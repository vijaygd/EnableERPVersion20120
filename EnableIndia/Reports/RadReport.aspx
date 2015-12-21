<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadReport.aspx.cs" Inherits="EnableIndia.Reports.RadReport" ClientIDMode="AutoID" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Assembly="Telerik.ReportViewer.WebForms" Namespace="Telerik.ReportViewer.WebForms" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enable India Report</title>
    <style type="text/css">
       html#html, body#body, form#form1, div#content
       {
         padding:0px;
         margin:0px auto;
         right:0px;
         top:0px;
         left:0px;
         position:absolute;
         font-family: Consolas, arial, 'lucida console';
         font-size:10px;
         color:#00008B;
         background-color:transparent;
         height:100%;
         width: 100%;
         overflow:auto;
       }
       .gMargins
       {	
			border: 0px solid black;
			padding: 0px;
			margin: 0px;
			height: 100%;
		}
		.buttonRounded
        {
         -moz-border-radius: 8px;
         -webkit-border-radius: 8px;
         border-radius: 8px; 
         text-decoration : none;
         position: relative;
         cursor: pointer;
         font-weight: bold;
         color: Blue;
         background-color:#7f8dbe;
         border:1 solid #000080;
         vertical-align:middle;
         top: 0px;
         left: 0px;
        }

        .buttonRounded:hover {
            background-color: #0978df; 
            color:White;
            font-weight:bolder;
         }
         html#html, body#body, form#form1, div#content, center#center
         { 
              border: 0px solid black;
              padding: 0px;
              margin: 0px;
              height : 100%;
         }
    </style>
      <script language="javascript" type="text/javascript">
          function reCenter() {
              var wide = 0;
              var high = 0;
              var x = 0;
              var y = 0;
              wide = window.screen.width;
              high = window.screen.height;
              var maxh = 680;  // your max height here; enter 0 if not used
              var maxw = 1024;  // your max width here; enter 0 if not used

              if (high > maxh) {
                  y = Math.round((high - maxh) / 2);
              }
              if (wide > maxw) {
                  x = Math.round((wide - maxw) / 2);
              }
              window.moveTo(x, y);   // Top is kept as 0 only for always getting to the top...

          }

             function GetRadWindow()
                  {      
                     var oWindow = null;
                     if (window.radWindow)
                     {
                         oWindow = window.RadWindow;
                     } 
                     else 
                        if (window.frameElement.radWindow)
                        {
                            oWindow = window.frameElement.radWindow;
                        }
                     return oWindow;;
                  }
                  function Close()
                  {
                     GetRadWindow().Close();
                  }
    </script>
</head>
<body>
    <center>
    <form id="frmRadReport" runat="server" clientidmode="AutoID">
      <div id="content">
    <table width="100%" cellpadding="0" cellspacing="0">
       <tr>
          <td valign="middle" align="left" style="border-bottom: 1px solid blue; border-top: 1px solid blue; width:50%;">
              <asp:Label CssClass="labelStyle" runat="server" ID="lbHeader" Font-Bold="true" ClientIDMode="AutoID" Font-Size="14"></asp:Label>
          </td>
          <td valign="middle" align="right" style="border-bottom: 1px solid blue; border-top: 1px solid blue; width:50%;">
              <asp:Button runat="server" ID="btnClose" OnClick="btnCloseClicked" Text="C l o s e" Font-Bold="true" ClientIDMode="AutoID" Font-Size="8.5" Font-Names="Consolas" CssClass="buttonRounded" />
          </td>
       </tr>
    </table>
    <table style="height:600px; width:1024px;">
       <tr>
          <td valign="top" align="center">
              <telerik:ReportViewer runat="server" ID="radReport"  Width="99%" Height="100%" ClientIDMode="AutoID" style="background-color:transparent;"     >
              </telerik:ReportViewer>
          </td>
       </tr>
    </table>
       <table  width="100%"  cellpadding="0" cellspacing="0">
         <tr>
           <td valign="middle" align="center" style="width:50%;">
              <asp:Label CssClass="labelStyle" runat="server" ID="lbNorecT" Text="Num Records: " Font-Bold="true"></asp:Label>
              <asp:Label CssClass="labelStyle" runat="server" ID="lbNoRec" ForeColor="#d32232"></asp:Label>
           </td>
           <td valign="middle" align="center" style="width:50%;">
              <asp:Label CssClass="labelStyle" runat="server" ID="lbError" ClientIDMode="AutoID"></asp:Label>
           </td>
         </tr>
       </table>
      </div>
    </form>
    </center>
</body>
</html>
