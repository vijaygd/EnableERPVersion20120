using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Reporting;
using Telerik.ReportViewer;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using MySql;
using MySql.Data;
using MySql.Web;
using MySql.Data.MySqlClient;

namespace EnableIndia.Reports
{
    public partial class RadReport1 : System.Web.UI.Page
    {
        public eGlobals gb = new eGlobals();
        public DataSet sqlDs;
        public MySqlConnection myConn = new MySqlConnection();

        public MySqlCommand mySqlCommand = new MySqlCommand();
        public MySqlDataAdapter mySqlAdapter;
        public DataSet myDataSet = new DataSet();
        public DataTable myDt; // = new DataTable();
        public DataTable tmyDt = new DataTable();   // Temporary for other seraches.....
        public static bool bSearchFlag = false;
        public MySql.Data.MySqlClient.MySqlDataAdapter sqlDa = null;
        public MySql.Data.MySqlClient.MySqlCommandBuilder sqlCmd = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            object rep = "";
            string rReport = "";
            string rptHeader = "";
            if (!Page.IsPostBack)
            {
                rReport = Request.QueryString["Report"];
                rptHeader = Request.QueryString["rptHeader"];
                this.lbHeader.Text = rptHeader;
                switch (rReport)
                {
                    case "PlacementW":
                        rptGotJobWithPlacementsN rpt = new rptGotJobWithPlacementsN();

                        if (Session["reportQuery"] != null)
                        {
                            string sqlStr = Session["reportQuery"].ToString();
                            getRecrods(sqlStr);
                            if (myDt != null)
                            {
                                rpt.table1.DataSource = myDt;
                            }
                            Session["reportQuery"] = null;
                        }
                        rpt.ReportParameters["rptHeader"].Value = rptHeader;
                        this.radReport.ReportSource = rpt;
                        this.radReport.RefreshReport();
                        break;
                    case "GotJob":
                        rptGotJobN rgj = new rptGotJobN();
                        if (Session["reportQuery"] != null)
                        {
                            string sqlStr = Session["reportQuery"].ToString();
                            getRecrods(sqlStr);
                            if (myDt != null)
                            {
                                rgj.table1.DataSource = myDt;
                            }
                            Session["reportQuery"] = null;
                        }
                        rgj.ReportParameters["rptHeader"].Value = rptHeader;
                        this.radReport.ReportSource = rgj;
                        this.radReport.RefreshReport();
                        break;
                    case "Placements":
                        rptPlacementsN rgp = new rptPlacementsN();
                        if (Session["reportQuery"] != null)
                        {
                            string sqlStr = Session["reportQuery"].ToString();
                            getRecrods(sqlStr);
                            if (myDt != null)
                            {
                                rgp.table1.DataSource = myDt;
                            }
                            Session["reportQuery"] = null;
                        }
                        rgp.ReportParameters["rptHeader"].Value = rptHeader;
                        this.radReport.ReportSource = rgp;
                        this.radReport.RefreshReport();
                        break;

                }

            }
        }

        private void getRecrods(string sQueryString)
        {
            myConn = gb.SetLocalConnection();
            myDt = new DataTable();
            //string sqlStr = "select agentid, company, first_name, email, address1, city, state, pincode, mobile  from agent_master where status <> 'inactive'";
            mySqlAdapter = new MySqlDataAdapter(sQueryString, myConn);
            myDataSet = new DataSet();
            mySqlAdapter.SelectCommand.CommandTimeout = 1200;
            //      mySqlAdapter.Fill(myDataSet);
            mySqlAdapter.Fill(myDt);
            ViewState["myDt"] = myDt;

        }


        protected void btnCloseClicked(object sender, EventArgs e)
        {
            CloseRadWindow();
        }
        private void CloseRadWindow()
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }

    }
}