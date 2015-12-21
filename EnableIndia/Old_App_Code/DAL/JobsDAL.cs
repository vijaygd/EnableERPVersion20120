using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for JobsDAL
    /// </summary>
    public class JobsDAL
    {
        public JobsDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetJobsDataTable()
        {
            string query = "select * from jobs order by job_name";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public MySqlDataReader GetJobs()
        {
            string query = "select * from jobs order by job_name";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataTable GetJobsWithJobRoles()
        {
            string query = "select ";
            query += "	jobs.job_name,";
            query += "	ifnull(job_roles.job_role_name,'') as job_role_name ";
            query += "from jobs ";
            query += "left join job_roles on jobs.job_id = job_roles.job_id ";
            query += "order by job_name,job_role_name ";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public int AddJob(string jobName)
        {
            string query = "insert into jobs(job_name) values(\"" + jobName + "\");select @@identity;";
            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }
    }
}