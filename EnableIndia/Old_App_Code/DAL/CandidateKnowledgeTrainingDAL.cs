using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CandidateKnowledgeTrainingDAL
    /// </summary>
    public class CandidateKnowledgeTrainingDAL
    {
        public CandidateKnowledgeTrainingDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetCandidateKnowledgeTrainingDetails(string candidateID)
        {
            string query = " call get_candidate_knowlwdge_training_detail(" + candidateID + ");";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public MySqlDataReader GetCandidateTrainingDetails(string candidateID)
        {
            string query = "select ";
            query += " train_prog.training_program_name,";
            query += " if(cand_ass_proj.grade=-2,'',cand_ass_proj.grade) as cand_grade,";
            query += " train_proj.training_project_name,";
            query += " EXTRACT(YEAR FROM train_proj.start_date_time)AS training_passed_year";
            query += " from candidates cand";
            query += " join(select * from candidates_assigned_to_training_projects";
            query += " where candidate_id=" + candidateID + " and passed_training=1) as cand_ass_proj";
            query += " on cand_ass_proj.candidate_id=cand.candidate_id";
            query += " join training_projects train_proj on train_proj.training_project_id=cand_ass_proj.training_project_id";
            query += " join training_programs train_prog on train_proj.training_program_id=train_prog.training_program_id";
            query += " where train_proj.is_closed=1 and cand_ass_proj.passed_training=1;";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }
    }
}