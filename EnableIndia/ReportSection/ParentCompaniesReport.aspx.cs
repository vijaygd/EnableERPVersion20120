using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.IO;
using Stimulsoft.Report;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.ReportSection
{
    public partial class ParentCompaniesReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetUICulture(this.Page);

            if (!Page.IsPostBack)
            {


            }
        }

        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();

            ParentCompaniesBAL get = new ParentCompaniesBAL();
            report.RegData("List_of_Parent_Co", get.GetParentCompaniesInReport());
            report.Load(Server.MapPath("~/Reports/ListOParentCompanies.mrt"));
            StiWebViewer1.Report = report;
        }
        private void messageBox(string msg)
        {
            webMessageBox wb = new webMessageBox();
            wb.Show(msg);
        }

//No.	Parent Company
        protected void btnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
           ParentCompaniesBAL get = new ParentCompaniesBAL();
           DataTable myDt = get.GetParentCompaniesInReport();
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
              dirPath += "\\ParentCompaniesReport" + DateTime.Now.ToString("ddMMyyhhmm") + ".xls";
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
                  xlDocBody.Append("Parent Companies Report: " + DateTime.Now.ToString("dd/MM/yyyy"));
                  xlDocBody.Append("</td>");
                  xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                  xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                  xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Number of entries: " + myDt.Rows.Count.ToString() + "</td>");
                  xlDocBody.Append("<tr><td width=\"25\"> </td></tr>");

                  xlDocBody.Append("</tr>");

                  xlDocBody.Append("<tr>");

                  xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No" + "</td>");
                  xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Name" + "</td>");
                  xlDocBody.Append("</tr>");
                  //
                  // Add Data Rows
                  int iRow = 0;
                  foreach (DataRow dRow in myDt.Rows)
                  {
                      xlDocBody.Append("<tr>");
                      iRow++;
                      for (i = 0; i < 1; i++)
                      {
                            xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + iRow.ToString() + "</td>");
                            xlDocBody.Append("<td valign=\"middle\" align=\"left\"> " + dRow[i].ToString() + "</td>");
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
              catch (System.Exception ex)
              {

              }
          }

        }
    }
}