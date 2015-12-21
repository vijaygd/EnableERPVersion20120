using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Stimulsoft.Report;
using System.IO;
using System.Text;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


namespace EnableIndia.ReportSection
{
    public partial class CandidateTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
            Global.SetUICulture(this.Page);

            if (!Page.IsPostBack)
            {
                EnableIndia.App_Code.BAL.DisabilityTypesBAL get = new EnableIndia.App_Code.BAL.DisabilityTypesBAL();
                MySqlDataReader drDisabilityTypes = get.GetDisabilityTypes();
                Global.FillDropDown(DdlDisabilityTypes, drDisabilityTypes, "disability_type", "disability_id");
                DdlDisabilityTypes.Items.RemoveAt(0);
                DdlDisabilityTypes.Items.Insert(0, new ListItem("All", "-1"));

                CandidateFlagsBAL flag = new CandidateFlagsBAL();
                MySqlDataReader drCandidateFlags = flag.GetCandidateFlags(true);
                Global.FillDropDown(DdlFlags, drCandidateFlags, "flag_name", "flag_id");
                DdlFlags.Items[0].Text = "All";
                DdlFlags.Items[0].Value = "-1";

                EnableIndia.App_Code.BAL.EmployeeBAL emp = new EnableIndia.App_Code.BAL.EmployeeBAL();
                MySqlDataReader drEmployee = emp.GetEmployeeListReader();
                Global.FillDropDown(DdlEmployee, drEmployee, "employee_name", "employee_id");
                DdlEmployee.Items[0].Text = "All";
                DdlEmployee.Items[0].Value = "-1";
            }
        }
        private DataTable GetData()
        {
            CandidatesBAL cand = new CandidatesBAL();
            cand.Status = DdlTaskType.Value;
            cand.DateType = DdlDateType.Value;
            cand.EmployeeID = Convert.ToInt32(DdlEmployee.Value);
            cand.CandidateFlagID = Convert.ToInt32(DdlFlags.Value);
            cand.SearchFor = TxtSearchFor.Text.Trim();
            cand.SearchIn = DdlSearchIn.Value;
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

            cand.DisabilityID = Convert.ToInt32(DdlDisabilityTypes.SelectedValue);
            DataTable DtCandidateTask = cand.GetCandidateTasks(cand);
            return (DtCandidateTask);
        }
        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {

            StiReport report = new StiReport();
            DataTable DtCandidateTask = GetData();
            report.RegData("DsCandidateTask", DtCandidateTask);
            if (DtCandidateTask.Rows.Count.Equals(0))
            {
                report.Load(Server.MapPath("~/Reports/BlankReport.mrt"));
            }
            else
            {
                report.Load(Server.MapPath("~/Reports/CandidateTasks.mrt"));
            }
            StiWebViewer1.Report = report;
        }
        protected void btnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            DataTable myDt = GetData();
            if (myDt != null)
            {
                int i = 0;
                StringBuilder xlDocBody = new StringBuilder(); ;
                // -------------------------------------------------
                // Create dir for storing....
                // ------------------------------------------------
                string dirPath = System.Configuration.ConfigurationManager.AppSettings["ExcelReports"];
                dirPath += "\\AllActiveRegisteredCandidates" + DateTime.Now.ToString("ddMMyyhhmm") + ".xls";
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
                    xlDocBody.Append("Candidate Task: " + DateTime.Now.ToString("dd/MM/yyyy"));
                    xlDocBody.Append("</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Number of entries: " + myDt.Rows.Count.ToString() + "</td>");
                    xlDocBody.Append("<tr><td width=\"25\"> </td></tr>");
                    xlDocBody.Append("<tr>");
                    // candidate_id, creation_date, candidate_name,registration_id,	disability_type,task_details,flag_name,employee_name,action_points,
                    // follow_up_date,closure_date,	lead_time_close_days,	str_closure_date,	str_follow_up_date,	str_lead_time_close_days	

                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Creation Date" + "</td>");

                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Candidate Name" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Reg-Id" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Disability" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Task Details" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Flag" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Managed By" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Action Points" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Folloup Date" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Closure" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Lead Time to Close(Days)" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Lead Time Close Days}" + "</td>");
                    xlDocBody.Append("</tr>");
                    //
                    // Add Data Rows
                    int iRow = 0;
                    foreach (DataRow dRow in myDt.Rows)
                    {
                        xlDocBody.Append("<tr>");
                        iRow++;
                        for (i = 0; i < 14; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + iRow.ToString() + "</td>");
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + dRow[i].ToString() + "</td>");
                                    break;
                                case 1:
                                case 9:
                                case 10:
                                    string st = string.IsNullOrEmpty(dRow[i].ToString()) ? string.Empty : Convert.ToDateTime(dRow[i].ToString()).ToString("dd/MM/yyyy");
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + st + "</td>");
                                    break;
                                case 11:
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