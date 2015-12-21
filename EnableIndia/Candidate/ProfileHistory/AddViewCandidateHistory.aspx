<%@ Page Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.ProfileHistory.AddViewCandidateHistory" Codebehind="AddViewCandidateHistory.aspx.cs" ClientIDMode="Static" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">Candidate Section</td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">
        <tr>
            <td>Profile and History >Add and View Candidate History</td>
        </tr>
    </table>
    
<table cellpadding="0" cellspacing="0" style="margin-top:10px">
    <tr>
        <td style="width:15px">&nbsp;</td>
        <td align="center">
            <asp:LinkButton ID="LnkBtnRegistration" runat="server" Text="Registration"
                PostBackUrl="~/Candidate/ProfileHistory/Registration.aspx" CssClass="tab_links"  />
        </td>
        <td style="padding-left:12px" align="center">
            <asp:LinkButton ID="LnkBtnEducationalQualifications" runat="server" Text="Educational Qualifications"
                PostBackUrl="~/Candidate/ProfileHistory/EducationalQualifications.aspx" 
                CssClass="tab_links" />
        </td>
        <td style="padding-left:12px" align="center">
            <asp:LinkButton ID="LnkBtnWorkExperience" runat="server" Text="Work Experience"
                PostBackUrl="~/Candidate/ProfileHistory/CandidateWorkExperience.aspx" CssClass="tab_links" />
        </td>
        <td style="padding-left:12px" align="center">
            <asp:LinkButton ID="LnkBtnKnowledgeAndTraining" runat="server" Text="Knowledge and Training"
                PostBackUrl="~/Candidate/ProfileHistory/CandidateKnowledgeTraining.aspx" CssClass="tab_links" />
        </td>
        <td style="padding-left:12px" align="center">
            <asp:LinkButton ID="LnkBtnJobProfiling" runat="server" Text="Job Profiling"
                PostBackUrl="~/Candidate/ProfileHistory/CandidateJobProfile.aspx" CssClass="tab_links" />
        </td>
        <td style="padding-left:12px" align="center">Candidate History</td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="skiplink">
        <tr>
            <td> 
                <h1><span id="skipToTop" class="skiplink" style="color:White">Add & View Candidate History</span></h1>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:210px">
                <span id="SpnCandidateNameText" runat="server" class="readonly_bold_text">Candidate:</span>
                <span id="SpnCandidateFirstName" runat="server" class="readonlyText"/>
                <span id="SpnCandidateMiddleName" runat="server" class="readonlyText"/>
                <span id="SpnCandidateLastName" runat="server" class="readonlyText"/>
            </td>
            <td style="width:250px">
                <span id="SpnDisabilityTypeText" runat="server" class="readonly_bold_text">Disability Type:</span>
                <span id="SpnDisabilityType" runat="server" class="readonlyText"></span>
            </td>
            <td style="width:100px">
                <span id="SpnRIDText" runat="server" class="readonly_bold_text">RID :</span>
                <span id="SpnRID" runat="server" class="readonlyText"></span>
            </td>
            <td>
                <span id="SpnStatusText" runat="server" class="readonly_bold_text">Status:</span>
                <span id="SpnStatus" runat="server" class="readonlyText"></span>
            </td>
        </tr>
    </table>
    <table cellpadding="4">
      <tr>
        <td> 
            <asp:ListView ID="LstViewHistoryAllCandidate" runat="server" OnItemDataBound="LstViewHistoryAllCandidate_ItemDataBound">
                <LayoutTemplate>
                    <table style="margin-bottom:5px">
                        <tr> 
                            <td style="font-weight:bold " >
                                Existing History of Candidate:
                            </td>
                        </tr>
                    </table>
                    <table id="TblCandidateHistory" cellpadding="4" cellspacing="0" rules="all" style="border-color:#808080;"
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
                           <asp:LinkButton ID="LnkBtnHistoryDate" runat="server" Status='<%#Eval("status") %>' CssClass="readonlyText"
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
            </asp:ListView>
        </td>
      </tr>
    </table>
   <table>
        <tr>
            <td>
                <asp:Button ID="BtnAddNewCandidateHistory" runat="server" Text="Add New History"  
                    OnClick="BtnAddNewCandidateHistory_Click" />
            </td>
            <td>
                <%--<asp:Button ID="BtnEditCandidateHistory" runat="server" Text="Edit"  
                    OnClientClick="javascript:if(ValidateListViewForCheckedRadioButtons('TblCandidateHistory','Please select atleast one history.')==true)ShowCandidateHistoryPopup(1);" />--%>
            </td>
        </tr>
    </table>
    <center>
     <div style="width:990px; height:650px;">
        <telerik:RadWindowManager runat="server" ID="radManager" DestroyOnClose="true"  AutoSize="true" Top="0"  Height="680px" Width="900px" Modal="true" CssClass="RadWindow">
        </telerik:RadWindowManager>
     </div>
     </center>
<script src="../../Scripts/jquery-1.7.1-vsdoc.js" type="text/javascript"></script>
<script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="../../Scripts/Common.js" type="text/jscript"></script>
<script src="AddViewHistory.js" type="text/javascript"></script>
<script src="AddViewCandidateHistory.js" type="text/javascript"></script>

</asp:Content>

