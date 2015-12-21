$(document).ready(function() {
    $("#BtnHelp").click(function() {
    ShowPopUp("../ITextPopup.aspx?page=CandidateTask", 550, 150);
});
$("#BtnGenerateReport").click(function () {
    Progress();
});

    SetDefaultOptionExelInReport();
});

function GoSearchParameter()
{
    var message="";
    var datesValid=true;
    
    var registrationDateFrom=$("#TxtFromDate").val();
    if($.trim(registrationDateFrom)!=''){
        var isDateFromValid = ValidateDate(registrationDateFrom,4,false,"");
        if(isDateFromValid==false){
            message+="Enter valid  From Date.\n";
            datesValid=false;
        }
    }
    
    var registrationToDate=$("#TxtToDate").val();
    if($.trim(registrationToDate)!=''){
        var isDateToValid = ValidateDate(registrationToDate,4,false,"");
        if(isDateToValid==false){
            message+="Enter valid  To Date.\n";
            datesValid=false;
        }
    }
    
    if(datesValid==false){
        alert(message);
        return datesValid;
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

