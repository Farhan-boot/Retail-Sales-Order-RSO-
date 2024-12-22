/**
* FocProductCtlr.js
*/
app.controller('AppMenuCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/AppMenu/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing App Menu';
        $scope.ListTitle = 'App Menu List';
        $scope.IsCreateIcon = true;
        $scope.IsListIcon = false;
        $scope.IsAppMenuShow = false;
        $scope.gridOptionsAppMenus = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;

        $scope.ShowHide = function () {
            if ($scope.IsAppMenuShow == false) {
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
            } else {
                $scope.btnShowText = "Create";
                $scope.IsShow = true;
                $scope.btnSaveShow = false;
                $scope.btnResetShow = false;
                $scope.IsCreateIcon = true;
                $scope.IsListIcon = false;
                $scope.PageTitle = 'Existing App Menu';
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

        GetPermission('04011');


        //**********----Get All TradeMaterials----***************
        function loadAppMenus(isPaging) {

            $scope.gridOptionsAppMenus.enableFiltering = true;
            $scope.gridOptionsAppMenus.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreAppMenus = true;
            $scope.lblMessageForAppMenus = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsAppMenus = {
                useExternalSorting: false,
                enableSorting: true,
                useExternalPagination: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "MENU_FOR_NAME", displayName: "Menu For", title: "Menu For", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "PARENT_NAME", displayName: "Parent Name", title: "Parent Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MENU_NAME", displayName: "Menu Name", title: "Menu Name", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MENU_NAME_BAN", displayName: "Menu Name (Bangla)", title: "Menu Name (Bangla)", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "IS_PARENT_STR", displayName: "Is Parent", title: "Is Parent", width: '8%', headerCellClass: $scope.highlightFilteredHeader },
                    //{ name: "MENU_URL", displayName: "Menu Url", title: "Menu Url", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "IS_ACTIVE_STR", displayName: "Is Active", title: "Is Active", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'SL No',
                        displayName: "SL No",
                        enableColumnResizing: true,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '7%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<div style="padding-left: 10px">' +
                            '<input type="number" id="id_{{row.entity.ITEM_ID}}"  ng-blur="grid.appScope.serialChange(row.entity)" ng-model="row.entity.SRL_NO" class="form-control" value="{{row.entity.SRL_NO}}" />' +
                            '</div>'
                    },
                    {
                        name: 'Action',
                        displayName: "Action",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '12%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<div style="padding-left: 10px">' +
                            '<span class="label label-info label-mini" style="text-align:center !important;">' +
                            '<a href="" title="Edit" ng-click="grid.appScope.getAppMenu(row.entity)">' +
                            '<i class="icon-edit" aria-hidden="true"></i> Edit' +
                            '</a>' +
                            '</span>' +
                            '<span class="label label-warning label-mini" style="display:none;text-align:center !important;">' +
                            '<a href="" title="Delete" ng-click="grid.appScope.delete(row.entity)">' +
                            '<i class="icon-trash" aria-hidden="true"></i> Delete' +
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
                exporterCsvFilename: 'Trade Materials.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Trade Materials", style: 'headerStyle' },
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
                loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetAppMenus/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var AppMenuList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            AppMenuList.then(function (response) {
                $scope.gridOptionsAppMenus.data = response.data.menuItemList;
                $scope.loaderMoreAppMenus = false;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };
        loadAppMenus(0);
        function loadMenuGroups(isPaging, MENU_FOR) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                MappingFor: MENU_FOR
                //loggeduser: $scope.loggedUserId                              
            };

            var apiRoute = baseUrl + '/GetMenuGroups';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var menuGroupList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            menuGroupList.then(function (response) {
                $scope.menuGroupList = response.data.menuItemList;

                console.log($scope.menuGroupList)
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        loadMenuGroups(0,1);
        //**********----Get Single Record----***************
        $scope.getAppMenu = function (dataModel) {
            //debugger
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Update App Menu';
            $scope.btnSaveText = "Update";
            $scope.btnShowText = "Show List";
            $scope.btnSaveShow = true;
            $scope.btnResetShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;


            $scope.hAppMenuId = dataModel.ITEM_ID;
            $scope.MENU_NAME = dataModel.MENU_NAME;
            $scope.MENU_NAME_BAN = dataModel.MENU_NAME_BAN;
            $scope.MENU_URL = dataModel.MENU_URL;
            $scope.MENU_FORName = dataModel.MENU_FOR_NAME;
            $scope.MENU_FOR = dataModel.MENU_FOR;
            $scope.IS_ACTIVE = dataModel.IS_ACTIVE;
            $scope.PARENT_ID = dataModel.PARENT_ID;
            $scope.IS_HEADER = dataModel.IS_HEADER;
      

            $("#ddlParent").select2("data", { id: dataModel.PARENT_ID, text: dataModel.PARENT_NAME??'--Select Parent--' });
            loadMenuGroups(0, $scope.MENU_FOR);
            
        };




        //**********----Create New TradeMaterial----***************

        $scope.save = function () {
            $('#save').attr('disabled', 'disabled');
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '04012'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveAppMenu();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };

        $scope.SaveAppMenu = function () {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };
           // alert($scope.PARENT_ID === null)
            var AppMenu = {
                ItemId: $scope.hAppMenuId === undefined || $scope.hAppMenuId === null ? 0 : $scope.hAppMenuId,
                MenuName: $scope.MENU_NAME,
                MenuNameB: $scope.MENU_NAME_BAN,
                MenuUrl: $scope.MENU_URL,
                MenuFor: $scope.MENU_FOR,
                IsActive: $scope.IS_ACTIVE,
                ParentId: $scope.PARENT_ID === null ? 0 : $scope.PARENT_ID,
                IsHeader: $scope.IS_HEADER
            };


            var apiRoute = baseUrl + 'SaveAppMenu/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(AppMenu) + "]";

            var SaveUpdateAppMenu = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateAppMenu.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnShowText = "Create";
                    $scope.PageTitle = 'Add New App Menu';
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;
                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    loadAppMenus(0);
                }
                else if (response.data == "") {
                    Command: toastr["warning"]("Save Not Successfull!!!!");
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }

        $scope.MENU_FORChanged = function () {


            loadMenuGroups(0, $scope.MENU_FOR);

        }
        $scope.serialChange = function (dataModel) {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId
            };
            var MenuInfo = {
                ItemId: dataModel.ITEM_ID,
                SrlNo: dataModel.SRL_NO
            };
            var apiRoute = baseUrl + 'UpdateSrlNo/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(MenuInfo) + "]";

            var deleteInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            deleteInfo.then(function (response) {
                // debugger;
                if (response.data != "") {
                   // Command: toastr["success"]("Update  Successfully!!!!");
                    loadAppMenus(0);
                }
                else if (response.data == "") {
                    Command: toastr["warning"]("Update Not Successfull!!!!");
                }

            }, function (error) {
                console.log("Error: " + error);
            });

        }
        $scope.delete = function (dataModel) {
            var isDelete = confirm('You are about to delete ' + dataModel.MENU_NAME + '. Are you sure?');
            if (isDelete == true) {
                objcmnParam = {
                    pageNumber: page,
                    pageSize: pageSize,
                    IsPaging: isPaging,
                    loggeduser: $scope.loggedUserId
                };
                var MenuInfo = {
                    ItemId: dataModel.ITEM_ID
                };
                var apiRoute = baseUrl + 'DeleteInfo/';

                var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(MenuInfo) + "]";

                var deleteInfo = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
                deleteInfo.then(function (response) {
                    // debugger;
                    if (response.data != "") {
                        Command: toastr["success"]("Delete  Successfully!!!!");
                        loadAppMenus(0);
                    }
                    else if (response.data == "") {
                        Command: toastr["warning"]("Delete Not Successfull!!!!");
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });
            }
        }

        $scope.MENU_FOR = 1;
        $scope.IS_ACTIVE = 1;
        $scope.IS_HEADER = 2;
        //**********----Reset Record----***************
        $scope.clear = function () {
            $scope.IsHidden = true;
            $scope.IsShow = true;
            $scope.IsHiddenDetail = true
            $scope.IsCreateIcon = true;
            $scope.IsListIcon = false;

            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Create";

            $scope.hAppMenuId = 0;
            $scope.MENU_NAME = '';
            $scope.MENU_NAME_BAN = '';
            $scope.MENU_URL = '';
            $scope.MENU_FOR = 1;
            $scope.IS_ACTIVE = 1;
            $scope.IS_HEADER = 2;

            loadAppMenus(0);
            loadMenuGroups(0, 1);
            $('#save').removeAttr('disabled');
        };
    }]);

