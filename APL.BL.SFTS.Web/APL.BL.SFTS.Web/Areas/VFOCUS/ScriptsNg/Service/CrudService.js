/**
 * ng_CrudService.js
 */

app.service('crudService', function ($http, conversion) {
    //**********----Get All Record----***************
    var urlGet = '';
    this.getAllIncludingCompanyLog = function (apiRoute, companyID, loggedUser, page, pageSize, isPaging) {
        urlGet = apiRoute + companyID + '/' + loggedUser + '/' + page + '/' + pageSize + '/' + isPaging;
        return $http.get(urlGet);
    }
    this.getAllIncludingCompanyuser = function (apiRoute, companyID, loggedUser, page, pageSize, isPaging) {
        urlGet = apiRoute + companyID + '/' + loggedUser + '/' + page + '/' + pageSize + '/' + isPaging;
        return $http.get(urlGet);
    }
    this.getAllWithCompnayID = function (apiRoute, page, pageSize, isPaging, ComapnyID) {
        urlGet = apiRoute + page + '/' + pageSize + '/' + isPaging + '/' + ComapnyID;
        return $http.get(urlGet);
    }
    this.getUser = function (apiRoute, companyID, loggedUser, userTypeID, page, pageSize, isPaging) {
        urlGet = apiRoute + companyID + '/' + loggedUser + '/' + '/' + userTypeID + '/' + page + '/' + pageSize + '/' + isPaging;
        return $http.get(urlGet);
    }
    this.getAll = function (apiRoute, page, pageSize, isPaging) {

        urlGet = apiRoute + page + '/' + pageSize + '/' + isPaging;
        return $http.get(urlGet);
    }

    this.getAllUsers = function (apiRoute, objcmnParam) {
        var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
        var request = $http({
            method: "post",
            url: apiRoute,
            data: cmnParam,
            dataType: "json",
            contentType: "application/json"
        });
        return request;
    }

    this.getAllUsersType = function (apiRoute, objcmnParam) {
        var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
        var request = $http({
            method: "post",
            url: apiRoute,
            data: cmnParam,
            dataType: "json",
            contentType: "application/json"
        });
        return request;
    }

    this.getAllUsersGroup = function (apiRoute, objcmnParam) {
        var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
        var request = $http({
            method: "post",
            url: apiRoute,
            data: cmnParam,
            dataType: "json",
            contentType: "application/json"
        });
        return request;
    }

    this.getAllByParam = function (apiRoute, companyID, loggedUser, page, pageSize, isPaging, pModuleID, pUserGroupID, pUserID, pOrgannogramID) {
        urlGet = apiRoute + companyID + '/' + loggedUser + '/' + page + '/' + pageSize + '/' + isPaging + '/' + pModuleID + '/' + pUserGroupID + '/' + pUserID + '/' + pOrgannogramID;
        return $http.get(urlGet);
    }
    //**********----Get Single Record----***************
    this.getByID = function (apiRoute) {
        return $http.get(apiRoute);
    }


    //**********----Create New Record----***************

    this.post = function (apiRoute, Model) {
        var request = $http({
            method: "post",
            url: apiRoute,
            data: Model
        });
        return request;
    }
    this.postList = function (apiRoute, User, PmCompany) {
        var strFinal = "[" + JSON.stringify(User) + "," + JSON.stringify(PmCompany) + "]";

        var request = $http({
            method: "post",
            url: apiRoute,
            data: strFinal,
            contentType: "application/json"
        });
        //console.log(request);
        return request;
    }



    this.GetList = function (apiRoute, cmnParam, headerToken) {

        var request = $http({
            method: "post",
            url: apiRoute,
            data: cmnParam,
            dataType: "json",
            contentType: "application/json",
            headers: headerToken
        });
        return request;
    }


    //**********----Update the Record----***************
    this.put = function (apiRoute, Model) {
        var request = $http({
            method: "put",
            url: apiRoute,
            data: Model
        });
        return request;
    }

    //**********----Delete the Record----***************
    this.delete = function (apiRoute) {
        var request = $http({
            method: "delete",
            url: apiRoute
        });
        return request;
    }

    //this.postMultipleModel = function (apiRoute, model) {
    //    debugger
    //    var strFinal = conversion.getDynamicModels(model);

    //    var request = $http({
    //        method: "post",
    //        url: apiRoute,
    //        data: strFinal,
    //        dataType: "json",
    //        contentType: "application/json"
    //    });
    //    //console.log(request);
    //    return request;
    //}

    this.postMultipleModel = function (apiRoute, model, headerToken) {
        var strFinal = conversion.getDynamicModels(model);
        var RequestType = strFinal.Token.post.AuthorizedToken == headerToken.AuthorizedToken || strFinal.Token.put.AuthorizedToken == headerToken.AuthorizedToken ? $.ajax : $http;
        var request = RequestType({
            method: "post",
            url: apiRoute,
            data: strFinal.model,
            async: false,
            dataType: "json",
            contentType: "application/json",
            headers: headerToken
        });
        return request;
    }
    this.checkedUserLoginID = function (apiRoute, Model) {
        var request = $http({
            method: "post",
            url: apiRoute,
            data: Model
        });
        return request;
    }

    this.getActiveServiceList = function (apiRoute, objcmnParam, headerToken) {

        var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

        var request = $http({
            method: "post",
            url: apiRoute,
            data: cmnParam,
            dataType: "json",
            contentType: "application/json",
            headers: headerToken
        });
        return request;
    }
});