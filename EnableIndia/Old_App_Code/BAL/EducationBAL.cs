using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for EducationBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class EducationBAL
    {
        public EducationBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetEducationsDataTable()
        {
            EnableIndia.App_Code.DAL.EducationDAL get = new EnableIndia.App_Code.DAL.EducationDAL();
            return get.GetEducationsDataTable();

        }

        public MySqlDataReader GetEducations()
        {
            EnableIndia.App_Code.DAL.EducationDAL get = new EnableIndia.App_Code.DAL.EducationDAL();
            return get.GetEducations();
        }

        public bool AddEducation(string courseQualificationName)
        {
            EnableIndia.App_Code.DAL.EducationDAL edu = new EnableIndia.App_Code.DAL.EducationDAL();
            int rowsAdded = edu.AddEducation(courseQualificationName);
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