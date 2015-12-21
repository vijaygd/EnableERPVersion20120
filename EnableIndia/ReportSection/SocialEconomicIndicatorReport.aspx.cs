using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.IO;

using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


namespace EnableIndia.Reports
{
    public partial class SocialEconomicIndicatorReport : System.Web.UI.Page
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
            if(!Page.IsPostBack)
            {
                if (!Page.IsPostBack)
                {
                    Global.SetUICulture(this.Page);

                    //EnableIndia.App_Code.BAL.EducationBAL education = new EnableIndia.App_Code.BAL.EducationBAL();
                    //MySqlDataReader drEducation = education.GetEducations();
                    //Global.FillDropDown(DdlQualification, drEducation, "course_qualification_name", "course_qualification_id");
                    //DdlQualification.Items.RemoveAt(0);
                    //DdlQualification.Items.Insert(0, new ListItem("All", "-1"));
                    //DdlQualification.Items.Insert(1, new ListItem("None", "-2"));

                    //EnableIndia.App_Code.BAL.CompaniesBAL comp = new EnableIndia.App_Code.BAL.CompaniesBAL();
                    //MySqlDataReader drCompany = comp.GetCompanies("-1");
                    //Global.FillDropDown(DdlCompanies, drCompany, "company_code", "company_id");
                    //DdlCompanies.Items.RemoveAt(0);
                    //DdlCompanies.Items.Insert(0, new ListItem("All", "-1"));
                    //DdlCompanies.Items.Insert(1, new ListItem("Unlisted", "-2"));

                    //EnableIndia.App_Code.BAL.LanguagesBAL language = new EnableIndia.App_Code.BAL.LanguagesBAL();
                    //MySqlDataReader drLanguages = language.GetLanguagesInReader();
                    //Global.FillDropDown(DdlLanguage, drLanguages, "language_name", "language_id");
                    //DdlLanguage.Items.RemoveAt(0);
                    //DdlLanguage.Items.Insert(0, new ListItem("All", "-1"));
                    //DdlLanguage.Items.Insert(1, new ListItem("None", "-2"));

                    //EnableIndia.App_Code.BAL.CandidateGroupsBAL candidateGroup = new EnableIndia.App_Code.BAL.CandidateGroupsBAL();
                    //DataTable dtCandidateGroup = candidateGroup.GetCandidateGroup();
                    //DdlGroups.DataSource = dtCandidateGroup;
                    //DdlGroups.DataTextField = "group_name";
                    //DdlGroups.DataValueField = "group_id";
                    //DdlGroups.DataBind();
                    //DdlGroups.Items.Insert(0, new ListItem("All", "-1"));
                    //DdlGroups.Items.Insert(1, new ListItem("None", "-2"));

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

                    //EnableIndia.App_Code.BAL.NGOsBAL ngo = new EnableIndia.App_Code.BAL.NGOsBAL();
                    //MySqlDataReader drNgos = ngo.GetNGOs(true);
                    //Global.FillDropDown(DdlNGOs, drNgos, "ngo_name", "ngo_id");
                    //if (DdlNGOs.Items.Count > 0)
                    //{
                    //    DdlNGOs.Items.RemoveAt(0);
                    //    DdlNGOs.Items.Insert(0, new ListItem("All", "-1"));
                    //}
                    //DdlNGOs.Items.Add(new ListItem("Others", "-2"));

                    EnableIndia.App_Code.BAL.JobsBAL job = new EnableIndia.App_Code.BAL.JobsBAL();
                    MySqlDataReader drJob = job.GetJobs();
                    Global.FillDropDown(DdlRecommendedJobType, drJob, "job_name", "job_id");
                    if (DdlRecommendedJobType.Items.Count > 0)
                    {
                        DdlRecommendedJobType.Items.RemoveAt(0);
                        DdlRecommendedJobType.Items.Insert(0, new ListItem("All", "-1"));
                    }
                }

            }

        }
        protected void btnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
           Old_App_Code.BAL.SocioEconomicIndicatorBAL seib = new Old_App_Code.BAL.SocioEconomicIndicatorBAL();
           seib = loadReport();
           DataTable myDt = (DataTable)getReport(seib);
           if (myDt != null)
           {
               int i = 0;
               StringBuilder xlDocBody = new StringBuilder(); ;
               // -------------------------------------------------
               // Create dir for storing....
               // ------------------------------------------------
               string dirPath = System.Configuration.ConfigurationManager.AppSettings["ExcelReports"];
               dirPath += "\\SocioEconomicIndicator" + DateTime.Now.ToString("ddMMyyhhmm") + ".xls";
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
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Reg Id" + "</td>");
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Cand Id" + "</td>");
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Registration Date" + "</td>");
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Name of Candidate" + "</td>");
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Date of Birth" + "</td>");
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Disability Type" + "</td>");
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Educational Qualifications" + "</td>");
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Email Address" + "</td>");
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Ngo Name" + "</td>");
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Recommended Job Type" + "</td>");
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Recommended job Roles" + "</td>");
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Salary" + "</td>");
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Family Income" + "</td>");
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Number of members" + "</td>");
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Main Earning Member" + "</td>");
                   xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Modified Date" + "</td>");



                   xlDocBody.Append("</tr>");
                   //
                   // Add Data Rows
                   foreach (DataRow dRow in myDt.Rows)
                   {
                       xlDocBody.Append("<tr>");
                       for (i = 0; i < 16; i++)
                       {
                           switch (i)
                           {
                               case 2:
                               case 4:
                               case 15:
                                   string st = string.IsNullOrEmpty(dRow[i].ToString()) ? string.Empty : Convert.ToDateTime(dRow[i].ToString()).ToString("dd/MM/yyyy");
                                   xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + st + "</td>");
                                   break;
                               case 3:
                               case 7:
                               case 8:
                               case 9:
                               case 10:
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
               catch (System.Exception ex)
               {

               }
           }


        }
        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            
        }
        private DataTable getReport(Old_App_Code.BAL.SocioEconomicIndicatorBAL seib)
        {
            DataTable dt = new DataTable();
            dt = seib.GetSEIReport(seib);
            return (dt);

        }
        private Old_App_Code.BAL.SocioEconomicIndicatorBAL loadReport()
        {
            Old_App_Code.BAL.SocioEconomicIndicatorBAL seib = new Old_App_Code.BAL.SocioEconomicIndicatorBAL();
            int candidateID = seib.GetCandidateID(TxtSearchFor.Text.Trim());
            try
            {
                seib.CandidateID = candidateID;
                if (seib.CandidateID == 66) seib.CandidateID = -1;
            }
            catch
            {
                seib.CandidateID = -1;
            }
            seib.StateID = Convert.ToInt32(DdlState.Value);
            if (string.IsNullOrEmpty(TxtHidddenCity.Text))
                seib.CityID = -1;
            else
                seib.CityID = string.IsNullOrEmpty(TxtHidddenCity.Text) ? -1 : ((TxtHidddenCity.Text == "-1") ? -1 : Convert.ToInt32(TxtHidddenCity.Text.Trim()));
            //  cand.CityID = Convert.ToInt32(TxtHidddenCity.Text.Trim());
            seib.AgeGroup = (string.IsNullOrEmpty(DdlAgeGroups.Value) ? -1 : (DdlAgeGroups.Value == "-1") ? -1 : Convert.ToInt32(DdlAgeGroups.Value));
            // cand.AgeGroup = Convert.ToInt32(DdlAgeGroups.Value);
//            cand.NgoID = string.IsNullOrEmpty(DdlNGOs.Value) ? -1 : Convert.ToInt32(DdlNGOs.Value);
//            cand.SearchFor = string.IsNullOrEmpty(TxtSearchFor.Text) ? "" : TxtSearchFor.Text.Trim();
            seib.SearchIn = DdlSearchIn.SelectedValue;
            seib.DisabilityID = string.IsNullOrEmpty(DdlDisabilityTypes.Value) ? -1 : Convert.ToInt32(DdlDisabilityTypes.Value);
            seib.DisabilitySubTypeID = string.IsNullOrEmpty(DdlHiddenDisabilitySubType.Value) ? -1 : Convert.ToInt32(DdlHiddenDisabilitySubType.Value);
            seib.RecommendedJobID = string.IsNullOrEmpty(DdlRecommendedJobType.Value) ? -1 : Convert.ToInt32(DdlRecommendedJobType.Value);
            seib.RecommendedJobRoleID = string.IsNullOrEmpty(TxtHiddenRecommendedRole.Text) ? -1 : Convert.ToInt32(TxtHiddenRecommendedRole.Text.Trim());
            SpnHiddenRecommendedRole.InnerText = TxtHiddenRecommendedRole.Text.Trim();
            SpnHiddenDisabilityType.InnerText = TxtHiddenDisabilitySubType.Text.Trim();
            seib.seiStatus = (this.ddlSEIOption.SelectedIndex <= 0) ? "AE" : "NE";
//            cand.MissingDataProfile = DdlMissingData.Value;

 //           cand.GroupID = string.IsNullOrEmpty(DdlGroups.Value) ? -1 : Convert.ToInt32(DdlGroups.Value);
 //           cand.LanguageID = string.IsNullOrEmpty(DdlLanguage.Value) ? -1 : Convert.ToInt32(DdlLanguage.Value);
            seib.Gender = DdlGender.Value;
            //cand.CompanyID = string.IsNullOrEmpty(DdlCompanies.Value) ? -1 : Convert.ToInt32(DdlCompanies.Value);
            //cand.QualificationID = Convert.ToInt32(DdlQualification.Value);
            //try
            //{
            //    cand.RegistrationFrom = Convert.ToDateTime(TxtRegistrationFrom.Text.Trim()).ToString("yyyy/MM/dd");
            //}
            //catch
            //{
            //    cand.RegistrationFrom = "1900/01/01";
            //}
            //try
            //{
            //    cand.RegistrationTo = Convert.ToDateTime(TxtRegistrationTo.Text.Trim()).ToString("yyyy/MM/dd");
            //}
            //catch
            //{
            //    cand.RegistrationTo = "5000/01/01";
            //}
            //try
            //{
            //    cand.DateOfBirth = Convert.ToDateTime(TxtDateOfBirth.Text.Trim()).ToString("yyyy/MM/dd");
            //}
            //catch
            //{
            //    cand.DateOfBirth = "1900/01/01";
            //}
            try
            {
                seib.SalaryFrom = Convert.ToDecimal(TxtSalaryFrom.Text.Trim());
            }
            catch
            {
                seib.SalaryFrom = 0;
            }
            try
            {
                seib.SalaryTo = Convert.ToDecimal(TxtSalaryTo.Text.Trim());
            }
            catch
            {
                seib.SalaryTo = 1000000;
            }
            //try
            //{
            //    cand.EmployentProjectStartDateFrom = Convert.ToDateTime(TxtEmployementProjectStartDateFrom.Text.Trim()).ToString("yyyy/MM/dd");
            //}
            //catch
            //{
            //    cand.EmployentProjectStartDateFrom = "1900/01/01";
            //}
            //try
            //{
            //    cand.EmployentProjectStartDateTo = Convert.ToDateTime(TxtEmployementProjectStartDateTo.Text.Trim()).ToString("yyyy/MM/dd");
            //}
            //catch
            //{
            //    cand.EmployentProjectStartDateTo = "5000/01/01";
            //}
            //try
            //{
            //    cand.EmployentProjectEndDateFrom = Convert.ToDateTime(TxtEmploymentEndDateFrom.Text.Trim()).ToString("yyyy/MM/dd");
            //}
            //catch
            //{
            //    cand.EmployentProjectEndDateFrom = "1900/01/01";
            //}
            //try
            //{
            //    cand.EmployentProjectEndDateTo = Convert.ToDateTime(TxtEmploymentEndDateTo.Text.Trim()).ToString("yyyy/MM/dd");
            //}
            //catch
            //{
            //    cand.EmployentProjectEndDateTo = "5000/01/01";
            //}
            seib.SearchFor = string.IsNullOrEmpty(TxtSearchFor.Text) ? "" : TxtSearchFor.Text.Trim();
            seib.SearchIn = DdlSearchIn.SelectedValue;

            return seib;
 
        }
    }
}