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


namespace APL.BL.SFTS.Web.Areas.SFTS.api
{
	[RoutePrefix("SFTS/api/RsoSalary")]
	public class RsoSalaryController : ApiController
	{
		// GET: SFTS/RsoSalary
		//public ActionResult Index()
		//{
		//    return View();
		//}
		
		public static decimal uploadID { get; set; }
		public static decimal UPLOADBY { get; set; }

		[HttpPost, ApiAuthorization]
		public HttpResponseMessage SaveSalary(object[] data)
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



				//if (objTargetSetup.Id == 0) { objTargetSetup.Id = new GetNewIdDZ().GetNewId("FF_RSO_EARNING_SALAY_SEQ"); }

				//if (objTargetSetup != null)
				//{
				//	decimal insertedId = 0;
				//	insertedId = new RsoSalaryPZ().SaveUpdateSalary(objTargetSetup.UploadCode);

				//	result = insertedId > 0 ? insertedId.ToString() : result;
				//}
				//else
				//{
				//	result = "";
				//}
			}
			catch (Exception e)
			{
				e.ToString();
				result = "";
			}
			return Request.CreateResponse(HttpStatusCode.OK, result);
		}


		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetAllSalary(object[] data)
		{
			IEnumerable<SP_GET_FF_RSO_EARNING_SALARY> TargetList = null;

			int recordsTotal = 0;
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

				TargetList = new RsoSalaryPZ().GetRsoSalary(1,1);
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

		public HttpResponseMessage ExportSalaryExcel(object[] data)
		{
			TargetFileExport targetFileExport = JsonConvert.DeserializeObject<TargetFileExport>(data[0].ToString());
			List<SP_GET_FF_RSO_EARNING_SALAY_FILE> targetFile = null;
			targetFile = new RsoSalaryPZ().GetSalaryData(2, targetFileExport.TargetPeriodId);
			string monthCode = targetFile[0].SALAY_YEAR_MONTH;
			
			string targetForStaff = "";
			string fileName = "";
			


			fileName = string.Concat(fileName);
			string directory = HttpContext.Current.Server.MapPath("~/UserFiles/RSO_SALARY/");
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

			// HttpResponseMessage result = null;
			// result = Request.CreateResponse(HttpStatusCode.OK);
			// result.Content = new StreamContent(new FileStream(path, FileMode.Open));
			//result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
			// result.Content.Headers.ContentDisposition.FileName = fileName;

			return Request.CreateResponse(HttpStatusCode.OK, fileName);
		}

		public string GenerateRSOTargetExcel(List<SP_GET_FF_RSO_EARNING_SALAY_FILE> targetFile, string filePath)
		{
			string result = "";
			using (ExcelPackage pck = new ExcelPackage())
			{
				//Create the worksheet 
				ExcelWorksheet ws = pck.Workbook.Worksheets.Add("StaffTarget");

				ws.Cells[1, 1].Value = "SL No.";
				ws.Cells[1, 2].Value = "Salary Month year";
				ws.Cells[1, 3].Value = "RS0 Code";
				ws.Cells[1, 4].Value = "Bank Name";
				ws.Cells[1, 5].Value = "Bank A/C";
				ws.Cells[1, 6].Value = "Date of Birth";
				ws.Cells[1, 7].Value = "Joining Date";
				ws.Cells[1, 8].Value = "Working Days";
				ws.Cells[1, 9].Value = "Total Payable Salary";
				ws.Cells[1, 10].Value = "Vendor";
				ws.Cells[1, 11].Value = "Status";
				

				for (int i = 0; i < targetFile.Count(); i++)
				{
					ws.Cells[i + 2, 1].Value = i + 1;
					ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).ROSCODE;
					ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).BANK_NAME;
					ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).BANK_AC;
					ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).DOB;
					ws.Cells[i + 2, 6].Value = targetFile.ElementAt(i).JOIN_DATE;
					ws.Cells[i + 2, 7].Value = targetFile.ElementAt(i).WORKING_DAY;
					ws.Cells[i + 2, 8].Value = targetFile.ElementAt(i).SALAY_YEAR_MONTH;
					ws.Cells[i + 2, 9].Value = targetFile.ElementAt(i).TOTAL_SALARY;
					ws.Cells[i + 2, 10].Value = targetFile.ElementAt(i).VENDOR;
					ws.Cells[i + 2, 11].Value = targetFile.ElementAt(i).STATUS;
					
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
		public decimal GetUploadCode(object[] data)
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
		public RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION SaveUpdateSalaryExcel()
		{
			RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION tfcv = new RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION();
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
				
				string directory = HttpContext.Current.Server.MapPath("~/UserFiles/RSO_SALARY");
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

				if (hpf.ContentLength > 0  && uploadID > 0)
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

		public string GetIsValidSalaryFor( string TargetForCode, string SALAY_YEAR_MONTH)
		{
			string UploadedTargetForCode = "0";
			List<ISVALID_SALARY_FOR> SalaryForCodeList = null;

			try
			{
				SalaryForCodeList = new RsoSalaryPZ().GetIsValidSalaryFor( TargetForCode, SALAY_YEAR_MONTH);
				UploadedTargetForCode = SalaryForCodeList[0].VALID_SALARY_FOR_CODE;
			}
			catch (Exception e)
			{
				e.ToString();
			}

			return UploadedTargetForCode;
		}

		public RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION ExcelForRsoSalaryUpload(string fileName, decimal uploadCode, decimal UPLOADBY)
		{
			string directory = HttpContext.Current.Server.MapPath("~/UserFiles/RSO_SALARY");
			FileInfo file = new FileInfo(Path.Combine(directory, fileName));

			int savedRowCount = 1;
			decimal totalTargetValue = 0;
			string TargetForCode = "0";
			RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION tfcv = new RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION();
			tfcv.IsInvalidCode = true;
			tfcv.InvalidCode = "0";

			try
			{
				string rowNo = "";
				string monthCode = "";
				string ROSCODE = "";
				string BANK_NAME = "";
				string BANK_AC = "";
				string DOB = "";
				string DOB_S = "";
				string JOIN_DATE = "";
				string JOIN_DATE_S = "";
				string WORKING_DAY = "";
				decimal WORKING_DAY_D = 0; ;
				string SALAY_YEAR_MONTH = "";
				string TOTAL_SALARY = "";
				decimal TOTAL_SALARY_D = 0; ;
				string VENDOR = "";
				decimal VENDOR_D = 0;
				string STATUS = "";

				decimal SaveResult = new RsoSalaryPZ().UploadRSOSalary(-1, ROSCODE, BANK_NAME, BANK_AC, DOB_S, JOIN_DATE_S, WORKING_DAY_D, SALAY_YEAR_MONTH, TOTAL_SALARY_D, VENDOR, STATUS, UPLOADBY);


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

								switch (c)
								{
									case 1:
										rowNo = columnValue[0].ToString();
										break;
									case 2:
										SALAY_YEAR_MONTH = columnValue[0].ToString();
										break;

									case 3:
										ROSCODE = columnValue[0].ToString();
										//tfcv.RowNo = r.ToString();
										//tfcv.ColumnNo = c.ToString();
										break;

									case 4:
										BANK_NAME = columnValue[0].ToString();
										//tfcv.RowNo = r.ToString();
										//tfcv.ColumnNo = c.ToString();
										break;

									case 5:
										BANK_AC = columnValue[0].ToString();
										//tfcv.RowNo = r.ToString();
										//tfcv.ColumnNo = c.ToString();
										break;

									case 6:
										DOB = columnValue[0].ToString();
										DOB_S = DateTime.Parse(DOB).ToString("dd-MMM-yy");
										//tfcv.RowNo = r.ToString();
										//tfcv.ColumnNo = c.ToString();
										break;

									case 7:
										JOIN_DATE = columnValue[0].ToString();
										JOIN_DATE_S = DateTime.Parse(JOIN_DATE).ToString("dd-MMM-yy");
										//tfcv.RowNo = r.ToString();
										//tfcv.ColumnNo = c.ToString();
										break;

									case 8:
										WORKING_DAY = columnValue[0].ToString();
										WORKING_DAY_D = Convert.ToDecimal(WORKING_DAY);
										//tfcv.RowNo = r.ToString();
										//tfcv.ColumnNo = c.ToString();
										break;
																			

									case 9:
										TOTAL_SALARY = columnValue[0].ToString();
										TOTAL_SALARY_D = Convert.ToDecimal(TOTAL_SALARY);
										//tfcv.RowNo = r.ToString();
										//tfcv.ColumnNo = c.ToString();
										break;

									case 10:
										VENDOR = columnValue[0].ToString();
										VENDOR_D = Convert.ToDecimal(VENDOR);
										//tfcv.RowNo = r.ToString();
										//tfcv.ColumnNo = c.ToString();
										break;

									case 11:
										STATUS = columnValue[0].ToString();
										tfcv.RowNo = r.ToString();
										tfcv.ColumnNo = c.ToString();
										break;
								}
								


							}
							if (j > totalRows)
							{
								break;
							}
						}

						tfcv.InvalidCode = GetIsValidSalaryFor(ROSCODE, SALAY_YEAR_MONTH);

						if (tfcv.InvalidCode != "0")
						{
							SaveResult = -1;
							savedRowCount++;
							 SaveResult = new RsoSalaryPZ().UploadRSOSalary(uploadCode, ROSCODE, BANK_NAME, BANK_AC, DOB_S, JOIN_DATE_S, WORKING_DAY_D, SALAY_YEAR_MONTH, TOTAL_SALARY_D, VENDOR, STATUS, UPLOADBY);
							decimal isSaved = SaveResult;
							tfcv.IsInvalidCode = false;
							tfcv.InvalidCode = "";
						}
						else
						{
							tfcv.IsInvalidCode = true;
							tfcv.InvalidCode = ROSCODE +  ' '+ SALAY_YEAR_MONTH;
							
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
		public IHttpActionResult GetUploadedExcelData(object[] data)
		{
			List<SP_GET_FF_RSO_EARNING_SALAY_FILE> FileDataList = null;

			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				FileDataList = new RsoSalaryPZ().GetUploadedSalaryFileDataFile(objcmnParam.UploadCode);
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



		public decimal GetCurUserID(string authorizedToken)
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
	}
}