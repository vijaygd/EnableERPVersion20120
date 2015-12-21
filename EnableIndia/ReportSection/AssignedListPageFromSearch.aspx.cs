using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnableIndia.ReportSection
{
    public partial class AssignedListPageFromSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string employmentProjectName = Request.QueryString["emp_proj_name"].ToString();
            EnableIndia.App_Code.BAL.EmploymentProjectBAL emp = new EnableIndia.App_Code.BAL.EmploymentProjectBAL();
            int employemntProjectID = emp.GetEmploymentProjectIDFromName(employmentProjectName);
            int companyID = emp.GetCompanyIDFromName(employmentProjectName);
            if (employemntProjectID > 0 && companyID > 0)
            {
                Response.Redirect("~/Company/AssignedList.aspx?emp_proj=" + Global.EncryptID(employemntProjectID).ToString() + "&comp=" + Global.EncryptID(companyID).ToString());

            }
            else
            {
                employemntProjectID = 0;
                companyID = 0;
                Response.Redirect("~/Company/AssignedList.aspx?emp_proj=" + employemntProjectID + "&comp=" + companyID);
            }
        }
    }
}