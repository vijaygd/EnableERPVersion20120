



$(document).ready(function() {

    $("#BtnHelp").click(function() {
    if(document.URL.indexOf("RegisterEmployee.aspx?emp=")==-1){
        ShowPopUp("../ITextPopup.aspx?page=add_enable_emp", 650, 150);
    }
    else
    {
        ShowPopUp("../ITextPopup.aspx?page=update_enable_emp", 650, 150);
    }
   // alert("df");
    
});

//=======================
    if(document.URL.indexOf("RegisterEmployee.aspx?emp=")>0){
       
        document.title="Update Enable India Employees";
        var lnkEmployeeList=$("#LeftMenu a[id=LnkEmployeeDetails]");
    
        $("#LeftMenu a").css("color","#0061AA");
        $(".selected_level2").removeClass("selected_level2");
        
        lnkEmployeeList.css("color","#D80000");
        lnkEmployeeList.parents("table[class^='level']").addClass("selected_level2");
    }
});


function ValidateEmployee(){
       var message="";
       var isValid=true;
    var firstName=$('#TxtFirstName').val() ;
    var middlname= $('#TxtMiddleName').val();
    var lastName=$('#TxtLastName').val();
    var btnDelete=$("#BtnDeleteEmployee");
    var isConfimed=confirm('Are you sure about deleting employee ' + firstName + ' ' + middlname + ' ' + lastName + ' ?');
    if(isConfimed==true){
        message+="Employee can not be deleted as employee has assigned";
        
        if(btnDelete.attr("OpenCandidateTask")>0){
            message+=" open candidate task";
            if(btnDelete.attr("OpenCompanyTask")>0){
                message+=" and open company task "
            }
            if(btnDelete.attr("OpenTraningProject")>0){
                message+=" and open training project";
            }
            if(btnDelete.attr("OpenEmpProject")>0){
                message+=" and open employment project";
            }
            message+=".";
            isValid=false;
            
        }else if(btnDelete.attr("OpenCompanyTask")>0){
            message+=" open company task";
            if(btnDelete.attr("OpenTraningProject")>0){
                 message+=" and open training project";
            }
            if(btnDelete.attr("OpenEmpProject")>0){
                 message+=" and open employment project";
            }
            message+=".";
            isValid=false;
            
        }else  if(btnDelete.attr("OpenTraningProject")>0){
            message+=" open training project";
             if(btnDelete.attr("OpenEmpProject")>0){
                message+=" and  open employment project"
             }
             message+=".";
            isValid=false;
            
        }else  if(btnDelete.attr("OpenEmpProject")>0){
            message+=" open employment project.";
            isValid=false;
            
        }
        if(isValid==false){
            alert(message);
        }
        return isValid;
    }
    else{
        return isConfimed;
    }
    
}