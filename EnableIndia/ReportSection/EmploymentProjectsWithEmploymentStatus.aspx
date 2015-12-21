<%@ Page Title="Employment Projects With Employment Status" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.ReportSection.EmploymentProjectsWithEmploymentStatus" Codebehind="EmploymentProjectsWithEmploymentStatus.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Stimulsoft.Report.Web, Version=2013.1.1600.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a"
    Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">Reports</td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">
        <tr>
            <td>Employment Projects With Employment Status</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="skiplink">
        <tr>
            <td>
                <h1><span id="skipToTop" class="skiplink" style="color:White">Employment Projects With Employment Status</span></h1>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlProfilingStatus">Project Type :</label></td>
            <td>
                <select id="DdlProjectTypes" runat="server">
                    <option value="-1">All</option>
                    <option value="0">Open</option>
                    <option value="1">Closed</option>
                </select>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlEmploymentProjects">Employment Project :</label></td>
            <td>
                <select id="DdlEmploymentProjects" runat="server" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px">Start Date Of Employment Project :</td>             
            <td>From :</td>
            <td>
                <asp:TextBox ID="TxtEmploymentStartFromDate" runat="server" yearlength="4" />
                <asp:ImageButton runat="server" ID="ImageButton3" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender3" PopupButtonID="ImageButton3" TargetControlID="TxtEmploymentStartFromDate" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtEmploymentStartFromDate"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                (dd/mm/yyyy)
<%--                <cc1:MaskedEditValidator runat="server" ID="tbepfv" ControlExtender="tbepfe" ControlToValidate="TxtEmploymentStartFromDate" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tbepfe" TargetControlID="TxtEmploymentStartFromDate" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>
            </td>
            <td> <label for="ctl00_ContentPlaceHolder2_TxtEmploymentStartFromDate" class="skiplink">Start Date Of Employment Project : From</label></td>
            <td><label for="ctl00_ContentPlaceHolder2_TxtEmploymentStartToDate">To :</label></td>
            <td>
                <asp:TextBox ID="TxtEmploymentStartToDate" runat="server" yearlength="4" />
                <asp:ImageButton runat="server" ID="ImageButton4" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender4" PopupButtonID="ImageButton4" TargetControlID="TxtEmploymentStartToDate" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtEmploymentStartToDate"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                (dd/mm/yyyy)
<%--               <cc1:MaskedEditValidator runat="server" ID="tbeptv" ControlExtender="tbepte" ControlToValidate="TxtEmploymentStartToDate" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tbepte" TargetControlID="TxtEmploymentStartToDate" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>            </td>
        </tr>
    </table>
     <table>
        <tr>
            <td style="width:135px">End Date Of Employment Project :</td>             
            <td>From :</td>
            <td>
                <asp:TextBox ID="TxtEmploymentEndFromDate" runat="server" yearlength="4" />
                <asp:ImageButton runat="server" ID="ImageButton1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="ImageButton1" TargetControlID="TxtEmploymentEndFromDate" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TxtEmploymentEndFromDate"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                (dd/mm/yyyy)
<%--                <cc1:MaskedEditValidator runat="server" ID="tbEmpDtfv" ControlExtender="tbEmpDtfe" ControlToValidate="TxtEmploymentEndFromDate" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tbEmpDtfe" TargetControlID="TxtEmploymentEndFromDate" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>  
            </td>
            <td> <label for="ctl00_ContentPlaceHolder2_TxtEmploymentEndFromDate" class="skiplink">End Date Of Employment Project : From</label></td>
            <td><label for="ctl00_ContentPlaceHolder2_TxtEmploymentEndToDate">To :</label></td>
            <td>
                <asp:TextBox ID="TxtEmploymentEndToDate" runat="server" yearlength="4" />
                <asp:ImageButton runat="server" ID="ImageButton2" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender2" PopupButtonID="ImageButton2" TargetControlID="TxtEmploymentEndToDate" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="TxtEmploymentEndToDate"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                (dd/mm/yyyy)
<%--                 <cc1:MaskedEditValidator runat="server" ID="tbEmpDttv" ControlExtender="tbEmpDtte" ControlToValidate="TxtEmploymentEndToDate" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tbEmpDtte" TargetControlID="TxtEmploymentEndToDate" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>     </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlVacancies">Vacancy :</label></td>
            <td>
                <select id="DdlVacancies" runat="server" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px;"><label for="ctl00_ContentPlaceHolder2_DdlJobType">Job Type :</label></td>
            <td>
                <select id="DdlJobType" runat="server" 
                onchange="javascript:DdlJobType_SelectIndexChanged(this.value,'JobID','DdlRole','DdlHiddenRole');" />
            </td>
             <td id="TdRole" style="width:150px;padding-left:30px">
                <label for="ctl00_ContentPlaceHolder2_DdlRole">Roles :</label>
            </td>
            <td>
            <select id="DdlRole" runat="server"
                onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHiddenRole').val($('#ctl00_ContentPlaceHolder2_DdlRole').val());" />
            </td>
            <td style="display:none"  >
                <label for="ctl00_ContentPlaceHolder2_DdlHiddenRole">Hidden role</label>
                <select id="DdlHiddenRole" runat="server"/>
                <label for="ctl00_ContentPlaceHolder2_TxtHiddenRole">Hidden role</label>
                <asp:TextBox ID="TxtHiddenRole" runat="server" />
            </td>
        </tr>
     </table>
     <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlGroups">Groups :</label></td>
            <td>
                <select id="DdlGroups" runat="server" />
            </td>
        </tr>
     </table>
     <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlCompanies">Company :</label></td>
            <td>
                <select id="DdlCompanies" runat="server" />
            </td>
        </tr>
     </table>
     <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlStates">States :</label></td>
            <td>
                <select id="DdlStates" runat="server" 
                onchange="javascript:DdlStates_SelectIndexChanged(this.value,'StateID','DdlCity','DdlHiddenCity');" />
            </td>
            <td id="TdCity" style="width:150px;padding-left:30px">
                <label for="ct100_ContentPlaceHolder2_DdlCity">City :</label>
            </td>
            <td>
                <select id="DdlCity" runat="server"
                     onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHiddenCity').val($('#ctl00_ContentPlaceHolder2_DdlCity').val());"
                     />
            </td>
             <td style="display:none"  >
                <label for="ctl00_ContentPlaceHolder2_DdlHiddenCity">Hidden city</label>
                <select id="DdlHiddenCity" runat="server"/>
                <label for="ctl00_ContentPlaceHolder2_TxtHiddenCity">Hidden city</label>
                <asp:TextBox ID="TxtHiddenCity" runat="server" />
            </td>
        </tr>
     </table>
     <table>
        <tr>
            <td>
                <asp:Button ID="BtnGenerateReport" runat="server" Text="Generate" OnClick="BtnGenerateReport_Click" />
              &nbsp;&nbsp;
              <asp:ImageButton runat="server" ID="ImageButton5" ImageUrl="~/App_Themes/Default/images/ExportToExcel.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="20"  Width="20px"
                 onclick="btnExportToExcel_Click" ToolTip="Export To Excel Directly"  />
            </td>
        </tr>
    </table>
    <table>
        <tr>
             <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_TxtEmploymentProjectName">View Employment Project :</label></td>
             <td><asp:TextBox ID="TxtEmploymentProjectName" runat="server"></asp:TextBox></td>
             <td><asp:Button ID="BtnGenrateCandidateDetail" runat="server" Text="Go" OnClientClick="javascript:return GoRegistrationDetail();"  /></td>
        </tr>
    </table>
    <table>
        <tr>
             <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_TxtEmploymentProjectNameForAssignedList">View Assigned List of Closed Employment Project :</label></td>
             <td><asp:TextBox ID="TxtEmploymentProjectNameForAssignedList" runat="server"></asp:TextBox></td>
             <td><asp:Button ID="BtnGenrateDetail" runat="server" Text="Go" OnClientClick="javascript:return GoAssignListDetail();"  />


             </td>&nbsp;&nbsp;


        </tr>
    </table>
     <table>
        <tr>
            <td>
                <cc1:StiWebViewer ID="StiWebViewer1" runat="server" RenderMode="UseCache" ViewMode="WholeReport"
                   Height="100%" />
            </td>
        </tr>
    </table>
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

    <script src="EmploymentProjectsWithEmploymentStatus.js" type="text/javascript"></script>
</asp:Content>

