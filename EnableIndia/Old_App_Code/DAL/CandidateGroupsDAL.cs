using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CandidateGroupsDAL
    /// </summary>
    public class CandidateGroupsDAL
    {
        public CandidateGroupsDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int AddCandidateGroup(string groupName)
        {
            string query = "insert into candidate_groups(group_name) values(\"" + groupName + "\")";
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }

        public DataTable GetCandidateGroupsAssignedToCandidate(string candidateID)
        {
            string query = "select ";
            query += "	grp.group_id,";
            query += "	grp.group_name,";
            query += "	if(cand_grp.candidate_group_id is null,0,1) as is_attached ";
            query += "from candidate_groups grp ";
            query += "left join(select candidate_group_id ";
            query += "			from candidate_groups_assigned_to_candidate ";
            query += "			where candidate_id=" + candidateID;
            query += "		    )as cand_grp on grp.group_id=cand_grp.candidate_group_id order by grp.group_name";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetCandidateGroup()
        {
            string query = "select * from  candidate_groups order by group_name ";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public MySqlDataReader GetCandidateGroups()
        {
            string query = "select * from  candidate_groups ";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }
    }
}