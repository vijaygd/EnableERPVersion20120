<%@ Page Title="Active Profiled Candidates" ValidateRequest="false" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.ProfileHistory.AllActiveCandidates" Codebehind="AllActiveCandidates.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">Candidate Section</td>
        </tr>
    </table>    

    <table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">    
        <tr>
            <td>Profile and History > All Active Profiled  Candidates</td>
        </tr>
     </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<script src="../../Scripts/jquery-1.7.1-vsdoc.js" type="text/javascript"></script>
<script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="../../Scripts/jquery.cookie.pack.js" type="text/javascript"></script>
<script src="../../Scripts/Common.js" type="text/jscript"></script>
<script src="../../Scripts/jquery.pager.js" type="text/jscript"></script>
<script src="AllActiveCandidates.js" type="text/javascript"></script>
    <table cellpadding="0" cellspacing="0" class="skiplink">
        <tr>
            <td>
                <h1><span id="skipToTop" class="skiplink" style="color:White">All Active Profiled Candidates</span></h1>
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
                    <option value="registration_id">RID</option>
                    <option value="ngo">NGO</option>
                </select>
            </td>
        </tr>
    </table>
    
    <table group="SearchParameters">
        <tr>
            <td style="width:135px;">
                <label for="ctl00_ContentPlaceHolder2_DdlDisabilities">Disability</label>
            </td>
            <td>
            <select id="DdlDisabilities" runat="server" />
            </td>
        </tr>
    </table>
    
    <table group="SearchParameters">
        <tr>
            <td style="width:135px;">
                <label for="ctl00_ContentPlaceHolder2_DdlEmploymentStatus">Type of Candidates</label></td>
            <td>
                <select id="DdlEmploymentStatus" runat="server" >
                    <option value="-1">All</option>
                    <option value="1">Unemployed</option>
                    <option value="2">Employed</option>
                    <option value="3">Priority</option>
                    <option value="4">Needy</option>
                    <option value="5">Ready for Employment (Employable without Training OR All Recommended Training Completed)</option>
                </select>
            </td>
        </tr>
    </table>
    
    <table group="SearchParameters">
        <tr>
            <td style="width:135px">
                <label for="ctl00_ContentPlaceHolder2_DdlJobType">Job Type</label>
            </td>
            <td>
                <select id="DdlJobType" runat="server" 
                    onchange="javascript:DdlJobType_SelectIndexChanged(this.value,'JobID','DdlRecommendedRole','DdlHiddenRecommendedRole');" />
            </td>
            <td id="TdRecomendedRole" style="width:150px;padding-left:30px">
                <label for="ctl00_ContentPlaceHolder2_DdlRecommendedRole">Recommended Role</label>
            </td>
            <td>
                <select id="DdlRecommendedRole" runat="server" 
                    onchange="javascript:$('#TxtHiddenRecommendedRole').val($('#DdlRecommendedRole').val());" />
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
    
    <table group="SearchParameters">
        <tr>
            <td style="width:135px;">
                <label for="ctl00_ContentPlaceHolder2_DdlCities">City</label>
            </td>
            <td>
                <select id="DdlCities" runat="server" />
            </td>
        </tr>
    </table>
    
    <table group="SearchParameters">
        <tr>
            <td style="width:135px;">
                <label for="ctl00_ContentPlaceHolder2_DdlNGOs">NGO</label>
            </td>
            <td>
                <select id="DdlNGOs" runat="server" />
            </td>
        </tr>
    </table>
    
    <table>
         <tr>
            <td style="width:135px;"><label for="ctl00_ContentPlaceHolder2_DdlAssignment">Assignment</label></td>
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
    
    <table group="SearchParameters">
        <tr>
            <td style="width:135px">
                <label for="ctl00_ContentPlaceHolder2_TxtOldRegistraionNumber">Old Registration Number</label>
            </td>
            <td><asp:TextBox ID="TxtOldRegistraionNumber" runat="server" /></td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td style="width:135px">
                 <label for="ctl00_ContentPlaceHolder2_TxtDateOfBirth">Date Of Birth</label>
            </td>
            <td>
                <asp:TextBox ID="TxtDateOfBirth" runat="server" yearlength="4" />
                    <asp:ImageButton runat="server" ID="Image1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                    <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="Image1" TargetControlID="TxtDateOfBirth" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtDateOfBirth"
                    ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                    runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                (dd/mm/yyyy)
            </td>
        </tr>
    </table>
    
     <table group="SearchParameters">
        <tr>
            <td style="width:135px;">
                <label for="ctl00_ContentPlaceHolder2_DdlAgeGroups">Age in Years</label>
            </td>
            <td>
                <select id="DdlAgeGroups" runat="server" />
            </td>
        </tr>
    </table>
    
    <table>
         <tr>
            <td  style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlMissingData">Missing data in Profile </label></td>
            <td>
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
        </tr>
    </table>
    
    <table>
          <tr>
            <td style="width:135px"></td>
              <td>
                <asp:Button ID="BtnSearch" runat="server" Text="Go" ToolTip="search" class="cell"
                    OnClientClick="javascript:$.cookie('grid_page_number',1,{path: '/'});javascript:return CheckForParameterChange();"
                    OnClick="BtnSearch_Click"  />
                 <asp:Button ID="BtnSearchCandidates" runat="server" Text="Hidden Search" style="display:none"
                    OnClick="BtnSearchCandidates_Click" />
              </td>
          </tr>
    </table>
   
    <table id="TblSearchResult" runat="server" visible="false">
        <tr>
            <td>
                <table>
                    <tr>
                        <td><h2 class="skiplink">Results Table</h2></td>
                    </tr>
                </table>
                
                <table cellspacing="4">
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
                <table cellspacing="4" style="margin-top:10px">
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
                                    <table id="TblAllActiveCandidates" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"  style="border-color:#808080;margin-top:10px" border="1px">
                                          <thead>
                                                <tr class="grid-header">
                                                    <th>
                                                        <input id="ChkSelectAllCandidates" type="checkbox"  
                                                            title="Select All Candidates"
                                                            onclick ="javascript:SelectAllCandidates();" />
                                                    </th>
                                                    <th align="right">No.</th>
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
                                        <td id="TdRecordNumber" align="right"></td>
                                        <td align="left" style="font-weight:normal" title="Name of Candidate :<%#Eval("candidate_name") %>">
                                            <a id="LnkBtnCandidateName" class="readonlyText" target="_blank"
                                                href='<%#"Registration.aspx?cand=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("candidate_name") %></a>
                                        </td>
                                        <td align="left" title="<%#Eval("candidate_name") %>'s RID"> 
                                            <a id="LnkBtnRegistrationID" class="readonlyText" target="_blank"
                                                href='<%#"AddViewCandidateHistory.aspx?cand=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("rid") %></a>
                                        </td>
                                        <td align="left" title="<%#Eval("candidate_name") %>'s Disability Type"><%#Eval("disability_type") %></td>
                                        <td align="left" title="<%#Eval("candidate_name") %>'s Educational Qualifications"><%#Eval("educational_qualifications")%></td>
                                        <td align="right" style="width:200px" title="<%#Eval("candidate_name") %>'s Phone Numbers"><%#Eval("phone_numbers") %></td>
                                        <td align="left" title="<%#Eval("candidate_name") %>'s Email Address"><%#Eval("email_address") %></td>
                                        <td align="left" title="<%#Eval("candidate_name") %>'s NGO Name"><%#Eval("ngo_name")%></td>
                                        <td align="left" title="<%#Eval("candidate_name") %>'s Current Company"><%#Eval("current_company") %></td>
                                        <td align="right" title="<%#Eval("candidate_name") %>'s Unemployed Since Days"><%#Eval("unemployed_from_days")%></td>
                                        <td align="left" title="<%#Eval("candidate_name") %>'s Recommended Job Type"><%#Eval("recommended_job_types")%></td>
                                        <td align="left" title="<%#Eval("candidate_name") %>'s Recommended Role"><%#Eval("recommended_roles")%></td>
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
            </td>
        </tr>
    </table>
    
    <%--Hidden fields for Candidate Calling List--%>
    <table style="display:none" >
        <tr>
            <td>
                <label for="ctl00_ContentPlaceHolder2_TxtIsParameterChanged">test</label>
                <asp:TextBox ID="TxtIsParameterChanged" runat="server" />
                <label for="ctl00_ContentPlaceHolder2_TxtCandidatesInCandidateCallingList">test</label>
                <asp:TextBox ID="TxtCandidatesInCandidateCallingList" runat="server" Width="800px" />
            </td>
        </tr>
    </table>
</asp:Content>