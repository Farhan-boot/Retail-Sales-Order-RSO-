
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
	[RoutePrefix("VFocus/api/graphkpi")]
	public class graphkpiController : ApiController
	{
		[HttpPost, ApiAuthorization]
		public HttpResponseMessage SaveGraphKpi(object[] data)
		{
			string result = "";
			int output = 0;
			try
			{
				VfocusGraphKPI VfocusGraphKPI = JsonConvert.DeserializeObject<VfocusGraphKPI>(data[0].ToString());
				VfocusGraphKPIMAP GraphKPIMAP = JsonConvert.DeserializeObject<VfocusGraphKPIMAP>(data[1].ToString());
				if (GraphKPIMAP.AssingGraph.Count > 0)
				{
					decimal UpdateResult = new GraphInfoPZ().SaveGraphKPI( 0, VfocusGraphKPI.KPI_KEY, 0,  "D");
					result = UpdateResult > 0 ? UpdateResult.ToString() : result;
					SaveChangeLog(false, VfocusGraphKPI.KPI_KEY.ToString(), VfocusGraphKPI.CreatedBy);

					if (Convert.ToInt16(result) >= 0)
					{
						foreach (AssingGraph asg in GraphKPIMAP.AssingGraph)
						{
							decimal SaveResult = new GraphInfoPZ().SaveGraphKPI(asg.GRAPH_ID, VfocusGraphKPI.KPI_KEY, VfocusGraphKPI.CreatedBy,  "I");
							result = SaveResult > 0 ? SaveResult.ToString() : result;

							SaveChangeLog(true, VfocusGraphKPI.KPI_KEY.ToString() + " - "+ VfocusGraphKPI.GRAPH_ID, VfocusGraphKPI.CreatedBy);
						}

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
		public IHttpActionResult GetAllGraphKpi(object[] data)
		{
			vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
			List<VFOCUS_GRAPH_VS_KPI> graphKPIList = new List<VFOCUS_GRAPH_VS_KPI>();
			int curPage = -1;
			var currentPage = curPage == -1 ? objcmnParam.pageNumber : 0;
			int recordsTotal = 0;
			try
			{
				graphKPIList = new GraphInfoPZ().GetAllGraphKPIList(0, 0);
				// graphInfoList = graphInfoList.OrderByDescending(sur => sur.GRAPH_ID).ToList();
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				recordsTotal,
				graphKPIList
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
				_ACTIVITYNAME = "Graph KPI " + message + ": insert new";
				_ACTIONTYPE = "INSERT";
			}
			else
			{
				_ACTIVITYNAME = "Graph KPI " + message + ": updated";
				_ACTIONTYPE = "UPDATE";
			}
			string _CHANGEDVALUE = "";

			//string _USERIPHOSTNAME = Request. + "-" + Dns.GetHostEntry(Request.UserHostAddress;).HostName.ToString();

			string _USERIPHOSTNAME = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() + " - " +
				System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			decimal saveID = new ApplicationLogPZ().INSERT_APPLICATION_ACCESSLOG(_USERID, _APPLICATIONNAME, _MODULENAME, _ACTIVITYNAME, _CHANGEDVALUE, _USERIPHOSTNAME, _ACTIONTYPE);
			//ApplicationLogPZ.INSERT_APPLICATION_ACCESSLOG(_USERID, _APPLICATIONNAME, _MODULENAME, _ACTIVITYNAME, _CHANGEDVALUE, _USERIPHOSTNAME, _ACTIONTYPE);
		}




	}
}