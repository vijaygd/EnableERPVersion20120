using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for TrainingProgramDAL
    /// </summary>
    public class TrainingProgramDAL
    {
        public TrainingProgramDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region GET FUNCTIONS

        public int CheckDuplicationProgramName(string trainingProgramName, string trainingProgramID)
        {
            string query = "select count(training_program_id) from training_programs";
            query += " where training_program_name =\"" + trainingProgramName + "\" ";
            if (!trainingProgramID.Equals("-2"))
            {
                query += " and training_program_id!=" + trainingProgramID;
            }

            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public DataTable GetTraningProgram()
        {
            string query = "select * from training_programs  order by training_program_name";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public MySqlDataReader GetTrainingProgramDetails(string trainingProgramID)
        {
            string query = "select * from training_programs ";
            if (!trainingProgramID.Equals("-1"))
            {
                query += " where training_program_id=" + trainingProgramID;
            }
            query += " order by training_program_name";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataTable GetTrainingProgramEligibleDisabilities(string trainingProgramID)
        {
            string query = "call get_training_program_eligible_disabilities(" + trainingProgramID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetTrainingProgramEligibleJobs(string trainingProgramID)
        {
            string query = "call get_training_program_eligible_jobs(" + trainingProgramID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetTrainingProgramEligibleCandidateGroups(string trainingProgramID)
        {
            string query = "call get_training_program_eligible_candidate_groups(" + trainingProgramID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetTrainingProgramEligibleQualifications(string trainingProgramID)
        {
            string query = "call get_training_program_eligible_qualifications(" + trainingProgramID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetTrainingProgramRecommendedRoles(string trainingProgramID)
        {
            string query = "call get_training_program_recommended_job_roles(" + trainingProgramID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetTrainingProgramRequiredLanguages(string trainingProgramID)
        {
            string query = "call get_training_program_languages(" + trainingProgramID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetTrainingProgramRequiredForTrainingPrograms(string trainingProgramID)
        {
            string query = "call get_training_programs_required_training_programs(" + trainingProgramID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }
        #endregion

        public string AddTrainingProgram(MySqlCommand cmd, string trainingProgramName, string comments)
        {
            cmd.CommandText = "insert into training_programs(training_program_name,comments)values(\"" + trainingProgramName + "\",\"";
            cmd.CommandText += comments + "\");select @@identity;";

            return cmd.ExecuteScalar().ToString();
        }

        public void UpdateTrainingProgram(MySqlCommand cmd, string trainingProgramName, string comments, string trainingProgramID)
        {
            cmd.CommandText = "update training_programs set training_program_name=\"" + trainingProgramName + "\",comments=\"";
            cmd.CommandText += comments + "\" where training_program_id=" + trainingProgramID;

            cmd.ExecuteNonQuery();
        }

        #region UPDATE FUNCTIONS
        public void UpdateTrainingProgramEligibleDisabilities(MySqlCommand cmd, string trainingProgramID, string disabilityID)
        {
            cmd.CommandText = "insert into training_program_eligible_disabilities(training_program_id,disability_id)values(";
            cmd.CommandText += trainingProgramID + "," + disabilityID + ")";

            cmd.ExecuteNonQuery();
        }

        public void UpdateTrainingProgramEligibleJobs(MySqlCommand cmd, string trainingProgramID, string jobID)
        {
            cmd.CommandText = "insert into training_program_eligible_jobs(training_program_id,job_id)values(";
            cmd.CommandText += trainingProgramID + "," + jobID + ")";

            cmd.ExecuteNonQuery();
        }

        public void UpdateTrainingProgramEligibleCandidateGroups(MySqlCommand cmd, string trainingProgramID, string groupID)
        {
            cmd.CommandText = "insert into training_program_eligible_candidate_groups(training_program_id,group_id)values(";
            cmd.CommandText += trainingProgramID + "," + groupID + ")";

            cmd.ExecuteNonQuery();
        }

        public void UpdateTrainingProgramEligibleQualifications(MySqlCommand cmd, string trainingProgramID, string qualificationID)
        {
            cmd.CommandText = "insert into training_program_eligible_qualifications(training_program_id,course_qualification_id)values(";
            cmd.CommandText += trainingProgramID + "," + qualificationID + ")";

            cmd.ExecuteNonQuery();
        }

        public void UpdateTrainingProgramRecommendedRoles(MySqlCommand cmd, string trainingProgramID, string jobRoleID)
        {
            cmd.CommandText = "insert into training_program_recommended_job_roles(training_program_id,job_role_id)values(";
            cmd.CommandText += trainingProgramID + "," + jobRoleID + ")";

            cmd.ExecuteNonQuery();
        }

        public void UpdateTrainingProgramRequiredLanguages(MySqlCommand cmd, string trainingProgramID, string languageID)
        {
            cmd.CommandText = "insert into training_program_required_languages(training_program_id,language_id)values(";
            cmd.CommandText += trainingProgramID + "," + languageID + ")";

            cmd.ExecuteNonQuery();
        }

        public void UpdateTrainingProgramRequiredForTrainingPrograms(MySqlCommand cmd, string trainingProgramID, string requiredTrainingProgramID)
        {
            cmd.CommandText = "insert into training_programs_required_training_programs(training_program_id,required_training_program_id)values(";
            cmd.CommandText += trainingProgramID + "," + requiredTrainingProgramID + ")";

            cmd.ExecuteNonQuery();
        }
        #endregion

        #region DELETE FUNCTIONS
        public void DeleteTrainingProgramEligibleDisabilities(MySqlCommand cmd, string trainingProgramID)
        {
            cmd.CommandText = "delete from training_program_eligible_disabilities where training_program_id=" + trainingProgramID;
            cmd.ExecuteNonQuery();
        }

        public void DeleteTrainingProgramEligibleJobs(MySqlCommand cmd, string trainingProgramID)
        {
            cmd.CommandText = "delete from training_program_eligible_jobs where training_program_id=" + trainingProgramID;
            cmd.ExecuteNonQuery();
        }

        public void DeleteTrainingProgramEligibleCandidateGroups(MySqlCommand cmd, string trainingProgramID)
        {
            cmd.CommandText = "delete from training_program_eligible_candidate_groups where training_program_id=" + trainingProgramID;
            cmd.ExecuteNonQuery();
        }

        public void DeleteTrainingProgramEligibleQualifications(MySqlCommand cmd, string trainingProgramID)
        {
            cmd.CommandText = "delete from training_program_eligible_qualifications where training_program_id=" + trainingProgramID;
            cmd.ExecuteNonQuery();
        }

        public void DeleteTrainingProgramRecommendedRoles(MySqlCommand cmd, string trainingProgramID)
        {
            cmd.CommandText = "delete from training_program_recommended_job_roles where training_program_id=" + trainingProgramID;
            cmd.ExecuteNonQuery();
        }

        public void DeleteTrainingProgramRequiredLanguages(MySqlCommand cmd, string trainingProgramID)
        {
            cmd.CommandText = "delete from training_program_required_languages where training_program_id=" + trainingProgramID;
            cmd.ExecuteNonQuery();
        }

        public void DeleteTrainingProgramRequiredForTrainingPrograms(MySqlCommand cmd, string trainingProgramID)
        {
            cmd.CommandText = "delete from training_programs_required_training_programs where training_program_id=" + trainingProgramID;
            cmd.ExecuteNonQuery();
        }
        #endregion


        public DataTable GetTrainingProgramsReports()
        {
            string query = "call rpt_get_training_programs()";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }
    }
}