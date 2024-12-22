using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.ProcessZone.Notice;
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
    [RoutePrefix("SFTS/api/NotificationSetup")]
    public class NotificationSetupController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetRegions(object[] data)
        {
            IEnumerable<GET_REGION> objListRegion = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListRegion = new NoticeSetupPZ().GetRegions();
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
        [HttpPost]
        public IHttpActionResult GetDistributors(object[] data)
        {
            IEnumerable<SP_GET_DISTRIBUTOR_BY_REG_IDcls> objListDistributor = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                objListDistributor = new NoticeSetupPZ().GetDistributor(objcmnParam.RegionId, 0, 0);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListDistributor
            });
        }
        [HttpPost]
        public IHttpActionResult GetNoticeTypeList(object[] data)
        {
            IEnumerable<SP_FF_GET_NOTIFICATION_TYPE> objListCenterType = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objcmnParam.CenterTypeId = 0;
                objListCenterType = new NoticeSetupPZ().GetNotificationTypes(objcmnParam.CenterTypeId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objListCenterType
            });
        }
        [HttpPost]
        public IHttpActionResult GetNoticeForList(object[] data)
        {
            List<NOTICE_FOR> noticeForList = new List<NOTICE_FOR>();
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                if (objcmnParam.NoticeType_Id == 1)
                {
                    NOTICE_FOR nOTICE_FOR1 = new NOTICE_FOR { ID = 1, Name = "National" };
                    noticeForList.Add(nOTICE_FOR1);
                    NOTICE_FOR nOTICE_FOR2 = new NOTICE_FOR { ID = 2, Name = "Region" };
                    noticeForList.Add(nOTICE_FOR2);
                    NOTICE_FOR nOTICE_FOR3 = new NOTICE_FOR { ID = 3, Name = "Distributor" };
                    noticeForList.Add(nOTICE_FOR3);
                    NOTICE_FOR nOTICE_FOR4 = new NOTICE_FOR { ID = 4, Name = "RSO" };
                    noticeForList.Add(nOTICE_FOR4);
                }
                if(objcmnParam.NoticeType_Id==2)
                {
                    NOTICE_FOR nOTICE_FOR1 = new NOTICE_FOR { ID = 1, Name = "National" };
                    noticeForList.Add(nOTICE_FOR1);
                    //NOTICE_FOR nOTICE_FOR2 = new NOTICE_FOR { ID = 2, Name = "Region" };
                    //noticeForList.Add(nOTICE_FOR2);
                    //NOTICE_FOR nOTICE_FOR3 = new NOTICE_FOR { ID = 3, Name = "Distributor" };
                    //noticeForList.Add(nOTICE_FOR3);
                    NOTICE_FOR nOTICE_FOR4 = new NOTICE_FOR { ID = 4, Name = "RSO" };
                    noticeForList.Add(nOTICE_FOR4);
                    NOTICE_FOR nOTICE_FOR5 = new NOTICE_FOR { ID = 5, Name = "Retailer" };
                    noticeForList.Add(nOTICE_FOR5);
                }
                if (objcmnParam.NoticeType_Id == 3)
                {
                    NOTICE_FOR nOTICE_FOR1 = new NOTICE_FOR { ID = 1, Name = "National" };
                    noticeForList.Add(nOTICE_FOR1);
                    NOTICE_FOR nOTICE_FOR2 = new NOTICE_FOR { ID = 2, Name = "Region" };
                    noticeForList.Add(nOTICE_FOR2);
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                noticeForList
            });
        }
        [HttpPost]
        public IHttpActionResult GetNoticeList(object[] data)
        {
            IEnumerable<SP_FF_GET__NOTICE_LIST> noticeList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                noticeList = new NoticeSetupPZ().GetNoticeList(objcmnParam.Notice_Id, objcmnParam.loggeduser);
                if(objcmnParam.NoticeType_Id>0)
                noticeList= noticeList.Where(w=>w.NOTICE_TYPE_ID== objcmnParam.NoticeType_Id).ToList();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                noticeList
            });
        }

        
       
        [HttpPost]
        public HttpResponseMessage SaveUploadAllFile() // Check to work
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
            //System.Web.HttpPostedFile hpf = hfc[0];
            string fileName = "";
            if (hfc.Count>0)
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
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        hpf.SaveAs(filePath);
                        hpf.InputStream.Dispose();
                        
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, fileName);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "");
            }

        }
      

        public List<NoticeUser> ExcelForRSONotice(decimal NoticeId_New, NoticeSetup notice, string fileName)
        {
            List<NoticeUser> noticeUsers = new List<NoticeUser>();

            string fileExtension = Path.GetExtension(fileName);
            string directory = HttpContext.Current.Server.MapPath("~/UserFiles/Notification");
            string filePath = Path.Combine(directory, fileName);
            DataTable dtExcelRecords = new DataTable();
            dtExcelRecords = ExcelHelper.ReadExcelSheet(filePath, fileExtension, "Yes");
            foreach (DataRow data in dtExcelRecords.Rows)
            {
                if (data[0].ToString().Length > 0)
                {
                    NoticeUser noticeUser = new NoticeUser();
                    noticeUser.NoticeId = NoticeId_New;
                    string RSO_CODE = data[0].ToString();

                    noticeUser.Message_Eng = data[1].ToString()==""? notice.Message : data[1].ToString();
                    noticeUser.Message_Ban = data[2].ToString();

                    IEnumerable<SP_GET_RSOcls> objListRso = new NoticeSetupPZ().GetAllRso(RSO_CODE);
                    if (objListRso != null && objListRso.Count() > 0)
                    {
                        noticeUser.RegionDdRsoId = objListRso.FirstOrDefault().RSO_ID;
                        noticeUsers.Add(noticeUser);
                    }
                   
                }
            }

            return noticeUsers;
        }

        public List<NoticeUser> ExcelForRetailerNotice(decimal NoticeId_New, NoticeSetup notice, string fileName)
        {
            List<NoticeUser> noticeUsers = new List<NoticeUser>();

            string fileExtension = Path.GetExtension(fileName);
            string directory = HttpContext.Current.Server.MapPath("~/UserFiles/Notification");
            string filePath = Path.Combine(directory, fileName);
            DataTable dtExcelRecords = new DataTable();
            dtExcelRecords = ExcelHelper.ReadExcelSheet(filePath, fileExtension, "Yes");
            foreach (DataRow data in dtExcelRecords.Rows)
            {
                if (data[0].ToString().Length > 0)
                {
                    NoticeUser noticeUser = new NoticeUser();
                    noticeUser.NoticeId = NoticeId_New;
                    string RETAILER_CODE = data[0].ToString();

                    noticeUser.Message_Eng = data[1].ToString() == "" ? notice.Message : data[1].ToString();
                    noticeUser.Message_Ban = data[2].ToString();

                    IEnumerable<SP_GET_RETAILERcls> objListRet = new NoticeSetupPZ().GetAllRetailer(RETAILER_CODE);
                    if (objListRet != null && objListRet.Count() > 0)
                    {
                        noticeUser.RegionDdRsoId = objListRet.FirstOrDefault().RETAILER_ID;
                        noticeUsers.Add(noticeUser);
                    }
                   
                }
            }

               return noticeUsers;
        }

        [HttpPost]
        public HttpResponseMessage ExportExcelTemplate(object[] data)
        {
            vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());


            
            string fileName = "";
            if (objcmnParam.NoticeForId == 1)
            {
                fileName = "Template_RSO.xlsx";
            }
            else if (objcmnParam.NoticeForId == 2)
            {
                fileName = "Template_Retailer.xlsx";
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

            if(objcmnParam.NoticeForId==1)
            {
                List<SP_GET_RSOcls> objListRso = new NoticeSetupPZ().GetAllRso(" ");
                GenerateRSOExcel(objListRso, filePath);
            }
            else if (objcmnParam.NoticeForId == 2)
            {
                List<SP_GET_RETAILERcls> objListRet = new NoticeSetupPZ().GetAllRetailer(" ").ToList();
                GenerateRetailerExcel(objListRet, filePath);
            }


            // HttpResponseMessage result = null;
            // result = Request.CreateResponse(HttpStatusCode.OK);
            // result.Content = new StreamContent(new FileStream(path, FileMode.Open));
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            // result.Content.Headers.ContentDisposition.FileName = fileName;

            return Request.CreateResponse(HttpStatusCode.OK, fileName);
        }

        public string GenerateRSOExcel(List<SP_GET_RSOcls> targetFile, string filePath)
        {
            string result = "";
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet 
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("RSO_Message");

               // ws.Cells[1, 1].Value = "SL NO";
                ws.Cells[1, 1].Value = "RSO_CODE";
                ws.Cells[1, 2].Value = "MESSAGE";
                ws.Cells[1, 3].Value = "";


                for (int i = 0; i < targetFile.Count(); i++)
                {
                    //ws.Cells[i + 2, 1].Value = i + 1;
                    ws.Cells[i + 2, 1].Value = targetFile.ElementAt(i).RSO_CODE;
                    ws.Cells[i + 2, 2].Value = "";
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
        public string GenerateRetailerExcel(List<SP_GET_RETAILERcls> targetFile, string filePath)
        {
            string result = "";
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet 
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Retailer_Message");

                //ws.Cells[1, 1].Value = "SL NO";
                ws.Cells[1, 1].Value = "RETAILER_CODE";
                ws.Cells[1, 2].Value = "MESSAGE";
                ws.Cells[1, 3].Value = "";


                for (int i = 0; i < targetFile.Count(); i++)
                {
                    //ws.Cells[i + 2, 1].Value = i + 1;
                    ws.Cells[i + 2, 1].Value = targetFile.ElementAt(i).RETAILER_CODE;
                    ws.Cells[i + 2, 2].Value = "";
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
        public HttpResponseMessage SaveNotification(object[] data)
        {
            string result = "";

            try
            {
                System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

                

                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                NoticeSetup notice = JsonConvert.DeserializeObject<NoticeSetup>(data[1].ToString());
                List<GET_ID> noticeRegionList = JsonConvert.DeserializeObject<List<GET_ID>>(data[2].ToString());
                List<GET_ID> noticeDistributorList = JsonConvert.DeserializeObject<List<GET_ID>>(data[3].ToString());
                List<NoticeUser> noticeUsers = new List<NoticeUser>();// JsonConvert.DeserializeObject<List<NoticeUser>>(data[2].ToString());
                List<NoticeTime> noticeTimes = new List<NoticeTime>();// JsonConvert.DeserializeObject<List<NoticeUser>>(data[2].ToString());
               
                

                decimal NoticeId_New = new NoticeSetupPZ().SaveNotification(notice.NoticeId, notice.NoticeTypeId, notice.NoticeForId, notice.FromDate, notice.ToDate, notice.Title, notice.Message, notice.Url, notice.FileName, notice.IsActive,  objcmnParam.loggeduser, notice.FlashTimes,noticeRegionList);
                if(NoticeId_New > 0)
                {
                    if(notice.NoticeForId == 2)
                    {
                        foreach (var item in noticeRegionList)
                        {
                            if (item.Id>0)
                            {
                                NoticeUser user = new NoticeUser();
                                user.NoticeId = NoticeId_New;
                                user.RegionDdRsoId = item.Id;
                                noticeUsers.Add(user);
                            }
                        }
                    }
                    if (notice.NoticeForId == 3)
                    {
                        foreach (var item in noticeDistributorList)
                        {
                            if (item.Id > 0)
                            {
                                NoticeUser user = new NoticeUser();
                                user.NoticeId = NoticeId_New;
                                user.RegionDdRsoId = item.Id;
                                noticeUsers.Add(user);
                            }
                        }
                    }
                    if (notice.NoticeForId == 4 && notice.ExcelFileName!="")
                    {
                        noticeUsers = ExcelForRSONotice(NoticeId_New, notice, notice.ExcelFileName);
                    }
                    else    if (notice.NoticeForId==5 && notice.RtExcelFileName != "")
                    {
                        noticeUsers = ExcelForRetailerNotice(NoticeId_New, notice, notice.RtExcelFileName);
                    }
                    if(notice.NoticeTypeId==3)
                    {
                        foreach (var item in notice.FlashTimes.Replace("#", "").Split(','))
                        {
                            if(item.Trim()!="")
                            {
                                NoticeTime nTime = new NoticeTime();
                                nTime.NoticeId = NoticeId_New;
                                nTime.NtcTime = item.Trim();
                                noticeTimes.Add(nTime);
                            }
                           
                        }
                    }
                    decimal updateResult1 = new NoticeSetupPZ().SaveNotificationUsersAndTimes(noticeUsers, noticeTimes);
                }
                result = NoticeId_New > 0 ? NoticeId_New.ToString() : result;
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                result = "";
            }


            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        public IHttpActionResult GetNotificationSetupReg(object[] data)
        {
            IEnumerable<SP_GET_ALL_DISTRIBUTOR> noticeReg = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                noticeReg = new NoticeSetupPZ().GetNotificationSetupReg(objcmnParam.Notice_Id);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                noticeReg
            });
        }
        [HttpPost]
        public IHttpActionResult GetNotificationSetupDis(object[] data)
        {
            IEnumerable<SP_GET_ALL_DISTRIBUTOR> noticeDis = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                noticeDis = new NoticeSetupPZ().GetNotificationSetupDis(objcmnParam.Notice_Id);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                noticeDis
            });
        }
        [HttpPost]
        public HttpResponseMessage DeleteInfo(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                NoticeSetup notice = JsonConvert.DeserializeObject<NoticeSetup>(data[1].ToString());

                if (notice.NoticeId > 0)
                {
                    decimal updateResult = new NoticeSetupPZ().DeleteInfo(notice.NoticeId);
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
    }
}
