using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.Models.ApiMobile;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.Web.Providers;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace APL.BL.SFTS.Web.Areas.SFTSReports.api
{
    [RoutePrefix("SFTSReports/api/RetailSalesOfficer")]
    public class RetailSalesOfficerController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRsoTargetVsAchivements(object[] data)
        {
            List<SP_GET_RPT_RSO_TARGET_ACHIVE> targetVsAchivemntList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                GetRsoTargetAchivement rsoTargetAchivement = JsonConvert.DeserializeObject<GetRsoTargetAchivement>(data[1].ToString());

                targetVsAchivemntList = new RsoPZ().GetRsoTargetVsAchivement(rsoTargetAchivement, 0);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                targetVsAchivemntList
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRsoSalesCallAndDailyAttendance(object[] data)
        {
            List<SP_GET_RSO_SALES_CALL_DAILY_ATTENDANCE> salesCallAndDaileyAttendanceList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                SearchParam objSearchParam = JsonConvert.DeserializeObject<SearchParam>(data[1].ToString());
                
                salesCallAndDaileyAttendanceList = new RsoPZ().GetSalesCallAndDailyAttendance(objSearchParam, objcmnParam.FromDate, objcmnParam.ToDate);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                salesCallAndDaileyAttendanceList
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRsoDetails(object[] data)
        {
            List<SP_GET_RSO_DETAIL> getRsoDetails = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                GetRsoDetails objGetRsoDetails = JsonConvert.DeserializeObject<GetRsoDetails>(data[1].ToString());
                
                getRsoDetails = new RsoPZ().GetRSODetail(objGetRsoDetails);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                getRsoDetails
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRsoAttendanceAndPath(object[] data)
        {
            List<SP_GET_RSO_ATTENDANCE_AND_PATH> rsoAttendanceAndPathList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                SearchParam objSearchParam = JsonConvert.DeserializeObject<SearchParam>(data[1].ToString());

                rsoAttendanceAndPathList = new RsoPZ().GetRsoAttendanceAndPath(objSearchParam, objcmnParam.FromDate, objcmnParam.ToDate);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                rsoAttendanceAndPathList
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRSOCommission(object[] data)
        {
            List<SP_GET_RSO_COMMISSION> rsoCommission = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                SearchParam objSearchParam = JsonConvert.DeserializeObject<SearchParam>(data[1].ToString());

                rsoCommission = new RsoPZ().GetRSOCommission(objSearchParam, objcmnParam.FromDate, objcmnParam.ToDate);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                rsoCommission
            });
        }
        [HttpPost]
        public HttpResponseMessage ExportExcelTemplate(object[] data)
        {
            vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());



            string fileName = "";

            fileName = "RSO_FOOTSTEP.xlsx";



            fileName = string.Concat(fileName);
            string directory = HttpContext.Current.Server.MapPath("~/UserFiles/Notification/");
            string filePath = directory + fileName;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            if (objcmnParam.NoticeForId == 1)
            {


                var retailerGPS = new RetailerPZ().GetFootsepExport(0, objcmnParam.ZoneId, objcmnParam.RouteID, objcmnParam.RetailerId, objcmnParam.Date);

                GenerateRSOExcel(retailerGPS, filePath);
            }



            // HttpResponseMessage result = null;
            // result = Request.CreateResponse(HttpStatusCode.OK);
            // result.Content = new StreamContent(new FileStream(path, FileMode.Open));
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            // result.Content.Headers.ContentDisposition.FileName = fileName;

            return Request.CreateResponse(HttpStatusCode.OK, fileName);
        }
        public string GenerateRSOExcel(List<SP_GET_FOOTSTEP_EXPORT1> targetFile, string filePath)
        {
            string result = "";
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet 
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("RSO_FOOTSTEP");

                ws.Cells[1, 1].Value = "SL NO";
                ws.Cells[1, 2].Value = "RSO CODE";
                ws.Cells[1, 3].Value = "DATE";
                ws.Cells[1, 4].Value = "LOGIN TIME";
                ws.Cells[1, 5].Value = "LOGOUT TIME";
                ws.Cells[1, 6].Value = "TIME ELAPSED";
                ws.Cells[1, 7].Value = "LAND MARK(A,B)";
                ws.Cells[1, 8].Value = "RETAILER CODE";
                ws.Cells[1, 9].Value = "RETAILER LAT-LONG";
                ws.Cells[1, 10].Value = "SALES CALL LAT-LONG";
                ws.Cells[1, 11].Value = "DISTANCE";
                ws.Cells[1, 12].Value = "CHECKOUT FEEDBACK";
                ws.Cells[1, 13].Value = "TOTAL SALES AMOUNT";


                for (int i = 0; i < targetFile.Count(); i++)
                {
                    ws.Cells[i + 2, 1].Value = i + 1;
                    ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).RSO_CODE;
                    ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).DATE_STR;
                    ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).LOGIN_TIME;
                    ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).LOGOUT_TIME;
                    ws.Cells[i + 2, 6].Value = targetFile.ElementAt(i).TIME_ELAPSED;
                    ws.Cells[i + 2, 7].Value = targetFile.ElementAt(i).LAND_MARK;
                    ws.Cells[i + 2, 8].Value = targetFile.ElementAt(i).RETAILER_CODE;
                    ws.Cells[i + 2, 9].Value = targetFile.ElementAt(i).RETAILER_LAT_LONG;
                    ws.Cells[i + 2, 10].Value = targetFile.ElementAt(i).SALES_LAT_LONG;
                    ws.Cells[i + 2, 11].Value = targetFile.ElementAt(i).DISTANCE;
                    ws.Cells[i + 2, 12].Value = targetFile.ElementAt(i).CHECKOUT_FEEDBACK;
                    ws.Cells[i + 2, 13].Value = targetFile.ElementAt(i).TOTAL_SALES_AMOUNT;
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

        [HttpPost]
        public HttpResponseMessage ExportExcelAttPath(object[] data)
        {
            vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());



            string fileName = "";

            fileName = "AttendancePath.xlsx";



            fileName = string.Concat(fileName);
            string directory = HttpContext.Current.Server.MapPath("~/UserFiles/Notification/");
            string filePath = directory + fileName;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            
            SearchParam objSearchParam = JsonConvert.DeserializeObject<SearchParam>(data[1].ToString());

          var  rsoAttendanceAndPathList = new RsoPZ().GetRsoAttendanceAndPath(objSearchParam, objcmnParam.FromDate, objcmnParam.ToDate);

            GenerateATTPathExcel(rsoAttendanceAndPathList, filePath);
            



            // HttpResponseMessage result = null;
            // result = Request.CreateResponse(HttpStatusCode.OK);
            // result.Content = new StreamContent(new FileStream(path, FileMode.Open));
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            // result.Content.Headers.ContentDisposition.FileName = fileName;

            return Request.CreateResponse(HttpStatusCode.OK, fileName);
        }
        public string GenerateATTPathExcel(List<SP_GET_RSO_ATTENDANCE_AND_PATH> targetFile, string filePath)
        {
            string result = "";
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet 
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("AttendancePath");

                ws.Cells[1, 1].Value = "SL NO";

                ws.Cells[1, 2].Value = "Date";
                ws.Cells[1, 3].Value = "Route";
                ws.Cells[1, 4].Value = "RSO Code";
                ws.Cells[1, 5].Value = "SR No";
                ws.Cells[1, 6].Value = "Retailer Code";
                ws.Cells[1, 7].Value = "Sales Call Login Time";
                ws.Cells[1, 8].Value = "Sales Call Logout Time";
                ws.Cells[1, 9].Value = "Time Elapsed(sec)";
                ws.Cells[1, 10].Value = "Land Mark(A,B)";
                ws.Cells[1, 11].Value = "Retailer LAT-LONG";
                ws.Cells[1, 12].Value = "Sales Call LAT-LONG";
                ws.Cells[1, 13].Value = "Distance";
                ws.Cells[1, 14].Value = "Matched";
                ws.Cells[1, 15].Value = "Checkout Feedback";
                ws.Cells[1, 16].Value = "Checkout Remarks";
                ws.Cells[1, 17].Value = "Closed BTS Code";
                ws.Cells[1, 18].Value = "Total Sales Amount";


                for (int i = 0; i < targetFile.Count(); i++)
                {
                    ws.Cells[i + 2, 1].Value = i + 1;
                    ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).DATE;
                    ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).ROUTE_CODE_NAME;
                    ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).RSO_CODE_NAME;
                    ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).SR_NO;
                    ws.Cells[i + 2, 6].Value = targetFile.ElementAt(i).RETAILER_CODE;
                    ws.Cells[i + 2, 7].Value = targetFile.ElementAt(i).SALES_CALL_LOGIN_TIME;
                    ws.Cells[i + 2, 8].Value = targetFile.ElementAt(i).SALES_CALL_LOGOUT_TIME;
                    ws.Cells[i + 2, 9].Value = targetFile.ElementAt(i).TIME_ELAPSED;
                    ws.Cells[i + 2, 10].Value = targetFile.ElementAt(i).LAND_MARK;
                    ws.Cells[i + 2, 11].Value = targetFile.ElementAt(i).RETAILER_LAT_LONG;
                    ws.Cells[i + 2, 12].Value = targetFile.ElementAt(i).SALES_CALL_LOCATION;
                    ws.Cells[i + 2, 13].Value = targetFile.ElementAt(i).DISTANCE;
                    ws.Cells[i + 2, 14].Value = targetFile.ElementAt(i).MATCH;
                    ws.Cells[i + 2, 15].Value = targetFile.ElementAt(i).CHECKOUT_FEEDBACK;
                    ws.Cells[i + 2, 16].Value = targetFile.ElementAt(i).CHECKOUT_REMARKS;
                    ws.Cells[i + 2, 17].Value = targetFile.ElementAt(i).CLOSE_BTS_CODE;
                    ws.Cells[i + 2, 18].Value = targetFile.ElementAt(i).TOTAL_SALES_AMOUNT;
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
    }
}
