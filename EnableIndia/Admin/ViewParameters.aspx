<%@ Page Title="View Parameters" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true" Inherits="EnableIndia.Admin.ViewParameters" Codebehind="ViewParameters.aspx.cs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div tabindex="1" style="width:0px;height:0px"></div>
<table>
    <tr>
        <td>
            <asp:Label CssClass="labelStyle" ID="LblColumnHeader" runat="server" style="display:none" />
            <asp:Label CssClass="labelStyle" ID="LblColumnName" runat="server" Visible="false" />
            <asp:Label CssClass="labelStyle" ID="LblTableName" runat="server" Visible="false" />
        </td>
    </tr>
</table>
<table id="TblOtherParameters" runat="server" visible="false">
    <tr>
        <td>
            <asp:ListView ID="LstViewParameters" runat="server">
                <LayoutTemplate>
                    <table id="TblParameters" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                        bordercolor="#808080" border="1px" style="margin-top:10px" >
                        <thead>
                            <tr class="grid-header">
                                <th align="right">No.</th>
                                <th id="TdColumnHeader" align="left"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td id="TdRecordNumber" align="right"></td>
                        <td align="left"><%#Eval(LblColumnName.Text) %></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                     <table id="TblParameters" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                        bordercolor="#808080" border="1px" style="margin-top:10px">
                        <thead>
                            <tr class="grid-header">
                                <th align="right">No.</th>
                                <th id="TdColumnHeader" align="left"></th>
                            </tr>
                        </thead>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>
    


<table id="TblDisibiltyType" runat="server" visible="false">
    <tr>
        <td>
            <asp:ListView ID="LstViewDisibiltyType" runat="server">
                <LayoutTemplate>
                    <span style="font-weight:bold">Disability Sub Types</span><br/> 
                    <table  id="TblDisibiltyType" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                        bordercolor="#808080" border="1px" style="margin-top:10px" >
                        <thead>
                            <tr class="grid-header">
                                <th align="right">No.</th>
                                <th align="left">Disability Type</th>
                                <th align="left">Disability Sub-Type</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td id="TdRecordNumber" align="right"></td>
                        <td align="left"><%#Eval("disability_type")%></td>
                        <td align="left"><%#Eval("disability_sub_type") %> </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                     <span style="font-weight:bold">Disability Sub Types</span><br/> 
                     <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                        bordercolor="#808080" border="1px" style="margin-top:10px">
                        <thead>
                            <tr class="grid-header">
                                <th id="TdColumnHeader" align="left">Disability Type</th>
                                <th align="left">Disability Sub-Type</th>
                            </tr>
                        </thead>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </td>
    </tr>    
</table>


<table id="TblJobTypeWithRole" runat="server" visible="false">
    <tr>
        <td>
            <asp:ListView ID="lstViewJobTypeWithRole" runat="server">
                <LayoutTemplate>
                    <span style="font-weight:bold">Roles </span><br/> 
                    <table id="TblJobTypeWithRole" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                        bordercolor="#808080" border="1px" style="margin-top:10px" >
                        <thead>
                            <tr class="grid-header">
                                <th align="right">No.</th>
                                <th align="left">Job Type</th>
                                <th align="left">Role</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td id="TdRecordNumber" align="right"></td>
                        <td align="left"><%#Eval("job_name")%></td>
                        <td align="left"><%#Eval("job_role_name")%> </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <span style="font-weight:bold">Roles </span><br/> 
                     <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                        bordercolor="#808080" border="1px"  style="margin-top:10px">
                        <thead>
                            <tr class="grid-header">
                                <th id="TdColumnHeader" align="left">Job Type</th>
                                <th align="left">Role</th>
                            </tr>
                        </thead>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </td>
    </tr>    
</table>


<table id="TblCountryWithState" runat="server" visible="false">
    <tr>
        <td>
            <asp:ListView ID="LstviewCountryWithState" runat="server">
                <LayoutTemplate>
                    <span style="font-weight:bold">States</span><br/> 
                    <table id="TblCountryWithState" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                        bordercolor="#808080" border="1px" style="margin-top:10px">
                        <thead>
                            <tr class="grid-header">
                                <th align="right">No.</th>
                                <th align="left">Country</th>
                                <th align="left">State</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td id="TdRecordNumber" align="right">"</td>
                        <td align="left"><%#Eval("country_name")%></td>
                        <td align="left"><%#Eval("state_name")%> </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <span style="font-weight:bold">States</span><br/> 
                     <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                        bordercolor="#808080" border="1px"  style="margin-top:10px">
                        <thead>
                            <tr class="grid-header">
                                <th id="TdColumnHeader" align="left">Country</th>
                                <th align="left">State</th>
                            </tr>
                        </thead>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </td>
    </tr>    
</table>



<table id="TblCityWithStateCountry" runat="server" visible="false">
    <tr>
        <td>
            <asp:ListView ID="LstViewCityWithStateCountry" runat="server">
                <LayoutTemplate>
                    <span style="font-weight:bold">City</span><br/> 
                    <table  id="TblCityWithStateCountry" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                        bordercolor="#808080" border="1px" style="margin-top:10px" >
                        <thead>
                            <tr class="grid-header">
                                <th align="right">No.</th>
                                <th align="left">Country</th>
                                <th align="left">State</th>
                                <th align="left">City</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td id="TdRecordNumber" align="right"></td>
                        <td align="left"><%#Eval("country_name")%></td>
                        <td align="left"><%#Eval("state_name")%></td>
                        <td align="left"><%#Eval("city_name")%> </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <span style="font-weight:bold">City</span><br/> 
                     <table cellpadding="4" class="tableBorder" cellspacing="0" rules="all" 
                        bordercolor="#808080" border="1px" style="margin-top:10px">
                        <thead>
                            <tr class="grid-header">
                                <th id="TdColumnHeader" align="left">Country</th>
                                <th align="left">State</th>
                                <th align="left">City</th>
                            </tr>
                        </thead>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </td>
    </tr>    
   
</table>
 <script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="ViewParameters.js" type="text/javascript"></script>
</asp:Content>

