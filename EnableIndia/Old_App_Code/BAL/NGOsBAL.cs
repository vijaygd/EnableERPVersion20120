using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for NGOsBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class NGOsBAL
    {
        public NGOsBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region NGO PROPERTIES
        public int NgoID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string OfficePhoneNumber
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public int CountryID
        {
            get;
            set;
        }

        public int StteID
        {
            get;
            set;
        }

        public int CityID
        {
            get;
            set;
        }

        public string PinCode
        {
            get;
            set;
        }

        public string Fax
        {
            get;
            set;
        }

        public string WebSite
        {
            get;
            set;
        }

        public string NgoDetails
        {
            get;
            set;
        }

        #endregion

        public int CheckForDuplicateNGO(string ngoID, string ngoName)
        {
            EnableIndia.App_Code.DAL.NGOsDAL get = new EnableIndia.App_Code.DAL.NGOsDAL();
            return get.CheckForDuplicateNGO(ngoID, ngoName);
        }

        public MySqlDataReader GetNGOs()
        {
            EnableIndia.App_Code.DAL.NGOsDAL get = new EnableIndia.App_Code.DAL.NGOsDAL();
            return get.GetNGOs();
        }

        public MySqlDataReader GetNGOs(bool includeEnableIndia)
        {
            EnableIndia.App_Code.DAL.NGOsDAL get = new EnableIndia.App_Code.DAL.NGOsDAL();
            return get.GetNGOs(includeEnableIndia);
        }

        public DataTable GetNGOList(string ngoName)
        {
            EnableIndia.App_Code.DAL.NGOsDAL get = new EnableIndia.App_Code.DAL.NGOsDAL();
            return get.GetNGOList(ngoName);
        }

        public MySqlDataReader GetNgoDetails(string ngoID)
        {
            EnableIndia.App_Code.DAL.NGOsDAL get = new EnableIndia.App_Code.DAL.NGOsDAL();
            return get.GetNgoDetails(ngoID);
        }

        public DataTable GetNGODisabilitySubTypes(string ngoID)
        {
            EnableIndia.App_Code.DAL.NGOsDAL get = new EnableIndia.App_Code.DAL.NGOsDAL();
            return get.GetNGODisabilitySubTypes(ngoID);
        }
    }
}