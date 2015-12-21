<%@ Page Title="Flagwise Closed Candidate Work Distribution" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.ReportSection.FlagWiseClosedCandidateTask" Codebehind="FlagWiseClosedCandidateTask.aspx.cs" ClientIDMode="Static" %>

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
            <td>Flagwise Closed Candidate Work Distribution</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
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
               <%-- <cc1:StiWebViewer ID="StiWebViewer1" runat="server" RenderMode="UseCache" ViewMode="WholeReport"
                    Height="800px" Width="1000px" ScrollBarsMode="true" />--%>
                     <cc1:StiWebViewer ID="StiWebViewer1" runat="server"  RenderMode="UseCache" ViewMode="WholeReport"
                     Height="100%" />
            </td>
        </tr>
    </table>
</asp:Content>

