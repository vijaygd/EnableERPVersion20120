/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../Scripts/jquery-1.7.1-vsdoc.js" />
///<reference path='../Scripts/Common.js' />

$(document).ready(function() {
    AttachLabelToCheckboxesIncheckedListBox("TblTrainingProgramEligibleDisabilityTypes", "ELIGIBLE DISABILITIES options");
    AttachLabelToCheckboxesIncheckedListBox("TblTrainingProgramEligibleGroups", "Eligible Groups options");
    AttachLabelToCheckboxesIncheckedListBox("TblEligibleEducationalQualification", "Eligible Educational Qualification");
    AttachLabelToCheckboxesIncheckedListBox("TblTrainingProgramRecommendedRoles", "Recommended Job Types and Roles");
    AttachLabelToCheckboxesIncheckedListBox("TblTrainingProgramRequiredLanguagess", "Required Languages");
    AttachLabelToCheckboxesIncheckedListBox("TblTrainingProgramCandidateShouldHavePassed", "Pre-requisite/Training Candidate should have passed");

    $("#BtnHelp").click(function() {
        ShowPopUp("../ITextPopup.aspx?page=add_train_program", 720, 140);
    });

});