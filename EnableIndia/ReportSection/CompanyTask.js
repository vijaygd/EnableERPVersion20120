$(document).ready(function() {
     $("#BtnHelp").click(function() {
     ShowPopUp("../ITextPopup.aspx?page=CompanyTask", 400, 150);
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