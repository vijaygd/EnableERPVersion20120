using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for CandidatePhoneAddressHistoryBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CandidatePhoneAddressHistoryBAL
    {
        public CandidatePhoneAddressHistoryBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCandidatePhoneHistory(string candidateID)
        {
            CandidatePhoneAddressHistoryDAL get = new CandidatePhoneAddressHistoryDAL();
            return get.GetCandidatePhoneHistory(candidateID);
        }

        public DataTable GetCandidateAddressHistory(string candidateID)
        {
            CandidatePhoneAddressHistoryDAL get = new CandidatePhoneAddressHistoryDAL();
            return get.GetCandidateAddressHistory(candidateID);
        }
    }
}