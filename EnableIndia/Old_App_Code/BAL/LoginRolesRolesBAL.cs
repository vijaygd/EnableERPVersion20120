using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


/// <summary>
/// Summary description for RolesBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class RolesBAL
    {
        public RolesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetRoles()
        {
            RolesDAL get = new RolesDAL();
            return get.GetRoles();
        }
    }
}
