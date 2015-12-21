<%@ Page Title="Add Company" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Company.AddCompany" Codebehind="AddCompany.aspx.cs" ClientIDMode="Static" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellpadding="0" cellspacing="0">
    <tr>
        <td colspan="2" class="pageHeader">Company Section</td>
    </tr>
     </table>
    <table cellpadding="0" cellspacing="0"  class="pageHeaderLevel1" >
        <tr>
            <td colspan="2"><span id="SpnOperationStatus" runat="server">Add</span> Company</td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink"><%=SpnOperationStatus.InnerText %> Company</span></h1>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:158px">
            <label for="ctl00_ContentPlaceHolder2_DdlParentCompanies">NAME OF PARENT COMPANY</label>
        </td>
        <td>
            <select id="DdlParentCompanies" runat="server" class="mandatory" type="select-one" messagetext="Parent company" />
            <span id="SpnParentCompanyName" runat="server" class="readonly_bold_text" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:158px">
            <label for="ctl00_ContentPlaceHolder2_TxtCompanyCode">COMPANY</label>
        </td>
        <td>
            <asp:TextBox ID="TxtCompanyCode" runat="server" class="mandatory" messagetext="Company" Width="300px" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:158px">
            <label for="ctl00_ContentPlaceHolder2_TxtPhoneLandlineOfOffice">PHONE/LANDLINE OF OFFICE</label>
        </td>
        <td>
            <asp:TextBox ID="TxtPhoneLandlineOfOffice" runat="server" class="mandatory" messagetext="Phone number" 
                phonenumber="true" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:158px">
            <label for="ctl00_ContentPlaceHolder2_TxtFax">Fax</label>
        </td>
        <td>
            <asp:TextBox ID="TxtFax" runat="server"/>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:158px">
            <label for="ctl00_ContentPlaceHolder2_TxtWebsite">Website</label>
        </td>
        <td>
            <asp:TextBox ID="TxtWebsite" runat="server"/>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:158px">
            <label for="ctl00_ContentPlaceHolder2_TxtAddress">ADDRESS </label>
        </td>
        <td style="width:478px" >
            Building, Lane<br />
            <asp:TextBox ID="TxtAddress" runat="server" Width="420px" class="mandatory" messagetext="Address" />&nbsp;
        </td>
    </tr>
</table>

<table cellspacing="0" cellpadding="0" style="margin-left:165px">
    <tr>
        <td>
            <label for="ctl00_ContentPlaceHolder2_DdlStates">STATE</label><br />
            <select id="DdlStates" runat="server" class="mandatory" type="select-one" messagetext="State"
                onchange="javascript:FilterCityStates(this.value,'StateID','DdlCities','DdlHiddenCities');"  />
            <%--<asp:Button ID="BtnPopulateStates" runat="server" Text="Refresh" OnClick="BtnPopulateStates_Click" />--%>
        </td>
        <td style="width:15px">&nbsp;</td>
        <td>
            <label for="ctl00_ContentPlaceHolder2_DdlCities">CITY</label><br />
             <select id="DdlCities" runat="server" class="mandatory" type="select-one" messagetext="City" enableviewstate="true" groupname="select-one" />
        </td>
        <td style="width:15px">
            <table style="display:none">
                <tr>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_DdlHiddenCities">HiddenCity</label>
                        <select id="DdlHiddenCities" runat="server" />
                        <span id="SpnHiddenCityID" runat="server" />
                    </td> 
                </tr>
           </table>        
            &nbsp;</td>
        <td>
            <label for="ctl00_ContentPlaceHolder2_TxtPinCode">PIN-CODE</label><br />
            <asp:TextBox ID="TxtPinCode" runat="server" class="mandatory" messagetext="Pincode" MaxLength="6" />
            <cc1:FilteredTextBoxExtender ID="filTxt" runat="server" TargetControlID="TxtPinCode" FilterMode="ValidChars" FilterType="Numbers"></cc1:FilteredTextBoxExtender>

        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:158px" valign="top">
            <label for="ctl00_ContentPlaceHolder2_TxtCompanyDetails">Company Details</label>
        </td>
        <td>
            <asp:TextBox ID="TxtCompanyDetails" runat="server" Height="70px" Width="420px" TextMode="MultiLine"/>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:158px" >
            <label for="ctl00_ContentPlaceHolder2_DdlIndustrialSegment">INDUSTRY SEGMENT</label>
        </td>
        <td>
            <select id="DdlIndustrialSegment" runat="server" class="mandatory" type="select-one" messagetext="Industry Segment"  />
        </td>
       
    </tr>
</table>

<table>
    <tr>
        <td>
            <asp:ListView ID="LstViewAddCompany" runat="server">
                <LayoutTemplate>
                    <table id="TblAddCompany" cellpadding="4" class="tableBorder" cellspacing="0" rules="all" style="border-color:#808080; border-width:1px;">
                        <thead>
                            <tr class="grid-header">
                                <th align="right">No.</th>
                               <%-- <th><span class="skiplink">Radio button for selecting row to update</span></th>--%>
                                <th>Type of Contact</th>
                                <th>Name of contact</th>
                                <th>Designation</th>
                                <th>Phone Number</th>
                                <th>E-mail Address</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                     <tr>
                         <td id="TdRecordNumber" align="right"></td>
                         <th align="left"><%#Eval("contact_type") %></th>
                         <td align="left">
                            <asp:LinkButton ID="LnkBtnCompanyContactName" runat="server"
                                Text='<%#Eval("contact_name") %>'
                                CompanyContactID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("contact_id"))) %>'
                                onclick="LnkBtnCompanyContactName_Click" />
                         </td>
                         <td align="left"><%#Eval("designation")%></td>
                         <td align="right"><%#Eval("phone_number") %></td>
                         <td align="left">
                            <a id="LnkBtnCandidateName" class="readonlyText"
                                href='mailto:<%#Eval("email_address") %>'><%#Eval("email_address") %></a>
                         </td>  
                     </tr>
                </ItemTemplate>
            </asp:ListView>
        </td>
        <td valign="top"></td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:158px">
            <asp:Button ID="BtnAddCompanyContact" runat="server" Text="Add Company Contact" 
                onclick="BtnAddCompanyContact_Click" />
        </td>
        <td>
            <asp:Button ID="BtnManageCompany" Text="Submit" runat="server" OnClientClick="javascript:return ValidateDropDowns();"
                OnClick="BtnManageCompany_Click" />
        </td>
        <td>
            <asp:Button ID="BtnClear" runat="server" Text="Clear" OnClick="BtnClear_Click" />
        </td>
    </tr>
</table>
     <center>
     <div style="width:990px; height:650px;">
        <telerik:RadWindowManager runat="server" ID="radManager" EnableViewState="false" DestroyOnClose="true" VisibleOnPageLoad="false"  AutoSize="true" Top="0"  Height="680px" Width="900px" Modal="true" CssClass="RadWindow">
        </telerik:RadWindowManager>
     </div>
     </center>

    <script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="AddCompany.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
    function ValidateDropDowns() {
        if(!ValidateForm())
        {
           return false;
        }
        // Check for state.....
        var statedd = document.getElementById("DdlStates").selectedIndex;
        if (statedd <= 0) {
            alert("State missing");
            return false;
        }
        var citydd = document.getElementById("DdlCities").selectedIndex;
        if(citydd <= 0)
        {
            alert("City Missing");
           return false;
        }
        return true;
    }                                 
</script>

</asp:Content>


