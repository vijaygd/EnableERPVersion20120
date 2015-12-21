using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for JobRolesBAL
/// </summary>
///
namespace EnableIndia.App_Code.BAL
{
    public class JobRolesBAL
    {
        public JobRolesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetJobRole()
        {
            EnableIndia.App_Code.DAL.JobRolesDAL get = new EnableIndia.App_Code.DAL.JobRolesDAL();
            return get.GetJobRole();

        }
        public MySqlDataReader GetJobRoles(string jobID)
        {
            EnableIndia.App_Code.DAL.JobRolesDAL get = new EnableIndia.App_Code.DAL.JobRolesDAL();
            return get.GetJobRoles(jobID);
        }

        public DataTable GetJobRolesWithJobType(string jobID)
        {
            EnableIndia.App_Code.DAL.JobRolesDAL get = new EnableIndia.App_Code.DAL.JobRolesDAL();
            return get.GetJobRolesWithJobType(jobID);
        }

        public bool AddJobRole(string jobID, string jobRoleName)
        {
            EnableIndia.App_Code.DAL.JobRolesDAL jobRole = new EnableIndia.App_Code.DAL.JobRolesDAL();
            int rowsAdded = jobRole.AddJobRole(jobID, jobRoleName);
            if (rowsAdded.Equals(0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}