using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CandidateCallingDAL
    /// </summary>
    public class CandidateCallingDAL
    {
        public CandidateCallingDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCandidateCalling(string CandidateIDs)
        {
            string query = "select cand.*, ";
            query += "	cand.candidate_id,";
            query += "	cand.candidate_id,";
            query += "	cand.registration_id,";
            query += "	fun_get_candidate_name_with_status(cand.candidate_id) as candidate_name,";
            query += "	disab.disability_type,";
            query += "	concat(cand.primary_phone_number,if(cand.secondary_phone_number='','',','),cand.secondary_phone_number)as phone_numbers ";
            query += "from candidates cand ";
            query += "join disability_types disab on cand.disability_id=disab.disability_id ";
            query += "where cand.candidate_id in(" + CandidateIDs + ") ";
            query += "order by candidate_name,registration_id";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }
    }
}