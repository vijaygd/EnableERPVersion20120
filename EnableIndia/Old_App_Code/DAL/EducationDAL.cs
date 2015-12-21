using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for EducationDAL
    /// </summary>
    public class EducationDAL
    {
        public EducationDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetEducationsDataTable()
        {
            string query = "select * from courses_qualifications order by course_qualification_name";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public MySqlDataReader GetEducations()
        {
            string query = "select * from courses_qualifications order by course_qualification_name";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public int AddEducation(string courseQualificationName)
        {
            string query = "insert into courses_qualifications(course_qualification_name) values(\"" + courseQualificationName + "\")";
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }
    }
}