using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.SFTS;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.Web.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APL.BL.SFTS.Web.Areas.SFTS.api
{
    [RoutePrefix("SFTS/api/EventCreate")]
    public class EventCreateController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetEvents(object[] data)
        {
            IEnumerable<SP_GET_EVENT_INFO> eventList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                eventList = new VisitPlanPZ().GetEvents(objcmnParam.EventId, objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                eventList
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetEventAreas(object[] data)
        {
            IEnumerable<GET_ALL_ZONE> eventArea = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                eventArea = new VisitPlanPZ().GetEventAreas(objcmnParam.EventId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                eventArea
            });
        }

        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveUpdateEvent(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                vmEventCreate eventCreate = JsonConvert.DeserializeObject<vmEventCreate>(data[1].ToString());
                List<GET_ID> zoneList = JsonConvert.DeserializeObject<List<GET_ID>>(data[2].ToString());

                if (eventCreate.EventId == 0) { eventCreate.EventId = new GetNewIdDZ().GetNewId("SQ_FF_EVENT_INFO_ID"); }
                
                decimal updateResult = new VisitPlanPZ().SaveUpdateEventCreate(eventCreate.EventId,eventCreate.EventName, eventCreate.Note, eventCreate.IsActive, objcmnParam.loggeduser, zoneList, eventCreate.IsToAll);

                result = updateResult > 0 ? updateResult.ToString() : result;
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                result = "";
            }


            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
