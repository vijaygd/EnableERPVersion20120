using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for DefaultsDAL
    /// </summary>
    public class DefaultsDAL
    {
        public DefaultsDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string GetDefaultAgeGroupForSearch()
        {
            string query = "select value from defaults where description='default_age_group_for_search'";
            DBAccess dba = new DBAccess();
            return dba.ExecuteQuery(query, null, "Scalar").ToString();
        }

        public int SetDefaultAgeGroupForSearch(string ageGroup)
        {
            string query = "update defaults set value=\"" + ageGroup + "\" where description='default_age_group_for_search'";
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }
    }
}