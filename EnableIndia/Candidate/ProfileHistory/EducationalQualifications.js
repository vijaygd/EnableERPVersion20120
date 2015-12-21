/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
///<reference path='../../Scripts/common.js' />

$(document).ready(function(){
    $("#BtnHelp").click(function() {
        ShowPopUp("../../ITextPopup.aspx?page=edu_qulification", 500, 150);
    });
    InsertRecordNumber("TblEducationalQualifications");
});

function ShowEducationalQualificationsPopup(strqualificationID,strLinkButtonID){
    var candidateID=document.URL.substring(document.URL.indexOf("=") + 1,document.URL.length);
    var url="../EducationalQualificationsPopUp.aspx?cand=" + candidateID;
    
    var qualificationID="";
    if(strqualificationID!="-1"){
        url+= "&cand_qual=" + $("#TblEducationalQualifications #" +strLinkButtonID ).attr("CourseQualificationID");
    }
    
    ShowPopUp(url,'850','220');
}