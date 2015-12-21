/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../../Scripts/Common.js" />

$(document).ready(function () {

    $("#BtnHelp").click(function () {
        ShowPopUp("../../ITextPopup.aspx?page=registration", 300, 150);
    });

    FilterCityStates($("#ContentPlaceHolder1_DdlDisabilityTypes").val(), 'DisabiltyTypeID', 'ContentPlaceHolder1_DdlDisabilitySubTypes', 'ContentPlaceHolder1_DdlHiddenDisabilitySubTypes');
    $("#ContentPlaceHolder1_DdlDisabilitySubTypes").val($("#ContentPlaceHolder1_SpnHiddenDisabilitySubTypesID").html());
    $("#ContentPlaceHolder1_DdlDisabilitySubTypes").change();

    FilterCityStates($("#ContentPlaceHolder1_DdlPresentCountry").val(), 'CountryID', 'ContentPlaceHolder1_DdlPresentAddressStates', 'ContentPlaceHolder1_DdlPresentAdrressHiddenState');
    $("#ContentPlaceHolder1_DdlPresentAddressStates").val($("#ContentPlaceHolder1_SpnPresentAdrressHiddenState").html());
    $("#ContentPlaceHolder1_DdlPresentAddressStates").change();

    $("#ContentPlaceHolder1_DdlPresentAddressCities").val($("#ContentPlaceHolder1_SpnPresentAddressHiddenCitiesID").html());
    $("#ContentPlaceHolder1_DdlPresentAddressCities").change();

    FilterCityStates($("#ContentPlaceHolder1_DdlPermanentCountry").val(), 'CountryID', 'ContentPlaceHolder1_DdlPermanentAddressStates', 'ContentPlaceHolder1_DdlPermanentHiddenStates');
    $("#ContentPlaceHolder1_DdlPermanentAddressStates").val($("#ContentPlaceHolder1_SpnPermanentHiddenStates").html());
    $("#ContentPlaceHolder1_DdlPermanentAddressStates").change();

    FilterCityStates($("#ContentPlaceHolder1_DdlPresentAddressStates").val(), 'StateID', 'ContentPlaceHolder1_DdlPresentAddressCities', 'ContentPlaceHolder1_DdlPresentAddressHiddenCities');
    $("#ContentPlaceHolder1_DdlPresentAddressCities").val($("#ContentPlaceHolder1_SpnPresentAddressHiddenCitiesID").html());
    $("#ContentPlaceHolder1_DdlPresentAddressCities").change();
    $("#ContentPlaceHolder1_TxtHiddenPresentAddressCity").val($("#ContentPlaceHolder1_SpnPresentAddressHiddenCitiesID").html());


    FilterCityStates($("#ContentPlaceHolder1_DdlPermanentAddressStates").val(), 'StateID', 'ContentPlaceHolder1_DdlPermanentAddressCities', 'ContentPlaceHolder1_DdlPermanentAddressHiddenCities');
    $("#ContentPlaceHolder1_DdlPermanentAddressCities").val($("#ContentPlaceHolder1_SpnPermanentAddressHiddenCitiesID").html());
    $("#ContentPlaceHolder1_DdlPermanentAddressCities").change();

    $("#ContentPlaceHolder1_TxtPermanentHiddenAddressCity").val($("#ContentPlaceHolder1_SpnPermanentAddressHiddenCitiesID").html());
    //Setting value of hidden controls for address and  phone number to check whether it's changed or not
    $("#ContentPlaceHolder1_SpnHiddenPresentAddress").html($("#ContentPlaceHolder1_TxtPresentAddress").val());
    $("#ContentPlaceHolder1_SpanHiddenStateID").html($("#ContentPlaceHolder1_DdlPresentAddressStates").val());
    $("#ContentPlaceHolder1_SpnHiddenCityID").html($("#ContentPlaceHolder1_DdlPresentAddressCities").val());
    $("#ContentPlaceHolder1_SpnHiddenPinCode").html($("#ContentPlaceHolder1_TxtPresentAddressPinCode").val());

    $("#ContentPlaceHolder1_SpnHiddenPhoneNumber").html($("#ContentPlaceHolder1_TxtPrimaryPhoneNumber").val());


    //Makes primary phone number and present adress non mandatory for other NGO candidate
    var registrationID = $("#ContentPlaceHolder1_SpnRegistrationID").html();
    if (registrationID.indexOf("N") != -1) {
        $("#ContentPlaceHolder1_lblPrimaryPhoneNumber").html("Phone Number (Primary)");
        $("#ContentPlaceHolder1_TxtPrimaryPhoneNumber").removeAttr("class");

        $("#ContentPlaceHolder1_TdPresentAddress").html("Address (Present)");
        $("#ContentPlaceHolder1_TxtPresentAddress").removeAttr("class");

        $("#ContentPlaceHolder1_TxtPresentAddressPinCode").removeAttr("class");
        $("#ContentPlaceHolder1_TxtPermanentAddress").removeAttr("class");
        $("#ContentPlaceHolder1_DdlPermanentCountry").removeAttr("class");
        $("#ContentPlaceHolder1_DdlPermanentAddressStates").removeAttr("class");
        $("#ContentPlaceHolder1_DdlPermanentAddressCities").removeAttr("class");
        $("#ContentPlaceHolder1_TxtPermanentAddressPinCode").removeAttr("class");
    }

    //make parmennt address is capital in enable india candidate
    var registrationID = $("#ContentPlaceHolder1_SpnRegistrationID").html();
    if (registrationID.indexOf("A") != -1) {
        $("#ContentPlaceHolder1_SpnParmanentAddress").css('text-transform', 'uppercase');
        $("#ContentPlaceHolder1_LblCountry").css('text-transform', 'uppercase');
        $("#ContentPlaceHolder1_LblState").css('text-transform', 'uppercase');
        $("#ContentPlaceHolder1_LblCity").css('text-transform', 'uppercase');
        $("#ContentPlaceHolder1_LblPinCode").css('text-transform', 'uppercase');
        $("#ContentPlaceHolder1_LblPresentPin").css('text-transform', 'uppercase');

    }

    if ($('#ContentPlaceHolder1_TxtHiddenPresentAddressState').val() != '') {
        $("#ContentPlaceHolder1_DdlPresentAddressStates").val($("#ContentPlaceHolder1_TxtHiddenPresentAddressState").val());
        $("#ContentPlaceHolder1_DdlPresentAddressStates").change();
        $("#ContentPlaceHolder1_DdlPresentAddressCities").val($("#ContentPlaceHolder1_TxtHiddenPresentAddressCity").val());
        $("#ContentPlaceHolder1_DdlPresentAddressCities").change();
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

function DdlPresentAddressStates_SelectedIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown)
{
    FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
    $('#ContentPlaceHolder1_TxtHiddenPresentAddressState').val($('#ContentPlaceHolder1_DdlPresentAddressStates').val());
}

function DdlPermanentAddressStates_SelectedIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown)
{
    FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
    $('#ContentPlaceHolder1_TxtPermanentHiddenAddressState').val($('#ContentPlaceHolder1_DdlPermanentAddressStates').val());
}


function CheckForDuplication(){
    $('#ContentPlaceHolder1_TxtHiddenPresentAddressState').val($('#ContentPlaceHolder1_DdlPresentAddressStates').val());
    $('#ContentPlaceHolder1_TxtHiddenPresentAddressCity').val($('#ContentPlaceHolder1_DdlPresentAddressCities').val());
    
    $('#ContentPlaceHolder1_TxtPermanentHiddenAddressState').val($('#ContentPlaceHolder1_DdlPermanentAddressStates').val());
    $('#ContentPlaceHolder1_TxtPermanentHiddenAddressCity').val($('#ContentPlaceHolder1_DdlPermanentAddressCities').val());
    
    var message=''+ $('#ContentPlaceHolder1_TxtCandidateFirstName').val() + ' ' + $('#ContentPlaceHolder1_TxtCandidateLastName').val() + ' already registered with same disability and date of birth. Are you sure you want to register as new candidate?';
    var isConfirmed = confirm(message);
    if(isConfirmed==true){
        $('#ContentPlaceHolder1_TxtHiddenNumber').val('0');
        $("#ContentPlaceHolder1_BtnRegister").click();
    }
    else{
        return false;
    }
}

function CheckForUpdation()
{
    var address=$("#ContentPlaceHolder1_SpnHiddenPresentAddress").html();
    var state=$("#ContentPlaceHolder1_SpanHiddenStateID").html();
    var city=$("#ContentPlaceHolder1_SpnHiddenCityID").html();
    var pincode=$("#ContentPlaceHolder1_SpnHiddenPinCode").html();
    
    var phonenumber=$("#ContentPlaceHolder1_SpnHiddenPhoneNumber").html();
    var isValid = ValidateForm();
            
    if(isValid==false)
    {
        return false;
    }
    else
    {
        if(document.URL.indexOf('Registration.aspx?cand=')!=-1 &&
            address!= $("#ContentPlaceHolder1_TxtPresentAddress").val() ||
            state!=$("#ContentPlaceHolder1_DdlPresentAddressStates").val() ||
            city!=$("#ContentPlaceHolder1_DdlPresentAddressCities").val()||
            pincode!=$("#ContentPlaceHolder1_TxtPresentAddressPinCode").val()||
            phonenumber != $("#ContentPlaceHolder1_TxtPrimaryPhoneNumber").val()){
        
            var firstName = $("#ContentPlaceHolder1_TxtCandidateFirstName").val();
            var lastName =$("#ContentPlaceHolder1_TxtCandidateLastName").val();
            var address=$("#ContentPlaceHolder1_TxtPresentAddress").val();
            var disibiltyTypes=$("#ContentPlaceHolder1_DdlDisabilityTypes option[selected!='']").html();
            
            return confirm("Are you sure you are updating data for "+ firstName +" "+ lastName +" from  "+ address +" who has "+disibiltyTypes+" ");
            
        }
    }
    
}

function validRegistration()
{
    $("#ContentPlaceHolder1_TxtRelevantDocumentDetails").attr("class","");
    if($("#ContentPlaceHolder1_RdbRelevantDocumentsSubmittedNo").attr("checked")==true){
        $("#ContentPlaceHolder1_TxtRelevantDocumentDetails").attr("class","mandatory");
    }
    
    var message="";
    var noErrors=true;
    
    var isValid=ValidateForm();
    
    if(isValid==true){
        //validate primary phone number.
        var primaryPhone=$("#ContentPlaceHolder1_TxtPrimaryPhoneNumber").val();
        if($.trim(primaryPhone)!=''){
            var isPhoneValid=ValidatePhoneNumber("TxtPrimaryPhoneNumber");
            if(isPhoneValid==false){
                message+="Enter valid primary phone number.\n";
                noErrors=false;
            }
        }
        
        //Validates secondary phone number.
        var secondaryPhone=$("#ContentPlaceHolder1_TxtSecondaryPhoneNumber").val();
        if($.trim(secondaryPhone)!=''){
            var isPhoneValid=ValidatePhoneNumber("TxtSecondaryPhoneNumber");
            if(isPhoneValid==false){
                message+="Enter valid secondary phone number.\n";
                noErrors=false;
            }
        }
        
        //validate primary pin code 
        var primaryPin=$("#ContentPlaceHolder1_TxtPresentAddressPinCode").val();
        if($.trim(primaryPin)!=''){
            var isPinValid=ValidatePinCode("TxtPresentAddressPinCode");
            if(isPinValid==false){
                message+="Enter valid present address pin code.\n";
                noErrors=false;
            }
        }
        
        
        //validate permanat pin code.
        var permanantPin=$("#ContentPlaceHolder1_TxtPermanentAddressPinCode").val();
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
