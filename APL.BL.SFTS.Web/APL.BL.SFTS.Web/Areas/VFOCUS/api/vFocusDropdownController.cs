using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.ProcessZone.Target;
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
    [RoutePrefix("VFOCUS/api/vFocusDropdown")]
    public class vFocusDropdownController : ApiController
    {

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



		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetKpigraphList(object[] data)
		{
			IEnumerable<VFOCUS_GRAPH_VS_KPI> objListGRAPHKPI = null;
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				objListGRAPHKPI = new GraphInfoPZ().GetAllGraphKPIList(0,  objcmnParam.KPIID);
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				objListGRAPHKPI
			});
		}


		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetAllAssignUnAssignGraph(object[] data)
		{
			IEnumerable<VFOCUS_ASS_UNASS_GRAPH> objListUNASSGRAPH = null;
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				objListUNASSGRAPH = new GraphInfoPZ().GetAllAssignUnAssignGraph(objcmnParam.KPIID);
				//objListUNASSGRAPH = new GraphInfoPZ().GetAllAssignUnAssignGraph(0);
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				objListUNASSGRAPH
			});
		}



		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetAllAssignUnAssignDENO(object[] data)
		{
			IEnumerable<VFOCUS_DENO> objListUNASSDENO = null;
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				objListUNASSDENO = new GraphInfoPZ().MAPUNMAP_DENO(0);
				//objListUNASSGRAPH = new GraphInfoPZ().GetAllAssignUnAssignGraph(0);
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				objListUNASSDENO
			});
		}



		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetAllFileCategory(object[] data)
		{
			IEnumerable<GET_VFOCUS_FILE_CATEGORY> objListCATEGORY = null;
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				objListCATEGORY = new B2C_UPLOAD_FILEPZ().GET_VFOCUS_FILE_CATEGORY(0);
				//objListUNASSGRAPH = new GraphInfoPZ().GetAllAssignUnAssignGraph(0);
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				objListCATEGORY
			});
		}


		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetAllFileFormat(object[] data)
		{
			IEnumerable<GET_VFOCUS_FILE_FORMAT> objListFORMAT = null;
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				objListFORMAT = new B2C_UPLOAD_FILEPZ().GET_VFOCUS_FILE_FORMAT(0);
				//objListUNASSGRAPH = new GraphInfoPZ().GetAllAssignUnAssignGraph(0);
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				objListFORMAT
			});
		}








	}
}
