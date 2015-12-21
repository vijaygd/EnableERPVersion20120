using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CandidateFlagsDAL
    /// </summary>
    public class CandidateFlagsDAL
    {
        public CandidateFlagsDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetCandidateFlags()
        {
            string query = "select * from candidate_flags order by flag_name";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        //code for remove NO Action Required value in dropdown
        public MySqlDataReader GetCandidateFlags(bool isNoAction)
        {
            string query = "select * from candidate_flags ";
            if (isNoAction == true)
            {
                query += " where flag_id>1 ";
            }
            query += "order by flag_name";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public int AddCandidateFlag(string flagName)
        {
            string query = "insert into candidate_flags(flag_name) values(\"" + flagName + "\")";
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }

        public DataTable GetFlagwiseOpenCandidateTask()
        {
            string query = "call rpt_open_candidate_flagwise_work_distribution()";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetFlagWiseClosedCandidateTask(EnableIndia.App_Code.BAL.CandidateFlagsBAL get)
        {
            string query = "rpt_closed_candidate_flagwise_work_distribution";

            List<Parameter> parameter = new List<Parameter>
        {
            new Parameter{Name="para_date_type",Value=get.DateType},
            new Parameter{Name="para_date_from",Value=get.DateFrom},
            new Parameter{Name="para_date_to",Value=get.DateTo}
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameter, "DataTable");
        }
    }
}