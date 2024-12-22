/**
 * RmbmAcknoledgementCtlr.js
 */

app.controller('RmbmAcknoledgementCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/RmbmAcknowledgement/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Approve";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'AMBM Shop Visit List';
       // $scope.ListTitle = 'Retailer Creation List';
        $scope.btnListShow = false;
        $scope.IsCreateIcon = false;
        $scope.IsListIcon = false;
        $scope.IsDetailShow = false;
        $scope.IsQuestionListShow = false;
        $scope.SaveQuestion = "Save";
        $scope.IsMapShow = false;


        $scope.gridOptionsRmbmAcknowledgement = [];

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
                    $scope.PageTitle = 'AMBM Shop Visit List';
                    $scope.IsMapShow = false;
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'RMBM Acknowledgement';
                    $scope.btnShowText = "Show AMBM Shop Visit List";
                    $scope.btnSaveShow = true;
                    $scope.btnRejectShow = true;
                    $scope.btnSaveText = "Approve";
                    $scope.IsShow = false;
                    $scope.IsHidden = false;
                    $scope.IsDetailShow = false;

                    $scope.IsCreateIcon = false;
                    $scope.IsListIcon = true;
                    $scope.loadNewRetailerCreationReq();
                }
            } else {                
                $scope.IsShow = true;
                $scope.btnSaveShow = false;
                $scope.btnRejectShow = false;
                $scope.IsDetailShow = false;
                $scope.btnListShow = false;
                $scope.IsCreateIcon = false;
                $scope.IsListIcon = false;
                $scope.PageTitle = 'AMBM Shop Visit List';
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

        GetPermission('01101');


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
            $scope.GetAmbmShopVisitDetail($scope.DataEntity);
        }

        //**********----Get Ambm ----***************
        function loadAmbm(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                TerritoryId: 0,
                loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetAmbm/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listAmbm = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listAmbm.then(function (response) {
                $scope.AmbmList = response.data.objListAmbm;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadAmbm(0);

        //*******-----Get Search Result----************
        $scope.GetAMBMShopVisitSearch = function () {
            SearchAMBMShopVisit(0);            
        };

        //**********----Search AMBM Shop Visit----***************
        function SearchAMBMShopVisit(isPaging) {           
            $scope.gridOptionsRmbmAcknowledgement = [];
            $scope.gridOptionsRmbmAcknowledgement.enableFiltering = true;
            $scope.gridOptionsRmbmAcknowledgement.enableGridMenu = true;

            // For Loading
            if (isPaging == 0)
                $scope.pagination.pageNumber = 1;

            //For Loading
            $scope.loaderMoreRmbmAcknowledgement = true;
            $scope.lblMessageForRmbmAcknowledgement = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsRmbmAcknowledgement = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "CENTER_CODE", displayName: "Shop Code", title: "Shop Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CENTER_NAME", displayName: "Shop Name", title: "Shop Name", width: '22%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CENTER_ADDRESS", displayName: "Shop Address", title: "Shop Address", width: '29%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "VISITED_DATE", displayName: "Visited Date", title: "Visited Date", width: '9%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "VISITED_BY", displayName: "Visited By", title: "Visited By", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ACNOWLEDGE_STATUS", displayName: "Acknowledged", title: "Acknowledged", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
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
                                      '<a href="" title="View Detail & Take Action" ng-click="grid.appScope.GetAmbmShopVisitDetail(row.entity)">' +
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
                AmbmId: $scope.Ambm == null || $scope.Ambm == 0 || $scope.Ambm == undefined ? 0 : $scope.Ambm,
                FromDate: $scope.VisitDateFrom == "" || $scope.VisitDateFrom == null ? null : conversion.getStringToDate($scope.VisitDateFrom),
                ToDate: $scope.VisitDateTo == "" || $scope.VisitDateTo == null ? null : conversion.getStringToDate($scope.VisitDateTo),
                loggeduser: $scope.loggedUserId
            };

            var apiRoute = baseUrl + 'GetAmbmShopVisitSearch/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listSearchResult = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listSearchResult.then(function (response) {
                $scope.gridOptionsRmbmAcknowledgement = [];
                $scope.gridOptionsRmbmAcknowledgement.data = response.data.ambmShopVisitList;
                $scope.loaderMoreRmbmAcknowledgement = false;
                $scope.RmbmAcknowledgementList = response.data.ambmShopVisitList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };


        //**********----Get All AMBM Shop Visit----***************
        function loadAMBMShopVisit(isPaging) {
            $scope.gridOptionsRmbmAcknowledgement.enableFiltering = true;
            $scope.gridOptionsRmbmAcknowledgement.enableGridMenu = true;

            // For Loading
            if (isPaging == 0)
                $scope.pagination.pageNumber = 1;

            //For Loading
            $scope.loaderMoreRmbmAcknowledgement = true;
            $scope.lblMessageForRmbmAcknowledgement = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };         
           
            $scope.gridOptionsRmbmAcknowledgement = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "CENTER_CODE", displayName: "Shop Code", title: "Shop Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CENTER_NAME", displayName: "Shop Name", title: "Shop Name", width: '22%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CENTER_ADDRESS", displayName: "Shop Address", title: "Shop Address", width: '29%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "VISITED_DATE", displayName: "Visited Date", title: "Visited Date", width: '9%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "VISITED_BY", displayName: "Visited By", title: "Visited By", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ACNOWLEDGE_STATUS", displayName: "Acknowledged", title: "Acknowledged", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
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
                                      '<a href="" title="View Detail & Take Action" ng-click="grid.appScope.GetAmbmShopVisitDetail(row.entity)">' +
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
            var apiRoute = baseUrl + 'GetAmbmShopVisit/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRmbmAcnowInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRmbmAcnowInfo.then(function (response) {
                $scope.pagination.totalItems = response.data.recordsTotal;
                $scope.gridOptionsRmbmAcknowledgement.data = response.data.ambmShopVisitList;
                $scope.loaderMoreRmbmAcknowledgement = false;
                $scope.RmbmAcknowledgementList = response.data.ambmShopVisitList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        loadAMBMShopVisit(0);


        //**********----Get Single Record----***************
        $scope.GetAmbmShopVisitDetail = function (dataModel) {
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'RMBM Acknowledgement';
            $scope.btnSaveText = "Acknowledged";
            $scope.btnShowText = "Show Visit List";
            $scope.IsDetailShow = false;
            $scope.IsTListShow = false;
            $scope.btnSaveShow = true;
            $scope.btnRejectShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;
            $scope.btnListShow = true;
            $scope.IsMapShow = true;

            $scope.hVisitId = dataModel.ID;
            $scope.ShopCode = dataModel.CENTER_CODE;
            $scope.ShopName = dataModel.CENTER_NAME;
           // $scope.Comments = dataModel.NAME;
            $scope.ShopAddress = dataModel.CENTER_ADDRESS;
            $scope.VisitedBy = dataModel.VISITED_BY;
            $scope.VisitedDate = dataModel.VISITED_DATE;


            $scope.IsSaveDisabled = false;
            $scope.IsCommentDisabled = false;
            $scope.Comments = '';

            $scope.getFeedbackQuestionAnswer(dataModel.ID);

            if (dataModel.ACNOWLEDGE_STATUS == "YES") {
                $scope.IsSaveDisabled = true;
              //  $scope.Comments = dataModel.APPROVERS_COMMENTS;
                //$scope.IsCommentDisabled = true;

            } else if (dataModel.ACNOWLEDGE_STATUS == "NO") {
                $scope.IsSaveDisabled = false;
                //$scope.IsCommentDisabled = false;
                $scope.Comments = '';
            }
            
        };


        $scope.FeedbackQAList = [];
        $scope.getFeedbackQuestionAnswer = function (visitId) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
                VisitId: visitId
            };
            var apiRoute = baseUrl + 'GetFeedbackQuestionAnswerList/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listfeedbackQA = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listfeedbackQA.then(function (response) {
                $scope.FeedbackQAList = [];
                $scope.FeedbackQAList = response.data.feedbackQuestionAnswerList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }


        //**********----RMBM Acknowledgement----***************

        $scope.save = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '01102'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveRmbmAcknowledgement();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });

        };

        $scope.SaveRmbmAcknowledgement = function () {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                VisitId: $scope.hVisitId,
                Comments: $scope.Comments,
                loggeduser: $scope.loggedUserId,
            };

            var apiRoute = baseUrl + 'SaveRmbmAcknowledgement/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var SaveRmbmAcknowledgement = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveRmbmAcknowledgement.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;

                    //loadAMBMShopVisit(0);
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
            loadAMBMShopVisit(0);
        };
    }]);

