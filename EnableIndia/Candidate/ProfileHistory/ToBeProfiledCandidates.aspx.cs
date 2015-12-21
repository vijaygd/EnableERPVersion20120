using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Candidate.ProfileHistory
{

    public partial class ToBeProfiledCandidates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }

          //    Global.SetDefaultButtonOfTheForm(this.Form, BtnSearchToBeProfiledCandidates);
            Global.SetUICulture(this.Page);
            if (!Page.IsPostBack)
            {
                Global.InitializePagingCookies();

                Global.AuthenticateUser();
                //ViewState["totalRecords"] = 0;
                CitiesBAL city = new CitiesBAL();
                MySqlDataReader drCities = city.GetCities("-1");
                Global.FillDropDown(DdlCities, drCities, "city_name", "city_id");
                if (DdlCities.Items.Count > 0)
                {
                    DdlCities.Items.RemoveAt(0);
                    DdlCities.Items.Insert(0, new ListItem("All", "-1"));
                }
                EnableIndia.App_Code.BAL.DisabilityTypesBAL disab = new EnableIndia.App_Code.BAL.DisabilityTypesBAL();
                MySqlDataReader drDisabilities = disab.GetDisabilityTypes();
                Global.FillDropDown(DdlDisabilityType, drDisabilities, "disability_type", "disability_id");
                if (DdlDisabilityType.Items.Count > 0)
                {
                    DdlDisabilityType.Items.RemoveAt(0);
                    DdlDisabilityType.Items.Insert(0, new ListItem("All", "-1"));
                }
            }
  
        }

        protected void BtnSearchToBeProfiledCandidates_Click(object sender, EventArgs e)
        {
            TblSearchResult.Visible = true;
            Request.Cookies["grid_page_number"].Value = "1";
            PopulateToBeProfiledCandidates(0);
        }

        protected void BtnSearchCandidates_Click(object sender, EventArgs e)
        {
            TblSearchResult.Visible = true;
            PopulateToBeProfiledCandidates(0);
        }

        protected void BtnPrint_click(object sender, EventArgs e)
        {
            if (Request.Cookies["candidate_calling"] != null && !Request.Cookies["candidate_calling"].Value.Equals(""))
            {
                string selectedCandidates = String.Empty;

                string[] encryptedCandidateIDs = Request.Cookies["candidate_calling"].Value.Trim().Split('_');
                string decryptedCandidateIDs = String.Empty;

                for (int counter = 0; counter < encryptedCandidateIDs.Length; counter++)
                {
                    selectedCandidates += Global.DecryptID(Convert.ToDouble(encryptedCandidateIDs[counter])).ToString() + ",";
                }

                Session["SelectedCandidates"] = selectedCandidates.Substring(0, selectedCandidates.Length - 1);
                ClientScript.RegisterStartupScript(this.GetType(), "__Popup", "ShowPopUp('../CandidateCallingListPrintForm.aspx',1024,768);", true);
            }
        }

        private void PopulateToBeProfiledCandidates(int currentPageIndex)
        {
            EnableIndia.App_Code.BAL.SearchCandidatesBAL search = new EnableIndia.App_Code.BAL.SearchCandidatesBAL();
            search.SearchFor = TxtSearchFor.Text.Trim();
            search.SearchIn = DdlSearchIn.Value;

            try
            {
                search.DateFrom = Convert.ToDateTime(TxtRegistrationDateFrom.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                search.DateFrom = "1900/1/1";
            }

            try
            {
                search.DateTo = Convert.ToDateTime(TxtRegistrationDateTo.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                search.DateTo = "5000/1/1";
            }

            search.CityID = Convert.ToInt32(DdlCities.Value);
            search.DisabilityID = Convert.ToInt32(DdlDisabilityType.Value);

            if (TxtDateOfBirth.Text.Trim().Equals(""))
            {
                search.DateOfBirth = "1900/01/01";
            }
            else
            {
                search.DateOfBirth = Convert.ToDateTime(TxtDateOfBirth.Text.Trim()).ToString("yyyy/MM/dd");
            }
            search.OldRegistrationNumber = TxtOldRegistrationNumber.Text.Trim();
            search.CurrentPageIndex = currentPageIndex;
            DataTable dt = search.SearchToBeProfiledCandidates(search);
//            LstViewToBeProfiledCandidates.DataSource = search.SearchToBeProfiledCandidates(search);
            LstViewToBeProfiledCandidates.DataSource = dt;
            LstViewToBeProfiledCandidates.DataBind();
             DataPager dtp1 = (DataPager)LstViewToBeProfiledCandidates.FindControl("DataPager1");

         //    this.lbNumbers.Text = dt.Rows.Count.ToString();
            //ViewState["totalRecords"] = totalRecords;
            if (LstViewToBeProfiledCandidates.Items.Count.Equals(0))
            {
                BtnAddToCandidateCalling.Visible = false;
            }
            else
            {
                BtnAddToCandidateCalling.Visible = true;
            }
        }

        protected void LstViewToBeProfiledCandidates_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                HtmlGenericControl LblCandidateName = (HtmlGenericControl)e.Item.FindControl("LblCandidateName");
                CheckBox ChkCandidateName = (CheckBox)e.Item.FindControl("ChkCandidateName");
                LblCandidateName.Attributes.Add("for", ChkCandidateName.ClientID);
                HtmlGenericControl SpnCount = (HtmlGenericControl)e.Item.FindControl("SpnCount");
                if (SpnCount != null)
                    this.lbNumbers.Text = SpnCount.InnerText;

            }
        }
        public void disableControls(Control parent)
        {

            var textBoxes = this.Controls.FindAll().OfType<TextBox>();
            foreach (var t in textBoxes)
            {
                t.Enabled = false;
            }
            var dropDowns = this.Controls.FindAll().OfType<DropDownList>();
            foreach (var d in dropDowns)
            {
                d.Enabled = false;
            }
            var selects = this.Controls.FindAll().OfType<HtmlSelect>();
            foreach (var s in selects)
            {
                s.Disabled = true;
            }
            var buttons = this.Controls.FindAll().OfType<Button>();
            foreach (var b in buttons)
            {
                b.Enabled = false;
            }
        }

    }
}