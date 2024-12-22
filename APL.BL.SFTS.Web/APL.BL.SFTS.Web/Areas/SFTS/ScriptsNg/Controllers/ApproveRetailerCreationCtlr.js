/**
 * ApproveRetailerCreationCtlr.js
 */

app.controller('ApproveRetailerCreationCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/ApproveRetailerCreation/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Approve";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Retailer Creation Requests';
        $scope.ListTitle = 'Retailer Creation List';
        $scope.btnListShow = false;
        $scope.IsCreateIcon = false;
        $scope.IsListIcon = false;
        $scope.IsDetailShow = false;
        $scope.IsQuestionListShow = false;
        $scope.SaveQuestion = "Save";
        $scope.IsMapShow = false;

        // debugger
        $scope.gridOptionsApproveRetailerCreation = [];

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
                    $scope.PageTitle = 'Retailer Creation Requests';
                    $scope.IsMapShow = false;
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'New Retailer Approval';
                    $scope.btnShowText = "Show Retailer Creation Requests";
                    $scope.btnSaveShow = true;
                    $scope.btnRejectShow = true;
                    $scope.btnSaveText = "Approve";
                    $scope.IsShow = false;
                    $scope.IsHidden = false;
                    $scope.IsDetailShow = false;

                    $scope.IsCreateIcon = false;
                    $scope.IsListIcon = true;
                    $scope.loadNewRetailerCreationReq(1);
                }
            } else {
                $scope.IsShow = true;
                $scope.btnSaveShow = false;
                $scope.btnRejectShow = false;
                $scope.IsDetailShow = false;
                $scope.btnListShow = false;
                $scope.IsCreateIcon = false;
                $scope.IsListIcon = false;
                $scope.PageTitle = 'Retailer Creation Requests';
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
        GetPermission('00101');

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
            $scope.UserCommonEntity.message = 'Approved';
            $scope.GetNewRetailerDetail($scope.DataEntity);
        }

        $scope.SearchRetailer = function () {
            var status = $scope.Status;
            $scope.loadNewRetailerCreationReq(status);
        }



        //**********----Get All New Retailer Records----***************
        $scope.loadNewRetailerCreationReq = function (status) {
            $scope.gridOptionsApproveRetailerCreation.enableFiltering = true;
            $scope.gridOptionsApproveRetailerCreation.enableGridMenu = true;


            //For Loading
            $scope.loaderMoreApproveRetailerCreation = true;
            $scope.lblMessageForApproveRetailerCreation = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsApproveRetailerCreation = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "DISTRIBUTOR_NAME", displayName: "Distributor", title: "Distributor", width: '18%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "NAME", displayName: "Retailer Name", title: "Retailer Name", width: '22%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ADDRESS", displayName: "Address", title: "Address", width: '30%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "REQUESTED_AT", displayName: "Request Date", title: "Request Date", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "IS_OWN_SHOP", visible: false, displayName: "Is Own Shop", title: "Is Own Shop", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "OWNERNAME", visible: false, displayName: "Owner Name", title: "Owner Name", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SHOPSIZE", visible: false, displayName: "Shop Size", title: "Shop Size", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CONTACTPERSON", visible: false, displayName: "Contact Person", title: "Contact Person", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CONTACTNO", visible: false, displayName: "Contact No", title: "Contact No", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TERRITORY_NAME", visible: false, displayName: "Zone Name", title: "Zone Name", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "REQUESTERS_COMMENTS", visible: false, displayName: "Requester Comments", title: "Requester Comments", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
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
                                      '<a href="" title="View Detail & Take Action" ng-click="grid.appScope.GetNewRetailerDetail(row.entity)">' +
                                        '<i class="icon-info-sign" aria-hidden="true"></i> View Detail' +
                                      '</a>' +
                                      '</span>' +
                                      //'<span class="label label-success label-mini" style="text-align:center !important;">' +
                                      //'<a href="" title="View Detail" ng-click="grid.appScope.NewRetailerDetail(row.entity)">' +
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
                exporterCsvFilename: 'RetailerCreationApproval.csv',
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
                FromDate: $scope.DateFrom == "" || $scope.DateFrom == null ? null : conversion.getStringToDate($scope.DateFrom),
                ToDate: $scope.DateTo == "" || $scope.DateTo == null ? null : conversion.getStringToDate($scope.DateTo),
                StatusId: status
            };
            var apiRoute = baseUrl + 'GetNewRetailerRequest/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listApproveRetailerCreation = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listApproveRetailerCreation.then(function (response) {
                // debugger;
                $scope.gridOptionsApproveRetailerCreation.data = response.data.newRetailerRequestList;
                $scope.loaderMoreApproveRetailerCreation = false;
                $scope.NewRetailerRequestList = response.data.newRetailerRequestList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.loadNewRetailerCreationReq(1)

        //**********----Get Single Record----***************
        $scope.GetNewRetailerDetail = function (dataModel) {
            //debugger
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'New Retailer Approval';
            $scope.btnSaveText = "Approve";
            $scope.btnShowText = "Show New Requests";
            $scope.IsDetailShow = false;
            $scope.IsTListShow = false;
            $scope.btnSaveShow = true;
            $scope.btnRejectShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;
            $scope.btnListShow = true;
            $scope.IsMapShow = true;

            $scope.hRetailerModifyId = dataModel.ID;
            $scope.RetailerCode = dataModel.CREATED_RETAILER_CODE;
            $scope.Distributor = dataModel.DISTRIBUTOR_NAME;
            $scope.RetailerName = dataModel.NAME;
            $scope.Address = dataModel.ADDRESS;
            $scope.OwnShop = dataModel.IS_OWN_SHOP;
            $scope.OwnerName = dataModel.OWNERNAME;
            $scope.RequesterComments = dataModel.REQUESTERS_COMMENTS;
            $scope.ShopSize = dataModel.SHOPSIZE;
            $scope.ContactPerson = dataModel.CONTACTPERSON;
            $scope.ContactNo = dataModel.CONTACTNO;
            $scope.Teritory = dataModel.TERRITORY_NAME;
            $scope.RequestDate = dataModel.REQUESTED_AT;

            $scope.latValue = dataModel.LOC_LATITUDE;
            $scope.longValue = dataModel.LOC_LONGITUDE;
            $scope.RetailerPin = new google.maps.MarkerImage("http://chart.apis.google.com/chart?chst=d_map_xpin_letter&chld=pin_star|R|F58635|000000|DC143C");

            if ($scope.latValue == undefined || $scope.latValue == null || $scope.latValue == 0 || $scope.longValue == undefined || $scope.longValue == null || $scope.longValue == 0) {
                $scope.IsMapNotAvail = true;
                $scope.IsMapShow = false;
                $scope.msgMapNotAvail = ' * Location is not available to show map!!'
            } else {
                $scope.IsMapNotAvail = false;
                $scope.IsMapShow = true;
                $scope.OtherRetailerLocation(dataModel.ROUTE_ID);
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

        $scope.OtherRetailerLocation = function (routeId) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RouteID: routeId,
                loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetRetailersLocationByRoute/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRetailerInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRetailerInfo.then(function (response) {
                // debugger;
                $scope.RetailerLocationList = response.data.RetailerLocationList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.showRetailerInfo = function (event, retailer) {
            // $scope.btsName = retailer.RETAILER_NAME;
            $scope.map.showInfoWindow('retailerInfoWindow', this);
        };

        //**********----New Retailer Approval----***************
        $scope.save = function (actionType) {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '00102'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveApproveRetailerCreation(actionType);
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.SaveApproveRetailerCreation = function (actionType) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };

            var NewRetailerApprovalInfo = {
                RetailerModifyId: $scope.hRetailerModifyId,
                ActionType: actionType,
                ApproverComment: $scope.ApproverComments,
            };

            var apiRoute = baseUrl + 'ApproveNewRetailer/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(NewRetailerApprovalInfo) + "]";

            var SaveNewRetailerApproval = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveNewRetailerApproval.then(function (response) {
                // debugger;
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;


                    $scope.loadNewRetailerCreationReq(1);
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
            $scope.PageTitle = 'Retailer Creation Requests';
            $scope.hTargetId = 0;
            $scope.hTargetDetailId = 0;
            $scope.ItemName = '';
            $scope.TargetPeriod = '';
            $scope.Version = '';
            $scope.TargetValue = '';
            $scope.RevisedTargetValue = '';
            $scope.Comment = '';

            $scope.loadNewRetailerCreationReq(1);
        };
    }]);

