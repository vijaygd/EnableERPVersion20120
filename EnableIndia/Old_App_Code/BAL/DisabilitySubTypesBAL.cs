using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for DisabilitySubTypesBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class DisabilitySubTypesBAL
    {
        public DisabilitySubTypesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetDisabilitySubTypes(string disabilityID)
        {
            DisabilitySubTypesDAL get = new DisabilitySubTypesDAL();
            return get.GetDisabilitySubTypes(disabilityID);
        }

        public DataTable GetDisabilitySubTypesInDataTAble(string disabilityID)
        {
            DisabilitySubTypesDAL get = new DisabilitySubTypesDAL();
            return get.GetDisabilitySubTypesInDataTAble(disabilityID);
        }

        public bool AddDisabilitySubType(string disabilityID, string disabilitySubType)
        {
            DisabilitySubTypesDAL disSub = new DisabilitySubTypesDAL();
            int rowsAdded = disSub.AddDisabilitySubType(disabilityID, disabilitySubType);
            if (rowsAdded > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}