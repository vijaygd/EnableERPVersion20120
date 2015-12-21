<%@ Page Title="Add Auto Recommended Candidate" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Training.AddRecommendedCandidate" Codebehind="AddRecommendedCandidate.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellspacing="0" cellpadding="0" >
    <tr>
        <td class="pageHeader">Training Section</td>
    </tr>
</table>

<table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">
    <tr>
        <td>
            Manage Open Training Projects>>Step 1: Add Auto-Recommended Candidates 
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:320px;padding-left:12px">
              <asp:LinkButton ID="LnkBtnAddNonRecommendedCandidates" runat="server" Text="Step 2: Add Non-Recommended Candidates" OnClick="LnkBtnAddNonRecommendedCandidates_click"  CssClass="tab_links"  />
        </td>
        <td style="width:150px">
             <asp:LinkButton ID="LnkBtnAssignedList" runat="server" Text="Step 3: Assigned List"  CssClass="tab_links" OnClick="LnkBtnAssignedList_click" />
        </td>
    </tr>
</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink" style="color:White"> Add Auto-Recommended Candidates</span></h1>
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
          <label for="ctl00_ContentPlaceHolder2_DdlSelectAge">Select Age (Years):</label>
        </td>
        <td>
            <select id="DdlSelectAge" runat="server"/>
        </td>
    </tr>
</table>

<table group="SearchParameters">
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_TxtSearchFor">Search for</label>
        </td>
        <td style="padding-right:30px">
            <asp:TextBox ID="TxtSearchFor" runat="server" Width="200px" ToolTip="Search For"/>
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
            <asp:Button ID="btnSearchCandidate" runat="server" Text="Go"
                OnClientClick="javascript:$.cookie('grid_page_number',1,{path: '/'});"
                OnClick="btnSearchCandidate_click" />
            <asp:Button ID="BtnSearchCandidates" runat="server" Text="Hidden Search" style="display:none"
                OnClick="BtnSearchCandidates_Click" />
        </td>
    </tr>
</table>

<table cellspacing="4" style="margin-top:10px">
    <tr>
        <td>
            <asp:ListView ID="LstViewTrainingProgram" runat="server" 
                OnItemDataBound="LstViewTrainingProgram_ItemDataBound" >
                <LayoutTemplate>
                    <table style="margin-bottom:10px" >
                        <tr>
                            <td style="font-weight:bold;width:400px">
                               <u>Auto-Recommended Candidates for this Training Program:</u>
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
                            <td><div id="DivRecommendedCandidates" class="pager"></div></td>
                        </tr>
                    </table>
                    <table id="TblViewTrainingProgram" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"  style="background-color:#808080;" border="1px">
                          <thead>
                                <tr class="grid-header">
                                    <th>
                                       <asp:CheckBox runat="server" ID="ChkSelectAll" title="Select All" OnCheckedChanged="EnableDisAllCb" AutoPostBack="true" />
                                   </th>
                                    <th align="right">No.</th>
                                     <th>Name</th>
                                    <th>RID</th>
                                    <th>Disability</th>
                                    <th>Qualifications</th>
                                    <th style="white-space:nowrap">Phone Numbers</th>
                                    <th style="white-space:nowrap">Email</th>
                                    <th>Languages Known</th>
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
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                          </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:CheckBox ID="ChkRecommendedCandidateName" runat="server" 
                               RecommendedCandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>' />
                               <label id="LblCandidateName" runat="server" class="skiplink">Select <%#Eval("candidate_name")%></label>
                        </td>
                        <td id="TdRecordNumber" align="right"></td>
                        <td title="Name : <%#Eval("candidate_name")%>">
                            <a id="LnkBtnCandidateName" class="readonlyText" target="_blank" 
                                href='<%#"../Candidate/ProfileHistory/Registration.aspx?cand=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("candidate_name")%></a>
                        </td>
                        <td title="<%#Eval("candidate_name") %>'s RID">
                            <a id="LnkBtnRegistrationID" class="readonlyText" target="_blank" 
                                href='<%#"../Candidate/ProfileHistory/AddViewCandidateHistory.aspx?cand=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("registration_id")%></a>
                        </td>
                        <td title="<%#Eval("candidate_name") %>'s Disability"><%# Eval("disability_type")%></td>
                        <td title="<%#Eval("candidate_name") %>'s Qualifications"><%# Eval("qualifications")%></td>
                        <td title="<%#Eval("candidate_name") %>'s Phone Numbers"><%# Eval("phone_numbers")%></td>
                        <td title="<%#Eval("candidate_name") %>'s Email"><%# Eval("email_address")%></td>
                        <td title="<%#Eval("candidate_name") %>'s Languages Known"><%# Eval("known_languages")%></td>
                        <td title="<%#Eval("candidate_name") %>'s Recommended Training"><%# Eval("recommended_training")%></td>
                        <td title="<%#Eval("candidate_name") %>'s Training Programs currently Assigned"><%# Eval("training_programs_passed")%></td>
                        <td title="<%#Eval("candidate_name") %>'s Training Passed"><%# Eval("training_programs_assigned")%></td>
                        <td title="<%#Eval("candidate_name") %>'s Current City"><%# Eval("city_name")%></td>
                        <td title="<%#Eval("candidate_name") %>'s Others"><%# Eval("other_knowledge")%></td>
                        <td title="<%#Eval("candidate_name") %>'s Prefered Location"><%# Eval("preferred_location")%></td>
                        <td title="<%#Eval("candidate_name") %>'s Unemployed since (days)"><%# Eval("unemployed_from_days")%></td>
                        <td title="<%#Eval("candidate_name") %>'s Recommended Job Type"><%# Eval("recommended_job_types")%></td>
                        <td title="<%#Eval("candidate_name") %>'s Recommended Role"><%# Eval("recommended_job_roles")%></td>
                        <td title="<%#Eval("candidate_name") %>'s Vacancy/Employment Project Assigned to"><%# Eval("emplyoment_project_names")%></td>
                        <td title="<%#Eval("candidate_name") %>'s Evaluator Comments"><%# Eval("evaluator_comments")%></td>
                        <td style="display:none"><span id="SpnCount" runat="server"><%# Eval("StrCount")%></span></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td style="padding-left:300px">
                                <span style="font-weight:bold">No  Results</span>
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
<script src="AddRecommendedCandidate.js" type="text/javascript" ></script>
</asp:Content>

