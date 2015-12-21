using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for EmploymentProjectContactDAL
    /// </summary>
    public class EmploymentProjectContactDAL
    {
        public EmploymentProjectContactDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetEmploymentProjectContacts(string employmentProjectID, string companyID)
        {
            string query = "call get_employment_project_contacts(" + employmentProjectID + "," + companyID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public void AddEmploymentProjectContact(MySqlCommand cmd, string employmentProjectID, string contactID, string contactType)
        {
            cmd.CommandText = "insert into employment_project_contacts(employment_project_id,contact_id,contact_type)values(" + employmentProjectID + ",";
            cmd.CommandText += contactID + ",'" + contactType + "')";

            cmd.ExecuteNonQuery();
        }

        public void DeleteEmploymentProjectContacts(MySqlCommand cmd, string employmentProjectID)
        {
            cmd.CommandText = "delete from employment_project_contacts where employment_project_id=" + employmentProjectID;
            cmd.ExecuteNonQuery();
        }
    }
}