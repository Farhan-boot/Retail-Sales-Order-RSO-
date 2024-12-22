/**
* FocProductCtlr.js
*/
app.controller('AchievementPointCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/AchievementPoint/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing Achievement Point';
        $scope.ListTitle = 'Achievement Point List';
        $scope.IsCreateIcon = true;
        $scope.IsListIcon = false;
        $scope.IsAchievementPointShow = false;
        $scope.gridOptionsAchievementPoints = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;

        $scope.ShowHide = function () {
            if ($scope.IsAchievementPointShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.btnShowText = "Create";
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Existing Achievement Points';
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Add New Achievement Point';
                    $scope.btnShowText = "Show List";
                    $scope.btnSaveShow = true;
                    $scope.btnResetShow = true;
                    $scope.btnSaveText = "Save";
                    $scope.IsShow = false;
                    $scope.IsHidden = false;

                    $scope.IsCreateIcon = false;
                    $scope.IsListIcon = true;
                }
            } else {
                $scope.btnShowText = "Create";
                $scope.IsShow = true;
                $scope.btnSaveShow = false;
                $scope.btnResetShow = false;
                $scope.IsCreateIcon = true;
                $scope.IsListIcon = false;
                $scope.PageTitle = 'Existing Achievement Point';
            }
        }

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
                    window.location.href = DirectoryKey + "/SFTS/NoPermission";
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }

        GetPermission('04013');


        //**********----Get All TradeMaterials----***************
        function loadAchievementPoints(isPaging) {

            $scope.gridOptionsAchievementPoints.enableFiltering = true;
            $scope.gridOptionsAchievementPoints.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreAchievementPoints = true;
            $scope.lblMessageForAchievementPoints = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsAchievementPoints = {
                useExternalSorting: false,
                enableSorting: true,
                useExternalPagination: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "POINT_NAME", displayName: "POINT NAME", title: "POINT NAME", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "POINT_CODE", displayName: "POINT CODE", title: "POINT CODE", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "POINT_SCORE", displayName: "POINT SCORE", title: "POINT SCORE", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "IS_ACTIVE_STR", displayName: "IS ACTIVE", title: "IS ACTIVE", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Action',
                        displayName: "Action",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '12%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<div style="padding-left: 10px">' +
                            '<span class="label label-info label-mini" style="text-align:center !important;">' +
                            '<a href="" title="Edit" ng-click="grid.appScope.getAchievementPoint(row.entity)">' +
                            '<i class="icon-edit" aria-hidden="true"></i> Edit' +
                            '</a>' +
                            '</span>' +
                            '<span class="label label-warning label-mini" style="text-align:center !important;">' +
                            '<a href="" title="Delete" ng-click="grid.appScope.delete(row.entity)">' +
                            '<i class="icon-trash" aria-hidden="true"></i> Delete' +
                            '</a>' +
                            '</span>' +
                            '</div>'
                    }
                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: true,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'Trade Materials.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Trade Materials", style: 'headerStyle' },
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
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetAchievementPoints/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var AchievementPointList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            AchievementPointList.then(function (response) {
                $scope.gridOptionsAchievementPoints.data = response.data.achievementPointList;
                $scope.loaderMoreAchievementPoints = false;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };
        loadAchievementPoints(0);

        //**********----Get Single Record----***************
        $scope.getAchievementPoint = function (dataModel) {
            //debugger
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Update Achievement Point';
            $scope.btnSaveText = "Update";
            $scope.btnShowText = "Show List";
            $scope.btnSaveShow = true;
            $scope.btnResetShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;

          
            $scope.hAchievementPointId = dataModel.POINT_ID;
            $scope.PointName = dataModel.POINT_NAME;
            $scope.PointCode = dataModel.POINT_CODE;
            $scope.PointScore = dataModel.POINT_SCORE;
            $scope.IsActive = dataModel.IS_ACTIVE;


        };




        //**********----Create New TradeMaterial----***************

        $scope.save = function () {
           
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '04014'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveAchievementPoint();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };

        $scope.SaveAchievementPoint = function () {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };

            var AchievementPoint = {
                PointId: $scope.hAchievementPointId === undefined || $scope.hAchievementPointId === null ? 0 : $scope.hAchievementPointId,
                PointName: $scope.PointName,
                PointCode: $scope.PointCode,
                PointScore: $scope.PointScore,
                IsActive: $scope.IsActive
            };


            var apiRoute = baseUrl + 'SaveAchievementPoint/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(AchievementPoint) + "]";

            var SaveUpdateAchievementPoint = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateAchievementPoint.then(function (response) {
                if (response.data != "") {

                    if (response.data == "10") {
                        Command: toastr["warning"]("Data already exists!!!!");
                    }
                    else {
                        Command: toastr["success"]("Save  Successfully!!!!");
                        $scope.clear();
                        $scope.IsHidden = true;
                        $scope.IsShow = true;
                        $scope.btnShowText = "Create";
                        $scope.PageTitle = 'Add New Achievement Point';
                        $scope.btnSaveShow = false;
                        $scope.btnResetShow = false;
                        $scope.IsCreateIcon = true;
                        $scope.IsListIcon = false;
                        loadAchievementPoints(0);
                    }
                }
                else if (response.data == "") {
                    Command: toastr["warning"]("Save Not Successfull!!!!");
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }

        $scope.delete = function (dataModel) {
            var isDelete = confirm('You are about to delete ' + dataModel.POINT_NAME + '. Are you sure?');
            if (isDelete == true) {
                objcmnParam = {
                    pageNumber: page,
                    pageSize: pageSize,
                    IsPaging: isPaging,
                    loggeduser: $scope.loggedUserId
                };

           
                var PointInfo = {
                    PointId: dataModel.POINT_ID
                };
                var apiRoute = baseUrl + 'DeleteInfo/';

                var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(PointInfo) + "]";

                var deleteInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
                deleteInfo.then(function (response) {
                    // debugger;
                    if (response.data != "") {
                        Command: toastr["success"]("Delete  Successfully!!!!");
                        loadAchievementPoints(0);
                    }
                    else if (response.data == "") {
                        Command: toastr["warning"]("Delete Not Successfull!!!!");
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });
            }
        }

        $scope.GroupFor = 1;
        $scope.IsActive = 1;
        //**********----Reset Record----***************
        $scope.clear = function () {
            $scope.IsHidden = true;
            $scope.IsShow = true;
            $scope.IsHiddenDetail = true
            $scope.IsCreateIcon = true;
            $scope.IsListIcon = false;

            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Create";

            $scope.hAchievementPointId = 0;
            $scope.PointName = '';
            $scope.PointCode = '';
            $scope.PointScore = '';
            $scope.IsActive = 1;

            loadAchievementPoints(0);
        };
    }]);

