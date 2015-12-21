using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


/// <summary>
/// Summary description for CandidateComputerKnowledgeBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CandidateComputerKnowledgeBAL
    {
        public CandidateComputerKnowledgeBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCanddiateComputerKnowledge(string candidateID)
        {
            CandidateComputerKnowledgeDAL get = new CandidateComputerKnowledgeDAL();
            return get.GetCanddiateComputerKnowledge(candidateID);
        }
    }
}