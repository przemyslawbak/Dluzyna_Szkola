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

    //mieszanie stylow z viewbag

    //kolory tla
    $(".pasekLogowania, .pasekCieniaHeader, .tabela").css("background-color", stronatlo); //tło strony
    $(".archiwum, .tytulStrony, .kontenerWpisu, .kontenerDetails, .trescDetails, .dataDetails, .wpisDodatki, .makeTresc, .dodatekKontener, .kontenerDuzyWpis, .kontenerOsoby").css("background-color", tresctlo); //tło treści i kolor tekstu naglowkow
    $(".tytulWpisu, .tytulAdmin, .stronaPaging, .tytulDetails, .archiwumHeader").css("background-color", naglowkikolor); //tło nagłówków
    $(".p5edziennik, .tagStyle, .najazdMenu, .dalejWpisu, .dalejDetails, .dalejSukcesy, .dodatkiButton, .gotit-btn").css("background-color", przyciskikolor); //przyciskikolor
    $(".tagThisStyle, .nazwiskoOsoby").css("background-color", glownynaglowektlo); //główny nagłówek strony

    //kolory
    $(".przycisk, .p5edziennik, .hyperPaging, a span, .tytulAdmin, .stronaPaging, .dalejDetails, .stopa, actionLink:link, actionLink:visited, actionLink:active, .nazwiskoOsoby, .dodatkiButton, .dropdown div, .gotit-btn").css("color", tresctlo); //tresctlo
    $(".richText-btn span, .myLink a:link, .myLink a:active, .myLink a:visited, .funkcjeOsoby, .archiwumLink").css("color", tresckolor); //tresckolor
    $(".archiwum, .tytulStrony, .trescWpisu, .dataWpisu, .trescDetails, .dataDetails").css("color", glownynaglowektlo); //glownynaglowektlo
});