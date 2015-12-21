<%@ Page Title="Add Enable India Employees" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" Inherits="EnableIndia.Admin.RegisterEmployee" Codebehind="RegisterEmployee.aspx.cs" %>

<%@ Register Assembly="System.Web.DynamicData, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"  Namespace="System.Web.DynamicData" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">Administration Section--Handle With Care!</td>
        </tr>
    </table>    
    <table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">    
        <tr>
            <td><asp:Label CssClass="labelStyle" ID="LblTitle" runat="server" Text="Add Enable India Employees" MessageStartText="Add new" /></td>
        </tr>
     </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<table class="skiplink" cellpadding="0" cellspacing="0">
    <tr>
        <td><h1 id="skipToTop" class="skiplink"><%= LblTitle.Text %></h1></td>
    </tr>
</table>

<table cellpadding="4" cellspacing="2">
    <tr>
        <td>
            <table>
                <tr>
                    <td style="width:122px"><label for="ctl00_ContentPlaceHolder2_DdlRoles">SELECT ROLE</label></td>
                    <td><select id="DdlRoles" runat="server" class="mandatory" messagetext="Role" /></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td valign="top" style="width:116px">NAME OF EMPLOYEE</td>
                    <td style="padding-left:8px">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <label for="ctl00_ContentPlaceHolder2_TxtFirstName">FIRST NAME</label><br />
                                    <asp:TextBox ID="TxtFirstName" runat="server" Width="120px"
                                         class="mandatory" messagetext="First name" />
                                </td>
                                <td style="padding-left:20px">
                                    <label for="ctl00_ContentPlaceHolder2_TxtMiddleName">Middle name</label><br />
                                    <asp:TextBox ID="TxtMiddleName" runat="server" Width="120px" />
                                </td>
                                <td style="padding-left:20px">
                                    <label for="ctl00_ContentPlaceHolder2_TxtLastName">LAST NAME</label><br />
                                    <asp:TextBox ID="TxtLastName" runat="server" Width="120px"
                                    class="mandatory" messagetext="Last name" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:122px"><label for="ctl00_ContentPlaceHolder2_TxtUserName">USER-NAME</label></td>
                    <td><asp:TextBox ID="TxtUserName" runat="server" Width="150px" class="mandatory" messagetext="Username" /></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:122px"><label for="ctl00_ContentPlaceHolder2_TxtPassword">PASS-WORD</label></td>
                    <td><asp:TextBox ID="TxtPassword" runat="server" Width="150px" class="mandatory" messagetext="Password" /></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:122px"><label for="ctl00_ContentPlaceHolder2_TxtEmailAddress">E-MAIL</label></td>
                    <td>
                        <asp:TextBox ID="TxtEmailAddress" runat="server" Width="300px" class="mandatory" messagetext="Email address"
                            emailaddress="true" />
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:122px"></td>
                    <td>
                        <asp:Button ID="BtnManageEmployee" runat="server" Text="Submit" IsSubmit="true" 
                            OnClientClick="javascript:return ValidateForm();" OnClick="BtnManageEmployee_Click" />&nbsp;&nbsp;
                        <asp:Button ID="BtnCancel" runat="server" Text="Clear" OnClick="BtnCancel_Click" />&nbsp;
                        <asp:Button ID="BtnDeleteEmployee" runat="server" Text="Delete" Visible="false"
                            CommandArgument='<%#Eval("employee_id") %>'
                            OnClientClick="javascript:return ValidateEmployee();"
                            OpenCandidateTask="0"
                            OpenCompanyTask="0"
                            OpenTraningProject="0"
                            OpenEmpProject="0"
                            OnClick="BtnDeleteEmployee_Click" />
                        <span id="SpnMessage" runat="server" style="vertical-align:super" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<script src="RegisterEmployee.js" type="text/javascript"></script>
</asp:Content>

