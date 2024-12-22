using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{   
    public class EndCallInfoPZ
    {
         public const string _collectionNodePart = "Coll";

         public EndCallInfoPZ() { }

        /// <summary>
        /// Get End call information by by search parameter.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="rsoID"></param>
        /// <param name="retailerID"></param>
        /// <param name="endCallNote"></param>
        /// <param name="callStatus"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="currentPage"></param>
        /// <returns></returns>
         public List<ENDCALL_INFOcls> GetAllEndCallInfo(decimal distributorID, decimal rsoID, decimal retailerID, string endCallNote, decimal callStatus, DateTime fromDate, DateTime toDate, decimal currentPage)
         {
             try
             {
                 //CallFail =0, CallSuccess =1 need implement enum
                 return new EndCallInfoDZ().GetAllEndCallInfo(distributorID, rsoID, retailerID, endCallNote, callStatus, fromDate, toDate, currentPage);
             }
             catch(Exception ex)
             {
                 throw ex;
             }
         }

        /// <summary>
         /// Receive transaction status , is it fail or success.
        /// </summary>
        /// <param name="dateTimeCall"></param>
        /// <param name="distributorID"></param>
        /// <param name="callNote"></param>
        /// <param name="rsoID"></param>
        /// <param name="retailerID"></param>
        /// <returns></returns>
         public ServiceStringXML SaveOrUpdate(DateTime dateTimeCall, decimal distributorID, string callNote, decimal rsoID, decimal retailerID)
         {            
             ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
             String objectXML = string.Empty;
             string objectItemName = new ENDCALL_INFOcls().GetType().Name;

             try
             {
                 DateTime updateDate = DateTime.Now;
                 decimal  updateBy = rsoID;
                 decimal endCallInfoID = 0;
                 decimal callFail = 0;
                 Decimal outEndCallInfoID = new EndCallInfoDZ().SaveOrUpdate(dateTimeCall, distributorID, updateBy, updateDate, endCallInfoID, callNote, rsoID, retailerID, callFail);
                 if (outEndCallInfoID != 0)
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
