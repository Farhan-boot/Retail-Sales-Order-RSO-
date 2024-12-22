
using APL.BL.SFTS.DataBridgeZone.Vfocus;
using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.Models.VFOCUS;
using APL.BL.SFTS.ProcessZone.VFocus;
using APL.BL.SFTS.Web.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APL.BL.SFTS.Web.Areas.VFOCUS.api
{
	[RoutePrefix("VFocus/api/denomapping")]
	public class DenomappingController : ApiController
	{
		[HttpPost, ApiAuthorization]
		public HttpResponseMessage SaveDenomap(object[] data)
		{
			string result = "";
			string _MESSAGE = "";
			int output = 0;
			try
			{
				VfocusGraphKPI VfocusGraphKPI = JsonConvert.DeserializeObject<VfocusGraphKPI>(data[0].ToString());
				VfocusDENOLIST DENOMAP = JsonConvert.DeserializeObject<VfocusDENOLIST>(data[1].ToString());
				if (DENOMAP.AssingDENO.Count > 0)
				{
					decimal UpdateResult = new GraphInfoPZ().SaveDENO(0, 0, "D");
					SaveChangeLog(false, _MESSAGE, DENOMAP.LASTUPDATEBY);
					result = UpdateResult > 0 ? UpdateResult.ToString() : result;

					if (Convert.ToInt16(result) >= 0)
					{
						foreach (AssingDENO asg in DENOMAP.AssingDENO)
						{
							decimal SaveResult = new GraphInfoPZ().SaveDENO(asg.DENO_ID, DENOMAP.LASTUPDATEBY , "I");
							result = SaveResult > 0 ? SaveResult.ToString() : result;

							_MESSAGE = _MESSAGE +", "+ asg.DENO_ID.ToString();
						}

						SaveChangeLog(true, _MESSAGE, DENOMAP.LASTUPDATEBY);


					}

				}

			}
			catch (Exception ex)
			{
				result = "";
				string e = ex.ToString();
			}
			return Request.CreateResponse(HttpStatusCode.OK, result);
		}


		[HttpPost]
		public IHttpActionResult GetAllDenomap(object[] data)
		{
			vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
			List<VFOCUS_DENO>DENOList = new List<VFOCUS_DENO>();
			int curPage = -1;
			var currentPage = curPage == -1 ? objcmnParam.pageNumber : 0;
			int recordsTotal = 0;
			try
			{
				DENOList = new GraphInfoPZ().GetDENOALL(0);
				// graphInfoList = graphInfoList.OrderByDescending(sur => sur.GRAPH_ID).ToList();
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				recordsTotal,
				DENOList
			});
		}



		private void SaveChangeLog(bool _isNEW, string message, decimal changeBy)
		{
			string _ACTIVITYNAME = "";
			string _ACTIONTYPE = "";
			decimal _USERID = changeBy;
			string _APPLICATIONNAME = "RSO APP Web";
			string _MODULENAME = "Vfocus";
			if (_isNEW)
			{
				_ACTIVITYNAME = "Deno mapping  " + message + ": insert new";
				_ACTIONTYPE = "INSERT";
			}
			else
			{
				_ACTIVITYNAME = "Deno mapping " + message + ": updated";
				_ACTIONTYPE = "UPDATE";
			}
			string _CHANGEDVALUE = "";

			string _USERIPHOSTNAME = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() + " - " +
				System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			decimal saveID = new ApplicationLogPZ().INSERT_APPLICATION_ACCESSLOG(_USERID, _APPLICATIONNAME, _MODULENAME, _ACTIVITYNAME, _CHANGEDVALUE, _USERIPHOSTNAME, _ACTIONTYPE);
						
		}




	}
}