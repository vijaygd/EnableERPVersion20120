<%@ Page Title="" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.ReportSection.GotJob" Codebehind="GotJob.aspx.cs" %>
<%@ Register Assembly="Stimulsoft.Report.Web, Version=2013.1.1600.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a"  Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">Reports</td>
        </tr>
        <tr>
            <td>Got Jobs</td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div>
       <table cellpadding="2" cellspacing="1">
           <tr>
              <td valign="middle" align="left" style="width:250px;" >
                  <asp:Label CssClass="labelStyle" runat="server" ID="lbgbt" Text="Candidates Got Job" Font-Bold="true" Font-Size="14pt"></asp:Label>
              </td>
              <td valign="middle" align="center" style="width:250px;">
                  <asp:Label CssClass="labelStyle" runat="server" ID="lbstdtT" Text="Start Date" Font-Bold="true"></asp:Label>
              </td>
              <td valign="middle" align="center" style="width:250px;">
                  <asp:Label CssClass="labelStyle" runat="server" ID="Label1" Text="End Date" Font-Bold="true"></asp:Label>
              </td>
              <td valign="middle" align="center" style="width:250px;">
                 <asp:Label CssClass="labelStyle" runat="server" ID="lbStatus" ForeColor="#D32232" Font-Bold="true"></asp:Label>
              </td>
           </tr>
           <tr>
              <td valign="middle" align="left" style="width:250px;" >
                  <asp:Label CssClass="labelStyle" runat="server" ID="lbNoRecT" Text="No of Records: " Font-Bold="true" Font-Size="14pt"></asp:Label>
                  <asp:Label CssClass="labelStyle" runat="server" ID="lbNoRec"></asp:Label>
              </td>
              <td  valign="middle" align="center" style="width:250px;">
                  <BDP:BDPLite runat="server" ID="dtStartDate" DateFormat="dd/MM/yyyy" ClientIDMode="AutoID" TextBoxColumns="10" Font-Size="small"></BDP:BDPLite>
                  <BDP:IsDateValidator runat="server" ID="IsDateValidator3" Display="Dynamic" ErrorMessage="Please Enter Valid Date" ControlToValidate="dtStartDate"></BDP:IsDateValidator>
              </td>
             <td  valign="middle" align="center" style="width:250px;">
             <BDP:BDPLite runat="server" ID="dtEndDate" DateFormat="dd/MM/yyyy" TextBoxColumns="10" Font-Size="small" ClientIDMode="AutoID" ></BDP:BDPLite>
             <BDP:IsDateValidator runat="server" ID="IsDateValidator1" Display="Dynamic" ErrorMessage="Please Enter Valid Date" ControlToValidate="dtEndDate"></BDP:IsDateValidator>
              </td>
              <td valign="middle" align="left" style="width:250px;">
                         <asp:Button runat="server" ID="btnQuery" Text="Query" ImageAlign="AbsMiddle" Height="30"  Width="70px"
                 onclick="btnQuery_Click" ToolTip="Get the records" />&nbsp
                         <asp:Button runat="server" ID="btnReset" Text="Reset" ImageAlign="AbsMiddle" Height="30"  Width="70px"
                 onclick="btnReset_Click" ToolTip="Reset to original status"  />
              </td>
            </tr>
          </table>
       <table cellpadding="2" cellspacing="1" style="width:1024px;border-bottom-color:Blue; border-bottom-style:solid; border-width:2;">
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
                 <cc2:FilteredTextBoxExtender ID="filTxt" runat="server" TargetControlID="tbSearchIntFrom" FilterMode="ValidChars" FilterType="Numbers"></cc2:FilteredTextBoxExtender>
                 <asp:Label CssClass="labelStyle" runat="server" ID="lbToTI" Text=" to " Font-Bold="true" Visible="false"></asp:Label>
                 <asp:TextBox runat="server" ID="tbSearchIntTo" Width="180px" Visible="false"></asp:TextBox>
                 <cc2:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tbSearchIntTo" FilterMode="ValidChars" FilterType="Numbers"></cc2:FilteredTextBoxExtender>
                   <BDP:BDPLite runat="server" ID="dtSearch" DateFormat="dd/MM/yyyy" TextBoxColumns="10" Font-Size="small" Visible="false"></BDP:BDPLite>
                   <BDP:IsDateValidator runat="server" ID="IsDateValidator2" Display="Dynamic" ErrorMessage="Please Enter Valid Date" ControlToValidate="dtSearch"></BDP:IsDateValidator>
                   &nbsp;
                 <asp:Button runat="server" ID="btnGet" Text="Get" ImageAlign="AbsMiddle" Height="30"  Width="70px"
                 onclick="btnGet_Click" ToolTip="Get the selected records" />&nbsp
                 </td>
            </tr>
            <tr>
               <td valign="middle" align="center" colspan="3">
                      <asp:Label CssClass="labelStyle" runat="server" ID="lbSelection" Font-Bold="true" ForeColor="#D32232"></asp:Label>
               </td>
            </tr>
       </table>
    </div>
    <div>
        <table>
        <tr>
            <td>
                <cc1:StiWebViewer ID="StiWebViewer1" runat="server"  RenderMode="UseCache" ViewMode="WholeReport" Height="100%" />
                
            </td>
        </tr>
    </table>

    </div>
     <div id="divforScript" class="load">
         <table width="500px" style="height:100px; border-bottom-color:Blue; border-bottom-style: solid; border-top-color: Blue; border-top-style: solid; border-width:1; background-color:White;">
         <tr>
            <td valign="middle" align="center" style="width:500px;">
                <asp:Image runat="server" ID="imbPb" AlternateText="...Wait..." ImageUrl="~/Image/ajax-loader.gif" Width="30px" Height="30px" />
           </td>
         </tr>
          <tr>
              <td valign="middle" align="center" style="width:500px;">
                <asp:Label CssClass="labelStyle" runat="server" ID="lbWaitState" Text="-: Please Wait - Report Generation under progress : -" Font-Bold="true" Font-Size="10" ForeColor="#D32232"></asp:Label>
              </td>
            </tr>
        </table>
    </div>

</asp:Content>

