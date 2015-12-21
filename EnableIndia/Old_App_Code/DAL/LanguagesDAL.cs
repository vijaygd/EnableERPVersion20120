using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for LanguagesDAL
    /// </summary>
    public class LanguagesDAL
    {
        public LanguagesDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetLanguages()
        {
            string query = "select * from languages order by language_name ";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public MySqlDataReader GetLanguagesInReader()
        {
            string query = "select * from languages order by language_name ";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public int AddLanguage(string languageName)
        {
            string query = "insert into languages(language_name) values(\"" + languageName + "\")";
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }
    }
}