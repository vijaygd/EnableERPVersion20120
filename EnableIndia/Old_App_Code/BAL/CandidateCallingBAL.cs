using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for CandidateCallingBAL
/// </summary>
///
namespace EnableIndia.App_Code.BAL
{
    public class CandidateCallingBAL
    {
        public CandidateCallingBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCandidateCalling(string CandidateIDs)
        {
            CandidateCallingDAL get = new CandidateCallingDAL();
            DataTable dtCandidateCalling = get.GetCandidateCalling(CandidateIDs);

            foreach (DataRow dr in dtCandidateCalling.Rows)
            {
                if (dr["is_last_reachable_on_primary_phone_number"].ToString().Contains("1") && !System.DBNull.Value.Equals(dr["primary_phone_number"].ToString()))
                {
                    dr["primary_phone_number"] = "@" + dr["primary_phone_number"].ToString().Replace(",", "\n");
                }
                else
                {
                    dr["primary_phone_number"] = dr["primary_phone_number"].ToString().Replace(",", "\n");
                }
                if (dr["is_last_reachable_on_secondary_phone_number"].ToString().Contains("1"))
                {
                    dr["secondary_phone_number"] = "@" + dr["secondary_phone_number"].ToString().Replace(",", "\n");
                }
                else
                {
                    dr["secondary_phone_number"] = dr["secondary_phone_number"].ToString().Replace(",", "\n");
                }
            }

            return dtCandidateCalling;
        }
        public static string GetDateFormat()
        {
            return "dd/MM/yyyy";
        }

    }
}