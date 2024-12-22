
/**
 * TokenCtrl.js
 */
app.controller('tokenCtrl', ['$scope', '$http', 'tokenService', '$sessionStorage', '$localStorage', '$rootScope',
function ($scope, $http, tokenService, $sessionStorage, $localStorage, $rootScope) {
    var hUserID = $('#hUserID').val();
    var hUserName = $('#hUserName').val();
    var hAppID = "1122";
    var token = $('#hUserToken').val();
    var headerToken = '';
    $scope.tokenManager = {
        generateSecurityToken: function () {
            var tokenId = [hAppID, hUserName, token].join(':');
            headerToken =
                {
                'AuthorizedToken': tokenId
                };
            return headerToken;
        },
    };

    $scope.loggedUserManager = {
        loggedUser: function () {
            loggedUserId = hUserID
            return loggedUserId;
        },
    };

    //var DirectoryKey = angular.element(document).find('meta[name=DirectoryKey]').prop("content");
    //$scope.DirectoryKey = {
    //    DirectoryKey: function () {
    //        DirectoryKey = DirectoryKey
    //        return DirectoryKey;
    //    },
    //};




}]);