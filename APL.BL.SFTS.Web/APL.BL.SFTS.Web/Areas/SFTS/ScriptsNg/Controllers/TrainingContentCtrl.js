/**
* FocProductCtlr.js
*/
app.controller('TrainingContentCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/TrainingContent/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing Training Content';
        $scope.ListTitle = 'Training Content List';
        $scope.IsCreateIcon = true;
        $scope.IsListIcon = false;
        $scope.IsTrainingContentShow = false;
        $scope.gridOptionsTrainingContents = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;

        $scope.ShowHide = function () {
            if ($scope.IsTrainingContentShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.btnShowText = "Create";
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Existing Training Contents';
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Add New Training Content';
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
                $scope.PageTitle = 'Existing Training Content';
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

        GetPermission('00912');


        //**********----Get All TradeMaterials----***************
        function loadTrainingContents(isPaging) {

            $scope.gridOptionsTrainingContents.enableFiltering = true;
            $scope.gridOptionsTrainingContents.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreTrainingContents = true;
            $scope.lblMessageForTrainingContents = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsTrainingContents = {
                useExternalSorting: false,
                enableSorting: true,
                useExternalPagination: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "CONTENT_NAME", displayName: "CONTENT NAME", title: "CONTENT NAME", width: '25%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TRAINING_NAME", displayName: "TRAINING NAME", title: "TRAINING NAME", width: '25%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "UPLOADED_DATE", displayName: "UPLOADED DATE", title: "UPLOADED DATE", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "OTHER_LINK", displayName: "OTHER LINK", title: "OTHER LINK", width: '30%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "IS_ACTIVE_STR", displayName: "IS ACTIVE", title: "IS ACTIVE", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
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
                            '<a href="" title="Edit" ng-click="grid.appScope.getTrainingContent(row.entity)">' +
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
            var apiRoute = baseUrl + 'GetTrainingContents/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var TrainingContentList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            TrainingContentList.then(function (response) {
                $scope.gridOptionsTrainingContents.data = response.data.menuGroupList;
                $scope.loaderMoreTrainingContents = false;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };
        loadTrainingContents(0);

        //**********----Get Single Record----***************
        $scope.getTrainingContent = function (dataModel) {
            //debugger
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Update Training Content';
            $scope.btnSaveText = "Update";
            $scope.btnShowText = "Show List";
            $scope.btnSaveShow = true;
            $scope.btnResetShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;


            $scope.hTrainingContentId = dataModel.TRAINING_ID;
            $scope.CONTENT_NAME = dataModel.CONTENT_NAME;
            $scope.TRAINING_NAME = dataModel.TRAINING_NAME;
            $scope.UPLOADED_DATE = dataModel.UPLOADED_DATE;
            $scope.OTHER_LINK = dataModel.OTHER_LINK;
            $scope.UploadedFileLink = DirectoryKey +"/UserFiles/TrainingContent/" + (dataModel.UPLOADED_FILE_LINK == "" || dataModel.UPLOADED_FILE_LINK == null ? "default_image.png" : dataModel.UPLOADED_FILE_LINK);
            $scope.IsActive = dataModel.IS_ACTIVE;

            $('#hdFileName').val(dataModel.UPLOADED_FILE_LINK);
        };




        //**********----Create New TradeMaterial----***************

        $scope.save = function () {
            $('#save').attr('disabled', 'disabled');
            var Isvalid = true;

            //if ($scope.UploadedFileLink == '' || $scope.OTHER_LINK=='') {
            //    if (document.getElementById('txtOtherLink').value == '' && document.getElementById('fileToUpload').value == '') {
            //        alert('Sorry! link or upload image/pdf file is empty');
            //        $('#save').removeAttr('disabled');
            //        return;
            //    }
            //}
   
           
        
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '00913'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                
                    $scope.SaveTrainingContent();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };

        $scope.SaveTrainingContent = function () {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };
            var fileName = $('#hdFileName').val();

            //if (fileName == "" && $scope.OTHER_LINK == "")
            //{
            //    Command: toastr["warning"]("Please input Link or upload file!!");
            //    return;
            //}
            var TrainingContent = {
                TrainingId: $scope.hTrainingContentId === undefined || $scope.hTrainingContentId === null ? 0 : $scope.hTrainingContentId,
                ContentName: $scope.CONTENT_NAME,
                TrainingName: $scope.TRAINING_NAME,
                UploadedDate: $scope.UPLOADED_DATE,
                OtherLink: $scope.OTHER_LINK,
                UploadedFileLink: fileName,
                IsActive: $scope.IsActive
            };


            var apiRoute = baseUrl + 'SaveTrainingContent/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(TrainingContent) + "]";

            SaveUploadAllFile();

            var SaveUpdateTrainingContent = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateTrainingContent.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnShowText = "Create";
                    $scope.PageTitle = 'Add New Training Content';
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;
                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    loadTrainingContents(0);
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

            if (window.File && window.FileList && window.FileReader) {
                $("#fileToUpload").on("change", function (e) {
                    var TrainingContentMaxLength = 10;
                    var files = e.target.files,
                        filesLength = files.length;
                    var name = files[0].name;

                    var fileExtension;   //change

                    fileExtension = name.split('.').pop().toLowerCase();
                    if (fileExtension !== 'pdf' && fileExtension !== 'png' && fileExtension !== 'jpg' && fileExtension !== 'jpeg' && fileExtension !== 'bmp') {
                        Command: toastr["warning"]("file type should be pdf/png/jpg/jpeg/bmp !!");
                        document.getElementById('fileToUpload').value = '';
                        return;
                    }
                    if (files[0].size > TrainingContentMaxLength * 1024 * 1024) {
                        Command: toastr["warning"]("Your file is " + Math.round(files[0].size / (1024 * 1024)) + "MB, Please upload file less than " + TrainingContentMaxLength + "MB!!");
                        //alert("Please upload file less than " + TrainingContentMaxLength+"MB. Thanks!!");
                        document.getElementById('fileToUpload').value = '';
                        return;
                    }


                    $('#hdFileName').val(name);
                    var reader = new FileReader();
                    reader.onload = $scope.imageIsLoaded;
                    reader.readAsDataURL(files[0]);

                    upFile = files[0]

                   

                    //SaveUploadedImgPdf();

                });
            } else {
                alert("Your browser doesn't support to File API")
            }

          
        });
        $scope.imageIsLoaded = function (e) {
            $scope.$apply(function () {
                $scope.UploadedFileLink = e.target.result;
            });
        }
        $scope.delete = function (dataModel) {
            var isDelete = confirm('You are about to delete ' + dataModel.TRAINING_NAME + '. Are you sure?');
            if (isDelete == true) {
                objcmnParam = {
                    pageNumber: page,
                    pageSize: pageSize,
                    IsPaging: isPaging,
                    loggeduser: $scope.loggedUserId
                };
                var TrainingInfo = {
                    TrainingId: dataModel.TRAINING_ID
                };
                var apiRoute = baseUrl + 'DeleteInfo/';

                var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(TrainingInfo) + "]";

                var deleteInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
                deleteInfo.then(function (response) {
                    // debugger;
                    if (response.data != "") {
                        Command: toastr["success"]("Delete  Successfully!!!!");
                        loadTrainingContents(0);
                    }
                    else if (response.data == "") {
                        Command: toastr["warning"]("Delete Not Successfull!!!!");
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });
            }
        }
        $scope.GroupFor = 1;
        $scope.IsActive = 1;
        $scope.UploadedFileLink = DirectoryKey +"/UserFiles/TrainingContent/default_image.png";
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

            $scope.hTrainingContentId = 0;
            $scope.CONTENT_NAME = '';
            $scope.TRAINING_NAME = '';
            $scope.UPLOADED_DATE = '';
            $scope.OTHER_LINK = '';
            $scope.IsActive = 1;
            $scope.UploadedFileLink = DirectoryKey +"/UserFiles/TrainingContent/default_image.png";
            document.getElementById('fileToUpload').value = '';
            $('#save').removeAttr('disabled');
            loadTrainingContents(0);
        };
    }]);

