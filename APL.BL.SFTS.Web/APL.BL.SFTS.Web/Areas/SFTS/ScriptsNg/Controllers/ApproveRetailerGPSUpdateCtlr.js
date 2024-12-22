/**
 * ApproveRetailerGPSUpdateCtlr.js
 */

app.controller('ApproveRetailerGPSUpdateCtlr', ['NgMap', '$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function (NgMap, $scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/ApproveRetailerGPSUpdate/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Approve";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Retailer GPS Update Requests';
        $scope.ListTitle = 'Retailer GPS Update List';
        $scope.btnListShow = false;
        $scope.IsCreateIcon = false;
        $scope.IsListIcon = false;
        $scope.IsDetailShow = false;
        $scope.IsQuestionListShow = false;
        $scope.SaveQuestion = "Save";
        $scope.IsMapShow = false;

        $scope.gridOptionsApproveRetailerGPSUpdate = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;

        $scope.ShowHide = function () {
            if ($scope.IsDetailShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnRejectShow = false;
                    $scope.IsDetailShow = false;
                    $scope.btnListShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Retailer GPS Update Requests';
                    $scope.IsMapShow = false;
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Retailer GPS Update Approval';
                    $scope.btnShowText = "Show Retailer GPS Update Requests";
                    $scope.btnSaveShow = true;
                    $scope.btnRejectShow = true;
                    $scope.btnSaveText = "Approve";
                    $scope.IsShow = false;
                    $scope.IsHidden = false;
                    $scope.IsDetailShow = false;

                    $scope.IsCreateIcon = false;
                    $scope.IsListIcon = true;
                    $scope.loadRetailerGPSUpdateReq();
                }
            } else {                
                $scope.IsShow = true;
                $scope.btnSaveShow = false;
                $scope.btnRejectShow = false;
                $scope.IsDetailShow = false;
                $scope.btnListShow = false;
                $scope.IsCreateIcon = false;
                $scope.IsListIcon = false;
                $scope.PageTitle = 'Retailer GPS Update Requests';
            }
        }

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

        GetPermission('00201');

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

        $scope.modal_ConfShow = function (confdata) {
            $scope.UserCommonEntity.EnableYes = false;
            $scope.UserCommonEntity.ValidateSave = false;
            $scope.UserCommonEntity.EnableConf = true;
            $scope.UserCommonEntity.DelMsgs = confdata;
            $('#ConfirmAlertModal').modal({ show: true, backdrop: "static", keyboard: "false" });
        }

        $scope.DataEntity = '';
        $scope.CallSave = function (dataModel) {
            $scope.DataEntity = dataModel;
            var ConfMessage = "You are about to Approve this/these record(s) now.";
            $scope.modal_ConfShow(ConfMessage);
        }

        $scope.IsConfirm = function () {
            $scope.UserCommonEntity.message = 'Approved';
            $scope.GetRetailerGPSDetail($scope.DataEntity);
        }

 
        //**********----Get All New Retailer Records----***************
        function loadRetailerGPSUpdateReq(isPaging) {
            $scope.gridOptionsApproveRetailerGPSUpdate.enableFiltering = true;
            $scope.gridOptionsApproveRetailerGPSUpdate.enableGridMenu = true;

            // For Loading
            if (isPaging == 0)
                $scope.pagination.pageNumber = 1;

            //For Loading
            $scope.loaderMoreApproveRetailerGPSUpdate = true;
            $scope.lblMessageForApproveRetailerGPSUpdate = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };         
           
            $scope.gridOptionsApproveRetailerGPSUpdate = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "RETAILER_CODE", displayName: "Retailer Code", title: "Retailer Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRIBUTOR_NAME", displayName: "Distributor", title: "Distributor", width: '27%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RETAILER_NAME", displayName: "Retailer Name", title: "Retailer Name", width: '27%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "REQUESTED_DATE", displayName: "Request Date", title: "Request Date", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "REQUEST_STATUS_NAME", displayName: "Status", title: "Status", width: '16%', headerCellClass: $scope.highlightFilteredHeader },
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
                                      '<span class="label label-info label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="View Detail & Take Action" ng-click="grid.appScope.GetRetailerGPSDetail(row.entity)">' +
                                        '<i class="icon-info-sign" aria-hidden="true"></i> View Detail' +
                                      '</a>' +
                                      '</span>' +
                                      //'<span class="label label-success label-mini" style="text-align:center !important;">' +
                                      //'<a href="" title="View Detail" ng-click="grid.appScope.RetailerGPSDetail(row.entity)">' +
                                      //  '<i class="icon-search" aria-hidden="true"></i> View Detail' +
                                      //'</a>' +
                                      //'</span>' +                           
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
            };
            var apiRoute = baseUrl + 'GetRetailerGPSUpdateRequest/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listDistTargetInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listDistTargetInfo.then(function (response) {
                $scope.pagination.totalItems = response.data.recordsTotal;
                $scope.gridOptionsApproveRetailerGPSUpdate.data = response.data.retailerGPSUpdateReq;
                $scope.loaderMoreApproveRetailerGPSUpdate = false;
                $scope.RetailerGPSUpdateRequestList = response.data.retailerGPSUpdateReq;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        loadRetailerGPSUpdateReq(0);


        //**********----Get Single Record----***************
        $scope.GetRetailerGPSDetail = function (dataModel) {
            //debugger
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Retailer GPS Update Approval';
            $scope.btnSaveText = "Approve";
            $scope.btnShowText = "Show Request List";
            $scope.IsDetailShow = false;
            $scope.IsTListShow = false;
            $scope.btnSaveShow = true;
            $scope.btnRejectShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;
            $scope.btnListShow = true;
            $scope.IsMapShow = true;

            $scope.hRetailerModifyId = dataModel.ID;
            $scope.RetailerCode = dataModel.RETAILER_CODE;
            $scope.Distributor = dataModel.DISTRIBUTOR_NAME;
            $scope.RetailerName = dataModel.RETAILER_NAME;
            //$scope.Address = dataModel.ADDRESS;
            $scope.RequesterComments = dataModel.REQUESTERS_COMMENTS;
            $scope.RequestDate = dataModel.REQUESTED_DATE;
            $scope.OldlatValue = dataModel.OLD_LAT;
            $scope.OldlongValue = dataModel.OLD_LONG;
            $scope.NewlatValue = dataModel.NEW_LAT;
            $scope.NewlongValue = dataModel.NEW_LONG;

            var OldPinColor = "F58635";
            var NewPinColor = "DC143C";
            $scope.OldPinImage = new google.maps.MarkerImage("http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|" + OldPinColor);
            $scope.NewPinImage = new google.maps.MarkerImage("http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|" + NewPinColor);

            if ($scope.OldlatValue == undefined || $scope.OldlatValue == null || $scope.OldlatValue == 0 || $scope.NewlatValue == undefined || $scope.NewlatValue == null || $scope.NewlatValue == 0,
                $scope.OldlongValue == undefined || $scope.OldlongValue == null || $scope.OldlongValue == 0 || $scope.NewlongValue == undefined || $scope.NewlongValue == null || $scope.NewlongValue == 0)
            {
                debugger
                $scope.IsMapNotAvail = true;
                $scope.IsMapShow = true;
                //$scope.msgMapNotAvail = ' * Location is not available to show map!!'
                $scope.IsOldLocationShow = false;
            } else {
                $scope.IsMapNotAvail = false;
                $scope.IsMapShow = true;
            }

            $scope.maxZoomForSinglePOI = 20;

            NgMap.getMap().then(function (map) {
                if (map.getZoom() > $scope.maxZoomForSinglePOI) {
                    map.setZoom($scope.maxZoomForSinglePOI);
                }
            });

            $scope.IsRejectDisabled = false;
            $scope.IsSaveDisabled = false;
            $scope.IsCommentDisabled = false;
            $scope.ApproverComments = '';

            if (dataModel.REQUEST_STATUS != 1) {
                $scope.IsRejectDisabled = true;
                $scope.IsSaveDisabled = true;
                $scope.ApproverComments = dataModel.APPROVERS_COMMENTS;
                //$scope.IsCommentDisabled = true;

            } else if (dataModel.REQUEST_STATUS == 1) {
                $scope.IsRejectDisabled = false;
                $scope.IsSaveDisabled = false;
                //$scope.IsCommentDisabled = false;
                $scope.ApproverComments = '';
            }
            
        };


        //**********----Retailer GPS Update Approval----***************


        $scope.save = function (actionType) {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '00202'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveGPSUpdate(actionType);
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.SaveGPSUpdate = function (actionType) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };
            $scope.ApproverComments = "";
            var RetailerGPSApprovalInfo = {
                RetailerModifyId: $scope.hRetailerModifyId,
                ActionType: actionType,
                ApproverComment: $scope.ApproverComments,
            };

            var apiRoute = baseUrl + 'ApproveRetailerGPSUpdate/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(RetailerGPSApprovalInfo) + "]";

            var SaveRetailerGPSApproval = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveRetailerGPSApproval.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;


                    loadRetailerGPSUpdateReq(0);
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
            $scope.btnRejectShow = false;
            $scope.IsMapShow = false;
            $scope.PageTitle = 'Retailer GPS Update Requests';
            $scope.hTargetId = 0;
            $scope.hTargetDetailId = 0;
            $scope.ItemName = '';
            $scope.TargetPeriod = '';
            $scope.Version = '';
            $scope.TargetValue = '';
            $scope.RevisedTargetValue = '';
            $scope.Comment = '';            

            loadRetailerGPSUpdateReq(0);
        };
    }]);

