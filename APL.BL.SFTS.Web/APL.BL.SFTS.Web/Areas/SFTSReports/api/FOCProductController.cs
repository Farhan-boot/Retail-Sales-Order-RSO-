using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.Models.ApiMobile;
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

namespace APL.BL.SFTS.Web.Areas.SFTSReports.api
{
    [RoutePrefix("SFTSReports/api/FOCProduct")]
    public class FOCProductController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetIssuedFOCProduct(object[] data)
        {
            List<SP_GET_RETAILER_SAF> retailerSaf = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                SearchParam objSearchParam = JsonConvert.DeserializeObject<SearchParam>(data[1].ToString());

                retailerSaf = new RetailerPZ().GetIssuedFOCProducts(objSearchParam, objcmnParam.FromDate, objcmnParam.ToDate);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                retailerSaf
            });
        }
    }
}
