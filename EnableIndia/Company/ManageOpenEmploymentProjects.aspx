<%@ Page Title="Open Employment Project" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Company.ManageOpenEmploymentProjects" Codebehind="ManageOpenEmploymentProjects.aspx.cs" ClientIDMode="Static" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td colspan="2" class="pageHeader">Company Section</td>
    </tr>
</table>
<table class="pageHeaderLevel1" cellspacing="0" cellpadding="0">
    <tr>
        <td colspan="2"  >Manage Open Employment Projects > Step 5: Interview List</td>
    </tr>
</table>
<table>
    <tr>
        <td>
            <asp:Button ID="BtnCompanyDetails" runat="server" Text="Company Detail"/>
        </td>
        <td>
            <asp:Button ID="BtnVacancyDetails" runat="server" Text="Vacancy Details" />
        </td>
        <td>
            <asp:Button ID="BtnEmploymentProjectDetails" runat="server" Text="Employment Project Details" />
        </td>
        <td>
            <asp:Button ID="BtnRecommnededCandidates" runat="server" Text="STEP 2: Recommended Candidate" />
        </td>
        <td>
            <asp:Button ID="BtnNonRecommendedCandidate" runat="server" Text="Non Recommended Candidate" />
        </td>
        <td>
            <asp:Button ID="BtnAssigned" runat="server" Text="Step 4:Assigned" />
        </td>
        <td>
            <asp:Button ID="SuccessfulCandidatesList" runat="server" Text="Step 6:Successful Candidates List" />
        </td>
    </tr>
 </table>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td class="skiplink">
            <h1><span id="skipToTop" class="skiplink">Interview List</span></h1>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td><h2 class="skiplink">Company Contacts</h2></td>
    </tr>
</table>

<table cellspacing="4">
    <tr>
        <td>
            <table class="readonlyText">
                <tr>
                    <td>
                         Parent Company Name: TCS <br />
                        Company Code: TCS-BLR-ECITY <br />
                        Vacancy Code: TCS-BLR-ECITY-RECEPTIONIST <br />
                        Employment Project Code: 12/12/2008 14:08 hrs <br />
                        Designation: Senior Receptionist <br />
                         Current Demand: 12<br />
                        Number of candidates in Assigned List: 0<br />
                        Number of candidates in Interview List: 3<br />
                        Number of candidates in Successful Candidates List: 0<br /><br />
                    </td>
                    <td>
                    <asp:Button id="Button1" runat="server" Text="Close this employment" />
   
                    </td>
                </tr>
            </table>
             Company Contacts for this Employment Project:<br /><br />
            <asp:ListView ID="LstViewCompanyContacts" runat="server">
                <LayoutTemplate>
                    <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                          bordercolor="#808080" border="1px">
                          <thead>
                                <tr class="grid-header">
                                    <td>Type of Contact</td>
                                    <td>Name of Contact in Company</td>
                                    <td>Designation</td>
                                    <td>Phone Number</td>
                                    <td>E-mail Address</td>
                                </tr>
                          </thead>
                          <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                
                 <ItemTemplate>
                    
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                        bordercolor="#808080" border="1px">
                        <thead>
                            <tr class="grid-header">
                                <th>Type of Contact</th>
                                <th>Name of Contact in Company</th>
                                <th>Designation</th>
                                <th>Phone Number</th>
                                <th>E-mail Address</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Regular</td>
                                <th>Sujatha Ramnathan</th>
                                <td>HR Manager</td>
                                <td>080-256678,9886754345</td>
                                <td>vasggasg</td>
                            </tr>
                            <tr>
                                <td>Primary</td>
                                <th>Hari Sadu</th>
                                <td>Operations Manager</td>
                                <td>080-4312541,8729712627277</td>
                                <td>gafgafsgag</td>
                            </tr>
                        </tbody>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td><span class="skiplink">Instruction text</span></td>
    </tr>
</table>

<%--<table>
    <tr>
        <td class="message">
            STEP 5:<br />
            This page displays all candidates who are successful at getting the job.<br />
            Close each step in the employment cycle using drop-down selection and hitting 'Submit'.<br />
            After closing all steps, you can close this Employment Project by hitting the 'Close this Employment Project' button.
            <a href="javascript:More_Click();" class="message">MORE HELP...</a><br />
        </td>
    </tr>
</table>--%>

<table style="margin-top:5px">
    <tr>
        <td style="font-weight:bold;text-decoration:underline">
            List of Successful Candidates for this Employment Project and Related Employment Cycle:
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
            <label for="ctl00_ContentPlaceHolder2_DdlAddCandidateFromAParticularStep">
                Add Candidates from a particular step to Candidate Calling by selecting the step here
            </label>
            <select id="DdlAddCandidateFromAParticularStep" runat="server">
                <option value="">Offer letter received by Candidate</option>
            </select>
            <asp:Button id="BtnSubmit" runat="server" Text="Add to Candidate calling from only this step" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
            <label for="ctl00_ContentPlaceHolder2_DdlCloseOffAParticularStep">
                Close off a particular step for all Candidates at that step by selecting the step here:
            </label>
            <select id="DdlCloseOffAParticularStep" runat="server">
                <option value="">Offer letter received by Candidate</option>
            </select>
             <label for="ctl00_ContentPlaceHolder2_DdlAndOutcomeOptionHere">
                And outcome option here
            </label>
            <select id="DdlAndOutcomeOptionHere" runat="server">
                <option value="">Offer letter received</option>
                <option value="">Not applicable</option>
            </select>
            <asp:Button id="BtnClose" runat="server" Text="Close" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
            <asp:Button ID="BtnAddToCandidateCalling" runat="server" Text="Add to Candidate Calling" />&nbsp;&nbsp;
            <asp:Button ID="BtnDeleteCandidates" runat="server" Text="Delete Candidates" OnClientClick="javascript:return confirm('Are you sure you want to delete following candidates: SMITA KHARE ');" />&nbsp;&nbsp;
            <asp:Button ID="BtnNotes" runat="server" Text="Notes" />&nbsp;&nbsp;
            <asp:Button ID="BtnReset" runat="server" Text="Reset" OnClientClick="javascript:return confirm('Are you sure you want to reset following candidates:  SMITA KHARE ');" />&nbsp;&nbsp;
            <asp:Button ID="BtnSelectAll" runat="server" Text="Select All" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td><h3 class="skiplink">Assigned Candidates Table</h3></td>
    </tr>
</table>

<table cellpadding="4">
    <tr>
        <td>
        <asp:ListView ID="LstViewManageOpenEmploymentProject" runat="server">
        <LayoutTemplate>
            <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                  bordercolor="#808080" border="1px">
                  <thead>
                        <tr class="grid-header">
                            <td></td>
                            <th>Name</th>
                            <th>R I D</th>
                            <th>Disability</th>
                            <th>Mark Phone on<br /> which reached</th>
                            <th>Offer letter received by candidate (CANDIDATE STATUS IS NOW EMPLOYED)</th>
                            <th>Get proof of employment from candidate</th>
                            <th>Update salary details into ERP system</th>
                            <th>Get candidate’s Joining Process from company</th>
                            <th>Follow up with candidates to meet requirements of joining process</th>
                            <th>Share workplace solution with company</th>
                            <th>Do workplace solution configuration</th>
                            <th>Coach company on how to train the candidate</th>                                    
                            <th>Peer Sensitization at the workplace</th>
                            <th>Inform NGO about candidate selection</th>
                            <th>If candidate is on contract, enter contract end date in Notes section.</th>
                            <th>Candidate is an intern (test-drive)</th>
                            <th>Candidate arrived at company on first day</th>
                            <th>Initial hand-holding for few days</th>
                            <th>Fill Retention Task data in Candidate History</th>
                            <th>Raise invoice for candidate</th>
                         </tr>
                   </thead>
                   <tbody>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                   </tbody>
              </table>
          </LayoutTemplate>
          
          <ItemTemplate>
          
          </ItemTemplate>
          
          <EmptyDataTemplate>
           <table id="TblCandidateList" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                bordercolor="#808080" border="1px">
                <thead>
                    <tr class="grid-header">
                            <th><span class="skiplink">Radio button for selecting row to update</span></th>
                            <th>Name</th>
                            <th>R I D</th>
                            <th>Disability</th>
                            <th>Mark Phone on<br /> which reached</th>
                            <th>Offer letter received by candidate (CANDIDATE STATUS IS NOW EMPLOYED)</th>
                            <th>Get proof of employment from candidate</th>
                            <th>Update salary details into ERP system</th>
                            <th>Get candidate’s Joining Process from company</th>
                            <th>Follow up with candidates to meet requirements of joining process</th>
                            <th>Share workplace solution with company</th>
                            <th>Do workplace solution configuration</th>
                            <th>Coach company on how to train the candidate</th>                                    
                            <th>Peer Sensitization at the workplace</th>
                            <th>Inform NGO about candidate selection</th>
                            <th>If candidate is on contract, enter contract end date in Notes section.</th>
                            <th>Candidate is an intern (test-drive)</th>
                            <th>Candidate arrived at company on first day</th>
                            <th>Initial hand-holding for few days</th>
                            <th>Fill Retention Task data in Candidate History</th>
                            <th>Raise invoice for candidate</th>
                    </tr>
                </thead>
                    <tbody>
                        <tr class="grid-row">
                                <td id="TdCheckbox">
                                    <asp:CheckBox ID="ChkSelectProject" runat="server" />
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_ChkSelectProject" class="skiplink">Select Shweta ALVA</label>
                                 </td>
                                <th>A12345</th>
                                <td style="white-space:nowrap">
                                    * Shweta ALVA&nbsp;
                                    <asp:Image ID="ImgBlueIcon" runat="server" ImageUrl="~/App_Themes/Default/images/Reminder.jpg" 
                                        ImageAlign="AbsMiddle" style="cursor:pointer" ToolTip="Add Notes" Height="15" Width="15"
                                        AlternateText="Add Notes" onclick="javascript:ShowAddNotesPopup();" />
                                </td>
                                <td>VI</td>
                                <td>(o)988888888,(o)080-2222222</td>
                                <td>
                                     <select id="DdlEducationCertificate" runat="server">
                                        <option value="">Offer letter received</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlEducationCertificate" class="skiplink">Shweta ALVA Confirm that education certificates are valid</label>
                                </td>
                                <td>
                                     <select id="DdlSendCandidatesProfile" runat="server">
                                        <option value="">Employment proof got</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlSendCandidatesProfile" class="skiplink">Shweta ALVA Send candidate’s profile/resume to company</label>
                                     
                                </td>
                                <td>
                                     <select id="DdlCommunicateCompanySchedule" runat="server">
                                        <option value="">Salary details updated</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                     <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlCommunicateCompanySchedule" class="skiplink">Shweta ALVA Communicate to company and schedule interviews, enter Interview date and time in the Notes section</label>
                                </td>
                                <td>
                                     <select id="DdlCallCandidateAboutInterview" runat="server">
                                        <option value="">Joining process got</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlCallCandidateAboutInterview" class="skiplink">Shweta ALVA Call candidate and inform about interview time (also check if they have been truthful in the resume)</label>
                                </td>
                                <td>
                                     <select id="DdlCoachedCandidate" runat="server">
                                        <option value="">Joining process requirements met</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlCoachedCandidate" class="skiplink">Shweta ALVA Coach candidate for the interview</label>
                                </td>
                                <td>
                                     <select id="DdlRemindCandidateResume" runat="server">
                                        <option value="">WPS shared with company</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlRemindCandidateResume" class="skiplink">Shweta ALVA Remind candidate to get resume, JAWS etc</label>
                                </td>
                                <td>
                                     <select id="DdlArrngeForExcort" runat="server">
                                        <option value="">WPS configured</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlArrngeForExcort" class="skiplink">Shweta ALVA Arrange for an escort for VI, or for a sign language interpreter for HI. Enter escort details in Notes section.</label>
                                </td>
                                <td>
                                      <select id="DdlInterviewDay" runat="server">
                                        <option value="">Company informed on how to train candidate</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlInterviewDay" class="skiplink">Shewta ALVA INTERVIEW DAY: Escort candidate to interview (help with commuting, show bus stop, remind about using mobility equipment, remind about using sign language, remind to demo JAWS, orient to place of work)</label>
                               </td>
                                <td>
                                       <select id="DdlCandidateGotInterviewed" runat="server">
                                        <option value="">peer sensitization done</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlCandidateGotInterviewed" class="skiplink">Shewta ALVA INTERVIEW DAY</label>
                                </td>
                                <td>
                                     <select id="DdlFollowUpWithCompany" runat="server">
                                           <option value="">NGO informed</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlFollowUpWithCompany" class="skiplink">Shweta ALVA Follow up with company about interview/ assessment outcome. Enter date for post-interview follow-up in Notes section.</label>
                                </td>
                                <td>
                                    <select id="DdlDidCandidateGetJob" runat="server">
                                           <option value="">Update contract detail</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlDidCandidateGetJob" class="skiplink">Shweta ALVA Did candidate get the job?</label>
                                 </td>
                                <td>
                                     <select id="DdlInformCandidateAboutSelection" runat="server">
                                           <option value="">Candidate internship done</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlInformCandidateAboutSelection" class="skiplink">Shweta ALVA Inform candidate about selection or non-selection</label>
                                </td>
                                <td>
                                     <select id="DdlCandidateConfirms" runat="server">
                                           <option value="">First day arrival happened</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlCandidateConfirms" class="skiplink">Shweta ALVA Candidate confirms about taking up the job</label>
                                 </td>
                                 <td>
                                     <select id="DdlInitialHandHolding" runat="server">
                                           <option value="">Initial hand holding</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlInitialHandHolding" class="skiplink">Shweta ALVA Initial Hand Holding for few days</label>
                                 </td>
                                 <td>
                                     <select id="DdlFillRetentionTaskData" runat="server">
                                           <option value="">Retention data entered</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlFillRetentionTaskData" class="skiplink">Shweta ALVA Fill retention task data in candidate history</label>
                                 </td>
                                 <td>
                                     <select id="DdlRaiseInvoiceForCandidate" runat="server">
                                           <option value="">InvoiceRaised</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_DdlRaiseInvoiceForCandidate" class="skiplink">Shweta ALVA raise invoice for candidate</label>
                                 </td>
                        </tr>
                        <tr class="grid-alternate-row">
                            <td id="TdCheckbox">
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_CheckBox1" class="skiplink">Select SMITA KHARE</label>
                            </td>
                            <th>N12300</th>
                            <td style="white-space:nowrap">
                                $ SMITA KHARE&nbsp;
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/Default/images/Reminder.jpg" 
                                        ImageAlign="AbsMiddle" style="cursor:pointer" ToolTip="Add Notes" Height="15" Width="15"
                                        AlternateText="Add Notes" onclick="javascript:ShowAddNotesPopup();" />
                            </td>
                            <td>VI</td>
                            <td>(o)98882345,(o)080-3122222</td>
                            <td>
                                     <select id="Select1" runat="server">
                                        <option value="">Offer letter received</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select1" class="skiplink">SMITA KHARE Confirm that education certificates are valid</label>
                                </td>
                                <td>
                                     <select id="Select2" runat="server">
                                        <option value="">Employment proof got</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select2" class="skiplink">SMITA KHARE Send candidate’s profile/resume to company</label>
                                     
                                </td>
                                <td>
                                     <select id="Select3" runat="server">
                                        <option value="">Salary details updated</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                     <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select3" class="skiplink">SMITA KHARE Communicate to company and schedule interviews, enter Interview date and time in the Notes section</label>
                                </td>
                                <td>
                                     <select id="Select4" runat="server">
                                        <option value="">Joining process got</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select4" class="skiplink">SMITA KHARE Call candidate and inform about interview time (also check if they have been truthful in the resume)</label>
                                </td>
                                <td>
                                     <select id="Select5" runat="server">
                                        <option value="">Joining process requirements met</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select5" class="skiplink">SMITA KHARE Coach candidate for the interview</label>
                                </td>
                                <td>
                                     <select id="Select6" runat="server">
                                        <option value="">WPS shared with company</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select6" class="skiplink">SMITA KHARE Remind candidate to get resume, JAWS etc</label>
                                </td>
                                <td>
                                     <select id="Select7" runat="server">
                                        <option value="">WPS configured</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select7" class="skiplink">SMITA KHARE Arrange for an escort for VI, or for a sign language interpreter for HI. Enter escort details in Notes section.</label>
                                </td>
                                <td>
                                      <select id="Select8" runat="server">
                                        <option value="">Company informed on how to train candidate</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select8" class="skiplink">SMITA KHARE INTERVIEW DAY: Escort candidate to interview (help with commuting, show bus stop, remind about using mobility equipment, remind about using sign language, remind to demo JAWS, orient to place of work)</label>
                               </td>
                                <td>
                                       <select id="Select9" runat="server">
                                        <option value="">peer sensitization done</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select9" class="skiplink">SMITA KHARE INTERVIEW DAY</label>
                                </td>
                                <td>
                                     <select id="Select10" runat="server">
                                           <option value="">NGO informed</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select10" class="skiplink">SMITA KHARE Follow up with company about interview/ assessment outcome. Enter date for post-interview follow-up in Notes section.</label>
                                </td>
                                <td>
                                    <select id="Select11" runat="server">
                                           <option value="">Update contract detail</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select11" class="skiplink">SMITA KHARE Did candidate get the job?</label>
                                 </td>
                                <td>
                                     <select id="Select12" runat="server">
                                           <option value="">Candidate internship done</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select12" class="skiplink">SMITA KHARE Inform candidate about selection or non-selection</label>
                                </td>
                                <td>
                                     <select id="Select13" runat="server">
                                           <option value="">First day arrival happened</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select13" class="skiplink">SMITA KHARE Candidate confirms about taking up the job</label>
                                 </td>
                                 <td>
                                     <select id="Select14" runat="server">
                                           <option value="">Initial hand holding</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select14" class="skiplink">SMITA KHARE Initial Hand Holding for few days</label>
                                 </td>
                                 <td>
                                     <select id="Select15" runat="server">
                                           <option value="">Retention data entered</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select15" class="skiplink">SMITA KHARE Fill retention task data in candidate history</label>
                                 </td>
                                 <td>
                                     <select id="Select16" runat="server">
                                           <option value="">InvoiceRaised</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select16" class="skiplink">SMITA KHARE raise invoice for candidate</label>
                                 </td>
                        </tr>
                        <tr class="grid-row">
                            <td id="TdCheckbox">
                                <asp:CheckBox ID="CheckBox2" runat="server" />
                                <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_CheckBox2" class="skiplink">Select Amit Desai</label>
                            </td>
                            <th>A23456</th>
                            <td style="white-space:nowrap">
                                * Amit Desai&nbsp;
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/App_Themes/Default/images/Reminder.jpg" 
                                        ImageAlign="AbsMiddle" style="cursor:pointer" ToolTip="Add Notes" Height="15" Width="15"
                                        AlternateText="Add Notes" onclick="javascript:ShowAddNotesPopup();" />
                            </td>
                            <td>PH</td>
                            <td>(o)988888888,(o)080-4122222</td>
                           <td>
                                     <select id="Select17" runat="server">
                                        <option value="">Offer letter received</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select17" class="skiplink">Amit Desai Confirm that education certificates are valid</label>
                                </td>
                                <td>
                                     <select id="Select18" runat="server">
                                        <option value="">Employment proof got</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select18" class="skiplink">Amit Desai Send candidate’s profile/resume to company</label>
                                     
                                </td>
                                <td>
                                     <select id="Select19" runat="server">
                                        <option value="">Salary details updated</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                     <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select19" class="skiplink">Amit Desai Communicate to company and schedule interviews, enter Interview date and time in the Notes section</label>
                                </td>
                                <td>
                                     <select id="Select20" runat="server">
                                        <option value="">Joining process got</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select20" class="skiplink">Amit Desai Call candidate and inform about interview time (also check if they have been truthful in the resume)</label>
                                </td>
                                <td>
                                     <select id="Select21" runat="server">
                                        <option value="">Joining process requirements met</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select21" class="skiplink">Amit Desai Coach candidate for the interview</label>
                                </td>
                                <td>
                                     <select id="Select22" runat="server">
                                        <option value="">WPS shared with company</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select22" class="skiplink">Amit Desai Remind candidate to get resume, JAWS etc</label>
                                </td>
                                <td>
                                     <select id="Select23" runat="server">
                                        <option value="">WPS configured</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select23" class="skiplink">Amit Desai Arrange for an escort for VI, or for a sign language interpreter for HI. Enter escort details in Notes section.</label>
                                </td>
                                <td>
                                      <select id="Select24" runat="server">
                                        <option value="">Company informed on how to train candidate</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select24" class="skiplink">Amit Desai INTERVIEW DAY: Escort candidate to interview (help with commuting, show bus stop, remind about using mobility equipment, remind about using sign language, remind to demo JAWS, orient to place of work)</label>
                               </td>
                                <td>
                                       <select id="Select25" runat="server">
                                        <option value="">peer sensitization done</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select25" class="skiplink">Amit Desai INTERVIEW DAY</label>
                                </td>
                                <td>
                                     <select id="Select26" runat="server">
                                           <option value="">NGO informed</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select26" class="skiplink">Amit Desai Follow up with company about interview/ assessment outcome. Enter date for post-interview follow-up in Notes section.</label>
                                </td>
                                <td>
                                    <select id="Select27" runat="server">
                                           <option value="">Update contract detail</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select27" class="skiplink">Amit Desai Did candidate get the job?</label>
                                 </td>
                                <td>
                                     <select id="Select28" runat="server">
                                           <option value="">Candidate internship done</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select28" class="skiplink">Amit Desai Inform candidate about selection or non-selection</label>
                                </td>
                                <td>
                                     <select id="Select29" runat="server">
                                           <option value="">First day arrival happened</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select29" class="skiplink">Amit Desai Candidate confirms about taking up the job</label>
                                 </td>
                                 <td>
                                     <select id="Select30" runat="server">
                                           <option value="">Initial hand holding</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select30" class="skiplink">Amit Desai Initial Hand Holding for few days</label>
                                 </td>
                                 <td>
                                     <select id="Select31" runat="server">
                                           <option value="">Retention data entered</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select31" class="skiplink">Amit Desai Fill retention task data in candidate history</label>
                                 </td>
                                 <td>
                                     <select id="Select32" runat="server">
                                           <option value="">InvoiceRaised</option>
                                            <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewManageOpenEmploymentProject_ctrl0_Select32" class="skiplink">Amit Desai raise invoice for candidate</label>
                                 </td>
                        </tr>
                    </tbody>
                </table>
          </EmptyDataTemplate>
        </asp:ListView>
        </td>
    </tr>
</table>
<%--
 <script src="ManageOpenEmploymentProjects.js" type="text/javascript">--%>
 <script src="ManageOpenEmolpymentProject.js" type="text/javascript">
    
    $(document).ready(function(){
        
        $("#TblEducationalQualifications tbody tr td[id='TdCheckbox']").each(function(){
            $(this).find("label").attr("id","Lbl" + $(this).find("input[type='checkbox']").attr("id"));
            $(this).find("label").attr("for",$(this).find("input[type='checkbox']").attr("id"));
        });
    });
    
    function More_Click() {
        ShowPopUp('ManageOpenEmploymentMoreHelp.htm','950','360');
    }

    

    function ShowAddNotesPopup()
    {
        ShowPopUp('AddNotesPopup.aspx','1110','660');
    }
</script>
    
</asp:Content>

