<%@ Page Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Company.AddViewCompanyHistory" Title="Add and View Company History" Codebehind="AddViewCompanyHistory.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" class="pageHeader">Company Section</td>
        </tr>
     </table>
    <table cellpadding="0" cellspacing="0"  class="pageHeaderLevel1" >
        <tr>
            <td colspan="2">Add and View Company History</td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td> 
            <h1><span id="skipToTop" class="skiplink" style="color:White">Add & View Company History</span></h1>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px">
            <label for="ctl00_ContentPlaceHolder2_DdlParentCompany">SELECT PARENT COMPANY</label>
        </td>
        <td>
           <select id="DdlParentCompany" runat="server" class="mandatory" messagetext="Parent Company" type="select-one"
            onchange="javascript:DdlParentCompany_SelectIndexChanged(this.value,'ParentCompanyID','DdlCompanyCode','DdlHiddenCompanyCode');"
              />&nbsp;&nbsp;&nbsp;
           <span id="SpnParentCompany" runat="server"/>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px">
            <label for="ctl00_ContentPlaceHolder2_DdlCompanyCode">SELECT COMPANY</label>
        </td>
        <td>
          <select id="DdlCompanyCode" runat="server" class="mandatory" messagetext="Company Code" type="select-one"
                onchange="javascript:$('#TxtHiddenCompanyID').val($('#DdlCompanyCode').val()); " />&nbsp;&nbsp;&nbsp;> 
           <span id="SpnCompanyCode" runat="server" />
        </td>
        <td>
            <table style="display:none" >
                <tr>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_DdlHiddenCompanyCode">HiddenCompanyCode</label>
                        <select id="DdlHiddenCompanyCode" runat="server" />
                        <label for="ctl00_ContentPlaceHolder2_TxtHiddenCompanyID">HiddenText</label>
                        <asp:TextBox ID="TxtHiddenCompanyID" runat="server">1</asp:TextBox>
                    </td> 
                </tr>
            </table>        
        </td>
        
       
    </tr>
</table>
<table>
    <tr>
       <td> <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClientClick="javascript:ValidateForm();" OnClick="BtnSubmit_click" />
        </td>
        <td><span id="SpnHiddenCompanyID" runat="server" style="display:none" ></span></td> 
    </tr>
</table>
<table cellpadding="4">
      <tr>
        <td> 
            <asp:ListView ID="LstViewHistoryAllCompany" runat="server"
                OnItemDataBound="LstViewHistoryAllCompany_ItemDataBound" >
                <LayoutTemplate>
                    <table style="margin-bottom:5px">
                        <tr> 
                            <td style="font-weight:bold " >
                                Existing History :
                            </td>
                        </tr>
                    </table>
                    <table id="TblCompanyHistory" cellpadding="4" cellspacing="0" rules="all" bordercolor="#808080"
                       class="tableBorder" border="1px">
                        <thead>
                           <tr class="grid-header">
                                <th align="right">No.</th>
                                <th>Creation Date</th>
                                <th>Details</th>
                                <th>Flag</th>
                                <th>Managed By</th>
                                <th>Action Points</th>
                                <th>Follow up Date</th>
                                <th>Status</th>
                                <th>Closure Date</th>
                           </tr>                        
                         </thead>
                         <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                         </tbody>                                                  
                     </table>   
                </LayoutTemplate>
                
                <ItemTemplate>
                    <tr>
                        <td align="right" id="TdRecordNumber">
                            <asp:LinkButton ID="LnkBtnHistoryDate" runat="server" Status='<%#Eval("status") %>' ClientIDMode="AutoID" CssClass="readonlyText"
                                OnClientClick="javascript:ShowCandidateHistoryPopup(1,this.id);"
                                CandidateHistoryID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("history_id"))) %>'
                                OnClick="LnkBtnHistoryDate_Click" />
                        </td>
                        <td align="left"><%#Convert.ToDateTime(Eval("history_date")).ToString("dd/MM/yyyy")%></td>
                        <td align="left"><%#Eval("details") %></td>
                        <td align="left"><%#Eval("flag_name")%></td>
                        <td align="left"><%#Eval("employee_name")%></td>
                        <td align="left"><%#Eval("recommended_action")%></td>
                        <td align="left"><%#Eval("str_follow_up_date")%></td>
                        <td align="left"><%#Eval("status")%></td>
                        <td align="left"><%#(Eval("str_closure_date"))%></td>
                        
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
  <table>
        <tr>
            <td>
                <asp:Button ID="BtnAddNewCompanyHistory" runat="server" Text="Add New History" 
                    OnClientClick="javascript:ShowCandidateHistoryPopup(-1);"
                    OnClick="BtnAddNewCompanyHistory_click" Visible="false"
                      />
            </td>
            <td>
                <%--<asp:Button ID="BtnEditCandidateHistory" runat="server" Text="Edit"  
                    OnClientClick="javascript:if(ValidateListViewForCheckedRadioButtons('TblCandidateHistory','Please select atleast one history.')==true)ShowCandidateHistoryPopup(1);" />--%>
            </td>
        </tr>
    </table>
    <script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="AddViewCompanyHistory.js" type="text/javascript"></script>
</asp:Content>

