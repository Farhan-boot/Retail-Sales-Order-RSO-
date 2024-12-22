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
    [RoutePrefix("SFTS/api/RmbmAcknowledgement")]
    public class RmbmAcknowledgementController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetAmbmShopVisitSearch(object[] data)
        {
            IEnumerable<SP_GET_AMBM_SHOP_VISIT> ambmShopVisitList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                ambmShopVisitList = new VisitPlanPZ().GetAmbmShopVisitSearch(objcmnParam.loggeduser, objcmnParam.AmbmId, objcmnParam.FromDate, objcmnParam.ToDate);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                ambmShopVisitList
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetAmbmShopVisit(object[] data)
        {
            IEnumerable<SP_GET_AMBM_SHOP_VISIT> ambmShopVisitList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                ambmShopVisitList = new VisitPlanPZ().GetAmbmShopVisit(objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                ambmShopVisitList
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetFeedbackQuestionAnswerList(object[] data)
        {
            IEnumerable<SP_GET_FEEDBACK_QUESTION_ANSWER> feedbackQuestionAnswerList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                feedbackQuestionAnswerList = new VisitPlanPZ().GetFeedbackQuestionAnswerList(objcmnParam.VisitId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                feedbackQuestionAnswerList
            });
        }

        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveRmbmAcknowledgement(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                if (objcmnParam != null)
                {
                    decimal insertedId = 0;
                    insertedId = new VisitPlanPZ().SaveRmbmAcknowledgement(objcmnParam.VisitId, objcmnParam.Comments);
                    result = insertedId > 0 ? insertedId.ToString() : result;
                }
                else
                {
                    result = "";
                }
            }
            catch (Exception e)
            {
                e.ToString();
                result = "";
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

    }
}
