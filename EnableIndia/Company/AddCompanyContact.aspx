<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true" Inherits="EnableIndia.Company.AddCompanyContact" Codebehind="AddCompanyContact.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<table>
    <tr>
        <td>
            <table>
                <tr>
                    <td style="width:150px">
                        <label for="ctl00_ContentPlaceHolder1_TxtNameOfContact">NAME OF CONTACT</label>
                    </td>
                    <td style="width:200px">
                        <asp:TextBox ID="TxtNameOfContact" runat="server" class="mandatory" messagetext="Contact Name" />
                    </td>
                    <td>
                        <label for="ctl00_ContentPlaceHolder1_DdlTypeOfContact">Type of Contact</label>
                    </td>
                    <td>
                        <select id="DdlTypeOfContact" runat="server" >
                            <option value="Regular">Regular</option>
                            <option value="Primary">Primary</option>
                            <option value="Escalation">Escalation</option>
                        </select>
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td style="width:150px">
                        <label for="ctl00_ContentPlaceHolder1_TxtDesignation">DESIGNATION</label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtDesignation" runat="server" class="mandatory" messagetext="Designation" />
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td style="width:150px">
                        <label for="ctl00_ContentPlaceHolder1_TxtPhoneNumber">PHONE NUMBER</label>
                    </td>
                    <td style="width:200px">
                        <asp:TextBox ID="TxtPhoneNumber" runat="server" class="mandatory" messagetext="Phone number" phonenumber="true" />
                    </td>
                    <td>
                        <label for="ctl00_ContentPlaceHolder1_TxtEmail">E-mail</label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtEmail" runat="server"  messagetext="Email"/>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width:150px">
                    </td>
                    <td>
                        <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClientClick="javascript:return ValidateForm();"
                            onclick="BtnSubmit_Click" />&nbsp;&nbsp;
                        <input id="BtnCancel" type="button" value="Cancel" onclick="javascript:self.close();"/>
                        <asp:Button ID="BtnDeleteContact" runat="server" Text="Delete" Visible="false"
                            OnClientClick="javascript:return confirm('Are you sure you want to delete this contact?');"
                            OnClick="BtnDeleteCompanyContact_Click" />
                        <asp:HiddenField runat="server" ID="txtParent" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</div>
    <script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="../Scripts/Common.js" type="text/javascript"></script>
</asp:Content>

