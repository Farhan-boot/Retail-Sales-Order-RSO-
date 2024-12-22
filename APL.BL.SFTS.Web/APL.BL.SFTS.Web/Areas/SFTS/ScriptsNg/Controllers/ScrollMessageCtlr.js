/**
 * ScrollMessageCtrl.js
 */
app.controller('ScrollMessageCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/ScrollMessage/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing Scroll Messages';
        $scope.ListTitle = 'Scroll Message List';
        $scope.IsCreateIcon = true;
        $scope.IsListIcon = false;
        $scope.IsEventShow = false;
        $scope.IsRegionShow = true;
        $scope.IsZoneShow = true;

        // debugger
        $scope.gridOptionsScrollMessage = [];
        $scope.ListSelectedZone = [];
        $scope.ListDDLZone = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;

        $scope.ShowHide = function () {
            if ($scope.IsEventShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.btnShowText = "Create";
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Existing Scroll Messages';
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Add New Scroll Message';
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
                $scope.PageTitle = 'Existing Scroll Messages';
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


        $scope.OnchangeToAll = function () {
            $scope.ListSelectedZone = [];
            if ($scope.IsToAll == true) {
                $scope.IsRegionShow = false;
                $scope.IsZoneShow = false;
            } else {
                $scope.IsRegionShow = true;
                $scope.IsZoneShow = this;
            }
        }

        //**********----Get Regions ----***************
        function loadRegion(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetRegions/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRegions = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRegions.then(function (response) {
                $scope.listRegion = response.data.objListRegion;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadRegion(0);

        //load Zones
        $scope.loadZones = function () {
            var isPaging = 0;
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RegionId: $scope.Region == null || $scope.Region == undefined || $scope.Region == '' ? 0 : $scope.Region,
                loggeduser: $scope.loggedUserId,
            };
            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetAllZones/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
            var ListZone = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            ListZone.then(function (response) {
                $scope.ListSelectedZone = [];
                $scope.ListDDLZone = [];
                if (response.data.objListZone.length > 0) {
                    $scope.ListDDLZone = response.data.objListZone;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.loadZones();


        //**********----Get All Scroll Message----***************
        function loadScrollMessages(isPaging) {
            $scope.gridOptionsScrollMessage.enableFiltering = true;
            $scope.gridOptionsScrollMessage.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreScrollMessage = true;
            $scope.lblMessageForScrollMessage = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsScrollMessage = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "SCROLL_MESSAGE", displayName: "Message", title: "Message", width: '50%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISPLAY_FROM", displayName: "Display From", title: "Display From", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISPLAY_TO", displayName: "Display To", title: "Display To", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "IS_ACTIVE", displayName: "Status", title: "Status", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
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
                                      '<a href="" title="Edit" ng-click="grid.appScope.getScrollMessage(row.entity)">' +
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
                exporterCsvFilename: 'ScrollMessage.csv',
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

            var apiRoute = baseUrl + 'GetScrollMessages/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listMsg = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listMsg.then(function (response) {
                $scope.gridOptionsScrollMessage.data = response.data.messageList;
                $scope.loaderMoreScrollMessage = false;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };
        loadScrollMessages(0);

        //**********----Get Single Record----***************
        $scope.getScrollMessage = function (dataModel) {
            //debugger
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Update Scroll Message';
            $scope.btnSaveText = "Update";
            $scope.btnShowText = "Show List";
            $scope.btnSaveShow = true;
            $scope.btnResetShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;

            $scope.hMessageId = dataModel.MESSAGE_ID;
            $scope.Message = dataModel.MESSAGE;
            $scope.DisplayDateFrom = dataModel.DISPLAY_FROM;
            $scope.DisplayDateFrom = dataModel.DISPLAY_TO;
            $scope.IsActive = dataModel.IS_ACTIVE == "Active" ? true : false;
            //$scope.IsRegionShow = false;
            //$scope.IsZoneShow = false;
           // $scope.IsToAll = false;

            //if (dataModel.IS_TO_ALL == true) {
            //    $scope.IsToAll = dataModel.IS_TO_ALL
            //} else {
            //    $scope.IsRegionShow = true;
            //    $scope.IsZoneShow = true;
            //    // $scope.GetAreas(dataModel.MESSAGE_ID);
            //}
        };

        $scope.GetAreas = function (messageId) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                EventId: messageId,
                loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetAreas/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listArea = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listArea.then(function (response) {
                $scope.ListSelectedZone = response.data.msgArea;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }


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
                   $scope.SaveScrollMessage();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.SaveScrollMessage = function () {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };

            var messageInfo = {
                MessageId: $scope.hMessageId == undefined || $scope.hMessageId == null ? 0 : $scope.hMessageId,
                Message: $scope.Message,
                DisplayFrom: $scope.DisplayDateFrom,
                DisplayTo: $scope.DisplayDateTo,
                IsActive: $scope.IsActive
            };

           // var displayArea = $scope.ListSelectedZone;

            var apiRoute = baseUrl + 'SaveUpdateScrollMessage/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(messageInfo) + "]"; //," + JSON.stringify(displayArea) + "

            var SaveUpdateScrollMessage = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateScrollMessage.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnShowText = "Create";
                    $scope.PageTitle = 'Add New Event';
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;
                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    loadScrollMessages(0);
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

            $scope.hMessageId = 0;
            $scope.DisplayDateFrom = '';
            $scope.DisplayDateTo = '';
            $scope.IsActive = false;
            $("#ddlRegion").select2("data", { id: '', text: '--Select Region--' });
            $scope.ListSelectedZone = [];

            loadScrollMessages(0);
        };
    }]);

