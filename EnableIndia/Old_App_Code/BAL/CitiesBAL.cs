using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for CitiesBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CitiesBAL
    {
        public CitiesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetCities(string stateID)
        {
            CitiesDAL city = new CitiesDAL();
            return city.GetCities(stateID);
        }

        public DataTable GetCitiesWithCountriesAndStates(string stateID)
        {
            CitiesDAL get = new CitiesDAL();
            return get.GetCitiesWithCountriesAndStates(stateID);
        }

        public bool AddCity(string stateID, string cityName)
        {
            CitiesDAL city = new CitiesDAL();
            int rowsAdded = city.AddCity(stateID, cityName);
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