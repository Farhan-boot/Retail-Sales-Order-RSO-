using APL.BL.SFTS.DataBridgeZone;
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
    [RoutePrefix("SFTS/api/VisitFeedbackStatus")]
    public class VisitFeedbackStatusController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetVisitFeedbackStatuses(object[] data)
        {
            IEnumerable<SP_GET_VISIT_FEEDBACK_STATUS> visitFeedbackStatusList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                visitFeedbackStatusList = new VisitPlanPZ().GetVisitFeedbackStatus(objcmnParam.VisitFeedbackStatusId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                visitFeedbackStatusList
            });
        }

        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveUpdateVisitFeedbackStaus(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                VisitFeedbackStatus visitFeedbackStatus = JsonConvert.DeserializeObject<VisitFeedbackStatus>(data[1].ToString());

                decimal updateResult = new VisitPlanPZ().SaveUpdateVisitFeedbackStatus(visitFeedbackStatus.Id, visitFeedbackStatus.StatusDescription, visitFeedbackStatus.StatusDescriptionBAN, objcmnParam.loggeduser);
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
