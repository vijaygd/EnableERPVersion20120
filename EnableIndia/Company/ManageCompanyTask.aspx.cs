using System;
using System.Linq;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Company
{
    public partial class ManageCompanyTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["role_id"] == null || Session["username"] == null || Session["password"] == null)
            //{
            //    webMessageBox wb = new webMessageBox();
            //    wb.Show("You are not authorized to login");
            //    return;
            //}

            if (!Page.IsPostBack)
            {
                CompanyFlagsBAL flag = new CompanyFlagsBAL();
                MySqlDataReader drCompanyFlags = flag.GetCompanyFlags(true);
                Global.FillDropDown(DdlFlags, drCompanyFlags, "flag_name", "flag_id");
                DdlFlags.Items[0].Text = "All";
                DdlFlags.Items[0].Value = "-1";

                EnableIndia.App_Code.BAL.EmployeeBAL emp = new EnableIndia.App_Code.BAL.EmployeeBAL();
                MySqlDataReader drEmployee = emp.GetEmployeeListReader();
                Global.FillDropDown(DdlEmployee, drEmployee, "employee_name", "employee_id");
                DdlEmployee.Items[0].Text = "All";
                DdlEmployee.Items[0].Value = "-1";
            }
            Global.SetDefaultButtonOfTheForm(this.Form, BtnSearchOpenCompanyTasks);
            Global.SetUICulture(this.Page);
            //if (Session["role_id"] != null)
            //{
            //    if (Session["role_id"].ToString() == "1")
            //    {
            //        disableControls(Page);
            //    }
            //}

        }


        protected void BtnSearchOpenCompanyTasks_click(object sender, EventArgs e)
        {
            CompaniesBAL serchCompany = new CompaniesBAL();

            serchCompany.SelectedDate = DdlDates.Value;
            try
            {
                serchCompany.DateFrom = Convert.ToDateTime(TxtDateFrom.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                serchCompany.DateFrom = "1900/01/01";
            }
            try
            {
                serchCompany.DateTo = Convert.ToDateTime(TxtDateTo.Text.Trim()).ToString("yyyy/MM/dd");
            }
            catch
            {
                serchCompany.DateTo = "5000/01/01";
            }
            //serchCompany.SelectedParameter = DdlParameters.Value;

            //if(DdlParameters.Value == "flag")
            //{
            //    serchCompany.SelectedParameterValue = Convert.ToInt32(DdlFlags.Value);
            //}
            //if(DdlParameters.Value == "managed_by")
            //{
            //    serchCompany.SelectedParameterValue = Convert.ToInt32(DdlEmployee.Value);
            //}
            serchCompany.CompanyFlagID = Convert.ToInt32(DdlFlags.Value);
            serchCompany.EmployeeID = Convert.ToInt32(DdlEmployee.Value);

            serchCompany.SearchFor = TxtSearchFor.Text.Trim();
            serchCompany.SearchIn = DdlSearchIn.Value;

            LstViewOpenCompanyTasks.DataSource = serchCompany.SearchOpenCompanyTasks(serchCompany);
            LstViewOpenCompanyTasks.DataBind();
            LstViewOpenCompanyTasks.Visible = true;
        }

        protected void LnkOpenCompanyTasks_click(object sender, EventArgs e)
        {
            BtnSearchOpenCompanyTasks_click(BtnSearchOpenCompanyTasks, new EventArgs());
        }
        //public void disableControls(Control parent)
        //{

        //    var textBoxes = this.Controls.FindAll().OfType<TextBox>();
        //    foreach (var t in textBoxes)
        //    {
        //        t.Enabled = false;
        //    }
        //    var dropDowns = this.Controls.FindAll().OfType<DropDownList>();
        //    foreach (var d in dropDowns)
        //    {
        //        d.Enabled = false;
        //    }
        //    var selects = this.Controls.FindAll().OfType<HtmlSelect>();
        //    foreach (var s in selects)
        //    {
        //        s.Disabled = true;
        //    }
        //    var buttons = this.Controls.FindAll().OfType<Button>();
        //    foreach (var b in buttons)
        //    {
        //        b.Enabled = false;
        //    }
        //}

    }
}