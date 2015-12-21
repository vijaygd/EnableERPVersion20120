/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../../Scripts/Common.js" />
/// <reference path="../../Scripts/jquery.cookie.pack.js" />
/// <reference path="../../Scripts/jquery.pager.js" />

$(document).ready(function(){
    $("#BtnHelp").click(function(){
        ShowPopUp("../../ITextPopup.aspx?page=act_cand", 900, 300);
    });
    $("#ContentPlaceHolder1_DdlJobType").change();
    $("#DivActiveProfiledCandidates").pager({ pagenumber: parseInt($.cookie("grid_page_number")), pagecount: parseInt($.cookie("grid_page_count")), buttonClickCallback: PageClick });
    InsertRecordNumberWithPaging("TblAllActiveCandidates",$.cookie("grid_page_number"));
    
    if($.cookie("candidate_calling")!=null){
        $("#ContentPlaceHolder1_TxtCandidatesInCandidateCallingList").val($.cookie("candidate_calling"));
        $("#ContentPlaceHolder1_BtnViewCandidateCallingList").css("display","");
        $("#ContentPlaceHolder1_BtnPrint").css("display","");
    }
    else{
        $("#TxtCandidatesInCandidateCallingList").val("");
        $("#BtnViewCandidateCallingList").css("display","none");
        $("#ContentPlaceHolder1_BtnPrint").css("display","none");
    }
            
    if($('#ContentPlaceHolder1_SpnHiddenRecommendedRole').html()!=''){
        try
        {
            $("#ContentPlaceHolder1_DdlRecommendedRole").val($("#ContentPlaceHolder1_SpnHiddenRecommendedRole").html());
            $("#ContentPlaceHolder1_TxtHiddenRecommendedRole").val($('#ContentPlaceHolder1_SpnHiddenRecommendedRole').html());
        }
        catch(Error)
        {
            var html="<option value='-1'>All</option>";
            html+="<option value='-2'>Unlisted</option>";
            $('#ContentPlaceHolder1_DdlRecommendedRole').html(html);
            window.setTimeout("$('#ContentPlaceHolder1_DdlRecommendedRole').val($('#ContentPlaceHolder1_SpnHiddenRecommendedRole').text())",10);
            $("#ContentPlaceHolder1_TxtHiddenRecommendedRole").val($('#ContentPlaceHolder1_SpnHiddenRecommendedRole').html()); 
        }    
    }
    
    SelectAllCandidates();
    CheckForCandidatesInCandidateCallingList();
});

function PageClick(pageNumber){
    $.cookie("grid_page_number",pageNumber,{path: '/'});
    $("#ContentPlaceHolder1_BtnSearchCandidates").click();
}

function SelectAllCandidates() {
    var result = $('#ContentPlaceHolder1_ChkSelectAllCandidates:checked').val() ? true : false;
        if (result) {
            $("#ContentPlaceHolder1_TblAllActiveCandidates tbody tr td :checkbox").each(function () {
                $(this).attr("checked", $("#ContentPlaceHolder1_ChkSelectAllCandidates").attr("checked"));
            });
        }
        else {
            $("#ContentPlaceHolder1_TblAllActiveCandidates tbody tr td :checkbox").each(function () {
                $(this).prop("checked", false);
            });

        }
}
function CheckForParameterChange(){
    var message="";
    var datesValid=true;
    //validate date of birth
    var dateOfBirth=$("#ContentPlaceHolder1_TxtDateOfBirth").val();
    if($.trim(dateOfBirth)!=''){
        var isDateValid = ValidateDate(dateOfBirth,4,false,"");
        if(isDateValid==false){
            message+="Enter valid Date Of Birth .\n";
            datesValid=false;
        }
    }
     if(datesValid==false){
        alert(message);
        return datesValid;
    }
        
    //Clears the previously checked candidates.
    var TxtIsParameterChanged=$("#ContentPlaceHolder1_TxtIsParameterChanged");
    var previousParameters=TxtIsParameterChanged.val();
    var newParameters="";
    $("table[group='SearchParameters']").each(function(){
        if($(this).find("select").size() > 0){
            newParameters+=$(this).find("select").val() + "#ContentPlaceHolder1_";
        }
        
        if($(this).find("input").size() > 0){
            newParameters+=$(this).find("input").val() + "#ContentPlaceHolder1_";
        }
    });
    
    if($.trim(previousParameters)==''){
        TxtIsParameterChanged.val(newParameters);
    }
    else{
        //Compares the value of old search parameters and new search parameters.
        if(TxtIsParameterChanged.val()!=newParameters && $.cookie("candidate_calling")!='' && $.cookie("candidate_calling")!=null){
            var wantToClearExistingCandidateCallingList = confirm("Candidate calling list already exists. Do you want to clear the existing list?");
            if(wantToClearExistingCandidateCallingList==true){
                $.cookie('candidate_calling',"",{expires:1,path:"/"});
                $("#ContentPlaceHolder1_TxtCandidatesInCandidateCallingList").val("");
                TxtIsParameterChanged.val("");
            }
        }
    }
    $("#ContentPlaceHolder1_TblAllActiveCandidates tbody tr td :checkbox").attr("checked",false);
}

function AddToCandidteCallingList(){
    var newCandidateList="";
    var existingCandidateCallingList=$("#ContentPlaceHolder1_TxtCandidatesInCandidateCallingList").val();
    
    $("#ContentPlaceHolder1_BtnViewCandidateCallingList").css("display","none");
     $("#ContentPlaceHolder1_BtnPrint").css("display","none");
      
    $("#ContentPlaceHolder1_TblAllActiveCandidates tbody tr :checkbox").filter(":checked").each(function(){
        //Checks whether candidate exists in the list or not.If the candidate does not exist in the list, then only add it in the list.
        if(existingCandidateCallingList.indexOf($(this).parent().attr("CandidateID"))==-1){
            newCandidateList+=$(this).parent().attr("CandidateID") + "_";
        }
    });
    
    if($("#ContentPlaceHolder1_TblAllActiveCandidates tbody tr :checkbox").filter(":checked").size()==0){
        alert("Select atleast one candidate.");
    }
    else{
        newCandidateList=newCandidateList.substring(0,newCandidateList.length-1);
        if($.trim(existingCandidateCallingList).length>0 && newCandidateList!=''){
            existingCandidateCallingList=existingCandidateCallingList + "_";
        }
        
        $("#ContentPlaceHolder1_TxtCandidatesInCandidateCallingList").val(existingCandidateCallingList + newCandidateList);
        $.cookie('candidate_calling',$("#ContentPlaceHolder1_TxtCandidatesInCandidateCallingList").val(),{expires:1,path:"/"});
        $("#ContentPlaceHolder1_BtnViewCandidateCallingList").css("display","");
        $("#ContentPlaceHolder1_BtnPrint").css("display","");
        alert("Candidates added to candidate calling list successfully.");
    }
    return false;
}

function CheckForCandidatesInCandidateCallingList() {
    if(typeof($("#ContentPlaceHolder1_TxtCandidatesInCandidateCallingList")) != 'undefined')
    {
        if ($("#ContentPlaceHolder1_TxtCandidatesInCandidateCallingList").val() != '') {
            var selectedCandidateIDs = $("#ContentPlaceHolder1_TxtCandidatesInCandidateCallingList").val().split('_');
            for (var counter = 0; counter < selectedCandidateIDs.length; counter++) {
                $("#ContentPlaceHolder1_TblAllActiveCandidates tbody tr span[CandidateID=" + selectedCandidateIDs[counter] + "]").find(":checkbox").attr("checked", true);
            }
         }
    }
}

function DdlJobType_SelectIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown){
    if(parseInt($("#ContentPlaceHolder1_DdlJobType").val())<0){
        $("#ContentPlaceHolder1_DdlRecommendedRole").css('display', '');
        $("#ContentPlaceHolder1_TdRecomendedRole").css('display', '');
        var option=$("#ContentPlaceHolder1_DdlRecommendedRole option");
        var html="<option value='-1'>All</option>";
        html+="<option value='-2'>Unlisted</option>";
        $('#ContentPlaceHolder1_DdlRecommendedRole').html(html);
        $('#ContentPlaceHolder1_TxtHiddenRecommendedRole').val($("#ContentPlaceHolder1_DdlRecommendedRole").val());
    }
    else {
        $("#ContentPlaceHolder1_TdRecomendedRole").css('display', '');
        //        $("select[id$=DdlRecommendedRole] > option").empty();
        $("select[id$=DdlRecommendedRole] > option").remove();
        $("#ContentPlaceHolder1_DdlRecommendedRole").css('display', '');
        FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
        var option=$("#ContentPlaceHolder1_DdlRecommendedRole option[value=-2]");
        option.html("All");
        option.attr("value","-1");
        $('#ContentPlaceHolder1_TxtHiddenRecommendedRole').val($("#ContentPlaceHolder1_DdlRecommendedRole").val());
    }
}
function removeOptions(selectbox) {
    var i;
    for (i = selectbox.options.length - 1; i >= 0; i--) {
        selectbox.remove(i);
    }
}