using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Reflection;

using MySql.Data.MySqlClient;
namespace EnableIndia.Company
{

    public partial class AddVacancy : System.Web.UI.Page
    {
        public string VacancyID
        {
            get;
            set;
        }
        public string oldValues;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }
            Global.AuthenticateUser();
            Global.SetDefaultButtonOfTheForm(this.Form, BtnManageVacancy);
            Global.SetUICulture(this.Page);

            if (Request.QueryString["vac"] != null)
            {
                this.Title = this.Title.Replace("Add", "Update");
                this.VacancyID = Global.DecryptID(Convert.ToDouble(Request.QueryString["vac"])).ToString();
            }
            else
            {
                SpanDate.InnerText = DateTime.Today.ToString("dd/MM/yyyy");
                this.VacancyID = "-2";
            }
            //populate company code in hidden dropdown
            //CompaniesBAL companycode = new CompaniesBAL();
            //MySqlDataReader drComanyCodes = companycode.GetCompanies("-1");
            //while(drComanyCodes.Read())
            //{
            //    ListItem list = new ListItem(drComanyCodes["company_code"].ToString(), drComanyCodes["company_id"].ToString());
            //    list.Attributes.Add("ParentCompanyID", drComanyCodes["parent_company_id"].ToString());
            //    DdlHiddenCompanyCode.Items.Add(list);
            //}
            //drComanyCodes.Close();
            //drComanyCodes.Dispose();

            //DdlHiddenCompanyCode.Items.Insert(0, new ListItem("Select", "-2"));
            //DdlHiddenCompanyCode.Items.Add(new ListItem("Not Available", "-3"));

            //populate Role Name in hidden dropdown
            EnableIndia.App_Code.BAL.JobRolesBAL roles = new EnableIndia.App_Code.BAL.JobRolesBAL();
            MySqlDataReader drRoles = roles.GetJobRoles("-1");
            while (drRoles.Read())
            {
                ListItem list = new ListItem(drRoles["job_role_name"].ToString(), drRoles["job_role_id"].ToString());
                list.Attributes.Add("JobID", drRoles["job_id"].ToString());
                DdlHiddenRoleName.Items.Add(list);
            }
            drRoles.Close();
            drRoles.Dispose();

            DdlHiddenRoleName.Items.Insert(0, new ListItem("Select", "-2"));
            DdlHiddenRoleName.Items.Add(new ListItem("Not Available", "-3"));

            if (!Page.IsPostBack)
            {
                Global.ShowMessageInAlert(this.Form);
                TxtVacancyName.Focus();

                ////populate parent company in dropdown
                //ParentCompaniesBAL parentcompany = new ParentCompaniesBAL();
                //MySqlDataReader drParentCompany = parentcompany.GetParentCompanies();
                //Global.FillDropDown(DdlParentCompanies, drParentCompany, "company_name", "company_id");

                //BtnPopulatesCompanyCodes_Click(BtnPopulatesCompanyCodes, new EventArgs());

                //populate job type in dropdown
                EnableIndia.App_Code.BAL.JobsBAL jobtype = new EnableIndia.App_Code.BAL.JobsBAL();
                MySqlDataReader drJobTypes = jobtype.GetJobs();
                Global.FillDropDown(DdlJobTypes, drJobTypes, "job_name", "job_id");


                //BtnPopulateJobRoles_Click(BtnPopulateJobRoles, new EventArgs());

                GetVacancySubTypes();
                GetRequiredEducationQualification();
                GetVacancyProgramm();
                GetRequiredLanguage();
                GetGoroupOfCosideredCandidate();
                if (Request.QueryString["vac"] != null)
                {
                    SpnOperationStatus.InnerText = "Update";
                    GetVacancyDetail();
                    BtnClear.Visible = false;

                }

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

        protected void BtnPopulateJobRoles_Click(Object sender, EventArgs e)
        {
            EnableIndia.App_Code.BAL.JobRolesBAL jobRole = new EnableIndia.App_Code.BAL.JobRolesBAL();
            MySqlDataReader drJobRoles = jobRole.GetJobRoles(DdlJobTypes.Value);
            Global.FillDropDown(DdlJobRoles, drJobRoles, "job_role_name", "job_role_id");
            if (Page.IsPostBack)
            {
                // BtnPopulateJobRoles.Focus();
            }
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }

        }


        private void GetVacancyDetail()
        {
            EnableIndia.App_Code.BAL.VacancyBAL vacancyDetail = new EnableIndia.App_Code.BAL.VacancyBAL();
            MySqlDataReader drVacancyDatail = vacancyDetail.GetVacancyDetails(this.VacancyID);

            if (drVacancyDatail.Read())
            {
                //DdlParentCompanies.Value = drVacancyDatail["parent_company_id"].ToString();


                //BtnPopulatesCompanyCodes_Click(BtnPopulatesCompanyCodes, new EventArgs());
                //SpnHiddenCompanyCodeID.InnerText = drVacancyDatail["company_id"].ToString();

                //DdlCompanyCodes.Value = 
                SpanDate.InnerText = Convert.ToDateTime(drVacancyDatail["vacancy_date"]).ToString("dd/MM/yyyy");
                DdlJobTypes.Value = drVacancyDatail["job_id"].ToString();
                TxtVacancyName.Text = drVacancyDatail["vacancy_name"].ToString();

                //BtnPopulateJobRoles_Click(BtnPopulateJobRoles, new EventArgs());
                SpnHiddenRoleName.InnerText = drVacancyDatail["job_role_id"].ToString();

                //DdlJobRoles.Value = 
                if (drVacancyDatail["monthly_salary"].ToString().Equals("0.00"))
                {
                    TxtMonthlySalary.Text = "";
                }
                else
                {
                    TxtMonthlySalary.Text = Convert.ToInt32(drVacancyDatail["monthly_salary"]).ToString();
                }
                TxtResponsibilityTaskList.Text = drVacancyDatail["responsibilities"].ToString();
                TxtInterventionRequired.Text = drVacancyDatail["intervention_required"].ToString();

                if (drVacancyDatail["working_days"].ToString().Equals("0"))
                {
                    TxtWorkingDays.Text = "";
                }
                else
                {
                    TxtWorkingDays.Text = drVacancyDatail["working_days"].ToString();
                }

                if (drVacancyDatail["has_shifts"].ToString().Contains("Yes"))
                {
                    RdbYes.Checked = true;
                }
                if (drVacancyDatail["has_shifts"].ToString().Contains("No"))
                {
                    RdbNo.Checked = true;
                }

                if (drVacancyDatail["working_hours"].ToString().Equals("0"))
                {
                    TxtWorkingHours.Text = "";
                }
                else
                {
                    TxtWorkingHours.Text = drVacancyDatail["working_hours"].ToString();
                }

                TxtHolidayAndLeavePolicy.Text = drVacancyDatail["holiday_leave_policy"].ToString();
                drVacancyDatail.Close();
                drVacancyDatail.Dispose();
            }
            else
            {
                Response.Redirect("AddVacancy.aspx", true);
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["vac"] != null)
            {
                Response.Redirect("~/Company/AddVacancy.aspx");
            }
            else
            {
                Response.Redirect("~/Company/AddVacancy.aspx");
            }

        }

        private void GetVacancySubTypes()
        {
            EnableIndia.App_Code.BAL.VacancyBAL vacancy = new EnableIndia.App_Code.BAL.VacancyBAL();
            LstViewAcceptedDisabilitySubType.DataSource = vacancy.GetVacancyDisabilitySubTypes(this.VacancyID);
            LstViewAcceptedDisabilitySubType.DataBind();
        }

        private void GetRequiredEducationQualification()
        {
            EnableIndia.App_Code.BAL.VacancyBAL education = new EnableIndia.App_Code.BAL.VacancyBAL();
            LstViewEducationQualificationRequired.DataSource = education.GetVacancyEducationalQualifications(this.VacancyID); ;
            LstViewEducationQualificationRequired.DataBind();
        }

        private void GetVacancyProgramm()
        {
            EnableIndia.App_Code.BAL.VacancyBAL programm = new EnableIndia.App_Code.BAL.VacancyBAL();
            LstViewTrainingCandidateShouldHavePassed.DataSource = programm.GetVacancyTrainingPrograms(this.VacancyID);
            LstViewTrainingCandidateShouldHavePassed.DataBind();
        }

        private void GetRequiredLanguage()
        {
            EnableIndia.App_Code.BAL.VacancyBAL language = new EnableIndia.App_Code.BAL.VacancyBAL();
            LstViewRequiredLanguage.DataSource = language.GetVacancyRequiredLanguages(this.VacancyID);
            LstViewRequiredLanguage.DataBind();
        }

        private void GetGoroupOfCosideredCandidate()
        {
            EnableIndia.App_Code.BAL.VacancyBAL groupOfCandidate = new EnableIndia.App_Code.BAL.VacancyBAL();
            LstViewGroupsOfCandidatConsidered.DataSource = groupOfCandidate.GetVacancyConsideredCandidateGroups(this.VacancyID);
            LstViewGroupsOfCandidatConsidered.DataBind();
        }

        //protected void BtnPopulatesCompanyCodes_Click(Object sender, EventArgs e)
        //{
        //    CompaniesBAL companycode = new CompaniesBAL();
        //    MySqlDataReader drComanyCodes = companycode.GetCompanies(DdlParentCompanies.Value);
        //    Global.FillDropDown(DdlCompanyCodes, drComanyCodes, "company_code", "company_id");
        //    if (Page.IsPostBack)
        //    {
        //        //BtnPopulatesCompanyCodes.Focus();
        //    }
        //}

        protected void BtnManageVacancy_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            EnableIndia.App_Code.BAL.VacancyBAL vacancy = new EnableIndia.App_Code.BAL.VacancyBAL();

            //Checks for duplicate vacancies
            int duplicateVacancies = vacancy.CheckForDuplicateVacancy(this.VacancyID, TxtVacancyName.Text.Trim());
            if (duplicateVacancies > 0)
            {
                Global.RedirectAfterSubmit("Vacancy already exists.", BtnManageVacancy.ID);
            }
            else
            {
                MySqlConnection conn = Global.GetConnectionString();
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();

                MySqlCommand cmd = new MySqlCommand("", conn, trans);
                vacancy.VacancyDate = SpanDate.InnerText;
                vacancy.VacancyName = TxtVacancyName.Text.Trim();

                vacancy.JobID = string.IsNullOrEmpty(DdlJobTypes.Value)?-1:Convert.ToInt32(DdlJobTypes.Value);
                vacancy.JobRoleID = string.IsNullOrEmpty(TxtHiddenRecommendedRole.Text)?-1: Convert.ToInt32(TxtHiddenRecommendedRole.Text.Trim());

                try
                {
                    vacancy.MonthlySalary = Convert.ToDecimal(TxtMonthlySalary.Text.Trim());
                }
                catch
                {
                    vacancy.MonthlySalary = 0;
                }

                vacancy.VacancyCode = string.IsNullOrEmpty(TxtVacancyName.Text)?"": TxtVacancyName.Text.Trim();
                vacancy.Responsibilities = string.IsNullOrEmpty(TxtResponsibilityTaskList.Text)?"":TxtResponsibilityTaskList.Text.Trim();
                vacancy.InterventionedRequired = string.IsNullOrEmpty(TxtInterventionRequired.Text)?"":TxtInterventionRequired.Text.Trim();
                vacancy.WorkingDays = string.IsNullOrEmpty(TxtWorkingDays.Text)?"":TxtWorkingDays.Text.Trim();


                //vacancy.HasShifts=RdbYes.Checked;
                string hasShifts = "";
                if (RdbYes.Checked)
                {
                    hasShifts = "Yes";
                }
                else if (RdbNo.Checked)
                {
                    hasShifts = "No";
                }
                vacancy.HasShifts = hasShifts;



                vacancy.WorkingHours = TxtWorkingHours.Text.Trim();
                vacancy.HolidayAndLeavePolicy = TxtHolidayAndLeavePolicy.Text.Trim();
                string newValues = "";
                Type type = vacancy.GetType();
                PropertyInfo[] proterties = type.GetProperties();
                foreach (var p in proterties)
                {
                    newValues += "<b>" + p.Name + ": </b>" + p.GetValue(vacancy, null) + ", ";

                }
                if (!string.IsNullOrEmpty(newValues))
                {
                    int l = newValues.LastIndexOf((char)',');
                    if (l > 0)
                        newValues = newValues.Substring(0, l);
                }
                int i = 0;
                for (i = 0; i < this.LstViewAcceptedDisabilitySubType.Items.Count; i++)
                {
                    HtmlTableCell tc = (HtmlTableCell)LstViewAcceptedDisabilitySubType.Items[i].FindControl("textField");
                    if (tc != null)
                    {
                        newValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                    }
                    CheckBox cb = (CheckBox)this.LstViewAcceptedDisabilitySubType.Items[i].FindControl("ChkSelectDisabilitySubType");
                    if (cb != null)
                    {
                        newValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                    }
                }
                for (i = 0; i < this.LstViewEducationQualificationRequired.Items.Count; i++)
                {
                    HtmlTableCell tc = (HtmlTableCell)LstViewEducationQualificationRequired.Items[i].FindControl("textField");
                    if (tc != null)
                    {
                        newValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                    }
                    CheckBox cb = (CheckBox)this.LstViewEducationQualificationRequired.Items[i].FindControl("ChkSelectEducationalCourseQualification");
                    if (cb != null)
                    {
                        newValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                    }
                }
                for (i = 0; i < this.LstViewTrainingCandidateShouldHavePassed.Items.Count; i++)
                {
                    HtmlTableCell tc = (HtmlTableCell)LstViewTrainingCandidateShouldHavePassed.Items[i].FindControl("textField");
                    if (tc != null)
                    {
                        newValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                    }
                    CheckBox cb = (CheckBox)this.LstViewTrainingCandidateShouldHavePassed.Items[i].FindControl("ChkSelectTraningCandidateprogram");
                    if (cb != null)
                    {
                        newValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                    }
                }
                for (i = 0; i < this.LstViewRequiredLanguage.Items.Count; i++)
                {
                    HtmlTableCell tc = (HtmlTableCell)LstViewRequiredLanguage.Items[i].FindControl("textField");
                    if (tc != null)
                    {
                        newValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                    }
                    CheckBox cb = (CheckBox)this.LstViewRequiredLanguage.Items[i].FindControl("ChkSelectRequiredLanguage");
                    if (cb != null)
                    {
                        newValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                    }
                }
                for (i = 0; i < this.LstViewGroupsOfCandidatConsidered.Items.Count; i++)
                {
                    HtmlTableCell tc = (HtmlTableCell)LstViewGroupsOfCandidatConsidered.Items[i].FindControl("textField");
                    if (tc != null)
                    {
                        newValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                    }
                    CheckBox cb = (CheckBox)this.LstViewGroupsOfCandidatConsidered.Items[i].FindControl("ChkSelectGroupOfCandidate");
                    if (cb != null)
                    {
                        newValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                    }
                }
                try
                {
                    if (this.VacancyID.Equals("-2"))
                    {
                        //Add vacancy
                        cmd = new MySqlCommand("add_vacancy", conn, trans);
                        cmd.CommandType = CommandType.StoredProcedure;
                        this.VacancyID = vacancy.AddVacancy(cmd, vacancy);
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.Text;
                        Global.createAuditTrial(this.Title, newValues, "", null, "Insert", Session["username"].ToString());
                        message = "Vacancy added successfully.";
                    }
                    else
                    {
                        //update vacancy
                        vacancy.VacancyID = Convert.ToInt32(this.VacancyID);
                        cmd = new MySqlCommand("update_vacancy", conn, trans);
                        cmd.CommandType = CommandType.StoredProcedure;
                        vacancy.UpdateVacancy(cmd, vacancy);
                        Global.createAuditTrial(this.Title, newValues,oldValues, null, "Update", Session["username"].ToString());
                        message = "Vacancy updated successfully.";
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.Text;

                        //delete
                        cmd = new MySqlCommand("", conn, trans);
                        vacancy.DeleteVacancyDisabilitySubTypes(cmd, this.VacancyID);

                        cmd = new MySqlCommand("", conn, trans);
                        vacancy.DeleteVacancyEducationalQualifications(cmd, this.VacancyID);

                        cmd = new MySqlCommand("", conn, trans);
                        vacancy.DeleteVacancyTrainingPrograms(cmd, this.VacancyID);

                        cmd = new MySqlCommand("", conn, trans);
                        vacancy.DeleteVacancyRequiredLanguages(cmd, this.VacancyID);

                        cmd = new MySqlCommand("", conn, trans);
                        vacancy.DeleteVacancyConsideredCandidateGroups(cmd, this.VacancyID);


                    }

                    //Add disisbilitysubtype
                    foreach (ListViewDataItem item in LstViewAcceptedDisabilitySubType.Items)
                    {
                        CheckBox ChkSelectDisabilityType = (CheckBox)item.FindControl("ChkSelectDisabilitySubType");
                        if (ChkSelectDisabilityType.Checked)
                        {
                            string disabilityID = Global.DecryptID(Convert.ToDouble(ChkSelectDisabilityType.Attributes["DisabilityTypeID"])).ToString();
                            string disablitySubTypeID = Global.DecryptID(Convert.ToDouble(ChkSelectDisabilityType.Attributes["DisabilitySubTypeID"])).ToString();
                            cmd = new MySqlCommand("", conn, trans);
                            vacancy.UpdateVacancyDisabilitySubTypes(cmd, this.VacancyID, disabilityID, disablitySubTypeID);
                        }
                    }

                    //Add educational qualification
                    foreach (ListViewDataItem item in LstViewEducationQualificationRequired.Items)
                    {
                        CheckBox ChkSelectEducationalCourseQualification = (CheckBox)item.FindControl("ChkSelectEducationalCourseQualification");
                        if (ChkSelectEducationalCourseQualification.Checked)
                        {
                            string qualificationID = Global.DecryptID(Convert.ToDouble(ChkSelectEducationalCourseQualification.Attributes["EducationalQualificationID"])).ToString();
                            cmd = new MySqlCommand("", conn, trans);
                            vacancy.UpdateVacancyEducationalQualifications(cmd, this.VacancyID, qualificationID);
                        }
                    }

                    //Adds traning program
                    foreach (ListViewDataItem item in LstViewTrainingCandidateShouldHavePassed.Items)
                    {
                        CheckBox ChkSelectTraningCandidateprogram = (CheckBox)item.FindControl("ChkSelectTraningCandidateprogram");
                        if (ChkSelectTraningCandidateprogram.Checked)
                        {
                            string trainingProgramID = Global.DecryptID(Convert.ToDouble(ChkSelectTraningCandidateprogram.Attributes["TraningProgramID"])).ToString();
                            cmd = new MySqlCommand("", conn, trans);
                            vacancy.UpdateVacancyTrainingPrograms(cmd, this.VacancyID, trainingProgramID);
                        }
                    }

                    //Adds Language
                    foreach (ListViewDataItem item in LstViewRequiredLanguage.Items)
                    {
                        CheckBox ChkSelectRequiredLanguage = (CheckBox)item.FindControl("ChkSelectRequiredLanguage");
                        if (ChkSelectRequiredLanguage.Checked)
                        {
                            string languageID = Global.DecryptID(Convert.ToDouble(ChkSelectRequiredLanguage.Attributes["LanguageID"])).ToString();
                            cmd = new MySqlCommand("", conn, trans);
                            vacancy.UpdateVacancyRequiredLanguages(cmd, this.VacancyID, languageID);
                        }
                    }

                    //Adds Group of candidate

                    foreach (ListViewDataItem item in LstViewGroupsOfCandidatConsidered.Items)
                    {
                        CheckBox ChkSelectGroupOfCandidate = (CheckBox)item.FindControl("ChkSelectGroupOfCandidate");
                        if (ChkSelectGroupOfCandidate.Checked)
                        {
                            string candidateGroupID = Global.DecryptID(Convert.ToDouble(ChkSelectGroupOfCandidate.Attributes["CandidateGroupID"])).ToString();
                            cmd = new MySqlCommand("", conn, trans);
                            vacancy.UpdateVacancyConsideredCandidateGroups(cmd, this.VacancyID, candidateGroupID);
                        }

                    }
                    trans.Commit();
                }

                catch (Exception ex)
                {
                    message = "Error occurred. Please Contact Administrator";
                    trans.Rollback();
                }

                finally
                {
                    conn.Close();
                    cmd.Dispose();
                    conn.Dispose();
                    string url = "~/Company/AddVacancy.aspx?vac=" + Global.EncryptID(Convert.ToInt32(this.VacancyID));
                    url += "&msg=" + Global.EncryptQueryString(message);
                    url += "&foc=" + Global.EncryptQueryString("null");
                    Response.Redirect(url, true);
                }
            }
        }

        protected void LstViewAcceptedDisabilitySubType_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl lbDisabilitySubType = (HtmlGenericControl)e.Item.FindControl("lbDisabilitySubType");
                CheckBox ChkSelectDisabilitySubType = (CheckBox)e.Item.FindControl("ChkSelectDisabilitySubType");

                lbDisabilitySubType.Attributes.Add("for", ChkSelectDisabilitySubType.ClientID);
            }
        }

        protected void LstViewEducationQualificationRequired_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl lblEducationalCourseQualification = (HtmlGenericControl)e.Item.FindControl("lblEducationalCourseQualification");
                CheckBox ChkSelectEducationalCourseQualification = (CheckBox)e.Item.FindControl("ChkSelectEducationalCourseQualification");

                lblEducationalCourseQualification.Attributes.Add("for", ChkSelectEducationalCourseQualification.ClientID);
            }
        }

        protected void LstViewTrainingCandidateShouldHavePassed_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl lblTraningCandidateprogram = (HtmlGenericControl)e.Item.FindControl("lblTraningCandidateprogram");
                CheckBox ChkSelectTraningCandidateprogram = (CheckBox)e.Item.FindControl("ChkSelectTraningCandidateprogram");

                lblTraningCandidateprogram.Attributes.Add("for", ChkSelectTraningCandidateprogram.ClientID);
            }
        }

        protected void LstViewRequiredLanguage_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl lblRequiredLanguage = (HtmlGenericControl)e.Item.FindControl("lblRequiredLanguage");
                CheckBox ChkSelectRequiredLanguage = (CheckBox)e.Item.FindControl("ChkSelectRequiredLanguage");

                lblRequiredLanguage.Attributes.Add("for", ChkSelectRequiredLanguage.ClientID);
            }
        }

        //LstViewGroupsOfCandidatConsidered_ItemDataBound

        protected void LstViewGroupsOfCandidatConsidered_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl lblGroupOfCandidate = (HtmlGenericControl)e.Item.FindControl("lblGroupOfCandidate");
                CheckBox ChkSelectGroupOfCandidate = (CheckBox)e.Item.FindControl("ChkSelectGroupOfCandidate");

                lblGroupOfCandidate.Attributes.Add("for", ChkSelectGroupOfCandidate.ClientID);
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
            oldValues = "<b>Vacancy Id: </b>" + this.VacancyID + ", ";
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