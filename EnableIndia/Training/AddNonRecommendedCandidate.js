
/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../Scripts/jquery.cookie.js" />
/// <reference path="../Scripts/Common.js" />
/// <reference path="../Scripts/jquery.cookie.pack.js" />
/// <reference path="../Scripts/jquery.pager.js" />


$(document).ready(function() {
    $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=non_recommeneded_cand_train_proj", 950, 350);
    });
    
    $("#DivNonRecommendedCandidates").pager({ pagenumber: parseInt($.cookie("grid_page_number")), pagecount: parseInt($.cookie("grid_page_count")), buttonClickCallback: PageClick });
    
    InsertRecordNumberWithPaging("TblAddNonRecommendedCandidate",$.cookie("grid_page_number"));

    $("#ctl00_ContentPlaceHolder2_DdlRecommendedJobType").change();
    $("#ctl00_ContentPlaceHolder2_DdlState").change();
    
    if($('#ctl00_ContentPlaceHolder2_TxtHidddenCity').val()!=''){
        $("#ctl00_ContentPlaceHolder2_DdlCity").val($("#ctl00_ContentPlaceHolder2_TxtHidddenCity").val());
        $("#ctl00_ContentPlaceHolder2_DdlCity").change();
    }

    if($('#ctl00_ContentPlaceHolder2_TxtHiddenRecommendedRole').val()!=''){
        $("#ctl00_ContentPlaceHolder2_DdlRecommendedRole").val($("#ctl00_ContentPlaceHolder2_TxtHiddenRecommendedRole").val());
        $("#ctl00_ContentPlaceHolder2_DdlRecommendedRole").change();
    }
});


function PageClick(pageNumber){
    $.cookie("grid_page_number",pageNumber,{path: '/'});
    $("#ctl00_ContentPlaceHolder2_BtnSearchCandidates").click();
}

function SelectAllCandidates(){
    $("#TblAddNonRecommendedCandidate tbody tr td :checkbox").each(function(){
        $(this).attr("checked",true);
    });
    return false;
}

function validateCheckBox()
{
    if($("#TblAddNonRecommendedCandidate  tr td :checkbox").filter(':checked').size()==0){
        alert('Select one or more candidates.');
        return false;
    }
    else{
        return true;
    }
}


function DdlState_SelectIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown)
{
    if ($("#ctl00_ContentPlaceHolder2_DdlState").val()<0){
        $("#ctl00_ContentPlaceHolder2_DdlCity").css('display', 'none');
        $("#TdCity").css('display', 'none');
         $("#ctl00_ContentPlaceHolder2_DdlCity").val($("#ctl00_ContentPlaceHolder2_DdlState").val());
         $('#ctl00_ContentPlaceHolder2_TxtHidddenCity').val($("#ctl00_ContentPlaceHolder2_DdlCity").val());
         
    }
    else {
        $("#ctl00_ContentPlaceHolder2_DdlCity").css('display', '');
        $("#TdCity").css('display', '');
        FilterCityStates(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);
        var option = $("#ctl00_ContentPlaceHolder2_DdlCity option[value=-2]");
        option.html("All");
        option.attr("value", "-1");
    }

}

function DdlRecommendedJobType_SelectIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown)
{
    if(parseInt($("#ctl00_ContentPlaceHolder2_DdlRecommendedJobType").val())<0){
        $("#ctl00_ContentPlaceHolder2_DdlRecommendedRole").css('display', 'none');
         $("#TdRecomendedRole").css('display', 'none');
           $("#ctl00_ContentPlaceHolder2_DdlRecommendedRole").val($("#ctl00_ContentPlaceHolder2_DdlRecommendedJobType").val());
           $('#ctl00_ContentPlaceHolder2_TxtHiddenRecommendedRole').val($("#ctl00_ContentPlaceHolder2_DdlRecommendedRole").val());
    }
    else{
        $("#TdRecomendedRole").css('display', '');
        $("#ctl00_ContentPlaceHolder2_DdlRecommendedRole").css('display', '');
        FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
        
        var option=$("#ctl00_ContentPlaceHolder2_DdlRecommendedRole option[value=-2]");
        option.html("All");
        option.attr("value","-1");
    }
    
}