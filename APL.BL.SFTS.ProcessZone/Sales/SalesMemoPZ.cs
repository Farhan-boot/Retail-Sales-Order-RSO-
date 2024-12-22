using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.Sales;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.Sales
{
    public class SalesMemoPZ
    {
        public decimal SaveSalesMemo(decimal Id, DateTime MemoDate, decimal CustomerId, decimal prodTypeId, decimal GrossAmount, decimal NetAmount,
                                        decimal VisitId, decimal latitude, decimal longitude, decimal CreatedBy)
        {
            try
            {
                return new SalesMemoDZ().SaveSalesMemo(Id, MemoDate, CustomerId, prodTypeId, GrossAmount, NetAmount, VisitId, latitude, longitude, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         
        public decimal SaveSalesReturn(decimal Id, DateTime ReturnDate, decimal CustomerId, decimal prodTypeId,
                                      decimal VisitId, decimal latitude, decimal longitude, decimal CreatedBy)
        {
            try
            {
                return new SalesMemoDZ().SaveSalesReturn(Id, ReturnDate, CustomerId, prodTypeId, VisitId, latitude, longitude, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveSalesMemoComplited(decimal Id, decimal CreatedBy)
        {
            try
            {
                return new SalesMemoDZ().SaveSalesMemoCompleted(Id, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetDeliveryStatus GetMemoDeliveryStatus(decimal TempMemoId)
        {
            try
            {
                return new SalesMemoDZ().GetMemoDeliveryStatus(TempMemoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetProdReturnStatus GetProductReturnStatus(decimal ReturnId)
        {
            try
            {
                return new SalesMemoDZ().GetProductReturnStatus(ReturnId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_TOPUP_ISSUE> GetTodaysTopupIssueHistory(decimal UserId, decimal RetailerId, DateTime? FromDate, DateTime? ToDate, decimal TopupIssueStatus)
        {
            try
            {
                return new SalesMemoDZ().GetTodaysTopupIssueHistory(UserId, RetailerId, FromDate, ToDate, TopupIssueStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetTopupIssueStatus GetTopupIssueStatus(decimal IssueId)
        {
            try
            {
                return new SalesMemoDZ().GetTopupIssueStatus(IssueId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveSalesReturnComplited(decimal Id, decimal CreatedBy)
        {
            try
            {
                return new SalesMemoDZ().SaveSalesReturnCompleted(Id, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal DeleteExistingProduct(decimal MemoId)
        {
            try
            {
                return new SalesMemoDZ().DeleteExistingProduct(MemoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public decimal SaveSalesMemoProduct(decimal Id, decimal MemoId,
                                        decimal ProductId, decimal SalesQty, decimal Price,
                                        string Remarks, decimal CreatedBy)
        {
            try
            {
                return new SalesMemoDZ().SaveSalesMemoProduct(Id, MemoId, ProductId, SalesQty, Price, Remarks, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveSalesReturnProduct(decimal Id, decimal ReturnId,
                                       decimal ProductId, decimal ReturnQty,
                                       string Remarks, decimal CreatedBy)
        {
            try
            {
                return new SalesMemoDZ().SaveSalesReturnProduct(Id, ReturnId, ProductId, ReturnQty, Remarks, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public decimal SaveMemoProductSerial(decimal Id, decimal SalesMemoProductId,
                                        decimal ProductId, string StartSerial, string EndSerial,
                                        decimal Quantity, decimal TotalQty,decimal CreatedBy)
        {
            try
            {
                return new SalesMemoDZ().SaveMemoProductSerial(Id, SalesMemoProductId, ProductId, StartSerial, EndSerial, Quantity, TotalQty, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveReturnProductSerial(decimal Id, decimal SalesReturnProductId,
                                      decimal ProductId, string StartSerial, string EndSerial,
                                      decimal Quantity, decimal TotalQty, decimal CreatedBy)
        {
            try
            {
                return new SalesMemoDZ().SaveReturnProductSerial(Id, SalesReturnProductId, ProductId, StartSerial, EndSerial, Quantity, TotalQty, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_MEMO> GetMemo(string MemoNo)
        {
            try
            {
                return new SalesMemoDZ().GetMemo(MemoNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         
        public List<SP_GET_SALES_MEMO> GetSalesMemo(decimal UserId, decimal RetailerId, DateTime? FromDate, DateTime? ToDate, string MemoId)
        {
            try
            {
                return new SalesMemoDZ().GetSalesMemo(UserId, RetailerId, FromDate, ToDate, MemoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_FF_GET_RETURN_MEMO> GetReturnMemo(decimal UserId, decimal RetailerId, DateTime? FromDate, DateTime? ToDate, decimal ReturnId)
        {
            try
            {
                return new SalesMemoDZ().GetReturnMemo(UserId, RetailerId, FromDate, ToDate, ReturnId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_MEMO> GetMemoById(decimal MemoId)
        {
            try
            {
                return new SalesMemoDZ().GetMemoById(MemoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<SP_GET_DELIVERED_MEMO_SERIAL> GetDeliveredMemoSerials(decimal MemoProductSerialId, decimal MemoProductId, decimal ProductId)
        {
            try
            {
                return new SalesMemoDZ().GetDeliveredMemoSerials(MemoProductSerialId, MemoProductId, ProductId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
