/// <reference path="../Scripts/jquery-2.1.4.min.js" />
///<reference path='../Scripts/Common.js' />

$(document).ready(function(){
    $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=emp_list", 750, 150);
    });
    
    InsertRecordNumber("TblEmployees");
    AttachLabelToRadioButtonsInListView("TblEmployees");
});

function ValidateEdit(){
    
}