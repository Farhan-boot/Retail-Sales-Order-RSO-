using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone.RSO;
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
    [RoutePrefix("SFTS/api/RSOPoint")]
    public class RSOPointController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetRSOPoints(object[] data)
        {
            IEnumerable<SP_GET_RSOPOINT_WEB> rsoPointList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                SearchParam searchParam = new SearchParam();
                searchParam.UserId = objcmnParam.loggeduser;
                searchParam.FromDate = objcmnParam.FromDate;
                searchParam.ToDate = objcmnParam.ToDate;
                searchParam.ZoneId = objcmnParam.ZoneId;
                searchParam.AppId = 0;
                rsoPointList = new RSOPointPZ().GetRSOPoints(searchParam);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                rsoPointList
            });
        }
        [HttpPost]
        public HttpResponseMessage ExportExcelTemplate(object[] data)
        {
            vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
            SearchParam searchParam = new SearchParam();
            searchParam.UserId = objcmnParam.loggeduser;
            searchParam.FromDate = objcmnParam.FromDate;
            searchParam.ToDate = objcmnParam.ToDate;
            searchParam.ZoneId = objcmnParam.ZoneId;
            searchParam.AppId = 0;


            string fileName = "";

                fileName = "RSO_Point.xlsx";



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

        
               var rsoPointList = new RSOPointPZ().GetRSOPoints(searchParam);
      
                GenerateRSOExcel(rsoPointList, filePath);
          



            // HttpResponseMessage result = null;
            // result = Request.CreateResponse(HttpStatusCode.OK);
            // result.Content = new StreamContent(new FileStream(path, FileMode.Open));
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            // result.Content.Headers.ContentDisposition.FileName = fileName;

            return Request.CreateResponse(HttpStatusCode.OK, fileName);
        }
        public string GenerateRSOExcel(List<SP_GET_RSOPOINT_WEB> targetFile, string filePath)
        {
            string result = "";
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet 
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("RSO_Point");

                ws.Cells[1, 1].Value = "SL NO";
                ws.Cells[1, 2].Value = "Date";
                ws.Cells[1, 3].Value = "Region";
                ws.Cells[1, 4].Value = "Distributor Code";
                ws.Cells[1, 5].Value = "RSO Code";
                ws.Cells[1, 6].Value = "SR Number";
                ws.Cells[1, 7].Value = "Total Points";


                for (int i = 0; i < targetFile.Count(); i++)
                {
                    ws.Cells[i + 2, 1].Value = i + 1;
                    ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).DATE_STR;
                    ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).REGION;
                    ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).DISTRIBUTOR_CODE;
                    ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).RSO_CODE;
                    ws.Cells[i + 2, 6].Value = targetFile.ElementAt(i).SR_NO;
                    ws.Cells[i + 2, 7].Value = targetFile.ElementAt(i).TOTAL_POINTS;
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
