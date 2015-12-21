<%@ Page Title="Add Training Project" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Training.AddTrainingProject" Codebehind="AddTrainingProject.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td colspan ="2" class="pageHeader">
            Training Section
        </td>
    </tr>
</table>
<table  cellpadding="0" cellspacing="0" class="pageHeaderLevel1">
    <tr>
        <td colspan="2">
            <asp:Label CssClass="labelStyle" ID="LblTitle" runat="server" Text="Add Training Project" MessageStartText="Add " /> 
        </td>
    </tr>
</table>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink"><%= LblTitle.Text%></span></h1>
        </td>
    </tr>
</table>
<%--<table>
    <tr>
        <td class="message" style="width:370px">
            Each instance of a Training Program is a Training Project.
            Create a Training Project for a given batch of candidates here.
            Mandatory fields are shown in capitals.
        </td>
    </tr>
</table>--%>

<table id="TblProjectName" runat="server" visible="false">
    <tr>
        <td style="width:200px">
           Name of Training Project :
        </td>
        <td>
            <span id="SpnTrainingProjectName" runat="server" class="readonlyText" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px">
           <label for="ctl00_ContentPlaceHolder2_DdlTrainingPrograms">NAME OF TRAINING PROGRAM:</label>
        </td>
        <td>
            <select id="DdlTrainingPrograms" runat="server" class="mandatory" type="select-one" messagetext="Training program" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px">
            <label for="ctl00_ContentPlaceHolder2_TxtStartDate">START DATE :</label>
        </td>
        <td>
            <asp:TextBox ID="TxtStartDate" runat="server" class="mandatory" messagetext="Start date" date="true" yearlength="4" />
            <asp:ImageButton runat="server" ID="Image1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
            <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="Image1" TargetControlID="TxtStartDate" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtStartDate"
            ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
            runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
             (DD/MM/YYYY)   

        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px">
            <label for="ctl00_ContentPlaceHolder2_TxtEndDate">END DATE :</label>
        </td>
        <td>
            <asp:TextBox ID="TxtEndDate" runat="server" class="mandatory" messagetext="End date" date="true" yearlength="4" />
            <asp:ImageButton runat="server" ID="Image2" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
            <cc1:CalendarExtender runat="server" ID="CalendarExtender2" PopupButtonID="Image2" TargetControlID="TxtEndDate" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtEndDate"
            ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
            runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
             (DD/MM/YYYY)

        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px">
            TIMINGS:
        </td>
        <td style="width:100px" >
             <label for="ctl00_ContentPlaceHolder2_TxtFromTime">From(HH:MM)</label> <br />
            <asp:TextBox ID="TxtFromTime" runat="server" class="mandatory" time="true" messagetext="From time"/>
        </td>
        <td valign="bottom" >
            <select id="DdlTimeFrom" runat="server" class="mandatory" messagetext="From clock time" title="">
                <option value="-2">Select</option>
                <option value="AM">AM</option>
                <option value="PM">PM</option>
            </select>
        </td>
        <td style="width:100px">
             <label for="ctl00_ContentPlaceHolder2_TxtToTime">To(HH:MM)</label><br />
            <asp:TextBox ID="TxtToTime" runat="server" class="mandatory" time="true"  messagetext="To time" />
           
        </td>
        <td  valign="bottom">
            <select id="DdlTimeTo" runat="server" class="mandatory" messagetext="To clock time" title="">
                <option value="-2">Select</option>
                <option value="AM">AM</option>
                <option value="PM">PM</option>
            </select>
        </td>
    </tr>
</table>
<table>
    <tr>
         <td style="width:200px">
           <label for="ctl00_ContentPlaceHolder2_TxtBatchSize">BATCH SIZE:</label>
        </td>
        <td>
            <asp:TextBox ID="TxtBatchSize" runat="server" class="mandatory" type="text" messagetext="Batch size" />
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="width:200px">
           <label for="ctl00_ContentPlaceHolder2_DdlEmployees">PROGRAM MANAGED BY:</label>
        </td>
        <td>
            <select id="DdlEmployees" runat="server" class="mandatory" type="select-one" messagetext="Employee" />
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="width:200px">
           <label for="ctl00_ContentPlaceHolder2_DdlCompanies">Credited To:</label>
        </td>
        <td>
            <telerik:RadComboBox runat="server" ID="DdlCompanies" CssClass="mandatory" CheckBoxes="true" BorderColor="#5E80FD" BorderWidth="2px" OnClientLoad="comboLoad"></telerik:RadComboBox>
<%--            <select id="DdlEmployees" runat="server" class="mandatory" type="select-one" messagetext="Employee" />--%>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="width:200px">
           <label for="ctl00_ContentPlaceHolder2_TxtVenue">Venue :</label>
        </td>
        <td>
            <asp:TextBox ID="TxtVenue" runat="server"/>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="width:200px">
           <label for="ctl00_ContentPlaceHolder2_TxtProjectDays"> Working Days :</label>
        </td>
        <td>
            <asp:TextBox ID="TxtProjectDays" runat="server"/>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="width:200px">
           <label for="ctl00_ContentPlaceHolder2_DdlProjectType">Project Category :</label>
        </td>
        <td>
            <select id="DdlProjectType" runat="server" class="mandatory" >
                <option value="-1">Select</option>
                <option value="OnLine">OnLine</option>
                <option value="OnSite">OnSite</option>
                <option value="Blended">Blended</option>
            </select>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="width:200px" valign="top">
          <h2><label for="ctl00_ContentPlaceHolder2_TxtComments">Comments:</label></h2>  
        </td>
        <td>
           <asp:TextBox ID="TxtComments" Width="350px"  class="mandatory" runat="server" TextMode="MultiLine" MaxLength="1024" Height="40px" BorderColor="#5E80FD" BorderWidth="2px"/>
        </td>
    </tr>
</table>
<%--<table id="TblProjectStatus" runat="server" >
    <tr>
        <td style="width:200px">
           <label for="ctl00_ContentPlaceHolder2_DdlProjectStatus">Project Status:</label>
        </td>
        <td>
            <select id="DdlProjectStatus" runat="server">
                <option value="Assigned">Assigned</option>
                <option value="Closed">Closed</option>
            </select>
        </td>
    </tr>
</table>--%>
<table>
    <tr>
        <td style="width:200px"></td>
        
        <td>
            <asp:Button ID="BtnManageTrainingProject" Text="Submit" runat="server" 
                OnClientClick="javascript:return ValidateRegistartionDate();" OnClick="BtnManageTrainingProject_Click" />
        </td>
        <td>
           <%-- <input id="BtnClear" type="reset"/>--%>
           <asp:Button ID="BtnClear" runat="server" Text="Clear" OnClick="BtnClear_Click"/>
        </td>
    </tr>
</table>

<script src="AddTrainingProject.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function comboLoad(sender) {
            var item = sender.get_items().getItem(0);
            checkBoxElement = item.get_checkBoxElement();
            itemParent = checkBoxElement.parentNode;
            itemParent.removeChild(checkBoxElement);
        }

    </script>
</asp:Content>

