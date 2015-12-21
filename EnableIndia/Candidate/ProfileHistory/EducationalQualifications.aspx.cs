using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using Telerik;
using Telerik.Web;
using Telerik.Web.UI;
using System.Text;
using System.Text.RegularExpressions;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


namespace EnableIndia.Candidate.ProfileHistory
{

    public partial class EducationalQualifications : System.Web.UI.Page
    {
        string[,] eduArray;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }

            GetCandidateDetail();
            GetCandidateEducationalQualifications();
            Global.SetDefaultButtonOfTheForm(this.Form, BtnAddMoreQualifications);
            if (!Page.IsPostBack)
            {

                Global.AuthenticateUser();

                if (Request.QueryString["cand"] != null)
                {
                    LnkBtnRegistration.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnWorkExperience.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnKnowledgeAndTraining.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnJobProfiling.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkButtonCandidateHistory.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();

                    GetCandidateEducationalQualifications();
                    BtnAddMoreQualifications.Visible = true;
                }
                else
                {
                    BtnAddMoreQualifications.Visible = false;
                }
            }
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }
        }

        private void GetCandidateDetail()
        {
            CandidatesBAL cand = new CandidatesBAL();
            MySqlDataReader drCandidateDetails = cand.GetCandidateDetails(Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString());
            if (drCandidateDetails.Read())
            {
                SpnCandidateFirstName.InnerText = drCandidateDetails["candidate_name"].ToString();
                //SpnCandidateFirstName.InnerText = drCandidateDetails["first_name"].ToString();
                //SpnCandidateMiddleName.InnerText = drCandidateDetails["middle_name"].ToString();
                //SpnCandidateLastName.InnerText = drCandidateDetails["last_name"].ToString();
                SpnDisabilityType.InnerText = drCandidateDetails["disability_type"].ToString();
                SpnRID.InnerText = drCandidateDetails["registration_id"].ToString();
                SpnStatus.InnerText = drCandidateDetails["employment_state"].ToString();

                SpnOtherQualifications.InnerText = drCandidateDetails["other_educational_qualifications"].ToString();
                drCandidateDetails.Close();
                drCandidateDetails.Dispose();
            }
        }



        private void GetCandidateEducationalQualifications()
        {
            string candidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString();
            CandidateEducationalQualificationsBAL cand = new CandidateEducationalQualificationsBAL();
            LstViewEducationalQualifications.DataSource = cand.GetCandidateEducationalQualifications(candidateID);
            LstViewEducationalQualifications.DataBind();
        }

        //protected void LstViewEducationalQualifications_ItemDataBound(object sender, ListViewItemEventArgs e)
        //{
        //    if(e.Item.ItemType.Equals(ListViewItemType.DataItem))
        //    {
        //        HtmlGenericControl LblCourseQualificationName = (HtmlGenericControl)e.Item.FindControl("LblCourseQualificationName");
        //        RadioButton RdbSelectQualifiaction = (RadioButton)e.Item.FindControl("RdbSelectQualifiaction");

        //        LblCourseQualificationName.Attributes.Add("for", RdbSelectQualifiaction.ClientID);
        //    }
        //}

        protected void BtnAddMoreQualifications_Click(object sender, EventArgs e)
        {
            GetCandidateEducationalQualifications();
            BtnAddMoreQualifications.Focus();
            string orgUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            int fEqual = orgUrl.IndexOf((char)'=');
            string candId = orgUrl.Substring(fEqual + 1, (orgUrl.Length - (fEqual + 1)));
            string url = "~/Candidate/EducationalQualificationsPopUp.aspx?cand=" + candId;
            popEduArray();
            invokeRadWindow(url);
        }

        protected void LnkBtnCourseQualificationName_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;

            GetCandidateEducationalQualifications();
            //OnClientClick="javascript:ShowEducationalQualificationsPopup(1,this.id);
            string CourseQualId = lb.Attributes["CourseQualificationID"];
            //string showPopup = "javascript:ShowEducationalQualificationsPopup('" + CourseQualId + "', '" + lb.ClientID + "')";
            string orgUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            int fEqual = orgUrl.IndexOf((char)'=');
            string parntId = lb.Parent.ID;
            string sindex = Regex.Replace(parntId, @"[^\d]", String.Empty);
            string candId = orgUrl.Substring(fEqual + 1, (orgUrl.Length - (fEqual + 1)));
            string url = "~/Candidate/EducationalQualificationsPopUp.aspx?Index=" + sindex + "&cand=" + candId + "&cand_qual=" + CourseQualId;
            popEduArray();
            invokeRadWindow(url);
        }

        private void popEduArray()
        {
            int i = 0;
            string qual = "";
            string year = "";
            if (this.LstViewEducationalQualifications.Items.Count > 0)
            {
                eduArray = new string[this.LstViewEducationalQualifications.Items.Count, 2];
                i = 0;
                foreach (System.Web.UI.WebControls.ListViewItem lv in this.LstViewEducationalQualifications.Items)
                {
                    LinkButton lb = (LinkButton)lv.FindControl("LnkBtnCourseQualificationName");
                    if (lb != null)
                    {
                        qual = lb.Attributes["CourseID"];
                        qual = Global.DecryptID(Convert.ToDouble(qual)).ToString();
                    }

                    //System.Web.UI.HtmlControls.HtmlTableCell tc1 = (System.Web.UI.HtmlControls.HtmlTableCell)lv.FindControl("qulName");
                    //qual = tc1.InnerText;
                    System.Web.UI.HtmlControls.HtmlTableCell tc2 = (System.Web.UI.HtmlControls.HtmlTableCell)lv.FindControl("passingYear");
                    year = tc2.InnerText;
                    eduArray[i, 0] = qual;
                    eduArray[i, 1] = year;
                    i++;
                }
                Session["eduArray"] = eduArray;
            }
            else
                Session["eduArray"] = null;

        }

        private void invokeRadWindow(string url)
        {
            RadWindow rw = new RadWindow();
            url += "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
            rw.NavigateUrl = url;
            rw.Width = 900;
            rw.Height = 600;
            rw.Top = 0;
            rw.Left = 0;
            rw.MaxHeight = 600;
            rw.MaxWidth = 900;
            rw.Modal = true;
            rw.Behaviors = WindowBehaviors.Maximize | WindowBehaviors.Close;
            rw.KeepInScreenBounds = true;
            //            rw.Behavior = WindowBehaviors.Default;
            rw.ReloadOnShow = true;
            rw.ID = "rwCenquiry";
            //   RadWindowManager rm = (RadWindowManager)this.Parent.FindControl("hradManager");
            this.radManager.Modal = true;
            this.radManager.VisibleOnPageLoad = true;
            rw.EnableViewState = false;
            rw.VisibleOnPageLoad = true;
            rw.AutoSize = false;
            this.radManager.EnableViewState = false;
            this.radManager.Windows.Add(rw);
            rw = this.radManager.Windows[0];
            return;
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