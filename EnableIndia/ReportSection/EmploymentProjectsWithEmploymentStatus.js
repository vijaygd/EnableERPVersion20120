$(document).ready(function() {
    $("#BtnHelp").click(function() {
       ShowPopUp("../ITextPopup.aspx?page=EmploymentProjectsWithEmploymentStatus", 750, 150);
   });
   $("#BtnGenerateReport").click(function () {
       Progress();
   });


            SetDefaultOptionExelInReport();
    $("#ctl00_ContentPlaceHolder2_DdlJobType").change();

    if ($('#ctl00_ContentPlaceHolder2_TxtHiddenRole').val() != '') {
        $("#ctl00_ContentPlaceHolder2_DdlRole").val($("#ctl00_ContentPlaceHolder2_TxtHiddenRole").val());
        $("#ctl00_ContentPlaceHolder2_DdlRole").change();
    }

    $("#ctl00_ContentPlaceHolder2_DdlStates").change();

    if ($('#ctl00_ContentPlaceHolder2_TxtHiddenCity').val() != '') {
        $("#ctl00_ContentPlaceHolder2_DdlCity").val($("#ctl00_ContentPlaceHolder2_TxtHiddenCity").val());
        $("#ctl00_ContentPlaceHolder2_DdlCity").change();
    }
});

function DdlJobType_SelectIndexChanged(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown) {
    if (parseInt($("#ctl00_ContentPlaceHolder2_DdlJobType").val()) < 0) {
        $("#ctl00_ContentPlaceHolder2_DdlRole").css('display', 'none');
        $("#TdRole").css('display', 'none');
        $("#ctl00_ContentPlaceHolder2_DdlRole").val($("#ctl00_ContentPlaceHolder2_DdlJobType").val());
        $('#ctl00_ContentPlaceHolder2_TxtHiddenRole').val($("#ctl00_ContentPlaceHolder2_DdlRole").val());
    }
    else {
        $("#TdRole").css('display', '');
        $("#ctl00_ContentPlaceHolder2_DdlRole").css('display', '');
        FilterCityStates(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);

        var option = $("#ctl00_ContentPlaceHolder2_DdlRole option[value=-2]");
        option.html("All");
        option.attr("value", "-1");
    }
}

function DdlStates_SelectIndexChanged(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown) {
    if (parseInt($("#ctl00_ContentPlaceHolder2_DdlStates").val()) < 0) {
        $("#ctl00_ContentPlaceHolder2_DdlCity").css('display', 'none');
        $("#TdCity").css('display', 'none');
        $("#ctl00_ContentPlaceHolder2_DdlCity").val($("#ctl00_ContentPlaceHolder2_DdlStates").val());
        $('#ctl00_ContentPlaceHolder2_TxtHiddenCity').val($("#ctl00_ContentPlaceHolder2_DdlCity").val());
    }
    else {
        $("#TdCity").css('display', '');
        $("#ctl00_ContentPlaceHolder2_DdlCity").css('display', '');
        FilterCityStates(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);

        var option = $("#ctl00_ContentPlaceHolder2_DdlCity option[value=-2]");
        option.html("All");
        option.attr("value", "-1");
    }
}

function GoRegistrationDetail(){
   
    var projectName = $.trim($("#ctl00_ContentPlaceHolder2_TxtEmploymentProjectName").val());
    if(projectName==''){
        alert("Data not entered.");
        return false;
    
    }
    else{
        window.open("EmploymentProjectDetailFromSearch.aspx?emp_proj_name="+projectName);
        return false;
    }    
}

function GoAssignListDetail(){
    var projectName = $.trim($("#ctl00_ContentPlaceHolder2_TxtEmploymentProjectNameForAssignedList").val());
    if(projectName==''){
        alert("Data not entered.");
        return false;
    }
    else{
        window.open("AssignedListPageFromSearch.aspx?emp_proj_name="+projectName);
        return false; 
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
