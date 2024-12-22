/**
 * ApproveStaffTargetReviseByRegionCtlr.js
 */
app.controller('ApproveStaffTargetReviseByRegionCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/ApproveStaffTargetRevise/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Staff Target Revise Reqest';
        $scope.IsCreateIcon = true;
        $scope.IsListIcon = false;
        $scope.IsStuffTargetDetailShow = false;
        $scope.btnShowDetail = false;
        $scope.IsbtnSaveDisabled = false;


        $scope.gridStaffTargetSummary = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;

        $scope.ShowHide = function () {
            if ($scope.IsStuffTargetDetailShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnRejectShow = false;
                    $scope.btnShowDetail = false;
                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Staff Target Revise Request';
                }
                else {
                    $scope.PageTitle = 'Staff Target Revise Request';
                    $scope.btnShowText = "Staff Target Revise Request";
                    $scope.btnSaveShow = true;
                    $scope.btnRejectShow = true;
                    $scope.btnSaveText = "Approve";
                    $scope.IsShow = false;
                    $scope.IsHidden = false;

                    $scope.IsCreateIcon = false;
                    $scope.IsListIcon = true;
                }
            } else {
                $scope.IsShow = true;
                $scope.btnSaveShow = false;
                $scope.btnRejectShow = false;
                $scope.IsStuffTargetDetailShow = false;
                $scope.IsQuestionListShow = false;
                $scope.btnShowDetail = false;
                $scope.IsCreateIcon = true;
                $scope.IsListIcon = false;
                $scope.PageTitle = 'Staff Target Revise Request';
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

       // GetPermission('01301');


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
        //  }


        //**********----Get All Staff Target----***************
        $scope.StaffTargetList = [];
        function loadAllStaffTarget(isPaging) {
            $scope.gridStaffTargetSummary.enableFiltering = true;
            $scope.gridStaffTargetSummary.enableGridMenu = true;

            // For Loading
            if (isPaging == 0)
                $scope.pagination.pageNumber = 1;

            //For Loading
            $scope.loaderMoreStaffTargetSummary = true;
            $scope.lblMessageForStaffTargetSummary = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridStaffTargetSummary = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "PERIOD_NAME", displayName: "Month", title: "Month", width: '17%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TARGET_ITEM_NAME", displayName: "Item Name", title: "Item Name", width: '37%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "VERSION", displayName: "Version", title: "Version", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TOTAL_TARGET_VALUE", displayName: "Total Target Value", title: "Total Target Value", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "APPROVE_STATUS", displayName: "Status", title: "Status", width: '14%', headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Action',
                        displayName: "Action",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '11%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<div style="padding-left: 10px">' +                                      
                                      '</span>' +
                                      '<span class="label label-info label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="View Detail" ng-click="grid.appScope.TargetRevise(row.entity)">' +
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
            var apiRoute = baseUrl + 'GetStaffTargetForApprove/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listFeedbackQuestionnaire = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listFeedbackQuestionnaire.then(function (response) {
                $scope.StaffTargetList = [];
                $scope.pagination.totalItems = response.data.recordsTotal;
                $scope.gridStaffTargetSummary.data = response.data.staffTargetList;
                $scope.loaderMoreStaffTargetSummary = false;
                $scope.StaffTargetList = response.data.staffTargetList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        loadAllStaffTarget(0);


        //**********----Target Revise----***************
        $scope.TargetRevise = function (dataModel) {
            //debugger           
            $scope.PageTitle = 'Staff Target Revise Approve';
            $scope.IsShow = false;
            $scope.IsHidden = true;
            $scope.IsStuffTargetDetailShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;
            $scope.btnShowDetail = true;
            $scope.btnRejectShow = true;
            $scope.btnSaveShow = true;
            $scope.btnSaveText = "Approve";
            $scope.btnShowText = "Show Revise Requests";

            $scope.hTargetId = dataModel.TARGET_ID;
            $scope.hVersion = dataModel.VERSION;
            $scope.ItemName = dataModel.TARGET_ITEM_NAME;
            $scope.TargetPeriod = dataModel.PERIOD_NAME;
            $scope.Version = dataModel.VERSION;
            $scope.TargetValue = dataModel.TOTAL_TARGET_VALUE;


            $scope.IsbtnSaveDisabled = false;
            $scope.revisedValueTxt = "Requested Value";
            $scope.loadStaffRequestedTarget($scope.hTargetId, $scope.hVersion)
      
        };

        $scope.loadStaffTargetRevise = function (targetId, version) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                TargetId: targetId,
                Version: version
            };

            var apiRoute = baseUrl + 'GetStaffTargetDetail/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listStaffTarget = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listStaffTarget.then(function (response) {
                $scope.StaffTargetList = [];
                $scope.StaffTargetList = response.data.staffTargeDetailtList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
  
        $scope.loadStaffRequestedTarget = function (targetId, version) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                TargetId: targetId,
                Version: version
            };

            var apiRoute = baseUrl + 'GetStaffRequestedTargetDetail/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listStaffTarget = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listStaffTarget.then(function (response) {
                $scope.StaffTargetList = [];
                $scope.StaffTargetList = response.data.staffTargeReqDetailtList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }


        //**********----Create New Record----***************
        $scope.save = function (actionType) {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '01302'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                //if (IsPermitted == true) {
                $scope.saveSTR(actionType);
                //} else {
                 //   Command: toastr["warning"]("You have no permission for this operation!");
                 //   return;
                //}
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.saveSTR = function (actionType) {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                TargetId: $scope.hTargetId,
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

            var SaveStaffTargetRevise = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveStaffTargetRevise.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Revise Request Sent Successfully!!!!");
                    $scope.clear();
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



        //**********----Delete Single Record----***************
        $scope.delete = function (dataModel) {
            var IsConf = confirm('You are about to delete ' + dataModel.OFFER_NAME + '. Are you sure?');
        }

        //**********----Reset Record----***************
        $scope.clear = function () {
            $scope.IsShow = true;
            $scope.IsStuffTargetDetailShow = false;
            $scope.btnSaveShow = false;
            $scope.btnRejectShow = false;
            $scope.btnShowDetail = false;
            $scope.hTargetId = '';
            $scope.hVersion = '';
            loadAllStaffTarget(0);
        };
    }]);

