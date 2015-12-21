<%@ Page Title="" Language="C#" MasterPageFile="~/MobileDevices/mobileMaster.Master" AutoEventWireup="true" CodeBehind="mdUnregisterCandidate.aspx.cs" Inherits="EnableIndia.MobileDevices.mdUnregisterCandidate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .buttons
        {
            display:none;
        }
    </style>
    <asp:ScriptManagerProxy runat="server" ID="sproxy1"></asp:ScriptManagerProxy>
    
    <script type="text/javascript">
        var BackRowColor;
        function Highlight(row) {
            BackRowColor = row.style.backgroundColor;
            //   row.style.backgroundColor = '#FFFF33';
            row.style.backgroundColor = '#C0FFC0';;
            row.style.border = '2px solid red';

        }
        function UnHighlight(row) {
            row.style.backgroundColor = BackRowColor;
        }
        function confirmCallBackFn(arg) {
            if (arg == true) {
                var btn = document.getElementById("ContentPlaceHolder1_Hdn");
                btn.click();
            }

        }
        function callConfirm() {
            radconfirm('Are you sure?', confirmCallBackFn);
        }

    </script>
    
     <table style="border-collapse:separate; border-width:0px; border-spacing:1px; word-wrap:break-word; width:100%; table-layout:fixed; ">
       <colgroup>
           <col  style="width:17%" />
           <col  style="width:27%" />
           <col  style="width:27%" />
           <col  style="width:27%" />
       </colgroup>
    <tbody>
         <tr>
            <td style="vertical-align:middle;">
                <label for="ContentPlaceHolder1_TxtSearchFor">Search for</label>
            </td>
            <td  style="vertical-align:middle; text-align:left">
                <asp:TextBox ID="TxtSearchFor" runat="server" Width="200px" ToolTip="Search For" />
                <label for="ContentPlaceHolder1_DdlSearchIn">in</label>
                <select id="DdlSearchIn" runat="server" title="Serach In">
                    <option value="name">Name</option>
                    <option value="registration_id">RID</option>
                    <option value="ngo">NGO</option>
                </select>
            </td>
             <td style="vertical-align:middle;">
                 <asp:Button runat="server" ID="btnGet" Text="Get" Width="80px" OnClick="btnGetClicked" />&nbsp;&nbsp;
                 <asp:Button runat="server" ID="btnReset" Text="Reset" Width="80px" OnClick="btnResetClicked" />
             </td>
        </tr>
    </tbody>
    </table>
    <div  id="wrapper">
        <div id="inner1" runat="server" style="vertical-align:top; margin: 0 auto;">
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
            <asp:BoundField DataField="educational_qualifications"    HeaderText="Qualification"     
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
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%"   HeaderStyle-Width="12%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="ngo_name"    HeaderText="NGO Name"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%"   HeaderStyle-Width="4%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="current_company"    HeaderText="Company Name"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%"   HeaderStyle-Width="4%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>

            <asp:BoundField DataField="unemployed_from_days"    HeaderText="Unemployed Since Days"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%"   HeaderStyle-Width="3%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="recommended_job_types"    HeaderText="Reco Job Roles"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="6%"   HeaderStyle-Width="6%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
            <asp:BoundField DataField="recommended_roles"    HeaderText="Reco Job roles"     
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="6%"   HeaderStyle-Width="6%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#dce4ff" 
                ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
            </asp:BoundField>
                 <asp:TemplateField HeaderText="Del"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="4%" ItemStyle-Width="4%" HeaderStyle-Font-Names="arial" HeaderStyle-BackColor="#dce4ff"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Wrap="true" HeaderStyle-Wrap="true">
                <ItemTemplate>
                 <asp:ImageButton runat="server" ID="imgDelete" AlternateText="Unregister"  OnClick="imageButtonUnRegisterClicked"  ToolTip="Unregister this candidate"  ImageUrl="~/Image/DeleteSmall.gif" ImageAlign="AbsMiddle"  />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <HeaderStyle BackColor="#e1e1e1" /> 
        <AlternatingRowStyle  BackColor="#EFEFFF" Height="14px" />
        <PagerStyle HorizontalAlign="Center"></PagerStyle>
        <RowStyle BackColor="#FFFFFF" Height="14px"/>
      </asp:GridView>
    </div>
        <div id="inner2" runat="server" style="text-align:center; vertical-align:middle; width:100%; ">
        <div style="display:table-cell; width:33.33%;">
           <asp:Label runat="server" ID="lbRecT" Text="Entries: " Font-Bold="true" Font-Names="Consolas"></asp:Label>
           <asp:Label runat="server" ID="lbNoRec" Font-Bold="true" Font-Size="12px" ForeColor="#d32232"></asp:Label>
        </div>
        <div style="display:table-cell; width:33.33%;">
            <asp:Button runat="server" ID="btnClose" Text="C l o s e" Width="200px" Font-Bold="true" Font-Size="12px" OnClick="btnCloseClick" />
        </div>
        <div style="display:table-cell; width:33.33%;">
           <asp:UpdatePanel runat="server" ID="updLabel" UpdateMode="Conditional">
               <ContentTemplate>
                    <asp:Label runat="server" ID="lbError" Font-Bold="true" Font-Size="12px" ForeColor="#d32232"></asp:Label>
               </ContentTemplate>
           </asp:UpdatePanel>
           <span id="SpnHiddenRecommendedRole" runat="server" visible="false"></span>

        </div>
    </div>
    </div>
    <div>
        <telerik:RadWindowManager runat="server" ID="RadWindowManager1"></telerik:RadWindowManager>
          <asp:Button ID="Hdn" runat="server" OnClick="Hdn_Click" CssClass="buttons" />
        <asp:HiddenField runat="server" ID="hField" />
    </div>
    <script src="../Scripts/jquery-2.1.4.min.js"></script>
</asp:Content>
