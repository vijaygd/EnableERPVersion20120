/// <reference path="../Scripts/jquery-2.1.4.min.js" />
///<reference path='../Scripts/Common.js' />
$(document).ready(function() {
    $("#BtnHelp").click(function() {
        if(document.URL.indexOf("RegisterNGO.aspx?ngo=")==-1){
                ShowPopUp("../ITextPopup.aspx?page=add_ngo", 700, 150);
        }
        else {
                ShowPopUp("../ITextPopup.aspx?page=update_ngo", 700, 150);
        }
    });
    
    //=======================================This code is used to display the label of the checkbox as the text on the left side.
    var maxLength = parseInt(0);
    $("#TblDisabilitySubTypes tbody tr td table tr td[id='textField']").each(function() {
        //$(this).find("label").attr("for", $(this).siblings().find(":input").attr("id"));
        if (parseInt($(this).find("label").html().length) > maxLength) {
            maxLength = parseInt($(this).find("label").html().length);
        }
    });
    $("#TblDisabilitySubTypes tbody tr td table tr td[id='textField']").css("width", (maxLength * 6) + 3);
    //============================================================================================================================

    AttachLabelToRadioButtonsInListView("TblNGOContacts");

    if (document.URL.indexOf("RegisterNGO.aspx?ngo=") > 0) {
        document.title = "Update NGO";
        var lnkNGOList = $("#LeftMenu a[id=LnkNGOList]");

        $("#LeftMenu a").css("color", "#0061AA");
        $(".selected_level2").removeClass("selected_level2");

        lnkNGOList.css("color", "#D80000");
        lnkNGOList.parents("table[class^='level']").addClass("selected_level2");
    }
    
    FilterCityStates($("#DdlStates").val(),'StateID','DdlCities','DdlHiddenCities');
    $("#DdlCities").val($("#SpnHiddenCityID").html());
    $("#DdlCities").change();
    InsertRecordNumber("TblNGOContacts");
});

function ShowContactsPopup(strContactID){
    var ngoID="";
    if(document.URL.indexOf("msg=")!="-1"){
        ngoID=document.URL.substring(document.URL.indexOf("=") + 1,document.URL.indexOf("msg=")-1);
    }
    else{
        ngoID=document.URL.substring(document.URL.indexOf("=") + 1,document.URL.length);
    }
    
    var url="Contacts.aspx?ngo=" + ngoID;
    if(strContactID!="-1")
    {
        url+="&cont=" + strContactID;
    }
    ShowPopUp(url,500,500);
}

function ValidateNGORegistration(){
    if($("#DdlStates").val()!="-2" && $("#SpnStateIDForValidation").html()=="-2"){
        alert("Please hit refresh button to refresh the cities.");
        return false;
    }
    else{
        return ValidateForm();
    }
}