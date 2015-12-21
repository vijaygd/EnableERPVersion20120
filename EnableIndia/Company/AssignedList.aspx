<%@ Page Title="Assigned List" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true"  EnableEventValidation="false" Inherits="EnableIndia.Company.AssignedList" Codebehind="AssignedList.aspx.cs" EnableViewState="true" MaintainScrollPositionOnPostback="true"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>
<%@ MasterType VirtualPath="~/Candidate/Candidate.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<table cellpadding="0" cellspacing="0">
    <tr>    
        <td class="pageHeader">COMPANY SECTION</td>
    </tr>
</table>

<table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">
    <tr> 
        <td>
            Manage Open Employment Projects>Step 3: Assigned List
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:300px;padding-left:12px">
           <asp:LinkButton runat="server" ID="lbCompanyDetails" CssClass="tab_links" Text="Company Details" OnClick="lbCompanyDetailsClick"></asp:LinkButton>
        </td>
        <td>
        <asp:LinkButton runat="server" ID="lbEmploymentProjectDetails" CssClass="tab_links" Text="Employment Project Details & Contacts" OnClick="lbempProjectsClick"></asp:LinkButton>        
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:300px;padding-left:12px">
<%--            <asp:LinkButton ID="LnkBtnAddRecommendedCandidates" runat="server" Text="Step 1: Add Recommended Candidates"
                PostBackUrl="~/Company/AddRecommendedCandidate.aspx" CssClass="tab_links" />
--%>           <asp:LinkButton ID="LinkButton1" runat="server" Text="Step 1: Add Recommended Candidates" OnClick="lbRecommendedCandidateClick"></asp:LinkButton>
<%--                PostBackUrl="~/Company/AddRecommendedCandidate.aspx" CssClass="tab_links" />
--%>        </td>
        <td>
<%--             <asp:LinkButton ID="LnkBtnAddNonRecommendedCandidates" runat="server" Text="Step 2: Add Non-Recommended Candidates"
                PostBackUrl="~/Company/AddNonRecommendedCandidate.aspx" CssClass="tab_links" />
--%>        <asp:LinkButton runat="server" ID="lbAddNonRecommendedCandidate" Text="Step 2: Add Non-Recommended Candidates" OnClick="lbNonRecommendedCandidateClick"></asp:LinkButton>
          </td>
    </tr>
</table>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<div>
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink" style="color:White">Step 3: Assigned List</span></h1>
        </td>
    </tr>
</table>

<table id="TblBlankMessage" runat="server" visible="false" style="margin-bottom:20px">
    <tr>
        <td style="padding-left:300px">
        <span style="font-weight:bold">No Data Found</span>
        </td>
    </tr>
</table>
<table style="width:100%; height:100%;">
    <tr>
        <td>
<table id="TblEmploymentProjectFrNoData" runat="server" visible="true">
    <tr>
        <td>
            <table>
                <tr style="font-size:11px">
                    <td class="readonly_bold_text">
                        <span>Employment Project : </span>
                    </td>
                    <td>
                        <span id="SpnEmploymentProjectName" runat="server" class="readonlyText" />
                    </td>
                    <td style="padding-left:20px">
                        <asp:Button ID="BtnCloseTrainingProject" runat="server" Visible="false"
                            OnClientClick="return confirm('Before closing the project: \n 1. Update End Date of project if required.\n 2. Transfer important details from Notes section to Company History.\n Are you sure you want to close the project?');"
                            Text="Close Project" OnClick="BtnCloseTrainingProject_Click" />
                    </td>
                    <td>
                        <asp:Button ID="BtnViewCandidateCallingList" runat="server" Text="View Candidate Calling " 
                            OnClientClick="javascript:ShowCandidateListPopup();return false;" 
                            onclick="BtnViewCandidateCallingList_Click" />
                    </td>
                    <td >
                         <asp:Button ID="BtnPrint" runat="server" Text="Print Candidate Calling" 
                             OnClientClick-="javascript:return CheckCandidatesInCallingList();"
                             onclick="BtnPrint_click" />
                    </td>
                </tr>
            </table>

            <table>
                <tr style="font-size:11px">
                    <td class="readonly_bold_text">
                        <span>Current Demand: </span>
                    </td>
                    <td>
                        <span id="SpnCurrentDemand" runat="server" class="readonlyText" />
                    </td>
                </tr>
            </table>

            <table id="TblTextAssignlistCandidate" runat="server">
                <tr>
                    <td>
                        <u>Assigned List of Candidates for this Employment Project and Related Employment Cycle:</u>
                    </td>
                </tr>
            </table>

            <table id="TblCandidateCaliingFromStep" runat="server">
                <tr>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_DdlCandidateCallingStep">
                           Add Candidates from a particular step to Candidate Calling by selecting the step here: 
                        </label>
                    </td>
                    <td>
                        <select id="DdlCandidateCallingStep" runat="server"  enableviewstate="true">
                            <option value="-2">Select</option>
                            <option value="1">candidate interested in the job?</option>
                            <option value="2">Education Certificates Verified</option>
                            <option value="3">Profile sent</option>
                            <option value="4">Interview Scheduled</option>
                            <option value="5">Candidate confirmed for Interview</option>
                            <option value="6">Candidate Prepared for Interview</option>
                            <option value="7">Interview Support required</option>
                            <option value="8">Interview Process complete</option>
                            <option value="9">Got Job</option>
                            <option value="10">Candidate informed and accepted job</option>
                            <option value="11">Offer letter received</option>
                            <option value="12">Employment Proof received</option>
                            <option value="13">Work Place Solution to be done?</option>
                        </select>
                    </td>
                    <td>
                        <asp:Button ID="BtnAddCandidateCallingFromStep" runat="server" 
                            Text="Add to Candidate Calling from only this step"
                            OnClientClick="javascript:if(validateStep()==true) return AddToCandidteCallingListFromStep();else return false;" />
                    </td>
                </tr>
            </table>

            <table id="TblCloseParticularStep" runat="server" >
                <tr>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_DdlEditParticularStepFrom">
                            Edit a particular step for all Candidates at that step by selecting the step here:
                        </label> 
                    </td>
                    <td> 
                        <asp:DropDownList runat="server" ID="DdlEditParticularStepFrom" AutoPostBack="true" EnableViewState="true"  OnSelectedIndexChanged="DdlEditParticularStepFromChanged">
                            <asp:ListItem value="-2">Select</asp:ListItem>
                            <asp:ListItem value="1">Candidate interested in the job?</asp:ListItem>
                            <asp:ListItem value="2">Education Certificates Verified</asp:ListItem>
                            <asp:ListItem value="3">Profile sent</asp:ListItem>
                            <asp:ListItem value="4">Interview Scheduled</asp:ListItem>
                            <asp:ListItem value="5">Candidate confirmed for Interview</asp:ListItem>
                            <asp:ListItem value="6">Candidate Prepared for Interview</asp:ListItem>
                            <asp:ListItem value="7">Interview Support required</asp:ListItem>
                            <asp:ListItem value="8">Interview Process complete</asp:ListItem>
                            <asp:ListItem value="9">Got Job</asp:ListItem>
                            <asp:ListItem value="10">Candidate informed and accepted job</asp:ListItem>
                            <asp:ListItem value="11">Offer letter received</asp:ListItem>
                            <asp:ListItem value="12">Employment Proof received</asp:ListItem>
                            <asp:ListItem value="13">Work Place Solution to be done?</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="padding-left:20px">
                        <label for="ctl00_ContentPlaceHolder2_DdlOutcomeOptions"> and outcome option here:</label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="DdlOutcomeOptions">
                            <asp:ListItem Value="-2" Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><input id="BtnEditSelection" type="button" value="Apply"
                            onclick="javascript:return CloseParticularList();" /></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td>
                     <asp:Button ID="BtnSearchCandidates" runat="server" Text="Hidden Search" style="display:none"
                            OnClick="BtnSearchCandidates_Click" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="border-collapse:separate; border-spacing:4px;">
<%--                        <asp:UpdatePanel runat="server" ID="updAssignedList" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>--%>
                        <asp:ListView ID="LstViewAssignedList" runat="server" OnItemDataBound="LstViewAssignedList_ItemDataBound">
                            <LayoutTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="BtnAddToCandidateCalling" Text="Add to Candidate Calling" runat="server"
                                                OnClientClick="javascript:if(validateCheckBox()==true)return AddToCandidteCallingList();else return false;" />
                                        </td>
                                        <td>
                                            <asp:Button ID="BtnDeleteCandidate" Text="Delete Candidate" runat="server" 
                                                OnClientClick="javascript:return confirm('Are you sure want to delete candidate?');ValidateSelection();"
                                                OnClick="BtnDeleteCandidate_Click" />
                                        </td>
                                    </tr>
                                </table>
                               <table>
                                    <tr>
                                        <td valign="top"><div id="DivCompanyAssigenedList" class="pager"></div></td>
                                    </tr>
                                </table>
                                <table id="TblAssignedCandidates" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" style="border-width:1px;">
                                    <thead>
                                        <tr class="grid-header">
                                            <th>
                                               <div>
                                                 <asp:CheckBox runat="server" ID="ChkSelectAll" OnCheckedChanged="EnableDisAllCb" AutoPostBack="true" ClientIDMode="AutoID" /> />
                                               </div>
                                               
                                            </th>
                                            <th align="right">No.</th> 
                                            <th>Name</th>
                                            <th>R I D</th>
                                            <th>Disability</th>
                                            <th>Phone<br />Numbers</th>
                                            <th>Candidate interested in the job?</th>
                                            <th>Education Certificates Verified</th>
                                            <th>Profile sent</th>
                                            <th>Interview Scheduled</th>
                                            <th>Candidate confirmed for Interview</th>
                                            <th>Candidate Prepared for Interview</th>
                                            <th>Interview Support required</th>
                                            <th>Interview Process complete</th>
                                            <th>Got Job</th>
                                            <th>Candidate informed and accepted job</th>
                                            <th>Offer letter received</th>
                                            <th>Employment Proof received</th>
                                            <th>Work Place Solution to be done?</th>
                                            <th>Update Got Job details</th>
                                         </tr>
                                    </thead>
                                    <tbody>
                                         <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr id="tRow" CandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'>
                                    <td>
                                        <asp:CheckBox ID="ChkSelectCandidate" runat="server" 
                                            CandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'
                                            EmpProjectGrpID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("employment_project_group_id"))) %>' 
                                             OnCheckedChanged="EnableDropDown" AutoPostBack="true" ClientIDMode="AutoID"/>
                                        <label id="LblCandidateName" runat="server" class="skiplink">Select <%#Eval("candidate_name")%></label>
                                    </td>
                                    <td id="TdRecordNumber" align="right"></td>
                                    <td align="left" style="font-weight:normal" title="Name : <%#Eval("candidate_name")%>">
                                        <a id="LnkBtnCandidateName" class="readonlyText" target="_blank"
                                            href='<%#"../Candidate/ProfileHistory/Registration.aspx?cand=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("candidate_name")%></a>
                                    </td>
                                    <td align="left" title="<%#Eval("candidate_name") %>'s RID">
                                        <a id="LnkBtnRegistrationID" class="readonlyText" target="_blank" runat="server"
                                            href='<%#"../Candidate/ProfileHistory/AddViewCandidateHistory.aspx?cand=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("registration_id")%></a>
                                    </td> 
                                    <td title="<%#Eval("candidate_name") %>'s Disability"><%#Eval("disability_type") %></td>
                                    <td title="<%#Eval("candidate_name") %>'s Phone Numbers"><%#Eval("phone_numbers") %></td>
                                    <td Step="1" title="<%#Eval("candidate_name") %> interested in job">
                                        <select id="DdlinterestedInJob" runat="server" disabled="disabled"
                                            title="Candidate interested in the job" Step="1" value='<%#Eval("interested_in_job") %>'>
                                            <option value="-2">Select</option>
                                            <option value="1">Yes</option>
                                            <option value="0">No</option>
                                        </select>
                                    </td>
                                    <td Step="2" title="<%#Eval("candidate_name") %>'s Education Certificates Verified">
                                        <select id="DdlCretificatesVerified" runat="server" disabled="disabled"
                                            title="Education Certificates Verified"
                                            Step="2" value='<%#Eval("cretificates_verified") %>'>
                                            <option value="-2">Select</option>
                                            <option value="1">Yes</option>
                                            <option value="0">No</option>
                                            <option value="2">NA</option>
                                        </select>
                                    </td>
                                    <td Step="3" title="<%#Eval("candidate_name") %>'s Profile sent">
                                        <select id="DdlProfileSent" runat="server" disabled="disabled"
                                            title="Profile Sent"
                                            Step="3" value='<%#Eval("profile_sent") %>'>
                                            <option value="-2">Select</option>
                                            <option value="1">Yes</option>
                                            <option value="0">No</option>
                                            <option value="2">NA</option>
                                        </select>
                                    </td>
                                    <td Step="4" title="<%#Eval("candidate_name") %>'s Interview Scheduled">
                                        <select id="DdlInterviewScheduled" runat="server" disabled="disabled" title="Interview Scheduled"
                                            Step="4" value='<%#Eval("interview_scheduled") %>'>
                                            <option value="-2">Select</option>
                                            <option value="1">Yes</option>
                                            <option value="2">NA</option>
                                        </select>
                                        <asp:ImageButton ID="BtnNotes" runat="server" title="Add Notes" AlternateText="Add Notes" ClientIDMode="AutoID"
                                                CandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'
                                                ImageUrl="~/App_Themes/Default/images/add-notes.jpg" ImageAlign="AbsMiddle" Height="12px" Width="12px"
                                                OnClick="BtnNotes_click" style="border-width:0px;" />
                                    </td>
                                    <td Step="5" title="<%#Eval("candidate_name") %> confirmed for Interview">
                                        <select id="DdlConfirmedForInterview" runat="server" disabled="disabled"
                                            title="Candidate confirmed for Interview"
                                            Step="5" value='<%#Eval("confirmed_for_interview") %>'>
                                            <option value="-2">Select</option>
                                            <option value="1">Yes</option>
                                            <option value="2">NA</option>
                                        </select>
                                    </td>
                                    <td Step="6" title="<%#Eval("candidate_name") %> prepared for Interview">
                                        <select id="DdlPreparedForInterview" runat="server" disabled="disabled"
                                            title="Candidate Prepared for Interview"
                                            Step="6" value='<%#Eval("prepared_for_interview") %>'>
                                            <option value="-2">Select</option>
                                            <option value="1">Yes</option>
                                            <option value="0">No</option>
                                            <option value="2">NA</option>
                                        </select>
                                    </td>
                                    <td Step="7" title="<%#Eval("candidate_name") %>'s Interview Support required">
                                        <select id="DdlInterviewSupportRequired" runat="server" disabled="disabled"
                                            title="Interview Support required "
                                             Step="7" value='<%#Eval("interview_support_required") %>'>
                                            <option value="-2">Select</option>
                                            <option value="1">Yes</option>
                                            <option value="0">No</option>
                                            <option value="2">NA</option>
                                        </select>
                                    </td>
                                    <td Step="8" title="<%#Eval("candidate_name") %>'s Interview Process complete">
                                        <select id="DdlInterviewProcessCompleted" runat="server" disabled="disabled"
                                            title="Interview Process completed"
                                            Step="8" value='<%#Eval("interview_process_completed") %>'>
                                            <option value="-2">Select</option>
                                            <option value="1">Yes</option>
                                            <option value="2">NA</option>
                                        </select>
                                    </td>
                                    <td Step="9" title="<%#Eval("candidate_name") %> Got Job">
                                        <select id="DdlGotJob" runat="server" disabled="disabled"
                                            title="Got Job" Step="9" value='<%#Eval("got_job") %>'>
                                            <option value="-2">Select</option>
                                            <option value="1">Yes</option>
                                            <option value="0">No</option>
                                        </select>
                                    </td>
                                    <td Step="10" title="<%#Eval("candidate_name") %> informed and accepted job">
                                        <select id="DdlAcceptedJob" runat="server" disabled="disabled"
                                            title="Candidate informed and accepted job"
                                            Step="10" value='<%#Eval("candidate_informed_accepted_job") %>'>
                                            <option value="-2">Select</option>
                                            <option value="1">Yes</option>
                                            <option value="0">No</option>
                                        </select>
                                    </td>
                                    <td Step="11" title="<%#Eval("candidate_name") %> offer letter received">
                                        <select id="DdlOfferLetterReceived" runat="server" disabled="disabled"
                                            title="Offer letter received "
                                            Step="11" value='<%#Eval("offer_letter_received") %>'>
                                            <option value="-2">Select</option>
                                            <option value="1">Yes</option>
                                            <option value="0">No</option>
                                            <option value="2">NA</option>
                                        </select>
                                    </td>
                                    <td Step="12" title="<%#Eval("candidate_name") %> employment proof received">
                                        <select id="DdlEmploymentProofReceived" runat="server" disabled="disabled"
                                            title="Employment Proof received"
                                            Step="12" value='<%#Eval("employment_proof_received") %>'>
                                            <option value="-2">Select</option>
                                            <option value="1">Yes</option>
                                            <option value="0">No</option>
                                            <option value="2">NA</option>
                                        </select>
                                    </td>
                                    <td Step="13" title="<%#Eval("candidate_name") %>'s Work Place Solution to be done">
                                        <select id="DdlWorkPlaceSolutionDone" runat="server" disabled="disabled"
                                            title="Work Place Solution to be done "
                                            Step="13" value='<%#Eval("work_place_solution_to_be_done") %>'>
                                            <option value="-2">Select</option>
                                            <option value="1">Yes</option>
                                            <option value="0">No</option>
                                            <option value="2">NA</option>
                                        </select>
                                    </td>
                                    <td Step="14" title="<%#Eval("candidate_name") %>'s Update Got Job details">
                                        <asp:ImageButton ID="BtnGotJob" runat="server"  AlternateText="Got Job"   ClientIDMode="AutoID"
                                             CandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'
                                             ImageUrl="~/App_Themes/Default/images/got-job.jpg" ImageAlign="AbsMiddle" Height="12px" Width="12px"
                                             OnClick="BtnGotJob_click" style="border-width:0px;"     />
                                    </td>
                                    <td style="display:none">
                                        <span id="SpnIsFreeze" runat="server"><%# Eval("got_job_details_entered")%></span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                  <table>
                                      <tr>
                                          <td style="padding-left:300px">
                                              <span style="font-weight:bold">No Candidates are Assigned</span>
                                           </td>
                                      </tr>
                                  </table>
                            </EmptyDataTemplate>
                        </asp:ListView>
<%--                        </ContentTemplate>
                        </asp:UpdatePanel>--%>

                    </td>
                </tr>
            </table>
                        <table style="margin-top:5px">
                            <tr>
                                <td style="padding-left:400px">
                                    <asp:Button ID="BtnSubmit" runat="server" Text="Submit"
                                        OnClick="BtnSubmit_click" />
                                </td>
                                <td style="padding-left:5px">
                                    <input id="BtnResetCandidate" runat="server" type="button" value="Reset"
                                        onclick="javascript:return ResetCandidateDetail();" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
   </tr>
</table>
</div>
<div>
<div>
 <center>
        <telerik:RadWindowManager runat="server" ID="radManager" EnableViewState="false" DestroyOnClose="true" VisibleOnPageLoad="false"  AutoSize="true" Top="0"  Height="680px" Width="900px" Modal="true"   CssClass="RadWindow">
        </telerik:RadWindowManager>
 </center>
 </div>
</div>
<table style="display:none">
    <tr>
        <td>
            <label for="ctl00_ContentPlaceHolder2_TxtHiiddenSelectedStep">Selected Step</label>
            <asp:TextBox ID="TxtHiiddenSelectedStep" runat="server" />
            <label for="ctl00_ContentPlaceHolder2_TxtIsParameterChanged">test</label>
            <asp:TextBox ID="TxtIsParameterChanged" runat="server" />
            <label for="ctl00_ContentPlaceHolder2_TxtCandidatesInCandidateCallingList">test</label>
            <asp:TextBox ID="TxtCandidatesInCandidateCallingList" runat="server" Width="800px" />
            <asp:HiddenField runat="server" ID="hIntStDate" />
            <asp:HiddenField runat="server" ID="hIntEdDate" />
            <asp:HiddenField runat="server" ID="hFieldPopup" />
        </td>
    </tr>
</table>
 <%--Changes made on 28/08/2012 --%>
 
   <asp:HiddenField ID="pHidden" runat="server" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="false">
    <ContentTemplate>
        <asp:Button ID="BtnTarget" runat="server" Text="No" Style="display: none" />
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="BtnTarget"
            PopupControlID="Panel1">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="Panel1" runat="server" EnableViewState="false" BackColor="Snow" Width="380px" Height="180px">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional" Visible="false">
                <ContentTemplate>
                    <table style="width:380px; height:200px; border:1; border-bottom-style:solid; border-bottom-color:Blue; border-left-style:solid; border-left-color:Blue; border-right-style:solid; border-right-color:Blue; border-top-style:solid; border-top-color:Blue;">
                    <tr>
                        <td valign="middle" align="left" style="border:1px; border-bottom-style:solid; border-bottom-color:Blue; border-bottom-width:80%;">
                            <asp:Label CssClass="labelStyle" runat="server" ID="lbt" Text="Warning" Font-Bold="true" Font-Size="Medium" Font-Names="Consolas"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                       <td valign="middle"  align="center">
                             <asp:Label CssClass="labelStyle" runat="server" ID="lbEmpstat" Text="This candidate is already employed in company, do you want to make him unemployed?" Font-Bold="true" Font-Names="Consolas" Font-Size="Small"></asp:Label>
                       </td>
                    </tr>
                    <tr>
                    <td valign="middle" align="center">
                    <asp:Button ID="Btnshow" runat="server" Text="Yes"  OnClientClick="javascript:openRadWindow();return;"  OnClick="btnYesClicked" />&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnHide" runat="server" Text="No"   OnClick="btnNoClicked" />
                    </td>
                    </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="BtnHide" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
    </ContentTemplate>
     <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Btnshow" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<%--Hidden fields for Candidate Calling List--%>
<%--<script src="../Candidate/ProfileHistory/CandidateWorkExperience.js" type="text/javascript"></script>--%>
<div runat="server" id="divId">
<asp:HiddenField ID="regId" runat="server" />
<asp:HiddenField ID="wkExp" runat="server" />
<asp:HiddenField ID="empProj" runat="server" />
<asp:HiddenField ID="candId"  runat="server" />
<script language="javascript" type="text/javascript">
    function wk1() {
        var cid = document.getElementById('<%= this.regId.ClientID %>');
        var wid = document.getElementById('<%= this.wkExp.ClientID %>');
        if (wid.value == '-1') {
            alert("No Work experience");
            // return;
        }
        var url = "../Candidate/WorkExperiencePopup.aspx?regid=" + cid.value + "&work_exp=" + wid.value + "&txboxId=" + self.parent.location;
        ShowPopUp(url, 880, 350);
    }
    function wk2() {
        ShowWorkExperiencePopUp(-1, '');

    }
    function openRadWindow()
    {
        var cid = document.getElementById('<%= this.regId.ClientID %>');
        var iepjIndex = 0;
        var icmpIndex = 0;
        iepjIndex = document.URL.indexOf("?emp_proj=");
        icmpIndex = document.URL.indexOf("&comp=");
        var emplomentProjectID = 0;
        if (icmpIndex > 0) {
            emplomentProjectID = document.URL.substr((iepjIndex + 10), (document.URL.length - (iepjIndex + 10)) - (document.URL.length - icmpIndex));
        }
        else {
            emplomentProjectID = document.URL.substr((iepjIndex + 10), (document.URL.length - (iepjIndex + 10)));
        }
        var url = "../candidate/WorkExperiencePopup.aspx?regid=" + cid.value;
        url += "&emp_proj=" + emplomentProjectID + "&frz=action&EnbRb=1";
        
        var ourl = self.parent.location.href;
        var n = ourl.indexOf("&IntStDate");
        if (n <= 0) {

            ourl += "&IntStDate=" + document.getElementById("hIntStDate");
            ourl += "&IntEdDate=" + document.getElementById("hIntEdDate");
        }
        url += "&txboxId=" + ourl;
        oprw(url);
    }
    function oprw(url) {
        var rWindow = document.getElementById("radManager");
        window.radopen(url, "Work Experience");
        return false;
    }
    function closeRadWindow()
    {

    }
</script>
</div>
<script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery.cookie.pack.js" type="text/javascript"></script>
<script src="../Scripts/jquery.pager.js" type="text/javascript"></script>
<script type="text/javascript" src="AssignedList.js"></script>
</asp:Content>

