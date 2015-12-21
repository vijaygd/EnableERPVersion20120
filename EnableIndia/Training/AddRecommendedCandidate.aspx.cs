using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;

namespace EnableIndia.Training
{
    public partial class AddRecommendedCandidate : System.Web.UI.Page
    {
        int trainingProjectID
        {
            get;
            set;
        }
        int trainingProgramID
        {
            get;
            set;
        }
        private string oldValues;

        protected void Page_Load(object sender, EventArgs e)
        {
 
            Global.SetDefaultButtonOfTheForm(this.Form, btnSearchCandidate);
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }

            if (Request.QueryString["train_proj"] != null)
            {
                this.trainingProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["train_proj"]));
            }
            else
            {
                this.trainingProjectID = -1;
            }

            if (Request.QueryString["train_prog"] != null)
            {
                this.trainingProgramID = Global.DecryptID(Convert.ToDouble(Request.QueryString["train_prog"]));
            }
            else
            {
                this.trainingProgramID = -1;
            }

            if (!Page.IsPostBack)
            {
                Global.InitializePagingCookies();
                Global.ShowMessageInAlert(this.Form);
                Global glob = new Global();
                glob.GetAgeGroups(DdlSelectAge);
                DdlSelectAge.Items[0].Text = "all";

                EnableIndia.App_Code.BAL.DefaultsBAL def = new EnableIndia.App_Code.BAL.DefaultsBAL();
                DdlSelectAge.Value = def.GetDefaultAgeGroupForSearch();

                EnableIndia.App_Code.BAL.TrainingProjectBAL project = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
                MySqlDataReader drProject = project.GetTrainingProgramInstance(this.trainingProjectID.ToString());
                if (drProject.Read())
                {
                    SpnTrainingProgramName.InnerText = drProject["training_program_name"].ToString();
                    SpnTrainingProjectName.InnerText = drProject["training_project_name"].ToString();
                }
                drProject.Close();
                drProject.Dispose();

                if (Request.QueryString["train_proj"] != null)
                {
                    //GetAutoRecommendedCandidate();
                }
            }
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }
            if (!Page.IsPostBack)
            {
                storeValues();
            }
            if (Page.IsPostBack)
            {
                if (ViewState["oldValues"] != null)
                {
                    oldValues = ViewState["oldValues"].ToString();
                }
            }

        }

        protected void BtnAddToAssignedList_Click(object sender, EventArgs e)
        {
            EnableIndia.App_Code.BAL.TrainingProjectBAL train = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            string message = String.Empty;
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand("", conn, trans);

            try
            {
                int candidatesAssigned = 0;
                foreach (ListViewDataItem item in LstViewTrainingProgram.Items)
                {
                    CheckBox ChkRecommendedCandidateName = (CheckBox)item.FindControl("ChkRecommendedCandidateName");
                    if (ChkRecommendedCandidateName.Checked)
                    {
                        string RecommendedCandidateID = Global.DecryptID(Convert.ToDouble(ChkRecommendedCandidateName.Attributes["RecommendedCandidateID"])).ToString();

                        string script = String.Empty;
                        int duplicateRecord = train.CheckDuplication(Convert.ToInt32(RecommendedCandidateID), this.trainingProjectID);
                        if (duplicateRecord > 0)
                        {
                            script = "alert('Candidate already assigned.');";
                            ClientScript.RegisterStartupScript(this.GetType(), "__key", script, true);
                            ChkRecommendedCandidateName.Checked = false;
                            return;
                        }
                        cmd = new MySqlCommand("", conn, trans);
                        train.AssignCandidateToTrainingProject(cmd, this.trainingProjectID.ToString(), RecommendedCandidateID);
                        candidatesAssigned++;
                    }
                }
                cmd = new MySqlCommand("", conn, trans);
                cmd.CommandType = CommandType.Text;
                train.UpdateTrainingProjectStatus(cmd, this.trainingProjectID);
                if (candidatesAssigned > 1)
                {
                    message = "Candidates assigned successfully.";
                }
                else
                {
                    message = "Candidate assigned successfully.";
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                message = Global.GetGlobalErrorMessage();
                trans.Rollback();
            }
            finally
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "__maessage", "alert(\"" + message + "\");", true);
                BtnSearchCandidates_Click(BtnSearchCandidates, new EventArgs());

                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }
        protected void btnSearchCandidate_click(object sender, EventArgs e)
        {
            GetAutoRecommendedCandidate();
        }

        private void GetAutoRecommendedCandidate()
        {
            EnableIndia.App_Code.BAL.SearchCandidatesBAL search = new EnableIndia.App_Code.BAL.SearchCandidatesBAL();
            Request.Cookies["grid_page_number"].Value = "1";
            search.AgeGroup = Convert.ToInt32(DdlSelectAge.Value);
            search.TrainingProgramID = this.trainingProgramID;
            search.TrainingProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["train_proj"]));
            search.SearchFor = TxtSearchFor.Text.Trim();
            search.SearchIn = DdlSearchIn.Value;

            LstViewTrainingProgram.DataSource = search.SearchRecommendedCandidate(search);
            LstViewTrainingProgram.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "__attachlabel", "", true);
        }

        protected void BtnSearchCandidates_Click(object sender, EventArgs e)
        {
            EnableIndia.App_Code.BAL.SearchCandidatesBAL search = new EnableIndia.App_Code.BAL.SearchCandidatesBAL();
            search.AgeGroup = Convert.ToInt32(DdlSelectAge.Value);
            search.TrainingProgramID = this.trainingProgramID;
            search.TrainingProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["train_proj"]));
            search.SearchFor = TxtSearchFor.Text.Trim();
            search.SearchIn = DdlSearchIn.Value;

            LstViewTrainingProgram.DataSource = search.SearchRecommendedCandidate(search);
            LstViewTrainingProgram.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "__attachlabel", "", true);
        }

        protected void LstViewTrainingProgram_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl LblCandidateName = (HtmlGenericControl)e.Item.FindControl("LblCandidateName");
                CheckBox ChkRecommendedCandidateName = (CheckBox)e.Item.FindControl("ChkRecommendedCandidateName");
                LblCandidateName.Attributes.Add("for", ChkRecommendedCandidateName.ClientID);
            }
        }

        protected void LnkBtnAddNonRecommendedCandidates_click(object sender, EventArgs e)
        {
            double projectID = Global.EncryptID(Convert.ToInt32(trainingProjectID));
            double programID = Global.EncryptID(Convert.ToInt32(trainingProgramID));
            Response.Redirect("~/Training/AddNonRecommendedCandidate.aspx?train_proj=" + projectID + "&train_prog=" + programID, true);
        }

        protected void LnkBtnAssignedList_click(object sender, EventArgs e)
        {
            double projectID = Global.EncryptID(Convert.ToInt32(trainingProjectID));
            double programID = Global.EncryptID(Convert.ToInt32(trainingProgramID));
            Response.Redirect("~/Training/AssignedList.aspx?train_proj=" + projectID + "&train_prog=" + programID, true);
        }
        protected void EnableDisAllCb(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            foreach (ListViewItem lv in this.LstViewTrainingProgram.Items)
            {
                CheckBox icb = (CheckBox)lv.FindControl("ChkRecommendedCandidateName");
                if (icb != null)
                {
                    if (cb.Checked)
                    {
                        icb.Checked = true;
                    }
                    else
                    {
                        icb.Checked = false;
                    }
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
            var checkBoxes = this.Controls.FindAll().OfType<CheckBox>();
            foreach (var cb in checkBoxes)
            {
                cb.Enabled = false;
            }
        }
        private void storeValues()
        {
        }
    }
}