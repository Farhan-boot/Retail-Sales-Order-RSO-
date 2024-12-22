using APL.BL.SFTS.DataBridgeZone;
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
    [RoutePrefix("SFTS/api/Menu")]
    public class MenuController : ApiController
    {
		// [HttpPost, ApiAuthorization]
		[HttpPost]
		public IHttpActionResult GetMenu(object[] data)
        {
            List<GetMenu> menuList = new List<GetMenu>();

            List<SP_GET_MENU> mainMenuList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                mainMenuList = new MenuPZ().GetMainMenu(objcmnParam.loggeduser);
                foreach(SP_GET_MENU mainMenu in mainMenuList)
                {
                    GetMenu objMenu = new GetMenu();
                    List<SP_GET_MENU> subMenuList = new List<SP_GET_MENU>();
                    subMenuList = new MenuPZ().GetSubMenu(objcmnParam.loggeduser, mainMenu.ID);
                    objMenu.mainMenu = mainMenu;
                    objMenu.subMenuList = subMenuList;
                    menuList.Add(objMenu);
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                classAddWithParent = "menu-open",
                classAddWithChild = "",
                menuList
            });
        }
    }
}
