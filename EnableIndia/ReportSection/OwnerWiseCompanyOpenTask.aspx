<%@ Page Title="Owner-wise Company Open Task Report" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.ReportSection.OwnerWiseCompanyOpenTask" Codebehind="OwnerWiseCompanyOpenTask.aspx.cs" %>
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
            <td>OwnerWise Work Distribution of Open Company Tasks </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
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

