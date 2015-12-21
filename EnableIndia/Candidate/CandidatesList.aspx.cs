using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Candidate
{

    public partial class CandidatesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Global.AuthenticateUser();

                GetListOfCandidates();
            }
        }

        protected void GetListOfCandidates()
        {
           
            CandidatesBAL list = new CandidatesBAL();
            LstViewCandidates.DataSource = list.GetListOfCandidates(DdlEmploymentStatus.SelectedValue);
            LstViewCandidates.DataBind();
        }
    }
}