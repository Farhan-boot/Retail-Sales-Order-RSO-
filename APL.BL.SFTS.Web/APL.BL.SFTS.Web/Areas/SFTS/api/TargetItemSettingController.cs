using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.Models.SFTS;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.ProcessZone.Target;
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
    [RoutePrefix("SFTS/api/TargetItemSetting")]
    public class TargetItemSettingController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveUpdateTargetItem(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                TargetItem targetItem = JsonConvert.DeserializeObject<TargetItem>(data[1].ToString());
                List<TargetItemApplyTo> listTargetItemApplyTo = JsonConvert.DeserializeObject<List<TargetItemApplyTo>>(data[2].ToString());
                if (targetItem.TargetItemId == 0) { targetItem.TargetItemId = new GetNewIdDZ().GetNewId("SEQ_TARGET_ITEM_ID"); }

                if (targetItem != null)
                {
                    decimal SavedTargetItemId = new TargetItemPZ().SaveUpdateTargetItem(targetItem.TargetItemId, targetItem.Code, targetItem.Name, targetItem.IsActive, targetItem.UnitName);
                    decimal IsSavedApplyTo = 0;
                    foreach (TargetItemApplyTo tiApply in listTargetItemApplyTo)
                    {
                         tiApply.CenterTypeId = tiApply.CenterTypeId == 0 ? null : tiApply.CenterTypeId;
                         tiApply.StaffTypeId = tiApply.StaffTypeId == 0 ? null : tiApply.StaffTypeId;
                         IsSavedApplyTo = new TargetItemPZ().SaveUpdateTargetItemApplyTo(tiApply.TargetItemApplyToId, targetItem.TargetItemId, tiApply.ChannelTypeId, tiApply.TargetEntityType, tiApply.StaffTypeId, tiApply.CenterTypeId, tiApply.DistributorIsSumOfStaff, tiApply.StaffIsSumOfCenter, tiApply.IsActive);
                    }

                    result = SavedTargetItemId > 0 && IsSavedApplyTo == 1 ? SavedTargetItemId.ToString() : "";
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
        public IHttpActionResult GetTargetItems(object[] data)
        {
            IEnumerable<GET_TARGET_ITEM> targetItems = null;

            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                targetItems = new TargetItemPZ().GetTargetItems(objcmnParam.TargetItemId, 0);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                recordsTotal,
                targetItems
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetTargetItemApplyTo(object[] data)
        {
            IEnumerable<GET_TARGET_ITEM_APPLY_TO> targetItemApplyTo = null;

            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                targetItemApplyTo = new TargetItemPZ().GetTargetItemApplyTo( 0, objcmnParam.TargetItemId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                recordsTotal,
                targetItemApplyTo
            });
        }


    }
}
