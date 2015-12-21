using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Reporting;
using Telerik.ReportViewer;
using Telerik.ReportViewer.WebForms;
using System.Data;
using System.Data.SqlClient;
using MySql;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.ReportSection
{
    public partial class RadReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object rep = "";
            string rReport = "";
            if (!Page.IsPostBack)
            {
                rReport = Request.QueryString["Report"];
                switch (rReport)
                {
                    case "nAllActiveRegisteredCandidate":
                        this.lbError.Text = "Please wait.....";
                        EnableIndia.Reports.nAllActiveRegisteredCandidate nacr = new Reports.nAllActiveRegisteredCandidate();
                        CandidatesBAL cand = new CandidatesBAL();
                        cand = (CandidatesBAL)Session["cand"];
                        Session.Remove("cand");
                        DataTable dt = cand.GetAllActiveRegisteredCandidate(cand);
                        if (dt != null) this.lbNoRec.Text = dt.Rows.Count.ToString();
                        nacr.DataSource = dt;
                        this.radReport.Report = nacr;
                        this.radReport.RefreshReport();
                        this.lbError.Text = "";
                        this.lbWaitState.Text = "";
                        break;


                }
                
            }
        }

        protected void btnCloseClicked(object sender, EventArgs e)
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
            this.lbError.Text = "<script type='text/javascript'>Close();</script>";
        }
        public override ClientIDMode ClientIDMode { get; set; }
    }
}