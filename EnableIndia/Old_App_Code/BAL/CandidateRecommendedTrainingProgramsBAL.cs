using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for CandidateRecommendedTrainingProgramsBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CandidateRecommendedTrainingProgramsBAL
    {
        public CandidateRecommendedTrainingProgramsBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCandidteRecommendedTrainingPrograms(string candidateID)
        {
            EnableIndia.App_Code.DAL.CandidateRecommendedTrainingProgramsDAL get = new EnableIndia.App_Code.DAL.CandidateRecommendedTrainingProgramsDAL();
            return get.GetCandidteRecommendedTrainingPrograms(candidateID);
        }

        public void DeleteCandidateRecommendedTrainingPrograms(MySqlCommand cmd, string candidateID)
        {
            EnableIndia.App_Code.DAL.CandidateRecommendedTrainingProgramsDAL prog = new EnableIndia.App_Code.DAL.CandidateRecommendedTrainingProgramsDAL();
            prog.DeleteCandidateRecommendedTrainingPrograms(cmd, candidateID);
        }

        public void UpdateCandidateRecommendedTrainingPrograms(MySqlCommand cmd, string candidateID, string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.CandidateRecommendedTrainingProgramsDAL prog = new EnableIndia.App_Code.DAL.CandidateRecommendedTrainingProgramsDAL();
            prog.UpdateCandidateRecommendedTrainingPrograms(cmd, candidateID, trainingProgramID);
        }
    }
}