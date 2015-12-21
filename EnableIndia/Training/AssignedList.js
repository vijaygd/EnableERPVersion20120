/// <reference path="../Scripts/jquery-1.7.1.min.js" />
///<reference path='../Scripts/common.js' />

$(document).ready(function(){
    $("#BtnHelp").click(function(){
        ShowPopUp("../ITextPopup.aspx?page=assign_train_proj", 1000, 450);
    });
    if ($.cookie("candidate_calling") != null) {
        $("#TxtCandidatesInCandidateCallingList").val($.cookie("candidate_calling"));
    }
    else {
        $("#TxtCandidatesInCandidateCallingList").val("");
    }

    //CheckForCandidatesInCandidateCallingList();
    InsertRecordNumber("TblViewAssignedCandidateList");

    //$("#TblViewAssignedCandidateList tbody tr td[Step] select").change(function(){
    //    CheckAssignedList($(this).attr("Step"),$(this).parents("tr:first").attr("CandidateID"));
    //});
    CheckAtStartup();
   // EnableDropDown();
    //DdlCloseOfParticularStep_SelectedIndexChanged();
});

//validate stautus
function CheckProjectStatus(){
    var returnProjectStatus=confirm('Before closing the project: \n 1. Update End Date of project if required.\n 2. Transfer important details from Notes section to Candidate History.\n Are you sure you want to continue?');
    if(returnProjectStatus==true){
        var projectStatus = $("#SpnTrainingProjectStatus").html();
        if (projectStatus != 'Completed'){
            alert("Only completed project can be closed.");
            return false;
        }
        else {
            return true;
        }
    }
    else{
        return false;
    }
}

// validate checkbox
function validateCheckBox(){
    if($("#TblViewAssignedCandidateList  tr td :checkbox").filter(':checked').size()==0){
        alert('Select atleast one candidate.');
        return false;
    }
    else{
        return true;
    }
}

function ResetCandidateDetail(){
    var isValidCheckBox=validateCheckBox();
    
    if(isValidCheckBox==true){
        $("#TblViewAssignedCandidateList tbody tr").each(function(){
            if($(this).find(":checkbox").attr("checked")==true){
                $(this).find("select[Step=1]").val("-2");
                $(this).find("select[Step=1]").change();
                $(this).find(":checkbox").attr("checked",true);
            }
        });
    } 
}

function ValidateClass(){
    $("#TblViewAssignedCandidateList tbody tr").each(function(){
        if($(this).find(":checkbox").attr("checked")==true){
            var DdlFinalStatus=$(this).find("select[Step=6]");
            if(DdlFinalStatus.val()!="1"){
            
            }
            else{
            
            }
        }
    });
    return ValidateForm();
}

function validateForm() {
}

//function EnableDropDown(){
//    $("#TblViewAssignedCandidateList tbody tr").each(function(){
//        if($(this).find(":checkbox").attr("checked")==true){
//             $(this).find("select").attr('disabled',false);
//        }
//        else{
//            $(this).find("select").attr('disabled',true);
//        }
//    });
//}

function EnableDropDown() {
    var t = 0;
    $("#TblViewAssignedCandidateList tbody tr").each(function () {
        if ($(this).find(":checkbox").attr("checked") == true) {
            $(this).find("select").attr('disabled', false);
        }
        else {
            $(this).find("select").attr('disabled', true);
        }
    });
}

function ShowNotesPopUp(strTrainingProjectID,strLinkButtonID){
    var trainingProjectID=document.URL.substring(document.URL.indexOf("=") + 1,document.URL.indexOf("&train_prog"));
    var url="../Training/CandidateNotes.aspx?train_proj=" + trainingProjectID;
    if(strTrainingProjectID!="-1"){
        url+= "&cand=" + $("#TblViewAssignedCandidateList #" + strLinkButtonID).attr("candidateID");
    }
    ShowPopUp(url,880,550);
}

function ShowGotJobPopUp(strLinkButtonID){
    var candidateID=$("#TblViewAssignedCandidateList #" + strLinkButtonID).attr("candidateID");
    var url="../candidate/WorkExperiencePopup.aspx?cand=" + candidateID;
    var trainingProjectID=document.URL.substring(document.URL.indexOf("=") + 1,document.URL.indexOf("&train_prog"));
    url+= "&train_proj=" + trainingProjectID;
    ShowPopUp(url,880,550);
}

function CheckAtStartup(){
   // $("#TblViewAssignedCandidateList tbody tr td[Step] select").each(function(){
   //     $(this).siblings(":text").val($(this).val());
   //     var dropDown=$(this);
   //     var tr = dropDown.parent().parent();
   //     var stepNumber = parseInt(dropDown.attr("Step"));
   //     var ChkRecommendedCandidateName = tr.find(':checkbox');
   //     if (!ChkRecommendedCandidateName.prop('checked')) {
   //         for (var counter = stepNumber + 1; counter <= 8; counter++) {
   //             if ((dropDown.val() == "0" || dropDown.val() == "-2") && counter != 6) {
   //                 tr.find("select[Step=" + counter + "]").css('visibility', 'hidden');
   //             }
   //             else if ((dropDown.val() == "0" || dropDown.val() == "-2") && counter == 6) {
   //                 tr.find("select[Step=" + counter + "]").css('visibility', 'hidden');
   //             }
   //             else if (stepNumber == 6 && dropDown.val() == "-2") {
   //                 tr.find("select[Step=" + (counter + 1) + "]").css('visibility', 'hidden');
   //             }
   //             else {
   //                 tr.find("select[Step=" + counter + "]").css('visibility', 'visible');
   //             }
   //         }
   //     }
   //});
}

function CheckAssignedList(stepNumber,candidateID){
    //$("#TblViewAssignedCandidateList tbody tr[CandidateID=" + candidateID + "] td[Step] select[Step=" + stepNumber + "]").each(function () {
    //    $(this).siblings(":text").val($(this).val());
    //    var dropDown = $(this);
    //    var tr = dropDown.parent().parent();
    //    stepNumber = parseInt(dropDown.attr("Step"));
    //    var ChkRecommendedCandidateName = tr.find(':checkbox');

    //    tr.find("select[Step=" + (stepNumber + 1) + "]").val("-2");
    //    if(dropDown.val()!='0' && dropDown.val()!='-2'){
    //        tr.find("select[Step=" + (stepNumber + 1)  + "]").css('visibility','visible');
    //        tr.find("select[Step=" + (stepNumber + 1)  + "]").val('-2');
            
    //        if (stepNumber == 2 || stepNumber == 5 || stepNumber == 6 || stepNumber == 7) {
	//		    for (var counter = stepNumber + 1; counter <= 8; counter++){
	//			    tr.find("select[Step=" + (counter + 1) + "]").val('-2');
	//			    if(tr.find("select[Step=" + (counter + 1) + "]").val()=='-2'){
	//			        tr.find("select[Step=" + (counter + 1) + "]").css('visibility', 'hidden');
				        
	//			    }
	//		    }
	//		}
    //    }
    //    //else {
        //    if (!ChkRecommendedCandidateName.prop('checked'))
        //    {
        //        for (var counter = stepNumber + 1; counter <= 8; counter++) {
        //            tr.find("select[Step=" + counter + "]").css('visibility', 'hidden');
        //            tr.find("select[Step=" + counter + "]").val('-2');
        //        }
        //   } 
        //}
   // });
}

function ShowCandidateListPopup(){
    var trainingProjectID = "";
    trainingProjectID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.indexOf("&train_prog"));
    var url = "../candidate/ViewCandidateCallingList.aspx?train_proj=" + trainingProjectID +"&step="+ $("#TxtHiiddenSelectedStep").val();
    ShowPopUp(url, 1200, 600);
}

function SelectAllCandidates(){
    $("#TblViewAssignedCandidateList tbody tr td :checkbox").each(function(){
        $(this).attr("checked",$("#ChkSelectAllCandidates").attr("checked"));
    });
    EnableDropDown();
    return false;
}

function DdlCloseOfParticularStep_SelectedIndexChanged(){
    $('#DdlOutcomes option').show();
    var stepNumber= $("#DdlCloseOfParticularStep").val();
    var html="<option value='-2'>Select</option>";
    switch(stepNumber)
    {
        case "1":
            html+="<option value='1'>Yes</option>";
            html+="<option value='0'>No</option>";
            break;
        case "2":
            html+="<option value='1'>Yes</option>";
            html+="<option value='0'>No</option>";
            html+="<option value='2'>NA</option>";
            break;
        case "3":
            html+="<option value='1' >Yes</option>";
            html+="<option value='0'>No</option>";
            break;
        case "4":
            html+="<option value='1'>Yes</option>";
            html+="<option value='0'>No</option>";
            break;
        case "5":
            html+="<option value='1'>Pass</option>";
            html+="<option value='0'>Fail</option>";
            html+="<option value='2'>NA</option>";
            break;
        case "6":
            html+="<option value='Excellent'>Excellent</option>";
            html+="<option value='Very Good'>Very Good</option>";
            html+="<option value='Satisfactory'>Satisfactory</option>";
            html+="<option value='Needs Improvement'>Needs Improvement</option>";
            html+="<option value='Waived'>Waived</option>";
            html+="<option value='NA'>NA</option>";
            break;
        case "7":
            html+="<option value='1'>Yes</option>";
            html+="<option value='0'>No</option>";
            html+="<option value='2'>NA</option>";
            break;
    }
    $('#DdlOutcomes').html(html);
}

function CloseParticularList(){
    var stepNumber= parseInt($("#DdlCloseOfParticularStep").val());
    var selectedStepValue=$('#DdlOutcomes').val();
    var message='';
    var valid=true;
    
    if(stepNumber<0){
        message+=" Particular step for all Candidates required.\n";
        valid=false;
    }
    if(selectedStepValue<0){
        message+=" Outcome option required.\n";
        valid=false;
    }
    if(valid==false){
        alert(message);
        return valid;
    }
    else{
        $('#TblViewAssignedCandidateList tbody tr').each(function(){
            var tr = $(this);
            var ChkRecommendedCandidateName = tr.find(':checkbox');
            var previousStep = parseInt(tr.find('select[step=' + (stepNumber -1) + ']').val());
            var currentStep = parseInt(tr.find('select[step=' + stepNumber + ']').val());
            
            if(stepNumber==1){
                if(currentStep<0){
                   tr.find('select[step=' + stepNumber + ']').val(selectedStepValue);
                   ChkRecommendedCandidateName.attr('checked',true);
                }
            }
            if(stepNumber==7){
                if(currentStep<0 && previousStep!=-2){
                    tr.find('select[step=' + stepNumber + ']').val(selectedStepValue);
                    ChkRecommendedCandidateName.attr('checked',true);
                }
            }
            else{
                if(previousStep>=1  && currentStep<0){
                    tr.find('select[step=' + stepNumber + ']').val(selectedStepValue);
                    ChkRecommendedCandidateName.attr('checked',true);
                }
            }
        });
         
        EnableDropDown();
        if ($("#TblViewAssignedCandidateList  tr td :checkbox").filter(':checked').size() > 0) {
            document.getElementById("hField").value = "1";
            $('#BtnSubmit').click();
        }
        else{
            alert("No candidates are at this task.");
            return false;
        }
        return false;
    }
}

function CheckCandidatesInCallingList(){
    if($("#TxtCandidatesInCandidateCallingList").val()==''){
        alert("Candidate calling list is empty.");
        return false;
    }
    else{
        return true;
    }
}

function validateStep(){
    var stepNumber=parseInt($("#DdlCandidateCallingStep").val());
    if(stepNumber<0){
        alert("Candidates calling from a particular step is required.");
        return false;
    }
    else{
        return true;
    }
}

function AddToCandidteCallingListFromStep(){
    var hiddenValue=$("#TxtCandidatesInCandidateCallingList").val();
    var step=$("#TxtHiiddenSelectedStep").val();
    
    if(hiddenValue !='' && step ==''){
        var message="This will clear candidate calling list. Do you want to continue?";
        var isConfirmed = confirm(message);
        if(isConfirmed==true){
            var newCandidateList="";
            var existingCandidateCallingList='';
            var stepNumber=parseInt($("#DdlCandidateCallingStep").val());
            if(stepNumber<0){
                alert("Candidates calling from a particular step is required.");
                return false;
            }
            else{
                $('#TblViewAssignedCandidateList tbody tr').each(function(){
                    var tr = $(this);
                    var ChkRecommendedCandidateName = tr.find(':checkbox');
                    var previousStep = parseInt(tr.find('select[step=' + (stepNumber -1) + ']').val());
                    var currentStep = parseInt(tr.find('select[step=' + stepNumber + ']').val());
                    
                    if(stepNumber==1){
                        if(currentStep<0){
                            newCandidateList+=ChkRecommendedCandidateName.parent().attr("CandidateID") + "_";
                        }
                    }    
                    if(stepNumber==7){
                        if(currentStep<0 && previousStep!=-2){
                             newCandidateList+=ChkRecommendedCandidateName.parent().attr("CandidateID") + "_";
                        }
                    }
                    else{
                        if(previousStep==1 && currentStep<0){
                            newCandidateList+=ChkRecommendedCandidateName.parent().attr("CandidateID") + "_";
                        }
                    }
                });

                newCandidateList=newCandidateList.substring(0,newCandidateList.length-1);
                if($.trim(existingCandidateCallingList).length>0 && newCandidateList!=''){
                    existingCandidateCallingList=existingCandidateCallingList + "_";
                }
                $("#TxtCandidatesInCandidateCallingList").val(existingCandidateCallingList + newCandidateList);
                $.cookie('candidate_calling',$("#TxtCandidatesInCandidateCallingList").val(),{expires:1,path:"/"});
                $("#BtnViewCandidateCallingList").css("display","");
            
                if($("#TxtCandidatesInCandidateCallingList").val()!=''){
                    setTimeout("alert('Candidates added to candidate calling list successfully.')",1000);
                }
                else{
                    alert("No Candidates added to candidate calling list.");
                }
                $("#TxtHiiddenSelectedStep").val($("#DdlCandidateCallingStep").val());
                $("#TblViewAssignedCandidateList tbody tr td :checkbox").each(function(){
                    $(this).attr("checked",false);
                    $("#ChkSelectAllCandidates").attr("checked",false);
                    EnableDropDown();
                });
                return false;
            }
        }
        else{
            return false;
        }
    }
    else{
        var newCandidateList="";
        var existingCandidateCallingList='';
        var stepNumber=parseInt($("#DdlCandidateCallingStep").val());
        if(stepNumber<0){
            alert("Candidates calling from a particular step is required.");
            return false;
        }
        else{
            $('#TblViewAssignedCandidateList tbody tr').each(function(){
                var tr = $(this);
                var ChkRecommendedCandidateName = tr.find(':checkbox');
                var previousStep = parseInt(tr.find('select[step=' + (stepNumber -1) + ']').val());
                var currentStep = parseInt(tr.find('select[step=' + stepNumber + ']').val());
                
                if(stepNumber==1){
                    if(currentStep<0){
                        newCandidateList+=ChkRecommendedCandidateName.parent().attr("CandidateID") + "_";
                    }
                }    
                if(stepNumber==7){
                      if(currentStep<0 && previousStep!=-2){
                        newCandidateList+=ChkRecommendedCandidateName.parent().attr("CandidateID") + "_";
                      }
                }
                else{
                    if(previousStep==1 && currentStep<0){
                        newCandidateList+=ChkRecommendedCandidateName.parent().attr("CandidateID") + "_";
                    }
                }
            });

            newCandidateList=newCandidateList.substring(0,newCandidateList.length-1);
            if($.trim(existingCandidateCallingList).length>0 && newCandidateList!=''){
                existingCandidateCallingList=existingCandidateCallingList + "_";
            }
            $("#TxtCandidatesInCandidateCallingList").val(existingCandidateCallingList + newCandidateList);
            $.cookie('candidate_calling',$("#TxtCandidatesInCandidateCallingList").val(),{expires:1,path:"/"});
            $("#BtnViewCandidateCallingList").css("display","");
            
            if($("#TxtCandidatesInCandidateCallingList").val()!=''){
                setTimeout("alert('Candidates added to candidate calling list successfully.')",1000);
            }
            else{
                alert("No Candidates added to candidate calling list.");
            }
            $("#TxtHiiddenSelectedStep").val($("#DdlCandidateCallingStep").val());
            $("#TblViewAssignedCandidateList tbody tr td :checkbox").each(function(){
                $(this).attr("checked",false);
                $("#ChkSelectAllCandidates").attr("checked",false);
                EnableDropDown();
            });
            return false;
        }
    }
}

function AddToCandidteCallingList(){
    var hiddenValue=$("#TxtCandidatesInCandidateCallingList").val();
    var step=$("#TxtHiiddenSelectedStep").val();
    
    if(hiddenValue !='' && step !=''){
        var message="This will clear candidate calling list. Do you want to continue?";
        var isConfirmed = confirm(message);
        if(isConfirmed==true){
            var newCandidateList="";
            var existingCandidateCallingList='';
            
            $("#TblViewAssignedCandidateList tbody tr :checkbox").filter(":checked").each(function(){
                //Checks whether candidate exists in the list or not.If the candidate does not exist in the list, then only add it in the list.
                if(existingCandidateCallingList.indexOf($(this).parent().attr("CandidateID"))==-1){
                    newCandidateList+=$(this).parent().attr("CandidateID") + "_";
                }
            });
            
            if($("#TblViewAssignedCandidateList tbody tr :checkbox").filter(":checked").size()==0){
                alert("Select atleast one candidate.");
            }
            else{
                newCandidateList=newCandidateList.substring(0,newCandidateList.length-1);
                if($.trim(existingCandidateCallingList).length>0 && newCandidateList!=''){
                    existingCandidateCallingList=existingCandidateCallingList + "_";
                }
                $("#TxtCandidatesInCandidateCallingList").val(existingCandidateCallingList + newCandidateList);
                $.cookie('candidate_calling',$("#TxtCandidatesInCandidateCallingList").val(),{expires:1,path:"/"});
                $("#BtnViewCandidateCallingList").css("display","");
                alert("Candidates added to candidate calling list successfully.");
            }
            $("#TxtHiiddenSelectedStep").val('');
            return false;
        }
        else{
             $("#TblViewAssignedCandidateList tbody tr td :checkbox").each(function(){
                $(this).attr("checked",false);
                $("#ChkSelectAllCandidates").attr("checked",false);
                EnableDropDown();
            });
            return false;
        }
    }
    else{
        var newCandidateList="";
        var existingCandidateCallingList=$("#TxtCandidatesInCandidateCallingList").val();
        $("#TblViewAssignedCandidateList tbody tr :checkbox").filter(":checked").each(function(){
            if(existingCandidateCallingList.indexOf($(this).parent().attr("CandidateID"))==-1){
                newCandidateList+=$(this).parent().attr("CandidateID") + "_";
            }
        });
        
        if($("#TblViewAssignedCandidateList tbody tr :checkbox").filter(":checked").size()==0){
            alert("Select atleast one candidate.");
        }
        else{
            newCandidateList=newCandidateList.substring(0,newCandidateList.length-1);
            if($.trim(existingCandidateCallingList).length>0 && newCandidateList!=''){
                existingCandidateCallingList=existingCandidateCallingList + "_";
            }
            $("#TxtCandidatesInCandidateCallingList").val(existingCandidateCallingList + newCandidateList);
            $.cookie('candidate_calling',$("#TxtCandidatesInCandidateCallingList").val(),{expires:1,path:"/"});
            $("#BtnViewCandidateCallingList").css("display","");
            alert("Candidates added to candidate calling list successfully.");
        }
        $("#TxtHiiddenSelectedStep").val('');
        return false;
    }
}

function CheckForCandidatesInCandidateCallingList(){
    if($("#TxtCandidatesInCandidateCallingList").val()!=''){
        var selectedCandidateIDs=$("#TxtCandidatesInCandidateCallingList").val().split('_');
        for(var counter=0;counter<selectedCandidateIDs.length;counter++){
            $("#TblViewAssignedCandidateList tbody tr span[CandidateID=" + selectedCandidateIDs[counter] + "]").find(":checkbox").attr("checked",true);
        }
        $("#BtnViewCandidateCallingList").css("display",'');
    }
}

function GetCandidateCalling(){ 
    var trainingProjectID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.indexOf("&train_prog"));
    window.open("CandidateCalling.aspx?train_proj="+trainingProjectID);
    return false;
}

function ConfirmDelete() {
    var IsDelete = confirm('Are you sure you want to delete the candidate ?');
    if(IsDelete == true){
        return true;
    }
    else{
        return false;
    }
}
function closeRadWindow(sender, eventArgs)
{
    

}
