using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnableIndia.MobileDevices
{
    public partial class PageProcessor : System.Web.UI.Page
    {
        public string Ppw;
        public string Message;
        protected void Page_Load(object sender, EventArgs e)
        {
            Ppw = Request.QueryString["Page"];
        }
    }
}