<%@ Page Title="Assigned List & Training Cycle" Language="C#"    MasterPageFile="~/Candidate/Candidate.master" EnableEventValidation="false" AutoEventWireup="true" Inherits="EnableIndia.Training.AssignedList" Codebehind="AssignedList.aspx.cs" EnableViewState="true" %>
<%@ Register Assembly="Stimulsoft.Report.Web, Version=2013.1.1600.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a"
    Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellspacing="0" cellpadding="0" >
    <tr>
        <td class="pageHeader">Training Section</td>
    </tr>
</table>

<table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">
    <tr>
        <td>
            Manage Open Training Projects>>Step 3: Assigned List & Training Cycle 
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:280px;padding-left:12px">
              <asp:LinkButton ID="LnkBtnAddRecommendedCandidates" runat="server" Text="Step 1: Add Recommended Candidates"
                 CssClass="tab_links" OnClick="LnkBtnAddRecommendedCandidates_click"  TabIndex="1" />
        </td>
        <td style="width:280px">
             <asp:LinkButton ID="LnkBtnAddNonRecommendedCandidates" runat="server" Text="Step 2:Add Non-Recommended Candidates"
                CssClass="tab_links" OnClick="LnkBtnAddNonRecommendedCandidates_click" TabIndex="2" />
        </td>
    </tr>
</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<div>
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink" style="color:White">Assigned List & Training Cycle</span></h1>
        </td>
    </tr>
</table>

<table>
    <tr style="font-size:11px">
        <td style="padding-left:30px" class="readonly_bold_text">
            <span class="readonlyText">Training Program Name:</span>
        </td>
        <td>
            <span id="SpnTrainingProgramName" runat="server" class="readonlyText"></span>
        </td>
        <td style="padding-left:200px">
            <asp:Button ID="BtnCloseTrainingProject" runat="server" Visible="false"
                OnClientClick="javascript:return CheckProjectStatus();"
                Text="Update Data and Close Project" OnClick="BtnCloseTrainingProject_Click" TabIndex="4"  />
        </td>
        <td>
            <asp:Button ID="BtnViewCandidateCallingList" runat="server" Text="View Candidate Calling " 
                OnClientClick="javascript:ShowCandidateListPopup();return false;" TabIndex="5" />
        </td>
        <td >
            <asp:Button ID="BtnPrint" runat="server" Text="Print Candidate Calling" 
                OnClientClick-="javascript:return CheckCandidatesInCallingList();"
                onclick="BtnPrint_click" TabIndex="6" />
        </td>
    </tr>
</table>

<table>
    <tr style="font-size:11px">
        <td style="padding-left:30px" class="readonly_bold_text">
             <span class="readonlyText">Training Project Name:</span>
        </td>
        <td>
            <span id="SpnTrainingProjectName" runat="server" class="readonlyText"></span>
        </td>
    </tr>
</table>

<table>
    <tr style="font-size:11px">
        <td style="padding-left:30px" class="readonly_bold_text"> 
            <span class="readonlyText">Status of Training Project :</span>
        </td>
        <td>
            <span id="SpnTrainingProjectStatus" runat="server" class="readonlyText"></span>
        </td>
    </tr>
</table>

<table id="TblTextAssignlistCandidate" runat="server">
    <tr>
        <td style="font-weight:bold;width:600px;padding-left:30px">
           <u>Assigned List of Candidates for this Training Project and Related Training Cycle:</u>
        </td>
    </tr>
</table>

<table id="TblCandidateCaliingFromStep" runat="server" >
    <tr>
        <td style="padding-left:30px">
           <label for="ctl00_ContentPlaceHolder2_DdlCandidateCallingStep"> Add Candidates from a particular step to Candidate Calling by selecting the step here: </label> 
        </td>
        <td>
            <select id="DdlCandidateCallingStep" tabindex="7" runat="server" enableviewstate="true">
                <option value="-2">Select</option>
                <option value="1">Candidate confirmed to attend </option>
                <option value="2">Candidate passed evaluation</option>
                <option value="3">Candidate actually started attending training</option>
                <option value="4">Candidate completed training </option>
                <option value="5">Final Status</option>
                <option value="6">Grade</option>
                <option value="7">Certificate given to Candidate</option>
            </select>
        </td>
        <td>
            <asp:Button ID="BtnAddCandidateCallingFromStep" runat="server" 
                Text="Add to Candidate Calling from only this step " TabIndex="8"
                OnClientClick="javascript:if(validateStep()==true) return AddToCandidteCallingListFromStep();else return false;" />
        </td>
    </tr>
</table>

<table id="TblCloseParticularStep" runat="server">
    <tr>
        <td style="padding-left:30px">
            <label for="ctl00_ContentPlaceHolder2_DdlCloseOfParticularStep"> Edit a particular step for all Candidates at that step by selecting the step here:</label>
        </td>
        <td id="tde1" runat="server">
<%--                onchange="javascript:return DdlCloseOfParticularStep_SelectedIndexChanged();">--%>
            <asp:DropDownList runat="server" TabIndex="9" ID="DdlCloseOfParticularStep" EnableViewState="true" ClientIDMode="AutoID" AutoPostBack="true"  OnSelectedIndexChanged="ddCloseParticluarStepChanged">
                <asp:ListItem value="-2">Select</asp:ListItem>
                <asp:ListItem value="1">Candidate confirmed to attend </asp:ListItem>
                <asp:ListItem value="2">Candidate passed evaluation</asp:ListItem>
                <asp:ListItem value="3"> Candidate actually started attending training</asp:ListItem>
                <asp:ListItem value="4">Candidate completed training </asp:ListItem>
                <asp:ListItem value="5">Final Status</asp:ListItem>
                <asp:ListItem value="6">Grade</asp:ListItem>
                <asp:ListItem value="7">Certificate given to Candidate</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <label for="ctl00_ContentPlaceHolder2_DdlOutcomes">and outcome option here:</label>
        </td>
        <td id="tde2" runat="server">
            <asp:DropDownList runat="server" ID="DdlOutcomes" TabIndex="10" EnableViewState="true" ClientIDMode="AutoID">
                <asp:ListItem value="1">Confirmed to Attend</asp:ListItem>
                <asp:ListItem value="0" >Will not attend</asp:ListItem>
                <asp:ListItem value="1">Passed Evaluation</asp:ListItem>
                <asp:ListItem value="0">no</asp:ListItem>
                <asp:ListItem value="1">Started Attending</asp:ListItem>
                <asp:ListItem value="0">no</asp:ListItem>
                <asp:ListItem value="1">Completed</asp:ListItem>
                <asp:ListItem value="0">Incomplete</asp:ListItem>
                <asp:ListItem value="1">Pass</asp:ListItem>
                <asp:ListItem value="0">Fail</asp:ListItem>
                <asp:ListItem value="Excellent">Excellent</asp:ListItem>
                <asp:ListItem value="Very Good">Very Good</asp:ListItem>
                <asp:ListItem value="Satisfactory">Satisfactory</asp:ListItem>
                <asp:ListItem value="Needs Improvement">Needs Improvement</asp:ListItem>
                <asp:ListItem value="Waived">Waived</asp:ListItem>
                <asp:ListItem value="1">Yes</asp:ListItem>
                <asp:ListItem value="0">No</asp:ListItem>
                
            </asp:DropDownList>
        </td>
 <%--       OnClientClick="javascript:return CloseParticularList();
 --%>       <td>
            <asp:Button ID="BtnCloseOutcomes" runat="server" TabIndex="12" Text="Apply" OnClick="applyButtonClicked"   />
        </td>
    </tr>
</table>
   
<table style="margin-top:10px">
    <tr>
        <td style="padding-left:50px">
            <asp:Button ID="BtnAddToCandidateCalling" TabIndex="13" runat="server" Text="Add to candidate calling"
                OnClientClick="javascript:if(validateCheckBox()==true)return AddToCandidteCallingList();else return false;"
                OnClick="BtnAddToCandidateCalling_click" />
        </td>
        <td style="padding-left:30px">
            <asp:Button ID="BtnDeleteCandidates" TabIndex="14" runat="server" Text="Delete Candidates"
                OnClientClick="javascript:return confirm('Are you sure want to delete candidate?');if(validateCheckBox()==true)return ConfirmDelete();else return false;"
                OnClick="BtnDeleteCandidates_click" />
        </td>
    </tr>
</table>
<table>
    <tr>
        <td>
<table cellspacing="4" style="margin-top:10px">
    <tr>
        <td>
<%--            <asp:UpdatePanel runat="server" ID="updlvca" UpdateMode="Conditional">
                <ContentTemplate>--%>


            <asp:ListView ID="LstViewAssignedCandidateList" runat="server" 
                OnItemDataBound="LstViewAssignedCandidateList_ItemDataBound" >
                <LayoutTemplate>
              
                    <table id="TblViewAssignedCandidateList" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                            messagetext="Candidate" style="margin:10px; border-color:#800000; border-collapse:separate; border-width:1px;">
                        <thead>
                            <tr class="grid-header">
                                <th valign="bottom">
                                    <asp:CheckBox runat="server" ID="ChkSelectAllCandidates" title="Select All Candidates" ClientIDMode="AutoID"
                                     OnCheckedChanged="EnableDisAllCb" AutoPostBack="true" EnableViewState="true" />
                                <th align="right" valign="bottom">No.</th>
                                <th valign="bottom">Name</th>
                                <th valign="bottom">RID</th>
                                <th valign="bottom">Phone numbers</th>
                                <th valign="bottom">Disability</th>
                                <th valign="bottom">1) Candidate confirmed to attend </th>
                                <th valign="bottom">2)Candidate passed evaluation</th>
                                <%-- <th  valign="bottom"  >3) If 'Yes' in 2, then call candidate on day before training to
                                     remind candidate to attend training--whether Candidate confirmed to attend training</th>--%>
                                <th valign="bottom"> 3) Candidate actually started attending training (first time attendance)</th>
                                <th valign="bottom"> 4) Candidate completed training  </th>
                                <th valign="bottom">5) Final Status </th>
                                <th valign="bottom">6) Grade</th>
                                <th valign="bottom">7) Certificate given to Candidate</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
                        </tbody>                   
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr CandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'>
                        <td>
                            <asp:CheckBox ID="ChkRecommendedCandidateName" runat="server" 
                                CandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'
                                TrainProjGrpID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("assigned_training_project_id"))) %>'
                                OnCheckedChanged="EnableDropDown"  AutoPostBack="true" EnableViewState="true" ClientIDMode="AutoID" />
                            <label id="LblCandidateName" runat="server" class="skiplink">Select <%#Eval("candidate_name")%></label>
                        </td>
                        <td align="right" id="TdRecordNumber">
                        </td>
                        <td title="Name : <%#Eval("candidate_name")%>">
                            <a id="LnkBtnCandidateName" class="readonlyText" target="_blank" 
                                href='<%#"../Candidate/ProfileHistory/Registration.aspx?cand=" + EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("candidate_name")%></a>
                                     <div style="width:100%; display:table-row">
                                           <div style="width:50%; display:table-cell">
                                      <asp:ImageButton ID="BtnNotes" runat="server" title="Add Notes" AlternateText="Add Notes" 
                                           ImageAlign="AbsMiddle"
                                        CandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'
                                        ImageUrl="~/App_Themes/Default/images/add-notes.jpg"
                                        OnClick="BtnNotes_Click" ClientIDMode="AutoID"
                                          style="border-width:0px; height:12px; width:12px;" />
                                     </div>
                                           <div style="width:50%; display:table-cell">
                                        <asp:ImageButton ID="BtnGotJob" runat="server" title="Got Job"  AlternateText="Got Job"
                                             ImageAlign="AbsMiddle"
                                            CandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'
                                            ImageUrl="~/App_Themes/Default/images/got-job.jpg" 
                                            OnClick="BtnJobs_Click"   ClientIDMode="AutoID"
                                            style="border-width:0px;padding-left:5px;height:12px; width:12px;" />
                                     </div>
                                    </div>
                        </td>
                        <td title="<%#Eval("candidate_name") %>'s RID">
                          <a id="LnkBtnRegistrationID" class="readonlyText" target="_blank" 
                                href='<%#"../Candidate/ProfileHistory/AddViewCandidateHistory.aspx?cand=" + EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("registration_id")%></a>
                        </td>
                        <td title="<%#Eval("candidate_name") %>'s Phone Numbers"><%#Eval("phone_numbers") %></td>
                        <td title="<%#Eval("candidate_name") %>'s Disability"><%#Eval("disability_type")%></td>
                        <td Step="1" title="<%#Eval("candidate_name") %> confirmed to attend">
                            <select id="DdlConfirmedToAttendTraining" enableviewstate="true" runat="server" value='<%# Eval("confirmed_to_attend_training") %>'  
                                Step="1" title="Confirmed To Attend Training" disabled="disabled"
                                messagetext="Confirm to attend training" >
                                <option value="-2">Select</option>
                                <option value="1">Yes</option>
                                <option value="0"> No</option>
                            </select>
                        </td>
                        <td Step="2" title="<%#Eval("candidate_name") %>'s passed evaluation">
                            <select id="DdlPassedEvaluation" runat="server" enableviewstate="true" value='<%# Eval("passed_evaluation")  %>' 
                             messagetext="Passed evaluation" title="Passed evaluation" disabled="disabled" Step="2">
                                <option value="-2">Select</option>
                                <option value="1">Yes</option>
                                <option value="0">No</option>
                                <option value="2">NA</option>
                            </select>
                        </td>
                        <td Step="3" title="<%#Eval("candidate_name") %> actually started attending training">
                            <select id="DdlActuallyStartedAttendingTraining" runat="server" enableviewstate="true" value='<%# Eval("actually_started_attending_training") %>'
                                Step="3" disabled="disabled" title="Candidate Started attending training" messagetext="Started attending training">
                                <option value="-2">Select</option>
                                <option value="1">Yes</option>
                                <option value ="0">No</option>
                            </select>
                        </td>
                        <td Step="4" title="<%#Eval("candidate_name") %> completed training">
                            <select id="DdlCompletedTraining" runat="server" enableviewstate="true" value='<%# Eval("completed_training") %>'
                                Step="4" disabled="disabled" title="Candidate Completed Training" messagetext="Completed training">
                                <option value="-2">Select</option>
                                <option value="1">Yes</option>
                                <option value="0">No</option>
                            </select>
                        </td>
                        <td Step="5" title="<%#Eval("candidate_name") %>'s Final Status">
                            <select id="DdlPassedTraining" runat="server" enableviewstate="true" value='<%# Eval("passed_training") %>'
                                Step="5" disabled="disabled" title="Candidate Passed Training" messagetext="Passed training">
                                <option value="-2">Select</option>
                                <option value="1">Pass</option>
                                <option value="0">Fail</option>
                                <option value="2">NA</option>
                            </select>
                        </td>
                        <td Step="6" title="<%#Eval("candidate_name") %>'s Grade">
                            <select id="DdlGrade" runat="server" enableviewstate="true" value='<%#Eval("grade")%>' messagetext="Grade" title="Grade" 
                                disabled="disabled" Step="6">
                                <option value="-2">Select</option>
                                <option value="Excellent">Excellent</option>
                                <option value="Very Good">Very Good</option>
                                <option value="Satisfactory">Satisfactory</option>
                                <option value="Needs Improvement">Needs Improvement</option>
                                <option value="Waived">Waived</option>
                                <option value="NA">NA</option>
                            </select>
                        </td>
                        <td Step="7" title="Certificate given to <%#Eval("candidate_name") %>">
                            <select id="DdlReceivedCertificate" runat="server" enableviewstate="true" value='<%# Eval("received_cretificate")%>'
                                Step="7" disabled="disabled" title="Candidate Received Certificate" messagetext="Received Certificate">
                                <option value="-2">Select</option>
                                <option value="1">Yes</option>
                                <option value="0">No</option>
                                <option value="2">NA</option>
                            </select>
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
<%--                </ContentTemplate>
                  </asp:UpdatePanel>--%>
                    </td>
                </tr>

         </table>
             <table>
                <tr>
                    <td style="padding-left:400px">
                        <asp:Button ID="BtnSubmit" runat="server" Text="Submit"
                            OnClientClick="javascript:if(validateCheckBox()==true)return ValidateClass();else return false;"
                            OnClick="BtnSubmit_click" />
                    </td>
                     <td style="padding-left:5px">
                        <input id="BtnResetCandidate" runat="server" type="button" value="Reset"
                            onclick="javascript:return ResetCandidateDetail();" />
                        <%--<asp:Button ID="BtnResetCandidate" runat="server" Text="Reset" />--%>
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
            <label for="ctl00_ContentPlaceHolder2_TxtHiiddenSelectedStep">Selected Step</label>
            <asp:TextBox ID="TxtHiiddenSelectedStep" runat="server"  />
            <label for="ctl00_ContentPlaceHolder2_TxtIsParameterChanged">test</label>
            <asp:TextBox ID="TxtIsParameterChanged" runat="server"  />
            <label for="ctl00_ContentPlaceHolder2_TxtCandidatesInCandidateCallingList">test</label>
            <asp:TextBox ID="TxtCandidatesInCandidateCallingList" runat="server" Width="800px" />
            <asp:HiddenField runat="server" ID="lbRowNumber" />
            <asp:HiddenField runat="server" ID="hFieldPopup" />

            
        </td>
    </tr>
</table>
</div>
<div>
     <center>
     <div style="width:990px; height:650px;">
        <telerik:RadWindowManager runat="server" ID="radManager" EnableViewState="false" DestroyOnClose="true" VisibleOnPageLoad="false"  AutoSize="true" Top="0"  Height="680px" Width="900px" Modal="true"  CssClass="RadWindow">
        </telerik:RadWindowManager>
     </div>
     </center>
</div>
    <asp:HiddenField runat="server" ID="hField" />
<cc1:StiWebViewer ID="StiWebViewer1" runat="server" RenderMode="UseCache" ViewMode="WholeReport"
    Height="600px" Width="100%" ScrollBarsMode="true" Visible="false" />
<script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery.cookie.pack.js" type="text/javascript"></script>
<script src="../Scripts/jquery.pager.js" type="text/javascript"></script>
<script src="AssignedList.js?version=1" type="text/javascript"></script>
</asp:Content>

