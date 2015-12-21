<%@ Page Title="" Language="C#" MasterPageFile="~/MobileDevices/mobileMaster.Master" AutoEventWireup="true" CodeBehind="mdRegistration.aspx.cs" Inherits="EnableIndia.MobileDevices.ProfileHistory.Register" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="vertical-align:top; margin: 0 auto;">
    <table  style="margin-top:10px; border-collapse:separate; border-spacing:0px; border-width:0px;">
    <tr>
        <td style="text-align:center;">Registration</td>
        <td style="padding-left:12px; text-align:center;">
            <asp:LinkButton ID="LnkBtnEducationalQualifications" runat="server" Text="Educational Qualifications"
                PostBackUrl="~/MobileDevices/ProfileHistory/mdEducationalQualification.aspx" 
                CssClass="tab_links" />
        </td>
        <td  style="padding-left:12px;text-align:center;">
            <asp:LinkButton ID="LnkBtnWorkExperience" runat="server" Text="Work Experience"
                PostBackUrl="~/MobileDevices/ProfileHistory/mdCandidateWorkExperience.aspx" CssClass="tab_links" />
        </td>
        <td style="padding-left:12px; text-align:center;">
            <asp:LinkButton ID="LnkBtnKnowledgeAndTraining" runat="server" Text="Knowledge and Training"
                PostBackUrl="~/MobileDevices/ProfileHistory/mdCandidateKnowledgeTraining.aspx" CssClass="tab_links" />
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
   <table style="border-collapse:separate; border-width:0px; border-spacing:1px; word-wrap:break-word; width:100%; table-layout:fixed; ">
       <colgroup>
           <col  style="width:17%" />
           <col  style="width:27%" />
           <col  style="width:27%" />
           <col  style="width:27%" />
       </colgroup>
    <tbody>
        <tr>
           <td style="white-space:nowrap; vertical-align:middle;">Registration ID&nbsp;&nbsp;</td>
              <td style="white-space:nowrap;vertical-align:middle;"><span id="SpnRegistrationID" runat="server" /></td>
              <td  style="white-space:nowrap;vertical-align:middle;">Candidate's NGO&nbsp;
               <span id="SpanCandidateNGO" runat="server" class="readonlyText" /></td>
              <td>
              <div><label id="LblCandidateIDAtNGO" runat="server" for="ctl00_ContentPlaceHolder2_TxtCandidateIDAtNGO" visible="false" >Candidate's ID at NGO </label>
                  <asp:TextBox ID="TxtCandidateIDAtNGO" runat="server" Visible="false"/>
                  <span id="SpnNgoID" runat="server" visible="false" />
              </div>
              <div style="display:table-cell; vertical-align:top;" id="TdMessageForNGO" runat="server" visible="false">(only for other NGO candidates)</div>
              </td>
            <td></td>
        </tr>
            <tr runat="server" id="TblRegistrationID" visible="false">
     <td style="text-align:left; vertical-align:middle;">Registration ID</td>
     <td  colspan="3" style= "width:100%;text-align:left; vertical-align:middle;">
        <span id="Span1" runat="server" />
     </td>
     </tr>
      <tr>
                    <td style="vertical-align:middle;"><label for="ContentPlaceHolder1_TxtFileNumber">File Number</label></td>
                    <td style="vertical-align:middle;"><asp:TextBox ID="TxtFileNumber" runat="server" /></td>
                    <td colspan="2" style="vertical-align:middle;">
                        <div style="display:table-row;">
                        <div style="display:table-cell; vertical-align:middle;">
                            <span id="SpnRegistrationDate" style="margin-right:12px;"> REGISTRATION DATE: </span>
                        </div>
                        <div style="vertical-align:middle;  display:table-cell;">
                           <asp:TextBox ID="TxtRegistrationDate" runat="server" Visible ="false" />
                           <span id="SpnRegistartionDate" runat="server" class="readonlyText" visible="false"></span>
                             (DD/MM/YYYY)
                        </div>
                        </div>
                    </td>
                </tr>
       <tr>
           <td style="text-align:left; vertical-align:middle;">
            </td>
           <td style="text-align:left; vertical-align:middle;">
             <asp:Label CssClass="labelStyle" runat="server" ID="Label13" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
              <asp:Label runat="server" ID="Label1" Text="First Name:" Font-Bold="true"></asp:Label>
           </td>
           <td style="text-align:left; vertical-align:middle;">
              <asp:Label runat="server" ID="Label2" Text="Middle Name:" Font-Bold="true"></asp:Label>
           </td>
           <td style="text-align:left; vertical-align:middle;">
             <asp:Label CssClass="labelStyle" runat="server" ID="Label14" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
             <asp:Label runat="server" ID="Label3" Text="Last Name:" Font-Bold="true"></asp:Label>
           </td>
       </tr>
       <tr>
           <td style="text-align:left; vertical-align:middle;">
              <asp:Label runat="server" ID="lbEnbt" Text="Candidate Name: " Font-Bold="true"></asp:Label>
           </td>
           <td style="text-align:left; vertical-align:middle;">
               <asp:TextBox runat="server" ID="TxtCandidateFirstName"></asp:TextBox>
            </td>
           <td style="text-align:left; vertical-align:middle;">
               <asp:TextBox runat="server" ID="TxtCandidateMiddleName" ></asp:TextBox>
           </td>
           <td style="text-align:left; vertical-align:middle;">
               <asp:TextBox runat="server" ID="TxtCandidateLastName"></asp:TextBox>
           </td>
       </tr>
        <tr>
          <td style="text-align:left; vertical-align:middle;">
                <asp:Label CssClass="labelStyle" runat="server" ID="Label15" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                <asp:Label CssClass="labelStyle" runat="server" ID="lbDdlDisabilityTypes" for="ContentPlaceHolder1_DdlDisabilityTypes" AssociatedControlID="DdlDisabilityTypes" Text="DISABILITY TYPE"></asp:Label>
           </td>
         <td style="text-align:left; vertical-align:middle;">
             <select id="DdlDisabilityTypes" runat="server" class="mandatory" messagetext="Disability type" type="select-one"
            onchange="javascript:FilterCityStates(this.value,'DisabiltyTypeID','ContentPlaceHolder1_DdlDisabilitySubTypes','ContentPlaceHolder1_DdlHiddenDisabilitySubTypes');"/>
         </td>
  
        <td  style="text-align:left; vertical-align:middle;">
             <asp:Label CssClass="labelStyle" runat="server" ID="Label16" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
             <asp:Label CssClass="labelStyle" runat="server" ID="lbDdlDisabilitySubTypes" for="ContentPlaceHolder1_DdlDisabilitySubTypes" Text="SUB TYPE" AssociatedControlID="DdlDisabilitySubTypes"></asp:Label>
         </td>
         <td  style="text-align:left; vertical-align:middle;">
             <select id="DdlDisabilitySubTypes" runat="server" class="mandatory" messagetext="Disability sub type"  type="select-one"
                  onchange="javascript:$('#TxtHiddenDisabilitySubTypes').val($('#DdlDisabilitySubTypes').val());" />
             <div style="display:none;">
                         <label for="ContentPlaceHolder1_DdlHiddenDisabilitySubTypes">HiddenDisablitySubTypes</label>
                         <select id="DdlHiddenDisabilitySubTypes" runat="server"/>
                         <label for="ContentPlaceHolder1_TxtHiddenDisabilitySubTypes">HiddenDisablitySubTypes</label>
                         <asp:TextBox ID="TxtHiddenDisabilitySubTypes" runat="server" />
             </div>
        </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; ">
                 <asp:Label CssClass="labelStyle" runat="server" ID="Label4" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                 <asp:Label CssClass="labelStyle" runat="server" id="ContentPlaceHolder1_TxtDateOfBirth" Text="DATE OF BIRTH" AssociatedControlID="TxtDateOfBirth"></asp:Label>
            </td>
            <td style="vertical-align:middle;">
                <asp:TextBox ID="TxtDateOfBirth" runat="server" class="mandatory" messagetext="Date of birth" date="true" yearlength="4"/>&nbsp;
                <asp:ImageButton runat="server" ID="Image1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="Image1" TargetControlID="TxtDateOfBirth" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtDateOfBirth"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />&nbsp;(DD/MM/YYYY) 
            </td>
            <td><asp:Label runat="server" ID="lbAge" Text="Age: " Font-Bold="true"></asp:Label>  <span id="SpnAge" runat="server" class="readonlyText" /></td>
            <td style="vertical-align:middle;">
           </td>
        </tr>
        <tr>
      <td style="vertical-align:middle;">
             <asp:Label CssClass="labelStyle" runat="server" ID="Label18" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
               GENDER
           </td>
            <td style="vertical-align:middle;">
                <asp:RadioButton ID="RdbMale" runat="server" GroupName="Gender" />
                <span class="radioButtonText">Male</span>
            </td>
            <td colspan="2" style="vertical-align:middle;">
               <label for="ContentPlaceHolder1_RdbMale" class="skiplink">Gender, Male</label>&nbsp;
                 <asp:RadioButton ID="RdbFemale" runat="server" GroupName="Gender"  />
                <span class="radioButtonText">Female</span>
                <label for="ContentPlaceHolder1_RdbFemale" class="skiplink">Gender, Female</label>
                <Asp:Label id="ContentPlaceHolder1_RdbFemale" runat="server" class="skiplink" Text="Gender, Female"></Asp:Label>
          </td>
         </tr>
          <tr>
              <td  style="vertical-align:middle;">
                 <asp:Label CssClass="labelStyle" runat="server" ID="lbOldRegistrationNumber" for="ContentPlaceHolder1_TxtOldRegistrationNumber" Text="Old Registration Number" AssociatedControlID="TxtOldRegistrationNumber"></asp:Label>
              </td>
           <td colspan="3" style="vertical-align:middle;">
               <asp:TextBox ID="TxtOldRegistrationNumber" runat="server"></asp:TextBox>
           </td>
          </tr>
          <tr>
            <td style="vertical-align:middle;">
                 <asp:Label CssClass="labelStyle" runat="server" ID="Label5" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                 <label for="ContentPlaceHolder1_TxtPrimaryPhoneNumber">PHONE NUMBER (PRIMARY)</label>
            </td>
            <td style="vertical-align:middle;">
                 <asp:TextBox ID="TxtPrimaryPhoneNumber" runat="server" 
                                        class="mandatory" messagetext="Primary phone number" phonenumber="true" />
            </td>
             <td style="vertical-align:middle;">
                 <asp:RadioButton ID="RdbLastREachableOnPrimaryPhoneNumber" runat="server" GroupName="PhoneNumber"/>
                 <span class="radioButtonText">last reachable on this phone.</span>
             </td>
            <td><label for="ContentPlaceHolder1_RdbLastREachableOnPrimaryPhoneNumber" class="skiplink">last reachable on primary phone number</label>
            </td>
         </tr>
          <tr id="TblNgoOfficeNuber" runat="server" visible="false">
              <td style="width:190px"></td>
              <td colspan="3">
                  <span id="SpnNGOOfficeNumber" runat="server" ></span>
              </td>
          </tr>
         <tr>
            <td style="vertical-align:middle;">
                 <label for="ContentPlaceHolder1_TxtSecondaryPhoneNumber">Phone number (Secondary)</label>
            </td>
            <td style="vertical-align:middle;">
               <asp:TextBox ID="TxtSecondaryPhoneNumber" runat="server" />
            </td>
            <td  style="vertical-align:middle;">
                <asp:RadioButton ID="RdbLastReachableOnSecondaryPhoneNumber" runat="server" GroupName="PhoneNumber" />
                      <span class="radioButtonText">last reachable on this phone.</span>
           </td>
           <td  style="vertical-align:middle;">
                <label for="ContentPlaceHolder1_RdbLastReachableOnSecondaryPhoneNumber" class="skiplink">last reachable on secondary phone number</label></td>
           </tr>
          <tr>
             <td style="vertical-align:middle;">
                 <asp:Label CssClass="labelStyle" runat="server" ID="Label6" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                 <asp:Label CssClass="labelStyle" runat="server" ID="lbPerAddT" Text="ADDRESS (PRESENT)" AssociatedControlID="TxtPresentAddress"></asp:Label>

             </td>
              <td colspan="2" style="vertical-align:middle;"> Building, Lane Details<br />
                  <asp:TextBox ID="TxtPresentAddress" runat="server" Width="90%"
                       class="mandatory" messagetext="Present address" />
                  <label class="skiplink" for="ContentPlaceHolder1_TxtPresentAddress">PRESENT ADDRESS, Building, Lane Details</label>
               </td>
              <td  style="vertical-align:middle;">
                  <asp:RadioButton ID="RdbLastReachableOnPresentAddress" runat="server" GroupName="Address"  />
                  <span class="radioButtonText">last reachable on this address</span>
              </td>
              <td style="vertical-align:middle;"><label for="ContentPlaceHolder1_RdbLastReachableOnPresentAddress" class="skiplink">last reachable on present address</label></td>
          </tr>
          <tr>
              <td>
                  &nbsp;
              </td>
              <td>
                    <asp:Label CssClass="labelStyle" runat="server" ID="Label7" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                    <asp:Label CssClass="labelStyle" runat="server" ID="lbPreCountryT" Text="COUNTRY" for="ContentPlaceHolder1_DdlPresentCountry"  AssociatedControlID="DdlPresentCountry"></asp:Label>

              </td>
              <td>
                    <asp:Label CssClass="labelStyle" runat="server" ID="Label8" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                    <asp:Label CssClass="labelStyle" runat="server" ID="lbDdlPresentAddressStates" for="ContentPlaceHolder1_DdlPresentAddressStates" Text="STATE" AssociatedControlID="DdlPresentAddressStates"></asp:Label>
              </td>
              <td>
                  <div style="display:table-cell; width:50%;" runat="server" id="divPreCity">
                    <asp:Label CssClass="labelStyle" runat="server" ID="Label9" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                    <asp:Label CssClass="labelStyle" runat="server"  ID="lbDdlPresentAddressCities" for="ContentPlaceHolder1_DdlPresentAddressCities" Text="CITY" AssociatedControlID="DdlPresentAddressCities"></Asp:Label>
                   </div>
                  <div style="display:table-cell; width:50%;" runat="server" id="divPrePinCode">
                    <asp:Label CssClass="labelStyle" runat="server" ID="Label10" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                    <asp:Label CssClass="labelStyle" runat="server" ID="ContentPlaceHolder1_TxtPresentAddressPinCode" Text="PIN-CODE" AssociatedControlID="TxtPresentAddressPinCode"></Asp:Label>
                  </div>
              </td>
          </tr>
            <tr>
                <td>&nbsp;

                </td>
                <td style="vertical-align:middle;">
                    <select id="DdlPresentCountry" runat="server" class="mandatory" 
                        messagetext="Country of present address" type="select-one"
                       onchange="javascript:DdlCountries_OnSelectedIndexChanged(this.value,'CountryID','ContentPlaceHolder1_DdlPresentAddressStates','ContentPlaceHolder1_DdlPresentAdrressHiddenState');"  
                    ></select>
                </td>
               <td style="vertical-align:middle;">
                    <select id="DdlPresentAddressStates" runat="server"  class="mandatory" 
                        messagetext="State of present address" type="select-one"
                        onchange="javascript:DdlPresentAddressStates_SelectedIndexChanged(this.value,'StateID','ContentPlaceHolder1_DdlPresentAddressCities','ContentPlaceHolder1_DdlPresentAddressHiddenCities');" />
                </td>
               
                <td style="vertical-align:middle;">
                   <div style="display:table-cell; width:50%;" runat="server" id="divPreSelCity">
                    <select id="DdlPresentAddressCities" runat="server" class="mandatory" type="select-one" 
                        messagetext="City of present address"
                        onchange="javascript:$('#ContentPlaceHolder1_TxtHiddenPresentAddressCity').val($('#ContentPlaceHolder1_DdlPresentAddressCities').val());" />
                   </div>
                   <div style="display:table-cell; width:50%;" id="divPreSelPinCode">
                     <asp:TextBox ID="TxtPresentAddressPinCode" runat="server" class="mandatory" Style="margin-left:10px;" messagetext="Pin-Code of present address"  pincode="true" MaxLength="6"/>
                     <cc1:FilteredTextBoxExtender ID="filTxt" runat="server" TargetControlID="TxtPresentAddressPinCode" FilterMode="ValidChars" FilterType="Numbers"></cc1:FilteredTextBoxExtender>

                    <div style="display:none;">
                        <div>
                                <label for="ContentPlaceHolder1_DdlPresentAdrressHiddenState">HiddenState</label>
                                <select id="DdlPresentAdrressHiddenState" runat="server"/>
                                <label for="ContentPlaceHolder1_TxtHiddenPresentAddressState">hidden state</label>
                                <asp:TextBox ID="TxtHiddenPresentAddressState" runat="server" />
                        </div>
                        <div>
                                <label for="ContentPlaceHolder1_DdlPresentAddressHiddenCities">HiddenCity</label>
                                <select id="DdlPresentAddressHiddenCities" runat="server"/>
                                <label for="ContentPlaceHolder1_TxtHiddenPresentAddressCity">hidden city</label>
                                <asp:TextBox ID="TxtHiddenPresentAddressCity" runat="server" />
                        </div>
                   </div>
                </div>
              </td>
            </tr>
             <tr>
              <td  style="vertical-align:middle;">
               <asp:Label CssClass="labelStyle" runat="server" ID="Label11" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
               <asp:Label CssClass="labelStyle" runat="server" ID="lbPerAddress" Text="ADDRESS (PERMANENT)" AssociatedControlID="TxtPermanentAddress"></asp:Label>
                       <%--<asp:CheckBox runat="server" ID="rbSameAsPresent" Text="Same as Present"  OnCheckedChanged="rbsapClicked"  AutoPostBack="true" Font-Names="Verdana" />--%>
               </td>
                 <td  colspan="2" style="vertical-align:middle;">
                      Building, Lane Details<br />
                     <asp:TextBox ID="TxtPermanentAddress" runat="server" Width="90%" class="mandatory" messagetext="Permanent address"  />&nbsp;
                     <label class="skiplink" for="ContentPlaceHolder1_TxtPermanentAddress" > 	Permanent Address, Building, Lane Details</label>
                 </td>
                    
                 <td style="vertical-align:middle;">
                     <asp:RadioButton ID="RdbLastReachableOnPermanentAddress" runat="server" GroupName="Address" />
                      <span class="radioButtonText">last reachable on this address</span>
                    <label for="ContentPlaceHolder1_RdbLastReachableOnPermanentAddress" class="skiplink">last reachable on permanent address</label>
                 </td>
             </tr>
          <tr>
              <td>
                  &nbsp;
              </td>
              <td>
                  <asp:Label CssClass="labelStyle" runat="server" ID="Label23" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                 <asp:Label CssClass="labelStyle" runat="server" ID="lbDdlPermanentCountry" for="ContentPlaceHolder1_DdlPermanentCountry" Text="COUNTRY" AssociatedControlID="DdlPermanentCountry"></asp:Label>

              </td>
              <td>
                 <asp:Label CssClass="labelStyle" runat="server" ID="Label24" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                 <asp:Label CssClass="labelStyle" runat="server" ID="lbDdlPermanentAddressStates" for="ContentPlaceHolder1_DdlPermanentAddressStates" Text="STATE" AssociatedControlID="DdlPermanentAddressStates"></asp:Label>
              </td>
              <td>
                <div style="display:table-row; width:100%;">
                <div style="display:table-cell; width:50%;" runat="server" id="divPerCity">
                   <asp:Label CssClass="labelStyle" runat="server" ID="Label25" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                   <asp:Label CssClass="labelStyle" runat="server" ID="lbDdlPermanentAddressCities" for="ContentPlaceHolder1_DdlPermanentAddressCities" Text="CITY" AssociatedControlID="DdlPermanentAddressCities"></asp:Label>
                </div>
                  <div style="display:table-cell; width:50%;" runat="server" id="divPerPinCode">
                    <asp:Label CssClass="labelStyle" runat="server" ID="Label26" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                    <asp:Label CssClass="labelStyle" runat="server" ID="ContentPlaceHolder1_TxtPermanentAddressPinCode" Text="PIN-CODE" AssociatedControlID="TxtPermanentAddressPinCode"></asp:Label>
                  </div>
                </div>
              </td>
          </tr>
          <tr>
            <td></td>
           <td style="vertical-align:middle;">
                    <select id="DdlPermanentCountry" runat="server" type="select-one"
                        class="mandatory" messagetext="Country of permanent address"
                        onchange="javascript:DdlCountries_OnSelectedIndexChanged(this.value,'CountryID','ContentPlaceHolder1_DdlPermanentAddressStates','ContentPlaceHolder1_DdlPermanentHiddenStates');"
                        >
                    </select>
          </td>
                <td style="vertical-align:middle;">
                    <select id="DdlPermanentAddressStates" runat="server" type="select-one"
                        class="mandatory" messagetext="State of permanent address"
                        onchange="javascript:DdlPermanentAddressStates_SelectedIndexChanged(this.value,'StateID','ContentPlaceHolder1_DdlPermanentAddressCities','ContentPlaceHolder1_DdlPermanentAddressHiddenCities');" />

                    <%--<asp:Button ID="BtnPopulatePermanentAddressCities" runat="server" Text="Refresh Cities" IsRefresh="true"
                        ToolTip="Refresh permanent address cities" OnClick="BtnPopulatePermanentAddressCities_Click" />--%>
                </td>
                <td style="vertical-align:middle;">
                    <div style="display:table-cell; width:50%;" runat="server" id="divPerSelCity">
                    <select id="DdlPermanentAddressCities" runat="server" type="select-one"
                        class="mandatory" messagetext="City of permanent address" 
                        onchange="javascript:$('#ContentPlaceHolder1_TxtPermanentHiddenAddressCity').val($('#ContentPlaceHolder1_DdlPermanentAddressCities').val());" />


                 </div>
                 <div style="display:table-cell; width:50%;" runat="server" id="divPerSelPinCode">
                   <asp:TextBox ID="TxtPermanentAddressPinCode" runat="server" Style="margin-left:10px;"
                         class="mandatory" messagetext="Pin-Code of permanent address"
                         pincode="true" MaxLength="6"
                        />
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="TxtPermanentAddressPinCode" FilterMode="ValidChars" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                    <div style="display:none;">
                        <div>
                                <label for="ContentPlaceHolder1_DdlPermanentHiddenStates">HiddenState</label>
                                <select id="DdlPermanentHiddenStates" runat="server"/>
                                <label for="ContentPlaceHolder1_TxtPermanentHiddenAddressState">hidden state</label>
                                <asp:TextBox ID="TxtPermanentHiddenAddressState" runat="server" />
                        </div>
                        <div>
                                <label for="ContentPlaceHolder1_DdlPermanentAddressHiddenCities">HiddenCity</label>
                                <select id="DdlPermanentAddressHiddenCities" runat="server"/>
                                <label for="ContentPlaceHolder1_TxtPermanentHiddenAddressCity">hidden city</label>
                                <asp:TextBox ID="TxtPermanentHiddenAddressCity" runat="server" />
                        </div>
                  </div>
                 </div>
                </td>
            </tr>
             <tr>
                    <td style="vertical-align:middle">
                        <label for="ContentPlaceHolder1_TxtEmailAddress">Email</label>
                    </td>
                    <td colspan="2" style="vertical-align:middle;"><asp:TextBox ID="TxtEmailAddress" runat="server" Width="90%" /></td>
                    <td>&nbsp;</td>
             </tr>
                <tr>
                    <td style="vertical-align:middle;">
                        <asp:Label CssClass="labelStyle" runat="server" ID="Label17" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                        <asp:Label  Font-Size="10px" runat="server" ID="ContentPlaceHolder1_TxtRelevantDocumentDetails" Text="RELEVANT DOCUMENTS SUBMITTED" AssociatedControlID="RdbRelevantDocumentsSubmittedYes"></asp:Label>
                    </td>
                    <td colspan="3" style="vertical-align:middle; width:100%;">
                        <div style="display:table-cell; width:50%;">
                        <asp:RadioButton ID="RdbRelevantDocumentsSubmittedYes" runat="server" GroupName="Docuements" Text=""  />
                        <span class="radioButtonText">Yes</span>&nbsp;
                        <asp:RadioButton ID="RdbRelevantDocumentsSubmittedNo" runat="server" GroupName="Docuements" />
                        <span class="radioButtonText">No</span>&nbsp;
                        <asp:TextBox ID="TxtRelevantDocumentDetails" Width="120px" runat="server"  messagetext="Relevant documents detail"  ToolTip="Details regarding document submission" />
                        </div>
                         <div style="display:table-cell;">
                              <asp:Label CssClass="labelStyle" runat="server" ID="lbWorkExpProofT" Text="Exp Proof: "></asp:Label>
                              <telerik:RadComboBox runat="server" ID="rcWep" CheckBoxes="true"></telerik:RadComboBox>
                         </div>
                    </td>
                </tr>
                <tr>
                   <td colspan="3">
                       <div style="width:100%;">
                           <table style="border-collapse:separate; border-spacing:1px;">
                               <tr>
                                   <td colspan="2" style="width:66%; vertical-align:middle; text-align:left;">
                                       <div style="display:table-row;">
                                            <div style="display:table-cell;">
                                               <asp:Label  runat="server" ID="lbMartS" Text="Maritial Status: " Width="150px" ></asp:Label>
                                                <asp:RadioButton ID="RdbSingle" runat="server" GroupName="MaritialStatus"/>
                                               <span class="radioButtonText">Single</span>
                                             </div>
                                             <div style="display:table-cell; display:none;"><label for="ContentPlaceHolder1_RdbSingle" class="skiplink">Maritial Status, Single</label></div>
                                             <div style="display:table-cell;">
                                                 <asp:RadioButton ID="RdbMarried" runat="server" GroupName="MaritialStatus"/>
                                                 <span class="radioButtonText">Married</span>
                                             </div>
                                             <div style="display:table-cell;  display:none;">
                                                 <label for="ContentPlaceHolder1_RdbMarried" class="skiplink">Maritial Status ,Married</label>
                                             </div>
                                        </div>

                                  </td>
                                   <td rowspan="4" style="width:33%;">
                              
                                        <div  style="border-style:double;border-width:2px;border-color:#4C77A4;width:105px;height:112px; vertical-align:middle; text-align:center; display:table-cell;">
                                            <asp:Image ID="ImgCandidatePhoto" runat="server" AlternateText="candidate's photograph" />
                                        </div>
                                   </td>
                               </tr>
                               <tr>
                                   <td style="vertical-align:middle;" >
                                      <asp:Label runat="server" ID="lbMst2" Width="150px" Text="Bio-data submitted"></asp:Label>
                                      <asp:CheckBox ID="ChkBiodataHardCopy" runat="server" GroupName="BioDataSubmission" />
                                      <asp:Label runat="server" ID="lbhc" Text="Hard Copy"></asp:Label>
                                  </td>
                                <td>
                                  <label for="ContentPlaceHolder1_ChkBiodataHardCopy" class="skiplink">Bio-data submitted, Hard copy</label>
                                  <asp:CheckBox ID="ChkBiodataSoftCopy" runat="server" GroupName="BioDataSubmission" />
                                  <asp:Label runat="server" ID="lbMst3" Text="Soft Copy"></asp:Label>
                                  <label for="ContentPlaceHolder1_ChkBiodataSoftCopy" class="skiplink">Bio-data submitted, Soft copy</label>
                                   </td>
                               </tr>
                               <tr>
                                   <td style="width:33%;" >
                                        <asp:Label runat="server" ID="Label12" Width="150px" Text="Joining Form signed"></asp:Label>
                                        <asp:CheckBox ID="ChkJoiningFormSigned" runat="server"  />
                                   </td>
                                   <td style="width:33%;">
                                    <div id="TblJoiningFormType" runat="server">
                                      <label for="ContentPlaceHolder1_TxtJoiningFormTypes">Types</label>
                                      <asp:TextBox ID="TxtJoiningFormTypes" runat="server" />
                                      <label for="ContentPlaceHolder1_ChkJoiningFormSigned" class="skiplink">Joining Form signed</label>&nbsp;&nbsp;
                                      <label for="ContentPlaceHolder1_TxtJoiningFormTypes">Types</label>
                                    </div>
                                   </td>
                               </tr>
                               <tr>
                                   <td colspan="2">
                                            <asp:Label CssClass="labelStyle" runat="server" ID="lbFileUpload"  for="ContentPlaceHolder1_FuUploadPhoto" Text="Upload Photograph" AssociatedControlID="FuUploadPhoto"></asp:Label>
                                            <asp:FileUpload ID="FuUploadPhoto" runat="server"  class="mandatory" />
                                   </td>
                               </tr>
                           </table>
                       </div>
                   </td>
                    <td></td>
               </tr>
                <tr>
                    <td colspan="2" style="vertical-align:middle; text-align:center;">
                       
                        <asp:Button ID="BtnRegister" runat="server" Text="Register" Font-Bold="true" OnClientClick="javascript:return validRegistration();"
                            OnClick="BtnRegisterCandidate_Click" />&nbsp;&nbsp;
                        <asp:Button ID="BtnClear" Font-Bold="true" runat="server" Text="Clear" OnClick="BtnClear_Click"/>  
                        <input id="BtnShowConfirm" type="button" onclick="javascript: return CheckForDuplication();" style="display:none;" />
                    </td>
                    <td colspan="2"></td>
                </tr>
               <tr style="display:none;">
                 <td>
                     <label for="ctl00_ContentPlaceHolder2_DdlPresentAdrressHiddenState">HiddenState</label>
                     <select id="Select1" runat="server"/>
                     <span id="SpnPresentAdrressHiddenState" runat="server"  />
                      <label for="ctl00_ContentPlaceHolder2_TxtHiddenPresentAddressState">hidden state</label>
                     <asp:TextBox ID="TextBox2" runat="server" />
                 </td>
                 <td>
                     <label for="ctl00_ContentPlaceHolder2_DdlPresentAddressHiddenCities">HiddenCity</label>
                     <select id="Select2" runat="server"/>
                     <span id="SpnPresentAddressHiddenCitiesID" runat="server"  />
                     <label for="ctl00_ContentPlaceHolder2_TxtHiddenPresentAddressCity">hidden city</label>
                     <asp:TextBox ID="TextBox3" runat="server" />
                 </td>
                   <td>
                   </td>
                   <td></td>
             </tr>
               <tr style="display:none;">
                   <td>
                       <label for="ctl00_ContentPlaceHolder2_DdlHiddenDisabilitySubTypes">HiddenDisablitySubTypes</label>
                       <select id="Select3" runat="server"/>
                       <span id="SpnHiddenDisabilitySubTypesID" runat="server" />
                       <label for="ctl00_ContentPlaceHolder2_TxtHiddenDisabilitySubTypes">HiddenDisablitySubTypes</label>
                       <asp:TextBox ID="TextBox4" runat="server" />
                   </td>
                   <td></td><td></td><td></td>
               </tr>
                 <tr style="display:none;">
                     <td>
                         <label for="ctl00_ContentPlaceHolder2_DdlPermanentHiddenStates">HiddenState</label>
                         <select id="Select4" runat="server"/>
                         <span id="SpnPermanentHiddenStates" runat="server"  />
                         <label for="ctl00_ContentPlaceHolder2_TxtPermanentHiddenAddressState">hidden state</label>
                         <asp:TextBox ID="TextBox5" runat="server" />
                     </td>
                     <td>
                         <label for="ctl00_ContentPlaceHolder2_DdlPermanentAddressHiddenCities">HiddenCity</label>
                         <select id="Select5" runat="server"/>
                         <span id="SpnPermanentAddressHiddenCitiesID" runat="server"  />
                         <label for="ctl00_ContentPlaceHolder2_TxtPermanentHiddenAddressCity">hidden city</label>
                         <asp:TextBox ID="TextBox6" runat="server" />
                     </td>
                 </tr>


    </tbody>
    </table>
    </div>
           <%-- hidden number for checking duplicaion--%>
           <div style="display:none;">
                        <label for="ContentPlaceHolder1_TxtHiddenNumber">hidden number</label>
                        <asp:TextBox ID="TxtHiddenNumber" runat="server" Text="1" />
             </div>
    <script src="../Scripts/jquery-2.1.4.min.js"></script>
    <script src="../Scripts/Common.js"></script>
    <script src="mdRegistration.js"></script>
     

</asp:Content>
