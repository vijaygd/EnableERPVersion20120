<%@ Page Title="" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" CodeBehind="SocioEconomicList.aspx.cs" Inherits="EnableIndia.Candidate.ProfileHistory.SocioEconomicList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
    <table>
        <tr>
            <td>
                     <asp:ListView ID="LstViewExistingSocioEconomicIndicator" runat="server" >
                            <LayoutTemplate>
                                <table style="margin-bottom:5px">
                                    <tr>
                                        <td style="font-weight:bold">Existing Work Experience:</td>
                                    </tr>
                                </table>
                                <table id="TblExistingSocioEconomicIndicator" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" style="border-color:#000000;"
                                      border="1" >
                                   <thead>
                                        <tr class="grid-header">
                                           <th align="right">No.</th>
                                           <th>Familiy Income</th>
                                           <th>Number of Members/th> 
                                           <th>Main Earning Member</th> 
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
                                        <asp:LinkButton ID="LnkBtnSecId" runat="server" Text="" CssClass="readonlyText"
                                            secid='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("sec_id"))) %>'
                                            OnClick="LnkSecId_Click" />
                                   </td>
                                   <th align="right" style="font-weight:normal"><%#Eval("family_income")%></th> 
                                   <td align="center"><%#Eval("number_of_members")%></td>
                                   <td align="center"><%#Eval("main_earning_member")%></td> 
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </td>
                </tr>
                 <tr>
                     <td  style="vertical-align:middle;">
                         <asp:Button runat="server" ID="btnAddSeC" Text="Add Socio Economic Indicator" Font-Bold="true" OnClick="btnAddSeCClicked" />
                     </td>
                 </tr>
            </table>
        <telerik:RadWindowManager runat="server" ID="radManager" EnableViewState="false" DestroyOnClose="true" VisibleOnPageLoad="false"  AutoSize="true" Top="0"  Height="680px" Width="900px" Modal="true" CssClass="RadWindow" ClientIDMode="Static">
        </telerik:RadWindowManager>

    <script src="../../Scripts/jquery-2.1.4.min.js"  type="text/javascript"></script>
    <script src="../../Scripts/Common.js" type="text/javascript"></script>
    <script src="SocioEconomicList.js" type="text/javascript"></script>
</asp:Content>
