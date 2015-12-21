<%@ Page Title="'To be Profiled' Candidates" ValidateRequest="false" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.ProfileHistory.ToBeProfiledCandidates" Codebehind="ToBeProfiledCandidates.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td class="pageHeader">Candidate Section</td>
    </tr>
</table>    
<table cellpadding="0" cellspacing="0">    
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">
                <tr>
                    <td>Profile and History > To be Profiled Candidates</td>
                </tr>
            </table>
        </td>
    </tr>
</table>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="../../Scripts/jquery.cookie.pack.js" type="text/javascript"></script>
<script src="../../Scripts/Common.js" type="text/jscript"></script>
<script src="../../Scripts/jquery.pager.js" type="text/jscript"></script>
<script src="ToBeProfiledCandidates.js" type="text/javascript"></script>

<table cellpadding="4" cellspacing="2">
    <tr>
        <td>
            <table group="SearchParameters" cellspacing="2">
                <tr>
                    <td style="width:110px"><label for="ctl00_ContentPlaceHolder2_TxtSearchFor">Search for</label></td>
                    <td><asp:TextBox ID="TxtSearchFor" runat="server" /></td>
                    <td style="padding-left:30px"><label for="ctl00_ContentPlaceHolder2_DdlSearchIn">in</label></td>
                    <td style="padding-left:5px">
                        <select id="DdlSearchIn" runat="server" title="Search In">
                            <option value="name">Name</option>
                            <option value="registration_id">RID</option>
                            <option value="ngo">NGO</option>
                        </select>
                    </td>
                </tr>
            </table>
            
            <table group="SearchParameters" >
                <tr>
                    <td style="width:110px"><label for="ctl00_ContentPlaceHolder2_DdlDisabilityType">Disability</label></td>
                    <td>
                        <select id="DdlDisabilityType" runat="server" />
                    </td>
                </tr>
            </table>
            
            <table group="SearchParameters" cellspacing="2">
                <tr>
                    <td style="width:110px"><label for="ctl00_ContentPlaceHolder2_DdlCities">City</label></td>
                    <td>
                        <select id="DdlCities" runat="server" />
                    </td>
                </tr>
            </table>
            
            <table group="SearchParameters">
                <tr>
                    <td valign="top" style="width:110px">
                        <label for="ctl00_ContentPlaceHolder2_TxtRegistrationDateFrom">Registration Date</label>
                    </td>
                    <td>
                       <asp:TextBox ID="TxtRegistrationDateFrom" runat="server" yearlength="4"/>
                        <asp:ImageButton runat="server" ID="Image1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="Image1" TargetControlID="TxtRegistrationDateFrom" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtRegistrationDateFrom"
                        ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                        runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                        <br />(dd/mm/yyyy)
<%--                         <cc1:MaskedEditValidator runat="server" ID="txtRegDatev" ControlExtender="txtRegDatee" ControlToValidate="TxtRegistrationDateFrom" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender runat="server" ID="txtRegDatee" TargetControlID="TxtRegistrationDateFrom" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>
                    </td>
                    <td style="padding-left:30px;" valign="top">
                        <label for="ctl00_ContentPlaceHolder2_TxtRegistrationDateTo">To </label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtRegistrationDateTo" runat="server" yearlength="4" />
                        <asp:ImageButton runat="server" ID="Image2" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                        <cc1:CalendarExtender runat="server" ID="CalendarExtender2" PopupButtonID="Image2" TargetControlID="TxtRegistrationDateTo" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtRegistrationDateTo"
                        ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                        runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                        <br />
                       (dd/mm/yyyy)
<%--                        <cc1:MaskedEditValidator runat="server" ID="tbRegDtv" ControlExtender="tbRegDte" ControlToValidate="TxtRegistrationDateTo" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender runat="server" ID="tbRegDte" TargetControlID="TxtRegistrationDateTo" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:110px"><label for="ctl00_ContentPlaceHolder2_TxtOldRegistrationNumber">Old Registration Number</label></td>
                    <td>
                        <asp:TextBox ID="TxtOldRegistrationNumber" runat="server" />
                    </td>
                </tr>
            </table>
            
            <table group="SearchParameters" >
                <tr>
                    <td style="width:110px"><label for="ctl00_ContentPlaceHolder2_TxtDateOfBirth">Date Of Birth</label></td>
                    <td>
                        <asp:TextBox ID="TxtDateOfBirth" runat="server" />
                        <asp:ImageButton runat="server" ID="Image3" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                        <cc1:CalendarExtender runat="server" ID="CalendarExtender3" PopupButtonID="Image3" TargetControlID="TxtDateOfBirth" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TxtDateOfBirth"
                        ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                        runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                        <br />
                        (dd/mm/yyyy)
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
 <table cellspacing="2" cellpadding="0">
    <tr>
        <td style="width:116px"></td>
        <td>
 <%--           <asp:Button ID="BtnSearchToBeProfiledCandidates" runat="server" Text="Go" class="cell"
                OnClientClick="CheckForParameterChange();"
                OnClick="BtnSearchToBeProfiledCandidates_Click" />
--%>     
          <asp:Button ID="BtnSearchToBeProfiledCandidates" runat="server" Text="Go"
                OnClientClick="javascript:$.cookie('grid_page_number',1,{path: '/'});javascript return CheckForParameterChange();"
                OnClick="BtnSearchToBeProfiledCandidates_Click" />
              <asp:Button ID="BtnSearchCandidates" runat="server" Text="Hidden Search" style="display:none;"
                OnClick="BtnSearchCandidates_Click" />
        </td>
    </tr>
</table>

<table id="TblSearchResult" runat="server" cellpadding="4" cellspacing="2" visible="false">
    <tr>
        <td>
            <table>
                <tr>
                    <td><h2 class="skiplink">Results Table</h2></td>
                </tr>
            </table>
            <table cellspacing="4">
                <tr>
                    <td>
                        <asp:Button ID="BtnAddToCandidateCalling" runat="server" Text="Add To Candidate Calling" 
                            OnClientClick="javascript:AddToCandidteCallingList();" />
                        <asp:Button ID="BtnViewCandidateCallingList" runat="server" Text="View Candidate Calling List" style="display:none"
                            OnClientClick="javascript:ShowPopUp('../ViewCandidateCallingList.aspx',1200,600);return false;" />
                          <asp:Button ID="BtnPrint" runat="server" Text="Print Candidate Calling" style="display:none"
                              OnClick="BtnPrint_click" />
                    </td>
                </tr>
              <tr>
                <td valign="middle">
                   <asp:Label CssClass="labelStyle" runat="server" ID="lbNumbersT" Text="The Number of Candidates in results table below: "></asp:Label>
                   <asp:Label CssClass="labelStyle" runat="server" ID="lbNumbers" ForeColor="#d32232"  ></asp:Label>
                   <asp:Label CssClass="labelStyle" runat="server" ID="Label2" Text=" Candidates "></asp:Label>
                </td>
              </tr>
            </table>
            <table style="margin-top:10px">
                <tr>
                    <td>
                        <asp:ListView ID="LstViewToBeProfiledCandidates" runat="server" OnItemDataBound="LstViewToBeProfiledCandidates_ItemDataBound">
                            <LayoutTemplate>
                                <table>
                                    <tr>
                                        <td><div id="DivProfiledCandidates" class="pager"></div></td>
                                    </tr>
                                </table>
                                <table id="TblToBeProfiledCandidates" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"  style="border-color:#808080" border="1px" >
                                    <thead>
                                        <tr class="grid-header">
                                            <th>
                                                <input id="ChkSelectAllCandidates" type="checkbox"  
                                                    title="Select All Candidates"
                                                    onclick ="javascript:SelectAllCandidates();" />
                                            </th>
                                            <th align="right">No.</th>
                                            <th style="white-space:nowrap">Name of Candidate</th>
                                            <th>Registration ID </br>(R I D)</th>
                                            <th>Disability Type</th>
                                            <th>NGO</th>
                                            <th>Educational Qualifications</th>
                                            <th>Phone numbers</th>
                                            <th style="white-space:nowrap">Email</th>                                                                                                                           
                                            <th>Current Company</th>
                                        </tr>
                                    </thead> 
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td id="TdRadioButton">
                                        <asp:CheckBox ID="ChkCandidateName"  runat="server"
                                            CandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>' />
                                        <label id="LblCandidateName" runat="server" class="skiplink">Select <%#Eval("candidate_name") %></label>
                                    </td>
                                    <td id="TdRecordNumber" align="right"></td>
                                    <td align="left">
                                        <a id="LnkCandidateName" class="readonlyText" target="_blank" title="Candidate Name : <%#Eval("candidate_name") %>"
                                            href='<%#"Registration.aspx?cand=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("candidate_name") %></a>
                                    </td>
                                    <td align="left">
                                        <a id="LnkBtnRegistrationID" class="readonlyText" target="_blank" title="<%#Eval("candidate_name") %>'s RID"
                                             href='<%#"AddViewCandidateHistory.aspx?cand=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("registration_id") %></a>
                                    </td>
                                    <td align="left" title="<%#Eval("candidate_name") %>'s Disability Type"><%#Eval("disability_type")%></td>
                                    <td align="left" title="<%#Eval("candidate_name") %>'s NGO Name"><%#Eval("ngo_name")%></td>
                                    <td align="left" title="<%#Eval("candidate_name") %>'s Educational Qualifications"><%#Eval("educational_qualifications") %></td>
                                    <td align="right" style="width:100px" title="<%#Eval("candidate_name") %>'s Phone Numbers"><%#Eval("phone_numbers")%></td>
                                    <td title="<%#Eval("candidate_name") %>'s Email Address"><%#Eval("email_address") %></td>
                                    <td align="left" title="<%#Eval("candidate_name") %>'s Current Company"><%#Eval("current_company")%></td>
                                        <td style="display:none">
                                            <span id="SpnCount" runat="server"><%# Eval("StrCount")%></span>
                                        </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <table>
                                    <tr>
                                        <td style="padding-left:300px">
                                            <span style="font-weight:bold">No Search Results</span>
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<%--Hidden fields for Candidate Calling List--%>
<div>
<table style="display:none">
    <tr>
        <td>
            <label for="ctl00_ContentPlaceHolder2_TxtIsParameterChanged">test</label>
            <asp:TextBox ID="TxtIsParameterChanged" runat="server" style="display:none" />
            <label for="ctl00_ContentPlaceHolder2_TxtCandidatesInCandidateCallingList">test</label>
            <asp:TextBox ID="TxtCandidatesInCandidateCallingList" runat="server" Width="800px" style="display:none" />
        </td>
    </tr>
</table>
</div>
</asp:Content>

