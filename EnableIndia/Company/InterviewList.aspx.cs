using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnableIndia.Company
{
    public partial class InterviewList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.AuthenticateUser();
        
            DataTable dt = new DataTable();
            LstViewInterviewListCompanyContacts.DataSource = dt;
            LstViewInterviewListCompanyContacts.DataBind();

            LstViewInterviewList.DataSource = dt;
            LstViewInterviewList.DataBind();
        }
    }
}