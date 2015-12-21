using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for DisabilityTypesBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class DisabilityTypesBAL
    {
        public DisabilityTypesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetDisabilityTypes()
        {
            DisabilityTypesDAL get = new DisabilityTypesDAL();
            return get.GetDisabilityTypes();
        }

        public DataTable GetDisabilityTypesTable()
        {
            DisabilityTypesDAL get = new DisabilityTypesDAL();
            return get.GetDisabilityTypesTable();
        }

        public DataTable GetdisabilityTypesWithSubTypes()
        {
            DisabilityTypesDAL get = new DisabilityTypesDAL();
            return get.GetdisabilityTypesWithSubTypes();
        }

        public bool AddDisabilityType(string disabilityType)
        {
            DisabilityTypesDAL disab = new DisabilityTypesDAL();
            int rowsAdded = disab.AddDisabilityType(disabilityType);
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