using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Sql;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.MobileDevices.ProfileHistory
{
    public partial class mdAllActiveCandidates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetUICulture(this.Page);
            Global.SetDefaultButtonOfTheForm(this.Form, BtnSearch);
            if (!Page.IsPostBack)
            {
                Global.InitializePagingCookies();
                Global.AuthenticateUser();
                Label lbh = this.Form.Parent.FindControl("lbHeader") as Label;
                if (lbh != null)
                {
                    lbh.Text = "All Active Registered Candidates";
                }
 
                EnableIndia.App_Code.BAL.CitiesBAL city = new EnableIndia.App_Code.BAL.CitiesBAL();
                MySqlDataReader drCities = city.GetCities("-1");
                Global.FillDropDown(DdlCities, drCities, "city_name", "city_id");
                if (DdlCities.Items.Count > 0)
                {
                    DdlCities.Items.RemoveAt(0);
                    DdlCities.Items.Insert(0, new ListItem("All", "-1"));
                }

                //job type
                EnableIndia.App_Code.BAL.JobsBAL job = new EnableIndia.App_Code.BAL.JobsBAL();
                MySqlDataReader drJob = job.GetJobs();
                Global.FillDropDown(DdlJobType, drJob, "job_name", "job_id");
                if (DdlJobType.Items.Count > 0)
                {
                    DdlJobType.Items.RemoveAt(0);
                    DdlJobType.Items.Insert(0, new ListItem("All", "-1"));
                }

                //Populates age groups
                Global glob = new Global();
                glob.GetAgeGroups(DdlAgeGroups);
                DefaultsBAL def = new DefaultsBAL();
                DdlAgeGroups.Value = def.GetDefaultAgeGroupForSearch();

                NGOsBAL ngo = new NGOsBAL();
                MySqlDataReader drNgos = ngo.GetNGOs(true);
                Global.FillDropDown(DdlNGOs, drNgos, "ngo_name", "ngo_id");
                if (DdlNGOs.Items.Count > 0)
                {
                    DdlNGOs.Items.RemoveAt(0);
                    DdlNGOs.Items.Insert(0, new ListItem("All", "-1"));
                }
                DdlNGOs.Items.Add(new ListItem("Others", "-2"));

                EnableIndia.App_Code.BAL.DisabilityTypesBAL disab = new EnableIndia.App_Code.BAL.DisabilityTypesBAL();
                MySqlDataReader drDisabilities = disab.GetDisabilityTypes();
                Global.FillDropDown(DdlDisabilities, drDisabilities, "disability_type", "disability_id");
                if (DdlDisabilities.Items.Count > 0)
                {
                    DdlDisabilities.Items.RemoveAt(0);
                    DdlDisabilities.Items.Insert(0, new ListItem("All", "-1"));
                }

                DataTable dt = new DataTable();
                LstViewAllActiveCandidates.DataSource = dt;
                LstViewAllActiveCandidates.DataBind();
            }

            EnableIndia.App_Code.BAL.JobRolesBAL HiddenRoles = new EnableIndia.App_Code.BAL.JobRolesBAL();
            MySqlDataReader drHiidenRoles = HiddenRoles.GetJobRoles("-1");
            while (drHiidenRoles.Read())
            {
                ListItem li = new ListItem(drHiidenRoles["job_role_name"].ToString(), drHiidenRoles["job_role_id"].ToString());
                li.Attributes.Add("JobID", drHiidenRoles["job_id"].ToString());
                DdlHiddenRecommendedRole.Items.Add(li);
            }
            DdlHiddenRecommendedRole.Items.Insert(0, new ListItem("All", "-1"));
            DdlHiddenRecommendedRole.Items.Add(new ListItem("Not Available", "-3"));
            drHiidenRoles.Close();

        }
        protected void BtnPrint_click(object sender, EventArgs e)
        {

        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            TblSearchResult.Visible = true;
            EnableIndia.App_Code.BAL.SearchCandidatesBAL search = new EnableIndia.App_Code.BAL.SearchCandidatesBAL();
            Request.Cookies["grid_page_number"].Value = "1";
            search.EmploymentStatus = Convert.ToInt32(DdlEmploymentStatus.Value);
            search.Assignment = DdlAssignment.Value;
            search.CityID = Convert.ToInt32(DdlCities.Value);
            search.AgeGroup = Convert.ToInt32(DdlAgeGroups.Value);
            search.NgoID = Convert.ToInt32(DdlNGOs.Value);
            search.DisabilityID = Convert.ToInt32(DdlDisabilities.Value);
            search.SearchFor = TxtSearchFor.Text.Trim();
            search.SearchIn = DdlSearchIn.Value;
            if (TxtDateOfBirth.Text.Trim().Equals(""))
            {
                search.DateOfBirth = "1900/01/01";
            }
            else
            {
                search.DateOfBirth = Convert.ToDateTime(TxtDateOfBirth.Text.Trim()).ToString("yyyy/MM/dd");
            }
            search.JobTypeId = Convert.ToInt32(DdlJobType.Value);
            if (TxtHiddenRecommendedRole.Text.Trim() == "-1")
            {
                search.RecommendedJobRoleID = -1;
            }
            else
                if (TxtHiddenRecommendedRole.Text.Trim() == "-2")
                {
                    search.RecommendedJobRoleID = -2;
                }
                else
                    if (TxtHiddenRecommendedRole.Text.Trim() == "-3")
                    {
                        search.RecommendedJobRoleID = -3;
                    }
            //string hiddenval = TxtHiddenRecommendedRole.Text.Trim();
            //search.RecommendedJobRoleID = Int32.Parse("-1");
            SpnHiddenRecommendedRole.InnerText = TxtHiddenRecommendedRole.Text.Trim();
            search.OldRegistrationNumber = TxtOldRegistraionNumber.Text.Trim();
            search.MissingDataInProfile = DdlMissingData.Value;

            LstViewAllActiveCandidates.DataSource = search.SearchAllActiveCandidates(search);
            LstViewAllActiveCandidates.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "__attachlabel", "", true);

            BtnSearch.Focus();
            if (LstViewAllActiveCandidates.Items.Count.Equals(0))
            {
                BtnAddToCandidateCalling.Visible = false;
                TblCountDetail.Visible = false;
            }
            else
            {
                BtnAddToCandidateCalling.Visible = true;
                TblCountDetail.Visible = true;
            }

        }
        protected void BtnSearchCandidates_Click(object sender, EventArgs e)
        {
            TblSearchResult.Visible = true;
            EnableIndia.App_Code.BAL.SearchCandidatesBAL search = new EnableIndia.App_Code.BAL.SearchCandidatesBAL();
            search.EmploymentStatus = Convert.ToInt32(DdlEmploymentStatus.Value);
            search.Assignment = DdlAssignment.Value;
            search.CityID = Convert.ToInt32(DdlCities.Value);
            search.AgeGroup = Convert.ToInt32(DdlAgeGroups.Value);
            search.NgoID = Convert.ToInt32(DdlNGOs.Value);
            search.DisabilityID = Convert.ToInt32(DdlDisabilities.Value);
            search.SearchFor = TxtSearchFor.Text.Trim();
            search.SearchIn = DdlSearchIn.Value;
            if (TxtDateOfBirth.Text.Trim().Equals(""))
            {
                search.DateOfBirth = "1900/01/01";
            }
            else
            {
                search.DateOfBirth = Convert.ToDateTime(TxtDateOfBirth.Text.Trim()).ToString("yyyy/MM/dd");
            }
            search.JobTypeId = Convert.ToInt32(DdlJobType.Value);
            search.RecommendedJobRoleID = Convert.ToInt32(TxtHiddenRecommendedRole.Text.Trim());
            SpnHiddenRecommendedRole.InnerText = TxtHiddenRecommendedRole.Text.Trim();
            search.OldRegistrationNumber = TxtOldRegistraionNumber.Text.Trim();
            search.MissingDataInProfile = DdlMissingData.Value;

            LstViewAllActiveCandidates.DataSource = search.SearchAllActiveCandidates(search);
            LstViewAllActiveCandidates.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "__attachlabel", "", true);

            BtnSearch.Focus();
            if (LstViewAllActiveCandidates.Items.Count.Equals(0))
            {
                BtnAddToCandidateCalling.Visible = false;
                TblCountDetail.Visible = false;
            }
            else
            {
                BtnAddToCandidateCalling.Visible = true;
                TblCountDetail.Visible = true;
            }

        }
        protected void LstViewAllActiveCandidates_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl LblCandidateName = (HtmlGenericControl)e.Item.FindControl("LblCandidateName");
                CheckBox ChkCandidateName = (CheckBox)e.Item.FindControl("ChkCandidateName");
                LblCandidateName.Attributes.Add("for", ChkCandidateName.ClientID);

                HtmlGenericControl SpnCount = (HtmlGenericControl)e.Item.FindControl("SpnCount");
                SpnTextCount.InnerText = SpnCount.InnerText;
            }
        }
    }
}