using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Reflection;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.NGO
{
    public partial class RegisterNGO : System.Web.UI.Page
    {
        public string NgoID
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

            TxtNgoName.Focus();
            Global.SetDefaultButtonOfTheForm(this.Form, BtnRegisterNGO);

            if (Request.QueryString["ngo"] != null)
            {
                this.NgoID = Global.DecryptID(Convert.ToDouble(Request.QueryString["ngo"])).ToString();
            }
            else
            {
                this.NgoID = "-2";
            }

            CitiesBAL city = new CitiesBAL();
            MySqlDataReader drCity = city.GetCities("-1");
            while (drCity.Read())
            {
                ListItem li = new ListItem(drCity["city_name"].ToString(), drCity["city_id"].ToString());
                li.Attributes.Add("StateID", drCity["state_id"].ToString());
                DdlHiddenCities.Items.Add(li);
            }

            drCity.Close();
            drCity.Dispose();

            DdlHiddenCities.Items.Insert(0, new ListItem("Select", "-2"));
            DdlHiddenCities.Items.Add(new ListItem("Not Available", "-3"));

            if (!Page.IsPostBack)
            {
                Global.AuthenticateUser();
                DataTable tbl = new DataTable();

                //Gets states
                StatesBAL st = new StatesBAL();
                MySqlDataReader drStates = st.GetStates("1");
                Global.FillDropDown(DdlStates, drStates, "state_name", "state_id");

                //BtnPopulateCities_Click(DdlStates, new EventArgs());

                GetNGODisabilitySubTypes();
                if (Request.QueryString["ngo"] != null)
                {

                    GetNgoDetails();
                    GetNGOContacts();
                    LblTitle.Text = "Update NGO";
                    LblTitle.Attributes["MessageStartText"] = "Update";

                    BtnResetNGO.Visible = false;
                }

                Global.ShowMessageInAlert(this.Form);
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

        private void GetNgoDetails()
        {
            NGOsBAL ngo = new NGOsBAL();
            MySqlDataReader drDetails = ngo.GetNgoDetails(this.NgoID);
            if (drDetails.Read())
            {
                TxtNgoName.Text = drDetails["ngo_name"].ToString();
                TxtPhoneLandlineOfOffice.Text = drDetails["office_phone_number"].ToString();
                TxtAddress.Text = drDetails["address"].ToString();
                DdlStates.Value = drDetails["state_id"].ToString();
                SpnHiddenCityID.InnerText = drDetails["city_id"].ToString();
                TxtPinCode.Text = drDetails["pin_code"].ToString();
                TxtFax.Text = drDetails["fax"].ToString();
                TxtWebSite.Text = drDetails["website"].ToString();
                TxtNgoDetails.Text = drDetails["ngo_details"].ToString();

                drDetails.Close();
                drDetails.Dispose();
            }
            else
            {
                Response.Redirect("~/NGO/RegisterNGO.aspx", true);
            }
        }

        private void GetNGOContacts()
        {
            NGOContactsBAL contact = new NGOContactsBAL();
            LstViewContacts.DataSource = contact.GetNGOContacts(this.NgoID);
            LstViewContacts.DataBind();
            if (LstViewContacts.Items.Count > 0)
            {
                BtnAddMoreContacts.Visible = true;
                LnkBtnAddMoreContacts.Visible = false;
                SpnContacts.Visible = true;
            }
            else
            {
                if (this.NgoID.Equals("-2"))
                {
                    LnkBtnAddMoreContacts.Visible = false;
                }
                else
                {
                    LnkBtnAddMoreContacts.Visible = true;
                }

                BtnAddMoreContacts.Visible = false;
            }
        }

        //protected void BtnPopulateCities_Click(object sender, EventArgs e)
        //{
        //    //Gets cities
        //    CitiesBAL city = new CitiesBAL();
        //    MySqlDataReader drCities = city.GetCities(DdlStates.Value);
        //    Global.FillDropDown(DdlCities, drCities, "city_name", "city_id");

        //    SpnStateIDForValidation.InnerText = DdlStates.Value;
        //    if(Page.IsPostBack)
        //    {
        //        BtnPopulateCities.Focus();
        //    }
        //}

        private void GetNGODisabilitySubTypes()
        {
            NGOsBAL ngo = new NGOsBAL();
            DataTable dtNGOdisabilitySubTypes = ngo.GetNGODisabilitySubTypes(this.NgoID);
            LstViewNGODisabilitySubTypes.DataSource = dtNGOdisabilitySubTypes;
            LstViewNGODisabilitySubTypes.DataBind();
        }

        protected void LstViewNGODisabilitySubTypes_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                // HtmlGenericControl lblDisabilitySubType = (HtmlGenericControl)e.Item.FindControl("lblDisabilitySubType");
                HtmlGenericControl lblDisabilitySubType = (HtmlGenericControl)e.Item.FindControl("lblDisabilitySubType");
                CheckBox ChkSelectDisabilitySubType = (CheckBox)e.Item.FindControl("ChkSelectDisabilitySubType");

                lblDisabilitySubType.Attributes.Add("for", ChkSelectDisabilitySubType.ClientID);
            }
        }

        protected void BtnRegisterNGO_Click(object sender, EventArgs e)
        {
            NGOsBAL ngo = new NGOsBAL();
            int duplicateNGOs = ngo.CheckForDuplicateNGO(this.NgoID, TxtNgoName.Text.Trim());

            if (duplicateNGOs > 0)
            {
                string errorMessage = "NGO Name already exists. Please use another name.";
                string url = "~/NGO/RegisterNGO.aspx";
                if (this.NgoID.Equals("-2"))
                {
                    url += "?msg=" + Global.EncryptQueryString(errorMessage);
                }
                else
                {
                    url += "?ngo=" + Global.EncryptID(Convert.ToInt32(this.NgoID));
                    url += "&msg=" + Global.EncryptQueryString(errorMessage);
                }


                url += "&foc=" + Global.EncryptQueryString(BtnRegisterNGO.ID);
                Response.Redirect(url, true);
            }


            MySqlConnection conn = Global.GetConnectionString();
            conn.Open();


            MySqlTransaction trans = conn.BeginTransaction();

            MySqlCommand cmd = new MySqlCommand();

            string ngoID = "0";



            MySqlParameter paraNgoID = new MySqlParameter("para_ngo_id", MySqlDbType.Int32);
            if (Request.QueryString["ngo"] != null)
            {
                ngoID = Global.DecryptID(Convert.ToDouble(Request.QueryString["ngo"])).ToString();
                cmd = new MySqlCommand("update_ngo", conn, trans);
                cmd.Parameters.AddWithValue("para_ngo_id", Convert.ToInt32(ngoID));
            }
            else
            {
                cmd = new MySqlCommand("add_ngo", conn, trans);
                paraNgoID.Direction = ParameterDirection.InputOutput;
                paraNgoID.Value = 0;
                cmd.Parameters.Add(paraNgoID);
            }

            cmd.Parameters.AddWithValue("para_ngo_name", TxtNgoName.Text.Trim());
            cmd.Parameters.AddWithValue("para_office_phone_number", TxtPhoneLandlineOfOffice.Text.Trim());
            cmd.Parameters.AddWithValue("para_address", TxtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("para_country_id", 1);
            cmd.Parameters.AddWithValue("para_state_id", Convert.ToInt32(DdlStates.Value));
            cmd.Parameters.AddWithValue("para_city_id", Convert.ToInt32(DdlHiddenCities.Value));
            cmd.Parameters.AddWithValue("para_pin_code", TxtPinCode.Text.Trim());
            cmd.Parameters.AddWithValue("para_fax", TxtFax.Text.Trim());
            cmd.Parameters.AddWithValue("para_website", TxtWebSite.Text.Trim());
            cmd.Parameters.AddWithValue("para_ngo_details", TxtNgoDetails.Text.Trim());

            cmd.CommandType = CommandType.StoredProcedure;
            string message = "";
            string newValues = "";
            Type type = cmd.GetType();
            PropertyInfo[] proterties = type.GetProperties();
            int j = 0;
            for (j = 0;j < cmd.Parameters.Count;j++)
            {
                newValues += "<b>" + cmd.Parameters[j].ParameterName + ": </b>" + cmd.Parameters[j].Value + ", ";
            }
            if (!string.IsNullOrEmpty(newValues))
            {
                int l = newValues.LastIndexOf((char)',');
                if (l > 0)
                    newValues = newValues.Substring(0, l);
            }
            int i = 0;
            for (i = 0; i < this.LstViewNGODisabilitySubTypes.Items.Count; i++)
            {
                HtmlGenericControl  lb = (HtmlGenericControl)LstViewNGODisabilitySubTypes.Items[i].FindControl("lblDisabilitySubType");
                
                if (lb != null)
                {
                    try
                    {
                        newValues += lb.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                    }
                    catch (System.Exception ex)
                    {
                        ; ;
                    }
                }
                CheckBox cb = (CheckBox)this.LstViewNGODisabilitySubTypes.Items[i].FindControl("ChkSelectDisabilitySubType");
                if (cb != null)
                {
                    newValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                }
            }
            try
            {
                //Adds ngo
                cmd.ExecuteNonQuery();
                if (Request.QueryString["ngo"] == null)
                {
                    ngoID = paraNgoID.Value.ToString();
                }

                cmd.Parameters.Clear();

                //Deletes the previous disability types and disability sub types attached to that ngo at the time of updatation only.
                if (Request.QueryString["ngo"] != null)
                {
                    cmd = new MySqlCommand("delete from ngo_disability_sub_types where ngo_id=" + ngoID, conn, trans);
                    cmd.ExecuteNonQuery();
                }

                //Adds ngo disability sub types
                for (int counter = 0; counter < LstViewNGODisabilitySubTypes.Items.Count; counter++)
                {
                    CheckBox ChkSelectDisabilitySubType = (CheckBox)LstViewNGODisabilitySubTypes.Items[counter].FindControl("ChkSelectDisabilitySubType");
                    if (ChkSelectDisabilitySubType.Checked)
                    {
                        cmd = new MySqlCommand("", conn, trans);
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into ngo_disability_sub_types values(" + ngoID + "," + ChkSelectDisabilitySubType.Attributes["DisabilityID"].ToString() + "," + ChkSelectDisabilitySubType.Attributes["DisabilitySubTypeID"].ToString() + ")";
                        cmd.ExecuteNonQuery();
                    }
                }

                trans.Commit();
                if (Request.QueryString["ngo"] != null)
                {
                    Global.createAuditTrial(this.Title, newValues, oldValues, null, "Update", Session["username"].ToString());
                    message = "NGO updated successfully.";
                }
                else
                {
                    Global.createAuditTrial(this.Title, newValues, "", null, "Insert", Session["username"].ToString());
                    message = "NGO added successfully.";
                }

            }
            catch (Exception ex)
            {
                trans.Rollback();
                Global.ShowMessagesInDiv(this.Page, Global.GetGlobalErrorMessage());
                message = ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();


                if (Request.QueryString["ngo"] == null)
                {
                    string url = "~/NGO/RegisterNGO.aspx?ngo=" + Global.EncryptID(Convert.ToInt32(ngoID)).ToString();
                    url += "&msg=" + Global.EncryptQueryString(message) + "&foc=" + Global.EncryptQueryString(BtnRegisterNGO.ID);

                    Response.Redirect(url, true);
                }
                else
                {
                    GetNgoDetails();
                    Global.ShowMessagesInDiv(this.Page, message);
                }
            }

        }

        protected void LnkBtnAddMoreContacts_Click(object sender, EventArgs e)
        {
            GetNGOContacts();
            LnkBtnAddMoreContacts.Focus();
        }

        protected void BtnAddMoreContacts_Click(object sender, EventArgs e)
        {
            GetNGOContacts();
            BtnAddMoreContacts.Focus();
        }

        protected void BtnResetNGO_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ngo"] != null)
            {
                Response.Redirect("~/NGO/RegisterNGO.aspx");
            }
            else
            {
                Response.Redirect("~/NGO/RegisterNGO.aspx");
            }
        }

        protected void LnkBtnContactName_Click(object sender, EventArgs e)
        {
            GetNGOContacts();
            ((LinkButton)sender).Focus();
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
            var checkBoxes = this.Controls.FindAll().OfType<CheckBox>();
            foreach (var cb in checkBoxes)
            {
                cb.Enabled = false;
            }

        }
        private void storeValues()
        {
            oldValues = "";
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
                oldValues += "<b>" + s.ID + ":  </b>" + s.Value + ", ";
            }
            //var checkBoxes = this.Controls.FindAll().OfType<CheckBox>();
            //foreach (var cb in checkBoxes)
            //{
            //    oldValues += "<b>" + cb.ID + ": </b>" + (cb.Checked ? "1" : "0").ToString();
            //}
            var radioButtons = this.Controls.FindAll().OfType<RadioButton>();
            foreach (var rb in radioButtons)
            {
                oldValues += "<b>" + rb.ID + ": </b>" + (rb.Checked ? "1" : "0").ToString();
            }
            int i = 0;
            for (i = 0; i < this.LstViewNGODisabilitySubTypes.Items.Count; i++)
            {
                HtmlGenericControl lb = (HtmlGenericControl)LstViewNGODisabilitySubTypes.Items[i].FindControl("lblDisabilitySubType");
                if (lb != null)
                {
                    try
                    {
                        oldValues += lb.InnerText.TrimStart().TrimEnd().Replace("'", "") + ": ";
                    }
                    catch (System.Exception ex)
                    {
                        ; ;
                    }
                }
                CheckBox cb = (CheckBox)this.LstViewNGODisabilitySubTypes.Items[i].FindControl("ChkSelectDisabilitySubType");
                if (cb != null)
                {
                    oldValues += (cb.Checked ? "1" : "0").ToString() + ", ";
                }
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