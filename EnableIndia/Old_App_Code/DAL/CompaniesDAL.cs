using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CompaniesDAL
    /// </summary>
    public class CompaniesDAL
    {
        public CompaniesDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int CheckForDuplicateCompany(string companyID, string companyName)
        {
            string query = "select count(company_id) from companies where company_code=\"" + companyName + "\" ";
            if (!companyID.Equals("-2"))
            {
                query += " and company_id!=" + companyID;
            }

            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public MySqlDataReader GetCompanies(string parentCompanyID)
        {
            string query = "select * from companies ";
            if (!parentCompanyID.Equals("-1"))
            {
                query += " where parent_company_id=" + parentCompanyID;
            }
            query += " order by company_code";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public MySqlDataReader GetcompanyDetails(string companyID)
        {
            string query = "select * from companies where company_id=" + companyID;
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public int AddCompany(EnableIndia.App_Code.BAL.CompaniesBAL company)
        {
            string query = "add_company";

            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_parent_company_id",Value=company.ParentCompanyID},
            new Parameter{Name="para_company_code",Value=company.CompanyCode},
            new Parameter{Name="para_phone_number",Value=company.PhoneNumber},
            new Parameter{Name="para_fax",Value=company.Fax},
            new Parameter{Name="para_website",Value=company.Website},
            new Parameter{Name="para_address",Value=company.Address},
            new Parameter{Name="para_state_id",Value=company.StateID},
            new Parameter{Name="para_city_id",Value=company.CityID},
            new Parameter{Name="para_pin_code",Value=company.PinCode},
            new Parameter{Name="para_company_details",Value=company.CompanyDetails},
             new Parameter{Name="para_industry_segment_id",Value=company.IndustrySegmentId},
        };

            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, parameters, "Scalar"));
        }

        public int UpdateCompany(EnableIndia.App_Code.BAL.CompaniesBAL company)
        {
            string query = "update_company";

            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_company_id",Value=company.CompanyID},
            new Parameter{Name="para_parent_company_id",Value=company.ParentCompanyID},
            new Parameter{Name="para_company_code",Value=company.CompanyCode},
            new Parameter{Name="para_phone_number",Value=company.PhoneNumber},
            new Parameter{Name="para_fax",Value=company.Fax},
            new Parameter{Name="para_website",Value=company.Website},
            new Parameter{Name="para_address",Value=company.Address},
            new Parameter{Name="para_state_id",Value=company.StateID},
            new Parameter{Name="para_city_id",Value=company.CityID},
            new Parameter{Name="para_pin_code",Value=company.PinCode},
            new Parameter{Name="para_company_details",Value=company.CompanyDetails},
            new Parameter{Name="para_industry_segment_id",Value=company.IndustrySegmentId},
        };

            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, parameters, "NonQuery");
        }

        public DataTable GetCompanyInReport(EnableIndia.App_Code.BAL.CompaniesBAL company)
        {
            string query = "rpt_list_of_company";
            List<Parameter> parameter = new List<Parameter>
        {
            new Parameter{Name="para_parent_company_id",Value=company.ParentCompanyID},
            new Parameter{Name="para_company_id",Value=company.CompanyID},
            new Parameter{Name="para_state_id",Value=company.StateID},
            new Parameter{Name="para_segment_id",Value=company.SegmentID},
            new Parameter{Name="para_city_id",Value=company.CityID},
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameter, "DataTable");
        }

        public DataTable GetCompanyTasks(EnableIndia.App_Code.BAL.CompaniesBAL company)
        {
            string query = "rpt_company_tasks";
            List<Parameter> parameter = new List<Parameter>
        {
            new Parameter{Name="para_status",Value=company.Status},
            new Parameter{Name="para_date_type",Value=company.DateType},
            new Parameter{Name="para_date_from",Value=company.DateFrom},
            new Parameter{Name="para_date_to",Value=company.DateTo},
             new Parameter{Name="para_employee_id",Value=company.EmployeeID},
            new Parameter{Name="para_candidate_flag_id",Value=company.CandidateFlagID},
             new Parameter{Name="para_search_for",Value=company.SearchFor},
            new Parameter{Name="para_search_in",Value=company.SearchIn}
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameter, "DataTable");
        }

        public MySqlDataReader GetIndustrySegments()
        {
            string query = "select * from industry_segments order by industry_segment ";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public int AddIndustrySegments(string industrySegmentName)
        {
            string query = "insert into  industry_segments(industry_segment ) values(\"" + industrySegmentName + "\")";
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }

        public int AddCompanyHistory(EnableIndia.App_Code.BAL.CompaniesBAL company)
        {
            string query = "add_company_history";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_parent_company_id",Value=company.ParentCompanyID},
            new Parameter{Name="para_company_id",Value=company.CompanyID},
            new Parameter{Name="para_history_date",Value=company.HistoryDate},
            new Parameter{Name="para_details",Value=company.Details},
            new Parameter{Name="para_company_flag_id",Value=company.CandidateFlagID},
            new Parameter{Name="para_assigned_to_employee_id",Value=company.EmployeeID},
            new Parameter{Name="para_recommended_action",Value=company.RecommendedAction},
            new Parameter{Name="para_follow_up_date",Value=company.FollowUpDate},
            new Parameter{Name="para_candidate_id",Value=company.CandidateID},
            new Parameter{Name="para_employment_project_id",Value=company.EmployemntProjectID},
            new Parameter{Name="para_is_history",Value=company.IsHistory}
        };

            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, parameters, "NonQuery");
        }

        public int UpdateCompanyHistory(EnableIndia.App_Code.BAL.CompaniesBAL company)
        {
            string query = "update_company_history";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_history_id",Value=company.HistoryID},
            new Parameter{Name="para_history_date",Value=company.HistoryDate},
            new Parameter{Name="para_details",Value=company.Details},
            new Parameter{Name="para_company_flag_id",Value=company.CandidateFlagID},
            new Parameter{Name="para_assigned_to_employee_id",Value=company.EmployeeID},
            new Parameter{Name="para_recommended_action",Value=company.RecommendedAction},
            new Parameter{Name="para_follow_up_date",Value=company.FollowUpDate},
            new Parameter{Name="para_status",Value=company.Status},
            new Parameter{Name="para_closure_date",Value=DateTime.Now.ToString("yyyy/MM/dd")}
        };

            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, parameters, "NonQuery");
        }

        public int DeleteCompanyHistory(int historyID, int companyID, int parentCompanyID)
        {
            string query = "delete from company_history where history_id=" + historyID;
            query += " and company_id=" + companyID;
            query += " and parent_company_id=" + parentCompanyID;

            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }

        public DataTable GetCompanyHistory(int companyID)
        {
            string query = "call get_company_history(" + companyID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public MySqlDataReader GetCompanyeHistoryDetails(string historyID)
        {
            string query = "select comp_hist.*, ";
            query += "par_comp.company_name,comp.company_code ";
            query += "from company_history comp_hist ";
            query += " join parent_companies  par_comp on par_comp.company_id=comp_hist.parent_company_id ";
            query += " join companies comp on comp.company_id=comp_hist.company_id ";
            query += "   where history_id=" + historyID;
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }


        public DataTable SearchOpenCompanyTasks(EnableIndia.App_Code.BAL.CompaniesBAL search)
        {
            string query = "search_open_company_tasks";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_selected_date",Value=search.SelectedDate},
            new Parameter{Name="para_date_from",Value=search.DateFrom},
            new Parameter{Name="para_date_to",Value=search.DateTo},
            new Parameter{Name="para_company_flag_id",Value=search.CompanyFlagID},
            new Parameter{Name="para_managed_by_id",Value=search.EmployeeID},
            new Parameter{Name="para_search_for",Value=search.SearchFor},
            new Parameter{Name="para_search_in",Value=search.SearchIn}
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameters, "DataTable");
        }

        public int CheckForDuplicationTask(EnableIndia.App_Code.BAL.CompaniesBAL comp)
        {
            string query = "select count(history_id) from company_history where parent_company_id=" + comp.ParentCompanyID + " ";
            query += " and  company_id=" + comp.CompanyID + " and employment_project_id=" + comp.EmployemntProjectID + " ";
            query += " and company_flag_id=" + comp.CandidateFlagID + " and details='" + comp.Details + "'";
            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public MySqlDataReader GetCandidateNameRidForAddTask(EnableIndia.App_Code.BAL.CompaniesBAL comp)
        {
            string query = " select  concat(cand.first_name,' ',cand.middle_name,' ',cand.last_name) as candidate_name, ";
            query += " cand.registration_id as RID ,disab.disability_type,emp_proj.employment_project_name,parent_company_id,company_id  ";
            query += "from candidates cand  ";
            query += " join disability_types disab on disab.disability_id=cand.disability_id ";
            query += " join candidates_assigned_to_employment_project assign_emp_proj on cand.candidate_id=assign_emp_proj.candidate_id ";
            query += " join employment_projects emp_proj on assign_emp_proj.employment_project_id=emp_proj.employment_project_id ";
            query += " where cand.candidate_id=" + comp.CandidateID + " and emp_proj.employment_project_id=" + comp.EmployemntProjectID;
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public int GetIDOfWorkplacesolution()
        {
            string query = "select flag_id from company_flags where  flag_name='Work Place solution to be Done'";
            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public int GetIDOfIntervaentionrequired()
        {
            string query = "select flag_id from company_flags where  flag_name='Interventions Required'";
            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public int GetIDOfInterviewDateTime()
        {
            string query = "select flag_id from company_flags where  flag_name='Interview Date and Time'";
            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public int GetIDOfPostInterviewDateTime()
        {
            string query = "select flag_id from company_flags where  flag_name='Post Interview Follow-up'";
            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public MySqlDataReader GetEmployemntProjectNameAndIntervention(EnableIndia.App_Code.BAL.CompaniesBAL comp)
        {
            string query = " select  employment_project_id,employment_project_name, ";
            query += " parent_company_id,company_id,intervention_required ";
            query += " from employment_projects where employment_project_id=" + comp.EmployemntProjectID;
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        //public MySqlDataReader GetEmployemntProjectNameAndInterventionAddition(EmploymentProjectBAL  emp)
        //{
        //    string query = " select  fun_generate_employment_project_name("+emp.CompanyID+", ";
        //    query += ""+emp.VacancyID+",";
        //    query += "'"+emp.CompanyCode+"',";
        //    query += "'" + emp.VacancyCode + "') as employment_project_name ";
        //    DBAccess dba = new DBAccess();
        //    return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        //}

        public int CheckForDuplicationIntevention(EnableIndia.App_Code.BAL.CompaniesBAL comp)
        {
            string query = "select count(history_id) from company_history where details=\"" + comp.Details + "\" ";
            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public DataTable GetFlagWiseClosedCompanyTask(EnableIndia.App_Code.BAL.CompaniesBAL comp)
        {
            string query = "rpt_flagwise_closed_company_task";
            List<Parameter> parameter = new List<Parameter>
        {
            new Parameter{Name="para_date_type",Value=comp.DateType},
            new Parameter{Name="para_date_from",Value=comp.DateFrom},
            new Parameter{Name="para_date_to",Value=comp.DateTo}
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameter, "DataTable");
        }

        public DataTable GetOwnerwiseClosedCompanyTask(EnableIndia.App_Code.BAL.CompaniesBAL comp)
        {
            string query = "rpt_ownerwise_company_closed_task";
            List<Parameter> parameter = new List<Parameter>
        {
            new Parameter{Name="para_date_type",Value=comp.DateType},
            new Parameter{Name="para_date_from",Value=comp.DateFrom},
            new Parameter{Name="para_date_to",Value=comp.DateTo}
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameter, "DataTable");
        }
    }
}