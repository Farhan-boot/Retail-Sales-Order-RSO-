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
    [RoutePrefix("SFTS/api/AppMenu")]
    public class AppMenuController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetAppMenus(object[] data)
        {
            IEnumerable<SP_GET_MENUITEM_WEB> menuItemList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                menuItemList = new MenuItemPZ().GetMenuItems(objcmnParam.MenuGroupId, objcmnParam.loggeduser, objcmnParam.MappingFor);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                menuItemList
            });
        }
        [HttpPost]
        public IHttpActionResult GetMenuGroups(object[] data)
        {
            IEnumerable<SP_GET_MENUITEM_WEB> menuItemList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                menuItemList = new MenuItemPZ().GetMenuGroups(objcmnParam.MenuGroupId, objcmnParam.loggeduser, objcmnParam.MappingFor).ToList();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                menuItemList
            });
        }
        [HttpPost]
        public HttpResponseMessage SaveAppMenu(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                MenuItem group = JsonConvert.DeserializeObject<MenuItem>(data[1].ToString());
                if (group.ItemId == 0)
                {
                    group.ActionFlag = 1;
                }
                else
                {
                    group.ActionFlag = 2;
                }
                decimal updateResult = new MenuItemPZ().SaveMenuItem(group.ActionFlag, group.ItemId, group.MenuName, group.MenuNameB, group.MenuUrl, group.MenuFor, group.IsActive,group.ParentId,group.IsHeader, objcmnParam.UserId);

                result = updateResult > 0 ? updateResult.ToString() : result;
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
                MenuItem group = JsonConvert.DeserializeObject<MenuItem>(data[1].ToString());

                if (group.ItemId > 0)
                {
                    decimal updateResult = new MenuItemPZ().DeleteInfo(group.ItemId);
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
        [HttpPost]
        public HttpResponseMessage UpdateSrlNo(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                MenuItem group = JsonConvert.DeserializeObject<MenuItem>(data[1].ToString());

                if (group.ItemId > 0)
                {
                    decimal updateResult = new MenuItemPZ().UpdateSrlNo(group.ItemId,group.SrlNo);
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
