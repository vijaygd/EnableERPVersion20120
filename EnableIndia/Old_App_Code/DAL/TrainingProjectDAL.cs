using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for TrainingProjectDAL
    /// </summary>
    public class TrainingProjectDAL
    {
        public class respfortraining
        {
            public int projectId { get; set; }
            public int programId { get; set; }
            public int company_id { get; set; }
        };
        IList<respfortraining> rft = new List<respfortraining>();
        public TrainingProjectDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetTrainingProjectDetails(string trainingProjectID)
        {
            string query = "select ";
            query += "  proj.*,";
            query += "  date_format(start_date_time,'%h:%i %p')as start_time, ";
            query += "	date_format(end_date_time,'%h:%i %p')as end_time ";
            query += "from training_projects proj ";
            query += "where training_project_id=" + trainingProjectID;

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        //added to Show training Programm instance

        public MySqlDataReader GetTrainingProgramInstance(string trainingProjectID)
        {
            string query = "call get_training_program_detail(" + trainingProjectID + ")";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataTable SearchOpenTrainingProjects(EnableIndia.App_Code.BAL.TrainingProjectBAL project)
        {
            try
            {
                string query = "search_open_training_projects";
                List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_training_program_id",Value=project.TrainingProgramID},
            new Parameter{Name="para_project_status",Value=project.ProjectStatus},
            new Parameter{Name="para_employee_id",Value=project.EmployeeID},
            new Parameter{Name="para_start_date",Value=project.StartDateTime},
            new Parameter{Name="para_end_date",Value=project.EndDateTime}
        };

                DBAccess dba = new DBAccess();
                return (DataTable)dba.ExecuteQuery(query, parameters, "DataTable");
            }
            catch (System.Exception ex)
            {
                DataTable dt = null;
                return dt;
            }
        }


        public int AddTrainingProject(EnableIndia.App_Code.BAL.TrainingProjectBAL project)
        {
            string query = "add_training_project";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_training_program_id",Value=project.TrainingProgramID},
            new Parameter{Name="para_start_date_time",Value=project.StartDateTime},
            new Parameter{Name="para_end_date_time",Value=project.EndDateTime},
            new Parameter{Name="para_batch_size",Value=project.BatchSize},
            new Parameter{Name="para_employee_id",Value=project.EmployeeID},
            new Parameter{Name="para_venue",Value=project.ProjectVenue},
            new Parameter{Name="para_days",Value=project.ProjectDays},
            new Parameter{Name="para_project_type",Value=project.ProjectType},
            new Parameter{Name="para_comments",Value=project.Comments},
        };

            DBAccess dba = new DBAccess();
            int trainingProjectId = Convert.ToInt32(dba.ExecuteQuery(query, parameters, "Scalar"));
            // Add multiple responsible persons introduced on 01.12.2015
            for(int i = 0;i < project.rft.Count;i++)
            {
                query = "Insert into trainingproject_credited_to (training_project_id, training_program_id, company_id) values (";
                query += trainingProjectId + ", " + project.rft[i].programId + ", " + project.rft[i].company_id + ")";
                dba.ExecuteQuery(query, null, "NonQuery");
            }
            return (trainingProjectId);
        }


        public DataSet SearchNonRecommenededCandidate(EnableIndia.App_Code.BAL.TrainingProjectBAL project)
        {
            string query = "search_non_recommended_candidate";

            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_training_project_id",Value=project.TrainingProjectID},
            new Parameter{Name="para_current_date",Value=DateTime.Now.ToString("yyyy/MM/dd")},
            new Parameter{Name="para_qualification_id",Value=project.QualificationID},
            new Parameter{Name="para_ngo_id",Value=project.NgoID},
            new Parameter{Name="para_state_id",Value=project.StateID},
            new Parameter{Name="para_city_id",Value=project.CityID},
            new Parameter{Name="para_recommended_training_program_id",Value=project.RecommndedTrainingProgramID},
            new Parameter{Name="para_disability_id",Value=project.DisabilityID},
            new Parameter{Name="para_recommended_job_type_id",Value=project.RecommendedJobID},
            new Parameter{Name="para_recommended_job_role_id",Value=project.RecommendedRoleID},
            new Parameter{Name="para_employment_status",Value=project.EmploymentStatus},
            new Parameter{Name="para_group_id",Value=project.GroupID},
            new Parameter{Name="para_langauge_id",Value=project.LangaugeID},
            new Parameter{Name="para_age_group",Value=project.AgeGroup},
            new Parameter{Name="para_search_for",Value=project.SearchFor},
            new Parameter{Name="para_search_in",Value=project.SearchIn},
            new Parameter{Name="para_page_number",Value=Convert.ToInt32(HttpContext.Current.Request.Cookies["grid_page_number"].Value) -1},
            new Parameter{Name="para_page_size",Value=Global.GetGridPageSize()}
        };

            DBAccess dba = new DBAccess();
            return (DataSet)dba.ExecuteQuery(query, parameters, "DataSet");
        }

        public int UpdateTrainingProject(EnableIndia.App_Code.BAL.TrainingProjectBAL project)
        {
            string query = "update_training_project";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_training_project_id",Value=project.TrainingProjectID},
            new Parameter{Name="para_training_program_id",Value=project.TrainingProgramID},
            new Parameter{Name="para_start_date_time",Value=project.StartDateTime},
            new Parameter{Name="para_end_date_time",Value=project.EndDateTime},
            new Parameter{Name="para_batch_size",Value=project.BatchSize},
            new Parameter{Name="para_employee_id",Value=project.EmployeeID},
            new Parameter{Name="para_venue",Value=project.ProjectVenue},
            new Parameter{Name="para_days",Value=project.ProjectDays},
            new Parameter{Name="para_project_type",Value=project.ProjectType},
            new Parameter{Name="para_comments",Value=project.Comments},
        };

            DBAccess dba = new DBAccess();
            int returnrows = (int)dba.ExecuteQuery(query, parameters, "NonQuery");
            // First check the persons who are already selected......
            // 
            query = "Select * from trainingproject_credited_to where training_project_id=" + project.TrainingProjectID;
            MySqlDataReader reader = (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
            int empId = 0;
            int j = 0;
            if (reader != null)
            {
                if (reader.HasRows)
                {
                    // Store in temp area since the reader can get closed....

                    while (reader.Read())
                    {
                        respfortraining rf = new respfortraining();
                        rf.programId = reader.GetInt32(0);
                        rf.projectId = reader.GetInt32(1);
                        rf.company_id = reader.GetInt32(2);
                        rft.Add(rf);
                    }
                    for (int n = 0; n < rft.Count; n++)
                    {
                        for (j = 0; j < project.rft.Count; j++)
                        {
                            if (project.rft[j].company_id == rft[n].company_id)
                            {
                                break;
                            }
                        }
                        if (j == project.rft.Count)
                        {
                            query = "Delete from trainingproject_credited_to where training_project_id=" + project.TrainingProjectID + " and company_id=" + rft[n].company_id;
                            dba.ExecuteQuery(query, null, "NonQuery");
                        }
                    }
                    reader.Close();
                    reader.Dispose();
                    reader = (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
                    if(reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                respfortraining rf = new respfortraining();
                                rf.programId = reader.GetInt32(0);
                                rf.projectId = reader.GetInt32(1);
                                rf.company_id = reader.GetInt32(2);
                                rft.Add(rf);
                            }
                            for (int n = 0; n < project.rft.Count; n++)
                            {
                                for (j = 0; j < rft.Count; j++)
                                {
                                    if (project.rft[n].company_id == rft[j].company_id)
                                    {
                                        break;
                                    }
                                }
                                if (j == rft.Count)
                                {
                                    query = "Insert into trainingproject_credited_to (training_project_id, training_program_id, company_id) values (";
                                    query += project.TrainingProjectID + ", " + project.TrainingProgramID + ", " + project.rft[n].company_id + ")";
                                    dba.ExecuteQuery(query, null, "NonQuery");
                                }
                            }
                        }
                    }

                }
                else
                {
                    for (int n = 0; n < project.rft.Count; n++)
                    {
                            query = "Insert into trainingproject_credited_to (training_project_id, training_program_id, company_id) values (";
                            query += project.TrainingProjectID + ", " + project.TrainingProgramID + ", " + project.rft[n].company_id + ")";
                            dba.ExecuteQuery(query, null, "NonQuery");
                    }

                }
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
            }
            return (returnrows);
        }

        public int UpdateCandidateAssignedList(MySqlCommand cmd, EnableIndia.App_Code.BAL.TrainingProjectBAL project)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "update_assigned_list";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("para_training_project_id", project.TrainingProjectID);
            cmd.Parameters.AddWithValue("para_candidate_id", project.CandidateID);
            cmd.Parameters.AddWithValue("para_confirmed_to_attend_training", project.ConfirmedToAttendTraining);
            cmd.Parameters.AddWithValue("para_passed_evaluation", project.PassedEvaluation);
            cmd.Parameters.AddWithValue("para_actually_started_attending_training", project.ActuallyStartedAttendingTraining);
            cmd.Parameters.AddWithValue("para_completed_training", project.CompletedTraining);
            cmd.Parameters.AddWithValue("para_passed_training", project.PassedTraining);
            cmd.Parameters.AddWithValue("para_grade", project.Grade);
            cmd.Parameters.AddWithValue("para_received_cretificate", project.ReceivedCertificate);

            return cmd.ExecuteNonQuery();
        }

        public void DeleteCandidateAssignedToTrainingProject(MySqlCommand cmd, string trainingProjectID, string candidateID)
        {
            cmd.CommandText = "delete from candidates_assigned_to_training_projects where training_project_id=" + trainingProjectID;
            cmd.CommandText += " and candidate_id=" + candidateID;
            cmd.ExecuteNonQuery();
        }

        public void AssignCandidateToTrainingProject(MySqlCommand cmd, string trainingProjectID, string candidateID)
        {
            cmd.CommandText = "insert into candidates_assigned_to_training_projects(training_project_id,candidate_id)values(" + trainingProjectID;
            cmd.CommandText += "," + candidateID + ");";
            cmd.CommandText += " CALL update_candidate_other_details(" + candidateID + "); ";
            cmd.ExecuteNonQuery();
        }

        public DataTable GetAssigneListCandidate(int trainingProjectID)
        {
            string query = "call get_assigned_list_candidates(" + trainingProjectID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public int UpdateTrainingProjectStatus(MySqlCommand cmd, int trainingProjectID)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "call update_training_project_status(" + trainingProjectID + ")";
            return cmd.ExecuteNonQuery();
        }

        public int CheckDuplication(int candidateID, int trainingProjectID)
        {
            string query = "select count(candidate_id) from candidates_assigned_to_training_projects ";
            query += " where is_candidate_deleted=0 and candidate_id=" + candidateID + " and training_project_id=" + trainingProjectID;

            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public int CheckCandidateAssigned(int trainingProjectID)
        {
            string query = "if not exists(select training_project_id) from candidates_assigned_to_training_projects ";
            query += " where training_project_id=" + trainingProjectID;

            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public int AddNotes(int candidateID, int trainingProjectID, string notes)
        {
            string query = "insert into candidate_notes(notes_date,candidate_id,training_project_id,notes) ";
            query += " values(\"" + DateTime.Today.ToString("yyyy/MM/dd") + "\"," + candidateID + "," + trainingProjectID + ",\"" + notes + "\")";
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }
        public int CheckDuplicationNote(int candidateID)
        {
            string query = "select count(notes_id) from candidate_notes ";
            query += " where candidate_id=" + candidateID;

            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public DataTable GetCandidateWithNotes(int trainingProjectID)
        {
            string query = "select  cand.*,";
            query += "concat(cand.first_name,'  ',cand.last_name) as candidate_name,";
            query += "note.* from candidates cand  ";
            query += "join candidate_notes note on cand.candidate_id=note.candidate_id where note.training_project_id=" + trainingProjectID + "";
            query += " order by note.notes_date desc ;";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetTrainingProjectInReports(EnableIndia.App_Code.BAL.TrainingProjectBAL project)
        {
            string query = "rpt_training_projects";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_project_status",Value=project.status},
            new Parameter{Name="para_training_program_id",Value=project.TrainingProgramID},
            new Parameter{Name="para_date_type",Value=project.DateType},
            new Parameter{Name="para_date_from",Value=project.DateFrom},
            new Parameter{Name="para_date_to",Value=project.DateTo},
            new Parameter{Name="para_managed_by",Value=project.EmployeeID},
            new Parameter{Name="para_credited_to", Value=project.Credited_to},
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameters, "DataTable");
        }

        public MySqlDataReader GetAllTrainingProjects()
        {
            string query = "select * from training_projects";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public MySqlDataReader GetTrainingProjects()
        {
            string query = "select * from training_projects where is_closed=1";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public MySqlDataReader GetTrainProjForRejectionDataCandidates()
        {
            string query = "select * from training_projects   ;";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataTable GetOwnerwiseTrainingWorkDistribution(EnableIndia.App_Code.BAL.TrainingProjectBAL project)
        {
            string query = "rpt_get_ownerwise_training_work_distribution";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_status",Value=project.ProjectStatus},
            new Parameter{Name="para_training_program_id",Value=project.TrainingProgramID},
            new Parameter{Name="para_training_project_id",Value=project.TrainingProjectID},
            new Parameter{Name="para_date_type",Value=project.DateType},
            new Parameter{Name="para_date_from",Value=project.DateFrom},
            new Parameter{Name="para_date_to",Value=project.DateTo}
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameters, "DataTable");
        }

        public DataTable GetAssigneListForClosedTrainingProject(EnableIndia.App_Code.BAL.TrainingProjectBAL project)
        {
            string query = "rpt_get_assigned_list_closed_training_project";
            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_training_program_id",Value=project.TrainingProgramID},
            new Parameter{Name="para_training_project_id",Value=project.TrainingProjectID},
        };

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, parameters, "DataTable");
        }
        public MySqlDataReader GetTrainingProjectResponsibleDAL(EnableIndia.App_Code.BAL.TrainingProjectBAL project)
        {
            DBAccess dba = new DBAccess();
            string query = "Select * from trainingproject_credited_to where training_project_id=" +  project.TrainingProjectID;
            return(MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");

        }
    }
}