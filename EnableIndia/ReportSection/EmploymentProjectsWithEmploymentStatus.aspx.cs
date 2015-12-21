using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Stimulsoft.Report;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.ReportSection
{
    public partial class EmploymentProjectsWithEmploymentStatus : System.Web.UI.Page
    {
        public int[] projectTypes = new int[] { 0, 0 };
        protected void Page_Load(object sender, EventArgs e)
        {
            EnableIndia.App_Code.BAL.JobRolesBAL HiddenRoles = new EnableIndia.App_Code.BAL.JobRolesBAL();
            MySqlDataReader drHiidenRoles = HiddenRoles.GetJobRoles("-1");
            while (drHiidenRoles.Read())
            {
                ListItem li = new ListItem(drHiidenRoles["job_role_name"].ToString(), drHiidenRoles["job_role_id"].ToString());
                li.Attributes.Add("JobID", drHiidenRoles["job_id"].ToString());
                DdlHiddenRole.Items.Add(li);
            }
            DdlHiddenRole.Items.Insert(0, new ListItem("All", "-1"));
            DdlHiddenRole.Items.Add(new ListItem("Not Available", "-3"));
            drHiidenRoles.Close();
            drHiidenRoles.Dispose();

            CitiesBAL city = new CitiesBAL();
            MySqlDataReader drCity = city.GetCities("-1");
            while (drCity.Read())
            {
                ListItem li = new ListItem(drCity["city_name"].ToString(), drCity["city_id"].ToString());
                li.Attributes.Add("StateID", drCity["state_id"].ToString());
                DdlHiddenCity.Items.Add(li);
            }
            DdlHiddenCity.Items.Insert(0, new ListItem("All", "-1"));
            DdlHiddenCity.Items.Add(new ListItem("Not Available", "-3"));
            drCity.Close();
            drCity.Dispose();

            Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
            Global.SetUICulture(this.Page);

            if (!Page.IsPostBack)
            {
                Global.SetUICulture(this.Page);

                EnableIndia.App_Code.BAL.EmploymentProjectBAL empProj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
                MySqlDataReader drEmpProj = empProj.GetEmploymentProjectNameDetail();
                Global.FillDropDown(DdlEmploymentProjects, drEmpProj, "employment_project_name", "employment_project_id");
                DdlEmploymentProjects.Items.RemoveAt(0);
                DdlEmploymentProjects.Items.Insert(0, new ListItem("All", "-1"));

                EnableIndia.App_Code.BAL.VacancyBAL vacancy = new EnableIndia.App_Code.BAL.VacancyBAL();
                MySqlDataReader drVacancy = vacancy.GetVacancyCodes();
                Global.FillDropDown(DdlVacancies, drVacancy, "vacancy_name", "vacancy_id");
                DdlVacancies.Items.RemoveAt(0);
                DdlVacancies.Items.Insert(0, new ListItem("All", "-1"));

                EnableIndia.App_Code.BAL.EmploymentProjectBAL blEmpProj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
                DataTable dtEmpProj = blEmpProj.GetEmploymentProjectConsideredCandidateGroups("-1");
                DdlGroups.DataSource = dtEmpProj;
                DdlGroups.DataTextField = "group_name";
                DdlGroups.DataValueField = "group_id";
                DdlGroups.DataBind();
                DdlGroups.Items.Insert(0, new ListItem("All", "-1"));
                DdlGroups.Items.Insert(1, new ListItem("None", "-2"));

                EnableIndia.App_Code.BAL.CompaniesBAL company = new EnableIndia.App_Code.BAL.CompaniesBAL();
                MySqlDataReader drCompany = company.GetCompanies("-1");
                Global.FillDropDown(DdlCompanies, drCompany, "company_code", "company_id");
                DdlCompanies.Items.RemoveAt(0);
                DdlCompanies.Items.Insert(0, new ListItem("All", "-1"));

                EnableIndia.App_Code.BAL.JobsBAL job = new EnableIndia.App_Code.BAL.JobsBAL();
                MySqlDataReader drJob = job.GetJobs();
                Global.FillDropDown(DdlJobType, drJob, "job_name", "job_id");
                if (DdlJobType.Items.Count > 0)
                {
                    DdlJobType.Items.RemoveAt(0);
                    DdlJobType.Items.Insert(0, new ListItem("All", "-1"));
                }

                EnableIndia.App_Code.BAL.StatesBAL state = new EnableIndia.App_Code.BAL.StatesBAL();
                MySqlDataReader drState = state.GetStates("-1");
                Global.FillDropDown(DdlStates, drState, "state_name", "state_id");
                if (DdlStates.Items.Count > 0)
                {
                    DdlStates.Items.RemoveAt(0);
                    DdlStates.Items.Insert(0, new ListItem("All", "-1"));
                }
            }
        }
        private DataTable getData()
        {
            EnableIndia.App_Code.BAL.EmploymentProjectBAL emplProj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            emplProj.ProjectStatus = DdlProjectTypes.Value;
            emplProj.EmploymentProjectID = Convert.ToInt32(DdlEmploymentProjects.Value);
            try
            {
                emplProj.EmploymentDateStartDateFrom = Convert.ToDateTime(TxtEmploymentStartFromDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                emplProj.EmploymentDateStartDateFrom = "1900/01/01";
            }
            try
            {
                emplProj.EmploymentDateStartDateTo = Convert.ToDateTime(TxtEmploymentStartToDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                emplProj.EmploymentDateStartDateTo = "5000/01/01";
            }
            try
            {
                emplProj.EmploymentDateEndDateFrom = Convert.ToDateTime(TxtEmploymentEndFromDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                emplProj.EmploymentDateEndDateFrom = "1900/01/01";
            }
            try
            {
                emplProj.EmploymentDateEndDateTo = Convert.ToDateTime(TxtEmploymentEndToDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                emplProj.EmploymentDateEndDateTo = "5000/01/01";
            }
            emplProj.VacancyID = string.IsNullOrEmpty(DdlVacancies.Value) ? -1 : Convert.ToInt32(DdlVacancies.Value);
            emplProj.JobID = string.IsNullOrEmpty(DdlJobType.Value) ? -1 : Convert.ToInt32(DdlJobType.Value);
            emplProj.JobRoleID = string.IsNullOrEmpty(DdlHiddenRole.Value) ? -1 : Convert.ToInt32(DdlHiddenRole.Value);
            emplProj.GroupID = string.IsNullOrEmpty(DdlGroups.Value) ? -1 : Convert.ToInt32(DdlGroups.Value);
            emplProj.CompanyID = string.IsNullOrEmpty(DdlCompanies.Value) ? -1 : Convert.ToInt32(DdlCompanies.Value);
            emplProj.StateID = string.IsNullOrEmpty(DdlStates.Value) ? -1 : Convert.ToInt32(DdlStates.Value);
            emplProj.CityID = string.IsNullOrEmpty(DdlHiddenCity.Value) ? -1 : Convert.ToInt32(DdlHiddenCity.Value);

            DataTable dtEmployProject = emplProj.GetEmploymentProjectsWithEmploymentStatus(emplProj, ref projectTypes);
            return (dtEmployProject);

        }
        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();
            DataTable dtEmployProject = getData();
            report.RegData("Emp_Prj_Emp_Status", dtEmployProject);
            if (dtEmployProject.Rows.Count.Equals(0))
            {
                report.Load(Server.MapPath("~/Reports/BlankReport.mrt"));
            }
            else
            {
                report.Load(Server.MapPath("~/Reports/EmploymentProjectEmploymentStatus.mrt"));
                //To count open projects
                report.Dictionary.Variables["open_count"].ValueObject = projectTypes[1];
                //To count closed projects
                report.Dictionary.Variables["closed_count"].ValueObject = projectTypes[0];
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
                dirPath += "\\EmploymentProjectWithEmploymentStatus" + DateTime.Now.ToString("ddMMyyhhmm") + ".xls";
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
                    xlDocBody.Append("Employment Project With Employment Status: " + DateTime.Now.ToString("dd/MM/yyyy"));
                    xlDocBody.Append("</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Number of entries: " + myDt.Rows.Count.ToString() + "</td>");
                    xlDocBody.Append("<tr><td width=\"25\"> </td></tr>");
                    xlDocBody.Append("<tr>");
                    //            No.		Employment Project	Company	Vacancy	Start Date		Actual End Date	Lead Time to Close Employment Project
                    // Current Demand	Number of candidates who went for interview		Number of Candidates who got job	
                    // Number of Rejected Candidates	Got job no details	Job Type		Role	Got Job VI	Got Job PD	Got Job CP	
                    // Got Job DB	Got Job HI	Got Job MR	Got Job MI	Got Job Others	Parent  Company	Company City	
                    // Project Managed by	Designation	Project Type	Industry segment	


                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Employment Project" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Company" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Vacancy" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Start Date" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Actual End Date" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Lead Time to Close Employment Project" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Current Demand" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Number of candidates who went for interview" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Number of candidates who got job" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Number of rejected candidates" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Got job No Details" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Job Type" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Role" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Got Job VI" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Got Job PD" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Got Job CP" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Got Job DB" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Got job HI" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Got Job MR" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Got Job MI" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Got Job Others" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Parent Company" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Company City" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Project Managed By" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Designation" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Industry Segment" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Project Type" + "</td>");
                    xlDocBody.Append("</tr>");
                    //
                    // Add Data Rows
                    int iRow = 0;
                    foreach (DataRow dRow in myDt.Rows)
                    {
                        xlDocBody.Append("<tr>");
                        iRow++;
                        for (i = 0; i < 28; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + iRow.ToString() + "</td>");
                                    break;
                                case 4:
                                case 5:
                                    string st = string.IsNullOrEmpty(dRow[i].ToString()) ? string.Empty : Convert.ToDateTime(dRow[i].ToString()).ToString("dd/MM/yyyy");
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + st + "</td>");
                                    break;
                                case 6:
                                case 7:
                                case 8:
                                case 9:
                                case 13:
                                case 14:
                                case 15:
                                case 16:
                                case 17:
                                case 18:
                                case 19:
                                case 20:
                                case 21:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + dRow[i].ToString() + "</td>");
                                    break;
                                case 10:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + dRow[i].ToString() + "</td>");
                                    int col1 = string.IsNullOrEmpty(dRow[9].ToString()) ? 0 : Convert.ToInt32(dRow[8].ToString());
                                    int col2 = string.IsNullOrEmpty(dRow[10].ToString()) ? 0 : Convert.ToInt32(dRow[9].ToString());
                                    col1 = col1 - col2;
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + col1.ToString() + "</td>");
                                    break;

                                case 1:
                                case 2:
                                case 3:
                                case 11:
                                case 12:
                                case 22:
                                case 23:
                                case 24:
                                case 25:
//                                case 26:
                                case 27:
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