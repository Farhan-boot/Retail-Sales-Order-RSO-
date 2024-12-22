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
    [RoutePrefix("SFTS/api/UserRoleAssign")]
    public class UserRoleAssignController : ApiController
    {     
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetUserRoles(object[] data)
        {
            IEnumerable<SP_GET_USER_ROLE> roleList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                roleList = new MenuPZ().GetUserRoles(objcmnParam.UserId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                roleList
            });
        }

        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveUpdateUserRoles(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                List<UserRole> roles = JsonConvert.DeserializeObject<List<UserRole>>(data[1].ToString());

                if (roles != null)
                {
                    decimal SavedId = 0;
                    foreach (UserRole role in roles)
                    {
                        decimal IsActive = 0;
                        IsActive = role.IS_ACTIVE == true ? 1 : 0;
                        SavedId = new MenuPZ().SaveUpdateUserRoles(objcmnParam.UserId, role.ID, IsActive, objcmnParam.loggeduser);
                    }

                    result = SavedId > 0 ? SavedId.ToString() : "";
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

    }
}
