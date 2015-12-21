using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;
/// <summary>
/// Summary description for CandidateWorkExperienceBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CandidateWorkExperienceBAL
    {
        public CandidateWorkExperienceBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region CANDIDATE WORK EXPERIENCE PARAMETERS
        public int CandidateWorkExperienceID
        {
            get;
            set;
        }

        public int CandidateID
        {
            get;
            set;
        }

        public int ParentCompanyID
        {
            get;
            set;
        }

        public int CompanyID
        {
            get;
            set;
        }

        public string UnlistedCompany
        {
            get;
            set;
        }

        public int JobRoleID
        {
            get;
            set;
        }

        public string UnlistedJobRole
        {
            get;
            set;
        }

        public string Designation
        {
            get;
            set;
        }

        public string DesignationFromDate
        {
            get;
            set;
        }

        public string DesignationToDate
        {
            get;
            set;
        }

        public int Years
        {
            get;
            set;
        }

        public decimal MonthlySalary
        {
            get;
            set;
        }
        public string ContractExpiryDate
        {
            get;
            set;
        }
        public string EmploymentProofFlag
        {
            get;
            set;
        }
        #endregion

        public DataTable GetCandidateWorkExperience(string candidateID)
        {
            CandidateWorkExperienceDAL get = new CandidateWorkExperienceDAL();

            DataTable dtCandidateWorkExperience = get.GetCandidateWorkExperience(candidateID);
            dtCandidateWorkExperience.Columns.Add("str_to_date");
            dtCandidateWorkExperience.Columns.Add("str_monthly_salary");

            foreach (DataRow dr in dtCandidateWorkExperience.Rows)
            {
                if (dr["designation_to_date"].ToString().Contains("5000"))
                {
                    dr["str_to_date"] = "Current";
                }
                else
                {
                    dr["str_to_date"] = Convert.ToDateTime(dr["designation_to_date"]).ToString("MM/yyyy");
                }

                if (Convert.ToInt32(dr["monthly_salary"]).Equals(0))
                {
                    dr["str_monthly_salary"] = "";
                }
                else
                {
                    dr["str_monthly_salary"] = Convert.ToInt32(dr["monthly_salary"]);
                }

                if (dr["experience_years"].ToString().Contains("-"))
                {
                    dr["experience_years"] = "0Y 0M";
                }
                else
                {
                    dr["experience_years"] = dr["experience_years"];
                }
            }
            return dtCandidateWorkExperience;
            //return get.GetCandidateWorkExperience(candidateID);
        }

        public MySqlDataReader GetCandidateWorkExperienceDetails(string candidateWorkExperienceID)
        {
            CandidateWorkExperienceDAL get = new CandidateWorkExperienceDAL();
            return get.GetCandidateWorkExperienceDetails(candidateWorkExperienceID);
        }

        public int AddCandidateWorkExperience(CandidateWorkExperienceBAL experience)
        {
            CandidateWorkExperienceDAL add = new CandidateWorkExperienceDAL();
            return add.AddCandidateWorkExperience(experience);
        }

        public bool UpdateCandidateWorkExperience(CandidateWorkExperienceBAL experience, out string errorMessage)
        {
            CandidateWorkExperienceDAL upd = new CandidateWorkExperienceDAL();
            int rowsUpdated = upd.UpdateCandidateWorkExperience(experience, out errorMessage);
            if (rowsUpdated > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteWorkExperience(string workExperienceID, string candidateID, out string errorMessage)
        {
            CandidateWorkExperienceDAL work = new CandidateWorkExperienceDAL();
            int isDeleted = work.DeleteWorkExperience(workExperienceID, candidateID, out errorMessage);
            if (isDeleted > 0)
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
