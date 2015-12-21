/// <reference path="../Scripts/jquery-2.0.2.min.js" />
///<reference path='../Scripts/common.js' />

$(document).ready(function() {
    $("#BtnHelp").click(function() {
      ShowPopUp("../ITextPopup.aspx?page=AssignedListPageForClosedTrainingProjects", 600, 150);
    });
    $("#BtnGenerateReport").click(function () {
      Progress();
    });

    SetDefaultOptionExelInReport();
    $("#DdlPrograms").change();
    
    if($('#TxtHiddenProjects').val()!=''){
        $("#DdlProjects").val($("#TxtHiddenProjects").val());
        $("#DdlProjects").change();
    }
});

function DdlPrograms_SelectIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown)
{
    if(parseInt($("#DdlPrograms").val())<0){
//         var option=$("#DdlProjects option");
//        var html="<option value='-2'>All</option>";
//        $('#DdlProjects').html(html);
//        $("#DdlProjects").change();
        FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
    }
    else{
        FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
         //var option=$("#DdlProjects option[value=-2]").re;
//        var option=$("#DdlProjects option[value=-2]");
//        option.html("All");
//        option.attr("value","-1");
    }
}
function Progress() {
    setTimeout(function () {
        var POPOUP = $('<div />');
        POPOUP.addClass("popuppw");
        $('body').append(POPOUP);
        var loading = $(".load");
        loading.show();
        var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
        var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
        loading.css({ top: top, left: left });
    }, 200);
}
$('form').on("BtnGenerateReport", function () {
    Progress();
});
