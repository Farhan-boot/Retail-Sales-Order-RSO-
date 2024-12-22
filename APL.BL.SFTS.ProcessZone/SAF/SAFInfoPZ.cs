using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.ShelterZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class SAFInfoPZ
    {
        public SAFInfoPZ() { }

        public const string _collectionNodePart = "Coll";

        /// <summary>
        /// Save or update SAF Info with checking duplicate SIM no.
        /// </summary>
        /// <param name="safID"></param>
        /// <param name="receiveDate"></param>
        /// <param name="simNO"></param>
        /// <param name="fromNO"></param>
        /// <param name="retailerID"></param>
        /// <param name="rsoID"></param>
        /// <param name="updateDate"></param>
        /// <param name="updateBy"></param>
        /// <returns>SAF Info ID for Web Service compatible XML soap data format</returns>
        public ServiceStringXML SaveSAFInfo(decimal safID, DateTime receiveDate, String simNO, String fromNO, decimal retailerID, decimal rsoID, DateTime updateDate, String updateBy)
        {            
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new SP_GET_INS_UPD_SAF_INFOcls().GetType().Name;
            try
            {
                //needed to test duplicate sim no 
                List<SP_GET_INS_UPD_SAF_INFOcls> safInfoColl = new SAFInfoDZ().GetSAFInfoSingle(simNO, retailerID, rsoID);
               if (safInfoColl == null || safInfoColl.Count == 0)
               {
                   Decimal SAFInfoID = new SAFInfoDZ().SaveSAFInfo(safID, receiveDate, simNO, fromNO, retailerID, rsoID, updateDate, updateBy);

                   if (SAFInfoID != 0)
                   {
                       objectXML = MessageReplyXML.Confirmation(objectItemName, true, MessageGodown.SaveNotification);
                   }
                   else
                   {
                       objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.FailSaveNotification);
                   }
               }
               else
               {
                   objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DuplicateSimNo);
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
        /// Get pending SAF Info of Retailer.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="rsoID"></param>
        /// <param name="retailerID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns>SAF Info for Web Service compatible XML soap data format</returns>
        public ServiceStringXML PendingSAFInfo(decimal distributorID, decimal rsoID, decimal retailerID, DateTime fromDate, DateTime toDate)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            SAF_INFO_PENDING pendingSAF = new SAF_INFO_PENDING();
            string objectItemName = pendingSAF.GetType().Name;
            try
            {
                List<SP_GET_INS_UPD_SAF_INFOcls> allSaf = new SAFInfoDZ().GetAllSAFInfo(fromDate, toDate, string.Empty, retailerID, rsoID);
                List<SP_GET_RETAILER_TAR_ACHIEVEcls> retailerColl = new RetailerDZ().GetRetailerTargetAndAchivement(retailerID, distributorID, (int)ProductCategoryEnum.SIM, fromDate.ToString(), toDate.ToString());

                pendingSAF.RETAILER_ID = retailerID;
                pendingSAF.RSO_ID = rsoID;
                pendingSAF.FROM_DATE = fromDate;
                pendingSAF.TO_DATE = toDate;

                if (allSaf != null)
                {
                    pendingSAF.TOTAL_SAF_SUBMIT = allSaf.Count;
                }
                else
                {
                    pendingSAF.TOTAL_SAF_SUBMIT = 0;
                }

                if(retailerColl!=null && retailerColl.Count>0)
                {
                    foreach(var item in retailerColl)
                    {
                        pendingSAF.TOTAL_SIM_SOLD += item.ACHIVEMENT_AMOUNT;
                    }
                }
                else
                {
                    pendingSAF.TOTAL_SIM_SOLD = 0;
                }
                pendingSAF.TOTAL_SIM_PENDING = pendingSAF.TOTAL_SIM_SOLD - pendingSAF.TOTAL_SAF_SUBMIT;

                objectXML = ConversionXML.ConvertObjectToXML<SAF_INFO_PENDING>(pendingSAF);
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
