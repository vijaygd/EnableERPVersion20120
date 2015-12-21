
$(document).ready(function() {
    $("#BtnHelp").click(function() {
    ShowPopUp("../ITextPopup.aspx?page=ListOfCompanies", 350, 150);
});
    $("#BtnGenerateReport").click(function () {
        Progress();
    });

     SetDefaultOptionExelInReport();
    $("#DdlState").change();
      $("#DdlParentCompany").change();
    
    if($('#TxtHidddenCity').val()!=''){
        $("#DdlCity").val($("#TxtHidddenCity").val());
        $("#DdlCity").change();
    }
    else{
        $('#TxtHidddenCity').val(-1);
    }
     if($('#TxtHiddenCompanyID').val()!=''){
        $("#DdlCompany").val($("#TxtHiddenCompanyID").val());
        $("#DdlCompany").change();
    }
});
function DdlState_SelectIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown)
{
    if (parseInt($("#DdlState").val())<0){
        $("#DdlCity").css('display', 'none');
        $("#TdCity").css('display', 'none');
        $("#DdlCity").val($("#DdlState").val());
        $('#TxtHidddenCity').val($("#DdlCity").val());
        // $("#DdlCity").change();
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

function DdlParentCompany_selectedIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown)
{
    if (parseInt($("#DdlParentCompany").val())<0){
    
          var option=$("#DdlCompany option");
        var html="<option value='-1'>All</option>";
        $('#DdlCompany').html(html);
        //$("#DdlCity").val($("#DdlState").val());
        $('#TxtHiddenCompanyID').val($("#DdlCompany").val());
          //$("#DdlCompany").change();
         
    }
    else {
        FilterCityStates(countryID, customAttribute, DdlVisibleDropdown, DdlHiddenDropdown);
        var option = $("#DdlCompany option[value=-2]");
        option.html("All");
        option.attr("value", "-1");
        //$('#TxtHiddenCompanyID').val($("#DdlCompany").val());

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
