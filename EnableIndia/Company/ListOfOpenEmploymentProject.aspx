<%@ Page Title="List of Open Employment Project"  Language="C#" MasterPageFile="~/Candidate/Candidate.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" Inherits="EnableIndia.Company.ListOfOpenEmploymentProject" Codebehind="ListOfOpenEmploymentProject.aspx.cs"  %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">Company Section</td>
        </tr>
        <tr>
            <td>Manage Open Employment Projects > List of Open Employment Projects</td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<div id="divMain" runat="server">

<table>
    <tr>
        <td style="width:190px">
            <label for="ctl00_ContentPlaceHolder2_DdlCompanyCode" >Select Company</label>
        </td>
        <td>
           <select id="DdlCompanyCode" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:190px">
            <label for="ctl00_ContentPlaceHolder2_DdlVacancyCode">Select Vacancy</label>
        </td>
        <td>
           <select id="DdlVacancyCode" runat="server" />
           <asp:HiddenField runat="server" id="hrtbChanged"/>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:190px">
            <label for="ctl00_ContentPlaceHolder2_DdlManagedByEmployee">Select 'Managed By'</label>
        </td>
        <td>
            <select id="DdlManagedByEmployee" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:190px">
            <label for="ctl00_ContentPlaceHolder2_TxtPossibleStartDateFrom" >Select 'Possible Start Date' from</label> 
        </td>
        <td align="left" style="width:190px">
            <asp:TextBox ID="TxtPossibleStartDateFrom" runat="server" yearlength="4" />
            <asp:ImageButton runat="server" ID="Image3" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif"  /><br style="font-size:4px;" />
            <cc1:CalendarExtender runat="server" ID="CalendarExtender3" PopupButtonID="Image3" TargetControlID="TxtPossibleStartDateFrom" Format="dd/MM/yyyy" ></cc1:CalendarExtender>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtPossibleStartDateFrom"
            ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
            runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
            DD/MM/YYYY
<%--            <cc1:MaskedEditValidator runat="server" ID="tbpstfv" ControlExtender="tbpstfe" ControlToValidate="TxtPossibleStartDateFrom" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
            <cc1:MaskedEditExtender  runat="server" ID="tbpstfe" TargetControlID="TxtPossibleStartDateFrom" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>
        </td>
        <td style="width:46px">
            <label for="ctl00_ContentPlaceHolder2_TxtPossibleStartDateTo" >To</label> 
        </td>
        <td align="left" style="width:190px">
            <asp:TextBox ID="TxtPossibleStartDateTo" runat="server" yearlength="4" />
            <asp:ImageButton runat="server" ID="Image1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif"  /><br style="font-size:4px;" />
            <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="Image1" TargetControlID="TxtPossibleStartDateTo" Format="dd/MM/yyyy" ></cc1:CalendarExtender>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtPossibleStartDateTo"
            ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
            runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
            DD/MM/YYYY
<%--            <cc1:MaskedEditValidator runat="server" ID="tbstev" ControlExtender="tbstee" ControlToValidate="TxtPossibleStartDateTo" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
            <cc1:MaskedEditExtender  runat="server" ID="tbstee" TargetControlID="TxtPossibleStartDateTo" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>           
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:190px">
            <label for="ctl00_ContentPlaceHolder2_TxtPossibleEndDateFrom" >Select 'Possible End Date' from</label> 
        </td>
        <td style="width:190px">
            <asp:TextBox ID="TxtPossibleEndDateFrom" runat="server" yearlength="4" />
            <asp:ImageButton runat="server" ID="Image2" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif"  /><br style="font-size:4px;" />
            <cc1:CalendarExtender runat="server" ID="CalendarExtender2" PopupButtonID="Image2" TargetControlID="TxtPossibleEndDateFrom" Format="dd/MM/yyyy" ></cc1:CalendarExtender>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TxtPossibleEndDateFrom"
            ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
            runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
            DD/MM/YYYY
<%--            <cc1:MaskedEditValidator runat="server" ID="tbpedfv" ControlExtender="tbpedfe" ControlToValidate="TxtPossibleEndDateFrom" ValidationExpression="^\d{2}/\d{2}/\d{4}$" ></cc1:MaskedEditValidator>
            <cc1:MaskedEditExtender  runat="server" ID="tbpedfe" TargetControlID="TxtPossibleEndDateFrom" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
--%>            
        </td>
        <td style="width:46px">
            <label for="ctl00_ContentPlaceHolder2_TxtPossibleEndDateTo">To</label> 
        </td>
        <td style="width:190px">
            <asp:TextBox ID="TxtPossibleEndDateTo" runat="server" yearlength="4"/>
            <asp:ImageButton runat="server" ID="Image4" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif"  /><br style="font-size:4px;" />
            <cc1:CalendarExtender runat="server" ID="CalendarExtender4" PopupButtonID="Image4" TargetControlID="TxtPossibleEndDateTo" Format="dd/MM/yyyy" ></cc1:CalendarExtender>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="TxtPossibleEndDateTo"
            ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
            runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
            DD/MM/YYYY
<%--            <cc1:MaskedEditValidator runat="server" ID="tbpedtv" ControlExtender="tbpedte" ControlToValidate="TxtPossibleEndDateTo" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
            <cc1:MaskedEditExtender  runat="server" ID="tbpedte" TargetControlID="TxtPossibleEndDateTo" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
--%>        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:190px">
            <label for="ctl00_ContentPlaceHolder2_DdlSelectProjectStatus">Select Project Status</label>
        </td>
        <td>
            <select id="DdlProjectStatus" runat="server">
                 <option value="All">All(Not Open + Open)</option>
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
        <td style="width:190px"></td>
        <td>
            <asp:Button ID="BtnSearch" runat="server" Text="Go" 
                OnClientClick="javascript:return GoSearchParameter();"
                OnClick="BtnSearch_Click" />
        </td>
    </tr>
</table>
</div>
<table>
<tr>
    <td>
        <asp:UpdatePanel runat="server" ID="updEmpProjects" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
        <asp:ListView ID="LstViewEmploymentProjects" runat="server"
            OnItemDataBound="LstViewEmploymentProjects_ItemDataBound" 
            onselectedindexchanged="LstViewEmploymentProjects_SelectedIndexChanged"  >
            <LayoutTemplate>
                <table>
                    <tr>
                        <th colspan="20" style="padding-top:10px;padding-bottom:10px">
                            <asp:Button id="BtnEnterEmploymentProjectCycle" runat="server" Text="Enter Employment Project Cycle"
                                OnClientClick="javascript:if(ValidateListViewForCheckedRadioButtons('TblEmploymentProjects','Please select an employment project.')==true) return ValidateProjectStatus(0);else return false;"
                                OnClick="BtnEnterEmploymentProjectCycle_Click" />&nbsp;
                            <asp:Button ID="BtnViewAssignedList" runat="server" Text="View Assigned List"
                                OnClientClick="javascript:if(ValidateListViewForCheckedRadioButtons('TblEmploymentProjects','Please select an employment project.')==true) return ValidateProjectStatus(0);else return false;"
                                OnClick="BtnViewAssignedList_Click" />
                            <asp:Button ID="BtnDeleteProject" Text="Delete Project" 
                                OnClientClick="javascript:if(ValidateListViewForCheckedRadioButtons('TblEmploymentProjects','Please select an employment project.')==true) return ValidateProjectStatus(1);else return false;"
                                runat="server" 
                                OnClick="BtnDeleteProject_Click" />
                        </th>
                    </tr>
                </table>
                <table id="TblEmploymentProjects" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" style="border-color:#808080;" border="1">
                   <thead>
                        <tr class="grid-header">
                            <th><span class="skiplink">Radio button for entering employment project cycle</span></th>
                            <th align="right">No.</th>
                            <th>Employment Project</th> 
                            <th>Current Demand</th> 
                            <th>Assigned Candidates</th> 
                            <th>Candidates marked as interview scheduled</th> 
                            <th>Candidates marked as interview process complete</th> 
                            <th>Successful Candidates (Got Job Details entered)</th> 
                            <th>Rejected Candidates</th> 
                            <th>Project Status</th>
                            <th>Managed by</th>
                            <th>Creation Date</th>
                            <th>Possible Start Date</th>
                            <th>Possible End Date</th>
                            <th>Job Type</th>
                            <th>Role Name</th>
                            <th>Parent Company</th>
                            <th>Company</th>
                            <th>Vacancy</th>
                            <th>Company City</th>
                        </tr>
                   </thead>
                   <tbody>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                   </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                   <td id="TdRadioButton">
                       <asp:RadioButton ID="RdbEmploymentProject" runat="server"  Font-Names="Consolas"  onclick="javascript:rbClicked(this);"
                            EmploymentProjectID='<%#  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("employment_project_id"))) %>'
                            CompanyID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("company_id")))%>'
                            IntStDate='<%#Eval("possible_start_date", "{0:" + EnableIndia.Global.GetDateFormat() + "}")%>'
                            intEdDate='<%#Eval("possible_end_date", "{0:" + EnableIndia.Global.GetDateFormat() + "}")%>'
                               />
                       <label id="LblEmploymentProjectName" runat="server" class="skiplink">Select <%#Eval("employment_project_name")%></label>
                   </td>
                   <td id="TdRecordNumber" align="right">
                   <td title="Employment Project : <%#Eval("employment_project_name")%>">
                        <a id="LnkEmploymentProject" class="readonlyText" runat="server"
                            href='<%# "AddEmploymentProjects.aspx?emp_proj=" + EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("employment_project_id"))) %>'><%#Eval("employment_project_name")%></a>
                   </td> 
                   <td align="right" title="<%#Eval("employment_project_name")%>'s Current Demand"><%#Eval("current_demand_of_people")%></td> 
                   <td align="right" title="<%#Eval("employment_project_name")%>'s Assigned Candidates"><%#Eval("candidates_assigned")%></td> 
                   <td align="right" title="<%#Eval("employment_project_name")%>'s Candidates marked as interview scheduled"><%#Eval("candidated_scheduled_for_interview")%></td> 
                   <td align="right" title="<%#Eval("employment_project_name")%>'s Candidates marked as interview process complete"><%#Eval("candidates_completed_interview")%></td> 
                   <td align="right" title="<%#Eval("employment_project_name")%>'s Successful Candidates (Got Job Details entered)"><%#Eval("candidates_job_details_entered")%></td> 
                   <td align="right" title="<%#Eval("employment_project_name")%>'s Rejected Candidates"><%#Eval("rejected_canidates")%></td> 
                   <td id="TdProjectStatus" title="<%#Eval("employment_project_name")%>'s Project Status"><%#Eval("project_status")%></td>
                   <td title="<%#Eval("employment_project_name")%>'s Managed by"><%#Eval("employee_name")%></td>
                   <td title="<%#Eval("employment_project_name")%>'s Creation Date"><%#Eval("project_creation_date_time","{0:" + EnableIndia.Global.GetDateFormat() + "}")%></td>
                   <td id="psd" title="<%#Eval("employment_project_name")%>'s Possible Start Date"><%#Eval("possible_start_date", "{0:" + EnableIndia.Global.GetDateFormat() + "}")%></td>
                   <td id="ped" title="<%#Eval("employment_project_name")%>'s Possible End Date"><%#Eval("possible_end_date", "{0:" + EnableIndia.Global.GetDateFormat() + "}")%></td>
                   <td title="<%#Eval("employment_project_name")%>'s Job Type"><%#Eval("job_name")%></td>
                   <td title="<%#Eval("employment_project_name")%>'s Role Name"><%#Eval("job_role_name")%></td>
                   <td title="<%#Eval("employment_project_name")%>'s Parent Company">
                        <a id="LnkParentCompany" class="readonlyText" runat="server"
                                href='<%#"AddParentCompany.aspx?par_comp=" + EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("parent_company_id"))) %>'> <%#Eval("parent_company")%> </a></td>
                   <td title="<%#Eval("employment_project_name")%>'s Company">
                        <a id="LnkBtnCompanyDetail" class="readonlyText" runat="server"
                                href='<%#"AddCompany.aspx?comp=" + EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("company_id"))) %>'> <%#Eval("company")%></a>
                   </td>
                   <td title="<%#Eval("employment_project_name")%>'s Vacancy">
                         <a id="LnkVacancies" class="readonlyText"  runat="server" VacancyID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("vacancy_id")))%>'
                                href='<%#"AddVacancy.aspx?vac=" + EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("vacancy_id"))) %>'> <%#Eval("vacancy_name")%></a>
                    </td>
                   <td title="<%#Eval("employment_project_name")%>'s Company City"><%#Eval("company_city")%></td>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </td>
</tr>
</table>
    <script language="javascript" type="text/javascript">
        function rbClicked(radio) {
            var j = 0;
            if (radio != null) {
                var dvData = document.getElementById("TblEmploymentProjects");
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
<script type="text/javascript" src="ListOfOpenEmploymentProject.js"></script>
</asp:Content>