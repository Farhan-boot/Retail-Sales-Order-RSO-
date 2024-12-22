/**
 * UnitOfMeasurementCtrl.js
 */

app.controller('unitOfMeasurementCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {
        var baseUrl = '/SystemCommon/api/UnitOfMeasurement/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnUnitOfMeasurementSaveText = "Save";

        $scope.btnMrrSaveText = "Save";
        $scope.btnMrrShowText = "Show List";

        $scope.PageTitle = 'Create Unit of Measurement';
        $scope.ListTitle = 'Unit of Measurement Records';

        $scope.PageTitle = 'Unit of Measurement Creation';
        $scope.ListTitle = 'Unit of Measurement Records';
        $scope.ListTitleMrrMasters = 'Unit of Measurement  Information (Masters)';
     
        $scope.ListTitleMrrDeatails = 'Unit of Measurement Information (Details)';


        $scope.UOMID = 0;

        $scope.gridOptionsMrrMaster = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;
        $scope.IsHiddenDetail = true;
        $scope.ShowHide = function () {
            $scope.IsHidden = $scope.IsHidden == true ? false : true;
            $scope.IsHiddenDetail = true;
            if ($scope.IsHidden == true) {
                $scope.btnMrrShowText = "Show List";
                $scope.IsShow = true;

                $scope.IsCreateIcon = false;
                $scope.IsListIcon = true;
            }
            else {
                $scope.btnMrrShowText = "Create";
                $scope.IsShow = false;
                $scope.IsHidden = false;

                $scope.IsCreateIcon = true;
                $scope.IsListIcon = false;
                loadUnitOfMeasurementRecords(0);
            }
        }

        function loadUserCommonEntity(num) {
            // debugger
            $scope.UserCommonEntity = {}
            $scope.UserCommonEntity = $scope.menuManager.LoadPageMenu(window.location.pathname);
            //  console.clear();
            //  debugger
            //Coming from SideNavCrl  
            $scope.permissionPageVisibility = true;
            $scope.generateSecurityParam = {};
            $scope.generateSecurityParam.MenuID = $scope.UserCommonEntity.currentMenuID;
            $scope.generateSecurityParam.CompanyID = $scope.UserCommonEntity.loggedCompnyID;

            $scope.HeaderToken = {};
            $scope.generateSecurityParam.methodtype = 'get';
            $scope.HeaderToken.get = { 'AuthorizedToken': $scope.tokenManager.generateSecurityToken($scope.generateSecurityParam) };
            $scope.generateSecurityParam.methodtype = 'put';
            $scope.HeaderToken.put = { 'AuthorizedToken': $scope.tokenManager.generateSecurityToken($scope.generateSecurityParam) };
            $scope.generateSecurityParam.methodtype = 'post';
            $scope.HeaderToken.post = { 'AuthorizedToken': $scope.tokenManager.generateSecurityToken($scope.generateSecurityParam) };
            $scope.generateSecurityParam.methodtype = 'delete';
            $scope.HeaderToken.delete = { 'AuthorizedToken': $scope.tokenManager.generateSecurityToken($scope.generateSecurityParam) };

        }
        loadUserCommonEntity(0);

        
      //  loadUnitOfMeasurementRecords(0);
        //
       // $scope.CustomCode = 1;
        $scope.UOMGroup = 0;
        //
     



        //**********----Get Record of UOMGroup ----***************
        function loadUOMGroupRecords(isPaging) {
          
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.UserCommonEntity.loggedUserID,
                loggedCompany: $scope.UserCommonEntity.loggedCompnyID,
                menuId: $scope.UserCommonEntity.currentMenuID,
                tTypeId: $scope.UserCommonEntity.currentTransactionTypeID
            };

            var apiRoute = baseUrl + 'GetUOMGroup/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listUOMGroup = crudService.GetList(apiRoute, cmnParam);
            listUOMGroup.then(function (response) {
                $scope.listUOMGroup = response.data.objListUOMGroup;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        loadUOMGroupRecords(0);




        ////**********----Get All Record----***************
        //function loadUnitOfMeasurementRecords(isPaging) {

        //    objcmnParam = {
        //        pageNumber: page,
        //        pageSize: pageSize,
        //        IsPaging: isPaging,
        //        loggeduser: $scope.UserCommonEntity.loggedUserID,
        //        loggedCompany: $scope.UserCommonEntity.loggedCompnyID,
        //        menuId: $scope.UserCommonEntity.currentMenuID,
        //        tTypeId: $scope.UserCommonEntity.currentTransactionTypeID
        //    };
        //    var apiRoute = baseUrl + 'GetUnitOfMeasurement/';

        //    var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

        //    var listUnitOfMeasurement = crudService.GetList(apiRoute, cmnParam);

        //    // var listUnitOfMeasurement = crudService.getAll(apiRoute, page, pageSize, isPaging);

        //    var listUnitOfMeasurement = crudService.GetList(apiRoute, cmnParam);
        //    listUnitOfMeasurement.then(function (response) {
        //        $scope.listUnitOfMeasurement = response.data.objUOMeasurement
        //    },
        //    function (error) {
        //        console.log("Error: " + error);
        //    });
        //}

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
                 loadUnitOfMeasurementRecords(1);
            },
            firstPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber = 1
                     loadUnitOfMeasurementRecords(1);
                }
            },
            nextPage: function () {
                if (this.pageNumber < this.getTotalPages()) {
                    this.pageNumber++;
                    loadUnitOfMeasurementRecords(1);
                }
            },
            previousPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber--;
                     loadUnitOfMeasurementRecords(1);
                }
            },
            lastPage: function () {
                if (this.pageNumber >= 1) {
                    this.pageNumber = this.getTotalPages();
                    loadUnitOfMeasurementRecords(1);
                }
            }
        };
        //  }


        //**********----Get All Mrr Master Records----***************
       function loadUnitOfMeasurementRecords (isPaging) {


            $scope.gridOptionsMrrMaster.enableFiltering = true;
            $scope.gridOptionsMrrMaster.enableGridMenu = true;

            // For Loading
            if (isPaging == 0)
                $scope.pagination.pageNumber = 1;

            //For Loading
            $scope.loaderMoreMrrMaster = true;
            $scope.lblMessageForMrrMaster = 'loading please wait....!';
            $scope.result = "color-red";

            //Ui Grid
            objcmnParam = {
                pageNumber: (($scope.pagination.pageNumber - 1) * $scope.pagination.pageSize),
                pageSize: $scope.pagination.pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.UserCommonEntity.loggedUserID,
                loggedCompany: $scope.UserCommonEntity.loggedCompnyID,
                menuId: $scope.UserCommonEntity.currentMenuID,
                tTypeId: $scope.UserCommonEntity.currentTransactionTypeID
            };


            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsMrrMaster = {
                useExternalPagination: true,
                useExternalSorting: true,

                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
               


                    { name: "UOMName", displayName: "UOM Name", title: "UOM Name", width: '50%', headerCellClass: $scope.highlightFilteredHeader },

                    { name: "UOMShortName", displayName: "UOM Short Name", title: "UOM Short Name", width: '35%', headerCellClass: $scope.highlightFilteredHeader },
                     
                    {
                        name: 'Action',
                        displayName: "Action",

                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                         

                        width: '15%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<span class="label label-info label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="Edit" ng-click="grid.appScope.getUnitOfMeasurement(row.entity)">' +
                                        '<i class="icon-edit" aria-hidden="true"></i> Edit' +
                                      '</a>' +
                                      '</span>' +

                                      '<span class="label label-warning label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="Delete" ng-click="grid.appScope.delete(row.entity)">' +
                                        '<i class="icon-glyphicon glyphicon-trash" aria-hidden="true"></i> Delete' +
                                      '</a>' +
                                      '</span>'
                         
                    }
                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: true,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'Mrr.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Mrr", style: 'headerStyle' },
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
                loggeduser: $scope.UserCommonEntity.loggedUserID,
                loggedCompany: $scope.UserCommonEntity.loggedCompnyID,
                menuId: $scope.UserCommonEntity.currentMenuID,
                tTypeId: $scope.UserCommonEntity.currentTransactionTypeID
            };
            var apiRoute = baseUrl + 'GetUnitOfMeasurement/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listUnitOfMeasurement = crudService.GetList(apiRoute, cmnParam);
            

            var listUnitOfMeasurement = crudService.GetList(apiRoute, cmnParam);
            listUnitOfMeasurement.then(function (response) { 
                    $scope.pagination.totalItems = response.data.recordsTotal;
                    $scope.gridOptionsMrrMaster.data = response.data.objUOMeasurement;
                    $scope.loaderMoreMrrMaster = false;
            },
            function (error) {
                console.log("Error: " + error);
            }); 
        };

        loadUnitOfMeasurementRecords(0);




        //**********----Get Single Record----***************
        $scope.getUnitOfMeasurement = function (dataModel) {

            $scope.IsShow = true;
            $scope.IsHiddenDetail = false;
            //
            $scope.btnMrrShowText = "Show List";
            $scope.IsHidden = true;
            //
            $scope.btnMrrSaveText = "Update";


            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;



            angular.forEach($scope.listUOMGroup, function (item) {
                if (item.UOMGroupID == dataModel.UOMGroupID)
                {

                    $scope.UOMGroup = dataModel.UOMGroupID;
                    $("#uOMGroup").select2("data", { id: dataModel.UOMGroupID, text: item.UOMGroupName });

                            return false;
                 }
                });


            $scope.UOMID = dataModel.UOMID;
            $scope.CustomCode = dataModel.CustomCode;
            $scope.UOMName = dataModel.UOMName;
            $scope.UOMShortName = dataModel.UOMShortName;
              
            $scope.UOMGroup = dataModel.UOMGroupID;
            $scope.btnUnitOfMeasurementSaveText = "Update";



            //var apiRoute = baseUrl + 'GetUnitOfMeasurementById/' + dataModel.UOMID;

            //var singleUnitOfMeasurement = crudService.getByID(apiRoute);
            //singleUnitOfMeasurement.then(function (response) {
            //    $scope.UOMID = response.data.UOMID;
            //    $scope.CustomCode = response.data.CustomCode;
            //    $scope.UOMName = response.data.UOMName;
            //    $scope.UOMShortName = response.data.UOMShortName;//new Date(response.data.SaleDate);
            //    // $scope.UOMGroupID = response.data.UOMGroupID;
            //    $scope.UOMGroup = response.data.UOMGroupID;
            //    $scope.btnUnitOfMeasurementSaveText = "Update";
            //},
            //function (error) {
            //    console.log("Error: " + error);
            //});
        };

        //**********----Create New Record----***************
        $scope.save = function ()
        {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.UserCommonEntity.loggedUserID,
                loggedCompany: $scope.UserCommonEntity.loggedCompnyID,
                menuId: $scope.UserCommonEntity.currentMenuID,
                tTypeId: $scope.UserCommonEntity.currentTransactionTypeID
            };

            var UnitOfMeasurement = {
                UOMGroupID: $scope.UOMGroup,
                CompanyID: $scope.UserCommonEntity.loggedCompnyID,
                CreateBy: $scope.UserCommonEntity.loggedUserID,
                CustomCode: $scope.CustomCode,
                UOMID: $scope.UOMID,
                UOMName: $scope.UOMName,
                UOMShortName: $scope.UOMShortName
            };

            var HedarTokenPostPut = $scope.UOMID > 0 ? $scope.HeaderToken.put : $scope.HeaderToken.post; 
            var apiRoute = baseUrl + 'SaveUpdateUnitOfMeasurement/'; 
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(UnitOfMeasurement) + "]";

            var UnitOfMeasurementCreateUpdate = crudService.GetList(apiRoute, cmnParam, HedarTokenPostPut);
            UnitOfMeasurementCreateUpdate.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    //  $scope.HGRRNo = response.data;

                }
                else if (response.data == "") {
                        Command: toastr["warning"]("Save Not Successfull!!!!");
                    $("#save").prop("disabled", false);
                }

            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        //**********----Delete Single Record----***************
        $scope.delete = function (dataModel) {
            var IsConf = confirm('You are about to delete ' + dataModel.UOMName + '. Are you sure?');
            if (IsConf) {
                var apiRoute = baseUrl + 'DeleteUnitOfMeasurement/' + dataModel.UOMID;
                var UnitOfMeasurementDelete = crudService.delete(apiRoute);
                UnitOfMeasurementDelete.then(function (response) {
                    
                    $scope.clear();
                }, function (error) {
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

            $scope.btnMrrSaveText = "Save";
            $scope.btnMrrShowText = "Show List";


            $scope.UOMID = 0;
            $scope.UOMGroup = 0;
            $scope.CustomCode = '';
            $scope.UOMName = '';
            $scope.UOMShortName = '';
            $scope.btnUnitOfMeasurementSaveText = "Save";
            $scope.UOMGroup = '';
            $("#uOMGroup").select2("data", { id: '', text: '--Select Group--' });
            loadUnitOfMeasurementRecords(0);
    
            loadUOMGroupRecords(0);

        };
    }]);

