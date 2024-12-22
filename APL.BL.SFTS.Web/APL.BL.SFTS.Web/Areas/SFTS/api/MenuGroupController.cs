using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APL.BL.SFTS.Web.Areas.SFTS.api
{
    [RoutePrefix("SFTS/api/MenuGroup")]
    public class MenuGroupController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetMenuGroups(object[] data)
        {
            IEnumerable<SP_GET_MENUGROUP_WEB> menuGroupList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                menuGroupList = new MenuGroupPZ().GetMenuGroups(objcmnParam.MenuGroupId, objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                menuGroupList
            });
        }

        [HttpPost]
        public HttpResponseMessage SaveMenuGroup(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                MenuGroup group = JsonConvert.DeserializeObject<MenuGroup>(data[1].ToString());
                if(group.GroupId==0)
                {
                    group.ActionFlag = 1;
                }
                else
                {
                    group.ActionFlag = 2;
                }
                decimal updateResult = new MenuGroupPZ().SaveMenuGroup(group.ActionFlag, group.GroupId, group.GroupName, group.GroupFor, group.IsActive, objcmnParam.UserId);

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
