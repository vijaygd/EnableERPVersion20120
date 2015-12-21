using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql;
using MySql.Data;
using MySql.Web;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using EnableIndia.ReportSection;
using EnableIndia.Reports;

namespace EnableIndia
{
    public partial class PlacementsN : System.Web.UI.Page
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
        string s1 = " select cand_other_detl.candidate_name_with_status as candidate_name,cand.registration_id,cand.candidate_id,disability.disability_type," +
            " disab_sub_type.disability_sub_type, " +
            " (case when cand_work_expr.company_id='-1' then cand_work_expr.unlisted_company when cand_work_expr.company_id > 0 then comp.company_code end)as company_name, " +
            " (case when cand_work_expr.parent_company_id='-1' then ''  when cand_work_expr.parent_company_id > 0 then par_comp.company_name end)as Parent_company_name," +
            " vac.vacancy_name, (case when cand_work_expr.is_entered_from_employment_project >'0' then 'YES'  when cand_work_expr.is_entered_from_employment_project <'1'then 'NO ' end )as Got_placed_by_EI," +
            "  (case when cand_work_expr.company_id='-1' then ''  when cand_work_expr.company_id > 0 then emp_proj.employment_project_name end )as Employment_Project, " +
            "  cand_work_expr.designation_from_date as date_of_join,cand_work_expr.monthly_salary as salary,ind.industry_segment," +
            " (case when jobs.job_id >'0'  then jobs.job_name  when jobs.job_name <'1' then 'Unlisted' end ) as job_Type, " +
            " cand.recommended_job_roles as recommended_job_role,  count(distinct cand.candidate_id ) as No_of_cand_got_job," +
            " (SELECT  count(*)  FROM disability_types disability where cand.disability_id=1 and cand.disability_id=disability.disability_id)as No_of_VI, " +
            " (SELECT  count(*)  FROM disability_types disability where cand.disability_id=2 and cand.disability_id=disability.disability_id)as No_of_HI, " +
            " (SELECT  count(*)  FROM disability_types disability where cand.disability_id=3 and cand.disability_id=disability.disability_id)as No_of_PD, " +
            " (SELECT  count(*)  FROM disability_types disability where cand.disability_id=4 and cand.disability_id=disability.disability_id)as No_of_MI, " +
            " (SELECT  count(*)  FROM disability_types disability where cand.disability_id=5 and cand.disability_id=disability.disability_id)as No_of_MR, " +
            " (SELECT  count(*)  FROM disability_types disability where cand.disability_id=6 and cand.disability_id=disability.disability_id)as No_of_CP, " +
            " (SELECT  count(*)  FROM disability_types disability where cand.disability_id=7 and cand.disability_id=disability.disability_id)as No_of_DB, " +
            " (SELECT  count(*)  FROM disability_types disability where cand.disability_id=8 and cand.disability_id=disability.disability_id)as No_of_Others_disb  " +
            "  FROM (select * from candidate_work_experience where mark_deleted=0  and is_entered_from_employment_project=1 ) as cand_work_expr" +
            "  left join   candidates cand on cand_work_expr.candidate_id= cand.candidate_id" +
            " and is_registration_completed=1 and cand.is_active=1 " +
            " 	          left JOIN candidate_other_details cand_other_detl ON cand_other_detl.candidate_id=cand.candidate_id  " +
            " left JOIN ngos ngo ON cand.ngo_id=ngo.ngo_id " +
            " left JOIN disability_types disability ON cand.disability_id=disability.disability_id " +
            " left JOIN disability_sub_types disab_sub_type ON cand.disability_sub_type_id=disab_sub_type.disability_sub_type_id  " +
            "  left JOIN states state ON cand.present_address_state_id=state.state_id" +
            " left JOIN cities city ON cand.present_address_city_id=city.city_id " +
            " left join candidate_recommended_roles c_rol on cand.candidate_id= c_rol.candidate_id " +
            " left join job_roles jb_rl on cand_work_expr.job_role_id=jb_rl.job_role_id " +
            " left join jobs on jb_rl.job_id=jobs.job_id  " +
            " left join companies comp on cand_work_expr.company_id=comp.company_id  " +
            " left join parent_companies par_comp on cand_work_expr.parent_company_id=par_comp.company_id " +
            " left join industry_segments ind on comp.industry_segment_id=ind.industry_segment_id " +
            " left join candidates_assigned_to_employment_project   cand_ass_emp_proj on cand_work_expr.candidate_id=cand_ass_emp_proj.candidate_id " +
            " and cand_ass_emp_proj.got_job=1 and cand_ass_emp_proj.is_candidate_deleted=0 " +
            " and cand_ass_emp_proj.employment_project_id" +
            " left join employment_projects emp_proj on cand_ass_emp_proj.employment_project_id=emp_proj.employment_project_id and emp_proj.is_closed=0" +
            " or (cand_work_expr.company_id=emp_proj.company_id and cand_work_expr.parent_company_id=emp_proj.parent_company_id and cand_work_expr.job_role_id=emp_proj.job_role_id )" +
            "  left join vacancies vac on emp_proj.vacancy_id=vac.vacancy_id  " +
            "  where cand.registration_id is not null  and cand_work_expr.is_entered_from_employment_project=1 ";
        string s2 = "";
        string s3 = "  group by cand_work_expr.candidate_work_experience_id  order by cand.first_name ";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
            this.lbStatus.Text = "";
            if (iDiff > 0)
            {
                this.lbStatus.Text = "Wrong dates...";
                return;
            }
            s2 = " and cand_work_expr.designation_from_date between '" + this.dtStartDate.SelectedDate.ToString("yyyy-MM-dd") + "' and '" + this.dtEndDate.SelectedDate.ToString("yyyy-MM-dd") + "' ";
            GetEntireInfo();
            if (myDt == null)
                return;
            refreshReport();

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
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            //instanceReportSource1.ReportDocument = report1;
            //rptGotJobN rgj = new rptGotJobN();
                rptGotJobPlacements rgj = new rptGotJobPlacements();
            rgj.ReportParameters["rptHeader"].Value = "Pacements from " + this.dtStartDate.SelectedDate.ToString("dd-MM-yyyy") + " to " + this.dtEndDate.SelectedDate.ToString("dd-MM-yyyy");
            rgj.table1.DataSource = myDt;
            instanceReportSource1.ReportDocument = rgj;
            this.tRadReport.ReportSource = instanceReportSource1;
            this.tRadReport.RefreshReport();
            this.lbNoRec.Text = myDt.Rows.Count.ToString();
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

    }
}