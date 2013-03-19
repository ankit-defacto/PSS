/// <reference path="../../Scripts/jquery-1.5.1-vsdoc.js" />

$(document).ready(function () {
    $actionlink = $('#widesearch > a');
    var $city = $("#cityfilter");
    var $state = $("#statefilter");
    var $zip = $("#zipfilter");
    var $lat = $("#hidden_lat");
    var $lng = $("#hidden_lng");
    // action part
    // hide the link - it is not ready with coordinates
    $actionlink.css('display', 'none');
    // wait for geocoding event
    $(window).bind('geocode_complete', function () {
        // add coordinates to link
        var oldhref = $actionlink.attr('href');
        oldhref = $.replaceQueryStringValue(oldhref, "latitude", $lat.val());
        oldhref = $.replaceQueryStringValue(oldhref, "longitude", $lng.val());
        $actionlink.attr('href', oldhref);
        // show link
        $actionlink.css('display', 'block');
    });
    // start geocoding
    var pssGeocoding = PSS.listings.geocoding;
    pssGeocoding.init('', $city.val(), $state.val(), $zip.val());
    pssGeocoding.exportLatLng($lat, $lng);
});