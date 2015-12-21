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

namespace EnableIndia.Candidate
{

    public partial class ViewCandidateCallingList : System.Web.UI.Page
    {
        int trainingProjectID
        {
            get;
            set;
        }
        int employmentProjectID
        {
            get;
            set;
        }
        public DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["train_proj"]))
            {
                this.trainingProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["train_proj"]));
            }
            else
            {
                this.trainingProjectID = -1;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["emp_proj"]))
            {
                this.employmentProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["emp_proj"]));
            }
            else
            {
                this.employmentProjectID = -1;
            }
            Global.ShowMessageInAlert(this.Form);


            if (!Page.IsPostBack)
            {
                if (Request.RawUrl.Contains("train_proj"))
                {
                    SpnTextTrainingProgram.Visible = true;
                    SpnTextTrainingProjectName.Visible = true;
                    TrainingProjectBAL project = new TrainingProjectBAL();
                    MySqlDataReader drProject = project.GetTrainingProgramInstance(this.trainingProjectID.ToString());
                    if (drProject.Read())
                    {
                        SpnTrainingProgramName.InnerText = drProject["training_program_name"].ToString();
                        SpnTrainingProjectName.InnerText = drProject["training_project_name"].ToString();
                        //SpnTrainnigProjectDetail.InnerText = Convert.ToDateTime(drProject["start_date_time"]).ToString("dd/MM/yyyy") + "";
                        //SpnTrainnigProjectDetail.InnerText += " to " + Convert.ToDateTime(drProject["end_date_time"]).ToString("dd/MM/yyyy") + "";
                        //SpnTrainnigProjectDetail.InnerText += " from " + drProject["start_time"].ToString() + " to " + drProject["end_time"].ToString();
                    }
                    drProject.Close();
                    drProject.Dispose();
                }

                if (!string.IsNullOrEmpty(Request.QueryString["step"]) && Request.RawUrl.Contains("train_proj"))
                {
                    SpnStepDetails.Visible = true;
                    string stepNumber = Request.QueryString["step"];
                    switch (stepNumber)
                    {
                        case "1":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 1: Whether Candidate confirmed to attend training";
                            break;
                        case "2":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 2: Whether Candidate passed evaluation";
                            break;
                        case "3":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 3: Whether Candidate actually started attending training";
                            break;
                        case "4":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 4: Whether Candidate completed training ";
                            break;
                        case "5":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 5: Whether Candidate Passed Training";
                            break;
                        case "6":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 6: Whether Candidate given to grade";
                            break;
                        case "7":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 7: Whether Certificate given to Candidate";
                            break;

                    }
                }

                if (Request.RawUrl.Contains("emp_proj"))
                {
                    SpnTextEmploymentProjectName.Visible = true;
                    SpnEmploymentProjectName.Visible = true;

                    EnableIndia.App_Code.BAL.EmploymentProjectBAL proj = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
                    MySqlDataReader drEmploymentProjectDetails = proj.GetEmploymentProjectDetails(this.employmentProjectID.ToString());

                    if (drEmploymentProjectDetails.Read())
                    {
                        SpnEmploymentProjectName.InnerText = drEmploymentProjectDetails["employment_project_name"].ToString();
                    }
                    drEmploymentProjectDetails.Close();
                    drEmploymentProjectDetails.Dispose();

                    SpnStepDetails.Visible = true;
                    string stepNumber = Request.QueryString["step"];
                    switch (stepNumber)
                    {
                        case "1":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 1: Whether Candidate interested in the job";
                            break;
                        case "2":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 2: Whether Education Certificates Verified";
                            break;
                        case "3":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 3: Whether Candidate Profile sent";
                            break;
                        case "4":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 4: Whether Candidate Interview Scheduled ";
                            break;
                        case "5":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 5: Whether Candidate confirmed for Interview";
                            break;
                        case "6":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 6: Whether Candidate Prepared for Interview";
                            break;
                        case "7":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 7: Whether Interview Support required";
                            break;
                        case "8":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 6: Whether Candidate Interview Process complete";
                            break;
                        case "9":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 6: Whether Candidate Got Job";
                            break;
                        case "10":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 6: Whether Candidate informed and accepted job";
                            break;
                        case "11":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 6: Whether Candidate Offer letter received";
                            break;
                        case "12":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 6: Whether Candidate Employment Proof received";
                            break;
                        case "13":
                            SpnStepDetails.InnerText = "Candidate Calling initiated from Step 6: Whether Work Place Solution to be done";
                            break;


                    }
                }
 
                if (Request.Cookies["candidate_calling"] != null && !Request.Cookies["candidate_calling"].Value.Equals(""))
                {
                    string[] encryptedCandidateIDs = Request.Cookies["candidate_calling"].Value.Trim().Split('_');
                    string decryptedCandidateIDs = String.Empty;

                    for (int counter = 0; counter < encryptedCandidateIDs.Length; counter++)
                    {
                        decryptedCandidateIDs += Global.DecryptID(Convert.ToDouble(encryptedCandidateIDs[counter])).ToString() + ",";
                    }

                    decryptedCandidateIDs += "0";

                    CandidateCallingBAL get = new CandidateCallingBAL();
                    dt = get.GetCandidateCalling(decryptedCandidateIDs);
                    LstViewCandidateCallingList.DataSource = dt; // get.GetCandidateCalling(decryptedCandidateIDs);
                    LstViewCandidateCallingList.DataBind();
                    ViewState["dt"] = dt;
                    if (LstViewCandidateCallingList.Items.Count > 0)
                    {
                        BtnExportToExcel.Visible = true;
                        BtnDeleteFromList.Visible = true;
                    }
                    else
                    {
                        BtnExportToExcel.Visible = false;
                        BtnDeleteFromList.Visible = false;
                    }
                }
            }
            if (Page.IsPostBack)
            {
                if (ViewState["dt"] != null)
                {
                    dt = (DataTable)ViewState["dt"];
                }
            }
        }

        protected void LstViewCandidateCallingList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                CheckBox ChkSelectCandidateID = (CheckBox)e.Item.FindControl("ChkSelectCandidateID");
                HtmlGenericControl lblSelectCandidateID = (HtmlGenericControl)e.Item.FindControl("lblSelectCandidateID");

                lblSelectCandidateID.Attributes.Add("for", ChkSelectCandidateID.ClientID);
            }
        }

        protected void BtnDeleteFromList_Click(object sender, EventArgs e)
        {
            //Session["CandidateCalling"] = TxtCandidateCallingList.Text;
        }

        protected void btnDelFromListClick(object sender, EventArgs e)
        {
            int i = 0;
            int count = this.LstViewCandidateCallingList.Items.Count;
            if (count == 0) return;
            for(i = count - 1;i >= 0;i--)
            {
                ListViewItem item = (ListViewItem)this.LstViewCandidateCallingList.Items[i];
                CheckBox cb = (CheckBox)item.FindControl("ChkSelectCandidateID");
                if (cb != null)
                {
                    if (cb.Checked)
                    {
                        // this.LstViewCandidateCallingList.Items.RemoveAt(i);
                        dt.Rows[i].Delete();
                        
                    }
                }
            }
           // this.LstViewCandidateCallingList.DataBind();
            dt.AcceptChanges();
            this.LstViewCandidateCallingList.DataSource = dt;
            this.LstViewCandidateCallingList.DataBind();
            ViewState["dt"] = dt;
            webMessageBox wb = new webMessageBox();
            wb.Show("Candidate(s) deleted successfully");
        }

        //protected void BtnPrint_click(object sender, EventArgs e)
        //{
        //    string selectedCandidates = String.Empty;
        //    foreach(ListViewDataItem item in LstViewCandidateCallingList.Items)
        //    {
        //        CheckBox ChkSelectCandidateID = (CheckBox)item.FindControl("ChkSelectCandidateID");
        //        if(ChkSelectCandidateID.Checked)
        //        {
        //            selectedCandidates += Global.DecryptID(Convert.ToDouble(ChkSelectCandidateID.Attributes["CandidateID"])) + ",";
        //        }
        //    }
        //    Session["SelectedCandidates"] = selectedCandidates.Substring(0, selectedCandidates.Length - 1);
        //    ClientScript.RegisterStartupScript(this.GetType(), "__Popup", "ShowPopUp('CandidateCallingListPrintForm.aspx',1024,768);", true);
        //}

    }
}