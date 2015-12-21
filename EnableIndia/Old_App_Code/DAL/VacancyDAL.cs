using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for VacancyDAL
    /// </summary>
    public class VacancyDAL
    {
        public VacancyDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public Global gs = new Global();
        public int CheckForDuplicateVacancy(string vacancyID, string vacancyName)
        {
            string query = "select count(vacancy_id) from vacancies where vacancy_name=\"" + vacancyName + "\"";
            if (!vacancyID.Equals("-2"))
            {
                query += " and vacancy_id!=" + vacancyID;
            }

            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        #region GET FUNCTIONS
        public MySqlDataReader GetVacancyCodes()
        {
            string query = "select vacancy_id,vacancy_name from vacancies ";
            //query += "where (parent_company_id=" + parentCompanyID + " or " + parentCompanyID + "=-1) ";
            //query += "and (company_id=" + companyID + " or " + companyID + "=-1) ";
            query += " order by vacancy_name ";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public MySqlDataReader GetVacancyDetails(string vacancyID)
        {
            string query = "select jobs.job_name,job_roles.job_role_name,vac.* ";
            query += "from vacancies vac ";
            query += "join jobs on vac.job_id = jobs.job_id ";
            query += "left join job_roles ON vac.job_role_id = job_roles.job_role_id ";
            query += "where (vac.vacancy_id=" + vacancyID + " or " + vacancyID + "=-1)";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataTable GetVacancyDisabilitySubTypes(string vacancyID)
        {
            string query = "call get_vacancy_disability_sub_types(" + vacancyID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetVacancyEducationalQualifications(string vacancyID)
        {
            string query = "call get_vacancy_educational_qualifications(" + vacancyID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetVacancyTrainingPrograms(string vacancyID)
        {
            string query = "call get_vacancy_training_programs(" + vacancyID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetVacancyRequiredLanguages(string vacancyID)
        {
            string query = "call get_vacancy_required_languages(" + vacancyID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetVacancyConsideredCandidateGroups(string vacancyID)
        {
            string query = "call get_vacancy_considered_canddiate_groups(" + vacancyID + ")";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetVacancyReport(EnableIndia.App_Code.BAL.VacancyBAL vacancy)
        {
            string query = "call rpt_list_vacancies()";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }
        #endregion

        public string AddVacancy(MySqlCommand cmd, EnableIndia.App_Code.BAL.VacancyBAL vacancy)
        {

            //string query = "add_vacancy";
            cmd.Parameters.AddWithValue("para_vacancy_date", DateTime.Now.ToString("yyyy/MM/dd"));
            cmd.Parameters.AddWithValue("para_vacancy_name", vacancy.VacancyName);
            cmd.Parameters.AddWithValue("para_job_id", vacancy.JobID);
            cmd.Parameters.AddWithValue("para_job_role_id", vacancy.JobRoleID);
            cmd.Parameters.AddWithValue("para_monthly_salary", vacancy.MonthlySalary);
            cmd.Parameters.AddWithValue("para_vacancy_code", vacancy.VacancyCode);
            cmd.Parameters.AddWithValue("para_responsibilities", vacancy.Responsibilities);
            cmd.Parameters.AddWithValue("para_intervention_required", vacancy.InterventionedRequired);
            cmd.Parameters.AddWithValue("para_working_days", vacancy.WorkingDays);
            cmd.Parameters.AddWithValue("para_has_shifts", vacancy.HasShifts);
            cmd.Parameters.AddWithValue("para_working_hours", vacancy.WorkingHours);
            cmd.Parameters.AddWithValue("para_holiday_leave_policy", vacancy.HolidayAndLeavePolicy);
            IList<string> paras = new List<string>();
            foreach (var p in cmd.Parameters)
            {
                paras.Add(p + ", ");
            }
            //Global.createAuditTrial("Vacancy", "Insert", "", paras, "Insert", HttpContext.Current.Session["username"].ToString());
            return cmd.ExecuteScalar().ToString();
        }

        #region UPDATE FUNCTIONS
        public void UpdateVacancyDisabilitySubTypes(MySqlCommand cmd, string vacancyID, string disabilityID, string disabilitySubTypeID)
        {
            cmd.CommandText = "insert into vacancy_accepted_disability_sub_types(vacancy_id,disability_id,disability_sub_type_id)values(";
            cmd.CommandText += vacancyID + "," + disabilityID + "," + disabilitySubTypeID + ")";
            cmd.ExecuteNonQuery();
        //    Global.createAuditTrial("Vacancy", cmd.CommandText, "", null, "Insert", HttpContext.Current.Session["username"].ToString());
        }

        public void UpdateVacancyEducationalQualifications(MySqlCommand cmd, string vacancyID, string courseQualificationID)
        {
            cmd.CommandText = "insert into vacancy_required_qualifications(vacancy_id,course_qualification_id)values(";
            cmd.CommandText += vacancyID + "," + courseQualificationID + ")";
            cmd.ExecuteNonQuery();
          //  Global.createAuditTrial("Vacancy", cmd.CommandText, "", null, "Insert", HttpContext.Current.Session["username"].ToString());
        }

        public void UpdateVacancyTrainingPrograms(MySqlCommand cmd, string vacancyID, string trainingProgramID)
        {
            cmd.CommandText = "insert into vacancy_training_programs(vacancy_id,training_program_id)values(" + vacancyID + "," + trainingProgramID + ")";
            cmd.ExecuteNonQuery();
            //Global.createAuditTrial("Vacancy", cmd.CommandText, "", null, "Insert", HttpContext.Current.Session["username"].ToString());
        }

        public void UpdateVacancyRequiredLanguages(MySqlCommand cmd, string vacancyID, string languageID)
        {
            cmd.CommandText = "insert into vacancy_required_languages(vacancy_id,language_id)values(" + vacancyID + "," + languageID + ")";
            cmd.ExecuteNonQuery();
          //  Global.createAuditTrial("Vacancy", cmd.CommandText, "", null, "Insert", HttpContext.Current.Session["username"].ToString());
        }

        public void UpdateVacancyConsideredCandidateGroups(MySqlCommand cmd, string vacancyID, string candidateGroupID)
        {
            cmd.CommandText = "insert into vacancy_considered_candidate_groups(vacancy_id,group_id)values(" + vacancyID + ",";
            cmd.CommandText += candidateGroupID + ")";
            cmd.ExecuteNonQuery();
         //   Global.createAuditTrial("Vacancy", cmd.CommandText, "", null, "Insert", HttpContext.Current.Session["username"].ToString());
        }
        #endregion

        public void UpdateVacancy(MySqlCommand cmd, EnableIndia.App_Code.BAL.VacancyBAL vacancy)
        {
            //string query = "update_vacancy";
            cmd.Parameters.AddWithValue("para_vacancy_id", vacancy.VacancyID);
            //cmd.Parameters.AddWithValue("para_vacancy_date",vacancy.VacancyDate);
            cmd.Parameters.AddWithValue("para_vacancy_name", vacancy.VacancyName);
            cmd.Parameters.AddWithValue("para_job_id", vacancy.JobID);
            cmd.Parameters.AddWithValue("para_job_role_id", vacancy.JobRoleID);
            cmd.Parameters.AddWithValue("para_monthly_salary", vacancy.MonthlySalary);
            cmd.Parameters.AddWithValue("para_vacancy_code", vacancy.VacancyCode);
            cmd.Parameters.AddWithValue("para_responsibilities", vacancy.Responsibilities);
            cmd.Parameters.AddWithValue("para_intervention_required", vacancy.InterventionedRequired);
            cmd.Parameters.AddWithValue("para_working_days", vacancy.WorkingDays);
            cmd.Parameters.AddWithValue("para_has_shifts", vacancy.HasShifts);
            cmd.Parameters.AddWithValue("para_working_hours", vacancy.WorkingHours);
            cmd.Parameters.AddWithValue("para_holiday_leave_policy", vacancy.HolidayAndLeavePolicy);

            cmd.ExecuteNonQuery();
        }

        #region DELETE FUNCTIONS
        public void DeleteVacancyDisabilitySubTypes(MySqlCommand cmd, string vacancyID)
        {
            cmd.CommandText = "delete from vacancy_accepted_disability_sub_types where vacancy_id=" + vacancyID;
            cmd.ExecuteNonQuery();
        }

        public void DeleteVacancyEducationalQualifications(MySqlCommand cmd, string vacancyID)
        {
            cmd.CommandText = "delete from vacancy_required_qualifications where vacancy_id=" + vacancyID;
            cmd.ExecuteNonQuery();
        }

        public void DeleteVacancyTrainingPrograms(MySqlCommand cmd, string vacancyID)
        {
            cmd.CommandText = "delete from vacancy_training_programs where vacancy_id=" + vacancyID;
            cmd.ExecuteNonQuery();
        }

        public void DeleteVacancyRequiredLanguages(MySqlCommand cmd, string vacancyID)
        {
            cmd.CommandText = "delete from vacancy_required_languages where vacancy_id=" + vacancyID;
            cmd.ExecuteNonQuery();
        }

        public void DeleteVacancyConsideredCandidateGroups(MySqlCommand cmd, string vacancyID)
        {
            cmd.CommandText = "delete from vacancy_considered_candidate_groups where vacancy_id=" + vacancyID;
            cmd.ExecuteNonQuery();
        }
        #endregion
    }
}