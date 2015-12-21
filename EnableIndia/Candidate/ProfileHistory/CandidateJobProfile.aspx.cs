using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using MySql.Data.MySqlClient;
using System.Text;
using Telerik;
using Telerik.Web;
using Telerik.Web.UI;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Candidate.ProfileHistory
{

    public partial class CandidateJobProfile : System.Web.UI.Page
    {
        public string CandidateID
        {
            get;
            set;
        }
        public string Mod
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

            TxtPrefferedJob.Focus();

            Global.SetDefaultButtonOfTheForm(this.Form, BtnManageCandidateJobProfile);
            if (Request.QueryString["cand"] != null)
            {
                this.CandidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString();
            }
            Mod = Request.QueryString["Mod"];
            if (!Page.IsPostBack)
            {
                Global.AuthenticateUser();
                if (string.IsNullOrEmpty(Mod))
                {
                    GetCandidateDetail();
                    Global glob = new Global();
                    glob.GetSalaryRange(DdlExpectedSalary);
                    DdlExpectedSalary.Items.Insert(0, new ListItem("Select", "-2"));
                }
                if (Request.QueryString["cand"] != null)
                {
                    LnkBtnRegistration.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnEducationalQualifications.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnWorkExprience.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnKnowledgeAndTraining.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkButtonCandidateHistory.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    if (string.IsNullOrEmpty(Mod))
                    {
                        GetCandidateGroups();
                        GetCandidateJobProfileDetails();
                    }
                    GetCandidateRoleInListView();
                }
                CandidateJobProfileBAL candVacancy = new CandidateJobProfileBAL();
                LstViewVacancy.DataSource = candVacancy.GetCurrentlyAssignnedEmploymentProject(this.CandidateID);
                LstViewVacancy.DataBind();
            }
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }
            if(Page.IsPostBack && this.hField.Value == "1")
            {
                this.hField.Value = string.Empty;
                GetCandidateRoleInListView();
            }
        }
        public void GetCandidateRoleInListView()
        {
            CandidateRecommendedRolesBAL roles = new CandidateRecommendedRolesBAL();
            LstViewJobRoles.DataSource = roles.GetCandidateRecommendedRolesByJob(this.CandidateID);
            LstViewJobRoles.DataBind();
            this.updJobRoles.Update();
        }

        protected void BtnRecommndedJobType_ClickLb(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            string jobId = lb.Attributes["JobID"];
            int cPosn = HttpContext.Current.Request.Url.AbsoluteUri.IndexOf((char)'=');
            string candidateId = HttpContext.Current.Request.Url.AbsoluteUri.Substring(cPosn + 1, (HttpContext.Current.Request.Url.AbsoluteUri.Length - (cPosn + 1)));
            string url = "Recommended Job Type.aspx?cand=" + candidateId + "&job=" + jobId + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
            invokeRadWindow(url);
        }
        protected void BtnRecommndedJobType_ClickBtn(object sender, EventArgs e)
        {
            int cPosn = HttpContext.Current.Request.Url.AbsoluteUri.IndexOf((char)'=');
            string candidateId = HttpContext.Current.Request.Url.AbsoluteUri.Substring(cPosn + 1, (HttpContext.Current.Request.Url.AbsoluteUri.Length - (cPosn + 1)));
            string url = "Recommended Job Type.aspx?cand=" + candidateId + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
            invokeRadWindow(url);
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

        protected void LstViewRecommendedJobRoles_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl LblJobRole = (HtmlGenericControl)e.Item.FindControl("LblJobRole");
                CheckBox ChkSelectJobRole = (CheckBox)e.Item.FindControl("ChkSelectJobRole");

                LblJobRole.Attributes.Add("for", ChkSelectJobRole.ClientID);
            }
        }

        protected void LstViewCandidateGroups_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl LblGroupname = (HtmlGenericControl)e.Item.FindControl("LblGroupname");
                CheckBox ChkSelectGroup = (CheckBox)e.Item.FindControl("ChkSelectGroup");

                LblGroupname.Attributes.Add("for", ChkSelectGroup.ClientID);
            }
        }

        private void GetCandidateGroups()
        {
            EnableIndia.App_Code.BAL.CandidateGroupsBAL grp = new EnableIndia.App_Code.BAL.CandidateGroupsBAL();
            LstViewCandidateGroups.DataSource = grp.GetCandidateGroupsAssignedToCandidate(this.CandidateID);
            LstViewCandidateGroups.DataBind();
        }

        private void GetCandidateJobProfileDetails()
        {
            EnableIndia.App_Code.BAL.CandidateJobProfileBAL candJobPro = new EnableIndia.App_Code.BAL.CandidateJobProfileBAL();
            MySqlDataReader drCandidateJobProfileDetails = candJobPro.GetCandidateJobProfileDetails(this.CandidateID);


            if (drCandidateJobProfileDetails.Read())
            {
                SpnUnemployedFromDays.InnerText = drCandidateJobProfileDetails["unemployed_from_days"].ToString();
                if (SpnUnemployedFromDays.InnerText.Equals("Employed"))
                {
                    SpnUnemployedFromDays.InnerText = "Employed ";
                    SpnDays.Visible = false;

                }
                else
                {
                    SpnUnemployedFromDays.InnerText = drCandidateJobProfileDetails["unemployed_from_days"].ToString();
                }
                TxtPrefferedJob.Text = drCandidateJobProfileDetails["preferred_job_by_candidate"].ToString();
                TxtPreferredLocation.Text = drCandidateJobProfileDetails["preferred_location"].ToString();
                TxtEvaluatorComments.Text = drCandidateJobProfileDetails["evaluator_comments"].ToString();
                DdlExpectedSalary.Value = drCandidateJobProfileDetails["expected_monthly_salary_range"].ToString();

                ChkMakeCandidateInactive.Checked = Convert.ToBoolean(drCandidateJobProfileDetails["is_inactive"]);
                TxtCandidateInactiveReason.Text = drCandidateJobProfileDetails["inactive_reason"].ToString();

                ChkPriorityCandidate.Checked = Convert.ToBoolean(drCandidateJobProfileDetails["is_priority_candidate"]);
                TxtPriorityCandidateReason.Text = drCandidateJobProfileDetails["priority_candidate_reason"].ToString();

                ChkNeedyCandidate.Checked = Convert.ToBoolean(drCandidateJobProfileDetails["is_needy_candidate"]);
                TxtNeedyCandidateReason.Text = drCandidateJobProfileDetails["needy_candidate_reason"].ToString();

                BtnManageCandidateJobProfile.Attributes["OpenTask"] = drCandidateJobProfileDetails["assigned_count"].ToString();
                BtnManageCandidateJobProfile.Attributes["OpenTraningProject"] = drCandidateJobProfileDetails["train_project_count"].ToString();
                BtnManageCandidateJobProfile.Attributes["OpenEmpProject"] = drCandidateJobProfileDetails["emp_proj_count"].ToString();

                drCandidateJobProfileDetails.Close();
                drCandidateJobProfileDetails.Dispose();
            }
            else
            {
                Response.Redirect("CandidateJobProfile.aspx", true);
            }
        }

        protected void BtnManageCandidateJobProfile_Click(object sender, EventArgs e)
        {
            if (!ChkMakeCandidateInactive.Checked)
            {
                TxtCandidateInactiveReason.Text = "";
            }

            if (!ChkPriorityCandidate.Checked)
            {
                TxtPriorityCandidateReason.Text = "";
            }

            if (!ChkNeedyCandidate.Checked)
            {
                TxtNeedyCandidateReason.Text = "";
            }

            string message = String.Empty;
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand("", conn, trans);

            try
            {

                //Manages candidate groups
                cmd = new MySqlCommand("", conn, trans);
                cmd.CommandText = "delete from candidate_groups_assigned_to_candidate where candidate_id=" + this.CandidateID;
                cmd.ExecuteNonQuery();

                foreach (ListViewDataItem item in LstViewCandidateGroups.Items)
                {
                    CheckBox ChkSelectGroup = (CheckBox)item.FindControl("ChkSelectGroup");
                    if (ChkSelectGroup.Checked)
                    {
                        cmd = new MySqlCommand("", conn, trans);
                        cmd.CommandText = "insert into candidate_groups_assigned_to_candidate(candidate_id,candidate_group_id)";
                        cmd.CommandText += "values(" + this.CandidateID + ",";
                        cmd.CommandText += Global.DecryptID(Convert.ToDouble(ChkSelectGroup.Attributes["CandidateGroupID"])).ToString() + ")";
                        cmd.ExecuteNonQuery();
                    }
                }

                cmd = new MySqlCommand("manage_candidate_job_profile", conn, trans);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("para_candidate_id", this.CandidateID);
                cmd.Parameters.AddWithValue("para_preferred_job_by_candidate", TxtPrefferedJob.Text.Trim());
                cmd.Parameters.AddWithValue("para_preferred_location", TxtPreferredLocation.Text.Trim());
                cmd.Parameters.AddWithValue("para_expected_monthly_salary_range", DdlExpectedSalary.Value);
                cmd.Parameters.AddWithValue("para_evaluator_comments", TxtEvaluatorComments.Text.Trim());


                cmd.Parameters.AddWithValue("para_inactive_reason", TxtCandidateInactiveReason.Text.Trim());
                cmd.Parameters.AddWithValue("para_is_priority_candidate", ChkPriorityCandidate.Checked);
                cmd.Parameters.AddWithValue("para_priority_candidate_reason", TxtPriorityCandidateReason.Text.Trim());
                cmd.Parameters.AddWithValue("para_is_needy_candidate", ChkNeedyCandidate.Checked);
                cmd.Parameters.AddWithValue("para_needy_candidate_reason", TxtNeedyCandidateReason.Text.Trim());

                if (ChkMakeCandidateInactive.Checked == true)
                {
                    CandidateJobProfileBAL job = new CandidateJobProfileBAL();
                    int isCandidateAssigned = job.CheckCandidateAssignedForTask(this.CandidateID);
                    if (isCandidateAssigned > 0)
                    {
                        //string script = String.Empty;
                        //script = "alert('Candidate cannot be deleted as candidate has open tasks assigned.');";
                        //ClientScript.RegisterStartupScript(this.GetType(), "__key", script, true);
                        message = "Candidate cannot be deleted as candidate has open tasks assigned.";
                        ChkMakeCandidateInactive.Checked = false;
                        cmd.Parameters.AddWithValue("para_is_active", !ChkMakeCandidateInactive.Checked);
                    }
                    else
                    {
                        message = "Candidate job profile updated successfully.";
                        cmd.Parameters.AddWithValue("para_is_active", !ChkMakeCandidateInactive.Checked);
                    }
                }
                else
                {
                    message = "Candidate job profile updated successfully.";
                    cmd.Parameters.AddWithValue("para_is_active", !ChkMakeCandidateInactive.Checked);

                }
                cmd.ExecuteNonQuery();

                trans.Commit();

                GetCandidateGroups();
                GetCandidateJobProfileDetails();
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
                if (ChkMakeCandidateInactive.Checked)
                {
                    Response.Redirect("~/company/ListOfOpenEmploymentProject.aspx", true);
                }
            }
        }
        private void invokeRadWindow(string url)
        {
            RadWindow rw = this.RadWindow;
            rw.NavigateUrl = url;
            rw.Width = 600;
            rw.Height = 500;
            rw.Top = 0;
            rw.Left = 0;
            rw.MaxHeight = 500;
            rw.MaxWidth = 600;
            rw.Modal = true;
            rw.Behaviors = WindowBehaviors.Maximize | WindowBehaviors.Close;
            rw.KeepInScreenBounds = false;
            //            rw.Behavior = WindowBehaviors.Default;
            rw.ReloadOnShow = true;
            rw.ID = "rwCenquiry";
            //   RadWindowManager rm = (RadWindowManager)this.Parent.FindControl("hradManager");
             this.radManager.Modal = true;
            this.radManager.VisibleOnPageLoad = true;
            rw.EnableViewState = false;
            rw.VisibleOnPageLoad = true;
            rw.AutoSize = false;
            this.radManager.Windows.Add(rw);
            rw = this.radManager.Windows[0];
            return;

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