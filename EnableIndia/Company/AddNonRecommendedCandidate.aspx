<%@ Page Title="Add Non Recommended Candidates" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Company.AddNonRecommendedCandidate" Codebehind="AddNonRecommendedCandidate.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>    
        <td class="pageHeader">COMPANY SECTION</td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0"  class="pageHeaderLevel1">
    <tr>
        <td>Manage Open Employment Projects>>Step 2: Add Non Recommended Candidates</td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:300px;padding-left:12px">
           <%-- <asp:LinkButton ID="LnkBtnCompanyDetails" runat="server" Text="Company Details" CssClass="tab_links"
                PostBackUrl="~/Company/AddCompany.aspx" />--%>
<%--           <a id="LnkBtnCompanyDetails" runat="server" class="tab_links"
                href="~/Company/AddCompany.aspx">Company Details</a>--%>
               <asp:LinkButton runat="server" ID="btnCompanyDetails" Text="Company Details"  OnClick="btnCompanyDetClick"></asp:LinkButton>
        </td>

        <td>
<%--            <a id="LnkBtnEmploymentProjectDetails" runat="server" class="tab_links"
                href="~/Company/AddEmploymentProjects.aspx">Employment Project Details & Contacts</a>
--%>  
          <asp:LinkButton ID="LnkBtnEmploymentProjectDetails" runat="server" Text="Employment Project Details & Contacts"  OnClick="empProjectsClick" CssClass="tab_links" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:300px;padding-left:12px">
              <asp:LinkButton ID="LnkBtnAddNonRecommendedCandidates" runat="server" Text="Step 1: Add Recommended Candidates"
                OnClick="lbAddReccomCandidates" CssClass="tab_links" />

        </td>
        <td style="width:150px">
<%--             <asp:LinkButton ID="LnkBtnAssignedList" runat="server" Text="Step 3: Assigned List"
                PostBackUrl="~/Company/AssignedList.aspx" CssClass="tab_links" />
--%> 
             <asp:LinkButton ID="LnkBtnAssignedList" runat="server" Text="Step 3: Assigned List"
              OnClick="LnkBtnAssignedList_click"    CssClass="tab_links" />

       </td>
    </tr>
</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery.pager.js" type="text/javascript"></script>
<script src="../Scripts/jquery.cookie.pack.js" type="text/javascript"></script>
<script src="AddNonRecommendedCandidate.js" type="text/javascript" ></script>

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
            <span>Employment Project : </span>
        </td>
        <td>
            <span id="SpnEmploymentProjectName" runat="server" class="readonlyText"/>
        </td>
    </tr>
</table>

<table>
    <tr style="font-size:11px">
        <td class="readonly_bold_text">
            <span>Current Demand: </span>
        </td>
        <td>
            <span id="SpnCurrentDemand" runat="server" class="readonlyText"/>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td style="width:150px"> 
            <label for="ctl00_ContentPlaceHolder2_DdlTypeOfCandidate">Type of Candidates :</label>
        </td>
        <td>
            <select id="DdlTypeOfCandidate" runat="server">
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
<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlQualification">Qualification</label>
        </td>
        <td>
            <select id="DdlQualification" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlNGO">NGO</label>
        </td>
        <td>
            <select id="DdlNGO" runat="server" />
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
                onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHidddenCity').val($('#ctl00_ContentPlaceHolder2_DdlCity').val());" />
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
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlRecommendedTrainingPrograms">Training Passed</label>
        </td>
        <td>
            <select id="DdlRecommendedTrainingPrograms" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlDisabilities">Disability</label>
        </td>
        <td>
            <select id="DdlDisabilities" runat="server" />
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
                onchange="javascript:DdlRecommendedJobType_SelectIndexChanged(this.value,'JobID','DdlRecommendedRole','DdlHiddenRecommendedRole');" />
        </td>
        <td id="TdRecomendedRole" style="width:150px;padding-left:30px">
            <label for="ctl00_ContentPlaceHolder2_DdlRecommendedRole">Recommended Role</label>
        </td>
        <td>
            <select id="DdlRecommendedRole" runat="server"
                onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHiddenRecommendedRole').val($('#ctl00_ContentPlaceHolder2_DdlRecommendedRole').val());" />
        </td>
        <td  style="display:none" >
            <label for="ctl00_ContentPlaceHolder2_DdlHiddenRecommendedRole">Hidden Rcommeded role</label>
            <select id="DdlHiddenRecommendedRole" runat="server"/>
            <label for="ctl00_ContentPlaceHolder2_TxtHiddenRecommendedRole">Hidden Rcommeded role</label>
            <asp:TextBox ID="TxtHiddenRecommendedRole" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlLanguage">Language</label>
        </td>
        <td>
            <select id="DdlLanguage" runat="server" />
        </td>
    </tr>
</table>


<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlGroups">Groups</label>
        </td>
        <td>
            <select id="DdlGroups" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_DdlAgeGroup">Age Years</label>
        </td>
        <td>
            <select id="DdlAgeGroup" runat="server" />
        </td>
    </tr>
</table>

<table>
        <tr>
            <td style="width:150px">
                <label for="ctl00_ContentPlaceHolder2_DdlSelectGender">Select Gender</label>
            </td>
            <td>
                <select id="DdlSelectGender" runat="server" title="Select Gender">
                    <option value="-1">All</option>
                    <option value="1">Male</option>
                    <option value="0">Female</option>
                </select>
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
<table>
    <tr>    
        <td style="width:150px"></td>
        <td>
            <asp:Button ID="BtnSearchNonRecommendedCandidates" Text="Go" runat="server" 
                OnClientClick="javascript:$.cookie('grid_page_number',1,{path: '/'});"
                OnClick="BtnSearchNonRecommendedCandidates_Click" />
            <asp:Button ID="BtnSearchCandidates" runat="server" Text="Hidden Search" style="display:none"
                OnClick="BtnSearchCandidates_Click" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
            <asp:ListView ID="LstViewNonRecommendedCandidate" runat="server" 
                OnItemDataBound="LstViewNonRecommendedCandidate_ItemDataBound">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <td><div id="DivCompanyNonRecommendedCandidates" class="pager"></div></td>
                        </tr>
                    </table>
                    <table style="margin-bottom:10px">
                        <tr>
                            <td style="font-weight:bold;width:400px">
                                <u>Non-Recommended Candidates for this Employment Project</u>
                            </td>
                           <%-- <td>
                                 <input id="BtnSelectAll" value="Select All" type="button"
                                    onclick="$('#TblNonRecommendedCandidates :checkbox').attr('checked',true);" />
                            </td>--%>
                            <td>
                                <asp:Button ID="BtnAddToAssignedList" Text="Add To Assigned List" runat="server"
                                    OnClientClick="return ValidateAssignment();" OnClick="BtnAddToAssignedList_Click" />
                            </td>
                        </tr>
                    </table>
                
                    <table id="TblNonRecommendedCandidates" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                        bordercolor="#808080" border="1px">
                       <thead>
                            <tr class="grid-header">
                              <th>
                                <asp:CheckBox runat="server" ID="ChkSelectAll" title="Select All" OnCheckedChanged="EnableDisAllCb" AutoPostBack="true" />
                               </th>
                               <th align="right">No.</th>
                               <th>Name</th> 
                               <th>RID</th> 
                               <th>Disability</th> 
                               <th>Qualification</th> 
                               <th style="width:200px" >Phone Numbers</th>
                               <th>Email</th>
                               <th>Other Employment Project candidate is assigned to  </th> 
                               <th>Training Programs candidate is Assigned to</th> 
                               <th>Training Passed</th> 
                               <th>Current City</th> 
                               <th>Others</th>
                               <th>Prefered Location</th>
                               <th>Special communication</th>
                               <th>Unemployed since (days)</th>
                               <th>Total work experience (years)</th>
                               <th>Recommended Job Type</th>
                               <th>Recommended Roles</th>
                               <th>Groups</th>
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
                           <asp:CheckBox ID="ChkSelectNonRecommendedCandidate" runat="server" 
                                CandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>' />
                           <label id="LblCandidateName" runat="server" class="skiplink">Select <%#Eval("candidate_name")%></label>
                       </td>
                       <td id="TdRecordNumber" align="right"></td>
                       <td align="left" style="font-weight:normal" title="Name : <%#Eval("candidate_name")%>">
                            <a id="LnkBtnCandidateName" class="readonlyText" target="_blank"
                                href='<%#"../Candidate/ProfileHistory/Registration.aspx?cand=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("candidate_name")%></a>
                       </td> 
                       <td align="left">
                            <a id="LnkBtnRegistrationID" class="readonlyText" target="_blank" title="<%#Eval("candidate_name") %>'s RID"
                                href='<%#"../Candidate/ProfileHistory/AddViewCandidateHistory.aspx?cand=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("registration_id")%></a>
                       </td> 
                       <td align="left" title="<%#Eval("candidate_name") %>'s Disability"><%#Eval("disability_type")%></td> 
                       <td align="left" title="<%#Eval("candidate_name") %>'s Qualifications"><%#Eval("qualifications")%></td> 
                       <td align="right" style="width:200px" title="<%#Eval("candidate_name") %>'s Phone Numbers"><%#Eval("phone_numbers")%></td>
                       <td align ="left" title="<%#Eval("candidate_name") %>'s Email"><%#Eval("email_address")%></td>
                       <td align="left" title="Other Employment Project <%#Eval("candidate_name") %> is assigned to"><%#Eval("assigned_employment_projects")%></td> 
                       <td align="left" title="Training Programs <%#Eval("candidate_name") %> is Assigned to"><%#Eval("training_programs_passed")%></td> 
                       <td align="left" title="<%#Eval("candidate_name") %>'s Training Passed"><%#Eval("training_programs_assigned")%></td> 
                       <td align="left" title="<%#Eval("candidate_name") %>'s Current City"><%#Eval("current_city")%></td>
                       <td title="<%#Eval("candidate_name") %>'s Others"><%# Eval("other_knowledge")%></td> 
                       <td align="left" title="<%#Eval("candidate_name") %>'s Prefered Location"><%#Eval("preferred_location")%></td>
                       <td align="left" title="<%#Eval("candidate_name") %>'s Special communication"><%#Eval("special_communication_skills")%></td>
                       <td align="right" title="<%#Eval("candidate_name") %>'s Unemployed since (days)"><%#Eval("unemployed_from_days")%></td>
                       <td align="right" title="<%#Eval("candidate_name") %>'s Total work experience"><%#Eval("total_experience")%></td>
                       <td align="left" title="<%#Eval("candidate_name") %>'s Recommended Job Type"><%#Eval("recommended_job_types")%></td>
                       <td align="left" title="<%#Eval("candidate_name") %>'s Recommended Role"><%#Eval("recommended_job_roles")%></td>
                       <td align="left" title="<%#Eval("candidate_name") %>'s Groups"><%#Eval("group_name")%></td>
                       <td align="left" title="<%#Eval("candidate_name") %>'s Evaluator Comments"><%#Eval("evaluator_comments")%></td>
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
            <asp:HiddenField runat="server" ID="hCompId" EnableViewState="true" />
            <asp:HiddenField runat="server" ID="hEmpProj" EnableViewState="true" />

        </td>
    </tr>
</table>
</asp:Content>


