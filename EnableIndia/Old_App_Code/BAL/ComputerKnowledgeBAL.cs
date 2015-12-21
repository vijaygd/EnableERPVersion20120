using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

/// <summary>
/// Summary description for ComputerKnowledgeBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class ComputerKnowledgeBAL
    {
        public ComputerKnowledgeBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetComputerKnowledge()
        {
            ComputerKnowledgeDAL get = new ComputerKnowledgeDAL();
            return get.GetComputerKnowledge();
        }
    }
}