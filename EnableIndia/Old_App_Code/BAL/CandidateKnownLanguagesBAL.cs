using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for CandiateKnownLanguagesBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CandidateKnownLanguagesBAL
    {
        public CandidateKnownLanguagesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCanddiateKnownLanguages(string candidateID)
        {
            EnableIndia.App_Code.DAL.CandidateKnownLanguagesDAL get = new EnableIndia.App_Code.DAL.CandidateKnownLanguagesDAL();
            return get.GetCanddiateKnownLanguages(candidateID);
        }
    }
}