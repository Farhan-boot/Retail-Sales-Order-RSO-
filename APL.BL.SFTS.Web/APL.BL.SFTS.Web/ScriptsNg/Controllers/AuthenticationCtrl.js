/**
* UserCtrl.js
*/ 

app.controller('loginCtrl', ['$scope', 'userService', '$window',
    function ($scope, userService, $window) {
        $scope.IsVisible = true; $scope.IsLogged = false; $scope.success = false; $scope.error = false;

        var DirectoryKey = angular.element(document).find('meta[name=DirectoryKey]').prop("content");

        //var d = $scope.DirectoryKey;
        //alert(d);

        $("#txtUserName").keyup(function (event) {
            if (event.keyCode === 13) {
                $("#btnOpenDoor").click();
            }
        });

        $("#txtPassword").keyup(function (event) {
            if (event.keyCode === 13) {
                $("#btnOpenDoor").click();
            }
        });

        //**********----Create New Record----***************
        $scope.submitLogin = function () {
            var AuthenticateUser = {
                UserLogin: $scope.UserLogin,
                Password: $scope.Password
            };
            $scope.lblrmessage = 'Authenticating....';
            if (AuthenticateUser != null) {
                var urlLogin = DirectoryKey +'/Account/Login/';
                var LoginUser = userService.post(urlLogin, AuthenticateUser);
                LoginUser.then(function (response) {
                    if (response.data.status === 1) {
                        $scope.IsVisible = false;
                        $scope.IsLogged = true;
                        $scope.error = false;
                        $scope.success = true;
                        $scope.lblrmessage = 'Login Successful. Redirecting....';
                        //if (response.data.TargetUrl == null)
                        //{
                        $window.location = DirectoryKey +'/SFTS/Home';
                        //}
                        //else
                        //{
                        //    $window.location = response.data.TargetUrl
                        //} 
                        //Command: toastr["info"]("Login Successful, Redirecting please wait....!");
                    }
                    else if (response.data.status === 0) {
                        //$scope.IsVisible = true;
                        $scope.IsLogged = true;
                        $scope.error = true;
                        $scope.lblrmessage = 'The login is invalid! Please re-enter..';
                        //Command: toastr["warning"]("The login is invalid! Please re-enter....");
                    }
                    else {
                        $scope.lblrmessage = 'Account Not Found!';
                       // Command: toastr["error"]("Account Not Found!");
                    }
                },
                function (error) {
                    console.log("Error: " + error);
                });
            }
        };

        //**********----Create New Record----***************
        $scope.submitRecovery = function () {
            debugger;
            var RecoverUser = {
                RecoverEmail: $scope.RecEmail
            };

            if (RecoverUser != null) {
                var url = DirectoryKey +'/Account/Recover/';
                var Recovery = userService.post(url, RecoverUser);
                Recovery.then(function (response) {
                    if (response.data.status === 1) {

                        Command: toastr["success"]("Great. We have sent you an email!");
                    }
                    else if (response.data.status === 0) {

                            Command: toastr["error"]("Account Not Found!");
                    }
                    else {
                        Command: toastr["error"]("Account Not Found!");
                    }
                },
                function (error) {
                    console.log("Error: " + error);
                });
            }
        }
    }]);


