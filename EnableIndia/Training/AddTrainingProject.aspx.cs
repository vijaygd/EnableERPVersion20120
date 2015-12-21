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
using Telerik;
using Telerik.Web.UI;
namespace EnableIndia.Training
{
    public partial class AddTrainingProject : System.Web.UI.Page
    {

        public string TrainingProjectID
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
            if (Request.RawUrl.Contains("proj"))
            {
                Page.Title = "Update Training Project";
                LblTitle.Text = "Update Training Project";
                LblTitle.Attributes["MessageStartText"] = "Update";
                TblProjectName.Visible = true;
            }
            Global.SetUICulture(this.Page);
            Global.AuthenticateUser();
            Global.SetDefaultButtonOfTheForm(this.Form, BtnManageTrainingProject);

            if (Request.QueryString["proj"] != null)
            {
                this.TrainingProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["proj"])).ToString();
            }
            else
            {
                this.TrainingProjectID = "-2";
            }
            if(Page.IsPostBack)
            {
                if (ViewState["TrainingProjectID"] != null)
                    this.TrainingProjectID = ViewState["TrainingProjectID"].ToString();

            }


            if (!Page.IsPostBack)
            {
                Global.ShowMessageInAlert(this.Form);

                EnableIndia.App_Code.BAL.TrainingProgramBAL program = new EnableIndia.App_Code.BAL.TrainingProgramBAL();
                MySqlDataReader drTrainingPrograms = program.GetTrainingProgramDetails("-1");
                Global.FillDropDown(DdlTrainingPrograms, drTrainingPrograms, "training_program_name", "training_program_id");

                if (Request.RawUrl.Contains("prog"))
                {
                    DdlTrainingPrograms.Value = Global.DecryptID(Convert.ToDouble(Request.QueryString["prog"])).ToString();
                    DdlTrainingPrograms.Disabled = true;
                }

                EnableIndia.App_Code.BAL.EmployeeBAL emp = new EnableIndia.App_Code.BAL.EmployeeBAL();
                DdlEmployees.DataSource = emp.GetEmployeeList();
                DdlEmployees.DataTextField = "employee_name";
                DdlEmployees.DataValueField = "employee_id";
                DdlEmployees.DataBind();
                if (DdlEmployees.Items.Count > 0)
                {
                    DdlEmployees.Items.Insert(0, new ListItem("Select", "-2"));
                }
                else
                {
                    DdlEmployees.Items.Add(new ListItem("Not Available", "-2"));
                }


                EnableIndia.App_Code.BAL.CompaniesBAL comp = new App_Code.BAL.CompaniesBAL();
                DdlCompanies.DataSource = comp.GetCompanies("-1");
                DdlCompanies.DataTextField = "company_code";
                DdlCompanies.DataValueField = "company_id";
                DdlCompanies.DataBind();

                if (DdlCompanies.Items.Count > 0)
                {
//                    DdlCompanies.Items.Insert(0, new ListItem("Select", "-2"));
                    DdlCompanies.Items.Insert(0, new RadComboBoxItem("Select", "-2"));
                    // Enable the checkboxes....
                    if (this.TrainingProjectID != "-2")
                    {
                        setEmployeeCheckBoxes();
                    }
                    
                }
                else
                {
                   // DdlCompanies.Items.Add(new ListItem("Not Available", "-2"));
                    DdlCompanies.Items.Add(new RadComboBoxItem("Not Available", "-2"));
                }

                if (Request.QueryString["proj"] != null)
                {
                    //TblProjectStatus.Visible = true;
                    GetTrainingProjectDetails();
                    DdlTrainingPrograms.Disabled = true;
                    BtnClear.Visible = false;
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

        private void GetTrainingProjectDetails()
        {
            EnableIndia.App_Code.BAL.TrainingProjectBAL project = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            MySqlDataReader drTrainingProjectDetails = project.GetTrainingProjectDetails(this.TrainingProjectID);

            if (drTrainingProjectDetails != null)
            {
                if (drTrainingProjectDetails.Read())
                {
                    SpnTrainingProjectName.InnerText = drTrainingProjectDetails["training_project_name"].ToString();
                    DdlTrainingPrograms.Value = drTrainingProjectDetails["training_program_id"].ToString();
                    TxtStartDate.Text = Convert.ToDateTime(drTrainingProjectDetails["start_date_time"]).ToString("dd/MM/yyyy");
                    TxtEndDate.Text = Convert.ToDateTime(drTrainingProjectDetails["end_date_time"]).ToString("dd/MM/yyyy");

                    if (drTrainingProjectDetails["start_time"].ToString().Contains("AM"))
                    {
                        DdlTimeFrom.Value = "AM";
                        TxtFromTime.Text = drTrainingProjectDetails["start_time"].ToString().Replace("AM", "");
                    }
                    else
                    {
                        DdlTimeFrom.Value = "PM";
                        TxtFromTime.Text = drTrainingProjectDetails["start_time"].ToString().Replace("PM", "");
                    }

                    if (drTrainingProjectDetails["end_time"].ToString().Contains("AM"))
                    {
                        DdlTimeTo.Value = "AM";
                        TxtToTime.Text = drTrainingProjectDetails["end_time"].ToString().Replace("AM", "");
                    }
                    else
                    {
                        DdlTimeTo.Value = "PM";
                        TxtToTime.Text = drTrainingProjectDetails["end_time"].ToString().Replace("PM", "");
                    }

                    TxtBatchSize.Text = drTrainingProjectDetails["batch_size"].ToString();
                    DdlEmployees.Value = drTrainingProjectDetails["employee_id"].ToString();

                    TxtVenue.Text = drTrainingProjectDetails["venue"].ToString();
                    TxtProjectDays.Text = drTrainingProjectDetails["days"].ToString();
                    DdlProjectType.Value = drTrainingProjectDetails["project_type"].ToString();
                    TxtComments.Text = drTrainingProjectDetails["comments"].ToString();
                    //DdlProjectStatus.Value = drTrainingProjectDetails["project_status"].ToString();

                    drTrainingProjectDetails.Close();
                    drTrainingProjectDetails.Dispose();
                }
                else
                {
                    Response.Redirect("~/Training/AddTrainingProject.aspx", true);
                }
            }
            else
            {
                Response.Redirect("~/Training/AddTrainingProject.aspx", true);

            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["proj"] != null)
            {
                Response.Redirect("~/Training/AddTrainingProject.aspx", true);
            }
            else
            {
                Response.Redirect("~/Training/AddTrainingProject.aspx", true);
            }
        }

        protected void BtnManageTrainingProject_Click(object sender, EventArgs e)
        {
            if (this.DdlTrainingPrograms.SelectedIndex <= 0)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("Please select training program");
                return;
            }
            EnableIndia.App_Code.BAL.TrainingProjectBAL project = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
            project.TrainingProgramID = Convert.ToInt32(DdlTrainingPrograms.Value);

            project.StartDateTime = Convert.ToDateTime(TxtStartDate.Text.Trim()).ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(TxtFromTime.Text.Trim() + " " + DdlTimeFrom.Value).ToLongTimeString();
            project.EndDateTime = Convert.ToDateTime(TxtEndDate.Text.Trim()).ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(TxtToTime.Text.Trim() + " " + DdlTimeTo.Value).ToLongTimeString();

            DateTime stDate = Convert.ToDateTime(this.TxtStartDate.Text);
            DateTime edDate = Convert.ToDateTime(this.TxtEndDate.Text);
            int dResult = DateTime.Compare(stDate, edDate);
            if (dResult > 0)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("Start date is greater than end date");
                return;
            }

            try
            {
                project.BatchSize = Convert.ToInt32(TxtBatchSize.Text.Trim());
            }
            catch
            {
                project.BatchSize = 0;
            }
            int fempId = 0;
            for (int i = 0; i < this.DdlCompanies.Items.Count; i++)
            {
                if (this.DdlCompanies.Items[i].Checked == true)
                {
                    if (fempId == 0) fempId = Convert.ToInt32(DdlCompanies.Items[i].Value);
                    EnableIndia.App_Code.BAL.TrainingProjectBAL.respfortraining rf = new EnableIndia.App_Code.BAL.TrainingProjectBAL.respfortraining();

                    rf.programId = project.TrainingProgramID;
                    rf.projectId = project.TrainingProjectID;
                    rf.company_id = Convert.ToInt32(DdlCompanies.Items[i].Value.ToString());
                    project.rft.Add(rf);
                }
            }
            project.EmployeeID = Convert.ToInt32(DdlEmployees.Value);

            project.ProjectVenue = TxtVenue.Text.Trim();
            project.ProjectDays = TxtProjectDays.Text.Trim();
            project.ProjectType = DdlProjectType.Value;
            project.Comments = TxtComments.Text.Trim();
            //forceRefresh();

            //project.ProjectStatus = DdlProjectStatus.Value;
            string newValues = "<b>Train Proj Id: </b>" + this.TrainingProjectID + ", ";
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
            // Add selected values..... 01.12.2015

                if (this.TrainingProjectID.Equals("-2"))
                {
                    project.TrainingProjectID = project.AddTrainingProject(project);
                    ViewState["TrainingProjectID"] = this.TrainingProjectID;
                    if (project.TrainingProjectID > 0)
                    {
                        string url = "~/Training/AddTrainingProject.aspx?proj=" + Global.EncryptID(Convert.ToInt32(project.TrainingProjectID));
                        url += "&msg=" + Global.EncryptQueryString("Training project added successfully.");
                        url += "&foc=" + Global.EncryptQueryString("null");
                        Global.createAuditTrial(this.Title, newValues, "", null, "Insert", Session["username"].ToString());
                        Response.Redirect(url, true);

                    }
                    else
                    {
                        Global.RedirectAfterSubmit("Error occurred. Please contact the administrator.", BtnManageTrainingProject.ID);
                    }
                }
                else
                {
                    project.TrainingProjectID = Convert.ToInt32(this.TrainingProjectID);
                    int rowsUpdated = project.UpdateTrainingProject(project);
                    if (rowsUpdated > 0)
                    {
                        string url = "~/Training/AddTrainingProject.aspx?proj=" + Global.EncryptID(Convert.ToInt32(this.TrainingProjectID));
                        url += "&msg=" + Global.EncryptQueryString("Training project updated successfully.");
                        url += "&foc=" + Global.EncryptQueryString("null");
                        Global.createAuditTrial(this.Title, newValues, oldValues, null, "Update", Session["username"].ToString());
                        Response.Redirect(url, true);
                    }
                    else
                    {
                        Global.RedirectAfterSubmit("Error occurred. Please contact the administrator.", BtnManageTrainingProject.ID);
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
            oldValues = "<b>Proj Id: </b>" + this.TrainingProjectID +  ", ";
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
        private void setEmployeeCheckBoxes()
        {
            EnableIndia.App_Code.BAL.TrainingProjectBAL tpb = new App_Code.BAL.TrainingProjectBAL();
            tpb.TrainingProgramID = Global.DecryptID(Convert.ToDouble(Request.QueryString["prog"]));
            tpb.TrainingProjectID = Convert.ToInt32(this.TrainingProjectID);
            MySqlDataReader reader = tpb.GetTrainingProjectResponsibleBAL(tpb);
            if (reader != null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int k = 0; k < DdlCompanies.Items.Count; k++)
                        {
                            if (this.DdlCompanies.Items[k].Value.ToString() == reader.GetValue(2).ToString())
                            {
                                this.DdlCompanies.Items[k].Checked = true;
                            }
                        }
                    }

                }
                reader.Close();
                reader.Dispose();
            }

        }
    }
}