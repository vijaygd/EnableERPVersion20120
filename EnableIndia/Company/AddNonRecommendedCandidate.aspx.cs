using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Reflection;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Company
{
    public partial class AddNonRecommendedCandidate : System.Web.UI.Page
    {
        public string IntStDate;
        public string IntEdDate;
        public string oldValues;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }
            Global.SetUICulture(this.Page);
            Global.SetDefaultButtonOfTheForm(this.Form, BtnSearchNonRecommendedCandidates);
            Global.AuthenticateUser();

            // populate hidden dropdown value 
            EnableIndia.App_Code.BAL.JobRolesBAL HiddenRoles = new EnableIndia.App_Code.BAL.JobRolesBAL();
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
                this.hCompId.Value = string.IsNullOrEmpty(Request.QueryString["comp"]) ? "" : Request.QueryString["comp"].ToString();
                this.hEmpProj.Value = string.IsNullOrEmpty(Request.QueryString["emp_proj"]) ? "" : Request.QueryString["emp_proj"].ToString();

                string st1 = string.IsNullOrEmpty(Request.QueryString["comp"])?"":"?comp=" + Request.QueryString["comp"].ToString();
//                LnkBtnCompanyDetails.HRef += "?comp=" + Request.QueryString["comp"].ToString();
              //  LnkBtnCompanyDetails.HRef += st1;
                string st2 = string.IsNullOrEmpty(Request.QueryString["emp_proj"]) ? "" : "?emp_proj=" +Request.QueryString["emp_proj"].ToString();
                // LnkBtnEmploymentProjectDetails.HRef += "?emp_proj=" + Request.QueryString["emp_proj"].ToString();
                //LnkBtnEmploymentProjectDetails.HRef += st2;
                //LnkBtnAddNonRecommendedCandidates.PostBackUrl += "?emp_proj=" + Request.QueryString["emp_proj"].ToString() + "&comp=" + Request.QueryString["comp"].ToString();
                //LnkBtnAssignedList.PostBackUrl += "?emp_proj=" + Request.QueryString["emp_proj"].ToString() + "&comp=" + Request.QueryString["comp"].ToString();
                LnkBtnAddNonRecommendedCandidates.PostBackUrl += st2 + st1;
                LnkBtnAssignedList.PostBackUrl += st2 + st1;

                //populate Value in DropDown
                EnableIndia.App_Code.BAL.EducationBAL education = new EnableIndia.App_Code.BAL.EducationBAL();
                MySqlDataReader drEducation = education.GetEducations();
                Global.FillDropDown(DdlQualification, drEducation, "course_qualification_name", "course_qualification_id");
                DdlQualification.Items.RemoveAt(0);
                DdlQualification.Items.Insert(0, new ListItem("All", "-1"));
                DdlQualification.Items.Insert(1, new ListItem("None", "-2"));

                TrainingProgramBAL programm = new TrainingProgramBAL();
                MySqlDataReader drProgram = programm.GetTrainingProgramDetails("-1");
                Global.FillDropDown(DdlRecommendedTrainingPrograms, drProgram, "training_program_name", "training_program_id");
                DdlRecommendedTrainingPrograms.Items.RemoveAt(0);
                DdlRecommendedTrainingPrograms.Items.Insert(0, new ListItem("All", "-1"));
                DdlRecommendedTrainingPrograms.Items.Insert(1, new ListItem("None", "-2"));


                EnableIndia.App_Code.BAL.DisabilityTypesBAL disabilty = new EnableIndia.App_Code.BAL.DisabilityTypesBAL();
                MySqlDataReader drDisabilty = disabilty.GetDisabilityTypes();
                Global.FillDropDown(DdlDisabilities, drDisabilty, "disability_type", "disability_id");
                DdlDisabilities.Items.RemoveAt(0);
                DdlDisabilities.Items.Insert(0, new ListItem("All", "-1"));

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

                EnableIndia.App_Code.BAL.JobsBAL job = new EnableIndia.App_Code.BAL.JobsBAL();
                MySqlDataReader drJobs = job.GetJobs();
                Global.FillDropDown(DdlRecommendedJobType, drJobs, "job_name", "job_id");
                DdlRecommendedJobType.Items.RemoveAt(0);
                DdlRecommendedJobType.Items.Insert(0, new ListItem("Profiled", "-1"));
                //DdlRecommendedJobType.Items.Insert(1, new ListItem("To be profiled", "-2"));
                //DdlRecommendedJobType.Items.Insert(1, new ListItem("Profiled", "-3"));

                EnableIndia.App_Code.BAL.JobRolesBAL roles = new EnableIndia.App_Code.BAL.JobRolesBAL();
                MySqlDataReader drRoles = roles.GetJobRoles("-1");
                Global.FillDropDown(DdlRecommendedRole, drRoles, "job_role_name", "job_role_id");
                DdlRecommendedRole.Items.RemoveAt(0);
                DdlRecommendedRole.Items.Insert(0, new ListItem("All", "-1"));

                EnableIndia.App_Code.BAL.LanguagesBAL language = new EnableIndia.App_Code.BAL.LanguagesBAL();
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

                EnableIndia.App_Code.BAL.EmploymentProjectBAL proj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
                MySqlDataReader drEmploymentProjectDetails = proj.GetEmploymentProjectDetails(Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])).ToString());

                if (drEmploymentProjectDetails.HasRows)
                {
                    drEmploymentProjectDetails.Read();
                    SpnEmploymentProjectName.InnerText = drEmploymentProjectDetails["employment_project_name"].ToString();
                    SpnCurrentDemand.InnerText = drEmploymentProjectDetails["current_demand_of_people"].ToString();
                }
                drEmploymentProjectDetails.Close();
                drEmploymentProjectDetails.Dispose();
                IntStDate = Request.QueryString["IntStDate"].ToString();
                IntEdDate = Request.QueryString["IntEdDate"].ToString();
                ViewState["IntStDate"] = IntStDate;
                ViewState["IntEdDate"] = IntEdDate;

            }
            if (Page.IsPostBack)
            {
                if (ViewState["IntStDate"] != null)
                {
                    IntStDate = ViewState["IntStDate"].ToString();
                }
                if (ViewState["IntEdDate"] != null)
                {
                    IntEdDate = ViewState["IntEdDate"].ToString();
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

        protected void LstViewNonRecommendedCandidate_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                CheckBox ChkSelectNonRecommendedCandidate = (CheckBox)e.Item.FindControl("ChkSelectNonRecommendedCandidate");
                HtmlGenericControl LblCandidateName = (HtmlGenericControl)e.Item.FindControl("LblCandidateName");

                LblCandidateName.Attributes.Add("for", ChkSelectNonRecommendedCandidate.ClientID);
            }
        }

        protected void BtnSearchNonRecommendedCandidates_Click(object sender, EventArgs e)
        {
            EnableIndia.App_Code.BAL.SearchCandidatesBAL search = new EnableIndia.App_Code.BAL.SearchCandidatesBAL();
            Request.Cookies["grid_page_number"].Value = "1";
            search.EmploymentProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"]));
            search.QualificationID = Convert.ToInt32(DdlQualification.Value);
            search.NgoID = Convert.ToInt32(DdlNGO.Value);
            search.PresentAddressStateID = Convert.ToInt32(DdlState.Value);
            search.CityID = Convert.ToInt32(TxtHidddenCity.Text.Trim());
            search.TrainingProgramID = Convert.ToInt32(DdlRecommendedTrainingPrograms.Value);
            search.DisabilityID = Convert.ToInt32(DdlDisabilities.Value);
            search.JobTypeId = Convert.ToInt32(DdlRecommendedJobType.Value);
            search.JobRoleID = Convert.ToInt32(TxtHiddenRecommendedRole.Text.Trim());
            search.LanguageID = Convert.ToInt32(DdlLanguage.Value);
            search.CandidateGroupID = Convert.ToInt32(DdlGroups.Value);
            search.AgeGroup = Convert.ToInt32(DdlAgeGroup.Value);
            search.SearchFor = TxtSearchFor.Text.Trim();
            search.SearchIn = DdlSearchIn.Value;
            search.EmploymentStatus = Convert.ToInt32(DdlTypeOfCandidate.Value);
            search.Gender = Convert.ToInt32(DdlSelectGender.Value);
            LstViewNonRecommendedCandidate.DataSource = search.SearchNonRecommendedCandidatesForEmploymentProject(search);
            LstViewNonRecommendedCandidate.DataBind();
        }

        protected void BtnSearchCandidates_Click(object sender, EventArgs e)
        {
            EnableIndia.App_Code.BAL.SearchCandidatesBAL search = new EnableIndia.App_Code.BAL.SearchCandidatesBAL();
            search.EmploymentProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"]));
            search.QualificationID = Convert.ToInt32(DdlQualification.Value);
            search.NgoID = Convert.ToInt32(DdlNGO.Value);
            search.PresentAddressStateID = Convert.ToInt32(DdlState.Value);
            search.CityID = Convert.ToInt32(TxtHidddenCity.Text.Trim());
            search.TrainingProgramID = Convert.ToInt32(DdlRecommendedTrainingPrograms.Value);
            search.DisabilityID = Convert.ToInt32(DdlDisabilities.Value);
            search.JobTypeId = Convert.ToInt32(DdlRecommendedJobType.Value);
            search.JobRoleID = Convert.ToInt32(TxtHiddenRecommendedRole.Text.Trim());
            search.LanguageID = Convert.ToInt32(DdlLanguage.Value);
            search.CandidateGroupID = Convert.ToInt32(DdlGroups.Value);
            search.AgeGroup = Convert.ToInt32(DdlAgeGroup.Value);
            search.SearchFor = TxtSearchFor.Text.Trim();
            search.SearchIn = DdlSearchIn.Value;
            search.EmploymentStatus = Convert.ToInt32(DdlTypeOfCandidate.Value);
            search.Gender = Convert.ToInt32(DdlSelectGender.Value);
            LstViewNonRecommendedCandidate.DataSource = search.SearchNonRecommendedCandidatesForEmploymentProject(search);
            LstViewNonRecommendedCandidate.DataBind();
        }

        protected void BtnAddToAssignedList_Click(object sender, EventArgs e)
        {
            string employmentProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])).ToString();
            string message = String.Empty;
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand("", conn, trans);
            EnableIndia.App_Code.BAL.EmploymentProjectBAL proj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            string newValues = "";
            try
            {
                int candidatesAssigned = 0;
                foreach (ListViewItem item in LstViewNonRecommendedCandidate.Items)
                {
                    CheckBox ChkSelectNonRecommendedCandidate = (CheckBox)item.FindControl("ChkSelectNonRecommendedCandidate");
                    if (ChkSelectNonRecommendedCandidate.Checked)
                    {
                        cmd = new MySqlCommand("", conn, trans);

                        string candidateID = Global.DecryptID(Convert.ToDouble(ChkSelectNonRecommendedCandidate.Attributes["CandidateID"])).ToString();
                        proj.AssignCandidateToEmploymentProject(cmd, employmentProjectID, candidateID);
                        candidatesAssigned++;
                        newValues += "Candidate id: " + candidateID + ", ";
                    //    Global.createAuditTrial("Add Non Reco Cand", newValues, "", null, "Insert", Session["username"].ToString());
                    }
                }

                cmd = new MySqlCommand("", conn, trans);
                cmd.CommandType = CommandType.Text;
                proj.UpdateEmploymentProjectStatus(cmd, Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])));
                //Type type = proj.GetType();
                //PropertyInfo[] proterties = type.GetProperties();
                //newValues = "";
                //foreach (var p in proterties)
                //{
                //    newValues += "<b>" + p.Name + ": </b>" + p.GetValue(proj, null) + ", ";

                //}
                if (!string.IsNullOrEmpty(newValues))
                {
                    int l = newValues.LastIndexOf((char)',');
                    if (l > 0)
                        newValues = newValues.Substring(0, l);
                }
               // Global.createAuditTrial("Add Non Reco Cand", newValues, "", null, "Update", Session["username"].ToString());
                trans.Commit();

                if (candidatesAssigned > 1)
                {
                    Global.createAuditTrial(this.Title, newValues, oldValues, null, "Update", Session["username"].ToString());
                    message = "Candidates assigned successfully.";
                }
                else
                {
                    Global.createAuditTrial(this.Title, newValues, "", null, "Insert", Session["username"].ToString());
                    message = "Candidate assigned successfully.";
                }
                //Response.Redirect(LnkBtnAssignedList.PostBackUrl + "&msg=" + message + "&foc=null");
                //string url = "~/Company/AddNonRecommendedCandidate.aspx?emp_proj=" + Request.QueryString["emp_proj"] + "&comp=" + Request.QueryString["comp"];
                //url += "&msg=" + Global.EncryptQueryString(message);
                //url += "&foc=" + Global.EncryptQueryString("null");
                //Response.Redirect(url, true);

            }
            catch (Exception ex)
            {
                trans.Rollback();
                Response.Write(ex.Message);
            }
            finally
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "__maessage", "alert(\"" + message + "\");", true);
                //Global.RedirectAfterSubmit(message, BtnSearchNonRecommendedCandidates.ID);
                BtnSearchCandidates_Click(BtnSearchCandidates, new EventArgs());

                conn.Close();
                cmd.Dispose();
                conn.Dispose();

            }
        }
        protected void LnkBtnAssignedList_click(object sender, EventArgs e)
        {
            string url = "~/Company/AssignedList.aspx?emp_proj=" + this.hEmpProj.Value + "&comp=" + this.hCompId.Value;
            url += "&IntStDate=" + IntStDate;
            url += "&IntEdDate=" + IntEdDate;
            Response.Redirect(url, false);
        }
        protected void btnCompanyDetClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Company/AddCompany.aspx?comp=" + this.hCompId.Value);
        }
        protected void empProjectsClick(object sender, EventArgs e)
        {
               Response.Redirect("~/Company/AddEmploymentProjects.aspx?emp_proj=" + this.hEmpProj.Value);

        }
        protected void lbAddReccomCandidates(object sender, EventArgs e)
        {
            string url="~/Company/AddRecommendedCandidate.aspx?emp_proj=" + this.hEmpProj.Value + "&comp=" + this.hCompId.Value;
            if (!string.IsNullOrEmpty(IntStDate))
            {
                url += "&IntStDate=" + IntStDate;
                url += "&IntEdDate=" + IntEdDate;
            }
            Response.Redirect(url);
        }
        protected void EnableDisAllCb(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            foreach (ListViewItem lv in this.LstViewNonRecommendedCandidate.Items)
            {
                CheckBox icb = (CheckBox)lv.FindControl("ChkSelectNonRecommendedCandidate");
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
        }
        private void storeValues()
        {
            var textBoxes = this.Controls.FindAll().OfType<TextBox>();
            foreach (var t in textBoxes)
            {
                oldValues += "<b>" + t.ID + ": </b>" + t.Text + ", ";
            }
            var dropDowns = this.Controls.FindAll().OfType<DropDownList>();
            foreach (var d in dropDowns)
            {
                oldValues += "<b>" + d.ID + ": </b>" + d.SelectedItem.Text + ", ";
            }
            var selects = this.Controls.FindAll().OfType<HtmlSelect>();
            foreach (var s in selects)
            {
                try
                {
                    int x = s.SelectedIndex;
                    oldValues += "<b>" + s.ID + ":  </b>" + s.Items[x].Text + ", ";
                }
                catch
                { ;;}
            }
            var checkBoxes = this.Controls.FindAll().OfType<CheckBox>();
            foreach (var cb in checkBoxes)
            {
                oldValues += "<b>" + cb.ID + ": </b>" + (cb.Checked ? "1" : "0").ToString();
            }
            var radioButtons = this.Controls.FindAll().OfType<RadioButton>();
            foreach (var rb in radioButtons)
            {
                oldValues += "<b>" + rb.ID + ": </b>" + (rb.Checked ? "1" : "0").ToString();
            }
            if (!string.IsNullOrEmpty(oldValues))
            {
                int l = oldValues.LastIndexOf(",");
                if (l > 0)
                    oldValues = oldValues.Substring(0, l);  // Remove the last unwanted ,
            }
            ViewState["oldValues"] = oldValues;
        }
    }
}