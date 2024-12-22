using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class ProductTranscationDZ
    {
        //public List<SP_SC_TRAN_OPERATIONcls> GetAllScTransction(Decimal distributorID, Decimal retailerID)
        //{
        //    try
        //    {
        //        OracleParameter distributorID_OP = new OracleParameter();
        //        distributorID_OP.Direction = System.Data.ParameterDirection.Input;
        //        distributorID_OP.OracleDbType = OracleDbType.Decimal;
        //        distributorID_OP.Value = distributorID;

        //        OracleParameter retailerID_OP = new OracleParameter();
        //        retailerID_OP.Direction = System.Data.ParameterDirection.Input;
        //        retailerID_OP.OracleDbType = OracleDbType.Decimal;
        //        retailerID_OP.Value = retailerID;

        //        OracleParameter resultOutCurSor = new OracleParameter();
        //        resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
        //        resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

        //        return (List<SP_SC_TRAN_OPERATIONcls>)ObjectMakerFromOracleSP.OracleHelper<SP_SC_TRAN_OPERATIONcls>.GetDataBySP(new SP_SC_TRAN_OPERATIONcls(), "SP_SC_TRAN_OPERATION", 12, resultOutCurSor, distributorID_OP, retailerID_OP);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// This method is used for checking each product detail information. Product information vaild or invaild.
        /// </summary>
        /// <param name="tranProductStr"></param>
        /// <returns></returns>
        public String CheckTransactionProductStringFormat(String tranProductStr)
        {
            try
            {
                OracleParameter tranProductStrOP = new OracleParameter();
                tranProductStrOP.Direction = System.Data.ParameterDirection.Input;
                tranProductStrOP.OracleDbType = OracleDbType.Varchar2;
                tranProductStrOP.Value = tranProductStr;
                tranProductStrOP.Size = 600;

                OracleParameter procssMsgReturnOP = new OracleParameter();
                procssMsgReturnOP.Direction = System.Data.ParameterDirection.ReturnValue;
                procssMsgReturnOP.OracleDbType = OracleDbType.Varchar2;
                procssMsgReturnOP.Size = 600;

                return ObjectMakerFromOracleSP.OracleHelper<SP_SC_TRAN_OPERATIONcls>.InsertDataByFun("FN_APP_TRAN_CHKECK_ONLY", procssMsgReturnOP, tranProductStrOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This method is used for receiving all product information for transaction.
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="senderNo"></param>
        /// <param name="receiverNo"></param>
        /// <param name="tranProductList"></param>
        /// <returns></returns>
        public String SaveAllTransactionStringFormat(Decimal requestId, Decimal senderNo, Decimal receiverNo, String tranProductList)
        {
            try
            {
                OracleParameter requestIdOP = new OracleParameter();
                requestIdOP.Direction = System.Data.ParameterDirection.Input;
                requestIdOP.OracleDbType = OracleDbType.Decimal;
                requestIdOP.Value = requestId;

                OracleParameter senderNoOP = new OracleParameter();
                senderNoOP.Direction = System.Data.ParameterDirection.Input;
                senderNoOP.OracleDbType = OracleDbType.Decimal;
                senderNoOP.Value = senderNo;

                OracleParameter receiverNoOP = new OracleParameter();
                receiverNoOP.Direction = System.Data.ParameterDirection.Input;
                receiverNoOP.OracleDbType = OracleDbType.Decimal;
                receiverNoOP.Value = receiverNo;

                OracleParameter tranProductListOP = new OracleParameter();
                tranProductListOP.Direction = System.Data.ParameterDirection.Input;
                tranProductListOP.OracleDbType = OracleDbType.Varchar2;
                tranProductListOP.Value = tranProductList;
                tranProductListOP.Size = 600;

                OracleParameter procssMsgReturnOP = new OracleParameter();
                procssMsgReturnOP.Direction = System.Data.ParameterDirection.Output;
                procssMsgReturnOP.OracleDbType = OracleDbType.Varchar2;
                procssMsgReturnOP.Size = 900;

                //OracleParameter tranAllIdList_Out_OP = new OracleParameter();
                //tranAllIdList_Out_OP.Direction = System.Data.ParameterDirection.Output;
                //tranAllIdList_Out_OP.OracleDbType = OracleDbType.Varchar2;


                return ObjectMakerFromOracleSP.OracleHelper<SP_SC_TRAN_OPERATIONcls>.InsertDataBySPstr("SP_APP_TRANSACTION", procssMsgReturnOP, requestIdOP, senderNoOP, receiverNoOP, tranProductListOP);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        //public Decimal SaveScTransction(Decimal scTransactionID, Decimal tranEntry, DateTime tranDate, Decimal distributorID, Decimal retailerID,
        //    char tranPosted, String tranSerialNo, Decimal tranVerifiedBy, String tranStartScNo, String tranEndScNo, Decimal tranProductID, Decimal tranQty,
        //    Decimal tranInventory, Decimal unitPrice)
        //{
        //    try
        //    {
        //        OracleParameter scTransactionID_OP = new OracleParameter();
        //        scTransactionID_OP.Direction = System.Data.ParameterDirection.Input;
        //        scTransactionID_OP.OracleDbType = OracleDbType.Decimal;
        //        scTransactionID_OP.Value = scTransactionID;

        //        OracleParameter tranEntryOP = new OracleParameter();
        //        tranEntryOP.Direction = System.Data.ParameterDirection.Input;
        //        tranEntryOP.OracleDbType = OracleDbType.Decimal;
        //        tranEntryOP.Value = tranEntry;

        //        OracleParameter tranDateOP = new OracleParameter();
        //        tranDateOP.Direction = System.Data.ParameterDirection.Input;
        //        tranDateOP.OracleDbType = OracleDbType.Date;
        //        tranDateOP.Value = tranDate;

        //        OracleParameter distributorID_OP = new OracleParameter();
        //        distributorID_OP.Direction = System.Data.ParameterDirection.Input;
        //        distributorID_OP.OracleDbType = OracleDbType.Decimal;
        //        distributorID_OP.Value = distributorID;

        //        OracleParameter retailerID_OP = new OracleParameter();
        //        retailerID_OP.Direction = System.Data.ParameterDirection.Input;
        //        retailerID_OP.OracleDbType = OracleDbType.Decimal;
        //        retailerID_OP.Value = retailerID;

        //        OracleParameter tranPostedOP = new OracleParameter();
        //        tranPostedOP.Direction = System.Data.ParameterDirection.Input;
        //        tranPostedOP.OracleDbType = OracleDbType.Char;
        //        tranPostedOP.Value = tranPosted;

        //        OracleParameter tranSerialNoOP = new OracleParameter();
        //        tranSerialNoOP.Direction = System.Data.ParameterDirection.Input;
        //        tranSerialNoOP.OracleDbType = OracleDbType.Varchar2;
        //        tranSerialNoOP.Value = tranSerialNo;

        //        OracleParameter tranVerifiedByOP = new OracleParameter();
        //        tranVerifiedByOP.Direction = System.Data.ParameterDirection.Input;
        //        tranVerifiedByOP.OracleDbType = OracleDbType.Decimal;
        //        tranVerifiedByOP.Value = tranVerifiedBy;

        //        OracleParameter tranStartScNoOP = new OracleParameter();
        //        tranStartScNoOP.Direction = System.Data.ParameterDirection.Input;
        //        tranStartScNoOP.OracleDbType = OracleDbType.Varchar2;
        //        tranStartScNoOP.Value = tranStartScNo;

        //        OracleParameter tranEndScNoOP = new OracleParameter();
        //        tranEndScNoOP.Direction = System.Data.ParameterDirection.Input;
        //        tranEndScNoOP.OracleDbType = OracleDbType.Varchar2;
        //        tranEndScNoOP.Value = tranEndScNo;

        //        OracleParameter tranProductID_OP = new OracleParameter();
        //        tranProductID_OP.Direction = System.Data.ParameterDirection.Input;
        //        tranProductID_OP.OracleDbType = OracleDbType.Decimal;
        //        tranProductID_OP.Value = tranProductID;

        //        OracleParameter tranQtyOP = new OracleParameter();
        //        tranQtyOP.Direction = System.Data.ParameterDirection.Input;
        //        tranQtyOP.OracleDbType = OracleDbType.Decimal;
        //        tranQtyOP.Value = tranQty;

        //        OracleParameter tranInventoryOP = new OracleParameter();
        //        tranInventoryOP.Direction = System.Data.ParameterDirection.Input;
        //        tranInventoryOP.OracleDbType = OracleDbType.Decimal;
        //        tranInventoryOP.Value = tranInventory; 

        //        OracleParameter unitPriceOP = new OracleParameter();
        //        unitPriceOP.Direction = System.Data.ParameterDirection.Input;
        //        unitPriceOP.OracleDbType = OracleDbType.Decimal;
        //        unitPriceOP.Value = unitPrice;

        //        return ObjectMakerFromOracleSP.OracleHelper<SP_SC_TRAN_OPERATIONcls>.InsertDataBySP("SP_SC_TRAN_OPERATION", scTransactionID_OP, tranEntryOP, tranDateOP, distributorID_OP, retailerID_OP,
        //        tranPostedOP, tranSerialNoOP, tranVerifiedByOP, tranStartScNoOP, tranEndScNoOP, tranProductID_OP, tranQtyOP, tranInventoryOP, unitPriceOP);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        
        //public Decimal SaveSimTransction(Decimal simTransactionID, Decimal entry, DateTime tranDate, Decimal distributorID, Decimal retailerID,
        //    char tranPosted, String tranSerialNo, Decimal tranEnteredBy, Decimal simTransaction, String tranStartSimNo, String tranEndSimNo,
        //    Decimal tranProductID, Decimal tranQty, DateTime issueDate, Decimal tranInventory, Decimal unitPrice)
        //{
        //    try
        //    {
        //        OracleParameter simTransactionID_OP = new OracleParameter();
        //        simTransactionID_OP.Direction = System.Data.ParameterDirection.Input;
        //        simTransactionID_OP.OracleDbType = OracleDbType.Decimal;
        //        simTransactionID_OP.Value = simTransactionID;

        //        OracleParameter entry_OP = new OracleParameter();
        //        entry_OP.Direction = System.Data.ParameterDirection.Input;
        //        entry_OP.OracleDbType = OracleDbType.Decimal;
        //        entry_OP.Value = entry;

        //        OracleParameter tranDateOP = new OracleParameter();
        //        tranDateOP.Direction = System.Data.ParameterDirection.Input;
        //        tranDateOP.OracleDbType = OracleDbType.Date;
        //        tranDateOP.Value = tranDate;

        //        OracleParameter distributorID_OP = new OracleParameter();
        //        distributorID_OP.Direction = System.Data.ParameterDirection.Input;
        //        distributorID_OP.OracleDbType = OracleDbType.Decimal;
        //        distributorID_OP.Value = distributorID;

        //        OracleParameter retailerID_OP = new OracleParameter();
        //        retailerID_OP.Direction = System.Data.ParameterDirection.Input;
        //        retailerID_OP.OracleDbType = OracleDbType.Decimal;
        //        retailerID_OP.Value = retailerID;

        //        OracleParameter tranPostedOP = new OracleParameter();
        //        tranPostedOP.Direction = System.Data.ParameterDirection.Input;
        //        tranPostedOP.OracleDbType = OracleDbType.Char;
        //        tranPostedOP.Value = tranPosted;

        //        OracleParameter tranSerialNoOP = new OracleParameter();
        //        tranSerialNoOP.Direction = System.Data.ParameterDirection.Input;
        //        tranSerialNoOP.OracleDbType = OracleDbType.Varchar2;
        //        tranSerialNoOP.Value = tranSerialNo;

        //        OracleParameter tranEnteredBy_OP = new OracleParameter();
        //        tranEnteredBy_OP.Direction = System.Data.ParameterDirection.Input;
        //        tranEnteredBy_OP.OracleDbType = OracleDbType.Decimal;
        //        tranEnteredBy_OP.Value = tranEnteredBy;

        //        OracleParameter simTransaction_OP = new OracleParameter();
        //        simTransaction_OP.Direction = System.Data.ParameterDirection.Input;
        //        simTransaction_OP.OracleDbType = OracleDbType.Decimal;
        //        simTransaction_OP.Value = simTransaction;

        //        OracleParameter tranStartSimNo_OP = new OracleParameter();
        //        tranStartSimNo_OP.Direction = System.Data.ParameterDirection.Input;
        //        tranStartSimNo_OP.OracleDbType = OracleDbType.Varchar2;
        //        tranStartSimNo_OP.Value = tranStartSimNo;

        //        OracleParameter tranEndSimNo_OP = new OracleParameter();
        //        tranEndSimNo_OP.Direction = System.Data.ParameterDirection.Input;
        //        tranEndSimNo_OP.OracleDbType = OracleDbType.Varchar2;
        //        tranEndSimNo_OP.Value = tranEndSimNo;

        //        OracleParameter tranProductID_OP = new OracleParameter();
        //        tranProductID_OP.Direction = System.Data.ParameterDirection.Input;
        //        tranProductID_OP.OracleDbType = OracleDbType.Decimal;
        //        tranProductID_OP.Value = tranProductID;

        //        OracleParameter tranQtyOP = new OracleParameter();
        //        tranQtyOP.Direction = System.Data.ParameterDirection.Input;
        //        tranQtyOP.OracleDbType = OracleDbType.Decimal;
        //        tranQtyOP.Value = tranQty;

        //        OracleParameter issueDate_OP = new OracleParameter();
        //        issueDate_OP.Direction = System.Data.ParameterDirection.Input;
        //        issueDate_OP.OracleDbType = OracleDbType.Date;
        //        issueDate_OP.Value = issueDate;

        //        OracleParameter tranInventoryOP = new OracleParameter();
        //        tranInventoryOP.Direction = System.Data.ParameterDirection.Input;
        //        tranInventoryOP.OracleDbType = OracleDbType.Decimal;
        //        tranInventoryOP.Value = tranInventory;

        //        OracleParameter unitPriceOP = new OracleParameter();
        //        unitPriceOP.Direction = System.Data.ParameterDirection.Input;
        //        unitPriceOP.OracleDbType = OracleDbType.Decimal;
        //        unitPriceOP.Value = unitPrice;

        //        return ObjectMakerFromOracleSP.OracleHelper<SP_SC_TRAN_OPERATIONcls>.InsertDataBySP("SP_SIM_TRAN_OPERATION", simTransactionID_OP, entry_OP, tranDateOP, distributorID_OP, retailerID_OP,
        //        tranPostedOP, tranSerialNoOP, tranEnteredBy_OP, simTransaction_OP, tranStartSimNo_OP, tranEndSimNo_OP,
        //        tranProductID_OP, tranQtyOP, issueDate_OP, tranInventoryOP, unitPriceOP);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// This method is used for SIM return operation.
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="parseFile"></param>
        /// <param name="cCode"></param>
        /// <param name="exitDate"></param>
        /// <param name="serial"></param>
        /// <param name="loadDate"></param>
        /// <returns></returns>
        public Decimal SaveReturnSIM(String productCode, String parseFile, Decimal cCode, DateTime exitDate, String serial, DateTime loadDate)
        {
            try
            {
                OracleParameter productCodeOP = new OracleParameter();
                productCodeOP.Direction = System.Data.ParameterDirection.Input;
                productCodeOP.OracleDbType = OracleDbType.Varchar2;
                productCodeOP.Value = productCode;

                OracleParameter parseFileOP = new OracleParameter();
                parseFileOP.Direction = System.Data.ParameterDirection.Input;
                parseFileOP.OracleDbType = OracleDbType.Varchar2;
                parseFileOP.Value = parseFile;

                OracleParameter cCodeOP = new OracleParameter();
                cCodeOP.Direction = System.Data.ParameterDirection.Input;
                cCodeOP.OracleDbType = OracleDbType.Decimal;
                cCodeOP.Value = cCode;

                OracleParameter exitDateOP = new OracleParameter();
                exitDateOP.Direction = System.Data.ParameterDirection.Input;
                exitDateOP.OracleDbType = OracleDbType.Date;
                exitDateOP.Value = exitDate;

                OracleParameter serialOP = new OracleParameter();
                serialOP.Direction = System.Data.ParameterDirection.Input;
                serialOP.OracleDbType = OracleDbType.Varchar2;
                serialOP.Value = serial;

                OracleParameter loadDateOP = new OracleParameter();
                loadDateOP.Direction = System.Data.ParameterDirection.Input;
                loadDateOP.OracleDbType = OracleDbType.Date;
                loadDateOP.Value = loadDate;

                OracleParameter outRowCountOP = new OracleParameter();
                outRowCountOP.Direction = System.Data.ParameterDirection.Output;
                outRowCountOP.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_SC_TRAN_OPERATIONcls>.InsertDataBySP("SP_INS_RETURNEDSIM", outRowCountOP, productCodeOP, parseFileOP, cCodeOP, exitDateOP, serialOP, loadDateOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
