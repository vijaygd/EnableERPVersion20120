using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CountriesDAL
    /// </summary>
    public class CountriesDAL
    {
        public CountriesDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetCountries()
        {
            string query = "select * from countries order by country_name";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataTable GetCountriesWithStates()
        {
            string query = "select ";
            query += "	cntr.country_name,";
            query += "	ifnull(st.state_name,'') as state_name ";
            query += "from countries cntr ";
            query += "left join states st on cntr.country_id = st.country_id ";
            query += "order by country_name,state_name ";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public int AddCountry(string countryName)
        {
            string query = "insert into countries(country_name) values(\"" + countryName + "\")";
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }
    }
}