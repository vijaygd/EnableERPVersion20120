<%@ Page Title="" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" CodeBehind="tRptAllRegisteredCandidates.aspx.cs" Inherits="EnableIndia.ReportSection.tRptAllRegisteredCandidates" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">Reports</td>
        </tr>
    </table>
    
    <table cellpadding="0" cellspacing="0"  class="pageHeaderLevel1">
        <tr>
            <td>All Active Registered Candidate</td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManagerProxy runat="server" ID="sproxy1">
</asp:ScriptManagerProxy>
    <table cellpadding="0" cellspacing="0" class="skiplink">
        <tr>
            <td>
                <h1><span id="skipToTop" class="skiplink" style="color:White">All Active Registered Candidate</span></h1>
            </td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td style="width:135px">
                <label for="ctl00_ContentPlaceHolder2_DdlQualification">Qualification</label>
            </td>
            <td>
                <select id="DdlQualification" runat="server" />
                <input type="text" id="TxtCandidateID" runat="server" style="display:none" />
            </td>
        </tr>
    </table>
        
    <table>
        <tr>
            <td style="width:135px;"><label for="ctl00_ContentPlaceHolder2_DdlProfilingStatus">Profiling Status :</label></td>
            <td>
                <select id="DdlProfilingStatus" runat="server">
                    <option value="All">All</option>
                    <option value="To be Profiled">To be Profiled</option>
                    <option value="Profiled">Profiled</option>
                </select>
            </td>
        </tr>
    </table>
        
    <table>
        <tr>
            <td style="width:135px;"><label for="ctl00_ContentPlaceHolder2_DdlTypeOfCandidate">Type of Candidates :</label></td>
            <td>
                <select id="DdlTypeOfCandidate" runat="server">
                    <option value="-1">All</option>
                    <option value="1">Unemployed</option>
                    <option value="2">Employed</option>
                    <option value="3">Priority</option>
                    <option value="4">Needy</option>
                    <option value="5">Ready for employment</option>
                </select>
            </td>
        </tr>
    </table>
   
    <table>
        <tr>
            <td style="width:135px;"><label for="ctl00_ContentPlaceHolder2_DdlAssignment">Assignment :</label></td>
            <td>
                <select id="DdlAssignment" runat="server">
                    <option value="All">All</option>
                    <option value="Assign_train">Assigned to Training Project</option>
                    <option value="Unassign_train">Unassigned to any Training Project</option>
                    <option value="Assign_emp_proj">Assigned to Employment Project</option>
                    <option value="Unassign_emp_proj">Unassigned to any Employment Project</option>
                    <option value="Assign_both">Assigned to both Training and Employment Project</option>
                    <option value="unassign_both">Unassigned to both Training and Employment Project</option>
                </select>
            </td>
        </tr>
     </table>
    
    <table>
        <tr>
            <td  style ="width:135px">
                <label for="ctl00_ContentPlaceHolder2_DdlState">State:</label>
            </td>
            <td>
                <select id="DdlState" runat="server"
                    onchange="javascript:DdlState_SelectIndexChanged(this.value,'StateID','DdlCities','DdlHiddenCity');" />
            </td>
            <td id="TdCity"  style ="padding-left:10px">
                <label for="ctl00_ContentPlaceHolder2_DdlCities">City:</label>
            </td>
            <td>
                <select id="DdlCities" runat="server"
                    onchange="javascript:$('#TxtHidddenCity').val($('#DdlCities').val());" onclick="return DdlCities_onclick()">
                </select>
            </td>
            <td style="display:none" >
                <label for="ctl00_ContentPlaceHolder2_DdlHiddenCity">hidden City</label>
                    <select id="DdlHiddenCity" runat="server" />
                    
              <label for="ctl00_ContentPlaceHolder2_TxtHidddenCity">hidden City</label>
                <asp:TextBox ID="TxtHidddenCity" runat="server" />
            </td>
        </tr>
    </table>

     <table>
        <tr>
            <td style="width:135px;"><label for="ctl00_ContentPlaceHolder2_DdlAgeGroups">Age(Years) :</label></td>
            <td>
                <select id="DdlAgeGroups" runat="server" />
            </td>
             <td align="left" valign="middle" style="height: 35px;">
             &nbsp;&nbsp;
                <asp:Label CssClass="labelStyle" runat="server" ID="lbContExpDateT" Text="Contract Expiry Date: " Font-Bold="true" AssociatedControlID="DdlContExpDate"></asp:Label>
                <asp:DropDownList runat="server" ID="DdlContExpDate">
                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                    <asp:ListItem Text="With Dates only" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>

        </tr>
     </table>
     
     <table>
        <tr>
            <td style="width:135px;"><label for="ctl00_ContentPlaceHolder2_DdlNGOs">Ngo :</label></td>
            <td>
                <select id="DdlNGOs" runat="server" />
            </td>
        </tr>
     </table>
     
     <table>
        <tr>
            <td style="width:135px">
                <label for="ctl00_ContentPlaceHolder2_DdlDisabilityTypes">Disability :</label>
            </td>
            <td>
                <select ID="DdlDisabilityTypes" runat="server" 
                   onchange="javascript:DdlDisabilityTypes_SelectedIndexChanged(this.value,'DisabilityTypeID','DdlDisabilitySubType','DdlHiddenDisabilitySubType');" />
            </td>
            <td id="TdDisabilitySubType" style="width:150px;padding-left:30px">
                <label for="ct100_ContentPlaceHolder2_DdlDisabilitySubType">Disability Sub Type</label>
            </td>
            <td>
                <select id="DdlDisabilitySubType" runat="server"
                    onchange="javascript:$('#ct100_ContentPlaceHolder2_TxtHiddenDisabilitySubType').val($('#ct100_ContentPlaceHolder2_DdlDisabilitySubType').val());" />
            </td>
            <td style="display:none">
                <label for="ct100_ContentPlaceHolder_DdlHiddenDisabilitySubType">Hidden Disability Type</label>
                <select id="DdlHiddenDisabilitySubType" runat="server"></select>
                <label for="ct100_ContentPlaceHolder_TxtHiddenDisabilitySubType">Hidden Disability Type</label>
                <asp:TextBox ID="TxtHiddenDisabilitySubType" runat="server"></asp:TextBox>
                <span id="SpnHiddenDisabilityType" runat="server"></span>
            </td>
        </tr>
     </table>
     
    <table>
        <tr>
            <td style="width:135px">
                <label for="ctl00_ContentPlaceHolder2_DdlRecommendedJobType">Job Type</label>
            </td>
            <td>
                <select id="DdlRecommendedJobType" runat="server" 
                    onchange="javascript:DdlRecommendedJobType_SelectIndexChanged(this.value,'JobID','DdlRecommendedRole','DdlHiddenRecommendedRole');" />
            </td>
            <td id="TdRecomendedRole" style="width:150px;padding-left:30px">
                <label for="ctl00_ContentPlaceHolder2_DdlRecommendedRole">Recommended Role</label>
            </td>
            <td>
                <select id="DdlRecommendedRole" runat="server"
                    onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHiddenRecommendedRole').val($('#ctl00_ContentPlaceHolder2_DdlRecommendedRole').val());" />
            </td>
            <td style="display:none">
                <label for="ctl00_ContentPlaceHolder2_DdlHiddenRecommendedRole">Hidden Rcommeded role</label>
                <select id="DdlHiddenRecommendedRole" runat="server"/>
                <label for="ctl00_ContentPlaceHolder2_TxtHiddenRecommendedRole">Hidden Rcommeded role</label>
                <asp:TextBox ID="TxtHiddenRecommendedRole" runat="server" />
                <span id="SpnHiddenRecommendedRole" runat="server"></span>
            </td>
        </tr>
    </table>
     
     <table>
        <tr>
            <td style="width:135px;"><label for="ctl00_ContentPlaceHolder2_DdlMissingData">Missing data in Profile :</label></td>
            <td>
                <select id="DdlMissingData" runat="server">
                    <option value="All">All</option>
                    <option value="phone_number_secondary">Phone number(Secondary)</option>
                    <option value="email_address">E-mail</option>
                    <option value="all_relevant_documents_submitted">All relevant documents submitted</option>
                    <option value="martial_status">Marital Status</option>
                    <option value="Biodata_HardCopy">Biodata Hardcopy</option>
                    <option value="Biodata_SoftCopy">Biodata Softcopy</option>
                    <option value="joining_from_signed">Joining Form signed</option>
                    <option value="join_from_types">Joining Form Types</option>
                    <option value="photograph">Photograph</option>
                    <option value="course/qualification">Course/Qualifications</option>
                    <option value="work_experience">Work Experience</option>
                    <option value="knowlwdge_training">Computer Knowledge</option>
                    <option value="languages_known">Languages Known</option>
                    <option value="other_communacation_skill">Other Communication skills</option>
                    <option value="need_based_training/counseling">Need-based training/counseling administered</option>
                    <option value="candidate_empolyeble_without_training">Candidate is employable without training</option>
                    <option value="Recomended_training">Recommended Training</option>
                    <option value="recommended_job_type">Recommended Job Types</option>
                    <option value="recommended_role">Recommended Roles</option>
                    <option value="prefered_job_candidates">Preferred Job By Candidates</option>
                    <option value="Preferred_Location">Preferred Location</option>
                    <option value="Expected_Monthly_Salary">Expected Monthly Salary</option>
                    <option value="groups">Groups</option>
                    <option value="contract_expiry_date">Contract Expiry Date</option>
                    <option value="candidate_id_at_ngo">Candidate's ID at NGO (for other NGO candidates)</option>
                    <option value="file_number">File Number</option>
                     <option value="disability_sub_type">Disability sub type</option>
                </select>
            </td>
        </tr>
      </table>
      <table>
        <tr>
            <td style="width:135px">
                <label for="ctl00_ContentPlaceHolder2_DdlGroups">Groups</label>
            </td>
            <td>
                <select id="DdlGroups" runat="server">
                    
                </select>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px">
                <label for="ctl00_ContentPlaceHolder2_DdlLanguage">Language</label>
            </td>
            <td>
                <select id="DdlLanguage" runat="server"/>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px;"><label for="ctl00_ContentPlaceHolder2_DdlGender">Gender</label></td>
            <td>
                <select id="DdlGender" runat="server">
                    <option value="All">All</option>
                    <option value="Male">Male</option>
                    <option value="Female">Female</option>
                </select>
            </td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td style="width:135px;"><label for="ctl00_ContentPlaceHolder2_DdlCompanies">Company</label></td>
            <td>
                <select id="DdlCompanies" runat="server"/>
            </td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td style="width:135px;"><label for="ctl00_ContentPlaceHolder2_TxtDateOfBirth">Date Of Birth :</label></td>
            <td><asp:TextBox ID="TxtDateOfBirth" runat="server" yearlength="4"></asp:TextBox>
                <asp:ImageButton runat="server" ID="Image7" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender7" PopupButtonID="Image7" TargetControlID="TxtDateOfBirth" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtDateOfBirth"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
            </td>
        </tr>
    </table>
    
    <table group="SearchParameters">
        <tr>
            <td style="width:135px">
                <label for="ctl00_ContentPlaceHolder2_TxtSearchFor">Search for</label>
            </td>
            <td style="padding-right:30px">
                <asp:TextBox ID="TxtSearchFor" runat="server" Width="200px" ToolTip="Search For" />
            </td>
            <td>
                <label for="ctl00_ContentPlaceHolder2_DdlSearchIn">in</label>
            </td>
            <td>
                <select id="DdlSearchIn" runat="server" title="Serach In">
                    <option value="name">Name</option>
                    <option selected="selected" value="registration_id">RID</option>
                </select>
            </td>
        </tr>
    </table >                
    
    <table>
        <tr>
            <td style="width:135px">Salary (Monthly)</td>
            <td>
                From
            </td>
            <td>
                <asp:TextBox ID="TxtSalaryFrom" runat="server"></asp:TextBox><br />
<%--               <cc1:MaskedEditValidator runat="server" ID="tbSalFv" ControlExtender="tbSalFe"  ControlToValidate="TxtSalaryFrom"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tbSalFe" TargetControlID="TxtSalaryFrom" InputDirection="RightToLeft" ClearMaskOnLostFocus="True" Enabled="True" Mask="99999999" MaskType="Number" ></cc1:MaskedEditExtender>
--%>           </td>
            <td> <label for="ctl00_ContentPlaceHolder2_TxtSalaryFrom" class="skiplink">Salary  from</label></td>
             <td>
                <label for="ctl00_ContentPlaceHolder2_TxtSalaryTo">To</label>
            </td>
             <td>
                <asp:TextBox ID="TxtSalaryTo" runat="server"></asp:TextBox><br />
<%--                <cc1:MaskedEditValidator runat="server" ID="tbSalTv" ControlExtender="tbSalTe" ControlToValidate="TxtSalaryTo"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tbSalTe" TargetControlID="TxtSalaryTo" InputDirection="RightToLeft" ClearMaskOnLostFocus="True" Enabled="True" Mask="99999999" MaskType="Number" ></cc1:MaskedEditExtender>
--%>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px;">Registration Date</td>
            <td>
                From
            </td>
            <td>
                <asp:TextBox ID="TxtRegistrationFrom" runat="server" yearlength="4"></asp:TextBox>
                <asp:ImageButton runat="server" ID="Image1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                 <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="Image1" TargetControlID="TxtRegistrationFrom" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtRegistrationFrom"
                 ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                 runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                 <br />
                  (dd/mm/yyyy)
<%--                <cc1:MaskedEditValidator runat="server" ID="tbrfv" ControlExtender="tbrfe" ControlToValidate="TxtRegistrationFrom" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tbrfe" TargetControlID="TxtRegistrationFrom" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>
            </td>
            <td valign="middle"><label for="ctl00_ContentPlaceHolder2_TxtRegistrationFrom" class="skiplink">Registration Date from</label></td>
            <td valign="middle"><label for="ctl00_ContentPlaceHolder2_TxtRegistrationTo">To</label></td>
             <td>
                <asp:TextBox ID="TxtRegistrationTo" runat="server" yearlength="4"></asp:TextBox>
                   <asp:ImageButton runat="server" ID="Image2" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                   <cc1:CalendarExtender runat="server" ID="CalendarExtender2" PopupButtonID="Image2"  TargetControlID="TxtRegistrationTo" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TxtRegistrationTo"
                   ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                   runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                (dd/mm/yyyy)
<%--                <cc1:MaskedEditValidator runat="server" ID="tbrtv" ControlExtender="tbrte" ControlToValidate="TxtRegistrationTo" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tbrte" TargetControlID="TxtRegistrationTo" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>            </td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td valign="middle" style="width:160px">Employment Project through which candidate got job:</td>
            <td valign="middle">Start Date</td>
            <td valign="middle">From</td>
            <td valign="middle">
                <asp:TextBox ID="TxtEmployementProjectStartDateFrom" runat="server" yearlength="4"></asp:TextBox>
                <asp:ImageButton runat="server" ID="Image3" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender3" PopupButtonID="Image3" TargetControlID="TxtEmployementProjectStartDateFrom" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="TxtEmployementProjectStartDateFrom"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                  (dd/mm/yyyy)
<%--                <cc1:MaskedEditValidator runat="server" ID="tbepfv" ControlExtender="tbepfe" ControlToValidate="TxtEmployementProjectStartDateFrom" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tbepfe" TargetControlID="TxtEmployementProjectStartDateFrom" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>            </td>
            <td valign="middle"><label for="ctl00_ContentPlaceHolder2_TxtEmployementProjectStartDateFrom" class="skiplink">Start Date from</label></td>
            <td valign="middle">
                <label for="ctl00_ContentPlaceHolder2_TxtEmployementProjectStartDateTo">To</label>
            </td>
             <td valign="middle">
                <asp:TextBox ID="TxtEmployementProjectStartDateTo" runat="server" yearlength="4"></asp:TextBox>
                <asp:ImageButton runat="server" ID="Image4" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender4" PopupButtonID="Image4" TargetControlID="TxtEmployementProjectStartDateTo" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="TxtEmployementProjectStartDateTo"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                (dd/mm/yyyy)
<%--                <cc1:MaskedEditValidator runat="server" ID="tbeptv" ControlExtender="tbepte" ControlToValidate="TxtEmployementProjectStartDateTo" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tbepte" TargetControlID="TxtEmployementProjectStartDateTo" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>            </td>
      
            <td valign="middle" style="width:135px;">End Date</td>
            <td valign="middle">From</td>
            <td valign="middle">
                <asp:TextBox ID="TxtEmploymentEndDateFrom" runat="server" yearlength="4"></asp:TextBox>
                <asp:ImageButton runat="server" ID="Image5" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender5" PopupButtonID="Image5" TargetControlID="TxtEmploymentEndDateFrom" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="TxtEmploymentEndDateFrom"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                  (dd/mm/yyyy)
<%--                <cc1:MaskedEditValidator runat="server" ID="tbEmpDtfv" ControlExtender="tbEmpDtfe" ControlToValidate="TxtEmploymentEndDateFrom" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tbEmpDtfe" TargetControlID="TxtEmploymentEndDateFrom" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>            </td>
            <td valign="middle"> <label for="ctl00_ContentPlaceHolder2_TxtEmploymentEndDateFrom" class="skiplink">End Date from</label></td>
             <td valign="middle">
                <label for="ctl00_ContentPlaceHolder2_TxtEmploymentEndDateTo">To</label>
            </td>
            <td valign="middle">
                <asp:TextBox ID="TxtEmploymentEndDateTo" runat="server" yearlength="4"></asp:TextBox>
                <asp:ImageButton runat="server" ID="Image6" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender6" PopupButtonID="Image6" TargetControlID="TxtEmploymentEndDateTo" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="TxtEmploymentEndDateTo"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                  (dd/mm/yyyy)
<%--                <cc1:MaskedEditValidator runat="server" ID="tbEmpDttv" ControlExtender="tbEmpDtte" ControlToValidate="TxtEmploymentEndDateTo" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tbEmpDtte" TargetControlID="TxtEmploymentEndDateTo" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px;"></td>
            <td>
              <div>
                 <asp:Button runat="server" ID="btnRefresh" Width="10px" Height="10px"  CssClass="btnHide" />
                <asp:Button ID="BtnGenerateReport" runat="server" Text="Generate" 
                    OnClientClick="javascript: return GoSearchParameter();" OnClick="BtnGenerateReport_Click"  />&nbsp;&nbsp;
                 <asp:ImageButton runat="server" ID="ImageButton3" ImageUrl="~/App_Themes/Default/images/ExportToExcel.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="20"  Width="20px"
                 onclick="btnExportToExcel_Click" ToolTip="Export To Excel Directly"  />&nbsp;

             </div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_TxtRIDForDetail">View Profile (RID)</label></td>
            <td><asp:TextBox ID="TxtRIDForDetail" runat="server"></asp:TextBox></td>
            <td><a id="LnkGenrateDetail" style="display:none" href="RegistrationDetaiFromSearch.aspx" target="_blank"  ></a>
                        <asp:Button ID="BtnGenrateCandidateDetail" runat="server" Text="Go"  OnClientClick="javascript: GoRegistrationDetail();"  />
             </td>
        </tr>
    </table>
    <div style="height:800px; width:100%;">
              <telerik:RadWindowManager runat="server" ID="radManager" DestroyOnClose="true" AutoSize="false" Top="0"  Height="680" Width="1024" Modal="true"  Left="0"  VisibleStatusbar="false" ClientIDMode="AutoID"  ></telerik:RadWindowManager>      
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
                                 <asp:Label CssClass="labelStyle" runat="server" ID="lbWaitState"  Font-Bold="true" Font-Size="10" ForeColor="#D32232">
                                 <p>-: Please Wait - Report Generation under progress : -</p></asp:Label>
                               </td>
                           </tr>
                         </table>

    </div>
  
    <script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="../Scripts/Common.js" type="text/javascript"></script>
    <script src="AllActiveRegisteredCandidateReport.js" type="text/javascript"></script>

</asp:Content>
