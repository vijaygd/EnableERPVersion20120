﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using Stimulsoft.Report;
using Telerik;
using Telerik.Web;
using Telerik.Web.UI;
using System.IO;
using System.Text;

using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.MobileDevices.mdReportsSection
{
    public partial class mdRptRegisteredCandidates : System.Web.UI.Page
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

            EnableIndia.App_Code.BAL.DisabilitySubTypesBAL subType = new EnableIndia.App_Code.BAL.DisabilitySubTypesBAL();
            MySqlDataReader drSubType = subType.GetDisabilitySubTypes("-1");
            while (drSubType.Read())
            {
                ListItem li = new ListItem(drSubType["disability_sub_type"].ToString(), drSubType["disability_sub_type_id"].ToString());
                li.Attributes.Add("DisabilityTypeID", drSubType["disability_id"].ToString());
                DdlHiddenDisabilitySubType.Items.Add(li);
            }
            DdlHiddenDisabilitySubType.Items.Insert(0, new ListItem("All", "-1"));
            DdlHiddenDisabilitySubType.Items.Add(new ListItem("Not Available", "-3"));
            drSubType.Close();
            drSubType.Dispose();
            EnableIndia.App_Code.BAL.CitiesBAL hiddenCity = new EnableIndia.App_Code.BAL.CitiesBAL();
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

            Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
            Global.SetUICulture(this.Page);
            if (!Page.IsPostBack)
            {
                Label lbh = this.Form.Parent.FindControl("lbHeader") as Label;
                if(lbh != null)
                {
                    lbh.Text = "Registered Candidate Report";
                }
                Global.SetUICulture(this.Page);

                EnableIndia.App_Code.BAL.EducationBAL education = new EnableIndia.App_Code.BAL.EducationBAL();
                MySqlDataReader drEducation = education.GetEducations();
                Global.FillDropDown(DdlQualification, drEducation, "course_qualification_name", "course_qualification_id");
                DdlQualification.Items.RemoveAt(0);
                DdlQualification.Items.Insert(0, new ListItem("All", "-1"));
                DdlQualification.Items.Insert(1, new ListItem("None", "-2"));

                EnableIndia.App_Code.BAL.CompaniesBAL comp = new EnableIndia.App_Code.BAL.CompaniesBAL();
                MySqlDataReader drCompany = comp.GetCompanies("-1");
                Global.FillDropDown(DdlCompanies, drCompany, "company_code", "company_id");
                DdlCompanies.Items.RemoveAt(0);
                DdlCompanies.Items.Insert(0, new ListItem("All", "-1"));
                DdlCompanies.Items.Insert(1, new ListItem("Unlisted", "-2"));

                EnableIndia.App_Code.BAL.LanguagesBAL language = new EnableIndia.App_Code.BAL.LanguagesBAL();
                MySqlDataReader drLanguages = language.GetLanguagesInReader();
                Global.FillDropDown(DdlLanguage, drLanguages, "language_name", "language_id");
                DdlLanguage.Items.RemoveAt(0);
                DdlLanguage.Items.Insert(0, new ListItem("All", "-1"));
                DdlLanguage.Items.Insert(1, new ListItem("None", "-2"));

                EnableIndia.App_Code.BAL.CandidateGroupsBAL candidateGroup = new EnableIndia.App_Code.BAL.CandidateGroupsBAL();
                DataTable dtCandidateGroup = candidateGroup.GetCandidateGroup();
                DdlGroups.DataSource = dtCandidateGroup;
                DdlGroups.DataTextField = "group_name";
                DdlGroups.DataValueField = "group_id";
                DdlGroups.DataBind();
                DdlGroups.Items.Insert(0, new ListItem("All", "-1"));
                DdlGroups.Items.Insert(1, new ListItem("None", "-2"));

                EnableIndia.App_Code.BAL.StatesBAL state = new EnableIndia.App_Code.BAL.StatesBAL();
                MySqlDataReader drState = state.GetStates("1");
                Global.FillDropDown(DdlState, drState, "state_name", "state_id");
                DdlState.Items.RemoveAt(0);
                DdlState.Items.Insert(0, new ListItem("All", "-1"));

                EnableIndia.App_Code.BAL.DisabilityTypesBAL get = new EnableIndia.App_Code.BAL.DisabilityTypesBAL();
                MySqlDataReader drDisabilityTypes = get.GetDisabilityTypes();
                Global.FillDropDown(DdlDisabilityTypes, drDisabilityTypes, "disability_type", "disability_id");
                if (DdlDisabilityTypes.Items.Count > 0)
                {
                    DdlDisabilityTypes.Items.RemoveAt(0);
                    DdlDisabilityTypes.Items.Insert(0, new ListItem("All", "-1"));
                }

                //Populates age groups
                Global glob = new Global();
                glob.GetAgeGroups(DdlAgeGroups);
                EnableIndia.App_Code.BAL.DefaultsBAL def = new EnableIndia.App_Code.BAL.DefaultsBAL();
                DdlAgeGroups.Value = def.GetDefaultAgeGroupForSearch();

                EnableIndia.App_Code.BAL.NGOsBAL ngo = new EnableIndia.App_Code.BAL.NGOsBAL();
                MySqlDataReader drNgos = ngo.GetNGOs(true);
                Global.FillDropDown(DdlNGOs, drNgos, "ngo_name", "ngo_id");
                if (DdlNGOs.Items.Count > 0)
                {
                    DdlNGOs.Items.RemoveAt(0);
                    DdlNGOs.Items.Insert(0, new ListItem("All", "-1"));
                }
                DdlNGOs.Items.Add(new ListItem("Others", "-2"));

                EnableIndia.App_Code.BAL.JobsBAL job = new EnableIndia.App_Code.BAL.JobsBAL();
                MySqlDataReader drJob = job.GetJobs();
                Global.FillDropDown(DdlRecommendedJobType, drJob, "job_name", "job_id");
                if (DdlRecommendedJobType.Items.Count > 0)
                {
                    DdlRecommendedJobType.Items.RemoveAt(0);
                    DdlRecommendedJobType.Items.Insert(0, new ListItem("All", "-1"));
                }
                this.DdlContExpDate.SelectedIndex = 0;
            }

        }
        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            Session.Remove("cand");
            CandidatesBAL cand = loadReport();
            Session["cand"] = cand;
            dispRadWindow("nAllActiveRegisteredCandidate");

        }
        protected void BtnGenerateGrid_Click(object sender, EventArgs e)
        {
            Session.Remove("cand");
            CandidatesBAL cand = loadReport();
            Session["cand"] = cand;
            dispRadWindowUrl("mdRegisteredCandidateGrid.aspx");
        }
        private CandidatesBAL loadReport()
        {
            CandidatesBAL cand = new CandidatesBAL();
            int candidateID = cand.GetCandidateID(TxtSearchFor.Text.Trim());
            try
            {
                cand.CandidateID = candidateID;
            }
            catch
            {
                cand.CandidateID = -1;
            }
            cand.ContractExpiryDate = this.DdlContExpDate.SelectedValue;   // Newly added......
            cand.IsProfiled = DdlProfilingStatus.Value;
            cand.EmploymentStatus = Convert.ToInt32(DdlTypeOfCandidate.Value);
            cand.Assignment = DdlAssignment.Value;
            cand.StateID = Convert.ToInt32(DdlState.Value);
            // ------------- Modified on 01-03-2012-------------
            if (string.IsNullOrEmpty(TxtHidddenCity.Text))
                cand.CityID = -1;
            else
                cand.CityID = string.IsNullOrEmpty(TxtHidddenCity.Text) ? -1 : ((TxtHidddenCity.Text == "-1") ? -1 : Convert.ToInt32(TxtHidddenCity.Text.Trim()));
            //  cand.CityID = Convert.ToInt32(TxtHidddenCity.Text.Trim());
            cand.AgeGroup = (string.IsNullOrEmpty(DdlAgeGroups.Value) ? -1 : (DdlAgeGroups.Value == "-1") ? -1 : Convert.ToInt32(DdlAgeGroups.Value));
            // cand.AgeGroup = Convert.ToInt32(DdlAgeGroups.Value);
            cand.NgoID = string.IsNullOrEmpty(DdlNGOs.Value) ? -1 : Convert.ToInt32(DdlNGOs.Value);
            cand.SearchFor = string.IsNullOrEmpty(TxtSearchFor.Text) ? "" : TxtSearchFor.Text.Trim();
            cand.SearchIn = DdlSearchIn.Value;
            cand.DisabilityID = string.IsNullOrEmpty(DdlDisabilityTypes.Value) ? -1 : Convert.ToInt32(DdlDisabilityTypes.Value);
            cand.DisabilitySubTypeID = string.IsNullOrEmpty(DdlHiddenDisabilitySubType.Value) ? -1 : Convert.ToInt32(DdlHiddenDisabilitySubType.Value);
            cand.RecommendedJobID = string.IsNullOrEmpty(DdlRecommendedJobType.Value) ? -1 : Convert.ToInt32(DdlRecommendedJobType.Value);
            cand.RecommendedJobRoleID = string.IsNullOrEmpty(TxtHiddenRecommendedRole.Text) ? -1 : Convert.ToInt32(TxtHiddenRecommendedRole.Text.Trim());
            SpnHiddenRecommendedRole.InnerText = TxtHiddenRecommendedRole.Text.Trim();
            SpnHiddenDisabilityType.InnerText = TxtHiddenDisabilitySubType.Text.Trim();
            cand.MissingDataProfile = DdlMissingData.Value;

            cand.GroupID = string.IsNullOrEmpty(DdlGroups.Value) ? -1 : Convert.ToInt32(DdlGroups.Value);
            cand.LanguageID = string.IsNullOrEmpty(DdlLanguage.Value) ? -1 : Convert.ToInt32(DdlLanguage.Value);
            cand.Gender = DdlGender.Value;
            cand.CompanyID = string.IsNullOrEmpty(DdlCompanies.Value) ? -1 : Convert.ToInt32(DdlCompanies.Value);
            cand.QualificationID = Convert.ToInt32(DdlQualification.Value);
            try
            {
                cand.RegistrationFrom = Convert.ToDateTime(TxtRegistrationFrom.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                cand.RegistrationFrom = "1900/01/01";
            }
            try
            {
                cand.RegistrationTo = Convert.ToDateTime(TxtRegistrationTo.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                cand.RegistrationTo = "5000/01/01";
            }
            try
            {
                cand.DateOfBirth = Convert.ToDateTime(TxtDateOfBirth.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                cand.DateOfBirth = "1900/01/01";
            }
            try
            {
                cand.SalaryFrom = Convert.ToDecimal(TxtSalaryFrom.Text.Trim());
            }
            catch
            {
                cand.SalaryFrom = 0;
            }
            try
            {
                cand.SalaryTo = Convert.ToDecimal(TxtSalaryTo.Text.Trim());
            }
            catch
            {
                cand.SalaryTo = 1000000;
            }
            try
            {
                cand.EmployentProjectStartDateFrom = Convert.ToDateTime(TxtEmployementProjectStartDateFrom.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                cand.EmployentProjectStartDateFrom = "1900/01/01";
            }
            try
            {
                cand.EmployentProjectStartDateTo = Convert.ToDateTime(TxtEmployementProjectStartDateTo.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                cand.EmployentProjectStartDateTo = "5000/01/01";
            }
            try
            {
                cand.EmployentProjectEndDateFrom = Convert.ToDateTime(TxtEmploymentEndDateFrom.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                cand.EmployentProjectEndDateFrom = "1900/01/01";
            }
            try
            {
                cand.EmployentProjectEndDateTo = Convert.ToDateTime(TxtEmploymentEndDateTo.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                cand.EmployentProjectEndDateTo = "5000/01/01";
            }
            return cand;

        }

        protected void btnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            CandidatesBAL cand = loadReport();
            if (cand != null)
            {
                DataTable myDt = cand.GetAllActiveRegisteredCandidate(cand);
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
                    xlDocBody.Append("All Active Registered Candidates: " + DateTime.Now.ToString("dd/MM/yyyy"));
                    xlDocBody.Append("</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "".ToString() + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Number of entries: " + myDt.Rows.Count.ToString() + "</td>");
                    xlDocBody.Append("<tr><td width=\"25\"> </td></tr>");
                    xlDocBody.Append("<tr>");
                    //{registration_id,	{candidate_id,	{registration_date,	{designation_expiry_date,	{candidate_name,	{registration_id1,	{date_of_birth,	{disability_type,	{educational_qualification,	{i1,
                    //{phone_numbers,		{email_address,		{ngo_name,		{unemployed_days,		{unemployed_since_days,		{recommended_job_types,		{recommended_job_roles,		{role_name,		{designation,



                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Reg Id" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Cand Id" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Registration Date" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Designation Expiry Date" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Name of Candidate" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "RegId1" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Date of Birth" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Disability Type" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Educational Qualifications" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Secondary Phone Number" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Phone Numbers" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Email Address" + "</td>");

                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Ngo Name" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Employed Days" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Unemployed since(days)" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Recommended Job Type" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Recommended job Roles" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Role Name" + "</td>");
                    //{company_name,		{date_of_join,		{contract_expiry_date,		{registration_date1,		{salary,	
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Designation" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Company Name" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Date of Join" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Contract Expiry Date" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Registration Date" + "</td>");
                    xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Salary" + "</td>");
                    xlDocBody.Append("</tr>");
                    //
                    // Add Data Rows
                    foreach (DataRow dRow in myDt.Rows)
                    {
                        xlDocBody.Append("<tr>");
                        for (i = 0; i < 23; i++)
                        {
                            switch (i)
                            {
                                case 2:
                                case 3:
                                case 6:
                                case 20:
                                case 22:
                                    string st = string.IsNullOrEmpty(dRow[i].ToString()) ? string.Empty : Convert.ToDateTime(dRow[i].ToString()).ToString("dd/MM/yyyy");
                                    xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + st + "</td>");
                                    break;
                                case 4:
                                case 7:
                                case 8:
                                case 9:
                                case 10:
                                case 11:
                                case 14:
                                case 15:
                                case 16:
                                case 17:
                                case 18:
                                    xlDocBody.Append("<td valign=\"middle\" align=\"left\"> " + dRow[i].ToString() + "</td>");
                                    break;
                                default:
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
       
        private void dispRadWindow(string repName)
        {
            RadWindow rw = new RadWindow();
            rw.NavigateUrl = "../../ReportSection/RadReport.aspx?Report=" + repName;
            //            rw.NavigateUrl = "../Reports/RadReport.aspx";
            Session["repName"] = repName;
            rw.Height = 680;
            rw.Width = 1024;
            rw.MaxHeight = 680;
            rw.MaxWidth = 1024;
            rw.Modal = true;
            rw.Behaviors = WindowBehaviors.Maximize | WindowBehaviors.Maximize | WindowBehaviors.Move | WindowBehaviors.Reload | WindowBehaviors.Close;
            rw.KeepInScreenBounds = true;
            //            rw.Behavior = WindowBehaviors.Default;
            rw.ReloadOnShow = true;
            rw.ShowContentDuringLoad = false;
            rw.ID = "rwCenquiry";
            //   RadWindowManager rm = (RadWindowManager)this.Parent.FindControl("hradManager");
            this.radManager.Modal = true;
            this.radManager.VisibleOnPageLoad = true;
            rw.EnableViewState = false;
            rw.VisibleOnPageLoad = true;
            rw.AutoSize = false;
            this.radManager.EnableViewState = false;
            this.radManager.Windows.Add(rw);
            rw = this.radManager.Windows[0];
        }
        private void dispRadWindowUrl(string url)
        {
            RadWindow rw = new RadWindow();
            rw.NavigateUrl = url;
            //            rw.NavigateUrl = "../Reports/RadReport.aspx";
            rw.Height = 680;
            rw.Width = 1024;
            rw.MaxHeight = 680;
            rw.MaxWidth = 1024;
            rw.Modal = true;
            rw.Behaviors = WindowBehaviors.Maximize | WindowBehaviors.Maximize | WindowBehaviors.Move | WindowBehaviors.Reload | WindowBehaviors.Close;
            rw.KeepInScreenBounds = true;
            //            rw.Behavior = WindowBehaviors.Default;
            rw.ReloadOnShow = true;
            rw.ShowContentDuringLoad = false;
            rw.ID = "rwCenquiry";
            //   RadWindowManager rm = (RadWindowManager)this.Parent.FindControl("hradManager");
            this.radManager.Modal = true;
            this.radManager.VisibleOnPageLoad = true;
            rw.EnableViewState = false;
            rw.VisibleOnPageLoad = true;
            rw.AutoSize = false;
            this.radManager.EnableViewState = false;
            this.radManager.Windows.Add(rw);
            rw = this.radManager.Windows[0];
        }

    }
}