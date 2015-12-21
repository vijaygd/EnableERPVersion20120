<%@ Page Title="Help" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true" Inherits="EnableIndia.ITextPopup" Codebehind="ITextPopup.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div tabindex="1" style="width:0px;height:0px"></div>
    <span id="SpnMessage" runat="server" class="message_bold" /><br />
    <input type="button" value="Close" onclick="javascript:self.close();" />
</asp:Content>

