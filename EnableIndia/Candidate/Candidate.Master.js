/// <reference path="../Scripts/jquery-2.1.4.min.js" />
///<reference path='../Scripts/Common.js' />


// this is global ready function
$(document).ready(function() {
    ShowHoverEffect();
    ShowServerSideMessages();
    
    //var width=screen.width - 438;
    var width= parseInt($(".subHeader").attr("offsetWidth")) + parseInt($("#TdGlobalButtons").attr("offsetWidth"));
    //alert(width);
    $("#TblUnderline").attr("width",width + "px");
    //$("#BtnLogOff").css("padding-left","1024px");
    //alert($("#tbTopBand").css("background"));
});

//function myLoad() {
//    if (document.all) {
//        document.all.loading.style.visibility = "hidden";
//    }
//    else {
//        document.loading.visibility = "hide";
//    }
//}  
//function my_events() {  
//    bind_events();  
//    myLoad();  
//}
//window.onload = my_events; //Assign events
