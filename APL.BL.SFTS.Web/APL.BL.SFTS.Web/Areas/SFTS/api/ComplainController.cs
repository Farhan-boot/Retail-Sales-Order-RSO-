using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
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
    [RoutePrefix("SFTS/api/Complain")]
    public class ComplainController : ApiController
    {

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetComplains(object[] data)
        {
            List<SP_GET_COMPLAINS> getComplainList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                Complain complain = JsonConvert.DeserializeObject<Complain>(data[1].ToString());

                getComplainList = new VisitPlanPZ().GetComplains(complain);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                getComplainList
            });
        }
     

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetComplainPictures(object[] data)
        {
            List<GET_COMPLAIN_PICTURE> getComplainPictures = null;
            vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

            try
            {
                getComplainPictures = new VisitPlanPZ().GetComplainPictures(0, objcmnParam.ComplainId, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(new
            {
                getComplainPictures
            });
        }

        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SubmitComplainStatus(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                Complain complain = JsonConvert.DeserializeObject<Complain>(data[1].ToString());

                if (complain != null)
                {
                    decimal insertedId = 0;
                    insertedId = new RetailerPZ().SubmitComplainStatus(complain.Id, complain.StatusId, complain.ResolutionDetail, objcmnParam.loggeduser);
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
