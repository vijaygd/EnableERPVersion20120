using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


/// <summary>
/// Summary description for CandidateHistoryBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CandidateHistoryBAL
    {
        public CandidateHistoryBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region CANDIDATE HISTORY PARAMETERS
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

        #endregion

        public DataTable GetCandidateHistory(string candidateID)
        {
            CandidateHistoryDAL get = new CandidateHistoryDAL();
            DataTable dtCandidateHistory = get.GetCandidateHistory(candidateID);
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

        public MySqlDataReader GetCandidateHistoryDetails(string historyID)
        {
            CandidateHistoryDAL get = new CandidateHistoryDAL();
            return get.GetCandidateHistoryDetails(historyID);
        }

        public bool AddCandidateHistory(CandidateHistoryBAL history)
        {
            CandidateHistoryDAL add = new CandidateHistoryDAL();
            int RowsAdded = add.AddCandidateHistory(history);
            if (RowsAdded > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCandidateHistory(CandidateHistoryBAL history)
        {
            CandidateHistoryDAL upd = new CandidateHistoryDAL();
            int RowsUpdated = upd.UpdateCandidateHistory(history);
            if (RowsUpdated > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int DeleteCandidateHistory(int historyID, int candidateID)
        {
            CandidateHistoryDAL dlHist = new CandidateHistoryDAL();
            return dlHist.DeleteCandidateHistory(historyID, candidateID);
        }
    }
}