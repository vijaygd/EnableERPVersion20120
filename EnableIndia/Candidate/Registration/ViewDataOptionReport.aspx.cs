using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Candidate.Registration
{

    public partial class ViewDataOptionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                StiReport report = new StiReport();

                EnableIndia.App_Code.BAL.DisabilityTypesBAL disibilty = new EnableIndia.App_Code.BAL.DisabilityTypesBAL();
                report.RegData("DsDisibiltySubTypes", disibilty.GetdisabilityTypesWithSubTypes());

                EnableIndia.App_Code.BAL.EducationBAL education = new EnableIndia.App_Code.BAL.EducationBAL();
                report.RegData("DsEducation", education.GetEducationsDataTable());

                EnableIndia.App_Code.BAL.LanguagesBAL language = new EnableIndia.App_Code.BAL.LanguagesBAL();
                report.RegData("DsLanguage", language.GetLanguages());

                TrainingProgramBAL training = new TrainingProgramBAL();
                report.RegData("DsRecommendedTraining", training.GetTraningProgram());

                EnableIndia.App_Code.BAL.JobsBAL job = new EnableIndia.App_Code.BAL.JobsBAL();
                report.RegData("DsJobType", job.GetJobsDataTable());

                EnableIndia.App_Code.BAL.JobRolesBAL role = new EnableIndia.App_Code.BAL.JobRolesBAL();
                report.RegData("DsRole", role.GetJobRole());

                EnableIndia.App_Code.BAL.CandidateGroupsBAL cand = new EnableIndia.App_Code.BAL.CandidateGroupsBAL();
                report.RegData("DsCandidateGroup", cand.GetCandidateGroup());

                report.Load(Server.MapPath("~/Reports/ViewDataOptions.mrt"));
                StiWebViewer1.Report = report;
                //report.Show();


            }

        }
    }
}