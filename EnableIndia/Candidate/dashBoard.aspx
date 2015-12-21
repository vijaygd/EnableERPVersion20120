<%@ Page Title="" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Async="true" CodeBehind="dashBoard.aspx.cs" Inherits="EnableIndia.Candidate.dashBoard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="divDashBoard" style="position:absolute; left: 201; z-index: 300; margin-top:0; padding:0" >
   <center>
   <asp:Panel runat="server" ID="pnCharts" ScrollBars="Vertical"  Height="570px" Width="820px">
   <table cellpadding="1" cellspacing="0" style="width:800px; margin-top:0px;">
     <tr style="height:26px;">
     <td  valign="middle" align="left" style="border-bottom-color:Blue; border-bottom-style:solid; border-top-color:Blue; border-top-style:solid; border-width:medium;" >
        <asp:Label CssClass="labelStyle" runat="server" ID="Status" Text="S t a t u s" Font-Bold="true" Font-Size="9" ForeColor="Blue"></asp:Label>
     </td>
     <td colspan="2" valign="middle" align="right" style="border-bottom-color:Blue; border-bottom-style:solid; border-top-color:Blue; border-top-style:solid; border-width:medium;" >
        <asp:Label CssClass="labelStyle" runat="server" ID="lbStatusDateT" Text="Date: "  Font-Bold="true" Font-Size="12" ForeColor="Blue"></asp:Label>
        <asp:Label CssClass="labelStyle" runat="server" ID="lbStatusDate" Font-Bold="true" Font-Size="9" ForeColor="Blue"></asp:Label>
     </td>
     </tr>
     <tr>
     <td colspan="2" valign="middle" align="left">
           <asp:Label CssClass="labelStyle" runat="server" ID="lbUnmpAcL" Text="Unemployed active Candidates till date: " Font-Bold="true"></asp:Label>
           <asp:Label CssClass="labelStyle" runat="server" ID="lbUnmpAc" Font-Bold="true" ForeColor="#D32232"></asp:Label>&nbsp;

     </td>
     <td colspan="2" valign="middle" align="right">
          <asp:Label CssClass="labelStyle" runat="server" ID="lbToBepL" Text="To be Profiled (Last Six Months): " Font-Bold="true"></asp:Label>
          <asp:Label CssClass="labelStyle" runat="server" ID="lbToBep" Font-Bold="true" ForeColor="#D32232"></asp:Label>
     </td>
     </tr>
     <tr>
     <td  style="width:240px; height:240px;">
        <asp:Chart ID="gotJobsChart" runat="server"  Width="240px" Height="240px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
          <Series>
            <asp:Series Name="gotJobSeries" ChartType="FastLine" ChartArea="gotJobChartArea" BorderWidth="4">
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
      <td style="width:240px; height:240px;">
        <asp:Chart ID="placements" runat="server"  Width="240px" Height="240px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
          <Series>
            <asp:Series Name="placementsSeries" ChartType="FastLine" ChartArea="placementChartArea" BorderWidth="4" >
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
         <td  style="width:240px; height:240px;">
            <asp:Chart ID="ChartUnderTraining" runat="server"  Width="240px" Height="240px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
          <Series>
            <asp:Series Name="udtSeries" ChartType="FastLine" ChartArea="udtChartArea" BorderWidth="4">
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
     <td  align="center" valign="middle" style="width:240px; height:20px;">
          <asp:LinkButton CssClass="bLbStyle" runat="server" ID="lbJobsObtained" Text="Jobs Obtained" Font-Bold="true" ForeColor="Blue" OnClick="lbGotJobsClicked"></asp:LinkButton>&nbsp;
          <asp:Label CssClass="labelStyle" runat="server" ID="lbJobObtainedTot" Width="30px" ForeColor="Blue" CssClass="right_align"></asp:Label>
     </td>
      <td align="center" valign="middle" style="width:240px; height:20px;">
          <asp:LinkButton CssClass="bLbStyle" runat="server" ID="lbPlacements" Text="Placements" Font-Bold="true" ForeColor="Blue" OnClick="lbPlacementsClicked"  ></asp:LinkButton>
          <asp:Label CssClass="labelStyle" runat="server" ID="lbPlacementsTot" ForeColor="Blue" CssClass="right_align"></asp:Label>
      </td>
      <td align="center" valign="middle" style="width:240px; height:20px;">
          <asp:LinkButton CssClass="bLbStyle" runat="server" ID="LinkButton9" Text="Under Training" Font-Bold="true" ForeColor="Blue"  ></asp:LinkButton>
          <asp:Label CssClass="labelStyle"  runat="server" ID="lbUnderTraining" ForeColor="Blue" Width="30px" CssClass="right_align" ></asp:Label>
      </td>
     </tr>
     </table>
     <center>
    <table cellpadding="1" cellspacing="0" style="width:520px;">
     <tr>
     <td  style="width:240px; height:240px;">
        <asp:Chart ID="chartRegCand" runat="server"  Width="240px" Height="240px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
          <Series>
            <asp:Series Name="regCandSeries" ChartType="FastLine" ChartArea="regChartArea" BorderWidth="4">
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
     <td  style="width:240px; height:240px;">
        <asp:Chart ID="chartTrained" runat="server"  Width="240px" Height="240px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
          <Series>
            <asp:Series Name="trnSeries" ChartType="FastLine" ChartArea="trnChartArea" BorderWidth="4">
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
    </tr>
     <tr>
    <td  align="center" valign="middle" style="width:240px; height:20px;">
        <asp:LinkButton CssClass="bLbStyle" runat="server" ID="LinkButton7" Text="Registered" Font-Bold="true" ForeColor="Blue"  ></asp:LinkButton>
          <asp:Label CssClass="labelStyle" runat="server" ID="lbRegCandidates"  ForeColor="Blue" Width="30px" CssClass="right_align"></asp:Label>
     </td>
      <td align="center" valign="middle" style="width:240px; height:20px;">
          <asp:LinkButton CssClass="bLbStyle" runat="server" ID="LinkButton8" Text="Trained" Font-Bold="true" ForeColor="Blue" ></asp:LinkButton>
          <asp:Label CssClass="labelStyle" runat="server"  ID="lbTrained" ForeColor="Blue" Width="30px" CssClass="right_align"></asp:Label>
      </td>
      <td align="center" valign="middle" style="width:240px; height:20px;">
      </td>
     </tr>
   </table>
   </center>
   </asp:Panel>
   </center>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

</asp:Content>

