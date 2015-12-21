using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for DisabilityTypesDAL
    /// </summary>
    public class DisabilityTypesDAL
    {
        public DisabilityTypesDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetDisabilityTypes()
        {
            string query = "select * from disability_types order by disability_type";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataTable GetDisabilityTypesTable()
        {
            string query = "select * from disability_types order by disability_type";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetdisabilityTypesWithSubTypes()
        {
            string query = "select ";
            query += "	disab.disability_type,";
            query += "	ifnull(disab_sub.disability_sub_type,'') as disability_sub_type ";
            query += "from disability_types disab ";
            query += "left join disability_sub_types disab_sub on disab.disability_id = disab_sub.disability_id ";
            query += "order by disability_type,disability_sub_type";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public int AddDisabilityType(string disabilityType)
        {
            string query = "insert into disability_types(disability_type) values(\"" + disabilityType + "\")";
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }
    }
}