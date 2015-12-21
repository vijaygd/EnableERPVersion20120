/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path='../Scripts/common.js' />


$(document).ready(function () {
    if (document.URL.indexOf("msg") == -1) {
        DdlFlags_SelectedIndexChanged();
    }
    else {
        if ($("#DdlFlags").val() == 1) {
            DdlFlags_SelectedIndexChanged();
        }
    }
    if (document.URL.indexOf("comp_hist") == -1) {
        FilterCityStatesInPopup($("#DdlParentCompanies").val(), 'ParentCompanyID', 'DdlCompanies', 'DdlHiddenCompany');
        $("#DdlCompanies").val($("#SpnHiddenCompanyID").html());
        $("#DdlCompanies").change();
    }

});



function ValidateClosureDate() {
     var updateStatus=$("#DdlUpdateStatus").val();
    if(updateStatus=="Closed"){
        $("#DdlFlags").attr("class","mandatory");
        if($("#DdlFlags").val()!="1")
        $("#DdlTaskManagedByEmployee").attr("class","mandatory");
    }
    else{
        $("#DdlFlags").attr("class","");
        $("#DdlTaskManagedByEmployee").attr("class","");
    }
    
	var isvalid = ValidateForm();
	if (isvalid == true) {
		var closureDate = $("#TxtFollowUpDate").val();
		if ($.trim(closureDate) != '') {
			var dateValid = ValidateDate(closureDate, 4, true, "Date");
			if (dateValid == false) {
				//alert("Date");
				return false
			}
		}
	}
	else {
		return false;
	}
}

function DdlFlags_SelectedIndexChanged() {
	if ($("#DdlFlags").val() == 1) {
		$("#DdlTaskManagedByEmployee").attr('disabled', true);
		$("#TxtRecommendedAction").attr('disabled', true);
		$("#TxtFollowUpDate").attr('disabled', true);
		$("#DdlTaskManagedByEmployee").attr('selectedIndex', 0);
		$("#TxtRecommendedAction").val("");
		$("#TxtFollowUpDate").val("");
		   var option=$("#DdlUpdateStatus option");
        var html="<option value='NA'>NA</option>";
        $('#DdlUpdateStatus').html(html);
        $("#DdlUpdateStatus").attr('disabled',true);
	}
	else {
		$("#DdlTaskManagedByEmployee").attr('disabled', false);
		$("#TxtRecommendedAction").attr('disabled', false);
		$("#TxtFollowUpDate").attr('disabled', false);
		 $("#DdlUpdateStatus").attr('disabled',false);
		  var option=$("#DdlUpdateStatus option");
        var html="<option value='Open'>Open</option>";
        html+="<option value='Closed'>Closed</option>";
        $('#DdlUpdateStatus').html(html);
	}

}

