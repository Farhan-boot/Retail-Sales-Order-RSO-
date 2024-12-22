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
    [RoutePrefix("SFTSReports/api/Retailer")]
    public class RetailerController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRetailerSales(object[] data)
        {
            List<SP_GET_RETAILER_SALES> retailerSales = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                SearchParam objSearchParam = JsonConvert.DeserializeObject<SearchParam>(data[1].ToString());
                objSearchParam.FromDate = objcmnParam.FromDate;
                objSearchParam.ToDate = objcmnParam.ToDate;

                retailerSales = new RetailerPZ().GetRetailerSales(objSearchParam);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                retailerSales
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRetailerStock(object[] data)
        {
            List<SP_GET_RETAILER_STOCK> retailerStock = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                SearchParam objSearchParam = JsonConvert.DeserializeObject<SearchParam>(data[1].ToString());

                retailerStock = new RetailerPZ().GetRetailerStock(objSearchParam);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                retailerStock
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRetailerCommission(object[] data)
        {
            List<SP_GET_RETAILER_COMMISSION> retailerCommission = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                SearchParam objSearchParam = JsonConvert.DeserializeObject<SearchParam>(data[1].ToString());

                retailerCommission = new RetailerPZ().GetRetailerCommission(objSearchParam, objcmnParam.FromDate, objcmnParam.ToDate);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                retailerCommission
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRetailerLocationUpdate(object[] data)
        {
            List<SP_GET_RETAILER_LOCATION_UPDATE> retailerLocationUpdate = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                SearchParam objSearchParam = JsonConvert.DeserializeObject<SearchParam>(data[1].ToString());

                retailerLocationUpdate = new RetailerPZ().GetRetailerLocationUpdate(objSearchParam);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                retailerLocationUpdate
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetRetailerSaf(object[] data)
        {
            List<SP_GET_RETAILER_SAF> retailerSaf = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                SearchParam objSearchParam = JsonConvert.DeserializeObject<SearchParam>(data[1].ToString());

                retailerSaf = new RetailerPZ().GetRetailerSaf(objSearchParam, objcmnParam.FromDate, objcmnParam.ToDate);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                retailerSaf
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetNewRetailerInfo(object[] data)
        {
            IEnumerable<SP_GET_NEW_RETAILER_INFO> newRetailerRequestList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                newRetailerRequestList = new RetailerPZ().GetNewRetailerInfo(objcmnParam.RetailerModifyId, objcmnParam.StatusId, objcmnParam.FromDate, objcmnParam.ToDate);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                newRetailerRequestList
            });
        }
        [HttpPost]
        public HttpResponseMessage ExportExcelTemplate(object[] data)
        {
            List<SP_GET_RETAILER_SALES> retailerSales = null;


                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                SearchParam objSearchParam = JsonConvert.DeserializeObject<SearchParam>(data[1].ToString());
            objSearchParam.FromDate = objcmnParam.FromDate;
            objSearchParam.ToDate = objcmnParam.ToDate;
            retailerSales = new RetailerPZ().GetRetailerSales(objSearchParam);

            //    vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
            //SearchParam objSearchParam = JsonConvert.DeserializeObject<SearchParam>(data[1].ToString());
            //objSearchParam.TDate = objSearchParam.TDate ?? DateTime.Now.ToString("dd/MM/yyyy");
            //var RSOStock = new RSOSUpdateStockPZ().GetRSOStock(objSearchParam);



            string fileName = "";

            fileName = "RetailerSales.xlsx";



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



            GenerateRSOExcel(retailerSales, filePath);




            // HttpResponseMessage result = null;
            // result = Request.CreateResponse(HttpStatusCode.OK);
            // result.Content = new StreamContent(new FileStream(path, FileMode.Open));
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            // result.Content.Headers.ContentDisposition.FileName = fileName;

            return Request.CreateResponse(HttpStatusCode.OK, fileName);
        }
        public string GenerateRSOExcel(List<SP_GET_RETAILER_SALES> targetFile, string filePath)
        {
            string result = "";
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet 
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("RetailerSales");

                ws.Cells[1, 1].Value = "SL NO";
                ws.Cells[1, 2].Value = "Distributor Code";
                ws.Cells[1, 3].Value = "RSO Code";
                ws.Cells[1, 4].Value = "Retailer Code";
                ws.Cells[1, 5].Value = "Date";
                ws.Cells[1, 6].Value = "SIM Sales Prepaid";
                ws.Cells[1, 7].Value = "SIM Sales Postpaid";
                ws.Cells[1, 8].Value = "SIM Sales Swap";
                ws.Cells[1, 9].Value = "SIM Sales Duplicate Dial";
                ws.Cells[1, 10].Value = "itop-up Sales";
                ws.Cells[1, 11].Value = "SR Number";
                ws.Cells[1, 12].Value = "Superviser";
                ws.Cells[1, 13].Value = "TOS";


                for (int i = 0; i < targetFile.Count(); i++)
                {
                    ws.Cells[i + 2, 1].Value = i + 1;
                    ws.Cells[i + 2, 2].Value = targetFile.ElementAt(i).DISTRIBUTOR_CODE;
                    ws.Cells[i + 2, 3].Value = targetFile.ElementAt(i).RSO_CODE;
                    ws.Cells[i + 2, 4].Value = targetFile.ElementAt(i).RETAILER_CODE;
                    ws.Cells[i + 2, 5].Value = targetFile.ElementAt(i).DATE;
                    ws.Cells[i + 2, 6].Value = targetFile.ElementAt(i).SIM_SALES_PREPAID;
                    ws.Cells[i + 2, 7].Value = targetFile.ElementAt(i).SIM_SALES_POSTPAID;
                    ws.Cells[i + 2, 8].Value = targetFile.ElementAt(i).SIM_SALES_SWAP;
                    ws.Cells[i + 2, 9].Value = targetFile.ElementAt(i).SIM_SALES_DUPLICATE_DIAL;
                    ws.Cells[i + 2, 10].Value = targetFile.ElementAt(i).ITOPUP_TERRITORY;
                    ws.Cells[i + 2, 11].Value = targetFile.ElementAt(i).SR_NO;
                    ws.Cells[i + 2, 12].Value = targetFile.ElementAt(i).SUPERV_NAME;
                    ws.Cells[i + 2, 13].Value = targetFile.ElementAt(i).TOS;
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
