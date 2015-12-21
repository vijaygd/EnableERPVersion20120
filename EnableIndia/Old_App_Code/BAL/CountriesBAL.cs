using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for CountriesBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CountriesBAL
    {
        public CountriesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetCountries()
        {
            CountriesDAL get = new CountriesDAL();
            return get.GetCountries();
        }

        public DataTable GetCountriesWithStates()
        {
            CountriesDAL get = new CountriesDAL();
            return get.GetCountriesWithStates();
        }

        public bool AddCountry(string countryName)
        {
            CountriesDAL countr = new CountriesDAL();
            int rowsAdded = countr.AddCountry(countryName);
            if (rowsAdded.Equals(0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}