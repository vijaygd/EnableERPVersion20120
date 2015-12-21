using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Web.Security;
using System.Security;
using System.Text;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net.Configuration;

using MySql.Data.MySqlClient;
namespace EnableIndia
{
    public class Global
    {
        //public Global()
        //{
        //    //
        //    // TODO: Add constructor logic here
        //    //
        //}

        public interface ISetPageUICulture
        {
            void SetPageUICulture();
        }

        public static void InitializePagingCookies()
        {
            HttpContext.Current.Response.Cookies["grid_page_number"].Value = "1";
            HttpContext.Current.Response.Cookies["grid_page_count"].Value = "1";
        }

        public static void SetGridPageCount(object totalRows)
        {
            if (HttpContext.Current.Request.Cookies["grid_page_count"] != null)
            {
                HttpContext.Current.Response.Cookies["grid_page_count"].Value = GetGridPageCount(Convert.ToDouble(totalRows));
            }
        }

        public static int GetGridPageSize()
        {
            return 50;
        }

        public static string GetGridPageCount(double totalRecords)
        {
            return Math.Ceiling(totalRecords / Global.GetGridPageSize()).ToString();
        }

        public static MySqlConnection GetConnectionString()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["EnableIndiaConnectionString"].ToString());
            return conn;
        }

        public static void SetUICulture(Page page)
        {
            page.UICulture = "en-GB";
            page.Culture = "en-GB";

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        }

        public static string GetDateFormat()
        {
            return "dd/MM/yyyy";
        }

        public static int GetPageSize()
        {
            return 50;
        }

        public static string GetGlobalErrorMessage()
        {
            return "Error occurred. Please contact the administrator.";
        }

        public static void SetDefaultButtonOfTheForm(HtmlForm form, Button submitButton)
        {
            form.DefaultButton = submitButton.UniqueID;
            form.DefaultFocus = submitButton.ClientID;
        }

        public void GetAgeGroups(HtmlSelect DdlAgeGroups)
        {
            //Populates age groups
            DdlAgeGroups.Items.Add(new ListItem("All", "-1"));
            for (int counter = 10; counter <= 24; counter++)
            {
                DdlAgeGroups.Items.Add(new ListItem(">" + counter.ToString(), counter.ToString()));
            }
        }

        public void GetSalaryRange(HtmlSelect DdlSalaryRange)
        {
            DdlSalaryRange.Items.Add(new ListItem("<2000", "<2000"));
            DdlSalaryRange.Items.Add(new ListItem("2000-3999", "3999"));
            DdlSalaryRange.Items.Add(new ListItem("4000-7999", "7999"));
            DdlSalaryRange.Items.Add(new ListItem("8000-20000", "20000"));
            DdlSalaryRange.Items.Add(new ListItem(">20000", ""));
        }

        public static void ClearAll(HtmlForm form)
        {
            //((HtmlGenericControl)form.Page.Master.FindControl("DivMessagesFromServer")).InnerText = "";
            string strScript = String.Empty;
            foreach (Control control in form.Controls[1].Controls)
            {
                switch (control.GetType().Name)
                {
                    case "TextBox":
                        ((TextBox)control).Text = "";
                        break;

                    case "DropDownList":
                        ((DropDownList)control).SelectedIndex = 0;
                        break;

                    case "HtmlSelect":
                        ((HtmlSelect)control).SelectedIndex = 0;
                        break;

                    case "CheckBox":
                        ((CheckBox)control).Checked = false;
                        break;

                    case "Button":
                        Button button = (Button)control;

                        if (button.Attributes["IsSubmit"] != null)
                        {
                            button.Focus();
                        }
                        break;

                    case "RadioButton":
                        RadioButton radioButton = (RadioButton)control;
                        if (radioButton.Attributes["Default"] != null)
                        {
                            radioButton.Checked = true;
                        }
                        else
                        {
                            radioButton.Checked = false;
                        }
                        break;

                    case "ListView":
                        ListView lstView = (ListView)control;
                        foreach (ListViewDataItem item in lstView.Items)
                        {
                            foreach (Control ctrl in item.Controls)
                            {
                                if (ctrl.GetType().Name.Equals("CheckBox"))
                                {
                                    ((CheckBox)ctrl).Checked = false;
                                }
                            }
                        }
                        break;
                }
            }
        }

        public static HtmlGenericControl ShowMessage(HtmlGenericControl SpnMessage, string message, bool isSuccess)
        {
            SpnMessage.InnerText = message;
            if (isSuccess.Equals(true))
            {
                SpnMessage.Attributes.Add("class", "success");
            }
            else
            {
                SpnMessage.Attributes.Add("class", "error");
            }

            return SpnMessage;
        }

        public static void AuthenticateUser()
        {
            //if(HttpContext.Current.Session["LoggedIn"] == null)
            //{
            //    HttpContext.Current.Response.Redirect("~/Login.aspx", true);
            //}
            HttpContext.Current.Session["CandidateCalling"] = null;
            HttpContext.Current.Session["CandidateCallingHeader"] = null;
            try
            {
                HttpContext.Current.Response.Cookies["candidate_calling"].Expires = DateTime.Now.AddDays(-1);
            }
            catch
            {
            }
        }

        public static void FillDropDown(object DropDown, MySqlDataReader drReader, string dataTextField, string dataValueField)
        {
            switch (((Control)DropDown).GetType().Name)
            {
                case "HtmlSelect":
                    ((HtmlSelect)DropDown).DataSource = drReader;
                    ((HtmlSelect)DropDown).DataTextField = dataTextField;
                    ((HtmlSelect)DropDown).DataValueField = dataValueField;
                    ((HtmlSelect)DropDown).DataBind();

                    if (((HtmlSelect)DropDown).Items.Count > 0)
                    {
                        ((HtmlSelect)DropDown).Items.Insert(0, new ListItem("Select", "-2"));
                    }
                    else
                    {
                        ((HtmlSelect)DropDown).Items.Add(new ListItem("Not Available", "-2"));
                    }

                    drReader.Close();
                    drReader.Dispose();

                    break;

                default:
                    ((DropDownList)DropDown).DataSource = drReader;
                    ((DropDownList)DropDown).DataTextField = dataTextField;
                    ((DropDownList)DropDown).DataValueField = dataValueField;
                    ((DropDownList)DropDown).DataBind();

                    if (((DropDownList)DropDown).Items.Count > 0)
                    {
                        ((DropDownList)DropDown).Items.Insert(0, new ListItem("Select", "-2"));
                    }
                    else
                    {
                        ((DropDownList)DropDown).Items.Add(new ListItem("Not Available", "-2"));
                    }

                    drReader.Close();
                    drReader.Dispose();

                    break;
            }
        }

        public static void ShowMessagesInDiv(Page page, string message)
        {
            //((HtmlGenericControl)page.Master.FindControl("DivMessagesFromServer")).InnerText = message;
            page.ClientScript.RegisterStartupScript(page.GetType(), "__message", "alert(\"" + message + "\");", true);
        }

        public static double EncryptID(int PlainID)
        {
            return PlainID * 157367.87;
        }

        public static int DecryptID(double EncryptedID)
        {
            return Convert.ToInt32(EncryptedID / 157367.87);
        }

        public static string EncryptQueryString(string querystring)
        {
            if (string.IsNullOrEmpty(querystring)) return "";
            byte[] initVectorBytes = Encoding.ASCII.GetBytes("@1B2c3D4e5F6g7H8");
            byte[] saltValueBytes = Encoding.ASCII.GetBytes("s@1tValue");

            // Convert our plaintext into a byte array.
            // Let us assume that plaintext contains UTF8-encoded characters.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(querystring);

            // First, we must create a password, from which the key will be derived.
            // This password will be generated from the specified passphrase and 
            // salt value. The password will be created using the specified hash 
            // algorithm. Password creation can be done in several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes("!5623a#de", saltValueBytes, "SHA1", 2);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(256 / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate encryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream();

            // Define cryptographic stream (always use Write mode for encryption).
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         encryptor,
                                                         CryptoStreamMode.Write);
            // Start encrypting.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            // Finish encrypting.
            cryptoStream.FlushFinalBlock();

            // Convert our encrypted data from a memory stream into a byte array.
            byte[] cipherTextBytes = memoryStream.ToArray();

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert encrypted data into a base64-encoded string.
            string cipherText = Convert.ToBase64String(cipherTextBytes);

            // Return encrypted string.
            return cipherText;


        }

        public static string DecryptQueryString(string encryptedQueryString)
        {
            if (string.IsNullOrEmpty(encryptedQueryString)) return "";
            byte[] initVectorBytes = Encoding.ASCII.GetBytes("@1B2c3D4e5F6g7H8");
            byte[] saltValueBytes = Encoding.ASCII.GetBytes("s@1tValue");

            // Convert our ciphertext into a byte array.
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedQueryString.Replace(" ", "+"));

            // First, we must create a password, from which the key will be 
            // derived. This password will be generated from the specified 
            // passphrase and salt value. The password will be created using
            // the specified hash algorithm. Password creation can be done in
            // several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes("!5623a#de", saltValueBytes, "SHA1", 2);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(256 / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate decryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                             keyBytes,
                                                             initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            // Define cryptographic stream (always use Read mode for encryption).
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                          decryptor,
                                                          CryptoStreamMode.Read);

            // Since at this point we don't know what the size of decrypted data
            // will be, allocate the buffer long enough to hold ciphertext;
            // plaintext is never longer than ciphertext.
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            // Start decrypting.
            int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                       0,
                                                       plainTextBytes.Length);

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert decrypted data into a string. 
            // Let us assume that the original plaintext string was UTF8-encoded.
            string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                       0,
                                                       decryptedByteCount);

            // Return decrypted string.   
            return plainText;

        }

        public static void SendEmail(string sender, string receiver, string subject, string message)
        {
            MailMessage mail = new MailMessage(sender, receiver);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = message;

            Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
            SmtpClient emailClient = new SmtpClient();
            emailClient.Host = settings.Smtp.Network.Host;
            emailClient.Send(mail);
        }

        public static void RedirectAfterSubmit(string message, string focusControlID)
        {
            string separator = "?";
            string rawURL = HttpContext.Current.Request.RawUrl;
            if (rawURL.Contains("msg"))
            {
                rawURL = rawURL.Substring(0, rawURL.IndexOf("msg") - 1);
            }
            if (rawURL.Contains("?"))
            {
                separator = "&";
            }
            HttpContext.Current.Response.Redirect(rawURL + separator + "msg=" + Global.EncryptQueryString(message) + "&foc=" + Global.EncryptQueryString(focusControlID));
        }

        public static void ShowMessageInAlert(HtmlForm form)
        {
            if (HttpContext.Current.Request.QueryString["msg"] != null)
            {
                string message = DecryptQueryString(HttpContext.Current.Request.QueryString["msg"].ToString());
                //string focusControlID = DecryptQueryString(HttpContext.Current.Request.QueryString["foc"].ToString());
                form.Page.ClientScript.RegisterStartupScript(form.Page.GetType(), "__script", "alert(\"" + message + "\");", true);

                //try
                //{
                //    ((Button)form.Controls[1].FindControl(focusControlID)).Focus();
                //}
                //catch
                //{
                //}
            }
        }
    }
}