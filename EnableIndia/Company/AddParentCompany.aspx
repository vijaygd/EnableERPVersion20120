<%@ Page Title="Add Parent Company" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Company.AddParentCompany" Codebehind="AddParentCompany.aspx.cs" ClientIDMode="Static" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td colspan="2" class="pageHeader">Company Section</td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">
    <tr >
        <td colspan="2"><span id="SpnOperationStatus" runat="server">Add</span> Parent Company</td>
    </tr>
</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink"><%=SpnOperationStatus.InnerText %> Parent Company</span></h1>
        </td>
    </tr>
</table>
<%--<table>
    <tr>
        <td class="message" style="width:330px">    
            Create new parent company by filling this form.
            Mandatory fields are shown in capitals.
        </td>
    </tr>
</table>--%>

<table>
    <tr>
        <td valign="top">
            <label for="ctl00_ContentPlaceHolder2_TxtParentCompanyName">NAME OF PARENT COMPANY</label>
        </td>
        <td valign="top">
            <asp:TextBox ID="TxtParentCompanyName" runat="server" Width="350px" class="mandatory" messagetext="Parent company name" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td align="center" style="padding-left:157px">
      
            <asp:Button ID="BtnManageParentCompany" runat="server" Text="Submit" ToolTip="Submit"
                OnClientClick="javascript:return ValidateForm();"
                OnClick="BtnManageParentCompany_Click" />      &nbsp;&nbsp;
                
            <%--         <input type="reset" value="Clear" />--%>
            <asp:Button ID="BtnClear" runat="server" Text="Clear" OnClick="BtnClear_Click"/>
        </td>
    </tr>
</table>

<script src="AddParentCompany.js" type="text/javascript"></script>

</asp:Content>

