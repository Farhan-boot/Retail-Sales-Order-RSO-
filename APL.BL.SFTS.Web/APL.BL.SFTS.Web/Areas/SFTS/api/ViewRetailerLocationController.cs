using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.Web.Providers;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace APL.BL.SFTS.Web.Areas.SFTS.api
{
    [RoutePrefix("SFTS/api/ViewRetailerLocation")]
    public class ViewRetailerLocationController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRetailerGPS(object[] data)
        {
            IEnumerable<SP_GET_RETAILER_GPS> retailerGPS = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                retailerGPS = new RetailerPZ().GetRetailerGPS(0, objcmnParam.ZoneId, objcmnParam.RouteID, objcmnParam.RetailerId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                retailerGPS
            });
        }



		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetRSORetailerGPS(object[] data)
		{
			IEnumerable<SP_GET_RETAILER_GPS> retailerGPS = null;

			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

				retailerGPS = new RetailerPZ().GetRSORetailerGPS(0, objcmnParam.ZoneId, objcmnParam.RouteID, objcmnParam.RetailerId, objcmnParam.Date);
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				retailerGPS
			});
		}

		[HttpPost, ApiAuthorization]
        public IHttpActionResult GetBTSLocation(object[] data)
        {
            IEnumerable<SP_GET_BTS_GPS> btsGPS = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                btsGPS = new RetailerPZ().GetBTSLocation(0, objcmnParam.ZoneId, objcmnParam.RouteID);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                btsGPS
            });
        }

    }
}
