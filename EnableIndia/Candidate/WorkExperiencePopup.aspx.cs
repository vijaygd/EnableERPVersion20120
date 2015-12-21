using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Candidate
{

    public partial class WorkExperiencePopup : System.Web.UI.Page
    {
        [Serializable]
        public struct wkDates
        {
            public string wkStartDate;
            public string wkEndDate;
        }
        wkDates[] workingDates;

        public string CandidateID
        {
            get;
            set;
        }

        public string EmploymentProjectID
        {
            get;
            set;
        }
        protected int ddSelCompanyIndex;
        public int rowId; // Introduced to skip the update of the row number for checking...
        public string IntStDate;
        public string IntEdDate;
        public string oldValues;

        [Serializable]
        public class wrkDates
        {
            public string wkStartDate { get; set; }
            public string wkEndDate { get; set; }
            public bool bCurrentFlag { get; set; }
        }

        public IList<wrkDates> sworkDates = new List<wrkDates>();
        public bool bEmpFts = false;
        private void Page_Init(object sender, EventArgs e)
        {
            Page.ClientTarget = "uplevel";

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }

            if (!Page.IsPostBack)
            {
                rowId = string.IsNullOrEmpty(Request.QueryString["rowId"]) ? -1 : Convert.ToInt32(Request.QueryString["rowId"].ToString());
                ViewState["rowId"] = rowId;
                string sWorkDates = string.IsNullOrEmpty(Request.QueryString["workDates"]) ? "" : Request.QueryString["workDates"].ToString();
                if (string.IsNullOrEmpty(sWorkDates))
                {
                    // Check for session.....
                    // ----------------------
                    if (!string.IsNullOrEmpty((string)Session["workDates"]))
                    {
                        sWorkDates = Session["workDates"].ToString();
                        Session.Remove("workDates");
                    }
                }

                XmlDocument xDoc = new XmlDocument();

                // ---------------------------
                // Convert into working dates.
                // ---------------------------
                if (!string.IsNullOrEmpty(sWorkDates))
                {
                    xDoc.LoadXml(sWorkDates);
                    XmlElement xelRoot = xDoc.DocumentElement;
                    XmlNodeList xmlNodes = xelRoot.SelectNodes("/WorkingDates/WorkDate");
                    foreach (XmlNode xNode in xmlNodes)
                    {
                        wrkDates wk = new wrkDates();
                        wk.wkStartDate = xNode.SelectSingleNode("./StartDate").InnerText;
                        wk.wkEndDate = xNode.SelectSingleNode("./EndDate").InnerText;
                        wk.bCurrentFlag = string.IsNullOrEmpty(xNode.SelectSingleNode("./Current").InnerText) ? false : true;
                        sworkDates.Add(wk);
                    }
                    ViewState.Add("sworkDates", sworkDates.ToArray());
                }
                else
                {
                    ViewState.Add("sworkDates", null);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["IntStDate"]))
                {
                    IntStDate = Request.QueryString["IntStDate"].ToString();
                    IntEdDate = Request.QueryString["IntEdDate"].ToString();
                    ViewState["IntStDate"] = IntStDate;
                    ViewState["IntEdDate"] = IntEdDate;
                }
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
                if (ViewState["sworkDates"] != null)
                {
                    wrkDates[] wrd = (wrkDates[])ViewState["sworkDates"];
                    if (wrd != null)
                    {
                        sworkDates = new List<wrkDates>();
                        for (int i = 0; i < wrd.GetLength(0); i++)
                        {
                            wrkDates wkk = new wrkDates();
                            wkk.wkStartDate = wrd[i].wkStartDate;
                            wkk.wkEndDate = wrd[i].wkEndDate;
                            wkk.bCurrentFlag = wrd[i].bCurrentFlag;
                            sworkDates.Add(wkk);
                        }
                    }
                    ViewState.Add("sworkDates", sworkDates.ToArray());

                }
                if (ViewState["rowId"] != null)
                {
                    rowId = Convert.ToInt32(ViewState["rowId"].ToString());
                }
                if (ViewState["CandidateID"] != null)
                    this.CandidateID = ViewState["CandidateID"].ToString();
            }

            String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
            String strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");

            this.basePage.Value = strUrl;
            Global.SetDefaultButtonOfTheForm(this.Form, BtnManageWorkExperience);
            Global.SetUICulture(this.Page);
            CompaniesBAL company = new CompaniesBAL();
            MySqlDataReader drCompany = company.GetCompanies("-1");
            while (drCompany.Read())
            {
                ListItem li = new ListItem(drCompany["company_code"].ToString(), drCompany["company_id"].ToString());
                li.Attributes.Add("ParentCompanyID", drCompany["parent_company_id"].ToString());
                DdlHiddenCompany.Items.Add(li);
            }
            drCompany.Close();
            drCompany.Dispose();
            DdlHiddenCompany.Items.Insert(0, new ListItem("Select", "-2"));
            DdlHiddenCompany.Items.Add(new ListItem("Not Available", "-3"));

            if (Request.QueryString["cand"] != null)
            {
                this.CandidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString();
                ViewState["CandidateID"] = this.CandidateID;

            }
            else
            {
                if (Request.QueryString["regid"] != null)
                {
                    CandidatesBAL cand = new CandidatesBAL();
                    string tCandId = cand.GetCandidateID(Request.QueryString["regid"]).ToString();
                    if (string.IsNullOrEmpty(tCandId))
                        this.CandidateID = "0";
                    else
                    {
                        double dCandId = Global.EncryptID(Convert.ToInt32(tCandId));
                        this.CandidateID = Global.DecryptID(dCandId).ToString();
                    }
                }
                else
                {
                    this.CandidateID = "0";
                }
                ViewState["RegID"] = Request.QueryString["regid"];
            }

            if (Request.QueryString["emp_proj"] != null)
            {
                this.EmploymentProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])).ToString();
            }
            else
            {
                this.EmploymentProjectID = "-2";
            }

            //added for show name and Rid in Got Job Popup
            if (Request.RawUrl.Contains("train_proj"))
            {
                TblCandidateDetail.Visible = true;
                TblGotJobDetail.Visible = true;
                this.Page.Title = "Got Job";
                CandidatesBAL candidate = new CandidatesBAL();
                MySqlDataReader drCandidate = candidate.GetCandidateDetails(this.CandidateID.ToString());
                if (drCandidate.Read())
                {
                    SpnCandidateName.InnerText = drCandidate["first_name"].ToString() + " " + drCandidate["middle_name"].ToString() + "  " + drCandidate["last_name"].ToString();
                    SpnCandidateRID.InnerText = drCandidate["registration_id"].ToString();
                }
                drCandidate.Close();
                drCandidate.Dispose();
                GetCandidateWorkExperience();
                if (LstViewExistingWorkExperience.Items.Count.Equals(0))
                {
                    SpnStatus.Visible = true;
                }
                else
                {
                    SpnStatus.Visible = false;
                }
            }

            if (!Page.IsPostBack)
            {
                string textboxId = string.Empty;
                if (Request.QueryString["txboxId"] != null)
                    textboxId = Request.QueryString["txboxId"].ToString().Replace("'", string.Empty);
                this.txtParent.Value = textboxId;
                
                //Gets parent companies
                EnableIndia.App_Code.BAL.ParentCompaniesBAL parentComp = new EnableIndia.App_Code.BAL.ParentCompaniesBAL();
                MySqlDataReader drParentCompanies = parentComp.GetParentCompanies();
                Global.FillDropDown(DdlParentCompanies, drParentCompanies, "company_name", "company_id");

                EnableIndia.App_Code.BAL.JobRolesBAL role = new EnableIndia.App_Code.BAL.JobRolesBAL();
                MySqlDataReader drRole = role.GetJobRoles("-1");
                Global.FillDropDown(DdlJobRoles, drRole, "job_role_name", "job_role_id");
                CandidateWorkExperienceBAL can = new CandidateWorkExperienceBAL();
                if (Request.QueryString["work_exp"] != null)
                {
                    GetWorkExperienceDetail();
                    BtnDeleteWorkExperience.Visible = true;
                }
                else
                {
                    CandidatesBAL cand = new CandidatesBAL();
                    MySqlDataReader drCandidateDetails = cand.GetCandidateDetails(Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString());
                    if (drCandidateDetails.Read())
                    {
                        if (drCandidateDetails["contract_expiry_date"].ToString().Contains("1900"))
                        {
                            TxtExpiryDate.Text = "";
                        }
                        else
                        {
                            TxtExpiryDate.Text = Convert.ToDateTime(drCandidateDetails["contract_expiry_date"]).ToString("dd/MM/yyyy");
                        }
                    }
                }
                Global.ShowMessageInAlert(this.Form);
               if(ViewState["bEmpFts"] != null)
                  bEmpFts = (bool)ViewState["bEmpFts"];
            }
            //added for employment project
            if (Request.RawUrl.Contains("emp_proj"))
            {
                RdbDesignationTo.Enabled = false;

              //  RdbDesignationTillCurrentDate.Enabled = false;
                //if (!bEmpFts)
                //{
                //    RdbDesignationTillCurrentDate.Checked = true;
                //    bEmpFts = true;
                //    ViewState["bEmpFts"] = bEmpFts;
                //}
                TblEmploymentProjectDetail.Visible = true;
                TblCandidateDetailForEmployment.Visible = true;
                TdSelectCompany.Visible = false;
                TdSelectRole.Visible = false;
                TdBlankUnlistedCompany.Visible = false;
                TdUnlistedCompany.Visible = false;
                TblEmploymentComany.Visible = true;
                LblCompany.Visible = false;
                TdDesignation.Visible = false;
                TblEmploymentDesignation.Visible = true;
                GetWorkExperienceDetailForEmploymentProject();
                TblParentCompanydetail.Attributes.Add("style", "margin-top:5px");
                TblRole.Attributes.Add("style", "margin-top:5px");

                EnableIndia.App_Code.BAL.EmploymentProjectBAL proj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
                MySqlDataReader drEmploymentProjectDetails = proj.GetEmploymentProjectDetails(this.EmploymentProjectID);
                if (drEmploymentProjectDetails.HasRows)
                {
                    drEmploymentProjectDetails.Read();
                    SpnEmploymentProjectName.InnerText = drEmploymentProjectDetails["employment_project_name"].ToString();
                    SpnCurrentDemand.InnerText = drEmploymentProjectDetails["current_demand_of_people"].ToString();
                }
                drEmploymentProjectDetails.Close();
                drEmploymentProjectDetails.Dispose();

                CandidatesBAL candidate = new CandidatesBAL();
                MySqlDataReader drCandidate = candidate.GetCandidateDetails(this.CandidateID.ToString());
                if (drCandidate.Read())
                {
                    SpnCandidateNameEmployment.InnerText = drCandidate["first_name"].ToString() + " " + drCandidate["middle_name"].ToString() + "  " + drCandidate["last_name"].ToString();
                    SpnCandidateRIDEmployment.InnerText = drCandidate["registration_id"].ToString();
                }
                drCandidate.Close();
                drCandidate.Dispose();
            }
            if (!Page.IsPostBack)
            {
                if (workingDates == null && this.LstViewExistingWorkExperience != null)
                {
                    int i = 0;
                    workingDates = new wkDates[this.LstViewExistingWorkExperience.Items.Count];
                    foreach (ListViewItem lv in this.LstViewExistingWorkExperience.Items)
                    {
                        System.Web.UI.HtmlControls.HtmlTableCell tf = (System.Web.UI.HtmlControls.HtmlTableCell)lv.FindControl("tdFromDate");
                        System.Web.UI.HtmlControls.HtmlTableCell tt = (System.Web.UI.HtmlControls.HtmlTableCell)lv.FindControl("tdToDate");
                        workingDates[i].wkStartDate = tf.InnerText;
                        if (tt.InnerText == "Current")
                        {
                            workingDates[i].wkEndDate = DateTime.Today.Month.ToString("00") + "/" + DateTime.Today.Year.ToString("0000");
                        }
                        else
                        {
                            workingDates[i].wkEndDate = tt.InnerText;
                        }
                        i++;
                    }
                    ViewState["workingDates"] = workingDates;
 
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
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }
            if (!Page.IsPostBack)
            {
                string enbRb = Request.QueryString["EnbRb"];
                if (!string.IsNullOrEmpty(enbRb))
                {
                    if (enbRb == "1")
                    {
                        this.RdbDesignationTillCurrentDate.Enabled = true;
                        this.RdbDesignationTillCurrentDate.Checked = false;
                        this.TxtDesignationTo.Enabled = true;
                        //                        disableRdbCurrentDate
                      //  ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "disablrb", "disableRdbCurrentDate();", true);

                    }

                }
            }

        }

        //added for to show listview in dropdown in Got Job Page
        private void GetCandidateWorkExperience()
        {
            CandidateWorkExperienceBAL candidate = new CandidateWorkExperienceBAL();
            LstViewExistingWorkExperience.DataSource = candidate.GetCandidateWorkExperience(this.CandidateID);
            LstViewExistingWorkExperience.DataBind();
        }

        private void GetWorkExperienceDetailForEmploymentProject()
        {
            EnableIndia.App_Code.BAL.EmploymentProjectBAL employment = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            string employmentProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])).ToString();
            MySqlDataReader drWorkExperienceEmployment = employment.GetEmploymentProjectDetails(employmentProjectID);

            if (drWorkExperienceEmployment.Read())
            {
                DdlSelectCompany.Visible = false;
                DdlParentCompanies.Value = drWorkExperienceEmployment["parent_company_id"].ToString();
                DdlParentCompanies.Attributes.Add("style", "display:none");
                DdlCompanies.Attributes.Add("style", "display:none");
                SpnHiddenCompanyID.InnerText = drWorkExperienceEmployment["company_id"].ToString();
                DdlHiddenCompany.Value = drWorkExperienceEmployment["company_id"].ToString();
                TxtUnlistedCompany.Visible = false;
                TxtDesignation.Visible = false;
                SpnSelectCompany.Visible = true;
                SpnParentCompnies.Visible = true;
                SpnCompanies.Visible = true;
                SpnJobRoles.Visible = true;
                SpnDesignation.Visible = true;
                SpnSelectCompany.InnerText = "Listed Company :";
                SpnParentCompnies.InnerText = " : " + DdlParentCompanies.Items.FindByValue(drWorkExperienceEmployment["parent_company_id"].ToString()).Text;
                SpnCompanies.InnerText = DdlHiddenCompany.Items.FindByValue(drWorkExperienceEmployment["company_id"].ToString()).Text;
                string te = drWorkExperienceEmployment["job_role_id"].ToString();
                if (drWorkExperienceEmployment["job_role_id"].ToString() != "0")
                {
                    TxtUnlistedRole.Visible = false;
                    DdlJobRoles.Visible = false;
                    DdlRoles.Visible = false;
                    SpnSelectRole.Visible = true;
                    SpnSelectRole.InnerText = "Listed Role :";
                    SpnJobRoles.InnerText = DdlJobRoles.Items.FindByValue(drWorkExperienceEmployment["job_role_id"].ToString()).Text;
                }
                else
                {
                    TdSelectRole.Visible = true;
                }
                SpnDesignation.InnerText = drWorkExperienceEmployment["designation"].ToString();
                drWorkExperienceEmployment.Close();
                drWorkExperienceEmployment.Dispose();
            }
        }

        private void GetWorkExperienceDetail()
        {
            CandidateWorkExperienceBAL exprienceDetail = new CandidateWorkExperienceBAL();
            string workexperienceID = Global.DecryptID(Convert.ToDouble(Request.QueryString["work_exp"])).ToString();
            MySqlDataReader drWorkExperience = exprienceDetail.GetCandidateWorkExperienceDetails(workexperienceID);

            if (drWorkExperience.Read())
            {
                DdlParentCompanies.Value = drWorkExperience["parent_company_id"].ToString();
                SpnHiddenCompanyID.InnerText = drWorkExperience["company_id"].ToString();
                TxtUnlistedCompany.Text = drWorkExperience["unlisted_company"].ToString();
                if (TxtUnlistedCompany.Text.Trim().Equals(""))
                {
                    DdlSelectCompany.Value = "1";
                }
                else
                {
                    DdlSelectCompany.Value = "2";
                }
                DdlJobRoles.Value = drWorkExperience["job_role_id"].ToString();
                TxtUnlistedRole.Text = drWorkExperience["unlisted_job_role"].ToString();
                if (TxtUnlistedRole.Text.Trim().Equals(""))
                {
                    DdlRoles.Value = "1";
                }
                else
                {
                    DdlRoles.Value = "2";
                }
                TxtDesignation.Text = drWorkExperience["designation"].ToString();
                TxtDesignationFrom.Text = Convert.ToDateTime(drWorkExperience["designation_from_date"]).ToString("MM/yyyy");
                if (drWorkExperience["designation_to_date"].ToString().Contains("5000"))
                {
                    RdbDesignationTillCurrentDate.Checked = true;
                }
                else
                {
                   // RdbDesignationTo.Checked = true;
                    if (string.IsNullOrEmpty(drWorkExperience["designation_to_date"].ToString()))
                        RdbDesignationTo.Checked = true;
                    else
                    {
                        TxtDesignationTo.Text = Convert.ToDateTime(drWorkExperience["designation_to_date"]).ToString("MM/yyyy");
                        RdbDesignationTillCurrentDate.Checked = false;
                        this.RdbDesignationTo.Checked = false;
                    }
                }
                if (drWorkExperience["monthly_salary"].ToString() == "0.00")
                {
                    TxtMonthlySalary.Text = "";
                }
                else
                {
                    TxtMonthlySalary.Text = Convert.ToInt32(drWorkExperience["monthly_salary"]).ToString();
                }
                if (drWorkExperience["years"].ToString().Contains("-"))
                {
                    SpnYear.InnerText = "0Y 0M";
                }
                else
                {
                    SpnYear.InnerText = drWorkExperience["years"].ToString();
                }
                if (drWorkExperience["contract_expiry_date"].ToString().Contains("1900"))
                {
                    TxtExpiryDate.Text = "";
                }
                else
                {
                    TxtExpiryDate.Text = Convert.ToDateTime(drWorkExperience["contract_expiry_date"]).ToString("dd/MM/yyyy");
                }
                BtnManageWorkExperience.Text = BtnManageWorkExperience.Text.Replace("Add", "Update");
                BtnManageWorkExperience.ToolTip = BtnManageWorkExperience.ToolTip.Replace("Add", "Update");
                if(!System.DBNull.Value.Equals(drWorkExperience["emp_proof_received"]))
                    if(drWorkExperience["emp_proof_received"].ToString() == "Y")
                        this.cbWep.Checked = true;
                drWorkExperience.Close();
                drWorkExperience.Dispose();
            }
        }

        protected void BtnPopulateParentCompanies_Click(object sender, EventArgs e)
        {
            CompaniesBAL comp = new CompaniesBAL();
            MySqlDataReader drCompanies = comp.GetCompanies(DdlParentCompanies.Value);
            Global.FillDropDown(DdlCompanies, drCompanies, "company_code", "company_id");
        }

        protected void BtnDeleteWorkExperience_Click(object sender, EventArgs e)
        {
            string errorMessage = String.Empty;
            CandidateWorkExperienceBAL work = new CandidateWorkExperienceBAL();
            bool isDeleted = work.DeleteWorkExperience(Global.DecryptID(Convert.ToDouble(Request.QueryString["work_exp"])).ToString(), this.CandidateID, out errorMessage);
            string script = String.Empty;

            if (isDeleted.Equals(true))
            {
                // script = "alert('Work experience deleted successfully.');self.close();";
               // ClientScript.RegisterStartupScript(this.GetType(), "__key", script, true);
                closePage("Work experience deleted successfully.", string.Empty);
            }
            else
            {
                script = "alert('" + Global.GetGlobalErrorMessage() + "');";
              //  ClientScript.RegisterStartupScript(this.GetType(), "__key", script, true);
                closePage("'" + Global.GetGlobalErrorMessage() + "'", string.Empty);
            }
           
        }

        protected void rdbDesgChanged(object sender, EventArgs e)
        {

         //   if (RdbDesignationTillCurrentDate.Checked)
         //   {
         //         this.TxtDesignationTo.Enabled = false;
         ////       this.tx
         //////                $("#TxtDesignationTo").attr('disabled',true);
         //////$("#TxtDesignationTo").removeAttr('class');
         //////$("#TblContractExpiryDate").show();
         ////////   $("#tryHidingMe").addClass("alwaysHide");
         //////$("#TblContractExpiryDate").addClass("jShow");
         ////   }
         //   else
         //   {
         //   }
            if (RdbDesignationTillCurrentDate.Checked)
            {
                this.TxtDesignationTo.Enabled = false;
            }
            else
            {
                this.TxtDesignationTo.Enabled = true;
            }

        }
        private bool CheckPartDate(string gDate)
        {
            if (gDate == "Current")
                return true;
            string[] dParts;
            try
            {
                dParts = gDate.Split((char)'/');
                if (dParts.Length != 2)
                    return false;
                if (Convert.ToInt32(dParts[0]) > 12 || Convert.ToInt32(dParts[0]) < 1)
                    return false;
                int iYear = Convert.ToInt32(dParts[1]);
                if (iYear < 1900 || iYear > 5000)
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }
        protected void BtnManageWorkExperience_Click(object sender, EventArgs e)
        {
            //  -- Check for mm/yyyy correctness.
            string message = string.Empty;
            if(this.TxtDesignationFrom.Text.Length != 7)
            {
                MsgBox("Designation From DATE format must always be MM/YYYY".ToString());
                return;
            }
            bool bCheck = false;
            string newValues = "";
  
            bCheck = CheckPartDate(this.TxtDesignationFrom.Text);
            if (!bCheck)
            {
                MsgBox("Wrong From Date");
                return;
            }
            if (!this.RdbDesignationTillCurrentDate.Checked)
            {

                if (this.TxtDesignationTo.Text.Length != 7)
                {
                    MsgBox("Designation To DATE format must always be MM/YYYY".ToString());
                    return;
                }
                bCheck = CheckPartDate(this.TxtDesignationTo.Text);
                if (!bCheck)
                {
                    MsgBox("Wrong To Date");
                    return;
                }
            }
            CandidateWorkExperienceBAL work = new CandidateWorkExperienceBAL();
            string pmessage = String.Empty;
            if (Request.QueryString["work_exp"] != null)
            {
                work.CandidateWorkExperienceID = Global.DecryptID(Convert.ToDouble(Request.QueryString["work_exp"]));
            }
            // ----------------------------------------------------------
            // Updated on 29.11.2013....
            // ----------------------------------------------------------
            if (string.IsNullOrEmpty(Request.QueryString["cand"]))
            {
                work.CandidateID = Convert.ToInt32(this.CandidateID);
            }
            else
            {
                work.CandidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"]));
            }
            if (!Request.RawUrl.Contains("emp_proj"))
            {
                if (DdlSelectCompany.Value.Equals("1"))
                {
                    work.ParentCompanyID = Convert.ToInt32(DdlParentCompanies.Value);
                    work.CompanyID = Convert.ToInt32(DdlHiddenCompany.Value);
                    work.UnlistedCompany = "";
                }
                else
                {
                    work.UnlistedCompany = TxtUnlistedCompany.Text.Trim();
                    work.ParentCompanyID = -1;
                    work.CompanyID = -1;
                }
                if (DdlRoles.Value.Equals("1"))
                {
                    work.JobRoleID = Convert.ToInt32(DdlJobRoles.Value);
                    work.UnlistedJobRole = "";
                }
                else
                {
                    work.UnlistedJobRole = TxtUnlistedRole.Text.Trim();
                    work.JobRoleID = -1;
                }
                work.Designation = TxtDesignation.Text.Trim();
                if (this.cbWep.Checked)
                    work.EmploymentProofFlag = "Y";
                else
                    work.EmploymentProofFlag = "N";
            }
            else
            {
                EnableIndia.App_Code.BAL.EmploymentProjectBAL employment = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
                string employmentProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])).ToString();
                MySqlDataReader drWorkExperienceEmployment = employment.GetEmploymentProjectDetails(employmentProjectID);

                if (drWorkExperienceEmployment.Read())
                {
                    work.ParentCompanyID = Convert.ToInt32(drWorkExperienceEmployment["parent_company_id"]);
                    work.CompanyID = Convert.ToInt32(drWorkExperienceEmployment["company_id"]);
                    work.UnlistedCompany = "";
                    if (drWorkExperienceEmployment["job_role_id"].ToString() != "0")
                    {
                        work.UnlistedJobRole = "";
                        work.JobRoleID = Convert.ToInt32(drWorkExperienceEmployment["job_role_id"]);
                    }
                    else
                    {
                        if (DdlRoles.Value.Equals("1"))
                        {
                            work.JobRoleID = Convert.ToInt32(DdlJobRoles.Value);
                            work.UnlistedJobRole = "";
                        }
                        else
                        {
                            work.UnlistedJobRole = TxtUnlistedRole.Text.Trim();
                            work.JobRoleID = -1;
                        }
                    }
                    work.Designation = SpnDesignation.InnerText;
                }
                drWorkExperienceEmployment.Close();
                drWorkExperienceEmployment.Dispose();
            }
            if (RdbDesignationTillCurrentDate.Checked == true)
            {
                work.DesignationToDate = "5000/01/01";
            }
            else
            {
                try
                {
                    work.DesignationToDate = Convert.ToDateTime(TxtDesignationTo.Text.Trim()).ToString("yyyy/MM/dd");
                }
                catch
                {
                    work.DesignationToDate = DateTime.Now.ToString("yyyy/MM/dd");
                }
            }

            try
            {
                work.DesignationFromDate = Convert.ToDateTime(TxtDesignationFrom.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                work.DesignationFromDate = DateTime.Now.ToString("yyyy/MM/dd");
            }

            try
            {
                work.MonthlySalary = Convert.ToDecimal(TxtMonthlySalary.Text.Trim());
            }
            catch
            {
                work.MonthlySalary = 0;
            }
            try
            {
                work.ContractExpiryDate = Convert.ToDateTime(TxtExpiryDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                work.ContractExpiryDate = "1900/01/01";
            }
            if (this.cbWep.Checked)
                work.EmploymentProofFlag = "Y";
            else
                work.EmploymentProofFlag = "N";
            // Check for the dates.....
            // -----------------------
            string stDate = "01/" + this.TxtDesignationFrom.Text;
            // Set the last date of the month...
            string edDate = ""; // this.TxtDesignationTo.Text;
            string edYear = ""; // this.TxtDesignationTo.Text.Substring(3, 4);

            // -------------------
            // Added on 19/092/014
            // -------------------

            string edd = ""; // edDate.Substring(0, 2);

            int idd =  01; //Convert.ToInt32(edd);
            int iyy = Convert.ToInt32(stDate.Substring(6, 4)); //Convert.ToInt32(edYear);
            idd = getMonthEndDate(idd, iyy);
            int i = 0;
            bool fDateComp = false;
            // Check for multiple currents
            i = 0;
            foreach(ListViewItem lv in this.LstViewExistingWorkExperience.Items)
            {
                System.Web.UI.HtmlControls.HtmlTableCell tf = (System.Web.UI.HtmlControls.HtmlTableCell)lv.FindControl("tdToDate");
                if (tf != null)
                {
                    if (!string.IsNullOrEmpty(tf.InnerText))
                    {
                        if (tf.InnerText == "Current") i++;
                    }
                }
            }
            if (i > 1)
            {
                MsgBox("Multiple currents");
              //  return;
            }
            i = 0;
            // first set starting and ending dates....
            DateTime dStDate = Convert.ToDateTime(stDate);
            if (this.RdbDesignationTillCurrentDate.Checked)
            {
                if (string.IsNullOrEmpty(this.TxtExpiryDate.Text))
                {
                    edDate = "31/12/2099";
                }
                else
                {
                    try
                    {
                        string[] expDates = this.TxtExpiryDate.Text.Split((char)'/');
                        edDate = expDates[1] + "/" + expDates[2];
                        edYear = expDates[2];
                        edd = edDate.Substring(0, 2);
                        idd = Convert.ToInt32(edd);
                        iyy = Convert.ToInt32(edYear);
                        idd = getMonthEndDate(idd, iyy);
                        edDate = idd.ToString() + "/" + edDate;
                    }
                    catch
                    {
                        edDate = "31/12/2099";
                    }
                }
            }
            else
            {
                edDate = this.TxtDesignationTo.Text;
                edYear = this.TxtDesignationTo.Text.Substring(3, 4);
                edd = edDate.Substring(0, 2);
                idd = Convert.ToInt32(edd);
                iyy = Convert.ToInt32(edYear);
                idd = getMonthEndDate(idd, iyy);
                edDate = idd.ToString() + "/" + edDate;
            }

            DateTime dEdDate = Convert.ToDateTime(edDate);
            int tResult = DateTime.Compare(dStDate, dEdDate);
            if(tResult >= 0)
            {
                MsgBox("Start date cannot be greater than or equal to End Date");
                return;
            }
            bool bCurrentFlag = false;
            wrkDates[] tsworkDates = null;
            if (sworkDates != null)
            {
                if (sworkDates.Count > 0)
                    tsworkDates = new wrkDates[sworkDates.Count];
            }
            if (tsworkDates != null)
            {
                // Need to check if these dates are alrady filled
                sworkDates.CopyTo(tsworkDates, 0);
                if (tsworkDates.GetLength(0) > 0)
                {
                    try
                    {
                        bool bOnlyMMyyyy = false;
                        string[] sDates = tsworkDates[0].wkStartDate.Split((char)' ');
                        if (sDates[0].Length == 7)
                            bOnlyMMyyyy = true;
                        for (i = 0; i < tsworkDates.GetLength(0); i++)
                        {
                            if (bOnlyMMyyyy)
                            {
                                tsworkDates[i].wkStartDate = "01/" + tsworkDates[i].wkStartDate;
                                idd = Convert.ToInt32(tsworkDates[i].wkEndDate.Substring(0, 2));
                                iyy = Convert.ToInt32(tsworkDates[i].wkEndDate.Substring(3, 4));
                                idd = getMonthEndDate(idd, iyy);
                                tsworkDates[i].wkEndDate = idd.ToString() + "/" + tsworkDates[i].wkEndDate;
                                ViewState["tsworkDates"] = tsworkDates;
                            }
                            else
                            {
                                tsworkDates[i].wkStartDate = tsworkDates[i].wkStartDate;
                                idd = Convert.ToInt32(tsworkDates[i].wkEndDate.Substring(3, 2));
                                iyy = Convert.ToInt32(tsworkDates[i].wkEndDate.Substring(6, 4));
                                idd = getMonthEndDate(idd, iyy);
                                tsworkDates[i].wkEndDate = tsworkDates[i].wkEndDate;
                                ViewState["tsworkDates"] = tsworkDates;
                            }



                        }
                    }
                    catch (System.Exception ex)
                    {
                        this.lbError.Text = "Error: " + ex.Message;
                    }
                }
                int j = 0;
                int rId = 0;
                rId = (this.BtnManageWorkExperience.Text == "Add")?-1: --rowId;   // Decrement rowid for skipping the specific row in case of update...
                if (this.BtnManageWorkExperience.Text == "Add")
                {
                    for (i = 0; i < tsworkDates.GetLength(0); i++)
                    {
                        DateTime wStDate = Convert.ToDateTime(tsworkDates[i].wkStartDate);
                        if ((tsworkDates[i].bCurrentFlag) && (this.RdbDesignationTillCurrentDate.Checked == true))
                        {
                            bCurrentFlag = true;
                            break;
                        }
                        DateTime wEdDate = Convert.ToDateTime(tsworkDates[i].wkEndDate);
                        // First check whether a start date falls in the date...
                        DateRange range = new DateRange(wStDate, wEdDate);
                        DateTime tStDate = dStDate;
                        for (tStDate = dStDate; tStDate <= dEdDate;)
                        {
                            if (range.Includes(tStDate))
                            {
                                fDateComp = true;
                                break;
                            }
                            tStDate = tStDate.AddMonths(1);

                        }
                    }
                }
                else
                {
                    IList<wrkDates> twk = new List<wrkDates>();
                    rId = (rId < 0) ? 0 : rId;
                    twk = tsworkDates.ToList();
                    twk.RemoveAt(rId);
                    tsworkDates = new wrkDates[twk.Count];
                    twk.CopyTo(tsworkDates, 0);
                    for (i = 0; i < tsworkDates.GetLength(0); i++)
                    {
                        if (i == 0) continue;
                        DateTime wStDate = Convert.ToDateTime(tsworkDates[i].wkStartDate);
                        if ((tsworkDates[i].bCurrentFlag) && (this.RdbDesignationTillCurrentDate.Checked == true))
                        {
                            bCurrentFlag = true;
                            break;
                        }
                        DateTime wEdDate = Convert.ToDateTime(tsworkDates[i].wkEndDate);
                        // First check whether a start date falls in the date...
                        DateRange range = new DateRange(wStDate, wEdDate);
                        DateTime tStDate = dStDate;
                        for (tStDate = dStDate; tStDate <= dEdDate;)
                        {
                            if (range.Includes(tStDate))
                            {
                                fDateComp = true;
                                break;
                            }
                            tStDate = tStDate.AddMonths(1);

                        }
                    }
                    
                }
                if (bCurrentFlag)
                {
                    MsgBox("Multiple currents not allowed");
               //     return;
                    pmessage = "Multiple currents ";
                }
                if (fDateComp)
                {
                    MsgBox("Work experience falls In-between");
                    pmessage = "Work experiece inbetween";
                //    return;
                }
            }
            
            Type type = work.GetType();
            PropertyInfo[] proterties = type.GetProperties();
            foreach (var p in proterties)
            {
                newValues += "<b>" + p.Name + ": </b>" + p.GetValue(work, null) + ", ";

            }
            if (!string.IsNullOrEmpty(newValues))
            {
                int l = newValues.LastIndexOf((char)',');
                if (l > 0)
                    newValues = newValues.Substring(0, l);
            }

            if (Request.QueryString["work_exp"] == null)
            {
                try
                {
                    int rowAdded = work.AddCandidateWorkExperience(work);
                    if (Request.RawUrl.Contains("emp_proj"))
                    {
                        try
                        {

                            MySqlConnection conn = Global.GetConnectionString();
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand("", conn);
                            cmd.CommandText = "update candidate_work_experience set is_entered_from_employment_project=1 ";
                            cmd.CommandText += "where candidate_work_experience_id=" + rowAdded;
                            cmd.ExecuteNonQuery();

                            cmd = new MySqlCommand("", conn);
                            cmd.CommandText = "update candidates_assigned_to_employment_project set got_job_details_entered=1 ";
                            cmd.CommandText += "where candidate_id=" + this.CandidateID + " and employment_project_id=" + this.EmploymentProjectID;

                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch (System.Exception ex)
                        {
                            MsgBox("Error Update 1: " + ex.Message);
                        }
                    }
                    if (rowAdded > 0)
                    {
                        Global.createAuditTrial(this.Title, newValues, "", null, "Insert", Session["username"].ToString());
                        message = "Work experience added successfully.";
                        MsgBox(message);
                        // Global.RedirectAfterSubmit(message, BtnManageWorkExperience.ID);
                    }
                    else
                    {

                        message = "Error occurred. Please contact the administrator.";
                        MsgBox(message);
                        // Global.RedirectAfterSubmit(message, BtnManageWorkExperience.ID);
                    }
                }
                catch (System.Exception ex)
                {
                    MsgBox("Error 1: " + ex.Message);
                }

            }
            else
            {
                try
                {
                    string errorMessage = String.Empty;
                    bool rowUpdated = work.UpdateCandidateWorkExperience(work, out errorMessage);
                    if (rowUpdated.Equals(true))
                    {
                        Global.createAuditTrial(this.Title, newValues, oldValues, null, "Update", Session["username"].ToString());
                        message = "Work experience updated successfully.";
                        MsgBox(message);
                        // Global.RedirectAfterSubmit(message, BtnManageWorkExperience.ID);
                    }
                    else
                    {
                        Global.createAuditTrial(this.Title, newValues, "", null, "Insert", Session["username"].ToString());
                        message = "Error occurred. Please contact the administrator.";
                        MsgBox(message);
                        // Global.RedirectAfterSubmit(message, BtnManageWorkExperience.ID);
                    }
                }
                catch (System.Exception ex)
                {
                    MsgBox("Error 2: " + ex.Message);
                }
            }
            closePage(message, pmessage);
        }
        private void closePage(string message, string pmessage)
        {
            string url = "";
            if (!string.IsNullOrEmpty(IntStDate))
            {
                if (!this.txtParent.Value.Contains("IntStDate"))
                {
                    this.txtParent.Value += "&IntStDate=" + IntStDate + "&IntEdDate=" + IntEdDate;
                }
            }
            if (string.IsNullOrEmpty(message))
            {
                url = "self.close();self.parent.location.replace('" + this.txtParent.Value + "')";
            }
            else
            {
                url = "window.alert('" + message + " " + pmessage  + "');self.close();self.parent.location.replace('" + this.txtParent.Value + "');";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", url, true);
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
             //Response.Write("<script language='javascript'> { self.close(); return false;}</script>");
              // ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "self.close();", true);           
            closePage("".ToString(), string.Empty);
        }
        private void MsgBox(string message)
        {
            webMessageBox wb = new webMessageBox();
            wb.Show(message);
        }
        protected void ddCompanyChanged(object sender, EventArgs e)
        {
            ddSelCompanyIndex = this.DdlCompanies.SelectedIndex;
            ViewState["ddSelCompanyIndex"] = ddSelCompanyIndex;
        }
        private int getMonthEndDate(int month, int year)
        {
            int idd = 0;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    idd = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    idd = 30;
                    break;
                case 2:
                    idd = (year / 4 == 0) ? 29 : 28;
                    break;
            }
            return idd;
        }
        public interface IRange<T>
        {
            T Start { get; }
            T End { get; }
            bool Includes(T value);
            bool Includes(IRange<T> range);
        }

        public class DateRange : IRange<DateTime>
        {
            public DateRange(DateTime start, DateTime end)
            {
                Start = start;
                End = end;
            }

            public DateTime Start { get; private set; }
            public DateTime End { get; private set; }

            public bool Includes(DateTime value)
            {
                return (Start <= value) && (value <= End);
            }

            public bool Includes(IRange<DateTime> range)
            {
                return (Start <= range.Start) && (range.End <= End);
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
            oldValues = "";
            string st = "";
            var textBoxes = this.Controls.FindAll().OfType<TextBox>();
            foreach (var t in textBoxes)
            {
                oldValues += "<b>" + t.ID + ": </b>" + t.Text + ", ";
            }
            var dropDowns = this.Controls.FindAll().OfType<DropDownList>();
            foreach (var d in dropDowns)
            {
                if (d.Items.Count == 0)
                    st = "Null";
                else
                    st = d.SelectedItem.Text;
                oldValues += "<b>" + d.ID + ": </b>" + st + ", ";
            }
            var selects = this.Controls.FindAll().OfType<HtmlSelect>();
            foreach (var s in selects)
            {
                oldValues += "<b>" + s.ID + ":  </b>" + s.Value + ", ";
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
        public void RemoveAt<T>(ref T[] arr, int index)
        {
            for (int a = index; a < arr.Length - 1; a++)
            {
                // moving elements downwards, to fill the gap at [index]
                arr[a] = arr[a + 1];
            }
            // finally, let's decrement Array's size by one
            Array.Resize(ref arr, arr.Length - 1);
        }
        protected void rbCheckedChanged(object sender, EventArgs e)
        {
            
            if(this.RdbDesignationTillCurrentDate.Checked == true)
            {
                this.TxtDesignationTo.Enabled = false;
            }
            else
            {
                this.TxtDesignationTo.Enabled = true;

            }
        }
    }
}
