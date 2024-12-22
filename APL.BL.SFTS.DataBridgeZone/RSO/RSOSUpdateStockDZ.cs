using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.RSO
{
    public class RSOSUpdateStockDZ
    {
        public RSOSUpdateStockDZ()
        { }


        public List<GET_PRODUCT_TYPE> GetProductType()
        {
            try
            {
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_PRODUCT_TYPE>)ObjectMakerFromOracleSP.OracleHelper<GET_PRODUCT_TYPE>.GetDataBySP(new GET_PRODUCT_TYPE(), "SP_FF_GET_PRODUCT_TYPE", 5, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GET_PRODUCTS> GetProductByPType(decimal prodTypeId)
        {
            try
            {
                OracleParameter prodTypeId_OP = new OracleParameter();
                prodTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                prodTypeId_OP.OracleDbType = OracleDbType.Decimal;
                prodTypeId_OP.Value = prodTypeId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List < GET_PRODUCTS>)ObjectMakerFromOracleSP.OracleHelper<GET_PRODUCTS>.GetDataBySP(new GET_PRODUCTS(), "SP_FF_GET_PRODUCT_BY_PTYPE", 5, resultOutCurSor, prodTypeId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ISVALID_PRDCT_QTY> GetIsValidProductQty(long UserId,decimal ProdTypeId, decimal ProductId, decimal Quantity)
        {
            try
            {
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Long;
                UserId_OP.Value = UserId;

                OracleParameter ProdTypeId_OP = new OracleParameter();
                ProdTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                ProdTypeId_OP.OracleDbType = OracleDbType.Decimal;
                ProdTypeId_OP.Value = ProdTypeId;

                OracleParameter ProductId_OP = new OracleParameter();
                ProductId_OP.Direction = System.Data.ParameterDirection.Input;
                ProductId_OP.OracleDbType = OracleDbType.Decimal;
                ProductId_OP.Value = ProductId;

                OracleParameter Quantity_OP = new OracleParameter();
                Quantity_OP.Direction = System.Data.ParameterDirection.Input;
                Quantity_OP.OracleDbType = OracleDbType.Decimal;
                Quantity_OP.Value = Quantity;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List < ISVALID_PRDCT_QTY>)ObjectMakerFromOracleSP.OracleHelper<ISVALID_PRDCT_QTY>.GetDataBySP(new ISVALID_PRDCT_QTY(), "SP_FF_ISVALID_PRDCT_QTY",1, resultOutCurSor, UserId_OP, ProdTypeId_OP,ProductId_OP, Quantity_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveRSOStock(decimal userId, decimal productId, decimal quantity, decimal price, decimal stockId, string strMode)
        {
            try
            {
                OracleParameter userIdOP = new OracleParameter();
                userIdOP.Direction = System.Data.ParameterDirection.Input;
                userIdOP.OracleDbType = OracleDbType.Decimal;
                userIdOP.Value = userId;

                OracleParameter productIdOP = new OracleParameter();
                productIdOP.Direction = System.Data.ParameterDirection.Input;
                productIdOP.OracleDbType = OracleDbType.Decimal;
                productIdOP.Value = productId;

                OracleParameter quantityOP = new OracleParameter();
                quantityOP.Direction = System.Data.ParameterDirection.Input;
                quantityOP.OracleDbType = OracleDbType.Int32;
                quantityOP.Value = Convert.ToInt32(quantity);

                OracleParameter priceOP = new OracleParameter();
                priceOP.Direction = System.Data.ParameterDirection.Input;
                priceOP.OracleDbType = OracleDbType.Decimal;
                priceOP.Value = price;

                int v_out=0;
                OracleParameter resultOP = new OracleParameter();
                resultOP.Direction = System.Data.ParameterDirection.Output;
                resultOP.OracleDbType = OracleDbType.Int32;
                resultOP.Value = v_out;

                OracleParameter stockIdOP = new OracleParameter();
                stockIdOP.Direction = System.Data.ParameterDirection.Input;
                stockIdOP.OracleDbType = OracleDbType.Decimal;
                stockIdOP.Value = stockId;

                OracleParameter strModeOP = new OracleParameter();
                strModeOP.Direction = System.Data.ParameterDirection.Input;
                strModeOP.OracleDbType = OracleDbType.Varchar2;
                strModeOP.Value = strMode;

                decimal result= ObjectMakerFromOracleSP.OracleHelper<GET_PRODUCTS>.InsertDataBySP("SP_FF_SAVE_PRODUCT_TO_STOCK", resultOP, userIdOP, productIdOP, quantityOP, priceOP, stockIdOP, strModeOP);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public Decimal ReturnRSOStock(decimal userId, string msisdn)
        {
            try
            {
                OracleParameter userIdOP = new OracleParameter();
                userIdOP.Direction = System.Data.ParameterDirection.Input;
                userIdOP.OracleDbType = OracleDbType.Decimal;
                userIdOP.Value = userId;

				OracleParameter msisdnOP = new OracleParameter();
				msisdnOP.Direction = System.Data.ParameterDirection.Input;
				msisdnOP.OracleDbType = OracleDbType.Varchar2;
				msisdnOP.Value = msisdn;

				int v_out = 0;
                OracleParameter resultOP = new OracleParameter();
                resultOP.Direction = System.Data.ParameterDirection.Output;
                resultOP.OracleDbType = OracleDbType.Int32;
                resultOP.Value = v_out;

                decimal result = ObjectMakerFromOracleSP.OracleHelper<GET_PRODUCTS>.InsertDataBySP("SP_FF_RETURN_RSO_STOCK", resultOP, userIdOP, msisdnOP);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_FF_GET_RSO_STOCK> GetRSOStock(SearchParam searchParam)
        {
            try
            {
                OracleParameter FromDate_OP = new OracleParameter();
                FromDate_OP.Direction = System.Data.ParameterDirection.Input;
                FromDate_OP.OracleDbType = OracleDbType.Date;
                FromDate_OP.Value = searchParam.FromDate;

                OracleParameter ToDate_OP = new OracleParameter();
                ToDate_OP.Direction = System.Data.ParameterDirection.Input;
                ToDate_OP.OracleDbType = OracleDbType.Date;
                ToDate_OP.Value = searchParam.ToDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_FF_GET_RSO_STOCK>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_RSO_STOCK>.GetDataBySP(new SP_FF_GET_RSO_STOCK(), "SP_FF_GET_RSO_STOCK", 6, resultOutCurSor, FromDate_OP, ToDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
