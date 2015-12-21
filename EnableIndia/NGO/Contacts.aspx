<%@ Page Title="NGO Contacts" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true" Inherits="EnableIndia.NGO.Contacts" Codebehind="Contacts.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="../Scripts/Common.js" type="text/javascript"></script>

<div></div>
<table cellpadding="4">
    <tr>
        <td>
            <table>
                <tr>
                    <td style="width:105px"><label for="ctl00_ContentPlaceHolder1_DdlCandidateTypes">Type of Contact</label></td>
                    <td>
                        <select id="DdlCandidateTypes" runat="server">
                            <option value="Regular">Regular</option>
                            <option value="Primary">Primary</option>
                        </select>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td><label for="ctl00_ContentPlaceHolder1_TxtContactName">NAME OF CONTACT</label></td>
                    <td><asp:TextBox ID="TxtContactName" runat="server" Width="250px" class="mandatory" messagetext="Name of contact" /></td>
                </tr>
            </table>
            
             <table>
                <tr>
                    <td style="width:105px"><label for="ctl00_ContentPlaceHolder1_TxtDesignation">Designation</label></td>
                    <td><asp:TextBox ID="TxtDesignation" runat="server" Width="250px" /></td>
                </tr>
            </table>
            
             <table>
                <tr>
                    <td style="width:105px"><label for="ctl00_ContentPlaceHolder1_TxtPhoneNumber">Phone Number</label></td>
                    <td><asp:TextBox ID="TxtPhoneNumber" runat="server" Width="250px" /></td>
                </tr>
            </table>
            
             <table>
                <tr>
                    <td style="width:105px"><label for="ctl00_ContentPlaceHolder1_TxtEmailAddress">E-mail address</label></td>
                    <td><asp:TextBox ID="TxtEmailAddress" runat="server" Width="250px" /></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:105px">
                    </td>
                    <td>
                        <asp:Button ID="BtnSubmit" runat="server" Text="Submit" IsSubmit="true" OnClientClick="javascript:return ValidateForm();"
                            OnClick="BtnSubmit_Click" />&nbsp;&nbsp;
                        <input id="BtnCancel" type="button" value="Cancel" onclick="javascript:self.close();" />&nbsp;&nbsp;
                        <asp:Button ID="BtnDeleteContact" runat="server" Text="Delete" Visible="false"
                            OnClientClick="javascript:return confirm('Are you sure you want to delete this contact?');"
                            OnClick="BtnDeleteNGOContact_Click" /> 
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

