/**
 * CurrentOfferCtrl.js
 */
app.controller('NewGraphInfoCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/VFocusAPI/api/GraphInfo/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Show List";

        $scope.PageTitle = 'New Graph Inforamation';
        $scope.ListTitle = 'Graph List';
        $scope.IsListIcon = true;
        $scope.gridOptionsNewGraphInfo = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;
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
                // loadCurrentOfferList(0);
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

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/'; //alert(apiRoute);
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

        GetPermission('02112');


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
        //  }


        //**********----Get All Customer Records----***************
        function loadAllNewGraphInfo(isPaging) {
            $scope.gridOptionsNewGraphInfo.enableFiltering = true;
            $scope.gridOptionsNewGraphInfo.enableGridMenu = true;

            // For Loading
            if (isPaging == 0)
                $scope.pagination.pageNumber = 1;

            //For Loading
            $scope.loaderMoreNewGraphInfo = true;
            $scope.lblMessageForNewGraphInfo = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsNewGraphInfo = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "GRAPH_CODE", displayName: "Code", title: "Code", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "GRAPH_NAME", displayName: "Name", title: "Name", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DETAIL", displayName: "Details", title: "Details", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Action',
                        displayName: "Action",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '15%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<div style="padding-left: 10px"><span class="label label-info label-mini" style="text-align:center !important;">' +
                            '<a href="" title="Edit" ng-click="grid.appScope.getNewGraphInfo(row.entity)">' +
                            '<i class="icon-edit" aria-hidden="true"></i> Edit' +
                            '</a>' +
                            '</span>' +

                            '<span class="label label-warning label-mini" style="text-align:center !important;">' +
                            '<a href="" title="Delete" ng-click="grid.appScope.delete(row.entity)">' +
                            '<i class="icon-trash" aria-hidden="true"></i> Delete' +
                            '</a>' +
                            '</span></div>'
                    }
                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: true,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'Graph.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Graph", style: 'headerStyle' },
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
                //loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetAllGraphInfo/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listCurrentOfferInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listCurrentOfferInfo.then(function (response) {
                $scope.pagination.totalItems = response.data.recordsTotal;
                $scope.gridOptionsNewGraphInfo.data = response.data.graphInfoList;
                $scope.loaderMoreNewGraphInfo = false;
                $scope.currentOfferList = response.data.graphInfoList;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };

        loadAllNewGraphInfo(0);


        //**********----Get Single Record----***************
        $scope.getNewGraphInfo = function (dataModel) {
            $scope.IsShow = true;
            $scope.IsHiddenDetail = false;
            $scope.btnShowText = "Show List";
            $scope.IsHidden = true;
            $scope.btnSaveText = "Update";
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;


            $scope.hGraphId = dataModel.GRAPH_ID;
            $scope.GraphCode = dataModel.GRAPH_CODE;
            $scope.GraphName = dataModel.GRAPH_NAME;
            $scope.Detail = dataModel.DETAIL;
        };


        //**********----Create New Record----***************

        $scope.save = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '02110'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveNewSurvey();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });

        };

        $scope.SaveNewSurvey = function () {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                CreatedBy: $scope.loggedUserId,
            };

            var GraphInfo = {
                GraphId: $scope.hGraphId == undefined || $scope.hGraphId == null ? 0 : $scope.hGraphId,
                GraphCode: $scope.GraphCode,
                GraphName: $scope.GraphName,
                Detail: $scope.Detail,
                CreatedBy: $scope.loggedUserId,
                 StrMode: 'U'
            };

            // var HedarTokenPostPut = $scope.CustomerID > 0 ? $scope.HeaderToken.put : $scope.HeaderToken.post;
            var apiRoute = baseUrl + 'SaveGraphInfo/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(GraphInfo) + "]";

            var SaveUpdateGraphInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateGraphInfo.then(function (response) {
                // debugger;
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                }
                else if (response.data == "") {
                    Command: toastr["warning"]("Save Not Successfull!!!!");
                    $("#save").prop("disabled", false);
                }

            },
                function (error) {
                    console.log("Error: " + error);
                });
        }


        //**********----Delete Single Record----***************
        $scope.delete = function (dataModel) {
            var isDelete = confirm('You are about to delete ' + dataModel.GraphCode + '. Are you sure?');
            if (isDelete == true) {
                objcmnParam = {
                    pageNumber: page,
                    pageSize: pageSize,
                    IsPaging: isPaging,
                    CreatedBy: $scope.loggedUserId,
                };

                var GraphInfo = {
                    GraphId: dataModel.GRAPH_ID,
                    GraphCode: dataModel.GRAPH_CODE,
                    GraphName: dataModel.GRAPH_NAME,
                    Detail: dataModel.DETAIL,
                    StrMode : 'D'
                };

                // var HedarTokenPostPut = $scope.CustomerID > 0 ? $scope.HeaderToken.put : $scope.HeaderToken.post;
                var apiRoute = baseUrl + 'SaveGraphInfo/';
                var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(GraphInfo) + "]";

                var SaveUpdateGraphInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
                SaveUpdateGraphInfo.then(function (response) {
                    // debugger;
                    if (response.data != "") {
                        Command: toastr["success"]("Deleted  Successfully!!!!");
                        $scope.clear();
                    }
                    else if (response.data == "") {
                        Command: toastr["warning"]("Save Not Successfull!!!!");
                        $("#save").prop("disabled", false);
                    }

                },
                    function (error) {
                        console.log("Error: " + error);
                    });
            }
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

            $scope.hSurveyId = 0;
            $scope.GraphCode = '';
            $scope.GraphName = '';
            $scope.Detail = '';

            loadAllNewGraphInfo(0);
        };
    }]);

