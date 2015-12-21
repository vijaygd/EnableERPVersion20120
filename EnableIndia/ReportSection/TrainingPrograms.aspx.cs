using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;
using System.Data;
using System.Data.Sql;
using System.Text;
using System.IO;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.ReportSection
{

    public partial class TrainingPrograms : System.Web.UI.Page
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
        protected void btnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            TrainingProgramBAL get = new TrainingProgramBAL();
            DataTable myDt = get.GetTrainingProgramReports();
            if (myDt != null)
            {
                int i = 0;
                StringBuilder xlDocBody = new StringBuilder(); ;
                // -------------------------------------------------
                // Create dir for storing....
                // ------------------------------------------------
                string dirPath = System.Configuration.ConfigurationManager.AppSettings["ExcelReports"];
                dirPath += "\\TrainingPrograms" + DateTime.Now.ToString("ddMMyyhhmm") + ".xls";
                dirPath = dirPath.Replace("\\\\", "\\");   // To take care of  IDE Problem.....
                try
                {
                    // First create header....
                    xlDocBody.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
                    xlDocBody.Append("<head runat='server'>");
                    xlDocBody.Append("<title>Enable India</title>");
                    xlDocBody.Append("<table width=\"100%\" cellpadding=1 cellspacing=2 style=\"background-color:#ffffff;\">");
                    xlDocBody.Append("<tr><td>");
                    xlDocBody.Append("<table width=\"600\" cellpadding=\"0\" cellspacing=\"2\"><tr><td>");
                    xlDocBody.Append("<tr><td colspan='3' valign='middle' align='left' style=\"font-size:medium; font-weight:bold;\">");
                    xlDocBody.Append("Training Programs: " + DateTime.Now.ToString("dd/MM/yyyy"));
                    xlDocBody.Append("</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Number of entries: " + myDt.Rows.Count.ToString() + "</td>");
                    xlDocBody.Append("<tr><td width=\"25\"> </td></tr>");
                    xlDocBody.Append("<tr>");
 //Traning program	  Dissability types	Recommended Job Types	Eligible Groups	Eligible Educational Qualification	Recommended Roles	Required Languages	Pre-requisite/Training Candidate should have passed	Open Training Projects	Closed Training Projects	
										

                    
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Traning program" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Disability Type" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Recommended Job Types" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Eligible Groups" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Eligible Educational Qualification" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Recommended Roles" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Required Languages" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Pre-requisite/Training Candidate should have passed" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Open Training Projects" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Closed Training Projects" + "</td>");
                    
                    xlDocBody.Append("</tr>");
                    //
                    // Add Data Rows
                    int iRow = 0;
                    foreach (DataRow dRow in myDt.Rows)
                    {
                        xlDocBody.Append("<tr>");
                        iRow++;
                        for (i = 0; i < 11; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + iRow.ToString() + "</td>");
                                    xlDocBody.Append("<td valign=\"middle\" align=\"left\"> " + dRow[i].ToString() + "</td>");
                                    break;
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                case 7:
                                case 8:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"left\"> " + dRow[i].ToString() + "</td>");
                                    break;
                                case 9:
                                case 10:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + dRow[i].ToString() + "</td>");
                                    break;
                            }
                        }
                        xlDocBody.Append("</tr>");
                    }
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Buffer = true;
                    byte[] array = Encoding.ASCII.GetBytes(xlDocBody.ToString());
                    ////     File.WriteAllText(fileName, xlDocBody.ToString());
                    File.WriteAllBytes(dirPath, array);
                    HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
                    HttpContext.Current.Response.AppendHeader("Content-Type", "application/ms-excel");
                    HttpContext.Current.Response.AppendHeader("Content-disposition", "attachment; filename=\"" + Path.GetFileName(dirPath) + "\";");
                    //int li = dirPath.LastIndexOf("\\");
                    //dirPath = dirPath.Substring(0, li);  // Remove the last reverse slash due to transmit....
                    System.Web.HttpContext.Current.Response.Flush();
                    // HttpContext.Current.Response.WriteFile(fileName);
                    System.Web.HttpContext.Current.Response.TransmitFile(dirPath);
                    HttpContext.Current.Response.End();
                }
                catch
                {

                }
            }


        }
    }
}