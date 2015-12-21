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

    public partial class EmployeeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Global.AuthenticateUser();
                //Global.SetDefaultButtonOfTheForm(this.Form, BtnEditEmployee);

                GetEmployeeList();
                Global.ShowMessageInAlert(this.Form);
            }
        }

        private void GetEmployeeList()
        {
            EnableIndia.App_Code.BAL.EmployeeBAL emp = new EmployeeBAL();
            LstViewEmployees.DataSource = emp.GetEmployeeList();
            LstViewEmployees.DataBind();
            //if(LstViewEmployees.Items.Count.Equals(0))
            //{
            //    BtnEditEmployee.Visible = false;
            //    BtnDeleteEmployee.Visible = false;
            //}
        }

        protected void LnkBtnEmployeeName_Click(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect("~/Admin/RegisterEmployee.aspx?emp=" + Global.EncryptID(Convert.ToInt32(employeeID)).ToString(), true);
        }

    }
}