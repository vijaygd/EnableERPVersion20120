<%@ Page Title="Add vacancy" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Company.AddVacancy" Codebehind="AddVacancy.aspx.cs" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" class="pageHeader">Company Section</td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0"  class="pageHeaderLevel1" >
        <tr >
            <td colspan="2"><span id="SpnOperationStatus" runat="server">Add</span> Vacancy</td>
        </tr>
    </table>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink"><%=SpnOperationStatus.InnerText %> Vacancy</span></h1>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:250px">
            Date
        </td>
        <td>
             <span id="SpanDate" runat="server" class="readonlyText">24/12/2008</span>
        </td>
    </tr>
</table>


<table>
    <tr>
        <td style="width:250px">
          <h2><label for="ctl00_ContentPlaceHolder2_TxtVacancyName">VACANCY NAME:</label></h2>  
        </td>
        <td>
            <asp:TextBox ID="TxtVacancyName" runat="server" class="mandatory" messagetext="Vacancy Name"/>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:250px">
          <h2><label for="ctl00_ContentPlaceHolder2_DdlJobTypes">JOB TYPE</label></h2>  
        </td>
        <td>
            <select id="DdlJobTypes" runat="server" class="mandatory" messagetext="Job Type" type="select-one"
                onchange="javascript:DdlRecommendedJobType_SelectIndexChanged(this.value,'JobID','DdlJobRoles','DdlHiddenRoleName');"
            />&nbsp;&nbsp;&nbsp;
            <%--<asp:Button ID="BtnPopulateJobRoles" runat="server" Text="Refresh" OnClick="BtnPopulateJobRoles_Click" />--%>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:250px">
          <h2> <label for="ctl00_ContentPlaceHolder2_DdlJobRoles">ROLE NAME</label></h2> 
        </td>
        <td>
            <select id="DdlJobRoles" runat="server" class="mandatory" messagetext="Role Name" type="select-one"
                onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHiddenRecommendedRole').val($('#ctl00_ContentPlaceHolder2_DdlJobRoles').val());" />
        </td>
        <td>
            <table style="display:none">
                <tr>
                    <td>
                        <label for="ctl00_ContentPlaceHolder2_DdlHiddenRoleName">HiddenRoleName</label>
                        <select id="DdlHiddenRoleName" runat="server"/>
                        <span id="SpnHiddenRoleName" runat="server" />
                         <label for="ctl00_ContentPlaceHolder2_TxtHiddenRecommendedRole">Hidden Rcommeded role</label>
                         <asp:TextBox ID="TxtHiddenRecommendedRole" runat="server" />
                    </td> 
                </tr>
            </table>        
        </td>
    </tr>
</table>

<table>
    <tr>
        <td valign="top" style="width:250px">
            <h2>DISABILITY TYPE AND SUB-TYPE ACCEPTED:</h2> 

        </td>
        <td>
            Options<br />
            <asp:ListView ID="LstViewAcceptedDisabilitySubType" runat="server"
                OnItemDataBound="LstViewAcceptedDisabilitySubType_ItemDataBound">
                <LayoutTemplate>
                    <table id="TblAcceptedDisabilitySubType" class ="checkedListBox" messagetext="disability sub type">
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
                    <table cellspacing="0">
                        <tr>
                            <td id="textField" runat="server" style="width:60px"><%#Eval("disability_type")+ " - " + Eval("disability_sub_type")%></td>
                            <td>
                                <asp:CheckBox ID="ChkSelectDisabilitySubType" runat="server"
                                DisabilityTypeID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("disability_id"))) %>'
                                DisabilitySubTypeID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("disability_sub_type_id"))) %>'
                                Checked='<%#Convert.ToBoolean(Eval("is_attached")) %>'/>
                                <label id="lbDisabilitySubType" runat="server" class="skiplink">Test1</label>
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
        <td valign="top" style="width:250px"><h2>Educational Qualifications Required</h2>
        </td>
        <td>
            Options<br />
            <asp:ListView ID="LstViewEducationQualificationRequired" runat="server"
            OnItemDataBound="LstViewEducationQualificationRequired_ItemDataBound">
                <LayoutTemplate>
                    <table id="TblEducationQualificationRequired" class ="checkedListBox" >
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
                    <table cellspacing="0">
                        <tr>
                            <td id="textField" runat="server" style="width:60px"><%#Eval("course_qualification_name")%></td>
                            <td>
                                <asp:CheckBox ID="ChkSelectEducationalCourseQualification" runat="server"
                                EducationalQualificationID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("course_qualification_id"))) %>' 
                                Checked='<%#Convert.ToBoolean(Eval("is_attached")) %>'/>
                                <label id="lblEducationalCourseQualification" runat="server" class="skiplink" >Test2</label>
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
        <td valign="top" style="width:250px"><h2>Training candidate should have passed</h2></td>
        <%--<td valign="top" style="width:250px">TRAINING CANDIDATE SHOULD HAVE PASSED <br />
            <span id="SpanTrainingCandidateShouldHavePassed" class="message" runat="server">
                Candidate who have been marked
                as 'Employable Without 
                Training' will bypass this parameter.
            </span>
        </td>--%>
        <td>
            Options<br />
            <asp:ListView ID="LstViewTrainingCandidateShouldHavePassed" runat="server"
                 OnItemDataBound="LstViewTrainingCandidateShouldHavePassed_ItemDataBound">
                <LayoutTemplate>
                    <table id="TblTrainingCandidateShouldHavePassed" class ="checkedListBox" messagetext="Trainng Candidate Program">
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
                            <td id="textField" runat="server" style="width:60px"><%#Eval("training_program_name")%></td>
                            <td>
                                <asp:CheckBox ID="ChkSelectTraningCandidateprogram" runat="server"
                                TraningProgramID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("training_program_id"))) %>' 
                                Checked='<%#Convert.ToBoolean(Eval("is_attached")) %>'/>
                                <label id="lblTraningCandidateprogram" runat="server" class="skiplink" >Test3</label>
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
        <td valign="top" style="width:250px"><h2>Required Languages</h2></td>
        <td>
            Options<br />
            <asp:ListView ID="LstViewRequiredLanguage" runat="server"
                OnItemDataBound="LstViewRequiredLanguage_ItemDataBound">
                <LayoutTemplate>
                    <table id="TblLstViewRequiredLanguage" class ="checkedListBox ">
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
                            <td id="textField" runat="server" style="width:60px"><%#Eval("language_name")%></td>
                            <td>
                                <asp:CheckBox ID="ChkSelectRequiredLanguage" runat="server"
                                 LanguageID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("language_id"))) %>' 
                                 Checked='<%#Convert.ToBoolean(Eval("is_attached")) %>' />
                                <label id="lblRequiredLanguage" runat="server" class="skiplink">Test4</label>
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
        <td style="width:250px">
            <h2><label for="ctl00_ContentPlaceHolder2_TxtMonthlySalary">Monthly Salary Rs</label></h2> 
        </td>
        <td>
            <asp:TextBox ID="TxtMonthlySalary" runat="server"/>
        </td>
    </tr>
</table>    

<table>
    <tr>
        <td style="width:250px">
            <h2><label for="ctl00_ContentPlaceHolder2_TxtResponsibilityTaskList">RESPONSIBILITIES/TASK LIST</label></h2> 
        </td>
        <td>
            <asp:TextBox ID="TxtResponsibilityTaskList" runat="server" Width="600px"
                 class="mandatory" messagetext="Responsibilities/Task List"/>
        </td>
    </tr>
</table>   

<table>
    <tr>
        <td valign="top" style="width:250px"><h2>Groups of Candidate considered</h2> <br />
        </td>
        <td>
            Options<br />
            <asp:ListView ID="LstViewGroupsOfCandidatConsidered" runat="server"
                OnItemDataBound="LstViewGroupsOfCandidatConsidered_ItemDataBound">
                <LayoutTemplate>
                    <table id="TblGroupsOfCandidatConsidered" class="checkedListBox">
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
                            <td id="textField" runat="server" style="width:60px"><%#Eval("group_name")%></td>
                            <td>
                                <asp:CheckBox ID="ChkSelectGroupOfCandidate" runat="server"
                                CandidateGroupID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("group_id"))) %>' 
                                Checked='<%#Convert.ToBoolean(Eval("is_attached")) %>'/>
                                <label id="lblGroupOfCandidate" runat="server" class="skiplink" >Test5</label>
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
        <td style="width:250px">
           <h2><label for="ctl00_ContentPlaceHolder2_TxtInterventionRequired">Intervention Required</label></h2>  
        </td>
        <td>
            <asp:TextBox ID="TxtInterventionRequired" runat="server"/>
        </td>
    </tr>
</table>   

<table>
    <tr>
        <td style="width:250px">
           <h2><label for="ctl00_ContentPlaceHolder2_TxtWorkingDays">Working Days</label></h2>  
        </td>
        <td>
            <asp:TextBox ID="TxtWorkingDays" runat="server"/>
        </td>
    </tr>
</table>   

<table>
    <tr>
        <td style="width:250px"><h2>Shifts</h2> </td>
        <td style="white-space:nowrap">
            <div style="width:100px">
               Yes
              <asp:RadioButton ID="RdbYes" runat="server" GroupName="DataSubmission"/>
            <label for="ctl00_ContentPlaceHolder2_RdbYes" class="skiplink">Shifts YES</label>&nbsp;
            </div>
        </td>
        <td style="white-space:nowrap">
            <div style="width:100px">
            No
            <asp:RadioButton ID="RdbNo" runat="server" GroupName="DataSubmission" />
            <label for="ctl00_ContentPlaceHolder2_RdbNo" class="skiplink">No shifts</label>
           </div>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:250px">
           <h2> <label for="ctl00_ContentPlaceHolder2_TxtWorkingHours">Working Hours</label></h2> 
        </td>
        <td>
            <asp:TextBox ID="TxtWorkingHours" runat="server"/>
        </td>
    </tr>
</table> 


<table>
    <tr>
        <td style="width:250px" valign="top">
            <h2><label for="ctl00_ContentPlaceHolder2_TxtHolidayAndLeavePolicy">Comments</label></h2> 
        </td>
        <td>
            <asp:TextBox ID="TxtHolidayAndLeavePolicy" runat="server" Width="250px" Height="50px" TextMode="MultiLine"/>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:244px"></td>
        
        <td>
            <asp:Button ID="BtnManageVacancy" Text="Submit" runat="server" 
                OnClientClick="javascript:return ValidateSalaryInVacancy();" onclick="BtnManageVacancy_Click" />
        </td>
        <td>
            <%--<input id="BtnClear" type="reset" />--%>
            <asp:Button ID="BtnClear" runat="server" Text="Clear" OnClick="BtnClear_Click" />
        </td>
    </tr>
</table>
<script src="AddVacancy.js" type="text/javascript"></script>
</asp:Content>



