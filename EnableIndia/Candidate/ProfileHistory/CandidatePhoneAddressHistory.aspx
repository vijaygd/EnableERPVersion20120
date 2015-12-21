<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.ProfileHistory.CandidatePhoneAddressHistory" Codebehind="CandidatePhoneAddressHistory.aspx.cs" ClientIDMode="Static" %>
 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script src="../../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<table>
    <tr>
        <td>
            <asp:ListView ID="LstViewPhoneHistory" runat="server" Visible="false">
                <LayoutTemplate>
                    <table style="margin-bottom:5px">
                        <tr>
                            <td style="font-weight:bold">Candidate Phone History</td>
                        </tr>
                    </table>
                    <table id="TblCandidatePhoneHistory" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                       bordercolor="#808080" border="1px" >
                       <thead>
                            <tr class="grid-header">
                               <th>No.</th>
                               <th>Phone Number</th>
                               <th>Secondary Phone Number</th>
                               <th>Created/Changed Date</th>
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
                        <td align="right"><%#Eval("primary_phone_number") %></td>
                        <td align="right"><%# Eval("secondary_phone_number")%></td>
                        <td align="left"><%#Convert.ToDateTime(Eval("updation_date")).ToString(EnableIndia.Global.GetDateFormat()) %></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>
                                <span style="font-weight:bold">There is no history</span>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
            
            <asp:ListView ID="LstViewAddressHistory" runat="server" Visible="false">
                <LayoutTemplate>
                    <table style="margin-bottom:5px">
                        <tr>
                            <td style="font-weight:bold">Candidate Address History</td>
                        </tr>
                    </table>
                    <table id="TblCandidateAddressHistory" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" style=" border-color:#808080;"
                        border="1px" >
                       <thead>
                            <tr class="grid-header">
                               <th>No.</th>
                               <th>Address</th>
                               <th>Present State</th>
                               <th>City</th>
                               <th>Pin Code</th>
                               <th>Created/Changed Date</th>
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
                        <td align="left"><%#Eval("present_address") %></td>
                        <td align="left"><%#Eval("state_name") %></td>
                        <td align="left"><%#Eval("city_name") %></td>
                        <td align="left"><%#Eval("present_address_pin_code") %></td>
                        <td align="left"><%#Convert.ToDateTime(Eval("updation_date")).ToString(EnableIndia.Global.GetDateFormat()) %></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>
                                <span style="font-weight:bold">There is no history</span>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>
<table style="margin-top:5px">
    <tr>
        <td>
            <input type="button" value="Close" onclick="javascript:self.close();" />
        </td>
    </tr>
</table>
<script type="text/javascript">
    $(document).ready(function(){
        InsertRecordNumber("TblCandidatePhoneHistory");
        InsertRecordNumber("TblCandidateAddressHistory");
    });
</script>
</asp:Content>

