using System;
using System.Linq;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Company
{

    public partial class AddViewCompanyHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //onchange="javascript:FilterCityStates(this.value,'ParentCompanyID','DdlCompanyCode','DdlHiddenCompanyCode');$('#ctl00_ContentPlaceHolder2_DdlCompanyCode').change();"
            //populate company code  in hidden company dropdown
            if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("You are not authorized to login");
                return;
            }
            CompaniesBAL company = new CompaniesBAL();
                MySqlDataReader drCompany = company.GetCompanies("-1");
                while (drCompany.Read())
                {
                    ListItem li = new ListItem(drCompany["company_code"].ToString(), drCompany["company_id"].ToString());
                    li.Attributes.Add("ParentCompanyID", drCompany["parent_company_id"].ToString());
                    DdlHiddenCompanyCode.Items.Add(li);
                }

                drCompany.Close();
                drCompany.Dispose();

                DdlHiddenCompanyCode.Items.Insert(0, new ListItem("Select", "-2"));
                DdlHiddenCompanyCode.Items.Add(new ListItem("Not Available", "-3"));

                Global.SetDefaultButtonOfTheForm(this.Form, BtnSubmit);
                Global.AuthenticateUser();
                Global.SetUICulture(this.Page);

            //Global.SetDefaultButtonOfTheForm(this.Form, BtnAddNewCompanyHistory);
            if (!Page.IsPostBack)
            {

                ParentCompaniesBAL parent = new ParentCompaniesBAL();
                MySqlDataReader drParent = parent.GetParentCompanies();
                Global.FillDropDown(DdlParentCompany, drParent, "company_name", "company_id");
                // GetCompanyHistory();
            }

             // GetCompanyHistory();
            if (Session["role_id"] != null)
            {
                if (Session["role_id"].ToString() == "1")
                {
                    disableControls(Page);
                }
            }

 
        }
        protected void LstViewHistoryAllCompany_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType.Equals(ListViewItemType.DataItem))
            {
                LinkButton LnkBtnHistoryDate = (LinkButton)e.Item.FindControl("LnkBtnHistoryDate");
                if (LnkBtnHistoryDate.Attributes["Status"].ToString().Equals("Closed"))
                {
                    LnkBtnHistoryDate.Visible = false;
                }
            }
        }
        protected void BtnSubmit_click(object sender, EventArgs e)
        {
            //if (ViewState["CompanyCode"] != null)
            //{
            //    this.DdlParentCompany.SelectedIndex = Convert.ToInt32(ViewState["CompanyCode"].ToString());
            //    this.DdlHiddenCompanyCode.SelectedIndex = this.DdlParentCompany.SelectedIndex;
            //}
            GetCompanyHistory();
            SpnHiddenCompanyID.InnerText = TxtHiddenCompanyID.Text;
            if (SpnHiddenCompanyID.InnerText == TxtHiddenCompanyID.Text)
            {
                BtnAddNewCompanyHistory.Visible = true;
            }
            ViewState["CompanyCode"] = this.DdlHiddenCompanyCode.Value;
        }

        private void GetCompanyHistory()
        {
            if (ViewState["CompanyCode"] != null)
            {
                int i = this.DdlHiddenCompanyCode.Items.IndexOf( this.DdlHiddenCompanyCode.Items.FindByValue(ViewState["CompanyCode"].ToString()));
                this.DdlHiddenCompanyCode.SelectedIndex = i;
            }

            CompaniesBAL comp = new CompaniesBAL();
            //if(Request.QueryString["comp"] == null)
            //{
            //    LstViewHistoryAllCompany.DataSource = comp.GetCompanyHistory(-1);
            //    LstViewHistoryAllCompany.DataBind();
            //}
            //else
            //{
            //int companyID = Global.DecryptID(Convert.ToDouble(Request.QueryString["comp"]));
            int companyID = Convert.ToInt32(DdlHiddenCompanyCode.Value);
            LstViewHistoryAllCompany.DataSource = comp.GetCompanyHistory(companyID);
            LstViewHistoryAllCompany.DataBind();
            //#
            //if(LstViewHistoryAllCompany.Items.Count.Equals(0))
            //{
            //    BtnAddNewCompanyHistory.Visible = false;
            //}
            //else
            //{
            //    BtnAddNewCompanyHistory.Visible = true;
            //}
        }

        protected void BtnAddNewCompanyHistory_click(object sender, EventArgs e)
        {
            //BtnSubmit_click(BtnSubmit, new EventArgs());
            GetCompanyHistory();
            BtnAddNewCompanyHistory.Focus();
        }
        protected void LnkBtnHistoryDate_Click(object sender, EventArgs e)
        {
            GetCompanyHistory();
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