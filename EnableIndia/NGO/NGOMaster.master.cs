using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace EnableIndia.NGO
{
    public partial class NGOMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                if (Session["role_id"].ToString() != "0")
                {
                    if (Request.RawUrl.Contains("admin"))
                    {
                        Response.Redirect("~/login.aspx");
                        FormsAuthentication.SignOut();
                        Session["LoggedIn"] = false;
                    }
                }
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }

        protected void BtnLogOff_click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/login.aspx");
            FormsAuthentication.SignOut();
            Session["LoggedIn"] = false;
        }
    }
}