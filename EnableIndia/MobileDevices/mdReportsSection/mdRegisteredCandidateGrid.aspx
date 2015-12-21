<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mdRegisteredCandidateGrid.aspx.cs" Inherits="EnableIndia.MobileDevices.mdReportsSection.mdRegisteredCandidateGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registerd Candidate</title>
    <script type="text/javascript">
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
        function Close() {
            GetRadWindow().Close();
        }
    </script>
</head>
<body>
    <form id="formRegisteredCandidates" runat="server">
    <div style="vertical-align:top; margin: 0 auto; height:600px;">
    <asp:GridView runat="server" ID="grCandidates" Style="position: static" HorizontalAlign="Center" 
          OnPageIndexChanging="grCandidatesChanging"  
          AutoGenerateColumns="False" CellSpacing="0" AllowPaging="True" PageSize="16"  
                        CellPadding="2"  Font-Size="12px"  Font-Names="Consolas"  RowStyle-Wrap="true" EmptyDataRowStyle-Wrap="true" HeaderStyle-Wrap="true" PagerStyle-Wrap="true" SelectedRowStyle-Wrap="true" 
         PagerStyle-HorizontalAlign="Center" OnRowDataBound="grCandidatesOnRowDataBound"  
         BorderColor="Transparent" BorderStyle="Solid" BorderWidth="0.5" CssClass="tbl" >
         <PagerSettings  
         FirstPageText="[ First ]"
         LastPageText="[ Last ]"   
         NextPageText ="[ Next ]"
         PreviousPageText="[ Prev ]"
         Position="bottom"
         Mode="NextPreviousFirstLast"  
         />
        <Columns>
            <asp:BoundField DataField="registration_id"  HeaderText="Reg Id"  ItemStyle-Wrap="true"
                ItemStyle-HorizontalAlign="Center"   ItemStyle-Width="2%"  HeaderStyle-Width="2%" 
                HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" 
                HeaderStyle-BackColor="#dce4ff" ApplyFormatInEditMode="True" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="candidate_id"   HeaderText="Cand Id"   ItemStyle-Wrap="true" 
                ItemStyle-HorizontalAlign="left" ItemStyle-Width="2%"   HeaderStyle-Width="2%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="registration_date"  HeaderText="Reg Date"  ItemStyle-Wrap="true" DataFormatString="{0:dd/MM/yyyy}"
                ItemStyle-HorizontalAlign="Left"   ItemStyle-Width="3%"  HeaderStyle-Width="3%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="designation_expiry_date"     HeaderText="Deg Exp Date"   DataFormatString="{0:dd/MM/yyyy}"
                ItemStyle-HorizontalAlign="left" ItemStyle-Width="3%" HeaderStyle-Width="3%"
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="candidate_name"    HeaderText="Candidate Name"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%"   HeaderStyle-Width="5%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="date_of_birth"    HeaderText="Date of Birth"     DataFormatString="{0:dd/MM/yyyy}"
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%"   HeaderStyle-Width="3%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="disability_type"    HeaderText="Disability"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%"   HeaderStyle-Width="5%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="educational_qualification"    HeaderText="Qualification"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%"   HeaderStyle-Width="4%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="phone_numbers"    HeaderText="Phone Numbers"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%"   HeaderStyle-Width="5%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="email_address"    HeaderText="e-mail"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%"   HeaderStyle-Width="4%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="ngo_name"    HeaderText="NGO Name"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%"   HeaderStyle-Width="4%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="Unemployed_Days"    HeaderText="Unemployed Days"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%"   HeaderStyle-Width="3%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="unemployed_since_days"    HeaderText="Unemployed Since Days"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%"   HeaderStyle-Width="3%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="recommended_job_types"    HeaderText="Reco Job Roles"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="6%"   HeaderStyle-Width="6%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="recommended_job_roles"    HeaderText="Reco Job roles"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="6%"   HeaderStyle-Width="6%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="role_name"    HeaderText="Role_name"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%"   HeaderStyle-Width="4%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="designation"    HeaderText="Designation"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%"   HeaderStyle-Width="4%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="company_name"    HeaderText="Company Name"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%"   HeaderStyle-Width="4%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="date_of_join"    HeaderText="Date of Join"     DataFormatString="{0:dd/MM/yyyy}"
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%"   HeaderStyle-Width="3%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="contract_expiry_date"    HeaderText="Cont Exp Date"     DataFormatString="{0:dd/MM/yyyy}"
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%"   HeaderStyle-Width="3%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
           <asp:BoundField DataField="salary"    HeaderText="Salary"     
                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="3%"   HeaderStyle-Width="3%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
        </Columns>
        <HeaderStyle BackColor="#e1e1e1" /> 
        <AlternatingRowStyle  BackColor="#EFEFFF" Height="14px" />
        <PagerStyle HorizontalAlign="Center"></PagerStyle>
        <RowStyle BackColor="#FFFFFF" Height="14px"/>
      </asp:GridView>
    </div>
    <div style="text-align:center; vertical-align:middle;">
        <div style="display:table-cell; width:33%;">
           <asp:Label runat="server" ID="lbRecT" Text="Entries: " Font-Bold="true" Font-Names="Consolas"></asp:Label>
           <asp:Label runat="server" ID="lbNoRec" Font-Bold="true" Font-Size="12px" ForeColor="#d32232"></asp:Label>
        </div>
        <div style="display:table-cell; width:33%;">
            <asp:Button runat="server" ID="btnClose" Text="C l o s e" Width="200px" Font-Bold="true" Font-Size="12px" OnClick="btnCloseClick" />
        </div>
        <div style="display:table-cell; width:33%;">
           <asp:Label runat="server" ID="lbError" Font-Bold="true" Font-Size="12px" ForeColor="#d32232"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
