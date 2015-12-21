using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for NGOsDAL
    /// </summary>
    public class NGOsDAL
    {
        public NGOsDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int CheckForDuplicateNGO(string ngoID, string ngoName)
        {
            string query = "select count(ngo_id) from ngos where ngo_name=\"" + ngoName + "\"";
            if (!ngoID.Equals("-2"))
            {
                query += " and ngo_id!=" + ngoID;
            }
            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public MySqlDataReader GetNGOs()
        {
            string query = "select ngo_id,ngo_name from ngos where ngo_id>1 order by ngo_name";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public MySqlDataReader GetNGOs(bool includeEnableIndia)
        {
            string query = "select ngo_id,ngo_name from ngos ";
            if (includeEnableIndia == false)
            {
                query += "where ngo_id>1 ";
            }
            query += "order by ngo_name";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        /*public DataTable GetNGOList(string ngoName)
        {
            string query = "select ng.ngo_id,ng.ngo_name,city.city_name from ngos ng";
            query += " join cities city on ng.city_id=city.city_id";
            query += " where ngo_id>1";
            query += " order by ngo_name";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }*/

        public DataTable GetNGOList(string ngoName)
        {
            string query = "CALL search_ngo_name(\"" + ngoName + "\")";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public MySqlDataReader GetNgoDetails(string ngoID)
        {
            string query = "select * from ngos where ngo_id=" + ngoID;
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataTable GetNGODisabilitySubTypes(string ngoID)
        {
            string query = "select ";
            query += "	dis_sub.disability_sub_type_id,";
            query += "	dis_sub.disability_sub_type,";
            query += "  dis.disability_id,";
            query += "  dis.disability_type,";
            query += "	if(ngo_dis_sub.disability_sub_type_id is null,0,1) as is_attached ";
            query += "from disability_sub_types dis_sub ";
            query += "join disability_types dis on dis_sub.disability_id=dis.disability_id ";
            query += "left join(select * from ngo_disability_sub_types ";
            query += "					where ngo_id=" + ngoID + ") as ngo_dis_sub on dis_sub.disability_sub_type_id = ngo_dis_sub.disability_sub_type_id ";

            query += " order by disability_type,disability_sub_type ";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }
    }
}