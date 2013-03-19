/// <reference path="../../Scripts/jquery-1.5.1-vsdoc.js" />

$(document).ready(function () {
    // address boxes
    var $address = $("#Address");
    var $city = $("#City");
    var $state = $("#State");
    var $zip = $("#ZipCode");
    // coordinates boxes
    var $lat = $("#locLat input");
    var $lng = $("#locLng input");
    // upload container url action
    var uploadUrl = $('#upload-container').val();
    // PSS objects
    var pssGeocoding = PSS.listings.geocoding;
    var pssmaps = PSS.facilityMap;
    var pssphotomanipulation = PSS.listings.photoManipulation;

    pssphotomanipulation.processPhotoDivs();
    $('#PublicPhotoFileUri').blur(function (ev) {
        var $imgthumb = $('.profileImgThumb');
        $imgthumb.find('img').attr('src', $(this).val());
    });
    // add more image url text boxes
    $('#addmore').click(function () {
        var $last = pssphotomanipulation.getLastHiddenContainer();
    });
    // local upload manager call
    $('a[data-id=uploadmanager]').click(function () {
        var $formarea = $('.formArea.clearfix');
        var ifr = '<iframe id="fileiframe" src="' + uploadUrl + '" />';
        $formarea.children().eq(0).hide();
        $formarea.children().eq(1).attr("class", "");
        $formarea.children().eq(1).append(ifr);
        var $ifr = $('#fileiframe');
        $ifr.height(700);
        $ifr.width($('.formArea.clearfix').width());
        $ifr.load(function () {
            var $ithat = $(this).contents();
            //insert local photos to listing
            $ithat.find('#addtolisting').click(function () {
                var actionPerformed = false;
                $ithat.find('td[class=delete]').each(function (i) {
                    var $checkbox = $(this).find('input[type=checkbox]');
                    if ($checkbox.attr('checked')) {
                        var $button = $(this).find('button');
                        var $last = pssphotomanipulation.getLastHiddenContainer();
                        $last.val($button.attr('data-url'));
                        $last.blur();
                        actionPerformed = true;
                    }
                });
                if (actionPerformed) {
                    $ithat.find('#backtolisting').click();
                }
            });
            // return to listings edit form
            $ithat.find('#backtolisting').click(function () {
                $formarea.children().eq(0).show();
                $formarea.children().eq(1).attr("class", "hidden");
                $('#fileiframe').remove();
            });
            $ithat.find('.btn.setas').click(function () {
                var url = $ithat.find('.modal-image').find('img').attr('src');
                var urlsplit = url.split('/');
                var host = urlsplit[0] + "//" + urlsplit[2] + "/";
                var newurl = "/" + url.replace(host, '');
                $('#PublicPhotoFileUri').val(newurl);
                $('#PublicPhotoFileUri').blur();
                $ithat.find('#backtolisting').click();
            });
        })
    });
    // initialize maps here
    pssmaps.initialize();
    // get coordinates for current address (in textboxes address, city, state and zip)
    $("#btn_listing_geocode").click(function () {
        pssGeocoding.init($address.val(), $city.val(), $state.val(), $zip.val());
        $(window).bind('geocode_complete', function (ev) {
            // show resolved location to user
            showMap();
        });
        $(window).bind('geocode_failed', function (ev) {
            $('#wait').remove();
        });
        pssGeocoding.exportLatLng($lat, $lng);
    });
    // show map for the address stored in database
    pssGeocoding.init($address.val(), $city.val(), $state.val(), $zip.val());
    showMap();

    function showMap() {
        //$('#wait').remove();
        $.removeWait('wait');
        $.createWait('wait').insertBefore('#map_canvas');
        pssmaps.customIconAlt = ICONHOME;
        pssmaps.initializeLatLonBorders();
        var address = {
            address: '',
            title: pssGeocoding.geocodeAddress,
            photo: '',
            facilityGuid: '',
            lat: $lat.val(),
            lng: $lng.val(),
            openInfo: true
        };
        setTimeout(show, 500); // this delay fixes the init zoom bug

        function show() {
            pssmaps.clearMarkers();
            pssmaps.codeAddress(address, pssmaps.calculateZoom);
            //$('#wait').remove();
            $.removeWait('wait');
        }
    }
});