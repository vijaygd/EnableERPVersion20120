<%@ Page Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true" Inherits="EnableIndia.Company.AddViewCompanyHistoryPopup" Title="Add and View Company History Popup" Codebehind="AddViewCompanyHistoryPopup.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
    <tr> 
        <td>
            <table id="TblCompanyDetail" runat="server" visible="false">
                <tr>
                    <td class="readonly_bold_text">
                        Parent Company Name:
                    </td>
                    <td>
                        <span id="SpnParentCompanyName" runat="server" class="readonlyText"></span>
                    </td>
                    <td style="padding-left:30px" class="readonly_bold_text">Company :</td>
                    <td>
                        <span id="SpnCompanyName" runat="server" class="readonlyText"></span>
                    </td>
                </tr>
            </table>
            
            <table visible="false" id="TblMessageAdd" runat="server">
                <tr>
                    <td style="font-weight:bold">
                       Add New History for Company
                    </td>
                </tr>   
            </table>
            
            <table visible="false" id="TblMessageUpdate" runat="server">
                <tr>
                    <td style="font-weight:bold">
                        Update Company History for selected row:
                    </td>
                </tr>   
            </table>
             
            <table id="TblParentCompany" runat="server">
                <tr>
                    <td style="width:200px">
                        <label for="ctl00_ContentPlaceHolder1_DdlParentCompany">PARENT COMPANY:</label></td>
                    <td>
                         <select id="DdlParentCompanies" runat="server"  class="mandatory"
                                title="Select parent company" messagetext="Parent company"
                                onchange="javascript:FilterCityStatesInPopup(this.value,'ParentCompanyID','DdlCompanies','DdlHiddenCompany');" />
                         <span id="SpnParentCompany" runat="server"></span>
                     </td>
                     <td>
                         <table style="display:none">
                            <tr>
                                <td>
                                    <label for="ctl00_ContentPlaceHolder2_DdlHiddenCompany">HiddenCompany</label>
                                    <select id="DdlHiddenCompany" runat="server"/>
                                    <span id="SpnHiddenCompanyID" runat="server" />
                                </td> 
                            </tr>
                        </table>       
                     </td>
                </tr>
            </table>
            
             <table id="TblCompany" runat="server">
                <tr>
                    <td style="width:200px">
                        <label for="ctl00_ContentPlaceHolder1_DdlCompanies"> COMPANY:</label></td>
                    <td>
                        <select id="DdlCompanies" runat="server" class="mandatory" messagetext="Company" />
                        <span id="SpnCompany" runat="server" ></span>
                     </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:200px">Date:</td>
                    <td><span id="SpnDate" runat="server"></span></td> 
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:200px" valign="top"><label for="ctl00_ContentPlaceHolder1_TxtDetails"> DETAILS:</label></td>
                    <td><asp:TextBox id="TxtDetails" runat="server" Text="" class="mandatory" messagetext="Detail" Width="400px" Height="60px" TextMode="MultiLine" ></asp:TextBox></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:200px"><label for="ctl00_ContentPlaceHolder1_DdlFlags"> Select Flag:</label></td>
                    <td><select id="DdlFlags" runat="server"   messagetext="Flag " onchange="javascript:DdlFlags_SelectedIndexChanged();" /><span id="SpnFlag" runat="server"  /></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:200px"><label for="ctl00_ContentPlaceHolder1_DdlTaskManagedByEmployee"> Task is Managed By Employee:</label></td>
                    <td><select id="DdlTaskManagedByEmployee" runat="server" messagetext="Managed by " /></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:200px"><label for="ctl00_ContentPlaceHolder1_TxtRecommendedAction"> Action Points:</label></td>
                    <td><asp:TextBox ID="TxtRecommendedAction" runat="server" Text=""></asp:TextBox></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:200px"><label for="ctl00_ContentPlaceHolder1_TxtFollowUpDate"> Follow-up-date:</label></td>
                    <td><asp:TextBox ID="TxtFollowUpDate" runat ="server"   yearlength="4" /> </td>
                    <td>(DD/MM/YYYY)</td>                
                </tr>
            </table>
            
            <table>
                <tr>
                   <td style="width:200px"><label id="LblUpdateStatus" runat="server" for="ctl00_ContentPlaceHolder1_DdlUpdateStatus">Update Status</label></td>
                    <td>
                        <select id="DdlUpdateStatus" runat="server">
                            <option value="Open">Open</option>
                            <option value="Closed">Closed</option>
                        </select>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:200px"></td>
                    <td style="width:1px" align="right">
                        <asp:Button ID="BtnAddUpdateCompanyHistory" runat="server" Text="Add" 
                            OnClientClick="javascript:return ValidateClosureDate();" 
                            OnClick="BtnAddUpdateCompanyHistory_Click" />
                     </td>
                     <td>
                        <asp:Button ID="BtnCloseCompanyHistory" runat="server" Text="Close pop-up" ToolTip="Close pop-up" OnClientClick="javascript:self.close();return false;" />
                    </td>
                    <td>
                        <asp:Button ID="BtnDeleteCompanyHistory" runat="server" Text="Delete History" ToolTip="Delete History"
                            OnClick="BtnDeleteCompanyHistory_Click" Visible="false"
                            OnClientClick="javascript:return confirm('Are you sure want to delete history?');" />
                            <asp:HiddenField runat="server" ID="hdField" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script type="text/javascript" src="AddViewCompanyHistoryPopup.js" ></script>
</asp:Content>

