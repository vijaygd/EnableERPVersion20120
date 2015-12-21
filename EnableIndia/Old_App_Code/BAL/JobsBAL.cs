using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for JobsBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class JobsBAL
    {
        public JobsBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetJobsDataTable()
        {
            EnableIndia.App_Code.DAL.JobsDAL get = new EnableIndia.App_Code.DAL.JobsDAL();
            return get.GetJobsDataTable();
        }

        public MySqlDataReader GetJobs()
        {
            EnableIndia.App_Code.DAL.JobsDAL get = new EnableIndia.App_Code.DAL.JobsDAL();
            return get.GetJobs();
        }

        public DataTable GetJobsWithJobRoles()
        {
            EnableIndia.App_Code.DAL.JobsDAL get = new EnableIndia.App_Code.DAL.JobsDAL();
            return get.GetJobsWithJobRoles();
        }

        public int AddJob(string jobName)
        {
            EnableIndia.App_Code.DAL.JobsDAL job = new EnableIndia.App_Code.DAL.JobsDAL();
            return job.AddJob(jobName);
        }
    }
}
