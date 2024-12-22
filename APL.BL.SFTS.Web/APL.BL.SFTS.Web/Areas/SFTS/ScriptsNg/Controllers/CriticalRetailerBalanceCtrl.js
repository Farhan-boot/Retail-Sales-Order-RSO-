/**
* FocProductCtlr.js
*/
app.controller('CriticalRetailerBalanceCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/CriticalRetailerBalance/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing Critical Balance';
        $scope.ListTitle = 'Critical Balance List';
        $scope.IsCreateIcon = true;
        $scope.IsListIcon = false;
        $scope.IsCriticalBalanceShow = false;
        $scope.gridOptionsCriticalBalances = [];
        $scope.gridOptionsCriticalTempBalances = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;


        $scope.ShowHide = function () {
            if ($scope.IsCriticalBalanceShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.btnShowText = "Create";
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Existing Critical Balances';

                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Add New Critical Balance';
                    $scope.btnShowText = "Show List";
                    $scope.btnSaveShow = true;
                    $scope.btnResetShow = true;
                    $scope.btnSaveText = "Save";
                    $scope.IsShow = false;
                    $scope.IsHidden = false;
             
                    $scope.IsCreateIcon = false;
                    $scope.IsListIcon = true;

                    $scope.deleteCriticalBalanceTemp();
                    $scope.loadCriticalTempBalances(0);
                }
            } else {
                $scope.btnShowText = "Create";
                $scope.IsShow = true;
                $scope.btnSaveShow = false;
                $scope.btnResetShow = false;
                $scope.IsCreateIcon = true;
                $scope.IsListIcon = false;
                $scope.PageTitle = 'Existing Critical Balance';
                $scope.deleteCriticalBalanceTemp();
                $scope.loadCriticalTempBalances(0);

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

        GetPermission('04003');


        //**********----Get All TradeMaterials----***************
        function loadCriticalBalances(isPaging) {

            $scope.gridOptionsCriticalBalances.enableFiltering = true;
            $scope.gridOptionsCriticalBalances.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreCriticalBalances = true;
            $scope.lblMessageForCriticalBalances = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsCriticalBalances = {
                useExternalSorting: false,
                enableSorting: true,
                useExternalPagination: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "RETAILER_CODE", displayName: "Retailer Code", title: "Retailer Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RETAILER_NAME", displayName: "Retailer Name", title: "Retailer Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRIBUTOR_CODE", displayName: "Distributor Code", title: "Distributor Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRIBUTOR_NAME", displayName: "Distributor Name", title: "Distributor Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "PRODUCT_NAME", displayName: "Product Name", title: "Product Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SATURDAY", displayName: "Amount", title: "Amount", width: '10%', headerCellClass: $scope.highlightFilteredHeader },

                    { name: "FROM_DATE", displayName: "From Date", title: "From Date", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TO_DATE", displayName: "To Date", title: "To Date", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "IS_ACTIVE_STR", displayName: "Is Active", title: "IS Active", width: '5%', headerCellClass: $scope.highlightFilteredHeader },
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
                            '<a href="" title="Edit" ng-click="grid.appScope.getCriticalBalance(row.entity)">' +
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
            var apiRoute = baseUrl + 'GetCriticalBalances/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var CriticalBalanceList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            CriticalBalanceList.then(function (response) {
                $scope.gridOptionsCriticalBalances.data = response.data.balanceList;
                $scope.loaderMoreCriticalBalances = false;

                console.log($scope.gridOptionsCriticalBalances.data )
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };
        loadCriticalBalances(0);
        $scope.loadCriticalTempBalances= function (isPaging) {

            $scope.gridOptionsCriticalTempBalances.enableFiltering = true;
            $scope.gridOptionsCriticalTempBalances.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreCriticalTempBalances = true;
            $scope.lblMessageForCriticalTempBalances = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsCriticalTempBalances = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "RETAILER_CODE", displayName: "Retailer Code", title: "Retailer Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RETAILER_NAME", displayName: "Retailer Name", title: "Retailer Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRIBUTOR_CODE", displayName: "Distributor Code", title: "Distributor Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRIBUTOR_NAME", displayName: "Distributor Name", title: "Distributor Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "PRODUCT_NAME", displayName: "Product Name", title: "Product Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SATURDAY", displayName: "Amount", title: "Amount", width: '10%', headerCellClass: $scope.highlightFilteredHeader },

                    { name: "FROM_DATE", displayName: "From Date", title: "From Date", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TO_DATE", displayName: "To Date", title: "To Date", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
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
                            '<span style="display:none" class="label label-info label-mini" style="text-align:center !important;">' +
                            '<a href="" title="Edit" ng-click="grid.appScope.getCriticalBalance(row.entity)">' +
                            '<i class="icon-edit" aria-hidden="true"></i> Edit' +
                            '</a>' +
                            '</span>' +
                            '<span style="display:none"  class="label label-warning label-mini" style="text-align:center !important;">' +
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
            var apiRoute = baseUrl + 'GetCriticalBalancesTemp/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var CriticalBalanceTempList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            CriticalBalanceTempList.then(function (response) {
                $scope.gridOptionsCriticalTempBalances.data = response.data.balanceTempList;
                $scope.loaderMoreCriticalTempBalances = false;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };
        //**********----Get Single Record----***************
        $scope.getCriticalBalance = function (dataModel) {
            //debugger
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Update Critical Balance';
            $scope.btnSaveText = "Update";
            $scope.btnShowText = "Show List";
            $scope.btnSaveShow = true;
            $scope.btnResetShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;

            $scope.IsUpdate = 1;
            $scope.hCriticalBalanceId = dataModel.CRTL_BALANCE_ID;
            $scope.RetailerCode = dataModel.RETAILER_CODE;
            $scope.DistributorCode = dataModel.DISTRIBUTOR_CODE;
            $scope.ProductName = dataModel.PRODUCT_NAME;
            $scope.Saturday = dataModel.SATURDAY;
            $scope.Sunday = dataModel.SUNDAY;
            $scope.Monday = dataModel.MONDAY;
            $scope.Tuesday = dataModel.TUESDAY;
            $scope.Wednesday = dataModel.WEDNESDAY;
            $scope.Thursday = dataModel.THURSDAY;
            $scope.Friday = dataModel.FRIDAY;
            $scope.FromDate = dataModel.FROM_DATE;
            $scope.ToDate = dataModel.TO_DATE;
            $scope.IsActive = dataModel.IS_ACTIVE;

      
        };




        //**********----Create New TradeMaterial----***************

        $scope.save = function () {

            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '04004'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveCriticalBalance();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };

        $scope.SaveCriticalBalance = function () {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };

            var CriticalBalance = {
                CriticalBalanceId: $scope.hCriticalBalanceId === undefined || $scope.hCriticalBalanceId === null ? 0 : $scope.hCriticalBalanceId,
                RetailerCode: $scope.RetailerCode,
                ProductName: $scope.ProductName,
                Saturday: $scope.Saturday,
                Sunday: $scope.Sunday,
                Monday: $scope.Monday,
                Tuesday: $scope.Tuesday,
                Wednesday: $scope.Wednesday,
                Thursday: $scope.Thursday,
                Friday: $scope.Friday,
                FromDate: $scope.FromDate,
                ToDate: $scope.ToDate,
            };


            var apiRoute = baseUrl + 'SaveCriticalBalance/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(CriticalBalance) + "]";

            var SaveUpdateCriticalBalance = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateCriticalBalance.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnShowText = "Create";
                    $scope.PageTitle = 'Add New Critical Balance';
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;
                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    loadCriticalBalances(0);
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
        $scope.deleteCriticalBalanceTemp = function () {

            var objXhr = new XMLHttpRequest();
            var apiRoute = baseUrl + 'DeleteCriticalBalanceTemp';
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
                $scope.loadCriticalTempBalances(0);
            } else if (IsInvalidCode == true) {
                $scope.loadCriticalTempBalances(0);
                ////debugger;
                $scope.IsInProgress = false;
                $scope.IsNotFoundShow = true;
                $scope.ProgressStatus = 0;
                $scope.NotFoundMsg = InvalidCode + " is invalid " + TargetForName + " Code in Row " + RowNo + " Column " + ColNo + " of uploaded Excel!"
                document.getElementById('files').value = '';
                jQuery(window).resize();
                // alert($scope.NotFoundMsg);
            }
        }
        function SaveUploadAllFile() {


            $scope.IsInProgress = true;
            $scope.ProgressStatus = 70;
            $scope.waitText = ' Please wait...'

            var data = new FormData();
            data.append("uploadedExcelFile", upExcelFile);

            var productName=  $('#ddlProduct').val();
            var objXhr = new XMLHttpRequest();
            var loggeduser = $scope.loggedUserId
            var apiRoute = baseUrl + 'SaveUploadAllFile?product=' + productName + '&userId=' + loggeduser;
            //objXhr.open("POST", apiRoute);
            //var saveFile = objXhr.send(data)
            var ajaxHelper = new AjaxHelper(apiRoute);
            ajaxHelper.Insert(data, actionCallback);
            
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
                    SaveUploadAllFile();
                    $scope.IsUpdate = 0;
                    $scope.hCriticalBalanceId = 0;
                    $scope.RetailerCode = "Test";
                    $scope.DistributorCode = "Test";
                    $scope.ProductName = "Test";
                    $scope.Saturday = 1;

                    $scope.FromDate = "01/01/1900";
                    $scope.ToDate = "01/01/1900";
                    $scope.IsActive = 1;
                    //$scope.loadCriticalTempBalances(0);
                    //setTimeout(function () { SaveUploadAllFile() }, 3000);
                    //setTimeout(function () { $scope.loadCriticalTempBalances(0) }, 1000);

                });
            } else {
                alert("Your browser doesn't support to File API")
            }
        });
        $scope.hCriticalBalanceId = 0;
        $scope.IsUpdate = 0;
        $scope.GroupFor = 1;
        $scope.IsActive = 1;
        //**********----Reset Record----***************
        $scope.clear = function () {
            $scope.IsHidden = true;
            $scope.IsShow = true;
            $scope.IsHiddenDetail = true
            $scope.IsCreateIcon = true;
            $scope.IsListIcon = false;

            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Create";

            $scope.hCriticalBalanceId = 0;
            $scope.IsUpdate = 0;
            $scope.RetailerCode = '';
            $scope.ProductName = '';
            $scope.Saturday = 0;
            $scope.Sunday = 0;
            $scope.Monday = 0;
            $scope.Tuesday = 0;
            $scope.Wednesday = 0;
            $scope.Thursday = 0;
            $scope.Friday = 0;
            $scope.FromDate = '';
            $scope.ToDate = '';
            $scope.IsActive = 1;
            document.getElementById('uploadedExcelFile').value = '';
            $scope.deleteCriticalBalanceTemp();
            $scope.loadCriticalTempBalances(0);
            loadCriticalBalances(0);
        };
    }]);

