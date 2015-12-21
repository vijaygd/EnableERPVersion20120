/// <reference path="../Scripts/jquery-2.1.4.intellisense.js" />
/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../Scripts/Common.js" />

$.noConflict();
$(document).ready(function () {
    $("#BtnHelp").click(function () {
        ShowPopUp("../ITextPopup.aspx?page=enable_ind_cand", 1000, 180);
    });
    FilterCityStates($("#ContentPlaceHolder1_DdlDisabilityTypes").val(), 'DisabiltyTypeID', 'ContentPlaceHolder1_DdlDisabilitySubTypes', 'ContentPlaceHolder1_DdlHiddenDisabilitySubTypes');

    FilterCityStates($("#ContentPlaceHolder1_DdlPresentCountry").val(), 'CountryID', 'ContentPlaceHolder1_DdlPresentAddressStates', 'ContentPlaceHolder1_DdlPresentAdrressHiddenState');

    FilterCityStates($("#ContentPlaceHolder1_DdlPermanentCountry").val(), 'CountryID', 'ContentPlaceHolder1_DdlPermanentAddressStates', 'ContentPlaceHolder1_DdlPermanentHiddenStates');

    FilterCityStates($("#ContentPlaceHolder1_DdlPresentAddressStates").val(), 'StateID', 'ContentPlaceHolder1_DdlPresentAddressCities', 'ContentPlaceHolder1_DdlPresentAddressHiddenCities');

    FilterCityStates($("#ContentPlaceHolder1_DdlPermanentAddressStates").val(), 'StateID', 'ContentPlaceHolder1_DdlPermanentAddressCities', 'ContentPlaceHolder1_DdlPermanentAddressHiddenCities');

    if ($('#ContentPlaceHolder1_TxtHiddenPresentAddressState').val() != '') {
        $("#ContentPlaceHolder1_DdlPresentAddressStates").val($("#ContentPlaceHolder1_TxtHiddenPresentAddressState").val());
        $("#ContentPlaceHolder1_DdlPresentAddressStates").change();
        $("#ContentPlaceHolder1_DdlPresentAddressCities").val($("#ContentPlaceHolder1_TxtHiddenPresentAddressCity").val());
        $("#ContentPlaceHolder1_DdlPresentAdrressHiddenState").change();
        $("#ContentPlaceHolder1_DdlPresentAddressHiddenCities").val($("#ContentPlaceHolder1_TxtHiddenPresentAddressCity").val());
        $("#ContentPlaceHolder1_DdlPresentAddressHiddenCities").change();
    }
    if ($('#ContentPlaceHolder1_TxtPermanentHiddenAddressState').val() != '') {
        $("#ContentPlaceHolder1_DdlPermanentAddressStates").val($("#ContentPlaceHolder1_TxtPermanentHiddenAddressState").val());
        $("#ContentPlaceHolder1_DdlPermanentAddressStates").change();
        $("#ContentPlaceHolder1_DdlPermanentAddressCities").val($("#ContentPlaceHolder1_TxtPermanentHiddenAddressCity").val());
        $("#ContentPlaceHolder1_DdlPermanentAddressCities").change();
        $("#ContentPlaceHolder1_DdlPermanentAddressHiddenCities").val($("#ContentPlaceHolder1_TxtPermanentHiddenAddressCity").val());
        $("#ContentPlaceHolder1_DdlPermanentAddressHiddenCities").change();
    }
    if ($('#ContentPlaceHolder1_TxtHiddenDisabilitySubTypes').val() != '') {
        $("#ContentPlaceHolder1_DdlDisabilitySubTypes").val($("#ContentPlaceHolder1_TxtHiddenDisabilitySubTypes").val());
        $("#ContentPlaceHolder1_DdlDisabilitySubTypes").change();
    }

});

function DdlPresentAddressStates_SelectedIndexChanged(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown) {
    FilterCityStates(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);
    $('#TxtHiddenPresentAddressState').val($('#DdlPresentAddressStates').val());
}

function DdlPermanentAddressStates_SelectedIndexChanged(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown) {
    FilterCityStates(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);
    $('#ContentPlaceHolder1_TxtPermanentHiddenAddressState').val($('#ContentPlaceHolder1_DdlPermanentAddressStates').val());
}

function CheckForDuplication() {
    $('#ContentPlaceHolder1_TxtHiddenPresentAddressState').val($('#ContentPlaceHolder1_DdlPresentAddressStates').val());
    $('#ContentPlaceHolder1_TxtHiddenPresentAddressCity').val($('#ContentPlaceHolder1_DdlPresentAddressCities').val());

    $('#ContentPlaceHolder1_TxtPermanentHiddenAddressState').val($('#ContentPlaceHolder1_DdlPermanentAddressStates').val());
    $('#ContentPlaceHolder1_TxtPermanentHiddenAddressCity').val($('#ContentPlaceHolder1_DdlPermanentAddressCities').val());

    var message = '' + $('#ContentPlaceHolder1_TxtCandidateFirstName').val() + ' ' + $('#ContentPlaceHolder1_TxtCandidateLastName').val() + ' already registered with same disability and date of birth. Are you sure you want to register as new candidate?';
    var isConfirmed = confirm(message);
    if (isConfirmed == true) {
        $('#ContentPlaceHolder1_TxtHiddenNumber').val('0');
        $("#ContentPlaceHolder1_BtnRegisterCandidate").click();
    }
    else {

        return false;
    }
}

function validRegistration() {
    $("#ContentPlaceHolder1_TxtRelevantDocumentDetails").attr("class", "");
    if ($("#ContentPlaceHolder1_RdbRelevantDocumentsSubmittedNo").attr("checked") == true) {
        $("#ContentPlaceHolder1_TxtRelevantDocumentDetails").attr("class", "mandatory");
    }
    var message = "";
    var noErrors = true;
    var isValid = ValidateMobileForm();

    if (isValid == true) {
        //validate Registration Date can not greter than today date
        var isRegistrationDateValid = ValidateRegistartionDate();
        if (isRegistrationDateValid == false) {
            message += "Registration date cannot be greater than today's date.\n";
            noErrors = false;
        }

        //Validates secondary phone number.
        var secondaryPhone = $("#ContentPlaceHolder1_TxtSecondaryPhoneNumber").val();
        if ($.trim(secondaryPhone) != '') {
            var isPhoneValid = ValidatePhoneNumber("TxtSecondaryPhoneNumber");
            if (isPhoneValid == false) {
                message += "Enter valid secondary phone number.\n";
                noErrors = false;
            }
        }

        //validate permanat pin code
        var permanantPin = $("#ContentPlaceHolder1_TxtPermanentAddressPinCode").val();
        if ($.trim(permanantPin) != '') {
            var isPinValid = ValidatePinCode("TxtPermanentAddressPinCode");
            if (isPinValid == false) {
                message += "Enter valid permanent address pin code.\n ";
                noErrors = false;
            }
        }
        if (noErrors == false) {
            alert(message);
        }
        return noErrors;
    }
    else {
        return false;
    }
}

function ValidateRegistartionDate() {
    var isvalid = ValidateForm();
    if (isvalid == true) {
        var currentDate = new Date();
        var enteredDate = $("#ContentPlaceHolder1_TxtRegistrationDate").val();
        var split = enteredDate.split("/");
        var registrationDate = new Date(split[2], split[1] - 1, split[0]);
        var noErrors = true;

        if (registrationDate > currentDate) {
            //alert("Registration date cannot be greater than today's date.");
            noErrors = false;
        }
        return noErrors;
    }
    else {
        return false;
    }
}

function DdlDisabilityTypes_SelectedIndexChanged() {
    var disabilityID = $("#ContentPlaceHolder1_DdlDisabilityTypes").val();
    $("#ContentPlaceHolder1_DdlDisabilitySubTypes option[DisabilityID!='']").show();
    $("#ContentPlaceHolder1_DdlDisabilitySubTypes option[DisabilityID!=" + disabilityID + "]").hide();
}
function KeyPress(sender, args) {
    var re = /^[0-9\-\:\/]$/;
    args.set_cancel(!re.test(args.get_keyCharacter()));
}

function ValidateMobileForm() {
    var errorMessage = "";
    var isFocus = false;
    $("#TblContentBody .mandatory").each(function () {
        switch ($(this).attr("type")) {
            case "text":
                if ($.trim($(this).val()) == '') {
                    errorMessage += $(this).attr("messagetext") + " is required.\n";
                    if (isFocus == false) {
                        isFocus = true;
                        $(this).focus();
                    }
                }
                    //Validates email address
                else if ($(this).attr("emailaddress")) {
                    var isValid = ValidateEmailAddres($.trim($(this).val()));
                    if (isValid == false) {
                        errorMessage += "Enter valid email address.\n";
                        if (isFocus == false) {
                            isFocus = true;
                            $(this).focus();
                        }
                    }
                }
                    //Validates date
                else if ($(this).attr("date")) {
                    isValid = ValidateDate($.trim($(this).val()), $(this).attr("yearlength"), false, "");
                    if (isValid == false) {
                        errorMessage += "Enter valid " + $(this).attr("messagetext") + ".\n";
                        if (isFocus == false) {
                            isFocus = true;
                            $(this).focus();
                        }
                    }
                }
                    //Validates time
                else if ($(this).attr("time")) {
                    isValid = ValidateTime($.trim($(this).val()), false, "");
                    if (isValid == false) {
                        errorMessage += "Enter valid " + $(this).attr("messagetext") + ".\n";
                        if (isFocus == false) {
                            isFocus = true;
                            $(this).focus();
                        }
                    }
                }
                    //Validates phone number and pin code
                else if ($(this).attr("phonenumber")) {
                    isValid = ValidatePhoneNumber($(this).attr("id"));
                    if (isValid == false) {
                        errorMessage += "Enter valid " + $(this).attr("messagetext") + ".\n";
                        if (isFocus == false) {
                            isFocus = true;
                            $(this).focus();
                        }
                    }
                }
                else if ($(this).attr("pincode")) {
                    isValid = ValidatePinCode($(this).attr("id"));
                    if (isValid == false) {
                        errorMessage += "Enter valid " + $(this).attr("messagetext") + ".\n";
                        if (isFocus == false) {
                            isFocus = true;
                            $(this).focus();
                        }
                    }
                }
                    //Validates salary
                else if ($(this).attr("salary")) {
                    isValid = ValidateSalary($(this).attr("id"));
                    if (isValid == false) {
                        errorMessage += "Enter valid " + $(this).attr("messagetext") + ".\n";
                        if (isFocus == false) {
                            isFocus = true;
                            $(this).focus();
                        }
                    }
                }

                break;

            case "password":
                if ($.trim($(this).val()) == '') {
                    errorMessage += $(this).attr("messagetext") + " is required.\n";
                    if (isFocus == false) {
                        isFocus = true;
                        $(this).focus();
                    }
                }
                break;

            case "textarea":
                if ($.trim($(this).val()) == '') {
                    errorMessage += $(this).attr("messagetext") + " is required.\n";
                    if (isFocus == false) {
                        isFocus = true;
                        $(this).focus();
                    }
                }
                break;

            case "table":
                //Used to validate radio buttons
                if ($(this).find(":radio").filter(":checked").size() == 0) {
                    errorMessage += "Select " + $(this).attr("messagetext") + ".\n";
                    if (isFocus == false) {
                        isFocus = true;
                        $(this).focus();
                    }
                }

            case "file":
                //used to validate file extensions
                if ($.trim($(this).val()) != '') {
                    var fileName = $(this).val();
                    var split = fileName.split('.');
                    var fileExtension = split[split.length - 1].toLowerCase();
                    if (fileExtension != 'jpg' && fileExtension != 'jpeg' && fileExtension != 'gif') {
                        errorMessage += "Only jpg,jpeg,gif are allowed.\n";
                        if (isFocus == false) {
                            isFocus = true;
                            $(this).focus();
                        }
                    }
                }
                break;

            case "select-one":
                if (parseInt($(this).val()) <= 0 && $(this).css("display") != 'none') {
                    errorMessage += $(this).attr("messagetext") + " is required.\n";
                    if (isFocus == false) {
                        isFocus = true;
                        $(this).focus();
                    }
                }
                break;
        };
    });

    errorMessage += ValidateCheckedListBoxes();

    if ($.trim(errorMessage) == '') {
        return true;
    }
    else {
        alert(errorMessage);
        return false;
    }
}
