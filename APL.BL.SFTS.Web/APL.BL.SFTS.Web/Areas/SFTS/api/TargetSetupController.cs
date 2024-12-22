using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.Models.SFTS;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
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
using System.Web.UI;
using System.Web.UI.WebControls;


namespace APL.BL.SFTS.Web.Areas.SFTS.api
{
    [RoutePrefix("SFTS/api/TargetSetup")]
    public class TargetSetupController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveTarget(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                vmTargetSetup objTargetSetup = JsonConvert.DeserializeObject<vmTargetSetup>(data[1].ToString());
                objTargetSetup.SetDate = DateTime.Now;

                if (objTargetSetup.TargetForId == 1) //For Distributor Target
                {
                    if (objTargetSetup.Id == 0) { objTargetSetup.Id = new GetNewIdDZ().GetNewId("SQ_TARGET_FOR_DISTRIBUTOR_ID"); }
                }
                else if (objTargetSetup.TargetForId == 2) //For Staff Target
                {
                    if (objTargetSetup.Id == 0) { objTargetSetup.Id = new GetNewIdDZ().GetNewId("SQ_TARGET_FOR_STAFF_ID"); }
                }

				// if (objTargetSetup != null)
				if (objTargetSetup.TargetForId > 0 && objTargetSetup.Id > 0   )
				{
                    decimal insertedId = 0;
                    insertedId = new TargetSetupPZ().SaveUpdateTarget(objTargetSetup.Id, objTargetSetup.TargetForId, objTargetSetup.StaffRoleId, objTargetSetup.TargetItemCode, objTargetSetup.MonthCode, objTargetSetup.UploadCode, objTargetSetup.SetDate, objcmnParam.loggeduser, objTargetSetup.Version, objTargetSetup.RevisionUpTo);

                    result = insertedId > 0 ? insertedId.ToString() : result;
                }
                else
                {
                    result = "";
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
        public IHttpActionResult GetAllTarget(object[] data)
        {
            IEnumerable<SP_GET_TARGET_SETUP> TargetList = null;

            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                TargetList = new TargetSetupPZ().GetAllTarget();
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
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [HttpPost, ApiAuthorization]
        public HttpResponseMessage ExportTargetExcel(object[] data)
        {
			string targetForStaff = "";
			string fileName = "";

			TargetFileExport targetFileExport = JsonConvert.DeserializeObject<TargetFileExport>(data[0].ToString());
            List<SP_GET_TARGET_FILE> targetFile = null;
			SP_GET_TARGET_FILE fileHeader = new SP_GET_TARGET_FILE();
			targetFile = new TargetSetupPZ().TargetExcelTemplate(targetFileExport.TargetPeriodId, targetFileExport.TargetItemId, targetFileExport.TargetFor, targetFileExport.StaffTypeId);
			string monthCode = fileHeader.MONTH_CODE; //  targetFile[0].MONTH_CODE;
			string itemCode = fileHeader.TARGET_ITEM_CODE; // targetFile[0].TARGET_ITEM_CODE;
			string directory = HttpContext.Current.Server.MapPath("~/UserFiles/TargetExcel/");
			string filePath = "";
			//string targetForStaff = "";


			if (targetFileExport.TargetFor == 1)
			{
				fileName = "Target_Distributor_" + monthCode + "_" + itemCode + ".xlsx";
			}
			else if (targetFileExport.TargetFor == 2)
			{
				if (targetFileExport.StaffTypeId == 1)
				{
					targetForStaff = "RSO";
				}
				else if (targetFileExport.StaffTypeId == 2)
				{
					targetForStaff = "AMBM";
				}
				fileName = "Target_" + targetForStaff + "_" + monthCode + "_" + itemCode + ".xlsx";
			}
			else
			{
				fileName = "StaffTargetSetup.xlsx";
				 
			}

			if (fileName == "StaffTargetSetup.xlsx")
			{
				directory = HttpContext.Current.Server.MapPath("~/UserFiles/TargetExcel/");
				filePath = directory + fileName;
				return Request.CreateResponse(HttpStatusCode.OK, fileName);
			}
			

			fileName = string.Concat(fileName);
             directory = HttpContext.Current.Server.MapPath("~/UserFiles/TargetExcel/");
             filePath = directory + fileName;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }


            if (targetFileExport.TargetFor == 1)
            {
                GenerateDistributorTargetExcel(targetFile, filePath);
            }
            else if (targetFileExport.TargetFor == 2)
            {
                if (targetFileExport.StaffTypeId == 1)
                {
                    GenerateRSOTargetExcel(targetFile, filePath);
                }
                else if (targetFileExport.StaffTypeId == 2)
                {
                    GenerateAMBMTargetExcel(targetFile, filePath);
                }
            }


            // HttpResponseMessage result = null;
            // result = Request.CreateResponse(HttpStatusCode.OK);
            // result.Content = new StreamContent(new FileStream(path, FileMode.Open));
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            // result.Content.Headers.ContentDisposition.FileName = fileName;

            return Request.CreateResponse(HttpStatusCode.OK, fileName);
        }

        public string GenerateRSOTargetExcel(List<SP_GET_TARGET_FILE> targetFile, string filePath)
        {
            string result = "";
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet 
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("StaffTarget");

                ws.Cells[1, 1].Value = "SL No.";
                ws.Cells[1, 2].Value = "Month Code";
                ws.Cells[1, 3].Value = "Month Name";
                ws.Cells[1, 4].Value = "Item Code";
                ws.Cells[1, 5].Value = "Item Name";
                ws.Cells[1, 6].Value = "Region";
                ws.Cells[1, 7].Value = "Zone";
                ws.Cells[1, 8].Value = "Distributor Code";
                ws.Cells[1, 9].Value = "Distributor Name";
                ws.Cells[1, 10].Value = "Staff Code";
                ws.Cells[1, 11].Value = "Staff Name";
                ws.Cells[1, 12].Value = "Target Value";

                for (int i = 0; i < targetFile.Count(); i++)
                {
                    ws.Cells[i + 2, 1].Value = i + 1;
                    ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).MONTH_CODE;
                    ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).MONTH_NAME;
                    ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).TARGET_ITEM_CODE;
                    ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).ITEM_NAME;
                    ws.Cells[i + 2, 6].Value = targetFile.ElementAt(i).REGION;
                    ws.Cells[i + 2, 7].Value = targetFile.ElementAt(i).ZONE;
                    ws.Cells[i + 2, 8].Value = targetFile.ElementAt(i).DISTRIBUTOR_CODE;
                    ws.Cells[i + 2, 9].Value = targetFile.ElementAt(i).DISTRIBUTOR_NAME;
                    ws.Cells[i + 2, 10].Value = targetFile.ElementAt(i).STAFF_CODE;
                    ws.Cells[i + 2, 11].Value = targetFile.ElementAt(i).STAFF_NAME;
                    ws.Cells[i + 2, 12].Value = targetFile.ElementAt(i).TARGET_VALUE;
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

        public string GenerateAMBMTargetExcel(List<SP_GET_TARGET_FILE> targetFile, string filePath)
        {
            string result = "";
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet 
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("StaffTarget");

                ws.Cells[1, 1].Value = "SL No.";
                ws.Cells[1, 2].Value = "Month Code";
                ws.Cells[1, 3].Value = "Month Name";
                ws.Cells[1, 4].Value = "Item Code";
                ws.Cells[1, 5].Value = "Item Name";
                ws.Cells[1, 6].Value = "Region";
                ws.Cells[1, 7].Value = "Zone";
                ws.Cells[1, 8].Value = "Staff Code";
                ws.Cells[1, 9].Value = "Staff Name";
                ws.Cells[1, 10].Value = "Target Value";

                for (int i = 0; i < targetFile.Count(); i++)
                {
                    ws.Cells[i + 2, 1].Value = i + 1;
                    ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).MONTH_CODE;
                    ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).MONTH_NAME;
                    ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).TARGET_ITEM_CODE;
                    ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).ITEM_NAME;
                    ws.Cells[i + 2, 6].Value = targetFile.ElementAt(i).REGION;
                    ws.Cells[i + 2, 7].Value = targetFile.ElementAt(i).ZONE;
                    ws.Cells[i + 2, 8].Value = targetFile.ElementAt(i).STAFF_CODE;
                    ws.Cells[i + 2, 9].Value = targetFile.ElementAt(i).STAFF_NAME;
                    ws.Cells[i + 2, 10].Value = targetFile.ElementAt(i).TARGET_VALUE;
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

        public string GenerateDistributorTargetExcel(List<SP_GET_TARGET_FILE> targetFile, string filePath)
        {
            string result = "";
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet 
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("DistributorTarget");

                ws.Cells[1, 1].Value = "SL No.";
                ws.Cells[1, 2].Value = "Month Code";
                ws.Cells[1, 3].Value = "Month Name";
                ws.Cells[1, 4].Value = "Item Code";
                ws.Cells[1, 5].Value = "Item Name";
                ws.Cells[1, 6].Value = "Region";
                ws.Cells[1, 7].Value = "Zone";
                ws.Cells[1, 8].Value = "Distributor Code";
                ws.Cells[1, 9].Value = "Distributor Name";
                ws.Cells[1, 10].Value = "Target Value";

                for (int i = 0; i < targetFile.Count(); i++)
                {
                    ws.Cells[i + 2, 1].Value = i + 1;
                    ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).MONTH_CODE;
                    ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).MONTH_NAME;
                    ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).TARGET_ITEM_CODE;
                    ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).ITEM_NAME;
                    ws.Cells[i + 2, 6].Value = targetFile.ElementAt(i).REGION;
                    ws.Cells[i + 2, 7].Value = targetFile.ElementAt(i).ZONE;
                    ws.Cells[i + 2, 8].Value = targetFile.ElementAt(i).DISTRIBUTOR_CODE;
                    ws.Cells[i + 2, 9].Value = targetFile.ElementAt(i).DISTRIBUTOR_NAME;
                    ws.Cells[i + 2, 10].Value = targetFile.ElementAt(i).TARGET_VALUE;
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
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                uploadCode = new GetNewIdDZ().GetNewId("SQ_FF_UPLOAD_CODE");
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return uploadCode;
        }


        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [HttpPost]
        public TargetForCodeValidity SaveUpdateTargetExcel()
        {
            TargetForCodeValidity tfcv = new TargetForCodeValidity();
            try
            {
                // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
                string filePath = "";
                decimal uploadCode = 0;
                decimal applyType = 0;
                decimal applySubType = 0;
                tfcv.InvalidCode = "0";
                tfcv.IsInvalidCode = true;


                string directory = HttpContext.Current.Server.MapPath("~/UserFiles/TargetExcel");
                string fileDir = directory + "/";

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
                string upCode = System.Web.HttpContext.Current.Request.Params["uploadCode"];
                string aplyType = System.Web.HttpContext.Current.Request.Params["applyType"];
                string aplySubType = System.Web.HttpContext.Current.Request.Params["applySubType"];
                uploadCode = Convert.ToDecimal(upCode);
                applyType = Convert.ToDecimal(aplyType);
                applySubType = Convert.ToDecimal(aplySubType);

                //   HttpContext.Response = "";

                System.Web.HttpPostedFile hpf = hfc[0];

                if (hpf.ContentLength > 0)
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

                    tfcv = ExcelForTargetUpload(fileName, uploadCode, applyType, applySubType);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return tfcv;
        }

        public string GetIsValidTargetFor(decimal TargetFor, decimal StaffTypeId, string TargetForCode)
        {
            string UploadedTargetForCode = "0";
            List<GET_IS_VALID_TARGET_FOR> TargetForCodeList = null;

            try
            {
                TargetForCodeList = new TargetSetupPZ().GetIsValidTargetFor(TargetFor, StaffTypeId, TargetForCode);
                UploadedTargetForCode = TargetForCodeList[0].VALID_TARGET_FOR_CODE;
            }
            catch (Exception e)
            {
                e.ToString();
            }

            return UploadedTargetForCode;
        }

        public TargetForCodeValidity ExcelForTargetUpload(string fileName, decimal uploadCode, decimal applyType, decimal applySubType)
        {
            string directory = HttpContext.Current.Server.MapPath("~/UserFiles/TargetExcel");
            FileInfo file = new FileInfo(Path.Combine(directory, fileName));

            int savedRowCount = 1;
            decimal totalTargetValue = 0;
            string TargetForCode = "0";
            TargetForCodeValidity tfcv = new TargetForCodeValidity();
            tfcv.IsInvalidCode = true;
            tfcv.InvalidCode = "0";

            try
            {
                string rowNo = "";
                string monthCode = "";
                string itemCode = "";
                string TargetApplyCode = "";
                string targetValue = "";
                decimal decTargetValue = 0;
                decimal log = 1;

                using (ExcelPackage package = new ExcelPackage(file))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
                    int totalRows = workSheet.Dimension.Rows;
                    int totalCols = workSheet.Dimension.Columns;

                    List<int> columnsToRead = new List<int>();
					int i = 0;
					for ( i = 1; i <= totalCols; i++)
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

                                if (applyType == 1)
                                {
                                    switch (c)
                                    {
                                        case 1:
                                            rowNo = columnValue[0].ToString();
                                            break;
                                        case 2:
                                            monthCode = columnValue[0].ToString();
                                            break;
                                        case 4:
                                            itemCode = columnValue[0].ToString();
                                            break;
                                        case 8:
                                            TargetApplyCode = columnValue[0].ToString();
                                            TargetForCode = TargetApplyCode;
                                            tfcv.RowNo = r.ToString();
                                            tfcv.ColumnNo = c.ToString();
                                            break;
                                        case 10:
                                            targetValue = columnValue[0].ToString();
                                            decTargetValue = Convert.ToDecimal(targetValue);
                                            totalTargetValue = totalTargetValue + decTargetValue;
                                            break;
                                    }
                                    if (c != 5)
                                    {
                                        continue;
                                    }
                                }
                                else if (applyType == 2)
                                {
                                    switch (c)
                                    {
                                        case 1:
                                            rowNo = columnValue[0].ToString();
                                            break;
                                        case 2:
                                            monthCode = columnValue[0].ToString();
                                            break;
                                        case 4:
                                            itemCode = columnValue[0].ToString();
                                            break;
                                        case 10:
                                            TargetApplyCode = columnValue[0].ToString();
                                            TargetForCode = TargetApplyCode;
                                            tfcv.RowNo = r.ToString();
                                            tfcv.ColumnNo = c.ToString();
                                            break;
                                        case 12:
                                            targetValue = columnValue[0].ToString();
                                            decTargetValue = Convert.ToDecimal(targetValue);
                                            totalTargetValue = totalTargetValue + decTargetValue;
                                            break;
                                    }

                                    if (c != 5)
                                    {
                                        continue;
                                    }
                                }

                            }
                            if (j > totalRows)
                            {
                                break;
                            }
                        }

                        tfcv.InvalidCode = GetIsValidTargetFor(applyType, applySubType, TargetForCode);

                        if (tfcv.InvalidCode != "0")
                        {
                            savedRowCount++;
                            decimal SaveResult = new TargetSetupPZ().UploadTargetDetail(uploadCode, monthCode, itemCode, TargetApplyCode, decTargetValue, applyType, log, applySubType);
                            decimal isSaved = SaveResult;
                            tfcv.IsInvalidCode = false;
                            tfcv.InvalidCode = "";
                        }
                        else
                        {
                            tfcv.IsInvalidCode = true;
                            tfcv.InvalidCode = TargetForCode;
                            if (applyType == 1)
                            {
                                tfcv.TargetForName = "Distributor";
                            }
                            else
                            {
                                if (applySubType == 1)
                                {
                                    tfcv.TargetForName = "RSO";
                                }
                                else
                                {
                                    tfcv.TargetForName = "AMBM";
                                }
                            }
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
            List<SP_GET_DISTRIBUTOR_TARGET_FILE> FileDataList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                FileDataList = new TargetSetupPZ().GetUploadedFileData(objcmnParam.UploadCode, objcmnParam.TargetFor);
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

        #endregion Excel File Upload

    }
}
