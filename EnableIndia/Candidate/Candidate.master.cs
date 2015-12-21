using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace EnableIndia.Candidate
{

    public partial class Candidate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                if (Session["role_id"].ToString() != "8")
                {
                    if (Request.RawUrl.Contains("admin"))
                    {
                        Response.Redirect("~/login.aspx");
                        FormsAuthentication.SignOut();
                        Session["LoggedIn"] = false;
                    }
                }
                Page.Header.DataBind();
                if (!Page.IsPostBack)
                {
                    if (!Request.RawUrl.Contains("AssignedList"))
                    {
                        Response.Cookies.Add(new HttpCookie("grid_page_number", "1"));
                        Response.Cookies.Add(new HttpCookie("grid_page_count", "1"));
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
            Session["LoggedIn"] = null;
        }

        protected void btnHome_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("~/Candidate/dashBoard.aspx", false);
        }
        protected void btnClickDashBoard(object sender, EventArgs e)
        {
            Response.Redirect("~/Candidate/dashBoard.aspx", false);
        }
    }
}