using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CandidateKnownLanguagesDAL
    /// </summary>
    public class CandidateKnownLanguagesDAL
    {
        public CandidateKnownLanguagesDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCanddiateKnownLanguages(string candidateID)
        {
            string query = "select ";
            query += "	lang.language_id,";
            query += "	lang.language_name,";
            query += "	if(cand_lang.language_id is null,0,1) as is_attached ";
            query += "from languages lang ";
            query += "left join(select language_id ";
            query += "			from candidate_known_languages ";
            query += "			where candidate_id=" + candidateID;
            query += "          ) as cand_lang on lang.language_id=cand_lang.language_id ";
            query += "order by language_name";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }
    }
}