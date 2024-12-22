/**
 * RSODetailsCtlr.js
 */

app.controller('RSODetailsCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTSReports/api/RetailSalesOfficer/';
      
        $scope.PageTitle = 'RSO Details';
        $scope.IsClusterDisabled = true;
        $scope.IsRegionDisabled = true;
        $scope.IsZoneDisabled = true;
        $scope.IsRouteDisabled = true;
        $scope.gridOptionsRSODetails = [];

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

        GetPermission('00701');

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

        //**********----Get Zones ----***************
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

        //**********----Get Target Item ----***************
        $scope.loadTargetItems = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId
            };

            var apiRoute = DirectoryKey + '/SFTSReports/api/Common/GetTargetItems/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var targetItems = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            targetItems.then(function (response) {
                $scope.itemList = response.data.objListTargetItem;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.loadTargetItems();

        //**********----Get RSO Details----***************
        $scope.GetRsoDetails = function () {
            $scope.gridOptionsRSODetails.enableFiltering = false;
            $scope.gridOptionsRSODetails.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreRSODetails = true;
            $scope.lblMessageForRSODetails = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsRSODetails = {
                useExternalPagination: false,
                useExternalSorting: true,
                enableFiltering: false,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "RSO_CODE", displayName: "Rso Code", title: "Rso Code", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RSO_NAME", displayName: "Rso Name", title: "Rso Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SR_NUMBER", displayName: "SR Number", title: "SR Number", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RSO_CONTACT", displayName: "RSO Contact", title: "RSO Contact", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "HANDSET_NUMBER", displayName: "Handset Number", title: "Handset Number", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ONBOUND_DATE", displayName: "Onbound Date", title: "Onbound Date", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CREATED_BY", displayName: "Created By", title: "Created By", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ACTIVE_STATUS", displayName: "Active Status", title: "Active Status", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "LAST_MODIFIED_BY", displayName: "Last Modified By", title: "Last Modified By", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "LAST_MODIFIED_DATE", displayName: "Last Modified Date", title: "Last Modified Date", width: '13%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MODIFIED_FIELDS", displayName: "Modified Fields", title: "Modified Fields", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DEACTIVE_DATE", displayName: "Deactive Date", title: "Deactive Date", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ROUTE_1", displayName: "Route 1", title: "Route 1", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ROUTE_2", displayName: "Route 2", title: "Route 2", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ROUTE_3", displayName: "Route 3", title: "Route 3", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ROUTE_4", displayName: "Route 4", title: "Route 4", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ROUTE_5", displayName: "Route 5", title: "Route 5", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ROUTE_6", displayName: "Route 6", title: "Route 6", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SIM_RETAILER_COUNT", displayName: "SIM Retailer Count", title: "SIM Retailer Count", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TOPUP_RETAILER_COUNT", displayName: "Topup Retailer Count", title: "Topup Retailer Count", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SC_RETAILER_COUNT", displayName: "SC Retailer Count", title: "SC Retailer Count", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DEVICE_RETAIELR_COUNT", displayName: "Device Retailer Count", title: "Device Retailer Count", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: 'Action', displayName: "  ", enableColumnResizing: false, enableFiltering: false, enableSorting: false, pinnedRight: true, width: '5%', headerCellClass: $scope.highlightFilteredHeader }
                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: false,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'RSO Details.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "RSO Details", style: 'headerStyle' },
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

            objRSODetails = {
                ClusterId: $scope.Cluster,
                RegionId: $scope.Region,
                ZoneId: $scope.Zone,
                ItemId: $scope.TargetItem
            }

            var apiRoute = baseUrl + 'GetRsoDetails/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(objRSODetails) + "]";

            var tva = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            tva.then(function (response) {
                $scope.tvaList = response.data.getRsoDetails;
                $scope.gridOptionsRSODetails.data = response.data.getRsoDetails;
                $scope.loaderMoreRSODetails = false;

            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetRsoDetails();

    }]);

