using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CandidatesDAL
    /// </summary>
    public class CandidatesDAL
    {
        public int GetCandidateID(string rid)
        {
            string query = "select candidate_id from candidates";
            if (!rid.Equals(""))
            {
                query += " where registration_id='" + rid + "'";
            }
            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public DataTable GetRegistrationIDForFormPrinting(string candidateID)
        {
            string query = "select * from candidates where candidate_id ";
            query += "IN (" + candidateID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public string GetRIDForCandidate(bool isEnableIndiaCandidate)
        {
            string query = "select fun_get_rid_for_candidate(" + isEnableIndiaCandidate + ")";
            DBAccess dba = new DBAccess();
            return dba.ExecuteQuery(query, null, "Scalar").ToString();
        }

        public MySqlDataReader GetCandidateDetails(string candidateID)
        {
            string query = "call get_candidate_details(" + candidateID + ",'" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataTable GetUnregisteredCandidates()
        {
            string query = "select ";
            query += "	cand.candidate_id,";
            query += "	cand.registration_id,";
            query += "  cand.ngo_id,";
            query += "	if(cand.ngo_id=1,ngo.ngo_name,'Other NGO')as ngo_name ";
            query += "from candidates cand ";
            query += "left join ngos ngo on cand.ngo_id=ngo.ngo_id ";
            query += "where cand.is_registration_completed=0 ";
            query += "order by registration_id limit 500";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetListOfCandidates(string employmentStatus)
        {
            string query = "call get_list_of_candidates(" + employmentStatus + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public string CreateUnregisteredCandidates(string numberOfForms, string candidateNgoID, out string errorMessage)
        {
            string query = "create_unregistered_candidates";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_created_candidates",Value="*",Direction="Output"},
            new Parameter{Name="para_number_of_forms",Value=numberOfForms},
            new Parameter{Name="para_candidate_ngo",Value=candidateNgoID}
        };
            DBAccess dba = new DBAccess();
            return dba.ExecuteNonQueryWithTransaction(query, parameters, out errorMessage).ToString();
            
        }

        public int CreateRegisteredCandidate(EnableIndia.App_Code.BAL.CandidatesBAL cand)
        {
            string query = "create_registered_candidate";

            List<Parameter> parameter = new List<Parameter>
        {
            new Parameter{Name="para_candidate_id",Value=0,Direction="Output"},
            new Parameter{Name="para_ngo_id",Value=cand.NgoID},
            new Parameter{Name="para_candidate_number_at_ngo",Value=cand.CandidateNumberAtNGO},
            new Parameter{Name="para_file_number",Value=cand.FileNumber},
            new Parameter{Name="para_registration_date",Value=cand.RegistrationDate},

            new Parameter{Name="para_first_name",Value=cand.FirstName},
            new Parameter{Name="para_middle_name",Value=cand.MiddleName},
            new Parameter{Name="para_last_name",Value=cand.LastName},

            new Parameter{Name="para_disability_id",Value=cand.DisabilityID},
            new Parameter{Name="para_disability_sub_type_id",Value=cand.DisabilitySubTypeID},
            new Parameter{Name="para_date_of_birth",Value=cand.DateOfBirth},

            new Parameter{Name="para_primary_phone_number",Value=cand.PrimaryPhoneNumber},
            new Parameter{Name="para_is_last_reachable_on_primary_phone_number",Value=cand.IsLastReachableOnPrimaryPhoneNumber},

            new Parameter{Name="para_secondary_phone_number",Value=cand.SecondaryPhoneNumber},
            new Parameter{Name="para_is_last_reachable_on_secondary_phone_number",Value=cand.IsLastReachableOnSecondaryPhoneNumber},

            new Parameter{Name="para_present_address",Value=cand.PresentAddress},
            new Parameter{Name="para_is_last_reachable_on_present_address",Value=cand.IsLastReachableOnPresentAddress},
            new Parameter{Name="para_present_address_state_id",Value=cand.PresentAddressStateID},
            new Parameter{Name="para_present_address_city_id",Value=cand.PresentAddressCityID},
            new Parameter{Name="para_present_address_pin_code",Value=cand.PresentAddressPinCode},

            new Parameter{Name="para_permanent_address",Value=cand.PermanentAddress},
            new Parameter{Name="para_is_last_reachable_on_permanent_address",Value=cand.IsLastReachableOnPermanentAddress},
            new Parameter{Name="para_permanent_address_state_id",Value=cand.PermanentAddressStateID},
            new Parameter{Name="para_permanent_address_city_id",Value=cand.PermanentAddressCityID},
            new Parameter{Name="para_permanent_address_pin_code",Value=cand.PermanentAddressPinCode},

            new Parameter{Name="para_gender",Value=cand.Gender},
            new Parameter{Name="para_are_all_relevant_documents_submitted",Value=cand.AreAllRelevantDocumentSubmitted},
            new Parameter{Name="para_document_details",Value=cand.DocumentDetails},
            new Parameter{Name="para_email_address",Value=cand.EmailAddress},
            new Parameter{Name="para_marital_status",Value=cand.MaritialStatus},

            new Parameter{Name="para_is_bio_data_hard_copy_submitted",Value=cand.IsBiodataHardCopySubmitted},
            new Parameter{Name="para_is_bio_data_soft_copy_submitted",Value=cand.IsBiodataSoftCopySubmitted},
            new Parameter{Name="para_is_joining_form_signed",Value=cand.IsJoiningFormSigned},
            new Parameter{Name="para_uploaded_photograph_extension",Value=cand.UploadedPhotographExtension},
            new Parameter{Name="para_old_registration_number",Value=cand.OldRegistrationNumber},
            new Parameter{Name="para_joining_form_types",Value=cand.JoiningFormTypes}
        };
            //IList<string> paras = new List<string>();
            //foreach (var p in parameter)
            //{
            //    paras.Add(p + ", ");
            //}
            //Global.createAuditTrial("Register Candidate", "Insert", "", paras, "Insert", HttpContext.Current.Session["Session"].ToString());
            string errorMessage = String.Empty;
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteNonQueryWithTransaction(query, parameter, out errorMessage);
        }

        public int UpdateCandidate(EnableIndia.App_Code.BAL.CandidatesBAL cand)
        {
            string query = "update_candidate";

            List<Parameter> parameter = new List<Parameter>
        {
            new Parameter{Name="para_candidate_id",Value=cand.CandidateID},
            new Parameter{Name="para_ngo_id",Value=cand.NgoID},
            new Parameter{Name="para_candidate_number_at_ngo",Value=cand.CandidateNumberAtNGO},
            new Parameter{Name="para_file_number",Value=cand.FileNumber},
            new Parameter{Name="para_registration_date",Value=cand.RegistrationDate},

            new Parameter{Name="para_first_name",Value=cand.FirstName},
            new Parameter{Name="para_middle_name",Value=cand.MiddleName},
            new Parameter{Name="para_last_name",Value=cand.LastName},

            new Parameter{Name="para_disability_id",Value=cand.DisabilityID},
            new Parameter{Name="para_disability_sub_type_id",Value=cand.DisabilitySubTypeID},
            new Parameter{Name="para_date_of_birth",Value=cand.DateOfBirth},

            new Parameter{Name="para_primary_phone_number",Value=cand.PrimaryPhoneNumber},
            new Parameter{Name="para_is_last_reachable_on_primary_phone_number",Value=cand.IsLastReachableOnPrimaryPhoneNumber},

            new Parameter{Name="para_secondary_phone_number",Value=cand.SecondaryPhoneNumber},
            new Parameter{Name="para_is_last_reachable_on_secondary_phone_number",Value=cand.IsLastReachableOnSecondaryPhoneNumber},

            new Parameter{Name="para_present_address",Value=cand.PresentAddress},
            new Parameter{Name="para_is_last_reachable_on_present_address",Value=cand.IsLastReachableOnPresentAddress},
            new Parameter{Name="para_present_address_state_id",Value=cand.PresentAddressStateID},
            new Parameter{Name="para_present_address_city_id",Value=cand.PresentAddressCityID},
            new Parameter{Name="para_present_address_pin_code",Value=cand.PresentAddressPinCode},

            new Parameter{Name="para_permanent_address",Value=cand.PermanentAddress},
            new Parameter{Name="para_is_last_reachable_on_permanent_address",Value=cand.IsLastReachableOnPermanentAddress},
            new Parameter{Name="para_permanent_address_state_id",Value=cand.PermanentAddressStateID},
            new Parameter{Name="para_permanent_address_city_id",Value=cand.PermanentAddressCityID},
            new Parameter{Name="para_permanent_address_pin_code",Value=cand.PermanentAddressPinCode},

            new Parameter{Name="para_gender",Value=cand.Gender},
            new Parameter{Name="para_are_all_relevant_documents_submitted",Value=cand.AreAllRelevantDocumentSubmitted},
            new Parameter{Name="para_document_details",Value=cand.DocumentDetails},
            new Parameter{Name="para_email_address",Value=cand.EmailAddress},
            new Parameter{Name="para_marital_status",Value=cand.MaritialStatus},

            new Parameter{Name="para_is_bio_data_hard_copy_submitted",Value=cand.IsBiodataHardCopySubmitted},
            new Parameter{Name="para_is_bio_data_soft_copy_submitted",Value=cand.IsBiodataSoftCopySubmitted},
            new Parameter{Name="para_is_joining_form_signed",Value=cand.IsJoiningFormSigned},
            new Parameter{Name="para_uploaded_photograph_extension",Value=cand.UploadedPhotographExtension},
            new Parameter{Name="para_old_registration_number",Value=cand.OldRegistrationNumber},
            new Parameter{Name="para_joining_form_types",Value=cand.JoiningFormTypes}
        };

            DBAccess dba = new DBAccess();
            string errorMessage = "";
            return (int)dba.ExecuteNonQueryWithTransaction(query, parameter, out errorMessage);
        }

        public DataTable GetCandidateTasks(EnableIndia.App_Code.BAL.CandidatesBAL cand)
        {
            string query = "rpt_candidate_tasks";
            List<Parameter> parameter = new List<Parameter>
        {
            new Parameter{Name="para_status",Value=cand.Status},
            new Parameter{Name="para_disability_id",Value=cand.DisabilityID},

            new Parameter{Name="para_date_type",Value=cand.DateType},
            new Parameter{Name="para_date_from",Value=cand.DateFrom},
            new Parameter{Name="para_date_to",Value=cand.DateTo},
            new Parameter{Name="para_employee_id",Value=cand.EmployeeID},
            new Parameter{Name="para_candidate_flag_id",Value=cand.CandidateFlagID},
             new Parameter{Name="para_search_for",Value=cand.SearchFor},
            new Parameter{Name="para_search_in",Value=cand.SearchIn}
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameter, "DataTable");
        }

        public DataTable GetOwnerwiseOpenCandidateTask(EnableIndia.App_Code.BAL.CandidatesBAL cand)
        {
            string query = "rpt_open_candidate_ownerwise_work_distribution";
            List<Parameter> parameter = new List<Parameter>
        {
            new Parameter{Name="para_date_from",Value=cand.DateFrom},
            new Parameter{Name="para_date_to",Value=cand.DateTo}
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameter, "DataTable");
        }

        public DataTable GetOwnerwiseClosedCandidateTask(EnableIndia.App_Code.BAL.CandidatesBAL cand)
        {
            string query = "rpt_closed_candidate_ownerwise_work_distribution";
            List<Parameter> parameter = new List<Parameter>
        {
            new Parameter{Name="para_date_type",Value=cand.DateType},
            new Parameter{Name="para_date_from",Value=cand.DateFrom},
            new Parameter{Name="para_date_to",Value=cand.DateTo}
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameter, "DataTable");
        }

        public DataTable GetAllActiveRegisteredCandidate(EnableIndia.App_Code.BAL.CandidatesBAL cand)
        {
            string query = "rpt_all_active_registered_candidates";
            //string query = "rpt_all_active_registered_candidates_new";
            List<Parameter> parameter = new List<Parameter>
        {
            //new Parameter{Name="para_candidate_id",Value=cand.CandidateID},
            new Parameter{Name="para_qualification_id",Value=cand.QualificationID},
            new Parameter{Name="para_is_profiled",Value=cand.IsProfiled},
            new Parameter{Name="para_employment_status",Value=cand.EmploymentStatus},
            new Parameter{Name="para_assignment",Value=cand.Assignment},
            new Parameter{Name="para_state_id",Value=cand.StateID},
            new Parameter{Name="para_city_id",Value=cand.CityID},
            new Parameter{Name="para_age_group",Value=cand.AgeGroup},
            new Parameter{Name="para_contract_expiry_date", Value=cand.ContractExpiryDate},
            new Parameter{Name="para_ngo_id",Value=cand.NgoID},
            new Parameter{Name="para_disability_id",Value=cand.DisabilityID},
            new Parameter{Name="para_disability_sub_id",Value=cand.DisabilitySubTypeID},
            new Parameter{Name="para_search_for",Value=cand.SearchFor},
            new Parameter{Name="para_search_in",Value=cand.SearchIn},
            new Parameter{Name="para_current_date",Value=DateTime.Now.ToString("yyyy/MM/dd")},
            new Parameter{Name="para_recommended_job_type_id",Value=cand.RecommendedJobID},
            new Parameter{Name="para_recommended_job_role_id",Value=cand.RecommendedJobRoleID},
            new Parameter{Name="para_missing_data_in_profile",Value=cand.MissingDataProfile},
            new Parameter{Name="para_group_id",Value=cand.GroupID},
            new Parameter{Name="para_langauge_id",Value=cand.LanguageID},
            new Parameter{Name="para_gender",Value=cand.Gender},
            new Parameter{Name="para_company_id",Value=cand.CompanyID},
            new Parameter{Name="para_registration_from_date",Value=cand.RegistrationFrom},
            new Parameter{Name="para_registration_to_date",Value=cand.RegistrationTo},
            new Parameter{Name="para_date_of_birth",Value=cand.DateOfBirth},
            new Parameter{Name="para_employment_start_from_date",Value=cand.EmployentProjectStartDateFrom},
            new Parameter{Name="para_employment_start_to_date",Value=cand.EmployentProjectStartDateTo},
            new Parameter{Name="para_employment_end_from_date",Value=cand.EmployentProjectEndDateFrom},
            new Parameter{Name="para_employment_end_to_date",Value=cand.EmployentProjectEndDateTo},

            new Parameter{Name="salary_from",Value=cand.SalaryFrom},
            new Parameter{Name="salary_to",Value=cand.SalaryTo}
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameter, "DataTable");
        }

        public int CheckDuplicationOfOldRegistrationNumber(EnableIndia.App_Code.BAL.CandidatesBAL cand)
        {
            string query = "select count(candidate_id) from candidates";
            query += " where old_registration_number =\"" + cand.OldRegistrationNumber + "\" ";
            if (!cand.CandidateID.Equals(-1))
            {
                query += " and candidate_id !=" + cand.CandidateID;
            }
            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public int CheckDuplicationCandidateDetails(EnableIndia.App_Code.BAL.CandidatesBAL cand)
        {
            //string query = "select count(candidate_id) from candidates";
            //query += " where date_of_birth= \"" + cand.DateOfBirth + "\" ";
            //query += " and disability_id= " + cand.DisabilityID;
            //if (!cand.CandidateID.Equals(-1))
            //{
            //    query += " and candidate_id !=" + cand.CandidateID;
            //}
            //DBAccess dba = new DBAccess();
            //return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
            return (0);
        }

        public int GetCandidateIDFromRID(string RID)
        {
            string query = "select candidate_id from candidates where  registration_id='" + RID + "' and  is_registration_completed=1 ";
            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public DataTable GetEmploymentProofNotGotCandidates()
        {
            string query = "call rpt_employment_proof_not_got()";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetRejectionDataFroCandidates(EnableIndia.App_Code.BAL.CandidatesBAL cand)
        {
            string query = "rpt_rejection_data_for_candidates";
            List<Parameter> parameter = new List<Parameter>
        {
            new Parameter{Name="para_search_for",Value=cand.SearchFor},
            new Parameter{Name="para_search_in",Value=cand.SearchIn},
            new Parameter{Name="para_training_program_id",Value=cand.TrainingProgramID},
            new Parameter{Name="para_training_project_id",Value=cand.TrainingProjectID},
            new Parameter{Name="para_employment_project_id",Value=cand.EmploymentProjectID},
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameter, "DataTable");
        }
    }
  }
