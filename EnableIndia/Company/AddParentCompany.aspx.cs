using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Reflection;

using MySql.Data.MySqlClient;
namespace EnableIndia.Company
{

    public partial class AddParentCompany : System.Web.UI.Page
    {
        public string ParentCompanyID
        {
            get;
            set;
        }

        public string oldValues;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }

            if (Request.QueryString["par_comp"] != null)
            {
                this.ParentCompanyID = Global.DecryptID(Convert.ToDouble(Request.QueryString["par_comp"])).ToString();
                this.Title = this.Title.Replace("Add", "Update");
            }
            else
            {
                this.ParentCompanyID = "-2";
            }

            Global.SetDefaultButtonOfTheForm(this.Form, BtnManageParentCompany);

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["par_comp"] != null)
                {
                    SpnOperationStatus.InnerText = "Update";

                    GetParentCompany();
                    BtnClear.Visible = false;
                }
                Global.ShowMessageInAlert(this.Form);
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

        protected void GetParentCompany()
        {
            EnableIndia.App_Code.BAL.ParentCompaniesBAL parent = new EnableIndia.App_Code.BAL.ParentCompaniesBAL();
            MySqlDataReader drParent = parent.GetParentCompanies(this.ParentCompanyID);

            if (drParent.Read())
            {
                TxtParentCompanyName.Text = drParent["company_name"].ToString();
            }

            drParent.Close();
            drParent.Dispose();
        }

        protected void BtnManageParentCompany_Click(object sender, EventArgs e)
        {
            EnableIndia.App_Code.BAL.ParentCompaniesBAL company = new EnableIndia.App_Code.BAL.ParentCompaniesBAL();

            int duplicateParentCompanies = company.CheckForDuplicateParentCompany(this.ParentCompanyID, TxtParentCompanyName.Text.Trim());
            if (duplicateParentCompanies > 0)
            {
                Global.RedirectAfterSubmit("Parent Company already exists.", BtnManageParentCompany.ID);
            }
            string newValues = "<b>Parent Company Id: </b>" +  this.ParentCompanyID + ", <b>Parent Company Name: </b>" +  TxtParentCompanyName.Text.TrimStart().TrimEnd();
    
            if (this.ParentCompanyID.Equals("-2"))
            {
                this.ParentCompanyID = company.AddParentCompany(TxtParentCompanyName.Text.TrimStart().TrimEnd()).ToString();
                if (Convert.ToInt32(this.ParentCompanyID) > 0)
                {
                    //Global.RedirectAfterSubmit("Parent company added successfully.", BtnManageParentCompany.ID);
                    string url = "~/Company/AddParentCompany.aspx?par_comp=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(this.ParentCompanyID));
                    url += "&msg=" + Global.EncryptQueryString("Parent company added successfully.");
                    url += "&foc=" + Global.EncryptQueryString("null");
                    Global.createAuditTrial(this.Title, newValues, "", null, "Insert", Session["username"].ToString());
                    Response.Redirect(url, true);
                }
                else
                {
                    Global.RedirectAfterSubmit(Global.GetGlobalErrorMessage(), BtnManageParentCompany.ID);
                }
            }
            else
            {
                company.ParentCompanyID = Convert.ToInt32(this.ParentCompanyID);
                company.ParentCompanyName = TxtParentCompanyName.Text.Trim();
                bool isAdded = company.UpdateParentCompany(company);
                if (isAdded.Equals(true))
                {
                    Global.ShowMessagesInDiv(this.Page, "Parent company updated successfully.");
                    Global.createAuditTrial(this.Title, newValues, oldValues, null, "Update", Session["username"].ToString());
                    //Global.RedirectAfterSubmit("Parent company updated successfully.", BtnManageParentCompany.ID);
                }
                else
                {
                    Global.RedirectAfterSubmit(Global.GetGlobalErrorMessage(), BtnManageParentCompany.ID);
                }

            }
            BtnManageParentCompany.Focus();
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Company/AddParentCompany.aspx", true);
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
            oldValues = "<b>Parent Company Id: </b>" + this.ParentCompanyID +  ", ";
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
                oldValues += "<b>" + s.ID + ":  </b>" + s.DataTextField + ", ";
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