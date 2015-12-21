using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for CandidatePhoneAddressHistoryDAL
    /// </summary>
    public class CandidatePhoneAddressHistoryDAL
    {
        public CandidatePhoneAddressHistoryDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetCandidatePhoneHistory(string candidateID)
        {
            string query = "select * from candidate_phone_history where candidate_id=" + candidateID;
            query += " and (primary_phone_number!='' or secondary_phone_number!='') ";
            query += " order by updation_date desc ";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public DataTable GetCandidateAddressHistory(string candidateID)
        {
            string query = "select ";
            query += "	hist.*,";
            query += "	ifnull(st.state_name,'')as state_name,";
            query += "	ifnull(cities.city_name,'')as city_name ";
            query += "from candidate_address_history hist ";
            query += "join states st on hist.present_address_state_id=st.state_id ";
            query += "join cities on hist.present_address_city_id=cities.city_id ";
            query += "where hist.candidate_id=" + candidateID;
            query += " order by updation_date desc ";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }
    }
}