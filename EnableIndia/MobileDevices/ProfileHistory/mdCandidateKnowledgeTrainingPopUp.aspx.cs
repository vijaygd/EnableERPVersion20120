using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.MobileDevices.ProfileHistory
{
    public partial class mdCandidateKnowledgeTrainingPopUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }

            Global.ShowMessageInAlert(this.Form);
            if (!Page.IsPostBack)
            {
                GetTrainingProgram();
            }
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }
        }
        private void GetTrainingProgram()
        {
            CandidateRecommendedTrainingProgramsBAL training = new CandidateRecommendedTrainingProgramsBAL();
            LstViewTrainingProgram.DataSource = training.GetCandidteRecommendedTrainingPrograms(Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString());
            LstViewTrainingProgram.DataBind();
        }

        protected void LstViewTrainingProgram_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl LblTrainingProgram = (HtmlGenericControl)e.Item.FindControl("LblTrainingProgramName");
                CheckBox ChkTrainingProgramName = (CheckBox)e.Item.FindControl("ChkTrainingProgramName");
                LblTrainingProgram.Attributes.Add("for", ChkTrainingProgramName.ClientID);
            }

        }

        protected void BtnSubmit_click(object sender, EventArgs e)
        {
            string message = string.Empty;
            EnableIndia.App_Code.BAL.CandidateRecommendedTrainingProgramsBAL trainingProgram = new EnableIndia.App_Code.BAL.CandidateRecommendedTrainingProgramsBAL();
            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();

            MySqlCommand cmd = new MySqlCommand("", conn, trans);

            try
            {

                cmd = new MySqlCommand("", conn, trans);
                cmd.Parameters.Clear();

                //Delete Training Programm
                cmd = new MySqlCommand("", conn, trans);
                trainingProgram.DeleteCandidateRecommendedTrainingPrograms(cmd, Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString());

                //cmd.CommandType = CommandType.Text;

                //update training Program
                foreach (ListViewDataItem item in LstViewTrainingProgram.Items)
                {
                    CheckBox ChkTrainingProgramName = (CheckBox)item.FindControl("ChkTrainingProgramName");
                    if (ChkTrainingProgramName.Checked)
                    {
                        string trainingProgramID = Global.DecryptID(Convert.ToDouble(ChkTrainingProgramName.Attributes["trainingProgramID"])).ToString();
                        cmd = new MySqlCommand("", conn, trans);
                        trainingProgram.UpdateCandidateRecommendedTrainingPrograms(cmd, Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString(), trainingProgramID);
                    }
                }
                trans.Commit();
                message = "Training Program added/updated successfully.";

            }
            catch
            {
                message = Global.GetGlobalErrorMessage();
                trans.Rollback();

            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
                Global.RedirectAfterSubmit(message, BtnSubmit.ID);

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

    }
}