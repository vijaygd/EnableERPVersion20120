<%@ Page Title="Add Employment Projects" Language="C#" MasterPageFile="~/Candidate/Candidate.master" AutoEventWireup="true" Inherits="EnableIndia.Company.AddEmploymentProjects" Codebehind="AddEmploymentProjects.aspx.cs" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" class="pageHeader">Company Section</td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0"  class="pageHeaderLevel1" >
        <tr >
            <td colspan="2"><span id="SpnOperationStatus" runat="server">Add</span> Employment Project</td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table cellpadding="0" cellspacing="0" class="skiplink">
    <tr>
        <td>
            <h1><span id="skipToTop" class="skiplink" style="color:White"><%=SpnOperationStatus.InnerText %> Employment Project</span></h1>
        </td>
    </tr>
</table>

<table id="TblBlankMessage" runat="server" visible="false" style="margin-bottom:20px">
    <tr>
        <td style="padding-left:300px">
        <span style="font-weight:bold">No Data Found</span>
        </td>
    </tr>
</table>

<table id="TblEmploymentProjectFrNoData" runat="server" visible="true">
    <tr>
        <td>
            <table>
                <tr>
                    <td style="width:200px">
                        <label for="ctl00_ContentPlaceHolder2_DdlParentCompany">SELECT PARENT COMPANY</label>
                    </td>
                    <td>
                       <select id="DdlParentCompany" runat="server" class="mandatory" messagetext="Parent Company"
                        onchange="javascript:FilterCityStates(this.value,'ParentCompanyID','DdlCompanyCode','DdlHiddenCompanyCode');$('#ctl00_ContentPlaceHolder2_DdlCompanyCode').change();"  />&nbsp;&nbsp;&nbsp;
                       <span id="SpnParentCompany" runat="server"/>
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td style="width:200px">
                        <label for="ctl00_ContentPlaceHolder2_DdlCompanyCode">SELECT COMPANY</label>
                    </td>
                    <td>
                       <select id="DdlCompanyCode" runat="server" class="mandatory" messagetext="Company Code" 
                            onchange="javascript:$('#TxtHiddenCompanyID').val($('#DdlCompanyCode').val()); " />&nbsp;&nbsp;&nbsp;
                        <span id="SpnCompanyCode" runat="server" />
                    </td>
                    <td>
                        <table style="display:none" >
                            <tr>
                                <td>
                                    <label for="ctl00_ContentPlaceHolder2_DdlHiddenCompanyCode">HiddenCompanyCode</label>
                                    <select id="DdlHiddenCompanyCode" runat="server" />
                                    <label for="ctl00_ContentPlaceHolder2_TxtHiddenCompanyID">HiddenText</label>
                                    <asp:TextBox ID="TxtHiddenCompanyID" runat="server">1</asp:TextBox>
                                    <%--<span id="SpnHiddenCompanyID" runat="server">-1</span>--%>
                                </td> 
                            </tr>
                        </table>        
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td style="width:200px">
                        <label for="ctl00_ContentPlaceHolder2_DdlVacancyCode">IMPORT VACANCY</label>
                    </td>
                    <td>
                       <select id="DdlVacancyCode" runat="server" class="mandatory" messagetext="Vacancy Code"
                            onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHiddenVacanciesValue').val('0');" />&nbsp;&nbsp;&nbsp;
                       <asp:Button ID="BtnPopulatesVacancyDetail" runat="server"  Text="Go"
                            OnClientClick="javascript:return ValidateVacancyDropDown();"  
                            OnClick="BtnPopulatesVacancyDetail_Click" />
                       <span id="SpnVacancyCode" runat="server" />
                    </td>
                    <td>
                        <table style="display:none"  >
                            <tr>
                                <td>
                                    <label for="ctl00_ContentPlaceHolder2_TxtHiddenVacanciesValue">Hiddenvalue</label>
                                    <asp:TextBox ID="TxtHiddenVacanciesValue" runat="server"></asp:TextBox>
                                </td> 
                            </tr>
                        </table>        
                    </td>
                </tr>
            </table>

<table id="TblVacancyDetail" runat="server" visible="false">
    <tr>
       <td>
            <table id="TblEmploymentProjectName" runat="server" visible="false">
                <tr style="font-size:11px">
                    <td style="width:200px"  class="readonly_bold_text" >
                        Employment Project Name
                    </td>
                    <td >
                        <span id="SpnEmploymentProjectName" runat="server" class="readonlyText"></span>
                    </td>
                </tr>
            </table>
             <table id="TblEmploymentProjectDate" runat="server" visible="false">
                <tr style="font-size:11px">
                    <td style="width:200px" class="readonly_bold_text">
                        Creation Date
                    </td>
                    <td >
                        <span id="SpnCreationDate" runat="server" class="readonlyText"></span>
                    </td>
                    <td>
                        <span id="SpnCreationTime" runat="server" class="readonlyText"></span>
                    </td>
                </tr>
            </table>
           <table>
            <tr>
                <td style="width:200px">
                  <h2> <label for="ctl00_ContentPlaceHolder2_DdlJobTypes">JOB TYPE</label></h2> 
                </td>
                <td>
                    <select id="DdlJobTypes" runat="server" class="mandatory" messagetext="Job Type"
                        onchange="javascript:DdlRecommendedJobType_SelectIndexChanged(this.value,'JobID','DdlJobRoles','DdlHiddenRoleName');"
                    />&nbsp;&nbsp;&nbsp;
                    <%--<asp:Button ID="BtnPopulateJobRoles" runat="server" Text="Refresh" OnClick="BtnPopulateJobRoles_Click" />--%>
                </td>
            </tr>
        </table>

        <table>
            <tr>
                <td style="width:200px">
                  <h2><label for="ctl00_ContentPlaceHolder2_DdlJobRoles">ROLE NAME</label></h2>  
                </td>
                <td>
                    <select id="DdlJobRoles" runat="server" class="mandatory" messagetext="Role Name"
                        onchange="javascript:$('#ctl00_ContentPlaceHolder2_TxtHiddenRecommendedRole').val($('#ctl00_ContentPlaceHolder2_DdlJobRoles').val());"/>
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
                <td valign="top" style="width:200px">
                   <h2>DISABILITY TYPE AND SUB-TYPE ACCEPTED:</h2> 
                </td>
                <td>
                    Options<br />
                    <asp:ListView ID="LstViewAcceptedDisabilitySubType" runat="server"
                        OnItemDataBound="LstViewAcceptedDisabilitySubType_ItemDataBound">
                        <LayoutTemplate>
                            <table id="TblAcceptedDisabilitySubType" class ="checkedListBox mandatory" messagetext="disability sub type">
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
                <td valign="top" style="width:200px"><h2>Educational Qualifications Required</h2> 
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
                <td valign="top" style="width:200px"><h2>Training candidate should have passed</h2> </td>
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
                <td valign="top" style="width:200px"><h2>Required Languages</h2> </td>
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
                <td style="width:200px">
                  <h2><label for="ctl00_ContentPlaceHolder2_TxtMonthlySalary">Monthly Salary (Rs.)</label></h2>  
                </td>
                <td>
                    <asp:TextBox id="TxtMonthlySalary" runat="server" />
                </td>
            </tr>
        </table>
        <%--<table>
            <tr>
                <td style="width:250px">
                     <label for="ctl00_ContentPlaceHolder2_TxtMonthlySalary">Monthy Salary Rs</label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"/>
                </td>
            </tr>
        </table>    --%>

      <%--  <table>
            <tr>
                <td style="width:200px">
                     ASSIGN UNIQUE CODE FOR THIS VACANCY
                </td>
                <td>
                    <span id="SpnAssignUniqueCodeForThisVacancy" runat="server" class="readonlyText" />
                </td>
            </tr>
        </table>--%>

        <table>
            <tr>
                <td style="width:200px">
                  <h2><label for="ctl00_ContentPlaceHolder2_TxtResponsibilityTaskList">RESPONSIBILITIES/TASK LIST</label></h2>   
                </td>
                <td>
                    <asp:TextBox ID="TxtResponsibilityTaskList" runat="server" class="mandatory" messagetext="Responsibilities/Task List"/>
                </td>
            </tr>
        </table>   

        <table>
            <tr>
                <td valign="top" style="width:200px"><h2>Groups of Candidate considered</h2> <br />
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
                <td style="width:200px">
                  <h2><label for="ctl00_ContentPlaceHolder2_TxtInterventionRequired">Intervention Required</label></h2>   
                </td>
                <td>
                    <asp:TextBox ID="TxtInterventionRequired" runat="server"/>
                </td>
            </tr>
        </table>   
        <table>
            <tr>
                <td style="width:200px">
                   <h2><label for="ctl00_ContentPlaceHolder2_TxtWorkingDays">Working Days</label></h2>  
                </td>
                <td>
                    <asp:TextBox ID="TxtWorkingDays" runat="server"/>
                </td>
            </tr>
        </table>   

        <table>
            <tr>
                <td style="width:200px"><h2>Shifts</h2> </td>
                <td style="white-space:nowrap">
                    Yes
                    <asp:RadioButton ID="RdbYes" runat="server" GroupName="DataSubmission"/>
                    <label for="ctl00_ContentPlaceHolder2_RdbYes" class="skiplink">Shifts YES</label>&nbsp;
                </td>
                <td style="white-space:nowrap">
                    No
                    <asp:RadioButton ID="RdbNo" runat="server" GroupName="DataSubmission" />
                    <label for="ctl00_ContentPlaceHolder2_RdbNo" class="skiplink">No shifts</label>&nbsp;
                </td>
            </tr>
        </table>

        <table>
            <tr>
                <td style="width:200px">
                   <h2><label for="ctl00_ContentPlaceHolder2_TxtWorkingHours">Working Hours</label></h2>  
                </td>
                <td>
                    <asp:TextBox ID="TxtWorkingHours" runat="server"/>
                </td>
            </tr>
        </table> 


        <table>
            <tr>
                <td style="width:200px" valign="top">
                  <h2><label for="ctl00_ContentPlaceHolder2_TxtHolidayAndLeavePolicy">Comments</label></h2>   
                </td>
                <td>
                    <asp:TextBox ID="TxtHolidayAndLeavePolicy" runat="server" Width="250px" Height="50px" TextMode="MultiLine"/>
                </td>
            </tr>
        </table>
         
       </td>
    </tr>
</table>

<%--<table>
    <tr>
        <td style="width:150px">
            <span id="SpanDateTimeOfCreation" runat="server" class="readonlyText">Date and Time of creation 
            of Employment Project:</span>
        </td>
        <td align="right" style="width:150px">
            <span id="SpanDateTime" runat="server" class="readonlyText" />
        </td>
    </tr>
</table>--%>
<table  id="TblEmploymentDetail" runat="server">
    <tr>
        <td>
            
            <table>
    <tr>
        <td style="width:200px">
            <label for="ctl00_ContentPlaceHolder2_TxtPossibleStartDate">POSSIBLE START DATE OF THIS PROJECT</label>
        </td>
        <td>
            <asp:TextBox id="TxtPossibleStartDate" runat="server" class="mandatory" messagetext="Start Date" date="true" yearlength="4"/>
            <asp:ImageButton runat="server" ID="ImageButton1" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
            <cc1:CalendarExtender runat="server" ID="CalendarExtender1" PopupButtonID="ImageButton1" TargetControlID="TxtPossibleStartDate" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtPossibleStartDate"
            ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
            runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
            <br />
        </td>
        <td>
            (dd/mm/yyyy)
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px">
            <label for="ctl00_ContentPlaceHolder2_TxtPossibleEndDate">POSSIBLE END DATE OF THIS PROJECT</label>
        </td>
        <td>
            <asp:TextBox id="TxtPossibleEndDate" runat="server" class="mandatory" messagetext="End Date" date="true" yearlength="4"/>
            <asp:ImageButton runat="server" ID="ImageButton2" AlternateText="RegD" ImageAlign="AbsMiddle" ImageUrl="~/Image/calendar.gif" ClientIDMode="Static" />
            <cc1:CalendarExtender runat="server" ID="CalendarExtender2" PopupButtonID="ImageButton2" TargetControlID="TxtPossibleEndDate" Format="dd/MM/yyyy" ClientIDMode="Static"></cc1:CalendarExtender>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtPossibleEndDate"
            ValidationGroup="Reg" hilite="txtOMdate" ErrorMessage="Please Enter Valid Date(DD/MM/YYYY)"
            runat="server" Display="Dynamic" ValidationExpression="[0-3][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]" />
            <br />
        </td>
        <td>
            (dd/mm/yyyy)
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px">
            <label for="ctl00_ContentPlaceHolder2_TxtCurrentDemand">CURRENT DEMAND (NUMBER OF PEOPLE)</label>
        </td>
        <td>
            <asp:TextBox id="TxtCurrentDemand" runat="server" class="mandatory" messagetext="Current Demand"/>
           <cc1:FilteredTextBoxExtender ID="filTxt" runat="server" TargetControlID="TxtCurrentDemand" FilterMode="ValidChars" FilterType="Numbers"></cc1:FilteredTextBoxExtender>

        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px">
            <label for="ctl00_ContentPlaceHolder2_TxtDesignation">DESIGNATION (as defined  by company):</label>
        </td>
        <td>
            <asp:TextBox id="TxtDesignation" runat="server" class="mandatory" messagetext="Designation"/>
        </td>
    </tr>
</table>

<table style="display:none">
    <tr>
        <td style="width:200px">
            <label for="ctl00_ContentPlaceHolder2_DdlProjectTypes">Project Type:</label>
        </td>
        <td>
            <select id="DdlProjectTypes" runat="server">
                <option value="-1">Select</option>
                <option value="OnLine">OnLine</option>
                <option value="OnSite">OnSite</option>
                <option value="Blended">Blended</option>
            </select>
        </td>
    </tr>
</table>



<table>
    <tr>
        <td>
            SELECT RELEVANT CONTACT PERSONS USING CHECKBOXES, FROM THE LIST BELOW:
        </td>
    </tr>
</table>

<table>
    <tr>
        <td>
            <asp:ListView ID="LstViewAddEmploymentProject" runat="server">
                <LayoutTemplate>
                    <table id="TblAddEmploymentProject" cellpadding="4"
                        class="checkedListBox mandatory tableBorder"
                        messagetext="Contact Person" cellspacing="0" rules="all"
                        bordercolor="#808080" border="1px">
                        <thead>
                            <tr class="grid-header">
                                
                                <th></th>
                                <th align="right">No.</th>
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
                            <td>
                                <asp:CheckBox ID ="ChkContactPerson" runat="server" 
                                ContactID='<%# EnableIndia.Global.EncryptID(Convert.ToInt32(Eval("contact_id"))) %>'
                                Checked ='<%#Convert.ToBoolean(Eval("is_attached")) %>' />
                                <label class ="skiplink">Select '<%#Eval("contact_name") %>'</label>
                            </td>
                            <td id="TdRecordNumber" align="right"></td>
                            <td align="left">
                                 <select id="DdlTypeOfContact" title="Select type of contact" runat="server" value='<%#Eval("employment_project_contact_type") %>'>
                                    <option value="Regular">Regular</option>
                                    <option value="Primary">Primary</option>
                                    <option value="Escalation">Escalation</option>
                                 </select>
                            </td>
                            <th align="left"><%#Eval("contact_name") %>
                            </th>
                            <td align="left"><%#Eval("designation")%>
                            </td>
                            <td align="right"><%#Eval("phone_number") %>
                            </td>
                            <td align="left"><%#Eval("email_address") %>
                            </td>
                        </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table id="TblAddEmploymentProject" cellpadding="4" class="tableBorder" cellspacing="0" rules="all"
                        bordercolor="#808080" border="1px">
                        <thead>
                            <tr class="grid-header">
                                <th></th>
                                <th>Type of Contact</th>
                                <th>Name of contact</th>
                                <th>Designation</th>
                                <th>Phone Number</th>
                                <th>E-mail Address</th>
                            </tr>
                        </thead>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px">
            <label for="ctl00_ContentPlaceHolder2_DdlEmployeeManagingThisVacancy">EMPLOYEE MANAGING THIS EMPLOYMENT PROJECT</label>
        </td>
        <td>
            <select id="DdlEmployeeManagingThisVacancy" runat="server" class="mandatory" messagetext="Employee" />
        </td>
    </tr>
</table>

<table>
    <tr>
        <td style="width:200px"></td>
        
        <td>
            <asp:Button ID="BtnManageEmploymentProject" Text="Submit" runat="server" 
                OnClientClick="javascript:return ValidateSalaryEmployementProject();" 
            OnClick="BtnManageEmploymentProject_Click" />
        </td>
        <td>
            <asp:Button ID="BtnClear" runat="server" Text="Clear" OnClick="BtnClear_Click" />
        </td>
    </tr>
</table>
        </td>
    </tr>
</table>
    </td>
 </tr>
</table>
<script src="../Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="AddEmploymentProjects.js" type="text/javascript"></script>
</asp:Content>

