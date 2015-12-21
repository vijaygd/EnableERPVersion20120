<%@ Page Title="Assigned List For Closed Employment Projects" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.ReportSection.AssignedListClosedEmploymentProject" Codebehind="AssignedListClosedEmploymentProject.aspx.cs" ClientIDMode="Static" %>

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
            <td>Assigned List For Closed Employment Projects</td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="skiplink">
        <tr>
            <td>
                <h1><span id="skipToTop" class="skiplink" style="color:White">Assigned List For Closed Employment Projects</span></h1>
            </td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td style="width:135px"><label for="ctl00_ContentPlaceHolder2_DdlVacancy">Vacancy :</label></td>
            <td>
                <select id="DdlVacancy" runat="server" class="mandatory" messagetext="Vacancy "
                onchange="javascript:DdlVacancy_SelectIndexChanged(this.value,'VacancyID','DdlEmploymentProject','DdlHiddenEmploymentProject');" />
            </td>
        </tr>
    </table>
       
    <table>
        <tr>
            <td id="TdEmploymentProject" style="width:135px">
                <label for="ctl00_ContentPlaceHolder2_DdlEmplymentProject">Employment Project :</label>
            </td>
            <td>
                <select id="DdlEmploymentProject" runat="server" class="mandatory" messagetext="Employment project"
                    onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHiddenEmploymentProject').val($('#ctl00_ContentPlaceHolder2_DdlEmploymentProject').val());" />
            </td>
            <td style="display:none">
                <label for="ctl00_ContentPlaceHolder2_DdlHiddenEmploymentProject">Hidden Employment Project</label>
                <select id="DdlHiddenEmploymentProject" runat="server" />
                <label for="ctl00_ContentPlaceHolder2_TxtHiddenEmploymentProject">Hidden Employment Project</label>
                <asp:TextBox ID="TxtHiddenEmploymentProject" runat="server" />
            </td>
        </tr>
     </table>
     
     <table>
        <tr>
            <td>
                <asp:Button ID="BtnGenerateReport" runat="server" Text="Generate" OnClientClick="javascript:return ValidateForm();" OnClick="BtnGenerateReport_Click" />
                 &nbsp;&nbsp;&nbsp;&nbsp;
               <asp:ImageButton runat="server" ID="ImageButton5" ImageUrl="~/App_Themes/Default/images/ExportToExcel.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="20"  Width="20px"
                 onclick="btnExportToExcel_Click" ToolTip="Export To Excel Directly"  />

            </td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td>
                <cc1:StiWebViewer ID="StiWebViewer1" runat="server" RenderMode="UseCache" ViewMode="WholeReport" Height="100%" />
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

    <script src="AssignedListClosedEmploymentProject.js" type="text/javascript"></script>
</asp:Content>

