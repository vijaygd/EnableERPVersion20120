using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


/// <summary>
/// Summary description for CandidateFlagsBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CandidateFlagsBAL
    {
        public CandidateFlagsBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Flag Wise Closed Candidate Work Distribution Parameters
        public string DateFrom
        {
            get;
            set;
        }
        public string DateType
        {
            get;
            set;
        }

        public string DateTo
        {
            get;
            set;
        }
        #endregion

        public MySqlDataReader GetCandidateFlags()
        {
            CandidateFlagsDAL get = new CandidateFlagsDAL();
            return get.GetCandidateFlags();
        }

        public MySqlDataReader GetCandidateFlags(bool isNoAction)
        {
            CandidateFlagsDAL get = new CandidateFlagsDAL();
            return get.GetCandidateFlags(isNoAction);
        }

        public bool AddCandidateFlag(string flagName)
        {
            EnableIndia.App_Code.DAL.CandidateFlagsDAL flag = new EnableIndia.App_Code.DAL.CandidateFlagsDAL();
            int rowsAdded = flag.AddCandidateFlag(flagName);
            if (rowsAdded.Equals(0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public DataTable GetFlagwiseOpenCandidateTask()
        {
            EnableIndia.App_Code.DAL.CandidateFlagsDAL get = new EnableIndia.App_Code.DAL.CandidateFlagsDAL();
            return get.GetFlagwiseOpenCandidateTask();
        }
        public MySqlDataReader GetRegisteredId(int candidateId)
        {
            string query = "select registration_id from  candidates where candidate_id=" + candidateId;
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }
        public DataTable GetFlagwiseClosedCandidateTask(CandidateFlagsBAL get)
        {
            EnableIndia.App_Code.DAL.CandidateFlagsDAL dlGet = new EnableIndia.App_Code.DAL.CandidateFlagsDAL();
            return dlGet.GetFlagWiseClosedCandidateTask(get);
        }
    }
}