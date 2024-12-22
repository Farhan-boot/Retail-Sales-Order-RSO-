/*
*    Created By: Shamim Uddin;
*    Create Date: 2-6-2016 (dd-mm-yy); Updated Date: 2-6-2016 (dd-mm-yy);
*    Name: 'itemGroupController';
*    Type: $scope;
*    Purpose: item Group For RND;
*    Service Injected: '$scope', 'ItemGroupService','uiGridConstants';
*/

app.controller('itemGroupController', ['$scope', 'ItemGroupService', 'uiGridConstants',
    function ($scope, ItemGroupService, uiGridConstants) {
        $scope.gridOptionsItemGroups = [];
        var objcmnParam = {};
        var isExisting = 0;
        var page = 1;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;
        var parentID = 0;
        var baseUrl = '/SystemCommon/api/ItemGroup/';
        $scope.btnSaveUpdateText = "Save";
        $scope.PageTitle = 'Create Item Group';
        $scope.ListTitle = 'Item Group  Records';
        $scope.drpPageTitle = 'Item Group List';
        $scope.MenuID = 0;
        $scope.itemGroupes = {};
        var LoginUserID = $('#hUserID').val();
        var LoginCompanyID = $('#hCompanyID').val();
        $scope.ItemGroupID = 0;

        $scope.cIsActive = true;


        $scope.PanelTitle = "Ledger List";

        //$scope.cIsActive = true;
        function LoadItemTypes(isPaging) {

            //$("#isActive").prop('checked', true);        

            var apiRoute = baseUrl + 'GetItemTypes/';
            var itemTypes = ItemGroupService.getAll(apiRoute, page, pageSize, isPaging, LoginCompanyID);
            itemTypes.then(function (response) {
                $scope.ItemTypes = response.data
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        LoadItemTypes(0);

        function loadLedger(isPaging) {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: LoginUserID,
                loggedCompany: LoginCompanyID,
                menuId: 5,
                tTypeId: 25
            };

            var apiRoute = baseUrl + 'GetLedger/';
            var acc1Id = 1;
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(acc1Id) + "]";
            var LedgerList = ItemGroupService.GetList(apiRoute, cmnParam);
            LedgerList.then(function (response) {
                $scope.LedgerList = response.data;

            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadLedger(0);



        //Grid-2
        //Pagination
        $scope.paginationItemPop = {
            paginationPageSizesItemPop: [15, 25, 50, 75, 100, 500, 1000, "All"],
            ddlpageSizeItemPop: 15,
            pageNumber: 1,
            pageSize: 15,
            totalItemsPop: 0,

            getTotalPagesItemPop: function () {
                return Math.ceil(this.totalItemsPop / this.ddlpageSizeItemPop);
            },
            //pageSizeChangeItemPop: function () {
            //    if (this.ddlpageSizeItemPop == "All") {
            //        this.pageNumber = 1
            //        this.pageSize = $scope.paginationItemPop.totalItemsPop;
            //        loadItemPop_Records(1);
            //    }
            //    else {
            //        this.pageSize = this.ddlpageSizeItemPop
            //        this.pageNumber = 1
            //        loadItemPop_Records(1);
            //    }
            //},

            pageSizeChangeItemPop: function () {
                if (this.ddlpageSizeItemPop == "All") {
                    this.pageNumber = 1
                    this.pageSize = 0
                    this.pageSize = $scope.paginationItemPop.totalItemsPop;
                    loadItemPop_Records(1);
                }
                else {
                    this.pageSize = this.ddlpageSizeItemPop
                    this.pageNumber = 1
                    loadItemPop_Records(1);
                }


            },
            firstPageItemPop: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber = 1
                    loadItemPop_Records(1);
                }
            },
            nextPageItemPop: function () {
                if (this.pageNumber < this.getTotalPagesItemPop()) {
                    this.pageNumber++;
                    loadItemPop_Records(1);
                }
            },
            previousPageItemPop: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber--;
                    loadItemPop_Records(1);
                }
            },
            lastPageItemPop: function () {
                if (this.pageNumber >= 1) {
                    this.pageNumber = this.getTotalPagesItemPop();
                    loadItemPop_Records(1);
                }
            }
        };

        //**********----Get All Record----***************
        function loadItemPop_Records(isPaging) {

            // For Loading   
            $scope.loaderMore = true;
            $scope.lblMessageItemPop = 'loading please wait....!';
            $scope.resultItemPop = "color-red";



            //Ui Grid
            objcmnParamItemPop = {
                pageNumber: $scope.paginationItemPop.pageNumber,
                pageSize: $scope.paginationItemPop.pageSize,
                IsPaging: isPaging,
                loggeduser: LoginUserID,
                loggedCompany: LoginCompanyID,
                menuId: 5
              
            };

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsItemPop = {
                columnDefs: [
                    { name: "Id", displayName: "Id", visible: false, headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ACode", displayName: "ACode", width:"20%", headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ACName", displayName: "AC Name", headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Action',
                        displayName: "Action",
                        width: '7%',
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<span class="label label-success label-mini" style="text-align:center !important;">' +
                                     '<a href="" title="Add" ng-click="grid.appScope.GetLedgerByID(row.entity)">' +
                                       '<i class="icon-check" aria-hidden="true"></i> Add' +
                                     '</a>' +
                                     '</span>'
                    }
                ],

                enableFiltering: true,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'Item.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Item", style: 'headerStyle' },
                exporterPdfFooter: function (currentPage, pageCount) {
                    return { text: currentPage.toString() + ' of ' + pageCount.toString(), style: 'footerStyle' };
                },
                exporterPdfCustomFormatter: function (docDefinition) {
                    docDefinition.styles.headerStyle = { fontSize: 22, bold: true };
                    docDefinition.styles.footerStyle = { fontSize: 10, bold: true };
                    return docDefinition;
                },
                exporterPdfOrientation: 'portrait',
                exporterPdfPageSize: 'LETTER',
                exporterPdfMaxGridWidth: 500,
                exporterCsvLinkElement: angular.element(document.querySelectorAll(".custom-csv-link-location")),
            };

            var apiRoute = baseUrl + 'GetLedgerDetail/';
            var cmnParam = "[" + JSON.stringify(objcmnParamItemPop) + "]";
            var LedgerList = ItemGroupService.GetList(apiRoute, cmnParam); 
            LedgerList.then(function (response) {
                $scope.paginationItemPop.totalItemsPop = response.data.recordsTotal;
                $scope.gridOptionsItemPop.data = response.data.objLedger;
                $scope.loaderMore = false;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadItemPop_Records(0);


       
        $scope.GetLedgerByID = function (dataModel) {
           
            $scope.ngmLedger = dataModel.Id;
            $("#ddlLedger").select2("data", { id: dataModel.Id, text: dataModel.ACName });
            Command: toastr["info"]("Ledger Successfully Added.");
            $("#HDOMasterModal").fadeOut(200, function () {
                $('#HDOMasterModal').modal('hide');
            });
        }


        $scope.SetParentText = function () {
            $scope.txtParent = "";
            parentID = 0;
        }

        $scope.LoadParentesByItemType = function () {
            $scope.itemGroupes = {};
            var ItemTypeID = $scope.ddlitemtype;
            var apiRoute = baseUrl + 'GetItemGroupParenteList/';
            if (ItemTypeID != "") {
                var itemGroupes = ItemGroupService.getItemParentesById(apiRoute, page, pageSize, isPaging, ItemTypeID, LoginCompanyID);
                itemGroupes.then(function (response) {
                    console.log(response.data);
                    $scope.itemGroupes = response.data;
                },
                function (error) {
                    console.log("Error: " + error);
                });
            }
            else {
                $scope.itemGroupes = "";
            }
        }
        $scope.save = function () {
           
            var ItemGroup = {
                ItemGroupID: $scope.ItemGroupID,
                ItemGroupName: $scope.ModGroupName,
                CustomCode: $scope.txtbxGroupCode,
                ItemTypeID: $scope.ddlitemtype,
                AcDetailID: $scope.ngmLedger,
                ParentID: (parentID == 0 ? null : parentID),
                IsActive: $scope.cIsActive,
                CompanyID: LoginCompanyID,
                // when save CreateBy Equal CreateBy ang When Update CreateBy Equal UpdatedBy 
                CreateBy: LoginUserID,
                IsDeleted: false
            };
            isExisting = $scope.ItemGroupID;
            if (isExisting == 0) {
                var apiRoute = baseUrl + 'SaveItemGroup/';
                var _saveItemGroup = ItemGroupService.post(apiRoute, ItemGroup);
                _saveItemGroup.then(function (response) {
                    LoadItemGroups(1);
                    ShowCustomToastrMessage(response);

                    $scope.clear();
                }, function (error) {
                    console.log("Error: " + error);
                });
            }
            else {
                var apiRoute = baseUrl + 'UpdateItemGroup/';
                //var cmnParam = "[" + JSON.stringify(ItemGroup) + "]";
                //var rowMaterial = RowMaterialService.GetList(apiRoute, cmnParam);
                var _updateItemGroup = ItemGroupService.post(apiRoute, ItemGroup);
                _updateItemGroup.then(function (response) {
                    LoadItemGroups(1);
                    response.data = -102;
                    ShowCustomToastrMessage(response);

                    $scope.clear();
                },
                function (error) {
                    console.log("Error: " + error);
                });
            }
            modal_fadeOut();
        }
        //Pagination
        $scope.pagination = {
            paginationPageSizes: [15, 25, 50, 75, 100, 500, 1000, "All"],
            ddlpageSize: 15, pageNumber: 1, pageSize: 15, totalItems: 0,
            getTotalPages: function () {
                return Math.ceil(this.totalItems / this.pageSize);
            },
            pageSizeChange: function () {
                if (this.ddlpageSize == "All")
                    this.pageSize = $scope.pagination.totalItems;
                else
                    this.pageSize = this.ddlpageSize
                this.pageNumber = 1
                LoadItemGroups(1);
            },
            firstPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber = 1
                    LoadItemGroups(1);
                }
            },
            nextPage: function () {
                if (this.pageNumber < this.getTotalPages()) {
                    this.pageNumber++;
                    LoadItemGroups(1);
                }
            },
            previousPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber--;
                    LoadItemGroups(1);
                }
            },
            lastPage: function () {
                if (this.pageNumber >= 1) {
                    this.pageNumber = this.getTotalPages();
                    LoadItemGroups(1);
                }
            }
        };
        //*************************************
        //---------Get All Item Group--------//
        //*************************************
        function LoadItemGroups(isPaging) {
            // For Loading
            $scope.loaderMore = true;
            $scope.lblMessage = 'loading please wait....!';
            $scope.result = "color-red";

            //Ui Grid
            objcmnParam = {
                pageNumber: $scope.pagination.pageNumber,
                pageSize: $scope.pagination.pageSize,
                IsPaging: isPaging,
                loggeduser: LoginUserID,
                loggedCompany: LoginCompanyID,
                menuId: 5,
                tTypeId: 25
            };

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };
            $scope.gridOptionsItemGroups = {
                columnDefs: [

                    //{ name: "ItemGroupID", displayName: "Group ID", width: '7%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CustomCode", displayName: "Group Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "Type", title: "Type", headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ItemGroupName", title: "Item Group", headerCellClass: $scope.highlightFilteredHeader },
                    { name: "Parent", title: "Parent Item", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "IsActive", title: "IsActive", width: '10%', headerCellClass: $scope.highlightFilteredHeader, enableFiltering: false, enableSorting: false, },
                    {
                        name: 'Edit',
                        displayName: "Edit",
                        width: '7%',
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<span class="label label-warning label-mini">' +
                                       ' <a ng-href="#GroupModal" data-toggle="modal" class="bs-tooltip" title="Edit Info" ng-click="grid.appScope.getItemGroupForEdit(row.entity)">' +
                                           '<i class="icon-pencil"></i>' +
                                       ' </a>' +
                                   ' </span>' +
                                    '<span class="label label-danger label-mini">' +
                                      '  <a href="#" class="bs-tooltip" title="Delete" ng-click="grid.appScope.delete(row.entity)">' +
                                            '<i class="icon-trash"></i>' +
                                       ' </a>' +
                                   ' </span>'
                    }
                ],
                enableFiltering: true,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'ItemGroupsFile.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Item Groups", style: 'headerStyle' },
                exporterPdfFooter: function (currentPage, pageCount) {
                    return { text: currentPage.toString() + ' of ' + pageCount.toString(), style: 'footerStyle' };
                },
                exporterPdfCustomFormatter: function (docDefinition) {
                    docDefinition.styles.headerStyle = { fontSize: 22, bold: true };
                    docDefinition.styles.footerStyle = { fontSize: 10, bold: true };
                    return docDefinition;
                },
                exporterPdfOrientation: 'portrait',
                exporterPdfPageSize: 'LETTER',
                exporterPdfMaxGridWidth: 500,
                exporterCsvLinkElement: angular.element(document.querySelectorAll(".custom-csv-link-location")),
            };
            //Ui Grid Server Call
            var apiRoute = baseUrl + 'GetAllItemGroups/';
            var itemGroup = ItemGroupService.getAllItemGroups(apiRoute, objcmnParam);
            itemGroup.then(function (response) {
                $scope.pagination.totalItems = response.data.recordsTotal;
                $scope.gridOptionsItemGroups.data = response.data.itemGroups;
                $scope.loaderMore = false;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        //Ui Grid Page Call
        LoadItemGroups(1);
        $scope.clear = function (itemGroupForm) {
            debugger;
            $scope.checkVal = true;
            itemGroupForm.$setPristine();
            itemGroupForm.$setUntouched();
            parentID = 0;
            $scope.groupCode = "";
            $scope.btnSaveUpdateText = "Save";
            $scope.ModGroupName = "";
            $scope.txtbxGroupCode = "";
            LoadItemTypes(0);
            $scope.ItemGroupID = "";
            $("#ddlItemGroup").select2("data", { id: 0, text: '-- Select Parent --' });
            $scope.ddlitemtype = "";
            $scope.LoadParentesByItemType();
            $("#ddlitemtype").select2("data", { id: 0, text: '-- Select Item Type --' });
            $("#isActive").prop('checked', false); // Unchecks the box

            $scope.ngmLedger = "";
            $("#ddlLedger").select2("data", { id: '', text: '-- Select Ledger --' });

            loadLedger(0);
        }
        $scope.delete = function (dataModel) {
            var IsConf = confirm('You are about to delete ' + dataModel.ItemGroupName + '. Are you sure?');
            if (IsConf) {

                var apiRoute = baseUrl + 'DeleteItemGroup/';
                var deleteConsumption = ItemGroupService.put(apiRoute, dataModel);
                deleteConsumption.then(function (response) {
                    response.data = -101;
                    ShowCustomToastrMessage(response);
                    $scope.clear();
                    LoadItemGroups(1);
                }, function (error) {
                    console.log("Error: " + error);
                });
            }
        }
        $scope.getItemGroupForEdit = function (dataModel) {

            if (dataModel.AcDetailID != null) {
                $scope.ngmLedger = dataModel.AcDetailID;
                $("#ddlLedger").select2("data", { id: dataModel.AcDetailID, text: dataModel.ACName });
            }

            var apiRoute = baseUrl + 'GetItemGroupById/';
            var singleitemGroup = ItemGroupService.getItemGroupByID(apiRoute, dataModel.ItemGroupID, LoginCompanyID);
            singleitemGroup.then(function (response) {
                $scope.ItemGroupID = response.data.ItemGroupID;
                $scope.ModGroupName = response.data.ItemGroupName;
                $scope.txtParent = response.data.ParentName;              
                parentID = response.data.ParentID;
                $scope.ddlitemtype = response.data.TypeId;
                $scope.txtbxGroupCode = response.data.CustomCode;
                $scope.groupCode = response.data.CustomCode;
                $scope.SetDrpdwn(response);
                $scope.LoadParentesByItemType();

            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.SetDrpdwn = function (response) {
            $scope.btnSaveUpdateText = "Update";
            if (response.data.Type != 'N/A') {
                $("#ddlitemtype").select2("data", { id: 0, text: response.data.Type });
            } else {
                $("#ddlitemtype").select2("data", { id: 0, text: '-- Select Item Type --' });
            }

            if (response.data.IsActive == "YES") {
                $scope.checkVal = true;

            } else {
                $scope.checkVal = false;
            }
        }
        $scope.selectNode = function (val) {
            $scope.txtParent = val.Name;
            parentID = val.ID;
            $scope.GetLedgerByParentID(val.ID);

        }
        $scope.treedubbleClick = function (val) {
            $scope.txtParent = val.Name;
            parentID = val.ID;
            //  $scope.getMaxByParentID(val);
            modal_fadeOutTree();
        }


        $scope.GetLedgerByParentID = function (val) {
            var patentID = val.ID;
            var apiRoute = baseUrl + 'GetLedgerByParentID/';
            var itemGroup = ItemGroupService.getItemGroupByID(apiRoute, val, LoginCompanyID);
            itemGroup.then(function (response) {
                $scope.ngmLedger = response.data.AcDetailID;
                $("#ddlLedger").select2("data", { id: response.data.AcDetailID, text: response.data.ACName });
                //if (response.data.ParentID != null)
                //{
                //    $scope.Isdisable = true;
                //}
                //else
                //{
                //    $scope.Isdisable = false;
                //}
            },
            function (error) {
                console.log("Error: " + error);
            });

        }

        $scope.getMaxByParentID = function (val) {
            var patentID = val.ID;
            var apiRoute = baseUrl + 'GetMaxByParentID/';
            var itemGroup = ItemGroupService.getItemGroupByID(apiRoute, patentID, LoginCompanyID);
            itemGroup.then(function (response) {

                $scope.txtbxGroupCode = response.data;
                alert(response.data);

            },
            function (error) {
                console.log("Error: " + error);
            });

        }


        $scope.CheckGroupCode = function () {

            var ItemGroup = {
                ItemGroupID: $scope.ItemGroupID,
                ItemGroupName: $scope.ModGroupName,
                CustomCode: $scope.txtbxGroupCode,
                ItemTypeID: $scope.ddlitemtype,
                AcDetailID: $scope.ngmLedger,
                ParentID: (parentID == 0 ? null : parentID),
                IsActive: $scope.cIsActive,
                CompanyID: LoginCompanyID,
                // when save CreateBy Equal CreateBy ang When Update CreateBy Equal UpdatedBy 
                CreateBy: LoginUserID,
                IsDeleted: false
            };
           
            if ($scope.groupCode != $scope.txtbxGroupCode) {
                var apiRoute = baseUrl + 'CheckItemGroupCode/';
                var itemGroup = ItemGroupService.checkedItemGroupCode(apiRoute, ItemGroup);
                itemGroup.then(function (response) {

                    if (response.data === 1) {
                        Command: toastr["warning"]($scope.txtbxGroupCode + " " + "This group Code already existing");
                        $scope.txtbxGroupCode = "";
                    }


                },
                function (error) {
                    console.log("Error: " + error);
                });

            }
        }


    }]);
function modal_fadeOut() {
    $("#GroupModal").fadeOut(200, function () {
        $('#GroupModal').modal('hide');
    });
}

function modal_fadeOutTree() {
    $("#drpModal").fadeOut(200, function () {
        $('#drpModal').modal('hide');
    });
}