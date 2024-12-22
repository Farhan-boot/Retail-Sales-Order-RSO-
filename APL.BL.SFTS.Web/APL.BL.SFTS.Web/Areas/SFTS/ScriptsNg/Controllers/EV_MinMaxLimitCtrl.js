/**
* FocProductCtlr.js
*/
app.controller('EV_MinMaxLimitCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/Ev_minmaxlimit/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing EV Limit';
        $scope.ListTitle = 'EV Limit List';
        $scope.IsCreateIcon = false;
        $scope.IsListIcon = false;
        $scope.IsEVLimitShow = false;
        $scope.gridOptionsEVLimits = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;

        $scope.ShowHide = function () {
            if ($scope.IsEVLimitShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.btnShowText = "Create";
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Existing EV Limits';
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Add New EV Limit';
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
                $scope.PageTitle = 'Existing EV Limit';
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

        GetPermission('00910');


        //**********----Get All TradeMaterials----***************
        function loadEVLimits(isPaging) {

            $scope.gridOptionsEVLimits.enableFiltering = true;
            $scope.gridOptionsEVLimits.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreEVLimits = true;
            $scope.lblMessageForEmployees = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsEVLimits = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "EV_LIMIT_MIN_AMOUNT", displayName: "MIN AMOUNT", title: "MIN AMOUNT", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "EV_LIMIT_MAX_AMOUNT", displayName: "MAX AMOUNT", title: "MAX AMOUNT", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
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
                            '<a href="" title="Edit" ng-click="grid.appScope.getEVLimit(row.entity)">' +
                            '<i class="icon-edit" aria-hidden="true"></i> Edit' +
                            '</a>' +
                            '</span>' +
                            '<span style="display:none" class="label label-warning label-mini" style="text-align:center !important;">' +
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
                exporterCsvFilename: 'Trade Materials.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Trade Materials", style: 'headerStyle' },
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
                loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetEVMinmaxlimit/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listTradeMaterial = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listTradeMaterial.then(function (response) {
                $scope.gridOptionsEVLimits.data = response.data.employeeList;
                $scope.loaderMoreEVLimits = false;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };
        loadEVLimits(0);

        //**********----Get Single Record----***************
        $scope.getEVLimit = function (dataModel) {
            //debugger
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Update EV Limit';
            $scope.btnSaveText = "Update";
            $scope.btnShowText = "Show List";
            $scope.btnSaveShow = true;
            $scope.btnResetShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;


            $scope.hEVLimitId = dataModel.EV_LIMIT_ID;
            $scope.MinAmount = dataModel.EV_LIMIT_MIN_AMOUNT;
            $scope.MaxAmount = dataModel.EV_LIMIT_MAX_AMOUNT;

           
        };

        $(document).on("input", ".numberonly", function () {
            this.value = this.value.replace(/\D/g, '');
        });


        //**********----Create New TradeMaterial----***************

        $scope.save = function () {

            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '00911'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveEVLimit();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };

        $scope.SaveEVLimit = function () {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };

            var EVLimit = {
                EV_LimitId: $scope.hEVLimitId == undefined || $scope.hEVLimitId == null ? 0 : $scope.hEVLimitId,
                MinAmount: $scope.MinAmount,
                MaxAmount: $scope.MaxAmount
            };


            var apiRoute = baseUrl + 'SaveUpdateEVLimit/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(EVLimit) + "]";

            var SaveUpdateEVLimit = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateEVLimit.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnShowText = "Create";
                    $scope.PageTitle = 'Add New EV Limit';
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;
                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    loadEVLimits(0);
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
            $scope.btnSaveShow = false;

            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Create";
            $scope.btnResetShow = false;
            $scope.hEVLimitId = 0;
            $scope.MinAmount = 0;
            $scope.MaxAmount = 0;

            loadEVLimits(0);
        };
    }]);

