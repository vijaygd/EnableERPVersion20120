using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for EmploymentProjectDAL
    /// </summary>
    public class EmploymentProjectDAL
    {
        public EmploymentProjectDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetEmploymentProjectDetails(string employmentProjectID)
        {
            string query = "call get_employment_project_detail(" + employmentProjectID + ")";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public MySqlDataReader GetEmploymentProjects()
        {
            string query = "SELECT * FROM employment_projects WHERE is_closed=1";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public MySqlDataReader GetEmploymentProjectNameDetail()
        {
            string query = "select * from employment_projects order by employment_project_name";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataSet GetcandidatesAssigenedToEmploymentProject(string employmentProjectID, int pagenumber, int pagesize)
        {
            string query = "call get_candidates_assigned_to_employment_project(" + employmentProjectID + "," + pagenumber + "," + pagesize + ")";

            DBAccess dba = new DBAccess();
            return (DataSet)dba.ExecuteQuery(query, null, "DataSet");
        }

        public DataTable GetCandidatesAssignedToEmploymentProjectsReader(string employmentProjectID)
        {
            string query = "select * from  candidates_assigned_to_employment_project where employment_project_id=" + employmentProjectID;

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public string AddEmploymentProject(MySqlCommand cmd, EnableIndia.App_Code.BAL.EmploymentProjectBAL emplProj)
        {
            cmd.Parameters.AddWithValue("para_parent_company_id", emplProj.ParentCompanyID);
            cmd.Parameters.AddWithValue("para_company_id", emplProj.CompanyID);
            cmd.Parameters.AddWithValue("para_vacancy_id", emplProj.VacancyID);
            cmd.Parameters.AddWithValue("para_possible_start_date", emplProj.PossibleStartDate);
            cmd.Parameters.AddWithValue("para_possible_end_date", emplProj.PossibleEndDate);
            cmd.Parameters.AddWithValue("para_current_demand_of_people", emplProj.CurrentDemandOfPeople);
            cmd.Parameters.AddWithValue("para_designation", emplProj.Designation);
            cmd.Parameters.AddWithValue("para_project_type", emplProj.ProjectType);
            cmd.Parameters.AddWithValue("para_salary", emplProj.Salary);
            cmd.Parameters.AddWithValue("para_employee_id", emplProj.EmployeeID);
            cmd.Parameters.AddWithValue("para_job_id", emplProj.JobID);
            cmd.Parameters.AddWithValue("para_job_role_id", emplProj.JobRoleID);
            cmd.Parameters.AddWithValue("para_responsibilities", emplProj.Responsibilities);
            cmd.Parameters.AddWithValue("para_intervention_required", emplProj.InterventionRequired);
            cmd.Parameters.AddWithValue("para_working_days", emplProj.WorkingDays);
            cmd.Parameters.AddWithValue("para_has_shifts", emplProj.HasShifts);
            cmd.Parameters.AddWithValue("para_working_hours", emplProj.WorkingHours);
            cmd.Parameters.AddWithValue("para_holiday_leave_policy", emplProj.HolidayLeavePolicy);
            cmd.Parameters.AddWithValue("para_company_code", emplProj.CompanyCode);
            cmd.Parameters.AddWithValue("para_vacancy_code", emplProj.VacancyCode);

            return cmd.ExecuteScalar().ToString();
        }

        public void UpdateEmploymentProject(MySqlCommand cmd, EnableIndia.App_Code.BAL.EmploymentProjectBAL emplProj)
        {
            cmd.Parameters.AddWithValue("para_employment_project_id", emplProj.EmploymentProjectID);
            cmd.Parameters.AddWithValue("para_parent_company_id", emplProj.ParentCompanyID);
            cmd.Parameters.AddWithValue("para_company_id", emplProj.CompanyID);
            cmd.Parameters.AddWithValue("para_vacancy_id", emplProj.VacancyID);
            cmd.Parameters.AddWithValue("para_possible_start_date", emplProj.PossibleStartDate);
            cmd.Parameters.AddWithValue("para_possible_end_date", emplProj.PossibleEndDate);
            cmd.Parameters.AddWithValue("para_current_demand_of_people", emplProj.CurrentDemandOfPeople);
            cmd.Parameters.AddWithValue("para_designation", emplProj.Designation);
            cmd.Parameters.AddWithValue("para_project_type", emplProj.ProjectType);
            cmd.Parameters.AddWithValue("para_salary", emplProj.Salary);
            cmd.Parameters.AddWithValue("para_employee_id", emplProj.EmployeeID);
            cmd.Parameters.AddWithValue("para_job_id", emplProj.JobID);
            cmd.Parameters.AddWithValue("para_job_role_id", emplProj.JobRoleID);
            cmd.Parameters.AddWithValue("para_responsibilities", emplProj.Responsibilities);
            cmd.Parameters.AddWithValue("para_intervention_required", emplProj.InterventionRequired);
            cmd.Parameters.AddWithValue("para_working_days", emplProj.WorkingDays);
            cmd.Parameters.AddWithValue("para_has_shifts", emplProj.HasShifts);
            cmd.Parameters.AddWithValue("para_working_hours", emplProj.WorkingHours);
            cmd.Parameters.AddWithValue("para_holiday_leave_policy", emplProj.HolidayLeavePolicy);
            cmd.ExecuteNonQuery();
        }

        public int UpdateCandidateAssignedList(MySqlCommand cmd, EnableIndia.App_Code.BAL.EmploymentProjectBAL emplProj)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "update_assigned_list_for_employment_project";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("para_employment_project_id", emplProj.EmploymentProjectID);
            cmd.Parameters.AddWithValue("para_candidate_id", emplProj.CandidateID);
            cmd.Parameters.AddWithValue("para_interested_in_job", emplProj.InterestedInJob);
            cmd.Parameters.AddWithValue("para_cretificates_verified", emplProj.CertificatesVerified);
            cmd.Parameters.AddWithValue("para_profile_sent", emplProj.ProfileSent);
            cmd.Parameters.AddWithValue("para_interview_scheduled", emplProj.InterviewScheduled);
            cmd.Parameters.AddWithValue("para_confirmed_for_interview", emplProj.ConfirmedForInterview);
            cmd.Parameters.AddWithValue("para_prepared_for_interview", emplProj.PreparedForInterview);
            cmd.Parameters.AddWithValue("para_interview_support_required", emplProj.InterviewSupportRequired);
            cmd.Parameters.AddWithValue("para_interview_process_completed", emplProj.InterviewProcessCompleted);
            cmd.Parameters.AddWithValue("para_got_job", emplProj.GotJob);
            cmd.Parameters.AddWithValue("para_candidate_informed_accepted_job", emplProj.CandidateInformedAcceptedJob);
            cmd.Parameters.AddWithValue("para_offer_letter_received", emplProj.OfferLetterReceived);
            cmd.Parameters.AddWithValue("para_employment_proof_received", emplProj.EmploymentProofReceived);
            cmd.Parameters.AddWithValue("para_work_place_solution_to_be_done", emplProj.WorkPlaceSolutionToBeDone);

            return cmd.ExecuteNonQuery();
        }

        public DataTable SearchOpenEmploymentProjects(EnableIndia.App_Code.BAL.EmploymentProjectBAL search)
        {
            string query = "search_open_employment_projects";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_company_id",Value=search.CompanyID},
            new Parameter{Name="para_vacancy_id",Value=search.VacancyID},
            new Parameter{Name="para_employee_id",Value=search.EmployeeID},
            new Parameter{Name="para_possible_start_date_from",Value=search.PossibleStartDateFrom},
            new Parameter{Name="para_possible_start_date_to",Value=search.PossibleStartDateTo},
            new Parameter{Name="para_possible_end_date_from",Value=search.PossibleEndDateFrom},
            new Parameter{Name="para_possible_end_date_to",Value=search.PossibleEndDateTo},
            new Parameter{Name="para_project_status",Value=search.ProjectStatus}
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameters, "DataTable");
        }

        public DataTable GetAssignedListForClosedEmploymentProject(EnableIndia.App_Code.BAL.EmploymentProjectBAL empProj)
        {
            string query = "rpt_get_assigned_list_closed_employment_project";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_vacancy_id",Value=empProj.VacancyID},
            new Parameter{Name="para_employment_project_id",Value=empProj.EmploymentProjectID}
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameters, "DataTable");
        }

        public void AssignCandidateToEmploymentProject(MySqlCommand cmd, string employmentProjectID, string candidateID)
        {
            cmd.CommandText = "insert into candidates_assigned_to_employment_project(employment_project_id,candidate_id)values(";
            cmd.CommandText += employmentProjectID + "," + candidateID + ");";
            cmd.CommandText += " CALL update_candidate_other_details(" + candidateID + "); ";
            cmd.ExecuteNonQuery();
        }

        public void DeleteAssignedCandidate(MySqlCommand cmd, string empProjectGroupID)
        {
            cmd.CommandText = "delete from candidates_assigned_to_employment_project where employment_project_group_id=" + empProjectGroupID;
            cmd.ExecuteNonQuery();
        }

        #region DELETE FUNCTIONS
        public void DeleteEmploymentProjectDisabilitySubTypes(MySqlCommand cmd, string employmentProjectID)
        {
            cmd.CommandText = "delete from employment_project_accepted_disability_sub_types where employment_project_id=" + employmentProjectID;
            cmd.ExecuteNonQuery();
        }

        public void DeleteEmploymentProjectEducationalQualifications(MySqlCommand cmd, string employmentProjectID)
        {
            cmd.CommandText = "delete from employment_project_required_qualifications where employment_project_id=" + employmentProjectID;
            cmd.ExecuteNonQuery();
        }

        public void DeleteEmploymentProjectTrainingProgram(MySqlCommand cmd, string employmentProjectID)
        {
            cmd.CommandText = "delete from employment_project_training_programs where employment_project_id=" + employmentProjectID;
            cmd.ExecuteNonQuery();
        }

        public void DeleteEmploymentProjectLangauges(MySqlCommand cmd, string employmentProjectID)
        {
            cmd.CommandText = "delete from employment_project_required_languages where employment_project_id=" + employmentProjectID;
            cmd.ExecuteNonQuery();
        }

        public void DeleteEmploymentProjectConsideredCandidateGroups(MySqlCommand cmd, string employmentProjectID)
        {
            cmd.CommandText = "delete from employment_project_considered_candidate_groups where employment_project_id=" + employmentProjectID;
            cmd.ExecuteNonQuery();
        }
        #endregion

        #region UPDATE FUNCTIONS
        public void AddEmploymentProjectDisabilitySubTypes(MySqlCommand cmd, string employmentProjectID, string disabilityID, string disabilitySubTypeID)
        {
            cmd.CommandText = "insert into employment_project_accepted_disability_sub_types(employment_project_id,disability_id,disability_sub_type_id)values(";
            cmd.CommandText += employmentProjectID + "," + disabilityID + "," + disabilitySubTypeID + ")";
            cmd.ExecuteNonQuery();
        }

        public void AddEmploymentProjectEducationalQualifications(MySqlCommand cmd, string employmentProjectID, string courseQualificationID)
        {
            cmd.CommandText = "insert into employment_project_required_qualifications(employment_project_id,course_qualification_id)values(";
            cmd.CommandText += employmentProjectID + "," + courseQualificationID + ")";
            cmd.ExecuteNonQuery();
        }

        public void AddEmploymentProjectTrainingPrograms(MySqlCommand cmd, string employmentProjectID, string trainingProgramID)
        {
            cmd.CommandText = "insert into employment_project_training_programs(employment_project_id,training_program_id)values(" + employmentProjectID + "," + trainingProgramID + ")";
            cmd.ExecuteNonQuery();
        }

        public void AddEmploymentProjectRequiredLanguages(MySqlCommand cmd, string employmentProjectID, string languageID)
        {
            cmd.CommandText = "insert into employment_project_required_languages(employment_project_id,language_id)values(" + employmentProjectID + "," + languageID + ")";
            cmd.ExecuteNonQuery();
        }

        public void AddEmploymentProjectConsideredCandidateGroups(MySqlCommand cmd, string employmentProjectID, string candidateGroupID)
        {
            cmd.CommandText = "insert into employment_project_considered_candidate_groups(employment_project_id,group_id)values(" + employmentProjectID + ",";
            cmd.CommandText += candidateGroupID + ")";
            cmd.ExecuteNonQuery();
        }
        #endregion

        #region GET FUNCTIONS
        public DataTable GetEmploymentProjectDisabilitySubTypes(string employmentProjectID)
        {
            string query = "call get_employment_project_disability_sub_types(" + employmentProjectID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetEmploymentProjectEducationalQualifications(string employmentProjectID)
        {
            string query = "call get_employment_project_educational_qualifications(" + employmentProjectID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetEmploymentProjectTrainingPrograms(string employmentProjectID)
        {
            string query = "call get_employment_project_training_programs(" + employmentProjectID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetEmploymentProjectRequiredLanguages(string employmentProjectID)
        {
            string query = "call get_employment_project_required_languages(" + employmentProjectID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetEmploymentProjectConsideredCandidateGroups(string employmentProjectID)
        {
            string query = "call get_employment_project_considered_candidate_groups(" + employmentProjectID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }
        #endregion

        public int AddEmploymentProjectNotes(EnableIndia.App_Code.BAL.EmploymentProjectBAL addNotes)
        {
            string query = "add_employment_project_candidate_notes";

            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_employment_project_id",Value=addNotes.EmploymentProjectID},
            new Parameter{Name="para_candidate_id",Value=addNotes.CandidateID},
            new Parameter{Name="para_interview_date",Value=addNotes.InterviewDate},
            new Parameter{Name="para_interview_time",Value=addNotes.InterviewTime},
            new Parameter{Name="para_interpreter_name",Value=addNotes.InterpreterName},
            new Parameter{Name="para_interpreter_detail",Value=addNotes.InterpreterDetail},
            new Parameter{Name="para_post_interview_date",Value=addNotes.PostInterviewDate},
            new Parameter{Name="para_post_interview_time",Value=addNotes.PostInterviewTime},
            new Parameter{Name="para_comments",Value=addNotes.NoteComments},
        };

            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, parameters, "NonQuery"));
        }

        public DataTable GetCandidateWithNotes(string employmentProjectID)
        {
            string query = "select  cand.*,time_format(note.interview_time,'%h:%i %p')as note_interview_time, ";
            query += "concat(cand.first_name,'  ',cand.last_name) as candidate_name,time_format(note.post_interview_time,'%h:%i %p')as note_post_interview_time,";
            query += "note.* from candidates cand  ";
            query += "join employment_project_candidate_notes note on cand.candidate_id=note.candidate_id where note.employment_project_id=" + employmentProjectID + "";
            query += " order by note.notes_date desc ;";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public int UpdateEmploymentProjectStatus(MySqlCommand cmd, int employmentProjectID)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "call update_employment_project_status(" + employmentProjectID + ")";
            return cmd.ExecuteNonQuery();
        }

        public DataTable GetEmploymentProjectsWithEmploymentStatus(EnableIndia.App_Code.BAL.EmploymentProjectBAL emplProj)
        {
            string query = "rpt_employment_projects_with_employment_status";

            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_project_status",Value=emplProj.ProjectStatus},
            new Parameter{Name="para_employment_project_id",Value=emplProj.EmploymentProjectID},
            new Parameter{Name="para_employment_date_start_date_from",Value=emplProj.EmploymentDateStartDateFrom},
            new Parameter{Name="para_employment_date_start_date_to",Value=emplProj.EmploymentDateStartDateTo},
            new Parameter{Name="para_employment_date_end_date_from",Value=emplProj.EmploymentDateEndDateFrom},
            new Parameter{Name="para_employment_date_end_date_to",Value=emplProj.EmploymentDateEndDateTo},
            new Parameter{Name="para_vacancy_id",Value=emplProj.VacancyID},
            new Parameter{Name="para_job_type_id",Value=emplProj.JobID},
            new Parameter{Name="para_job_role_id",Value=emplProj.JobRoleID},
            new Parameter{Name="para_group_id",Value=emplProj.GroupID},
            new Parameter{Name="para_company_id",Value=emplProj.CompanyID},
            new Parameter{Name="para_state_id",Value=emplProj.StateID},
            new Parameter{Name="para_city_id",Value=emplProj.CityID}
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameters, "DataTable");
        }

        public int GetEmploymentProjectIDFromName(string projectName)
        {
            string query = "select employment_project_id from employment_projects where  employment_project_name='" + projectName + "'";
            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public int GetCompanyIDFromName(string projectName)
        {
            string query = "select company_id from employment_projects where  employment_project_name='" + projectName + "' and is_closed=1";
            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }
    }
}