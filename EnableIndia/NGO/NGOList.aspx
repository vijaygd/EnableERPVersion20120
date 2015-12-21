<%@ Page Title="NGO Section" Language="C#" MasterPageFile="~/NGO/NGOMaster.master" AutoEventWireup="true" Inherits="EnableIndia.NGO.NGOList" Codebehind="NGOList.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td class="pageHeader">
            NGO SECTION
        </td>
    </tr>
</table> 
 
<table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">    
    <tr>
        <td>NGO List & Details</td>
    </tr>
</table>  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <span><h1 id="skipToTop" class="skiplink">NGO List</h1></span>
        </td>
    </tr>
</table>

<table>
     <tr>
        <td><label for="TxtNGO">NGO Name :</label></td>
        <td><asp:TextBox ID="TxtNGO" runat="server" Width="500px" /></td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Button ID="BtnSearchNGO" runat="server" Text="Search" OnClick="BtnSearchNGO_Click" />
        </td>
    </tr>
</table>

<table cellpadding="4" style="padding-top:20px">
    <tr>
        <td>
            <asp:ListView ID="LstViewNgoDetails" runat="server">
                <LayoutTemplate>
                    <table  id="TblViewNgoDetails" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" bordercolor="#808080" border="1px">
                        <thead class="grid-header">
                            <tr>
                                <th align="right">No.</th>
                                <th align="center">NGO</th>
                                <th align="center">City</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="right" id="TdRecordNumber"></td>
                        <td scope="row" valign="top" align="left" title="NGO : <%#Eval("ngo_name") %>">
                            <asp:LinkButton ID="LnkBtnNgo" runat="server" Text='<%#Eval("ngo_name") %>' Font-Bold="false"
                                CommandArgument='<%#Eval("ngo_id") %>' OnClick="LnkBtnNgo_Click"  />
                        </td>
                        <td valign="top" align="left" title="NGO's City : <%#Eval("city_name")%>"><%#Eval("city_name")%></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all" bordercolor="#808080" border="1px">
                        <thead class="grid-header">
                            <tr>
                                 <td style="width:250px" align="left">NGO</td>
                                 <td align="center">City</td>
                            </tr>
                        </thead>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>
<script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="NGOList.js" type="text/javascript"></script>
</asp:Content>

