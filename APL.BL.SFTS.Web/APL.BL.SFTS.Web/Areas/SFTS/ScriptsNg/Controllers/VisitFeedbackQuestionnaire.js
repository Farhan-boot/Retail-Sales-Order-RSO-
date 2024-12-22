/**
 * CurrentOfferCtrl.js
 */
app.controller('FeedbackQuestionnaireCtrl', ['$scope', 'crudService', 'conversion', '$filter', '$localStorage', 'uiGridConstants',
    function ($scope, crudService, conversion, $filter, $localStorage, uiGridConstants) {

        var baseUrl = DirectoryKey +'/SFTS/api/VisitFeedbackQuestionnaire/';
        var isExisting = 0;
        var page = 0;
        var pageSize = 100;
        var isPaging = 0;
        var totalData = 0;

        $scope.btnSaveText = "Save";
        $scope.btnShowText = "Create";

        $scope.PageTitle = 'Existing Questionnaire';
        $scope.ListTitle = 'Questionnaire List';
        $scope.IsCreateIcon = true;
        $scope.IsListIcon = false;
        $scope.IsQuestionShow = false;
        $scope.IsQuestionListShow = false;
        $scope.SaveQuestion = "Save";

        $scope.gridOptionsQuestionnaire = [];

        $scope.IsHidden = true;
        $scope.IsShow = true;

        $scope.ShowHide = function () {
            if ($scope.IsQuestionShow == false) {
                $scope.IsHidden = $scope.IsHidden == true ? false : true;
                if ($scope.IsHidden == true) {
                    $scope.btnShowText = "Create";
                    $scope.IsShow = true;
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;
                    $scope.IsQuestionShow == false;

                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    $scope.PageTitle = 'Existing Questionnaire';
                }
                else {
                    $scope.PageTitle = 'Add New Questionnaire';
                    $scope.btnShowText = "Show List";
                    $scope.btnSaveShow = true;
                    $scope.btnResetShow = true;
                    $scope.btnSaveText = "Save";
                    $scope.IsShow = false;
                    $scope.IsHidden = false;
                    $scope.IsQuestionShow == false;

                    $scope.IsCreateIcon = false;
                    $scope.IsListIcon = true;
                    $scope.clearQuestionnaire();
                }
            } else {
                $scope.btnShowText = "Create";
                $scope.IsShow = true;
                $scope.btnSaveShow = false;
                $scope.btnResetShow = false;
                $scope.IsQuestionShow = false;
                $scope.IsQuestionListShow = false;
                $scope.IsCreateIcon = true;
                $scope.IsListIcon = false;
                $scope.PageTitle = 'Existing Questionnaire';
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

        GetPermission('01901');

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


        //**********----Get Visit Type ----***************
        $scope.loadVisitTypes = function (isPaging) {
            // $("#ddlVisitType").select2("val", "");
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                DistributorID: $scope.Distributor,
                VisitTypeId: 0
                //loggeduser: $scope.loggedUserId,                              
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetVisitTypes/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listVisitTypes = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listVisitTypes.then(function (response) {
                $scope.listVisitType = response.data.objListVisitType;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.loadVisitTypes();


        //**********----Get Center Type ----***************
        $scope.loadCenterTypes = function (isPaging) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                DistributorID: $scope.Distributor,
                CenterTypeId: 0
                //loggeduser: $scope.loggedUserId,                              
            };

            var apiRoute = DirectoryKey + '/SFTS/api/CmnDropdown/GetCenterTypes/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
 
            var listCenterTypes = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listCenterTypes.then(function (response) {
                $scope.listCenterType = response.data.objListCenterType;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.loadCenterTypes();


        //**********----Get All Customer Records----***************
        function loadAllFeedbackQuestionnaire(isPaging) {
            $scope.gridOptionsQuestionnaire.enableFiltering = true;
            $scope.gridOptionsQuestionnaire.enableGridMenu = true;

            // For Loading
            if (isPaging == 0)
                $scope.pagination.pageNumber = 1;

            //For Loading
            $scope.loaderMoreNewQuestionnaire = true;
            $scope.lblMessageForQuestionnaire = 'loading please wait....!';
            $scope.result = "color-red";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsQuestionnaire = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "VISIT_TYPE_NAME", displayName: "Visit Type", title: "Visit Type", width: '27%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ENTITY_TYPE_NAME", displayName: "Entity Type", title: "Entity Type", width: '23%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CENTER_TYPE_NAME", displayName: "Center Type", title: "Center Type", width: '23%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "IS_ACTIVE", displayName: "Status", title: "Status", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Action',
                        displayName: "Action",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        pinnedRight: true,
                        width: '19%',
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<div style="padding-left: 10px">' +
                                      '<span class="label label-info label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="Edit" ng-click="grid.appScope.getQuestionnaire(row.entity)">' +
                                        '<i class="icon-edit" aria-hidden="true"></i> Edit' +
                                      '</a>' +
                                      '</span>' +
                                      '<span class="label label-success label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="Add Question" ng-click="grid.appScope.AddNewQuestion(row.entity)">' +
                                        '<i class="icon-external-link" aria-hidden="true"></i> Add Question' +
                                      '</a>' +
                                      '</span>' +
                                      '<span class="label label-warning label-mini" style="text-align:center !important;">' +
                                      '<a href="" title="Delete" ng-click="grid.appScope.delete(row.entity)">' +
                                        '<i class="icon-trash" aria-hidden="true"></i> Delete' +
                                      '</a>' +
                                      '</span>' +
                                      '</div>'
                    }
                ],

                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                enableFiltering: true,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'Customer.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Customer", style: 'headerStyle' },
                exporterPdfFooter: function (currentPage, pageCount) {
                    return { text: currentPage.toString() + ' of ' + pageCount.toString(), style: 'footerStyle' };
                },
                exporterPdfCustomFormatter: function (docDefinition) {
                    docDefinition.styles.headerStyle = { fontSize: 22, bold: true };
                    docDefinition.styles.footerStyle = { fontSize: 10, bold: true };
                    return docDefinition;
                },
                exporterPdfOrientation: 'portrait',
                exporterPdfPageSize: 'LETTER',
                exporterPdfMaxGridWidth: 500,
                exporterCsvLinkElement: angular.element(document.querySelectorAll(".custom-csv-link-location")),
            };

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                loggeduser: $scope.loggedUserId,
            };
            var apiRoute = baseUrl + 'GetFeedbackQuestionnaires/';

            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listFeedbackQuestionnaire = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listFeedbackQuestionnaire.then(function (response) {
                $scope.pagination.totalItems = response.data.recordsTotal;
                $scope.gridOptionsQuestionnaire.data = response.data.feedbackQuestionnaireList;
                $scope.loaderMoreNewQuestionnaire = false;
                $scope.QuestionnaireList = response.data.feedbackQuestionnaireList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        loadAllFeedbackQuestionnaire(0);


        //**********----Get Single Record----***************
        $scope.getQuestionnaire = function (dataModel) {
            $scope.IsHidden = false;
            $scope.IsShow = false;
            $scope.PageTitle = 'Update Questionnaire';
            $scope.btnSaveText = "Update";
            $scope.btnShowText = "Show List";
            $scope.IsQuestionShow = false;
            $scope.IsQuestionListShow = false;
            $scope.btnSaveShow = true;
            $scope.btnResetShow = true;
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;


            $scope.hQuestionnaireId = dataModel.QUESTIONNAIRE_ID;
            $scope.VisitType = dataModel.VISIT_TYPE_ID;
            $scope.EntityType = dataModel.ENTITY_TYPE_ID;
            $scope.CenterType = dataModel.CENTER_TYPE_ID;
            $scope.IsActive = dataModel.IS_ACTIVE == "Active" ? true : false;

            $("#ddlVisitType").select2("data", { id: dataModel.VISIT_TYPE_ID, text: dataModel.VISIT_TYPE_NAME });
            $("#ddlEntityType").select2("data", { id: dataModel.ENTITY_TYPE_ID, text: dataModel.ENTITY_TYPE_NAME });
            $("#ddlCenterType").select2("data", { id: dataModel.CENTER_TYPE_ID, text: dataModel.CENTER_TYPE_NAME });
        };


        //**********----Add New Question----***************
        $scope.AddNewQuestion = function (dataModel) {
            $scope.PageTitle = 'Add New Question';
            $scope.IsShow = false;
            $scope.IsHidden = true;
            $scope.IsQuestionShow = true;
            $scope.IsQuestionListShow = true;
            $scope.btnShowText = "Show Questionnaire";
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;

            $scope.hQuestionnaireId = dataModel.QUESTIONNAIRE_ID;
            $scope.DisplayVisitType = dataModel.VISIT_TYPE_NAME;
            $scope.DisplayEntityType = dataModel.ENTITY_TYPE_NAME;
            $scope.DisplayCenterType = dataModel.CENTER_TYPE_NAME;
            $scope.loadFeedbackQuestion($scope.hQuestionnaireId, 0);          
        };

        $scope.loadFeedbackQuestion = function (QuestnnairId, QuestionId) {
            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                QuestionnaireId: QuestnnairId,
                FeedbackQuestionId: QuestionId
            };

            var apiRoute = baseUrl + 'GetFeedbackQuestions/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listFeedbackQuestion = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listFeedbackQuestion.then(function (response) {
                $scope.FeedbackQuestionList = response.data.feedbackQuestionList;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        //**********----Create New Questionnaire----***************

        $scope.saveQuestionnaire = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '01902'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveVisitFeedbackQuestionnaire();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.SaveVisitFeedbackQuestionnaire = function () {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                //loggeduser: $scope.loggedUserId,
            };

            var QuestionnaireInfo = {
                QuestionnaireId: $scope.hQuestionnaireId == undefined || $scope.hQuestionnaireId == null ? 0 : $scope.hQuestionnaireId,
                VisitEntityType: $scope.EntityType,
                CenterTypeId: $scope.CenterType,
                VisitTypeId: $scope.VisitType,
                IsActive: $scope.IsActive
            };

            // var HedarTokenPostPut = $scope.CustomerID > 0 ? $scope.HeaderToken.put : $scope.HeaderToken.post;
            var apiRoute = baseUrl + 'SaveUpdateQuestionnaire/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(QuestionnaireInfo) + "]";

            var SaveUpdateQuestionnaire = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateQuestionnaire.then(function (response) {
                // debugger;
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clearQuestionnaire();
                    $scope.IsHidden = true;
                    $scope.IsShow = true;
                    $scope.btnShowText = "Create";
                    $scope.PageTitle = 'Add New Questionnaire';
                    $scope.btnSaveShow = false;
                    $scope.btnResetShow = false;
                    $scope.IsCreateIcon = true;
                    $scope.IsListIcon = false;
                    loadAllFeedbackQuestionnaire(0);
                }
                else if (response.data == "") {
                        Command: toastr["warning"]("Save Not Successfull!!!!");
                    $("#save").prop("disabled", false);
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.clearQuestionnaire = function () {
            $("#ddlVisitType").select2("data", { id: '', text: '--Select Visit Type--' });
            $("#ddlEntityType").select2("data", { id: '', text: '--Select Entity Type--' });
            $("#ddlCenterType").select2("data", { id: '', text: '--Select Center Type--' });
            $scope.btnSaveText = "Save";
            $scope.PageTitle = 'Add New Questionnaire';
            $scope.VisitType = '';
            $scope.EntityType = '';
            $scope.CenterType = '';
            $scope.IsActive = false;
            $scope.hQuestionnaireId = 0;
        }

        $scope.clearQuestion = function () {
            $scope.DisplayOrder = '';
            $scope.Question = '';
            $scope.hQuestionId = 0;
            $scope.SaveQuestion = "Save";
            $scope.PageTitle = 'Add New Question';
        }

     
        //**********----Create New Record----***************

        $scope.saveQuestion = function () {
            objcmnParam = {
                loggeduser: $scope.loggedUserId,
                PermissionCode: '01902'
            };

            var apiRoute = DirectoryKey + '/SFTS/api/Permission/GetRoleWisePermission/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var roleWisePermission = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            roleWisePermission.then(function (response) {
                $scope.listRoleWisePermission = response.data.roleWisePermission;
                IsPermitted = response.data.IsPermitted;
                if (IsPermitted == true) {
                    $scope.SaveVisitFeedbackQuestion();
                } else {
                    Command: toastr["warning"]("You have no permission for this operation!");
                    return;
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        };

        $scope.SaveVisitFeedbackQuestion = function () {

            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                //loggeduser: $scope.loggedUserId,
            };

            var QuestionInfo = {
                FeedbackQuestionId: $scope.hQuestionId == undefined || $scope.hQuestionId == null ? 0 : $scope.hQuestionId,
                QuestionnaireId: $scope.hQuestionnaireId,
                QuestionText: $scope.Question,
                DisplayOrder: $scope.DisplayOrder
            };

            var apiRoute = baseUrl + 'SaveUpdateQuestion/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "," + JSON.stringify(QuestionInfo) + "]";

            var SaveUpdateQuestion = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            SaveUpdateQuestion.then(function (response) {
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.DisplayOrder = '';
                    $scope.Question = '';
                    $scope.hQuestionId = 0;
                    $scope.SaveQuestion = "Save";
                    $scope.PageTitle = 'Add New Questionnaire';
                    $scope.loadFeedbackQuestion($scope.hQuestionnaireId);
                }
                else if (response.data == "") {
                        Command: toastr["warning"]("Save Not Successfull!!!!");
                    $("#save").prop("disabled", false);
                }

            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetQuestion = function (QuestionId) {
            $scope.hQuestionId = QuestionId;
            $scope.SaveQuestion = "Update";
            $scope.PageTitle = 'Update Question';


            objcmnParam = {
                pageNumber: page,
                pageSize: pageSize,
                IsPaging: isPaging,
                QuestionnaireId: $scope.hQuestionnaireId,
                QuestionId: $scope.hQuestionId
            };

            var apiRoute = baseUrl + 'GetFeedbackQuestions/';
            var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";

            var listFeedbackQuestion = crudService.GetList(apiRoute, cmnParam, $scope.HeaderToken);
            listFeedbackQuestion.then(function (response) {
                $scope.FbackQuestionList = response.data.feedbackQuestionList;
                $scope.Question = $scope.FbackQuestionList[0].QUESTION_TEXT;
                $scope.DisplayOrder = $scope.FbackQuestionList[0].DISPLAY_ORDER;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }




        //**********----Delete Single Record----***************
        $scope.delete = function (dataModel) {
            if (permissionCode != '01902') {
                Command: toastr["warning"]("You have no permission for this operation!");
                return;
            }

            var IsConf = confirm('You are about to delete ' + dataModel.QUESTION_TEXT + '. Are you sure?');
        }

        //**********----Reset Record----***************
        $scope.clear = function () {
            $scope.IsHidden = true;
            $scope.IsShow = true;
            $scope.IsHiddenDetail = true
            $scope.IsCreateIcon = false;
            $scope.IsListIcon = true;

            $scope.btnSaveText = "Save";
            $scope.btnShowText = "Show List";

            $scope.hSurveyId = 0;
            $scope.Title = '';
            $scope.Description = '';
            $scope.StartDate = '';
            $scope.EndDate = '';

            $("#ddlDistributor").select2("data", { id: '', text: '--Select Distributor--' });
            $("#ddlRoute").select2("data", { id: '', text: '--Select Route--' });
            loadAllFeedbackQuestionnaire(0);
        };
    }]);

