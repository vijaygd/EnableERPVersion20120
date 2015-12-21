using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for ParentCompaniesDAL
    /// </summary>
    public class ParentCompaniesDAL
    {
        public ParentCompaniesDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int CheckForDuplicateParentCompany(string parentcompanyID, string parentcompanyName)
        {
            string query = "select count(company_id) from parent_companies where company_name=\"" + parentcompanyName + "\" ";
            if (!parentcompanyID.Equals("-2"))
            {
                query += " and company_id!=" + parentcompanyID;
            }

            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public MySqlDataReader GetParentCompanies(string parentCompanyID)
        {
            string query = "select * from parent_companies where company_id = " + parentCompanyID;
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public MySqlDataReader GetParentCompanies()
        {
            string query = "select * from parent_companies order by company_name";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public int AddParentCompany(string parentCompanyName)
        {
            string query = "insert into parent_companies(company_name) values(\"" + parentCompanyName + "\");select @@identity as company_id;";
            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public int UpdateParentCompany(EnableIndia.App_Code.BAL.ParentCompaniesBAL parentComp)
        {
            string query = "update parent_companies set company_name=\"" + parentComp.ParentCompanyName + "\" ";
            query += "where company_id=" + parentComp.ParentCompanyID;
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }
        public DataTable GetParentCompaniesInReport()
        {
            string query = "select company_name as parent_company from parent_companies order by company_name";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }
    }
}