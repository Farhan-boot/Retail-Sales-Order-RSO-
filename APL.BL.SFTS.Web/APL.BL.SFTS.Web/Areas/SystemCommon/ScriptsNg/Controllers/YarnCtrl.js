/*
*    Created By: Shamim Uddin;
*    Create Date: 2-6-2016 (dd-mm-yy); Updated Date: 2-6-2016 (dd-mm-yy);
*    Name: 'YarnController';
*    Type: $scope;
*    Purpose: Yarn  For RND;
*    Service Injected: '$scope', 'FinishGoodSerivce','uiGridConstants','filter';
*/

app.controller('YarnController', ['$scope', 'YarnService', 'crudService', 'conversion', '$filter', 'uiGridConstants',
    function ($scope, YarnService, crudService, conversion, $filter, uiGridConstants) {
        //**************************************************Start Vairiable Initialize**************************************************
        var baseUrl = '/SystemCommon/api/Yarn/';
        $scope.permissionPageVisibility = true;
        $scope.UserCommonEntity = {};
        $scope.HeaderToken = {};
        objcmnParam = {};
        $scope.gridOptionsFg = [];
        $scope.gridOptionsYarn = [];

        //var LoggedUserID = $('#hUserID').val();
        //var LoggedCompanyID = $('#hCompanyID').val();

        var isExisting = 0;
        var page = 1;
        var pageSize = 10;
        var isPaging = 0;
        var totalData = 0;
        var ItemTypeID = 3;// 3 type is yarn
        //$scope.IsShow = true;
        //$scope.IsListShow = true;
        $scope.ItemID = 0;
        var acDetailID = null;

        //$scope.btnRawMaterialText = "Save";
        //$scope.btnRawMaterialShowText = "New";
        $scope.PageTitle = 'Yarn Info';
        $scope.ListTitle = 'Yarn List';
        // var checkItemCode = false;
        $scope.hiditemName = "";
        //$scope.grdShowHide = true;
        //$scope.MainForm = false;
        $scope.IsHidden = true;

        //***************************************************End Vairiable Initialize***************************************************
        //$scope.CmnMethod = function (FuncEntity, CmnNum) { $scope.CmnEntity = {}; $scope.CmnEntity = conversion.ExecuteCmnFunc(FuncEntity, CmnNum); if (CmnNum != 0 && CmnNum != 2) { $scope[$scope.CmnEntity.MethodName]($scope.CmnEntity.rowEntity); } if (CmnNum == 2) { for (var i = 0; i < $scope.CmnEntity.MethodName.length; i++) { $scope[$scope.CmnEntity.MethodName[i]]($scope.CmnEntity.rowEntity); } } if (CmnNum == 3) { $scope.cmnbtnShowHideEnDisable(num = (toast = $('.toast-warning').attr("style")) == undefined ? $scope.CmnEntity.num : 7); } }
        //***************************************************Start Common Task for all**************************************************
        frmName = 'frmRawMaterial'; DelFunc = 'delete'; DelMsg = 'ArticleNo'; EditFunc = 'getRawMaterialByID';
        $scope.UserCommonEntity = conversion.UserCmnEntity($scope.menuManager.LoadPageMenu(window.location.pathname), frmName, DelFunc, DelMsg, EditFunc);
        $scope.HeaderToken = conversion.Tokens($scope.tokenManager); $scope.DelParam = {};
        $scope.cmnParam = function () { objcmnParam = conversion.cmnParams(); }
        $scope.CmnMethod = function (FuncEntity, CmnNum) { $scope.CmnEntity = {}; $scope.CmnEntity = conversion.ExecuteCmnFunc(FuncEntity, CmnNum); if (CmnNum != 0 && CmnNum != 2 && CmnNum != 6) { $scope[$scope.CmnEntity.MethodName]($scope.CmnEntity.rowEntity); } if (CmnNum == 2) { for (var i = 0; i < $scope.CmnEntity.MethodName.length; i++) { $scope[$scope.CmnEntity.MethodName[i]]($scope.CmnEntity.rowEntity); } } if (CmnNum == 3) { conversion.SaveUpdatBehave($scope.CmnEntity.num); } }
        $scope.cmnbtnShowHideEnDisable = function (num) { $scope.UserCommonEntity = conversion.btnBehave(num, $scope.UserCommonEntity.IsbtnSaveDisable); }
        $scope.cmnbtnShowHideEnDisable(0);//0=default/reset, 1=Create, 2=Update, 3=Unchange on Update mode btn text, 4=only disable save button, 5=only enable save button
        //****************************************************End Common Task for all***************************************************        

        var LoggedUserID = $scope.UserCommonEntity.loggedUserID;
        var LoggedCompanyID = $scope.UserCommonEntity.loggedCompnyID;

        //************************************************Start Show List Information Dynamic Grid******************************************************       
        $scope.ShowHide = function () {
            $scope.IsHidden = $scope.IsHidden ? false : true;
            if ($scope.IsHidden == true) {
                $scope.clear();
            }
            else {
                $scope.RefreshMasterList();
                $scope.IsShow = false;
            }
        }
        //*************************************************End Show List Information Dynamic Grid*******************************************************

        $scope.GetItemGroups = function () {
            var apiRoute = baseUrl + 'GetItemGroups/';
            var itemGroupes = YarnService.getAllItemGroup(apiRoute, page, pageSize, isPaging, ItemTypeID, LoggedCompanyID);
            itemGroupes.then(function (response) {
                $scope.itemGroupes = response.data;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetItemGroups();


        //**********---- Check input text from database ----***************//
        $scope.AutoCompleteItem = function () {
            $scope.result = [];
            objcmnParam = {
                loggedCompany: 0,
                TableName: 'CmnItemMaster',
                FieldNameOne: 'ItemName',
                FieldNameTwo: 'ItemGroupID',
                id: $scope.drpItemGroup,
                InputString: '%' + $scope.txtbxItemName.split(' ').join('') + '%'
            };

            if ($scope.txtbxItemName != "")
                var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
            var apiRoute = '/SystemCommon/api/SystemCommonDDL/AutoComplete/';
            var Value = YarnService.GetList(apiRoute, cmnParam);
            Value.then(function (response) {
                $scope.result = response.data.ObjParameters;
            },
            function (error) {
                console.log("Error: " + error);
            });

        }



        $scope.CheckItemCode = function () {

            objcmnParam = {
                loggedCompany: LoggedCompanyID,
                TableName: 'CmnItemMaster',
                FieldName: 'ItemName',
                InputString: $scope.txtbxItemName.split(' ').join('')
            };

            if ($scope.txtbxItemName != "")
                // var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
                var apiRoute = '/SystemCommon/api/SystemCommonDDL/CheckInputString/';
            var Value = YarnService.getAllYarn(apiRoute, objcmnParam);
            Value.then(function (response) {
                $scope.Exsintance = response.data.ObjParameters[0].Existance;
                if ($scope.Exsintance == 1) {
                    $scope.txtbxItemName = '';
                    Command: toastr["warning"]("Item Name Already Exist!!!!");
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetUnits = function () {
            var apiRoute = baseUrl + 'GetUnits/';
            var Units = YarnService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
            Units.then(function (response) {
                $scope.Units = response.data;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetUnits();

        $scope.GetColors = function () {
            var apiRoute = baseUrl + 'GetColors/';
            var Colors = YarnService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
            Colors.then(function (response) {
                $scope.Colors = response.data;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetColors();

        $scope.GetSizes = function () {
            var apiRoute = baseUrl + 'GetSizes/';
            var Sizes = YarnService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
            Sizes.then(function (response) {
                $scope.Sizes = response.data;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetSizes();

        $scope.GetBrands = function () {
            var apiRoute = baseUrl + 'GetBrands/';
            var Brands = YarnService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
            Brands.then(function (response) {
                $scope.Brands = response.data;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetBrands();

        $scope.GetModels = function () {
            var apiRoute = baseUrl + 'GetModels/';
            var Models = YarnService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
            Models.then(function (response) {
                $scope.Models = response.data;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetModels();


        $scope.Save = function () {
            isExisting = $scope.ItemID;
            debugger;
            var ACTypeID = "1";
            if (isExisting == 0) {

                var Yarn = {
                    ItemTypeID: ItemTypeID,
                    ItemGroupID: $scope.drpItemGroup,
                    ItemName: $scope.txtbxItemName,
                    UOMID: $scope.drpUOMID,
                    ItemColorID: $scope.drpColor,
                    ItemSizeID: $scope.drpSize,
                    ItemBrandID: $scope.drpBrand,
                    ItemModelID: $scope.drpModel,
                    Note: $scope.txtbxNote,
                    Description: $scope.txtDescription,
                    CreateBy: LoggedUserID,
                    CompanyID: LoggedCompanyID,
                    Count: $scope.txtbxCount
                }
                var cmnParam = "[" + JSON.stringify(Yarn) + "," + JSON.stringify(acDetailID) + "," + JSON.stringify(ACTypeID) + "]";

                var apiRoute = baseUrl + 'SaveYarn/';
                var saveYarn = YarnService.PostMultiData(apiRoute, cmnParam);
                saveYarn.then(function (response) {
                    if (response != "") {
                        var ArtwitUnCode = response;
                        var SplitedArtwitUnCode = ArtwitUnCode.split(",");
                        $scope.ArticleNo = SplitedArtwitUnCode[0];
                        $scope.txtbxUniqueCode = SplitedArtwitUnCode[1];
                        //response.data = 1;
                        //ShowCustomToastrMessage(response);
                        if (response == "1") {
                            $scope.clear();
                            //Command: toastr["success"]("Item Saved successfully.");
                            ShowCustomToastrMessageSaveUpdate(1, $scope.UserCommonEntity);
                            //$scope.GetYarnDetails();
                        }
                        if (response == "-1") {
                            Command: toastr["warning"]("Item Name Already Exists.");
                        }
                        if (response == "0") {
                            //Command: toastr["warning"]("Save not Successful.");
                            ShowCustomToastrMessageSaveUpdate(0, $scope.UserCommonEntity);
                        }
                        //$scope.GetYarnDetails();
                        //$scope.clear();
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });
            }

            else {


                var Yarn = {
                    ItemID: $scope.ItemID,
                    ItemTypeID: ItemTypeID,
                    ItemGroupID: $scope.drpItemGroup,
                    ItemName: $scope.txtbxItemName,
                    UOMID: $scope.drpUOMID,
                    ItemColorID: $scope.drpColor,
                    ItemSizeID: $scope.drpSize,
                    ItemBrandID: $scope.drpBrand,
                    ItemModelID: $scope.drpModel,
                    Note: $scope.txtbxNote,
                    Description: $scope.txtDescription,
                    UpdateBy: LoggedUserID,
                    CompanyID: LoggedCompanyID,
                    Count: $scope.txtbxCount
                }
                var cmnParam = "[" + JSON.stringify(Yarn) + "," + JSON.stringify(acDetailID) + "," + JSON.stringify(ACTypeID) + "]";
                var apiRoute = baseUrl + '/UpdateYarn/';
                var updateYarn = YarnService.PostMultiData(apiRoute, cmnParam);
                updateYarn.then(function (response) {
                    //response.data = -102;
                    //ShowCustomToastrMessage(response);
                    if (response == "1") {                        
                        $scope.clear();
                        ShowCustomToastrMessageSaveUpdate(1, $scope.UserCommonEntity);
                        //Command: toastr["success"]("Item Saved successfully.");
                        //$scope.GetYarnDetails();
                    }
                    if (response == "-1") {
                        Command: toastr["warning"]("Item Name Already Exists.");
                    }
                    if (response == "0") {
                        ShowCustomToastrMessageSaveUpdate(0, $scope.UserCommonEntity);
                        //Command: toastr["warning"]("Update not Successful.");
                    }
                    //$scope.GetYarnDetails();
                    //$scope.clear();

                },
                function (error) {
                    console.log("Error: " + error);
                });
            }

        }


        $scope.clear = function () {
            //checkItemCode = false;
            //$scope.grdShowHide = true;
            //$scope.MainForm = false;
            $scope.ItemID = 0;
            acDetailID = null;
            $scope.hiditemName = "";
            //$scope.btnRawMaterialText = "Save";
            $scope.txtbxItemName = "";
            $scope.txtDescription = "";
            $scope.txtbxNote = "";
            $scope.drpItemGroup,
            $scope.txtbxItemName = "",
            $scope.drpUOMID = "",
            $scope.drpColor = "",
            $scope.drpSize = "",
            $scope.drpBrand = "",
            $scope.drpModel = "",
            $scope.txtbxCount = "";
            $scope.IsHidden = true;

            $("#drpUOMID").select2("data", { id: 0, text: '--Select Unit--' });
            $("#drpBrand").select2("data", { id: 0, text: '--Select Brand--' });
            $("#drpItemGroup").select2("data", { id: 0, text: '--Select Group--' });
            $("#drpColor").select2("data", { id: 0, text: '--Select Color--' });
            $("#drpModel").select2("data", { id: 0, text: '--Select Model--' });
            $("#drpSize").select2("data", { id: 0, text: '--Select Size--' });
        }

        //$scope.ShowHide = function () {
        //    $scope.clear();
        //    if ($scope.btnRawMaterialShowText === "New") {

        //        $scope.btnRawMaterialShowText = "Show List";
        //        $scope.grdShowHide = false;
        //        $scope.MainForm = true;
        //    }
        //    else {
        //        $scope.btnRawMaterialShowText = "New";
        //        $scope.grdShowHide = true;
        //        $scope.MainForm = false;
        //    }
        //}



        //Pagination
        $scope.paginationFg = {
            paginationPageSizesFg: [15, 25, 50, 75, 100, 500, 1000, "All"],
            ddlpageSizeFg: 15, pageNumberFg: 1, pageSizeFg: 15, totalItemsFg: 0,
            getTotalPagesFg: function () {
                return Math.ceil(this.totalItemsFg / this.pageSizeFg);
            },
            pageSizeChangeFg: function () {
                if (this.ddlpageSizeFg == "All")
                    this.pageSizeFg = $scope.paginationFg.totalItemsFg;
                else
                    this.pageSizeFg = this.ddlpageSizeFg
                this.pageNumberFg = 1
                $scope.GetYarnDetails();
            },
            firstPageFg: function () {
                if (this.pageNumberFg > 1) {
                    this.pageNumberFg = 1
                    $scope.GetYarnDetails();
                }
            },
            nextPageFg: function () {
                if (this.pageNumberFg < this.getTotalPagesFg()) {
                    this.pageNumberFg++;
                    $scope.GetYarnDetails();
                }
            },
            previousPageFg: function () {
                if (this.pageNumberFg > 1) {
                    this.pageNumberFg--;
                    $scope.GetYarnDetails();
                }
            },
            lastPageFg: function () {
                if (this.pageNumberFg >= 1) {
                    this.pageNumberFg = this.getTotalPagesFg();
                    $scope.GetYarnDetails();
                }
            }
        };

        $scope.GetYarnDetails = function () {
            // For Loading
            $scope.loaderMore = true;
            $scope.lblMessage = 'loading please wait....!';
            $scope.result = "color-red";

            //Ui Grid
            $scope.cmnParam();
            objcmnParam.pageNumber = $scope.paginationFg.pageNumberFg;
            objcmnParam.pageSize = $scope.paginationFg.pageSizeFg;
            objcmnParam.IsPaging = isPaging;
            objcmnParam.ItemType = ItemTypeID;

            //objcmnParamFg = {
            //    pageNumber: $scope.paginationFg.pageNumberFg,
            //    pageSize: $scope.paginationFg.pageSizeFg,
            //    IsPaging: isPaging,
            //    loggeduser: LoggedUserID,
            //    loggedCompany: LoggedCompanyID,
            //    menuId: 5,
            //    tTypeId: 26,
            //    ItemType: ItemTypeID
            //};

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };

            $scope.gridOptionsFg = {
                columnDefs: [
                    { name: "ArticleNo", displayName: "Article No", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ItemTypeName", title: "Item Type", headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ItemGroupName", title: "Item Group", headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ItemName", title: "Item Name", headerCellClass: $scope.highlightFilteredHeader },
                     { name: "Note", displayName: "Rnd Name", headerCellClass: $scope.highlightFilteredHeader },
                    { name: "Count", title: "Item Count", headerCellClass: $scope.highlightFilteredHeader },
                    { name: "UOMName", title: "Item Unit", headerCellClass: $scope.highlightFilteredHeader },
                    { name: "Color", title: "Item Color", headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SizeName", title: "Item Size", headerCellClass: $scope.highlightFilteredHeader },
                    { name: "BrandName", title: "Item Brand", headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ModelName", title: "Model", headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Option',
                        displayName: "Option",
                        width: '13%',
                        pinnedRight: true,
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        headerCellClass: $scope.highlightFilteredHeader,
                        visible: $scope.UserCommonEntity.visible,
                        cellTemplate: $scope.UserCommonEntity.cellTemplate
                    }
                ],

                enableFiltering: true,
                enableGridMenu: true,
                enableSelectAll: true,
                exporterCsvFilename: 'Yarn.csv',
                exporterPdfDefaultStyle: { fontSize: 9 },
                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
                exporterPdfHeader: { text: "Yarn Type", style: 'headerStyle' },
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

            var apiRoute = baseUrl + 'GetAllYarn/';
            var RowMaterials = YarnService.getAllYarn(apiRoute, objcmnParam);
            RowMaterials.then(function (response) {

                $scope.paginationFg.totalItemsFg = response.data.recordsTotal;
                $scope.gridOptionsFg.data = response.data.yarnlist;
                $scope.loaderMore = false;
            },
            function (error) {
                console.log("Error: " + error);
            });


        }
        $scope.RefreshMasterList = function () {
            $scope.paginationFg.pageNumberFg = 1;
            $scope.GetYarnDetails();
        }
        $scope.RefreshMasterList();

        //$scope.GetYarnDetails();

        $scope.delete = function (dataModel) {
            //var IsConf = confirm('You are about to delete ' + dataModel.ItemName + '. Are you sure?');
            //if (IsConf) {
                var RawMaterial = {
                    ItemID: dataModel.ItemID,
                    DeleteBy: LoggedUserID,
                    CompanyID: LoggedCompanyID
                }
                var apiRoute = baseUrl + 'DeleteYarn/';
                var deleteRowMaterial = YarnService.put(apiRoute, RawMaterial);
                deleteRowMaterial.then(function (response) {
                    response.data = -101;
                    ShowCustomToastrMessage(response);
                    $scope.GetYarnDetails();
                    $scope.clear();
                }, function (error) {
                    console.log("Error: " + error);
                });
            //}
        }

        $scope.getRawMaterialByID = function (dataModel) {
            var apiRoute = baseUrl + 'GetYarn/' + dataModel.ItemID;
            var rowMaterial = YarnService.getRawMaterialByID(apiRoute);
            rowMaterial.then(function (response) {

                //$scope.btnRawMaterialText = "Update";
                //$scope.btnRawMaterialShowText = "Show List";
                //$scope.grdShowHide = false;
                //$scope.MainForm = true;
                $scope.hiditemName = response.data.ItemName;
                $scope.ItemID = response.data.ItemID;
                $scope.txtbxUniqueCode = response.data.UniqueCode;
                $scope.txtbxNote = response.data.Note;
                $scope.txtbxItemName = response.data.ItemName;
                $scope.ArticleNo = response.data.ArticleNo;
                $scope.drpItemGroup = response.data.ItemGropID;
                $scope.txtDescription = response.data.Description;
                $scope.drpUOMID = response.data.UnitId;
                $scope.drpSize = response.data.SizeId;
                $scope.drpColor = response.data.ColorId;
                acDetailID = response.data.AcDetailID;
                $scope.drpBrand = response.data.BrandId;
                $scope.drpModel = response.data.ModelId;
                $scope.txtbxCount = response.data.Count;
                debugger

                if (response.data.ItemGroup != "N/A") {
                    $("#drpItemGroup").select2("data", { id: 0, text: response.data.ItemGroup });
                } else {
                    $("#drpItemGroup").select2("data", { id: 0, text: '--Select Group--' });
                }

                if (response.data.Unit != "N/A") {
                    $("#drpUOMID").select2("data", { id: 0, text: response.data.Unit });
                } else {
                    $("#drpUOMID").select2("data", { id: 0, text: '--Select Unit--' });
                }

                if (response.data.Color != "N/A") {
                    $("#drpColor").select2("data", { id: 0, text: response.data.Color });
                } else {
                    $("#drpColor").select2("data", { id: 0, text: '--Select Color--' });
                }

                if (response.data.Size != "N/A") {
                    $("#drpSize").select2("data", { id: 0, text: response.data.Size });
                } else {
                    $("#drpSize").select2("data", { id: 0, text: '--Select Size--' });
                }

                if (response.data.Brand != "N/A") {
                    $("#drpBrand").select2("data", { id: 0, text: response.data.Brand });
                } else {
                    $("#drpBrand").select2("data", { id: 0, text: '--Select Brand--' });
                }
                if (response.data.Model != "N/A") {
                    $("#drpModel").select2("data", { id: 0, text: response.data.Model });
                } else {
                    $("#drpModel").select2("data", { id: 0, text: '--Select Model--' });
                }
                $scope.IsHidden = true;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.SetItemName = function () {
            //    ItemName = $("#drpItemGroup option:selected").text();
            //    Count = $scope.txtbxCount;
            //    if (ItemName != "" && Count != undefined) {
            //        $scope.txtbxItemName = ItemName + '' + Count;
            //        $scope.ArticleNo = ItemName + '' + Count;
            //    }
            //    else if (Count == null && ItemName != "") {
            //        $scope.txtbxItemName = "";
            //        $scope.ArticleNo = "";
            //   }
            debugger;
            var itemGroupID = $scope.drpItemGroup;
            var apiRoute = baseUrl + 'GetAcDetailsID/';
            var getAcDetail = YarnService.GetAcDetailsID(apiRoute, page, pageSize, isPaging, LoggedCompanyID, itemGroupID);
            getAcDetail.then(function (response) {
                acDetailID = response.data;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
    }]);







///*
//*    Created By: Shamim Uddin;
//*    Create Date: 2-6-2016 (dd-mm-yy); Updated Date: 2-6-2016 (dd-mm-yy);
//*    Name: 'YarnController';
//*    Type: $scope;
//*    Purpose: Yarn  For RND;
//*    Service Injected: '$scope', 'FinishGoodSerivce','uiGridConstants','filter';
//*/

//app.controller('YarnController', ['$scope', 'YarnService', '$filter', 'uiGridConstants',
//    function ($scope, YarnService, $filter, uiGridConstants) {

//        $scope.gridOptionsYarn = [];
//        var objcmnParam = {};

//        var baseUrl = '/SystemCommon/api/Yarn/';
//        var LoggedUserID = $('#hUserID').val();
//        var LoggedCompanyID = $('#hCompanyID').val();

//        var isExisting = 0;
//        var page = 1;
//        var pageSize = 10;
//        var isPaging = 0;
//        var totalData = 0;
//        var ItemTypeID = 3;// 3 type is yarn
//        $scope.IsShow = true;
//        $scope.IsListShow = true;
//        $scope.ItemID = 0;
//        var acDetailID = null;

//        $scope.btnRawMaterialText = "Save";
//        $scope.btnRawMaterialShowText = "New";
//        $scope.PageTitle = 'Yarn Info';
//        $scope.ListTitle = 'Yarn List';
//        // var checkItemCode = false;
//        $scope.hiditemName = "";
//        $scope.grdShowHide = true;
//        $scope.MainForm = false;

//        $scope.GetItemGroups = function () {
//            var apiRoute = baseUrl + 'GetItemGroups/';
//            var itemGroupes = YarnService.getAllItemGroup(apiRoute, page, pageSize, isPaging, ItemTypeID, LoggedCompanyID);
//            itemGroupes.then(function (response) {
//                $scope.itemGroupes = response.data;
//            },
//            function (error) {
//                console.log("Error: " + error);
//            });
//        }
//        $scope.GetItemGroups();


//        $scope.CheckItemCode = function () {

//            objcmnParam = {
//                loggedCompany: LoggedCompanyID,
//                TableName: 'CmnItemMaster',
//                FieldName: 'ItemName',
//                InputString: $scope.txtbxItemName.split(' ').join('')
//            };

//            if ($scope.txtbxItemName != "")
//               // var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
//            var apiRoute = '/SystemCommon/api/SystemCommonDDL/CheckInputString/';
//            var Value = YarnService.getAllYarn(apiRoute, objcmnParam);
//            Value.then(function (response) {
//                $scope.Exsintance = response.data.ObjParameters[0].Existance;
//                if ($scope.Exsintance == 1) {
//                    $scope.txtbxItemName = '';
//                    Command: toastr["warning"]("Item Name Already Exist!!!!");
//                }
//            },
//            function (error) {
//                console.log("Error: " + error);
//            });
//        }

//        $scope.GetUnits = function () {
//            var apiRoute = baseUrl + 'GetUnits/';
//            var Units = YarnService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
//            Units.then(function (response) {
//                $scope.Units = response.data;
//            },
//            function (error) {
//                console.log("Error: " + error);
//            });
//        }
//        $scope.GetUnits();

//        $scope.GetColors = function () {
//            var apiRoute = baseUrl + 'GetColors/';
//            var Colors = YarnService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
//            Colors.then(function (response) {
//                $scope.Colors = response.data;
//            },
//            function (error) {
//                console.log("Error: " + error);
//            });
//        }

//        $scope.GetColors();

//        $scope.GetSizes = function () {
//            var apiRoute = baseUrl + 'GetSizes/';
//            var Sizes = YarnService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
//            Sizes.then(function (response) {
//                $scope.Sizes = response.data;
//            },
//            function (error) {
//                console.log("Error: " + error);
//            });
//        }
//        $scope.GetSizes();

//        $scope.GetBrands = function () {
//            var apiRoute = baseUrl + 'GetBrands/';
//            var Brands = YarnService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
//            Brands.then(function (response) {
//                $scope.Brands = response.data;
//            },
//            function (error) {
//                console.log("Error: " + error);
//            });
//        }
//        $scope.GetBrands();

//        $scope.GetModels = function () {
//            var apiRoute = baseUrl + 'GetModels/';
//            var Models = YarnService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
//            Models.then(function (response) {
//                $scope.Models = response.data;
//            },
//            function (error) {
//                console.log("Error: " + error);
//            });
//        }
//        $scope.GetModels();


//        $scope.save = function () {
//            isExisting = $scope.ItemID;
//            debugger;
//            var ACTypeID = "1";
//            if (isExisting == 0) {

//                var Yarn = {
//                    ItemTypeID: ItemTypeID,
//                    ItemGroupID: $scope.drpItemGroup,
//                    ItemName: $scope.txtbxItemName,
//                    UOMID: $scope.drpUOMID,
//                    ItemColorID: $scope.drpColor,
//                    ItemSizeID: $scope.drpSize,
//                    ItemBrandID: $scope.drpBrand,
//                    ItemModelID: $scope.drpModel,
//                    Note: $scope.txtbxNote,
//                    Description: $scope.txtDescription,
//                    CreateBy: LoggedUserID,
//                    CompanyID: LoggedCompanyID,
//                    Count: $scope.txtbxCount
//                }
//                var cmnParam = "[" + JSON.stringify(Yarn) + "," + JSON.stringify(acDetailID) + "," + JSON.stringify(ACTypeID) + "]";

//                var apiRoute = baseUrl + 'SaveYarn/';
//                var saveYarn = YarnService.PostMultiData(apiRoute, cmnParam);
//                saveYarn.then(function (response) {
//                    if (response.data != "") {
//                        var ArtwitUnCode = response.data;
//                        var SplitedArtwitUnCode = ArtwitUnCode.split(",");
//                        $scope.ArticleNo = SplitedArtwitUnCode[0];
//                        $scope.txtbxUniqueCode = SplitedArtwitUnCode[1];
//                        //response.data = 1;
//                        //ShowCustomToastrMessage(response);
//                        if (response.data == "1") {
//                            Command: toastr["success"]("Item Saved successfully.");
//                        }
//                        if (response.data == "-1") {
//                            Command: toastr["warning"]("Item Name Already Exists.");
//                        }
//                        if (response.data == "0")
//                        {
//                            Command: toastr["warning"]("Save not Successful.");
//                        }
//                        $scope.GetYarnDetails();
//                        $scope.clear();
//                    }

//                }, function (error) {
//                    console.log("Error: " + error);
//                });
//            }

//            else {


//                var Yarn = {
//                    ItemID: $scope.ItemID,
//                    ItemTypeID: ItemTypeID,
//                    ItemGroupID: $scope.drpItemGroup,
//                    ItemName: $scope.txtbxItemName,
//                    UOMID: $scope.drpUOMID,
//                    ItemColorID: $scope.drpColor,
//                    ItemSizeID: $scope.drpSize,
//                    ItemBrandID: $scope.drpBrand,
//                    ItemModelID: $scope.drpModel,
//                    Note: $scope.txtbxNote,
//                    Description: $scope.txtDescription,
//                    UpdateBy: LoggedUserID,
//                    CompanyID: LoggedCompanyID,
//                    Count: $scope.txtbxCount
//                }
//                var cmnParam = "[" + JSON.stringify(Yarn) + "," + JSON.stringify(acDetailID) + "," + JSON.stringify(ACTypeID) + "]";
//                var apiRoute = baseUrl + '/UpdateYarn/';
//                var updateYarn = YarnService.PostMultiData(apiRoute, cmnParam);
//                updateYarn.then(function (response) {
//                    //response.data = -102;
//                    //ShowCustomToastrMessage(response);
//                    if (response.data == "1") {
//                        Command: toastr["success"]("Item Saved successfully.");
//                    }
//                    if (response.data == "-1") {
//                        Command: toastr["warning"]("Item Name Already Exists.");
//                    }
//                    if (response.data == "0") {
//                        Command: toastr["warning"]("Update not Successful.");
//                    }
//                    $scope.GetYarnDetails();
//                    $scope.clear();

//                },
//                function (error) {
//                    console.log("Error: " + error);
//                });
//            }

//        }


//        $scope.clear = function () {
//            //checkItemCode = false;
//            $scope.grdShowHide = true;
//            $scope.MainForm = false;
//            $scope.ItemID = 0;
//            acDetailID = null;
//            $scope.hiditemName = "";
//            $scope.btnRawMaterialText = "Save";
//            $scope.txtbxItemName = "";
//            $scope.txtDescription = "";
//            $scope.txtbxNote = "";
//            $scope.drpItemGroup,
//            $scope.txtbxItemName = "",
//            $scope.drpUOMID = "",
//            $scope.drpColor = "",
//            $scope.drpSize = "",
//            $scope.drpBrand = "",
//            $scope.drpModel = "",
//            $scope.txtbxCount = "";

//            $("#drpUOMID").select2("data", { id: 0, text: '--Select Unit--' });
//            $("#drpBrand").select2("data", { id: 0, text: '--Select Brand--' });
//            $("#drpItemGroup").select2("data", { id: 0, text: '--Select Group--' });
//            $("#drpColor").select2("data", { id: 0, text: '--Select Color--' });
//            $("#drpModel").select2("data", { id: 0, text: '--Select Model--' });
//            $("#drpSize").select2("data", { id: 0, text: '--Select Size--' });
//        }

//        $scope.ShowHide = function () {
//            $scope.clear();
//            if ($scope.btnRawMaterialShowText === "New") {

//                $scope.btnRawMaterialShowText = "Show List";
//                $scope.grdShowHide = false;
//                $scope.MainForm = true;
//            }
//            else {
//                $scope.btnRawMaterialShowText = "New";
//                $scope.grdShowHide = true;
//                $scope.MainForm = false;
//            }
//        }



//        //Pagination
//        $scope.paginationFg = {
//            paginationPageSizesFg: [15, 25, 50, 75, 100, 500, 1000, "All"],
//            ddlpageSizeFg: 15, pageNumberFg: 1, pageSizeFg: 15, totalItemsFg: 0,
//            getTotalPagesFg: function () {
//                return Math.ceil(this.totalItemsFg / this.pageSizeFg);
//            },
//            pageSizeChangeFg: function () {
//                if (this.ddlpageSizeFg == "All")
//                    this.pageSizeFg = $scope.paginationFg.totalItemsFg;
//                else
//                    this.pageSizeFg = this.ddlpageSizeFg
//                this.pageNumberFg = 1
//                $scope.GetYarnDetails();
//            },
//            firstPageFg: function () {
//                if (this.pageNumberFg > 1) {
//                    this.pageNumberFg = 1
//                    $scope.GetYarnDetails();
//                }
//            },
//            nextPageFg: function () {
//                if (this.pageNumberFg < this.getTotalPagesFg()) {
//                    this.pageNumberFg++;
//                    $scope.GetYarnDetails();
//                }
//            },
//            previousPageFg: function () {
//                if (this.pageNumberFg > 1) {
//                    this.pageNumberFg--;
//                    $scope.GetYarnDetails();
//                }
//            },
//            lastPageFg: function () {
//                if (this.pageNumberFg >= 1) {
//                    this.pageNumberFg = this.getTotalPagesFg();
//                    $scope.GetYarnDetails();
//                }
//            }
//        };

//        $scope.GetYarnDetails = function () {
//            // For Loading
//            $scope.loaderMore = true;
//            $scope.lblMessage = 'loading please wait....!';
//            $scope.result = "color-red";

//            //Ui Grid
//            objcmnParamFg = {
//                pageNumber: $scope.paginationFg.pageNumberFg,
//                pageSize: $scope.paginationFg.pageSizeFg,
//                IsPaging: isPaging,
//                loggeduser: LoggedUserID,
//                loggedCompany: LoggedCompanyID,
//                menuId: 5,
//                tTypeId: 26,
//                ItemType: ItemTypeID
//            };

//            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
//                if (col.filters[0].term) {
//                    return 'header-filtered';
//                } else {
//                    return '';
//                }
//            };

//            $scope.gridOptionsFg = {
//                columnDefs: [
//                    { name: "ArticleNo", displayName: "Article No", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
//                    { name: "ItemTypeName", title: "Item Type", headerCellClass: $scope.highlightFilteredHeader },
//                    { name: "ItemGroupName", title: "Item Group", headerCellClass: $scope.highlightFilteredHeader },
//                    { name: "ItemName", title: "Item Name", headerCellClass: $scope.highlightFilteredHeader },
//                    { name: "Count", title: "Item Count", headerCellClass: $scope.highlightFilteredHeader },
//                    { name: "UOMName", title: "Item Unit", headerCellClass: $scope.highlightFilteredHeader },
//                    { name: "Color", title: "Item Color", headerCellClass: $scope.highlightFilteredHeader },
//                    { name: "SizeName", title: "Item Size", headerCellClass: $scope.highlightFilteredHeader },
//                    { name: "BrandName", title: "Item Brand", headerCellClass: $scope.highlightFilteredHeader },
//                    { name: "ModelName", title: "Model", headerCellClass: $scope.highlightFilteredHeader },
//                    {
//                        name: 'Edit',
//                        displayName: "Edit",
//                        width: '5%',
//                        enableColumnResizing: false,
//                        enableFiltering: false,
//                        enableSorting: false,
//                        headerCellClass: $scope.highlightFilteredHeader,
//                        cellTemplate: '<span class="label label-warning label-mini">' +
//                                            '<a ng-href="javascript:void(0);" data-toggle="modal" class="bs-tooltip" title="Edit Info">' +
//                                                '<i class="icon-pencil" ng-click="grid.appScope.getRawMaterialByID(row.entity)"></i>' +
//                                            '</a>' +
//                                        '</span>' +
//                                        '<span class="label label-danger label-mini">' +
//                                            '<a href="javascript:void(0);" class="bs-tooltip" title="Delete" ng-click="grid.appScope.delete(row.entity)">' +
//                                                '<i class="icon-trash"></i>' +
//                                            '</a>' +
//                                        '</span>'
//                    }
//                ],

//                enableFiltering: true,
//                enableGridMenu: true,
//                enableSelectAll: true,
//                exporterCsvFilename: 'Yarn.csv',
//                exporterPdfDefaultStyle: { fontSize: 9 },
//                exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
//                exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
//                exporterPdfHeader: { text: "Yarn Type", style: 'headerStyle' },
//                exporterPdfFooter: function (currentPage, pageCount) {
//                    return { text: currentPage.toString() + ' of ' + pageCount.toString(), style: 'footerStyle' };
//                },
//                exporterPdfCustomFormatter: function (docDefinition) {
//                    docDefinition.styles.headerStyle = { fontSize: 22, bold: true };
//                    docDefinition.styles.footerStyle = { fontSize: 10, bold: true };
//                    return docDefinition;
//                },
//                exporterPdfOrientation: 'portrait',
//                exporterPdfPageSize: 'LETTER',
//                exporterPdfMaxGridWidth: 500,
//                exporterCsvLinkElement: angular.element(document.querySelectorAll(".custom-csv-link-location")),
//            };

//            var apiRoute = baseUrl + 'GetAllYarn/';
//            var RowMaterials = YarnService.getAllYarn(apiRoute, objcmnParamFg);
//            RowMaterials.then(function (response) {

//                $scope.paginationFg.totalItemsFg = response.data.recordsTotal;
//                $scope.gridOptionsFg.data = response.data.objFinishGoods;
//                $scope.loaderMore = false;
//            },
//            function (error) {
//                console.log("Error: " + error);
//            });


//        }
//        $scope.GetYarnDetails();

//        $scope.delete = function (dataModel) {
//            var IsConf = confirm('You are about to delete ' + dataModel.ItemName + '. Are you sure?');
//            if (IsConf) {
//                var RawMaterial = {
//                    ItemID: dataModel.ItemID,
//                    DeleteBy: LoggedUserID,
//                    CompanyID: LoggedCompanyID
//                }
//                var apiRoute = baseUrl + 'DeleteYarn/';
//                var deleteRowMaterial = YarnService.put(apiRoute, RawMaterial);
//                deleteRowMaterial.then(function (response) {
//                    response.data = -101;
//                    ShowCustomToastrMessage(response);
//                    $scope.GetYarnDetails();
//                    $scope.clear();
//                }, function (error) {
//                    console.log("Error: " + error);
//                });
//            }
//        }

//        $scope.getRawMaterialByID = function (dataModel) {
//            var apiRoute = baseUrl + 'GetYarn/' + dataModel.ItemID;
//            var rowMaterial = YarnService.getRawMaterialByID(apiRoute);
//            rowMaterial.then(function (response) {

//                $scope.btnRawMaterialText = "Update";
//                $scope.btnRawMaterialShowText = "Show List";
//                $scope.grdShowHide = false;
//                $scope.MainForm = true;
//                $scope.hiditemName = response.data.ItemName;
//                $scope.ItemID = response.data.ItemID;
//                $scope.txtbxUniqueCode = response.data.UniqueCode;
//                $scope.txtbxNote = response.data.Note;
//                $scope.txtbxItemName = response.data.ItemName;
//                $scope.ArticleNo = response.data.ArticleNo;
//                $scope.drpItemGroup = response.data.ItemGropID;
//                $scope.txtDescription = response.data.Description;
//                $scope.drpUOMID = response.data.UnitId;
//                $scope.drpSize = response.data.SizeId;
//                $scope.drpColor = response.data.ColorId;
//                acDetailID = response.data.AcDetailID;
//                $scope.drpBrand = response.data.BrandId;
//                $scope.drpModel = response.data.ModelId;
//                $scope.txtbxCount = response.data.Count;
//                debugger

//                if (response.data.ItemGroup != "N/A") {
//                    $("#drpItemGroup").select2("data", { id: 0, text: response.data.ItemGroup });
//                } else {
//                    $("#drpItemGroup").select2("data", { id: 0, text: '--Select Group--' });
//                }

//                if (response.data.Unit != "N/A") {
//                    $("#drpUOMID").select2("data", { id: 0, text: response.data.Unit });
//                } else {
//                    $("#drpUOMID").select2("data", { id: 0, text: '--Select Unit--' });
//                }

//                if (response.data.Color != "N/A") {
//                    $("#drpColor").select2("data", { id: 0, text: response.data.Color });
//                } else {
//                    $("#drpColor").select2("data", { id: 0, text: '--Select Color--' });
//                }

//                if (response.data.Size != "N/A") {
//                    $("#drpSize").select2("data", { id: 0, text: response.data.Size });
//                } else {
//                    $("#drpSize").select2("data", { id: 0, text: '--Select Size--' });
//                }

//                if (response.data.Brand != "N/A") {
//                    $("#drpBrand").select2("data", { id: 0, text: response.data.Brand });
//                } else {
//                    $("#drpBrand").select2("data", { id: 0, text: '--Select Brand--' });
//                }
//                if (response.data.Model != "N/A") {
//                    $("#drpModel").select2("data", { id: 0, text: response.data.Model });
//                } else {
//                    $("#drpModel").select2("data", { id: 0, text: '--Select Model--' });
//                }

//            },
//            function (error) {
//                console.log("Error: " + error);
//            });
//        }

//        $scope.SetItemName = function () {
//            //    ItemName = $("#drpItemGroup option:selected").text();
//            //    Count = $scope.txtbxCount;
//            //    if (ItemName != "" && Count != undefined) {
//            //        $scope.txtbxItemName = ItemName + '' + Count;
//            //        $scope.ArticleNo = ItemName + '' + Count;
//            //    }
//            //    else if (Count == null && ItemName != "") {
//            //        $scope.txtbxItemName = "";
//            //        $scope.ArticleNo = "";
//            //   }
//            debugger;
//            var itemGroupID = $scope.drpItemGroup;
//            var apiRoute = baseUrl + 'GetAcDetailsID/';
//            var getAcDetail = YarnService.GetAcDetailsID(apiRoute, page, pageSize, isPaging, LoggedCompanyID, itemGroupID);
//            getAcDetail.then(function (response) {
//                acDetailID = response.data;
//            },
//            function (error) {
//                console.log("Error: " + error);
//            });
//        }
//    }]);
