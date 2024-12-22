using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.Models.SFTS;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.Web.Areas.HelpPage;
using APL.BL.SFTS.Web.Providers;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APL.BL.SFTS.Web.Areas.VFOCUS.api
{

	[RoutePrefix("VFocus/api/Vfoucusdataupload")]
	public class VfoucusdatauploadController : ApiController
	{

		public static decimal uploadID { get; set; }
		public static decimal UPLOADBY { get; set; }



		[HttpPost, ApiAuthorization]
		public HttpResponseMessage SaveData(object[] data)
		{
			string result = "";
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				vmSalaryupload objTargetSetup = JsonConvert.DeserializeObject<vmSalaryupload>(data[1].ToString());
				//objTargetSetup.SetDate = DateTime.Now;

				decimal insertedId = 0;
				insertedId = new RsoSalaryPZ().SaveUpdateSalary(objTargetSetup.UploadCode);

				result = insertedId > 0 ? insertedId.ToString() : result;

				
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