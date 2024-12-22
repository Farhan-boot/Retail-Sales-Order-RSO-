/**
 * CurrentOfferCtrl.js
 */
app.controller('NewGraphInfoCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/VFocusAPI/api/Kpideshboard/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Show List";

        $scope.PageTitle = 'New KPI VS Dashboard';
        $scope.ListTitle = 'KPI VS Dashboard List';
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

        GetPermission('02115');


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



        loadKPILIST(0);

        //**********----GET KPI ITEM LIST ----***************
        function loadKPILIST(isPaging) {
            // alert('hello'); debugger;
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RoleId: 0,
                loggeduser: $scope.loggedUserId,
                KPIID: 0,
            };

            var apiRoute = DirectoryKey + '/VFocusAPI/api/vFocusDropdown/GetKpiList/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listKPI = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listKPI.then(function (response) {
                $scope.listKPI = response.data.objListKPIItem;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }




        //loadKPIGRAPHLIST(0);

        //**********----GET KPI VS Graph list ----***************
        
        $scope.loadKPIGRAPHLIST = function (i, listKPIModel) {
             
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RoleId: 0,
                loggeduser: $scope.loggedUserId,
                KPIID: listKPIModel,
            };

            var apiRoute = DirectoryKey + '/VFocusAPI/api/vFocusDropdown/GetKpigraphList/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var Graphlist = 'Graphlist_' + i;

            if (i === 1) {
            var Graphlist1 = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
                Graphlist1.then(function (response) {
                    $scope.Graphlist1 = response.data.objListGRAPHKPI;
                },

                    function (error) {
                        console.log("Error: " + error);
                    });    

            }

           else if (i === 2) {
                var Graphlist2 = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
                Graphlist2.then(function (response) {
                    $scope.Graphlist2 = response.data.objListGRAPHKPI;
                },

                    function (error) {
                        console.log("Error: " + error);
                    });

            }

           else if (i === 3) {
                var Graphlist3 = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
                Graphlist3.then(function (response) {
                    $scope.Graphlist3 = response.data.objListGRAPHKPI;
                },

                    function (error) {
                        console.log("Error: " + error);
                    });

            }



                       
        }

        $scope.loadKPIGRAPHLIST2 = function (listKPIModel) {
            // alert('hello'); debugger;
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RoleId: 0,
                loggeduser: $scope.loggedUserId,
                KPIID: listKPIModel,
            };

            var apiRoute = DirectoryKey + '/VFocusAPI/api/vFocusDropdown/GetKpigraphList/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var Graphlist = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            Graphlist.then(function (response) {
                $scope.Graphlist = response.data.objListGRAPHKPI;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }


        $scope.loadKPIGRAPHLIST3 = function (listKPIModel) {
            // alert('hello'); debugger;
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RoleId: 0,
                loggeduser: $scope.loggedUserId,
                KPIID: listKPIModel,
            };

            var apiRoute = DirectoryKey + '/VFocusAPI/api/vFocusDropdown/GetKpigraphList/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var Graphlist = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            Graphlist.then(function (response) {
                $scope.Graphlist = response.data.objListGRAPHKPI;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }


        //**********----Get All Customer Records----***************
        function loadAllKPI_VS_Dashboard(isPaging) {
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
                    { name: "KPI1_NAME", displayName: "KPI1_NAME", title: "KPI1_NAME", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "GRAPH1_NAME", displayName: "GRAPH1_NAME", title: "GRAPH1_NAME", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "KPI2_NAME", displayName: "KPI2_NAME", title: "KPI2_NAME", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "GRAPH2_NAME", displayName: "GRAPH2_NAME", title: "GRAPH2_NAME", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "KPI3_NAME", displayName: "KPI3_NAME", title: "KPI3_NAME", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "GRAPH3_NAME", displayName: "GRAPH3_NAME", title: "GRAPH3_NAME", width: '15%', headerCellClass: $scope.highlightFilteredHeader },



                    {
                        name: 'Action',
                        displayName: "Action",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '10%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<div style="padding-left: 12px"><span class="label label-info label-mini" style="text-align:center !important;">' +
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
                exporterCsvFilename: 'KPIDashboard.csv',
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
            var apiRoute = baseUrl + 'GetAllKPIDashboardList/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listCurrentOfferInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listCurrentOfferInfo.then(function (response) {
                $scope.pagination.totalItems = response.data.recordsTotal;
                $scope.gridOptionsNewGraphInfo.data = response.data.KPIDashboardList;
                $scope.loaderMoreNewGraphInfo = false;
                $scope.currentOfferList = response.data.KPIDashboardList;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };

        loadAllKPI_VS_Dashboard(0);


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
                LASTUPDATE_BY: $scope.loggedUserId,
                KPI_KEY1: $scope.listKPIModel1,
                GRAPH_ID1: $scope.listGRAPHModel1,

                KPI_KEY2: $scope.listKPIModel2,
                GRAPH_ID2: $scope.listGRAPHModel2,

                KPI_KEY3: $scope.listKPIModel3,
                GRAPH_ID3: $scope.listGRAPHModel3,
                
            };

            // var HedarTokenPostPut = $scope.CustomerID > 0 ? $scope.HeaderToken.put : $scope.HeaderToken.post;
            var apiRoute = baseUrl + 'SaveKpiDashboard/';
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
                    //loggeduser: $scope.loggedUserId,
                };

                var GraphInfo = {
                    GraphId: dataModel.GRAPH_ID,
                    GraphCode: dataModel.GRAPH_CODE,
                    GraphName: dataModel.GRAPH_NAME,
                    Detail: dataModel.DETAIL,
                    StrMode: 'D'
                };

                // var HedarTokenPostPut = $scope.CustomerID > 0 ? $scope.HeaderToken.put : $scope.HeaderToken.post;
                var apiRoute = baseUrl + 'SaveKpiDashboard/';
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

