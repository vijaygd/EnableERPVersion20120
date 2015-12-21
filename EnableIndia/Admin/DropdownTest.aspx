<%@ Page Title="Dropdown Test" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" Inherits="EnableIndia.Admin.DropdownTest" Codebehind="DropdownTest.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">Administration Section--Handle With Care!</td>
        </tr>
    </table>    
    <table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">    
        <tr>
            <td>Add Drop-down Options</td>
        </tr>
     </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink">Add Drop-down Options</span></h1>    
        </td>
    </tr>
</table>
<%--<h1 id="skipToTop">Add Drop-down Options </h1>--%>
<table cellpadding="4">
    <tr>
        <td>
            <table>
                <tr>
                    <td style="width:133px"><label for="ctl00_ContentPlaceHolder2_DdlParameters">PARAMETER</label></td>
                    <td>
                        <select id="DdlParameters" runat="server" onchange="javascript:DdlParameters_SelectedIndexChanged();">
                            <option para="edu" 
                                IdentityColumn="course_qualification_id" 
                                TableName="courses_qualifications" 
                                ColumnName="course_qualification_name"
                                value="Education">Education</option>
                            <%--<option value="Disability Type" para="dis">Disability Type</option>--%>
                            <option para="dis_sub" 
                                IdentityColumn="disability_sub_type_id"
                                TableName="disability_sub_types" 
                                ColumnName="disability_sub_type"
                                value="Disability Sub Type">Disability Sub Type</option>
                            <option value="Job Type" para="job"
                                IdentityColumn="job_id"
                                TableName="jobs" 
                                ColumnName="job_name"
                                >Job Type</option>
                            <option value="Job Role" para="role"
                                IdentityColumn="job_role_id"
                                TableName="job_roles" 
                                ColumnName="job_role_name"
                                >Role</option>
                            <option value="Candidate Group" para="cand_grp"
                                IdentityColumn="group_id"
                                TableName="candidate_groups" 
                                ColumnName="group_name"
                                >Candidate Group</option>
                            <option value="Country" para="countr"
                                IdentityColumn="country_id"
                                TableName="countries" 
                                ColumnName="country_name"
                                >Country</option>
                            <option value="State" para="st"
                                IdentityColumn="state_id"
                                TableName="states" 
                                ColumnName="state_name"
                                >State</option>
                            <option value="City" para="cit"
                                IdentityColumn="city_id"
                                TableName="cities" 
                                ColumnName="city_name"
                                >City</option>
                            <option value="Candidate Flag" para="can_flg"
                                IdentityColumn="flag_id"
                                TableName="candidate_flags" 
                                ColumnName="flag_name"
                                >Candidate Flag</option>
                            <option value="Company Flag" para="comp_flg"
                                IdentityColumn="flag_id"
                                TableName="company_flags" 
                                ColumnName="flag_name"
                                >Company Flag</option>
                            <option value="Languages" para="lang"
                                IdentityColumn="language_id"
                                TableName="languages" 
                                ColumnName="language_name"
                                >Languages Known</option>
                        </select>&nbsp;&nbsp;
                    </td>
                    <td>
                        <input id="BtnViewOptions" type="button" value="View Existing" onclick="javascript:BtnViewOptions_Click();" />
                    </td>
                </tr>
            </table>
            
            <table id="TblDisabilityTypes" group="Parameters" style="display:none">
                <tr>
                    <td style="width:133px"><label for="ctl00_ContentPlaceHolder2_DdlDisabilityTypes">DISABILITY TYPE</label></td>
                    <td><select id="DdlDisabilityTypes" runat="server" class="mandatory" messagetext="Disability type" /></td>
                </tr>
            </table>
            
            <table id="TblJobs" group="Parameters" style="display:none">
                <tr>
                    <td style="width:133px"><label for="ctl00_ContentPlaceHolder2_DdlJobs">JOB TYPE</label></td>
                    <td><select id="DdlJobs" runat="server" class="mandatory" messagetext="Job type" /></td>
                </tr>
            </table>
            
            <table id="TblCountry" group="Parameters" style="display:none">
                <tr>
                    <td style="width:133px"><label for="ctl00_ContentPlaceHolder2_DdlCountries">COUNTRY</label></td>
                    <td style="white-space:nowrap">
                        <select id="DdlCountries" runat="server" class="mandatory" messagetext="Country"
                            onchange="javascript:FilterCityStates(this.value,'CountryID','DdlStates','DdlHiddenStates');" />&nbsp;&nbsp;
                        <asp:Button ID="BtnRefreshStates" runat="server" Text="Refresh" style="display:none" IsRefresh="true" Visible="false"
                            OnClick="BtnRefreshStates_Click" />
                    </td>
                </tr>
            </table>
            
            <table style="display:none">
                <tr>
                    <td><label for="ctl00_ContentPlaceHolder2_DdlHiddenStates">HiddenDropDown</label></td>
                    <td><select id="DdlHiddenStates" runat="server" /></td>
                </tr>
            </table>
            
            <table id="TblState" group="Parameters" style="display:none">
                <tr>
                    <td style="width:133px"><label for="ctl00_ContentPlaceHolder2_DdlStates">STATE</label></td>
                    <td><select id="DdlStates" runat="server" class="mandatory" messagetext="State" /></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:133px"><label for="ctl00_ContentPlaceHolder2_TxtNewType">ADD NEW TYPE FOR SELECTED PARAMETER</label></td>
                    <td><asp:TextBox ID="TxtNewType" runat="server" Width="200px" class="mandatory" messagetext="Type" /></td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td style="width:133px">&nbsp;</td>
                    <td>
                        <asp:Button ID="BtnAddParameter" runat="server" Text="Submit" OnClientClick="javascript:return ValidateForm();" 
                            IsSubmit="true" OnClick="BtnAddParameter_Click" />&nbsp;&nbsp;
                        <asp:Button ID ="BtnClearParameter" runat="server" Text="Clear" 
                            onclick="BtnClearParameter_Click" />    
                       <%-- <input id="BtnClear" type="reset" value="Clear" />--%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<script src="DropDownTest.js" type="text/javascript"></script>
</asp:Content>

