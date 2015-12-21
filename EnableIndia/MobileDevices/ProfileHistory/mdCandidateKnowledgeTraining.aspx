<%@ Page Title="" Language="C#" MasterPageFile="~/MobileDevices/mobileMaster.Master" AutoEventWireup="true" CodeBehind="mdCandidateKnowledgeTraining.aspx.cs" Inherits="EnableIndia.MobileDevices.ProfileHistory.mdCandidateKnowledgeTraining" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div style="text-align:left;">
    <table style="border-collapse:separate; border-spacing:2px;">
    <tr>
        <td style="text-align:center;">
            <asp:LinkButton ID="LnkBtnRegistration" runat="server" Text="Registration"
                PostBackUrl="~/MobileDevices/ProfileHistory/mdRegistration.aspx" CssClass="tab_links" />
        </td>
        <td style="padding-left:12px; text-align:center;">
          <asp:LinkButton ID="LnkBtnEducationalQualifications" runat="server" Text="Educational Qualifications"
                PostBackUrl="~/MobileDevices/ProfileHistory/mdEducationalQualification.aspx" 
                CssClass="tab_links" />
        </td>
        
        <td style="padding-left:12px; text-align:center;">
          <asp:LinkButton ID="LnkBtnWorkExperience" runat="server" Text="Work Experience"
                PostBackUrl="~/MobileDevices/ProfileHistory/mdCandidateWorkExperience.aspx" CssClass="tab_links" />
        </td>
        <td style="padding-left:12px; text-align:center;">
             <asp:Label runat="server" ID="lbKnowledgeTraining" Text="Knowledge and Training" Font-Bold="true"></asp:Label>
        </td>
        <td style="padding-left:12px; text-align:center;">
            <asp:LinkButton ID="LnkBtnJobProfiling" runat="server" Text="Job Profiling"
                PostBackUrl="~/MobileDevices/ProfileHistory/mdCandidateJobProfile.aspx" CssClass="tab_links" />
        </td>
        <td style="padding-left:12px; text-align:center;">
            <asp:LinkButton ID="LnkButtonCandidateHistory" runat="server" Text="Candidate History" CssClass="tab_links" 
            PostBackUrl="~/MobileDevices/ProfileHistory/mdAddViewCandidateHistory.aspx" />
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
    <div style="width:100%;">
        <div style="display:table-cell;">
            <asp:Label runat="server" ID="Label2" Text="Computer Knowledge: " Font-Bold="true" Font-Size="Medium"></asp:Label>
        </div>
    </div>
    <div style="display:table-row;">
        <div style="display:table-cell;">
        <asp:Label runat="server" ID="Label1" Text="Options" Font-Bold="true" Font-Size="12px"></asp:Label>
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
               <table style="border-collapse:separate; border-spacing:0px; border-width:1px;">
                   <tr>
                       <td id="textField" style="width:56px"><%#Eval("computer_knowledge_type")%></td>
                       <td>
                           <asp:CheckBox ID="ChkSelectKnowledge" runat="server" 
                               KnowledgeID='<%#  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("computer_knowledge_id"))) %>'
                               Checked='<%# Convert.ToBoolean(Eval("is_attached")) %>' />
                           <label id="LblComputerKnowledge" runat="server" style="display:none;" class="skiplink">test</label>
                       </td>
                   </tr>
               </table>
           </ItemTemplate>
       </asp:ListView>
    </div>
    <div  style="padding-left:30px; vertical-align:middle; display:table-cell; vertical-align:top;">
        <asp:Label runat="server" ID="lbOthers" Text="Others: " Font-Bold="true" Style="vertical-align:middle;"></asp:Label>
        <asp:TextBox ID="TxtOtherKnowledge" runat="server" Width="500px" MaxLength="130" TextMode="MultiLine" Height="60px"/>
        <label for="ContentPlaceHolder1_TxtOtherKnowledge" class="skiplink">Other knowledge</label>
    </div>
    </div>
   <div style="display:table;border-collapse:separate;border-spacing:5px; border-width: 2px;">
       <div style="display:table-row;">
      <div style="display:table-cell; vertical-align:top;  float:left;">
          <asp:Label runat="server" ID="lbLbKnown" Text="Language Known: " Font-Bold="true" Font-Size="Medium"></asp:Label>
        </div>
      <div style="display:table-cell;  float:left;">
          <div style="text-align:center;">
              <asp:Label runat="server" ID="Label4" Text="  Options" Font-Bold="true" Font-Size="12px"></asp:Label>
           </div>
          <div>
          <asp:ListView ID="LstViewKnownLanguages" runat="server" OnItemDataBound="LstViewKnownLanguages_ItemDataBound">
          <LayoutTemplate>
              <table id="TblLanguages" class="checkedListBox">
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
              <table style="border-collapse:separate; border-spacing:0px;  border-width:1px;" >
                  <tr>
                      <td id="textField" style="text-align:left;"><%#Eval("language_name") %>&nbsp</td>
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
          </div>
       </div>
      <div style="display:table-cell; vertical-align:top; float:left; text-align:left;">
          <asp:Label runat="server" ID="Label3" Text="Other Communication Skills" Font-Bold="true" Font-Size="Medium"></asp:Label>
          <table style="width:100%">
              <tr>
                  <td>
                      Knows Sign language
                  </td>
               <td>
                   <asp:CheckBox ID="ChkKnowsSignLanguage" runat="server" />
                  <label for="ContentPlaceHolder1_ChkKnowsSignLanguage" class="skiplink">knows sign language other communications skills 1 of 3 </label>
                </td>
              </tr>
              <tr>
                  <td>
                       Knows Braille
                  </td>
                  <td>
                     <asp:CheckBox ID="ChkKnowsBraile" runat="server" />
                    <label for="ContentPlaceHolder1_ChkKnowsBraile" class="skiplink">Knows Braille  2 of 3 </label>

                  </td>
              </tr>
              <tr>
                  <td>
                        N A
                  </td>
                  <td>
                      <asp:CheckBox ID="ChkNotApplicable" runat="server" />
                      <label for="ContentPlaceHolder1_ChkNotApplicable" class="skiplink">N A 3 of 3 </label>
                  </td>
              </tr>
          </table>
       </div>
    </div>
    </div>
       <div style="display:table-row;">
           <div style="display:table-cell;">
             <label for="ContentPlaceHolder1_TxtNeedBasedTrainingAdministered">Need-based training/counseling administered:&nbsp;</label>
           </div>
           <div style="display:table-cell;">
            <asp:TextBox ID="TxtNeedBasedTrainingAdministered" runat="server" Width="400px" MaxLength="100" />
           </div>
       </div> 
       <div style="white-space:nowrap;">
           <asp:CheckBox ID="ChkEmployableWithoutTraining" runat="server" TextAlign="Left"
                     Text="If candidate is employable without training, then click here"/>

       </div> 
            <br style="font-size:4px;" />
       <div style="font-weight:bold">Training Details</div>
       <div style="margin-top:6px;">
                 <asp:ListView ID="LstViewTrainingPassed" runat="server">
                     <LayoutTemplate>
                         <table rules="all" style="border-collapse:separate; border-spacing:0px; border-color:#808080; border-width:1px;">
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
                             <td style="text-align:right"><%# Eval("training_passed_year") %></td>
                         </tr>
                     </ItemTemplate>
                 </asp:ListView>
                </div>                
       <div style="display:table-row;">
                <div style="display:table-cell;">Training Currently Assigned To:</div>
                <div style="display:table-cell;"><span id="SpnCurentTraining" runat="server" /></div>
        </div>
       <div style="display:table-row;">
                <div style="display:table-cell;">Recommended Training:</div>
                <div style="display:table-cell;"><span id="SpnRecommendedTraining" runat="server" /></div>
        </div>
        <div style="display:table-row;">
               <asp:Button ID="BtnAddEditRecommendedTraining" runat="server" Text="Add/Edit Recommended Training"
                        OnClientClick="javascript:ShowTrainingProgrammPopup(-1);" 
                        OnClick="BtnAddEditRecommendedTraining_Click"/>

        </div>
       <div  style="text-align:center;">
                    <asp:Button ID="BtnUpdateKnowledgeAndTraining" runat="server" Text="Submit" 
                        OnClick="BtnUpdateKnowledgeAndTraining_Click" />
       </div>
    </div>
            <script src="../../Scripts/jquery-2.1.4.min.js"></script>
            <script src="../../Scripts/Common.js"></script>
            <script src="mdCandidateKnowledgeTraining.js"></script>
</asp:Content>
