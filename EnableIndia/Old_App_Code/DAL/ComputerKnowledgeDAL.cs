using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
namespace EnableIndia.App_Code.DAL
{

    /// <summary>
    /// Summary description for ComputerKnowledgeDAL
    /// </summary>
    public class ComputerKnowledgeDAL
    {
        public ComputerKnowledgeDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetComputerKnowledge()
        {
            string query = "select * from computer_knowledge order by computer_knowledge_type";
            DBAccess dba = new DBAccess();
            return (DataTable)dba.ExecuteQuery(query, null, "DataTable");
        }
    }
}