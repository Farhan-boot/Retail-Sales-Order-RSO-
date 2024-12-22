using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APL.BL.SFTS.Web.Areas.SFTS.api
{
    [RoutePrefix("SFTS/api/Ev_minmaxlimit")]
    public class EV_MinMaxLimitController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetEVMinmaxlimit(object[] data)
        {
            IEnumerable<SP_GET_ALL_EV_LIMIT> employeeList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                employeeList = new VisitPlanPZ().GetEVMinmaxlimit(objcmnParam.EV_Limit_Id, objcmnParam.loggeduser);
                //employeeList = new VisitPlanPZ().GetEmployees(0, 0);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                employeeList
            });
        }
        [HttpPost]
        public HttpResponseMessage SaveUpdateEVLimit(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                EV_MinMaxLimit employee = JsonConvert.DeserializeObject<EV_MinMaxLimit>(data[1].ToString());

                decimal updateResult = new VisitPlanPZ().SaveUpdateEVLimit(employee.EV_LimitId, employee.MinAmount, employee.MaxAmount, objcmnParam.loggeduser);

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
