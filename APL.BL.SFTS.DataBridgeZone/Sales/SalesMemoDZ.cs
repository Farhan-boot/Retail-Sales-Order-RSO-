using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.Sales
{
    public class SalesMemoDZ
    {
        readonly string connStringMainDB = ConfigurationManager.ConnectionStrings["APL_DB_ConnString"].ConnectionString;

        public Decimal SaveSalesMemo(decimal Id, DateTime MemoDate, decimal CustomerId, decimal prodTypeId, decimal GrossAmount, decimal NetAmount,
                                        decimal VisitId, decimal latitude, decimal longitude, decimal CreatedBy)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter CustomerId_OP = new OracleParameter();
                CustomerId_OP.Direction = System.Data.ParameterDirection.Input;
                CustomerId_OP.OracleDbType = OracleDbType.Decimal;
                CustomerId_OP.Value = CustomerId;

                OracleParameter ProdTypeId_OP = new OracleParameter();
                ProdTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                ProdTypeId_OP.OracleDbType = OracleDbType.Decimal;
                ProdTypeId_OP.Value = prodTypeId;

                OracleParameter GrossAmount_OP = new OracleParameter();
                GrossAmount_OP.Direction = System.Data.ParameterDirection.Input;
                GrossAmount_OP.OracleDbType = OracleDbType.Decimal;
                GrossAmount_OP.Value = GrossAmount;

                OracleParameter NetAmount_OP = new OracleParameter();
                NetAmount_OP.Direction = System.Data.ParameterDirection.Input;
                NetAmount_OP.OracleDbType = OracleDbType.Decimal;
                NetAmount_OP.Value = NetAmount;

                OracleParameter VisitId_OP = new OracleParameter();
                VisitId_OP.Direction = System.Data.ParameterDirection.Input;
                VisitId_OP.OracleDbType = OracleDbType.Decimal;
                VisitId_OP.Value = VisitId;

                OracleParameter latitude_OP = new OracleParameter();
                latitude_OP.Direction = System.Data.ParameterDirection.Input;
                latitude_OP.OracleDbType = OracleDbType.Decimal;
                latitude_OP.Value = latitude;

                OracleParameter longitude_OP = new OracleParameter();
                longitude_OP.Direction = System.Data.ParameterDirection.Input;
                longitude_OP.OracleDbType = OracleDbType.Decimal;
                longitude_OP.Value = longitude;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_INS_SALES_MEMO_V2", resultOutID, Id_OP, CustomerId_OP, ProdTypeId_OP, GrossAmount_OP, NetAmount_OP, VisitId_OP, latitude_OP, longitude_OP, CreatedBy_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveSalesReturn(decimal Id, DateTime ReturnDate, decimal CustomerId, decimal prodTypeId,
                                       decimal VisitId, decimal latitude, decimal longitude, decimal CreatedBy)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter CustomerId_OP = new OracleParameter();
                CustomerId_OP.Direction = System.Data.ParameterDirection.Input;
                CustomerId_OP.OracleDbType = OracleDbType.Decimal;
                CustomerId_OP.Value = CustomerId;

                OracleParameter ProdTypeId_OP = new OracleParameter();
                ProdTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                ProdTypeId_OP.OracleDbType = OracleDbType.Decimal;
                ProdTypeId_OP.Value = prodTypeId;

                OracleParameter VisitId_OP = new OracleParameter();
                VisitId_OP.Direction = System.Data.ParameterDirection.Input;
                VisitId_OP.OracleDbType = OracleDbType.Decimal;
                VisitId_OP.Value = VisitId;

                OracleParameter latitude_OP = new OracleParameter();
                latitude_OP.Direction = System.Data.ParameterDirection.Input;
                latitude_OP.OracleDbType = OracleDbType.Decimal;
                latitude_OP.Value = latitude;

                OracleParameter longitude_OP = new OracleParameter();
                longitude_OP.Direction = System.Data.ParameterDirection.Input;
                longitude_OP.OracleDbType = OracleDbType.Decimal;
                longitude_OP.Value = longitude;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_INS_SALES_RETURN", resultOutID, Id_OP, CustomerId_OP, ProdTypeId_OP, VisitId_OP, latitude_OP, longitude_OP, CreatedBy_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveSalesMemoCompleted(decimal Id, decimal CreatedBy)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_INS_SALES_MEMO_COMPLETED", resultOutID, Id_OP, CreatedBy_OP);
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
                GetDeliveryStatus getMemoDeliveryStatus = new GetDeliveryStatus();
                OracleConnection cn = new OracleConnection(connStringMainDB);
                string spName = "SP_FF_GET_MEMO_DELIVERY_STATUS";
                OracleCommand cmd = new OracleCommand(spName);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter deliveryStatus_OP = new OracleParameter();
                deliveryStatus_OP.Direction = System.Data.ParameterDirection.Output;
                deliveryStatus_OP.OracleDbType = OracleDbType.Decimal;
                cmd.Parameters.Add(deliveryStatus_OP);

                OracleParameter statusMsgBan_OP = new OracleParameter();
                statusMsgBan_OP.Direction = System.Data.ParameterDirection.Output;
                statusMsgBan_OP.OracleDbType = OracleDbType.NVarchar2;
                statusMsgBan_OP.Size = 500;
                cmd.Parameters.Add(statusMsgBan_OP);

                OracleParameter statusMsgEng_OP = new OracleParameter();
                statusMsgEng_OP.Direction = System.Data.ParameterDirection.Output;
                statusMsgEng_OP.OracleDbType = OracleDbType.NVarchar2;
                statusMsgEng_OP.Size = 500;
                cmd.Parameters.Add(statusMsgEng_OP);

                OracleParameter TempMemoId_OP = new OracleParameter();
                TempMemoId_OP.Direction = System.Data.ParameterDirection.Input;
                TempMemoId_OP.OracleDbType = OracleDbType.Decimal;
                TempMemoId_OP.Value = TempMemoId;
                cmd.Parameters.Add(TempMemoId_OP);


                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                getMemoDeliveryStatus.deliveryStatus = Convert.ToDecimal(deliveryStatus_OP.Value.ToString());
                getMemoDeliveryStatus.statusMsgBan = statusMsgBan_OP.Value.ToString();
                getMemoDeliveryStatus.statusMsgEng = statusMsgEng_OP.Value.ToString();

                cmd.Connection.Close();

                return getMemoDeliveryStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveSalesReturnCompleted(decimal Id, decimal CreatedBy)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_INS_SALES_RET_COMPLETED", resultOutID, Id_OP, CreatedBy_OP);
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
                GetProdReturnStatus getProdReturnStatus = new GetProdReturnStatus();
                OracleConnection cn = new OracleConnection(connStringMainDB);
                string spName = "SP_FF_GET_RETURN_STATUS";
                OracleCommand cmd = new OracleCommand(spName);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter returnStatus_OP = new OracleParameter();
                returnStatus_OP.Direction = System.Data.ParameterDirection.Output;
                returnStatus_OP.OracleDbType = OracleDbType.Decimal;
                cmd.Parameters.Add(returnStatus_OP);

                OracleParameter statusMsgBan_OP = new OracleParameter();
                statusMsgBan_OP.Direction = System.Data.ParameterDirection.Output;
                statusMsgBan_OP.OracleDbType = OracleDbType.NVarchar2;
                statusMsgBan_OP.Size = 500;
                cmd.Parameters.Add(statusMsgBan_OP);

                OracleParameter statusMsgEng_OP = new OracleParameter();
                statusMsgEng_OP.Direction = System.Data.ParameterDirection.Output;
                statusMsgEng_OP.OracleDbType = OracleDbType.NVarchar2;
                statusMsgEng_OP.Size = 500;
                cmd.Parameters.Add(statusMsgEng_OP);

                OracleParameter ReturnId_OP = new OracleParameter();
                ReturnId_OP.Direction = System.Data.ParameterDirection.Input;
                ReturnId_OP.OracleDbType = OracleDbType.Decimal;
                ReturnId_OP.Value = ReturnId;
                cmd.Parameters.Add(ReturnId_OP);


                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                getProdReturnStatus.returnStatus = Convert.ToDecimal(returnStatus_OP.Value.ToString());
                getProdReturnStatus.statusMsgBan = statusMsgBan_OP.Value.ToString();
                getProdReturnStatus.statusMsgEng = statusMsgEng_OP.Value.ToString();

                cmd.Connection.Close();

                return getProdReturnStatus;
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
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter Retailer_OP = new OracleParameter();
                Retailer_OP.Direction = System.Data.ParameterDirection.Input;
                Retailer_OP.OracleDbType = OracleDbType.Decimal;
                Retailer_OP.Value = RetailerId;

                OracleParameter FromDate_OP = new OracleParameter();
                FromDate_OP.Direction = System.Data.ParameterDirection.Input;
                FromDate_OP.OracleDbType = OracleDbType.Date;
                FromDate_OP.Value = FromDate;

                OracleParameter ToDate_OP = new OracleParameter();
                ToDate_OP.Direction = System.Data.ParameterDirection.Input;
                ToDate_OP.OracleDbType = OracleDbType.Date;
                ToDate_OP.Value = ToDate;

                OracleParameter TopupIssueStatus_OP = new OracleParameter();
                TopupIssueStatus_OP.Direction = System.Data.ParameterDirection.Input;
                TopupIssueStatus_OP.OracleDbType = OracleDbType.Decimal;
                TopupIssueStatus_OP.Value = TopupIssueStatus;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_TOPUP_ISSUE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TOPUP_ISSUE>.GetDataBySP(new SP_GET_TOPUP_ISSUE(), "SP_FF_GET_TOPUP_ISSUE", 12, resultOutCurSor, UserId_OP, Retailer_OP, FromDate_OP, ToDate_OP, TopupIssueStatus_OP);
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
                GetTopupIssueStatus getTopupIssueStatus = new GetTopupIssueStatus();
                OracleConnection cn = new OracleConnection(connStringMainDB);
                string spName = "SP_FF_GET_TOPUP_ISSUE_STATUS";
                OracleCommand cmd = new OracleCommand(spName);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter issueStatus_OP = new OracleParameter();
                issueStatus_OP.Direction = System.Data.ParameterDirection.Output;
                issueStatus_OP.OracleDbType = OracleDbType.Decimal;
                cmd.Parameters.Add(issueStatus_OP);

                OracleParameter statusMsgBan_OP = new OracleParameter();
                statusMsgBan_OP.Direction = System.Data.ParameterDirection.Output;
                statusMsgBan_OP.OracleDbType = OracleDbType.NVarchar2;
                statusMsgBan_OP.Size = 500;
                cmd.Parameters.Add(statusMsgBan_OP);

                OracleParameter statusMsgEng_OP = new OracleParameter();
                statusMsgEng_OP.Direction = System.Data.ParameterDirection.Output;
                statusMsgEng_OP.OracleDbType = OracleDbType.NVarchar2;
                statusMsgEng_OP.Size = 500;
                cmd.Parameters.Add(statusMsgEng_OP);

                OracleParameter IssueId_OP = new OracleParameter();
                IssueId_OP.Direction = System.Data.ParameterDirection.Input;
                IssueId_OP.OracleDbType = OracleDbType.Decimal;
                IssueId_OP.Value = IssueId;
                cmd.Parameters.Add(IssueId_OP);


                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                getTopupIssueStatus.issueStatus = Convert.ToDecimal(issueStatus_OP.Value.ToString());
                getTopupIssueStatus.statusMsgBan = statusMsgBan_OP.Value.ToString();
                getTopupIssueStatus.statusMsgEng = statusMsgEng_OP.Value.ToString();

                cmd.Connection.Close();

                return getTopupIssueStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal DeleteExistingProduct(decimal MemoId)
        {
            try
            {
                OracleParameter MemoId_OP = new OracleParameter();
                MemoId_OP.Direction = System.Data.ParameterDirection.Input;
                MemoId_OP.OracleDbType = OracleDbType.Decimal;
                MemoId_OP.Value = MemoId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_DEL_EXIST_MEMO_PROD", resultOutID, MemoId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Decimal SaveSalesMemoProduct(decimal Id, decimal MemoId,
                                        decimal ProductId, decimal SalesQty, decimal Price,
                                        string Remarks, decimal CreatedBy)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter MemoId_OP = new OracleParameter();
                MemoId_OP.Direction = System.Data.ParameterDirection.Input;
                MemoId_OP.OracleDbType = OracleDbType.Decimal;
                MemoId_OP.Value = MemoId;

                OracleParameter ProductId_OP = new OracleParameter();
                ProductId_OP.Direction = System.Data.ParameterDirection.Input;
                ProductId_OP.OracleDbType = OracleDbType.Decimal;
                ProductId_OP.Value = ProductId;

                OracleParameter SalesQty_OP = new OracleParameter();
                SalesQty_OP.Direction = System.Data.ParameterDirection.Input;
                SalesQty_OP.OracleDbType = OracleDbType.Decimal;
                SalesQty_OP.Value = SalesQty;

                OracleParameter Price_OP = new OracleParameter();
                Price_OP.Direction = System.Data.ParameterDirection.Input;
                Price_OP.OracleDbType = OracleDbType.Decimal;
                Price_OP.Value = Price;

                OracleParameter Remarks_OP = new OracleParameter();
                Remarks_OP.Direction = System.Data.ParameterDirection.Input;
                Remarks_OP.OracleDbType = OracleDbType.Varchar2;
                Remarks_OP.Value = Remarks;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_INS_SALES_MEMO_PROD", resultOutID, Id_OP, MemoId_OP, ProductId_OP, SalesQty_OP, Price_OP, Remarks_OP, CreatedBy_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveSalesReturnProduct(decimal Id, decimal ReturnId,
                                      decimal ProductId, decimal ReturnQty,
                                      string Remarks, decimal CreatedBy)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter ReturnId_OP = new OracleParameter();
                ReturnId_OP.Direction = System.Data.ParameterDirection.Input;
                ReturnId_OP.OracleDbType = OracleDbType.Decimal;
                ReturnId_OP.Value = ReturnId;

                OracleParameter ProductId_OP = new OracleParameter();
                ProductId_OP.Direction = System.Data.ParameterDirection.Input;
                ProductId_OP.OracleDbType = OracleDbType.Decimal;
                ProductId_OP.Value = ProductId;

                OracleParameter ReturnQty_OP = new OracleParameter();
                ReturnQty_OP.Direction = System.Data.ParameterDirection.Input;
                ReturnQty_OP.OracleDbType = OracleDbType.Decimal;
                ReturnQty_OP.Value = ReturnQty;

                OracleParameter Remarks_OP = new OracleParameter();
                Remarks_OP.Direction = System.Data.ParameterDirection.Input;
                Remarks_OP.OracleDbType = OracleDbType.Varchar2;
                Remarks_OP.Value = Remarks;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_INS_SALES_RETURN_PROD", resultOutID, ReturnId_OP, ProductId_OP, ReturnQty_OP, Remarks_OP, CreatedBy_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Decimal SaveMemoProductSerial(decimal Id, decimal SalesMemoProductId,
                                        decimal ProductId, string StartSerial, string EndSerial,
                                        decimal Quantity, decimal TotalQty, decimal CreatedBy)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter SalesMemoProductId_OP = new OracleParameter();
                SalesMemoProductId_OP.Direction = System.Data.ParameterDirection.Input;
                SalesMemoProductId_OP.OracleDbType = OracleDbType.Decimal;
                SalesMemoProductId_OP.Value = SalesMemoProductId;

                OracleParameter ProductId_OP = new OracleParameter();
                ProductId_OP.Direction = System.Data.ParameterDirection.Input;
                ProductId_OP.OracleDbType = OracleDbType.Decimal;
                ProductId_OP.Value = ProductId;

                OracleParameter StartSerial_OP = new OracleParameter();
                StartSerial_OP.Direction = System.Data.ParameterDirection.Input;
                StartSerial_OP.OracleDbType = OracleDbType.Varchar2;
                StartSerial_OP.Value = StartSerial;

                OracleParameter EndSerial_OP = new OracleParameter();
                EndSerial_OP.Direction = System.Data.ParameterDirection.Input;
                EndSerial_OP.OracleDbType = OracleDbType.Varchar2;
                EndSerial_OP.Value = EndSerial;

                OracleParameter Quantity_OP = new OracleParameter();
                Quantity_OP.Direction = System.Data.ParameterDirection.Input;
                Quantity_OP.OracleDbType = OracleDbType.Decimal;
                Quantity_OP.Value = Quantity;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_INS_SALES_MEMO_PROD_SL", resultOutID, SalesMemoProductId_OP, ProductId_OP, StartSerial_OP, EndSerial_OP, Quantity_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveReturnProductSerial(decimal Id, decimal SalesReturnProductId,
                                     decimal ProductId, string StartSerial, string EndSerial,
                                     decimal Quantity, decimal TotalQty, decimal CreatedBy)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter SalesReturnProductId_OP = new OracleParameter();
                SalesReturnProductId_OP.Direction = System.Data.ParameterDirection.Input;
                SalesReturnProductId_OP.OracleDbType = OracleDbType.Decimal;
                SalesReturnProductId_OP.Value = SalesReturnProductId;

                OracleParameter ProductId_OP = new OracleParameter();
                ProductId_OP.Direction = System.Data.ParameterDirection.Input;
                ProductId_OP.OracleDbType = OracleDbType.Decimal;
                ProductId_OP.Value = ProductId;

                OracleParameter StartSerial_OP = new OracleParameter();
                StartSerial_OP.Direction = System.Data.ParameterDirection.Input;
                StartSerial_OP.OracleDbType = OracleDbType.Varchar2;
                StartSerial_OP.Value = StartSerial;

                OracleParameter EndSerial_OP = new OracleParameter();
                EndSerial_OP.Direction = System.Data.ParameterDirection.Input;
                EndSerial_OP.OracleDbType = OracleDbType.Varchar2;
                EndSerial_OP.Value = EndSerial;

                OracleParameter Quantity_OP = new OracleParameter();
                Quantity_OP.Direction = System.Data.ParameterDirection.Input;
                Quantity_OP.OracleDbType = OracleDbType.Decimal;
                Quantity_OP.Value = Quantity;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_INS_SALES_RETURN_PROD_SL", resultOutID, SalesReturnProductId_OP, ProductId_OP, StartSerial_OP, EndSerial_OP, Quantity_OP);
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
                OracleParameter MemoNo_OP = new OracleParameter();
                MemoNo_OP.Direction = System.Data.ParameterDirection.Input;
                MemoNo_OP.OracleDbType = OracleDbType.Varchar2;
                MemoNo_OP.Value = MemoNo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_MEMO>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_MEMO>.GetDataBySP(new SP_GET_MEMO(), "SP_FF_GET_MEMO", 9, resultOutCurSor, MemoNo_OP);
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
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter Retailer_OP = new OracleParameter();
                Retailer_OP.Direction = System.Data.ParameterDirection.Input;
                Retailer_OP.OracleDbType = OracleDbType.Decimal;
                Retailer_OP.Value = RetailerId;

                OracleParameter FromDate_OP = new OracleParameter();
                FromDate_OP.Direction = System.Data.ParameterDirection.Input;
                FromDate_OP.OracleDbType = OracleDbType.Date;
                FromDate_OP.Value = FromDate;

                OracleParameter ToDate_OP = new OracleParameter();
                ToDate_OP.Direction = System.Data.ParameterDirection.Input;
                ToDate_OP.OracleDbType = OracleDbType.Date;
                ToDate_OP.Value = ToDate;

                OracleParameter MemoId_OP = new OracleParameter();
                MemoId_OP.Direction = System.Data.ParameterDirection.Input;
                MemoId_OP.OracleDbType = OracleDbType.Varchar2;
                MemoId_OP.Value = MemoId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SALES_MEMO>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SALES_MEMO>.GetDataBySP(new SP_GET_SALES_MEMO(), "SP_FF_GET_SALES_MEMO", 10, resultOutCurSor, UserId_OP, Retailer_OP, FromDate_OP, ToDate_OP, MemoId_OP);
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
                OracleParameter MemoId_OP = new OracleParameter();
                MemoId_OP.Direction = System.Data.ParameterDirection.Input;
                MemoId_OP.OracleDbType = OracleDbType.Decimal;
                MemoId_OP.Value = MemoId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_MEMO>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_MEMO>.GetDataBySP(new SP_GET_MEMO(), "SP_FF_GET_MEMO_BY_ID", 9, resultOutCurSor, MemoId_OP);
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
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter Retailer_OP = new OracleParameter();
                Retailer_OP.Direction = System.Data.ParameterDirection.Input;
                Retailer_OP.OracleDbType = OracleDbType.Decimal;
                Retailer_OP.Value = RetailerId;

                OracleParameter FromDate_OP = new OracleParameter();
                FromDate_OP.Direction = System.Data.ParameterDirection.Input;
                FromDate_OP.OracleDbType = OracleDbType.Date;
                FromDate_OP.Value = FromDate;

                OracleParameter ToDate_OP = new OracleParameter();
                ToDate_OP.Direction = System.Data.ParameterDirection.Input;
                ToDate_OP.OracleDbType = OracleDbType.Date;
                ToDate_OP.Value = ToDate;

                OracleParameter MemoId_OP = new OracleParameter();
                MemoId_OP.Direction = System.Data.ParameterDirection.Input;
                MemoId_OP.OracleDbType = OracleDbType.Decimal;
                MemoId_OP.Value = ReturnId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_FF_GET_RETURN_MEMO>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_RETURN_MEMO>.GetDataBySP(new SP_FF_GET_RETURN_MEMO(), "SP_FF_GET_RETURN_MEMO", 10, resultOutCurSor, UserId_OP, Retailer_OP, FromDate_OP, ToDate_OP, MemoId_OP);
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
                OracleParameter MemoProductSerialId_OP = new OracleParameter();
                MemoProductSerialId_OP.Direction = System.Data.ParameterDirection.Input;
                MemoProductSerialId_OP.OracleDbType = OracleDbType.Decimal;
                MemoProductSerialId_OP.Value = MemoProductSerialId;

                OracleParameter MemoProductId_OP = new OracleParameter();
                MemoProductId_OP.Direction = System.Data.ParameterDirection.Input;
                MemoProductId_OP.OracleDbType = OracleDbType.Decimal;
                MemoProductId_OP.Value = MemoProductId;

                OracleParameter ProductId_OP = new OracleParameter();
                ProductId_OP.Direction = System.Data.ParameterDirection.Input;
                ProductId_OP.OracleDbType = OracleDbType.Decimal;
                ProductId_OP.Value = ProductId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_DELIVERED_MEMO_SERIAL>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_DELIVERED_MEMO_SERIAL>.GetDataBySP(new SP_GET_DELIVERED_MEMO_SERIAL(), "SP_FF_GET_DELIV_MEMO_PRODUCT", 6, resultOutCurSor, MemoProductSerialId_OP, MemoProductId_OP, ProductId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
