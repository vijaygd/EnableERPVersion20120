<%@ Page Title="Add Training Program" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Training.AddTrainingProgram" Codebehind="AddTrainingProgram.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td colspan ="2" class="pageHeader">
            Training Section
        </td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" class="pageHeaderLevel1">
    <tr>
        <td colspan="2">
            <asp:Label CssClass="labelStyle" ID="LblTitle" runat="server" Text="Add Training Program" MessageStartText="Add " />
        </td>
    </tr>
</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink"><%= LblTitle.Text%></span></h1>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px">
          <h2><label for="ctl00_ContentPlaceHolder2_TxtTrainingProgramName">NAME OF TRAINING PROGRAM:</label></h2>  
        </td>
        <td>
           <asp:TextBox ID="TxtTrainingProgramName" Width="300px" runat="server"
                class="mandatory" messagetext="Name of training program" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td valign="top" style="width:200px"><h2>DISABILITY TYPES:</h2> </td>
        <td>
            Options<br />
            <asp:ListView ID="LstViewTrainingProgramEligibleDisabilityTypes" runat="server"
                OnItemDataBound="LstViewTrainingProgramEligibleDisabilityTypes_ItemDataBound" >
                <LayoutTemplate>
                    <table id="TblTrainingProgramEligibleDisabilityTypes" class="checkedListBox mandatory"
                        messagetext="eligible disability" >
                        <tbody>
                            <tr>
                                <td>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>   
                    <table cellpadding="0">
                        <tr>
                            <td id="textField" runat="server" style="width:56px">
                                <%#Eval("disability_type")%>
                            </td>
                            <td>
                                 <asp:CheckBox ID="ChkSelectDisabilityType" runat="server" 
                                    DisabilitypeID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("disability_id"))) %>'
                                    Checked='<%#Convert.ToBoolean(Eval("is_attached")) %>' />
                                 <label id="lblDisabilitytype" runat="server" class="skiplink">Test1</label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td valign="top" style="width:200px"><h2>Eligible Groups:</h2> </td>
        <td>
            Options<br />
            <asp:ListView ID="LstViewTrainingProgramEligibleGroups" runat="server" 
                 OnItemDataBound="LstViewTrainingProgramEligibleGroups_ItemDataBound">
                <LayoutTemplate>
                    <table id="TblTrainingProgramEligibleGroups" class="checkedListBox">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>   
                     <table cellpadding="0">
                        <tr>
                            <td id="textField" runat="server" style="width:56px"><%#Eval("group_name")%></td>
                            <td>
                                 <asp:CheckBox ID="ChkSelectGroup" runat="server" 
                                    GroupID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("group_id"))) %>'
                                    Checked='<%#Convert.ToBoolean(Eval("is_attached")) %>' />
                                 <label id="lblGroup" runat="server" class="skiplink">Test3</label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td valign="top" style="width:200px"><h2> Eligible Educational Qualification:</h2></td>
        <td>
            Options<br />
            <asp:ListView ID="LstViewTrainingProgramEligibleEducationalQualification" runat="server" 
                 OnItemDataBound="LstViewTrainingProgramEligibleEducationalQualification_ItemDataBound">
                <LayoutTemplate>
                    <table id="TblEligibleEducationalQualification" class="checkedListBox">
                        <tbody>
                                <tr>
                                    <td>
                                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                    </td>
                                </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>  
                    <table cellpadding="0">
                        <tr>
                            <td id="textField" runat="server" style="width:56px"><%#Eval("course_qualification_name")%></td>
                            <td>
                                 <asp:CheckBox ID="ChkSelectEligibleEducatinalQualification" runat="server" 
                                    CourseID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("course_qualification_id"))) %>'
                                    Checked='<%#Convert.ToBoolean(Eval("is_attached")) %>' />
                                 <label id="lblEligibleEducatinalQualification" runat="server" class="skiplink">Test4</label>
                            </td>
                        </tr>
                    </table> 
                </ItemTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td valign="top" style="width:200px"><h2>Recommended Job Types and Roles :</h2> </td>
        <td>
            Options<br />
            <asp:ListView ID="LstViewTrainingProgramRecommendedRoles" runat="server" 
                 OnItemDataBound="LstViewTrainingProgramRecommendedRoles_ItemDataBound">
                <LayoutTemplate>
                    <table id="TblTrainingProgramRecommendedRoles" class="checkedListBox">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>  
                    <table cellpadding="0">
                        <tr>
                            <td id="textField" runat="server" style="width:56px"><%#Eval("job_name") + " - " + Eval("job_role_name")%></td>
                            <td>
                                 <asp:CheckBox ID="ChkSelectTrainingProgramRecommendedRoles" runat="server"
                                    JobRoleID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("job_role_id"))) %>'
                                    Checked='<%#Convert.ToBoolean(Eval("is_attached")) %>' />
                                 <label id="lblRecommendedRoles" runat="server" class="skiplink">Test5</label>
                            </td>
                        </tr>
                    </table> 
                </ItemTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td valign="top" style="width:200px"><h2> Required Languages:</h2></td>
        <td>
            Options<br />
            <asp:ListView ID="LstViewTrainingProgramRequiredLanguages" runat="server"
                 OnItemDataBound="LstViewTrainingProgramRequiredLanguages_ItemDataBound">
                <LayoutTemplate>
                    <table id="TblTrainingProgramRequiredLanguagess" class="checkedListBox">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>  
                    <table cellpadding="0">
                        <tr>
                            <td id="textField" runat="server" style="width:56px"><%#Eval("language_name")%></td>
                            <td>
                                 <asp:CheckBox ID="ChkSelectRequiredLanguage" runat="server" 
                                    LanguageID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("language_id"))) %>'
                                    Checked='<%#Convert.ToBoolean(Eval("is_attached")) %>' />
                                 <label id="lblRequiredLanguage" runat="server" class="skiplink">Test6</label>
                            </td>
                        </tr>
                    </table>  
                </ItemTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td valign="top" style="width:200px"><h2> Pre-requisite/Training Candidate should have passed:</h2></td>
        <td>
            Options<br />
            <asp:ListView ID="LstViewTrainingProgramCandidateShouldHavePassed" runat="server"
             OnItemDataBound="LstViewTrainingProgramCandidateShouldHavePassed_ItemDataBound">
                <LayoutTemplate>
                    <table id="TblTrainingProgramCandidateShouldHavePassed" class="checkedListBox">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate> 
                    <table cellpadding="0">
                        <tr>
                            <td id="textField" runat="server" style="width:56px"><%#Eval("training_program_name")%></td>
                            <td>
                                 <asp:CheckBox ID="ChkSelectTrainingCandidate" runat="server" 
                                    TraininProgramID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("training_program_id"))) %>'
                                    Checked='<%#Convert.ToBoolean(Eval("is_attached")) %>' />
                                 <label id="lblTrainingCandidate" runat="server" class="skiplink">Test7</label>
                            </td>
                        </tr>
                    </table>    
                </ItemTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px">
          <h2><label for="ctl00_ContentPlaceHolder2_TxtComments">Comments:</label></h2>  
        </td>
        <td>
           <asp:TextBox ID="TxtComments" Width="350px" runat="server" TextMode="MultiLine" Height="40px"/>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px"></td>
        <td>
            <asp:Button ID="BtnManageTrainingProgram" runat="server" Text="Submit" OnClientClick="javascript:return ValidateForm();" 
                IsSubmit="true" OnClick="BtnManageTrainingProgram_Click" />
        </td>
        <td>
            <asp:Button ID ="BtnClear" runat="server" Text="Clear"  OnClick="BtnClear_Click"/>
        </td>
    </tr>
</table>

<script src="AddTrainingProgram.js" type="text/javascript"></script>
</asp:Content>

