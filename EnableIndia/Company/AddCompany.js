/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path='../Scripts/common.js' />

function ShowCompanyContactPopup(strContactID,strLinkButtonID) {
    var companyID = "";
    if(document.URL.indexOf("msg")==-1){
        companyID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.length);
    }
    else{
        companyID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.indexOf("&msg"));
    }
    
    var url = "AddCompanyContact.aspx?comp=" + companyID;
    if (strContactID != "-1") {
        url += "&cont="+ $("#TblAddCompany #" +strLinkButtonID ).attr("CompanyContactID");
    }
    url += "&txboxId=" + self.parent.location;
    ShowPopUp(url, 600, 200);
}
$(document).ready(function() {
    InsertRecordNumber("TblAddCompany");
    $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=add_comp", 900, 150);
    });
     FilterCityStates($("#DdlStates").val(),'StateID','DdlCities','DdlHiddenCities');
     $("#DdlCities").val($("#SpnHiddenCityID").html());
    $("#DdlCities").change();
});  

                                