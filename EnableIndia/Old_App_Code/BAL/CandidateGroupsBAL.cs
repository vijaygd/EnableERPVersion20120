using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


/// <summary>
/// Summary description for CandidateGroupsBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CandidateGroupsBAL
    {
        public CandidateGroupsBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public bool AddCandidateGroup(string groupName)
        {
            CandidateGroupsDAL group = new CandidateGroupsDAL();
            int rowsAdded = group.AddCandidateGroup(groupName);
            if (!rowsAdded.Equals(0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetCandidateGroupsAssignedToCandidate(string candidateID)
        {
            CandidateGroupsDAL get = new CandidateGroupsDAL();
            return get.GetCandidateGroupsAssignedToCandidate(candidateID);
        }

        public DataTable GetCandidateGroup()
        {
            CandidateGroupsDAL get = new CandidateGroupsDAL();
            return get.GetCandidateGroup();
        }

        public MySqlDataReader GetCandidateGroups()
        {
            CandidateGroupsDAL get = new CandidateGroupsDAL();
            return get.GetCandidateGroups();
        }
    }
}