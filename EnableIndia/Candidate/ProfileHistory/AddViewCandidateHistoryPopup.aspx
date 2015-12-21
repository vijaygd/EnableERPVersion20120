<%@ Page Title="Add View Candidate History Popup" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true" Inherits="EnableIndia.date.ProfileHistory.AddViewCandidateHistoryPopup" Codebehind="AddViewCandidateHistoryPopup.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="width:300px;padding-left:5px">
                <span id="SpnCandidateNameText" runat="server" class="readonly_bold_text">Candidate:</span>
                <span id="SpnCandidateName" runat="server" class="readonlyText"/>
            </td>
            <td style="width:100px">
                <span id="SpnRIDText" runat="server" class="readonly_bold_text">RID :</span>
                <span id="SpnRID" runat="server" class="readonlyText"></span>
            </td>
        </tr>
    </table>
    
    <table>
        <tr> 
          <td>
            <table visible="false" id="TblMessageAdd" runat="server">
                <tr>
                    <td style="font-weight:bold">
                       Add New History for Candidate:
                    </td>
                </tr>   
            </table>
            <table visible="false" id="TblMessageUpdate" runat="server">
                <tr>
                    <td style="font-weight:bold">
                        Update Candidate History for selected row:
                    </td>
                </tr>   
            </table>
            <table>
                <tr>
                    <td style="width:200px">Date:</td>
                    <td>
                        <span id="SpnDate" runat="server"></span>
                    </td> 
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width:200px" valign="top">
                        <label for="ctl00_ContentPlaceHolder1_TxtDetails"> DETAILS:</label></td>
                        <td><asp:TextBox id="TxtDetails" runat="server" Rows="100" Columns="100" class="mandatory" messagetext="Detail" Width="400px" Height="100px" TextMode="MultiLine" MaxLength="10000" ></asp:TextBox></td>
                    <%--<td><textarea id="TxtDetails" runat="server" class="mandatory" messagetext="Detail" style="height:100px;width:400px" /></td>--%>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width:200px"><label for="ctl00_ContentPlaceHolder1_DdlFlags"> Select Flag:</label></td>
                    <td>
                        <select id="DdlFlags" runat="server" onchange="javascript:DdlFlags_SelectedIndexChanged();" messagetext="Flag " />
                        <span id="SpnFlag" runat="server" />
                    </td>
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
                    <td><asp:TextBox ID="TxtRecommendedAction" runat="server" Text="" Width="400px"></asp:TextBox></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width:200px"><label for="ctl00_ContentPlaceHolder1_TxtFollowUpDate"> Follow-up-date:</label></td>
                    <td><asp:TextBox ID="TxtFollowUpDate" runat ="server" yearlength="4" />

                    </td>
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
                        <asp:Button ID="BtnAddUpdateCandiateHistory" runat="server" Text="Add" 
                            OnClientClick="javascript:return ValidateClosureDate();" 
                            OnClick="BtnAddUpdateCandiateHistory_Click" />
                     </td>
                     <td>
                        <asp:Button ID="BtnCloseCandidateHistory" runat="server" Text="Close" ToolTip="Close" OnClientClick="javascript:self.close();return false;" />
                    </td>
                    <td>
                        <asp:Button ID="BtnDeleteCandidateHistory" runat="server" Text="Delete History" ToolTip="Delete History"
                            Visible="false" OnClick="BtnDeleteCandidateHistory_Click"
                            OnClientClick="javascript:return confirm('Are you sure want to delete candidate history?');" />
                         <asp:HiddenField runat="server" ID="txtParent" ClientIDMode="Static" />

                    </td>
                </tr>
            </table>
            </td>
        </tr>
    </table>
<script src="../../Scripts/jquery-1.7.1-vsdoc.js" type="text/javascript"></script>
<script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="AddViewHistory.js" type="text/javascript"></script>
</asp:Content>

