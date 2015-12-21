using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for EmploymentProjectContactBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class EmploymentProjectContactBAL
    {
        public EmploymentProjectContactBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetEmploymentProjectContacts(string employmentProjectID, string companyID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectContactDAL get = new EnableIndia.App_Code.DAL.EmploymentProjectContactDAL();
            return get.GetEmploymentProjectContacts(employmentProjectID, companyID);
        }

        public void AddEmploymentProjectContact(MySqlCommand cmd, string employmentProjectID, string contactID, string contactType)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectContactDAL cont = new EnableIndia.App_Code.DAL.EmploymentProjectContactDAL();
            cont.AddEmploymentProjectContact(cmd, employmentProjectID, contactID, contactType);
        }

        public void DeleteEmploymentProjectContacts(MySqlCommand cmd, string employmentProjectID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectContactDAL cont = new EnableIndia.App_Code.DAL.EmploymentProjectContactDAL();
            cont.DeleteEmploymentProjectContacts(cmd, employmentProjectID);
        }
    }
}
