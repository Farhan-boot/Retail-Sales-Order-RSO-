/**
* FocProductCtlr.js
*/
app.controller('NotificationSetupTikCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/NotificationSetup/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing Notice';
        $scope.ListTitle = 'Notification List';
        $scope.IsCreateIcon = true;
        $scope.IsListIcon = false;
        $scope.IsNoticeShow = false;
        $scope.gridOptionsNotice = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;
        var selectedRegion = [];
        $scope.ListSelectedRegion = [];
        $scope.listDDLRegion = [];

        var selectedDistributor = [];
        $scope.ListSelectedDistributor = [];
        $scope.listDDLDistributor = [];
        $scope.ShowHide = function () {
            if ($scope.IsNoticeShow == false) {
                $scope.IsHidden = $scope.IsHidden === true ? false : true;
                if ($scope.IsHidden === true) {
                    $scope.btnShowText = "Create";
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Existing Notice';
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Add New Notice';
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
                $scope.PageTitle = 'Existing Notice';
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

        GetPermission('04007');

        function loadNoticeTypes(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RoleId: 0,
                //loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = baseUrl + '/GetNoticeTypeList';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listNoticeTypes = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listNoticeTypes.then(function (response) {
                $scope.listNoticeTypes = response.data.objListCenterType;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        loadNoticeTypes(0);
        function loadNoticeFors(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                NoticeType_Id: 2,
                                         
            };

            var apiRoute = baseUrl + '/GetNoticeForList';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listNoticeFors = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listNoticeFors.then(function (response) {
                $scope.listNoticeFors = response.data.noticeForList;


            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        loadNoticeFors(0);

        //**********----Get All TradeMaterials----***************
        function loadNotice(isPaging) {

            $scope.gridOptionsNotice.enableFiltering = true;
            $scope.gridOptionsNotice.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreNotice = true;
            $scope.lblMessageForNotice = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsNotice = {
                useExternalSorting: false,
                enableSorting: true,
                useExternalPagination: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "NOTICE_TYPE", displayName: "NOTICE TYPE", title: "NOTICE TYPE", width: '13%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "NOTICE_FOR", displayName: "NOTICE FOR", title: "NOTICE FOR", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "FROM_DATE", displayName: "FROM DATE", title: "FROM DATE", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TO_DATE", displayName: "TO DATE", title: "TO DATE", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TITLE", displayName: "TITLE", title: "TITLE", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MESSAGE", displayName: "MESSAGE", title: "MESSAGE", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "URL", displayName: "URL", title: "URL", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    //{ name: "FILENAME", displayName: "FILENAME", title: "FILENAME", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    //{ name: "IS_ACTIVE", displayName: "IS ACTIVE", title: "IS ACTIVE", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
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
                            '<a href="" title="Edit" ng-click="grid.appScope.getNotice(row.entity)">' +
                            '<i class="icon-edit" aria-hidden="true"></i> Edit' +
                            '</a>' +
                            '</span>' +
                            '<span  class="label label-warning label-mini" style="display:none;text-align:center !important;">' +
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
                exporterCsvFilename: 'Notice List.csv',
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
                NoticeType_Id: 2
            };
            var apiRoute = baseUrl + 'GetNoticeList';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listTradeMaterial = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listTradeMaterial.then(function (response) {
                $scope.gridOptionsNotice.data = response.data.noticeList;
                $scope.loaderMoreNotice = false;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };
        loadNotice(0);
        $scope.ExportExcelFile = function (forId) {
            $scope.IsInProgress = true;
            $scope.waitText = ' Please wait...';
            fileExport = {
                NoticeForId: forId
                //loggeduser: $scope.loggedUserId,                          
            };

            var apiRoute = baseUrl + 'ExportExcelTemplate/';
            var cmnParam = "[" + JSON.stringify(fileExport) + "]";

            var TargetItems = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            TargetItems.then(function (response) {
                $scope.IsInProgress = false;
                $scope.waitText = '';
                window.open(DirectoryKey +'/UserFiles/' + response.data, '_blank', '');
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        //**********----Get Single Record----***************
        $scope.getNotice = function (dataModel) {
            //debugger
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Update Notice';
            $scope.btnSaveText = "Update";
            $scope.btnShowText = "Show List";
            $scope.btnSaveShow = true;
            $scope.btnResetShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;


            $scope.hNOTICE_ID = dataModel.NOTICE_ID;
            $scope.NOTICE_TYPE_ID = dataModel.NOTICE_TYPE_ID;
            $scope.NOTICE_TYPE = dataModel.NOTICE_TYPE;
            $scope.NOTICE_FOR_ID = dataModel.NOTICE_FOR_ID;
            $scope.NOTICE_FOR = dataModel.NOTICE_FOR;
            $scope.FROM_DATE = dataModel.FROM_DATE;
            $scope.TO_DATE = dataModel.TO_DATE;
            $scope.TITLE = dataModel.TITLE;
            $scope.MESSAGE = dataModel.MESSAGE;
            $scope.URL = dataModel.URL;
            $scope.FILENAME = dataModel.FILENAME;
            $scope.IS_ACTIVE = dataModel.IS_ACTIVE;

            $scope.DD_IDS = dataModel.DD_IDS;
            $scope.DD_NAMES = dataModel.DD_NAMES;
            $scope.RE_IDS = dataModel.RE_IDS;
            $scope.RE_NAMES = dataModel.RE_NAMES;

            if (dataModel.NOTICE_FOR_ID === 1) {

                $scope.IsRegionShow = false;
                $scope.IsDitriburotShow = false;
                $scope.IsRSOShow = false;
                $scope.IsRetailerShow = false;
            } else if (dataModel.NOTICE_FOR_ID === 2) {

                $scope.IsRegionShow = true;
                $scope.IsDitriburotShow = false;
                $scope.IsRSOShow = false;
                $scope.IsRetailerShow = false;
                loadRegions(0);
            }
            else if (dataModel.NOTICE_FOR_ID === 3) {

                $scope.IsRegionShow = false;
                $scope.IsDitriburotShow = true;
                $scope.IsRSOShow = false;
                $scope.IsRetailerShow = false;
                loadDistributors(0);
            } else if (dataModel.NOTICE_FOR_ID === 4) {

                $scope.IsRegionShow = false;
                $scope.IsDitriburotShow = false;
                $scope.IsRSOShow = true;
                $scope.IsRetailerShow = false;
            }
            else if (dataModel.NOTICE_FOR_ID === 5) {

                $scope.IsRegionShow = false;
                $scope.IsDitriburotShow = false;
                $scope.IsRSOShow = false;
                $scope.IsRetailerShow = true;
            }
         
            $("#ddlNoticeType").select2("data", { id: dataModel.NOTICE_TYPE_ID, text: dataModel.NOTICE_TYPE });
            $("#ddlNoticeFor").select2("data", { id: dataModel.NOTICE_FOR_ID, text: dataModel.NOTICE_FOR });


        };

        function loadRegions(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId
            };

            var apiRoute = baseUrl + '/GetRegions'; //'/mDMS/SFTS/api/CmnDropdown/GetRegions/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var regionList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            regionList.then(function (response) {

                console.log(response.data);
                $scope.regionList = response.data.objListRegion;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        //loadRegions(0);

        function loadDistributors(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId
            };

            var apiRoute = baseUrl + '/GetDistributors';  //'/mDMS/SFTS/api/CmnDropdown/GetDistributors/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var distributorList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            distributorList.then(function (response) {

                console.log(response.data);
                $scope.distributorList = response.data.objListDistributor;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }


        $("#ddlNoticeType").select2("data", { id: 2, text: 'Ticker Notification' });
        $scope.NOTICE_TYPE_ID = 2;
        $("#ddlNoticeType").prop("disabled", true);

        $scope.noticeForChanged = function () {

            $scope.IsRegionShow = false;
            $scope.IsDitriburotShow = false;
            $scope.IsRSOShow = false;
            $scope.IsRetailerShow = false;

            if ($scope.NOTICE_FOR_ID === 2) {
                $scope.IsRegionShow = true;
                DISTRIBUTOR_ID = 0;
                loadRegions(0);
            } else if ($scope.NOTICE_FOR_ID === 3) {
                $scope.IsDitriburotShow = true;
                REGION_ID = 0;
                loadDistributors(0);
            } else if ($scope.NOTICE_FOR_ID === 4) {
                $scope.IsRSOShow = true;
                $scope.IsRetailerShow = false;
            } else if ($scope.NOTICE_FOR_ID === 5) {
                $scope.IsRetailerShow = true;
                $scope.IsRSOShow = false;
            }
        }

        $scope.IS_ACTIVE = 1;

        //**********----Create New TradeMaterial----***************

        $scope.save = function () {
            $('#save').attr('disabled', 'disabled');
            //var noticeId = $('#hNOTICE_ID').val() ?? "";

            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '04008'
            };
            //if ($scope.NOTICE_FOR_ID === 2) {
            //    if ($scope.TITLE == '') {
            //        alert('Sorry! excel file not Selected');
            //        $('#save').removeAttr('disabled');
            //        return;
            //    }
            //    if ($scope.TITLE == '') {
            //        alert('Sorry! excel file not Selected');
            //        $('#save').removeAttr('disabled');
            //        return;
            //    }
            //}
            if ($scope.NOTICE_FOR_ID === 4 && document.getElementById('uploadedExcelFile').value == '' && $scope.hNOTICE_ID == 0) {
                alert('Sorry! excel file not Selected');
                $('#save').removeAttr('disabled');
                return;
            }
            if ($scope.NOTICE_FOR_ID === 5 && document.getElementById('upExcelRetailerFile').value == '' && $scope.hNOTICE_ID == 0) {
                alert('Sorry! excel file not Selected');
                $('#save').removeAttr('disabled');
                return;
            }

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveNotice();
                   // $('#save').removeAttr('disabled');
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    $('#save').removeAttr('disabled');
                    return;
                }
            },
                function (error) {
                    console.log("Error: " + error);
                    $('#save').removeAttr('disabled');
                });
        };
        //var fileList = [];
        $scope.SaveNotice = function () {


            var fileName = $('#hdFileName').val();
            var excelFileName = $('#hdExcelFileName').val();
            var retailerExcelFileName = $('#hdRetlrExcelFileName').val();
          
            var regions = 0;// $('#ddlRegion').val() !== null ? $('#ddlRegion').val().toString() : $('#ddlRegion').val();
            var distributors = 0;// $('#ddlDistributor').val() !== null ? $('#ddlDistributor').val().toString() : $('#ddlDistributor').val();
            //if (regions === null) {
            //    regions = $('#hdRegions').val().toString();
            //}
            //if (regions === null) {
            //    distributors = $('#hdDistributors').val().toString();
            //}
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };

            var Notice = {
                NoticeId: $scope.hNOTICE_ID === undefined || $scope.hNOTICE_ID === null ? 0 : $scope.hNOTICE_ID,
                NoticeTypeId: $scope.NOTICE_TYPE_ID,
                NoticeForId: $scope.NOTICE_FOR_ID,
                FromDate: $scope.FROM_DATE,
                ToDate: $scope.TO_DATE,
                Title: $scope.TITLE,
                Message: $scope.MESSAGE,
                Url: $scope.URL,
                FileName: fileName,
                IsActive: $scope.IS_ACTIVE,
                RegionIds: regions,
                DistributorIds: distributors,
                ExcelFileName: excelFileName,
                RtExcelFileName: retailerExcelFileName
            };



            var apiRoute = baseUrl + 'SaveNotification';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(Notice) + "," + JSON.stringify(selectedRegion) + "," + JSON.stringify(selectedDistributor) + "]";



            SaveUploadAllFile();
            var SaveUpdateNotice = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateNotice.then(function (response) {
                if (response.data !== "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnShowText = "Create";
                    $scope.PageTitle = 'Add New Notice';
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;
                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    loadNotice(0);
                }
                else if (response.data == "") {
                    Command: toastr["warning"]("Save Not Successfull!!!!");
                    $('#save').removeAttr('disabled');
                }
            },
                function (error) {
                    console.log("Error: " + error);
                    $('#save').removeAttr('disabled');
                });
        }


        var upFile = [];
        var upExcelFile = [];
        var upRetailerExcelFile = [];
        
        function SaveUploadAllFile() {
            $scope.IsInProgress = true;
            $scope.ProgressStatus = 70;
            $scope.waitText = ' Please wait...'

            var data = new FormData();
            data.append("uploadedFile", upFile);
            data.append("uploadedExcelFile", upExcelFile);
            data.append("upRetailerExcelFile", upRetailerExcelFile);


            var objXhr = new XMLHttpRequest();
            var apiRoute = baseUrl + 'SaveUploadAllFile/';
            objXhr.open("POST", apiRoute);
            var saveFile = objXhr.send(data);


        }
        $(document).ready(function () {

            if (window.File && window.FileList && window.FileReader) {
                $("#fileToUpload").on("change", function (e) {

                    $scope.IsInProgress = true;
                    $scope.ProgressStatus = 25;
                    $scope.waitText = '...'

                    var files = e.target.files,
                        filesLength = files.length;
                    var name = files[0].name;

                    $('#hdFileName').val(name);
                    upFile = files[0]

                    var fileExtension;
                    fileExtension = name.split('.').pop();

                    if (fileExtension !== 'pdf' && fileExtension !== 'png' && fileExtension !== 'jpg') {
                        Command: toastr["warning"]("file type should be pdf/png/jpg !!");
                        document.getElementById('fileToUpload').value = '';
                        return;
                    }

                    //SaveUploadedImgPdf();

                });
            } else {
                alert("Your browser doesn't support to File API")
            }

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

                });
            } else {
                alert("Your browser doesn't support to File API")
            }

            if (window.File && window.FileList && window.FileReader) {
                $("#upExcelRetailerFile").on("change", function (e) {

                    $scope.IsInProgress = true;
                    $scope.ProgressStatus = 25;
                    $scope.waitText = '...'

                    var files = e.target.files,
                        filesLength = files.length;
                    var name = files[0].name;

                    $('#hdRetlrExcelFileName').val(name);
                    upRetailerExcelFile = files[0]

                    var fileExtension;
                    fileExtension = name.split('.').pop();

                    if (fileExtension !== 'xls' && fileExtension !== 'xlsx') {
                        Command: toastr["warning"]("file type should be xls/xlsx !!");
                        document.getElementById('upExcelRetailerFile').value = '';
                        return;
                    }

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
                if (data == null) {
                    xhr.send();
                }
                else {
                    xhr.send(data);
                }
            }

            this.Insert = function (obj, callback) {
                callWebAPI(this._baseUrl, "POST", obj, callback);
            }
        }
        $scope.delete = function (dataModel) {
            var isDelete = confirm('You are about to delete ' + dataModel.TITLE + '. Are you sure?');
            if (isDelete == true) {
                objcmnParam = {
                    pageNumber: page,
                    pageSize: pageSize,
                    IsPaging: isPaging,
                    loggeduser: $scope.loggedUserId
                };
                var TableInfo = {
                    NoticeId: dataModel.NOTICE_ID
                };
                var apiRoute = baseUrl + 'DeleteInfo/';

                var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(TableInfo) + "]";

                var deleteInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
                deleteInfo.then(function (response) {
                    // debugger;
                    if (response.data != "") {
                        Command: toastr["success"]("Delete  Successfully!!!!");
                        loadNotice(0);
                    }
                    else if (response.data == "") {
                        Command: toastr["warning"]("Delete Not Successfull!!!!");
                    }

                }, function (error) {
                        console.log("Error: " + error);

                });
            }
        }
        $scope.hNOTICE_ID = 0;
        //**********----Reset Record----***************
        $scope.clear = function () {
            $scope.IsHidden = true;
            $scope.IsShow = true;
            $scope.IsHiddenDetail = true
            $scope.IsCreateIcon = true;
            $scope.IsListIcon = false;
            $scope.btnSaveShow = false;
            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Create";

            $scope.hNOTICE_ID = 0;
            $scope.NOTICE_TYPE_ID = 2;
            $scope.NOTICE_TYPE = '';
            $scope.NOTICE_FOR_ID = 0;
            $scope.FROM_DATE = '';
            $scope.TO_DATE = '';
            $scope.TITLE = '';
            $scope.MESSAGE = '';
            $scope.URL = '';
            $scope.FILENAME = '';
            $scope.IS_ACTIVE = 1;
           // $("#ddlNoticeType").select2("data", { id: '', text: '--Select Notification Type--' });
            $("#ddlNoticeFor").select2("data", { id: '', text: '--Select Notification For--' });

            $("#ddlNoticeFor").select2("data", { id: '', text: '--Select Notification For--' });
            $("#ddlRegion").select2("data", { id: '', text: '--Select Region--' });
            $("#ddlDistributor").select2("data", { id: '', text: '--Select Distributor--' });
            $scope.IsRegionShow = false;
            $scope.IsDitriburotShow = false;
            $scope.IsRSOShow = false;
            $scope.IsRetailerShow = false;
            document.getElementById('uploadedExcelFile').value = '';
            document.getElementById('upExcelRetailerFile').value = '';
            $('#save').removeAttr('disabled');
            $('#hdFileName').val('');
            $('#hdExcelFileName').val('');
            $('#hdRetlrExcelFileName').val('');
            loadNotice(0);
        };
    }]);

