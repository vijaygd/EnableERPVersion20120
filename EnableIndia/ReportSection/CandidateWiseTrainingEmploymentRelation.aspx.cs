using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Stimulsoft.Report;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.ReportSection
{

    public partial class CandidateWiseTrainingEmploymentRelation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // populate hidden dropdown value 
            EnableIndia.App_Code.BAL.JobRolesBAL HiddenRoles = new EnableIndia.App_Code.BAL.JobRolesBAL();
            MySqlDataReader drHiidenRoles = HiddenRoles.GetJobRoles("-1");
            while (drHiidenRoles.Read())
            {
                ListItem li = new ListItem(drHiidenRoles["job_role_name"].ToString(), drHiidenRoles["job_role_id"].ToString());
                li.Attributes.Add("JobID", drHiidenRoles["job_id"].ToString());
                DdlHiddenRecommendedRole.Items.Add(li);
            }
            DdlHiddenRecommendedRole.Items.Insert(0, new ListItem("All", "-1"));
            DdlHiddenRecommendedRole.Items.Add(new ListItem("Not Available", "-3"));
            drHiidenRoles.Close();
            drHiidenRoles.Dispose();

            EnableIndia.App_Code.BAL.TrainingProjectBAL proj = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            MySqlDataReader drHidenProject = proj.GetTrainingProjects();
            while (drHidenProject.Read())
            {
                ListItem li = new ListItem(drHidenProject["training_project_name"].ToString(), drHidenProject["training_project_id"].ToString());
                li.Attributes.Add("TrainingProgramID", drHidenProject["training_program_id"].ToString());
                DdlHiddenProjects.Items.Add(li);
            }
            //DdlHiddenProjects.Items.Insert(0, new ListItem("All", "-1"));
            //DdlHiddenProjects.Items.Add(new ListItem("None", "-2"));
            //DdlHiddenProjects.Items.Add(new ListItem("Any", "-3"));
            //DdlHiddenProjects.Items.Insert(0, new ListItem("Select", "-4"));
            DdlProjects.DataBind();


            DdlHiddenProjects.Items.Insert(0, new ListItem("Select", "-4"));
            DdlHiddenProjects.Items.Add(new ListItem("Not Available", "-5"));
            drHidenProject.Close();
            drHidenProject.Dispose();


            Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
            Global.SetUICulture(this.Page);

            if (!Page.IsPostBack)
            {
                Global.SetUICulture(this.Page);

                EnableIndia.App_Code.BAL.CandidateGroupsBAL   candidateGroup = new EnableIndia.App_Code.BAL.CandidateGroupsBAL();
                DataTable dtCandidateGroup = candidateGroup.GetCandidateGroup();
                DdlGroups.DataSource = dtCandidateGroup;
                DdlGroups.DataTextField = "group_name";
                DdlGroups.DataValueField = "group_id";
                DdlGroups.DataBind();
                DdlGroups.Items.Insert(0, new ListItem("All", "-1"));
                DdlGroups.Items.Insert(1, new ListItem("None", "-2"));

                EnableIndia.App_Code.BAL.DisabilityTypesBAL get = new EnableIndia.App_Code.BAL.DisabilityTypesBAL();
                MySqlDataReader drDisabilityTypes = get.GetDisabilityTypes();
                Global.FillDropDown(DdlDisabilityTypes, drDisabilityTypes, "disability_type", "disability_id");
                DdlDisabilityTypes.Items.RemoveAt(0);
                DdlDisabilityTypes.Items.Insert(0, new ListItem("All", "-1"));

                EnableIndia.App_Code.BAL.JobsBAL job = new EnableIndia.App_Code.BAL.JobsBAL();
                MySqlDataReader drJob = job.GetJobs();
                Global.FillDropDown(DdlRecommendedJobType, drJob, "job_name", "job_id");
                if (DdlRecommendedJobType.Items.Count > 0)
                {
                    DdlRecommendedJobType.Items.RemoveAt(0);
                    DdlRecommendedJobType.Items.Insert(0, new ListItem("All", "-1"));
                }

                EnableIndia.App_Code.BAL.EducationBAL education = new EnableIndia.App_Code.BAL.EducationBAL();
                MySqlDataReader drEducation = education.GetEducations();
                Global.FillDropDown(DdlQualifications, drEducation, "course_qualification_name", "course_qualification_id");
                DdlQualifications.Items.RemoveAt(0);
                DdlQualifications.Items.Insert(0, new ListItem("All", "-1"));

                //TrainingProjectBAL training = new TrainingProjectBAL();
                //MySqlDataReader drTraining = training.GetTrainingProjects();
                //Global.FillDropDown(DdlTrainingDone, drTraining, "training_project_name", "training_project_id");
                //DdlTrainingDone.Items.RemoveAt(0);
                //DdlTrainingDone.Items.Insert(0,new ListItem("All","-1"));
                //DdlTrainingDone.Items.Insert(1, new ListItem("None", "-2"));
                //DdlTrainingDone.Items.Insert(2, new ListItem("Any", "-3"));

                TrainingProgramBAL trainPrgm = new TrainingProgramBAL();
                DataTable dtTrainPrgm = trainPrgm.GetTraningProgram();
                DdlRecommendedTraining.DataSource = dtTrainPrgm;
                DdlRecommendedTraining.DataTextField = "training_program_name";
                DdlRecommendedTraining.DataValueField = "training_program_id";
                DdlRecommendedTraining.DataBind();
                DdlRecommendedTraining.Items.Insert(0, new ListItem("All", "-1"));
                DdlRecommendedTraining.Items.Insert(1, new ListItem("None", "-2"));

                TrainingProgramBAL blTrainPrgm = new TrainingProgramBAL();
                DataTable dttrainPrgm = trainPrgm.GetTraningProgram();
                DdlRecommendedTrainingNotDone.DataSource = dtTrainPrgm;
                DdlRecommendedTrainingNotDone.DataTextField = "training_program_name";
                DdlRecommendedTrainingNotDone.DataValueField = "training_program_id";
                DdlRecommendedTrainingNotDone.DataBind();
                DdlRecommendedTrainingNotDone.Items.Insert(0, new ListItem("All", "-1"));
                DdlRecommendedTrainingNotDone.Items.Insert(1, new ListItem("None", "-2"));

                TrainingProgramBAL programm = new TrainingProgramBAL();
                MySqlDataReader drProgramm = programm.GetTrainingProgramDetails("-1");
                Global.FillDropDown(DdlPrograms, drProgramm, "training_program_name", "training_program_id");

                DdlPrograms.Items.RemoveAt(0);
                DdlPrograms.Items.Insert(0, new ListItem("All", "-1"));


                //TrainingProjectBAL project = new TrainingProjectBAL();
                //MySqlDataReader drproject = project.GetTrainingProjects();
                //Global.FillDropDown(DdlProjects, drproject, "training_project_name", "training_project_id");
                //if (DdlProjects.Items.Count > 0)
                //{
                //DdlProjects.DataBind();
                DdlProjects.Items.Insert(0, new ListItem("All", "-1"));
                DdlProjects.Items.Insert(1, new ListItem("None", "-2"));
                DdlProjects.Items.Insert(2, new ListItem("Any", "-3"));
                //}
            }
            if (Page.IsPostBack)
            {
                //TrainingProgramBAL programm = new TrainingProgramBAL();
                //MySqlDataReader drProgramm = programm.GetTrainingProgramDetails("-1");
                //Global.FillDropDown(DdlPrograms, drProgramm, "training_program_name", "training_program_id");

                DdlPrograms.Items.RemoveAt(0);
                DdlPrograms.Items.Insert(0, new ListItem("All", "-1"));
                //DdlProjects.Items.Insert(0, new ListItem("All", "-1"));
                //DdlProjects.Items.Insert(1, new ListItem("None", "-2"));
                //DdlProjects.Items.Insert(2, new ListItem("Any", "-3"));
            }
        }

        private DataTable loadReport()
        {
            EnableIndia.App_Code.BAL.SearchCandidatesBAL search = new EnableIndia.App_Code.BAL.SearchCandidatesBAL();
            search.IsProfiled = DdlProfilingStatus.Value;
            search.EmploymentStatus = Convert.ToInt32(DdlTypeOfCandidate.Value);
            // search.TrainingProjectID = Convert.ToInt32(DdlTrainingDone.Value);
            search.DateType = DdlDateType.Value;
            try
            {
                search.TrainingDateFrom = Convert.ToDateTime(TxtTrainingFromDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                search.TrainingDateFrom = "1900/01/01";
            }
            try
            {
                search.TrainingDateTo = Convert.ToDateTime(TxtTrainingToDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                search.TrainingDateTo = "5000/01/01";
            }
            try
            {
                search.EmploymentDateFrom = Convert.ToDateTime(TxtEmploymentFromDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                search.EmploymentDateFrom = "1900/01/01";
            }
            try
            {
                search.EmploymentDateTo = Convert.ToDateTime(TxtEmploymentToDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                search.EmploymentDateTo = "5000/01/01";
            }
            search.JobTypeId = string.IsNullOrEmpty(DdlRecommendedJobType.Value)?-1:Convert.ToInt32(DdlRecommendedJobType.Value);
            search.JobRoleID = string.IsNullOrEmpty(TxtHiddenRecommendedRole.Text)?-1:Convert.ToInt32(TxtHiddenRecommendedRole.Text.Trim());
            SpnHiddenRecommendedRole.InnerText = TxtHiddenRecommendedRole.Text.Trim();
            search.DisabilityID = string.IsNullOrEmpty(DdlDisabilityTypes.Value)?-1: Convert.ToInt32(DdlDisabilityTypes.Value);
            search.GroupID = string.IsNullOrEmpty(DdlGroups.Value)?-1:Convert.ToInt32(DdlGroups.Value);
            search.QualificationID = string.IsNullOrEmpty(DdlQualifications.Value)?-1: Convert.ToInt32(DdlQualifications.Value);
            search.TrainingProgramID = string.IsNullOrEmpty(DdlRecommendedTraining.Value)?-1: Convert.ToInt32(DdlRecommendedTraining.Value);
            search.SearchFor = string.IsNullOrEmpty(TxtSearchFor.Text)?"": TxtSearchFor.Text.Trim();
            search.SearchIn = DdlSearchIn.Value;
            search.AssignedTrainingProgramID = string.IsNullOrEmpty(DdlPrograms.Value)?-1: Convert.ToInt32(DdlPrograms.Value);
            search.TrainingProjectID = string.IsNullOrEmpty(TxtHiddenProjects.Text)?-1: Convert.ToInt32(TxtHiddenProjects.Text.Trim());
            SpnHiddenProjects.InnerText = string.IsNullOrEmpty(TxtHiddenProjects.Text)?"": TxtHiddenProjects.Text.Trim();
            search.NotDoneTrainingProgramID = string.IsNullOrEmpty(DdlRecommendedTrainingNotDone.Value)?-1: Convert.ToInt32(DdlRecommendedTrainingNotDone.Value);
            DataTable dt = new DataTable();
            dt = search.GetCandidateWiseTrainingEmploymentRelation(search);
            return dt;
        }

        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();
            DataTable dt = new DataTable();
            dt = loadReport();
            report.RegData("CandiTraining_Employment", dt);

            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    report.Load(Server.MapPath("~/Reports/BlankReport.mrt"));
                    StiWebViewer1.Report = report;
                    //report.Compile();
                    //report.Render();
                    //report.Show(true);
                }
                else
                {
                    report.Load(Server.MapPath("~/Reports/CandiTrainingEmployment.mrt"));
                    StiWebViewer1.Report = report;
                //    report.Compile();
                //    report.Render();
                //    report.Show(true);
                }
            }
            else
            {
               
                report.Load(Server.MapPath("~/Reports/BlankReport.mrt"));
                StiWebViewer1.RenderMode = Stimulsoft.Report.Web.StiRenderMode.UseCache;
                StiWebViewer1.Report = report;
             //   report.Compile();
              //  report.Render();
             //   report.Show(true);

            }
        }
        protected void btnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            DataTable myDt = loadReport();
            if (myDt != null)
            {
                int i = 0;
                StringBuilder xlDocBody = new StringBuilder(); ;
                // -------------------------------------------------
                // Create dir for storing....
                // ------------------------------------------------
                string dirPath = System.Configuration.ConfigurationManager.AppSettings["ExcelReports"];
                dirPath += "\\CandidateWiseTrainingEmploymentRelation" + DateTime.Now.ToString("ddMMyyhhmm") + ".xls";
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
                    xlDocBody.Append("Candidate Wise Training And Employment Relation: " + DateTime.Now.ToString("dd/MM/yyyy"));
                    xlDocBody.Append("</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Number of entries: " + myDt.Rows.Count.ToString() + "</td>");
                    xlDocBody.Append("<tr><td width=\"25\"> </td></tr>");
                    xlDocBody.Append("<tr>");
                    //registration_id, candidate_id, candidate_name, disability_type, i1, phone_numbers, recommended_job_type, current_company, employment_start_date, training_projects_done,
                    //start_date_of_training, end_date_of_training, recommended_training_programs, training_project_id, recommended_training_programs_not_done_id, recommended_training_programs_not_done, 
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Reg-Id" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Name of Candidate" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Disability Type" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Phone Numbers" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "I1" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Recommended Job Type" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Current Company" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Start Date of Employment for Candidate in Current Company" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Training Passed" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Start Date of Training" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "End Date of Training" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Recommended Training" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Recommended Training Not Passed" + "</td>");
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
                                case 8:
                                case 10:
                                case 11:
                                    string st = string.IsNullOrEmpty(dRow[i].ToString()) ? string.Empty : Convert.ToDateTime(dRow[i].ToString()).ToString("dd/MM/yyyy");
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + st + "</td>");
                                    break;
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                case 7:
                                case 9:
                                case 12:
                                case 13:
                                case 14:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"left\"> " + dRow[i].ToString() + "</td>");
                                    break;
                                case 0:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + iRow.ToString() + "</td>");
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