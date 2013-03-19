/*
 * jQuery File Upload Plugin JS Example 6.5.1
 * https://github.com/blueimp/jQuery-File-Upload
 *
 * Copyright 2010, Sebastian Tschan
 * https://blueimp.net
 *
 * Licensed under the MIT license:
 * http://www.opensource.org/licenses/MIT
 */

/*jslint nomen: true, unparam: true, regexp: true */
/*global $, window, document */

$(function () {
    'use strict';

    // Initialize the jQuery File Upload widget:
    $('#fileupload').fileupload();

    $('#fileupload').fileupload('option', {
        maxFileSize: 1000000,
        resizeMaxWidth: 1920,
        resizeMaxHeight: 1200
    });

    // Enable iframe cross-domain access via redirect option:
    //    $('#fileupload').fileupload(
    //    'option',
    //    'redirect',
    //        window.location.href.replace(
    //            /\/[^\/]*$/,
    //            '/cors/result.html?%s'
    //        )
    //    );

    $.createWait('wait').appendTo('.row.fileupload-buttonbar:last');
    // Load existing files:
    $.ajax({
        // Uncomment the following to send cross-domain cookies:
        //xhrFields: {withCredentials: true},
        //$('#fileupload').fileupload('option', 'url'),
        url: localUrl,
        dataType: 'json',
        context: $('#fileupload')[0]
    }).done(function (result) {
        $.removeWait('wait');
        $(this).fileupload('option', 'done').call(this, null, { result: result });
    });
});
