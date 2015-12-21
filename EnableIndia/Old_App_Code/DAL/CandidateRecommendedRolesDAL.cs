using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CandidateRecommendedRolesDAL
    /// </summary>
    public class CandidateRecommendedRolesDAL
    {
        public CandidateRecommendedRolesDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCandidateRecommendedRoles(string candidateID, string jobID)
        {
            string query = "select ";
            query += "  jrole.job_id,";
            query += "	jrole.job_role_id,";
            query += "	jrole.job_role_name,";
            query += "  jobs.job_name,";
            query += "	if(cand_rec_role.job_role_id is null,0,1) as is_attached ";
            query += "from job_roles jrole ";
            query += "join jobs on jrole.job_id = jobs.job_id ";
            query += "left join(select job_role_id ";
            query += "			from candidate_recommended_roles ";
            query += "			where candidate_id=" + candidateID + " and job_id=" + jobID;
            query += "		    )as cand_rec_role on jrole.job_role_id=cand_rec_role.job_role_id ";
            if (!jobID.Equals("-1"))
            {
                query += " and jrole.job_id=" + jobID;
            }
            query += " order by job_role_name";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetCandidateRecommendedRolesByJob(string candidateID)
        {
            string query = "select ";
            query += "	jobs.job_id,";
            query += "	jobs.job_name as recommended_job_name,";
            query += "	get_candidate_recommended_roles_by_job_type(cand_rec_jobs.candidate_id,cand_rec_jobs.job_id)as recommended_job_roles ";
            query += "from candidate_recommended_job_types cand_rec_jobs ";
            query += "join jobs on cand_rec_jobs.job_id=jobs.job_id ";
            query += "where cand_rec_jobs.candidate_id=" + candidateID;
            query += " order by job_name";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public int DeleteRecommendedJobType(string candidateID, string jobID, out string errorMessage)
        {
            string query = "call delete_candidate_recommended_job_type(" + candidateID + "," + jobID + ")";
            DBAccess dba = new DBAccess();
            Global.createAuditTrial("Del Reco Job Role", "", "", null, "Delete", HttpContext.Current.Session["username"].ToString());
            return (int)dba.ExecuteNonQueryWithTransaction(query, null, out errorMessage);
        }
    }
}