using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.ReportSection
{
    public partial class FlagWiseOpenCandidateTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
        }

        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();

            CandidateFlagsBAL get = new CandidateFlagsBAL();
            report.RegData("DsFlagWiseWorkDistribution", get.GetFlagwiseOpenCandidateTask());

            report.Load(Server.MapPath("~/Reports/OpenCandidatesFlagwiseWorkDistribution.mrt"));
            StiWebViewer1.Report = report;
        }
    }
}