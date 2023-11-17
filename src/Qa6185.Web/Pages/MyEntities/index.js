$(function () {
    var l = abp.localization.getResource("Qa6185");
	
	var myEntityService = window.qa6185.myEntities.myEntities;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "MyEntities/CreateModal",
        scriptUrl: abp.appPath + "Pages/MyEntities/createModal.js",
        modalClass: "myEntityCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "MyEntities/EditModal",
        scriptUrl: abp.appPath + "Pages/MyEntities/editModal.js",
        modalClass: "myEntityEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            name: $("#NameFilter").val(),
			property2: $("#Property2Filter").val()
        };
    };
    
    //<suite-custom-code-block-1>
    //</suite-custom-code-block-1>

    var dataTable = $("#MyEntitiesTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(myEntityService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Qa6185.MyEntities.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Qa6185.MyEntities.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    myEntityService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reloadEx();;
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "name" },
			{ data: "property2" }
        ]
    }));
    
    //<suite-custom-code-block-2>
    //</suite-custom-code-block-2>

    createModal.onResult(function () {
        dataTable.ajax.reloadEx();;
    });

    editModal.onResult(function () {
        dataTable.ajax.reloadEx();;
    });

    $("#NewMyEntityButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reloadEx();;
    });

    $("#ExportToExcelButton").click(function (e) {
        e.preventDefault();

        myEntityService.getDownloadToken().then(
            function(result){
                    var input = getFilter();
                    var url =  abp.appPath + 'api/app/my-entities/as-excel-file' + 
                        abp.utils.buildQueryString([
                            { name: 'downloadToken', value: result.token },
                            { name: 'filterText', value: input.filterText }, 
                            { name: 'name', value: input.name }, 
                            { name: 'property2', value: input.property2 }
                            ]);
                            
                    var downloadWindow = window.open(url, '_blank');
                    downloadWindow.focus();
            }
        )
    });

    $('#AdvancedFilterSectionToggler').on('click', function (e) {
        $('#AdvancedFilterSection').toggle();
    });

    $('#AdvancedFilterSection').on('keypress', function (e) {
        if (e.which === 13) {
            dataTable.ajax.reloadEx();;
        }
    });

    $('#AdvancedFilterSection select').change(function() {
        dataTable.ajax.reloadEx();;
    });
    
    //<suite-custom-code-block-3>
    //</suite-custom-code-block-3>
    
    
});
