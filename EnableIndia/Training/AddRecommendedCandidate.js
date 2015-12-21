/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../Scripts/jquery.pager.js" />
/// <reference path='../Scripts/Common.js' />

$(document).ready(function(){
     $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=recommended_cand_train_proj", 800, 350);
    });
    
    $("#DivRecommendedCandidates").pager({ pagenumber: parseInt($.cookie("grid_page_number")), pagecount: parseInt($.cookie("grid_page_count")), buttonClickCallback: PageClick });
    InsertRecordNumberWithPaging("TblViewTrainingProgram",$.cookie("grid_page_number"));
});

function PageClick(pageNumber){
    $.cookie("grid_page_number",pageNumber,{path: '/'});
    $("#BtnSearchCandidates").click();
}

function SelectAllCandidates(){
    $("#TblViewTrainingProgram tbody tr td :checkbox").each(function(){
        $(this).attr("checked",true);
    });
    return false;
}

function validateCheckBox()
{
    if($("#TblViewTrainingProgram  tr td :checkbox").filter(':checked').size()==0){
        alert('Select one or more candidates.');
        return false;
    }
    else{
        return true;
    }
}