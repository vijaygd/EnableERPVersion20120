using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI.DataVisualization;

namespace EnableIndia.Company
{
    public partial class ListOfOpenEmploymentProject : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }
            Global.AuthenticateUser();
            Global.SetUICulture(this.Page);
            Global.SetDefaultButtonOfTheForm(this.Form, BtnSearch);

            if (!Page.IsPostBack)
            {
                DdlCompanyCode.Focus();

                //populate company code  in hidden company dropdown
                EnableIndia.App_Code.BAL.CompaniesBAL company = new EnableIndia.App_Code.BAL.CompaniesBAL();
                MySqlDataReader drCompanies = company.GetCompanies("-1");
                Global.FillDropDown(DdlCompanyCode, drCompanies, "company_code", "company_id");
                if (DdlCompanyCode.Items.Count > 1)
                {
                    DdlCompanyCode.Items[0].Text = "All";
                    DdlCompanyCode.Items[0].Value = "-1";
                }

                EnableIndia.App_Code.BAL.VacancyBAL vacancycode = new EnableIndia.App_Code.BAL.VacancyBAL();
                MySqlDataReader drVacancyCodes = vacancycode.GetVacancyCodes();
                Global.FillDropDown(DdlVacancyCode, drVacancyCodes, "vacancy_name", "vacancy_id");
                if (DdlVacancyCode.Items.Count > 1)
                {
                    DdlVacancyCode.Items[0].Text = "All";
                    DdlVacancyCode.Items[0].Value = "-1";
                }

                EnableIndia.App_Code.BAL.EmployeeBAL employee = new EnableIndia.App_Code.BAL.EmployeeBAL();
                MySqlDataReader drEmployees = employee.GetEmployeeListReader();
                Global.FillDropDown(DdlManagedByEmployee, drEmployees, "employee_name", "employee_id");
                if (DdlManagedByEmployee.Items.Count > 0)
                {
                    DdlManagedByEmployee.Items[0].Text = "All";
                    DdlManagedByEmployee.Items[0].Value = "-1";
                }
                Global.ShowMessageInAlert(this.Form);
                
            }
            registerLbPostBackControl();
            if (Page.IsPostBack)
            {
                //if (!string.IsNullOrEmpty(this.hrtbChanged.Value))
                //{
                //    int iRow = Convert.ToInt32(this.hrtbChanged.Value.ToString());
                //    RadioButton rb = (RadioButton)this.LstViewEmploymentProjects.Items[iRow].FindControl("RdbEmploymentProject");
                //    RadioButton orb = rb;
                //    if (rb != null)
                //    {
                //        rb.Checked = true;
                //        rb.InputAttributes["checked"] = "true";
                //        int i = 0;
                //        for (i = 0; i < iRow; i++)
                //        {
                //            rb = (RadioButton)this.LstViewEmploymentProjects.Items[i].FindControl("RdbEmploymentProject");
                //            rb.Checked = false;
                //        }
                //        for (i = iRow + 1; i < this.LstViewEmploymentProjects.Items.Count; i++)
                //        {
                //            rb = (RadioButton)this.LstViewEmploymentProjects.Items[i].FindControl("RdbEmploymentProject");
                //            rb.Checked = false;
                //        }
                //        orb.Focus();
                //    }
                //}
            }
            //if (Session["role_id"] != null)
            //{
            //    if (Session["role_id"].ToString() == "1")
            //    {
            //        disableControls(Page);
            //    }
            //}

        }
        private void registerLbPostBackControl()
        {
            int i = 0;
            for(i = 0;i < this.LstViewEmploymentProjects.Items.Count;i++)
            {
                RadioButton rb = this.LstViewEmploymentProjects.Items[i].FindControl("RdbEmploymentProject") as RadioButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(rb);
            }
        }
        protected void BtnDeleteProject_Click(object sender, EventArgs e)
        {
            foreach (ListViewDataItem item in LstViewEmploymentProjects.Items)
            {
                RadioButton RdbEmploymentProject = (RadioButton)item.FindControl("RdbEmploymentProject");
                if (RdbEmploymentProject.Checked)
                {
                    string EmploymentProjectID = RdbEmploymentProject.Attributes["EmploymentProjectID"].ToString();
                    string message = String.Empty;
                    MySqlConnection conn = Global.GetConnectionString();
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("", conn);
                    cmd.CommandText = "delete from employment_projects where employment_project_id=" + Global.DecryptID(Convert.ToDouble(EmploymentProjectID));
                    cmd.ExecuteNonQuery();

                    string script = String.Empty;

                    script = "alert('Project deleted successfully.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "__key", script, true);
                }
            }
            BtnSearch_Click(BtnSearch, new EventArgs());
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            EnableIndia.App_Code.BAL.EmploymentProjectBAL search = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            search.CompanyID = Convert.ToInt32(DdlCompanyCode.Value);
            search.VacancyID = Convert.ToInt32(DdlVacancyCode.Value);
            search.EmployeeID = Convert.ToInt32(DdlManagedByEmployee.Value);
            try
            {
                search.PossibleStartDateFrom = Convert.ToDateTime(TxtPossibleStartDateFrom.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                search.PossibleStartDateFrom = "1900/1/1";
            }

            try
            {
                search.PossibleStartDateTo = Convert.ToDateTime(TxtPossibleStartDateTo.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                search.PossibleStartDateTo = "5000/1/1";
            }

            try
            {
                search.PossibleEndDateFrom = Convert.ToDateTime(TxtPossibleEndDateFrom.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                search.PossibleEndDateFrom = "1900/1/1";
            }

            try
            {
                search.PossibleEndDateTo = Convert.ToDateTime(TxtPossibleEndDateTo.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                search.PossibleEndDateTo = "5000/1/1";
            }
            search.ProjectStatus = DdlProjectStatus.Value;

            LstViewEmploymentProjects.DataSource = search.SearchOpenEmploymentProjects(search);
            LstViewEmploymentProjects.DataBind();
        }

        protected void BtnEnterEmploymentProjectCycle_Click(object sender, EventArgs e)
        {
            foreach (ListViewDataItem item in LstViewEmploymentProjects.Items)
            {
                RadioButton RdbEmploymentProject = (RadioButton)item.FindControl("RdbEmploymentProject");
                //string url = "~/Company/AddRecommendedCandidate.aspx?emp_proj=" + RdbEmploymentProject.Attributes["EmploymentProjectID"].ToString();
                //url += "&comp=" + RdbEmploymentProject.Attributes["CompanyID"].ToString();
                
                //string url = "~/Company/AddRecommendedCandidate.aspx?emp_proj=" + Global.EncryptID(Convert.ToInt32(RdbEmploymentProject.Attributes["EmploymentProjectID"].ToString()));
                //url += "&comp=" + RdbEmploymentProject.Attributes["CompanyID"].ToString();
                int empPrjId = Global.DecryptID(Convert.ToDouble(RdbEmploymentProject.Attributes["EmploymentProjectID"].ToString()));
                 string url = "~/Company/AddRecommendedCandidate.aspx?emp_proj=" + Global.EncryptID(Convert.ToInt32(empPrjId));
                url += "&comp=" + RdbEmploymentProject.Attributes["CompanyID"].ToString();
               
                TableCell tc2 = (TableCell)item.FindControl("ped");
                
                if (RdbEmploymentProject.Checked)
                {
                    string intStDate = RdbEmploymentProject.Attributes["IntStDate"].ToString();
                    string intEdDate = RdbEmploymentProject.Attributes["IntEdDate"].ToString();
                    url += "&IntStDate=" + intStDate;
                    url += "&IntEdDate=" + intEdDate;
                    Response.Redirect(url, true);
                }
            }
        }

        protected void BtnViewAssignedList_Click(object sender, EventArgs e)
        {
            foreach (ListViewDataItem item in LstViewEmploymentProjects.Items)
            {
                RadioButton RdbEmploymentProject = (RadioButton)item.FindControl("RdbEmploymentProject");
                string url = "~/Company/AssignedList.aspx?emp_proj=" + RdbEmploymentProject.Attributes["EmploymentProjectID"].ToString();
                url += "&comp=" + RdbEmploymentProject.Attributes["CompanyID"].ToString();
                if (RdbEmploymentProject.Checked)
                {
                    string intStDate = RdbEmploymentProject.Attributes["IntStDate"].ToString();
                    string intEdDate = RdbEmploymentProject.Attributes["IntEdDate"].ToString();
                    url += "&IntStDate=" + intStDate;
                    url += "&IntEdDate=" + intEdDate;
                    Response.Redirect(url, true);
                }
            }
        }

        protected void LstViewEmploymentProjects_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl LblEmploymentProjectName = (HtmlGenericControl)e.Item.FindControl("LblEmploymentProjectName");
                RadioButton RdbEmploymentProject = (RadioButton)e.Item.FindControl("RdbEmploymentProject");
                LblEmploymentProjectName.Attributes.Add("for", RdbEmploymentProject.ClientID);
                HtmlAnchor LnkEmploymentProject = (HtmlAnchor)e.Item.FindControl("LnkEmploymentProject");
                HtmlAnchor LnkVacancies = (HtmlAnchor)e.Item.FindControl("LnkVacancies");

                string EmploymentProjectID = RdbEmploymentProject.Attributes["EmploymentProjectID"].ToString();
                string CompanyID = RdbEmploymentProject.Attributes["CompanyID"].ToString();
                string vacancyID = LnkVacancies.Attributes["VacancyID"].ToString();

                if (LnkEmploymentProject.InnerText == "")
                {
                    //RdbTrainingProject.Visible = false;
                    LnkEmploymentProject.Visible = false;
                }
                else
                {
                    LnkEmploymentProject.Visible = true;
                    //RdbTrainingProject.Visible = true;
                }
                if (!vacancyID.ToString().Equals("-157367.87"))
                {
                    LnkVacancies.Visible = true;
                }
                else
                {
                    LnkVacancies.Visible = false;
                }
                if (LnkEmploymentProject.InnerText == "Not Opened")
                {
                    LnkEmploymentProject.HRef = "~/Company/AddEmploymentProjects.aspx?comp=" + CompanyID;

                }
                //ListViewItem lvi = e.Item;
                //RadioButton rb = (RadioButton)lvi.FindControl("RdbEmploymentProject");
                //rb.Attributes.Add("onclick", "rbClicked('" + rb.UniqueID + "')");
                //ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(rb);

            }

        }
        protected void LstViewEmploymentProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            var checkBoxes = this.Controls.FindAll().OfType<CheckBox>();
            foreach (var cb in checkBoxes)
            {
                cb.Enabled = false;
            }

        }
        protected void RdbEmploymentProjectChanged(object sender, EventArgs e)
        {
            this.updEmpProjects.Update();
        }
    }
}
