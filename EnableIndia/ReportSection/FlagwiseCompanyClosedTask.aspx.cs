using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;

namespace EnableIndia.ReportSection
{

    public partial class FlagwiseCompanyClosedTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
            Global.SetUICulture(this.Page);
        }
        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();
            EnableIndia.App_Code.BAL.CompaniesBAL comp = new EnableIndia.App_Code.BAL.CompaniesBAL();
            comp.DateType = DdlDateType.Value;
            try
            {
                comp.DateFrom = Convert.ToDateTime(TxtFromDate.Text.Trim()).ToString("yyyy/MM/dd");

            }
            catch
            {
                comp.DateFrom = "1900/01/01";
            }
            try
            {
                comp.DateTo = Convert.ToDateTime(TxtToDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                comp.DateTo = "5000/01/01";
            }

            report.RegData("DsFlagwiseCompanyClosedTasks", comp.GetFlagWiseClosedCompanyTask(comp));

            report.Load(Server.MapPath("~/Reports/FlagwiseCompanyClosedTask.mrt"));
            //report.Dictionary.Variables["var_date_from"].ValueObject = Convert.ToDateTime(cand.DateFrom).ToString(Global.GetDateFormat());
            //report.Dictionary.Variables["var_date_to"].ValueObject = Convert.ToDateTime(cand.DateTo).ToString(Global.GetDateFormat());

            StiWebViewer1.Report = report;
        }
    }
}