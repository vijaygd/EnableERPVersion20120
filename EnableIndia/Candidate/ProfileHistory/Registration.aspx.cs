using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Reflection;
using MySql.Data.MySqlClient;
using Telerik;
using Telerik.Web;
using Telerik.Web.UI;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Candidate.ProfileHistory
{

    public partial class Registration : System.Web.UI.Page
    {
        public int candidateID
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

            if (Request.QueryString["cand"] != null)
            {
                this.candidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"]));
            }
            else
            {
                this.candidateID = -1;
            }

            Global.SetUICulture(this.Page);
            Global.SetDefaultButtonOfTheForm(this.Form, BtnRegister);
            if (!Page.IsPostBack)
            {
                GetPeremenetAddesssCounties();
                GetPresentAddesssCounties();
                Global.AuthenticateUser();
                TxtFileNumber.Focus();
                GetDisabilityTypes();
                GetStates();
                foreach (ListItem li in DdlPresentAddressCities.Items)
                {
                    DdlPermanentAddressCities.Items.Add(li);
                }

                if (Request.QueryString["cand"] != null)
                {
                    LnkBtnEducationalQualifications.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnWorkExperience.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnKnowledgeAndTraining.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkBtnJobProfiling.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkButtonCandidateHistory.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    LnkButtonSocioIncomicIndicator.PostBackUrl += "?cand=" + Request.QueryString["cand"].ToString();
                    SpnRegistartionDate.Visible = true;
                    GetCandidateDetails();
                    TxtRegistrationDate.Visible = false;
                    BtnClear.Visible = false;
                }
                else
                {
                    TxtRegistrationDate.Visible = true;
                    LblCandidateIDAtNGO.Visible = true;
                    TxtCandidateIDAtNGO.Visible = true;
                }
                Global.ShowMessageInAlert(this.Form);

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
            DdlPresentAddressCities.Items.FindByValue(this.SpnPresentAdrressHiddenState.InnerText);
            DdlPermanentAddressCities.Items.FindByValue(this.SpnPresentAddressHiddenCitiesID.InnerText);
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

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["cand"] != null)
            {
                Response.Redirect("~/Candidate/ProfileHistory/Registration.aspx", true);
            }
            else
            {
                Response.Redirect("~/Candidate/ProfileHistory/Registration.aspx", true);
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

        private void GetStates()
        {
            StatesBAL st = new StatesBAL();
            MySqlDataReader drStates = st.GetStates("1");

            while (drStates.Read())
            {
                DdlPresentAddressStates.Items.Add(new ListItem(drStates["state_name"].ToString(), drStates["state_id"].ToString()));
                DdlPermanentAddressStates.Items.Add(new ListItem(drStates["state_name"].ToString(), drStates["state_id"].ToString()));
            }
            drStates.Close();
            drStates.Dispose();

            if (DdlPresentAddressStates.Items.Count > 0)
            {
                DdlPresentAddressStates.Items.Insert(0, new ListItem("Select", "-2"));
            }
            else
            {
                DdlPresentAddressStates.Items.Add(new ListItem("No State", "-2"));
            }

            if (DdlPermanentAddressStates.Items.Count > 0)
            {
                DdlPermanentAddressStates.Items.Insert(0, new ListItem("Select", "-2"));
            }
            else
            {
                DdlPermanentAddressStates.Items.Add(new ListItem("No State", "-2"));
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

            if (Page.IsPostBack)
            {
                DdlPermanentAddressCities.Focus();
            }
        }
        #endregion

        private void GetCandidateDetails()
        {
            CandidatesBAL cand = new CandidatesBAL();
            cand.CandidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"]));
            MySqlDataReader drCandidateDetails = cand.GetCandidateDetails(cand.CandidateID.ToString());

            if (drCandidateDetails.Read())
            {
                SpnRegistrationID.InnerText = drCandidateDetails["registration_id"].ToString();
                SpnNgoID.InnerText = drCandidateDetails["ngo_id"].ToString();
                SpanCandidateNGO.InnerText = drCandidateDetails["ngo_name"].ToString();

                if (drCandidateDetails["registration_id"].ToString().Contains("N"))
                {
                    TdMessageForNGO.Visible = true;
                    LblCandidateIDAtNGO.Visible = true;
                    TxtCandidateIDAtNGO.Visible = true;
                    TxtCandidateIDAtNGO.Text = drCandidateDetails["candidate_number_at_ngo"].ToString();
                    TblJoiningFormType.Visible = false;
                }

                TxtFileNumber.Text = drCandidateDetails["file_number"].ToString();
                SpnRegistartionDate.InnerText = Convert.ToDateTime(drCandidateDetails["registration_date"]).ToString("dd/MM/yyyy").Replace("01/01/1900", "");
                TxtRegistrationDate.Text = Convert.ToDateTime(drCandidateDetails["registration_date"]).ToString("dd/MM/yyyy").Replace("01/01/1900", "");
                TxtCandidateFirstName.Text = drCandidateDetails["first_name"].ToString();
                TxtCandidateMiddleName.Text = drCandidateDetails["middle_name"].ToString();
                TxtCandidateLastName.Text = drCandidateDetails["last_name"].ToString();
                DdlDisabilityTypes.Value = drCandidateDetails["disability_id"].ToString();
                SpnHiddenDisabilitySubTypesID.InnerText = drCandidateDetails["disability_sub_type_id"].ToString();
                TxtDateOfBirth.Text = Convert.ToDateTime(drCandidateDetails["date_of_birth"]).ToString("dd/MM/yyyy").Replace("01/01/1900", "");

                if (Convert.ToInt32(drCandidateDetails["age"]) < 200)
                {
                    SpnAge.InnerText = drCandidateDetails["age"].ToString();
                    //SpnAge.InnerText = DateTime.Now.AddYears(Convert.ToDateTime(drCandidateDetails["date_of_birth"]).Year * -1).ToString("yy") + " Years";
                }
                else
                {
                    SpnAge.InnerText = "";
                }
                if (drCandidateDetails["gender"].ToString().Equals("Male"))
                {
                    RdbMale.Checked = true;
                }
                else
                {
                    RdbFemale.Checked = true;
                }

                if (SpnRegistrationID.InnerText.Contains("N"))
                {
                    if (drCandidateDetails["other_ngo_candidate_phone_number"].ToString().Contains("N"))
                    {
                        TblNgoOfficeNuber.Visible = true;
                        SpnNGOOfficeNumber.InnerText = "(" + drCandidateDetails["other_ngo_candidate_phone_number"].ToString() + ")";
                    }
                    else
                    {
                        TblNgoOfficeNuber.Visible = false;
                        TxtPrimaryPhoneNumber.Text = drCandidateDetails["other_ngo_candidate_phone_number"].ToString();
                    }
                }
                else
                {
                    TxtPrimaryPhoneNumber.Text = drCandidateDetails["primary_phone_number"].ToString();
                }
                RdbLastREachableOnPrimaryPhoneNumber.Checked = Convert.ToBoolean(drCandidateDetails["is_last_reachable_on_primary_phone_number"]);
                TxtSecondaryPhoneNumber.Text = drCandidateDetails["secondary_phone_number"].ToString();
                RdbLastReachableOnSecondaryPhoneNumber.Checked = Convert.ToBoolean(drCandidateDetails["is_last_reachable_on_secondary_phone_number"]);
                TxtPresentAddress.Text = drCandidateDetails["present_address"].ToString();
                DdlPresentCountry.Value = drCandidateDetails["present_address_country_id"].ToString();
                SpnPresentAdrressHiddenState.InnerText = drCandidateDetails["present_address_state_id"].ToString();
                SpnPresentAddressHiddenCitiesID.InnerText = drCandidateDetails["present_address_city_id"].ToString();
                TxtPresentAddressPinCode.Text = drCandidateDetails["present_address_pin_code"].ToString();
                RdbLastReachableOnPresentAddress.Checked = Convert.ToBoolean(drCandidateDetails["is_last_reachable_on_present_address"]);

                //Permanent address
                TxtPermanentAddress.Text = drCandidateDetails["permanent_address"].ToString();
                RdbLastReachableOnPermanentAddress.Checked = Convert.ToBoolean(drCandidateDetails["is_last_reachable_on_permanent_address"]);
                DdlPermanentCountry.Value = drCandidateDetails["permanent_address_country_id"].ToString();
                SpnPermanentHiddenStates.InnerText = drCandidateDetails["permanent_address_state_id"].ToString();
                SpnPermanentAddressHiddenCitiesID.InnerText = drCandidateDetails["permanent_address_city_id"].ToString();
                TxtPermanentAddressPinCode.Text = drCandidateDetails["permanent_address_pin_code"].ToString();
                TxtEmailAddress.Text = drCandidateDetails["email_address"].ToString();
                RdbRelevantDocumentsSubmittedYes.Checked = Convert.ToBoolean(drCandidateDetails["are_all_relevant_documents_submitted"]);
                RdbRelevantDocumentsSubmittedNo.Checked = !RdbRelevantDocumentsSubmittedYes.Checked;
                TxtRelevantDocumentDetails.Text = drCandidateDetails["document_details"].ToString();

                if (drCandidateDetails["marital_status"].ToString().ToLower().Equals("single"))
                {
                    RdbSingle.Checked = true;
                }
                else if (drCandidateDetails["marital_status"].ToString().ToLower().Equals("married"))
                {
                    RdbMarried.Checked = true;
                }

                ChkBiodataHardCopy.Checked = Convert.ToBoolean(drCandidateDetails["is_bio_data_hard_copy_submitted"]);
                ChkBiodataSoftCopy.Checked = Convert.ToBoolean(drCandidateDetails["is_bio_data_soft_copy_submitted"]);
                ChkJoiningFormSigned.Checked = Convert.ToBoolean(drCandidateDetails["is_joining_form_signed"]);

                if (!drCandidateDetails["uploaded_photograph_extension"].ToString().Equals(""))
                {
                    Random random = new Random();
                    ImgCandidatePhoto.ImageUrl = cand.GetCandidatePhotoPath(cand.CandidateID, drCandidateDetails["uploaded_photograph_extension"].ToString()) + "?" + "random=" + random.NextDouble();
                    ImgCandidatePhoto.AlternateText = drCandidateDetails["first_name"].ToString() + " " + drCandidateDetails["last_name"].ToString();
                }

                TxtOldRegistrationNumber.Text = drCandidateDetails["old_registration_number"].ToString();
                TxtJoiningFormTypes.Text = drCandidateDetails["joining_form_types"].ToString();
                drCandidateDetails.Close();
                drCandidateDetails.Dispose();
            }
            // Get work experience proof.
            string sQueryString = "select a.emp_proof_received, b.company_code, a.company_id   ";
            sQueryString += " from candidate_work_experience a,  companies b where a.company_id=b.company_id and a.candidate_id=" + this.candidateID;
            sQueryString += " union ";
            sQueryString += " select emp_proof_received, unlisted_company, company_id  ";
            sQueryString += "  from candidate_work_experience   where candidate_id=" + this.candidateID + " and company_id=-1";
            DBAccess db = new DBAccess();
            string resultType = "Reader";
          
            MySqlDataReader wpfReader = (MySqlDataReader)db.ExecuteQuery(sQueryString, null, resultType);
            int i = 0;
            if (wpfReader.HasRows)
            {
                while (wpfReader.Read())
                {
                    Telerik.Web.UI.RadComboBoxItem cbItem = new Telerik.Web.UI.RadComboBoxItem();
                    cbItem.Text =    wpfReader.GetValue(1).ToString();
                    cbItem.Value = wpfReader.GetValue(2).ToString();
                    if (wpfReader.GetValue(0).ToString() == "Y")
                    {
                        cbItem.Checked = true;
                    }
                    this.rcWep.Items.Add(cbItem);
                    this.rcWep.DataBind();
                   
                    i++;
                }
            }

        }

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

        protected void BtnRegisterCandidate_Click(object sender, EventArgs e)
        {
            CandidatesBAL cand = new CandidatesBAL();
            if (Request.QueryString["cand"] != null)
            {
                cand.CandidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"]));
            }
            else
            {
                return;
            }

            cand.NgoID = Convert.ToInt32(SpnNgoID.InnerText);
            if (SpnNgoID.InnerText.Equals("1"))
            {
                cand.CandidateNumberAtNGO = "";
            }
            else
            {
                cand.CandidateNumberAtNGO = TxtCandidateIDAtNGO.Text.Trim();
            }

            cand.FileNumber = TxtFileNumber.Text.Trim();
            try
            {
                cand.RegistrationDate = Convert.ToDateTime(TxtRegistrationDate.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                cand.RegistrationDate = DateTime.Now.ToString("yyyy/MM/dd");
            }

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

            if (Request.QueryString["cand"] != null)
            {

                bool isUpdated = cand.UpdateCandidate(cand);
                if (isUpdated.Equals(true))
                {

                    cand.UploadCandidatePhoto(FuUploadPhoto, cand.CandidateID);
                    string newValues = "";
                    Type type = cand.GetType();
                    PropertyInfo[] proterties = type.GetProperties();
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
                    Global.createAuditTrial(this.Title, newValues, oldValues, null, "Update", Session["username"].ToString());
                    updateEmploymentProof();
                    Global.RedirectAfterSubmit("Candidate updated successfully.", BtnRegister.ID);
                    GetCandidateDetails();
                }
                else
                {
                    Global.ShowMessagesInDiv(this.Page, "Error occurred. Please contact the administrator.");
                }
            }
        }
        public void updateEmploymentProof()
        {
            if (this.rcWep.Items.Count > 0)
            {
                DBAccess db = new DBAccess();
                string sQueryString = "";
                for (int i = 0; i < this.rcWep.Items.Count; i++)
                {
                    sQueryString = "Update candidate_work_experience set emp_proof_received=";
                    if (this.rcWep.Items[i].Checked)
                    {
                        sQueryString += "'Y' where candidate_id=" + this.candidateID + " and company_id=" + this.rcWep.Items[i].Value;
                    }
                    else
                    {
                        sQueryString += "'N' where candidate_id=" + this.candidateID + " and company_id=" + this.rcWep.Items[i].Value;
                    }
                    db.ExecuteQuery(sQueryString, null, "NonQuery".ToString());
                }

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

        private void storeValues()
        {
            oldValues = "<b>Cand Id: </b>" + this.candidateID + ", <b>Reg Id: </b>" + this.SpnRegistrationID + ", ";
            var textBoxes = this.Controls.FindAll().OfType<TextBox>();
            foreach (var t in textBoxes)
            {
                oldValues += "<b>" + t.ID + ": </b>" +  t.Text + ", ";
            }
            var dropDowns = this.Controls.FindAll().OfType<DropDownList>();
            foreach (var d in dropDowns)
            {
                oldValues += "<b>" + d.ID + ": </b>" + d.SelectedItem.Text + ", ";
            }
            var selects = this.Controls.FindAll().OfType<HtmlSelect>();
            foreach (var s in selects)
            {
                oldValues += "<b>" + s.ID + ":  </b>" + s.DataTextField + ", ";
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