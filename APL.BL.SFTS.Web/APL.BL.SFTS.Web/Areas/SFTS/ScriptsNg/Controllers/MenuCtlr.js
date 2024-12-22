/**
 * MenuCtrl.js
https://salesapps.banglalink.net/mDMS/SFTS/api/Menu/GetMenu/
 */


app.controller('MenuCtlr', ['$scope', 'menuService',
    function ($scope, menuService) {
        var baseUrl = DirectoryKey + '/SFTS/api/Menu/';
        
        function CommonEntity() {
            $scope.HeaderToken = $scope.tokenManager.generateSecurityToken();
            $scope.loggedUserId = $scope.loggedUserManager.loggedUser();
        }
        CommonEntity();


        //**********----Get Menu ----***************
        function loadMenu() {
            objcmnParam = {
                MenuId: 0,
                loggeduser: $scope.loggedUserId
            };

            var apiRoute = baseUrl + 'GetMenu/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listMenu = menuService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listMenu.then(function (response) {
                $scope.menuList = response.data.menuList;
                $scope.hMainMenuId = $scope.menuList[0].mainMenu.ID;
                var menuId = '#' + $scope.hMainMenuId;
                // jQuery(menuId).parent('li').addClass('menu-open')
                //$(menuId).parent('li').addClass('menu-open');
                //overflow: hidden; display: block;
                //setTimeout(
                //    function () {
                //        $(menuId).parent('li').addClass('menu-open');                
                //    }, 5000);
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        loadMenu(0);

        //**********----Get Role Wise Permission ----***************



    }]);

