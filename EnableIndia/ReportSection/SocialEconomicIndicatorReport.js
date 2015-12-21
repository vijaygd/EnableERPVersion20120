/// <reference path="../Scripts/jquery-1.7.1-vsdoc.js" />
/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../Scripts/Common.js" />

$(document).ready(function () {
    $("#BtnHelp").click(function () {
        ShowPopUp("../ITextPopup.aspx?page=AllActiveRegisteredCandidate", 500, 150);
    });
    $("#DdlDisabilityTypes").change();
    SetDefaultOptionExelInReport();
    $("#TxtSalaryFrom").attr("maxlength", 7);
    $("#DdlState").change();
    $("#TxtSalaryTo").attr("maxlength", 7);

    if ($('#TxtHidddenCity').val() != '') {
        $("#DdlCities").val($("#TxtHidddenCity").val());
        $("#DdlCities").change();
    }
    else {
        $('#TxtHidddenCity').val(-1);
    }
    if ($('#SpnHiddenRecommendedRole').html() != '') {
        try {
            $("#DdlRecommendedRole").val($("#SpnHiddenRecommendedRole").html());
            $("#TxtHiddenRecommendedRole").val($('#SpnHiddenRecommendedRole').html());
        }
        catch (Error) {
            var html = "<option value='-1'>All</option>";
            html += "<option value='-2'>Unlisted</option>";
            $('#DdlRecommendedRole').html(html);
            window.setTimeout("$('#DdlRecommendedRole').val($('#SpnHiddenRecommendedRole').text())", 10);
            $("#TxtHiddenRecommendedRole").val($('#SpnHiddenRecommendedRole').html());
        }
    }
    if ($('#SpnHiddenDisabilityType').html() != '') {
        try {
            $('#DdlDisabilitySubType').val($('#SpnHiddenDisabilityType').html());
            $("#TxtHiddenDisabilitySubType").val($('#SpnHiddenDisabilityType').html());
        }
        catch (Error) {
            var html = "<option value='-1'>All</option>";
            $('#DdlDisabilitySubType').html(html);
            window.setTimeout("$('#DdlDisabilitySubType').val($('#SpnHiddenDisabilityType').text())", 10);
            $("#TxtHiddenDisabilitySubType").val($('#SpnHiddenDisabilityType').html());
        }
    }

});

function DdlRecommendedJobType_SelectIndexChanged(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown) {
    if (parseInt($("#DdlRecommendedJobType").val()) < 0) {
        $("#DdlRecommendedRole").css('display', '');
        $("#TdRecomendedRole").css('display', '');

        var option = $("#DdlRecommendedRole option");
        var html = "<option value='-1'>All</option>";
        html += "<option value='-2'>Unlisted</option>";
        $('#DdlRecommendedRole').html(html);
        $('#TxtHiddenRecommendedRole').val($("#DdlRecommendedRole").val());
    }
    else {
        $("#TdRecomendedRole").css('display', '');
        $("#DdlRecommendedRole").css('display', '');
        FilterCityStates(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);
        var option = $("#DdlRecommendedRole option[value=-2]");
        option.html("All");
        option.attr("value", "-1");
        $('#TxtHiddenRecommendedRole').val($("#DdlRecommendedRole").val());
    }
}

function DdlDisabilityTypes_SelectedIndexChanged(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown) {
    if (parseInt($("#DdlDisabilityTypes").val()) < 0) {
        $("#DdlDisabilitySubType").css('display', '');
        $("#TdDisabilitySubType").css('display', '');

        var option = $("#DdlDisabilitySubType option");
        var html = "<option value='-1'>All</option>";
        $('#DdlDisabilitySubType').html(html);
        $('#ct100_ContentPlaceHolder_TxtHiddenDisabilitySubType').val($('#DdlDisabilitySubType').val());
    }
    else {
        $("#TdDisabilitySubType").css('display', '');
        $("#DdlDisabilitySubType").css('display', '');
        FilterCityStates(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);
        var option = $("#DdlDisabilitySubType option[value=-2]");
        option.html("All");
        option.attr("value", "-1");
        $('#ct100_ContentPlaceHolder_TxtHiddenDisabilitySubType').val($('#DdlDisabilitySubType').val());
    }
}

function DdlState_SelectIndexChanged(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown) {
    if (parseInt($("#DdlState").val()) < 0) {
        $("#DdlCities").css('display', 'none');
        $("#TdCity").css('display', 'none');
        $("#DdlCities").val($("#DdlState").val());
        $('#TxtHidddenCity').val($("#DdlCities").val());
    }
    else {
        $("#DdlCities").css('display', '');
        $("#TdCity").css('display', '');
        $('#DdlCity').css('display', '');
        FilterCityStates(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);
        var option = $("#DdlCities option[value=-2]");
        option.html("All");
        option.attr("value", "-1");
    }
}
