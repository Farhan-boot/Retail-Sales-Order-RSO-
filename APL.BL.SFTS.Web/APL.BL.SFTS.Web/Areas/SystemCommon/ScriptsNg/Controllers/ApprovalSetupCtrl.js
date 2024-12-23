﻿/**
* ApprovalSetupCtrl.js
*/

app.controller('approvalSetupCtrl', function ($scope, approvalSetupService, crudService, menuService, conversion, $filter) {
    var baseUrl = '/SystemCommon/api/ApprovalSetup/';
    var isExisting = 0;
    var page = 1;
    var pageSize = 300;
    var isPaging = 0;
    var totalData = 0;
    $scope.ListCompany = [];
    $scope.IsActiveChkBox = true;
    $scope.ListStatus = [];
    $scope.ListMenues = [];
    $scope.ListOrganogram = [];
    $scope.ListStatusBy = [];
    $scope.listWorkFlowDetail = [];
    $scope.WorkFlowID = 0;
    $scope.WorkFlowDetailID = 0;
    $scope.drpPageTitle = "Branch List";
    // $scope.hfIndex = "";

    var LoginUserID = $('#hUserID').val();
    var LoginCompanyID = $('#hCompanyID').val();
    $scope.LgUser = $('#hUserID').val();

    $scope.btnApprovalSetupSaveText = "Save";
    $scope.btnApprovalSetupShowText = "Show List";
    $scope.btnPIReviseText = "Revise";
    $scope.PageTitle = 'Create Approval Setup Entry';
    $scope.ListTitle = 'Approval ';
    $scope.ListTitleApprovalMasters = 'Approval Setup Records';
    $scope.ListTitleApprovalDeatails = 'Approval Setup';

    $scope.IsApprovalDetailChkBox = 0;
    $scope.IsDepartment = 0; 
    $scope.TeamDetails = [];

    //*************---Show and Hide Order---**********//
    $scope.IsHidden = true;
    $scope.IsShow = true;
    $scope.IsHiddenDetail = true;
    $scope.ShowDetailsList = false;
    $scope.ShowHide = function () {
        $scope.IsHidden = $scope.IsHidden == true ? false : true; 
        if ($scope.IsHidden == true) {
            $scope.btnApprovalSetupShowText = "Show List";
            $scope.IsShow = true;
            $scope.ShowDetailsList = false;
        }
        else {
            $scope.btnApprovalSetupShowText = "Create";
            $scope.IsShow = false;
            $scope.IsHidden = false;
            $scope.ShowDetailsList = true; 
        }
        $scope.btnApprovalSetupSaveText = "Save";
    }

    //**********----Get Status DropDown On Page Load----***************
    function loadRecords_Status(isPaging) {
        var apiRoute = '/SystemCommon/api/SystemCommonDDL/GetStatus/';
        var listStatus = menuService.GetStatus(apiRoute, page, pageSize, isPaging);
        listStatus.then(function (response) {
            $scope.ListStatus = response.data;
            $scope.lstStatusList = response.data[0].StatusID;
            $("#ddlStatus").select2("data", { id: response.data[0].StatusID, text: response.data[0].StatusName });
        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    loadRecords_Status(0);

    //**********----Get Menu DropDown On Page Load----***************
    function loadRecords_Menues(isPaging) {
        var apiRoute = '/SystemCommon/api/SystemCommonDDL/GetMenues/';
        var listMenues = menuService.GetDrpMenues(apiRoute, page, pageSize, isPaging);
        listMenues.then(function (response) {
            $scope.ListMenues = response.data;
            //$scope.lstMenuList =  response.data[0].MenuID;
            //$("#ddlMenu").select2("data", { id: response.data[0].MenuID, text: response.data[0].MenuName });

            $scope.lstMenuList =0;
            $("#ddlMenu").select2("data", { id: '', text: '--Select Menu--' });
        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    loadRecords_Menues(0);

    //**********----Get Company DropDown On Page Load----***************
    function loadRecords_Company(isPaging) {
        var apiRoute = '/SystemCommon/api/SystemCommonDDL/GetCompany/';
        var listCompany = menuService.GetCompanies(apiRoute, page, pageSize, isPaging);
        listCompany.then(function (response) {
            $scope.ListCompany = response.data;  //Set Default
            //$scope.lstCompanyList = response.data[0].CompanyID;
            //$("#ddlCompany").select2("data", { id: response.data[0].CompanyID, text: response.data[0].CompanyName }); 
            $scope.lstCompanyList = 0;
            $("#ddlCompany").select2("data", { id: '', text: '--Select Company--' });
        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    loadRecords_Company(0);

    //*******************organogram  parent DropDown On Page Load-- ***********
    function loadRecords_Organogram(isPaging) {
        var apiRoute = '/SystemCommon/api/SystemCommonDDL/GetOrganogram/';
        var listOrganograms = menuService.GetDrpOrganograms(apiRoute, 1, 0, page, pageSize, isPaging);
        listOrganograms.then(function (response) {
            $scope.ListOrganogram = response.data;
            $scope.lstOrganogramList = 0;
            //$("#ddlBranch").select2("data", { id: response.data[0].OrganogramID, text: response.data[0].OrganogramName });
        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    loadRecords_Organogram(0);

    $scope.GetBranchs = function () {
        var apiRoute = baseUrl + 'GetBranchDetails/';
        var _brnach = approvalSetupService.getBranch(apiRoute, page, pageSize, isPaging, LoginCompanyID);
        _brnach.then(function (response) {
            console.log(response.data);
            $scope.Branches = response.data;
        },
        function (error) {
            console.log("Error: " + error);
        });

    }
    $scope.GetBranchs();


    //**********---- Get StatusBy  Records ----*************** //
    function loadStatusByRecords(isPaging) {
        var apiRoute = '/Sales/api/PI/GetPISalesPerson/';
        var listStatusBy = crudService.getModel(apiRoute, page, pageSize, isPaging);
        listStatusBy.then(function (response) {
            $scope.ListStatusBy = response.data;
            $scope.lstStatusByList = response.data[0].UserID;
            $("#ddlStatusBy").select2("data", { id: response.data[0].UserID, text: response.data[0].UserFullName });
        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    //loadStatusByRecords(0);

    //**********----Get User DropDown On Page Load----***************
    function loadRecords_User(isPaging) {
        var apiRoute = '/SystemCommon/api/SystemCommonDDL/GetUser/';
        var processListUser = crudService.getAllIncludingCompanyLog(apiRoute, LoginCompanyID, LoginUserID, page, pageSize, isPaging);
        processListUser.then(function (response) {
            $scope.ListStatusBy = response.data;
            //$scope.lstStatusByList = response.data[0].UserID;
            //$("#ddlStatusBy").select2("data", { id: response.data[0].UserID, text: response.data[0].UserFullName });

            //$scope.ListUser = response.data;
            //// $("#userDropDown").select2("data", { id: $scope.ListUser[0].UserID, text: $scope.ListUser[0].UserFullName });
            //$("#userDropDown").select2("data", { id: 0, text: '--Select User--' });
        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    loadRecords_User(0);

    //**********---- Get All Approval Setup Master Record  ----*************** //
    function loadApprovalSetupRecords(isPaging) {
        var apiRoute = baseUrl + 'GetApprovalSetupRecords/'; // by viewModel
        var listApprovalSetupRecords = approvalSetupService.getApprovalSetupList(apiRoute);
        listApprovalSetupRecords.then(function (response) {
            $scope.listApprovalSetupRecords = response.data
        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    loadApprovalSetupRecords(0);

    $scope.IsTeamChange=function(checked)
    { 
        $scope.IsDepartment = 0;
        $("#uniform-chkIsDepartment").find("span").removeClass("checked");
        $scope.TeamDetails = [];
        $scope.drpTeams = 0;
        $("#drpTeams").select2("data", { id: '', text: '--Select Team--' });
        $scope.txtbxBranch = "";
    }

    //**********----add approval setup from form ----***************//
    $scope.add = function () {
        var TempEmployeeID= $scope.lstStatusByList; 
        var duplicateItem = 0;
        angular.forEach($scope.TeamDetails, function (item) {
            if (TempEmployeeID == item.EmployeeID) {
                duplicateItem = 1;
                return false;
            }
        });
        
        if ((duplicateItem === 0)) {
            $scope.TeamDetails.push({
                WorkFlowID: $scope.WorkFlowID,
                WorkFlowDetailID: $scope.WorkFlowDetailID,
                StatusID: $scope.lstStatusList,
                StatusName: $("#ddlStatus").select2('data').text,
                EmployeeID: $scope.lstStatusByList,
                StatusBy: $("#ddlStatusBy").select2('data').text,
                MenuName: $("#ddlMenu").select2('data').text,
                CompanyID: $scope.lstCompanyList,
                Sequence: $scope.Sequence,
                IsDeleted: false
            });
            $scope.ClearDetail();
        }
        else {
            Command: toastr["warning"]("UserName Already Exists!!!!");
        }
    }

    $scope.deleteDetails = function (dataModel) {
        if ($scope.IsApprovalDetailChkBox==1)
        {
            Command: toastr["warning"]("Update Team Setup....!!!!");
            return;
        }
        var tempList = $scope.TeamDetails;
        $scope.TeamDetails = [];

        var IsConf = confirm('You are about to delete . Are you sure?');
        if (IsConf) {
            angular.forEach(tempList, function (value, key) {
                if (value.StatusBy != dataModel.StatusBy) {
                    var objNew = {};
                    objNew.WorkFlowID = value.WorkFlowID;
                    objNew.WorkFlowDetailID = value.WorkFlowDetailID;
                    objNew.StatusID = value.StatusID;
                    objNew.StatusName = value.StatusName;
                    objNew.EmployeeID = value.EmployeeID;
                    objNew.StatusBy = value.StatusBy;
                    objNew.MenuName = value.MenuName;
                    objNew.CompanyID = value.CompanyID;
                    objNew.Sequence = value.Sequence;
                    objNew.IsDeleted = false;
                    $scope.TeamDetails.push(objNew);
                }
            });
        }
    }



    $scope.ClearDetail = function () {
        $scope.Sequence = '';
        $scope.lstStatusList = 0;
        $scope.lstStatusByList = 0;
        $("#ddlStatus").select2("data", { id: 0, text: '--Select Status--' });
        $("#ddlStatusBy").select2("data", { id: 0, text: '--Select Status By--' });
    }

    //**********----delete  Record from ListPIDetails----***************//
    $scope.deleteStatus = function (index) {
        $scope.listWorkFlowDetail.splice(index, 1);
    };


    //**********----Load Approval Records detail Form master workflow List By select WorkflowID ----***************//
    $scope.loadApprovalForUpdate = function (dataModel) {
        $scope.WorkFlowID = dataModel.WorkFlowID;
        $scope.IsActiveChkBox = dataModel.IsActive;
        $scope.Sequence = "";//dataModel.Sequence; 
        var workFlowID = dataModel.WorkFlowID;
        var apiRoute = baseUrl + 'GetApprovalDetailsByWorkFlowID/';
        $scope.listWorkFlowDetail = [];
        var listApprovalDetailRecords = approvalSetupService.getApprovalListByWorkFlowID(apiRoute, workFlowID);
        listApprovalDetailRecords.then(function (response) {
            //$scope.listWorkFlowDetail = response.data
            $scope.TeamDetails = response.data;
            $scope.lstOrganogramList = $scope.TeamDetails[0].BranchID;
            $scope.txtbxBranch = $scope.TeamDetails[0].BranchName;
             
            if ($scope.TeamDetails[0].IsDepartment)
            {
                $scope.IsDepartment = 1;
                $("#uniform-chkIsDepartment").find("span").addClass("checked");
            }
            else
            {
                $scope.IsDepartment = 0;
                $("#uniform-chkIsDepartment").find("span").removeClass("checked");
            }

            if ($scope.TeamDetails[0].IsTeamWiseSetup) {
                $scope.IsApprovalDetailChkBox = 1;
                $("#uniform-chkIsApprovalDetail").find("span").addClass("checked");
            }
            else {
                $scope.IsApprovalDetailChkBox = 0;
                $("#uniform-chkIsApprovalDetail").find("span").removeClass("checked");
            }
           
            if ($scope.TeamDetails[0].BranchID > 0) {
                //$scope.getTemsByDepartmentID(dataModel.BranchID);
                var departmentID = $scope.TeamDetails[0].BranchID;
                var apiRoute = baseUrl + 'GetTemsByDepartmentID/';
                var _team = approvalSetupService.getTeam(apiRoute, page, pageSize, isPaging, departmentID);
                _team.then(function (response) {
                    $scope.teams = response.data;
                    $scope.drpTeams = $scope.TeamDetails[0].TeamID;
                    $("#drpTeams").select2("data", { id: $scope.TeamDetails[0].TeamID, text: $scope.TeamDetails[0].TeamName });

                     
                },
                function (error) {
                    console.log("Error: " + error);
                });

            } 
        },
        function (error) {
            console.log("Error: " + error);
        });

        $scope.lstMenuList = dataModel.MenuID;
        $("#ddlMenu").select2("data", { id: dataModel.MenuID, text: dataModel.MenuName });
        $scope.lstCompanyList = dataModel.CompanyID;
        $("#ddlCompany").select2("data", { id: dataModel.CompanyID, text: dataModel.CompanyName });
        $scope.lstOrganogramList = dataModel.OrganogramID;
        $("#ddlBranch").select2("data", { id: dataModel.OrganogramID, text: dataModel.OrganogramName });
        $scope.lstStatusList = '';
        $("#ddlStatus").select2("data", { id: '', text: '--Select Status--' });
        $scope.lstStatusByList = '';
        $("#ddlStatusBy").select2("data", { id: '', text: '--Select Status By--' });
        $scope.btnApprovalSetupSaveText = "Update";
        $scope.btnApprovalSetupShowText = "Show List";
        $scope.IsHidden = true;
        $scope.IsShow = true;
        $scope.ShowDetailsList = false; 
        $scope.bool = false;
        

       
    };

    // ..... Load approval detail record to detail form by  select detail record WorkFlowDetailID ........//
    $scope.loadApprovalForUpdateDetails = function (dataModel) {
        $scope.lstMenuList = dataModel.MenuID;
        $("#ddlMenu").select2("data", { id: dataModel.MenuID, text: dataModel.MenuName });
        $scope.lstCompanyList = dataModel.CompanyID;
        $("#ddlCompany").select2("data", { id: dataModel.CompanyID, text: dataModel.CompanyName });
        $scope.lstOrganogramList = dataModel.OrganogramID;
        $("#ddlBranch").select2("data", { id: dataModel.OrganogramID, text: dataModel.OrganogramName });
        $scope.lstStatusList = dataModel.StatusID;
        $("#ddlStatus").select2("data", { id: dataModel.StatusID, text: dataModel.StatusName });
        $scope.lstStatusByList = dataModel.UserID;
        $("#ddlStatusBy").select2("data", { id: dataModel.UserID, text: dataModel.UserFullName });
        $scope.Sequence = dataModel.Sequence;
        $scope.WorkFlowDetailID = dataModel.WorkFlowDetailID;
        $scope.hfIndex = $scope.listWorkFlowDetail.indexOf(dataModel);
    }

     

    //**********----Save and Update CmnWorkFlowMaster and CmnWorkFlowDetail  Records----***************//
    $scope.save = function () {
        debugger
        var workFlowMaster = {
            WorkFlowID: $scope.WorkFlowID,
            MenuID: $scope.lstMenuList,
            UserTeamID: $scope.drpTeams,
            BranchID: $scope.lstOrganogramList,
            IsActive: $scope.IsActiveChkBox,
            IsTeamWiseSetup: $scope.IsApprovalDetailChkBox,
            IsDepartment:$scope.IsDepartment,
            CompanyID: $scope.lstCompanyList,
            CreateBy: LoginUserID
        };

        var workFlowMasterDetail = $scope.TeamDetails;
        if ($scope.TeamDetails.length > 0) {
            var apiRoute = baseUrl + 'SaveUpdateApprovalSetup/';
            var ApprovalSetupCreateUpdate = approvalSetupService.postApprovalMasterDetail(apiRoute, workFlowMaster, workFlowMasterDetail);
            ApprovalSetupCreateUpdate.then(function (response) {
                var result = 0;
                if (response.data != "") {
                    Command: toastr["success"]("Save  Successfully!!!!");
                    $scope.clear();
                }
                
            },
            function (error) {
                console.log("Error: " + error);
                Command: toastr["warning"]("Save Not Successful!!!!");
            });
        }
        else if ($scope.TeamNeams.length >= 0) {
                Command: toastr["warning"]("Add Approval Setup!!!!");
        }
    };

    //**********----Reset Record----***************//
     

    $scope.clear = function () {
        loadApprovalSetupRecords(0);
        $scope.IsHidden = true;
        $scope.IsShow = true;
        $scope.IsHiddenDetail = true;
        $scope.btnApprovalSetupSaveText = "Save";
        $scope.listPIMaster = [];
        $scope.listWorkFlowDetail = [];
        $scope.WorkFlowID = 0;
        $scope.WorkFlowDetailID = 0;
        $scope.Sequence = '';
        $scope.IsActiveChkBox = true;
        $scope.lstMenuList = '';
        $("#ddlMenu").select2("data", { id: '', text: '--Select Menu--' });
        $scope.lstCompanyList = '';
        $("#ddlCompany").select2("data", { id: '', text: '--Select Company--' });
        $scope.lstOrganogramList = '';
        $("#ddlBranch").select2("data", { id: '', text: '--Select Branch--' });
        $scope.lstStatusList = '';
        $("#ddlStatus").select2("data", { id: '', text: '--Select Status--' });
        $scope.lstStatusByList = '';
        $("#ddlStatusBy").select2("data", { id: '', text: '--Select Status By--' });

        $scope.TeamDetails = [];
        $scope.drpTeams = 0;
        $("#drpTeams").select2("data", { id: '', text: '--Select Team--' });
        $scope.txtbxBranch = "";
        $scope.IsApprovalDetailChkBox = 0;
        $("#uniform-chkIsApprovalDetail").find("span").removeClass("checked");
        $scope.IsDepartment = 0;
        $("#uniform-chkIsDepartment").find("span").removeClass("checked");
        $scope.ShowHide();
    };

    $scope.selectNode = function (val) {
        $scope.txtbxBranchTemp = val.Name; 
        $scope.getTemsByDepartmentID(val.ID); 
    }


    $scope.getTemsByDepartmentID = function (departmentID) {

        var apiRoute = baseUrl + 'GetTemsByDepartmentID/';
        var _team = approvalSetupService.getTeam(apiRoute, page, pageSize, isPaging, departmentID);
        _team.then(function (response) {
            $scope.teams = response.data; 
            $scope.TeamDetails = [];
            $scope.drpTeams = 0;
            $("#drpTeams").select2("data", { id: '', text: '--Select Team--' });
            $scope.lstOrganogramList = 0;
            $scope.txtbxBranch = '';
            $scope.txtbxBranch = $scope.txtbxBranchTemp;
            $scope.lstOrganogramList = departmentID;
        },
        function (error) {
            console.log("Error: " + error);
        });

    }

    $scope.GetTeamsUserByTemID = function () {
        var apiRoute = baseUrl + 'GetTeamsUserByTemID/' + $scope.drpTeams;
        var _team = approvalSetupService.getAll(apiRoute);
        _team.then(function (response) {
            $scope.TeamDetails = response.data;
        },
        function (error) {
            console.log("Error: " + error);
        });

    }
});



