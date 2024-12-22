/**
 * SurveyQuestionCtrl.js
 */
app.controller('SurveyQuestionCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/SurveyQuestionAndAnswer/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Show List";

        $scope.PageTitle = 'New Survey';
        $scope.ListTitle = 'Survey List';

        $scope.gridOptionsNewSurvey = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;
        $scope.IsHiddenDetail = true;
        $scope.ShowHide = function () {
            $scope.IsHidden = $scope.IsHidden == true ? false : true;
            $scope.IsHiddenDetail = true;
            if ($scope.IsHidden == true) {
                $scope.btnShowText = "Show List";
                $scope.IsShow = true;

                $scope.IsCreateIcon = false;
                $scope.IsListIcon = true;
                $scope.clear();
            }
            else {
                $scope.btnShowText = "Create";
                $scope.btnSaveText = "Save";
                $scope.IsShow = false;
                $scope.IsHidden = false;

                $scope.IsCreateIcon = true;
                $scope.IsListIcon = false;
                // loadCurrentOfferList(0);
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

        GetPermission('01501');


        //**********----Pagination----***************
        $scope.pagination = {
            paginationPageSizes: [15, 25, 50, 75, 100, 500, 1000, "All"],
            ddlpageSize: 15, pageNumber: 1, pageSize: 15, totalItems: 0,

            getTotalPages: function () {
                return Math.ceil(this.totalItems / this.pageSize);
            },
            pageSizeChange: function () {
                if (this.ddlpageSize == "All")
                    this.pageSize = $scope.pagination.totalItems;
                else
                    this.pageSize = this.ddlpageSize

                this.pageNumber = 1
                loadCustomerRecords(1);
            },
            firstPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber = 1
                    loadCustomerRecords(1);
                }
            },
            nextPage: function () {
                if (this.pageNumber < this.getTotalPages()) {
                    this.pageNumber++;
                    loadCustomerRecords(1);
                }
            },
            previousPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber--;
                    loadCustomerRecords(1);
                }
            },
            lastPage: function () {
                if (this.pageNumber >= 1) {
                    this.pageNumber = this.getTotalPages();
                    loadCustomerRecords(1);
                }
            }
        };
        //  }

        //**********----Get Survey ----***************
        function loadSurvey(isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                DistributorID: 0,
                //loggeduser: $scope.loggedUserId,                             
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetSurvey/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listSurvey = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listSurvey.then(function (response) {
                $scope.listSurvey = response.data.objListSurvey;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        loadSurvey(0);

        //**********----Get Question ----***************
        $scope.loadQuestion = function (isPaging) {
            //$("#ddlQuestion").select2("val", "");
            //$("#ddlQuestion").val('');
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                SurveyId: $scope.Survey,
                //loggeduser: $scope.loggedUserId,                           
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetSurveyQuestion/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listQuestions = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listQuestions.then(function (response) {
                $scope.listQuestion = response.data.objListQuestion;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        //**********----Get All Question----***************
        $scope.getQuestionForEdit = function (dataModel) {
            $scope.IsShow = true;
            $scope.IsHiddenDetail = false;
            $scope.btnShowText = "Show List";
            $scope.IsHidden = true;
            $scope.btnSaveText = "Update";
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;


            $scope.hSurveyId = dataModel.SURVEYLIST_ID;
            $scope.Title = dataModel.TITLE;
            $scope.Description = dataModel.DESCRIPTION;
            $scope.StartDate = dataModel.START_DATETIME;
            $scope.EndDate = dataModel.END_DATETIME;

            $("#ddlDistributor").select2("data", { id: dataModel.DISTRIBUTORID, text: dataModel.DISTRIBUTOR_NAME });
            $("#ddlRoute").select2("data", { id: dataModel.ROUTE_CODE, text: dataModel.ROUTE_NAME });
          // $("#ddlSurveyFor").select2("data", { id: '', text: '--RSO--' });
        };

        //*******----Survey Onchange----*******
        $scope.GetSurveyQuestions = function () {
            $scope.getAllQuestion($scope.Survey);
            $scope.IsTableSurveyQuestionShow = true;

            $scope.loadQuestion();
        };

        //*******----Question Onchange----*******
        $scope.GetAnswers = function () {
            $scope.getAllAnswer($scope.Survey, $scope.SelectedQuestion);
            $scope.IsTableQuestionAnswerShow = true;
        };

        //**********----Get All Question----***************
        $scope.getAllQuestion = function (surveyId) {
            //$scope.ListSurveyQuestion = [];
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                //loggeduser: $scope.loggedUserId,
                SurveyId: surveyId
            };

            var apiRoute = baseUrl + 'GetQuestionList/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listServiceDetail = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listServiceDetail.then(function (response) {
                $scope.ListSurveyQuestion = [];
                var surveyQuestion = response.data.objSurveyQuestionList;
                $scope.ListSurveyQuestion = surveyQuestion;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        //**********----Get All Answer----***************
        $scope.getAllAnswer = function (surveyId, questionId) {
            //$scope.ListSurveyQuestion = [];

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
                SurveyId: surveyId,
                SurveyQuestionId: questionId
            };

            var apiRoute = baseUrl + 'GetSurveyAnswerList/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listServiceDetail = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listServiceDetail.then(function (response) {
                $scope.ListQuestionAnswer = [];
                var questionAnswer = response.data.objSurveyAnswerList;
                $scope.ListQuestionAnswer = questionAnswer;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        //**********----Create New Question----***************
        $scope.saveQuestion = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '01502'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveSurveyQuestion();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.SaveSurveyQuestion = function () {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };

            var QuestionInfo = {
                SurveyId: $scope.Survey,
                Question: $scope.Question,
            };

            // var HedarTokenPostPut = $scope.CustomerID > 0 ? $scope.HeaderToken.put : $scope.HeaderToken.post;
            var apiRoute = baseUrl + 'SaveUpdateQuestion/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(QuestionInfo) + "]";

            var SaveUpdateQuestion = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateQuestion.then(function (response) {
                if (response.data != "") {
                    $scope.GetSurveyQuestions();
                    Command: toastr["success"]("Save  Successfully!!!!");
                    //$scope.clear();
                }
                else if (response.data == "") {
                        Command: toastr["warning"]("Save Not Successfull!!!!");
                    //$("#save").prop("disabled", false);
                }

            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        //**********----Save New Answer----***************
        $scope.saveAnswer = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '01502'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveQuestionAnswer();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.SaveQuestionAnswer = function () {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };

            var AnswerInfo = {
                QuestionId: $scope.SelectedQuestion,
                Answer: $scope.Answer
            };

            // var HedarTokenPostPut = $scope.CustomerID > 0 ? $scope.HeaderToken.put : $scope.HeaderToken.post;
            var apiRoute = baseUrl + 'SaveAnswer/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(AnswerInfo) + "]";

            var SaveUpdateSurvey = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateSurvey.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.GetAnswers();
                    //$scope.clear();
                }
                else if (response.data == "") {
                        Command: toastr["warning"]("Save Not Successfull!!!!");
                }

            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        //**********----Delete Single Record----***************
        $scope.deleteAnswer = function (dataModel) {
            var IsConf = confirm('You are about to delete ' + dataModel.OFFER_NAME + '. Are you sure?');
        }

        //**********----Reset Record----***************
        $scope.clear = function () {
            $scope.IsHidden = true;
            $scope.IsShow = true;
            $scope.IsHiddenDetail = true
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;

            $scope.hSurveyId = 0
            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Show List";

            
            $scope.Title = '';
            $scope.Description = '';
            $scope.StartDate = '';
            $scope.EndDate = '';

            $("#ddlDistributor").select2("data", { id: '', text: '--Select Distributor--' });
            $("#ddlRoute").select2("data", { id: '', text: '--Select Route--' });
            $("#ddlSurveyFor").select2("data", { id: '', text: '--RSO--' });
            loadAllNewSurvey(0);
        };
    }]);

