<%@ Page Title="Work Experience" Language="C#" MasterPageFile="~/Popup.master" ValidateRequest="false" MaintainScrollPositionOnPostback="true"  AutoEventWireup="true" EnableEventValidation="false" Inherits="EnableIndia.Candidate.WorkExperiencePopup" Codebehind="WorkExperiencePopup.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width:800px;height:460px">
    <table id="TblEmploymentProjectDetail" runat="server" visible="false">
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <span>Employment Project : </span><span id="SpnEmploymentProjectName" class="readonlyText" runat="server"></span>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <span>Current Demand : </span><span id="SpnCurrentDemand" class="readonlyText" runat="server"></span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <table id="TblCandidateDetail" runat="server" visible="false">
        <tr>
            <td>
                 <table>
                    <tr>
                        <td>
                          <span class="readonly_bold_text">Candidate Name : </span><span id="SpnCandidateName" runat="server" class="readonlyText"></span>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <span class="readonly_bold_text">RID :</span><span id="SpnCandidateRID" runat="server" class="readonlyText"></span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <table id="TblCandidateDetailForEmployment" runat="server" visible="false">
        <tr>
            <td>
                 <table>
                    <tr>
                        <td>
                           Candidate Name:<span id="SpnCandidateNameEmployment" runat="server" class="readonlyText"></span>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            RID :<span id="SpnCandidateRIDEmployment" runat="server" class="readonlyText"></span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table id="TblGotJobDetail" runat="server" visible="false">
        <tr>
            <td>
                <table style="margin-top:10px;font-weight:bold">
                    <tr>
                        <td>
                            Candidate's Current Job As Stored in System:
                        </td>
                        <td>
                            <span id="SpnStatus" runat="server" style="font-weight:bold">Unemployed</span>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:ListView ID="LstViewExistingWorkExperience" runat="server">
                                <LayoutTemplate>
                                    <table id="TblExistingWorkExperience" cellpadding="2" class="tableBorder" cellspacing="0" rules="all" style="border-color:#808080; border: 1px solid blue;">
                                       <thead>
                                            <tr class="grid-header">
                                               <th>Company</th> 
                                               <th>Designation</th> 
                                               <th>From (MM/YYYY)</th> 
                                               <th>To (MM/YYYY)</th> 
                                            </tr>
                                       </thead>
                                       <tbody>
                                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                       </tbody>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr>
                                       <td runat="server" id="tdCompany" align="left"><%#Eval("company")%></td> 
                                       <td runat="server" id="tbDesig" align="left"><%#Eval("designation") %></td> 
                                       <td runat="server" id="tdFromDate" align="left"><%#Convert.ToDateTime(Eval("designation_from_date")).ToString("MM/yyyy")%></td> 
                                       <td runat="server" id="tdToDate" align="left"><%#Eval("str_to_date")%></td> 
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </td>
                    </tr>
                </table>
                <table style="margin-top:20px;font-weight:bold">
                    <tr>
                        <td>
                            Add New Current Job Details:
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td>
                <table cellpadding="2" cellspacing="0" border="0">
                    <tr>
                        <td align="left" style="width:103px" id="TdSelectCompany" runat="server"><label for="ctl00_ContentPlaceHolder1_DdlSelectCompany">SELECT COMPANY</label></td>
                        <td align="left">
                            <span id="SpnSelectCompany" runat="server" visible="false" />
                            <select id="DdlSelectCompany" runat="server" class="mandatory" messagetext="Company"
                                onchange="javascript:DdlSelectCompany_SelectedIndexChanged();">
                                <option value="-2">Select</option>
                                <option value="1">Listed Company</option>
                                <option value="2">Unlisted Company</option>
                            </select>
                        </td>
                    </tr>
                </table>
                <table cellpadding="2" cellspacing="0" border="0" id="TblParentCompanydetail" runat="server">
                    <tr>
                        <td align="left" style="width:103px" id="TdBlankUnlistedCompany" runat="server"></td>
                        <td align="left" id="TdUnlistedCompany" runat="server" visible="true">
                            <asp:TextBox ID="TxtUnlistedCompany" runat="server" Width="230px" ToolTip="COMPANY NAME"
                                messagetext="Unlisted company" />
                        </td>
                        <td align="left" id="TdParentCompany">
                            <label for="ctl00_ContentPlaceHolder1_DdlParentCompanies">PARENT COMPANY</label> <span id="SpnParentCompnies" runat="server" visible="false" /><br />
                            <select id="DdlParentCompanies" runat="server" style="width:200px"
                                title="Select parent company" messagetext="Parent company"
                                onchange="javascript:FilterCityStatesInPopup(this.value,'ParentCompanyID','DdlCompanies','DdlHiddenCompany');" />
                            <table style="display:none">
                                <tr>
                                    <td>
                                        <label for="ctl00_ContentPlaceHolder2_DdlHiddenCompany">HiddenCompany</label>
                                        <select id="DdlHiddenCompany" runat="server" />
                                        <span id="SpnHiddenCompanyID" runat="server" />
                                    </td> 
                                </tr>
                            </table>        
                        </td>
                        <td id="TdCompany" style="padding-left:30px">
                            <label for="ctl00_ContentPlaceHolder1_DdlCompanies" id="LblCompany" runat="server" >COMPANY</label><br />
                            <asp:DropDownList  runat="server" ID="DdlCompanies" messagetext="Company" AutoPostBack="false"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <table cellpadding="2" cellspacing="0" border="0" id="TblEmploymentComany" runat="server" visible="false" style="margin-top:5px">
                    <tr>
                        <td align="left">COMPANY : <span id="SpnCompanies" runat="server" visible="false" /></td>
                    </tr>
                </table>
                <table cellpadding="2" cellspacing="0" border="0" id="TblRole" runat="server">
                    <tr>
                        <td align="left" style="width:103px" id="TdSelectRole" runat="server" ><label for="ctl00_ContentPlaceHolder1_DdlRoles">SELECT ROLE</label></td>
                        <td align="left">
                            <span id="SpnSelectRole" runat="server" visible="false" /><span id="SpnJobRoles" runat="server" visible="false" />
                            <select id="DdlRoles" runat="server" class="mandatory" messagetext="Role"
                                onchange="javascript:DdlRoles_SelectedIndexChanged();">
                                <option value="-2">Select</option>
                                <option value="1">Listed Role</option>
                                <option value="2">Unlisted Role</option>
                            </select>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="padding-left:103px">
                            <select id="DdlJobRoles" runat="server" messagetext="Role" title="SELECT JOB ROLE" />
                            <asp:TextBox ID="TxtUnlistedRole" runat="server" Width="250px" ToolTip="ROLE NAME" messagetext="Unlisted role" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <table id="TblEmploymentDesignation" runat="server" visible="false" style="margin-top:5px;margin-bottom:5px">
        <tr>
            <td>Designation : <span id="SpnDesignation" runat="server" visible="false" /></td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td valign="top"><label for="TxtDesignation">Enter other details</label></td>
            <td></td>
            <td valign="top" id="TdDesignation" runat="server">
                <label for="ctl00_ContentPlaceHolder1_TxtDesignation">Designation</label><br />
                <asp:TextBox ID="TxtDesignation" runat="server" />
            </td>
            <td style="width:10px">&nbsp;</td>
            <td valign="top">
                <label for="ctl00_ContentPlaceHolder1_TxtDesignationFrom">FROM (MM/YYYY)</label><br />
                <asp:TextBox ID="TxtDesignationFrom" runat="server" Width="80px" class="mandatory" messagetext="From date" />
<%--                <cc1:MaskedEditValidator runat="server" ID="tbdtfv" ControlExtender="tbdtfe" ControlToValidate="TxtDesignationFrom"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender runat="server" ID="tbdtfe" TargetControlID="TxtDesignationFrom" ClearMaskOnLostFocus="True" InputDirection="LeftToRight" Enabled="True" Mask="99/9999" MaskType="None" ></cc1:MaskedEditExtender>
--%>                
            </td>
            <td style="width:10px"></td>
            <td style="white-space:nowrap">
                <table type="table" messagetext="Designation end date">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:RadioButton ID="RdbDesignationTo" runat="server"  onclick="javascript:ToggleContractExpiryDate();"  />
                                        <label for="ctl00_ContentPlaceHolder1_RdbDesignationTo" class="skiplink">Past Experience</label>
                                    </td>
                                    <td>
                                        <label for="ctl00_ContentPlaceHolder1_TxtDesignationTo">TO (MM/YYYY)</label><br />
                                        <asp:TextBox ID="TxtDesignationTo" runat="server"  Width="80px" class="mandatory" messagetext="End date" OnBlur="javascript:TxtDesignationTo_TextChanged();" />
 <%--                                          <cc1:MaskedEditValidator runat="server" ID="tbdtv" ControlExtender="tbdte" ControlToValidate="TxtDesignationTo"></cc1:MaskedEditValidator>
                                           <cc1:MaskedEditExtender runat="server" ID="tbdte" TargetControlID="TxtDesignationTo" ClearMaskOnLostFocus="True" InputDirection="LeftToRight" Enabled="True" Mask="99/9999" MaskType="None"  ></cc1:MaskedEditExtender>
 --%>                                   </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox runat="server" ID="RdbDesignationTillCurrentDate" Text="Current" OnCheckedChanged="rbCheckedChanged" AutoPostBack="true" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" style="padding-left:10px;padding-right:10px">Years
                <table>
                    <tr>
                        <td>
                            <span id="SpnYear" runat="server"></span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width:110px"></td>
            <td valign="top">
                <label for="ctl00_ContentPlaceHolder1_TxtMonthlySalary">Monthly Salary (Rs)</label><br />
                <asp:TextBox ID="TxtMonthlySalary" runat="server" Width="90px" />
               <cc1:FilteredTextBoxExtender ID="filTxt" runat="server" TargetControlID="TxtMonthlySalary" FilterMode="ValidChars" FilterType="Numbers"></cc1:FilteredTextBoxExtender>

            </td>
            <td>&nbsp;&nbsp;&nbsp;
               <asp:CheckBox runat="server" ID="cbWep" Text="Work Experiece Proof Got" Font-Bold="true" />
              </td> 
        </tr>
    </table>

    
    <table id="TblContractExpiryDate">
        <tr>
            <td>
                <label for="ctl00_ContentPlaceHolder1_TxtExpiryDate">For candidate on job contract, contract expiry date:</label>
            </td>
            <td>
                <asp:TextBox ID="TxtExpiryDate" runat="server" date="true" yearlength="4" />(DD/MM/YYYY)
            </td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td>
                <asp:Button ID="BtnManageWorkExperience" runat="server" Text="Add" ToolTip="Add"  style="margin-left:10px;"
                    OnClientClick="javascript:return ValidateWorkExperience();" OnClick="BtnManageWorkExperience_Click"  />
            </td>
            <td>
            <asp:Button runat="server" ID="btnClose" Text="Close" OnClick="btnClose_Click"   />
            </td>
            <td>
                <asp:Button ID="BtnDeleteWorkExperience" runat="server" Text="Delete" Visible="false"
                    style="margin-left:5px;" OnClick="BtnDeleteWorkExperience_Click"
                    OnClientClick="javascript:return confirm('Are you sure want to delete work experience ?');" />
                    <asp:HiddenField runat="server" ID="orgPage" />
                    <asp:HiddenField runat="server" ID="basePage" />
                    <asp:HiddenField runat="server" ID="txtParent" ClientIDMode="Static" />
            </td>
        </tr>
        <tr>
            <td valign="middle" align="center" colspan="3">
                <telerik:RadAjaxPanel runat="server" ID="radAjaxPanel">
                    <asp:Label CssClass="labelStyle" runat="server" ID="lbError" ForeColor="#D32232"></asp:Label>
                </telerik:RadAjaxPanel>
            </td>
        </tr>
    </table>
    </div>
    <script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="WorkExperiencePopup.js" type="text/javascript"></script>
</asp:Content>

