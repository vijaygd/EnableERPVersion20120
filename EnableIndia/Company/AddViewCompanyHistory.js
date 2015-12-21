

/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path='../Scripts/jquery.cookie.js' />
/// <reference path='../Scripts/common.js' />


$(document).ready(function() {
        $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=add_view_comp_hist", 600, 150);
        });
InsertRecordNumber("TblCompanyHistory");
 $("#DdlParentCompany").change();
// if( $("#TxtHiddenText").val()=="1"){
// alert();
//    $("#TxtHiddenText").val("1")
// }
 
 if($('#TxtHiddenCompanyID').val()!=''){
        $("#DdlCompanyCode").val($("#TxtHiddenCompanyID").val());
        $("#DdlCompanyCode").change();
    }
    
  FilterCityStates($("#DdlParentCompany").val(),'ParentCompanyID','DdlCompanyCode','DdlHiddenCompanyCode');
  $("#DdlCompanyCode").val($("#TxtHiddenCompanyID").val());
        
});


function ShowCandidateHistoryPopup(strHistoryID, strLinkButtonID) {
	//var candidateID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.length);
	var isReturn= ValidateForm();
	if(isReturn==true){
	    if($("#TxtHiddenCompanyID").val()!=$("#SpnHiddenCompanyID").html()){
	        alert("Please hit Submit button to refresh existing history.");
	        return false;
	    }
	    else{
	        var parentCompanyID=EncryptID($("#DdlParentCompany").val());
	        var companyID=EncryptID($("#TxtHiddenCompanyID").val());
	        var url = "AddViewCompanyHistoryPopup.aspx"; 
	        //#
	        url+="?par_comp="+parentCompanyID+"&comp="+companyID+"";
	        if (strHistoryID != "-1") {
		        url += "&comp_hist=" + $("#TblCompanyHistory #" + strLinkButtonID).attr("CandidateHistoryID");
	        }
	        ;
	        ShowPopUp(url, 700, 500);
	    }
	}
	else{
	    return false;
	}
}

function DdlParentCompany_SelectIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown)
{
     FilterCityStates(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);
      $("#DdlCompanyCode").val($("#TxtHiddenCompanyID").val());
      $("#DdlCompanyCode").change();
//      if($("#TxtHiddenText").val()!=1){
//      $("#TxtHiddenText").val("0");
//      }
}