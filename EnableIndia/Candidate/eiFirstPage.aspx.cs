using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnableIndia.Candidate
{
    public partial class eiFirstPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               // Response.Redirect("~/Candidate/dashBoard.aspx", false);
            }
        }
    }
}