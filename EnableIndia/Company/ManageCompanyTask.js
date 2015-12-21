/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path='../Scripts/common.js' />


$(document).ready(function() {
        $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=task_manage_company", 800, 190);
        });
       
        InsertRecordNumber("TblViewOpenCompanyTasks");
});


function ShowCompanyOpenTaskPopup(strLinkButtonID) {
    //var candidateID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.length);
    var historyID= $("#TblViewOpenCompanyTasks #"+strLinkButtonID).attr("CandidateHistoryID");
    var url = "AddViewCompanyHistoryPopup.aspx?comp_hist=" + historyID;
    ShowPopUp(url, 700, 500);
}

function DdlParameters_OnSelectedIndexChanged(){
    $("#DdlFlags").hide();
    $("#DdlEmployee").hide();
    
    switch($("#DdlParameters").val()){
        case "flag":
            $("#DdlFlags").show();
            break;
            
        case "managed_by":
            $("#DdlEmployee").show();
            break;
    }
}

function ResetAllDropDown(){
    $("#DdlFlags").attr("selectedIndex",0);
    $("#DdlEmployee").attr("selectedIndex",0);
}

function GoSearchParameter()
{
    var message="";
    var datesValid=true;
    
    var registrationDateFrom=$("#TxtDateFrom").val();
    if($.trim(registrationDateFrom)!=''){
        var isDateFromValid = ValidateDate(registrationDateFrom,4,false,"");
        if(isDateFromValid==false){
            message+="Enter valid  From Date.\n";
            datesValid=false;
        }
    }
    
    var registrationToDate=$("#TxtDateTo").val();
    if($.trim(registrationToDate)!=''){
        var isDateToValid = ValidateDate(registrationToDate,4,false,"");
        if(isDateToValid==false){
            message+="Enter valid  To Date.\n";
            datesValid=false;
        }
    }
    
    if(datesValid==false){
        alert(message);
        return datesValid;
    }
    
}