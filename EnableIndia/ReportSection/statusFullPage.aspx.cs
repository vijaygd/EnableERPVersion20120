using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;
using System.Data;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Reflection;

namespace EnableIndia.ReportSection
{

    public partial class statusFullPage : System.Web.UI.Page
    {
        public struct searchDates
        {
            public string stDate;
            public string edDate;
            public int noc;
        }
        searchDates[] gotJobDates = new searchDates[6];
        searchDates[] placedDates = new searchDates[6];
        searchDates[] regcanDates = new searchDates[6];
        searchDates[] triprjDates = new searchDates[6];
        searchDates[] empprjDates = new searchDates[6];
        searchDates[] tripEdDates = new searchDates[6];
        searchDates[] regCands = new searchDates[6];
        searchDates[] udtCands = new searchDates[6];
        searchDates[] trnCands = new searchDates[6];

        public string[] xLabels = new string[6];
        public string[] alphaMonhts = { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public int[] noDaysPerMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public bool bPo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                setDates();
                fillCharts();
                getAllActiveRegisteredCandidates();
                getTrainingProjectsStDateWise();
                getTrainingProjectsEDDateWise();
                getEmploymentProjects();
                getTrnCandidates();
                getUnderTraining();
                getRegCandidates();
                bPo = false;
                ViewState["bPo"] = bPo;
                this.dtBaseDate.SelectedDate = DateTime.Today;
            }
            if(Page.IsPostBack)
            {
                if (ViewState["bPo"] != null)
                {
                    bPo = Convert.ToBoolean(ViewState["bPo"]);
                }
                setDates();
            }

        }
        public void setDates()
        {
            int i = 0;
            DateTime Today = DateTime.Today;
            // Calculate 6 Months before perid.
            DateTime tDate = DateTime.Today;
            if (this.dtBaseDate.SelectedDate.ToString().Substring(0, 10) == "01/01/0001" || this.dtBaseDate.SelectedDate.ToString().Substring(0, 8) == "1/1/0001")
            {
                this.dtBaseDate.SelectedDate = DateTime.Today;
            }
            tDate = this.dtBaseDate.SelectedDate;
            DateTime stDate = tDate;
            int dpm = 0;
            for (i = 5; i >= 0; i--)
            {
                gotJobDates[i].edDate = stDate.Year.ToString() + "-" + stDate.Month.ToString("00") + "-" + stDate.Day.ToString("00");
                placedDates[i].edDate = stDate.Year.ToString() + "-" + stDate.Month.ToString("00") + "-" + stDate.Day.ToString("00");
                regcanDates[i].edDate = stDate.Year.ToString() + "/" + stDate.Month.ToString("00") + "/" + stDate.Day.ToString("00");
                triprjDates[i].edDate = stDate.Year.ToString() + "/" + stDate.Month.ToString("00") + "/" + stDate.Day.ToString("00");
                empprjDates[i].edDate = stDate.Year.ToString() + "/" + stDate.Month.ToString("00") + "/" + stDate.Day.ToString("00");
                tripEdDates[i].edDate = stDate.Year.ToString() + "/" + stDate.Month.ToString("00") + "/" + stDate.Day.ToString("00");
                regCands[i].edDate = stDate.Year.ToString() + "-" + stDate.Month.ToString("00") + "-" + stDate.Day.ToString("00");
                trnCands[i].edDate = stDate.Year.ToString() + "-" + stDate.Month.ToString("00") + "-" + stDate.Day.ToString("00");
                udtCands[i].edDate = stDate.Year.ToString() + "-" + stDate.Month.ToString("00") + "-" + stDate.Day.ToString("00");
                if ((stDate.Year) % 4 == 0 && stDate.Month == 2)
                {
                    dpm = 29;
                }
                else
                {
                    dpm = noDaysPerMonth[stDate.Month];
                }
                stDate = stDate.AddDays(-dpm);
                //stDate = stDate.AddMonths(-1);
                tDate = stDate.AddDays(1);
                
                // tDate = stDate;
                gotJobDates[i].stDate = tDate.Year.ToString() + "-" + tDate.Month.ToString("00") + "-" + tDate.Day.ToString("00");
                placedDates[i].stDate = tDate.Year.ToString() + "-" + tDate.Month.ToString("00") + "-" + tDate.Day.ToString("00");
                regcanDates[i].stDate = tDate.Year.ToString() + "/" + tDate.Month.ToString("00") + "/" + tDate.Day.ToString("00");
                triprjDates[i].stDate = tDate.Year.ToString() + "/" + tDate.Month.ToString("00") + "/" + tDate.Day.ToString("00");
                empprjDates[i].stDate = tDate.Year.ToString() + "/" + tDate.Month.ToString("00") + "/" + tDate.Day.ToString("00");
                tripEdDates[i].stDate = tDate.Year.ToString() + "/" + tDate.Month.ToString("00") + "/" + tDate.Day.ToString("00");
                regCands[i].stDate = tDate.Year.ToString() + "-" + tDate.Month.ToString("00") + "-" + tDate.Day.ToString("00");
                trnCands[i].stDate = tDate.Year.ToString() + "-" + tDate.Month.ToString("00") + "-" + tDate.Day.ToString("00");
                udtCands[i].stDate = tDate.Year.ToString() + "-" + tDate.Month.ToString("00") + "-" + tDate.Day.ToString("00");
            }

        }
        private void fillCharts()
        {
            int i = 0;
            int j = 0;
            int iCount = 0;
            string sqlStr = "";
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("", conn);
            // ------------------------
            // First fill got jobs.....
            // ------------------------

            string gotJobQuery = "select count(*) from ((select count(*) " +
                                   " FROM (select * from candidate_work_experience where mark_deleted=0   " +
                                   " and designation_to_date ='5000-01-01') as cand_work_expr  " +
                                   " left join candidates cand on cand_work_expr.candidate_id= cand.candidate_id  and is_registration_completed=1 and cand.is_active=1 " +
                                   " left JOIN candidate_other_details cand_other_detl ON cand_other_detl.candidate_id=cand.candidate_id  " +
                                   " left JOIN ngos ngo ON cand.ngo_id=ngo.ngo_id  " +
                                   " left JOIN disability_types disability ON cand.disability_id=disability.disability_id " +
                                   " left JOIN disability_sub_types disab_sub_type ON cand.disability_sub_type_id=disab_sub_type.disability_sub_type_id " +
                                   " left JOIN states state ON cand.present_address_state_id=state.state_id " +
                                   " left JOIN cities city ON cand.present_address_city_id=city.city_id " +
                                   " left join candidate_recommended_roles c_rol on cand.candidate_id= c_rol.candidate_id   " +
                                   " left join job_roles jb_rl on cand_work_expr.job_role_id=jb_rl.job_role_id " +
                                   " left join jobs on jb_rl.job_id=jobs.job_id   " +
                                   " left join companies comp on cand_work_expr.company_id=comp.company_id   " +
                                   " left join parent_companies par_comp on cand_work_expr.parent_company_id=par_comp.company_id " +
                                   " left join industry_segments ind on comp.industry_segment_id=ind.industry_segment_id  " +
                                   " left join candidates_assigned_to_employment_project   cand_ass_emp_proj on cand_work_expr.candidate_id=cand_ass_emp_proj.candidate_id   and cand_ass_emp_proj.employment_project_id " +
                                   " left join employment_projects emp_proj on cand_ass_emp_proj.employment_project_id=emp_proj.employment_project_id and emp_proj.is_closed=0  or (cand_work_expr.company_id=emp_proj.company_id and cand_work_expr.parent_company_id=emp_proj.parent_company_id and cand_work_expr.job_role_id=emp_proj.job_role_id ) left join vacancies vac on emp_proj.vacancy_id=vac.vacancy_id where cand.registration_id is not null and cand_work_expr.designation_to_date > curdate()  and cand_work_expr.designation_from_date ";
            //between '2010-01-01' and '2010-12-31'  group by cand_work_expr.candidate_id 
            //order by cand.first_name)) as t;




            string placementQuery = " select count(*) from ((select count(*) " +
                                    "  FROM (select * from candidate_work_experience where mark_deleted=0  and is_entered_from_employment_project=1 ) as cand_work_expr  left join   candidates cand on cand_work_expr.candidate_id= cand.candidate_id and is_registration_completed=1 and cand.is_active=1  " +
                                    "  left JOIN candidate_other_details cand_other_detl ON cand_other_detl.candidate_id=cand.candidate_id  " +
                                    "  left JOIN ngos ngo ON cand.ngo_id=ngo.ngo_id " +
                                    "  left JOIN disability_types disability ON cand.disability_id=disability.disability_id " +
                                    "  left JOIN disability_sub_types disab_sub_type ON cand.disability_sub_type_id=disab_sub_type.disability_sub_type_id  " +
                                    "  left JOIN states state ON cand.present_address_state_id=state.state_id left JOIN cities city ON cand.present_address_city_id=city.city_id " +
                                    "  left join candidate_recommended_roles c_rol on cand.candidate_id= c_rol.candidate_id " +
                                    "  left join job_roles jb_rl on cand_work_expr.job_role_id=jb_rl.job_role_id " +
                                    "  left join jobs on jb_rl.job_id=jobs.job_id " +
                                    "  left join companies comp on cand_work_expr.company_id=comp.company_id  " +
                                    "  left join parent_companies par_comp on cand_work_expr.parent_company_id=par_comp.company_id " +
                                    "  left join industry_segments ind on comp.industry_segment_id=ind.industry_segment_id" +
                                    "  left join candidates_assigned_to_employment_project   cand_ass_emp_proj on cand_work_expr.candidate_id=cand_ass_emp_proj.candidate_id  and " +
                                    "  cand_ass_emp_proj.got_job=1 and cand_ass_emp_proj.is_candidate_deleted=0  and cand_ass_emp_proj.employment_project_id " +
                                    "  left join employment_projects emp_proj on cand_ass_emp_proj.employment_project_id=emp_proj.employment_project_id and emp_proj.is_closed=0 or (" +
                                    "  cand_work_expr.company_id=emp_proj.company_id and cand_work_expr.parent_company_id=emp_proj.parent_company_id and cand_work_expr.job_role_id=emp_proj.job_role_id )  " +
                                    "  left join vacancies vac on emp_proj.vacancy_id=vac.vacancy_id  " +
                                    "  where cand.registration_id is not null  and cand_work_expr.is_entered_from_employment_project=1 ";
            string s2;
           // string s3 = " group by cand_work_expr.candidate_work_experience_id order by cand.first_name )) as t";
            string s3 = " group by cand_work_expr.candidate_id  order by cand.first_name )) as t";


            this.lbStatusDate.Text = Convert.ToDateTime(gotJobDates[0].stDate).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(gotJobDates[5].edDate).ToString("dd/MM/yyyy");
            for (i = 5; i >= 0; i--)
            {
                MySqlDataReader reader;
                s2 = " and cand_work_expr.designation_from_date between '" + gotJobDates[i].stDate + "' and '" + gotJobDates[i].edDate + "' ";
                sqlStr = gotJobQuery + s2 + s3;
                cmd.CommandText = sqlStr;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    gotJobDates[i].noc = reader.GetInt32(0);

                }
                reader.Close();
            }
            for (i = 5; i >= 0; i--)
            {
                MySqlDataReader reader;
                s2 = " and cand_work_expr.designation_from_date between '" + placedDates[i].stDate + "' and '" + placedDates[i].edDate + "' ";
                sqlStr = placementQuery + s2 + s3;
                cmd.CommandText = sqlStr;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    placedDates[i].noc = reader.GetInt32(0);
                }
                reader.Close();
            }
            cmd.Dispose();
            conn.Close();
            conn = null;
            fillXlabels();
            // -----------------------------------------------
            // Populate the graphs.....
            // -----------------------------------------------
            try
            {
                this.gotJobsChart.Series["gotJobSeries"].SmartLabelStyle.Enabled = false;
                this.gotJobsChart.ChartAreas[0].AxisX.Title = "Months";
                this.gotJobsChart.ChartAreas[0].AxisY.Title = " Candidate Numbers";
                this.gotJobsChart.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Blue;
                this.gotJobsChart.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Blue;
                this.gotJobsChart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.gotJobsChart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.gotJobsChart.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                this.gotJobsChart.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
                this.gotJobsChart.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Blue;
                this.gotJobsChart.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.gotJobsChart.ChartAreas[0].AxisX.Interval = 1;
                this.gotJobsChart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                iCount = 0;
                double dnoCandidates = 0;
                for (i = 0; i < 6; i++)
                {
                    dnoCandidates = Convert.ToDouble(gotJobDates[i].noc);
                    this.gotJobsChart.Series[0].Points.AddXY(xLabels[i], dnoCandidates);
                    this.gotJobsChart.Series[0].Points[i].Label = dnoCandidates.ToString();
                    iCount += gotJobDates[i].noc;
                }
                this.lbJobObtainedTot.Text = iCount.ToString();
            }
            catch (System.Exception ex)
            {
                // his.lbStatus.Text = ex.Message;
            }
            // ------------------------------------------------
            // Fill placements......
            // ------------------------------------------------
            try
            {
                this.placements.Series["placementsSeries"].SmartLabelStyle.Enabled = false;
                this.placements.ChartAreas[0].AxisX.Title = "Months";
                this.placements.ChartAreas[0].AxisY.Title = " Candidate Numbers";
                this.placements.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Blue;
                this.placements.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Blue;
                this.placements.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.placements.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.placements.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                this.placements.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
                this.placements.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Blue;
                this.placements.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.placements.ChartAreas[0].AxisX.Interval = 1;
                this.placements.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                double dnoCandidates = 0;
                iCount = 0;
                for (i = 0; i < 6; i++)
                {
                    dnoCandidates = Convert.ToDouble(placedDates[i].noc);
                    this.placements.Series[0].Points.AddXY(xLabels[i], dnoCandidates);
                    this.placements.Series[0].Points[i].Label = dnoCandidates.ToString();
                    iCount += placedDates[i].noc;
                }
                this.lbPlacementsTot.Text = iCount.ToString();
            }
            catch (System.Exception ex)
            {
                // his.lbStatus.Text = ex.Message;
            }

        }
        private void fillXlabels()
        {
            int i = 0;
            DateTime d1;
            DateTime d2;
            for (i = 0; i < 6; i++)
            {
                d1 = Convert.ToDateTime(gotJobDates[i].stDate);
                d2 = Convert.ToDateTime(gotJobDates[i].edDate);
                xLabels[i] = alphaMonhts[d1.Month] + "-" + alphaMonhts[d2.Month];
            }
            // -- Check for duplicate months.....
            // ----------------------------------
            for (i = 0; i < 6; i++)
            {
                string[] month = xLabels[i].Split((char)'-');
                if (month != null)
                {
                    if (month.Length == 2)
                    {
                        if (month[0] == month[1])
                           xLabels[i] = month[0];
                    }
                }
            }
        }
        private void getAllActiveRegisteredCandidates()
        {
            int iCount = 0;
            int i = 0;
            CandidatesBAL cand = new CandidatesBAL();
            cand.CandidateID = -1;
            cand.IsProfiled = "All";
            cand.EmploymentStatus = -1;
            cand.Assignment = "All";
            cand.StateID = -1;
            cand.CityID = -1;
            cand.AgeGroup = 13;
            cand.ContractExpiryDate = "0";
            cand.NgoID = -1;
            cand.SearchFor = "";
            cand.SearchIn = "registration_id";
            cand.DisabilityID = -1;
            cand.DisabilitySubTypeID = -1;
            cand.RecommendedJobID = -1;
            cand.RecommendedJobRoleID = -1;
            cand.MissingDataProfile = "All";
            cand.GroupID = -1;
            cand.LanguageID = -1;
            cand.Gender = "All";
            cand.CompanyID = -1;
            cand.QualificationID = -1;
            //cand.RegistrationFrom = "1900/01/01";
            //cand.RegistrationTo = "5000/01/01";
            cand.DateOfBirth = "1900/01/01";
            cand.SalaryFrom = 0;
            cand.SalaryTo = 999999;
            cand.EmployentProjectStartDateFrom = "1900/01/01";
            cand.EmployentProjectStartDateTo = "5000/01/01";
            cand.EmployentProjectEndDateFrom = "1900/01/01";
            cand.EmployentProjectEndDateTo = "5000/01/01";
            for (i = 5; i >= 0; i--)
            {
                cand.RegistrationFrom = regcanDates[i].stDate;
                cand.RegistrationTo = regcanDates[i].edDate;
                DataTable dt = cand.GetAllActiveRegisteredCandidate(cand);
                regcanDates[i].noc = dt.Rows.Count;
            }
            try
            {
                this.activeCandidates.Series["acSeries"].SmartLabelStyle.Enabled = false;
                this.activeCandidates.ChartAreas[0].AxisX.Title = "Months";
                this.activeCandidates.ChartAreas[0].AxisY.Title = " Candidate Numbers";
                this.activeCandidates.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Blue;
                this.activeCandidates.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Blue;
                this.activeCandidates.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.activeCandidates.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.activeCandidates.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                this.activeCandidates.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
                this.activeCandidates.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Blue;
                this.activeCandidates.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.activeCandidates.ChartAreas[0].AxisX.Interval = 1;
                this.activeCandidates.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                double dnoCandidates = 0;
                for (i = 0; i < 6; i++)
                {
                    dnoCandidates = Convert.ToDouble(regcanDates[i].noc);
                    this.activeCandidates.Series[0].Points.AddXY(xLabels[i], dnoCandidates);
                    this.activeCandidates.Series[0].Points[i].Label = dnoCandidates.ToString();
                    iCount += regcanDates[i].noc;
                }
                this.lbActiveCandidatesTot.Text = iCount.ToString();
            }
            catch (System.Exception ex)
            {
                // his.lbStatus.Text = ex.Message;
            }
        }
        private void getTrainingProjectsStDateWise()
        {
            int iCount = 0;
            int i = 0;
            int[] projectTypes = new int[] { 0, 0 };
            EnableIndia.App_Code.BAL.TrainingProjectBAL proj = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            proj.DateType = "start";
            proj.status = -1;
            proj.TrainingProgramID = -1;
            proj.EmployeeID = -1;
            for (i = 5; i >= 0; i--)
            {
                proj.DateFrom = triprjDates[i].stDate;
                proj.DateTo = triprjDates[i].edDate;
                DataTable dtTrainingProject = proj.GetTrainingProjectInReports(proj, ref projectTypes);
                triprjDates[i].noc = dtTrainingProject.Rows.Count;
            }
            try
            {
                this.traingProgramsStDate.Series["tpSeriesStDate"].SmartLabelStyle.Enabled = false;
                this.traingProgramsStDate.ChartAreas[0].AxisX.Title = "Months";
                this.traingProgramsStDate.ChartAreas[0].AxisY.Title = " Candidate Numbers";
                this.traingProgramsStDate.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Blue;
                this.traingProgramsStDate.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Blue;
                this.traingProgramsStDate.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.traingProgramsStDate.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.traingProgramsStDate.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                this.traingProgramsStDate.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
                this.traingProgramsStDate.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Blue;
                this.traingProgramsStDate.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.traingProgramsStDate.ChartAreas[0].AxisX.Interval = 1;
                this.traingProgramsStDate.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                double dnoCandidates = 0;
                for (i = 0; i < 6; i++)
                {
                    dnoCandidates = Convert.ToDouble(triprjDates[i].noc);
                    this.traingProgramsStDate.Series[0].Points.AddXY(xLabels[i], dnoCandidates);
                    this.traingProgramsStDate.Series[0].Points[i].Label = dnoCandidates.ToString();
                    iCount += triprjDates[i].noc;
                }
                this.lbTrainProjStDateTot.Text = iCount.ToString();
            }
            catch (System.Exception ex)
            {
                // his.lbStatus.Text = ex.Message;
            }

        }
        private void getTrainingProjectsEDDateWise()
        {
            int i = 0;
            int iCount = 0;
            int[] projectTypes = new int[] { 0, 0 };
            EnableIndia.App_Code.BAL.TrainingProjectBAL proj = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            proj.DateType = "end";
            proj.status = -1;
            proj.TrainingProgramID = -1;
            proj.EmployeeID = -1;
            for (i = 5; i >= 0; i--)
            {
                proj.DateFrom = tripEdDates[i].stDate;
                proj.DateTo = tripEdDates[i].edDate;
                DataTable dtTrainingProject = proj.GetTrainingProjectInReports(proj, ref projectTypes);
                tripEdDates[i].noc = dtTrainingProject.Rows.Count;
            }
            try
            {
                this.traingProgramsEdDate.Series["edSeries"].SmartLabelStyle.Enabled = false;
                this.traingProgramsEdDate.ChartAreas[0].AxisX.Title = "Months";
                this.traingProgramsEdDate.ChartAreas[0].AxisY.Title = " Candidate Numbers";
                this.traingProgramsEdDate.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Blue;
                this.traingProgramsEdDate.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Blue;
                this.traingProgramsEdDate.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.traingProgramsEdDate.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.traingProgramsEdDate.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                this.traingProgramsEdDate.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
                this.traingProgramsEdDate.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Blue;
                this.traingProgramsEdDate.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.traingProgramsEdDate.ChartAreas[0].AxisX.Interval = 1;
                this.traingProgramsEdDate.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                double dnoCandidates = 0;
                for (i = 0; i < 6; i++)
                {
                    dnoCandidates = Convert.ToDouble(tripEdDates[i].noc);
                    this.traingProgramsEdDate.Series[0].Points.AddXY(xLabels[i], dnoCandidates);
                    this.traingProgramsEdDate.Series[0].Points[i].Label = dnoCandidates.ToString();
                    iCount += tripEdDates[i].noc;
                }
                this.lbTrinProjEdDateTot.Text = iCount.ToString();
            }
            catch (System.Exception ex)
            {
                // his.lbStatus.Text = ex.Message;
            }

        }
        private void getEmploymentProjects()
        {
            int i = 0;
            int iCount = 0;
            EnableIndia.App_Code.BAL.EmploymentProjectBAL emplProj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            emplProj.ProjectStatus = "-1";
            emplProj.EmploymentProjectID = -1;
            emplProj.EmploymentDateEndDateFrom = "1900/01/01";
            emplProj.EmploymentDateEndDateTo = "5000/01/01";
            emplProj.VacancyID = -1;
            emplProj.JobID = -1;
            emplProj.JobRoleID = -1;
            emplProj.GroupID = -1;
            emplProj.CompanyID = -1;
            emplProj.StateID = -1;
            emplProj.CityID = -1;
            int[] projectTypes = new int[] { 0, 0 };
            for (i = 5; i >= 0; i--)
            {
                emplProj.EmploymentDateStartDateFrom = empprjDates[i].stDate;
                emplProj.EmploymentDateStartDateTo = empprjDates[i].edDate;
                DataTable dtEmployProject = emplProj.GetEmploymentProjectsWithEmploymentStatus(emplProj, ref projectTypes);
                empprjDates[i].noc = dtEmployProject.Rows.Count;
            }
            try
            {
                this.employmentProjects.Series["epSeries"].SmartLabelStyle.Enabled = false;
                this.employmentProjects.ChartAreas[0].AxisX.Title = "Months";
                this.employmentProjects.ChartAreas[0].AxisY.Title = " Candidate Numbers";
                this.employmentProjects.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Blue;
                this.employmentProjects.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Blue;
                this.employmentProjects.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.employmentProjects.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.employmentProjects.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                this.employmentProjects.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
                this.employmentProjects.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Blue;
                this.employmentProjects.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.employmentProjects.ChartAreas[0].AxisX.Interval = 1;
                this.employmentProjects.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                double dnoCandidates = 0;
                for (i = 0; i < 6; i++)
                {
                    dnoCandidates = Convert.ToDouble(empprjDates[i].noc);
                    this.employmentProjects.Series[0].Points.AddXY(xLabels[i], dnoCandidates);
                    this.employmentProjects.Series[0].Points[i].Label = dnoCandidates.ToString();
                    iCount += empprjDates[i].noc;
                }
                this.lbEmpProjTot.Text = iCount.ToString();
            }
            catch (System.Exception ex)
            {
                // his.lbStatus.Text = ex.Message;
            }

        }
        private void getRegCandidates()
        {
            int iCount = 0;
            int i = 0;
            CandidatesBAL cand = new CandidatesBAL();
            cand.CandidateID = -1;
            cand.IsProfiled = "All";
            cand.EmploymentStatus = -1;
            cand.Assignment = "All";
            cand.StateID = -1;
            cand.CityID = -1;
            cand.AgeGroup = -1;
            cand.ContractExpiryDate = "0";
            cand.NgoID = -1;
            cand.SearchFor = "";
            cand.SearchIn = "registration_id";
            cand.DisabilityID = -1;
            cand.DisabilitySubTypeID = -1;
            cand.RecommendedJobID = -1;
            cand.RecommendedJobRoleID = -1;
            cand.MissingDataProfile = "All";
            cand.GroupID = -1;
            cand.LanguageID = -1;
            cand.Gender = "All";
            cand.CompanyID = -1;
            cand.QualificationID = -1;
            cand.RegistrationFrom = regcanDates[0].stDate;
            cand.RegistrationTo = regcanDates[5].edDate;
            cand.DateOfBirth = "1900/01/01";
            cand.SalaryFrom = 0;
            cand.SalaryTo = 1000000;
            cand.EmployentProjectStartDateFrom = "1900/01/01";
            cand.EmployentProjectStartDateTo = "5000/01/01";
            cand.EmployentProjectEndDateFrom = "1900/01/01";
            cand.EmployentProjectEndDateTo = "5000/01/01";
            //int i = 0;
            //int iCount = 0;
            DateTime Today = DateTime.Today;
            // Calculate 6 Months before perid.
            DateTime stDate = Today; // AddYears(-3);
            DateTime tDate = DateTime.Today;
            string sqlStr = "";
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("", conn);
            //  DataTable dt = cand.GetAllActiveRegisteredCandidate(cand);
            DataTable dt = new DataTable();
            int count = 0;
            for (i = 5; i >= 0; i--)
            {
                cand.RegistrationFrom = regcanDates[i].stDate;
                cand.RegistrationTo = regcanDates[i].edDate;
                dt = cand.GetAllActiveRegisteredCandidate(cand);
                regCands[i].noc = dt.Rows.Count;
                count += regCands[i].noc;
                dt.Clear();
                dt.Dispose();
            }
            try
            {
                this.chartRegCand.Series["regCandSeries"].SmartLabelStyle.Enabled = false;
                this.chartRegCand.ChartAreas[0].AxisX.Title = "Months";
                this.chartRegCand.ChartAreas[0].AxisY.Title = " Candidate Numbers";
                this.chartRegCand.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Blue;
                this.chartRegCand.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Blue;
                this.chartRegCand.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.chartRegCand.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.chartRegCand.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                this.chartRegCand.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
                this.chartRegCand.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Blue;
                this.chartRegCand.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.chartRegCand.ChartAreas[0].AxisX.Interval = 1;
                this.chartRegCand.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                double dnoCandidates = 0;
                for (i = 0; i < 6; i++)
                {
                    dnoCandidates = Convert.ToDouble(regCands[i].noc);
                    this.chartRegCand.Series[0].Points.AddXY(xLabels[i], dnoCandidates);
                    this.chartRegCand.Series[0].Points[i].Label = dnoCandidates.ToString();
                    iCount += regCands[i].noc;
                }
                this.lbRegCandidates.Text = iCount.ToString();
            }
            catch (System.Exception ex)
            {
                // his.lbStatus.Text = ex.Message;
            }

        }
        private void getTrnCandidates()
        {
            string trnQuery = "SELECT count(*) FROM candidates_assigned_to_training_projects  a join training_projects  b on  a.training_project_id=b.training_project_id where a.passed_training > 0  ";
            string s2 = "";
            int i = 0;
            int iCount = 0;
            DateTime Today = DateTime.Today;
            // Calculate 6 Months before perid.
            DateTime stDate = Today; // AddYears(-3);
            DateTime tDate = DateTime.Today;
            string sqlStr = "";
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("", conn);
            //for (i = 5; i >= 0; i--)
            //{
                
            //    trnCands[i].edDate = stDate.Year.ToString() + "-" + stDate.Month.ToString("00") + "-" + stDate.Day.ToString("00");
            //    stDate = stDate.AddMonths(-1);
            //    tDate = stDate.AddDays(1);
            //    trnCands[i].stDate = tDate.Year.ToString() + "-" + tDate.Month.ToString("00") + "-" + tDate.Day.ToString("00");
            //}
            for (i = 5; i >= 0; i--)
            {
                MySqlDataReader reader;
                s2 = " and end_date_time between '" + trnCands[i].stDate + "' and '" + trnCands[i].edDate + "' ";
                sqlStr = trnQuery + s2;
                cmd.CommandText = sqlStr;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    trnCands[i].noc = reader.GetInt32(0);

                }
                reader.Close();
            }
            try
            {
                this.chartTrained.Series["trnSeries"].SmartLabelStyle.Enabled = false;
                this.chartTrained.ChartAreas[0].AxisX.Title = "Months";
                this.chartTrained.ChartAreas[0].AxisY.Title = " Candidate Numbers";
                this.chartTrained.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Blue;
                this.chartTrained.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Blue;
                this.chartTrained.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.chartTrained.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.chartTrained.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                this.chartTrained.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
                this.chartTrained.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Blue;
                this.chartTrained.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.chartTrained.ChartAreas[0].AxisX.Interval = 1;
                this.chartTrained.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                double dnoCandidates = 0;
                for (i = 0; i < 6; i++)
                {
                    dnoCandidates = Convert.ToDouble(trnCands[i].noc);
                    this.chartTrained.Series[0].Points.AddXY(xLabels[i], dnoCandidates);
                    this.chartTrained.Series[0].Points[i].Label = dnoCandidates.ToString();
                    iCount += trnCands[i].noc;
                }
                this.lbTrained.Text = iCount.ToString();
            }
            catch (System.Exception ex)
            {
                // his.lbStatus.Text = ex.Message;
            }

        }
        private void getUnderTraining()
        {
            string udtQuery = "SELECT count(*) FROM candidates_assigned_to_training_projects  a join training_projects  b on  a.training_project_id=b.training_project_id where   a.passed_training < 1 ";
            string s2 = "";
            int i = 0;
            int iCount = 0;
            DateTime Today = DateTime.Today;
            // Calculate 6 Months before perid.
            DateTime stDate = Today; // AddYears(-3);
            DateTime tDate = DateTime.Today;
            string sqlStr = "";
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("", conn);
            //for (i = 5; i >= 0; i--)
            //{
            //    udtCands[i].edDate = stDate.Year.ToString() + "-" + stDate.Month.ToString("00") + "-" + stDate.Day.ToString("00");
            //    stDate = stDate.AddMonths(-1);
            //    tDate = stDate.AddDays(1);
            //    udtCands[i].stDate = tDate.Year.ToString() + "-" + tDate.Month.ToString("00") + "-" + tDate.Day.ToString("00");
            //}
            for (i = 5; i >= 0; i--)
            {
                MySqlDataReader reader;
                s2 = " and end_date_time between '" + udtCands[i].stDate + "' and '" + udtCands[i].edDate + "' ";
                sqlStr = udtQuery + s2;
                cmd.CommandText = sqlStr;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    udtCands[i].noc = reader.GetInt32(0);

                }
                reader.Close();
            }
            try
            {
                this.ChartUnderTraining.Series["udtSeries"].SmartLabelStyle.Enabled = false;
                this.ChartUnderTraining.ChartAreas[0].AxisX.Title = "Months";
                this.ChartUnderTraining.ChartAreas[0].AxisY.Title = " Candidate Numbers";
                this.ChartUnderTraining.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Blue;
                this.ChartUnderTraining.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Blue;
                this.ChartUnderTraining.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.ChartUnderTraining.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.ChartUnderTraining.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                this.ChartUnderTraining.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
                this.ChartUnderTraining.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Blue;
                this.ChartUnderTraining.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
                this.ChartUnderTraining.ChartAreas[0].AxisX.Interval = 1;
                this.ChartUnderTraining.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                double dnoCandidates = 0;
                for (i = 0; i < 6; i++)
                {
                    dnoCandidates = Convert.ToDouble(udtCands[i].noc);
                    this.ChartUnderTraining.Series[0].Points.AddXY(xLabels[i], dnoCandidates);
                    this.ChartUnderTraining.Series[0].Points[i].Label = dnoCandidates.ToString();
                    iCount += udtCands[i].noc;
                }
                this.lbUnderTraining.Text = iCount.ToString();
            }
            catch (System.Exception ex)
            {
                // his.lbStatus.Text = ex.Message;
            }

        }

        protected void lbGotJobsClicked(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportSection/GotJobN.aspx", false);
        }

        protected void lbPlacementsClicked(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportSection/PlacementsN.aspx", false);
        }

        protected void lbActiveCandidatesClicked(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportSection/AllActiveRegisteredCandidateReport.aspx", false);
        }

        protected void trainingProjectsClicked(object sender, EventArgs e)
        {
            Response.Redirect("~//ReportSection/TrainingProjectReports.aspx", false);
        }

        protected void employmentProjectsClicked(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportSection/EmploymentProjectsWithEmploymentStatus.aspx", false);
        }

        protected void trainingProjectsEDClicked(object sender, EventArgs e)
        {
            Response.Redirect("~//ReportSection/TrainingProjectReports.aspx", false);
        }

        protected void btnClose_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }

        private void refreshCharts()
        {
            this.gotJobsChart.Series["gotJobSeries"].Points.ResumeUpdates();
            this.gotJobsChart.Series["gotJobSeries"].Points.Clear();
            this.placements.Series["placementsSeries"].Points.Clear();
            this.activeCandidates.Series["acSeries"].Points.Clear();
            this.traingProgramsStDate.Series["tpSeriesStDate"].Points.Clear();
            this.traingProgramsEdDate.Series["edSeries"].Points.Clear();
            this.employmentProjects.Series["epSeries"].Points.Clear();
            fillCharts();
            getAllActiveRegisteredCandidates();
            getTrainingProjectsStDateWise();
            getTrainingProjectsEDDateWise();
            getEmploymentProjects();
            getRegCandidates();
            getTrnCandidates();
            getUnderTraining();
        }

        protected void prtButton_Click(object sender, ImageClickEventArgs e)
        {
            refreshCharts();
            bPo = Convert.ToBoolean(ViewState["bPo"]);
            Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate());
            // doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            string fName = "Chart" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString() +
                                     DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + ".pdf";
            var pdfFile = Server.MapPath("~/TempImageFiles/"+ fName);
            PdfWriter pDoc = PdfWriter.GetInstance(doc, new FileStream(pdfFile, FileMode.Create));
            pDoc.PageEvent = new MyPdfPageEventHelpPageNo();
            doc.Open();

            PdfPTable header = new PdfPTable(2);
            float[] hw = new float[] { 412, 413 };
            header.SetWidths(hw);

            PdfPCell hlc = new PdfPCell();
            PdfPCell rlc = new PdfPCell();
            Phrase lp = new Phrase("Status");
            Phrase rp = new Phrase("From: " + this.lbStatusDate.Text);
            lp.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            rp.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            hlc.Phrase = lp;
            rlc.Phrase = rp;
            rlc.HorizontalAlignment = Element.ALIGN_RIGHT;
            hlc.HorizontalAlignment = Element.ALIGN_LEFT;
            hlc.BorderWidth = 0;
            rlc.BorderWidth = 0;
            hlc.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
            rlc.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
            rlc.BorderColorBottom = new BaseColor(0, 0, 255);
            rlc.BorderColorTop = new BaseColor(0, 0, 255);
            hlc.BorderColorTop = new BaseColor(0, 0, 255);
            hlc.BorderColorBottom = new BaseColor(0, 0, 255);
            hlc.BorderWidthBottom = 0.4f;
            hlc.BorderWidthTop = 0.4f;
            rlc.BorderWidthTop = 0.4f;
            rlc.BorderWidthBottom = 0.4f;
            header.AddCell(hlc);
            header.AddCell(rlc);
            doc.Add(header);
            doc.Add(new Phrase(Environment.NewLine));

            float[] mwidths = new float[] { 275, 275, 275 };
            PdfPTable pdft = new PdfPTable(3);
            pdft.SetWidths(mwidths);
            
            PdfPCell leftCell = new PdfPCell();
            PdfPCell rightCell = new PdfPCell();
            PdfPCell centerCell = new PdfPCell();
            leftCell.HorizontalAlignment = Element.ALIGN_CENTER;
            rightCell.HorizontalAlignment = Element.ALIGN_CENTER;
            centerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            leftCell.BorderWidth = 0;
            rightCell.BorderWidth = 0;
            centerCell.BorderWidth = 0;
            // ------------------------------------
            // Gotjob chart.....
            // ------------------------------------
            var chartimage = new MemoryStream();
            this.gotJobsChart.SaveImage(chartimage, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
            // var image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(Chart(this.gotJobsChart));
            image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            leftCell.AddElement(image);
            // ---------------
            // Placements.....
            // ---------------
            chartimage = new MemoryStream();
            this.placements.SaveImage(chartimage, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
            image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            centerCell.AddElement(image);
            // ---------------------
            // Active Candidates....
            // ---------------------
            chartimage = new MemoryStream();
            this.activeCandidates.SaveImage(chartimage, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
            image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            rightCell.AddElement(image);

            pdft.AddCell(leftCell);
            pdft.AddCell(centerCell);
            pdft.AddCell(rightCell);
            //doc.Add(pdft);
            Phrase p1 = new Phrase(this.lbJobsObtained.Text + " - " + this.lbJobObtainedTot.Text);
            Phrase p2 = new Phrase(this.lbPlacements.Text + " - " + this.lbPlacementsTot.Text);
            Phrase p3 = new Phrase(this.lbActiveCandidates.Text + " - " + this.lbActiveCandidatesTot.Text);
            p1.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);
            p2.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);
            p3.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);
            leftCell.Phrase = p1;
            centerCell.Phrase = p2;
            rightCell.Phrase = p3;
            
            pdft.AddCell(leftCell);
            pdft.AddCell(centerCell);
            pdft.AddCell(rightCell);

            // Give space.....
            p1 = new Phrase(" ");
            p2 = new Phrase(" ");
            p3 = new Phrase(" ");
            leftCell.Phrase = p1;
            centerCell.Phrase = p2;
            rightCell.Phrase = p3;

            pdft.AddCell(leftCell);
            pdft.AddCell(centerCell);
            pdft.AddCell(rightCell);

            // ---------------
            // Second row....
            // --------------

            // ------------------------------------
            // Training Programs Start Date
            // ------------------------------------
            chartimage = new MemoryStream();
            this.traingProgramsStDate.SaveImage(chartimage);
            image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            leftCell.AddElement(image);
            // ---------------------------
            // Training programs End Date
            // ---------------------------
            chartimage = new MemoryStream();
            this.traingProgramsEdDate.SaveImage(chartimage);
            image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            centerCell.AddElement(image);
            // ---------------------
            // Active Candidates....
            // ---------------------
            chartimage = new MemoryStream();
            this.employmentProjects.SaveImage(chartimage);
            image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            rightCell.AddElement(image);

            pdft.AddCell(leftCell);
            pdft.AddCell(centerCell);
            pdft.AddCell(rightCell);
            //doc.Add(pdft);

            // doc.Add(new Phrase(Environment.NewLine));
            p1 = new Phrase(this.lbTrainingProjStDate.Text + " - " + this.lbTrainProjStDateTot.Text);
            p2 = new Phrase(this.lbTrainingProjEdDate.Text + " - " + this.lbTrinProjEdDateTot.Text);
            p3 = new Phrase(this.lbEmpProj.Text + " - " + this.lbEmpProjTot.Text);
            leftCell.Phrase = p1;
            centerCell.Phrase = p2;
            rightCell.Phrase = p3;
            pdft.AddCell(leftCell);
            pdft.AddCell(centerCell);
            pdft.AddCell(rightCell);

            doc.Add(pdft);

            //  -- print in new page.....
            doc.NewPage();
            // --------------
            // Third row.....
            // --------------

            // ------------------------------------
            // Training Programs Start Date
            // ------------------------------------
            chartimage = new MemoryStream();
            this.chartRegCand.SaveImage(chartimage);
            image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            leftCell.AddElement(image);
            // ---------------------------
            // Training programs End Date
            // ---------------------------
            chartimage = new MemoryStream();
            this.chartTrained.SaveImage(chartimage);
            image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            centerCell.AddElement(image);
            // ---------------------
            // Active Candidates....
            // ---------------------
            chartimage = new MemoryStream();
            this.ChartUnderTraining.SaveImage(chartimage);
            image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            rightCell.AddElement(image);

            pdft.AddCell(leftCell);
            pdft.AddCell(centerCell);
            pdft.AddCell(rightCell);
            //doc.Add(pdft);

            // doc.Add(new Phrase(Environment.NewLine));
            p1 = new Phrase(this.lbRegCandidatesT.Text + " - " + this.lbRegCandidates.Text);
            p2 = new Phrase(this.lbTrainedT.Text + " - " + this.lbTrained.Text);
            p3 = new Phrase(this.lbUnderTrainingT.Text + " - " + this.lbUnderTraining.Text);
            leftCell.Phrase = p1;
            centerCell.Phrase = p2;
            rightCell.Phrase = p3;
            pdft.AddCell(leftCell);
            pdft.AddCell(centerCell);
            pdft.AddCell(rightCell);

            doc.Add(pdft);
            doc.Close();

            string sigPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
            string physicalPath = Server.MapPath("~/TempImageFiles");
            string vdocPdf = physicalPath.Substring(sigPath.Length).Replace('\\', '/').Insert(0, "~/");
            vdocPdf += "/" + fName;
            Response.AddHeader("Content-Disposition", "attachment;filename=Chart1.pdf");
            Response.ContentType = "application/pdf";
            Response.TransmitFile(Server.MapPath(vdocPdf));
            Response.End();

        }
        private Byte[] Chart(System.Web.UI.DataVisualization.Charting.Chart chart)
        {
            using (var chartimage = new MemoryStream())
            {
                chart.SaveImage(chartimage, ChartImageFormat.Png);
                return chartimage.GetBuffer();
            }
        }
        protected void dtEndDate_SelectionChanged(object sender, EventArgs e)
        {
            bPo = true;
            //setDates();
        }
        protected void prtbtnJobObtained_Click(object sender, EventArgs e)
        {
            refreshCharts();
            var chartimage = new MemoryStream();
            chartimage = new MemoryStream();
            this.gotJobsChart.SaveImage(chartimage);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            prtSingleSheet(image, this.lbJobsObtained.Text + " - " + lbJobObtainedTot.Text);
            return;
         //   Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate());
         //   // doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
         //   string fName = "Chart" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString() +
         //                            DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + ".pdf";
         //   var pdfFile = Server.MapPath("~/TempImageFiles/" + fName);
         //   PdfWriter pDoc = PdfWriter.GetInstance(doc, new FileStream(pdfFile, FileMode.Create));
         //   pDoc.PageEvent = new MyPdfPageEventHelpPageNo();
         //   doc.Open();

         //   PdfPTable header = new PdfPTable(2);
         //   float[] hw = new float[] { 412, 413 };
         //   header.SetWidths(hw);

         //   PdfPCell hlc = new PdfPCell();
         //   PdfPCell rlc = new PdfPCell();
         //   Phrase lp = new Phrase("Status");
         //   Phrase rp = new Phrase("From: " + this.lbStatusDate.Text);
         //   lp.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
         //   rp.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
         //   hlc.Phrase = lp;
         //   rlc.Phrase = rp;
         //   rlc.HorizontalAlignment = Element.ALIGN_RIGHT;
         //   hlc.HorizontalAlignment = Element.ALIGN_LEFT;
         //   hlc.BorderWidth = 0;
         //   rlc.BorderWidth = 0;
         //   hlc.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
         //   rlc.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
         //   rlc.BorderColorBottom = new BaseColor(0, 0, 255);
         //   rlc.BorderColorTop = new BaseColor(0, 0, 255);
         //   hlc.BorderColorTop = new BaseColor(0, 0, 255);
         //   hlc.BorderColorBottom = new BaseColor(0, 0, 255);
         //   hlc.BorderWidthBottom = 0.4f;
         //   hlc.BorderWidthTop = 0.4f;
         //   rlc.BorderWidthTop = 0.4f;
         //   rlc.BorderWidthBottom = 0.4f;
         //   header.AddCell(hlc);
         //   header.AddCell(rlc);
         //   doc.Add(header);
         //   doc.Add(new Phrase(Environment.NewLine));

         //   float[] mwidths = new float[] { 825 };
         //   PdfPTable pdft = new PdfPTable(1);
         //   pdft.SetWidths(mwidths);
         //   var chartimage = new MemoryStream();

         //   chartimage = new MemoryStream();
         //   this.gotJobsChart.SaveImage(chartimage);
         //   iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
         //   image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
         ////   image.ScalePercent(120, 100);
         //   image.ScaleToFit(800f, 400f);
         //   // image.ScaleAbsolute(700f, 360f);
         //   image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
         //   PdfPCell pdfCell = new PdfPCell();
         //   pdfCell.BorderWidth = 0;
         //   pdfCell.AddElement(image);
         //   pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
         //   pdft.AddCell(pdfCell);
         //   string text = this.lbJobsObtained.Text + " - " + this.lbJobObtainedTot.Text;
         //   Phrase p1 = new Phrase();
         //   iTextSharp.text.Font georgia = FontFactory.GetFont("georgia", 14f);
         //   georgia.Color = iTextSharp.text.BaseColor.BLACK;

         //   Chunk info = new Chunk(text, georgia);
         //   p1.Add(info);
         //   pdfCell.Phrase = p1;
         //   pdft.AddCell(pdfCell);
         //   doc.Add(pdft);
         //   doc.Close();
         //   string sigPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
         //   string physicalPath = Server.MapPath("~/TempImageFiles");
         //   string vdocPdf = physicalPath.Substring(sigPath.Length).Replace('\\', '/').Insert(0, "~/");
         //   vdocPdf += "/" + fName;
         //   Response.AddHeader("Content-Disposition", "attachment;filename=Chart1.pdf");
         //   Response.ContentType = "application/pdf";
         //   Response.TransmitFile(Server.MapPath(vdocPdf));
         //   Response.End();


        }

        private void prtSingleSheet(iTextSharp.text.Image image,  string title)
        {
            refreshCharts();
            Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate());
            // doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            string fName = "Chart" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString() +
                                     DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + ".pdf";
            var pdfFile = Server.MapPath("~/TempImageFiles/" + fName);
            PdfWriter pDoc = PdfWriter.GetInstance(doc, new FileStream(pdfFile, FileMode.Create));
            pDoc.PageEvent = new MyPdfPageEventHelpPageNo();
            doc.Open();

            PdfPTable header = new PdfPTable(2);
            float[] hw = new float[] { 412, 413 };
            header.SetWidths(hw);

            PdfPCell hlc = new PdfPCell();
            PdfPCell rlc = new PdfPCell();
            Phrase lp = new Phrase("Status");
            Phrase rp = new Phrase("From: " + this.lbStatusDate.Text);
            lp.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            rp.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            hlc.Phrase = lp;
            rlc.Phrase = rp;
            rlc.HorizontalAlignment = Element.ALIGN_RIGHT;
            hlc.HorizontalAlignment = Element.ALIGN_LEFT;
            hlc.BorderWidth = 0;
            rlc.BorderWidth = 0;
            hlc.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
            rlc.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
            rlc.BorderColorBottom = new BaseColor(0, 0, 255);
            rlc.BorderColorTop = new BaseColor(0, 0, 255);
            hlc.BorderColorTop = new BaseColor(0, 0, 255);
            hlc.BorderColorBottom = new BaseColor(0, 0, 255);
            hlc.BorderWidthBottom = 0.4f;
            hlc.BorderWidthTop = 0.4f;
            rlc.BorderWidthTop = 0.4f;
            rlc.BorderWidthBottom = 0.4f;
            header.AddCell(hlc);
            header.AddCell(rlc);
            doc.Add(header);
            doc.Add(new Phrase(Environment.NewLine));

            float[] mwidths = new float[] { 825 };
            PdfPTable pdft = new PdfPTable(1);
            pdft.SetWidths(mwidths);
            var chartimage = new MemoryStream();

            chartimage = new MemoryStream();
            this.gotJobsChart.SaveImage(chartimage);
            //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            // image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            //   image.ScalePercent(120, 100);
            image.ScaleToFit(1000f, 400f);
            // image.ScaleAbsolute(700f, 360f);
            image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            PdfPCell pdfCell = new PdfPCell();
            pdfCell.BorderWidth = 0;
            pdfCell.AddElement(image);
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdft.AddCell(pdfCell);
            string text = title;
            Phrase p1 = new Phrase();
            iTextSharp.text.Font georgia = FontFactory.GetFont("georgia", 14f);
            georgia.Color = iTextSharp.text.BaseColor.BLACK;

            Chunk info = new Chunk(text, georgia);
            p1.Add(info);
            pdfCell.Phrase = p1;
            pdft.AddCell(pdfCell);
            doc.Add(pdft);
            doc.Close();
            string sigPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
            string physicalPath = Server.MapPath("~/TempImageFiles");
            string oPdfFile = physicalPath + "\\" + pdfFile;
            string vdocPdf = physicalPath.Replace("\\", "/");
            vdocPdf += "/" + fName;
            HttpContext.Current.Response.AppendHeader("Content-disposition", "attachment; filename=\"" + Path.GetFileName(pdfFile) + "\";");
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.TransmitFile(vdocPdf);
            HttpContext.Current.Response.End();
            File.Delete(oPdfFile);

        }
        protected void btnGetClick(object sender, ImageClickEventArgs e)
        {
            bPo = true;
            ViewState["bPo"] = bPo;
            // Clear all the charts.....
            // -------------------------
            //this.gotJobsChart.Series["gotJobSeries"].Points.Clear();
            //this.placements.Series["placementsSeries"].Points.Clear();
            //this.activeCandidates.Series["acSeries"].Points.Clear();
            //this.traingProgramsStDate.Series["tpSeriesStDate"].Points.Clear();
            //this.traingProgramsEdDate.Series["edSeries"].Points.Clear();
            //this.employmentProjects.Series["epSeries"].Points.Clear();
            ////if (this.gotJobsChart.Series.Count > 0) this.gotJobsChart.Series.RemoveAt(0);
            ////if (this.placements.Series.Count > 0) this.placements.Series.RemoveAt(0);
            ////if (this.activeCandidates.Series.Count > 0) this.activeCandidates.Series.RemoveAt(0);
            ////if (this.traingProgramsStDate.Series.Count > 0) this.traingProgramsStDate.Series.RemoveAt(0);
            ////if (this.traingProgramsEdDate.Series.Count > 0) this.traingProgramsEdDate.Series.RemoveAt(0);
            ////if (this.employmentProjects.Series.Count > 0) this.employmentProjects.Series.RemoveAt(0);
            fillCharts();
            getAllActiveRegisteredCandidates();
            getTrainingProjectsStDateWise();
            getTrainingProjectsEDDateWise();
            getEmploymentProjects();
            getRegCandidates();
            getTrnCandidates();
            getUnderTraining();

        }
        public class MyPdfPageEventHelpPageNo : iTextSharp.text.pdf.PdfPageEventHelper
        {
            //Create object of PdfContentByte
            PdfContentByte pdfContent;
            protected PdfTemplate total;
            protected BaseFont helv;
            private bool settingFont = false;
            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                total = writer.DirectContent.CreateTemplate(100, 100);
                total.BoundingBox = new iTextSharp.text.Rectangle(-20, -20, 100, 100);
                helv = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.NOT_EMBEDDED);
            }

            public override void OnStartPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
            {
                base.OnStartPage(writer, document);
                int i = 0;
                PdfPTable ptab = new PdfPTable(2);
                ptab.TotalWidth = 720; // 6.5F;
                float[] f = new float[] { 360, 360 };
                ptab.SetWidths(f);
                PdfPCell leftCell = new PdfPCell();
                PdfPCell rightCell = new PdfPCell();

                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                Phrase ph1 = new Phrase();
                Phrase ph2 = new Phrase();
                ph1.Add(new Chunk("Enable India", boldFont));
                leftCell.Phrase = ph1;
                ph2.Add(new Chunk("Date: " + DateTime.Today.ToString("dd/MM/yyyy")));
                leftCell.Phrase = ph1;
                rightCell.Phrase = ph2;
                leftCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                rightCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                rightCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                leftCell.BorderColorBottom = new BaseColor(0, 0, 255);
                rightCell.BorderColorBottom = new BaseColor(0, 0, 255);
                leftCell.BorderWidthBottom = 0.3f;
                rightCell.BorderWidthBottom = 0.3f;
                ptab.AddCell(leftCell);
                ptab.AddCell(rightCell);
                ptab.WriteSelectedRows(0, -1, 72, (document.PageSize.Height - 10), writer.DirectContent);
                // document.Add(new Phrase(Environment.NewLine));


            }
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnStartPage(writer, document);
                PdfPTable tabFot = new PdfPTable(2);
                //  tabFot.TotalWidth = document.PageSize.Width - (document.LeftMargin + document.RightMargin);
                tabFot.TotalWidth = 720;
                float[] f = new float[] { 360, 360 };
                tabFot.SetWidths(f);
                tabFot.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell cell1 = new PdfPCell();
                PdfPCell cell2 = new PdfPCell();
                cell1.Phrase = new Phrase("Status Report");
                cell1.PaddingLeft = 2;
                cell2.Phrase = new Phrase("Page: " + document.PageNumber.ToString());
                cell2.HorizontalAlignment = 2;
                cell1.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                cell2.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                cell2.PaddingRight = 2;
                cell1.BorderColorTop = new BaseColor(0, 0, 255);
                cell2.BorderColorTop = new BaseColor(0, 0, 255);
                cell1.BorderWidthTop = 0.3f;
                cell2.BorderWidthTop = 0.3f;
                tabFot.AddCell(cell1);
                tabFot.AddCell(cell2);

                //                document.Add(tabFot);
                float leftMargin = document.PageSize.Width - 720;
                tabFot.WriteSelectedRows(0, -1, 72, (document.Bottom - 5), writer.DirectContent);

            }

        }
        protected void prtbtnTpEdDate_Click(object sender, ImageClickEventArgs e)
        {
            refreshCharts();
            var chartimage = new MemoryStream();
            chartimage = new MemoryStream();
            //this.gotJobsChart.SaveImage(chartimage);
            this.traingProgramsEdDate.SaveImage(chartimage);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            prtSingleSheet(image, this.lbTrainingProjEdDate.Text + " - " + this.lbTrinProjEdDateTot.Text);

        }
        protected void prtbtnEmpProj_Click(object sender, ImageClickEventArgs e)
        {
            refreshCharts();
            var chartimage = new MemoryStream();
            chartimage = new MemoryStream();
            this.employmentProjects.SaveImage(chartimage);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            prtSingleSheet(image, this.lbEmpProj.Text + " - " + this.lbEmpProjTot.Text);

        }
        protected void prtbtnUnderTraining_Click(object sender, ImageClickEventArgs e)
        {
            refreshCharts();
            var chartimage = new MemoryStream();
            chartimage = new MemoryStream();
            this.ChartUnderTraining.SaveImage(chartimage);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            prtSingleSheet(image, this.lbUnderTrainingT.Text + " - " + this.lbUnderTraining.Text);

        }
        protected void prtbtnRegCandidates_Click(object sender, ImageClickEventArgs e)
        {
            refreshCharts();
            var chartimage = new MemoryStream();
            chartimage = new MemoryStream();
            this.chartRegCand.SaveImage(chartimage);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            prtSingleSheet(image, this.lbRegCandidatesT.Text  + " - " + this.lbRegCandidates.Text);

        }
        protected void prtbtnActiveCandidates_Click(object sender, ImageClickEventArgs e)
        {
            refreshCharts();
            var chartimage = new MemoryStream();
            chartimage = new MemoryStream();
            this.gotJobsChart.SaveImage(chartimage);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            prtSingleSheet(image, this.lbActiveCandidates.Text + " - " + this.lbActiveCandidatesTot.Text);
        }
        protected void prtbtnPlacements_Click(object sender, ImageClickEventArgs e)
        {
            refreshCharts();
            var chartimage = new MemoryStream();
            chartimage = new MemoryStream();
            this.placements.SaveImage(chartimage);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            prtSingleSheet(image, this.lbPlacements.Text + " - " + this.lbPlacementsTot.Text);

        }
        protected void prtbtnTrained_Click(object sender, ImageClickEventArgs e)
        {
            refreshCharts();
            var chartimage = new MemoryStream();
            chartimage = new MemoryStream();
            this.chartTrained.SaveImage(chartimage);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            prtSingleSheet(image, this.lbTrainedT.Text + " - " + this.lbTrained.Text);
        }
        protected void prtbtnTpStdate_Click(object sender, ImageClickEventArgs e)
        {
            refreshCharts();
            var chartimage = new MemoryStream();
            chartimage = new MemoryStream();
            this.traingProgramsStDate.SaveImage(chartimage);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            prtSingleSheet(image, this.lbTrainingProjStDate.Text + " - " + this.lbTrainProjStDateTot.Text);
        }
    }
}
