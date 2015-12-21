using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Candidate.ProfileHistory
{

    public partial class CandidateKnowledgeTraining : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }

            TxtOtherKnowledge.Focus();
            Global.SetDefaultButtonOfTheForm(this.Form, BtnUpdateKnowledgeAndTraining);
            if (!Page.IsPostBack)
            {
                Global.AuthenticateUser();
                GetCandidateDetail();
                if (Request.QueryString["cand"] != null)
                {
                    LnkBtnRegistration.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnEducationalQualifications.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnWorkExperience.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnJobProfiling.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkButtonCandidateHistory.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();

                    GetComputerKnowledge();
                    GetKnownLanguages();
                    GetCandidateKnowledgeTrainingDetails();
                }
                GetTraining();
                CandidateKnowledgeTrainingBAL training = new CandidateKnowledgeTrainingBAL();
                LstViewTrainingPassed.DataSource = training.GetCandidateTrainingDetails(Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString());
                LstViewTrainingPassed.DataBind();
            }
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }

        }

        protected void GetTraining()
        {
            CandidateKnowledgeTrainingBAL training = new CandidateKnowledgeTrainingBAL();
            MySqlDataReader drTraining = training.GetCandidateKnowledgeTrainingDetails(Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString());
            if (drTraining.Read())
            {
                SpnCurentTraining.InnerText = drTraining["assigned_training_programs"].ToString();
                SpnRecommendedTraining.InnerText = drTraining["recommended_training_programs"].ToString();
            }
            drTraining.Close();
            drTraining.Dispose();
        }

        protected void BtnAddEditRecommendedTraining_Click(object sender, EventArgs e)
        {
            GetTraining();
        }

        private void GetCandidateDetail()
        {
            CandidatesBAL cand = new CandidatesBAL();
            MySqlDataReader drCandidateDetails = cand.GetCandidateDetails(Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString());
            if (drCandidateDetails.Read())
            {
                SpnCandidateFirstName.InnerText = drCandidateDetails["candidate_name"].ToString();
                SpnDisabilityType.InnerText = drCandidateDetails["disability_type"].ToString();
                SpnRID.InnerText = drCandidateDetails["registration_id"].ToString();
                SpnStatus.InnerText = drCandidateDetails["employment_state"].ToString();

                drCandidateDetails.Close();
                drCandidateDetails.Dispose();
            }
        }

        protected void LstViewComputerKnowledge_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl LblComputerKnowledge = (HtmlGenericControl)e.Item.FindControl("LblComputerKnowledge");
                CheckBox ChkSelectKnowledge = (CheckBox)e.Item.FindControl("ChkSelectKnowledge");

                LblComputerKnowledge.Attributes.Add("for", ChkSelectKnowledge.ClientID);
            }
        }

        protected void LstViewKnownLanguages_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl LblLanguage = (HtmlGenericControl)e.Item.FindControl("LblLanguage");
                CheckBox ChkSelectLanguage = (CheckBox)e.Item.FindControl("ChkSelectLanguage");
                LblLanguage.Attributes.Add("for", ChkSelectLanguage.ClientID);
            }
        }

        private void GetComputerKnowledge()
        {
            CandidateComputerKnowledgeBAL candCompKnowl = new CandidateComputerKnowledgeBAL();
            string candidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString();
            LstViewComputerKnowledge.DataSource = candCompKnowl.GetCanddiateComputerKnowledge(candidateID);
            LstViewComputerKnowledge.DataBind();
        }

        private void GetKnownLanguages()
        {
            EnableIndia.App_Code.BAL.CandidateKnownLanguagesBAL get = new EnableIndia.App_Code.BAL.CandidateKnownLanguagesBAL();
            string candidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString();
            LstViewKnownLanguages.DataSource = get.GetCanddiateKnownLanguages(candidateID);
            LstViewKnownLanguages.DataBind();
        }

        private void GetCandidateKnowledgeTrainingDetails()
        {
            CandidateKnowledgeTrainingBAL candKnowlTrain = new CandidateKnowledgeTrainingBAL();
            string candidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString();
            MySqlDataReader drCandidateKnowledgeTraining = candKnowlTrain.GetCandidateKnowledgeTrainingDetails(candidateID);

            if (drCandidateKnowledgeTraining.HasRows)
            {
                drCandidateKnowledgeTraining.Read();
                TxtOtherKnowledge.Text = drCandidateKnowledgeTraining["other_knowledge"].ToString();
                ChkKnowsSignLanguage.Checked = Convert.ToBoolean(drCandidateKnowledgeTraining["knows_sign_language"]);
                ChkKnowsBraile.Checked = Convert.ToBoolean(drCandidateKnowledgeTraining["knows_braille"]);
                ChkNotApplicable.Checked = Convert.ToBoolean(drCandidateKnowledgeTraining["not_applicable"]);
                TxtNeedBasedTrainingAdministered.Text = drCandidateKnowledgeTraining["training_counselling_administered"].ToString();
                ChkEmployableWithoutTraining.Checked = Convert.ToBoolean(drCandidateKnowledgeTraining["is_candidate_employable_without_training"]);
            }
            drCandidateKnowledgeTraining.Close();
            drCandidateKnowledgeTraining.Dispose();
        }

        protected void BtnUpdateKnowledgeAndTraining_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["cand"] != null)
            {
                string message = String.Empty;
                string candidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString();

                MySqlConnection conn = Global.GetConnectionString();
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand("", conn, trans);

                try
                {
                    //Deletes the previous computer knowledge training for tis candidate
                    cmd = new MySqlCommand("", conn, trans);
                    cmd.CommandText = "delete from candidate_computer_knowledge where candidate_id=" + candidateID;
                    cmd.ExecuteNonQuery();

                    //Assigns computer knowledge trainng
                    foreach (ListViewDataItem item in LstViewComputerKnowledge.Items)
                    {
                        CheckBox ChkSelectKnowledge = (CheckBox)item.FindControl("ChkSelectKnowledge");
                        if (ChkSelectKnowledge.Checked)
                        {
                            cmd = new MySqlCommand("", conn, trans);
                            cmd.CommandText = "insert into candidate_computer_knowledge(candidate_id,computer_knowledge_id)";
                            cmd.CommandText += "values(" + candidateID.ToString() + ",";
                            cmd.CommandText += Global.DecryptID(Convert.ToDouble(ChkSelectKnowledge.Attributes["KnowledgeID"])).ToString() + ")";
                            cmd.ExecuteNonQuery();
                        }
                    }

                    //Deletes the previous known languages for tis candidate
                    cmd = new MySqlCommand("", conn, trans);
                    cmd.CommandText = "delete from candidate_known_languages where candidate_id=" + candidateID;
                    cmd.ExecuteNonQuery();

                    //Assigns known languages
                    foreach (ListViewDataItem item in LstViewKnownLanguages.Items)
                    {
                        CheckBox ChkSelectLanguage = (CheckBox)item.FindControl("ChkSelectLanguage");
                        if (ChkSelectLanguage.Checked)
                        {
                            cmd = new MySqlCommand("", conn, trans);
                            cmd.CommandText = "insert into candidate_known_languages(candidate_id,language_id)";
                            cmd.CommandText += "values(" + candidateID.ToString() + ",";
                            cmd.CommandText += Global.DecryptID(Convert.ToDouble(ChkSelectLanguage.Attributes["LanguageID"])).ToString() + ")";
                            cmd.ExecuteNonQuery();
                        }
                    }

                    //Adds/updates candidate knowledge training
                    cmd = new MySqlCommand("manage_candidate_knowledge_training", conn, trans);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("para_candidate_id", Convert.ToInt32(candidateID));
                    cmd.Parameters.AddWithValue("para_other_knowledge", TxtOtherKnowledge.Text.Trim());
                    cmd.Parameters.AddWithValue("para_knows_sign_language", ChkKnowsSignLanguage.Checked);
                    cmd.Parameters.AddWithValue("para_knows_braille", ChkKnowsBraile.Checked);
                    cmd.Parameters.AddWithValue("para_not_applicable", ChkNotApplicable.Checked);
                    cmd.Parameters.AddWithValue("para_training_counselling_administered", TxtNeedBasedTrainingAdministered.Text.Trim());
                    cmd.Parameters.AddWithValue("para_is_candidate_employable_without_training", ChkEmployableWithoutTraining.Checked);
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                    //Repopulates the details to disaply updated values
                    GetComputerKnowledge();
                    GetKnownLanguages();
                    GetCandidateKnowledgeTrainingDetails();
                    message = "Knowledge and training updated successfully.";
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    message = ex.Message;
                }
                finally
                {
                    conn.Close();
                    cmd.Dispose();
                    conn.Dispose();
                    Global.ShowMessagesInDiv(this.Page, message);
                }
            }
        }
        public void disableControls(Control parent)
        {

            var textBoxes = this.Controls.FindAll().OfType<TextBox>();
            foreach (var t in textBoxes)
            {
                t.Enabled = false;
            }
            var dropDowns = this.Controls.FindAll().OfType<DropDownList>();
            foreach (var d in dropDowns)
            {
                d.Enabled = false;
            }
            var selects = this.Controls.FindAll().OfType<HtmlSelect>();
            foreach (var s in selects)
            {
                s.Disabled = true;
            }
            var buttons = this.Controls.FindAll().OfType<Button>();
            foreach (var b in buttons)
            {
                b.Enabled = false;
            }
        }

    }
}