<%@ Page Title="" Language="C#" MasterPageFile="~/MobileDevices/mobileMaster.Master" AutoEventWireup="true" CodeBehind="candidateRegistration.aspx.cs" Inherits="EnableIndia.MobileDevices.candidateRegistration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div style="vertical-align:top;">
    <table style="border-collapse:separate; border-spacing:0px; border-width:0px;">
     <tr>
        <td>
              Registration > Enable India Candidate
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
          <td style="vertical-align:middle;">
              <asp:Label CssClass="labelStyle" runat="server" ID="lbFileNumber"  Text="File Number" AssociatedControlID="TxtFileNumber" for="ContentPlaceHolder1_TxtFileNumber"></asp:Label>
          </td>
          <td style="vertical-align:middle;"><asp:TextBox ID="TxtFileNumber" runat="server" /></td>
          <td  style="padding-left:30px;width:135px;vertical-align:middle;">
              <asp:Label CssClass="labelStyle" runat="server" ID="Label12" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
              <asp:Label CssClass="labelStyle" runat="server" ID="ContentPlaceHolder1_TxtRegistrationDate" Text="REGISTRATION DATE" AssociatedControlID="TxtRegistrationDate"></asp:Label>
          </td>
          <td>
          <asp:TextBox ID="TxtRegistrationDate" runat="server" class="mandatory" messagetext="Registration date" date="true" yearlength="4"/>
          <asp:ImageButton runat="server" ID="ImageButton1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" />
          <cc1:CalendarExtender runat="server" ID="CalendarExtender2" PopupButtonID="ImageButton1" TargetControlID="TxtRegistrationDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
          <asp:RegularExpressionValidator ID="revDateOfBirth" ControlToValidate="TxtRegistrationDate"
              ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
              runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" /><br />(DD/MM/YYYY) 
              </td>
     </tr>
    <tr runat="server" id="TblRegistrationID" visible="false">
     <td style="text-align:left; vertical-align:middle;">Registration ID</td>
     <td  colspan="3" style= "width:100%;text-align:left; vertical-align:middle;">
        <span id="SpnregistrationID" runat="server" />
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
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
            </td>
            <td colspan="2" style="vertical-align:middle;">
                (DD/MM/YYYY) 
            </td>
        </tr>
        <tr>
      <td style="vertical-align:middle;">
            <asp:Label runat="server" ID="Label18" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
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
                  <div style="display:table-cell; width:50%;">
                    <asp:Label CssClass="labelStyle" runat="server" ID="Label9" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                    <asp:Label CssClass="labelStyle" runat="server"  ID="lbDdlPresentAddressCities" for="ContentPlaceHolder1_DdlPresentAddressCities" Text="CITY" AssociatedControlID="DdlPresentAddressCities"></Asp:Label>
                   </div>
                  <div style="display:table-cell; width:50%;">
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
                   <div style="display:table-cell; width:50%;">
                    <select id="DdlPresentAddressCities" runat="server" class="mandatory" type="select-one" 
                        messagetext="City of present address"
                        onchange="javascript:$('#ContentPlaceHolder1_TxtHiddenPresentAddressCity').val($('#ContentPlaceHolder1_DdlPresentAddressCities').val());" />
                   </div>
                   <div style="display:table-cell; width:50%;">
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
                <div style="display:table-cell; width:50%;">
                   <asp:Label CssClass="labelStyle" runat="server" ID="Label25" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                   <asp:Label CssClass="labelStyle" runat="server" ID="lbDdlPermanentAddressCities" for="ContentPlaceHolder1_DdlPermanentAddressCities" Text="CITY" AssociatedControlID="DdlPermanentAddressCities"></asp:Label>
                </div>
                  <div style="display:table-cell; width:50%;">
                    <asp:Label CssClass="labelStyle" runat="server" ID="Label26" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                    <asp:Label CssClass="labelStyle" runat="server" ID="ContentPlaceHolder1_TxtPermanentAddressPinCode" Text="PIN-CODE" AssociatedControlID="TxtPermanentAddressPinCode"></asp:Label>
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
                    <div style="display:table-cell; width:50%;">
                    <select id="DdlPermanentAddressCities" runat="server" type="select-one"
                        class="mandatory" messagetext="City of permanent address" 
                        onchange="javascript:$('#ContentPlaceHolder1_TxtPermanentHiddenAddressCity').val($('#ContentPlaceHolder1_DdlPermanentAddressCities').val());" />


                 </div>
                 <div style="display:table-cell; width:50%;">
                   <asp:TextBox ID="TxtPermanentAddressPinCode" runat="server" 
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
                    <td colspan="3" style="vertical-align:middle;">
                        <asp:RadioButton ID="RdbRelevantDocumentsSubmittedYes" runat="server" GroupName="Docuements" Text=""  />
                        <span class="radioButtonText">Yes</span>&nbsp;&nbsp;
                        <asp:RadioButton ID="RdbRelevantDocumentsSubmittedNo" runat="server" GroupName="Docuements" />
                        <span class="radioButtonText">No</span>&nbsp;&nbsp;
                        <asp:TextBox ID="TxtRelevantDocumentDetails" runat="server" 
                            messagetext="Relevant documents detail"
                            ToolTip="Details regarding document submission" /><br style="font-size:2px" />
                         <div><label for="ContentPlaceHolder1_RdbRelevantDocumentsSubmittedYes" class="skiplink">ALL RELEVANT DOCUMENTS SUBMITTED, Yes</label></div>
                         <div><label for="ContentPlaceHolder1_RdbRelevantDocumentsSubmittedNo" class="skiplink">ALL RELEVANT DOCUMENTS SUBMITTED, No</label></div>
                    </td>
                </tr>
                <tr>
                  <td style="vertical-align:middle;">
                     <asp:Label runat="server" ID="lbMst" Text="Marital Status"></asp:Label></td>
                    <td  style="vertical-align:middle;">
                       <asp:RadioButton ID="RdbSingle" runat="server" GroupName="MaritialStatus" />
                       <span class="radioButtonText">Single</span>
                   </td>
                   <td colspan="2" style="vertical-align:bottom;">
                       <label for="ContentPlaceHolder1_RdbSingle" style="vertical-align:middle;" class="skiplink">
                       <asp:Label runat="server" ID="lbMst1" Text="Maritial Status, Single"></asp:Label></label>
                       <asp:RadioButton ID="RdbMarried" runat="server" GroupName="MaritialStatus" />
                       <span class="radioButtonText">Married</span>&nbsp;&nbsp;<br style="font-size:2px;" />
                   <div  style="vertical-align:middle;"><label for="ContentPlaceHolder1_RdbMarried" class="skiplink">Maritial Status, Married</label></div>
                   </td>
               </tr>
               <tr>
                   <td style="vertical-align:middle;">
                     <asp:Label runat="server" ID="lbMst2" Text="Bio-data submitted"></asp:Label></td>
                   <td  style="vertical-align:,middle;" >
                    <asp:CheckBox ID="ChkBiodataHardCopy" runat="server" GroupName="BioDataSubmission" />&nbsp;&nbsp;
                    <asp:Label runat="server" ID="lbhc" Text="Hard Copy"></asp:Label>
                    </td>
                 <td colspan="2" style="vertical-align:middle;">
                     <label for="ContentPlaceHolder1_ChkBiodataHardCopy" class="skiplink">Bio-data submitted, Hard copy</label>
                     <asp:CheckBox ID="ChkBiodataSoftCopy" runat="server" GroupName="BioDataSubmission" />
                     <asp:Label runat="server" ID="lbMst3" Text="Soft Copy"></asp:Label>
                     <div style="vertical-align:middle;" ><label for="ContentPlaceHolder1_ChkBiodataSoftCopy" class="skiplink">Bio-data submitted, Soft copy</label></div>
                  </td>
               </tr>
                <tr>
                    <td style="vertical-align:middle;"><asp:Label runat="server" ID="lbJfs" Text="Joining Form signed"></asp:Label> </td>
                    <td style="vertical-align:middle;"><asp:CheckBox ID="ChkJoiningFormSigned" runat="server" /></td>
                    <td style="vertical-align:middle;"><label for="ContentPlaceHolder1_TxtJoiningFormTypes">Types</label><asp:TextBox ID="TxtJoiningFormTypes" runat="server" /></td>
                    <td style="vertical-align:middle;"><label for="ContentPlaceHolder1_ChkJoiningFormSigned" class="skiplink">Joining Form signed</label></td>
               </tr>
                  <tr>
                      <td style="vertical-align:middle;">
                          <asp:Label CssClass="labelStyle" runat="server" ID="lbFileUpload"  for="ContentPlaceHolder1_FuUploadPhoto" Text="Upload Photograph" AssociatedControlID="FuUploadPhoto"></asp:Label>
                      </td>
                      <td style="vertical-align:middle;">
                          <asp:FileUpload ID="FuUploadPhoto" runat="server"  class="mandatory" />
                      </td>
                      <td  style="border-style:double;border-width:2px;border-color:#4C77A4;width:105px;height:112px; vertical-align:middle; text-align:center;">
                            &nbsp;
                      </td>
                      <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="vertical-align:middle; text-align:center;">
                       
                        <asp:Button ID="BtnRegisterCandidate" runat="server" Text="Register" OnClientClick="javascript:return validRegistration();"
                            OnClick="BtnRegisterCandidate_Click" />&nbsp;&nbsp;
                        <input id="BtnShowConfirm" type="button" onclick="javascript:return CheckForDuplication();" style="display:none" />
                        <asp:Button ID="BtnClear" runat="server" Text="Clear" OnClick="BtnClear_Click"/>  
                    </td>
                </tr>
         </tbody>
   </table>
    </div>
           <div style="display:none;">
                        <label for="ContentPlaceHolder1_TxtHiddenNumber">hidden number</label>
                        <asp:TextBox ID="TxtHiddenNumber" runat="server" Text="1" />
             </div>
    <script src="../Scripts/jquery-2.1.4.min.js"></script>
    <script src="../Scripts/Common.js"></script>
    <script src="candidateRegistration.js"></script>
</asp:Content>
