using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace EnableIndia.Old_App_Code.BAL
{

    class SocioEconomicIndicatorBAL
    {
        #region CANDIDATE SOCIO ECONOMIC INDICATOR
        public int SecID
        {
            get;
            set;
        }

        public int CandidateID
        {
            get;
            set;
        }
        public decimal FamilyIncome
        {
            get;
            set;
        }
        public int NumberOfMembers
        {
            get;
            set;
        }
        public int  MainEarningMember
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
        public int DisabilityID
        {
            get;
            set;
        }
        public int DisabilitySubTypeID
        {
            get;
            set;
        }
        public int RecommendedJobID
        {
            get;
            set;
        }
        public int RecommendedJobRoleID
        {
            get;
            set;
        }
        public string Gender
        {
            get;
            set;
        }
        public string seiStatus
        {
            get;
            set;
        }
        public decimal SalaryFrom
        {
            get;
            set;
        }

        public decimal SalaryTo
        {
            get;
            set;
        }

        #endregion
        public DataTable GetSocialEconomicIndicator(string candidateID)
        {
            EnableIndia.Old_App_Code.DAL.SocioEconomicIndicatorDAL seid = new DAL.SocioEconomicIndicatorDAL();
            return (seid.GetCandidateSocioEconomicIndicator(candidateID));
        }
       public int AddCandidateSocioEconomicIndicator(SocioEconomicIndicatorBAL sei)
       {
           Old_App_Code.DAL.SocioEconomicIndicatorDAL seid = new DAL.SocioEconomicIndicatorDAL();
           int retRows = seid.AddSocialEconomicIndicator(sei);
           return (retRows);
       }
       public MySqlDataReader GetSocioEconomicIndicatorDetail(string candidateID, string secID)
       {
           Old_App_Code.DAL.SocioEconomicIndicatorDAL seid = new DAL.SocioEconomicIndicatorDAL();
           return(seid.GetSocioEconomicIndicatorDetail(candidateID, secID));
       }
       public int UpdateSocioEconomicIndicator(SocioEconomicIndicatorBAL sei)
       {
           Old_App_Code.DAL.SocioEconomicIndicatorDAL seid = new DAL.SocioEconomicIndicatorDAL();
           int rowsaffected = seid.UpdateSocioEconomicIndicator(sei);
           return (rowsaffected);
       }
       public int GetCandidateID(string rid)
       {
           Old_App_Code.DAL.SocioEconomicIndicatorDAL seid = new DAL.SocioEconomicIndicatorDAL();
           return seid.GetCandidateID(rid);
       }
       public DataTable GetSEIReport(Old_App_Code.BAL.SocioEconomicIndicatorBAL seib)
       {
           Old_App_Code.DAL.SocioEconomicIndicatorDAL seid = new DAL.SocioEconomicIndicatorDAL();
           DataTable dt = seid.GetSEIReport(seib);
           return (dt);
       }
    }

}
