function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode != 46 && charCode > 31
      && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

// Upper Case Validation
function UpperCase(ctrlID) {
    var PANNo = document.getElementById(ctrlID).value;
    if (PANNo != "") {
        document.getElementById(ctrlID).value = PANNo.toUpperCase();
    }
}
// Pan Card Validation

function ValidatePAN() {
    var Obj = document.getElementById("panno");
    if (Obj.value != "") {
        ObjVal = Obj.value;
        var panPat = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
        if (ObjVal.search(panPat) == -1) {
            alert("Invalid Pan No");
            Obj.focus();
            return false;
        }
        else {
            alert("Correct Pan No");
        }
    }
}

// ifsc CODE

$(document).ready(function () {

    $("#IFSCCode").change(function () {
        $('span.error-keyup-7').remove();
        var inputvalues = $(this).val();
        var reg = /[A-Z|a-z]{4}[0][a-zA-Z0-9]{6}$/;
        if (inputvalues.match(reg)) {
            return true;
        }
        else {
            $("#IFSCCode").val("");
            $(this).after('<span class="error error-keyup-7" style="color:red;">Invalid IFSC Code.</span>');
            //alert("You entered invalid IFSC code");
            //document.getElementById("txtifsc").focus();
            return false;
        }
    });

});

// pan 
$(document).ready(function () {
    $('#panno').keyup(function () {
        
        $('span.error-keyup-7').remove();
        var inputVal = $(this).val();
        var pancardno = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
        if (!pancardno.test(inputVal)) {
            $(this).after('<span class="error error-keyup-7" style="color:red;">Invalid Panno Format.</span>');
        }
    });
});

// email 
$(document).ready(function () {
    $('#emailid').keyup(function () {
        
        $('span.error-keyup-7').remove();
        var inputVal = $(this).val();
        var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        if (!emailReg.test(inputVal)) {
            $(this).after('<span class="error error-keyup-7" style="color:red;">Invalid Email Format.</span>');
        }
    });
});

// email
$(document).ready(function () {
    $('#email').keyup(function () {
        
        $('span.error-keyup-7').remove();
        var inputVal = $(this).val();
        var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        if (!emailReg.test(inputVal)) {
            $(this).after('<span class="error error-keyup-7" style="color:red;">Invalid Email Format.</span>');
        }
    });
});
// Money 

function checkAmount()
{
    var myField = document.getElementById("field")
    var reg = /^\d{0,4}(\.\d{0,2})?$/; if (reg.test(myField.value))
    {
        alert("Nice real currency!");
    }
    else
    {
        alert("Please Enter a Valid Amount!");
    }
}
 
// Mobile No 
$(document).ready(function () {

    $("#mobileno").on("blur", function () {
        
        var mobNum = $(this).val();
        var filter = /^\d*(?:\.\d{1,2})?$/;

        if (filter.test(mobNum)) {
            if (mobNum.length == 10) {
               // alert("valid");
                $("#mobile-valid").removeClass("hidden");
                $("#folio-invalid").addClass("hidden");
            } else {
                alert('Please put 10  digit mobile number');
                $("#folio-invalid").removeClass("hidden");
                $("#mobile-valid").addClass("hidden");
                return false;
            }
        }
        else {
           // alert('Not a valid number');
            $("#folio-invalid").removeClass("hidden");
            $("#mobile-valid").addClass("hidden");
            return false;
        }
    });

    // User ke liy 
    $("#MobileNouser").on("blur", function () {
        
        var mobNum = $(this).val();
        var filter = /^\d*(?:\.\d{1,2})?$/;

        if (filter.test(mobNum)) {
            if (mobNum.length == 10) {
                // alert("valid");
                $("#mobile-valid").removeClass("hidden");
                $("#folio-invalid").addClass("hidden");
            } else {
               // alert('Please put 10  digit mobile number');
                $("#folio-invalid").removeClass("hidden");
                $("#mobile-valid").addClass("hidden");
                return false;
            }
        }
        else {
            // alert('Not a valid number');
            $("#folio-invalid").removeClass("hidden");
            $("#mobile-valid").addClass("hidden");
            return false;
        }
    });
});



// GST NO 
$(document).ready(function () {
    $('#gst').keyup(function () {
        
        $('span.error-keyup-7').remove();
        var inputVal = $(this).val();
        var GSTNO = /(0[0-9]|1[1-9]|2[0-9]|3[0-7])[A-Z]{3}[CPHFATBLJG]{1}[A-Z]{1}\d{4}[A-Z]{1}\d{1}[A-Z0-9]{2}/;
        if (!GSTNO.test(inputVal)) {
            $(this).after('<span class="error error-keyup-7" style="color:red;">Invalid</span>');
        }
        else
        {
            $(this).after('<span class="error error-keyup-7" style="color:green;">Valid.</span>');
        }
    });
});

// WEBSITE
$(document).ready(function () {
    $('#web').keyup(function () {
        
        $('span.error-keyup-7').remove();
        var inputVal = $(this).val();
        var WESITE = /^(?:(?:https?|ftp):\/\/)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})))(?::\d{2,5})?(?:\/\S*)?$/;// /(http(s)?:\/\/.)?(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)/;
        if (!WESITE.test(inputVal)) {
            $(this).after('<span class="error error-keyup-7" style="color:red;">Invalid</span>');
        }
        else {
            $(this).after('<span class="error error-keyup-7" style="color:green;">Valid.</span>');
        }
    });
});


// Pincode
$(document).ready(function () {
    $('#pin').keyup(function () {
        
        $('span.error-keyup-7').remove();
        var inputVal = $(this).val();
        var pincode = /^(\d{4}|\d{6})$/;
        if (!pincode.test(inputVal)) {
            $(this).after('<span class="error error-keyup-7" style="color:red;">Invalid</span>');
        }
        else {
            $(this).after('<span class="error error-keyup-7" style="color:green;">Valid.</span>');
        }
    });
});
