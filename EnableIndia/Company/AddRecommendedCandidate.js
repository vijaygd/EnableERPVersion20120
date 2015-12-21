/// <reference path="../Scripts/jquery-2.1.4.min.js" />
///<reference path='../Scripts/common.js' />

$(document).ready(function(){
     $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=recommended_cand_emp_proj", 950, 350);
    });
    
    $("#DivRecommendedCandidates").pager({ pagenumber: parseInt($.cookie("grid_page_number")), pagecount: parseInt($.cookie("grid_page_count")), buttonClickCallback: PageClick });
    InsertRecordNumberWithPaging("TblRecommendedCandidates",$.cookie("grid_page_number"));
});

function PageClick(pageNumber){
    $.cookie("grid_page_number",pageNumber,{path: '/'});
    $("#BtnSearchCandidates").click();
}

function ValidateAssignment(){
    if($('#TblRecommendedCandidates :checkbox:checked').size()==0){
        alert("Please select atleast one candidate.");
        return false;
    }
}