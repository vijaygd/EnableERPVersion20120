using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using MySql.Data.MySqlClient;
using System.Management;
using System.Reflection;
using System.Runtime.CompilerServices;
using EnableIndia;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetDefaultButtonOfTheForm(this.Form, BtnLoginName);
            var path = Server.MapPath("~");
            if (!Page.IsPostBack)
            {

                dispVersion();
                if (HttpContext.Current.Request.Cookies["EnableIndia"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["EnableIndia"].Value))
                    {
                        string[] loginDetails = Request.Cookies["EnableIndia"].Value.Trim().Split(',');
                        TxtLoginName.Text = Global.DecryptQueryString(loginDetails[0]);
                        TxtLoginPassword.Attributes.Add("value", Global.DecryptQueryString(loginDetails[1]));
                        chkRememberMe.Checked = Convert.ToBoolean(loginDetails[2]);
                    }
                }
                Session["LoggedIn"] = null;
                TxtLoginName.Focus();
            }

        }

        protected void BtnLoginName_Click(object sender, EventArgs e)
        {
            if (TxtLoginName.Text.Trim().Equals("admin"))
            {
                if (TxtLoginName.Text.Trim().Equals("admin") && TxtLoginPassword.Text.Trim().Equals("EIadmin2010"))
                {
                    Session["role_id"] = 8;
                    Session["LoggedIn"] = true;
                    FormsAuthentication.SetAuthCookie(TxtLoginName.Text.Trim(), chkRememberMe.Checked);
                    if (chkRememberMe.Checked.Equals(true))
                    {
                        HttpCookie cookie = new HttpCookie("EnableIndia");
                        cookie.Expires = DateTime.Now.AddDays(60);
                        TxLoginUserNameAndPassword.Text = string.Format("{0},{1},{2}", Global.EncryptQueryString(TxtLoginName.Text.Trim()), Global.EncryptQueryString(TxtLoginPassword.Text.Trim()), chkRememberMe.Checked);
                        cookie.Value = TxLoginUserNameAndPassword.Text;
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        TxLoginUserNameAndPassword.Text = "";
                        HttpContext.Current.Response.Cookies["EnableIndia"].Expires = DateTime.Now.AddDays(-1);
                    }

                    Session["username"] = "admin";
                    Session["password"] = "eiadmin2010";
                    //                Response.Redirect("~/Candidate/eiFirstPage.aspx", true);
                    Response.Redirect("~/Company/ListOfOpenEmploymentProject.aspx", true);
                }
                else
                {
                    Global.ShowMessage(SpnMessage, "Login Failed.", false);
                }
            }

            else
            {
                bool bLogin = false;
                EmployeeBAL emp = new EmployeeBAL();
                string userName = string.Empty;
                string password = string.Empty;
                MySqlDataReader drLogin = emp.GetLoginDetail(TxtLoginName.Text.Trim(), TxtLoginPassword.Text.Trim());
                if (drLogin.Read())
                {
                    userName = drLogin["login_name"].ToString();
                    //                password = drLogin["emp_password"].ToString(); 
                    string tPwd = System.Text.ASCIIEncoding.ASCII.GetString((byte[])drLogin["emp_password"]); // System.Text.ASCIIEncoding.ASCII.GetString(drLogin["emp_password"])
                    password = Global.DecryptQueryString(tPwd);
                    Session["role_id"] = drLogin["role_id"].ToString();
                    Session["username"] = userName;
                    Session["password"] = password;
                }
                bLogin = drLogin.HasRows;
                drLogin.Close();
                drLogin.Dispose();
                if (bLogin)
                {
                    if (TxtLoginName.Text.Trim() == userName && TxtLoginPassword.Text.Trim() == password)
                    {
                        Session["LoggedIn"] = true;
                        FormsAuthentication.SetAuthCookie(TxtLoginName.Text.Trim(), chkRememberMe.Checked);
                        // Response.Redirect("~/company/ListOfOpenEmploymentProject.aspx", true);
                        Response.Redirect("~/Company/ListOfOpenEmploymentProject.aspx", true);
                        //    Response.Redirect(Page.ResolveClientUrl("Candidate/eiFirstPage.aspx"));
                    }
                }
                else
                {
                    Global.ShowMessage(SpnMessage, "Login Failed.", false);
                }

            }
        }

        protected void LnkForgotPassword_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/RecoverPassword.aspx");
        }
        private void dispVersion()
        {
            Assembly web = Assembly.GetExecutingAssembly();
            AssemblyName webName = web.GetName();
            string myVersion = webName.Version.ToString();
            this.lbVersion.Text = "Version: " + myVersion;
        }
        protected void downloadAndroid(object sender, EventArgs e)
        {
            string filename = "~/MobileRelease/android/enablemobile.Droid.apk";
            string path = Page.Server.MapPath(filename); //get file object as FileInfo
            System.IO.FileInfo file = new System.IO.FileInfo(path); //-- if the file exists on the server
            if (file.Exists)
            {
                Page.Response.Clear();
                Page.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Page.Response.AddHeader("Content-Length", file.Length.ToString());
                //if (sContentType.Length > 0)
                //    Page.Response.ContentType = sContentType;
                //else
                    Page.Response.ContentType = "application/octet-stream";

                Page.Response.WriteFile(file.FullName);
                Page.Response.Flush();
                Page.Response.End(); //if file does not exist

            }
        }
    }
}