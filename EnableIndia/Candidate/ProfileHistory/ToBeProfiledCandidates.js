/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
/// <reference path='../../Scripts/common.js' />

$(document).ready(function(){
    $("#BtnHelp").click(function() {
        ShowPopUp("../../ITextPopup.aspx?page=to_be_profile", 1150, 300);
    });

    //InsertRecordNumber("TblToBeProfiledCandidates");
    
    $("#DivProfiledCandidates").pager({ pagenumber: parseInt($.cookie("grid_page_number")), pagecount: parseInt($.cookie("grid_page_count")), buttonClickCallback: PageClick });
    
    InsertRecordNumberWithPaging("TblToBeProfiledCandidates",$.cookie("grid_page_number"));
    
    if($.cookie("candidate_calling")!=null){
        $("#TxtCandidatesInCandidateCallingList").val($.cookie("candidate_calling"));
           $("#BtnViewCandidateCallingList").css("display","");
        $("#BtnPrint").css("display","");
    }
    else{
        $("#TxtCandidatesInCandidateCallingList").val("");
         $("#BtnViewCandidateCallingList").css("display","none");
        $("#BtnPrint").css("display","none");
    }
    
    SelectAllCandidates();
    CheckForCandidatesInCandidateCallingList();
});

function PageClick(pageNumber){
    $.cookie("grid_page_number",pageNumber,{path: '/'});
    $("#BtnSearchCandidates").click();
}

function SelectAllCandidates(){
    var result = $('#ChkSelectAllCandidates:checked').val() ? true : false;
    if (result) {
        $("#TblToBeProfiledCandidates tbody tr td :checkbox").each(function(){
            $(this).attr("checked",$("#ChkSelectAllCandidates").attr("checked"));
        });
    }
    else {
        $("#TblToBeProfiledCandidates tbody tr td :checkbox").each(function () {
             $(this).prop("checked", false);
         });
     }
}

function CheckForParameterChange(){
    //Validates the dates
    var message="";
    var datesValid=true;
    
    var registrationDateFrom=$("#TxtRegistrationDateFrom").val();
    if($.trim(registrationDateFrom)!=''){
        var isDateFromValid = ValidateDate(registrationDateFrom,4,false,"");
        if(isDateFromValid==false){
            message+="Enter valid Registration From Date.\n";
            datesValid=false;
        }
    }
    
    var registrationToDate=$("#TxtRegistrationDateTo").val();
    if($.trim(registrationToDate)!=''){
        var isDateToValid = ValidateDate(registrationToDate,4,false,"");
        if(isDateToValid==false){
            message+="Enter valid Registration To Date.\n";
            datesValid=false;
        }
    }
    
    var dateOfBirth=$("#TxtDateOfBirth").val();
    if($.trim(dateOfBirth)!=''){
        var isDateValid = ValidateDate(dateOfBirth,4,false,"");
        if(isDateValid==false){
            message+="Enter valid Date Of Birth .\n";
            datesValid=false;
        }
    }
    if(datesValid==false){
        alert(message);
        return datesValid;
    }

    var TxtIsParameterChanged=$("#TxtIsParameterChanged");
    var previousParameters=TxtIsParameterChanged.val();
    var newParameters="";
    $("table[group='SearchParameters']").each(function(){
        if($(this).find("select").size() > 0){
            newParameters+=$(this).find("select").val() + "#";
        }
        
        if($(this).find("input").size() > 0){
            newParameters+=$(this).find("input").val() + "#";
        }
    });
    
    if($.trim(previousParameters)==''){
        TxtIsParameterChanged.val(newParameters);
    }
    else{
        //Compares the value of old search parameters and new search parameters.
        if(TxtIsParameterChanged.val()!=newParameters && $.cookie("candidate_calling")!='' && $.cookie("candidate_calling")!=null){
            var wantToClearExistingCandidateCallingList = confirm("Candidate calling list already exists. Do you want to clear the existing list?");
            if(wantToClearExistingCandidateCallingList==true){
                $.cookie('candidate_calling',"",{expires:1,path:"/"});
                $("#TxtCandidatesInCandidateCallingList").val("");
                TxtIsParameterChanged.val("");
            }
        }
    }
    
    $("#TblToBeProfiledCandidates tbody tr td :checkbox").attr("checked",false);
}

function AddToCandidteCallingList(){
    var newCandidateList="";
    var existingCandidateCallingList=$("#TxtCandidatesInCandidateCallingList").val();
    
    $("#BtnViewCandidateCallingList").css("display","none");
         $("#BtnPrint").css("display","none");
    $("#TblToBeProfiledCandidates tbody tr :checkbox").filter(":checked").each(function(){
        //Checks whether candidate exists in the list or not.If the candidate does not exist in the list, then only add it in the list.
        if(existingCandidateCallingList.indexOf($(this).parent().attr("CandidateID"))==-1){
            newCandidateList+=$(this).parent().attr("CandidateID") + "_";
        }
    });
    
    if($("#TblToBeProfiledCandidates tbody tr :checkbox").filter(":checked").size()==0){
        alert("Select atleast one candidate.");
    }
    else{
        //$("#cTxtCandidateCallingList").val(existingCandidateCallingList + newCandidateListHTML);
        newCandidateList=newCandidateList.substring(0,newCandidateList.length-1);
        if($.trim(existingCandidateCallingList).length>0 && newCandidateList!=''){
            existingCandidateCallingList=existingCandidateCallingList + "_";
        }
        //alert("Existing: " + existingCandidateCallingList + "\n" + "New: " + newCandidateList);
        $("#TxtCandidatesInCandidateCallingList").val(existingCandidateCallingList + newCandidateList);
        $.cookie('candidate_calling',$("#TxtCandidatesInCandidateCallingList").val(),{expires:1,path:"/"});
        $("#BtnViewCandidateCallingList").css("display","");
             $("#BtnPrint").css("display","");
        alert("Candidates added to candidate calling list successfully.");
    }
    return false;
}

//function CheckForCandidatesInCandidateCallingList() {
//    var selectedIDs = $('#<%= TxtCandidatesInCandidateCallingList.ClientID %>');
//    if ($("#TxtCandidatesInCandidateCallingList").val() != '') {
//        selectedCandidateIDs = selectedIDs.val().split('_');
//            $("#TblToBeProfiledCandidates tbody tr span[CandidateID=" + selectedCandidateIDs[counter] + "]").find(":checkbox").attr("checked",true);
//    }
//}

function CheckForCandidatesInCandidateCallingList() {
    if (typeof ($("#TxtCandidatesInCandidateCallingList")) != 'undefined') {
        if ($("#TxtCandidatesInCandidateCallingList").val() != '') {
            if ($("#TxtCandidatesInCandidateCallingList").val().IndexOf("-") != -1)
            {
                 var selectedCandidateIDs = $("#TxtCandidatesInCandidateCallingList").val().split('_');
                 for (var counter = 0; counter < selectedCandidateIDs.length; counter++) {
                     $("#TblAllActiveCandidates tbody tr span[CandidateID=" + selectedCandidateIDs[counter] + "]").find(":checkbox").attr("checked", true);
                 }
            }
        }
    }
 }
