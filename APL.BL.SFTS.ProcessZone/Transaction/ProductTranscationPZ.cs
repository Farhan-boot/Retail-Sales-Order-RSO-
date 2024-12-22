using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.ShelterZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class ProductTranscationPZ
    {
        public const string _collectionNodePart = "Coll";

        public ProductTranscationPZ(){}

        /// <summary>
        /// This method is used for checking each product detail information. Product information vaild or invaild and return xml format soap data.
        /// </summary>
        /// <param name="tranProductStr"></param>
        /// <returns></returns>
        public ServiceStringXML CheckTransactionProductStringFormat(String tranProductStr)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new SP_SC_TRAN_OPERATIONcls().GetType().Name;

            try
            {
                String processMsg = new ProductTranscationDZ().CheckTransactionProductStringFormat(tranProductStr);
                if (processMsg.Trim() != string.Empty)
                {
                    if (processMsg.Trim().ToLower().Contains("true")==true)
                    {
                       
                        objectXML = MessageReplyXML.Confirmation(objectItemName, true, processMsg);
                    }
                    else
                    {
                        objectXML = MessageReplyXML.Confirmation(objectItemName, false, processMsg);
                    }
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.FailTranCheckNotification);
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
        /// This method is used for receiving all product information for transaction.
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="senderNo"></param>
        /// <param name="receiverNo"></param>
        /// <param name="tranProductList"></param>
        /// <returns></returns>
        public ServiceStringXML SaveAllTransactionStringFormatXML(Decimal requestId, Decimal senderNo, Decimal receiverNo, String tranProductList)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new SP_SC_TRAN_OPERATIONcls().GetType().Name;

            try
            {
                String processMsg = new ProductTranscationDZ().SaveAllTransactionStringFormat(requestId, senderNo, receiverNo, tranProductList);
                if (processMsg.Trim() != string.Empty)
                {
                    if (processMsg.Trim().Contains("Fail") == true || processMsg.Trim().Contains("FAIL") == true)
                    {
                        requestId = 0;
                        objectXML = MessageReplyXML.Confirmation(objectItemName, requestId, processMsg);
                    }
                    else
                    {
                        objectXML = MessageReplyXML.Confirmation(objectItemName, requestId, processMsg);
                    }
                }
                else
                {
                    requestId = 0;
                    objectXML = MessageReplyXML.Confirmation(objectItemName, requestId, MessageGodown.FailTranNotification);
                }
            }
            catch (Exception ex)
            {
                requestId = 0;
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, requestId, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        //public ServiceStringXML SaveScTransctionXML(Decimal scTransactionID, Decimal tranEntry, DateTime tranDate, Decimal distributorID, Decimal retailerID,
        //    char tranPosted, String tranSerialNo, Decimal tranVerifiedBy, String tranStartScNo, String tranEndScNo, Decimal tranProductID, Decimal tranQty,
        //    Decimal tranInventory, Decimal unitPrice)
        //{
        //    ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
        //    String objectXML = string.Empty;
        //    string objectItemName = new SP_SC_TRAN_OPERATIONcls().GetType().Name;

        //    try
        //    {
        //        Decimal scTransctionID = new ProductTranscationDZ().SaveScTransction(scTransactionID, tranEntry, tranDate, distributorID, retailerID,
        //     tranPosted, tranSerialNo, tranVerifiedBy, tranStartScNo, tranEndScNo, tranProductID, tranQty, tranInventory, unitPrice);
        //        if (scTransctionID != 0)
        //        {
        //            objectXML = MessageReplyXML.Confirmation(objectItemName, true, MessageGodown.TranNotification);
        //        }
        //        else
        //        {
        //            objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.FailTranNotification);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        serviceStrXmlObj.IssueArisePlace = this.ToString();
        //        serviceStrXmlObj.OperationMessage = ex.Message;
        //        serviceStrXmlObj.StackTrace = ex.StackTrace;
        //        objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
        //    }
        //    finally
        //    {
        //        serviceStrXmlObj.ObjectXML = objectXML;
        //    }
        //    return serviceStrXmlObj;       
        //}

        //public ServiceStringXML SaveSimTransctionXML(Decimal simTransactionID, Decimal entry, DateTime tranDate, Decimal distributorID, Decimal retailerID,
        //    char tranPosted, String tranSerialNo, Decimal tranEnteredBy, Decimal simTransaction, String tranStartSimNo, String tranEndSimNo,
        //    Decimal tranProductID, Decimal tranQty, DateTime issueDate, Decimal tranInventory, Decimal unitPrice)
        //{
        //    ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
        //    String objectXML = string.Empty;
        //    string objectItemName = new SP_SIM_TRAN_OPERATIONcls().GetType().Name;

        //    try
        //    {
        //        Decimal simTransctionID = new ProductTranscationDZ().SaveSimTransction(simTransactionID, entry, tranDate, distributorID, retailerID,
        //     tranPosted, tranSerialNo, tranEnteredBy, simTransaction, tranStartSimNo, tranEndSimNo, tranProductID, tranQty, issueDate, tranInventory, unitPrice);
        //        if (simTransctionID != 0)
        //        {
        //            objectXML = MessageReplyXML.Confirmation(objectItemName, true, MessageGodown.TranNotification);
        //        }
        //        else
        //        {
        //            objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.FailTranNotification);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        serviceStrXmlObj.IssueArisePlace = this.ToString();
        //        serviceStrXmlObj.OperationMessage = ex.Message;
        //        serviceStrXmlObj.StackTrace = ex.StackTrace;
        //       // objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
        //        objectXML = MessageReplyXML.Confirmation(objectItemName, false, ex.Message);
        //    }
        //    finally
        //    {
        //        serviceStrXmlObj.ObjectXML = objectXML;
        //    }
        //    return serviceStrXmlObj;
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
        public ServiceStringXML SaveReturnSIMXML(String productCode, String parseFile, Decimal cCode, DateTime exitDate, String serial, DateTime loadDate)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();

            String objectXML = string.Empty;
            string objectItemName = new SP_INS_RETURNEDSIMcls().GetType().Name;

            try
            {               
                Decimal rowCount = new ProductTranscationDZ().SaveReturnSIM(productCode, parseFile, cCode, exitDate, serial, loadDate);

                if (rowCount != 0)
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, true, MessageGodown.SaveNotification);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.FailSaveNotification);
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
    }
}
