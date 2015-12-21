/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../../Scripts/Common.js" />
$.noConflict();
$(document).ready(function () {
    $("#BtnHelp").click(function () {
        ShowPopUp("../../ITextPopup.aspx?page=enable_ind_cand", 1000, 180);
    });
    FilterCityStates($("#DdlDisabilityTypes").val(), 'DisabiltyTypeID', 'DdlDisabilitySubTypes', 'DdlHiddenDisabilitySubTypes');

    FilterCityStates($("#DdlPresentCountry").val(), 'CountryID', 'DdlPresentAddressStates', 'DdlPresentAdrressHiddenState');

    FilterCityStates($("#DdlPermanentCountry").val(), 'CountryID', 'DdlPermanentAddressStates', 'DdlPermanentHiddenStates');

    FilterCityStates($("#DdlPresentAddressStates").val(), 'StateID', 'DdlPresentAddressCities', 'DdlPresentAddressHiddenCities');

    FilterCityStates($("#DdlPermanentAddressStates").val(), 'StateID', 'DdlPermanentAddressCities', 'DdlPermanentAddressHiddenCities');

    if ($('#TxtHiddenPresentAddressState').val() != '') {
        $("#DdlPresentAddressStates").val($("TxtHiddenPresentAddressState").val());
        $("#DdlPresentAddressStates").change();
        $("#DdlPresentAddressCities").val($("TxtHiddenPresentAddressCity").val());
        $("#DdlPresentAdrressHiddenState").change();
        $("#DdlPresentAddressHiddenCities").val($("TxtHiddenPresentAddressCity").val());
        $("#DdlPresentAddressHiddenCities").change();
    }
    if ($('#TxtPermanentHiddenAddressState').val() != '') {
        $("#DdlPermanentAddressStates").val($("TxtPermanentHiddenAddressState").val());
        $("#DdlPermanentAddressStates").change();
        $("#DdlPermanentAddressCities").val($("TxtPermanentHiddenAddressCity").val());
        $("#DdlPermanentAddressCities").change();
        $("#DdlPermanentAddressHiddenCities").val($("TxtPermanentHiddenAddressCity").val());
        $("#DdlPermanentAddressHiddenCities").change();
    }
    if ($('#TxtHiddenDisabilitySubTypes').val() != '') {
        $("#DdlDisabilitySubTypes").val($("TxtHiddenDisabilitySubTypes").val());
        $("#DdlDisabilitySubTypes").change();
    }

});

function DdlPresentAddressStates_SelectedIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown){
    FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
    $('#TxtHiddenPresentAddressState').val($('#DdlPresentAddressStates').val());
}

function DdlPermanentAddressStates_SelectedIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown){
    FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
    $('#TxtPermanentHiddenAddressState').val($('#DdlPermanentAddressStates').val());
}

function CheckForDuplication(){
    $('#TxtHiddenPresentAddressState').val($('#DdlPresentAddressStates').val());
    $('#TxtHiddenPresentAddressCity').val($('#DdlPresentAddressCities').val());
    
    $('#TxtPermanentHiddenAddressState').val($('#DdlPermanentAddressStates').val());
    $('#TxtPermanentHiddenAddressCity').val($('#DdlPermanentAddressCities').val());
    
    var message=''+ $('#TxtCandidateFirstName').val() + ' ' + $('#TxtCandidateLastName').val() + ' already registered with same disability and date of birth. Are you sure you want to register as new candidate?';
    var isConfirmed = confirm(message);
    if(isConfirmed==true){
        $('#TxtHiddenNumber').val('0');
        $("#BtnRegisterCandidate").click();
    }
    else{
       
        return false;
    }
}

function validRegistration(){
    $("#TxtRelevantDocumentDetails").attr("class","");
    if($("#RdbRelevantDocumentsSubmittedNo").attr("checked")==true){
        $("#TxtRelevantDocumentDetails").attr("class","mandatory");
    }
    var message="";
    var noErrors=true;
    var isValid=ValidateForm();
    
    if(isValid==true){
        //validate Registration Date can not greter than today date
        var isRegistrationDateValid=ValidateRegistartionDate();
        if(isRegistrationDateValid==false){
            message+="Registration date cannot be greater than today's date.\n";
            noErrors=false;
        }
    
        //Validates secondary phone number.
        var secondaryPhone=$("#TxtSecondaryPhoneNumber").val();
        if($.trim(secondaryPhone)!=''){
            var isPhoneValid=ValidatePhoneNumber("TxtSecondaryPhoneNumber");
            if(isPhoneValid==false){
                message+="Enter valid secondary phone number.\n";
                noErrors=false;
            }
        }
        
        //validate permanat pin code
        var permanantPin=$("#TxtPermanentAddressPinCode").val();
        if($.trim(permanantPin)!=''){
            var isPinValid=ValidatePinCode("TxtPermanentAddressPinCode");
            if(isPinValid==false){
                message+="Enter valid permanent address pin code.\n ";
                noErrors=false;
            }
        }
        if(noErrors==false){
            alert(message);
        }
        return noErrors;
    }
    else{
        return false;
    }
}

function ValidateRegistartionDate(){   
    var isvalid=ValidateForm();
    if(isvalid==true){
        var currentDate=new Date();
        var enteredDate =$("#TxtRegistrationDate").val();
        var split=enteredDate.split("/");
        var registrationDate=new Date(split[2],split[1]-1,split[0]);
        var noErrors=true;
        
        if(registrationDate>currentDate){
            //alert("Registration date cannot be greater than today's date.");
            noErrors=false;
        }
        return noErrors;
    }
    else{
        return false;
    }
}

function DdlDisabilityTypes_SelectedIndexChanged(){
    var disabilityID = $("#DdlDisabilityTypes").val();
    $("#DdlDisabilitySubTypes option[DisabilityID!='']").show();
    $("#DdlDisabilitySubTypes option[DisabilityID!=" + disabilityID + "]").hide();
}
function KeyPress(sender, args) {
    var re = /^[0-9\-\:\/]$/;
    args.set_cancel(!re.test(args.get_keyCharacter()));
}
