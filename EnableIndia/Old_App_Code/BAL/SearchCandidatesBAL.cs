using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for SearchCandidatesBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class SearchCandidatesBAL
    {
        public SearchCandidatesBAL()
        {
            //
        }
        #region SEARCH PARAMETERS
        public int EmploymentStatus
        {
            get;
            set;
        }

        public int CityID
        {
            get;
            set;
        }

        public int AgeGroup
        {
            get;
            set;
        }

        public int NgoID
        {
            get;
            set;
        }

        public int DisabilityID
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

        public string OldRegistrationNumber
        {
            get;
            set;
        }

        public string DateOfBirth
        {
            get;
            set;
        }
        public int JobTypeId
        {
            get;
            set;
        }
        public int RecommendedJobRoleID
        {
            get;
            set;
        }

        //Specific to open candidate taksks
        public string SelectedDate
        {
            get;
            set;
        }


        public int CandidateFlagID
        {
            get;
            set;
        }

        public int EmployeeID
        {
            get;
            set;
        }



        public int CurrentPageIndex
        {
            get;
            set;
        }
        //Recommended Candidate for training projects
        public int TrainingProjectID
        {
            get;
            set;
        }

        public int TrainingProgramID
        {
            get;
            set;
        }

        public int AssignedTrainingProgramID
        {
            get;
            set;
        }

        //Recommended candidates for employment projects
        public int EmploymentProjectID
        {
            get;
            set;
        }

        //Non recommended candidates for employment projects
        public int QualificationID
        {
            get;
            set;
        }

        public int PresentAddressStateID
        {
            get;
            set;
        }

        public int JobRoleID
        {
            get;
            set;
        }

        public int LanguageID
        {
            get;
            set;
        }

        public int CandidateGroupID
        {
            get;
            set;
        }
        public string Assignment
        {
            get;
            set;
        }
        public string MissingDataInProfile
        {
            get;
            set;
        }

        //Reports Parameters
        public string EmploymentDateFrom
        {
            get;
            set;
        }

        public string EmploymentDateTo
        {
            get;
            set;
        }

        public string DateType
        {
            get;
            set;
        }

        public string TrainingDateFrom
        {
            get;
            set;
        }

        public string TrainingDateTo
        {
            get;
            set;
        }

        public int GroupID
        {
            get;
            set;
        }

        public int NotDoneTrainingProgramID
        {
            get;
            set;
        }

        public string CurrentDate
        {
            get;
            set;
        }

        public string IsProfiled
        {
            get;
            set;
        }

        public int Gender
        {
            get;
            set;
        }

        #endregion

        public DataTable SearchAllActiveCandidates(SearchCandidatesBAL search)
        {
            SearchCandidatesDAL get = new SearchCandidatesDAL();
            DataSet dsAllActiveCandidates = get.SearchAllActiveCandidates(search);
            DataTable dtSearchAllActiveCandidates = null;
            if(dsAllActiveCandidates != null)
            {
            dtSearchAllActiveCandidates = dsAllActiveCandidates.Tables[0];
            dtSearchAllActiveCandidates.Columns.Add("StrCount");
            foreach (DataRow dr in dtSearchAllActiveCandidates.Rows)
            {
                dr["phone_numbers"] = dr["phone_numbers"].ToString().Replace(",", "<br/>");
                if (dr["unemployed_from_days"].ToString().Equals("Employed"))
                {
                    //dr["recommended_job_types"] = "";
                    //dr["recommended_roles"] = "";
                    dr["recommended_job_types"] = dr["recommended_job_types"].ToString();
                    dr["recommended_roles"] = dr["recommended_roles"].ToString();
                    dr["current_company"] = dr["current_company"].ToString();
                }
                else
                {
                    dr["current_company"] = "";
                    dr["recommended_job_types"] = dr["recommended_job_types"].ToString();
                    dr["recommended_roles"] = dr["recommended_roles"].ToString();
                }
                dr["StrCount"] = dsAllActiveCandidates.Tables[1].Rows[0]["total_rows"];
              }
               Global.SetGridPageCount(dsAllActiveCandidates.Tables[1].Rows[0]["total_rows"]);
            }
            else
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("Error: Data not avaialble");
            }

            return dtSearchAllActiveCandidates;
        }

        public DataTable SearchRecommendedCandidate(SearchCandidatesBAL search)
        {
            SearchCandidatesDAL get = new SearchCandidatesDAL();
            DataSet dsSearchAutoRecommendedCandidate = get.SearchAutoRecommendedCandidate(search);
            DataTable dtSearchAutoRecommendedCandidate = dsSearchAutoRecommendedCandidate.Tables[0];
            dtSearchAutoRecommendedCandidate.Columns.Add("StrCount");
            foreach (DataRow dr in dtSearchAutoRecommendedCandidate.Rows)
            {
                dr["phone_numbers"] = dr["phone_numbers"].ToString().Replace(",", Environment.NewLine);
                dr["email_address"] = dr["email_address"].ToString().Replace(",", Environment.NewLine);
                dr["StrCount"] = dsSearchAutoRecommendedCandidate.Tables[1].Rows[0]["total_rows"];
            }
            Global.SetGridPageCount(dsSearchAutoRecommendedCandidate.Tables[1].Rows[0]["total_rows"]);
            return dtSearchAutoRecommendedCandidate;
        }

        public DataTable SearchToBeProfiledCandidates(SearchCandidatesBAL search)
        {
            SearchCandidatesDAL get = new SearchCandidatesDAL();
            DataSet dsToBeProfiledCandidates = get.SearchToBeProfiledCandidates(search);

            DataTable dtToBeProfiledCandidates = dsToBeProfiledCandidates.Tables[0];
            dtToBeProfiledCandidates.Columns.Add("StrCount");
            foreach (DataRow dr in dtToBeProfiledCandidates.Rows)
            {
                dr["phone_numbers"] = dr["phone_numbers"].ToString().Replace(",", Environment.NewLine);
                dr["StrCount"] = dsToBeProfiledCandidates.Tables[1].Rows[0]["total_rows"];
            }

            Global.SetGridPageCount(dsToBeProfiledCandidates.Tables[1].Rows[0]["total_rows"]);
            return dtToBeProfiledCandidates;
        }

        public DataTable SearchOpenCandidateTasks(SearchCandidatesBAL search)
        {
            SearchCandidatesDAL get = new SearchCandidatesDAL();
            DataTable dtOpenCandidateTasks = get.SearchOpenCandidateTasks(search);
            dtOpenCandidateTasks.Columns.Add("str_follow_up_date");
            foreach (DataRow dr in dtOpenCandidateTasks.Rows)
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
            return dtOpenCandidateTasks;
        }

        public DataTable SearchRecommendedCandidatesForEmploymentProjects(SearchCandidatesBAL search)
        {
            SearchCandidatesDAL get = new SearchCandidatesDAL();
            DataSet dsRecommendedCandidates = get.SearchRecommendedCandidatesForEmploymentProjects(search);
            DataTable dtRecommendedCandidates = dsRecommendedCandidates.Tables[0];
            foreach (DataRow dr in dtRecommendedCandidates.Rows)
            {
                dr["phone_numbers"] = dr["phone_numbers"].ToString().Replace(",", Environment.NewLine);
                dr["email_address"] = dr["email_address"].ToString().Replace(",", Environment.NewLine);
                if (dr["month_experience"].ToString().Equals("0"))
                {
                    dr["total_experience"] = "0y 0m";
                }
                if (Convert.ToInt32(dr["month_experience"]) > 11)
                {
                    dr["year_experience"] = Math.Floor(Convert.ToDouble(dr["month_experience"]) / 12);
                    dr["month_experience"] = (Convert.ToInt32(dr["month_experience"]) % 12);
                    dr["total_experience"] = dr["year_experience"].ToString() + "y" + dr["month_experience"].ToString() + "m";
                }
                else
                {
                    dr["total_experience"] = dr["year_experience"].ToString() + "y" + dr["month_experience"].ToString() + "m";
                }
                if (dr["total_experience"].ToString().Contains("-"))
                {
                    dr["total_experience"] = "0y 0m";
                }
            }
            Global.SetGridPageCount(dsRecommendedCandidates.Tables[1].Rows[0]["total_rows"]);
            return dtRecommendedCandidates;
        }

        public DataTable SearchNonRecommendedCandidatesForEmploymentProject(SearchCandidatesBAL search)
        {
            SearchCandidatesDAL get = new SearchCandidatesDAL();
            DataSet dsNonRecommendedCandidates = get.SearchNonRecommendedCandidatesForEmploymentProject(search);
            DataTable dtNonRecommendedCandidates = dsNonRecommendedCandidates.Tables[0];
            foreach (DataRow dr in dtNonRecommendedCandidates.Rows)
            {
                if (dr["month_experience"].ToString().Equals("0"))
                {
                    dr["total_experience"] = "0y 0m";
                }
                dr["phone_numbers"] = dr["phone_numbers"].ToString().Replace(",", Environment.NewLine);
                dr["email_address"] = dr["email_address"].ToString().Replace(",", Environment.NewLine);
                if (Convert.ToInt32(dr["month_experience"]) > 11)
                {
                    dr["year_experience"] = Math.Floor(Convert.ToDouble(dr["month_experience"]) / 12);
                    dr["month_experience"] = (Convert.ToInt32(dr["month_experience"]) % 12);
                    dr["total_experience"] = dr["year_experience"].ToString() + "y" + dr["month_experience"].ToString() + "m";
                }
                else
                {
                    dr["total_experience"] = dr["year_experience"].ToString() + "y" + dr["month_experience"].ToString() + "m";
                }
                if (dr["total_experience"].ToString().Contains("-"))
                {
                    dr["total_experience"] = "0y 0m";
                }
            }
            Global.SetGridPageCount(dsNonRecommendedCandidates.Tables[1].Rows[0]["total_rows"]);
            return dtNonRecommendedCandidates;
        }

        public DataTable GetCandidateWiseTrainingEmploymentRelation(SearchCandidatesBAL search)
        {
            SearchCandidatesDAL get = new SearchCandidatesDAL();
            DataTable dt = get.GetCandidateWiseTrainingEmploymentRelation(search);
            if (dt == null)
                return (DataTable)null;
            foreach (DataRow dr in dt.Rows)
            {
                dr["phone_numbers"] = dr["phone_numbers"].ToString().Replace(",", Environment.NewLine);
            }
            return dt;
        }
    }
}
