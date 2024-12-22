using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.ShelterZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class TickerMessagePZ
    {
        public TickerMessagePZ()
        { }

        public const string _collectionNodePart = "Coll";

        public List<SP_GET_TICKER_MESSAGEcls> GetTickerMessageSearch(decimal id, string prepareDateFrom, string prepareDateTo, decimal distributorID, decimal currentPage)
        {
            try
            {
                return new TickerMessageDZ().GetTickerMessageSearch(id, prepareDateFrom, prepareDateTo, distributorID, currentPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_TICKER_MESSAGEcls> GetTickerMessageByDate(DateTime displayDate, decimal distributorID)
        {
            try
            {
                return new TickerMessageDZ().GetTickerMessageByDate(displayDate, distributorID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ServiceStringXML GetTickerMessageByDateXML(DateTime displayDate, decimal distributorID)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            String objectXML = string.Empty;
            string objectItemName = new SP_GET_RETAIL_RSO_WISECls().GetType().Name + _collectionNodePart;
            try
            {
                List<SP_GET_TICKER_MESSAGEcls> ticMessColl = new TickerMessageDZ().GetTickerMessageByDate(displayDate, 0);

                List<SP_GET_TICKER_MESSAGEcls> ticMessFilterColl = new List<SP_GET_TICKER_MESSAGEcls>();
                if (ticMessColl != null && ticMessColl.Count > 0)
                {
                    foreach (var ticMss in ticMessColl)
                    {
                        if (ticMss.DISTRIBUTOR_ID == 0)
                        {
                            ticMessFilterColl.Add(ticMss);
                        }
                        else if (ticMss.DISTRIBUTOR_ID == distributorID)
                        {
                            ticMessFilterColl.Add(ticMss);
                        }
                    }
                }


                if (ticMessFilterColl != null && ticMessFilterColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<SP_GET_TICKER_MESSAGEcls>(ticMessFilterColl, _collectionNodePart);
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

        public decimal SaveOrOpdateTickerMessage(decimal id, decimal distributorId, DateTime prepareDate, string messageNote,
           DateTime displayStartDate, DateTime displayEndDate)
        {
            try
            {
                return new TickerMessageDZ().SaveUpdateTickerMessage(id, distributorId, prepareDate, messageNote, displayStartDate, displayEndDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
