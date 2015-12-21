﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Text;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;
using Telerik;
using Telerik.Web;
using Telerik.Web.UI;
using Telerik.Web.Dialogs;

namespace EnableIndia.Candidate.ProfileHistory
{

    public partial class Recommended_Job_Type : System.Web.UI.Page
    {
        public string CandidateID
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
            Global.SetDefaultButtonOfTheForm(this.Form, BtnAddJobTypes);
            Global.ShowMessageInAlert(this.Form);

            if (Request.QueryString["cand"] != null)
            {
                this.CandidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString();
            }

            if (!Page.IsPostBack)
            {
                EnableIndia.App_Code.BAL.JobsBAL job = new EnableIndia.App_Code.BAL.JobsBAL();
                MySqlDataReader drJob = job.GetJobs();
                Global.FillDropDown(DdlRecommndedJobTypes, drJob, "job_name", "job_id");

                if (Request.QueryString["job"] != null)
                {
                    DdlRecommndedJobTypes.Value = Global.DecryptID(Convert.ToDouble(Request.QueryString["job"])).ToString();
                    DdlRecommndedJobTypes.Attributes.Add("style", "display:none");
                    SpnRecommendedJobTypes.InnerText = DdlRecommndedJobTypes.Items[DdlRecommndedJobTypes.SelectedIndex].Text;
                    BtnDeleteRecommendedjobType.Visible = true;
                    //BtnAddJobTypes.Text = BtnAddJobTypes.Text.Replace("Submit", "Update");
                }
                this.txtParent.Value = Request.QueryString["txboxId"];
                GetJobWithRole();
            }
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }

        }
        private void GetJobWithRole()
        {
            CandidateRecommendedRolesBAL role = new CandidateRecommendedRolesBAL();
            LstViewJobTypesWithRole.DataSource = role.GetCandidateRecommendedRoles(this.CandidateID, DdlRecommndedJobTypes.Value);
            LstViewJobTypesWithRole.DataBind();
        }

        protected void LstViewJobTypesWithRole_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl lblJobRole = (HtmlGenericControl)e.Item.FindControl("lblJobRole");
                CheckBox ChkJobRole = (CheckBox)e.Item.FindControl("ChkJobRole");
                lblJobRole.Attributes.Add("for", ChkJobRole.ClientID);
            }
        }

        protected void BtnAddJobTypes_click(object sender, EventArgs e)
        {
            this.lbError.Text = "Plesae wait...";
           // this.updStat.Update();
            int i = 0;
            string message = String.Empty;
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand("", conn, trans);
            try
            {
                //Manages recommended roles
                cmd = new MySqlCommand("", conn, trans);
                cmd.CommandText = "delete from candidate_recommended_job_types where candidate_id=" + this.CandidateID + " and job_id=" + DdlRecommndedJobTypes.Value;
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("", conn, trans);
                cmd.CommandText = "insert into candidate_recommended_job_types(candidate_id,job_id)";
                cmd.CommandText += "values(" + this.CandidateID + ",";
                cmd.CommandText += DdlRecommndedJobTypes.Value + ")";
                cmd.ExecuteNonQuery();

                //Code For Optimization
                cmd = new MySqlCommand("", conn, trans);
                cmd.CommandText = "UPDATE candidates SET  ";
                cmd.CommandText += "recommended_job_types=fun_get_candidate_recommended_job_types(" + this.CandidateID + ")";
                cmd.CommandText += "WHERE candidate_id=" + this.CandidateID;
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("", conn, trans);
                cmd.CommandText = "delete from candidate_recommended_roles where candidate_id=" + this.CandidateID;
                cmd.CommandText += " and job_id=" + DdlRecommndedJobTypes.Value;
                cmd.ExecuteNonQuery();
                foreach (ListViewDataItem item in LstViewJobTypesWithRole.Items)
                {
                    CheckBox ChkJobRole = (CheckBox)item.FindControl("ChkJobRole");
                    if (ChkJobRole.Checked && ChkJobRole.Attributes["jobID"].ToString().Equals(DdlRecommndedJobTypes.Value))
                    {
                        cmd = new MySqlCommand("", conn, trans);
                        cmd.CommandText = "insert into candidate_recommended_roles(candidate_id,job_id,job_role_id)";
                        cmd.CommandText += "values(" + this.CandidateID + "," + DdlRecommndedJobTypes.Value + ",";
                        cmd.CommandText += ChkJobRole.Attributes["JobRoleID"].ToString() + ")";
                        cmd.ExecuteNonQuery();
                    }
                }
                //Code For Optimization
                cmd = new MySqlCommand("", conn, trans);
                cmd.CommandText = "UPDATE candidates SET recommended_job_roles=fun_get_candidate_recommended_roles(" + this.CandidateID + ") ";
                //cmd.CommandText += "recommended_job_types=fun_get_candidate_recommended_job_types(" + this.CandidateID + ")";
                cmd.CommandText += "WHERE candidate_id=" + this.CandidateID;
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("", conn, trans);
                cmd.CommandText = "update candidates set is_profiled=1 where candidate_id=" + this.CandidateID;
                cmd.ExecuteNonQuery();

                trans.Commit();
                message = "Recommended role updated successfully.";
                MsgBox(message);
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
                // Global.RedirectAfterSubmit(message, BtnAddJobTypes.ID);

            }
            closeRadPage(message);
        }
        private void MsgBox(string message)
        {
            webMessageBox wb = new webMessageBox();
            wb.Show(message);
        }
        protected void BtnDeleteRecommendedjobType_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            string message = "";
            CandidateRecommendedRolesBAL job = new CandidateRecommendedRolesBAL();
            int rowsAffected = job.DeleteRecommendedJobType(this.CandidateID, DdlRecommndedJobTypes.Value, out errorMessage);
            if (rowsAffected > 0)
            {
                message = "Recommended job type deleted successfully.";
            //    ClientScript.RegisterStartupScript(this.GetType(), "__Delete", "alert('" + message + "');self.close();", true);
            }
            else
            {
                message = "Unable to delete";
                //ClientScript.RegisterStartupScript(this.GetType(), "__Delete", "alert('" + errorMessage + "');", true);
            }
            MsgBox(message);
            closeRadPage(message);            
        }
        private void closeRadPage(string message)
        {
            this.lbError.Text = message;
         //   this.updStat.Update();
            System.Threading.Thread.Sleep(2000);
            this.lbError.Text = "<script type='text/javascript'>Close();</script>";
   
        }
        protected void closePage(object sender, EventArgs e)
        {
            closeRadPage("");
            //string url = "";
            //if (string.IsNullOrEmpty(message))
            //{
            //    url = "self.parent.location.replace('" + this.txtParent.Value + "')";
            //}
            //else
            //{
            //    url = "window.alert('" + message + "');self.parent.location.replace('" + this.txtParent.Value + "');";
            //}
 //           ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "javascript:self.close();", true);
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

    }
}