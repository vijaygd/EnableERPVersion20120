<%@ Page Title="Educational Qualifications" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true" Inherits="EnableIndia.Candidate.EducationalQualificationsPopUp" Codebehind="EducationalQualificationsPopUp.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div></div>
<table>
    <tr>
        <td>EDUCATIONAL QUALIFICATIONS (Passed Only)</td>
    </tr>
</table>
<table cellspacing="0" cellpadding="7">
    <tr>
        <td style="width:148px">
            <label for="ctl00_ContentPlaceHolder1_DdlCoursesQualifications">COURSE/QUALIFICATIONS</label><br />
            <select id="DdlCoursesQualifications" runat="server" class="mandatory" messagetext="Course/Qualifications" />
        </td>
        <td style="width:10px">&nbsp;</td>
        <td style="width:150px">
            <label for="ctl00_ContentPlaceHolder1_TxtPassingYear">PASSING YEAR (YYYY)</label><br />
            <asp:TextBox ID="TxtPassingYear" runat="server" class="mandatory" messagetext="Passing year"  />
        </td>
        <td style="width:10px">&nbsp;</td>
        <td style="width:150px" valign="top">
            <label for="ctl00_ContentPlaceHolder1_TxtPercentage">Percentage</label><br />
            <asp:TextBox ID="TxtPercentage" runat="server" />
        </td>
        <td style="width:10px">&nbsp;</td>
        <td valign="top">
            <label for="ctl00_ContentPlaceHolder1_TxtDetails">Details</label><br />
            <asp:TextBox ID="TxtDetails" runat="server" />
        </td>
        <td style="width:10px">&nbsp;</td>
    </tr>
</table>
<table>
    <tr>
        <td>
            <label for="ctl00_ContentPlaceHolder1_TxtOtherEducationalQualifications">Other Educational Qualifications (eg. Currently doing)</label>
            <asp:TextBox ID="TxtOtherEducationalQualifications" runat="server" Width="480px" />
        </td>
    </tr>
</table>
<table>
    <tr>
         <td>
            <asp:Button ID="BtnAddUpdateQualifications" runat="server" Text="Submit" ToolTip="Submit" OnClick="BtnAddUpdateQualifications_Click"
                OnClientClick="javascript:return ValidateYear();$(this).attr('disabled','disabled');" />
         </td>
         <td>   
            <asp:Button ID="BtnCloseQualifications" runat="server" Text="Close" ToolTip="Close" OnClientClick="javascript:self.close();return false;" />
        </td>
        <td>
            <asp:Button ID="BtnDeleteQualification" runat="server" Text="Delete" ToolTip="Delete" Visible="false"
                OnClientClick="javascript:return confirm('Are you sure want to delete Educational qualification ?');" 
                onclick="BtnDeleteQualification_click" /></td>
            <asp:HiddenField runat="server" ID="txtParent" ClientIDMode="Static" />

    </tr>
</table>
<script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="../Scripts/Common.js" type="text/jscript"></script>
<script src="EducationalQualificationsPopUp.js" type="text/jscript"></script>
</asp:Content>

