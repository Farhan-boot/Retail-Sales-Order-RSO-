using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.ShelterZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class RSORoutePZ
    {       
        public RSORoutePZ()
        {

        }
        public const string _collectionNodePart = "Coll";

        /// <summary>
        ///  Get Valide RSO from RSO and RSO_APP_PASSWORD table.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="pass"></param>
        /// <returns>List of related object</returns>
        public List<SP_RSO_BY_CODE_PASScls> GetROSByCodeAndPass(string code, string pass)
        {
            try
            {
                return new RSORouteDZ().GetROSByCodeAndPass(code, pass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Valide RSO from RSO and RSO_APP_PASSWORD table.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="pass"></param>
        /// <returns>Single RSO info object for Web Service compatible XML soap data format</returns>
        public ServiceStringXML GetROSByCodeAndPassXML(string code, string pass)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new SP_RSO_BY_CODE_PASScls().GetType().Name;
            try
            {
                List<SP_RSO_BY_CODE_PASScls> rosColl = new RSORouteDZ().GetROSByCodeAndPass(code, pass);
                if (rosColl != null && rosColl.Count == 1)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<SP_RSO_BY_CODE_PASScls>(rosColl[0]);
                }
                else if (rosColl == null || rosColl.Count == 0)
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.InvalideRSOCode);
                }
                else if (rosColl.Count > 1)
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DuplicateRSOCode);
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
        /// Get all Retailer visiting schedule(OUTLETSCHEDULE) for particular route by RSO visit.
        /// </summary>
        /// <param name="rsoID"></param>
        /// <param name="assignDate"></param>
        /// <param name="distributorID"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_RSO_WISE_ROT_A_RETcls> GetROS_WiseRouteAndRetailer(decimal rsoID, DateTime assignDate, decimal distributorID)
        {
            try
            {
                return new RSORouteDZ().GetROS_WiseRouteAndRetailer(rsoID, assignDate, distributorID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all RSO schedule with visiting particular Route from RSOSCHEDULE table.
        /// </summary>
        /// <param name="rsoID"></param>
        /// <param name="assignDate"></param>
        /// <param name="distributorID"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_RSO_ROT_SCHDLcls> GetROS_RouteWiseSchedule(decimal rsoID, DateTime assignDate, decimal distributorID)
        {
            try
            {                
                return new RSORouteDZ().GetROS_RouteWiseSchedule(rsoID, assignDate, distributorID);;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //RetailerStatus

        /// <summary>
        /// Get all Retailer visiting schedule(OUTLETSCHEDULE) for particular route by RSO visit.
        /// </summary>
        /// <param name="rsoID"></param>
        /// <param name="assignDate"></param>
        /// <param name="distributorID"></param>
        /// <returns>List of related object for Web Service compatible XML soap data format</returns>
        public ServiceStringXML GetROS_WiseRouteAndRetailerXML(decimal rsoID, DateTime assignDate, decimal distributorID)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            string objectXML = string.Empty;
            string objectItemName = new SP_GET_RSO_WISE_ROT_A_RETcls().GetType().Name + _collectionNodePart;
            try
            {                
                List<SP_GET_RSO_WISE_ROT_A_RETcls> rosColl = new RSORouteDZ().GetROS_WiseRouteAndRetailer(rsoID, assignDate, distributorID);
                if (rosColl != null && rosColl.Count > 0)
                {
                    foreach (SP_GET_RSO_WISE_ROT_A_RETcls item in rosColl)
                    {
                        item.RETAILER_NAME = item.RETAILER_NAME.Replace("&", "and");
                       item.ROUTE_NAME = item.ROUTE_NAME.Replace("&", "and");
                    }
                    objectXML = ConversionXML.ConvertObjectToXML<SP_GET_RSO_WISE_ROT_A_RETcls>(rosColl, _collectionNodePart);
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
        /// Get all RSO schedule with visiting particular Route from RSOSCHEDULE table.
        /// </summary>
        /// <param name="rsoID"></param>
        /// <param name="assignDate"></param>
        /// <param name="distributorID"></param>
        /// <returns>List of related object for Web Service compatible XML soap data format</returns>
        public ServiceStringXML GetROS_RouteWiseScheduleXML(decimal rsoID, DateTime assignDate, decimal distributorID)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            string objectXML = string.Empty;
            string objectItemName = new SP_GET_RSO_ROT_SCHDLcls().GetType().Name + _collectionNodePart;
            try
            {
                List<SP_GET_RSO_ROT_SCHDLcls> rosColl = new RSORouteDZ().GetROS_RouteWiseSchedule(rsoID, assignDate, distributorID);
                if (rosColl != null && rosColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<SP_GET_RSO_ROT_SCHDLcls>(rosColl, _collectionNodePart);
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
    }
}
