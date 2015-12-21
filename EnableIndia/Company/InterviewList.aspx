<%@ Page Title="Interview List" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Company.InterviewList" Codebehind="InterviewList.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
    <tr>    
        <td>    
            COMPANY SECTION
        </td>
    </tr>
</table>
<table>
    <tr>
        <td>
            Manage Open Employment Projects>>Step 4: Interview List
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:280px">
              <asp:LinkButton ID="LnkBtnAddRecommendedCandidates" runat="server" Text="Step 1: Add Recommended Candidates"
                PostBackUrl="~/Company/AddRecommendedCandidate.aspx" CssClass="tab_links" />
        </td>
        <td style="width:280px">
              <asp:LinkButton ID="LnkBtnAddNonRecommendedCandidates" runat="server" Text="Step 2: Add Non Recommended Candidates"
                PostBackUrl="~/Company/AddNonRecommendedCandidate.aspx" CssClass="tab_links" />
        </td>
        <td style="width:160px">
            <asp:LinkButton ID="LnkBtnAssignedList" runat="server" Text="Step 3: Assigned List"
                PostBackUrl="~/Company/AssignedList.aspx" CssClass="tab_links" />
        </td>
        <td style="width:230px">
            <asp:LinkButton ID="LnkBtnSuccessfulCandidateList" runat="server" Text="Step 5: Successful Candidate List"
                PostBackUrl="~/Company/SuccessfulCandidateList.aspx" CssClass="tab_links" />
        </td>
    </tr>
</table>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table>
    <tr>
        <td class="readonlyText">
            Parent Company Name: TCS<br />
            Company Code: TCS-BLR-ECITY<br />
            Vacancy Code: TCS-BLR-ECITY-RECEPTIONIST<br />
            Employment Project Code: 12/12/2008 14:08 hrs<br />
            Designation: Senior Receptionist<br />
            Current Demand: 12<br />
            Number of candidates in Assigned List: 0<br />
            Number of candidates in Interview List: 3<br />
            Number of candidates in Successful Candidates List: 0
        </td>
    </tr>
</table>

<table>
    <tr>
        <td class="readonlyText">
            <u>Company Contacts for this Employment Project:</u>
        </td>
    </tr>
</table>

<table cellspacing="4">
    <tr>
        <td>
             <asp:ListView ID="LstViewInterviewListCompanyContacts" runat="server">
                <LayoutTemplate>
                     <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                           bordercolor="#808080" border="1px" summary="Interview List Details">
                           <thead>
                                <tr class="readonlyText">
                                    <th>Type of Contact</th>
                                    <th>Name of Contact in Company</th>
                                    <th>Designation</th>
                                    <th>Phone Number</th>
                                    <th>E-mail Address</th>
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
                        bordercolor="#808080" border="1px" summary="Interview list">
                        <thead>
                            <tr class="readonlyText">
                                <th>Type of Contact</th>
                                <th>Name of Contact in Company</th>
                                <th>Designation</th>
                                <th>Phone Number</th>
                                <th>E-mail Address</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr style="font-weight:normal" class="readonlyText">
                                <td>Regular</td>
                                <td>Sujatha Ramnathan</td>
                                <td>HR Manager</td>
                                <td>080-256678, 9886754345</td>
                                <td>vasggasg</td>
                            </tr>
                            <tr style="font-weight:normal" class="readonlyText">
                                <td>Regular</td>
                                <td>Hari Sadu</td>
                                <td>Operations Manager</td>
                                <td>080-4312541, 8729712627277</td>
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
        <td class="message">
            STEP  4:<br />
            This page displays all assigned candidates who are interested in the job.<br />
            Close each step in the employment cycle using drop-down selection and hitting 'Submit'. 
             <a href="javascript:More_Click();" class="message">MORE HELP...</a><br />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
           <u> Interview List of Candidates for this Employment Project and Related Employment Cycle:</u>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:300px">
            <label for="ctl00_ContentPlaceHolder2_DdlAddCandidateForAParticularStep">
                Add Candidates from a particular step to Candidate Calling by selecting the step here: 
            </label>
        </td>
        <td>
            <select id="DdlAddCandidateForAParticularStep" runat="server">
                <option value="">Confirm that Education Certificates are valid</option>
            </select>
        </td>
        <td>
            <asp:Button ID="BtnAddToCandidateCallingOnlyThisStep" Width="250px" Text="Add To Candidate Calling Only This Step" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:255px">
            <label for="ctl00_ContentPlaceHolder2_DdlCloseOffAParticularStepForAllCandidates">
                Close off a particular step for all Candidates at that step by selecting the step here: 
            </label>
        </td>
        <td>
             <select id="DdlCloseOffAParticularStepForAllCandidates" runat="server">
                <option value="">Confirm that Education Certificates are valid</option>
            </select>
        </td>
        <td>
            <label for="ctl00_ContentPlaceHolder2_DdlAndOutcomeOptionHere">and outcome option here:</label>
        </td>
        <td>
            <select id="DdlAndOutcomeOptionHere" runat="server">
                <option value="">Yes</option>
                <option value="">Will Not</option>
            </select>
        </td>
        <td>
            <asp:Button ID="BtnClose" Text="Close" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
            <asp:Button ID="BtnAddToCandidateCalling" Text="Add to Candidate Calling" runat="server" />
        </td>
        <td>
            <asp:Button ID="BtnDeleteCandate" Text="Delete Candidate" runat="server" />
        </td>
        <td>
            <asp:Button ID="BtnReset" Text="Reset" runat="server" />
        </td>
        <td>
            <asp:Button ID="BtnNotes" Text="Notes" runat="server" />
        </td>
        <td>
            <asp:Button ID="BtnSelectAll" Text="Select All" runat="server" />
        </td>
    </tr>
</table>

<table cellpadding="4">
    <tr>
        <td>
        <asp:ListView ID="LstViewInterviewList" runat="server">
        <LayoutTemplate>
            <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                  bordercolor="#808080" border="1px">
                  <thead>
                        <tr class="grid-header">
                            <td></td>
                                <th>R I D</th>
                                <th>Name</th>
                                <th>Disability</th>
                                <th>Mark Phone on<br /> which reached</th>
                                <th>Confirm that <br />education certificates<br /> are valid</th>
                                <th>Send candidate’s <br /> profile/resume <br />to company</th>
                                <th>Communicate to <br />company and schedule <br />interviews, enter <br /> Interview date and time<br /> in the Notes section</th>
                                <th>Call candidate <br />and inform about <br />interview time <br />(also check if they <br />have been truthful in<br /> the resume)</th>
                                <th>Coach candidate for<br /> the interview</th>
                                <th>Remind candidate<br /> to get resume,<br /> JAWS etc</th>
                                <th> Arrange for an<br /> escort for VI,<br /> or for a sign language<br /> interpreter for HI.<br /> Enter escort details <br />in Notes section.</th>
                                <th>INTERVIEW DAY: <br />Escort candidate to<br /> interview (help with<br /> commuting, show bus <br />stop, remind about <br />using mobility equipment,<br /> remind about using <br />sign language, remind <br />to demo JAWS, orient<br /> to place of work)</th>                                    
                                <th>Interview: Candidate got <br />interviewed/assessed </th>
                                <th>Follow up with <br />company about interview/<br /> assessment outcome. Enter<br /> date for post-interview<br /> follow-up in Notes <br />section.</th>
                                <th>Did candidate get<br /> the job?</th>
                                <th>Inform candidate about <br />selection or non-selection</th>
                                <th> Candidate confirms about<br /> taking up the job</th>
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
           <table id="TblInterViewList" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                bordercolor="#808080" border="1px">
                <thead>
                    <tr class="grid-header">
                            <th><span class="skiplink">Radio button for selecting row to update</span></th>
                            <th>R I D</th>
                            <th>Name</th>
                            <th>Disability</td>
                            <th>Mark Phone on<br /> which reached</th>
                            <th>Confirm that <br />education certificates<br /> are valid</th>
                            <th>Send candidate’s <br /> profile/resume <br />to company</th>
                            <th>Communicate to <br />company and schedule <br />interviews, enter <br /> Interview date and time<br /> in the Notes section</th>
                            <th>Call candidate <br />and inform about <br />interview time <br />(also check if they <br />have been truthful in<br /> the resume)</th>
                            <th>Coach candidate for<br /> the interview</th>
                            <th>Remind candidate<br /> to get resume,<br /> JAWS etc</th>
                            <th> Arrange for an<br /> escort for VI,<br /> or for a sign language<br /> interpreter for HI.<br /> Enter escort details <br />in Notes section.</th>
                            <th>INTERVIEW DAY: <br />Escort candidate to<br /> interview (help with<br /> commuting, show bus <br />stop, remind about <br />using mobility equipment,<br /> remind about using <br />sign language, remind <br />to demo JAWS, orient<br /> to place of work)</th>                                    
                            <th>Interview: Candidate got <br />interviewed/assessed </th>
                            <th>Follow up with <br />company about interview/<br /> assessment outcome. Enter<br /> date for post-interview<br /> follow-up in Notes <br />section.</th>
                            <th>Did candidate get<br /> the job?</th>
                            <th>Inform candidate about <br />selection or non-selection</th>
                            <th> Candidate confirms about<br /> taking up the job</th>
                    </tr>
                </thead>
                    <tbody>
                        <tr class="grid-row">
                                <td id="TdCheckbox">
                                    <asp:CheckBox ID="ChkSelectProject" runat="server" />
                                    <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_ChkSelectProject" class="skiplink">Select Shweta ALVA</label>
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
                                        <option value="">Certificate are Valid</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DdlEducationCertificate" class="skiplink">Shweta ALVA Confirm that education certificates are valid</label>
                                </td>
                                <td>
                                     <select id="DdlSendCandidatesProfile" runat="server">
                                        <option value="">Resume sent</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DdlSendCandidatesProfile" class="skiplink">Shweta ALVA Send candidate’s profile/resume to company</label>
                                </td>
                                <td>
                                      <select id="DdlCommunicateCompanySchedule" runat="server">
                                        <option value="">Interview details entered</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                     <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DdlCommunicateCompanySchedule" class="skiplink">Shweta ALVA Communicate to company and schedule interviews, enter Interview date and time in the Notes section</label>
                                </td>
                                <td>
                                      <select id="DdlCallCandidateAboutInterview" runat="server">
                                        <option value="">Candidate informed about interview and Resume details checked</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DdlCallCandidateAboutInterview" class="skiplink">Shweta ALVA Call candidate and inform about interview time (also check if they have been truthful in the resume)</label>
                                </td>
                                <td>
                                     <select id="DdlCoachedCandidate" runat="server">
                                        <option value="">Coached for Interview</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DdlCoachedCandidate" class="skiplink">Shweta ALVA Coach candidate for the interview</label>
                                </td>
                                <td>
                                     <select id="DdlRemindCandidateResume" runat="server">
                                        <option value="">Candidate reminded to get Resume</option>
                                        <option value="">JAWS</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DdlRemindCandidateResume" class="skiplink">Shweta ALVA Remind candidate to get resume, JAWS etc</label>
                                </td>
                                <td>
                                      <select id="DdlArrngeForExcort" runat="server">
                                        <option value="">Escort/ interpreter details entered</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DdlArrngeForExcort" class="skiplink">Shweta ALVA Arrange for an escort for VI, or for a sign language interpreter for HI. Enter escort details in Notes section.</label>
                                </td>
                                <td>
                                      <select id="DdlInterviewDay" runat="server">
                                        <option value="">Candidate escorted and oriented</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DdlInterviewDay" class="skiplink">Shewta ALVA INTERVIEW DAY: Escort candidate to interview (help with commuting, show bus stop, remind about using mobility equipment, remind about using sign language, remind to demo JAWS, orient to place of work)</label>
                               </td>
                                <td>
                                     <select id="DdlCandidateGotInterviewed" runat="server">
                                        <option value="">Candidate got interviewed</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DdlCandidateGotInterviewed" class="skiplink">Shewta ALVA INTERVIEW DAY</label>
                                </td>
                                <td>
                                      <select id="DdlFollowUpWithCompany" runat="server">
                                        <option value="">Follow-up done</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DdlFollowUpWithCompany" class="skiplink">Shweta ALVA Follow up with company about interview/ assessment outcome. Enter date for post-interview follow-up in Notes section.</label>
                                </td>
                                <td>
                                      <select id="DdlDidCandidateGetJob" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DdlDidCandidateGetJob" class="skiplink">Shweta ALVA Did candidate get the job?</label>
                                 </td>
                                <td>
                                       <select id="DdlInformCandidateAboutSelection" runat="server">
                                        <option value="">Candidate informed about selection/ non-selection</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DdlInformCandidateAboutSelection" class="skiplink">Shweta ALVA Inform candidate about selection or non-selection</label>
                                </td>
                                <td>
                                     <select id="DdlCandidateConfirms" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DdlCandidateConfirms" class="skiplink">Shweta ALVA Candidate confirms about taking up the job</label>
                                 </td>
                        </tr>
                        <tr class="grid-alternate-row">
                            <td id="TdCheckbox">
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_CheckBox1" class="skiplink">Select SMITA KHARE</label>
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
                                 <select id="DropDownList3" runat="server">
                                        <option value="">Certificate are Valid</option>
                                        <option value="">Not Applicable</option>
                                     </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList3" class="skiplink">SMITA KHARE Confirm that education certificates are valid</label>
                            </td>
                            <td>
                                 <select id="DropDownList4" runat="server">
                                        <option value="">Resume sent</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList4" class="skiplink">SMITA KHARE Send candidate’s profile/resume to company</label>
                            </td>
                            <td>
                                 <select id="DropDownList5" runat="server">
                                        <option value="">Interview details entered</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList5" class="skiplink">SMITA KHARE Communicate to company and schedule interviews, enter Interview date and time in the Notes section</label>
                            </td>
                            <td>
                                 <select id="DropDownList6" runat="server">
                                        <option value="">Candidate informed about interview and Resume details checked</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList6" class="skiplink">SMITA KHARE Communicate</label>
                            </td>
                            <td>
                                 <select id="DropDownList7" runat="server">
                                        <option value="">Coached for Interview</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList7" class="skiplink">SMITA KHARE Coach candidate for the interview</label>
                            </td>
                            <td>
                                 <select id="DropDownList8" runat="server">
                                        <option value="">Candidate reminded to get Resume</option>
                                        <option value="">JAWS</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList8" class="skiplink">SMITA KHARE Remind candidate to get resume, JAWS etc</label>
                            </td>
                            <td>
                                  <select id="DropDownList9" runat="server">
                                        <option value="">Escort/ interpreter details entered</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList9" class="skiplink">SMITA KHARE Arrange for an escort for VI, or for a sign language interpreter for HI. Enter escort details in Notes section.</label>
                            </td>
                            <td>
                                 <select id="DropDownList10" runat="server">
                                        <option value="">Candidate escorted and oriented</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList10" class="skiplink">SMITA KHARE INTERVIEW DAY: Escort candidate to interview (help with commuting, show bus stop, remind about using mobility equipment, remind about using sign language, remind to demo JAWS, orient to place of work)</label>
                           </td>
                            <td>
                                 <select id="DropDownList11" runat="server">
                                        <option value="">Candidate got interviewed</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList11" class="skiplink">SMITA KHARE Interview: Candidate got interviewed/assessed</label>
                            </td>
                            <td>
                                  <select id="DropDownList12" runat="server">
                                        <option value="">Follow-up done</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList12" class="skiplink">SMITA KHARE Follow up with company about interview/ assessment outcome. Enter date for post-interview follow-up in Notes section.</label>
                            </td>
                            <td>
                                  <select id="DropDownList13" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList13" class="skiplink">SMITA KHARE Did candidate get the job?</label>
                             </td>
                            <td>
                                   <select id="DropDownList14" runat="server">
                                        <option value="">Candidate informed about selection/ non-selection</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList14" class="skiplink">SMITA KHARE Inform candidate about selection or non-selection</label>
                            </td>
                            <td>
                                  <select id="DropDownList15" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList15" class="skiplink">SMITA KHARE Candidate confirms about taking up the job</label>
                             </td>
                        </tr>
                        <tr class="grid-row">
                            <td id="TdCheckbox">
                                <asp:CheckBox ID="CheckBox2" runat="server" />
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_CheckBox2" class="skiplink">Select Amit Desai</label>
                            </td>
                            <th>A23456</th>
                            <td style="white-space:nowrap">
                                * Amit Desai&nbsp;
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/App_Themes/Default/images/Reminder.jpg" 
                                        ImageAlign="AbsMiddle" style="cursor:pointer" ToolTip="Add Notes" Height="15" Width="15"
                                        AlternateText="Add Notes" onclick="javascript:ShowAddNotesPopup();" />
                            </td>
                            <td>PH</td>
                            <td>(o)988888888,(o)080-4444444</td>
                            <td>
                                 <select id="DropDownList16" runat="server">
                                        <option value="">Certificate are Valid</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList16" class="skiplink">Amit Desai Confirm that education certificates are valid</label>
                            </td>
                            <td>
                                 <select id="DropDownList17" runat="server">
                                        <option value="">Resume sent</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList17" class="skiplink">Amit Desai Send candidate’s profile/resume to company</label>
                            </td>
                            <td>
                                  <select id="DropDownList18" runat="server">
                                        <option value="">Interview details entered</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList18" class="skiplink">Amit Desai Communicate to company and schedule interviews, enter Interview date and time in the Notes section</label>
                            </td>
                            <td>
                                 <select id="DropDownList19" runat="server">
                                        <option value="">Candidate informed about interview and Resume details checked</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList19" class="skiplink">Amit Desai Call candidate and inform about interview time (also check if they have been truthful in the resume)</label>
                            </td>
                            <td>
                                 <select id="DropDownList20" runat="server">
                                        <option value="">Coached for Interviewd</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList20" class="skiplink">mit Desai Coach candidate for the interview</label>
                            </td>
                            <td>
                                 <select id="DropDownList21" runat="server">
                                        <option value="">Candidate reminded to get Resume</option>
                                        <option value="">JAWS</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList21" class="skiplink">Amit Desai Remind candidate to get resume, JAWS etc</label>
                            </td>
                            <td>
                                  <select id="DropDownList22" runat="server">
                                        <option value="">Escort/ interpreter details entered</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList22" class="skiplink">Amit Desai Arrange for an escort for VI, or for a sign language interpreter for HI. Enter escort details in Notes section.</label>
                            </td>
                            <td>
                                 <select id="DropDownList23" runat="server">
                                        <option value="">Candidate escorted and oriented</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList23" class="skiplink">Amit Desai INTERVIEW DAY: Escort candidate to interview (help with commuting, show bus stop, remind about using mobility equipment, remind about using sign language, remind to demo JAWS, orient to place of work)</label>
                           </td>
                            <td>
                                 <select id="DropDownList24" runat="server">
                                        <option value="">Candidate got interviewed</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList24" class="skiplink">Amit Desai Interview: Candidate got interviewed/assessed </label>
                            </td>
                            <td>
                                   <select id="DropDownList25" runat="server">
                                        <option value="">Follow-up done</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList25" class="skiplink">Amit Desai Follow up with company about interview/ assessment outcome. Enter date for post-interview follow-up in Notes section.</label>
                            </td>
                            <td>
                                   <select id="DropDownList26" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList26" class="skiplink">Amit Desai Did candidate get the job?</label>
                             </td>
                            <td>
                                  <select id="DropDownList27" runat="server">
                                        <option value="">Candidate informed about selection/ non-selection</option>
                                        <option value="">Not Applicable</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList27" class="skiplink">Amit Desai Inform candidate about selection or non-selection</label>
                            </td>
                            <td>
                                 <select id="DropDownList28" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                 </select>
                                <label for="ctl00_ContentPlaceHolder2_LstViewInterviewList_ctrl0_DropDownList28" class="skiplink">Amit Desai Candidate confirms about taking up the job</label>
                             </td>
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
        <td>
            <asp:Button ID="BtnSubmit" Text="Submit" runat="server" />
        </td>
    </tr>
</table>

<script type="text/javascript">
    function More_Click() {
        ShowPopUp('InterviewListMoreHelp.htm','950','360');
    }
</script>
</asp:Content>

