using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for CandidateKnowledgeTrainingBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CandidateKnowledgeTrainingBAL
    {
        public CandidateKnowledgeTrainingBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetCandidateKnowledgeTrainingDetails(string candidateID)
        {
            CandidateKnowledgeTrainingDAL get = new CandidateKnowledgeTrainingDAL();
            return get.GetCandidateKnowledgeTrainingDetails(candidateID);
        }

        public MySqlDataReader GetCandidateTrainingDetails(string candidateID)
        {
            CandidateKnowledgeTrainingDAL get = new CandidateKnowledgeTrainingDAL();
            return get.GetCandidateTrainingDetails(candidateID);
        }
    }
}