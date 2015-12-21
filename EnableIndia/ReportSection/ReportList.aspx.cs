using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnableIndia.ReportSection
{
    public partial class ReportList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lbGotJobClick(object sender, EventArgs e)
        {
            string u1 = HttpContext.Current.Request.Url.AbsoluteUri;
            u1 = u1.Replace("/ReportSection/ReportList.aspx", "/Candidate/GotJobN.aspx");
//            ClientScript.RegisterStartupScript(this.GetType(), this.GetType().Name, string.Format("window.open('{0}', '_blank');", "http://192.168.100.98/eiadmin/GotJobN.aspx"), true);
            ClientScript.RegisterStartupScript(this.GetType(), this.GetType().Name, string.Format("window.open('{0}', '_blank');", u1), true);
        }
        protected void lbPlacementsClick(object sender, EventArgs e)
        {
            string u1 = HttpContext.Current.Request.Url.AbsoluteUri;
            u1 = u1.Replace("/ReportSection/ReportList.aspx", "/Candidate/PlacementsN.aspx");
            ClientScript.RegisterStartupScript(this.GetType(), this.GetType().Name, string.Format("window.open('{0}', '_blank');", u1), true);
        }
    }
}