/**
 * RSOFootstepViewCtlr.js
 */

app.controller('RSOFootstepViewCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants', 'NgMap', '$rootScope',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants, NgMap, $rootScope) {

        var baseUrl = DirectoryKey +'/SFTS/api/RSOFootstepsView/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;
        $scope.PageTitle = 'RSO Footsteps View';
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

        GetPermission('01201');


        //**********----Get Zone ----***************
        function loadZone(isPaging) {
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
        loadZone(0);

        //**********----Get Route ----***************
        $scope.loadRso = function (isPaging) {
            $("#ddlRso").select2("val", "");
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                ZoneId: $scope.Zone == null || $scope.Zone == 0 || $scope.Zone == undefined ? 0 : $scope.Zone,
                loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetRSOFromZone/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRso = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRso.then(function (response) {
                $scope.RsoList = response.data.objListRso;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        //$scope.loadRso(0);


        //**********----Get Retailer GPS----***************
        $scope.listRetailerGps = [];
        $scope.listRsoGps = [];
        $scope.RsoGpsOrigin = [];
        $scope.RsoGpsDestination = [];
        $scope.RsoWayPoints = [];
        $scope.GetRsoFootstraps = function () {

            $scope.IsMapShow = true;
            $scope.GetRSOLocation();

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                ZoneId: $scope.Zone == null || $scope.Zone == 0 || $scope.Zone == undefined ? 0 : $scope.Zone,
                RouteID: $scope.Rso == null || $scope.Rso == 0 || $scope.Rso == undefined ? 0 : $scope.Rso,
                RetailerId: $scope.Retailer == null || $scope.Retailer == 0 || $scope.Retailer == undefined ? 0 : $scope.Retailer,
                Date: $scope.VisitDate == "" || $scope.VisitDate == null ? null : conversion.getStringToDate($scope.VisitDate),
                //loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = DirectoryKey + '/SFTS/api/ViewRetailerLocation/GetRSORetailerGPS/';
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

            //$scope.showRsoInfo = function (event, rso) {
            //    $scope.rsoName = rso.NAME;
            //    $scope.map.showInfoWindow('rsoInfoWindow', this);
            //};

            $scope.showRetailerInfo = function (event, retailer) {
                $scope.retailerName = retailer.RETAILER_NAME;
                $scope.checkInTime = retailer.CHECKIN_TIME;
                $scope.checkoutFeedback = retailer.CHECKOUT_FEEDBACK;
                $scope.totalSalesAmount = retailer.TOTAL_SALES_AMOUNT;
                $scope.map.showInfoWindow('retailerInfoWindow', this);
            };

            if ($scope.listRetailerGps == null && $scope.listRsoGps == null) {
                $scope.IsMapNotAvail = true;
                $scope.IsMapShow = false;
                $scope.msgMapNotAvail = ' * Location is not available to show map!!'
            } else {
                $scope.IsMapNotAvail = false;
                $scope.IsMapShow = true;
            }
        };
        $scope.ExportExcelFile = function () {
            //$scope.GetRSOLocation();

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                ZoneId: $scope.Zone == null || $scope.Zone == 0 || $scope.Zone == undefined ? 0 : $scope.Zone,
                RouteID: $scope.Rso == null || $scope.Rso == 0 || $scope.Rso == undefined ? 0 : $scope.Rso,
                RetailerId: $scope.Retailer == null || $scope.Retailer == 0 || $scope.Retailer == undefined ? 0 : $scope.Retailer,
                Date: $scope.VisitDate == "" || $scope.VisitDate == null ? null : conversion.getStringToDate($scope.VisitDate),
                NoticeForId: 1
                //loggeduser: $scope.loggedUserId                              
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
        $scope.ExportExcelFileBTS = function () {
            //$scope.GetRSOLocation();

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                ZoneId: $scope.Zone == null || $scope.Zone == 0 || $scope.Zone == undefined ? 0 : $scope.Zone,
                RouteID: $scope.Rso == null || $scope.Rso == 0 || $scope.Rso == undefined ? 0 : $scope.Rso,
                RetailerId: $scope.Retailer == null || $scope.Retailer == 0 || $scope.Retailer == undefined ? 0 : $scope.Retailer,
                Date: $scope.VisitDate == "" || $scope.VisitDate == null ? null : conversion.getStringToDate($scope.VisitDate),
                NoticeForId: 1
                //loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = baseUrl + 'ExportExcelTemplateBTS/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var TargetItems = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            TargetItems.then(function (response) {
                window.open(DirectoryKey +'/UserFiles/Notification/' + response.data, '_blank', '');
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        //**********----Get RSO GPS----***************
        $scope.GetRSOLocation = function () {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                ZoneId: $scope.Zone == null || $scope.Zone == 0 || $scope.Zone == undefined ? 0 : $scope.Zone,
                RsoId: $scope.Rso,
                Date: $scope.VisitDate == "" || $scope.VisitDate == null ? null : conversion.getStringToDate($scope.VisitDate),
                //loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = baseUrl + 'GetRsoFootsteps/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRSOGps = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRSOGps.then(function (response) {
                $scope.listRsoGps = response.data.rsoGPS;
                var gpsCount = $scope.listRsoGps.length;
                if (gpsCount > 0) {
                    $scope.RsoGpsOrigin = [$scope.listRsoGps[0].VISIT_TIME_LAT, $scope.listRsoGps[0].VISIT_TIME_LONG]
                    $scope.RsoGpsDestination = [$scope.listRsoGps[gpsCount - 1].VISIT_TIME_LAT, $scope.listRsoGps[gpsCount - 1].VISIT_TIME_LONG]
                    $scope.RsoPoints = [];
                    for (var i = 0; i < gpsCount; i++) {
                        if (i != 0 && i != gpsCount - 1) {
                            $scope.RsoPoints.push(
                                   {
                                       location: {
                                           lat: $scope.listRsoGps[i].VISIT_TIME_LAT,
                                           lng: $scope.listRsoGps[i].VISIT_TIME_LONG
                                       },
                                       stopover: true
                                   }
                            );
                        }
                    }
                    $rootScope.wayPoints = $scope.RsoPoints;
                } else {
                    $scope.IsMapNotAvail = true;
                    $scope.IsMapShow = false;
                    $scope.msgMapNotAvail = ' * No data available to show map!!'
                }
             
                },
            function (error) {
                console.log("Error: " + error);
            });

        };

    }]);

