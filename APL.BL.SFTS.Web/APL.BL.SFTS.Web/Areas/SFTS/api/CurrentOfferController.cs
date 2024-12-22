using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.SFTS;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.Web.Providers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace APL.BL.SFTS.Web.Areas.SFTS.api
{
    [RoutePrefix("SFTS/api/CurrentOffer")]
    public class CurrentOfferController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveUpdateCurrentOffer(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                vmCurrentOffer currentOffer = JsonConvert.DeserializeObject<vmCurrentOffer>(data[1].ToString());
                List<GET_ID> currentOfferDistList = JsonConvert.DeserializeObject<List<GET_ID>>(data[2].ToString());
                List<GET_ID> currentOfferRegList = JsonConvert.DeserializeObject<List<GET_ID>>(data[3].ToString());

                if (currentOffer != null)
                {
                    if (currentOffer.OfferId == 0) { currentOffer.OfferId = new GetNewIdDZ().GetNewId("SQ_FF_CURRENT_OFFER"); }

                    decimal SavedOfferId = new CurrentOfferPZ().SaveUpdateCurrentOffer(currentOffer.OfferId, currentOffer.OfferName, currentOffer.OfferDetails, currentOffer.StartDate, currentOffer.EndDate, currentOffer.DisplayFromDate, currentOffer.DisplayToDate, currentOffer.TargetType, currentOffer.IsToAll, currentOffer.StaffRoleId, currentOffer.IsActive, objcmnParam.loggeduser, currentOfferRegList, currentOfferDistList);
                    result = SavedOfferId > 0 ? SavedOfferId.ToString() : "";
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
        [HttpPost]
        public IHttpActionResult GetRegions(object[] data)
        {
            IEnumerable<GET_REGION> objListRegion = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListRegion = new CurrentOfferPZ().GetRegions(0);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListRegion
            });
        }
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetAllOffer(object[] data)
        {
            IEnumerable<SP_GET_ALL_CURRENT_OFFER> currentOffers = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                currentOffers = new CurrentOfferPZ().GetAllCurrentOffer(objcmnParam.CurrentOfferId);                
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                currentOffers
            });
        }

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
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetCurrentOfferReg(object[] data)
        {
            IEnumerable<SP_GET_ALL_DISTRIBUTOR> currentOfferReg = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                currentOfferReg = new CurrentOfferPZ().GetCurrentOfferRegion(objcmnParam.CurrentOfferId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                currentOfferReg
            });
        }

        [HttpPost]
        public void SaveUpdatePictures()
        {
            int iUploadedCnt = 0;

            string directory = HttpContext.Current.Server.MapPath("~/UserFiles/CurrentOfferImage");
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

                    byte[] picture = File.ReadAllBytes(filePath);

                    decimal PicturesSaveResult = new CurrentOfferPZ().SaveUpdateOfferPictures(0, CurrentOfferId, PicSlNo, fileName, picture, 1);
                }
            }
        }


        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetCurrentOfferPictures(object[] data)
        {
            List<GET_OFFER_PICTURES> getOfferPicture = null;
            vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

            try
            {
                getOfferPicture = new VisitPlanPZ().GetCurrentOfferPictures(0, objcmnParam.CurrentOfferId, 0);
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
				int i = 1;

				for (i = 1; i <= numberOfCols; i++)
                {
                    columnsToRead.Add(i);
                }

				int j = 0;

				for (j = 2; j <= numberOfRows; j++)
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

                            if (c != 5)
                            {
                                continue;
                            }
                        }
                        if (j > numberOfRows)
                        {
                            break;
                        }
                    }
                    savedRowCount++;
                  //  decimal SaveResult = new TargetSetupPZ().UploadTargetDetail(uploadCode, monthCode, itemCode, distributorCode, decTargetValue, applyType, log);
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
    }
}
