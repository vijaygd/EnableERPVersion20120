/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../../Scripts/Common.js" />


var $jq = jQuery.noConflict();
$(document).ready(function(){

    $("#BtnHelp").click(function() {
        ShowPopUp("../../ITextPopup.aspx?page=unreg_blank_form", 1000, 250);
    });
    
   InsertRecordNumber("TblUnregisteredCandidates"); 
});

function ValidateCheckedBoxes()
{
    if($("#TblUnregisteredCandidates tbody tr :checkbox").filter(":checked").size()==0){
        alert("Select atleast one candidate.");
        return false;
    }
   
}

function ValidateNumberOfForms(){
    var isValid=true;
    var numberOfForms1 = $("#ctl00_ContentPlaceHolder2_TxtNumberOfNewForms").val();
    var numberOfForms = $("#ctl00$ContentPlaceHolder2$TxtNumberOfNewForms").val();

    var t = $("input#TxtNumberOfNewForms");
    if($.trim(numberOfForms)==""){
        alert("Number of forms is required.");
        isValid=false;
    }
    else if($.trim(numberOfForms)>50){
        alert("Number of forms should not be more than 50.")
        isValid=false;
    }
    else if(isNaN(parseInt(numberOfForms))){
        alert("Please enter the valid number.");
        isValid=false;
    }
    if(isValid==true){
        return ValidateForm();
    }
    else{
        return isValid;
    }
    
   
    //return isValid;
}