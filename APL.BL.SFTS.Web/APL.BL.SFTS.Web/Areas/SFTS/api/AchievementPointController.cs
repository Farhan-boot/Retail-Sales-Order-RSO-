using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone.Target;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APL.BL.SFTS.Web.Areas.SFTS.api
{
    [RoutePrefix("SFTS/api/AchievementPoint")]
    public class AchievementPointController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetAchievementPoints(object[] data)
        {
            IEnumerable<SP_GET_ACHIEVE_POINT> achievementPointList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                achievementPointList = new AchievementPointPZ().GetAchievementPoints(objcmnParam.PointId, objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                achievementPointList
            });
        }

        [HttpPost]
        public HttpResponseMessage SaveAchievementPoint(object[] data)
        {
            string result = "";

            try
            {
           
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                AchievementPoint point = JsonConvert.DeserializeObject<AchievementPoint>(data[1].ToString());

              var pointDb =new AchievementPointPZ().GetAchievementPoints(point.PointId, objcmnParam.loggeduser).Where(w=>w.POINT_CODE==point.PointCode && w.POINT_NAME==point.PointName && w.POINT_SCORE==point.PointScore).ToList();
                if (pointDb.Count() == 0)
                {
                    if (point.PointId == 0)
                    {
                        point.ActionFlag = 1;
                    }
                    else
                    {
                        point.ActionFlag = 2;
                    }
                    decimal updateResult = new AchievementPointPZ().SaveAchievementPoint(point, objcmnParam.UserId);

                    result = updateResult > 0 ? updateResult.ToString() : result;
                }
                else
                {
                    result = "10";
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                result = "";
            }


            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [HttpPost]
        public HttpResponseMessage DeleteInfo(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                AchievementPoint point = JsonConvert.DeserializeObject<AchievementPoint>(data[1].ToString());

                if (point.PointId > 0)
                {
                    decimal updateResult = new AchievementPointPZ().DeleteInfo(point.PointId);
                    result = updateResult > 0 ? updateResult.ToString() : result;
                }
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
