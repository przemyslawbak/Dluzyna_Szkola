/****************************************
 * cookieBubble.js: Version 1.0
 * author: João Pereira
 * website: http://www.joaopereira.pt
 * email: joaopereirawd@gmail.com
 * Licensed MIT 
*****************************************/
(function ($) {

	$.fn.cookieBubble = function (options) {

			var thiis = $(this);

			//Defaults
			var settings = $.extend({	
				icon:false,
				iconColor:false,
				buttonColor:false,
				buttonTextColor:false,
				buttonRadius:false,
				//Cookie cnf
				cookieMaxAge:30
			}, options);


			//icons available  
			var cookie_svg = {
				icon_1:'<div></div>'
			}

			//Cooking things function
			var cookieApp = {
				init:function() {
					var cb_icon = settings.icon;
				
						if (cb_icon) {
							cookieApp.addIcon(settings.icon);
						} else {
							var icon_container = thiis.find('.cb-image');
							    icon_container.remove();
						}
				
						cookieApp.checkCookie(); 

				}, 
				addIcon:function(icon) {
		
					var img_target = thiis.find('.cb-row');  //this is the target where SVG image will be inserted

			       	var cookie_img = settings.icon;

				       	switch (cookie_img) {
				       	   	case 'cookie_icon_1': img_target.prepend(cookie_svg.icon_1); break;	
				       	   	default: img_target.prepend(cookie_svg.icon_1);
				                
				       	}
		          				
				},

				setCookie:function(cname,cvalue,exdays) {
				    var d = new Date();
				    d.setTime(d.getTime() + (exdays*24*60*60*1000));
				    var expires = "expires=" + d.toGMTString();
				    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
				},
				getCookie: function(cname) {
				    var name = cname + "=";
				    var decodedCookie = decodeURIComponent(document.cookie);
				    var ca = decodedCookie.split(';');
				    for(var i = 0; i < ca.length; i++) {
				        var c = ca[i];
				        while (c.charAt(0) == ' ') {
				            c = c.substring(1);
				        }
				        if (c.indexOf(name) == 0) {
				            return c.substring(name.length, c.length);
				        }
				    }
				    return "";
				},
				checkCookie: function() {
				    var get_cookie = cookieApp.getCookie('cookieBubble');

				    if (get_cookie != "" && get_cookie != null) {
				    	
				        thiis.hide(); //Hide cookieBuble
				    } else {
				        thiis.show(); //Show cookieBuble
						var button = thiis.find('.gotit-btn'); //Got it Button
						
							if (settings.buttonColor) button.css('background-color', settings.buttonColor );
							if (settings.buttonTextColor) button.css('color', settings.buttonTextColor );
							if (settings.buttonRadius) button.css('border-radius', settings.buttonRadius );

				    		button.click(function(event) {
								cookieApp.setCookie('cookieBubble', 'hide', settings.cookieMaxAge); 
								thiis.hide();
						});
				    }
				},

			}

    		//Each function
			return this.each(function () {
				cookieApp.init();	
			});
	};


})(jQuery);


