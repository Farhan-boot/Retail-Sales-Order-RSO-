/**
 * TargetItemSettingsCtrl.js
 */

app.controller('TargetItemSettingsCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {
        var baseUrl = DirectoryKey +'/SFTS/api/TargetItemSetting/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.IsCreateIcon = false;
        $scope.IsListIcon = true;
        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Show List";

        $scope.PageTitle = 'Add New Target Item';
        $scope.ListTitle = 'Target Item List';


        $scope.gridOptionsTargetItemSettings = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;
        $scope.IsHiddenDetail = true;
        $scope.ShowHide = function () {
            $scope.IsHidden = $scope.IsHidden == true ? false : true;
            $scope.IsHiddenDetail = true;
            if ($scope.IsHidden == true) {
                $scope.btnShowText = "Show List";
                $scope.IsShow = true;

                $scope.IsCreateIcon = false;
                $scope.IsListIcon = true;
                $scope.clear();
            }
            else {
                $scope.btnShowText = "Create";
                $scope.btnSaveText = "Save";
                $scope.PageTitle = 'Existing Target Items';
                $scope.IsShow = false;
                $scope.IsHidden = false;

                $scope.IsCreateIcon = true;
                $scope.IsListIcon = false;
                loadAllTargetItem(0);
            }
        }

        function CommonEntity() {
            $scope.HeaderToken = $scope.tokenManager.generateSecurityToken();
            $scope.loggedUserId = $scope.loggedUserManager.loggedUser();
        }
        CommonEntity();

        var IsPermitted = false;
        function GetPermission(code) {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: code
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted != true) {
                    window.location.href = DirectoryKey + "/SFTS/NoPermission";
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        GetPermission('01601');

        //**********----Pagination----***************
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
                loadCustomerRecords(1);
            },
            firstPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber = 1
                    loadCustomerRecords(1);
                }
            },
            nextPage: function () {
                if (this.pageNumber < this.getTotalPages()) {
                    this.pageNumber++;
                    loadCustomerRecords(1);
                }
            },
            previousPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber--;
                    loadCustomerRecords(1);
                }
            },
            lastPage: function () {
                if (this.pageNumber >= 1) {
                    this.pageNumber = this.getTotalPages();
                    loadCustomerRecords(1);
                }
            }
        };
        //  }


        //**********----Get Entity Types ----***************
        function loadEntityTypes(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                CenterTypeId: 0,
                //loggeduser: $scope.loggedUserId,                             
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetTargetItemEntityTypes/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listEntityTypes = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listEntityTypes.then(function (response) {
                $scope.listEntityType = response.data.objTargetEntityType;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadEntityTypes(0);

        //**********----Get Staff Type ----***************
        function loadRoles(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RoleId: 0,
                //loggeduser: $scope.loggedUserId,                         
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetRoles/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRoles = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRoles.then(function (response) {
                $scope.listRole = response.data.objListRole;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadRoles(0);


        //**********----Get Center Types ----***************
        function loadCenterTypes(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                CenterTypeId: 0,
                //loggeduser: $scope.loggedUserId,                             
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetCenterTypes/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listCenterTypes = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listCenterTypes.then(function (response) {
                $scope.listCenterType = response.data.objListCenterType;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadCenterTypes(0);

        //**********----Get Channel Types ----***************
        function loadChannelTypes(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                CenterTypeId: 0,
                //loggeduser: $scope.loggedUserId,                             
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetChannelType/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listChannelTypes = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listChannelTypes.then(function (response) {
                $scope.listChennelType = response.data.objListChennelType;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadChannelTypes(0);

        $scope.TdShowHide = function (dataModel) {
            var entityType = dataModel.Entity;

            if (entityType == 1) {
                dataModel.IsCenterDisabled = true;
                dataModel.IsStaffDisabled = false;
                dataModel.CenterType = "";
            }
            else if (entityType == 3) {
                dataModel.IsStaffDisabled = true;
                dataModel.IsCenterDisabled = false;
                dataModel.StaffRole = "";
            }
            else {
                dataModel.IsStaffDisabled = true;
                dataModel.IsCenterDisabled = true;
                dataModel.StaffRole = "";
                dataModel.CenterType = "";
            }
        }

        $scope.ListItemtDetails = [];
        $scope.ListItemtDetails.push({ FirstRow: null });
        $scope.AddItemToList = function () {
            $scope.ListItemtDetails.push({});

        }

        $scope.DeleteRow = function (index) {
            if (index == 0) {
                alert("First row can not be deleted!");
                return;
            }
            $scope.ListItemtDetails.splice(index, 1);
        }


        //**********----Get All Customer Records----***************
        function loadAllTargetItem(isPaging) {
            $scope.gridOptionsTargetItemSettings.enableFiltering = true;
            $scope.gridOptionsTargetItemSettings.enableGridMenu = true;

            // For Loading
            if (isPaging == 0)
                $scope.pagination.pageNumber = 1;

            //For Loading
            $scope.loaderMoreTargetItemSettings = true;
            $scope.lblMessageForCurrentOffer = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsTargetItemSettings = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "TARGET_ITEM_CODE", displayName: "Item Code", title: "Item Code", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TARGET_ITEM_NAME", displayName: "Item Name", title: "Item Name", width: '40%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "UNIT_NAME", displayName: "Unit Name", title: "Unit Name", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ACTIVE_STATUS", displayName: "Status", title: "Status", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Action',
                        displayName: "Action",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '12%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<div style="padding-left: 12px"><span class="label label-info label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="Edit" ng-click="grid.appScope.getTargetItem(row.entity)">' +
                                        '<i class="icon-edit" aria-hidden="true"></i> Edit' +
                                      '</a>' +
                                      '</span>' +

                                      '<span class="label label-warning label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="Delete" ng-click="grid.appScope.delete(row.entity)">' +
                                        '<i class="icon-trash" aria-hidden="true"></i> Delete' +
                                      '</a>' +
                                      '</span></div>'
                    }
                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: true,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'Customer.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Customer", style: 'headerStyle' },
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

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                TargetItemId: 0,
                loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetTargetItems/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listTargetItemInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listTargetItemInfo.then(function (response) {
                $scope.pagination.totalItems = response.data.recordsTotal;
                $scope.gridOptionsTargetItemSettings.data = response.data.targetItems;
                $scope.loaderMoreTargetItemSettings = false;
                $scope.TargetItemList = response.data.targetItems;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        loadAllTargetItem(0);

        $scope.IsImageShow = false;
        //**********----Get Single Record----***************
        $scope.getTargetItem = function (dataModel) {
            $scope.clear();
            debugger;
            $scope.IsShow = true;
            $scope.IsHiddenDetail = false;
            $scope.btnShowText = "Show List";
            $scope.btnSaveText = "Update";
            $scope.PageTitle = 'Update Target Item';
            $scope.IsHidden = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;

            $scope.hTargetItemId = dataModel.TARGET_ITEM_ID;
            $scope.TargetItemCode = dataModel.TARGET_ITEM_CODE;
            $scope.UnitName = dataModel.UNIT_NAME;
            $scope.TargetItemName = dataModel.TARGET_ITEM_NAME;
            $scope.IsActive = dataModel.IS_ACTIVE == 1 ? true : false;
            $scope.GetApplyTo();
        };

        $scope.GetApplyTo = function () {
            debugger;
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                TargetItemId: $scope.hTargetItemId,
                loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetTargetItemApplyTo/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
            var listTargetItemInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);

            listTargetItemInfo.then(function (response) {
                debugger;
                $scope.ListItemtDetails = [];
                $scope.ListApplyTo = response.data.targetItemApplyTo;

                angular.forEach($scope.ListApplyTo, function (item) {
                    if (item != null || item != "") {
                        $scope.ListItemtDetails.push({
                            TargetApplyId: item.TARGET_ITEM_APPLY_ID,
                            IsStaffDisabled: item.TARGET_ENTITY_TYPE == 2 || item.TARGET_ENTITY_TYPE == 3 ? true : false,
                            IsCenterDisabled: item.TARGET_ENTITY_TYPE == 2 || item.TARGET_ENTITY_TYPE == 1 ? true : false,
                            ChannelType: item.CHANNEL_TYPE_ID,
                            Entity: item.TARGET_ENTITY_TYPE,
                            StaffRole: item.STAFF_TYPE_ID,
                            CenterType: item.CENTER_TYPE_ID,
                        });
                    }


                    loadCenterTypes(0);
                    loadRoles(0);
                    loadChannelTypes(0);
                });

            },
            function (error) {
                console.log("Error: " + error);
            });
        }


        var fileList = [];
        //**********----Create New Record----***************

        $scope.save = function () {

            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '01602'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveTargetItemSettings();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.SaveTargetItemSettings = function () {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                //loggeduser: $scope.loggedUserId,
            };

            var TargetItemInfo = {
                TargetItemId: $scope.hTargetItemId == undefined || $scope.hTargetItemId == null ? 0 : $scope.hTargetItemId,
                Code: $scope.TargetItemCode,
                Name: $scope.TargetItemName,
                IsActive: $scope.IsActive == true ? 1 : 0,
                UnitName: $scope.UnitName
            };

            $scope.ApplyToList = [];

            angular.forEach($scope.ListItemtDetails, function (item) {
                if (item != null || item != "") {
                    $scope.ApplyToList.push({
                        TargetItemApplyToId: item.TargetApplyId == undefined || item.TargetApplyId == null ? 0 : item.TargetApplyId,
                        ChannelTypeId: item.ChannelType,
                        TargetEntityType: item.Entity,
                        StaffTypeId: item.StaffRole,
                        CenterTypeId: item.CenterType
                    });
                }
            });

            var applyTo = $scope.ApplyToList;


            var apiRoute = baseUrl + 'SaveUpdateTargetItem/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(TargetItemInfo) + "," + JSON.stringify(applyTo) + "]";

            var SaveUpdateTargetItemSetting = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateTargetItemSetting.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");

                    $scope.clear();
                }
                else if (response.data == "") {
                        Command: toastr["warning"]("Save Not Successfull!!!!");
                    $("#save").prop("disabled", false);
                }

            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        //**********----Delete Single Record----***************
        $scope.delete = function (dataModel) {
            var IsConf = confirm('You are about to delete ' + dataModel.TARGET_ITEM_NAME + '. Are you sure?');
        }

        //**********----Reset Record----***************
        $scope.clear = function () {
            $scope.IsHidden = true;
            $scope.IsShow = true;
            $scope.IsHiddenDetail = true
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;

            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Show List";
            $scope.PageTitle = 'Add New Target Item';

            $scope.hTargetItemId = 0;
            $scope.TargetItemCode = '';
            $scope.UnitName = '';
            $scope.TargetItemName = '';

            $scope.IsActive = false;

            $scope.ListItemtDetails = [];
            $scope.ListItemtDetails.push({ FirstRow: null });

            loadAllTargetItem(0);
        };
    }]);

