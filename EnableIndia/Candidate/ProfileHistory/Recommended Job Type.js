/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
///<reference path='../../Scripts/common.js' />
$(document).ready(function(){
    DdlRecommndedJobTypes_SelectedIndexChanged();
    InsertRecordNumber("TdRecordNumber");
    
    var maxLength = parseInt(0);
    $("#TblJobTypesRoles tbody tr td table tr td[id='textField']").each(function() {
        //$(this).find("label").attr("for", $(this).siblings().find(":input").attr("id"));
        if (parseInt($(this).find("label").html().length) > maxLength) {
            maxLength = parseInt($(this).find("label").html().length);
        }
    });
    $("#TblJobTypesRoles tbody tr td table tr td[id='textField']").css("width", (maxLength * 6) + 3);
});


function DdlRecommndedJobTypes_SelectedIndexChanged()
{
    $("#SpnEmptyMessage").hide();
    $("#TblJobTypesRoles tbody table").hide();
    
    var jobID=$("#DdlRecommndedJobTypes").val();
    $("#TblJobTypesRoles tbody table[JobID=" + jobID + "]").show();
    if($("#TblJobTypesRoles tbody table[JobID=" + jobID + "]").size()==0){
        $("#SpnEmptyMessage").show();
        $("#TblJobTypesRoles").hide();
    }
    else{
        $("#TblJobTypesRoles").show();
    }
}