/**
 * MarketUpdateCtlr.js
 */

app.controller('MarketUpdateCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/MarketUpdate/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Approve";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Market Update List';
        $scope.btnListShow = false;
        $scope.IsCreateIcon = false;
        $scope.IsListIcon = false;
        $scope.IsDetailShow = false;
        $scope.IsQuestionListShow = false;
        $scope.SaveQuestion = "Save";
        $scope.IsMapShow = false;

        $scope.gridOptionsMarketUpdate = [];

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
                    $scope.PageTitle = 'Market Update List';
                    $scope.IsMapShow = false;
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Market Update';
                    $scope.btnShowText = "Show Market Update List";
                    $scope.btnSaveShow = true;
                    $scope.btnRejectShow = true;
                    $scope.btnSaveText = "Approve";
                    $scope.IsShow = false;
                    $scope.IsHidden = false;
                    $scope.IsDetailShow = false;

                    $scope.IsCreateIcon = false;
                    $scope.IsListIcon = true;
                }
            } else {
                $scope.IsShow = true;
                $scope.btnSaveShow = false;
                $scope.btnRejectShow = false;
                $scope.IsDetailShow = false;
                $scope.btnListShow = false;
                $scope.IsCreateIcon = false;
                $scope.IsListIcon = false;
                $scope.PageTitle = 'Market Update List';
            }
        }

        function CommonEntity() {
            $scope.HeaderToken = $scope.tokenManager.generateSecurityToken();
            $scope.Imtiaz = $scope.tokenManager.generateSecurityToken();
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

        GetPermission('01001');

        $scope.PreviewPicture = function (imageId) {
            var modal = document.getElementById('myModal');

            // Get the image and insert it inside the modal - use its "alt" text as a caption
            var img = document.getElementById(imageId);
            var modalImg = document.getElementById("img01");

            modal.style.display = "block";
            modalImg.src = img.src;


            // Get the <span> element that closes the modal
            var span = document.getElementsByClassName("close")[0];
            //$scope.btnSaveShow = false;
            //$scope.IsCreateIcon = false;
            //$scope.IsListIcon = false;
            //$scope.btnListShow = false;
            // When the user clicks on <span> (x), close the modal
            span.onclick = function () {
                modal.style.display = "none";
            }
        }

        //**********----Get Events ----***************
        function loadEvents() {
            objcmnParam = {
                RoleId: 0,
                loggeduser: $scope.loggedUserId,
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetEvents/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listEvent = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listEvent.then(function (response) {
                $scope.listEvent = response.data.objEventList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadEvents();

        //**********----Get Market Update Types ----***************
        function loadMarketUpdateTypes() {
            objcmnParam = {
                RoleId: 0,
                loggeduser: $scope.loggedUserId,
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetMarketUpdateTypes/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listMarketUpdateType = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listMarketUpdateType.then(function (response) {
                $scope.listMarketUpdateType = response.data.objUpdateTypeList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadMarketUpdateTypes();

        //*******-----Get Search Result----************
        $scope.GetMarketUpdateSearch = function () {
            loadMarketUpdate();
        };

        //**********----Get Market Update----***************
        function loadMarketUpdate() {
            $scope.gridOptionsMarketUpdate.enableFiltering = true;
            $scope.gridOptionsMarketUpdate.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreMarketUpdate = true;
            $scope.lblMessageForMarketUpdate = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsMarketUpdate = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "MARKET_UPDATE_TYPE", displayName: "Market Update Type", title: "Market Update Type", width: '13%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "EVENT_NAME", displayName: "Event Name", title: "Event Namee", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "OPERATOR_CODE", displayName: "Operator Code", title: "Operator Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "NOTE", displayName: "Note", title: "Note", width: '34%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "UPDATED_DATE", displayName: "Update Date", title: "Update Date", width: '9%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CAMPTURED_BY_USER_NAME", displayName: "Captured By", title: "Captured By", width: '11%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RETAILER_CODE", visible: false, displayName: "Retailer Code", title: "Retailer Code", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RETAILER_NAME", visible: false, displayName: "Retailer Name", title: "Retailer Name", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRIBUTOR_CODE", visible: false, displayName: "Distributor Code", title: "Distributor Code", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRIBUTOR_NAME", visible: false, displayName: "Distributor Name", title: "Distributor Name", width: '0%', headerCellClass: $scope.highlightFilteredHeader },
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
                                      '<a href="" title="View Detail & Take Action" ng-click="grid.appScope.GetMarketUpdateDetail(row.entity)">' +
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
                exporterCsvFilename: 'MarketUpdate.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Market Update", style: 'headerStyle' },
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
                FromDate: $scope.DateFrom == "" || $scope.DateFrom == null ? null : conversion.getStringToDate($scope.DateFrom),
                ToDate: $scope.DateTo == "" || $scope.DateTo == null ? null : conversion.getStringToDate($scope.DateTo),
                loggeduser: $scope.loggedUserId,
                MarketUpdateTypeId: $scope.UpdateType,
                EventId: $scope.Event,
            };
            var apiRoute = baseUrl + 'GetMarketUpdate/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listMarketUpdateInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listMarketUpdateInfo.then(function (response) {
                $scope.gridOptionsMarketUpdate = [];
                $scope.gridOptionsMarketUpdate.data = response.data.marketUpdateList;
                $scope.loaderMoreMarketUpdate = false;
                $scope.MarketUpdateList = response.data.marketUpdateList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };
        loadMarketUpdate();

        //**********----Get Single Record----***************
        $scope.GetMarketUpdateDetail = function (dataModel) {
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Market Update Detail';
            $scope.btnSaveText = "Submit";
            $scope.btnShowText = "Show Market Update List";
            $scope.IsDetailShow = false;
            $scope.IsTListShow = false;
            $scope.btnSaveShow = false;
            $scope.btnRejectShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;
            $scope.btnListShow = true;
            $scope.IsMapShow = true;

            $scope.hMarketUpdateId = dataModel.ID;
            $scope.MarketUpdateType = dataModel.MARKET_UPDATE_TYPE;
            $scope.EventName = dataModel.EVENT_NAME;
            $scope.CapturedBy = dataModel.CAMPTURED_BY_USER_NAME;
            $scope.RetailerCode = dataModel.RETAILER_CODE;
            $scope.RetailerName = dataModel.RETAILER_NAME;

            $scope.OperatorCode = dataModel.OPERATOR_CODE;
            $scope.Note = dataModel.NOTE;
            $scope.UpdateDate = dataModel.UPDATED_DATE;
            $scope.DistributorCode = dataModel.DISTRIBUTOR_CODE;
            $scope.DistributorName = dataModel.DISTRIBUTOR_NAME;
            $scope.GetPictures(dataModel.ID);
        };

        $scope.GetPictures = function (marketUpdateId) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                MarketUpdateId: marketUpdateId,
                loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetMarketUpdatePictures/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listUpdatePicture = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listUpdatePicture.then(function (response) {
                $scope.ImageData = response.data.getMarketUpdatePictures;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }


    }]);

