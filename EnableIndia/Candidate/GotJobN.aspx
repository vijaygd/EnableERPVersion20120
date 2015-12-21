<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GotJobN.aspx.cs" Inherits="EnableIndia.GotJobN" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="Telerik.ReportViewer.WebForms, Version=6.1.12.621, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" namespace="Telerik.ReportViewer.WebForms" tagprefix="telerik" %>
<%--<%@ Register TagPrefix="telerik" Assembly="Telerik.ReportViewer.WebForms" Namespace="Telerik.ReportViewer.WebForms" %>--%>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
   <head id="Head1" runat="server">
    <title>GotJob</title>
    <style type="text/css">

       html, body
       {
         padding:0px;
         margin:0px;
         right:0px;
         top:0px;
         left:0px;
         height:720px;
         position:absolute;
         font-family: Consolas, Consolas, 'lucida console';
         font-size:12pt;
         color:#00008B;
         width:100%;
         margin-left: auto;
         margin-right : auto;
         max-width: 100%;
         min-height: 720px;

       }
       .divClass
       {
           width: 1024px;
           height:700px;
           position:absolute;
           margin-left: auto;
           margin-right: auto;
       }
       .smallBr{
            font-size : 10px;
            line-height: 2; 
       }

       </style>
</head>
<body>
    <center>
    <form id="formGotJob" runat="server">
    <asp:ScriptManager runat="server" ID="scm" EnablePartialRendering="true"></asp:ScriptManager>
    <div>
       <table cellpadding="2" cellspacing="1">
           <tr>
              <td valign="middle" align="left" style="width:25%;" >
                  <asp:Label runat="server" ID="lbgbt" Text="Candidates Got Job" Font-Bold="true" Font-Size="14pt"></asp:Label>
              </td>
              <td valign="middle" align="center" style="width:25%;">
                  <asp:Label runat="server" ID="lbstdtT" Text="Start Date" Font-Bold="true"></asp:Label>
              </td>
              <td valign="middle" align="center" style="width:25%;">
                  <asp:Label runat="server" ID="Label1" Text="End Date" Font-Bold="true"></asp:Label>
              </td>
              <td valign="middle" align="center" style="width:25%;">
                 <asp:Label runat="server" ID="lbStatus" ForeColor="#D32232" Font-Bold="true"></asp:Label>
              </td>
           </tr>
           <tr>
              <td valign="middle" align="left" style="width:25%;" >
                  <asp:Label runat="server" ID="lbNoRecT" Text="No of Records: " Font-Bold="true" Font-Size="14pt"></asp:Label>
                  <asp:Label runat="server" ID="lbNoRec"></asp:Label>
              </td>
              <td  valign="middle" align="center" style="width:25%;">
                  <BDP:BDPLite runat="server" ID="dtStartDate" DateFormat="dd/MM/yyyy" TextBoxColumns="10" Font-Size="small"></BDP:BDPLite>
                  <BDP:IsDateValidator runat="server" ID="IsDateValidator3" Display="Dynamic" ErrorMessage="Please Enter Valid Date" ControlToValidate="dtStartDate"></BDP:IsDateValidator>
              </td>
             <td  valign="middle" align="center" style="width:25%;">
             <BDP:BDPLite runat="server" ID="dtEndDate" DateFormat="dd/MM/yyyy" TextBoxColumns="10" Font-Size="small"></BDP:BDPLite>
             <BDP:IsDateValidator runat="server" ID="IsDateValidator1" Display="Dynamic" ErrorMessage="Please Enter Valid Date" ControlToValidate="dtEndDate"></BDP:IsDateValidator>
              </td>
              <td valign="middle" align="left" style="width:25%;">
                         <asp:ImageButton runat="server" ID="btnQuery" ImageUrl="~/Image/QueryR.gif"  AlternateText="Query" ImageAlign="AbsMiddle" Height="30"  Width="70px"
                 onclick="btnQuery_Click" ToolTip="Get the records" />&nbsp
                         <asp:ImageButton runat="server" ID="btnReset" ImageUrl="~/Image/Reset.gif"  AlternateText="Reset" ImageAlign="AbsMiddle" Height="30"  Width="70px"
                 onclick="btnReset_Click" ToolTip="Reset to original status"  />&nbsp;
                         <asp:ImageButton runat="server" ID="btnChart" ImageUrl="~/Image/Chart.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="30"  Width="70px"
                 onclick="btnChart_Click" ToolTip="Print Chart"  />&nbsp;
                         <asp:ImageButton runat="server" ID="btnClose" ImageUrl="~/Image/Close.gif"  AlternateText="Close" ImageAlign="AbsMiddle" Height="30"  Width="70px"
                 onclick="btnClose_Click" ToolTip="Close this screen"  />&nbsp;

              </td>
            </tr>
          </table>
       <table cellpadding="2" cellspacing="1" style="width:100%;border-bottom-color:Blue; border-bottom-style:solid; border-width:2;">
           <tr>
              <td  valign="middle" align="center" style="width:15%;" >
                 <asp:Label runat="server" ID="lbSearchT" Text="Search: " Font-Bold="true" Font-Size="14px"></asp:Label>&nbsp;
              </td>
              <td valign="middle" align="left" style="width:25%;">
                 <asp:DropDownList runat="server" ID="ddOptions" OnSelectedIndexChanged="ddSelChanged" AutoPostBack="true">
                    <asp:ListItem Text="Candidate Name" Value="cn"></asp:ListItem>
                    <asp:ListItem Text="Candidate Id" Value="ci"></asp:ListItem>
                    <asp:ListItem Text="Registration Id" Value="ri"></asp:ListItem>
                    <asp:ListItem Text="Date of Join" Value="dj"></asp:ListItem>
                    <asp:ListItem Text="Placed By EI" Value="pe"></asp:ListItem>
                    <asp:ListItem Text="Placed By others" Value="po"></asp:ListItem>
                    <asp:ListItem Text="Salary" Value="sl"></asp:ListItem>
                 </asp:DropDownList>&nbsp;
                 </td>
                 <td valign="middle" align="left" style="width:60%;">
                     <asp:TextBox runat="server" ID="tbSearch" Width="180px"></asp:TextBox>
                 <asp:TextBox runat="server" ID="tbSearchIntFrom" Width="180px" Visible="false"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="filTxt" runat="server" TargetControlID="tbSearchIntFrom" FilterMode="ValidChars" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                 <asp:Label runat="server" ID="lbToTI" Text=" to " Font-Bold="true" Visible="false"></asp:Label>
                 <asp:TextBox runat="server" ID="tbSearchIntTo" Width="180px" Visible="false"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tbSearchIntTo" FilterMode="ValidChars" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                   <BDP:BDPLite runat="server" ID="dtSearch" DateFormat="dd/MM/yyyy" TextBoxColumns="10" Font-Size="small" Visible="false"></BDP:BDPLite>
                   <BDP:IsDateValidator runat="server" ID="IsDateValidator2" Display="Dynamic" ErrorMessage="Please Enter Valid Date" ControlToValidate="dtSearch"></BDP:IsDateValidator>
                   &nbsp;
                 <asp:ImageButton runat="server" ID="btnGet" ImageUrl="~/Image/Get.gif"  AlternateText="Get" ImageAlign="AbsMiddle" Height="30"  Width="70px"
                 onclick="btnGet_Click" ToolTip="Get the selected records" />&nbsp
                 </td>
            </tr>
            <tr>
               <td valign="middle" align="center" colspan="3">
                      <asp:Label runat="server" ID="lbSelection" Font-Bold="true" ForeColor="#D32232"></asp:Label>
               </td>
            </tr>
       </table>
    </div>
      <center>
      <div style="width:100%; height:540px;">
        <telerik:ReportViewer ID="tRadReport" runat="server" Width="100%" Height="540px"></telerik:ReportViewer>
     </div>
     </center>
    </form>
    </center>
</body>
</html>
