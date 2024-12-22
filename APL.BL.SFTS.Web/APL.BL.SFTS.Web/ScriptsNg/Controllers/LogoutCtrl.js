/**
 * LogoutCtrl.js
 */

app.controller('LogoutController', ['$scope', '$http', '$window', function ($scope, $http, $window) {

    var DirectoryKey = angular.element(document).find('meta[name=DirectoryKey]').prop("content");

    $scope.LogOut = function () {
        
        $http({
            method: 'POST',
            url: DirectoryKey +'/Account/LogOut',
        }).
            success(function (data, status, headers, config) {
                if (data.status === 1) {
                    document.getElementById('hUserID').value = "";
                    document.getElementById('hUserName').value = "";
                    document.getElementById('hUserToken').value = "";
                    $window.location = DirectoryKey +'/Account/Login';
                }
            }).
            error(function (data, status, headers, config) {

            });
    };
}]);
app.config(function ($locationProvider) {
    $locationProvider.html5Mode(true);
});
