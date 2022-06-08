$(document).ready(function () {
    $('#EMAIL').keyup(function () {
        $('span.error-keyup-7').remove();
        var inputVal = $(this).val();
        var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        if (!emailReg.test(inputVal)) {
            $(this).after('<span class="error error-keyup-7" style="color:red;">Invalid Email Format.</span>');
        }
    });
});

