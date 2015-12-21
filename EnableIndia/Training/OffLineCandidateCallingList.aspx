<%@ Page Title="Candidate Calling Off-Line" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true" Inherits="EnableIndia.Training.OffLineCandidateCallingList" Codebehind="OffLineCandidateCallingList.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellspacing="0" cellpadding="0" >
    <tr>
        <td class="pageHeader">Training Section</td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">
    <tr>
        <td>
            Manage Open Training Projects>>Candidate Calling (off-line)
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
            <span class="readonlyText">Training Program Instance:</span>
        </td>
        <td><span id="SpnTrainingProgramName" runat="server" class="readonlyText"></span>
        </td>
        <td><span id="SpnTrainnigProjectDetail" runat="server" class="readonlyText"></span>
        </td>
    </tr>
</table>
<table style="margin-top:10px">
    <tr>
        <td style="padding-left:50px">
            <asp:Button ID="BtnSelectAll" runat="server" Text="Select All"
            OnClientClick="javascript:return SelectAllCandidates();" />
        </td>
        <td>
            <asp:Button ID="BtnDeleteCandidates"  runat="server" Text="Delete Candidates" />
        </td>
    </tr>
</table>

<table cellspacing="4" style="margin-top:10px">
    <tr>
        <td>
            <asp:ListView ID="LstViewCandidateCallingList" runat="server" 
                OnItemDataBound="LstViewCandidateCallingList_ItemDataBound">
                <LayoutTemplate>
              
                    <table id="TblViewCandidateCallingList" cellpadding="4" class="tableBorder  checkedListBox mandatory" cellspacing="0" rules="all" 
                           bordercolor="#808080" border="1px" messagetext="Candidate" style="margin:10px">
                        <thead>
                            <tr class="grid-header">
                            
                                <th></th>
                                <th >Name</th>
                                <th >RID</th>
                                <th >Mark Phone on which reached</th>
                                <th >Disability</th>
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
                    <tbody>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
                    </tbody>                   
                </table>
                  
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                          <asp:CheckBox ID="ChkRecommendedCandidateName" runat="server" 
                                CandidateID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_id"))) %>' />
                           <label id="LblCandidateName" runat="server" class="skiplink">Select <%#Eval("candidate_name")%></label>
                        </td>
                        <td><%# Eval("candidate_name")%></td>
                        <td><%# Eval("registration_id")%></td>
                        <td align="right" ><%# Eval("phone_numbers") %></td>
                        <td><%# Eval("disability_type")%></td>
                         <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                        <table>
                            <tr>
                                <td style="padding-left:300px">
                                    <span style="font-weight:bold">No Candidates</span>
                                </td>
                            </tr>
                        </table>
                </EmptyDataTemplate>
        </asp:ListView>

        </td>
    </tr>
</table>



<table>
    <tr>
        <td>
            <%--Hidden fields for Candidate Calling List--%>
            <label for="ctl00_ContentPlaceHolder1_TxtCandidateCallingHeader">test</label>
            <asp:TextBox ID="TxtCandidateCallingHeader" runat="server" Width="800px" />
            <label for="ctl00_ContentPlaceHolder1_TxtCandidatesInCandidateCallingList">test</label>
            <asp:TextBox ID="TxtCandidatesInCandidateCallingList" runat="server" Width="800px" />
        </td>
    </tr>

</table>

<script src="OffLineCandidateCallingList.js" type="text/javascript"></script>
<script src="../Scripts/jquery.cookie.js" type="text/javascript"></script>
</asp:Content>

