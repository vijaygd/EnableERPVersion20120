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

namespace EnableIndia.Training
{
    public partial class OffLineCandidateCallingList : System.Web.UI.Page
    {
        int trainingProjectID
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["train_proj"] != null)
            {
                this.trainingProjectID = Global.DecryptID(Convert.ToDouble(Request.QueryString["train_proj"]));
            }
            else
            {
                this.trainingProjectID = -1;
            }
            Global.ShowMessageInAlert(this.Form);

            if (!Page.IsPostBack)
            {
                EnableIndia.App_Code.BAL.TrainingProjectBAL project = new EnableIndia.App_Code.BAL.TrainingProjectBAL();
                MySqlDataReader drProject = project.GetTrainingProgramInstance(this.trainingProjectID.ToString());
                if (drProject.Read())
                {
                    SpnTrainingProgramName.InnerText = drProject["training_program_name"].ToString();
                    SpnTrainnigProjectDetail.InnerText = Convert.ToDateTime(drProject["start_date_time"]).ToString("dd/MM/yyyy") + "";
                    SpnTrainnigProjectDetail.InnerText += " to " + Convert.ToDateTime(drProject["end_date_time"]).ToString("dd/MM/yyyy") + "";
                    SpnTrainnigProjectDetail.InnerText += " from " + drProject["start_time"].ToString() + " to " + drProject["end_time"].ToString();
                }
                drProject.Close();
                drProject.Dispose();
            }
            //code for candidate calling list

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
                LstViewCandidateCallingList.DataSource = get.GetCandidateCalling(decryptedCandidateIDs);
                LstViewCandidateCallingList.DataBind();
            }
        }

        protected void LstViewCandidateCallingList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                CheckBox ChkRecommendedCandidateName = (CheckBox)e.Item.FindControl("ChkRecommendedCandidateName");
                HtmlGenericControl LblCandidateName = (HtmlGenericControl)e.Item.FindControl("LblCandidateName");

                LblCandidateName.Attributes.Add("for", ChkRecommendedCandidateName.ClientID);
            }
        }

    }
}