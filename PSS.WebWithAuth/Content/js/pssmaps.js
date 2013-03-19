/// <reference path="../../Scripts/jquery-1.5.1-vsdoc.js" />

// main object
var PSS = PSS || {};

// handles geocoding in PSS
PSS.facilityMap = {
    customIcon: PSS.ICONHOME
    , customIconAlt: PSS.ICONARROW
    , GLOBE_WIDTH: 256 // a constant in Google's map projection
    , geocoder: null // google maps Geocoder object
    , map: null // Map object
    , LatLonBorders: { // should be tuned later
        maxLon: -170
        , minLon: 170
        , maxLat: -85
        , minLat: 85
    }
    // user's browser coordinates
    , browserLocation: { lat: null, lng: null }
    , activeResultCssClass: 'resultactive'
    , markersArray: []
    , initializeLatLonBorders: function () {
        this.LatLonBorders = { maxLon: -170, minLon: 170, maxLat: -85, minLat: 85 };
    }
    , initializeGeocoder: function () {
        this.geocoder = new google.maps.Geocoder();
    }
    , initialize: function () {
        this.initializeLatLonBorders();
        this.initializeGeocoder();
        var latlng = new google.maps.LatLng(47.37, 122.19);
        var mapOptions = {
            zoom: 8,
            maxZoom: 16,
            center: latlng,
            scrollwheel: false,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        this.map = new google.maps.Map(document.getElementById('map_canvas'), mapOptions);
    }
    , clearMarkers: function () {
        var that = this;
        if (that.markersArray) {
            for (var i = 0; i < that.markersArray.length; i++) {
                that.markersArray[i].setMap(null);
            }
            that.markersArray.length = 0;
        }
    }
    , createMarker: function (lat, lng, title, icon) {
        var that = this;
        if (typeof lat !== 'undefined' && typeof lng !== 'undefined') {
            var marker = new google.maps.Marker({
                title: title,
                map: that.map,
                position: new google.maps.LatLng(lat, lng),
                icon: icon
            });
            that.markersArray.push(marker);
            return marker;
        }
    }
    // uses navigator
    , getBrowserGeolocation: function (callback) {
        var that = this;
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                that.browserLocation.lat = position.coords.latitude;
                that.browserLocation.lng = position.coords.longitude;
                callback();
            },
            function (error) {
                alert("Get current position failed: " + error);
            },
            {
                maximumAge: 60000,
                timeout: 20000,
                enableHighAccuracy: true
            }
            );
        }
        else {
            alert('Geolocation services are not supported by your browser');
            return null;
        }
    }
    , putBrowserGeolocation: function () {
        var that = this;
        var glocation = that.browserLocation;
        if (glocation.lat != null && glocation.lng != null) {
            var marker = that.createMarker(glocation.lat, glocation.lng, 'Your location', that.customIconAlt);
            that.trackMaxMin(glocation.lat, glocation.lng);
        }
    }
    , extractCityStateZip: function () {
        var that = this;
        var geocoder = that.geocoder;
        var glocation = that.browserLocation;

        if (glocation.lat != null && glocation.lng != null) {
            var latlng = new google.maps.LatLng(glocation.lat, glocation.lng);
            geocoder.geocode({ 'latLng': latlng }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    if (results[0]) {
                        result = results[0].address_components;
                        var citystatezip = {};
                        for (var i = 0; i < result.length; ++i) {
                            if (result[i].types[0] == "administrative_area_level_1") { citystatezip.city = result[i].short_name; }
                            if (result[i].types[0] == "locality") { citystatezip.state = result[i].long_name; }
                            if (result[i].types[0] == "postal_code") { citystatezip.zip = result[i].long_name; }
                        }
                        citystatezip.zip = typeof citystatezip.zip === 'undefined' ? "" : citystatezip.zip;
                        $(window).trigger('geolocation_ready', citystatezip);
                        //alert("City:" + citystatezip.city + " State: " + citystatezip.state + " Zip: " + citystatezip.zip);
                    }
                    else {
                        alert('No results found');
                    }
                }
                else {
                    alert('Geocoder failed due to: ' + status);
                }
            });
        }
    }
    , codeAddressSimple: function (address, $inputLat, $inputLng) {
        var that = this;
        var map = that.map;
        var geocoder = that.geocoder;
        var latlng = new google.maps.LatLng(0, 0);
        geocoder.geocode({ 'address': address }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                //console.log(results[0].geometry.location.lat());
                latlng = results[0].geometry.location;
                $inputLat.val(latlng.lat());
                $inputLng.val(latlng.lng());
                $(window).trigger('geocode_complete');
            }
            else {
                alert('Geocode was not successful for the following reason: ' + status);
                $(window).trigger('geocode_failed');
            }
        });
    }
    , codeAddress: function (address, callback) {
        var that = this;
        var map = that.map;
        var geocoder = that.geocoder;
        // plamen: important! the link below is extracted from the parent view and must be present there
        var $detailsLink = $('#' + address.facilityGuid);
        // add coordinates if present otherwise try to resolve by geocoding
        if (address.lat == 0 && address.lng == 0) { // try to resolve the address
            geocoder.geocode({ 'address': address.address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    var position = results[0].geometry.location;
                    var marker = that.createMarker(position.lat(), position.lng(), address.title, that.customIcon);
                    marker.setOptions({ position: results[0].geometry.location });
                    // store the point for later calculations
                    that.trackMaxMin(marker.position.lat(), marker.position.lng());
                    that.addListeners(marker, address, $detailsLink);
                } else { // inform user for failed geocodings
                    //alert('Geocode was not successful for the following reason: ' + status);
                    var cellcurrent = that.getResultBox($detailsLink);
                    //insert message below the title      
                    cellcurrent.prepend('<li><span style="background-color: Red;">Geocoder failed to resolve this address</span></li>');
                }
                if (callback && typeof callback === "function") {
                    callback();
                }
            });
        }
        else { // coordinates are stored in database
            var marker = that.createMarker(address.lat, address.lng, address.title, that.customIcon);
            that.trackMaxMin(marker.position.lat(), marker.position.lng());
            that.addListeners(marker, address, $detailsLink);
            callback();
        }
    }
    , addListeners: function (marker, address, $detailsLink) {
        var that = this;
        var map = that.map;
        var contentString = '<div style="height: 100px; width: 280px;"><div style="font-weight: bold;">' +
                            address.title + '</div><div>' + address.address + '</div>';
        // gets the result entry Details link
        if (typeof $detailsLink[0] !== 'undefined') {
            contentString += '<img height="40px" style="max-width: 70px;" src="' + address.photo + '" alt="" />&nbsp;' + $detailsLink[0].outerHTML;
            //contentString += '<div>' + $detailsLink[0].outerHTML + '</div>';
        }
        else {
            marker.setIcon(that.customIconAlt);
        }
        contentString += '</div>';
        var infowindow = new google.maps.InfoWindow({
            content: contentString,
            maxWidth: 280
        });
        // add info window on click
        google.maps.event.addListener(marker, 'click', function () {
            infowindow.open(map, marker);
            $('html, body').animate({
                scrollTop: $detailsLink.offset().top - 100
            }, 1000);
        });
        // highlight listing entry on marker hover                
        google.maps.event.addListener(marker, 'mouseover', function () {
            that.highlightResult($detailsLink, true);
        });
        google.maps.event.addListener(marker, 'mouseout', function () {
            that.highlightResult($detailsLink, false);
        });
        if (address.openInfo) {
            infowindow.open(map, marker);
        }
    }
    , decodeHtml: function (encoded) {
        return $('<div />').html(encoded).text();
    }
    // gets <li> item which contains the details link
    , getResultBox: function ($detailsLink) {
        return $detailsLink.parents().eq(2);
    }
    // row highlighting on marker hover
    , highlightResult: function ($detailsLink, highlight) {
//        var csscls = this.activeResultCssClass;
//        var $cellhl = this.getResultBox($detailsLink);
//        var originalcls = $cellhl.attr('class');
//        //if (typeof originalcls === undefined) originalcls = '';
//        if (highlight) {
//            $cellhl.attr('class', csscls);
//        }
//        else {
//            $cellhl.attr('class', originalcls);
//        }
    }
    // track lat/lng values on each codeAddress call
    , trackMaxMin: function (lat, lng) {
        var lnbrd = this.LatLonBorders;
        // track min for lat/lon
        lnbrd.minLat = Math.min(lnbrd.minLat, lat);
        lnbrd.minLon = Math.min(lnbrd.minLon, lng);
        // track max for lat/lon
        lnbrd.maxLat = Math.max(lnbrd.maxLat, lat);
        lnbrd.maxLon = Math.max(lnbrd.maxLon, lng);
        //console.log(lnbrd.maxLat + '#' + lnbrd.minLat + '|' + lnbrd.maxLon + '#' + lnbrd.minLon);
    }
    // determine best zoom level and center map
    , calculateZoom: function () {
        var that = PSS.facilityMap;
        var map = that.map;
        var lnbrd = that.LatLonBorders;
        // calculate map boundaries
        var west = lnbrd.minLon;
        var east = lnbrd.maxLon;
        var north = lnbrd.maxLat;
        var south = lnbrd.minLat;
        var angle = east - west;
        var angle2 = north - south;
        //var delta = 0;
        //var horizontal = false;
        if (angle2 > angle) {
            angle = angle2;
            //delta = 3;
        }
        if (angle < 0) {
            angle += 360;
        }
        if (angle == 0) { // protect map in case of one result (zoomfactor infinity)
            map.setCenter(new google.maps.LatLng(lnbrd.minLat, lnbrd.minLon));
            // one result is tracked, we can increase zoom factor
            map.setZoom(12);
        }
        else {
            // another zoom factor calculation method, gives smaller values
            //zoomfactor = Math.floor(Math.log(340 * 360 / angle / GLOBE_WIDTH) / Math.LN2) - 2 - delta;
            var zoomfactor = Math.round(Math.log(300 * 300 / angle / that.GLOBE_WIDTH) / Math.LN2) - 1;
            //console.log(zoomfactor);
            map.setZoom(zoomfactor);
            // after zoom factor setup center the map 
            var sw = new google.maps.LatLng(south, west);
            var ne = new google.maps.LatLng(north, east);
            var bounds = new google.maps.LatLngBounds(sw, ne);
            map.setCenter(bounds.getCenter());
        }
    }
}