/// <reference path="../Scripts/jquery-1.7.1-vsdoc.js" />
/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../Scripts/Common.js" />


$(document).ready(function () {
    $("#BtnHelp").click(function () {
        ShowPopUp("../../ITextPopup.aspx?page=AllActiveRegisteredCandidate", 500, 150);
    });
    $("#ContentPlaceHolder1_DdlRecommendedJobType").change();
    $("#ContentPlaceHolder1_DdlDisabilityTypes").change();
    SetDefaultOptionExelInReport();
    $("#ContentPlaceHolder1_TxtSalaryFrom").attr("maxlength", 7);
    $("#ContentPlaceHolder1_DdlState").change();
    $("#ContentPlaceHolder1_TxtSalaryTo").attr("maxlength", 7);

    if ($('#ContentPlaceHolder1_TxtHidddenCity').val() != '') {
        $("#ContentPlaceHolder1_DdlCities").val($("#ContentPlaceHolder1_TxtHidddenCity").val());
        $("#ContentPlaceHolder1_DdlCities").change();
    }
    else {
        $('#ContentPlaceHolder1_TxtHidddenCity').val(-1);
    }

    if ($('#ContentPlaceHolder1_SpnHiddenRecommendedRole').html() != '') {
        try {
            $("#ContentPlaceHolder1_DdlRecommendedRole").val($("#ContentPlaceHolder1_SpnHiddenRecommendedRole").html());
            $("#ContentPlaceHolder1_TxtHiddenRecommendedRole").val($('#ContentPlaceHolder1_SpnHiddenRecommendedRole').html());
        }
        catch (Error) {
            var html = "<option value='-1'>All</option>";
            html += "<option value='-2'>Unlisted</option>";
            $('#ContentPlaceHolder1_DdlRecommendedRole').html(html);
            window.setTimeout("$('#ContentPlaceHolder1_DdlRecommendedRole').val($('#ContentPlaceHolder1_SpnHiddenRecommendedRole').text())", 10);
            $("#ContentPlaceHolder1_TxtHiddenRecommendedRole").val($('#ContentPlaceHolder1_SpnHiddenRecommendedRole').html());
        }
    }

    if ($('#ContentPlaceHolder1_SpnHiddenDisabilityType').html() != '') {
        try {
            $('#ContentPlaceHolder1_DdlDisabilitySubType').val($('#ContentPlaceHolder1_SpnHiddenDisabilityType').html());
            $("#ContentPlaceHolder1_TxtHiddenDisabilitySubType").val($('#ContentPlaceHolder1_SpnHiddenDisabilityType').html());
        }
        catch (Error) {
            var html = "<option value='-1'>All</option>";
            $('#ContentPlaceHolder1_DdlDisabilitySubType').html(html);
            window.setTimeout("$('#ContentPlaceHolder1_DdlDisabilitySubType').val($('#ContentPlaceHolder1_SpnHiddenDisabilityType').text())", 10);
            $("#ContentPlaceHolder1_TxtHiddenDisabilitySubType").val($('#ContentPlaceHolder1_SpnHiddenDisabilityType').html());
        }
    }

});

function GoRegistrationDetail() {
    var rid = $.trim($("#ContentPlaceHolder1_TxtRIDForDetail").val());
    if (ValidateRID(rid) == false) {
        alert('Enter data in a proper format.');
        return false;
    }
    else {
        window.open("RegistrationDetaiFromSearch.aspx?rid=" + rid);
        return false;
    }
}

function DdlRecommendedJobType_SelectIndexChanged(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown) {
    if (parseInt($("#ContentPlaceHolder1_DdlRecommendedJobType").val()) < 0) {
        $("#ContentPlaceHolder1_DdlRecommendedRole").css('display', '');
        $("#ContentPlaceHolder1_TdRecomendedRole").css('display', '');

        var option = $("#ContentPlaceHolder1_DdlRecommendedRole option");
        var html = "<option value='-1'>All</option>";
        html += "<option value='-2'>Unlisted</option>";
        $('#ContentPlaceHolder1_DdlRecommendedRole').html(html);
        $('#ContentPlaceHolder1_TxtHiddenRecommendedRole').val($("#ContentPlaceHolder1_DdlRecommendedRole").val());
    }
    else {
        $("#ContentPlaceHolder1_TdRecomendedRole").css('display', '');
        $("#ContentPlaceHolder1_DdlRecommendedRole").css('display', '');
        FilterCityStates(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);
        var option = $("#ContentPlaceHolder1_DdlRecommendedRole option[value=-2]");
        option.html("All");
        option.attr("value", "-1");
        $('#ContentPlaceHolder1_TxtHiddenRecommendedRole').val($("#ContentPlaceHolder1_DdlRecommendedRole").val());
    }
}

function DdlDisabilityTypes_SelectedIndexChanged(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown) {
    if (parseInt($("#ContentPlaceHolder1_DdlDisabilityTypes").val()) < 0) {
        $("#ContentPlaceHolder1_DdlDisabilitySubType").css('display', '');
        $("#ContentPlaceHolder1_TdDisabilitySubType").css('display', '');

        var option = $("#ContentPlaceHolder1_DdlDisabilitySubType option");
        var html = "<option value='-1'>All</option>";
        $('#ContentPlaceHolder1_DdlDisabilitySubType').html(html);
        $('#ContentPlaceHolder1_ct100_ContentPlaceHolder_TxtHiddenDisabilitySubType').val($('#ContentPlaceHolder1_DdlDisabilitySubType').val());
    }
    else {
        $("#ContentPlaceHolder1_TdDisabilitySubType").css('display', '');
        $("#ContentPlaceHolder1_DdlDisabilitySubType").css('display', '');
        FilterCityStates(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);
        var option = $("#ContentPlaceHolder1_DdlDisabilitySubType option[value=-2]");
        option.html("All");
        option.attr("value", "-1");
        $('#ContentPlaceHolder1_ct100_ContentPlaceHolder_TxtHiddenDisabilitySubType').val($('#ContentPlaceHolder1_DdlDisabilitySubType').val());
    }
}

function DdlState_SelectIndexChanged(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown) {
    if (parseInt($("#ContentPlaceHolder1_DdlState").val()) < 0) {
        $("#ContentPlaceHolder1_DdlCities").css('display', 'none');
        $("#ContentPlaceHolder1_TdCity").css('display', 'none');
        $("#ContentPlaceHolder1_DdlCities").val($("#ContentPlaceHolder1_DdlState").val());
        $('#ContentPlaceHolder1_TxtHidddenCity').val($("#ContentPlaceHolder1_DdlCities").val());
    }
    else {
        $("#ContentPlaceHolder1_DdlCities").css('display', '');
        $("#ContentPlaceHolder1_TdCity").css('display', '');
        $('#ContentPlaceHolder1_DdlCity').css('display', '');
        FilterCityStates(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);
        var option = $("#ContentPlaceHolder1_DdlCities option[value=-2]");
        option.html("All");
        option.attr("value", "-1");
    }
}

function GoSearchParameter() {
    var message = "";
    var datesValid = true;

    var salaryFrom = $("#ContentPlaceHolder1_TxtSalaryFrom").val();
    if ($.trim(salaryFrom) != '') {
        var isSalaryValid = ValidateSalary("TxtSalaryFrom");
        if (isSalaryValid == false) {
            message += "Enter valid salary from .\n";
            datesValid = false;
        }
    }

    var salaryTo = $("#ContentPlaceHolder1_TxtSalaryTo").val();
    if ($.trim(salaryTo) != '') {
        var isSalaryValid = ValidateSalary("TxtSalaryTo");
        if (isSalaryValid == false) {
            message += "Enter valid salary to.\n";
            datesValid = false;
        }
    }

    var registrationDateFrom = $("#ContentPlaceHolder1_TxtRegistrationFrom").val();
    if ($.trim(registrationDateFrom) != '') {
        var isDateFromValid = ValidateDate(registrationDateFrom, 4, false, "");
        if (isDateFromValid == false) {
            message += "Enter valid registration From Date.\n";
            datesValid = false;
        }
    }

    var dateOfBirth = $("#ContentPlaceHolder1_TxtDateOfBirth").val();
    if ($.trim(dateOfBirth) != '') {
        var isDateFromValid = ValidateDate(dateOfBirth, 4, false, "");
        if (isDateFromValid == false) {
            message += "Enter valid registration From Date.\n";
            datesValid = false;
        }
    }

    var registrationToDate = $("#ContentPlaceHolder1_TxtRegistrationTo").val();
    if ($.trim(registrationToDate) != '') {
        var isDateToValid = ValidateDate(registrationToDate, 4, false, "");
        if (isDateToValid == false) {
            message += "Enter valid registration To Date.\n";
            datesValid = false;
        }
    }

    var employmentProjectStartDateFrom = $("#ContentPlaceHolder1_TxtEmployementProjectStartDateFrom").val();
    if ($.trim(employmentProjectStartDateFrom) != '') {
        var isDateFromValid = ValidateDate(employmentProjectStartDateFrom, 4, false, "");
        if (isDateFromValid == false) {
            message += "Enter valid employment project start date from .\n";
            datesValid = false;
        }
    }

    var employmentProjectStartDateTo = $("#ContentPlaceHolder1_TxtEmployementProjectStartDateTo").val();
    if ($.trim(employmentProjectStartDateTo) != '') {
        var isDateToValid = ValidateDate(employmentProjectStartDateTo, 4, false, "");
        if (isDateToValid == false) {
            message += "Enter valid employment project start date to.\n";
            datesValid = false;
        }
    }

    var employmentProjectEndDateFrom = $("#ContentPlaceHolder1_TxtEmploymentEndDateFrom").val();
    if ($.trim(employmentProjectEndDateFrom) != '') {
        var isDateFromValid = ValidateDate(employmentProjectEndDateFrom, 4, false, "");
        if (isDateFromValid == false) {
            message += "Enter valid employment project end date from.\n";
            datesValid = false;
        }
    }

    var employmentProjectEndDateTo = $("#ContentPlaceHolder1_TxtEmploymentEndDateTo").val();
    if ($.trim(employmentProjectEndDateTo) != '') {
        var isDateToValid = ValidateDate(employmentProjectEndDateTo, 4, false, "");
        if (isDateToValid == false) {
            message += "Enter valid employment project end date to.\n";
            datesValid = false;
        }
    }

    if (datesValid == false) {
        alert(message);
        return datesValid;
    }
    return true;
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
$('form').on("ContentPlaceHolder1_BtnGenerateReport", function () {
    Progress();
});


