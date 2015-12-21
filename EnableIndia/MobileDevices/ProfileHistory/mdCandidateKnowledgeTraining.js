/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
///<reference path='../Scripts/Common.js' />

$(document).ready(function(){
    $("#BtnHelp").click(function() {
        ShowPopUp("../../ITextPopup.aspx?page=Knowlege_train", 500, 150);
    });
    
    AttachLabelToCheckboxesIncheckedListBox("TblComputerKnowledge","Computer Knowledge options");
    AttachLabelToCheckboxesIncheckedListBox("TblLanguages","Languages Known options");
});

function ShowTrainingProgrammPopup(strContactID){
    var candidateID=document.URL.substring(document.URL.indexOf("=") + 1, document.URL.length);
    var url = "mdCandidateKnowledgeTrainingPopUp.aspx?cand=" + candidateID;
    
    if (strContactID != "-1"){
        url+="";
    }
    ShowPopUp(url, 500, 400);
}