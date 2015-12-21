/// <reference path="../Scripts/jquery-2.1.4.min.js" />
///<reference path='../Scripts/jquery.cookie.js' />
///<reference path='../Scripts/common.js' />

$(document).ready(function(){

   
});

function SelectAllCandidates(){
    $("#TblViewCandidateCallingList tbody tr td :checkbox").each(function(){
        $(this).attr("checked",true);
    });
    return false;
}
