<%@ Page Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Company.ManageCompanyTask" Title="Manage Company Task" Codebehind="ManageCompanyTask.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td class="pageHeader">Company Section</td>
    </tr>
    <tr>
        <td>Task Management > Search Open Company Tasks</td>
    </tr>
 </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td class="skiplink">
            <h1><span id="skipToTop" class="skiplink">Task Management</span></h1>
        </td>
    </tr>
</table>
<table cellpadding="4">
    <tr>
        <td>
            
            <table>
                <tr>
                    <td valign="middle" style="width:83px" ><span>Select Date</span>
                            <br /> 
                    
                    </td>
                    <td valign="middle" >
                        <select id="DdlDates" runat="server">
                            <option value="created">Created</option>
                            <option value="Followup">Follow-up</option>
                        </select>
                        <br />
                    </td>
                    <td valign="middle"><label for="ctl00_ContentPlaceHolder2_DdlDates" class="skiplink">Select date</label></td>
                    <td style="padding-left:85px" >
                    <asp:TextBox ID="TxtDateFrom" runat="server" yearlength="4" />
                    <asp:ImageButton runat="server" ID="Image1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                    <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="Image1" TargetControlID="TxtDateFrom" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtDateFrom"
                    ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                    runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                        <br />(dd/mm/yyyy)
                        <label for="ctl00_ContentPlaceHolder2_TxtDateFrom" class="skiplink">Select date from</label>
                    </td>
                    <td style="padding-left:10px;padding-right:10px"  valign="top" >to</td>
                    <td >
                     <asp:TextBox ID="TxtDateTo" runat="server"  yearlength="4" />
                        <asp:ImageButton runat="server" ID="Image2" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                        <cc1:CalendarExtender runat="server" ID="CalendarExtender2" PopupButtonID="Image2" TargetControlID="TxtDateTo" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
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
                        </select>
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_DdlParameters" class="skiplink">Select parameter</label></td>
                    <td style="padding-left:14px;padding-right:10px">
                        
                       
                                           </td>
                    <td><label for="ctl00_ContentPlaceHolder2_DdlSelectedParameterValues" class="skiplink">Select values of selected paramete</label></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width:83px" >
                        flag
                    </td>
                    <td><select id="DdlFlags" runat="server" ></select></td>
                    <td><label for="ctl00_ContentPlaceHolder2_DdlFlags" class="skiplink">Select flag</label></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:83px" >Managed By
                    </td> 
                    <td>
                         <select id="DdlEmployee" runat="server"></select>
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_DdlEmployee" class="skiplink">Select Managed By</label></td>
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
                            <option value="company">Company</option>
                        </select>
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_DdlSearchIn" class="skiplink">Search in</label></td>
                </tr>
            </table>
             <table>
                <tr>
                    <td style="padding-left:90px">
                        <asp:Button ID="BtnSearchOpenCompanyTasks" runat="server" Text="Go" 
                        OnClientClick="javascript:return GoSearchParameter();"
                         OnClick="BtnSearchOpenCompanyTasks_click"    />
                    </td>
                </tr>
            </table>
            
             <table>
                <tr>
                    <td>
                        <asp:ListView ID="LstViewOpenCompanyTasks" runat="server" >
                            <LayoutTemplate>
                                <table id="TblViewOpenCompanyTasks" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                                    border="1px">
                                    <thead>
                                        <tr class="grid-header">
                                            <th align="right">No.</th>
                                            <th>Creation Date</th>
                                            <th>Company</th>
                                            <th>Parent Company</th>
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
                                     <asp:LinkButton ID="LnkOpenCompanyTasks" runat="server" CssClass="readonlyText" ClientIDMode="AutoID"
                                        CandidateHistoryID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("history_id"))) %>'
                                            OnClientClick="javascript:ShowCompanyOpenTaskPopup(this.id);"
                                            OnClick="LnkOpenCompanyTasks_click"
                                       
                                     />
                                </td>
                                <td align="left"> <%#Convert.ToDateTime(Eval("history_date")).ToString("dd/MM/yyyy")%></td>
                               
                                 <td align="left">
                                        <%-- <a id="LnkBtnCompanyHistory" class="readonlyText" 
                                            href='<%#"AddViewCompanyHistory.aspx?comp=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("company_id"))) %>'>
                                            </a>--%>
                                        <a id="LnkBtnCompanyDetail" class="readonlyText" 
                                            href='<%#"AddCompany.aspx?comp=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("company_id"))) %>'>
                                            <%#Eval("company_code")%>
                                        </a>
                                </td>
                                  <td align="left">
                                    <%-- <a id="LnkBtnCompanyDetail" class="readonlyText" 
                                        href='<%#"AddCompany.aspx?comp=" +  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("company_id"))) %>'>
                                        </a>--%>
                                        <%#Eval("company_name")%>
                                    
                                </td>
                                  
                                <td align="left"><%#Eval("details")%></td>
                                <td align="left"><%#Eval("flag_name")%></td>
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
<script src="ManageCompanyTask.js" type="text/javascript"></script>
</asp:Content>

