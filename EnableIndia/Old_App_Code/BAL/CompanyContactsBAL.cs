using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for CompanyContactsBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CompanyContactsBAL
    {
        public CompanyContactsBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region COMPANY CONTACTS PARAMETERS
        public int ContactID
        {
            get;
            set;
        }

        public int CompanyID
        {
            get;
            set;
        }

        public string ContactName
        {
            get;
            set;
        }

        public string ContactType
        {
            get;
            set;
        }

        public string Designation
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public string EmailAddress
        {
            get;
            set;
        }
        #endregion

        public DataTable GetCompanyContacts(string companyID)
        {
            CompanyContactsDAL get = new CompanyContactsDAL();
            return get.GetCompanyContacts(companyID);
        }

        public MySqlDataReader GetCompanyContactDetails(string contactID)
        {
            CompanyContactsDAL get = new CompanyContactsDAL();
            return get.GetCompanyContactDetails(contactID);
        }

        public bool AddCompanyContact(CompanyContactsBAL contact)
        {
            CompanyContactsDAL add = new CompanyContactsDAL();
            int rowsAdded = add.AddCompanyContact(contact);
            if (rowsAdded > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCompanyContact(CompanyContactsBAL contact)
        {
            CompanyContactsDAL update = new CompanyContactsDAL();
            int rowsUpdated = update.UpdateCompanyContact(contact);
            if (rowsUpdated > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCompanyContact(string contactID)
        {
            CompanyContactsDAL del = new CompanyContactsDAL();
            int rowsDeleted = del.DeleteCompanyContact(contactID);
            if (rowsDeleted > 0)
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