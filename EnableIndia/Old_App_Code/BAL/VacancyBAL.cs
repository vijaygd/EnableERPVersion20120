using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for VacancyBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class VacancyBAL
    {
        public VacancyBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region VACANCY PARAMETERS
        public int VacancyID
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

        public string Designation
        {
            get;
            set;
        }

        public decimal MonthlySalary
        {
            get;
            set;
        }

        public string VacancyCode
        {
            get;
            set;
        }

        public string Responsibilities
        {
            get;
            set;
        }

        public string InterventionedRequired
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

        public string HolidayAndLeavePolicy
        {
            get;
            set;
        }
        public string VacancyDate
        {
            get;
            set;
        }
        public string VacancyName
        {
            get;
            set;
        }
        #endregion

        public int CheckForDuplicateVacancy(string vacancyID, string vacancyName)
        {
            EnableIndia.App_Code.DAL.VacancyDAL check = new EnableIndia.App_Code.DAL.VacancyDAL();
            return check.CheckForDuplicateVacancy(vacancyID, vacancyName);
        }

        #region GET PARAMETERS
        public MySqlDataReader GetVacancyCodes()
        {
            EnableIndia.App_Code.DAL.VacancyDAL get = new EnableIndia.App_Code.DAL.VacancyDAL();
            return get.GetVacancyCodes();
        }

        public MySqlDataReader GetVacancyDetails(string vacancyID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL get = new EnableIndia.App_Code.DAL.VacancyDAL();
            return get.GetVacancyDetails(vacancyID);
        }

        public DataTable GetVacancyDisabilitySubTypes(string vacancyID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            return vac.GetVacancyDisabilitySubTypes(vacancyID);
        }

        public DataTable GetVacancyEducationalQualifications(string vacancyID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            return vac.GetVacancyEducationalQualifications(vacancyID);
        }

        public DataTable GetVacancyTrainingPrograms(string vacancyID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            return vac.GetVacancyTrainingPrograms(vacancyID);
        }

        public DataTable GetVacancyRequiredLanguages(string vacancyID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            return vac.GetVacancyRequiredLanguages(vacancyID);
        }

        public DataTable GetVacancyConsideredCandidateGroups(string vacancyID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            return vac.GetVacancyConsideredCandidateGroups(vacancyID);
        }

        public DataTable GetVacancyReport(VacancyBAL vacancy)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            return vac.GetVacancyReport(vacancy);
        }
        #endregion

        #region UPDATE PARAMETERS
        public void UpdateVacancyDisabilitySubTypes(MySqlCommand cmd, string vacancyID, string disabilityID, string disabilitySubTypeID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            vac.UpdateVacancyDisabilitySubTypes(cmd, vacancyID, disabilityID, disabilitySubTypeID);
        }

        public void UpdateVacancyEducationalQualifications(MySqlCommand cmd, string vacancyID, string courseQualificationID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            vac.UpdateVacancyEducationalQualifications(cmd, vacancyID, courseQualificationID);
        }

        public void UpdateVacancyTrainingPrograms(MySqlCommand cmd, string vacancyID, string trainingProgramID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            vac.UpdateVacancyTrainingPrograms(cmd, vacancyID, trainingProgramID);
        }

        public void UpdateVacancyRequiredLanguages(MySqlCommand cmd, string vacancyID, string languageID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            vac.UpdateVacancyRequiredLanguages(cmd, vacancyID, languageID);
        }

        public void UpdateVacancyConsideredCandidateGroups(MySqlCommand cmd, string vacancyID, string candidateGroupID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            vac.UpdateVacancyConsideredCandidateGroups(cmd, vacancyID, candidateGroupID);
        }
        #endregion


        public string AddVacancy(MySqlCommand cmd, VacancyBAL vacancy)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            return vac.AddVacancy(cmd, vacancy);
        }

        public void UpdateVacancy(MySqlCommand cmd, VacancyBAL vacancy)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            vac.UpdateVacancy(cmd, vacancy);
        }

        #region DELETE FUNCTIONS
        public void DeleteVacancyDisabilitySubTypes(MySqlCommand cmd, string vacancyID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            vac.DeleteVacancyDisabilitySubTypes(cmd, vacancyID);
        }

        public void DeleteVacancyEducationalQualifications(MySqlCommand cmd, string vacancyID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            vac.DeleteVacancyEducationalQualifications(cmd, vacancyID);
        }

        public void DeleteVacancyTrainingPrograms(MySqlCommand cmd, string vacancyID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            vac.DeleteVacancyTrainingPrograms(cmd, vacancyID);
        }

        public void DeleteVacancyRequiredLanguages(MySqlCommand cmd, string vacancyID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            vac.DeleteVacancyRequiredLanguages(cmd, vacancyID);
        }

        public void DeleteVacancyConsideredCandidateGroups(MySqlCommand cmd, string vacancyID)
        {
            EnableIndia.App_Code.DAL.VacancyDAL vac = new EnableIndia.App_Code.DAL.VacancyDAL();
            vac.DeleteVacancyConsideredCandidateGroups(cmd, vacancyID);
        }
        #endregion
    }
}
