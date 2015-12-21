<%@ Page Title="Knowledge & Training " Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.ProfileHistory.CandidateKnowledgeTraining" Codebehind="CandidateKnowledgeTraining.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="../../Scripts/jquery-1.7.1-vsdoc.js" type="text/javascript"></script>
<script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="../../Scripts/Common.js" type="text/jscript"></script>
<script src="CandidateKnowledgeTraining.js" type="text/javascript"></script>
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">
                Candidate Section
            </td>
        </tr>
    </table> 
       
    <table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">    
        <tr>
            <td>Profile and History> Knowledge & Training</td>
        </tr>
    </table>   
     
    <table cellpadding="0" cellspacing="0" style="margin-top:10px">    
        <tr>
            <td style="width:15px">&nbsp;</td>
            <td align="center">
                <asp:LinkButton ID="LnkBtnRegistration" runat="server" Text="Registration"
                    PostBackUrl="~/Candidate/ProfileHistory/Registration.aspx" CssClass="tab_links" />
            </td>
            <td style="padding-left:12px" align="center">
                <asp:LinkButton ID="LnkBtnEducationalQualifications" runat="server" Text="Educational Qualifications"
                    PostBackUrl="~/Candidate/ProfileHistory/EducationalQualifications.aspx" CssClass="tab_links" />
            </td>
            <td style="padding-left:12px" align="center">
                <asp:LinkButton ID="LnkBtnWorkExperience" runat="server" Text="Work Experience"
                    PostBackUrl="~/Candidate/ProfileHistory/CandidateWorkExperience.aspx" CssClass="tab_links" />
            </td>
            <td style="padding-left:12px" align="center">Knowledge and Training</td>
            <td style="padding-left:12px" align="center">
                <asp:LinkButton ID="LnkBtnJobProfiling" runat="server" Text="Job Profiling"
                    PostBackUrl="~/Candidate/ProfileHistory/CandidateJobProfile.aspx" CssClass="tab_links" />
            </td>
            <td style="padding-left:12px" align="center">
                <asp:LinkButton ID="LnkButtonCandidateHistory" runat="server" Text="Candidate History" CssClass="tab_links" 
                PostBackUrl="~/Candidate/ProfileHistory/AddViewCandidateHistory.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="skiplink">
        <tr>
            <td>
                <h1><span id="skipToTop" class="skiplink">Knowledge and Training</span></h1>
            </td>
        </tr>
    </table>

    <table style="margin-bottom:10px">
        <tr>
            <td style="width:210px">
                <span id="SpnCandidateNameText" runat="server" class="readonly_bold_text">Candidate:</span>
                <span id="SpnCandidateFirstName" runat="server" class="readonlyText"/>
                <span id="SpnCandidateMiddleName" runat="server" class="readonlyText"/>
                <span id="SpnCandidateLastName" runat="server" class="readonlyText"/>
            </td>
            <td style="width:250px">
                <span id="SpnDisabilityTypeText" runat="server" class="readonly_bold_text">Disability Type:</span>
                <span id="SpnDisabilityType" runat="server" class="readonlyText"></span>
            </td>
            <td style="width:100px">
                <span id="SpnRIDText" runat="server" class="readonly_bold_text">RID :</span>
                <span id="SpnRID" runat="server" class="readonlyText"></span>
            </td>
            <td>
                <span id="SpnStatusText" runat="server" class="readonly_bold_text">Status:</span>
                <span id="SpnStatus" runat="server" class="readonlyText"></span>
            </td>
        </tr>
    </table>

    <table cellpadding="4">
        <tr>
            <td>
                <table>
                    <tr>
                        <td valign="top"><h2>Computer Knowledge</h2></td>
                        <td>
                            Options<br />
                            <asp:ListView ID="LstViewComputerKnowledge" runat="server" OnItemDataBound="LstViewComputerKnowledge_ItemDataBound">
                                <LayoutTemplate>
                                    <table id="TblComputerKnowledge" class="checkedListBox">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0">
                                        <tr>
                                            <td id="textField" style="width:56px"><%#Eval("computer_knowledge_type")%></td>
                                            <td>
                                                <asp:CheckBox ID="ChkSelectKnowledge" runat="server" 
                                                    KnowledgeID='<%#  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("computer_knowledge_id"))) %>'
                                                    Checked='<%# Convert.ToBoolean(Eval("is_attached")) %>' />
                                                <label id="LblComputerKnowledge" runat="server" class="skiplink">test</label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:ListView>
                        </td>
                        <td valign="top" style="padding-left:30px">Others
                            <asp:TextBox ID="TxtOtherKnowledge" runat="server" Width="500px" MaxLength="130" TextMode="MultiLine" Height="60px"/>
                            <label for="ctl00_ContentPlaceHolder2_TxtOtherKnowledge" class="skiplink">Other knowledge</label>
                        </td>
                    </tr>
                </table>
           
                <table>
                    <tr>
                        <td valign="top" style="width:118px"><h2>Languages Known</h2></td>
                        <td>
                            Options<br />
                             <asp:ListView ID="LstViewKnownLanguages" runat="server" OnItemDataBound="LstViewKnownLanguages_ItemDataBound">
                                <LayoutTemplate>
                                    <table id="TblLanguages" class="checkedListBox"  style="width:157px">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate> 
                                    <table cellpadding="0" >
                                        <tr>
                                            <td id="textField" align="left"><%#Eval("language_name") %>&nbsp</td>
                                            <td>
                                                <asp:CheckBox ID="ChkSelectLanguage" runat="server" 
                                                    LanguageID='<%#  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("language_id"))) %>'
                                                    Checked='<%# Convert.ToBoolean(Eval("is_attached")) %>' />
                                                <label id="LblLanguage" runat="server" class="skiplink" >test</label>
                                            </td>
                                        </tr>
                                    </table>  
                                </ItemTemplate>
                            </asp:ListView>
                        </td>
                        <td valign="top" style="padding-left:30px">
                            <h2>Other Communication Skills</h2><br />
                            <table id="TblOtherCommunicationSkills" class="checkedListBox">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table cellspacing="0">
                                                <tr>
                                                    <td style="width:122px">Knows Sign language</td>
                                                    <td>
                                                        <asp:CheckBox ID="ChkKnowsSignLanguage" runat="server" />
                                                        <label for="ctl00_ContentPlaceHolder2_ChkKnowsSignLanguage" class="skiplink">knows sign language other communications skills 1 of 3 </label>
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                            <table cellspacing="0">
                                                <tr>
                                                    <td style="width:122px">Knows Braille</td>
                                                    <td>
                                                        <asp:CheckBox ID="ChkKnowsBraile" runat="server" />
                                                        <label for="ctl00_ContentPlaceHolder2_ChkKnowsBraile" class="skiplink">Knows Braille  2 of 3 </label>
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                            <table cellspacing="0">
                                                <tr>
                                                    <td style="width:122px">N A</td>
                                                    <td>
                                                        <asp:CheckBox ID="ChkNotApplicable" runat="server" />
                                                        <label for="ctl00_ContentPlaceHolder2_ChkNotApplicable" class="skiplink">N A 3 of 3 </label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </table>
        
                <table>
                    <tr>
                        <td>
                            <label for="ctl00_ContentPlaceHolder2_TxtNeedBasedTrainingAdministered">Need-based training/counseling administered</label>
                        </td>    
                        <td style="padding-left:56px">
                            <asp:TextBox ID="TxtNeedBasedTrainingAdministered" runat="server" Width="400px" MaxLength="100" />
                        </td>
                    </tr>
                </table>
                
                <table>
                    <tr>
                        <td style="white-space:nowrap">
                            <asp:CheckBox ID="ChkEmployableWithoutTraining" runat="server" TextAlign="Left"
                                Text="If candidate is employable without training, then click here"/>
                        </td>
                    </tr>
                </table>
        
                <table>
                    <tr>
                        <td style="font-weight:bold">Training Details</td>
                    </tr>
                </table>
                
                <table cellpadding="5">
                    <tr>
                        <td valign="top" style="padding-top:18px">
                            <asp:ListView ID="LstViewTrainingPassed" runat="server">
                                <LayoutTemplate>
                                    <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                        bordercolor="#808080" border="1px">
                                        <thead>
                                            <tr class="grid-header">
                                                <th>Training Passed</th>
                                                <th>Grade</th>
                                                <th>Training Project</th>
                                                <th>Training Passed Year</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                        </tbody>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("training_program_name")%></td>
                                        <td><%# Eval("cand_grade") %></td>
                                        <td><%# Eval("training_project_name")%></td>
                                        <td align="right"><%# Eval("training_passed_year") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </td>
                    </tr>
                </table>
                
                <table>
                    <tr>
                        <td>Training Currently Assigned To:</td>
                        <td><span id="SpnCurentTraining" runat="server" /></td>
                    </tr>
                </table>
                
                <table>
                    <tr>
                        <td>Recommended Training:</td>
                        <td><span id="SpnRecommendedTraining" runat="server" /></td>
                    </tr>
                </table>
                
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="BtnAddEditRecommendedTraining" runat="server" Text="Add/Edit Recommended Training"
                                OnClientClick="javascript:ShowTrainingProgrammPopup(-1);" 
                                OnClick="BtnAddEditRecommendedTraining_Click"/>
                        </td>
                    </tr>
                </table>
                
                <table style="width:100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="BtnUpdateKnowledgeAndTraining" runat="server" Text="Submit" 
                                OnClick="BtnUpdateKnowledgeAndTraining_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

