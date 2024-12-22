/**
 * SalesCallAndDailyAttendanceCtlr.js
 */

app.controller('SalesCallAndDailyAttendanceCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTSReports/api/RetailSalesOfficer/';
      
        $scope.PageTitle = 'RSO Sales Call And Daily Attendance';
        $scope.IsClusterDisabled = true;
        $scope.IsRegionDisabled = true;
        $scope.IsZoneDisabled = true;
        $scope.IsRouteDisabled = true;
        $scope.gridOptionsSalesCallAndDailyAttendance = [];

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
        loadUserWorkArea();
   
        //**********----Get Clusters ----***************
        function loadClusters() {
            objcmnParam = {
                loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = DirectoryKey + '/SFTSReports/api/Common/GetClusters/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var clusters = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            clusters.then(function (response) {
                $scope.clusterList = response.data.objListCluster;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
      
        //**********----Get Regions ----***************
        $scope.loadRegions = function() {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                IsRegionalUser: isRegionalUser,
                ClusterId: $scope.Cluster
            };

            var apiRoute = DirectoryKey + '/SFTSReports/api/Common/GetRegions/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var regions = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            regions.then(function (response) {
                $scope.regionList = response.data.objListRegion;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        //**********----Get Zones ----***************
        $scope.loadZones = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                IsZonalUser: 1,
                RegionId: $scope.Region
            };

            var apiRoute = DirectoryKey + '/SFTSReports/api/Common/GetZones/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var zones = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            zones.then(function (response) {
                $scope.zoneList = response.data.objListZone;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.loadZoneRegionOnchange = function () {
            objcmnParam = {
                loggeduser: 0,
                RegionId: $scope.Region
            };

            var apiRoute = DirectoryKey + '/SFTSReports/api/Common/GetZones/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var zones = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            zones.then(function (response) {
                $scope.zoneList = response.data.objListZone;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        //**********----Get Rso ----***************
        $scope.loadRso = function (isPaging) {
            $("#ddlRso").select2("val", "");
            objcmnParam = {
                //ZoneId: $scope.Zone == null || $scope.Zone == 0 || $scope.Zone == undefined ? 0 : $scope.Zone,
                loggeduser: $scope.loggedUserId
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetRSO/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRso = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRso.then(function (response) {
                $scope.RsoList = response.data.objListRso;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.loadRso(0);


        //**********----Get Sales And Daily Attendance----***************
        $scope.GetSalesCallAndDailyAttendance = function () {
            $scope.gridOptionsSalesCallAndDailyAttendance.enableFiltering = false;
            $scope.gridOptionsSalesCallAndDailyAttendance.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreSalesCallAndDailyAttendance = true;
            $scope.lblMessageForSalesCallAndDailyAttendance = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsSalesCallAndDailyAttendance = {
                useExternalPagination: false,
                useExternalSorting: true,
                enableFiltering: false,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "DATE", displayName: "Date", title: "Date", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ROUTE", displayName: "Route Name", title: "Route Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RSO", displayName: "RSO", title: "RSO", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "VISIT_TARGET", displayName: "Visit Target", title: "Visit Target", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "VISITED", displayName: "Visited", title: "Visited", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SUCCESSFUL_SALES_CALL", displayName: "Successful Sales Call", title: "Successful Sales Call", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SIM_RETAIELR_TARGET", displayName: "SIM Retailer Target", title: "SIM Retailer Target", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SIM_RETAILER_VISITED", displayName: "SIM Retailer Visited", title: "SIM Retailer Visited", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SUCCESSFUL_SIM_SALES_CALL", displayName: "Successful SIM Call", title: "Successful SIM Call", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SIM_COUNT", displayName: "SIM Count", title: "SIM Count", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TOPUP_RETAILER_TARGET", displayName: "Topup Retailer Target", title: "Topup Retailer Target", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TOPUP_RETAILER_VISITED", displayName: "Topup Retailer Visited", title: "Topup Retailer Visited", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SUCCESSFUL_TOPUP_SALES_CALL", displayName: "Successful Topup Sales Call", title: "Successful Topup Sales Call", width: '17%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TOPUP_AMOUNT", displayName: "Topup Amount", title: "Topup Amount", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SC_RETAILER_TARGET", displayName: "SC Retailer Target", title: "SC Retailer Target", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SC_RETAILER_VISITED", displayName: "SC Retailer Visited", title: "SC Retailer Visited", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SUCCESSFUL_SC_SALES_CALL", displayName: "Successful SC Call", title: "Successful SC Call", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SC_VALUE", displayName: "SC Value", title: "SC Value", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DEVICE_RETAILER_TARGET", displayName: "Device Retailer Target", title: "Device Retailer Target", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DEVICE_RETAILER_VISITED", displayName: "Device Retailer Visited", title: "Device Retailer Visited", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SUCCESSFUL_DEVICE_SALES_CALL", displayName: "Successful Device Sales Call", title: "Successful Device Sales Call", width: '17%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DEVICE_COUNT", displayName: "Device Count", title: "Device Count", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: 'Action', displayName: "  ", enableColumnResizing: false, enableFiltering: false, enableSorting: false, pinnedRight: true, width: '5%', headerCellClass: $scope.highlightFilteredHeader }
                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: false,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'Sales Call And Attendance.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Sales Call And Attendance", style: 'headerStyle' },
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
                FromDate: $scope.FromDate == "" || $scope.FromDate == null ? null : conversion.getStringToDate($scope.FromDate),
                ToDate: $scope.ToDate == "" || $scope.ToDate == null ? null : conversion.getStringToDate($scope.ToDate),
            };

            objSearchParam = {
                ClusterId: $scope.Cluster,
                RegionId: $scope.Region,
                ZoneId: $scope.Zone
            }

            var apiRoute = baseUrl + 'GetRsoSalesCallAndDailyAttendance/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(objSearchParam) + "]";

            var tva = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            tva.then(function (response) {
                $scope.tvaList = response.data.salesCallAndDaileyAttendanceList;
                $scope.gridOptionsSalesCallAndDailyAttendance.data = response.data.salesCallAndDaileyAttendanceList;
                $scope.loaderMoreSalesCallAndDailyAttendance = false;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetSalesCallAndDailyAttendance();

    }]);

