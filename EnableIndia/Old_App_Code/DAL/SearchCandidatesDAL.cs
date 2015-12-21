using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for SearchCandidatesDAL
    /// </summary>
    public class SearchCandidatesDAL
    {
        public SearchCandidatesDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet SearchAllActiveCandidates(EnableIndia.App_Code.BAL.SearchCandidatesBAL search)
        {
            try
            {
                string query = "search_all_active_candidates";
                List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_employment_status",Value=search.EmploymentStatus},
            new Parameter{Name="para_assignment",Value=search.Assignment},
            new Parameter{Name="para_city_id",Value=search.CityID},
            new Parameter{Name="para_age_group",Value=search.AgeGroup},
            new Parameter{Name="para_ngo_id",Value=search.NgoID},
            new Parameter{Name="para_disability_id",Value=search.DisabilityID},
            new Parameter{Name="para_search_for",Value=search.SearchFor},
            new Parameter{Name="para_search_in",Value=search.SearchIn},
            new Parameter{Name="para_current_date",Value=DateTime.Now.ToString("yyyy/MM/dd")},
            new Parameter{Name="para_old_registration_number",Value=search.OldRegistrationNumber},
            new Parameter{Name="para_date_of_birth",Value=search.DateOfBirth},
            new Parameter{Name="para_recommended_job_type_id",Value=search.JobTypeId},
            new Parameter{Name="para_recommended_job_role_id",Value=search.RecommendedJobRoleID},
            new Parameter{Name="para_page_number",Value=Convert.ToInt32(HttpContext.Current.Request.Cookies["grid_page_number"].Value) -1},
            new Parameter{Name="para_page_size",Value=Global.GetGridPageSize()},
            new Parameter{Name="para_missing_data_in_profile",Value=search.MissingDataInProfile},
        };

                DBAccess dba = new DBAccess();
                return (DataSet)dba.ExecuteQuery(query, parameters, "DataSet");
            }
            catch(System.Exception ex)
            {

            }
            return null;
        }

        public DataSet SearchToBeProfiledCandidates(EnableIndia.App_Code.BAL.SearchCandidatesBAL search)
        {
            string query = "search_to_be_profiled_candidates";

            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_search_for",Value=search.SearchFor},
            new Parameter{Name="para_search_in",Value=search.SearchIn},
            new Parameter{Name="para_registration_date_from",Value=search.DateFrom},
            new Parameter{Name="para_registration_date_to",Value=search.DateTo},
            new Parameter{Name="para_city_id",Value=search.CityID},
            new Parameter{Name="para_current_date",Value=DateTime.Now.ToString("yyyy/MM/dd")},
            new Parameter{Name="para_current_page_index",Value=Convert.ToInt32(HttpContext.Current.Request.Cookies["grid_page_number"].Value) -1},
            new Parameter{Name="para_page_size",Value=Global.GetGridPageSize()},
            new Parameter{Name="para_old_registration_number",Value=search.OldRegistrationNumber},
            new Parameter{Name="para_date_of_birth",Value=search.DateOfBirth},
            new Parameter{Name="para_disability_id",Value=search.DisabilityID}
        };

            DBAccess dba = new DBAccess();
            return (DataSet)dba.ExecuteQuery(query, parameters, "DataSet");
        }

        public DataTable SearchOpenCandidateTasks(EnableIndia.App_Code.BAL.SearchCandidatesBAL search)
        {
            string query = "search_open_candidate_tasks";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_selected_date",Value=search.SelectedDate},
            new Parameter{Name="para_date_from",Value=search.DateFrom},
            new Parameter{Name="para_date_to",Value=search.DateTo},
            new Parameter{Name="para_candidate_flag_id",Value=search.CandidateFlagID},
            new Parameter{Name="para_managed_by_id",Value=search.EmployeeID},
            new Parameter{Name="para_disability_id",Value=search.DisabilityID},
            new Parameter{Name="para_search_for",Value=search.SearchFor},
            new Parameter{Name="para_search_in",Value=search.SearchIn}
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameters, "DataTable");
        }

        public DataSet SearchAutoRecommendedCandidate(EnableIndia.App_Code.BAL.SearchCandidatesBAL search)
        {
            string query = "search_recommended_candidates_for_training_project";

            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_training_program_id",Value=search.TrainingProgramID},
            new Parameter{Name="para_training_project_id",Value=search.TrainingProjectID},
            new Parameter{Name="para_age_group_id",Value=search.AgeGroup},
            new Parameter{Name="para_current_date",Value=DateTime.Now.ToString("yyyy/MM/dd")},
            new Parameter{Name="para_search_for",Value=search.SearchFor},
            new Parameter{Name="para_search_in",Value=search.SearchIn},
            new Parameter{Name="para_page_number",Value=Convert.ToInt32(HttpContext.Current.Request.Cookies["grid_page_number"].Value) -1},
            new Parameter{Name="para_page_size",Value=Global.GetGridPageSize()},
        };

            DBAccess dba = new DBAccess();
            return (DataSet)dba.ExecuteQuery(query, parameters, "DataSet");
        }

        public DataSet SearchRecommendedCandidatesForEmploymentProjects(EnableIndia.App_Code.BAL.SearchCandidatesBAL search)
        {
            string query = "search_recommended_candidates_for_employment_project";

            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_employment_project_id",Value=search.EmploymentProjectID},
            new Parameter{Name="para_age_group",Value=search.AgeGroup},
            new Parameter{Name="para_current_date",Value=DateTime.Now.ToString("yyyy/MM/dd")},
            new Parameter{Name="para_page_number",Value=Convert.ToInt32(HttpContext.Current.Request.Cookies["grid_page_number"].Value) -1},
            new Parameter{Name="para_page_size",Value=Global.GetGridPageSize()},
            new Parameter{Name="para_search_for",Value=search.SearchFor},
            new Parameter{Name="para_search_in",Value=search.SearchIn},
            new Parameter{Name="para_gender",Value=search.Gender},
        };

            DBAccess dba = new DBAccess();
            return (DataSet)dba.ExecuteQuery(query, parameters, "DataSet");
        }

        public DataSet SearchNonRecommendedCandidatesForEmploymentProject(EnableIndia.App_Code.BAL.SearchCandidatesBAL search)
        {
            string query = "search_non_recommended_candidates_for_employment_project";

            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_employment_project_id",Value=search.EmploymentProjectID},
            new Parameter{Name="para_qualification_id",Value=search.QualificationID},
            new Parameter{Name="para_ngo_id",Value=search.NgoID},
            new Parameter{Name="para_state_id",Value=search.PresentAddressStateID},
            new Parameter{Name="para_city_id",Value=search.CityID},
            new Parameter{Name="para_training_program_id",Value=search.TrainingProgramID},
            new Parameter{Name="para_disability_id",Value=search.DisabilityID},
            new Parameter{Name="para_job_id",Value=search.JobTypeId},
            new Parameter{Name="para_job_role_id",Value=search.JobRoleID},
            new Parameter{Name="para_language_id",Value=search.LanguageID},
            new Parameter{Name="para_candidate_group_id",Value=search.CandidateGroupID},
            new Parameter{Name="para_age_group",Value=search.AgeGroup},
            new Parameter{Name="para_current_date",Value=DateTime.Now.ToString("yyyy/MM/dd")},
            new Parameter{Name="para_employment_status",Value=search.EmploymentStatus},
            new Parameter{Name="para_search_for",Value=search.SearchFor},
            new Parameter{Name="para_search_in",Value=search.SearchIn},
            new Parameter{Name="para_gender",Value=search.Gender},
            new Parameter{Name="para_page_number",Value=Convert.ToInt32(HttpContext.Current.Request.Cookies["grid_page_number"].Value) -1},
            new Parameter{Name="para_page_size",Value=Global.GetGridPageSize()},
        };

            DBAccess dba = new DBAccess();
            return (DataSet)dba.ExecuteQuery(query, parameters, "DataSet");
        }

        public DataTable GetCandidateWiseTrainingEmploymentRelation(EnableIndia.App_Code.BAL.SearchCandidatesBAL search)
        {
            string query = "rpt_candidatewise_training_and_employment";

            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_is_profiled",Value=search.IsProfiled},
            new Parameter{Name="para_employment_status",Value=search.EmploymentStatus},
            new Parameter{Name="para_training_project_id",Value=search.TrainingProjectID},
            new Parameter{Name="para_date_type",Value=search.DateType},
            new Parameter{Name="para_training_date_from",Value=search.TrainingDateFrom},
            new Parameter{Name="para_training_date_to",Value=search.TrainingDateTo},
            new Parameter{Name="para_employment_date_from",Value=search.EmploymentDateFrom},
            new Parameter{Name="para_employment_date_to",Value=search.EmploymentDateTo},
            new Parameter{Name="para_recommended_job_type_id",Value=search.JobTypeId},
            new Parameter{Name="para_recommended_job_role_id",Value=search.JobRoleID},
            new Parameter{Name="para_disability_id",Value=search.DisabilityID},
            new Parameter{Name="para_group_id",Value=search.GroupID},
            new Parameter{Name="para_qualification_id",Value=search.QualificationID},
            new Parameter{Name="para_recommended_training_program_id",Value=search.TrainingProgramID},
            new Parameter{Name="para_not_done_training_program_id",Value=search.NotDoneTrainingProgramID},
            new Parameter{Name="para_search_for",Value=search.SearchFor},
            new Parameter{Name="para_search_in",Value=search.SearchIn},
            new Parameter{Name="para_training_program_id",Value=search.AssignedTrainingProgramID},
            new Parameter{Name="para_assigned_training_project_id",Value=search.TrainingProjectID},
            new Parameter{Name="para_current_date",Value=DateTime.Now.ToString("yyyy/MM/dd")}
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameters, "DataTable");
        }
    }
}