using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for NGOContactsDAL
    /// </summary>
    public class NGOContactsDAL
    {
        public NGOContactsDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetNGOContacts(string ngoID)
        {
            string query = "select * from ngo_contacts where ngo_id=" + ngoID + " and mark_deleted=0";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public MySqlDataReader GetNGOContactDetails(string contactID)
        {
            string query = "select * from ngo_contacts where contact_id=" + contactID;
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public int AddNGOContact(EnableIndia.App_Code.BAL.NGOContactsBAL contact)
        {
            string query = "add_ngo_contact";

            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_ngo_id",Value=contact.NgoID},
            new Parameter{Name="para_type_of_contact",Value=contact.TypeOfContact},
            new Parameter{Name="para_contact_name",Value=contact.ContactName},
            new Parameter{Name="para_designation",Value=contact.Designation},
            new Parameter{Name="para_phone_number",Value=contact.PhoneNumber},
            new Parameter{Name="para_email_address",Value=contact.EmailAddress}
        };

            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, parameters, "NonQuery");
        }

        public int UpdateNGOContact(EnableIndia.App_Code.BAL.NGOContactsBAL contact)
        {
            string query = "update_ngo_contact";

            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_contact_id",Value=contact.ContactID},
            new Parameter{Name="para_type_of_contact",Value=contact.TypeOfContact},
            new Parameter{Name="para_contact_name",Value=contact.ContactName},
            new Parameter{Name="para_designation",Value=contact.Designation},
            new Parameter{Name="para_phone_number",Value=contact.PhoneNumber},
            new Parameter{Name="para_email_address",Value=contact.EmailAddress}
        };

            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, parameters, "NonQuery");
        }

        public int DeleteNGOContact(string ngoContactID)
        {
            string query = "update ngo_contacts set mark_deleted=1 where contact_id=" + ngoContactID;
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }
    }
}