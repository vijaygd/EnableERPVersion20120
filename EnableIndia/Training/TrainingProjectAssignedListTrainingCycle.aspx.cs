using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnableIndia.Training
{
    public partial class TrainingProjectAssignedListTrainingCycle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.AuthenticateUser();

            DataTable dt = new DataTable();

            LstViewAssignedListTrainingCycle.DataSource = dt;
            LstViewAssignedListTrainingCycle.DataBind();
        }
    }
}