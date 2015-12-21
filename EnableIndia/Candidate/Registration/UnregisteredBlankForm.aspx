<%@ Page Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.Registration.UnregisteredBlankForm" Title="Unregistered Blank Forms" Codebehind="UnregisteredBlankForm.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td class="pageHeader" >Candidate Section</td>
    </tr>
    <tr>
        <td>Registration > Unregistered Blank Forms</td>
    </tr>
 </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<%--    <script src="../../Scripts/jquery-1.7.1-vsdoc.js" type="text/javascript"></script>
--%>
<table cellpadding="0" cellspacing="0" class="skiplink" >
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink">Unregistered Blank Forms</span></h1>
        </td>
    </tr>
</table>

<table cellpadding="4" cellspacing="4">
    <tr>
        <td>
            <table cellpadding="4">
                <tr>
                    <td>
                        <b>Creation and printing of new blank forms:</b>
                    </td>
                </tr>
            </table>
            <table cellpadding="4">
                <tr>
                    <td style="width:203px">
                        <asp:Label CssClass="labelStyle" runat="server" ID="lbNoFormsT" Text="Numer of Forms to be created"></asp:Label>
                    </td>
                    <td>
                      <asp:TextBox ID="TxtNumberOfNewForms"  runat="server" Width="50px" />
                      <cc1:FilteredTextBoxExtender ID="filTxt" runat="server" TargetControlID="TxtNumberOfNewForms" FilterMode="ValidChars" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                    </td> 
                </tr>
            </table>
            
            <table cellpadding="4">
                <tr>
                    <td style="width:203px">
                        <label for="ctl00_ContentPlaceHolder2_DdlNgos">Select NGO</label>
                    </td>
                    <td>
                        <select id="DdlNgos" runat="server" class="mandatory" messagetext="NGO">
                            <option value="-2">Select</option>
                            <option value="1">Enable India</option>
                            <option value="2">Other NGO</option>
                        </select>
                    </td>
                </tr>
            </table>
            
            <table cellpadding="4">
                <tr>
                    <td style="width:203px">&nbsp;</td>
                    <td>
                        <asp:Button ID="BtnCreate" runat="server" Text="Create" 
                            IsSubmit="true" OnClick="BtnCreate_Click" />
                    </td>
                    <td>
                        <asp:Button ID="BtnCreatePrint" runat="server" Text="Create and Print"
                          OnClick="BtnCreatePrint_Click"  />
                    </td>
                </tr>
            </table>
            
            <table cellpadding="4">
                <tr>
                    <td>
                        <b>Existing unused blank registration forms:</b>
                    </td>
                </tr>
            </table>
            
            <table cellpadding="4">
                <tr>
                    <td>
                         <asp:Button ID="BtnPrint" runat="server" Text="Print" 
                            OnClientClick="javascript:return ValidateCheckedBoxes();"
                            OnClick="BtnPrint_click"/>
                    </td>
                </tr>
            </table>
            
            <asp:ListView ID="LstViewUnregisteredCandidates" runat="server"
                OnItemDataBound="LstViewUnregisteredCandidates_ItemDataBound">
                <LayoutTemplate>
                    <table id="TblUnregisteredCandidates" cellpadding="4" class=" mandatory tableBorder " cellspacing="0" rules="all" style="border-color:#808080;" border="1px">
                        <thead>
                            <tr class="grid-header">
                                <td></td>
                                <th align="right">No.</th>
                                <td>Registration ID</td>
                                <td>NGO candidate belongs to</td>
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
                            <asp:CheckBox ID="ChkCandidateRegistration" runat="server" CandidateRID='<%#Eval("candidate_id") %>' />
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td><label id="LblRegistration" runat="server" class="skiplink" >Select <%#Eval("registration_id")%></label></td>
                                </tr>
                            </table>
                        </td>
                        <td id="TdRecordNumber" align="right">
                            <%-- <asp:LinkButton ID="LnkBtnGoToRegistrationForm" runat="server" CssClass="readonlyText"
                                CommandArgument='<%#Eval("candidate_id") %>'
                                NgoID='<%#Eval("ngo_id") %>' 
                                OnClick="LnkBtnGoToRegistrationForm_Click" />--%>
                            <a id="LnkBtnGoToRegistrationForm" target="_blank"
                                href='<%#"" + (Eval("ngo_id").ToString().Equals("1")?"EnableIndiaCandidate":"OtherNGOCandidate") + ".aspx?cand=" +  Eval("candidate_id").ToString() %>' >
                            </a>
                        </td>
                        <td align="left">
                            <%#Eval("registration_id") %>
                       
                        </td>
                        <th align="left"><%#Eval("ngo_name") %></th>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all" style="border-color:#808080;" border="1px">
                        <thead>
                            <tr class="grid-header">
                                <td></td>
                                <td align="right">No.</td>
                                <td>Registration ID</td>
                                <td>NGO candidate belongs to</td>
                            </tr>
                        </thead>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>

    <script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Common.js" type="text/javascript"></script>
    <script src="UnregisteredBlankForm.js" type="text/javascript"></script>

</asp:Content>

