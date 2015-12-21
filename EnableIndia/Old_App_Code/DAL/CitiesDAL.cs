using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CitiesDAL
    /// </summary>
    public class CitiesDAL
    {
        public CitiesDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetCities(string stateID)
        {
            string query = "select * from cities ";
            if (!stateID.Equals("-1"))
            {
                query += "where state_id=" + stateID;
            }
            query += " order by city_name";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataTable GetCitiesWithCountriesAndStates(string stateID)
        {
            string query = "select ";
            query += "	cntr.country_name,";
            query += "	st.state_name,";
            query += "	city.* ";
            query += "from cities city ";
            query += "join states st on st.state_id=city.state_id ";
            query += "join countries cntr on st.country_id=cntr.country_id ";
            if (!stateID.Equals("-1"))
            {
                query += "where city.state_id=" + stateID;
            }
            query += " order by country_name,state_name,city_name";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public int AddCity(string stateID, string cityName)
        {
            string query = "insert into cities(state_id,city_name) values(" + stateID + ",\"" + cityName + "\")";
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }
    }
}