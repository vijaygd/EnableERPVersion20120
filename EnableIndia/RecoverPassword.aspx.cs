using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text;
using EnableIndia;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submitClick(object sender, EventArgs e)
        {
            Button bt = (Button)this.pwdRecovery.UserNameTemplateContainer.FindControl("btnSubmit");
            if (bt.Text == "Return")
            {
                string url = "Login.aspx";
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.open('");
                sb.Append(url);
                sb.Append("');");
                sb.Append("</script>");
                ClientScript.RegisterStartupScript(this.GetType(),
                       "script", sb.ToString());
                return;
            }
            string[] st = new string[1];
            EmployeeDAL emp = new EmployeeDAL();
            string email = string.Empty;
            string password = string.Empty;
            TextBox tb = (TextBox)this.pwdRecovery.UserNameTemplateContainer.FindControl("UserName");
            Label lb = (Label)this.pwdRecovery.UserNameTemplateContainer.FindControl("lbStatus");
            if (string.IsNullOrEmpty(tb.Text))
            {
                lb.Text = "User Name empty";
                return;
            }
            MySqlDataReader drLoginDetail = emp.GetLoginDetailForPassword(tb.Text);
            if (drLoginDetail.Read())
            {
                email = drLoginDetail["email_address"].ToString();
                password = System.Text.ASCIIEncoding.ASCII.GetString((byte[])drLoginDetail["emp_password"]);
                password = "Password: " + Global.DecryptQueryString(password);
            }
            else
            {
                lb.Text = "Invalid Username";
                return;
            }
            drLoginDetail.Close();
            drLoginDetail.Dispose();

            try
            {
                Global.sendMail(email, "enablesupport@affinity-soft.com",  "EnableIndia - Password Recorvery","".ToString(), "Password Recovered: " + password, st, "");
                //   Global.SendEmail("notification@enable-india.info", email, "Password Recovery", password);
                lb.Text = "Password detail has been sent on your mail. - Click on Return to login page";
                bt.Text = "Return";
                
            }
            catch (Exception ex)
            {
                lb.Text = "Error occured.";
            }
 
        }
    }
}