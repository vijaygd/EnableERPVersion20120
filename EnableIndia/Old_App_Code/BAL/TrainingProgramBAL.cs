using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for TrainingProgramBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class TrainingProgramBAL
    {
        public TrainingProgramBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string TrainingProgramName
        {
            get;
            set;
        }

        public string TrainingProgramID
        {
            get;
            set;
        }
        #region GET FUNCTIONS
        //check duplication Program Name
        public int CheckDuplicationProgramName(string trainingProgramName, string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL get = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            return get.CheckDuplicationProgramName(trainingProgramName, trainingProgramID);
        }
        public DataTable GetTraningProgram()
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL get = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            return get.GetTraningProgram();
        }
        public MySqlDataReader GetTrainingProgramDetails(string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL get = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            return get.GetTrainingProgramDetails(trainingProgramID);
        }

        public DataTable GetTrainingProgramEligibleDisabilities(string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL get = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            return get.GetTrainingProgramEligibleDisabilities(trainingProgramID);
        }

        public DataTable GetTrainingProgramEligibleJobs(string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL get = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            return get.GetTrainingProgramEligibleJobs(trainingProgramID);
        }

        public DataTable GetTrainingProgramEligibleCandidateGroups(string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL get = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            return get.GetTrainingProgramEligibleCandidateGroups(trainingProgramID);
        }

        public DataTable GetTrainingProgramEligibleQualifications(string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL get = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            return get.GetTrainingProgramEligibleQualifications(trainingProgramID);
        }

        public DataTable GetTrainingProgramRecommendedRoles(string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL get = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            return get.GetTrainingProgramRecommendedRoles(trainingProgramID);
        }

        public DataTable GetTrainingProgramRequiredLanguages(string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL get = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            return get.GetTrainingProgramRequiredLanguages(trainingProgramID);
        }

        public DataTable GetTrainingProgramRequiredForTrainingPrograms(string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL get = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            DataTable dtRequiredTraingProgramm = get.GetTrainingProgramRequiredForTrainingPrograms(trainingProgramID);
            foreach (DataRow dr in dtRequiredTraingProgramm.Rows)
            {
                if (dr["training_program_id"].ToString().Contains(trainingProgramID))
                {
                    dr.Delete();
                }
            }

            return dtRequiredTraingProgramm;
        }
        #endregion

        public string AddTrainingProgram(MySqlCommand cmd, string trainingProgramName, string comments)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL add = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            return add.AddTrainingProgram(cmd, trainingProgramName, comments);
        }

        public void UpdateTrainingProgram(MySqlCommand cmd, string trainingProgramName, string comments, string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL upd = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            upd.UpdateTrainingProgram(cmd, trainingProgramName, comments, trainingProgramID);
        }

        #region UPDATE FUNCTIONS
        public void UpdateTrainingProgramEligibleDisabilities(MySqlCommand cmd, string trainingProgramID, string disabilityID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL program = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            program.UpdateTrainingProgramEligibleDisabilities(cmd, trainingProgramID, disabilityID);
        }

        public void UpdateTrainingProgramEligibleJobs(MySqlCommand cmd, string trainingProgramID, string jobID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL program = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            program.UpdateTrainingProgramEligibleJobs(cmd, trainingProgramID, jobID);
        }

        public void UpdateTrainingProgramEligibleCandidateGroups(MySqlCommand cmd, string trainingProgramID, string groupID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL program = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            program.UpdateTrainingProgramEligibleCandidateGroups(cmd, trainingProgramID, groupID);
        }

        public void UpdateTrainingProgramEligibleQualifications(MySqlCommand cmd, string trainingProgramID, string qualificationID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL program = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            program.UpdateTrainingProgramEligibleQualifications(cmd, trainingProgramID, qualificationID);
        }

        public void UpdateTrainingProgramRecommendedRoles(MySqlCommand cmd, string trainingProgramID, string jobRoleID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL program = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            program.UpdateTrainingProgramRecommendedRoles(cmd, trainingProgramID, jobRoleID);
        }

        public void UpdateTrainingProgramRequiredLanguages(MySqlCommand cmd, string trainingProgramID, string languageID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL program = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            program.UpdateTrainingProgramRequiredLanguages(cmd, trainingProgramID, languageID);
        }

        public void UpdateTrainingProgramRequiredForTrainingPrograms(MySqlCommand cmd, string trainingProgramID, string requiredTrainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL program = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            program.UpdateTrainingProgramRequiredForTrainingPrograms(cmd, trainingProgramID, requiredTrainingProgramID);
        }
        #endregion

        #region DELETE FUNCTIONS
        public void DeleteTrainingProgramEligibleDisabilities(MySqlCommand cmd, string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL program = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            program.DeleteTrainingProgramEligibleDisabilities(cmd, trainingProgramID);
        }

        public void DeleteTrainingProgramEligibleJobs(MySqlCommand cmd, string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL program = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            program.DeleteTrainingProgramEligibleJobs(cmd, trainingProgramID);
        }

        public void DeleteTrainingProgramEligibleCandidateGroups(MySqlCommand cmd, string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL program = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            program.DeleteTrainingProgramEligibleCandidateGroups(cmd, trainingProgramID);
        }

        public void DeleteTrainingProgramEligibleQualifications(MySqlCommand cmd, string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL program = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            program.DeleteTrainingProgramEligibleQualifications(cmd, trainingProgramID);
        }

        public void DeleteTrainingProgramRecommendedRoles(MySqlCommand cmd, string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL program = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            program.DeleteTrainingProgramRecommendedRoles(cmd, trainingProgramID);
        }

        public void DeleteTrainingProgramRequiredLanguages(MySqlCommand cmd, string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL program = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            program.DeleteTrainingProgramRequiredLanguages(cmd, trainingProgramID);
        }

        public void DeleteTrainingProgramRequiredForTrainingPrograms(MySqlCommand cmd, string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL program = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            program.DeleteTrainingProgramRequiredForTrainingPrograms(cmd, trainingProgramID);
        }
        #endregion
        public DataTable GetTrainingProgramReports()
        {
            EnableIndia.App_Code.DAL.TrainingProgramDAL program = new EnableIndia.App_Code.DAL.TrainingProgramDAL();
            return program.GetTrainingProgramsReports();
        }
    }
}
