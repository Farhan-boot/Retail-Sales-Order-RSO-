using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.SFTS;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.ProcessZone.Notice;
using APL.BL.SFTS.ProcessZone.Retailer;
using APL.BL.SFTS.Web.Areas.HelpPage;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace APL.BL.SFTS.Web.Areas.SFTS.api
{
    [RoutePrefix("SFTS/api/RetailerTarget")]
    public class RetailerTargetController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetRetailerTargets(object[] data)
        {
            IEnumerable<SP_FF_GET_RETAILER_TARGET> targetList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                targetList = new RetailerTargetPZ().GetRetailerTargets(objcmnParam.TargetId, objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                targetList
            });
        }

        [HttpPost]
        public IHttpActionResult GetTargetPeriodList(object[] data)
        {
            IEnumerable<SP_FF_GET_TARGET_PERIOD> targetPeriodList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                targetPeriodList = new RetailerTargetPZ().GetTargetPeriodList(objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                targetPeriodList
            });
        }
        [HttpPost]
        public IHttpActionResult GetTargetItemList(object[] data)
        {
            IEnumerable<SP_FF_GET_TARGET_ITEM> targetItemList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                targetItemList = new RetailerTargetPZ().GetTargetItemList(objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                targetItemList
            });
        }
        [HttpPost]
        public IHttpActionResult GetRetailTargetsTemp(object[] data)
        {
            IEnumerable<SP_FF_GET_RETAILER_TARGET> targetTempList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                targetTempList = new RetailerTargetPZ().GetRetailTargetsTemp(objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                targetTempList
            });
        }
        [HttpPost]
        public TargetForCodeValidity UploadAllFile(string product, decimal userId) // Check to work
        {
            TargetForCodeValidity tfcv = new TargetForCodeValidity();
            tfcv.InvalidCode = "0";
            tfcv.IsInvalidCode = true;
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
            string retailerTargetFilePath = System.Configuration.ConfigurationManager.AppSettings["RetailerTargetFilePath"];
            string fileName = "";
            if (hfc.Count > 0)
            {
                for (int i = 0; i < hfc.Count; i++)
                {
                    System.Web.HttpPostedFile hpf = hfc[i];

                    if (hpf != null && hpf.ContentLength > 0)
                    {
                        string exttension = System.IO.Path.GetExtension(hpf.FileName);
                        string directory = HttpContext.Current.Server.MapPath(retailerTargetFilePath);
                        string fileDir = directory + "/";

                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        if (exttension != "")
                        {
                            fileName = System.IO.Path.GetFileName(hpf.FileName);
                        }


                        string filePath = fileDir + fileName;

                        hpf.SaveAs(filePath);
                        hpf.InputStream.Dispose();

                    }
                }
                return tfcv;
            }
            else
            {
                return tfcv;
            }

        }
        [HttpPost]
        public TargetForCodeValidity SaveUploadAllFile(string product, decimal userId) // Check to work
        {
            TargetForCodeValidity tfcv = new TargetForCodeValidity();
            tfcv.InvalidCode = "0";
            tfcv.IsInvalidCode = true;
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
            string fileName = "";
            if (hfc.Count > 0)
            {
                for (int i = 0; i < hfc.Count; i++)
                {
                    System.Web.HttpPostedFile hpf = hfc[i];

                    if (hpf != null && hpf.ContentLength > 0)
                    {
                        string exttension = System.IO.Path.GetExtension(hpf.FileName);
                        string directory = HttpContext.Current.Server.MapPath("~/UserFiles/Notification");
                        string fileDir = directory + "/";

                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        if (exttension != "")
                        {
                            fileName = System.IO.Path.GetFileName(hpf.FileName);
                        }


                        string filePath = fileDir + fileName;

                        hpf.SaveAs(filePath);
                        hpf.InputStream.Dispose();

                        var retailerTargetList = ExcelForRetailerTarget(product, fileName);

                        decimal updateResult = new RetailerTargetPZ().SaveTargetToTemp(retailerTargetList, userId);
                    }
                }
                return tfcv;
            }
            else
            {
                return tfcv;
            }

        }
        public List<SP_FF_GET_RETAILER_TARGET> ExcelForRetailerTarget(string product, string fileName)
        {
            List<SP_FF_GET_RETAILER_TARGET> retailerTargetList = new List<SP_FF_GET_RETAILER_TARGET>();

            string fileExtension = Path.GetExtension(fileName);
            string directory = HttpContext.Current.Server.MapPath("~/UserFiles/Notification");
            string filePath = Path.Combine(directory, fileName);
            DataTable dtExcelRecords = new DataTable();
            dtExcelRecords = ExcelHelper.ReadExcelSheet(filePath, fileExtension, "Yes");
            foreach (DataRow data in dtExcelRecords.Rows)
            {
                if (data[0].ToString().Length > 0)
                {
                    SP_FF_GET_RETAILER_TARGET retailerTarget = new SP_FF_GET_RETAILER_TARGET();



                    string RETAILER_CODE = data[0].ToString();
                    retailerTarget.STAFF_CODE = RETAILER_CODE;

                    retailerTarget.STAFF_TYPE = data[1].ToString();
                    retailerTarget.TARGET = Convert.ToDecimal(data[2].ToString());

                    IEnumerable<SP_GET_RETAILERcls> objListRet = new NoticeSetupPZ().GetAllRetailer(RETAILER_CODE);
                    if (product == "5")
                    {
                        objListRet = objListRet.Where(w => w.SIMSELLER == 'Y').ToList();
                    }
                    else if (product == "3")
                    {
                        objListRet = objListRet.Where(w => w.ITOPUPSELLER == 'Y').ToList();
                    }
                    if (objListRet != null && objListRet.Count() > 0)
                    {
                        retailerTargetList.Add(retailerTarget);
                    }


                }
            }


            return retailerTargetList;
        }

        [HttpPost]
        public HttpResponseMessage SaveRetailerTarget(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                RetailerTarget retailerTarget = JsonConvert.DeserializeObject<RetailerTarget>(data[1].ToString());
                if (retailerTarget.TargetId == 0)
                {
                    retailerTarget.ActionFlag = 1;
                    retailerTarget.SetDate = retailerTarget.SetDate ?? DateTime.Now.ToString("dd/MM/yyyy");
                    retailerTarget.UpTo = retailerTarget.UpTo ?? DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    retailerTarget.ActionFlag = 2;
                }
                decimal updateResult = new RetailerTargetPZ().SaveRetailerTarget(retailerTarget, objcmnParam.UserId);

                result = updateResult > 0 ? updateResult.ToString() : result;
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                result = "";
            }


            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        
        [HttpPost]
        public HttpResponseMessage ExportExcelTemplate(object[] data)
        {
            vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
            RetailerTarget retailerTarget = JsonConvert.DeserializeObject<RetailerTarget>(data[1].ToString());

            retailerTarget.ActionFlag = 1;
            retailerTarget.SetDate = retailerTarget.SetDate;
            retailerTarget.UpTo = retailerTarget.UpTo;



            string fileName = "";



            if (objcmnParam.NoticeForId == 1)
            {
                fileName = "Template_Target_SSO" + "" + ".xlsx";
            }
            else if (objcmnParam.NoticeForId == 2)
            {
                fileName = "Template_Target_LSO" + "" + ".xlsx";
            }

            fileName = string.Concat(fileName);
            string directory = HttpContext.Current.Server.MapPath("~/UserFiles/");
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
                fileName = "Template_Target_SSO" + "" + ".xlsx";
                List<SP_GET_RETAILERcls> objListRet = new NoticeSetupPZ().GetAllRetailer(" ").Where(w => w.SIMSELLER == 'Y').ToList();

                GenerateTargetExcel(objListRet, 1, filePath, retailerTarget);
            }
            else if (objcmnParam.NoticeForId == 2)
            {
                fileName = "Template_Target_LSO" + "" + ".xlsx";
                List<SP_GET_RETAILERcls> objListRet = new NoticeSetupPZ().GetAllRetailer(" ").Where(w => w.ITOPUPSELLER == 'Y').ToList();

                GenerateTargetExcel(objListRet, 2, filePath, retailerTarget);
            }


            // HttpResponseMessage result = null;
            // result = Request.CreateResponse(HttpStatusCode.OK);
            // result.Content = new StreamContent(new FileStream(path, FileMode.Open));
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            // result.Content.Headers.ContentDisposition.FileName = fileName;

            return Request.CreateResponse(HttpStatusCode.OK, fileName);
        }
        public string GenerateTargetExcel(List<SP_GET_RETAILERcls> targetFile, int excelFor, string filePath, RetailerTarget retailerTarget)
        {
            string result = "";
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet 
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Template_Target");


                ws.Cells[1, 1].Value = "STAFF_CODE";
                ws.Cells[1, 2].Value = "STAFF_TYPE";
                ws.Cells[1, 3].Value = "TARGET";
                ws.Cells[1, 4].Value = "ProductId";
                ws.Cells[1, 5].Value = "PeriodId";
                ws.Cells[1, 6].Value = "SetDate";
                ws.Cells[1, 7].Value = "UpTo";

                ws.Cells[0 + 2, 4].Value = retailerTarget.ItemId;
                ws.Cells[0 + 2, 5].Value = retailerTarget.PeriodId;
                ws.Cells[0 + 2, 6].Value = retailerTarget.SetDate;
                ws.Cells[0 + 2, 7].Value = retailerTarget.UpTo;

                for (int i = 0; i < targetFile.Count(); i++)
                {

                    ws.Cells[i + 2, 1].Value = targetFile.ElementAt(i).RETAILER_CODE;
                    ws.Cells[i + 2, 2].Value = excelFor == 1 ? "SSO" : excelFor == 2 ? "LSO" : "";
                    ws.Cells[i + 2, 3].Value = "";
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
        public HttpResponseMessage DeleteInfo(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                RetailerTarget retailerTarget = JsonConvert.DeserializeObject<RetailerTarget>(data[1].ToString());

                if (retailerTarget.TargetId > 0)
                {
                    decimal updateResult = new RetailerTargetPZ().DeleteInfo(retailerTarget.TargetId);
                    result = updateResult > 0 ? updateResult.ToString() : result;
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                result = "";
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [HttpPost]
        public HttpResponseMessage DeleteRetailerTargetTemp(object[] data)
        {
            string result = "";

            try
            {

                decimal updateResult = new RetailerTargetPZ().DeleteRetailerTargetTemp();
                result = updateResult > 0 ? updateResult.ToString() : result;
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                result = "";
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
