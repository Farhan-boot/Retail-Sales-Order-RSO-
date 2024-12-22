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
    [RoutePrefix("SFTS/api/BestRSOPractice")]
    public class BestRSOPracticeController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveUpdateBestRSOPractice(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                BestPracticesRSO objBPR = JsonConvert.DeserializeObject<BestPracticesRSO>(data[1].ToString());

                if (objBPR != null)
                {
                    decimal SavedBPRId = new RsoPZ().SaveUpdateRsoBestPractice(objBPR.BestPracticesRsoId, objBPR.RsoId, objBPR.RetailerMarketAreaId, objBPR.PeriodId, objBPR.Year, objBPR.CalculationAreaId, objBPR.Description, objcmnParam.loggeduser);
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
        public IHttpActionResult GetAllBestRSOPractice(object[] data)
        {
            IEnumerable<SP_GET_BEST_RSO_PRACTICE> bestRsoPracticeList = null;

            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                bestRsoPracticeList = new RsoPZ().GetAllBestRsoPractice(objcmnParam.BestPracticesRsoId, 0);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                recordsTotal,
                bestRsoPracticeList
            });
        }
    }
}
