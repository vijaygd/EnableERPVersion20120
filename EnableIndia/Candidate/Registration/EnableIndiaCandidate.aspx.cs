using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using MySql.Data.MySqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Candidate.Registration
{

    public partial class EnableIndiaCandidate : System.Web.UI.Page
    {
        public string oldValues;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }
            Label lbUser = (Label)Master.FindControl("lbUser");
            if (lbUser != null)
            {
                lbUser.Text = Session["username"].ToString();
            }

            Global.SetUICulture(this.Page);
            Global.SetDefaultButtonOfTheForm(this.Form, BtnRegisterCandidate);
            
            if (!Page.IsPostBack)
            {
                Global.AuthenticateUser();
                TxtFileNumber.Focus();
                GetDisabilityTypes();
                GetPresentAddesssCounties();
                GetPeremenetAddesssCounties();

                foreach (ListItem li in DdlPresentAddressCities.Items)
                {
                    DdlPermanentAddressCities.Items.Add(li);
                }

                if (Request.QueryString["cand"] != null)
                {
                    GetCandidateDetails();
                    BtnClear.Visible = false;
                }
                Global.ShowMessageInAlert(this.Form);
                if (Session["role_id"] != null)
                {
                    if (Session["role_id"].ToString() == "1")
                    {
                        disableControls(Page);
                    }
                }
            }
                CitiesBAL presentCity = new CitiesBAL();
                MySqlDataReader drPresentCity = presentCity.GetCities("-1");
                while (drPresentCity.Read())
                {
                    ListItem li = new ListItem(drPresentCity["city_name"].ToString(), drPresentCity["city_id"].ToString());
                    li.Attributes.Add("StateID", drPresentCity["state_id"].ToString());
                    DdlPresentAddressHiddenCities.Items.Add(li);
                }
                drPresentCity.Close();
                drPresentCity.Dispose();
                DdlPresentAddressHiddenCities.Items.Insert(0, new ListItem("Select", "-2"));
                DdlPresentAddressHiddenCities.Items.Add(new ListItem("Not Available", "-3"));

                CitiesBAL permenantCity = new CitiesBAL();
                MySqlDataReader drCity = permenantCity.GetCities("-1");
                while (drCity.Read())
                {
                    ListItem li = new ListItem(drCity["city_name"].ToString(), drCity["city_id"].ToString());
                    li.Attributes.Add("StateID", drCity["state_id"].ToString());
                    DdlPermanentAddressHiddenCities.Items.Add(li);
                }
                drCity.Close();
                drCity.Dispose();
                DdlPermanentAddressHiddenCities.Items.Insert(0, new ListItem("Select", "-2"));
                DdlPermanentAddressHiddenCities.Items.Add(new ListItem("Not Available", "-3"));

                DisabilitySubTypesBAL subTypes = new DisabilitySubTypesBAL();
                MySqlDataReader drSubtypes = subTypes.GetDisabilitySubTypes("-1");
                while (drSubtypes.Read())
                {
                    ListItem li = new ListItem(drSubtypes["disability_sub_type"].ToString(), drSubtypes["disability_sub_type_id"].ToString());
                    li.Attributes.Add("DisabiltyTypeID", drSubtypes["disability_id"].ToString());
                    DdlHiddenDisabilitySubTypes.Items.Add(li);
                }
                drSubtypes.Close();
                drSubtypes.Dispose();
                DdlHiddenDisabilitySubTypes.Items.Insert(0, new ListItem("Select", "-2"));
                DdlHiddenDisabilitySubTypes.Items.Add(new ListItem("Not Available", "-3"));

                //populate hidden state
                StatesBAL st = new StatesBAL();
                MySqlDataReader drStates = st.GetStates("-1");
                while (drStates.Read())
                {
                    ListItem li = new ListItem(drStates["state_name"].ToString(), drStates["state_id"].ToString());
                    li.Attributes.Add("CountryID", drStates["country_id"].ToString());
                    DdlPresentAdrressHiddenState.Items.Add(li);
                }
                drStates.Close();
                drStates.Dispose();
                DdlPresentAdrressHiddenState.Items.Insert(0, new ListItem("Select", "-2"));
                DdlPresentAdrressHiddenState.Items.Add(new ListItem("Not Available", "-3"));

                StatesBAL stPerment = new StatesBAL();
                MySqlDataReader drStatesPermenent = stPerment.GetStates("-1");
                while (drStatesPermenent.Read())
                {
                    ListItem li = new ListItem(drStatesPermenent["state_name"].ToString(), drStatesPermenent["state_id"].ToString());
                    li.Attributes.Add("CountryID", drStatesPermenent["country_id"].ToString());
                    DdlPermanentHiddenStates.Items.Add(li);
                }
                drStatesPermenent.Close();
                drStatesPermenent.Dispose();
                DdlPermanentHiddenStates.Items.Insert(0, new ListItem("Select", "-2"));
                DdlPermanentHiddenStates.Items.Add(new ListItem("Not Available", "-3"));
            if (Page.IsPostBack)
            {
                //if (ViewState["State"] != null)
                //{
                //    this.DdlPresentAddressStates.SelectedIndex = Convert.ToInt32(ViewState["State"]);
                //    this.DdlPresentAdrressHiddenState.SelectedIndex = Convert.ToInt32(ViewState["State"]);
                //}
                //if (ViewState["City"] != null)
                //{
                //    this.DdlPresentAddressCities.SelectedIndex = Convert.ToInt32(ViewState["State"]);
                //    this.DdlPresentAddressHiddenCities.SelectedIndex = Convert.ToInt32(ViewState["State"]);
                //}
                //if (ViewState["Country"] != null)
                //{
                //    this.DdlPresentCountry.SelectedIndex = Convert.ToInt32(ViewState["Country"]);
                //}
                //rbsapClicked(null, null);

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

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["cand"] != null)
            {
                Response.Redirect("~/Candidate/Registration/EnableIndiaCandidate.aspx", true);
            }
            else
            {
                Response.Redirect("~/Candidate/Registration/EnableIndiaCandidate.aspx", true);
            }
        }

        #region GETS DISABILITY TYPES AND ITS SUB TYPES
        protected void GetDisabilityTypes()
        {
            EnableIndia.App_Code.BAL.DisabilityTypesBAL get = new EnableIndia.App_Code.BAL.DisabilityTypesBAL();
            MySqlDataReader drDisabilityTypes = get.GetDisabilityTypes();
            Global.FillDropDown(DdlDisabilityTypes, drDisabilityTypes, "disability_type", "disability_id");
        }

        protected void BtnPopulateDisabilitySubTypes_Click(object sender, EventArgs e)
        {
            DisabilitySubTypesBAL get = new DisabilitySubTypesBAL();
            MySqlDataReader drDisabilitySubTypes = get.GetDisabilitySubTypes(DdlDisabilityTypes.Value);
            Global.FillDropDown(DdlDisabilitySubTypes, drDisabilitySubTypes, "disability_sub_type", "disability_sub_type_id");

            if (DdlDisabilitySubTypes.Items.Count > 1)
            {
                DdlDisabilitySubTypes.Items.Add(new ListItem("Others", "-1"));
            }

            if (Page.IsPostBack)
            {
                DdlDisabilitySubTypes.Focus();
            }
        }
        #endregion

        private void GetPresentAddesssCounties()
        {
            CountriesBAL country = new CountriesBAL();
            MySqlDataReader drCountry = country.GetCountries();
            Global.FillDropDown(DdlPresentCountry, drCountry, "country_name", "country_id");
        }

        private void GetPeremenetAddesssCounties()
        {
            CountriesBAL country = new CountriesBAL();
            MySqlDataReader drCountry = country.GetCountries();
            Global.FillDropDown(DdlPermanentCountry, drCountry, "country_name", "country_id");
        }

        private void GetCandidateDetails()
        {
            CandidatesBAL cand = new CandidatesBAL();
            MySqlDataReader drCandidateDetails = cand.GetCandidateDetails(Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString());

            if (drCandidateDetails.Read())
            {
                TblRegistrationID.Visible = true;
                SpnregistrationID.InnerText = drCandidateDetails["registration_id"].ToString();
                drCandidateDetails.Close();
                drCandidateDetails.Dispose();
            }
            else
            {
                Response.Redirect("~/Candidate/Registration/EnableIndiaCandidate.aspx", true);
            }
        }

        #region GETS CITIES
        protected void BtnPopulatePresentAddressCities_Click(object sender, EventArgs e)
        {
            CitiesBAL city = new CitiesBAL();
            MySqlDataReader drCities = city.GetCities(DdlPresentAddressStates.Value);
            Global.FillDropDown(DdlPresentAddressCities, drCities, "city_name", "city_id");

            if (Page.IsPostBack)
            {
                DdlPresentAddressCities.Focus();
            }
        }

        protected void BtnPopulatePermanentAddressCities_Click(object sender, EventArgs e)
        {
            CitiesBAL city = new CitiesBAL();
            MySqlDataReader drCities = city.GetCities(DdlPermanentAddressStates.Value);
            Global.FillDropDown(DdlPermanentAddressCities, drCities, "city_name", "city_id");
            if (DdlPermanentAddressCities.Items.Count > 0)

                if (Page.IsPostBack)
                {
                    DdlPermanentAddressCities.Focus();
                }
        }
        #endregion

        protected void BtnRegisterCandidate_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(this.TxtEmailAddress.Text))
            //{
            //    string eMail = this.TxtEmailAddress.Text;
            //    Regex regex = new Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            //    Match match = regex.Match(eMail);
            //    if (!match.Success)
            //    {
            //        webMessageBox wb = new webMessageBox();
            //        wb.Show("Wrong e-mail Identification");
            //        this.TxtEmailAddress.Focus();
            //        return;
            //    }
            //}
            CandidatesBAL cand = new CandidatesBAL();

            if (Request.QueryString["cand"] != null)
            {
                cand.CandidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"]));
            }
            cand.NgoID = 1;
            cand.CandidateNumberAtNGO = "";
            cand.FileNumber = TxtFileNumber.Text.Trim();

            cand.FirstName = TxtCandidateFirstName.Text.Trim();
            cand.MiddleName = TxtCandidateMiddleName.Text.Trim();
            cand.LastName = TxtCandidateLastName.Text.Trim();

            cand.DisabilityID = Convert.ToInt32(DdlDisabilityTypes.Value);
            cand.DisabilitySubTypeID = Convert.ToInt32(DdlHiddenDisabilitySubTypes.Value);
            try
            {
                cand.DateOfBirth = Convert.ToDateTime(TxtDateOfBirth.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                cand.DateOfBirth = DateTime.Now.ToString("yyyy/MM/dd");
            }
            try
            {
                cand.RegistrationDate = Convert.ToDateTime(TxtRegistrationDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                cand.RegistrationDate = DateTime.Now.ToString("yyyy/MM/dd");
            }
            string gender = "Male";
            if (RdbFemale.Checked)
            {
                gender = "Female";
            }
            cand.Gender = gender;
            cand.PrimaryPhoneNumber = TxtPrimaryPhoneNumber.Text.Trim();
            cand.IsLastReachableOnPrimaryPhoneNumber = RdbLastREachableOnPrimaryPhoneNumber.Checked;
            cand.SecondaryPhoneNumber = TxtSecondaryPhoneNumber.Text.Trim();
            cand.IsLastReachableOnSecondaryPhoneNumber = RdbLastReachableOnSecondaryPhoneNumber.Checked;

            //Present address
            cand.PresentAddress = TxtPresentAddress.Text.Trim();
            cand.IsLastReachableOnPresentAddress = RdbLastReachableOnPresentAddress.Checked;
            cand.PresentAddressStateID = Convert.ToInt32(DdlPresentAdrressHiddenState.Value);
            cand.PresentAddressCityID = Convert.ToInt32(DdlPresentAddressHiddenCities.Value);
            cand.PresentAddressPinCode = TxtPresentAddressPinCode.Text.Trim();

            //Permanent address
            cand.PermanentAddress = TxtPermanentAddress.Text.Trim();
            cand.IsLastReachableOnPermanentAddress = RdbLastReachableOnPermanentAddress.Checked;
            cand.PermanentAddressStateID = Convert.ToInt32(DdlPermanentHiddenStates.Value);
            cand.PermanentAddressCityID = Convert.ToInt32(DdlPermanentAddressHiddenCities.Value);
            cand.PermanentAddressPinCode = TxtPermanentAddressPinCode.Text.Trim();
            cand.EmailAddress = TxtEmailAddress.Text.Trim();

            //Relevant documents
            cand.AreAllRelevantDocumentSubmitted = RdbRelevantDocumentsSubmittedYes.Checked;
            cand.DocumentDetails = TxtRelevantDocumentDetails.Text.Trim();

            string maritialStatus = "";
            if (RdbSingle.Checked)
            {
                maritialStatus = "Single";
            }
            else if (RdbMarried.Checked)
            {
                maritialStatus = "Married";
            }
            cand.MaritialStatus = maritialStatus;

            cand.IsBiodataHardCopySubmitted = ChkBiodataHardCopy.Checked;
            cand.IsBiodataSoftCopySubmitted = ChkBiodataSoftCopy.Checked;
            cand.IsJoiningFormSigned = ChkJoiningFormSigned.Checked;
            cand.UploadedPhotographExtension = Path.GetExtension(FuUploadPhoto.PostedFile.FileName);
            cand.OldRegistrationNumber = TxtOldRegistrationNumber.Text.Trim();
            cand.JoiningFormTypes = TxtJoiningFormTypes.Text.Trim();

            if (TxtOldRegistrationNumber.Text.Trim() != "")
            {
                //checking duplicate candidate old registration number
                string script = String.Empty;
                int duplicateRecord = cand.CheckDuplicationOfOldRegistrationNumber(cand);
                if (duplicateRecord > 0)
                {
                    script = "alert('Old Registration number already exists.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "__key", script, true);
                    return;
                }
            }

            if (TxtHiddenNumber.Text.Equals("1"))
            {
                //checking duplication for candidate registration
                string script = String.Empty;
                int duplicateRecord = cand.CheckDuplicationCandidateDetails(cand);
                if (duplicateRecord > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "__key", "$('#BtnShowConfirm').click();", true);
                    return;
                }
            }
            string newValues = "";
            Type type = cand.GetType();
            PropertyInfo[] proterties = type.GetProperties();
            int j = 0;
            foreach (var p in proterties)
            {
                newValues += "<b>" + p.Name + ": </b>" + p.GetValue(cand, null) + ", ";

            }
            if (!string.IsNullOrEmpty(newValues))
            {
                int l = newValues.LastIndexOf((char)',');
                if (l > 0)
                    newValues = newValues.Substring(0, l);
            }

            if (Request.QueryString["cand"] != null)
            {
                bool isUpdated = cand.UpdateCandidate(cand);
                if (isUpdated.Equals(true))
                {
                    string url = "?cand=";
                    url += Request.QueryString["cand"];
                    url += "&msg=" + Global.EncryptQueryString("Candidate registered successfully.");
                    url += "&foc=" + Global.EncryptQueryString("null");
                    Global.createAuditTrial("Register Candidate", newValues, oldValues, null, "Update", HttpContext.Current.Session["username"].ToString());
                    Response.Redirect("~/Candidate/ProfileHistory/Registration.aspx" + url, false);
                }
                else
                {
                    Global.ShowMessagesInDiv(this.Page, "Error ocurred. Please contact the administrator.");
                }
            }
            else
            {
                cand.CandidateID = cand.CreateRegisteredCandidate(cand);
                if (cand.CandidateID > 0)
                {
                    string url = "~/Candidate/ProfileHistory/Registration.aspx?cand=" + Global.EncryptID(cand.CandidateID);
                    url += "&msg=" + Global.EncryptQueryString("Candidate registered successfully.");
                    url += "&foc=" + Global.EncryptQueryString("null");
                    cand.UploadCandidatePhoto(FuUploadPhoto, cand.CandidateID);
                    Global.createAuditTrial("Register Candidate", newValues, "", null, "Insert", HttpContext.Current.Session["username"].ToString());
                    Response.Redirect(url, true);
                }
            }
        }
        protected void rbsapClicked(object sender, EventArgs e)
        {
            //if (this.rbSameAsPresent.Checked)
            //{
            //    this.TxtPermanentAddress.Text = this.TxtPresentAddress.Text;
            //    this.DdlPermanentAddressStates.SelectedIndex = this.DdlPresentAddressStates.SelectedIndex;
            //    this.DdlPermanentCountry.SelectedIndex = this.DdlPresentCountry.SelectedIndex;
            //    this.DdlPermanentAddressCities.SelectedIndex = this.DdlPresentAddressCities.SelectedIndex;
            //    this.TxtPermanentAddressPinCode.Text = this.TxtPresentAddressPinCode.Text;
            //    if (this.RdbLastReachableOnPresentAddress.Checked)
            //        this.RdbLastReachableOnPermanentAddress.Checked = true;
            //    this.DdlPresentAddressHiddenCities.SelectedIndex = this.DdlPresentAddressCities.SelectedIndex;
            //    this.DdlPresentAdrressHiddenState.SelectedIndex = this.DdlPresentAddressStates.SelectedIndex;
            //    ViewState["State"] = this.DdlPresentAddressStates.SelectedIndex;
            //    ViewState["City"] = this.DdlPresentAddressCities.SelectedIndex;
            //    ViewState["Country"] = this.DdlPresentCountry.SelectedIndex;
 
            //}
            //else
            //{
            //    this.TxtPermanentAddress.Text = "";
            //    this.DdlPresentAddressStates.SelectedIndex = 0;
            //    this.DdlPermanentAddressCities.SelectedIndex = 0;
            //    this.DdlPermanentCountry.SelectedIndex = 0;
            //    this.TxtPermanentAddressPinCode.Text = "";
            //    this.RdbLastReachableOnPermanentAddress.Checked = false;
            //}
 
        }
        public void  disableControls(Control parent)
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
        }
        private void storeValues()
        {
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
