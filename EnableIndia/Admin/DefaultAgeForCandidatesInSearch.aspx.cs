using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Admin
{

    public partial class DefaultAgeForCandidatesInSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Global.SetDefaultButtonOfTheForm(this.Form, BtnSetAgeGroup);
                Global glob = new Global();
                glob.GetAgeGroups(DdlAgeGroups);
                GetDefaultAgeGroupForSearch();

                DdlAgeGroups.Items[0].Value = "all";
            }
        }

        private void GetDefaultAgeGroupForSearch()
        {
            DefaultsBAL def = new DefaultsBAL();
            SpnDefaultAge.InnerText = def.GetDefaultAgeGroupForSearch();
            DdlAgeGroups.Value = SpnDefaultAge.InnerText;
        }

        protected void BtnSetAgeGroup_Click(object sender, EventArgs e)
        {
            DefaultsBAL def = new DefaultsBAL();
            bool isUpdated = def.SetDefaultAgeGroupForSearch(DdlAgeGroups.Value);
            if (isUpdated.Equals(true))
            {
                Global.ShowMessagesInDiv(this.Page, "Age group updated successfully.");
                GetDefaultAgeGroupForSearch();
            }
            else
            {
                Global.ShowMessagesInDiv(this.Page, Global.GetGlobalErrorMessage());
            }
            BtnSetAgeGroup.Focus();
        }
    }
}