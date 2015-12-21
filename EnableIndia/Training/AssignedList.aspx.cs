using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using MySql.Data.MySqlClient;
using Stimulsoft.Report;
using Stimulsoft.Report.Web;
using Telerik;
using Telerik.Web;
using Telerik.Web.UI;
using System.Xml;
using System.Xml.XPath;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;
using System.Reflection;
using System.Text;

namespace EnableIndia.Training
{

    public partial class AssignedList : System.Web.UI.Page
    {
        [Serializable]
        public class wkDates
        {
            public string stDate { get; set; }
            public string edDate { get; set; }
            public bool bCurrentFlag { get; set; }
        }
        public StringWriter sw = new StringWriter();
        public IList<wkDates> workDates = new List<wkDates>();

        DataTable sqlDt;
        string[,] workingDates;

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

        int candidateID
        {
            get;
            set;
        }
        int empProjId
        {
            get;
            set;
        }
        int lvRowNumber;

        protected void Page_Load(object sender, EventArgs e)
        {

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

            GetTrainingProgramDetail();

            Global.SetDefaultButtonOfTheForm(this.Form, BtnSubmit);
            DdlCandidateCallingStep.Focus();
            if (!Page.IsPostBack)
            {
                Global.ShowMessageInAlert(this.Form);
                if (Request.QueryString["train_proj"] != null)
                {
                    GetCandidateAssignedList();
                }
            }
 //           ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "$('#TblViewAssignedCandidateList tbody tr td[Step] select').change();CheckAssignedList();", true);
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }
            if(!Page.IsPostBack)
            {
                if(ViewState["lvRowNumber"] != null)
                {
                    lvRowNumber = Convert.ToInt32(ViewState["lvRowNumber"]);
                }
            }
            if(!Page.IsPostBack)
            {
                this.DdlOutcomes.Attributes.Add("Step", "1");
                this.DdlOutcomes.Attributes.Add("Step", "1");
                this.DdlOutcomes.Attributes.Add("Step", "2");
                this.DdlOutcomes.Attributes.Add("Step", "2");
                this.DdlOutcomes.Attributes.Add("Step", "3");
                this.DdlOutcomes.Attributes.Add("Step", "3");
                this.DdlOutcomes.Attributes.Add("Step", "4");
                this.DdlOutcomes.Attributes.Add("Step", "4");
                this.DdlOutcomes.Attributes.Add("Step", "5");
                this.DdlOutcomes.Attributes.Add("Step", "5");
                this.DdlOutcomes.Attributes.Add("Step", "6");
                this.DdlOutcomes.Attributes.Add("Step", "6");
                this.DdlOutcomes.Attributes.Add("Step", "7");
                this.DdlOutcomes.Attributes.Add("Step", "7");


            }
            if(Page.IsPostBack)
            {
               
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
        //protected override void OnPreRender(EventArgs e)
        //{
        //    base.OnPreRender(e);
        //}
        protected void GetTrainingProgramDetail()
        {
            EnableIndia.App_Code.BAL.TrainingProjectBAL project = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            MySqlDataReader drProject = project.GetTrainingProgramInstance(this.trainingProjectID.ToString());
            if (drProject.Read())
            {
                SpnTrainingProgramName.InnerText = drProject["training_program_name"].ToString();
                SpnTrainingProjectName.InnerText = drProject["training_project_name"].ToString();
                SpnTrainingProjectStatus.InnerText = drProject["project_status"].ToString();

                if (drProject["cand_certi_count"].ToString() == "0")
                {
                    BtnCloseTrainingProject.Visible = false;
                }
                else if (drProject["cand_certi_count"].Equals(drProject["cand_assign_count"]))
                {
                    BtnCloseTrainingProject.Visible = true;
                }
            }
            drProject.Close();
            drProject.Dispose();
        }

        protected void BtnNotes_Click(object sender,  ImageClickEventArgs e)
        {
            ImageButton ib = (ImageButton)sender;
            ListViewDataItem lv = (ListViewDataItem)ib.NamingContainer;
            int iRow = lv.DisplayIndex;
            // Store candidate id , since it is losing the original control id.....
            // --------------------------------------------------------------------
            string candId = ib.Attributes["CandidateID"].ToString();
            GetCandidateAssignedList();
            int i = 0;
            ImageButton ib1 = null;
            for (i = 0; i < this.LstViewAssignedCandidateList.Items.Count;i++)
            {
                ListViewItem lv1 = (ListViewItem)this.LstViewAssignedCandidateList.Items[i];
                ib1 = (ImageButton)lv1.FindControl("BtnNotes");
                string tcandId = ib1.Attributes["CandidateID"].ToString();
                if (candId == tcandId) break;
            }
            Session["event_controle"] = ((ImageButton)ib1);
            if (ib != null)
            {
                //GetCandidateWorkExperience(ib.Attributes["CandidateID"]);
                //populateWorkingDates();
                invokeRadWindow(ib.Attributes["CandidateID"]);
            }
            cSetFocus(ib);
            ib.Focus();
        }

        protected void GetCandidateAssignedList()
        {
            EnableIndia.App_Code.BAL.TrainingProjectBAL training = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            LstViewAssignedCandidateList.DataSource = training.GetAssigneListCandidate(this.trainingProjectID);
            LstViewAssignedCandidateList.DataBind();
         //   this.updlvca.Update();

            if (LstViewAssignedCandidateList.Items.Count.Equals(0))
            {
                BtnViewCandidateCallingList.Visible = false;
                BtnAddToCandidateCalling.Visible = false;
                BtnDeleteCandidates.Visible = false;
                BtnResetCandidate.Visible = false;
                BtnSubmit.Visible = false;
                TblCloseParticularStep.Visible = false;
                TblCandidateCaliingFromStep.Visible = false;
                TblTextAssignlistCandidate.Visible = false;
                BtnPrint.Visible = false;
            }
            else
            {
                BtnViewCandidateCallingList.Visible = true;
                BtnAddToCandidateCalling.Visible = true;
                BtnDeleteCandidates.Visible = true;
                BtnResetCandidate.Visible = true;
                BtnSubmit.Visible = true;
                TblCloseParticularStep.Visible = true;
                TblCandidateCaliingFromStep.Visible = true;
                TblTextAssignlistCandidate.Visible = true;
                BtnPrint.Visible = true;
            }
        }

        protected void LstViewAssignedCandidateList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                CheckBox ChkRecommendedCandidateName = (CheckBox)e.Item.FindControl("ChkRecommendedCandidateName");
                HtmlGenericControl LblCandidateName = (HtmlGenericControl)e.Item.FindControl("LblCandidateName");
                LblCandidateName.Attributes.Add("for", ChkRecommendedCandidateName.ClientID);
                ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(ChkRecommendedCandidateName);
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
                EnableIndia.App_Code.BAL.TrainingProjectBAL trainProj = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
                DataTable dtAssignCandidates = trainProj.GetAssigneListCandidate(this.trainingProjectID);

                foreach (DataRow dr in dtAssignCandidates.Rows)
                {
                    int candidateID = Convert.ToInt32(dr["candidate_id"]);
                    cmd.CommandText = string.Format("CALL update_candidate_other_details({0})", candidateID);
                    int j = cmd.ExecuteNonQuery();
                }

                cmd.CommandText = "update training_projects set is_closed=1 where training_project_id=" + this.trainingProjectID;
                int i = cmd.ExecuteNonQuery();
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
            string url = "~/Training/ListOfOpenTrainingProjects.aspx?msg=" + Global.EncryptQueryString("Training project closed successfully.");
            url += "&foc=" + Global.EncryptQueryString("null");
            Response.Redirect(url);
        }

        protected void BtnSubmit_click(object sender, EventArgs e)
        {
            string message = String.Empty;
            int deletedCandidates = 0;
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand("", conn, trans);

            EnableIndia.App_Code.BAL.TrainingProjectBAL training = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            try
            {
                foreach (ListViewDataItem item in LstViewAssignedCandidateList.Items)
                {
                    CheckBox ChkRecommendedCandidateName = (CheckBox)item.FindControl("ChkRecommendedCandidateName");
                    if (ChkRecommendedCandidateName.Checked)
                    {
                        cmd = new MySqlCommand("", conn, trans);
                        int candidateID = Global.DecryptID(Convert.ToDouble(ChkRecommendedCandidateName.Attributes["CandidateID"]));

                        HtmlSelect DdlConfirmedToAttendTraining = (HtmlSelect)item.FindControl("DdlConfirmedToAttendTraining");
                        HtmlSelect DdlPassedEvaluation = (HtmlSelect)item.FindControl("DdlPassedEvaluation");
                        HtmlSelect DdlActuallyStartedAttendingTraining = (HtmlSelect)item.FindControl("DdlActuallyStartedAttendingTraining");
                        HtmlSelect DdlCompletedTraining = (HtmlSelect)item.FindControl("DdlCompletedTraining");
                        HtmlSelect DdlPassedTraining = (HtmlSelect)item.FindControl("DdlPassedTraining");
                        HtmlSelect DdlGrade = (HtmlSelect)item.FindControl("DdlGrade");
                        HtmlSelect DdlReceivedCertificate = (HtmlSelect)item.FindControl("DdlReceivedCertificate");

                        training.TrainingProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["train_proj"]));
                        training.CandidateID = Convert.ToInt32(candidateID);
                        training.ConfirmedToAttendTraining = Convert.ToInt32(DdlConfirmedToAttendTraining.Value);
                        training.PassedEvaluation = Convert.ToInt32(DdlPassedEvaluation.Value);
                        training.ActuallyStartedAttendingTraining = Convert.ToInt32(DdlActuallyStartedAttendingTraining.Value);
                        training.CompletedTraining = Convert.ToInt32(DdlCompletedTraining.Value);
                        training.PassedTraining = Convert.ToInt32(DdlPassedTraining.Value);
                        training.ReceivedCertificate = Convert.ToInt32(DdlReceivedCertificate.Value);
                        if (DdlPassedTraining.Value == "0" || DdlPassedTraining.Value == "-2")
                        {
                            training.Grade = "-2";
                        }
                        else
                        {
                            training.Grade = DdlGrade.Value;
                        }
                        if (training.ConfirmedToAttendTraining == 0 || training.PassedEvaluation == 0 || training.ActuallyStartedAttendingTraining == 0 || training.CompletedTraining == 0)
                        {
                            training.UpdateCandidateAssignedList(cmd, training);
                            cmd = new MySqlCommand("", conn, trans);
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "update candidates_assigned_to_training_projects set is_candidate_deleted=1 where candidate_id=" + candidateID;
                            cmd.CommandText += " and training_project_id=" + this.trainingProjectID + ";";
                            cmd.ExecuteNonQuery();
                            deletedCandidates++;
                        }
                        else
                        {
                            cmd = new MySqlCommand("", conn, trans);
                            training.UpdateCandidateAssignedList(cmd, training);
                        }

                        //update candidate other details
                        cmd = new MySqlCommand("", conn, trans);
                        cmd.CommandText += " CALL update_candidate_other_details(" + candidateID + "); ";
                        cmd.ExecuteNonQuery();
                    }
                    ChkRecommendedCandidateName.Checked = false;

                    //update status of project
                    cmd = new MySqlCommand("", conn, trans);
                    cmd.CommandType = CommandType.Text;
                    training.UpdateTrainingProjectStatus(cmd, this.trainingProjectID);
                }
                trans.Commit();
                message = "Assigned list updated successfully.";
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
                if (deletedCandidates == 1)
                {
                    message = deletedCandidates.ToString() + " candidate being deassigned from this project.";
                }
                else if (deletedCandidates > 1)
                {
                    message = deletedCandidates.ToString() + " candidates being deassigned from this project.";
                }
                Global.RedirectAfterSubmit(message, BtnSubmit.ID);
                GetCandidateAssignedList();
                Response.Redirect("~/Training/AssignedList.aspx", false);
            }
        }
        private void messageBox(string message)
        {
            webMessageBox wb = new webMessageBox();
            wb.Show(message);
        }
        protected void applyButtonClicked(object sender, EventArgs e)
        {
            if(this.DdlCloseOfParticularStep.SelectedIndex < 0)
            {
                messageBox("Nothing selected");
                return;
            }
            bool bChangesDone = false;
            // Apply button clicked....
            int i = 0;
            int j = 0;
            int iStepIndex = this.DdlCloseOfParticularStep.SelectedIndex;
            int iOutComeIndex = this.DdlOutcomes.SelectedIndex;

            // First check whether all the check boxes are checked....
            CheckBox cbAll = (CheckBox)this.LstViewAssignedCandidateList.FindControl("ChkSelectAllCandidates");
            if(cbAll != null)
            {
                if(cbAll.Checked)
                {
                    bChangesDone = true;
                    // Find the control for all items....
                    int selIndex = this.DdlOutcomes.SelectedIndex;
                    for(i = 0;i < this.LstViewAssignedCandidateList.Items.Count;i++)
                    {
                            HtmlSelect DdlConfirmedToAttendTraining = (HtmlSelect)this.LstViewAssignedCandidateList.Items[i].FindControl("DdlConfirmedToAttendTraining");
                            HtmlSelect DdlPassedEvaluation = (HtmlSelect)this.LstViewAssignedCandidateList.Items[i].FindControl("DdlPassedEvaluation");
                            HtmlSelect DdlActuallyStartedAttendingTraining = (HtmlSelect)this.LstViewAssignedCandidateList.Items[i].FindControl("DdlActuallyStartedAttendingTraining");
                            HtmlSelect DdlCompletedTraining = (HtmlSelect)this.LstViewAssignedCandidateList.Items[i].FindControl("DdlCompletedTraining");
                            HtmlSelect DdlPassedTraining = (HtmlSelect)this.LstViewAssignedCandidateList.Items[i].FindControl("DdlPassedTraining");
                            HtmlSelect DdlGrade = (HtmlSelect)this.LstViewAssignedCandidateList.Items[i].FindControl("DdlGrade");
                            HtmlSelect DdlReceivedCertificate = (HtmlSelect)this.LstViewAssignedCandidateList.Items[i].FindControl("DdlReceivedCertificate");
                            if(iStepIndex == 1)
                            {
                                if(DdlConfirmedToAttendTraining != null)
                                {
                                    if (this.DdlCloseOfParticularStep.SelectedValue == "1")
                                        DdlConfirmedToAttendTraining.Value = this.DdlOutcomes.SelectedValue; 
                                }
                            }
                            if(iStepIndex == 2)
                            {
                                if(DdlPassedEvaluation != null)
                                {
                                    if (DdlConfirmedToAttendTraining.Value == "1")
                                    {
                                        DdlPassedEvaluation.Value = this.DdlOutcomes.SelectedValue; 
                                    }
                                }
                            }
                            if(iStepIndex == 3)
                            {
                                if(DdlActuallyStartedAttendingTraining != null)
                                {
                                    if((DdlConfirmedToAttendTraining.Value == "1") && (DdlConfirmedToAttendTraining.Value == "1"))
                                    {
                                        DdlActuallyStartedAttendingTraining.Value = this.DdlOutcomes.SelectedValue; 
                                    }
                                }
                            }
                            if(iStepIndex == 4)
                            {
                                if(DdlCompletedTraining != null)
                                {
                                    if ((DdlConfirmedToAttendTraining.Value == "1") && (DdlConfirmedToAttendTraining.Value == "1") && (DdlActuallyStartedAttendingTraining.Value == "1"))
                                    {
                                        DdlCompletedTraining.Value = this.DdlOutcomes.SelectedValue; 
                                    }

                                }
                            }
                            if(iStepIndex == 5)
                            {
                                if (DdlPassedTraining != null)
                                {
                                    if ((DdlConfirmedToAttendTraining.Value == "1") && (DdlConfirmedToAttendTraining.Value == "1") &&
                                        (DdlActuallyStartedAttendingTraining.Value == "1") && (DdlCompletedTraining.Value == "1"))
                                    {
                                        DdlPassedTraining.Value = this.DdlOutcomes.SelectedValue; 
                                    }
                                }

                            }
                            if(iStepIndex == 6)
                            {
                                if (DdlGrade != null)
                                {
                                    if ((DdlConfirmedToAttendTraining.Value == "1") && (DdlConfirmedToAttendTraining.Value == "1") &&
                                        (DdlActuallyStartedAttendingTraining.Value == "1") && (DdlCompletedTraining.Value == "1") && DdlPassedTraining.Value == "1")
                                    {
                                        DdlGrade.Value = this.DdlOutcomes.SelectedValue;
                                    }
                                }

                            }
                            if(iStepIndex == 7)
                            {
                                if (DdlReceivedCertificate != null)
                                {
                                    if ((DdlConfirmedToAttendTraining.Value == "1") && (DdlConfirmedToAttendTraining.Value == "1") &&
                                        (DdlActuallyStartedAttendingTraining.Value == "1") && (DdlCompletedTraining.Value == "1") && DdlPassedTraining.Value == "1")
                                    {
                                        DdlReceivedCertificate.Value = this.DdlOutcomes.SelectedValue;
                                    }
                                }

                            }
                    }
                }
                else
                {
                    // Check if any individual checkboxes are checked....
                    bool cbChecked = false;
                    for (i = 0; i < this.LstViewAssignedCandidateList.Items.Count; i++)
                    {
                        CheckBox cb1 = (CheckBox)this.LstViewAssignedCandidateList.Items[i].FindControl("ChkRecommendedCandidateName");
                        if (cb1 != null)
                        {
                            if (cb1.Checked)
                            {
                                cbChecked = true;
                                break;
                            }
                        }
                    }
                    if(!cbChecked)
                    {
                        messageBox("No candidate selected");
                        return;
                    }
                    bChangesDone = true; 
                    for(i = 0;i < this.LstViewAssignedCandidateList.Items.Count;i++)
                    {
                        CheckBox cb = (CheckBox)this.LstViewAssignedCandidateList.Items[i].FindControl("ChkRecommendedCandidateName");
                        if(cb != null)
                        {
                            if(cb.Checked)
                            {
                                HtmlSelect DdlConfirmedToAttendTraining = (HtmlSelect)this.LstViewAssignedCandidateList.Items[i].FindControl("DdlConfirmedToAttendTraining");
                                HtmlSelect DdlPassedEvaluation = (HtmlSelect)this.LstViewAssignedCandidateList.Items[i].FindControl("DdlPassedEvaluation");
                                HtmlSelect DdlActuallyStartedAttendingTraining = (HtmlSelect)this.LstViewAssignedCandidateList.Items[i].FindControl("DdlActuallyStartedAttendingTraining");
                                HtmlSelect DdlCompletedTraining = (HtmlSelect)this.LstViewAssignedCandidateList.Items[i].FindControl("DdlCompletedTraining");
                                HtmlSelect DdlPassedTraining = (HtmlSelect)this.LstViewAssignedCandidateList.Items[i].FindControl("DdlPassedTraining");
                                HtmlSelect DdlGrade = (HtmlSelect)this.LstViewAssignedCandidateList.Items[i].FindControl("DdlGrade");
                                HtmlSelect DdlReceivedCertificate = (HtmlSelect)this.LstViewAssignedCandidateList.Items[i].FindControl("DdlReceivedCertificate");
                                if (iStepIndex == 1)
                                {
                                    if (DdlConfirmedToAttendTraining != null)
                                    {
                                            DdlConfirmedToAttendTraining.Value = this.DdlOutcomes.SelectedValue;
                                    }
                                }
                                if (iStepIndex == 2)
                                {
                                    if (DdlPassedEvaluation != null)
                                    {
                                        if (DdlConfirmedToAttendTraining.Value == "1")
                                        {
                                            DdlPassedEvaluation.Value = this.DdlOutcomes.SelectedValue;
                                        }
                                    }
                                }
                                if (iStepIndex == 3)
                                {
                                    if (DdlActuallyStartedAttendingTraining != null)
                                    {
                                        if ((DdlConfirmedToAttendTraining.Value == "1") && (DdlConfirmedToAttendTraining.Value == "1"))
                                        {
                                            DdlActuallyStartedAttendingTraining.Value = this.DdlOutcomes.SelectedValue;
                                        }
                                    }
                                }
                                if (iStepIndex == 4)
                                {
                                    if (DdlCompletedTraining != null)
                                    {
                                        if ((DdlConfirmedToAttendTraining.Value == "1") && (DdlConfirmedToAttendTraining.Value == "1") && (DdlActuallyStartedAttendingTraining.Value == "1"))
                                        {
                                            DdlCompletedTraining.Value = this.DdlOutcomes.SelectedValue;
                                        }

                                    }
                                }
                                if (iStepIndex == 5)
                                {
                                    if (DdlPassedTraining != null)
                                    {
                                        if ((DdlConfirmedToAttendTraining.Value == "1") && (DdlConfirmedToAttendTraining.Value == "1") &&
                                            (DdlActuallyStartedAttendingTraining.Value == "1") && (DdlCompletedTraining.Value == "1"))
                                        {
                                            DdlPassedTraining.Value = this.DdlOutcomes.SelectedValue;
                                        }
                                    }

                                }
                                if (iStepIndex == 6)
                                {
                                    if (DdlGrade != null)
                                    {
                                        if ((DdlConfirmedToAttendTraining.Value == "1") && (DdlConfirmedToAttendTraining.Value == "1") &&
                                            (DdlActuallyStartedAttendingTraining.Value == "1") && (DdlCompletedTraining.Value == "1") && DdlPassedTraining.Value == "1")
                                        {
                                            DdlGrade.Value = this.DdlOutcomes.SelectedValue;
                                        }
                                    }

                                }
                                if (iStepIndex == 7)
                                {
                                    if (DdlReceivedCertificate != null)
                                    {
                                        if ((DdlConfirmedToAttendTraining.Value == "1") && (DdlConfirmedToAttendTraining.Value == "1") &&
                                            (DdlActuallyStartedAttendingTraining.Value == "1") && (DdlCompletedTraining.Value == "1") && DdlPassedTraining.Value == "1")
                                        {
                                            DdlReceivedCertificate.Value = this.DdlOutcomes.SelectedValue;
                                        }
                                    }

                                }

                            }
                        }
                    }
                }
                if (bChangesDone)
                {
                    Type t = typeof(Button);
                    object[] p = new object[1];
                    p[0] = EventArgs.Empty;
                    MethodInfo m = t.GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance);
                    // m.Invoke(btnButtonYouWantedToSimulate, p);
                    if (m != null)
                        m.Invoke(this.BtnSubmit, p);

                }

            }
        }
        protected void LnkBtnAddNonRecommendedCandidates_click(object sender, EventArgs e)
        {
            double projectID = Global.EncryptID(Convert.ToInt32(trainingProjectID));
            double programID = Global.EncryptID(Convert.ToInt32(trainingProgramID));
            Response.Redirect("~/Training/AddNonRecommendedCandidate.aspx?train_proj=" + projectID + "&train_prog=" + programID, true);
        }

        protected void LnkBtnAddRecommendedCandidates_click(object sender, EventArgs e)
        {
            double projectID = Global.EncryptID(Convert.ToInt32(trainingProjectID));
            double programID = Global.EncryptID(Convert.ToInt32(trainingProgramID));
            Response.Redirect("~/Training/AddRecommendedCandidate.aspx?train_proj=" + projectID + "&train_prog=" + programID, true);
        }

        protected void BtnDeleteCandidates_click(object sender, EventArgs e)
        {
            string message = String.Empty;
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand("", conn, trans);

            EnableIndia.App_Code.BAL.TrainingProjectBAL training = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            try
            {
                foreach (ListViewDataItem item in LstViewAssignedCandidateList.Items)
                {
                    CheckBox ChkRecommendedCandidateName = (CheckBox)item.FindControl("ChkRecommendedCandidateName");
                    if (ChkRecommendedCandidateName.Checked)
                    {
                        cmd = new MySqlCommand("", conn, trans);
                        cmd.CommandType = CommandType.Text;
                        string trainProjGroupID = Global.DecryptID(Convert.ToDouble(ChkRecommendedCandidateName.Attributes["TrainProjGrpID"])).ToString();
                        int candidateID = Global.DecryptID(Convert.ToDouble(ChkRecommendedCandidateName.Attributes["CandidateID"]));

                        cmd.CommandText = string.Format("delete from candidates_assigned_to_training_projects where assigned_training_project_id={0}", trainProjGroupID);
                        cmd.ExecuteNonQuery();

                        //update candidate other details
                        cmd = new MySqlCommand("", conn, trans);
                        cmd.CommandText += " CALL update_candidate_other_details(" + candidateID + "); ";
                        cmd.ExecuteNonQuery();
                    }
                }

                cmd = new MySqlCommand("", conn, trans);
                cmd.CommandType = CommandType.Text;
                training.UpdateTrainingProjectStatus(cmd, this.trainingProjectID);
                trans.Commit();
                message = "Candidate deleted successfully.";
            }
            catch (Exception ex)
            {
                message = Global.GetGlobalErrorMessage();
                trans.Rollback();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
                Global.RedirectAfterSubmit(message, BtnDeleteCandidates.ID);
            }
        }

        protected void BtnAddToCandidateCalling_click(object sender, EventArgs e)
        {

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
                ClientScript.RegisterStartupScript(this.GetType(), "__Popup", "GetCandidateCalling();", true);
            }
        }

        private void PrintReport()
        {
            StiReport report = new StiReport();
            EnableIndia.App_Code.BAL.CandidateCallingBAL get = new EnableIndia.App_Code.BAL.CandidateCallingBAL();

            report.RegData("CandidateDetail", get.GetCandidateCalling(Session["SelectedCandidates"].ToString()));
            report.Load(Server.MapPath("~/Reports/candidateCalling.mrt"));
            string fileName = "Training_" + Request.QueryString["train_proj"].ToString();
            string filePath = Server.MapPath("~/Docs/" + fileName + ".pdf");
            StiWebViewer1.Report = report;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            report.ExportDocument(StiExportFormat.Pdf, filePath);
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.Flush();
            Response.WriteFile(filePath);
            Response.End();
            File.Delete(filePath);
            Session["SelectedCandidates"] = null;
        }
        private void invokeRadWindow(string candId)
        {
//                 Response.Redirect("~/Training/CandidateNotes.aspx?train_proj=" + Global.EncryptID(trainingProjectID) + "&cand=" + ib.Attributes["CandidateID"]);
            RadWindow rw = new RadWindow();
            rw.NavigateUrl = "~/Training/CandidateNotes.aspx?train_proj=" + Global.EncryptID(trainingProjectID) + "&cand=" + candId.ToString() + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
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
        protected void BtnJobs_Click(object sender, EventArgs e)
        {
            Session["event_controle"] = ((ImageButton)sender);
            ImageButton ib = (ImageButton)sender;
            ListViewDataItem lv = (ListViewDataItem)ib.NamingContainer;
            int iRow = lv.DisplayIndex;
            if (ib != null)
            {
                GetCandidateWorkExperience(ib.Attributes["CandidateID"]);
                populateWorkingDates();
                invokeRadWindowJobs(ib.Attributes["CandidateID"]);
            }
            cSetFocus(ib);
            ib.Focus();
        }
        protected void EnableDropDown(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            ListViewItem lv = (ListViewItem)cb.NamingContainer;
            HtmlSelect c1 = (HtmlSelect)lv.FindControl("DdlConfirmedToAttendTraining");
            HtmlSelect c2 = (HtmlSelect)lv.FindControl("DdlPassedEvaluation");
            HtmlSelect c3 = (HtmlSelect)lv.FindControl("DdlActuallyStartedAttendingTraining");
            HtmlSelect c4 = (HtmlSelect)lv.FindControl("DdlCompletedTraining");
            HtmlSelect c5 = (HtmlSelect)lv.FindControl("DdlPassedTraining");
            HtmlSelect c6 = (HtmlSelect)lv.FindControl("DdlGrade");
            HtmlSelect c7 = (HtmlSelect)lv.FindControl("DdlReceivedCertificate");
            if (cb.Checked)
            {
                  if (c1 != null) c1.Disabled = false;
                  if (c2 != null) c2.Disabled = false;
                  if (c3 != null) c3.Disabled = false;
                  if (c4 != null) c4.Disabled = false;
                  if (c5 != null) c5.Disabled = false;
                  if (c6 != null) c6.Disabled = false;
                  if (c7 != null) c7.Disabled = false;

            }
            else
            {
                if (c1 != null) c1.Disabled = true;
                if (c2 != null) c2.Disabled = true;
                if (c3 != null) c3.Disabled = true;
                if (c4 != null) c4.Disabled = true;
                if (c5 != null) c5.Disabled = true;
                if (c6 != null) c6.Disabled = true;
                if (c7 != null) c7.Disabled = true;

            }
            cb.Focus();
            cSetFocus(cb);
        }

        protected void EnableDisAllCb(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            foreach (ListViewItem lv in this.LstViewAssignedCandidateList.Items)
            {
                CheckBox icb = (CheckBox)lv.FindControl("ChkRecommendedCandidateName");
                if (icb != null)
                {
                    if (icb.Checked)
                    {
                        icb.Checked = false;
                        foreach (Control ht in lv.Controls)
                        {
                            if (ht.GetType() == typeof(HtmlSelect))
                            {
                                HtmlSelect hs = (HtmlSelect)ht;
                                hs.Disabled = true;
                            }
                        }
                    }
                    else
                    {
                        icb.Checked = true;
                        foreach (Control ht in lv.Controls)
                        {
                            if (ht.GetType() == typeof(HtmlSelect))
                            {
                                HtmlSelect hs = (HtmlSelect)ht;
                                hs.Disabled = false;
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

        private void invokeRadWindowJobs(string candId)
        {
            RadWindow rw = new RadWindow();
            rw.NavigateUrl = "~/candidate/WorkExperiencePopup.aspx?train_proj=" + Global.EncryptID(trainingProjectID) + "&cand=" + candId.ToString() + "&rowId=-1" + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri + "&workDates=" + sw.ToString();
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
        private void populateWorkingDates()
        {
            int i = 0;
            string stDate = "";
            string edDate = "";
            if (this.sqlDt.Rows.Count > 0)
            {
                workingDates = new string[sqlDt.Rows.Count, 2];
                XmlDocument xDoc = new XmlDocument();

                sw = new StringWriter();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(sw);
                xmlTextWriter.WriteStartDocument();
                xmlTextWriter.WriteStartElement("WorkingDates");
                //(2) string.Empty makes cleaner code
                i = 0;
                foreach (DataRow dr in sqlDt.Rows)
                {
                    xmlTextWriter.WriteStartElement("WorkDate");
                    stDate = string.IsNullOrEmpty(dr[8].ToString()) ? "" : dr[8].ToString();
                    xmlTextWriter.WriteElementString("StartDate", stDate);
                    edDate = string.IsNullOrEmpty(dr[9].ToString()) ? "" : dr[9].ToString();
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
                    i++;
                    xmlTextWriter.WriteEndElement();
                }
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteEndDocument();
                HttpContext.Current.Session.Add("workDates", sw.ToString());
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
        }
        private void GetCandidateWorkExperience(string candId)
        {
            CandidateWorkExperienceBAL candidate = new CandidateWorkExperienceBAL();
            double dCandId = Convert.ToDouble(candId);
            int iCandId = Global.DecryptID(dCandId);
            sqlDt = candidate.GetCandidateWorkExperience(iCandId.ToString());
            ViewState["Cand"] = sqlDt;
 
        }
        protected void ddCloseParticluarStepChanged(object sender, EventArgs e)
        {
            if (this.DdlCloseOfParticularStep.SelectedIndex == 0)
            {
                cSetFocus(this.DdlCloseOfParticularStep);
                this.DdlCloseOfParticularStep.Focus();
                return;
            }
            int iSelectedIndex = this.DdlCloseOfParticularStep.SelectedIndex;
            this.DdlOutcomes.Items.Clear();
            switch (iSelectedIndex)
            {
                case 1: 
                case 3:
                case 4:
                        this.DdlOutcomes.Items.Add(new ListItem { Text="Select", Value="-2"});
                        this.DdlOutcomes.Items.Add(new ListItem { Text="Yes", Value="1"});
                        this.DdlOutcomes.Items.Add(new ListItem { Text="No", Value="0"});
                    break;
                case 2: 
                case 5:
                case 7:
                        this.DdlOutcomes.Items.Add(new ListItem { Text="Select", Value="-2"});
                        this.DdlOutcomes.Items.Add(new ListItem { Text="Yes", Value="1"});
                        this.DdlOutcomes.Items.Add(new ListItem { Text="No", Value="0"});
                        this.DdlOutcomes.Items.Add(new ListItem { Text="NA", Value="2"});
                    break;
                case 6:
                        this.DdlOutcomes.Items.Add(new ListItem { Text = "Select", Value = "-2" });
                        this.DdlOutcomes.Items.Add(new ListItem { Text="Excellent", Value="Excellent"});
                        this.DdlOutcomes.Items.Add(new ListItem { Text="Very Good", Value="Very Good"});
                        this.DdlOutcomes.Items.Add(new ListItem { Text="Satisfactory", Value="Satisfactory"});
                        this.DdlOutcomes.Items.Add(new ListItem { Text="Needs Improvement", Value="Needs Improvement"});
                        this.DdlOutcomes.Items.Add(new ListItem { Text="Waived", Value="Waived"});
                        this.DdlOutcomes.Items.Add(new ListItem { Text="NA", Value="NA"});
                    break;

            }
            cSetFocus(this.DdlCloseOfParticularStep);
            this.DdlCloseOfParticularStep.Focus();
        }
        public void cSetFocus(Control control)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "focus", "document.getElementById('" + control.ClientID + "').focus();", true);

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