using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using Stimulsoft.Report;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace EnableIndia.ReportSection
{
    public partial class AssignedListClosedEmploymentProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            // populate hidden dropdown value 

            EnableIndia.App_Code.BAL.EmploymentProjectBAL HiddenEmpProj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            MySqlDataReader drHiddenEmpProj = HiddenEmpProj.GetEmploymentProjects();
            while (drHiddenEmpProj.Read())
            {
                ListItem li = new ListItem(drHiddenEmpProj["employment_project_name"].ToString(), drHiddenEmpProj["employment_project_id"].ToString());
                li.Attributes.Add("VacancyID", drHiddenEmpProj["vacancy_id"].ToString());
                DdlHiddenEmploymentProject.Items.Add(li);
            }
            DdlHiddenEmploymentProject.Items.Insert(0, new ListItem("All", "-1"));
            DdlHiddenEmploymentProject.Items.Add(new ListItem("Not Available", "-3"));
            drHiddenEmpProj.Close();
            drHiddenEmpProj.Dispose();

            Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
            Global.SetUICulture(this.Page);

            if (!Page.IsPostBack)
            {
                Global.SetUICulture(this.Page);

                EnableIndia.App_Code.BAL.VacancyBAL vacancy = new EnableIndia.App_Code.BAL.VacancyBAL();
                MySqlDataReader drVacancy = vacancy.GetVacancyCodes();
                Global.FillDropDown(DdlVacancy, drVacancy, "vacancy_name", "vacancy_id");
            }
        }
        private DataTable getData()
        {
            EnableIndia.App_Code.BAL.EmploymentProjectBAL empProj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();

            empProj.VacancyID = string.IsNullOrEmpty(DdlVacancy.Value) ? -1 : Convert.ToInt32(DdlVacancy.Value);
            empProj.EmploymentProjectID = string.IsNullOrEmpty(DdlHiddenEmploymentProject.Value) ? -1 : Convert.ToInt32(DdlHiddenEmploymentProject.Value);
            DataTable dt = empProj.GetAssignedListForClosedEmploymentProject(empProj);
            return dt;
        }

        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();
            DataTable dt = getData();
            report.RegData("assigned_list_for_closed_emp_pr", dt);
            if (dt.Rows.Count.Equals(0))
            {
                report.Load(Server.MapPath("~/Reports/Blank.mrt"));
            }
            else
            {
                report.Load(Server.MapPath("~/Reports/AssignedListForClosedEmploymentProject.mrt"));
            }
            StiWebViewer1.Report = report;
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
                if (myDt.Rows.Count == 0)
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
                    xlDocBody.Append("Assigned List for Closed Employment Projects: " + DateTime.Now.ToString("dd/MM/yyyy"));
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
//                No.	Name	R I D	Disability	Phone numbers	Candidate intrested in the job?	Educational Certificates Verified	Profile sent	Interview Scheduled	Candidate Confirmed for Interview	Candidate Prepared for Interview	Interview Support Required	
                    //Interview Process complete	Got Job	Candidate informed and accepted job	Offer letter received	Employment Proof received	Work Place Solution to be done?	

                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Name" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "RID" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Disability" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Phone Numbers" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Candidate Interested in the job" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Educational Certificates Verified" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Profile Sent" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Interview Scheduled Candidate" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Confirmed for Interview" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Candidate Perpared for Interview" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Interview Support Required" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Interview Process Complete" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Got job" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Candidate Informed and Accepted Job" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Offer Letter received" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Employment Proof received" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Work Place Solution to be done?" + "</td>");



                    xlDocBody.Append("</tr>");
                    //
                    // Add Data Rows
                    int iRow = 0;
                    foreach (DataRow dRow in myDt.Rows)
                    {
                        xlDocBody.Append("<tr>");
                        iRow++;
                        for (i = 0; i < 18; i++)
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
                   HttpContext.Current.Response.ClearHeaders();
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
        private void messageBox(string msg)
        {
            webMessageBox wb = new webMessageBox();
            wb.Show(msg);
        }
    }
}