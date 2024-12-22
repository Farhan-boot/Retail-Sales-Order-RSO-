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

namespace APL.BL.SFTS.Web.Areas.SFTS.api
{

	[RoutePrefix("SFTS/api/RSOincentive")]
	public class RSOincentiveController : ApiController
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
				insertedId = new RsoIncentiveDZ().SaveUpdateIncentive(objFileUpload.UploadCode);
				
				result = insertedId > 0 ? insertedId.ToString() : result;

				//SaveChangeLog(true, _MESSAGE, objcmnParam.loggeduser);

			}
			catch (Exception e)
			{
				string errorMessage = "SaveData-ERROR:-" + e.Message.ToString();
				ExcelHelper.WriteServiceLog(errorMessage);

				e.ToString();
				result = "";
			}
			return Request.CreateResponse(HttpStatusCode.OK, result);
		}



		[HttpPost, ApiAuthorization]
		public IHttpActionResult GetAllData(object[] data)
		{
			IEnumerable<SP_GET_FF_RSO_EARNING_INCENTIVE> FileDataList = null;

			int recordsTotal = 0;
			decimal periodtypeID = 0;
			decimal monthID = 0;
			try
			{
				RSOEarningParameters objcmnParam = JsonConvert.DeserializeObject<RSOEarningParameters>(data[0].ToString());
				periodtypeID = objcmnParam.periodtypeID;
				monthID = objcmnParam.monthID;

			}
			catch (Exception e)
			{
				
				periodtypeID = 0;
				monthID = 0;
			}

			try
			{
				
				FileDataList = new RsoIncentivePZ().GetRsoiNCENTIVE(periodtypeID, monthID);
				recordsTotal = FileDataList.Count();
			}
			catch (Exception e)
			{
				string errorMessage = "GetAllData-ERROR:-" + e.Message.ToString();
				ExcelHelper.WriteServiceLog(errorMessage);

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




			/*
			TargetFileExport targetFileExport = JsonConvert.DeserializeObject<TargetFileExport>(data[0].ToString());
			List<SP_GET_FF_RSO_EARNING_INCENTIVE_FILE> targetFile = null;
			targetFile = new RsoIncentivePZ().GetRsoiNCENTIVE_export(1, targetFileExport.TargetPeriodId);
			string CAMP_NAME = targetFile[0].BASE_YEAR_MONTH;		

			string targetForStaff = "";
			string fileName = "RSO_INCENTIVE.xlsx";


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
			GenerateRSOeARNINGExcel(targetFile, filePath);



			return Request.CreateResponse(HttpStatusCode.OK, fileName);

			*/



			RSOEarningParameters targetFileExport = JsonConvert.DeserializeObject<RSOEarningParameters>(data[0].ToString());
			string fileName = "RSO_INCENTIVE.xlsx";
			string directory = HttpContext.Current.Server.MapPath("~/UserFiles/RSO_SALARY/");
			string filePath = "";
			string targetForStaff = "";

			if (targetFileExport.monthID > 0)
			{
				List<SP_GET_FF_RSO_EARNING_INCENTIVE_FILE> targetFile = null;
				targetFile = new RsoIncentivePZ().GetRsoiNCENTIVE_export(1, targetFileExport.monthID);
				if (targetFile.Count > 0)
				{
					fileName = "RSO_COMMISSION_" + targetFile[0].BASE_YEAR_MONTH + ".xlsx";
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
				GenerateRSOeARNINGExcel(targetFile, filePath);

				return Request.CreateResponse(HttpStatusCode.OK, fileName);

			}
			else
			{
				fileName = "RSO_INCENTIVE.xlsx";
				directory = HttpContext.Current.Server.MapPath("~/UserFiles/RSO_SALARY/TEMPLATE/");
				filePath = directory + fileName;
				return Request.CreateResponse(HttpStatusCode.OK, fileName);
			}




		}

		public string GenerateRSOeARNINGExcel(List<SP_GET_FF_RSO_EARNING_INCENTIVE_FILE> targetFile, string filePath)
		{
			string result = "";
			using (ExcelPackage pck = new ExcelPackage())
			{
				//Create the worksheet 
				ExcelWorksheet ws = pck.Workbook.Worksheets.Add("StaffTarget");

				ws.Cells[1, 1].Value = "SL";
				ws.Cells[1, 2].Value = "RSO CODE";
				ws.Cells[1, 3].Value = "MONTH YEAR";
				ws.Cells[1, 4].Value = "TYPE";
				ws.Cells[1, 5].Value = "AMOUNT";
				ws.Cells[1, 6].Value = "REMARKS";				


				for (int i = 0; i < targetFile.Count(); i++)
				{
					ws.Cells[i + 2, 1].Value = i + 1;
					ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).RSOCODE;
					ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).BASE_YEAR_MONTH;
					ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).TYPE;
					ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).INCENTIVE;
					ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).REMARKS;


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
				string errorMessage = "GetUploadCode-ERROR:-" + e.Message.ToString();
				ExcelHelper.WriteServiceLog(errorMessage);

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
					ExcelHelper.WriteServiceLog("SaveUploadDataExcel STEP-1");
					tfcv = ExcelForRsoSalaryUpload(filePath, uploadID, UPLOADBY);
				}
			}
			catch (Exception ex)
			{
				string errorMessage = "SaveUploadDataExcel-ERROR:-" + ex.Message.ToString();
				ExcelHelper.WriteServiceLog(errorMessage);
				throw ex;
			}

			return tfcv;
		}


		public string GetIsValidSalaryFor(string RSOCODE, string SALAY_YEAR_MONTH)
		{
			string UploadedTargetForCode = "0";
			List<ISVALID_SALARY_FOR> SalaryForCodeList = null;

			try
			{
				SalaryForCodeList = new RsoIncentiveDZ().GetIsValidIncentiveFor(RSOCODE, SALAY_YEAR_MONTH);
				UploadedTargetForCode = SalaryForCodeList[0].VALID_SALARY_FOR_CODE;
			}
			catch (Exception e)
			{
				string errorMessage = "GetIsValidSalaryFor-ERROR:-" + e.Message.ToString();
				ExcelHelper.WriteServiceLog(errorMessage);

				e.ToString();
			}

			return UploadedTargetForCode;
		}



		public RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION ExcelForRsoSalaryUpload(string fileName, decimal uploadCode, decimal UPLOADBY)
		{
			//string directory = HttpContext.Current.Server.MapPath("~/UserFiles/RSO_SALARY");
			///FileInfo file = new FileInfo(Path.Combine(directory, fileName));
			//string fileFullPath = directory + "/" + fileName;

			string fileExtension = Path.GetExtension(fileName);
			DataTable dtExcelRecords = new DataTable();
			dtExcelRecords = ExcelHelper.ReadExcelSheet(fileName, fileExtension, "Yes");
			ExcelHelper.WriteServiceLog("SaveUploadDataExcel STEP-2: Total ROW:" + dtExcelRecords.Rows.Count);

			int savedRowCount = 1;
			decimal totalTargetValue = 0;
			string TargetForCode = "0";
			RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION tfcv = new RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION();
			tfcv.IsInvalidCode = true;
			tfcv.InvalidCode = "0";
			decimal rowNo2 = 0;
			try
			{
				string rowNo = "";
				string TYPE = "";
				string ROSCODE = "";				
				string SALAY_YEAR_MONTH = "";

				decimal INCENTIVE = 0;
				decimal TOTAL_SALARY_D = 0; 
				string REMARKS = "";

				ExcelHelper.WriteServiceLog("SaveUploadDataExcel STEP-3");
				decimal SaveResult = new RsoIncentivePZ().UploadRSOIncentive(-1, ROSCODE, SALAY_YEAR_MONTH, TYPE, INCENTIVE, REMARKS, UPLOADBY);
				ExcelHelper.WriteServiceLog("SaveUploadDataExcel STEP-4");

				List<RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION> ListOfData = new List<RSO_SALARY_COMMISSION_INCENTIVE_VALIDATION>();
				foreach (DataRow data in dtExcelRecords.Rows)
				{
					if (data[0].ToString().Trim().Length > 0)
					{
						rowNo2 = rowNo2++;
						//SALAY_YEAR_MONTH = data[1].ToString();
						ROSCODE = data[0].ToString().Trim();
						SALAY_YEAR_MONTH = DateTime.Parse(data[1].ToString().Trim()).ToString("MMM_yy");

						TYPE = data[2].ToString();
						INCENTIVE = Convert.ToDecimal(data[3].ToString());
						REMARKS = data[4].ToString();

						ExcelHelper.WriteServiceLog("SaveUploadDataExcel STEP-5");
						tfcv.InvalidCode = GetIsValidSalaryFor(ROSCODE, SALAY_YEAR_MONTH);

						if (tfcv.InvalidCode != "0")
						{
							SaveResult = -1;
							savedRowCount++;
							SaveResult = new RsoIncentivePZ().UploadRSOIncentive(uploadCode, ROSCODE, SALAY_YEAR_MONTH, TYPE, INCENTIVE, REMARKS, UPLOADBY);
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
				
				
			}
			catch (Exception e)
			{
				string errorMessage = "ExcelForRsoSalaryUpload-ROW: " + rowNo2 +" - ERROR:-" + e.Message.ToString();
				ExcelHelper.WriteServiceLog(errorMessage);

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
			List<SP_GET_FF_RSO_EARNING_INCENTIVE_FILE> FileDataList = null;

			try
			{
				vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
				FileDataList = new RsoIncentivePZ().GetUploadedSalaryFileDataFile(objcmnParam.UploadCode);
			}
			catch (Exception e)
			{
				string errorMessage = "ExcelForRsoSalaryUpload-ERROR:-" + e.Message.ToString();
				ExcelHelper.WriteServiceLog(errorMessage);

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
				string errorMessage = "GetCurUserID-ERROR:-" + ex.Message.ToString();
				ExcelHelper.WriteServiceLog(errorMessage);

				return 0;
			}

		}





		


	}
}
