using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for EmploymentProjectBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class EmploymentProjectBAL
    {
        public EmploymentProjectBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region EMPLOYMENT PROJECT PARAMETERS
        public int EmploymentProjectID
        {
            get;
            set;
        }

        public int ParentCompanyID
        {
            get;
            set;
        }

        public int CompanyID
        {
            get;
            set;
        }

        public int VacancyID
        {
            get;
            set;
        }

        public string PossibleStartDate
        {
            get;
            set;
        }

        public string PossibleEndDate
        {
            get;
            set;
        }

        public int CurrentDemandOfPeople
        {
            get;
            set;
        }

        public string Designation
        {
            get;
            set;
        }

        public string ProjectType
        {
            get;
            set;
        }

        public decimal Salary
        {
            get;
            set;
        }

        public int EmployeeID
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public int JobID
        {
            get;
            set;
        }

        public int JobRoleID
        {
            get;
            set;
        }

        public string Responsibilities
        {
            get;
            set;
        }
        public string InterventionRequired
        {
            get;
            set;
        }

        public string WorkingDays
        {
            get;
            set;
        }

        public string HasShifts
        {
            get;
            set;
        }

        public string WorkingHours
        {
            get;
            set;
        }

        public string HolidayLeavePolicy
        {
            get;
            set;
        }

        public string CompanyCode
        {
            get;
            set;
        }

        public string VacancyCode
        {
            get;
            set;
        }

        public string ProjectStatus
        {
            get;
            set;
        }

        public int StateID
        {
            get;
            set;
        }

        public int CityID
        {
            get;
            set;
        }
        //Search Parameters
        public string PossibleStartDateFrom
        {
            get;
            set;
        }

        public string PossibleStartDateTo
        {
            get;
            set;
        }

        public string PossibleEndDateFrom
        {
            get;
            set;
        }

        public string PossibleEndDateTo
        {
            get;
            set;
        }

        public int CandidateID
        {
            get;
            set;
        }

        public int InterestedInJob
        {
            get;
            set;
        }

        public int CertificatesVerified
        {
            get;
            set;
        }

        public int ProfileSent
        {
            get;
            set;
        }

        public int InterviewScheduled
        {
            get;
            set;
        }

        public int ConfirmedForInterview
        {
            get;
            set;
        }

        public int PreparedForInterview
        {
            get;
            set;
        }

        public int InterviewSupportRequired
        {
            get;
            set;
        }
        public int InterviewProcessCompleted
        {
            get;
            set;
        }

        public int GotJob
        {
            get;
            set;
        }

        public int CandidateInformedAcceptedJob
        {
            get;
            set;
        }

        public int OfferLetterReceived
        {
            get;
            set;
        }

        public int EmploymentProofReceived
        {
            get;
            set;
        }

        public int WorkPlaceSolutionToBeDone
        {
            get;
            set;
        }


        public string InterviewDate
        {
            get;
            set;
        }


        public string InterviewTime
        {
            get;
            set;
        }

        public string PostInterviewDate
        {
            get;
            set;
        }

        public string PostInterviewTime
        {
            get;
            set;
        }

        public string InterpreterName
        {
            get;
            set;

        }

        public string InterpreterDetail
        {
            get;
            set;
        }

        public string NoteComments
        {
            get;
            set;
        }

        //REPORT PARAMETERS
        public string EmploymentDateStartDateFrom
        {
            get;
            set;
        }

        public string EmploymentDateStartDateTo
        {
            get;
            set;
        }

        public string EmploymentDateEndDateFrom
        {
            get;
            set;
        }

        public string EmploymentDateEndDateTo
        {
            get;
            set;
        }

        public int GroupID
        {
            get;
            set;
        }
        #endregion

        public MySqlDataReader GetEmploymentProjects()
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL get = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            return get.GetEmploymentProjects();
        }

        public MySqlDataReader GetEmploymentProjectDetails(string employmentProjectID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL get = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            return get.GetEmploymentProjectDetails(employmentProjectID);
        }

        public MySqlDataReader GetEmploymentProjectNameDetail()
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL get = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            return get.GetEmploymentProjectNameDetail();
        }

        public int UpdateCandidateAssignedList(MySqlCommand cmd, EmploymentProjectBAL emplProj)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL upd = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            return upd.UpdateCandidateAssignedList(cmd, emplProj);
        }

        public DataTable GetCandidatesAssignedToEmploymentProjects(string employmentProjectID, int pagesize)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL get = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            DataSet dsAssignedCandidates = get.GetcandidatesAssigenedToEmploymentProject(employmentProjectID, (Convert.ToInt32(HttpContext.Current.Request.Cookies["grid_page_number"].Value) - 1), pagesize);
            DataTable dtAssignedCandidates = dsAssignedCandidates.Tables[0];
            foreach (DataRow dr in dtAssignedCandidates.Rows)
            {
                dr["phone_numbers"] = dr["phone_numbers"].ToString().Replace(",", "<br/>");
            }
            if (HttpContext.Current.Request.Cookies["grid_page_count"] != null)
            {
                HttpContext.Current.Response.Cookies["grid_page_count"].Value = Math.Ceiling((Convert.ToDouble(dsAssignedCandidates.Tables[1].Rows[0]["total_rows"])) / 25).ToString();
            }
            return dtAssignedCandidates;
        }

        public DataTable GetCandidatesAssignedToEmploymentProjectsReader(string employmentProjectID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL get = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            return get.GetCandidatesAssignedToEmploymentProjectsReader(employmentProjectID);
        }

        public string AddEmploymentProject(MySqlCommand cmd, EmploymentProjectBAL emplProj)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL add = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            return add.AddEmploymentProject(cmd, emplProj);
        }

        public void UpdateEmploymentProject(MySqlCommand cmd, EmploymentProjectBAL emplProj)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL upd = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            upd.UpdateEmploymentProject(cmd, emplProj);
        }

        public DataTable SearchOpenEmploymentProjects(EmploymentProjectBAL search)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL get = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            return get.SearchOpenEmploymentProjects(search);
        }

        public void AssignCandidateToEmploymentProject(MySqlCommand cmd, string employmentProjectID, string candidateID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL proj = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            proj.AssignCandidateToEmploymentProject(cmd, employmentProjectID, candidateID);
        }

        public void DeleteAssignedCandidate(MySqlCommand cmd, string empProjectGroupID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL proj = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            proj.DeleteAssignedCandidate(cmd, empProjectGroupID);
        }

        #region UPDATE PARAMETERS
        public void AddEmploymentProjectDisabilitySubTypes(MySqlCommand cmd, string employmentProjectID, string disabilityID, string disabilitySubTypeID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            emp.AddEmploymentProjectDisabilitySubTypes(cmd, employmentProjectID, disabilityID, disabilitySubTypeID);
        }

        public void AddEmploymentProjectEducationalQualifications(MySqlCommand cmd, string employmentProjectID, string courseQualificationID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            emp.AddEmploymentProjectEducationalQualifications(cmd, employmentProjectID, courseQualificationID);
        }

        public void AddEmploymentProjectTrainingPrograms(MySqlCommand cmd, string employmentProjectID, string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            emp.AddEmploymentProjectTrainingPrograms(cmd, employmentProjectID, trainingProgramID);
        }

        public void AddEmploymentProjectRequiredLanguages(MySqlCommand cmd, string employmentProjectID, string languageID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            emp.AddEmploymentProjectRequiredLanguages(cmd, employmentProjectID, languageID);
        }

        public void AddEmploymentProjectConsideredCandidateGroups(MySqlCommand cmd, string employmentProjectID, string candidateGroupID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            emp.AddEmploymentProjectConsideredCandidateGroups(cmd, employmentProjectID, candidateGroupID);
        }
        #endregion

        #region DELETE FUNCTIONS
        public void DeleteEmploymentProjectDisabilitySubTypes(MySqlCommand cmd, string employmentProjectID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            emp.DeleteEmploymentProjectDisabilitySubTypes(cmd, employmentProjectID);
        }

        public void DeleteEmploymentProjectEducationalQualifications(MySqlCommand cmd, string employmentProjectID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            emp.DeleteEmploymentProjectEducationalQualifications(cmd, employmentProjectID);
        }

        public void DeleteEmploymentProjectTrainingProgram(MySqlCommand cmd, string employmentProjectID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            emp.DeleteEmploymentProjectTrainingProgram(cmd, employmentProjectID);
        }

        public void DeleteEmploymentProjectLangauges(MySqlCommand cmd, string employmentProjectID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            emp.DeleteEmploymentProjectLangauges(cmd, employmentProjectID);
        }

        public void DeleteEmploymentProjectConsideredCandidateGroups(MySqlCommand cmd, string employmentProjectID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            emp.DeleteEmploymentProjectConsideredCandidateGroups(cmd, employmentProjectID);
        }
        #endregion

        #region GET PARAMETERS
        public DataTable GetEmploymentProjectDisabilitySubTypes(string employmentProjectID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            return emp.GetEmploymentProjectDisabilitySubTypes(employmentProjectID);
        }

        public DataTable GetEmploymentProjectEducationalQualifications(string employmentProjectID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            return emp.GetEmploymentProjectEducationalQualifications(employmentProjectID);
        }

        public DataTable GetEmploymentProjectTrainingPrograms(string employmentProjectID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            return emp.GetEmploymentProjectTrainingPrograms(employmentProjectID);
        }

        public DataTable GetEmploymentProjectRequiredLanguages(string employmentProjectID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            return emp.GetEmploymentProjectRequiredLanguages(employmentProjectID);
        }

        public DataTable GetEmploymentProjectConsideredCandidateGroups(string employmentProjectID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            return emp.GetEmploymentProjectConsideredCandidateGroups(employmentProjectID);
        }
        #endregion

        public bool AddEmploymentProjectNotes(EmploymentProjectBAL addNotes)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL emp = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            int rowAdded = emp.AddEmploymentProjectNotes(addNotes);
            if (rowAdded.Equals(0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public DataTable GetCandidateWithNotes(string employmentProjectID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL get = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            DataTable dtCanddidateNote = get.GetCandidateWithNotes(employmentProjectID);
            dtCanddidateNote.Columns.Add("str_notes");

            foreach (DataRow dr in dtCanddidateNote.Rows)
            {
                string strNotes = string.Empty;
                if (!dr["interview_date"].ToString().Contains("1900"))
                {
                    strNotes += "Interview Date :" + Convert.ToDateTime(dr["interview_date"]).ToString(Global.GetDateFormat()) + "</br>";
                }

                if (!dr["note_interview_time"].ToString().Contains("00"))
                {
                    strNotes += " time :" + dr["note_interview_time"].ToString() + "</br>";
                }

                if (!dr["interpreter_name"].ToString().Equals(""))
                {
                    strNotes += " interpreter name :" + dr["interpreter_name"].ToString() + "</br>";
                }

                if (!dr["interpreter_contact_details"].ToString().Equals(""))
                {
                    strNotes += " Contact details :" + dr["interpreter_contact_details"].ToString() + "</br>";
                }

                if (!dr["post_interview_date"].ToString().Contains("1900"))
                {
                    strNotes += " Date For Post Interview follow up with Company:" + Convert.ToDateTime(dr["post_interview_date"]).ToString(Global.GetDateFormat()) + "</br>";
                }

                if (!dr["note_post_interview_time"].ToString().Contains("00"))
                {
                    strNotes += " time :" + dr["note_post_interview_time"].ToString() + "</br>";
                }

                if (!dr["comments"].ToString().Equals(""))
                {
                    strNotes += " " + dr["comments"].ToString() + "</br>";
                }

                dr["str_notes"] = strNotes;
            }
            return dtCanddidateNote;
        }

        public int UpdateEmploymentProjectStatus(MySqlCommand cmd, int employmentProjectID)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL upd = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            return upd.UpdateEmploymentProjectStatus(cmd, employmentProjectID);
        }

        public DataTable GetEmploymentProjectsWithEmploymentStatus(EmploymentProjectBAL emplProj, ref int[] projectTypes)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL dlProj = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            DataTable dtEmploymentProject = dlProj.GetEmploymentProjectsWithEmploymentStatus(emplProj);
            dtEmploymentProject.Columns.Add("project_types");
            foreach (DataRow dr in dtEmploymentProject.Rows)
            {
                if(!System.DBNull.Value.Equals(dr["project_status"]))
                {
                    if (Convert.ToBoolean(dr["project_status"]))
                    {
                        //To count closed projects
                        projectTypes[0]++;
                    }
                }
                else
                {
                    //To count open projects
                    projectTypes[1]++;
                }
                if (dr["project_status"].ToString() == "1")
                {
                    dr["project_types"] = "Closed";
                }
                else
                {
                    dr["project_types"] = "Open";
                }
            }
            return dtEmploymentProject;
        }

        public DataTable GetAssignedListForClosedEmploymentProject(EmploymentProjectBAL empProj)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL dlProj = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            DataTable dtPorject = dlProj.GetAssignedListForClosedEmploymentProject(empProj);
            foreach (DataRow dr in dtPorject.Rows)
            {
                dr["phone_numbers"] = dr["phone_numbers"].ToString().Replace(",", Environment.NewLine);
            }
            return dtPorject;
        }

        public int GetEmploymentProjectIDFromName(string projectName)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL empProj = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            return empProj.GetEmploymentProjectIDFromName(projectName);
        }

        public int GetCompanyIDFromName(string projectName)
        {
            EnableIndia.App_Code.DAL.EmploymentProjectDAL empProj = new EnableIndia.App_Code.DAL.EmploymentProjectDAL();
            return empProj.GetCompanyIDFromName(projectName);
        }
    }
}