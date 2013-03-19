/// <reference path="../../Scripts/jquery-1.5.1-vsdoc.js" />

$(document).ready(function () {
    var $geoloc = $('#geolocready');
    // check if geolocation is submitted to server
    if ($geoloc.val() == 'WaitingForResolve') {
        // show wait indicator
        // dim screen and inform user about geolocation process
        $('body').prepend('<h2 id="wait" style="background-color: Red; color: White; text-align: center;">Getting your location. Please, wait...</h2>');
        var pssmaps = PSS.facilityMap;
        pssmaps.initializeGeocoder();
        pssmaps.getBrowserGeolocation(function () { pssmaps.extractCityStateZip(); });
        $(window).bind('geolocation_ready', function (e, citystatezip) {
            //alert(pssmaps.browserLocation.lat);
            //alert("City:" + citystatezip.city + " State: " + citystatezip.state + " Zip: " + citystatezip.zip);
            $('#wait').css('background-color', 'Green').text('Redirecting...');
            setTimeout(Redirect, 1000);
            function Redirect() {
                window.location = 'search?city=' + citystatezip.city + '&state=' + citystatezip.state +
                            '&zip=' + citystatezip.zip +
                            "&latitude=" + pssmaps.browserLocation.lat + "&longitude=" + pssmaps.browserLocation.lng;
            }
        });

    }
    $('#eldercarenearyou').appendTo('#oform');
});