using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using Telerik;
using Telerik.Web;
using Telerik.Web.UI;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


namespace EnableIndia.Candidate.ProfileHistory
{
    public partial class SocioEconomicList : System.Web.UI.Page
    {
        public int candidateID
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cand"] != null)
            {
                this.candidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"]));
            }
            GetCandidateDetail();
            GetSocioEconomicIndicator();
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
        private void GetSocioEconomicIndicator()
        {
            Old_App_Code.BAL.SocioEconomicIndicatorBAL seib = new Old_App_Code.BAL.SocioEconomicIndicatorBAL();
            DataTable dt = seib.GetSocialEconomicIndicator(this.candidateID.ToString());
            this.LstViewExistingSocioEconomicIndicator.DataSource = dt;
            this.LstViewExistingSocioEconomicIndicator.DataBind();
        }
        protected void LnkSecId_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            ListViewItem lv = (ListViewItem)lb.NamingContainer;
            string secId = lb.Attributes["secid"];
            string lbId = (lv.DataItemIndex + 1).ToString();
            string url = "~/Candidate/SocioEconomicIndicator.aspx?cand=" + Global.EncryptID(Convert.ToInt32(this.candidateID));
            url += "&secId=" + secId;
            url += "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
            invokeRadWindow(url);
        }
        protected void btnAddSeCClicked(object sender, EventArgs e)
        {
            string url = "~/Candidate/SocioEconomicIndicator.aspx?cand=" + Global.EncryptID(Convert.ToInt32(this.candidateID));
            url += "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
            invokeRadWindow(url);
        }
        private void invokeRadWindow(string url)
        {
            RadWindow rw = new RadWindow();
            rw.NavigateUrl = url;
            rw.Width = 900;
            rw.Height = 600;
            rw.Top = 0;
            rw.Left = 0;
            rw.MaxHeight = 600;
            rw.MaxWidth = 900;
            rw.Modal = true;
            rw.Behaviors = WindowBehaviors.Maximize | WindowBehaviors.Maximize | WindowBehaviors.Move | WindowBehaviors.Reload | WindowBehaviors.Close;
            rw.KeepInScreenBounds = true;
            //            rw.Behavior = WindowBehaviors.Default;
            rw.ReloadOnShow = true;
            rw.ShowContentDuringLoad = false;
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

    }
}