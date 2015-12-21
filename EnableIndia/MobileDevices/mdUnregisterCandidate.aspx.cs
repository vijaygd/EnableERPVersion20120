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
using System.Text;
using System.Text.RegularExpressions;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.MobileDevices
{
    public partial class mdUnregisterCandidate : System.Web.UI.Page
    {
        public MySqlCommand mySqlCommand = new MySqlCommand();
        public MySqlDataAdapter mySqlAdapter;
        public DataSet myDataSet = new DataSet();
        public DataTable myDt; // = new DataTable();
        public DataTable tmyDt = new DataTable();   // Temporary for other seraches.....
        eGlobals gb = new eGlobals();
        public MySqlConnection myConn = new MySqlConnection();
        public static bool bSearchFlag = false;
        public MySql.Data.MySqlClient.MySqlDataAdapter sqlDa = null;
        public MySql.Data.MySqlClient.MySqlCommandBuilder sqlCmd = null;
        string candName;
        string candReg;
        public string sqlStr = " select sql_calc_found_rows  " + 
            "  distinct cand.registration_id, " + 
            "  cand.candidate_id, " + 
            "  cand_other_detl.candidate_name_with_status as candidate_name, " + 
            "  cand.registration_id as rid, " + 
            "  dis.disability_type, " + 
            "  cand.candidate_educational_qualifications as educational_qualifications, " +
            "  concat(cand.primary_phone_number, cand.secondary_phone_number) as phone_numbers, " + 
            "  cand.email_address, " + 
            "  cand.ngo_id, " + 
            "  ngo.ngo_name, " + 
            "  fun_calculate_unemployed_days(cand.registration_date,cand_work_expr.designation_expiry_date,CURDATE())as unemployed_days, " + 
            "  if(0=0,ifnull(cand_cur_comp.current_company,''),'')as current_company, " + 
            "  if(0 > 0,cast(0 as char),'Employed') as unemployed_from_days, " + 
            "  cand.recommended_job_types as recommended_job_types, " + 
            "  cand.recommended_job_roles as recommended_roles, " + 
            "  cand.old_registration_number, " + 
            "  cand.date_of_birth " +  
            " from candidates cand " + 
            " left join candidate_other_details cand_other_detl on cand_other_detl.candidate_id=cand.candidate_id " + 
            " left JOIN ngos ngo on cand.ngo_id=ngo.ngo_id " + 
            " left JOIN disability_types dis on cand.disability_id = dis.disability_id " + 
            " left join cities city on cand.present_address_city_id=city.city_id " + 
            " LEFT JOIN (select " + 
            "   candidate_id, " + 
            "   max(designation_to_date) as designation_expiry_date " + 
            "   from candidate_work_experience " + 
            "   where mark_deleted=0 " + 
            "   group by candidate_id)as cand_work_expr on cand.candidate_id = cand_work_expr.candidate_id " + 
            "  " + 
            " LEFT JOIN(select " + 
            "       distinct cand_work_expr.candidate_id, " + 
            "       if(cand_work_expr.company_id=-1,cand_work_expr.unlisted_company,comp.company_code)as current_company, " + 
            "       designation_to_date " + 
            "      from candidate_work_experience cand_work_expr " + 
            "        left JOIN(select  " + 
            "          candidate_id, " + 
            "          max(designation_to_date) as designation_expiry_date " + 
            "         from candidate_work_experience " + 
            "         where mark_deleted=0 " + 
            "         group by candidate_id)as cur_desig on cand_work_expr.designation_to_date = cur_desig.designation_expiry_date " + 
            "      LEFT JOIN companies comp on cand_work_expr.company_id=comp.company_id " + 
            "      WHERE cand_work_expr.candidate_id=cur_desig.candidate_id " + 
            "      AND cand_work_expr.mark_deleted=0 " + 
            "      group by candidate_id)as cand_cur_comp on cand.candidate_id=cand_cur_comp.candidate_id where cand.is_active=1 limit 100000; ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpCookie cookie = new HttpCookie("grid_page_number");
                HttpContext.Current.Response.Cookies.Add(cookie);
                loadDataSource();
                string message = Request.QueryString["Message"];
                if(!string.IsNullOrEmpty(message))
                {
                    this.lbError.Text = message;
                    this.updLabel.Update();
                }
            }
            if (Page.IsPostBack)
            {
                myDt = (DataTable)ViewState["myDt"];
                if(ViewState["candReg"] != null)
                {
                    candReg = ViewState["candReg"].ToString();
                }
                if(ViewState["candName"] != null)
                {
                    candName = ViewState["candName"].ToString();
                }

            }
        }
        protected void imageButtonUnRegisterClicked(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = (ImageButton)sender;
            GridViewRow gr = (GridViewRow)ib.NamingContainer;
            candName = gr.Cells[2].Text;
            candReg = gr.Cells[0].Text;
            ViewState["candReg"] = candReg;
            ViewState["candName"] = candName;
            RadWindowManager1.RadConfirm("Unregister this candidate?", "confirmCallBackFn", 280, 100, null, "Unregister");
        }
        protected void btnYesClicked(object sender, EventArgs e)
        {
          //  this.ModalPopupExtender1.Hide();
            UnregisterCandidate();
            return;
        }
        private void UnregisterCandidate()
        {
            string message = string.Empty;
            MySqlCommand command = new MySqlCommand();
            string statString = string.Empty;
            bool bUnStat = false;
            try
            {
                string sQueryString = string.Empty;
                myConn = gb.SetLocalConnection();
                MySqlConnection conn = new MySqlConnection();

                //string sqlStr = "select agentid, company, first_name, email, address1, city, state, pincode, mobile  from agent_master where status <> 'inactive'";
                command = new MySqlCommand(sqlStr, myConn);
                sQueryString = "update candidates set is_active=0 where registration_id = '" + candReg + "'";
                command.CommandText = sQueryString;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                statString = "Successfully unregistered";
                bUnStat = true;
            }
            catch (System.Exception ex)
            {
                statString = "Error: " + ex.Message;
            }
            finally
            {
                myConn.Close();
                command.Dispose();
                myConn.Dispose();
            }
            MsgBox(statString);
            if (bUnStat)
            {
                myDt.Clear();
                this.grCandidates.DataSource = null;
                this.grCandidates.DataBind();
                loadDataSource();
            }
        }
        protected void btnNoClicked(object sender, EventArgs e)
        {
           // this.ModalPopupExtender1.Hide();
        }
        
        protected void Hdn_Click(object sender, EventArgs e)
        {
            UnregisterCandidate();
            
        }
        protected void grCandidatesChanging(object sender, GridViewPageEventArgs e)
        {
            this.grCandidates.DataSource = myDt;
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[7].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            }
        }
        private SearchCandidatesBAL loadReport()
        {
            EnableIndia.App_Code.BAL.SearchCandidatesBAL search = new EnableIndia.App_Code.BAL.SearchCandidatesBAL();
            Request.Cookies["grid_page_number"].Value = "1";
            search.EmploymentStatus = -1;
            search.Assignment = "All";
            search.CityID = -1;
            search.AgeGroup = -1;
            search.NgoID = -1;
            search.DisabilityID = -1;
            search.SearchFor = "";
            search.SearchIn = DdlSearchIn.Value;
            search.DateOfBirth = "1900/01/01";
            search.JobTypeId = -1;
            search.RecommendedJobRoleID = -1;
            search.OldRegistrationNumber = string.Empty;
            search.MissingDataInProfile = "All";
            SpnHiddenRecommendedRole.InnerText = "-1";
            return search;
        }
        protected void btnCloseClick(object sender, EventArgs e)
        {
            Response.Redirect("~/MobileDevices/mdDefaultPage.aspx", false);
        }
        private void MsgBox(string message)
        {
            webMessageBox wb = new webMessageBox();
            wb.Show(message);
        }
        protected void btnGetClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TxtSearchFor.Text))
            {
                MsgBox("Nothing for search");
                return;
            }
            int iSelected = this.DdlSearchIn.SelectedIndex;
            int i = 0;
            bool[] dRecs = new bool[1];

            switch (iSelected)
            {
                case -1:
                case 0:
                    dRecs = new bool[myDt.Rows.Count + 1];
                    if (string.IsNullOrEmpty(this.TxtSearchFor.Text)) return;
                    foreach (DataRow dr in myDt.Rows)
                    {
                        Match match = Regex.Match(dr[2].ToString().ToUpper(), this.TxtSearchFor.Text.ToUpper());
                        if (match.Success)
                        {
                            dRecs[i] = false;
                        }
                        else
                        {
                            dRecs[i] = true;
                        }
                        i++;
                    }
                    break;
                case 1:
                case 2:
                    int iCol = iSelected == 1 ? 0 : 1;
                    dRecs = new bool[myDt.Rows.Count + 1];
                    if (string.IsNullOrEmpty(this.TxtSearchFor.Text)) return;
                    foreach (DataRow dr in myDt.Rows)
                    {
                        if (dr[iCol].ToString().Trim() == this.TxtSearchFor.Text.Trim())
                        {
                            dRecs[i] = false;
                        }
                        else
                        {
                            dRecs[i] = true;
                        }
                        i++;
                    }
                    break;
            }
            int j = 0;
            for (i = 0; i < dRecs.GetLength(0); i++)
            {
                if (dRecs[i])
                {
                    myDt.Rows[i].Delete();
                    j++;
                }
            }
            myDt.AcceptChanges();
            ViewState["dt"] = myDt;
            this.grCandidates.DataSource = myDt;
            this.grCandidates.DataBind();
        }
        public void loadDataSource()
        {
            this.lbError.Text = "Please wait....";
            this.updLabel.Update();
            try
            {
                myConn = gb.SetLocalConnection();
                MySqlConnection conn = new MySqlConnection();
                myDt = new DataTable();

                //string sqlStr = "select agentid, company, first_name, email, address1, city, state, pincode, mobile  from agent_master where status <> 'inactive'";
                MySqlCommand command = new MySqlCommand(sqlStr, myConn);
                // Add the parameters for the SelectCommand.
                //command.Parameters.Add("@phone_numbers", MySqlDbType.String);
                //command.Parameters.Add("@unemployed_from_days", MySqlDbType.Int32);

                mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = command;
                myDataSet = new DataSet();
                mySqlAdapter.SelectCommand.CommandTimeout = 1200;
                //      mySqlAdapter.Fill(myDataSet);
                mySqlAdapter.Fill(myDt);
                if (myDt.Rows.Count <= 0)
                {
                    this.lbError.Text = "No records found according to selection";
                    this.updLabel.Update();
                    return;
                }
                // Preferbaly clear first to avoid duplicates....
                // ----------------------------------------------
                this.grCandidates.DataSource = myDt;
                this.grCandidates.DataBind();
                ViewState["myDt"] = myDt;
                this.lbNoRec.Text = myDt.Rows.Count.ToString("######");
            }
            catch (System.Exception ex)
            {
                MsgBox("Sorry ! no records found" + ex.Message);
                this.lbNoRec.Text = "";
            }
            this.lbError.Text = "Record loaded";
        }
        protected void btnResetClicked(object sender, EventArgs e)
        {
            loadDataSource();
        }
    }
}