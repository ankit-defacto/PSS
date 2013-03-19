jQuery(document).ready(function () {

    prmSearch = { multipleSearch: false, overlay: false, sopt: ["eq", "ne", "bw", "bn", "ew", "en", "cn", "nc"] };

    jQuery("#list").jqGrid({
        url: '/Admin/ClientGrid',
        datatype: "json",
        mtype: 'POST',
        colNames: ['ClientGuid', 'Flagged', 'Client Name', 'Address Details', 'Email', 'Waiverd', 'Free Days', 'Credits', 'Suspended', 'Account Paused', ''],
        colModel: [
   		        { name: 'ClientGuid', key: true, index: 'ClientGuid', hidden: true },
		        { name: 'IsFlagged', index: 'IsFlagged', width: 20, search: false, sortable: true },
   		        { name: 'ClientName', index: 'ClientName', width: 90 },
   		        { name: 'Address', index: 'Address', width: 135, search: true },
   		        { name: 'Email', index: 'Email', width: 100, align: "center", search: true },
   		        { name: 'IsWaiverd', index: 'IsWaiverd', width: 40, align: "center", search: true },
   		        { name: 'FreeDays', index: 'FreeDays', width: 40, align: "center", search: true },
   		        { name: 'AccountBalance', index: 'AccountBalance', width: 50, align: "center", search: true },
   		        { name: 'IsSuspended', index: 'IsSuspended', width: 40, align: "center", search: true },
   		        { name: 'PauseAccount', index: 'PauseAccount', width: 50, search: true, sortable: true },
		        { name: 'action', index: 'action', width: 120, search: false, sortable: false }
   	        ],
        autowidth: true,
        height: '100%',
        shrinkToFit: true,
        scrollOffset: 0,
        rowNum: 10,
        rowList: [10, 20, 50, 100],
        pager: '#pager',
        sortname: 'ClientGuid',
        viewrecords: true,
        sortorder: "desc",
        multiselect: true,
        gridComplete: function () {
            var ids = jQuery("#list").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var cl = ids[i];
                fl = "<img alt='x' style='height:20px; width:14px; margin:3px 0 0 5px;' src='../../Content/img/RedFlag.gif' class='" + jQuery("#list").getCell(cl, 2) + "' title='Client Account Suspended' />";
                jQuery("#list").jqGrid('setRowData', ids[i], { IsFlagged: fl });
                ed = "<input type='button' value='Edit' class='jqgrid_444_custombutton_Edit' rel='" + cl + "' />";
                de = "<input type='button' value='Delete' class='jqgrid_444_custombutton_Delete' rel='" + cl + "' />";
                //ac = "<input type='button' id='id_paused' value='" + jQuery("#list").getCell(cl, 'PauseAccount') + "' class='jqgrid_444_custombutton_Paused " + jQuery("#list").getCell(cl, 'PauseAccount') + "' rel='" + cl + "' />";
                jQuery("#list").jqGrid('setRowData', ids[i], { action: ed + de });
            }
        },
        caption: "Account List",
        toppager: true
    });
    jQuery("#list").jqGrid('navGrid', '#pager', { cloneToTop: true, add: false, edit: false, del: false, search: true, refresh: true }, {}, {}, {}, prmSearch);

    // Multiserach toolbar
    jQuery("#list").searchGrid(prmSearch);

    var searchDialog = $("#searchmodfbox_" + jQuery("#list")[0].id);
    searchDialog.addClass("ui-jqgrid ui-widget ui-widget-content ui-corner-all");
    searchDialog.css({ position: "relative", "z-index": "auto", "float": "left" })
    var gbox = $("#gbox_" + jQuery("#list")[0].id);
    gbox.before(searchDialog);
    gbox.css({ clear: "left" });

    //Add new toolbar with new buttons on top of jqgrid
    jQuery("#list").jqGrid('navButtonAdd', "#list_toppager_left", { caption: "New", buttonicon: "ui-icon ui-icon-add ", id: "toolbar_new", onClickButton: null, position: "last", title: "", cursor: "pointer" });
    jQuery("#list").jqGrid('navButtonAdd', "#list_toppager_left", { caption: "Delete", buttonicon: "ui-icon ui-icon-trash ", id: "toolbar_deleteAll", onClickButton: null, position: "last", title: "", cursor: "pointer" });
    jQuery("#list").jqGrid('navButtonAdd', "#list_toppager_left", { caption: "Activate", buttonicon: "ui-icon ui-icon-trash ", id: "toolbar_activate", onClickButton: null, position: "last", title: "", cursor: "pointer" });
    jQuery("#list").jqGrid('navButtonAdd', "#list_toppager_left", { caption: "De-Activate", buttonicon: "ui-icon ui-icon-trash ", id: "toolbar_deActivate", onClickButton: null, position: "last", title: "", cursor: "pointer" });
    jQuery("#list").jqGrid('navButtonAdd', "#list_toppager_left", { caption: "Suspend Account", buttonicon: "ui-icon ui-icon-trash ", id: "toolbar_suspendAccount", onClickButton: null, position: "last", title: "", cursor: "pointer" });
    jQuery("#list").jqGrid('navButtonAdd', "#list_toppager_left", { caption: "Continue Account", buttonicon: "ui-icon ui-icon-trash ", id: "toolbar_continueAccount", onClickButton: null, position: "last", title: "", cursor: "pointer" });
    jQuery("#list").jqGrid('navButtonAdd', "#list_toppager_left", { caption: "Change Facility Price", buttonicon: "ui-icon ui-icon-trash ", id: "toolbar_setFacilityPrice", onClickButton: null, position: "last", title: "", cursor: "pointer" });

    var topPagerDiv = $("#list_toppager")[0];
    $("#edit_list_top", topPagerDiv).remove();
    $("#del_list_top", topPagerDiv).remove();
    $("#search_list_top", topPagerDiv).remove();
    $("#refresh_list_top", topPagerDiv).remove();
    $("#list_toppager_center", topPagerDiv).remove();
    $(".ui-paging-info", topPagerDiv).remove();

    var bottomPagerDiv = $("div#pager")[0];
    $("#add_list", bottomPagerDiv).remove();

    //Add New Button call New Action
    jQuery("#toolbar_new").click(function () {
        var url = $(this).attr('href');
        var dialog = $('<div id="pop-up-create" style="display:none"></div>').appendTo('body');
        dialog.load('/Admin/Create', {}, function (responseText, textStatus, XMLHttpRequest) {
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

    //get selected rows on DeleteAll Button
    jQuery("#toolbar_deleteAll").click(function () {
        var id = jQuery("#list").jqGrid('getGridParam', 'selarrrow');
        if (id == null || id == "")
            alert("Check Row to Delete Accounts");
        else {
            if (confirm("Are you sure you want to delete this?")) {
                doWork("/Admin/DeleteAccount", id, "");
            }
            return false;
        }
    });

    //get selected rows on Activate Button
    jQuery("#toolbar_activate").click(function () {
        var id = jQuery("#list").jqGrid('getGridParam', 'selarrrow');
        if (id == null || id == "")
            alert("Check Row to Activate Accounts");
        else
            doWork("/Admin/PauseAccount", id, "ac");
    });

    //get selected rows on De-Activate Button
    jQuery("#toolbar_deActivate").click(function () {
        var id = jQuery("#list").jqGrid('getGridParam', 'selarrrow');
        if (id == null || id == "")
            alert("Check Row to Deactivate Accounts");
        else
            doWork("/Admin/PauseAccount", id, "de");
    });

    //get selected rows on Suspend Account Button
    jQuery("#toolbar_suspendAccount").click(function () {
        var id = jQuery("#list").jqGrid('getGridParam', 'selarrrow');
        if (id == null || id == "")
            alert("Check Row to Suspend Accounts");
        else {
            doWork("/Admin/SuspendAccount", id, "su");
        }
    });

    //get selected rows on Continue Account Button
    jQuery("#toolbar_continueAccount").click(function () {
        var id = jQuery("#list").jqGrid('getGridParam', 'selarrrow');
        if (id == null || id == "")
            alert("Check Row to Continue Accounts");
        else
            doWork("/Admin/SuspendAccount", id, "cn");
    });

    //Edit Button
    $('body').delegate('.jqgrid_444_custombutton_Edit', 'click', function () {
        var myID = $(this).attr('rel');
        var url = $(this).attr('href');
        document.location = '/Admin/ClientAccount?clientGuid=' + myID;
        //        var dialog = $('<div id="pop-up-edit" style="display:none"></div>').appendTo('body');
        //        dialog.load('/Admin/See?id=' + myID, {}, function (responseText, textStatus, XMLHttpRequest) {
        //            dialog.dialog({
        //                autoOpen: true,
        //                modal: true,
        //                height: 'auto',
        //                width: 'auto',
        //                close: function (event, ui) {
        //                    dialog.remove();
        //                }
        //            });
        //        });
        //        return false;
    });

    //Delete Button
    $('body').delegate('.jqgrid_444_custombutton_Delete', 'click', function () {
        var id = $(this).attr('rel');
        if (confirm("Are you sure you want to delete this?")) {
            doWork("/Admin/DeleteAccount", id, "");
        }
        return false;
    });

    //Account Pasued(Activate Deactivate) Button
    $('body').delegate('.jqgrid_444_custombutton_Paused', 'click', function () {
        var id = $(this).attr('rel');
        doWork("/Admin/PauseAccount", id, "ck");
    });

    //Change Facility price on one click


    //Add New Button call New Action
    jQuery("#toolbar_setFacilityPrice").click(function () {
        var id = jQuery("#list").jqGrid('getGridParam', 'selarrrow');
        if (id == null || id == "")
            alert("Check Row to Change Client's Facility Price");
        else {
            var dialog = $('<div id="pop-up-create" style="display:none"></div>').appendTo('body');
            dialog.load('/Admin/FaciltyPrice', {}, function (responseText, textStatus, XMLHttpRequest) {
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
        }
    });



});

function doWork(Url, id, type) {
    $.ajax({
        type: "POST",
        url: Url,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({
            'id': id.toString().split(','),
            'type': type
        }),
        success: function (result) {
            $("#list").trigger("reloadGrid");
            alert(result);
        },
        error: function (result) {
            alert('Oh no: ' + result.responseText);
        }
    });
}