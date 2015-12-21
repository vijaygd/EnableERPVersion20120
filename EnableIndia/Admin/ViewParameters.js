/// <reference path="../Scripts/jquery-2.1.4.min.js" />
/// <reference path="../Scripts/Common.js" />


$(document).ready(function(){
    $("#TblParameters thead tr th[id='TdColumnHeader']").html($("#LblColumnHeader").html());
    
    InsertRecordNumber("TblParameters");
    InsertRecordNumber("TblDisibiltyType");
    InsertRecordNumber("TblJobTypeWithRole");
    InsertRecordNumber("TblCountryWithState");
    InsertRecordNumber("TblCityWithStateCountry");
});