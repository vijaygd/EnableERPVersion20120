﻿<%@ Page Title="Add Recommended Job Type and Role" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.ProfileHistory.Recommended_Job_Type" Codebehind="Recommended Job Type.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <telerik:RadCodeBlock runat="server" ID="rcb1">
       <script language="javascript" type="text/javascript">
           function GetRadWindow() {
               var oWindow = null;
               if (window.radWindow) {
                   oWindow = window.RadWindow;
               }
               else
                   if (window.frameElement.radWindow) {
                       oWindow = window.frameElement.radWindow;
                   }
               return oWindow;;
           }
           function Close(msg) {
               GetRadWindow().Close(msg);
           }
           function refreshParentPage() {
               getRadWindow().BrowserWindow.location.reload();
           }
           function redirectParentPage(url) {
               GetRadWindow().BrowserWindow.document.location.href = url;
           }

      </script>
      </telerik:RadCodeBlock>

<asp:Panel runat="server" ID="panContent" Width="530px" Height="400px" ScrollBars="Vertical">
    <table style="margin-left:40px">
        <tr>
            <td style="width:62px"><label for="ctl00_ContentPlaceHolder1_DdlRecommndedJobTypes">Job Type</label>:</td>
            <td>
                <select id="DdlRecommndedJobTypes" runat="server" class="mandatory"
                    messagetext="Job type"
                    onchange="javascript:DdlRecommndedJobTypes_SelectedIndexChanged();" />
                <span id="SpnRecommendedJobTypes" runat="server" />
            </td>
        </tr>
    </table>
   
    <table style="margin-top:5px;margin-left:40px">
        <tr>
            <td valign="top"  style="width:62px">Job Roles:</td>
            <td>
                <span id="SpnEmptyMessage" style="white-space:nowrap">No role assigned.</span>
                <asp:ListView ID="LstViewJobTypesWithRole" runat="server"
                    OnItemDataBound="LstViewJobTypesWithRole_ItemDataBound">
                    <LayoutTemplate>
                        <table id="TblJobTypesRoles" cellpadding="0" class="checkedListBox">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <table cellpadding="0" JobID='<%#Eval("job_id") %>'>
                            <tr>
                                <td id="textField"><label id="lblJobRole" runat="server"><%#Eval("job_role_name") %></label></td>
                                <td>
                                    <asp:CheckBox ID="ChkJobRole" runat="server" 
                                        jobID='<%#Eval("job_id") %>' JobRoleID='<%#Eval("job_role_id") %>' 
                                        Checked='<%#Convert.ToBoolean(Eval("is_attached")) %>' />
                                    <%--<label id="lblJobRole" runat="server" class="skiplink"><%#Eval("job_role_name") %></label>--%>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:ListView>
            </td>
        </tr>
    </table>
    
     <table style="margin-top:10px;margin-left:40px">
        <tr>
            <td style="width:62px"></td>
            <td>
                <asp:Button ID="BtnAddJobTypes" runat="server" Text="Update" 
                    OnClientClick="javascript:return ValidateForm();"
                    OnClick="BtnAddJobTypes_click" />
            </td>
            
            <td>
                <asp:Button runat="server" ID="btnClose" Text="Close" OnClick="CloseWindow" />
            </td>
            <td>
                <asp:Button ID="BtnDeleteRecommendedjobType" runat="server" Text="Delete" Visible="false"
                    OnClientClick="javascript:return confirm('Are you sure you want to delete Job Type/ Role Type data?');"
                    OnClick="BtnDeleteRecommendedjobType_Click" />
                   <asp:HiddenField runat="server" ID="txtParent" ClientIDMode="Static" />

            </td>
        </tr>
         <tr>
             <td style="vertical-align:middle; text-align:center;">
                 <asp:Label CssClass="labelStyle" runat="server" ID="lbError"></asp:Label>
             </td>
         </tr>
    </table>
    </asp:Panel>
    <script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="Recommended Job Type.js" type="text/javascript"></script>
    <script language="JavaScript" type="text/javascript">
        function refreshParent() {
//            window.opener.location.href = window.opener.location.href;
//            if (window.opener.self) {
//                window.opener.self.close()
//            }
            window.close();
            window.open(document.getElementById("txtParent").value, "_parent");
           
        }
</script>
</asp:Content>
