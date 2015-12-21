using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;
using System.Data.Sql;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;
using Telerik;
using Telerik.Web.UI;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


namespace EnableIndia.ReportSection
{
    public partial class TrainingProjectReports : System.Web.UI.Page
    {
        int[] projectTypes = new int[] { 0, 0 };
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
            Global.SetUICulture(this.Page);
            if (!Page.IsPostBack)
            {
                TrainingProgramBAL programm = new TrainingProgramBAL();
                MySqlDataReader drProgramm = programm.GetTrainingProgramDetails("-1");
                Global.FillDropDown(DdlSelectProgram, drProgramm, "training_program_name", "training_program_id");
                DdlSelectProgram.Items[0].Text = "All";
                DdlSelectProgram.Items[0].Value = "-1";


                EnableIndia.App_Code.BAL.EmployeeBAL employee = new EnableIndia.App_Code.BAL.EmployeeBAL();
                MySqlDataReader drEmployees = employee.GetEmployeeListReader();
                Global.FillDropDown(DdlManagedByEmployee, drEmployees, "employee_name", "employee_id");
                if (DdlManagedByEmployee.Items.Count > 0)
                {
                    DdlManagedByEmployee.Items[0].Text = "All";
                    DdlManagedByEmployee.Items[0].Value = "-1";
                }
                EnableIndia.App_Code.BAL.CompaniesBAL comp = new App_Code.BAL.CompaniesBAL();
                DdlCompanies.DataSource = comp.GetCompanies("-1");
                DdlCompanies.DataTextField = "company_code";
                DdlCompanies.DataValueField = "company_id";
                DdlCompanies.DataBind();

                if (DdlCompanies.Items.Count > 0)
                {
                    DdlCompanies.Items.Insert(0, new RadComboBoxItem("Select", "-2"));

                }
                else
                {
                    DdlCompanies.Items.Add(new RadComboBoxItem("Not Available", "-2"));
                }


            }
        }

        private DataTable getData()
        {
            EnableIndia.App_Code.BAL.TrainingProjectBAL proj = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            proj.status = Convert.ToInt32(DdlProjectType.Value);
            proj.TrainingProgramID = Convert.ToInt32(DdlSelectProgram.Value);

            proj.DateType = DdlDateType.Value;
            try
            {
                proj.DateFrom = Convert.ToDateTime(TxtFromDate.Text.Trim()).ToString("yyyy/MM/dd");

            }
            catch
            {
                proj.DateFrom = "1900/01/01";
            }
            try
            {
                proj.DateTo = Convert.ToDateTime(TxtToDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                proj.DateTo = "5000/01/01";
            }
            proj.Credited_to = (DdlCompanies.SelectedIndex <= 0)?-1: Convert.ToInt32(this.DdlCompanies.SelectedValue);
            proj.EmployeeID = Convert.ToInt32(DdlManagedByEmployee.Value);
            DataTable dtTrainingProject = proj.GetTrainingProjectInReports(proj, ref projectTypes);
            return (dtTrainingProject);
        }


        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();
            DataTable dtTrainingProject = getData();
            report.RegData("DsTrainingProjects", dtTrainingProject);

            if (dtTrainingProject.Rows.Count.Equals(0))
            {
                report.Load(Server.MapPath("~/Reports/BlankReport.mrt"));
            }
            else
            {
                report.Load(Server.MapPath("~/Reports/TrainingProjectReport.mrt"));
                //To count open projects
                report.Dictionary.Variables["open_count"].ValueObject = projectTypes[1];
                //To count closed projects
                report.Dictionary.Variables["close_count"].ValueObject = projectTypes[0];
            }
            StiWebViewer1.Report = report;
        }
        protected void btnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            DataTable myDt = getData();
            // Set the employee names.....

            if (myDt != null)
            {
                int i = 0;
                if(this.DdlCompanies.SelectedIndex > 0)
                {
                    for(i = myDt.Rows.Count -1; i >= 0;i--)
                    {
                        if ((string.IsNullOrEmpty(myDt.Rows[i][8].ToString())) || (myDt.Rows[i][8] ==  DBNull.Value))
                        {
                            myDt.Rows[i].Delete();
                        }
                    }
                    myDt.AcceptChanges();
                }
                StringBuilder xlDocBody = new StringBuilder(); ;
                // -------------------------------------------------
                // Create dir for storing....
                // ------------------------------------------------
                string dirPath = System.Configuration.ConfigurationManager.AppSettings["ExcelReports"];
                dirPath += "\\TrainingProjects" + DateTime.Now.ToString("ddMMyyhhmm") + ".xls";
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
                    xlDocBody.Append("Training Projects: " + DateTime.Now.ToString("dd/MM/yyyy"));
                    xlDocBody.Append("</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Number of entries: " + myDt.Rows.Count.ToString() + "</td>");
                    xlDocBody.Append("<tr><td width=\"25\"> </td></tr>");
                    xlDocBody.Append("<tr>");
                    //Training Program	Training Project	Start Date		End Date	Timings	Batch Size		Project Managed By	Venue	Days	
                    // Project Category	Project Type		Comments	Number of Assigned Candidates	Number of Passed Candidates	Number of Failed Candidates
                    // Total candidates	
                    // Passed VI	Passed PD	Passed CP	Passed DB	Passed HI	Passed MI	Passed MR	Passed Others	Failed VI	Failed PD	Failed CP	
                    // Failed DB	Failed HI	Failed MI	Failed MR	Failed Other	

//                    training_program_name, training_project_name, start_date, end_date, start_time, end_time, batch_size, employee_name, venue, days, 
                    //comments, project_category, project_type, candidates_assigned, candidates_passed, candidates_failed, passed_vi, passed_hi, passed_pd, 
                    //passed_mi, passed_mr, passed_cp, passed_db, passed_others, failed_vi, failed_hi, failed_pd, failed_mi, failed_mr, failed_cp, failed_db, 
                    //failed_others, project_status, timings, 

                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Traning Program" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Traning Project" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Start Date" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "End Date" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Start Time" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "End Time" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Batch Size" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Project Managed By" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Credited To" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Venue" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Days" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Comments" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Project Category" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Project Type" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Number of assigned candidates" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Number of passed candidates" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Number of Candidates Failed" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Total Candidates" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Passed VI" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Passed PD" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Passed CP" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Passed DB" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Passed HI" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Passed MI" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Passed MR" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Passed Passed Others" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Failed VI" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Failed PD" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Failed CP" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Failed DB" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Failed HI" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Failed MI" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Failed MR" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Failed Others" + "</td>");
                    xlDocBody.Append("</tr>");
                    //
                    // Add Data Rows
                    int iRow = 0;
                    foreach (DataRow dRow in myDt.Rows)
                    {
                        xlDocBody.Append("<tr>");
                        iRow++;
                        for (i = 0; i < 33; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + iRow.ToString() + "</td>");
                                    xlDocBody.Append("<td valign=\"middle\" align=\"left\"> " + dRow[i].ToString() + "</td>");
                                    break;
                                case 2:
                                case 3:
                                    string st = string.IsNullOrEmpty(dRow[i].ToString()) ? string.Empty : Convert.ToDateTime(dRow[i].ToString()).ToString("dd/MM/yyyy");
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + st + "</td>");
                                    break;
                                case 6:
                                case 9:
                                case 13:
                                case 14:
                                case 16:
                                case 17:
                                case 18:
                                case 19:
                                case 20:
                                case 21:
                                case 22:
                                case 23:
                                case 24:
                                case 25:
                                case 26:
                                case 27:
                                case 28:
                                case 29:
                                case 30:
                                case 31:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + dRow[i].ToString() + "</td>");
                                    break;
                                case 1:
                                case 4:
                                case 5:
                                case 7:
                                case 8:
                                case 10:
                                case 11:
                                case 12:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"left\"> " + dRow[i].ToString() + "</td>");
                                    break;
                                case 15:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + dRow[i].ToString() + "</td>");
                                    int col1 = string.IsNullOrEmpty(dRow[14].ToString()) ? 0:  Convert.ToInt32(dRow[14].ToString());
                                    int col2 = string.IsNullOrEmpty(dRow[14].ToString()) ? 0 : Convert.ToInt32(dRow[15].ToString());
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + (col1 + col2).ToString() + "</td>");
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