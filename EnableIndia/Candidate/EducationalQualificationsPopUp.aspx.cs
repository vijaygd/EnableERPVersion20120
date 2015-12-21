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

namespace EnableIndia.Candidate
{
    public partial class EducationalQualificationsPopUp : System.Web.UI.Page
    {
        [Serializable]
        public struct qualifications
        {
            public string qual;
            public string year;
        }
        qualifications[] quals;
        [Serializable]
        public struct OrgValues
        {
            public string orgQual;
            public string orgPass;
            public string orgPer;
        }
        OrgValues oValues = new OrgValues();
        public string oldValues;

        public string sIndex
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

            Global.SetDefaultButtonOfTheForm(this.Form, BtnAddUpdateQualifications);
            if (!Page.IsPostBack)
            {
                if (Session["eduArray"] != null)
                {
                    string[,] quls  = (string[,])(Session["eduArray"]);
                    Session.Remove("eduArray");
                    quals = new qualifications [quls.GetLength(0)];
                    for (int i = 0; i < quls.GetLength(0); i++)
                    {
                        quals[i].qual = quls[i, 0];
                        quals[i].year = quls[i, 1];
                    }
                    ViewState["eduArray"] = quals;

                }
                this.txtParent.Value = Request.QueryString["txboxId"];
                EnableIndia.App_Code.BAL.EducationBAL edu = new EnableIndia.App_Code.BAL.EducationBAL();
                MySqlDataReader drEducationalQualifications = edu.GetEducations();
                Global.FillDropDown(DdlCoursesQualifications, drEducationalQualifications, "course_qualification_name", "course_qualification_id");
                if(Request.QueryString["Index"] != null)
                {
                    sIndex = Request.QueryString["Index"];
                    ViewState["sIndex"] = sIndex;
                }
                else
                {
                    sIndex = string.Empty;
                }
                if (Request.QueryString["cand_qual"] != null)
                {
                    BtnDeleteQualification.Visible = true;
                    GetCandidateQualificatrionDetails();
                }
                else
                {
                    CandidatesBAL cand = new CandidatesBAL();
                    MySqlDataReader drCand = cand.GetCandidateDetails(Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString());

                    if (drCand.Read())
                    {

                        TxtOtherEducationalQualifications.Text = drCand["other_educational_qualifications"].ToString();
                    }
                    drCand.Close();
                    drCand.Dispose();
                }
                Global.ShowMessageInAlert(this.Form);
            }
            if (Page.IsPostBack)
            {
                if(ViewState["eduArray"] != null)
                {
                     quals = (qualifications[])ViewState["eduArray"];
                }
                if(ViewState["orgValues"] != null)
                {
                    oValues = new OrgValues();
                    oValues = (OrgValues)ViewState["orgValues"];
                }
                if(ViewState["sIndex"] != null)
                    sIndex = ViewState["sIndex"].ToString();
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

        private void GetCandidateQualificatrionDetails()
        {
            CandidateEducationalQualificationsBAL canEdu = new CandidateEducationalQualificationsBAL();
            string qualificationID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand_qual"])).ToString();
            MySqlDataReader drQualificationDetails = canEdu.GetCandidateEducationalQualificationDetails(qualificationID);

            if (drQualificationDetails.Read())
            {

                DdlCoursesQualifications.Value = drQualificationDetails["course_qualification_id"].ToString();
                TxtPassingYear.Text = drQualificationDetails["passing_year"].ToString();
                if (drQualificationDetails["percentage"].ToString().Equals("0.00"))
                {
                    TxtPercentage.Text = "";
                }
                else
                {
                    TxtPercentage.Text = drQualificationDetails["percentage"].ToString();
                }
                TxtDetails.Text = drQualificationDetails["details"].ToString();
                TxtOtherEducationalQualifications.Text = drQualificationDetails["other_educational_qualifications"].ToString();

                BtnAddUpdateQualifications.Text = BtnAddUpdateQualifications.Text.Replace("Submit", "Update");
                BtnAddUpdateQualifications.ToolTip = BtnAddUpdateQualifications.ToolTip.Replace("Submit", "Update");
            }
            drQualificationDetails.Close();
            drQualificationDetails.Dispose();
            oValues.orgQual = DdlCoursesQualifications.Value;
            oValues.orgPass = TxtPassingYear.Text;
            oValues.orgPer = TxtPercentage.Text;
            ViewState["orgValues"] = oValues;

        }

        protected void BtnDeleteQualification_click(object sender, EventArgs e)
        {
            CandidateEducationalQualificationsBAL delete = new CandidateEducationalQualificationsBAL();
            bool isDeleted = delete.DeleteEducationalQualifications(Global.DecryptID(Convert.ToDouble(Request.QueryString["cand_qual"])).ToString(), Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString());
            string script = String.Empty;

            if (isDeleted.Equals(true))
            {
                //script = "alert('Educational qualification deleted successfully.');self.close();";
                //ClientScript.RegisterStartupScript(this.GetType(), "__key", script, true);
                closePage("Educational qualification deleted successfully.");
            }
            else
            {
                //script = "alert('" + Global.GetGlobalErrorMessage() + "');";
                //ClientScript.RegisterStartupScript(this.GetType(), "__key", script, true);
                closePage("Unable to Delete");
            }

        }

        protected void BtnAddUpdateQualifications_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            bool bMatch = false;
            if (quals != null)
            {
                if (quals.GetLength(0) > 0)
                {
                    if (this.BtnAddUpdateQualifications.Text != "Update")
                    {
                        for (i = 0; i < quals.GetLength(0); i++)
                        {
                            if (this.DdlCoursesQualifications.Value.ToString().Trim() == quals[i].qual.Trim())
                            {
                                bMatch = true;
                                break;
                            }
                        }
                        if (bMatch)
                        {
                            MsgBox("Qualification already exists".ToString());
                            return;
                        }
                        int eYear = Convert.ToInt32(this.TxtPassingYear.Text);
                        int aLengh = quals.GetLength(0);
                        // Sort the array.....
                        qualifications[] tquals = quals.OrderBy(x => x.year).ToArray();
                        if (!string.IsNullOrEmpty(this.TxtPassingYear.Text))
                        {
                            for (i = Convert.ToInt32(tquals[0].year); i <= Convert.ToInt32(tquals[aLengh - 1].year); i++)
                            {
                               if(i == eYear)
                               {
                                   bMatch = true;
                                   break;
                               }
                            }
                            if (bMatch)
                            {
                                   MsgBox("Passing year already used".ToString());
                                   return;
                            }
                        }
                    }
                    else
                    {
                        // First find the equivelant index under the existing drop down...
                        if (quals.GetLength(0) > 1)
                        {
                            for (i = 0; i < quals.GetLength(0); i++)
                            {
                                if (oValues.orgQual == this.DdlCoursesQualifications.Value)
                                {
                                    for (j = i; j < quals.GetLength(0); j++)
                                    {

                                        if (this.TxtPassingYear.Text == quals[j].year)
                                        {
                                            bMatch = true;
                                            break;
                                        }
                                    }
                                    if (bMatch)
                                    {
                                        if(!string.IsNullOrEmpty(sIndex))
                                            if (j != Convert.ToInt32(sIndex))
                                            {
                                                MsgBox("Passing year already used".ToString());
                                                return;
                                            }
                                    }
                                }
                                if (this.TxtPassingYear.Text == quals[i].year)
                                {
                                    bMatch = true;
                                    break;
                                }
                            }
                            if (bMatch)
                            {
                                if (!string.IsNullOrEmpty(sIndex))
                                {
                                    if (i != Convert.ToInt32(sIndex))
                                    {
                                        MsgBox("Passing year already used".ToString());
                                        return;
                                    }
                                }
                            }
                        }
                    }

                }
            }
            string message = "";
            string script = String.Empty;
            CandidateEducationalQualificationsBAL candEdu = new CandidateEducationalQualificationsBAL();
            if (Request.QueryString["cand_qual"] != null)
            {
                candEdu.CandidateQualificationID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand_qual"]));
            }

            candEdu.CandidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"]));
            candEdu.CourseQualificationID = Convert.ToInt32(DdlCoursesQualifications.Value);

            try
            {
                candEdu.PassingYear = Convert.ToInt32(TxtPassingYear.Text.Trim());
            }
            catch
            {
                candEdu.PassingYear = DateTime.Now.Year;
            }

            try
            {
                candEdu.Percentage = Convert.ToDecimal(TxtPercentage.Text.Trim());
            }
            catch
            {
                candEdu.Percentage = 0;
            }

            candEdu.Details = TxtDetails.Text.Trim();
            candEdu.OtherEducationalQualification = TxtOtherEducationalQualifications.Text.Trim();
           
            BtnAddUpdateQualifications.Attributes.Add("onclick", "this.disabled=true;" + GetPostBackEventReference(BtnAddUpdateQualifications).ToString());
            string errorMessage = "";
            string newValues = "";
            Type type = candEdu.GetType();
            PropertyInfo[] proterties = type.GetProperties();
            foreach (var p in proterties)
            {
                newValues += "<b>" + p.Name + ": </b>" + p.GetValue(candEdu, null) + ", ";
            }
            if (!string.IsNullOrEmpty(newValues))
            {
                int l = newValues.LastIndexOf((char)',');
                if (l > 0)
                    newValues = newValues.Substring(0, l);
            }

            if (Request.QueryString["cand_qual"] != null)
            {
                int rowsUpdated = candEdu.UpdateCandidateEducationalQualification(candEdu, out errorMessage);
                if (rowsUpdated > 0)
                {
                    Global.createAuditTrial(this.Title, newValues, oldValues, null, "Update", Session["username"].ToString());
                    message = "Educational qualification updated successfully.";
                }
            }
            else
            {
                int rowsAdded = candEdu.AddCandidateEducationalQualification(candEdu, out errorMessage);
                if (rowsAdded > 0)
                {
                    Global.createAuditTrial(this.Title, newValues, "", null, "Insert", Session["username"].ToString());
                    message = "Educational qualification added successfully.";
                }
            }
            BtnAddUpdateQualifications.Enabled = true;
            closePage(message);
        }
        private void MsgBox(string message)
        {
            webMessageBox wb = new webMessageBox();
            wb.Show(message);
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
            // Response.Redirect(this.txtParent.Value);
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