using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Candidate
{
    public partial class SocioEconomicIndicator : System.Web.UI.Page
    {
        public string candidateID
        {
            get;
            set;
        }
        public string SecId
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string textboxId = string.Empty;
                if (Request.QueryString["txboxId"] != null)
                    textboxId = Request.QueryString["txboxId"].ToString().Replace("'", string.Empty);
                this.txtParent.Value = textboxId;

                candidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString();
                ViewState["candidateID"] = candidateID;
                if (!string.IsNullOrEmpty(candidateID))
                {
                    GetCandidateDetail();
                }
                else
                {
                    ; ;
                }

                if (Request.QueryString["secId"] != null)
                    this.SecId = Global.DecryptID(Convert.ToDouble(Request.QueryString["secId"])).ToString();
                else
                    this.SecId = string.Empty;
                if(!string.IsNullOrEmpty(SecId))
                {
                    GetSecDetails();
                    ViewState["secId"] = SecId;
                    this.btnAddSocioEconomicstatus.Text = "Update";
                }

            }
            if(Page.IsPostBack)
            {
                if (ViewState["candidateID"] != null)
                    candidateID = ViewState["candidateID"].ToString();
                if (ViewState["secId"] != null)
                    SecId = ViewState["secId"].ToString();

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
        private void messageBox(string message)
        {
            webMessageBox wb = new webMessageBox();
            wb.Show(message);

        }
        protected void btnAddSocioEconomicstatusClicked(object sender, EventArgs e)
        {
            decimal dfi = 0;
            if(!string.IsNullOrEmpty(this.TxtFamiliyIncome.Text))
            {
                if(!decimal.TryParse(this.TxtFamiliyIncome.Text, out dfi))
                {
                    this.lbError.Text = "Wrong income";
                    messageBox("Wrong income");
                    return;
                }
            }
            int nom = 0;
            if(!string.IsNullOrEmpty(this.TxtNumberOfMembers.Text))
            {
                if(!int.TryParse(this.TxtNumberOfMembers.Text, out nom))
                {
                    this.lbError.Text = "Wrong Number of members";
                    messageBox("Wrong Number of members");
                    return;
                }
            }
            Old_App_Code.BAL.SocioEconomicIndicatorBAL seib = new Old_App_Code.BAL.SocioEconomicIndicatorBAL();
            seib.CandidateID = Convert.ToInt32(candidateID);
            seib.FamilyIncome = Convert.ToDecimal(this.TxtFamiliyIncome.Text);
            seib.NumberOfMembers = Convert.ToInt32(this.TxtNumberOfMembers.Text);
            seib.MainEarningMember = (this.cbMainEarningMember.Checked) ? 1 : 0;
            if (string.IsNullOrEmpty(SecId))
            {
                seib.AddCandidateSocioEconomicIndicator(seib);
                closePage("Socio Economic Indicator Record added successfully");
            }
            else
            {
                seib.SecID = Convert.ToInt32(this.SecId);
                int rows = seib.UpdateSocioEconomicIndicator(seib);
                if (rows == 1)
                    closePage("Socio Economic Indicator Updated");
                else
                    closePage("Socio Economic Indicator Update Unsuccessful");
            }
        }
        private void GetSecDetails()
        {
            Old_App_Code.BAL.SocioEconomicIndicatorBAL seib = new Old_App_Code.BAL.SocioEconomicIndicatorBAL();
            MySqlDataReader reader = seib.GetSocioEconomicIndicatorDetail(candidateID, SecId);
            if(reader.HasRows)
            {
                reader.Read();
                this.TxtFamiliyIncome.Text =  reader.GetDecimal(2).ToString();
                this.TxtNumberOfMembers.Text = reader.GetInt32(3).ToString();
                this.cbMainEarningMember.Checked = reader.GetBoolean(4) ? true : false;
                reader.Close();
                reader.Dispose();
            }
        }
        private void closePage(string message)
        {
            string url = "";
            if (string.IsNullOrEmpty(message))
            {
                url = "self.close();self.parent.location.replace('" + this.txtParent.Value + "')";
            }
            else
            {
                url = "window.alert('" + message + "');self.close();self.parent.location.replace('" + this.txtParent.Value + "');";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", url, true);
        }
        protected void btnCancelClicked(object sender, EventArgs e)
        {
            closePage("".ToString());
        }
    }
}