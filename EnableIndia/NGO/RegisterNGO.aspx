<%@ Page Title="Add NGO" Language="C#" MasterPageFile="~/NGO/NGOMaster.master" AutoEventWireup="true" Inherits="EnableIndia.NGO.RegisterNGO" Codebehind="RegisterNGO.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
    <tr>
        <td class="pageHeader">
            NGO SECTION
        </td>
    </tr>
</table>  
<table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">    
    <tr>
        <td><asp:Label CssClass="labelStyle" ID="LblTitle" runat="server" Text="Add NGO" MessageStartText="Add new" /></td>
    </tr>
</table>  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1 id="skipToTop" class="skiplink"><%= LblTitle.Text%></h1>
        </td>
    </tr>
</table>

<%--<h1 id="skipToTop" class="skiplink"><%= LblTitle.Text%></h1>--%>
    
<table cellpadding="4">
    <tr>
        <td>
            <table>
                <tr>
                    <td style="width:210px"><label for="ctl00_ContentPlaceHolder2_TxtNgoName">NGO NAME</label></td>
                    <td><asp:TextBox ID="TxtNgoName" runat="server" Width="400px" class="mandatory" messagetext="NGO name"
                          ngoName='<%#Eval("ngo_name") %>' /></td>
                </tr>
            </table>
       
            <table>
                <tr>
                    <td valign="top" style="width:210px">
                        DISABILITY TYPES AND SUB-TYPES THIS NGO DEALS IN
                    </td>
                    <td>
                        Options<br />
                         <asp:ListView ID="LstViewNGODisabilitySubTypes" runat="server" OnItemDataBound="LstViewNGODisabilitySubTypes_ItemDataBound">
                            <LayoutTemplate>
                                <table id="TblDisabilitySubTypes" class="checkedListBox mandatory" messagetext="disability sub type">
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
                                <table cellspacing="0">
                                    <tr>
                                        <td id="textField" runat="server" style="width:56px"><label id="lblDisabilitySubType" runat="server"><%#Eval("disability_type") + " - " + Eval("disability_sub_type") %></label>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkSelectDisabilitySubType" runat="server" 
                                                DisabilityID='<%#Eval("disability_id") %>'
                                                DisabilitySubTypeID='<%#Eval("disability_sub_type_id") %>'
                                                Checked='<%#Convert.ToBoolean(Eval("is_attached")) %>' />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:ListView>
                    </td>
                 </tr>
             </table>   
             
             <table>
                <tr>
                    <td style="width:210px">
                        <label for="ctl00_ContentPlaceHolder2_TxtPhoneLandlineOfOffice">PHONE/LANDLINE OF OFFICE</label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtPhoneLandlineOfOffice" runat="server" Width="400px" MaxLength="100" 
                            class="mandatory" messagetext="Office phone number" />
                    </td>
                </tr>
            </table>    
            
             <table>
                <tr>
                    <td style="width:210px" valign="top">
                        <label for="ctl00_ContentPlaceHolder2_TxtAddress">ADDRESS</label>
                    </td>
                    <td>
                        BUILDING,LANE<br />
                        <asp:TextBox ID="TxtAddress" runat="server" Width="400px" MaxLength="100" class="mandatory" messagetext="Address" />
                    </td>
                </tr>
            </table>
            
             <table cellspacing="0" cellpadding="0" style="margin-left:218px">
                <tr>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_DdlStates">STATE</label><br />
                        <select id="DdlStates" runat="server" style="width:150px" class="mandatory" type="select-one" messagetext="State"
                            onchange="javascript:FilterCityStates(this.value,'StateID','DdlCities','DdlHiddenCities');" />
                       
                        
                    </td>
                    <td style="padding-left:15px;padding-right:15px">
                        <br />
                        <%--<asp:Button ID="BtnPopulateCities" runat="server" Text="Refresh" OnClick="BtnPopulateCities_Click" />--%>
                    </td>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_DdlCities">CITY</label><br />
                        <select id="DdlCities" runat="server" style="width:150px" class="mandatory" type="select-one" messagetext="City" />
                    </td>
                    
                    <td style="width:15px"  >
                        <table style="display:none">
                            <tr>
                                <td>
                                    <label for="ctl00_ContentPlaceHolder2_DdlHiddenCities">HiddenCity</label>
                                    <select id="DdlHiddenCities" runat="server" />
                                    <span id="SpnHiddenCityID" runat="server" style="display:none" />
                                </td> 
                            </tr>
                       </table>        
                    
                    &nbsp;</td>
                    <td>
                        <asp:Label CssClass="labelStyle" runat="server" ID="lbPinCode" Text="PIN-CODE" AssociatedControlID="TxtPinCode"></asp:Label>
                        <br />
                        <asp:TextBox ID="TxtPinCode" runat="server"  TextMode="SingleLine" class="mandatory" messagetext="Pin-code" pincode="true" type="text" ValidationExpression="[\s\S]{1,10}" MaxLength="6" Columns="6"  />
                        <cc1:FilteredTextBoxExtender ID="filTxt" runat="server" TargetControlID="TxtPinCode" FilterMode="ValidChars"  FilterType="Numbers"></cc1:FilteredTextBoxExtender>

                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:210px">
                        <label for="ctl00_ContentPlaceHolder2_TxtFax">Fax</label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtFax" runat="server" Width="400px" MaxLength="100" />
                    </td>
                </tr>
            </table>
            
             <table>
                <tr>
                    <td style="width:210px">
                        <label for="ctl00_ContentPlaceHolder2_TxtWebSite">Website</label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtWebSite" runat="server" Width="400px" MaxLength="100" />
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:210px" valign="top">
                        <label for="ctl00_ContentPlaceHolder2_TxtNgoDetails">NGO Details</label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtNgoDetails" runat="server" TextMode="MultiLine" Width="400px" Height="30" MaxLength="100" />
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td>
                        <asp:LinkButton ID="LnkBtnAddMoreContacts" runat="server" Text="Add Contacts" Visible="false"
                            OnClientClick="javascript:ShowContactsPopup(-1);" 
                            OnClick="LnkBtnAddMoreContacts_Click" />
                        <span id="SpnContacts" runat="server" visible="false">Contacts</span>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                     <td>
                        <asp:ListView ID="LstViewContacts" runat="server">
                            <LayoutTemplate>
                                <table id="TblNGOContacts" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" bordercolor="#808080" border="1px">
                                    <thead class="grid-header">
                                        <tr>
                                            <th align="right">No.</th>
                                            <th>Type of Contact</th>
                                            <th>Name of contact</th>
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
                                <tr>
                                    <td id="TdRecordNumber" align="right"></td>
                                    <td><%#Eval("type_of_contact") %></td>
                                    <th>
                                        <asp:LinkButton ID="LnkBtnContactName" runat="server" CssClass="readonlyText"
                                            Text='<%#Eval("contact_name") %>' Font-Bold="false"
                                            OnClientClick='<%# "javascript:ShowContactsPopup(" +  Eval("encrypted_contact_id") + ");" %>'
                                            OnClick="LnkBtnContactName_Click" />
                                    </th>
                                    <td><%#Eval("designation") %></td>
                                    <td><%#Eval("phone_number") %></td>
                                    <td><%#Eval("email_address") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </td>
                    <td style="white-space:nowrap" valign="top">
                        <asp:Button ID="BtnAddMoreContacts" runat="server" Text="Add more contacts" Visible="false"
                            OnClientClick="javascript:ShowContactsPopup(-1);" OnClick="BtnAddMoreContacts_Click" />
                    </td>
                 </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:45px">&nbsp;</td>
                    <td align="center" style="width:570px">
                        <asp:Button ID="BtnRegisterNGO" runat="server" Text="Submit" OnClientClick="javascript:return ValidateNGORegistration();" 
                            IsSubmit="true" OnClick="BtnRegisterNGO_Click" />&nbsp;&nbsp;
                        <%--<input id="BtnClear" runat="server" type="reset" value="Clear" />--%>
                        <asp:Button ID="BtnResetNGO" runat="server" Text="Clear" 
                            onclick="BtnResetNGO_Click"  />
                        <span id="SpnStateIDForValidation" runat="server" style="display:none" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="RegisterNGO.js" type="text/javascript"></script>
</asp:Content>

