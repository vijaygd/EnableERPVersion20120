/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
///<reference path='../../Scripts/common.js' />

$(document).ready(function(){

    $("#BtnHelp").click(function() {
        ShowPopUp("../../ITextPopup.aspx?page=job_proflie", 800, 180);
    });

    AttachLabelToCheckboxesIncheckedListBox("TblJobRoles","Role options");
    AttachLabelToCheckboxesIncheckedListBox("TblCandidateGroups","Group options");
    InsertRecordNumber("TblJobRoles");
});

function CheckCandidateInactive(){
    if($("#ChkMakeCandidateInactive").prop("checked")){
        var IsValid=confirm("Ticking this will make the candidate unavailable in the ERP permanently. Are you sure you want to continue?");
        if(IsValid==true){
            $("#ChkMakeCandidateInactive").attr("checked",true);
            return IsValid;
        }
        else{
            $("#ChkMakeCandidateInactive").attr("checked",false);
            return IsValid;
        }
    }

}



function ValidateOpenTask(){
    var message="";
    var isValid=true;
       
    if($("#ChkMakeCandidateInactive").attr("checked")== true){
        message+="Candidate can not be inactivated as candidate has assigned ";
        var btnSubmit=$("#BtnManageCandidateJobProfile");
        
        if(btnSubmit.attr("OpenTask")>0){
            message+=" open candidate task";
             if(btnSubmit.attr("OpenTraningProject")>0){
                message+=" and open training project";
             }
             if(btnSubmit.attr("OpenEmpProject")>0){
                 message+=" and open employment project";
             }
              message+=".";
            isValid=false;
        }else if(btnSubmit.attr("OpenTraningProject")>0){
            message+=" open training project";
            if(btnSubmit.attr("OpenEmpProject")>0){
                 message+=" and open employment project";
             }
             message+=".";
            isValid=false;
        }else if(btnSubmit.attr("OpenEmpProject")>0){
            message+=" open employment project.";
            isValid=false;
        }
         if(isValid==false){
            alert(message);
        }
        return isValid;
    }
    else{
        return true;
    }
}