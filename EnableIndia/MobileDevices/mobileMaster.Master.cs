using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnableIndia.MobileDevices
{
    public partial class mobileMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.ServerVariables["http_user_agent"].IndexOf("Safari", StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                Page.ClientTarget = "uplevel";
            }
        }
        protected void menuMobileMasterClicked(object sender, MenuEventArgs e)
        {
            string tS = e.Item.Value.ToString().TrimStart().TrimEnd();
            int i = 0;
            switch (tS)
            {
                case "rc":
                    this.lbHeader.Text = "Candidate Registration";
                    Response.Redirect("~/MobileDevices/candidateRegistration.aspx", false);
                    break;
                case "logOff":
                    Response.Redirect("~/MobileDevices/mdLogin.aspx", false);
                    break;
                case "cs":
                    this.lbHeader.Text = "Registered Candidates List";
                    Response.Redirect("~/MobileDevices/mdReportsSection/mdRptRegisteredCandidates.aspx", false);
                    break;
                case "acp":
                    Response.Redirect("~/MobileDevices/ProfileHistory/mdAllActiveCandidates.aspx", false);
                    break;
                case "urc":
                    Response.Redirect("~/MobileDevices/PageProcessor.aspx?Page=mdUnregisterCandidate.aspx", false);
                    break;
            }
  
        }
        protected void btnHome_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("~/MobileDevises/mdDefaultPage.aspx", false);
        }
    }
}