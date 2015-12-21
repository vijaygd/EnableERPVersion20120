<%@ Page Title="Candidate Profile" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.ProfileHistory.Registration" Codebehind="Registration.aspx.cs" ClientIDMode="Static" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td class="pageHeader">
            Candidate Section
        </td>
    </tr>
</table> 
   
<table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">    
    <tr>
        <td>Profile and History > Candidate Profile</td>
    </tr>
</table>    

<table cellpadding="0" cellspacing="0" style="margin-top:10px">
    <tr>
        <td style="width:15px">&nbsp;</td>
        <td align="center">Registration</td>
        <td align="center" style="padding-left:12px">
            <asp:LinkButton ID="LnkBtnEducationalQualifications" runat="server" Text="Educational Qualifications"
                PostBackUrl="~/Candidate/ProfileHistory/EducationalQualifications.aspx" 
                CssClass="tab_links" />
        </td>
        <td align="center" style="padding-left:12px">
            <asp:LinkButton ID="LnkBtnWorkExperience" runat="server" Text="Work Experience"
                PostBackUrl="~/Candidate/ProfileHistory/CandidateWorkExperience.aspx" CssClass="tab_links" />
        </td>
        <td align="center" style="padding-left:12px">
            <asp:LinkButton ID="LnkBtnKnowledgeAndTraining" runat="server" Text="Knowledge and Training"
                PostBackUrl="~/Candidate/ProfileHistory/CandidateKnowledgeTraining.aspx" CssClass="tab_links" />
        </td>
        <td align="center" style="padding-left:12px">
            <asp:LinkButton ID="LnkBtnJobProfiling" runat="server" Text="Job Profiling"
                PostBackUrl="~/Candidate/ProfileHistory/CandidateJobProfile.aspx" CssClass="tab_links" />
        </td>
        <td align="center" style="padding-left:12px">
            <asp:LinkButton ID="LnkButtonCandidateHistory" runat="server" Text="Candidate History" CssClass="tab_links" 
            PostBackUrl="~/Candidate/ProfileHistory/AddViewCandidateHistory.aspx" />
        </td>
        <td align="center" style="padding-left:12px">
            <asp:LinkButton ID="LnkButtonSocioIncomicIndicator" runat="server" Text="Socio Economic Indicator" CssClass="tab_links" 
            PostBackUrl="~/Candidate/ProfileHistory/SocioEconomicList.aspx" />
        </td>
    </tr>
</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink">Registration Form</span></h1>
        </td>
    </tr>
</table>

<table class="skiplink" cellpadding="0" cellspacing="0">
    <tr>
        <td><h2 class="skiplink">Basic Information</h2></td>
    </tr>
</table>

<table cellpadding="4" style="margin-top:0px">
    <tr>
        <td>
            <table>
                <tr>
                    <td valign="top" style="white-space:nowrap">Registration ID&nbsp;&nbsp;</td>
                    <td valign="top" style="white-space:nowrap"><span id="SpnRegistrationID" runat="server" /></td>
                    <td style="width:20px">&nbsp;</td>
                    
                    <td valign="top" style="white-space:nowrap">Candidate's NGO</td>
                    <td valign="top" style="width:120px"><span id="SpanCandidateNGO" runat="server" class="readonlyText" /></td>
                    <td style="width:20px">&nbsp;</td>
                    
                    <td valign="top" style="width:150px"><label id="LblCandidateIDAtNGO" runat="server" for="ctl00_ContentPlaceHolder2_TxtCandidateIDAtNGO" visible="false" >Candidate's ID at NGO </label></td>
                    <td valign="top">
                        <asp:TextBox ID="TxtCandidateIDAtNGO" runat="server" Visible="false"/>
                        <span id="SpnNgoID" runat="server" visible="false" />
                    </td>
                    <td valign="top" id="TdMessageForNGO" runat="server" visible="false">(only for other NGO candidates)</td>
                </tr>
            </table>
            <table>
                <tr>
                    <td valign="top" style="width:145px"><label for="ctl00_ContentPlaceHolder2_TxtFileNumber">File Number</label></td>
                    <td valign="top"><asp:TextBox ID="TxtFileNumber" runat="server" /></td>
                    <td style="width:20px">&nbsp;</td>
                    
                    <td style="width:170px">
                        <span id="SpnRegistrationDate"> REGISTRATION DATE </span>
                            
                        </td>
                    <td>
                        <asp:TextBox ID="TxtRegistrationDate" runat="server" Visible ="false" /><br />
                    </td>
                    <td><span id="SpnRegistartionDate" runat="server" class="readonlyText" visible="false"></span><br />
                        (DD/MM/YYYY)
                    </td>
                </tr>
            </table>
             <table style="display:none" >
           <%-- hidden number for checking duplicaion--%>
                <tr>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_TxtHiddenNumber">hidden number</label>
                        <asp:TextBox ID="TxtHiddenNumber" runat="server" Text="1" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td valign="top" style="width:145px">NAME OF CANDIDATE</td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <label for="ctl00_ContentPlaceHolder2_TxtCandidateFirstName">First Name</label><br />
                                    <asp:TextBox ID="TxtCandidateFirstName" runat="server" 
                                        datatype="string" class="mandatory" messagetext="First name" />
                                </td>
                                <td style="width:30px"></td>
                                <td>
                                    <label for="ctl00_ContentPlaceHolder2_TxtCandidateMiddleName">Middle Name</label><br />
                                    <asp:TextBox ID="TxtCandidateMiddleName" datatype="string" runat="server" />
                                </td>
                                <td style="width:30px"></td>
                                <td>
                                    <label for="ctl00_ContentPlaceHolder2_TxtCandidateLastName">Last Name</label><br />
                                    <asp:TextBox ID="TxtCandidateLastName" runat="server" 
                                        datatype="string" class="mandatory" messagetext="Last name" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width:145px"><label for="ctl00_ContentPlaceHolder2_DdlDisabilityTypes">DISABILITY TYPE</label></td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="4"  >
                                    <select id="DdlDisabilityTypes" runat="server" class="mandatory" messagetext="Disability type" 
                                        onchange="javascript:FilterCityStates(this.value,'DisabiltyTypeID','DdlDisabilitySubTypes','DdlHiddenDisabilitySubTypes');"/>
                                </td>
                                <td style="width:30px"></td>
                                <td style="width:60px">
                                    <label for="ctl00_ContentPlaceHolder2_DdlDisabilitySubTypes">SUB TYPE</label></td>
                                <td>
                                    <select id="DdlDisabilitySubTypes" runat="server"  class="mandatory" messagetext="Disability sub type" 
                                        onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHiddenDisabilitySubTypes').val($('#ctl00_ContentPlaceHolder2_DdlDisabilitySubTypes').val());" />
                                </td>
                                 <td>
                                    <table style="display:none">
                                        <tr>
                                            <td>
                                                <label for="ctl00_ContentPlaceHolder2_DdlHiddenDisabilitySubTypes">HiddenDisablitySubTypes</label>
                                                <select id="DdlHiddenDisabilitySubTypes" runat="server"/>
                                                <span id="SpnHiddenDisabilitySubTypesID" runat="server" />
                                                <label for="ctl00_ContentPlaceHolder2_TxtHiddenDisabilitySubTypes">HiddenDisablitySubTypes</label>
                                                <asp:TextBox ID="TxtHiddenDisabilitySubTypes" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width:145px"><label for="ctl00_ContentPlaceHolder2_TxtDateOfBirth">DATE OF BIRTH </label></td>
                    <td>
                        <table cellpadding="2" cellspacing="0">
                            <tr>
                                <td><asp:TextBox ID="TxtDateOfBirth" runat="server" class="mandatory" messagetext="Date of birth" date="true"  yearlength="4"/></td>
                            </tr>
                        </table>
                    </td>
                    <td >(DD/MM/YYYY)</td>
                    <td style="width:30px">&nbsp;</td>
                    <td class="readonlyText">Age&nbsp;</td>
                    <td><span ID="SpnAge" runat="server" class="readonlyText" /></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:145px">GENDER</td>
                    <td style="white-space:nowrap">
                        <asp:RadioButton ID="RdbMale" runat="server" GroupName="Gender" Checked="true"  />
                        <span class="radioButtonText">Male</span>
                        
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_RdbMale" class="skiplink">Gender ,Male</label></td>
                    <td style="white-space:nowrap">
                        <asp:RadioButton ID="RdbFemale" runat="server" GroupName="Gender" />
                        <span class="radioButtonText">Female</span>
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_RdbFemale" class="skiplink">Gender ,Female</label></td>
                    <td style="padding-left:60px"><label for="ctl00_ContentPlaceHolder2_TxtOldRegistrationNumber">Old Registration number</label></td>
                    <td><asp:TextBox ID="TxtOldRegistrationNumber" runat="server"></asp:TextBox></td>
                </tr>
            </table>
            
            <table cellpadding="0" cellspacing="0" class="skiplink">
                <tr>
                    <td><h2 class="skiplink">Contact Information</h2></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:180px"><label id="lblPrimaryPhoneNumber" for="ctl00_ContentPlaceHolder2_TxtPrimaryPhoneNumber">PHONE NUMBER (PRIMARY )</label></td>
                    <td>
                        <table cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="TxtPrimaryPhoneNumber" runat="server" 
                                        class="mandatory" messagetext="Primary phone number" phonenumber="true" />
                                </td>
                                <td>
                                    <asp:RadioButton ID="RdbLastREachableOnPrimaryPhoneNumber" runat="server" GroupName="PhoneNumber"
                                       />
                                    <span class="radioButtonText">last reachable on this phone.</span>
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_RdbLastREachableOnPrimaryPhoneNumber" class="skiplink">last reachable on primary phone number</label></td>
                                <td>
                                    <a id="LnkPhoneHistory" CandidateID='<%= Request.QueryString["cand"] %>' class="readonlyText" 
                                        href="javascript:ShowPopUp('CandidatePhoneAddressHistory.aspx?cand=' + $('#LnkPhoneHistory').attr('CandidateID') + '&hist=ph',600,500);">Phone history</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table id="TblNgoOfficeNuber" runat="server" visible="false">
                <tr>
                    <td style="width:190px"></td>
                    <td colspan="3">
                        <span id="SpnNGOOfficeNumber" runat="server" ></span>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width:180px"><label for="ctl00_ContentPlaceHolder2_TxtSecondaryPhoneNumber"> Phone number (Secondary)</label></td>
                    <td>
                        <table cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="TxtSecondaryPhoneNumber" runat="server" />
                                </td>
                                <td>
                                    <asp:RadioButton ID="RdbLastReachableOnSecondaryPhoneNumber" runat="server" GroupName="PhoneNumber" />
                                    <span class="radioButtonText">last reachable on this phone.</span>
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_RdbLastReachableOnSecondaryPhoneNumber" class="skiplink">last reachable on secondary phone number</label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" style="margin-top:2px">
                <tr>
                    <td>
                        <table cellspacing="0" cellpadding="0">
                            <tr>
                                <td id="TdPresentAddress" style="width:152px">ADDRESS (PRESENT)</td>
                                <td>
                                     Building, Lane Details<br />
                                    <asp:TextBox ID="TxtPresentAddress" runat="server" Width="400px"
                                        class="mandatory" messagetext="Present address" />&nbsp;
                                </td>
                                <td>
                                    <label class="skiplink" for="ctl00_ContentPlaceHolder2_TxtPresentAddress">PRESENT ADDRESS, Building, Lane Details</label>
                                </td>
                                <td style="white-space:nowrap">
                                    <asp:RadioButton ID="RdbLastReachableOnPresentAddress" runat="server" GroupName="Address" Checked="true"/>
                                    <span class="radioButtonText">last reachable on this address.</span> 
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_RdbLastReachableOnPresentAddress" class="skiplink">last reachable on present address</label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" style="margin-left:152px">
                <tr>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_DdlPresentCountry" >COUNTRY</label><br />
                        <select id="DdlPresentCountry" runat="server"
                            class="mandatory"
                            messagetext="Country of present address"
                           onchange="javascript:DdlCountries_OnSelectedIndexChanged(this.value,'CountryID','DdlPresentAddressStates','DdlPresentAdrressHiddenState');" ></select>
                    </td>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_DdlPresentAddressStates">STATE</label><br />
                        <select id="DdlPresentAddressStates" runat="server" class="mandatory" messagetext="State of present address" 
                            onchange="javascript:DdlPresentAddressStates_SelectedIndexChanged(this.value,'StateID','DdlPresentAddressCities','DdlPresentAddressHiddenCities');"/>
                    </td>
                    <td style="width:15px">&nbsp;</td>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_DdlPresentAddressCities">CITY</label><br />
                        <select id="DdlPresentAddressCities" runat="server" class="mandatory" 
                            onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHiddenPresentAddressCity').val($('#ctl00_ContentPlaceHolder2_DdlPresentAddressCities').val());" 
                            messagetext="City of present address" />
                    </td>
                    <td style="width:15px">&nbsp;</td>
                    <td>
                        <table style="display:none" >
                            <tr>
                                <td>
                                    <label for="ctl00_ContentPlaceHolder2_DdlPresentAdrressHiddenState">HiddenState</label>
                                    <select id="DdlPresentAdrressHiddenState" runat="server"/>
                                    <span id="SpnPresentAdrressHiddenState" runat="server"  />
                                     <label for="ctl00_ContentPlaceHolder2_TxtHiddenPresentAddressState">hidden state</label>
                                    <asp:TextBox ID="TxtHiddenPresentAddressState" runat="server" />
                                </td>
                                <td>
                                    <label for="ctl00_ContentPlaceHolder2_DdlPresentAddressHiddenCities">HiddenCity</label>
                                    <select id="DdlPresentAddressHiddenCities" runat="server"/>
                                    <span id="SpnPresentAddressHiddenCitiesID" runat="server"  />
                                    <label for="ctl00_ContentPlaceHolder2_TxtHiddenPresentAddressCity">hidden city</label>
                                    <asp:TextBox ID="TxtHiddenPresentAddressCity" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_TxtPresentAddressPinCode" id="LblPresentPin">Pin-Code</label><br />
                        <asp:TextBox ID="TxtPresentAddressPinCode" runat="server" class="mandatory" messagetext="Pin-Code of present address" pincode="true"  />
                    </td>
                    <td>
                        <br />
                        <a id="LnkAddressHistory" CandidateID='<%= Request.QueryString["cand"] %>' class="readonlyText" 
                            href="javascript:ShowPopUp('CandidatePhoneAddressHistory.aspx?cand=' + $('#LnkAddressHistory').attr('CandidateID') + '&hist=addr',600,500);">Address history</a>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width:152px">
                       <span id="SpnParmanentAddress"> Address (Permanent)</span>
                    </td>
                    <td>
                        Building, Lane Details<br />
                        <asp:TextBox ID="TxtPermanentAddress" runat="server" Width="400px" MaxLength="0" class="mandatory" messagetext="Permanent address" />&nbsp;
                    </td>
                    <td>
                        <label class="skiplink" for="ctl00_ContentPlaceHolder2_TxtPermanentAddress">Permanent Address, Building, Lane Details</label>
                    </td>
                    <td style="white-space:nowrap">
                        <asp:RadioButton ID="RdbLastReachableOnPermanentAddress" runat="server" GroupName="Address" />
                        <span class="radioButtonText">last reachable on this address.</span> 
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_RdbLastReachableOnPermanentAddress" class="skiplink">last reachable on permanent address</label></td>
                </tr>
            </table>
            <table cellspacing="0" style="margin-left:152px">
                <tr>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_DdlPermanentCountry" id="LblCountry" >Country</label><br />
                        <select id="DdlPermanentCountry" runat="server"
                            class="mandatory" messagetext="Country of permanent address"
                            onchange="javascript:DdlCountries_OnSelectedIndexChanged(this.value,'CountryID','DdlPermanentAddressStates','DdlPermanentHiddenStates');" >
                        </select>
                    </td>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_DdlPermanentAddressStates" id="LblState">State</label><br />
                        <select id="DdlPermanentAddressStates" runat="server"
                            class="mandatory" messagetext="State of permanent address"
                            onchange="javascript:DdlPermanentAddressStates_SelectedIndexChanged(this.value,'StateID','DdlPermanentAddressCities','DdlPermanentAddressHiddenCities');" />
                    </td>
                    <td style="width:15px">&nbsp;</td>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_DdlPermanentAddressCities" id="LblCity">City</label><br />
                        <select id="DdlPermanentAddressCities" runat="server" class="mandatory" 
                            onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtPermanentHiddenAddressCity').val($('#ctl00_ContentPlaceHolder2_DdlPermanentAddressCities').val());"
                            messagetext="City of permanent address" />
                     </td>
                     
                     <td>
                        <table style="display:none">
                            <tr>
                                <td>
                                    <label for="ctl00_ContentPlaceHolder2_DdlPermanentHiddenStates">HiddenState</label>
                                    <select id="DdlPermanentHiddenStates" runat="server"/>
                                    <span id="SpnPermanentHiddenStates" runat="server"  />
                                    <label for="ctl00_ContentPlaceHolder2_TxtPermanentHiddenAddressState">hidden state</label>
                                    <asp:TextBox ID="TxtPermanentHiddenAddressState" runat="server" />
                                </td>
                                <td>
                                    <label for="ctl00_ContentPlaceHolder2_DdlPermanentAddressHiddenCities">HiddenCity</label>
                                    <select id="DdlPermanentAddressHiddenCities" runat="server"/>
                                    <span id="SpnPermanentAddressHiddenCitiesID" runat="server"  />
                                    <label for="ctl00_ContentPlaceHolder2_TxtPermanentHiddenAddressCity">hidden city</label>
                                    <asp:TextBox ID="TxtPermanentHiddenAddressCity" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width:15px">&nbsp;</td>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_TxtPermanentAddressPinCode" id="LblPinCode">Pin-Code</label><br />
                        <asp:TextBox ID="TxtPermanentAddressPinCode" runat="server" class="mandatory" messagetext="Pin-Code of permanent address" />
                    </td>
                </tr>
            </table>
            
             <table>
                <tr>
                    <td style="width:145px"><label for="ctl00_ContentPlaceHolder2_TxtEmailAddress">Email</label></td>
                    <td><asp:TextBox ID="TxtEmailAddress" runat="server" Width="353px" /></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td><h2 class="skiplink">Other Information</h2></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="white-space:nowrap;width:145px">
                        ALL RELEVANT DOCUMENTS SUBMITTED
                    </td>
                    <td>
                        <asp:RadioButton ID="RdbRelevantDocumentsSubmittedYes" runat="server" GroupName="Docuements" Checked="true"  />
                        <span class="radioButtonText">Yes</span>
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_RdbRelevantDocumentsSubmittedYes" class="skiplink">ALL RELEVANT DOCUMENTS SUBMITTED, Yes</label></td>
                    <td style="white-space:nowrap">
                        <asp:RadioButton ID="RdbRelevantDocumentsSubmittedNo" runat="server" GroupName="Docuements" />
                        <span class="radioButtonText">No</span>
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_RdbRelevantDocumentsSubmittedNo" class="skiplink"> ALL RELEVANT DOCUMENTS SUBMITTED, No</label></td>
                    <td>
                        Details<br />
                        <asp:TextBox ID="TxtRelevantDocumentDetails" runat="server" Width="225px"
                             messagetext="Relevant documents detail"
                             ToolTip="Details regarding document submission" />
                    </td> 
                    <td>
                       <asp:Label CssClass="labelStyle" runat="server" ID="lbWorkExpProofT" Text="Exp Proof: "></asp:Label>
                       <telerik:RadComboBox runat="server" ID="rcWep" CheckBoxes="true"></telerik:RadComboBox>

                    </td>
                </tr>
            </table>
              <table>    
                <tr>
                    <td style="height:10px">&nbsp;</td>
                </tr>
            </table>
           
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td style="width:142px">Marital Status</td>
                                <td>
                                    <asp:RadioButton ID="RdbSingle" runat="server" GroupName="MaritialStatus"/>
                                    <span class="radioButtonText">Single</span>
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_RdbSingle" class="skiplink">Maritial Status, Single</label></td>
                                <td>
                                   <asp:RadioButton ID="RdbMarried" runat="server" GroupName="MaritialStatus"/>
                                   <span class="radioButtonText">Married</span>
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_RdbMarried" class="skiplink">Maritial Status ,Married</label></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="width:142px">Bio-data submitted</td>
                                <td>
                                    <asp:CheckBox ID="ChkBiodataHardCopy" runat="server" />
                                    Hard Copy
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_ChkBiodataHardCopy" class="skiplink">Bio-data submitted, Hard copy</label></td>
                                <td>
                                   <asp:CheckBox ID="ChkBiodataSoftCopy" runat="server" />
                                   Soft Copy
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_ChkBiodataSoftCopy" class="skiplink">Bio-data submitted, Soft copy</label></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="width:142px">Joining Form signed</td>
                                <td>
                                    <asp:CheckBox ID="ChkJoiningFormSigned" runat="server" />
                                    <label for="ctl00_ContentPlaceHolder2_ChkJoiningFormSigned" class="skiplink" >Joining Form signed</label>
                                </td>
                                
                                <td>
                                    <table id="TblJoiningFormType" runat="server">
                                        <tr>
                                            <td>
                                                <label for="ctl00_ContentPlaceHolder2_TxtJoiningFormTypes">Types</label>
                                                <asp:TextBox ID="TxtJoiningFormTypes" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="width:145px"><label for="ctl00_ContentPlaceHolder2_FuUploadPhoto">Upload Photograph</label></td>
                                <td>
                                    <asp:FileUpload ID="FuUploadPhoto" runat="server" class="mandatory"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table style="margin-bottom:15px">
                            <tr>
                                <td align="center" style="border-style:double;border-width:2px;border-color:#4C77A4;width:105px;height:112px">
                                    <asp:Image ID="ImgCandidatePhoto" runat="server" AlternateText="candidate's photograph" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:218px"></td>
                    <td align="center">
                        <asp:Button ID="BtnRegister" runat="server" Text="Submit" ToolTip="Submit"
                            OnClientClick="javascript:return validRegistration();"
                            OnClick="BtnRegisterCandidate_Click" />&nbsp;&nbsp;
                            <input id="BtnShowConfirm" type="button" onclick="javascript:return CheckForDuplication();" style="display:none"/>
                        <asp:Button ID="BtnClear" runat="server" Text="Clear"  OnClick="BtnClear_Click"/>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<%--Hidden controls For address and  phone no --%>
<table style="display:none">
    <tr>
        <td>
            <span id="SpnHiddenPhoneNumber"></span>
            <span id="SpnHiddenPresentAddress"></span>
            <span id="SpanHiddenStateID"></span>
            <span id="SpnHiddenCityID"></span>
            <span id="SpnHiddenPinCode"></span>
        </td>
    </tr>
</table>
<script src="../../Scripts/jquery-1.7.1-vsdoc.js" type="text/javascript"></script>
<script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="../../Scripts/Common.js" type="text/jscript"></script>
<script src="Registration.js"  type="text/javascript"></script>   
</asp:Content>
