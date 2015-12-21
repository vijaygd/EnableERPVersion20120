using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for EnableIndia.App_Code.BAL.EnableIndia.App_Code.BAL.ParentCompaniesBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class ParentCompaniesBAL
    {
        public ParentCompaniesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region PARENT COMPANY PARAMETERS
        public int ParentCompanyID
        {
            get;
            set;
        }

        public string ParentCompanyName
        {
            get;
            set;
        }
        #endregion

        public int CheckForDuplicateParentCompany(string parentcompanyID, string parentcompanyName)
        {
            EnableIndia.App_Code.DAL.ParentCompaniesDAL comp = new EnableIndia.App_Code.DAL.ParentCompaniesDAL();
            return comp.CheckForDuplicateParentCompany(parentcompanyID, parentcompanyName);
        }

        public MySqlDataReader GetParentCompanies(string parentCompanyID)
        {
            EnableIndia.App_Code.DAL.ParentCompaniesDAL get = new EnableIndia.App_Code.DAL.ParentCompaniesDAL();
            return get.GetParentCompanies(parentCompanyID);
        }


        public MySqlDataReader GetParentCompanies()
        {
            EnableIndia.App_Code.DAL.ParentCompaniesDAL get = new EnableIndia.App_Code.DAL.ParentCompaniesDAL();
            return get.GetParentCompanies();
        }

        public int AddParentCompany(string parentCompanyName)
        {
            EnableIndia.App_Code.DAL.ParentCompaniesDAL get = new EnableIndia.App_Code.DAL.ParentCompaniesDAL();
            return get.AddParentCompany(parentCompanyName);
        }

        public bool UpdateParentCompany(EnableIndia.App_Code.BAL.ParentCompaniesBAL parentComp)
        {
            EnableIndia.App_Code.DAL.ParentCompaniesDAL get = new EnableIndia.App_Code.DAL.ParentCompaniesDAL();
            int rowsUpdated = get.UpdateParentCompany(parentComp);
            if (rowsUpdated > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetParentCompaniesInReport()
        {
            EnableIndia.App_Code.DAL.ParentCompaniesDAL get = new EnableIndia.App_Code.DAL.ParentCompaniesDAL();
            return get.GetParentCompaniesInReport();
        }
    }
}