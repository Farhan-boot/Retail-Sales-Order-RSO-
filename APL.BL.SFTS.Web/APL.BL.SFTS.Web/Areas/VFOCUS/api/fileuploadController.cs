using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
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
using System.Configuration;
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

	[RoutePrefix("VFocus/api/fileupload")]
	public class fileuploadController : ApiController
	{
		[HttpPost, ApiAuthorization]
		public HttpResponseMessage SaveUpdateCurrentOffer(object[] data)
		{
			string result = "";
			//string fileFormat = "";
			//String[] _FILEFORMAT = null;
			bool isValidFormat = false;
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				ViewableFileinfo fileInfo = JsonConvert.DeserializeObject<ViewableFileinfo>(data[1].ToString());
				List<FILE_UPLOAD_ID> currentOfferDistList = JsonConvert.DeserializeObject<List<FILE_UPLOAD_ID>>(data[2].ToString());

				IEnumerable<VFOCUS_API_CALL> ASSCC_KEY = null;

				ASSCC_KEY = new  B2C_UPLOAD_FILEPZ().GET_VFOCUS_BTS_KPI_USER(fileInfo.uploadBy, 0);
				string isactive = (fileInfo.IsActive == 1) ? "Y" : "N";
				if (ASSCC_KEY.Count() > 0)
				{
					if (fileInfo != null && fileInfo.STRMODE == "I")
					{
						if (fileInfo.fileID == 0) { fileInfo.fileID = new GetNewIdDZ().GetNewId("FF_VFOCUS_FILE_UPLOAD_SEQ"); }

						/*	fileFormat  = Path.GetExtension(fileInfo.fileName);


							if (fileInfo.fileFormat == 1)
							{
								_FILEFORMAT = ConfigurationManager.AppSettings.Get("_IMGFORMAT").ToString().Split(',');

								isValidFormat = Array.Exists(_FILEFORMAT, x => x == fileFormat); 
							}
							else if (fileInfo.fileFormat == 2)
							{
								_FILEFORMAT = ConfigurationManager.AppSettings.Get("_VIDEOFORMAT").ToString().Split(',');

								isValidFormat = Array.Exists(_FILEFORMAT, x => x == fileFormat);
							}
							else if (fileInfo.fileFormat == 3)
							{
								_FILEFORMAT = ConfigurationManager.AppSettings.Get("_AUDIOFORMAT").ToString().Split(',');

								isValidFormat = Array.Exists(_FILEFORMAT, x => x == fileFormat);
							}
							else if (fileInfo.fileFormat == 4)
							{
								_FILEFORMAT = ConfigurationManager.AppSettings.Get("_PDFFORMAT").ToString().Split(',');

								isValidFormat = Array.Exists(_FILEFORMAT, x => x == fileFormat);
							}
							else if (fileInfo.fileFormat == 5)
							{
								_FILEFORMAT = ConfigurationManager.AppSettings.Get("_WORDFORMAT").ToString().Split(',');

								isValidFormat = Array.Exists(_FILEFORMAT, x => x == fileFormat);
							}
							else if (fileInfo.fileFormat == 6)
							{
								_FILEFORMAT = ConfigurationManager.AppSettings.Get("_EXCELFORMAT").ToString().Split(',');

								isValidFormat = Array.Exists(_FILEFORMAT, x => x == fileFormat);
							}
							*/

						//isValidFormat = isVALID_FORMAT(fileInfo.fileFormat);

						if (isValidFormat)
						{
							Decimal SavedOfferId = new B2C_UPLOAD_FILEPZ().SP_FF_SAVE_FILE_UPLOAD(fileInfo.fileID, fileInfo.fileName, fileInfo.fileDetail, fileInfo.fileCategory, fileInfo.fileFormat, fileInfo.fileLink, isactive, fileInfo.uploadBy, fileInfo.STRMODE);

							result = SavedOfferId > 0 ? SavedOfferId.ToString() : "";

						}
						else
						{
							result = "-2";
						}
						
					}
					else if (fileInfo.STRMODE == "D")
					{
						Decimal SavedOfferId = new B2C_UPLOAD_FILEPZ().SP_FF_SAVE_FILE_UPLOAD(fileInfo.fileID, fileInfo.fileName, fileInfo.fileDetail, fileInfo.fileCategory, fileInfo.fileFormat, fileInfo.fileLink, isactive, fileInfo.uploadBy, fileInfo.STRMODE);
						result = SavedOfferId > 0 ? SavedOfferId.ToString() : "";
					}
					else
					{
						result = "";
					}

				}
				else
				{
					result = "-1";
				}
			}
			catch (Exception e)
			{
				e.ToString();
				result = "";
			}
			return Request.CreateResponse(HttpStatusCode.OK, result);
		}

		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetAllFILE(object[] data)
		{
			IEnumerable<SP_FF_GET_FILE_UPLOAD_INFO> UPLOAD_INFO = null;

			try
			{
				ViewableFileinfo objcmnParam = JsonConvert.DeserializeObject<ViewableFileinfo>(data[0].ToString());

				UPLOAD_INFO = new B2C_UPLOAD_FILEPZ().SP_FF_GET_FILE_UPLOAD_INFO(objcmnParam.fileID,  objcmnParam.fileCategory, objcmnParam.fileFormat);
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				UPLOAD_INFO
			});
		}


		/*
		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetCurrentOfferDist(object[] data)
		{
			IEnumerable<SP_GET_ALL_DISTRIBUTOR> currentOfferDist = null;

			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

				currentOfferDist = new CurrentOfferPZ().GetCurrentOfferDistributor(objcmnParam.CurrentOfferId);
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				currentOfferDist
			});
		}
		*/

		[HttpPost]
		public void SaveUpdatePictures()
		{
			string result = "";
			try
			{
				int iUploadedCnt = 0;

				string directory = HttpContext.Current.Server.MapPath("~/UserFiles/VFOCUS/FILE_UPLOAD");
				string fileDir = directory + "/";

				if (!Directory.Exists(directory))
				{
					Directory.CreateDirectory(directory);
				}

				System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
				string Id = System.Web.HttpContext.Current.Request.Params["CurrentOfferId"];
				decimal CurrentOfferId = Convert.ToDecimal(Id);
				string filePath = "";

				// CHECK THE FILE COUNT.
				for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
				{
					System.Web.HttpPostedFile hpf = hfc[iCnt];

					if (hpf.ContentLength > 0)
					{
						string fileName = "";
						int PicSlNo = iCnt + 1;
						fileName = System.IO.Path.GetFileName(hpf.FileName);
						filePath = fileDir + fileName;
						// CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
						if (!File.Exists(filePath))
						{
							//string exttension = System.IO.Path.GetExtension(hpf.FileName);
							hpf.SaveAs(filePath);

							iUploadedCnt = iUploadedCnt + 1;
							hpf.InputStream.Dispose();
						}

						byte[] picture = File.ReadAllBytes(filePath); //decimal ID, Decimal FILEID, Decimal FILEID_SL_NO, byte[] Picture, Decimal UPLOADBY

						decimal PicturesSaveResult = new B2C_UPLOAD_FILEPZ().SaveUpdateOfferPictures(0, CurrentOfferId, PicSlNo, picture, 1);


						string _VFOCUS_FILE_UPLOAD_SERVER = ConfigurationManager.AppSettings.Get("_VFOCUS_FILE_UPLOAD_SERVER");

						string uploadPath = _VFOCUS_FILE_UPLOAD_SERVER + fileName;
						Decimal SavedFileId = new B2C_UPLOAD_FILEPZ().SP_FF_SAVE_FILE_UPLOAD(CurrentOfferId, "", "", 0, 0, uploadPath, "", 0, "U");

						result = SavedFileId > 0 ? SavedFileId.ToString() : "";

						CALL_VFOCUS_API(CurrentOfferId);
						
					}
				}

				//return Request.CreateResponse(HttpStatusCode.OK, result);
			}
			catch (Exception ex)
			{
				result = ex.Message.ToString();
				//return Request.CreateResponse(HttpStatusCode.Forbidden, result);
			}
			


		}


		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetvfocusFile(object[] data)
		{
			List<GET_VFOCUS_FILES> getOfferPicture = null;
			ViewableFileinfo objcmnParam = JsonConvert.DeserializeObject<ViewableFileinfo>(data[0].ToString());

			try
			{
				//getOfferPicture = new VisitPlanPZ().GetCurrentOfferPictures(0, objcmnParam.fileID, 0);

				getOfferPicture = new B2C_UPLOAD_FILEPZ().SP_FF_GET_VFOUS_FILE_LIST(0, objcmnParam.fileID, 0);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return Json(new
			{
				getOfferPicture
			});
		}

		[HttpPost, ApiAuthorization]
		public HttpResponseMessage DeletePicture(object[] data)
		{
			//SP_FF_OFFER_PICTURES
			string result = "";
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

				decimal ResultId = new CurrentOfferPZ().DeletePicture(objcmnParam.PictureId);
				result = ResultId > 0 ? ResultId.ToString() : "";
			}
			catch (Exception e)
			{
				e.ToString();
				result = "";
			}
			return Request.CreateResponse(HttpStatusCode.OK, result);
		}


		[HttpPost]
		public void UploadRetailerOfferExcel()
		{
			int iUploadedCnt = 0;

			// DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
			string sPath = "";

			string documentPath = "C:\\excel_dir\\";
			var directory = documentPath;
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}

			System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
			System.Web.HttpPostedFile hpf = hfc[0];
			if (hpf.ContentLength > 0)
			{
				string excelFilePath = "";
				string fileName = "";
				// CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
				if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
				{
					string exttension = System.IO.Path.GetExtension(hpf.FileName);
					fileName = System.IO.Path.GetFileName(hpf.FileName);
					excelFilePath = directory + fileName;
					hpf.SaveAs(excelFilePath);

					iUploadedCnt = iUploadedCnt + 1;
					hpf.InputStream.Dispose();
				}

				ExcelForRetailerOffer(excelFilePath);
			}
		}

		public void ExcelForRetailerOffer(string filePaht)
		{
			decimal uploadCode = 0;
			int savedRowCount = 1;
			decimal totalTargetValue = 0;
			if (uploadCode == 0) { uploadCode = new GetNewIdDZ().GetNewId("SQ_FF_UPLOAD_CODE"); }

			Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
			try
			{
				if (System.IO.File.Exists(filePaht))
				{
					System.IO.File.Delete(filePaht);
				}

				Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePaht);
				Microsoft.Office.Interop.Excel.Worksheet xlSheet = xlWorkbook.Sheets[1]; // get first sheet
				Microsoft.Office.Interop.Excel.Range xlRange = xlSheet.UsedRange; // get the entire used range
				int numberOfRows = xlRange.Rows.Count;
				int numberOfCols = xlRange.Columns.Count;

				string rowNo = "";
				string monthCode = "";
				string itemCode = "";
				string distributorCode = "";
				string targetValue = "";
				decimal decTargetValue = 0;
				//decimal applyType = 1;
				//decimal log = 1;

				List<int> columnsToRead = new List<int>();
				for (int i = 1; i <= numberOfCols; i++)
				{
					columnsToRead.Add(i);
				}

				for (int j = 2; j <= numberOfRows; j++)
				{
					List<int> rowsToRead = new List<int>();
					rowsToRead.Add(j);
					foreach (int c in columnsToRead)
					{
						foreach (int r in rowsToRead)
						{
							List<string> columnValue = new List<string>();

							if (xlRange.Cells[r, c].Value2 == null)
							{
								string x = "";
								x = (xlRange.Cells[r, c].Value2) = "";
								columnValue.Add(x);
							}
							else
							{
								columnValue.Add(xlRange.Cells[r, c].Value2.ToString());
							}
							if (columnValue[0].ToString().Length > 0)
							{

								switch (c)
								{
									case 1:
										rowNo = columnValue[0].ToString();
										break;
									case 2:
										monthCode = columnValue[0].ToString();
										break;
									case 3:
										itemCode = columnValue[0].ToString();
										break;
									case 4:
										distributorCode = columnValue[0].ToString();
										break;
									case 5:
										targetValue = columnValue[0].ToString();
										decTargetValue = Convert.ToDecimal(targetValue);
										totalTargetValue = totalTargetValue + decTargetValue;
										break;
								}

							}
						}
						if (j > numberOfRows)
						{
							break;
						}
					}

				//	tfcv.InvalidCode = GetIsValidData(DD_CODE, CAMP_NAME);

					savedRowCount++;
					 // decimal SaveResult = new TargetSetupPZ().UploadTargetDetail(uploadCode, monthCode, itemCode, distributorCode, decTargetValue, applyType, log);
					//  decimal isSaved = SaveResult;
				}

				xlWorkbook.Close(true, Type.Missing, Type.Missing);
				xlApp.Workbooks.Close();

			}
			catch (Exception e)
			{
				string p = e.Message;
			}
			finally
			{
				KillExcel(xlApp);
				System.Threading.Thread.Sleep(100);
			}
		}

		[DllImport("User32.dll")]
		public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int ProcessId);
		private static void KillExcel(Microsoft.Office.Interop.Excel.Application theApp)
		{
			int id = 0;
			IntPtr intptr = new IntPtr(theApp.Hwnd);
			System.Diagnostics.Process p = null;
			try
			{
				GetWindowThreadProcessId(intptr, out id);
				p = System.Diagnostics.Process.GetProcessById(id);
				if (p != null)
				{
					p.Kill();
					p.Dispose();
				}
			}
			catch (Exception ex)
			{
				string s = ex.Message;
			}
		}


		public void CALL_VFOCUS_API(decimal uploadID)
		{

			IEnumerable<VFOCUS_API_CALL> API_CALL_INFO = null;
			API_CALL_INFO = new B2C_UPLOAD_FILEPZ().GET_VFOCUS_BTS_KPI_USER(0, uploadID);
			string _VFOCUS_CALL_API = ConfigurationManager.AppSettings.Get("_VFOCUS_CALL_API");

			try
			{
				using (var client = new HttpClient())
				{
					string _MSISDN = "";
					string _ACCESSKEY = "";
					string _FILE_NAME = "";
					string _FILE_INFO = "";
					string _CATEGORY_NAME = "";
					string _FORMAT_NAME = "";
					foreach (VFOCUS_API_CALL fileInfo in API_CALL_INFO)
					{
						_MSISDN = (string.IsNullOrEmpty(fileInfo.MSISDN)) ? "" : fileInfo.MSISDN.ToString().Trim();
						_ACCESSKEY = (string.IsNullOrEmpty(fileInfo.ACCESSKEY)) ? "" : fileInfo.ACCESSKEY.ToString().Trim();
						_FILE_NAME = (string.IsNullOrEmpty(fileInfo.FILE_NAME)) ? "" : fileInfo.FILE_NAME.ToString().Trim();
						_FILE_INFO = (string.IsNullOrEmpty(fileInfo.FILE_INFO)) ? "" : fileInfo.FILE_INFO.ToString().Trim();
						_CATEGORY_NAME = (string.IsNullOrEmpty(fileInfo.CATEGORY_NAME)) ? "" : fileInfo.CATEGORY_NAME.ToString().Trim();
						_FORMAT_NAME = (string.IsNullOrEmpty(fileInfo.FORMAT_NAME)) ? "" : fileInfo.FORMAT_NAME.ToString().Trim();

					}


					client.BaseAddress = new Uri(_VFOCUS_CALL_API);
					client.DefaultRequestHeaders.Add("MSISDN", String.Format(_MSISDN));
					client.DefaultRequestHeaders.Add("ACCESSKEY", String.Format(_ACCESSKEY));
					client.DefaultRequestHeaders.Add("TITLE", String.Format(_FILE_NAME));
					client.DefaultRequestHeaders.Add("ShortDescription", String.Format(_FILE_INFO));
					client.DefaultRequestHeaders.Add("Category", String.Format(_CATEGORY_NAME));
					client.DefaultRequestHeaders.Add("UserName", String.Format(_FORMAT_NAME));

					var response = client.PostAsync("vFocus/api/AppPost/SendNotification", null).Result;
					if (response.IsSuccessStatusCode)
					{
						string result = response.Content.ReadAsStringAsync().Result;
						Console.Write("Success");
					}
					else
						Console.Write("Error");
				}
			}
			catch (Exception ex)
			{

				throw;
			}


		}

		public bool isVALID_FORMAT(Int32 formatID)
		{
			//bool result = false;
			String[] _FILEFORMAT = null;
			bool isValidFormat = false;
			string fileName = "";
			string fileFormat = "";

			System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
			for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
			{
				System.Web.HttpPostedFile hpf = hfc[iCnt];
				if (hpf.ContentLength > 0)
				{
					fileName = System.IO.Path.GetFileName(hpf.FileName);

					//fileFormat = Path.GetExtension(fileName);
					//_FILEFORMAT = ConfigurationManager.AppSettings.Get("_EXCELFORMAT").ToString().Split(',');
					//isValidFormat = Array.Exists(_FILEFORMAT, x => x == fileFormat);

				}

				fileFormat = Path.GetExtension(fileName);


				if (formatID == 1)
				{
					_FILEFORMAT = ConfigurationManager.AppSettings.Get("_IMGFORMAT").ToString().Split(',');

					isValidFormat = Array.Exists(_FILEFORMAT, x => x == fileFormat);
				}
				else if (formatID == 2)
				{
					_FILEFORMAT = ConfigurationManager.AppSettings.Get("_VIDEOFORMAT").ToString().Split(',');

					isValidFormat = Array.Exists(_FILEFORMAT, x => x == fileFormat);
				}
				else if (formatID == 3)
				{
					_FILEFORMAT = ConfigurationManager.AppSettings.Get("_AUDIOFORMAT").ToString().Split(',');

					isValidFormat = Array.Exists(_FILEFORMAT, x => x == fileFormat);
				}
				else if (formatID == 4)
				{
					_FILEFORMAT = ConfigurationManager.AppSettings.Get("_PDFFORMAT").ToString().Split(',');

					isValidFormat = Array.Exists(_FILEFORMAT, x => x == fileFormat);
				}
				else if (formatID == 5)
				{
					_FILEFORMAT = ConfigurationManager.AppSettings.Get("_WORDFORMAT").ToString().Split(',');

					isValidFormat = Array.Exists(_FILEFORMAT, x => x == fileFormat);
				}
				else if (formatID == 6)
				{
					_FILEFORMAT = ConfigurationManager.AppSettings.Get("_EXCELFORMAT").ToString().Split(',');

					isValidFormat = Array.Exists(_FILEFORMAT, x => x == fileFormat);
				}




			}

			return isValidFormat;
		}


		


	}
}