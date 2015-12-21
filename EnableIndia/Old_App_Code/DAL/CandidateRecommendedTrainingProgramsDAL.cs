using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CandidateRecommendedTrainingProgramsDAL
    /// </summary>
    public class CandidateRecommendedTrainingProgramsDAL
    {
        public CandidateRecommendedTrainingProgramsDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCandidteRecommendedTrainingPrograms(string candidateID)
        {
            string query = "select ";
            query += " prog.training_program_id,";
            query += " prog.training_program_name,";
            query += " if(cand_prog.training_program_id is null,0,1) as is_attached ";
            query += "from training_programs prog ";
            query += "left join(select training_program_id ";
            query += " from candidate_recommended_training_programs ";
            query += " where candidate_id=" + candidateID + ")as cand_prog on prog.training_program_id=cand_prog.training_program_id ";
            query += "order by training_program_name ";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public void DeleteCandidateRecommendedTrainingPrograms(MySqlCommand cmd, string candidateID)
        {
            cmd.CommandText = "delete from candidate_recommended_training_programs where candidate_id=" + candidateID + ";";
            cmd.CommandText += " call update_candidate_other_details(" + candidateID + ");";
            cmd.ExecuteNonQuery();
        }

        public void UpdateCandidateRecommendedTrainingPrograms(MySqlCommand cmd, string candidateID, string trainingProgramID)
        {
            cmd.CommandText = "insert into candidate_recommended_training_programs(candidate_id,training_program_id) values(" + candidateID;
            cmd.CommandText += "," + trainingProgramID + ");";
            cmd.CommandText += " call update_candidate_other_details(" + candidateID + ");";

            cmd.ExecuteNonQuery();
        }
    }
}