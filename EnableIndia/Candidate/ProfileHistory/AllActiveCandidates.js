/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../../Scripts/Common.js" />


$(document).ready(function(){
    $("#BtnHelp").click(function(){
        ShowPopUp("../ITextPopup.aspx?page=act_cand", 900, 300);
    });
    
    $("#DdlJobType").change();
    $("#DivActiveProfiledCandidates").pager({ pagenumber: parseInt($.cookie("grid_page_number")), pagecount: parseInt($.cookie("grid_page_count")), buttonClickCallback: PageClick });
    InsertRecordNumberWithPaging("TblAllActiveCandidates",$.cookie("grid_page_number"));
    
    if($.cookie("candidate_calling")!=null){
        $("#TxtCandidatesInCandidateCallingList").val($.cookie("candidate_calling"));
        $("#BtnViewCandidateCallingList").css("display","");
        $("#BtnPrint").css("display","");
    }
    else{
        $("#TxtCandidatesInCandidateCallingList").val("");
        $("#BtnViewCandidateCallingList").css("display","none");
        $("#BtnPrint").css("display","none");
    }
            
    if($('#SpnHiddenRecommendedRole').html()!=''){
        try
        {
            $("#DdlRecommendedRole").val($("#SpnHiddenRecommendedRole").html());
            $("#TxtHiddenRecommendedRole").val($('#SpnHiddenRecommendedRole').html());
        }
        catch(Error)
        {
            var html="<option value='-1'>All</option>";
            html+="<option value='-2'>Unlisted</option>";
            $('#DdlRecommendedRole').html(html);
            window.setTimeout("$('#DdlRecommendedRole').val($('#SpnHiddenRecommendedRole').text())",10);
            $("#TxtHiddenRecommendedRole").val($('#SpnHiddenRecommendedRole').html()); 
        }    
    }
    
    SelectAllCandidates();
    CheckForCandidatesInCandidateCallingList();
});

function PageClick(pageNumber){
    $.cookie("grid_page_number",pageNumber,{path: '/'});
    $("#BtnSearchCandidates").click();
}

function SelectAllCandidates() {
    var result = $('#ChkSelectAllCandidates:checked').val() ? true : false;
        if (result) {
            $("#TblAllActiveCandidates tbody tr td :checkbox").each(function () {
                $(this).attr("checked", $("#ChkSelectAllCandidates").attr("checked"));
            });
        }
        else {
            $("#TblAllActiveCandidates tbody tr td :checkbox").each(function () {
                $(this).prop("checked", false);
            });

        }
}


function CheckForParameterChange(){
    var message="";
    var datesValid=true;
    //validate date of birth
    var dateOfBirth=$("#TxtDateOfBirth").val();
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
    var TxtIsParameterChanged=$("#TxtIsParameterChanged");
    var previousParameters=TxtIsParameterChanged.val();
    var newParameters="";
    $("table[group='SearchParameters']").each(function(){
        if($(this).find("select").size() > 0){
            newParameters+=$(this).find("select").val() + "#";
        }
        
        if($(this).find("input").size() > 0){
            newParameters+=$(this).find("input").val() + "#";
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
                $("#TxtCandidatesInCandidateCallingList").val("");
                TxtIsParameterChanged.val("");
            }
        }
    }
    $("#TblAllActiveCandidates tbody tr td :checkbox").attr("checked",false);
}

function AddToCandidteCallingList(){
    var newCandidateList="";
    var existingCandidateCallingList=$("#TxtCandidatesInCandidateCallingList").val();
    
    $("#BtnViewCandidateCallingList").css("display","none");
     $("#BtnPrint").css("display","none");
      
    $("#TblAllActiveCandidates tbody tr :checkbox").filter(":checked").each(function(){
        //Checks whether candidate exists in the list or not.If the candidate does not exist in the list, then only add it in the list.
        if(existingCandidateCallingList.indexOf($(this).parent().attr("CandidateID"))==-1){
            newCandidateList+=$(this).parent().attr("CandidateID") + "_";
        }
    });
    
    if($("#TblAllActiveCandidates tbody tr :checkbox").filter(":checked").size()==0){
        alert("Select atleast one candidate.");
    }
    else{
        newCandidateList=newCandidateList.substring(0,newCandidateList.length-1);
        if($.trim(existingCandidateCallingList).length>0 && newCandidateList!=''){
            existingCandidateCallingList=existingCandidateCallingList + "_";
        }
        
        $("#TxtCandidatesInCandidateCallingList").val(existingCandidateCallingList + newCandidateList);
        $.cookie('candidate_calling',$("#TxtCandidatesInCandidateCallingList").val(),{expires:1,path:"/"});
        $("#BtnViewCandidateCallingList").css("display","");
        $("#BtnPrint").css("display","");
        alert("Candidates added to candidate calling list successfully.");
    }
    return false;
}

function CheckForCandidatesInCandidateCallingList() {
    if(typeof($("#TxtCandidatesInCandidateCallingList")) != 'undefined')
    {
        if ($("#TxtCandidatesInCandidateCallingList").val() != '') {
            var selectedCandidateIDs = $("#TxtCandidatesInCandidateCallingList").val().split('_');
            for (var counter = 0; counter < selectedCandidateIDs.length; counter++) {
                $("#TblAllActiveCandidates tbody tr span[CandidateID=" + selectedCandidateIDs[counter] + "]").find(":checkbox").attr("checked", true);
            }
         }
    }
}

function DdlJobType_SelectIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown){
    if(parseInt($("#DdlJobType").val())<0){
        $("#DdlRecommendedRole").css('display', '');
        $("#TdRecomendedRole").css('display', '');
        var option=$("#DdlRecommendedRole option");
        var html="<option value='-1'>All</option>";
        html+="<option value='-2'>Unlisted</option>";
        $('#DdlRecommendedRole').html(html);
        $('#TxtHiddenRecommendedRole').val($("#DdlRecommendedRole").val());
    }
    else {
        $("#TdRecomendedRole").css('display', '');
        //        $("select[id$=DdlRecommendedRole] > option").empty();
        $("select[id$=DdlRecommendedRole] > option").remove();
        $("#DdlRecommendedRole").css('display', '');
        FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
        var option=$("#DdlRecommendedRole option[value=-2]");
        option.html("All");
        option.attr("value","-1");
        $('#TxtHiddenRecommendedRole').val($("#DdlRecommendedRole").val());
    }
}
function removeOptions(selectbox) {
    var i;
    for (i = selectbox.options.length - 1; i >= 0; i--) {
        selectbox.remove(i);
    }
}