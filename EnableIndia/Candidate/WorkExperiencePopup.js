/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../Scripts/Common.js" />

$(document).ready(function() {
    if (document.URL.indexOf("emp_proj") == -1) {
        FilterCityStatesInPopup($("#DdlParentCompanies").val(), 'ParentCompanyID', 'DdlCompanies', 'DdlHiddenCompany');
        $("#DdlCompanies").val($("#SpnHiddenCompanyID").html());
        $("#DdlCompanies").change();
        DdlSelectCompany_SelectedIndexChanged();
        DdlRoles_SelectedIndexChanged();

    }
    else {
        DdlRoles_SelectedIndexChanged();
    }
    ToggleContractExpiryDate();
    parent.scrollTo(0, 0);
});

function ToggleContractExpiryDate() {
    if ($("#RdbDesignationTillCurrentDate").prop('checked')==true)
       {
          $("#TxtDesignationTo").val('');
          $("#TxtDesignationTo").attr('disabled', true);
          $("#TxtDesignationTo").removeAttr('class');
          $("#TblContractExpiryDate").show();
      }
    else {
        $("#TxtDesignationTo").attr('disabled', false);
        $("#TxtDesignationTo").attr('class', 'mandatory');
        $("#TblContractExpiryDate").hide();
    }
}


function TxtDesignationTo_TextChanged(){
    //if($("#TxtDesignationTo").val()==''){
    //    $("#RdbDesignationTillCurrentDate").attr("checked","");
    //    $("#RdbDesignationTo").attr("checked","");
    //}
    //else{
    //    $("#RdbDesignationTo").attr("checked","true");
    //}
}

function DdlSelectCompany_SelectedIndexChanged(){
    $('#TdParentCompany').css('display', 'none');
    $('#TdCompany').css('display', 'none');
    $('#TxtUnlistedCompany').css('display', 'none');
    $("#DdlParentCompanies").attr("class","");
    $("#DdlCompanies").attr("class","");
    $("#TxtUnlistedCompany").attr("class","");
    
    switch($("#DdlSelectCompany").val()){
        case "1":
            $('#TdParentCompany').css('display', '');
            $('#TdCompany').css('display', '');
            
            //Makes parent company and company mandatory
            $("#DdlParentCompanies").attr("class","mandatory");
            $("#DdlCompanies").attr("class","mandatory");
            break;
            
        case "2":
            $('#TxtUnlistedCompany').css('display', '');  
            $("#TxtUnlistedCompany").attr("class","mandatory");
            break;
    }
}

function DdlRoles_SelectedIndexChanged(){
    $('#DdlJobRoles').css('display', 'none');
    $('#TxtUnlistedRole').css('display', 'none');
    $('#DdlJobRoles').attr("class","");
    $('#TxtUnlistedRole').attr("class","");

    switch($("#DdlRoles").val()){
        case "1":
            $('#DdlJobRoles').css('display', '');
            $('#DdlJobRoles').attr("class","mandatory");
            break;
            
        case "2":
            $('#TxtUnlistedRole').css('display', '');
            $('#TxtUnlistedRole').attr("class","mandatory");
            break;
    }
}
function disableRdbCurrentDate()
{
    //$('#RdbDesignationTillCurrentDate').prop('checked', false);
    return false;
}
function ValidateDurations(strDuration){
    strDuration =$.trim(strDuration);
    var noErrors=true;
        var split=strDuration.split('/');
        if(parseInt(split.length)!=2){
            noErrors = false;
        }
        else{
            //Validates month
            if(isNaN(split[0]) || parseInt(split[0]<=0) || parseInt(split[0])>12){
                noErrors = false;
            }
            //Validates year
            if(isNaN(split[1]) || parseInt(split[1].length)!=4 || parseInt(split[1])<=1900){
                noErrors = false;
            }
        }
        
        return noErrors;
}

function ValidateWorkExperience()
{
    var message="";
    var noErrors=true;
    
    var isValid=ValidateForm();
    
    if(isValid==true){
        var salary=$("#TxtMonthlySalary").val();
        if($.trim(salary)!=''){
            var isSalaryValid=ValidateSalary("TxtMonthlySalary");
            if(isSalaryValid==false){
                message+="Enter valid salary.\n";
                noErrors=false;   
            }
        }
        
        //Validates designation start date
        if(ValidateDurations($("#TxtDesignationFrom").val())==false){
            message+="Enter valid designation start date.\n" ;
            noErrors=false;
        }
        
        //Validates designation end date
        if($("#RdbDesignationTillCurrentDate").attr("checked")==false){
            if(ValidateDurations($("#TxtDesignationTo").val())==false){
                message+="Enter valid designation end date.\n" ;
                noErrors=false;
            }
        }
        
        var contractExpiryDate=$("#TxtExpiryDate").val();
        if($.trim(contractExpiryDate)!=''){
            var isDateValid=ValidateDate(contractExpiryDate,4,false,"");
            if(isDateValid==false){
                message+="Enter valid contract expiry date. " ;
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

 
    function getRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }

    function refreshParentPage() {
        getRadWindow().BrowserWindow.location.reload();
    }

    function Close() {
          GetRadWindow().Close();
    }
