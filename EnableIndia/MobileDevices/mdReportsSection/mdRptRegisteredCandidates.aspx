<%@ Page Title="" Language="C#" MasterPageFile="~/MobileDevices/mobileMaster.Master" AutoEventWireup="true" CodeBehind="mdRptRegisteredCandidates.aspx.cs" Inherits="EnableIndia.MobileDevices.mdReportsSection.mdRptRegisteredCandidates" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title style="text-align:center">Candidate Registration</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManagerProxy runat="server" ID="sproxy1"></asp:ScriptManagerProxy>
    <table style="width:100%; border-collapse:separate; border-width:1px; border-spacing:2px;">
        <colgroup>
            <col style="width:15%;" />
            <col style="width:85%;" />
        </colgroup>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label3" Text="Qualification: "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
                <select id="DdlQualification" runat="server" />
                <input type="text" id="TxtCandidateID" runat="server" style="display:none" />

            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="lbProfileStatus" Text="Profile Status: "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
                <select id="DdlProfilingStatus" runat="server">
                    <option value="All">All</option>
                    <option value="To be Profiled">To be Profiled</option>
                    <option value="Profiled">Profiled</option>
                </select>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label2" Text="Type of Candidate: "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
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
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label4" Text="Assignment: "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
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
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label5" Text="State: "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
                <select id="DdlState" runat="server"
                    onchange="javascript:DdlState_SelectIndexChanged(this.value,'StateID','ContentPlaceHolder1_DdlCities','ContentPlaceHolder1_DdlHiddenCity');" />
                        <div id="TdCity"" style="display:table-cell; display:none;">
                            <select id="DdlCities1" runat="server" onchange="javascript:$('#ContentPlaceHolder1_TxtHidddenCity').val($('#ContentPlaceHolder1_DdlCities').val());" onclick="return DdlCities_onclick()">
                                <option value="All">All</option>
                            </select>
                        </div>
                        <div style="display:table-cell; display:none; ">
                           <label for="ContentPlaceHolder1_DdlHiddenCity">hidden City</label>
                           <select id="DdlHiddenCity" runat="server" />
                        </div>
                        <div style="display:table-cell; display:none; ">
                         <label for="ContentPlaceHolder1_TxtHidddenCity">hidden City</label>
                         <asp:TextBox ID="TxtHidddenCity" runat="server" />
                         </div>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label7" Text="Age(Years) :"></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
                <div style="display:table-cell">
                     <select id="DdlAgeGroups" runat="server" />
                </div>
                <div style="display:table-cell">
                  &nbsp;&nbsp;
                <asp:Label CssClass="labelStyle" runat="server" ID="lbContExpDateT" Text="Contract Expiry Date: " Font-Bold="true" AssociatedControlID="DdlContExpDate"></asp:Label>
                <asp:DropDownList runat="server" ID="DdlContExpDate">
                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                    <asp:ListItem Text="With Dates only" Value="1"></asp:ListItem>
                </asp:DropDownList>

                </div>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label8" Text="Ngo: "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
                <select id="DdlNGOs" runat="server" />

            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label9" Text="Disability: "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
                <div style="display:table;">
                    <div  style="display:table-row;">
                        <div style="display:table-cell;">
                        <select  id="DdlDisabilityTypes" runat="server" 
                            onchange="javascript:DdlDisabilityTypes_SelectedIndexChanged(this.value,'ContentPlaceHolder1_DisabilityTypeID','ContentPlaceHolder1_DdlDisabilitySubType','DdlHiddenDisabilitySubType');" />
                        </div>
                        <div style="display:table-cell;">
                            <label for="ct100_ContentPlaceHolder2_DdlDisabilitySubType" style="margin-left:20px;">Disability Sub Type:</label>
                        </div>
                        <div style="display:table-cell;">
                           <select id="DdlDisabilitySubType" runat="server" style="margin-left:20px;"
                             onchange="javascript:$('#ContentPlaceHolder1_TxtHiddenDisabilitySubType').val($('#ContentPlaceHolder1_DdlDisabilitySubType').val());" />
                        </div>
                        <div style="display:table-cell; display:none;">
                            <label for="ct100_ContentPlaceHolder_DdlHiddenDisabilitySubType">Hidden Disability Type</label>
                            <select id="DdlHiddenDisabilitySubType" runat="server"></select>
                            <label for="ct100_ContentPlaceHolder_TxtHiddenDisabilitySubType">Hidden Disability Type</label>
                            <asp:TextBox ID="TxtHiddenDisabilitySubType" runat="server"></asp:TextBox>
                            <span id="SpnHiddenDisabilityType" runat="server"></span>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label10" Text="Job Type: "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
                <div style="display:table;">
                    <div  style="display:table-row;">
                        <div style="display:table-cell;">
                           <select id="DdlRecommendedJobType" runat="server" 
                                onchange="javascript:DdlRecommendedJobType_SelectIndexChanged(this.value,'JobID','ContentPlaceHolder1_DdlRecommendedRole','ContentPlaceHolder1_DdlHiddenRecommendedRole');" />
                        </div>
                        <div style="display:table-cell; margin-left:20px;">
                            <label for="ContentPlaceHolder1_DdlRecommendedRole" style="margin-left:20px;">Recommended Role: </label>
                        </div>
                        <div style="display:table-cell; margin-left:20px;">
                           <select id="DdlRecommendedRole" runat="server" style="margin-left:20px;"
                            onchange="javascript:$('#ContentPlaceHolder1_TxtHiddenRecommendedRole').val($('#ContentPlaceHolder1_DdlRecommendedRole').val());" />
                        </div>
                        <div style="display:table-cell; display:none;">
                           <label for="ContentPlaceHolder1_DdlHiddenRecommendedRole">Hidden Rcommeded role</label>
                           <select id="DdlHiddenRecommendedRole" runat="server"/>
                           <label for="ContentPlaceHolder1_TxtHiddenRecommendedRole">Hidden Rcommeded role</label>
                            <asp:TextBox ID="TxtHiddenRecommendedRole" runat="server" />
                           <span id="SpnHiddenRecommendedRole" runat="server"></span>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label11" Text="Missing data in Profile :"></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
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
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label12" Text="Groups"></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
                <select id="DdlGroups" runat="server"></select>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label13" Text="Language: "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
                <select id="DdlLanguage" runat="server"/>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label14" Text="Gender: "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
               <select id="DdlGender" runat="server">
                    <option value="All">All</option>
                    <option value="Male">Male</option>
                    <option value="Female">Female</option>
                </select>

            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label15" Text="Company: "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
               <select id="DdlCompanies" runat="server"/>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label16" Text="Date of Birth: "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
                <asp:TextBox ID="TxtDateOfBirth" runat="server" yearlength="4"></asp:TextBox>
                <asp:ImageButton runat="server" ID="Image7" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender7" PopupButtonID="Image7" TargetControlID="TxtDateOfBirth" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtDateOfBirth"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label17" Text="Search for: "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
                <div style="display:table;">
                    <div group="SearchParameters"  style="display:table-row;">
                        <div style="display:table-cell;">
                            <asp:Label runat="server" ID="lbSearchForT" Text="Search For: " Width="120px" CssClass="labelStyle" AssociatedControlID="TxtSearchFor"></asp:Label>
                        </div>
                        <div style="display:table-cell;">
                            <asp:TextBox ID="TxtSearchFor" runat="server" Width="200px" ToolTip="Search For" />
                        </div>
                        <div style="display:table-cell;">
                           <label for="ContentPlaceHolder1_DdlSearchIn">in</label>
                        </div>
                        <div style="display:table-cell;">
                             <select id="DdlSearchIn" runat="server" title="Serach In">
                                 <option value="name">Name</option>
                                 <option selected="selected" value="registration_id">RID</option>
                             </select>
                        </div>
                    </div>
                </div>

            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label18" Text="Salary (Monthly): "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
                <div style="display:table;">
                    <div  style="display:table-row;">
                        <div style="display:table-cell;">
                            <asp:Label runat="server" ID="lbFrom" Text="From: " CssClass="labelStyle" Width="120px" AssociatedControlID="TxtSalaryFrom"></asp:Label>
                        </div>
                        <div style="display:table-cell;">
                            <asp:TextBox ID="TxtSalaryFrom" runat="server"></asp:TextBox>
                        </div>
                        <div style="display:table-cell;">
                            <label for="ContentPlaceHolder1_TxtSalaryFrom" class="skiplink">Salary  from</label>
                        </div>
                        <div style="display:table-cell;">
                            <label for="ContentPlaceHolder1_TxtSalaryTo">To</label>
                        </div>
                        <div style="display:table-cell;">
                            <asp:TextBox ID="TxtSalaryTo" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label19" Text="Registration Date: "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
                 <div style="display:table;">
                    <div  style="display:table-row;">
                        <div style="display:table-cell;">
                           <asp:TextBox ID="TxtRegistrationFrom" runat="server" yearlength="4"></asp:TextBox>
                           <asp:ImageButton runat="server" ID="Image1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                               <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="Image1" TargetControlID="TxtRegistrationFrom" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtRegistrationFrom"
                                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                              <br />
                             (dd/mm/yyyy)
                        </div>
                        <div style="display:table-cell;">
                            <label for="ContentPlaceHolder1_TxtRegistrationFrom" class="skiplink">Registration Date from</label>
                        </div>
                        <div style="display:table-cell;">
                            <label for="ContentPlaceHolder1_TxtRegistrationTo">To</label>
                        </div>
                        <div style="display:table-cell;">
                               <asp:TextBox ID="TxtRegistrationTo" runat="server" yearlength="4"></asp:TextBox>
                               <asp:ImageButton runat="server" ID="Image2" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                               <cc1:CalendarExtender runat="server" ID="CalendarExtender2" PopupButtonID="Image2"  TargetControlID="TxtRegistrationTo" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TxtRegistrationTo"
                                          ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                                          runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                               <br />
                               (dd/mm/yyyy)
                        </div>
                    </div>
                </div>

            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label20" Text="Employment Project through which candidate got job:"></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
               <div style="display:table; width:100%;">
                    <div  style="display:table-row;">
                        <div style="display:table-cell;">
                          <asp:Label runat="server" ID="lbStDt" Text="Start Date" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div style="display:table-cell;">
                         <asp:Label runat="server" ID="Label1" Text="From: " CssClass="labelStyle"></asp:Label>
                        </div>
                        <div style="display:table-cell;">
                            <asp:TextBox ID="TxtEmployementProjectStartDateFrom" runat="server" Width="100px" yearlength="4"></asp:TextBox>
                            <asp:ImageButton runat="server" ID="Image3" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                            <cc1:CalendarExtender runat="server" ID="CalendarExtender3" PopupButtonID="Image3" TargetControlID="TxtEmployementProjectStartDateFrom" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="TxtEmployementProjectStartDateFrom"
                                  ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                                  runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                             <br />(dd/mm/yyyy)
                        </div>
                        <div style="display:table-cell;">
                            <label for="ContentPlaceHolder1_TxtEmployementProjectStartDateFrom" class="skiplink">Start Date from</label>
                        </div>
                        <div style="display:table-cell;">
                            <label for="ContentPlaceHolder1_TxtEmployementProjectStartDateTo">To</label>
                        </div>
                        <div style="display:table-cell;">
                            <asp:TextBox ID="TxtEmployementProjectStartDateTo" runat="server" Width="100px" yearlength="4"></asp:TextBox>
                            <asp:ImageButton runat="server" ID="Image4" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                            <cc1:CalendarExtender runat="server" ID="CalendarExtender4" PopupButtonID="Image4" TargetControlID="TxtEmployementProjectStartDateTo" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="TxtEmployementProjectStartDateTo"
                                   ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                                   runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                                   <br />(dd/mm/yyyy)
                        </div>
                        <div style="display:table-cell;">
                            From:
                        </div>
                        <div style="display:table-cell;">
                              <asp:TextBox ID="TxtEmploymentEndDateFrom" runat="server" Width="100px" yearlength="4"></asp:TextBox>
                              <asp:ImageButton runat="server" ID="Image5" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                              <cc1:CalendarExtender runat="server" ID="CalendarExtender5" PopupButtonID="Image5" TargetControlID="TxtEmploymentEndDateFrom" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="TxtEmploymentEndDateFrom"
                              ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                              runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                              <br />
                                (dd/mm/yyyy)

                        </div>
                        <div style="display:table-cell;">
                            <label for="ContentPlaceHolder1_TxtEmploymentEndDateFrom" class="skiplink">End Date from</label>
                        </div>
                        <div style="display:table-cell;">
                            <label for="ContentPlaceHolder1_TxtEmploymentEndDateTo">To</label>
                        </div>
                        <div style="display:table-cell;">
                             <asp:TextBox ID="TxtEmploymentEndDateTo" runat="server" Width="100px" yearlength="4"></asp:TextBox>
                             <asp:ImageButton runat="server" ID="Image6" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                             <cc1:CalendarExtender runat="server" ID="CalendarExtender6" PopupButtonID="Image6" TargetControlID="TxtEmploymentEndDateTo" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="TxtEmploymentEndDateTo"
                             ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                             runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                             <br />
                               (dd/mm/yyyy)

                        </div>
                    </div>
                </div>

            </td>
        </tr>
        <tr>
            <td colspan="2" style="vertical-align:middle; text-align:left; font-weight:bold;">
                 <asp:Button runat="server" ID="btnRefresh" Width="10px" Height="10px"  CssClass="btnHide" />
                <asp:Button ID="BtnGenerateReport" runat="server" Text="Generate Print Format" 
                    OnClientClick="javascript: return GoSearchParameter();" OnClick="BtnGenerateReport_Click"  />&nbsp;&nbsp;
                <asp:Button runat="server" ID="BtnGenerateGrid" Text="Generate Grid" OnClientClick="javascript: return GoSearchParameter();" OnClick="BtnGenerateGrid_Click" />&nbsp;&nbsp;
                 <asp:ImageButton runat="server" ID="ImageButton3" ImageUrl="~/App_Themes/Default/images/ExportToExcel.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="20"  Width="20px"
                 onclick="btnExportToExcel_Click" ToolTip="Export To Excel Directly"  />&nbsp;
            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left; font-weight:bold;">
                <asp:Label runat="server" ID="Label23" Text="View Profile (RID): "></asp:Label>
            </td>
            <td style="vertical-align:middle; text-align:left;">
                <asp:TextBox ID="TxtRIDForDetail" runat="server"></asp:TextBox>&nbsp;&nbsp;
                    <a id="LnkGenrateDetail" style="display:none" href="RegistrationDetaiFromSearch.aspx" target="_blank"  ></a>
                        <asp:Button id="BtnGenrateCandidateDetail" runat="server" Text="Go"  OnClientClick="javascript: GoRegistrationDetail();" />
            </td>
        </tr>
    </table>
        <div style="height:800px; width:100%;">
              <telerik:RadWindowManager runat="server" ID="radManager" DestroyOnClose="true" AutoSize="false" Top="0"  Height="680" Width="1024" Modal="true"  Left="0"  VisibleStatusbar="false" ClientIDMode="AutoID"  ></telerik:RadWindowManager>      
          </div>
    <div id="divforScript" class="load">
         <table style="height:100px; width:500px; border-bottom-color:Blue; border-bottom-style: solid; border-top-color: Blue; border-top-style: solid; border-width:1; background-color:White;">
         <tr>
            <td  style="width:500px; text-align:center; vertical-align:middle;">
                                  <asp:Image runat="server" ID="imbPb" AlternateText="...Wait..." ImageUrl="~/Image/ajax-loader.gif" Width="30px" Height="30px" />
                              </td>
                             </tr>
                            <tr>
                               <td style="width:500px; text-align:center; vertical-align:middle;">
                                 <asp:Label CssClass="labelStyle" runat="server" ID="lbWaitState"  Font-Bold="true" Font-Size="10" ForeColor="#D32232">
                                 <p>-: Please Wait - Report Generation under progress : -</p></asp:Label>
                               </td>
                           </tr>
                         </table>

    </div>
    <script src="../../Scripts/jquery-2.1.4.min.js"></script>
    <script src="../../Scripts/Common.js"></script>
    <script src="mdRptRegisteredCandidates.js"></script>
</asp:Content>
