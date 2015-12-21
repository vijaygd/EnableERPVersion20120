using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Reflection;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


namespace EnableIndia.date.ProfileHistory
{

    public partial class AddViewCandidateHistoryPopup : System.Web.UI.Page
    {
        public string oldValues;

        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetDefaultButtonOfTheForm(this.Form, BtnAddUpdateCandiateHistory);
            Global.AuthenticateUser();
            Global.SetUICulture(this.Page);
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }

            if (!Page.IsPostBack)
            {
                this.txtParent.Value = Request.QueryString["txboxId"];
                CandidateFlagsBAL candidateHistory = new CandidateFlagsBAL();
                MySqlDataReader drCandidateHistory = candidateHistory.GetCandidateFlags();
                Global.FillDropDown(DdlFlags, drCandidateHistory, "flag_name", "flag_id");

                EnableIndia.App_Code.BAL.EmployeeBAL employee = new EnableIndia.App_Code.BAL.EmployeeBAL();
                DdlTaskManagedByEmployee.DataSource = employee.GetEmployeeList();
                DdlTaskManagedByEmployee.DataTextField = "employee_name";
                DdlTaskManagedByEmployee.DataValueField = "employee_id";
                DdlTaskManagedByEmployee.DataBind();

                if (DdlTaskManagedByEmployee.Items.Count > 0)
                {
                    DdlTaskManagedByEmployee.Items.Insert(0, new ListItem("Select", "-2"));
                }
                else
                {
                    DdlTaskManagedByEmployee.Items.Add(new ListItem("Not Available", "-2"));
                }
                LblUpdateStatus.Visible = false;
                DdlUpdateStatus.Visible = false;

                if (Request.QueryString["hist"] != null)
                {
                    BtnDeleteCandidateHistory.Visible = true;
                    TblMessageUpdate.Visible = true;
                    GetCandidateHistoryDetails();
                }
                Global.ShowMessageInAlert(this.Form);
                if (Request.QueryString["hist"] == null)
                {
                    TblMessageAdd.Visible = true;
                    SpnDate.InnerText = DateTime.Today.ToString("dd/MM/yyyy");
                }
            }
            GetCandidateDetail();
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

        private void GetCandidateDetail()
        {
            CandidatesBAL cand = new CandidatesBAL();
            MySqlDataReader drCandidateDetails = cand.GetCandidateDetails(Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString());
            if (drCandidateDetails.Read())
            {
                SpnCandidateName.InnerText = drCandidateDetails["candidate_name"].ToString();
                SpnRID.InnerText = drCandidateDetails["registration_id"].ToString();

                drCandidateDetails.Close();
                drCandidateDetails.Dispose();
            }
        }

        private void GetCandidateHistoryDetails()
        {
            CandidateHistoryBAL history = new CandidateHistoryBAL();
            string historyID = Global.DecryptID(Convert.ToDouble(Request.QueryString["hist"])).ToString();
            MySqlDataReader drCandidateHistory = history.GetCandidateHistoryDetails(historyID);
            if (drCandidateHistory.Read())
            {
                SpnDate.InnerText = Convert.ToDateTime(drCandidateHistory["history_date"]).ToString("dd/MM/yyyy");
                TxtDetails.Text = drCandidateHistory["details"].ToString();
                DdlFlags.Value = drCandidateHistory["candidate_flag_id"].ToString();

                if (Convert.ToInt32(DdlFlags.Value) > 1)
                {
                    DdlFlags.Items.Remove(DdlFlags.Items.FindByValue("1"));
                }

                DdlTaskManagedByEmployee.Value = drCandidateHistory["assigned_to_employee_id"].ToString();
                TxtRecommendedAction.Text = drCandidateHistory["recommended_action"].ToString();
                //changes for changes in follow of date 
                if (drCandidateHistory["follow_up_date"].ToString().Contains("1900"))
                {
                    TxtFollowUpDate.Text = "";
                }
                else
                {
                    TxtFollowUpDate.Text = Convert.ToDateTime(drCandidateHistory["follow_up_date"]).ToString("dd/MM/yyyy");
                }
                LblUpdateStatus.Visible = true;
                DdlUpdateStatus.Visible = true;
                DdlUpdateStatus.Value = drCandidateHistory["status"].ToString();

                BtnAddUpdateCandiateHistory.Text = BtnAddUpdateCandiateHistory.Text.Replace("Add", "Update");
                BtnAddUpdateCandiateHistory.ToolTip = BtnAddUpdateCandiateHistory.ToolTip.Replace("Add", "Update");
                if (drCandidateHistory["status"].ToString().Contains("Closed"))
                {
                    //TxtDetails.Enabled = false;
                    TxtDetails.Enabled = false;
                    DdlTaskManagedByEmployee.Disabled = true;
                    DdlFlags.Disabled = true;
                    TxtRecommendedAction.Enabled = false;
                    TxtFollowUpDate.Enabled = false;
                    DdlUpdateStatus.Disabled = true;
                }
                drCandidateHistory.Close();
                drCandidateHistory.Dispose();
            }
        }

        private void MsgBox(string message)
        {
            webMessageBox wb = new webMessageBox();
            wb.Show(message);
        }
        protected void BtnAddUpdateCandiateHistory_Click(object sender, EventArgs e)
        {
            string message = "";
            if (string.IsNullOrEmpty(this.TxtDetails.Text))
            {
                MsgBox("Details cannot be empty");
                return;
            }
            if (this.DdlFlags.SelectedIndex <= 0)
            {
                MsgBox("One flag must be selected");
                return;
            }
            CandidateHistoryBAL history = new CandidateHistoryBAL();

            if (Request.QueryString["hist"] != null)
            {
                history.HistoryID = Global.DecryptID(Convert.ToDouble(Request.QueryString["hist"]));
            }

            history.CandidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"]));

            try
            {
                history.HistoryDate = Convert.ToDateTime(SpnDate.InnerText.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                history.HistoryDate = DateTime.Now.ToString("yyyy/MM/dd");
            }

            history.Details = TxtDetails.Text.Trim();
            history.CandidateFlagID = Convert.ToInt32(DdlFlags.Value);
            history.EmployeeID = Convert.ToInt32(DdlTaskManagedByEmployee.Value);
            history.RecommendedAction = TxtRecommendedAction.Text.Trim();

            try
            {
                history.FollowUpDate = Convert.ToDateTime(TxtFollowUpDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                history.FollowUpDate = "1900/01/01";
            }

            history.Status = Convert.ToString(DdlUpdateStatus.Value);

            string newValues = "";
            Type type = history.GetType();
            PropertyInfo[] proterties = type.GetProperties();
            foreach (var p in proterties)
            {
                newValues += "<b>" + p.Name + ": </b>" + p.GetValue(history, null) + ", ";
            }
            if (!string.IsNullOrEmpty(newValues))
            {
                int l = newValues.LastIndexOf((char)',');
                if (l > 0)
                    newValues = newValues.Substring(0, l);
            }
            if (Request.QueryString["hist"] != null)
            {

                bool rowsUpdated = history.UpdateCandidateHistory(history);

           if (rowsUpdated.Equals(true))
                {
                    Global.createAuditTrial(this.Title, newValues, oldValues, null, "Update", Session["username"].ToString());
                    message = "Candidate History Updated Successfully.";
                }
            }
            else
            {
                bool rowsAdded = history.AddCandidateHistory(history);

                if (rowsAdded.Equals(true))
                {
                    Global.createAuditTrial(this.Title, newValues, "", null, "Insert", Session["username"].ToString());
                    message = "Candidate History Added Successfully.";
                }
            }
            closePage(message);
        }

        protected void BtnDeleteCandidateHistory_Click(object sender, EventArgs e)
        {
            string message = "";
            CandidateHistoryBAL history = new CandidateHistoryBAL();
            int isDeleted = history.DeleteCandidateHistory(Global.DecryptID(Convert.ToDouble(Request.QueryString["hist"])), Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])));
            string script = String.Empty;

            if (isDeleted > 0)
            {
                message = "Candidate history deleted successfully";
            }
            else
            {
                message = "Unable to delete";
            }
            closePage(message);
        }
        private void closePage(string message)
        {
            string url = "";
            if (string.IsNullOrEmpty(message))
            {
                url = "self.parent.location.replace('" + this.txtParent.Value + "')";
            }
            else
            {
                url = "window.alert('" + message + "');self.parent.location.replace('" + this.txtParent.Value + "');";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", url, true);
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
    }
}