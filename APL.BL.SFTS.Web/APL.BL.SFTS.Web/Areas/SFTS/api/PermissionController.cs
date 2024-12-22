using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.Models.SFTS;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.Web.Areas.HelpPage;
using APL.BL.SFTS.Web.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APL.BL.SFTS.Web.Areas.SFTS.api
{
    [RoutePrefix("SFTS/api/Permission")]
    public class PermissionController : ApiController
    {

		/*
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRoleWisePermission(object[] data)
        {
            IEnumerable<SP_GET_ROLE_WISE_PERMISSION> roleWisePermission = null;
            bool IsPermitted = false;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                roleWisePermission = new MenuPZ().GetRoleWisePermission(objcmnParam.loggeduser, objcmnParam.PermissionCode);
                IsPermitted = roleWisePermission.Count() > 0 ? true : false;
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                IsPermitted,
                roleWisePermission
            });
        } */

		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetRoleWisePermission(object[] data)
		{
			string message = "";

			//message = "API CALL Start";
			//WriteServiceLog(message);
			IEnumerable <SP_GET_ROLE_WISE_PERMISSION> roleWisePermission = null;
			bool IsPermitted = false;
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

				roleWisePermission = new MenuPZ().GetRoleWisePermission(objcmnParam.loggeduser, objcmnParam.PermissionCode);
				IsPermitted = roleWisePermission.Count() > 0 ? true : false;
			}
			catch (Exception e)
			{
				e.ToString();

				message = "ERROR: " +e.Message.ToString();
				ExcelHelper.WriteServiceLog(message);
			}

			//message = "API CALL END";
			ExcelHelper.WriteServiceLog(message);

			return Json(new
			{
				IsPermitted,
				roleWisePermission
			});
		}



		[HttpPost, ApiAuthorization]
        public IHttpActionResult GetPermissions(object[] data)
        {
            IEnumerable<SP_GET_PERMISSION> permissionList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                permissionList = new MenuPZ().GetPermissions(objcmnParam.RoleId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                permissionList
            });
        }

        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveUpdatePermissions(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                List<Permission> permissions = JsonConvert.DeserializeObject<List<Permission>>(data[1].ToString());

                if (permissions != null)
                {
                    decimal SavedId = 0;
                    foreach (Permission permission in permissions)
                    {
                         decimal IsActive = 0;
                         IsActive = permission.IS_ACTIVE == true ? 1 : 0;
                         SavedId = new MenuPZ().SaveUpdatePermissions(permission.ID, objcmnParam.RoleId, IsActive, objcmnParam.loggeduser);
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
