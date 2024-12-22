/**
 * ApproveDistributorTargetReviseByRegionCtlr.js
 */
app.controller('ApproveDistributorTargetReviseByRegionCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/ApproveDistributorTargetRevise/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Submit";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing Revise Requests';
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
                    $scope.btnRejectShow = false;
                    $scope.btnResetShow = false;
                    $scope.IsDetailShow = false;
                    $scope.btnListShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Existing Revise Requests';
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Approve Target Revise';
                    $scope.btnShowText = "Show Revise Request";
                    $scope.btnSaveShow = true;
                    $scope.btnRejectShow = true;
                    $scope.btnResetShow = true;
                    $scope.btnSaveText = "Approve";
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
                $scope.btnRejectShow = false;
                $scope.btnResetShow = false;
                $scope.IsDetailShow = false;
                $scope.btnListShow = false;
                $scope.IsCreateIcon = false;
                $scope.IsListIcon = false;
                $scope.PageTitle = 'Existing Revise Request';
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

       // GetPermission('00901');


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

            /* $scope.gridOptionsDistTargetRevise = {
                enableSorting: true,
                columnDefs: [
                  { name: 'color', field: 'colorHexidecimalValue', "cellTemplate": "<div class=\"ui-grid-cell-contents ng-scope ng-binding\" ng-style=\"{'background-color':COL_FIELD}\">" },
                  { name: 'name', field: 'name' },
                  { name: 'hexadecimalValue', field: 'colorHexidecimalValue' }

                ],
                data: [{
                    "colorHexidecimalValue": "#d2bcc2",
                    "name": "Color 1",
                },
                                {
                                    "colorHexidecimalValue": "#ee7351",
                                    "name": "Color 2",

                                },
                                {
                                    "colorHexidecimalValue": "#aa873b",
                                    "name": "Color 3"
                                },
                                {
                                    "colorHexidecimalValue": "#9bb1a5",
                                    "name": "Color 4"
                                },
                                {
                                    "colorHexidecimalValue": "#1c77d4",
                                    "name": "Color 5"
                                },
                                {
                                    "colorHexidecimalValue": "#f39c34",
                                    "name": "Color 6"
                                },
                                {
                                    "colorHexidecimalValue": "#32d6f4",
                                    "name": "Color 7"
                                }, {
                                    "colorHexidecimalValue": "#798bf6",
                                    "name": "Color 8"
                                },
                                {
                                    "colorHexidecimalValue": "#1d954f",
                                    "name": "Color 9"
                                },
                                {
                                    "colorHexidecimalValue": "#24e1ac",
                                    "name": "Color 10"
                                },
                                {
                                    "colorHexidecimalValue": "#f7fb26",
                                    "name": "Color 11"
                                },

                               {
                                   "colorHexidecimalValue": "#dbbac1",
                                   "name": "Color 12"
                               },
                                {
                                    "colorHexidecimalValue": "#6f765d",
                                    "name": "Color 13"
                                },
                                {
                                    "colorHexidecimalValue": "#75e93f",
                                    "name": "Color 14"
                                },
                                {
                                    "colorHexidecimalValue": "#93aecc",
                                    "name": "Color 15"
                                },
                                {
                                    "colorHexidecimalValue": "#7357e4",
                                    "name": "Color 16"
                                },
                                {
                                    "colorHexidecimalValue": "#4bdc9b",
                                    "name": "Color 17"
                                },
                                {
                                    "colorHexidecimalValue": "#2e66af",
                                    "name": "Color 18"
                                }, {
                                    "colorHexidecimalValue": "#e347be",
                                    "name": "Color 19"
                                },
                                {
                                    "colorHexidecimalValue": "#4fe002",
                                    "name": "Color 20"
                                },
                                {
                                    "colorHexidecimalValue": "#b6f6b1",
                                    "name": "Color 21"
                                },
                                {
                                    "colorHexidecimalValue": "#fedcde",
                                    "name": "Color 22"
                                }


                ]
            };*/

            $scope.gridOptionsDistTargetRevise = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,



                columnDefs: [
                    { name: "DISTRIBUTOR_NAME", displayName: "Distributor", title: "Distributor", width: '17%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TARGET_ITEM_NAME", displayName: "Item Name", title: "Item Name", width: '35%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "PERIOD_NAME", displayName: "Target Period", title: "Target Period", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TARGET_VALUE", displayName: "Target Value", title: "Target Value", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TARGET_DETAIL_VERSION", displayName: "Version", title: "Version", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Action',
                        displayName: "Action",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '10%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<div style="padding-left: 10px">' +
                                      '<span ng-disabled="row.entity.APROVAL_STATUS != 0" class="label label-info label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="View Detail" ng-click="grid.appScope.getDistTarget(row.entity)">' +
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
                exporterCsvFilename: 'Customer.csv',
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
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
                UserType: 2
            };
            var apiRoute = baseUrl + 'GetDistributorTargetForApprove/';

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
            $scope.PageTitle = 'Approve Target Revise';
            $scope.btnSaveText = "Approve";
            $scope.btnShowText = "Show Revise Request";
            $scope.IsDetailShow = false;
            $scope.IsTListShow = false;
            $scope.btnSaveShow = true;
            $scope.btnRejectShow = true;
            $scope.btnResetShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;
            $scope.btnListShow = true;

            $scope.hTargetId = dataModel.TARGET_ID;
            $scope.hTargetDetailId = dataModel.TARGET_DETAIL_ID;
            $scope.hVersion = dataModel.TARGET_DETAIL_VERSION;

            if (dataModel.STATUS_NAME == "PENDING AT REGION" || dataModel.STATUS_NAME == "PENDING AT HO") {
                $scope.loadDistRequestedTarget($scope.hTargetId, $scope.hVersion)
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
            //debugger
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

        $scope.save = function (actionType) {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: ''
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {

                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                //if (IsPermitted == true) {
                    $scope.ApproveDistributorTargetRevise(actionType);
                //} else {
                  //  Command: toastr["warning"]("You have no permission for this operation!");
                  //  return;
               // }
            },
            function (error) {
                console.log("Error: " + error);
            });         
        };

        $scope.ApproveDistributorTargetRevise = function (actionType) {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                Version: $scope.hVersion,
                UserType: 2
            };

            var ApproveReviseRequest = {
                TargetId: $scope.hTargetId,
                ActionType: actionType,
                ApproverComment: $scope.ApproverComments,
            };

            var apiRoute = baseUrl + 'ApproveReviseRequest/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(ApproveReviseRequest) + "]";

            var SaveDistTargetRevise = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveDistTargetRevise.then(function (response) {
                // debugger;
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnRejectShow = false;

                    loadDistTarget(0);
                }
                else if (response.data == "") {
                        Command: toastr["warning"]("Save Not Successfull!!!!");
                    $("#save").prop("disabled", false);
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

