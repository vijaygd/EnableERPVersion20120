<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.Registration.EnableIndiaCandidate" Title="Enable India Candidate Registration" Codebehind="EnableIndiaCandidate.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table cellpadding="0" cellspacing="0">
    <tr>
        <td colspan="2" class="pageHeader">Candidate Section</td>
    </tr>
    <tr>
        <td>
              Registration > Enable India Candidate
        </td>
    </tr>
</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink" style="color:White">Enable India Candidate</span></h1>
        </td>
    </tr>
</table>
<div>
            <table id="TblRegistrationID" runat="server" visible="false">
                <tr>
                    <td style="width:170px">Registration ID</td>
                    <td><span id="SpnregistrationID" runat="server" /></td>
                </tr>
            </table>
            <table style="margin-bottom:5px">
                <tr>
                    <td valign="middle" style="width:170px">
                        <asp:Label CssClass="labelStyle" runat="server" ID="lbFileNumber"  Text="File Number" AssociatedControlID="TxtFileNumber" for="ctl00_ContentPlaceHolder2_TxtFileNumber"></asp:Label>
                    </td>
                    <td valign="middle"><asp:TextBox ID="TxtFileNumber" runat="server" /></td>
                    <td valign="middle" style="padding-left:30px;width:150px">
                        <asp:Label CssClass="labelStyle" runat="server" ID="Label3" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                        <asp:Label CssClass="labelStyle" runat="server" ID="ctl00_ContentPlaceHolder2_TxtRegistrationDate" Text="REGISTRATION DATE" AssociatedControlID="TxtRegistrationDate"></asp:Label>
                    </td>
                    <td>
                    <asp:TextBox ID="TxtRegistrationDate" runat="server" class="mandatory" messagetext="Registration date" date="true" yearlength="4"/>
                    <asp:ImageButton runat="server" ID="ImageButton1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" />
                    <cc1:CalendarExtender runat="server" ID="CalendarExtender2" PopupButtonID="ImageButton1" TargetControlID="TxtRegistrationDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                    <asp:RegularExpressionValidator ID="revDateOfBirth" ControlToValidate="TxtRegistrationDate"
                        ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                        runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" /><br />(DD/MM/YYYY) 

 
 <%--                   
                    <asp:TextBox ID="TxtRegistrationDate" runat="server" class="mandatory" messagetext="Registration date" date="true" yearlength="4"/>
                    <asp:Image runat="server" ID="imgtxtregdate" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" />
                     <asp:Label CssClass="labelStyle" runat="server" ID="Label3" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                     <br />

                            (DD/MM/YYYY)
                        <cc1:MaskedEditValidator runat="server" ID="txtRegDatev" ControlExtender="txtRegDatee" ControlToValidate="TxtRegistrationDate" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender runat="server" ID="txtRegDatee" TargetControlID="TxtRegistrationDate" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
                        <cc1:CalendarExtender runat="server" ID="cetxtregdate" PopupButtonID="imgtxtregdate" TargetControlID="TxtRegistrationDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
--%>                   </td>
                </tr>
            </table>
            <table style="display:none">
            <%-- hidden number for checking duplicaion--%>
                <tr>
                    <td valign="middle">
                        <label for="ctl00_ContentPlaceHolder2_TxtHiddenNumber">hidden number</label>
                        <asp:TextBox ID="TxtHiddenNumber" runat="server" Text="1" />
                    </td>
                </tr>
            </table>
            <table> 
                <tr>
                    <td valign="middle" style="width:170px">
                     <asp:Label runat="server" ID="lbNameofcand" Text="NAME OF CANDIDATE" CssClass="labelStyle"></asp:Label></td>
                    <td valign="middle">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="middle">
                                    <asp:Label CssClass="labelStyle" runat="server" ID="m1" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12" ></asp:Label>
                                    <asp:Label CssClass="labelStyle" runat="server" ID="ctl00_ContentPlaceHolder2_TxtCandidateFirstName" Text="First Name" AssociatedControlID="TxtCandidateFirstName"></asp:Label>
                                    <br />
                                   <asp:TextBox ID="TxtCandidateFirstName" runat="server" class="mandatory" messagetext="First name"
                                         datatype="string" />
                                </td>
                                <td valign="middle" style="padding-left:30px">
                                    <asp:Label CssClass="labelStyle" runat="server" ID="ctl00_ContentPlaceHolder2_TxtCandidateMiddleName" Text="Middle" AssociatedControlID="TxtCandidateMiddleName"></asp:Label>
                                    <asp:Label CssClass="labelStyle" runat="server" ID="Label19" Text="&nbsp;"  Font-Bold="true" Font-Size="12" ></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TxtCandidateMiddleName" runat="server" datatype="string" />
                                </td>
                                <td valign="middle" style="padding-left:30px">
                                    <asp:Label CssClass="labelStyle" runat="server" ID="Label1" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                    <asp:Label CssClass="labelStyle" runat="server" ID="ctl00_ContentPlaceHolder2_TxtCandidateLastName" Text="Last Name" AssociatedControlID="TxtCandidateLastName"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TxtCandidateLastName" runat="server" class="mandatory" messagetext="Last name"
                                        datatype="string" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td valign="middle" style="width:170px">
                        <asp:Label CssClass="labelStyle" runat="server" ID="Label15" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                       <asp:Label CssClass="labelStyle" runat="server" ID="lbDdlDisabilityTypes" for="ctl00_ContentPlaceHolder2_DdlDisabilityTypes" AssociatedControlID="DdlDisabilityTypes" Text="DISABILITY TYPE"></asp:Label>
                     </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="middle">
                                    <select id="DdlDisabilityTypes" runat="server" class="mandatory" messagetext="Disability type" type="select-one"
                                   onchange="javascript:FilterCityStates(this.value,'DisabiltyTypeID','DdlDisabilitySubTypes','DdlHiddenDisabilitySubTypes');"/>

 
                                </td>
 
                               <td valign="middle" style="padding-left:50px;width:80px">
                                    <asp:Label CssClass="labelStyle" runat="server" ID="Label16" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                    <asp:Label CssClass="labelStyle" runat="server" ID="lbDdlDisabilitySubTypes" for="ctl00_ContentPlaceHolder2_DdlDisabilitySubTypes" Text="SUB TYPE" AssociatedControlID="DdlDisabilitySubTypes"></asp:Label>
                                </td>
                                <td valign="middle">
                                    <select id="DdlDisabilitySubTypes" runat="server" class="mandatory" messagetext="Disability sub type"  type="select-one"
                                         onchange="javascript:$('#TxtHiddenDisabilitySubTypes').val($('#DdlDisabilitySubTypes').val());" />
                                </td>
                                <td valign="middle">
                                    <table style="display:none">
                                        <tr>
                                            <td valign="middle">
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
                    <td style="width:170px">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="middle" style="width:120px">
                                <asp:Label CssClass="labelStyle" runat="server" ID="Label2" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                <asp:Label CssClass="labelStyle" runat="server" id="ctl00_ContentPlaceHolder2_TxtDateOfBirth" Text="DATE OF BIRTH" AssociatedControlID="TxtDateOfBirth"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="middle">
                        <asp:TextBox ID="TxtDateOfBirth" runat="server" class="mandatory" messagetext="Date of birth" date="true" yearlength="4"/>&nbsp;
                        <asp:ImageButton runat="server" ID="Image1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" />
                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="Image1" TargetControlID="TxtDateOfBirth" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtDateOfBirth"
                        ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                        runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                    </td>
                    <td valign="middle">
                        (DD/MM/YYYY) 
                    </td>
                </tr>
            </table>
            
            <table type="table"  class="mandatory" messagetext="gender">
               <tr>
                   <td style="width:170px">
                    <asp:Label runat="server" ID="Label18" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                    <asp:Label runat="server" ID="lbGenderT" Text="GENDER" CssClass="labelStyle"></asp:Label>
                   </td>
                    <td style="width:200px">
                        <asp:RadioButton ID="RdbMale" runat="server" GroupName="Gender" />
                        <span class="radioButtonText">Male</span>
                    </td>
                    <td>
                       <label for="ctl00_ContentPlaceHolder2_RdbMale" class="skiplink">Gender, Male</label>&nbsp;
                         <asp:RadioButton ID="RdbFemale" runat="server" GroupName="Gender"  />
                        <span class="radioButtonText">Female</span>
                        <label for="ctl00_ContentPlaceHolder2_RdbFemale" class="skiplink">Gender, Female</label>
                        <Asp:Label id="ctl00_ContentPlaceHolder2_RdbFemale" runat="server" class="skiplink" Text="Gender, Female"></Asp:Label>
                  </td>
               </tr>
   
                <tr>
                    <td  valign="middle">
                       <asp:Label CssClass="labelStyle" runat="server" ID="lbOldRegistrationNumber" for="ctl00_ContentPlaceHolder2_TxtOldRegistrationNumber" Text="Old Registration Number" AssociatedControlID="TxtOldRegistrationNumber"></asp:Label>
                    </td>
                    <td colspan="2" valign="middle"><asp:TextBox ID="TxtOldRegistrationNumber" runat="server"></asp:TextBox></td>
                </tr>
            </table>
            
            <table type="table" >
                <tr>
                    <td>
                    
            <table>
                <tr>
                    <td valign="middle" style="width:180px">
                         <asp:Label CssClass="labelStyle" runat="server" ID="Label4" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                        <label for="ctl00_ContentPlaceHolder2_TxtPrimaryPhoneNumber">PHONE NUMBER (PRIMARY)</label>
                   </td>
                    <td>
                        <table cellspacing="0">
                            <tr>
                                <td valign="middle">
                                    <asp:TextBox ID="TxtPrimaryPhoneNumber" runat="server" 
                                        class="mandatory" messagetext="Primary phone number" phonenumber="true" />
  
                                </td>
                                <td valign="middle">
                                    <asp:RadioButton ID="RdbLastREachableOnPrimaryPhoneNumber" runat="server" GroupName="PhoneNumber"
                                        />
                                    <span class="radioButtonText" style="font-weight:bold;" >last reachable on this phone.</span>
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_RdbLastREachableOnPrimaryPhoneNumber" class="skiplink">last reachable on primary phone number</label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td valign="middle" style="width:180px">
                        <label for="ctl00_ContentPlaceHolder2_TxtSecondaryPhoneNumber">Phone number (Secondary)</label>
                    </td>
                    <td>
                        <table cellspacing="0">
                            <tr>
                                <td valign="middle">
                                    <asp:TextBox ID="TxtSecondaryPhoneNumber" runat="server" />
                                </td>
                                <td valign="middle">
                                    <asp:RadioButton ID="RdbLastReachableOnSecondaryPhoneNumber" runat="server" GroupName="PhoneNumber" />
                                    <span class="radioButtonText"  style="font-weight:bold;">last reachable on this phone.</span>
                                </td>
                                <td valign="middle">
                                <label for="ctl00_ContentPlaceHolder2_RdbLastReachableOnSecondaryPhoneNumber" class="skiplink">last reachable on secondary phone number</label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
                    </td>
                </tr>
            </table>
            
            <table type="table">
                <tr>
                    <td>
                    
            <table>
                <tr>
                    
                    <td>
                        <table cellspacing="0">
                            <tr>
                                <td valign="middle" style="width:170px">
                                    <asp:Label CssClass="labelStyle" runat="server" ID="Label5" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                   <asp:Label CssClass="labelStyle" runat="server" ID="lbPerAddT" Text="ADDRESS (PRESENT)" AssociatedControlID="TxtPresentAddress"></asp:Label>

                               </td>
                                <td valign="middle">
                                    Building, Lane Details<br />
                                    <asp:TextBox ID="TxtPresentAddress" runat="server" Width="400px"
                                         class="mandatory" messagetext="Present address" />
                                 </td>
                                <td valign="middle">
                                    <label class="skiplink" for="ctl00_ContentPlaceHolder2_TxtPresentAddress">PRESENT ADDRESS, Building, Lane Details</label>
                                </td>
                                <td valign="middle">
                                    <asp:RadioButton ID="RdbLastReachableOnPresentAddress" runat="server" GroupName="Address"  />
                                    <span class="radioButtonText"  style="font-weight:bold;">last reachable on this address</span>
                                </td>
                                <td valign="middle"><label for="ctl00_ContentPlaceHolder2_RdbLastReachableOnPresentAddress" class="skiplink">last reachable on present address</label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width:170px"></td>
                    <td>
                        <table cellspacing="0">
                            <tr>
                                <td valign="middle">
                                     <asp:Label CssClass="labelStyle" runat="server" ID="Label6" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                    <asp:Label CssClass="labelStyle" runat="server" ID="lbPreCountryT" Text="COUNTRY" for="ctl00_ContentPlaceHolder2_DdlPresentCountry"  AssociatedControlID="DdlPresentCountry"></asp:Label>
                                     <br />
                                    <select id="DdlPresentCountry" runat="server" class="mandatory" enableviewstate="true"
                                        messagetext="Country of present address" type="select-one"
                                       onchange="javascript:DdlCountries_OnSelectedIndexChanged(this.value,'CountryID','DdlPresentAddressStates','DdlPresentAdrressHiddenState');"  
                                    ></select>
 <%--                                       onchange="javascript:FilterCityStates(this.value,'DisabiltyTypeID','DdlDisabilitySubTypes','DdlHiddenDisabilitySubTypes');"/>
 --%>
                               </td>
                                <td valign="middle">
                                    <asp:Label CssClass="labelStyle" runat="server" ID="Label7" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                    <asp:Label CssClass="labelStyle" runat="server" ID="lbDdlPresentAddressStates" for="ctl00_ContentPlaceHolder2_DdlPresentAddressStates" Text="STATE" AssociatedControlID="DdlPresentAddressStates"></asp:Label>
                                    <br />
                                    <select id="DdlPresentAddressStates" runat="server"  class="mandatory" enableviewstate="true"
                                        messagetext="State of present address" type="select-one"
                                        onchange="javascript:DdlPresentAddressStates_SelectedIndexChanged(this.value,'StateID','DdlPresentAddressCities','DdlPresentAddressHiddenCities');" />

                     
                                    <%--<asp:Button ID="BtnPopulatePresentAddressCities" runat="server" Text="Refresh Cities" IsRefresh="true"
                                        ToolTip="Refresh present address cities" OnClick="BtnPopulatePresentAddressCities_Click" />--%>
                                </td>
                               
                                <td valign="middle" style="padding-left:15px">
                                    <asp:Label CssClass="labelStyle" runat="server" ID="Label8" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                    <asp:Label CssClass="labelStyle" runat="server"  ID="lbDdlPresentAddressCities" for="ctl00_ContentPlaceHolder2_DdlPresentAddressCities" Text="CITY" AssociatedControlID="DdlPresentAddressCities"></Asp:Label>
                                       <br />
                                    <select id="DdlPresentAddressCities" runat="server" class="mandatory" type="select-one" 
                                        messagetext="City of present address"
                                        onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHiddenPresentAddressCity').val($('#ctl00_ContentPlaceHolder2_DdlPresentAddressCities').val());" />
                                </td>
                                
                                <td>
                                    <table style="display:none" >
                                        <tr>
                                            <td valign="middle">
                                                <label for="ctl00_ContentPlaceHolder2_DdlPresentAdrressHiddenState">HiddenState</label>
                                                <select id="DdlPresentAdrressHiddenState" runat="server"/>
                                                <label for="ctl00_ContentPlaceHolder2_TxtHiddenPresentAddressState">hidden state</label>
                                                <asp:TextBox ID="TxtHiddenPresentAddressState" runat="server" />
                                            </td>
                                            <td valign="middle">
                                                <label for="ctl00_ContentPlaceHolder2_DdlPresentAddressHiddenCities">HiddenCity</label>
                                                <select id="DdlPresentAddressHiddenCities" runat="server"/>
                                                <label for="ctl00_ContentPlaceHolder2_TxtHiddenPresentAddressCity">hidden city</label>
                                                <asp:TextBox ID="TxtHiddenPresentAddressCity" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                
                                <td valign="middle" style="padding-left:15px">
                                    <asp:Label CssClass="labelStyle" runat="server" ID="Label9" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                    <asp:Label CssClass="labelStyle" runat="server" ID="ctl00_ContentPlaceHolder2_TxtPresentAddressPinCode" Text="PIN-CODE" AssociatedControlID="TxtPresentAddressPinCode"></Asp:Label>
                                    <br />
                                    <asp:TextBox ID="TxtPresentAddressPinCode" runat="server" class="mandatory" messagetext="Pin-Code of present address"  pincode="true" MaxLength="6"/>
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
                             <td valign="middle" style="width:170px">
                              <asp:Label CssClass="labelStyle" runat="server" ID="Label11" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                              <asp:Label CssClass="labelStyle" runat="server" ID="lbPerAddress" Text="ADDRESS (PERMANENT)" AssociatedControlID="TxtPermanentAddress"></asp:Label>
                                      <%--<asp:CheckBox runat="server" ID="rbSameAsPresent" Text="Same as Present"  OnCheckedChanged="rbsapClicked"  AutoPostBack="true" Font-Names="Verdana" />--%>
                              </td>
                                <td valign="middle">
                                     Building, Lane Details<br />
                                    <asp:TextBox ID="TxtPermanentAddress" runat="server" Width="400px" class="mandatory" messagetext="Permanent address"  />&nbsp;

                                </td>
                                <td valign="middle">
                                    <label class="skiplink" for="ctl00_ContentPlaceHolder2_TxtPermanentAddress" > 	Permanent Address, Building, Lane Details</label>
                                </td>
                                   
                                <td valign="middle">
                                    <asp:RadioButton ID="RdbLastReachableOnPermanentAddress" runat="server" GroupName="Address" />
                                     <span class="radioButtonText"  style="font-weight:bold;">last reachable on this address</span>
                                </td>
                                <td valign="middle"><label for="ctl00_ContentPlaceHolder2_RdbLastReachableOnPermanentAddress" class="skiplink">last reachable on permanent address</label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:170px"></td>
                    <td>
                        <table cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Label CssClass="labelStyle" runat="server" ID="Label12" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                    <asp:Label CssClass="labelStyle" runat="server" ID="lbDdlPermanentCountry" for="ctl00_ContentPlaceHolder2_DdlPermanentCountry" Text="COUNTRY" AssociatedControlID="DdlPermanentCountry"></asp:Label>
                                    <br />
                                    <select id="DdlPermanentCountry" runat="server" type="select-one"
                                        class="mandatory" messagetext="Country of permanent address"
                                        onchange="javascript:DdlCountries_OnSelectedIndexChanged(this.value,'CountryID','DdlPermanentAddressStates','DdlPermanentHiddenStates');"
                                        >
                                    </select>
                                </td>
                                <td valign="middle">
                                    <asp:Label CssClass="labelStyle" runat="server" ID="Label13" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                    <asp:Label CssClass="labelStyle" runat="server" ID="lbDdlPermanentAddressStates" for="ctl00_ContentPlaceHolder2_DdlPermanentAddressStates" Text="STATE" AssociatedControlID="DdlPermanentAddressStates"></asp:Label>
                                    <br />
                                    <select id="DdlPermanentAddressStates" runat="server" type="select-one"
                                        class="mandatory" messagetext="State of permanent address"
                                        onchange="javascript:DdlPermanentAddressStates_SelectedIndexChanged(this.value,'StateID','DdlPermanentAddressCities','DdlPermanentAddressHiddenCities');" />

                                    <%--<asp:Button ID="BtnPopulatePermanentAddressCities" runat="server" Text="Refresh Cities" IsRefresh="true"
                                        ToolTip="Refresh permanent address cities" OnClick="BtnPopulatePermanentAddressCities_Click" />--%>
                                </td>
                                <td valign="middle" style="padding-left:15px">
                                   <asp:Label CssClass="labelStyle" runat="server" ID="Label14" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                   <asp:Label CssClass="labelStyle" runat="server" ID="lbDdlPermanentAddressCities" for="ctl00_ContentPlaceHolder2_DdlPermanentAddressCities" Text="CITY" AssociatedControlID="DdlPermanentAddressCities"></asp:Label>
                                     <br />
                                    <select id="DdlPermanentAddressCities" runat="server" type="select-one"
                                        class="mandatory" messagetext="City of permanent address"
                                        onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtPermanentHiddenAddressCity').val($('#ctl00_ContentPlaceHolder2_DdlPermanentAddressCities').val());" />


                                </td>
                                <td>
                                    <table style="display:none" >
                                        <tr>
                                            <td valign="middle">
                                                <label for="ctl00_ContentPlaceHolder2_DdlPermanentHiddenStates">HiddenState</label>
                                                <select id="DdlPermanentHiddenStates" runat="server"/>
                                                <label for="ctl00_ContentPlaceHolder2_TxtPermanentHiddenAddressState">hidden state</label>
                                                <asp:TextBox ID="TxtPermanentHiddenAddressState" runat="server" />
                                            </td>
                                            <td valign="middle">
                                                <label for="ctl00_ContentPlaceHolder2_DdlPermanentAddressHiddenCities">HiddenCity</label>
                                                <select id="DdlPermanentAddressHiddenCities" runat="server"/>
                                                <label for="ctl00_ContentPlaceHolder2_TxtPermanentHiddenAddressCity">hidden city</label>
                                                <asp:TextBox ID="TxtPermanentHiddenAddressCity" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                
                                <td valign="middle" style="padding-left:15px">
                                    <asp:Label CssClass="labelStyle" runat="server" ID="Label10" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                                    <asp:Label CssClass="labelStyle" runat="server" ID="ctl00_ContentPlaceHolder2_TxtPermanentAddressPinCode" Text="PIN-CODE" AssociatedControlID="TxtPermanentAddressPinCode"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TxtPermanentAddressPinCode" runat="server" 
                                         class="mandatory" messagetext="Pin-Code of permanent address"
                                         pincode="true" MaxLength="6"
                                        />
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
                    <td style="width:170px">
                        <label for="ctl00_ContentPlaceHolder2_TxtEmailAddress">Email</label>
                        <br />
                    </td>
                    <td><asp:TextBox ID="TxtEmailAddress" runat="server" Width="355px" /></td>
                </tr>
            </table>
            
           
            <table type="table" class="mandatory" messagetext="relevant documents submission status " >
                <tr>
                    <td valign="middle" style="white-space:nowrap;width:170px">
                        <asp:Label CssClass="labelStyle" runat="server" ID="Label17" Text="* " ForeColor="#D32232" Font-Bold="true" Font-Size="12"></asp:Label>
                        <asp:Label CssClass="labelStyle" runat="server" ID="ctl00_ContentPlaceHolder2_TxtRelevantDocumentDetails" Text="RELEVANT DOCUMENTS SUBMITTED" AssociatedControlID="RdbRelevantDocumentsSubmittedYes"></asp:Label>
                    </td>
                    <td valign="middle" style="white-space:nowrap">
                        <asp:RadioButton ID="RdbRelevantDocumentsSubmittedYes" runat="server" GroupName="Docuements" Text=""  />
                        <span class="radioButtonText">Yes</span>

                    </td>
                    <td valign="middle"><label for="ctl00_ContentPlaceHolder2_RdbRelevantDocumentsSubmittedYes" class="skiplink">ALL RELEVANT DOCUMENTS SUBMITTED, Yes</label></td>
                    <td valign="middle" style="white-space:nowrap">
                        <asp:RadioButton ID="RdbRelevantDocumentsSubmittedNo" runat="server" GroupName="Docuements" 
                            />
                        <span class="radioButtonText">No</span>
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_RdbRelevantDocumentsSubmittedNo" class="skiplink">ALL RELEVANT DOCUMENTS SUBMITTED, No</label></td>
                    <td valign="middle">
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
                        <table type="table">
                            <tr>
                                <td style="width:142px">
                                 <asp:Label runat="server" ID="lbMst" Text="Marital Status" CssClass="labelStyle"></asp:Label></td>
                                 <td valign="middle">
                                    <asp:RadioButton ID="RdbSingle" runat="server" GroupName="MaritialStatus" />
                                    <span class="radioButtonText">Single</span>
                                </td>
                                <td><label for="ctl00_ContentPlaceHolder2_RdbSingle" class="skiplink">
                                    <asp:Label runat="server" ID="lbMst1" Text="Maritial Status, Single"></asp:Label></label></td>
                                <td valign="middle">
                                    <asp:RadioButton ID="RdbMarried" runat="server" GroupName="MaritialStatus" />
                                    <span class="radioButtonText">Married</span>
                                </td>
                                <td valign="middle"><label for="ctl00_ContentPlaceHolder2_RdbMarried" class="skiplink">Maritial Status, Married</label></td>
                            </tr>
                        </table>

                        <table>
                            <tr>
                                <td valign="middle" style="width:142px">
                                  <asp:Label runat="server" ID="lbMst2" Text="Bio-data submitted" CssClass="labelStyle"></asp:Label></td>
                                <td valign="middle">
                                  <asp:Label runat="server" ID="lbhc" Text="Hard Copy" CssClass="labelStyle"></asp:Label>
                                    <asp:CheckBox ID="ChkBiodataHardCopy" runat="server" GroupName="BioDataSubmission" />
                                </td>
                                <td valign="middle"><label for="ctl00_ContentPlaceHolder2_ChkBiodataHardCopy" class="skiplink">Bio-data submitted, Hard copy</label></td>
                                <td valign="middle" style="vertical-align:super">
                                  <asp:Label runat="server" ID="lbMst3" Text="Soft Copy" CssClass="labelStyle"></asp:Label>
                                    <asp:CheckBox ID="ChkBiodataSoftCopy" runat="server" GroupName="BioDataSubmission" />
                                </td>
                                <td valign="middle"><label for="ctl00_ContentPlaceHolder2_ChkBiodataSoftCopy" class="skiplink">Bio-data submitted, Soft copy</label></td>
                            </tr>
                        </table>

                        <table>
                            <tr>
                                <td style="width:142px"><asp:Label runat="server" ID="lbJfs" Text="Joining Form signed" CssClass="labelStyle"></asp:Label> </td>
                                <td valign="middle"><asp:CheckBox ID="ChkJoiningFormSigned" runat="server" /></td>
                                <td valign="middle"><label for="ctl00_ContentPlaceHolder2_ChkJoiningFormSigned" class="skiplink">Joining Form signed</label></td>
                                <td valign="middle"><label for="ctl00_ContentPlaceHolder2_TxtJoiningFormTypes">Types</label></td>
                                <td valign="middle"><asp:TextBox ID="TxtJoiningFormTypes" runat="server" /></td>
                            </tr>
                        </table>

                        <table>    
                            <tr>
                                <td valign="middle" style="width:170px">
                                    <asp:Label CssClass="labelStyle" runat="server" ID="lbFileUpload"  for="ctl00_ContentPlaceHolder2_FuUploadPhoto" Text="Upload Photograph" AssociatedControlID="FuUploadPhoto"></asp:Label>
                                </td>
                                <td valign="middle">
                                    <asp:FileUpload ID="FuUploadPhoto" runat="server"  class="mandatory" />
                                </td>
                            </tr>
                        </table>
                   </td>
                   
                    <td>
                    <table style="margin-bottom:15px" >
                        <tr>
                            <td align="center" valign="middle" style="border-style:double;border-width:2px;border-color:#4C77A4;width:105px;height:112px">
                                &nbsp;
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
                    <td valign="middle" align="center" style="width:570px">
                       
                        <asp:Button ID="BtnRegisterCandidate" runat="server" Text="Register" OnClientClick="javascript:return validRegistration();"
                            OnClick="BtnRegisterCandidate_Click" />&nbsp;&nbsp;
                        <input id="BtnShowConfirm" type="button" onclick="javascript:return CheckForDuplication();" style="display:none" />
                        <asp:Button ID="BtnClear" runat="server" Text="Clear" OnClick="BtnClear_Click"/>  
                    </td>
                </tr>
            </table>
</div>
   <script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
   <script src="../../Scripts/Common.js" type="text/javascript"></script>
   <script src="EnableIndiaCandidate.js" type="text/javascript"></script>
</asp:Content>
