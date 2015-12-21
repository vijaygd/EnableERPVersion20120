using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for CandidateRecommendedRolesBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CandidateRecommendedRolesBAL
    {
        public CandidateRecommendedRolesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCandidateRecommendedRoles(string candidateID, string jobID)
        {
            CandidateRecommendedRolesDAL get = new CandidateRecommendedRolesDAL();
            return get.GetCandidateRecommendedRoles(candidateID, jobID);
        }

        public DataTable GetCandidateRecommendedRolesByJob(string candidateID)
        {
            CandidateRecommendedRolesDAL get = new CandidateRecommendedRolesDAL();
            return get.GetCandidateRecommendedRolesByJob(candidateID);
        }

        public int DeleteRecommendedJobType(string candidateID, string jobID, out string errorMessage)
        {
            CandidateRecommendedRolesDAL job = new CandidateRecommendedRolesDAL();
            return job.DeleteRecommendedJobType(candidateID, jobID, out errorMessage);
        }
    }
}