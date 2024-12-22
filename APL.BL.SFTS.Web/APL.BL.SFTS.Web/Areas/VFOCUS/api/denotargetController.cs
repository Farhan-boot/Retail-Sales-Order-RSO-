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
using System.Data;
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
	[RoutePrefix("VFocus/api/denotarget")]
	public class denotargetController : ApiController
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
				insertedId = new B2C_UPLOAD_FILEPZ().SAVE_VFOCUS_DENO_TARGET("D");
				insertedId = new B2C_UPLOAD_FILEPZ().SAVE_VFOCUS_DENO_TARGET("I");

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
			IEnumerable<GET_VFOCUS_DENO_TARGET> TargetList = null;

			int recordsTotal = 0;
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

				TargetList = new B2C_UPLOAD_FILEPZ().GET_VFOCUS_DENO_TARGET( "", "");
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
			List<GET_VFOCUS_DENO_TARGET> targetFile = null;
			targetFile = new B2C_UPLOAD_FILEPZ().GET_VFOCUS_DENO_TARGET( "", "");
			string ROSCODE = targetFile[0].ROSCODE.ToString();

			string targetForStaff = "";
			string fileName = "DENO_TARGET.xlsx";



			fileName = string.Concat(fileName);
			string directory = HttpContext.Current.Server.MapPath("~/UserFiles/VFOCUS/DENO_TARGET/");
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

		public string GenerateRSOTargetExcel(List<GET_VFOCUS_DENO_TARGET> targetFile, string filePath)
		{
			string result = "";
			using (ExcelPackage pck = new ExcelPackage())
			{
				//Create the worksheet 
				ExcelWorksheet ws = pck.Workbook.Worksheets.Add("StaffTarget");
				ws.Cells[1, 1].Value = "SL";
				ws.Cells[1, 2].Value = "RSO_CODE";
				ws.Cells[1, 2].Value = "DENO_ID";
				ws.Cells[1, 4].Value = "TARGET_COUNT";
				ws.Cells[1, 5].Value = "DENO_AMOUNT";
				ws.Cells[1, 6].Value = "START_DATE";
				ws.Cells[1, 7].Value = "END_DATE";



				for (int i = 0; i < targetFile.Count(); i++)
				{
					ws.Cells[i + 2, 1].Value = i + 1;
					ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).ROSCODE;
					ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).DENO_ID;
					ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).TARGET_COUNT;
					ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).DENO_AMOUNT;
					ws.Cells[i + 2, 6].Value = targetFile.ElementAt(i).DATE_START;
					ws.Cells[i + 2, 7].Value = targetFile.ElementAt(i).DATE_END;


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

				string directory = HttpContext.Current.Server.MapPath("~/UserFiles/VFOCUS/DENO_TARGET");
				//string directory = HttpContext.Current.Server.MapPath("~/UserFiles/RSO_SALARY");
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

					tfcv = ExcelForDATAUpload(filePath, uploadID, UPLOADBY);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return tfcv;
		}

		public string GetIsValidData(string RSO_ID, string DENO_ID, string DATE1, string DATE2) // RSO_ID, DENO_ID, DATE1, DATE2
		{
			string UploadedDDCode = "1";
			List<ISVALID_DENO_TARGET> _CODEList = null;

			try
			{
			_CODEList = new B2C_UPLOAD_FILEPZ().ISVALID_CAMP_DATA_DENO(RSO_ID, DENO_ID, DATE1, DATE2);
				UploadedDDCode = _CODEList[0].VALID_CODE.ToString();
			}
			catch (Exception e)
			{
				e.ToString();
			}

			return UploadedDDCode;
		}

		public vmVFOCUS_UPLOAD ExcelForDATAUpload(string fileName, decimal uploadCode, decimal UPLOADBY) // CHECK TO TEST
		{
			//string directory = HttpContext.Current.Server.MapPath("~/UserFiles/VFOCUS/DENO_TARGET");
			//FileInfo file = new FileInfo(Path.Combine(directory, fileName));

			string fileExtension = Path.GetExtension(fileName);
			DataTable dtExcelRecords = new DataTable();
			dtExcelRecords = ExcelHelper.ReadExcelSheet(fileName, fileExtension, "Yes");
			
			int savedRowCount = 1;
			//decimal totalTargetValue = 0;
			//string TargetForCode = "0";
			vmVFOCUS_UPLOAD tfcv = new vmVFOCUS_UPLOAD();
			tfcv.IsInvalidCode = true;
			tfcv.InvalidCode = "0";
			string rowNo2 = "";
			decimal rowNum = 0;

			try
			{

				string RSO_ID = "";
				string DENO_ID = "";
				decimal TARGET_COUNT = 0;
				decimal DENO_AMOUNT = 0;
				string DATE1 = "";
				string DATE2 = "";
				string DATE_S = "";
				decimal _UPLOADBY = UPLOADBY;
				//string ISACTIVE = "";
				string UPLOAD_BATCHID = "ABCD_" + uploadCode.ToString();
				string STRMODE = "D";

				decimal SaveResult = new B2C_UPLOAD_FILEPZ().SAVE_VFOCUS_DENO_TARGET_TEMP(RSO_ID, DENO_ID, TARGET_COUNT, DENO_AMOUNT, DATE1, DATE2, _UPLOADBY, STRMODE);

				List<vmVFOCUS_UPLOAD> ListOfData = new List<vmVFOCUS_UPLOAD>();

				foreach (DataRow data in dtExcelRecords.Rows)
				{
					if (data[1].ToString().Length > 0)
					{
						RSO_ID = data[0].ToString();
						DENO_ID = data[1].ToString();
						TARGET_COUNT = Convert.ToDecimal(data[2].ToString());
						DENO_AMOUNT = Convert.ToDecimal(data[3].ToString());

						DATE_S = data[4].ToString();
						DATE1 = DateTime.Parse(DATE_S).ToString("dd-MMM-yy");

						DATE_S = data[5].ToString();
						DATE2 = DateTime.Parse(DATE_S).ToString("dd-MMM-yy");


						tfcv.InvalidCode = GetIsValidData(RSO_ID, DENO_ID, DATE1, DATE2);

						if (tfcv.InvalidCode != "0")
						{
							SaveResult = -1;
							savedRowCount++;
							SaveResult = new B2C_UPLOAD_FILEPZ().SAVE_VFOCUS_DENO_TARGET_TEMP(RSO_ID, DENO_ID, TARGET_COUNT, DENO_AMOUNT, DATE1, DATE2, _UPLOADBY, "I");
							decimal isSaved = SaveResult;
							tfcv.IsInvalidCode = false;
							tfcv.InvalidCode = "";
						}
						else
						{
							tfcv.IsInvalidCode = true;
							tfcv.InvalidCode = "USER CODE:" + RSO_ID + "  Deno : " + DENO_ID + " is Duplicate in excel file or Deno target is already exist or User code is invalid ";
							tfcv.RowNo = rowNum.ToString();

							break;
						}

					}
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


		//public vmVFOCUS_UPLOAD ExcelForDATAUpload_OLD(string fileName, decimal uploadCode, decimal UPLOADBY) // CHECK TO TEST
		//{
		//	string directory = HttpContext.Current.Server.MapPath("~/UserFiles/VFOCUS/DENO_TARGET");
		//	FileInfo file = new FileInfo(Path.Combine(directory, fileName));

		//	int savedRowCount = 1;
		//	decimal totalTargetValue = 0;
		//	string TargetForCode = "0";
		//	vmVFOCUS_UPLOAD tfcv = new vmVFOCUS_UPLOAD();
		//	tfcv.IsInvalidCode = true;
		//	tfcv.InvalidCode = "0";

		//	try
		//	{
				
		//		string RSO_ID = "";
		//		string DENO_ID = "";
		//		decimal TARGET_COUNT = 0;
		//		decimal DENO_AMOUNT = 0;
		//		DateTime DATE1 = DateTime.Now;
		//		DateTime DATE2 = DateTime.Now;
		//		decimal _UPLOADBY = UPLOADBY;
		//		string ISACTIVE = "";
		//		string UPLOAD_BATCHID = "ABCD_" + uploadCode.ToString();
		//		string STRMODE = "D";

		//		decimal SaveResult = new B2C_UPLOAD_FILEPZ().SAVE_VFOCUS_DENO_TARGET_TEMP(RSO_ID, DENO_ID, TARGET_COUNT, DENO_AMOUNT, DATE1, DATE2, _UPLOADBY, STRMODE);


		//		using (ExcelPackage package = new ExcelPackage(file))
		//		{
		//			ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
		//			int totalRows = workSheet.Dimension.Rows;
		//			int totalCols = workSheet.Dimension.Columns;

		//			List<int> columnsToRead = new List<int>();
		//			for (int i = 1; i <= totalCols; i++)
		//			{
		//				columnsToRead.Add(i);
		//			}

		//			for (int j = 2; j <= totalRows; j++)
		//			{
		//				List<int> rowsToRead = new List<int>();
		//				rowsToRead.Add(j);
		//				foreach (int c in columnsToRead)
		//				{
		//					foreach (int r in rowsToRead)
		//					{
		//						List<string> columnValue = new List<string>();

		//						if (workSheet.Cells[r, c].Value == null)
		//						{
		//							string x = "";
		//							columnValue.Add(x);
		//						}
		//						else
		//						{
		//							columnValue.Add(workSheet.Cells[r, c].Value.ToString());
		//						}

		//						if (columnValue[0].ToString().Length > 0)
		//						{
		//							switch (c)
		//							{
		//								case 1:
		//									RSO_ID = columnValue[0].ToString();
		//									break;
		//								case 2:
		//									DENO_ID = columnValue[0].ToString();
		//									break;

		//								case 3:
		//									TARGET_COUNT = Convert.ToDecimal(columnValue[0].ToString());
		//									break;

		//								case 4:
		//									DENO_AMOUNT = Convert.ToDecimal(columnValue[0].ToString());
		//									break;

		//								case 5:
		//									DATE1 = Convert.ToDateTime(columnValue[0].ToString());
		//									break;

		//								case 6:
		//									DATE2 = Convert.ToDateTime(columnValue[0].ToString());
		//									break;


		//							}


		//						}

									



		//					}
		//					if (j > totalRows)
		//					{
		//						break;
		//					}
		//				}

		//				tfcv.InvalidCode = GetIsValidData(RSO_ID, DENO_ID, DATE1, DATE2);

		//				if (tfcv.InvalidCode != "0")
		//				{
		//					SaveResult = -1;
		//					savedRowCount++;
		//					SaveResult = new B2C_UPLOAD_FILEPZ().SAVE_VFOCUS_DENO_TARGET_TEMP(RSO_ID, DENO_ID, TARGET_COUNT, DENO_AMOUNT, DATE1, DATE2, _UPLOADBY,  "I");
		//					decimal isSaved = SaveResult;
		//					tfcv.IsInvalidCode = false;
		//					tfcv.InvalidCode = "";
		//				}
		//				else
		//				{
		//					tfcv.IsInvalidCode = true;
		//					tfcv.InvalidCode = RSO_ID + ' ' + DENO_ID;

		//					break;
		//				}
		//			}

		//			package.Dispose();
		//		}

		//	}
		//	catch (Exception e)
		//	{
		//		string p = e.Message;
		//	}
		//	finally
		//	{
		//	}

		//	return tfcv;
		//}


		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetUploadedExcelData(object[] data)  // Check for working
		{
			List<GET_VFOCUS_DENO_TARGET> FileDataList = null;

			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				FileDataList = new B2C_UPLOAD_FILEPZ().GET_VFOCUS_DENO_TARGET_TEMP("", "");
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
				_ACTIVITYNAME = "Deno targe upload  " + message + ": insert new";
				_ACTIONTYPE = "UPLOAD";
			}
			else
			{
				_ACTIVITYNAME = "Deno targe upload " + message + ": updated";
				_ACTIONTYPE = "UPLOAD";
			}
			string _CHANGEDVALUE = "";

			string _USERIPHOSTNAME = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() + " - " +
				System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			decimal saveID = new ApplicationLogPZ().INSERT_APPLICATION_ACCESSLOG(_USERID, _APPLICATIONNAME, _MODULENAME, _ACTIVITYNAME, _CHANGEDVALUE, _USERIPHOSTNAME, _ACTIONTYPE);

		}


	}
}