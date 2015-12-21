<%@ Page Title="Set Default Age for Candidates in Searches" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" Inherits="EnableIndia.Admin.DefaultAgeForCandidatesInSearch" Codebehind="DefaultAgeForCandidatesInSearch.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">Administration Section--Handle With Care!</td>
        </tr>
    </table>    
    <table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">    
        <tr>
            <td>Set Default Age for Candidates in Searches</td>
        </tr>
     </table>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink">Set Default Age</span></h1>
        </td>
    </tr>
</table>

<%--<h1 id="skipToTop">Set Default Age for Candidates in Searches</h1>--%>
<table cellpadding="4" cellspacing="0">
    <tr>
        <td>Current default setting for Age for candidates  in Searches: <span id="SpnDefaultAge" runat="server" class="readonly_bold_text" /> Years</td>
    </tr>
</table>

<table cellpadding="4" cellspacing="0" style="margin-top:8px">
    <tr>
        <td style="width:170px">
            <label for="ctl00_ContentPlaceHolder2_DdlAgeGroups">SELECT DEFAULT AGE FOR CANDIDATES IN SEARCHES:</label>
        </td>
        <td valign="top"><select id="DdlAgeGroups" runat="server" /></td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" style="margin-top:8px">
    <tr>
        <td style="width:170px">&nbsp;</td>
        <td>
            <asp:Button ID="BtnSetAgeGroup" runat="server" Text="Submit" OnClick="BtnSetAgeGroup_Click" />&nbsp;&nbsp;
            <%--<input id="" type="reset" value="Reset" />--%>
        </td>
    </tr>
</table>
<script src="DefaultAgeForCandidatesInSearch.js" type="text/javascript"></script>
</asp:Content>

