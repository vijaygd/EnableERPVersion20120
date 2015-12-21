<%@ Page Title="Candidate Tasks" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.ReportSection.CandidateTask" Codebehind="CandidateTask.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
            <td>Candidate Tasks</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink"> Candidate Tasks</span></h1>
        </td>
    </tr>
</table>
    <table>
        <tr>
            <td style="width:103px">Task Type :</td>
            <td>
                <select id="DdlTaskType" runat="server">
                    <option value="Open">Open</option>
                    <option value="Closed">Closed</option>
                </select>
            </td>
        </tr>
        </table>
        
    <table>
        <tr>
            <td style="width:103px">Disability Types :</td>
            <td>
                <asp:DropDownList ID="DdlDisabilityTypes" runat="server" />
            </td>
            <td>
            <label for="ctl00_ContentPlaceHolder2_DdlEmployee" class="skiplink">Select Disability Types </label>
            </td>
        
        </tr>
     </table>
     <table>
            <tr>
                <td style="width:103px">Flag :</td>
                <td><select id="DdlFlags" runat="server" ></select></td>
                <td><label for="ctl00_ContentPlaceHolder2_DdlFlags" class="skiplink">Select Flag</label></td>
            </tr>
        </table>
        <table >
            <tr>
                <td style="width:103px">Managed By :
                </td>
                <td><select id="DdlEmployee" runat="server"></select>
                </td>
                <td><label for="ctl00_ContentPlaceHolder2_DdlEmployee" class="skiplink">Select Managed by </label></td>
            </tr>
        </table>
        <table>
        <tr>
            <td style="width:80px">Select Date:</td>
            <td style="padding-left:10px"><label for="ctl00_ContentPlaceHolder2_DdlDateType">Type</label></td>
            <td>
                <select id="DdlDateType" runat="server">
                    <option value="Creation">Creation</option>
                    <option value="Follow_up_date">Follow up date</option>
                     <option value="Closed">Closure</option>
                    </select>
            </td>
            <td style="padding-left:30px"><label for="ctl00_ContentPlaceHolder2_TxtFromDate">From Date :</label> </td>
            <td>
                <asp:TextBox ID="TxtFromDate" runat="server" yearlength="4"  />
                <asp:ImageButton runat="server" ID="ImageButton1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="ImageButton1" TargetControlID="TxtFromDate" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtFromDate"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                (dd/mm/yyyy)
                
<%--                <cc1:MaskedEditValidator runat="server" ID="tfdv" ControlExtender="tfde" ControlToValidate="TxtFromDate" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="tfde" TargetControlID="TxtFromDate" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>            </td>
            <td style="padding-left:30px"><label for="ctl00_ContentPlaceHolder2_TxtToDate">To Date :</label></td>
            <td>
                <asp:TextBox ID="TxtToDate" runat="server" yearlength="4"  />
                <asp:ImageButton runat="server" ID="ImageButton2" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
                <cc1:CalendarExtender runat="server" ID="CalendarExtender2" PopupButtonID="ImageButton2" TargetControlID="TxtToDate" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtToDate"
                ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
                runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
                <br />
                (dd/mm/yyyy)
                
<%--                <cc1:MaskedEditValidator runat="server" ID="ttdv" ControlExtender="ttde" ControlToValidate="TxtToDate" ValidationExpression="^\d{2}/\d{2}/\d{4}$"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender  runat="server" ID="ttde" TargetControlID="TxtToDate" ClearMaskOnLostFocus="True" Enabled="True" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender>
--%>            </td>
        </tr>
      </table>
      <table>
                <tr>
                    <td style="width:83px">Search For</td>
                    <td>
                        <asp:TextBox ID="TxtSearchFor" runat="server" />
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_TxtSearchFor" class="skiplink">Search for</label></td>
                    <td style="padding-left:10px;padding-right:10px">in</td>
                    <td>
                        <select id="DdlSearchIn" runat="server">
                            <option value="registration_id">RID</option>
                            <option value="name">Name</option>
                        </select>
                    </td>
                    <td><label for="ctl00_ContentPlaceHolder2_DdlSearchIn" class="skiplink">Search in</label></td>
                </tr>
            </table>
      <table>
        <tr>
            <td>
                <asp:Button ID="BtnGenerateReport" runat="server" 
                    OnClientClick="javascript:return GoSearchParameter();"
                    OnClick="BtnGenerateReport_Click" Text="Generate" />&nbsp;&nbsp;
               <asp:ImageButton runat="server" ID="ImageButton3" ImageUrl="~/App_Themes/Default/images/ExportToExcel.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="20"  Width="20px"
                 onclick="btnExportToExcel_Click" ToolTip="Export To Excel Directly"  />&nbsp;

            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <%--<cc1:StiWebViewer ID="StiWebViewer1" runat="server" RenderMode="UseCache" ViewMode="WholeReport"
                    Height="800px" Width="1400px"  ScrollBarsMode="true" />--%>
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

    <script src="CandidateTask.js" type="text/javascript"></script>
</asp:Content>

