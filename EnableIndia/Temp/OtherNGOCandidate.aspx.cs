using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


namespace EnableIndia.Candidate.Registration
{

    public partial class OtherNGOCandidate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.SetDefaultButtonOfTheForm(this.Form, BtnRegisterCandidate);
            Global.SetUICulture(this.Page);
            if (!Page.IsPostBack)
            {
                Global.AuthenticateUser();
                DdlNGOs.Focus();
                GetNGOs();

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
                populateDropDowns();
            }
            
            if (Page.IsPostBack)
            {
                populateDropDowns(); // Populate the drop downs since it is dynamically created....
                GetSelectedValueFromDropDown(this.DdlPresentAddressStates);
                //if (ViewState["PresentState"] != null)
                //    this.DdlPresentAddressStates.SelectedIndex = Convert.ToInt32(ViewState["PresentState"]);
                //if(ViewState["PresentCity"] != null)
                //    this.DdlPresentAddressCities.SelectedIndex = Convert.ToInt32(ViewState["PresentState"]);
                //if (ViewState["PresentCountry"] != null)
                //    this.DdlPresentCountry.SelectedIndex = Convert.ToInt32(ViewState["PresentCountry"]);

                //if (ViewState["PermState"] != null)
                //    this.DdlPresentAddressStates.SelectedIndex = Convert.ToInt32(ViewState["PresentState"]);
                //if (ViewState["PermCity"] != null)
                //    this.DdlPresentAddressCities.SelectedIndex = Convert.ToInt32(ViewState["PresentState"]);
                //if (ViewState["PermCountry"] != null)
                //    this.DdlPresentCountry.SelectedIndex = Convert.ToInt32(ViewState["PresentCountry"]);

                //rbsapClicked(null, null);
            }
        }

        private void populateDropDowns()
        {
            // populate in hidden dropdown
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

        }
        private void GetNGOs()
        {
            NGOsBAL ngo = new NGOsBAL();
            MySqlDataReader drNGOs = ngo.GetNGOs();
            Global.FillDropDown(DdlNGOs, drNGOs, "ngo_name", "ngo_id");
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
                DdlPresentAddressStates.Items.Add(new ListItem("Not Available", "-2"));
            }

            if (DdlPermanentAddressStates.Items.Count > 0)
            {
                DdlPermanentAddressStates.Items.Insert(0, new ListItem("Select", "-2"));
            }
            else
            {
                DdlPermanentAddressStates.Items.Add(new ListItem("No Available", "-2"));
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
            MySqlDataReader drCandidateDetails = cand.GetCandidateDetails(Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString());

            if (drCandidateDetails.Read())
            {
                TblRegistrationID.Visible = true;
                SpnRegistrationID.InnerText = drCandidateDetails["registration_id"].ToString();

                drCandidateDetails.Close();
                drCandidateDetails.Dispose();
            }
            else
            {
                Response.Redirect("~/Candidate/Registration/OtherNGOCandidate.aspx", true);
            }
        }


        protected void BtnClear_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["cand"] != null)
            {
                Response.Redirect("~/Candidate/Registration/OtherNGOCandidate.aspx", true);
            }
            else
            {
                Response.Redirect("~/Candidate/Registration/OtherNGOCandidate.aspx", true);
            }
        }

        protected void BtnRegisterCandidate_Click(object sender, EventArgs e)
        {
            string upLoadedFile = "";
            if (this.DdlNGOs.SelectedIndex <= 0)
            {
                webMessageBox wmb = new webMessageBox();
                wmb.Show("No NGO Selected");
                return;
            }

            CandidatesBAL cand = new CandidatesBAL();

            if (Request.QueryString["cand"] != null)
            {
                cand.CandidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"]));
            }

            cand.NgoID = Convert.ToInt32(DdlNGOs.Value);
            cand.CandidateNumberAtNGO = TxtCandidateIDNumberAtOtherNGO.Text.Trim();
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
                cand.DateOfBirth = "1900/01/01";
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
             
            if (!string.IsNullOrEmpty(FuUploadPhoto.PostedFile.FileName) || !string.IsNullOrEmpty(this.lbFileUploaded.Text))
            {
                if (this.FuUploadPhoto.HasFile) upLoadedFile = this.FuUploadPhoto.PostedFile.FileName;
                if(!string.IsNullOrEmpty(this.lbFileUploaded.Text)) upLoadedFile = this.lbFileUploaded.Text;
            }
//            cand.UploadedPhotographExtension = Path.GetExtension(FuUploadPhoto.PostedFile.FileName);
            cand.UploadedPhotographExtension = Path.GetExtension(upLoadedFile);
            cand.OldRegistrationNumber = TxtOldRegistrationNumber.Text.Trim();
            cand.JoiningFormTypes = "";

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

            if (Request.QueryString["cand"] != null)
            {
                bool isUpdated = cand.UpdateCandidate(cand);
                if (isUpdated.Equals(true))
                {
                    //Global.RedirectAfterSubmit("Candidate updated successfully.", BtnRegisterCandidate.ID);
                    //Global.ShowMessagesInDiv(this.Page, "Candidate updated sucessfully.");

                    string url = "?cand=";
                    url += Request.QueryString["cand"];
                    url += "&msg=" + Global.EncryptQueryString("Candidate registered successfully.");
                    url += "&foc=" + Global.EncryptQueryString("null");
                    cand.UploadCandidatePhoto(FuUploadPhoto, cand.CandidateID);

                    Response.Redirect("~/Candidate/ProfileHistory/Registration.aspx" + url, false);

                    //Response.Redirect("~/Candidate/Registration/UnregisteredBlankForm.aspx", false);
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

                    Response.Redirect(url, true);
                }
            }

        }
        protected void rbsapClicked(object sender, EventArgs e)
        {
        //    //if (this.rbSameAsPresent.Checked)
        //    //{
        //    //    this.TxtPermanentAddress.Text = this.TxtPresentAddress.Text;
        //    //    this.DdlPermanentAddressStates.SelectedIndex = this.DdlPresentAddressStates.SelectedIndex;
        //    //    this.DdlPermanentCountry.SelectedIndex = this.DdlPresentCountry.SelectedIndex;
        //    //    this.DdlPermanentAddressCities.SelectedIndex = this.DdlPresentAddressCities.SelectedIndex;
        //    //    this.TxtPermanentAddressPinCode.Text = this.TxtPresentAddressPinCode.Text;
        //    //    if (this.RdbLastReachableOnPresentAddress.Checked)
        //    //        this.RdbLastReachableOnPermanentAddress.Checked = true;

        //    //    ViewState["PresentState"] = this.DdlPresentAddressStates.SelectedIndex;
        //    //    ViewState["PresentCity"] = this.DdlPresentAddressCities.SelectedIndex;
        //    //    ViewState["PresentCountry"] = this.DdlPresentCountry.SelectedIndex;

        //    //    ViewState["PermState"] = this.DdlPermanentAddressStates.SelectedIndex;
        //    //    ViewState["PermCity"] = this.DdlPermanentAddressCities.SelectedIndex;
        //    //    ViewState["PermCountry"] = this.DdlPermanentCountry.SelectedIndex;

        //    }
        //    else
        //    {
        //        try
        //        {
        //            this.TxtPermanentAddress.Text = "";
        //            this.DdlPresentAddressStates.SelectedIndex = 0;
        //            this.DdlPermanentAddressCities.SelectedIndex = 0;
        //            this.DdlPermanentCountry.SelectedIndex = 0;
        //            this.TxtPermanentAddressPinCode.Text = "";
        //            this.RdbLastReachableOnPermanentAddress.Checked = false;
        //        }
        //        catch { ;;}
        //    }
        }
        protected void ddParentStateChanged(object sender, EventArgs e)
        {
            ViewState["PresentState"] = this.DdlPresentAddressStates.SelectedIndex;

        }
        public static string GetSelectedValueFromDropDown(HtmlSelect listBox)
        {
            return HttpContext.Current.Request[listBox.UniqueID];
        }
        protected void btnPreviewImage_Click(object sender, EventArgs e)
        {
            if (this.FuUploadPhoto.HasFile)
            {
                string path = Server.MapPath("TempImages");

                FileInfo oFileInfo = new FileInfo(FuUploadPhoto.PostedFile.FileName);
                string fileName = oFileInfo.Name;

                string fullFileName = path + "\\" + fileName;
                string imagePath = "TempImages/" + fileName;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FuUploadPhoto.PostedFile.SaveAs(fullFileName);
                this.ImgCandidatePhoto.ImageUrl = imagePath;
                string[] fname = this.FuUploadPhoto.PostedFile.FileName.Split( (char)'\\');
                string lbName = "";
                if (fname.GetLength(0) > 0)
                {
                    for (int j = 0; j < fname.GetLength(0); j++)
                    {
                        lbName += fname[j] + "\\";
                        if (lbName.Length > 40)
                        {
                            lbName += Environment.NewLine;
                        }
                    }
                }
                else
                {
                    lbName = this.FuUploadPhoto.PostedFile.FileName;
                }
                
                this.lbFileUploaded.Text =  "<p style='font-family:Consolas; font-size:8px; color: Blue;'>" +  lbName + "</p>";
                
            }
        }

 
    }
}