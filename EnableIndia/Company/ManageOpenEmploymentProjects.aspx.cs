using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace EnableIndia.Company
{
    public partial class ManageOpenEmploymentProjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Global.AuthenticateUser();

                DataTable dt = new DataTable();
                LstViewCompanyContacts.DataSource = dt;
                LstViewCompanyContacts.DataBind();
                LstViewManageOpenEmploymentProject.DataSource = dt;
                LstViewManageOpenEmploymentProject.DataBind();
            }
        }
    }
}