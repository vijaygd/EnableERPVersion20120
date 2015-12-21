using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for CandidateJobProfileBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CandidateJobProfileBAL
    {
        public CandidateJobProfileBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetCandidateJobProfileDetails(string candidateID)
        {
            CandidateJobProfileDAL get = new CandidateJobProfileDAL();
            return get.GetCandidateJobProfileDetails(candidateID);
        }
        public DataTable GetCandidateRecommnededRole(string candidateID)
        {
            CandidateJobProfileDAL get = new CandidateJobProfileDAL();
            return get.GetCandidateRecommnededRole(candidateID);
        }
        public MySqlDataReader GetJobRole()
        {
            CandidateJobProfileDAL get = new CandidateJobProfileDAL();
            return get.GetJobRole();
        }
        public DataTable GetCurrentlyAssignnedEmploymentProject(string candidateID)
        {
            CandidateJobProfileDAL get = new CandidateJobProfileDAL();
            DataTable dt = get.GetCurrentlyAssignnedEmploymentProject(candidateID);
            return dt;
        }
        public int CheckCandidateAssignedForTask(string candidateID)
        {
            CandidateJobProfileDAL get = new CandidateJobProfileDAL();
            return get.CheckCandidateAssignedForTask(candidateID);
        }
    }
}