/// <reference path="../Scripts/jquery-2.1.4.min.js" />
///<reference path='../Scripts/common.js' />


$(document).ready(function() {
    
});

function  ValidateAllDetail()
{
    var interviewDate= $("#TxtInterviewDate").val();
    var interviewTime= $("#TxtInterviewTime").val();
    var interpreterName=$("#TxtLanguageInterpreterName").val();
    var interpreterDetail= $("#TxtInterpreterContactDetails").val();
    var postDateInterview= $("#TxtDateForPostInterView").val();
    var postTimeInterview= $("#TxtTimeForPostInterView").val();
    var comments= $("#TxtComments").val();
    if(interviewDate=='' && interviewTime=='' &&interpreterName=='' &&interpreterDetail=='' 
        && postDateInterview=='' && postTimeInterview=='' && comments==''){
        alert("Please enter some detail.");
        return false;
    }
    else{
        return true;
    }
}

function ValidateDateTime()
{
    var message="";
    var datesValid=true;
    
    var isvalid=ValidateAllDetail();
    if(isvalid==true){
         
        var interviewDate=$("#TxtInterviewDate").val();
        if($.trim(interviewDate)!=''){
            var isDateFromValid = ValidateDate(interviewDate,4,false,"");
            if(isDateFromValid==false){
                message+="Enter valid  interview date.\n";
                datesValid=false;
            }
        }
        
        var interviewTime= $("#TxtInterviewTime").val();
        if($.trim(interviewTime)!=''){
            var isTimeFromValid = ValidateTime(interviewTime,false,"");
            if(isTimeFromValid==false){
                message+="Enter valid  interview Time.\n";
                datesValid=false;
            }
            if($("#DdlInteviewTime").val()==-2){
                message+="Select interview time clock .\n";
                datesValid=false;
            }
        }
        
         var postDateInterview=$("#TxtDateForPostInterView").val();
        if($.trim(postDateInterview)!=''){
            var isDateFromValid = ValidateDate(postDateInterview,4,false,"");
            if(isDateFromValid==false){
                message+="Enter valid post interview date.\n";
                datesValid=false;
            }
        }
        
        var postTimeInterview= $("#TxtTimeForPostInterView").val();
        if($.trim(postTimeInterview)!=''){
            var isTimeFromValid = ValidateTime(postTimeInterview,false,"");
            if(isTimeFromValid==false){
                message+="Enter valid  interview Time.\n";
                datesValid=false;
            }
            if($("#DdlPostInterviewTime").val()==-2){
                message+="Select post interview time clock .\n";
                datesValid=false;
            }
        }
        
        if(datesValid==false){
            alert(message);
            return datesValid;
        }
    
    }
    else{
        return false;
    }
}