using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql;
using MySql.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Web;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Globalization;
using EnableIndia.ReportSection;
using EnableIndia.Reports;
using BasicFrame.WebControls;
using Telerik;
using Telerik.Web;
using Telerik.Web.UI;
using System.Text;
using System.IO;


namespace EnableIndia.ReportSection
{
    public partial class GotJobWithPlacements : System.Web.UI.Page
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
        public string s1 = "select cand_other_detl.candidate_name_with_status as candidate_name,cand.registration_id,cand.candidate_id,disability.disability_type,  " + 
         "    disab_sub_type.disability_sub_type,  "   +  
         "    (case when cand_work_expr.company_id='-1' then cand_work_expr.unlisted_company when cand_work_expr.company_id > 0 then comp.company_code end)as company_name,  "   +  
         "    (case when cand_work_expr.parent_company_id='-1' then ''  when cand_work_expr.parent_company_id > 0 then par_comp.company_name end)as Parent_company_name,  "   +  
         "    vac.vacancy_name, (case when cand_work_expr.is_entered_from_employment_project >'0' then 'YES'  when cand_work_expr.is_entered_from_employment_project <'1'then 'NO ' end )as Got_placed_by_EI,  "   +  
         "    (case when cand_work_expr.company_id='-1' then ''  when cand_work_expr.company_id > 0 then emp_proj.employment_project_name end )as Employment_Project,  "   +  
         "     cand_work_expr.designation_from_date as date_of_join,cand_work_expr.monthly_salary as salary,ind.industry_segment,  "   +  
         "    (case when jobs.job_id >'0'  then jobs.job_name  when jobs.job_name <'1' then 'Unlisted' end ) as job_Type,  "   +  
         "     cand.recommended_job_roles as recommended_job_role,  "   +  
         "     Group_concat(distinct training_programs.training_program_name) as Traing_Prgm,  "   +  
         "     Group_concat(distinct training_projects.training_project_name) as Traing_Prjct,  "   +  
         "     Group_concat(distinct  "   +  
         "concat(emp.employee_first_name,emp.employee_middle_name,emp.employee_last_name))  "   +  
         "as managed_by,  "   +
         "compcont.contact_name as contact_name, compcont.phone_number as contact_phone, " +
         "(case when cand_work_expr.emp_proof_received = 'Y' then 'Yes' else 'No' end) as employee_proof_received, " +
         "              count(distinct cand.candidate_id ) as No_of_cand_got_job,  "   +  
         "              (SELECT  count(*)  FROM disability_types disability where  "   +  
         "cand.disability_id=1 and cand.disability_id=disability.disability_id)as  "   +  
         "No_of_VI,  "   +  
         "              (SELECT  count(*)  FROM disability_types disability where  "   +  
         "cand.disability_id=2 and cand.disability_id=disability.disability_id)as  "   +  
         "No_of_HI,  "   +  
         "              (SELECT  count(*)  FROM disability_types disability where  "   +  
         "cand.disability_id=3 and cand.disability_id=disability.disability_id)as  "   +  
         "No_of_PD,  "   +  
         "              (SELECT  count(*)  FROM disability_types disability where  "   +  
         "cand.disability_id=4 and cand.disability_id=disability.disability_id)as  "   +  
         "No_of_MI,  "   +  
         "              (SELECT  count(*)  FROM disability_types disability where  "   +  
         "cand.disability_id=5 and cand.disability_id=disability.disability_id)as  "   +  
         "No_of_MR,  "   +  
         "              (SELECT  count(*)  FROM disability_types disability where  "   +  
         "cand.disability_id=6 and cand.disability_id=disability.disability_id)as  "   +  
         "No_of_CP,  "   +  
         "              (SELECT  count(*)  FROM disability_types disability where  "   +  
         "cand.disability_id=7 and cand.disability_id=disability.disability_id)as  "   +  
         "No_of_DB,  "   +  
         "              (SELECT  count(*)  FROM disability_types disability where  "   +  
         "cand.disability_id=8 and cand.disability_id=disability.disability_id)as  "   +  
         "No_of_Others_disb   "   +  
         "               "   +  
         "             FROM (select * from candidate_work_experience where  "   +  
         "mark_deleted=0    and designation_to_date ='5000-01-01') as cand_work_expr  "   +  
         "                "   +  
         "              left join   candidates cand on cand_work_expr.candidate_id=  "   +  
         "cand.candidate_id  "   +  
         "              and is_registration_completed=1 and cand.is_active=1  "   +  
         "              left JOIN candidate_other_details cand_other_detl ON cand_other_detl.candidate_id=cand.candidate_id   "   +  
         "              left JOIN ngos ngo ON cand.ngo_id=ngo.ngo_id  "   +  
         "              left JOIN disability_types disability ON cand.disability_id=disability.disability_id  "   +  
         "              left JOIN disability_sub_types disab_sub_type ON cand.disability_sub_type_id=disab_sub_type.disability_sub_type_id   "   +  
         "              left JOIN states state ON  "   +  
         "cand.present_address_state_id=state.state_id  "   +  
         "              left JOIN cities city ON  "   +  
         "cand.present_address_city_id=city.city_id  "   +  
         "              left join candidate_recommended_roles c_rol on cand.candidate_id= c_rol.candidate_id  "   +  
         "              left join job_roles jb_rl on cand_work_expr.job_role_id=jb_rl.job_role_id  "   +  
         "              left join jobs on jb_rl.job_id=jobs.job_id   "   +  
         "              left join companies comp on cand_work_expr.company_id=comp.company_id   "   +  
         "              left join parent_companies par_comp on cand_work_expr.parent_company_id=par_comp.company_id  "   +  
         "              left join industry_segments ind on comp.industry_segment_id=ind.industry_segment_id  "   +  
         "              left join candidates_assigned_to_employment_project  "   +  
         "cand_ass_emp_proj on  "   +  
         "cand_work_expr.candidate_id=cand_ass_emp_proj.candidate_id  "   +  
         "and cand_ass_emp_proj.got_job=1 and cand_ass_emp_proj.is_candidate_deleted=0 " +
         "               and cand_ass_emp_proj.employment_project_id  "   +  
         "              left join employment_projects emp_proj on cand_ass_emp_proj.employment_project_id=emp_proj.employment_project_id and  "   +  
         "emp_proj.is_closed=0  "   +  
         "              or (cand_work_expr.company_id=emp_proj.company_id and cand_work_expr.parent_company_id=emp_proj.parent_company_id and cand_work_expr.job_role_id=emp_proj.job_role_id )  "   +  
         "              left join vacancies vac on emp_proj.vacancy_id=vac.vacancy_id  "   +  
         "     left join candidates_assigned_to_training_projects cand_ass on cand.candidate_id =cand_ass.candidate_id  "   +  
         "        left Join training_projects on cand_ass.training_project_id= training_projects.training_project_id  "   +  
         "           left join training_programs on training_projects.training_program_id =  "   +  
         "training_programs.training_program_id    "   +  
         "           left join employees emp on  "   +  
         "training_projects.employee_id=emp.employee_id  "   +
         "left join company_contacts compcont on cand_work_expr.company_id=compcont.company_id " +
         "             where cand.registration_id is not null and cand_work_expr.designation_to_date > curdate()  "; 
         //"               "   +  
         //"             group by cand_work_expr.candidate_id  order by cand.first_name   "   +  
       
        
        
        
     //   public string s1 = " select cand_other_detl.candidate_name_with_status as candidate_name,cand.registration_id,cand.candidate_id,disability.disability_type, " +
     //" disab_sub_type.disability_sub_type, " +
     //" (case when cand_work_expr.company_id='-1' then cand_work_expr.unlisted_company when cand_work_expr.company_id > 0 then comp.company_code end)as company_name, " +
     //" (case when cand_work_expr.parent_company_id='-1' then ''  when cand_work_expr.parent_company_id > 0 then par_comp.company_name end)as Parent_company_name," +
     //" vac.vacancy_name, (case when cand_work_expr.is_entered_from_employment_project >'0' then 'YES'  when cand_work_expr.is_entered_from_employment_project <'1'then 'NO ' end )as Got_placed_by_EI," +
     //"  (case when cand_work_expr.company_id='-1' then ''  when cand_work_expr.company_id > 0 then emp_proj.employment_project_name end )as Employment_Project, " +
     //"  cand_work_expr.designation_from_date as date_of_join,cand_work_expr.monthly_salary as salary,ind.industry_segment," +
     //" (case when jobs.job_id >'0'  then jobs.job_name  when jobs.job_name <'1' then 'Unlisted' end ) as job_Type, " +
     //" cand.recommended_job_roles as recommended_job_role,  count(distinct cand.candidate_id ) as No_of_cand_got_job," +
     //" (SELECT  count(*)  FROM disability_types disability where cand.disability_id=1 and cand.disability_id=disability.disability_id)as No_of_VI, " +
     //" (SELECT  count(*)  FROM disability_types disability where cand.disability_id=2 and cand.disability_id=disability.disability_id)as No_of_HI, " +
     //" (SELECT  count(*)  FROM disability_types disability where cand.disability_id=3 and cand.disability_id=disability.disability_id)as No_of_PD, " +
     //" (SELECT  count(*)  FROM disability_types disability where cand.disability_id=4 and cand.disability_id=disability.disability_id)as No_of_MI, " +
     //" (SELECT  count(*)  FROM disability_types disability where cand.disability_id=5 and cand.disability_id=disability.disability_id)as No_of_MR, " +
     //" (SELECT  count(*)  FROM disability_types disability where cand.disability_id=6 and cand.disability_id=disability.disability_id)as No_of_CP, " +
     //" (SELECT  count(*)  FROM disability_types disability where cand.disability_id=7 and cand.disability_id=disability.disability_id)as No_of_DB, " +
     //" (SELECT  count(*)  FROM disability_types disability where cand.disability_id=8 and cand.disability_id=disability.disability_id)as No_of_Others_disb  " +
     //"  FROM (select * from candidate_work_experience where mark_deleted=0    and designation_to_date ='5000-01-01') as cand_work_expr " +
     //"  left join   candidates cand on cand_work_expr.candidate_id= cand.candidate_id " +
     //" and is_registration_completed=1 and cand.is_active=1 " +
     //" left JOIN candidate_other_details cand_other_detl ON cand_other_detl.candidate_id=cand.candidate_id  " +
     //" left JOIN ngos ngo ON cand.ngo_id=ngo.ngo_id " +
     //" left JOIN disability_types disability ON cand.disability_id=disability.disability_id " +
     //" left JOIN disability_sub_types disab_sub_type ON cand.disability_sub_type_id=disab_sub_type.disability_sub_type_id  " +
     //" left JOIN states state ON cand.present_address_state_id=state.state_id " +
     //" left JOIN cities city ON cand.present_address_city_id=city.city_id " +
     //" left join candidate_recommended_roles c_rol on cand.candidate_id= c_rol.candidate_id " +
     //" left join job_roles jb_rl on cand_work_expr.job_role_id=jb_rl.job_role_id " +
     //" left join jobs on jb_rl.job_id=jobs.job_id  " +
     //" left join companies comp on cand_work_expr.company_id=comp.company_id  " +
     //" left join parent_companies par_comp on cand_work_expr.parent_company_id=par_comp.company_id " +
     //" left join industry_segments ind on comp.industry_segment_id=ind.industry_segment_id " +
     //" left join candidates_assigned_to_employment_project   cand_ass_emp_proj on cand_work_expr.candidate_id=cand_ass_emp_proj.candidate_id " +
     //"  and cand_ass_emp_proj.employment_project_id " +
     //" left join employment_projects emp_proj on cand_ass_emp_proj.employment_project_id=emp_proj.employment_project_id and emp_proj.is_closed=0 " +
     //" or (cand_work_expr.company_id=emp_proj.company_id and cand_work_expr.parent_company_id=emp_proj.parent_company_id and cand_work_expr.job_role_id=emp_proj.job_role_id )" +
     //" left join vacancies vac on emp_proj.vacancy_id=vac.vacancy_id" +
     //" where cand.registration_id is not null and cand_work_expr.designation_to_date > curdate() ";
        public string s2;
       // public string s3 = " group by cand_work_expr.candidate_id  order by cand.first_name";
        string s3 = "  group by cand_work_expr.candidate_work_experience_id  order by cand.first_name ";



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

        protected void btnQuery_Click(object sender, ImageClickEventArgs e)
        {
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
            int iDiff = DateTime.Compare(d1, d2);
            if (iDiff > 0)
                return;

            s2 = " and cand_work_expr.designation_from_date between '" + this.dtStartDate.SelectedDate.ToString("yyyy-MM-dd") + "' and '" + this.dtEndDate.SelectedDate.ToString("yyyy-MM-dd") + "' ";
            GetEntireInfo();
            if (myDt == null)
            {
                this.lbStatus.Text = "Wrong dates...";
                return;
            }
           // refreshReport();
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {

        }

        private void GetEntireInfo()
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
        private void refreshReport()
        {
            rptGotJobWithPlacementsN rgj = new rptGotJobWithPlacementsN();
            rgj.ReportParameters["rptHeader"].Value = "Report Got Job from : " + this.dtStartDate.SelectedDate.ToString("dd-MM-yyyy") + " to " + this.dtEndDate.SelectedDate.ToString("dd-MM-yyyy");
            rgj.table1.DataSource = myDt;
            this.tRadReport.ReportSource = rgj;
            this.tRadReport.RefreshReport();
        }

        protected void ddSelChanged(object sender, EventArgs e)
        {
            if (this.ddOptions.SelectedIndex < 0) return;
            switch (this.ddOptions.SelectedValue)
            {
                case "cn": this.tbSearch.Visible = true;
                    this.dtSearch.Visible = false;
                    this.tbSearchIntFrom.Visible = false;
                    this.tbSearchIntTo.Visible = false;
                    this.lbToTI.Visible = false;
                    this.lbSelection.Text = "Searach Candidate wise";
                    break;
                case "ci":
                case "ri":
                case "sl":
                    this.tbSearch.Visible = false;
                    this.dtSearch.Visible = false;
                    this.tbSearchIntFrom.Visible = true;
                    this.tbSearchIntTo.Visible = true;
                    this.lbToTI.Visible = true;
                    switch (this.ddOptions.SelectedValue)
                    {
                        case "ci": this.lbSelection.Text = "Search by Candididate Id"; break;
                        case "ri": this.lbSelection.Text = "Search by Registration Id"; break;
                        case "sl": this.lbSelection.Text = "Search by Salary wise"; break;
                    }
                    break;
                case "pe":
                case "po":
                    this.tbSearch.Visible = false;
                    this.dtSearch.Visible = false;
                    this.tbSearchIntFrom.Visible = false;
                    this.tbSearchIntTo.Visible = false;
                    this.lbToTI.Visible = false;
                    switch (this.ddOptions.SelectedValue)
                    {
                        case "pe": this.lbSelection.Text = "Search by Got Job EI"; break;
                        case "po": this.lbSelection.Text = "Search by Got Job Non EI"; break;
                    }
                    break;

                case "dj":
                    this.tbSearch.Visible = false;
                    this.dtSearch.Visible = true;
                    this.tbSearchIntFrom.Visible = false;
                    this.tbSearchIntTo.Visible = false;
                    this.lbToTI.Visible = false;
                    break;
            }
        }

        protected void btnGet_Click(object sender, ImageClickEventArgs e)
        {
            int i = 0;
            bool[] dRecs = new bool[1];
            int v1 = 0;
            int v2 = 0;
            int dValue = 0;
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
            if (this.ddOptions.SelectedValue == "ci" || this.ddOptions.SelectedValue == "ri" || this.ddOptions.SelectedValue == "sl")
            {
                if (string.IsNullOrEmpty(this.tbSearchIntFrom.Text) && string.IsNullOrEmpty(this.tbSearchIntTo.Text))
                {
                    this.lbStatus.Text = "Textbox fields empty for comparison";
                    return;
                }
                if (string.IsNullOrEmpty(this.tbSearchIntFrom.Text))
                {
                    this.lbStatus.Text = "From field cannot be empty";
                    return;
                }
                if (string.IsNullOrEmpty(this.tbSearchIntTo.Text))
                {
                    this.tbSearchIntTo.Text = "999999";
                }
                v1 = Convert.ToInt32(this.tbSearchIntFrom.Text.ToString().Trim());
                v2 = Convert.ToInt32(this.tbSearchIntTo.Text.ToString().Trim());

                if (v1 > v2)
                {
                    this.lbStatus.Text = "From value should be either less than or equal to second";
                    return;
                }
            }
            switch (this.ddOptions.SelectedValue)
            {
                case "cn":
                    dRecs = new bool[myDt.Rows.Count + 1];
                    if (string.IsNullOrEmpty(this.tbSearch.Text)) return;
                    foreach (DataRow dr in myDt.Rows)
                    {
                        Match match = Regex.Match(dr[0].ToString().ToUpper(), this.tbSearch.Text.ToUpper());
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

                case "ci":
                    dRecs = new bool[myDt.Rows.Count + 1];
                    foreach (DataRow dr in myDt.Rows)
                    {
                        dValue = Convert.ToInt32(dr[2].ToString().Trim());
                        if (dValue >= v1 && dValue <= v2)
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
                case "ri":
                    dRecs = new bool[myDt.Rows.Count + 1];
                    foreach (DataRow dr in myDt.Rows)
                    {
                        if (string.IsNullOrEmpty(dr[11].ToString()))
                        {
                            dRecs[i] = true;
                            i++;
                            continue;
                        }
                        string sdValue = Regex.Replace(dr[1].ToString(), @"[a-z]|[A-Z]|\s", "");
                        dValue = Convert.ToInt32(sdValue);
                        if (dValue >= v1 && dValue <= v2)
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
                case "sl":
                    dRecs = new bool[myDt.Rows.Count + 1];
                    foreach (DataRow dr in myDt.Rows)
                    {
                        if (string.IsNullOrEmpty(dr[11].ToString()))
                        {
                            dRecs[i] = true;
                            i++;
                            continue;
                        }
                        int index = dr[11].ToString().IndexOf('.');
                        string sal = index >= 0 && (index + 1) < dr[11].ToString().Length ? dr[11].ToString().Substring(0, index) : "0".ToString();

                        dValue = Convert.ToInt32(sal);
                        if (dValue >= v1 && dValue <= v2)
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
                case "pe":
                case "po":
                    dRecs = new bool[myDt.Rows.Count + 1];
                    // if (string.IsNullOrEmpty(this.tbSearchInt.Text)) return;
                    string compStr = this.ddOptions.SelectedValue == "pe" ? "YES" : "NO";
                    foreach (DataRow dr in myDt.Rows)
                    {
                        if (dr[8].ToString().ToUpper().Trim() == compStr.Trim())
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
                case "dj":
                    if (this.dtSearch.SelectedDate.ToString("yyyy-MM-dd") == "0001-01-01")
                    {
                        this.lbStatus.Text = "Wrong date...";
                        return;
                    }
                    dRecs = new bool[myDt.Rows.Count + 1];
                    DateTime d2 = this.dtSearch.SelectedDate;
                    DateTime d1 = this.dtEndDate.SelectedDate;
                    int iDiff = 0;

                    foreach (DataRow dr in myDt.Rows)
                    {
                        if (string.IsNullOrEmpty(dr[10].ToString()))
                        {
                            dRecs[i] = true;
                            i++;
                            return;
                        }
                        try
                        {
                            d1 = DateTime.Parse(dr[10].ToString());
                        }
                        catch
                        {
                            dRecs[i] = true;
                            i++;
                            return;
                        }
                        iDiff = DateTime.Compare(d1, d2);
                        if (iDiff == 0)
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
            this.tRadReport.ReportSource = null;
            this.tRadReport.RefreshReport();
            refreshReport();

        }
        private string ExtractNumbers(string expr)
        {
            return string.Join(null, System.Text.RegularExpressions.Regex.Split(expr, "[^.\\d]"));
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
            // GetEntireInfo();

        }

        protected void btnClose_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }

        protected void btnChart_Click(object sender, ImageClickEventArgs e)
        {
            int i = 0;
            int j = 0;
            int iDiff1 = 0;
            int iDiff2 = 0;
            int iTotDays = 0;
            string sTotDays = "";
            DateTime stDate = this.dtStartDate.SelectedDate;
            DateTime edDate = this.dtEndDate.SelectedDate;
            DateTime d1 = this.dtStartDate.SelectedDate;
            DateTime d2 = this.dtEndDate.SelectedDate;
            int iDiff = DateTime.Compare(d1, d2);
            if (myDt == null)
            {
                this.lbStatus.Text = "No Data for chart";
                return;
            }
            if (myDt.Rows.Count == 0)
            {
                this.lbStatus.Text = "No Data for chart";
                return;
            }
            this.lbStatus.Text = "";
            if (iDiff >= 0)
            {
                this.lbStatus.Text = "Start date > than end date";
                return;
            }
            double df = (d2 - d1).TotalDays + 1;
            if (df < 15)
            {
                this.lbStatus.Text = "Too less Days to chart";
                return;
            }
            // ------------------------------------------------
            // Find number of intervals  for chart 
            // ------------------------------------------------
            int noIntervals = 0;
            int intSize = 15;
            for (i = 0; ; i++)
            {
                noIntervals = (int)df / intSize;
                if (noIntervals < 20) break;
                intSize += 15;
            }
            if (((int)df % intSize) > 0) noIntervals++;
            // ---------------------------------------------------------------
            // Startcounting the number of records under each of the intervals
            // ---------------------------------------------------------------
            for (i = 0; i < noIntervals; i++)
            {
                iTotDays = 0;
                if (i == 0)
                {
                    d1 = this.dtStartDate.SelectedDate;
                }
                else
                {
                    d1 = d1.AddDays(intSize);
                }
                d2 = d1.AddDays(intSize);
                foreach (DataRow dr in myDt.Rows)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(dr[10].ToString())) continue;
                        DateTime sDt = Convert.ToDateTime(dr[10]);
                        iDiff1 = DateTime.Compare(sDt, d1);
                        iDiff2 = DateTime.Compare(sDt, d2);
                        if (iDiff1 >= 0 && iDiff2 < 0)
                            iTotDays++;
                    }
                    catch
                    {
                        continue;
                    }
                }
                sTotDays += iTotDays.ToString() + ":";
            }
            string chartPage = "";
            string u1 = HttpContext.Current.Request.Url.AbsoluteUri;
            chartPage = u1.Replace("/ReportSection/GotJobWithPlacements.aspx", "/Reports/rptJobPlaceCharts.aspx");

            chartPage += "?TotDays=" + df.ToString();
            chartPage += "&StartDate=" + this.dtStartDate.SelectedDate.ToString("dd/MM/yyyy");
            chartPage += "&EndDate=" + this.dtEndDate.SelectedDate.ToString("dd/MM/yyyy");
            chartPage += "&IntSize=" + intSize.ToString();
            chartPage += "&NoIntervals=" + noIntervals.ToString();
            chartPage += "&Title=Got Jobs";
            chartPage += "&sTotDays=" + sTotDays;
            chartPage += "&NoRecs=" + this.lbNoRec.Text;
            chartPage += "&countIndex=" + "10".ToString();
            Session["myDt"] = myDt;
            ClientScript.RegisterStartupScript(this.GetType(), this.GetType().Name, string.Format("window.open('{0}', '_blank');", chartPage), true);

        }
        protected void dtEndDate_SelectionChanged(object sender, EventArgs e)
        {
        }

        protected void dtStartDate_SelectionChanged(object sender, EventArgs e)
        {
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
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
            int iDiff = DateTime.Compare(d1, d2);
            if (iDiff > 0)
                return;

            s2 = " and cand_work_expr.designation_from_date between '" + this.dtStartDate.SelectedDate.ToString("yyyy-MM-dd") + "' and '" + this.dtEndDate.SelectedDate.ToString("yyyy-MM-dd") + "' ";

            string u1 = HttpContext.Current.Request.Url.AbsoluteUri;
            Session["reportQuery"] = s1 + s2 + s3;
            string fmgurl = u1.Replace("ReportSection/GotJobWithPlacements", "Reports/RadReport");
            fmgurl += "?Report=GotJobWithPlacements&rptHeader=" + "Report Got Job from : " + this.dtStartDate.SelectedDate.ToString("dd-MM-yyyy") + " to " + this.dtEndDate.SelectedDate.ToString("dd-MM-yyyy");
            ClientScript.RegisterStartupScript(this.GetType(), this.GetType().Name, string.Format("window.open('{0}', '_blank');", fmgurl), true);
            return;

        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {

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
            DateTime d1 = this.dtStartDate.SelectedDate;
            DateTime d2 = this.dtEndDate.SelectedDate;
            int iDiff = DateTime.Compare(d1, d2);
            if (iDiff > 0)
                return;

            s2 = " and cand_work_expr.designation_from_date between '" + this.dtStartDate.SelectedDate.ToString("yyyy-MM-dd") + "' and '" + this.dtEndDate.SelectedDate.ToString("yyyy-MM-dd") + "' ";
            GetEntireInfo();
            if (myDt == null)
            {
                this.lbStatus.Text = "Wrong dates...";
                return;
            }
            myConn = gb.SetLocalConnection();
            string sqlStr = s1 + s2 + s3;
            myDt = new DataTable();
            //string sqlStr = "select agentid, company, first_name, email, address1, city, state, pincode, mobile  from agent_master where status <> 'inactive'";
            mySqlAdapter = new MySqlDataAdapter(sqlStr, myConn);
            mySqlAdapter.SelectCommand.CommandTimeout = 1200;
            //      mySqlAdapter.Fill(myDataSet);
            mySqlAdapter.Fill(myDt);
            ViewState["myDt"] = myDt;
        }

        protected void btnExport_Click(object sender, ImageClickEventArgs e)
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
            int i = 0;
            StringBuilder xlDocBody = new StringBuilder(); ;
            // -------------------------------------------------
            // Create dir for storing....
            // ------------------------------------------------
            string dirPath = System.Configuration.ConfigurationManager.AppSettings["ExcelReports"];
            dirPath += "\\GotJobWithTrainingPrograms" + DateTime.Now.ToString("ddMMyyhhmm") + ".xls"; 
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
                xlDocBody.Append("GotJob with Training Program " +  DateTime.Now.ToString("dd/MM/yyyy"));
                xlDocBody.Append("</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Start Date: " + this.dtStartDate.SelectedDate.ToString("dd/MM/yyyy") + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "End Date: " + this.dtEndDate.SelectedDate.ToString("dd/MM/yyyy") + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;\" border=\"1\">" + "Number of entries: " + myDt.Rows.Count.ToString() + "</td>");
                xlDocBody.Append("<tr><td width=\"25\"> </td></tr>");
                xlDocBody.Append("<tr>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Candidate Name" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Reg Id" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Cand Id" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Disability Type" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Disability Sub Type" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Parent Company" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Company" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Vacancy" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Got placed by EI" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Employment Project" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Date of Join" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Salary" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Industry Segment" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Job Type" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Reco Job Role" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Training Program " + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Training Project" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Managed By" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Contact Name" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Contact Phone" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "Employee Proof Received" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No Got Job" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No of VI" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No of HI" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No of DB" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No of MI" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No of MR" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No of CP" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No of DB" + "</td>");
                xlDocBody.Append("<td valign=\"middle\" align=\"center\" style=\"width:50px;background-color:#EFE6FA;\" border=\"1\">" + "No of Oth" + "</td>");
                xlDocBody.Append("</tr>");
                //
                // Add Data Rows
                foreach(DataRow dRow in myDt.Rows)
                {
                    xlDocBody.Append("<tr>");
                    for(i = 0;i < 30;i++)
                    {
                        xlDocBody.Append("<td valign=\"middle\" align=\"center\"> " + dRow[i].ToString() + "</td>");
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
                ; ;
            }
 
        }
    }
}