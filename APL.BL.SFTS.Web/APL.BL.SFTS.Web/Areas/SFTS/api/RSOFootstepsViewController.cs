using APL.BL.SFTS.DataBridgeZone;
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

namespace APL.BL.SFTS.Web.Areas.SFTS.api
{
    [RoutePrefix("SFTS/api/RSOFootstepsView")]
    public class RSOFootstepsViewController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRsoFootsteps(object[] data)
        {
            IEnumerable<SP_GET_RSO_GPS> rsoGPS = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                rsoGPS = new RsoPZ().GetRsoGPS(objcmnParam.ZoneId, objcmnParam.RsoId, objcmnParam.Date);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                rsoGPS
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

              var  retailerGPS = new RetailerPZ().GetFootsepExport(0, objcmnParam.ZoneId, objcmnParam.RouteID, objcmnParam.RetailerId,objcmnParam.Date);
                //var  rsoGPS = new RsoPZ().GetRsoGPS(objcmnParam.ZoneId, objcmnParam.RsoId, objcmnParam.Date);

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

                ws.Cells[1, 1].Value = "SL No";
                ws.Cells[1, 2].Value = "RSO Code";
                ws.Cells[1, 3].Value = "Date";
                ws.Cells[1, 4].Value = "Login Time";
                ws.Cells[1, 5].Value = "Logout Time";
                ws.Cells[1, 6].Value = "Time Elapsed";
                ws.Cells[1, 7].Value = "Land Mark(A,B)";
                ws.Cells[1, 8].Value = "Retailer Code";
                ws.Cells[1, 9].Value = "Retailer LAT-LONG";
                ws.Cells[1, 10].Value = "Sales Call LAT-LONG";
                ws.Cells[1, 11].Value = "Distance";
                ws.Cells[1, 12].Value = "Checkout Feedback";
                ws.Cells[1, 13].Value = "Total Sales Amount";
                ws.Cells[1, 14].Value = "BTS Code";
                ws.Cells[1, 15].Value = "BTS Address";


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
                    ws.Cells[i + 2, 14].Value = targetFile.ElementAt(i).BTS_CODE;
                    ws.Cells[i + 2, 15].Value = targetFile.ElementAt(i).BTS_ADDRESS;
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
        public HttpResponseMessage ExportExcelTemplateBTS(object[] data)
        {
            vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());



            string fileName = "";

            fileName = "RSO_FOOTSTEP_BTS.xlsx";



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

                var retailerGPS = new RetailerPZ().GetFootsepExport_BTS(0, objcmnParam.ZoneId, objcmnParam.RouteID, objcmnParam.RetailerId,objcmnParam.Date);
                //var  rsoGPS = new RsoPZ().GetRsoGPS(objcmnParam.ZoneId, objcmnParam.RsoId, objcmnParam.Date);

                GenerateRSOExcelBTS(retailerGPS, filePath);
            }



            // HttpResponseMessage result = null;
            // result = Request.CreateResponse(HttpStatusCode.OK);
            // result.Content = new StreamContent(new FileStream(path, FileMode.Open));
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            // result.Content.Headers.ContentDisposition.FileName = fileName;

            return Request.CreateResponse(HttpStatusCode.OK, fileName);
        }
        public string GenerateRSOExcelBTS(List<SP_GET_FOOTSTEP_EXPORT2> targetFile, string filePath)
        {
            string result = "";
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet 
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("RSO_FOOTSTEP_BTS");

                ws.Cells[1, 1].Value = "SL No";
                ws.Cells[1, 2].Value = "BTS Code";
                ws.Cells[1, 3].Value = "BTS Info";
                ws.Cells[1, 4].Value = "Address";
               


                for (int i = 0; i < targetFile.Count(); i++)
                {
                    ws.Cells[i + 2, 1].Value = i + 1;
                    ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).BTS_CODE;
                    ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).BTS_INFO;
                    ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).ADDRESS;
                    
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
