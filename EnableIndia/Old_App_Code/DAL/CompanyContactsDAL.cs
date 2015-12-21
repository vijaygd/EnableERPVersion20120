using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CompanyContactsDAL
    /// </summary>
    public class CompanyContactsDAL
    {
        public CompanyContactsDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCompanyContacts(string companyID)
        {
            string query = "select * from company_contacts where mark_deleted=0 and company_id=" + companyID;
            query += " order by contact_name";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public MySqlDataReader GetCompanyContactDetails(string contactID)
        {
            string query = "select * from company_contacts where contact_id=" + contactID;
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public int AddCompanyContact(EnableIndia.App_Code.BAL.CompanyContactsBAL contact)
        {
            string query = "add_company_contact";
            List<Parameter> parameter = new List<Parameter>
        {
            new Parameter{Name="para_company_id",Value=contact.CompanyID},
            new Parameter{Name="para_contact_name",Value=contact.ContactName},
            new Parameter{Name="para_contact_type",Value=contact.ContactType},
            new Parameter{Name="para_designation",Value=contact.Designation},
            new Parameter{Name="para_phone_number",Value=contact.PhoneNumber},
            new Parameter{Name="para_email_address",Value=contact.EmailAddress},
        };

            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, parameter, "NonQuery");
        }

        public int UpdateCompanyContact(EnableIndia.App_Code.BAL.CompanyContactsBAL contact)
        {
            string query = "update_company_contact";
            List<Parameter> parameter = new List<Parameter>
        {
            new Parameter{Name="para_contact_id",Value=contact.ContactID},
            new Parameter{Name="para_company_id",Value=contact.CompanyID},
            new Parameter{Name="para_contact_name",Value=contact.ContactName},
            new Parameter{Name="para_contact_type",Value=contact.ContactType},
            new Parameter{Name="para_designation",Value=contact.Designation},
            new Parameter{Name="para_phone_number",Value=contact.PhoneNumber},
            new Parameter{Name="para_email_address",Value=contact.EmailAddress},
        };

            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, parameter, "NonQuery");
        }

        public int DeleteCompanyContact(string contactID)
        {
            string query = "update company_contacts set mark_deleted=1 where contact_id=" + contactID;
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }
    }
}