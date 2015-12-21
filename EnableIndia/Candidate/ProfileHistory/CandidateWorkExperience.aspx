<%@ Page Title="Work Experience" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" EnableEventValidation="false" Inherits="EnableIndia.Candidate.ProfileHistory.CandidateWorkExperience" Codebehind="CandidateWorkExperience.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>
<%@ MasterType VirtualPath="~/Candidate/Candidate.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td class="pageHeader">
            Candidate Section
        </td>
    </tr>
</table>    
 <table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">
    <tr>
        <td>Profile and History > Work Experience</td>
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
                PostBackUrl="~/Candidate/ProfileHistory/EducationalQualifications.aspx" CssClass="tab_links" />
        </td>
        
        <td style="padding-left:12px" align="center">Work Experience</td>
        
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
            <h1><span id="skipToTop" class="skiplink">Work Experience</span></h1>
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
                <span id="SpnStatus" runat="server" class="readonlyText"></span>&nbsp;&nbsp;
                <asp:Label CssClass="labelStyle" runat="server" ID="lbEmpStatus" ForeColor="#d32232" Font-Bold="true" Font-Names="Consolas" Font-Size="12px"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel runat="server" ID="panListView" Height="460px" Width="100%" ScrollBars="Auto">
<table cellpadding="4">
    <tr>
        <td>
            <table>
                <tr>
                    <td>
                        <asp:ListView ID="LstViewExistingWorkExperience" runat="server" >
                            <LayoutTemplate>
                                <table style="margin-bottom:5px">
                                    <tr>
                                        <td style="font-weight:bold">Existing Work Experience:</td>
                                    </tr>
                                </table>
                                <table id="TblExistingWorkExperience" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" style="border-color:#000000;"
                                      border="1" >
                                   <thead>
                                        <tr class="grid-header">
                                           <%--<th></th>--%>
                                           <th align="right">No.</th>
                                           <th>Parent Company</th>
                                           <th>Employment Project Name</th> 
                                           <th>Company</th> 
                                           <th>Role</th> 
                                           <th>Designation</th> 
                                           <th>From (MM/YYYY)</th> 
                                           <th>To (MM/YYYY)</th> 
                                           <th>Years</th> 
                                           <th>Monthly Salary<br />(Rs)</th> 
                                        </tr>
                                   </thead>
                                   <tbody>
                                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                   </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                   <td id="TdRecordNumber" align="right">
                                        <asp:LinkButton ID="LnkBtnDesignation" runat="server" Text="" CssClass="readonlyText"
                                            WorkExperienceID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("candidate_work_experience_id"))) %>'
                                            OnClick="LnkBtnDesignation_Click" />
                                   </td>
                                   <th align="left" style="font-weight:normal"><%#Eval("parent_company")%></th> 
                                   <td align="left"><%#Eval("employment_project_name")%></td>
                                   <td align="left"><%#Eval("company")%></td> 
                                   <td align="left"><%#Eval("job_role")%></td> 
                                   <td align="left"><%#Eval("designation") %></td> 
                                   <td runat="server" id="stDate" align="left"><%#Convert.ToDateTime(Eval("designation_from_date")).ToString("MM/yyyy")%></td> 
                                   <td runat="server" id="edDate" align="left"><%#Eval("str_to_date")%></td> 
                                   <td align="right"><%#Eval("experience_years")%></td> 
                                   <td align="right"><%#Eval("str_monthly_salary")%></td> 
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td>
                          For candidate on job contract, contract expiry date:
                    </td>
                    <td>
                         <span id="SpnContractExpiryDate" runat="server" class="readonlyText"></span>
                    </td>
                </tr>
            </table>
            <table id="tbButtons">
                <tr>
                    <td>
                        <%--<asp:Button ID ="BtnAddWorkExperience" runat="server" text="Add Work Experience" 
                         OnClientClick="javascript:ShowWorkExperiencePopUp(-1,'');"
                         OnClick="BtnAddWorkExperience_Click"/>--%>
                           <asp:Button ID ="BtnAddWorkExperience" runat="server" text="Add Work Experience" 
                         OnClick="BtnAddWorkExperience_Click"/>
                    </td>
                    <td>
                    <asp:TextBox runat="server" ID="TxtReturnValue" ClientIDMode="Static" style="display:none"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
<div>
 <center>
<%--<asp:UpdatePanel runat="server" ID="updatePanelrad">
--%>        <telerik:RadWindowManager runat="server" ID="radManager" EnableViewState="false" DestroyOnClose="true" VisibleOnPageLoad="false"  AutoSize="true" Top="0"  Height="680px" Width="900px" Modal="true" CssClass="RadWindow" ClientIDMode="Static">
        </telerik:RadWindowManager>
<%-- </asp:UpdatePanel>
--%> </center>
 </div>

<%--<asp:Panel runat="server" ID="pnWorkExperience" Height="260px" Width="100%" ScrollBars="None">
  <iframe runat="server" id="pnWk" width="100%" height="100%" scrolling="auto">
  </iframe>
</asp:Panel>--%>

<asp:HiddenField ID="pHidden" runat="server" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="false">
    <ContentTemplate>
        <asp:Button ID="BtnTarget" runat="server" Text="No" Style="display: none" />
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="BtnTarget"
            PopupControlID="Panel1">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="Panel1" runat="server" BackColor="Snow" Width="380px" Height="180px">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional" Visible="false">
                <ContentTemplate>
                    <table style="width:380px; height:200px; border:1px; border-bottom-style:solid; border-bottom-color:Blue; border-left-style:solid; border-left-color:Blue; border-right-style:solid; border-right-color:Blue; border-top-style:solid; border-top-color:Blue;">
                    <tr>
                        <td valign="middle" align="left" style="border:1; border-bottom-style:solid; border-bottom-color:Blue; border-bottom-width:80%;">
                            <asp:Label CssClass="labelStyle" runat="server" ID="lbt" Text="Warning" Font-Bold="true" Font-Size="Medium" Font-Names="Consolas"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                       <td valign="middle"  align="center">
                             <asp:Label CssClass="labelStyle" runat="server" ID="lbEmpstat" Text="This candidate is already employed in company, do you want to make him unemployed?" Font-Bold="true" Font-Names="Consolas" Font-Size="Small"></asp:Label>
                       </td>
                    </tr>
                    <tr>
                    <td valign="middle" align="center">
                    <asp:Button ID="Btnshow" runat="server" Text="Yes" OnClientClick="javascript:return wk1();" OnClick="btnYesClicked" />&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnHide" runat="server" Text="No"  OnClick="btnNoClicked" />
                    </td>
                    </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="BtnHide" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
    </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Btnshow" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>

<div runat="server" id="divId">
<asp:HiddenField ID="candId" runat="server" />
<asp:HiddenField ID="wkExp" runat="server" />
<asp:HiddenField runat="server" ID="txtParent" ClientIDMode="Static" />

<script language="javascript" type="text/javascript">
    function wk1() {
        var cid = document.getElementById('<%= this.candId.ClientID %>');
        var wid = document.getElementById('<%= this.wkExp.ClientID %>');

        var url = "../WorkExperiencePopup.aspx?cand=" + cid.value + "&work_exp=" + wid.value + "&txboxId=" + self.parent.location + "&rowId=-1" + "&EnbRb=1";
        //  ShowPopUp(url, 880, 350);
        //        document.getElementById("pnWk").src = url;
        openRadWindow(url);
    }
    function wk2() {
    //    ShowWorkExperiencePopUp(-1, '')
        //    displayWorkExperience(-1, '');
        var cid = document.getElementById('<%= this.candId.ClientID %>');
        var url = "../WorkExperiencePopup.aspx" + "?txboxId=" + self.parent.location + "&cand=" + cid.value + "&rowId=-1";
        openRadWindow(url);
//        document.getElementById("pnWk").src = url;

    }
    function openRadWindow(url) {
        var rWindow = document.getElementById("radManager");
        window.radopen(url, "Work Experience");
        return false;

    }
    function parentFunc()
    {
        var x = document.getElementById("txtParent").value;
        __doPostBack(x);
    }
    function displayWorkExperience(strWorkExperienceID,strLinkButtonID) {
        var cid = document.getElementById('<%= this.candId.ClientID %>');
        var wid = document.getElementById('<%= this.wkExp.ClientID %>');
    
    var url="../WorkExperiencePopup.aspx?cand=" + cid.value;
    
    if(strWorkExperienceID!="-1"){
        url+= "&work_exp=" + document.getElementById("#TblExistingWorkExperience").attributes("WorkExperienceID"); // #" + strLinkButtonID).attr("WorkExperienceID");
    }
    var x = document.getElementById('<%= this.txtParent.ClientID %>');
//    url += "&txboxId=" + self.parent.location; //     "<%= this.txtParent.ClientID %>"
//    var rWindow = document.getElementById("radManager");
//    rWindow.show(url);
//    return false;
    //    ShowPopUp(url,880,350);
    //window.showModalDialog(url, window.self);
    
    }
</script>
</div>
<script src="../../Scripts/jquery-1.7.1-vsdoc.js" type="text/javascript"></script>
<script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="../../Scripts/Common.js" type="text/jscript"></script>
<script src="CandidateWorkExperience.js" type="text/javascript"></script>
</asp:Content>
