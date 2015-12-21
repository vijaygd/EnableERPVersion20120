using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnableIndia.Admin
{
    public partial class ViewParameters : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                switch (Request.QueryString["para"].ToString())
                {
                    case "edu":
                        LblColumnHeader.Text = "Education";
                        LblTableName.Text = "courses_qualifications";
                        LblColumnName.Text = "course_qualification_name";
                        BindOtherParametersListView();
                        break;

                    case "dis":
                        LblColumnHeader.Text = "Disability Types";
                        LblTableName.Text = "disability_types";
                        LblColumnName.Text = "disability_type";
                        BindOtherParametersListView();
                        break;

                    case "dis_sub":
                        EnableIndia.App_Code.BAL.DisabilityTypesBAL disibilty = new EnableIndia.App_Code.BAL.DisabilityTypesBAL();
                        LstViewDisibiltyType.DataSource = disibilty.GetdisabilityTypesWithSubTypes();
                        LstViewDisibiltyType.DataBind();
                        TblDisibiltyType.Visible = true;
                        break;

                    case "job":
                        LblColumnHeader.Text = "Job Types";
                        LblTableName.Text = "jobs";
                        LblColumnName.Text = "job_name";
                        BindOtherParametersListView();
                        break;

                    case "role":

                        EnableIndia.App_Code.BAL.JobsBAL role = new EnableIndia.App_Code.BAL.JobsBAL();
                        lstViewJobTypeWithRole.DataSource = role.GetJobsWithJobRoles();
                        lstViewJobTypeWithRole.DataBind();
                        TblJobTypeWithRole.Visible = true;
                        break;

                    case "cand_grp":
                        LblColumnHeader.Text = "Candidate Groups";
                        LblTableName.Text = "candidate_groups";
                        LblColumnName.Text = "group_name";
                        BindOtherParametersListView();
                        break;

                    case "countr":
                        LblColumnHeader.Text = "Countries";
                        LblTableName.Text = "countries";
                        LblColumnName.Text = "country_name";
                        BindOtherParametersListView();
                        break;

                    case "st":
                        EnableIndia.App_Code.BAL.CountriesBAL countyState = new EnableIndia.App_Code.BAL.CountriesBAL();
                        LstviewCountryWithState.DataSource = countyState.GetCountriesWithStates();
                        LstviewCountryWithState.DataBind();
                        TblCountryWithState.Visible = true;
                        break;

                    case "cit":
                        EnableIndia.App_Code.BAL.StatesBAL cityState = new EnableIndia.App_Code.BAL.StatesBAL();
                        LstViewCityWithStateCountry.DataSource = cityState.GetStatesWithCities();
                        LstViewCityWithStateCountry.DataBind();
                        TblCityWithStateCountry.Visible = true;
                        break;

                    case "can_flg":
                        LblColumnHeader.Text = "Candidate Flags";
                        LblTableName.Text = "candidate_flags";
                        LblColumnName.Text = "flag_name";
                        BindOtherParametersListView();
                        break;

                    case "comp_flg":
                        LblColumnHeader.Text = "Company Flags";
                        LblTableName.Text = "company_flags";
                        LblColumnName.Text = "flag_name";
                        BindOtherParametersListView();
                        break;

                    case "lang":
                        LblColumnHeader.Text = "Languages";
                        LblTableName.Text = "languages";
                        LblColumnName.Text = "language_name";
                        BindOtherParametersListView();
                        break;
                    case "indu_seg":
                        LblColumnHeader.Text = "Industry Segment";
                        LblTableName.Text = "industry_segments";
                        LblColumnName.Text = "industry_segment";
                        BindOtherParametersListView();
                        break;
                }
            }
        }

        private void BindOtherParametersListView()
        {
            string query = " select " + LblColumnName.Text + " from " + LblTableName.Text + " ";
            query += " order by " + LblColumnName.Text;

            DBAccess dba = new DBAccess();
            DataTable dtParameters = (DataTable)dba.ExecuteQuery(query, null, "DataTable");
            LstViewParameters.DataSource = dtParameters;
            LstViewParameters.DataBind();
            TblOtherParameters.Visible = true;
        }
    }
}