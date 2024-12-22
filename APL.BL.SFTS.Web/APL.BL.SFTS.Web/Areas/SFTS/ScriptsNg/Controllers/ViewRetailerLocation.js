/**
 * RetailerLocationCtlr.js
 */

app.controller('RetailerLocationCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants', 'NgMap',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants, NgMap) {

        var baseUrl = DirectoryKey +'/SFTS/api/ViewRetailerLocation/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;
        $scope.PageTitle = 'Retailer Location';
        $scope.IsMapShow = false;


        function CommonEntity() {
            $scope.HeaderToken = $scope.tokenManager.generateSecurityToken();
            $scope.loggedUserId = $scope.loggedUserManager.loggedUser();
           // $scope.CmnMethod = function (FuncEntity, CmnNum) { $scope.CmnEntity = {}; $scope.CmnEntity = conversion.ExecuteCmnFunc(FuncEntity, CmnNum); if (CmnNum != 0 && CmnNum != 2 && CmnNum != 6) { $scope[$scope.CmnEntity.MethodName]($scope.CmnEntity.rowEntity); } if (CmnNum == 2) { for (var i = 0; i < $scope.CmnEntity.MethodName.length; i++) { $scope[$scope.CmnEntity.MethodName[i]]($scope.CmnEntity.rowEntity); } } if (CmnNum == 3) { conversion.SaveUpdatBehave($scope.CmnEntity.num); } }
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

        GetPermission('01801');


        //**********----Get Zone ----***************
        function loadZones(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RegionId: 0,
                ZoneId: 0,
                loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetZones/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listZone = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listZone.then(function (response) {
                $scope.listZone = response.data.objListZone;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadZones(0);

        //**********----Get Route ----***************
        $scope.loadRoute = function (isPaging) {
            $("#ddlRoute").select2("val", "");
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                ZoneId: $scope.Zone == null || $scope.Zone == 0 || $scope.Zone == undefined ? 0 : $scope.Zone,
                loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetRoutesByZone/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRoutes = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRoutes.then(function (response) {
                $scope.listRoute = response.data.objListRoute;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
         //$scope.loadRoute(0);


        //**********----Get Retailer ----***************
         $scope.loadRetailer = function (isPaging) {
             $("#ddlRetailer").select2("val", "");
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RouteID: $scope.Route == null || $scope.Route == 0 || $scope.Route == undefined ? 0 : $scope.Route,
                //loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetRetailers/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRetailers = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRetailers.then(function (response) {
                $scope.listRetailer = response.data.objListRetailer;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        // $scope.loadRetailer(0);

        //**********----Get Retailer GPS----***************
         $scope.listRetailerGps = [];
         $scope.listBtsGps = [];

        $scope.GetRetailerGPSDetail = function () {

            $scope.IsMapShow = true;
            $scope.GetBTSLocation();

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                ZoneId: $scope.Zone == null || $scope.Zone == 0 || $scope.Zone == undefined ? 0 : $scope.Zone,
                RouteID: $scope.Route == null || $scope.Route == 0 || $scope.Route == undefined ? 0 : $scope.Route,
                RetailerId: $scope.Retailer == null || $scope.Retailer == 0 || $scope.Retailer == undefined ? 0 : $scope.Retailer,
                loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = baseUrl + 'GetRetailerGPS/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRetailerLocation = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRetailerLocation.then(function (response) {

                $scope.listRetailerGps = response.data.retailerGPS;
                $scope.CenterLatValue = $scope.listRetailerGps[0].LATITUDE_VALUE;
                $scope.CenterLongValue = $scope.listRetailerGps[0].LONGITUDE_VALUE;
            },
            function (error) {
                console.log("Error: " + error);
            });
         
            //http://chart.apis.google.com/chart?chst=d_map_xpin_letter&chld=pin|R|F58635|000000 

            $scope.RetailerPin = new google.maps.MarkerImage("http://chart.apis.google.com/chart?chst=d_map_xpin_letter&chld=pin_star|R|F58635|000000|DC143C");

      
            NgMap.getMap().then(function (map) {
                $scope.map = map;
            });

            $scope.showBtsInfo = function (event, bts) {
                $scope.btsName = bts.NAME;
                $scope.map.showInfoWindow('btsInfoWindow', this);
            };

            $scope.showRetailerInfo = function (event, retailer) {
                $scope.retailerName = retailer.RETAILER_NAME;
                $scope.map.showInfoWindow('retailerInfoWindow', this);
            };

            if ($scope.listRetailerGps == null && $scope.listBtsGps == null) {
                $scope.IsMapNotAvail = true;
                $scope.IsMapShow = false;
                $scope.msgMapNotAvail = ' * Location is not available to show map!!'
            } else {
                $scope.IsMapNotAvail = false;
                $scope.IsMapShow = true;
            }
        };

        //**********----Get BTS GPS----***************
        $scope.GetBTSLocation = function () {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                ZoneId: $scope.Zone == null || $scope.Zone == 0 || $scope.Zone == undefined ? 0 : $scope.Zone,
                RouteID: $scope.Route == null || $scope.Route == 0 || $scope.Route == undefined ? 0 : $scope.Route,
                //loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = baseUrl + 'GetBTSLocation/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listBTSLocation = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listBTSLocation.then(function (response) {

                $scope.listBtsGps = response.data.btsGPS;
            },
            function (error) {
                console.log("Error: " + error);
            });

        };
  
    }]);

