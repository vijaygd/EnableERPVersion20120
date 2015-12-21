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


namespace EnableIndia.Training
{
    public partial class AddTrainingProgram : System.Web.UI.Page
    {
        public string TrainingProgramID
        {
            get;
            set;
        }
        private string oldValues;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }
            if (Request.RawUrl.Contains("prog"))
            {
                Page.Title = "Update Training Program";
                //TxtTrainingProgramName.Enabled = false;
                LblTitle.Text = "Update Training Program";
                LblTitle.Attributes["MessageStartText"] = "Update";
            }
            Global.AuthenticateUser();
            Global.SetDefaultButtonOfTheForm(this.Form, BtnManageTrainingProgram);

            if (Request.QueryString["prog"] != null)
            {
                this.TrainingProgramID = Global.DecryptID(Convert.ToDouble(Request.QueryString["prog"])).ToString();
            }
            else
            {
                this.TrainingProgramID = "-2";
            }

            if (!Page.IsPostBack)
            {
                TxtTrainingProgramName.Focus();
                if (Request.QueryString["prog"] != null)
                {
                    GetTrainingProgramDetails();
                    BtnClear.Visible = false;
                }

                GetTrainingProgramOtherDetails();
                Global.ShowMessageInAlert(this.Form);
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

        private void GetTrainingProgramDetails()
        {
            TrainingProgramBAL program = new TrainingProgramBAL();

            MySqlDataReader drTrainingProgramDetails = program.GetTrainingProgramDetails(this.TrainingProgramID);

            if (drTrainingProgramDetails.Read())
            {

                TxtTrainingProgramName.Text = drTrainingProgramDetails["training_program_name"].ToString();
                TxtComments.Text = drTrainingProgramDetails["comments"].ToString();

                drTrainingProgramDetails.Close();
                drTrainingProgramDetails.Dispose();
            }
            else
            {
                Response.Redirect("~/Training/AddTrainingProgram.aspx", true);
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["prog"] != null)
            {
                Response.Redirect("~/Training/AddTrainingProgram.aspx", true);
            }
            else
            {
                Response.Redirect("~/Training/AddTrainingProgram.aspx", true);
            }
        }

        private void GetTrainingProgramOtherDetails()
        {
            TrainingProgramBAL program = new TrainingProgramBAL();

            LstViewTrainingProgramEligibleDisabilityTypes.DataSource = program.GetTrainingProgramEligibleDisabilities(this.TrainingProgramID);
            LstViewTrainingProgramEligibleDisabilityTypes.DataBind();


            LstViewTrainingProgramEligibleGroups.DataSource = program.GetTrainingProgramEligibleCandidateGroups(this.TrainingProgramID);
            LstViewTrainingProgramEligibleGroups.DataBind();

            LstViewTrainingProgramEligibleEducationalQualification.DataSource = program.GetTrainingProgramEligibleQualifications(this.TrainingProgramID);
            LstViewTrainingProgramEligibleEducationalQualification.DataBind();

            LstViewTrainingProgramRecommendedRoles.DataSource = program.GetTrainingProgramRecommendedRoles(this.TrainingProgramID);
            LstViewTrainingProgramRecommendedRoles.DataBind();

            LstViewTrainingProgramRequiredLanguages.DataSource = program.GetTrainingProgramRequiredLanguages(this.TrainingProgramID);
            LstViewTrainingProgramRequiredLanguages.DataBind();

            LstViewTrainingProgramCandidateShouldHavePassed.DataSource = program.GetTrainingProgramRequiredForTrainingPrograms(this.TrainingProgramID);
            LstViewTrainingProgramCandidateShouldHavePassed.DataBind();
        }

        protected void BtnManageTrainingProgram_Click(object sender, EventArgs e)
        {
            string message = String.Empty;
            TrainingProgramBAL program = new TrainingProgramBAL();

            //check duplication
            string script = string.Empty;
            int duplicateRecord = program.CheckDuplicationProgramName(TxtTrainingProgramName.Text.Trim().ToString(), this.TrainingProgramID);
            if (duplicateRecord > 0)
            {
                script = "alert('Program Name already exists.');";
                ClientScript.RegisterStartupScript(this.GetType(), "__key", script, true);
                return;
            }
            else
            {
                MySqlConnection conn = Global.GetConnectionString();
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand("", conn, trans);
                string newValues = "";
                newValues = "Tran Prog: " + this.TrainingProgramID + ", ";
                newValues += "Tran Name: " + this.TxtTrainingProgramName.Text + ", ";
                int i = 0;
                for (i = 0; i < this.LstViewTrainingProgramEligibleDisabilityTypes.Items.Count; i++)
                {

                    HtmlTableCell tc = (HtmlTableCell)LstViewTrainingProgramEligibleDisabilityTypes.Items[i].FindControl("textField");
                    if (tc != null)
                    {
                        newValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                    }
                    CheckBox cb = (CheckBox)this.LstViewTrainingProgramEligibleDisabilityTypes.Items[i].FindControl("ChkSelectDisabilityType");
                    if (cb != null)
                    {
                        newValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                    }
                }
                for (i = 0; i < this.LstViewTrainingProgramEligibleGroups.Items.Count; i++)
                {
                    HtmlTableCell tc = (HtmlTableCell)LstViewTrainingProgramEligibleGroups.Items[i].FindControl("textField");
                    if (tc != null)
                    {
                        newValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                    }
                    CheckBox cb = (CheckBox)this.LstViewTrainingProgramEligibleGroups.Items[i].FindControl("ChkSelectGroup");
                    if (cb != null)
                    {
                        newValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                    }
                }
                for (i = 0; i < this.LstViewTrainingProgramEligibleEducationalQualification.Items.Count; i++)
                {
                    HtmlTableCell tc = (HtmlTableCell)LstViewTrainingProgramEligibleEducationalQualification.Items[i].FindControl("textField");
                    if (tc != null)
                    {
                        newValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                    }
                    CheckBox cb = (CheckBox)this.LstViewTrainingProgramEligibleEducationalQualification.Items[i].FindControl("ChkSelectEligibleEducatinalQualification");
                    if (cb != null)
                    {
                        newValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                    }
                }

                for (i = 0; i < this.LstViewTrainingProgramRecommendedRoles.Items.Count; i++)
                {
                    HtmlTableCell tc = (HtmlTableCell)LstViewTrainingProgramRecommendedRoles.Items[i].FindControl("textField");
                    if (tc != null)
                    {
                        newValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                    }
                    CheckBox cb = (CheckBox)this.LstViewTrainingProgramRecommendedRoles.Items[i].FindControl("ChkSelectTrainingProgramRecommendedRoles");
                    if (cb != null)
                    {
                        newValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                    }
                }
                for (i = 0; i < this.LstViewTrainingProgramRequiredLanguages.Items.Count; i++)
                {
                    HtmlTableCell tc = (HtmlTableCell)LstViewTrainingProgramRequiredLanguages.Items[i].FindControl("textField");
                    if (tc != null)
                    {
                        newValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                    }
                    CheckBox cb = (CheckBox)this.LstViewTrainingProgramRequiredLanguages.Items[i].FindControl("ChkSelectRequiredLanguage");
                    if (cb != null)
                    {
                        newValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                    }
                }
                for (i = 0; i < this.LstViewTrainingProgramCandidateShouldHavePassed.Items.Count; i++)
                {
                    HtmlTableCell tc = (HtmlTableCell)LstViewTrainingProgramCandidateShouldHavePassed.Items[i].FindControl("textField");
                    if (tc != null)
                    {
                        newValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                    }
                    CheckBox cb = (CheckBox)this.LstViewTrainingProgramCandidateShouldHavePassed.Items[i].FindControl("ChkSelectTrainingCandidate");
                    if (cb != null)
                    {
                        newValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                    }
                }
                newValues += "Comments: " + this.TxtComments.Text;

                try
                {
                    if (this.TrainingProgramID.Equals("-2"))
                    {
                        //Adds Training Program
                        this.TrainingProgramID = program.AddTrainingProgram(cmd, TxtTrainingProgramName.Text.Trim(), TxtComments.Text.Trim());
                        message = "Training program added successfully.";
                        Global.createAuditTrial(this.Title, newValues, "", null, "Insert", Session["username"].ToString());
                    }
                    else
                    {
                        //Updates Training Program
                        cmd = new MySqlCommand("", conn, trans);
                        program.UpdateTrainingProgram(cmd, TxtTrainingProgramName.Text.Trim(), TxtComments.Text.Trim(), this.TrainingProgramID);

                        //Deletes existing values in checkboxes from databases.
                        cmd = new MySqlCommand("", conn, trans);
                        program.DeleteTrainingProgramEligibleDisabilities(cmd, this.TrainingProgramID);

                        cmd = new MySqlCommand("", conn, trans);
                        program.DeleteTrainingProgramEligibleCandidateGroups(cmd, this.TrainingProgramID);

                        cmd = new MySqlCommand("", conn, trans);
                        program.DeleteTrainingProgramEligibleQualifications(cmd, this.TrainingProgramID);

                        cmd = new MySqlCommand("", conn, trans);
                        program.DeleteTrainingProgramRecommendedRoles(cmd, this.TrainingProgramID);

                        cmd = new MySqlCommand("", conn, trans);
                        program.DeleteTrainingProgramRequiredLanguages(cmd, this.TrainingProgramID);

                        cmd = new MySqlCommand("", conn, trans);
                        program.DeleteTrainingProgramRequiredForTrainingPrograms(cmd, this.TrainingProgramID);

                        message = "Training program updated successfully.";
                        Global.createAuditTrial(this.Title, newValues, oldValues, null, "Update", Session["username"].ToString());
                    }

                    // Adds training program disabilities
                    foreach (ListViewDataItem item in LstViewTrainingProgramEligibleDisabilityTypes.Items)
                    {
                        CheckBox ChkSelectDisabilityType = (CheckBox)item.FindControl("ChkSelectDisabilityType");
                        if (ChkSelectDisabilityType.Checked)
                        {
                            string disabilityID = Global.DecryptID(Convert.ToDouble(ChkSelectDisabilityType.Attributes["DisabilitypeID"])).ToString();
                            cmd = new MySqlCommand("", conn, trans);

                            program.UpdateTrainingProgramEligibleDisabilities(cmd, this.TrainingProgramID, disabilityID);
                        }
                    }

                    // Adds Eligible Groups
                    foreach (ListViewDataItem item in LstViewTrainingProgramEligibleGroups.Items)
                    {
                        CheckBox ChkSelectGroup = (CheckBox)item.FindControl("ChkSelectGroup");
                        if (ChkSelectGroup.Checked)
                        {
                            string groupID = Global.DecryptID(Convert.ToDouble(ChkSelectGroup.Attributes["GroupID"])).ToString();
                            cmd = new MySqlCommand("", conn, trans);
                            program.UpdateTrainingProgramEligibleCandidateGroups(cmd, this.TrainingProgramID, groupID);
                        }
                    }

                    foreach (ListViewDataItem item in LstViewTrainingProgramEligibleEducationalQualification.Items)
                    {
                        CheckBox ChkSelectEligibleEducatinalQualification = (CheckBox)item.FindControl("ChkSelectEligibleEducatinalQualification");
                        if (ChkSelectEligibleEducatinalQualification.Checked)
                        {
                            string courseID = Global.DecryptID(Convert.ToDouble(ChkSelectEligibleEducatinalQualification.Attributes["CourseID"])).ToString();
                            cmd = new MySqlCommand("", conn, trans);
                            program.UpdateTrainingProgramEligibleQualifications(cmd, this.TrainingProgramID, courseID);
                        }
                    }

                    foreach (ListViewDataItem item in LstViewTrainingProgramRecommendedRoles.Items)
                    {
                        CheckBox ChkSelectTrainingProgramRecommendedRoles = (CheckBox)item.FindControl("ChkSelectTrainingProgramRecommendedRoles");
                        if (ChkSelectTrainingProgramRecommendedRoles.Checked)
                        {
                            string jobRoleID = Global.DecryptID(Convert.ToDouble(ChkSelectTrainingProgramRecommendedRoles.Attributes["JobRoleID"])).ToString();
                            cmd = new MySqlCommand("", conn, trans);
                            program.UpdateTrainingProgramRecommendedRoles(cmd, this.TrainingProgramID, jobRoleID);
                        }
                    }

                    foreach (ListViewDataItem item in LstViewTrainingProgramRequiredLanguages.Items)
                    {
                        CheckBox ChkSelectRequiredLanguage = (CheckBox)item.FindControl("ChkSelectRequiredLanguage");
                        if (ChkSelectRequiredLanguage.Checked)
                        {
                            string languageID = Global.DecryptID(Convert.ToDouble(ChkSelectRequiredLanguage.Attributes["LanguageID"])).ToString();
                            cmd = new MySqlCommand("", conn, trans);
                            program.UpdateTrainingProgramRequiredLanguages(cmd, this.TrainingProgramID, languageID);
                        }
                    }

                    foreach (ListViewDataItem item in LstViewTrainingProgramCandidateShouldHavePassed.Items)
                    {
                        CheckBox ChkSelectTrainingCandidate = (CheckBox)item.FindControl("ChkSelectTrainingCandidate");
                        if (ChkSelectTrainingCandidate.Checked)
                        {
                            string traininProgramID = Global.DecryptID(Convert.ToDouble(ChkSelectTrainingCandidate.Attributes["TraininProgramID"])).ToString();
                            cmd = new MySqlCommand("", conn, trans);
                            program.UpdateTrainingProgramRequiredForTrainingPrograms(cmd, this.TrainingProgramID, traininProgramID);
                        }
                    }


                    trans.Commit();
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
                    string url = "~/Training/AddTrainingProgram.aspx?prog=" + Global.EncryptID(Convert.ToInt32(this.TrainingProgramID));
                    url += "&msg=" + Global.EncryptQueryString(message);
                    url += "&foc=" + Global.EncryptQueryString("null");
                    Response.Redirect(url, true);
                    //Global.RedirectAfterSubmit(message, BtnManageTrainingProgram.ID);
                }
            }
        }

        protected void LstViewTrainingProgramEligibleDisabilityTypes_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl lblDisabilitytype = (HtmlGenericControl)e.Item.FindControl("lblDisabilitytype");
                CheckBox ChkSelectDisabilityType = (CheckBox)e.Item.FindControl("ChkSelectDisabilityType");

                lblDisabilitytype.Attributes.Add("for", ChkSelectDisabilityType.ClientID);
            }
        }

        protected void LstViewTrainingProgramRecommendedJobTypes_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl lblJobType = (HtmlGenericControl)e.Item.FindControl("lblJobType");
                CheckBox ChkSelectJobType = (CheckBox)e.Item.FindControl("ChkSelectJobType");

                lblJobType.Attributes.Add("for", ChkSelectJobType.ClientID);
            }
        }

        protected void LstViewTrainingProgramEligibleGroups_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl lblGroup = (HtmlGenericControl)e.Item.FindControl("lblGroup");
                CheckBox ChkSelectGroup = (CheckBox)e.Item.FindControl("ChkSelectGroup");

                lblGroup.Attributes.Add("for", ChkSelectGroup.ClientID);
            }
        }

        protected void LstViewTrainingProgramEligibleEducationalQualification_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl lblEligibleEducatinalQualification = (HtmlGenericControl)e.Item.FindControl("lblEligibleEducatinalQualification");
                CheckBox ChkSelectEligibleEducatinalQualification = (CheckBox)e.Item.FindControl("ChkSelectEligibleEducatinalQualification");

                lblEligibleEducatinalQualification.Attributes.Add("for", ChkSelectEligibleEducatinalQualification.ClientID);
            }
        }

        protected void LstViewTrainingProgramRecommendedRoles_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl lblRecommendedRoles = (HtmlGenericControl)e.Item.FindControl("lblRecommendedRoles");
                CheckBox ChkSelectTrainingProgramRecommendedRoles = (CheckBox)e.Item.FindControl("ChkSelectTrainingProgramRecommendedRoles");

                lblRecommendedRoles.Attributes.Add("for", ChkSelectTrainingProgramRecommendedRoles.ClientID);
            }
        }

        protected void LstViewTrainingProgramRequiredLanguages_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl lblRequiredLanguage = (HtmlGenericControl)e.Item.FindControl("lblRequiredLanguage");
                CheckBox ChkSelectRequiredLanguage = (CheckBox)e.Item.FindControl("ChkSelectRequiredLanguage");

                lblRequiredLanguage.Attributes.Add("for", ChkSelectRequiredLanguage.ClientID);
            }
        }

        protected void LstViewTrainingProgramCandidateShouldHavePassed_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl lblTrainingCandidate = (HtmlGenericControl)e.Item.FindControl("lblTrainingCandidate");
                CheckBox ChkSelectTrainingCandidate = (CheckBox)e.Item.FindControl("ChkSelectTrainingCandidate");

                lblTrainingCandidate.Attributes.Add("for", ChkSelectTrainingCandidate.ClientID);
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
            oldValues = "<b>Tran Id: </b>" + this.TrainingProgramID + ", ";
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
                oldValues += "<b>" + s.ID + ":  </b>" + s.Value + ", ";
            }
            var radioButtons = this.Controls.FindAll().OfType<RadioButton>();
            foreach (var rb in radioButtons)
            {
                oldValues += "<b>" + rb.ID + ": </b>" + (rb.Checked ? "1" : "0").ToString() + ", ";
            }
            int i = 0;
            for (i = 0; i < this.LstViewTrainingProgramEligibleDisabilityTypes.Items.Count; i++)
            {
                HtmlTableCell tc = (HtmlTableCell)LstViewTrainingProgramEligibleDisabilityTypes.Items[i].FindControl("textField");
                if (tc != null)
                {
                    oldValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                }
                CheckBox cb = (CheckBox)this.LstViewTrainingProgramEligibleDisabilityTypes.Items[i].FindControl("ChkSelectDisabilityType");
                if (cb != null)
                {
                    oldValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                }
            }
            for (i = 0; i < this.LstViewTrainingProgramEligibleGroups.Items.Count; i++)
            {
                HtmlTableCell tc = (HtmlTableCell)LstViewTrainingProgramEligibleGroups.Items[i].FindControl("textField");
                if (tc != null)
                {
                    oldValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                }
                CheckBox cb = (CheckBox)this.LstViewTrainingProgramEligibleGroups.Items[i].FindControl("ChkSelectGroup");
                if (cb != null)
                {
                    oldValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                }
            }
            for (i = 0; i < this.LstViewTrainingProgramEligibleEducationalQualification.Items.Count; i++)
            {
                HtmlTableCell tc = (HtmlTableCell)LstViewTrainingProgramEligibleEducationalQualification.Items[i].FindControl("textField");
                if (tc != null)
                {
                    oldValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                }
                CheckBox cb = (CheckBox)this.LstViewTrainingProgramEligibleEducationalQualification.Items[i].FindControl("ChkSelectEligibleEducatinalQualification");
                if (cb != null)
                {
                    oldValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                }
            }

            for (i = 0; i < this.LstViewTrainingProgramRecommendedRoles.Items.Count; i++)
            {
                HtmlTableCell tc = (HtmlTableCell)LstViewTrainingProgramRecommendedRoles.Items[i].FindControl("textField");
                if (tc != null)
                {
                    oldValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                }
                CheckBox cb = (CheckBox)this.LstViewTrainingProgramRecommendedRoles.Items[i].FindControl("ChkSelectTrainingProgramRecommendedRoles");
                if (cb != null)
                {
                    oldValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                }
            }
            for (i = 0; i < this.LstViewTrainingProgramRequiredLanguages.Items.Count; i++)
            {
                HtmlTableCell tc = (HtmlTableCell)LstViewTrainingProgramRequiredLanguages.Items[i].FindControl("textField");
                if (tc != null)
                {
                    oldValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                }
                CheckBox cb = (CheckBox)this.LstViewTrainingProgramRequiredLanguages.Items[i].FindControl("ChkSelectRequiredLanguage");
                if (cb != null)
                {
                    oldValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                }
            }
            for (i = 0; i < this.LstViewTrainingProgramCandidateShouldHavePassed.Items.Count; i++)
            {
                HtmlTableCell tc = (HtmlTableCell)LstViewTrainingProgramCandidateShouldHavePassed.Items[i].FindControl("textField");
                if (tc != null)
                {
                    oldValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                }
                CheckBox cb = (CheckBox)this.LstViewTrainingProgramCandidateShouldHavePassed.Items[i].FindControl("ChkSelectTrainingCandidate");
                if (cb != null)
                {
                    oldValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                }
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