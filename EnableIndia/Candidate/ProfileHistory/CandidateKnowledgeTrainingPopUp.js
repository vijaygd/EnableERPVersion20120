/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
///<reference path='../../Scripts/jquery.cookie.js' />
///<reference path='../../Scripts/common.js' />

$(document).ready(function(){

     var maxLength = parseInt(0);
   /* $("#TblViewTrainingProgram tbody tr td table tr td[id='textField']").each(function() {
        //$(this).find("label").attr("for", $(this).siblings().find(":input").attr("id"));
        if (parseInt($(this).find("label").html().length) > maxLength) {
            maxLength = parseInt($(this).find("label").html().length);
        }
    });
    $("#TblViewTrainingProgram tbody tr td table tr td[id='textField']").css("width", (maxLength * 6) + 3);*/
    AttachLabelToCheckboxesIncheckedListBox("TblViewTrainingProgram","Training Program Options");
});