using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for TrainingProjectBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class TrainingProjectBAL
    {
        public TrainingProjectBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public class respfortraining
        {
            public int projectId { get; set;}
            public int programId { get; set;}
            public int company_id { get; set;}
        };
        #region TRAINING PROJECT PARAMETERS
        public int TrainingProjectID
        {
            get;
            set;
        }

        public int CandidateID
        {
            get;
            set;
        }

        public int TrainingProgramID
        {
            get;
            set;
        }

        public int RecommndedTrainingProgramID
        {
            get;
            set;
        }
        public string StartDateTime
        {
            get;
            set;
        }

        public string EndDateTime
        {
            get;
            set;
        }

        public int BatchSize
        {
            get;
            set;
        }

        public int EmployeeID
        {
            get;
            set;
        }

        public string ProjectStatus
        {
            get;
            set;
        }

        public int ConfirmedToAttendTraining
        {
            get;
            set;
        }
        public int PassedEvaluation
        {
            get;
            set;
        }
        public int ConfirmedToAttendTrainingBeforeTrainingDay
        {
            get;
            set;
        }
        public int ActuallyStartedAttendingTraining
        {
            get;
            set;
        }

        public int CompletedTraining
        {
            get;
            set;
        }
        public int PassedTraining
        {
            get;
            set;
        }
        public string Grade
        {
            get;
            set;
        }

        public int ReceivedCertificate
        {
            get;
            set;
        }

        public int QualificationID
        {
            get;
            set;
        }

        public int NgoID
        {
            get;
            set;
        }

        public int CityID
        {
            get;
            set;
        }

        public int StateID
        {
            get;
            set;
        }

        public int DisabilityID
        {
            get;
            set;
        }

        public int RecommendedJobID
        {
            get;
            set;
        }

        public int RecommendedRoleID
        {
            get;
            set;
        }

        public int EmploymentStatus
        {
            get;
            set;
        }

        public int GroupID
        {
            get;
            set;
        }
        public int LangaugeID
        {
            get;
            set;
        }

        public int AgeGroup
        {
            get;
            set;
        }
        public string SearchFor
        {
            get;
            set;
        }
        public string SearchIn
        {
            get;
            set;
        }
        public string ProjectVenue
        {
            get;
            set;
        }

        public string ProjectDays
        {
            get;
            set;
        }

        public string ProjectType
        {
            get;
            set;
        }
        //reports
        public string DateType
        {
            get;
            set;
        }

        public string DateFrom
        {
            get;
            set;
        }

        public string DateTo
        {
            get;
            set;
        }

        public int status
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }
        public int Credited_to
        {
            get;
            set;
        }
        public IList<respfortraining> rft = new List<respfortraining>();
        #endregion

        public MySqlDataReader GetTrainingProjectDetails(string trainingProjectID)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            return get.GetTrainingProjectDetails(trainingProjectID);
        }

        //added to show training program instane
        public MySqlDataReader GetTrainingProgramInstance(string trainingProjectID)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            return get.GetTrainingProgramInstance(trainingProjectID);
        }

        public DataTable SearchOpenTrainingProjects(TrainingProjectBAL project)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            DataTable DtSearchCandidte = get.SearchOpenTrainingProjects(project);
            foreach (DataRow dr in DtSearchCandidte.Rows)
            {
                if (dr["training_project_id"].ToString().Contains("-1"))
                {
                    dr["start_date_time"] = "";
                    dr["end_date_time"] = "";
                    dr["start_time"] = "";
                    dr["candidates_assigned"] = "";
                    dr["total_candidates_passed"] = "";
                    dr["total_candidates_failed"] = "";
                }
                else
                {
                    dr["start_date_time"] = Convert.ToDateTime(dr["start_date_time"]).ToString(Global.GetDateFormat()) + " to ";
                    dr["end_date_time"] = Convert.ToDateTime(dr["end_date_time"]).ToString(Global.GetDateFormat());
                    dr["start_time"] = dr["start_time"] + " to ";
                    dr["candidates_assigned"] = dr["candidates_assigned"];
                    dr["total_candidates_passed"] = dr["total_candidates_passed"];
                    dr["total_candidates_failed"] = dr["total_candidates_failed"];
                }

            }
            return DtSearchCandidte;
        }

        public int AddTrainingProject(TrainingProjectBAL project)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL add = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            return add.AddTrainingProject(project);
        }

        public int UpdateTrainingProject(TrainingProjectBAL project)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL upd = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            return upd.UpdateTrainingProject(project);
        }

        public void DeleteCandidateAssignedToTrainingProject(MySqlCommand cmd, string trainingProjectID, string candidateID)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL proj = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            proj.DeleteCandidateAssignedToTrainingProject(cmd, trainingProjectID, candidateID);
        }

        public void AssignCandidateToTrainingProject(MySqlCommand cmd, string trainingProjectID, string candidateID)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL proj = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            proj.AssignCandidateToTrainingProject(cmd, trainingProjectID, candidateID);
        }

        public DataTable GetAssigneListCandidate(int trainingProjectID)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            DataTable dtAssignedListCandidates = get.GetAssigneListCandidate(trainingProjectID);
            foreach (DataRow dr in dtAssignedListCandidates.Rows)
            {
                dr["phone_numbers"] = dr["phone_numbers"].ToString().Replace(",", "\n");
            }
            return dtAssignedListCandidates;
        }

        public int UpdateCandidateAssignedList(MySqlCommand cmd, TrainingProjectBAL project)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL upd = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            return upd.UpdateCandidateAssignedList(cmd, project);
        }

        public int UpdateTrainingProjectStatus(MySqlCommand cmd, int trainingProjectID)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL upd = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            return upd.UpdateTrainingProjectStatus(cmd, trainingProjectID);
        }

        public DataTable SearchNonRecommenededCandidate(TrainingProjectBAL project)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            DataSet dsSearchNonRecommenededCandidate = get.SearchNonRecommenededCandidate(project);
            DataTable dtSearchNonRecommenededCandidate = dsSearchNonRecommenededCandidate.Tables[0];
            foreach (DataRow dr in dtSearchNonRecommenededCandidate.Rows)
            {
                dr["phone_numbers"] = dr["phone_numbers"].ToString().Replace(",", Environment.NewLine);
                dr["email_address"] = dr["email_address"].ToString().Replace(",", Environment.NewLine);
            }
            Global.SetGridPageCount(dsSearchNonRecommenededCandidate.Tables[1].Rows[0]["total_rows"]);

            return dtSearchNonRecommenededCandidate;
        }

        public int CheckDuplication(int candidateID, int trainingProjectID)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            return get.CheckDuplication(candidateID, trainingProjectID);
        }

        public int CheckCandidateAssigned(int trainingProjectID)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            return get.CheckCandidateAssigned(trainingProjectID);
        }
        public bool AddNotes(int candidateID, int trainingProjectID, string notes)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            int rowsAdded = get.AddNotes(candidateID, trainingProjectID, notes);
            if (rowsAdded.Equals(0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public DataTable GetCandidateWithNotes(int trainingProjectID)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            return get.GetCandidateWithNotes(trainingProjectID);
        }

        public int CheckDuplicationNote(int candidateID)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            return get.CheckDuplicationNote(candidateID);
        }
        public DataTable GetTrainingProjectInReports(TrainingProjectBAL project, ref int[] projectTypes)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            DataTable dtTrainingProject = get.GetTrainingProjectInReports(project);
            dtTrainingProject.Columns.Add("timings");
            foreach (DataRow dr in dtTrainingProject.Rows)
            {
                dr["timings"] = dr["start_time"].ToString() + " to " + dr["end_time"].ToString();

                if (Convert.ToBoolean(dr["project_status"]))
                {
                    //To count closed projects
                    projectTypes[0]++;
                }
                else
                {
                    //To count open projects
                    projectTypes[1]++;
                }
            }
            return dtTrainingProject;
        }

        public MySqlDataReader GetAllTrainingProjects()
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            return get.GetAllTrainingProjects();
        }

        public MySqlDataReader GetTrainingProjects()
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            return get.GetTrainingProjects();
        }

        public MySqlDataReader GetTrainProjForRejectionDataCandidates()
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            return get.GetTrainProjForRejectionDataCandidates();
        }

        public DataTable GetOwnerwiseTrainingWorkDistribution(TrainingProjectBAL project)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            return get.GetOwnerwiseTrainingWorkDistribution(project);
        }
        public DataTable GetAssigneListForClosedTrainingProject(TrainingProjectBAL project)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            DataTable dtAssignedListCandidates = get.GetAssigneListForClosedTrainingProject(project);
            foreach (DataRow dr in dtAssignedListCandidates.Rows)
            {
                dr["phone_numbers"] = dr["phone_numbers"].ToString().Replace(",", "\n");
            }
            return dtAssignedListCandidates;
        }
        public MySqlDataReader GetTrainingProjectResponsibleBAL(TrainingProjectBAL project)
        {
            EnableIndia.App_Code.DAL.TrainingProjectDAL get = new EnableIndia.App_Code.DAL.TrainingProjectDAL();
            return (MySqlDataReader)get.GetTrainingProjectResponsibleDAL(project);
        }
    }
}
