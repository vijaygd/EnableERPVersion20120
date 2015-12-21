<%@ Page Title="Assigned List Training Cycle" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Training.TrainingProjectAssignedListTrainingCycle" Codebehind="TrainingProjectAssignedListTrainingCycle.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
    <tr>
        <td colspan ="2" class="pageHeader">
            Training Section
        </td>
    </tr>
</table>
<table class="pageHeaderLevel1">
    <tr>
        <td colspan="2">
            Manage Open Training Projects>>Step 3: Assigned List & Training Cycle
        </td>
    </tr>
</table>
<table>
    <tr>
       <td style="padding-left:21px">
           <asp:LinkButton ID="LnkBtnProgramDetails" runat="server" Text="Program Details"
                PostBackUrl="~/Candidate/ProfileHistory/EducationalQualifications.aspx" 
                CssClass="tab_links" />
       </td>
    </tr>
</table>

<table>
    <tr>
        <td style="padding-left:21px">
            <asp:LinkButton ID="LnkBtnStepOneAddRecommendedCandidates" runat="server" Text="Step 1: Add Recommended Candidates"
                PostBackUrl="~/Training/TrainingProjectsAddRecommendedCandidates.aspx"
                CssClass="tab_links" />
        </td>
        
        <td style="padding-left:21px">
            <asp:LinkButton ID="LnkBtnStepThreeAssignedList" runat="server" Text="Step 2: Add Non-Recommended Candidates"
                PostBackUrl="~/Training/TrainingProjectsNonRecomendedCandidates.aspx" CssClass="tab_links" />
        </td>
    </tr>
</table>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<table class="readonlyText">
    <tr>
        <td>
            Training Program Instance: Computer Basics 12/11/2008 to 30/11/2008 from 4 pm to 8 pm <br />
            Status of Training Project: Assigned
            
        </td>
        <td>
            <asp:Button ID="BtnCloseThisTrainingProject" Text="Close This Training Project" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td class="message">
            This page displays all candidates assigned for this Training Project.<br />
            You can manage the Training Cycle for all candidates assigned to this Training Project, <br />
            by serially closing the steps in the Training Cycle for each candidate by using radio-button selection.
             <a href="javascript:More_Click();" class="message">MORE HELP...</a><br />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
           <b><u>Assigned List of Candidates for this Training Project and Related Training Cycle</u></b>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px">
            <label for="ctl00_ContentPlaceHolder2_DdlAddCandidatesFromParticular">Add Candidates from a particular step to Candidate Calling by selecting the step here</label>
        </td>
        <td>
            <select id="DdlAddCandidatesFromParticular" runat="server">
                <option value="">1) Whether Candidate confirmed to attend training</option>
            </select>
        </td>
        <td>
            <asp:Button ID="BtnAddToCandidateCallingFromOnlyThisStep" Width="270px" Text="Add To Candiate Calling From Only This Step" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px">
            <label for="ctl00_ContentPlaceHolder2_DdlCloseOffParticularStep">Close off a particular step for all Candidates at that step by selecting the step here</label>
        </td>
        <td>
            <select id="DdlCloseOffParticularStep" runat="server">
                <option value="">1) Whether Candidate confirmed to attend training</option>
            </select>
        </td>
        <td>
            <label for="ctl00_ContentPlaceHolder2_DdlOutcomeOptionHere"> and outcome option here</label>
        </td>
        <td>
            <select id="DdlOutcomeOptionHere" runat="server">
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
            <asp:Button ID="BtnSelectAll" Text="Select All" runat="server" />
        </td>
        <td>
            <asp:Button ID="BtnAddToCandidateCalling" Text="Add To Candidate Calling" runat="server" />
        </td>
        <td>
            <asp:Button ID="BtnDeleteCandiates" Text="Delete Candidates" runat="server" />
        </td>
        <td>
            <asp:Button ID="BtnReset" Text="Reset" runat="server" />
        </td>
        <td>
            <asp:Button ID="BtnAddGotJobDetails" Text="Add Got Job Details" runat="server" />
        </td>
    </tr>
</table>

<table cellpadding="4">
    <tr>
        <td>
        <asp:ListView ID="LstViewAssignedListTrainingCycle" runat="server">
        <LayoutTemplate>
            <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                  bordercolor="#808080" border="1px">
                  <thead>
                        <tr class="grid-header">
                            <td></td>
                            <th>Name</th>
                            <th>R I D</th>
                            <th>Mark Phone on which reached</th>
                            <th>1) Whether Candidate confirmed to attend training </th>
                            <th>2) If 'Yes' in 1, then call candidate on day before training to remind candidate to attend training--whether Candidate confirmed to attend training</th>
                            <th>START OF PROJECT: 3) If 'Yes' in 2, then whether candidate actually started attending training (first time attendance)</th>
                            <th>COMPLETION  OF PROJECT:4) If 'Yes' in 3, whether candidate completed training </th>
                            <th>5) Final Status</th>
                            <th>Grade</th>
                            <th>Certificate given to Candidate</th>
                            <th>Comments</th>
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
           <table id="TblAssignedListTrainingCycle" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                bordercolor="#808080" border="1px">
                <thead>
                    <tr class="grid-header">
                            <th><span class="skiplink">Checkbox for selecting row to update</span></th>
                            <th>Name</th>
                            <th>R I D</th>
                            <th>Mark Phone on which reached</th>
                            <th>1) Whether Candidate confirmed to attend training </th>
                            <th>2) If 'Yes' in 1, then call candidate on day before training to remind candidate to attend training--whether Candidate confirmed to attend training</th>
                            <th>START OF PROJECT: 3) If 'Yes' in 2, then whether candidate actually started attending training (first time attendance)</th>
                            <th>COMPLETION  OF PROJECT:4) If 'Yes' in 3, whether candidate completed training </th>
                            <th>5) Final Status</th>
                            <th>Grade</th>
                            <th>Certificate given to Candidate</th>
                            <th>Comments</th>
                    </tr>
                </thead>
                    <tbody>
                        <tr class="grid-row">
                                <td id="TdCheckbox1">
                                    <asp:CheckBox ID="ChkSelectProject1" runat="server" />
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_ChkSelectProject1" class="skiplink">Select Shweta ALVA</label>
                                 </td>
                                <th>A12345</th>
                                <td style="white-space:nowrap">
                                    * Shweta ALVA&nbsp;
                                </td>
                                <td>(o)988888888,(o)080-2222222</td>
                                <td>
                                     <select id="DdlCandidateConfirmedToAttendTraining" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">Will Not</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_DdlCandidateConfirmedToAttendTraining" class="skiplink">Shweta ALVA Confirm To attend training</label>
                                </td>
                                <td>
                                     <select id="DdlCallCandidateOnDayBeforeTraining" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">Will Not</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_DdlCallCandidateOnDayBeforeTraining" class="skiplink">Shweta ALVA comunicates to company to attend the trainig</label>
                                </td>
                                <td>
                                     <select id="DdlStartOfProject" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_DdlStartOfProject" class="skiplink">Shweta ALVA Started the training</label>
                                </td>
                                 <td>
                                     <select id="DdlCompletionOfProject" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_DdlCompletionOfProject" class="skiplink">Shweta ALVA completed the training</label>
                                </td>
                                 <td>
                                     <select id="DdlFinalStatusOfProject" runat="server">
                                        <option value="">Pass</option>
                                        <option value="">Fail</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_DdlFinalStatusOfProject" class="skiplink">Shweta ALVA's final status pass or fail</label>
                                </td>
                                <td>
                                     <select id="DdlGrade" runat="server">
                                        <option value="">G1</option>
                                        <option value="">G2</option>
                                        <option value="">G3</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_DdlGrade" class="skiplink">Shweta ALVA's grade</label>
                                </td>
                                <td>
                                     <select id="DdlCertificateGivenToCandidate" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_DdlCertificateGivenToCandidate" class="skiplink">Shweta ALVA has given a certificate</label>
                                </td>
                                
                                <td>
                                </td>
                        </tr>
                         <tr class="grid-row">
                                <td id="TdCheckbox2">
                                    <asp:CheckBox ID="ChkSelectProject2" runat="server" />
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_ChkSelectProject2" class="skiplink">Select Smita Khare</label>
                                 </td>
                                <th>N12300</th>
                                <td style="white-space:nowrap">
                                    # Smita Khare&nbsp;
                                </td>
                                <td>(o)98882345,(o)080-3122222</td>
                                <td>
                                     <select id="Select1" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">Will Not</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_Select1" class="skiplink">Smita Khare Confirm To attend training</label>
                                </td>
                                <td>
                                     <select id="Select2" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">Will Not</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_DdlCallCandidateOnDayBeforeTraining" class="skiplink">Smita Khare comunicates to company to attend the trainig</label>
                                </td>
                                <td>
                                     <select id="Select3" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_DdlStartOfProject" class="skiplink">Smita Khare Started the training</label>
                                </td>
                                 <td>
                                     <select id="Select4" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_DdlCompletionOfProject" class="skiplink">Smita Khare completed the training</label>
                                </td>
                                 <td>
                                     <select id="Select5" runat="server">
                                        <option value="">Pass</option>
                                        <option value="">Fail</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_DdlFinalStatusOfProject" class="skiplink">Smita Khare's final status pass or fail</label>
                                </td>
                                <td>
                                     <select id="Select6" runat="server">
                                        <option value="">G1</option>
                                        <option value="">G2</option>
                                        <option value="">G3</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_DdlGrade" class="skiplink">Smita Khare's grade</label>
                                </td>
                                <td>
                                     <select id="Select7" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_DdlCertificateGivenToCandidate" class="skiplink">Smita Khare has given a certificate</label>
                                </td>
                                
                                <td>
                                </td>
                        </tr>
                        
                         <tr class="grid-row">
                                <td id="TdCheckbox3">
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_CheckBox1" class="skiplink">Select Amit Desai</label>
                                 </td>
                                <th>A23456</th>
                                <td style="white-space:nowrap">
                                    Amit Desai&nbsp;
                                </td>
                                <td>(o)988888888,(o)080-4122222</td>
                                <td>
                                     <select id="Select8" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">Will Not</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_Select8" class="skiplink">Amit Desai Confirm To attend training</label>
                                </td>
                                <td>
                                     <select id="Select9" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">Will Not</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_Select9" class="skiplink">Amit Desai comunicates to company to attend the trainig</label>
                                </td>
                                <td>
                                     <select id="Select10" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_Select10" class="skiplink">Amit Desai Started the training</label>
                                </td>
                                 <td>
                                     <select id="Select11" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_Select11" class="skiplink">Amit Desai completed the training</label>
                                </td>
                                 <td>
                                     <select id="Select12" runat="server">
                                        <option value="">Pass</option>
                                        <option value="">Fail</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_Select12" class="skiplink">Amit Desai's final status pass or fail</label>
                                </td>
                                <td>
                                     <select id="Select13" runat="server">
                                        <option value="">G1</option>
                                        <option value="">G2</option>
                                        <option value="">G3</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_Select13" class="skiplink">Amit Desai's grade</label>
                                </td>
                                <td>
                                     <select id="Select14" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_Select14" class="skiplink">Amit Desai has given a certificate</label>
                                </td>
                                
                                <td>
                                </td>
                        </tr>
                        
                         <tr class="grid-row">
                                <td id="TdCheckbox4">
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_CheckBox2" class="skiplink">Select Sadanand Patil</label>
                                 </td>
                                <th>A23456</th>
                                <td style="white-space:nowrap">
                                    Amit Desai&nbsp;
                                </td>
                                <td>(o)988888888,(o)080-4122222</td>
                                <td>
                                     <select id="Select15" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">Will Not</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_Select15" class="skiplink">Sadanand Patil Confirm To attend training</label>
                                </td>
                                <td>
                                     <select id="Select16" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">Will Not</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_Select16" class="skiplink">Sadanand Patil comunicates to company to attend the trainig</label>
                                </td>
                                <td>
                                     <select id="Select17" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_Select17" class="skiplink">Sadanand Patil Started the training</label>
                                </td>
                                 <td>
                                     <select id="Select18" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_Select18" class="skiplink">Sadanand Patil completed the training</label>
                                </td>
                                 <td>
                                     <select id="Select19" runat="server">
                                        <option value="">Pass</option>
                                        <option value="">Fail</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_Select19" class="skiplink">Sadanand Patil's final status pass or fail</label>
                                </td>
                                <td>
                                     <select id="Select20" runat="server">
                                        <option value="">G1</option>
                                        <option value="">G2</option>
                                        <option value="">G3</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_Select20" class="skiplink">Sadanand Patil's grade</label>
                                </td>
                                <td>
                                     <select id="Select21" runat="server">
                                        <option value="">Yes</option>
                                        <option value="">No</option>
                                     </select>
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAssignedListTrainingCycle_ctrl0_Select21" class="skiplink">Sadanand Patil has given a certificate</label>
                                </td>
                                
                                <td>
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

    function More_Click() 
    {
        ShowPopUp('TrainingProjectsAssignedListTrainingCycleMoreHelp.htm','950','460');
    }
</script>

</asp:Content>

