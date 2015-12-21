using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.DAL;
using EnableIndia.App_Code.BAL;

namespace EnableIndia.Training
{
    public partial class CandidateNotes : System.Web.UI.Page
    {
        public int trainingProjectID
        {
            get;
            set;
        }
        public int candidateID
        {
            get;
            set;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
         //   Global.SetDefaultButtonOfTheForm(this.Form, BtnSubmit);
         //   Global.ShowMessageInAlert(this.Form);
            if (Request.QueryString["train_proj"] != null)
            {
                this.trainingProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["train_proj"]));
            }
            else
            {
                this.trainingProjectID = -1;
            }
            if (Request.QueryString["cand"] != null)
            {
                this.candidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"]));
            }
            else
            {
                this.candidateID = -1;
            }

            EnableIndia.App_Code.BAL.TrainingProjectBAL project = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            MySqlDataReader drProject = project.GetTrainingProgramInstance(this.trainingProjectID.ToString());
            if (drProject.Read())
            {
                SpnTrainingProgramName.InnerText = drProject["training_program_name"].ToString();
                SpnTrainingProjectName.InnerText = drProject["training_project_name"].ToString();
                //SpnTrainnigProjectDetail.InnerText = Convert.ToDateTime(drProject["start_date_time"]).ToString("dd/MM/yyyy") + "";
                //SpnTrainnigProjectDetail.InnerText += " to " + Convert.ToDateTime(drProject["end_date_time"]).ToString("dd/MM/yyyy") + "";
                //SpnTrainnigProjectDetail.InnerText += " from " + drProject["start_time"].ToString() + " to " + drProject["end_time"].ToString();
            }
            drProject.Close();
            drProject.Dispose();

            CandidatesBAL cand = new CandidatesBAL();
            MySqlDataReader drCandidate = cand.GetCandidateDetails(this.candidateID.ToString());
            if (drCandidate.Read())
            {
                SpnCandidateName.InnerText = drCandidate["first_name"].ToString() + " " + drCandidate["middle_name"].ToString() + "  " + drCandidate["last_name"].ToString();
                SpnCandidateRID.InnerText = drCandidate["registration_id"].ToString();
            }
            drCandidate.Close();
            drCandidate.Dispose();
            GetCandidateNotes();
            if (!Page.IsPostBack)
            {
                string textboxId = string.Empty;
                if (Request.QueryString["txboxId"] != null)
                    textboxId = Request.QueryString["txboxId"].ToString().Replace("'", string.Empty);
                this.txtParent.Value = textboxId;
            }
        }

        protected void GetCandidateNotes()
        {
            EnableIndia.App_Code.BAL.TrainingProjectBAL project = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            LstCandidateNotes.DataSource = project.GetCandidateWithNotes(this.trainingProjectID);
            LstCandidateNotes.DataBind();
        }

        protected void BtnSubmit_click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TxtNotes.Text))
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("Notes empty");
                return;
            }
            string message = String.Empty;

            EnableIndia.App_Code.BAL.TrainingProjectBAL project = new EnableIndia.App_Code.BAL.TrainingProjectBAL();

            //string script = string.Empty;
            //int duplicateRecord = project.CheckDuplicationNote(this.candidateID);
            //if(duplicateRecord > 0)
            //{
            //    script = "alert('Note already added for candidate.');";
            //    ClientScript.RegisterStartupScript(this.GetType(), "__key", script, true);
            //    return;
            //}

            bool rowAdded = project.AddNotes(this.candidateID, this.trainingProjectID, TxtNotes.Text.Trim().ToString());
            if (rowAdded.Equals(true))
            {
                message = "Note added successfully.";
            }
            else
            {
                message = "Error occurred. Please contact the administrator.";
            }
            Global.RedirectAfterSubmit(message, BtnSubmit.ID);

        }
        protected void closeRadWindow(object sender, EventArgs e)
        {
            closePage();
        }
        private void closePage()
        {
            string  url = "self.close();self.parent.location.replace('" + this.txtParent.Value + "')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", url, true);
        }

    }
}