
/// <reference path="../Scripts/jquery-1.7.1-vsdoc.js" />
/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../Scripts/Common.js" />

$(document).ready(function () {
    $("#BtnHelp").click(function () {
        ShowPopUp("../ITextPopup.aspx?page=AllActiveRegisteredCandidate", 500, 150);
    });
    $("#DdlRecommendedJobType").change();
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

function GoRegistrationDetail(){
    var rid = $.trim($("#TxtRIDForDetail").val());
    if(ValidateRID(rid)==false ){
        alert('Enter data in a proper format.');
        return false;    
    }
    else{  
        window.open("RegistrationDetaiFromSearch.aspx?rid="+rid);
        return false;    
    }
}

function DdlRecommendedJobType_SelectIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown){
    if(parseInt($("#DdlRecommendedJobType").val())<0){
        $("#DdlRecommendedRole").css('display', '');
        $("#TdRecomendedRole").css('display', '');
        
        var option=$("#DdlRecommendedRole option");
        var html="<option value='-1'>All</option>";
        html+="<option value='-2'>Unlisted</option>";
        $('#DdlRecommendedRole').html(html);
        $('#TxtHiddenRecommendedRole').val($("#DdlRecommendedRole").val());
    }
    else{
        $("#TdRecomendedRole").css('display', '');
        $("#DdlRecommendedRole").css('display', '');
        FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
        var option=$("#DdlRecommendedRole option[value=-2]");
        option.html("All");
        option.attr("value","-1");
        $('#TxtHiddenRecommendedRole').val($("#DdlRecommendedRole").val());
    }
}

function DdlDisabilityTypes_SelectedIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown){
    if(parseInt($("#DdlDisabilityTypes").val())<0){
        $("#DdlDisabilitySubType").css('display','');
        $("#TdDisabilitySubType").css('display','');
        
        var option=$("#DdlDisabilitySubType option");
        var html="<option value='-1'>All</option>";
        $('#DdlDisabilitySubType').html(html);
        $('#ct100_ContentPlaceHolder_TxtHiddenDisabilitySubType').val($('#DdlDisabilitySubType').val());
    }
    else{
        $("#TdDisabilitySubType").css('display','');
        $("#DdlDisabilitySubType").css('display','');
        FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
        var option=$("#DdlDisabilitySubType option[value=-2]");
        option.html("All");
        option.attr("value","-1");
        $('#ct100_ContentPlaceHolder_TxtHiddenDisabilitySubType').val($('#DdlDisabilitySubType').val());
    }
}

function DdlState_SelectIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown){
    if(parseInt($("#DdlState").val())<0){
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

function GoSearchParameter(){
    var message="";
    var datesValid=true;
    
    var salaryFrom=$("#TxtSalaryFrom").val();
    if($.trim(salaryFrom)!=''){
        var isSalaryValid=ValidateSalary("TxtSalaryFrom");
        if(isSalaryValid==false){
            message+="Enter valid salary from .\n";
            datesValid=false; 
        }
    }
        
    var salaryTo=$("#TxtSalaryTo").val();
    if($.trim(salaryTo)!=''){
        var isSalaryValid=ValidateSalary("TxtSalaryTo");
        if(isSalaryValid==false){
            message+="Enter valid salary to.\n";
            datesValid=false;
        }
    }
    
    var registrationDateFrom=$("#TxtRegistrationFrom").val();
    if($.trim(registrationDateFrom)!=''){
        var isDateFromValid = ValidateDate(registrationDateFrom,4,false,"");
        if(isDateFromValid==false){
            message+="Enter valid registration From Date.\n";
            datesValid=false;
        }
    }
    
    var dateOfBirth=$("#TxtDateOfBirth").val();
    if($.trim(dateOfBirth)!=''){
        var isDateFromValid=ValidateDate(dateOfBirth,4,false,"");
        if(isDateFromValid==false){
            message+="Enter valid registration From Date.\n";
            datesValid=false;
        }
    }
    
    var registrationToDate=$("#TxtRegistrationTo").val();
    if($.trim(registrationToDate)!=''){
        var isDateToValid = ValidateDate(registrationToDate,4,false,"");
        if(isDateToValid==false){
            message+="Enter valid registration To Date.\n";
            datesValid=false;
        }
    }
     
    var employmentProjectStartDateFrom=$("#TxtEmployementProjectStartDateFrom").val();
    if($.trim(employmentProjectStartDateFrom)!=''){
        var isDateFromValid = ValidateDate(employmentProjectStartDateFrom,4,false,"");
        if(isDateFromValid==false){
            message+="Enter valid employment project start date from .\n";
            datesValid=false;
        }
    }
    
    var employmentProjectStartDateTo=$("#TxtEmployementProjectStartDateTo").val();
    if($.trim(employmentProjectStartDateTo)!=''){
        var isDateToValid = ValidateDate(employmentProjectStartDateTo,4,false,"");
        if(isDateToValid==false){
            message+="Enter valid employment project start date to.\n";
            datesValid=false;
        }
    }
    
    var employmentProjectEndDateFrom=$("#TxtEmploymentEndDateFrom").val();
    if($.trim(employmentProjectEndDateFrom)!=''){
        var isDateFromValid = ValidateDate(employmentProjectEndDateFrom,4,false,"");
        if(isDateFromValid==false){
            message+="Enter valid employment project end date from.\n";
            datesValid=false;
        }
    }
    
    var employmentProjectEndDateTo=$("#TxtEmploymentEndDateTo").val();
    if($.trim(employmentProjectEndDateTo)!=''){
        var isDateToValid = ValidateDate(employmentProjectEndDateTo,4,false,"");
        if(isDateToValid==false){
            message+="Enter valid employment project end date to.\n";
            datesValid=false;
        }
    }
    
    if(datesValid==false){
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
	$('form').on("BtnGenerateReport", function () {
	Progress();
});
