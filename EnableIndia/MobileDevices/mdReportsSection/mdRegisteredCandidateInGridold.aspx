<%@ Page Title="" Language="C#" MasterPageFile="~/MobileDevices/mobileMaster.Master" AutoEventWireup="true" CodeBehind="mdRegisteredCandidateInGridold.aspx.cs" Inherits="EnableIndia.MobileDevices.mdReportsSection.mdRegisteredCandidateInGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                ItemStyle-HorizontalAlign="Center"   ItemStyle-Width="10%"  HeaderStyle-Width="10%" 
                HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" 
                HeaderStyle-BackColor="#dce4ff" ApplyFormatInEditMode="True" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="candidate_id"   HeaderText="Cand Id"   ItemStyle-Wrap="true" 
                ItemStyle-HorizontalAlign="left" ItemStyle-Width="10%"   HeaderStyle-Width="10%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="registration_date"  HeaderText="Reg Date"  ItemStyle-Wrap="true"
                ItemStyle-HorizontalAlign="Left"   ItemStyle-Width="15%"  HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="designation_expiry_date"     HeaderText="Deg Exp Date"   
                ItemStyle-HorizontalAlign="left" ItemStyle-Width="10%" HeaderStyle-Width="10%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="candidate_name"    HeaderText="Candidate Name"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="10%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="date_of_birth"    HeaderText="Date of Birth"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="disability_type"    HeaderText="Disability"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="educational_qualification"    HeaderText="Qualification"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="phone_numbers"    HeaderText="Phone Numbers"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="email_address"    HeaderText="e-mail"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>



            <asp:BoundField DataField="ngo_name"    HeaderText="NGO Name"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="Unemployed_Days"    HeaderText="Unemployed Days"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="unemployed_since_days"    HeaderText="Unemployed Since Days"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="recommended_job_types"    HeaderText="Reco Job Roles"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="recommended_job_types"    HeaderText="Reco Job Types"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="rold_name"    HeaderText="Role_name"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="designation"    HeaderText="Designation"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="company_name"    HeaderText="Company Name"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="date_of_join"    HeaderText="Date of Join"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="contract_expiry_date"    HeaderText="Cont Exp Date"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
           <asp:BoundField DataField="salary"    HeaderText="Salary"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"   HeaderStyle-Width="15%"
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
</asp:Content>
