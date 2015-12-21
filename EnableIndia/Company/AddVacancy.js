

///<reference path='../Scripts/Common.js' />

$(document).ready(function() {
    AttachLabelToCheckboxesIncheckedListBox("TblAcceptedDisabilitySubType", "DISABILITY SUB-TYPE ACCEPTED options");
    AttachLabelToCheckboxesIncheckedListBox("TblEducationQualificationRequired","EDUCATIONAL QUALIFICATION REQUIRED Options");
    AttachLabelToCheckboxesIncheckedListBox("TblTrainingCandidateShouldHavePassed", "TRAINING CANDIDATE SHOULD HAVE PASSED Options");
    AttachLabelToCheckboxesIncheckedListBox("TblLstViewRequiredLanguage", "REQUIRED LANGUAGE");
    AttachLabelToCheckboxesIncheckedListBox("TblGroupsOfCandidatConsidered", "Groups of Candidate considered ");
    
    $("#BtnHelp").click(function() {
    ShowPopUp("../ITextPopup.aspx?page=add_vac", 950, 150);
    });
        $("#DdlJobTypes").change();
      if($("#SpnHiddenRoleName").html()!=""){
        $("#DdlJobRoles").val($("#SpnHiddenRoleName").html());
        $('#TxtHiddenRecommendedRole').val($("#SpnHiddenRoleName").html());
      }
      
//    FilterCityStates($("#DdlJobTypes").val(),'JobID','DdlJobRoles','DdlHiddenRoleName');
    
});

function ValidateSalaryInVacancy()
{
    var message="";
    var noErrors=true;
    
    var isValid=ValidateForm();
    
    if(isValid==true){
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

function DdlRecommendedJobType_SelectIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown)
{
    if(parseInt($("#DdlRecommendedJobType").val())<0){
    
           //$("#DdlRecommendedRole").val($("#DdlRecommendedJobType").val());
           $('#TxtHiddenRecommendedRole').val($("#DdlRecommendedRole").val());
    }
    else{
        FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
        //$("#DdlJobRoles").val($("#SpnHiddenRoleName").html());
//        if($('#DdlHiddenRoleName').val()!=-3){
//            var option=$("#DdlJobRoles option[value=-2]").remove();
//            var html="<option value='-2'>Select</option>";
//            html+="<option value='0'>All</option>";
//            html+=$("#DdlJobRoles").html();
//            $('#DdlJobRoles').html(html);
//            $('#DdlJobRoles').attr("selectedIndex",0);
//        }else{
           
            //$("#DdlJobRoles").val($('#DdlHiddenRoleName').val());
       // }
        var option=$("#DdlJobRoles option[value=-2]");
        option.html("All");
        option.attr("value","0");
        $('#TxtHiddenRecommendedRole').val($("#DdlJobRoles").val());
        $("#DdlJobRoles").change();
        
    }
}