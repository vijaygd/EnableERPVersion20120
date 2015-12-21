<%@ Page Title="Add Non Recommended Candidates" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Training.AddNonRecommendedCandidate" Codebehind="AddNonRecommendedCandidate.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>    
        <td class="pageHeader">    
            Training section
        </td>
    </tr>
</table>

<table class="pageHeaderLevel1" cellpadding="0" cellspacing="0">
    <tr>
        <td>
             Manage Open Training Projects>>Step 2: Add Non-Recommended Candidates
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:280px;padding-left:12px">
              <asp:LinkButton ID="LnkBtnAddRecommendedCandidates" runat="server" Text="Step 1: Add Recommended Candidates"
                 CssClass="tab_links" OnClick="LnkBtnAddRecommendedCandidates_click" />
        </td>
        <td style="width:150px">
             <asp:LinkButton ID="LnkBtnAssignedList" runat="server" Text="Step 3: Assigned List"
                CssClass="tab_links" OnClick="LnkBtnAssignedList_click" />
        </td>
    </tr>
</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink" style="color:White"> Add Non-Recommended Candidates</span></h1>
        </td>
    </tr>
</table>


<table>
    <tr style="font-size:11px">
        <td class="readonly_bold_text">
            <span class="readonlyText">Training Program Name:</span>
        </td>
        <td>
            <span id="SpnTrainingProgramName" runat="server" class="readonlyText"></span>
        </td>
         <td style="padding-left:30px" class="readonly_bold_text">
             <span class="readonlyText">Training Project Name:</span>
        </td>
        <td>
            <span id="SpnTrainingProjectName" runat="server" class="readonlyText"></span>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlQualification">Qualification</label>
        </td>
        <td>
            <select id="DdlQualification" runat="server"/>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlNGO">NGO</label>
        </td>
        <td>
            <select id="DdlNGO" runat="server"/>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlState">State</label>
        </td>
        <td>
            <select id="DdlState" runat="server"
                onchange="javascript:DdlState_SelectIndexChanged(this.value,'StateID','DdlCity','DdlHiddenCity');" />              
        </td>
        <td id="TdCity">
            <label for="ctl00_ContentPlaceHolder2_DdlCity">City</label>
        </td>
        <td>
            <select id="DdlCity" runat="server"
                onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHidddenCity').val($('#ctl00_ContentPlaceHolder2_DdlCity').val());"/>
        </td>
        <td style="display:none">
            <label for="ctl00_ContentPlaceHolder2_DdlHiddenCity">hidden City</label>
                <select id="DdlHiddenCity" runat="server" />
                
              <label for="ctl00_ContentPlaceHolder2_TxtHidddenCity">hidden City</label>
                <asp:TextBox ID="TxtHidddenCity" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlRecommendedTraining">Recommended Training </label>
        </td>
        <td>
            <select id="DdlRecommendedTraining" runat="server"/>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlDisablity">Disability</label>
        </td>
        <td>
            <select id="DdlDisablity" runat="server"/>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlRecommendedJobType">Recommended Job Type</label>
        </td>
        <td>
            <select id="DdlRecommendedJobType" runat="server"
                onchange="javascript:DdlRecommendedJobType_SelectIndexChanged(this.value,'JobID','DdlRecommendedRole','DdlHiddenRecommendedRole');"
            />
        </td>
         <td id="TdRecomendedRole" style="width:150px;padding-left:30px">
            <label for="ctl00_ContentPlaceHolder2_DdlRecommendedRole">Recommended Role</label>
        </td>
        <td>
            <select id="DdlRecommendedRole" runat="server"
                onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHiddenRecommendedRole').val($('#ctl00_ContentPlaceHolder2_DdlRecommendedRole').val());"/>
        </td>
         <td style="display:none" >
            <label for="ctl00_ContentPlaceHolder2_DdlHiddenRecommendedRole">Hidden Rcommeded role</label>
            <select id="DdlHiddenRecommendedRole" runat="server"/>
            <label for="ctl00_ContentPlaceHolder2_TxtHiddenRecommendedRole">Hidden Rcommeded role</label>
            <asp:TextBox ID="TxtHiddenRecommendedRole" runat="server" />
        </td>
       
    </tr>
  
</table>

<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlEmploymentStatus">Employment Status</label>
        </td>
        <td>
            <select id="DdlEmploymentStatus" runat="server">
                <option value="-1">All</option>
                <option value="1">Employed</option>
                <option value="0">UnEmployed</option>
            </select>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
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
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlLanguage">Language</label>
        </td>
        <td>
            <select id="DdlLanguage" runat="server"/>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlAgeGroup">Age (Years):</label>
        </td>
        <td>
            <select id="DdlAgeGroup" runat="server"/>
        </td>
    </tr>
</table>

<table group="SearchParameters">
    <tr>
        <td style="width:150px">
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
                </select>
            </td>
    </tr>
</table>

<table style="margin-top:10px">
    <tr>    
        <td style="padding-left:160px">
            <asp:Button ID="BtnSearchNonRecommenededCandidate" Text="Go" runat="server"
                OnClientClick="javascript:$.cookie('grid_page_number',1,{path: '/'});"
                OnClick="BtnSearchNonRecommenededCandidate_click" />
            <asp:Button ID="BtnSearchCandidates" runat="server" Text="Hidden Search" style="display:none"
                OnClick="BtnSearchCandidates_Click" />
        </td>
    </tr>
</table>

<table>
<tr>
    <td>
        <asp:ListView ID="LstViewAddNonRecommendedCandidate" runat="server"
            OnItemDataBound="LstViewAddNonRecommendedCandidate_ItemDataBound">
            <LayoutTemplate>
                 <table>
                    <tr>
                        <td style="font-weight:bold;width:400px">
                           <u>Non-Recommended Candidates for this Training Program:</u>
                        </td>
                        <td>
                            <asp:Button ID="BtnAddToAssignedList" runat="server" Text="Add to Assigned List"
                                OnClientClick="javascript:return validateCheckBox();"
                                onclick="BtnAddToAssignedList_Click" />
                        </td>
                    </tr>
                </table>
                 <table>
                    <tr>
                        <td><div id="DivNonRecommendedCandidates" class="pager"></div></td>
                    </tr>
                </table>
                <table id="TblAddNonRecommendedCandidate" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                    bordercolor="#808080" border="1px" summary="Add non Recommended Candidate" style="margin:10px">
               
                   <thead>
                        <tr class="grid-header">
                             <th>
                                 <asp:CheckBox runat="server" ID="ChkSelectAll" title="Select All" OnCheckedChanged="EnableDisAllCb" AutoPostBack="true" />
                               </th>
                            <th align="right">No.</th>
                            <th>Name</th>
                            <th>RID</th>
                            <th>Disability</th>
                            <th style="width:80px;white-space:nowrap">Qualifications</th>
                            <th style="white-space:nowrap">Phone Numbers</th>
                            <th style="white-space:nowrap">Email</th>
                            <th align="center">Languages Known</th>
                            <th>Recommended Training</th>
                            <th>Training Programs currently Assigned</th>
                            <th>Training Passed</th>
                            <th>Current City</th>
                            <th>Others</th>
                            <th>Prefered Location</th>
                            <th>Unemployed since (days)</th>
                            <th>Recommended Job Type</th>
                            <th>Recommended Role</th>
                            <th>Vacancy/Employment Project Assigned to</th>
                            <th>Evaluator Comments</th>
                        </tr>
                   </thead>
                   <tbody>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                   </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                   <td>
                     <asp:CheckBox ID="ChkNonRecommendedCandidateName" runat="server" 
                            NonRecommendedCandidateID='<%#EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>' />
                     <label id="LblCandidateName" runat="server" class="skiplink">Select <%#Eval("candidate_name")%></label>
                   </td>
                   <td align="right" id="TdRecordNumber"></td>
                   <td title="Name: <%#Eval("candidate_name")%>">
                        <a id="LnkBtnCandidateName" class="readonlyText" target="_blank" 
                            href='<%#"../Candidate/ProfileHistory/Registration.aspx?cand=" + EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("candidate_name")%></a>
                   </td>
                   <td title="<%#Eval("candidate_name") %>'s RID">
                        <a id="LnkBtnRegistrationID" class="readonlyText" target="_blank" 
                            href='<%#"../Candidate/ProfileHistory/AddViewCandidateHistory.aspx?cand=" + EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("registration_id")%></a>
                    </td>
                    <td title="<%#Eval("candidate_name") %>'s Disability"><%# Eval("disability_type")%></td>
                    <td title="<%#Eval("candidate_name") %>'s Qualifications"><%# Eval("qualifications")%></td>
                    <td title="<%#Eval("candidate_name") %>'s Phone Numbers"><%# Eval("phone_numbers")%></td>
                    <td title="<%#Eval("candidate_name") %>'s Email"><%# Eval("email_address")%></td>
                    <td align="left" title="<%#Eval("candidate_name") %>'s Languages Known"><%# Eval("known_languages")%></td>
                    <td title="<%#Eval("candidate_name") %>'s Recommended Training"><%# Eval("recommended_training")%></td>
                    <td title="<%#Eval("candidate_name") %>'s Training Programs currently Assigned"><%# Eval("training_programs_passed")%></td>
                    <td title="<%#Eval("candidate_name") %>'s Training Passed">><%# Eval("training_programs_assigned")%></td>
                    <td title="<%#Eval("candidate_name") %>'s Current City"><%# Eval("city_name")%></td>
                    <td title="<%#Eval("candidate_name") %>'s Others"><%# Eval("other_knowledge")%></td>
                    <td title="<%#Eval("candidate_name") %>'s Prefered Location"><%# Eval("preferred_location")%></td>
                    <td title="<%#Eval("candidate_name") %>'s Unemployed since (days)"><%# Eval("unemployed_from_days")%></td>
                    <td title="<%#Eval("candidate_name") %>'s RecommendedJobType"><%# Eval("recommended_job_types")%></td>
                    <td title="<%#Eval("candidate_name") %>'s Recommended Role"><%# Eval("recommended_job_roles") %></td>
                    <td title="<%#Eval("candidate_name") %>'s Vacancy/Employment Project Assigned to"><%# Eval("emplyoment_project_names")%></td>
                    <td title="<%#Eval("candidate_name") %>'s Evaluator Comments"><%# Eval("evaluator_comments")%></td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td style="padding-left:300px">
                            <span style="font-weight:bold">No Results</span>
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:ListView>
    </td>
</tr>
</table>
<script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery.cookie.pack.js" type="text/javascript"></script>
<script src="../Scripts/jquery.pager.js" type="text/javascript"></script>
<script src="AddNonRecommendedCandidate.js" type="text/javascript"></script>
<%--<script type="text/javascript">
    function More_Click() {
        ShowPopUp('AddNonRecommendedCandidate.htm','870','260');
    }
</script>--%>
</asp:Content>


