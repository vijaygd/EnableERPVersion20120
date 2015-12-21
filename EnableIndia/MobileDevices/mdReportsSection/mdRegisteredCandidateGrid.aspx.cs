using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.MobileDevices.mdReportsSection
{
    public partial class mdRegisteredCandidateGrid : System.Web.UI.Page
    {
        public DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CandidatesBAL cand = new CandidatesBAL();
                cand = (CandidatesBAL)Session["cand"];
                Session.Remove("cand");
                dt = cand.GetAllActiveRegisteredCandidate(cand);
                if (dt != null)
                {
                    this.lbNoRec.Text = dt.Rows.Count.ToString();
                }
                ViewState["dt"] = dt;
                this.grCandidates.DataSource = dt;
                this.grCandidates.DataBind();
            }
            if(Page.IsPostBack)
            {
                dt = (DataTable)ViewState["dt"];
            }

        }
        protected void grCandidatesChanging(object sender, GridViewPageEventArgs e)
        {
            this.grCandidates.DataSource = dt;
            this.grCandidates.PageIndex = e.NewPageIndex;
            this.grCandidates.DataBind();
        }
        protected void grCandidatesOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i = 0;
            int j = 0;
            GridViewRow gRow = e.Row;
            foreach (TableCell tc in gRow.Cells)
            {
                tc.BorderColor = System.Drawing.Color.FromArgb(170, 188, 254);
                tc.BorderWidth = Unit.Pixel(2);
            }
            e.Row.Attributes.Add("onMouseOver", "Highlight(this)");
            e.Row.Attributes.Add("onMouseOut", "UnHighlight(this)");
        }
        protected void btnCloseClick(object sender, EventArgs e)
        {
            CloseRadWindow();
        }
        private void CloseRadWindow()
        {
            string closeScript = "<script language ='javascript' type ='text/javascript' >";
            closeScript += "function GetRadWindow()";
            closeScript += "{      ";
            closeScript += "var oWindow = null;";
            closeScript += "if (window.radWindow)";
            closeScript += "oWindow = window.RadWindow;";  //Will work in Moz in all cases, including clasic dialog      
            closeScript += "else if (window.frameElement.radWindow)";
            closeScript += "oWindow = window.frameElement.radWindow;"; //IE (and Moz as well)      
            closeScript += "return oWindow;";
            closeScript += "}";
            closeScript += "function Close()";
            closeScript += "{";
            closeScript += "GetRadWindow().Close();";
            closeScript += "}";
            closeScript += "</script>";
        //    ClientScript.RegisterStartupScript(this.GetType(), "closeScript", closeScript);
            this.lbError.Text = "<script type='text/javascript'>Close();</script>";        }

    }
}