using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace EnableIndia.ReportSection
{
    public partial class EmploymentProjectDetailFromSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string employmentProjectName = Request.QueryString["emp_proj_name"].ToString();
            EnableIndia.App_Code.BAL.EmploymentProjectBAL emp = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            int employemntProjectID = emp.GetEmploymentProjectIDFromName(employmentProjectName);
            if (employemntProjectID > 0)
            {
                Response.Redirect("~/Company/AddEmploymentProjects.aspx?emp_proj=" + Global.EncryptID(employemntProjectID).ToString());
            }
            else
            {

                Response.Redirect("~/Company/AddEmploymentProjects.aspx?emp_proj=" + employemntProjectID.ToString());
            }
        }
    }
}