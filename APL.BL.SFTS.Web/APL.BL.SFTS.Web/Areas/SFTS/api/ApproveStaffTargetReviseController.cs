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
    [RoutePrefix("SFTS/api/ApproveStaffTargetRevise")]
    public class ApproveStaffTargetReviseController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetStaffTargetForApprove(object[] data)
        {
            IEnumerable<SP_GET_STAFF_TARGET> staffTargetList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                staffTargetList = new TargetSetupPZ().GetStaffTargetForApprove(objcmnParam.loggeduser, objcmnParam.Version, objcmnParam.UserType);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                staffTargetList
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetStaffTargetDetail(object[] data)
        {
            IEnumerable<SP_GET_STAFF_TARGET_DETAIL> staffTargeDetailtList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                staffTargeDetailtList = new TargetSetupPZ().GetStaffTargetDetailForApproval(objcmnParam.TargetId, objcmnParam.Version);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                staffTargeDetailtList
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetStaffRequestedTargetDetail(object[] data)
        {
            IEnumerable<SP_GET_STAFF_TARGET_DETAIL> staffTargeReqDetailtList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                staffTargeReqDetailtList = new TargetSetupPZ().GetStaffReqTargetDetail(objcmnParam.TargetId, objcmnParam.Version);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                staffTargeReqDetailtList
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
                    insertedId = new TargetSetupPZ().ApproveStaffTargetRevise(reviseReqApprove.TargetId, objcmnParam.Version, reviseReqApprove.ActionType, reviseReqApprove.ApproverComment, objcmnParam.loggeduser, objcmnParam.UserType);
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
