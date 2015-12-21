/// <reference path="Scipts/jquery-1.7.2-vsdoc.js" />
/// <reference path="Scripts/jquery-1.7.2.min.js" />



function animateGif() {
    var isIE = (navigator.userAgent.indexOf("MSIE") != -1);
    if (!isIE) {
        isIE = (navigator.userAgent.indexOf("Trident") != -1);
    }
    var pb = document.getElementById("progressBar");
    if (isIE) {
        pb.innerHTML = '<img src="../Images/pleasewait.gif" width="400" height ="26"/>';
    }
    pb.style.display = '';
}