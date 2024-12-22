using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
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
    [RoutePrefix("SFTS/api/MarketUpdate")]
    public class MarketUpdateController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetMarketUpdate(object[] data)
        {
            IEnumerable<SP_GET_MARKET_UPDATE> marketUpdateList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                marketUpdateList = new VisitPlanPZ().GetMarketUpdate(objcmnParam.loggeduser, objcmnParam.FromDate, objcmnParam.ToDate, objcmnParam.MarketUpdateTypeId, objcmnParam.EventId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                marketUpdateList
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetMarketUpdatePictures(object[] data)
        {
            List<GET_MARKET_UPDATE_PICTURE> getMarketUpdatePictures = null;
            vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

            try
            {
                getMarketUpdatePictures = new VisitPlanPZ().GetMarketUpdatePictures(0, objcmnParam.MarketUpdateId, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(new
            {
                getMarketUpdatePictures
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetMarketUpdateTypes(object[] data)
        {
            IEnumerable<SP_GET_MARKET_UPDATE_TYPE> marketUpdateTypeList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                marketUpdateTypeList = new VisitPlanPZ().GetMarketUpdateTypes(objcmnParam.MarketUpdateTypeId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                marketUpdateTypeList
            });
        }

        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveUpdateMarketUpdateType(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                MarketUpdateType marketUpdateType = JsonConvert.DeserializeObject<MarketUpdateType>(data[1].ToString());

                decimal updateResult = new VisitPlanPZ().SaveUpdateMarketUpdateType(marketUpdateType.Id, marketUpdateType.Name, marketUpdateType.IsActive, objcmnParam.loggeduser);
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
