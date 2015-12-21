<%@ Page Title="Owner-wise Training Work Distribution" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.ReportSection.OwnerwiseTrainingWorkDistribution" Codebehind="OwnerwiseTrainingWorkDistribution.aspx.cs" %>

<%@ Register Assembly="Stimulsoft.Report.Web, Version=2013.1.1600.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a"
    Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">Reports</td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0"  class="pageHeaderLevel1">
        <tr>
            <td>Owner-wise Training Work Distribution</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table>
        <tr>
            <td style="width:125px"><label for="ctl00_ContentPlaceHolder2_DdlProjectType"> Project Type</label></td>
            <td>
                <select id="DdlProjectType" runat="server">
                    <option value="Open">Open</option>
                    <option value="Closed">Closed</option>
                    </select>
            </td>
        </tr>
     </table>
     <table>
        <tr>
            <td style="width:125px">
                <label for="ctl00_ContentPlaceHolder2_DdlPrograms">Training Program</label>
            </td>
            <td>
                <select id="DdlPrograms" runat="server"
                    onchange="javascript:DdlPrograms_SelectIndexChanged(this.value,'TrainingProgramID','DdlProjects','DdlHiddenProjects');" />
                 
            </td>
        </tr>
      </table>
       <table>
        <tr>
            <td style="width:125px">
                <label for="ctl00_ContentPlaceHolder2_DdlProjects">Training Project</label>
            </td>
            <td>
                <select id="DdlProjects" runat="server"
                    onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHiddenProjects').val($('#ctl00_ContentPlaceHolder2_DdlProjects').val());" />
                 
            </td>
             <td style="display:none"  >
                <label for="ctl00_ContentPlaceHolder2_DdlHiddenProjects">Hidden </label>
                <select id="DdlHiddenProjects" runat="server"/>
                <label for="ctl00_ContentPlaceHolder2_TxtHiddenProjects">Hidden</label>
                <asp:TextBox ID="TxtHiddenProjects" runat="server" />
            </td>
        </tr>
      </table>
      
    <table>
        <tr>
            <td>Select Date:</td>
            <td style="padding-left:30px"><label for="ctl00_ContentPlaceHolder2_DdlDateType">Type</label></td>
            <td>
                <select id="DdlDateType" runat="server">
                    <option value="Start">Start</option>
                    <option value="End">End</option>
                    </select>
            </td>
            <td style="padding-left:30px"><label for="ctl00_ContentPlaceHolder2_TxtFromDate">From Date :</label> </td>
            <td>
                <asp:TextBox ID="TxtFromDate" runat="server" />
            </td>
            <td style="padding-left:30px"><label for="ctl00_ContentPlaceHolder2_TxtToDate">To Date :</label></td>
            <td>
                <asp:TextBox ID="TxtToDate" runat="server" />
            </td>
        </tr>
    </table>
     
     
      <table>
        <tr>
            <td>
                <asp:Button ID="BtnGenerateReport" runat="server" OnClick="BtnGenerateReport_Click" Text="Generate" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                 <cc1:StiWebViewer ID="StiWebViewer1" runat="server"  RenderMode="UseCache" ViewMode="WholeReport"
                     Height="100%" />
                <%--<cc1:StiWebViewer ID="StiWebViewer1" runat="server" RenderMode="UseCache" ViewMode="WholeReport"
                    ScrollBarsMode="true"  Height="800px" Width="1000px" />--%>
            </td>
        </tr>
    </table>
     <div id="divforScript" class="load">
         <table width="500px" style="height:100px; border-bottom-color:Blue; border-bottom-style: solid; border-top-color: Blue; border-top-style: solid; border-width:1; background-color:White;">
         <tr>
            <td valign="middle" align="center" style="width:500px;">
                <asp:Image runat="server" ID="imbPb" AlternateText="...Wait..." ImageUrl="~/Image/ajax-loader.gif" Width="30px" Height="30px" />
           </td>
         </tr>
          <tr>
              <td valign="middle" align="center" style="width:500px;">
                <asp:Label CssClass="labelStyle" runat="server" ID="lbWaitState" Text="-: Please Wait - Report Generation under progress : -" Font-Bold="true" Font-Size="10" ForeColor="#D32232"></asp:Label>
              </td>
            </tr>
        </table>
    </div>

    <script src="OwnerwiseTrainingWorkDistribution.js"  type="text/javascript"></script>
</asp:Content>

