<%@ Page Title="" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" CodeBehind="PlacementsN.aspx.cs" Inherits="EnableIndia.ReportSection.PlacementsN" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
       <table cellpadding="2" cellspacing="0"  style="width:1024px;">
           <tr>
              <td valign="middle" align="left" style="width:22%;" >
                  <asp:Label CssClass="labelStyle" runat="server" ID="lbgbt" Text="Candidates Placed" Font-Bold="true" Font-Size="14pt"></asp:Label>
              </td>
              <td valign="middle" align="center" style="width:22%;">
                  <asp:Label CssClass="labelStyle" runat="server" ID="lbstdtT" Text="Start Date" Font-Bold="true"></asp:Label>
              </td>
              <td valign="middle" align="center" style="width:22%;">
                  <asp:Label CssClass="labelStyle" runat="server" ID="Label1" Text="End Date" Font-Bold="true"></asp:Label>
              </td>
              <td valign="middle" align="center" style="width:34%;">
                 <asp:Label CssClass="labelStyle" runat="server" ID="lbStatus" ForeColor="#D32232" Font-Bold="true"></asp:Label>
              </td>
           </tr>
           <tr>
              <td valign="middle" align="left" style="width:22%;" >
                  <asp:Label CssClass="labelStyle" runat="server" ID="lbNoRecT" Text="No of Records: " Font-Bold="true" Font-Size="14pt"></asp:Label>
                  <asp:Label CssClass="labelStyle" runat="server" ID="lbNoRec"></asp:Label>
              </td>
              <td  valign="middle" align="center" style="width:22%;">
                  <BDP:BasicDatePicker runat="server" ID="dtStartDate" DateFormat="dd/MM/yyyy" ClientIDMode="AutoID" TextBoxColumns="10" Font-Size="small" YearSelectorEnabled="true" ShowNoneButton="false"></BDP:BasicDatePicker>
                  <BDP:IsDateValidator runat="server" ID="IsDateValidator3" Display="Dynamic" ErrorMessage="Please Enter Valid Date" ControlToValidate="dtStartDate"></BDP:IsDateValidator>
              </td>
             <td  valign="middle" align="center" style="width:22%;">
             <BDP:BasicDatePicker  runat="server" ID="dtEndDate" DateFormat="dd/MM/yyyy" ClientIDMode="AutoID" TextBoxColumns="10" Font-Size="small" YearSelectorEnabled="true" ShowNoneButton="false"></BDP:BasicDatePicker>
             <BDP:IsDateValidator runat="server" ID="IsDateValidator1" Display="Dynamic" ErrorMessage="Please Enter Valid Date" ControlToValidate="dtEndDate"></BDP:IsDateValidator>
              </td>
              <td valign="middle" align="left" style="width:34%;">
                         <asp:ImageButton runat="server" ID="btnQuery" ImageUrl="~/Image/QueryR.gif"  AlternateText="Query" ImageAlign="AbsMiddle" Height="24"  Width="56px"
                 onclick="btnQuery_Click" ToolTip="Get the records" />&nbsp
                         <asp:ImageButton runat="server" ID="btnReset" ImageUrl="~/Image/Reset.gif"  AlternateText="Reset" ImageAlign="AbsMiddle" Height="24"  Width="56px"
                 onclick="btnReset_Click" ToolTip="Reset to original status"  />&nbsp;
                          <asp:ImageButton runat="server" ID="btnChart" ImageUrl="~/Image/Chart.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="24"  Width="56px"
                 onclick="btnChart_Click" ToolTip="Print Chart"  />&nbsp;
                        <asp:ImageButton runat="server" ID="ImageButton2" ImageUrl="~/Image/Print.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="20"  Width="20px"
                 onclick="btnPrint_Click" ToolTip="Print In Full Page"  />&nbsp;
                        <asp:ImageButton runat="server" ID="ImageButton3" ImageUrl="~/App_Themes/Default/images/ExportToExcel.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="20"  Width="20px"
                 onclick="btnExportToExce_Click" ToolTip="Export To Excel Directly"  />&nbsp;


              </td>
            </tr>
          </table>
       <table cellpadding="2" cellspacing="0" style="width:1024px;">
           <tr>
              <td  valign="middle" align="center" style="width:25%;" >
                 <asp:Label CssClass="labelStyle" runat="server" ID="lbSearchT" Text="Search: " Font-Bold="true" Font-Size="14px"></asp:Label>&nbsp;
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
                 <td valign="middle" align="left" style="width:50%;">
                     <asp:TextBox runat="server" ID="tbSearch" Width="180px"></asp:TextBox>
                 <asp:TextBox runat="server" ID="tbSearchIntFrom" Width="180px" Visible="false"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="filTxt" runat="server" TargetControlID="tbSearchIntFrom" FilterMode="ValidChars" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                 <asp:Label CssClass="labelStyle" runat="server" ID="lbToTI" Text=" to " Font-Bold="true" Visible="false"></asp:Label>
                 <asp:TextBox runat="server" ID="tbSearchIntTo" Width="180px" Visible="false"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tbSearchIntTo" FilterMode="ValidChars" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                   <BDP:BDPLite runat="server" ID="dtSearch" DateFormat="dd/MM/yyyy" TextBoxColumns="10" Font-Size="small" Visible="false"></BDP:BDPLite>
                   <BDP:IsDateValidator runat="server" ID="IsDateValidator2" Display="Dynamic" ClientIDMode="AutoID" ErrorMessage="Please Enter Valid Date" ControlToValidate="dtSearch"></BDP:IsDateValidator>
                   &nbsp;
                 <asp:ImageButton runat="server" ID="btnGet" ImageUrl="~/Image/Get.gif"  AlternateText="Get" ImageAlign="AbsMiddle" Height="24px"  Width="56px"
                 onclick="btnGet_Click" ToolTip="Get the selected records" />&nbsp
                  <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="~/Image/Close.gif"  AlternateText="Close" ImageAlign="AbsMiddle" Height="24px"  Width="56px"
                 onclick="btnClose_Click" ToolTip="Reset to original status"  />&nbsp;
                 </td>
            </tr>
            <tr>
               <td valign="middle" align="center" colspan="3">
                      <asp:Label CssClass="labelStyle" runat="server" ID="lbSelection" Font-Bold="true" ForeColor="#D32232"></asp:Label>
               </td>
            </tr>
       </table>
    </div>
      <center>
      <div style="width:100%; height:580px;border-bottom-color:Blue; border-bottom-style:solid; border-width:1; border-top-color:Blue; border-top-style:solid;">
        <telerik:ReportViewer ID="tRadReport" runat="server" Width="100%" Height="540px"></telerik:ReportViewer>
     </div>
     </center>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
