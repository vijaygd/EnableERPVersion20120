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
    public partial class AddEmploymentProjects : System.Web.UI.Page
    {
        public string EmloymentProjectID
        {
            get;
            set;
        }
        string oldValues;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }

            Global.AuthenticateUser();
            Global.SetUICulture(this.Page);


            if (Request.QueryString["emp_proj"] != null)
            {
                this.Title = this.Title.Replace("Add", "Update");
                this.EmloymentProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])).ToString();
                if (Request.QueryString["emp_proj"].ToString() == "0")
                {
                    TblBlankMessage.Visible = true;
                    TblEmploymentProjectFrNoData.Visible = false;
                }
            }
            else
            {

                TblEmploymentDetail.Visible = false;
                this.EmloymentProjectID = "-2";
                if (TblEmploymentDetail.Visible == false)
                {
                    Global.SetDefaultButtonOfTheForm(this.Form, BtnPopulatesVacancyDetail);
                }
                else
                {
                    Global.SetDefaultButtonOfTheForm(this.Form, BtnManageEmploymentProject);
                }
            }

            //populate company code  in hidden company dropdown
            CompaniesBAL company = new CompaniesBAL();
            MySqlDataReader drCompany = company.GetCompanies("-1");
            while (drCompany.Read())
            {
                ListItem li = new ListItem(drCompany["company_code"].ToString(), drCompany["company_id"].ToString());
                li.Attributes.Add("ParentCompanyID", drCompany["parent_company_id"].ToString());
                DdlHiddenCompanyCode.Items.Add(li);
            }

            drCompany.Close();
            drCompany.Dispose();

            DdlHiddenCompanyCode.Items.Insert(0, new ListItem("Select", "-2"));
            DdlHiddenCompanyCode.Items.Add(new ListItem("Not Available", "-3"));


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
                ///added for vacancy Details
                EnableIndia.App_Code.BAL.JobsBAL jobtype = new EnableIndia.App_Code.BAL.JobsBAL();
                MySqlDataReader drJobTypes = jobtype.GetJobs();
                Global.FillDropDown(DdlJobTypes, drJobTypes, "job_name", "job_id");

                EnableIndia.App_Code.BAL.ParentCompaniesBAL parentcompany = new EnableIndia.App_Code.BAL.ParentCompaniesBAL();
                MySqlDataReader drParentCompany = parentcompany.GetParentCompanies();
                Global.FillDropDown(DdlParentCompany, drParentCompany, "company_name", "company_id");

                EnableIndia.App_Code.BAL.VacancyBAL vacancycode = new EnableIndia.App_Code.BAL.VacancyBAL();
                MySqlDataReader drVacancyCodes = vacancycode.GetVacancyCodes();
                Global.FillDropDown(DdlVacancyCode, drVacancyCodes, "vacancy_name", "vacancy_id");

                //BtnPopulatesCompanyCodes_Click(BtnPopulatesCompanyCodes, new EventArgs());

                // SpnHiddenCompanyID.InnerText=drParentCompany["company_id"].ToString();

                // BtnPopulatesVacancyCodes_Click(BtnPopulatesVacancyCodes, new EventArgs());

                EnableIndia.App_Code.BAL.EmployeeBAL emp = new EnableIndia.App_Code.BAL.EmployeeBAL();
                DdlEmployeeManagingThisVacancy.DataSource = emp.GetEmployeeList();
                DdlEmployeeManagingThisVacancy.DataTextField = "employee_name";
                DdlEmployeeManagingThisVacancy.DataValueField = "employee_id";
                DdlEmployeeManagingThisVacancy.DataBind();

                if (DdlEmployeeManagingThisVacancy.Items.Count > 0)
                {
                    DdlEmployeeManagingThisVacancy.Items.Insert(0, new ListItem("Select", "-2"));
                }
                else
                {
                    DdlEmployeeManagingThisVacancy.Items.Add(new ListItem("Not Available", "-2"));
                }
                if (!this.EmloymentProjectID.Equals("-2"))
                {
                    SpnOperationStatus.InnerText = "Update";
                    GetEmploymentProjectDetail();
                    BtnClear.Visible = false;
                    TblEmploymentProjectName.Visible = true;
                    TblEmploymentProjectDate.Visible = true;
                }
                Global.ShowMessageInAlert(this.Form);
            }

            if (Request.RawUrl.Contains("comp"))
            {
                CompaniesBAL parent = new CompaniesBAL();
                MySqlDataReader drParent = parent.GetcompanyDetails(Global.DecryptID(Convert.ToDouble(Request.QueryString["comp"])).ToString());
                if (drParent.Read())
                {
                    DdlParentCompany.Value = drParent["parent_company_id"].ToString();
                }
                drParent.Close();
                drParent.Dispose();


                DdlHiddenCompanyCode.Value = Global.DecryptID(Convert.ToDouble(Request.QueryString["comp"])).ToString();
                DdlCompanyCode.Disabled = true;
                DdlParentCompany.Disabled = true;
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

        protected void GetVacancySalary()
        {
            EnableIndia.App_Code.BAL.VacancyBAL vacancyDetail = new EnableIndia.App_Code.BAL.VacancyBAL();
            MySqlDataReader drVacancyDatail = vacancyDetail.GetVacancyDetails(DdlVacancyCode.Value);

            if (drVacancyDatail.Read())
            {
                if (drVacancyDatail["monthly_salary"].ToString().Equals("0.00"))
                {
                    TxtMonthlySalary.Text = "";
                }
                else
                {
                    TxtMonthlySalary.Text = Convert.ToInt32(drVacancyDatail["monthly_salary"]).ToString();
                }
            }
            drVacancyDatail.Close();
            drVacancyDatail.Dispose();
        }

        private void GetEmploymentProjectDetail()
        {
            EnableIndia.App_Code.BAL.EmploymentProjectBAL emp = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            //string employmentprojectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])).ToString();
            MySqlDataReader drEmploymentProjectDetails = emp.GetEmploymentProjectDetails(this.EmloymentProjectID);

            if (drEmploymentProjectDetails.Read())
            {
                if (Request.QueryString["emp_proj"] != null)
                {
                    DdlParentCompany.Visible = false;
                    DdlCompanyCode.Visible = false;
                    DdlVacancyCode.Visible = false;

                    BtnPopulatesVacancyDetail.Visible = false;
                }
                SpnCreationDate.InnerText = Convert.ToDateTime(drEmploymentProjectDetails["project_creation_date_time"]).ToString("dd/MM/yyyy");

                SpnCreationTime.InnerText = drEmploymentProjectDetails["project_start_time"].ToString();


                SpnEmploymentProjectName.InnerText = drEmploymentProjectDetails["employment_project_name"].ToString();
                DdlParentCompany.Value = drEmploymentProjectDetails["parent_company_id"].ToString();

                SpnParentCompany.InnerText = DdlParentCompany.Items.FindByValue(drEmploymentProjectDetails["parent_company_id"].ToString()).Text;

                //BtnPopulatesCompanyCodes_Click(BtnPopulatesCompanyCodes, new EventArgs());
                TxtHiddenCompanyID.Text = drEmploymentProjectDetails["company_id"].ToString();
                //DdlCompanyCode.Value = drEmploymentProjectDetails["company_id"].ToString();
                SpnCompanyCode.InnerText = DdlHiddenCompanyCode.Items.FindByValue(drEmploymentProjectDetails["company_id"].ToString()).Text;

                BtnPopulatesVacancyDetail_Click(BtnPopulatesVacancyDetail, new EventArgs());
                //TxtHiddenVacanciesID.Text = drEmploymentProjectDetails["vacancy_id"].ToString();
                DdlVacancyCode.Value = drEmploymentProjectDetails["vacancy_id"].ToString();
                SpnVacancyCode.InnerText = DdlVacancyCode.Items.FindByValue(drEmploymentProjectDetails["vacancy_id"].ToString()).Text;


                BtnPopulatesVacancyDetail_Click(BtnPopulatesVacancyDetail, new EventArgs());

                TxtPossibleStartDate.Text = Convert.ToDateTime(drEmploymentProjectDetails["possible_start_date"]).ToString("dd/MM/yyyy");
                TxtPossibleEndDate.Text = Convert.ToDateTime(drEmploymentProjectDetails["possible_end_date"]).ToString("dd/MM/yyyy");
                TxtCurrentDemand.Text = drEmploymentProjectDetails["current_demand_of_people"].ToString();
                TxtDesignation.Text = drEmploymentProjectDetails["designation"].ToString();
                DdlProjectTypes.Value = drEmploymentProjectDetails["project_type"].ToString();
                if (drEmploymentProjectDetails["salary"].ToString().Equals("0.00"))
                {
                    TxtMonthlySalary.Text = "";
                }
                else
                {
                    TxtMonthlySalary.Text = Convert.ToInt32(drEmploymentProjectDetails["salary"]).ToString();
                }
                DdlEmployeeManagingThisVacancy.Value = drEmploymentProjectDetails["employee_id"].ToString();
                if (drEmploymentProjectDetails["is_closed"].ToString().Equals("1"))
                {
                    BtnManageEmploymentProject.Visible = false;
                }
                drEmploymentProjectDetails.Close();
                drEmploymentProjectDetails.Dispose();
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["emp_proj"] != null)
            {
                Response.Redirect("~/Company/AddEmploymentProjects.aspx");
            }
            else
            {
                Response.Redirect("~/Company/AddEmploymentProjects.aspx");
            }
        }

        protected void BtnPopulatesCompanyCodes_Click(Object sender, EventArgs e)
        {
            CompaniesBAL companycode = new CompaniesBAL();
            MySqlDataReader drCompanyCodes = companycode.GetCompanies(DdlParentCompany.Value);
            Global.FillDropDown(DdlCompanyCode, drCompanyCodes, "company_code", "company_id");
            if (Page.IsPostBack)
            {
                //BtnPopulatesCompanyCodes.Focus();
            }
        }

        protected void BtnPopulatesVacancyDetail_Click(Object sender, EventArgs e)
        {
            TblEmploymentDetail.Visible = true;
            TblVacancyDetail.Visible = true;
            TxtHiddenVacanciesValue.Text = "1";
            if (this.EmloymentProjectID == "-2")
            {
                EnableIndia.App_Code.BAL.VacancyBAL vacancydetail = new EnableIndia.App_Code.BAL.VacancyBAL();
                MySqlDataReader drVacancyDetail = vacancydetail.GetVacancyDetails(DdlVacancyCode.Value);
                if (drVacancyDetail.Read())
                {
                    DdlJobTypes.Value = drVacancyDetail["job_id"].ToString();
                    SpnHiddenRoleName.InnerText = drVacancyDetail["job_role_id"].ToString();
                    GetVacancySubTypes();
                    GetRequiredEducationQualification();
                    GetVacancyProgramm();
                    GetRequiredLanguage();
                    GetGroupOfCosideredCandidate();
                    //DdlJobRoles.Value = 
                    if (drVacancyDetail["working_days"].ToString().Equals("0"))
                    {
                        TxtWorkingDays.Text = "";
                    }
                    else
                    {
                        TxtWorkingDays.Text = drVacancyDetail["working_days"].ToString();
                    }

                    if (drVacancyDetail["monthly_salary"].ToString().Equals("0.00"))
                    {
                        TxtMonthlySalary.Text = "";
                    }
                    else
                    {
                        TxtMonthlySalary.Text = Convert.ToInt32(drVacancyDetail["monthly_salary"]).ToString();
                    }
                    //SpnAssignUniqueCodeForThisVacancy.InnerText = drVacancyDetail["vacancy_code"].ToString();
                    TxtResponsibilityTaskList.Text = drVacancyDetail["responsibilities"].ToString();
                    TxtInterventionRequired.Text = drVacancyDetail["intervention_required"].ToString();
                    if (drVacancyDetail["has_shifts"].ToString().Contains("Yes"))
                    {
                        RdbYes.Checked = true;
                    }
                    if (drVacancyDetail["has_shifts"].ToString().Contains("No"))
                    {
                        RdbNo.Checked = true;
                    }

                    if (drVacancyDetail["working_hours"].ToString().Equals("0"))
                    {
                        TxtWorkingHours.Text = "";
                    }
                    else
                    {
                        TxtWorkingHours.Text = drVacancyDetail["working_hours"].ToString();
                    }

                    TxtHolidayAndLeavePolicy.Text = drVacancyDetail["holiday_leave_policy"].ToString();

                }
                GetCompanyDetails();
                if (this.EmloymentProjectID == "-2")
                {
                    GetVacancySalary();
                }
                drVacancyDetail.Close();
                drVacancyDetail.Dispose();
                BtnPopulatesVacancyDetail.Focus();
            }
            else
            {

                EnableIndia.App_Code.BAL.EmploymentProjectBAL emp = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
                MySqlDataReader drEmploymentProjectDetails = emp.GetEmploymentProjectDetails(this.EmloymentProjectID);
                if (drEmploymentProjectDetails.Read())
                {
                    DdlJobTypes.Value = drEmploymentProjectDetails["job_id"].ToString();
                    SpnHiddenRoleName.InnerText = drEmploymentProjectDetails["job_role_id"].ToString();
                    GetEmploymentProjectSubTypes();
                    GetEmploymentProjectRequiredLanguage();
                    GetEmploymentProjectProgramm();
                    GetEmploymentProjectRequiredEducationQualification();
                    GetEmploymentProjectGoroupOfCosideredCandidate();

                    //SpnAssignUniqueCodeForThisVacancy.InnerText = drVacancyDetail["vacancy_code"].ToString();
                    TxtResponsibilityTaskList.Text = drEmploymentProjectDetails["responsibilities"].ToString();
                    TxtInterventionRequired.Text = drEmploymentProjectDetails["intervention_required"].ToString();
                    if (drEmploymentProjectDetails["working_days"].ToString().Equals("0"))
                    {
                        TxtWorkingDays.Text = "";
                    }
                    else
                    {
                        TxtWorkingDays.Text = drEmploymentProjectDetails["working_days"].ToString();
                    }

                    if (drEmploymentProjectDetails["has_shifts"].ToString().Contains("Yes"))
                    {
                        RdbYes.Checked = true;
                    }
                    if (drEmploymentProjectDetails["has_shifts"].ToString().Contains("No"))
                    {
                        RdbNo.Checked = true;
                    }

                    if (drEmploymentProjectDetails["working_hours"].ToString().Equals("0"))
                    {
                        TxtWorkingHours.Text = "";
                    }
                    else
                    {
                        TxtWorkingHours.Text = drEmploymentProjectDetails["working_hours"].ToString();
                    }

                    TxtHolidayAndLeavePolicy.Text = drEmploymentProjectDetails["holiday_leave_policy"].ToString();
                    drEmploymentProjectDetails.Close();
                    drEmploymentProjectDetails.Dispose();
                    GetCompanyDetails();
                }
                //BtnPopulatesVacancyDetail.Focus();
            }
            //BtnManageEmploymentProject.Focus();
            Global.SetDefaultButtonOfTheForm(this.Form, BtnManageEmploymentProject);
        }

        private void GetVacancySubTypes()
        {
            EnableIndia.App_Code.BAL.VacancyBAL vacancy = new EnableIndia.App_Code.BAL.VacancyBAL();
            LstViewAcceptedDisabilitySubType.DataSource = vacancy.GetVacancyDisabilitySubTypes(DdlVacancyCode.Value);
            LstViewAcceptedDisabilitySubType.DataBind();
        }

        private void GetRequiredEducationQualification()
        {
            EnableIndia.App_Code.BAL.VacancyBAL education = new EnableIndia.App_Code.BAL.VacancyBAL();
            LstViewEducationQualificationRequired.DataSource = education.GetVacancyEducationalQualifications(DdlVacancyCode.Value);
            ;
            LstViewEducationQualificationRequired.DataBind();
        }

        private void GetVacancyProgramm()
        {
            EnableIndia.App_Code.BAL.VacancyBAL programm = new EnableIndia.App_Code.BAL.VacancyBAL();
            LstViewTrainingCandidateShouldHavePassed.DataSource = programm.GetVacancyTrainingPrograms(DdlVacancyCode.Value);
            LstViewTrainingCandidateShouldHavePassed.DataBind();
        }

        private void GetRequiredLanguage()
        {
            EnableIndia.App_Code.BAL.VacancyBAL language = new EnableIndia.App_Code.BAL.VacancyBAL();
            LstViewRequiredLanguage.DataSource = language.GetVacancyRequiredLanguages(DdlVacancyCode.Value);
            LstViewRequiredLanguage.DataBind();
        }

        private void GetGroupOfCosideredCandidate()
        {
            EnableIndia.App_Code.BAL.VacancyBAL groupOfCandidate = new EnableIndia.App_Code.BAL.VacancyBAL();
            LstViewGroupsOfCandidatConsidered.DataSource = groupOfCandidate.GetVacancyConsideredCandidateGroups(DdlVacancyCode.Value);
            LstViewGroupsOfCandidatConsidered.DataBind();
        }

        //in case after adding emploment project
        private void GetEmploymentProjectSubTypes()
        {
            EnableIndia.App_Code.BAL.EmploymentProjectBAL employee = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            LstViewAcceptedDisabilitySubType.DataSource = employee.GetEmploymentProjectDisabilitySubTypes(this.EmloymentProjectID);
            LstViewAcceptedDisabilitySubType.DataBind();
        }

        private void GetEmploymentProjectRequiredEducationQualification()
        {
            EnableIndia.App_Code.BAL.EmploymentProjectBAL employee = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            LstViewEducationQualificationRequired.DataSource = employee.GetEmploymentProjectEducationalQualifications(this.EmloymentProjectID);
            ;
            LstViewEducationQualificationRequired.DataBind();
        }

        private void GetEmploymentProjectProgramm()
        {
            EnableIndia.App_Code.BAL.EmploymentProjectBAL employee = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            LstViewTrainingCandidateShouldHavePassed.DataSource = employee.GetEmploymentProjectTrainingPrograms(this.EmloymentProjectID);
            LstViewTrainingCandidateShouldHavePassed.DataBind();
        }

        private void GetEmploymentProjectRequiredLanguage()
        {
            EnableIndia.App_Code.BAL.EmploymentProjectBAL employee = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            LstViewRequiredLanguage.DataSource = employee.GetEmploymentProjectRequiredLanguages(this.EmloymentProjectID);
            LstViewRequiredLanguage.DataBind();
        }

        private void GetEmploymentProjectGoroupOfCosideredCandidate()
        {
            EnableIndia.App_Code.BAL.EmploymentProjectBAL employee = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            LstViewGroupsOfCandidatConsidered.DataSource = employee.GetEmploymentProjectConsideredCandidateGroups(this.EmloymentProjectID);
            LstViewGroupsOfCandidatConsidered.DataBind();
        }
        //==========
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

        protected void LstViewGroupsOfCandidatConsidered_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl lblGroupOfCandidate = (HtmlGenericControl)e.Item.FindControl("lblGroupOfCandidate");
                CheckBox ChkSelectGroupOfCandidate = (CheckBox)e.Item.FindControl("ChkSelectGroupOfCandidate");

                lblGroupOfCandidate.Attributes.Add("for", ChkSelectGroupOfCandidate.ClientID);
            }
        }


        //private void GetCompanyContacts()
        //{
        //    EmploymentProjectContactBAL employee = new EmploymentProjectContactBAL();
        //    DataTable companyContact=employee.getda

        //}
        //protected void BtnPopulatesVacancyCodes_Click(Object sender, EventArgs e)
        //{
        //    EnableIndia.App_Code.BAL.VacancyBAL vacancycode = new EnableIndia.App_Code.BAL.VacancyBAL();
        //    MySqlDataReader drVacancyCodes = vacancycode.GetVacancyCodes(DdlParentCompany.Value, DdlHiddenCompanyCode.Value);
        //    Global.FillDropDown(DdlVacancyCode, drVacancyCodes, "vacancy_code", "vacancy_id");
        //    if (Page.IsPostBack)
        //    {
        //        //BtnPopulatesVacancyCodes.Focus();
        //    }

        //}
        private void GetCompanyDetails()
        {
            EmploymentProjectContactBAL company = new EmploymentProjectContactBAL();
            LstViewAddEmploymentProject.DataSource = company.GetEmploymentProjectContacts(EmloymentProjectID, TxtHiddenCompanyID.Text);
            LstViewAddEmploymentProject.DataBind();

        }
        protected void BtnManageEmploymentProject_Click(object sender, EventArgs e)
        {
            if (this.DdlEmployeeManagingThisVacancy.SelectedIndex <= 0)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("At leaset one employee must be selected for managing the vacancy");
                if (this.TblEmploymentDetail.Visible == false)
                    this.TblEmploymentDetail.Visible = true;
                return;
            }
            EnableIndia.App_Code.BAL.EmploymentProjectBAL project = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            string message = String.Empty;
            MySqlCommand cmd = new MySqlCommand("", conn);
            MySqlTransaction trans = conn.BeginTransaction();

            // project.VacancyID = Convert.ToInt32(DdlVacancyCode.Value);

            project.ParentCompanyID = Convert.ToInt32(DdlParentCompany.Value);
            if (this.EmloymentProjectID.Equals("-2"))
            {
                project.CompanyID = Convert.ToInt32(DdlHiddenCompanyCode.Value);
                project.VacancyID = Convert.ToInt32(DdlVacancyCode.Value);
            }
            else
            {
                project.CompanyID = Convert.ToInt32(TxtHiddenCompanyID.Text.Trim());
                project.VacancyID = Convert.ToInt32(DdlVacancyCode.Value);
            }
            try
            {
                project.PossibleStartDate = Convert.ToDateTime(TxtPossibleStartDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                project.PossibleStartDate = DateTime.Today.ToString("yyyy/MM/dd");
            }
            try
            {
                project.PossibleEndDate = Convert.ToDateTime(TxtPossibleEndDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                project.PossibleEndDate = DateTime.Today.ToString("yyyy/MM/dd");
            }

            project.CurrentDemandOfPeople = Convert.ToInt32(TxtCurrentDemand.Text.Trim());
            project.Designation = TxtDesignation.Text.Trim();
            project.ProjectType = DdlProjectTypes.Value;
            try
            {
                project.Salary = Convert.ToDecimal(TxtMonthlySalary.Text.Trim());
            }
            catch
            {
                project.Salary = 0;
            }

            project.EmployeeID = Convert.ToInt32(DdlEmployeeManagingThisVacancy.Value);

            //DdlVacancyCode.Items[DdlVacancyCode.SelectedIndex].Text.Visible = false;
            project.CompanyCode = DdlHiddenCompanyCode.Items[DdlHiddenCompanyCode.SelectedIndex].Text;
            project.VacancyCode = DdlVacancyCode.Items[DdlVacancyCode.SelectedIndex].Text;
            project.JobID = Convert.ToInt32(DdlJobTypes.Value);
            project.JobRoleID = Convert.ToInt32(TxtHiddenRecommendedRole.Text.Trim());
            project.Responsibilities = TxtResponsibilityTaskList.Text.Trim();

            project.InterventionRequired = TxtInterventionRequired.Text.Trim();


            project.WorkingDays = TxtWorkingDays.Text.Trim();


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
            project.HasShifts = hasShifts;

            project.WorkingHours = TxtWorkingHours.Text.Trim();
            project.HolidayLeavePolicy = TxtHolidayAndLeavePolicy.Text.Trim();

            DateTime stDate = Convert.ToDateTime(this.TxtPossibleStartDate.Text);
            DateTime edDate = Convert.ToDateTime(this.TxtPossibleEndDate.Text);
            int dResult = DateTime.Compare(stDate, edDate);
            if (this.DdlJobTypes.SelectedIndex <= 0)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("Job Type must be selected");
                if (!this.TblEmploymentDetail.Visible)
                {
                    this.TblEmploymentDetail.Visible = true;
                }
                this.DdlJobTypes.Focus();
                return;
            }
            if (dResult > 0)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("Start date is greater than end date");
                if (!this.TblEmploymentDetail.Visible)
                {
                    this.TblEmploymentDetail.Visible = true;
                }
                return;
            }

            string newValues = "";
            Type type = project.GetType();
            PropertyInfo[] proterties = type.GetProperties();
            foreach (var p in proterties)
            {
                
                newValues += "<b>" + p.Name + ": </b>" + p.GetValue(project, null) + ", ";
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
                if (this.EmloymentProjectID.Equals("-2"))
                {
                    cmd = new MySqlCommand("add_employment_project", conn, trans);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.EmloymentProjectID = project.AddEmploymentProject(cmd, project);

                    message = "Employment project added successfully.";
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.Text;
                    Global.createAuditTrial(this.Title, newValues, "", null, "Insert", Session["username"].ToString());
                }
                else
                {
                    project.EmploymentProjectID = Convert.ToInt32(this.EmloymentProjectID);
                    cmd = new MySqlCommand("update_employment_project", conn, trans);
                    cmd.CommandType = CommandType.StoredProcedure;
                    project.UpdateEmploymentProject(cmd, project);

                    message = "Employment project Updated successfully.";
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.Text;
                    EmploymentProjectContactBAL deleteContact = new EmploymentProjectContactBAL();
                    deleteContact.DeleteEmploymentProjectContacts(cmd, this.EmloymentProjectID);

                    cmd = new MySqlCommand("", conn, trans);
                    project.DeleteEmploymentProjectDisabilitySubTypes(cmd, this.EmloymentProjectID);

                    cmd = new MySqlCommand("", conn, trans);
                    project.DeleteEmploymentProjectEducationalQualifications(cmd, this.EmloymentProjectID);

                    cmd = new MySqlCommand("", conn, trans);
                    project.DeleteEmploymentProjectTrainingProgram(cmd, this.EmloymentProjectID);

                    cmd = new MySqlCommand("", conn, trans);
                    project.DeleteEmploymentProjectLangauges(cmd, this.EmloymentProjectID);

                    cmd = new MySqlCommand("", conn, trans);
                    project.DeleteEmploymentProjectConsideredCandidateGroups(cmd, this.EmloymentProjectID);
                    Global.createAuditTrial(this.Title, newValues, oldValues, null, "Update", Session["username"].ToString());
   
                }


                //add contact from check box
                foreach (ListViewDataItem item in LstViewAddEmploymentProject.Items)
                {
                    CheckBox ChkContactPerson = (CheckBox)item.FindControl("ChkContactPerson");

                    if (ChkContactPerson.Checked)
                    {
                        HtmlSelect DdlTypeOfContact = (HtmlSelect)item.FindControl("DdlTypeOfContact");
                        EmploymentProjectContactBAL contact = new EmploymentProjectContactBAL();
                        string contactID = Global.DecryptID(Convert.ToDouble(ChkContactPerson.Attributes["ContactID"])).ToString();
                        cmd = new MySqlCommand("", conn, trans);
                        contact.AddEmploymentProjectContact(cmd, this.EmloymentProjectID, contactID, DdlTypeOfContact.Value);
                    }
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
                        project.AddEmploymentProjectDisabilitySubTypes(cmd, this.EmloymentProjectID, disabilityID, disablitySubTypeID);
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
                        project.AddEmploymentProjectEducationalQualifications(cmd, this.EmloymentProjectID, qualificationID);
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
                        project.AddEmploymentProjectTrainingPrograms(cmd, this.EmloymentProjectID, trainingProgramID);
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
                        project.AddEmploymentProjectRequiredLanguages(cmd, this.EmloymentProjectID, languageID);
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
                        project.AddEmploymentProjectConsideredCandidateGroups(cmd, this.EmloymentProjectID, candidateGroupID);
                    }

                }

                trans.Commit();

                //add task in task management
                ////
                if (project.InterventionRequired != "")
                {
                    CompaniesBAL company = new CompaniesBAL();

                    company.HistoryDate = DateTime.Now.ToString("yyyy/MM/dd");
                    if (this.EmloymentProjectID.Equals("-2"))
                    {
                        company.CompanyID = Convert.ToInt32(DdlHiddenCompanyCode.Value);
                    }
                    else
                    {
                        company.CompanyID = Convert.ToInt32(TxtHiddenCompanyID.Text.Trim());
                    }
                    company.ParentCompanyID = Convert.ToInt32(DdlParentCompany.Value);

                    company.Details = "";
                    company.CandidateID = 0;
                    company.CandidateFlagID = company.GetIDOfIntervaentionrequired();
                    company.EmployemntProjectID = Convert.ToInt32(this.EmloymentProjectID);
                    MySqlDataReader drTaskdetail = company.GetEmployemntProjectNameAndIntervention(company);
                    if (drTaskdetail.Read())
                    {
                        company.Details = drTaskdetail["employment_project_name"].ToString() + ", ";
                        company.Details += project.InterventionRequired + " ";
                    }
                    drTaskdetail.Close();
                    drTaskdetail.Dispose();

                    company.IsHistory = 0;
                    //company.EmployeeID = -2;
                    company.RecommendedAction = "";
                    company.FollowUpDate = "1900/01/01";
                    company.Status = "Open";
                    if (Request.QueryString["comp_hist"] != null)
                    {
                        bool rowsUpdated = company.UpdateCompanyHistory(company);

                        if (rowsUpdated.Equals(true))
                        {
                            //  Global.RedirectAfterSubmit("Company History Updated Successfully.", BtnAddUpdateCompanyHistory.ID);
                        }
                    }
                    else
                    {
                        int isTask = company.CheckForDuplicationIntevention(company);

                        if (isTask == 0)
                        {
                            bool rowsAdded = company.AddCompanyHistory(company);
                            if (rowsAdded.Equals(true))
                            {
                                // employee.UpdateCandidateAssignedList(cmd, employee);
                                //message = "Assigned list updated successfully.";
                            }
                        }
                    }
                }
                ////

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
                string url = "~/Company/AddEmploymentProjects.aspx?emp_proj=" + Global.EncryptID(Convert.ToInt32(this.EmloymentProjectID));
                url += "&msg=" + Global.EncryptQueryString(message);
                url += "&foc=" + Global.EncryptQueryString("null");
                Response.Redirect(url, true);
                //Global.RedirectAfterSubmit(message, BtnManageEmploymentProject.ID);
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
            oldValues = "<b>Employment Project Id: </b>" + this.EmloymentProjectID + ", ";
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
            //var checkBoxes = this.Controls.FindAll().OfType<CheckBox>();
            //foreach (var cb in checkBoxes)
            //{
            //    oldValues += "<b>" + cb.ID + ": </b>" + (cb.Checked ? "1" : "0").ToString();
            //}
            var radioButtons = this.Controls.FindAll().OfType<RadioButton>();
            foreach (var rb in radioButtons)
            {
                oldValues += "<b>" + rb.ID + ": </b>" + (rb.Checked ? "1" : "0").ToString();
            }
            int i = 0;
            for (i = 0; i < this.LstViewAcceptedDisabilitySubType.Items.Count; i++)
            {
                HtmlTableCell tc = (HtmlTableCell)LstViewAcceptedDisabilitySubType.Items[i].FindControl("textField");
                if (tc != null)
                {
                    oldValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                }
                CheckBox cb = (CheckBox)this.LstViewAcceptedDisabilitySubType.Items[i].FindControl("ChkSelectDisabilitySubType");
                if (cb != null)
                {
                    oldValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                }
            }
            for (i = 0; i < this.LstViewEducationQualificationRequired.Items.Count; i++)
            {
                HtmlTableCell tc = (HtmlTableCell)LstViewEducationQualificationRequired.Items[i].FindControl("textField");
                if (tc != null)
                {
                    oldValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                }
                CheckBox cb = (CheckBox)this.LstViewEducationQualificationRequired.Items[i].FindControl("ChkSelectEducationalCourseQualification");
                if (cb != null)
                {
                    oldValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                }
            }
            for (i = 0; i < this.LstViewTrainingCandidateShouldHavePassed.Items.Count; i++)
            {
                HtmlTableCell tc = (HtmlTableCell)LstViewTrainingCandidateShouldHavePassed.Items[i].FindControl("textField");
                if (tc != null)
                {
                    oldValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                }
                CheckBox cb = (CheckBox)this.LstViewTrainingCandidateShouldHavePassed.Items[i].FindControl("ChkSelectTraningCandidateprogram");
                if (cb != null)
                {
                    oldValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                }
            }
            for (i = 0; i < this.LstViewRequiredLanguage.Items.Count; i++)
            {
                HtmlTableCell tc = (HtmlTableCell)LstViewRequiredLanguage.Items[i].FindControl("textField");
                if (tc != null)
                {
                    oldValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                }
                CheckBox cb = (CheckBox)this.LstViewRequiredLanguage.Items[i].FindControl("ChkSelectRequiredLanguage");
                if (cb != null)
                {
                    oldValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                }
            }
            for (i = 0; i < this.LstViewGroupsOfCandidatConsidered.Items.Count; i++)
            {
                HtmlTableCell tc = (HtmlTableCell)LstViewGroupsOfCandidatConsidered.Items[i].FindControl("textField");
                if (tc != null)
                {
                    oldValues += tc.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                }
                CheckBox cb = (CheckBox)this.LstViewGroupsOfCandidatConsidered.Items[i].FindControl("ChkSelectGroupOfCandidate");
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