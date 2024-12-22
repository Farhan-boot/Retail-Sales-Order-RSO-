/**
* FocProductCtlr.js
*/
app.controller('RetailerTargetUploadCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/RetailerTarget/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveShow = false;
        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing Retailer Target';
        $scope.ListTitle = 'Retailer Target List';
        $scope.IsCreateIcon = true;
        $scope.IsListIcon = false;
        $scope.IsRetailerTargetShow = false;
        $scope.gridOptionsRetailerTargets = [];
        $scope.gridOptionsRetailerTempTargets = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;


        $scope.ShowHide = function () {
            if ($scope.IsRetailerTargetShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.btnShowText = "Create";
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Existing Retailer Targets';

                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Add New Retailer Target';
                    $scope.btnShowText = "Show List";
                    $scope.btnSaveShow = true;
                    $scope.btnResetShow = true;
                    $scope.btnSaveText = "Save";
                    $scope.IsShow = false;
                    $scope.IsHidden = false;

                    $scope.IsCreateIcon = false;
                    $scope.IsListIcon = true;

                    $scope.deleteRetailerTargetTemp();
                    $scope.loadRetailerTempTargets(0);
                }
            } else {
                $scope.btnShowText = "Create";
                $scope.IsShow = true;
                $scope.btnSaveShow = false;
                $scope.btnResetShow = false;
                $scope.IsCreateIcon = true;
                $scope.IsListIcon = false;
                $scope.PageTitle = 'Existing Retailer Target';
                $scope.deleteRetailerTargetTemp();
                $scope.loadRetailerTempTargets(0);

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

        GetPermission('04041');


        //**********----Get All TradeMaterials----***************
        function loadRetailerTargets(isPaging) {

            $scope.gridOptionsRetailerTargets.enableFiltering = true;
            $scope.gridOptionsRetailerTargets.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreRetailerTargets = true;
            $scope.lblMessageForRetailerTargets = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsRetailerTargets = {
                useExternalSorting: false,
                enableSorting: true,
                useExternalPagination: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "ITEM_NAME", displayName: "Item Name", title: "Item Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "PERIOD_NAME", displayName: "Period Name", title: "Period Name", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "STAFF_CODE", displayName: "Staff Code", title: "Staff Code", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "STAFF_TYPE", displayName: "Staff Type", title: "Staff Type", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TARGET", displayName: "Target", title: "Target", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SET_DATE", displayName: "Set Date", title: "Set Date", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "UP_TO", displayName: "Up To", title: "Up To", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
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
                            '<a href="" title="Edit" ng-click="grid.appScope.getRetailerTarget(row.entity)">' +
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
                exporterCsvFilename: 'Trade Materials.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Trade Materials", style: 'headerStyle' },
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
            var apiRoute = baseUrl + 'GetRetailerTargets/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var RetailerTargetList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            RetailerTargetList.then(function (response) {
                $scope.gridOptionsRetailerTargets.data = response.data.targetList;
                $scope.loaderMoreRetailerTargets = false;
                console.log($scope.gridOptionsRetailerTargets.data)
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };
        loadRetailerTargets(0);

        function loadTargetPeriods(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RoleId: 0,
                //loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = baseUrl + '/GetTargetPeriodList';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var targetPeriodList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            targetPeriodList.then(function (response) {
                $scope.targetPeriodList = response.data.targetPeriodList;

                console.log($scope.targetPeriodList)
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        loadTargetPeriods(0);
        function loadTargetItems(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RoleId: 0,
                //loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = baseUrl + '/GetTargetItemList';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var targetItemList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            targetItemList.then(function (response) {
                $scope.targetItemList = response.data.targetItemList;

                console.log($scope.targetItemList)
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        loadTargetItems(0);
        $scope.loadRetailerTempTargets = function (isPaging) {

            //$scope.gridOptionsRetailerTempTargets.enableFiltering = true;
            //$scope.gridOptionsRetailerTempTargets.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreRetailerTempTargets = true;
            $scope.lblMessageForRetailerTempTargets = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsRetailerTempTargets = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    //{ name: "ITEM_NAME", displayName: "Item Name", title: "Up To", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    //{ name: "PERIOD_NAME", displayName: "Period Name", title: "Period Name", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "STAFF_CODE", displayName: "Staff Code", title: "Staff Code", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "STAFF_TYPE", displayName: "Staff Type", title: "Staff Type", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TARGET", displayName: "Target ", title: "Target", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
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
                            '<a href="" title="Edit" ng-click="grid.appScope.getRetailerTarget(row.entity)">' +
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
                exporterCsvFilename: 'Trade Materials.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Trade Materials", style: 'headerStyle' },
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
            var apiRoute = baseUrl + 'GetRetailTargetsTemp/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var RetailerTargetTempList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            RetailerTargetTempList.then(function (response) {
                $scope.gridOptionsRetailerTempTargets.data = response.data.targetTempList;
                $scope.loaderMoreRetailerTempTargets = false;

                console.log($scope.gridOptionsRetailerTempTargets.data)
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };
        //**********----Get Single Record----***************
        $scope.getRetailerTarget = function (dataModel) {
            //debugger
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Update Retailer Target';
            $scope.btnSaveText = "Update";
            $scope.btnShowText = "Show List";
            $scope.btnSaveShow = true;
            $scope.btnResetShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;

            $scope.IsUpdate = true;
            $scope.hRetailerTargetId = dataModel.TARGET_ID;
            loadTargetItems(0);

            $scope.SET_DATE = dataModel.SET_DATE;
            $scope.UP_TO = dataModel.UP_TO;
            $scope.ITEM_ID = dataModel.ITEM_ID;
            $scope.PERIOD_ID = dataModel.PERIOD_ID;
            $scope.TARGET = dataModel.TARGET;
            $scope.STAFF_CODE = dataModel.STAFF_CODE;
            $scope.STAFF_TYPE = dataModel.STAFF_TYPE;

            $("#ddlItem").select2("data", { id: dataModel.ITEM_ID, text: dataModel.ITEM_NAME });
            $("#ddlPeriod").select2("data", { id: dataModel.PERIOD_ID, text: dataModel.PERIOD_NAME });


        };




        //**********----Create New TradeMaterial----***************

        $scope.save = function () {

            if ($scope.IsUpdate == false) {
                if (document.getElementById('uploadedExcelFile').value == '') {
                    alert('Sorry! Please choose Excel file');
                    return;
                }
            }
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '04042'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    UploadAllFile();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };

        $scope.SaveRetailerTarget = function () {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };

            var RetailerTarget = {
                TargetId: $scope.hRetailerTargetId === undefined || $scope.hRetailerTargetId === null ? 0 : $scope.hRetailerTargetId,
                ItemId: $scope.ITEM_ID,
                PeriodId: $scope.PERIOD_ID,
                StaffCode: $scope.STAFF_CODE,
                StaffType: $scope.STAFF_TYPE,
                SetDate: $scope.SET_DATE,
                UpTo: $scope.UP_TO,
                Target: $scope.TARGET
            };


            var apiRoute = baseUrl + 'SaveRetailerTarget/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(RetailerTarget) + "]";

            var SaveUpdateRetailerTarget = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateRetailerTarget.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnShowText = "Create";
                    $scope.PageTitle = 'Add New Retailer Target';
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;
                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    loadRetailerTargets(0);
                }
                else if (response.data == "") {
                    Command: toastr["warning"]("Save Not Successfull!!!!");
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        $scope.ProductName = "";
        var upExcelFile = [];
        $scope.deleteRetailerTargetTemp = function () {

            var objXhr = new XMLHttpRequest();
            var apiRoute = baseUrl + 'DeleteRetailerTargetTemp';
            objXhr.open("POST", apiRoute);
            var saveFile = objXhr.send();
            //loadCriticalTempBalances(0);
        }
        function AjaxHelper(baseUrl) {
            this._baseUrl = baseUrl;

            var callWebAPI = function (url, verb, data, callback) {

                var xhr = new XMLHttpRequest();

                xhr.onload = function (evt) {
                    var data = JSON.parse(evt.target.responseText);
                    callback(data);
                }

                xhr.onerror = function () {
                    alert("Error while calling Web API");
                }

                xhr.open(verb, url);
                // xhr.setRequestHeader("Content-Type", "application/json");
                if (data == null) {
                    xhr.send();
                }
                else {
                    // xhr.send(JSON.stringify(data));
                    xhr.send(data);
                }
            }

            this.Insert = function (obj, callback) {
                callWebAPI(this._baseUrl, "POST", obj, callback);
            }
        }
        var actionCallback = function (response) {
            var InvalidCode = response.InvalidCode;
            var IsInvalidCode = response.IsInvalidCode;
            var RowNo = response.RowNo;
            var ColNo = response.ColumnNo;
            var TargetForName = response.TargetForName;

            $scope.IsNotFoundShow = false;
            $scope.NotFoundMsg = '';


            if (IsInvalidCode == false) {
                $scope.IsNotFoundShow = false;
                $scope.loadRetailerTempTargets(0);
            } else if (IsInvalidCode == true) {
                $scope.loadRetailerTempTargets(0);
                ////debugger;
                $scope.IsInProgress = false;
                $scope.IsNotFoundShow = true;
                $scope.ProgressStatus = 0;
                $scope.NotFoundMsg = InvalidCode + " is invalid " + TargetForName + " Code in Row " + RowNo + " Column " + ColNo + " of uploaded Excel!"
                //document.getElementById('files').value = '';
                jQuery(window).resize();
                // alert($scope.NotFoundMsg);
            }
        }
        $scope.ExportExcelFile = function (forId) {
            fileExport = {
                NoticeForId: forId
            };
            var RetailerTarget = {
                TargetId: $scope.hRetailerTargetId === undefined || $scope.hRetailerTargetId === null ? 0 : $scope.hRetailerTargetId,
                ItemId: $scope.ITEM_ID,
                PeriodId: $scope.PERIOD_ID,
                SetDate: $scope.SET_DATE,
                UpTo: $scope.UP_TO
            };
            var apiRoute = baseUrl + 'ExportExcelTemplate/';
            var cmnParam = "[" + JSON.stringify(fileExport) + "," + JSON.stringify(RetailerTarget) + "]";

            var TargetItems = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            TargetItems.then(function (response) {
                window.open(DirectoryKey +'/UserFiles/' + response.data, '_blank', '');
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        function UploadAllFile() {


            $scope.IsInProgress = true;
            $scope.ProgressStatus = 70;
            $scope.waitText = ' Please wait...'

            var data = new FormData();
            data.append("uploadedExcelFile", upExcelFile);

            var productName = $scope.ITEM_ID;
            var objXhr = new XMLHttpRequest();
            var loggeduser = $scope.loggedUserId;

            var apiRoute = baseUrl + 'UploadAllFile?product=' + productName + '&userId=' + loggeduser;
            //objXhr.open("POST", apiRoute);
            //var saveFile = objXhr.send(data)
            var ajaxHelper = new AjaxHelper(apiRoute);
            ajaxHelper.Insert(data, actionCallback);

            Command: toastr["success"]("Upload  Successfully!!!!");

        }
        $(document).ready(function () {



            if (window.File && window.FileList && window.FileReader) {
                $("#uploadedExcelFile").on("change", function (e) {

                    $scope.IsInProgress = true;
                    $scope.ProgressStatus = 25;
                    $scope.waitText = '...'

                    var files = e.target.files,
                        filesLength = files.length;
                    var name = files[0].name;

                    $('#hdExcelFileName').val(name);
                    upExcelFile = files[0]

                    var fileExtension;
                    fileExtension = name.split('.').pop();

                    if (fileExtension !== 'xls' && fileExtension !== 'xlsx') {
                        Command: toastr["warning"]("file type should be xls/xlsx !!");
                        document.getElementById('uploadedExcelFile').value = '';
                        return;
                    }

                    //SaveUploadAllFile().then($scope.loadCriticalTempBalances(0));
                    //$scope.loadCriticalTempBalances(0).then(SaveUploadAllFile());
                    // SaveUploadAllFile().done($scope.loadCriticalTempBalances(0)).done($scope.loadCriticalTempBalances(0));
                    //$.when(SaveUploadAllFile()).done(function () {
                    //$scope.loadCriticalTempBalances(0);
                    //});
                    //$.when($scope.loadCriticalTempBalances(0)).then(SaveUploadAllFile());
                  //  UploadAllFile();
                    $scope.IsUpdate = false;
                    //$scope.loadCriticalTempBalances(0);
                    //setTimeout(function () { SaveUploadAllFile() }, 3000);
                    //setTimeout(function () { $scope.loadCriticalTempBalances(0) }, 1000);

                });
            } else {
                alert("Your browser doesn't support to File API")
            }
        });

        $scope.delete = function (dataModel) {
            var isDelete = confirm('You are about to delete ' + dataModel.ITEM_NAME + '. Are you sure?');
            if (isDelete == true) {
                objcmnParam = {
                    pageNumber: page,
                    pageSize: pageSize,
                    IsPaging: isPaging,
                    loggeduser: $scope.loggedUserId
                };
                var TargetInfo = {
                    TargetId: dataModel.TARGET_ID
                };
                var apiRoute = baseUrl + 'DeleteInfo/';

                var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(TargetInfo) + "]";

                var deleteInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
                deleteInfo.then(function (response) {
                    // debugger;
                    if (response.data != "") {
                        Command: toastr["success"]("Delete  Successfully!!!!");
                        loadRetailerTargets(0);
                    }
                    else if (response.data == "") {
                        Command: toastr["warning"]("Delete Not Successfull!!!!");
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });
            }
        }
        $scope.hRetailerTargetId = 0;
        $scope.IsUpdate = false;
        $scope.ITEM_ID = 0;
        $scope.PERIOD_ID = 0;
        $scope.TARGET = 0;
        $scope.gridOptionsRetailerTempTargets = [];
        //**********----Reset Record----***************
        $scope.clear = function () {
            $scope.IsHidden = true;
            $scope.IsShow = true;
            $scope.IsHiddenDetail = true
            $scope.IsCreateIcon = true;
            $scope.IsListIcon = false;

            $scope.btnSaveShow = true;
            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Create";

            $scope.hRetailerTargetId = 0;
            $scope.IsUpdate = false;
            $scope.SET_DATE = '';
            $scope.UP_TO = '';
            $scope.ITEM_ID = 0;
            $scope.PERIOD_ID = 0;
            $scope.TARGET = 0;
            $scope.STAFF_CODE = '';
            $scope.STAFF_TYPE = '';
            $("#ddlItem1").select2("data", { id: '', text: '--Select Item--' });
            $("#ddlPeriod1").select2("data", { id: '', text: '--Select Period--' });

            $("#ddlItem").select2("data", { id: '', text: '--Select Item--' });
            $("#ddlPeriod").select2("data", { id: '', text: '--Select Period--' });
            $scope.deleteRetailerTargetTemp();
            $scope.loadRetailerTempTargets(0);
            //alert($scope.gridOptionsRetailerTempTargets.length)
            //$scope.gridOptionsRetailerTempTargets = [];
            document.getElementById('uploadedExcelFile').value = '';

            loadRetailerTargets(0);
        };
    }]);

