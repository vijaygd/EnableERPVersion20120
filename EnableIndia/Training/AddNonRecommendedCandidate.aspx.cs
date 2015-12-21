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



namespace EnableIndia.Training
{
    public partial class AddNonRecommendedCandidate : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }
            Global.SetDefaultButtonOfTheForm(this.Form, BtnSearchNonRecommenededCandidate);
            if (Request.QueryString["train_proj"] != null)
            {
                this.trainingProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["train_proj"]));
            }
            else
            {
                this.trainingProjectID = -1;
            }
            Global.AuthenticateUser();
            if (Request.QueryString["train_prog"] != null)
            {
                this.trainingProgramID = Global.DecryptID(Convert.ToDouble(Request.QueryString["train_prog"]));
            }
            else
            {
                this.trainingProgramID = -1;
            }

            // populate hidden dropdown value 
            JobRolesBAL HiddenRoles = new JobRolesBAL();
            MySqlDataReader drHiidenRoles = HiddenRoles.GetJobRoles("-1");
            while (drHiidenRoles.Read())
            {
                ListItem li = new ListItem(drHiidenRoles["job_role_name"].ToString(), drHiidenRoles["job_role_id"].ToString());
                li.Attributes.Add("JobID", drHiidenRoles["job_id"].ToString());
                DdlHiddenRecommendedRole.Items.Add(li);
            }
            DdlHiddenRecommendedRole.Items.Insert(0, new ListItem("All", "-1"));
            DdlHiddenRecommendedRole.Items.Add(new ListItem("Not Available", "-3"));
            drHiidenRoles.Close();
            drHiidenRoles.Dispose();

            CitiesBAL hiddenCity = new CitiesBAL();
            MySqlDataReader drHiddenCity = hiddenCity.GetCities("-1");
            while (drHiddenCity.Read())
            {
                ListItem li = new ListItem(drHiddenCity["city_name"].ToString(), drHiddenCity["city_id"].ToString());
                li.Attributes.Add("StateID", drHiddenCity["state_id"].ToString());
                DdlHiddenCity.Items.Add(li);
            }
            DdlHiddenCity.Items.Insert(0, new ListItem("All", "-1"));
            DdlHiddenCity.Items.Add(new ListItem("Not Available", "-3"));
            drHiddenCity.Close();
            drHiddenCity.Dispose();

            if (!Page.IsPostBack)
            {
                Global.InitializePagingCookies();

                Global.ShowMessageInAlert(this.Form);
                TrainingProjectBAL project = new TrainingProjectBAL();
                MySqlDataReader drProject = project.GetTrainingProgramInstance(this.trainingProjectID.ToString());
                if (drProject.Read())
                {
                    SpnTrainingProgramName.InnerText = drProject["training_program_name"].ToString();
                    SpnTrainingProjectName.InnerText = drProject["training_project_name"].ToString();
                }
                drProject.Close();
                drProject.Dispose();

                //populate Value in DropDown
                EducationBAL education = new EducationBAL();
                MySqlDataReader drEducation = education.GetEducations();
                Global.FillDropDown(DdlQualification, drEducation, "course_qualification_name", "course_qualification_id");
                DdlQualification.Items.RemoveAt(0);
                DdlQualification.Items.Insert(0, new ListItem("All", "-1"));
                DdlQualification.Items.Insert(1, new ListItem("None", "-2"));

                TrainingProgramBAL programm = new TrainingProgramBAL();
                MySqlDataReader drProgram = programm.GetTrainingProgramDetails("-1");
                Global.FillDropDown(DdlRecommendedTraining, drProgram, "training_program_name", "training_program_id");
                DdlRecommendedTraining.Items.RemoveAt(0);
                DdlRecommendedTraining.Items.Insert(0, new ListItem("All", "-1"));
                DdlRecommendedTraining.Items.Insert(1, new ListItem("None", "-2"));

                DisabilityTypesBAL disabilty = new DisabilityTypesBAL();
                MySqlDataReader drDisabilty = disabilty.GetDisabilityTypes();
                Global.FillDropDown(DdlDisablity, drDisabilty, "disability_type", "disability_id");
                DdlDisablity.Items.RemoveAt(0);
                DdlDisablity.Items.Insert(0, new ListItem("All", "-1"));

                NGOsBAL ngo = new NGOsBAL();
                MySqlDataReader drNgo = ngo.GetNGOs(true);
                Global.FillDropDown(DdlNGO, drNgo, "ngo_name", "ngo_id");
                DdlNGO.Items.RemoveAt(0);
                DdlNGO.Items.Insert(0, new ListItem("All", "-1"));
                DdlNGO.Items.Add(new ListItem("Others", "-2"));

                StatesBAL state = new StatesBAL();
                MySqlDataReader drState = state.GetStates("-1");
                Global.FillDropDown(DdlState, drState, "state_name", "state_id");
                DdlState.Items.RemoveAt(0);
                DdlState.Items.Insert(0, new ListItem("All", "-1"));

                CitiesBAL city = new CitiesBAL();
                MySqlDataReader drCity = city.GetCities("-1");
                Global.FillDropDown(DdlCity, drCity, "city_name", "city_id");
                DdlCity.Items.RemoveAt(0);
                DdlCity.Items.Insert(0, new ListItem("All", "-1"));

                JobsBAL job = new JobsBAL();
                MySqlDataReader drJobs = job.GetJobs();
                Global.FillDropDown(DdlRecommendedJobType, drJobs, "job_name", "job_id");
                DdlRecommendedJobType.Items.RemoveAt(0);
                DdlRecommendedJobType.Items.Insert(0, new ListItem("All", "-1"));
                DdlRecommendedJobType.Items.Insert(1, new ListItem("To be profiled", "-2"));
                DdlRecommendedJobType.Items.Insert(2, new ListItem("Profiled", "-3"));

                JobRolesBAL roles = new JobRolesBAL();
                MySqlDataReader drRoles = roles.GetJobRoles("-1");
                Global.FillDropDown(DdlRecommendedRole, drRoles, "job_role_name", "job_role_id");
                DdlRecommendedRole.Items.RemoveAt(0);
                DdlRecommendedRole.Items.Insert(0, new ListItem("All", "-1"));

                LanguagesBAL language = new LanguagesBAL();
                MySqlDataReader drLanguages = language.GetLanguagesInReader();
                Global.FillDropDown(DdlLanguage, drLanguages, "language_name", "language_id");
                DdlLanguage.Items.RemoveAt(0);
                DdlLanguage.Items.Insert(0, new ListItem("All", "-1"));
                DdlLanguage.Items.Insert(1, new ListItem("None", "-2"));

                CandidateGroupsBAL candidateGroup = new CandidateGroupsBAL();
                DataTable dtCandidateGroup = candidateGroup.GetCandidateGroup();
                DdlGroups.DataSource = dtCandidateGroup;
                DdlGroups.DataTextField = "group_name";
                DdlGroups.DataValueField = "group_id";
                DdlGroups.DataBind();
                DdlGroups.Items.Insert(0, new ListItem("All", "-1"));
                DdlGroups.Items.Insert(1, new ListItem("None", "-2"));

                Global glob = new Global();
                glob.GetAgeGroups(DdlAgeGroup);
                DdlAgeGroup.Items[0].Text = "all";

                DefaultsBAL def = new DefaultsBAL();
                DdlAgeGroup.Value = def.GetDefaultAgeGroupForSearch();
            }
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }

        }

        protected void BtnSearchNonRecommenededCandidate_click(object sender, EventArgs e)
        {
            TrainingProjectBAL project = new TrainingProjectBAL();
            Request.Cookies["grid_page_number"].Value = "1";
            project.TrainingProgramID = this.trainingProgramID;
            project.TrainingProjectID = this.trainingProjectID;
            project.QualificationID = Convert.ToInt32(DdlQualification.Value);
            project.NgoID = Convert.ToInt32(DdlNGO.Value);
            project.StateID = Convert.ToInt32(DdlState.Value);
            project.CityID = Convert.ToInt32(DdlCity.Value);
            project.RecommndedTrainingProgramID = Convert.ToInt32(DdlRecommendedTraining.Value);
            project.DisabilityID = Convert.ToInt32(DdlDisablity.Value);
            project.RecommendedJobID = Convert.ToInt32(DdlRecommendedJobType.Value);
            project.RecommendedRoleID = Convert.ToInt32(DdlRecommendedRole.Value);
            project.EmploymentStatus = Convert.ToInt32(DdlEmploymentStatus.Value);
            project.GroupID = Convert.ToInt32(DdlGroups.Value);
            project.LangaugeID = Convert.ToInt32(DdlLanguage.Value);
            project.AgeGroup = Convert.ToInt32(DdlAgeGroup.Value);
            project.SearchFor = TxtSearchFor.Text.Trim();
            project.SearchIn = DdlSearchIn.Value;

            LstViewAddNonRecommendedCandidate.DataSource = project.SearchNonRecommenededCandidate(project);
            LstViewAddNonRecommendedCandidate.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "__attachlabel", "", true);
        }
        protected void BtnSearchCandidates_Click(object sender, EventArgs e)
        {
            TrainingProjectBAL project = new TrainingProjectBAL();
            project.TrainingProgramID = this.trainingProgramID;
            project.TrainingProjectID = this.trainingProjectID;
            project.QualificationID = Convert.ToInt32(DdlQualification.Value);
            project.NgoID = Convert.ToInt32(DdlNGO.Value);
            project.StateID = Convert.ToInt32(DdlState.Value);
            project.CityID = Convert.ToInt32(DdlCity.Value);
            project.RecommndedTrainingProgramID = Convert.ToInt32(DdlRecommendedTraining.Value);
            project.DisabilityID = Convert.ToInt32(DdlDisablity.Value);
            project.RecommendedJobID = Convert.ToInt32(DdlRecommendedJobType.Value);
            project.RecommendedRoleID = Convert.ToInt32(DdlRecommendedRole.Value);
            project.EmploymentStatus = Convert.ToInt32(DdlEmploymentStatus.Value);
            project.GroupID = Convert.ToInt32(DdlGroups.Value);
            project.LangaugeID = Convert.ToInt32(DdlLanguage.Value);
            project.AgeGroup = Convert.ToInt32(DdlAgeGroup.Value);
            project.SearchFor = TxtSearchFor.Text.Trim();
            project.SearchIn = DdlSearchIn.Value;

            LstViewAddNonRecommendedCandidate.DataSource = project.SearchNonRecommenededCandidate(project);
            LstViewAddNonRecommendedCandidate.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "__attachlabel", "", true);
        }

        protected void LstViewAddNonRecommendedCandidate_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl LblCandidateName = (HtmlGenericControl)e.Item.FindControl("LblCandidateName");
                CheckBox ChkNonRecommendedCandidateName = (CheckBox)e.Item.FindControl("ChkNonRecommendedCandidateName");
                LblCandidateName.Attributes.Add("for", ChkNonRecommendedCandidateName.ClientID);
            }
        }

        protected void BtnAddToAssignedList_Click(object sender, EventArgs e)
        {
            TrainingProjectBAL train = new TrainingProjectBAL();
            string message = String.Empty;
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand("", conn, trans);

            try
            {
                int candidatesAssigned = 0;
                foreach (ListViewDataItem item in LstViewAddNonRecommendedCandidate.Items)
                {
                    CheckBox ChkNonRecommendedCandidateName = (CheckBox)item.FindControl("ChkNonRecommendedCandidateName");
                    if (ChkNonRecommendedCandidateName.Checked)
                    {
                        string NonRecommendedCandidateID = Global.DecryptID(Convert.ToDouble(ChkNonRecommendedCandidateName.Attributes["NonRecommendedCandidateID"])).ToString();
                        string script = String.Empty;
                        int duplicateRecord = train.CheckDuplication(Convert.ToInt32(NonRecommendedCandidateID), this.trainingProjectID);
                        if (duplicateRecord > 0)
                        {
                            ChkNonRecommendedCandidateName.Checked = false;
                            return;
                        }
                        cmd = new MySqlCommand("", conn, trans);
                        train.AssignCandidateToTrainingProject(cmd, this.trainingProjectID.ToString(), NonRecommendedCandidateID);
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

        protected void LnkBtnAssignedList_click(object sender, EventArgs e)
        {
            double projectID = Global.EncryptID(Convert.ToInt32(trainingProjectID));
            double programID = Global.EncryptID(Convert.ToInt32(trainingProgramID));
            Response.Redirect("~/Training/AssignedList.aspx?train_proj=" + projectID + "&train_prog=" + programID, true);
        }

        protected void LnkBtnAddRecommendedCandidates_click(object sender, EventArgs e)
        {
            double projectID = Global.EncryptID(Convert.ToInt32(trainingProjectID));
            double programID = Global.EncryptID(Convert.ToInt32(trainingProgramID));
            Response.Redirect("~/Training/AddRecommendedCandidate.aspx?train_proj=" + projectID + "&train_prog=" + programID, true);
        }
        protected void EnableDisAllCb(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            foreach (ListViewItem lv in this.LstViewAddNonRecommendedCandidate.Items)
            {
                CheckBox icb = (CheckBox)lv.FindControl("ChkNonRecommendedCandidateName");
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

    }
}