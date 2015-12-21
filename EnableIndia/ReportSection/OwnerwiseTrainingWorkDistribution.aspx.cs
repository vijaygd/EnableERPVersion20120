using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


namespace EnableIndia.ReportSection
{
    public partial class OwnerwiseTrainingWorkDistribution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetDefaultButtonOfTheForm(this.Form, BtnGenerateReport);
            Global.SetUICulture(this.Page);

            // populate hidden dropdown value 
            EnableIndia.App_Code.BAL.TrainingProjectBAL proj = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            MySqlDataReader drHidenProject = proj.GetTrainingProjects();
            while (drHidenProject.Read())
            {
                ListItem li = new ListItem(drHidenProject["training_project_name"].ToString(), drHidenProject["training_project_id"].ToString());
                li.Attributes.Add("TrainingProgramID", drHidenProject["training_program_id"].ToString());
                DdlHiddenProjects.Items.Add(li);
            }
            DdlHiddenProjects.Items.Insert(0, new ListItem("All", "-1"));
            DdlHiddenProjects.Items.Add(new ListItem("Not Available", "-3"));
            drHidenProject.Close();
            drHidenProject.Dispose();


            if (!Page.IsPostBack)
            {
                TrainingProgramBAL programm = new TrainingProgramBAL();
                MySqlDataReader drProgramm = programm.GetTrainingProgramDetails("-1");
                Global.FillDropDown(DdlPrograms, drProgramm, "training_program_name", "training_program_id");

                DdlPrograms.Items[0].Text = "All";
                DdlPrograms.Items[0].Value = "-1";


                //TrainingProjectBAL proj = new TrainingProjectBAL();
                //MySqlDataReader drProject = proj.GetTrainingProjects();
                //Global.FillDropDown(DdlProjects, drProject, "training_project_name", "training_project_id");
                //DdlProjects.Items[0].Text = "All";
                //DdlProjects.Items[0].Value = "-1";
            }
        }

        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();
            TrainingProjectBAL proj = new TrainingProjectBAL();
            proj.ProjectStatus = DdlProjectType.Value;
            proj.TrainingProgramID = Convert.ToInt32(DdlPrograms.Value);
            proj.TrainingProjectID = Convert.ToInt32(TxtHiddenProjects.Text.Trim());

            proj.DateType = DdlDateType.Value;
            try
            {
                proj.DateFrom = Convert.ToDateTime(TxtFromDate.Text.Trim()).ToString("yyyy/MM/dd");

            }
            catch
            {
                proj.DateFrom = "1900/01/01";
            }
            try
            {
                proj.DateTo = Convert.ToDateTime(TxtToDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                proj.DateTo = "5000/01/01";
            }

            report.RegData("DsOwnerwiseTrainingWorkDistribution", proj.GetOwnerwiseTrainingWorkDistribution(proj));

            report.Load(Server.MapPath("~/Reports/OwnerwiseTrainingWorkDistribution.mrt"));
            //report.Dictionary.Variables["var_date_from"].ValueObject = Convert.ToDateTime(cand.DateFrom).ToString(Global.GetDateFormat());
            //report.Dictionary.Variables["var_date_to"].ValueObject = Convert.ToDateTime(cand.DateTo).ToString(Global.GetDateFormat());

            StiWebViewer1.Report = report;
        }
    }
}