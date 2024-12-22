using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
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
    [RoutePrefix("SFTSReports/api/AttendanceSummary1")]
    public class AttendanceSummary1Controller : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetAttendanceSummary1(object[] data)
        {
            List<SP_GET_ATTENDANCE_SUMMARY1> AttendanceSummary1 = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
          
                AttendanceSummary1 = new RSOAttendancePZ().GetAttendanceSummary1(objcmnParam);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                AttendanceSummary1
            });
        }
        [HttpPost]
        public HttpResponseMessage ExportExcelTemplate(object[] data)
        {
            vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

           var  AttendanceSummary1 = new RSOAttendancePZ().GetAttendanceSummary1(objcmnParam);



            string fileName = "";

            fileName = "Attendance_Summary1.xlsx";



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



            GenerateRSOExcel(AttendanceSummary1, filePath);




            // HttpResponseMessage result = null;
            // result = Request.CreateResponse(HttpStatusCode.OK);
            // result.Content = new StreamContent(new FileStream(path, FileMode.Open));
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            // result.Content.Headers.ContentDisposition.FileName = fileName;

            return Request.CreateResponse(HttpStatusCode.OK, fileName);
        }
        public string GenerateRSOExcel(List<SP_GET_ATTENDANCE_SUMMARY1> targetFile, string filePath)
        {
            string result = "";
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet 
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Attendance Summary1");

                ws.Cells[1, 1].Value = "SL NO";
                ws.Cells[1, 2].Value = "Date";
                ws.Cells[1, 3].Value = "RSO Code";
                ws.Cells[1, 4].Value = "SR No";
                ws.Cells[1, 5].Value = "Total Distance Covered";
                ws.Cells[1, 6].Value = "Total Time(Sec)";


                for (int i = 0; i < targetFile.Count(); i++)
                {
                    ws.Cells[i + 2, 1].Value = i + 1;
                    ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).ATT_DATE;
                    ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).RSO_CODE;
                    ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).SR_NO;
                    ws.Cells[i + 2, 5].Value = string.IsNullOrEmpty(targetFile.ElementAt(i).TOTAL_DIST_COVERED) ? -1 : Convert.ToDecimal(targetFile.ElementAt(i).TOTAL_DIST_COVERED) ;
                    ws.Cells[i + 2, 6].Value = targetFile.ElementAt(i).TOTAL_TIME;
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
