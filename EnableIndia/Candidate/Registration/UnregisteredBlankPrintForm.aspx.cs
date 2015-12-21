using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Candidate.Registration
{

    public partial class UnregisteredBlankPrintForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["SelectedCandidates"] != null)
                {
                    StiReport report = new StiReport();

                    if (!Session["SelectedCandidates"].ToString().Equals(""))
                    {
                        CandidatesBAL cand = new CandidatesBAL();
                        report.RegData("DsRegistrationID", cand.GetRegistrationIDForFormPrinting(Session["SelectedCandidates"].ToString()));
                    }
                    else
                    {
                        DataTable dtBlankForEIForm = new DataTable();
                        dtBlankForEIForm.Columns.Add("registration_id");
                        DataRow dr = dtBlankForEIForm.NewRow();
                        dr["registration_id"] = "";
                        dtBlankForEIForm.Rows.Add(dr);
                        report.RegData("DsRegistrationID", dtBlankForEIForm);

                    }
                    EnableIndia.App_Code.BAL.DisabilityTypesBAL disab = new EnableIndia.App_Code.BAL.DisabilityTypesBAL();
                    report.RegData("DsDisabilityTypes", disab.GetDisabilityTypesTable());

                    ComputerKnowledgeBAL computer = new ComputerKnowledgeBAL();
                    report.RegData("DsComputerKnowledge", computer.GetComputerKnowledge());

                    DataTable dtBlank = new DataTable();
                    dtBlank.Columns.Add("column");
                    report.RegData("DsBlank", dtBlank);


                    report.Load(Server.MapPath("~/Reports/CandidateRegistration.mrt"));
                    StiWebViewer1.Report = report;
                    Session["SelectedCandidates"] = null;
                }
            }
        }
    }
}