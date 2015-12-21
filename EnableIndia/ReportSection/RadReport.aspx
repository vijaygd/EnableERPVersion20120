<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadReport.aspx.cs" Inherits="EnableIndia.ReportSection.RadReport" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Assembly="Telerik.ReportViewer.WebForms" Namespace="Telerik.ReportViewer.WebForms" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MetAcEx Report</title>
    <style type="text/css">
       html, body
       {
         padding:0px;
         margin:0px auto;
         right:0px;
         top:0px;
         left:0px;
         height:680px;
         position:fixed;
         font-family: Consolas, arial, 'lucida console';
         font-size:10px;
         color:#00008B;
         background-color:transparent;
       }
       .gMargins
       {	
			border: 0px solid black;
			padding: 0px;
			margin: 0px;
			height: 100%;
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
    <form id="frmRadReport" runat="server">
     <div id="gMargins">
     <center>
      <telerik:ReportViewer runat="server" ID="radReport"  Width="980" Height="580" style="background-color:transparent;"  >
      </telerik:ReportViewer>
      </center>
      </div>
      <div>
       <table  width="1008"  cellpadding="0" cellspacing="0">
         <tr>
           <td valign="middle" align="center" colspan="2">
              <asp:Button runat="server" ID="btnClose" OnClick="btnCloseClicked" Text="C l o s e" Font-Bold="true" Font-Size="8.5" Font-Names="Consolas" />
           </td>
         </tr>
         <tr>
           <td valign="middle" align="left" style="width:50%;">
              <asp:Label CssClass="labelStyle" runat="server" ID="lbNorecT" Text="Num Records: " Font-Bold="true"></asp:Label>
              <asp:Label CssClass="labelStyle" runat="server" ID="lbNoRec" ForeColor="#d32232"></asp:Label>
           </td>
           <td valign="middle" align="right" style="width:50%;">
              <asp:Label CssClass="labelStyle" runat="server" ID="lbError" ClientIDMode="AutoID"></asp:Label>
           </td>
         </tr>
       </table>
      </div>
          <div id="divforScript" class="load">
         <table width="500px" style="height:100px; background-color:White;">
         <tr>
            <td valign="middle" align="center" style="width:500px;">
                <asp:Image runat="server" ID="imbPb" AlternateText="...Wait..." ImageUrl="~/Image/ajax-loader.gif" Width="30px" Height="30px" />
                              </td>
                             </tr>
                            <tr>
                               <td valign="middle" align="center" style="width:500px;">
                                 <asp:Label CssClass="labelStyle" runat="server" ID="lbWaitState"  Font-Bold="true" Font-Size="10" ForeColor="#D32232">
                                 <p>-: Please Wait - Report Generation under progress : -</p></asp:Label>
                               </td>
                           </tr>
                         </table>

    </div>

    </form>
    </center>
</body>
</html>
