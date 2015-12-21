using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for JobRolesDAL
    /// </summary>
    public class JobRolesDAL
    {
        public JobRolesDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetJobRole()
        {
            string query = "select * from job_roles order by job_role_name";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }
        public MySqlDataReader GetJobRoles(string jobID)
        {
            string query = "select * from job_roles ";
            if (!jobID.Equals("-1"))
            {
                query += " where job_id=" + jobID;
            }
            query += " order by job_role_name";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataTable GetJobRolesWithJobType(string jobID)
        {
            string query = "select ";
            query += "	jrole.job_role_id,";
            query += "	jrole.job_role_name,";
            query += "	jobs.job_name ";
            query += "from job_roles jrole ";
            query += "join jobs on jrole.job_id = jobs.job_id ";
            if (!jobID.Equals("-1"))
            {
                query += "where jrole.job_id=" + jobID;
            }
            query += " order by job_name,job_role_name";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        //public DataTable GetJobRolesWithJobType(string candidateID)
        //{
        //    string query = "select ";
        //    query += "	jrole.job_role_id,";
        //    query += "	jrole.job_role_name,";
        //    query += "	jobs.job_name,";
        //    query += "	if(cand_rec_role.job_role_id is null,0,1) as is_attached ";
        //    query += "from job_roles jrole ";
        //    query += "join jobs on jrole.job_id = jobs.job_id ";
        //    query += "left join(select job_role_id ";
        //    query += "		    from candidate_recommended_roles";
        //    query += "			where candidate_id=" + candidateID + ")as cand_rec_role on jrole.job_role_id=cand_rec_role.job_role_id";

        //    DBAccess dba = new DBAccess();
        //    return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        //}

        public int AddJobRole(string jobID, string jobRoleName)
        {
            string query = "insert into job_roles(job_id,job_role_name) values(" + jobID + ",\"" + jobRoleName + "\")";
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }
    }
}