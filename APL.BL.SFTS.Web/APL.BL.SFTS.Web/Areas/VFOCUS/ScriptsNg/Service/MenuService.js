/**
 * ng_CrudService.js
 */

app.service('menuService', function ($http) {

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

});