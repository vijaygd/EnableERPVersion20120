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
    public partial class CompanyReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);

            CitiesBAL hiddenCity = new CitiesBAL();
            MySqlDataReader drHiddenCity = hiddenCity.GetCities("-1");
            while (drHiddenCity.Read())
            {
                ListItem li = new ListItem(drHiddenCity["city_name"].ToString(), drHiddenCity["city_id"].ToString());
                li.Attributes.Add("StateID", drHiddenCity["state_id"].ToString());
                DdlHiddenCity.Items.Add(li);
            }
            DdlHiddenCity.Items.Insert(0, new ListItem("All", "-1"));
            DdlHiddenCity.Items.Add(new ListItem("Not Available", "-3"));
            drHiddenCity.Close();
            drHiddenCity.Dispose();

            //populate company code  in hidden company dropdown
            CompaniesBAL company = new CompaniesBAL();
            MySqlDataReader drCompany = company.GetCompanies("-1");
            while (drCompany.Read())
            {
                ListItem li = new ListItem(drCompany["company_code"].ToString(), drCompany["company_id"].ToString());
                li.Attributes.Add("ParentCompanyID", drCompany["parent_company_id"].ToString());
                DdlHiddenCompanies.Items.Add(li);
            }

            drCompany.Close();
            drCompany.Dispose();

            DdlHiddenCompanies.Items.Insert(0, new ListItem("Select", "-2"));
            DdlHiddenCompanies.Items.Add(new ListItem("Not Available", "-3"));

            if (!Page.IsPostBack)
            {
                ParentCompaniesBAL parentComp = new ParentCompaniesBAL();
                MySqlDataReader drParentCompanies = parentComp.GetParentCompanies();
                Global.FillDropDown(DdlParentCompany, drParentCompanies, "company_name", "company_id");
                DdlParentCompany.Items.RemoveAt(0);
                DdlParentCompany.Items.Insert(0, new ListItem("All", "-1"));

                CompaniesBAL get = new CompaniesBAL();
                //MySqlDataReader drCompany = get.GetCompanies("-1");
                //Global.FillDropDown(DdlCompany, drCompany, "company_code", "company_id");
                //DdlCompany.Items.RemoveAt(0);
                //DdlCompany.Items.Insert(0, new ListItem("All", "-1"));

                StatesBAL state = new StatesBAL();
                MySqlDataReader drState = state.GetStates("1");
                Global.FillDropDown(DdlState, drState, "state_name", "state_id");
                DdlState.Items.RemoveAt(0);
                DdlState.Items.Insert(0, new ListItem("All", "-1"));

                //CitiesBAL city = new CitiesBAL();
                //MySqlDataReader drCity = city.GetCities("-1");
                //Global.FillDropDown(DdlCity, drCity, "city_name", "city_id");
                //DdlCity.Items.RemoveAt(0);
                //DdlCity.Items.Insert(0, new ListItem("All", "-1"));

                MySqlDataReader drIndustry = get.GetIndustrySegments();
                Global.FillDropDown(DdlIndustrialSegment, drIndustry, "industry_segment", "industry_segment_id");
                DdlIndustrialSegment.Items.RemoveAt(0);
                DdlIndustrialSegment.Items.Insert(0, new ListItem("All", "-1"));
            }
        }
         private void messageBox(string msg)
        {
            webMessageBox wb = new webMessageBox();
            wb.Show(msg);
        }

// No.	Company	Parent Company	Phone/Landline of Office	Fax	Website	Address	State	City	Company Details	Industry Segment	

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
                dirPath += "\\Company Report" + DateTime.Now.ToString("ddMMyyhhmm") + ".xls";
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
                    xlDocBody.Append("Company Report: " + DateTime.Now.ToString("dd/MM/yyyy"));
                    xlDocBody.Append("</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Number of entries: " + myDt.Rows.Count.ToString() + "</td>");
                    xlDocBody.Append("<tr><td width=\"25\"> </td></tr>");
                      //       No.	Company	Parent Company	Phone/Landline of Office	Fax	Website	Address	State	City	Company Details	Industry Segment	
                    xlDocBody.Append("<tr>");

                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Company" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Parent Company" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Phone/Landline Office" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Fax" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Website" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Address" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "State" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "City" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Company Details" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Industry Segment" + "</td>");
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
                                    xlDocBody.Append("<td valign=\"middle\" align=\"left\"> " + dRow[i].ToString() + "</td>");
                                    break;
                                case 1:
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
        private DataTable getData()
        {
            CompaniesBAL company = new CompaniesBAL();
            company.ParentCompanyID = string.IsNullOrEmpty(DdlParentCompany.Value) ? -1 : Convert.ToInt32(DdlParentCompany.Value);
            company.CompanyID = string.IsNullOrEmpty(TxtHiddenCompanyID.Text) ? -1 : Convert.ToInt32(TxtHiddenCompanyID.Text.Trim());
            company.StateID = string.IsNullOrEmpty(DdlState.Value) ? -1 : Convert.ToInt32(DdlState.Value);
            company.CityID = string.IsNullOrEmpty(TxtHidddenCity.Text) ? -1 : Convert.ToInt32(TxtHidddenCity.Text.Trim());
            company.SegmentID = string.IsNullOrEmpty(DdlIndustrialSegment.Value) ? -1 : Convert.ToInt32(DdlIndustrialSegment.Value);
            DataTable dt = company.GetCompanyInReport(company);
            return (dt);

        }
        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();
            DataTable dt = getData();
            report.RegData("DsCompany", dt);

            if (dt.Rows.Count.Equals(0))
            {
                report.Load(Server.MapPath("~/Reports/BlankReport.mrt"));
            }
            else
            {
                report.Load(Server.MapPath("~/Reports/ListOfCompanies.mrt"));
            }
            StiWebViewer1.Report = report;
        }
    }
}