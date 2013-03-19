jQuery(document).ready(function () {
    jQuery("#list").jqGrid({
        url: '/Admin/Listingtype',
        datatype: "json",
        mtype: 'POST',
        colNames: ['ListingTypeGuid', 'ListingTypeName', 'ListingTypePrice',''],
        colModel: [
   		{ name: 'ListingTypeGuid', key: true, index: 'ListingTypeGuid', hidden: true },
   		        { name: 'ListingTypeName', index: 'ListingTypeName', width: 300 , sortable: false, align: "left"},
   		        { name: 'ListingTypePrice', index: 'ListingTypePrice', width: 300, search: true , sortable: false, align: "left"},
		        { name: 'action', index: 'action', width: 200, search: false, sortable: false}
   	        ],
        autowidth:true,
        rowNum: 10,
       // rowList: [10, 20, 30],
        pager: '#pager',
        sortname: 'ListingTypeGuid',
        viewrecords: true,
        sortorder: "desc",
        caption: "Listing Types",
        gridComplete: function () {
            var ids = jQuery("#list").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var cl = ids[i];
                ed = "<input type='button' value='Edit' style='margin-left:50px;' class='jqgrid_444_custombutton_Edit' rel='" + cl + "' />";
                jQuery("#list").jqGrid('setRowData', ids[i], { action: ed });
            }
        },
    });

    jQuery("#list").jqGrid('navGrid', '#pager', { edit: false, add: false, del: false ,search:false});

    
    //Edit Button
    $('body').delegate('.jqgrid_444_custombutton_Edit', 'click', function () {
        var myID = $(this).attr('rel');
        var url = $(this).attr('href');
        var dialog = $('<div id="pop-up-edit" style="display:none"></div>').appendTo('body');
        dialog.load('/Admin/SeeListingType?id=' + myID, {}, function (responseText, textStatus, XMLHttpRequest) {
            dialog.dialog({
                autoOpen: true,
                modal: true,
                height: 'auto',
                width: 'auto',
                close: function (event, ui) {
                    dialog.remove();
                }
            });
        });
        return false;
    });

});


