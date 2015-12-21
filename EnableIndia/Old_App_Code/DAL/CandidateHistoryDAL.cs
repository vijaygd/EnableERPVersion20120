using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CandidateHistoryDAL
    /// </summary>
    public class CandidateHistoryDAL
    {
        public CandidateHistoryDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCandidateHistory(string candidateID)
        {
            string query = "call get_candidate_history(" + candidateID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public MySqlDataReader GetCandidateHistoryDetails(string historyID)
        {
            string query = "select * from candidate_history where history_id=" + historyID;
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public int AddCandidateHistory(EnableIndia.App_Code.BAL.CandidateHistoryBAL history)
        {
            string query = "add_candidate_history";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_candidate_id",Value=history.CandidateID},
            new Parameter{Name="para_history_date",Value=history.HistoryDate},
            new Parameter{Name="para_details",Value=history.Details},
            new Parameter{Name="para_candidate_flag_id",Value=history.CandidateFlagID},
            new Parameter{Name="para_assigned_to_employee_id",Value=history.EmployeeID},
            new Parameter{Name="para_recommended_action",Value=history.RecommendedAction},
            new Parameter{Name="para_follow_up_date",Value=history.FollowUpDate}
        };
 
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, parameters, "NonQuery");
        }

        public int UpdateCandidateHistory(EnableIndia.App_Code.BAL.CandidateHistoryBAL history)
        {
            string query = "update_candidate_history";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_history_id",Value=history.HistoryID},
            new Parameter{Name="para_history_date",Value=history.HistoryDate},
            new Parameter{Name="para_details",Value=history.Details},
            new Parameter{Name="para_candidate_flag_id",Value=history.CandidateFlagID},
            new Parameter{Name="para_assigned_to_employee_id",Value=history.EmployeeID},
            new Parameter{Name="para_recommended_action",Value=history.RecommendedAction},
            new Parameter{Name="para_follow_up_date",Value=history.FollowUpDate},
            new Parameter{Name="para_status",Value=history.Status},
            new Parameter{Name="para_closure_date",Value=DateTime.Now.ToString("yyyy/MM/dd")}
        };

            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, parameters, "NonQuery");
        }

        public int DeleteCandidateHistory(int historyID, int candidateID)
        {
            string query = "delete from candidate_history where history_id=" + historyID;
            query += " and candidate_id=" + candidateID;

            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }
    }
}