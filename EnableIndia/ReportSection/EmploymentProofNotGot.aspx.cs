using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.Sql;
using System.IO;
using Stimulsoft.Report;
using EnableIndia.App_Code.DAL;
using EnableIndia.App_Code.BAL;

namespace EnableIndia.ReportSection
{

    public partial class EmploymentProofNotGot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
        }
        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();
            CandidatesBAL cand = new CandidatesBAL();
            report.RegData("Emp_Proof_not_got", cand.GetEmploymentProofNotGotCandidates());
            report.Load(Server.MapPath("~/Reports/EmploymentProofNotGotFromCandidate.mrt"));
            StiWebViewer1.Report = report;
        }
        protected void btnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            CandidatesBAL cand = new CandidatesBAL();
            DataTable myDt = cand.GetEmploymentProofNotGotCandidates();
            if (myDt != null)
            {
                int i = 0;
                StringBuilder xlDocBody = new StringBuilder(); ;
                // -------------------------------------------------
                // Create dir for storing....
                // ------------------------------------------------
                string dirPath = System.Configuration.ConfigurationManager.AppSettings["ExcelReports"];
                dirPath += "\\EmploymentProofNotGot" + DateTime.Now.ToString("ddMMyyhhmm") + ".xls";
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
                    xlDocBody.Append("Employment Proof Not got from Candidate: " + DateTime.Now.ToString("dd/MM/yyyy"));
                    xlDocBody.Append("</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Number of entries: " + myDt.Rows.Count.ToString() + "</td>");
                    xlDocBody.Append("<tr><td width=\"25\"> </td></tr>");
                    xlDocBody.Append("<tr>");
                    // candidate_id, creation_date, candidate_name,registration_id,	disability_type,task_details,flag_name,employee_name,action_points,
                    // follow_up_date,closure_date,	lead_time_close_days,	str_closure_date,	str_follow_up_date,	str_lead_time_close_days	

                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Candidate Id" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Candidate Name" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Reg Id" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Disability Type" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "NGO" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Phone Numbers" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Current Company" + "</td>");
                    xlDocBody.Append("</tr>");
                    //
                    // Add Data Rows
                    int iRow = 0;
                    foreach (DataRow dRow in myDt.Rows)
                    {
                        xlDocBody.Append("<tr>");
                        iRow++;
                        for (i = 0; i < 7; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + iRow.ToString() + "</td>");
                                    xlDocBody.Append("<td valign=\"middle\" align=\"left\"> " + dRow[i].ToString() + "</td>");
                                    break;
                                case 2:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + dRow[i].ToString() + "</td>");
                                    break;
                                default:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"left\"> " + dRow[i].ToString() + "</td>");
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