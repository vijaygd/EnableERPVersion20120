<%@ Page Title="" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" CodeBehind="dashBoard.aspx.cs" Inherits="EnableIndia.Candidate.dashBoard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="divDashBoard" style="position:absolute; left: 201; z-index: 300; margin-top:0;" >
   <center>
   <asp:Panel runat="server" ID="pnCharts" ScrollBars="Vertical"  Height="600px" Width="820px">
   <table cellpadding="1" cellspacing="0" style="width:800px;">
     <tr style="height:30px;">
     <td  valign="middle" align="left" style="border-bottom-color:Blue; border-bottom-style:solid; border-top-color:Blue; border-top-style:solid; border-width:medium;" >
        <asp:Label runat="server" ID="Status" Text="S t a t u s" Font-Bold="true" Font-Size="10" ForeColor="Blue"></asp:Label>
     </td>
     <td colspan="2" valign="middle" align="right" style="border-bottom-color:Blue; border-bottom-style:solid; border-top-color:Blue; border-top-style:solid; border-width:medium;" >
        <asp:Label runat="server" ID="lbStatusDateT" Text="Date: "  Font-Bold="true" Font-Size="12" ForeColor="Blue"></asp:Label>
        <asp:Label runat="server" ID="lbStatusDate" Font-Bold="true" Font-Size="10" ForeColor="Blue"></asp:Label>
     </td>
     </tr>
     <tr>
     <td colspan="2" valign="middle" align="left">
           <asp:Label runat="server" ID="lbUnmpAcL" Text="Unemployed active Candidates till date: " Font-Bold="true"></asp:Label>
           <asp:Label runat="server" ID="lbUnmpAc" Font-Bold="true" ForeColor="#D32232"></asp:Label>&nbsp;

     </td>
     <td colspan="2" valign="middle" align="right">
          <asp:Label runat="server" ID="lbToBepL" Text="To be Profiled (Last Six Months): " Font-Bold="true"></asp:Label>
          <asp:Label runat="server" ID="lbToBep" Font-Bold="true" ForeColor="#D32232"></asp:Label>
     </td>
     </tr>
     <tr>
     <td  style="width:255px; height:255px;">
        <asp:Chart ID="gotJobsChart" runat="server"  Width="255px" Height="255px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
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
      <td style="width:255px; height:255px;">
        <asp:Chart ID="placements" runat="server"  Width="255px" Height="255px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
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
         <td  style="width:255px; height:255px;">
            <asp:Chart ID="ChartUnderTraining" runat="server"  Width="255px" Height="255px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
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
     <td  align="center" valign="middle" style="width:255px; height:26px;">
          <asp:LinkButton CssClass="bLbStyle" runat="server" ID="lbJobsObtained" Text="Jobs Obtained" Font-Bold="true" ForeColor="Blue" OnClick="lbGotJobsClicked"></asp:LinkButton>&nbsp;
          <asp:Label runat="server" ID="lbJobObtainedTot" Width="30px" ForeColor="Blue" CssClass="right_align"></asp:Label>
     </td>
      <td align="center" valign="middle" style="width:255px; height:26px;">
          <asp:LinkButton CssClass="bLbStyle" runat="server" ID="lbPlacements" Text="Placements" Font-Bold="true" ForeColor="Blue" OnClick="lbPlacementsClicked"  ></asp:LinkButton>
          <asp:Label runat="server" ID="lbPlacementsTot" ForeColor="Blue" CssClass="right_align"></asp:Label>
      </td>
      <td align="center" valign="middle" style="width:255px; height:26px;">
          <asp:LinkButton CssClass="bLbStyle" runat="server" ID="LinkButton9" Text="Under Training" Font-Bold="true" ForeColor="Blue"  ></asp:LinkButton>
          <asp:Label  runat="server" ID="lbUnderTraining" ForeColor="Blue" Width="30px" CssClass="right_align" ></asp:Label>
      </td>
     </tr>
     </table>
     <center>
    <table cellpadding="1" cellspacing="0" style="width:520px;">
     <tr>
     <td  style="width:255px; height:255px;">
        <asp:Chart ID="chartRegCand" runat="server"  Width="255px" Height="255px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
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
     <td  style="width:255px; height:255px;">
        <asp:Chart ID="chartTrained" runat="server"  Width="255px" Height="255px" BorderDashStyle="Solid" BackSecondaryColor="White"  BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"  BorderColor="#1A3B69">
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
    </tr>
     <tr>
    <td  align="center" valign="middle" style="width:255px; height:26px;">
        <asp:LinkButton CssClass="bLbStyle" runat="server" ID="LinkButton7" Text="Registered" Font-Bold="true" ForeColor="Blue"  ></asp:LinkButton>
          <asp:Label runat="server" ID="lbRegCandidates"  ForeColor="Blue" Width="30px" CssClass="right_align"></asp:Label>
     </td>
      <td align="center" valign="middle" style="width:255px; height:26px;">
          <asp:LinkButton CssClass="bLbStyle" runat="server" ID="LinkButton8" Text="Trained" Font-Bold="true" ForeColor="Blue" ></asp:LinkButton>
          <asp:Label runat="server"  ID="lbTrained" ForeColor="Blue" Width="30px" CssClass="right_align"></asp:Label>
      </td>
      <td align="center" valign="middle" style="width:255px; height:26px;">
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

