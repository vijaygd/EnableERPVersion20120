
/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../Scripts/Common.js" />



$(document).ready(function(){
    
});

function ValidateYear()
{
    var message="";
    var noErrors=true;
    var isValid=ValidateForm();
    if(isValid==true){
        var year=$("#TxtPassingYear").val();
        if($.trim(year)!=''){
            var currentDate=new Date();
            if(isNaN(year) ||parseInt(year.length)!=4 || parseInt(year)<1900|| parseInt(year)>currentDate.getFullYear()){
                message+="Enter year yyyy format. It should be greater than 1900.\n";
                noErrors=false;
                }
            }
        var percentage=$("#TxtPercentage").val();
        if($.trim(percentage)!=''){
            if(isNaN(percentage)||parseInt(percentage)>100){
                message+="Enter valid percentage.";
                noErrors=false;
            }
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

