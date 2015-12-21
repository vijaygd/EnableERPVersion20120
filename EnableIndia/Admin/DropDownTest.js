/// <reference path="../Scripts/jquery-2.1.4.min.js" />
///<reference path="../Scripts/common.js"/>

$(document).ready(function() {
    $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=add_dropdown", 700, 150);
    });
    FilterCityStates($("#DdlCountries").val(),'CountryID','DdlStates','DdlHiddenStates');
    DdlParameters_SelectedIndexChanged();
});

function DdlParameters_SelectedIndexChanged(){
    //Resets all dropdowns
    $("table [group=Parameters] select").attr("selectedIndex",0);
    FilterCityStates($("#DdlCountries").val(),'CountryID','DdlStates','DdlHiddenStates');

    var selectedParameter=$("#DdlParameters").val();
    $("table[group='Parameters']").css("display","none");
    $("#TblCountry #BtnRefreshStates").css("display","none");
    $("select[class='mandatory']").attr("class","");
    
    switch(selectedParameter)
    {
        case "Disability Sub Type":
            $("#TblDisabilityTypes").css("display","");
            $("#TblDisabilityTypes select").attr("class","mandatory");
            break;
    
        case "Job Role":
            $("#TblJobs").css("display","");
            $("#TblJobs select").attr("class","mandatory");
            break;
            
        case "State":
            $("#TblCountry").css("display","");
            $("#TblCountry select").attr("class","mandatory");
            break;
            
        case "City":
            $("#TblCountry").css("display","");
            $("#TblCountry select").attr("class","mandatory");
            
            $("#TblState").css("display","");
            $("#TblState select").attr("class","mandatory");
            
            $("#TblCountry #BtnRefreshStates").css("display","");
            break;
    }
}

function BtnViewOptions_Click(){
    var parameter = $("#DdlParameters :selected").attr("para");
    
    switch($("#DdlParameters :selected").val())
    {
        case "Disability Sub Type":
            ShowPopUp('ViewParameters.aspx?para=' + parameter + "&para2=" + EncryptID($("#DdlDisabilityTypes").val()),800,800);
            break;
    
        case "Job Role":
            ShowPopUp('ViewParameters.aspx?para=' + parameter + "&para2=" + EncryptID($("#DdlJobs").val()),800,800);
            break;
            
        case "State":
            ShowPopUp('ViewParameters.aspx?para=' + parameter + "&para2=" + EncryptID($("#DdlCountries").val()),800,800);
            break;
            
        case "City":
            ShowPopUp('ViewParameters.aspx?para=' + parameter + "&para2=" + EncryptID($("#DdlStates").val()),800,800);
            break;
            
        default:
            ShowPopUp('ViewParameters.aspx?para=' + parameter,800,800);
    }
    
}