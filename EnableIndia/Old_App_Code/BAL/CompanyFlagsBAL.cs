using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for CompanyFlagsBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CompanyFlagsBAL
    {
        public CompanyFlagsBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public bool AddCompanyFlag(string flagName)
        {
            CompanyFlagsDAL flag = new CompanyFlagsDAL();
            int rowsAdded = flag.AddCompanyFlag(flagName);
            if (rowsAdded.Equals(0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public MySqlDataReader GetCompanyFlags(bool isNoAction)
        {
            CompanyFlagsDAL flag = new CompanyFlagsDAL();
            return flag.GetCompanyFlags(isNoAction);
        }

        public DataTable GetFlagwiseOpenCompanyTask()
        {
            CompanyFlagsDAL flag = new CompanyFlagsDAL();
            return flag.GetFlagwiseOpenCompanyTask();
        }
        public DataTable GetOwnerwisecompanyOpenTask()
        {
            CompanyFlagsDAL flag = new CompanyFlagsDAL();
            DataTable dt = flag.GetOwnerwisecompanyOpenTask();
            return dt;
        }
    }
}