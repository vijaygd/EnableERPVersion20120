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

    public partial class AddRecommendedCandidate : System.Web.UI.Page
    {
        public string IntStDate;
        public string IntEdDate;

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
            Global.SetDefaultButtonOfTheForm(this.Form, BtnSearchRecommendedCandidates);

            if (!Page.IsPostBack)
            {
                Global.ShowMessageInAlert(this.Form);
                string st1 = string.IsNullOrEmpty(Request.QueryString["comp"]) ? "" : "?comp=" + Request.QueryString["comp"].ToString();
                string st2 = string.IsNullOrEmpty(Request.QueryString["emp_proj"]) ? "" : "?emp_proj=" + Request.QueryString["emp_proj"].ToString();
                this.hCompId.Value = string.IsNullOrEmpty(Request.QueryString["comp"]) ? "" : Request.QueryString["comp"].ToString();
                this.hEmpProj.Value = string.IsNullOrEmpty(Request.QueryString["emp_proj"]) ? "" : Request.QueryString["emp_proj"].ToString();
                if (this.hCompId.Value.ToString().Contains("."))
                {
                    this.hCompId.Value = Global.DecryptID(Convert.ToDouble(this.hCompId.Value.ToString())).ToString();
                }
                if (this.hEmpProj.Value.ToString().Contains("."))
                {
                    this.hEmpProj.Value = Global.DecryptID(Convert.ToDouble(this.hEmpProj.Value.ToString())).ToString();
                }
                //LnkBtnCompanyDetails.HRef += "?comp=" + Request.QueryString["comp"].ToString(); 
                //LnkBtnEmploymentProjectDetails.HRef += "?emp_proj=" + Request.QueryString["emp_proj"].ToString();

                //LnkBtnAddNonRecommendedCandidates.PostBackUrl += "?emp_proj=" + Request.QueryString["emp_proj"].ToString() + "&comp=" + Request.QueryString["comp"].ToString();
                //LnkBtnAssignedList.PostBackUrl += "?emp_proj=" + Request.QueryString["emp_proj"].ToString() + "&comp=" + Request.QueryString["comp"].ToString();

                // LnkBtnCompanyDetails.HRef += st1;
                LnkBtnEmploymentProjectDetails.HRef += st2;

                LnkBtnAddNonRecommendedCandidates.PostBackUrl += st2 + st1;
                LnkBtnAssignedList.PostBackUrl += st2 + st1;


                Global glob = new Global();
                glob.GetAgeGroups(DdlAgeGroups);
                DdlAgeGroups.Items[0].Text = "all";
                DdlAgeGroups.Items[0].Value = "-1";

                DefaultsBAL def = new DefaultsBAL();
                DdlAgeGroups.Value = def.GetDefaultAgeGroupForSearch();

                EnableIndia.App_Code.BAL.EmploymentProjectBAL proj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
                if (string.IsNullOrEmpty(Request.QueryString["emp_proj"]))
                {
                    webMessageBox wb = new webMessageBox();
                    wb.Show("No employment project selected");
                    return;
                }
                string empProj = "";
                int i = Request.QueryString["emp_proj"].ToString().IndexOf("?");
                if (i > 0)
                {
                    empProj = Request.QueryString["emp_proj"].ToString().Substring(0, i);
                }
                else
                {
                    empProj = Request.QueryString["emp_proj"].ToString();
                }
                // MySqlDataReader drEmploymentProjectDetails = proj.GetEmploymentProjectDetails(Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])).ToString());
                MySqlDataReader drEmploymentProjectDetails = proj.GetEmploymentProjectDetails(Global.DecryptID(Convert.ToDouble(empProj)).ToString());

                if (drEmploymentProjectDetails.HasRows)
                {
                    drEmploymentProjectDetails.Read();
                    SpnEmploymentProjectName.InnerText = drEmploymentProjectDetails["employment_project_name"].ToString();
                    SpnCurrentDemand.InnerText = drEmploymentProjectDetails["current_demand_of_people"].ToString();
                }
                drEmploymentProjectDetails.Close();
                drEmploymentProjectDetails.Dispose();
                IntStDate = Request.QueryString["IntStDate"].ToString();
                IntEdDate = Request.QueryString["IntEdDate"].ToString();
                ViewState["IntStDate"] = IntStDate;
                ViewState["IntEdDate"] = IntEdDate;

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

        protected void BtnSearchRecommendedCandidates_Click(object sender, EventArgs e)
        {
            EnableIndia.App_Code.BAL.SearchCandidatesBAL search = new EnableIndia.App_Code.BAL.SearchCandidatesBAL();
            Request.Cookies["grid_page_number"].Value = "1";
            string empProj = "";
            int i = Request.QueryString["emp_proj"].ToString().IndexOf("?");
            if (i > 0)
            {
                empProj = Request.QueryString["emp_proj"].ToString().Substring(0, i);
            }
            else
            {
                empProj = Request.QueryString["emp_proj"].ToString();
            }
            // search.EmploymentProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"]));
            search.EmploymentProjectID = Global.DecryptID(Convert.ToDouble(empProj));
            search.AgeGroup = Convert.ToInt32(DdlAgeGroups.Value);
            search.SearchFor = TxtSearchFor.Text.Trim();
            search.SearchIn = DdlSearchIn.Value;
            search.Gender = Convert.ToInt32(DdlSelectGender.Value);
            LstViewRecommendedCandidate.DataSource = search.SearchRecommendedCandidatesForEmploymentProjects(search);
            LstViewRecommendedCandidate.DataBind();
        }

        protected void BtnSearchCandidates_Click(object sender, EventArgs e)
        {
            EnableIndia.App_Code.BAL.SearchCandidatesBAL search = new EnableIndia.App_Code.BAL.SearchCandidatesBAL();
            string empProj = "";
            int i = Request.QueryString["emp_proj"].ToString().IndexOf("?");
            if (i > 0)
            {
                empProj = Request.QueryString["emp_proj"].ToString().Substring(0, i);
            }
            else
            {
                empProj = Request.QueryString["emp_proj"].ToString();
            }
            //search.EmploymentProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"]));
            search.EmploymentProjectID = Global.DecryptID(Convert.ToDouble(empProj));
            search.AgeGroup = Convert.ToInt32(DdlAgeGroups.Value);
            search.SearchFor = TxtSearchFor.Text.Trim();
            search.SearchIn = DdlSearchIn.Value;
            search.Gender = Convert.ToInt32(DdlSelectGender.Value);
            LstViewRecommendedCandidate.DataSource = search.SearchRecommendedCandidatesForEmploymentProjects(search);
            LstViewRecommendedCandidate.DataBind();
        }

        protected void LstViewRecommendedCandidate_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                CheckBox ChkRecommendedCandidate = (CheckBox)e.Item.FindControl("ChkRecommendedCandidate");
                HtmlGenericControl LblCandidateName = (HtmlGenericControl)e.Item.FindControl("LblCandidateName");

                LblCandidateName.Attributes.Add("for", ChkRecommendedCandidate.ClientID);
            }
        }

        protected void BtnAddToAssignedList_Click(object sender, EventArgs e)
        {

            string empProj = "";
            int i = Request.QueryString["emp_proj"].ToString().IndexOf("?");
            if (i > 0)
            {
                empProj = Request.QueryString["emp_proj"].ToString().Substring(0, i);
            }
            else
            {
                empProj = Request.QueryString["emp_proj"].ToString();
            }
            //string employmentProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])).ToString();
            string employmentProjectID = Global.DecryptID(Convert.ToDouble(empProj)).ToString();
            string message = String.Empty;

            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand("", conn, trans);
            EnableIndia.App_Code.BAL.EmploymentProjectBAL proj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            string newValues = "";
            try
            {
                int candidatesAssigned = 0;
                foreach (ListViewItem item in LstViewRecommendedCandidate.Items)
                {
                    CheckBox ChkRecommendedCandidate = (CheckBox)item.FindControl("ChkRecommendedCandidate");
                    if (ChkRecommendedCandidate.Checked)
                    {
                        cmd = new MySqlCommand("", conn, trans);

                        string candidateID = Global.DecryptID(Convert.ToDouble(ChkRecommendedCandidate.Attributes["CandidateID"])).ToString();
                        proj.AssignCandidateToEmploymentProject(cmd, employmentProjectID, candidateID);
                        candidatesAssigned++;
                        newValues += "Candidate id: " + candidateID + ", ";
                    }
                }

                cmd = new MySqlCommand("", conn, trans);
                cmd.CommandType = CommandType.Text;
                //                proj.UpdateEmploymentProjectStatus(cmd, Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"])));
                proj.UpdateEmploymentProjectStatus(cmd, Global.DecryptID(Convert.ToDouble(empProj)));


                trans.Commit();
                if (!string.IsNullOrEmpty(newValues))
                {
                    int l = newValues.LastIndexOf((char)',');
                    if (l > 0)
                        newValues = newValues.Substring(0, l);
                }


                if (candidatesAssigned > 1)
                {
                    message = "Candidates assigned successfully.";
                    Global.createAuditTrial(this.Title, newValues, oldValues, null, "Update", Session["username"].ToString());
                    //Global.RedirectAfterSubmit("Company History Added Successfully.", BtnAddUpdateCompanyHistory.ID)
                }
                else
                {
                    message = "Candidate assigned successfully.";
                    Global.createAuditTrial(this.Title, newValues, "", null, "Insert", Session["username"].ToString());
                }
                // Response.Redirect(LnkBtnAssignedList.PostBackUrl + "&msg=" + message + "&foc=" + BtnSearchRecommendedCandidates.ID);

            }
            catch (Exception ex)
            {
                trans.Rollback();
                Response.Write(ex.Message);
            }
            finally
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "__maessage", "alert(\"" + message + "\");", true);
                //Global.RedirectAfterSubmit(message, BtnSearchNonRecommendedCandidates.ID);
                BtnSearchCandidates_Click(BtnSearchCandidates, new EventArgs());

                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        protected void LnkBtnAddNonRecommendedCandidates_Click(object sender, EventArgs e)
        {
            string url = "~/Company/AddNonRecommendedCandidate.aspx?emp_proj=" +  Global.EncryptID(Convert.ToInt32(this.hEmpProj.Value)) + "&comp=" + Global.EncryptID(Convert.ToInt32(this.hCompId.Value));
            url += "&IntStDate=" + IntStDate;
            url += "&IntEdDate=" + IntEdDate;
            Response.Redirect(url, false);
        }

        protected void LnkBtnAssignedList_click(object sender, EventArgs e)
        {
            string url = "~/Company/AssignedList.aspx?emp_proj=" + Global.EncryptID(Convert.ToInt32(this.hEmpProj.Value)) + "&comp=" + Global.EncryptID(Convert.ToInt32(this.hCompId.Value));
            url += "&IntStDate=" + IntStDate;
            url += "&IntEdDate=" + IntEdDate;
            //Response.Redirect("~/Company/AssignedList.aspx?emp_proj=" + Global.EncryptID(Convert.ToInt32(this.hEmpProj.Value)) + "&comp=" + Global.EncryptID(Convert.ToInt32(this.hCompId.Value)), false);
            Response.Redirect(url, false);
        }
        protected void btnCompanyDetClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Company/AddCompany.aspx?comp=" + Global.EncryptID(Convert.ToInt32(this.hCompId.Value)));
        }
        protected void EnableDisAllCb(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            foreach (ListViewItem lv in this.LstViewRecommendedCandidate.Items)
            {
                CheckBox icb = (CheckBox)lv.FindControl("ChkRecommendedCandidate");
                if (icb != null)
                {
                    if (cb.Checked)
                    {
                        icb.Checked = true;
                    }
                    else
                    {
                        icb.Checked = false;
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
        }
        private void storeValues()
        {
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