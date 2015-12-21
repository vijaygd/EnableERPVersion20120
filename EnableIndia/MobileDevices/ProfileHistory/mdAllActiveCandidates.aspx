<%@ Page Title="" Language="C#" MasterPageFile="~/MobileDevices/mobileMaster.Master" AutoEventWireup="true" CodeBehind="mdAllActiveCandidates.aspx.cs" Inherits="EnableIndia.MobileDevices.ProfileHistory.mdAllActiveCandidates" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../App_Themes/Default/Pager.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.7.1-vsdoc.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-2.1.4.min.js"></script>
    <script src="../../Scripts/jquery.cookie.pack.js"></script>
    <script src="../../Scripts/Common.js"></script>
    <script src="../../Scripts/jquery.pager.js"></script>
    <script src="mdAllActiveCandidates.js"></script>
       <table style="border-collapse:separate; border-width:0px; border-spacing:1px; word-wrap:break-word; width:100%; table-layout:fixed; ">
       <colgroup>
           <col  style="width:17%" />
           <col  style="width:27%" />
           <col  style="width:27%" />
           <col  style="width:27%" />
       </colgroup>
    <tbody>
         <tr>
            <td style="vertical-align:middle;">
                <label for="ContentPlaceHolder1_TxtSearchFor">Search for</label>
            </td>
            <td  colspan="3" style="vertical-align:middle; text-align:left">
                <asp:TextBox ID="TxtSearchFor" runat="server" Width="200px" ToolTip="Search For" />
                <label for="ContentPlaceHolder1_DdlSearchIn">in</label>
                <select id="DdlSearchIn" runat="server" title="Serach In">
                    <option value="name">Name</option>
                    <option value="registration_id">RID</option>
                    <option value="ngo">NGO</option>
                </select>
            </td>
        </tr>
         <tr>
            <td style="vertical-align:middle;">
                <label for="ContentPlaceHolder1_DdlDisabilities">Disability</label>
            </td>
            <td style="vertical-align:middle;">
               <select id="DdlDisabilities" runat="server" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
                <tr>
            <td style="vertical-align:middle;">
                <label for="ContentPlaceHolder1_DdlEmploymentStatus">Type of Candidates</label></td>
            <td style="vertical-align:middle;">
                <select id="DdlEmploymentStatus" runat="server" >
                    <option value="-1">All</option>
                    <option value="1">Unemployed</option>
                    <option value="2">Employed</option>
                    <option value="3">Priority</option>
                    <option value="4">Needy</option>
                    <option value="5">Ready for Employment (Employable without Training OR All Recommended Training Completed)</option>
                </select>
            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle;">
                <label for="ContentPlaceHolder1_DdlJobType">Job Type</label>
            </td>
            <td colspan="3" style="vertical-align:middle;">
                <select id="DdlJobType" runat="server" 
                    onchange="javascript:DdlJobType_SelectIndexChanged(this.value,'JobID','DdlRecommendedRole','DdlHiddenRecommendedRole');" />
                <label for="ContentPlaceHolder1_DdlRecommendedRole">Recommended Role</label>
                <select id="DdlRecommendedRole" runat="server" 
                    onchange="javascript:$('#TxtHiddenRecommendedRole').val($('#DdlRecommendedRole').val());" />
            <div style="display:none">
                <label for="ContentPlaceHolder1_DdlHiddenRecommendedRole">Hidden Rcommeded role</label>
                <select id="DdlHiddenRecommendedRole" runat="server"/>
                <label for="ContentPlaceHolder1_TxtHiddenRecommendedRole">Hidden Rcommeded role</label>
                <asp:TextBox ID="TxtHiddenRecommendedRole" runat="server" />
                <span id="SpnHiddenRecommendedRole" runat="server"></span>
            </div>
          </td>
        </tr>
        <tr>
            <td style="vertical-align:middle;">
                <label for="ContentPlaceHolder1_DdlCities">City</label>
            </td>
            <td style="vertical-align:middle;">
                <select id="DdlCities" runat="server" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="vertical-align:middle;">
                <label for="ContentPlaceHolder1_DdlNGOs">NGO</label>
            </td>
            <td style="vertical-align:middle;">
                <select id="DdlNGOs" runat="server" />
            </td>
            <td></td>
        </tr>
         <tr>
            <td style="vertical-align:middle;"><label for="ContentPlaceHolder1_DdlAssignment">Assignment</label></td>
            <td style="vertical-align:middle;">
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
            <td></td>
        </tr>
        <tr>
            <td style="vertical-align:middle;">
                <label for="ContentPlaceHolder1_TxtOldRegistraionNumber">Old Registration Number</label>
            </td>
            <td style="vertical-align:middle;"><asp:TextBox ID="TxtOldRegistraionNumber" runat="server" /></td>
            <td></td>
        </tr>
        <tr>
            <td style="vertical-align:middle;">
                 <label for="ContentPlaceHolder1_TxtDateOfBirth">Date Of Birth</label>
            </td>
            <td style="vertical-align:middle;">
                <asp:TextBox ID="TxtDateOfBirth" runat="server" yearlength="4" />
                    <asp:ImageButton runat="server" ID="Image1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                    <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="Image1" TargetControlID="TxtDateOfBirth" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtDateOfBirth"
                    ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                    runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                (dd/mm/yyyy)
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="vertical-align:middle;;">
                <label for="ContentPlaceHolder1_DdlAgeGroups">Age in Years</label>
            </td>
            <td>
                <select id="DdlAgeGroups" runat="server" />
            </td>
            <td></td>
        </tr>
         <tr>
            <td  style="vertical-align:middle;"><label for="ContentPlaceHolder1_DdlMissingData">Missing data in Profile </label></td>
            <td style="vertical-align:middle;">
                <select id="DdlMissingData" runat="server">
                    <option value="All">Select</option>
                    <option value="phone_number_secondary">Phone number(Secondary)</option>
                    <option value="email_address">E-mail</option>
                    <option value="all_relevant_documents_submitted">All relevant documents submitted-No</option>
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
            <td></td>
        </tr>
          <tr>
            <td style="vertical-align:middle;">
                <asp:Button ID="BtnSearch" runat="server" Text="Go" ToolTip="search" class="cell"
                    OnClientClick="javascript:$.cookie('grid_page_number',1,{path: '/'});javascript:return CheckForParameterChange();"
                    OnClick="BtnSearch_Click"  />
                 <asp:Button ID="BtnSearchCandidates" runat="server" Text="Hidden Search" style="display:none"
                    OnClick="BtnSearchCandidates_Click" />
              </td>
          </tr>
    </tbody>
    </table>
       <div id="TblSearchResult" runat="server" visible="false">
           <table>
               <tr>
                   <td><h2 class="skiplink">Results Table</h2></td>
               </tr>
           </table>
           
           <table style="border-collapse:separate; border-spacing:4px;">
               <tr>
                   <td>
                       <asp:Button ID="BtnAddToCandidateCalling" runat="server" Text="Add To Candidate Calling"
                           OnClientClick="javascript:return AddToCandidteCallingList();" />
                       <asp:Button ID="BtnViewCandidateCallingList" runat="server" Text="View Candidate Calling" style="display:none"
                           OnClientClick="javascript:ShowPopUp('../ViewCandidateCallingList.aspx',1200,600);return false;" />
                          <asp:Button ID="BtnPrint" runat="server" Text="Print Candidate Calling" style="display:none"
                             OnClick="BtnPrint_click" />
                   </td>
               </tr>
           </table>
           <table id="TblCountDetail" runat="server">
               <tr>
                   <td>The Number of Candidates in results table below:<span id="SpnTextCount" runat="server"></span>candidates</td>
               </tr>
           </table>
           <table style="margin-top:10px; border-collapse:separate; border-spacing:4px;">
               <tr>
                   <td>
                       <asp:ListView ID="LstViewAllActiveCandidates" runat="server" style="width"
                           OnItemDataBound="LstViewAllActiveCandidates_ItemDataBound">
                           <LayoutTemplate>
                               <table>
                                   <tr>
                                       <td><div id="DivActiveProfiledCandidates" class="pager"></div></td>
                                   </tr>
                               </table>
                               <table id="TblAllActiveCandidates" class="tableBorder" rules="all"  style="border-color:#808080;margin-top:10px; border-width:1px;  border-collapse:separate; border-spacing:0px;">
                                     <thead>
                                           <tr class="grid-header">
                                               <th>
                                                   <input id="ChkSelectAllCandidates" type="checkbox"  
                                                       title="Select All Candidates"
                                                       onclick ="javascript:SelectAllCandidates();" />
                                               </th>
                                               <th style="text-align:right;">No.</th>
                                               <th style="white-space:nowrap">Name of Candidate</th>
                                               <th>Registration ID (R I D)</th>
                                               <th>Disability Type</th>
                                               <th>Educational Qualifications</th>
                                               <th style="width:200px" >Phone numbers</th>
                                               <th style="white-space:nowrap">Email</th>                                                                                                                           
                                               <th>NGO</th>
                                               <th>Current Company</th>
                                               <th>Unemployed since days</th>
                                               <th>Recommended Job Type</th>
                                               <th>Recommended Role</th>
                                           </tr>
                                     </thead>
                                     <tbody>
                                       <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                     </tbody>
                               </table>
                           </LayoutTemplate>
                           
                           <ItemTemplate>
                               <tr>
                                   <td>
                                       <asp:CheckBox id="ChkCandidateName" runat="server"
                                           CandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>' />
                                       <label id="LblCandidateName" runat="server" class="skiplink">Select <%#Eval("candidate_name")%></label>
                                   </td>
                                   <td id="TdRecordNumber" style="text-align:right;"></td>
                                   <td style="font-weight:normal; text-align:left;" title="Name of Candidate :<%#Eval("candidate_name") %>">
                                       <a id="LnkBtnCandidateName" class="readonlyText" target="_blank"
                                           href='<%#"mdRegistration.aspx?cand=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("candidate_name") %></a>
                                   </td>
                                   <td style="text-align:left;" title="<%#Eval("candidate_name") %>'s RID"> 
                                       <a id="LnkBtnRegistrationID" class="readonlyText" target="_blank"
                                           href='<%#"mdAddViewCandidateHistory.aspx?cand=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("rid") %></a>
                                   </td>
                                   <td style="text-align:left;" title="<%#Eval("candidate_name") %>'s Disability Type"><%#Eval("disability_type") %></td>
                                   <td style="text-align:left;" title="<%#Eval("candidate_name") %>'s Educational Qualifications"><%#Eval("educational_qualifications")%></td>
                                   <td style="text-align:right;width:200px" title="<%#Eval("candidate_name") %>'s Phone Numbers"><%#Eval("phone_numbers") %></td>
                                   <td style="text-align:left;" title="<%#Eval("candidate_name") %>'s Email Address"><%#Eval("email_address") %></td>
                                   <td style="text-align:left;" title="<%#Eval("candidate_name") %>'s NGO Name"><%#Eval("ngo_name")%></td>
                                   <td style="text-align:left;" title="<%#Eval("candidate_name") %>'s Current Company"><%#Eval("current_company") %></td>
                                   <td style="text-align:right;" title="<%#Eval("candidate_name") %>'s Unemployed Since Days"><%#Eval("unemployed_from_days")%></td>
                                   <td style="text-align:left;" title="<%#Eval("candidate_name") %>'s Recommended Job Type"><%#Eval("recommended_job_types")%></td>
                                   <td style="text-align:left"  title="<%#Eval("candidate_name") %>'s Recommended Role"><%#Eval("recommended_roles")%></td>
                                   <td style="display:none">
                                       <span id="SpnCount" runat="server"><%# Eval("StrCount")%></span>
                                   </td>
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
           </table>
     </div>    
    <%--Hidden fields for Candidate Calling List--%>
    <table style="display:none" >
        <tr>
            <td>
                <label for="ContentPlaceHolder1_TxtIsParameterChanged">test</label>
                <asp:TextBox ID="TxtIsParameterChanged" runat="server" />
                <label for="ContentPlaceHolder1_TxtCandidatesInCandidateCallingList">test</label>
                <asp:TextBox ID="TxtCandidatesInCandidateCallingList" runat="server" Width="800px" />
            </td>
        </tr>
    </table>

</asp:Content>
