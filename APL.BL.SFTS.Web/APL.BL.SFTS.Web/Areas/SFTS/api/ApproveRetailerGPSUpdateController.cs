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
    [RoutePrefix("SFTS/api/ApproveRetailerGPSUpdate")]
    public class ApproveRetailerGPSUpdateController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRetailerGPSUpdateRequest(object[] data)
        {
            IEnumerable<SP_GET_RETAILER_GPS_FOR_APPROVE> retailerGPSUpdateReq = null;

            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                retailerGPSUpdateReq = new RetailerPZ().GetRetailerGPSUpdateForApprove(objcmnParam.RetailerModifyId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                recordsTotal,
                retailerGPSUpdateReq
            });
        }

        [HttpPost, ApiAuthorization]
        public HttpResponseMessage ApproveRetailerGPSUpdate(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                vmRetailerCreationApprove retCreationApprove = JsonConvert.DeserializeObject<vmRetailerCreationApprove>(data[1].ToString());

                if (retCreationApprove != null)
                {
                    decimal insertedId = 0;
                    insertedId = new RetailerPZ().SaveRetailerGPSUpdateReqApprove(retCreationApprove.RetailerModifyId, retCreationApprove.ActionType, retCreationApprove.ApproverComment);
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
