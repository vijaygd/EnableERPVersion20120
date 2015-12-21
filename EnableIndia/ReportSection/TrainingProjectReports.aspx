<%@ Page Title=" Training Projects with Passed/Failed Status and Split-up by Disability" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.ReportSection.TrainingProjectReports" Codebehind="TrainingProjectReports.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>

<%@ Register Assembly="Stimulsoft.Report.Web, Version=2013.1.1600.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a"
    Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">Reports</td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0"  class="pageHeaderLevel1">
        <tr>
            <td>Training Projects with Passed/Failed Status and Split-up by Disability</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink">Training Projects</span></h1>
        </td>
    </tr>
</table>
    <table>
        <tr>
            <td style="width:125px"><label for="ctl00_ContentPlaceHolder2_DdlProjectType"> Project Type</label></td>
            <td>
                <select id="DdlProjectType" runat="server">
                    <option value="-1">All</option>
                    <option value="0">Open</option>
                    <option value="1">Closed</option>
                </select>
            </td>
        </tr>
     </table>
     <table>
    <tr>
        <td style="width:125px">
            <label for="ctl00_ContentPlaceHolder2_DdlSelectProgram">Select Program</label>
        </td>
        <td>
            <select id="DdlSelectProgram" runat="server" />
             
        </td>
    </tr>
</table>

    <table>
        <tr>
            <td>Select Date:</td>
            <td style="padding-left:30px"><label for="ctl00_ContentPlaceHolder2_DdlDateType">Type</label></td>
            <td>
                <select id="DdlDateType" runat="server">
                    <option value="start">Start</option>
                    <option value="end">End</option>
                    </select>
            </td>
            <td style="padding-left:30px"><label for="ctl00_ContentPlaceHolder2_TxtFromDate">From Date :</label> </td>
            <td>
                <asp:TextBox ID="TxtFromDate" runat="server" yearlength="4" />
                <asp:ImageButton runat="server" ID="ImageButton1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="ImageButton1" TargetControlID="TxtFromDate" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtFromDate"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                  (dd/mm/yyyy)
<%--                <cc1:MaskedEditValidator runat="server" ID="ttfdv" ControlExtender="ttfde" ControlToValidate="TxtFromDate" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="ttfde" TargetControlID="TxtFromDate" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>            </td>
            <td style="padding-left:30px"><label for="ctl00_ContentPlaceHolder2_TxtToDate">To Date :</label></td>
            <td>
                <asp:TextBox ID="TxtToDate" runat="server" yearlength="4"/>
                <asp:ImageButton runat="server" ID="ImageButton2" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender2" PopupButtonID="ImageButton2" TargetControlID="TxtToDate" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtToDate"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                  (dd/mm/yyyy)
<%--                <cc1:MaskedEditValidator runat="server" ID="tttdv" ControlExtender="tttde" ControlToValidate="TxtToDate" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tttde" TargetControlID="TxtToDate" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>
            </td>
        </tr>
      </table>
      <table>
        <tr>
            <td style="width:125px">
                <label for="ctl00_ContentPlaceHolder2_DdlManagedByEmployee">Select Managed By</label>
            </td>
            <td>
                <select id="DdlManagedByEmployee" runat="server" />
                  
            </td>
        </tr>
    </table>
    <table>
    <tr>
        <td style="width:200px">
           <label for="ctl00_ContentPlaceHolder2_DdlCompanies">Credited To:</label>
        </td>
        <td>
            <telerik:RadComboBox runat="server" ID="DdlCompanies" CssClass="mandatory" CheckBoxes="false" BorderColor="#5E80FD" BorderWidth="2px" OnClientLoad="comboLoad"></telerik:RadComboBox>
        </td>
    </tr>
</table>

      <table>
        <tr>
            <td>
                <asp:Button ID="BtnGenerateReport" runat="server" 
                    OnClientClick="javascript:return GoSearchParameter();"
                    OnClick="BtnGenerateReport_Click" Text="Generate" />
                &nbsp;&nbsp;
                <asp:ImageButton runat="server" ID="ImageButton3" ImageUrl="~/App_Themes/Default/images/ExportToExcel.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="20"  Width="20px"
                 onclick="btnExportToExcel_Click" ToolTip="Export To Excel Directly"  />
            </td>
        </tr>
    </table>
   <%-- <table>
        <tr>
            <td>
               Open <span id="Span1" runat="server"></span>
               closed <span id="Span2" runat="server"></span>
               paassed <span id="Span3" runat="server"></span>
                failed<span id="Span4" runat="server"></span>
            </td>
        </tr>
    </table>--%>
    <table >
        <tr>
            <td>
                <%--<cc1:StiWebViewer ID="StiWebViewer1" runat="server" RenderMode="UseCache" ViewMode="WholeReport"
                    PageBorderSize="0" CacheMode="Page" height="100%" Width="900px"
                    ScrollBarsMode="true"  />--%>
                     <cc1:StiWebViewer ID="StiWebViewer1" runat="server"  RenderMode="UseCache" ViewMode="WholeReport"
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

    <script src="TrainingProjectReports.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function(){
            $("#ctl00_ContentPlaceHolder2_StiWebViewer1").css("padding-bottom","35px");
            $("#iframe table tr td[height=140px]").attr("height","0px");
        });
        function comboLoad(sender) {
            var item = sender.get_items().getItem(0);
            checkBoxElement = item.get_checkBoxElement();
            itemParent = checkBoxElement.parentNode;
            itemParent.removeChild(checkBoxElement);
        }

    </script>
</asp:Content>
