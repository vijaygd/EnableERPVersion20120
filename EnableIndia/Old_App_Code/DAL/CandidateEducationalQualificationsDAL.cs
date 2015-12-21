using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CandidateEducationalQualificationsDAL
    /// </summary>
    public class CandidateEducationalQualificationsDAL
    {
        public CandidateEducationalQualificationsDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCandidateEducationalQualifications(string candidateID)
        {
            string query = "select ";
            query += "	can_edu_qual.candidate_qualification_id,";
            query += "	can_edu_qual.course_qualification_id,";
            query += "	can_edu_qual.passing_year,";
            query += "	can_edu_qual.percentage,";
            query += "	can_edu_qual.details,";
            query += "  can_edu_qual.mark_deleted,";
            query += "	qual.course_qualification_name ";
            query += "from candidate_educational_qualifications can_edu_qual ";
            query += "join courses_qualifications qual on can_edu_qual.course_qualification_id = qual.course_qualification_id ";
            query += "where can_edu_qual.candidate_id=" + candidateID + "  and can_edu_qual.mark_deleted=0 ";
            query += " order by passing_year desc";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public MySqlDataReader GetCandidateEducationalQualificationDetails(string qualificationID)
        {
            string query = "select ";
            query += "	cand_edu_qual.*,";
            query += "	cand.other_educational_qualifications ";
            query += "from candidate_educational_qualifications cand_edu_qual ";
            query += "join candidates cand on cand_edu_qual.candidate_id = cand.candidate_id ";
            query += "where cand_edu_qual.candidate_qualification_id=" + qualificationID;

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public int AddCandidateEducationalQualification(EnableIndia.App_Code.BAL.CandidateEducationalQualificationsBAL candEdu, out string errorMessage)
        {
            string query = "add_canddiate_educational_qualification";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_candidate_id",Value=candEdu.CandidateID},
            new Parameter{Name="para_course_qualification_id",Value=candEdu.CourseQualificationID},
            new Parameter{Name="para_passing_year",Value=candEdu.PassingYear},
            new Parameter{Name="para_percentage",Value=candEdu.Percentage},
            new Parameter{Name="para_details",Value=candEdu.Details},
            new Parameter{Name="para_other_educational_qualifications",Value=candEdu.OtherEducationalQualification},
        };

            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteNonQueryWithTransaction(query, parameters, out errorMessage);
        }

        public int UpdateCandidateEducationalQualification(EnableIndia.App_Code.BAL.CandidateEducationalQualificationsBAL candEdu, out string errorMessage)
        {
            string query = "update_candidate_educational_qualification";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_candidate_qualification_id",Value=candEdu.CandidateQualificationID},
            new Parameter{Name="para_candidate_id",Value=candEdu.CandidateID},
            new Parameter{Name="para_course_qualification_id",Value=candEdu.CourseQualificationID},
            new Parameter{Name="para_passing_year",Value=candEdu.PassingYear},
            new Parameter{Name="para_percentage",Value=candEdu.Percentage},
            new Parameter{Name="para_details",Value=candEdu.Details},
            new Parameter{Name="para_other_educational_qualifications",Value=candEdu.OtherEducationalQualification},
        };

            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteNonQueryWithTransaction(query, parameters, out errorMessage);
        }

        public int DeleteEducationalQualifications(string qualificationID, string candidateID)
        {
            string query = "call delete_educational_qualifications(" + qualificationID + "," + candidateID + ")";
            DBAccess dba = new DBAccess();
            Global.createAuditTrial("Del Educational Qual", "", "", null, "Delete", HttpContext.Current.Session["username"].ToString());
            return (int)dba.ExecuteQuery(query, null, "NonQuery");

        }
    }
}