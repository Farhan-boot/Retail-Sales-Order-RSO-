/**
 * RsoSalaryCtlr.js
 */

app.controller('TargetSetupCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {


        var baseUrl = DirectoryKey +'/SFTS/api/RSOCommission/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Show List";
        $scope.IsExcelDataShow = false;
        $scope.IsStaffExcelDataShow = false;
        // $scope.IsTargetForDisabled = false;
        // $scope.IsTargetItemDisabled = false;
        // $scope.IsTargetPeriodDisabled = false;

        $scope.PageTitle = 'RSO Salary';
        $scope.ListTitle = 'Salary List';
        $scope.waitText = ''

        $scope.gridOptionsTargetSetup = [];
        $scope.currentDate = $filter('date')(new Date(), 'dd/MM/yyyy');
        $scope.SetDate = $scope.currentDate;
        $scope.IsHidden = true;
        $scope.IsShow = true;
        $scope.IsListIcon = true;
        $scope.IsHiddenDetail = true;
        $scope.ShowHide = function () {
            $scope.IsHidden = $scope.IsHidden == true ? false : true;
            $scope.IsHiddenDetail = true;
            if ($scope.IsHidden == true) {
                $scope.btnShowText = "Show List";
                $scope.IsShow = true;

                $scope.IsCreateIcon = false;
                $scope.IsListIcon = true;
                $scope.clear();
            }
            else {
                $scope.btnShowText = "Create";
                $scope.btnSaveText = "Save";
                $scope.IsShow = false;
                $scope.IsHidden = false;

                $scope.IsCreateIcon = true;
                $scope.IsListIcon = false;
                loadAllTarget(0);
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

        GetPermission('01701');

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


































        //*********----Start File Upload----*******************
        var uploadCode = 0;
        var upFile = [];
        $scope.uploadedExcelData = [];
        function getUploadCode() {
            var isPaging = 0;
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                HeaderToken: $scope.HeaderToken,
            };

            var apiRoute = baseUrl + 'GetUploadCode/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
            var upCode = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            upCode.then(function (response) {
                debugger;
                uploadCode = response.data;
                $scope.hUploadCode = uploadCode;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }

        $(document).ready(function () {

            if (window.File && window.FileList && window.FileReader) {
                $("#files").on("change", function (e) {


















                    upFile = [];
                    $scope.IsInProgress = true;
                    $scope.ProgressStatus = 25;
                    $scope.waitText = '...'

                    var files = e.target.files,
                        filesLength = files.length;
                    var name = files[0].name;
                    upFile = files[0]

                    /// file validation //////////////
                    var fileExtension;
                    fileExtension = name.split('.').pop();
                    if (fileExtension != 'xlsx') {
                        Command: toastr["warning"]("file type should be .xlsx !!");
                        document.getElementById('files').value = '';
                        return;
                    }
                    //// file validation /////////////

                    //// Save Excel Start/////////////                  
                    setTimeout(function () { getUploadCode() }, 1000);
                    setTimeout(function () { SaveUploadedExcel() }, 2000);
                    //// Save Excel End/////////////


                });
            } else {
                alert("Your browser doesn't support to File API")
            }
        });

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
                getSavedExcelData();
            } else if (IsInvalidCode == true) {
                ////debugger;
                $scope.IsInProgress = false;
                $scope.IsNotFoundShow = true;
                $scope.ProgressStatus = 0;
                $scope.NotFoundMsg = InvalidCode + " is invalid " + " Code in Row " + RowNo + " Column " + ColNo + " of uploaded Excel!"
                document.getElementById('files').value = '';
                jQuery(window).resize();
                // alert($scope.NotFoundMsg);
            }
        }

        function SaveUploadedExcel() {
            $scope.IsInProgress = true;
            $scope.ProgressStatus = 70;
            $scope.waitText = ' Please wait...'
            ///// Start Saveing Excel/////////////
            var data = new FormData();
            data.append("uploadedFile", upFile);
            data.append("uploadCode", uploadCode);
            data.append("applyType", $scope.TargetFor);
            if ($scope.TargetFor == 2) {
                data.append("applySubType", $scope.StaffType);
            } else {
                data.append("applySubType", 0);
            }
            // ADD LISTENERS.
            var apiRoute = baseUrl + 'SaveUploadDataExcel/';
            var ajaxHelper = new AjaxHelper(apiRoute);
            ajaxHelper.Insert(data, actionCallback);


            getSavedExcelData();
            /////////// End Saveing Excel /////////////////   
        }

        function getSavedExcelData() {
            var isPaging = 0;
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                UploadCode: uploadCode,
                TargetFor: $scope.TargetFor,
                loggeduser: $scope.loggedUserId,
            };

            var apiRoute = baseUrl + 'GetUploadedExcelData/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
            var upCode = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            upCode.then(function (response) {
                //debugger
                $scope.uploadedData = [];
                $scope.uploadedExcelData = []; //distributor
                $scope.uploadedStaffExcelData = []; //staff
                $scope.IsExcelDataShow = false;
                $scope.IsStaffExcelDataShow = false;
                $scope.uploadedData = response.data.FileDataList;;
                if ($scope.uploadedData.length > 0) {
                    $scope.uploadedExcelData = response.data.FileDataList;
                    $scope.TotalRowCount = $scope.uploadedExcelData[0].ROW_COUNT;
                    $scope.TotalTargetValue = $scope.uploadedExcelData[0].TOTAL_SALARY_VALUE;
                    if ($scope.uploadedExcelData != null || $scope.uploadedExcelData != [] || $scope.uploadedExcelData != "" || $scope.uploadedExcelData != undefined) {
                        $scope.IsExcelDataShow = true;
                        $scope.IsStaffExcelDataShow = false;
                        $scope.IsInProgress = true;
                        $scope.ProgressStatus = 100;
                        $scope.waitText = ' Completed!'
                    }
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }

        //*********----End File Upload----*******************   

        //*********---- Export Excel File ---*****************
        $scope.ExportExcelFile = function () {

            fileExport = {
                /*TargetItemId: $scope.TargetItem,
                TargetPeriodId: $scope.TargetPeriod,
                TargetFor: $scope.TargetFor,
                StaffTypeId: $scope.StaffType
                //loggeduser: $scope.loggedUserId,*/

                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
                periodtypeID: 1,
                monthID: $scope.TargetPeriod
            };

            var apiRoute = baseUrl + 'ExportExcelData/';
            var cmnParam = "[" + JSON.stringify(fileExport) + "]";

            var TargetItems = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            TargetItems.then(function (response) {
                if ($scope.TargetPeriod > 0)
                    window.open('/UserFiles/RSO_SALARY/' + response.data, '_blank', '');
                else
                    window.open('/UserFiles/RSO_SALARY/TEMPLATE/' + response.data, '_blank', '');
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }

        loadTargetItems(0);

        //**********----Get Target Items ----***************
        function loadTargetItems(isPaging) {
            //debugger
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                periodtypeID: 3,
                //loggeduser: $scope.loggedUserId,                          
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetTargetPeriodEarning/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var TargetItems = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            TargetItems.then(function (response) {
                $scope.listTargetItem = response.data.objListTargetItem;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }

        loadTargetItems(0);

        //**********----Get Target Period ----***************
        $scope.loadTargetPeriod = function (isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                periodtypeID: 3,
                //loggeduser: $scope.loggedUserId,                              
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetTargetPeriodEarning/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var TargetPeriod = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            TargetPeriod.then(function (response) {
                $scope.listTargetPeriod = response.data.objListTargetPeriod;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }

        $scope.loadTargetPeriod(0);

        //**********----Get All Target----***************
        function loadAllTarget(isPaging) {
            $scope.gridOptionsTargetSetup.enableFiltering = true;
            $scope.gridOptionsTargetSetup.enableGridMenu = true;

            // For Loading
            if (isPaging == 0)
                $scope.pagination.pageNumber = 1;

            //For Loading
            $scope.loaderMoreTarget = true;
            $scope.lblMessageForTarget = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsTargetSetup = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "ROSCODE", displayName: "RSO CODE", title: "RSO CODE", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TARGET", displayName: "TARGET", title: "TARGET", width: '16%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ACHIVEMENT", displayName: "ACHIVEMENT", title: "ACHIVEMENT", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "INCENTIVE", displayName: "INCENTIVE", title: "INCENTIVE", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SALAY_YEAR_MONTH", displayName: "SALAY_YEAR_MONTH", title: "SALAY_YEAR_MONTH", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CAMP_NAME", displayName: "CAMP_NAME", title: "CAMP_NAME", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "KPI", displayName: "KPI", title: "KPI", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "BANK_NAME", displayName: "BANK_NAME", title: "BANK_NAME", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "BANK_AC", displayName: "BANK_AC", title: "BANK_AC", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "VENDOR", displayName: "VENDOR", title: "VENDOR", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "STATUS", displayName: "STATUS", title: "STATUS", width: '10%', headerCellClass: $scope.highlightFilteredHeader },

                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: true,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'RSO_SALARY.csv',
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
                periodtypeID: 1,
                monthID: $scope.TargetPeriod
            };
            var apiRoute = baseUrl + 'GetAllData/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listAllTarget = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listAllTarget.then(function (response) {
                $scope.pagination.totalItems = response.data.recordsTotal;
                $scope.gridOptionsTargetSetup.data = response.data.FileDataList;
                $scope.loaderMoreTarget = false;
                $scope.targetList = response.data.FileDataList;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };
        loadAllTarget(0);

        //**********----Get Single Record----***************
        $scope.getTarget = function (dataModel) {
            $scope.IsShow = true;
            $scope.IsHiddenDetail = false;
            $scope.btnShowText = "Show List";
            $scope.IsHidden = true;
            $scope.btnSaveText = "Update";
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;
            $scope.IsExcelDataShow = false;
            $scope.IsStaffExcelDataShow = false;
            $scope.uploadedExcelData = [];
            $scope.IsInProgress = false;
            $scope.IsNotFoundShow = false;
            document.getElementById('files').value = '';


            $scope.hTargetId = dataModel.TARGET_ID;
            $scope.hVersion = dataModel.VERSION;
            $scope.TargetItem = dataModel.TARGET_ITEM_ID;
            $scope.TargetPeriod = dataModel.TARGET_PERIOD_ID;
            $scope.TargetFor = dataModel.TARGET_FOR_ID;
            $scope.SetDate = dataModel.SET_DATE;
            $scope.RevisionUpTo = dataModel.REVISION_VALID_UP_TO;
            $scope.IsTargetForDisabled = true;
            $scope.IsTargetItemDisabled = true;
            $scope.IsTargetPeriodDisabled = true;

            $("#ddlTargetItem").select2("data", { id: dataModel.TARGET_ITEM_ID, text: dataModel.TARGET_ITEM_NAME });
            $("#ddlTargetPeriod").select2("data", { id: dataModel.TARGET_PERIOD_ID, text: dataModel.PERIOD_NAME });

            if (dataModel.TARGET_FOR_ID == 2) {
                $scope.IsStaffTypeShow = true;
                //$("#ddlStaffType").select2("data", { id: '', text: '--Select Staff Type--' });
                $("#ddlTargetFor").select2("data", { id: dataModel.TARGET_FOR_ID, text: "Staff" });
                $("#ddlStaffType").select2("data", { id: dataModel.STAFF_TYPE_ID, text: dataModel.STAFF_TYPE_NAME });
                $scope.IsStaffTypeDisabled = true;
                $scope.StaffType = dataModel.STAFF_TYPE_ID; //Added by Ashraf
            } else {
                $("#ddlTargetFor").select2("data", { id: dataModel.TARGET_FOR_ID, text: dataModel.TARGET_FOR });
                $scope.IsStaffTypeShow = false;
                $("#ddlStaffType").select2("data", { id: '', text: '--Select Staff Type--' });
            }
        };

        //**********----Create New Record----***************
        $scope.save = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '01702'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveTargetSetup();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };

        $scope.SaveTargetSetup = function () {
            $scope.IsSaveBtnDisabled = true;
            var uploadFile = document.getElementById('files').value;
            if (uploadFile == "") {
                Command: toastr["warning"]("Please upload a valid Target File!");
                $scope.IsSaveBtnDisabled = false;
                return;
            }

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };

            var TargetInfo = {
                Id: $scope.hTargetId == null || $scope.hTargetId == undefined || $scope.hTargetId == "" ? 0 : $scope.hTargetId,
                TargetItemCode: $scope.TargetItem,
                MonthCode: $scope.TargetPeriod,
                UploadCode: $scope.hUploadCode,
                TargetForId: $scope.TargetFor,
                StaffRoleId: $scope.StaffType,
                RevisionUpTo: $scope.RevisionUpTo == "" || $scope.RevisionUpTo == null ? null : conversion.getStringToDate($scope.RevisionUpTo),
                Version: $scope.hVersion == null || $scope.hVersion == undefined || $scope.hVersion == "" ? 0 : $scope.hVersion
            };

            var apiRoute = baseUrl + 'SaveData/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(TargetInfo) + "]";

            var SaveUpdateTarget = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateTarget.then(function (response) {
                if (response.data == "1") {
                    Command: toastr["success"]("Save  Successfully!!");
                    $scope.IsSaveBtnDisabled = false;
                    $scope.clear();
                }
                else if (response.data == "2") {
                    Command: toastr["warning"]("Uploaded data not matched with Period or Item!!");
                    $scope.IsSaveBtnDisabled = false;
                }
                else if (response.data == "3") {
                    Command: toastr["warning"]("Target for this item and period already uploaded, you can update it!!");
                    $scope.IsSaveBtnDisabled = false;
                }
                else if (response.data == "0") {
                    Command: toastr["warning"]("Save Not Successfull!!");
                    $scope.IsSaveBtnDisabled = false;
                }

            },
                function (error) {
                    console.log("Error: " + error);
                });
        }

        //**********----Delete Single Record----***************
        $scope.delete = function (dataModel) {
            var IsConf = confirm('You are about to delete ' + dataModel.TARGET_ITEM_NAME + '. Are you sure?');
        }

        //**********----Reset Record----***************
        $scope.clear = function () {
            $scope.IsHidden = true;
            $scope.IsShow = true;
            $scope.IsHiddenDetail = true
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;

            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Show List";

            $scope.hUploadCode = '';
            $scope.hTargetId = '';
            $scope.hVersion = '';
            $scope.TargetItem = '';
            $scope.TargetPeriod = '';
            $scope.TargetFor = '';
            $scope.StaffType = '';
            $scope.RevisionUpTo = '';
            $scope.IsStaffTypeShow = false;
            $scope.IsTargetForDisabled = false;
            $scope.IsTargetItemDisabled = false;
            $scope.IsTargetPeriodDisabled = false;
            $scope.IsStaffTypeDisabled = false;
            $scope.IsExcelDataShow = false;
            $scope.IsStaffExcelDataShow = false;
            $scope.IsInProgress = false;
            $scope.IsNotFoundShow = false;
            document.getElementById('files').value = '';

            $("#ddlTargetItem").select2("data", { id: '', text: '--Select Target Item--' });
            $("#ddlTargetPeriod").select2("data", { id: '', text: '--Select Target Period--' });
            $("#ddlTargetFor").select2("data", { id: '', text: '--Select Target For--' });
            $("#ddlStaffType").select2("data", { id: '', text: '--Select Staff Type--' });

            loadAllTarget(0);
        };
    }]);
