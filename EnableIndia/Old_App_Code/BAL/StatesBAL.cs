using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for StatesBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class StatesBAL
    {
        public StatesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetStates(string countryID)
        {
            StatesDAL get = new StatesDAL();
            return get.GetStates(countryID);
        }

        public DataTable GetStatesWithCountry(string countryID)
        {
            StatesDAL get = new StatesDAL();
            return get.GetStatesWithCountry(countryID);
        }

        public DataTable GetStatesWithCities()
        {
            StatesDAL get = new StatesDAL();
            return get.GetStatesWithCities();
        }

        public bool AddState(string counrtyID, string stateName)
        {
            StatesDAL state = new StatesDAL();
            int rowsAdded = state.AddState(counrtyID, stateName);
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
