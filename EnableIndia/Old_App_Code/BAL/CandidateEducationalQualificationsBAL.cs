using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


/// <summary>
/// Summary description for CandidateEducationalQualificationsBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CandidateEducationalQualificationsBAL
    {
        public CandidateEducationalQualificationsBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region CANDIDATE EDUCATIONAL QUALIFICATIONS
        public int CandidateQualificationID
        {
            get;
            set;
        }

        public int CandidateID
        {
            get;
            set;
        }

        public int CourseQualificationID
        {
            get;
            set;
        }

        public int PassingYear
        {
            get;
            set;
        }

        public decimal Percentage
        {
            get;
            set;
        }

        public string Details
        {
            get;
            set;
        }

        public string OtherEducationalQualification
        {
            get;
            set;
        }
        #endregion

        public DataTable GetCandidateEducationalQualifications(string candidateID)
        {
            CandidateEducationalQualificationsDAL get = new CandidateEducationalQualificationsDAL();
            DataTable dtCandidateEducationalQualifications = get.GetCandidateEducationalQualifications(candidateID);
            if (dtCandidateEducationalQualifications != null)
            {
                dtCandidateEducationalQualifications.Columns.Add("str_percentage");
                foreach (DataRow dr in dtCandidateEducationalQualifications.Rows)
                {
                    if (dr["percentage"].ToString().Equals("0.00"))
                    {
                        dr["str_percentage"] = "";
                    }
                    else
                    {
                        dr["str_percentage"] = dr["percentage"].ToString();
                    }
                }
            }
            return dtCandidateEducationalQualifications;
        }

        public MySqlDataReader GetCandidateEducationalQualificationDetails(string qualificationID)
        {
            CandidateEducationalQualificationsDAL get = new CandidateEducationalQualificationsDAL();
            return get.GetCandidateEducationalQualificationDetails(qualificationID);
        }

        public int AddCandidateEducationalQualification(CandidateEducationalQualificationsBAL candEdu, out string errorMessage)
        {
            CandidateEducationalQualificationsDAL get = new CandidateEducationalQualificationsDAL();
            return get.AddCandidateEducationalQualification(candEdu, out errorMessage);
        }

        public int UpdateCandidateEducationalQualification(CandidateEducationalQualificationsBAL candEdu, out string errorMessage)
        {
            CandidateEducationalQualificationsDAL get = new CandidateEducationalQualificationsDAL();
            return get.UpdateCandidateEducationalQualification(candEdu, out errorMessage);
        }
        public bool DeleteEducationalQualifications(string qualificationID, string candidateID)
        {
            CandidateEducationalQualificationsDAL education = new CandidateEducationalQualificationsDAL();
            int rowDeleted = education.DeleteEducationalQualifications(qualificationID, candidateID);
            if (rowDeleted > 0)
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