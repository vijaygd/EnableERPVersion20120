<%@ Page Title="Candidate Wise Training And Employment Relation" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.ReportSection.CandidateWiseTrainingEmploymentRelation" Codebehind="CandidateWiseTrainingEmploymentRelation.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="Stimulsoft.Report.Web, Version=2013.1.1600.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a"
    Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">Reports</td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">
        <tr>
            <td>Candidate Wise Training And Employment Relation</td>
        </tr>
    </table>
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="skiplink">
        <tr>
            <td>
                <h1><span id="skipToTop" class="skiplink" style="color:White">Candidate Wise Training And Employment Relation</span></h1>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlProfilingStatus">Profiling Status :</label></td>
            <td>
                <select id="DdlProfilingStatus" runat="server">
                    <option value="All">All</option>
                    <option value="To be Profiled">To be Profiled</option>
                    <option value="Profiled">Profiled</option>
                </select>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlTypeOfCandidate">Type of Candidate :</label></td> 
            <td>
                <select id="DdlTypeOfCandidate" runat="server">
                    <option value="-1">All</option>
                    <option value="1">Employed</option>
                    <option value="2">Unemployed</option>
                </select>
            </td>           
        </tr>
    </table>
        <table>
        <tr>
            <td style="width:135px">
                <label for="ctl00_ContentPlaceHolder2_DdlPrograms">Training Program</label>
            </td>
            <td>
                <select id="DdlPrograms" runat="server" 
                    onchange="javascript:DdlPrograms_SelectIndexChanged(this.value,'TrainingProgramID','DdlProjects','DdlHiddenProjects');" />
            </td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td style="width:135px">
                <label for="ctl00_ContentPlaceHolder2_DdlProjects">Training Project</label>
            </td>
            <td>
                <select id="DdlProjects" runat="server"  
                        onchange="javascript:$('#TxtHiddenProjects').val($('#DdlProjects').val());" />
            </td>
            <td style="display:none">
                <label for="ctl00_ContentPlaceHolder2_DdlHiddenProjects">Hidden</label>
                <select id="DdlHiddenProjects" runat="server"/>
                <label for="ctl00_ContentPlaceHolder2_TxtHiddenProjects">Hidden</label>
                <asp:TextBox ID="TxtHiddenProjects" runat="server" />
                <span id="SpnHiddenProjects" runat="server"></span>
            </td>
        </tr>
    </table>

   <%-- <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlTrainingDone">Training Passed :</label></td>             
            <td>
                <select id="DdlTrainingDone" runat="server" />
            </td>
        </tr>
    </table>--%>
    <table>
        <tr>
            <td style="width:135px">Training Dates :</td>             
            <td><label for="ctl00_ContentPlaceHolder2_DdlDateType">Type :</label></td>
            <td>
                <select id="DdlDateType" runat="server">
                    <option value="Start">Start</option>
                    <option value="End">End</option>
                </select>
            </td>
            <td><label for="ctl00_ContentPlaceHolder2_TxtTrainingFromDate">From :</label></td>
            <td>
                <asp:TextBox ID="TxtTrainingFromDate" runat="server" yearlength="4" />
                <asp:ImageButton runat="server" ID="Image2" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender2" PopupButtonID="Image2" TargetControlID="TxtTrainingFromDate" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtTrainingFromDate"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                (dd/mm/yyyy)
<%--                <cc1:MaskedEditValidator runat="server" ID="ttfdv" ControlExtender="ttfde" ControlToValidate="TxtTrainingFromDate" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="ttfde" TargetControlID="TxtTrainingFromDate" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>           </td>
            <td><label for="ctl00_ContentPlaceHolder2_TxtTrainingToDate">To :</label></td>
            <td>
                <asp:TextBox ID="TxtTrainingToDate" runat="server" yearlength="4" />
                 <asp:ImageButton runat="server" ID="ImageButton1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                 <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="ImageButton1" TargetControlID="TxtTrainingToDate" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtTrainingToDate"
                 ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                 runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                (dd/mm/yyyy)
<%--                <cc1:MaskedEditValidator runat="server" ID="tttdv" ControlExtender="tttde" ControlToValidate="TxtTrainingToDate" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tttde" TargetControlID="TxtTrainingToDate" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px">Employment Start Date in Current Company :</td>             
            <td>From :</td>
            <td>
                <asp:TextBox ID="TxtEmploymentFromDate" runat="server" yearlength="4" />
                <br />
                (mm/yyyy)
<%--                <cc1:MaskedEditValidator runat="server" ID="tbEmpDtfv" ControlExtender="tbEmpDtfe" ControlToValidate="TxtEmploymentFromDate" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tbEmpDtfe" TargetControlID="TxtEmploymentFromDate" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>          </td>
            <td> <label for="ctl00_ContentPlaceHolder2_TxtEmploymentFromDate" class="skiplink">Employment Start Date in Current Company : From</label></td>
            <td><label for="ctl00_ContentPlaceHolder2_TxtEmploymentToDate">To :</label></td>
            <td>
                <asp:TextBox ID="TxtEmploymentToDate" runat="server" yearlength="4" />
                <br />
                (mm/yyyy)
<%--                <cc1:MaskedEditValidator runat="server" ID="tbEmpDttv" ControlExtender="tbEmpDtte" ControlToValidate="TxtEmploymentToDate" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tbEmpDtte" TargetControlID="TxtEmploymentToDate" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlRecommendedJobType">Recommended Job Type :</label></td>
            <td>
                <select id="DdlRecommendedJobType" runat="server" 
                onchange="javascript:DdlRecommendedJobType_SelectIndexChanged(this.value,'JobID','DdlRecommendedRole','DdlHiddenRecommendedRole');" />
            </td>
             <td id="TdRecomendedRole" style="width:150px;padding-left:30px">
                <label for="ctl00_ContentPlaceHolder2_DdlRecommendedRole">Recommended Role :</label>
            </td>
            <td>
            <select id="DdlRecommendedRole" runat="server"
                onchange="javascript:$('#TxtHiddenRecommendedRole').val($('#DdlRecommendedRole').val());" />
            </td>
            <td  style="display:none" >
                <label for="ctl00_ContentPlaceHolder2_DdlHiddenRecommendedRole">Hidden Rcommeded role</label>
                <select id="DdlHiddenRecommendedRole" runat="server"/>
                <label for="ctl00_ContentPlaceHolder2_TxtHiddenRecommendedRole">Hidden Rcommeded role</label>
                <asp:TextBox ID="TxtHiddenRecommendedRole" runat="server" />
                <span id="SpnHiddenRecommendedRole" runat="server"></span>
            </td>
        </tr>
     </table>
     <table>
        <tr>
            <td style="width:135px;"><label for="ctl00_ContentPlaceHolder2_DdlDisabilityTypes">Disability :</label></td>
            <td>
                <select id="DdlDisabilityTypes" runat="server" />
            </td>
        </tr>
     </table>
     <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlGroups">Groups :</label></td>
            <td>
                <select id="DdlGroups" runat="server" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlQualifications">Qualifications :</label></td>
            <td>
                <select id="DdlQualifications" runat="server" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlRecommendedTraining">Recommended Training </label></td>
            <td>
                <select id="DdlRecommendedTraining" runat="server" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlRecommendedTrainingNotDone">Recommended Training not Passed :</label></td>
            <td>
                <select id="DdlRecommendedTrainingNotDone" runat="server" />
            </td>
        </tr>
    </table>
    
    <table group="SearchParameters">
        <tr>
            <td style="width:135px">
                <label for="ctl00_ContentPlaceHolder2_TxtSearchFor">Search for</label>
            </td>
            <td style="padding-right:30px">
                <asp:TextBox ID="TxtSearchFor" runat="server" Width="200px" ToolTip="Search For" />
            </td>
            <td>
                <label for="ctl00_ContentPlaceHolder2_DdlSearchIn">in</label>
            </td>
            <td>
                <select id="DdlSearchIn" runat="server" title="Serach In">
                    <option value="name">Name</option>
                    <option value="registration_id">RID</option>
                </select>
            </td>
        </tr>
    </table> 
    
         
    <table>
        <tr>
            <td>
                <asp:Button ID="BtnGenerateReport" runat="server" Text="Generate" 
                     OnClientClick="javascript:return GoSearchParameter();" OnClick="BtnGenerateReport_Click" />&nbsp;&nbsp;
             <asp:ImageButton runat="server" ID="ImageButton3" ImageUrl="~/App_Themes/Default/images/ExportToExcel.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="20"  Width="20px"
                 onclick="btnExportToExcel_Click" ToolTip="Export To Excel Directly"  />&nbsp;

            </td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td>
                <cc1:StiWebViewer ID="StiWebViewer1" runat="server" RenderMode="Standard" ViewMode="WholeReport"
                   Height="100%" />
            </td>
        </tr>
    </table>
        <div id="divforScript" class="load">
         <table width="500px" style="height:100px; border-bottom-color:Blue; border-bottom-style: solid; border-top-color: Blue; border-top-style: solid; border-width:1; background-color:White;">
         <tr>
            <td valign="middle" align="center" style="width:500px;">
                                  <asp:Image runat="server" ID="imbPb" AlternateText="...Wait..." ImageUrl="~/Image/ajax-loader.gif" Width="30px" Height="30px" />
                              </td>
                             </tr>
                            <tr>
                               <td valign="middle" align="center" style="width:500px;">
                                 <asp:Label CssClass="labelStyle" runat="server" ID="lbWaitState" Text="-: Please Wait - Report Generation under progress : -" Font-Bold="true" Font-Size="10" ForeColor="#D32232"></asp:Label>
                               </td>
                           </tr>
                         </table>

    </div>
    <script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="CandidateWiseTrainingEmploymentRelation.js" type="text/javascript"></script>
</asp:Content>

