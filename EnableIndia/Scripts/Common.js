/// <reference path="jquery-2.1.4.min.js" />

var date_format_string = "MM/dd/yy";
 
//Function for Left trim
function LeftTrim(sString)
{
    while (sString.substring(0,1) == ' ')
    {
        sString = sString.substring(1, sString.length);
    }
    return sString;
}

//Function for Right trim
function RightTrim(sString)
{
    while (sString.substring(sString.length-1, sString.length) == ' ')
    {
        sString = sString.substring(0,sString.length-1);
    }
    return sString;
}

//Function for encrypting ID
function EncryptID(PlainID)
{
    return parseFloat(PlainID * 157367.87).toFixed(2);
}

//Function for decrypting ID
function DecryptID(EncryptedID)
{
    return parseInt(EncryptedID / 157367.87);
}

//Function for confirming delete action
function ConfirmDelete()
{
    return confirm("Are you sure?");
}

function addDay(TxtID,num)
{
    var dateString = $('#' + TxtID).val();
    if(dateString=='__/__/__')
        dateString=formatDate(new Date());

    dt = getDateString(dateString);
        
    iDay=num*(1000*60*60*24);
    dt=new Date(dt.getTime()+iDay);
    try{$('#' + TxtID).val(formatDate(dt));}
    catch(e){}
  
    return false;
}

function getDateString(DateString)
{    
    curr_date = new Date();
    var arrDateFormatString = date_format_string.split('/');
    var arrDateString = DateString.split('/');
    curr_day=1;
    curr_month=1;
    curr_year=2008;
    
    if(arrDateString.length==3)
    {
        for(i=0;i<3;i++)
        {
            switch (arrDateFormatString[i])
            {
                case "dd" :
                    curr_day=arrDateString[i];
                    break;
                case "MM" :
                    curr_month = parseInt(arrDateString[i]-1);
                    break;
                case "yy" :
                    curr_year=parseInt(20+arrDateString[i]);                
                    break;
            }
            
        }    
        curr_date.setFullYear(curr_year,curr_month,curr_day);
    }
    return curr_date;
}

function formatDate(date) 
{
    var arrDateFormatString = date_format_string.split('/');
    resultDate="";
    for(i=0;i<3;i++)
    {
        switch (arrDateFormatString[i])
        {
            case "dd" :
                day=date.getDate()+"";
                resultDate = resultDate+(day.length==1?"0"+day:day)+(i==2?"":"/")
                break;
            case "MM" :
                month=date.getMonth()+1+"";
                resultDate = resultDate+(month.length==1?"0"+month:month)+(i==2?"":"/")
                break;
            case "yy" :
                fullYear = date.getFullYear()+"";
                resultDate = resultDate+fullYear.substring(2,4)+(i==2?"":"/")
                break;
        }
        
    }    
    return resultDate;
}
//==========================================================================================================================================================
function ShowSelection(strSpanId){
    $(".selectedicontext").removeClass("selectedicontext");
    $(strSpanId).addClass("selectedicontext"); 
}

function AttachHover() {
    $(":image[ishover:yes]").hover(function() {
            $(this).attr("src",$(this).attr("src").replace("_out","_over"));
        },
        function() {
            $(this).attr("src", $(this).attr("src").replace("_over", "_out"));
        });

    $("img[ishover:yes]").hover(function() {
        $(this).attr("src", $(this).attr("src").replace("_out", "_over"));
    },
    function() {
        $(this).attr("src", $(this).attr("src").replace("_over", "_out"));
    });
}

function ShowCallenders() {
    $(".calendar").datepicker({showOn: 'button', buttonText: 'Select Date', buttonImage: '../App_Themes/Blue/Images/Callender.GIF', buttonImageOnly: true , dateFormat: 'mm/dd/y' , defaultDate:new Date()});
}

function SetTableStyle(htmlTableId) {
    $("#" + htmlTableId + " tbody tr").filter(":odd").addClass("grid-alternate-row").end().filter(":even").addClass("grid-row");
    return $("#" + htmlTableId);
}

function SetTableStyle() {
    $(":submit").addClass("button");
    $(":reset").addClass("button");
    $(":button").addClass("button");
    
    $(":text").attr("maxlength",250);
    $("textarea").attr("maxlength",2000);
    
    $(".tableBorder > tbody > tr").filter(":odd").addClass("grid-alternate-row").end().filter(":even").addClass("grid-row");
    
    //Sets the color of selected link and its bullet icon
    $("#LeftMenu table[class!=''] tr td a").each(function(){
        var href=$(this).attr("href").replace(/^.*\.\//g,"");
        if(document.URL.indexOf(href)>0 && document.URL.indexOf("RegisterNGO.aspx?ngo=")==-1 && document.URL.indexOf("RegisterEmployee.aspx?emp=")==-1){
            $(this).css("color","#D80000");
            $(this).parents("table[class^='level']").addClass("selected_level2");
            return;
        }
    });
    
    AllowString();
    AllowDate();
}

function AllowString(){
    $("#TblContentBody input[type=text][datatype=string]").keypress(function (e){
      if((e.which>=65 && e.which<=90) || (e.which>=97 && e.which<=122) || e.which==13 ||e.which==32){
        return true;
      }
      else{
        alert("Only letters are allowed.");
        return false;
      }
    });
}

function AllowDate(){
//     $("#TblContentBody input[type=text][yearlength]").blur(function(e){
//        $("#TblContentBody input[type=text][yearlength]").replace(/[^\d\/]/g,'');
//     });
    
    $("#TblContentBody input[type=text][yearlength]").attr("maxlength",10);
    $("#TblContentBody input[type=text][yearlength]").keypress(function (e){
        //alert(e.which);
      if((e.which>=47 && e.which<=57) || e.which==8 || e.which==0){
        return true;
      }
      else{
        alert("Only digits and / are allowed.");
        return false;
      }
    });
}

function ShowHoverEffect() {
    $(".tableBorder tbody tr").each(function() {
        $(this).hover(function() {
            $(this).addClass("grid-hover-row");
        },
            function() {
                $(this).removeClass("grid-hover-row");
            }

            );

        $(this).click(function() {
            $(".tableBorder tbody tr").each(function() {
                $(this).removeClass("grid-selected-row");
            });

            $(this).addClass("grid-selected-row");

        }
            );

    });
}

function ClearAll(){
    $("#TblContentBody input[type=text]").val("");
    $("#TblContentBody textarea").val("");
    $("#TblContentBody select").attr("selectedIndex","0");
}

function ShowPopUp(pageUrl,width,heigth){
    if (window.showModalDialog){
        window.showModalDialog(pageUrl, "name", "dialogWidth:" + width + "px;dialogHeight:" + heigth + "px");
    }
    else{
        window.open(pageUrl, 'name', 'height=' + heigth + ',width=' + width + ',toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no ,modal=yes');
    }
}

function ClosePopup(strOuterWindowReturncontrolID){
    if(document.URL.indexOf("msg")!=-1){
        window.opener.document.getElementById(strOuterWindowReturncontrolID).value="";
    }
    else{
        window.opener.document.getElementById(strOuterWindowReturncontrolID).value="false";
    }
    self.close();
}

function CheckForPopupReturnValue(returnControlID){
    if($("#" + returnControlID).val()=='false'){
        $("#" + returnControlID).val("");
        return false;
    }
}

//==============================================================Validateion at client side=================================================
function ValidateRID(rid){
    var noErrors=true;
    
    //Checks for first letter of RID
    if(rid.substring(0,1).toLowerCase()!="a" && rid.substring(0,1).toLowerCase()!="n"){
        noErrors=false;
    }
    
    if(rid.length<6){
        noErrors=false;
    }
    
    //Checks for occurence of a or n.
    rid = rid.replace(/\d/g,'');
    if(rid.toLowerCase()!="a" && rid.toLowerCase()!="n"){
        noErrors=false;
    }
    return noErrors;
}

function ValidateEmailAddres(emailAddress){
    
    var isValid = true;

    //Searches for @ and . and also validates the position
    isValid = (emailAddress.indexOf(".") > 2) && (emailAddress.indexOf("@") > 0);

    //checks that @ should appear immediately after or before '.'
    if (emailAddress.indexOf("@") == emailAddress.indexOf(".") + 1 || emailAddress.indexOf("@") == emailAddress.indexOf(".") - 1)
        isValid = false;

    //Checks for domain. Domain should be com,net etc.
    var domain = emailAddress.substring(emailAddress.lastIndexOf('.') + 1, emailAddress.length);
    if (domain.length < 3 || domain.length > 3)
        isValid = false;

    //checks for Invalid Chars
    var invalidChars = '\/\'\\ ";:?!()[]\{\}^|';
    for (i = 0; i < invalidChars.length; i++) {
        if (emailAddress.indexOf(invalidChars.charAt(i), 0) > -1) {
            isValid = false;
        }
    }

    return isValid;
}

function ValidateDate(strDate,strYearLength,showAlert,strMessage){
    var noErrors=true;
    var split = strDate.split('/');

    if(parseInt(split.length)!=3){
        noErrors = false;
    }
    else{
        //Validates date
        if(isNaN(split[0]) || parseFloat(split[0])<=0 || parseFloat(split[0])>31 || $.trim(split[0])==''){
            noErrors = false;
        }
        //Validates month
        if(isNaN(split[1]) || parseFloat(split[1])<=0 || parseFloat(split[1])>12 || $.trim(split[1])==''){
            noErrors = false;
        }
        
        //Validates year
        var minYear=1900;
        if(parseFloat(strYearLength)==2){
            minYear=0;
        }
        
        if(isNaN(split[2]) || parseFloat(split[2].length)!=parseFloat(strYearLength) || parseFloat(split[2])<minYear){
            noErrors = false;
        }
        
        var month=parseFloat(split[1])-1;
        var date=parseFloat(split[0]);
        var maxDate=31;
        if(month==1){
            maxDate=28;
            if(parseFloat(split[2]) % 4 == 0){
                maxDate=29;
            }
        }
        else if(month==3 || month==5 || month==8 || month==10){
            maxDate = 30;
        }
        
        if(date>maxDate){
            noErrors=false;
        }
    }
    
    if(showAlert== true && noErrors==false){
            alert("Enter valid " + strMessage + ".");
    }
    return noErrors;
}

function ValidateTime(strTime,showAlert,strMessage){
    var noErrors=true;
    var split=strTime.split(':');
    if(parseInt(split.length)!=2){
        noErrors = false;
    }
    else{
        //Validates hours
        if(isNaN(split[0]) || parseInt(split[0]<=0) || parseInt(split[0])>12){
            noErrors = false;
        }
        
        //Validates minutes
        if(isNaN(split[1]) || parseInt(split[1]<0) || parseInt(split[1])>59){
            noErrors = false;
        }
    }
    
    if(showAlert== true && noErrors==false){
            alert("Enter valid " + strMessage + ".");
    }
    return noErrors;
}
function ValidatePinCode(strTextBoxControlID){
    //Only space and numbers are allowed.
    var string=$.trim($("#" + strTextBoxControlID).val());
    string = string.replace(/\s+/g,'');
    
    var noErrors=true;
    if(string.indexOf(".")!=-1){
        noErrors=false;
    }
    else{
        if(isNaN(string)){
            noErrors=false;
        }
    }
    
    return noErrors;

}

function ValidatePhoneNumber(strTextBoxControlID){
    //Only space and numbers are allowed.
    var string=$.trim($("#" + strTextBoxControlID).val());
    string = string.replace(/\s+/g,'').replace(/,/g,'');
    
    var noErrors=true;
    if(string.indexOf(".")!=-1){
        noErrors=false;
    }
    else{
        if(isNaN(string)){
            noErrors=false;
        }
    }
    return noErrors;
}

function ValidateSalary(strTextBoxControlID){
    //Only comma and numbers are allowed.
    var salary=$.trim($("#" + strTextBoxControlID).val());
    salary =salary.replace(/,/g,'');
    
    var noErrors=true;
    if(salary.indexOf(".")!=-1){
        noErrors=false;
    }
    else{
        if(isNaN(salary)){
            noErrors=false;
        }
    }
    
    return noErrors;
}

function ValidateForm(){
    var errorMessage="";
    var isFocus=false;
    $("#TblContentBody .mandatory").each(function(){
        switch($(this).attr("type")){
            case "text":
                if($.trim($(this).val())==''){
                    errorMessage+=$(this).attr("messagetext") + " is required.\n";
                    if(isFocus==false){
                        isFocus=true;
                        $(this).focus();
                    }
                }
                //Validates email address
                else if($(this).attr("emailaddress")){
                    var isValid=ValidateEmailAddres($.trim($(this).val()));
                    if(isValid==false){
                        errorMessage+="Enter valid email address.\n";
                        if(isFocus==false){
                            isFocus=true;
                            $(this).focus();
                        }
                    }
                }
                //Validates date
                else if($(this).attr("date")){
                    isValid= ValidateDate($.trim($(this).val()),$(this).attr("yearlength"),false,"");
                    if(isValid==false){
                        errorMessage+="Enter valid " + $(this).attr("messagetext") + ".\n";
                        if(isFocus==false){
                            isFocus=true;
                            $(this).focus();
                        }
                    }
                }
                //Validates time
                else if($(this).attr("time")){
                    isValid= ValidateTime($.trim($(this).val()),false,"");
                    if(isValid==false){
                        errorMessage+="Enter valid " + $(this).attr("messagetext") + ".\n";
                        if(isFocus==false){
                            isFocus=true;
                            $(this).focus();
                        }
                    }
                }
                //Validates phone number and pin code
                else if($(this).attr("phonenumber")){
                    isValid=ValidatePhoneNumber($(this).attr("id"));
                    if(isValid==false){
                        errorMessage+="Enter valid " + $(this).attr("messagetext") + ".\n";
                        if(isFocus==false){
                            isFocus=true;
                            $(this).focus();
                        }
                    }
                }
                 else if($(this).attr("pincode")){
                    isValid=ValidatePinCode($(this).attr("id"));
                    if(isValid==false){
                        errorMessage+="Enter valid " + $(this).attr("messagetext") + ".\n";
                        if(isFocus==false){
                            isFocus=true;
                            $(this).focus();
                        }
                    }
                }
                //Validates salary
                else if($(this).attr("salary")){
                    isValid= ValidateSalary($(this).attr("id"));
                    if(isValid==false){
                        errorMessage+="Enter valid " + $(this).attr("messagetext") + ".\n";
                        if(isFocus==false){
                            isFocus=true;
                            $(this).focus();
                        }
                    }
                }
                
                break;
                
            case "password":
                if($.trim($(this).val())==''){
                    errorMessage+=$(this).attr("messagetext") + " is required.\n";
                    if(isFocus==false){
                        isFocus=true;
                        $(this).focus();
                    }
                }
                break;
                
            case "textarea":
                if($.trim($(this).val())==''){
                    errorMessage+=$(this).attr("messagetext") + " is required.\n";
                    if(isFocus==false){
                        isFocus=true;
                        $(this).focus();
                    }
                }
                break;
                
            case "table":
                //Used to validate radio buttons
                if($(this).find(":radio").filter(":checked").size()==0){
                    errorMessage+= "Select " + $(this).attr("messagetext") + ".\n";
                    if(isFocus==false){
                        isFocus=true;
                        $(this).focus();
                    }
                }
                
            case "file":
                //used to validate file extensions
                if($.trim($(this).val())!=''){
                    var fileName=$(this).val();
                    var split=fileName.split('.');
                    var fileExtension=split[split.length-1].toLowerCase();
                    if(fileExtension!='jpg' && fileExtension!='jpeg' && fileExtension!='gif'){
                        errorMessage+="Only jpg,jpeg,gif are allowed.\n";
                        if(isFocus==false){
                            isFocus=true;
                            $(this).focus();
                        }
                    }
                }
                break;
                              
            case "select-one":
                if(parseInt($(this).val()) <= 0 && $(this).css("display") !='none' ){
                    errorMessage+=$(this).attr("messagetext") + " is required.\n";
                    if(isFocus==false){
                        isFocus=true;
                        $(this).focus();
                    }
                }
                break;
        };
    });
    
    errorMessage+=ValidateCheckedListBoxes();
    
    if($.trim(errorMessage)==''){
        return true;
    }
    else{
        alert(errorMessage);
        return false;
    }
}

function ValidateCheckedListBoxes(){
    var errorMessage="";
    $("#TblContentBody .checkedListBox").filter(".mandatory").each(function(){
        if($(this).find(":checked").size()==0){
            errorMessage+="Select atleast one " + $(this).attr("messagetext") + ".\n";
        }
    });
    
    return errorMessage;
}

function ShowServerSideMessages(){
    if($.trim($("#ctl00_DivMessagesFromServer").html())!='')
    {
        alert($("#ctl00_DivMessagesFromServer").html());
    }
}


function AttachLabelToCheckboxesInListView(strTableID){
    $("#" + strTableID + " tbody tr td[id='TdCheckbox']").each(function(){
            var checkBox=$(this).find("input[type='checkbox']");
            var checkBoxID=checkBox.attr("id");
            
            var label=$(this).find("label");
            
            label.attr("for",checkBoxID);
        });
}

function AttachLabelToCheckboxesIncheckedListBox(strTableID,strLabelTextPrefix){
    var counter=1;
    $("#" + strTableID + " tbody tr td table tr td :checkbox").each(function(){
            //var checkBox=$(this).find("input[type='checkbox']");
            var checkBoxID=$(this).attr("id");
            
            var label=null;
            if($(this).siblings().size()==0){
                label=$(this).parent().siblings("label");
            }
            else{
                label=$(this).siblings("label");
            }
           
            //label.attr("id","lbl" + checkBoxID);
            //label.attr("for",checkBoxID);
            //alert($(this).parents("td").siblings().html());
            if(counter==1){
                label.html($(this).parents("td").siblings().html() + " " + strLabelTextPrefix + " " + counter + " of " + $("#" + strTableID + " tbody tr td table").size());
            }
            else{
                label.html($(this).parents("td").siblings().html() + " " + counter + " of " + $("#" + strTableID + " tbody tr td table").size()); 
            }
            
            counter++;
    });
    
    var maxLength=0;
    $("#" + strTableID + " tbody tr td table tr td[id='textField']").each(function(){
        if(parseInt($(this).html().length)>maxLength){
            maxLength=parseInt($(this).html().length);
        }
    });
    
    $("#" + strTableID + " tbody tr td table tr td[id='textField']").css("width",(maxLength * 7) + 3);
}

function AttachLabelToRadioButtonsInListView(strTableID){   
    //$("#" + strTableID + " tbody tr td[id='TdRadioButton'] input[type='radio']:first").attr("checked",true);
    $("#" + strTableID + " tbody tr td[id='TdRadioButton']").each(function(){
            var radioButton=$(this).find("input[type='radio']");
            //radioButton.attr("name","ctl00$ContentPlaceHolder2$" + strTableID);
            var label=$(this).find("label");
            
            //label.attr("for",radioButton.attr("id"));
            
            //Attaches click event so that only one radio button can be selected at any time
            radioButton.click(function(){
                SelectSingleRadioButton(strTableID,$(this).attr("id"));
            });
        });
}

function ValidateListViewForCheckedRadioButtons(strTableID,strMessage){
    var checkedRadioButtons=$("#" + strTableID + " :radio").filter(":checked").size();
    if(checkedRadioButtons==0){
        alert(strMessage);
        return false;
    }
    else{
        return true;
    }
}

function SelectSingleRadioButton(strTableName,strradioButtonID){
    $("#" + strTableName + " tbody tr td[id='TdRadioButton'] input[type='radio']").attr("checked",false);
    
    $("#" + strradioButtonID).attr("checked",true);
}

function InsertRecordNumber(strTableID){
	var recordNumber=1;
	$("#" + strTableID + " tbody tr td[id='TdRecordNumber']").each(function(){
		if($(this).find("a").length > 0){
			$(this).find("a").html(recordNumber);
		}
		else{
			$(this).html(recordNumber);
		}
		
		recordNumber++;
	});
}

function InsertRecordNumberWithPaging(strTableID,pageNumber){
	var recordNumber=((parseInt(pageNumber)-1)*50) + 1;
	$("#" + strTableID + " tbody tr td[id='TdRecordNumber']").each(function(){
		if($(this).find("a").length > 0){
			$(this).find("a").html(recordNumber);
		}
		else{
			$(this).html(recordNumber);
		}
		recordNumber++;
	});
}

function InsertRecordNumberWithAssignedlistPaging(strTableID,pageNumber){
	var recordNumber=((parseInt(pageNumber)-1)*25) + 1;
	$("#" + strTableID + " tbody tr td[id='TdRecordNumber']").each(function(){
		if($(this).find("a").length > 0){
			$(this).find("a").html(recordNumber);
		}
		else{
			$(this).html(recordNumber);
		}
		recordNumber++;
	});
}

function FilterCityStates(strFilterID,strFilterAttribute,strVisibleDropdownID,strDdlHiddenDropdownID){
    var options="";
    // $("#" + strVisibleDropdownID).html("");
    var i;
    var DdlCities = document.getElementById(strVisibleDropdownID);
    var dlength = parseInt(DdlCities.options.length);
    if (dlength > 0) {
        DdlCities.options.length = 0;
    }
    DdlCities.options[0]=new Option("Select","-2");
    $("#" + strDdlHiddenDropdownID + " option[" + strFilterAttribute + "=" + strFilterID + "]").each(function(){
        options+="<option value='" + $(this).attr("value") + "'>" + $(this).html() + "</option>\n";
        DdlCities.options[DdlCities.options.length]=new Option($(this).html(),$(this).attr("value"));
    });
    
    if(options==""){
        options="<option value='-3'>Not Available</option>";
        DdlCities.options[0]=new Option("Not Available","-3");
    }
    
    DdlCities.selectedIndex=0;
    
    $("#" + strDdlHiddenDropdownID).val($("#" + strVisibleDropdownID).val());
    $("#" + strVisibleDropdownID).change(function(){
        $("#" + strDdlHiddenDropdownID).val($(this).val());
    }); 
}

function FilterCityStatesInPopup(strFilterID,strFilterAttribute,strVisibleDropdownID,strDdlHiddenDropdownID){
    var options="";
    $("#" + strVisibleDropdownID).html("");
    var DdlCities = document.getElementById("" + strVisibleDropdownID);
        DdlCities.options[0] = new Option("Select", "-2");
        $("#" + strDdlHiddenDropdownID + " option[" + strFilterAttribute + "=" + strFilterID + "]").each(function () {
            options += "<option value='" + $(this).attr("value") + "'>" + $(this).html() + "</option>\n";
            DdlCities.options[DdlCities.options.length] = new Option($(this).html(), $(this).attr("value"));
        });

        if (options == "") {
            options = "<option value='-3'>Not Available</option>";
            DdlCities.options[0] = new Option("Not Available", "-3");
        }

        DdlCities.selectedIndex = 0;
        //Error causing statement
        //$("#" + strVisibleDropdownID).html(options);

        $("#" + strDdlHiddenDropdownID).val($("#" + strVisibleDropdownID).val());

        $("#" + strVisibleDropdownID).change(function () {
            $("#" + strDdlHiddenDropdownID).val($(this).val());
        });
}

//=========================country dropdown change=============================================================
function DdlCountries_OnSelectedIndexChanged(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown){
    FilterCityStates(countryID,customAttribute,DdlVisibleDropdown,DdlHiddenDropdown);
    if(DdlVisibleDropdown.indexOf("Present")!=-1){
        $("#DdlPresentAddressStates").change();
    }
    else{
        $("#DdlPermanentAddressStates").change();
    }
}

function SetDefaultOptionExelInReport(){
    $("#StiWebViewer1_SaveTypeList").val("Microsoft Excel");
}


function PreventTimeOut() {
    $.get("/Enable%20India/CommonService.asmx?op=HelloWorld", function() { });

}
var t = setInterval("PreventTimeOut()", 6000000);

function disableControls(dd1, dd2) {
    $('#<%=dd1.ClientID %>').hide();
    $('#<%=dd2.ClientID %>').hide();

}
