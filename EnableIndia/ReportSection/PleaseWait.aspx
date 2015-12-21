<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PleaseWait.aspx.cs" Inherits="EnableIndia.ReportSection.PleaseWait" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Please Wait</title>
        <style type="text/css">
       html, body
       {
         padding:0px;
         margin:0px;
         right:0px;
         top:0px;
         left:0px;
         width:500px;
         height=200px;
         position:absolute;
         font-family: Consolas, arial, 'lucida console';
         font-size:12px;
         color:#00008B;
         margin-left:auto;
         margin-right:auto;
         background-repeat:repeat-x;
         background-attachment:fixed;
         background-image: url(../Schema/mBackGround4.svg);
         overflow-y: auto;
         overflow-x: hidden;
       }
       </style>
</head>
<body>
    <form id="formPleaseWait" runat="server">
    <div>
       <table width="500px" style="height:200px; border-bottom-color:Blue; border-bottom-style: solid; border-top-color: Blue; border-top-style: solid; border-width:1; background-color:#91a8fe;">
        <tr>
              <td valign="middle" align="center" style="width:500px;">
                <asp:Image runat="server" ID="imbPb" AlternateText="...Wait..." ImageUrl="~/Image/pleasewait.gif" Width="30px" Height="30px" />
             </td>
       </tr>
       <tr>
            <td valign="middle" align="center" style="width:500px;">
                <asp:Label CssClass="labelStyle" runat="server" ID="lbWaitState" Text="-: Please Wait - Program Creation under progress : -" Font-Bold="true" Font-Size="10" ForeColor="#D32232"></asp:Label>
                </td>
           </tr>
      </table>
    </div>
    </form>
</body>
</html>
