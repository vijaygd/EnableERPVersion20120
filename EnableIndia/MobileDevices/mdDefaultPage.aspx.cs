using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnableIndia.MobileDevices
{
    public partial class mdDefaultPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string msg = Request.QueryString["msg"];
            if(!string.IsNullOrEmpty(msg))
            {
                webMessageBox wb = new webMessageBox();
                wb.Show(msg);
            }
        }
    }
}