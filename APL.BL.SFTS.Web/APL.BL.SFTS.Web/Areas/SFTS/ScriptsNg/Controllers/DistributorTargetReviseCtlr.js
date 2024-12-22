/**
 * DistributorTargetReviseCtrl.js
 */
app.controller('DistributorTargetReviseCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/DistributorTargetRevise/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.currentDate = $filter('date')(new Date(), 'dd/MM/yyyy');

        $scope.btnSaveText = "Submit";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing Targets';
        $scope.ListTitle = 'Target List';
        $scope.btnListShow = false;
        $scope.IsCreateIcon = false;
        $scope.IsListIcon = false;
        $scope.IsDetailShow = false;
        $scope.IsbtnSaveDisabled = false;

        $scope.gridOptionsDistTargetRevise = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;

        $scope.ShowHide = function () {
            if ($scope.IsDetailShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;
                    $scope.IsDetailShow = false;
                    $scope.btnListShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Existing Targets';
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Target Revise';
                    $scope.btnShowText = "Show Existing Targets";
                    $scope.btnSaveShow = true;
                    $scope.btnResetShow = true;
                    $scope.btnSaveText = "Submit";
                    $scope.IsShow = false;
                    $scope.IsHidden = false;
                    $scope.IsDetailShow = false;

                    $scope.IsCreateIcon = false;
                    $scope.IsListIcon = true;
                    $scope.loadDistTarget();
                }
            } else {
                $scope.IsShow = true;
                $scope.btnSaveShow = false;
                $scope.btnResetShow = false;
                $scope.IsDetailShow = false;
                $scope.btnListShow = false;
                $scope.IsCreateIcon = false;
                $scope.IsListIcon = false;
                $scope.PageTitle = 'Existing Targets';
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

        GetPermission('00901');


        //**********----Pagination----***************
        $scope.pagination = {
            paginationPageSizes: [15, 25, 50, 75, 100, 500, 1000, "All"],
            ddlpageSize: 15, pageNumber: 1, pageSize: 15, totalItems: 0,

            getTotalPages: function () {
                return Math.ceil(this.totalItems / this.pageSize);
            },
            pageSizeChange: function () {
                if (this.ddlpageSize == "All")
                    this.pageSize = $scope.pagination.totalItems;
                else
                    this.pageSize = this.ddlpageSize

                this.pageNumber = 1
                loadCustomerRecords(1);
            },
            firstPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber = 1
                    loadCustomerRecords(1);
                }
            },
            nextPage: function () {
                if (this.pageNumber < this.getTotalPages()) {
                    this.pageNumber++;
                    loadCustomerRecords(1);
                }
            },
            previousPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber--;
                    loadCustomerRecords(1);
                }
            },
            lastPage: function () {
                if (this.pageNumber >= 1) {
                    this.pageNumber = this.getTotalPages();
                    loadCustomerRecords(1);
                }
            }
        };

        //**********----Get All Customer Records----***************
        function loadDistTarget(isPaging) {
            $scope.gridOptionsDistTargetRevise.enableFiltering = true;
            $scope.gridOptionsDistTargetRevise.enableGridMenu = true;

            // For Loading
            if (isPaging == 0)
                $scope.pagination.pageNumber = 1;

            //For Loading
            $scope.loaderMoreDistTargetRevise = true;
            $scope.lblMessageForDistTargetRevise = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };


            $scope.gridOptionsDistTargetRevise = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,



                columnDefs: [
                    { name: "TARGET_ITEM_NAME", displayName: "Item Name", title: "Item Name", width: '30%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "PERIOD_NAME", displayName: "Target Period", title: "Target Period", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TARGET_VALUE", displayName: "Target Value", title: "Target Value", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TARGET_DETAIL_VERSION", displayName: "Version", title: "Version", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "STATUS_NAME", colorHexidecimalValue: "#aa873b", displayName: "Status", title: "Status", width: '17%', headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Action',
                        displayName: "Action",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '15%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<div style="padding-left: 10px">' +
                                      '<span ng-disabled="row.entity.APROVAL_STATUS != 0" class="label label-info label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="Revise" ng-click="grid.appScope.getDistTarget(row.entity)">' +
                                        '<i class="icon-edit" aria-hidden="true"></i> Revise' +
                                      '</a>' +
                                      '</span>' +
                                      '<span class="label label-success label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="View Detail" ng-click="grid.appScope.ViewTargetDetail(row.entity)">' +
                                        '<i class="icon-info-sign" aria-hidden="true"></i> View Detail' +
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
                exporterCsvFilename: 'DistributorTargetRevise.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "DistributorTargetRevise", style: 'headerStyle' },
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
            var apiRoute = baseUrl + 'GetDistributorTarget/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listDistTargetInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listDistTargetInfo.then(function (response) {

                $scope.pagination.totalItems = response.data.recordsTotal;
                $scope.gridOptionsDistTargetRevise.data = response.data.distributorTargetList;
                $scope.loaderMoreDistTargetRevise = false;
                $scope.DistTargetListList = response.data.distributorTargetList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        loadDistTarget(0);

        //**********----Get Single Record----***************
        $scope.getDistTarget = function (dataModel) {
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Target Revise';
            $scope.btnSaveText = "Submit";
            $scope.btnShowText = "Show Existing Targets";
            $scope.IsDetailShow = false;
            $scope.IsTListShow = false;
            $scope.btnSaveShow = true;
            $scope.btnResetShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;
            $scope.btnListShow = true;

            $scope.hTargetId = dataModel.TARGET_ID;
            $scope.hTargetDetailId = dataModel.TARGET_DETAIL_ID;
            $scope.hVersion = dataModel.TARGET_DETAIL_VERSION;
            $scope.hRevisionValidUpTo = dataModel.REVISION_VALID_UP_TO;

            if (dataModel.STATUS_NAME == "PENDING AT REGION" || dataModel.STATUS_NAME == "PENDING AT HO") {
                $scope.IsbtnSaveDisabled = true;
                $scope.loadDistRequestedTarget($scope.hTargetId, $scope.hVersion)
                Command: toastr["warning"]("Revise request pending for this target!!");
            } else {
                $scope.hTargetDetailId = dataModel.TARGET_DETAIL_ID;
                $scope.ItemName = dataModel.TARGET_ITEM_NAME;
                $scope.TargetPeriod = dataModel.PERIOD_NAME;
                $scope.Version = dataModel.TARGET_DETAIL_VERSION;
                $scope.TargetValue = dataModel.TARGET_VALUE;
            }
        };

        $scope.loadDistRequestedTarget = function (targetId, version) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
                TargetId: targetId,
                Version: version
            };

            var apiRoute = baseUrl + 'GetDistributorTargetReviseReq/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listStaffTarget = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listStaffTarget.then(function (response) {
                $scope.DistTargetReqList = [];
                $scope.DistTargetReqList = response.data.disTargetModReqList;

                $scope.ItemName = $scope.DistTargetReqList[0].TARGET_ITEM_NAME;
                $scope.TargetPeriod = $scope.DistTargetReqList[0].PERIOD_NAME;
                $scope.Version = $scope.DistTargetReqList[0].TARGET_DETAIL_VERSION;
                $scope.TargetValue = $scope.DistTargetReqList[0].TARGET_VALUE;
                $scope.RevisedTargetValue = $scope.DistTargetReqList[0].REVISED_TARGET_VALUE;
                $scope.Comment = $scope.DistTargetReqList[0].COMMENTS;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        //**********----View Target Detail----***************
        $scope.ViewTargetDetail = function (dataModel) {
            $scope.PageTitle = 'Target Detail';
            $scope.IsShow = false;
            $scope.IsHidden = true;
            $scope.IsDetailShow = true;
            $scope.IsQuestionListShow = true;
            $scope.btnShowText = "Show Existing Targets";
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;
            $scope.btnListShow = true;


            $scope.hTargetId = dataModel.TARGET_ID;
            $scope.hTargetDetailId = dataModel.TARGET_DETAIL_ID;
            $scope.ItemName = dataModel.TARGET_ITEM_NAME;
            $scope.TargetPeriod = dataModel.PERIOD_NAME;
            $scope.Version = dataModel.TARGET_DETAIL_VERSION;
            $scope.TargetValue = dataModel.TARGET_VALUE;
        };

        //**********----Create Revise----***************

        $scope.save = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '00902'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveDistributorTargetRevise();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });         
        };

        $scope.SaveDistributorTargetRevise = function () {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
                Version: $scope.hVersion
            };

            var TargetReviseInfo = {
                TargetId: $scope.hTargetId,
                TargetDetailId: $scope.hTargetDetailId,
                TargetValue: $scope.TargetValue,
                RevisedTargetValue: $scope.RevisedTargetValue,
                Comments: $scope.Comment,
            };

            var apiRoute = baseUrl + 'ReviseDistributorTarget/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(TargetReviseInfo) + "]";

            var SaveTargetRevise = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveTargetRevise.then(function (response) {
                if (response.data == "1") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;


                    loadDistTarget(0);
                }
                else if (response.data == "2") {
                    Command: toastr["warning"]("Revise request date has been expired!!");
                }
                else{
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
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;
            $scope.btnListShow = false;

            //$scope.btnShowText = "Show Existing Targets";
            $scope.hTargetId = 0;
            $scope.hTargetDetailId = 0;
            $scope.ItemName = '';
            $scope.TargetPeriod = '';
            $scope.Version = '';
            $scope.TargetValue = '';
            $scope.RevisedTargetValue = '';
            $scope.Comment = '';

            loadDistTarget(0);
        };
    }]);

