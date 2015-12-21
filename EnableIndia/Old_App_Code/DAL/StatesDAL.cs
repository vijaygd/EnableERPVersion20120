using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for StatesDAL
    /// </summary>
    public class StatesDAL
    {
        public StatesDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetStates(string countryID)
        {
            string query = "select * from states ";
            if (!countryID.Equals("-1"))
            {
                query += " where country_id=" + countryID;
            }
            query += " order by state_name";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataTable GetStatesWithCountry(string countryID)
        {
            string query = "select ";
            query += "st.*,";
            query += "cntr.country_name ";
            query += "from states st ";
            query += "join countries cntr on st.country_id=cntr.country_id ";
            if (!countryID.Equals("-1"))
            {
                query += "where st.country_id=" + countryID;
            }
            query += " order by country_name,state_name";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetStatesWithCities()
        {
            string query = "select ";
            query += "  cntr.country_name,";
            query += "	ifnull(st.state_name,'')as state_name,";
            query += "	ifnull(city.city_name,'') as city_name ";
            query += "from countries cntr  ";
            query += "left join states st  on cntr.country_id = st.country_id ";
            query += "left join cities city on st.state_id = city.state_id ";
            query += "order by country_name,state_name,city_name ";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public int AddState(string counrtyID, string stateName)
        {
            string query = "insert into states(country_id,state_name) values(" + counrtyID + ",\"" + stateName + "\")";
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }
    }
}