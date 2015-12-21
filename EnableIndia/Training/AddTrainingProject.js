/// <reference path="../Scripts/jquery-1.7.1.min.js" />
///<reference path='../Scripts/Common.js' />

$(document).ready(function() {

$("#BtnHelp").click(function() {
ShowPopUp("../ITextPopup.aspx?page=add_train_project", 500, 160);
});

});


function ValidateRegistartionDate()
{   
    var message="";
    var noErrors=true;
    
    var isvalid=ValidateForm();
    if(isvalid==true){
        var currentDate=new Date();
                
        var startDate =$("#TxtStartDate").val();
        var split=startDate.split("/");
        
        var registrationDate = new Date(Date.UTC(split[2], split[1]-1, split[0]));
        
        if (registrationDate < currentDate) {
            var rDate = new Date(registrationDate);
            var timeDiff = Math.abs(currentDate.getTime() - rDate.getTime());
            var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24)); 
            if (diffDays > 365) {
                message += "Start date cannot be more than one year behind from today's date.\n"
                noErrors = false;
            }
        }
        
        var endDate=$("#TxtEndDate").val();
        var split=startDate.split("/");
        
        registrationDate = new Date(Date.UTC(split[2], split[1]-1, split[0]));
        
        //if(registrationDate<currentDate){
        //    message+="End date cannot be less than today's date.\n"
        //    noErrors=false;
        //}
        var SelValue=$("#DdlTimeFrom option:selected").val();
        if(SelValue == "-2"){
            message+="Either AM or PM should be selected for From Time";
            noErrors=false;
        }
        SelValue=$("#DdlTimeTo option:selected").val();
        if (SelValue == "-2")
        {
            message += "Either AM or PM should be selected for To Time";
            noErrors=false;
        }
        SelValue=$("#DdlProjectType option:selected").val();
        if(SelValue == "-2")
        {
            message += "Location must be selected";
            noErrors = false;
        }
        SelValue=$("#DdlEmployees option:selected").val();
        if (SelValue == "-2") {
            message += "Program Managed by is must";
            noErrors = false;
        }
        if(noErrors==false){
            alert(message);
        }
        return noErrors;
    }
    else{
        return false;
    }
}