<%@ Page Title="" Language="C#" MasterPageFile="~/MobileDevices/mobileMaster.Master" AutoEventWireup="true" CodeBehind="mdDefaultPage.aspx.cs" Inherits="EnableIndia.MobileDevices.mdDefaultPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style  type="text/css">
    .container {
          background: transparent;
          position: absolute;
          top : 30%;
          left : 0px;
          width: 100%;
          overflow: visible;
          visibility: visible;
          display: block;
          text-align:center;
        }

        .announce {
          margin:0px auto;
          position  :relative;
          top : -15px;
          width: 60%;
          height : 300px;
          visibility: visible;
        }
    </style>
         <div class="container">
         <div class="announce" >

                   <asp:Label runat="server" ID="Lb1" Text="Candidate" Font-Size="35px" Font-Bold="true" Font-Names="Consolas"></asp:Label><br />
                   <asp:Label runat="server" ID="Label1" Text="Management" Font-Size="35px" Font-Bold="true" Font-Names="Consolas"></asp:Label><br />
                   <asp:Label runat="server" ID="Label2" Text="System" Font-Size="35px" Font-Bold="true" Font-Names="Consolas"></asp:Label>
 
        </div>
    </div>
</asp:Content>
