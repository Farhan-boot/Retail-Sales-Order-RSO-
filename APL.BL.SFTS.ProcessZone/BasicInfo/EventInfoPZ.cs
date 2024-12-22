using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.ShelterZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class EventInfoPZ
    {
        public EventInfoPZ() { }

        public const string _collectionNodePart = "Coll";

        #region Get Methods

        /// <summary>
        /// This methods is calling to provide all event or particular evnet info.
        /// </summary>
        /// <param name="searchEventName"> default value is empty string for all evnet info</param>
        /// <returns>List of event object</returns>
        public List<EVENT_INFOcls> GetAllEventInfo(string searchEventName)
        {
            try
            {
                return new EventInfoDZ().GetAllEventInfo(searchEventName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This methods is calling to provide one week name and date. Starting from current server date.  
        /// </summary>
        /// <returns>Web service compatible XML soap data format </returns>
        public ServiceStringXML GetWeekAllDays()
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new WeekInfo().GetType().Name;
            try
            {
                List<WeekInfo> oneWeek = new List<WeekInfo>();
                DateTime todayDate = DateTime.Now;
				int indexCounter = 0;
				for (indexCounter = 0; indexCounter < 7; indexCounter++)
                {
                    WeekInfo weekInfo = new WeekInfo();
                    weekInfo.DayName = todayDate.AddDays(indexCounter).DayOfWeek.ToString();
                    weekInfo.DayValue = indexCounter.ToString();
                    weekInfo.DayDate = todayDate.AddDays(indexCounter).ToString("dd-MMM-yyyy");
                    oneWeek.Add(weekInfo);
                }
                objectXML = ConversionXML.ConvertObjectToXML<WeekInfo>(oneWeek, _collectionNodePart);
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
        /// This methods is calling to provide all event.  
        /// </summary>
        /// <returns>Web service compatible XML soap data format </returns>
        public ServiceStringXML GetAllEventInfoXML()
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new EVENT_INFOcls().GetType().Name;
            try
            {
                List<EVENT_INFOcls> eventAllColl = new EventInfoDZ().GetAllEventInfo(string.Empty);
                List<EVENT_INFOcls> eventActiveColl = new List<EVENT_INFOcls>();

                foreach (var item in eventAllColl)
                {
                    if (item.IS_ACTIVE == (int) EnumCollection.ActiveInactiveEnum.Active)
                    {
                        eventActiveColl.Add(item);
                    }
                }

                if (eventActiveColl != null && eventActiveColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<EVENT_INFOcls>(eventActiveColl, _collectionNodePart);
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

        #endregion Get Methods

        #region Save Methods

        /// <summary>
        /// This methods is calling to save or update event info.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="note"></param>
        /// <param name="isActive"></param>
        /// <param name="createBy"></param>
        /// <param name="createDate"></param>
        /// <returns>if save properly return Event Table ID or zero fail save info </returns>
       
        public Decimal Save(Decimal eventId, string name, string note, int isActive, decimal createBy, DateTime createDate)
        {
            Decimal eventInfoID = eventId;
            string objectItemName = new EVENT_INFOcls().GetType().Name;

            try
            {
                eventInfoID = new EventInfoDZ().Save(eventId, name, note, isActive, createBy, createDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return eventInfoID;
        }

        #endregion Save Methods
    }
}
