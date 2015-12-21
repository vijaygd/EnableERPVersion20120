$(document).ready(function(){
    $("#BtnHelp").click(function(){
       ShowPopUp("../ITextPopup.aspx?page=AssignedListPageForClosedEmploymentProjects", 600, 150);
    });
    $("#BtnGenerateReport").click(function () {
        Progress();
     });


    SetDefaultOptionExelInReport();
    $("#DdlVacancy").change();

    if($('#TxtHiddenEmploymentProject').val() != '') {
        $("#DdlEmploymentProject").val($("#TxtHiddenEmploymentProject").val());
        $("#DdlEmploymentProject").change();
    }
});

function DdlVacancy_SelectIndexChanged(vacancyID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown){
    if(parseInt($("#DdlVacancy").val()) < 0){
        FilterCityStates(vacancyID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
    }
    else{
        FilterCityStates(vacancyID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);
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
