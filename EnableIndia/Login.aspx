<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EnableIndia.Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes, initial-scale=1.0, maximum-scale=1.0, minimum-scale=0.1" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="cache-control" content="no-store" />
    <meta http-equiv="cache-control" content="private" />
    <meta http-equiv="cache-control" content="max-age=0, must-revalidate" />
    <meta http-equiv="expires" content="now-1" />
    <meta http-equiv="pragma" content="no-cache" />


    <title>Enable India Login</title>
    <style  type="text/css">
       html
       {
         font-family: Consolas, arial;
         font-size:11px;
         color:#00008B;
         background-repeat:repeat-x;
         background-attachment:fixed;
         background-position:center;
         overflow-y: auto;
         overflow-x: auto;
         margin:0px auto;
         max-width:1024px;
         max-height:768px;
         width:1024px;
         height:768px;
      }
    .container {
          background: transparent;
          position: absolute;
          top : 30%;
          left : 0px;
          width: 100%;
          overflow: visible;
          visibility: visible;
          display: block;
        }

        .announce {
          margin-left: -300px;
          position  : absolute;
          top : -15px;
          left: 50%;
          width: 600px;
          height : 300px;
          visibility: visible;
        }
    </style>
    <link href="~/App_Themes/Default/header.css" rel="stylesheet"  id="headerId" runat="server" type="text/css" />
</head>
<body  style="margin-top:0px;">
    <form id="formLogin" runat="server" method="post">
    <div style="height:768px; width:1024px;">
                <table border="0" style="height:94px;background-image:url(Image/topband.jpg); background-repeat: no-repeat;background-size:100% 100%; text-align:left; width:100%; border-collapse:separate; border-width:0px;">
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                </tr>
             </table>
         <div class="container">
         <div class="announce" >
        <table style="width:100%; font-family:Consolas; border-collapse:separate; border-spacing:3px; font-size:12pt; border-bottom-style:solid; border-bottom-width:2px; border-color:#00008b; border-top-style:solid; border-top-width:2px; border-top-color: #00008b;"  >
            <tr>
                <td  colspan="2" style="text-align:center; vertical-align:middle; text-align:center;">
                    <h1 style="font-size:26px; font-family:'MS PGothic'; color:darkblue;"><u>Welcome To Enable India ERP</u></h1>
                  <br />
                </td>
            </tr>
             <tr style="height:35px;">
               <td  style="width:200px;text-align:right; vertical-align:middle;">
                     <asp:Label CssClass="labelStyle"  Font-Names="Consolas" Font-Size="12pt" runat="server" ID="lbt1" Font-Bold="true" Text="User Name:" AssociatedControlID="TxtLoginName"></asp:Label>&nbsp;&nbsp&nbsp;&nbsp;
                     </td>
                <td  style="width:200px;text-align:left; vertical-align:middle;">
                   <asp:TextBox ID="TxtLoginName" runat="server" Font-Names="Consolas" Font-Size="12pt" type="text" CssClass="mandatory"  messagetext="Login name" Width="200px" /></td>
             </tr>
              <tr style="height:35px;">
                 <td  style="width:200px; text-align:right; vertical-align:middle;">
                 <asp:Label CssClass="labelStyle" Font-Names="Consolas" Font-Size="12pt" runat="server" ID="lbt2" Font-Bold="true" Text="Password:" AssociatedControlID="TxtLoginPassword"></asp:Label>&nbsp;&nbsp&nbsp;&nbsp;</td>
                 <td  style="width:200px; text-align:left; vertical-align:middle;">
                     <asp:TextBox Font-Names="Consolas" Font-Size="12pt" ID="TxtLoginPassword" runat="server" type="text" TextMode="Password" class="mandatory" messagetext="Password" Width="200px" />
                 </td>
              </tr>
             <tr style="height:35px;">
                 <td  style="width:200px; text-align:right; vertical-align:middle;" >
                   <asp:Button ID="BtnLoginName" runat="server" Font-Names="Consolas" Font-Size="12pt" Text="Login" Font-Bold="true" OnClientClick="javascript:ValidateUserDetail();"  OnClick="BtnLoginName_Click"   />&nbsp;&nbsp;&nbsp;
                  </td>
                 <td style="text-align:left; vertical-align:middle; width:200px;">
                       &nbsp;&nbsp;&nbsp;         <asp:CheckBox ID="chkRememberMe" runat="server" /><label for="chkRememberMe">Remember Me</label>
                 </td>
               </tr>
             <tr style="height:35px;">
              <td colspan="2" style="width:400px;text-align:center; vertical-align:middle;">
                  <asp:LinkButton Font-Names="Consolas" Font-Size="12pt" ID="LnkForgotPassword" Text="Forgot Password" runat="server"
                                             OnClientClick="javascript:ValidateUserName();"
                                             OnClick="LnkForgotPassword_Click" />
                  <span id="SpnMessage" runat="server" />
                            </td>
               </tr>
        <tr>
           <td colspan="2" style="text-align:center; vertical-align:middle;">

               <asp:Label CssClass="labelStyle"  runat="server"  ID="lbVersion"  Font-Bold="true" Font-Size="10" Font-Names="Consolas"></asp:Label>&nbsp;&nbsp;
           </td>
        </tr>
        <tr>
          <td>
                  <asp:TextBox ID="TextBox1" runat="server"  Width="150px" Visible="false" />
          </td>
        </tr>
        </table>
        <div runat="server" id="divtb" visible="false">
           <asp:TextBox runat="server" ID="TxLoginUserNameAndPassword" Width="150px"></asp:TextBox>
        </div>
        </div>
        </div>
        <div style="width:1024px; text-align:center; vertical-align:middle; position:fixed; bottom:0px; background-color:#003D7E;">
            <asp:Label runat="server" ForeColor="White" Font-Bold="true" Font-Names="Consolas" Font-Size="10px"  ID="lbFooterMessage" Text="Copyright © Enable India - To Empower People With Disabilities"></asp:Label>
        </div>

    </div>
    </form>
    </body>
<script src="Scripts/jquery-2.1.4.min.js"></script>
<script src="Scripts/Common.js"></script>
<script src="Login.js"></script>

</html>
