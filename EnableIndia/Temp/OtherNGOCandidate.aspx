<%@ Page Language="C#" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.Registration.OtherNGOCandidate" Title="Other NGO Candidate Registration" Codebehind="OtherNGOCandidate.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
    <tr>
        <td class="pageHeader">Candidate Section</td>
    </tr>
    <tr>
        <td>Registration > Other NGO Candidate</td>
    </tr>
 </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div>
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink">Other NGO Candidate</span></h1>
        </td>
    </tr>
</table>
<table cellpadding="4">
    <tr>
        <td>
            <table id="TblRegistrationID" runat="server" visible="false">
                <tr>
                    <td style="width:185px">Registration ID:</td>
                    <td><span id="SpnRegistrationID" runat="server" /></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:185px">
                        <asp:label runat="server" ID="lbDdlNgos" for="ctl00_ContentPlaceHolder2_DdlNgos" Text="NGO" AssociatedControlID="DdlNgos"></asp:label>
                        <asp:Label runat="server" ID="Label3" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>

                    </td>
                    <td>
                        <select id="DdlNGOs" runat="server" class="mandatory" type="select-one" messagetext="NGO" />
                      </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td style="width:185px">
                        <label for="ctl00_ContentPlaceHolder2_TxtCandidateIDNumberAtOtherNGO">Candidate's ID number at NGO:</label>
                    </td>
                    <td><asp:TextBox ID="TxtCandidateIDNumberAtOtherNGO" runat="server" /></td>
                </tr>
            </table>
            
            <table style="margin-bottom:5px">
                <tr>
                    <td valign="top" style="width:185px">
                        <label for="ctl00_ContentPlaceHolder2_TxtFileNumber">File Number</label>
                    </td>
                    <td valign="top"><asp:TextBox ID="TxtFileNumber" runat="server" /></td>
                    <td valign="top" style="padding-left:30px;width:135px">
                        <label for="ctl00_ContentPlaceHolder2_TxtRegistrationDate">REGISTRATION DATE </label>
                    </td>
                    <td>
                    <asp:TextBox ID="TxtRegistrationDate" runat="server" class="mandatory" messagetext="Registration Date"/>
                    <asp:Label runat="server" ID="Label1" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                    <br />(DD/MM/YYYY)
 
                    </td>
                </tr>
            </table>
            <table style="display:none" >
                <tr>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_TxtHiddenNumber">hidden number</label>
                        <asp:TextBox ID="TxtHiddenNumber" runat="server" Text="1" />
                    </td>
                </tr>
            </table>
            <table> 
                <tr>
                    <td valign="top" style="width:185px">NAME OF CANDIDATE</td>
                    <td >
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td  valign="middle>
                                    <label for="ctl00_ContentPlaceHolder2_TxtCandidateFirstName">First Name</label>
                                    <asp:Label runat="server" ID="Label2" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                     <br />
                                    <asp:TextBox ID="TxtCandidateFirstName" runat="server" class="mandatory" 
                                        messagetext="First name" />
 
                                </td>
                                <td valign="middle"  style="padding-left:30px;">
                                    <label for="ctl00_ContentPlaceHolder2_TxtCandidateMiddleName">Middle Name</label><br />
                                    <asp:TextBox ID="TxtCandidateMiddleName" 
                                        runat="server" />
                                </td>
                                <td style="padding-left:30px">
                                    <label for="ctl00_ContentPlaceHolder2_TxtCandidateLastName">Last Name</label>
                                     <asp:Label runat="server" ID="Label4" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TxtCandidateLastName" runat="server" 
                                        class="mandatory" messagetext="Last name"  />
 
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:185px">
                      <asp:Label runat="server" ID="lbDdlDisabilityTypes" for="ctl00_ContentPlaceHolder2_DdlDisabilityTypes" AssociatedControlID="DdlDisabilityTypes" Text="DISABILITY TYPE"></asp:Label>
                        <asp:Label runat="server" ID="Label5" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td  valign="middle">
                                    <select id="DdlDisabilityTypes" runat="server" type="select-one"
                                        class="mandatory" messagetext="Disability type" 
                                        onchange="javascript:FilterCityStates(this.value,'DisabiltyTypeID','DdlDisabilitySubTypes','DdlHiddenDisabilitySubTypes');"/>
 
                                </td>
                                <td  valign="middle" style="padding-left:30px;">
                                <asp:Label runat="server" ID="lbDdlDisabilitySubTypes" for="ctl00_ContentPlaceHolder2_DdlDisabilitySubTypes" Text="SUB TYPE" AssociatedControlID="DdlDisabilitySubTypes"></asp:Label>
                                    <asp:Label runat="server" ID="Label6" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                </td>
                                <td>
                                    <select id="DdlDisabilitySubTypes" runat="server"  class="mandatory" messagetext="Disability sub type" type="select-one"
                                        onchange="javascript:$('#TxtHiddenDisabilitySubTypes').val($('#ctl00_ContentPlaceHolder2_DdlDisabilitySubTypes').val());"  /> 
                                </td>
                                 <td>
                                    <table style="display:none" >
                                        <tr>
                                            <td  valign="middle">
                                                <label for="ctl00_ContentPlaceHolder2_DdlHiddenDisabilitySubTypes">HiddenDisablitySubTypes</label>
                                                <select id="DdlHiddenDisabilitySubTypes" runat="server"/>
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
                    <td style="width:185px">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width:100px">
                                    <label for="ctl00_ContentPlaceHolder2_TxtDateOfBirth">Date Of Birth </label>
                                     <asp:Label runat="server" ID="Label7" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>

                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtDateOfBirth" runat="server" class="mandatory" messagetext="Date of birth"/>
 
                    </td>
                    <td>(DD/MM/YYYY)</td>
                </tr>
            </table>
            
            <table type="table" class="mandatory" messagetext="gender">
                <tr>
                    <td valign="middle" style="width:185px">
                    <asp:Label runat="server" ID="lbGenderT" Text="GENDER"></asp:Label>
                    <asp:Label runat="server" ID="Label8" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                    </td>
                    <td valign="middle">
                        <asp:RadioButton ID="RdbMale" runat="server" GroupName="Gender"  />
                        <span class="radioButtonText">Male</span>
 
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_RdbMale" class="skiplink"> Gender, Male</label>
                    </td>
                    <td>
                        <asp:RadioButton ID="RdbFemale" runat="server" GroupName="Gender"  />
                        <span class="radioButtonText">Female</span>
                     </td>
                    <td><label for="ctl00_ContentPlaceHolder2_RdbFemale" class="skiplink">Gender, Female</label></td>
                    <td style="padding-left:40px"><label for="ctl00_ContentPlaceHolder2_TxtOldRegistrationNumber">Old Registration number</label></td>
                    <td><asp:TextBox ID="TxtOldRegistrationNumber" runat="server"></asp:TextBox></td>
                </tr>
            </table>
            
            <table  >
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td style="width:185px">
                                    <label for="ctl00_ContentPlaceHolder2_TxtPrimaryPhoneNumber">Phone Number (Primary)</label>
                                     <asp:Label runat="server" ID="Label14" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                </td>
                                <td>
                                    <table cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="TxtPrimaryPhoneNumber" class="mandatory" messagetext="Primary phone number" runat="server" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RdbLastREachableOnPrimaryPhoneNumber" runat="server" GroupName="PhoneNumber"
                                                    />
                                                <span class="radioButtonText">last reachable on this phone.</span>
                                            </td>
                                            <td><label for="ctl00_ContentPlaceHolder2_RdbLastREachableOnPrimaryPhoneNumber" class="skiplink">last reachable on primary phone number</label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        
                        <table>
                            <tr>
                                <td style="width:185px">
                                    <label for="ctl00_ContentPlaceHolder2_TxtSecondaryPhoneNumber">Phone number (Secondary)</label>
                                </td>
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
                    </td>
                </tr>
            </table>
            
            
            <table  >
                <tr>
                    <td>
                        
                  
            <table>
                <tr>
                    
                    <td>
                        <table cellspacing="0">
                            <tr>
                                <td style="width:185px">
                                    <table cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td style="width:132px">
                                                  Address (Present)
                                                  <asp:Label runat="server" ID="Label9" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                     Building, Lane Details<br/>
                                    <asp:TextBox ID="TxtPresentAddress" class="mandatory" messagetext="Present address" runat="server" Width="400px" />
                                     <label class="skiplink" for="ctl00_ContentPlaceHolder2_TxtPresentAddress" >PRESENT ADDRESS, Building, Lane Details</label>
                                </td>
                                <td>
                                    <asp:RadioButton ID="RdbLastReachableOnPresentAddress" runat="server" GroupName="Address" 
                                         />
                                    <span class="radioButtonText">last reachable on this address</span>
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_RdbLastReachableOnPresentAddress" class="skiplink">last reachable on present address</label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:185px"></td>
                    <td>
                        <table cellspacing="0">
                            <tr>
                                <td>
                                <asp:Label runat="server" ID="lbPreCountryT" Text="COUNTRY" for="ctl00_ContentPlaceHolder2_DdlPresentCountry"  AssociatedControlID="DdlPresentCountry"></asp:Label>
                                     <asp:Label runat="server" ID="Label10" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                     <br />
                                    <select id="DdlPresentCountry" runat="server" class="mandatory"  messagetext="Country of present address" type="select-one" enableviewstate="true"
                                       onchange="javascript:DdlCountries_OnSelectedIndexChanged(this.value,'CountryID','DdlPresentAddressStates','DdlPresentAdrressHiddenState');" />  
                                </td>
                                <td>
                                <asp:Label runat="server" ID="lbDdlPresentAddressStates" for="ctl00_ContentPlaceHolder2_DdlPresentAddressStates" Text="STATE" AssociatedControlID="DdlPresentAddressStates"></asp:Label>
                                     <asp:Label runat="server" ID="Label11" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                     <br />
    
                                    <select id="DdlPresentAddressStates" runat="server"  class="mandatory"
                                        messagetext="State of present address" type="select-one" enableviewstate="true"
                                        onchange="javascript:DdlPresentAddressStates_SelectedIndexChanged(this.value,'StateID','DdlPresentAddressCities','DdlPresentAddressHiddenCities');" />
                                </td>
                                <td style="padding-left:15px">
                                <Asp:Label runat="server"  ID="lbDdlPresentAddressCities" for="ctl00_ContentPlaceHolder2_DdlPresentAddressCities" Text="CITY" AssociatedControlID="DdlPresentAddressCities"></Asp:Label>
                                     <asp:Label runat="server" ID="Label12" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                    <br />
                                    <select id="DdlPresentAddressCities"  runat="server" type="select-one"
                                        class="mandatory" messagetext="City of present address" enableviewstate="true"
                                        onchange="javascript:$('#TxtHiddenPresentAddressCity').val($('#DdlPresentAddressCities').val());" />
                                 </td>
                                
                                 <td>
                                    <table style="display:none" >
                                        <tr>
                                            <td>
                                                <label for="ctl00_ContentPlaceHolder2_DdlPresentAdrressHiddenState">HiddenState</label>
                                                <select id="DdlPresentAdrressHiddenState" runat="server"/>
                                                <label for="ctl00_ContentPlaceHolder2_TxtHiddenPresentAddressState">hidden state</label>
                                                <asp:TextBox ID="TxtHiddenPresentAddressState" runat="server" />
                                            </td>
                                            <td>
                                                <label for="ctl00_ContentPlaceHolder2_DdlPresentAddressHiddenCities">HiddenCity</label>
                                                <select id="DdlPresentAddressHiddenCities" runat="server"/>
                                                <label for="ctl00_ContentPlaceHolder2_TxtHiddenPresentAddressCity">hidden city</label>
                                                <asp:TextBox ID="TxtHiddenPresentAddressCity" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="padding-left:15px">
                                    <label for="ctl00_ContentPlaceHolder2_TxtPresentAddressPinCode">Pin-Code</label>
                                    <asp:Label runat="server" ID="Label15" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TxtPresentAddressPinCode" class="mandatory" messagetext="Pin-Code of present address" runat="server" MaxLength="6" />
                                     <cc1:FilteredTextBoxExtender ID="filTxt" runat="server" TargetControlID="TxtPresentAddressPinCode" FilterMode="ValidChars" FilterType="Numbers"></cc1:FilteredTextBoxExtender>


                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    
                    <td>
                        <table cellspacing="0">
                            <tr>
                                <td  style="width:185px">
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td style="width:142px">
                                                     Address (Permanent)
                                                     <asp:Label runat="server" ID="Label16" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                                     <br />
<%--                                                     <asp:CheckBox runat="server" ID="rbSameAsPresent" Text="Same as Present" Font-Names="Verdana" Checked="false" />
--%>                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                
                                <td>
                                    <label >Building, Lane Details</label><br />
                                    <asp:TextBox ID="TxtPermanentAddress" runat="server" class="mandatory" messagetext="Permanent address" Width="400px" />&nbsp;
                                   <label class="skiplink" for="ctl00_ContentPlaceHolder2_TxtPermanentAddress"> 	Permanent Address, Building, Lane Details</label>
 
                                </td>
                                <td>
                                    <asp:RadioButton ID="RdbLastReachableOnPermanentAddress" runat="server" GroupName="Address" />
                                     <span class="radioButtonText">last reachable on this address</span>
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_RdbLastReachableOnPermanentAddress" class="skiplink">last reachable on permanent address</label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:185px"></td>
                    <td>
                        <table cellspacing="0">
                            <tr>
                                <td>
                                <asp:Label runat="server" ID="lbDdlPermanentCountry" for="ctl00_ContentPlaceHolder2_DdlPermanentCountry" Text="COUNTRY" AssociatedControlID="DdlPermanentCountry"></asp:Label>
                                    <asp:Label runat="server" ID="Label17" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                    <br />
                                    <select id="DdlPermanentCountry" runat="server" class="mandatory" messagetext="Country of permanent address" type="select-one"
                                        onchange="javascript:DdlCountries_OnSelectedIndexChanged(this.value,'CountryID','DdlPermanentAddressStates','DdlPermanentHiddenStates');">
                                     </select>
                               </td>
                                <td>
                                <asp:Label runat="server" ID="lbDdlPermanentAddressStates" for="ctl00_ContentPlaceHolder2_DdlPermanentAddressStates" Text="STATE" AssociatedControlID="DdlPermanentAddressStates"></asp:Label>
                                     <asp:Label runat="server" ID="Label18" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                    <br />
                                    <select id="DdlPermanentAddressStates" class="mandatory" runat="server"  messagetext="State of permanent address" type="select-one"
                                     onchange="javascript:DdlPermanentAddressStates_SelectedIndexChanged(this.value,'StateID','DdlPermanentAddressCities','DdlPermanentAddressHiddenCities');" />
                                </td>
                                <td style="padding-left:15px">
                                <asp:Label runat="server" ID="lbDdlPermanentAddressCities" for="ctl00_ContentPlaceHolder2_DdlPermanentAddressCities" Text="CITY" AssociatedControlID="DdlPermanentAddressCities"></asp:Label>
                                    <asp:Label runat="server" ID="Label19" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                   <br />
                                    <select id="DdlPermanentAddressCities" class="mandatory" runat="server" messagetext="City of permanent address" type="select-one"
                                        onchange="javascript:$('TxtPermanentHiddenAddressCity').val($('#ctl00_ContentPlaceHolder2_DdlPermanentAddressCities').val());" />
                                </td>
                                
                                 <td>
                                    <table style="display:none" >
                                        <tr>
                                            <td>
                                                <label for="ctl00_ContentPlaceHolder2_DdlPermanentHiddenStates">HiddenState</label>
                                                <select id="DdlPermanentHiddenStates" runat="server"/>
                                                <label for="ctl00_ContentPlaceHolder2_TxtPermanentHiddenAddressState">hidden state</label>
                                                <asp:TextBox ID="TxtPermanentHiddenAddressState" runat="server" />
                                            </td>
                                            <td>
                                                <label for="ctl00_ContentPlaceHolder2_DdlPermanentAddressHiddenCities">HiddenCity</label>
                                                <select id="DdlPermanentAddressHiddenCities" runat="server"/>
                                                <label for="ctl00_ContentPlaceHolder2_TxtPermanentHiddenAddressCity">hidden city</label>
                                                <asp:TextBox ID="TxtPermanentHiddenAddressCity" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                
                                <td style="padding-left:15px">
                                    <label for="ctl00_ContentPlaceHolder2_TxtPermanentAddressPinCode">Pin-Code</label>
                                    <asp:Label runat="server" ID="Label20" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TxtPermanentAddressPinCode" class="mandatory" messagetext="Pin-Code of permanent address" runat="server" MaxLength="6" />
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="TxtPermanentAddressPinCode" FilterMode="ValidChars" FilterType="Numbers"></cc1:FilteredTextBoxExtender>

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
                    <td style="width:185px">
                        <label for="ctl00_ContentPlaceHolder2_TxtEmailAddress">Email</label>
                        <br />
                    </td>
                    <td><asp:TextBox ID="TxtEmailAddress" runat="server" Width="350px" /></td>
                </tr>
            </table>
            
            <table  type="table" class="mandatory" messagetext="relevant documents submission status ">
                <tr>
                    <td style="white-space:nowrap;width:142px">
                        <label for="ctl00_ContentPlaceHolder2_TxtRelevantDocumentDetails">ALL RELEVANT DOCUMENTS SUBMITTED</label>
                        <asp:Label runat="server" ID="Label13" Text="  *" ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                    </td>
                    
                    <td style="white-space:nowrap;padding-left:41px">
                        <asp:RadioButton ID="RdbRelevantDocumentsSubmittedYes" runat="server" GroupName="Docuements" Text="" />
                        <span class="radioButtonText">Yes</span>
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_RdbRelevantDocumentsSubmittedYes" class="skiplink">ALL RELEVANT DOCUMENTS SUBMITTED, Yes</label></td>
                    <td style="white-space:nowrap">
                        <asp:RadioButton ID="RdbRelevantDocumentsSubmittedNo" runat="server" GroupName="Docuements"  />
                        <span class="radioButtonText">No</span>
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_RdbRelevantDocumentsSubmittedNo" class="skiplink">ALL RELEVANT DOCUMENTS SUBMITTED, No</label></td>
                    <td>
                        <asp:TextBox ID="TxtRelevantDocumentDetails" runat="server" Width="230px" 
                            messagetext="Relevant documents detail"
                            ToolTip="Details regarding document submission" />

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
                        <table  >
                            <tr>
                                <td style="width:180px">Marital Status</td>
                                 <td>
                                    <asp:RadioButton ID="RdbSingle" runat="server" GroupName="MaritialStatus"  />
                                    <span class="radioButtonText">Single</span>
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_RdbSingle" class="skiplink">Maritial Status ,Single</label></td>
                                <td>
                                    <asp:RadioButton ID="RdbMarried" runat="server" GroupName="MaritialStatus" />
                                    <span class="radioButtonText">Married</span>
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_RdbMarried" class="skiplink">Maritial Status ,Married</label></td>
                            </tr>
                        </table>

                        <table>
                            <tr>
                                <td style="width:182px">Bio-data submitted</td>
                                <td>
                                    Hard Copy
                                    <asp:CheckBox ID="ChkBiodataHardCopy" runat="server"/>
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_ChkBiodataHardCopy" class="skiplink">Bio-data submitted, Hard copy</label></td>
                                <td style="vertical-align:super">
                                    Soft Copy
                                    <asp:CheckBox ID="ChkBiodataSoftCopy" runat="server" GroupName="BioDataSubmission" />
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_ChkBiodataSoftCopy" class="skiplink">Bio-data submitted, Soft copy</label></td>
                            </tr>
                        </table>

                        <table>
                            <tr>
                                <td style="width:180px">Joining Form signed </td>
                                <td><asp:CheckBox ID="ChkJoiningFormSigned" runat="server" /></td>
                                <td><label for="ctl00_ContentPlaceHolder2_ChkJoiningFormSigned" class="skiplink">Joining Form signed</label></td>
                            </tr>
                        </table>

                        <table>    
                            <tr>
                                <td style="width:183px">
                                   <asp:Label runat="server" ID="lbFileUpload"  for="ctl00_ContentPlaceHolder2_FuUploadPhoto" Text="Upload Photograph" AssociatedControlID="FuUploadPhoto"></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FuUploadPhoto" runat="server" class="mandatory" ClientIDMode="Static" onChange="javascript:return fupClicked(this);" EnableViewState="true" />
                                </td>
                            </tr>
                        </table>
                        
                    </td>
                    <td>
                        <table style="margin-bottom:15px">
                            <tr>
                                <td  align="center" style="border-style:double;border-width:2px;border-color:#4C77A4;">
                                      <div style="display:table;">
                                        <div style="display:table-row;">
                                           <div style="display:table-cell; width:106px; height:113px; vertical-align:middle;">
                                                 <asp:Image ID="ImgCandidatePhoto" runat="server" AlternateText="candidate-photo" onChange="javascript:return fupClicked(this);" Height="105px" Width="112px" ClientIDMode="Static" />
                                           </div>
                                           <div id="lbWrap" style="display:table-cell; width:120px;">
                                                 <asp:Literal runat="server" ID="lbFileUploaded"></asp:Literal>
                                           </div>
                                        </div>
                                      </div>
                                      <asp:Button ID="btnPreviewImage" runat="server" Style="display: none;" OnClick="btnPreviewImage_Click" /> 
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td valign="middle" align="left">
                                </td>
                            </tr>
                        </table>
                    </td>
                    
                </tr>
            </table>
            <table>
                <tr>
                    <td align="center" style="width:570px">
                        <asp:Button ID="BtnRegisterCandidate" runat="server" Text="Register" OnClientClick="javascript:return validRegistration();"
                            OnClick="BtnRegisterCandidate_Click" />&nbsp;&nbsp;
                         <input id="BtnShowConfirm" type="button" onclick="javascript:return CheckForDuplication();" style="display:none" />
                        <asp:Button ID="BtnClear" runat="server" Text="Clear" OnClick="BtnClear_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</div>
<div runat="server" id="fup">
  <script type="text/javascript" language="javascript">
      function fupClicked(fup) {
          document.getElementById('btnPreviewImage').click();
      }
  </script>
</div>
     <script src='<%= ResolveClientUrl("~")%>Scripts/jquery-1.7.1.min.js' type="text/javascript" ></script>
     <script src="../../Scripts/Common.js" type="text/javascript"></script>
    <script src="OtherNgoCandidate.js" type="text/javascript"></script>
</asp:Content>
