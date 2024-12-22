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
    [RoutePrefix("SFTS/api/DistributorTargetRevise")]
    public class DistributorTargetReviseController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetDistributorTarget(object[] data)
        {
            IEnumerable<SP_GET_DISTRIBUTOR_TARGET> distributorTargetList = null;

            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                distributorTargetList = new TargetSetupPZ().GetDistributorTarget(objcmnParam.TargetId, objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                recordsTotal,
                distributorTargetList
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetDistributorTargetDetail(object[] data)
        {
            IEnumerable<SP_GET_DISTRIBUTOR_TARGET> distTargetDetailList = null;

            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                distTargetDetailList = new TargetSetupPZ().GetDistributorTargetDetail(objcmnParam.TargetId, objcmnParam.loggeduser, objcmnParam.Version);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                recordsTotal,
                distTargetDetailList
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetDistributorTargetReviseReq(object[] data)
        {
            IEnumerable<SP_GET_DISTRIBUTOR_TARGET> disTargetModReqList = null;

            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                disTargetModReqList = new TargetSetupPZ().GetDistributorTargetReviseReq(objcmnParam.TargetId, objcmnParam.loggeduser, objcmnParam.Version);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                recordsTotal,
                disTargetModReqList
            });
        }


        [HttpPost, ApiAuthorization]
        public HttpResponseMessage ReviseDistributorTarget(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                vmDistributorTargetRevise distTarget = JsonConvert.DeserializeObject<vmDistributorTargetRevise>(data[1].ToString());

                if (distTarget != null)
                {
                    decimal insertedId = 0;
                    distTarget.Id = new GetNewIdDZ().GetNewId("SQ_FF_DIST_TARGET_MODIFY");
                    insertedId = new TargetSetupPZ().SaveUpdateTargetRevise(distTarget.Id, distTarget.TargetId, distTarget.TargetDetailId, objcmnParam.Version, distTarget.TargetValue, distTarget.RevisedTargetValue, distTarget.Comments, objcmnParam.loggeduser);
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
