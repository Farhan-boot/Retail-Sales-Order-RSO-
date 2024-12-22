using APL.BL.SFTS.DataBridgeZone;
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
    [RoutePrefix("SFTSReports/api/Common")]
    public class CommonController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetClusters(object[] data)
        {
            IEnumerable<GET_DROPDOWN> objListCluster = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                objListCluster = new RoutePZ().GetClusters(objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListCluster
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRegions(object[] data)
        {
            IEnumerable<GET_REGION> objListRegion = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListRegion = new RetailerPZ().GetRegions(objcmnParam.ClusterId, objcmnParam.loggeduser, objcmnParam.IsRegionalUser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListRegion
            });
        }

        [HttpPost]
        public IHttpActionResult GetZones(object[] data)
        {
            IEnumerable<GET_ZONE> objListZone = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListZone = new RetailerPZ().GetZones(0, objcmnParam.RegionId, objcmnParam.loggeduser, objcmnParam.IsZonalUser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListZone
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRoutes(object[] data)
        {
            IEnumerable<GET_DROPDOWN> objListRoute = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListRoute = new RetailerPZ().GetRoutesByZone(objcmnParam.ZoneId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListRoute
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetUserWorkArea(object[] data)
        {
            IEnumerable<GET_USER_WORK_AREA> objListUserWorkArea = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListUserWorkArea = new RsoPZ().GetUserWorkArea(objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListUserWorkArea
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetTargetItems(object[] data)
        {
            IEnumerable<SP_GET_TARGET_ITEM> objListTargetItem = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListTargetItem = new TargetSetupPZ().GetAllTargetItem(objcmnParam.TargetItemId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListTargetItem
            });
        }
    }
}
