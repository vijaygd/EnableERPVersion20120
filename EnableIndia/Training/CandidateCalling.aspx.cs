using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using MySql.Data.MySqlClient;
using Stimulsoft.Report;
using Stimulsoft.Report.Web;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


namespace EnableIndia.Training
{

    public partial class CandidateCalling : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StiReport report = new StiReport();

            CandidateCallingBAL get = new CandidateCallingBAL();
            report.RegData("CandidateDetail", get.GetCandidateCalling(Session["SelectedCandidates"].ToString()));

            //report.Load(Server.MapPath("~/Reports/CandidateCalliningListReport.mrt"));
            report.Load(Server.MapPath("~/Reports/candidateCalling.mrt"));
            //string fileName = DateTime.Now.Ticks.ToString();
            string fileName = "Training_" + Request.QueryString["train_proj"].ToString();
            string filePath = Server.MapPath("~/Docs/" + fileName + ".pdf");
            StiWebViewer1.Report = report;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            report.ExportDocument(StiExportFormat.Pdf, filePath);
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            //Response.Flush();
            //Response.WriteFile(filePath);


            System.Net.WebClient client = new System.Net.WebClient();
            Byte[] buffer = client.DownloadData(filePath);

            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }


            //Response.End();
            //StiWebViewer1.Report = report;
            File.Delete(filePath);

            Session["SelectedCandidates"] = null;

        }
    }
}