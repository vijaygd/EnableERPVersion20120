<%@ Page Title="" Language="C#" MasterPageFile="~/MobileDevices/mobileMaster.Master" AutoEventWireup="true" CodeBehind="mdEducationalQualification.aspx.cs" Inherits="EnableIndia.MobileDevices.mdProfileHistory.mdEducationalQualification" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="text-align:left;">
    <table style="border-collapse:separate; border-spacing:2px;">
    <tr>
        <td style="text-align:center;">
            <asp:LinkButton ID="LnkBtnRegistration" runat="server" Text="Registration"
                PostBackUrl="~/MobileDevices/ProfileHistory/mdRegistration.aspx" CssClass="tab_links" />
        </td>
        <td style="padding-left:12px; text-align:center;">Educational Qualification</td>
        
        <td style="padding-left:12px; text-align:center;">
            <asp:LinkButton ID="LnkBtnWorkExperience" runat="server" Text="Work Experience"
                PostBackUrl="~/MobileDevices/ProfileHistory/mdCandidateWorkExperience.aspx" CssClass="tab_links" />
        </td>
        <td style="padding-left:12px; text-align:center;">
            <asp:LinkButton ID="LnkBtnKnowledgeAndTraining" runat="server" Text="Knowledge and Training"
                PostBackUrl="~/MobileDevices/ProfileHistory/mdCandidateKnowledgeTraining.aspx" CssClass="tab_links" />
        </td>
        <td style="padding-left:12px; text-align:center;">
            <asp:LinkButton ID="LnkBtnJobProfiling" runat="server" Text="Job Profiling"
                PostBackUrl="~/MobileDevices/ProfileHistory/mdCandidateJobProfile.aspx" CssClass="tab_links" />
        </td>
        <td style="padding-left:12px; text-align:center;">
            <asp:LinkButton ID="LnkButtonCandidateHistory" runat="server" Text="Candidate History" CssClass="tab_links" 
            PostBackUrl="~/MobileDevices/ProfileHistory/mdAddViewCandidateHistory.aspx" />
        </td>
    </tr>
</table>
</div>
<table style="border-collapse:collapse; border-spacing:0px;" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink">Educational Qualifications</span></h1>
        </td>
    </tr>
</table>
<table style="border-collapse:separate; border-spacing:2px; border-color:darkblue;" >
    <tr>
        <td style = "width:210px">
            <span id="SpnCandidateNameText" runat="server" style="font-weight:bold" class="readonly_bold_text">Candidate:</span>
            <span id="SpnCandidateFirstName" runat="server" class="readonlyText"/>
            <span id="SpnCandidateMiddleName" runat="server" style="font-weight:bold" class="readonlyText"/>
            <span id="SpnCandidateLastName" runat="server" class="readonlyText"/>
        </td>
        <td style="width:250px">
            <span id="SpnDisabilityTypeText" runat="server" style="font-weight:bold" class="readonly_bold_text">Disability Type:</span>
            <span id="SpnDisabilityType" runat="server" class="readonlyText"></span>
        </td>
        <td style="width:100px">
            <span id="SpnRIDText" runat="server" style="font-weight:bold" class="readonly_bold_text">RID :</span>
            <span id="SpnRID" runat="server" class="readonlyText"></span>
        </td>
        <td>
            <span id="SpnStatusText" runat="server" style="font-weight:bold" class="readonly_bold_text">Status:</span>
            <span id="SpnStatus" runat="server" class="readonlyText"></span>
        </td>
    </tr>
</table>
    <div style="text-align:left;">
            <asp:ListView ID="LstViewEducationalQualifications" runat="server" >
                <LayoutTemplate>
                    <table style="margin-bottom:5px" >
                        <tr>
                            <td style="font-weight:bold">Existing Data on Educational Qualifications</td>
                        </tr>
                    </table>
                    <table id="TblEducationalQualifications" style="border-collapse:separate; border-width:2px; border-spacing:0px; border-color:#808080;"  class="tableBorder"  rules="all" >
                        <thead>
                            <tr class="grid-header">
                                <th style="text-align:center;">No.</th>
                                <%--<th><span class="skiplink">Radio button for selecting row to update</span></th>--%>
                                <th style="text-align:center;">Course/Qualifications</th>
                                <th style="text-align:center;">Passing Year</th>
                                <th style="text-align:center;">Percentage %</th>
                                <th style="text-align:center;">Details</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </tbody>
                    </table>
                    
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td id="TdRecordNumber" style="text-align:center;">
                             <asp:LinkButton ID="LnkBtnCourseQualificationName" runat="server" Text="" CssClass="readonlyText" Font-Bold="true"
                                CourseQualificationID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_qualification_id"))) %>'
                                CourseID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("course_qualification_id"))) %>'
                                OnClick="LnkBtnCourseQualificationName_Click"
                              />
                        </td>
                        <td runat="server" id="qulName" style="font-weight:normal; text-align:left;">
                            <%#Eval("course_qualification_name") %>
                            
                        </td>
                        <td style="text-align:right;" runat="server" id="passingYear"><%#Eval("passing_year")%></td>
                        <td style="text-align:right;"><%#Eval("str_percentage")%></td>
                        <td style="text-align:left"><%#Eval("details")%></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    <div  runat="server" id="TblOtherQualification">
            <span>Other Educational Qualifications (eg. Currently doing)</span>
            <span id="SpnOtherQualifications" runat="server" class="readonlyText"></span>

    </div>

<table>
    <tr>
        <td>
            <asp:Button ID="BtnAddMoreQualifications" runat="server" Text="Add  Qualifications" Visible="false"
                ToolTip="Add Qualifications"
                OnClick="BtnAddMoreQualifications_Click" />
        </td>
        <td>
            <%-- <asp:Button ID="BtnEditQualifications" runat="server" Text="Edit" ToolTip="Edit" Visible="false"
                OnClientClick="javascript:if(ValidateListViewForCheckedRadioButtons('TblEducationalQualifications','Please select atleast one qualification.')==true)ShowEducationalQualificationsPopup(1);"
                OnClick="BtnEditQualifications_Click" />--%>
        </td>
    </tr>
</table>
<div>
     <div style="width:990px; height:650px;">
        <telerik:RadWindowManager runat="server" ID="radManager" EnableViewState="false" DestroyOnClose="true" VisibleOnPageLoad="false"  AutoSize="true" Top="0"  Height="680px" Width="900px" Modal="true" CssClass="RadWindow">
        </telerik:RadWindowManager>
     </div>
 </div>
    <script src="../../Scripts/jquery-2.1.4.min.js"></script>
    <script src="../../Scripts/Common.js"></script>
    <script src="mdEducationalQualifications.js"></script>
</asp:Content>
