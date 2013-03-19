(function( $ ){
  $.fn.ntz_infiniteCarousel = function() {
    return this.each(function(){
      var carousel = $(this),
          etalon = $('li:first', carousel);
      carousel.wrap('<div class="ntz_infiniteCarouselWrap"></div>');
      var w = carousel.closest('.ntz_infiniteCarouselWrap'), //the wrap
          n = $('<a href="#" class="nav next"/><a href="#" class="nav prev"/>'), // the navigation
          inc = etalon.outerWidth(true), // increment - the width of an element ( is the same amount of px to be scrolled )
          ul = $('ul', carousel),
          perPage = Math.ceil( w.width()/inc ), // how many elements are displayed per page
          fX = $('li:lt(' + perPage + ')', ul).clone(), // first and last X elements ( x = perPage)
          lX = $('li:gt('+ ( $('li', ul).length - perPage-1 ) +')', ul).clone(),
          s = $('li.s', carousel); // selected 
      w.addClass( carousel.attr('id') );
      ul.append(fX).prepend(lX); // adding elemnts on begining and the end for infinite loop
      var ulW = $('li', ul).length * inc, // width for ul
          maxPos = -1*(ulW - inc*perPage - perPage); // max position
      ul.width( ulW ).css({marginLeft:-inc*perPage}); 
 
      n.click(function(){
        var t = $(this),
            curPos = parseInt(ul.css('marginLeft'), 10);
        if( ul.is(':animated') ) {return false;} // we don't need multiple scrolls
 
        if( t.hasClass('next') ){ // scroll left
          if( curPos >= 0 ){
            ul.css({ marginLeft: -( ulW - inc * perPage*2 ) }); // infinite loop
          }
          ul.animate({ marginLeft:'+='+inc })
        }
 
        if ( t.hasClass('prev') ) { //scroll right
          if( maxPos >= curPos ){
            ul.css({ marginLeft: - inc * perPage }); // infinite loop
          }
          ul.animate({ marginLeft:'-='+inc });
        }     
        return false;
      });
      n.appendTo(w);
    });
  }; // ntz_infiniteCarousel
})( jQuery );
$('#sliderWrapper').ntz_infiniteCarousel();
if (!Object.create) {
  Object.create = function (o) {
    if (arguments.length > 1) {
      throw new Error('Object.create implementation only accepts the first parameter.');
    }
    function F() {}
    F.prototype = o;
    return new F();
  };
}

jQuery(document).ready(function($){
  $('body').enablePlaceholders();
	//Cufon.replace('.topM li a', { fontFamily: 'cursive' });
	//Cufon.replace('.quote', { fontFamily: 'cursive' });
});

(function( $, document ){
  var enablePlaceholders = {
    init: function( el ){
      var $t = this;
      $t.el = $(el).data( 'hasplaceholder', true );
      $t.placeholder = $t.el.attr('placeholder');
      $t.addPlaceholder( $t.el );
    } // init
    ,clearValue: function( e ){
      if( $(e).val() === $(e).data('placeholder') ) {
        $(e).val('');
      }
    }//clearValue
    ,addPlaceholder: function(){
      var $t = this;
        $t.maybeShowPlaceholder();
      $t.el.bind('blur.ntz_placeholder', $.proxy( $t.maybeShowPlaceholder, $t ) );
      $t.el.bind('focus.ntz_placeholder', $.proxy( $t.maybeHidePlaceholder, $t ) );
    } //addPlaceholder
    ,maybeShowPlaceholder: function(){
      var $t = this;
      if( $.trim( $t.el.val() ) !== '' ){ return; }
      $t.el
        .addClass('placeholder')
        .val( $t.placeholder );
    }//maybeShowPlaceholder
    ,maybeHidePlaceholder: function(){
      var $t = this;
      if( $t.el.hasClass('placeholder') && 
          $t.el.val() == $t.placeholder ){
        $t.el.val('')
      } 
    }//maybeHidePlaceholder
  };

  $.fn.enablePlaceholders = function() {
    var fakeInput = document.createElement("input"),
        nativePlaceholder = ("placeholder" in fakeInput);
    if (!nativePlaceholder) {
      $('input[placeholder], textarea[placeholder]').filter(function(){
        return !$(this).data('hasplaceholder')
      }).each(function(){
        var obj = Object.create( enablePlaceholders );
        obj.init( this );
      });
      return this;
    }
  };

	var d = document;
	var safari = (navigator.userAgent.toLowerCase().indexOf('safari') != -1) ? true : false;
	var gebtn = function(parEl,child) { return parEl.getElementsByTagName(child); };
	onload = function() {
						
			var body = gebtn(d,'body')[0];
			body.className = body.className && body.className != '' ? body.className + ' has-js' : 'has-js';
						
			if (!d.getElementById || !d.createTextNode) return;
			var ls = gebtn(d,'label');
			for (var i = 0; i < ls.length; i++) {
					var l = ls[i];
					if (l.className.indexOf('label_') == -1) continue;
					var inp = gebtn(l,'input')[0];
					if (l.className == 'label_check') {
							l.className = (safari && inp.checked == true || inp.checked) ? 'label_check c_on' : 'label_check c_off';
                            l.onclick = check_it;
					};
					if (l.className == 'label_radio') {
							l.className = (safari && inp.checked == true || inp.checked) ? 'label_radio r_on' : 'label_radio r_off';
							l.onclick = turn_radio;
					};
			};
	};
	var check_it = function() {
			var inp = gebtn(this,'input')[0];
            if (this.className == 'label_check c_off' || inp.checked) {
					this.className = 'label_check c_on';
					//if (safari) inp.click();
			} else {
					this.className = 'label_check c_off';
					//if (safari) inp.click();
			};
            // plamen: this fails in chrome - 2nd click() action reverts checkbox state
//			if (this.className == 'label_check c_off' || (!safari && inp.checked)) {
//					this.className = 'label_check c_on';
//					if (safari) inp.click();
//			} else {
//					this.className = 'label_check c_off';
//					if (safari) inp.click();
//			};
	};
	var turn_radio = function() {
			var inp = gebtn(this,'input')[0];
			if (this.className == 'label_radio r_off' || inp.checked) {
					var ls = gebtn(this.parentNode,'label');
					for (var i = 0; i < ls.length; i++) {
							var l = ls[i];
							if (l.className.indexOf('label_radio') == -1)  continue;
							l.className = 'label_radio r_off';
					};
					this.className = 'label_radio r_on';
                    // plamen: this fails in chrome
					//if (safari) inp.click();
			} else {
					this.className = 'label_radio r_off';
					//if (safari) inp.click();
			};
	};

})( jQuery, document );

// http://paulirish.com/2011/requestanimationframe-for-smart-animating/
// http://my.opera.com/emoller/blog/2011/12/20/requestanimationframe-for-smart-er-animating

// requestAnimationFrame polyfill by Erik Möller
// fixes from Paul Irish and Tino Zijdel

(function() {
  var lastTime = 0,
      vendors  = [ 'ms', 'moz', 'webkit', 'o' ];
  for( var x = 0; x < vendors.length && !window.requestAnimationFrame; ++x ){
    window.requestAnimationFrame = window[vendors[x] + 'RequestAnimationFrame'];
    window.cancelAnimationFrame  = window[vendors[x] + 'CancelAnimationFrame'] || window[vendors[x] + 'CancelRequestAnimationFrame'];
  }

  if ( !window.requestAnimationFrame ){
    window.requestAnimationFrame = function( callback, element ){
      var currTime = new Date().getTime();
      var timeToCall = Math.max( 0, 16 - ( currTime - lastTime ) );
      var id = window.setTimeout( function(){ callback( currTime + timeToCall ); }, 
        timeToCall);
      lastTime = currTime + timeToCall;
      return id;
    };
  }

  if ( !window.cancelAnimationFrame ){
    window.cancelAnimationFrame = function( id ) {
      clearTimeout( id );
    };
  }
}());