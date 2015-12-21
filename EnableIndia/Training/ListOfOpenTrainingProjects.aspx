<%@ Page Title="List Of Open Training Projects" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Training.ListOfOpenTrainingProjects" Codebehind="ListOfOpenTrainingProjects.aspx.cs"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td colspan ="2" class="pageHeader">
            Training Section
        </td>
    </tr>
</table>
<table class="pageHeaderLevel1" cellpadding="0" cellspacing="0">
    <tr>
        <td colspan="2">
            Manage Open Training Projects >> List of Open Training Projects
        </td>
    </tr>
</table>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<%--<table>
    <tr>
        <td class="message" style="width:700px">    
            Select a Training Project using radio-button and click on the 'Enter Training Project Cycle' button below.
             <a href="javascript:More_Click();" class="message">MORE HELP...</a><br />
        </td>
    </tr>
</table>--%>
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink" style="color:White">List of Open Training Projects</span></h1>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
            <asp:Label CssClass="labelStyle" runat="server" ID="lbselProgram" Text="Select Program" AssociatedControlID="DdlSelectProgram" for="ctl00_ContentPlaceHolder2_DdlSelectProgram"></asp:Label>
        </td>
        <td>
            <select id="DdlSelectProgram" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
            <asp:Label CssClass="labelStyle" runat="server" ID="lbddlProj" AssociatedControlID="DdlSelectProjectStatus" for="ctl00_ContentPlaceHolder2_DdlSelectProjectStatus" Text="Select Project Status"></asp:Label>
        </td>
        <td>
            <select id="DdlSelectProjectStatus" runat="server">
                <option value="All">All</option>
                <option value="Not Opened">Not Opened</option>
                <option value="All Open">All Open(Unassigned + Assigned + Started + Completed)</option>
                <option value="Unassigned">Unassigned</option>
                <option value="Started">Started</option>
                <option value="Assigned">Assigned</option>
                <option value="Completed">Completed</option>
            </select>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
            <asp:Label CssClass="labelStyle" runat="server" ID="lbManagedBy" Text="Managed By" for="ctl00_ContentPlaceHolder2_DdlManagedBy" AssociatedControlID="DdlManagedBy"></asp:Label>
        </td>
        <td>
            <select id="DdlManagedBy" runat="server"/>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px" valign="top">
          <asp:Label CssClass="labelStyle" runat="server" ID="lbstartDate" Text="Date" for="ctl00_ContentPlaceHolder2_TxtStartDateFrom" AssociatedControlID="TxtStartDateFrom"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtStartDateFrom" runat="server" yearlength="4" />
            <asp:ImageButton runat="server" ID="Image1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" />
            <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="Image1" TargetControlID="TxtStartDateFrom" Format="dd/MM/yyyy"></cc1:CalendarExtender>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtStartDateFrom"
            ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
            runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
            <br/>DD/MM/YYYY

<%--             <cc1:MaskedEditValidator runat="server" ID="tdstv" ControlExtender="tdste" ControlToValidate="TxtStartDateFrom" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
             <cc1:MaskedEditExtender  runat="server" ID="tdste" TargetControlID="TxtStartDateFrom" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>
        </td>
        <td style="width:50px" align="center" valign="top">
            <asp:Label CssClass="labelStyle" runat="server" ID="lbTextStartDate" Text="To" for="ctl00_ContentPlaceHolder2_TxtStartDateTo" AssociatedControlID="TxtStartDateTo"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtStartDateTo" runat="server" yearlength="4" />
            <asp:ImageButton runat="server" ID="Image2" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif"  />
            <cc1:CalendarExtender runat="server" ID="CalendarExtender2" PopupButtonID="Image2" TargetControlID="TxtStartDateTo" Format="dd/MM/yyyy" ></cc1:CalendarExtender>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtStartDateTo"
            ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
            runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
            <br />DD/MM/YYYY
            
<%--             <cc1:MaskedEditValidator runat="server" ID="tdtov" ControlExtender="tdtoe" ControlToValidate="TxtStartDateTo" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
             <cc1:MaskedEditExtender  runat="server" ID="tdtoe" TargetControlID="TxtStartDateTo" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
        </td>
        <td>
            <asp:Button ID="BtnSearchOpenProject" Text="Go" runat="server" 
                OnClientClick="javascript:return GoSearchParameter();"
                OnClick="BtnSearchOpenProject_click" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
        </td>
        <td>
            <asp:Button ID="BtnEnterTrainingProjectCycle" Text="Enter Training Project Cycle" runat="server" Visible="false"
                OnClientClick="javascript:function rbValidate() { if(ValidateListViewForCheckedRadioButtons('TblTrainingProject','Please select atleast one Training Program.')==true) ValidateProjectStatus(0);else return false;}"
                OnClick="BtnEnterTrainingProjectCycle_Click" />
        </td>
        <td>
            <asp:Button ID="BtnViewAssignedList" Text="View Assigned List" runat="server" Visible="false"
            OnClientClick="javascript:if(ValidateListViewForCheckedRadioButtons('TblTrainingProject','Please select atleast one Training Program.')==true) ValidateProjectStatus(0);else return false;"
            OnClick="BtnViewAssignedList_Click" />
        </td>
        <td>
            <asp:Button ID="BtnDeleteProject" Text="Delete Project" 
                OnClientClick="javascript:if(ValidateListViewForCheckedRadioButtons('TblTrainingProject','Please select atleast one Training Program.')==true) ValidateProjectStatus(1);else return false;"
                runat="server" 
                OnClick="BtnDeleteProject_Click"
                Visible="false" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
            <asp:ListView ID="LstViewTrainingProject" runat="server" OnItemDataBound="LstViewTrainingProject_ItemDataBound" >
                <LayoutTemplate>
                    <table id="TblTrainingProject" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" style="border-color:#808080; border-width:1px;" 
                        summary="Training Program Details Table">
                        <thead>
                            <tr class="grid-header">
                                <th><span class="skiplink">Radio button for selecting row to update</span></th>
                                <th align="right">No.</th>
                                <th>Training Program</th>
                                <th>Training Project</th>
                                <th>Dates</th>
                                <th>Timing</th>
                                <th>Managed By</th>
                                <th>Current Status of Project</th>
                                <th>Batch Size</th>
                                <th>Number of Assigned Candidates</th>
                                <th>Number of Candidates currently marked Passed</th>
                                <th >Number of Candidates currently marked Failed</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td id="TdRadioButton">
                            <asp:RadioButton ID="RdbTrainingProject" runat="server" Font-Names="Consolas" onclick="javascript:rbClicked(this);"
                                TrainingProjectID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("training_project_id")))%>'
                                TrainingProgramID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("training_program_id")))%>' />
                                <label id="LblTrainingProgramName" runat="server" class="skiplink">Select <%#Eval("training_program_name")%></label>
                        </td>
                        <td id="TdRecordNumber" align="right">
                        </td>
                        <td>
                            <a id="LnkTrainingProgram" runat="server" href='<%#"AddTrainingProgram.aspx?prog=" + EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("training_program_id"))) %>' >
                                <%#Eval("training_program_name")%>
                            </a>
                        </td>
                        
                        <td>
                            <a id="LnkTrainingProject" runat="server" href='<%#"AddTrainingProject.aspx?proj=" + EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("training_project_id"))) %>' ><%#Eval("training_project_name")%></a>
                        </td>
                        <td>
                            <%# Eval("start_date_time") + " " + Eval("end_date_time")%>
                        </td>
                        <td>
                            <%# Eval("start_time")+" "+ Eval("end_time") %>
                        </td>                         <td><%#Eval("employee_name")%></td>
                        <td id="TdProjectStatus"><%#Eval("project_status")%></td>
                        <td><%# Eval("batch_size") %></td>
                        <td><%#Eval("candidates_assigned")%></td>

                        <td><%# Eval("total_candidates_passed")%></td>
                        <td><%# Eval("total_candidates_failed")%></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td style="padding-left:300px">
                                <span style="font-weight:bold">No Search Results</span>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </td>
    </tr>
    <asp:HiddenField runat="server" ID="hrtbChanged" />
</table>
    <script language="javascript" type="text/javascript">
        function rbClicked(radio) {
            var j = 0;
            if (radio != null) {
                var dvData = document.getElementById("TblTrainingProject");
                var inputs = dvData.getElementsByTagName("input");
                for (var i = 0; i < inputs.length; i++) {
                    var ele = inputs[i];
                    if (ele.type == "radio") {
                        if (ele.name != radio.name && ele.checked) {
                            ele.checked = false;
                            break;
                        }
                    }
                }
                radio.checked = true;
                __doPostBack();
            }
        }

    </script>
    <script src="../Scripts/jquery-2.0.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/Common.js" type="text/javascript"></script>
    <script src="ListOfOpenTrainingProjects.js" type="text/javascript"></script>
</asp:Content>

