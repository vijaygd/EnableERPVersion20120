using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Admin
{
    public partial class DropdownTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetDefaultButtonOfTheForm(this.Form, BtnAddParameter);
            if (!Page.IsPostBack)
            {
                Global.AuthenticateUser();

                GetDisabilityTypes();
                GetJobs();
                GetCountries();
                GetStates();

                Global.ShowMessageInAlert(this.Form);
            }

            StatesBAL state = new StatesBAL();
            MySqlDataReader dtStates = state.GetStates("-1");
            while (dtStates.Read())
            {
                ListItem li = new ListItem(dtStates["state_name"].ToString(), dtStates["state_id"].ToString());
                li.Attributes.Add("CountryID", dtStates["country_id"].ToString());
                DdlHiddenStates.Items.Add(li);
            }
            DdlHiddenStates.Items.Insert(0, new ListItem("Select", "-2"));
            DdlHiddenStates.Items.Add(new ListItem("Not Available", "-3"));
        }

        protected void BtnRefreshStates_Click(object sender, EventArgs e)
        {
            GetStates();
            DdlStates.Focus();
            BtnRefreshStates.Focus();
        }
        protected void BtnClearParameter_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/DropDownTest.aspx");
        }

        private void CheckForDuplication()
        {
            string query = "select count(" + DdlParameters.Items[DdlParameters.SelectedIndex].Attributes["IdentityColumn"] + ") ";
            query += "from " + DdlParameters.Items[DdlParameters.SelectedIndex].Attributes["TableName"] + " where " + DdlParameters.Items[DdlParameters.SelectedIndex].Attributes["ColumnName"] + "=\"" + TxtNewType.Text.Trim() + "\"";
            switch (DdlParameters.Value)
            {
                case "Job Role":
                    query += " and job_id=" + DdlJobs.Value;
                    break;

                case "State":
                    query += " and country_id=" + DdlCountries.Value;
                    break;

                case "City":
                    query += " and state_id=" + DdlHiddenStates.Value;
                    break;
            }

            DBAccess dba = new DBAccess();
            string duplicateRecords = dba.ExecuteQuery(query, null, "Scalar").ToString();
            if (duplicateRecords.Equals("1"))
            {
                string message = Global.EncryptQueryString(DdlParameters.Value + " - " + TxtNewType.Text.Trim() + " already exists.");
                Response.Redirect("~/Admin/DropDownTest.aspx?msg=" + message + "&foc=" + Global.EncryptQueryString(BtnAddParameter.ID), true);
            }
        }

        protected void BtnAddParameter_Click(object sender, EventArgs e)
        {
            string selectedParameter = DdlParameters.Value;
            CheckForDuplication();
            switch (DdlParameters.Value)
            {
                case "Education":
                    AddEducation();
                    break;

                case "Disability Type":
                    AddDisabilityType();
                    break;

                case "Disability Sub Type":
                    AddDisabilitySubType();
                    break;

                case "Job Type":
                    //AddJob();
                    break;

                case "Job Role":
                    AddJobRole();
                    break;

                case "Candidate Group":
                    AddCandidateGroup();
                    break;

                case "Country":
                    AddCountry();
                    break;

                case "State":
                    AddState();
                    break;

                case "City":
                    AddCity();
                    break;

                case "Candidate Flag":
                    AddCandidateFlag();
                    break;

                case "Company Flag":
                    AddCompanyFlag();
                    break;

                case "Languages":
                    AddLanguage();
                    break;
            }

            Global.RedirectAfterSubmit(DdlParameters.Value + " added succesfully.", BtnAddParameter.ID);
        }

        #region FUNCTIONS TO GET DATA
        private void GetDisabilityTypes()
        {
            EnableIndia.App_Code.BAL.DisabilityTypesBAL disab = new EnableIndia.App_Code.BAL.DisabilityTypesBAL();
            MySqlDataReader drDisabilityTypes = disab.GetDisabilityTypes();
            Global.FillDropDown(DdlDisabilityTypes, drDisabilityTypes, "disability_type", "disability_id");
            if (DdlDisabilityTypes.Items.Count.Equals(0))
            {
                DdlDisabilityTypes.Items.Add(new ListItem("No Disability Type", "-2"));
            }
        }

        private void GetJobs()
        {
            EnableIndia.App_Code.BAL.JobsBAL job = new EnableIndia.App_Code.BAL.JobsBAL();
            MySqlDataReader drJobs = job.GetJobs();
            Global.FillDropDown(DdlJobs, drJobs, "job_name", "job_id");
            if (DdlJobs.Items.Count.Equals(0))
            {
                DdlJobs.Items.Add(new ListItem("No Job Created", "-2"));
            }
        }

        private void GetCountries()
        {
            CountriesBAL countr = new CountriesBAL();
            MySqlDataReader drCountries = countr.GetCountries();
            Global.FillDropDown(DdlCountries, drCountries, "country_name", "country_id");
            if (DdlCountries.Items.Count.Equals(0))
            {
                DdlCountries.Items.Add(new ListItem("No Country Created", "-2"));
            }
        }

        private void GetStates()
        {
            StatesBAL stat = new StatesBAL();
            MySqlDataReader drStates = stat.GetStates(DdlCountries.Value);
            Global.FillDropDown(DdlStates, drStates, "state_name", "state_id");
            if (DdlStates.Items.Count.Equals(0))
            {
                DdlStates.Items.Add(new ListItem("No State Created", "-2"));
            }
        }
        #endregion

        #region FUNCTIONS TO ADD DATA
        private void AddDisabilitySubType()
        {
            DisabilitySubTypesBAL disSub = new DisabilitySubTypesBAL();
            bool isDisabilitySubTypeAdded = disSub.AddDisabilitySubType(DdlDisabilityTypes.Value, TxtNewType.Text.Trim());
            if (isDisabilitySubTypeAdded.Equals(true))
            {
                Global.ShowMessagesInDiv(this.Page, "Disability sub type added successfully.");
            }
            else
            {
                Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
            }
        }

        private void AddEducation()
        {
            EnableIndia.App_Code.BAL.EducationBAL edu = new EnableIndia.App_Code.BAL.EducationBAL();
            bool isEducationAdded = edu.AddEducation(TxtNewType.Text.Trim());
            if (isEducationAdded.Equals(true))
            {
                Global.ShowMessagesInDiv(this.Page, "Education type added successfully.");
            }
            else
            {
                Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
            }
        }

        private void AddDisabilityType()
        {
            EnableIndia.App_Code.BAL.DisabilityTypesBAL disab = new EnableIndia.App_Code.BAL.DisabilityTypesBAL();
            bool isDisabilityAdded = disab.AddDisabilityType(TxtNewType.Text.Trim());
            if (isDisabilityAdded.Equals(true))
            {
                Global.ShowMessagesInDiv(this.Page, "Disability type added successfully.");
            }
            else
            {
                Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
            }
            GetDisabilityTypes();
        }

        //private void AddJob()
        //{
        //    JobsBAL job = new JobsBAL();
        //    //bool isJobAdded = job.AddJob(TxtNewType.Text.Trim());
        //    if(isJobAdded.Equals(true))
        //    {
        //        Global.ShowMessagesInDiv(this.Page, "Job type added successfully.");
        //    }
        //    else
        //    {
        //        Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
        //    }
        //    GetJobs();
        //}

        private void AddJobRole()
        {
            EnableIndia.App_Code.BAL.JobRolesBAL jobRole = new EnableIndia.App_Code.BAL.JobRolesBAL();
            bool isJobRoleAdded = jobRole.AddJobRole(DdlJobs.Value, TxtNewType.Text.Trim());
            if (isJobRoleAdded.Equals(true))
            {
                Global.ShowMessagesInDiv(this.Page, "Role added successfully.");
            }
            else
            {
                Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
            }
        }

        private void AddCandidateGroup()
        {
            EnableIndia.App_Code.BAL.CandidateGroupsBAL group = new EnableIndia.App_Code.BAL.CandidateGroupsBAL();
            bool isCandidateGroupAdded = group.AddCandidateGroup(TxtNewType.Text.Trim());
            if (isCandidateGroupAdded.Equals(true))
            {
                Global.ShowMessagesInDiv(this.Page, "Candidate group added successfully.");
            }
            else
            {
                Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
            }
        }

        private void AddCountry()
        {
            EnableIndia.App_Code.BAL.CountriesBAL countr = new EnableIndia.App_Code.BAL.CountriesBAL();
            bool isCountryAdded = countr.AddCountry(TxtNewType.Text.Trim());
            if (isCountryAdded.Equals(true))
            {
                Global.ShowMessagesInDiv(this.Page, "Country added successfully.");
            }
            else
            {
                Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
            }
            GetCountries();
            GetStates();
        }

        private void AddState()
        {
            EnableIndia.App_Code.BAL.StatesBAL state = new EnableIndia.App_Code.BAL.StatesBAL();
            bool isStateAdded = state.AddState(DdlCountries.Value, TxtNewType.Text.Trim());
            if (isStateAdded.Equals(true))
            {
                Global.ShowMessagesInDiv(this.Page, "State added successfully.");
            }
            else
            {
                Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
            }
            GetStates();
        }

        private void AddCity()
        {
            EnableIndia.App_Code.BAL.CitiesBAL city = new EnableIndia.App_Code.BAL.CitiesBAL();
            bool isCityAdded = city.AddCity(DdlHiddenStates.Value, TxtNewType.Text.Trim());
            if (isCityAdded.Equals(true))
            {
                Global.ShowMessagesInDiv(this.Page, "City added successfully.");
            }
            else
            {
                Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
            }
        }

        private void AddCandidateFlag()
        {
            EnableIndia.App_Code.BAL.CandidateFlagsBAL flag = new EnableIndia.App_Code.BAL.CandidateFlagsBAL();
            bool isFlagAdded = flag.AddCandidateFlag(TxtNewType.Text.Trim());
            if (isFlagAdded.Equals(true))
            {
                Global.ShowMessagesInDiv(this.Page, "Candidate flag added successfully.");
            }
            else
            {
                Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
            }
        }

        private void AddCompanyFlag()
        {
            EnableIndia.App_Code.BAL.CompanyFlagsBAL flag = new EnableIndia.App_Code.BAL.CompanyFlagsBAL();
            bool isFlagAdded = flag.AddCompanyFlag(TxtNewType.Text.Trim());
            if (isFlagAdded.Equals(true))
            {
                Global.ShowMessagesInDiv(this.Page, "Company flag added successfully.");
            }
            else
            {
                Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
            }
        }

        private void AddLanguage()
        {
            EnableIndia.App_Code.BAL.LanguagesBAL lang = new EnableIndia.App_Code.BAL.LanguagesBAL();
            bool isLanguageAdded = lang.AddLanguage(TxtNewType.Text.Trim());
            if (isLanguageAdded.Equals(true))
            {
                Global.ShowMessagesInDiv(this.Page, "Language added successfully.");
            }
            else
            {
                Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
            }
        }
        #endregion
    }
}