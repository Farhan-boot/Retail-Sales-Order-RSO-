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
	[RoutePrefix("VFocus/api/campdata")]
	public class campdataController : ApiController
	{
		
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
				vmVFOCUS_UPLOAD objFileUpload = JsonConvert.DeserializeObject<vmVFOCUS_UPLOAD>(data[1].ToString());
				//objTargetSetup.SetDate = DateTime.Now;

				decimal insertedId = 0;
				insertedId = new B2C_UPLOAD_FILEPZ().SP_FF_SAVE_CAMP_DATA(objFileUpload.Id, objFileUpload.UPLOAD_BATCHID, "D");
				insertedId = new B2C_UPLOAD_FILEPZ().SP_FF_SAVE_CAMP_DATA(objFileUpload.Id, objFileUpload.UPLOAD_BATCHID, "I");

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
			IEnumerable<SP_FF_GET_CAMP_DATA> TargetList = null;

			int recordsTotal = 0;
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

				TargetList = new B2C_UPLOAD_FILEPZ().SP_FF_GET_CAMP_DATA(0, "", "");
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
			List<SP_FF_GET_CAMP_DATA> targetFile = null;
			targetFile = new B2C_UPLOAD_FILEPZ().SP_FF_GET_CAMP_DATA(0,  "",  "");
			string CAMP_NAME = targetFile[0].CAMP_NAME.ToString();

			string targetForStaff = "";
			string fileName = "CAMP_DATA.xlsx";



			fileName = string.Concat(fileName);
			string directory = HttpContext.Current.Server.MapPath("~/UserFiles/VFOCUS/CAMP_DATA/");
			string filePath = directory + fileName;

			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}

			if (System.IO.File.Exists(filePath))
			{
				System.IO.File.Delete(filePath);
			}
			GenerateRSOTargetExcel(targetFile, filePath);

			

			return Request.CreateResponse(HttpStatusCode.OK, fileName);
		}

		public string GenerateRSOTargetExcel(List<SP_FF_GET_CAMP_DATA> targetFile, string filePath)
		{
			string result = "";
			using (ExcelPackage pck = new ExcelPackage())
			{
				//Create the worksheet 
				ExcelWorksheet ws = pck.Workbook.Worksheets.Add("StaffTarget");

				ws.Cells[1, 1].Value = "SL No.";
				ws.Cells[1, 2].Value = "DD_CODE";
				ws.Cells[1, 3].Value = "CAMP_NAME";
				ws.Cells[1, 4].Value = "TARGET";
				ws.Cells[1, 5].Value = "ACIEVEMENNTS";
				ws.Cells[1, 6].Value = "UPLOAD_DATE";
				


				for (int i = 0; i < targetFile.Count(); i++)
				{
					ws.Cells[i + 2, 1].Value = i + 1;
					ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).ID;
					ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).DD_CODE;
					ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).CAMP_NAME;
					ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).TARGET;
					ws.Cells[i + 2, 6].Value = targetFile.ElementAt(i).ACIEVEMENNTS;
					ws.Cells[i + 2, 7].Value = targetFile.ElementAt(i).UPLOAD_DATE;
					

				}

				//using (ExcelRange rng = ws.Cells["A1:A8"])
				//{
				//    rng.Style.Font.Bold = false;
				//    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
				//    rng.Style.Fill.BackgroundColor.SetColor(Color.DarkGray);  //Set color to DarkGray 
				//    rng.Style.Font.Color.SetColor(Color.Black);
				//}

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
		public Camp_data_upload SaveUploadDataExcel() // Check to work
		{
			Camp_data_upload tfcv = new Camp_data_upload();
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

				string directory = HttpContext.Current.Server.MapPath("~/UserFiles/VFOCUS/CAMP_DATA");
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

					tfcv = ExcelForRsoSalaryUpload(fileName, uploadID, UPLOADBY);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return tfcv;
		}

		public string GetIsValidData(string DD_CODE, string CAMP_NAME) // Check for working
		{
			string UploadedDDCode = "0";
			List<ISVALID_CAMP_DATA> DD_CODEList = null;

			try
			{
				DD_CODEList = new B2C_UPLOAD_FILEPZ().ISVALID_CAMP_DATA(DD_CODE, CAMP_NAME);
				UploadedDDCode = (DD_CODEList.Count > 0) ? DD_CODEList[0].VALID_DD_CODE.ToString() : "0";
			}
			catch (Exception e)
			{
				e.ToString();
			}

			return UploadedDDCode;
		}

		public Camp_data_upload ExcelForRsoSalaryUpload(string fileName, decimal uploadCode, decimal UPLOADBY) // CHECK TO TEST
		{
			string directory = HttpContext.Current.Server.MapPath("~/UserFiles/VFOCUS/CAMP_DATA");
			FileInfo file = new FileInfo(Path.Combine(directory, fileName));

			int savedRowCount = 1;
			decimal totalTargetValue = 0;
			string TargetForCode = "0";
			Camp_data_upload tfcv = new Camp_data_upload();
			tfcv.IsInvalidCode = true;
			tfcv.InvalidCode = "0";

			try
			{
				decimal ROW_COUNT = 0;
				string DD_CODE = "";
				string CAMP_NAME = "";
				decimal TARGET = 0;
				decimal ACIEVEMENNTS = 0;
				decimal _UPLOADBY = UPLOADBY;
				string ISACTIVE = "";
				string UPLOAD_BATCHID = "ABCD_"+uploadCode.ToString();
				string STRMODE = "D";

				decimal SaveResult = new B2C_UPLOAD_FILEPZ().SP_FF_SAVE_CAMP_DATA_TEMP(-1, DD_CODE, CAMP_NAME, TARGET, ACIEVEMENNTS, _UPLOADBY, ISACTIVE, UPLOAD_BATCHID, STRMODE);


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
											ROW_COUNT = Convert.ToDecimal(columnValue[0].ToString());
											break;
										case 2:
											DD_CODE = columnValue[0].ToString();
											break;

										case 3:
											CAMP_NAME = columnValue[0].ToString();
											break;

										case 4:
											TARGET = Convert.ToDecimal(columnValue[0].ToString());
											break;

										case 5:
											ACIEVEMENNTS = Convert.ToDecimal(columnValue[0].ToString());
											break;


									}


								}
							}
							if (j > totalRows)
							{
								break;
							}
						}

						tfcv.InvalidCode = GetIsValidData(DD_CODE, CAMP_NAME);

						if (tfcv.InvalidCode != "0")
						{
							SaveResult = -1;
							savedRowCount++;
							SaveResult = new B2C_UPLOAD_FILEPZ().SP_FF_SAVE_CAMP_DATA_TEMP(uploadCode, DD_CODE, CAMP_NAME, TARGET, ACIEVEMENNTS, _UPLOADBY, ISACTIVE, UPLOAD_BATCHID, "I");
							decimal isSaved = SaveResult;
							tfcv.IsInvalidCode = false;
							tfcv.InvalidCode = "";
						}
						else
						{
							tfcv.IsInvalidCode = true;
							tfcv.InvalidCode = DD_CODE + ' ' + CAMP_NAME;

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
			List<SP_FF_GET_CAMP_DATA> FileDataList = null;

			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				FileDataList = new B2C_UPLOAD_FILEPZ().SP_FF_GET_CAMP_DATA_TEMP(objcmnParam.UploadCode);
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
				_ACTIVITYNAME = "Camp data upload  " + message + ": insert new";
				_ACTIONTYPE = "UPLOAD";
			}
			else
			{
				_ACTIVITYNAME = "Camp data upload " + message + ": updated";
				_ACTIONTYPE = "UPLOAD";
			}
			string _CHANGEDVALUE = "";

			string _USERIPHOSTNAME = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() + " - " +
				System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			decimal saveID = new ApplicationLogPZ().INSERT_APPLICATION_ACCESSLOG(_USERID, _APPLICATIONNAME, _MODULENAME, _ACTIVITYNAME, _CHANGEDVALUE, _USERIPHOSTNAME, _ACTIONTYPE);

		}



	}
}