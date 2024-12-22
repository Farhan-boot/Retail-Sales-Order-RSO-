/**
 * UserRoleAssignCtlr.js
 */

app.controller('UserRoleAssignCtlr', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {
        var baseUrl = '/SFTS/api/UserRoleAssign/';

        $scope.IsCreateIcon = false;
        $scope.IsListIcon = true;
        $scope.btnSaveText = "Save";
        $scope.PageTitle = 'Add User Roles';
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

            var apiRoute = '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted != true) {
                    window.location.href = "/SFTS/NoPermission";
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        GetPermission('04002');


        //**********----Get Users ----***************
        function loadUsers() {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,                         
            };

            var apiRoute = '/SFTS/api/CmnDropdown/GetUsers/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listUsers = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listUsers.then(function (response) {
                $scope.listUser = response.data.objListUser;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadUsers();

        //Get User wise Roles
        $scope.roleList = [];
        $scope.userWiseRoleDetails = [];
        $scope.loadUserRoles = function() {
            objcmnParam = {
                UserId: $scope.User,
                loggeduser: $scope.loggedUserId,                         
            };

            var apiRoute = baseUrl + 'GetUserRoles/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listPermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listPermission.then(function (response) {
                $scope.userWiseRoleDetails = [];
                $scope.roleList = response.data.roleList;

                angular.forEach($scope.roleList, function (item) {

                    if (item != null || item != "") {
                        $scope.userWiseRoleDetails.push({
                            ID: item.ID,
                            CODE: item.CODE,
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
                PermissionCode: '04002'
            };

            var apiRoute = '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.saveUserRole();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

      
        $scope.saveUserRole = function () {

            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                UserId: $scope.User
            };
      
            var userWiseRole = $scope.userWiseRoleDetails;
  
            var apiRoute = baseUrl + 'SaveUpdateUserRoles/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(userWiseRole) + "]";

            var SaveUpdateRole = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateRole.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");           
                    $scope.clear();
                }
                else if (response.data == "") {
                        Command: toastr["warning"]("Save Not Successfull!!!!");
                }

            },
            function (error) {
                console.log("Error: " + error);
            });
        };

     

        //**********----Reset Record----***************
        $scope.clear = function () {
            $("#ddlUser").select2("data", { id: '', text: '--Select User--' });
            $scope.userWiseRoleDetails = [];
        };
    }]);

