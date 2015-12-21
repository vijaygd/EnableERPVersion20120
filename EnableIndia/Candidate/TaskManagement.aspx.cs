using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Candidate
{

    public partial class TaskManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetDefaultButtonOfTheForm(this.Form, BtnSearchOpenCandidateTasks);
            Global.SetUICulture(this.Page);

            if (!Page.IsPostBack)
            {
                CandidateFlagsBAL flag = new CandidateFlagsBAL();
                MySqlDataReader drCandidateFlags = flag.GetCandidateFlags(true);
                Global.FillDropDown(DdlFlags, drCandidateFlags, "flag_name", "flag_id");
                DdlFlags.Items[0].Text = "All";
                DdlFlags.Items[0].Value = "-1";

                EnableIndia.App_Code.BAL.EmployeeBAL emp = new EnableIndia.App_Code.BAL.EmployeeBAL();
                MySqlDataReader drEmployee = emp.GetEmployeeListReader();
                Global.FillDropDown(DdlEmployee, drEmployee, "employee_name", "employee_id");
                DdlEmployee.Items[0].Text = "All";
                DdlEmployee.Items[0].Value = "-1";

                EnableIndia.App_Code.BAL.DisabilityTypesBAL disab = new EnableIndia.App_Code.BAL.DisabilityTypesBAL();
                MySqlDataReader drDisabilities = disab.GetDisabilityTypes();
                Global.FillDropDown(DdlDisabiltyTypes, drDisabilities, "disability_type", "disability_id");
                DdlDisabiltyTypes.Items[0].Text = "All";
                DdlDisabiltyTypes.Items[0].Value = "-1";

            }

        }



        protected void BtnSearchOpenCandidateTasks_Click(object sender, EventArgs e)
        {
            EnableIndia.App_Code.BAL.SearchCandidatesBAL searchCandidate = new EnableIndia.App_Code.BAL.SearchCandidatesBAL();
            searchCandidate.SelectedDate = DdlDates.Value;
            try
            {
                searchCandidate.DateFrom = Convert.ToDateTime(TxtDateFrom.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                searchCandidate.DateFrom = "1900/01/01";
            }
            try
            {
                searchCandidate.DateTo = Convert.ToDateTime(TxtDateTo.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                searchCandidate.DateTo = "5000/01/01";
            }
            //searchCandidate.SelectedParameter = DdlParameters.Value;

            //if(DdlParameters.Value == "flag")
            //{
            //    searchCandidate.SelectedParameterValue =Convert.ToInt32(DdlFlags.Value);
            //}
            //if(DdlParameters.Value == "managed_by")
            //{
            //    searchCandidate.SelectedParameterValue = Convert.ToInt32(DdlEmployee.Value);
            //}
            //if(DdlParameters.Value == "Disabilities")
            //{
            //    searchCandidate.SelectedParameterValue = Convert.ToInt32(DdlDisabiltyTypes.Value);
            //}
            searchCandidate.CandidateFlagID = Convert.ToInt32(DdlFlags.Value);
            searchCandidate.EmployeeID = Convert.ToInt32(DdlEmployee.Value);
            searchCandidate.DisabilityID = Convert.ToInt32(DdlDisabiltyTypes.Value);

            searchCandidate.SearchFor = TxtSearchFor.Text.Trim();
            searchCandidate.SearchIn = DdlSearchIn.Value;

            LstViewOpenCandidateTasks.DataSource = searchCandidate.SearchOpenCandidateTasks(searchCandidate);
            LstViewOpenCandidateTasks.DataBind();
            LstViewOpenCandidateTasks.Visible = true;
        }

        protected void LnkOpenCandidateTasks_click(object sender, EventArgs e)
        {
            BtnSearchOpenCandidateTasks_Click(BtnSearchOpenCandidateTasks, new EventArgs());
        }
    }
}