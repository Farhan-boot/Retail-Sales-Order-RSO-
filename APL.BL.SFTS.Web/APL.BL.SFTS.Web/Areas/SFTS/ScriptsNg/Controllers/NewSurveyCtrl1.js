/**
* FocProductCtlr.js
*/
app.controller('NewSurveyCtrl1', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/Survey/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing New Survey';
        $scope.ListTitle = 'App Survey List';
        $scope.IsCreateIcon = true;
        $scope.IsListIcon = false;
        $scope.IsSurveyShow = false;
        $scope.gridOptionsNewSurvey = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;

        $scope.ShowHide = function () {
            //if ($scope.IsSurveyShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.btnShowText = "Create";
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Existing App Menus';
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Add New App Menu';
                    $scope.btnShowText = "Show List";
                    $scope.btnSaveShow = true;
                    $scope.btnResetShow = true;
                    $scope.btnSaveText = "Save";
                    $scope.IsShow = false;
                    $scope.IsHidden = false;

                    $scope.IsCreateIcon = false;
                    $scope.IsListIcon = true;
                }
            //} else {
            //    $scope.btnShowText = "Create";
            //    $scope.IsShow = true;
            //    $scope.btnSaveShow = false;
            //    $scope.btnResetShow = false;
            //    $scope.IsCreateIcon = true;
            //    $scope.IsListIcon = false;
            //    $scope.PageTitle = 'Existing App Menu';
            //}
        }

        function CommonEntity() {
            $scope.HeaderToken = $scope.tokenManager.generateSecurityToken();
            $scope.loggedUserId = $scope.loggedUserManager.loggedUser();
        }
        CommonEntity();
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

        GetPermission('01401');


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
        function loadRegion(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                //loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = baseUrl + '/GetRegions/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRegions = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRegions.then(function (response) {
                //$scope.listRegion = response.data.objListRegion;
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
        loadRegion(0);
        //**********----Get Distributors ----***************
        function loadDistributors(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                DistributorID: 0,
                //loggeduser: $scope.loggedUserId,                      
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetDistributors/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listDistributors = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listDistributors.then(function (response) {
                $scope.listDistributor = response.data.objListDistributor;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }

        loadDistributors(0);


        //**********----Get Routes ----***************
        $scope.loadRoutes = function (isPaging) {
            $("#ddlRoute").select2("val", "");
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                DistributorID: $scope.Distributor,
                RouteID: 0,
                //loggeduser: $scope.loggedUserId,                              
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetRoutes/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRoutes = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRoutes.then(function (response) {
                $scope.listRoute = response.data.objListRoute;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }

        function loadRoutes(isPaging) {
            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetRoutes/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listDistributors = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listDistributors.then(function (response) {
                $scope.listRoute = response.data.objListRoute;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }


        //**********----Get All Customer Records----***************
        function loadAllNewSurvey(isPaging) {
            $scope.gridOptionsNewSurvey.enableFiltering = true;
            $scope.gridOptionsNewSurvey.enableGridMenu = true;

            // For Loading
            if (isPaging == 0)
                $scope.pagination.pageNumber = 1;

            //For Loading
            $scope.loaderMoreNewSurvey = true;
            $scope.lblMessageForNewSurvey = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsNewSurvey = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "DISTRIBUTOR_NAME", displayName: "Distributor", title: "Distributor", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TITLE", displayName: "Title", title: "Title", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DESCRIPTION", displayName: "Description", title: "Description", width: '30%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "START_DATETIME", displayName: "Start Date", title: "Start Date", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "END_DATETIME", displayName: "End Date", title: "End Date", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SURVEY_FOR", displayName: "Survey For", title: "Survey For", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SURVEY_STATUS", displayName: "Status", title: "Status", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Action',
                        displayName: "Action",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '20%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<div style="padding-left: 12px"><span class="label label-info label-mini" style="text-align:center !important;">' +
                            '<a href="" title="Edit" ng-click="grid.appScope.getNewSurveyInfo(row.entity)">' +
                            '<i class="icon-edit" aria-hidden="true"></i> Edit' +
                            '</a>' +
                            '</span>' +

                            '<span class="label label-warning label-mini" style="text-align:center !important;">' +
                            '<a href="" title="Delete" ng-click="grid.appScope.delete(row.entity)">' +
                            '<i class="icon-trash" aria-hidden="true"></i> Delete' +
                            '</a>' +
                            '</span>' +

                            '<span ng-show="row.entity.SURVEY_STATUS==1" class="label label-success label-mini" style="text-align:center !important;">' +
                            '<a href="" title="Publish" ng-click="grid.appScope.publishSurveyInfo(row.entity)">' +
                            '<i class="fa fa-check-circle-o" aria-hidden="true"></i> Publish' +
                            '</a>' +
                            '</span>  ' +

                            '<span ng-show="row.entity.SURVEY_STATUS==2" class="label label-danger label-mini" style="text-align:center !important;">' +
                            '<a href="" title="Publish" ng-click="grid.appScope.publishSurveyInfo(row.entity)">' +
                            '<i class="fa fa-ban" aria-hidden="true"></i> Unpublish' +
                            '</a>' +
                            '</span></div> '
                    }
                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: true,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'Customer.csv',
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
                //loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetAllSurvey/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listCurrentOfferInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listCurrentOfferInfo.then(function (response) {
                $scope.pagination.totalItems = response.data.recordsTotal;
                $scope.gridOptionsNewSurvey.data = response.data.surveyList;
                $scope.loaderMoreNewSurvey = false;
                $scope.currentOfferList = response.data.surveyList;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };

        loadAllNewSurvey(0);


        //**********----Get Single Record----***************
        $scope.getNewSurveyInfo = function (dataModel) {
            $scope.IsShow = true;
            $scope.IsHiddenDetail = false;
            $scope.btnShowText = "Show List";
            $scope.IsHidden = true;
            $scope.btnSaveText = "Update";
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;


            $scope.hSurveyId = dataModel.SURVEYLIST_ID;
            $scope.Title = dataModel.TITLE;
            $scope.Description = dataModel.DESCRIPTION;
            $scope.StartDate = dataModel.START_DATETIME;
            $scope.EndDate = dataModel.END_DATETIME;
            $scope.SURVEY_FOR = dataModel.SURVEY_FOR;
            $scope.Distributor = dataModel.DISTRIBUTORID;
            $scope.Route = dataModel.ROUTE_CODE;

            $scope.ListSelectedRegion = [];
            $scope.selectedRegion = [];

            $scope.GetSurveyReg(dataModel.SURVEYLIST_ID);
         
            $("#ddlDistributor").select2("data", { id: dataModel.DISTRIBUTORID, text: dataModel.DISTRIBUTOR_NAME });
            $("#ddlRoute").select2("data", { id: dataModel.ROUTE_CODE, text: dataModel.ROUTE_NAME });
            if (dataModel.SURVEY_FOR == 2) {
                $("#ddlSurveyFor").select2("data", { id: dataModel.SURVEY_FOR, text: 'RSO' });
            } else {
                $("#ddlSurveyFor").select2("data", { id: dataModel.SURVEY_FOR, text: 'MTO' });
            }



        };

        $scope.publishSurveyInfo = function (dataModel) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId
            };
            var SurveyInfo = {
                SurveyId: dataModel.SURVEYLIST_ID
            };
            var apiRoute = baseUrl + 'PublishSurveyInfo/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(SurveyInfo) + "]";

            var PublishSurvey = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            PublishSurvey.then(function (response) {
                // debugger;
                if (response.data != "") {
                    Command: toastr["success"]("Update  Successfully!!!!");
                    loadAllNewSurvey(0);
                }
                else if (response.data == "") {
                    Command: toastr["warning"]("Update Not Successfull!!!!");
                }

            }, function (error) {
                console.log("Error: " + error);
            });

        }
        $scope.GetSurveyReg = function (SurveyId) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                SurveyId: SurveyId,
                //loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetSurveyRegion/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listSurveyReg = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listSurveyReg.then(function (response) {
                $scope.surveyReg = response.data.surveyReg;
                $scope.ListSelectedRegion = $scope.surveyReg;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }


        //**********----Create New Record----***************

        $scope.save = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '01402'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
            console.log(cmnParam);
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
                //loggeduser: $scope.loggedUserId,
            };

            var SurveyInfo = {
                SurveyId: $scope.hSurveyId == undefined || $scope.hSurveyId == null ? 0 : $scope.hSurveyId,
                DistributorId: $scope.Distributor == null ? 0 : $scope.Distributor,
                RouteId: $scope.Route == null || $scope.Route == "" ? 0 : $scope.Route,
                FromDate: $scope.StartDate == "" || $scope.StartDate == null ? null : conversion.getStringToDate($scope.StartDate),
                ToDate: $scope.EndDate == "" || $scope.EndDate == null ? null : conversion.getStringToDate($scope.EndDate),
                StatusId: $scope.Status,
                SurveyTitle: $scope.Title,
                Description: $scope.Description,
                SURVEY_FOR: $scope.SURVEY_FOR
            };

            // var HedarTokenPostPut = $scope.CustomerID > 0 ? $scope.HeaderToken.put : $scope.HeaderToken.post;
            var apiRoute = baseUrl + 'SaveUpdateSurvey/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(SurveyInfo) + "," + JSON.stringify(selectedRegion) + "]";

            var SaveUpdateSurvey = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateSurvey.then(function (response) {
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
            var IsConf = confirm('You are about to delete ' + dataModel.OFFER_NAME + '. Are you sure?');
        }

        //**********----Reset Record----***************
        $scope.clear = function () {
            $scope.IsHidden = true;
            $scope.IsShow = true;
            $scope.IsHiddenDetail = true
            $scope.IsCreateIcon = true;
            $scope.IsListIcon = false;

            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Create";

            $scope.hSurveyId = 0;
            $scope.Title = '';
            $scope.Description = '';
            $scope.StartDate = '';
            $scope.EndDate = '';

            loadAllNewSurvey(0);

            $("#ddlDistributor").select2("data", { id: '', text: '--Select Distributor--' });
            $("#ddlRoute").select2("data", { id: '0', text: '--Select Route--' });
            $("#ddlSurveyFor").select2("data", { id: '', text: '--Select Survey For--' });
            // $("#ddlRoute").select2("data", { id: '', text: '--Select Route--' }); 

            //loadRegion(0);
            $scope.ListSelectedRegion = [];
            $scope.selectedRegion = [];
        };
    }]);

