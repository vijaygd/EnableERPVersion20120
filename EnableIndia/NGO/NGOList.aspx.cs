using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.NGO
{

    public partial class NGOList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Global.AuthenticateUser();

                GetNgoList();
            }
        }

        protected void GetNgoList()
        {
            NGOsBAL get = new NGOsBAL();
            get.Name = TxtNGO.Text.Trim();
            LstViewNgoDetails.DataSource = get.GetNGOList(get.Name);
            LstViewNgoDetails.DataBind();
        }

        protected void LnkBtnNgo_Click(object sender, EventArgs e)
        {
            int ngoID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect("~/NGO/RegisterNGO.aspx?ngo=" + Global.EncryptID(ngoID).ToString(), true);
        }

        protected void BtnSearchNGO_Click(object sender, EventArgs e)
        {
            GetNgoList();
        }
    }
}