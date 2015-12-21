<%@ Page Title="" Language="C#" MasterPageFile="~/MobileDevices/mobileMaster.Master" AutoEventWireup="true" CodeBehind="mdAddViewCandidateHistory.aspx.cs" Inherits="EnableIndia.MobileDevices.ProfileHistory.mdAddViewCandidateHistory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <table style="border-collapse:separate; border-spacing:2px; border-width:1px; border-color:darkblue;">
    <tr>
        <td style="text-align:center;">
            <asp:LinkButton ID="LnkBtnRegistration" runat="server" Text="Registration"
                PostBackUrl="~/MobileDevices/ProfileHistory/Registration.aspx" CssClass="tab_links" />
        </td>
        <td style="padding-left:12px; text-align:center;">
          <asp:LinkButton ID="LnkBtnEducationalQualifications" runat="server" Text="Educational Qualifications"
                PostBackUrl="~/MobileDevices/ProfileHistory/mdEducationalQualification.aspx" 
                CssClass="tab_links" />
        </td>
        
        <td style="padding-left:12px; text-align:center;">
          <asp:LinkButton ID="LnkBtnWorkExprience" runat="server" Text="Work Experience"
                PostBackUrl="~/MobileDevices/ProfileHistory/mdCandidateWorkExperience.aspx" CssClass="tab_links" />
        </td>
        <td style="padding-left:12px; text-align:center;">
             <asp:LinkButton ID="LnkBtnKnowledgeAndTraining" runat="server" Text="Knowledge and Training"
                PostBackUrl="~/MobileDevices/ProfileHistory/mdCandidateKnowledgeTraining.aspx" CssClass="tab_links" />
       </td>
        <td style="padding-left:12px; text-align:center;">
          <asp:LinkButton ID="LnkBtnJobProfiling" runat="server" Text="Job Profiling"
                PostBackUrl="~/MobileDevices/ProfileHistory/CandidateJobProfile.aspx" CssClass="tab_links" />
        </td>
        <td style="padding-left:12px; text-align:center;">Candidate History
        </td>
    </tr>
     </table>
 
    <table style="margin-bottom:10px">
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
    <div>
            <asp:ListView ID="LstViewHistoryAllCandidate" runat="server" OnItemDataBound="LstViewHistoryAllCandidate_ItemDataBound">
                <LayoutTemplate>
                    <table style="margin-bottom:5px">
                        <tr> 
                            <td style="font-weight:bold " >
                                Existing History of Candidate:
                            </td>
                        </tr>
                    </table>
                    <table id="TblCandidateHistory" rules="all" style="border-color:#808080; border-collapse:separate; border-spacing:0px; border-width:4px;">
                        <thead>
                           <tr class="grid-header">
                                <th style="text-align:right;">No.</th>
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
                        <td id="TdRecordNumber" style="text-align:right;">
                           <asp:LinkButton ID="LnkBtnHistoryDate" runat="server" Status='<%#Eval("status") %>' CssClass="readonlyText"
                                CandidateHistoryID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("history_id"))) %>'
                                OnClick="LnkBtnHistoryDate_Click" />
                        </td>
                        <td style="text-align:left;"><%#Convert.ToDateTime(Eval("history_date")).ToString("dd/MM/yyyy")%></td>
                        <td style="text-align:left;"><%#Eval("details") %></td>
                        <td style="text-align:left;"><%#Eval("flag_name")%></td>
                        <td style="text-align:left;"><%#Eval("employee_name")%></td>
                        <td style="text-align:left;"><%#Eval("recommended_action")%></td>
                        <td style="text-align:left;"><%#Eval("str_follow_up_date")%></td>
                        <td style="text-align:left;"><%#Eval("status")%></td>
                        <td style="text-align:left;"><%#(Eval("str_closure_date"))%></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
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
     <div style="width:990px; height:650px;">
        <telerik:RadWindowManager runat="server" ID="radManager" DestroyOnClose="true"  AutoSize="true" Top="0"  Height="680px" Width="900px" Modal="true" CssClass="RadWindow">
        </telerik:RadWindowManager>
     </div>
<script src="../../Scripts/jquery-1.7.1-vsdoc.js" type="text/javascript"></script>
<script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="../../Scripts/Common.js" type="text/jscript"></script>
<script src="mdAddViewHistory.js" type="text/javascript"></script>
<script src="mdAddViewCandidateHistory.js" type="text/javascript"></script>

</asp:Content>
