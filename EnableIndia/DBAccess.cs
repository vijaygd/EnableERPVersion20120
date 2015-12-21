using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for DBAccess
/// </summary>
/// 
namespace EnableIndia
{
    public class DBAccess
    {
        MySqlConnection conn;
        public DBAccess()
        {
            conn = Global.GetConnectionString();
        }

        public object ExecuteQuery(string query, List<Parameter> parameters, string ResultType)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandTimeout = 1200;
            MySqlParameter myParam = new MySqlParameter();
            myParam.Value = 0;

            if (parameters != null && parameters.Count > 0)
            {
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (Parameter parameter in parameters)
                {

                    if (parameter.Direction.Equals("Output"))
                    {
                        myParam.ParameterName = parameter.Name;
                        myParam.Direction = ParameterDirection.InputOutput;
                        cmd.Parameters.Add(myParam);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);
                    }

                }
            }
            else
            {
                cmd.CommandType = CommandType.Text;
            }
            try
            {
                if(conn.State > 0)
                {
                    conn.Close();
                }
                conn.Open();
                int rowsAffected = 0;
                try
                {
                    switch (ResultType)
                    {
                        case "Reader":
                            return cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        case "DataSet":
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                            da.Fill(ds);
                            return ds;

                        case "DataTable":
                            da = new MySqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                            da.Fill(dt);
                            return dt;

                        case "NonQuery":
                            try
                            {
                                cmd.ExecuteNonQuery();
                                rowsAffected = 1;
                            }
                            catch (Exception ex)
                            {
                                rowsAffected = 0;
                            }
                            finally
                            {
                                conn.Close();
                                cmd.Dispose();
                                conn.Dispose();
                            }

                            if (Convert.ToInt32(myParam.Value) > 0)
                            {
                                return Convert.ToInt32(myParam.Value);
                            }
                            else
                            {
                                return rowsAffected;
                            }

                        case "Scalar":
                            object scalarResult = new object();
                            scalarResult = cmd.ExecuteScalar();
                            conn.Close();
                            cmd.Dispose();
                            conn.Dispose();
                            return scalarResult;

                        default:
                            return null;
                    }
                }
                catch (System.Exception ex)
                {
                    webMessageBox wb = new webMessageBox();
                    wb.Show("Error: " + ex.Message);
                }
            }
            catch (System.Exception ex)
            {
                webMessageBox wb = new webMessageBox();
                wb.Show("Unable to connect: " + ex.Message);
            }
            return null;
        }

        public object ExecuteNonQueryWithTransaction(string query, List<Parameter> parameters, out string errorMessage)
        {

            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();

            MySqlParameter myParam = new MySqlParameter();

            MySqlCommand cmd = new MySqlCommand(query, conn, trans);

            if (parameters != null && parameters.Count > 0)
            {
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (Parameter parameter in parameters)
                {

                    if (parameter.Direction.Equals("Output"))
                    {
                        myParam.ParameterName = parameter.Name;
                        myParam.Direction = ParameterDirection.InputOutput;
                        myParam.Value = parameter.Value;
                        cmd.Parameters.Add(myParam);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);
                    }

                }
            }
            else
            {
                cmd.CommandType = CommandType.Text;
            }

            int rowsAffected = 0;
            errorMessage = "";
            try
            {
                rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    trans.Rollback();
                    errorMessage = "Please enter full values";
                }
                else
                {
                    rowsAffected = 1;
                    trans.Commit();
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                if (ex.Message.Contains("Duplicate entry"))
                    errorMessage = "Please use another login name.";
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            switch (myParam.DbType)
            {
                case DbType.String:
                    return myParam.Value.ToString();

                default:
                    if (Convert.ToInt32(myParam.Value) > 0)
                    {
                        return Convert.ToInt32(myParam.Value);
                    }
                    else
                    {
                        return rowsAffected;
                    }
            }
        }
    }

    public class Parameter
    {

        public Parameter()
        {
            this.Direction = "Input";
        }

        public string Name
        {
            get;
            set;
        }

        public object Value
        {
            get;
            set;
        }

        public string Direction
        {
            get;
            set;
        }
    }
}