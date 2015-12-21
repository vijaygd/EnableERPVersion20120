using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace EnableIndia.Admin
{
    public partial class RegisterEmployee : System.Web.UI.Page
    {
        int EmployeeID
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["emp"] != null)
            {
                this.EmployeeID = Global.DecryptID(Convert.ToDouble(Request.QueryString["emp"]));
            }
            else
            {
                this.EmployeeID = -2;
            }

            Global.SetDefaultButtonOfTheForm(this.Form, BtnManageEmployee);
            if (!Page.IsPostBack)
            {
                Global.AuthenticateUser();

                EnableIndia.App_Code.BAL.RolesBAL jRoles = new EnableIndia.App_Code.BAL.RolesBAL();
                MySqlDataReader drJobRoles = jRoles.GetRoles();

                Global.FillDropDown(DdlRoles, drJobRoles, "role_name", "role_id");

                if (Request.QueryString["emp"] != null)
                {
                    LblTitle.Text = "Update Enable India Employee";
                    LblTitle.Attributes["MessageStartText"] = "Update";
                    GetEmployeeDetails();
                    BtnCancel.Visible = false;
                    BtnDeleteEmployee.Visible = true;
                }

                Global.ShowMessageInAlert(this.Form);
            }
            SpnMessage.InnerText = "";
        }

        private void GetEmployeeDetails()
        {
            EnableIndia.App_Code.BAL.EmployeeBAL emp = new EnableIndia.App_Code.BAL.EmployeeBAL();
            MySqlDataReader drEmployeeDetails = emp.GetEmployeeDetails(this.EmployeeID.ToString());

            if (drEmployeeDetails.Read())
            {
                DdlRoles.Value = drEmployeeDetails["role_id"].ToString();
                TxtFirstName.Text = drEmployeeDetails["employee_first_name"].ToString();
                TxtMiddleName.Text = drEmployeeDetails["employee_middle_name"].ToString();
                TxtLastName.Text = drEmployeeDetails["employee_last_name"].ToString();
                TxtUserName.Text = drEmployeeDetails["login_name"].ToString();
                TxtPassword.Text = drEmployeeDetails["login_password"].ToString();
                TxtEmailAddress.Text = drEmployeeDetails["email_address"].ToString();

                BtnDeleteEmployee.Attributes["OpenCandidateTask"] = drEmployeeDetails["open_cand_task"].ToString();
                BtnDeleteEmployee.Attributes["OpenCompanyTask"] = drEmployeeDetails["open_comp_task"].ToString();
                BtnDeleteEmployee.Attributes["OpenTraningProject"] = drEmployeeDetails["open_train_proj"].ToString();
                BtnDeleteEmployee.Attributes["OpenEmpProject"] = drEmployeeDetails["open_emp_proj"].ToString();

                drEmployeeDetails.Close();
                drEmployeeDetails.Dispose();
            }
            else
            {
                Response.Redirect("~/Admin/RegisterEmployee.aspx", true);
            }
        }

        protected void BtnManageEmployee_Click(object sender, EventArgs e)
        {
            EnableIndia.App_Code.BAL.EmployeeBAL emp = new EnableIndia.App_Code.BAL.EmployeeBAL();

            emp.RoleID = Convert.ToInt32(DdlRoles.Value);
            emp.EmployeeFirstName = TxtFirstName.Text.Trim();
            emp.EmployeeMiddleName = TxtMiddleName.Text.Trim();
            emp.EmployeeLastName = TxtLastName.Text.Trim();
            emp.LoginName = TxtUserName.Text.Trim();
            emp.Password = TxtPassword.Text.Trim();
            emp.EmailAddress = TxtEmailAddress.Text.Trim();

            string errorMessage = "";
            bool isSuccess = false;

            if (Request.QueryString["emp"] != null)
            {
                emp.EmployeeID = this.EmployeeID;
                isSuccess = emp.UpdateEmployee(emp, out errorMessage);
            }
            else
            {
                isSuccess = emp.AddEmployee(emp, out errorMessage);
            }

            if (isSuccess.Equals(true))
            {
                if (Request.QueryString["emp"] != null)
                {
                    Global.ShowMessagesInDiv(this.Page, "Employee updated successfully.");
                    Response.Redirect("~/Admin/EmployeeList.aspx", true);
                }
                else
                {
                    //Global.ShowMessagesInDiv(this.Page, "Employee added successfully.");
                    //Global.ClearAll(this.Form);
                    Global.RedirectAfterSubmit("Employee added successfully.", BtnManageEmployee.ID);
                }
            }
            else
            {
                Global.ShowMessagesInDiv(this.Page, errorMessage);
            }
        }

        protected void BtnDeleteEmployee_Click(object sender, EventArgs e)
        {
            string script = String.Empty;
            string message = string.Empty;
            EnableIndia.App_Code.BAL.EmployeeBAL emp = new EnableIndia.App_Code.BAL.EmployeeBAL();
            emp.EmployeeID = this.EmployeeID;
            //int IsEmployeeAssigned = emp.CheckEmployeeAssignedForTask(emp);
            //MySqlDataReader drEmployeeDetails = emp.GetEmployeeDetails(this.EmployeeID.ToString());
            //drEmployeeDetails.Read();
            //if(Convert.ToInt32(drEmployeeDetails["open_cand_task"]) > 0)
            //{
            //    script = "alert('Employee can not be deleted as employee has open tasks assigned.');";
            //    ClientScript.RegisterStartupScript(this.GetType(), "__key", script, true);
            //    //Response.Redirect("~/Admin/EmployeeList.aspx");
            //    return;
            //}
            //else
            //{
            bool isDeleted = emp.DeleteEmployee(this.EmployeeID.ToString());
            if (isDeleted.Equals(true))
            {
                var url = "~/Admin/EmployeeList.aspx?msg=" + Global.EncryptQueryString("Employee deleted successfully.");
                url += "&foc=" + Global.EncryptQueryString("null");
                Response.Redirect(url, true);
            }
            else
            {
                Global.ShowMessagesInDiv(this.Page, Global.GetGlobalErrorMessage());
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["emp"] != null)
            {
                Response.Redirect("~/Admin/EmployeeList.aspx", true);
            }
            else
            {
                Global.ClearAll(this.Form);
            }
        }
    }
}