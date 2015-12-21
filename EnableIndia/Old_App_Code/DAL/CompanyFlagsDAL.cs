using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CompanyFlagsDAL
    /// </summary>
    public class CompanyFlagsDAL
    {
        public CompanyFlagsDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int AddCompanyFlag(string flagName)
        {
            string query = "insert into company_flags(flag_name) values(\"" + flagName + "\")";
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }

        public MySqlDataReader GetCompanyFlags(bool isNoAction)
        {
            string query = "select * from company_flags ";
            if (isNoAction == true)
            {
                query += " where flag_id>1 ";
            }
            query += "order by flag_name";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }



        public DataTable GetFlagwiseOpenCompanyTask()
        {
            string query = "call rpt_flagwise_open_company_task()";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetOwnerwisecompanyOpenTask()
        {
            string query = "call rpt_ownerwise_company_open_task()";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

    }
}