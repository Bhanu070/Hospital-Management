
   


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


function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}