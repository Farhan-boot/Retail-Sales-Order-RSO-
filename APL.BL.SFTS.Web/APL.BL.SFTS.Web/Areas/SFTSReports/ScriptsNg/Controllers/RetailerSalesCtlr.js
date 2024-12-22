/**
 * RetailerSalesCtlr.js
 */

app.controller('RetailerSalesCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTSReports/api/Retailer/';
      
        $scope.PageTitle = 'Retailer Sales';
        $scope.IsClusterDisabled = true;
        $scope.IsRegionDisabled = true;
        $scope.IsZoneDisabled = true;
        $scope.IsRouteDisabled = true;
        $scope.gridOptionsRetailerSales = [];

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
        $scope.GetRetailerSales = function () {
            $scope.gridOptionsRetailerSales.enableFiltering = false;
            $scope.gridOptionsRetailerSales.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreRetailerSales = true;
            $scope.lblMessageForRetailerSales = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsRetailerSales = {
                useExternalPagination: false,
                useExternalSorting: true,
                enableFiltering: false,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "DISTRIBUTOR_CODE", displayName: "Distributor Code", title: "Distributor Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RSO_CODE", displayName: "RSO Code", title: "RSO Code", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RETAILER_CODE", displayName: "Retailer Code", title: "Retailer Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DATE", displayName: "Date", title: "Date", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SIM_SALES_PREPAID", displayName: "SIM Sales Prepaid", title: "SIM Sales Prepaid", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SIM_SALES_POSTPAID", displayName: "SIM Sales Postpaid", title: "SIM Sales Postpaid", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SIM_SALES_SWAP", displayName: "SIM Sales Swap", title: "SIM Sales Swap", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TOS", displayName: "TOS", title: "TOS", width: '6%', headerCellClass: $scope.highlightFilteredHeader },
                   // { name: "SIM_SALES_DUPLICATE_DIAL", displayName: "SIM Sales Duplicate Dial", title: "SIM Sales Duplicate Dial", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    //{ name: "DEVICE_SALES", displayName: "Device Sales", title: "Device Sales", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ITOPUP_TERRITORY", displayName: "itop-up Sales", title: "itop-up Tertiary", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    //{ name: "SC_SALES", displayName: "SC Sales", title: "SC Sales", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SR_NO", displayName: "SR Number", title: "SR Number", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SUPERV_NAME", displayName: "Superviser", title: "Superviser", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                   
                   // { name: 'Action', displayName: "  ", enableColumnResizing: false, enableFiltering: false, enableSorting: false, pinnedRight: true, width: '5%', headerCellClass: $scope.highlightFilteredHeader }
                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: false,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'Retailer Sales.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Retailer Sales", style: 'headerStyle' },
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

            var apiRoute = baseUrl + 'GetRetailerSales/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(objSearchParam) + "]";

            var tva = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            tva.then(function (response) {
                $scope.tvaList = response.data.retailerSales;
                $scope.gridOptionsRetailerSales.data = response.data.retailerSales;
                $scope.loaderMoreRetailerSales = false;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        //$scope.GetRetailerSales();
        $scope.ExportExcelFile = function () {
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

            var apiRoute = baseUrl + 'GetRetailerSales/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(objSearchParam) + "]";
            var apiRoute = baseUrl + 'ExportExcelTemplate/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(objSearchParam) + "]";

            var TargetItems = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            TargetItems.then(function (response) {
                window.open(DirectoryKey +'/UserFiles/Notification/' + response.data, '_blank', '');
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
    }]);

