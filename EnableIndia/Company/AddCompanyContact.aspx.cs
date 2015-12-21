using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Company
{

    public partial class AddCompanyContact : System.Web.UI.Page
    {
        public string CompanyContactID
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }

            if (Request.QueryString["cont"] != null)
            {
                this.CompanyContactID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cont"])).ToString();
                this.Page.Title = "Update Company Contact";
            }
            else
            {
                this.CompanyContactID = "-2";
                this.Page.Title = "Add Company Contact";
            }

            if (!Page.IsPostBack)
            {

                if (!this.CompanyContactID.Equals("-2"))
                {
                    GetCompanyContactDetail();
                    BtnDeleteContact.Visible = true;

                }
                Global.ShowMessageInAlert(this.Form);
                this.txtParent.Value = Request.QueryString["txboxId"];
            }
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }

        }


        private void GetCompanyContactDetail()
        {
            CompanyContactsBAL companycontact = new CompanyContactsBAL();
            //string companyContactID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cont"])).ToString();
            MySqlDataReader drCompanyContactDetail = companycontact.GetCompanyContactDetails(this.CompanyContactID);
            if (drCompanyContactDetail.Read())
            {

                TxtNameOfContact.Text = drCompanyContactDetail["contact_name"].ToString();
                DdlTypeOfContact.Value = drCompanyContactDetail["contact_type"].ToString();
                TxtDesignation.Text = drCompanyContactDetail["designation"].ToString();
                TxtPhoneNumber.Text = drCompanyContactDetail["phone_number"].ToString();
                TxtEmail.Text = drCompanyContactDetail["email_address"].ToString();
            }
            drCompanyContactDetail.Close();
            drCompanyContactDetail.Dispose();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            int companyID = Global.DecryptID(Convert.ToDouble(Request.QueryString["comp"]));

            CompanyContactsBAL companycontact = new CompanyContactsBAL();

            //if (Request.QueryString["cont"] != null)
            //{
            //    companycontact.ContactID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cont"]));
            //}
            companycontact.CompanyID = companyID;
            companycontact.ContactName = TxtNameOfContact.Text.Trim();
            companycontact.ContactType = DdlTypeOfContact.Value;
            companycontact.Designation = TxtDesignation.Text.Trim();
            companycontact.PhoneNumber = TxtPhoneNumber.Text.Trim();
            companycontact.EmailAddress = TxtEmail.Text.Trim();
            string message = "";
            if (Request.QueryString["cont"] != null)
            {
                companycontact.ContactID = Convert.ToInt32(this.CompanyContactID);
                bool isCompanyContactUpdated = companycontact.UpdateCompanyContact(companycontact);
                if (isCompanyContactUpdated.Equals(true))
                {
                    //Global.RedirectAfterSubmit("Contact Updated Successfully", BtnSubmit.ID);
                    message = "Contact Updated Successfully";
                    
                }
                else
                {
                    // Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
                    message = "Error occurred. Please contact the administrator.";
                }
            }
            else
            {

                bool CompanyContactAdded = companycontact.AddCompanyContact(companycontact);
                if (CompanyContactAdded.Equals(true))
                {
                    //Global.RedirectAfterSubmit("Company Contact added successfully.", BtnSubmit.ID);
                    //Global.ClearAll(this.Form);
                    message = "Company Contact added successfully.";
                }
                else
                {
                    Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
                    message = "Error occurred. Please contact the administrator.";
                }
                BtnSubmit.Focus();
            }
            closePage(message);
        }

        protected void BtnDeleteCompanyContact_Click(object sender, EventArgs e)
        {
            CompanyContactsBAL contact = new CompanyContactsBAL();
            bool isDeleted = contact.DeleteCompanyContact(this.CompanyContactID);
            string script = String.Empty;
            if (isDeleted.Equals(true))
            {
                script = "alert('Contact deleted successfully.');self.close();";
                ClientScript.RegisterStartupScript(this.GetType(), "__key", script, true);
            }
            else
            {
                script = "alert('" + Global.GetGlobalErrorMessage() + "');";
                ClientScript.RegisterStartupScript(this.GetType(), "__key", script, true);
            }
        }
        private void closePage(string message)
        {
            string url = "";
            if (string.IsNullOrEmpty(message))
            {
                url = "self.parent.location.replace('" + this.txtParent.Value + "')";
            }
            else
            {
                url = "window.alert('" + message + "');self.parent.location.replace('" + this.txtParent.Value + "');";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", url, true);
            // Response.Redirect(this.txtParent.Value);
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

    }
}