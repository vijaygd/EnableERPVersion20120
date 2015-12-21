using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Candidate.Registration
{

    public partial class ViewDataOptions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetDisabiltySubTypes();
                GetEducationalQualification();
                GetLanguage();
                GetTraningProgramm();
                GetJobType();
                GetRole();
                GetCandidateGroup();
            }

        }

        protected void BtnPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Candidate/Registration/ViewDataOptionReport.aspx", true);
        }

        protected void GetDisabiltySubTypes()
        {
            EnableIndia.App_Code.BAL.DisabilityTypesBAL subType = new EnableIndia.App_Code.BAL.DisabilityTypesBAL();
            LstDisabilitySubType.DataSource = subType.GetdisabilityTypesWithSubTypes();
            LstDisabilitySubType.DataBind();
        }
        protected void GetEducationalQualification()
        {
            EnableIndia.App_Code.BAL.EducationBAL education = new EnableIndia.App_Code.BAL.EducationBAL();
            LstEducationalQualifications.DataSource = education.GetEducationsDataTable();
            LstEducationalQualifications.DataBind();
        }

        protected void GetLanguage()
        {
            EnableIndia.App_Code.BAL.LanguagesBAL language = new EnableIndia.App_Code.BAL.LanguagesBAL();
            LstLanguagesKnown.DataSource = language.GetLanguages();
            LstLanguagesKnown.DataBind();
        }

        protected void GetTraningProgramm()
        {
            TrainingProgramBAL programm = new TrainingProgramBAL();
            LstRecommendedTrainings.DataSource = programm.GetTraningProgram();
            LstRecommendedTrainings.DataBind();
        }

        protected void GetJobType()
        {
            EnableIndia.App_Code.BAL.JobsBAL job = new EnableIndia.App_Code.BAL.JobsBAL();
            LstRecommendedJobType.DataSource = job.GetJobsDataTable();
            LstRecommendedJobType.DataBind();
        }

        protected void GetRole()
        {
            EnableIndia.App_Code.BAL.JobRolesBAL role = new EnableIndia.App_Code.BAL.JobRolesBAL();
            LstRecommendedRole.DataSource = role.GetJobRole();
            LstRecommendedRole.DataBind();
        }

        protected void GetCandidateGroup()
        {
            EnableIndia.App_Code.BAL.CandidateGroupsBAL group = new EnableIndia.App_Code.BAL.CandidateGroupsBAL();
            LstCandidateGroup.DataSource = group.GetCandidateGroup();
            LstCandidateGroup.DataBind();
        }


    }
}