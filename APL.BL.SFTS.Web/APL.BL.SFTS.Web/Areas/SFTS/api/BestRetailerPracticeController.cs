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
    [RoutePrefix("SFTS/api/BestRetailerPractice")]
    public class BestRetailerPracticeController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveUpdateBestRetailerPractice(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                BestPracticesRetailer objBPR = JsonConvert.DeserializeObject<BestPracticesRetailer>(data[1].ToString());

                if (objBPR != null)
                {
                    decimal SavedBPRId = new RetailerPZ().SaveUpdateRetailerBestPractice(objBPR.BestPracticesRetailerId, objBPR.RetailerId, objBPR.RetailerMarketAreaId, objBPR.PeriodId, objBPR.Year, objBPR.CalculationAreaId, objBPR.Description, objcmnParam.loggeduser);
                    result = SavedBPRId > 0 ? SavedBPRId.ToString() : "";
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

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetAllBestRetailerPractice(object[] data)
        {
            IEnumerable<SP_GET_BEST_RETAILER_PRACTICE> bestRetailerPracticeList = null;

            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                bestRetailerPracticeList = new RetailerPZ().GetAllBestRetailerPractice(objcmnParam.RetailerBestPracticeId, 0);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                recordsTotal,
                bestRetailerPracticeList
            });
        }
    }
}
