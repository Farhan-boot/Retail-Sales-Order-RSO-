using APL.BL.SFTS.DataBridgeZone.RSO;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using APL.BL.SFTS.Models.SystemCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.RSO
{
    public class RSOSUpdateStockPZ
    {
        public RSOSUpdateStockPZ() { }

        public List<GET_PRODUCT_TYPE> GetProductType()
        {
            try
            {
                return new RSOSUpdateStockDZ().GetProductType();
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
                return new RSOSUpdateStockDZ().GetProductByPType(prodTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool GetIsValidProductQty(long UserId,decimal ProdTypeId, decimal ProductId,decimal Quantity)
        {
            try
            {
                return new RSOSUpdateStockDZ().GetIsValidProductQty(UserId, ProdTypeId, ProductId, Quantity).FirstOrDefault().IS_VALID==1?true:false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public decimal SaveRSOStock(decimal userId, decimal productId, decimal quantity, decimal price, decimal stockId, string strMode)
        {
            try
            {
                return new RSOSUpdateStockDZ().SaveRSOStock(userId, productId, quantity,price, stockId, strMode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal ReturnRSOStock(decimal userId, string msisdn)
        {
            try
            {
                return new RSOSUpdateStockDZ().ReturnRSOStock(userId, msisdn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_FF_GET_RSO_STOCK> GetRSOStock(vmCmnParameters cmnParam)
        {
            SearchParam searchParam = new SearchParam();
            searchParam.FromDate = cmnParam.FromDate;
            searchParam.ToDate = cmnParam.ToDate;
            List<SP_FF_GET_RSO_STOCK> retailerSales = new List<SP_FF_GET_RSO_STOCK>();
            try
            {
                retailerSales = new RSOSUpdateStockDZ().GetRSOStock(searchParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return retailerSales;
        }
    }
}
