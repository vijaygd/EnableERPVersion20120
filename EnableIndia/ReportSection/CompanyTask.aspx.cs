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
    public partial class CompanyTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
            Global.SetUICulture(this.Page);
            if (!Page.IsPostBack)
            {
                CompanyFlagsBAL flag = new CompanyFlagsBAL();
                MySqlDataReader drCompanyFlags = flag.GetCompanyFlags(true);
                Global.FillDropDown(DdlFlags, drCompanyFlags, "flag_name", "flag_id");
                DdlFlags.Items[0].Text = "All";
                DdlFlags.Items[0].Value = "-1";

                EnableIndia.App_Code.BAL.EmployeeBAL emp = new EnableIndia.App_Code.BAL.EmployeeBAL();
                MySqlDataReader drEmployee = emp.GetEmployeeListReader();
                Global.FillDropDown(DdlEmployee, drEmployee, "employee_name", "employee_id");
                DdlEmployee.Items[0].Text = "All";
                DdlEmployee.Items[0].Value = "-1";
            }
        }
        private DataTable getData()
        {
            CompaniesBAL company = new CompaniesBAL();
            company.Status = DdlTaskType.Value;
            company.EmployeeID = Convert.ToInt32(DdlEmployee.Value);
            company.CandidateFlagID = Convert.ToInt32(DdlFlags.Value);
            company.SearchFor = TxtSearchFor.Text.Trim();
            company.SearchIn = DdlSearchIn.Value;

            company.DateType = DdlDateType.Value;
            try
            {
                company.DateFrom = Convert.ToDateTime(TxtFromDate.Text.Trim()).ToString("yyyy/MM/dd");

            }
            catch
            {
                company.DateFrom = "1900/01/01";
            }
            try
            {
                company.DateTo = Convert.ToDateTime(TxtToDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                company.DateTo = "5000/01/01";
            }
            DataTable DtCompanyTask = company.GetCompanyTasks(company);
            return (DtCompanyTask);
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
                  dirPath += "\\CompanyTask" + DateTime.Now.ToString("ddMMyyhhmm") + ".xls";
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
                      xlDocBody.Append("Company Task: " + DateTime.Now.ToString("dd/MM/yyyy"));
                      xlDocBody.Append("</td>");
                      xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                      xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                      xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Number of entries: " + myDt.Rows.Count.ToString() + "</td>");
                      xlDocBody.Append("<tr><td width=\"25\"> </td></tr>");
                      xlDocBody.Append("<tr>");
                      // No.	Creation Date	Company	Parent Company	Task Details	Flag	Managed By	Action Points	Follow-up date	Closure	Lead time to Close (days)


                      xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No" + "</td>");
                      xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Creation Date" + "</td>");
                      xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Company" + "</td>");
                      xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Parent Company" + "</td>");

                      xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Task Details" + "</td>");
                      xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Flag" + "</td>");
                      xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Managed By" + "</td>");
                      xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Action Points" + "</td>");
                      xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Follow-up Date" + "</td>");
                      xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Closure Date" + "</td>");
                      xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Lead time to Close (Days)" + "</td>");
                      xlDocBody.Append("</tr>");
                      //
                      // Add Data Rows
                      int iRow = 0;
                      foreach (DataRow dRow in myDt.Rows)
                      {
                          xlDocBody.Append("<tr>");
                          iRow++;
                          for (i = 0; i < 8; i++)
                          {
                              switch (i)
                              {
                                  case 0:
                                      xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + iRow.ToString() + "</td>");
                                      string st = string.IsNullOrEmpty(dRow[i].ToString()) ? string.Empty : Convert.ToDateTime(dRow[i].ToString()).ToString("dd/MM/yyyy");
                                      xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + st + "</td>");
                                      break;
                                  case 7:
                                  case 8:
                                      string st1 = string.IsNullOrEmpty(dRow[i].ToString()) ? string.Empty : Convert.ToDateTime(dRow[i].ToString()).ToString("dd/MM/yyyy");
                                      xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + st1 + "</td>");
                                      break;

                                  case 9:
                                      xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + dRow[i].ToString() + "</td>");
                                      break;
                                  case 1:
                                  case 2:
                                  case 3:
                                  case 4:
                                  case 5:
                                  case 6:
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
            DataTable DtCompanyTask = getData();
            report.RegData("DsCompanyTasks", DtCompanyTask);
            if (DtCompanyTask.Rows.Count.Equals(0))
            {
                report.Load(Server.MapPath("~/Reports/BlankReport.mrt"));
            }
            else
            {
                report.Load(Server.MapPath("~/Reports/CompanyTasks.mrt"));
            }
            StiWebViewer1.Report = report;
        }
    }
}