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
    [RoutePrefix("SFTS/api/MenuGroupItemMap")]
    public class MenuGroup_ItemMapController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetMenuGroupItemMaps(object[] data)
        {
            IEnumerable<SP_GET_GROUPITEM_MAP_WEB> menuGroupItemMapList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                menuGroupItemMapList = new MenuGroupItemMapPZ().GetMenuGroupItemMaps(objcmnParam.Mapping_Id, objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                menuGroupItemMapList
            });
        }
        [HttpPost]
        public IHttpActionResult GetMenuGroups(object[] data)
        {
            IEnumerable<SP_GET_MENUGROUP_WEB> menuGroupList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                menuGroupList = new MenuGroupPZ().GetMenuGroups(objcmnParam.MenuGroupId, objcmnParam.loggeduser);
                if(objcmnParam.MappingFor>0)
                {
                    menuGroupList = menuGroupList.Where(w => w.GROUP_FOR == objcmnParam.MappingFor).ToList();
                }

               
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
        public IHttpActionResult GetMenuItems(object[] data)
        {
            IEnumerable<SP_GET_MENUITEM_WEB> menuItemList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                menuItemList = new MenuGroupItemMapPZ().GetMenuItems(objcmnParam.MenuGroupId, objcmnParam.MappingFor);
                if (objcmnParam.MappingFor > 0)
                {
                    menuItemList = menuItemList.Where(w => w.MENU_FOR == objcmnParam.MappingFor).ToList();
                }


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
        public HttpResponseMessage SaveMenuGroupItemMap(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                GroupItemMap groupItems = JsonConvert.DeserializeObject<GroupItemMap>(data[1].ToString());
                if (groupItems.MappingId == 0)
                {
                    groupItems.ActionFlag = 1;
                }
                else
                {
                    groupItems.ActionFlag = 2;
                }
                decimal updateResult = new MenuGroupItemMapPZ().SaveMenuGroupItemMaps(groupItems, objcmnParam.UserId);

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
