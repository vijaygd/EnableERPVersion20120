/// <reference path="../Scripts/jquery-2.1.4.min.js" />
///<reference path='../Scripts/common.js' />

$(document).ready(function(){
    $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=task_manage", 800,280);
    });
    InsertRecordNumber("TblViewOpenCandidateTasks");
});

function ShowCandidateOpenTaskPopup(strHistoryID,strLinkButtonID) {
    //var candidateID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.length);
    
    var candidateID =$("#TblViewOpenCandidateTasks #"+strLinkButtonID).attr("CandidateID");
    var url = "ProfileHistory/AddViewCandidateHistoryPopup.aspx?cand=" + candidateID;
    if(strHistoryID!="-1"){
        url+= "&hist=" + $("#TblViewOpenCandidateTasks #"+strLinkButtonID).attr("CandidateHistoryID");
    }
    ShowPopUp(url, 700, 500);
}
function ResetAllDropDown(){
    $("#ctl00_ContentPlaceHolder2_DdlFlags").attr("selectedIndex",0);
    $("#ctl00_ContentPlaceHolder2_DdlEmployee").attr("selectedIndex",0);
    $("#ctl00_ContentPlaceHolder2_DdlDisabiltyTypes").attr("selectedIndex",0);
    
}

function DdlParameters_OnSelectedIndexChanged(){
    $("#ctl00_ContentPlaceHolder2_DdlFlags").hide();
    $("#ctl00_ContentPlaceHolder2_DdlEmployee").hide();
    $("#ctl00_ContentPlaceHolder2_DdlDisabiltyTypes").hide();
    
    switch($("#ctl00_ContentPlaceHolder2_DdlParameters").val()){
        case "flag":
            $("#ctl00_ContentPlaceHolder2_DdlFlags").show();
            break;
            
        case "managed_by":
            $("#ctl00_ContentPlaceHolder2_DdlEmployee").show();
            break;
            
        default:
            $("#ctl00_ContentPlaceHolder2_DdlDisabiltyTypes").show();
            
    }
}
function GoSearchParameter()
{
    var message="";
    var datesValid=true;
    
    var registrationDateFrom=$("#ctl00_ContentPlaceHolder2_TxtDateFrom").val();
    if($.trim(registrationDateFrom)!=''){
        var isDateFromValid = ValidateDate(registrationDateFrom,4,false,"");
        if(isDateFromValid==false){
            message+="Enter valid  From Date.\n";
            datesValid=false;
        }
    }
    
    var registrationToDate=$("#ctl00_ContentPlaceHolder2_TxtDateTo").val();
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