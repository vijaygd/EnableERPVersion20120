
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.ReportSection
{

    public partial class AssignedListPageForClosedTrainingProjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
            // populate hidden dropdown value 
            EnableIndia.App_Code.BAL.TrainingProjectBAL proj = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            MySqlDataReader drHidenProject = proj.GetTrainingProjects();
            while (drHidenProject.Read())
            {
                ListItem li = new ListItem(drHidenProject["training_project_name"].ToString(), drHidenProject["training_project_id"].ToString());
                li.Attributes.Add("TrainingProgramID", drHidenProject["training_program_id"].ToString());
                DdlHiddenProjects.Items.Add(li);
            }
            DdlHiddenProjects.Items.Insert(0, new ListItem("Select", "-2"));
            DdlHiddenProjects.Items.Add(new ListItem("Not Available", "-3"));
            drHidenProject.Close();
            drHidenProject.Dispose();

            if (!Page.IsPostBack)
            {
                TrainingProgramBAL programm = new TrainingProgramBAL();
                MySqlDataReader drProgramm = programm.GetTrainingProgramDetails("-1");
                Global.FillDropDown(DdlPrograms, drProgramm, "training_program_name", "training_program_id");

                DdlPrograms.Items[0].Text = "Select";
                DdlPrograms.Items[0].Value = "-2";
            }
        }
        private DataTable getData()
        {
            EnableIndia.App_Code.BAL.TrainingProjectBAL proj = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            proj.TrainingProgramID = string.IsNullOrEmpty(DdlPrograms.Value) ? -1 : Convert.ToInt32(DdlPrograms.Value);
            proj.TrainingProjectID = string.IsNullOrEmpty(DdlHiddenProjects.Value) ? -1 : Convert.ToInt32(DdlHiddenProjects.Value);

            DataTable dtAssignedList = proj.GetAssigneListForClosedTrainingProject(proj);
            return (dtAssignedList);
        }
        private void messageBox(string msg)
        {
            webMessageBox wb = new webMessageBox();
            wb.Show(msg);
        }
        protected void btnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            DataTable myDt = getData();
            if (myDt == null)
            {
                messageBox("Nothing to display");
                return;

            }
            if (myDt != null)
            {
                if(myDt.Rows.Count == 0)
                {
                    messageBox("Nothing to display");
                    return;
                }
                int i = 0;
                StringBuilder xlDocBody = new StringBuilder(); ;
                // -------------------------------------------------
                // Create dir for storing....
                // ------------------------------------------------
                string dirPath = System.Configuration.ConfigurationManager.AppSettings["ExcelReports"];
                dirPath += "\\AssignedListForClosedTrainingProjects" + DateTime.Now.ToString("ddMMyyhhmm") + ".xls";
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
                    xlDocBody.Append("Assigned List for closing Training Projects: " + DateTime.Now.ToString("dd/MM/yyyy"));
                    xlDocBody.Append("</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Number of entries: " + myDt.Rows.Count.ToString() + "</td>");
                    xlDocBody.Append("<tr><td width=\"25\"> </td></tr>");
                    xlDocBody.Append("<tr><td colspan='6' valign='middle' align='left' style=\"font-size:medium; font-weight:bold;background-color:#EFE6FA;\">" + "</td>");
                    xlDocBody.Append("<td valign='middle' align='center' style=\"font-size:medium; font-weight:bold;background-color:#EFE6FA;\">" + "Start of the Project" + "</td>");
                    xlDocBody.Append("<td colspan='5' valign='middle' align='center' style=\"font-size:medium; font-weight:bold;background-color:#EFE6FA;\">" + "Completion of the Project" + "</td>");

                    xlDocBody.Append("</tr>");

                    xlDocBody.Append("<tr>");
                    //                  No.	Name	RID	Phone Numbers	Disability	1) Candidate confirmed to attend	2) Candidate passed evaluation	
                    // START OF PROJECT: 3) Candidate actually started attending training (first time attendence)	COMPLETION OF PROJECT:
                    //4) Candidate completed training	5) Final Status	6) Grade	7)Certificate given to Candidate	

                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Name" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "RID" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Phone Numbers" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Disability" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "1) Candidate Confirmed to attend" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "2) Candidate passed evaluation" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "3)Candidate actually started attending training (first time attendence)" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "4) Candidate completed training" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "5) Final Status" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "6) Grade" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "7) Certificate given to Candidate" + "</td>");
                    xlDocBody.Append("</tr>");
                    //
                    // Add Data Rows
                    int iRow = 0;
                    foreach (DataRow dRow in myDt.Rows)
                    {
                        xlDocBody.Append("<tr>");
                        iRow++;
                        for (i = 0; i < 12; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + iRow.ToString() + "</td>");
                                    break;
                                case 1:
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
                    //                    HttpContext.Current.Response.AppendHeader("Content-Type", "application/ms-excel");
                    HttpContext.Current.Response.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
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
        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();
            DataTable dtAssignedList = getData();
            if(dtAssignedList == null)
            {
                messageBox("Nothing to display");
                return;

            }
            if (dtAssignedList.Rows.Count == 0)
            {
                messageBox("Nothing to display");
                return;
            }
            report.RegData("DsAssignedListClosedTrainingProject", dtAssignedList);

            if (dtAssignedList.Rows.Count.Equals(0))
            {
                report.Load(Server.MapPath("~/Reports/Blank.mrt"));
            }
            else
            {
                report.Load(Server.MapPath("~/Reports/AssignedListClosedTrainingProject.mrt"));
            }
            //report.Dictionary.Variables["var_date_from"].ValueObject = Convert.ToDateTime(cand.DateFrom).ToString(Global.GetDateFormat());
            //report.Dictionary.Variables["var_date_to"].ValueObject = Convert.ToDateTime(cand.DateTo).ToString(Global.GetDateFormat());
            StiWebViewer1.Report = report;
        }
    }
}