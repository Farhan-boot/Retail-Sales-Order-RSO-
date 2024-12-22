/**
 * RetailerBestPracticeCtrl.js
 */

app.config(['$compileProvider', '$locationProvider', function ($compileProvider) { 
    $compileProvider.debugInfoEnabled(true);

    //, $locationProvider
    //$locationProvider.html5Mode({
    //    enabled: true,
    //    requireBase: false
    //});
}]);

app.controller('BestRetailerPracticeCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {
        var baseUrl = DirectoryKey +'/SFTS/api/BestRetailerPractice/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.IsCreateIcon = false;
        $scope.IsListIcon = true;
        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Show List";

        $scope.PageTitle = 'Add New Best Retailer Practice';
        $scope.ListTitle = 'Best Retailer Practice List';

        // debugger
        $scope.gridOptionsBestRetailerPractice = [];

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
                $scope.PageTitle = 'Existing Best Retailer Practices';
                $scope.IsShow = false;
                $scope.IsHidden = false;

                $scope.IsCreateIcon = true;
                $scope.IsListIcon = false;
                loadAllRetailerBestPractice(0);
            }
        }


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

        GetPermission('00401');



        //**********----Get Region ----***************
        function loadRegions(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RoleId: 0,
                //loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetRegions/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRegions = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRegions.then(function (response) {
                $scope.listRegion = response.data.objListRegion;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadRegions(0);


        //**********----Get Distributors ----***************
        $scope.loadDistributors = function (isPaging) {
            $("#ddlDistributor").select2("val", "");
            var regionId = $scope.Region;
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RegionId: regionId
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
        //$scope.loadDistributors(0);

        //**********----Get Retailers ----***************
        $scope.loadRetailers = function (isPaging) {
            $("#ddlRetailer").select2("val", "");
            var distributorId = $scope.Distributor;
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                DistributorID: distributorId
                //loggeduser: $scope.loggedUserId,                           
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetRetailers/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRetailers = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRetailers.then(function (response) {
                $scope.listRetailer = response.data.objListRetailer;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        //$scope.loadRetailers(0);

        //**********----Get Months ----***************
        function loadMonths(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                //loggeduser: $scope.loggedUserId,                           
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetMonths/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listMonths = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listMonths.then(function (response) {
                $scope.listMonth = response.data.objListMonth;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadMonths(0);

        //**********----Get Calculation Area ----***************
        function loadCalculationAreas(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                //loggeduser: $scope.loggedUserId,                           
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetCalculationAreas/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listCalculationAreas = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listCalculationAreas.then(function (response) {
                $scope.listCalculationArea = response.data.objListCalculationArea;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadCalculationAreas(0);


   
        //**********----Get All Best Retailer Practice Records----***************

        function loadAllRetailerBestPractice(isPaging) {
            $scope.gridOptionsBestRetailerPractice.enableFiltering = true;
            $scope.gridOptionsBestRetailerPractice.enableGridMenu = true;

            // For Loading
            if (isPaging == 0)
                $scope.pagination.pageNumber = 1;

            //For Loading
            $scope.loaderMoreBestRetailerPractice = true;
            $scope.lblMessageForBestRetailerPractice = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsBestRetailerPractice = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "REGION_NAME", displayName: "Region", title: "Region", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISTRIBUTOR_NAME", displayName: "Distributor", title: "Distributor", width: '30%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "RETAILER_NAME", displayName: "Retailer", title: "Retailer", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "PERIOD_NAME", displayName: "Month", title: "Month", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "YEAR", displayName: "Year", title: "Year", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Action',
                        displayName: "Action",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '12%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<div style="padding-left: 12px"><span class="label label-info label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="Edit" ng-click="grid.appScope.getBestRetailerPractice(row.entity)">' +
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
                RetailerBestPracticeId: 0,
                loggeduser: $scope.loggedUserId
            };

   
            var apiRoute = baseUrl + 'GetAllBestRetailerPractice/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRetailerBestPracticeInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRetailerBestPracticeInfo.then(function (response) {
                $scope.pagination.totalItems = response.data.recordsTotal;
                $scope.gridOptionsBestRetailerPractice.data = response.data.bestRetailerPracticeList;
                $scope.loaderMoreBestRetailerPractice = false;
                $scope.RetailerBestPracticeList = response.data.bestRetailerPracticeList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        loadAllRetailerBestPractice(0);


        //**********----Get Single Record----***************
        $scope.getBestRetailerPractice = function (dataModel) {
            $scope.clear();
            $scope.IsShow = true;
            $scope.IsHiddenDetail = false;
            $scope.btnShowText = "Show List";
            $scope.btnSaveText = "Update";
            $scope.PageTitle = 'Update Best Retailer Practice';
            $scope.IsHidden = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;

            $scope.hBestRetailerPracticeId = dataModel.BEST_PRACTICES_RETAILER_ID;
            $scope.Region = dataModel.REGION_ID;
            $scope.Distributor = dataModel.DISTRIBUTOR_ID;
            $scope.Retailer = dataModel.RETAILER_ID;
            $scope.Thana = '';
            $scope.Month = dataModel.PERIOD_ID;
            $scope.Year = dataModel.YEAR;
            $scope.CalculationArea = dataModel.CALCULATION_AREA_ID;
            tinyMCE.activeEditor.setContent(dataModel.DESCRIPTION)

            $("#ddlRegion").select2("data", { id: dataModel.REGION_ID, text: dataModel.REGION_NAME });
            $("#ddlDistributor").select2("data", { id: dataModel.DISTRIBUTOR_ID, text: dataModel.DISTRIBUTOR_NAME });
            $("#ddlRetailer").select2("data", { id: dataModel.RETAILER_ID, text: dataModel.RETAILER_NAME });
            $("#ddlMonth").select2("data", { id: dataModel.PERIOD_ID, text: dataModel.PERIOD_NAME == null ? "--Select Month--" : dataModel.PERIOD_NAME });
            $("#ddlCalculationArea").select2("data", { id: dataModel.CALCULATION_AREA_ID, text: dataModel.CALCULATION_AREA_NAME == null ? "--Select Calculation Area--" : dataModel.CALCULATION_AREA_NAME });

        };


        //**********----Create New Record----***************
        $scope.save = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '00402'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveBestRetailerPractice();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });          
        };


        $scope.SaveBestRetailerPractice = function () {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };

            var descriptionContent = tinyMCE.activeEditor.getContent();
            if (descriptionContent == "" || descriptionContent == null || descriptionContent == undefined) {
                alert("Please write something in Description!!");
                return;
            }

            var BRPInfo = {
                BestPracticesRetailerId: $scope.hBestRetailerPracticeId == undefined || $scope.hBestRetailerPracticeId == null ? 0 : $scope.hBestRetailerPracticeId,
                RetailerId: $scope.Retailer,
                PeriodId: $scope.Month,
                Year: $scope.Year,
                CalculationAreaId: $scope.CalculationArea,
                Description: descriptionContent
            };


            var apiRoute = baseUrl + 'SaveUpdateBestRetailerPractice/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(BRPInfo) + "]";

            var SaveUpdateRetailerBestPractice = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateRetailerBestPractice.then(function (response) {
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
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;

            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Show List";
            $scope.PageTitle = 'Add New Best Retailer Practice';

            $scope.hBestRetailerPracticeId = 0;
            $scope.Region = '';
            $scope.Distributor = '';
            $scope.Retailer = '';
            $scope.Thana = '';
            $scope.Month = '';
            $scope.Year = '';
            $scope.CalculationArea = '';
            tinyMCE.activeEditor.setContent("")

            $("#ddlRegion").select2("data", { id: '', text: '--Select Region--' });
            $("#ddlDistributor").select2("data", { id: '', text: '--Select Distributor--' });
            $("#ddlRetailer").select2("data", { id: '', text: '--Select Retailer--' });
            $("#ddlMonth").select2("data", { id: '', text: '--Select Month--' });
            $("#ddlCalculationArea").select2("data", { id: '', text: '--Select Calculation Area--' });

            loadAllRetailerBestPractice(0);
        };
    }]);

