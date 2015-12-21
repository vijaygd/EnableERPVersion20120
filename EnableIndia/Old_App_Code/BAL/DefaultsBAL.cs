using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for DefaultsBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class DefaultsBAL
    {
        public DefaultsBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string GetDefaultAgeGroupForSearch()
        {
            DefaultsDAL def = new DefaultsDAL();
            return def.GetDefaultAgeGroupForSearch();
        }

        public bool SetDefaultAgeGroupForSearch(string ageGroup)
        {
            DefaultsDAL def = new DefaultsDAL();
            int rowsAffected = def.SetDefaultAgeGroupForSearch(ageGroup);
            if (rowsAffected > 0)
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