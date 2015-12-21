/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../Scripts/Common.js" />


$(document).ready(function() {
    $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=ngo_list", 650, 150);
    });
    
     InsertRecordNumber("TblViewNgoDetails");
});