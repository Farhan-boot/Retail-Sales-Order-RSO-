
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
	[RoutePrefix("VFocus/api/Kpideshboard")]
	public class KpideshboardController : ApiController
	{
		[HttpPost, ApiAuthorization]
		public HttpResponseMessage SaveKpiDashboard(object[] data)
		{
			string result = "";
			string _MESSAGE = "";
			try
			{
				VfocusKPIDASHBOARD graphKPI = JsonConvert.DeserializeObject<VfocusKPIDASHBOARD>(data[1].ToString());
				if (graphKPI.KPI_KEY1 == graphKPI.KPI_KEY2)
				{
					_MESSAGE = graphKPI.KPI_KEY1.ToString() + " is duplicate mapping ";
				}
				if (graphKPI.KPI_KEY1 == graphKPI.KPI_KEY3)
				{
					_MESSAGE = graphKPI.KPI_KEY1.ToString() + " is duplicate mapping ";
				}

				if (graphKPI.KPI_KEY2 == graphKPI.KPI_KEY3)
				{
					_MESSAGE = graphKPI.KPI_KEY2.ToString() + " is duplicate mapping ";
				}
				else
				{
					if (graphKPI.KPI_KEY1 > 0 && graphKPI.GRAPH_ID1 > 0)
					{
						decimal UpdateResult = new GraphInfoPZ().SaveKPI_Dashboard(graphKPI.ID, graphKPI.KPI_KEY1, graphKPI.GRAPH_ID1, graphKPI.KPI_KEY2, graphKPI.GRAPH_ID2, graphKPI.KPI_KEY3, graphKPI.GRAPH_ID3, graphKPI.LASTUPDATE_BY, "D");
						SaveChangeLog(false, _MESSAGE, graphKPI.CreatedBy);

						decimal SaveResult = new GraphInfoPZ().SaveKPI_Dashboard(graphKPI.ID, graphKPI.KPI_KEY1, graphKPI.GRAPH_ID1, graphKPI.KPI_KEY2, graphKPI.GRAPH_ID2, graphKPI.KPI_KEY3, graphKPI.GRAPH_ID3, graphKPI.CreatedBy, "I");
						result = SaveResult > 0 ? SaveResult.ToString() : result;

						_MESSAGE = graphKPI.KPI_KEY1.ToString() + " : " + graphKPI.GRAPH_ID1.ToString() + " - " + graphKPI.KPI_KEY2.ToString() + " : " + graphKPI.GRAPH_ID2.ToString() + " - " + graphKPI.KPI_KEY3.ToString() + " : " + graphKPI.GRAPH_ID3.ToString();

						SaveChangeLog(true, _MESSAGE, graphKPI.LASTUPDATE_BY);

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
		public IHttpActionResult GetAllKPIDashboardList(object[] data)
		{
			vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
			List<VFOCUS_KPI_DASHBOARD> KPIDashboardList = new List<VFOCUS_KPI_DASHBOARD>();
			int curPage = -1;
			var currentPage = curPage == -1 ? objcmnParam.pageNumber : 0;
			int recordsTotal = 0;
			try
			{
				KPIDashboardList = new GraphInfoPZ().GetAllKPIDashboardList(0, 0, 0);
				// graphInfoList = graphInfoList.OrderByDescending(sur => sur.GRAPH_ID).ToList();
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				recordsTotal,
				KPIDashboardList
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
				_ACTIVITYNAME = "KPI Dashboard " + message + ": insert new";
				_ACTIONTYPE = "INSERT";
			}
			else
			{
				_ACTIVITYNAME = "KPI Dashboard " + message + ": updated";
				_ACTIONTYPE = "UPDATE";
			}
			string _CHANGEDVALUE = "";

			//string _USERIPHOSTNAME = Request. + "-" + Dns.GetHostEntry(Request.UserHostAddress;).HostName.ToString();

			string _USERIPHOSTNAME = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() + " - " +
				System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			decimal saveID = new ApplicationLogPZ().INSERT_APPLICATION_ACCESSLOG(_USERID, _APPLICATIONNAME, _MODULENAME, _ACTIVITYNAME, _CHANGEDVALUE, _USERIPHOSTNAME, _ACTIONTYPE);
			//return saveID;
			//ApplicationLogPZ.INSERT_APPLICATION_ACCESSLOG(_USERID, _APPLICATIONNAME, _MODULENAME, _ACTIVITYNAME, _CHANGEDVALUE, _USERIPHOSTNAME, _ACTIONTYPE);
		}
	}
}