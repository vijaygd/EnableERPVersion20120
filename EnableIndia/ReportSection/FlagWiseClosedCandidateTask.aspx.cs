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
    public partial class FlagWiseClosedCandidateTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetUICulture(this.Page);
            Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
        }

        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();

            CandidateFlagsBAL get = new CandidateFlagsBAL();
            get.DateType = DdlDateType.Value;
            try
            {
                get.DateFrom = Convert.ToDateTime(TxtFromDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                get.DateFrom = "1900/01/01";
            }
            try
            {
                get.DateTo = Convert.ToDateTime(TxtToDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                get.DateTo = "5000/01/01";
            }
            report.RegData("DsFlagWiseWorkDistribution", get.GetFlagwiseClosedCandidateTask(get));

            report.Load(Server.MapPath("~/Reports/ClosedCandidatesFlagwiseWorkDistribution.mrt"));

            report.Dictionary.Variables["var_date_from"].ValueObject = Convert.ToDateTime(get.DateFrom).ToString(Global.GetDateFormat());
            report.Dictionary.Variables["var_date_to"].ValueObject = Convert.ToDateTime(get.DateTo).ToString(Global.GetDateFormat());
            StiWebViewer1.Report = report;
        }
    }
}