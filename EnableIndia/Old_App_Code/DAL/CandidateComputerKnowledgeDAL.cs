using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CandidateComputerKnowledgeDAL
    /// </summary>
    public class CandidateComputerKnowledgeDAL
    {
        public CandidateComputerKnowledgeDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCanddiateComputerKnowledge(string candidateID)
        {
            string query = "select ";
            query += "	comp_knowl.computer_knowledge_id,";
            query += "	comp_knowl.computer_knowledge_type,";
            query += "	if(cand_comp_knowl.computer_knowledge_id is null,0,1) as is_attached ";
            query += "from computer_knowledge comp_knowl ";
            query += "left join(select computer_knowledge_id ";
            query += "			from candidate_computer_knowledge ";
            query += "			where candidate_id=" + candidateID;
            query += "          ) as cand_comp_knowl on comp_knowl.computer_knowledge_id=cand_comp_knowl.computer_knowledge_id ";
            query += "order by computer_knowledge_type";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }
    }

}