﻿using APL.BL.SFTS.DataBridgeZone;
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

namespace APL.BL.SFTS.Web.Areas.SFTS.api
{

	[RoutePrefix("SFTS/api/RSOCommission")]
	public class RSOCommissionController : ApiController
    {

		public static decimal uploadID { get; set; }
		public static decimal UPLOADBY { get; set; }


		[HttpPost, ApiAuthorization]
		public HttpResponseMessage SaveData(object[] data)
		{
			string result = "";
			//string _MESSAGE = "";
			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				vmSalaryupload objFileUpload = JsonConvert.DeserializeObject<vmSalaryupload>(data[1].ToString());
				//objTargetSetup.SetDate = DateTime.Now;

				decimal insertedId = 0;
				insertedId = new RsoCommissionDZ().SaveUpdateCommission(objFileUpload.UploadCode);				
				result = insertedId > 0 ? insertedId.ToString() : result;
				
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
			IEnumerable<SP_GET_FF_RSO_EARNING_COMMISSION> FileDataList = null;

			int recordsTotal = 0;
			decimal periodtypeID = 0;
			decimal monthID = 0;

			try
			{
				RSOEarningParameters objcmnParam = JsonConvert.DeserializeObject<RSOEarningParameters>(data[0].ToString());
				periodtypeID = objcmnParam.periodtypeID;
				monthID = objcmnParam.monthID;
			}
			catch
			{
				periodtypeID = 0;
				monthID = 0;
			}
			try
			{
				FileDataList = new RsoCommissionPZ().GetRsoCOMMISSION(periodtypeID, monthID);
				recordsTotal = FileDataList.Count();
				/*
				if (periodtypeID > 0 && monthID > 0)
				{
					FileDataList = new RsoCommissionPZ().GetRsoCOMMISSION(periodtypeID, monthID);
				}
				else {
					recordsTotal = 1;
					FileDataList = new List<SP_GET_FF_RSO_EARNING_COMMISSION>();
				}
				*/
			}
			catch (Exception e)
			{
				e.ToString();
			}
			return Json(new
			{
				recordsTotal,
				FileDataList
			});
		}

		#region Export Excel
		public HttpResponseMessage ExportExcelData(object[] data)  // Check to work
		{
			RSOEarningParameters targetFileExport = JsonConvert.DeserializeObject<RSOEarningParameters>(data[0].ToString());
			string fileName = "RSO_FIX_COMMISSION_TEMPLATE.xlsx";
			string directory = HttpContext.Current.Server.MapPath("~/UserFiles/RSO_SALARY/");
			string filePath = "";
			string targetForStaff = "";

			if (targetFileExport.monthID > 0)
			{
				List<SP_GET_FF_RSO_EARNING_COMMISSION_FILE> targetFile = null;
				targetFile = new RsoCommissionPZ().GetRsoCOMMISSION_export(1, targetFileExport.monthID);
				if (targetFile.Count > 0)
				{
					fileName = "RSO_COMMISSION_" + targetFile[0].SALAY_YEAR_MONTH + ".xlsx";
				}
				else
				{
					fileName = "RSO_COMMISSION_TEMPLATE.xlsx";
				}
				fileName = string.Concat(fileName);
				filePath = directory + fileName;

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
			else
			{
				fileName = "RSO_FIX_COMMISSION_TEMPLATE.xlsx";
				directory = HttpContext.Current.Server.MapPath("~/UserFiles/RSO_SALARY/TEMPLATE/");
				filePath = directory + fileName;
				return Request.CreateResponse(HttpStatusCode.OK, fileName);
			}	



			
		}

		public string GenerateRSOTargetExcel(List<SP_GET_FF_RSO_EARNING_COMMISSION_FILE> targetFile, string filePath)
		{
			string result = "";
			using (ExcelPackage pck = new ExcelPackage())
			{
				//Create the worksheet 
				ExcelWorksheet ws = pck.Workbook.Worksheets.Add("StaffTarget");

				ws.Cells[1, 1].Value = "RS0 Code";
				ws.Cells[1, 2].Value = "Target";
				ws.Cells[1, 3].Value = "Achievement";
				ws.Cells[1, 4].Value = "Incentive";
				ws.Cells[1, 5].Value = "Salary Month year";
				ws.Cells[1, 6].Value = "Campaign Name";
				ws.Cells[1, 7].Value = "KPI";
				ws.Cells[1, 8].Value = "Bank Name";
				ws.Cells[1, 9].Value = "Bank A/C";
				ws.Cells[1, 10].Value = "Vendor";
				ws.Cells[1, 11].Value = "Status";


				for (int i = 0; i < targetFile.Count(); i++)
				{
					ws.Cells[i + 2, 1].Value = i + 1;
					ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).ROSCODE;
					ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).TARGET;
					ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).ACHIVEMENT;
					ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).INCENTIVE;
					ws.Cells[i + 2, 6].Value = targetFile.ElementAt(i).SALAY_YEAR_MONTH;
					ws.Cells[i + 2, 7].Value = targetFile.ElementAt(i).CAMP_NAME;
					ws.Cells[i + 2, 8].Value = targetFile.ElementAt(i).KPI;
					ws.Cells[i + 2, 9].Value = targetFile.ElementAt(i).BANK_NAME;
					ws.Cells[i + 2, 10].Value = targetFile.ElementAt(i).BANK_AC;
					ws.Cells[i + 2, 11].Value = targetFile.ElementAt(i).VENDOR;
					ws.Cells[i + 2, 12].Value = targetFile.ElementAt(i).STATUS;

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
		public RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION SaveUploadDataExcel()
		{
			RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION tfcv = new RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION();
			try
			{
				string filePath = "";
				decimal uploadCode = 0;
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
				uploadCode = Convert.ToDecimal(upCode);

				System.Web.HttpPostedFile hpf = hfc[0];

				if (hpf.ContentLength > 0 && uploadID > 0)
				{
					string fileName = "";
					filePath = fileDir + Path.GetFileName(hpf.FileName);
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

					tfcv = ExcelForRsoCommissionUpload(filePath, uploadID, UPLOADBY);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return tfcv;
		}


		public string GetIsValidSalaryFor(string TargetForCode, string SALAY_YEAR_MONTH)
		{
			string UploadedTargetForCode = "0";
			List<ISVALID_SALARY_FOR> SalaryForCodeList = null;

			try
			{
				SalaryForCodeList = new RsoCommissionPZ().GetIsValidCommissionFOR(TargetForCode, SALAY_YEAR_MONTH);
				UploadedTargetForCode = SalaryForCodeList[0].VALID_SALARY_FOR_CODE;
			}
			catch (Exception e)
			{
				e.ToString();
			}

			return UploadedTargetForCode;
		}



		public RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION ExcelForRsoCommissionUpload(string fileName, decimal uploadCode, decimal UPLOADBY)
		{
			//string directory = HttpContext.Current.Server.MapPath("~/UserFiles/RSO_SALARY");
			///FileInfo file = new FileInfo(Path.Combine(directory, fileName));
			//string fileFullPath = directory + "/" + fileName;

			string fileExtension = Path.GetExtension(fileName);
			DataTable dtExcelRecords = new DataTable();
			dtExcelRecords = ExcelHelper.ReadExcelSheet(fileName, fileExtension, "Yes");


			int savedRowCount = 1;
			decimal totalTargetValue = 0;
			string TargetForCode = "0";
			RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION tfcv = new RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION();
			tfcv.IsInvalidCode = true;
			tfcv.InvalidCode = "0";
			string rowNo2 = "";
			try
			{
				string rowNo = "";

				string ROSCODE = "";
				decimal TARGET = 0;
				decimal ACHIEVEMENT = 0;
				decimal INCENTIVE = 0;
				string SDATE = "";
				string SALAY_YEAR_MONTH = "";
				string CAMPING_NAME = "";
				string KPI = "";
				string BANK_NAME = "";
				string BANK_AC = "";				
				string VENDOR = "";
				string STATUS = "";
				

				decimal SaveResult = new RsoCommissionPZ().UploadRSOCommission(-1, ROSCODE, TARGET, ACHIEVEMENT, INCENTIVE, SALAY_YEAR_MONTH, CAMPING_NAME, KPI, BANK_NAME, BANK_AC, VENDOR, STATUS, UPLOADBY);
				

				List<RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION> ListOfData = new List<RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION>();
				foreach (DataRow data in dtExcelRecords.Rows)
				{

					if (data[0].ToString().Length > 0)
					{
						ROSCODE = rowNo = data[0].ToString();
						TARGET = Convert.ToDecimal(data[1].ToString());
						ACHIEVEMENT = Convert.ToDecimal(data[2].ToString().Trim());
						INCENTIVE = Convert.ToDecimal(data[3].ToString());
						SDATE = data[4].ToString();
						SALAY_YEAR_MONTH = DateTime.Parse(SDATE).ToString("MMM_yy");
						CAMPING_NAME = data[5].ToString();
						KPI = data[6].ToString();
						BANK_NAME = data[7].ToString();
						BANK_AC = data[8].ToString();
						VENDOR = data[9].ToString();
						STATUS = data[10].ToString();


						tfcv.InvalidCode = GetIsValidSalaryFor(ROSCODE, SALAY_YEAR_MONTH);

						if (tfcv.InvalidCode != "0")
						{
							SaveResult = -1;
							savedRowCount++;
							SaveResult = new RsoCommissionPZ().UploadRSOCommission(uploadCode, ROSCODE, TARGET, ACHIEVEMENT, INCENTIVE, SALAY_YEAR_MONTH, CAMPING_NAME, KPI, BANK_NAME, BANK_AC, VENDOR, STATUS, UPLOADBY);
							decimal isSaved = SaveResult;
							tfcv.IsInvalidCode = false;
							tfcv.InvalidCode = "";
						}
						else
						{
							tfcv.IsInvalidCode = true;
							tfcv.InvalidCode = ROSCODE + ' ' + SALAY_YEAR_MONTH;

							break;
						}

					}
					

				}
				

				//SaveResult = new RsoSalaryPZ().UploadRSOSalary(uploadCode, ROSCODE, BANK_NAME, BANK_AC, DOB_S, JOIN_DATE_S, WORKING_DAY_D, SALAY_YEAR_MONTH, TOTAL_SALARY_D, VENDOR_D, STATUS, UPLOADBY);

				#region old file upload
				

				#endregion
			}
			catch (Exception e)
			{
				string p = e.Message +" ROW:" + rowNo2;
			}
			finally
			{
			}

			return tfcv;
		}


		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetUploadedExcelData(object[] data)
		{
			List<SP_GET_FF_RSO_EARNING_COMMISSION_FILE> FileDataList = null;

			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				FileDataList = new RsoCommissionPZ().GetUploadedCommissionFileDataFile(objcmnParam.UploadCode);
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





		


	}
}
