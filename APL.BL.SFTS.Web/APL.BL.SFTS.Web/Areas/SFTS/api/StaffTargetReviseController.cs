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
    [RoutePrefix("SFTS/api/StaffTargetRevise")]
    public class StaffTargetReviseController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetStaffTarget(object[] data)
        {
            IEnumerable<SP_GET_STAFF_TARGET> staffTargetList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                staffTargetList = new TargetSetupPZ().GetStaffTarget(objcmnParam.loggeduser, objcmnParam.Version);
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
                staffTargeDetailtList = new TargetSetupPZ().GetStaffTargetDetail(objcmnParam.TargetId, objcmnParam.Version, objcmnParam.loggeduser);
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
        public HttpResponseMessage ReviseStaffTarget(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                List<SP_GET_STAFF_TARGET_DETAIL> staffTargetRevise = JsonConvert.DeserializeObject<List<SP_GET_STAFF_TARGET_DETAIL>>(data[1].ToString());

                if (staffTargetRevise != null)
                {
                    decimal insertedId = 0;
                    decimal targetModifyId = new GetNewIdDZ().GetNewId("SQ_FF_STAFF_TARGET_MODIFY");
                    insertedId = new TargetSetupPZ().SaveStaffTargetRevise(targetModifyId, objcmnParam.loggeduser, objcmnParam.TargetId, objcmnParam.Version, staffTargetRevise);
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
