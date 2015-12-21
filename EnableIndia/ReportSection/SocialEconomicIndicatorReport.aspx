<%@ Page Title="" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" CodeBehind="SocialEconomicIndicatorReport.aspx.cs" Inherits="EnableIndia.Reports.SocialEconomicIndicatorReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table style="border-collapse:separate; border-spacing:4px; border-width:4px;">
        <tr>
            <td colspan="6">
                <asp:Label runat="server" ID="lbSeiHeader" Text="Social Economic Indicator Report" Font-Bold="true" Font-Size="12px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:middle; text-align:left;">
                <asp:Label runat="server" ID="lbSearchT" Text="Search" Font-Bold="true" Font-Size="12px"></asp:Label>
            </td>
            <td colspan="2" style="vertical-align:middle; text-align:left;">
                <asp:TextBox runat="server" ID="TxtSearchFor" Width="120px"></asp:TextBox>&nbsp;&nbsp;
                <asp:Label runat="server" ID="lbinT" Text=" in " Font-Bold="true"></asp:Label>
                <asp:DropDownList runat="server" ID="DdlSearchIn">
                    <asp:ListItem Text="Name" Value="name"></asp:ListItem>
                    <asp:ListItem Text="Registration Id" Value="registration_id"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td colspan="3"></td>
        </tr>
        <tr>
            <td  style ="width:135px">
                <label for="ctl00_ContentPlaceHolder2_DdlState">State:</label>
            </td>
            <td>
                <select id="DdlState" runat="server" enableviewstate="true"
                    onchange="javascript:DdlState_SelectIndexChanged(this.value,'StateID','DdlCities','DdlHiddenCity');" />
            </td>
            <td id="TdCity" style="width:150px;padding-left:30px">
                <label for="ctl00_ContentPlaceHolder2_DdlCities">City:</label>
            </td>
            <td>
                <select id="DdlCities" runat="server" enableviewstate="true"
                   onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHidddenCity').val($('#ctl00_ContentPlaceHolder2_DdlCities').val());" onclick="return DdlCities_onclick()"/>
            </td>
            <td style="display:none" >
                <label for="ctl00_ContentPlaceHolder2_DdlHiddenCity">hidden City</label>
                    <select id="DdlHiddenCity" runat="server" />
                    
              <label for="ctl00_ContentPlaceHolder2_TxtHidddenCity">hidden City</label>
                <asp:TextBox ID="TxtHidddenCity" runat="server" />
            </td>
            <td></td>
        </tr>
       <tr>
            <td style="width:135px">
                <label for="ctl00_ContentPlaceHolder2_DdlDisabilityTypes">Disability :</label>
            </td>
            <td>
                <select ID="DdlDisabilityTypes" runat="server" 
                   onchange="javascript:DdlDisabilityTypes_SelectedIndexChanged(this.value,'DisabilityTypeID','DdlDisabilitySubType','DdlHiddenDisabilitySubType');" />
            </td>
            <td id="TdDisabilitySubType" style="width:150px;padding-left:30px">
                <label for="ct100_ContentPlaceHolder2_DdlDisabilitySubType">Disability Sub Type</label>
            </td>
            <td>
                <select id="DdlDisabilitySubType" runat="server"
                  onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHidddenCity').val($('#ctl00_ContentPlaceHolder2_DdlCities').val());" onclick="return DdlCities_onclick()"/>
              </td>
            <td style="display:none">
                <label for="ct100_ContentPlaceHolder_DdlHiddenDisabilitySubType">Hidden Disability Type</label>
                <select id="DdlHiddenDisabilitySubType" runat="server"></select>
                <label for="ct100_ContentPlaceHolder_TxtHiddenDisabilitySubType">Hidden Disability Type</label>
                <asp:TextBox ID="TxtHiddenDisabilitySubType" runat="server"></asp:TextBox>
                <span id="SpnHiddenDisabilityType" runat="server"></span>
            </td>
           <td>

           </td>
           <td>

           </td>
           <td>

           </td>
        </tr>
                <tr>
            <td style="width:135px">
                <label for="ctl00_ContentPlaceHolder2_DdlRecommendedJobType">Job Type</label>
            </td>
            <td>
                <select id="DdlRecommendedJobType" runat="server" 
                    onchange="javascript:DdlRecommendedJobType_SelectIndexChanged(this.value,'JobID','DdlRecommendedRole','DdlHiddenRecommendedRole');" />
            </td>
            <td id="TdRecomendedRole" style="width:150px;padding-left:30px">
                <label for="ctl00_ContentPlaceHolder2_DdlRecommendedRole">Recommended Role</label>
            </td>
            <td>
                <select id="DdlRecommendedRole" runat="server"
                    onchange="javascript:$('#TxtHiddenRecommendedRole').val($('#DdlRecommendedRole').val());" />
            </td>
            <td style="display:none">
                <label for="ctl00_ContentPlaceHolder2_DdlHiddenRecommendedRole">Hidden Rcommeded role</label>
                <select id="DdlHiddenRecommendedRole" runat="server"/>
                <label for="ctl00_ContentPlaceHolder2_TxtHiddenRecommendedRole">Hidden Rcommeded role</label>
                <asp:TextBox ID="TxtHiddenRecommendedRole" runat="server" />
                <span id="SpnHiddenRecommendedRole" runat="server"></span>
            </td>
        </tr>
        <tr>
            <td style="width:135px;"><label for="ctl00_ContentPlaceHolder2_DdlGender">Gender</label></td>
            <td>
                <select id="DdlGender" runat="server">
                    <option value="All">All</option>
                    <option value="Male">Male</option>
                    <option value="Female">Female</option>
                </select>
            </td>
        </tr>
       <tr>
        <td style="width:135px">
            <asp:Label runat="server" ID="lbSalaryT" Text="Salary (Monthly)" Font-Bold="true" Font-Size="12px"></asp:Label></td>
            <td colspan="5">
              <asp:Label runat="server" ID="lbFromT"  Text=" From " Font-Bold="true" Font-Size="12"></asp:Label>
                <asp:TextBox ID="TxtSalaryFrom" runat="server"></asp:TextBox>
            <label for="ctl00_ContentPlaceHolder2_TxtSalaryFrom" class="skiplink">Salary  from</label>
                <label for="ctl00_ContentPlaceHolder2_TxtSalaryTo">To</label>
                <asp:TextBox ID="TxtSalaryTo" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td style="width:135px; height: 35px;"><label for="ctl00_ContentPlaceHolder2_DdlAgeGroups">Age(Years) :</label></td>
            <td style="height: 35px">
                <select id="DdlAgeGroups" runat="server" />
            </td>
            <td colspan="4"></td>
        </tr>
          <tr>
            <td style="width:135px; height: 35px;"><label for="ctl00_ContentPlaceHolder2_ddlSEIOption">SEI Entered:</label></td>
            <td style="height: 35px">
                <asp:DropDownList runat="server" ID="ddlSEIOption">
                    <asp:ListItem Text="All Entered"  Value="AE"></asp:ListItem>
                    <asp:ListItem Text="Not Entered"  Value="NE"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td colspan="4"></td>
        </tr>

        <tr>
            <td>
             <div>
                 <asp:Button runat="server" ID="btnRefresh" Width="10px" Height="10px"  CssClass="btnHide" />
                <asp:Button ID="BtnGenerateReport" runat="server" Text="Generate" 
                    OnClientClick="javascript: return GoSearchParameter();" OnClick="BtnGenerateReport_Click"  />&nbsp;&nbsp;
                 <asp:ImageButton runat="server" ID="ImageButton3" ImageUrl="~/App_Themes/Default/images/ExportToExcel.gif"  AlternateText="Chart" ImageAlign="AbsMiddle" Height="20"  Width="20px"
                 onclick="btnExportToExcel_Click" ToolTip="Export To Excel Directly"  />&nbsp;
             </div>

            </td>
        </tr>
    </table>
    <script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="../Scripts/Common.js" type="text/javascript"></script>
    <script src="SocialEconomicIndicatorReport.js" type="text/javascript"></script>
       <script language="javascript" type="text/javascript">

        function DdlCities_onclick() {

        }
    </script>
</asp:Content>
