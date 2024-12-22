/**
 * SurveyResultCtlr.js
 */

app.controller('SurveyResultCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTSReports/api/SurveyResult/';

        $scope.PageTitle = 'Survey Result';
        $scope.gridOptionsSurveyResult = [];

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
        GetPermission('04027');

        //**********----Get User Work Area ----***************
        var isRegionalUser = 0;



        //**********----Get Sales And Daily Attendance----***************
        $scope.GetSurveyResult = function () {
            $scope.gridOptionsSurveyResult.enableFiltering = false;
            $scope.gridOptionsSurveyResult.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreSurveyResult = true;
            $scope.lblMessageForSurveyResult = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsSurveyResult = {
                useExternalSorting: false,
                enableSorting: true,
                useExternalPagination: true,
                enableFiltering: false,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "SURVEY_NAME", displayName: "Survey Name", title: "Survey Name", width: '25%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RES_DATE", displayName: "Response Date", title: "Response Date", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "USER_CODE", displayName: "User Code", title: "User Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "USER_NAME", displayName: "User Name", title: "User Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SV_QST", displayName: "Survey Question", title: "Survey Question", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SV_ANS", displayName: "Survey Answer", title: "Survey Answer", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
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

            objSearchParam = {
                SurveyId: $scope.SurveyId,
            }

            var apiRoute = baseUrl + 'GetSurveyResult/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(objSearchParam) + "]";

            var tva = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            tva.then(function (response) {
                $scope.tvaList = response.data.SurveyResult;
                $scope.gridOptionsSurveyResult.data = response.data.RSOStock;
                $scope.loaderMoreSurveyResult = false;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        function loadSurveys(isPaging) {
            objcmnParam = {
                pageNumber: 0,
                pageSize: 0,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId
            };

            var apiRoute = baseUrl + '/GetSurveyList'; //'/mDMS/SFTS/api/CmnDropdown/GetRegions/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var surveyList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            surveyList.then(function (response) {
                if (response.data.surveyList.length > 0) {
                    $scope.surveyList = response.data.surveyList;
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        loadSurveys(0);
        //$scope.GetSurveyResult();
        $scope.ExportExcelFile = function () {
            objSearchParam = {
                SurveyId: $scope.SurveyId,
            }

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

