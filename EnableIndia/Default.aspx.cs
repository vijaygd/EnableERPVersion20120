using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
namespace EnableIndia
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Browser.IsMobileDevice)
                {
                    Response.Redirect("~/MobileDevices/mdLogin.aspx", false);
                  //  Response.Redirect("~/MobileDevices/ProfileHistory/mdRegistration.aspx", false);
                }
                else
                {
                    Response.Redirect("~/Login.aspx", false);
                }
            }
            catch (System.Exception ex)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("System error: Contact Admin </br>" + ex.Message);
            }
        }
    }
}