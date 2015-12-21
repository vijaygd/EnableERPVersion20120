using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CandidateJobProfileDAL
    /// </summary>
    public class CandidateJobProfileDAL
    {
        public CandidateJobProfileDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetCandidateJobProfileDetails(string candidateID)
        {
            string query = "call get_candidate_job_profile_details(" + candidateID + ",'" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataTable GetCurrentlyAssignnedEmploymentProject(string candidateID)
        {
            string query = "get_currently_assigned_employment_project_of_candidate";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_candidate_id",Value=candidateID},
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameters, "DataTable");
        }


        public DataTable GetCandidateRecommnededRole(string candidateID)
        {
            string query = "select jobs.job_id, ";
            query += "	jobs.job_name as recommended_job_name,";
            query += "	fun_get_candidate_recommended_roles(cand_jobs.candidate_id) as recommended_job_role ";
            query += "from candidate_recommended_job_types cand_jobs ";
            query += "join jobs on cand_jobs.job_id=jobs.job_id ";
            query += "where cand_jobs.candidate_id=" + candidateID;
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");

        }

        public MySqlDataReader GetJobRole()
        {
            string query = "select * from candidate_recommended_job_types  ";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public int CheckCandidateAssignedForTask(string candidateID)
        {
            string query = "select count(candidate_id) from candidate_history";
            query += " where candidate_id =" + candidateID + " and status='Open' and candidate_flag_id!=1 ";

            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }
    }
}