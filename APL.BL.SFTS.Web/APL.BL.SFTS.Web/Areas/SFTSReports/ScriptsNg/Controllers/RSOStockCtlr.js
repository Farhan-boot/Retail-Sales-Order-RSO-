/**
 * RSOStockCtlr.js
 */

app.controller('RSOStockCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTSReports/api/RSOStock/';

        $scope.PageTitle = 'RSO Stock';
        $scope.gridOptionsRSOStock = [];

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
        


        //**********----Get Sales And Daily Attendance----***************
        $scope.GetRSOStock = function () {
            $scope.gridOptionsRSOStock.enableFiltering = false;
            $scope.gridOptionsRSOStock.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreRSOStock = true;
            $scope.lblMessageForRSOStock = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsRSOStock = {
                useExternalSorting: false,
                enableSorting: true,
                useExternalPagination: true,
                enableFiltering: false,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "TDATE", displayName: "DATE", title: "DATE", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RSO_CODE", displayName: "RSO CODE", title: "RSO CODE", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "PRODUCT_NAME", displayName: "PRODUCT NAME", title: "PRODUCT NAME", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "PRODUCT_QTY", displayName: "PRODUCT QTY", title: "PRODUCT QTY", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SALES_QTY", displayName: "SALES QTY", title: "SALES QTY", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "BALANCE", displayName: "BALANCE", title: "BALANCE", width: '12%', headerCellClass: $scope.highlightFilteredHeader },

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


            var apiRoute = baseUrl + 'GetRSOStock/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var tva = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            tva.then(function (response) {
                $scope.tvaList = response.data.RSOStock;
                $scope.gridOptionsRSOStock.data = response.data.RSOStock;
                $scope.loaderMoreRSOStock = false;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }

        //$scope.GetRSOStock();
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

