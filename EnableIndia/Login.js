/// <reference path="Scripts/jquery-2.1.4.intellisense.js" />
/// <reference path="Scripts/jquery-2.1.4.min.js" />
/// <reference path="Scripts/Common.js" />

$(document).ready(function () {
    $("#TxLoginUserNameAndPassword").css("display", "none");
});

function ValidateUserDetail() {
    var message = "";
    var isValid = true;
    if ($("#TxtLoginName").val() == "") {
        message += "Please enter the username.\n";
        isValid = false;
    }
    if ($("#TxtLoginPassword").val() == "") {
        message += "Please enter the password.\n";
        isValid = false;
    }
    if (isValid == false) {
        alert(message);
    }
    return isValid;
}



function ValidateUserName() {
    if ($("#TxtLoginName").val() == "") {
        alert("Please enter the username.");
        return false;
    }
    else {
        return true;
    }
}
