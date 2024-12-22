
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
	[RoutePrefix("VFocus/api/GraphInfo")]
	public class GraphInfoController : ApiController
	{
		[HttpPost, ApiAuthorization]
		public HttpResponseMessage SaveGraphInfo(object[] data)
		{
			string result = "";
			try
			{
				VfocusGraphInfo graphInfo = JsonConvert.DeserializeObject<VfocusGraphInfo>(data[1].ToString());
				if (graphInfo.GraphId > 0)
				{
					graphInfo.isdelete = (graphInfo.StrMode == "D") ? "Y" : "N"; 
					decimal UpdateResult = new GraphInfoPZ().SaveGraphInfo(graphInfo.GraphId, graphInfo.GraphCode, graphInfo.GraphName, graphInfo.Detail, graphInfo.CreatedBy, graphInfo.CreatedBy, graphInfo.isdelete, graphInfo.StrMode);
					result = UpdateResult > 0 ? UpdateResult.ToString() : result;

					SaveChangeLog(false, graphInfo.GraphCode, graphInfo.CreatedBy);
				}
				else
				{
					decimal SaveResult = new GraphInfoPZ().SaveGraphInfo(0, graphInfo.GraphCode, graphInfo.GraphName, graphInfo.Detail, graphInfo.CreatedBy, graphInfo.CreatedBy, "N", "I");
					result = SaveResult > 0 ? SaveResult.ToString() : result;

					SaveChangeLog(true, graphInfo.GraphCode, graphInfo.CreatedBy);

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
        public IHttpActionResult GetAllGraphInfo(object[] data)
        {
            vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
			List<SP_FF_SAVE_VFOCUS_GRAPH_INFO> graphInfoList = new List<SP_FF_SAVE_VFOCUS_GRAPH_INFO>();
            int curPage = -1;
            var currentPage = curPage == -1 ? objcmnParam.pageNumber : 0;
            int recordsTotal = 0;
            try
            {
                graphInfoList = new GraphInfoPZ().GetAllGraphInfoList(0, null, null);
               // graphInfoList = graphInfoList.OrderByDescending(sur => sur.GRAPH_ID).ToList();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                recordsTotal,
                graphInfoList
            });
        }



		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetKpiList(object[] data)
		{
			IEnumerable<VFOCUS_KPI_INFO> objListKPIItem = null;
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				objListKPIItem = new GraphInfoPZ().GetAllKPIList(objcmnParam.KPIID);
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				objListKPIItem
			});
		}



		private void SaveChangeLog(bool _isNEW, string message, decimal changeBy)
		{			
			string _ACTIVITYNAME = "";
			string _ACTIONTYPE = "";
			decimal _USERID = changeBy;
			string _APPLICATIONNAME = "RSO APP Web";
			string _MODULENAME = "Vfocus";
			if (_isNEW) {
				_ACTIVITYNAME = "Graph code " + message + ": insert new";
				_ACTIONTYPE = "INSERT";
			}
			else
			{
				_ACTIVITYNAME = "Graph code " + message + ": updated";
				_ACTIONTYPE = "UPDATE";
			}				
			string _CHANGEDVALUE = "";

			//string _USERIPHOSTNAME = Request. + "-" + Dns.GetHostEntry(Request.UserHostAddress;).HostName.ToString();

			string _USERIPHOSTNAME = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString()+" - "+
				System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			decimal saveID = new ApplicationLogPZ().INSERT_APPLICATION_ACCESSLOG(_USERID, _APPLICATIONNAME, _MODULENAME, _ACTIVITYNAME, _CHANGEDVALUE, _USERIPHOSTNAME, _ACTIONTYPE);
			//ApplicationLogPZ.INSERT_APPLICATION_ACCESSLOG(_USERID, _APPLICATIONNAME, _MODULENAME, _ACTIVITYNAME, _CHANGEDVALUE, _USERIPHOSTNAME, _ACTIONTYPE);
		}


	}
}
