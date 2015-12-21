<%@ Page Title="Add Recommended Candidates" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Training.TrainingProjectsAddRecommendedCandidates" Codebehind="TrainingProjectsAddRecommendedCandidates.aspx.cs" ClientIDMode="Static" %>

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
            Manage Open Training Projects>>Step 1: Add Recommended Candidates
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
            <asp:LinkButton ID="LnkBtnStepOneAddRecommendedCandidates" runat="server" Text="Step 2: Add Non-Recommended Candidates"
                PostBackUrl="~/Training/TrainingProjectsNonRecomendedCandidates.aspx"
                CssClass="tab_links" />
        </td>
        
        <td style="padding-left:21px">
            <asp:LinkButton ID="LnkBtnStepThreeAssignedList" runat="server" Text="Step 3: Assigned List"
                PostBackUrl="~/Training/TrainingProjectAssignedListTrainingCycle.aspx" CssClass="tab_links" />
        </td>
    </tr>
</table>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table class="readonlyText">
    <tr>
        <td>
            Training Program Instance: Computer Basics 12/11/2008 to 30/11/2008 from 4 pm to 8 pm
        </td>
    </tr>
</table>

<table>
    <tr>
        <td class="message">
            Select candidates for this Training Project using check-box selection and click 'Add to Assigned List'<br />
            to transfer candidates to the Assigned List.
            <a href="javascript:More_Click();" class="message">MORE HELP...</a><br />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
            <label for="ctl00_ContentPlaceHolder2_DdlSelectAge">Select Age Years</label>
        </td>
        <td>
            <select id="DdlSelectAge" runat="server">
                <option value="">11</option>
                <option value="">12</option>
                <option value="" selected="selected">14</option>
                <option value="">15</option>
                <option value="">16</option>
                <option value="">17</option>
                <option value="">18</option>
            </select>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
            <b><u>Recommended Candidates for this Training Program</u></b>
        </td>
        <td>
            <asp:Button ID="BtnSelectAll" Text="Select All" runat="server" />
        </td>
        <td>
            <asp:Button ID="BtnAddToAssignedList" Text="Add to Assigned List" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
            <asp:ListView ID="LstViewAddRecommendedCandidate" runat="server">
                <LayoutTemplate>
                    <table id="TblAddRecommendedCandidate" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                        bordercolor="#808080" border="1px" summary="Recommended Candidate training Program Details Table">
                        <thead>
                            <tr class="grid-header">
                                <th><span class="skiplink">Radio button for selecting row to update</span></th>
                                <th>RID</th>
                                <th>Name</th>
                                <th>Disability</th>
                                <th>Qualifications</th>
                                <th>Language Known</th>
                                <th>Recommended Training</th>
                                <th>Training Programs already Assigned</th>
                                <th>Training Passed</th>
                                <th>Current City</th>
                                <th>Prefered location</th>
                                <th>Special Communication</th>
                                <th>Unemployeed Since Days</th>
                                <th>Recommended Job Types</th>
                                <th>Recommended Role</th>
                                <th>Vacancy/Employment Project Assigned to</th>
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
                    <table id="TblAddRecommendedCandidate" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                        bordercolor="#808080" border="1px" summary="Existing Data on recommended candidates Training Program. Select row using radio-button for updating that row.">
                        <thead>
                            <tr class="grid-header">
                                <th><span class="skiplink">Radio button for selecting row to update</span></th>
                                <th>RID</th>
                                <th>Name</th>
                                <th>Disability</th>
                                <th>Qualifications</th>
                                <th>Language Known</th>
                                <th>Recommended Training</th>
                                <th>Training Programs already Assigned</th>
                                <th>Training Passed</th>
                                <th>Current City</th>
                                <th>Prefered location</th>
                                <th>Special Communication</th>
                                <th>Unemployeed Since Days</th>
                                <th>Recommended Job Types</th>
                                <th>Recommended Role</th>
                                <th>Vacancy/Employment Project Assigned to</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td id="TdRadioButton1">
                                    <asp:RadioButton ID="RdbRecommendedCandidateTrainingProject1" runat="server" GroupName="Company" />
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAddRecommendedCandidate_ctrl0_RdbRecommendedCandidateTrainingProject1" class="skiplink">SHWETA ALVA</label>
                                </td>
                                <th align="left"  style="font-weight:normal">
                                    <asp:LinkButton ID="LnkBtnTrainingProgramAOneTwoThree" runat="server" 
                                    Text="A12345" Font-Bold="false"/>
                                </th>
                                <td style="width:280px">
                                    <asp:LinkButton ID="LnkBtnTrainingProjectShwetaAlva" 
                                    runat="server" Text="SHWETA ALVA" Font-Bold="false"/>
                                </td>
                                <td>VI</td>
                                <td>BA, MA</td>
                                <td>English, Hindi</td>
                                <td>T1, T2</td>
                                <td></td>
                                <td></td>
                                <td>Banglore</td>
                                <td>Banglore</td>
                                <td>Sign, braille</td>
                                <td>70</td>
                                <td>J1</td>
                                <td>R1, R2</td>
                                <td></td>
                            </tr>
                        </tbody>
                         <tbody>
                            <tr>
                                 <td id="TdRadioButton2">
                                    <asp:RadioButton ID="RdbRecommendedCandidateTrainingProject2" runat="server" GroupName="Company" />
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAddRecommendedCandidate_ctrl0_RdbRecommendedCandidateTrainingProject2" class="skiplink">SMITA KHARE</label>
                                </td>
                                <th align="left"  style="font-weight:normal">
                                    <asp:LinkButton ID="LnkBtnTrainingProgramNOneTwoThree" runat="server" 
                                    Text="N12300" Font-Bold="false"/>
                                </th>
                                <td style="width:280px">
                                    <asp:LinkButton ID="LnkBtnTrainingProjectSmitaKhare" 
                                    runat="server" Text="SMITA KHARE" Font-Bold="false"/>
                                </td>
                                <td>VI</td>
                                <td>B.Com</td>
                                <td>Kannada, Hindi, Marathi</td>
                                <td>T1</td>
                                <td>Front Office</td>
                                <td>T2</td>
                                <td>Delhi</td>
                                <td>Banglore</td>
                                <td>Sign</td>
                                <td>120</td>
                                <td>J2</td>
                                <td>R2, R3, R4</td>
                                <td>TCS-BLR-Ecity-Receptionist</td>
                            </tr>
                        </tbody>
                        <tbody>
                            <tr>
                                <td id="TdRadioButton3">
                                    <asp:RadioButton ID="RdbRecommendedCandidateTrainingProject3" runat="server" GroupName="Company" />
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAddRecommendedCandidate_ctrl0_RdbRecommendedCandidateTrainingProject3" class="skiplink">Amit Desai</label>
                                </td>
                                <th align="left"  style="font-weight:normal">
                                    <asp:LinkButton ID="LnkBtnTrainingProgramATwoThreeFour" runat="server" 
                                    Text="A23456" Font-Bold="false"/>
                                </th>
                                <td style="width:280px">
                                    <asp:LinkButton ID="LnkBtnTrainingProjectAmitDesai" 
                                    runat="server" Text="AMIT DESAI" Font-Bold="false"/>
                                </td>
                                <td>PH</td>
                                <td>BA</td>
                                <td>Kannada</td>
                                <td>T3</td>
                                <td></td>
                                <td></td>
                                <td>Chennai</td>
                                <td>Banglore</td>
                                <td>NA</td>
                                <td></td>
                                <td>J3</td>
                                <td>R3</td>
                                <td></td>
                            </tr>
                        </tbody>
                         <tbody>
                            <tr>
                                <td id="TdRadioButton4">
                                    <asp:RadioButton ID="RdbRecommendedCandidateTrainingProject4" runat="server" GroupName="Company" />
                                    <label for="ctl00_ContentPlaceHolder2_LstViewAddRecommendedCandidate_ctrl0_RdbRecommendedCandidateTrainingProject4" class="skiplink">Patil</label>
                                </td>
                                <th align="left"  style="font-weight:normal">
                                    <asp:LinkButton ID="LnkBtnTrainingProgramASevenSixEight" runat="server" 
                                    Text="A76855" Font-Bold="false"/>
                                </th>
                                <td style="width:280px">
                                    <asp:LinkButton ID="LnkBtnTrainingProjectPatil" 
                                    runat="server" Text="Patil" Font-Bold="false"/>
                                </td>
                                <td>VI</td>
                                <td>M.Com</td>
                                <td>English</td>
                                <td>T4</td>
                                <td></td>
                                <td></td>
                                <td>Banglore</td>
                                <td>Chennai</td>
                                <td>Braille</td>
                                <td></td>
                                <td>J4</td>
                                <td>R4</td>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>

<script type="text/javascript">

    function More_Click() 
    {
        ShowPopUp('TrainingProjectsAddRecommendedCandidatesMoreHelp.htm','770','270');
    }
</script>

</asp:Content>

