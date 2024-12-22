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
    [RoutePrefix("SFTS/api/ApproveDistributorTargetRevise")]
    public class ApproveDistributorTargetReviseController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetDistributorTargetForApprove(object[] data)
        {
            IEnumerable<SP_GET_DISTRIBUTOR_TARGET> distributorTargetList = null;

            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                distributorTargetList = new TargetSetupPZ().GetDistributorTargetForApprove(objcmnParam.TargetId, objcmnParam.loggeduser, objcmnParam.UserType);
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
        public HttpResponseMessage ApproveReviseRequest(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                vmApproveReviseRequest reviseReqApprove = JsonConvert.DeserializeObject<vmApproveReviseRequest>(data[1].ToString());

                if (reviseReqApprove != null)
                {
                    decimal insertedId = 0;
                    insertedId = new TargetSetupPZ().ApproveDistributorTargetRevise(reviseReqApprove.TargetId, objcmnParam.Version, reviseReqApprove.ActionType, reviseReqApprove.ApproverComment, objcmnParam.loggeduser, objcmnParam.UserType);
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
