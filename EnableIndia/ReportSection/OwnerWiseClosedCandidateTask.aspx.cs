using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;
using EnableIndia.App_Code.DAL;
using EnableIndia.App_Code.BAL;

namespace EnableIndia.ReportSection
{
    public partial class OwnerWiseClosedCandidateTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
            Global.SetUICulture(this.Page);
        }

        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();
            CandidatesBAL cand = new CandidatesBAL();
            cand.DateType = DdlDateType.Value;
            try
            {
                cand.DateFrom = Convert.ToDateTime(TxtFromDate.Text.Trim()).ToString("yyyy/MM/dd");

            }
            catch
            {
                cand.DateFrom = "1900/01/01";
            }
            try
            {
                cand.DateTo = Convert.ToDateTime(TxtToDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                cand.DateTo = "5000/01/01";
            }

            report.RegData("DsOwnerWiseWorkDistribution", cand.GetOwnerwiseClosedCandidateTask(cand));

            report.Load(Server.MapPath("~/Reports/ClosedCandidatesOwnerwiseWorkDistribution.mrt"));
            report.Dictionary.Variables["var_date_from"].ValueObject = Convert.ToDateTime(cand.DateFrom).ToString(Global.GetDateFormat());
            report.Dictionary.Variables["var_date_to"].ValueObject = Convert.ToDateTime(cand.DateTo).ToString(Global.GetDateFormat());

            StiWebViewer1.Report = report;
        }
    }
}