/// <reference path="../../Scripts/jquery-2.1.4.min.js" />
///<reference path='../../Scripts/common.js' />

$(document).ready(function(){
    
    $("#BtnHelp").click(function(){
        ShowPopUp("../../ITextPopup.aspx?page=work_exp", 400, 150);
    });

    InsertRecordNumber("TblExistingWorkExperience");
});

function ShowWorkExperiencePopUp(strWorkExperienceID,strLinkButtonID)
{
    var candidateID=document.URL.substring(document.URL.indexOf("=") + 1,document.URL.length);
    var url="../../Candidate/WorkExperiencePopup.aspx?cand=" + candidateID;
    
    if(strWorkExperienceID!="-1"){
        url += "&work_exp=" + $("#ContentPlaceHolder1_TblExistingWorkExperience #" + strLinkButtonID).attr("WorkExperienceID");
    }
    var x = TxtReturnValue.ClientID;
    url += +"&txboxId=" + x;
    ShowPopUp(url,880,350);
}



function showAlertOnEmployed(pStatus, _id)
{
 //   var grid = document.getElementById("LstViewExistingWorkExperience");
 //   window.alert("grid id: " + grid);
 //   var gridVal = grid.SelectedItems(1).SubItems(6).Text
 //   window.alert("Val: " + gridVal);

    if (pStatus == "Employed") {
        var userResponce = confirm("This candidate is already employed in company, do you want to make him unemployed?");
        if (userResponce == true) {
            ShowWorkExperiencePopUpDirectly(1, _id);
        }
        else {
            //            ShowWorkExperiencePopUp(-1, '');
            return (true); 
        } 
    }
    else 
    {
        ShowWorkExperiencePopUp(-1, '');   
    }
}

//function ShowWorkExperiencePopUpDirectly(candid, strWorkExperienceID) {

//    var url = "../WorkExperiencePopup.aspx?cand=" + candid;
//    if (strWorkExperienceID != "-1") {
//        url += "&work_exp=" + strWorkExperienceID;
//    }
//    else {
//        url += "&work_exp=" + '1';
//    }
//    ShowPopUp(url, 880, 350);
//}
  

function ShowWorkExperiencePopUpDirectly(strWorkExperienceID, strWorkExperienceID1)
 {
    var candidateID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.length);
    var url = "../../Candidate/WorkExperiencePopup.aspx?cand=" + candidateID;

    if (strWorkExperienceID != "-1") {
	    url += "&work_exp=" + strWorkExperienceID;
    }
//	var candid = '<%=candId %>';
//	var workexp = '<%=wkExp %>';
	url = "../../Candidate/WorkExperiencePopup.aspx?cand=" + candid + "&work_exp=" + workexp;
    
    ShowPopUp(url, 880, 350);
  }
  function refreshMain() {
      __doPostBack();
     
  }
  