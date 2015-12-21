
/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../Scripts/jquery.cookie.js" />
/// <reference path="../Scripts/Common.js" />


$(document).ready(function(){
    $("#TxtCandidatesInCandidateCallingList").val($.cookie("candidate_calling"));
    InsertRecordNumber("TblCandidateCallingList");
    SetTableStyle();
});

function SelectAllCandidates(strSelectAllCheckBoxID){
    $("#TblCandidateCallingList tbody tr td :checkbox").each(function(){
        $(this).attr("checked",$("#" + strSelectAllCheckBoxID).attr("checked"));
    });
}

function ValidateCheckedBoxes()
{
    if($("#TblCandidateCallingList tbody tr :checkbox").filter(":checked").size()==0){
        alert("Select atleast one candidate.");
        return false;
    }
}

function RemoveFromCandidateCallingList(){
    if($("#TblCandidateCallingList tbody tr td :checkbox").filter(":checked").size()==0){
        alert("Please select atleast one candidate to remove.");
    }
    else{
        var counter=0;
        $("#TblCandidateCallingList tbody tr td :checkbox").filter(":checked").each(function(){
            $("#TblCandidateCallingList tbody tr[CandidateID=" + $(this).parent().attr("CandidateID") + "]").remove();
            counter++;
        });
        
        $("#TblCandidateCallingList tbody tr").removeAttr("class");
        
        var modifiedCandidateCallingList="";
        $("#TblCandidateCallingList tbody tr td :checkbox").each(function(){
            modifiedCandidateCallingList+=$(this).parent().attr("CandidateID") + "_";
        });
        
        if($.trim(modifiedCandidateCallingList)==''){
            modifiedCandidateCallingList='';
        }
        else{
            modifiedCandidateCallingList= modifiedCandidateCallingList.substring(0,modifiedCandidateCallingList.length-1);
        }
        
        $("#TxtCandidatesInCandidateCallingList").val(modifiedCandidateCallingList);
    
        $.cookie("candidate_calling",$.trim(modifiedCandidateCallingList),{path:"/",expires:1});
        if(counter==1){
            alert(counter+ " candidate deleted successfully.");
        }else{
            alert(counter+ " candidates deleted successfully.");
        }
        InsertRecordNumber("TblCandidateCallingList");
        SetTableStyle();
    }
    return false;
}