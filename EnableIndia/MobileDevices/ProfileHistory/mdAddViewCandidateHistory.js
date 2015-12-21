/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
///<reference path='../../Scripts/common.js' />

$(document).ready(function(){

    $("#BtnHelp").click(function() {
        ShowPopUp("../../ITextPopup.aspx?page=add_view_cand_hist", 650, 150);
    });
    
    InsertRecordNumber("TblCandidateHistory");
});

