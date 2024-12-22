/**
 * ComplainCtlr.js
 */

app.controller('ComplainCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/Complain/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Approve";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Complain List';
        $scope.btnListShow = false;
        $scope.IsCreateIcon = false;
        $scope.IsListIcon = false;
        $scope.IsDetailShow = false;
        $scope.IsQuestionListShow = false;
        $scope.SaveQuestion = "Save";
        $scope.IsMapShow = false;
        $scope.IsFromDetail = false;

        // debugger
        $scope.gridOptionsComplain = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;

        $scope.ShowHide = function () {
            if ($scope.IsDetailShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnRejectShow = false;
                    $scope.IsDetailShow = false;
                    $scope.btnListShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Complain List';
                    $scope.IsMapShow = false;
                    $scope.IsFromDetail = false;
                    $scope.loadComplainStatus();
                    loadComplain();
                   // $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Complain';
                    $scope.btnShowText = "Show Complain List";
                    $scope.btnSaveShow = true;
                    $scope.btnRejectShow = true;
                    $scope.btnSaveText = "Approve";
                    $scope.IsShow = false;
                    $scope.IsHidden = false;
                    $scope.IsDetailShow = false;

                    $scope.IsCreateIcon = false;
                    $scope.IsListIcon = true;
                }
            } else {                
                $scope.IsShow = true;
                $scope.btnSaveShow = false;
                $scope.btnRejectShow = false;
                $scope.IsDetailShow = false;
                $scope.btnListShow = false;
                $scope.IsCreateIcon = false;
                $scope.IsListIcon = false;
                $scope.PageTitle = 'Complain List';
            }
        }

        function CommonEntity() {
            $scope.HeaderToken = $scope.tokenManager.generateSecurityToken();
            $scope.loggedUserId = $scope.loggedUserManager.loggedUser();
           // $scope.CmnMethod = function (FuncEntity, CmnNum) { $scope.CmnEntity = {}; $scope.CmnEntity = conversion.ExecuteCmnFunc(FuncEntity, CmnNum); if (CmnNum != 0 && CmnNum != 2 && CmnNum != 6) { $scope[$scope.CmnEntity.MethodName]($scope.CmnEntity.rowEntity); } if (CmnNum == 2) { for (var i = 0; i < $scope.CmnEntity.MethodName.length; i++) { $scope[$scope.CmnEntity.MethodName[i]]($scope.CmnEntity.rowEntity); } } if (CmnNum == 3) { conversion.SaveUpdatBehave($scope.CmnEntity.num); } }
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

        GetPermission('00701');


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

  
        //**********----Get Complain Types ----***************
        function loadComplainTypes(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetComplainTypes/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var complainTypes = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            complainTypes.then(function (response) {
                $scope.listComplainType = response.data.listComplainType;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadComplainTypes(0);

        //**********----Get Complain Status ----***************
        $scope.loadComplainStatus = function (isPaging) {

            var complainType = 0;
            if ($scope.IsFromDetail) {
                complainType = $scope.complainTypeId;
            } else {
                complainType = $scope.ComplainType;
            }
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                ComplainTypeId: complainType,
                loggeduser: $scope.loggedUserId
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetComplainStatus/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var complainStatus = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            complainStatus.then(function (response) {
                $scope.listComplainStatus = [];
                $scope.listComplainStatus = response.data.listComplainStatus;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }


        //*******-----Get Search Result----************
        $scope.GetComplainSearch = function () {
            loadComplain();
        };  

        //**********----Get Complain----***************
        function loadComplain() {
            $scope.gridOptionsComplain.enableFiltering = true;
            $scope.gridOptionsComplain.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreComplain = true;
            $scope.lblMessageForComplain = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };         
           
            $scope.gridOptionsComplain = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "COMPLAIN_DATE", displayName: "Complain Date", title: "Complain Date", width: '11%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "COMPLAIN_FOR_TEXT", displayName: "Complain For", title: "Complain For", width: '12%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "COMPLAIN_FOR_CODE", displayName: "Code", title: "Code", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "COMPLAIN_FOR_NAME", displayName: "Name", title: "Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DESCRIPTION", displayName: "Discription", title: "Discription", width: '29%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "STATUS_NAME", displayName: "Status", title: "Status", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Action',
                        displayName: "Action",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '10%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<div style="padding-left: 10px">' +
                                      '<span class="label label-info label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="View Detail & Take Action" ng-click="grid.appScope.GetComplainDetail(row.entity)">' +
                                        '<i class="icon-info-sign" aria-hidden="true"></i> View Detail' +
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
                exporterCsvFilename: 'Complain.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Complain", style: 'headerStyle' },
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
                loggeduser: $scope.loggedUserId
            };

            objComplain = {
                Id: 0,
                ComplainFor: $scope.ComplainFor,
                ComplainForId: 0,
                TypeId: $scope.ComplainType,
                StatusId: $scope.Status,
                FromDate: $scope.DateFrom == "" || $scope.DateFrom == null ? null : conversion.getStringToDate($scope.DateFrom),
                ToDate: $scope.DateTo == "" || $scope.DateTo == null ? null : conversion.getStringToDate($scope.DateTo),
            };


            var apiRoute = baseUrl + 'GetComplains/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(objComplain) + "]";

            var listComplain = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listComplain.then(function (response) {
                $scope.gridOptionsComplain = [];
                $scope.gridOptionsComplain.data = response.data.getComplainList;
                $scope.loaderMoreComplain = false;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };
        loadComplain();

        //**********----Get Single Record----***************
        $scope.GetComplainDetail = function (dataModel) {
            //debugger
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Complain Detail';
            $scope.btnSaveText = "Submit";
            $scope.btnShowText = "Show Complain List";
            $scope.IsDetailShow = false;
            $scope.IsTListShow = false;
            $scope.btnSaveShow = true;
            $scope.btnRejectShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;
            $scope.btnListShow = true;
            $scope.IsMapShow = true;
            $scope.IsFromDetail = true;
            $scope.complainTypeId = dataModel.TYPE_ID;
            $scope.loadComplainStatus(0);
            if (dataModel.COMPLAIN_FOR == 1) {
                $scope.ComplainForCodeLabel = "Retailer Code"
                $scope.ComplainForNameLabel = "Retailer Name"
            } else if (dataModel.COMPLAIN_FOR == 3) {
                $scope.ComplainForCodeLabel = "Staff Code"
                $scope.ComplainForNameLabel = "Staff Name"
            }
         
            $scope.hComplainId = dataModel.ID;
            $scope.ComplainDate = dataModel.COMPLAIN_DATE;
            $scope.ComplainForCode = dataModel.COMPLAIN_FOR_CODE;
            $scope.ComplainForName = dataModel.COMPLAIN_FOR_NAME;
            $scope.RetailerName = dataModel.RETAILER_NAME;
            $scope.DistributorCode = dataModel.DISTRIBUTOR_CODE;
            $scope.DistributorName = dataModel.DISTRIBUTOR_NAME;
            $scope.Description = dataModel.DESCRIPTION;
            $scope.ResoluationDetail = dataModel.RESOLUTION_DETAILS;
            $scope.StatusChange = dataModel.STATUS_ID;
            $("#ddlStatusChange").select2("data", { id: dataModel.STATUS_ID, text: dataModel.STATUS_NAME });
            $scope.GetPictures(dataModel.ID);
        };

        $scope.GetPictures = function (complainId) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                ComplainId: complainId,
                loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetComplainPictures/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listComplainPic = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listComplainPic.then(function (response) {
                $scope.ImageData = response.data.getComplainPictures;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }


        $scope.PreviewPicture = function (imageId) {
            var modal = document.getElementById('myModal');

            // Get the image and insert it inside the modal - use its "alt" text as a caption
            var img = document.getElementById(imageId);
            var modalImg = document.getElementById("img01");

             modal.style.display = "block";
             modalImg.src = img.src;


            // Get the <span> element that closes the modal
            var span = document.getElementsByClassName("close")[0];
            //$scope.btnSaveShow = false;
            //$scope.IsCreateIcon = false;
            //$scope.IsListIcon = false;
            //$scope.btnListShow = false;
            // When the user clicks on <span> (x), close the modal
            span.onclick = function () {
                modal.style.display = "none";
            }
        }

        //**********----Submit Status Change----***************

        $scope.save = function () {

            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '00702'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveComplain();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });

        };


        $scope.SaveComplain = function () {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };

            var ComplainStatus = {
                Id: $scope.hComplainId,
                StatusId: $scope.StatusChange,
                ResolutionDetail: $scope.ResoluationDetail,
            };

            var apiRoute = baseUrl + 'SubmitComplainStatus/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(ComplainStatus) + "]";

            var SaveComplainStatus = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveComplainStatus.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnListShow = false;
                    $scope.IsCreateIcon = false;
                    $scope.IsListIcon = false;
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


        $scope.clear = function () {
            //$("#ddlComplainFor").select2("data", { id: 0, text: '--Select Complain For--' });
            //$("#ddlComplainType").select2("data", { id: 0, text: '--Select Complain Type--' });         
            //$("#ddlStatus").select2("data", { id: 0, text: '--Select Status--' });
            //$scope.DateTo = '';
            //$scope.DateFrom = '';
            //$scope.gridOptionsComplain = [];
            //$scope.gridOptionsComplain.data = [];
            loadComplain();
        }

    }]);

