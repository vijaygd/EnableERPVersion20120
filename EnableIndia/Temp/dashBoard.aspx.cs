using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;
using System.Data;

namespace EnableIndia.Candidate
{
    public partial class dashBoard : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            fillCharts();
            getAllActiveRegisteredCandidates();
            getTrainingProjectsStDateWise();
            getTrainingProjectsEDDateWise();
            getEmploymentProjects();
            getRegCandidates();
            getTrnCandidates();
            getUnderTraining();
           
        }
        private void fillCharts()
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            int i = 0;
            int j = 0;
            int iCount = 0;
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
            string s3 = " group by cand_work_expr.candidate_id  order by cand.first_name )) as t";

            DateTime Today = DateTime.Today;
            // Calculate 6 Months before perid.
            DateTime stDate = Today; // AddYears(-3);
            DateTime tDate = DateTime.Today;
            tDate = tDate.AddDays(-1);
            stDate = tDate;

            string sqlStr = "";
            try
            {
                conn = Global.GetConnectionString();
                conn.Open();
                cmd = new MySqlCommand("", conn);
                // ----------------------------------------------
                // Fill the base information.......
                // ---------------------------------------------
                 sqlStr = "select count(*)  from (SELECT a.registration_id,a.registration_date,b.candidate_name_with_status ";
                 sqlStr += "FROM candidates a, candidate_other_details b where a.candidate_id=b.candidate_id and a.is_active=1 ";
                 sqlStr += " and b.unemployed_days>0 and b.candidate_name_with_status!='' limit  50000) as g";
                 try
                 {
                     MySqlDataReader reader;
                     cmd.CommandText = sqlStr;
                     reader = cmd.ExecuteReader();
                     if (reader.HasRows)
                     {
                         reader.Read();
                         this.lbUnmpAc.Text = reader.GetInt32(0).ToString();
                     }
                     reader.Close();
                     sqlStr = "select count(*) from (SELECT * FROM  candidates where is_profiled=0 and registration_date ";
                     sqlStr += "  between date_sub(now(),  interval 6 month) and  now() ) as sixmonths";
                     cmd.CommandText = sqlStr;
                     reader = cmd.ExecuteReader();
                     if (reader.HasRows)
                     {
                         reader.Read();
                         this.lbToBep.Text = reader.GetInt32(0).ToString();
                     }
                     reader.Close();
                     reader.Dispose();
                     reader = null;
                 }
                 catch { ;;}
 

            for (i = 5; i >= 0; i--)
            {
                gotJobDates[i].edDate = stDate.Year.ToString() + "-" + stDate.Month.ToString("00") + "-" + stDate.Day.ToString("00");
                placedDates[i].edDate = stDate.Year.ToString() + "-" + stDate.Month.ToString("00") + "-" + stDate.Day.ToString("00");
                regcanDates[i].edDate = stDate.Year.ToString() + "/" + stDate.Month.ToString("00") + "/" + stDate.Day.ToString("00");
                triprjDates[i].edDate = stDate.Year.ToString() + "/" + stDate.Month.ToString("00") + "/" + stDate.Day.ToString("00");
                empprjDates[i].edDate = stDate.Year.ToString() + "/" + stDate.Month.ToString("00") + "/" + stDate.Day.ToString("00");
                tripEdDates[i].edDate = stDate.Year.ToString() + "/" + stDate.Month.ToString("00") + "/" + stDate.Day.ToString("00");
                stDate = stDate.AddMonths(-1);
                tDate = stDate.AddDays(1);
                gotJobDates[i].stDate = tDate.Year.ToString() + "-" + tDate.Month.ToString("00") + "-" + tDate.Day.ToString("00");
                placedDates[i].stDate = stDate.Year.ToString() + "-" + tDate.Month.ToString("00") + "-" + tDate.Day.ToString("00");
                regcanDates[i].stDate = stDate.Year.ToString() + "/" + tDate.Month.ToString("00") + "/" + tDate.Day.ToString("00");
                triprjDates[i].stDate = stDate.Year.ToString() + "/" + tDate.Month.ToString("00") + "/" + tDate.Day.ToString("00");
                empprjDates[i].stDate = stDate.Year.ToString() + "/" + tDate.Month.ToString("00") + "/" + tDate.Day.ToString("00");
                tripEdDates[i].stDate = stDate.Year.ToString() + "/" + tDate.Month.ToString("00") + "/" + tDate.Day.ToString("00"); 
            }
            this.lbStatusDate.Text = gotJobDates[0].stDate + " to " + gotJobDates[5].edDate;
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
                MsgBox("Error: " + ex.Message);
                return;
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
                MsgBox("Error: " + ex.Message);
                return;
 
            }

            }
             catch (System.Exception ex)
             {
                 MsgBox("Error: " + ex.Message);
                 return;
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
            cand.CompanyID =  -1;
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
            //try
            //{
            //    this.activeCandidates.Series["acSeries"].SmartLabelStyle.Enabled = false;
            //    this.activeCandidates.ChartAreas[0].AxisX.Title = "Months";
            //    this.activeCandidates.ChartAreas[0].AxisY.Title = " Candidate Numbers";
            //    this.activeCandidates.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Blue;
            //    this.activeCandidates.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Blue;
            //    this.activeCandidates.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
            //    this.activeCandidates.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
            //    this.activeCandidates.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            //    this.activeCandidates.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
            //    this.activeCandidates.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Blue;
            //    this.activeCandidates.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
            //    this.activeCandidates.ChartAreas[0].AxisX.Interval = 1;
            //    this.activeCandidates.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            //    double dnoCandidates = 0;
            //    for (i = 0; i < 6; i++)
            //    {
            //        dnoCandidates = Convert.ToDouble(regcanDates[i].noc);
            //        this.activeCandidates.Series[0].Points.AddXY(xLabels[i], dnoCandidates);
            //        this.activeCandidates.Series[0].Points[i].Label = dnoCandidates.ToString();
            //        iCount += regcanDates[i].noc;
            //    }
            //    this.lbActiveCandidatesTot.Text = iCount.ToString();
            //}
            //catch (System.Exception ex)
            //{
            //    // his.lbStatus.Text = ex.Message;
            //}
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
            //try
            //{
            //    this.traingProgramsStDate.Series["tpSeriesStDate"].SmartLabelStyle.Enabled = false;
            //    this.traingProgramsStDate.ChartAreas[0].AxisX.Title = "Months";
            //    this.traingProgramsStDate.ChartAreas[0].AxisY.Title = " Candidate Numbers";
            //    this.traingProgramsStDate.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Blue;
            //    this.traingProgramsStDate.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Blue;
            //    this.traingProgramsStDate.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
            //    this.traingProgramsStDate.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
            //    this.traingProgramsStDate.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            //    this.traingProgramsStDate.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
            //    this.traingProgramsStDate.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Blue;
            //    this.traingProgramsStDate.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
            //    this.traingProgramsStDate.ChartAreas[0].AxisX.Interval = 1;
            //    this.traingProgramsStDate.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            //    double dnoCandidates = 0;
            //    for (i = 0; i < 6; i++)
            //    {
            //        dnoCandidates = Convert.ToDouble(triprjDates[i].noc);
            //        this.traingProgramsStDate.Series[0].Points.AddXY(xLabels[i], dnoCandidates);
            //        this.traingProgramsStDate.Series[0].Points[i].Label = dnoCandidates.ToString();
            //        iCount += triprjDates[i].noc;
            //    }
            //    this.lbTrainProjStDateTot.Text = iCount.ToString();
            //}
            //catch (System.Exception ex)
            //{
            //    // his.lbStatus.Text = ex.Message;
            //}

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
            //try
            //{
            //    this.traingProgramsEdDate.Series["edSeries"].SmartLabelStyle.Enabled = false;
            //    this.traingProgramsEdDate.ChartAreas[0].AxisX.Title = "Months";
            //    this.traingProgramsEdDate.ChartAreas[0].AxisY.Title = " Candidate Numbers";
            //    this.traingProgramsEdDate.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Blue;
            //    this.traingProgramsEdDate.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Blue;
            //    this.traingProgramsEdDate.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
            //    this.traingProgramsEdDate.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
            //    this.traingProgramsEdDate.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            //    this.traingProgramsEdDate.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
            //    this.traingProgramsEdDate.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Blue;
            //    this.traingProgramsEdDate.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
            //    this.traingProgramsEdDate.ChartAreas[0].AxisX.Interval = 1;
            //    this.traingProgramsEdDate.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            //    double dnoCandidates = 0;
            //    for (i = 0; i < 6; i++)
            //    {
            //        dnoCandidates = Convert.ToDouble(tripEdDates[i].noc);
            //        this.traingProgramsEdDate.Series[0].Points.AddXY(xLabels[i], dnoCandidates);
            //        this.traingProgramsEdDate.Series[0].Points[i].Label = dnoCandidates.ToString();
            //        iCount += tripEdDates[i].noc;
            //    }
            //    this.lbTrinProjEdDateTot.Text = iCount.ToString();
            //}
            //catch (System.Exception ex)
            //{
            //    // his.lbStatus.Text = ex.Message;
            //}

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
            //try
            //{
            //    this.employmentProjects.Series["epSeries"].SmartLabelStyle.Enabled = false;
            //    this.employmentProjects.ChartAreas[0].AxisX.Title = "Months";
            //    this.employmentProjects.ChartAreas[0].AxisY.Title = " Candidate Numbers";
            //    this.employmentProjects.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Blue;
            //    this.employmentProjects.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Blue;
            //    this.employmentProjects.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
            //    this.employmentProjects.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
            //    this.employmentProjects.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            //    this.employmentProjects.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
            //    this.employmentProjects.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Blue;
            //    this.employmentProjects.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
            //    this.employmentProjects.ChartAreas[0].AxisX.Interval = 1;
            //    this.employmentProjects.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            //    double dnoCandidates = 0;
            //    for (i = 0; i < 6; i++)
            //    {
            //        dnoCandidates = Convert.ToDouble(empprjDates[i].noc);
            //        this.employmentProjects.Series[0].Points.AddXY(xLabels[i], dnoCandidates);
            //        this.employmentProjects.Series[0].Points[i].Label = dnoCandidates.ToString();
            //        iCount += empprjDates[i].noc;
            //    }
            //    this.lbEmpProjTot.Text = iCount.ToString();
            //}
            //catch (System.Exception ex)
            //{
            //    // his.lbStatus.Text = ex.Message;
            //}

        }
        private void getRegCandidates()
        {
            string regQuery = "SELECT * FROM candidates where ";
            string s2= "";
            string s3 = " and is_registration_completed=1  ";
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
            regQuery = "SELECT Count(*) FROM candidates where   ";
            for (i = 5; i >= 0; i--)
            {
                regCands[i].edDate = stDate.Year.ToString() + "-" + stDate.Month.ToString("00") + "-" + stDate.Day.ToString("00");
                stDate = stDate.AddMonths(-1);
                tDate = stDate.AddDays(1);
                regCands[i].stDate = tDate.Year.ToString() + "-" + tDate.Month.ToString("00") + "-" + tDate.Day.ToString("00");
            }
            for (i = 5; i >= 0; i--)
            {
                MySqlDataReader reader;
                s2 = " registration_date between '" + regCands[i].stDate + "' and '" + regCands[i].edDate + "' ";
                sqlStr =regQuery + s2 + s3;
                cmd.CommandText = sqlStr;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    regCands[i].noc = reader.GetInt32(0);

                }
                reader.Close();
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
            for (i = 5; i >= 0; i--)
            {
                trnCands[i].edDate = stDate.Year.ToString() + "-" + stDate.Month.ToString("00") + "-" + stDate.Day.ToString("00");
                stDate = stDate.AddMonths(-1);
                tDate = stDate.AddDays(1);
                trnCands[i].stDate = tDate.Year.ToString() + "-" + tDate.Month.ToString("00") + "-" + tDate.Day.ToString("00");
            }
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
            string udtQuery = "SELECT COUNT(*) FROM candidates_assigned_to_training_projects  a join training_projects  b on  a.training_project_id=b.training_project_id where   a.passed_training < 1 ";
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
            for (i = 5; i >= 0; i--)
            {
                udtCands[i].edDate = stDate.Year.ToString() + "-" + stDate.Month.ToString("00") + "-" + stDate.Day.ToString("00");
                stDate = stDate.AddMonths(-1);
                tDate = stDate.AddDays(1);
                udtCands[i].stDate = tDate.Year.ToString() + "-" + tDate.Month.ToString("00") + "-" + tDate.Day.ToString("00");
            }
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
        private void MsgBox(string message)
        {
            webMessageBox wb = new webMessageBox();
            wb.Show(message);
        }
    }
}