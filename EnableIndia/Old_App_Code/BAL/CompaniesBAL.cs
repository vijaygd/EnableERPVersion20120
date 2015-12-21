using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for CompaniesBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CompaniesBAL
    {
        public CompaniesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region COMPANY PARAMETERS
        public int HistoryID
        {
            get;
            set;
        }

        public int CandidateID
        {
            get;
            set;
        }

        public string HistoryDate
        {
            get;
            set;
        }

        public string Details
        {
            get;
            set;
        }

        public int CandidateFlagID
        {
            get;
            set;
        }
        public int IsHistory
        {
            get;
            set;
        }

        public int EmployemntProjectID
        {
            get;
            set;
        }

        public int EmployeeID
        {
            get;
            set;
        }

        public string RecommendedAction
        {
            get;
            set;
        }

        public string FollowUpDate
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public int CompanyID
        {
            get;
            set;
        }

        public int ParentCompanyID
        {
            get;
            set;
        }

        public string CompanyCode
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public string Fax
        {
            get;
            set;
        }

        public string Website
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public int StateID
        {
            get;
            set;
        }

        public int CityID
        {
            get;
            set;
        }

        public string PinCode
        {
            get;
            set;
        }

        public string CompanyDetails
        {
            get;
            set;
        }

        public int IndustrySegmentId
        {
            get;
            set;
        }

        public string SelectedDate
        {
            get;
            set;
        }

        public string SelectedParameter
        {
            get;
            set;
        }

        public int SelectedParameterValue
        {
            get;
            set;
        }

        public string SearchFor
        {
            get;
            set;
        }

        public string SearchIn
        {
            get;
            set;
        }

        public string DateFrom
        {
            get;
            set;
        }

        public string DateTo
        {
            get;
            set;
        }

        public int CompanyFlagID
        {
            get;
            set;
        }
        public string DateType
        {
            get;
            set;
        }
        public string ParentCompany
        {
            get;
            set;
        }
        public string Company
        {
            get;
            set;
        }
        public string State
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string IndustrySegment
        {
            get;
            set;
        }
        public int SegmentID
        {
            get;
            set;
        }
        #endregion

        public int CheckForDuplicateCompany(string companyID, string companyName)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL comp = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return comp.CheckForDuplicateCompany(companyID, companyName);
        }

        public MySqlDataReader GetCompanies(string parentCompanyID)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return get.GetCompanies(parentCompanyID);
        }

        public MySqlDataReader GetcompanyDetails(string companyID)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return get.GetcompanyDetails(companyID);
        }

        public int AddCompany(CompaniesBAL company)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL comp = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return comp.AddCompany(company);
        }

        public bool UpdateCompany(CompaniesBAL company)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL comp = new EnableIndia.App_Code.DAL.CompaniesDAL();
            int rowsUpdated = comp.UpdateCompany(company);
            if (rowsUpdated > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddIndustrySegments(string industrySegmentName)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL comp = new EnableIndia.App_Code.DAL.CompaniesDAL();
            int rowsAdded = comp.AddIndustrySegments(industrySegmentName);
            if (rowsAdded.Equals(0))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public MySqlDataReader GetIndustrySegments()
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return get.GetIndustrySegments();
        }
        public bool AddCompanyHistory(CompaniesBAL company)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL comp = new EnableIndia.App_Code.DAL.CompaniesDAL();
            int rowsAdded = comp.AddCompanyHistory(company);
            if (rowsAdded.Equals(0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool UpdateCompanyHistory(CompaniesBAL company)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL comp = new EnableIndia.App_Code.DAL.CompaniesDAL();
            int rowsAdded = comp.UpdateCompanyHistory(company);
            if (rowsAdded.Equals(0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int DeleteCompanyHistory(int historyID, int companyID, int parentCompanyID)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL dlComp = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return dlComp.DeleteCompanyHistory(historyID, companyID, parentCompanyID);
        }

        public DataTable GetCompanyHistory(int companyID)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            DataTable dtCandidateHistory = get.GetCompanyHistory(companyID);
            dtCandidateHistory.Columns.Add("str_closure_date");
            dtCandidateHistory.Columns.Add("str_follow_up_date");
            foreach (DataRow dr in dtCandidateHistory.Rows)
            {
                if (dr["closure_date"].ToString().Contains("1900"))
                {
                    dr["str_closure_date"] = "";
                }
                else
                {
                    dr["str_closure_date"] = Convert.ToDateTime(dr["closure_date"]).ToString(Global.GetDateFormat());
                }
                //code for changes in  follow_up_date 
                if (dr["follow_up_date"].ToString().Contains("1900"))
                {
                    dr["str_follow_up_date"] = "";
                }
                else
                {
                    dr["str_follow_up_date"] = Convert.ToDateTime(dr["follow_up_date"]).ToString(Global.GetDateFormat());
                }
                if (dr["flag_name"].ToString().ToLower().Contains("no action"))
                {
                    if (dr["closure_date"].ToString().Contains("1900"))
                    {
                        dr["status"] = "NA";
                    }
                    else
                    {
                        dr["status"] = "Closed";
                    }
                    dr["employee_name"] = "NA";
                    dr["recommended_action"] = "NA";
                    dr["str_follow_up_date"] = "NA";
                    dr["str_closure_date"] = "NA";
                }
            }

            return dtCandidateHistory;
        }

        public MySqlDataReader GetCompanyHistoryDetails(string historyID)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return get.GetCompanyeHistoryDetails(historyID);
        }
        public DataTable SearchOpenCompanyTasks(CompaniesBAL search)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();

            DataTable dtOpenCcompanyTasks = get.SearchOpenCompanyTasks(search);
            dtOpenCcompanyTasks.Columns.Add("str_follow_up_date");
            foreach (DataRow dr in dtOpenCcompanyTasks.Rows)
            {
                if (dr["follow_up_date"].ToString().Contains("1900"))
                {
                    dr["str_follow_up_date"] = "";
                }
                else
                {
                    dr["str_follow_up_date"] = Convert.ToDateTime(dr["follow_up_date"]).ToString(Global.GetDateFormat());
                }
            }

            return dtOpenCcompanyTasks;
        }

        public DataTable GetCompanyInReport(CompaniesBAL company)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return get.GetCompanyInReport(company);
        }

        public DataTable GetCompanyTasks(CompaniesBAL company)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            //return get.GetCompanyTasks(company);

            DataTable dtGetCompanyTasks = get.GetCompanyTasks(company);
            dtGetCompanyTasks.Columns.Add("str_closure_date");
            dtGetCompanyTasks.Columns.Add("str_follow_up_date");
            dtGetCompanyTasks.Columns.Add("str_lead_time_close_days");
            foreach (DataRow dr in dtGetCompanyTasks.Rows)
            {
                if (dr["follow_up_date"].ToString().Contains("1900"))
                {
                    dr["str_follow_up_date"] = "";
                }
                else
                {
                    dr["str_follow_up_date"] = Convert.ToDateTime(dr["follow_up_date"]).ToString(Global.GetDateFormat());
                }

                if (dr["closure_date"].ToString().Contains("1900"))
                {
                    dr["str_closure_date"] = "";
                    dr["str_lead_time_close_days"] = "";
                }
                else
                {
                    dr["str_lead_time_close_days"] = dr["lead_time_close_days"].ToString();
                    dr["str_closure_date"] = Convert.ToDateTime(dr["closure_date"]).ToString(Global.GetDateFormat());
                }
            }
            return dtGetCompanyTasks;
        }
        public int CheckForDuplicationTask(CompaniesBAL search)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return get.CheckForDuplicationTask(search);
        }

        public MySqlDataReader GetCandidateNameRidForAddTask(CompaniesBAL comp)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return get.GetCandidateNameRidForAddTask(comp);
        }
        public int GetIDOfWorkplacesolution()
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return get.GetIDOfWorkplacesolution();

        }
        public int GetIDOfIntervaentionrequired()
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return get.GetIDOfIntervaentionrequired();

        }

        public int GetIDOfPostInterviewDateTime()
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return get.GetIDOfPostInterviewDateTime();
        }

        public int GetIDOfInterviewDateTime()
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return get.GetIDOfInterviewDateTime();
        }

        public MySqlDataReader GetEmployemntProjectNameAndIntervention(CompaniesBAL comp)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return get.GetEmployemntProjectNameAndIntervention(comp);
        }
        public int CheckForDuplicationIntevention(CompaniesBAL comp)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return get.CheckForDuplicationIntevention(comp);
        }

        //public MySqlDataReader GetEmployemntProjectNameAndInterventionAddition(EmploymentProjectBAL emp)
        //{
        //    CompaniesDAL get = new CompaniesDAL();
        //    return get.GetEmployemntProjectNameAndInterventionAddition(emp);
        //}

        public DataTable GetFlagWiseClosedCompanyTask(CompaniesBAL comp)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return get.GetFlagWiseClosedCompanyTask(comp);
        }

        public DataTable GetOwnerwiseClosedCompanyTask(CompaniesBAL comp)
        {
            EnableIndia.App_Code.DAL.CompaniesDAL get = new EnableIndia.App_Code.DAL.CompaniesDAL();
            return get.GetOwnerwiseClosedCompanyTask(comp);
        }
    }
}