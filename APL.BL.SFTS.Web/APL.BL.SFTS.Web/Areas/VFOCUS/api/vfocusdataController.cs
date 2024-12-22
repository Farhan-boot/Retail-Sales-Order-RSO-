using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.Models.SFTS;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.Models.VFOCUS;
using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.ProcessZone.VFocus;
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
	[RoutePrefix("VFocus/api/vfocusdata")]
	public class vfocusdataController : ApiController
	{
		// GET: SFTS/RsoSalary
		//public ActionResult Index()
		//{
		//    return View();
		//}

		public static decimal uploadID { get; set; }
		public static decimal UPLOADBY { get; set; }

		[HttpPost, ApiAuthorization]
		public HttpResponseMessage SaveData(object[] data)
		{
			string result = "";
			string _MESSAGE = "";
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				vmSalaryupload objTargetSetup = JsonConvert.DeserializeObject<vmSalaryupload>(data[1].ToString());
				//objTargetSetup.SetDate = DateTime.Now;

				decimal insertedId = 0;
				//insertedId = new B2C_UPLOAD_FILEPZ().SAVE_VFOCUS_DENO_TARGET("D");
				insertedId = new B2C_UPLOAD_FILEPZ().SAVE_B2CSCAPPTARGETPROCESS();

				result = insertedId > 0 ? insertedId.ToString() : result;

				SaveChangeLog(true, _MESSAGE, objcmnParam.loggeduser);

			}
			catch (Exception e)
			{
				e.ToString();
				result = "";
			}
			return Request.CreateResponse(HttpStatusCode.OK, result);
		}


		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetAllData(object[] data)
		{
			IEnumerable<GET_B2CSCAPPTARGETPROCESS> TargetList = null;

			int recordsTotal = 0;
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

				TargetList = new B2C_UPLOAD_FILEPZ().GET_B2CSCAPPTARGETPROCESS();
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				recordsTotal,
				TargetList
			});
		}

		#region Export Excel

		public HttpResponseMessage ExportExcelData(object[] data)  // Check to work
		{
			TargetFileExport targetFileExport = JsonConvert.DeserializeObject<TargetFileExport>(data[0].ToString());
			List<GET_B2CSCAPPTARGETPROCESS> targetFile = null;
			targetFile = new B2C_UPLOAD_FILEPZ().GET_B2CSCAPPTARGETPROCESS();
			string DD_CODE = targetFile[0].DD_CODE.ToString();

			string targetForStaff = "";
			string fileName = "SALES_TARGET.xlsx";



			fileName = string.Concat(fileName);
			string directory = HttpContext.Current.Server.MapPath("~/UserFiles/VFOCUS/SALES_DATA/");
			string filePath = directory + fileName;

			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}

			if (System.IO.File.Exists(filePath))
			{
				System.IO.File.Delete(filePath);
			}
			GenerateSALESgetExcel(targetFile, filePath);



			return Request.CreateResponse(HttpStatusCode.OK, fileName);
		}

		public string GenerateSALESgetExcel(List<GET_B2CSCAPPTARGETPROCESS> targetFile, string filePath)
		{
			string result = "";
			using (ExcelPackage pck = new ExcelPackage())
			{
				//Create the worksheet 
				ExcelWorksheet ws = pck.Workbook.Worksheets.Add("StaffTarget");

				ws.Cells[1, 1].Value = "TARGET_DATE";
				ws.Cells[1, 2].Value = "REGION";
				ws.Cells[1, 3].Value = "DD_CODE";
				ws.Cells[1, 4].Value = "DD_NAME";
				ws.Cells[1, 5].Value = "RP_SIM";
				ws.Cells[1, 6].Value = "RP_EV";

				ws.Cells[1, 7].Value = "GA";
				ws.Cells[1, 8].Value = "DS_EV";
				ws.Cells[1, 9].Value = "DS_SC";
				ws.Cells[1, 10].Value = "TOTAL_DS";
				ws.Cells[1, 11].Value = "RECH_SC";
				ws.Cells[1, 12].Value = "RECH_EV";
				ws.Cells[1, 13].Value = "TOTAL_RECH";



				for (int i = 0; i < targetFile.Count(); i++)
				{
					ws.Cells[i + 2, 1].Value = i + 1;
					ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).TARGET_DATE;
					ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).REGION;
					ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).DD_CODE;
					ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).DD_NAME;
					ws.Cells[i + 2, 6].Value = targetFile.ElementAt(i).RP_SIM;
					ws.Cells[i + 2, 7].Value = targetFile.ElementAt(i).RP_EV;
			
					ws.Cells[i + 2, 8].Value = targetFile.ElementAt(i).GA;
					ws.Cells[i + 2, 9].Value = targetFile.ElementAt(i).DS_EV;
					ws.Cells[i + 2, 10].Value = targetFile.ElementAt(i).DS_SC;
					ws.Cells[i + 2, 11].Value = targetFile.ElementAt(i).TOTAL_DS;

					ws.Cells[i + 2, 11].Value = targetFile.ElementAt(i).RECH_SC;
					ws.Cells[i + 2, 12].Value = targetFile.ElementAt(i).RECH_EV;
					ws.Cells[i + 2, 13].Value = targetFile.ElementAt(i).TOTAL_RECH;


				}

				

				pck.SaveAs(new FileInfo(filePath));
			}
			return result;
		}



		#endregion

		#region Excel File Upload

		[HttpPost, ApiAuthorization]
		public decimal GetUploadCode(object[] data) // Check to work
		{
			decimal uploadCode = 0;
			try
			{
				//HttpContext.Current.Session["uploadID"] = "";
				fileCmnParameters objcmnParam = JsonConvert.DeserializeObject<fileCmnParameters>(data[0].ToString());
				uploadCode = new GetNewIdDZ().GetNewId("SQ_FF_UPLOAD_CODE");
				//HttpContext.Current.Session["uploadID"] = uploadCode.ToString();
				uploadID = uploadCode;
				UPLOADBY = GetCurUserID(objcmnParam.HeaderToken.AuthorizedToken.ToString());


			}
			catch (Exception e)
			{
				e.ToString();
			}
			return uploadCode;
		}

		[System.Web.Http.AcceptVerbs("GET", "POST")]
		[HttpPost]
		public vmVFOCUS_UPLOAD SaveUploadDataExcel() // Check to work
		{
			vmVFOCUS_UPLOAD tfcv = new vmVFOCUS_UPLOAD();
			try
			{
				// DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
				string filePath = "";
				decimal uploadCode = 0;
				//decimal applyType = 0;
				//decimal applySubType = 0;
				tfcv.InvalidCode = "0";
				tfcv.IsInvalidCode = true;
				//decimal UPLOADBY = 100789; // SessionHelper.GetCurUserID(); // Convert.ToDecimal(HttpContext.Current.Session["CurUserID"].ToString());

				string directory = HttpContext.Current.Server.MapPath("~/UserFiles/VFOCUS/SALES_DATA");
				string fileDir = directory + "/";

				if (!Directory.Exists(directory))
				{
					Directory.CreateDirectory(directory);
				}

				System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
				string upCode = System.Web.HttpContext.Current.Request.Params["uploadCode"].ToString();
				//string aplyType = System.Web.HttpContext.Current.Request.Params["applyType"];
				//string aplySubType = System.Web.HttpContext.Current.Request.Params["applySubType"];
				uploadCode = Convert.ToDecimal(upCode);
				//applyType = Convert.ToDecimal(aplyType);
				//applySubType = Convert.ToDecimal(aplySubType);



				System.Web.HttpPostedFile hpf = hfc[0];

				if (hpf.ContentLength > 0 && uploadID > 0)
				{
					string fileName = "";
					filePath = fileDir + Path.GetFileName(hpf.FileName);
					// CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
					if (System.IO.File.Exists(filePath))
					{
						System.IO.File.Delete(filePath);
					}

					if (!File.Exists(filePath))
					{
						//string exttension = System.IO.Path.GetExtension(hpf.FileName);
						fileName = System.IO.Path.GetFileName(hpf.FileName);
						hpf.SaveAs(filePath);
						hpf.InputStream.Dispose();
					}

					tfcv = ExcelForDATAUpload(fileName, uploadID, UPLOADBY);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return tfcv;
		}

		public string GetIsValidData(string DD_CODE) // RSO_ID, DENO_ID, DATE1, DATE2
		{
			string UploadedDDCode = "0";
			List<ISVALID_DD_CODE> _CODEList = null;

			try
			{
				_CODEList = new B2C_UPLOAD_FILEPZ().ISVALID_DD_CODE_SALES(DD_CODE);
				UploadedDDCode = (_CODEList.Count > 0) ? _CODEList[0].VALID_DD_CODE.ToString() : "0";
			}
			catch (Exception e)
			{
				e.ToString();
			}

			return UploadedDDCode;
		}

		public vmVFOCUS_UPLOAD ExcelForDATAUpload(string fileName, decimal uploadCode, decimal UPLOADBY) // CHECK TO TEST
		{
			string directory = HttpContext.Current.Server.MapPath("~/UserFiles/VFOCUS/SALES_DATA");
			FileInfo file = new FileInfo(Path.Combine(directory, fileName));

			int savedRowCount = 1;
			//decimal totalTargetValue = 0;
			//string TargetForCode = "0";
			vmVFOCUS_UPLOAD tfcv = new vmVFOCUS_UPLOAD();
			tfcv.IsInvalidCode = true;
			tfcv.InvalidCode = "0";

			try
			{
				
				DateTime TARGET_DATE = DateTime.Now;
				string REGION = "";
				string DD_CODE = "";
				string DD_NAME = "";
				Decimal RP_SIM = 0;
				Decimal RP_EV = 0;
				decimal GA = 0;
				Decimal DS_EV = 0;
				decimal DS_SC = 0;
				decimal TOTAL_DS = 0;
				Decimal RECH_SC = 0;
				decimal RECH_EV = 0;
				Decimal TOTAL_RECH = 0;				
				string STRMODE = "D";

				decimal SaveResult = new B2C_UPLOAD_FILEPZ().SAVE_SALESTARGET_UPLOAD_TEMP(TARGET_DATE, REGION, DD_CODE, DD_NAME, RP_SIM, RP_EV, GA, DS_EV, DS_SC, TOTAL_DS, RECH_SC, RECH_EV, TOTAL_RECH, STRMODE);


				using (ExcelPackage package = new ExcelPackage(file))
				{
					ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
					int totalRows = workSheet.Dimension.Rows;
					int totalCols = workSheet.Dimension.Columns;

					List<int> columnsToRead = new List<int>();
					for (int i = 1; i <= totalCols; i++)
					{
						columnsToRead.Add(i);
					}

					for (int j = 2; j <= totalRows; j++)
					{
						List<int> rowsToRead = new List<int>();
						rowsToRead.Add(j);
						foreach (int c in columnsToRead)
						{
							foreach (int r in rowsToRead)
							{
								List<string> columnValue = new List<string>();

								if (workSheet.Cells[r, c].Value == null)
								{
									string x = "";
									columnValue.Add(x);
								}
								else
								{
									columnValue.Add(workSheet.Cells[r, c].Value.ToString());
								}

								if (columnValue[0].ToString().Length > 0)
								{
									switch (c)
									{
										case 1:
											TARGET_DATE = Convert.ToDateTime(columnValue[0].ToString());
											break;
										case 2:
											REGION = columnValue[0].ToString();
											break;

										case 3:
											DD_CODE = columnValue[0].ToString();
											break;

										case 4:
											DD_NAME = columnValue[0].ToString();
											break;

										case 5:
											try { RP_SIM = Convert.ToDecimal(columnValue[0].ToString()); }
											catch (Exception) { RP_SIM = 0; }

											break;

										case 6:
											try { RP_EV = Convert.ToDecimal(columnValue[0].ToString()); }
											catch (Exception) { RP_EV = 0; }
											//RP_EV = Convert.ToDecimal(columnValue[0].ToString());
											break;

										case 7:
											try { GA = Convert.ToDecimal(columnValue[0].ToString()); }
											catch (Exception) { GA = 0; }
											//GA = Convert.ToDecimal(columnValue[0].ToString());
											break;

										case 8:
											try { DS_EV = Convert.ToDecimal(columnValue[0].ToString()); }
											catch (Exception) { DS_EV = 0; }
											//DS_EV = Convert.ToDecimal(columnValue[0].ToString());
											break;

										case 9:
											try { DS_SC = Convert.ToDecimal(columnValue[0].ToString()); }
											catch (Exception) { DS_SC = 0; }
											//DS_SC = Convert.ToDecimal(columnValue[0].ToString());
											break;

										case 10:
											try { TOTAL_DS = Convert.ToDecimal(columnValue[0].ToString()); }
											catch (Exception) { TOTAL_DS = 0; }
											//TOTAL_DS = Convert.ToDecimal(columnValue[0].ToString());
											break;

										case 11:
											try { RECH_SC = Convert.ToDecimal(columnValue[0].ToString()); }
											catch (Exception) { RECH_SC = 0; }
											//RECH_SC = Convert.ToDecimal(columnValue[0].ToString());
											break;

										case 12:
											try { RECH_EV = Convert.ToDecimal(columnValue[0].ToString()); }
											catch (Exception) { RECH_EV = 0; }
											//RECH_EV = Convert.ToDecimal(columnValue[0].ToString());
											break;

										case 13:
											try { TOTAL_RECH = Convert.ToDecimal(columnValue[0].ToString()); }
											catch (Exception) { TOTAL_RECH = 0; }
											//TOTAL_RECH = Convert.ToDecimal(columnValue[0].ToString());
											break;


									}

								}

							}
							if (j > totalRows)
							{
								break;
							}
						}

						tfcv.InvalidCode = GetIsValidData(DD_CODE);

						if (tfcv.InvalidCode != "0")
						{
							SaveResult = -1;
							savedRowCount++;
							SaveResult = new B2C_UPLOAD_FILEPZ().SAVE_SALESTARGET_UPLOAD_TEMP(TARGET_DATE, REGION, DD_CODE, DD_NAME, RP_SIM, RP_EV, GA, DS_EV, DS_SC, TOTAL_DS, RECH_SC, RECH_EV, TOTAL_RECH, "I");
							decimal isSaved = SaveResult;
							tfcv.IsInvalidCode = false;
							tfcv.InvalidCode = "";
						}
						else
						{
							tfcv.IsInvalidCode = true;
							tfcv.InvalidCode = " DD Code: "+DD_CODE+" is duplicate or invalid" ;

							break;
						}
					}

					package.Dispose();
				}

			}
			catch (Exception e)
			{
				string p = e.Message;
			}
			finally
			{
			}

			return tfcv;
		}


		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetUploadedExcelData(object[] data)  // Check for working
		{
			List<GET_B2CSCAPPTARGETPROCESS> FileDataList = null;

			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				FileDataList = new B2C_UPLOAD_FILEPZ().GET_B2CSCAPPTARGETPROCESS();
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				FileDataList
			});
		}

		#endregion



		public decimal GetCurUserID(string authorizedToken) // Check to work
		{

			try
			{

				if (authorizedToken != null)
				{
					string[] parts = authorizedToken.Split(new char[] { ':' });
					if (parts.Length == 3)
					{
						return Convert.ToDecimal(parts[0]);
						//userName = parts[1];
						//authorizedToken = parts[2];
					}
					else { return 0; }
				}
				else { return 0; }
			}
			catch (Exception ex)
			{
				return 0;
			}

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
				_ACTIVITYNAME = "Sales target upload  " + message + ": insert new";
				_ACTIONTYPE = "UPLOAD";
			}
			else
			{
				_ACTIVITYNAME = "Sales target upload " + message + ": updated";
				_ACTIONTYPE = "UPLOAD";
			}
			string _CHANGEDVALUE = "";

			string _USERIPHOSTNAME = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() + " - " +
				System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			decimal saveID = new ApplicationLogPZ().INSERT_APPLICATION_ACCESSLOG(_USERID, _APPLICATIONNAME, _MODULENAME, _ACTIVITYNAME, _CHANGEDVALUE, _USERIPHOSTNAME, _ACTIONTYPE);

		}
	}
}