/**
 * EventCreateCtrl.js
 */
app.controller('EventCreateCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/EventCreate/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing Events';
        $scope.ListTitle = 'Event List';
        $scope.IsCreateIcon = true;
        $scope.IsListIcon = false;
        $scope.IsEventShow = false;
        $scope.IsRegionShow = true;
        $scope.IsZoneShow = true;

        // debugger
        $scope.gridOptionsEventCreate = [];
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
                    $scope.PageTitle = 'Existing Events';
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Add New Event';
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
                $scope.PageTitle = 'Existing Events';
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


        //**********----Get All Events----***************
        function loadEvents(isPaging) {
            $scope.gridOptionsEventCreate.enableFiltering = true;
            $scope.gridOptionsEventCreate.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreEventCreate = true;
            $scope.lblMessageForEventCreate = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsEventCreate = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "EVENT_NAME", displayName: "Event Name", title: "Event Name", width: '35%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "NOTE", displayName: "Note", title: "Note", width: '45%', headerCellClass: $scope.highlightFilteredHeader },
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
                                      '<a href="" title="Edit" ng-click="grid.appScope.getEvent(row.entity)">' +
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
            var apiRoute = baseUrl + 'GetEvents/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listEvent = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listEvent.then(function (response) {
                $scope.gridOptionsEventCreate.data = response.data.eventList;
                $scope.loaderMoreEventCreate = false;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };
        loadEvents(0);

        //**********----Get Single Record----***************
        $scope.getEvent = function (dataModel) {
            //debugger
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Update Event';
            $scope.btnSaveText = "Update";
            $scope.btnShowText = "Show List";
            $scope.btnSaveShow = true;
            $scope.btnResetShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;


            $scope.hEventId = dataModel.EVENT_ID;
            $scope.EventName = dataModel.EVENT_NAME;
            $scope.EventNote = dataModel.NOTE;
            $scope.IsActive = dataModel.IS_ACTIVE == "Active" ? true : false;
            $scope.IsRegionShow = false;
            $scope.IsZoneShow = false;
            $scope.IsToAll = false;

            if (dataModel.IS_NATIONAL_EVENT == true) {
                $scope.IsToAll = dataModel.IS_NATIONAL_EVENT;
            } else {
                $scope.IsRegionShow = true;
                $scope.IsZoneShow = true;
                $scope.GetEventAreas(dataModel.EVENT_ID);
            }
        };

        $scope.GetEventAreas = function (eventId) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                EventId: eventId,
                loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetEventAreas/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listEventArea = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listEventArea.then(function (response) {
                $scope.ListSelectedZone = response.data.eventArea;
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
                    $scope.SaveEvent();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.SaveEvent = function () {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };

            var eventInfo = {
                EventId: $scope.hEventId == undefined || $scope.hEventId == null ? 0 : $scope.hEventId,
                EventName: $scope.EventName,
                Note: $scope.EventNote,
                IsActive: $scope.IsActive,
                IsToAll: $scope.IsToAll
            };

            var eventArea = $scope.ListSelectedZone;

            var apiRoute = baseUrl + 'SaveUpdateEvent/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(eventInfo) + "," + JSON.stringify(eventArea) + "]";

            var SaveUpdateEventInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateEventInfo.then(function (response) {
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
                    loadEvents(0);
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

            $scope.hEventId = 0;
            $scope.EventName = '';
            $scope.EventNote = '';
            $scope.IsActive = false;
            $("#ddlRegion").select2("data", { id: '', text: '--Select Region--' });
            $scope.ListSelectedZone = [];

            loadEvents(0);
        };
    }]);

