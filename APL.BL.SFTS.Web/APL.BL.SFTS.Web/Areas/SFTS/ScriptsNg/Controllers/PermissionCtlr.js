/**
 * PermissionCtlr.js
 */

app.controller('PermissionCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {
        var baseUrl = DirectoryKey +'/SFTS/api/Permission/';

        $scope.IsCreateIcon = false;
        $scope.IsListIcon = true;
        $scope.btnSaveText = "Save";
        $scope.PageTitle = 'Add New Permission';
        var permissionCode = "";

       
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

        GetPermission('03001');


        //**********----Get Roles ----***************
        function loadRoles(isPaging) {
            objcmnParam = {
                RoleId: 0,
                loggeduser: $scope.loggedUserId,                         
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

        //Get Role wise permissions
        $scope.permissionList = [];
        $scope.roleWisePermissionDetails = [];
        $scope.loadRolePermissions = function() {
            objcmnParam = {
                RoleId: $scope.Role,
                loggeduser: $scope.loggedUserId,                         
            };

            var apiRoute = baseUrl + 'GetPermissions/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listPermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listPermission.then(function (response) {
                $scope.roleWisePermissionDetails = [];
                $scope.permissionList = response.data.permissionList;

                angular.forEach($scope.permissionList, function (item) {
                    if (item != null || item != "") {
                        $scope.roleWisePermissionDetails.push({
                            ID: item.ID,
                            DESCRIPTION: item.DESCRIPTION,
                            NAME: item.NAME,
                            IS_ACTIVE: item.IS_ACTIVE
                        });
                    }
                })
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.save = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '03002'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.savePermission();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        };
      
        $scope.savePermission = function () {

            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                RoleId: $scope.Role
            };
      
            var roleWisePermission = $scope.roleWisePermissionDetails;
  
            var apiRoute = baseUrl + 'SaveUpdatePermissions/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(roleWisePermission) + "]";

            var SaveUpdatePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdatePermission.then(function (response) {
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
        };

     

        //**********----Reset Record----***************
        $scope.clear = function () {
            $("#ddlRole").select2("data", { id: '', text: '--Select Role--' });
            $scope.roleWisePermissionDetails = [];
        };
    }]);

