/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path='../Scripts/jquery.cookie.js' />
/// <reference path='../Scripts/jquery.cookie.pack.js' />
/// <reference path='../Scripts/common.js' />
/// <reference path="../Scripts/jquery.pager.js" />

$(document).ready(function(){
     $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=non_recommeneded_cand_emp_proj", 950, 350);
    });
    
    $("#DivCompanyNonRecommendedCandidates").pager({ pagenumber: parseInt($.cookie("grid_page_number")), pagecount: parseInt($.cookie("grid_page_count")), buttonClickCallback: PageClick });
    
    InsertRecordNumberWithPaging("TblNonRecommendedCandidates",$.cookie("grid_page_number"));
    
    $("#DdlRecommendedJobType").change();
    $("#DdlState").change();
    
    if($('#TxtHidddenCity').val()!=''){
        $("#DdlCity").val($("#TxtHidddenCity").val());
        $("#DdlCity").change();
    }
     if($('#TxtHiddenRecommendedRole').val()!=''){
        $("#DdlRecommendedRole").val($("#TxtHiddenRecommendedRole").val());
        $("#DdlRecommendedRole").change();
    }
});

function PageClick(pageNumber){
    $.cookie("grid_page_number",pageNumber,{path: '/'});
    $("#BtnSearchCandidates").click();
}

function ValidateAssignment(){
    if($('#TblNonRecommendedCandidates :checkbox:checked').size()==0){
        alert("Please select atleast one candidate.");
        return false;
    }
}
function DdlState_SelectIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown)
{
    if (parseInt($("#DdlState").val())<0){
        $("#DdlCity").css('display', 'none');
        $("#TdCity").css('display', 'none');
        $("#DdlCity").val($("#DdlState").val());
        $('#TxtHidddenCity').val($("#DdlCity").val());
         
    }
    else {
        $("#DdlCity").css('display', '');
        $("#TdCity").css('display', '');
        FilterCityStates(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);
        var option = $("#DdlCity option[value=-2]");
        option.html("All");
        option.attr("value", "-1");
    }
}

function DdlRecommendedJobType_SelectIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown)
{
    if(parseInt($("#DdlRecommendedJobType").val())<0){
        $("#DdlRecommendedRole").css('display', 'none');
         $("#TdRecomendedRole").css('display', 'none');
           $("#DdlRecommendedRole").val($("#DdlRecommendedJobType").val());
           $('#TxtHiddenRecommendedRole').val($("#DdlRecommendedRole").val());
    }
    else{
        $("#TdRecomendedRole").css('display', '');
        $("#DdlRecommendedRole").css('display', '');
        FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
        
        var option=$("#DdlRecommendedRole option[value=-2]");
        option.html("All");
        option.attr("value","-1");
    }
}