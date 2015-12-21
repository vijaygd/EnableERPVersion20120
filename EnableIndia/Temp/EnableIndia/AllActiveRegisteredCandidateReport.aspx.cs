using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Stimulsoft.Report;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.ReportSection
{
    public partial class AllActiveRegisteredCandidateReport : System.Web.UI.Page
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
            }
        }

        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();
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
            cand.IsProfiled = DdlProfilingStatus.Value;
            cand.EmploymentStatus = Convert.ToInt32(DdlTypeOfCandidate.Value);
            cand.Assignment = DdlAssignment.Value;
            cand.StateID = Convert.ToInt32(DdlState.Value);
            // ------------- Modified on 01-03-2012-------------
            if (string.IsNullOrEmpty(TxtHidddenCity.Text))
                cand.CityID = -1;
            else
                cand.CityID = string.IsNullOrEmpty(TxtHidddenCity.Text)?-1:((TxtHidddenCity.Text == "-1") ? -1 : Convert.ToInt32(TxtHidddenCity.Text.Trim()));
            //  cand.CityID = Convert.ToInt32(TxtHidddenCity.Text.Trim());
            cand.AgeGroup = (string.IsNullOrEmpty(DdlAgeGroups.Value)?-1: (DdlAgeGroups.Value == "-1") ? -1 : Convert.ToInt32(DdlAgeGroups.Value));
            // cand.AgeGroup = Convert.ToInt32(DdlAgeGroups.Value);
            cand.NgoID = string.IsNullOrEmpty(DdlNGOs.Value)?-1:Convert.ToInt32(DdlNGOs.Value);
            cand.SearchFor = string.IsNullOrEmpty(TxtSearchFor.Text)?"": TxtSearchFor.Text.Trim();
            cand.SearchIn = DdlSearchIn.Value;
            cand.DisabilityID = string.IsNullOrEmpty(DdlDisabilityTypes.Value)?-1:Convert.ToInt32(DdlDisabilityTypes.Value);
            cand.DisabilitySubTypeID = string.IsNullOrEmpty(DdlHiddenDisabilitySubType.Value)?-1:Convert.ToInt32(DdlHiddenDisabilitySubType.Value);
            cand.RecommendedJobID = string.IsNullOrEmpty(DdlRecommendedJobType.Value)?-1: Convert.ToInt32(DdlRecommendedJobType.Value);
            cand.RecommendedJobRoleID = string.IsNullOrEmpty(TxtHiddenRecommendedRole.Text)?-1:Convert.ToInt32(TxtHiddenRecommendedRole.Text.Trim());
            SpnHiddenRecommendedRole.InnerText = TxtHiddenRecommendedRole.Text.Trim();
            SpnHiddenDisabilityType.InnerText = TxtHiddenDisabilitySubType.Text.Trim();
            cand.MissingDataProfile = DdlMissingData.Value;

            cand.GroupID =  string.IsNullOrEmpty(DdlGroups.Value)?-1:Convert.ToInt32(DdlGroups.Value);
            cand.LanguageID = string.IsNullOrEmpty(DdlLanguage.Value)?-1:Convert.ToInt32(DdlLanguage.Value);
            cand.Gender = DdlGender.Value;
            cand.CompanyID = string.IsNullOrEmpty(DdlCompanies.Value)?-1: Convert.ToInt32(DdlCompanies.Value);
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
            
            DataTable dt = cand.GetAllActiveRegisteredCandidate(cand);
            report.RegData("DsActiveCandidates", dt);
            if (dt.Rows.Count.Equals(0))
            {
                report.Load(Server.MapPath("~/Reports/BlankReport.mrt"));
            }
            else
            {
                report.Load(Server.MapPath("~/Reports/AllActiveRegisteredCandidates.mrt"));
            }
         
            StiWebViewer1.Report = report;
        }
    }
}