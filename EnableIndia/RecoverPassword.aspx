<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="EnableIndia.RecoverPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recover Password</title>
    <style type="text/css">
       html
       {
         padding:0px;
         margin:0px;
         right:0px;
         top:0px;
         left:0px;
         width: 800px;
         height:600px;
         position:fixed;
         font-family: Consolas, arial, 'lucida console';
         font-size:12px;
         color:#00008B;
         margin-left:auto;
         margin-right :auto;
         overflow-y: auto;
         overflow-x: auto;
         overflow: -moz-scrollbars-vertical;
     }
         .container {
          background: transparent;
          position: absolute;
          top : 30%;
          left : 0px;
          width: 100%;
           /*height: 1px;*/
          overflow: visible;
          visibility: visible;
          display: block
        }

        .announce {
          margin-left: -200px;
          position  : absolute;
          top : -15px;
          left: 50%;
          width: 800px;
          height : 600px;
          visibility: visible
        }
        .labelRightAlign
        {
            text-align: right;
        }
     </style>
</head>
<body>
    <form id="frmRecoverPassword" runat="server">
    <div class="container">
      <div class="announce">
         <asp:PasswordRecovery runat="server" ID="pwdRecovery"
         SuccessText="Your password was successfully reset and emailed to you." Width="400px">
             <UserNameTemplate>
             <div style="display:table; border-top: 2px solid blue; border-bottom: 2px solid blue;">
                <div style="display:table-row; height:30px;">
                   <div style="display:table-cell; width:400px; text-align:center;">
                      <asp:Label CssClass="labelStyle" runat="server" ID="Label1" Text="Recover Your Password" Font-Bold="true" Font-Size="14px"></asp:Label>
                   </div>
                </div>
                <div style="display:table-row; height:50px;">
                   <div style="display:table-cell; width:400px;">
                   <asp:Label CssClass="labelStyle" runat="server" ID="lbMessage" Text="The steps below will allow you to have 
           a new password sent to the registered email address." Font-Bold="true"></asp:Label>
                   </div>
                </div>
                <div style="display:table-row; height:30px;">
                   <div style="display:table-cell; width:400px;">
                      <asp:Label CssClass="labelStyle" runat="server" ID="lbUserNameT" Text="User Name: "  Width="130px" CssClass="labelRightAlign" Font-Bold="true"></asp:Label>
                      <asp:TextBox ID="UserName" runat="server" />
                   </div>
                </div>
                <div style="display:table-row; height:30px;">
                   <div style="display:table-cell; width:400px; text-align:center;">
                        <asp:Button ID="btnSubmit"  CausesValidation="true"  ValidationGroup="PWRecovery" runat="server" OnClick="submitClick" Text="Submit" />
                   </div>
                </div>
                   <div style="display:table-cell; width:400px; height:30px; text-align:center;">
                   <asp:Label CssClass="labelStyle" runat="server" ID="lbStatus" ForeColor="#d32232"  Font-Bold="true"></asp:Label>
                   </div>
             </div>
           </UserNameTemplate>
  
         </asp:PasswordRecovery>
      </div>
    </div>
    </form>
</body>
</html>
