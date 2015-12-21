<%@ Page Title="Task Management" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.TaskManagement" Codebehind="TaskManagement.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td class="pageHeader">Candidate Section</td>
    </tr>
</table>    
<table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">    
    <tr>
        <td>Task Management > Search Open Candidate Tasks</td>
    </tr>
 </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td class="skiplink">
            <h1><span id="skipToTop" class="skiplink">Task Management</span></h1>
            <asp:HiddenField runat="server" ID="hrtbChanged" />
        </td>
    </tr>
</table>
<table cellpadding="4">
    <tr>
        <td>
            
            <table>
                <tr>
                    <td valign="top"style="width:83px" ><span>Select Date</span>
                            <br /> 
                    
                    </td>
                    <td >
                        <select id="DdlDates" runat="server">
                            <option value="created">Created</option>
                            <option value="Followup">Follow-up</option>
                        </select>
                        <br />
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_DdlDates" class="skiplink">Select date</label></td>
                    <td style="padding-left:105px" >
                        <asp:TextBox ID="TxtDateFrom" runat="server" yearlength="4" />
                        <asp:ImageButton runat="server" ID="Image2" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                        <cc1:CalendarExtender runat="server" ID="CalendarExtender2" PopupButtonID="Image2" TargetControlID="TxtDateFrom" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtDateFrom"
                        ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                        runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                        <br />(dd/mm/yyyy)
                        <label for="ctl00_ContentPlaceHolder2_TxtDateFrom" class="skiplink">Select date from</label>
                    </td>
                    <td style="padding-left:10px;padding-right:10px"  valign="top" >to</td>
                    <td >
                        
                        <asp:TextBox ID="TxtDateTo" runat="server"  yearlength="4" />
                        <asp:ImageButton runat="server" ID="Image1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="Image1" TargetControlID="TxtDateTo" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtDateTo"
                        ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                        runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                        <br />(dd/mm/yyyy)
                        <label for="ctl00_ContentPlaceHolder2_TxtDateTo" class="skiplink">Select date to</label>
                    </td>
                </tr>
            </table>
            
            <table style="display:none">
                <tr>
                    <td style="width:83px">Select</td>
                    <td style="width:165px">
                        <select id="DdlParameters" runat="server" onchange="javascript:ResetAllDropDown();DdlParameters_OnSelectedIndexChanged();">
                            <option value="flag">Flag</option>
                            <option value="managed_by">Managed By</option>
                            <option value="Disabilities">Disability</option>
                        </select>
                        <%--<asp:Button ID="BtnPopulateParameterValues" runat="server" Text="Refresh" OnClick="BtnPopulateParameterValues_Click" />--%>
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_DdlParameters" class="skiplink">Select parameter</label></td>
                    <td style="padding-left:14px;padding-right:10px">
                        
                        
                       
                                           </td>
                    <td><label for="ctl00_ContentPlaceHolder2_DdlSelectedParameterValues" class="skiplink">Select values of selected paramete</label></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width:83px">Flag</td>
                    <td><select id="DdlFlags" runat="server" ></select></td>
                    <td><label for="ctl00_ContentPlaceHolder2_DdlFlags" class="skiplink">Select Flag</label></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width:83px">Managed By
                    </td>
                    <td><select id="DdlEmployee" runat="server"></select>
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_DdlEmployee" class="skiplink">Select Managed by </label></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width:83px">Disability</td>
                    <td> <select id="DdlDisabiltyTypes" runat="server"></select></td>
                    <td><label for="ctl00_ContentPlaceHolder2_DdlDisabiltyTypes" class="skiplink">Select Disability type</label></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width:83px">Search For</td>
                    <td>
                        <asp:TextBox ID="TxtSearchFor" runat="server" />
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_TxtSearchFor" class="skiplink">Search for</label></td>
                    <td style="padding-left:10px;padding-right:10px">in</td>
                    <td>
                        <select id="DdlSearchIn" runat="server">
                            <option value="registration_id">RID</option>
                            <option value="name">Name</option>
                        </select>
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_DdlSearchIn" class="skiplink">Search in</label></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="padding-left:90px">
                        <asp:Button ID="BtnSearchOpenCandidateTasks" runat="server" Text="Go" 
                        OnClientClick="javascript:return GoSearchParameter();"
                            OnClick="BtnSearchOpenCandidateTasks_Click" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:ListView ID="LstViewOpenCandidateTasks" runat="server" >
                            <LayoutTemplate>
                                <table id="TblViewOpenCandidateTasks" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                                    bordercolor="#808080" border="1px">
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right">No.</th>
                                            <th>Creation Date</th>
                                            <th>Candidate</th>
                                            <th>RID</th>
                                            <th>Disability</th>
                                            <th>Task Details</th>
                                            <th>Flag</th>
                                            <th>Managed By</th>
                                            <th>Action Points</th>
                                            <th>Follow-up date</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                <td id="TdRecordNumber" align="right">
                                     <asp:LinkButton ID="LnkOpenCandidateTasks" runat="server" CssClass="readonlyText" ClientIDMode="AutoID"
                                        OnClientClick="javascript:ShowCandidateOpenTaskPopup(1,this.id);"
                                        CandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'
                                        CandidateHistoryID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("history_id"))) %>'
                                        OnClick="LnkOpenCandidateTasks_click"
                                     />
                                </td>
                                <td align="left"> <%#Convert.ToDateTime(Eval("history_date")).ToString("dd/MM/yyyy")%></td>
                                <td align="left">
                                    <a id="LnkBtnCandidateName" class="readonlyText" 
                                        href='<%#"ProfileHistory/Registration.aspx?cand=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("canddiate_name")%></a>
                                </td>
                                <td align="left">
                                    <a id="LnkBtnRegistrationID" class="readonlyText"
                                    href='<%#"ProfileHistory/AddViewCandidateHistory.aspx?cand=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'><%#Eval("registration_id")%></a>
                                </td>
                                <td align="left"><%#Eval("disability_type")%></td>
                                <td align="left"><%#Eval("details") %></td>
                                <td align="left"><%#Eval("flag_name") %></td>
                                <td align="left"><%#Eval("employee_name")%></td>
                                <td align="left"><%#Eval("recommended_action")%></td>
                                <td align="left"><%#Eval("str_follow_up_date")%></td>
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
 <script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="TaskManagement.js" type="text/javascript"></script>
</asp:Content>

