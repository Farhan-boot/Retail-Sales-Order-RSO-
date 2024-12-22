/**
 * UploadedTargetCtlr.js
 */

app.controller('UploadedTargetCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTSReports/api/Target/';
      
        $scope.PageTitle = 'Uploaded Target';
        $scope.IsClusterDisabled = true;
        $scope.IsRegionDisabled = true;
        $scope.IsZoneDisabled = true;
        $scope.IsRouteDisabled = true;
        $scope.IsStaffTypeDisabled = true;

        $scope.gridOptionsUploadedTarget = [];

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
                    window.location.href = "/SFTS/NoPermission";
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        //GetPermission('00701');

        //**********----Get User Work Area ----***************
        var isRegionalUser = 0;
        function loadUserWorkArea() {
            objcmnParam = {
                loggeduser: $scope.loggedUserId
            };

            var apiRoute = DirectoryKey + '/SFTSReports/api/Common/GetUserWorkArea/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var workAreas = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            workAreas.then(function (response) {
                $scope.workAreaList = response.data.objListUserWorkArea;
                $scope.marketAreaType = $scope.workAreaList[0].MARKET_AREA_TYPE_ID;
                switch($scope.marketAreaType)
                {
                    case 1:
                        $scope.IsClusterDisabled = false;
                        $scope.IsRegionDisabled = false;
                        $scope.IsZoneDisabled = false;
                        $scope.IsRouteDisabled = false;
                        loadClusters();
                        break;
                    case 2:
                        $scope.IsClusterDisabled = true;
                        $scope.IsRegionDisabled = false;
                        $scope.IsZoneDisabled = false;
                        $scope.IsRouteDisabled = false;
                        isRegionalUser = 1;
                        $scope.loadRegions();
                        break;
                    case 4:
                        $scope.IsClusterDisabled = true;
                        $scope.IsRegionDisabled = true;
                        $scope.IsZoneDisabled = false;
                        $scope.IsRouteDisabled = false;
                        $scope.loadZones();
                        break;
                    default:
                }

            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        //loadUserWorkArea();


 
        //**********----Get Routes ----***************
        $scope.loadRoutes = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                ZoneId: $scope.Zone
            };

            var apiRoute = DirectoryKey + '/SFTSReports/api/Common/GetRoutes/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var routes = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            routes.then(function (response) {
                $scope.routeList = response.data.objListRoute;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        //**********----Get Target Items ----***************
        function loadTargetItems(isPaging) {
            objcmnParam = {
                TargetItemId: 0,
                //loggeduser: $scope.loggedUserId,                          
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetTargetItem/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var TargetItems = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            TargetItems.then(function (response) {
                $scope.listTargetItem = response.data.objListTargetItem;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        loadTargetItems(0);

        //**********----Get Target Period ----***************
        $scope.loadTargetPeriod = function (isPaging) {
            objcmnParam = {
                TargetPeriodId: 0,
                //loggeduser: $scope.loggedUserId,                              
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetTargetPeriod/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var TargetPeriod = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            TargetPeriod.then(function (response) {
                $scope.listTargetPeriod = response.data.objListTargetPeriod;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.loadTargetPeriod(0);

        //**********----Get Staff Type ----***************
        function loadRoles(isPaging) {
            objcmnParam = {
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

        $scope.TargetForChange = function () {
            $scope.IsStaffTypeDisabled = true;
            $("#ddlStaffType").select2("data", { id: '', text: '--Select Staff Type--' });
            if ($scope.TargetFor == 2) {
                $scope.IsStaffTypeDisabled = false;
                loadRoles(0);
            }
        }

        //**********----Get Uploaded Target----***************
        $scope.GetUploadedTarget = function () {
            $scope.gridOptionsUploadedTarget.enableFiltering = false;
            $scope.gridOptionsUploadedTarget.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreUploadedTarget = true;
            $scope.lblMessageForUploadedTarget = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsUploadedTarget = {
                useExternalPagination: false,
                useExternalSorting: true,
                enableFiltering: false,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "TARGET_ITEM_CODE", displayName: "Item Code", title: "Item Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ITEM_NAME", displayName: "Item Name", title: "Item Name", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MONTH_NAME", displayName: "Month Name", title: "Month Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "STAFF_NAME", displayName: "Staff Name", title: "Staff Name", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRIBUTOR_NAME", displayName: "Dist Name", title: "Dist Name", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TARGET_VALUE", displayName: "Target Value", title: "Target Value", width: '11%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: 'Action', displayName: "  ", enableColumnResizing: false, enableFiltering: false, enableSorting: false, pinnedRight: true, width: '5%', headerCellClass: $scope.highlightFilteredHeader }
                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: false,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'Uploaded Target.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Uploaded Target", style: 'headerStyle' },
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
            };

           objUploadedTarget = {
                TargetItemId: $scope.TargetItem,
                TargetPeriodId: $scope.TargetPeriod,
                TargetFor: $scope.TargetFor,
                StaffTypeId: $scope.StaffType,
                InitialVersion: $scope.IsInitalVersion
            };

           var apiRoute = baseUrl + 'GetUploadedTarget/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(objUploadedTarget) + "]";

            var tva = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            tva.then(function (response) {
                $scope.tvaList = response.data.uploadedTarget;
                $scope.gridOptionsUploadedTarget.data = response.data.uploadedTarget;
                $scope.loaderMoreUploadedTarget = false;

            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetUploadedTarget();

    }]);

