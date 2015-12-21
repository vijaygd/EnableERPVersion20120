using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace EnableIndia
{
    public partial class ITextPopup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["page"] != null)
                {
                    XmlDocument popupXmlDoc = new XmlDocument();
                    popupXmlDoc.Load(Server.MapPath("~/Popup_xml/IText.xml"));
                    XmlNodeList nodeList = popupXmlDoc.GetElementsByTagName(Request.QueryString["page"].ToString());
                    foreach (XmlNode node in nodeList.Item(0))
                    {
                        SpnMessage.InnerHtml += node.InnerText + "<br/>";
                    }
                }
            }
        }
    }
}