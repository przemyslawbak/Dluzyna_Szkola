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
    $(".c-event-body, .c-day-next-month, .c-event-list, .c-day, .c-day-previous-month, .archiwum, .tytulStrony, .kontenerWpisu, .kontenerDetails, .trescDetails, .dataDetails, .wpisDodatki, .makeTresc, .dodatekKontener, .kontenerDuzyWpis, .kontenerOsoby").css("background-color", tresctlo); //tło treści i kolor tekstu naglowkow
    $(".tytulWpisu, .tytulAdmin, .stronaPaging, .tytulDetails, .archiwumHeader, .c-week-day, .c-grid-title, .c-event-title").css("background-color", naglowkikolor); //tło nagłówków
    $(".p5edziennik, .c-event, .tagStyle, .najazdMenu, .dalejWpisu, .dalejDetails, .dalejSukcesy, .dodatkiButton, .gotit-btn").css("background-color", przyciskikolor); //przyciskikolor
    $(".tagThisStyle, .nazwiskoOsoby, .c-nav-btn-over, .c-today, .c-event-over").css("background-color", glownynaglowektlo); //główny nagłówek strony

    //kolory
    $(".c-grid-title, .c-event-title, .c-event-over, .c-event, .c-today, .c-week-day, .trescNaglowka, .przycisk, .p5edziennik, .hyperPaging, a span, .tytulAdmin, .stronaPaging, .tytulDetails, .dalejDetails, .stopa, actionLink:link, actionLink:visited, actionLink:active, .nazwiskoOsoby, .dodatkiButton, .dropdown div, .gotit-btn").css("color", tekstnaglowkow); //tresctlo
    $(".richText-btn span, .myLink a:link, .myLink a:active, .myLink a:visited, .funkcjeOsoby").css("color", tresckolor); //tresckolor
    $(".archiwum, .tytulStrony, .trescWpisu, .dataWpisu, .trescDetails, .dataDetails").css("color", glownynaglowektlo); //glownynaglowektlo
    $(".archiwumLink").css("color", przyciskikolor); //przyciskikolor
});