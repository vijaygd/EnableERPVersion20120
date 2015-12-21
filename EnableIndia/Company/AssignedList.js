
/// <reference path="../Scripts/jquery-1.7.1.min.js" />
/// <reference path="../Scripts/jquery.cookie.js" />
///<reference path='../Scripts/common.js' />

$(document).ready(function() {
	$("#BtnHelp").click(function() {
		ShowPopUp("../ITextPopup.aspx?page=assign_emp_proj", 950, 450);
	});
	$("#DivCompanyAssigenedList").pager({ pagenumber: parseInt($.cookie("grid_page_number")), pagecount: parseInt($.cookie("grid_page_count")), buttonClickCallback: PageClick });
	InsertRecordNumberWithAssignedlistPaging("TblAssignedCandidates",$.cookie("grid_page_number"));
	$("#TblAssignedCandidates tbody tr td[Step] select").change(function() {
	    CheckAssignedList($(this).attr("Step"), $(this).parents("tr:first").attr("CandidateID"));
	});
	EnableDropDown();
	CheckAtStartup();
});

function PageClick(pageNumber){
    $.cookie("grid_page_number",pageNumber,{path: '/'});
    $("#BtnSearchCandidates").click();
}

function ValidateSelection(){
    if($("#TblAssignedCandidates tbody tr td :checkbox:checked").size()==0){
        alert("Please select atleast one candidate.");
        return false;
    }
    else{
        return true;
    }
}

function AfterDelete(){
    var pageNumber=$.cookie("grid_page_number",$.cookie("grid_page_number")-1,{path: '/'});
    InsertRecordNumberWithAssignedlistPaging("TblAssignedCandidates",pageNumber);
}

function ShowWorkExperiencePopUp(strWorkExperienceID, strLinkButtonID) {
    var candidateID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.length);
    //var url = "../WorkExperiencePopup.aspx?cand=" + candidateID;
    var url = "../Candidate/WorkExperiencepopup.aspx?cand=" + candidateID;
    if (strWorkExperienceID != "-1") {
        url += "&work_exp=" + $("#TblExistingWorkExperience #" + strLinkButtonID).attr("WorkExperienceID");
    }
    URL += "&txboxId=" + self.parent.location;
    ShowPopUp(url, 880, 350);
}


function showAlertOnEmployed(pStatus, _id) {
    //   var grid = document.getElementById("LstViewExistingWorkExperience");
    //   window.alert("grid id: " + grid);
    //   var gridVal = grid.SelectedItems(1).SubItems(6).Text
    //   window.alert("Val: " + gridVal);

    if (pStatus == "Employed") {
        var userResponce = confirm("This candidate is already employed in company, do you want to make him unemployed?");
        if (userResponce == true) {
            ShowWorkExperiencePopUpDirectly(1, _id);
        }
        else {
            ShowWorkExperiencePopUp(-1, '');
        }
    }
    else {
        ShowWorkExperiencePopUp(-1, '');
    }
}

//function ShowWorkExperiencePopUpDirectly(candid, strWorkExperienceID) {

//    var url = "../WorkExperiencePopup.aspx?cand=" + candid;
//    if (strWorkExperienceID != "-1") {
//        url += "&work_exp=" + strWorkExperienceID;
//    }
//    else {
//        url += "&work_exp=" + '1';
//    }
//    ShowPopUp(url, 880, 350);
//}


//  changes made on 29/08/2012



//function ShowGotJobPopUp(strLinkButtonID){
//    var message="Updating Got Job will make all cells in this row uneditable.Are you sure you want to continue?";
//    var isConfirmed=confirm(message);
//    if(isConfirmed==true)
//    {
//        var candidateID=$("#TblAssignedCandidates #" + strLinkButtonID).attr("candidateID");
//        var url="../candidate/WorkExperiencePopup.aspx?cand=" + candidateID;
//        var emplomentProjectID=document.URL.substring(document.URL.indexOf("=") + 1,document.URL.indexOf("&comp"));
//        url+= "&emp_proj=" + emplomentProjectID +"&frz=action";
//        return  ShowPopUp(url,880,550);
//    }
//    else{
//        return false;
//    }



function ShowWorkExperiencePopUpDirectly(strWorkExperienceID, strWorkExperienceID1) {
    var candidateID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.length);
    var url = "../WorkExperiencePopup.aspx?cand=" + candidateID;

    if (strWorkExperienceID != "-1") {
        url += "&work_exp=" + strWorkExperienceID;
    }
    //	var candid = '<%=candId %>';
    //	var workexp = '<%=wkExp %>';
    //url = "../WorkExperiencePopup.aspx?cand=" + candid + "&work_exp=" + workexp;
    ShowPopUp(url, 880, 350);

}

function ShowNotesPopUp(strLinkButtonID){
    var employmentProjectID=document.URL.substring(document.URL.indexOf("=") + 1,document.URL.indexOf("&comp"));
    var url="../Company/CandidateNotesForEmploymentProject.aspx?emp_proj=" + employmentProjectID;
    url+= "&cand=" + $("#TblAssignedCandidates #" + strLinkButtonID).attr("candidateID");
    ShowPopUp(url,880,550);
    return false;
}

//function EnableDropDown(cbox) {
//    var cb = document.getElementById("ChkSelectCandidate");
//    $("#TblAssignedCandidates tbody tr").each(function(){
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
    $("#TblAssignedCandidates tbody tr").each(function () {
        if ($(this).find(":checkbox").is(":checked")) {
            $(this).find("select").attr('disabled', false);
        }
        else {
            $(this).find("select").attr('disabled', true);
        }
    });
}
//function EnableDropDown() {
//    $("#TblAssignedCandidates  tr td").each(function () {
//        if ($(this).is(':checked')) {
//            $(this).find("select").prop('disabled', false);
//        }
//        else {
//            $(this).find("select").prop('disabled', true);
//        }
//    });
//}
function AddToCandidteCallingList(){
    var hiddenValue=$("#TxtCandidatesInCandidateCallingList").val();
    var step=$("#TxtHiiddenSelectedStep").val();
    
    if(hiddenValue !='' && step !=''){
            var message="This will clear candidate calling list. Do you want to continue?";
            var isConfirmed = confirm(message);
            if(isConfirmed==true){
                var newCandidateList = "";
	            var existingCandidateCallingList = '';

	            $("#TblAssignedCandidates tbody tr :checkbox").filter(":checked").each(function() {
		            //Checks whether candidate exists in the list or not.If the candidate does not exist in the list, then only add it in the list.
		            if (existingCandidateCallingList.indexOf($(this).parent().attr("CandidateID")) == -1) {
			            newCandidateList += $(this).parent().attr("CandidateID") + "_";
		            }
	            });

	            if ($("#TblAssignedCandidates tbody tr :checkbox").filter(":checked").size() == 0) {
		            alert("Select atleast one candidate.");
	            }
	            else {
		            newCandidateList = newCandidateList.substring(0, newCandidateList.length - 1);
		            if($.trim(existingCandidateCallingList).length > 0 && newCandidateList != '') {
			            existingCandidateCallingList = existingCandidateCallingList + "_";
		            }
		            $("#TxtCandidatesInCandidateCallingList").val(existingCandidateCallingList + newCandidateList);
		            $.cookie('candidate_calling', $("#TxtCandidatesInCandidateCallingList").val(), { expires: 1, path: "/" });
		            $("#BtnViewCandidateCallingList").css("display", "");
		            alert("Candidates added to candidate calling list successfully.");
	            }
	            $("#TxtHiiddenSelectedStep").val('');
	            return false;
            }
            else{
                 $("#TblAssignedCandidates tbody tr td :checkbox").each(function(){
		            $(this).attr("checked", false);
		            $("#ChkSelectAll").attr("checked", false);
		            EnableDropDown();
	            });
                return false;
            }
    }
    else{
	    var newCandidateList = "";
	    var existingCandidateCallingList = $("#TxtCandidatesInCandidateCallingList").val();

	    $("#TblAssignedCandidates tbody tr :checkbox").filter(":checked").each(function() {
		    //Checks whether candidate exists in the list or not.If the candidate does not exist in the list, then only add it in the list.
		    if (existingCandidateCallingList.indexOf($(this).parent().attr("CandidateID")) == -1) {
			    newCandidateList += $(this).parent().attr("CandidateID") + "_";
		    }
	    });

	    if ($("#TblAssignedCandidates tbody tr :checkbox").filter(":checked").size() == 0) {
		    alert("Select atleast one candidate.");
	    }
	    else {
		    newCandidateList = newCandidateList.substring(0, newCandidateList.length - 1);
		    if ($.trim(existingCandidateCallingList).length > 0 && newCandidateList != '') {
			    existingCandidateCallingList = existingCandidateCallingList + "_";
		    }
		    $("#TxtCandidatesInCandidateCallingList").val(existingCandidateCallingList + newCandidateList);
		    $.cookie('candidate_calling', $("#TxtCandidatesInCandidateCallingList").val(), { expires: 1, path: "/" });
		    $("#BtnViewCandidateCallingList").css("display", "");
		    alert("Candidates added to candidate calling list successfully.");
	    }
	    $("#TxtHiiddenSelectedStep").val('');
	    return false;
	}
}

function ShowCandidateListPopup() {
	var trainingProjectID = "";
	trainingProjectID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.indexOf("&comp"));
	var url = "../candidate/ViewCandidateCallingList.aspx?emp_proj=" + trainingProjectID + "&step=" + $("#TxtHiiddenSelectedStep").val();
	ShowPopUp(url, 1200, 600);
}

function CheckCandidatesInCallingList() {
	if ($("#TxtCandidatesInCandidateCallingList").val() == '') {
		alert("Candidate calling list is empty.");
		return false;
	}
	else {
		return true;
	}
}

// validate checkbox
function validateCheckBox() {
	if ($("#TblAssignedCandidates  tr td :checkbox").filter(':checked').size() == 0) {
		alert('Select atleast one candidate.');
		return false;
	}
	else {
		return true;
	}
}

function ResetCandidateDetail() {
	var isValidCheckBox = validateCheckBox();

	if (isValidCheckBox == true) {
		$("#TblAssignedCandidates tbody tr").each(function() {
			if ($(this).find(":checkbox").attr("checked") == true) {
				$(this).find("select[Step=1]").val("-2");
				$(this).find("select[Step=1]").change();
				$(this).find(":checkbox").attr("checked", true);
			}
		});
	}
}

function CheckAtStartup(){
	$("#TblAssignedCandidates tbody tr td[Step] select").each(function(){
		$(this).siblings(":text").val($(this).val());
		var dropDown = $(this);
		var tr = dropDown.parent().parent();
		var stepNumber = parseInt(dropDown.attr("Step"));
		var candidateID= $(this).parents("tr:first").attr("CandidateID");
        if(stepNumber==13 && dropDown.val()>=0){
            $("#TblAssignedCandidates tbody tr[CandidateID=" + candidateID + "] input[title='Got Job'] ").css("visibility","visible");
        }
        else{
            $("#TblAssignedCandidates tbody tr[CandidateID=" + candidateID + "] input[title='Got Job'] ").css("visibility","hidden");
        }
		for(var counter = stepNumber + 1; counter <= 13; counter++){
		    if((dropDown.val() == '0' && (stepNumber == 2 || stepNumber == 3 || stepNumber == 4 || stepNumber == 5 || stepNumber == 6 || stepNumber == 7 || stepNumber == 8 || stepNumber == 11 || stepNumber == 12) || dropDown.val() != "-2")){
				tr.find("select[Step=" + counter + "]").css('visibility', 'visible');
			}
			else {
			    tr.find("select[Step=" + counter + "]").css('visibility', 'hidden');
			}
		}
    });
}

function CheckAssignedList(stepNumber, candidateID) {
	$("#TblAssignedCandidates tbody tr[CandidateID=" + candidateID + "] td[Step] select[Step=" + stepNumber + "]").each(function() {
		$(this).siblings(":text").val($(this).val());
		var dropDown = $(this);
		var tr = dropDown.parent().parent();
		stepNumber = parseInt(dropDown.attr("Step"));

        if(stepNumber==13 && dropDown.val()>=0){
            $("#TblAssignedCandidates tbody tr[CandidateID=" + candidateID + "] input[title='Got Job'] ").css("visibility","visible");
        }
        else{
            $("#TblAssignedCandidates tbody tr[CandidateID=" + candidateID + "] input[title='Got Job'] ").css("visibility","hidden");
        }
		if ((dropDown.val() == '0' && (stepNumber == 2 || stepNumber == 3 || stepNumber == 4 || stepNumber == 5 || stepNumber == 6 || stepNumber == 7 || stepNumber == 8 || stepNumber == 11 || stepNumber == 12) 
		    ||dropDown.val() != '0' ) && dropDown.val() != '-2') {
			tr.find("select[Step=" + (stepNumber + 1) + "]").css('visibility', 'visible');
			tr.find("select[Step=" + (stepNumber + 1) + "]").val('-2');
            tr.find("select[Step=" + (stepNumber + 1) + "]").val("-2");
                 
			if (stepNumber == 2 || stepNumber == 3 || stepNumber == 4 || stepNumber == 5 || stepNumber == 6 || stepNumber == 7 || stepNumber == 8 || stepNumber == 11 || stepNumber == 12) {
			    for (var counter = stepNumber + 1; counter <= 14; counter++) {
				    tr.find("select[Step=" + (counter + 1) + "]").val('-2');
				    if(tr.find("select[Step=" + (counter + 1) + "]").val()=='-2'){
				        tr.find("select[Step=" + (counter + 1) + "]").css('visibility', 'hidden');
				    }
			    }
			}
		} 
		else {
			for (var counter = stepNumber + 1; counter <= 13; counter++) {
				tr.find("select[Step=" + counter + "]").css('visibility', 'hidden');
				tr.find("select[Step=" + counter + "]").val('-2');
			}
		}
	});
}

function DdlEditParticularStepFrom_SelectedIndexChanged(){
    $('#DdlOutcomeOptions option').show();
    var stepNumber= $("#DdlEditParticularStepFrom").val();
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
            html+="<option value='1'>Yes</option>";
            html+="<option value='0'>No</option>";
            html+="<option value='2'>NA</option>";
            
            break;
        case "4":
            html+="<option value='1'>Yes</option>";
            html+="<option value='2'>NA</option>";
            break;
            
        case "5":
            html+="<option value='1'>Yes</option>";
            html+="<option value='2'>NA</option>";
            break;
            
        case "6":
            html+="<option value='1'>Yes</option>";
            html+="<option value='0'>No</option>";
            html+="<option value='2'>NA</option>";
            break;
            
        case "7":
            html+="<option value='1'>Yes</option>";
            html+="<option value='0'>No</option>";
            html+="<option value='2'>NA</option>";
            break;
            
         case "8":
            html+="<option value='1'>Yes</option>";
            html+="<option value='2'>NA</option>";
            break;
            
        case "9":
            html+="<option value='1'>Yes</option>";
            html+="<option value='0'>No</option>";
            break;
            
        case "10":
            html+="<option value='1'>Yes</option>";
            html+="<option value='0'>No</option>";
            break;
            
        case "11":
            html+="<option value='1'>Yes</option>";
            html+="<option value='0'>No</option>";
            html+="<option value='2'>NA</option>";
            break;
            
        case "12":
            html+="<option value='1'>Yes</option>";
            html+="<option value='0'>No</option>";
            html+="<option value='2'>NA</option>";
            break;
            
        case "13":
            html+="<option value='1'>Yes</option>";
            html+="<option value='0'>No</option>";
            html+="<option value='2'>NA</option>";
            break;
    }
    $('#DdlOutcomeOptions').html(html);
}

//function CloseParticularList() {
//	var stepNumber = parseInt($("#ctl00_ContentPlaceHolder2_DdlEditParticularStepFrom").val());
//	var selectedStepValue = $('#DdlOutcomeOptions').val();
//	var message = '';
//	var st1 = '';
//	var st2 = '';
//	var valid = true;

//	if (stepNumber < 0) {
//		message += " Particular step for all Candidates required.\n";
//		valid = false;
//	}
//	if (selectedStepValue < 0) {
//		message += " Outcome option required.\n";
//		valid = false;
//	}
//	if (valid == false) {
//		alert(message);
//		return valid;
//	} 
//	else{
//	    $('#TblAssignedCandidates tbody tr').each(function () {
//        var tr = $(this);
//        var ChkRecommendedCandidateName = tr.find(':checkbox');
//        var st1 = ("Step=" + (stepNumber - 1)).toString().trim();
//        var st2 = ("Step=" + stepNumber).toString().trim();
//        var previousStep = parseInt(tr.find('select[' + st1 + ']').val());
//        var currentStep = parseInt(tr.find('select[' + st2 + ']').val());
//        if (stepNumber == 1) {
//                if (currentStep < 0) {
//                    tr.find('select[' + st2 + ']').eq(selectedStepValue).prop('selected', true);
//                    ChkRecommendedCandidateName.attr('checked', true);
//                }
//            }
//            else {
//                if (previousStep >= 0 && currentStep < 0) {
//                    tr.find('select[' + st2 + ']').eq(selectedStepValue).prop('selected', true);
//                    ChkRecommendedCandidateName.attr('checked', true);
//                }
//            }
//	    });
//	    EnableDropDown();
//	    if ($("#TblAssignedCandidates  tr td :checkbox").filter(':checked').size() > 0) {
//			$('#BtnSubmit').click();
//		} 
//		else{
//			alert("No candidates are at this task.");
//			return false;
//		}
//		return false;
//	}
//}
function CloseParticularList() {
    var stepNumber = parseInt($("#DdlEditParticularStepFrom").val());
    var selectedStepValue = $('#DdlOutcomeOptions').val();
    var message = '';
    var valid = true;

    if (stepNumber < 0) {
        message += " Particular step for all Candidates required.\n";
        valid = false;
    }
    if (selectedStepValue < 0) {
        message += " Outcome option required.\n";
        valid = false;
    }
    if (valid == false) {
        alert(message);
        return valid;
    }
    else {
        $('#TblAssignedCandidates tbody tr').each(function () {
            var tr = $(this);
            var ChkRecommendedCandidateName = tr.find(':checkbox');
            if (ChkRecommendedCandidateName.is(":checked")) {
                var previousStep = parseInt(tr.find('select[step=' + (stepNumber - 1) + ']').val());
                var currentStep = parseInt(tr.find('select[step=' + stepNumber + ']').val());

                if (stepNumber == 1) {
                    if (currentStep < 0) {
                        tr.find('select[step=' + stepNumber + ']').val(selectedStepValue);
                        ChkRecommendedCandidateName.attr('checked', true);
                    }
                }
                else {
                    if ((previousStep >= 0 && currentStep < 0) || (previousStep == currentStep)) {
                        tr.find('select[step=' + stepNumber + ']').val(selectedStepValue);
                        ChkRecommendedCandidateName.attr('checked', true);
                    }
                }
            }
        });
        EnableDropDown();
        if ($("#TblAssignedCandidates  tr td :checkbox").filter(':checked').size() > 0) {
            $('#BtnSubmit').click();
        }
        else {
            alert("No candidates are at this task.");
            return false;
        }
        return false;
    }
}

function validateStep(){
    var stepNumber = parseInt($("#DdlCandidateCallingStep").val());
    if (stepNumber < 0) {
	    alert("Candidates calling from a particular step is required.");
	    return false;
	}
    else{
        return true;
    }
}

function AddToCandidteCallingListFromStep() {
    var hiddenValue=$("#TxtCandidatesInCandidateCallingList").val();
    var step=$("#TxtHiiddenSelectedStep").val();
    
    if(hiddenValue !='' && step ==''){
        var message="This will clear candidate calling list. Do you want to continue?";
        var isConfirmed = confirm(message);
        if(isConfirmed==true){
            var newCandidateList = "";
	        var existingCandidateCallingList = "";
	        var stepNumber = parseInt($("#DdlCandidateCallingStep").val());
	        if (stepNumber < 0) {
		        alert("Candidates calling from a particular step is required.");
		        return false;
	        } 
	        else {
	            $('#TblAssignedCandidates tbody tr').each(function() {
		            var tr = $(this);   
		            var ChkRecommendedCandidateName = tr.find(':checkbox');
		            var previousStep = parseInt(tr.find('select[step=' + (stepNumber - 1) + ']').val());
		            var currentStep = parseInt(tr.find('select[step=' + stepNumber + ']').val());

		            if (stepNumber == 1) {
			            if (currentStep < 0) {
				            newCandidateList += ChkRecommendedCandidateName.parent().attr("CandidateID") + "_";
			            }
		            }
		            else{
			            if(previousStep >=0 && currentStep < 0){
				            newCandidateList += ChkRecommendedCandidateName.parent().attr("CandidateID") + "_";
			            }
		            }
		        });

	            newCandidateList = newCandidateList.substring(0, newCandidateList.length - 1);
	            if ($.trim(existingCandidateCallingList).length > 0 && newCandidateList != '') {
		            existingCandidateCallingList = existingCandidateCallingList + "_";
	            }
	            $("#TxtCandidatesInCandidateCallingList").val(existingCandidateCallingList + newCandidateList);
	            $.cookie('candidate_calling', $("#TxtCandidatesInCandidateCallingList").val(), { expires: 1, path: "/" });
	            $("#BtnViewCandidateCallingList").css("display", "");
	            if ($("#TxtCandidatesInCandidateCallingList").val() != '') {
		            setTimeout("alert('Candidates added to candidate calling list successfully.')", 1000);
	            } 
	            else {
		            alert("No Candidates added to candidate calling list.");
	            }
	            $("#TxtHiiddenSelectedStep").val($("#DdlCandidateCallingStep").val());
	            $("#TblAssignedCandidates tbody tr td :checkbox").each(function() {
                    $(this).attr("checked", false);
                    $("#ChkSelectAll").attr("checked", false);
                    EnableDropDown();
	            });
		        return false;
	        }
        }
        else {
            return false;
        }
    }
    else{
	    var newCandidateList = "";
	    var existingCandidateCallingList = "";
	    var stepNumber = parseInt($("#DdlCandidateCallingStep").val());
	    if (stepNumber < 0) {
		    alert("Candidates calling from a particular step is required.");
		    return false;
	    } 
	    else {
	        $('#TblAssignedCandidates tbody tr').each(function() {
			    var tr = $(this);
		        var ChkRecommendedCandidateName = tr.find(':checkbox');
		        var previousStep = parseInt(tr.find('select[step=' + (stepNumber - 1) + ']').val());
		        var currentStep = parseInt(tr.find('select[step=' + stepNumber + ']').val());
		        if (stepNumber == 1) {
			        if (currentStep < 0) {
				        newCandidateList += ChkRecommendedCandidateName.parent().attr("CandidateID") + "_";
			        }
		        }
		        else {
			        if (previousStep >=0 && currentStep < 0) {
				        newCandidateList += ChkRecommendedCandidateName.parent().attr("CandidateID") + "_";
			        }
		        }
		    });
		    newCandidateList = newCandidateList.substring(0, newCandidateList.length - 1);
		    if ($.trim(existingCandidateCallingList).length > 0 && newCandidateList != '') {
			    existingCandidateCallingList = existingCandidateCallingList + "_";
		    }
		    $("#TxtCandidatesInCandidateCallingList").val(existingCandidateCallingList + newCandidateList);
		    $.cookie('candidate_calling', $("#TxtCandidatesInCandidateCallingList").val(), { expires: 1, path: "/" });
		    $("#BtnViewCandidateCallingList").css("display", "");
		    if ($("#TxtCandidatesInCandidateCallingList").val() != '') {
			    setTimeout("alert('Candidates added to candidate calling list successfully.')", 1000);
		    } else {
			    alert("No Candidates added to candidate calling list.");
		    }
		    $("#TxtHiiddenSelectedStep").val($("#DdlCandidateCallingStep").val());
		    $("#TblAssignedCandidates tbody tr td :checkbox").each(function() {
                $(this).attr("checked", false);
                $("#ChkSelectAll").attr("checked", false);
                EnableDropDown();
	        });
		    return false;
	    }
	}
}