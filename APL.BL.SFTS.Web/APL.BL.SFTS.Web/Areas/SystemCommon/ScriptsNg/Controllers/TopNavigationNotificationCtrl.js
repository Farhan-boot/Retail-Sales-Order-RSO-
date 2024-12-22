app.filter('timeAgo', ['$interval', function ($interval) {
    // trigger digest every 60 seconds
    $interval(function (){}, 60000);

    function fromNowFilter(time){
        return moment(time).fromNow();
    }

    fromNowFilter.$stateful = true;
    return fromNowFilter;
}]);




app.controller('TopNavigationNotificationCtrl', ['$scope', '$localStorage', 'sideNavService', function ($scope, $localStorage, sideNavService) {
     
    $scope.processNotificationList = [];
    $scope.processNotificationList = $localStorage.ProcessListfromLocalStrorage;
    $scope.topNavigationNotificationList = [];
    $scope.sessionUserCompanyID = $('#hCompanyID').val();
    $scope.sessionLoggedUserID = $('#hUserID').val();
    //alert($scope.sessionUserCompanyID);
    //**** GET NOtificationes This Event Fire for signalr client BroadCust ****************
    function loadRecords_Notificationes(dataModuleID) {
        var ModuleID = 1;
        var companyID = $scope.sessionUserCompanyID;
        var loggedUser = $scope.sessionLoggedUserID;
        var userID = $scope.sessionLoggedUserID;
        var apiRoute = '/SystemCommon/api/SystemCommonLayout/GetNotificationInfo/';
        var processMenues = sideNavService.GetSideMenu(apiRoute, companyID, loggedUser, userID);
        processMenues.then(function (response) {
            var currentLength = $scope.topNavigationNotificationList.length;
            $scope.topNavigationNotificationList = response.data; 
            var Length = $scope.topNavigationNotificationList.length;
            if(Length>currentLength)
            {
                ShowCustomToastrMessageResult(500);
            }
        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    //This Function is Invoked When Signalr hub Initialized;
    function loadRecords_Notification(dataModuleID) {
        
        var ModuleID = 1;
        var companyID = $scope.sessionUserCompanyID;
        var loggedUser = $scope.sessionLoggedUserID;
        var userID = $scope.sessionLoggedUserID;

        var apiRoute = '/SystemCommon/api/SystemCommonLayout/GetNotificationInfo/';
        var processMenues = sideNavService.GetSideMenu(apiRoute, companyID, loggedUser, userID);
        processMenues.then(function (response) {
            
            $scope.topNavigationNotificationList = response.data;
           
        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    
    
    $scope.targetNotifiedID = function (model, MasterID) {
       
        $localStorage.notificationStorageModel = model;
        $localStorage.notificationStorageMenuID = model.MenuID;
        
        $localStorage.currentMenuID = model.MenuID;
        $localStorage.notificationStorageMasterID = model.TransactionID;
        $localStorage.notificationStorageIsApproved = true;
        $localStorage.notificationStorageIsDeclained = true; 
       
        var apiRoute = '/SystemCommon/Dashboard/' + 'ModifyCompanySession/' + model.NotificationCompanyID;
        var porcessMasterDetails = sideNavService.getByID(apiRoute);
        porcessMasterDetails.then(function (response) {
            debugger
            var ab = response;
            
        },
       function (error) {
           console.log("Error: " + error);
       });
    };


    //Here is code for Process Wise Notification
    function loadRecords_ProcessNotificationes() { 
        var companyID = $scope.sessionUserCompanyID;
        var userID = $scope.sessionLoggedUserID;
        var departmentID = $scope.sessionLoggedUserID;
        var requestedUrl = window.location.pathname;
        var urlArray = requestedUrl.split("/");
        var moduleName = "";
        var controllerName = "";
        var controllerActionName = "A";
        moduleName = urlArray[1];
        controllerName = urlArray[2];
        if (urlArray.length == 4)
        {
            controllerActionName = urlArray[3];
        }

        var apiRoute = '/SystemCommon/api/SystemCommonLayout/GetProcessNotification/';
        var processMenues = sideNavService.GetProcess(apiRoute, userID, companyID, departmentID, moduleName, controllerName, controllerActionName);
        processMenues.then(function (response) {
            if (response.data.length > 0)
            {
                $scope.processNotificationList = response.data;
                $localStorage.ProcessListfromLocalStrorage = $scope.processNotificationList;
               
            }
        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    //*********************************** Signalr Code ************************
    // Reference the hub.
     

    var model = $scope.topNavigationNotificationList;
    var hubNotif = $.connection.notificationHubs;

    $.connection.hub.start().done(function () {
         
        loadRecords_Notification(0);
        loadRecords_ProcessNotificationes();
       // loadRecords_ProcessNotificationes();
    });

    hubNotif.client.updatedData = function () { 
        loadRecords_Notificationes(0);
        loadRecords_ProcessNotificationes();
    };
    //setInterval(function () {
        
    //    loadRecords_Notificationes(0);
    //}, 3000);
    hubNotif.server.broadcastData = function (model) { 
        loadRecords_Notification(0);
    };

}]);