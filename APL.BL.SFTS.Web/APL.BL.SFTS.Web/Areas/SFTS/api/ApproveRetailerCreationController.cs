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
    [RoutePrefix("SFTS/api/ApproveRetailerCreation")]
    public class ApproveRetailerCreationController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetNewRetailerRequest(object[] data)
        {
            IEnumerable<SP_GET_NEW_RETAILER_FOR_APPROVE> newRetailerRequestList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                newRetailerRequestList = new RetailerPZ().GetNewRetailerForApprove(objcmnParam.RetailerModifyId, objcmnParam.StatusId, objcmnParam.FromDate, objcmnParam.ToDate);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                newRetailerRequestList
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRetailersLocationByRoute(object[] data)
        {
            IEnumerable<SP_GET_RETAILER_LOC_BY_ROUTE> RetailerLocationList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                RetailerLocationList = new RetailerPZ().GetRetailerLocationByRoute(objcmnParam.RouteID);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                RetailerLocationList
            });
        }


        [HttpPost, ApiAuthorization]
        public HttpResponseMessage ApproveNewRetailer(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                vmRetailerCreationApprove retCreationApprove = JsonConvert.DeserializeObject<vmRetailerCreationApprove>(data[1].ToString());

                if (retCreationApprove != null)
                {
                    decimal insertedId = 0;
                    insertedId = new RetailerPZ().SaveRetailerModifyReqApprove(retCreationApprove.RetailerModifyId, retCreationApprove.ActionType, retCreationApprove.ApproverComment);
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
