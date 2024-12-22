/**
 * SpecialReportCtlr.js
 */

app.controller('SpecialReportCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTSReports/api/SpecialReport/';

        $scope.PageTitle = 'Special Report';
        $scope.gridOptionsSpecialReport = [];

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
        GetPermission('04039');

        //**********----Get User Work Area ----***************
        var isRegionalUser = 0;



        //**********----Get Sales And Daily Attendance----***************
        $scope.GetSpecialReport = function () {
            $scope.gridOptionsSpecialReport.enableFiltering = false;
            $scope.gridOptionsSpecialReport.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreSpecialReport = true;
            $scope.lblMessageForSpecialReport = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsSpecialReport = {
                useExternalSorting: false,
                enableSorting: true,
                useExternalPagination: true,
                enableFiltering: false,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "RSO_CODE", displayName: "RSO CODE", title: "RSO CODE", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SR_NO", displayName: "SR_NO", title: "SR NO", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRIBUTOR_CODE", displayName: "DISTRIBUTOR CODE", title: "DISTRIBUTOR CODE", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RSO_APP_VERSION", displayName: "RSO APP VERSION", title: "RSO APP VERSION", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "REGISTRATION_DATE", displayName: "REGISTRATION DATE", title: "REGISTRATION DATE", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "IMEI", displayName: "DEVICE IMEI", title: "DEVICE IMEI", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "UNIQUE_SL", displayName: "DEVICE UNIQUE SL", title: "DEVICE UNIQUE SL", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "LAST_LOGIN_DATE_TIME", displayName: "LAST LOGIN DATE/TIME", title: "LAST LOGIN DATE/TIME", width: '16%', headerCellClass: $scope.highlightFilteredHeader },
                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: false,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'RSO Stock.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "RSO Stock", style: 'headerStyle' },
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
                ZoneId: $scope.ZoneId
            };


            var apiRoute = baseUrl + 'GetSpecialReport/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var tva = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            tva.then(function (response) {
                $scope.tvaList = response.data.SpecialReport;
                $scope.gridOptionsSpecialReport.data = response.data.RSOStock;
                $scope.loaderMoreSpecialReport = false;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        $scope.loadZones = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                IsZonalUser: 0,
                RegionId: 0
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CommissionStructure/'+ '/GetRegions/';// '/mDMS/SFTSReports/api/Common/GetZones/';
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
        //$scope.GetSpecialReport();
        $scope.ExportExcelFile = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                FromDate: $scope.FromDate == "" || $scope.FromDate == null ? null : conversion.getStringToDate($scope.FromDate),
                ToDate: $scope.ToDate == "" || $scope.ToDate == null ? null : conversion.getStringToDate($scope.ToDate),
                ZoneId: $scope.ZoneId
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
    }]);

