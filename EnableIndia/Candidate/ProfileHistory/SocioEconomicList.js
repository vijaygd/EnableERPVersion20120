/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../Scripts/Common.js" />

$(document).ready(function () {

    $("#BtnHelp").click(function () {
        ShowPopUp("../../ITextPopup.aspx?page=work_exp", 400, 150);
    });

    InsertRecordNumber("TblExistingSocioEconomicIndicator");
});

