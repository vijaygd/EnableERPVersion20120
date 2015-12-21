<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptJobPlaceCharts.aspx.cs" Inherits="EiAdmin.rptJobPlaceCharts" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=9" />
<meta http-equiv="Page-Enter" content="Alpha(opacity=100)"/>
    <title>Status through graph</title>
        <style type="text/css">
       html, body
       {
         padding:0px;
         margin:0px;
         right:0px;
         top:0px;
         left:0px;
         height:720px;
         position:absolute;
         font-family: Consolas, Consolas, 'lucida console';
         font-size:12pt;
         color:#00008B;
         width:100%;
         margin-left: auto;
         margin-right : auto;
         max-width: 100%;
         min-height: 720px;

       }
       .divClass
       {
           width: 1024px;
           height:700px;
           position:absolute;
           margin-left: auto;
           margin-right: auto;
       }
       .smallBr{
            font-size : 10px;
            line-height: 2; 
       }
       </style>
       <script language="javascript" type="text/javascript">
           function printChart(elementId)
           {
               var printContent = document.getElementById(elementId);
               var windowUrl = 'about:blank';
               var uniqueName = new Date();
               var windowName = 'Print' + uniqueName.getTime();
               var printWindow = window.open(windowUrl, windowName, 'left=50000,top=50000,width=0,height=0');

               printWindow.document.write(printContent.innerHTML);
               printWindow.document.close();
               printWindow.focus();
               printWindow.print();
               printWindow.close();
           }
           function printGraph(elementId) {
               var html = '<html>\n<head>\n';
               if (document.getElementsByTagName != null) {
                   var headTags = document.getElementsByTagName("head");
                   if (headTags.length > 0)
                       html += headTags[0].innerhtml;
               }
               html += '\n</head>\n<body>\n';
               var printReadyElem = document.getElementById(elementId);
               if (printReadyElem != null) {
                   html += printReadyElem.innerhtml;
               }
               else {
                   alert("Could not find the printPart div");
                   return;
               }
               html += '\n</body>\n</html>';
               var printWin = window.open("", "printSpecial");
               printWin.document.open();
               printWin.document.write(html);
               printWin.document.close();
               printWin.print();
           }
       </script>
</head>
<body>
    <center>
    <form id="formChart" runat="server">
    <div>
    <table width="1024px" cellpadding="2" cellspacing="0" style="border-bottom-color:Blue; border-bottom-style:solid; border-top-color:Blue; border-top-style:solid; border-width:2;">
        <tr>
           <td colspan="2" valign="middle" align="center">
              <asp:Label CssClass="labelStyle" runat="server" ID="Label3" Font-Bold="true" Font-Size="14pt" Text="Enable India"></asp:Label>
           </td>

           <td colspan="2" valign="middle" align="center">
              <asp:Label CssClass="labelStyle" runat="server" ID="lbTitle" Font-Bold="true" Font-Size="14pt"></asp:Label>
           </td>
        </tr>
        <tr>
           <td valign="middle" align="right" style="width:256px;" >
              <asp:Label CssClass="labelStyle" runat="server" ID="lbStartDateT" Text="Start Date: " Font-Bold="true"></asp:Label>
           </td>
           <td valign="middle" align="left" style="width:256px;" >
              <asp:Label CssClass="labelStyle" runat="server" ID="lbStartDate" ></asp:Label>
           </td>
           <td valign="middle" align="right" style="width:256px;" >
              <asp:Label CssClass="labelStyle" runat="server" ID="Label1" Text="End Date: " Font-Bold="true"></asp:Label>
           </td>
           <td valign="middle" align="left" style="width:256px;" >
              <asp:Label CssClass="labelStyle" runat="server" ID="lbEndDate"></asp:Label>
           </td>
        </tr>
        <tr>
           <td valign="middle" align="right" style="width:256px;" >
              <asp:Label CssClass="labelStyle" runat="server" ID="Label2" Text="Total Days: " Font-Bold="true"></asp:Label>
           </td>
           <td valign="middle" align="left" style="width:256px;" >
              <asp:Label CssClass="labelStyle" runat="server" ID="lbTotDays" ></asp:Label>
           </td>
           <td valign="middle" colspan="2" align="right" style="width:512px;" >
              <asp:Label CssClass="labelStyle" runat="server" ID="Label4" Text="No Intervals: " Font-Bold="true"></asp:Label>
              <asp:Label CssClass="labelStyle" runat="server" ID="lbInterval"></asp:Label>&nbsp;
              <asp:Label CssClass="labelStyle" runat="server" ID="Label5" Text="Interval Size: " Font-Bold="true"></asp:Label>
              <asp:Label CssClass="labelStyle" runat="server" ID="lbIntSize"></asp:Label>&nbsp;
              <asp:ImageButton runat="server" ID="imgPrint" AlternateText="Print" ImageAlign="AbsMiddle" ImageUrl="~/Image/PrintC.gif" Height="24px" Width="60px" OnClick="prtButton_Click" />
           </td>

        </tr>
        <tr>
           <td valign="middle" align="right" style="width:256px;" >
              <asp:Label CssClass="labelStyle" runat="server" ID="Label6" Text="Interval Period: " Font-Bold="true"></asp:Label>
              <asp:DropDownList runat="server" ID="ddIntPeriod" OnSelectedIndexChanged="ddIntervalChanged" AutoPostBack="true">
                 <asp:ListItem Text="Select"></asp:ListItem>
                 <asp:ListItem Text="Monthly" Value="M"></asp:ListItem>
                 <asp:ListItem Text="BiMonthly" Value="I"></asp:ListItem>
                 <asp:ListItem Text="Quarterly" Value="Q"></asp:ListItem>
                 <asp:ListItem Text="Half Yearly" Value="H"></asp:ListItem>
              </asp:DropDownList>
           </td>
           <td colspan="2" valign="middle" align="center" style="width:512px;" >
             <asp:Label CssClass="labelStyle" runat="server" ID="lbNoRecsT" Text="Number of Candidates: " Font-Bold="true"></asp:Label>
             <asp:Label CssClass="labelStyle" runat="server" ID="lbNoRecs"></asp:Label>
           </td>
           <td valign="middle" colspan="2" align="right" style="width:256px;" >
                <asp:ImageButton runat="server" ID="btnClose" ImageUrl="~/Image/Close.gif"  AlternateText="Close" ImageAlign="AbsMiddle" Height="24"  Width="60px" 
                 onclick="btnClose_Click" ToolTip="Close this screen"  />&nbsp;
                 <asp:Label CssClass="labelStyle" runat="server" ID="lbStatus" Width="160px"></asp:Label>
           </td>
        </tr>
    </table>
    </div>
    <br class="smallBr" />
    <div id="chartDiv" runat="server" style="height:520px; width:980px;border-bottom-color:Blue; border-bottom-style:solid; border-top-color:Blue; border-width:2;">
            <asp:Chart ID="ytdSalesT" runat="server"    Width="960px" Height="500px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
          <Series>
            <asp:Series Name="ytdSalesSeriesT" ChartType="Column" ChartArea="ytdChartAreaT">
          </asp:Series>
        </Series>
      <ChartAreas>
          <asp:ChartArea Name="ytdChartAreaT">
                    <area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" 
                     wallwidth="0" IsClustered="False"></area3dstyle> 
          </asp:ChartArea>
       </ChartAreas>
    </asp:Chart>

    </div>

    </form>
    </center>
</body>
</html>
