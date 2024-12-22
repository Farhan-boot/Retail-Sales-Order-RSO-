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
    [RoutePrefix("SFTS/api/ApproveRetailerInfoUpdate")]
    public class ApproveRetailerInfoUpdateController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRetailerModifyRequest(object[] data)
        {
            IEnumerable<SP_GET_RETAILER_INFO_UPDATE_FOR_APPROVE> modifiedRetailerRequestList = null;

            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                modifiedRetailerRequestList = new RetailerPZ().GetRetailerUpdatedInfoForApprove(objcmnParam.RetailerModifyId, objcmnParam.StatusId, objcmnParam.FromDate, objcmnParam.ToDate);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                recordsTotal,
                modifiedRetailerRequestList
            });
        }

        [HttpPost, ApiAuthorization]
        public HttpResponseMessage ApproveRetailerModifyRequest(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                vmRetailerCreationApprove retCreationApprove = JsonConvert.DeserializeObject<vmRetailerCreationApprove>(data[1].ToString());

                if (retCreationApprove != null)
                {
                    decimal insertedId = 0;
                    insertedId = new RetailerPZ().SaveRetailerInfoModifyReqApprove(retCreationApprove.RetailerModifyId, retCreationApprove.ActionType, retCreationApprove.ApproverComment);
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
