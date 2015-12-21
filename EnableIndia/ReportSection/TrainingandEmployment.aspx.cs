using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Text.RegularExpressions;
using System.Globalization;
using EnableIndia.ReportSection;
using EnableIndia.Reports;
using BasicFrame.WebControls;
using Telerik;
using Telerik.Reporting;
using Telerik.Reporting.Design;
using Telerik.ReportViewer;
using Telerik.ReportViewer.Common;
using Telerik.ReportViewer.WebForms;
using System.Text;
using System.IO;

namespace EnableIndia.ReportSection
{
    public partial class TrainingandEmployment : System.Web.UI.Page
    {
        Telerik.Reporting.Drawing.Unit w;
        public DataSet sqlDs;
        public MySqlConnection myConn = new MySqlConnection();
        eGlobals gb = new eGlobals();
        public MySqlCommand mySqlCommand = new MySqlCommand();
        public MySqlDataAdapter mySqlAdapter;
        public DataSet myDataSet = new DataSet();
        public DataTable myDt; // = new DataTable();
        public DataTable tmyDt = new DataTable();   // Temporary for other seraches.....
        public static bool bSearchFlag = false;
        public MySql.Data.MySqlClient.MySqlDataAdapter sqlDa = null;
        public MySql.Data.MySqlClient.MySqlCommandBuilder sqlCmd = null;
        //string s1 = "select cand.candidate_id, cand.registration_id, cand.registration_date, cand_oth_detl.candidate_name_with_status As candidate_name, " +
        //          " YEAR(CURDATE()) - " +
        //          " YEAR(date_of_birth) AS age, cand.gender, st.state_name, ct.city_name, ngos.ngo_name, disb.disability_type, disb_sub.disability_sub_type, " + 
        //          " (case when cand.is_profiled ='0' then 'To Be Profiled' " +
        //          " when cand.is_profiled >'0' then 'Profiled' end )as Prof_status," +
        //          " null as Training_Project," +
        //          " null as Training_Program," +
        //          " null as Candidate_Job_Roles," +
        //          " jr.job_role_name as Recommended_job_role," +
        //          " comp.company_code AS company_name, " +
        //          "  par_comp.company_name AS Parent_company_name," +
        //          " null as Joining_date" +
        //          " from candidates cand" +
        //          " left join candidate_other_details cand_oth_detl on cand.candidate_id=cand_oth_detl.candidate_id" +
        //          " left join disability_types disb on cand.disability_id=disb.disability_id" +
        //          " left join disability_sub_types disb_sub on cand.disability_sub_type_id=disb_sub.disability_sub_type_id" +
        //          " left join ngos on cand.ngo_id=ngos.ngo_id" +
        //          " left join states st on cand.present_address_state_id=st.state_id" +
        //          " left join cities ct on cand.present_address_city_id=ct.city_id" +
        //          " left join candidate_recommended_roles cand_rl on cand.candidate_id=cand_rl.candidate_id" +
        //          " left Join job_roles jr on cand_rl.job_role_id=jr.job_role_id" +
        //          " left JOIN candidate_work_experience cand_work_expr ON cand.candidate_id = cand_work_expr.candidate_id " +
        //          " 		 AND cand_work_expr.mark_deleted=0 " +
        //          "  LEFT JOIN companies comp ON cand_work_expr.company_id=comp.company_id " +
        //          " LEFT JOIN parent_companies par_comp ON cand_work_expr.parent_company_id=par_comp.company_id " +
        //          " left join candidates_assigned_to_training_projects cand_tran on cand.candidate_id= cand_tran.candidate_id" +
        //          " AND cand_tran.is_candidate_deleted=0 " +
        //          " left join training_projects tran on cand_tran.training_project_id=tran.training_project_id" +
        //          " left join training_programs tram on  tran.training_program_id= tram.training_program_id" +
        //          " group by cand_rl.recommended_job_role_id " +
        //          " union all " +
        //          " select cand.candidate_id, cand.registration_id, cand.registration_date, cand_oth_detl.candidate_name_with_status As candidate_name, YEAR(CURDATE()) -  YEAR(date_of_birth) AS age," +
        //          " cand.gender, st.state_name, ct.city_name, ngos.ngo_name, disb.disability_type, disb_sub.disability_sub_type,  (case when cand.is_profiled ='0' then 'To Be Profiled' " +
        //          " when cand.is_profiled >'0' then 'Profiled' end )as Prof_status, null as Training_Project, null as Training_Program, case " +
        //          " WHEN cand_work_expr.job_role_id='-1' THEN cand_work_expr.unlisted_job_role " +
        //          " 					WHEN cand_work_expr.job_role_id > 0 THEN jr.job_role_name END" +
        //          " 		 AS Candidate_Job_Roles," +
        //          " null as Recommended_job_role," +
        //          " CASE" +
        //          " 					WHEN cand_work_expr.company_id='-1' THEN cand_work_expr.unlisted_company " +
        //          " 					WHEN cand_work_expr.company_id > 0 THEN comp.company_code END" +
        //          " 		 AS company_name," +
        //          " CASE " +
        //          " 					WHEN cand_work_expr.parent_company_id='-1' THEN '' " +
        //          " 					WHEN cand_work_expr.parent_company_id > 0 THEN par_comp.company_name END" +
        //          " 				 AS Parent_company_name," +
        //          "  cand_work_expr.designation_from_date as Joining_date" +
        //          " from candidates cand" +
        //          " left join candidate_other_details cand_oth_detl on cand.candidate_id=cand_oth_detl.candidate_id" +
        //          " left join disability_types disb on cand.disability_id=disb.disability_id" +
        //          " left join disability_sub_types disb_sub on cand.disability_sub_type_id=disb_sub.disability_sub_type_id" +
        //          " left join ngos on cand.ngo_id=ngos.ngo_id" +
        //          " left join states st on cand.present_address_state_id=st.state_id" +
        //          " left join cities ct on cand.present_address_city_id=ct.city_id" +
        //          " left join candidate_recommended_roles cand_rl on cand.candidate_id=cand_rl.candidate_id" +
        //          " left JOIN candidate_work_experience cand_work_expr ON cand.candidate_id = cand_work_expr.candidate_id " +
        //          " 		 AND cand_work_expr.mark_deleted=0 " +
        //          "   left Join job_roles jr on cand_work_expr.job_role_id=jr.job_role_id" +
        //          " LEFT JOIN companies comp ON cand_work_expr.company_id=comp.company_id " +
        //          " LEFT JOIN parent_companies par_comp ON cand_work_expr.parent_company_id=par_comp.company_id " +
        //          " left join candidates_assigned_to_training_projects cand_tran on cand.candidate_id= cand_tran.candidate_id" +
        //          " AND cand_tran.is_candidate_deleted=0 " +
        //          " left join training_projects tran on cand_tran.training_project_id=tran.training_project_id" +
        //          " left join training_programs tram on  tran.training_program_id= tram.training_program_id";
        //string s2 = " group by cand_work_expr.candidate_work_experience_id " +
        //          "   " +
        //          "  union all " +
        //          "   " +
        //          "  select cand.candidate_id, cand.registration_id, cand.registration_date, cand_oth_detl.candidate_name_with_status As candidate_name,"  +
        //          " YEAR(CURDATE()) - YEAR(date_of_birth) AS age," +
        //          " cand.gender, st.state_name, ct.city_name, ngos.ngo_name, disb.disability_type," +
        //          " disb_sub.disability_sub_type," +
        //          "   (case when cand.is_profiled ='0' then 'To Be Profiled' " +
        //          " when cand.is_profiled >'0' then 'Profiled' end )as Prof_status," +
        //          " tran.training_project_name as Training_Project," +
        //          " tram.training_program_name as Training_Program," +
        //          " null as Candidate_Job_Roles," +
        //          " null as Recommended_job_role, " +
        //          " null as company_name," +
        //          " null as Parent_company_name," +
        //          " null as Joining_date" +
        //          "  from candidates cand" +
        //          "   left join candidate_other_details cand_oth_detl on cand.candidate_id=cand_oth_detl.candidate_id" +
        //          " left join disability_types disb on cand.disability_id=disb.disability_id" +
        //          " left join disability_sub_types disb_sub on cand.disability_sub_type_id=disb_sub.disability_sub_type_id" +
        //          " left join ngos on cand.ngo_id=ngos.ngo_id" +
        //          " left join states st on cand.present_address_state_id=st.state_id" +
        //          " left join cities ct on cand.present_address_city_id=ct.city_id" +
        //          " left join candidate_recommended_roles cand_rl on cand.candidate_id=cand_rl.candidate_id" +
        //          " left Join job_roles jr on cand_rl.job_role_id=jr.job_role_id" +
        //          " left JOIN candidate_work_experience cand_work_expr ON cand.candidate_id = cand_work_expr.candidate_id " +
        //          " 		 AND cand_work_expr.mark_deleted=0 " +
        //          "  LEFT JOIN companies comp ON cand_work_expr.company_id=comp.company_id " +
        //          " LEFT JOIN parent_companies par_comp ON cand_work_expr.parent_company_id=par_comp.company_id " +
        //          " left join candidates_assigned_to_training_projects cand_tran on cand.candidate_id= cand_tran.candidate_id" +
        //          " AND cand_tran.is_candidate_deleted=0 " +
        //          " left join training_projects tran on cand_tran.training_project_id=tran.training_project_id" +
        //          " left join training_programs tram on  tran.training_program_id= tram.training_program_id";
        //string s3 = " group by cand_tran.assigned_training_project_id ";
        string s1 =                     "select cand.candidate_id,  " + 
                    "cand.registration_id,  " +  
                    "cand.registration_date,  " +  
                    "cand_oth_detl.candidate_name_with_status As candidate_name,  " +  
                    "YEAR(CURDATE()) - YEAR(date_of_birth) AS age,  " +  
                    "cand.gender,  " +  
                    "st.state_name,  " +  
                    "ct.city_name,  " +  
                    "ngos.ngo_name,  " +  
                    "disb.disability_type,  " +  
                    "disb_sub.disability_sub_type,  " +  
                    "(case when cand.is_profiled ='0' then 'To Be Profiled'   " +  
                    "when cand.is_profiled >'0' then 'Profiled' end )as Prof_status,  " +  
                    "null as Training_Project,  " +  
                    "null as Training_Program,  " +  
                    "null as Candidate_Job_Roles,  " +  
                    "jr.job_role_name as Recommended_job_role,  " +  
                    "comp.company_code AS company_name,   " +  
                    " par_comp.company_name AS Parent_company_name,  " +  
                    "null as Joining_date,  " +  
                    "null AS Candidate_completed_training,  " +  
                    "null as End_DATE_Training_project,   " +  
                    "null as Employment_project_name,  " +  
                    "null as  Got_placed_by_EI  " +  
                    "from candidates cand   " +  
                    "left join candidate_other_details cand_oth_detl on cand.candidate_id=cand_oth_detl.candidate_id  " +  
                    "left join disability_types disb on cand.disability_id=disb.disability_id  " +  
                    "left join disability_sub_types disb_sub on cand.disability_sub_type_id=disb_sub.disability_sub_type_id  " +  
                    "left join ngos on cand.ngo_id=ngos.ngo_id  " +  
                    "left join states st on cand.present_address_state_id=st.state_id  " +  
                    "left join cities ct on cand.present_address_city_id=ct.city_id  " +  
                    "left join candidate_recommended_roles cand_rl on cand.candidate_id=cand_rl.candidate_id  " +  
                    "left Join job_roles jr on cand_rl.job_role_id=jr.job_role_id  " +  
                    "left JOIN candidate_work_experience cand_work_expr ON cand.candidate_id = cand_work_expr.candidate_id   " +  
                    "   AND cand_work_expr.mark_deleted=0   " +  
                    "  LEFT JOIN candidates_assigned_to_employment_project cand_emp ON cand_work_expr.candidate_id=cand_emp.candidate_id  " +  
                    " LEFT JOIN employment_projects emp ON cand_emp.employment_project_id=emp.employment_project_id  " +  
                    "      " +  
                    "LEFT JOIN companies comp ON cand_work_expr.company_id=comp.company_id   " +  
                    "LEFT JOIN parent_companies par_comp ON cand_work_expr.parent_company_id=par_comp.company_id   " +  
                    "left join candidates_assigned_to_training_projects cand_tran on cand.candidate_id= cand_tran.candidate_id  " +  
                    "AND cand_tran.is_candidate_deleted=0   " +  
                    "left join training_projects tran on cand_tran.training_project_id=tran.training_project_id  " +  
                    "left join training_programs tram on  tran.training_program_id= tram.training_program_id  " +  
                    "group by cand_rl.recommended_job_role_id   " +  
                    "union all   " +  
                    "select cand.candidate_id,  " +  
                    "cand.registration_id,  " +  
                    "cand.registration_date,  " +  
                    "cand_oth_detl.candidate_name_with_status As candidate_name,  " +  
                    "YEAR(CURDATE()) - YEAR(date_of_birth) AS age,  " +  
                    "cand.gender,  " +  
                    "st.state_name,  " +  
                    "ct.city_name,  " +  
                    "ngos.ngo_name,  " +  
                    "disb.disability_type,  " +  
                    "disb_sub.disability_sub_type,  " +  
                    "(case when cand.is_profiled ='0' then 'To Be Profiled'   " +  
                    "when cand.is_profiled >'0' then 'Profiled' end )as Prof_status,  " +  
                    "null as Training_Project,  " +  
                    "null as Training_Program,  " +  
                    "case   " +  
                    "WHEN cand_work_expr.job_role_id='-1' THEN cand_work_expr.unlisted_job_role   " +  
                    "     WHEN cand_work_expr.job_role_id > 0 THEN jr.job_role_name END  " +  
                    "   AS Candidate_Job_Roles,  " +  
                    "null as Recommended_job_role,  " +  
                    "CASE  " +  
                    "     WHEN cand_work_expr.company_id='-1' THEN cand_work_expr.unlisted_company   " +  
                    "     WHEN cand_work_expr.company_id > 0 THEN comp.company_code END  " +  
                    "   AS company_name,  " +  
                    "CASE   " +  
                    "     WHEN cand_work_expr.parent_company_id='-1' THEN ''   " +  
                    "     WHEN cand_work_expr.parent_company_id > 0 THEN par_comp.company_name END  " +  
                    "     AS Parent_company_name,  " +  
                    " cand_work_expr.designation_from_date as Joining_date,  " +  
                    "null AS Candidate_completed_training,  " +  
                    "null as End_DATE_Training_project,   " +  
                    "IF(cand_work_expr.is_entered_from_employment_project=0,'',emp.employment_project_name)AS employment_project_name,  " +  
                    "(case when cand_work_expr.is_entered_from_employment_project >'0' then 'YES'   " +  
                    "when cand_work_expr.is_entered_from_employment_project <'1'then 'NO ' end )as Got_placed_by_EI  " +  
                    "from candidates cand  " +  
                    "left join candidate_other_details cand_oth_detl on cand.candidate_id=cand_oth_detl.candidate_id  " +  
                    "left join disability_types disb on cand.disability_id=disb.disability_id  " +  
                    "left join disability_sub_types disb_sub on cand.disability_sub_type_id=disb_sub.disability_sub_type_id  " +  
                    "left join ngos on cand.ngo_id=ngos.ngo_id  " +  
                    "left join states st on cand.present_address_state_id=st.state_id  " +  
                    "left join cities ct on cand.present_address_city_id=ct.city_id  " +  
                    "left join candidate_recommended_roles cand_rl on cand.candidate_id=cand_rl.candidate_id  " +  
                    "left JOIN candidate_work_experience cand_work_expr ON cand.candidate_id = cand_work_expr.candidate_id   " +  
                    "   AND cand_work_expr.mark_deleted=0   " +  
                    "  LEFT JOIN candidates_assigned_to_employment_project cand_emp ON cand_work_expr.candidate_id=cand_emp.candidate_id  " +  
                    " LEFT JOIN employment_projects emp ON cand_emp.employment_project_id=emp.employment_project_id  " +  
                    " left Join job_roles jr on cand_work_expr.job_role_id=jr.job_role_id  " +  
                    "LEFT JOIN companies comp ON cand_work_expr.company_id=comp.company_id   " +  
                    "LEFT JOIN parent_companies par_comp ON cand_work_expr.parent_company_id=par_comp.company_id   " +  
                    "left join candidates_assigned_to_training_projects cand_tran on cand.candidate_id= cand_tran.candidate_id  " +  
                    "AND cand_tran.is_candidate_deleted=0   " +  
                    "left join training_projects tran on cand_tran.training_project_id=tran.training_project_id  " +  
                    "left join training_programs tram on  tran.training_program_id= tram.training_program_id " + 
                    " group by cand_work_expr.candidate_work_experience_id ";

        string s2 = "  union all  " + 
                    " select cand.candidate_id, " + 
                    "cand.registration_id, " + 
                    "cand.registration_date, " + 
                    "cand_oth_detl.candidate_name_with_status As candidate_name, " + 
                    "YEAR(CURDATE()) - YEAR(date_of_birth) AS age, " + 
                    "cand.gender, " + 
                    "st.state_name, " + 
                    "ct.city_name, " + 
                    "ngos.ngo_name, " + 
                    "disb.disability_type, " + 
                    "disb_sub.disability_sub_type, " + 
                    "  (case when cand.is_profiled ='0' then 'To Be Profiled'  " + 
                    "when cand.is_profiled >'0' then 'Profiled' end )as Prof_status, " + 
                    "tran.training_project_name as Training_Project, " + 
                    "tram.training_program_name as Training_Program, " + 
                    "null as Candidate_Job_Roles, " + 
                    "null as Recommended_job_role,  " + 
                    "null as company_name, " + 
                    "null as Parent_company_name, " + 
                    "null as Joining_date, " + 
                    "CASE  " + 
                    "     WHEN cand_tran.completed_training <'1' THEN 'NO'  " + 
                    "     WHEN cand_tran.completed_training > 0 THEN 'YES' END " + 
                    "     AS Candidate_completed_training, " + 
                    "tran.end_date_time as End_DATE_Training_project,  " + 
                    "null as Employment_project_name, " + 
                    "null as  Got_placed_by_EI  " + 
                    " from candidates cand " + 
                    "  left join candidate_other_details cand_oth_detl on cand.candidate_id=cand_oth_detl.candidate_id " + 
                    "left join disability_types disb on cand.disability_id=disb.disability_id " + 
                    "left join disability_sub_types disb_sub on cand.disability_sub_type_id=disb_sub.disability_sub_type_id " + 
                    "left join ngos on cand.ngo_id=ngos.ngo_id " + 
                    "left join states st on cand.present_address_state_id=st.state_id " + 
                    "left join cities ct on cand.present_address_city_id=ct.city_id " + 
                    "left join candidate_recommended_roles cand_rl on cand.candidate_id=cand_rl.candidate_id " + 
                    "left Join job_roles jr on cand_rl.job_role_id=jr.job_role_id " + 
                    "left JOIN candidate_work_experience cand_work_expr ON cand.candidate_id = cand_work_expr.candidate_id  " + 
                    "   AND cand_work_expr.mark_deleted=0  " + 
                    "  LEFT JOIN candidates_assigned_to_employment_project cand_emp ON cand_work_expr.candidate_id=cand_emp.candidate_id " + 
                    " LEFT JOIN employment_projects emp ON cand_emp.employment_project_id=emp.employment_project_id " + 
                    "LEFT JOIN companies comp ON cand_work_expr.company_id=comp.company_id  " + 
                    "LEFT JOIN parent_companies par_comp ON cand_work_expr.parent_company_id=par_comp.company_id  " + 
                    "left join candidates_assigned_to_training_projects cand_tran on cand.candidate_id= cand_tran.candidate_id " + 
                    "AND cand_tran.is_candidate_deleted=0  " + 
                    "left join training_projects tran on cand_tran.training_project_id=tran.training_project_id  " +  
                    "left join training_programs tram on  tran.training_program_id= tram.training_program_id";

        string s3 = " group by cand_tran.assigned_training_project_id ";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.dtEndDate.ShowCalendarOnTextBoxFocus = true;
                this.dtStartDate.ShowCalendarOnTextBoxFocus = true;
                this.dtEndDate.SelectionChanged += new EventHandler(dtEndDate_SelectionChanged);
                this.dtEndDate.SelectedDate = DateTime.Today;
                this.dtStartDate.SelectedDate = Convert.ToDateTime(DateTime.Today.Year.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + "01".ToString());
            }

            if (Page.IsPostBack)
            {
                if (ViewState["myDt"] != null)
                {
                    myDt = (DataTable)(ViewState["myDt"]);
                }
                if (ViewState["tmyDt"] != null)
                {
                    tmyDt = (DataTable)(ViewState["tmyDt"]);
                }
            }

        }
        protected void ddSelChanged(object sender, EventArgs e)
        {
            if (this.ddOptions.SelectedIndex < 0) return;
            switch (this.ddOptions.SelectedValue)
            {
                case "cn": 
                case "state":
                case "city":
                case "ngo":
                case "dt":
                case "tpj":
                case "tpg":
                case "con":
                case "gen":
                    this.tbSearch.Visible = true;
                    this.dtSearch.Visible = false;
                    this.tbSearchIntFrom.Visible = false;
                    this.tbSearchIntTo.Visible = false;
                    this.lbToTI.Visible = false;
                    switch(this.ddOptions.SelectedValue)
                    {
                        case "cn": this.lbSelection.Text = "Searach Candidate wise"; break;
                        case "state": this.lbSelection.Text = "Searach State wise"; break;
                        case "city": this.lbSelection.Text = "Searach City wise"; break;
                        case "ngo": this.lbSelection.Text = "Searach NGO wise"; break;
                        case "dt": this.lbSelection.Text = "Searach Disability wise"; break;
                        case "tpj": this.lbSelection.Text = "Searach Training Project wise"; break;
                        case "tpg": this.lbSelection.Text = "Searach Training Program wise"; break;
                        case "con": this.lbSelection.Text = "Searach Company wise"; break;
                        case "gen": this.lbSelection.Text = "Searach Gender wise"; break;
                    }
                    break;
                case "ci":
                case "ri":
                    this.tbSearch.Visible = false;
                    this.dtSearch.Visible = false;
                    this.tbSearchIntFrom.Visible = true;
                    this.tbSearchIntTo.Visible = true;
                    this.lbToTI.Visible = true;
                    switch (this.ddOptions.SelectedValue)
                    {
                        case "ci": this.lbSelection.Text = "Search by Candididate Id"; break;
                        case "ri": this.lbSelection.Text = "Search by Registration Id"; break;
                    }
                    break;
            }

        }
        protected void dtStartDate_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void dtEndDate_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void btnQuery_Click(object sender, ImageClickEventArgs e)
        {

            GetEntireInfo();
            filterRecords();
            this.lbNoRec.Text = myDt.Rows.Count.ToString();
            EnableIndia.Reports.TrainingandEmp tep = new TrainingandEmp();
            tep.table1.DataSource = null;
            tep.table1.DataSource = myDt;
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            instanceReportSource1.ReportDocument = tep;
            this.tRadReport.ReportSource = instanceReportSource1;
            this.tRadReport.RefreshReport();

        }
        private void filterRecords()
        {
            int i = 0;
            bool[] dRecs = new bool[1];
            if (this.dtStartDate.SelectedDate.ToString("yyyy-MM-dd") == "0001-01-01")
            {
                this.dtStartDate.SelectedDate = Convert.ToDateTime(DateTime.Today.Year.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + "01".ToString());
            }
            if (this.dtEndDate.SelectedDate.ToString("yyyy-MM-dd") == "0001-01-01")
            {
                this.dtEndDate.SelectedDate = DateTime.Today;
            }
            DateTime d1 = this.dtStartDate.SelectedDate;
            DateTime d2 = this.dtEndDate.SelectedDate;


            if (this.ddOptions.SelectedIndex <= 0)
                return;
            if (myDt == null)
                return;
            if (myDt.Rows.Count <= 0)
                return;
            if ((this.ddOptions.SelectedValue == "cn" ||
               this.ddOptions.SelectedValue == "state" ||
               this.ddOptions.SelectedValue == "city" ||
               this.ddOptions.SelectedValue == "ngo" ||
               this.ddOptions.SelectedValue == "dt" ||
               this.ddOptions.SelectedValue == "tpj" ||
               this.ddOptions.SelectedValue == "tpg" ||
               this.ddOptions.SelectedValue == "con" ||
               this.ddOptions.SelectedValue == "gen") && string.IsNullOrEmpty(this.tbSearch.Text))
            {
                this.lbError.Text = "No Search pattern";
                return;
            }
            if((this.ddOptions.SelectedValue == "ci" || this.ddOptions.SelectedValue == "ri") && string.IsNullOrEmpty(this.tbSearchIntFrom.Text))
            {
                this.lbError.Text = "No Search Pattern";
                return;
            }
            if((this.ddOptions.SelectedValue == "ci" || this.ddOptions.SelectedValue == "ri") && string.IsNullOrEmpty(this.tbSearchIntTo.Text))
            {
                this.tbSearchIntTo.Text = "99999";
            }
            int iColPosition = 0;
            switch (this.ddOptions.SelectedValue)
            {
                case "cn": case "state": case "city": case "ngo": case "dt": case "tpj": case "tpg": case "con": 
                    switch (this.ddOptions.SelectedValue)
                    {
                        case "cn": iColPosition = 3; break;
                        case "state": iColPosition = 6; break;
                        case "city": iColPosition = 7; ; break;
                        case "ngo": iColPosition = 8; ; break;
                        case "dt": iColPosition = 9; ; break;
                        case "tpj": iColPosition = 12; ; break;
                        case "tpg": iColPosition = 13; ; break;
                        case "con": iColPosition = 16; ; break;
                    }
                    dRecs = new bool[myDt.Rows.Count + 1];
                    foreach (DataRow dr in myDt.Rows)
                    {
                        Match match = Regex.Match(dr[iColPosition].ToString().ToUpper(), this.tbSearch.Text.ToUpper());
                        if (match.Success)
                        {
                            dRecs[i] = false;
                        }
                        else
                        {
                            dRecs[i] = true;
                        }
                        i++;
                    }
                    break;
                case "gen":

                    dRecs = new bool[myDt.Rows.Count + 1];
                    foreach (DataRow dr in myDt.Rows)
                    {
                        bool iMatch = (dr[5].ToString().ToUpper() == this.tbSearch.Text.ToUpper()) ? true : false;
                        if (iMatch)
                        {
                            dRecs[i] = false;
                        }
                        else
                        {
                            dRecs[i] = true;
                        }
                        i++;
                    }
                    break;
                case "ci": case "ri":
                    dRecs = new bool[myDt.Rows.Count + 1];
                    string regId = string.Empty;
                    foreach (DataRow dr in myDt.Rows)
                    {

                        bool iMatch = false;
                        switch (this.ddOptions.SelectedValue)
                        {
                            case "ci":
                                iMatch = (Convert.ToInt32(dr[0]) >= Convert.ToInt32(this.tbSearchIntFrom.Text)) && (Convert.ToInt32(dr[0]) <= Convert.ToInt32(this.tbSearchIntTo.Text));
                                break;
                            case "ri": iColPosition = 1;
                                regId = Regex.Replace(dr[1].ToString(), @"[A-Za-z\s]", string.Empty);
                                iMatch = (Convert.ToInt32(regId) >= Convert.ToInt32(this.tbSearchIntFrom.Text)) && (Convert.ToInt32(regId) <= Convert.ToInt32(this.tbSearchIntTo.Text));
                                break;
                        }

                        if (iMatch)
                        {
                            dRecs[i] = false;
                        }
                        else
                        {
                            dRecs[i] = true;
                        }
                        i++;
                    }
                    break;
                case "rsd":
                    d2 = DateTime.Today;
                    DateTime dbDate = new DateTime();
                    i = 0;
                    dRecs = new bool[myDt.Rows.Count + 1];
                    foreach (DataRow dr in myDt.Rows)
                    {
                        dbDate = Convert.ToDateTime(dr[2]);
                        int iMatch = dbDate.CompareTo(this.dtStartDate.SelectedDate);
                        if(iMatch >= 0)
                        {
                            dRecs[i] = false;
                        }
                        else
                        {
                            dRecs[i] = true;
                        }
                        i++;
                    }
                    break;
                case "red":
                    d2 = DateTime.Today;
                    DateTime dbeDate = new DateTime();
                    i = 0;
                    dRecs = new bool[myDt.Rows.Count + 1];
                    foreach (DataRow dr in myDt.Rows)
                    {
                        dbDate = Convert.ToDateTime(dr[2]);
                        int iMatch = dbeDate.CompareTo(this.dtEndDate.SelectedDate);
                        if (iMatch <= 0 )
                        {
                            dRecs[i] = false;
                        }
                        else
                        {
                            dRecs[i] = true;
                        }
                        i++;
                    }
                    break;
                case "brd":
                    d2 = DateTime.Today;
                    int iMatch1 = 0;
                    int iMatch2 = 0;
                    DateTime dbrdDate = new DateTime();
                    i = 0;
                    dRecs = new bool[myDt.Rows.Count + 1];
                    foreach (DataRow dr in myDt.Rows)
                    {
                        dbrdDate = Convert.ToDateTime(dr[2]);
                        iMatch1 = dbrdDate.CompareTo(this.dtStartDate.SelectedDate);
                        iMatch2 = dbrdDate.CompareTo(this.dtEndDate.SelectedDate);
                        if (iMatch1 >= 0 && iMatch2 <= 0)
                        {
                            dRecs[i] = false;
                        }
                        else
                        {
                            dRecs[i] = true;
                        }
                        i++;
                    }
                    break;
                case "jsd":
                    d2 = DateTime.Today;
                    dbDate = new DateTime();
                    i = 0;
                    dRecs = new bool[myDt.Rows.Count + 1];
                    foreach (DataRow dr in myDt.Rows)
                    {
                        if (string.IsNullOrEmpty(dr[18].ToString()))
                        {
                            dRecs[i] = true;
                            i++;
                            continue;
                        }
                        dbDate = Convert.ToDateTime(dr[18]);
                        int iMatch = dbDate.CompareTo(this.dtStartDate.SelectedDate);
                        if (iMatch >= 0)
                        {
                            dRecs[i] = false;
                        }
                        else
                        {
                            dRecs[i] = true;
                        }
                        i++;
                    }
                    break;
                case "jed":
                    d2 = DateTime.Today;
                     dbeDate = new DateTime();
                    i = 0;
                    dRecs = new bool[myDt.Rows.Count + 1];
                    foreach (DataRow dr in myDt.Rows)
                    {
                        if (string.IsNullOrEmpty(dr[18].ToString()))
                        {
                            dRecs[i] = true;
                            i++;
                            continue;
                        }

                        dbDate = Convert.ToDateTime(dr[18]);
                        int iMatch = dbeDate.CompareTo(this.dtEndDate.SelectedDate);
                        if (iMatch <= 0)
                        {
                            dRecs[i] = false;
                        }
                        else
                        {
                            dRecs[i] = true;
                        }
                        i++;
                    }
                    break;
                case "jrd":
                    d2 = DateTime.Today;
                    iMatch1 = 0;
                    iMatch2 = 0;
                    dbrdDate = new DateTime();
                    i = 0;
                    dRecs = new bool[myDt.Rows.Count + 1];
                    foreach (DataRow dr in myDt.Rows)
                    {
                        if(string.IsNullOrEmpty(dr[18].ToString()))
                        {
                            dRecs[i] = true;
                            i++;
                            continue;
                        }
                        dbrdDate = Convert.ToDateTime(dr[18]);
                        iMatch1 = dbrdDate.CompareTo(this.dtStartDate.SelectedDate);
                        iMatch2 = dbrdDate.CompareTo(this.dtEndDate.SelectedDate);
                        if (iMatch1 >= 0 && iMatch2 <= 0)
                        {
                            dRecs[i] = false;
                        }
                        else
                        {
                            dRecs[i] = true;
                        }
                        i++;
                    }
                    break;


            }

            int j = 0;
            for (i = 0; i < dRecs.GetLength(0); i++)
            {
                if (dRecs[i])
                {
                    myDt.Rows[i].Delete();
                    j++;
                }
            }
            myDt.AcceptChanges();
            ViewState["myDt"] = myDt;
       //     refreshReport();

        }
        protected void btnReset_Click(object sender, ImageClickEventArgs e)
        {
            if (myDt == null)
            {
                this.lbStatus.Text = "Nothing to reset";
                return;
            }
            if (tmyDt != null)
            {
                this.lbStatus.Text = "";
                this.lbSelection.Text = "";
                this.ddOptions.SelectedIndex = 0;
                myDt.Clear();
                myDt = tmyDt.Clone();
                for (int j = 0; j < tmyDt.Rows.Count; j++)
                {
                    myDt.ImportRow(tmyDt.Rows[j]);
                }
                ViewState["myDt"] = myDt;
                refreshReport();
                this.tbSearch.Text = "";
                this.tbSearchIntFrom.Text = "";
                this.tbSearchIntTo.Text = "";
                this.tbSearch.Visible = true;
                this.dtSearch.Visible = false;
                this.tbSearchIntFrom.Visible = false;
                this.tbSearchIntTo.Visible = false;
                this.lbToTI.Visible = false;
                this.lbSelection.Text = "";
            }

        }

        protected void btnChart_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnGet_Click(object sender, ImageClickEventArgs e)
        {
            bool[] dRecs = new bool[1];
            if (myDt == null)
            {
                this.lbStatus.Text = "Report not yet populated";
                return;
            }
            if (myDt.Rows.Count <= 0)
            {
                this.lbStatus.Text = "No records to serach";
                return;
            }
            filterRecords();
            this.lbNoRec.Text = myDt.Rows.Count.ToString();
            this.tRadReport.ReportSource = null;
            this.tRadReport.RefreshReport();
            refreshReport();
        }
        private void refreshReport()
        {
            TrainingandEmp tap = new TrainingandEmp();
 
            //  rgj.DataSource = myDt;
            tap.table1.DataSource = myDt;
            this.tRadReport.ReportSource = tap;
            this.tRadReport.RefreshReport();
            this.lbNoRec.Text = myDt.Rows.Count.ToString();
        }

        private void GetEntireInfo()
        {
            try
            {
                myConn = gb.SetLocalConnection();
                string sqlStr = s1 + s2 + s3;
                myDt = new DataTable();
                //string sqlStr = "select agentid, company, first_name, email, address1, city, state, pincode, mobile  from agent_master where status <> 'inactive'";
                mySqlAdapter = new MySqlDataAdapter(sqlStr, myConn);
                myDataSet = new DataSet();
                mySqlAdapter.SelectCommand.CommandTimeout = 1200;
                //      mySqlAdapter.Fill(myDataSet);
                mySqlAdapter.Fill(myDt);
                ViewState["myDt"] = myDt;
                if (myDt.Rows.Count <= 0)
                {
                    this.lbStatus.Text = "No records found according to selection";
                    return;
                }
                tmyDt = myDt.Clone();
                for (int j = 0; j < myDt.Rows.Count; j++)
                {
                    tmyDt.ImportRow(myDt.Rows[j]);
                }
                ViewState["tmyDt"] = tmyDt;
                this.lbNoRec.Text = myDt.Rows.Count.ToString();
                //   removeDup();
                refreshReport();
            }
            catch (System.Exception ex)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("Error: " + ex.Message);
            }
        }

        protected void btnClose_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");

        }
        private void getInfoForExcel()
        {
            if (this.dtStartDate.SelectedDate.ToString("yyyy-MM-dd") == "0001-01-01")
            {
                this.dtStartDate.SelectedDate = Convert.ToDateTime(DateTime.Today.Year.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + "01".ToString());
            }
            if (this.dtEndDate.SelectedDate.ToString("yyyy-MM-dd") == "0001-01-01")
            {
                this.dtEndDate.SelectedDate = DateTime.Today;
            }
            //DateTime d1 = this.dtStartDate.SelectedDate;
            //DateTime d2 = this.dtEndDate.SelectedDate;
            //int iDiff = DateTime.Compare(d1, d2);
            //if (iDiff > 0)
            //    return;
            //string dtString = string.Empty;
            //if(this.dtStartDate.SelectedDate.ToString() != "01/01/0001" || this.dtEndDate.SelectedDate.ToString() != "01/01/0001")
            //        dtString = " and cand_work_expr.designation_from_date between '" + this.dtStartDate.SelectedDate.ToString("yyyy-MM-dd") + "' and '" + this.dtEndDate.SelectedDate.ToString("yyyy-MM-dd") + "' ";
            //GetEntireInfo();
            //if (myDt == null)
            //{
            //    this.lbStatus.Text = "Wrong dates...";
            //    return;
            //}
            myConn = gb.SetLocalConnection();
            string sqlStr = s1 + s2 + s3;
            myDt = new DataTable();
            mySqlAdapter = new MySqlDataAdapter(sqlStr, myConn);
            mySqlAdapter.SelectCommand.CommandTimeout = 1200;
            //      mySqlAdapter.Fill(myDataSet);
            mySqlAdapter.Fill(myDt);
            ViewState["myDt"] = myDt;
        }

        protected void btnWExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            webMessageBox wb = new webMessageBox();
            if (myDt == null)
            {
                getInfoForExcel();
            }
            if (myDt.Rows.Count == 0)
            {
                getInfoForExcel();
                if (myDt.Rows.Count == 0)
                {
                    wb.Show("No Recrods available");
                    return;
                }
            }
            filterRecords();
            this.lbNoRec.Text = myDt.Rows.Count.ToString();

            int i = 0;
            StringBuilder xlDocBody = new StringBuilder(); ;
            // -------------------------------------------------
            // Create dir for storing....
            // ------------------------------------------------
            string dirPath = System.Configuration.ConfigurationManager.AppSettings["ExcelReports"];
            dirPath += "\\TrainingandEmployment" + DateTime.Now.ToString("ddMMyyhhmm") + ".xls";
            dirPath = dirPath.Replace("\\\\", "\\");   // To take care of  IDE Problem.....
            try
            {
                // First create header....
                xlDocBody.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
                xlDocBody.Append("<head runat='server'>");
                xlDocBody.Append("<title>Enable India</title>");
                xlDocBody.Append("<table width=\"100%\" cellpadding=1 cellspacing=2 style=\"background-color:#ffffff;\">");
                xlDocBody.Append("<tr><td>");
                xlDocBody.Append("<table width=\"600\" cellpadding=\"0\" cellspacing=\"2\"><tr><td>");
                xlDocBody.Append("<tr><td colspan='3' valign='middle' align='left' style=\"font-size:medium; font-weight:bold;\">");
                xlDocBody.Append("Training & Employment " + DateTime.Now.ToString("dd/MM/yyyy"));
                xlDocBody.Append("</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Start Date: " + this.dtStartDate.SelectedDate.ToString("dd/MM/yyyy") + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "End Date: " + this.dtEndDate.SelectedDate.ToString("dd/MM/yyyy") + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Number of entries: " + myDt.Rows.Count.ToString() + "</td>");
                xlDocBody.Append("<tr><td width=\"25\"> </td></tr>");
                xlDocBody.Append("<tr>");
//                Candidate Name		Reg Id	Cand Id	Disability Type	Disability Sub Type	Company Name		Parent Company Name	Vacancy Name	Placed By EI	Job Role	Date of Join
                //Salary	Job Type	Recommended Job Role	Managed By	Emp Veri Done	Emp Proof Received	Contact Person		Contact Phone	No of VI	No of HI	No Of PD	No of MI	No of MR	No of CP	No Of DB	No Oth Dis

                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Cand Id" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Reg Id" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Reg Date" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Candidate Name" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Age" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Gender" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "State Name" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "City Name" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "NGO Name" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Disability Type" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Disability Sub Type" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Prof Status" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Training Project" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Training Program" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Candidate Job Role" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Recommended Job Role" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Company Name" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Parent Company Name" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Joining Date" + "</td>");

                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Candidate Completed Training" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "End Date Training Project" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Employment Project Name" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Got Placed By EI" + "</td>");
                xlDocBody.Append("</tr>");
                //
                // Add Data Rows
                foreach (DataRow dRow in myDt.Rows)
                {
                    xlDocBody.Append("<tr>");
                    for (i = 0; i < 23; i++)
                    {
                        switch(i)
                        {
                            case 3:
                                xlDocBody.Append("<td valign=\"middle\" align=\"left\"> " + dRow[i].ToString() + "</td>");
                                break;
                            case 2:
                            case 18:
                            case 20:
                                string sDate = dRow[i].ToString();
                                try
                                {
                                    sDate = (string.IsNullOrEmpty(sDate)?string.Empty: (Convert.ToDateTime(sDate).ToString("dd/MM/yyyy")));
                                }
                                catch
                                {
                                    ;;
                                }
                                xlDocBody.Append("<td valign=\"middle\" align=\"left\"> " + sDate + "</td>");
                                break;
                            default:
                                xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + dRow[i].ToString() + "</td>");
                                break;
                        }
                    }
                    xlDocBody.Append("</tr>");
                }
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                byte[] array = Encoding.ASCII.GetBytes(xlDocBody.ToString());
                ////     File.WriteAllText(fileName, xlDocBody.ToString());
                File.WriteAllBytes(dirPath, array);
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
                HttpContext.Current.Response.AppendHeader("Content-Type", "application/ms-excel");
                HttpContext.Current.Response.AppendHeader("Content-disposition", "attachment; filename=\"" + Path.GetFileName(dirPath) + "\";");
                //int li = dirPath.LastIndexOf("\\");
                //dirPath = dirPath.Substring(0, li);  // Remove the last reverse slash due to transmit....
                System.Web.HttpContext.Current.Response.Flush();
                // HttpContext.Current.Response.WriteFile(fileName);
                System.Web.HttpContext.Current.Response.TransmitFile(dirPath);
                HttpContext.Current.Response.End();

            }
            catch (System.Exception ex)
            {
                webMessageBox wb1 = new webMessageBox();
                wb1.Show("Error: " + ex.Message);
            }


        }
    }
}