using APL.BL.SFTS.DataBridgeZone;
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

namespace APL.BL.SFTS.Web.Areas.SFTSReports.api
{
    [RoutePrefix("SFTSReports/api/Target")]
    public class TargetController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetUploadedTarget(object[] data)
        {
            List<SP_GET_TARGET_FILE> uploadedTarget = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                TargetFileExport targetFileExport = JsonConvert.DeserializeObject<TargetFileExport>(data[1].ToString());

                uploadedTarget = new TargetSetupPZ().GetUploadedTargets(targetFileExport.TargetPeriodId, targetFileExport.TargetItemId, targetFileExport.TargetFor, targetFileExport.StaffTypeId, targetFileExport.InitialVersion);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                uploadedTarget
            });
        }
    }
}
