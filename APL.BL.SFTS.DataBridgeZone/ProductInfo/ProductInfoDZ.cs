using APL.BL.SFTS.Models.ApiMobile;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class ProductInfoDZ
    {
        readonly string connStringMainDB = ConfigurationManager.ConnectionStrings["APL_DB_ConnString"].ConnectionString;
        public ProductInfoDZ()
        { }

        /// <summary>
        /// Get product family information only from TBLPRODFAMILY table.
        /// </summary>
        /// <param name="productFamilyID">default value is zero for all product family</param>
        /// <param name="productCode">default value is empty string for all product family</param>
        /// <returns>List of product family object</returns>
        public List<SP_GET_PRODUCT_FAMILYcls> GetProductFamilyForSetPrice(Decimal productFamilyID, string productCode)
        {
            try
            {
                OracleParameter productFamilyID_OP = new OracleParameter();
                productFamilyID_OP.Direction = System.Data.ParameterDirection.Input;
                productFamilyID_OP.OracleDbType = OracleDbType.Decimal;
                productFamilyID_OP.Value = productFamilyID;

                OracleParameter productCodeOP = new OracleParameter();
                productCodeOP.Direction = System.Data.ParameterDirection.Input;
                productCodeOP.OracleDbType = OracleDbType.Varchar2;
                productCodeOP.Value = productCode;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_PRODUCT_FAMILYcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_PRODUCT_FAMILYcls>.GetDataBySP(new SP_GET_PRODUCT_FAMILYcls(), "SP_GET_PRODUCT_FAMILY_PRI", 5, resultOutCurSor, productFamilyID_OP, productCodeOP);
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
        public List<SP_GET_PRODUCT_FAMILYcls> GetProductFamily(Decimal productFamilyID, string productCode)
        {
            try
            {
                OracleParameter productFamilyID_OP = new OracleParameter();
                productFamilyID_OP.Direction = System.Data.ParameterDirection.Input;
                productFamilyID_OP.OracleDbType = OracleDbType.Decimal;
                productFamilyID_OP.Value = productFamilyID;

                OracleParameter productCodeOP = new OracleParameter();
                productCodeOP.Direction = System.Data.ParameterDirection.Input;
                productCodeOP.OracleDbType = OracleDbType.Varchar2;
                productCodeOP.Value = productCode;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_PRODUCT_FAMILYcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_PRODUCT_FAMILYcls>.GetDataBySP(new SP_GET_PRODUCT_FAMILYcls(), "SP_GET_PRODUCT_FAMILY", 5, resultOutCurSor, productFamilyID_OP, productCodeOP);
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
                OracleParameter productFamilyID_OP = new OracleParameter();
                productFamilyID_OP.Direction = System.Data.ParameterDirection.Input;
                productFamilyID_OP.OracleDbType = OracleDbType.Decimal;
                productFamilyID_OP.Value = productFamilyID;

                OracleParameter productCategoryID_OP = new OracleParameter();
                productCategoryID_OP.Direction = System.Data.ParameterDirection.Input;
                productCategoryID_OP.OracleDbType = OracleDbType.Decimal;
                productCategoryID_OP.Value = productCategoryID;

                OracleParameter proCategoryNameOP = new OracleParameter();
                proCategoryNameOP.Direction = System.Data.ParameterDirection.Input;
                proCategoryNameOP.OracleDbType = OracleDbType.Varchar2;
                proCategoryNameOP.Value = proCategoryName;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_PRO_CATEGORYcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_PRO_CATEGORYcls>.GetDataBySP(new SP_GET_PRO_CATEGORYcls(), "SP_GET_PRO_CATEGORY", 4, resultOutCurSor, productFamilyID_OP, productCategoryID_OP, proCategoryNameOP);
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
                OracleParameter productCategoryID_OP = new OracleParameter();
                productCategoryID_OP.Direction = System.Data.ParameterDirection.Input;
                productCategoryID_OP.OracleDbType = OracleDbType.Decimal;
                productCategoryID_OP.Value = productCategoryID;

                OracleParameter productSubCategoryID_OP = new OracleParameter();
                productSubCategoryID_OP.Direction = System.Data.ParameterDirection.Input;
                productSubCategoryID_OP.OracleDbType = OracleDbType.Decimal;
                productSubCategoryID_OP.Value = productSubCategoryID;

                OracleParameter proSubCategoryNameOP = new OracleParameter();
                proSubCategoryNameOP.Direction = System.Data.ParameterDirection.Input;
                proSubCategoryNameOP.OracleDbType = OracleDbType.Varchar2;
                proSubCategoryNameOP.Value = proSubCategoryName;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SUBCATEGORYcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SUBCATEGORYcls>.GetDataBySP(new SP_GET_SUBCATEGORYcls(), "SP_GET_SUBCATEGORY", 4, resultOutCurSor, productCategoryID_OP, productSubCategoryID_OP, proSubCategoryNameOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get product list from relational product table but not included product sales price table 
        /// </summary>
        /// <param name="subCategoryID">default value is zero for all product</param>
        /// <returns>List of product object</returns>
        public List<SP_GET_PRODUCT_BY_SUBCATEIDcls> GetProductBySubCatIDSetPrice(Decimal subCategoryID)
        {
            try
            {
                OracleParameter subCategoryID_OP = new OracleParameter();
                subCategoryID_OP.Direction = System.Data.ParameterDirection.Input;
                subCategoryID_OP.OracleDbType = OracleDbType.Decimal;
                subCategoryID_OP.Value = subCategoryID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_PRODUCT_BY_SUBCATEIDcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_PRODUCT_BY_SUBCATEIDcls>.GetDataBySP(new SP_GET_PRODUCT_BY_SUBCATEIDcls(), "SP_GET_PRO_BY_SUBCATID_SET_P", 11, resultOutCurSor, subCategoryID_OP);
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
        /// <returns>List of product object which price is define</returns>
        public List<SP_GET_PRODUCT_BY_SUBCATEIDcls> GetProductBySubCategoryID(Decimal subCategoryID)
        {
            try
            {
                OracleParameter subCategoryID_OP = new OracleParameter();
                subCategoryID_OP.Direction = System.Data.ParameterDirection.Input;
                subCategoryID_OP.OracleDbType = OracleDbType.Decimal;
                subCategoryID_OP.Value = subCategoryID;              

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_PRODUCT_BY_SUBCATEIDcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_PRODUCT_BY_SUBCATEIDcls>.GetDataBySP(new SP_GET_PRODUCT_BY_SUBCATEIDcls(), "SP_GET_PRODUCT_BY_SUBCATEID", 11, resultOutCurSor, subCategoryID_OP);
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
                OracleParameter SubcategoryId_OP = new OracleParameter();
                SubcategoryId_OP.Direction = System.Data.ParameterDirection.Input;
                SubcategoryId_OP.OracleDbType = OracleDbType.Decimal;
                SubcategoryId_OP.Value = SubcategoryId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_PRODUCT>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_PRODUCT>.GetDataBySP(new SP_GET_PRODUCT(), "SP_FF_GET_PRODUCT", 8, resultOutCurSor, SubcategoryId_OP);
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
                GetProdFrmSerial getProdFrmSerial = new GetProdFrmSerial();
                List<SP_GET_PRODUCT_FROM_SL> getProdFromSl = new List<SP_GET_PRODUCT_FROM_SL>();
                OracleConnection cn = new OracleConnection(connStringMainDB);
                string spName = "SP_FF_GET_PROD_FROM_SL_V2";
                OracleCommand cmd = new OracleCommand(spName);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;
                cmd.Parameters.Add(UserId_OP);

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;
                cmd.Parameters.Add(RetailerId_OP);

                OracleParameter ProdTypeId_OP = new OracleParameter();
                ProdTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                ProdTypeId_OP.OracleDbType = OracleDbType.Decimal;
                ProdTypeId_OP.Value = ProdTypeId;
                cmd.Parameters.Add(ProdTypeId_OP);

                OracleParameter StartSerial_OP = new OracleParameter();
                StartSerial_OP.Direction = System.Data.ParameterDirection.Input;
                StartSerial_OP.OracleDbType = OracleDbType.Varchar2;
                StartSerial_OP.Value = StartSl;
                cmd.Parameters.Add(StartSerial_OP);

                OracleParameter EndSerial_OP = new OracleParameter();
                EndSerial_OP.Direction = System.Data.ParameterDirection.Input;
                EndSerial_OP.OracleDbType = OracleDbType.Varchar2;
                EndSerial_OP.Value = EndSl;
                cmd.Parameters.Add(EndSerial_OP);

                OracleParameter errCode_OP = new OracleParameter();
                errCode_OP.Direction = System.Data.ParameterDirection.Output;
                errCode_OP.OracleDbType = OracleDbType.Decimal;
                cmd.Parameters.Add(errCode_OP);

                OracleParameter errMsgEng_OP = new OracleParameter();
                errMsgEng_OP.Direction = System.Data.ParameterDirection.Output;
                errMsgEng_OP.OracleDbType = OracleDbType.NVarchar2;
                errMsgEng_OP.Size = 500;
                cmd.Parameters.Add(errMsgEng_OP);

                OracleParameter errMsgBan_OP = new OracleParameter();
                errMsgBan_OP.Direction = System.Data.ParameterDirection.Output;
                errMsgBan_OP.OracleDbType = OracleDbType.NVarchar2;
                errMsgBan_OP.Size = 500;
                cmd.Parameters.Add(errMsgBan_OP);

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;
                cmd.Parameters.Add(resultOutCurSor);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                string errCode = errCode_OP.Value.ToString();
                string errMsgEng = errMsgEng_OP.Value.ToString();
                string errMsgBan = errMsgBan_OP.Value.ToString();
                OracleDataReader reader = ((OracleRefCursor)resultOutCurSor.Value).GetDataReader();
                while (reader.Read())
                {
                    SP_GET_PRODUCT_FROM_SL spGetProd = new SP_GET_PRODUCT_FROM_SL();
                    spGetProd.PRODUCT_ID = reader.GetDecimal(0);
                    spGetProd.PRODUCT_CODE = reader.GetString(1);
                    spGetProd.PRODUCT_NAME = reader.GetString(2);
                    spGetProd.DESCRIPTION = reader.GetString(3);
                    spGetProd.UNIT_PRICE = reader.GetDecimal(4);
                    spGetProd.PRODUCT_CATEGORY_ID = reader.GetDecimal(5);
                    spGetProd.PRODUCT_CATEGORY = reader.GetString(6);
                    spGetProd.PRODUCT_FAMILY_ID = reader.GetDecimal(7);
                    getProdFromSl.Add(spGetProd);
                }

                getProdFrmSerial.getProdFrmSl = getProdFromSl;
                getProdFrmSerial.errCode = Convert.ToDecimal(errCode);
                getProdFrmSerial.errMsgEng = errMsgEng;
                getProdFrmSerial.errMsgBan = errMsgBan;

                reader.Close();
                cmd.Connection.Close();
               
                return getProdFrmSerial;
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
                GetProdFrmSerial getProdFrmSerial = new GetProdFrmSerial();
                List<SP_GET_PRODUCT_FROM_SL> getProdFromSl = new List<SP_GET_PRODUCT_FROM_SL>();
                OracleConnection cn = new OracleConnection(connStringMainDB);
                string spName = "SP_FF_GET_PROD_FOR_RETURN";
                OracleCommand cmd = new OracleCommand(spName);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;
                cmd.Parameters.Add(UserId_OP);

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;
                cmd.Parameters.Add(RetailerId_OP);

                OracleParameter ProdTypeId_OP = new OracleParameter();
                ProdTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                ProdTypeId_OP.OracleDbType = OracleDbType.Decimal;
                ProdTypeId_OP.Value = ProdTypeId;
                cmd.Parameters.Add(ProdTypeId_OP);

                OracleParameter StartSerial_OP = new OracleParameter();
                StartSerial_OP.Direction = System.Data.ParameterDirection.Input;
                StartSerial_OP.OracleDbType = OracleDbType.Varchar2;
                StartSerial_OP.Value = StartSl;
                cmd.Parameters.Add(StartSerial_OP);

                OracleParameter EndSerial_OP = new OracleParameter();
                EndSerial_OP.Direction = System.Data.ParameterDirection.Input;
                EndSerial_OP.OracleDbType = OracleDbType.Varchar2;
                EndSerial_OP.Value = EndSl;
                cmd.Parameters.Add(EndSerial_OP);

                OracleParameter errCode_OP = new OracleParameter();
                errCode_OP.Direction = System.Data.ParameterDirection.Output;
                errCode_OP.OracleDbType = OracleDbType.Decimal;
                cmd.Parameters.Add(errCode_OP);

                OracleParameter errMsgEng_OP = new OracleParameter();
                errMsgEng_OP.Direction = System.Data.ParameterDirection.Output;
                errMsgEng_OP.OracleDbType = OracleDbType.NVarchar2;
                errMsgEng_OP.Size = 500;
                cmd.Parameters.Add(errMsgEng_OP);

                OracleParameter errMsgBan_OP = new OracleParameter();
                errMsgBan_OP.Direction = System.Data.ParameterDirection.Output;
                errMsgBan_OP.OracleDbType = OracleDbType.NVarchar2;
                errMsgBan_OP.Size = 500;
                cmd.Parameters.Add(errMsgBan_OP);

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;
                cmd.Parameters.Add(resultOutCurSor);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                string errCode = errCode_OP.Value.ToString();
                string errMsgEng = errMsgEng_OP.Value.ToString();
                string errMsgBan = errMsgBan_OP.Value.ToString();
                OracleDataReader reader = ((OracleRefCursor)resultOutCurSor.Value).GetDataReader();
                while (reader.Read())
                {
                    SP_GET_PRODUCT_FROM_SL spGetProd = new SP_GET_PRODUCT_FROM_SL();
                    spGetProd.PRODUCT_ID = reader.GetDecimal(0);
                    spGetProd.PRODUCT_CODE = reader.GetString(1);
                    spGetProd.PRODUCT_NAME = reader.GetString(2);
                    spGetProd.DESCRIPTION = reader.GetString(3);
                    spGetProd.UNIT_PRICE = reader.GetDecimal(4);
                    spGetProd.PRODUCT_CATEGORY_ID = reader.GetDecimal(5);
                    spGetProd.PRODUCT_CATEGORY = reader.GetString(6);
                    spGetProd.PRODUCT_FAMILY_ID = reader.GetDecimal(7);
                    getProdFromSl.Add(spGetProd);
                }

                getProdFrmSerial.getProdFrmSl = getProdFromSl;
                getProdFrmSerial.errCode = Convert.ToDecimal(errCode);
                getProdFrmSerial.errMsgEng = errMsgEng;
                getProdFrmSerial.errMsgBan = errMsgBan;

                reader.Close();
                cmd.Connection.Close();

                return getProdFrmSerial;
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
                GetSimStatus getSimStatus = new GetSimStatus();
                OracleConnection cn = new OracleConnection(connStringMainDB);
                string spName = "SP_FF_GET_SIM_STATUS";
                OracleCommand cmd = new OracleCommand(spName);
                cmd.Connection = cn; 
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;
                cmd.Parameters.Add(UserId_OP);

                OracleParameter SimNo_OP = new OracleParameter();
                SimNo_OP.Direction = System.Data.ParameterDirection.Input;
                SimNo_OP.OracleDbType = OracleDbType.Varchar2;
                SimNo_OP.Value = SimNo;
                cmd.Parameters.Add(SimNo_OP);

                OracleParameter statusMsgEng_OP = new OracleParameter();
                statusMsgEng_OP.Direction = System.Data.ParameterDirection.Output;
                statusMsgEng_OP.OracleDbType = OracleDbType.NVarchar2;
                statusMsgEng_OP.Size = 500;
                cmd.Parameters.Add(statusMsgEng_OP);

                OracleParameter statusMsgBan_OP = new OracleParameter();
                statusMsgBan_OP.Direction = System.Data.ParameterDirection.Output;
                statusMsgBan_OP.OracleDbType = OracleDbType.NVarchar2;
                statusMsgBan_OP.Size = 500;
                cmd.Parameters.Add(statusMsgBan_OP);

                OracleParameter errCode_OP = new OracleParameter();
                errCode_OP.Direction = System.Data.ParameterDirection.Output;
                errCode_OP.OracleDbType = OracleDbType.Decimal;
                cmd.Parameters.Add(errCode_OP);

                OracleParameter errMsgEng_OP = new OracleParameter();
                errMsgEng_OP.Direction = System.Data.ParameterDirection.Output;
                errMsgEng_OP.OracleDbType = OracleDbType.NVarchar2;
                errMsgEng_OP.Size = 500;
                cmd.Parameters.Add(errMsgEng_OP);

                OracleParameter errMsgBan_OP = new OracleParameter();
                errMsgBan_OP.Direction = System.Data.ParameterDirection.Output;
                errMsgBan_OP.OracleDbType = OracleDbType.NVarchar2;
                errMsgBan_OP.Size = 500;
                cmd.Parameters.Add(errMsgBan_OP);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
               
                getSimStatus.statusMsgEng = statusMsgEng_OP.Value.ToString();
                getSimStatus.statusMsgBan = statusMsgBan_OP.Value.ToString();
                getSimStatus.errCode = Convert.ToDecimal(errCode_OP.Value.ToString());
                getSimStatus.errMsgEng = errMsgEng_OP.Value.ToString();
                getSimStatus.errMsgBan = errMsgBan_OP.Value.ToString();

                cmd.Connection.Close();

                return getSimStatus;
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
                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RET_TOPUP_STATUS>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RET_TOPUP_STATUS>.GetDataBySP(new SP_GET_RET_TOPUP_STATUS(), "SP_FF_GET_RET_TOPUP_STATUS", 3, resultOutCurSor, RetailerId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public TopupIssueRetailer SaveTopupIssueToRetailer(decimal RetailerId, decimal IssuedBy, string PassCode, decimal TopupAmt, decimal VisitId, decimal Latitude, decimal Longitude)
        {
            TopupIssueRetailer topupIssueRetailer = new TopupIssueRetailer();
            OracleConnection cn = new OracleConnection(connStringMainDB);
            string spName = "FF_INS_TOPUP_ISSUE_RETAILER_V2";
            //string spName = "SP_FF_INS_TOPUP_ISSUE_RETAILER";
            OracleCommand cmd = new OracleCommand(spName);
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            { 
                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;
                cmd.Parameters.Add(RetailerId_OP);

                OracleParameter IssuedBy_OP = new OracleParameter();
                IssuedBy_OP.Direction = System.Data.ParameterDirection.Input;
                IssuedBy_OP.OracleDbType = OracleDbType.Decimal;
                IssuedBy_OP.Value = IssuedBy;
                cmd.Parameters.Add(IssuedBy_OP);

                OracleParameter PassCode_OP = new OracleParameter();
                PassCode_OP.Direction = System.Data.ParameterDirection.Input;
                PassCode_OP.OracleDbType = OracleDbType.Varchar2;
                PassCode_OP.Value = PassCode;
                cmd.Parameters.Add(PassCode_OP);

                OracleParameter TopupAmt_OP = new OracleParameter();
                TopupAmt_OP.Direction = System.Data.ParameterDirection.Input;
                TopupAmt_OP.OracleDbType = OracleDbType.Decimal;
                TopupAmt_OP.Value = TopupAmt;
                cmd.Parameters.Add(TopupAmt_OP);

                OracleParameter VisitId_OP = new OracleParameter();
                VisitId_OP.Direction = System.Data.ParameterDirection.Input;
                VisitId_OP.OracleDbType = OracleDbType.Decimal;
                VisitId_OP.Value = VisitId;
                cmd.Parameters.Add(VisitId_OP);

                OracleParameter Latitude_OP = new OracleParameter();
                Latitude_OP.Direction = System.Data.ParameterDirection.Input;
                Latitude_OP.OracleDbType = OracleDbType.Decimal;
                Latitude_OP.Value = Latitude;
                cmd.Parameters.Add(Latitude_OP);

                OracleParameter Longitude_OP = new OracleParameter();
                Longitude_OP.Direction = System.Data.ParameterDirection.Input;
                Longitude_OP.OracleDbType = OracleDbType.Decimal;
                Longitude_OP.Value = Longitude;
                cmd.Parameters.Add(Longitude_OP);

                OracleParameter transId_OP = new OracleParameter();
                transId_OP.Direction = System.Data.ParameterDirection.Output;
                transId_OP.OracleDbType = OracleDbType.Decimal;
                cmd.Parameters.Add(transId_OP);

                OracleParameter errCode_OP = new OracleParameter();
                errCode_OP.Direction = System.Data.ParameterDirection.Output;
                errCode_OP.OracleDbType = OracleDbType.Decimal;
                cmd.Parameters.Add(errCode_OP);

                OracleParameter errMsgEng_OP = new OracleParameter();
                errMsgEng_OP.Direction = System.Data.ParameterDirection.Output;
                errMsgEng_OP.OracleDbType = OracleDbType.NVarchar2;
                errMsgEng_OP.Size = 500;
                cmd.Parameters.Add(errMsgEng_OP);

                OracleParameter errMsgBan_OP = new OracleParameter();
                errMsgBan_OP.Direction = System.Data.ParameterDirection.Output;
                errMsgBan_OP.OracleDbType = OracleDbType.NVarchar2;
                errMsgBan_OP.Size = 500;
                cmd.Parameters.Add(errMsgBan_OP);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                
                topupIssueRetailer.transId = Convert.ToDecimal(transId_OP.Value.ToString());
                topupIssueRetailer.errCode = Convert.ToDecimal(errCode_OP.Value.ToString());
                topupIssueRetailer.errMsgEng = errMsgEng_OP.Value.ToString();
                topupIssueRetailer.errMsgBan = errMsgBan_OP.Value.ToString();

                cmd.Connection.Close();

                return topupIssueRetailer;
            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                throw ex;
            }
        }



		public TopupIssueRetailer SaveTopupIssueToRetailer_with_Transactionscope(decimal RetailerId, decimal IssuedBy, string PassCode, decimal TopupAmt, decimal VisitId, decimal Latitude, decimal Longitude)
		{
			TopupIssueRetailer topupIssueRetailer = new TopupIssueRetailer();
			OracleConnection cn = new OracleConnection(connStringMainDB);
			string spName = "SP_FF_INS_TOPUP_ISSUE_RETAILER";
			OracleCommand cmd = new OracleCommand(spName);
			cmd.Connection = cn;
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			try
			{
				OracleParameter RetailerId_OP = new OracleParameter();
				RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
				RetailerId_OP.OracleDbType = OracleDbType.Decimal;
				RetailerId_OP.Value = RetailerId;
				cmd.Parameters.Add(RetailerId_OP);

				OracleParameter IssuedBy_OP = new OracleParameter();
				IssuedBy_OP.Direction = System.Data.ParameterDirection.Input;
				IssuedBy_OP.OracleDbType = OracleDbType.Decimal;
				IssuedBy_OP.Value = IssuedBy;
				cmd.Parameters.Add(IssuedBy_OP);

				OracleParameter PassCode_OP = new OracleParameter();
				PassCode_OP.Direction = System.Data.ParameterDirection.Input;
				PassCode_OP.OracleDbType = OracleDbType.Varchar2;
				PassCode_OP.Value = PassCode;
				cmd.Parameters.Add(PassCode_OP);

				OracleParameter TopupAmt_OP = new OracleParameter();
				TopupAmt_OP.Direction = System.Data.ParameterDirection.Input;
				TopupAmt_OP.OracleDbType = OracleDbType.Decimal;
				TopupAmt_OP.Value = TopupAmt;
				cmd.Parameters.Add(TopupAmt_OP);

				OracleParameter VisitId_OP = new OracleParameter();
				VisitId_OP.Direction = System.Data.ParameterDirection.Input;
				VisitId_OP.OracleDbType = OracleDbType.Decimal;
				VisitId_OP.Value = VisitId;
				cmd.Parameters.Add(VisitId_OP);

				OracleParameter Latitude_OP = new OracleParameter();
				Latitude_OP.Direction = System.Data.ParameterDirection.Input;
				Latitude_OP.OracleDbType = OracleDbType.Decimal;
				Latitude_OP.Value = Latitude;
				cmd.Parameters.Add(Latitude_OP);

				OracleParameter Longitude_OP = new OracleParameter();
				Longitude_OP.Direction = System.Data.ParameterDirection.Input;
				Longitude_OP.OracleDbType = OracleDbType.Decimal;
				Longitude_OP.Value = Longitude;
				cmd.Parameters.Add(Longitude_OP);

				OracleParameter transId_OP = new OracleParameter();
				transId_OP.Direction = System.Data.ParameterDirection.Output;
				transId_OP.OracleDbType = OracleDbType.Decimal;
				cmd.Parameters.Add(transId_OP);

				OracleParameter errCode_OP = new OracleParameter();
				errCode_OP.Direction = System.Data.ParameterDirection.Output;
				errCode_OP.OracleDbType = OracleDbType.Decimal;
				cmd.Parameters.Add(errCode_OP);

				OracleParameter errMsgEng_OP = new OracleParameter();
				errMsgEng_OP.Direction = System.Data.ParameterDirection.Output;
				errMsgEng_OP.OracleDbType = OracleDbType.NVarchar2;
				errMsgEng_OP.Size = 500;
				cmd.Parameters.Add(errMsgEng_OP);

				OracleParameter errMsgBan_OP = new OracleParameter();
				errMsgBan_OP.Direction = System.Data.ParameterDirection.Output;
				errMsgBan_OP.OracleDbType = OracleDbType.NVarchar2;
				errMsgBan_OP.Size = 500;
				cmd.Parameters.Add(errMsgBan_OP);

				cmd.Connection.Open();
				cmd.ExecuteNonQuery();


				topupIssueRetailer.transId = Convert.ToDecimal(transId_OP.Value.ToString());
				topupIssueRetailer.errCode = Convert.ToDecimal(errCode_OP.Value.ToString());
				topupIssueRetailer.errMsgEng = errMsgEng_OP.Value.ToString();
				topupIssueRetailer.errMsgBan = errMsgBan_OP.Value.ToString();

				cmd.Connection.Close();

				return topupIssueRetailer;
			}
			catch (Exception ex)
			{
				cmd.Connection.Close();
				throw ex;
			}
		}



		public GetProdFrmSerial GetSalesMemo(decimal UserId, decimal RetailerId, decimal ProdTypeId, string StartSl, string EndSl)
        {
            try
            {
                GetProdFrmSerial getProdFrmSerial = new GetProdFrmSerial();
                List<SP_GET_PRODUCT_FROM_SL> getProdFromSl = new List<SP_GET_PRODUCT_FROM_SL>();
                OracleConnection cn = new OracleConnection(connStringMainDB);
                string spName = "SP_FF_GET_SALES_MEMO";
                OracleCommand cmd = new OracleCommand(spName);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;
                cmd.Parameters.Add(UserId_OP);

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;
                cmd.Parameters.Add(RetailerId_OP);

                OracleParameter ProdTypeId_OP = new OracleParameter();
                ProdTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                ProdTypeId_OP.OracleDbType = OracleDbType.Decimal;
                ProdTypeId_OP.Value = ProdTypeId;
                cmd.Parameters.Add(ProdTypeId_OP);

                OracleParameter StartSerial_OP = new OracleParameter();
                StartSerial_OP.Direction = System.Data.ParameterDirection.Input;
                StartSerial_OP.OracleDbType = OracleDbType.Varchar2;
                StartSerial_OP.Value = StartSl;
                cmd.Parameters.Add(StartSerial_OP);

                OracleParameter EndSerial_OP = new OracleParameter();
                EndSerial_OP.Direction = System.Data.ParameterDirection.Input;
                EndSerial_OP.OracleDbType = OracleDbType.Varchar2;
                EndSerial_OP.Value = EndSl;
                cmd.Parameters.Add(EndSerial_OP);

                OracleParameter errCode_OP = new OracleParameter();
                errCode_OP.Direction = System.Data.ParameterDirection.Output;
                errCode_OP.OracleDbType = OracleDbType.Decimal;
                cmd.Parameters.Add(errCode_OP);

                OracleParameter errMsgEng_OP = new OracleParameter();
                errMsgEng_OP.Direction = System.Data.ParameterDirection.Output;
                errMsgEng_OP.OracleDbType = OracleDbType.NVarchar2;
                errMsgEng_OP.Size = 500;
                cmd.Parameters.Add(errMsgEng_OP);

                OracleParameter errMsgBan_OP = new OracleParameter();
                errMsgBan_OP.Direction = System.Data.ParameterDirection.Output;
                errMsgBan_OP.OracleDbType = OracleDbType.NVarchar2;
                errMsgBan_OP.Size = 500;
                cmd.Parameters.Add(errMsgBan_OP);

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;
                cmd.Parameters.Add(resultOutCurSor);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                string errCode = errCode_OP.Value.ToString();
                string errMsgEng = errMsgEng_OP.Value.ToString();
                string errMsgBan = errMsgBan_OP.Value.ToString();
                OracleDataReader reader = ((OracleRefCursor)resultOutCurSor.Value).GetDataReader();
                while (reader.Read())
                {
                    SP_GET_PRODUCT_FROM_SL spGetProd = new SP_GET_PRODUCT_FROM_SL();
                    spGetProd.PRODUCT_ID = reader.GetDecimal(0);
                    spGetProd.PRODUCT_CODE = reader.GetString(1);
                    spGetProd.PRODUCT_NAME = reader.GetString(2);
                    spGetProd.DESCRIPTION = reader.GetString(3);
                    spGetProd.UNIT_PRICE = reader.GetDecimal(4);
                    spGetProd.PRODUCT_CATEGORY_ID = reader.GetDecimal(5);
                    spGetProd.PRODUCT_CATEGORY = reader.GetString(6);
                    spGetProd.PRODUCT_FAMILY_ID = reader.GetDecimal(7);
                    getProdFromSl.Add(spGetProd);
                }

                getProdFrmSerial.getProdFrmSl = getProdFromSl;
                getProdFrmSerial.errCode = Convert.ToDecimal(errCode);
                getProdFrmSerial.errMsgEng = errMsgEng;
                getProdFrmSerial.errMsgBan = errMsgBan;

                reader.Close();
                cmd.Connection.Close();

                return getProdFrmSerial;
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
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_FOC_PRODUCT>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FOC_PRODUCT>.GetDataBySP(new SP_GET_FOC_PRODUCT(), "SP_FF_GET_FOC_PRODUCT", 4, resultOutCurSor, UserId_OP);
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
        public List<SP_INS_UPD_PRODUCT_SALEPRICEcls> GetAllProductPrice(Decimal familyID, Decimal categoryID, Decimal subCategoryID, Decimal productID, Decimal productPriceID, Decimal currentPageNo)
        {
            try
            {
                OracleParameter familyID_OP = new OracleParameter();
                familyID_OP.Direction = System.Data.ParameterDirection.Input;
                familyID_OP.OracleDbType = OracleDbType.Decimal;
                familyID_OP.Value = familyID;

                OracleParameter categoryID_OP = new OracleParameter();
                categoryID_OP.Direction = System.Data.ParameterDirection.Input;
                categoryID_OP.OracleDbType = OracleDbType.Decimal;
                categoryID_OP.Value = categoryID;

                OracleParameter subCategoryID_OP = new OracleParameter();
                subCategoryID_OP.Direction = System.Data.ParameterDirection.Input;
                subCategoryID_OP.OracleDbType = OracleDbType.Decimal;
                subCategoryID_OP.Value = subCategoryID;

                OracleParameter productID_OP = new OracleParameter();
                productID_OP.Direction = System.Data.ParameterDirection.Input;
                productID_OP.OracleDbType = OracleDbType.Decimal;
                productID_OP.Value = productID;

                OracleParameter productPriceID_OP = new OracleParameter();
                productPriceID_OP.Direction = System.Data.ParameterDirection.Input;
                productPriceID_OP.OracleDbType = OracleDbType.Decimal;
                productPriceID_OP.Value = productPriceID;

                OracleParameter currentPageNoOP = new OracleParameter();
                currentPageNoOP.Direction = System.Data.ParameterDirection.Input;
                currentPageNoOP.OracleDbType = OracleDbType.Decimal;
                currentPageNoOP.Value = currentPageNo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_INS_UPD_PRODUCT_SALEPRICEcls>)ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_PRODUCT_SALEPRICEcls>.GetDataBySP(new SP_INS_UPD_PRODUCT_SALEPRICEcls(), "SP_GET_PRODUCT_SALEPRICE", 18, resultOutCurSor, familyID_OP, categoryID_OP, subCategoryID_OP, productID_OP, productPriceID_OP, currentPageNoOP);
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
                OracleParameter p_TBLPRODUCTSUBCATEGORY_ID_OP = new OracleParameter();
                p_TBLPRODUCTSUBCATEGORY_ID_OP.Direction = System.Data.ParameterDirection.Input;
                p_TBLPRODUCTSUBCATEGORY_ID_OP.OracleDbType = OracleDbType.Varchar2;
                p_TBLPRODUCTSUBCATEGORY_ID_OP.Value = p_TBLPRODUCTSUBCATEGORY_ID;

                OracleParameter p_UPDATE_BY_OP = new OracleParameter();
                p_UPDATE_BY_OP.Direction = System.Data.ParameterDirection.Input;
                p_UPDATE_BY_OP.OracleDbType = OracleDbType.Decimal;
                p_UPDATE_BY_OP.Value = p_UPDATE_BY;

                OracleParameter p_TBLPRODUCTCATEGORY_ID_OP = new OracleParameter();
                p_TBLPRODUCTCATEGORY_ID_OP.Direction = System.Data.ParameterDirection.Input;
                p_TBLPRODUCTCATEGORY_ID_OP.OracleDbType = OracleDbType.Decimal;
                p_TBLPRODUCTCATEGORY_ID_OP.Value = p_TBLPRODUCTCATEGORY_ID;

                OracleParameter p_UPDATE_DATE_OP = new OracleParameter();
                p_UPDATE_DATE_OP.Direction = System.Data.ParameterDirection.Input;
                p_UPDATE_DATE_OP.OracleDbType = OracleDbType.Date;
                p_UPDATE_DATE_OP.Value = p_UPDATE_DATE;

                OracleParameter p_TBLPRODFAMILY_ID_OP = new OracleParameter();
                p_TBLPRODFAMILY_ID_OP.Direction = System.Data.ParameterDirection.Input;
                p_TBLPRODFAMILY_ID_OP.OracleDbType = OracleDbType.Decimal;
                p_TBLPRODFAMILY_ID_OP.Value = p_TBLPRODFAMILY_ID;

                OracleParameter p_PRODUCT_SALEPRICE_ID_OP = new OracleParameter();
                p_PRODUCT_SALEPRICE_ID_OP.Direction = System.Data.ParameterDirection.Input;
                p_PRODUCT_SALEPRICE_ID_OP.OracleDbType = OracleDbType.Decimal;
                p_PRODUCT_SALEPRICE_ID_OP.Value = p_PRODUCT_SALEPRICE_ID;

                OracleParameter p_CREATE_BY_OP = new OracleParameter();
                p_CREATE_BY_OP.Direction = System.Data.ParameterDirection.Input;
                p_CREATE_BY_OP.OracleDbType = OracleDbType.Decimal;
                p_CREATE_BY_OP.Value = p_CREATE_BY;

                OracleParameter p_NOTE_OP = new OracleParameter();
                p_NOTE_OP.Direction = System.Data.ParameterDirection.Input;
                p_NOTE_OP.OracleDbType = OracleDbType.NVarchar2;
                p_NOTE_OP.Value = p_NOTE;

                OracleParameter p_CREATE_DATE_OP = new OracleParameter();
                p_CREATE_DATE_OP.Direction = System.Data.ParameterDirection.Input;
                p_CREATE_DATE_OP.OracleDbType = OracleDbType.Date;
                p_CREATE_DATE_OP.Value = p_CREATE_DATE;

                OracleParameter p_TBLPRODUCTID_OP = new OracleParameter();
                p_TBLPRODUCTID_OP.Direction = System.Data.ParameterDirection.Input;
                p_TBLPRODUCTID_OP.OracleDbType = OracleDbType.Decimal;
                p_TBLPRODUCTID_OP.Value = p_TBLPRODUCTID;

                OracleParameter p_ISDISPLAY_PRICE_OP = new OracleParameter();
                p_ISDISPLAY_PRICE_OP.Direction = System.Data.ParameterDirection.Input;
                p_ISDISPLAY_PRICE_OP.OracleDbType = OracleDbType.Decimal;
                p_ISDISPLAY_PRICE_OP.Value = p_ISDISPLAY_PRICE;

                OracleParameter p_SALESPRICE_OP = new OracleParameter();
                p_SALESPRICE_OP.Direction = System.Data.ParameterDirection.Input;
                p_SALESPRICE_OP.OracleDbType = OracleDbType.Decimal;
                p_SALESPRICE_OP.Value = p_SALESPRICE;

                OracleParameter outProductSalePriceIDOP = new OracleParameter();
                outProductSalePriceIDOP.Direction = System.Data.ParameterDirection.Output;
                outProductSalePriceIDOP.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_PRODUCT_SALEPRICEcls>.InsertDataBySP("SP_INS_UPD_PRODUCT_SALEPRICE", outProductSalePriceIDOP, p_TBLPRODUCTSUBCATEGORY_ID_OP,
                        p_UPDATE_BY_OP, p_TBLPRODUCTCATEGORY_ID_OP, p_UPDATE_DATE_OP, p_TBLPRODFAMILY_ID_OP, p_PRODUCT_SALEPRICE_ID_OP, p_CREATE_BY_OP, p_NOTE_OP, p_CREATE_DATE_OP,
                        p_TBLPRODUCTID_OP, p_ISDISPLAY_PRICE_OP, p_SALESPRICE_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
