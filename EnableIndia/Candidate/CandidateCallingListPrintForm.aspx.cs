using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Candidate
{

    public partial class CandidateCallingListPrintForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["SelectedCandidates"] != null)
                {
                    StiReport report = new StiReport();

                    CandidateCallingBAL get = new CandidateCallingBAL();
                    report.RegData("CandidateDetail", get.GetCandidateCalling(Session["SelectedCandidates"].ToString()));

                    //report.Load(Server.MapPath("~/Reports/CandidateCalliningListReport.mrt"));
                    report.Load(Server.MapPath("~/Reports/candidateCalling.mrt"));
                    StiWebViewer1.Report = report;
                    Session["SelectedCandidates"] = null;
                }
            }
        }
    }
}