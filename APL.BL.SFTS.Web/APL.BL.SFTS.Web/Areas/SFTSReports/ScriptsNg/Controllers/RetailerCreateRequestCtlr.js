/**
 * RetailerCreateRequestCtlr.js
 */

app.controller('RetailerCreateRequestCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTSReports/api/Retailer/';
      
        $scope.PageTitle = 'Retailer Create Request Report';
        $scope.IsClusterDisabled = true;
        $scope.IsRegionDisabled = true;
        $scope.IsZoneDisabled = true;
        $scope.IsRouteDisabled = true;
        $scope.gridOptionsRetailerCreateRequest = [];

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
                debugger;
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
                debugger;
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

        $scope.SearchRetailer = function () {
            var status = $scope.Status;
            $scope.GetNewRetailerInfo(status);
        }

        //**********----Get New Retailer Request----***************
        $scope.GetNewRetailerInfo = function (status) {
            $scope.gridOptionsRetailerCreateRequest.enableFiltering = false;
            $scope.gridOptionsRetailerCreateRequest.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreRetailerCreateRequest = true;
            $scope.lblMessageForRetailerCreateRequest = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsRetailerCreateRequest = {
                useExternalPagination: false,
                useExternalSorting: true,
                enableFiltering: false,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "NAME", displayName: "Retailer Name", title: "Retailer Name", width: '14%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRIBUTOR_NAME", displayName: "Distributor Name", title: "Distributor Name", width: '14%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TERRITORY_NAME", displayName: "Zone Name", title: "Zone Name", width: '14%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "IS_OWN_SHOP", displayName: "Own Shop", title: "Own Shop", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    //{ name: "ROUTE_NAME", displayName: "Route Name", title: "Route Name", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ADDRESS", displayName: "Address", title: "Address", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SHOPSIZE", displayName: "Shop Size", title: "Shop Size", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "OWNERNAME", displayName: "Owner Name", title: "Owner Name", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CONTACTPERSON", displayName: "Contact Person", title: "Contact Person", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CONTACTNO", displayName: "Contact No", title: "Contact No", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRICT_NAME", displayName: "District Name", title: "District Name", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "THANA_NAME", displayName: "Thana Name", title: "Thana Name", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "REQUESTERS_COMMENTS", displayName: "Requester Comments", title: "Requester Comments", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "REQUESTED_BY_NAME", displayName: "Requested By", title: "Requested By", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "REQUEST_STATUS_NAME", displayName: "Status", title: "Status", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: 'Action', displayName: "  ", enableColumnResizing: false, enableFiltering: false, enableSorting: false, pinnedRight: true, width: '5%', headerCellClass: $scope.highlightFilteredHeader }
                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: false,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'Retailer New Retailer Info.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Retailer New Retailer Info", style: 'headerStyle' },
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
                FromDate: $scope.DateFrom == "" || $scope.DateFrom == null ? null : conversion.getStringToDate($scope.DateFrom),
                ToDate: $scope.DateTo == "" || $scope.DateTo == null ? null : conversion.getStringToDate($scope.DateTo),
                StatusId: status
            };


            var apiRoute = baseUrl + 'GetNewRetailerInfo/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var tva = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            tva.then(function (response) {
                $scope.tvaList = response.data.newRetailerRequestList;
                $scope.gridOptionsRetailerCreateRequest.data = response.data.newRetailerRequestList;
                $scope.loaderMoreRetailerCreateRequest = false;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetNewRetailerInfo(1);

    }]);

