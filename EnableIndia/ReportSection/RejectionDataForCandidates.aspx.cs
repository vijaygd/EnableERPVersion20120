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
        public partial class RejectionDataForCandidates : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
                // populate hidden dropdown value 
                EnableIndia.App_Code.BAL.TrainingProjectBAL proj = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
                MySqlDataReader drHidenProject = proj.GetTrainProjForRejectionDataCandidates();
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
                if (IsPostBack == false)
                {
                    TrainingProgramBAL programm = new TrainingProgramBAL();
                    MySqlDataReader drProgramm = programm.GetTrainingProgramDetails("-1");
                    Global.FillDropDown(DdlPrograms, drProgramm, "training_program_name", "training_program_id");
                    DdlPrograms.Items.RemoveAt(0);
                    DdlPrograms.Items.Insert(0, new ListItem("All", "-1"));

                    EnableIndia.App_Code.BAL.EmploymentProjectBAL empProj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
                    MySqlDataReader drEmpProj = empProj.GetEmploymentProjectNameDetail();
                    Global.FillDropDown(DdlEmploymentProject, drEmpProj, "employment_project_name", "employment_project_id");
                    DdlEmploymentProject.Items.RemoveAt(0);
                    DdlEmploymentProject.Items.Insert(0, new ListItem("All", "-1"));
                }
            }
            private DataTable getData()
            {
                CandidatesBAL cand = new CandidatesBAL();
                cand.SearchFor = TxtSearchForCandidate.Text.Trim();
                cand.SearchIn = DdlSearch.Value;
                cand.TrainingProgramID = string.IsNullOrEmpty(DdlPrograms.Value) ? -1 : Convert.ToInt32(DdlPrograms.Value);
                cand.TrainingProjectID = string.IsNullOrEmpty(TxtHiddenProjects.Text) ? -1 : Convert.ToInt32(TxtHiddenProjects.Text.Trim());
                cand.EmploymentProjectID = string.IsNullOrEmpty(DdlEmploymentProject.Value) ? -1 : Convert.ToInt32(DdlEmploymentProject.Value);
                SpnHiddenProjects.InnerText = string.IsNullOrEmpty(TxtHiddenProjects.Text) ? "" : TxtHiddenProjects.Text.Trim();
                DataTable dtAssignedList = cand.GetRejectionDataFroCandidates(cand);
                return (dtAssignedList);

            }
            protected void BtnGenerateReport_Click(object sender, EventArgs e)
            {
                StiReport report = new StiReport();
                DataTable dtAssignedList = getData();
                report.RegData("DSCandidateRejectionData", dtAssignedList);
                if (dtAssignedList.Rows.Count.Equals(0))
                {
                    report.Load(Server.MapPath("~/Reports/Blank.mrt"));
                }
                else
                {
                    report.Load(Server.MapPath("~/Reports/rpt_rejection_data_for_candidates.mrt"));
                }

                StiWebViewer1.Report = report;
            }
            protected void btnExportToExcel_Click(object sender, ImageClickEventArgs e)
            {
                DataTable myDt = getData();
                if (myDt != null)
                {
                    int i = 0;
                    StringBuilder xlDocBody = new StringBuilder(); ;
                    // -------------------------------------------------
                    // Create dir for storing....
                    // ------------------------------------------------
                    string dirPath = System.Configuration.ConfigurationManager.AppSettings["ExcelReports"];
                    dirPath += "\\RejectionDataForCandidates" + DateTime.Now.ToString("ddMMyyhhmm") + ".xls";
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
                        xlDocBody.Append("Rejection Data for Candidates: " + DateTime.Now.ToString("dd/MM/yyyy"));
                        xlDocBody.Append("</td>");
                        xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                        xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                        xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Number of entries: " + myDt.Rows.Count.ToString() + "</td>");
                        xlDocBody.Append("<tr><td width=\"25\"> </td></tr>");
                        xlDocBody.Append("<tr>");
// No		Candidate Name	RID	Disability	Training Project that candidate not interested in	Evaluation not passed	Training Project that candidate was intersted in,but didnot start attending	
                        //Training Project that candidate start attending but didnot complete	Training Project that candidate failed	Employment Project where candidate not interested in job
                     //   Employment Project where candidate didnot get job/got rejected	Employment Project where candidate got job, but did not accept job


                        xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No" + "</td>");
                        xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Cand Id" + "</td>");
                        xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Candidate Name" + "</td>");
                        xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "RID" + "</td>");
                        xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Disability" + "</td>");

                        xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Training Project that candidate not interested in" + "</td>");
                        xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Training Project that candidate was intersted in,but didnot start attending" + "</td>");
                        xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Training Project that candidate start attending but didnot complete	Training" + "</td>");
                        xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Training Project that candidate failed" + "</td>");
                        xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Employment Project where candidate not interested in job" + "</td>");
                        xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Employment Project where candidate didnot get job/got rejected" + "</td>");
                        xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Employment Project where candidate got job, but did not accept job" + "</td>");
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
                                        xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + dRow[i].ToString() + "</td>");
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
        }
    }
