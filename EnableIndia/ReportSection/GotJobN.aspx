<%@ Page Title="" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" CodeBehind="GotJobN.aspx.cs" Inherits="EnableIndia.ReportSection.GotJobN" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
 <table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">Reports</td>
        </tr>
        <tr>
            <td>Candidates Got Job</td>
        </tr>
    </table>
  </div>
    <div>
       <table cellpadding="2" cellspacing="1">
           <tr>
              <td valign="middle" align="left" style="width:25%;" >
                  <asp:Label CssClass="labelStyle" runat="server" ID="lbgbt" Text="Candidates Got Job" Font-Bold="true" Font-Size="14pt"></asp:Label>
              </td>
              <td valign="middle" align="center" style="width:25%;">
                  <asp:Label CssClass="labelStyle" runat="server" ID="lbstdtT" Text="Start Date" Font-Bold="true"></asp:Label>
              </td>
              <td valign="middle" align="center" style="width:25%;">
                  <asp:Label CssClass="labelStyle" runat="server" ID="Label1" Text="End Date" Font-Bold="true"></asp:Label>
              </td>
              <td valign="middle" align="center" style="width:25%;">
                 <asp:Label CssClass="labelStyle" runat="server" ID="lbStatus" ForeColor="#D32232" Font-Bold="true"></asp:Label>
              </td>
          </tr>
           <tr>
              <td valign="middle" align="left" style="width:25%;" >
                  <asp:Label CssClass="labelStyle" runat="server" ID="lbNoRecT" Text="No of Records: " Font-Bold="true" Font-Size="14pt"></asp:Label>
                  <asp:Label CssClass="labelStyle" runat="server" ID="lbNoRec"></asp:Label>
              </td>
              <td  valign="middle" align="center" style="width:25%;">
                  <BDP:BasicDatePicker runat="server" ID="dtStartDate" 
                                        DateFormat="dd/MM/yyyy" Columns="1" AutoPostBack="true" 
                      WeekendDayStyle-BackColor="#ADD8E6" TextBoxColumns="10" Font-Size="Small" 
                      onselectionchanged="dtStartDate_SelectionChanged" DisplayType="TextBoxAndImage" ClientIDMode="AutoID" YearSelectorEnabled="true" ShowNoneButton="false"></BDP:BasicDatePicker>
                  <BDP:IsDateValidator runat="server" ID="IsDateValidator3" Display="Dynamic"   ErrorMessage="Please Enter Valid Date" ControlToValidate="dtStartDate"></BDP:IsDateValidator>
              </td>
              <td valign="middle" align="center" style="width:25%;">
                  <BDP:BasicDatePicker runat="server" ID="dtEndDate" 
                      DateFormat="dd/MM/yyyy" Columns="1" AutoPostBack="true" 
                      WeekendDayStyle-BackColor="#ADD8E6" TextBoxColumns="10" Font-Size="Small" 
                      onselectionchanged="dtEndDate_SelectionChanged" ClientIDMode="AutoID" DisplayType="TextBoxAndImage"></BDP:BasicDatePicker>
                  <BDP:IsDateValidator runat="server" ID="dtEndDateV" Display="Dynamic" YearSelectorEnabled="true" ShowNoneButton="false" ErrorMessage="Please Enter Valid Date" ControlToValidate="dtEndDate"></BDP:IsDateValidator>
              
              </td>
              <td valign="middle" align="left" style="width:25%;">
                         <asp:ImageButton runat="server" ID="btnQuery" ImageUrl="~/Image/QueryR.gif"  AlternateText="Query" ImageAlign="AbsMiddle" Height="20"  Width="50px"
                 onclick="btnQuery_Click" ToolTip="Get the records" />&nbsp
                         <asp:ImageButton runat="server" ID="btnReset" ImageUrl="~/Image/Reset.gif"  AlternateText="Reset" ImageAlign="AbsMiddle" Height="20"  Width="50px"
                 onclick="btnReset_Click" ToolTip="Reset to original status"  />&nbsp;
                         <asp:ImageButton runat="server" ID="btnChart" ImageUrl="~/Image/Chart.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="20"  Width="50px"
                 onclick="btnChart_Click" ToolTip="Print Chart"  />&nbsp;
                         <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="~/Image/Print.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="20"  Width="20px"
                 onclick="btnPrint_Click" ToolTip="Print In Full Page"  />&nbsp;
                         <asp:ImageButton runat="server" ID="ImageButton2" ImageUrl="~/App_Themes/Default/images/ExportToExcel.gif"  AlternateText="Export To Excel" ImageAlign="AbsMiddle" Height="20"  Width="20px"
                 onclick="btnWExportToExcel_Click" ToolTip="Export To Excel"  />&nbsp;


              </td>
            </tr>
          </table>
       <table cellpadding="2" cellspacing="1" style="width:100%;border-bottom-color:Blue; border-bottom-style:solid; border-width:2;">
           <tr>
              <td  valign="middle" align="center" style="width:15%;" >
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
                 <td valign="middle" align="left" style="width:60%;">
                     <asp:TextBox runat="server" ID="tbSearch" Width="180px"></asp:TextBox>
                 <asp:TextBox runat="server" ID="tbSearchIntFrom" Width="180px" Visible="false"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="filTxt" runat="server" TargetControlID="tbSearchIntFrom" FilterMode="ValidChars" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                 <asp:Label CssClass="labelStyle" runat="server" ID="lbToTI" Text=" to " Font-Bold="true" Visible="false"></asp:Label>
                 <asp:TextBox runat="server" ID="tbSearchIntTo" Width="180px" Visible="false"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tbSearchIntTo" FilterMode="ValidChars" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                   <BDP:BDPLite runat="server" ID="dtSearch" DateFormat="dd/MM/yyyy" TextBoxColumns="10" Font-Size="small" Visible="false"></BDP:BDPLite>
                   <BDP:IsDateValidator runat="server" ID="IsDateValidator2" Display="Dynamic" ClientIDMode="AutoID" ErrorMessage="Please Enter Valid Date" ControlToValidate="dtSearch"></BDP:IsDateValidator>
                   &nbsp;
                 <asp:ImageButton runat="server" ID="btnGet" ImageUrl="~/Image/Get.gif"  AlternateText="Get" ImageAlign="AbsMiddle" Height="24"  Width="56px"
                 onclick="btnGet_Click" ToolTip="Get the selected records" />&nbsp
                         <asp:ImageButton runat="server" ID="btnClose" ImageUrl="~/Image/Close.gif"  AlternateText="Close" ImageAlign="AbsMiddle" Height="24"  Width="56px"
                 onclick="btnClose_Click" ToolTip="Close this screen"  />
 
                 </td>
            </tr>
            <tr>
               <td valign="middle" align="center" colspan="3">
                      <asp:Label CssClass="labelStyle" runat="server" ID="lbSelection" Font-Bold="true" ForeColor="#D32232"></asp:Label>
               </td>
            </tr>
       </table>
    </div>
      <div style="width:100%; height:540px;">
        <telerik:ReportViewer ID="tRadReport" runat="server" Width="100%" Height="540px"></telerik:ReportViewer>
     </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
