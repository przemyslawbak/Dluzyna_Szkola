﻿$(document).ready(function () {
    //swap shadows for mouse on/off
    $(".przycisk, .p5edziennik, .dalejWpisu, .dalejDetails").mouseenter(function () {
        $(this).addClass("najazd");
    });
    $(".przycisk, .p5edziennik, .dalejWpisu, .dalejDetails").mouseleave(function () {
        $(this).removeClass("najazd");
    });
    //remove clas until loaded
    $(".przycisk, .p5edziennik, .dalejWpisu, .dalejDetails").removeClass("najazd");

    //animate dropdown for nav bar
    $(".przycisk.p1").mouseenter(function () {
        $(this).stop().animate({ 'height': '488px' }, 'slow');
    });
    $(".przycisk.p1").mouseleave(function () {
        $(this).stop().animate({ 'height': '68px' }, 'slow');
    });
    $(".przycisk.p2").mouseenter(function () {
        $(this).stop().animate({ 'height': '488px' }, 'slow');
    });
    $(".przycisk.p2").mouseleave(function () {
        $(this).stop().animate({ 'height': '68px' }, 'slow');
    });
    $(".przycisk.p3").mouseenter(function () {
        $(this).stop().animate({ 'height': '368px' }, 'slow');
    });
    $(".przycisk.p3").mouseleave(function () {
        $(this).stop().animate({ 'height': '68px' }, 'slow');
    });
    $(".przycisk.p4").mouseenter(function () {
        $(this).stop().animate({ 'height': '548px' }, 'slow');
    });
    $(".przycisk.p4").mouseleave(function () {
        $(this).stop().animate({ 'height': '68px' }, 'slow');
    });

    //tag helpers
    var attr = "custombackground";
    var val = "przyciskikolor";
    //change color for dropdown
    $(".dropdown div").hover(function () {
        if ($(this).attr(attr)) {
            $(this).removeAttr(attr);
        } else {
            $(this).attr(attr, val);
        }
        $(this).toggleClass("najazdMenu");
    });

    //maybe to be removed, to verify
    $(".wpisArchiwum").hover(function () {
        $(this).toggleClass("najazdMenu");
    });


});