<%@ Page Title="Rejection Data For Candidates" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.ReportSection.RejectionDataForCandidates" Codebehind="RejectionDataForCandidates.aspx.cs" ClientIDMode="Static" %>

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
            <td>Rejection Data For Candidates</td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="skiplink">
        <tr>
            <td>
                <h1><span id="skipToTop" class="skiplink" style="color:White">Rejection Data For Candidates</span></h1>
            </td>
        </tr>
    </table>

    <table>
        <tr>
            <td style="width:135px;"><label for="ctl00_ContentPlaceHolder2_TxtSearchForCandidate">Search For Candidate</label></td>
            <td><asp:TextBox ID="TxtSearchForCandidate" runat="server" /></td>
            <td style="padding-left:30px"><label for="ctl00_ContentPlaceHolder2_DdlSearch">in</label></td>
            <td style="padding-left:5px">
                <select id="DdlSearch" runat="server" title="Search In">
                    <option value="registration_id">RID</option>
                    <option value="name">Name</option>
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
                <select id="DdlPrograms" runat="server" class="mandatory" messagetext="Training program"
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
                <select id="DdlProjects" runat="server" class="mandatory" messagetext="Training project"
                    onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHiddenProjects').val($('#ctl00_ContentPlaceHolder2_DdlProjects').val());" />
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
    
    <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlEmploymentProject">Employment Project</label></td>
            <td>
                <select ID="DdlEmploymentProject" runat="server"/>
            </td>
        </tr>
    </table> 
    
    <table>
        <tr>
            <td>
                <asp:Button ID="BtnGenerateReport" runat="server" 
                    OnClientClick="javascript:return ValidateForm();" OnClick="BtnGenerateReport_Click" Text="Generate" />&nbsp;&nbsp;
                <asp:ImageButton runat="server" ID="ImageButton5" ImageUrl="~/App_Themes/Default/images/ExportToExcel.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="20"  Width="20px"
                 onclick="btnExportToExcel_Click" ToolTip="Export To Excel Directly"  />

            </td>
        </tr>
    </table>
    
    <table >
        <tr>
            <td>
                 <cc1:StiWebViewer ID="StiWebViewer1" runat="server"  RenderMode="UseCache" ViewMode="WholeReport"
                    Height="100%"/>
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

    <script language="javascript" type="text/javascript">
        $(document).ready(function(){
            $("#ctl00_ContentPlaceHolder2_StiWebViewer1").css("padding-bottom","35px");
            $("#iframe table tr td[height=140px]").attr("height","0px");
        });
    </script>
    <script src="RejectionDataForCandidates.js" type="text/javascript"></script>
</asp:Content>

