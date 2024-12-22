using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.Models.ApiMobile;
using APL.BL.SFTS.ShelterZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class ProductInfoPZ
    {
        public const string _collectionNodePart = "Coll";
        public ProductInfoPZ()
        { }

        /// <summary>
        /// Get product family information only from TBLPRODFAMILY table.
        /// </summary>
        /// <param name="productFamilyID">default value is zero for all product family</param>
        /// <param name="productCode">default value is empty string for all product family</param>
        /// <returns>List of product family object</returns>
        public List<SP_GET_PRODUCT_FAMILYcls> GetProductFamilyForSetPrice(Decimal proFamilyID, string proCode)
        {
            try
            {
                return new ProductInfoDZ().GetProductFamilyForSetPrice(proFamilyID, proCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get product family information from PRODUCT_SALEPRICE and TBLPRODFAMILY table. This product family is available when sales price is defined each product.
        /// </summary>
        /// <param name="productFamilyID">default value is zero for all product family</param>
        /// <param name="productCode">default value is empty string for all product family</param>
        /// <returns>List of product family object</returns>
        public List<SP_GET_PRODUCT_FAMILYcls> GetProductFamily(Decimal proFamilyID, string proCode)
        {
            try
            {
                return new ProductInfoDZ().GetProductFamily(proFamilyID, proCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get product category information TBLPRODUCTCATEGORY table and related table.
        /// </summary>
        /// <param name="productFamilyID">default value is zero for all product family</param>
        /// <param name="productCategoryID">default value is zero for all product category</param>
        /// <param name="proCategoryName">default value is empty string for all product category</param>
        /// <returns>List of product category object</returns>
        public List<SP_GET_PRO_CATEGORYcls> GetProductCategory(Decimal productFamilyID, Decimal productCategoryID, string proCategoryName)
        {
            try
            {
                return new ProductInfoDZ().GetProductCategory( productFamilyID,  productCategoryID,  proCategoryName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get product category information TBLPRODUCTSUBCATEGORY table and related table.
        /// </summary>
        /// <param name="productCategoryID">default value is zero for all product category</param>
        /// <param name="productSubCategoryID">default value is zero for all product sub category</param>
        /// <param name="proSubCategoryName">default value is empty string for all product sub category</param>
        /// <returns>List of product sub category object</returns>
        public List<SP_GET_SUBCATEGORYcls> GetProductSubCategory(Decimal productCategoryID, Decimal productSubCategoryID, string proSubCategoryName)
        {
            try
            {
                return new ProductInfoDZ().GetProductSubCategory(productCategoryID, productSubCategoryID, proSubCategoryName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_PRODUCT> GetProducts(Decimal SubcategoryId)
        {
            try
            {
                return new ProductInfoDZ().GetProducts(SubcategoryId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetProdFrmSerial GetProductFromSerial(decimal UserId, decimal RetailerId, decimal ProdTypeId, string StartSl, string EndSl)
        {
            try
            {
                return new ProductInfoDZ().GetProductFromSerial(UserId, RetailerId, ProdTypeId, StartSl, EndSl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetProdFrmSerial GetProductForReturn(decimal UserId, decimal RetailerId, decimal ProdTypeId, string StartSl, string EndSl)
        {
            try
            {
                return new ProductInfoDZ().GetProductForReturn(UserId, RetailerId, ProdTypeId, StartSl, EndSl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetSimStatus GetSimStatus(decimal UserId, string SimNo)
        {
            try
            {
                return new ProductInfoDZ().GetSimStatus(UserId, SimNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RET_TOPUP_STATUS> GetRetailerTopupBalance(decimal RetailerId)
        {
            try
            {
                return new ProductInfoDZ().GetRetailerTopupBalance(RetailerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TopupIssueRetailer SaveTopupIssueToRetailer(decimal RetailerId, decimal IssuedBy, string PassCode, decimal TopupAmt, decimal VisitId, decimal Latitude, decimal Longitude)
        {
            try
            {
                return new ProductInfoDZ().SaveTopupIssueToRetailer(RetailerId, IssuedBy, PassCode, TopupAmt, VisitId, Latitude, Longitude);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_FOC_PRODUCT> GetFOCProducts(decimal UserId)
        {
            try
            {
                return new ProductInfoDZ().GetFOCProducts(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get product family information from PRODUCT_SALEPRICE and TBLPRODFAMILY table. This product family is available when sales price is defined each product.
        /// </summary>
        /// <param name="productFamilyID">default value is zero for all product family</param>
        /// <param name="productCode">default value is empty string for all product family</param>
        /// <returns>List of product family object for Web Service compatible XML soap data format</returns>
        public ServiceStringXML GetProductFamilyXML(Decimal proFamilyID, string proCode)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            string objectXML = string.Empty;
            string objectItemName = new SP_GET_PRODUCT_FAMILYcls().GetType().Name + _collectionNodePart;
            try
            {
                List<SP_GET_PRODUCT_FAMILYcls> retailerColl = new ProductInfoDZ().GetProductFamily(proFamilyID, proCode);
                if (retailerColl != null && retailerColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<SP_GET_PRODUCT_FAMILYcls>(retailerColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        /// <summary>
        /// Get product list from relational product table but not included product sales price table 
        /// </summary>
        /// <param name="subCategoryID">default value is zero for all product</param>
        /// <returns>List of product object </returns>
        public List<SP_GET_PRODUCT_BY_SUBCATEIDcls> GetProductBySubCatIDSetPrice(Decimal subCategoryID)
        {
            try
            {
                return new ProductInfoDZ().GetProductBySubCatIDSetPrice(subCategoryID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get product list from relational product table with include product sales price table (PRODUCT_SALEPRICE).
        /// </summary>
        /// <param name="subCategoryID">default value is zero for all product</param>
        /// <returns>List of product object which price is define. And Web Service compatible XML soap data format</returns>
        public ServiceStringXML GetProductBySubCategoryIDXML(Decimal subCategoryID)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            string objectXML = string.Empty;
            string objectItemName = new SP_GET_PRODUCT_BY_SUBCATEIDcls().GetType().Name + _collectionNodePart;
            try
            {
                List<SP_GET_PRODUCT_BY_SUBCATEIDcls> productColl = new ProductInfoDZ().GetProductBySubCategoryID(subCategoryID);
                if (productColl != null && productColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<SP_GET_PRODUCT_BY_SUBCATEIDcls>(productColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        #region Product Price 

        /// <summary>
        /// Get single product from relational product table with include product sales price table by list of search parameter.
        /// </summary>
        /// <param name="familyID"></param>
        /// <param name="categoryID"></param>
        /// <param name="subCategoryID"></param>
        /// <param name="productID"></param>
        /// <param name="productPriceID"></param>
        /// <param name="currentPageNo"></param>
        /// <returns>Single product sales price object</returns>
        public SP_INS_UPD_PRODUCT_SALEPRICEcls GetProductPrice(Decimal familyID, Decimal categoryID, Decimal subCategoryID, Decimal productID, Decimal productPriceID, Decimal currentPageNo)
        {
            try
            {
                List<SP_INS_UPD_PRODUCT_SALEPRICEcls> productSalePriceColl = new ProductInfoDZ().GetAllProductPrice(familyID, categoryID, subCategoryID, productID,productPriceID, currentPageNo);
                if (productSalePriceColl == null || productSalePriceColl.Count == 0)
                {
                    return null;
                }
                return productSalePriceColl[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get product list from relational product table with include product sales price table by list of search parameter.
        /// </summary>
        /// <param name="familyID"></param>
        /// <param name="categoryID"></param>
        /// <param name="subCategoryID"></param>
        /// <param name="productID"></param>
        /// <param name="productPriceID"></param>
        /// <param name="currentPageNo"></param>
        /// <returns>List of product sales price object</returns>
        public List<SP_INS_UPD_PRODUCT_SALEPRICEcls> GetAllProductPrice(Decimal familyID, Decimal categoryID, Decimal subCategoryID, Decimal productID, Decimal productSalePriceID, Decimal currentPageNo)
        {
            try
            {
                return new ProductInfoDZ().GetAllProductPrice(familyID, categoryID, subCategoryID, productID, productSalePriceID, currentPageNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Save or update product sales price.
        /// </summary>
        /// <param name="p_TBLPRODUCTSUBCATEGORY_ID"></param>
        /// <param name="p_UPDATE_BY"></param>
        /// <param name="p_TBLPRODUCTCATEGORY_ID"></param>
        /// <param name="p_UPDATE_DATE"></param>
        /// <param name="p_TBLPRODFAMILY_ID"></param>
        /// <param name="p_PRODUCT_SALEPRICE_ID">if value is zero then save product sales price other wise update operation implement</param>
        /// <param name="p_CREATE_BY"></param>
        /// <param name="p_NOTE"></param>
        /// <param name="p_CREATE_DATE"></param>
        /// <param name="p_TBLPRODUCTID"></param>
        /// <param name="p_ISDISPLAY_PRICE"></param>
        /// <param name="p_SALESPRICE"></param>
        /// <returns> PRODUCT_SALEPRICE_ID field value </returns>
        public Decimal SaveOrUpdateSalePrice(decimal p_TBLPRODUCTSUBCATEGORY_ID, decimal p_UPDATE_BY, decimal p_TBLPRODUCTCATEGORY_ID, DateTime p_UPDATE_DATE,
            decimal p_TBLPRODFAMILY_ID, decimal p_PRODUCT_SALEPRICE_ID, decimal p_CREATE_BY, string p_NOTE, DateTime p_CREATE_DATE, decimal p_TBLPRODUCTID,
            decimal p_ISDISPLAY_PRICE, decimal p_SALESPRICE)
        {
            try
            {
                return new ProductInfoDZ().SaveOrUpdateSalePrice(p_TBLPRODUCTSUBCATEGORY_ID, p_UPDATE_BY, p_TBLPRODUCTCATEGORY_ID, p_UPDATE_DATE,
                    p_TBLPRODFAMILY_ID, p_PRODUCT_SALEPRICE_ID, p_CREATE_BY, p_NOTE, p_CREATE_DATE, p_TBLPRODUCTID, p_ISDISPLAY_PRICE, p_SALESPRICE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Product Price
    }
}
