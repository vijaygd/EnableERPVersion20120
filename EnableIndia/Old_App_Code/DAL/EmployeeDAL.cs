using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for EmployeeDAL
    /// </summary>
    public class EmployeeDAL
    {
        public EmployeeDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MySqlDataReader GetEmployeeListReader()
        {
            string query = "select";
            query += "	emp.employee_id,";
            query += "	concat_ws(' ',emp.employee_first_name,emp.employee_middle_name,emp.employee_last_name) as employee_name,";
            query += "	roles.role_name,";
            query += "	log.login_name,";
            query += "	convert(aes_decrypt(log.login_password,'adminei'),char)as login_password,";
            query += "	emp.email_address ";
            query += "from employees emp ";
            query += "join login_info `log` on emp.login_id=log.login_id ";
            query += "join roles on `log`.role_id=roles.role_id ";
            query += "where emp.mark_deleted=0 ";
            query += "order by employee_name";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public DataTable GetEmployeeList()
        {
            string query = "select";
            query += "	emp.employee_id,";
            query += "	concat_ws(' ',emp.employee_first_name,emp.employee_middle_name,emp.employee_last_name) as employee_name,";
            query += "	roles.role_name,";
            query += "	log.login_name,";
            query += "	convert(aes_decrypt(log.login_password,'adminei'),char)as login_password,";
            query += "	emp.email_address ";
            query += "from employees emp ";
            query += "join login_info `log` on emp.login_id=log.login_id ";
            query += "join roles on `log`.role_id=roles.role_id ";
            query += "where emp.mark_deleted=0 ";
            query += "order by employee_name";

            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }

        public MySqlDataReader GetEmployeeDetails(string employeeID)
        {
            string query = "call get_employee_assigned_open_task(" + employeeID + ")";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        public int AddEmployee(EnableIndia.App_Code.BAL.EmployeeBAL emp, out string errorMessage)
        {
            string query = "add_employee";

            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_employee_first_name",Value=emp.EmployeeFirstName},
            new Parameter{Name="para_employee_middle_name",Value=emp.EmployeeMiddleName},
            new Parameter{Name="para_employee_last_name",Value=emp.EmployeeLastName},
            new Parameter{Name="para_login_name",Value=emp.LoginName},
            new Parameter{Name="para_login_password",Value=emp.Password},
            new Parameter{Name="para_role_id",Value=emp.RoleID},
            new Parameter{Name="para_email_address",Value=emp.EmailAddress}
        };

            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteNonQueryWithTransaction(query, parameters, out errorMessage);
        }

        public int UpdateEmployee(EnableIndia.App_Code.BAL.EmployeeBAL emp, out string errorMessage)
        {
            string query = "update_employee";

            List<Parameter> parameters = new List<Parameter>
        {
            new Parameter{Name="para_employee_id",Value=emp.EmployeeID},
            new Parameter{Name="para_employee_first_name",Value=emp.EmployeeFirstName},
            new Parameter{Name="para_employee_middle_name",Value=emp.EmployeeMiddleName},
            new Parameter{Name="para_employee_last_name",Value=emp.EmployeeLastName},
            new Parameter{Name="para_login_name",Value=emp.LoginName},
            new Parameter{Name="para_login_password",Value=emp.Password},
            new Parameter{Name="para_role_id",Value=emp.RoleID},
            new Parameter{Name="para_email_address",Value=emp.EmailAddress}
        };

            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteNonQueryWithTransaction(query, parameters, out errorMessage);
        }

        public int DeleteEmployee(string employeeID)
        {
            string query = "update employees set mark_deleted=1 where employee_id=" + employeeID;
            DBAccess dba = new DBAccess();
            return (int)dba.ExecuteQuery(query, null, "NonQuery");
        }


        public int CheckEmployeeAssignedForTask(EnableIndia.App_Code.BAL.EmployeeBAL emp)
        {
            string query = "select count(assigned_to_employee_id) from candidate_history";
            query += " where assigned_to_employee_id =" + emp.EmployeeID + " and status='Open' ";

            DBAccess dba = new DBAccess();
            return Convert.ToInt32(dba.ExecuteQuery(query, null, "Scalar"));
        }

        public MySqlDataReader GetLoginDetail(string loginName)
        {
            string query = "SELECT lg_info.login_name,emp.email_address,lg_info.role_id,CONVERT(AES_DECRYPT(login_password,'adminei'),CHAR)AS emp_password ";
            query += " FROM employees emp JOIN login_info lg_info ON emp.login_id=lg_info.login_id ";
            query += " WHERE lg_info.login_name='" + loginName + "'";

            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }

        //public MySqlDataReader GetLoginDetail(string loginName,string password)
        //{

        //    string query = " SELECT lg_info.login_name,emp.email_address,lg_info.role_id,CONVERT(AES_DECRYPT(login_password,'adminei'),CHAR)AS emp_password ";
        //    query += " FROM employees emp JOIN login_info lg_info ON emp.login_id=lg_info.login_id ";
        //    query += " WHERE lg_info.login_name='" + loginName + "' ";
        //    query += " and login_password=AES_ENCRYPT('"+password +"','adminei')";
        //    DBAccess dba = new DBAccess();
        //    return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        //}
        public MySqlDataReader GetLoginDetail(string loginName, string password)
        {
            password = Global.EncryptQueryString(password);
            string query = " SELECT lg_info.login_name,emp.email_address,lg_info.role_id, login_password AS emp_password ";
            query += " FROM employees emp JOIN login_info lg_info ON emp.login_id=lg_info.login_id ";
            query += " WHERE lg_info.login_name='" + loginName + "' ";
            query += " and login_password= '" + password + "'  and emp.mark_deleted=0";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }
        public MySqlDataReader GetLoginDetailForPassword(string loginName)
        {
            string query = " SELECT lg_info.login_name,emp.email_address,lg_info.role_id, login_password AS emp_password ";
            query += " FROM employees emp JOIN login_info lg_info ON emp.login_id=lg_info.login_id ";
            query += " WHERE lg_info.login_name='" + loginName + "' ";
            DBAccess dba = new DBAccess();
            return (MySqlDataReader)dba.ExecuteQuery(query, null, "Reader");
        }
    }
}