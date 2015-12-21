/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../Scripts/Common.js" />

$(document).ready(function() {
        $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=CandidateWiseTrainingAndEmploymentRelation", 800, 150);
    });
    $("#BtnGenerateReport").click(function () {
        Progress();
    });

    SetDefaultOptionExelInReport();
    $("#DdlRecommendedJobType").change();
    if($('#SpnHiddenRecommendedRole').html()!=''){
        $("#DdlRecommendedRole").val($("#SpnHiddenRecommendedRole").html());
        $("#TxtHiddenRecommendedRole").val($('#SpnHiddenRecommendedRole').html());
    }
    $("#DdlPrograms").change();
    if($('#SpnHiddenProjects').html()!=''){
        $("#DdlProjects").val($("#SpnHiddenProjects").html());
        $("#DdlProjects").change();
    }
});

function DdlRecommendedJobType_SelectIndexChanged(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown) {
    if(parseInt($("#DdlRecommendedJobType").val()) < 0) {
        $("#DdlRecommendedRole").css('display', 'none');
        $("#TdRecomendedRole").css('display', 'none');
        $('#TxtHiddenRecommendedRole').val(-1);
    }
    else{
        $("#TdRecomendedRole").css('display', '');
        $("#DdlRecommendedRole").css('display', '');
        FilterCityStates(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);

        var option = $("#DdlRecommendedRole option[value=-2]");
        option.html("All");
        option.attr("value", "-1");
        $('#TxtHiddenRecommendedRole').val($("#DdlRecommendedRole").val());
    }
}

function ValidateDurations(strDuration){
    strDuration =$.trim(strDuration);
    var noErrors=true;
    var split=strDuration.split('/');
    if(parseInt(split.length)!=2){
        noErrors = false;
    }
    else{
        //Validates month
        if(isNaN(split[0]) || parseInt(split[0]<=0) || parseInt(split[0])>12){
            noErrors = false;
        }
        //Validates year
        if(isNaN(split[1]) || parseInt(split[1].length)!=4 || parseInt(split[1])<=1900){
            noErrors = false;
        }
    }
    return noErrors;
}

function GoSearchParameter(){
    var message="";
    var datesValid=true;
    
    var registrationDateFrom=$("#TxtTrainingFromDate").val();
    if($.trim(registrationDateFrom)!=''){
        var isDateFromValid = ValidateDate(registrationDateFrom,4,false,"");
        if(isDateFromValid==false){
            message+="Enter valid training from Date.\n";
            datesValid=false;
        }
    }
    
    var registrationToDate=$("#TxtTrainingToDate").val();
    if($.trim(registrationToDate)!=''){
        var isDateToValid = ValidateDate(registrationToDate,4,false,"");
        if(isDateToValid==false){
            message+="Enter valid training to Date.\n";
            datesValid=false;
        }
    }
    
     //Validates  start date
     var employmentProjectFrom=$("#TxtEmploymentFromDate").val();
     if($.trim(employmentProjectFrom)!=''){
        if(ValidateDurations(employmentProjectFrom)==false){
            message+="Enter valid employment project from date.\n" ;
            datesValid=false;
        }
    }
    var employmentProjectTo=$("#TxtEmploymentToDate").val();
    if($.trim(employmentProjectTo)!=''){
         if(ValidateDurations(employmentProjectTo)==false){
            message+="Enter valid employment project to date.\n" ;
            datesValid=false;
        }
    }
    if(datesValid==false){
        alert(message);
        return datesValid;
    }
}

function DdlPrograms_SelectIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown){
    if (parseInt($("#DdlPrograms").val()) < 0) {
          if (Value  == -1) {
            var option = $("#DdlProjects option[value=-1]");
            var html = "<option value='-1'>All</option>";
            $('#DdlProjects').html(html);
            $('#TxtHiddenProjects').val(-1);
        }
       if(Value == -2){
        var option = $("#DdlProjects option[value=-2]");
        var html = "<option value='-2'>None</option>";
            $('#DdlProjects').html(html);
            $('#TxtHiddenProjects').val(-2);
            }
            if (Value == -3) {
                var option = $("#DdlProjects option[value=-3]");
                var html = "<option value='-3'>Any</option>";
                $('#DdlProjects').html(html);
                $('#TxtHiddenProjects').val(-3);
            }
        
    }
//     if(parseInt($("#DdlPrograms").val())= -2){
//        var option=$("#DdlProjects option");
//       // var html = "<option value='-1'>All</option>";
//        var html = "<option value='-2'>None</option>";
//       //var html = "<option value='-3'>Any</option>";
//        $('#DdlProjects').html(html);
//        $('#TxtHiddenProjects').val($("#DdlProjects").val());
//    }
//     if(parseInt($("#DdlPrograms").val())= -3){
//        var option=$("#DdlProjects option");
//        //var html = "<option value='-1'>All</option>";
//       // var html = "<option value='-2'>None</option>";
//        var html = "<option value='-3'>Any</option>";
//        $('#DdlProjects').html(html);
//        $('#TxtHiddenProjects').val($("#DdlProjects").val());
//    }
    
    else{
        FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
        var option = $("#DdlProjects option[value=-4]");
        option.html("All");
        option.attr("value", "-1");
        $('#TxtHiddenProjects').val($("#DdlProjects").val());
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
