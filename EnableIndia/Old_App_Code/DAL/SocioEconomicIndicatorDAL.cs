using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace EnableIndia.Old_App_Code.DAL
{
    class SocioEconomicIndicatorDAL
    {
        public int GetCandidateID(string rid)
        {
            string query = "select candidate_id from candidates";
            if (!rid.Equals(""))
            {
                query += " where registration_id='" + rid + "'";
            }
            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public DataTable GetCandidateSocioEconomicIndicator(string candidateID)
        {
            string query = "Select * from socio_economic_indicator where candidate_id=" + candidateID;
            DBAccess dba = new DBAccess();
            DataTable dt = (DataTable)dba.ExecuteQuery(query, null, "DataTable");
            return (dt);
        }
        public int AddSocialEconomicIndicator(Old_App_Code.BAL.SocioEconomicIndicatorBAL seib)
        {
            string query = "Insert into socio_economic_indicator (candidate_id, family_income, number_of_members, main_earning_member, recupdate) values (";
            query += seib.CandidateID + ", " + seib.FamilyIncome + ", " + seib.NumberOfMembers + ", " + seib.MainEarningMember + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            DBAccess dba = new DBAccess();
            int retrows = (int)dba.ExecuteQuery(query, null, "NonQuery");
            return (retrows);
        }
        public MySqlDataReader GetSocioEconomicIndicatorDetail(string candidateID, string seiID)
        {
            string query = "Select * from socio_economic_indicator where candidate_id=" + candidateID + " and sec_id=" + seiID;
            DBAccess dba = new DBAccess();
            return ((MySqlDataReader)dba.ExecuteQuery(query, null, "Reader"));
        }
        public int UpdateSocioEconomicIndicator(Old_App_Code.BAL.SocioEconomicIndicatorBAL seib)
        {
            string query = "Update socio_economic_indicator set family_income = " + seib.FamilyIncome + ", ";
            query += "number_of_members=" + seib.NumberOfMembers + ", ";
            query += "main_earning_member=" + seib.MainEarningMember + ", recupdate=now()  where candidate_id=" + seib.CandidateID + " and sec_id=" + seib.SecID;
            DBAccess dba = new DBAccess();
            int retrows = (int)dba.ExecuteQuery(query, null, "NonQuery");
            return (retrows);
        }
        public DataTable GetSEIReport(Old_App_Code.BAL.SocioEconomicIndicatorBAL seib)
        {
            string query = "select distinct cand.registration_id," +
            "		cand.candidate_id," +
            "		cand.registration_date," +
            "		cand_other_detl.candidate_name_with_status as candidate_name," +
            "		cand.date_of_birth," +
            "		disability.disability_type," +
            "		cand.candidate_educational_qualifications as educational_qualification," +
            "		cand.email_address," +
            "		ngo.ngo_name, " +
            "		cand.recommended_job_types as recommended_job_types," +
            "		cand.recommended_job_roles as recommended_job_roles," +
            "       convert(cand_work_comp.monthly_salary,signed) as salary, " +
            "       sei.family_income, sei.number_of_members, " +
            "  		(case sei.main_earning_member  when 1 then 'Yes'  else 'No'  end) as main_earning_member,  " +
            "   sei.recupdate " +
            "	FROM candidates cand" +
            "	JOIN candidate_other_details cand_other_detl ON cand_other_detl.candidate_id=cand.candidate_id " +
            "	JOIN disability_types disability ON cand.disability_id=disability.disability_id " +
            "	JOIN disability_sub_types disab_sub_type ON disability.disability_id=disab_sub_type.disability_id " +
            "   JOIN ngos ngo ON cand.ngo_id=ngo.ngo_id " +
            "	LEFT JOIN states state ON cand.present_address_state_id=state.state_id " +
            "	LEFT JOIN cities city ON cand.present_address_city_id=city.city_id ";

            if (seib.RecommendedJobID != -1)
            {
                query += " JOIN candidate_recommended_job_types recom_job_type ON cand.candidate_id=recom_job_type.candidate_id ";
                query += " AND (recom_job_type.job_id=" + seib.RecommendedJobID + ") ";
            }
            if (seib.RecommendedJobRoleID != -1)
            {
                query += " LEFT JOIN candidate_recommended_roles recom_job_role ON cand.candidate_id=recom_job_role.candidate_id ";
                query += " AND recom_job_role.job_role_id=" + seib.RecommendedJobRoleID;
            }
            query += "LEFT JOIN(SELECT" + 
                     "				DISTINCT can_exp.candidate_id," + 
                     "				can_exp.company_id," + 
                     "				IFNULL(comp.company_code,can_exp.unlisted_company) unlist_company," + 
                     "				IFNULL(role.job_role_name,can_exp.unlisted_job_role) unlist_role," + 
                     "				can_exp.designation_from_date, " + 
                     "				can_exp.unlisted_company, " + 
                     "				can_exp.unlisted_job_role, " + 
                     "				can_exp.job_role_id, " + 
                     "				monthly_salary " + 
                     "			FROM candidate_work_experience can_exp" + 
                     "			LEFT JOIN companies comp ON can_exp.company_id=comp.company_id " + 
                     "			LEFT JOIN candidate_recommended_roles reco_role ON can_exp.job_role_id=reco_role.job_role_id " + 
                     "			LEFT JOIN job_roles role ON can_exp.job_role_id=role.job_role_id " + 
                     "			WHERE can_exp.mark_deleted=0 and can_exp.designation_to_date >CURRENT_DATE() " + 
                     "			GROUP BY can_exp.candidate_id" + 
                     "			)cand_work_comp ON cand.candidate_id=cand_work_comp.candidate_id ";
            query += "    left join socio_economic_indicator sei on sei.candidate_id=cand.candidate_id where ";
            if (seib.CandidateID != -1 && seib.CandidateID != 0) query += " cand.candidate_id=" + seib.CandidateID + " and ";
            if (seib.StateID != -1) query += " state.state_id=" + seib.StateID + " and ";
            if (seib.CityID != -1) query += "city.city_id=" + seib.CityID + " and ";
            if (seib.Gender != "All") query += "cand.gender='" + seib.Gender + "' and ";
            if (seib.DisabilityID != -1) query += "cand.disability_id=" + seib.DisabilityID + " and ";
            query += " cand_work_comp.monthly_salary between " + seib.SalaryFrom + " and " + seib.SalaryTo + " and ";
            if (!string.IsNullOrEmpty(seib.SearchFor))
            {
                if (seib.SearchIn == "registration_id")
                {
                    query += " cand.registration_id LIKE '%" + seib.SearchFor + "%' and ";
                }
                if(seib.SearchIn == "name")
                {
                    query += "  (cand.first_name like '%" + seib.SearchFor + "%' or cand.middle_name like '%" + seib.SearchFor + "%'  or  cand.last_name like '%" + seib.SearchFor + "%') and ";
                }
            }
            if (seib.DisabilitySubTypeID != -1) query += " cand.disability_sub_type_id = " + seib.DisabilitySubTypeID;
            
            query = query.TrimEnd();
            string lastword = query.Split(' ').Last();
            //if (lastword == "and")
            //{
            //    int iLast = query.LastIndexOf("and");
            //    query = query.Substring(0, iLast) + " "; // Space for safety...
            //    // check whether it is just where....
            //    lastword = query.Split(' ').Last();
            //    //if (!string.IsNullOrEmpty(lastword))
            //    //{
            //    //    if (lastword == "where")
            //    //    {
            //    //        iLast = query.LastIndexOf("where");
            //    //        query = query.Substring(0, iLast) + " ";
            //    //    }
            //    //}
            //}
            //if (lastword == "where")
            //{
            //    int iLast = query.LastIndexOf("where");
            //    query = query.Substring(0, iLast) + " "; // Space for safety...
            //}
            if(lastword == "and")
            {
                if(seib.seiStatus == "AE")
                {
                    query += " !isnull(sei.recupdate) ";
                }
                else
                {
                    query += " isnull(sei.recupdate) ";
                }
            }
            if (lastword == "where")
            {
                if (seib.seiStatus == "AE")
                {
                    query += " !isnull(sei.recupdate) ";
                }
                else
                {
                    query += " isnull(sei.recupdate) ";
                }
            }
            query += " Order by cand.candidate_id";
            query = query.Replace("\t", " ");

            DBAccess dba = new DBAccess();
            DataTable dt = (DataTable)dba.ExecuteQuery(query, null, "DataTable");
            return (dt);
        }
    }
}
