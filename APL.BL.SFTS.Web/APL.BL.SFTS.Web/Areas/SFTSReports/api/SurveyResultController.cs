using APL.BL.SFTS.DataBridgeZone;
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
    [RoutePrefix("SFTSReports/api/SurveyResult")]
    public class SurveyResultController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetSurveyList(object[] data)
        {
            IEnumerable<SP_GET_SURVEYLISTcls> surveyList = null;
            try
            {
                decimal distributorID = 0;
                decimal _routeID = 0;
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                surveyList = new SurveyPZ().GetAllSurveyList(0, distributorID, _routeID);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                surveyList
            });
        }
        [HttpPost]
        public IHttpActionResult GetSurveyResult(object[] data)
        {
            List<SP_FF_GET_SURVEY> RSOStock = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                SearchParam objSearchParam = JsonConvert.DeserializeObject<SearchParam>(data[1].ToString());
                objSearchParam.TDate = objSearchParam.TDate ?? DateTime.Now.ToString("dd/MM/yyyy");
                RSOStock = new SurveyPZ().GetSurveyResult(objSearchParam);
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
            SearchParam objSearchParam = JsonConvert.DeserializeObject<SearchParam>(data[1].ToString());
            objSearchParam.TDate = objSearchParam.TDate ?? DateTime.Now.ToString("dd/MM/yyyy");
            var SurveyResult = new SurveyPZ().GetSurveyResult(objSearchParam);



            string fileName = "";

            fileName = "Survey_Result_" + DateTime.Now.Ticks + ".xlsx";



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



            GenerateRSOExcel(SurveyResult, filePath);




            // HttpResponseMessage result = null;
            // result = Request.CreateResponse(HttpStatusCode.OK);
            // result.Content = new StreamContent(new FileStream(path, FileMode.Open));
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            // result.Content.Headers.ContentDisposition.FileName = fileName;

            return Request.CreateResponse(HttpStatusCode.OK, fileName);
        }
        public string GenerateRSOExcel(List<SP_FF_GET_SURVEY> targetFile, string filePath)
        {
            string result = "";
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet 
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Survey Result");

                ws.Cells[1, 1].Value = "SL NO";
                ws.Cells[1, 2].Value = "Survey Name";
                ws.Cells[1, 3].Value = "Response Date";
                ws.Cells[1, 4].Value = "User Code";
                ws.Cells[1, 5].Value = "User Name";
                ws.Cells[1, 6].Value = "Survey Question";
                ws.Cells[1, 7].Value = "Survey Answer";


                for (int i = 0; i < targetFile.Count(); i++)
                {
                    ws.Cells[i + 2, 1].Value = i + 1;
                    ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).SURVEY_NAME;
                    ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).RES_DATE;
                    ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).USER_CODE;
                    ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).USER_NAME;
                    ws.Cells[i + 2, 6].Value = targetFile.ElementAt(i).SV_QST;
                    ws.Cells[i + 2, 7].Value = targetFile.ElementAt(i).SV_ANS;
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
