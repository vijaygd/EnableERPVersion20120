using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnableIndia.Training
{
    public partial class TrainingProjectsNonRecomendedCandidates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.AuthenticateUser();
            DataTable dt = new DataTable();

            LstViewAddNonRecommendedCandidate.DataSource = dt;
            LstViewAddNonRecommendedCandidate.DataBind();
        }
    }
}