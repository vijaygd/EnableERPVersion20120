using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
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

    public partial class CandidateWorkExperience : System.Web.UI.Page
    {
        [Serializable]
        public class wkDates
        {
            public string stDate { get; set; }
            public string edDate { get; set; }
            public bool bCurrentFlag { get; set; }
        }
        public StringWriter sw = new StringWriter();
        public IList<wkDates> workDates = new List<wkDates>();

        string[,] workingDates;

        public string CandidateID
        {
            get;
            set;
        }
        public double firstCandidateID
        {
            get;
            set;
        }
        DataTable sqlDt = new DataTable();
        public bool bEmpFlag;
        // Candidate_Candidate cn;
        EnableIndia.Candidate.Candidate cn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }

            Global.SetDefaultButtonOfTheForm(this.Form, BtnAddWorkExperience);
            if (Request.QueryString["cand"] != null)
            {
                this.CandidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString();
            }
            else
            {
                this.CandidateID = "-2";
            }
            if (!Page.IsPostBack)
            {
                Page.Header.DataBind();
                GetCandidateDetail();
                Global.AuthenticateUser();

                if (Request.QueryString["cand"] != null)
                {
                    LnkBtnRegistration.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnEducationalQualifications.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnKnowledgeAndTraining.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnJobProfiling.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkButtonCandidateHistory.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    this.candId.Value = Request.QueryString["cand"].ToString();
                    GetCandidateWorkExperience();
                    //  BtnAddWorkExperience.Attributes.Add("onClick", "javascript:showAlertOnEmployed('" + SpnStatus.InnerText + "','" + firstCandidateID + "')");
                }
                if(!string.IsNullOrEmpty(Request.QueryString["message"]))
                {
                    this.lbEmpStatus.Text = Request.QueryString["message"];
                }
            }
            if (Page.IsPostBack)
            {
                if (ViewState["Cand"] != null)
                {
                    sqlDt = (DataTable)ViewState["Cand"];
                }
                if (ViewState["bEmpFlag"] != null)
                {
                    bEmpFlag = (bool)ViewState["bEmpFlag"];
                }
                //  this.Btnshow.Attributes.Add("OnClientClick", "javascript:ShowWorkExperiencePopUpDirectly('" + this.candId.Value + "', '" + this.wkExp.Value + "');return false;");
                // this.BtnHide.Attributes.Add("OnClientClick", "javascript:ShowWorkExperiencePopUp('" + this.candId.Value + "', " + "'');return false;");
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
                SpnDisabilityType.InnerText = drCandidateDetails["disability_type"].ToString();
                SpnRID.InnerText = drCandidateDetails["registration_id"].ToString();
                SpnStatus.InnerText = drCandidateDetails["employment_state"].ToString();
                string sContExpDate = drCandidateDetails["contract_expiry_date"].ToString();
                if (!string.IsNullOrEmpty(sContExpDate) &&  !System.DBNull.Value.Equals(sContExpDate))

                {
                    if (drCandidateDetails["contract_expiry_date"].ToString().Contains("1900"))
                    {
                        SpnContractExpiryDate.InnerText = "";
                    }
                    else
                    {
                        SpnContractExpiryDate.InnerText = Convert.ToDateTime(drCandidateDetails["contract_expiry_date"]).ToString("dd/MM/yyyy");
                    }
                }
                drCandidateDetails.Close();
                drCandidateDetails.Dispose();
            }
        }

        private void GetCandidateWorkExperience()
        {
            CandidateWorkExperienceBAL candidate = new CandidateWorkExperienceBAL();

            DataTable dt = candidate.GetCandidateWorkExperience(this.CandidateID);
            bool fwk = false;
            foreach (DataRow row in dt.Rows)
            {
                //if ((row["str_to_date"]).ToString().ToLower() == "current")
                //{
                    firstCandidateID = Global.EncryptID(Convert.ToInt32(Convert.ToInt32(row["candidate_work_experience_id"])));
                    if (!fwk)
                    {
                        this.wkExp.Value = firstCandidateID.ToString();
                        fwk = true;
                    }
               // }
            }
            sqlDt = candidate.GetCandidateWorkExperience(this.CandidateID);
            ViewState["Cand"] = sqlDt;
            LstViewExistingWorkExperience.DataSource = sqlDt; // candidate.GetCandidateWorkExperience(this.CandidateID);
            LstViewExistingWorkExperience.DataBind();
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }

        }

        protected void BtnAddWorkExperience_Click(object sender, EventArgs e)
        {
            GetCandidateDetail();
            GetCandidateWorkExperience();
            populateWorkingDates();
            if (this.SpnStatus.InnerText.Contains("Employed"))
            {
                this.UpdatePanel1.Visible = true;
                this.UpdatePanel2.Visible = true;
                this.ModalPopupExtender1.Show();
            }
            else
            {
                Session["workingDates"] = workingDates;
                string url = "~/candidate/WorkExperiencePopup.aspx?cand=" + Global.EncryptID(Convert.ToInt32(this.CandidateID)) + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri + "&workDates=" + sw.ToString() + "&rowId=-1";

                invokeRadWindow(url);
            }

        }
        private void populateWorkingDates()
        {
            int i = 0;
            string stDate = "";
            string edDate = "";
            if (this.LstViewExistingWorkExperience.Items.Count > 0)
            {
                workingDates = new string[this.LstViewExistingWorkExperience.Items.Count, 2];
                XmlDocument xDoc = new XmlDocument();

                sw = new StringWriter();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(sw);
                xmlTextWriter.WriteStartDocument();
                xmlTextWriter.WriteStartElement("WorkingDates");
                //(2) string.Empty makes cleaner code
                i = 0;
                foreach (System.Web.UI.WebControls.ListViewItem lv in this.LstViewExistingWorkExperience.Items)
                {
                    xmlTextWriter.WriteStartElement("WorkDate");
                    System.Web.UI.HtmlControls.HtmlTableCell tc1 = (System.Web.UI.HtmlControls.HtmlTableCell)lv.FindControl("stDate");
                    stDate = tc1.InnerText;
                    xmlTextWriter.WriteElementString("StartDate", stDate);
                    System.Web.UI.HtmlControls.HtmlTableCell tc2 = (System.Web.UI.HtmlControls.HtmlTableCell)lv.FindControl("edDate");
                    edDate = tc2.InnerText;
                    if (edDate == "Current")
                    {
                        workingDates[i, 1] = DateTime.Today.Month.ToString("00") + "/" + DateTime.Today.Year.ToString("0000");
                        xmlTextWriter.WriteElementString("EndDate", DateTime.Today.Month.ToString("00") + "/" + DateTime.Today.Year.ToString("0000"));
                        xmlTextWriter.WriteElementString("Current", "Current");
                    }
                    else
                    {
                        workingDates[i, 1] = edDate;
                        xmlTextWriter.WriteElementString("EndDate", edDate);
                        xmlTextWriter.WriteElementString("Current", "");
                    }
                    i++;
                    xmlTextWriter.WriteEndElement();
                }
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteEndDocument();
                HttpContext.Current.Session.Add("workDates", sw.ToString());
                        }
            else
            {
                XmlDocument xDoc = new XmlDocument();
                sw = new StringWriter();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(sw);
                xmlTextWriter.WriteStartDocument();
                xmlTextWriter.WriteStartElement("WorkingDates");
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteEndDocument();
                HttpContext.Current.Session.Add("workDates", sw.ToString());
                xDoc.LoadXml(sw.ToString());
            }
                       

        }
        protected void msgButtonClicked(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            if (e.CommandName == "Y")
                bEmpFlag = true;
            else
                bEmpFlag = false;
            ViewState["bEmpFlag"] = bEmpFlag;
        }
        protected void LnkBtnDesignation_Click(object sender, EventArgs e)
        {
            GetCandidateDetail();
            GetCandidateWorkExperience();
            populateWorkingDates();
            LinkButton lb = (LinkButton)sender;
            ListViewItem lv = (ListViewItem)lb.NamingContainer;
            string wkExpId = lb.Attributes["WorkExperienceID"];
            string lbId = (lv.DataItemIndex + 1).ToString();
            string url = "~/candidate/WorkExperiencePopup.aspx?cand=" + Global.EncryptID(Convert.ToInt32(this.CandidateID)) +
                         "&work_exp=" + wkExpId + "&workDates=" + sw.ToString();
            url += "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri + "&rowId=" + lbId;
            //             this.pnWk.Attributes["src"] = url;
            invokeRadWindow(url);
        }

        protected void btnYesClicked(object sender, EventArgs e)
        {
            populateWorkingDates();
            this.ModalPopupExtender1.Hide();
            ////this.UpdatePanel1.Visible = false;
            ////this.UpdatePanel2.Visible = false;
            //// wk1                    var url = "../WorkExperiencePopup.aspx?cand=" + cid.value + "&work_exp=" + wid.value + "&txboxId=" + self.parent.location;
            //LinkButton lb = (LinkButton)this.LstViewExistingWorkExperience.Items[0].FindControl("LnkBtnDesignation");
            //string workExpId = lb.Attributes["WorkExperienceID"];
            //string url = "../WorkExperiencePopup.aspx?cand=" + Global.EncryptID(Convert.ToInt32(this.CandidateID)) + "&work_exp=" + workExpId + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
            //// invokeRadWindow(url);
            //this.pnWk.Attributes["src"] = url;
        }
        protected void btnNoClicked(object sender, EventArgs e)
        {
            this.ModalPopupExtender1.Hide();
            //this.UpdatePanel1.Visible = false;
            //this.UpdatePanel2.Visible = false;
            //this.Panel1.Visible = false;
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
            // --------------------------------------
            // Transfer the dates.....
            // --------------------------------------
            

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