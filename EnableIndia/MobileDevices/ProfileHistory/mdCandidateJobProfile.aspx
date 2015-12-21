<%@ Page Title="" Language="C#" MasterPageFile="~/MobileDevices/mobileMaster.Master" AutoEventWireup="true" CodeBehind="mdCandidateJobProfile.aspx.cs" Inherits="EnableIndia.MobileDevices.ProfileHistory.mdCandidateJobProfile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" lang="javascript">
    function CloseWindow(sender, eventArgs) {
        if ((sender != null) && (sender != undefined)) {
            if ((eventArgs != null) && (eventArgs != undefined)) {
                if (eventArgs._argument) {
                    window.alert(eventArgs._argument);
                    var hField = document.getElementById("hField");
                    hField.value = "1";
                    __doPostBack();
                }
            }
        }
    }
</script>
   <table style="border-collapse:separate; border-spacing:2px;">
    <tr>
        <td style="text-align:center;">
            <asp:LinkButton ID="LnkBtnRegistration" runat="server" Text="Registration"
                PostBackUrl="~/MobileDevices/ProfileHistory/mdRegistration.aspx" CssClass="tab_links" />
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
        <td style="padding-left:12px; text-align:center;">Job Profiling</td>
        <td style="padding-left:12px; text-align:center;">
            <asp:LinkButton ID="LnkButtonCandidateHistory" runat="server" Text="Candidate History" CssClass="tab_links" 
            PostBackUrl="~/MobileDevices/ProfileHistory/mdAddViewCandidateHistory.aspx" />
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
    
    <table>
        <tr>
            <td>
                <asp:UpdatePanel runat="server" ID="updJobRoles" UpdateMode="Conditional">
                    <ContentTemplate>

                <asp:ListView ID="LstViewJobRoles" runat="server" >
                    <LayoutTemplate>
                        Recommended Job Types and Recommended Roles
                        <table id="TblJobRoles" class="tableBorder"  rules="all" 
                            style="margin-top:5px; border-color:#808080; border-width:1px; border-collapse:separate; border-spacing:0px; border-width:4px;">
                            <thead>
                                <tr class="grid-header">
                                    <th style="text-align:right;">No.</th>
                                    <th>Recommended Job Types </th>
                                    <th>Recommended Roles</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td id="TdRecordNumber"  style="text-align:right;">
                               <asp:LinkButton ID="LnkJobRoles" runat="server" CssClass="readonlyText"
                                    JobID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("job_id"))) %>'
                                    OnClick="BtnRecommndedJobType_ClickLb" />
                            </td>
                            <td><%#Eval("recommended_job_name")%></td>
                            <td><%#Eval("recommended_job_roles")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td>
                
                <asp:Button id="BtnRecommndedJobType" runat="server" Text="Add Recommended Job Type and Role" 
                    OnClick="BtnRecommndedJobType_ClickBtn" />
            </td>
        </tr>
    </table>
    
<table style="margin-top:10px">
    <tr>
        <td>
            Number of days candidate has had ‘unemployed’ status: <span id="SpnUnemployedFromDays" runat="server" class="readonlyText" /> <span id="SpnDays" runat="server" class="readonlyText">days</span>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td><label for="ctl00_ContentPlaceHolder2_TxtPrefferedJob">Preferred Job By Candidates</label></td>
        <td><asp:TextBox ID="TxtPrefferedJob" runat="server" /></td>
        <td style="padding-left:40px"><label for="ctl00_ContentPlaceHolder2_TxtPreferredLocation">Preferred Location</label></td>
        <td><asp:TextBox ID="TxtPreferredLocation" runat="server" /></td>
    </tr>
</table>
<table>
    <tr>
        <td><label for="ctl00_ContentPlaceHolder2_DdlExpectedSalary">Expected Monthly Salary Rs.</label></td>
        <td>
            <select id="DdlExpectedSalary" runat="server" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:156px; vertical-align:middle;">
            <label for="ctl00_ContentPlaceHolder2_TxtEvaluatorComments">Evaluator Comments</label></td>
        <td>
            <asp:TextBox ID="TxtEvaluatorComments" runat="server" TextMode="MultiLine" Height="100px" Width="700px" />    
        </td>
    </tr>
</table>
<br />
<h2>Assign Candidates to Groups</h2>
<table style="border-collapse:separate; border-spacing:0px; border-width:0px;">
    <tr>
        <td>
            All Groups<br />
            <asp:ListView ID="LstViewCandidateGroups" runat="server" OnItemDataBound="LstViewCandidateGroups_ItemDataBound">
                <LayoutTemplate>
                    <table id="TblCandidateGroups" class="checkedListBox">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <table style="border-collapse:separate; border-spacing:0px; border-width:0px;">
                        <tr>
                            <td id="textField"><%#Eval("group_name") %></td>
                            <td>
                                <asp:CheckBox ID="ChkSelectGroup" runat="server" 
                                    CandidateGroupID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("group_id"))) %>'
                                    Checked='<%# Convert.ToBoolean(Eval("is_attached")) %>' />
                                <label id="LblGroupname" runat="server" class="skiplink" >test</label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
             </asp:ListView>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
             <label for="ctl00_ContentPlaceHolder2_ChkMakeCandidateInactive">Make a Candidate Inactive</label>
        </td>
        <td>
            <asp:CheckBox ID="ChkMakeCandidateInactive" runat="server" onclick="javascript:return CheckCandidateInactive();" />
        </td>
        
        <td style="padding-left:60px">
            <label for="ctl00_ContentPlaceHolder2_TxtCandidateInactiveReason">Reason</label>
            <asp:TextBox ID="TxtCandidateInactiveReason" runat="server" />
        </td>
        <td></td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_ChkPriorityCandidate">Make as Priority Candidate</label>
        </td>
        <td>
            <asp:CheckBox ID="ChkPriorityCandidate" runat="server" />
        </td>
        
        <td style="padding-left:60px; text-align:left;">
            <label for="ctl00_ContentPlaceHolder2_TxtPriorityCandidateReason" >Reason</label>
            <asp:TextBox ID="TxtPriorityCandidateReason" runat="server" /><br />
        </td>
        <td></td>
    </tr>
</table>


<table>
    <tr>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder2_ChkNeedyCandidate">Mark as Needy Candidate</label>
        </td>
        <td>
            <asp:CheckBox ID="ChkNeedyCandidate" runat="server" />
        </td>
        <td style="padding-left:60px">
            <label for="ctl00_ContentPlaceHolder2_TxtNeedyCandidateReason"> Reason</label>
            <asp:TextBox ID="TxtNeedyCandidateReason" runat="server" />
        </td>
        <td> </td>
    </tr>
</table>
Employment project to which candidate is currently assigned to: 
<div  style="margin:4px;">
             <asp:ListView ID="LstViewVacancy" runat="server">
                <LayoutTemplate>
                     <table class="tableBorder" rules="all"  style="border-collapse:separate; border-spacing:0px; border-width:4px;">
                           <thead>
                                <tr class="grid-header">
                                    <th>Parent Company</th>
                                    <th>Employment Project</th>
                                    <th>Job Type</th>
                                    <th>Role</th>
                                </tr>
                          </thead>
                         <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                         </tbody>
                     </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("company_name")%>
                        </td>
                        <td>
                            <%# Eval("employment_project_name")%>
                        </td>
                        <td>
                            <%# Eval("job_name")%>
                        </td>
                        <td>
                            <%# Eval("job_role_name")%>    
                        </td>
                    </tr>
                </ItemTemplate>    
          </asp:ListView>
</div>
<div style="text-align:left; width:100%;float:left; margin-left:300px;">
            <asp:Button ID="BtnManageCandidateJobProfile" runat="server" Text="Submit" 
                    OpenTask="0"
                    OpenTraningProject="0"
                    OpenEmpProject="0"
                    OnClientClick="javascript:return ValidateOpenTask();"
                    OnClick="BtnManageCandidateJobProfile_Click" />
            <asp:HiddenField runat="server" ID="hField" />

</div>
<div>
     <div style="width:990px; height:650px;">
        <telerik:RadWindowManager runat="server" ID="radManager" EnableViewState="false"  DestroyOnClose="true" VisibleOnPageLoad="false"  AutoSize="true" Top="0"  Height="680px" Width="900px" Modal="true" CssClass="modalPopup_rad"  >
           <Windows>
             <telerik:RadWindow runat="server" ID="RadWindow" Height="680px" Width="900px" OnClientShow="setShowAttr" OnClientClose="CloseWindow">
             </telerik:RadWindow>
           </Windows>
        </telerik:RadWindowManager>
     </div>
 </div>
<script src="../../Scripts/jquery-1.7.1-vsdoc.js" type="text/javascript"></script>
<script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="../../Scripts/Common.js" type="text/jscript"></script>
<script src="mdCandidateJobProfile.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function ShowKnowlegeTrainingPopup(strContactID, strLinkButtonID) {
        var candidateID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.length);
        var url = "Recommended JobType.aspx?cand=" + candidateID;
        if (strContactID != "-1") {
            url += "&job=" + strContactID;
        }
        url += "&txboxId=" + self.parent.location;
        ShowPopUp(url, 500, 400);
    }
    function setShowAttr(radWindow) {
        var delScrollbar = radWindow._name;
        document.getElementsByName(delScrollbar)[0].setAttribute("scrolling", "yes");
        var oTop = document.documentElement.scrollTop;
        document.documentElement.scroll = "yes";
        document.documentElement.style.overflow = "scroll";
        document.documentElement.scrollTop = oTop;

        if (document.documentElement && document.documentElement.scrollTop) {
            var oTop = document.documentElement.scrollTop;
            document.documentElement.scroll = "yes";
            document.documentElement.style.overflow = "scroll";
            document.documentElement.scrollTop = oTop;
        }

        else if (document.body) {
            var oTop = document.body.scrollTop;
            document.body.scroll = "yes";
            document.body.style.overflow = "scroll";
            document.body.scrollTop = oTop;
        }
    }
</script>
</asp:Content>
