/**
* FocProductCtlr.js
*/
app.controller('RSOPointCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/RSOPoint/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing RSO Point';
        $scope.ListTitle = 'RSO Point List';
        $scope.IsCreateIcon = true;
        $scope.IsListIcon = false;
        $scope.IsRSOPointShow = false;
        $scope.gridOptionsRSOPoints = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;

        $scope.ShowHide = function () {
            if ($scope.IsRSOPointShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.btnShowText = "Create";
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Existing RSO Points';
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Add New RSO Point';
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
                $scope.PageTitle = 'Existing RSO Point';
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

        GetPermission('04015');


        //**********----Get All TradeMaterials----***************
        $scope.loadRSOPoints = function (isPaging) {
        

            $scope.gridOptionsRSOPoints.enableFiltering = true;
            $scope.gridOptionsRSOPoints.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreRSOPoints = true;
            $scope.lblMessageForRSOPoints = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsRSOPoints = {
                useExternalSorting: false,
                enableSorting: true,
                useExternalPagination: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "DATE_STR", displayName: "Date", title: "Date", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "REGION", displayName: "Region", title: "Region", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRIBUTOR_CODE", displayName: "Distributor Code", title: "Distributor Code", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RSO_CODE", displayName: "RSO Code", title: "RSO Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SR_NO", displayName: "SR Number", title: "SR Number", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TOTAL_POINTS", displayName: "Total Points", title: "Total Points", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Action',
                        displayName: "Action",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '12%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<div style="padding-left: 10px" hidden>' +
                            '<span class="label label-info label-mini" style="text-align:center !important;">' +
                            '<a href="" title="Edit" ng-click="grid.appScope.getRSOPoint(row.entity)">' +
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
                ZoneId: $scope.ZoneId??0,
                FromDate: $scope.FromDate == "" || $scope.FromDate == null ? null : conversion.getStringToDate($scope.FromDate),
                ToDate: $scope.ToDate == "" || $scope.ToDate == null ? null : conversion.getStringToDate($scope.ToDate),
            };
            var apiRoute = baseUrl + 'GetRSOPoints/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var RSOPointList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            RSOPointList.then(function (response) {
                $scope.gridOptionsRSOPoints.data = response.data.rsoPointList;
                $scope.loaderMoreRSOPoints = false;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };
        //$scope.loadRSOPoints(0);

        $scope.loadZones = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                IsZonalUser: 0,
                RegionId: 0
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CommissionStructure/' + '/GetRegions/';// '/mDMS/SFTSReports/api/Common/GetZones/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var zones = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            zones.then(function (response) {
                $scope.zoneList = response.data.objListRegion;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        $scope.loadZones();
        $scope.ExportExcelFile = function () {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
                ZoneId: $scope.ZoneId ?? 0,
                FromDate: $scope.FromDate == "" || $scope.FromDate == null ? null : conversion.getStringToDate($scope.FromDate),
                ToDate: $scope.ToDate == "" || $scope.ToDate == null ? null : conversion.getStringToDate($scope.ToDate),
            };
            var apiRoute = baseUrl + 'ExportExcelTemplate/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var TargetItems = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            TargetItems.then(function (response) {
                window.open(DirectoryKey +'/UserFiles/Notification/' + response.data, '_blank', '');
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        //**********----Get Single Record----***************
        //$scope.getRSOPoint = function (dataModel) {
        //    //debugger
        //    $scope.IsHidden = false;
        //    $scope.IsShow = false;
        //    $scope.PageTitle = 'Update RSO Point';
        //    $scope.btnSaveText = "Update";
        //    $scope.btnShowText = "Show List";
        //    $scope.btnSaveShow = true;
        //    $scope.btnResetShow = true;
        //    $scope.IsCreateIcon = false;
        //    $scope.IsListIcon = true;


        //    $scope.hRSOPointId = dataModel.GROUP_ID;
        //    $scope.GroupName = dataModel.GROUP_NAME;
        //    $scope.GroupForName = dataModel.GROUP_FOR_NAME;
        //    $scope.GroupFor = dataModel.GROUP_FOR;
        //    $scope.IsActive = dataModel.IS_ACTIVE;


        //};




        ////**********----Create New TradeMaterial----***************

        //$scope.save = function () {

        //    objcmnParam = {
        //        loggeduser: $scope.loggedUserId,
        //        PermissionCode: '01902'
        //    };

        //    var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
        //    var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

        //    var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
        //    roleWisePermission.then(function (response) {
        //        $scope.listRoleWisePermission = response.data.roleWisePermission;
        //        IsPermitted = response.data.IsPermitted;
        //        if (IsPermitted == true) {
        //            $scope.SaveRSOPoint();
        //        } else {
        //            Command: toastr["warning"]("You have no permission for this operation!");
        //            return;
        //        }
        //    },
        //        function (error) {
        //            console.log("Error: " + error);
        //        });
        //};

        //$scope.SaveRSOPoint = function () {

        //    objcmnParam = {
        //        pageNumber: page,
        //        pageSize: pageSize,
        //        IsPaging: isPaging,
        //        loggeduser: $scope.loggedUserId,
        //    };

        //    var RSOPoint = {
        //        GroupId: $scope.hRSOPointId === undefined || $scope.hRSOPointId === null ? 0 : $scope.hRSOPointId,
        //        GroupName: $scope.GroupName,
        //        GroupFor: $scope.GroupFor,
        //        IsActive: $scope.IsActive
        //    };


        //    var apiRoute = baseUrl + 'SaveRSOPoint/';
        //    var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(RSOPoint) + "]";

        //    var SaveUpdateRSOPoint = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
        //    SaveUpdateRSOPoint.then(function (response) {
        //        if (response.data != "") {
        //            Command: toastr["success"]("Save  Successfully!!!!");
        //            $scope.clear();
        //            $scope.IsHidden = true;
        //            $scope.IsShow = true;
        //            $scope.btnShowText = "Create";
        //            $scope.PageTitle = 'Add New RSO Point';
        //            $scope.btnSaveShow = false;
        //            $scope.btnResetShow = false;
        //            $scope.IsCreateIcon = true;
        //            $scope.IsListIcon = false;
        //            loadRSOPoints(0);
        //        }
        //        else if (response.data == "") {
        //            Command: toastr["warning"]("Save Not Successfull!!!!");
        //        }
        //    },
        //        function (error) {
        //            console.log("Error: " + error);
        //        });
        //}
        $scope.GroupFor = 1;
        $scope.IsActive = 1;
        //**********----Reset Record----***************
        $scope.clear = function () {
            $scope.IsHidden = true;
            $scope.IsShow = true;
            $scope.IsHiddenDetail = true
            $scope.IsCreateIcon = true;
            $scope.IsListIcon = false;

            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Create";

            $scope.hRSOPointId = 0;
            $scope.GroupName = '';
            $scope.GroupFor = 1;
            $scope.IsActive = 1;

            loadRSOPoints(0);
        };
    }]);

