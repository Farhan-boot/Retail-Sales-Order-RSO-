/**
 * CurrentOfferCtrl.js
 */

app.config(['$compileProvider', '$locationProvider', function ($compileProvider) { 
    $compileProvider.debugInfoEnabled(true);

    //, $locationProvider
    //$locationProvider.html5Mode({
    //    enabled: true,
    //    requireBase: false
    //});
}]);
app.controller('CurrentOfferCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {
        var baseUrl = DirectoryKey +'/SFTS/api/CurrentOffer/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;
        var selectedDistributor = [];
       

        $scope.IsCreateIcon = false;
        $scope.IsListIcon = true;
        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Show List";

        $scope.PageTitle = 'Add New Current Offer';
        $scope.ListTitle = 'Current Offer List';

        $scope.gridOptionsCurrentOffer = [];
        $scope.ListSelectedDistributor = [];
        var selectedRegion = [];
        $scope.ListSelectedRegion = [];
        $scope.listDDLRegion = [];
        $scope.ListDDLDistributor = [];
       
        $scope.currentOfferDist = [];

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
                $scope.PageTitle = 'Existing Current Offers';
                $scope.IsShow = false;
                $scope.IsHidden = false;

                $scope.IsCreateIcon = true;
                $scope.IsListIcon = false;
                loadAllCurrentOffer(0);
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

        GetPermission('00801');

        //load Distributors
        $scope.loadDistributors = function () {

            console.log($scope.ListSelectedRegion)
            var isPaging = 0;
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RegionId: $scope.Region == null || $scope.Region == undefined || $scope.Region == '' ? 0 : $scope.Region,
                loggeduser: $scope.loggedUserId,
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetAllDistributors/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
            var ListDistributor = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            ListDistributor.then(function (response) {
                selectedDistributor = $scope.ListSelectedDistributor;
                $scope.ListDDLDistributor = [];
                if (response.data.objListDistributor.length > 0) {
                    $scope.ListDDLDistributor = response.data.objListDistributor;

                    console.log($scope.ListDDLDistributor);
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.loadDistributors();

        //**********----Get Region ----***************
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

        //**********----Get Roles ----***************
        function loadRoles(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                RoleId: 0,
                //loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetRoles/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listRoles = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listRoles.then(function (response) {
                $scope.listRole = response.data.objListRole;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadRoles(0);
        
        //**********----Get Center Types ----***************
        function loadCenterTypes(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                CenterTypeId: 0
                //loggeduser: $scope.loggedUserId,                           
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetCenterTypes/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listCenterTypes = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listCenterTypes.then(function (response) {
                $scope.listCenterType = response.data.objListCenterType;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadCenterTypes(0);

        $scope.IsStaffRoleShow = false;
        $scope.IsCenterTypeShow = false;
        $scope.IsRetailerUploadShow = false;
        $scope.IsRegionShow = false;
        $scope.TargetTypeOnchange = function () {
            $scope.ListSelectedDistributor = [];
            $scope.ListSelectedRegion = [];
            $scope.IsStaffRoleShow = false;
            $scope.IsCenterTypeShow = false;
            $scope.IsRetailerUploadShow = false;
            $scope.IsRegionShow = false;
            if ($scope.TargetType == 1) {
                $scope.IsRetailerUploadShow = true;
                $scope.IsRegionShow = true;
                $scope.IsStaffRoleShow = false;
                $scope.IsCenterTypeShow = false;
            } else if ($scope.TargetType == 2) {
                $scope.IsRegionShow = false;
                $scope.IsStaffRoleShow = false;
                $scope.IsRetailerUploadShow = false;
                $scope.IsCenterTypeShow = false;
            } else if ($scope.TargetType == 3) {
                $scope.IsStaffRoleShow = true;
                $scope.IsRetailerUploadShow = false;
                $scope.IsRegionShow = true;
              
                $scope.IsCenterTypeShow = false;
            } else if ($scope.TargetType == 4) {
                $scope.IsRegionShow = false;
                $scope.IsCenterTypeShow = true;
                $scope.IsStaffRoleShow = false;
                $scope.IsRetailerUploadShow = false;
            }
        }

        $(document).ready(function () {
        
            $(".checkboxInput").change(function () {
                if (this.checked) {
                    alert('ok')
                }
            });
        });
        $scope.OnchangeToAll = function () {
            $scope.ListSelectedDistributor = [];
            $scope.ListSelectedRegion = [];
            $("#ddlStaffRole").select2("data", { id: '', text: '--Select Staff Role--' });
            if ($scope.IsToAll == true) {
                $scope.IsStaffRoleShow = false;
                $scope.IsCenterTypeShow = false;
                $scope.IsRetailerUploadShow = false;
                $("#ddlStaffRole").select2("data", { id: '', text: '--Select Staff Role--' });
            } else {
                if ($scope.TargetType == 1) {
                    $scope.IsRetailerUploadShow = true;
                    $scope.IsStaffRoleShow = false;
                    $scope.IsCenterTypeShow = false;
                } else if ($scope.TargetType == 2) {
                    $scope.IsStaffRoleShow = false;
                    $scope.IsRetailerUploadShow = false;
                    $scope.IsCenterTypeShow = false;
                } else if ($scope.TargetType == 3) {
                    $scope.IsStaffRoleShow = true;
                    $scope.IsRetailerUploadShow = false;
                    $scope.IsCenterTypeShow = false;

                } else if ($scope.TargetType == 4) {
                    $scope.IsCenterTypeShow = true;
                    $scope.IsStaffRoleShow = false;
                    $scope.IsRetailerUploadShow = false;
                }
            }     
        }

   
        //**********----Get All Current Offer Records----***************
 
        function loadAllCurrentOffer(isPaging) {
            $scope.gridOptionsCurrentOffer.enableFiltering = true;
            $scope.gridOptionsCurrentOffer.enableGridMenu = true;

            // For Loading
            if (isPaging == 0)
                $scope.pagination.pageNumber = 1;

            //For Loading
            $scope.loaderMoreCurrentOffer = true;
            $scope.lblMessageForCurrentOffer = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsCurrentOffer = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "OFFER_NAME", displayName: "Offer Name", title: "Offer Name", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "OFFER_DETAIL", displayName: "Offer Detail", title: "Offer Detail", width: '30%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "TARGET_TYPE_NAME", displayName: "Target Type", title: "Target Type", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "START_DATE", displayName: "Start Date", title: "Start Date", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "END_DATE", displayName: "End Date", title: "End Date", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISPLAY_DATE_FROM", displayName: "Display Date From", title: "Display Date From", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "DISPLAY_DATE_TO", displayName: "Display Date To", title: "Display Date To", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "IS_ACTIVE", displayName: "Is Active", title: "Is Active", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    
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
                                      '<a href="" title="Edit" ng-click="grid.appScope.getOfferInfo(row.entity)">' +
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
                CurrentOfferId: 0,
                loggeduser: $scope.loggedUserId
            };

   
            var apiRoute = baseUrl + 'GetAllOffer/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listCurrentOfferInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listCurrentOfferInfo.then(function (response) {
                $scope.pagination.totalItems = response.data.recordsTotal;
                $scope.gridOptionsCurrentOffer.data = response.data.currentOffers;
                $scope.loaderMoreCurrentOffer = false;
                $scope.currentOfferList = response.data.currentOffers;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        loadAllCurrentOffer(0);

        $scope.IsImageShow = false;
        //**********----Get Single Record----***************
        $scope.getOfferInfo = function (dataModel) {
            $scope.clear();
            $scope.IsShow = true;
            $scope.IsHiddenDetail = false;
            $scope.btnShowText = "Show List";
            $scope.btnSaveText = "Update";
            $scope.PageTitle = 'Update Current Offer';
            $scope.IsHidden = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;
            $scope.IsImageShow = true;

            $scope.hOfferId = dataModel.CURRENT_OFFER_ID;
            $scope.OfferName = dataModel.OFFER_NAME;
            $scope.OfferDetail = dataModel.OFFER_DETAIL;
            $scope.TargetType = dataModel.TARGET_TYPE;          
            $scope.StartDate = dataModel.START_DATE;
            $scope.EndDate = dataModel.END_DATE;
            $scope.DisplayDateFrom = dataModel.DISPLAY_DATE_FROM;
            $scope.DisplayDateTo = dataModel.DISPLAY_DATE_TO;
            $scope.StaffRole = dataModel.STAFF_ROLE_ID;
            $scope.IsActive = dataModel.IS_ACTIVE == "ACTIVE" ? true : false;
            $scope.IsToAll = dataModel.IS_TO_ALL == "FOR ALL" ? true : false;
            $scope.ListSelectedDistributor = [];
            $scope.ListSelectedRegion = [];
            $("#ddlTargetType").select2("data", { id: dataModel.TARGET_TYPE, text: dataModel.TARGET_TYPE_NAME });          
            $("#ddlCenterType").select2("data", { id: dataModel.CENTER_TYPE_ID, text: dataModel.CENTER_TYPE_NAME });
            if (dataModel.TARGET_TYPE == 1 || dataModel.TARGET_TYPE == 3) {
                $scope.IsRegionShow = true;
                $scope.GetCurrentOfferReg(dataModel.CURRENT_OFFER_ID);
            }
            if (dataModel.TARGET_TYPE == 1) {
                $scope.IsStaffRoleShow = false;
                $scope.IsRetailerUploadShow = true;
               
                $scope.GetCurrentOfferDist(dataModel.CURRENT_OFFER_ID);
              
            } else {
                $scope.IsStaffRoleShow = true;
                $scope.IsRetailerUploadShow = false;
                $("#ddlStaffRole").select2("data", { id: dataModel.STAFF_ROLE_ID, text: dataModel.STAFF_ROLE });
            }

            $scope.ListSelectedDistributor = $scope.currentOfferDist;
            $scope.ListSelectedRegion = $scope.currentOfferReg;
            //Offer Image Preview 
            $scope.GetPictures(dataModel.CURRENT_OFFER_ID);
        };

        $scope.GetCurrentOfferDist = function (OfferId) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                CurrentOfferId: OfferId,
                //loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetCurrentOfferDist/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listCurrentOfferPicture = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listCurrentOfferPicture.then(function (response) {
                $scope.currentOfferDist = response.data.currentOfferDist;
                $scope.ListSelectedDistributor = $scope.currentOfferDist;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetCurrentOfferReg = function (OfferId) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                CurrentOfferId: OfferId,
                //loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetCurrentOfferReg/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var currentOfferReg = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            currentOfferReg.then(function (response) {
                $scope.currentOfferReg = response.data.currentOfferReg;
                $scope.ListSelectedRegion = $scope.currentOfferReg;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        $scope.GetPictures = function (OfferId) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                CurrentOfferId: OfferId,
                //loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetCurrentOfferPictures/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listCurrentOfferPicture = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listCurrentOfferPicture.then(function (response) {
                $scope.ImageData = response.data.getOfferPicture;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.Imagefiles = [];

        $scope.RemovePics = function (PicId) {
            if (!confirm("The Picture will be deleted permanently. Are you sure?")) {
                return false;
            }

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                PictureId: PicId,
                //loggeduser: $scope.loggedUserId,

            };
            var apiRoute = baseUrl + 'DeletePicture/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var deletePicture = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            deletePicture.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Picture Removed Successfully!!!!");

                    $scope.GetPictures($scope.hOfferId);
                    $scope.IsImageShow = true;
                }

            },
            function (error) {
                console.log("Error: " + error);
            });

                //$(this).parent(".pip").remove();
        }

        $(document).ready(function () {
      
            if (window.File && window.FileList && window.FileReader) {
                $("#files").on("change", function (e) {

                    //$(".remove").click(function () {
                    //    debugger
                    //    $(this).parent(".pip").remove();
                    //});

                    var files = e.target.files,
                      filesLength = files.length;
                    var name = files[0].name;
                    for (var i = 0; i < filesLength; i++) {
                        var f = files[i]

                        /// file validation //////////////
                        $scope.fileValidate = files[i];

                        if ($scope.fileValidate.size > 200000000) {
                            // alert('file size should not be greater than 200 MB');
                            Command: toastr["warning"]("file size should not be greater than 200 MB!!!!");
                            document.getElementById('files').value = '';
                            return;
                        }

                        var allowed = ["jpeg", "png", "gif", "jpg"];
                        var found = false;
                        //var img;
                        //img = new Image();
                        allowed.forEach(function (extension) {
                            if ($scope.fileValidate.type.match('image/' + extension)) {
                                found = true;
                            }

                            //if ($scope.file.type.match('application/' + 'msword')) {
                            //    found = true;
                            //}
                        });
                        if (!found) {
                            //alert('file type should be .jpeg, .png, .jpg, .gif, .pdf, .doc');
                            Command: toastr["warning"]("file type should be .jpeg, .png, .jpg, .gif!!");
                            document.getElementById('files').value = '';
                            return;
                        }
                        //// file validation /////////////

                        $scope.Imagefiles.push(files[i])

                        var fileReader = new FileReader();
                        fileReader.onload = (function (e) {

                            var file = e.target;
                            $("<span class=\"pip\">" +
                              "<img float: right; class=\"imageThumb\" src=\"" + e.target.result + "\" title=\"" + name + "\"/>" +
                              "<br/><span class=\"remove\" id=\"" + name + "\">Remove image</span>" +
                              "</span>").appendTo("#imageContain");
                            $(".remove").click(function () {
                               // debugger
                                var ImageId = this.id;
                                for (var i = 0; i <= $scope.Imagefiles.length - 1; i++) {
                                    var fileName = $scope.Imagefiles[i].name;
                                    if (fileName == ImageId) {
                                        $scope.Imagefiles.splice(i, 1);
                                        $(this).parent(".pip").remove();
                                        break;
                                    }                                   
                                }                               
                            });

                            // Old code here
                            /*$("<img></img>", {
                              class: "imageThumb",
                              src: e.target.result,
                              title: file.name + " | Click to remove"
                            }).insertAfter("#files").click(function(){$(this).remove();});*/

                        });
                        fileReader.readAsDataURL(f);
                    }
                });
            } else {
                alert("Your browser doesn't support to File API")
            }
        });

        var fileList = [];
        //**********----Create New Record----***************

        $scope.save = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '00802'
            };
            $scope.SaveCurrentOffer();
            var apiRoute = '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveCurrentOffer();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });         
        };

        $scope.SaveCurrentOffer = function () {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };

            var OfferInfo = {
                OfferId: $scope.hOfferId == undefined || $scope.hOfferId == null ? 0 : $scope.hOfferId,
                OfferName: $scope.OfferName,
                OfferDetails: $scope.OfferDetail,
                StartDate: $scope.StartDate == "" || $scope.StartDate == null ? null : conversion.getStringToDate($scope.StartDate),
                EndDate: $scope.EndDate == "" || $scope.EndDate == null ? null : conversion.getStringToDate($scope.EndDate),
                DisplayFromDate: $scope.DisplayDateFrom == "" || $scope.DisplayDateFrom == null ? null : conversion.getStringToDate($scope.DisplayDateFrom),
                DisplayToDate: $scope.DisplayDateTo == "" || $scope.DisplayDateTo == null ? null : conversion.getStringToDate($scope.DisplayDateTo),
                TargetType: $scope.TargetType,
                IsToAll: $scope.IsToAll == true ? 1 : 0,
                StaffRoleId: $scope.StaffRole == 0 || $scope.StaffRole == undefined ? null : $scope.StaffRole,
                IsActive: $scope.IsActive == true ? 1 : 0
            };


            //angular.forEach($scope.files, function (item) {
            //    this.push(item.name);
            //}, fileList);

            //if (fileList.length == 0) {
            //    fileList.push('NotFound');
            //}


            //new
            angular.forEach($scope.Imagefiles, function (item) {
                this.push(item.name);
            }, fileList);

            if (fileList.length == 0) {
                fileList.push('NotFound');
            }


            var apiRoute = baseUrl + 'SaveUpdateCurrentOffer/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(OfferInfo) + " ," + JSON.stringify($scope.ListSelectedDistributor) + "," + JSON.stringify($scope.ListSelectedRegion) + "]";

            var SaveUpdateCurrentOffer = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateCurrentOffer.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");

                    if (fileList.length > 0) {
                        ///// Start Saveing Pictures/////////////
                        var data = new FormData();
                        for (var i in $scope.Imagefiles) {
                            data.append("uploadedFile", $scope.Imagefiles[i]);
                        }
                        data.append("uploadedFile", response);
                        var OfferId = response.data;
                        data.append("CurrentOfferId", OfferId);

                        // ADD LISTENERS.
                        var objXhr = new XMLHttpRequest();
                        var apiRoute = baseUrl + 'SaveUpdatePictures/';
                        objXhr.open("POST", apiRoute);
                        objXhr.send(data);
                        document.getElementById('files').value = '';
                        $scope.Imagefiles = [];
                        /////////// End Saveing Pictures /////////////////

                        var myEl = angular.element(document.querySelector('#imageContain'));
                        myEl.empty();
                        $scope.GetPictures($scope.hOfferId);
                        $scope.IsImageShow = false;
                    }

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

        
        $scope.PreviewPicture = function (imageId) {
            //debugger;
            var modal = document.getElementById('myModal');

            // Get the image and insert it inside the modal - use its "alt" text as a caption
            var img = document.getElementById(imageId);
            var modalImg = document.getElementById("img01");

            modal.style.display = "block";
            modalImg.src = document.getElementById(imageId).getAttribute("src");


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
            $scope.PageTitle = 'Add New Current Offer';

            $scope.hOfferId = 0;
            $scope.OfferName = '';
            $scope.OfferDetail = '';
            $scope.StartDate = '';
            $scope.EndDate = '';
            $scope.DisplayDateFrom = '';
            $scope.DisplayDateTo = '';
            $scope.IsActive = false;
            $scope.IsToAll = false;
            $scope.IsStaffRoleShow = false;

            $("#ddlTargetType").select2("data", { id: '', text: '--Select Target Type--' });
            $("#ddlStaffRole").select2("data", { id: '', text: '--Select Staff Role--' });
            $scope.Imagefiles = [];
            $scope.ListSelectedDistributor = [];
            var myEl = angular.element(document.querySelector('#imageContain'));
            myEl.empty();
            $scope.IsImageShow = false;
            $scope.ListSelectedRegion = [];
            loadAllCurrentOffer(0);
        };
    }]);

