<%@ Page Title="Educational Qualifications" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.ProfileHistory.EducationalQualifications" Codebehind="EducationalQualifications.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td class="pageHeader">Candidate Section</td>
    </tr>
</table>    
<table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">    
    <tr>
        <td>Profile and History> Educational Qualifications</td>
    </tr>
</table>    
<table cellpadding="0" cellspacing="0" style="margin-top:10px">
    <tr>
        <td style="width:15px">&nbsp;</td>
        <td align="center">
            <asp:LinkButton ID="LnkBtnRegistration" runat="server" Text="Registration"
                PostBackUrl="~/Candidate/ProfileHistory/Registration.aspx" CssClass="tab_links" />
        </td>
        <td style="padding-left:12px" align="center">Educational Qualifications</td>
        
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
        <td style="padding-left:12px" align="center">
            <asp:LinkButton ID="LnkButtonCandidateHistory" runat="server" Text="Candidate History" CssClass="tab_links" 
            PostBackUrl="~/Candidate/ProfileHistory/AddViewCandidateHistory.aspx" />
        </td>
    </tr>
</table>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink">Educational Qualifications</span></h1>
        </td>
    </tr>
</table>
<table >
    <tr>
        <td style = "width:210px">
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
            <asp:ListView ID="LstViewEducationalQualifications" runat="server" >
                <LayoutTemplate>
                    <table style="margin-bottom:5px" >
                        <tr>
                            <td style="font-weight:bold">Existing Data on Educational Qualifications</td>
                        </tr>
                    </table>
                    <table id="TblEducationalQualifications" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                        bordercolor="#808080" border="1px" >
                        <thead>
                            <tr class="grid-header">
                                <th align="right">No.</th>
                                <%--<th><span class="skiplink">Radio button for selecting row to update</span></th>--%>
                                <th>Course/Qualifications</th>
                                <th>Passing Year</th>
                                <th>Percentage %</th>
                                <th>Details</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </tbody>
                    </table>
                    
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <%--<td id="TdRadioButton">
                            <asp:RadioButton ID="RdbSelectQualifiaction" runat="server" 
                            QualificationID='<%#  EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_qualification_id"))) %>' />
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td><label id="LblCourseQualificationName" runat="server" class="skiplink">Select <%#Eval("course_qualification_name")%></label></td>
                                </tr>
                            </table>
                        </td>--%>
                        
                        <td id="TdRecordNumber" align="right">
                             <asp:LinkButton ID="LnkBtnCourseQualificationName" runat="server" Text="" CssClass="readonlyText"
                                CourseQualificationID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_qualification_id"))) %>'
                                CourseID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("course_qualification_id"))) %>'
                                OnClick="LnkBtnCourseQualificationName_Click"
                              />
                        </td>
                        <td runat="server" id="qulName" style="font-weight:normal" align="left">
                            <%#Eval("course_qualification_name") %>
                            
                        </td>
                        <td align="right" runat="server" id="passingYear"><%#Eval("passing_year")%></td>
                        <td align="right"><%#Eval("str_percentage")%></td>
                        <td align="left"><%#Eval("details")%></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>
<table id="TblOtherQualification" runat="server" >
    <tr>
        <td>
            <span>Other Educational Qualifications (eg. Currently doing)</span>
            <span id="SpnOtherQualifications" runat="server" class="readonlyText"></span>
        </td>
    </tr>
</table>

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
 <center>
     <div style="width:990px; height:650px;">
        <telerik:RadWindowManager runat="server" ID="radManager" EnableViewState="false" DestroyOnClose="true" VisibleOnPageLoad="false"  AutoSize="true" Top="0"  Height="680px" Width="900px" Modal="true" CssClass="RadWindow">
        </telerik:RadWindowManager>
     </div>
 </center>
 </div>

<script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="EducationalQualifications.js" type="text/javascript"></script>
</asp:Content>