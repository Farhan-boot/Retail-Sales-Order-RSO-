/**
 * ApproveRetailerInfoUpdateCtlr.js
 */

app.controller('ApproveRetailerInfoUpdateCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/ApproveRetailerInfoUpdate/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Approve";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Retailer Info Update Requests';
        $scope.ListTitle = 'Retailer Info Update List';
        $scope.btnListShow = false;
        $scope.IsCreateIcon = false;
        $scope.IsListIcon = false;
        $scope.IsDetailShow = false;
        $scope.IsQuestionListShow = false;
        $scope.SaveQuestion = "Save";
        $scope.IsMapShow = false;

        // debugger
        $scope.gridOptionsApproveRetailerInfoUpdate = [];

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
                    $scope.PageTitle = 'Retailer Info Update Requests';
                    $scope.IsMapShow = false;
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = ' Modified Retailer Approval';
                    $scope.btnShowText = "Show Retailer Info Update Requests";
                    $scope.btnSaveShow = true;
                    $scope.btnRejectShow = true;
                    $scope.btnSaveText = "Approve";
                    $scope.IsShow = false;
                    $scope.IsHidden = false;
                    $scope.IsDetailShow = false;

                    $scope.IsCreateIcon = false;
                    $scope.IsListIcon = true;
                    $scope.loadModifiedRetailerInfoUpdateReq(1);
                }
            } else {
                $scope.IsShow = true;
                $scope.btnSaveShow = false;
                $scope.btnRejectShow = false;
                $scope.IsDetailShow = false;
                $scope.btnListShow = false;
                $scope.IsCreateIcon = false;
                $scope.IsListIcon = false;
                $scope.PageTitle = 'Retailer Info Update Requests';
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
                debugger;
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
        GetPermission('00301');

        $scope.modal_ConfShow = function (confdata) {
            debugger;
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
            $scope.GetModifiedRetailerDetail($scope.DataEntity);
        }

        $scope.SearchRetailer = function () {
            var status = $scope.Status;
            $scope.loadModifiedRetailerInfoUpdateReq(status);
        }

        //**********----Get All Retailer Modify Records----***************
        $scope.loadModifiedRetailerInfoUpdateReq = function (status) {
            $scope.gridOptionsApproveRetailerInfoUpdate.enableFiltering = true;
            $scope.gridOptionsApproveRetailerInfoUpdate.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreApproveRetailerInfoUpdate = true;
            $scope.lblMessageForApproveRetailerInfoUpdate = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsApproveRetailerInfoUpdate = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "RETAILER_CODE", displayName: "Retailer Code", title: "Retailer Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRIBUTOR_NAME", displayName: "Distributor Name", title: "Distributor Name", width: '17%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CURRENT_NAME", displayName: "Retailer Name", title: "Retailer Name", width: '17%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MODIFIED_NAME", visible: false, displayName: "Modified Name", title: "Modified Name", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CURRENT_CONTACTPERSON", visible: false, displayName: "Contact Person", title: "Contact Person", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MODIFIED_CONTACTPERSON", visible: false, displayName: "Modified Contact Person", title: "Modified Contact Person", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CURRENT_CONTACTNO", displayName: "Contact No", title: "Contact No", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MODIFIED_CONTACTNO", visible: false, displayName: "Modified Contact No", title: "Modified Contact No", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CURRENT_ADDRESS", displayName: "Address", title: "Address", width: '26%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MODIFIED_ADDRESS", visible: false, displayName: "Modified Address", title: "Modified Address", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CURRENT_IS_OWN_SHOP", visible: false, displayName: "Is Own Shop", title: "Is Own Shop", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MODIFIED_IS_OWN_SHOP", visible: false, displayName: "Modified Is Own Shop", title: "Modified Is Own Shop", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CURRENT_OWNERNAME", visible: false, displayName: "Owner Name", title: "Modified Owner Name", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MODIFIED_OWNERNAME", visible: false, displayName: "Modified Owner Name", title: "Modified Owner Name", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CURRENT_SHOPSIZE", visible: false, displayName: "Current Shop Size", title: "Current Shop Size", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MODIFIED_SHOPSIZE", visible: false, displayName: "Modified Shop Size", title: "Modified Shop Size", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CURRENT_DISTRICT_NAME", visible: false, displayName: "Current District Name", title: "Current District Name", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MODIFIED_DISTRICT_NAME", visible: false, displayName: "Modified District Name", title: "Modified District Name", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CURRENT_THANA_NAME", visible: false, displayName: "Current Thana Name", title: "Current Thana Name", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MODIFIED_THANA_NAME", visible: false, displayName: "Modified Thana Name", title: "Modified Thana Name", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "LOC_LATITUDE", visible: false, displayName: "Latitude", title: "Latitude", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "LOC_LONGITUDE", visible: false, displayName: "Longitude", title: "Longitude", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "REQUEST_STATUS_NAME", displayName: "Status", title: "Status", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
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
                                      '<a href="" title="View Detail & Take Action" ng-click="grid.appScope.GetModifiedRetailerDetail(row.entity)">' +
                                        '<i class="icon-info-sign" aria-hidden="true"></i> View Detail' +
                                      '</a>' +
                                      '</span>' +
                                      //'<span class="label label-success label-mini" style="text-align:center !important;">' +
                                      //'<a href="" title="View Detail" ng-click="grid.appScope.ModifiedRetailerDetail(row.entity)">' +
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
                exporterCsvFilename: 'RetailerInfoUpdateApproval.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "RetailerInfoUpdateApproval", style: 'headerStyle' },
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
                FromDate: $scope.DateFrom == "" || $scope.DateFrom == null ? null : conversion.getStringToDate($scope.DateFrom),
                ToDate: $scope.DateTo == "" || $scope.DateTo == null ? null : conversion.getStringToDate($scope.DateTo),
                StatusId: status
            };
            var apiRoute = baseUrl + 'GetRetailerModifyRequest/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listDistTargetInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listDistTargetInfo.then(function (response) {
                // debugger;
                $scope.gridOptionsApproveRetailerInfoUpdate.data = response.data.modifiedRetailerRequestList;
                $scope.loaderMoreApproveRetailerInfoUpdate = false;
                $scope.ModifiedRetailerRequestList = response.data.modifiedRetailerRequestList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.loadModifiedRetailerInfoUpdateReq(1);


        //**********----Get Single Record----***************
        $scope.GetModifiedRetailerDetail = function (dataModel) {
            //debugger
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = ' Modified Retailer Approval';
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
            $scope.RetailerName = dataModel.CURRENT_NAME;
            $scope.Address = dataModel.CURRENT_ADDRESS;
            $scope.OwnShop = dataModel.CURRENT_IS_OWN_SHOP;
            $scope.OwnerName = dataModel.CURRENT_OWNERNAME;
            $scope.RequesterComments = dataModel.REQUESTERS_COMMENTS;
            $scope.ShopSize = dataModel.CURRENT_SHOPSIZE;
            $scope.ContactPerson = dataModel.CURRENT_CONTACTPERSON;
            $scope.ContactNo = dataModel.CURRENT_CONTACTNO;
            $scope.District = dataModel.CURRENT_DISTRICT_NAME;
            $scope.Thana = dataModel.CURRENT_THANA_NAME;


            $scope.ModifiedRetailerName = dataModel.MODIFIED_NAME;
            $scope.ModifiedAddress = dataModel.MODIFIED_ADDRESS;
            $scope.ModifiedOwnShop = dataModel.MODIFIED_IS_OWN_SHOP;
            $scope.ModifiedOwnerName = dataModel.MODIFIED_OWNERNAME;
            $scope.ModifiedShopSize = dataModel.MODIFIED_SHOPSIZE;
            $scope.ModifiedContactPerson = dataModel.MODIFIED_CONTACTPERSON;
            $scope.ModifiedContactNo = dataModel.MODIFIED_CONTACTNO;
            $scope.ModifiedDistrict = dataModel.MODIFIED_DISTRICT_NAME;
            $scope.ModifiedThana = dataModel.MODIFIED_THANA_NAME;

            $scope.latValue = dataModel.LOC_LATITUDE;
            $scope.longValue = dataModel.LOC_LONGITUDE;

            if ($scope.latValue == undefined || $scope.latValue == null || $scope.latValue == 0 || $scope.longValue == undefined || $scope.longValue == null || $scope.longValue == 0) {
                $scope.IsMapNotAvail = true;
                $scope.IsMapShow = false;
                $scope.msgMapNotAvail = ' * Location is not available to show map!!'
            } else {
                $scope.IsMapNotAvail = false;
                $scope.IsMapShow = true;
            }


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


        //**********---- Modified Retailer Approval----***************

        $scope.save = function (actionType) {

            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '00302'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                debugger;
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.ApproveRetailerInfoUpdate(actionType);
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.ApproveRetailerInfoUpdate = function (actionType) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };

            var ModifiedRetailerApprovalInfo = {
                RetailerModifyId: $scope.hRetailerModifyId,
                ActionType: actionType,
                ApproverComment: $scope.ApproverComments,
            };

            var apiRoute = baseUrl + 'ApproveRetailerModifyRequest/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(ModifiedRetailerApprovalInfo) + "]";

            var SaveModifiedRetailerApproval = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveModifiedRetailerApproval.then(function (response) {
                // debugger;
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;


                    $scope.loadModifiedRetailerInfoUpdateReq(1);
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
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;
            $scope.btnListShow = false;
            $scope.btnRejectShow = false;
            $scope.IsMapShow = false;
            $scope.PageTitle = 'Retailer Info Update Requests';
            $scope.hTargetId = 0;
            $scope.hTargetDetailId = 0;
            $scope.ItemName = '';
            $scope.TargetPeriod = '';
            $scope.Version = '';
            $scope.TargetValue = '';
            $scope.RevisedTargetValue = '';
            $scope.Comment = '';

            $scope.loadModifiedRetailerInfoUpdateReq(1);
        };
    }]);

