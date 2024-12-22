/*
  DocumentUploadCtrl.js
 */
app.controller('DocumentUploadCtrl', ['$scope', 'crudService', 'conversion', '$http', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $http, $filter, $localStorage, uiGridConstants) {
        var baseUrl = '/SystemCommon/api/DocumentUpload/';
        $scope.permissionPageVisibility = true;
        $scope.UserCommonEntity = {};
        $scope.HeaderToken = {};
        objcmnParam = {};
        $scope.gridOptions = [];
        var page = 1;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;
        $scope.loadLoadingProcessArticleNo = false;
        $scope.LoadingMessage = 'Loading...';
        $scope.PageTitle = 'Document Upload';
        $scope.ListTitleDetail = 'Parent Number List';
        $scope.ListTitle = 'Document List';
        $scope.IsHidden = true;
        $scope.IsShow = false;
        //$scope.IsBrows = true;
        $scope.FileId = null;
        $scope.FileName = '';
        $scope.FileSize = '';
        $scope.FileType = '';
        $scope.ParentTypeID = null;
        $scope.DocumentTypeID = null;
        $scope.DocumentPahtID = null;
        $scope.PrevDocumentTypeID = null;
        $scope.PrevFilePath = '';
        $scope.PrevVirtualPath = '';
        $scope.DocumentRows = [];
        $scope.ListSelectedDocuments = [];
        $scope.ListDDLDocuments = [];
        $scope.DocumentLists = [];
        $scope.ListParentDocuments = [];
        $scope.DocumentPaths = "";
        $scope.DelParentDocuments = [];
        files = [];
        //***************************************************End Vairiable Initialize***************************************************
        //$scope.CmnMethod = function (FuncEntity, CmnNum) { $scope.CmnEntity = {}; $scope.CmnEntity = conversion.ExecuteCmnFunc(FuncEntity, CmnNum); if (CmnNum != 0 && CmnNum != 2) { $scope[$scope.CmnEntity.MethodName]($scope.CmnEntity.rowEntity); } if (CmnNum == 2) { for (var i = 0; i < $scope.CmnEntity.MethodName.length; i++) { $scope[$scope.CmnEntity.MethodName[i]]($scope.CmnEntity.rowEntity); } } if (CmnNum == 3) { $scope.cmnbtnShowHideEnDisable(num = (toast = $('.toast-warning').attr("style")) == undefined ? $scope.CmnEntity.num : 7); } }
        //***************************************************Start Common Task for all**************************************************
        frmName = 'frmDocumentUpload'; DelFunc = 'DeleteDocumentListData'; DelMsg = 'DocName'; EditFunc = 'getDocumentListByID';
        $scope.UserCommonEntity = conversion.UserCmnEntity($scope.menuManager.LoadPageMenu(window.location.pathname), frmName, DelFunc, DelMsg, EditFunc);
        $scope.HeaderToken = conversion.Tokens($scope.tokenManager); $scope.DelParam = {};
        $scope.cmnParam = function () { objcmnParam = conversion.cmnParams(); }
        $scope.CmnMethod = function (FuncEntity, CmnNum) { $scope.CmnEntity = {}; $scope.CmnEntity = conversion.ExecuteCmnFunc(FuncEntity, CmnNum); if (CmnNum != 0 && CmnNum != 2 && CmnNum != 6) { $scope[$scope.CmnEntity.MethodName]($scope.CmnEntity.rowEntity); } if (CmnNum == 2) { for (var i = 0; i < $scope.CmnEntity.MethodName.length; i++) { $scope[$scope.CmnEntity.MethodName[i]]($scope.CmnEntity.rowEntity); } } if (CmnNum == 3) { conversion.SaveUpdatBehave($scope.CmnEntity.num); } }
        $scope.cmnbtnShowHideEnDisable = function (num) { $scope.UserCommonEntity = conversion.btnBehave(num, $scope.UserCommonEntity.IsbtnSaveDisable); }
        $scope.cmnbtnShowHideEnDisable(0);//0=default/reset, 1=Create, 2=Update, 3=Unchange on Update mode btn text, 4=only disable save button, 5=only enable save button
        //****************************************************End Common Task for all*************************************************** 

        $scope.loadddlDocumentType = function (dataModel) {
            $scope.cmnParam();
            ModelsArray = [objcmnParam];
            var apiRoute = baseUrl + 'GeDocumentTypeList/';
            var listddlType = crudService.postMultipleModel(apiRoute, ModelsArray, $scope.HeaderToken.get);
            listddlType.then(function (response) {
                $scope.ddlDocumentType = response.data.DocumentTypeList;
                $scope.ddlParentType = response.data.DocumentTypeList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.loadddlDocumentType(0);

        $scope.getDocumentTypeBaseData = function () {
            $scope.cmnParam();
            objcmnParam.id = $scope.DocumentTypeID;
            ModelsArray = [objcmnParam];
            var apiRoute = baseUrl + 'GetDocumentTypeBaseData/';
            var _DocData = crudService.postMultipleModel(apiRoute, ModelsArray, $scope.HeaderToken.get);
            _DocData.then(function (response) {
                //$scope.IsBrows = true;
                $scope.DocumentPahtID = null;
                if (response.data._objDocData != null) {
                    $scope.DocumentPahtID = response.data._objDocData.DocumentPahtID;
                    $scope.DocumentTypeName = response.data._objDocData.DocumentTypeName;
                    $scope.FilePath = response.data._objDocData.FilePath;
                    $scope.VirtualPath = response.data._objDocData.VirtualPath;
                    //$scope.IsBrows = false;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.loadParentDocuments = function (ParentId) {
            $scope.ListParentDocuments = [];
            $scope.cmnParam();
            objcmnParam.id = ParentId;
            ModelsArray = [objcmnParam];
            var apiRoute = baseUrl + 'GetParentDocList/';
            var ListPDocument = crudService.postMultipleModel(apiRoute, ModelsArray, $scope.HeaderToken.get);
            ListPDocument.then(function (response) {
                $scope.ListParentDocuments = [];
                if (response.data.PDocList.length > 0) {
                    $scope.ListParentDocuments = response.data.PDocList;
                }
                $scope.IsShow = $scope.ListParentDocuments.length > 0 ? true : false;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.loadDocuments = function () {
            $scope.ListSelectedDocuments = [];
            $scope.ListDDLDocuments = [];
            $scope.cmnParam();
            objcmnParam.id = $scope.ParentTypeID;
            ModelsArray = [objcmnParam];
            var apiRoute = baseUrl + 'GetDocList/';
            var ListDDDocument = crudService.postMultipleModel(apiRoute, ModelsArray, $scope.HeaderToken.get);
            ListDDDocument.then(function (response) {
                $scope.ListSelectedDocuments = [];
                $scope.ListDDLDocuments = [];
                if (response.data.DocList.length > 0) {
                    $scope.ListDDLDocuments = response.data.DocList;
                    //if ($scope.FileId != null && $scope.FileId > 0) {
                    //    angular.forEach($scope.ListParentDocuments, function (LPD) {
                    //        angular.forEach($scope.ListDDLDocuments, function (lis) {
                    //            if (LPD.id == lis.id && LPD.FileId == $scope.FileId) {
                    //                $scope.ListSelectedDocuments.push({ id: lis.id, label: lis.label, ModelState: LPD.ModelState });
                    //                lis.ModelState = LPD.ModelState;
                    //            }
                    //        })
                    //    })
                    //}
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.ManageDocumentList = function () {
            if ($scope.ListSelectedDocuments.length > 0) {
                angular.forEach($scope.ListSelectedDocuments, function (LD) {
                    var IsMatch = 0;
                    angular.forEach($scope.ListDDLDocuments, function (LSD) {
                        if (LSD.id == LD.id) {
                            if ($scope.ListParentDocuments.length > 0) {
                                angular.forEach($scope.ListParentDocuments, function (PD) {
                                    if (LD.id == PD.FileId) {
                                        IsMatch = 1;
                                    }
                                })
                            }
                            if (IsMatch == 0) {
                                $scope.ListParentDocuments.push({
                                    FileName: LSD.FileName, FileSize: LSD.FileSize, FileType: LSD.FileType, FilePath: LSD.FilePath, DocName: LSD.DocName, VirtualPath: LSD.VirtualPath, ViewPath: LSD.ViewPath,
                                    FileId: LSD.FileId, DocumentTypeName: LSD.DocumentTypeName, DocumentPahtID: LSD.DocumentPahtID, DocumentTypeID: LSD.DocumentTypeID, Remarks: LSD.Remarks, ModelState: LSD.ModelState
                                });
                            }
                        }
                    })
                })

                $scope.IsShow = $scope.ListParentDocuments.length > 0 ? true : false;
                $scope.ListSelectedDocuments = [];
                $scope.ListDDLDocuments = [];
                $("#ddlPType").select2("data", { id: 0, text: '-- Select Parent Type --' });
            }
        }


        var checkName = '';
        $scope.CheckDocNameIfExist = function (CheckName) {
            checkName = '';
            checkName = CheckName == undefined || CheckName == '' ? '' : CheckName.replace(/[' ']/g, '');
            if (checkName != '') {
                $scope.cmnParam();
                objcmnParam.ParamName = checkName;
                objcmnParam.id = $scope.FileId == 0 || $scope.FileId == undefined || $scope.FileId == null || $scope.FileId == "" ? 0 : $scope.FileId;
                ModelsArray = [objcmnParam];
                var apiRoute = baseUrl + 'DuplicateCheckDocName/';
                var CheckDocNo = crudService.postMultipleModel(apiRoute, ModelsArray, $scope.HeaderToken.get);
                CheckDocNo.then(function (response) {
                    if (response.data.result == 1) {
                        Command: toastr["warning"]("Ref. Document No: " + checkName + " already exists. !!!!");
                        $scope.DocName = '';
                    }
                },
                function (error) {
                    console.log("Error: " + error);
                });
            }
        }

        $scope.deleteRow = function (del, index) {
            if ($scope.FileId > 0) {
                $scope.DelParentDocuments.push({
                    FileName: del.FileName, FileSize: del.FileSize, FileType: del.FileType, FilePath: del.FilePath, DocName: del.DocName, VirtualPath: del.VirtualPath, FileId: del.FileId,
                    DocumentTypeName: del.DocumentTypeName, DocumentPahtID: del.DocumentPahtID, DocumentTypeID: del.DocumentTypeID, Remarks: del.Remarks, ModelState: 'Deleted'
                });
            }

            $scope.ListParentDocuments.splice(index, 1);
            $scope.IsShow = $scope.ListParentDocuments.length > 0 ? true : false;
        };
        //**************************************************End Grade Dropdown******************************************************

        //Pagination
        $scope.pagination = {
            paginationPageSizes: [15, 25, 50, 75, 100, 500, 1000, "All"],
            ddlpageSize: 15,
            pageNumber: 1,
            pageSize: 15,
            totalItems: 0,

            getTotalPages: function () {
                return Math.ceil(this.totalItems / this.pageSize);
            },
            pageSizeChange: function () {
                if (this.ddlpageSize == "All")
                    this.pageSize = $scope.pagination.totalItems;
                else
                    this.pageSize = this.ddlpageSize

                this.pageNumber = 1
                $scope.LoadDocumentMasterList(1);
            },
            firstPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber = 1
                    $scope.LoadDocumentMasterList(1);
                }
            },
            nextPage: function () {
                if (this.pageNumber < this.getTotalPages()) {
                    this.pageNumber++;
                    $scope.LoadDocumentMasterList(1);
                }
            },
            previousPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber--;
                    $scope.LoadDocumentMasterList(1);
                }
            },
            lastPage: function () {
                if (this.pageNumber >= 1) {
                    this.pageNumber = this.getTotalPages();
                    $scope.LoadDocumentMasterList(1);
                }
            }
        };

        $scope.LoadDocumentMasterList = function (isPaging) {
            $scope.loaderMore = true;
            $scope.lblMessage = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.cmnParam();
            objcmnParam.pageNumber = ($scope.pagination.pageNumber - 1) * $scope.pagination.pageSize;
            objcmnParam.pageSize = $scope.pagination.pageSize;
            objcmnParam.IsPaging = isPaging;

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };
            $scope.gridOptions = {
                rowTemplate: $scope.UserCommonEntity.rowTemplate,
                columnDefs: [
                    { name: "FileId", visible: false, headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DocumentPahtID", visible: false, headerCellClass: $scope.highlightFilteredHeader },
                    { name: "FilePath", visible: false, headerCellClass: $scope.highlightFilteredHeader },
                    { name: "VirtualPath", visible: false, headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ViewPath", visible: false, headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DocumentTypeID", visible: false, headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DocName", displayName: "Document No", width: '14%', headerCellClass: $scope.highlightFilteredHeader },
                    //{ name: "FileSize", displayName: "Size", headerCellClass: $scope.highlightFilteredHeader },
                    //{ name: "FileType", displayName: "Type", headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DocumentTypeName", displayName: "Document Type", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ParentDocumentNames", displayName: "Reference Documents", width: '25%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "Remarks", displayName: "Remarks", width: '20%', headerCellClass: $scope.highlightFilteredHeader },

                    { name: "FileName", displayName: "Document Name", width: '18%', headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Options',
                        displayName: "Options",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '17%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        visible: $scope.UserCommonEntity.visible,
                        cellTemplate: '<span class="label label-info label-mini">' +
                                        '<a href="javascript:void(0);" target="_blank" ng-click="grid.appScope.OpenFile(row.entity)" title="Open in a new Tab">' +
                                        '<i class="glyphicon glyphicon-file" aria-hidden="true">&nbsp;File</i> </a> </span>' +
                            $scope.UserCommonEntity.cellTemplate
                    }
                ],

                enableFiltering: true,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'DocumentInfo.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Document", style: 'headerStyle' },
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

            ModelsArray = [objcmnParam];
            var apiRoute = baseUrl + 'DocumentMasterList/';
            var _finishGoods = crudService.postMultipleModel(apiRoute, ModelsArray, $scope.HeaderToken.get);
            _finishGoods.then(function (response) {
                $scope.pagination.totalItems = response.data.recordsTotal;
                $scope.gridOptions.data = response.data.MasterData;
                $scope.loaderMore = false;
                //$scope.finishGoods = response.data;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.RefreshMasterList = function () {
            $scope.pagination.pageNumber = 1;
            $scope.LoadDocumentMasterList(0);
        }
        $scope.RefreshMasterList();

        $scope.OpenFile = function (datafile) {
            debugger
            //window.open(datafile.ViewPath);
            var myWindow = window.open();
            myWindow.document.write('<html><head><title>' + datafile.FileName + '</title></head><body height="100%" width="100%"><iframe src="' + datafile.ViewPath + '" height="100%" width="100%"></iframe></body></html>');
        }

        $scope.getDocumentListByID = function (dataModel) {
            //$('#frmDetail').hide();
            $scope.IsHidden = true;
            $scope.DocName = dataModel.DocName;
            $scope.Remarks = dataModel.Remarks;
            $scope.DocumentTypeID = dataModel.DocumentTypeID;
            $scope.DocumentPahtID = dataModel.DocumentPahtID;
            $scope.DocumentTypeName = dataModel.DocumentTypeName;
            $scope.FilePath = dataModel.FilePath;
            $scope.VirtualPath = dataModel.VirtualPath;
            $scope.FileId = dataModel.FileId;
            $scope.FileName = dataModel.FileName;
            $scope.FileSize = dataModel.FileSize;
            $scope.FileType = dataModel.FileType;
            $("#ddlType").select2("data", { id: $scope.DocumentTypeID, text: $scope.DocumentTypeName });

            $scope.PrevDocumentTypeID = dataModel.DocumentTypeID;
            $scope.PrevFilePath = dataModel.FilePath;
            $scope.PrevVirtualPath = dataModel.VirtualPath;
            $scope.loadParentDocuments($scope.FileId);
            //$scope.IsBrows = false;
        }

        //var ConfMessage = ''; var files = [];
        //$scope.CaughtDocumentRows = [];
        //$scope.AddDocumentFile = function () {
        //    debugger
        //    files = document.getElementById('file').files;
        //    if (files.length > 0) {
        //        $scope.DocumentPaths = [];
        //        ConfMessage = 'You are about to upload ' + files.length + ' files. Are you sure?';
        //        $scope.modal_ConfShow(ConfMessage);
        //        $scope.IsConfirm = function () {
        //            angular.forEach(files, function (file, index) {
        //                $scope.CaughtDocumentRows.push(files[index]);
        //                $scope.DocumentRows.push({
        //                    FileName: file.name, FileSize: file.size, FileType: file.type, FilePath: $scope.FilePath, DocName: $scope.DocName, VirtualPath: $scope.VirtualPath, FileId: null,
        //                    DocumentTypeName: $scope.DocumentTypeName, DocumentPahtID: $scope.DocumentPahtID, DocumentTypeID: $scope.DocumentTypeID, Remarks: $scope.Remarks, ModelState: 'Inserted'
        //                });
        //            });

        //            $scope.SaveUploadDocumentFile();
        //            $('#file').val('');
        //            $scope.IsUploadDisable = false;
        //            $scope.IsShow = $scope.DocumentRows.length > 0 ? true : false;
        //            if ($scope.DocumentRows.length > 0) { $scope.cmnbtnShowHideEnDisable('false'); } else { $scope.cmnbtnShowHideEnDisable('true'); }
        //        }
        //    }
        //    else {
        //        Command: toastr["warning"]("No file chosen");
        //    }
        //};
        //$scope.IsUploadDisable = true; $scope.upCount = -1; var isSave = 0;
        //$scope.SaveUploadDocumentFile = function () {
        //    var formData = new FormData();
        //    $scope.DocumentPaths = [];
        //    var sl = 0;
        //    angular.forEach($scope.CaughtDocumentRows, function (file, index) {
        //        if (index > $scope.upCount) {
        //            formData.append("uploadedFile", $scope.CaughtDocumentRows[index]);
        //            $scope.DocumentRows[index].FileId = sl = sl + 1;
        //            $scope.DocumentPaths.push({ FilePath: $scope.DocumentRows[index].FilePath, VirtualPath: $scope.DocumentRows[index].VirtualPath });

        //        }
        //    });

        //    $scope.SetPathList();

        //    $http.post(baseUrl + "UploadDocuments/", formData,
        //    {
        //        withCredentials: true,
        //        headers: { 'Content-Type': undefined },
        //        transformRequest: angular.identity
        //    })
        //    .success(function (response) {
        //        if (response.ListDocuments.length > 0) {
        //            $('#file').val('');
        //            angular.forEach(response.ListDocuments, function (file, index) {
        //                angular.forEach($scope.DocumentRows, function (doc) {
        //                    if (file.FileId == doc.FileId && file.FileSize == doc.FileSize && doc.ModelState == 'Inserted') {
        //                        doc.FilePath = file.FilePath;
        //                        doc.VirtualPath = file.VirtualPath;
        //                        doc.FileName = file.FileName;
        //                        doc.FileId = index + 1;
        //                    }
        //                })
        //            });
        //            Command: toastr["success"]($scope.CaughtDocumentRows.length + " file(s) are uploaded");
        //            $('#modalDocument').modal('hide');
        //            $scope.IsUploadDisable = true;
        //            $scope.upCount = $scope.DocumentRows.length - 1;
        //        }
        //        else {
        //            Command: toastr["warning"]("Uploaded" + $scope.CaughtDocumentRows.length + " file(s) are caught in error");
        //            $scope.IsUploadDisable = false;
        //        }
        //    })
        //    .error(function () {

        //    });
        //};

        $scope.SetPathList = function () {
            var apiRoute = baseUrl + 'getPathList/';
            var PathList = crudService.getModelAjax(apiRoute, $scope.DocumentPaths, $scope.HeaderToken.get);
            PathList.then(function (response) {
                var result = 0;
                if (response.PathContainer != "0") {
                    result = 1
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.uploadDocumentFile = function (files) {
            var formData = new FormData();
            $scope.DocumentPaths = "";
            angular.forEach(files, function (file, index) {
                formData.append("uploadedFile", files[index]);
                $scope.DocumentPaths = { FilePath: $scope.FilePath, VirtualPath: $scope.VirtualPath };
            });

            $scope.SetPathList();

            $http.post(baseUrl + "UploadDocuments/", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
            .success(function (response) {
                if ($scope.UserCommonEntity.message == "Updated") {
                    $scope.FileName = response.ListDocuments[0].FileName;
                    $scope.FileSize = response.ListDocuments[0].FileSize;
                    $scope.FileType = response.ListDocuments[0].FileType;
                }
                else {
                    $scope.FileId = 0;
                    $scope.FileName = response.ListDocuments[0].FileName;
                    $scope.FileSize = response.ListDocuments[0].FileSize;
                    $scope.FileType = response.ListDocuments[0].FileType;
                    $scope.FilePath = response.ListDocuments[0].FilePath;
                    $scope.VirtualPath = response.ListDocuments[0].VirtualPath;
                }
                $scope.onUpdateDocument();
            })
            .error(function () {

            });
        };

        //$scope.tblDeleteDocFile = [];
        //$scope.deleteDocumentFile = function (element, index) {
        //    debugger
        //    ConfMessage = 'You are about to delete ' + element.FileName + '. Are you sure?';
        //    $scope.modal_ConfShow(ConfMessage);
        //    $scope.IsConfirm = function () {
        //        //$scope.lblMessage = 'loading please wait....!';
        //        //$scope.result = "color-red";
        //        if (element.FileId != null) {
        //            var fileDetails = { FilePath: element.FilePath }
        //            var apiRoute = baseUrl + "DeleteDocuments/";
        //            var fileDelete = crudService.post(apiRoute, fileDetails);
        //            fileDelete.then(function (response) {
        //                if (response.data.result === 1) {
        //                    $scope.DocumentRows.splice(index, 1);
        //                    $scope.CaughtDocumentRows.splice(index, 1);
        //                    $scope.upCount = $scope.DocumentRows.length - 1;
        //                }
        //                else if (response.data.result === -1) {
        //                        Command: toastr["warning"]("Error to delete " + element.FileName + " !!");
        //                }
        //                else {
        //                    Command: toastr["warning"]("Unable to delete " + element.FileName + ", Please try again!!");
        //                }
        //                $scope.IsShow = $scope.DocumentRows.length > 0 ? true : false;
        //                if ($scope.DocumentRows.length > 0) { $scope.cmnbtnShowHideEnDisable('false'); } else { $scope.cmnbtnShowHideEnDisable('true'); }

        //                //$scope.loaderMore = false;
        //            },
        //            function (error) {
        //                console.log("Error: " + error);
        //            });
        //        }
        //        else {
        //            $scope.DocumentRows.splice(index, 1);
        //            $scope.CaughtDocumentRows.splice(index, 1);
        //        }
        //    }
        //};

        //$scope.deleteDocumentFileOnReset = function () {
        //    angular.forEach($scope.DocumentRows, function (docFile) {
        //        $scope.deleteDocumentFileFunc(docFile);
        //    })
        //}

        $scope.deleteDocumentFileFunc = function (docFile) {
            debugger
            var fileDetails = { FilePath: docFile.FilePath }
            if (fileDetails.FilePath != '') {
                var apiRoute = baseUrl + "DeleteDocuments/";
                var fileDeletes = crudService.post(apiRoute, fileDetails);
                fileDeletes.then(function (response) {
                },
                function (error) {
                    console.log("Error: " + error);
                });
            }
        };

        $scope.MoveDocumentFileFunc = function (docFile) {
            debugger
            var fileDetails = { FilePath: docFile.FilePath, PrevFilePath: docFile.PrevFilePath, FileName: docFile.FileName }
            var apiRoute = baseUrl + "MoveDocuments/";
            var fileDeletes = crudService.post(apiRoute, fileDetails);
            fileDeletes.then(function (response) {
                if (response.data.result != "") {
                    $scope.FileName = response.data.result;
                    $scope.onUpdateDocument();
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.ShowHide = function () {
            $scope.IsHidden = $scope.IsHidden ? false : true;
            if ($scope.IsHidden == true) {
                $scope.clear();
            }
            else {
                $scope.RefreshMasterList();
                $scope.IsShow = false;
            }
        };

        //$scope.ManageDocumentList = function () {
        //    $scope.DocumentLists = [];
        //    if ($scope.ListSelectedDocuments.length == 0) {
        //        debugger
        //        $scope.ListSelectedDocuments.push({ ModelState: 'NotFound' });
        //        $scope.DocumentLists = $scope.ListSelectedDocuments;
        //    }
        //    else {
        //        angular.forEach($scope.ListSelectedDocuments, function (tes) {
        //            if (tes.ModelState == 'NotFound') { $scope.ListSelectedDocuments.splice($scope.ListSelectedDocuments.indexOf(tes), 1); }
        //        })

        //        if ($scope.FileId > 0) {
        //            angular.forEach($scope.ListDDLDocuments, function (LSD) {
        //                var IsDel = 0, IsIns = 0;
        //                angular.forEach($scope.ListSelectedDocuments, function (LD) {
        //                    if (LSD.id == LD.id && LSD.ModelState == "Updated") {
        //                        IsDel = 1;
        //                    }
        //                    if (LSD.id == LD.id && LSD.ModelState == "Default") {
        //                        IsIns = 1;
        //                    }
        //                })
        //                if (IsDel != 1 && LSD.ModelState == "Updated") {
        //                    LSD.ModelState = "Deleted";
        //                }

        //                if (IsIns == 1 && LSD.ModelState == "Default") {
        //                    LSD.ModelState = "Inserted";
        //                }
        //            })

        //            $scope.DocumentLists = $scope.ListDDLDocuments;
        //        }
        //        else {
        //            $scope.DocumentLists = $scope.ListSelectedDocuments;
        //        }
        //    }
        //}

        $scope.RearrangeDocumentList = function () {
            if ($scope.ListParentDocuments.length > 0) {
                angular.forEach($scope.ListParentDocuments, function (tes) {
                    if (tes.ModelState == 'NotFound') { $scope.ListParentDocuments.splice($scope.ListParentDocuments.indexOf(tes), 1); }
                })

                $scope.DocumentLists = $scope.ListParentDocuments;
                if ($scope.DelParentDocuments.length > 0) {
                    angular.forEach($scope.DelParentDocuments, function (del) {
                        $scope.DocumentLists.push({
                            FileName: del.FileName, FileSize: del.FileSize, FileType: del.FileType, FilePath: del.FilePath, DocName: del.DocName, VirtualPath: del.VirtualPath, FileId: del.FileId,
                            DocumentTypeName: del.DocumentTypeName, DocumentPahtID: del.DocumentPahtID, DocumentTypeID: del.DocumentTypeID, Remarks: del.Remarks, ModelState: del.ModelState
                        });
                    })
                }
            }
            else {

                $scope.ListParentDocuments.push({ ModelState: 'NotFound' });
                $scope.DocumentLists = $scope.ListParentDocuments;
            }

        }

        $scope.Save = function () {
            $scope.cmnParam();
            if ($scope.ListSelectedDocuments.length > 0) {
                Command: toastr["warning"]("You have " + $scope.ListSelectedDocuments.length + " item(s) to add!!!");
                return;
            }

            $scope.RearrangeDocumentList();
            files = document.getElementById('file').files;
            if ($scope.UserCommonEntity.message == "Updated") {
                if ($scope.DocumentTypeID != $scope.PrevDocumentTypeID && $scope.FilePath != $scope.PrevFilePath && files.length == 0) {
                    $scope.MoveDocumentFileFunc(fileDetails = { FilePath: $scope.FilePath, PrevFilePath: $scope.PrevFilePath, FileName: $scope.FileName });
                }
                if (files.length > 0) {
                    $scope.uploadDocumentFile(files);
                    $scope.deleteDocumentFileFunc(fileDetails = { FilePath: $scope.PrevFilePath });
                }

                if ($scope.DocumentTypeID == $scope.PrevDocumentTypeID && files.length == 0) {
                    $scope.onUpdateDocument();
                }
            }
            else {
                if (files.length > 0) {
                    $scope.uploadDocumentFile(files);
                }
                else {
                    Command: toastr["warning"]("No file chosen");
                }

                //var master = {
                //    FileId: 0
                //}

                //if ($scope.DocumentRows.length == 0) {
                //    debugger
                //    $scope.DocumentRows.push({ ModelState: 'NotFound' });
                //}
                //else {
                //    angular.forEach($scope.DocumentRows, function (tes) {
                //        if (tes.ModelState == 'NotFound') { $scope.DocumentRows.splice($scope.DocumentRows.indexOf(tes), 1); }
                //    })
                //}

                //var HeaderTokenPutPost = $scope.UserCommonEntity.message == "Saved" ? $scope.HeaderToken.post : $scope.HeaderToken.put;
                //ModelsArray = [master, $scope.DocumentRows, $scope.DocumentLists, objcmnParam]; //$scope.tblDeleteDocFile,
                //var apiRoute = baseUrl + 'SaveUpdateDocumentList/';
                //var SaveMasterDetail = crudService.postMultipleModel(apiRoute, ModelsArray, HeaderTokenPutPost);
                //SaveMasterDetail.then(function (response) {
                //    if (response == '1') {
                //        ShowCustomToastrMessageSaveUpdate(1, $scope.UserCommonEntity);
                //        isSave = 1;
                //        $scope.clear();
                //    }
                //    else {
                //        ShowCustomToastrMessageSaveUpdate(0, $scope.UserCommonEntity);
                //    }
                //},

                //function (error) {
                //    ShowCustomToastrMessageSaveUpdate(0, $scope.UserCommonEntity);
                //    console.log("Error: " + error);
                //});
            }
        }

        $scope.onUpdateDocument = function () {
            var master = {
                DocName: $scope.DocName.replace(/[' ']/g, ''),

                Remarks: $scope.Remarks,
                DocumentTypeID: $scope.DocumentTypeID,
                DocumentPahtID: $scope.DocumentPahtID,
                DocumentTypeName: $scope.DocumentTypeName,
                FilePath: $scope.FilePath,
                VirtualPath: $scope.VirtualPath,
                FileId: $scope.FileId,
                FileName: $scope.FileName,
                FileSize: $scope.FileSize,
                FileType: $scope.FileType
            }

            ModelsArray = [master, $scope.DocumentLists, objcmnParam];
            var apiRoute = baseUrl + 'SaveUpdateDocumentList/';
            var SaveMasterDetail = crudService.postMultipleModel(apiRoute, ModelsArray, $scope.HeaderToken.put);
            SaveMasterDetail.then(function (response) {
                if (response == '1') {
                    ShowCustomToastrMessageSaveUpdate(1, $scope.UserCommonEntity);
                    //isSave = 1;
                    $scope.clear();
                }
                else {
                    ShowCustomToastrMessageSaveUpdate(0, $scope.UserCommonEntity);
                }
            },
            function (error) {
                ShowCustomToastrMessageSaveUpdate(0, $scope.UserCommonEntity);
                console.log("Error: " + error);
            });


        }

        //*********************************************************Start Save/Update/Delete**********************************************************
        $scope.DeleteDocumentListData = function (delModel) {
            $scope.cmnParam();
            objcmnParam.id = delModel.FileId;
            ModelsArray = [objcmnParam];
            var apiRoute = baseUrl + 'DeleteDocumentList/';
            var DelDoc = crudService.postMultipleModel(apiRoute, ModelsArray, $scope.HeaderToken.delete);
            DelDoc.then(function (response) {
                if (response.data.result != '') {
                    $scope.RefreshMasterList();
                    $scope.deleteDocumentFileFunc(delModel);
                    Command: toastr["success"](delModel.FileName + " has been Deleted Successfully!!!!");
                }
                else {
                    Command: toastr["warning"](delModel.FileName + " Not Deleted, Please Check and Try Again!");
                }
            }, function (error) {
                Command: toastr["warning"](delModel.FileName + " Not Deleted, Please Check and Try Again!");
                console.log("Error: " + error);
            });
        };
        //*********************************************************End Save/Update/Delete**********************************************************

        //$scope.modal_ConfShow = function (confdata) {
        //    $scope.UserCommonEntity.EnableYes = false;
        //    $scope.UserCommonEntity.ValidateSave = false;
        //    $scope.UserCommonEntity.EnableConf = true;
        //    $scope.UserCommonEntity.DelMsgs = confdata;
        //    $('#CmnDeleteModal').modal({ show: true, backdrop: "static", keyboard: "false" });
        //}

        $scope.ClearDocumentFile = function () {
            $scope.ListSelectedDocuments = [];
            $scope.ListDDLDocuments = [];
            $scope.DocumentLists = [];
            $scope.DelParentDocuments = [];
            $scope.ListParentDocuments = [];
            $scope.IsShow = $scope.ListParentDocuments.length > 0 ? true : false;
        }

        $scope.clear = function () {
            $scope.frmDocumentUpload.$setPristine();
            $scope.frmDocumentUpload.$setUntouched();

            $scope.DocName = '';
            $scope.Remarks = null;
            $scope.DocumentTypeID = null;
            $scope.DocumentPahtID = null;
            $scope.ParentTypeID = null;
            $scope.DocumentTypeName = '';
            $scope.FilePath = '';
            $scope.VirtualPath = '';
            $scope.FileId = 0;
            $scope.FileName = '';
            $scope.FileSize = '';
            $scope.FileType = '';
            $scope.PrevDocumentTypeID = null;
            $scope.PrevFilePath = '';
            $scope.PrevVirtualPath = '';
            $scope.ListSelectedDocuments = [];
            $scope.ListDDLDocuments = [];
            $scope.DocumentLists = [];
            $scope.ListParentDocuments = [];
            $scope.DocumentPaths = "";
            $scope.DelParentDocuments = [];
            //$scope.IsBrows = true;
            $("#ddlType").select2("data", { id: 0, text: '-- Select Document Type --' });
            $("#ddlPType").select2("data", { id: 0, text: '-- Select Parent Type --' });
            $scope.gridOptions.data = [];
            $scope.IsShow = false;
            $scope.IsHidden = true;
            //$scope.upCount = -1;
            files = [];
            //if (isSave == 0) {
            //    $scope.deleteDocumentFileOnReset();
            //}
            //$scope.DocumentRows = [];
            //$scope.CaughtDocumentRows = [];
            ////$scope.tblDeleteDocFile = [];
            //isSave = 0;
            //$('#frmDetail').show();
            $('#file').val('');
        }
    }]);