/// <reference path="../../Scripts/jquery-1.5.1-vsdoc.js" />
// main object
var PSS = PSS || {};
PSS.EMPTYIMAGEURL = EMPTYIMAGEURL;
PSS.ICONHOME = ICONHOME;
PSS.ICONARROW = ICONARROW;
// debug only
function displayObject(o) {
    var out = '';
    for (var p in o) {
        out += p + ': ' + o[p] + '\n';
    }
    alert(out);
}

//jquery extensions
//simple wait indicator
$.extend({
    createWait: function (id) {
        return $('<div id="' + id + '" style="background-color: Red; color: White; text-align: center;">Please, wait...</div>');
    },
    removeWait: function (id) { $('#' + id).remove(); }
});
$.extend({
    getUrlVars: function () {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        }
        return vars;
    },
    getUrlVar: function (name) {
        return $.getUrlVars()[name];
    }
});
// query string value replacer
$.extend({
    replaceQueryStringValue: function (url, key, replace) {
        var re = new RegExp("(" + key + "=)[^\&]+", "g");
        return url.replace(re, '$1' + replace);
    }
});
// decode html encoded string
$.extend({
    decodeHtml: function (encoded) {
        return $('<div />').html(encoded).text();
    }
});
// show more/less
$.fn.shorten = function (settings) {
    var config = {
        showChars: 100,
        ellipsesText: "...",
        moreText: "more",
        lessText: "less"
    };

    if (settings) {
        $.extend(config, settings);
    }

    $('.morelink').live('click', function () {
        var $this = $(this);
        if ($this.hasClass('less')) {
            $this.removeClass('less');
            $this.html(config.moreText);
        } else {
            $this.addClass('less');
            $this.html(config.lessText);
        }
        $this.parent().prev().toggle();
        $this.prev().toggle();
        return false;
    });

    return this.each(function () {
        var $this = $(this);

        var content = $this.html();
        if (content.length > config.showChars) {
            var c = content.substr(0, config.showChars);
            var h = content.substr(config.showChars, content.length - config.showChars);
            var html = c + '<span class="moreellipses">' + config.ellipsesText + '&nbsp;</span><span class="morecontent"><span>' + h + '</span>&nbsp;&nbsp;<a href="javascript:void(0);" class="morelink">' + config.moreText + '</a></span>';
            $this.html(html);
            $(".morecontent span").hide();
        }
    });
}