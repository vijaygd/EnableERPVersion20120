<%@ Page Title="List of Companies " Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.ReportSection.CompanyReport" Codebehind="CompanyReport.aspx.cs" ClientIDMode="Static" %>


<%@ Register Assembly="Stimulsoft.Report.Web, Version=2013.1.1600.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a"
    Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
         <td class="pageHeader">Reports</td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">
        <tr>
         <td>List of Companies </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
   <table cellpadding="0" cellspacing="0" class="skiplink">
        <tr>
            <td>
                <h1><span id="skipToTop" class="skiplink" style="color:White">List of Companies </span></h1>
            </td>
        </tr>
    </table>
  <table>
        <tr>
            <td  style ="width:130px">
                <label for="ctl00_ContentPlaceHolder2_DdlParentCompany">Parent Company:</label>
            </td>
            <td>
                <select id="DdlParentCompany" runat="server" 
                    onchange="javascript:DdlParentCompany_selectedIndexChanged(this.value,'ParentCompanyID','DdlCompany','DdlHiddenCompanies');"></select>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td  style ="width:130px">
                <label for="ctl00_ContentPlaceHolder2_DdlCompany">Company:</label>
            </td>
            <td>
                <select id="DdlCompany" runat="server"
                 onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHiddenCompanyID').val($('#ctl00_ContentPlaceHolder2_DdlCompany').val());" />       
            </td>
            <td style="display:none" >
            <label for="ctl00_ContentPlaceHolder2_DdlHiddenCompanies">hidden City</label>
                <select id="DdlHiddenCompanies" runat="server" />
                
              <label for="ctl00_ContentPlaceHolder2_TxtHiddenCompanyID">hidden City</label>
                <asp:TextBox ID="TxtHiddenCompanyID" runat="server" />
        </td>
        </tr>
    </table>
<table>
    <tr>
        <td  style ="width:130px">
            <label for="ctl00_ContentPlaceHolder2_DdlState">State</label>
        </td>
        <td>
            <select id="DdlState" runat="server"
                onchange="javascript:DdlState_SelectIndexChanged(this.value,'StateID','DdlCity','DdlHiddenCity');" />
        </td>
        <td id="TdCity"  style ="padding-left:10px">
            <label for="ctl00_ContentPlaceHolder2_DdlCity">City</label>
        </td>
        <td>
            <select id="DdlCity" runat="server"
                onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHidddenCity').val($('#ctl00_ContentPlaceHolder2_DdlCity').val());" />
        </td>
        <td style="display:none" >
            <label for="ctl00_ContentPlaceHolder2_DdlHiddenCity">hidden City</label>
                <select id="DdlHiddenCity" runat="server" />
                
              <label for="ctl00_ContentPlaceHolder2_TxtHidddenCity">hidden City</label>
                <asp:TextBox ID="TxtHidddenCity" runat="server" />
        </td>
    </tr>
</table>
    <table>
        <tr>
            <td style ="width:130px" >
                 <label for="ctl00_ContentPlaceHolder2_DdlIndustrialSegment">Industry Segment:</label>
            </td>
            <td>
                <select id="DdlIndustrialSegment" runat="server" class="mandatory" messagetext="Industry Segment"  />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Button ID="BtnGenerateReport" runat="server" OnClick="BtnGenerateReport_Click" Text="Generate" />
                &nbsp;&nbsp;
                <asp:ImageButton runat="server" ID="ImageButton5" ImageUrl="~/App_Themes/Default/images/ExportToExcel.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="20"  Width="20px"
                 onclick="btnExportToExcel_Click" ToolTip="Export To Excel Directly"  />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>    
                 <cc1:StiWebViewer ID="StiWebViewer1" runat="server"  RenderMode="UseCache" ViewMode="WholeReport"
                     Height="100%" />
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

    <script src="CompanyReport.js" type="text/javascript"></script>
</asp:Content>

