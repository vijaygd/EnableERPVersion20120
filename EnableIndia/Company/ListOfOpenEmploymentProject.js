
/// <reference path="../Scripts/jquery-2.0.2.min.js" />
///<reference path='../Scripts/Common.js' />

$(document).ready(function(){
     $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=list_of_emp_proj", 950, 400);
    });
    
    AttachLabelToRadioButtonsInListView("TblEmploymentProjects");
    InsertRecordNumber("TblEmploymentProjects");
});

function ValidateEntry(){
    if($("#TblEmploymentProjects tbody :radio:checked").length==0){
        alert("Please select an employment project.");
        return false;
    }
}

function ValidateProjectStatus(status)
{
    var tr = $('#TblEmploymentProjects tbody tr :radio:checked').parents('tr:first');
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

function GoSearchParameter(){
       var message="";
    var datesValid=true;
    
    var possibleDateFrom=$("#TxtPossibleStartDateFrom").val();
    if($.trim(possibleDateFrom)!=''){
        var isDateFromValid = ValidateDate(possibleDateFrom,4,false,"");
        if(isDateFromValid==false){
            message+="Enter valid possible start from date.\n";
            datesValid=false;
        }
    }
    
    var possibleToDate=$("#TxtPossibleStartDateTo").val();
    if($.trim(possibleToDate)!=''){
        var isDateToValid = ValidateDate(possibleToDate,4,false,"");
        if(isDateToValid==false){
            message+="Enter valid possible start to date.\n";
            datesValid=false;
        }
    }
    
      var registrationDateFrom=$("#TxtPossibleEndDateFrom").val();
    if($.trim(registrationDateFrom)!=''){
        var isDateFromValid = ValidateDate(registrationDateFrom,4,false,"");
        if(isDateFromValid==false){
            message+="Enter valid possible end from date.\n";
            datesValid=false;
        }
    }
    
    var registrationToDate=$("#TxtPossibleEndDateTo").val();
    if($.trim(registrationToDate)!=''){
        var isDateToValid = ValidateDate(registrationToDate,4,false,"");
        if(isDateToValid==false){
            message+="Enter valid possible end to date.\n";
            datesValid=false;
        }
    }
    
    if(datesValid==false){
        alert(message);
        return datesValid;
    }

}
function enabledisablerb(radio) {
    var dvData = document.getElementById("TblEmploymentProjects");
    var inputs = dvData.getElementsByTagName("input");
    var fts = false;
    for (var i = 0; i < inputs.length; i++) {
        var ele = inputs[i];
        if (ele.type == "radio") {
            if (ele == radio && ele.checked) {
                continue;
            }
            else
            {
                elechecked = false;
            }
        }
    }
    return true;
}
