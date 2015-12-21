using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CandidateWorkExperienceDAL
    /// </summary>
    public class CandidateWorkExperienceDAL
    {
        public CandidateWorkExperienceDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCandidateWorkExperience(string candidateID)
        {
            string query = "call get_candidate_experience(" + candidateID + ",'" + DateTime.Now.ToString("yyyy/MM/dd") + "')";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public MySqlDataReader GetCandidateWorkExperienceDetails(string candidateWorkExperienceID)
        {
            string query = "select cand_work_exp.*,cand.contract_expiry_date from candidate_work_experience ";
            query += "cand_work_exp join candidates cand on cand_work_exp.candidate_id = cand.candidate_id ";
            query += " where candidate_work_experience_id=" + candidateWorkExperienceID;
            query += " and mark_deleted=0 ";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public int AddCandidateWorkExperience(EnableIndia.App_Code.BAL.CandidateWorkExperienceBAL experience)
        {
            string query = "add_candidate_work_experience";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_candidate_id",Value=experience.CandidateID},
            new Parameter{Name="para_parent_company_id",Value=experience.ParentCompanyID},
            new Parameter{Name="para_company_id",Value=experience.CompanyID},
            new Parameter{Name="para_unlisted_company",Value=experience.UnlistedCompany},
            new Parameter{Name="para_job_role_id",Value=experience.JobRoleID},
            new Parameter{Name="para_unlisted_job_role",Value=experience.UnlistedJobRole},
            new Parameter{Name="para_designation",Value=experience.Designation},
            new Parameter{Name="para_designation_from_date",Value=experience.DesignationFromDate},
            new Parameter{Name="para_designation_to_date",Value=experience.DesignationToDate},
            new Parameter{Name="para_monthly_salary",Value=experience.MonthlySalary},
            new Parameter{Name="para_contract_expiry_date",Value=experience.ContractExpiryDate},
            new Parameter{Name="para_work_experience_proof", Value=experience.EmploymentProofFlag}
        };

            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, parameters, "Scalar"));
        }

        public int UpdateCandidateWorkExperience(EnableIndia.App_Code.BAL.CandidateWorkExperienceBAL experience, out string errorMessage)
        {
            errorMessage = String.Empty;
            string query = "update_candidate_work_experience";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_candidate_id",Value=experience.CandidateID},
            new Parameter{Name="para_candidate_work_experience_id",Value=experience.CandidateWorkExperienceID},
            new Parameter{Name="para_parent_company_id",Value=experience.ParentCompanyID},
            new Parameter{Name="para_company_id",Value=experience.CompanyID},
            new Parameter{Name="para_unlisted_company",Value=experience.UnlistedCompany},
            new Parameter{Name="para_job_role_id",Value=experience.JobRoleID},
            new Parameter{Name="para_unlisted_job_role",Value=experience.UnlistedJobRole},
            new Parameter{Name="para_designation",Value=experience.Designation},
            new Parameter{Name="para_designation_from_date",Value=experience.DesignationFromDate},
            new Parameter{Name="para_designation_to_date",Value=experience.DesignationToDate},
            //new Parameter{Name="para_years",Value=experience.Years},
            new Parameter{Name="para_monthly_salary",Value=experience.MonthlySalary},
            new Parameter{Name="para_contract_expiry_date",Value=experience.ContractExpiryDate},
            new Parameter{Name="para_work_experience_proof", Value=experience.EmploymentProofFlag}
        };

            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteNonQueryWithTransaction(query, parameters, out errorMessage);
        }

        public int DeleteWorkExperience(string workExperienceID, string candidateID, out string errorMessage)
        {
            errorMessage = String.Empty;
            string query = "call delete_candidate_work_experience(" + candidateID + "," + workExperienceID + ")";
            DBAccess dba = new DBAccess();
            Global.createAuditTrial("Del Work Experience", "", "", null, "Delete", HttpContext.Current.Session["username"].ToString());
            return (int)dba.ExecuteNonQueryWithTransaction(query, null, out errorMessage);
        }
    }
}