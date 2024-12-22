using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
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
    [RoutePrefix("SFTS/api/TradeMaterial")]
    public class TradeMaterialController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetFOCProducts(object[] data)
        {
            IEnumerable<SP_GET_FOC_PRODUCT_INFO> productList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                productList = new VisitPlanPZ().GetFOCProducts(objcmnParam.TradeMaterialId, objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                productList
            });
        }

        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveUpdateFOCProduct(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                FocProduct focProduct = JsonConvert.DeserializeObject<FocProduct>(data[1].ToString());

                decimal updateResult = new VisitPlanPZ().SaveUpdateTradeMaterial(focProduct.TradeMaterialId, focProduct.TradeMaterialCode, focProduct.TradeMaterialName, focProduct.IsActive, objcmnParam.UserId);

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
