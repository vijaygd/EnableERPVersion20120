using System;
using System.Linq;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Company
{
    public partial class CandidateNotesForEmploymentProject : System.Web.UI.Page
    {
        public string EmploymentProjectID
        {
            get;
            set;
        }
        public int candidateID
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

          //  Global.SetDefaultButtonOfTheForm(this.Form, BtnSubmit);
            if (Request.QueryString["emp_proj"] != null)
            {
                this.EmploymentProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])).ToString();
            }
            else
            {
                this.EmploymentProjectID = "-2";
            }

            if (Request.QueryString["cand"] != null)
            {
                this.candidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"]));
            }
            else
            {
                this.candidateID = -1;
            }

            Global.SetUICulture(this.Page);
            //Global.SetDefaultButtonOfTheForm(this.Form, base);
            if (!Page.IsPostBack)
            {


                EmploymentProjectBAL proj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
                MySqlDataReader drEmploymentProjectDetails = proj.GetEmploymentProjectDetails(this.EmploymentProjectID);
                if (drEmploymentProjectDetails.HasRows)
                {
                    drEmploymentProjectDetails.Read();
                    SpnEmploymentProjectName.InnerText = drEmploymentProjectDetails["employment_project_name"].ToString();
                    SpnCurrentDemand.InnerText = drEmploymentProjectDetails["current_demand_of_people"].ToString();
                }
                drEmploymentProjectDetails.Close();
                drEmploymentProjectDetails.Dispose();


                CandidatesBAL cand = new CandidatesBAL();
                MySqlDataReader drCandidate = cand.GetCandidateDetails(this.candidateID.ToString());
                if (drCandidate.Read())
                {
                    SpnCandidateName.InnerText = drCandidate["first_name"].ToString() + " " + drCandidate["middle_name"].ToString() + "  " + drCandidate["last_name"].ToString();
                    SpnCandidateRID.InnerText = drCandidate["registration_id"].ToString();
                }
                drCandidate.Close();
                drCandidate.Dispose();
                Global.ShowMessageInAlert(this.Form);
                this.lbStartDate.Text = (string.IsNullOrEmpty( Request.QueryString["IntStDate"])?string.Empty: Request.QueryString["IntStDate"].ToString());
                this.lbEndDate.Text = (string.IsNullOrEmpty(Request.QueryString["IntEdDate"])?string.Empty: Request.QueryString["IntEdDate"].ToString());
                string textboxId = string.Empty;
                if (Request.QueryString["txboxId"] != null)
                    textboxId = Request.QueryString["txboxId"].ToString().Replace("'", string.Empty);
                this.txtParent.Value = textboxId;


            }
            GetCandidateNotes();
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }

        }


        protected void GetCandidateNotes()
        {
            EnableIndia.App_Code.BAL.EmploymentProjectBAL project = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            LstCandidateNotes.DataSource = project.GetCandidateWithNotes(this.EmploymentProjectID);
            LstCandidateNotes.DataBind();
        }

        protected void BtnResetDetail_click(object sender, EventArgs e)
        {
            Response.Redirect("~/Company/CandidateNotesForEmploymentProject.aspx?emp_proj=" + Request.QueryString["emp_proj"] + "&cand=" + Request.QueryString["cand"]);
        }

        protected void BtnSubmit_click(object sender, EventArgs e)
        {

            string message = String.Empty;

            EnableIndia.App_Code.BAL.EmploymentProjectBAL emp = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            emp.EmploymentProjectID = Convert.ToInt32(this.EmploymentProjectID);
            emp.CandidateID = this.candidateID;
            try
            {
                emp.InterviewDate = Convert.ToDateTime(TxtInterviewDate.Text.Trim()).ToString("yyyy/MM/dd");

            }
            catch
            {
                emp.InterviewDate = "1900/01/01";
            }
            try
            {
                emp.InterviewTime = Convert.ToDateTime(TxtInterviewTime.Text.Trim() + "" + DdlInteviewTime.Value).ToLongTimeString();
            }
            catch
            {
                emp.InterviewTime = "00:00:00";
            }
            if (emp.InterviewDate != "1900/01/01")
            {
                DateTime intDate = DateTime.ParseExact(this.TxtInterviewDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime stDate = DateTime.ParseExact(this.lbStartDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime edDate = DateTime.ParseExact(this.lbEndDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                int r1 = intDate.CompareTo(stDate);
                int r2 = intDate.CompareTo(edDate);
                if (r1 < 0 || r2 > 0)
                {
                    webMessageBox wb = new webMessageBox();
                    wb.Show("Entered interview date does not all in the period");
                    return;
                }
            }
            emp.InterpreterName = TxtLanguageInterpreterName.Text.Trim();
            emp.InterpreterDetail = TxtInterpreterContactDetails.Text.Trim();
            try
            {
                emp.PostInterviewDate = Convert.ToDateTime(TxtDateForPostInterView.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                emp.PostInterviewDate = "1900/01/01";
            }
            try
            {
                emp.PostInterviewTime = Convert.ToDateTime(TxtTimeForPostInterView.Text.Trim() + "" + DdlPostInterviewTime.Value).ToLongTimeString();
            }
            catch
            {
                emp.PostInterviewTime = "00:00:00";
            }
            emp.NoteComments = TxtComments.Text.Trim();

            ////added for task management
            if (TxtInterviewDate.Text != "" && TxtInterviewTime.Text != "")
            {
                CompaniesBAL company = new CompaniesBAL();

                company.HistoryDate = DateTime.Now.ToString("yyyy/MM/dd");


                company.Details = "";
                company.CandidateID = candidateID;
                company.CandidateFlagID = company.GetIDOfInterviewDateTime();
                company.EmployemntProjectID = Convert.ToInt32(this.EmploymentProjectID);
                MySqlDataReader drTaskdetail = company.GetCandidateNameRidForAddTask(company);
                if (drTaskdetail.Read())
                {
                    company.CompanyID = Convert.ToInt32(drTaskdetail["company_id"]);
                    company.ParentCompanyID = Convert.ToInt32(drTaskdetail["parent_company_id"]);

                    company.Details = drTaskdetail["candidate_name"].ToString() + ", ";
                    company.Details += drTaskdetail["RID"].ToString() + ", ";
                    company.Details += drTaskdetail["disability_type"].ToString() + ", ";
                    company.Details += drTaskdetail["employment_project_name"].ToString() + ", ";
                    company.Details += "Interview Date:" + TxtInterviewDate.Text + " ";
                    company.Details += "time:" + TxtInterviewTime.Text + "" + DdlInteviewTime.Value + " ";
                    if (emp.NoteComments != "")
                    {
                        company.Details += ", " + emp.NoteComments;
                    }
                }
                drTaskdetail.Close();
                drTaskdetail.Dispose();

                company.IsHistory = 1;
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

                    bool rowsAdded = company.AddCompanyHistory(company);

                    if (rowsAdded.Equals(true))
                    {
                        // employee.UpdateCandidateAssignedList(cmd, employee);
                        //message = "Assigned list updated successfully.";
                    }
                }
            }
            ////added for post inteview
            if (TxtDateForPostInterView.Text != "" && TxtTimeForPostInterView.Text != "")
            {
                CompaniesBAL company = new CompaniesBAL();

                company.HistoryDate = DateTime.Now.ToString("yyyy/MM/dd");


                company.Details = "";
                company.CandidateID = candidateID;
                company.CandidateFlagID = company.GetIDOfPostInterviewDateTime();
                company.EmployemntProjectID = Convert.ToInt32(this.EmploymentProjectID);
                MySqlDataReader drTaskdetail = company.GetCandidateNameRidForAddTask(company);
                if (drTaskdetail.Read())
                {
                    company.CompanyID = Convert.ToInt32(drTaskdetail["company_id"]);
                    company.ParentCompanyID = Convert.ToInt32(drTaskdetail["parent_company_id"]);

                    company.Details = drTaskdetail["candidate_name"].ToString() + ", ";
                    company.Details += drTaskdetail["RID"].ToString() + ", ";
                    company.Details += drTaskdetail["disability_type"].ToString() + ", ";
                    company.Details += drTaskdetail["employment_project_name"].ToString() + ", ";
                    company.Details += "Date For Post Interview follow up with Company:" + TxtDateForPostInterView.Text + " ";
                    company.Details += "time:" + TxtTimeForPostInterView.Text + "" + DdlPostInterviewTime.Value + " ";
                    if (emp.NoteComments != "")
                    {
                        company.Details += "," + emp.NoteComments;
                    }
                }
                drTaskdetail.Close();
                drTaskdetail.Dispose();

                company.IsHistory = 1;
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

                    bool rowsAdded = company.AddCompanyHistory(company);

                    if (rowsAdded.Equals(true))
                    {
                        // employee.UpdateCandidateAssignedList(cmd, employee);
                        //message = "Assigned list updated successfully.";
                    }
                }
            }


            bool rowAdded = emp.AddEmploymentProjectNotes(emp);

            if (rowAdded.Equals(true))
            {
                message = "Note added successfully.";
            }
            else
            {
                message = "Error occurred. Please contact the administrator.";
            }
            Global.RedirectAfterSubmit(message, BtnSubmit.ID);

        }
        protected void btnCloseClick(object sender, EventArgs e)
        {
            string url = "self.close();self.parent.location.replace('" + this.txtParent.Value + "')";
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

    }
}