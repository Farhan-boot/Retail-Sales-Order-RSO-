/**
* FocProductCtlr.js
*/
app.controller('NotificationSetupFlsCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
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

        GetPermission('04009');

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
                NoticeType_Id: 3,
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
                    { name: "NOTICE_TYPE", displayName: "NOTICE TYPE", title: "NOTICE TYPE", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "NOTICE_FOR", displayName: "NOTICE FOR", title: "NOTICE FOR", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "FROM_DATE", displayName: "FROM DATE", title: "FROM DATE", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TO_DATE", displayName: "TO DATE", title: "TO DATE", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    //{ name: "TITLE", displayName: "TITLE", title: "TITLE", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    //{ name: "MESSAGE", displayName: "MESSAGE", title: "MESSAGE", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    //{ name: "URL", displayName: "URL", title: "URL", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
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
                            '<span class="label label-warning label-mini" style="display:none;text-align:center !important;">' +
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
                NoticeType_Id: 3
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
           // $scope.FILENAME = dataModel.FILENAME;
            $scope.IS_ACTIVE = dataModel.IS_ACTIVE;
            $scope.DD_IDS = dataModel.DD_IDS;
            $scope.DD_NAMES = dataModel.DD_NAMES;
            $scope.RE_IDS = dataModel.RE_IDS;
            $scope.RE_NAMES = dataModel.RE_NAMES;

            $scope.FILENAME = DirectoryKey +'/UserFiles/Notification/' + (dataModel.FILENAME == "" || dataModel.FILENAME == null ? "default_image.png" : dataModel.FILENAME);

            //$scope.FILENAME = DirectoryKey +'/UserFiles/Notification/'+ (dataModel.FILENAME == "" || dataModel.FILENAME == null ? "default_image.png" : dataModel.FILENAME);
            if (dataModel.NOTICE_FOR_ID === 1) {

                $scope.IsRegionShow = false;
                $scope.IsDitriburotShow = false;
                $scope.IsRSOShow = false;
            } else if (dataModel.NOTICE_FOR_ID === 2) {

                $scope.IsRegionShow = true;
                $scope.IsDitriburotShow = false;
                $scope.IsRSOShow = false;
                loadRegions(0);
            }
            else if (dataModel.NOTICE_FOR_ID === 3) {

                $scope.IsRegionShow = false;
                $scope.IsDitriburotShow = true;
                $scope.IsRSOShow = false;
                loadDistributors(0);
            } else if (dataModel.NOTICE_FOR_ID === 4) {

                $scope.IsRegionShow = false;
                $scope.IsDitriburotShow = false;
                $scope.IsRSOShow = true;
            }

            $scope.GetNoticeReg(dataModel.NOTICE_ID);

            $scope.IsTime1Show = false;
            var times = dataModel.NOTICE_TIMES.split(',');
            for (var i = 0; i < times.length; i++) {
                var html = '';

                html += '<div class="input-group" id="inputFormRow">';
                html += '<input type="time" name="time" class="form-control m-input" value="' + times[i]+'" placeholder="HH:MM:SS" autocomplete="off">';
                html += '<div class="input-group-addon">';
                html += '<span id="removeRow"><i class="fa fa-trash"></i></span>';
                html += '</div><span class="error">*</span>';
                html += '</div>';

                $('#newRow').append(html);
            }
            $("#ddlNoticeType").select2("data", { id: dataModel.NOTICE_TYPE_ID, text: dataModel.NOTICE_TYPE });
            $("#ddlNoticeFor").select2("data", { id: dataModel.NOTICE_FOR_ID, text: dataModel.NOTICE_FOR });


        };
        $scope.IsTime1Show = true;
        $scope.GetNoticeReg = function (Notice_Id) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                Notice_Id: Notice_Id,
                //loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetNotificationSetupReg/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listnoticeReg = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listnoticeReg.then(function (response) {
                $scope.noticeReg = response.data.noticeReg;
                $scope.ListSelectedRegion = $scope.noticeReg;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
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

                selectedRegion = $scope.ListSelectedRegion;
                $scope.listDDLRegion = [];
                if (response.data.objListRegion.length > 0) {
                    $scope.listDDLRegion = response.data.objListRegion;

                    console.log($scope.listDDLRegion);
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }


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


        $("#ddlNoticeType").select2("data", { id: 3, text: 'Flash Pop-Ups' });
        $scope.NOTICE_TYPE_ID = 3;
        $("#ddlNoticeType").prop("disabled", true);
        $("#ddlNoticeFor").select2("data", { id: 2, text: 'Region' });
        $scope.NOTICE_FOR_ID = 2;
        //$("#ddlNoticeFor").prop("disabled", true);
        $scope.IsRegionShow = true;
        loadRegions(0);

        $scope.noticeForChanged = function () {

            $scope.IsRegionShow = false;
            $scope.IsDitriburotShow = false;
            $scope.IsRSOShow = false;

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
            }
        }

        $scope.IS_ACTIVE = 1;

        //**********----Create New TradeMaterial----***************

        $scope.save = function () {

            $('#save').attr('disabled', 'disabled');
           
            //if ($scope.hNOTICE_ID==0 && document.getElementById('fileToUpload').value == '') {
            //    alert('Sorry! image/pdf file not Selected');
            //    return;
            //}
            var mInput = false;
            var i = 0;
            $(".m-input").each(function () {
               
                // Test if the div element is empty
               
                    if (i==0 && $scope.IsTime1Show == false) {
                        mInput = false;
                    }
                    else {
                        if ((i == 0 && $(this).val() == "") ){
                            mInput = true;
                        } else if ((i > 0 && $(this).val() == "")) {
                            mInput = true;
                        }
                    }

              

                i=i+1;
            });

            if ($scope.hNOTICE_ID == 0 ) {

                if ( i == 0 && mInput == false) {
                    alert('Sorry! required time is not selected');
                    $('#save').removeAttr('disabled');
                    return;
                }
                else if ( i == 1 && mInput == true) {
                    alert('Sorry! required time is not selected');
                    $('#save').removeAttr('disabled');
                    return;
                }

                if (i > 1 && mInput == true) {
                    alert('Sorry! required time is not selected');
                    $('#save').removeAttr('disabled');
                    return;
                }
            }
            else if ($scope.hNOTICE_ID>0) {
                if (i == 0 && mInput == false) {
                    alert('Sorry! required time is not selected 1');
                    $('#save').removeAttr('disabled');
                    return;
                }
                else if (i == 1 && mInput == false) {
                    alert('Sorry! required time is not selected 2');
                    $('#save').removeAttr('disabled');
                    return;
                }

                if (i > 1 && mInput == true) {
                    alert('Sorry! required time is not selected 3');
                    $('#save').removeAttr('disabled');
                    return;
                }
            }
            

            if ($scope.NOTICE_FOR_ID === 2 && $scope.ListSelectedRegion.length == 0) {
                $('#save').removeAttr('disabled');
                alert('Sorry! Region not Selected');
                return;
            }
            if ($scope.FILENAME == DirectoryKey +'/UserFiles/Notification/default_image.png') {
                if (document.getElementById('fileToUpload').value == '') {
                    alert('Sorry! image/pdf file is empty');
                    $('#save').removeAttr('disabled');
                    return;
                }
            }
 
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '04010'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveNotice();
             
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

            var regions = 0;// $('#ddlRegion').val() !== null ? $('#ddlRegion').val().toString() : $('#ddlRegion').val();
            var distributors = 0;// $('#ddlDistributor').val() !== null ? $('#ddlDistributor').val().toString() : $('#ddlDistributor').val();

            /*
            if (regions === null) {
                regions = $('#hdRegions').val().toString();
            }

            if (distributors === null) {
                distributors = $('#hdDistributors').val().toString();
            }
            */
            var flashTimes = '';

            $('.m-input').each(function () {
                flashTimes += $(this).val() + ','; // add to string
            });



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
                FlashTimes: flashTimes
            };



            var apiRoute = baseUrl + 'SaveNotification';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(Notice) + "," + JSON.stringify($scope.ListSelectedRegion) + "," + JSON.stringify($scope.ListSelectedDistributor) + "]";



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

        function SaveUploadAllFile() {
            $scope.IsInProgress = true;
            $scope.ProgressStatus = 70;
            $scope.waitText = ' Please wait...'

            var data = new FormData();
            data.append("uploadedFile", upFile);
 

            var objXhr = new XMLHttpRequest();
            var apiRoute = baseUrl + 'SaveUploadAllFile/';
            objXhr.open("POST", apiRoute);
            var saveFile = objXhr.send(data);


        }
        $(document).ready(function () {

            $('#select2-drop').prop('style', 'display: none; top: 0px; left: 0px; width: 100px;');

            if (window.File && window.FileList && window.FileReader) {
                $("#fileToUpload").on("change", function (e) {
                    var FlashNoticeMaxLength = 2;
                    $scope.IsInProgress = true;
                    $scope.ProgressStatus = 25;
                    $scope.waitText = '...'

                    var files = e.target.files,
                        filesLength = files.length;
                    var name = files[0].name;

                    var fileExtension;     //change
                    fileExtension = name.split('.').pop().toLowerCase();

                    if (fileExtension !== 'png' && fileExtension !== 'jpg' && fileExtension !== 'bmp') {
                        Command: toastr["warning"]("file type should be png/jpg/bmp !!");
                        document.getElementById('fileToUpload').value = '';
                        return;
                    }
                    if (files[0].size > FlashNoticeMaxLength * 1024 * 1024) {
                        Command: toastr["warning"]("Your file is " + Math.round(files[0].size / (1024 * 1024)) + "MB, Please upload file less than " + FlashNoticeMaxLength + "MB!!");
                        document.getElementById('fileToUpload').value = '';
                        return;
                    }

                    $('#hdFileName').val(name);
                    upFile = files[0]
                    var reader = new FileReader();
                    reader.onload = $scope.imageIsLoaded;
                    reader.readAsDataURL(files[0]);

                   

                    //SaveUploadedImgPdf();

                });
            } else {
                alert("Your browser doesn't support to File API")
            }
            $("#addRow").click(function () {
                var html = '';

                html += '<div class="input-group" id="inputFormRow">';
                html += '<input type="time" name="time" class="form-control m-input" placeholder="HH:MM:SS" autocomplete="off">';
                html += '<div class="input-group-addon">';
                html += '<span id="removeRow"><i class="fa fa-trash"></i></span>';
                html += '</div><span class="error">*</span>';
                html += '</div> ';

                $('#newRow').append(html);
            });

            // remove row
            $(document).on('click', '#removeRow', function () {
                $(this).closest('#inputFormRow').remove();

                
            });

        });
        $scope.imageIsLoaded = function (e) {
            $scope.$apply(function () {
                $scope.FILENAME = e.target.result;
            });
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
        //$scope.FILENAME = DirectoryKey +"/UserFiles/Notification/default_image.png";
        $scope.FILENAME = DirectoryKey +"/UserFiles/Notification/default_image.png";
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
            $scope.NOTICE_TYPE_ID = 3;
            $scope.NOTICE_TYPE = '';
            $scope.NOTICE_FOR_ID = 0;
            $scope.FROM_DATE = '';
            $scope.TO_DATE = '';
            $scope.TITLE = '';
            $scope.MESSAGE = '';
            $scope.URL = '';
            //$scope.FILENAME = '';
            $scope.IS_ACTIVE = 1;
            $scope.FILENAME = DirectoryKey +"/UserFiles/Notification/default_image.png";
            //$("#ddlNoticeType").select2("data", { id: '', text: '--Select Notification Type--' });
            $("#ddlNoticeFor").select2("data", { id: '', text: '--Select Notification For--' });
            $("#ddlRegion").select2("data", { id: '', text: '--Select Region--' });
            document.getElementById('fileToUpload').value = '';
            $scope.IsRegionShow = false;
            $('#save').removeAttr('disabled');
            $('#hdFileName').val('');
            $('#hdExcelFileName').val('');
            $('#hdRetlrExcelFileName').val('');

            $('.m-input').val('');
            $('#newRow').html('');
            $scope.ListSelectedRegion = [];
            loadNotice(0);
        };
    }]);

