/**
* FocProductCtlr.js
*/
app.controller('MenuGroupItemMapCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/MenuGroup_ItemMap/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing Menu Group Item Map';
        $scope.ListTitle = 'Menu Group List';
        $scope.IsCreateIcon = true;
        $scope.IsListIcon = false;
        $scope.IsMenuGroupItemMapShow = false;
        $scope.gridOptionsMenuGroupItemMaps = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;

        $scope.ShowHide = function () {
            if ($scope.IsMenuGroupItemMapShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.btnShowText = "Create";
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Existing Menu Group Item Maps';
                    $scope.clear();
                }
                else {
                    $scope.PageTitle = 'Add New Menu Group Item Map';
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
                $scope.PageTitle = 'Existing Menu Group Item Map';
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

        GetPermission('01901');


        //**********----Get All TradeMaterials----***************
        function loadMenuGroupItemMaps(isPaging) {

            $scope.gridOptionsMenuGroupItemMaps.enableFiltering = true;
            $scope.gridOptionsMenuGroupItemMaps.enableGridMenu = true;

            //For Loading
            $scope.loaderMoreMenuGroupItemMaps = true;
            $scope.lblMessageForMenuGroupItemMaps = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsMenuGroupItemMaps = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "GROUP_NAME", displayName: "GROUP NAME", title: "GROUP NAME", width: '25%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MENU_NAME", displayName: "MENU NAME", title: "MENU NAME", width: '25%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "MAPPING_FOR_NAME", displayName: "MAPPING FOR", title: "MAPPING FOR", width: '25%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "IS_ACTIVE_STR", displayName: "IS ACTIVE", title: "IS ACTIVE", width: '25%', headerCellClass: $scope.highlightFilteredHeader },
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
                            '<a href="" title="Edit" ng-click="grid.appScope.getMenuGroupItemMap(row.entity)">' +
                            '<i class="icon-edit" aria-hidden="true"></i> Edit' +
                            '</a>' +
                            '</span>' +
                            '<span class="label label-warning label-mini" style="text-align:center !important;">' +
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
            var apiRoute = baseUrl + 'GetMenuGroupItemMaps/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var menuGroupItemMapList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            menuGroupItemMapList.then(function (response) {
                $scope.gridOptionsMenuGroupItemMaps.data = response.data.menuGroupItemMapList;
                $scope.loaderMoreMenuGroupItemMaps = false;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };
        loadMenuGroupItemMaps(0);

        //**********----Get Single Record----***************
        $scope.getMenuGroupItemMap = function (dataModel) {
            //debugger
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Update Menu Group';
            $scope.btnSaveText = "Update";
            $scope.btnShowText = "Show List";
            $scope.btnSaveShow = true;
            $scope.btnResetShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;


            $scope.hMenuGroupItemMapId = dataModel.MAPPING_ID;
            $scope.GroupName = dataModel.GROUP_NAME;
            $scope.MenuName = dataModel.MENU_NAME;
            $scope.MappingForName = dataModel.MAPPING_FOR_NAME;
            $scope.IsActive = dataModel.IS_ACTIVE;
            $scope.GroupId = dataModel.GROUP_ID;
            $scope.MenuId = dataModel.MENU_ID;
            $scope.MappingFor = dataModel.MAPPING_FOR;
            $scope.GroupItems = dataModel.GROUP_ITEMS;
            
            loadGroups(0, $scope.MappingFor);
            loadItems(0, $scope.MappingFor, $scope.GroupId);

            $("#ddlGroup").select2("data", { id: dataModel.GROUP_ID, text: dataModel.GROUP_NAME });
        };

        $scope.mappingForChanged = function () {

            
            loadGroups(0,$scope.MappingFor);
            loadItems(0,$scope.MappingFor);

        }
        $scope.MappingFor = 1;
        loadGroups(0, $scope.MappingFor);
        loadItems(0, $scope.MappingFor);
        function loadGroups(isPaging, mappingFor) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
                MappingFor: mappingFor
            };

            var apiRoute = baseUrl + '/GetMenuGroups'; //'/mDMS/SFTS/api/CmnDropdown/GetRegions/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var groupList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            groupList.then(function (response) {

                console.log(response.data);
                $scope.groupList = response.data.menuGroupList;
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }

        function loadItems(isPaging, mappingFor,groupId) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
                MappingFor: mappingFor,
                MenuGroupId: groupId
            };

            var apiRoute = baseUrl + '/GetMenuItems'; //'/mDMS/SFTS/api/CmnDropdown/GetRegions/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var itemList = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            itemList.then(function (response) {
                $scope.itemList = [];
                console.log(response.data);
                $scope.itemList = response.data.menuItemList;
                //$scope.GroupItems = "2,3,4";

                //if ($scope.GroupItems !== "undefined") {
                //    var gItems = $scope.GroupItems.split(',');

                //    for (var i = 0; i < gItems.length; i++) {
                //        console.log("table "+gItems[i])
                //        for (var j = 0; j < $scope.itemList.length; j++) {
                //            console.log("page "+$scope.itemList[j].ITEM_ID)
                //            if ($scope.itemList[j].ITEM_ID == gItems[i]) {
                //                alert(gItems[i])
                //                $scope.item.Selected = true;
                //                break;
                //            }

                //        }

                //    }
                //}

                //for (var j = 0; j < $scope.itemList.length; j++) {
                //    alert($scope.itemList[j].ITEM_ID)

                //}
                ////alert($scope.GroupItems)
                ////$scope.GroupItems = "2,3,4";
                //var gItems = $scope.GroupItems.split(',');
                //for (var i = 0; i < gItems.length; i++) {
                //    alert(gItems[i])
                //}
               
                console.log("Items: " + $scope.itemList);
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
       
        //**********----Create New TradeMaterial----***************

        $scope.groupChanged = function () {
            loadItems(0, $scope.MappingFor, $scope.GroupId);
        }
        $scope.save = function () {

            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '01902'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveMenuGroupItemMap();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        };

        $scope.SaveMenuGroupItemMap = function () {

 
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };
            var itemIds = "";
            for (var i = 0; i < $scope.itemList.length; i++) {
                if ($scope.itemList[i].Selected) {
                    var itemId = $scope.itemList[i].ITEM_ID;
                    itemIds +=  itemId+",";
                }
            }
            var MenuGroupItemMap = {
                MappingId: $scope.hMenuGroupItemMapId === undefined || $scope.hMenuGroupItemMapId === null ? 0 : $scope.hMenuGroupItemMapId,
                GroupId: $scope.GroupId,
                ItemIds: itemIds,
                MappingFor: $scope.MappingFor,
                IsActive: $scope.IsActive
            };

           
            var apiRoute = baseUrl + 'SaveMenuGroupItemMap/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(MenuGroupItemMap) + "]";

            var SaveUpdateMenuGroupItemMap = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateMenuGroupItemMap.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnShowText = "Create";
                    $scope.PageTitle = 'Add New Menu Group';
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;
                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    loadMenuGroupItemMaps(0);
                }
                else if (response.data == "") {
                    Command: toastr["warning"]("Save Not Successfull!!!!");
                }
            },
                function (error) {
                    console.log("Error: " + error);
                });
        }
        
        $scope.IsActive = 1;
        //**********----Reset Record----***************
        $scope.clear = function () {
            $scope.IsHidden = true;
            $scope.IsShow = true;
            $scope.IsHiddenDetail = true
            $scope.IsCreateIcon = true;
            $scope.IsListIcon = false;

            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Create";

            $scope.hMenuGroupItemMapId = 0;
            $scope.GroupId = 0;
            $scope.IsActive = 1;
            $scope.MappingFor = 1;
            loadGroups(0, $scope.MappingFor);
            loadItems(0, $scope.MappingFor, $scope.GroupId);
            loadMenuGroupItemMaps(0);
        };
    }]);

