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
using EnableIndia.App_Code.DAL;
using EnableIndia.App_Code.BAL;

namespace EnableIndia.Candidate.Registration
{

    public partial class UnregisteredBlankForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlInputButton)this.Master.FindControl("BtnViewDataOptions")).Visible = true;

            Global.SetDefaultButtonOfTheForm(this.Form, BtnCreate);
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }

            if (!Page.IsPostBack)
            {
                Global.AuthenticateUser();

                GetUnregisteredCandidates();
                if (Session["role_id"] != null)
                {
                    if (Session["role_id"].ToString() == "1")
                    {
                        disableControls(Page);
                    }
                }

            }
        }

        private void GetUnregisteredCandidates()
        {
            CandidatesBAL get = new CandidatesBAL();
            LstViewUnregisteredCandidates.DataSource = get.GetUnregisteredCandidates();
            LstViewUnregisteredCandidates.DataBind();
        }

        protected void LstViewUnregisteredCandidates_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl LblRegistration = (HtmlGenericControl)e.Item.FindControl("LblRegistration");
                CheckBox ChkCandidateRegistration = (CheckBox)e.Item.FindControl("ChkCandidateRegistration");

                LblRegistration.Attributes.Add("for", ChkCandidateRegistration.ClientID);
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            if (!checkValues()) return;
            CandidatesBAL cand = new CandidatesBAL();
            string errorMessage = "";
            string createdCandidates = cand.CreateUnregisteredCandidates(TxtNumberOfNewForms.Text.Trim(), DdlNgos.Value, out errorMessage);
            if (!createdCandidates.Contains("*") && !createdCandidates.Equals(""))
            {
                Global.ShowMessagesInDiv(this.Page, "Forms created successfully.");
                Global.ClearAll(this.Form);
            }
            else
            {
                Global.ShowMessagesInDiv(this.Page, errorMessage);
            }

            GetUnregisteredCandidates();
            TxtNumberOfNewForms.Text = "";
            DdlNgos.Value = "-2";
        }
        private bool checkValues()
        {
            if (string.IsNullOrEmpty(this.TxtNumberOfNewForms.Text))
            {
                MsgBox("Number of forms required");
                return false;
            }
            if(Convert.ToInt32(this.TxtNumberOfNewForms.Text) < 50)
            {
                MsgBox("Number of forms should not be more than 50.");
                return false;
            }
    
            return true;
        }
        protected void BtnPrint_click(object sender, EventArgs e)
        {
            if (!checkValues()) return;
            //Session ["checkCandidateID"]
            string selectedCandidates = String.Empty;
            foreach (ListViewDataItem item in LstViewUnregisteredCandidates.Items)
            {
                CheckBox ChkCandidateRegistration = (CheckBox)item.FindControl("ChkCandidateRegistration");
                if (ChkCandidateRegistration.Checked)
                {
                    selectedCandidates += (ChkCandidateRegistration.Attributes["CandidateRID"]).ToString() + ",";
                }
            }

            Session["SelectedCandidates"] = selectedCandidates.Substring(0, selectedCandidates.Length - 1);
            ClientScript.RegisterStartupScript(this.GetType(), "__Popup", "ShowPopUp('UnregisteredBlankPrintForm.aspx',1024,768);", true);
        }

        protected void BtnCreatePrint_Click(object sender, EventArgs e)
        {
            CandidatesBAL cand = new CandidatesBAL();
            string errorMessage = "";
            string createdCandidates = cand.CreateUnregisteredCandidates(TxtNumberOfNewForms.Text.Trim(), DdlNgos.Value, out errorMessage);
            GetUnregisteredCandidates();
            if (!createdCandidates.Contains("*") && !createdCandidates.Equals(""))
            {
                Session["SelectedCandidates"] = createdCandidates;
                ClientScript.RegisterStartupScript(this.GetType(), "__Popup", "ShowPopUp('UnregisteredBlankPrintForm.aspx',1024,768);", true);
            }
            TxtNumberOfNewForms.Text = "";
            DdlNgos.Value = "-2";
        }

        //protected void LnkBtnGoToRegistrationForm_Click(object sender, EventArgs e)
        //{
        //    int candidateID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
        //    if(((LinkButton)sender).Attributes["NgoID"].Equals("1"))
        //    {
        //        Response.Redirect("~/Candidate/Registration/EnableIndiaCandidate.aspx?cand=" + Global.EncryptID(candidateID).ToString(), true);
        //    }
        //    else
        //    {
        //        Response.Redirect("~/Candidate/Registration/OtherNGOCandidate.aspx?cand=" + Global.EncryptID(candidateID).ToString(), true);
        //    }
        //}
        private void MsgBox(string message)
        {
            webMessageBox wb = new webMessageBox();
            wb.Show(message);
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
        }
 
    }
}