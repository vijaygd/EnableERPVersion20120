<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SocioEconomicIndicator.aspx.cs" Inherits="EnableIndia.Candidate.SocioEconomicIndicator" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Socio Economic Indidator</title>
    <link href="../App_Themes/Default/StyleSheet.css" rel="stylesheet" />
    <link href="../StyleSheets/contentStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="formSocioEconomicIndicator" runat="server">
        <asp:ScriptManager runat="server" ID="scm1"></asp:ScriptManager>
    <div>
    <table>
        <tr>
            <td colspan="2">
               <asp:Label runat="server" ID="lbHeader" Text="Socio Economic Indicator" Font-Bold="true"></asp:Label>
            </td>
        </tr>
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

        <table style="border-collapse:separate; border-spacing:5px; border-width:2px;">
         <tr>
            <td>
                <asp:Label runat="server" ID="Label4" Text="Family Income: "></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="TxtFamiliyIncome" Width="120px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label runat="server" ID="Label5" Text="Number of members: "></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="TxtNumberOfMembers" Width="50px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="Label6" Text="Main Earning Member: "></asp:Label>
            </td>
            <td>
                <asp:CheckBox runat="server" ID="cbMainEarningMember" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button runat="server" ID="btnAddSocioEconomicstatus" Text="Add" OnClick="btnAddSocioEconomicstatusClicked" />&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancelClicked" />
                <asp:HiddenField runat="server" ID="txtParent" ClientIDMode="Static" />

            </td>
        </tr>
        <tr >
            <td colspan="2" style="vertical-align:middle; text-align:center;"">
                <asp:Label runat="server" ID="lbError" Font-Bold="true" Font-Size="12px" ForeColor="#d32232"></asp:Label>
            </td>
        </tr>

    </table>

    </div>
    </form>
</body>
</html>
