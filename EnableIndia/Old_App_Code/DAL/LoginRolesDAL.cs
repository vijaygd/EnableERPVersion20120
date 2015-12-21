using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for RolesDAL
    /// </summary>
    public class RolesDAL
    {
        public RolesDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetRoles()
        {
            string query = "select * from roles order by role_name";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }
    }
}