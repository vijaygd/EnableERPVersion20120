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

namespace EnableIndia.NGO
{
    public partial class Contacts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["cont"] != null)
                {
                    BtnDeleteContact.Visible = true;
                    
                    GetNGOContactDetails();
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

        }

        private void GetNGOContactDetails()
        {
            NGOContactsBAL contact = new NGOContactsBAL();
            MySqlDataReader drContactDetails = contact.GetNGOContactDetails(Global.DecryptID(Convert.ToDouble(Request.QueryString["cont"])).ToString());
            drContactDetails.Read();

            DdlCandidateTypes.Value = drContactDetails["type_of_contact"].ToString();
            TxtContactName.Text = drContactDetails["contact_name"].ToString();
            TxtDesignation.Text = drContactDetails["designation"].ToString();
            TxtPhoneNumber.Text = drContactDetails["phone_number"].ToString();
            TxtEmailAddress.Text = drContactDetails["email_address"].ToString();

            drContactDetails.Close();
            drContactDetails.Dispose();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            int ngoID = Global.DecryptID(Convert.ToDouble(Request.QueryString["ngo"]));

            NGOContactsBAL contact = new NGOContactsBAL();

            if (Request.QueryString["cont"] != null)
            {
                contact.ContactID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cont"]));
            }

            contact.NgoID = ngoID;
            contact.TypeOfContact = DdlCandidateTypes.Value;
            contact.ContactName = TxtContactName.Text.Trim();
            contact.Designation = TxtDesignation.Text.Trim();
            contact.PhoneNumber = TxtPhoneNumber.Text.Trim();
            contact.EmailAddress = TxtEmailAddress.Text.Trim();

            if (Request.QueryString["cont"] != null)
            {
                bool isContactUpdated = contact.UpdateNGOContact(contact);
                if (isContactUpdated.Equals(true))
                {
                    //Global.ShowMessagesInDiv(this.Page, "Contact updated successfully.");
                    //Global.ClearAll(this.Form);
                    Global.RedirectAfterSubmit("Contact updated successfully.", BtnSubmit.ID);
                }
                else
                {
                    Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
                }
            }
            else
            {
                bool isContactAdded = contact.AddNGOContact(contact);
                if (isContactAdded.Equals(true))
                {
                    //Global.ShowMessagesInDiv(this.Page, "Contact added successfully.");
                    Global.RedirectAfterSubmit("Contact added successfully.", BtnSubmit.ID);
                    Global.ClearAll(this.Form);
                }
                else
                {
                    Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
                }
            }

            BtnSubmit.Focus();
        }

        protected void BtnDeleteNGOContact_Click(object sender, EventArgs e)
        {
            NGOContactsBAL delete = new NGOContactsBAL();
            bool isDeleted = delete.DeleteNGOContact(Global.DecryptID(Convert.ToDouble(Request.QueryString["cont"])).ToString());
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