/// <reference path="../Scripts/jquery-2.1.4.min.js" />
///<reference path='../Scripts/Common.js' />

$(document).ready(function() {
    AttachLabelToCheckboxesIncheckedListBox("TblAcceptedDisabilitySubType", "DISABILITY SUB-TYPE ACCEPTED options");
    AttachLabelToCheckboxesIncheckedListBox("TblEducationQualificationRequired","EDUCATIONAL QUALIFICATION REQUIRED Options");
    AttachLabelToCheckboxesIncheckedListBox("TblTrainingCandidateShouldHavePassed", "TRAINING CANDIDATE SHOULD HAVE PASSED Options");
    AttachLabelToCheckboxesIncheckedListBox("TblLstViewRequiredLanguage", "REQUIRED LANGUAGE");
    AttachLabelToCheckboxesIncheckedListBox("TblGroupsOfCandidatConsidered", "Groups of Candidate considered ");

    $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=add_emp_proj", 860, 160);
    });
    InsertRecordNumber("TblAddEmploymentProject");
    if(document.URL.indexOf("AddEmploymentProjects.aspx?emp_proj=")==-1){
        var companyCode=$("#DdlHiddenCompanyCode").val();
        FilterCityStates($("#DdlParentCompany").val(),'ParentCompanyID','DdlCompanyCode','DdlHiddenCompanyCode');
        $("#DdlCompanyCode").val($("#TxtHiddenCompanyID").val());
        if(document.URL.indexOf("AddEmploymentProjects.aspx?emp_proj=")==-1){
            $("#DdlCompanyCode").val(companyCode);
        }
        $("#DdlCompanyCode").change();
    }
    
    if($("#TxtHiddenVacanciesValue").val()!=''){
        $("#DdlJobTypes").change();
    }
     
    if($("#SpnHiddenRoleName").html()!=""){
        $("#DdlJobRoles").val($("#SpnHiddenRoleName").html());
        $('#TxtHiddenRecommendedRole').val($("#SpnHiddenRoleName").html());
    }
});

function ValidateVacancyDropDown(){
    var message="";
    var allValid=true;
    var parentCompany=$("#DdlParentCompany").val();
    var company=$("#DdlCompanyCode").val();
    var vacancyCode=$("#DdlVacancyCode").val();
    if(vacancyCode ==-2 ){
        message+="Select vacancy code.\n";
        allValid=false;
    }
    if(parentCompany <=0){
         message+="Select parent company.\n";
        allValid=false;
    }
    if(company <=0){
         message+="Select company.\n";
        allValid=false;
    }
    if(allValid==false){
        alert(message);
    }
    return allValid;
}

function ValidateSalaryEmployementProject(){
    var message="";
    var noErrors=true;
    var isValid=ValidateForm();
    if(isValid==true){
        if($("#TxtHiddenVacanciesValue").val()==0){
            message+="Please hit refresh button.\n";
            noErrors=false;
        }
        var salary=$("#TxtMonthlySalary").val();
        if($.trim(salary)!=''){
            var isSalaryValid=ValidateSalary("TxtMonthlySalary");
            if(isSalaryValid==false){
                message+="Enter valid salary.\n";
                noErrors=false;   
            }
        }
    if(noErrors==false){
            alert(message);
        }
        return noErrors;
    }
    else{
        return false;
    }
}

function DdlRecommendedJobType_SelectIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown){
    if(parseInt($("#DdlRecommendedJobType").val())<0){
       $('#TxtHiddenRecommendedRole').val($("#DdlRecommendedRole").val());
    }
    else{
        FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
        var option=$("#DdlJobRoles option[value=-2]");
        option.html("All");
        option.attr("value","0");
        $('#TxtHiddenRecommendedRole').val($("#DdlJobRoles").val());
        $("#DdlJobRoles").change();
    }
}