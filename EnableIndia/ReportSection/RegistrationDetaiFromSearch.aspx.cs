using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnableIndia.App_Code.DAL;
using EnableIndia.App_Code.BAL;

namespace EnableIndia.ReportSection
{
    public partial class RegistrationDetaiFromSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string RID = Request.QueryString["rid"].ToString();
            CandidatesBAL cand = new CandidatesBAL();
            int candiateID = cand.GetCandidateIDFromRID(RID);
            if (candiateID > 0)
            {
                Response.Redirect("~/Candidate/ProfileHistory/Registration.aspx?cand=" + Global.EncryptID(candiateID).ToString());
            }
            else
            {
                candiateID = 0;
                Response.Redirect("~/Candidate/ProfileHistory/Registration.aspx?cand=" + candiateID);
            }
        }
    }
}