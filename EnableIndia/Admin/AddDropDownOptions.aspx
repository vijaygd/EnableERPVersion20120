<%@ Page Title="Add Data Options" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" Inherits="EnableIndia.Admin.AddDropDownOptions" Codebehind="AddDropDownOptions.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageHeader">Administration Section--Handle With Care!</td>
        </tr>
    </table>    
    <table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">    
        <tr>
            <td>Add Data Options</td>
        </tr>
     </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink">Add Data Options</span></h1>    
        </td>
    </tr>
</table>
<table cellpadding="4">
    <tr>
        <td>
            <table>
                <tr>
                    <td style="width:133px"><label for="ctl00_ContentPlaceHolder2_DdlParameters">PARAMETER</label></td>
                    <td>
                        <select id="DdlParameters" runat="server" onchange="javascript:DdlParameters_SelectedIndexChanged();">
                            <option para="edu" 
                                identitycolumn="course_qualification_id" 
                                TableName="courses_qualifications" 
                                ColumnName="course_qualification_name"
                                value="Education">Education</option>
                            <option para="dis_sub" 
                                IdentityColumn="disability_sub_type_id"
                                TableName="disability_sub_types" 
                                ColumnName="disability_sub_type"
                                value="Disability Sub Type">Disability Sub Type</option>
                            <option para="job"
                                IdentityColumn="job_id"
                                TableName="jobs" 
                                ColumnName="job_name"
                                value="Job Type" >Job Type</option>
                            <option para="role"
                                IdentityColumn="job_role_id"
                                TableName="job_roles" 
                                ColumnName="job_role_name"
                                value="Job Role">Role</option>
                            <option para="cand_grp"
                                IdentityColumn="group_id"
                                TableName="candidate_groups" 
                                ColumnName="group_name"
                                value="Candidate Group">Candidate Group</option>
                            <option para="countr"
                                IdentityColumn="country_id"
                                TableName="countries" 
                                ColumnName="country_name"
                                value="Country">Country</option>
                            <option para="st"
                                IdentityColumn="state_id"
                                TableName="states" 
                                ColumnName="state_name"
                                value="State">State</option>
                            <option para="cit"
                                IdentityColumn="city_id"
                                TableName="cities" 
                                ColumnName="city_name"
                                value="City">City</option>
                            <option para="can_flg"
                                IdentityColumn="flag_id"
                                TableName="candidate_flags" 
                                ColumnName="flag_name"
                                value="Candidate Flag">Candidate Flag</option>
                            <option para="comp_flg"
                                IdentityColumn="flag_id"
                                TableName="company_flags" 
                                ColumnName="flag_name"
                                value="Company Flag">Company Flag</option>
                            <option para="lang"
                                IdentityColumn="language_id"
                                TableName="languages" 
                                ColumnName="language_name"
                                value="Languages">Languages Known</option>
                            <option para="indu_seg" 
                                value="Industry Segment"
                                IdentityColumn="industry_segment_id"
                                TableName="industry_segments" 
                                ColumnName="industry_segment">
                                Industry Segment
                            </option>
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
            
            <table id="TblJobs" style="display:none">
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
            
            <table  id="TblJobRole" group="Parameters" style="display:none" >
                <tr>
                    <td style="width:133px"><label for="ctl00_ContentPlaceHolder2_TxtJobRole">ADD NEW ROLE FOR JOB TYPE</label></td>
                    <td><asp:TextBox ID="TxtJobRole" runat="server" Width="200px" messagetext="Role" /></td>
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
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="AddDropDownOptions.js" type="text/javascript"></script>
</asp:Content>