/**
 * UnitOfMeasurementCtrl.js
 */

app.controller('bankAccountCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {
        var baseUrl = '/SystemCommon/api/BankAccount/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;
       
        $scope.btnAccountSaveText = "Save";
        $scope.btnAccountShowText = "Show List";

     
        $scope.PageTitle = 'Bank Account Creation';
        $scope.ListTitle = 'Bank Account Records';
        $scope.ListTitleAccountMasters = 'Bank Account (Masters)';
     
   


        $scope.BankAccountID = 0;

        $scope.gridOptionsAccountMaster = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;
        $scope.IsHiddenDetail = true;
        $scope.ShowHide = function () {
            $scope.IsHidden = $scope.IsHidden == true ? false : true;
            $scope.IsHiddenDetail = true;
            if ($scope.IsHidden == true) {
                $scope.btnAccountShowText = "Show List";
                $scope.IsShow = true;

                $scope.IsCreateIcon = false;
                $scope.IsListIcon = true;
            }
            else {
                $scope.btnAccountShowText = "Create";
                $scope.IsShow = false;
                $scope.IsHidden = false;

                $scope.IsCreateIcon = true;
                $scope.IsListIcon = false;
                loadBankMasterRecords(0);
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
  

        //**********----Get Record of Bank ----***************
        function loadBankRecords(isPaging) {
          
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.UserCommonEntity.loggedUserID,
                loggedCompany: $scope.UserCommonEntity.loggedCompnyID,
                menuId: $scope.UserCommonEntity.currentMenuID,
                tTypeId: $scope.UserCommonEntity.currentTransactionTypeID
            };

            var apiRoute = baseUrl + 'GetBank/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listBank = crudService.GetList(apiRoute, cmnParam);
            listBank.then(function (response) {
                $scope.listBank = response.data.objBank;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        loadBankRecords(0);
        

        //**********----Get Record of Bank ----***************
     $scope.LoadBranchByBankID= function () {
          
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.UserCommonEntity.loggedUserID,
                loggedCompany: $scope.UserCommonEntity.loggedCompnyID,
                menuId: $scope.UserCommonEntity.currentMenuID,
                tTypeId: $scope.UserCommonEntity.currentTransactionTypeID
            };

            var apiRoute = baseUrl + 'LoadBranchByBankID/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + ","+JSON.stringify($scope.ngmBank) + "]";

            var listBranch = crudService.GetList(apiRoute, cmnParam);
            listBranch.then(function (response) {
                $scope.listBranch = response.data.objBranch;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
 


        ////**********----Get All Record----***************
        //function loadBankMasterRecords(isPaging) {

        //    objcmnParam = {
        //        pageNumber: page,
        //        pageSize: pageSize,
        //        IsPaging: isPaging,
        //        loggeduser: $scope.UserCommonEntity.loggedUserID,
        //        loggedCompany: $scope.UserCommonEntity.loggedCompnyID,
        //        menuId: $scope.UserCommonEntity.currentMenuID,
        //        tTypeId: $scope.UserCommonEntity.currentTransactionTypeID
        //    };
        //    var apiRoute = baseUrl + 'getDetailByMstrBankID/';

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
                 loadBankMasterRecords(1);
            },
            firstPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber = 1
                     loadBankMasterRecords(1);
                }
            },
            nextPage: function () {
                if (this.pageNumber < this.getTotalPages()) {
                    this.pageNumber++;
                    loadBankMasterRecords(1);
                }
            },
            previousPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber--;
                     loadBankMasterRecords(1);
                }
            },
            lastPage: function () {
                if (this.pageNumber >= 1) {
                    this.pageNumber = this.getTotalPages();
                    loadBankMasterRecords(1);
                }
            }
        };
        //  }


        //**********----Get All Mrr Master Records----***************
       function loadBankMasterRecords (isPaging) {


            $scope.gridOptionsAccountMaster.enableFiltering = true;
            $scope.gridOptionsAccountMaster.enableGridMenu = true;

            // For Loading
            if (isPaging == 0)
                $scope.pagination.pageNumber = 1;

            //For Loading
            $scope.loaderMoreMrrMaster = true;
            $scope.lblMessageForMrrMaster = 'loading please wait....!';
            $scope.result = "color-red";

            ////Ui Grid
            objcmnParam = {
                pageNumber: (($scope.pagination.pageNumber - 1) * $scope.pagination.pageSize),
                pageSize: $scope.pagination.pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.UserCommonEntity.loggedUserID,
                loggedCompany: $scope.UserCommonEntity.loggedCompnyID,
                menuId: $scope.UserCommonEntity.currentMenuID,
                tTypeId: $scope.UserCommonEntity.currentTransactionTypeID
            };

            //objcmnParam.pageNumber = ($scope.pagination.pageNumber - 1) * $scope.pagination.pageSize;
            //objcmnParam.pageSize = $scope.pagination.pageSize;
            //objcmnParam.IsPaging = isPaging;


            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsAccountMaster = {
                useExternalPagination: true,
                useExternalSorting: true,

                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
               


                    { name: "BankName", displayName: "Bank Name", title: "Bank Name", width: '25%', headerCellClass: $scope.highlightFilteredHeader },

                    { name: "BranchName", displayName: "Branch Name", title: "Branch Name", width: '25%', headerCellClass: $scope.highlightFilteredHeader },
                     
                    { name: "AccountName", displayName: "Account Name", title: "Account Name", width: '25%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "AccountNo", displayName: "Account No", title: "Account No", width: '18%', headerCellClass: $scope.highlightFilteredHeader },

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
                                      '<a href="" title="Edit" ng-click="grid.appScope.getDetailByMstrBankID(row.entity)">' +
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

 
            var apiRoute = baseUrl + 'GetBankAccountMaster/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listMasterBankAccount = crudService.GetList(apiRoute, cmnParam);
            

            var listMasterBankAccount = crudService.GetList(apiRoute, cmnParam);
            listMasterBankAccount.then(function (response) {
                    $scope.pagination.totalItems = response.data.recordsTotal;
                    $scope.gridOptionsAccountMaster.data = response.data.objMasterBankAccount;
                    $scope.loaderMoreAccountMaster = false;
            },
            function (error) {
                console.log("Error: " + error);
            }); 
        };

        loadBankMasterRecords(0);




        //**********----Get Single Record----***************
        $scope.getDetailByMstrBankID = function (dataModel) {

            $scope.IsShow = true;
            $scope.IsHiddenDetail = false;
            $scope.IsDefaultBranch = false;
           
            //
            $scope.btnAccountShowText = "Show List";
            $scope.IsHidden = true;
            //
            $scope.btnAccountSaveText = "Update";


            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;

            $("#ddlBank").prop("disabled", true);

            angular.forEach($scope.listBank, function (item) {
                if (item.BankID == dataModel.BankID)
                { 
                    $scope.ngmBank = dataModel.BankID;
                    $("#ddlBank").select2("data", { id: dataModel.BankID, text: item.BankName }); 
                            return false;
                 }
                });

            // BankID = bnk.BankID, BankName = bnk.BankName, BranchID = brnc.BranchID,
            // BranchName = brnc.BranchName, collapsed = true, IsDcBank = bnk.IsDCBank, 
            // Address = brnc.Address, SwiftCode = brnc.SwiftCode, CompanyID

            if (dataModel.IsDefault)
            {
                $scope.IsDefaultBranch = dataModel.IsDefault;
            }
         

            $scope.BranchID = dataModel.BranchID;
            $scope.BranchName = dataModel.BranchName; 
            $scope.BranchAddress = dataModel.Address; 
            $scope.SwiftCode = dataModel.SwiftCode;
               

            $scope.btnUnitOfMeasurementSaveText = "Update";



            //var apiRoute = baseUrl + 'GetUnitOfMeasurementById/' + dataModel.BranchID;

            //var singleUnitOfMeasurement = crudService.getByID(apiRoute);
            //singleUnitOfMeasurement.then(function (response) {
            //    $scope.BranchID = response.data.BranchID;
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

        

            var bankAccountMaster = {
                BankAccountID: $scope.BankAccountID,
                BankID: $scope.ngmBank,
                BranchID: $scope.ngmBranch, 
                AccountName:$scope.AccountName,
                AccountNo: $scope.AccountNo,
                CompanyID: $scope.UserCommonEntity.loggedCompnyID,
                CreateBy: $scope.UserCommonEntity.loggedUserID,
               
            };

            var HedarTokenPostPut = $scope.BankAccountID > 0 ? $scope.HeaderToken.put : $scope.HeaderToken.post;
            var apiRoute = baseUrl + 'SaveUpdateBankAccount/'; 
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(bankAccountMaster) + "]";

            var bankAccountCreateUpdate = crudService.GetList(apiRoute, cmnParam, HedarTokenPostPut);
            bankAccountCreateUpdate.then(function (response) {
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
            var IsConf = confirm('You are about to delete ' + dataModel.BranchName + '. Are you sure?');
            if (IsConf) {
                var apiRoute = baseUrl + 'DeleteBranch/' + dataModel.BranchID;
                var BranchDelete = crudService.delete(apiRoute);
                BranchDelete.then(function (response) {
                    
                    if (response.data==1)
                    {
                        Command: toastr["success"]("Delete Successfull!!!!");
                        //$scope.btnAccountShowText = "Create";
                        //$scope.IsShow = false;
                        //$scope.IsHidden = false;

                        //$scope.IsCreateIcon = true;
                        //$scope.IsListIcon = false;
                    loadBankMasterRecords(0);
                    }
                    else if (response.data == 0) {
                            Command: toastr["warning"]("Delete Not Successfull!!!!"); 
                    }

                   // $scope.clear();
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

            $scope.btnAccountSaveText = "Save";
            $scope.btnAccountShowText = "Show List";


            $scope.BranchID = 0;
            $scope.SwiftCode = '';
            $scope.BranchName = '';
            $scope.BranchAddress = '';
            $scope.IsDefaultBranch = false;

            $("#ddlBank").prop("disabled", false);

            $scope.btnUnitOfMeasurementSaveText = "Save";
            $scope.ngmBank = '';
            $("#ddlBank").select2("data", { id: '', text: '--Select Bank--' });

            loadBankMasterRecords(0);
    
            loadBankRecords(0);

        };

        $scope.clearBank = function () {

            $scope.BankModalID = 0;
            $scope.BankName = '';
            $scope.ShortName = ''; 
            $scope.IsDCBank = false;
             
            loadBankRecords(0); 
        };


    }]);

function modal_fadeOut_Bank() {
    $("#BankModal").fadeOut(200, function () {
        $('#BankModal').modal('hide');
    });
}

