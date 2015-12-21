using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using Telerik;
using Telerik.Web;
using Telerik.Web.UI;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.MobileDevices.ProfileHistory
{
    public partial class mdAddViewCandidateHistory : System.Web.UI.Page
    {
        public string CandidateID
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

            Global.SetDefaultButtonOfTheForm(this.Form, BtnAddNewCandidateHistory);
            Global.AuthenticateUser();
            Global.SetUICulture(this.Page);

            if (Request.QueryString["cand"] != null)
            {
                CandidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString();
            }
            else
            {
                CandidateID = "-2";
            }
            if (!Page.IsPostBack)
            {
                Label lbh = this.Form.Parent.FindControl("lbHeader") as Label;
                if (lbh != null)
                {
                    lbh.Text = "Candidate History";
                }
 
                GetCandidateDetail();
                if (Request.QueryString["cand"] != null)
                {
                    LnkBtnRegistration.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnEducationalQualifications.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    this.LnkBtnWorkExprience.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnKnowledgeAndTraining.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnJobProfiling.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    GetCandidateHistory();
                }
            }
            this.Page.Title = SpnCandidateFirstName.InnerText + "'s" + " History";
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }

        }
        protected void LstViewHistoryAllCandidate_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                LinkButton LnkBtnHistoryDate = (LinkButton)e.Item.FindControl("LnkBtnHistoryDate");
                if (LnkBtnHistoryDate.Attributes["Status"].ToString().Equals("Closed"))
                {
                    LnkBtnHistoryDate.Visible = false;
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
                SpnDisabilityType.InnerText = drCandidateDetails["disability_type"].ToString();
                SpnRID.InnerText = drCandidateDetails["registration_id"].ToString();
                SpnStatus.InnerText = drCandidateDetails["employment_state"].ToString();

                drCandidateDetails.Close();
                drCandidateDetails.Dispose();
            }
        }

        private void GetCandidateHistory()
        {
            CandidateHistoryBAL history = new CandidateHistoryBAL();
            LstViewHistoryAllCandidate.DataSource = history.GetCandidateHistory(this.CandidateID);
            LstViewHistoryAllCandidate.DataBind();
        }

        protected void BtnAddNewCandidateHistory_Click(object sender, EventArgs e)
        {
            GetCandidateHistory();
            BtnAddNewCandidateHistory.Focus();
            invokeRadWindow(0);
        }

        protected void LnkBtnHistoryDate_Click(object sender, EventArgs e)
        {
            GetCandidateHistory();
            LinkButton lb = (LinkButton)sender;
            double historyId = Convert.ToDouble(lb.Attributes["CandidateHistoryID"]);
            invokeRadWindow(historyId);

        }
        private void invokeRadWindow(double histId)
        {
            //ITextPopup.aspx?page=add_view_cand_hist", 650, 150
            RadWindow rw = new RadWindow();
            // rw.NavigateUrl = "~/ITextPopup.aspx?page=" + historyId;
            if (histId == 0)
            {
                rw.NavigateUrl = "~/Candidate/ProfileHistory/AddViewCandidateHistoryPopup.aspx?cand=" + Global.EncryptID(Convert.ToInt32(this.CandidateID)) + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
            }
            else
            {
                rw.NavigateUrl = "~/Candidate/ProfileHistory/AddViewCandidateHistoryPopup.aspx?cand=" + Global.EncryptID(Convert.ToInt32(this.CandidateID)) + "&hist=" + histId + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
            }
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