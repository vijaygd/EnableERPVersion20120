using System;
using System.Linq;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Reflection;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Company
{
    public partial class AddViewCompanyHistoryPopup : System.Web.UI.Page
    {
        public string oldValues;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }

            Global.SetDefaultButtonOfTheForm(this.Form, BtnAddUpdateCompanyHistory);
            Global.AuthenticateUser();
            Global.SetUICulture(this.Page);

            EnableIndia.App_Code.BAL.CompaniesBAL company = new EnableIndia.App_Code.BAL.CompaniesBAL();
            MySqlDataReader drCompany = company.GetCompanies("-1");
            while (drCompany.Read())
            {
                ListItem li = new ListItem(drCompany["company_code"].ToString(), drCompany["company_id"].ToString());
                li.Attributes.Add("ParentCompanyID", drCompany["parent_company_id"].ToString());
                DdlHiddenCompany.Items.Add(li);
            }

            drCompany.Close();
            drCompany.Dispose();

            DdlHiddenCompany.Items.Insert(0, new ListItem("Select", "-2"));
            DdlHiddenCompany.Items.Add(new ListItem("Not Available", "-3"));

            if (Request.QueryString["par_comp"] != null)
            {
                GetParentCompanyName();
                this.hdField.Value = "1";
            }
            else
            {
                this.hdField.Value = "0";
            }

            if (!Page.IsPostBack)
            {
                //Gets parent companies
                EnableIndia.App_Code.BAL.ParentCompaniesBAL parentComp = new EnableIndia.App_Code.BAL.ParentCompaniesBAL();
                MySqlDataReader drParentCompanies = parentComp.GetParentCompanies();
                Global.FillDropDown(DdlParentCompanies, drParentCompanies, "company_name", "company_id");

                CompanyFlagsBAL candidateHistory = new CompanyFlagsBAL();
                MySqlDataReader drCandidateHistory = candidateHistory.GetCompanyFlags(false);
                Global.FillDropDown(DdlFlags, drCandidateHistory, "flag_name", "flag_id");

                EnableIndia.App_Code.BAL.EmployeeBAL employee = new EnableIndia.App_Code.BAL.EmployeeBAL();
                DdlTaskManagedByEmployee.DataSource = employee.GetEmployeeList();
                DdlTaskManagedByEmployee.DataTextField = "employee_name";
                DdlTaskManagedByEmployee.DataValueField = "employee_id";
                DdlTaskManagedByEmployee.DataBind();

                if (DdlTaskManagedByEmployee.Items.Count > 0)
                {
                    DdlTaskManagedByEmployee.Items.Insert(0, new ListItem("Select", "-2"));
                }
                else
                {
                    DdlTaskManagedByEmployee.Items.Add(new ListItem("Not Available", "-2"));
                }
                if (Request.QueryString["comp_hist"] != null)
                {
                    BtnDeleteCompanyHistory.Visible = true;
                    LblUpdateStatus.Visible = true;
                    DdlUpdateStatus.Visible = true;

                    TblParentCompany.Visible = false;
                    TblCompany.Visible = false;
                    TblCompanyDetail.Visible = true;
                    TblMessageUpdate.Visible = true;
                    GetCompanyHistoryDetails();
                    if (DdlFlags.Visible == false)
                    {
                        TxtDetails.Enabled = false;
                        DdlTaskManagedByEmployee.Disabled = true;
                        TxtRecommendedAction.Enabled = false;
                        TxtFollowUpDate.Enabled = false;
                        DdlUpdateStatus.Disabled = true;
                    }
                }
                Global.ShowMessageInAlert(this.Form);
                if (Request.QueryString["comp_hist"] == null)
                {
                    LblUpdateStatus.Visible = false;
                    DdlUpdateStatus.Visible = false;

                    TblParentCompany.Visible = true;
                    TblCompany.Visible = true;
                    TblMessageAdd.Visible = true;
                    SpnDate.InnerText = DateTime.Today.ToString("dd/MM/yyyy");
                }
 
            }
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }
            if (!Page.IsPostBack)
            {
                storeValues();
            }
            if (Page.IsPostBack)
            {
                if (ViewState["oldValues"] != null)
                {
                    oldValues = ViewState["oldValues"].ToString();
                }
            }

       }

        private void GetParentCompanyName()
        {
            DdlCompanies.Visible = false;
            DdlParentCompanies.Visible = false;
            EnableIndia.App_Code.BAL.ParentCompaniesBAL company = new EnableIndia.App_Code.BAL.ParentCompaniesBAL();
            string parentCompanyID = Global.DecryptID(Convert.ToDouble(Request.QueryString["par_comp"])).ToString();
            MySqlDataReader drParent = company.GetParentCompanies(parentCompanyID);
            if (drParent.Read())
            {
                SpnParentCompany.InnerText = drParent["company_name"].ToString();
            }
            drParent.Close();
            drParent.Dispose();

            CompaniesBAL comp = new CompaniesBAL();
            string CompanyID = Global.DecryptID(Convert.ToDouble(Request.QueryString["comp"])).ToString();
            MySqlDataReader drCompany = comp.GetcompanyDetails(CompanyID);
            if (drCompany.Read())
            {
                SpnCompany.InnerText = drCompany["company_code"].ToString();
            }
            drCompany.Close();
            drCompany.Dispose();
        }

        private void GetCompanyHistoryDetails()
        {
            CompaniesBAL company = new CompaniesBAL();
            string historyID = Global.DecryptID(Convert.ToDouble(Request.QueryString["comp_hist"])).ToString();
            MySqlDataReader drCompanyHistory = company.GetCompanyHistoryDetails(historyID);
            if (drCompanyHistory.Read())
            {
                SpnParentCompanyName.InnerText = drCompanyHistory["company_name"].ToString();
                SpnCompanyName.InnerText = drCompanyHistory["company_code"].ToString();
                SpnDate.InnerText = Convert.ToDateTime(drCompanyHistory["history_date"]).ToString("dd/MM/yyyy");
                TxtDetails.Text = drCompanyHistory["details"].ToString();
                DdlFlags.Value = drCompanyHistory["company_flag_id"].ToString();

                if (Convert.ToInt32(DdlFlags.Value) > 1)
                {
                    DdlFlags.Items.Remove(DdlFlags.Items.FindByValue("1"));
                }

                DdlTaskManagedByEmployee.Value = drCompanyHistory["assigned_to_employee_id"].ToString();
                TxtRecommendedAction.Text = drCompanyHistory["recommended_action"].ToString();
                //changes for changes in  follow of date 
                if (drCompanyHistory["follow_up_date"].ToString().Contains("1900"))
                {
                    TxtFollowUpDate.Text = "";
                }
                else
                {
                    TxtFollowUpDate.Text = Convert.ToDateTime(drCompanyHistory["follow_up_date"]).ToString("dd/MM/yyyy");
                }
                LblUpdateStatus.Visible = true;
                DdlUpdateStatus.Visible = true;
                DdlUpdateStatus.Value = drCompanyHistory["status"].ToString();

                BtnAddUpdateCompanyHistory.Text = BtnAddUpdateCompanyHistory.Text.Replace("Add", "Update");
                BtnAddUpdateCompanyHistory.ToolTip = BtnAddUpdateCompanyHistory.ToolTip.Replace("Add", "Update");
                if (drCompanyHistory["status"].ToString().Contains("Closed"))
                {
                    TxtDetails.Enabled = false;
                    DdlTaskManagedByEmployee.Disabled = true;
                    DdlFlags.Disabled = true;
                    TxtRecommendedAction.Enabled = false;
                    TxtFollowUpDate.Enabled = false;
                    DdlUpdateStatus.Disabled = true;
                }
                drCompanyHistory.Close();
                drCompanyHistory.Dispose();
            }
        }
        private void MsgBox(string message)
        {
            webMessageBox wb = new webMessageBox();
            wb.Show(message);
        }
        protected void BtnAddUpdateCompanyHistory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TxtDetails.Text))
            {
                MsgBox("Details textbox empty");
                return;
            }
            CompaniesBAL company = new CompaniesBAL();
            if (Request.QueryString["comp_hist"] != null)
            {
                company.HistoryID = Global.DecryptID(Convert.ToDouble(Request.QueryString["comp_hist"]));
            }

            try
            {
                company.HistoryDate = Convert.ToDateTime(SpnDate.InnerText.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                company.HistoryDate = DateTime.Now.ToString("yyyy/MM/dd");
            }

            if (Request.QueryString["comp_hist"] == null)
            {
                company.ParentCompanyID = Global.DecryptID(Convert.ToDouble(Request.QueryString["par_comp"]));
                company.CompanyID = Global.DecryptID(Convert.ToDouble(Request.QueryString["comp"]));
            }
            company.Details = TxtDetails.Text.Trim();
            company.CandidateFlagID = Convert.ToInt32(DdlFlags.Value);
            company.EmployeeID = Convert.ToInt32(DdlTaskManagedByEmployee.Value);
            company.RecommendedAction = TxtRecommendedAction.Text.Trim();
            company.CandidateID = 0;
            company.EmployemntProjectID = 0;
            company.IsHistory = 0;
            try
            {
                company.FollowUpDate = Convert.ToDateTime(TxtFollowUpDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                company.FollowUpDate = "1900/01/01";
            }
            company.Status = Convert.ToString(DdlUpdateStatus.Value);
            string newValues = "";
            Type type = company.GetType();
            PropertyInfo[] proterties = type.GetProperties();
            foreach (var p in proterties)
            {
                newValues += "<b>" + p.Name + ": </b>" + p.GetValue(company, null) + ", ";
            }
            if (!string.IsNullOrEmpty(newValues))
            {
                int l = newValues.LastIndexOf((char)',');
                if (l > 0)
                    newValues = newValues.Substring(0, l);
            }

            if (Request.QueryString["comp_hist"] != null)
            {
                bool rowsUpdated = company.UpdateCompanyHistory(company);
                if (rowsUpdated.Equals(true))
                {
                    Global.createAuditTrial(this.Title, newValues, oldValues, null, "Update", Session["username"].ToString());
                    Global.RedirectAfterSubmit("Company History Updated Successfully.", BtnAddUpdateCompanyHistory.ID);
                }
            }
            else
            {
                bool rowsAdded = company.AddCompanyHistory(company);
                if (rowsAdded.Equals(true))
                {
                    Global.createAuditTrial(this.Title, newValues, "", null, "Insert", Session["username"].ToString());
                    Global.RedirectAfterSubmit("Company History Added Successfully.", BtnAddUpdateCompanyHistory.ID);
                }
            }
        }

        protected void BtnDeleteCompanyHistory_Click(object sender, EventArgs e)
        {
            CompaniesBAL comp = new CompaniesBAL();
            int isDeleted = comp.DeleteCompanyHistory(Global.DecryptID(Convert.ToDouble(Request.QueryString["comp_hist"])), Global.DecryptID(Convert.ToDouble(Request.QueryString["comp"])), Global.DecryptID(Convert.ToDouble(Request.QueryString["par_comp"])));
            string script = String.Empty;

            if (isDeleted > 0)
            {
                script = "alert('Company history deleted successful.');self.close();";
                ClientScript.RegisterStartupScript(this.GetType(), "_Key", script, true);
            }
            else
            {
                script = "alert('" + Global.GetGlobalErrorMessage() + "');";
                ClientScript.RegisterStartupScript(this.GetType(), "_Key", script, true);
            }
        }
        public void disableControls(Control parent)
        {

            var textBoxes = this.Controls.FindAll().OfType<TextBox>();

            foreach (var t in textBoxes)
            {
                t.Enabled = false;
            }
            var dropDowns = this.Controls.FindAll().OfType<DropDownList>();
            foreach (var d in dropDowns)
            {
                d.Enabled = false;
            }
            var selects = this.Controls.FindAll().OfType<HtmlSelect>();
            foreach (var s in selects)
            {
                s.Disabled = true;
            }
            var buttons = this.Controls.FindAll().OfType<Button>();
            foreach (var b in buttons)
            {
                b.Enabled = false;
            }
        }

        private void storeValues()
        {
            oldValues = "";
            var textBoxes = this.Controls.FindAll().OfType<TextBox>();
            foreach (var t in textBoxes)
            {
                oldValues += "<b>" + t.ID + ": </b>" + t.Text + ", ";
            }
            var dropDowns = this.Controls.FindAll().OfType<DropDownList>();
            foreach (var d in dropDowns)
            {
                oldValues += "<b>" + d.ID + ": </b>" + d.SelectedItem.Text + ", ";
            }
            var selects = this.Controls.FindAll().OfType<HtmlSelect>();
            foreach (var s in selects)
            {
                oldValues += "<b>" + s.ID + ":  </b>" + s.Value + ", ";
            }
            var checkBoxes = this.Controls.FindAll().OfType<CheckBox>();
            foreach (var cb in checkBoxes)
            {
                oldValues += "<b>" + cb.ID + ": </b>" + (cb.Checked ? "1" : "0").ToString();
            }
            var radioButtons = this.Controls.FindAll().OfType<RadioButton>();
            foreach (var rb in radioButtons)
            {
                oldValues += "<b>" + rb.ID + ": </b>" + (rb.Checked ? "1" : "0").ToString();
            }
            if (!string.IsNullOrEmpty(oldValues))
            {
                int l = oldValues.LastIndexOf(",");
                if (l > 0)
                    oldValues = oldValues.Substring(0, l);  // Remove the last unwanted ,
            }
            ViewState["oldValues"] = oldValues;
        }
    }
}