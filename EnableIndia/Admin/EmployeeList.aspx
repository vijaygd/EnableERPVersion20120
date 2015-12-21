<%@ Page Title="Enable India Employee List & Details" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" Inherits="EnableIndia.Admin.EmployeeList" Codebehind="EmployeeList.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">Administration Section--Handle With Care!</td>
        </tr>
    </table>    
    <table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">    
        <tr>
            <td>Enable India Employee List & Details</td>
        </tr>
     </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<%--<h1 id="skipToTop" class="skiplink">Enable India Employee List and Details</h1>--%>
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1 id="skipToTop" class="skiplink">Enable India Employee List and Details</h1>
        </td>
    </tr>
</table>
<table cellpadding="4">
    <tr>
        <td>
            <asp:ListView ID="LstViewEmployees" runat="server">
                <LayoutTemplate>
                    <table id="TblEmployees" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                        bordercolor="#808080" border="1px">
                        <thead>
                            <tr class="grid-header">
                                <th align="right">No.</th>
                                <%--<th><span class="skiplink">Radio button for selecting row to update or delete</span></th>--%>
                                <th align="left">Name of Employee</th>
                                <th align="left">Role</th>
                                <th align="left">User-Name</th>
                                <th align="left">Password</th>
                                <th align="left">Email</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="right" id="TdRecordNumber"></td>
                        <th align="left" title="Name : <%#Eval("employee_name") %>">
                            <asp:LinkButton ID="LnkBtnEmployeeName" runat="server" Text='<%#Eval("employee_name") %>'
                                CommandArgument='<%#Eval("employee_id") %>'
                                Font-Bold="false" OnClick="LnkBtnEmployeeName_Click" />
                        </th>
                        <td align="left" title="<%#Eval("employee_name") %>'s Role"><%#Eval("role_name")%></td>
                        <td align="left" title="<%#Eval("employee_name") %>'s Login Name"><%#Eval("login_name") %></td>
                        <td align="left" title="<%#Eval("employee_name") %>'s Login Password"><%#Eval("login_password") %></td>
                        <td align="left" title="<%#Eval("employee_name") %>'s Email"><%#Eval("email_address") %></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                     <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                        bordercolor="#808080" border="1px">
                        <thead>
                            <tr class="grid-header">
                                <%--<th></th>--%>
                                <th align="left">Name of Employee</th>
                                <th align="left">Role</th>
                                <th align="left">User-Name</th>
                                <th align="left">Password</th>
                                <th align="left">Email</th>
                            </tr>
                        </thead>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>
<script src="EmployeeList.js" type="text/javascript"></script>
</asp:Content>

