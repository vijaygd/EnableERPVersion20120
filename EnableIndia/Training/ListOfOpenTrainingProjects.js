/// <reference path="../Scripts/jquery-2.0.2.min.js" />
///<reference path='../Scripts/Common.js' />

$(document).ready(function() {

    $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=list_of_train_proj", 1000, 250);
    });
    AttachLabelToRadioButtonsInListView("TblTrainingProject");
    InsertRecordNumber("TblTrainingProject");
    //SelectSingleRadioButton("TblTrainingProject","RdbTrainingProject");
});

function ValidateProjectStatus(status)
{
    var tr = $('#TblTrainingProject tbody tr :radio:checked').parents('tr:first');
    var projectStatus=tr.find("td[id='TdProjectStatus']").html();
    //alert(projectStatus);
    if(projectStatus=='Not Opened'){
        alert("Project not opened as yet.");
        return false;
    }
    if(status==1){
        if(projectStatus!='Unassigned'){
            alert("Project cannot be deleted.");
            return false;
        }
        else{
              var isConfirmed=confirm("Are you sure you want to delete this project ?");
              return isConfirmed ;
        }
    }
    else{
        return true;
    }
}


function GoSearchParameter()
{
    var message="";
    var datesValid=true;
    
    var registrationDateFrom=$("#ctl00_ContentPlaceHolder2_TxtStartDateFrom").val();
    if($.trim(registrationDateFrom)!=''){
        var isDateFromValid = ValidateDate(registrationDateFrom,4,false,"");
        if(isDateFromValid==false){
            message+="Enter valid  From Date.\n";
            datesValid=false;
        }
    }
    
    var registrationToDate=$("#ctl00_ContentPlaceHolder2_TxtStartDateTo").val();
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
