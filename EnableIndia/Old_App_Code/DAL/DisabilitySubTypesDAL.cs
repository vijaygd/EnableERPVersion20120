using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for DisabilitySubTypesDAL
    /// </summary>
    public class DisabilitySubTypesDAL
    {
        public DisabilitySubTypesDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetDisabilitySubTypes(string disabilityID)
        {
            string query = "select * from disability_sub_types ";

            if (!disabilityID.Equals("-1"))
            {
                query += " where disability_id=" + disabilityID;
            }
            query += " order by disability_sub_type";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataTable GetDisabilitySubTypesInDataTAble(string disabilityID)
        {
            string query = "select ";
            query += "	dis_sub.*,";
            query += "	dis.disability_type ";
            query += "from disability_sub_types dis_sub ";
            query += "join disability_types dis on dis_sub.disability_id = dis.disability_id ";

            if (!disabilityID.Equals("-1"))
            {
                query += " where dis_sub.disability_id=" + disabilityID;
            }
            query += " order by disability_type,disability_sub_type";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public int AddDisabilitySubType(string disabilityID, string disabilitySubType)
        {
            string query = "insert into disability_sub_types(disability_id,disability_sub_type) values(" + disabilityID + ",\"" + disabilitySubType + "\")";
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }
    }
}