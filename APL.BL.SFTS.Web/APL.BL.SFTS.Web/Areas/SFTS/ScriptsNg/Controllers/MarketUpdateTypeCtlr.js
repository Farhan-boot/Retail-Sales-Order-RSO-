/**
 * MarketUpdateTypeCtlr.js
 */
app.controller('MarketUpdateTypeCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/MarketUpdate/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing Market Update Types';
        $scope.ListTitle = 'Market Update Type List';
        $scope.IsCreateIcon = true;
        $scope.IsListIcon = false;
        $scope.IsUpdateTypeShow = false;

        $scope.gridOptionsMarketUpdateType = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;

        $scope.ShowHide = function () {
            if ($scope.IsUpdateTypeShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.btnShowText = "Create";
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Existing Market Update Types';
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Add New Market Update Type';
                    $scope.btnShowText = "Show List";
                    $scope.btnSaveShow = true;
                    $scope.btnResetShow = true;
                    $scope.btnSaveText = "Save";
                    $scope.IsShow = false;
                    $scope.IsHidden = false;

                    $scope.IsCreateIcon = false;
                    $scope.IsListIcon = true;
                }
            } else {
                $scope.btnShowText = "Create";
                $scope.IsShow = true;
                $scope.btnSaveShow = false;
                $scope.btnResetShow = false;
                $scope.IsCreateIcon = true;
                $scope.IsListIcon = false;
                $scope.PageTitle = 'Existing Market Update Types';
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

        GetPermission('01901');

        //**********----Get Market Update Types----***************
        function loadMarketUpdateTypes(isPaging) {
            $scope.gridOptionsMarketUpdateType.enableFiltering = true;
            $scope.gridOptionsMarketUpdateType.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreMarketUpdateType = true;
            $scope.lblMessageForMarketUpdateType = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsMarketUpdateType = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "NAME", displayName: "Market Update Type Name", title: "Market Update Type Name", width: '65%', headerCellClass: $scope.highlightFilteredHeader },                  
                    { name: "IS_ACTIVE", displayName: "Status", title: "Status", width: '25%', headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Action',
                        displayName: "Action",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '12%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<div style="padding-left: 10px">' +
                                      '<span class="label label-info label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="Edit" ng-click="grid.appScope.getMarketUpdateType(row.entity)">' +
                                        '<i class="icon-edit" aria-hidden="true"></i> Edit' +
                                      '</a>' +
                                      '</span>' +
                                      '<span class="label label-warning label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="Delete" ng-click="grid.appScope.delete(row.entity)">' +
                                        '<i class="icon-trash" aria-hidden="true"></i> Delete' +
                                      '</a>' +
                                      '</span>' +
                                      '</div>'
                    }
                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: true,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'MarketUpdateType.csv',
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
                loggeduser: $scope.loggedUserId,
                MarketUpdateTypeId: 0
            };
            var apiRoute = baseUrl + 'GetMarketUpdateTypes/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listMarketUpdate = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listMarketUpdate.then(function (response) {
                $scope.gridOptionsMarketUpdateType.data = response.data.marketUpdateTypeList;
                $scope.loaderMoreMarketUpdateType = false;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };
        loadMarketUpdateTypes(0);

        //**********----Get Single Record----***************
        $scope.getMarketUpdateType = function (dataModel) {
            //debugger
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Update Market Update Type';
            $scope.btnSaveText = "Update";
            $scope.btnShowText = "Show List";
            $scope.btnSaveShow = true;
            $scope.btnResetShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;


            $scope.hMarketUpdateTypeId = dataModel.ID;
            $scope.TypeName = dataModel.NAME;
            $scope.IsActive = dataModel.IS_ACTIVE == "Active" ? true : false;
        };

        //**********----Create New Event----***************
        $scope.save = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '01902'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                $scope.SaveMarketUpdateType();
                } else {
                   Command: toastr["warning"]("You have no permission for this operation!");
                   return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.SaveMarketUpdateType = function () {

            objcmnParam = {
                loggeduser: $scope.loggedUserId,
            };

            var MarketUpdateTypeInfo = {
                Id: $scope.hMarketUpdateTypeId == undefined || $scope.hMarketUpdateTypeId == null ? 0 : $scope.hMarketUpdateTypeId,
                Name: $scope.TypeName,
                IsActive: $scope.IsActive
            };

            var apiRoute = baseUrl + 'SaveUpdateMarketUpdateType/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(MarketUpdateTypeInfo) + "]";

            var CreateMarketUpdateType = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            CreateMarketUpdateType.then(function (response) {
                // debugger;
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnShowText = "Create";
                    $scope.PageTitle = 'Add New Market Update Type';
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;
                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    loadMarketUpdateTypes(0);
                }
                else if (response.data == "") {
                        Command: toastr["warning"]("Save Not Successfull!!!!");
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        //**********----Reset Record----***************
        $scope.clear = function () {
            $scope.IsHidden = true;
            $scope.IsShow = true;
            $scope.IsHiddenDetail = true
            $scope.IsCreateIcon = true;
            $scope.IsListIcon = false;

            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Create";

            $scope.hMarketUpdateTypeId = 0;
            $scope.TypeName = '';
            $scope.IsActive = false;

            loadMarketUpdateTypes(0);
        };
    }]);

