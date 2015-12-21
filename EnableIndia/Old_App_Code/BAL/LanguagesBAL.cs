using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for LanguagesBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class LanguagesBAL
    {
        public LanguagesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetLanguages()
        {
            LanguagesDAL get = new LanguagesDAL();
            return get.GetLanguages();

        }
        public MySqlDataReader GetLanguagesInReader()
        {
            LanguagesDAL get = new LanguagesDAL();
            return get.GetLanguagesInReader();
        }

        public bool AddLanguage(string languageName)
        {
            LanguagesDAL lang = new LanguagesDAL();
            int rowsAdded = lang.AddLanguage(languageName);
            if (rowsAdded.Equals(0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
