/**
 * AttendanceSummary2Ctlr.js
 */

app.controller('AttendanceSummary2Ctlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTSReports/api/AttendanceSummary2/';

        $scope.PageTitle = 'Attendance Summary2';
        $scope.gridOptionsAttendanceSummary2 = [];

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
        GetPermission('04033');

        //**********----Get User Work Area ----***************
        var isRegionalUser = 0;



        //**********----Get Sales And Daily Attendance----***************
        $scope.GetAttendanceSummary2 = function () {
            $scope.gridOptionsAttendanceSummary2.enableFiltering = false;
            $scope.gridOptionsAttendanceSummary2.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreAttendanceSummary2 = true;
            $scope.lblMessageForAttendanceSummary2 = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsAttendanceSummary2 = {
                useExternalSorting: false,
                enableSorting: true,
                useExternalPagination: true,
                enableFiltering: false,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "ATT_DATE", displayName: "Date", title: "Date", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RSO_CODE", displayName: "RSO Code", title: "RSO Code", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SR_NO", displayName: "SR No", title: "SR No", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CHK_REASON", displayName: "Checkout Reason", title: "Checkout Reason", width: '27%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RETAILER_COUNT", displayName: "Retailer Count", title: "Retailer Count", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TOTAL_SALES", displayName: "Total Sales", title: "Total Sales", width: '12%', headerCellClass: $scope.highlightFilteredHeader },

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
            };



            var apiRoute = baseUrl + 'GetAttendanceSummary2/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var tva = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            tva.then(function (response) {
                $scope.tvaList = response.data.AttendanceSummary2;
                $scope.gridOptionsAttendanceSummary2.data = response.data.AttendanceSummary2;
                $scope.loaderMoreAttendanceSummary2 = false;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }

        //$scope.GetAttendanceSummary2();
        $scope.ExportExcelFile = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
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
    }]);

