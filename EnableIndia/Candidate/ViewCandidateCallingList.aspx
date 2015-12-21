<%@ Page Title="Candidate Calling List" Language="C#" ValidateRequest="false" MasterPageFile="~/Popup.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.ViewCandidateCallingList" Codebehind="ViewCandidateCallingList.aspx.cs" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width:0px;height:0px"></div>
<label for="ctl00_ContentPlaceHolder1_TxtCandidateCallingList" style="display:none">test</label>
<asp:TextBox ID="TxtCandidateCallingList" runat="server" Height="500px" Width="1000px" TextMode="MultiLine" style="display:none"  />

<table >
    <tr>
        <td style="display:none">
            <asp:Button ID="BtnExportToExcel" runat="server" Visible="false" Text="Export To Excel" />
        </td>
       
    </tr>
</table>

<table>
    <tr style="font-size:11px">
        <td>
            <span id="SpnTextTrainingProgram" runat="server" visible="false" class="readonly_bold_text">Training Program:</span>
        </td>
        <td><span id="SpnTrainingProgramName" runat="server" class="readonlyText"></span>
        </td>
       
    </tr>
</table>

<table>
    <tr style="font-size:11px">
        <td>
            <span id="SpnTextTrainingProjectName" runat="server" visible="false" class="readonly_bold_text">Training Project:</span>
        </td>
         <td><span id="SpnTrainingProjectName" runat="server" class="readonlyText"></span>
        </td>
    </tr>
</table>

<table>
    <tr style="font-size:11px">
        <td class="readonly_bold_text">
            <span id="SpnTextEmploymentProjectName" runat="server" visible="false">Employment Project : </span>
        </td>
        <td>
            <span id="SpnEmploymentProjectName" runat="server" visible="false" class="readonlyText" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
            <span id="SpnStepDetails" runat="server" class="readonlyText" visible="false"></span>
            
        </td>
    </tr>
</table>    
<%--
<table  class="message">
    <tr>
        <td>
            You can add candidates from Assigned List onto the Candidate Calling List.<br />
            Use a print out of this page to fill it offline.<br />
            Delete candidates from the list below by selecting candidates using check-boxes and hitting 'Delete from List' button.<br />
            Legend:<br />
            Candidate name in capitals indicates 'unemployed candidate'.<br />
            If candidate is already assigned to some employment project, then a $ appears before the candidate name.<br />
            If candidate is a priority candidate, then a * appears before candidate name.<br />
            If candidate is already assigned to some training program, then a # appears before the candidate name.<br />
            If candidate is a needy candidate, then a % appears before candidate name.<br />
        </td>
    </tr>
    
</table>--%>

<table cellpadding="4"  style="margin-top:10px">
    <tr>
        <td>
            <asp:Button ID="BtnDeleteFromList" runat="server" Text="Delete From List" Visible="false"
                 OnClick="btnDelFromListClick" />
        </td>
    </tr>
</table>

<table cellpadding="4">
    <tr>
        <td>
            <asp:ListView ID="LstViewCandidateCallingList" runat="server" OnItemDataBound="LstViewCandidateCallingList_ItemDataBound">
                <LayoutTemplate>
                    <table id="TblCandidateCallingList" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                          bordercolor="#808080" border="1px">
                          <thead>
                            <tr class="grid-header">
                                <th>
                                     <asp:CheckBox ID="ChkSelectAllCandidates" runat="server" ToolTip="Select all candidates"
                                        onclick="javascript:SelectAllCandidates(this.id);" />
                                        
                                </th>
                                <th>Record No.</th>
                                <th>Candidate RID</th>
                                <th>Name</th>
                                <th>Disability<br />Type</th>
                                <th>Phone 1</th>
                                <th>Phone 2</th>
                                <th>How did you get in touch?</th>
                                <th>What was Candidate's reply?</th>
                                <th>Got Job? <br />(Yes/No)</th>
                                <th>Remarks/Next Action</th>
                               <%-- <th>Mark Phone on<br />which reached</th>
                                <th>Send SMS</th>
                                <th>Send Telegram</th>
                                <th>Send e-mail</th>
                                <th>Got Job?<br />(Yes/No)</th>
                                <th>Organisation</th>
                                <th>Designation</th>
                                <th>Joining Date</th>
                                <th>Salary</th>
                                <th>Comments</th>--%>
                            </tr>
                          </thead>
                          
                          <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                          </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr CandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>'>
                        <td>
                            <asp:CheckBox ID="ChkSelectCandidateID" runat="server" 
                                CandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>' />
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td><label id="lblSelectCandidateID" runat="server" class="skiplink">Select <%#Eval("candidate_name")%></label></td>
                                </tr>
                            </table>
                        </td>
                        <td id="TdRecordNumber" align="right"></td>
                        <td align="left"><%#Eval("registration_id")%></td>
                        <td align="left"><%#Eval("candidate_name")%></td>
                        <td align="left"><%#Eval("disability_type") %></td>
                        <td align="right" style="width:100px" ><%#Eval("primary_phone_number") %></td>
                        <td align="right" style="width:100px" ><%#Eval("secondary_phone_number") %></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table id="TblCandidateCallingList" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                          bordercolor="#808080" border="1px">
                          <thead>
                            <tr class="grid-header">
                                <th></th>
                                <th>Candidate RID</th>
                                <th>Name</th>
                                <th>Disability<br />Type</th>
                                <th>Mark Phone on<br />which reached</th>
                                <th>Send SMS</th>
                                <th>Send Telegram</th>
                                <th>Send e-mail</th>
                                <th>Got Job?<br />(Yes/No)</th>
                                <th>Organisation</th>
                                <th>Designation</th>
                                <th>Joining Date</th>
                                <th>Salary</th>
                                <th>Comments</th>
                            </tr>
                          </thead>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>

<table style="margin-top:5px">
    <tr>
        <td>
            <input type="button" value="Close" onclick="javascript:self.close();" />
        </td>
    </tr>
</table>

<table style="display:none">
    <tr>
        <td>
            <%--Hidden fields for Candidate Calling List--%>
            <label for="ctl00_ContentPlaceHolder1_TxtCandidateCallingHeader">test</label>
            <asp:TextBox ID="TxtCandidateCallingHeader" runat="server" Width="800px" style="display:none" />
            <label for="ctl00_ContentPlaceHolder1_TxtCandidatesInCandidateCallingList">test</label>
            <asp:TextBox ID="TxtCandidatesInCandidateCallingList" runat="server" Width="800px" style="display:none" />
        </td>
    </tr>
</table>
<script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery.cookie.js" type="text/javascript"></script>
<script src="ViewCandidateCallingList.js" type="text/javascript"></script>
</asp:Content>

