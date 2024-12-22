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
    [RoutePrefix("SFTS/api/ScrollMessage")]
    public class ScrollMessageController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetScrollMessages(object[] data)
        {
            IEnumerable<SP_GET_SCROLL_MESSAGE> messageList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                messageList = new VisitPlanPZ().GetScrollMessages(objcmnParam.MessageId, objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                messageList
            });
        }


        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveUpdateScrollMessage(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                vmScrollMessage scrollMessage = JsonConvert.DeserializeObject<vmScrollMessage>(data[1].ToString());
                //List<GET_ID> zoneList = JsonConvert.DeserializeObject<List<GET_ID>>(data[2].ToString());

                decimal updateResult = new VisitPlanPZ().SaveUpdateScrollMessage(scrollMessage.MessageId, scrollMessage.Message, scrollMessage.DisplayFrom, scrollMessage.DisplayTo, scrollMessage.IsActive, objcmnParam.loggeduser);

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
