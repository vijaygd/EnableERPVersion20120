<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="statusFullPage.aspx.cs" Inherits="EnableIndia.ReportSection.statusFullPage" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=9" />
<meta http-equiv="Page-Enter" content="Alpha(opacity=100)"/>
    <title>Status Full Page</title>
    <style type="text/css">
     html
       {

         padding:0px;
         margin:0px;
         right:0px;
         top:0px;
         left:0px;
         height:720px;
         position:absolute;
         font-family: Consolas, arial, 'lucida console';
         font-size:11px;
         color:#00008B;
         width:1024px;
         margin-left: auto;
         margin-right : auto;
         max-width: 1024px;
         min-height: 720px;
         }
        .right_align
        {}
    </style>
</head>
<body>
<center>
    <form id="formStatusFullPage" runat="server">
    <asp:ScriptManager runat="server" ID="scm1" EnablePageMethods="true" EnablePartialRendering="true">
     <Scripts>
    </Scripts>
    </asp:ScriptManager>
<div id="divDashBoard" style="position:absolute; width:1000px;  z-index: 300;">
   <center>

   <table cellpadding="2" cellspacing="0" style="width:1000px;">
     <tr style="height:30px;">
     <td  valign="middle" align="left" style="border-bottom-color:Blue; border-bottom-style:solid; border-top-color:Blue; border-top-style:solid; border-width:medium;" >
        <asp:Label CssClass="labelStyle" runat="server" ID="Status" Text="E n a b l e  I n d i a  S t a t u s" Font-Bold="true" Font-Size="12" ForeColor="Blue"></asp:Label>
     </td>
     <td valign="middle" align="center" style="border-bottom-color:Blue; border-bottom-style:solid; border-top-color:Blue; border-top-style:solid; border-width:medium;">
        <asp:Label CssClass="labelStyle" runat="server" ID="lbDate" Text="Base Date: " Width="120px"></asp:Label>
                  <BDP:BasicDatePicker runat="server" ID="dtBaseDate" 
                      DateFormat="dd/MM/yyyy" Columns="1"  
                      WeekendDayStyle-BackColor="#ADD8E6" TextBoxColumns="10" Font-Size="Small" 
                      onselectionchanged="dtEndDate_SelectionChanged" ClientIDMode="AutoID" DisplayType="TextBoxAndImage" AutoPostBack="false"></BDP:BasicDatePicker>
                 <BDP:IsDateValidator runat="server" ID="dtEndDateV" Display="Dynamic" YearSelectorEnabled="true" ShowNoneButton="false" ErrorMessage="Please Enter Valid Date" ControlToValidate="dtBaseDate" Width="120px"></BDP:IsDateValidator>&nbsp;
       <asp:ImageButton runat="server" ID="btnGet" OnClick="btnGetClick" ImageAlign="AbsMiddle" ImageUrl="~/Image/Get.gif" AlternateText="Get" Width="60px" />
     </td>
     <td valign="middle" align="right" style="border-bottom-color:Blue; border-bottom-style:solid; border-top-color:Blue; border-top-style:solid; border-width:medium;" >
        <asp:Label CssClass="labelStyle" runat="server" ID="lbStatusDateT" Text="Date: "  Font-Bold="true" Font-Size="12" ForeColor="Blue"></asp:Label>
        <asp:Label CssClass="labelStyle" runat="server" ID="lbStatusDate" Font-Bold="true" Font-Size="12" ForeColor="Blue"></asp:Label>
     </td>
     </tr>
     <tr>
     <td  style="width:330px; height:330px;">
        <asp:Chart ID="gotJobsChart" runat="server"  Width="330px" Height="330px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
          <Series>
            <asp:Series Name="gotJobSeries" ChartType="Column" ChartArea="gotJobChartArea">
          </asp:Series>
        </Series>
      <ChartAreas>
          <asp:ChartArea Name="gotJobChartArea">
                    <area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" 
                     wallwidth="0" IsClustered="False"></area3dstyle> 
          </asp:ChartArea>
       </ChartAreas>
    </asp:Chart>
     </td>
      <td style="width:330px; height:330px;">
        <asp:Chart ID="placements" runat="server"  Width="330px" Height="330px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
          <Series>
            <asp:Series Name="placementsSeries" ChartType="Column" ChartArea="placementChartArea">
          </asp:Series>
        </Series>
      <ChartAreas>
          <asp:ChartArea Name="placementChartArea">
                    <area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" 
                     wallwidth="0" IsClustered="False"></area3dstyle> 
          </asp:ChartArea>
       </ChartAreas>
    </asp:Chart>
      </td>
      <td style="width:330px; height:330px;">
        <asp:Chart ID="activeCandidates" runat="server"    Width="330px" Height="330px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
          <Series>
            <asp:Series Name="acSeries" ChartType="Column" ChartArea="acChartArea">
          </asp:Series>
        </Series>
      <ChartAreas>
          <asp:ChartArea Name="acChartArea">
                    <area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" 
                     wallwidth="0" IsClustered="False"></area3dstyle> 
          </asp:ChartArea>
       </ChartAreas>
    </asp:Chart>
      </td>
    </tr>
     <tr>
     <td  align="center" valign="middle" style="width:330px; height:26px;">
          <asp:Label CssClass="labelStyle" runat="server" ID="lbJobsObtained" Text="Jobs Obtained" Font-Bold="true" ForeColor="Blue"></asp:Label>&nbsp;
          <asp:Label CssClass="labelStyle" runat="server" ID="lbJobObtainedTot" Width="30px" ForeColor="Blue" CssClass="right_align"></asp:Label>&nbsp;
          <asp:ImageButton runat="server" ID="ibtJobObtained" ImageAlign="AbsMiddle" Height="16px" Width="16px" AlternateText="Jo" OnClick="prtbtnJobObtained_Click" ImageUrl="~/Image/Print.gif" />
     </td>
      <td align="center" valign="middle" style="width:330px; height:26px;">
          <asp:Label CssClass="labelStyle" runat="server" ID="lbPlacements" Text="Placements" Font-Bold="true" ForeColor="Blue"></asp:Label>&nbsp;
          <asp:Label CssClass="labelStyle" runat="server" ID="lbPlacementsTot" ForeColor="Blue" CssClass="right_align"></asp:Label>&nbsp;
          <asp:ImageButton runat="server" ID="ImageButton1" ImageAlign="AbsMiddle" Height="16px" Width="16px" AlternateText="Jo" OnClick="prtbtnPlacements_Click" ImageUrl="~/Image/Print.gif" />
      </td>
      <td align="center" valign="middle" style="width:330px; height:26px;">
          <asp:Label CssClass="labelStyle" runat="server" ID="lbActiveCandidates" Text="Active Candidates" Font-Bold="true" ForeColor="Blue"  ></asp:Label>&nbsp;
          <asp:Label CssClass="labelStyle" runat="server" ID="lbActiveCandidatesTot" Width="30px" ForeColor="Blue" CssClass="right_align"></asp:Label>
          <asp:ImageButton runat="server" ID="ImageButton2" ImageAlign="AbsMiddle" Height="16px" Width="16px" AlternateText="Jo" OnClick="prtbtnActiveCandidates_Click" ImageUrl="~/Image/Print.gif" />

      </td>
     </tr>
     <tr>
     <td  style="width:330px; height:330px;">
        <asp:Chart ID="traingProgramsStDate" runat="server"  Width="330px" Height="330px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
          <Series>
            <asp:Series Name="tpSeriesStDate" ChartType="Column" ChartArea="tpChartArea">
          </asp:Series>
        </Series>
      <ChartAreas>
          <asp:ChartArea Name="tpChartArea">
                    <area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" 
                     wallwidth="0" IsClustered="False"></area3dstyle> 
          </asp:ChartArea>
       </ChartAreas>
    </asp:Chart>
    </td>
     <td  style="width:330px; height:330px;">
        <asp:Chart ID="traingProgramsEdDate" runat="server"  Width="330px" Height="330px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
          <Series>
            <asp:Series Name="edSeries" ChartType="Column" ChartArea="edChartArea">
          </asp:Series>
        </Series>
      <ChartAreas>
          <asp:ChartArea Name="edChartArea">
                    <area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" 
                     wallwidth="0" IsClustered="False"></area3dstyle> 
          </asp:ChartArea>
       </ChartAreas>
    </asp:Chart>
    </td>
     <td  style="width:330px; height:330px;">
        <asp:Chart ID="employmentProjects" runat="server"  Width="330px" Height="330px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
          <Series>
            <asp:Series Name="epSeries" ChartType="Column" ChartArea="epChartArea">
          </asp:Series>
        </Series>
      <ChartAreas>
          <asp:ChartArea Name="epChartArea">
                    <area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" 
                     wallwidth="0" IsClustered="False"></area3dstyle> 
          </asp:ChartArea>
       </ChartAreas>
    </asp:Chart>
    </td>
    </tr>
     <tr>
     <td  align="center" valign="middle" style="width:330px; height:26px;">
          <asp:Label CssClass="labelStyle" runat="server" ID="lbTrainingProjStDate" Text="Training Projects St Date" Font-Bold="true" ForeColor="Blue"  ></asp:Label>&nbsp;
          <asp:Label CssClass="labelStyle" runat="server" ID="lbTrainProjStDateTot"  ForeColor="Blue" Width="30px" CssClass="right_align"></asp:Label>
          <asp:ImageButton runat="server" ID="ImageButton3" ImageAlign="AbsMiddle" Height="16px" Width="16px" AlternateText="Jo" OnClick="prtbtnTpStdate_Click" ImageUrl="~/Image/Print.gif" />

     </td>
      <td align="center" valign="middle" style="width:330px; height:26px;">
          <asp:Label CssClass="labelStyle" runat="server" ID="lbTrainingProjEdDate" Text="Training Projects End Date" Font-Bold="true" ForeColor="Blue" ></asp:Label>&nbsp;
          <asp:Label CssClass="labelStyle" runat="server"  ID="lbTrinProjEdDateTot" ForeColor="Blue" Width="30px" CssClass="right_align"></asp:Label>
          <asp:ImageButton runat="server" ID="ImageButton4" ImageAlign="AbsMiddle" Height="16px" Width="16px" AlternateText="Jo" OnClick="prtbtnTpEdDate_Click" ImageUrl="~/Image/Print.gif" />

      </td>
      <td align="center" valign="middle" style="width:330px; height:26px;">
          <asp:Label CssClass="labelStyle"  runat="server" ID="lbEmpProj" Text="Employment Projects" Font-Bold="true" ForeColor="Blue" ></asp:Label>&nbsp;
          <asp:Label CssClass="labelStyle"  runat="server" ID="lbEmpProjTot" ForeColor="Blue" Width="30px" CssClass="right_align" ></asp:Label>
          <asp:ImageButton runat="server" ID="ImageButton5" ImageAlign="AbsMiddle" Height="16px" Width="16px" AlternateText="Jo" OnClick="prtbtnEmpProj_Click" ImageUrl="~/Image/Print.gif" />

      </td>
     </tr>
   <tr>
     <td  style="width:330px; height:330px;">
        <asp:Chart ID="chartRegCand" runat="server"  Width="330px" Height="330px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
          <Series>
            <asp:Series Name="regCandSeries" ChartType="Column" ChartArea="regChartArea">
          </asp:Series>
        </Series>
      <ChartAreas>
          <asp:ChartArea Name="regChartArea">
                    <area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" 
                     wallwidth="0" IsClustered="False"></area3dstyle> 
          </asp:ChartArea>
       </ChartAreas>
    </asp:Chart>
    </td>
     <td  style="width:330px; height:330px;">
        <asp:Chart ID="chartTrained" runat="server"  Width="330px" Height="330px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
          <Series>
            <asp:Series Name="trnSeries" ChartType="Column" ChartArea="trnChartArea">
          </asp:Series>
        </Series>
      <ChartAreas>
          <asp:ChartArea Name="trnChartArea">
                    <area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" 
                     wallwidth="0" IsClustered="False"></area3dstyle> 
          </asp:ChartArea>
       </ChartAreas>
    </asp:Chart>
    </td>
     <td  style="width:330px; height:330px;">
        <asp:Chart ID="ChartUnderTraining" runat="server"  Width="330px" Height="330px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
          <Series>
            <asp:Series Name="udtSeries" ChartType="Column" ChartArea="udtChartArea">
          </asp:Series>
        </Series>
      <ChartAreas>
          <asp:ChartArea Name="udtChartArea">
                    <area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" 
                     wallwidth="0" IsClustered="False"></area3dstyle> 
          </asp:ChartArea>
       </ChartAreas>
    </asp:Chart>
    </td>
    </tr>
     <tr>
     <td  align="center" valign="middle" style="width:330px; height:26px;">
          <asp:Label CssClass="labelStyle" runat="server" ID="lbRegCandidatesT" Text="Registered" Font-Bold="true" ForeColor="Blue"></asp:Label>
          <asp:Label CssClass="labelStyle" runat="server" ID="lbRegCandidates"  ForeColor="Blue" Width="30px" CssClass="right_align"></asp:Label>
          <asp:ImageButton runat="server" ID="ImageButton6" ImageAlign="AbsMiddle" Height="16px" Width="16px" AlternateText="Jo" OnClick="prtbtnRegCandidates_Click" ImageUrl="~/Image/Print.gif" ToolTip="Print Registered candidates chart" />

     </td>
      <td align="center" valign="middle" style="width:330px; height:26px;">
          <asp:Label CssClass="labelStyle" runat="server" ID="lbTrainedT" Text="Trained" Font-Bold="true" ForeColor="Blue" ></asp:Label>
          <asp:Label CssClass="labelStyle" runat="server"  ID="lbTrained" ForeColor="Blue" Width="30px" CssClass="right_align"></asp:Label>
          <asp:ImageButton runat="server" ID="ImageButton7" ImageAlign="AbsMiddle" Height="16px" Width="16px" AlternateText="Jo" OnClick="prtbtnTrained_Click" ImageUrl="~/Image/Print.gif" />

      </td>
      <td align="center" valign="middle" style="width:330px; height:26px;">
          <asp:Label CssClass="labelStyle" runat="server" ID="lbUnderTrainingT" Text="Under Training" Font-Bold="true" ForeColor="Blue"></asp:Label>
          <asp:Label CssClass="labelStyle"  runat="server" ID="lbUnderTraining" ForeColor="Blue" Width="30px" CssClass="right_align" ></asp:Label>
          <asp:ImageButton runat="server" ID="ImageButton8" ImageAlign="AbsMiddle" Height="16px" Width="16px" AlternateText="Jo" OnClick="prtbtnUnderTraining_Click" ImageUrl="~/Image/Print.gif" />

      </td>
     </tr>

     <tr style="height:30px;">
     <td colspan="3" valign="middle" align="center" style="border-bottom-color:Blue; border-bottom-style:solid; border-top-color:Blue; border-top-style:solid; border-width:medium;" >
        <asp:ImageButton runat="server" ID="btnClose" ImageUrl="~/Image/Close.gif"  AlternateText="Close" ImageAlign="AbsMiddle" Height="28px"  Width="80px" onClick="btnClose_Click" ToolTip="Close this screen"  />&nbsp;&nbsp;
        <asp:ImageButton runat="server" ID="imgPrint" AlternateText="Print" ImageAlign="AbsMiddle" ImageUrl="~/Image/PrintC.gif" Height="28px" Width="80px" OnClick="prtButton_Click" ToolTip="Print the above displayed graph" />
     </td>
     </tr>
   </table>
   </center>
</div>
    </form>
    </center>
</body>
</html>
