using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using Telerik;
using Telerik.Web;
using Telerik.Web.UI;
using System.Text;
using System.IO;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;
using System.Xml;
using System.Reflection;


namespace EnableIndia.Company
{
    public partial class AssignedList : System.Web.UI.Page
    {
        public string EmploymentProjectID
        {
            get;
            set;
        }

        public string CompanyID
        {
            get;
            set;
        }

        public string IntStDate
        {
            get;
            set;
        }

        public string IntEdDate
        {
            get;
            set;
        }
        public string oldValues;

        [Serializable]
        public class wkDates
        {
            public string stDate { get; set; }
            public string edDate { get; set; }
            public bool bCurrentFlag { get; set; }
        }
        [Serializable]
        public struct candDates
        {
            public string candId;
            public wkDates[] wkd;
        }
        public candDates[] cnds;

        public StringWriter sw = new StringWriter();
        public IList<wkDates> workDates = new List<wkDates>();

        string[,] workingDates;
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.AuthenticateUser();
            Global.SetDefaultButtonOfTheForm(this.Form, BtnSubmit);
            DdlCandidateCallingStep.Focus();
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }

            if (!string.IsNullOrEmpty(Request.QueryString["emp_proj"]))
            {
                this.EmploymentProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])).ToString();
                if (Request.QueryString["emp_proj"].ToString() == "0")
                {
                    TblBlankMessage.Visible = true;
                    TblEmploymentProjectFrNoData.Visible = false;
                }
            }
            else
            {
                this.EmploymentProjectID = "-2";
            }

            if (!string.IsNullOrEmpty(Request.QueryString["comp"]))
            {
                this.CompanyID = Global.DecryptID(Convert.ToDouble(Request.QueryString["comp"])).ToString();
            }
            else
            {
                this.CompanyID = "-2";
            }

            EnableIndia.App_Code.BAL.EmploymentProjectBAL proj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            MySqlDataReader drEmploymentProjectDetails = proj.GetEmploymentProjectDetails(this.EmploymentProjectID);
            if (drEmploymentProjectDetails.HasRows)
            {
                drEmploymentProjectDetails.Read();
                SpnEmploymentProjectName.InnerText = drEmploymentProjectDetails["employment_project_name"].ToString();
                SpnCurrentDemand.InnerText = drEmploymentProjectDetails["current_demand_of_people"].ToString();

                if (drEmploymentProjectDetails["cand_completed_count"].ToString() == "0")
                {
                    BtnCloseTrainingProject.Visible = false;
                }
                else if (drEmploymentProjectDetails["cand_completed_count"].Equals(drEmploymentProjectDetails["cand_assign_count"]))
                {
                    BtnCloseTrainingProject.Visible = true;
                }
                if (drEmploymentProjectDetails["is_closed"].ToString().Equals("1"))
                {
                    BtnCloseTrainingProject.Visible = false;
                }
            }

            drEmploymentProjectDetails.Close();
            drEmploymentProjectDetails.Dispose();
            if (!Page.IsPostBack)
            {
                string st1 = string.IsNullOrEmpty(Request.QueryString["comp"]) ? "" : "?comp=" + Global.DecryptID(Convert.ToDouble(Request.QueryString["comp"].ToString()));
                string st2 = string.IsNullOrEmpty(Request.QueryString["emp_proj"]) ? "" : "?emp_proj=" + Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"].ToString()));

                //LnkBtnCompanyDetails.HRef += "?comp=" + Request.QueryString["comp"].ToString();
                //LnkBtnEmploymentProjectDetails.HRef += "?emp_proj=" + Request.QueryString["emp_proj"].ToString();

                //LnkBtnAddRecommendedCandidates.PostBackUrl += "?emp_proj=" + Request.QueryString["emp_proj"].ToString() + "&comp=" + Request.QueryString["comp"].ToString();
                //LnkBtnAddNonRecommendedCandidates.PostBackUrl += "?emp_proj=" + Request.QueryString["emp_proj"].ToString() + "&comp=" + Request.QueryString["comp"].ToString();

                //LnkBtnCompanyDetails.HRef += st1;
                // LnkEmploymentProjectDetails.HRef += st2;

                // LnkBtnAddRecommendedCandidates.PostBackUrl += (st2 + st1);
                // LnkBtnAddNonRecommendedCandidates.PostBackUrl += (st2 + st1);


                Global.ShowMessageInAlert(this.Form);
                Request.Cookies["grid_page_number"].Value = "1";
                GetCandidatesAssignedToEmploymentProject();
                if (!string.IsNullOrEmpty(Request.QueryString["IntStDate"]))
                {
                    IntStDate = Request.QueryString["IntStDate"].ToString();
                    IntEdDate = Request.QueryString["IntEdDate"].ToString();
                    ViewState["IntStDate"] = IntStDate;
                    ViewState["IntEdDate"] = IntEdDate;
                    this.hIntStDate.Value = IntStDate;
                    this.hIntEdDate.Value = IntEdDate;
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
                if (ViewState["cnds"] != null)
                {

                    cnds = (candDates[])ViewState["cnds"];
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
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }
            if (!Page.IsPostBack)
            {
                storeWorkExperience();
            }
        }
        protected void Page_LoadComplete()
        {
            try
            {
                if (Session["event_controle"] != null)
                {
                    ImageButton controle = (ImageButton)Session["event_controle"];
                    ScriptManager.GetCurrent(this.Page).SetFocus(controle);
                    cSetFocus(controle);

                }
            }
            catch (InvalidCastException inEx)
            {
            }

        }

 
        private void storeWorkExperience()
        {
            cnds = new candDates[this.LstViewAssignedList.Items.Count];
            int i = 0;
            foreach (ListViewItem item in this.LstViewAssignedList.Items)
            {
                if (item.ItemType == ListViewItemType.DataItem)
                {
                    CheckBox cb = (CheckBox)item.FindControl("ChkSelectCandidate");
                    if (cb != null)
                    {
                        cnds[i].candId = cb.Attributes["CandidateID"].ToString();
                        i++;
                    }

                }
            }
            if (cnds != null)
            {
                for (i = 0; i < cnds.GetLength(0); i++)
                {
                    CandidateWorkExperienceBAL candidate = new CandidateWorkExperienceBAL();
                    DataTable dt = candidate.GetCandidateWorkExperience(Global.DecryptID(Convert.ToDouble(cnds[i].candId)).ToString());
                    cnds[i].wkd = new wkDates[dt.Rows.Count];

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        cnds[i].wkd[j] = new wkDates();
                        cnds[i].wkd[j].stDate = dt.Rows[j][8].ToString();
                        cnds[i].wkd[j].edDate = dt.Rows[j][9].ToString();
                    }
                }
                ViewState["cnds"] = cnds;
            }
        }
        private void populateWorkingDates(int iRow)
        {
            int i = 0;
            string stDate = "";
            string edDate = "";
            if (cnds[iRow].wkd != null)
            {
                if (cnds[iRow].wkd.GetLength(0) > 0)
                {
                    workingDates = new string[cnds[iRow].wkd.GetLength(0), 2];
                    XmlDocument xDoc = new XmlDocument();
                    sw = new StringWriter();
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(sw);
                    xmlTextWriter.WriteStartDocument();
                    xmlTextWriter.WriteStartElement("WorkingDates");
                    //(2) string.Empty makes cleaner code
                    i = 0;
                    for (i = 0; i < cnds[iRow].wkd.GetLength(0); i++)
                    {
                        xmlTextWriter.WriteStartElement("WorkDate");
                        stDate = cnds[iRow].wkd[i].stDate;
                        xmlTextWriter.WriteElementString("StartDate", stDate);
                        edDate = cnds[iRow].wkd[i].edDate;
                        if (edDate == "Current")
                        {
                            workingDates[i, 1] = DateTime.Today.Month.ToString("00") + "/" + DateTime.Today.Year.ToString("0000");
                            xmlTextWriter.WriteElementString("EndDate", DateTime.Today.Month.ToString("00") + "/" + DateTime.Today.Year.ToString("0000"));
                            xmlTextWriter.WriteElementString("Current", "Current");
                        }
                        else
                        {
                            workingDates[i, 1] = edDate;
                            xmlTextWriter.WriteElementString("EndDate", edDate);
                            xmlTextWriter.WriteElementString("Current", "");
                        }
                        xmlTextWriter.WriteEndElement();
                    }
                    xmlTextWriter.WriteEndElement();
                    xmlTextWriter.WriteEndDocument();
                    HttpContext.Current.Session.Add("workDates", sw.ToString());
                }
            }
            else
            {
                XmlDocument xDoc = new XmlDocument();
                sw = new StringWriter();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(sw);
                xmlTextWriter.WriteStartDocument();
                xmlTextWriter.WriteStartElement("WorkingDates");
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteEndDocument();
                HttpContext.Current.Session.Add("workDates", sw.ToString());
                xDoc.LoadXml(sw.ToString());
            }
            Session["workingDates"] = workingDates;

        }

        private void GetCandidatesAssignedToEmploymentProject()
        {
            EnableIndia.App_Code.BAL.EmploymentProjectBAL proj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            LstViewAssignedList.DataSource = proj.GetCandidatesAssignedToEmploymentProjects(this.EmploymentProjectID, 25);
            LstViewAssignedList.DataBind();
            if (LstViewAssignedList.Items.Count.Equals(0))
            {
                BtnSubmit.Visible = false;
                BtnResetCandidate.Visible = false;
                TblCloseParticularStep.Visible = false;
                TblCandidateCaliingFromStep.Visible = false;
                TblTextAssignlistCandidate.Visible = false;
                HttpContext.Current.Request.Cookies["grid_page_number"].Value = (Convert.ToInt32(HttpContext.Current.Request.Cookies["grid_page_number"].Value) - 1).ToString();
                if (!HttpContext.Current.Request.Cookies["grid_page_number"].Value.Equals("0"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "PageClick(" + HttpContext.Current.Request.Cookies["grid_page_number"].Value + ");", true);
                }
            }
            else
            {
                BtnSubmit.Visible = true;
                BtnResetCandidate.Visible = true;
                TblCloseParticularStep.Visible = true;
                TblCandidateCaliingFromStep.Visible = true;
                TblTextAssignlistCandidate.Visible = true;
            }
        }

        protected void BtnSearchCandidates_Click(object sender, EventArgs e)
        {
            Request.Cookies["grid_page_number"].Value = HttpContext.Current.Request.Cookies["grid_page_number"].Value;
            GetCandidatesAssignedToEmploymentProject();
        }

        protected void LstViewAssignedList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                CheckBox ChkSelectCandidate = (CheckBox)e.Item.FindControl("ChkSelectCandidate");
                HtmlGenericControl LblCandidateName = (HtmlGenericControl)e.Item.FindControl("LblCandidateName");

                ImageButton BtnGotJob = (ImageButton)e.Item.FindControl("BtnGotJob");
                ImageButton BtnNotes = (ImageButton)e.Item.FindControl("BtnNotes");

                LblCandidateName.Attributes.Add("for", ChkSelectCandidate.ClientID);

                HtmlGenericControl SpnIsFreeze = (HtmlGenericControl)e.Item.FindControl("SpnIsFreeze");

                if (SpnIsFreeze.InnerText.Contains("1"))
                {
                    ChkSelectCandidate.Visible = false;
                    BtnGotJob.Visible = false;
                    BtnNotes.Visible = false;
                }
                HtmlSelect DdlWorkPlaceSolutionDone = (HtmlSelect)e.Item.FindControl("DdlWorkPlaceSolutionDone");
                ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(ChkSelectCandidate);
                //  ScriptManager.GetCurrent(this).RegisterPostBackControl(cb);
            }
        }

        protected void BtnCloseTrainingProject_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand("", conn, trans);
            cmd.CommandText = "";
            try
            {
                EnableIndia.App_Code.BAL.EmploymentProjectBAL empProj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
                DataTable dtAssignedCandidates = empProj.GetCandidatesAssignedToEmploymentProjects(this.EmploymentProjectID, 25);

                cmd.CommandText = "update employment_projects set is_closed=1 where employment_project_id=" + this.EmploymentProjectID;
                cmd.ExecuteNonQuery();
                foreach (DataRow dr in dtAssignedCandidates.Rows)
                {
                    int candidateID = Convert.ToInt32(dr["candidate_id"]);
                    cmd.CommandText = string.Format("CALL update_candidate_other_details({0})", candidateID);
                    cmd.ExecuteNonQuery();
                }

                string url = "~/Company/ListOfOpenEmploymentProject.aspx?msg=" + Global.EncryptQueryString("Employment project closed successfully.");
                url += "&foc=" + Global.EncryptQueryString("null");
                Response.Redirect(url, false);
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        private bool ValiDateCheckBoxes()
        {
            bool bChecked = false;
            try
            {
                foreach (ListViewItem item in this.LstViewAssignedList.Items)
                {
                    CheckBox cb = (CheckBox)item.FindControl("ChkSelectCandidate");
                    if (cb != null)
                    {
                        if (cb.Checked)
                        {
                            bChecked = true;
                            break;
                        }
                    }
                }
            }
            catch
            {
                ; ;
            }
            return (bChecked);
        }
        private bool ValidateValues()
        {
            bool bValidated = false;
            int checkedCount = 0;
            int selCount = 0;
            foreach (ListViewItem item in this.LstViewAssignedList.Items)
            {
                CheckBox cb = (CheckBox)item.FindControl("ChkSelectCandidate");
                if (cb.Checked)
                {
                    checkedCount++;
                    HtmlSelect ht = (HtmlSelect)item.FindControl("DdlPreparedForInterview");
                    if (ht.SelectedIndex == 1) selCount++;
                }
            }
            if (checkedCount == selCount)
                return (true);
            else
                return (false);
        }
        private void MsgBox(string message)
        {
            webMessageBox wb = new webMessageBox();
            wb.Show(message);
        }
        protected void BtnSubmit_click(object sender, EventArgs e)
        {
            bool bValiDateCheckBoxes = ValiDateCheckBoxes();
            if (!bValiDateCheckBoxes)
            {
                MsgBox("At least one checkbox should be clicked");
                return;
            }
            //bool bValidateValues = ValidateValues();
            //if (!bValidateValues)
            //{
            //    MsgBox("Candidate prepared for interview not set");
            //    return;
            //}
            bool[] cbArray = new bool[this.LstViewAssignedList.Items.Count];
            string message = String.Empty;
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand("", conn, trans);
            int deletedCandidates = 0;
            int i = 0;
            bool bChangesDone = false;
            EnableIndia.App_Code.BAL.EmploymentProjectBAL employee = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            try
            {
                foreach (ListViewDataItem item in LstViewAssignedList.Items)
                {
                    CheckBox ChkSelectCandidate = (CheckBox)item.FindControl("ChkSelectCandidate");
                    cbArray[i] = false;
                    if (ChkSelectCandidate.Checked)
                    {
                        bChangesDone = true;
                        cbArray[i] = true; i++;
                        cmd = new MySqlCommand("", conn, trans);
                        int candidateID = Global.DecryptID(Convert.ToDouble(ChkSelectCandidate.Attributes["CandidateID"]));

                        HtmlSelect DdlInterestedInJob = (HtmlSelect)item.FindControl("DdlInterestedInJob");
                        HtmlSelect DdlCretificatesVerified = (HtmlSelect)item.FindControl("DdlCretificatesVerified");
                        HtmlSelect DdlProfileSent = (HtmlSelect)item.FindControl("DdlProfileSent");
                        HtmlSelect DdlInterviewScheduled = (HtmlSelect)item.FindControl("DdlInterviewScheduled");
                        HtmlSelect DdlConfirmedForInterview = (HtmlSelect)item.FindControl("DdlConfirmedForInterview");
                        HtmlSelect DdlPreparedForInterview = (HtmlSelect)item.FindControl("DdlPreparedForInterview");
                        HtmlSelect DdlInterviewSupportRequired = (HtmlSelect)item.FindControl("DdlInterviewSupportRequired");
                        HtmlSelect DdlInterviewProcessCompleted = (HtmlSelect)item.FindControl("DdlInterviewProcessCompleted");
                        HtmlSelect DdlGotJob = (HtmlSelect)item.FindControl("DdlGotJob");
                        HtmlSelect DdlAcceptedJob = (HtmlSelect)item.FindControl("DdlAcceptedJob");
                        HtmlSelect DdlOfferLetterReceived = (HtmlSelect)item.FindControl("DdlOfferLetterReceived");
                        HtmlSelect DdlEmploymentProofReceived = (HtmlSelect)item.FindControl("DdlEmploymentProofReceived");
                        HtmlSelect DdlWorkPlaceSolutionDone = (HtmlSelect)item.FindControl("DdlWorkPlaceSolutionDone");

                        employee.EmploymentProjectID = Convert.ToInt32(this.EmploymentProjectID);
                        employee.CandidateID = Convert.ToInt32(candidateID);
                        employee.InterestedInJob = Convert.ToInt32(DdlInterestedInJob.Value);
                        employee.CertificatesVerified = Convert.ToInt32(DdlCretificatesVerified.Value);
                        employee.ProfileSent = Convert.ToInt32(DdlProfileSent.Value);
                        employee.InterviewScheduled = Convert.ToInt32(DdlInterviewScheduled.Value);
                        employee.ConfirmedForInterview = Convert.ToInt32(DdlConfirmedForInterview.Value);
                        employee.PreparedForInterview = Convert.ToInt32(DdlPreparedForInterview.Value);
                        employee.InterviewSupportRequired = Convert.ToInt32(DdlInterviewSupportRequired.Value);
                        employee.InterviewProcessCompleted = Convert.ToInt32(DdlInterviewProcessCompleted.Value);
                        employee.GotJob = Convert.ToInt32(DdlGotJob.Value);
                        employee.CandidateInformedAcceptedJob = Convert.ToInt32(DdlAcceptedJob.Value);
                        employee.OfferLetterReceived = Convert.ToInt32(DdlOfferLetterReceived.Value);
                        employee.EmploymentProofReceived = Convert.ToInt32(DdlEmploymentProofReceived.Value);
                        employee.WorkPlaceSolutionToBeDone = Convert.ToInt32(DdlWorkPlaceSolutionDone.Value);

                        if (employee.GotJob == 0 || employee.InterestedInJob == 0 || employee.CandidateInformedAcceptedJob == 0)
                        {
                            employee.UpdateCandidateAssignedList(cmd, employee);

                            cmd = new MySqlCommand("", conn, trans);
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "update candidates_assigned_to_employment_project set is_candidate_deleted=1 where candidate_id=" + candidateID;
                            cmd.CommandText += " and employment_project_id=" + this.EmploymentProjectID;
                            cmd.ExecuteNonQuery();
                            deletedCandidates++;
                        }
                        else
                        {
                            if (employee.WorkPlaceSolutionToBeDone == 1)
                            {
                                CompaniesBAL company = new CompaniesBAL();
                                company.HistoryDate = DateTime.Now.ToString("yyyy/MM/dd");

                                if (!string.IsNullOrEmpty(Request.QueryString["comp_hist"]))
                                {
                                    company.CompanyID = Convert.ToInt32(this.CompanyID);
                                    MySqlDataReader drCompany = company.GetcompanyDetails(this.CompanyID.ToString());
                                    if (drCompany.Read())
                                    {
                                        company.ParentCompanyID = Convert.ToInt32(drCompany["parent_company_id"]);
                                    }
                                    drCompany.Close();
                                    drCompany.Dispose();
                                }

                                company.Details = "";
                                company.CandidateID = candidateID;
                                company.CandidateFlagID = company.GetIDOfWorkplacesolution();
                                company.EmployemntProjectID = Convert.ToInt32(this.EmploymentProjectID);
                                MySqlDataReader drTaskdetail = company.GetCandidateNameRidForAddTask(company);
                                if (drTaskdetail.Read())
                                {
                                    company.Details = drTaskdetail["candidate_name"].ToString() + ", ";
                                    company.Details += drTaskdetail["RID"].ToString() + ", ";
                                    company.Details += drTaskdetail["employment_project_name"].ToString() + ", ";
                                    company.Details += drTaskdetail["disability_type"].ToString() + " ";
                                }
                                drTaskdetail.Close();
                                drTaskdetail.Dispose();

                                company.IsHistory = 0;
                                company.RecommendedAction = "";
                                company.FollowUpDate = "1900/01/01";
                                company.Status = "Open";

                                if (!string.IsNullOrEmpty(Request.QueryString["comp_hist"]))
                                {
                                    bool rowsUpdated = company.UpdateCompanyHistory(company);

                                    if (rowsUpdated.Equals(true))
                                    {
                                        //  Global.RedirectAfterSubmit("Company History Updated Successfully.", BtnAddUpdateCompanyHistory.ID);
                                    }
                                }
                                else
                                {
                                    int isTask = company.CheckForDuplicationTask(company);
                                    if (isTask == 0)
                                    {
                                        bool rowsAdded = company.AddCompanyHistory(company);
                                        if (rowsAdded.Equals(true))
                                        {

                                        }
                                    }
                                }
                            }
                            employee.UpdateCandidateAssignedList(cmd, employee);
                           
                        }

                        /* Update candidate other details */
                        cmd = new MySqlCommand("", conn, trans);
                        cmd.CommandText += " CALL update_candidate_other_details(" + candidateID + "); ";
                        cmd.ExecuteNonQuery();

                    }
  
                }
                message = "Assigned list updated successfully.";

                cmd = new MySqlCommand("", conn, trans);
                cmd.CommandType = CommandType.Text;
                employee.UpdateEmploymentProjectStatus(cmd, Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])));
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
            }
            finally
            {
                if (deletedCandidates == 1)
                {
                    message = deletedCandidates.ToString() + " candidate being deassigned from the list.";
                }
                else if (deletedCandidates > 1)
                {
                    message = deletedCandidates.ToString() + " candidates being deassigned from the list.";
                }
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
                if (bChangesDone)
                {
                    Type t = typeof(Button);
                    object[] p = new object[1];
                    p[0] = EventArgs.Empty;
                    MethodInfo m = t.GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance);
                    // m.Invoke(btnButtonYouWantedToSimulate, p);
                    if (m != null)
                        m.Invoke(this.BtnSearchCandidates, p);

                }


                //BtnSearchCandidates_Click(BtnSearchCandidates, new EventArgs());
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "__maessage", "alert(\"" + message + "\");$('#DdlEditParticularStepFrom').attr('selectedIndex',0);", true);
                //ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), " $('#DdlEditParticularStepFrom').attr('selectedIndex',0);", true);
            }
            setCheckBoxes(cbArray); // introduced due to postback
            //if (!string.IsNullOrEmpty(message))
            //{
            //    webMessageBox wb = new webMessageBox();
            //    wb.Show(message);
            //}
        }
        private void setCheckBoxes(bool[] cbs)
        {
            int i = 0;
            foreach (ListViewDataItem item in LstViewAssignedList.Items)
            {
                CheckBox ChkSelectCandidate = (CheckBox)item.FindControl("ChkSelectCandidate");
                if(cbs[i])
                {
                    ChkSelectCandidate.Checked = true;
                }
                i++;
            }

        }
        private void setSelectValues()
        {
            int iStopNumber = 0;
            foreach (ListViewItem item in this.LstViewAssignedList.Items)
            {
                iStopNumber = 0;
                CheckBox cb = (CheckBox)item.FindControl("ChkSelectCandidate");
                if (cb.Checked)
                {
                    HtmlSelect DdlInterestedInJob = (HtmlSelect)item.FindControl("DdlInterestedInJob");
                    HtmlSelect DdlCretificatesVerified = (HtmlSelect)item.FindControl("DdlCretificatesVerified");
                    HtmlSelect DdlProfileSent = (HtmlSelect)item.FindControl("DdlProfileSent");
                    HtmlSelect DdlInterviewScheduled = (HtmlSelect)item.FindControl("DdlInterviewScheduled");
                    HtmlSelect DdlConfirmedForInterview = (HtmlSelect)item.FindControl("DdlConfirmedForInterview");
                    HtmlSelect DdlPreparedForInterview = (HtmlSelect)item.FindControl("DdlPreparedForInterview");
                    HtmlSelect DdlInterviewSupportRequired = (HtmlSelect)item.FindControl("DdlInterviewSupportRequired");
                    HtmlSelect DdlInterviewProcessCompleted = (HtmlSelect)item.FindControl("DdlInterviewProcessCompleted");
                    HtmlSelect DdlGotJob = (HtmlSelect)item.FindControl("DdlGotJob");
                    HtmlSelect DdlAcceptedJob = (HtmlSelect)item.FindControl("DdlAcceptedJob");
                    HtmlSelect DdlOfferLetterReceived = (HtmlSelect)item.FindControl("DdlOfferLetterReceived");
                    HtmlSelect DdlEmploymentProofReceived = (HtmlSelect)item.FindControl("DdlEmploymentProofReceived");
                    HtmlSelect DdlWorkPlaceSolutionDone = (HtmlSelect)item.FindControl("DdlWorkPlaceSolutionDone");
                    
                }
            }
        }
        protected void BtnDeleteCandidate_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand("", conn, trans);
            EnableIndia.App_Code.BAL.EmploymentProjectBAL proj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            try
            {
                foreach (ListViewItem item in LstViewAssignedList.Items)
                {
                    CheckBox ChkSelectCandidate = (CheckBox)item.FindControl("ChkSelectCandidate");
                    if (ChkSelectCandidate.Checked)
                    {
                        cmd = new MySqlCommand("", conn, trans);
                        string empProjectGroupID = Global.DecryptID(Convert.ToDouble(ChkSelectCandidate.Attributes["EmpProjectGrpID"])).ToString();
                        proj.DeleteAssignedCandidate(cmd, empProjectGroupID);
                        int candidateID = Global.DecryptID(Convert.ToDouble(ChkSelectCandidate.Attributes["CandidateID"]));

                        /* Update candidate other details */
                        cmd = new MySqlCommand("", conn, trans);
                        cmd.CommandText += " CALL update_candidate_other_details(" + candidateID + "); ";
                        cmd.ExecuteNonQuery();
                    }
                }
                cmd = new MySqlCommand("", conn, trans);
                cmd.CommandType = CommandType.Text;
                proj.UpdateEmploymentProjectStatus(cmd, Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])));
                trans.Commit();
                string message = "Candidate deleted successfully.";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "__maessage", "alert(\"" + message + "\");", true);
            }
            catch (Exception ex)
            {
                trans.Rollback();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
                GetCandidatesAssignedToEmploymentProject();
            }
        }

        protected void BtnPrint_click(object sender, EventArgs e)
        {
            if (Request.Cookies["candidate_calling"] != null && Request.Cookies["candidate_calling"].Value != null && !Request.Cookies["candidate_calling"].Value.Equals(""))
            {
                string selectedCandidates = String.Empty;
                string[] encryptedCandidateIDs = Request.Cookies["candidate_calling"].Value.Trim().Split('_');
                string decryptedCandidateIDs = String.Empty;

                for (int counter = 0; counter < encryptedCandidateIDs.Length; counter++)
                {
                    selectedCandidates += Global.DecryptID(Convert.ToDouble(encryptedCandidateIDs[counter])).ToString() + ",";
                }
                Session["SelectedCandidates"] = selectedCandidates.Substring(0, selectedCandidates.Length - 1);
                ClientScript.RegisterStartupScript(this.GetType(), "__Popup", "ShowPopUp('../candidate/CandidateCallingListPrintForm.aspx',1024,768);", true);
            }
        }

        protected void BtnGotJob_click(object sender, ImageClickEventArgs e)
        {
            Session["event_controle"] = ((ImageButton)sender);
            ImageButton ig = (ImageButton)sender;
            ListViewDataItem lv = (ListViewDataItem)ig.NamingContainer;
            int iRow = lv.DisplayIndex;

            HtmlAnchor lb = (HtmlAnchor)this.LstViewAssignedList.Items[iRow].FindControl("LnkBtnRegistrationID");
            string rid = lb.InnerText;
            this.regId.Value = rid;
            // this.wkExp.Value = "-1";
            int? wkExp = null;
            wkExp = getWorkExperience(rid);
            if (wkExp == 0 || !wkExp.HasValue)
            {
                this.wkExp.Value = "-1";
            }
            else
            {
                double dwk = Global.EncryptID((int)wkExp);
                this.wkExp.Value = dwk.ToString(); //  wkExp.ToString();
            }
            CheckBox cb = (CheckBox)this.LstViewAssignedList.Items[iRow].FindControl("ChkSelectCandidate");
            if (cb != null)
            {
                this.empProj.Value = this.EmploymentProjectID;   //em cb.Attributes["EmpProjectGrpID"];
            }
            else
            {
                this.empProj.Value = "-1";
            }
            this.candId.Value = cb.Attributes["CandidateID"];
            //       BtnSubmit_click(BtnSubmit, new EventArgs());
            // Look if candidate is already employed....
            // -----------------------------------------
            if (this.wkExp.Value != "-1")
            {
                this.UpdatePanel1.Visible = true;
                this.UpdatePanel2.Visible = true;
                this.ModalPopupExtender1.Show();
            }
            else
            {
                string url = "";
                // string url = "~/candidate/WorkExperiencePopup.aspx?regid=" + this.regId.Value + "&work_exp=" + this.wkExp.Value + "&emp_proj=" + this.empProj.Value + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
                populateWorkingDates(iRow);
                if (this.empProj.Value == "-1")
                    url = "~/candidate/WorkExperiencePopup.aspx?regid=" + this.regId.Value + "&emp_proj=" + this.empProj.Value + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri + "&rowId=-1" + "&workDates=" + sw.ToString();
                else

                    url = "~/candidate/WorkExperiencePopup.aspx?regid=" + this.regId.Value + "&emp_proj=" + Global.EncryptID(Convert.ToInt32(this.empProj.Value.ToString())) + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri + "&rowId=-1" + "&workDates=" + sw.ToString();
                if (!string.IsNullOrEmpty(IntStDate))
                {
                    url += "&IntStDate=" + IntStDate;
                    url += "&IntEdDate=" + IntEdDate;
                }

                invokeRadWindow(url);

            }
            cSetFocus(ig);
            ig.Focus();
            return;

            //MySqlConnection conn = Global.GetConnectionString();
            //conn.Open();
            //MySqlTransaction trans = conn.BeginTransaction();
            //MySqlCommand cmd = new MySqlCommand("", conn, trans);
            //EnableIndia.App_Code.BAL.EmploymentProjectBAL proj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            //try
            //{
            //    cmd = new MySqlCommand("", conn, trans);
            //    cmd.CommandType = CommandType.Text;
            //    proj.UpdateEmploymentProjectStatus(cmd, Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])));
            //    trans.Commit();

            //}
            //catch (Exception ex)
            //{
            //    trans.Rollback();
            //}
            //finally
            //{
            //    conn.Close();
            //    cmd.Dispose();
            //    conn.Dispose();
            //}


        }

        private int getWorkExperience(string regid)
        {
            try
            {
                MySqlConnection conn = Global.GetConnectionString();
                string sqlStr = "Select candidate_work_experience_id, max(designation_from_date),designation_to_date  from candidate_work_experience a, ";
                sqlStr += "candidates b where b.registration_id='" + regid.ToString() + "'  And a.designation_to_date='5000-01-01'  AND b.candidate_id=a.candidate_id";
                int wkid = 0;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
                cmd.CommandTimeout = 300;
                cmd.CommandType = CommandType.Text;
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    wkid = System.DBNull.Value.Equals(reader.GetInt32(0)) ? -1 : reader.GetInt32(0);
                }
                reader.Close();
                cmd.Dispose();
                conn.Close();
                conn = null;
                reader = null;
                return wkid;
            }
            catch (System.Exception ex)
            {
                return 0;
            }
        }
        protected void BtnNotes_click(object sender, ImageClickEventArgs e)
        {
            // BtnSearchCandidates_Click(BtnSearchCandidates, new EventArgs());
            ImageButton ib = (ImageButton)sender;
            ListViewDataItem lv = (ListViewDataItem)ib.NamingContainer;
            int iRow = lv.DisplayIndex;
            // GetCandidateAssignedList();
            // Store candidate id , since it is losing the original control id.....
            // --------------------------------------------------------------------
            string candId = ib.Attributes["CandidateID"].ToString();
            GetCandidatesAssignedToEmploymentProject();
            int i = 0;
            ImageButton ib1 = null;
            for (i = 0; i < this.LstViewAssignedList.Items.Count; i++)
            {
                ListViewItem lv1 = (ListViewItem)this.LstViewAssignedList.Items[i];
                ib1 = (ImageButton)lv1.FindControl("BtnNotes");
                string tcandId = ib1.Attributes["CandidateID"].ToString();
                if (candId == tcandId) break;
            }
            Session["event_controle"] = ((ImageButton)ib1);

            if (ib != null)
            {
                CheckBox cb = (CheckBox)lv.FindControl("ChkSelectCandidate");
                string candidateId = cb.Attributes["CandidateID"];
                string url = "";
                url = "~/Company/CandidateNotesForEmploymentProject.aspx?emp_proj=" + Global.EncryptID(Convert.ToInt32(this.EmploymentProjectID)) + "&cand=" + candidateId;
                if (!string.IsNullOrEmpty(IntStDate))
                {
                    url += "&IntStDate=" + IntStDate;
                    url += "&IntEdDate=" + IntEdDate;
                }
                url += "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
                //System.Web.UI.HtmlControls.HtmlAnchor  lb = (System.Web.UI.HtmlControls.HtmlAnchor)lv.FindControl("LnkBtnRegistrationID");
                //int wkEx = getWorkExperience(lb.InnerText);
                //if(wkEx == 0)
                //{
                //    url = "~/candidate/WorkExperiencePopup.aspx?cand=" + ib.Attributes["CandidateID"] + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
                //}
                //else
                //{
                //    this.wkExp.Value = Global.EncryptID(wkEx).ToString();
                //    url = "~/candidate/WorkExperiencePopup.aspx?cand=" + ib.Attributes["CandidateID"] + "&work_exp=" + this.wkExp.Value + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
                //}
                invokeRadWindow(url);
            }
            cSetFocus(ib);
            ib.Focus();
        }

        protected void btnYesClicked(object sender, EventArgs e)
        {

            //            string url = "../candidate/WorkExperiencePopup.aspx?regid=" + this.regId.Value + "&work_exp=" + this.wkExp.Value + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
            this.ModalPopupExtender1.Hide();
            //            string url = "~/Candidate/WorkExperiencePopup.aspx?regid=" + this.regId.Value + "&work_exp=" + this.wkExp.Value; // +"&txboxId='" + HttpContext.Current.Request.Url.AbsoluteUri + "'";
            //            invokeRadWindow(url);
            //StringBuilder sb = new StringBuilder();
            //sb.Append("<script type = 'text/javascript'>");
            //sb.Append("openRadWindow('");
            //sb.Append(url);
            //sb.Append("');");
            //sb.Append("</script>");
            //ClientScript.RegisterStartupScript(this.GetType(),
            //       "script", sb.ToString());

        }
        protected void btnNoClicked(object sender, EventArgs e)
        {
            this.ModalPopupExtender1.Hide();
            //string url = "~/candidate/WorkExperiencePopup.aspx?regid=-1&work_exp=''&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
            //invokeRadWindow(url);

        }

        protected void BtnViewCandidateCallingList_Click(object sender, EventArgs e)
        {

        }
        protected void lbRecommendedCandidateClick(object sender, EventArgs e)
        {
            //            Response.Redirect("~/Company/AddRecommendedCandidate.aspx?emp_proj=" + this.EmploymentProjectID.ToString() + "&comp=" + this.CompanyID.ToString());
            string url = "~/Company/AddRecommendedCandidate.aspx?emp_proj=" + Global.EncryptID(Convert.ToInt32(this.EmploymentProjectID.ToString())) + "&comp=" + this.CompanyID.ToString();
            if (!string.IsNullOrEmpty(IntStDate))
            {
                url += "&IntStDate=" + IntStDate;
                url += "&IntEdDate=" + IntEdDate;
            }
            Response.Redirect(url);
        }
        protected void lbNonRecommendedCandidateClick(object sender, EventArgs e)
        {
            string url = "~/Company/AddNonRecommendedCandidate.aspx?emp_proj=" + Global.EncryptID(Convert.ToInt32(this.EmploymentProjectID.ToString())) + "&comp=" + this.CompanyID.ToString();
            if (!string.IsNullOrEmpty(IntStDate))
            {
                url += "&IntStDate=" + IntStDate;
                url += "&IntEdDate=" + IntEdDate;
            }
            Response.Redirect(url);
        }

        protected void lbCompanyDetailsClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Company/AddCompany.aspx?comp=" + Global.EncryptID(Convert.ToInt32(this.CompanyID)));

        }
        protected void lbempProjectsClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Company/AddEmploymentProjects.aspx?emp_proj=" + Global.EncryptID(Convert.ToInt32(this.EmploymentProjectID)));

        }
        public void invokeRadWindow(string url)
        {
            RadWindow rw = new RadWindow();
            rw.NavigateUrl = url;
            rw.Width = 900;
            rw.Height = 600;
            rw.Top = 0;
            rw.Left = 0;
            rw.MaxHeight = 600;
            rw.MaxWidth = 900;
            rw.Modal = true;
            rw.Behaviors = WindowBehaviors.Maximize | WindowBehaviors.Maximize | WindowBehaviors.Move | WindowBehaviors.Reload | WindowBehaviors.Close;
            rw.KeepInScreenBounds = true;
            //            rw.Behavior = WindowBehaviors.Default;
            rw.ReloadOnShow = true;
            rw.ID = "rwCenquiry";
            //   RadWindowManager rm = (RadWindowManager)this.Parent.FindControl("hradManager");
            this.radManager.Modal = true;
            this.radManager.VisibleOnPageLoad = true;
            rw.EnableViewState = false;
            rw.VisibleOnPageLoad = true;
            this.radManager.EnableViewState = false;
            this.radManager.Windows.Add(rw);
            rw = this.radManager.Windows[0];
            return;
        }
        protected void EnableDropDown(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            ListViewItem lv = (ListViewItem)cb.NamingContainer;

            if (cb.Checked)
            {

                foreach (Control ht in lv.Controls)
                {
                    if (ht.GetType() == typeof(HtmlSelect))
                    {
                        HtmlSelect hs = (HtmlSelect)ht;
                        // hs.Visible = true;
                        hs.Disabled = false;
                    }
                }
            }
            else
            {
                foreach (Control ht in lv.Controls)
                {
                    if (ht.GetType() == typeof(HtmlSelect))
                    {
                        HtmlSelect hs = (HtmlSelect)ht;
                        hs.Disabled = true;
                        // hs.Visible = false;
                    }
                }
            }

            int iRow = lv.DataItemIndex;
            //HtmlSelect ht = (HtmlSelect)lv.FindControl("DdlinterestedInJob");
            //ht.Disabled = false;
            //ht = (HtmlSelect)lv.FindControl("DdlCretificatesVerified");
            //ht.Disabled = false;
            //ht = (HtmlSelect)lv.FindControl("DdlProfileSent");
            //ht.Disabled = false;
       //     this.updAssignedList.Update();
            cSetFocus(cb);
            cb.Focus();
        }
        protected void EnableDisAllCb(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            foreach (ListViewItem lv in this.LstViewAssignedList.Items)
            {
                CheckBox icb = (CheckBox)lv.FindControl("ChkSelectCandidate");
                if (icb != null)
                {
                    if (cb.Checked)
                    {
                        icb.Checked = true;
                        foreach (Control ht in lv.Controls)
                        {
                            if (ht.GetType() == typeof(HtmlSelect))
                            {
                                HtmlSelect hs = (HtmlSelect)ht;
                                // hs.Visible = true;
                                hs.Disabled = false;
                            }
                        }
                    }
                    else
                    {
                        icb.Checked = false;
                        foreach (Control ht in lv.Controls)
                        {
                            if (ht.GetType() == typeof(HtmlSelect))
                            {
                                HtmlSelect hs = (HtmlSelect)ht;
                                hs.Disabled = true;
                                // hs.Visible = false;
                            }
                        }
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
            oldValues = "";
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
        protected void DdlEditParticularStepFromChanged(object sender, EventArgs e)
        {
            if (this.DdlEditParticularStepFrom.SelectedIndex <= 0)
            {
                cSetFocus(this.DdlEditParticularStepFrom);
                this.DdlEditParticularStepFrom.Focus();
                return;
            }
            string stepNumber = this.DdlEditParticularStepFrom.SelectedIndex.ToString();
            this.DdlOutcomeOptions.Items.Clear();
            switch (stepNumber)
            {
                case "1":
                case "9":
                case "10":
                    this.DdlOutcomeOptions.Items.Add(new ListItem { Text = "Select", Value = "-2" });
                    this.DdlOutcomeOptions.Items.Add(new ListItem { Text = "Yes", Value = "1" });
                    this.DdlOutcomeOptions.Items.Add(new ListItem { Text = "No", Value = "0" });
                    break;
                case "2":
                case "3":
                case "6":
                case "7":
                case "11":
                case "12":
                case "13":
                    this.DdlOutcomeOptions.Items.Add(new ListItem { Text = "Select", Value = "-2" });
                    this.DdlOutcomeOptions.Items.Add(new ListItem { Text = "Yes", Value = "1" });
                    this.DdlOutcomeOptions.Items.Add(new ListItem { Text = "No", Value = "0" });
                    this.DdlOutcomeOptions.Items.Add(new ListItem { Text = "NA", Value = "2" });
                    break;
                case "4":
                case "5":
                case "8":
                    this.DdlOutcomeOptions.Items.Add(new ListItem { Text = "Select", Value = "-2" });
                    this.DdlOutcomeOptions.Items.Add(new ListItem { Text = "Yes", Value = "1" });
                    this.DdlOutcomeOptions.Items.Add(new ListItem { Text = "NA", Value = "2" });
                    break;
            }
            cSetFocus(this.DdlEditParticularStepFrom);
            this.DdlEditParticularStepFrom.Focus();

        }
        public void cSetFocus(Control control)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "focus","document.getElementById('" + control.ClientID + "').focus();", true);
            //StringBuilder sb = new StringBuilder();

            //sb.Append("\r\n<script language='JavaScript'>\r\n");
            //sb.Append("<!--\r\n");
            //sb.Append("function SetFocus()\r\n");
            //sb.Append("{\r\n");
            //sb.Append("\tdocument.");

            //Control p = control.Parent;
            //if (p.Parent != null)
            //{
            //    while (!(p is System.Web.UI.HtmlControls.HtmlForm)) p = p.Parent;
            //    sb.Append(p.ClientID);
            //    sb.Append("['");
            //    sb.Append(control.UniqueID);
            //    sb.Append("'].focus();\r\n");
            //    sb.Append("}\r\n");
            //    sb.Append("window.onload = SetFocus;\r\n");
            //    sb.Append("// -->\r\n");
            //    sb.Append("</script>");

            //    //   control.Page.RegisterClientScriptBlock("SetFocus", sb.ToString());
            //    ClientScript.RegisterStartupScript(this.GetType(), "SetFocus", sb.ToString(), false);
            //}
        }
    }
 
}