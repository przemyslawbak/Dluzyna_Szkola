var losuj = Math.floor(Math.random() * 2);
var gender = '';
if (losuj == 0) { gender = 'boy'; } else { gender = 'girl'; }
var temper = '15';
var rain = '';
var sun = '';
var odczuwalna = 15;

function changeGender() {
    if (gender == 'boy') { gender = 'girl'; } else { gender = 'boy'; }
    var elem = document.getElementById("ludzik");
    elem.src = "/img/pogoda/ava_" + gender + "_" + temper + sun + rain + ".png";
    elem.style.cursor = "pointer";
}

$(document).ready(function () {
    //documentation
    //https://codepen.io/fleeting/pen/yjhBK/
    //https://developer.yahoo.com/weather/documentation.html
    var currentHour = new Date().getHours();
    
    
    
    console.log(gender);
    $.simpleWeather({
        location: '',
        woeid: '491682',
        unit: 'c',
        success: function (weather) {
            if (weather.code == 3 ||
                weather.code == 4 ||
                weather.code == 5 ||
                weather.code == 6 ||
                weather.code == 7 ||
                weather.code == 8 ||
                weather.code == 9 ||
                weather.code == 10 ||
                weather.code == 11 ||
                weather.code == 12 ||
                weather.code == 18 ||
                weather.code == 35 ||
                weather.code == 37 ||
                weather.code == 38 ||
                weather.code == 39 ||
                weather.code == 40 ||
                weather.code == 42 ||
                weather.code == 45 ||
                weather.code == 47) {
                rain = '_rain';
            }
            if (weather.code == 30 ||
                weather.code == 31 ||
                weather.code == 32 ||
                weather.code == 34 ||
                weather.code == 36 ||
                weather.code == 44 &&
                currentHour > 7 &&
                currentHour < 20) {
                sun = '_sun';
            }
            if (weather.temp <= 5) { temper = 5; sun = ''; }
            if (weather.temp > 5 & weather.temp <= 10) { temper = 10; }
            if (weather.temp > 10 & weather.temp <= 15) { temper = 15; }
            if (weather.temp > 15 & weather.temp <= 20) { temper = 20; }
            if (weather.temp > 20 & weather.temp <= 25) { temper = 25; }
            if (weather.temp > 25) { temper = 99; rain = ''; }

            if (weather.heatindex > 50) { odczuwalna = weather.temp; } else { odczuwalna = weather.heatindex; }
            html = '<div class="col-md-6" style="float:left; text-align: center;">najnowsze pomiary<h1><i style="font-size: 65px; line-height: 50px;" class="icon-' + weather.code + '"></i><br/> ' + weather.temp + '&deg;' + weather.units.temp + '</h2> <p>odczuwalna temp.</p> ' + odczuwalna + '&deg;' + weather.units.temp + '</div>';
            html += '<div class="col-md-6" style="float:left;"><a onclick="changeGender();"><img id="ludzik" style="height: 200px; margin-top: 20px;  margin-bottom: 20px; cursor: pointer" src="/img/pogoda/ava_' + gender + '_' + temper + sun + rain +'.png"/></a></div>';
            html += '<div class="col-md-4" style="float:left; text-align: center; border-top: solid 1px black;">min<h2>' + weather.low + '&deg' + weather.units.temp + '</h2></div>';
            html += '<div class="col-md-4" style="float:left; text-align: center; border-top: solid 1px black;">dzisiaj<h2><i style="font-size: 60px; line-height: 28px;" class="icon-' + weather.todayCode + '"></i> ' + '</h2></div>';
            html += '<div class="col-md-4" style="float:left; text-align: center; border-top: solid 1px black;">max<h2><span>' + weather.high + '&deg;' + weather.units.temp + '</span></h2></div>';
            $("#weather").html(html);
        },
        error: function (error) {
            $("#weather").html('<p>' + error + '</p>');
        }
    });


    //wysiwyg editor
    $('.wysiwyg').richText();

    //date time picker
    //https://www.jqueryscript.net/time-clock/Datetime-Picker-jQuery-Moment.html
    $('#picker').dateTimePicker();

    //cookies popup
    //https://www.jqueryscript.net/slider/Cookie-Consent-Compliance-Popup-cookieBubble.html
    $('.cookieBubble').cookieBubble({
            cookieMaxAge: 30
        });
});