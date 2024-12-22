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
    [RoutePrefix("SFTSReports/api/SpecialReport")]
    public class SpecialReportController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetSpecialReport(object[] data)
        {
            List<SP_GET_SPECIAL_REPORT> RSOStock = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                SearchParam searchParam = new SearchParam();
                searchParam.FromDate = objcmnParam.FromDate;
                searchParam.ToDate = objcmnParam.ToDate;
                searchParam.ZoneId = objcmnParam.ZoneId;
                RSOStock = new RsoPZ().GetSpecialReport(searchParam);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                RSOStock
            });
        }
        [HttpPost]
        public HttpResponseMessage ExportExcelTemplate(object[] data)
        {
            vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
            SearchParam searchParam = new SearchParam();
            searchParam.FromDate = objcmnParam.FromDate;
            searchParam.ToDate = objcmnParam.ToDate;
            searchParam.ZoneId = objcmnParam.ZoneId;
            
            var SpecialReport = new RsoPZ().GetSpecialReport(searchParam);



            string fileName = "";

            fileName = "SpecialReport" + DateTime.Now.Ticks + ".xlsx";



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



            GenerateRSOExcel(SpecialReport, filePath);




            // HttpResponseMessage result = null;
            // result = Request.CreateResponse(HttpStatusCode.OK);
            // result.Content = new StreamContent(new FileStream(path, FileMode.Open));
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            // result.Content.Headers.ContentDisposition.FileName = fileName;

            return Request.CreateResponse(HttpStatusCode.OK, fileName);
        }
        public string GenerateRSOExcel(List<SP_GET_SPECIAL_REPORT> targetFile, string filePath)
        {
            string result = "";
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet 
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Special Report");

                ws.Cells[1, 1].Value = "SL NO";
                ws.Cells[1, 2].Value = "RSO CODE";
                ws.Cells[1, 3].Value = "SR NUMBER";
                ws.Cells[1, 4].Value = "DISTRIBUTOR CODE";
                ws.Cells[1, 5].Value = "RSO APP VERSION";
                ws.Cells[1, 6].Value = "DEVICE IMEI";
                ws.Cells[1, 7].Value = "DEVICE UNIQUE SL";
                ws.Cells[1, 8].Value = "LAST LOGIN Date/Time";


                for (int i = 0; i < targetFile.Count(); i++)
                {
                    ws.Cells[i + 2, 1].Value = i + 1;
                    ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).RSO_CODE;
                    ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).SR_NO;
                    ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).DISTRIBUTOR_CODE;
                    ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).RSO_APP_VERSION;
                    ws.Cells[i + 2, 6].Value = targetFile.ElementAt(i).IMEI;
                    ws.Cells[i + 2, 7].Value = targetFile.ElementAt(i).UNIQUE_SL;
                    ws.Cells[i + 2, 8].Value = targetFile.ElementAt(i).LAST_LOGIN_DATE_TIME;
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
