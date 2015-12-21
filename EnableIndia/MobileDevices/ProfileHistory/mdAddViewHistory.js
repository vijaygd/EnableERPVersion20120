/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
///<reference path='../../Scripts/jquery.cookie.js' />
///<reference path='../../Scripts/common.js' />

$(document).ready(function() {
     if (document.URL.indexOf("msg") == -1 ){
	    DdlFlags_SelectedIndexChanged();
	}
	else{
	    if($("#DdlFlags").val()==1){
	    DdlFlags_SelectedIndexChanged();
	    }
	}
    //DdlFlags_SelectedIndexChanged();
});

function ShowCandidateHistoryPopup(strHistoryID,strLinkButtonID) {
    var candidateID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.length);
    var url = "AddViewCandidateHistoryPopup.aspx?cand=" + candidateID;
    if(strHistoryID!="-1"){
        url+= "&hist=" + $("#TblCandidateHistory #"+strLinkButtonID).attr("CandidateHistoryID");
    }
    ShowPopUp(url, 700, 500);
}
function DdlUpdateStatus_selectedIndexChanged(){
    var updateStatus=$("#DdlUpdateStatus").val();
    if(updateStatus=="Closed"){
        alert(updateStatus.val());
        $("#DdlFlags").attr("class","mandatory");
        $("#DdlTaskManagedByEmployee").attr("class","mandatory");
    }
    else{
        $("#DdlFlags").attr("class","");
        $("#DdlTaskManagedByEmployee").attr("class","");
    }
}

function ValidateClosureDate()
{
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
    
    var isvalid=ValidateForm();
    if(isvalid==true){
        var closureDate=$("#TxtFollowUpDate").val();
        if($.trim(closureDate)!='')
        {
           var dateValid=ValidateDate(closureDate,4,true,"Date");
           if(dateValid==false){
                //alert("Date");
                return false
           }
        }
    }
    else{
        return false;
    }
}

function DdlFlags_SelectedIndexChanged()
{
    if($("#DdlFlags").val()==1){
        $("#DdlTaskManagedByEmployee").attr('disabled',true);
        $("#TxtRecommendedAction").attr('disabled',true);
        $("#TxtFollowUpDate").attr('disabled',true);
        $("#DdlTaskManagedByEmployee").attr('selectedIndex',0);
        $("#TxtRecommendedAction").val("");
        $("#TxtFollowUpDate").val("");
        
        
        var option=$("#DdlUpdateStatus option");
        var html="<option value='NA'>NA</option>";
        $('#DdlUpdateStatus').html(html);
        $("#DdlUpdateStatus").attr('disabled',true);
    }
    else{
        $("#DdlTaskManagedByEmployee").attr('disabled',false);
        $("#TxtRecommendedAction").attr('disabled',false);
        $("#TxtFollowUpDate").attr('disabled',false);
        $("#DdlUpdateStatus").attr('disabled',false);
        var option=$("#DdlUpdateStatus option");
        var html="<option value='Open'>Open</option>";
        html+="<option value='Closed'>Closed</option>";
        $('#DdlUpdateStatus').html(html);
        
    }

}