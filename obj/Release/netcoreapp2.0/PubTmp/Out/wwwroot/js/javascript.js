$(document).ready(function () {

    //aktualnosci picture remove btn

    $(".myCheckbox").click(function () {
        if ($(this).is(':checked')) {
            $(".checkboxVerify").hide("slow");
        }
        else {
            $(".checkboxVerify").show("slow");
        }
    });
});