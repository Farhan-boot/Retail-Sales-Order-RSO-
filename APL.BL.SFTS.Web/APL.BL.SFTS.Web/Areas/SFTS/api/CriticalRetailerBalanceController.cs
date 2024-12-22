using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.SFTS;
using APL.BL.SFTS.Models.SystemCommon;
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
    [RoutePrefix("SFTS/api/CriticalRetailerBalance")]
    public class CriticalRetailerBalanceController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetCriticalBalances(object[] data)
        {
            IEnumerable<SP_GET_CRTL_RETAILER_BALANCE> balanceList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                balanceList = new CriticalRetailerBalancePZ().GetCriticalBalances(objcmnParam.CriticalBalanceId, objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                balanceList
            });
        }
        [HttpPost]
        public IHttpActionResult GetCriticalBalancesTemp(object[] data)
        {
            IEnumerable<SP_GET_CRTBALANCE_TEMP> balanceTempList = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                balanceTempList = new CriticalRetailerBalancePZ().GetCriticalBalancesTemp( objcmnParam.loggeduser);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                balanceTempList
            });
        }
        [HttpPost]
        public TargetForCodeValidity SaveUploadAllFile(string product,decimal userId) // Check to work
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

						if (System.IO.File.Exists(filePath))
						{
							System.IO.File.Delete(filePath);
						}

						if (!File.Exists(filePath))
                        {
                            hpf.SaveAs(filePath);
                            hpf.InputStream.Dispose();
                        }
                       var retailerBallanceList=    ExcelForCriticalBalance(product,fileName);

                        decimal updateResult = new CriticalRetailerBalancePZ().SaveBalanceToTemp(retailerBallanceList, userId);
                    }
                }
                return tfcv;
            }
            else
            {
                return tfcv;
            }

        }
        public List<SP_GET_CRTL_RETAILER_BALANCE> ExcelForCriticalBalance(string product, string fileName)
        {
            List<SP_GET_CRTL_RETAILER_BALANCE> criticalBalanceList = new List<SP_GET_CRTL_RETAILER_BALANCE>();

            string fileExtension = Path.GetExtension(fileName);
            string directory = HttpContext.Current.Server.MapPath("~/UserFiles/Notification");
            string filePath = Path.Combine(directory, fileName);
            DataTable dtExcelRecords = new DataTable();
            dtExcelRecords = ExcelHelper.ReadExcelSheet(filePath, fileExtension, "Yes");
            foreach (DataRow data in dtExcelRecords.Rows)
            {
                SP_GET_CRTL_RETAILER_BALANCE criticalBalance = new SP_GET_CRTL_RETAILER_BALANCE();

                
				if (data[0].ToString().Length > 0)
				{
					string RETAILER_CODE = data[0].ToString();
					criticalBalance.RETAILER_CODE = RETAILER_CODE;
					criticalBalance.PRODUCT_NAME = product;
					criticalBalance.SATURDAY = Convert.ToDecimal(data[1].ToString());
					criticalBalance.SUNDAY = Convert.ToDecimal(0);
					criticalBalance.MONDAY = Convert.ToDecimal(0);
					criticalBalance.TUESDAY = Convert.ToDecimal(0);
					criticalBalance.WEDNESDAY = Convert.ToDecimal(0);
					criticalBalance.THURSDAY = Convert.ToDecimal(0);
					criticalBalance.FRIDAY = Convert.ToDecimal(0);
					if (data[2].ToString() != "")
						criticalBalance.FROM_DATE = Convert.ToDateTime(data[2].ToString()).Date.ToString("yyyy/MM/dd");
					if (data[3].ToString() != "")
						criticalBalance.TO_DATE = Convert.ToDateTime(data[3].ToString()).Date.ToString("yyyy/MM/dd");
					SP_GET_DD_RETAILER_INFO retailerInfo = new CriticalRetailerBalancePZ().GetRetailerDistributorInfo(RETAILER_CODE);
					if (retailerInfo != null)
					{
						criticalBalance.DISTRIBUTOR_CODE = retailerInfo.DISTRIBUTOR_CODE;

					}
					if (criticalBalance.DISTRIBUTOR_CODE != "")
					{
						criticalBalanceList.Add(criticalBalance);
					}

				}				

            }



            return criticalBalanceList;
        }

        [HttpPost]
        public HttpResponseMessage SaveCriticalBalance(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                CriticalBalance criticalBalance = JsonConvert.DeserializeObject<CriticalBalance>(data[1].ToString());
                if (criticalBalance.CriticalBalanceId == 0)
                {
                    criticalBalance.ActionFlag = 1;
                    criticalBalance.FromDate = criticalBalance.FromDate ?? DateTime.Now.ToString("dd/MM/yyyy");
                    criticalBalance.ToDate = criticalBalance.ToDate ?? DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    criticalBalance.ActionFlag = 2;
                }
                decimal updateResult = new CriticalRetailerBalancePZ().SaveCriticalBalance(criticalBalance, objcmnParam.UserId);

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
        public HttpResponseMessage DeleteCriticalBalanceTemp()
        {
            string result = "";

            try
            {
    
                decimal updateResult = new CriticalRetailerBalancePZ().DeleteCriticalBalanceTemp();

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
