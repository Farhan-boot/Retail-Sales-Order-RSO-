/**
 * VisitFeedbackStatusCtlr.js
 */
app.controller('VisitFeedbackStatusCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/VisitFeedbackStatus/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing Visit Feedback Status';
        $scope.ListTitle = 'Visit Feedback Status List';
        $scope.IsCreateIcon = true;
        $scope.IsListIcon = false;
        $scope.IsUpdateTypeShow = false;

        $scope.gridOptionsVisitFeedbackStatus = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;

        $scope.ShowHide = function () {
            if ($scope.IsUpdateTypeShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.btnShowText = "Create";
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Existing Visit Feedback Status';
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Add New Visit Feedback Status';
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
                $scope.PageTitle = 'Existing Visit Feedback Status';
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

        GetPermission('01901');

        //**********----GetVisit Feedback Statuss----***************
        function loadVisitFeedbackStatus(isPaging) {
            $scope.gridOptionsVisitFeedbackStatus.enableFiltering = true;
            $scope.gridOptionsVisitFeedbackStatus.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreVisitFeedbackStatus = true;
            $scope.lblMessageForVisitFeedbackStatus = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsVisitFeedbackStatus = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "STATUS_DESCRIPTION", displayName: "Visit Feedback Status English", title: "Visit Feedback Status English", width: '45%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "STATUS_DESCRIPTION_BAN", displayName: "Visit Feedback Status Bangla", title: "Visit Feedback Status Bangla", width: '45%', headerCellClass: $scope.highlightFilteredHeader },

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
                                      '<a href="" title="Edit" ng-click="grid.appScope.getVisitFeedbackStatus(row.entity)">' +
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
                exporterCsvFilename: 'VisitFeedbackStatus.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Customer", style: 'headerStyle' },
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
                VisitFeedbackStatusId: 0
            };
            var apiRoute = baseUrl + 'GetVisitFeedbackStatuses/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listMarketUpdate = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listMarketUpdate.then(function (response) {
                $scope.gridOptionsVisitFeedbackStatus.data = response.data.visitFeedbackStatusList;
                $scope.loaderMoreVisitFeedbackStatus = false;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };
        loadVisitFeedbackStatus(0);

        //**********----Get Single Record----***************
        $scope.getVisitFeedbackStatus = function (dataModel) {
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Update Visit Feedback Status';
            $scope.btnSaveText = "Update";
            $scope.btnShowText = "Show List";
            $scope.btnSaveShow = true;
            $scope.btnResetShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;


            $scope.hVisitFeedbackStatusId = dataModel.ID;
            $scope.StatusDescription = dataModel.STATUS_DESCRIPTION;
            $scope.StatusDescriptionBAN = dataModel.STATUS_DESCRIPTION_BAN;
            $scope.IsActive = dataModel.IS_ACTIVE == "Active" ? true : false;
        };

        //**********----Create New Event----***************
        $scope.save = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '01902'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                 if (IsPermitted == true) {
                    $scope.SaveVisitFeedbackStatus();
                 } else {
                  Command: toastr["warning"]("You have no permission for this operation!");
                  return;
                 }
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.SaveVisitFeedbackStatus = function () {

            objcmnParam = {
                loggeduser: $scope.loggedUserId,
            };

            var VisitFeedbackStatusInfo = {
                Id: $scope.hVisitFeedbackStatusId == undefined || $scope.hVisitFeedbackStatusId == null ? 0 : $scope.hVisitFeedbackStatusId,
                StatusDescription: $scope.StatusDescription,
                StatusDescriptionBAN : $scope.StatusDescriptionBAN
            };

            var apiRoute = baseUrl + 'SaveUpdateVisitFeedbackStaus/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(VisitFeedbackStatusInfo) + "]";

            var CreateVisitFeedbackStatus = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            CreateVisitFeedbackStatus.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnShowText = "Create";
                    $scope.PageTitle = 'Add New Visit Feedback Status';
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;
                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    loadVisitFeedbackStatus(0);
                }
                else if (response.data == "") {
                        Command: toastr["warning"]("Save Not Successfull!!!!");
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        //**********----Reset Record----***************
        $scope.clear = function () {
            $scope.IsHidden = true;
            $scope.IsShow = true;
            $scope.IsHiddenDetail = true
            $scope.IsCreateIcon = true;
            $scope.IsListIcon = false;

            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Create";

            $scope.hVisitFeedbackStatusId = 0;
            $scope.StatusDescription = '';
            $scope.StatusDescriptionBAN = '';
            $scope.IsActive = false;

            loadVisitFeedbackStatus(0);
        };
    }]);

