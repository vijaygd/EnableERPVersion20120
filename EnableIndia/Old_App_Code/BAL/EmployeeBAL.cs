using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for EmployeeBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class EmployeeBAL
    {
        public EmployeeBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Employee Attributes
        public int EmployeeID
        {
            get;
            set;
        }

        public int RoleID
        {
            get;
            set;
        }

        public string EmployeeFirstName
        {
            get;
            set;
        }

        public string EmployeeMiddleName
        {
            get;
            set;
        }

        public string EmployeeLastName
        {
            get;
            set;
        }

        public string LoginName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string EmailAddress
        {
            get;
            set;
        }
        #endregion

        public MySqlDataReader GetEmployeeListReader()
        {
            EnableIndia.App_Code.DAL.EmployeeDAL get = new EnableIndia.App_Code.DAL.EmployeeDAL();
            return get.GetEmployeeListReader();
        }
        public DataTable GetEmployeeList()
        {
            EnableIndia.App_Code.DAL.EmployeeDAL get = new EnableIndia.App_Code.DAL.EmployeeDAL();
            return get.GetEmployeeList();
        }

        public MySqlDataReader GetEmployeeDetails(string employeeID)
        {
            EnableIndia.App_Code.DAL.EmployeeDAL get = new EnableIndia.App_Code.DAL.EmployeeDAL();
            return get.GetEmployeeDetails(employeeID);
        }

        public bool AddEmployee(EmployeeBAL emp, out string errorMessage)
        {
            EnableIndia.App_Code.DAL.EmployeeDAL add = new EnableIndia.App_Code.DAL.EmployeeDAL();
            int rowsAdded = add.AddEmployee(emp, out errorMessage);
            if (rowsAdded > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateEmployee(EmployeeBAL emp, out string errorMessage)
        {
            EnableIndia.App_Code.DAL.EmployeeDAL upd = new EnableIndia.App_Code.DAL.EmployeeDAL();
            int rowsUpdated = upd.UpdateEmployee(emp, out errorMessage);
            if (rowsUpdated > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteEmployee(string employeeID)
        {
            EnableIndia.App_Code.DAL.EmployeeDAL emp = new EnableIndia.App_Code.DAL.EmployeeDAL();
            int rowsDeleted = emp.DeleteEmployee(employeeID);
            if (rowsDeleted > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int CheckEmployeeAssignedForTask(EmployeeBAL emp)
        {
            EnableIndia.App_Code.DAL.EmployeeDAL employee = new EnableIndia.App_Code.DAL.EmployeeDAL();
            return employee.CheckEmployeeAssignedForTask(emp);
        }

        public MySqlDataReader GetLoginDetail(string loginName)
        {

            EnableIndia.App_Code.DAL.EmployeeDAL employee = new EnableIndia.App_Code.DAL.EmployeeDAL();
            return employee.GetLoginDetail(loginName);
        }

        public MySqlDataReader GetLoginDetail(string loginName, string password)
        {

            EnableIndia.App_Code.DAL.EmployeeDAL employee = new EnableIndia.App_Code.DAL.EmployeeDAL();
            return employee.GetLoginDetail(loginName, password);
        }
    }
}