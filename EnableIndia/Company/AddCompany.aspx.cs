using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using Telerik;
using Telerik.Web;
using Telerik.Web.UI;
using System.Reflection;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


namespace EnableIndia.Company
{

    public partial class AddCompany : System.Web.UI.Page
    {
        public string CompanyID
        {
            get;
            set;
        }
        public string oldValues;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }

            Global.SetDefaultButtonOfTheForm(this.Form, BtnManageCompany);
            CitiesBAL city = new CitiesBAL();
            MySqlDataReader drcity = city.GetCities("-1");
            while (drcity.Read())
            {
                ListItem list = new ListItem(drcity["city_name"].ToString(), drcity["city_id"].ToString());
                list.Attributes.Add("StateID", drcity["state_id"].ToString());
                DdlHiddenCities.Items.Add(list);
            }
            drcity.Close();
            drcity.Dispose();

            DdlHiddenCities.Items.Insert(0, new ListItem("Select", "-2"));
            DdlHiddenCities.Items.Add(new ListItem("Not Available", "-3"));


            if (Request.QueryString["comp"] != null)
            {
                this.Title = this.Title.Replace("Add", "Update");
                this.CompanyID = Global.DecryptID(Convert.ToDouble(Request.QueryString["comp"])).ToString();
                LstViewAddCompany.Visible = true;
                //BtnEditCompanyContact.Visible = true;
                BtnAddCompanyContact.Visible = true;

            }
            else
            {
                this.CompanyID = "-2";
                LstViewAddCompany.Visible = false;
                //BtnEditCompanyContact.Visible = false;
                BtnAddCompanyContact.Visible = false;
            }

            if (!Page.IsPostBack)
            {
               // Page.ClientScript.RegisterClientScriptInclude("selective", ResolveUrl(@"AddCompany.js"));
                Global.AuthenticateUser();

                //Gets parent companies in dropdown
                EnableIndia.App_Code.BAL.ParentCompaniesBAL parentComp = new EnableIndia.App_Code.BAL.ParentCompaniesBAL();
                MySqlDataReader drParentCompanies = parentComp.GetParentCompanies();
                Global.FillDropDown(DdlParentCompanies, drParentCompanies, "company_name", "company_id");

                //Gets states in dropdown
                StatesBAL state = new StatesBAL();
                MySqlDataReader drStates = state.GetStates("1");
                Global.FillDropDown(DdlStates, drStates, "state_name", "state_id");

                CompaniesBAL company = new CompaniesBAL();
                MySqlDataReader drCompany = company.GetIndustrySegments();
                Global.FillDropDown(DdlIndustrialSegment, drCompany, "industry_segment", "industry_segment_id");

                //BtnPopulateStates_Click(BtnPopulateStates, new EventArgs());
                if (Request.QueryString["comp"] != null)
                {
                    SpnOperationStatus.InnerText = "Update";
                    GetCompanyDetail();
                    BtnClear.Visible = false;
                    SpnParentCompanyName.InnerText = DdlParentCompanies.Items[DdlParentCompanies.SelectedIndex].Text;
                    DdlParentCompanies.Visible = false;
                }
                Global.ShowMessageInAlert(this.Form);
                //getcompanycontact in listview
                GetCompanyContacts();

            }
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }
            if (!Page.IsPostBack)
            {
                storeValues();
            }
            if (Page.IsPostBack)
            {
                if (ViewState["oldValues"] != null)
                {
                    oldValues = ViewState["oldValues"].ToString();
                }
            }
        }

        private void GetCompanyDetail()
        {

            CompaniesBAL company = new CompaniesBAL();
            MySqlDataReader drCompanyDetails = company.GetcompanyDetails(this.CompanyID);

            if (drCompanyDetails.Read())
            {
                DdlParentCompanies.Value = drCompanyDetails["parent_company_id"].ToString();
                TxtCompanyCode.Text = drCompanyDetails["company_code"].ToString();
                TxtPhoneLandlineOfOffice.Text = drCompanyDetails["phone_number"].ToString();
                TxtFax.Text = drCompanyDetails["fax"].ToString();
                TxtWebsite.Text = drCompanyDetails["website"].ToString();
                TxtAddress.Text = drCompanyDetails["address"].ToString();

                DdlStates.Value = drCompanyDetails["state_id"].ToString();

                //BtnPopulateStates_Click(BtnPopulateStates, new EventArgs());
                SpnHiddenCityID.InnerText = drCompanyDetails["city_id"].ToString();

                //DdlCities.Value = drCompanyDetails["city_id"].ToString();
                TxtPinCode.Text = drCompanyDetails["pin_code"].ToString();
                TxtCompanyDetails.Text = drCompanyDetails["company_details"].ToString();

                DdlIndustrialSegment.Value = drCompanyDetails["industry_segment_id"].ToString();
                drCompanyDetails.Close();
                drCompanyDetails.Dispose();
            }
            else
            {
                Response.Redirect("AddCompany.aspx", true);
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["comp"] != null)
            {
                Response.Redirect("~/Company/AddCompany.aspx", true);
            }
            else
            {
                Response.Redirect("~/Company/AddCompany.aspx", true);
            }
        }


        protected void BtnAddCompanyContact_Click(object sender, EventArgs e)
        {
            GetCompanyContacts();
            BtnAddCompanyContact.Focus();
//if(document.URL.indexOf("msg")==-1){
//        companyID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.length);
//    }
//    else{
//        companyID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.indexOf("&msg"));
//    }
    
//    var url = "AddCompanyContact.aspx?comp=" + companyID;
//    if (strContactID != "-1") {
//        url += "&cont="+ $("#TblAddCompany #" +strLinkButtonID ).attr("CompanyContactID");
//    }
//     url += "&txboxId=" + self.parent.location;            string url = "";
            string url = "";
            int indexOfComp = HttpContext.Current.Request.Url.AbsoluteUri.ToString().IndexOf("?comp=") + 6;
            if (HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("msg") == -1)
            {
                this.CompanyID = HttpContext.Current.Request.Url.AbsoluteUri.Substring(indexOfComp, (HttpContext.Current.Request.Url.AbsoluteUri.Length - indexOfComp));
            }
            else
            {
                int indexOfMsg = HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("&msg");
                this.CompanyID = HttpContext.Current.Request.Url.AbsoluteUri.Substring(indexOfComp, (indexOfMsg - indexOfComp));
            }
            url = "AddCompanyContact.aspx?comp=" + this.CompanyID;
            invokeRadWindow("");
        }

        private void GetCompanyContacts()
        {
            CompanyContactsBAL companycontact = new CompanyContactsBAL();
            LstViewAddCompany.DataSource = companycontact.GetCompanyContacts(this.CompanyID);
            LstViewAddCompany.DataBind();
        }

        protected void BtnPopulateStates_Click(object sender, EventArgs e)
        {
            CitiesBAL city = new CitiesBAL();
            MySqlDataReader drCities = city.GetCities(DdlStates.Value);
            Global.FillDropDown(DdlCities, drCities, "city_name", "city_id");
        }


        protected void BtnManageCompany_Click(object sender, EventArgs e)
        {

            if (this.DdlParentCompanies.SelectedIndex <= 0)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("Parent company must be selected");
                return;
            }
            
            CompaniesBAL company = new CompaniesBAL();

            int duplicateCompanies = company.CheckForDuplicateCompany(this.CompanyID, TxtCompanyCode.Text.Trim());
            if (duplicateCompanies > 0)
            {
                Global.RedirectAfterSubmit("Company already exists.", BtnManageCompany.ID);
            }

            string message = String.Empty;

            company.ParentCompanyID = Convert.ToInt32(DdlParentCompanies.Value);
            company.CompanyCode = TxtCompanyCode.Text.Trim();
            company.PhoneNumber = TxtPhoneLandlineOfOffice.Text.Trim();
            company.Fax = TxtFax.Text.Trim();
            company.Website = TxtWebsite.Text.Trim();
            company.Address = TxtAddress.Text.Trim();
            company.StateID = Convert.ToInt32(DdlStates.Value);
            company.CityID = Convert.ToInt32(DdlHiddenCities.Value);
            company.PinCode = TxtPinCode.Text.Trim();
            company.CompanyDetails = TxtCompanyDetails.Text.Trim();
            company.IndustrySegmentId = Convert.ToInt32(DdlIndustrialSegment.Value);
            string newValues = "";
            Type type = company.GetType();
            PropertyInfo[] proterties = type.GetProperties();
            foreach (var p in proterties)
            {
                newValues += "<b>" + p.Name + ": </b>" + p.GetValue(company, null) + ", ";

            }
            if (!string.IsNullOrEmpty(newValues))
            {
                int l = newValues.LastIndexOf((char)',');
                if (l > 0)
                    newValues = newValues.Substring(0, l);
            }
            if (Request.QueryString["comp"] != null)
            {
                company.CompanyID = Convert.ToInt32(this.CompanyID);
                bool isUpadated = company.UpdateCompany(company);
                if (isUpadated.Equals(true))
                {
                    Global.createAuditTrial(this.Title, newValues, oldValues, null, "Update", Session["username"].ToString());
                    message = "Company updated successfully.";
                }
                else
                {
                    message = "Error occurred. Please contact the administrator";
                }
            }
            else
            {
                company.CompanyID = company.AddCompany(company);
                if (company.CompanyID > 0)
                {
                    string url = "~/Company/AddCompany.aspx?comp=" + Global.EncryptID(Convert.ToInt32(company.CompanyID));
                    url += "&msg=" + Global.EncryptQueryString("Company added successfully.");
                    url += "&foc=" + Global.EncryptQueryString("null");
                    Global.createAuditTrial(this.Title, newValues, "", null, "Insert", Session["username"].ToString());
                    Response.Redirect(url, true);
                }
                else
                {
                    message = "Error occurred. Please contact the administrator.";
                }
            }
            Global.RedirectAfterSubmit(message, BtnManageCompany.ID);
        }
    //    var url = "AddCompanyContact.aspx?comp=" + companyID;
    //if (strContactID != "-1") {
    //    url += "&cont="+ $("#TblAddCompany #" +strLinkButtonID ).attr("CompanyContactID");
    // }
    //ShowPopUp(url, 600, 200);
        protected void LnkBtnCompanyContactName_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;

            GetCompanyContacts();
            string compContactId = lb.Attributes["CompanyContactID"];
            invokeRadWindow(compContactId);

        }
        private void invokeRadWindow(string contId)
        {
            //                 Response.Redirect("~/Training/CandidateNotes.aspx?train_proj=" + Global.EncryptID(trainingProjectID) + "&cand=" + ib.Attributes["CandidateID"]);
            RadWindow rw = new RadWindow();
            if(string.IsNullOrEmpty(contId))
            {
                rw.NavigateUrl = "~/Company/AddCompanyContact.aspx?comp=" + this.CompanyID + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
            }
            else
            {
                rw.NavigateUrl = "~/Company/AddCompanyContact.aspx?comp=" + Global.EncryptID(Convert.ToInt32(this.CompanyID)) + "&cont=" + contId + "&txboxId=" + HttpContext.Current.Request.Url.AbsoluteUri;
            }
            rw.Width = 900;
            rw.Height = 600;
            rw.Top = 0;
            rw.Left = 0;
            rw.MaxHeight = 600;
            rw.MaxWidth = 900;
            rw.Modal = true;
            rw.Behaviors = WindowBehaviors.Maximize | WindowBehaviors.Maximize | WindowBehaviors.Move | WindowBehaviors.Reload | WindowBehaviors.Close;
            rw.KeepInScreenBounds = true;
            //            rw.Behavior = WindowBehaviors.Default;
            rw.ReloadOnShow = true;
            rw.ID = "rwCenquiry";
            //   RadWindowManager rm = (RadWindowManager)this.Parent.FindControl("hradManager");
            this.radManager.Modal = true;
            this.radManager.VisibleOnPageLoad = true;
            rw.EnableViewState = false;
            rw.VisibleOnPageLoad = true;
            this.radManager.EnableViewState = false;
            this.radManager.Windows.Add(rw);
            rw = this.radManager.Windows[0];
            return;
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
        private void storeValues()
        {
            oldValues = "<b>Company Id: </b>" + this.CompanyID + ", ";
            var textBoxes = this.Controls.FindAll().OfType<TextBox>();
            foreach (var t in textBoxes)
            {
                oldValues += "<b>" + t.ID + ": </b>" + t.Text + ", ";
            }
            var dropDowns = this.Controls.FindAll().OfType<DropDownList>();
            foreach (var d in dropDowns)
            {
                oldValues += "<b>" + d.ID + ": </b>" + d.SelectedItem.Text + ", ";
            }
            var selects = this.Controls.FindAll().OfType<HtmlSelect>();
            foreach (var s in selects)
            {
                try
                {
                    int x = s.SelectedIndex;
                    oldValues += "<b>" + s.ID + ":  </b>" + s.Items[x].Text + ", ";
                }
                catch
                { ;;}
            }
            var checkBoxes = this.Controls.FindAll().OfType<CheckBox>();
            foreach (var cb in checkBoxes)
            {
                oldValues += "<b>" + cb.ID + ": </b>" + (cb.Checked ? "1" : "0").ToString();
            }
            var radioButtons = this.Controls.FindAll().OfType<RadioButton>();
            foreach (var rb in radioButtons)
            {
                oldValues += "<b>" + rb.ID + ": </b>" + (rb.Checked ? "1" : "0").ToString();
            }
            if (!string.IsNullOrEmpty(oldValues))
            {
                int l = oldValues.LastIndexOf(",");
                if (l > 0)
                    oldValues = oldValues.Substring(0, l);  // Remove the last unwanted ,
            }
            ViewState["oldValues"] = oldValues;
        }

    }
}
