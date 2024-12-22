/*
*    Created By: Shamim Uddin;
*    Create Date: 2-6-2016 (dd-mm-yy); Updated Date: 2-6-2016 (dd-mm-yy);
*    Name: 'RawMateraialController';
*    Type: $scope;
*    Purpose: Raw Material For RND;
*    Service Injected: '$scope', 'RowMaterialService','uiGridConstants','filter';
*/

app.controller('RawMateraialController', ['$scope', 'RowMaterialService', '$filter', 'uiGridConstants',
    function ($scope, RowMaterialService, $filter, uiGridConstants) {
        $scope.gridOptionsRm = [];
        var objcmnParamRm = {};
        var baseUrl = '/SystemCommon/api/RawMaterial/';

        var LoggedUserID = $('#hUserID').val();
        var LoggedCompanyID = $('#hCompanyID').val();

        var isExisting = 0;
        var page = 1;
        var pageSize = 10;
        var isPaging = 0;
        var totalData = 0;
        $scope.IsShow = true;
        $scope.IsListShow = true;
        $scope.ItemID = 0;
        var ItemTypeID = 2;
        var parentID = 0;
        var acDetailID = null;
        $scope.drpPageTitle = 'Item Group List';
        $scope.btnRawMaterialText = "Save";
        $scope.btnRawMaterialShowText = "Raw Material Entry";
        $scope.PageTitle = 'Material Setup';
        $scope.ListTitle = 'Material List';
        $scope.ItemType = 2;
        $scope.modelDiv = true;
        $scope.isreadType = false;
        $scope.SaveType = '';
        $scope.unitSHowHide = true;
        $scope.colorHideShow = true;
        $scope.brandHideShow = true;
        $scope.sizeHideShow = true;
        $scope.modelHideShow = true;

        //$scope.GetItemGroups = function () {
        //    var apiRoute = baseUrl + 'GetItemGroups/';
        //    var itemGroupes = RowMaterialService.getAllItemGroup(apiRoute, page, pageSize, isPaging, ItemTypeID);
        //    itemGroupes.then(function (response) {
        //        $scope.itemGroupes = response.data;
        //    },
        //    function (error) {
        //        console.log("Error: " + error);
        //    });
        //}
        //$scope.GetItemGroups();

        //$scope.getItemGroupsByType = function () {
        //    var apiRoute = baseUrl + 'GetItemGroups/';
        //    if ($scope.drpType != "") {
        //        var itemGroupes = RowMaterialService.getAllItemGroup(apiRoute, page, pageSize, isPaging, $scope.drpType, LoggedCompanyID);
        //        itemGroupes.then(function (response) {
        //            $scope.itemGroupes = response.data;
        //        },
        //        function (error) {
        //            console.log("Error: " + error);
        //        });
        //    }
        //    else {
        //        $scope.itemGroupes = "";
        //    }
        //}
        //$scope.getItemGroupsByType();
        $scope.SetParentText = function () {
            $scope.txtParent = "";
            parentID = 0;
            acDetailID = null;
        }
   
        $scope.LoadParentesByItemType = function () {
            $scope.itemGroupes = {};
            //$("#ddlItemGroup").select2("data", { id: 0, text: '-- Select Parent --' });
            var ItemTypeID = typeof ($scope.drpType) === "undefined" ? 0 : $scope.drpType;
            // var apiRoute = baseUrl + 'GetItemParentes/';
            var apiRoute = baseUrl + 'GetItemGroupParenteList/';
           // if (ItemTypeID != "") {
                var itemGroupes = RowMaterialService.getItemParentesById(apiRoute, page, pageSize, isPaging, ItemTypeID, LoggedCompanyID);
                itemGroupes.then(function (response) {
                    console.log(response.data);
                    $scope.itemGroupes = response.data;
                },
                function (error) {
                    console.log("Error: " + error);
                });
            //}
            //else {
            //    $scope.itemGroupes = "";
            //}
                $scope.isreadType = true;
        }
        $scope.LoadParentesByItemType();

        $scope.GetUnits = function () {
            var apiRoute = baseUrl + 'GetUnits/';
            var Units = RowMaterialService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
            Units.then(function (response) {
                $scope.Units = response.data;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetUnits();

        ////////********************* Auto Complete Item Name ************************///////////////

        $scope.AutoCompleteItemName = function () {
            $scope.result = [];
            objcmnParam = {
                loggedCompany: 0,
                TableName: 'CmnItemMaster',
                FieldNameOne: 'ItemName',
                FieldNameTwo: 'ItemTypeID',
                id: $scope.drpType,
                InputString: '%' + $scope.txtbxItemName.split(' ').join('') + '%'
            };

            if ($scope.drpType != "")
                var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
            var apiRoute = '/SystemCommon/api/SystemCommonDDL/AutoComplete/';
            var Value = RowMaterialService.GetList(apiRoute, cmnParam);
            Value.then(function (response) {
                $scope.result = response.data.ObjParameters;
            },
            function (error) {
                console.log("Error: " + error);
            });

        }

        ////////********************* Check Item Code ************************///////////////
        $scope.CheckItemCode = function () {

            objcmnParam = {
                loggedCompany: LoggedCompanyID,
                TableName: 'CmnItemMaster',
                FieldName: 'Barcode',
                InputString: $scope.ItemCode.split(' ').join('')
            };

            if ($scope.ItemCode != "")
                var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
            var apiRoute = '/SystemCommon/api/SystemCommonDDL/CheckInputString/';
            var Value = RowMaterialService.GetList(apiRoute, cmnParam);
            Value.then(function (response) {
                $scope.Exsintance = response.data.ObjParameters[0].Existance;
                if ($scope.Exsintance == 1) {
                    $scope.ItemCode = '';
                    Command: toastr["warning"]("Item Code Already Exist!!!!");
                }
            },
            function (error) {
                console.log("Error: " + error);
            });
        }


        //**********---- Check input text from database ----***************//
        $scope.CheckInputString = function () {
            objcmnParam = {
                loggedCompany: LoggedCompanyID,
                TableName: 'CmnItemMaster',
                FieldName: 'ItemName',
                InputString: $scope.txtbxItemName.split(' ').join('')
            };

            if ($scope.txtbxItemName != "")
                var cmnParam = "[" + JSON.stringify(objcmnParam) + "]";
            var apiRoute = '/SystemCommon/api/SystemCommonDDL/CheckInputString/';
            var Value = RowMaterialService.GetList(apiRoute, cmnParam);
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


        $scope.GetColors = function () {
            var apiRoute = baseUrl + 'GetColors/';
            var Colors = RowMaterialService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
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
            var Sizes = RowMaterialService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
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
            var Brands = RowMaterialService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
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
            var Models = RowMaterialService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
            Models.then(function (response) {
                $scope.Models = response.data;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetModels();
        $scope.save = function () {
            isExisting = $scope.ItemID;
            if (isExisting == 0) {
                var RawMaterial = {
                    ItemTypeID: $scope.drpType,
                    ItemGroupID: (parentID == 0 ? null : parentID),
                    AcDetailID: acDetailID,
                    Barcode: $scope.ItemCode,
                    ItemName: $scope.txtbxItemName,
                    UOMID: $scope.drpUOMID,
                    ItemColorID: $scope.drpColor,
                    ItemSizeID: $scope.drpSize,
                    ItemBrandID: $scope.drpBrand,
                    ItemModelID: $scope.drpModel,
                    Note: $scope.txtbxNote,
                    Description: $scope.txtDescription,
                    CreateBy: LoggedUserID,
                    CompanyID: LoggedCompanyID
                }
                var apiRoute = baseUrl + 'SaveRowMaterial/';
                // var saveRawMaterial = RowMaterialService.post(apiRoute, RawMaterial);

                var ACTypeID = "1";
                var cmnParam = "[" + JSON.stringify(RawMaterial) + "," + JSON.stringify(acDetailID) + "," + JSON.stringify(ACTypeID) + "]";

                var saveRawMaterial = RowMaterialService.GetList(apiRoute, cmnParam);


                saveRawMaterial.then(function (response) {
                    if (response.data != "") {
                        var ArtwitUnCode = response.data;
                        var SplitedArtwitUnCode = ArtwitUnCode.split(",");
                        $scope.ArticleNo = SplitedArtwitUnCode[0];
                        $scope.txtbxUniqueCode = SplitedArtwitUnCode[1];
                        if (response.data == "1") {
                            Command: toastr["success"]("Item Saved successfully.");
                        }
                        if (response.data == "-1") {
                            Command: toastr["warning"]("Item Name Already Exists.");
                        }
                        //ShowCustomToastrMessage(response);
                        $scope.ItemType = $scope.drpType;
                        $scope.GetRawMaterials();
                        modal_fadeOut();
                        $scope.clear();
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });

            } else {
                var RawMaterial = {
                    ItemID: $scope.ItemID,
                    ItemTypeID: $scope.drpType,
                    ItemGroupID: (parentID == 0 ? null : parentID),
                    AcDetailID: acDetailID,
                    Barcode: $scope.ItemCode,
                    ItemName: $scope.txtbxItemName,
                    UOMID: $scope.drpUOMID,
                    ItemColorID: $scope.drpColor,
                    ItemSizeID: $scope.drpSize,
                    ItemBrandID: $scope.drpBrand,
                    ItemModelID: $scope.drpModel,
                    Note: $scope.txtbxNote,
                    Description: $scope.txtDescription,
                    UpdateBy: LoggedUserID,
                    CompanyID: LoggedCompanyID
                }
                var apiRoute = baseUrl + 'UpdateRawMaterial/';
                var cmnParam = "[" + JSON.stringify(RawMaterial) +"]";
                var rowMaterial = RowMaterialService.GetList(apiRoute, cmnParam);
                rowMaterial.then(function (response) {
                    //response.data = -102;
                    //ShowCustomToastrMessage(response);
                    if (response.data == "1") {
                        Command: toastr["success"]("Item Updated successfully.");
                    }
                    if (response.data == "-1") {
                        Command: toastr["warning"]("Item Name Already Exists.");
                    }
                    $scope.ItemType = $scope.drpType;
                    $scope.GetRawMaterials();
                    modal_fadeOut();
                    $scope.clear();
                },
                function (error) {
                    console.log("Error: " + error);
                });
            }
        }
        $scope.clear = function (frmRawMaterial) {
            frmRawMaterial.$setPristine();
            frmRawMaterial.$setUntouched();
            $scope.unitSHowHide = true;
            $scope.colorHideShow = true;
            $scope.brandHideShow = true;
            $scope.sizeHideShow = true;
            $scope.modelHideShow = true;
            $scope.modelDiv = true;
            $scope.isreadType = false;
            LoadItemTypes(0);
            $scope.ItemCode = "";
            $scope.ItemType = 2;
            $scope.ItemID = 0;
            parentID = 0;
            acDetailID = null;
            $scope.txtParent = "";
            $scope.btnRawMaterialText = "Save";
            $scope.txtbxItemName = "";
            $scope.txtDescription = "";
            $scope.txtbxNote = "";
            $scope.txtbxItemName = "",
            $scope.drpUOMID = "",
            $scope.drpColor = "",
            $scope.drpSize = "",
            $scope.drpBrand = "",
            $scope.drpModel = "",
            $scope.drpType = ""; //normal reset
            $("#drpType").select2("data", { id: 0, text: '-- Select Type --' }); // select2 reset
            $scope.drpItemGroup = "", // normal reset
            //$("#drpItemGroup").select2("data", { id: 0, text: '-- Select Item Group --' }); // select2 reset
            //$scope.getItemGroupsByType();
            $scope.txtbxUniqueCode = "";
            $scope.ArticleNo = "";
            $("#drpColor").select2("data", { id: 0, text: '-- Select Color --' });
            $("#drpBrand").select2("data", { id: 0, text: '-- Select Brand --' });
            $("#drpModel").select2("data", { id: 0, text: '-- Select Model --' });
            $("#drpSize").select2("data", { id: 0, text: '-- Select Size --' });
            $("#drpUOMID").select2("data", { id: 0, text: '-- Select Unit --' });
        }

        //Pagination
        $scope.paginationRm = {
            paginationPageSizesRm: [10, 25, 50, 75, 100, 500, 1000, "All"],
            ddlpageSizeRm: 10,
            pageNumberRm: 1,
            pageSizeRm: 10,
            totalItemsRm: 0,

            getTotalPagesRm: function () {
                return Math.ceil(this.totalItemsRm / this.pageSizeRm);
            },
            pageSizeChangeRm: function () {
                if (this.ddlpageSizeRm == "All") {
                    this.pageNumberRm = 1
                    this.pageSizeRm = $scope.paginationRm.totalItemsRm;
                    $scope.GetRawMaterials();
                }
                else {
                    this.pageSizeRm = this.ddlpageSizeRm
                    this.pageNumberRm = 1
                    $scope.GetRawMaterials();
                }


            },
            firstPageRm: function () {
                if (this.pageNumberRm > 1) {
                    this.pageNumberRm = 1
                    $scope.GetRawMaterials();
                }
            },
            nextPageRm: function () {
                if (this.pageNumberRm < this.getTotalPagesRm()) {
                    this.pageNumberRm++;
                    $scope.GetRawMaterials();
                }
            },
            previousPageRm: function () {
                if (this.pageNumberRm > 1) {
                    this.pageNumberRm--;
                    $scope.GetRawMaterials();
                }
            },
            lastPageRm: function () {
                if (this.pageNumberRm >= 1) {
                    this.pageNumberRm = this.getTotalPagesRm();
                    $scope.GetRawMaterials();
                }
            }
        };
        $scope.GetRawMaterials = function () {

            $scope.loaderMore = true;
            $scope.lblMessage = 'loading please wait....!';
            $scope.result = "color-red";
           
            objcmnParamRm = {
                pageNumber: $scope.paginationRm.pageNumberRm,
                pageSize: $scope.paginationRm.pageSizeRm,
                IsPaging: isPaging,
                loggeduser: LoggedUserID,
                loggedCompany: LoggedCompanyID,
                menuId: 5,
                tTypeId: 26,
                ItemType: $scope.ItemType
            };
            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };
            $scope.gridOptionsRm = {
                enableFiltering: true,
                enableRowSelection: true,
                enableSelectAll: true,
                showFooter: true,
                columnDefs: [
                    
                     { name: "ItemTypeID", displayName: "ItemTypeID", visible: false, headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ArticleNo", title: "Item Code.", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "Barcode", displayName: "Store Code", width: '15%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ItemTypeName", title: "Item-Type", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ItemGroupName", title: "Item-Group", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ItemName", displayName: "Item-Name", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "UOMName", displayName: "Unit", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "Color", displayName: "Color", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "SizeName", displayName: "Size", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "BrandName", displayName: "Brand", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "ModelName", displayName: "Model", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    {
                        name: 'Edit',
                        displayName: "Edit",
                        enableColumnResizing: false,
                        enableFiltering: false,
                        enableSorting: false,
                        width: '10%',
                        pinnedRight: true,
                        headerCellClass: $scope.highlightFilteredHeader,
                        cellTemplate: '<span class="label label-warning label-mini">' +
                                      ' <a ng-href="#GroupModal" data-toggle="modal" class="bs-tooltip" title="Edit Info" ng-click="grid.appScope.getRawMaterialByID(row.entity)">' +
                                          '<i class="icon-pencil"></i>' +
                                      ' </a>' +
                                  ' </span>' +
                                   '<span class="label label-danger label-mini">' +
                                     '  <a href="#" class="bs-tooltip" title="Delete" ng-click="grid.appScope.delete(row.entity)">' +
                                           '<i class="icon-trash"></i>' +
                                      ' </a>' +
                                  ' </span>'
                    }
                ]
            };

            var apiRoute = baseUrl + 'GetAllRowMaterial/';
            var RowMaterials = RowMaterialService.getAllRawMaterial(apiRoute, objcmnParamRm);
            RowMaterials.then(function (response) {
               
                $scope.paginationRm.totalItemsRm = response.data.recordsTotal;
                $scope.gridOptionsRm.data = response.data.objRawMaterials;
                debugger;
                console.log(response);
                $scope.loaderMore = false;
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetRawMaterials();
        $scope.delete = function (dataModel) {
            var IsConf = confirm('You are about to delete ' + dataModel.ItemName + '. Are you sure?');
            if (IsConf) {

                var RawMaterial = {
                    ItemID: dataModel.ItemID,
                    DeleteBy: LoggedUserID,
                    CompanyID: LoggedCompanyID
                }
                var apiRoute = baseUrl + 'DeleteRawMaterial/';
                var deleteRowMaterial = RowMaterialService.put(apiRoute, RawMaterial);
                deleteRowMaterial.then(function (response) {
                    $scope.GetRawMaterials();
                    response.data = -101;
                    ShowCustomToastrMessage(response);
                    $scope.clear();

                }, function (error) {
                    console.log("Error: " + error);
                });
            }
        }

        $scope.getRawMaterialByID = function (dataModel) {
            
            var apiRoute = baseUrl + 'GetRawMaterial/' + dataModel.ItemID + '/' + dataModel.ItemTypeID + '/' + LoggedCompanyID;
            var rowMaterial = RowMaterialService.getRawMaterialByID(apiRoute);
            rowMaterial.then(function (response) {
                
                $scope.unitSHowHide = false;
                $scope.colorHideShow = false;
                $scope.brandHideShow = false;
                $scope.sizeHideShow = false;
                $scope.modelHideShow = false;
                $scope.btnRawMaterialText = "Update";
                $scope.ItemID = response.data.ItemID;
                $scope.ItemCode = response.data.Barcode;
                $scope.txtbxItemName = response.data.ItemName;
                $scope.txtDescription = response.data.Description;
                $scope.txtbxUniqueCode = response.data.UniqueCode;
                $scope.txtbxNote = response.data.Note;
                $scope.ArticleNo = response.data.ArticleNo
                $scope.SetDropdwn(response);
                parentID = response.data.ItemGroupID; // parent Id is item Group ID
                acDetailID = response.data.AcDetailID;
                $scope.txtParent = response.data.ItemGroupName;
                $scope.LoadParentesByItemType();
                $scope.isreadType = true;
                $scope.modelDiv = true;
                $("#RawMoaterialModal").fadeIn(200, function () { $('#RawMoaterialModal').modal('show'); });
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.SetDropdwn = function (response) {
            $scope.drpType = response.data.ItemTypeID
            if (response.data.ItemTypeName != 'N/A') {
                $("#drpType").select2("data", { id: 0, text: response.data.ItemTypeName });
            } else {
                $("#drpType").select2("data", { id: 0, text: '-- Select Type --' });
            }

            //$scope.getItemGroupsByType();
            //$scope.drpItemGroup = response.data.ItemGroupID
            //if (response.data.ItemGroupName != 'N/A') {
            //    $("#drpItemGroup").select2("data", { id: 0, text: response.data.ItemGroupName });
            //} else {
            //    $("#drpItemGroup").select2("data", { id: 0, text: '-- Select Item Group --' });
            //}
            $scope.drpColor = response.data.ItemColorID
            if (response.data.Color != 'N/A') {
                $("#drpColor").select2("data", { id: 0, text: response.data.Color });
            } else {
                $("#drpColor").select2("data", { id: 0, text: '-- Select Color --' });
            }

            $scope.drpBrand = response.data.ItemBrandID
            if (response.data.BrandName != 'N/A') {
                $("#drpBrand").select2("data", { id: 0, text: response.data.BrandName });
            } else {
                $("#drpBrand").select2("data", { id: 0, text: '-- Select Brand --' });
            }

            $scope.drpModel = response.data.ItemModelID
            if (response.data.ModelName != 'N/A') {
                $("#drpModel").select2("data", { id: 0, text: response.data.ModelName });
            } else {
                $("#drpModel").select2("data", { id: 0, text: '-- Select Model --' });
            }

            $scope.drpSize = response.data.ItemSizeID
            if (response.data.SizeName != 'N/A') {
                $("#drpSize").select2("data", { id: 0, text: response.data.SizeName });
            } else {
                $("#drpSize").select2("data", { id: 0, text: '-- Select Size --' });
            }

            $scope.drpUOMID = response.data.UOMID
            if (response.data.UOMName != 'N/A') {
                $("#drpUOMID").select2("data", { id: 0, text: response.data.UOMName });
            } else {
                $("#drpUOMID").select2("data", { id: 0, text: '-- Select Unit --' });
            }
            $scope.modelDiv = false;
        }

        function LoadItemTypes(isPaging) {

            //$("#isActive").prop('checked', true);        

            var apiRoute = '/SystemCommon/api/ItemGroup/GetItemTypes/';
            var itemTypes = RowMaterialService.getAll(apiRoute, page, pageSize, isPaging, LoggedCompanyID);
            itemTypes.then(function (response) {
                $scope.Types = response.data
            },
            function (error) {
                console.log("Error: " + error);
            });
        }
        LoadItemTypes(0);

        //$scope.getTypes = function () {
        //    $scope.Types = [{
        //        Item: 'Raw Material'
        //        , Value: 2 // For Raw Material
        //    },
        //    {
        //        Item: 'Chemical'
        //        , Value: 5 // For Chemical
        //    }, {
        //        Item: 'Fixed Asset'
        //        , Value: 4 // For Fixed Asset
        //    }, {
        //        Item: 'Wastage',
        //        Value:6//For Wastage
        //    }];
        //}
        //$scope.getTypes();
        $scope.SerchItemGroupsByType = function () {
            $scope.ItemType = "";
            $scope.ItemType = $scope.drpSearchType;
            $scope.paginationRm.pageNumberRm = 1;
            $scope.GetRawMaterials();
        }

        $scope.selectNode = function (val) {
            $scope.txtParent = val.Name;
            parentID = val.ID;
            acDetailID = val.AcDetailID;
            $scope.drpType = val.ItemTypeID;
            $("#drpType").select2("data", { id: val.ItemTypeID, text: val.ItemType.ItemTypeName });
        }
        $scope.treedubbleClick = function (val) {
            $scope.txtParent = val.Name;
            parentID = val.ID;
            acDetailID = val.AcDetailID;
            modal_fadeOutTree();
            $scope.drpType = val.ItemTypeID;
            $("#drpType").select2("data", { id: val.ItemTypeID, text: val.ItemType.ItemTypeName });
        }

        $scope.SetUpSize = function () {
            debugger
            $scope.SaveType = "Size";
            $scope.ModalHeading = "Size";
            $scope.labelName = "Size"
            $scope.btnSave = "Save";
            $scope.placeHolder = "----Size----"
            $("#modalRMCommon").fadeIn(200, function () { $('#modalRMCommon').modal('show'); });
        }
        $scope.SetUpUnit = function () {
            debugger
            $scope.SaveType = "Unit";
            $scope.ModalHeading = "Unit";
            $scope.labelName = "Unit"
            $scope.btnSave = "Save";
            $scope.placeHolder = "----Unit----"
            $("#modalRMCommon").fadeIn(200, function () { $('#modalRMCommon').modal('show'); });
        }
        $scope.SetUpColor = function () {
            $scope.SaveType = "Color";
            $scope.ModalHeading = "Color";
            $scope.labelName = "Color"
            $scope.btnSave = "Save";
            $scope.placeHolder = "----Color----"
            $("#modalRMCommon").fadeIn(200, function () { $('#modalRMCommon').modal('show'); });
        }
        $scope.SetUpBrand = function () {
            $scope.SaveType = "Brand";
            $scope.ModalHeading = "Brand";
            $scope.labelName = "Brand"
            $scope.btnSave = "Save";
            $scope.placeHolder = "----Brand----"
            $("#modalRMCommon").fadeIn(200, function () { $('#modalRMCommon').modal('show'); });
        }
        $scope.SetUpModel = function () {
            $scope.SaveType = "Model";
            $scope.ModalHeading = "Model";
            $scope.labelName = "Model"
            $scope.btnSave = "Save";
            $scope.placeHolder = "----Model----"
            $("#modalRMCommon").fadeIn(200, function () { $('#modalRMCommon').modal('show'); });
        }

        $scope.SaveItem = function () {
            debugger
            if ($scope.SaveType == 'Size') {

                var Size = {
                    SizeName: $scope.txtValue,
                    CreateBy: LoggedUserID,
                    CompanyID: LoggedCompanyID
                };
                var apiRoute = baseUrl + 'SaveSize/';
                var StateCreate = RowMaterialService.post(apiRoute, Size);
                StateCreate.then(function (response) {
                    debugger;
                    if (response.data != "") {
                        var res = response.data.split(",");
                        $scope.GetSizes();
                        $scope.drpSize = res[1];
                        $("#drpSize").select2("data", { id: res[1], text: res[0] });

                        Command: toastr["info"]("Size Saved Successfully!!!!");
                        $scope.ClearRMCommonModal();
                        $("#modalRMCommon").fadeIn(200, function () { $('#modalRMCommon').modal('hide'); });
                    }
                    else if (response.data === 0) {
                            Command: toastr["error"]("Error while Creating User!!!!");
                    }
                    else {
                        Command: toastr["error"]("Error Undefined!!!!");
                    }
                },
                function (error) {
                    console.log("Error: " + error);
                });

            }
            else if ($scope.SaveType == 'Unit') {
                var CmnUOM = {
                    UOMName: $scope.txtValue,
                    CreateBy: LoggedUserID,
                    CompanyID: LoggedCompanyID
                };
                var apiRoute = baseUrl + 'SaveUnit/';
                var StateCreate = RowMaterialService.post(apiRoute, CmnUOM);
                StateCreate.then(function (response) {
                    debugger;
                    if (response.data != "") {
                        var res = response.data.split(",");

                        $scope.GetUnits();
                        $scope.drpUOMID = res[1];
                        $("#drpUOMID").select2("data", { id: res[1], text: res[0] });

                        Command: toastr["info"]("Unit Saved Successfully!!!!");
                        $scope.ClearRMCommonModal();
                        $("#modalRMCommon").fadeIn(200, function () { $('#modalRMCommon').modal('hide'); });
                    }
                    else if (response.data === 0) {
                            Command: toastr["error"]("Error while Creating User!!!!");
                    }
                    else {
                        Command: toastr["error"]("Error Undefined!!!!");
                    }
                },
                function (error) {
                    console.log("Error: " + error);
                });
            } else if ($scope.SaveType == 'Color') {
                var Color = {
                    ColorName: $scope.txtValue,
                    CreateBy: LoggedUserID,
                    CompanyID: LoggedCompanyID
                };
                var apiRoute = baseUrl + 'SaveColor/';
                var StateCreate = RowMaterialService.post(apiRoute, Color);
                StateCreate.then(function (response) {
                    debugger;
                    if (response.data != "") {
                        var res = response.data.split(",");

                        $scope.GetColors();
                        $scope.drpColor = res[1];
                        $("#drpColor").select2("data", { id: res[1], text: res[0] });

                        Command: toastr["info"]("Color Saved Successfully!!!!");
                        $scope.ClearRMCommonModal();
                        $("#modalRMCommon").fadeIn(200, function () { $('#modalRMCommon').modal('hide'); });
                    }
                    else if (response.data === 0) {
                            Command: toastr["error"]("Error while Creating User!!!!");
                    }
                    else {
                        Command: toastr["error"]("Error Undefined!!!!");
                    }
                },
                function (error) {
                    console.log("Error: " + error);
                });
            } else if ($scope.SaveType == 'Brand') {
                var Brand = {
                    BrandName: $scope.txtValue,
                    CreateBy: LoggedUserID,
                    CompanyID: LoggedCompanyID
                };
                var apiRoute = baseUrl + 'SaveBrand/';
                var StateCreate = RowMaterialService.post(apiRoute, Brand);
                StateCreate.then(function (response) {
                    debugger;
                    if (response.data != "") {
                        var res = response.data.split(",");
                        $scope.GetBrands();
                        $scope.drpBrand = res[1];
                        $("#drpBrand").select2("data", { id: res[1], text: res[0] });

                        Command: toastr["info"]("Brand Saved Successfully!!!!");
                        $scope.ClearRMCommonModal();
                        $("#modalRMCommon").fadeIn(200, function () { $('#modalRMCommon').modal('hide'); });
                    }
                    else if (response.data === 0) {
                            Command: toastr["error"]("Error while Creating User!!!!");
                    }
                    else {
                        Command: toastr["error"]("Error Undefined!!!!");
                    }
                },
                function (error) {
                    console.log("Error: " + error);
                });
            } else if ($scope.SaveType == 'Model') {
                var ModelName = {
                    ModelName: $scope.txtValue,
                    CreateBy: LoggedUserID,
                    CompanyID: LoggedCompanyID
                };
                var apiRoute = baseUrl + 'SaveModal/';
                var StateCreate = RowMaterialService.post(apiRoute, ModelName);
                StateCreate.then(function (response) {
                    debugger;
                    if (response.data != "") {
                        var res = response.data.split(",");

                        $scope.GetModels();
                        $scope.drpModel = res[1];
                        $("#drpModel").select2("data", { id: res[1], text: res[0] });

                        Command: toastr["info"]("Model Saved Successfully!!!!");
                        $scope.ClearRMCommonModal();
                        $("#modalRMCommon").fadeIn(200, function () { $('#modalRMCommon').modal('hide'); });
                    }
                    else if (response.data === 0) {
                            Command: toastr["error"]("Error while Creating User!!!!");
                    }
                    else {
                        Command: toastr["error"]("Error Undefined!!!!");
                    }
                },
                function (error) {
                    console.log("Error: " + error);
                });
            }
        }
        $scope.ClearRMCommonModal = function () {
            $scope.txtValue = "";
            $scope.SaveType = "";
        }
    }]);

function modal_fadeOut() {
    $("#RawMoaterialModal").fadeOut(200, function () {
        $('#RawMoaterialModal').modal('hide');
    });
}

function modal_fadeOutTree() {
    $("#drpModal").fadeOut(200, function () {
        $('#drpModal').modal('hide');
    });
}