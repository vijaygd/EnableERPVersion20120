using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Training
{
    public partial class ListOfOpenTrainingProjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetUICulture(this.Page);
            Global.SetDefaultButtonOfTheForm(this.Form, BtnSearchOpenProject);

            //Global.ShowMessageInAlert(this.Form);
            if (!Page.IsPostBack)
            {
                TrainingProgramBAL programm = new TrainingProgramBAL();
                MySqlDataReader drProgramm = programm.GetTrainingProgramDetails("-1");
                Global.FillDropDown(DdlSelectProgram, drProgramm, "training_program_name", "training_program_id");
                DdlSelectProgram.Items[0].Text = "All";
                DdlSelectProgram.Items[0].Value = "-1";

                EnableIndia.App_Code.BAL.EmployeeBAL emp = new EnableIndia.App_Code.BAL.EmployeeBAL();
                DdlManagedBy.DataSource = emp.GetEmployeeList();
                DdlManagedBy.DataTextField = "employee_name";
                DdlManagedBy.DataValueField = "employee_id";
                DdlManagedBy.DataBind();
                // ((HtmlSelect)DropDown).Items.Insert(0, new ListItem("Select", "-2"));
                DdlManagedBy.Items.Insert(0, new ListItem("All", "-1"));
                Global.ShowMessageInAlert(this.Form);

            }
            Global.AuthenticateUser();

        }

        protected void BtnEnterTrainingProjectCycle_Click(object sender, EventArgs e)
        {
            foreach (ListViewDataItem item in LstViewTrainingProject.Items)
            {
                RadioButton RdbTrainingProject = (RadioButton)item.FindControl("RdbTrainingProject");
                if (RdbTrainingProject.Checked)
                {
                    string TrainingProjectID = RdbTrainingProject.Attributes["TrainingProjectID"].ToString();
                    string TrainingProgramID = RdbTrainingProject.Attributes["TrainingProgramID"].ToString();
                    Response.Redirect("~/Training/AddRecommendedCandidate.aspx?train_proj=" + TrainingProjectID + "&train_prog=" + TrainingProgramID, true);
                }
            }
        }

        protected void BtnViewAssignedList_Click(object sender, EventArgs e)
        {
            foreach (ListViewDataItem item in LstViewTrainingProject.Items)
            {
                RadioButton RdbTrainingProject = (RadioButton)item.FindControl("RdbTrainingProject");
                if (RdbTrainingProject.Checked)
                {
                    string TrainingProjectID = RdbTrainingProject.Attributes["TrainingProjectID"].ToString();
                    string TrainingProgramID = RdbTrainingProject.Attributes["TrainingProgramID"].ToString();
                    Response.Redirect("~/Training/AssignedList.aspx?train_proj=" + TrainingProjectID + "&train_prog=" + TrainingProgramID, true);
                }
            }
        }

        protected void BtnDeleteProject_Click(object sender, EventArgs e)
        {
            foreach (ListViewDataItem item in LstViewTrainingProject.Items)
            {
                RadioButton RdbTrainingProject = (RadioButton)item.FindControl("RdbTrainingProject");
                if (RdbTrainingProject.Checked)
                {
                    string TrainingProjectID = RdbTrainingProject.Attributes["TrainingProjectID"].ToString();
                    //string TrainingProgramID = RdbTrainingProject.Attributes["TrainingProgramID"].ToString();
                    //Response.Redirect("~/Training/AssignedList.aspx?train_proj=" + TrainingProjectID  true);
                    string message = String.Empty;
                    MySqlConnection conn = Global.GetConnectionString();
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("", conn);
                    cmd.CommandText = "delete from training_projects where training_project_id=" + Global.DecryptID(Convert.ToDouble(TrainingProjectID));
                    cmd.ExecuteNonQuery();

                    string script = String.Empty;

                    script = "alert('Project deleted successfully.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "__key", script, true);
                }
            }
            BtnSearchOpenProject_click(BtnSearchOpenProject, new EventArgs());
        }

        protected void BtnSearchOpenProject_click(object sender, EventArgs e)
        {
            try
            {
                EnableIndia.App_Code.BAL.TrainingProjectBAL training = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
                training.TrainingProgramID = Convert.ToInt32(DdlSelectProgram.Value);
                training.ProjectStatus = DdlSelectProjectStatus.Value;
                training.EmployeeID = Convert.ToInt32(DdlManagedBy.Value);
                try
                {

                    training.StartDateTime = Convert.ToDateTime(TxtStartDateFrom.Text.Trim()).ToString("yyyy/MM/dd");
                }
                catch
                {
                    training.StartDateTime = "1900/01/01";
                }
                try
                {
                    training.EndDateTime = Convert.ToDateTime(TxtStartDateTo.Text.Trim()).ToString("yyyy/MM/dd");
                }
                catch
                {
                    training.EndDateTime = "5000/01/01";
                }

                LstViewTrainingProject.DataSource = training.SearchOpenTrainingProjects(training);
                LstViewTrainingProject.DataBind();
                LstViewTrainingProject.Visible = true;
                if (LstViewTrainingProject.Items.Count.Equals(0))
                {
                    BtnEnterTrainingProjectCycle.Visible = false;
                    BtnViewAssignedList.Visible = false;
                    BtnDeleteProject.Visible = false;
                }
                else
                {
                    BtnEnterTrainingProjectCycle.Visible = true;
                    BtnViewAssignedList.Visible = true;
                    BtnDeleteProject.Visible = true;
                }
            }
            catch (System.Exception ex)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("Error: " + ex.Message);
            }
        }

        protected void LstViewTrainingProject_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl LblTrainingProgramName = (HtmlGenericControl)e.Item.FindControl("LblTrainingProgramName");
               // Label LblTrainingProgramName = (Label)e.Item.FindControl("LblTrainingProgramName");
                RadioButton RdbTrainingProject = (RadioButton)e.Item.FindControl("RdbTrainingProject");
                LblTrainingProgramName.Attributes.Add("for", RdbTrainingProject.ClientID);
                HtmlAnchor LnkTrainingProject = (HtmlAnchor)e.Item.FindControl("LnkTrainingProject"); 

                ListViewItem lvi = e.Item;
                RadioButton rb = (RadioButton)lvi.FindControl("RdbTrainingProject");
             //   rb.Attributes.Add("onclick", "rbClicked('" + e.Item.DataItemIndex + "')");

                string TrainingProjectID = RdbTrainingProject.Attributes["TrainingProjectID"].ToString();
                string TrainingProgramID = RdbTrainingProject.Attributes["TrainingProgramID"].ToString();

                if (LnkTrainingProject.InnerText == "")
                {
                    //RdbTrainingProject.Visible = false;
                    LnkTrainingProject.Visible = false;
                }
                else
                {
                    LnkTrainingProject.Visible = true;
                    //RdbTrainingProject.Visible = true;
                }
                if (LnkTrainingProject.InnerText == "Not Opened")
                {
                    LnkTrainingProject.HRef = "~/Training/AddTrainingProject.aspx?prog=" + TrainingProgramID;

                }
            }

        }
    }
}
// --------------------- end of module--------------------------
