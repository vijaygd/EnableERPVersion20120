using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;

namespace EnableIndia.Candidate.ProfileHistory
{

    public partial class CandidatePhoneAddressHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["cand"] != null)
                {
                    string candidateID = String.Empty;
                    try
                    {
                        candidateID = Global.DecryptID(Convert.ToDouble(Request.QueryString["cand"])).ToString();
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "__Error", "self.close();", true);
                        return;
                    }

                    CandidatePhoneAddressHistoryBAL history = new CandidatePhoneAddressHistoryBAL();
                    if (Request.QueryString["hist"].Equals("ph"))
                    {
                        LstViewPhoneHistory.DataSource = history.GetCandidatePhoneHistory(candidateID);
                        LstViewPhoneHistory.DataBind();
                        LstViewPhoneHistory.Visible = true;
                        this.Title = "Phone history";
                    }
                    else
                    {
                        LstViewAddressHistory.DataSource = history.GetCandidateAddressHistory(candidateID);
                        LstViewAddressHistory.DataBind();
                        LstViewAddressHistory.Visible = true;
                        this.Title = "Address history";
                    }
                }
            }
        }
    }
}