using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


/// <summary>
/// Summary description for NGOContactsBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class NGOContactsBAL
    {
        public NGOContactsBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region NGO CONTACTS PROPERTIES
        public int ContactID
        {
            get;
            set;
        }

        public int NgoID
        {
            get;
            set;
        }

        public string TypeOfContact
        {
            get;
            set;
        }

        public string ContactName
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

        public DataTable GetNGOContacts(string ngoID)
        {
            NGOContactsDAL get = new NGOContactsDAL();
            DataTable dtNGOContacts = get.GetNGOContacts(ngoID);
            dtNGOContacts.Columns.Add("encrypted_contact_id");
            foreach (DataRow dr in dtNGOContacts.Rows)
            {
                dr["encrypted_contact_id"] = Global.EncryptID(Convert.ToInt32(dr["contact_id"]));
            }

            return dtNGOContacts;
        }

        public MySqlDataReader GetNGOContactDetails(string contactID)
        {
            NGOContactsDAL get = new NGOContactsDAL();
            return get.GetNGOContactDetails(contactID);
        }

        public bool AddNGOContact(NGOContactsBAL contact)
        {
            NGOContactsDAL ngo = new NGOContactsDAL();
            int rowsAffected = ngo.AddNGOContact(contact);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateNGOContact(NGOContactsBAL contact)
        {
            NGOContactsDAL ngo = new NGOContactsDAL();
            int rowsAffected = ngo.UpdateNGOContact(contact);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteNGOContact(string ngoContactID)
        {
            NGOContactsDAL delete = new NGOContactsDAL();
            int rowsDeleted = delete.DeleteNGOContact(ngoContactID);
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
