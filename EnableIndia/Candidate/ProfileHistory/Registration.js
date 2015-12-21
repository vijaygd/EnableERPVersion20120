/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../../Scripts/Common.js" />

$(document).ready(function () {

    $("#BtnHelp").click(function () {
        ShowPopUp("../../ITextPopup.aspx?page=registration", 300, 150);
    });

    FilterCityStates($("#DdlDisabilityTypes").val(), 'DisabiltyTypeID', 'DdlDisabilitySubTypes', 'DdlHiddenDisabilitySubTypes');
    $("#DdlDisabilitySubTypes").val($("#SpnHiddenDisabilitySubTypesID").html());
    $("#DdlDisabilitySubTypes").change();

    FilterCityStates($("#DdlPresentCountry").val(), 'CountryID', 'DdlPresentAddressStates', 'DdlPresentAdrressHiddenState');
    $("#DdlPresentAddressStates").val($("#SpnPresentAdrressHiddenState").html());
    $("#DdlPresentAddressStates").change();

    $("#DdlPresentAddressCities").val($("#SpnPresentAddressHiddenCitiesID").html());
    $("#DdlPresentAddressCities").change();

    FilterCityStates($("#DdlPermanentCountry").val(), 'CountryID', 'DdlPermanentAddressStates', 'DdlPermanentHiddenStates');
    $("#DdlPermanentAddressStates").val($("#SpnPermanentHiddenStates").html());
    $("#DdlPermanentAddressStates").change();

    FilterCityStates($("#DdlPresentAddressStates").val(), 'StateID', 'DdlPresentAddressCities', 'DdlPresentAddressHiddenCities');
    $("#DdlPresentAddressCities").val($("#SpnPresentAddressHiddenCitiesID").html());
    $("#DdlPresentAddressCities").change();
    $("#TxtHiddenPresentAddressCity").val($("#SpnPresentAddressHiddenCitiesID").html());


    FilterCityStates($("#DdlPermanentAddressStates").val(), 'StateID', 'DdlPermanentAddressCities', 'DdlPermanentAddressHiddenCities');
    $("#DdlPermanentAddressCities").val($("#SpnPermanentAddressHiddenCitiesID").html());
    $("#DdlPermanentAddressCities").change();

    $("#TxtPermanentHiddenAddressCity").val($("#SpnPermanentAddressHiddenCitiesID").html());
    //Setting value of hidden controls for address and  phone number to check whether it's changed or not
    $("#SpnHiddenPresentAddress").html($("#TxtPresentAddress").val());
    $("#SpanHiddenStateID").html($("#DdlPresentAddressStates").val());
    $("#SpnHiddenCityID").html($("#DdlPresentAddressCities").val());
    $("#SpnHiddenPinCode").html($("#TxtPresentAddressPinCode").val());

    $("#SpnHiddenPhoneNumber").html($("#TxtPrimaryPhoneNumber").val());


    //Makes primary phone number and present adress non mandatory for other NGO candidate
    var registrationID = $("#SpnRegistrationID").html();
    if (registrationID.indexOf("N") != -1) {
        $("#lblPrimaryPhoneNumber").html("Phone Number (Primary)");
        $("#TxtPrimaryPhoneNumber").removeAttr("class");

        $("#TdPresentAddress").html("Address (Present)");
        $("#TxtPresentAddress").removeAttr("class");

        $("#TxtPresentAddressPinCode").removeAttr("class");
        $("#TxtPermanentAddress").removeAttr("class");
        $("#DdlPermanentCountry").removeAttr("class");
        $("#DdlPermanentAddressStates").removeAttr("class");
        $("#DdlPermanentAddressCities").removeAttr("class");
        $("#TxtPermanentAddressPinCode").removeAttr("class");
    }

    //make parmennt address is capital in enable india candidate
    var registrationID = $("#SpnRegistrationID").html();
    if (registrationID.indexOf("A") != -1) {
        $("#SpnParmanentAddress").css('text-transform', 'uppercase');
        $("#LblCountry").css('text-transform', 'uppercase');
        $("#LblState").css('text-transform', 'uppercase');
        $("#LblCity").css('text-transform', 'uppercase');
        $("#LblPinCode").css('text-transform', 'uppercase');
        $("#LblPresentPin").css('text-transform', 'uppercase');

    }

    if ($('#TxtHiddenPresentAddressState').val() != '') {
        $("#DdlPresentAddressStates").val($("#TxtHiddenPresentAddressState").val());
        $("#DdlPresentAddressStates").change();
        $("#DdlPresentAddressCities").val($("#TxtHiddenPresentAddressCity").val());
        $("#DdlPresentAddressCities").change();
        $("#DdlPresentAddressHiddenCities").val($("#TxtHiddenPresentAddressCity").val());
        $("#DdlPresentAddressHiddenCities").change();
    }
    if ($('#TxtPermanentHiddenAddressState').val() != '') {
        $("#DdlPermanentAddressStates").val($("#TxtPermanentHiddenAddressState").val());
        $("#DdlPermanentAddressStates").change();
        $("#DdlPermanentAddressCities").val($("#TxtPermanentHiddenAddressCity").val());
        $("#DdlPermanentAddressCities").change();
        $("#DdlPermanentAddressHiddenCities").val($("#TxtPermanentHiddenAddressCity").val());
        $("#DdlPermanentAddressHiddenCities").change();

    }
    if ($('#TxtHiddenDisabilitySubTypes').val() != '') {
        $("#DdlDisabilitySubTypes").val($("#TxtHiddenDisabilitySubTypes").val());
        $("#DdlDisabilitySubTypes").change();
    }
});

function DdlPresentAddressStates_SelectedIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown)
{
    FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
    $('#TxtHiddenPresentAddressState').val($('#DdlPresentAddressStates').val());
}

function DdlPermanentAddressStates_SelectedIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown)
{
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
        $("#BtnRegister").click();
    }
    else{
        return false;
    }
}

function CheckForUpdation()
{
    var address=$("#SpnHiddenPresentAddress").html();
    var state=$("#SpanHiddenStateID").html();
    var city=$("#SpnHiddenCityID").html();
    var pincode=$("#SpnHiddenPinCode").html();
    
    var phonenumber=$("#SpnHiddenPhoneNumber").html();
    var isValid = ValidateForm();
            
    if(isValid==false)
    {
        return false;
    }
    else
    {
        if(document.URL.indexOf('Registration.aspx?cand=')!=-1 &&
            address!= $("#TxtPresentAddress").val() ||
            state!=$("#DdlPresentAddressStates").val() ||
            city!=$("#DdlPresentAddressCities").val()||
            pincode!=$("#TxtPresentAddressPinCode").val()||
            phonenumber != $("#TxtPrimaryPhoneNumber").val()){
        
            var firstName = $("#TxtCandidateFirstName").val();
            var lastName =$("#TxtCandidateLastName").val();
            var address=$("#TxtPresentAddress").val();
            var disibiltyTypes=$("#DdlDisabilityTypes option[selected!='']").html();
            
            return confirm("Are you sure you are updating data for "+ firstName +" "+ lastName +" from  "+ address +" who has "+disibiltyTypes+" ");
            
        }
    }
    
}

function validRegistration()
{
    $("#TxtRelevantDocumentDetails").attr("class","");
    if($("#RdbRelevantDocumentsSubmittedNo").attr("checked")==true){
        $("#TxtRelevantDocumentDetails").attr("class","mandatory");
    }
    
    var message="";
    var noErrors=true;
    
    var isValid=ValidateForm();
    
    if(isValid==true){
        //validate primary phone number.
        var primaryPhone=$("#TxtPrimaryPhoneNumber").val();
        if($.trim(primaryPhone)!=''){
            var isPhoneValid=ValidatePhoneNumber("TxtPrimaryPhoneNumber");
            if(isPhoneValid==false){
                message+="Enter valid primary phone number.\n";
                noErrors=false;
            }
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
        
        //validate primary pin code 
        var primaryPin=$("#TxtPresentAddressPinCode").val();
        if($.trim(primaryPin)!=''){
            var isPinValid=ValidatePinCode("TxtPresentAddressPinCode");
            if(isPinValid==false){
                message+="Enter valid present address pin code.\n";
                noErrors=false;
            }
        }
        
        
        //validate permanat pin code.
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
            return noErrors;
        }
        else{
            return CheckForUpdation();
        }
    }
    else{
        
        return false;
    }
}
