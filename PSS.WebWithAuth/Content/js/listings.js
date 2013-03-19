/// <reference path="../../Scripts/jquery-1.5.1-vsdoc.js" />

// main object
var PSS = PSS || {};

PSS.listings = {
    getFacilityMapObject: function () {
        return this.facilityMap;
    }
    , geocoding: {
        geocodeAddress: ""
        , addressComponents: {
            address: ""
            , city: ""
            , state: ""
            , zip: ""
        }
        , init: function (address, city, state, zip) {
            this.addressComponents = {
                address: address
                , city: city
                , state: state
                , zip: zip
            };
            this.build();
        }
        , build: function () {
            var addcmp = this.addressComponents;
            //"{address} {city}, {state} {zip}"
            this.geocodeAddress = addcmp.address + " " + addcmp.city + ", " + addcmp.state + " " + addcmp.zip;
        }
        // execute init() before this
        , exportLatLng: function ($targetLat, $targetLng) {
            var pssmaps = PSS.facilityMap; // replace
            pssmaps.initializeGeocoder();
            pssmaps.codeAddressSimple(this.geocodeAddress, $targetLat, $targetLng);
        }
    }
    , photoManipulation: {
        attachEvents: function (templateParams) {
            var that = this;
            var tp = templateParams;
            if (tp.facilityPhotoSel == null) {
                return;
            }

            var $imgbox = $(tp.imageBoxSel);
            var $imgspan = $(tp.imageSpanSel);

            $(tp.imageButtonSel).click(function () {
                $(tp.facilityPhotoSel).attr('class', 'hidden');
                $(tp.facilityPhotoSel + ' input[type="text"]').val('');
                $imgspan.find('img').remove();
            });
            $imgbox.focus(function (ev) {
                this.select();
            });
            $imgbox.blur(function (ev) {
                that.showThumb(templateParams);
            });
            if ($imgbox.val().length > 5) {
                that.showThumb(templateParams);
            }
        }
        , showThumb: function (templateParams) {
            var homereplacement = PSS.EMPTYIMAGEURL;
            var tp = templateParams;
            var newsrc = $(tp.imageBoxSel).val();
            var $imgspan = $(tp.imageSpanSel);
            var $imgspanimg = $imgspan.find('img');
            if ($imgspanimg.length == 0) {
                $imgspan.append($('<img src="' + newsrc + '" onerror="this.src=\'' + homereplacement + '\'"/>'));
            }
            else {
                $imgspanimg.attr('src', newsrc);
            }
        }
        , extractTemplateParams: function ($container) {
            var uid = $container.attr('data-container-id');
            var facilityphotosel = "#facility-photo_" + uid;
            var imgboxsel = "#s" + uid + " input";
            var imgbuttonsel = "#i" + uid;
            var imgspansel = "#ss" + uid;
            return { facilityPhotoSel: facilityphotosel, imageBoxSel: imgboxsel, imageButtonSel: imgbuttonsel, imageSpanSel: imgspansel };
        }
        , processPhotoDivs: function () {
            var that = this;
            var $photocontainers = $(".facility-photo-data");
            $photocontainers.each(function (index) {
                var templateparams = that.extractTemplateParams($(this));
                that.attachEvents(templateparams);
            });
        }
        , getLastHiddenContainer: function () {
            // ~ selector fails in IE9
            var $lastf = $('#facility-photo-container div[id^="facility-photo_"][class="hidden"]').filter(":first");
            $lastf.attr('class', 'fieldRow');
            var $cont = $lastf.find('input[type="text"]');
            $cont.focus();
            return $cont;
        }
    }
}