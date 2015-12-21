using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;

public partial class ReportSection_TrainingPrograms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
    }

    protected void BtnGenerateReport_Click(object sender, EventArgs e)
    {
        StiReport report = new StiReport();
        TrainingProgramBAL get = new TrainingProgramBAL();
        report.RegData("DsTrainingPrograms", get.GetTrainingProgramReports());
        report.Load(Server.MapPath("~/Reports/TrainingPrograms.mrt"));
        StiWebViewer1.Report = report;
    }
}
