/**
 * RSOTargetVsAchivementCtlr.js
 */

app.controller('RSOTargetVsAchivementCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = '/mDMS/SFTSReports/api/RetailSalesOfficer/';
      
        $scope.PageTitle = 'RSO Target Vs Achivement';
        $scope.IsClusterDisabled = true;
        $scope.IsRegionDisabled = true;
        $scope.IsZoneDisabled = true;
        $scope.IsRouteDisabled = true;
        $scope.gridOptionsRSOTargetAchivement = [];

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

            var apiRoute = '/mDMS/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted != true) {
                    window.location.href = "/mDMS/SFTS/NoPermission";
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

            var apiRoute = '/mDMS/SFTSReports/api/Common/GetUserWorkArea/';
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

            var apiRoute = '/mDMS/SFTSReports/api/Common/GetClusters/';
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

            var apiRoute = '/mDMS/SFTSReports/api/Common/GetRegions/';
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

            var apiRoute = '/mDMS/SFTSReports/api/Common/GetZones/';
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

            var apiRoute = '/mDMS/SFTSReports/api/Common/GetZones/';
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

            var apiRoute = '/mDMS/SFTSReports/api/Common/GetRoutes/';
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

            var apiRoute = '/mDMS/SFTSReports/api/Common/GetTargetItems/';
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

        //**********----Get Rso Target Vs Achivement----***************
        $scope.GetRsoTargetVsAchivement = function () {
            $scope.gridOptionsRSOTargetAchivement.enableFiltering = false;
            $scope.gridOptionsRSOTargetAchivement.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreRSOTargetAchivement = true;
            $scope.lblMessageForRSOTargetAchivement = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsRSOTargetAchivement = {
                useExternalPagination: false,
                useExternalSorting: true,
                enableFiltering: false,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "RSO_CODE", displayName: "RSO Code", title: "RSO Code", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RSO_NAME", displayName: "RSO Name", title: "RSO Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRIBUTOR_CODE", displayName: "Dist Code", title: "Dist Code", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRIBUTOR_NAME", displayName: "Dist Name", title: "Dist Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TARGET_VALUE", displayName: "Target Value", title: "Target Value", width: '11%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ACHIVED_VALUE", displayName: "Achived Value", title: "Achived Value", width: '11%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "PRO_RATED_TARGET", displayName: "Pro Rated Target", title: "Pro Rated Target", width: '11%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CURRENT_RR", displayName: "Current RR", title: "Current RR", width: '11%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "REQUIRED_RR", displayName: "Required RR", title: "Required RR", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                {name:  'Action', displayName: "  ", enableColumnResizing: false, enableFiltering: false, enableSorting: false, pinnedRight: true, width: '5%', headerCellClass: $scope.highlightFilteredHeader }
                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: false,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'RSO Target Achivement.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "RSO Target Achivement", style: 'headerStyle' },
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

            objTargetVsAchivement = {
                ClusterId: $scope.Cluster,
                RegionId: $scope.Region,
                ZoneId: $scope.Zone,
                ItemId: $scope.TargetItem
            }

            var apiRoute = baseUrl + 'GetRsoTargetVsAchivements/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(objTargetVsAchivement) + "]";

            var tva = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            tva.then(function (response) {
                $scope.tvaList = response.data.targetVsAchivemntList;
                $scope.gridOptionsRSOTargetAchivement.data = response.data.targetVsAchivemntList;
                $scope.loaderMoreRSOTargetAchivement = false;

            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetRsoTargetVsAchivement();

    }]);

