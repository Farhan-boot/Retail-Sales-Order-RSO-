/**
 * CurrentOfferCtrl.js
 */
app.controller('NewGraphInfoCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/VFocusAPI/api/graphkpi/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;
        $scope.unassignGraph = [];
        $scope.assignGraph = [];

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Show List";

        $scope.PageTitle = 'Graph VS KPI Mapping';
        $scope.ListTitle = 'Graph VS KPI Mapping List';
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

        GetPermission('02113');


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



        //loadKPILIST(0);


        //**********----GET Assign Unassign Graph ----***************
        $scope.loadUNASSINGGRPH = function (listKPIModel) {
            // alert('hello'); debugger;
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RoleId: 0,
                loggeduser: $scope.loggedUserId,
                KPIID: listKPIModel,
            };

            var apiRoute = DirectoryKey + '/VFocusAPI/api/vFocusDropdown/GetAllAssignUnAssignGraph/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken)
                .then(function (response) {
                    $scope.unassignGraph = response.data.objListUNASSGRAPH;
                    $scope.assignGraph = [];
                },
                    function (error) {
                        console.error(error)
                    })
                .then(function () {
                    $scope.UpdateAssignUnAssignGrapth();
                    $scope.UpdateAssigngnGrapth();
                })
        }

        $scope.UpdateAssignUnAssignGrapth = function () {
            if ($scope.unassignGraph.findIndex(x => x.ISASSIGN === true) == -1 && $scope.assignGraph.findIndex(x => x.ISASSIGN === true) == -1 && $scope.assignGraph.length != 0 && $scope.unassignGraph.length != 0) {
                Command: toastr["error"]("Please select at least one item");
                return;
            }
            let count = 0;
            /*for (let i = 0; i < $scope.unassignGraph.length; i++) {
                if ($scope.unassignGraph[i].ISASSIGN) {
                    count++;
                }
            }
            for (let i = 0; i <= count; i++) {
                let _i = $scope.unassignGraph.findIndex(x => x.ISASSIGN === true);
                if (_i > -1) {
                    $scope.unassignGraph[_i].ISASSIGN = false;
                    $scope.assignGraph.push($scope.unassignGraph[_i]);
                    $scope.unassignGraph.splice(_i, 1);


                    if ($scope.assignGraph.length == 5) {
                        i = count+1;
                    }
                }
            }  */
            
            
            count = 0;
            for (let i = 0; i < $scope.assignGraph.length; i++) {
                if ($scope.assignGraph[i].ISASSIGN) {
                    count++;
                }
            }
            for (let i = 0; i <= count; i++) {
                let _i = $scope.assignGraph.findIndex(x => x.ISASSIGN === true);
                if (_i > -1) {
                    $scope.assignGraph[_i].ISASSIGN = false;
                    $scope.unassignGraph.push($scope.assignGraph[_i]);
                    $scope.assignGraph.splice(_i, 1);

                    if ($scope.assignGraph.length == 5) {
                        i = count+1;
                    }

                }
            }

            if ($scope.assignGraph.length >= 5) {
                $("#btnassign").prop("disabled", true);
            }
            else {
                $("#btnassign").prop("disabled", false);
            }  
            


        };



        $scope.UpdateAssigngnGrapth = function () {
          //  alert(1);
            if ($scope.unassignGraph.findIndex(x => x.ISASSIGN === true) == -1 && $scope.assignGraph.findIndex(x => x.ISASSIGN === true) == -1 && $scope.assignGraph.length == 0 && $scope.unassignGraph.length != 0) {
                Command: toastr["error"]("Please select at least one item");
                return;
            }        


            let count = 0;
            for (let i = 0; i < $scope.unassignGraph.length; i++) {
                if ($scope.unassignGraph[i].ISASSIGN) {
                    count++;
                }
            }
            for (let i = 0; i <= count; i++) {
                let _i = $scope.unassignGraph.findIndex(x => x.ISASSIGN === true);
                if (_i > -1) {
                    $scope.unassignGraph[_i].ISASSIGN = false;
                    $scope.assignGraph.push($scope.unassignGraph[_i]);
                    $scope.unassignGraph.splice(_i, 1);


                    if ($scope.assignGraph.length == 5) {
                        i = count + 1;
                    }
                }
            }

            if ($scope.assignGraph.length >= 5) {
                $("#btnassign").prop("disabled", true);
            }
            else {
                $("#btnassign").prop("disabled", false);
            }



        };


        //**********----Get All Customer Records----***************
        function loadAllNewGraphInfo(isPaging) {
            //alert('hellow'); debugger;
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
                    { name: "KPI_NAME", displayName: "KPI_NAME", title: "KPI_NAME", width: '25%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "KPI_DETAILS", displayName: "KPI_DETAILS", title: "KPI_DETAILS", width: '25%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "GRAPH_CODE", displayName: "GRAPH_CODE", title: "GRAPH_CODE", width: '25%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "GRAPH_NAME", displayName: "GRAPH_NAME", title: "GRAPH_NAME", width: '25%', headerCellClass: $scope.highlightFilteredHeader },
                    /*{
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
                    }*/
                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: true,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'GraphKPI.csv',
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
            var apiRoute = baseUrl + 'GetAllGraphKpi/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listCurrentOfferInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listCurrentOfferInfo.then(function (response) {
                $scope.pagination.totalItems = response.data.recordsTotal;
                $scope.gridOptionsNewGraphInfo.data = response.data.graphKPIList;
                $scope.loaderMoreNewGraphInfo = false;
                $scope.currentOfferList = response.data.graphKPIList;
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

            $scope.hKPIkey = dataModel.KPI_KEY;
            $scope.KNAME = dataModel.KPI_NAME;
            $scope.KDETAILS = dataModel.KPI_DETAILS;

            $scope.Detail = dataModel.DETAIL;


            $("#ddllistKPI").select2("data", { id: dataModel.KPI_KEY, text: dataModel.KPI_NAME });


        };





        //**********----Create New Record----***************

        $scope.save = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '02114'
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
                CreatedBy: $scope.loggedUserId,
                KPI_KEY: $scope.listKPIModel
            };

            var GraphInfo = {
                //GraphId: $scope.hGraphId == undefined || $scope.hGraphId == null ? 0 : $scope.hGraphId,
                //GraphCode: $scope.GraphCode,
                //GraphName: $scope.GraphName,
               // Detail: $scope.Detail,
                CreatedBy: $scope.loggedUserId,
                AssingGraph: $scope.assignGraph,
                UnassignGraph: $scope.unassignGraph

            };

            // var HedarTokenPostPut = $scope.CustomerID > 0 ? $scope.HeaderToken.put : $scope.HeaderToken.post;
            var apiRoute = baseUrl + 'SaveGraphKpi/';
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
                var apiRoute = baseUrl + 'SaveGraphKpi/';
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

            $("#ddllistKPI").select2("data", { id: '', text: '--Select Target Item--' });


            loadAllNewGraphInfo(0);
        };
    }]);

