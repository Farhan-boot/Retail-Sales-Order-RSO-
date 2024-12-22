/*
*    Created By: Shashangka Shekhar;
*    Create Date: 22-5-2016 (dd-mm-yy); Updated Date: 22-5-2016 (dd-mm-yy);
*    Name: 'crudService';
*    Type: $http service;
*    Purpose: Register New member with validaing user input;
*    Service Injected: '$scope', 'crudService', '$http', '$filter';
*/

//app.controller('userCtrl', function ($scope, $http, crudService, $filter) {
app.config(['$compileProvider', function ($compileProvider) {
    $compileProvider.debugInfoEnabled(true);
}]);


app.controller('userCtrl', ['$scope', 'crudService', 'uiGridConstants', '$q', '$http', 'conversion',
function ($scope, crudService, uiGridConstants, $q, $http, conversion) {

    $scope.gridOptionsUsers = [];
    var objcmnParam = {};

    $scope.onlyNumbers = /^\d+$/;
    var isExisting = 0;
    var page = 1;
    var pageSize = 20;
    var isPaging = 0;
    var inCallback = false;
    var totalData = 0;

    var LUserID = $('#hUserID').val();
    var LCompanyID = $('#hCompanyID').val();
    $scope.EditUserID = 0;
    $scope.IsOnlineAccount = false;
    $scope.PanelTitle = 'New User';
    $scope.DataPanelTitle = 'Existing User';
    $scope.listUser = [];
    var User = {};
    var OnlineAccount = 0;

    $scope.ngHPassword = false;
    $scope.ngHLoginID = false;
    $scope.loaderMore = false;
    $scope.loaderUpload = false;
    $scope.scrollended = false;

    $scope.SelectedFileAvatar = [];
    $scope.SelectedFileSignature = [];
    $scope.SelectedFileFinger = [];

    $scope.signaturename = null;
    $scope.avatarname = null;
    $scope.PopTitle = "Ledger List";
    $scope.UserType = 0;
    $scope.UserType = $('#hUserType').val();
    $scope.CounteryID = 0;
    $scope.StateID = 0;
    $scope.Flag = "";
    $scope.AddressType = "";
    $scope.ACTypeID = 0;
    $scope.fdfsf = true;
    $scope.IsLoginIDRequired = false;
    $scope.IsRequiredFirstName = false;
    $scope.IsJCDepartmentRequired = false;
    $scope.IsDefultCompanyRequired = false;
    $scope.IsJCDesignationRequired = false;
    $scope.IsRequiredBuyerName = false;
    $scope.IsRequiredSupplierName = false;
    $scope.IsRequiredSupplierContactPerson = false;
    $scope.IsRequiredddSupplier = false;
    $scope.IsRequiredddParty = false;
    $scope.IsRequiredPartyContactPersonName = false;
    //-------------Tab Name----------------
    $scope.ngComPerMission = true;
    $scope.ngJobContract = true;
    $scope.ngLedger = true;
    $scope.ngPresentAddress = true;
    $scope.ngPermanentAddress = true;
    $scope.ngPersonalInfo = true;
    $scope.ngAccountInfo = true;
    $scope.TabActive = "";
    // for Personal Info
    $scope.ngPersonalInfoforEmployeeDesign = true;
    $scope.ngPersonalInfoforSupplier = false;
    $scope.ngPersonalInfoforBuyer = false;
    $scope.ngPersonalInfoforBuyerReff = false;
    $scope.ngPersonalInfoforPartyContactPersonDesign = false;
    $scope.ngPersonalInfoforSupplierContactPersonDesign = false;
    $scope.TabManageByUserTyeID = function () {
        debugger
        if ($scope.UserType == 1) { // For User
            $scope.ActiveAccountInfo = "active";
            $scope.ACTypeID = 4;
        }
        else if ($scope.UserType == 3) { // for Supplier
            debugger
            $scope.ACTypeID = 2;
            $scope.ActivePersonalInfo = "active";
            $scope.PanelTitle = 'New Supplier';
            $scope.DataPanelTitle = 'Existing Supplier';
            $scope.ngComPerMission = false;
            $scope.ngJobContract = false;
            $scope.ngAccountInfo = false;
            $scope.ngPermanentAddress = false;
            $scope.ngPersonalInfoforEmployeeDesign = false;
            $scope.ngPersonalInfoforSupplier = true;
        }
        else if ($scope.UserType == 2) { // for Buyer
            debugger
            $scope.ACTypeID = 3;
            $scope.ActivePersonalInfo = "active";
            $scope.PanelTitle = 'New Buyer';
            $scope.DataPanelTitle = 'Existing Buyer';
            $scope.ngComPerMission = false;
            $scope.ngJobContract = false;
            $scope.ngAccountInfo = false;
            $scope.ngPermanentAddress = false;
            $scope.ngPersonalInfoforEmployeeDesign = false;
            $scope.ngPersonalInfoforSupplier = false;// This Tab for Supplier No need for Buyer
            $scope.ngPersonalInfoforBuyer = true;
        }
        else if ($scope.UserType == 4) { // for Buyer Ref
            $scope.ACTypeID = 7;
            $scope.ActivePersonalInfo = "active";
            $scope.PanelTitle = 'New Buyer Ref';
            $scope.DataPanelTitle = 'Existing Buyer Ref';
            $scope.ngComPerMission = false;
            $scope.ngJobContract = false;
            $scope.ngAccountInfo = false;
            $scope.ngPermanentAddress = false;
            $scope.ngLedger = false;
            $scope.ngPersonalInfoforEmployeeDesign = false;
            $scope.ngPersonalInfoforSupplier = false;// This Tab for Supplier No need for Buyer Reff
            $scope.ngPersonalInfoforBuyer = false;// This Tab for Buyer No need for Buyer Reff
            $scope.ngPersonalInfoforBuyerReff = true;
        }
        else if ($scope.UserType == 5) { // for Party Contact Person
            LoadUserByTypeID(2); // Party=Buyer is 2
            $scope.ACTypeID = 5;
            $scope.ActivePersonalInfo = "active";
            $scope.PanelTitle = 'Party Contact Person';
            $scope.DataPanelTitle = 'Existing Party Contact Person';
            $scope.ngComPerMission = false;
            $scope.ngJobContract = false;
            $scope.ngAccountInfo = false;
            $scope.ngPermanentAddress = false;
            $scope.ngLedger = false;
            $scope.ngPersonalInfoforEmployeeDesign = false;
            $scope.ngPersonalInfoforSupplier = false;// This Tab for Supplier No need for Buyer Reff
            $scope.ngPersonalInfoforBuyer = false;// This Tab for Buyer No need for Buyer Reff
            $scope.ngPersonalInfoforBuyerReff = false; // This Tab for Byer Reff No need for 
            $scope.ngPersonalInfoforPartyContactPersonDesign = true;

        }
        else if ($scope.UserType == 6) // for Supplier Contact Person
        {
            LoadUserByTypeID(3); // Supplier is 3
            $scope.ACTypeID = 6;
            $scope.ActivePersonalInfo = "active";
            $scope.PanelTitle = 'Supplier Contact Person';
            $scope.DataPanelTitle = 'Existing Supplier Contact Person';
            $scope.ngComPerMission = false;
            $scope.ngJobContract = false;
            $scope.ngAccountInfo = false;
            $scope.ngPermanentAddress = false;
            $scope.ngLedger = false;
            $scope.ngPersonalInfoforEmployeeDesign = false;
            $scope.ngPersonalInfoforSupplier = false;// This Tab for Supplier No need for Buyer Reff
            $scope.ngPersonalInfoforBuyer = false;// This Tab for Buyer No need for Buyer Reff
            $scope.ngPersonalInfoforBuyerReff = false; // This Tab for Byer Reff No need for 
            $scope.ngPersonalInfoforPartyContactPersonDesign = false; // This Tab For Supplier Contact Person
            $scope.ngPersonalInfoforSupplierContactPersonDesign = true;
        }

    }
    $scope.TabManageByUserTyeID();


    ////////********************* Auto Complete suplier Name ************************///////////////

    $scope.AutoCompletesupplierName = function () {
        var UserType = "";
        var UserName = "";
        if ($scope.UserType == 1)
        {
            UserType = 1; // User
            UserName = $scope.FirstName
        }
        if ($scope.UserType == 3)
        {
            UserType = 3; // supplier
            UserName = $scope.supplierName;
        }
        if ($scope.UserType == 4)
        {
            UserType = 4; // Buyer
            UserName = $scope.buyerName;
        }
           
        $scope.result = [];
        objcmnParam = {
            loggedCompany: 0,
            TableName: 'CmnUser',
            FieldNameOne: 'UserFullName',
            FieldNameTwo: 'UserTypeID',
            id: UserType,
            InputString: '%' + UserName.split(' ').join('') + '%'
        };

        if (UserType != "")
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
        var apiRoute = '/SystemCommon/api/SystemCommonDDL/AutoComplete/';
        var Value = crudService.GetList(apiRoute, cmnParam);
        Value.then(function (response) {
            $scope.result = response.data.ObjParameters;
        },
        function (error) {
            console.log("Error: " + error);
        });

    }

    //Grid-2
    //Pagination
    $scope.paginationItemPop = {
        paginationPageSizesItemPop: [15, 25, 50, 75, 100, 500, 1000, "All"],
        ddlpageSizeItemPop: 15,
        pageNumber: 1,
        pageSize: 15,
        totalItemsPop: 0,

        getTotalPagesItemPop: function () {
            return Math.ceil(this.totalItemsPop / this.ddlpageSizeItemPop);
        },
        

        pageSizeChangeItemPop: function () {
            if (this.ddlpageSizeItemPop == "All") {
                this.pageNumber = 1
                this.pageSize = 0
                this.pageSize = $scope.paginationItemPop.totalItemsPop;
                loadItemPop_Records(1);
            }
            else {
                this.pageSize = this.ddlpageSizeItemPop
                this.pageNumber = 1
                loadItemPop_Records(1);
            }


        },
        firstPageItemPop: function () {
            if (this.pageNumber > 1) {
                this.pageNumber = 1
                loadItemPop_Records(1);
            }
        },
        nextPageItemPop: function () {
            if (this.pageNumber < this.getTotalPagesItemPop()) {
                this.pageNumber++;
                loadItemPop_Records(1);
            }
        },
        previousPageItemPop: function () {
            if (this.pageNumber > 1) {
                this.pageNumber--;
                loadItemPop_Records(1);
            }
        },
        lastPageItemPop: function () {
            if (this.pageNumber >= 1) {
                this.pageNumber = this.getTotalPagesItemPop();
                loadItemPop_Records(1);
            }
        }
    };

    //**********----Get All Record----***************
    function loadItemPop_Records(isPaging) {

        // For Loading   
        $scope.loaderMore = true;
        $scope.lblMessageItemPop = 'loading please wait....!';
        $scope.resultItemPop = "color-red";



        //Ui Grid
        objcmnParamItemPop = {
            pageNumber: $scope.paginationItemPop.pageNumber,
            pageSize: $scope.paginationItemPop.pageSize,
            IsPaging: isPaging,
            loggeduser: LUserID,
            loggedCompany: LCompanyID,
            menuId: 5

        };

        $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
            if (col.filters[0].term) {
                return 'header-filtered';
            } else {
                return '';
            }
        };

        $scope.gridOptionsItemPop = {
            columnDefs: [
                { name: "Id", displayName: "Id", visible: false, headerCellClass: $scope.highlightFilteredHeader },
                { name: "ACode", displayName: "ACode", width: "20%", headerCellClass: $scope.highlightFilteredHeader },
                { name: "ACName", displayName: "AC Name", headerCellClass: $scope.highlightFilteredHeader },
                {
                    name: 'Action',
                    displayName: "Action",
                    width: '7%',
                    enableColumnResizing: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: $scope.highlightFilteredHeader,
                    cellTemplate: '<span class="label label-success label-mini" style="text-align:center !important;">' +
                                 '<a href="" title="Add" ng-click="grid.appScope.GetLedgerByID(row.entity)">' +
                                   '<i class="icon-check" aria-hidden="true"></i> Add' +
                                 '</a>' +
                                 '</span>'
                }
            ],

            enableFiltering: true,
            enableGridMenu: true,
            enableSelectAll: true,
            exporterCsvFilename: 'Item.csv',
            exporterPdfDefaultStyle: { fontSize: 9 },
            exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
            exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
            exporterPdfHeader: { text: "Item", style: 'headerStyle' },
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

        var apiRoute = '/SystemCommon/api/ItemGroup/GetLedgerDetail/';
        var cmnParam = "[" + JSON.stringify(objcmnParamItemPop) + "]";
        var LedgerList = crudService.GetList(apiRoute, cmnParam);
        LedgerList.then(function (response) {
            $scope.paginationItemPop.totalItemsPop = response.data.recordsTotal;
            $scope.gridOptionsItemPop.data = response.data.objLedger;
            $scope.loaderMore = false;
        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    loadItemPop_Records(0);



    $scope.GetLedgerByID = function (dataModel) {

        $scope.ngmLedger = dataModel.Id;
        $("#ddlLedger").select2("data", { id: dataModel.Id, text: dataModel.ACName });
        Command: toastr["info"]("Ledger Successfully Added.");
        $("#HDOMasterModal").fadeOut(200, function () {
            $('#HDOMasterModal').modal('hide');
        });
    }


    //**********----Get All Record----***************
    $scope.listUserTitle = [
        { TitleId: 1, Title: 'Mr.' },
        { TitleId: 2, Title: 'Mrs.' }
    ];

    $scope.listUserGender = [
        { GenderId: 1, Gender: 'Male' },
        { GenderId: 2, Gender: 'Female' },
        { GenderId: 3, Gender: 'Others' }
    ];

    $scope.listUserReligion = [
         { ReligionId: 1, Religion: 'Islam' },
         { ReligionId: 2, Religion: 'Christianity' },
         { ReligionId: 3, Religion: 'Hinduism' },
         { ReligionId: 4, Religion: 'Buddhism' },
         { ReligionId: 5, Religion: 'Others' }
    ];

    $scope.listBloodGroup = [
       { BloodGroupID: 1, BloodGroup: 'A+ (A-Positive)' },
       { BloodGroupID: 2, BloodGroup: 'O+ (O-Positive)' },
       { BloodGroupID: 3, BloodGroup: 'B+ (B-Positive)' },
       { BloodGroupID: 4, BloodGroup: 'AB+ (AB-Positive)' },
       { BloodGroupID: 5, BloodGroup: 'A- (A-Negative)' },
       { BloodGroupID: 6, BloodGroup: 'O- (O-Negative)' },
       { BloodGroupID: 7, BloodGroup: 'B- (B-Negative)' },
       { BloodGroupID: 8, BloodGroup: 'AB- (AB-Negative)' }
    ];

    $scope.listJobContractType = [
        { JobContractTypeID: 1, JobContractType: 'Permanent' },
        { JobContractTypeID: 2, JobContractType: 'Probational' },
        { JobContractTypeID: 3, JobContractType: 'Contractual' },
        { JobContractTypeID: 4, JobContractType: 'Others' }
    ];

    $scope.listCountry = [];
    $scope.listState = [];
    $scope.listCity = [];
    $scope.listDesignation = [];
    $scope.listDepartment = [];

    $scope.Duplicate = function () {
        if ($scope.IsDuplicate) {
            $scope.Address2 = $scope.Address1;
        }
    };
    $scope.Duplicate1 = function () {
        if ($scope.IsDuplicate1) {
            $scope.Address2_2 = $scope.Address1_1;
        }
    };
    //else {
    //    $scope.Address1 = angular.copy($scope.Address2);
    //}


    function loadLedger(isPaging) {

        objcmnParam = {
            pageNumber: page,
            pageSize: pageSize,
            IsPaging: isPaging,
            loggeduser: LUserID,
            loggedCompany: LCompanyID,
            menuId: 5,
            tTypeId: 25
        };

        var apiRoute = '/SystemCommon/api/ItemGroup/GetLedger/';
        var acc1Id = 1;
        var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(acc1Id) + "]";
        var LedgerList = crudService.GetList(apiRoute, cmnParam);
        LedgerList.then(function (response) {
            $scope.LedgerList = response.data;

        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    loadLedger(0);


    //**********----Get All Record----***************
    function LoadUserByTypeID(TypeID) {
        var apiRoute = '/SystemCommon/api/SystemCommonDDL/LoadUserByTypeID/' + LCompanyID + '/' + LUserID + '/' + TypeID + '/';
        var typeWiseUser = crudService.getAll(apiRoute, page, pageSize, isPaging);
        typeWiseUser.then(function (response) {
            $scope.typeWiseUsers = response.data
        },
        function (error) {
            console.log("Error: " + error);
        });
    }



    function loadRecords_designation(isPaging) {
        var apiRoute = '/SystemCommon/api/SystemCommonDDL/GetDesignation/' + LCompanyID + '/' + LUserID + '/';
        var ddlCountry = crudService.getAll(apiRoute, page, pageSize, isPaging);
        ddlCountry.then(function (response) {
            $scope.listDesignation = response.data
        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    loadRecords_designation(0);

    //**********----Get All Record----***************
    function loadRecords_department(isPaging) {
        var apiRoute = '/SystemCommon/api/SystemCommonDDL/GetDepartment/' + LCompanyID + '/' + LUserID + '/';
        var ddlCountry = crudService.getAll(apiRoute, page, pageSize, isPaging);
        ddlCountry.then(function (response) {
            $scope.listDepartment = response.data
        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    loadRecords_department(0);

    //**********----Get All Record----***************
    function loadRecords_countryforPresent(isPaging) {
        debugger;
        var apiRoute = '/SystemCommon/api/SystemCommonDDL/GetCountry/' + LCompanyID + '/' + LUserID + '/';
        var ddlCountry = crudService.getAll(apiRoute, page, pageSize, isPaging);
        ddlCountry.then(function (response) {
            debugger;
            $scope.listCountryforpresentAddress = response.data;

            $scope.ddlCountry = response.data[17].CountryID;
            $("#userCountry").select2("data", { id: response.data[17].CountryID, text: response.data[17].CountryName });

            $scope.loadRecords_stateforPresentAddress(0);
        },
        function (error) {
            console.warn("Error: " + error);
        });
    }
    loadRecords_countryforPresent(0);

    //**********----Get All Record----***************
    $scope.loadRecords_stateforPresentAddress = function (isPaging) {

        var countryId = $scope.ddlCountry;
        var apiRoute = '/SystemCommon/api/SystemCommonDDL/GetState/' + countryId + '/' + LCompanyID + '/' + LUserID + '/';
        var ddlStates = crudService.getAll(apiRoute, page, pageSize, isPaging);
        ddlStates.then(function (response) {
            $scope.listStateforPresent = response.data
            debugger;
            //$scope.ddlState = response.data[0].StateID;
            //$("#userState").select2("data", { id: response.data[0].StateID, text: response.data[0].StateName });

            //$scope.ddlState1 = response.data[0].StateID;
            //$("#userState1").select2("data", { id: response.data[0].StateID, text: response.data[0].StateName });

            //$scope.loadRecords_cityforPresentAddress(0);
        },
        function (error) {
            console.warn("Error: " + error);
        });
    }

    //**********----Get All Record----***************
    $scope.ngchloadRecords_cityforPresentAddress = function (isPagin) {
        $scope.ddlCity = 0;
        $("#userCity").select2("val", '');
        $scope.loadRecords_cityforPresentAddress(0);
    }
    $scope.loadRecords_cityforPresentAddress = function (isPaging) {
        debugger;

        var stateId = $scope.ddlState;
        if (stateId != null || stateId!=0)
        {
           
            var apiRoute = '/SystemCommon/api/SystemCommonDDL/GetCity/' + stateId + '/' + LCompanyID + '/' + LUserID + '/';
            var ddlCities = crudService.getAll(apiRoute, page, pageSize, isPaging);
            ddlCities.then(function (response) {
                debugger;
                $scope.listCityforpresentAddress = response.data;

                //$scope.ddlCity = response.data[0].CityID;
                //$("#userCity").select2("data", { id: response.data[0].CityID, text: response.data[0].CityName });

                //$scope.ddlCity1 = response.data[0].CityID;
                //$("#userCity1").select2("data", { id: response.data[0].CityID, text: response.data[0].CityName });
            },
            function (error) {
                console.warn("Error: " + error);
            });
        }
    }

    function loadRecords_countryforPermanent(isPaging) {
        debugger;
        var apiRoute = '/SystemCommon/api/SystemCommonDDL/GetCountry/' + LCompanyID + '/' + LUserID + '/';
        var ddlCountry = crudService.getAll(apiRoute, page, pageSize, isPaging);
        ddlCountry.then(function (response) {
            debugger;
            $scope.listCountryforpermanent = response.data;

            $scope.ddlCountry1 = response.data[17].CountryID;
            $("#userCountry1").select2("data", { id: response.data[17].CountryID, text: response.data[17].CountryName });

            $scope.loadRecords_stateforPermanentAddress(0);
        },
        function (error) {
            console.warn("Error: " + error);
        });
    }
    loadRecords_countryforPermanent(0);

    $scope.loadRecords_stateforPermanentAddress = function (isPaging) {

        debugger;
        var countryId1 = $scope.ddlCountry1;
        var apiRoute = '/SystemCommon/api/SystemCommonDDL/GetState/' + countryId1 + '/' + LCompanyID + '/' + LUserID + '/';
        var ddlStates = crudService.getAll(apiRoute, page, pageSize, isPaging);
        ddlStates.then(function (response) {
            $scope.listStateforPermanentAddress = response.data

            //$scope.ddlState = response.data[0].StateID;
            //$("#userState").select2("data", { id: response.data[0].StateID, text: response.data[0].StateName });

            //$scope.ddlState1 = response.data[0].StateID;
            //$("#userState1").select2("data", { id: response.data[0].StateID, text: response.data[0].StateName });

            //   $scope.loadRecords_cityforPermanentAddress(0);
        },
        function (error) {
            console.warn("Error: " + error);
        });
    }
    $scope.ngchloadRecords_cityforPermanentAddress = function (isPaging) {
        $scope.ddlCity1 = 0;
        $("#userCity1").select2("val", '');
        $scope.loadRecords_cityforPermanentAddress(0);
    }
    $scope.loadRecords_cityforPermanentAddress = function (isPaging) {

        debugger
        var stateId = $scope.ddlState1;
        if (stateId != null || stateId != 0) {
            var apiRoute = '/SystemCommon/api/SystemCommonDDL/GetCity/' + stateId + '/' + LCompanyID + '/' + LUserID + '/';
            var ddlCities = crudService.getAll(apiRoute, page, pageSize, isPaging);
            ddlCities.then(function (response) {
                $scope.listCityforpremanentAddress = response.data

                //$scope.ddlCity = response.data[0].CityID;
                //$("#userCity").select2("data", { id: response.data[0].CityID, text: response.data[0].CityName });

                //$scope.ddlCity1 = response.data[0].CityID;
                //$("#userCity1").select2("data", { id: response.data[0].CityID, text: response.data[0].CityName });
            },
            function (error) {
                console.warn("Error: " + error);
            });
        }
    }


    //**********----Get All Record----***************
    function loadRecords_grp(isPaging) {
        var apiRoute = '/SystemCommon/api/User/GetUserGroupddl/' + LCompanyID + '/' + LUserID + '/' + $scope.UserType + '/';
        var ddlUserGroup = crudService.getAll(apiRoute, page, pageSize, isPaging);
        ddlUserGroup.then(function (response) {
            $scope.ListUserGroup = response.data
        },
        function (error) {
            console.warn("Error: " + error);
        });
    }
    loadRecords_grp(0);

    //**********----Get All Record----***************
    function loadRecords_typ(isPaging) {
        var apiRoute = '/SystemCommon/api/User/GetUserTypeddl/' + LCompanyID + '/' + LUserID + '/';
        var ddlUserType = crudService.getAll(apiRoute, page, pageSize, isPaging);
        ddlUserType.then(function (response) {
            $scope.ListUserType = response.data;
        },
        function (error) {
            console.warn("Error: " + error);
        });
    }
    //loadRecords_typ(0);

    //Pagination
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
            $scope.loadRecordsUser(1);
        },
        firstPage: function () {
            if (this.pageNumber > 1) {
                this.pageNumber = 1
                $scope.loadRecordsUser(1);
            }
        },
        nextPage: function () {
            if (this.pageNumber < this.getTotalPages()) {
                this.pageNumber++;
                $scope.loadRecordsUser(1);
            }
        },
        previousPage: function () {
            if (this.pageNumber > 1) {
                this.pageNumber--;
                $scope.loadRecordsUser(1);
            }
        },
        lastPage: function () {
            if (this.pageNumber >= 1) {
                this.pageNumber = this.getTotalPages();
                $scope.loadRecordsUser(1);
            }
        }
    };

    //**********----Get All Record----***************
    $scope.loadRecordsUser = function (isPaging) {

        // For Loading
        $scope.loaderMore = true;
        $scope.lblMessage = 'loading please wait....!';
        $scope.result = "color-red";

        //Ui Grid
        objcmnParam = {
            pageNumber: $scope.pagination.pageNumber,
            pageSize: $scope.pagination.pageSize,
            IsPaging: isPaging,
            loggeduser: LUserID,
            loggedCompany: LCompanyID,
            menuId: 5,
            tTypeId: 25,
            UserType: $scope.UserType,
            ACTypeID: $scope.ACTypeID
        };

        $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
            if (col.filters[0].term) {
                return 'header-filtered';
            } else {
                return '';
            }
        };

        $scope.gridOptionsUsers = {
            columnDefs: [
                { name: "UserID", displayName: "User ID", width: '7%', headerCellClass: $scope.highlightFilteredHeader },
                { name: "CustomCode", displayName: "CustomCode", headerCellClass: $scope.highlightFilteredHeader },
                { name: "UserFullName", displayName: "Full Name", headerCellClass: $scope.highlightFilteredHeader },
                { name: "Designation", title: "Designation", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                { name: "Department", title: "Department", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                { name: "UserType", title: "User Type", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                { name: "GroupName", title: "Group", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                { name: "MobileNo", title: "Mobile", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                { name: "ACName", title: "Ledger", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                   { name: "SupplierName", displayName: "Supplier", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                  { name: "PartyName", displayName: "Party", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                 { name: "PresentFullAddress", displayName: "Present Address", title: "Present Address", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                {
                    name: 'Edit',
                    displayName: "Edit",
                    width: '7%',
                    enableColumnResizing: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: $scope.highlightFilteredHeader,
                    cellTemplate: '<span class="label label-warning label-mini">' +
                                        '<a ng-href="#userModal" data-toggle="modal" class="bs-tooltip" title="Edit Info">' +
                                            '<i class="icon-pencil" ng-click="grid.appScope.getUser(row.entity)"></i>' +
                                        '</a>' +
                                    '</span>' +
                                    '<span class="label label-danger label-mini">' +
                                        '<a href="javascript:void(0);" class="bs-tooltip" title="Delete" ng-click="grid.appScope.delete(row.entity)">' +
                                            '<i class="icon-trash"></i>' +
                                        '</a>' +
                                    '</span>'
                }

            ]
            ,

            enableFiltering: true,
            enableGridMenu: true,
            enableSelectAll: true,
            exporterCsvFilename: 'Users.csv',
            exporterPdfDefaultStyle: { fontSize: 9 },
            exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
            exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
            exporterPdfHeader: { text: "User", style: 'headerStyle' },
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

        var apiRoute = '/SystemCommon/api/User/GetUser/';
        var listAllUser = crudService.getAllUsers(apiRoute, objcmnParam);
        listAllUser.then(function (response) {
            $scope.pagination.totalItems = response.data.recordsTotal;
            $scope.gridOptionsUsers.data = response.data.listUsers;
            $scope.loaderMore = false;
            //$scope.listUser = response.data
            $scope.ManageValidation();
        },
        function (error) {
            console.log("Error: " + error);
        });
    };
    $scope.loadRecordsUser(0);
    //----------Start Manage Validation and Grid Hide Show--------------------------
    $scope.ManageValidation = function () {
        if ($scope.UserType == 1) { // For User
            debugger;
            $scope.IsLoginIDRequired = false;
            $scope.IsRequiredFirstName = true;
            $scope.IsJCDepartmentRequired = true;
            $scope.IsDefultCompanyRequired = true;
            $scope.IsJCDesignationRequired = true;
            $scope.gridOptionsUsers.columnDefs[0].visible = false;
            $scope.gridOptionsUsers.columnDefs[1].visible = false;
            $scope.gridOptionsUsers.columnDefs[7].visible = false;
            $scope.gridOptionsUsers.columnDefs[8].visible = false;
            $scope.gridOptionsUsers.columnDefs[9].visible = false;
            $scope.gridOptionsUsers.columnDefs[10].visible = false;
            $scope.Star = '*';
        } else if ($scope.UserType == 2) { // for Buyer
            $scope.IsRequired1 = false;
            $scope.IsRequiredBuyerName = true;
            $scope.Star = '*';
            $scope.gridOptionsUsers.columnDefs[0].visible = false;
            $scope.gridOptionsUsers.columnDefs[1].visible = false;
            $scope.gridOptionsUsers.columnDefs[3].visible = false;
            $scope.gridOptionsUsers.columnDefs[4].visible = false;
            $scope.gridOptionsUsers.columnDefs[5].visible = false;
            $scope.gridOptionsUsers.columnDefs[6].visible = false;
            $scope.gridOptionsUsers.columnDefs[9].visible = false;
            $scope.gridOptionsUsers.columnDefs[10].visible = false;


        } else if ($scope.UserType == 3) { // for Supplier
            $scope.IsRequiredSupplierName = true;
            $scope.gridOptionsUsers.columnDefs[0].visible = false;
            $scope.gridOptionsUsers.columnDefs[1].visible = false;
            $scope.gridOptionsUsers.columnDefs[3].visible = false;
            $scope.gridOptionsUsers.columnDefs[4].visible = false;
            $scope.gridOptionsUsers.columnDefs[5].visible = false;
            $scope.gridOptionsUsers.columnDefs[6].visible = false;
            $scope.gridOptionsUsers.columnDefs[9].visible = false;
            $scope.gridOptionsUsers.columnDefs[10].visible = false;
            $scope.Star = '*';

        } else if ($scope.UserType == 4) { // for Buyer Ref
            $scope.IsRequiredBuyerRegName = true;
            $scope.gridOptionsUsers.columnDefs[0].visible = false;
            $scope.gridOptionsUsers.columnDefs[1].visible = false;
            $scope.gridOptionsUsers.columnDefs[3].visible = false;
            $scope.gridOptionsUsers.columnDefs[4].visible = false;
            $scope.gridOptionsUsers.columnDefs[5].visible = false;
            $scope.gridOptionsUsers.columnDefs[6].visible = false;
            $scope.gridOptionsUsers.columnDefs[8].visible = false;
            $scope.gridOptionsUsers.columnDefs[9].visible = false;
            $scope.gridOptionsUsers.columnDefs[10].visible = false;
            $scope.Star = '*';

        } else if ($scope.UserType == 5) { // for Party Contact Person
            $scope.IsRequiredddParty = true;
            $scope.IsRequiredPartyContactPersonName = true;
            $scope.gridOptionsUsers.columnDefs[0].visible = false;
            $scope.gridOptionsUsers.columnDefs[1].visible = false;
            $scope.gridOptionsUsers.columnDefs[3].visible = false;
            $scope.gridOptionsUsers.columnDefs[4].visible = false;
            $scope.gridOptionsUsers.columnDefs[5].visible = false;
            $scope.gridOptionsUsers.columnDefs[6].visible = false;
            $scope.gridOptionsUsers.columnDefs[8].visible = false;
            $scope.gridOptionsUsers.columnDefs[9].visible = false;

        } else if ($scope.UserType == 6) { // for Supplier Contact Person
            $scope.IsRequiredSupplierContactPerson = true
            $scope.IsRequiredddSupplier = true;
            $scope.gridOptionsUsers.columnDefs[0].visible = false;
            $scope.gridOptionsUsers.columnDefs[1].visible = false;
            $scope.gridOptionsUsers.columnDefs[3].visible = false;
            $scope.gridOptionsUsers.columnDefs[4].visible = false;
            $scope.gridOptionsUsers.columnDefs[5].visible = false;
            $scope.gridOptionsUsers.columnDefs[6].visible = false;
            $scope.gridOptionsUsers.columnDefs[8].visible = false;
            $scope.gridOptionsUsers.columnDefs[10].visible = false;
            $scope.Star = '*';

        }
    }
    $scope.ManageValidation();
    //----------Start Manage Validation and Grid Hide Show--------------------------

    //File Upload
    $scope.selectFileAvatar = function (element) {
        debugger
        if (element.files[0] == undefined) return;
        for (var i = 0; i < element.files.length; i++) {
            $scope.SelectedFileAvatar.push(element.files[i])
        }

        var formData = new FormData();
        //formData.append("file", $scope.SelectedFileFinger[0]);
        for (var i in $scope.SelectedFileAvatar) {
            formData.append("uploadedFile", $scope.SelectedFileAvatar[i]);
        }

        var defer = $q.defer();
        $http.post("/SystemCommon/api/User/UploadAvatar/", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (response) {
            debugger
            $scope.avatarname = response

            //Preview Image
            var reader = new FileReader();
            reader.onload = function (event) {
                debugger
                $scope.avatar_source = event.target.result;
                $scope.$apply();
                document.getElementById("fileAvatar").disabled = true;
            }
            // when the file is read it triggers the onload event above.
            reader.readAsDataURL(element.files[0]);
            //defer.resolve(response)
        })
        .error(function () {
            defer.reject("File Upload Failed!");
        });
        //console.log(defer.promise);
    }

    $scope.selectFileSignature = function (element) {

        if (element.files[0] == undefined) return;
        for (var i = 0; i < element.files.length; i++) {
            $scope.SelectedFileSignature.push(element.files[i])
        }

        var formData = new FormData();
        //formData.append("file", $scope.SelectedFileFinger[0]);
        for (var i in $scope.SelectedFileSignature) {
            formData.append("uploadedFile", $scope.SelectedFileSignature[i]);
        }

        var defer = $q.defer();
        $http.post("/SystemCommon/api/User/UploadSignature/", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (response) {
            $scope.signaturename = response

            //Preview Image
            var reader = new FileReader();
            reader.onload = function (event) {
                $scope.signature_source = event.target.result;
                $scope.$apply();
                document.getElementById("fileSignature").disabled = true;
            }
            // when the file is read it triggers the onload event above.
            reader.readAsDataURL(element.files[0]);
            //defer.resolve(response)
        })
        .error(function () {
            defer.reject("File Upload Failed!");
        });
        //console.log(defer.promise);
    }
    $scope.selectFileFinger = function (element) {
        debugger
        if (element.files[0] == undefined) return;
        for (var i = 0; i < element.files.length; i++) {
            $scope.SelectedFileFinger.push(element.files[i])
        }

        var formData = new FormData();
        //formData.append("file", $scope.SelectedFileFinger[0]);
        for (var i in $scope.SelectedFileFinger) {
            formData.append("uploadedFile", $scope.SelectedFileFinger[i]);
        }

        var defer = $q.defer();
        $http.post("/SystemCommon/api/User/UploadFinger/", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (response) {
            debugger
            $scope.fingername = response

            //Preview Image
            var reader = new FileReader();
            reader.onload = function (event) {
                debugger
                $scope.Fingerprint_source = event.target.result;
                $scope.$apply();
                document.getElementById("fileFinger").disabled = true;
            }
            // when the file is read it triggers the onload event above.
            reader.readAsDataURL(element.files[0]);
            //defer.resolve(response)
        })
        .error(function () {
            defer.reject("File Upload Failed!");
        });
        //console.log(defer.promise);

    }
    $scope.clearFileAvatar = function () {
        if ($scope.avatarname != null) {
            var fileDetails = {
                ImageUrl: $scope.avatarname
            }
            var apiRoute = '/SystemCommon/api/User/DeleteAvatar/';
            var fileDelete = crudService.post(apiRoute, fileDetails);
            fileDelete.then(function (response) {
                $scope.avatar_source = '';
                $('#fileAvatar').val('');
                $scope.SelectedFileAvatar = [];
                $scope.avatarname = null;
                fileDetails = {};
                document.getElementById("fileAvatar").disabled = false;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
    }
    $scope.clearFileSignature = function () {
        if ($scope.signaturename != null) {
            var fileDetails = {
                SignatUrl: $scope.signaturename
            }
            var apiRoute = '/SystemCommon/api/User/DeleteSignature/';
            var fileDelete = crudService.post(apiRoute, fileDetails);
            fileDelete.then(function (response) {
                $scope.signature_source = '';
                $('#fileSignature').val('');
                $scope.SelectedFileSignature = [];
                $scope.signaturename = null;
                fileDetails = {};
                document.getElementById("fileSignature").disabled = false;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
    }
    $scope.clearFinger = function () {
        if ($scope.fingername != null) {
            var fileDetails = {
                FingerUrl: $scope.fingername
            }
            var apiRoute = '/SystemCommon/api/User/DeleteFinger/';
            var fileDelete = crudService.post(apiRoute, fileDetails);
            fileDelete.then(function (response) {
                $scope.Fingerprint_source = '';
                $('#fileFinger').val('');
                $scope.SelectedFileFinger = [];
                $scope.fingername = null;
                fileDetails = {};
                document.getElementById("fileFinger").disabled = false;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
    }
    //**********----Create New Record----***************
    $scope.save = function () {
        debugger
        if ($scope.IsOnlineAccount)
            OnlineAccount = 1;

        debugger
        if (($scope.DOB == "") || ($scope.DOB == null) || ($scope.DOB==undefined))
        {
            $scope.DOB = "1/1/1900";
        }
         
         
        User = {
            CompanyID: LCompanyID,
            LoggedUser: LUserID,
            UserID: $scope.EditUserID,
            ACTypeID: $scope.ACTypeID,

            //Login Account
            LoginID: $scope.LoginID,
            LoginEmail: $scope.Email,
            LoginPhone: '',
            Password: $scope.password == undefined ? '' : $scope.password,
            //User Type
            //UserTypeID: $scope.ddlUserType,
            UserTypeID: $scope.UserType == "" ? 0 : $scope.UserType,
            UserGroupID: $scope.ddlUserGroup == "" ? 0 : $scope.ddlUserGroup,
            UserTitleID: $scope.ddlUsertitle == "" ? 0 : $scope.ddlUsertitle,


            //User Info
            UserFirstName: $scope.FirstName,
            UserMiddleName: $scope.MiddleName,
            UserLastName: $scope.LastName,
            GenderID: $scope.ddlGender == "" ? 0 : $scope.ddlGender,
            ReligionID: $scope.ddlUserReligion == "" ? 0 : $scope.ddlUserReligion,

            FathersName: $scope.FatherName,
            MothersName: $scope.MotherName,
            SpouseNane: $scope.SpouseName,

            // Present Address
            //User Contact1
            ParAddress1: $scope.ParAddress1,
            ParAddress2: $scope.ParAddress2,
            ParCountryID: $scope.ddlCountry == "" ? 0 : $scope.ddlCountry,
            ParStateID: $scope.ddlState == "" ? 0 : $scope.ddlState,
            ParCityID: $scope.ddlCity == "" ? 0 : $scope.ddlCity,

            //Permanent Address
            //User Contact2 //Newly Added
            PreAddress1: $scope.PreAddress1,
            PreAddress2: $scope.PreAddress2,
            PreCountryID: $scope.ddlCountry1 == "" ? 0 : $scope.ddlCountry1,
            PreStateID: $scope.ddlState1 == "" ? 0 : $scope.ddlState1,
            PreCityID: $scope.ddlCity1 == "" ? 0 : $scope.ddlCity1,

            //User Identity
            UniqueIdentity: '',
            //BloodGroup: $scope.ddlBloodGroup.BloodGroupID,
            BloodGroup: $scope.ddlBloodGroup == "" ? 0 : $scope.ddlBloodGroup,

            Height: $scope.Height == "" ? 0.0 : $scope.Height,
            DOB: $scope.DOB == "1/1/1900" ? "1/1/1900" : conversion.getStringToDate($scope.DOB),
            PassportNO: $scope.PassportNo,
            NID: $scope.NationalID,
            MobileNo: $scope.emMobile,
            OfficeID: $scope.IDCard,
            ImageUrl: $scope.avatarname,
            FingerUrl: $scope.fingername,
            SignatUrl: $scope.signaturename,

            //User Job Contract
            DesignationID: $scope.ddlDesignation == "" ? 0 : $scope.ddlDesignation,
            DepartmentID: $scope.ddlDepartment == "" ? 0 : $scope.ddlDepartment,
            JobContractTypeID: $scope.ddlContractType == "" ? 0 : $scope.ddlContractType,
            UserParentID: $scope.ddlSupplier == "" ? 0 : $scope.ddlSupplier,

            // Ledger
            AcDetailID: $scope.ngmLedger == "" ? 0 : $scope.ngmLedger,

            //Open User Login Account
            IsOnlineAccount: OnlineAccount
        };
        if ($scope.UserType == 1) {
            if (User.UserParentID != 0) {
                User.UserParentID = $scope.ddlSupplier == undefined ? 0 : $scope.ddlSupplier;
            }
        }
        else if ($scope.UserType == 3) { // For supplier
            if (User.DesignationID != 0) {
                User.DesignationID = $scope.ddlDesignation == undefined ? 0 : $scope.ddlDesignation;
            }
            if (User.DepartmentID != 0) {
                User.DepartmentID = $scope.ddlDepartment == undefined ? 0 : $scope.ddlDepartment;
            }
            if (User.JobContractTypeID != 0) {
                User.JobContractTypeID = $scope.ddlContractType == undefined ? 0 : $scope.ddlContractType;
            }
            if (User.UserParentID != 0) {
                User.UserParentID = $scope.ddlSupplier == undefined ? 0 : $scope.ddlSupplier;
            }
            User.MobileNo = $scope.supplierMobile;
            User.UserFirstName = $scope.supplierName;
        }
        else if ($scope.UserType == 2) // For Buyer
        {
            if (User.DesignationID != 0) {
                User.DesignationID = $scope.ddlDesignation == undefined ? 0 : $scope.ddlDesignation;
            }
            if (User.DepartmentID != 0) {
                User.DepartmentID = $scope.ddlDepartment == undefined ? 0 : $scope.ddlDepartment;
            }
            if (User.JobContractTypeID != 0) {
                User.JobContractTypeID = $scope.ddlContractType == undefined ? 0 : $scope.ddlContractType;
            }
            if (User.UserParentID != 0) {
                User.UserParentID = $scope.ddlSupplier == undefined ? 0 : $scope.ddlSupplier;
            }
            User.MobileNo = $scope.buyerMobile;
            User.UserFirstName = $scope.buyerName;
        }
        else if ($scope.UserType == 4) // For Buyer Ref
        {
            if (User.DesignationID != 0) {
                User.DesignationID = $scope.ddlDesignation == undefined ? 0 : $scope.ddlDesignation;
            }
            if (User.DepartmentID != 0) {
                User.DepartmentID = $scope.ddlDepartment == undefined ? 0 : $scope.ddlDepartment;
            }
            if (User.JobContractTypeID != 0) {
                User.JobContractTypeID = $scope.ddlContractType == undefined ? 0 : $scope.ddlContractType;
            }
            if (User.UserParentID != 0) {
                User.UserParentID = $scope.ddlSupplier == undefined ? 0 : $scope.ddlSupplier;
            }
            User.MobileNo = $scope.buyerReffMobile;
            User.UserFirstName = $scope.buyerReffName;
        }
        else if ($scope.UserType == 5) // For Party Contact Person
        {
            if (User.DesignationID != 0) {
                User.DesignationID = $scope.ddlDesignation == undefined ? 0 : $scope.ddlDesignation;
            }
            if (User.DepartmentID != 0) {
                User.DepartmentID = $scope.ddlDepartment == undefined ? 0 : $scope.ddlDepartment;
            }
            if (User.JobContractTypeID != 0) {
                User.JobContractTypeID = $scope.ddlContractType == undefined ? 0 : $scope.ddlContractType;
            }
            User.UserParentID = $scope.ddlParty == "" ? 0 : $scope.ddlParty;
        }
        else if ($scope.UserType == 6)// For Supplier Contact Person
        {
            if (User.DesignationID != 0) {
                User.DesignationID = $scope.ddlDesignation == undefined ? 0 : $scope.ddlDesignation;
            }
            if (User.DepartmentID != 0) {
                User.DepartmentID = $scope.ddlDepartment == undefined ? 0 : $scope.ddlDepartment;
            }
            if (User.JobContractTypeID != 0) {
                User.JobContractTypeID = $scope.ddlContractType == undefined ? 0 : $scope.ddlContractType;
            }
            User.UserParentID = $scope.ddlSupplier == "" ? 0 : $scope.ddlSupplier;
        }

        console.log(User);
        //-------Defult Company ------------

        $scope.defultCompanylist = [];
        debugger
        angular.forEach($scope.SelectCompnayList, function (item) {
            debugger;
            if (item.id == $scope.defultCompany) {
                $scope.defultCompanylist.push({
                    id: item.id,
                    IsDefult: true
                });
            } else {

                $scope.defultCompanylist.push({
                    id: item.id,
                    IsDefult: false
                });
            }
            debugger;
        })
        var PmCompany = $scope.defultCompanylist;


        debugger;
        var apiRoute = '/SystemCommon/api/User/SaveUser/';
        var UserCreate = crudService.postList(apiRoute, User, PmCompany);
        UserCreate.then(function (response) {
            if (response.data === 1) {
                Command: toastr["info"]("User Saved Successfully!!!!");
                modal_fadeOut();
                $scope.loadRecordsUser(0);
                $scope.clear();
            }
            else if (response.data === 0) {
                    Command: toastr["error"]("Error while Creating User!!!!");
            }
            else {
                Command: toastr["error"]("Error Undefined!!!!");
            }
        },
        function (error) {
            console.log("Error: " + error);
        });
    };

    //******=========Get Single Data=========******
    $scope.getUser = function (dataModel) {
        debugger;
        $scope.PanelTitle = 'Update User';
        $scope.EditUserID = dataModel.UserID;

        var apiRoute = '/SystemCommon/api/User/GetUserByID/' + dataModel.UserID + '/' + LCompanyID + '/' + LUserID + '/' + $scope.ACTypeID;
        var UserDetails = crudService.getByID(apiRoute);
        UserDetails.then(function (response) {
            if (response.data != null) {
                console.log(response.data);
                debugger
                $scope.ddlUserType = '';

                if ($scope.UserType == 3) {  // For Supplier
                    $scope.supplierMobile = response.data.MobileNo;
                    $scope.supplierName = response.data.UserFullName;
                }
                else if ($scope.UserType == 2) // For Buyer
                {
                    $scope.buyerName = response.data.UserFullName;
                    $scope.buyerMobile = response.data.MobileNo;
                }
                else if ($scope.UserType == 6) {
                    $scope.emMobile = response.data.MobileNo;
                }
                else if ($scope.UserType == 1) {// For user
                    debugger;
                    if (response.data.LoginID == 'Unknown') {
                        $scope.IsOnlineAccount = false;
                        $scope.CreateAccount();
                        $scope.LoginID = '';
                    } else {

                        $scope.IsOnlineAccount = true;
                        $scope.CreateAccount();
                        $scope.LoginID = response.data.LoginID;
                        $scope.password = response.data.ConfirmPassword;
                        $scope.emMobile = response.data.MobileNo;
                    }


                }
                else if ($scope.UserType == 4) { //for Buyer Ref
                    $scope.buyerReffMobile = response.data.MobileNo;
                    $scope.buyerReffName = response.data.UserFullName;
                }
                $scope.IDCard = response.data.OfficeID;
                $scope.ddlUserGroup = response.data.UserGroupID;
                $("#userGroup").select2("data", { id: response.data.UserGroupID, text: response.data.UserGroup });

                //$scope.LoginID = response.data.LoginID;
                $scope.Email = response.data.Email;
                //  $scope.Phone = response.data.LoginPhone;

                $scope.ddlUsertitle = response.data.UserTitleID;
                $("#userTitle").select2("data", { id: response.data.UserTitleID, text: response.data.UserTitle });

                $scope.FirstName = response.data.UserFirstName;
                $scope.MiddleName = response.data.UserMiddleName;
                $scope.LastName = response.data.UserLastName;

                $scope.ddlGender = response.data.GenderID;
                $("#userGender").select2("data", { id: response.data.GenderID, text: response.data.Gender });

                $scope.ddlUserReligion = response.data.ReligionID;
                $("#userReligion").select2("data", { id: response.data.GenderID, text: response.data.Religion });

                //$scope.DOB = response.data.DOB;
                if (response.data.DOB != null) {
                    $scope.DOB = conversion.getDateToString(response.data.DOB);
                }

                $scope.FatherName = response.data.FathersName;
                $scope.MotherName = response.data.MothersName;
                $scope.SpouseName = response.data.SpouseNane;
                $scope.Height = response.data.Height;

                $scope.ddlBloodGroup = response.data.BloodGroupID;
                $("#bloodGroup").select2("data", { id: response.data.BloodGroupID, text: response.data.BloodGroup });

                $scope.PassportNo = response.data.PassportNO;
                $scope.NationalID = response.data.NID;
                $scope.PreAddress1 = response.data.PreAddress1;
                $scope.PreAddress2 = response.data.PreAddress2;
                $scope.ParAddress1 = response.data.ParAddress1;
                $scope.ParAddress2 = response.data.ParAddress2;
                debugger;
                //--------------Present Address----------
                loadRecords_countryforPresent(0);
                $scope.ddlCountry = response.data.ParCountryID;
                $("#userCountry").select2("data", { id: response.data.ParCountryID, text: response.data.ParCountryName });

                $scope.loadRecords_stateforPresentAddress(0);
                $scope.ddlState = response.data.ParStateID;
                console.log(response.data.ParStateID);
                $("#userState").select2("data", { id: response.data.ParStateID, text: response.data.ParStateName });

                $scope.loadRecords_cityforPresentAddress(0);
                $scope.ddlCity = response.data.ParCityID;
                $("#userCity").select2("data", { id: response.data.ParCityID, text: response.data.ParCityName });

                //-------------Permanent Address-----------------------------
                debugger;
                loadRecords_countryforPermanent(0);
                $scope.ddlCountry1 = response.data.PreCountryID;
                $("#userCountry1").select2("data", { id: response.data.PreCountryID, text: response.data.PreCountryName });

                $scope.loadRecords_stateforPermanentAddress(0);
                $scope.ddlState1 = response.data.PreStateID;
                $("#userState1").select2("data", { id: response.data.PreStateID, text: response.data.PreStateName });

                $scope.loadRecords_cityforPermanentAddress(0);
                $scope.ddlCity1 = response.data.PreCityID;
                $("#userCity1").select2("data", { id: response.data.PreCityID, text: response.data.PreCityName });

                if ($scope.UserType == 5) { // for Party Contact Person
                    LoadUserByTypeID(2);
                    $scope.ddlParty = response.data.UserParentID;
                    $("#ddlparty").select2("data", { id: response.data.UserParentID, text: response.data.ParentName });
                }
                else if ($scope.UserType == 6) // for Supplier Contact Person
                {
                    LoadUserByTypeID(3);
                    $scope.ddlSupplier = response.data.UserParentID;
                    $("#ddlSupplier").select2("data", { id: response.data.UserParentID, text: response.data.ParentName });
                }
                debugger;

                // $scope.Zip = response.data.Zip;
                $scope.ddlDepartment = response.data.DepartmentID;
                if (response.data.ImageUrl == "../../Content/img/noavatar-male.png") {
                    document.getElementById("fileAvatar").disabled = false;
                    $scope.avatar_source = response.data.ImageUrl;
                    $scope.avatarname = null;

                } else {
                    document.getElementById("fileAvatar").disabled = true;
                    $scope.avatar_source = response.data.ImageUrl;
                    $scope.avatarname = response.data.ImageName;

                }
                if (response.data.SignatUrl == "../../Content/img/signature.png") {
                    document.getElementById("fileSignature").disabled = false;
                    $scope.signature_source = response.data.SignatUrl;
                    $scope.signaturename = null;
                } else {
                    document.getElementById("fileSignature").disabled = true;
                    $scope.signature_source = response.data.SignatUrl;
                    $scope.signaturename = response.data.SignatName;
                }


                $("#userdepartment").select2("data", { id: response.data.DepartmentID, text: response.data.Department });

                $scope.ddlContractType = response.data.JobContractTypeID;
                $("#userContractType").select2("data", { id: response.data.JobContractTypeID, text: response.data.JobContractType });

                $scope.ddlDesignation = response.data.DesignationID;
                $("#userDesignation").select2("data", { id: response.data.DesignationID, text: response.data.Designation });

                $scope.ngmLedger = response.data.AcDetailID;
                $("#ddlLedger").select2("data", { id: response.data.AcDetailID, text: response.data.ACName });


                //$scope.frmUser.$setPristine();
                //$scope.frmUser.$setUntouched();
                debugger;
                $scope.GetCompanyPermissionListByuserID($scope.EditUserID);
            }
            else { Command: toastr["error"]("Error while Loading!!!!"); }
        }, function (error) {
            console.log("Error: " + error);
        });
    };

    $scope.GetCompanyPermissionListByuserID = function (UserID) {
        debugger
        var apiRoute = '/SystemCommon/api/SystemCommonDDL/GetCompanyPermissionListByUserID/' + UserID;
        var company = crudService.getByID(apiRoute);
        company.then(function (response) {
            $scope.SelectCompnayList = response.data;
            $scope.selectedList = response.data;

            debugger;
            for (i = 0; i < $scope.selectedList.length; i++) {
                if ($scope.selectedList[i].IsDefult == true) {
                    $scope.defultCompany = $scope.selectedList[i].id;
                    $("#defultCompany").select2("data", { id: $scope.selectedList[i].id, text: $scope.selectedList[i].label });

                }
            }
        },
        function (error) {
            console.log("Error: " + error);
        });
    }

    //**********----Delete Single Record----***************
    $scope.delete = function (dataModel) {
        var IsConf = confirm('You are about to delete ' + dataModel.UserFullName + '. Are you sure?');
        if (IsConf) {
            var apiRoute = '/SystemCommon/api/User/DeleteUser/' + dataModel.UserID + '/' + LCompanyID + '/' + LUserID;
            var UserDelete = crudService.delete(apiRoute);
            UserDelete.then(function (response) {
                if (response.data === 1) { Command: toastr["info"]("User Deleted Successfully!!!!"); }
                else { Command: toastr["error"]("Error while Deleting!!!!"); }
                $scope.loadRecordsUser(0);
                $scope.ManageValidation();
            }, function (error) {
                console.log("Error: " + error);
            });
        }
    }
    $scope.GetCompanys = function () {
        var apiRoute = '/SystemCommon/api/SystemCommonDDL/GetCompanyForMutl/';
        var _company = crudService.getAll(apiRoute, page, pageSize, isPaging);
        _company.then(function (response) {
            $scope.SelectCompnayList = [];
            $scope.companylist = response.data;
            // $scope.ListMultiProcessModel = item;     
        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    $scope.GetCompanys();

    $scope.clear = function () {

        debugger;
        $scope.EditUserID = 0;
        $scope.frmUser.$setPristine();
        $scope.frmUser.$setUntouched();

        $scope.PanelTitle = 'New User';
        //--------Specific------------
        $scope.supplierName = "";
        $scope.supplierMobile = "";
        $scope.buyerName = "";
        $scope.buyerMobile = "";
        $scope.password = "";
        //-----------END-------------

        $scope.TabManageByUserTyeID();
        $scope.ManageValidation();
        $scope.UserGroupID = 0;
        $scope.GroupName = '';
        $scope.LoginID = '';
        $scope.FirstName = '';
        $scope.MiddleName = '';
        $scope.LastName = '';
        $scope.Email = '';
        $scope.Phone = '';
        $scope.FatherName = '';
        $scope.MotherName = '';
        $scope.SpouseName = '';
        $scope.Address1 = '';
        $scope.Address2 = '';
        $scope.Address1_1 = '';
        $scope.Address2_2 = '';
        $scope.Height = '';
        $scope.DOB = '';
        $scope.PassportNo = '';
        $scope.NationalID = '';
        $scope.IDCard = "";
        $scope.emMobile = "";

        //$("#userGender").select2("val", '');
        //$scope.ddlGender = 0;

        $scope.ddlGender = "";
        $('#userGender').select2("data", { id: '', text: '--Select Gender--' });

        //$("#userReligion").select2("val", '');
        //$scope.ddlUserReligion = 0;

        $scope.ddlUserReligion = "";
        $('#userReligion').select2("data", { id: '', text: '--Select Religion--' });

        //$("#userType").select2("val", '');
        //$scope.ddlUserType = 0;

        $scope.ddlUserType = "";
        $('#userType').select2("data", { id: '', text: '--Select Type--' });

        $scope.ddlUserGroup = "";
        $('#userGroup').select2("data", { id: '', text: '--Select Group--' });


        //$("#userGroup").select2("val", '');
        //$scope.ddlUserGroup = 0;


        $scope.ddlUsertitle = "";
        $('#userTitle').select2("data", { id: '', text: '--Select Title--' });

        //$("#userTitle").select2("val", '');
        //$scope.ddlUsertitle = 0;

        $scope.ddlBloodGroup = "";
        $('#bloodGroup').select2("data", { id: '', text: '--Select Blood Group--' });

        //$("#bloodGroup").select2("val", '');
        //$scope.ddlBloodGroup = 0;

        //$("#userState").select2("val", '');
        //$scope.ddlState = 0;

        //$("#userCity").select2("val", '');
        //$scope.ddlCity = 0;

        //$("#userdepartment").select2("val", '');
        //$scope.ddlDepartment = 0;

        $scope.ddlDepartment = "";
        $('#userdepartment').select2("data", { id: '', text: '--Select Department--' });

        $scope.ddlContractType = "";
        $('#userContractType').select2("data", { id: '', text: '--Select Type--' });

        //$("#userContractType").select2("val", '');
        //$scope.ddlContractType = 0;

        //$("#userDesignation").select2("val", '');
        //$scope.ddlDesignation = 0;

        $scope.ddlDesignation = "";
        $('#userDesignation').select2("data", { id: '', text: '--Select Designation--' });

        $scope.ngmLedger = "";
        $('#ddlLedger').select2("data", { id: '', text: '-- Select Ledger --' });

        //$("#ddlLedger").select2("val", '');
        //$scope.ngmLedger = 0;

        //$("#ddlparty").select2("val", '');
        //$scope.ddlParty = 0;
        $scope.ddlParty = "";
        $('#ddlparty').select2("data", { id: '', text: '--Select Party--' });

        $scope.ddlSupplier = "";
        $('#ddlSupplier').select2("data", { id: '', text: '--Select Supplier--' });

        //$("#ddlSupplier").select2("val", '');
        //$scope.ddlSupplier = 0;

        $scope.SelectCompnayList = [];
        $scope.signature_source = "../../Content/img/signature.png";
        $scope.avatar_source = "../../Content/img/noavatar-male.png";
        $scope.Fingerprint_source = "../../Content/img/Fingerprint.png";

        $scope.avatarname = null;
        $scope.signaturename = null;
        debugger;
        $scope.PreAddress1 = "";
        $scope.PreAddress2 = "";
        $scope.ParAddress1 = "";
        $scope.ParAddress2 = "";

        //------Present Address-------       

        $scope.loadRecords_stateforPresentAddress(0);

        $scope.ddlState = "";
        $('#userState').select2("data", { id: '', text: '-- Select State --' });

        //$scope.ddlState = 0;
        //$("#userState").select2("val", '');

        $scope.loadRecords_cityforPresentAddress(0);

        $scope.ddlCity = "";
        $('#userCity').select2("data", { id: '', text: '--Select City--' });

        //$scope.ddlCity = 0;
        //$("#userCity").select2("val", '');

        //-------Permanent Address------

        $scope.loadRecords_stateforPermanentAddress(0);

        $scope.ddlState1 = "";
        $('#userState1').select2("data", { id: '', text: '--Select State--' });

        //$scope.ddlState1 = 0;
        //$("#userState1").select2("val", '');

        $scope.loadRecords_cityforPermanentAddress(0);

        $scope.ddlCity1 = "";
        $('#userCity1').select2("data", { id: '', text: '--Select City--' });

        //$scope.ddlCity1 = 0;
        //$("#userCity1").select2("val", '');      

        $scope.defultCompany = "";
        $('#defultCompany').select2("data", { id: '', text: '--Select Company--' });
    };

    $scope.AddDefultCompany = function () {
        debugger;
        $scope.SelectCompnayList;
        $scope.companylist;
        $scope.selectedList = [];
        for (i = 0; i < $scope.companylist.length; i++) {
            var bl = false;
            for (j = 0; j < $scope.SelectCompnayList.length; j++) {
                if ($scope.companylist[i].id == $scope.SelectCompnayList[j].id) {
                    bl = true;
                }
            }

            if (bl) {
                obj = {
                    id: $scope.companylist[i].id,
                    label: $scope.companylist[i].label,
                }
                $scope.selectedList.push(obj);
            }
        }

    }

    $scope.SateBasicSetup = function () {
        $scope.ModalHeading = "State";
        $scope.labelName = "State"
        $scope.btnSave = "Save";
        $scope.placeHolder = "----State----"
        $("#modalStateCityModa").fadeIn(200, function () { $('#modalStateCityModa').modal('show'); });
    }

    $scope.CityBasicSetup = function () {
        $scope.ModalHeading = "City";
        $scope.labelName = "City"
        $scope.btnSave = "Save";
        $scope.placeHolder = "----City----"
        $("#modalStateCityModa").fadeIn(200, function () { $('#modalStateCityModa').modal('show'); });
    }

    $scope.LoadPermanentState = function () {
        $scope.CounteryID = $scope.ddlCountry1;
        $scope.Flag = "State";
        $scope.AddressType = "PermanentState"
        if ($scope.CounteryID == null || $scope.CounteryID == 0) {
            Command: toastr["error"]("Please Select Countery Name !!!!");

        } else {
            $scope.SateBasicSetup();
        }
    }
    $scope.LoadPermanentCity = function () {
        $scope.CounteryID = $scope.ddlCountry1;
        $scope.StateID = $scope.ddlState1;
        $scope.Flag = "City";
        $scope.AddressType = "PermanentCity";
        if ($scope.StateID == null || $scope.StateID == 0) {
            Command: toastr["error"]("Please Select State Name !!!!");
        } else {
            $scope.CityBasicSetup();
        }


    }
    $scope.LoadPresentState = function () {
        $scope.CounteryID = $scope.ddlCountry;
        $scope.Flag = "State";
        $scope.AddressType = "PresentState";
        if ($scope.CounteryID == null || $scope.CounteryID == 0) {
            Command: toastr["error"]("Please Select Countery Name !!!!");

        } else {
            $scope.SateBasicSetup();
        }
    }
    $scope.LoadPresentCity = function () {
        $scope.CounteryID = $scope.ddlCountry;
        $scope.StateID = $scope.ddlState;
        $scope.Flag = "City";
        $scope.AddressType = "PresentCity";
        if ($scope.StateID == null || $scope.StateID == 0) {
            Command: toastr["error"]("Please Select State Name !!!!");
        } else {
            $scope.CityBasicSetup();
        }
    }


    $scope.SaveStateCity = function () {
        if ($scope.Flag == "State") {
            State = {
                StateName: $scope.txtValue,
                CountryID: $scope.CounteryID,
                CreateBy: LUserID,
                CompanyID: LCompanyID
            };

            var apiRoute = '/SystemCommon/api/User/SaveState/';
            var StateCreate = crudService.post(apiRoute, State);
            StateCreate.then(function (response) {
                debugger;
                if (response.data != "") {
                    var res = response.data.split(",");
                    if ($scope.AddressType == "PermanentState") {
                        $scope.loadRecords_stateforPermanentAddress(0);
                        $scope.ddlState1 = res[1];
                        $("#userState1").select2("data", { id: res[1], text: res[0] });
                    }
                    else if ($scope.AddressType == "PresentState") {
                        $scope.loadRecords_stateforPresentAddress(0);
                        $scope.ddlState = res[1];
                        $("#userState").select2("data", { id: res[1], text: res[0] });
                    }
                    $scope.AddresStateCityClear();
                    Command: toastr["info"]("Data Saved Successfully!!!!");
                    $("#modalStateCityModa").fadeIn(200, function () { $('#modalStateCityModa').modal('hide'); });
                }
                else if (response.data === 0) {
                        Command: toastr["error"]("Error while Creating User!!!!");
                }
                else {
                    Command: toastr["error"]("Error Undefined!!!!");
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        else {
            city = {
                CityName: $scope.txtValue,
                StateID: $scope.StateID,
                CountryID: $scope.CounteryID,
                CreateBy: LUserID,
                CompanyID: LCompanyID
            };
            var apiRoute = '/SystemCommon/api/User/SaveCity/';
            var StateCreate = crudService.post(apiRoute, city);
            StateCreate.then(function (response) {
                if (response.data != "") {
                    var res = response.data.split(",");
                    if ($scope.AddressType == "PermanentCity") {
                        $scope.loadRecords_cityforPermanentAddress(0);
                        $scope.ddlCity1 = res[1];
                        $("#userCity1").select2("data", { id: res[1], text: res[0] });
                    }
                    else if ($scope.AddressType == "PresentCity") {
                        $scope.loadRecords_cityforPresentAddress(0);
                        $scope.ddlCity = res[1];
                        $("#userCity").select2("data", { id: res[1], text: res[0] });
                    }
                    $scope.AddresStateCityClear();
                    Command: toastr["info"]("Data Saved Successfully!!!!");
                    $("#modalStateCityModa").fadeIn(200, function () { $('#modalStateCityModa').modal('hide'); });
                }
                else if (response.data === 0) {
                        Command: toastr["error"]("Error while Creating User!!!!");
                }
                else {
                    Command: toastr["error"]("Error Undefined!!!!");
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
    }
    $scope.AddresStateCityClear = function () {
        $scope.CounteryID = 0;
        $scope.StateID = 0;
        $scope.Flag = "";
        $scope.AddressType = "";
        $scope.txtValue = "";
    }

    $scope.CheckLoginID = function () {
        if ($scope.UserType == 1) {
            CmnUserAuthentication = {
                LoginID: $scope.LoginID,
            };

            var apiRoute = '/SystemCommon/api/User/CheckLoginID/';
            var itemGroup = crudService.checkedUserLoginID(apiRoute, CmnUserAuthentication);
            itemGroup.then(function (response) {

                if (response.data === 1) {
                    Command: toastr["warning"]($scope.LoginID + " " + "This Login ID already existing");
                    $scope.LoginID = "";
                }


            },
            function (error) {
                console.log("Error: " + error);
            });
        }
    }
    $scope.CreateAccount = function () {
        debugger

        if ($scope.IsOnlineAccount == true) {
            $scope.LoginID = '';
            $scope.password = '';
            $scope.ngHPassword = true;
            $scope.ngHLoginID = true;
            $scope.IsLoginIDRequired = true;
        } else {
            $scope.LoginID = '';
            $scope.password = '';
            $scope.ngHPassword = false;
            $scope.ngHLoginID = false;
            $scope.IsLoginIDRequired = false;
        }
    }

}]);

function modal_fadeOut() {
    $("#userModal").fadeOut(200, function () {
        $('#userModal').modal('hide');
    });
}