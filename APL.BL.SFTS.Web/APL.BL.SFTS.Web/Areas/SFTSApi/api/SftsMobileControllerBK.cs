using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.ProcessZone.RSO;
using APL.BL.SFTS.ProcessZone.Sales;
using APL.BL.SFTS.ProcessZone.Target;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml;

namespace APL.BL.SFTS.Web.Areas.SFTSApi.api
{
    [RoutePrefix("SFTSApi/api/SftsMobile")]
    public class SftsMobileController : ApiController
    {

        #region Authentication
        //for ApiToken
        public string GenerateToken(string userid, string password)
        {
            string Id = Guid.NewGuid().ToString("N");
            string userAgent = "User-Agent";
            string message = string.Join(":", new string[] { userid, Id, userAgent });
            string key = password ?? "";

            var encoding = new System.Text.ASCIIEncoding();

            byte[] keyByte = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(message);

            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        public decimal InsertToken(string userName, string token, string version)
        {
            decimal result = 0;
            decimal appId = 1133;
            result = new GenerateTokenPZ().InsertToken(userName, token, appId, version);

            return result;
        }

        // for ApiToken
        public bool ValidateToken(CmnParam cmnParam)
        {
            bool isValid = false;
            decimal result = 0;
            result = new GenerateTokenPZ().ValidateToken(cmnParam.UserId, cmnParam.Token);
            isValid = result > 0 ? true : false;
            return isValid;
        }


        [ResponseType(typeof(Authentication))]
        [HttpPost]
        public Authentication Login(object data)
        {
            Authentication auth = new Authentication();
            vmLoginUser loginUser = JsonConvert.DeserializeObject<vmLoginUser>(data.ToString());
            decimal appId = 1133;
            string Token = "";
            try
            {
                List<SP_GET_USER_AUTHENTICATION> userInfo = new UserInfoPZ().GetLogInAuthentication(loginUser.UserLogin.Trim(), loginUser.Password.Trim(), appId);

                if (userInfo != null && userInfo.Count > 0)
                {
                    Token = GenerateToken(loginUser.UserLogin, loginUser.Password);
                    decimal TokenSaveResult = InsertToken(loginUser.UserLogin, Token, loginUser.Version);
                    if (TokenSaveResult > 0)
                    {
                        auth.UserId = Convert.ToInt32(userInfo[0].USER_ID);
                        auth.Status = userInfo[0].STATUS == 1 ? true : false;
                        auth.Token = Token;
                        auth.RsoId = Convert.ToInt64(userInfo[0].RSO_ID);
                        auth.RsoCode = Convert.ToString(userInfo[0].USER_CODE);
                        auth.RsoName = Convert.ToString(userInfo[0].USER_NAME);
                    }
                }
                else
                {
                    auth.Status = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return auth;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult LogOut(object data)
        {
            SaveResult saveResult = new SaveResult();
            try
            {
                CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

                if (ValidateToken(cmnParam))
                {
                    Decimal result = 0;
                    result = new GenerateTokenPZ().TokenExpiration(cmnParam.UserId, cmnParam.Token);

                    saveResult.Result = Convert.ToInt64(result);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return saveResult;
        }

        #endregion Authentication

        #region Monobrand

        [ResponseType(typeof(GetCurrentOffer))]
        [HttpPost]
        public GetCurrentOffer GetCurrentOffers(object data)
        {
            GetCurrentOffer getCurrentOffer = new GetCurrentOffer();
            getCurrentOffer.status_code = 400;
            List<SP_GET_CURRENT_OFFER> getCurrentOfferList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getCurrentOfferList = new CurrentOfferPZ().GetCurrentOffer(cmnParam.UserId);
                    getCurrentOffer.data = getCurrentOfferList;
                    getCurrentOffer.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getCurrentOffer;
        }

        [ResponseType(typeof(GetMessage))]
        [HttpPost]
        public GetMessage GetMessages(object[] data)
        {
            GetMessage getMessage = new GetMessage();
            getMessage.status_code = 400;
            List<SP_GET_MESSAGE> getMessageList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getMessageList = new VisitPlanPZ().GetMessages();
                    getMessage.data = getMessageList;
                    getMessage.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getMessage;
        }

        [ResponseType(typeof(SP_GET_SHOP_VISIT_PLAN))]
        [HttpPost]
        public List<SP_GET_SHOP_VISIT_PLAN> GetShopVisitPlan(object[] data)
        {
            List<SP_GET_SHOP_VISIT_PLAN> visitPlanList = null;

            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            GetVisitPlan getVisitPlan = JsonConvert.DeserializeObject<GetVisitPlan>(data[1].ToString());
            getVisitPlan.EntityType = 2;
            if (ValidateToken(cmnParam))
            {
                try
                {
                    visitPlanList = new VisitPlanPZ().GetShopVisitPlan(getVisitPlan.EntityType, getVisitPlan.VisitType, getVisitPlan.VisitDate, getVisitPlan.StaffUserId, getVisitPlan.Status);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return visitPlanList;
        }


        [ResponseType(typeof(GetShopStock))]
        [HttpPost]
        public GetShopStock GetShopCurrentStock(object[] data)
        {
            GetShopStock objShopStock = new GetShopStock();
            objShopStock.status_code = 400;
            List<SP_GET_SHOP_STOCK> getStockList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Shop shop = JsonConvert.DeserializeObject<Shop>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getStockList = new VisitPlanPZ().GetShopCurrentStock(shop.ShopId);
                    objShopStock.data = getStockList;
                    objShopStock.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objShopStock;
        }


        [ResponseType(typeof(SP_GET_FEEDBACK_QUESTION))]
        [HttpPost]
        public List<SP_GET_FEEDBACK_QUESTION> GetFeedbackQuestionList(object[] data)
        {
            List<SP_GET_FEEDBACK_QUESTION> feedbackQuestionList = null;
            try
            {
                CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
                GetFeedbackQuestion getQuestion = JsonConvert.DeserializeObject<GetFeedbackQuestion>(data[1].ToString());

                if (ValidateToken(cmnParam))
                {
                    feedbackQuestionList = new VisitPlanPZ().GetFeedbackQuestionList(getQuestion.VisitId, getQuestion.RetailerId, getQuestion.QuestionnaireId, getQuestion.QuestionId);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return feedbackQuestionList;
        }


        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult CancelVisit(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            try
            {
                CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
                GetVisitPlan visitPlan = JsonConvert.DeserializeObject<GetVisitPlan>(data[1].ToString());

                DateTime locationValidAt = DateTime.Now;

                if (ValidateToken(cmnParam))
                {
                    decimal Result = 0;

                    Result = new VisitPlanPZ().CancelVisit(visitPlan.VisitPlanId);
                    saveResult.Result = Convert.ToInt64(Result);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return saveResult;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult SaveUpdateVisit(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            try
            {
                CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
                Visit visit = JsonConvert.DeserializeObject<Visit>(data[1].ToString());
                List<FeedbackQuestionAnswer> listFeedbackQA = JsonConvert.DeserializeObject<List<FeedbackQuestionAnswer>>(data[2].ToString());

                if (ValidateToken(cmnParam))
                {
                    decimal Result = 0;
                    if (visit.VisitId == 0) { visit.VisitId = new GetNewIdDZ().GetNewId("SQ_FF_VISIT"); }

                    Result = new VisitPlanPZ().SaveUpdateVisit(visit.VisitId, visit.VisitPlanId, visit.StaffUserId, visit.EntityType, visit.CenterId, visit.RetailerId, visit.VisitTimeLat, visit.VisitTimeLong, visit.FeedbackStatusId, visit.FeedbackDescription, visit.EntityOtherId, visit.EntityOtherTypeName, visit.EntityOtherName, visit.EntityOrArea, visit.VisitTypeId, cmnParam.UserId, cmnParam.UserId, visit.ReviewedBy, visit.LocationIsValid, visit.LocationValidAt, visit.LocationDiffDistance, listFeedbackQA);
                    saveResult.Result = Convert.ToInt64(Result);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return saveResult;
        }

        [ResponseType(typeof(GetShopTargetAchive))]
        [HttpPost]
        public GetShopTargetAchive GetShopTargetVsAchivement(object[] data)
        {
            GetShopTargetAchive objTargetAchive = new GetShopTargetAchive();
            ShopTargetAchivement objShopTarget = new ShopTargetAchivement();
            objTargetAchive.status_code = 400;
            List<SP_GET_SHOP_TARGET_ACHIVE> getTargetAchive = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Shop shop = JsonConvert.DeserializeObject<Shop>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getTargetAchive = new VisitPlanPZ().GetShopTargetVsAchivement(shop.ShopId);

                    if (getTargetAchive.Count > 0)
                    {
                        objShopTarget.MonthNo = getTargetAchive[0].MonthNo;
                        objShopTarget.TargetAchive = getTargetAchive;
                        objTargetAchive.data = objShopTarget;
                        objTargetAchive.status_code = 200;
                    }
                    else
                    {
                        objTargetAchive.data = objShopTarget;
                        objTargetAchive.status_code = 200;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objTargetAchive;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult SaveUpdateVisitPlan(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            try
            {
                CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
                List<GetVisitPlan> visitPlanList = JsonConvert.DeserializeObject<List<GetVisitPlan>>(data[1].ToString());

                DateTime locationValidAt = DateTime.Now;

                if (ValidateToken(cmnParam))
                {
                    decimal Result = 0;
                    foreach (GetVisitPlan visitPlan in visitPlanList)
                    {
                        Result = new VisitPlanPZ().SaveUpdateVisitPlan(visitPlan.VisitPlanId, visitPlan.VisitDate, visitPlan.StaffUserId, visitPlan.EntityType, visitPlan.CenterId, cmnParam.UserId, visitPlan.VisitType);
                    }
                    saveResult.Result = Convert.ToInt64(Result);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return saveResult;
        }


        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult SaveUpdateClosingRequest(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            try
            {
                CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
                ClosingStatus closingStatus = JsonConvert.DeserializeObject<ClosingStatus>(data[1].ToString());

                if (ValidateToken(cmnParam))
                {
                    decimal Result = 0;

                    Result = new VisitPlanPZ().SaveUpdateClosingStatus(closingStatus.ClosingStatusId, closingStatus.CenterId, closingStatus.StatusDate, closingStatus.StatusDescription, closingStatus.ClosingTime, closingStatus.CreatedBy);
                    saveResult.Result = Convert.ToInt64(Result);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return saveResult;
        }


        [ResponseType(typeof(GetCurrentOfferPicture))]
        [HttpPost]
        public GetCurrentOfferPicture GetCurrentOfferPictures(object[] data)
        {
            GetCurrentOfferPicture objCurrentOfferPic = new GetCurrentOfferPicture();
            objCurrentOfferPic.status_code = 400;
            List<GET_OFFER_PICTURES> getOfferPicture = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            CurrentOffer currentOffer = JsonConvert.DeserializeObject<CurrentOffer>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getOfferPicture = new VisitPlanPZ().GetCurrentOfferPictures(0, currentOffer.CurrentOfferId, currentOffer.PictureSlNo);
                    objCurrentOfferPic.data = getOfferPicture;
                    objCurrentOfferPic.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objCurrentOfferPic;
        }

        [ResponseType(typeof(GetShopClosingStatus))]
        [HttpPost]
        public GetShopClosingStatus GetShopClosingStatus(object[] data)
        {
            GetShopClosingStatus objShopClosingStatus = new GetShopClosingStatus();
            objShopClosingStatus.status_code = 400;
            List<GET_SHOP_CLOSING_STATUS> getShopClosingStatusList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            ClosingStatus closingStatus = JsonConvert.DeserializeObject<ClosingStatus>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getShopClosingStatusList = new VisitPlanPZ().GetShopClosingStatus(closingStatus.StatusDate);
                    objShopClosingStatus.data = getShopClosingStatusList;
                    objShopClosingStatus.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }
            return objShopClosingStatus;
        }

        [ResponseType(typeof(GetCenters))]
        [HttpPost]
        public GetCenters GetCenters(object data)
        {
            GetCenters objGetComplain = new GetCenters();
            objGetComplain.status_code = 400;
            List<SP_GET_CENTERS> getComplainList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getComplainList = new VisitPlanPZ().GetCenters(0, 2);
                    objGetComplain.data = getComplainList;
                    objGetComplain.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objGetComplain;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult UpdateShopLocation(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            try
            {
                CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
                CenterLocationUpdate centerLocation = JsonConvert.DeserializeObject<CenterLocationUpdate>(data[1].ToString());

                if (ValidateToken(cmnParam))
                {
                    decimal Result = 0;

                    Result = new VisitPlanPZ().CenterLocationUpdate(centerLocation.CenterId, centerLocation.LatValue, centerLocation.LongValue);
                    saveResult.Result = Convert.ToInt64(Result);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return saveResult;
        }
        #endregion Monobrand

        #region Distribution Channel

        [ResponseType(typeof(GetVisitPlanSummary))]
        [HttpPost]
        public GetVisitPlanSummary GetVisitPlanSummary(object data)
        {
            GetVisitPlanSummary getVisitPlanSummary = new GetVisitPlanSummary();
            getVisitPlanSummary.status_code = 400;
            List<SP_GET_VISIT_PLAN_SUMMARY> getVisitPlanSummaryList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getVisitPlanSummaryList = new RSOVisitPlanPZ().GetVisitPlanSummary(0, cmnParam.UserId);
                    getVisitPlanSummary.data = getVisitPlanSummaryList;
                    getVisitPlanSummary.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getVisitPlanSummary;
        }
        
        [ResponseType(typeof(GetTodayHighlights))]
        [HttpPost]
        public GetTodayHighlights GetTodayHighlights(object data)
        {
            GetTodayHighlights getTodayHighlight = new GetTodayHighlights();
            GetHighlights getHighlights = new GetHighlights();
            getTodayHighlight.status_code = 400;          
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getHighlights = new RSOVisitPlanPZ().GetTodayHighlights(0, cmnParam.UserId);

                    getTodayHighlight.data = getHighlights;
                    getTodayHighlight.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getTodayHighlight;
        }

        [ResponseType(typeof(GetProducts))]
        [HttpPost]
        public GetProducts GetProducts(object data)
        {
            GetProducts getProducts = new GetProducts();
            List<SP_GET_PRODUCT> products = new List<SP_GET_PRODUCT>();
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    products = new ProductInfoPZ().GetProducts(0);
                    getProducts.data = products;
                    getProducts.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getProducts;
        }

        //Product Delivery

        [ResponseType(typeof(GetProdFrmSl))]
        [HttpPost]
        public GetProdFrmSl GetProductFromSl(object data)
        {
            GetProdFrmSl getProdsFrmSl = new GetProdFrmSl();
            GetProdFrmSerial getProdFrmSerial = new GetProdFrmSerial();
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());
             
            if (ValidateToken(cmnParam))
            {
                try
                {
                    getProdFrmSerial = new ProductInfoPZ().GetProductFromSerial(cmnParam.UserId, cmnParam.RetailerId, cmnParam.ProdTypeId, cmnParam.StartSl, cmnParam.EndSl);
                    getProdsFrmSl.data = getProdFrmSerial;
                    getProdsFrmSl.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getProdsFrmSl;
        }
            
        [ResponseType(typeof(GetSimSts))]
        [HttpPost]
        public GetSimSts GetSimStatus(object data)
        {
            GetSimSts getSimSts = new GetSimSts();
            GetSimStatus getSimStatus = new GetSimStatus();
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getSimStatus = new ProductInfoPZ().GetSimStatus(cmnParam.UserId, cmnParam.SimNo);
                    getSimSts.data = getSimStatus;
                    getSimSts.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getSimSts;
        }
          
        [ResponseType(typeof(TopupIssueRetailer))]
        [HttpPost]
        public TopupIssue SaveTopupIssueToRetailer(object[] data)
        {
            TopupIssue topupIssue = new TopupIssue();
            TopupIssueRetailer topupIssueRetailer = new TopupIssueRetailer();
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            GetTopupIssueRetailer getTopupIssue = JsonConvert.DeserializeObject<GetTopupIssueRetailer>(data[1].ToString());
             
            if (ValidateToken(cmnParam))
            {
                try
                {
                    topupIssueRetailer = new ProductInfoPZ().SaveTopupIssueToRetailer(getTopupIssue.RetailerId, cmnParam.UserId, getTopupIssue.PassCode, getTopupIssue.TopupAmt, getTopupIssue.VisitId, getTopupIssue.Latitude, getTopupIssue.Longitude);
                    topupIssue.data = topupIssueRetailer;
                    topupIssue.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return topupIssue;
        }

        [ResponseType(typeof(GetTopupIssueHistory))]
        [HttpPost]
        public GetTopupIssueHistory GetTodaysTopupIssueHistory(object data)
        {
            GetTopupIssueHistory getTopupIssue = new GetTopupIssueHistory();

            List<SP_GET_TOPUP_ISSUE> topupIssueList = null;

            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    topupIssueList = new SalesMemoPZ().GetTodaysTopupIssueHistory(cmnParam.UserId, cmnParam.RetailerId, cmnParam.FromDate, cmnParam.ToDate, cmnParam.TopupIssueStatus);
                    getTopupIssue.data = topupIssueList;
                    getTopupIssue.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getTopupIssue;
        }

        [ResponseType(typeof(GetIssueStatus))]
        [HttpPost]
        public GetIssueStatus GetTopupIssueStatus(object data)
        {
            GetIssueStatus getIssueStatus = new GetIssueStatus();
            GetTopupIssueStatus getTopupIssueStatus = new GetTopupIssueStatus();
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getTopupIssueStatus = new SalesMemoPZ().GetTopupIssueStatus(cmnParam.IssueId);
                    getIssueStatus.data = getTopupIssueStatus;
                    getIssueStatus.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getIssueStatus;
        }
         
        [ResponseType(typeof(GetRetailerTopupBalance))]
        [HttpPost]
        public GetRetailerTopupBalance GetRetailerBalance(object data)
        {
            string serviceResult = "";
            GetRetailerTopupBalance getBalance = new GetRetailerTopupBalance();
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    string date = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");

                    HttpWebRequest request = HttpWebRequest.Create("http://10.10.80.9:7890/csms/C2SReceiver") as HttpWebRequest;
                    request.ContentType = "text/xml;charset=\"utf-8\"";
                    request.Accept = "text/xml";
                    request.Method = "POST";
                    XmlDocument reqBody = new XmlDocument();
                    reqBody.LoadXml(@"<?xml version=""1.0"">  
                    <!DOCTYPE COMMAND PUBLIC ""-//Ocam//DTD XML Command 1.0//EN"" ""xml/command.dtd"">  
                     <COMMAND>
	                      <TYPE>EXUSRBALREQ</TYPE>
                          <DATE>" + date + "</DATE>" +
	                      "<EXTNWCODE>BD</EXTNWCODE>" +
	                      "<MSISDN>"+ cmnParam.MSISDN +"</MSISDN>" +
	                      "<PIN>"+ cmnParam.PinNo +"</PIN>" +
	                      "<LOGINID>" + cmnParam.UserId + "</LOGINID>" +
	                      "<PASSWORD>" +cmnParam.Password +"</PASSWORD>" +
	                      "<EXTCODE></EXTCODE>" +
	                      "<EXTREFNUM></EXTREFNUM>" +
                          "<LANGUAGE1>0</LANGUAGE1>" +
                     "</COMMAND>");

                    using (Stream stream = request.GetRequestStream())
                    {
                        reqBody.Save(stream);
                    }

                    using (WebResponse Serviceres = request.GetResponse())
                    {
                        using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                        {
                            var ServiceResult = rd.ReadToEnd();
                            serviceResult = ServiceResult;
                        }
                    }

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(serviceResult);
                    serviceResult = JsonConvert.SerializeXmlNode(doc);

                    getBalance.data = serviceResult;
                    getBalance.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getBalance;
        }

        [ResponseType(typeof(GetRetTopupStatus))]
        [HttpPost]
        public GetRetTopupStatus GetRetailerTopupBalance(object data)
        {
            GetRetTopupStatus getTopupStatus = new GetRetTopupStatus();
            List<SP_GET_RET_TOPUP_STATUS> listTopupStatus = new List<SP_GET_RET_TOPUP_STATUS>();
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    listTopupStatus = new ProductInfoPZ().GetRetailerTopupBalance(cmnParam.RetailerId);
                    getTopupStatus.data = listTopupStatus;
                    getTopupStatus.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getTopupStatus;
        }

        [ResponseType(typeof(GetMemoNo))]
        [HttpPost]
        public GetMemoNo GetTempMemoId(object[] data)
        {
            GetMemoNo memoNo = new GetMemoNo();
            memoNo.status_code = 400;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Retailer retailer = JsonConvert.DeserializeObject<Retailer>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    memoNo.TempMemoId = new GetNewIdDZ().GetNewId("SQ_FF_TEMP_MEMO_ID");
               
                    memoNo.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return memoNo;
        }

          
        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult SaveProductDelivery(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            saveResult.Result = 0;
            saveResult.status_code = 400;
            
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            SalesMemo salesMemo = JsonConvert.DeserializeObject<SalesMemo>(data[1].ToString());
            List<SalesMemoProduct> newMemoProducts = JsonConvert.DeserializeObject<List<SalesMemoProduct>>(data[2].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    decimal savedMemoId = 0;
                    decimal savedMemoProductId = 0;
                    decimal savedMemoProductSerialId = 0;
                    decimal savedMemoCompletedId = 0;

                    savedMemoId = new SalesMemoPZ().SaveSalesMemo(salesMemo.MemoId, salesMemo.MemoDate, salesMemo.CustomerId, salesMemo.ProdTypeId, salesMemo.GrossAmount, salesMemo.NetAmount, salesMemo.VisitId, salesMemo.Latitude, salesMemo.Longitude, cmnParam.UserId);

                    foreach (SalesMemoProduct smp in newMemoProducts)
                    {
                        savedMemoProductId = new SalesMemoPZ().SaveSalesMemoProduct(smp.Id, salesMemo.MemoId, smp.ProductId, smp.SalesQty, smp.Price, smp.Remarks, cmnParam.UserId);

                        foreach (SalesMemoProductSerial smps in smp.salesMemoProdSls)
                        {
                            savedMemoProductSerialId = new SalesMemoPZ().SaveMemoProductSerial(smps.Id, savedMemoProductId, smps.ProductId, smps.StartSerial, smps.EndSerial, smps.Quantity, smps.TotalQty, cmnParam.UserId);
                        }
                    }

                    if(savedMemoProductSerialId > 0)
                    {
                        savedMemoCompletedId = new SalesMemoPZ().SaveSalesMemoComplited(salesMemo.MemoId, cmnParam.UserId);
                    }

                    saveResult.Result = savedMemoCompletedId > 0 ? 1 : 0;
                    saveResult.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            
            return saveResult;
        }


        [ResponseType(typeof(GetDeliveryStatus))]
        [HttpPost]
        public GetDlivStatus GetMemoDeliveryStatus(object data)
        {
            GetDlivStatus getDelivStatus = new GetDlivStatus();
            GetDeliveryStatus getDeliveryStatus = new GetDeliveryStatus();
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getDeliveryStatus = new SalesMemoPZ().GetMemoDeliveryStatus(cmnParam.TempMemoId);
                    getDelivStatus.data = getDeliveryStatus;
                    getDelivStatus.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getDelivStatus;
        }

        //Product Return

        [ResponseType(typeof(GetProdFrmSl))]
        [HttpPost]
        public GetProdFrmSl GetProductForReturn(object data)
        {
            GetProdFrmSl getProdsFrmSl = new GetProdFrmSl();
            GetProdFrmSerial getProdFrmSerial = new GetProdFrmSerial();
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getProdFrmSerial = new ProductInfoPZ().GetProductForReturn(cmnParam.UserId, cmnParam.RetailerId, cmnParam.ProdTypeId, cmnParam.StartSl, cmnParam.EndSl);
                    getProdsFrmSl.data = getProdFrmSerial;
                    getProdsFrmSl.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getProdsFrmSl;
        }
         
        [ResponseType(typeof(GetProdRetrnId))]
        [HttpPost]
        public GetProdRetrnId GetProdReturnId(object[] data)
        {
            GetProdRetrnId getReturnId = new GetProdRetrnId();
            getReturnId.status_code = 400;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Retailer retailer = JsonConvert.DeserializeObject<Retailer>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getReturnId.ProdReturnId = new GetNewIdDZ().GetNewId("SQ_FF_SALES_REURN_ID");

                    getReturnId.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getReturnId;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult SaveProductReturn(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            saveResult.Result = 0;
            saveResult.status_code = 400;

            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            SalesReturn salesReturn = JsonConvert.DeserializeObject<SalesReturn>(data[1].ToString());
            List<SalesReturnProduct> salesReturnProducts = JsonConvert.DeserializeObject<List<SalesReturnProduct>>(data[2].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    decimal savedReturnId = 0;
                    decimal savedReturnProductId = 0;
                    decimal savedReturnProductSerialId = 0;
                    decimal savedReturnCompletedId = 0;

                    savedReturnId = new SalesMemoPZ().SaveSalesReturn(salesReturn.ReturnId, salesReturn.ReturnDate, salesReturn.CustomerId, salesReturn.ProdTypeId, salesReturn.VisitId, salesReturn.Latitude, salesReturn.Longitude, cmnParam.UserId);

                    foreach (SalesReturnProduct smp in salesReturnProducts)
                    {
                        savedReturnProductId = new SalesMemoPZ().SaveSalesReturnProduct(smp.Id, salesReturn.ReturnId, smp.ProductId, smp.ReturnQty, smp.Remarks, cmnParam.UserId);

                        foreach (SalesReturnProductSerial smps in smp.salesReturnProdSls)
                        {
                            savedReturnProductSerialId = new SalesMemoPZ().SaveReturnProductSerial(smps.Id, savedReturnProductId, smps.ProductId, smps.StartSerial, smps.EndSerial, smps.Quantity, smps.TotalQty, cmnParam.UserId);
                        }
                    }
                     
                    if (savedReturnProductSerialId > 0)
                    {
                        savedReturnCompletedId = new SalesMemoPZ().SaveSalesReturnComplited(salesReturn.ReturnId, cmnParam.UserId);
                    }

                    saveResult.Result = savedReturnCompletedId > 0 ? 1 : 0;
                    saveResult.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return saveResult;
        }
         
        [ResponseType(typeof(GetReturnStatus))]
        [HttpPost]
        public GetReturnStatus GetProductReturnStatus(object data)
        {
            GetReturnStatus getReturnStatus = new GetReturnStatus();
            GetProdReturnStatus getProdReturnStatus = new GetProdReturnStatus();
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());
              
            if (ValidateToken(cmnParam))
            {
                try
                {
                    getProdReturnStatus = new SalesMemoPZ().GetProductReturnStatus(cmnParam.ReturnId);
                    getReturnStatus.data = getProdReturnStatus;
                    getReturnStatus.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getReturnStatus;
        }



        [ResponseType(typeof(GetRetailerDashboardSummary))]
        [HttpPost]
        public GetRetailerDashboardSummary GetRetailerDashboardInfo(object[] data)
        {
            GetRetailerDashboardSummary getRetailerDashboardSummary = new GetRetailerDashboardSummary();
            getRetailerDashboardSummary.status_code = 400;
            List<SP_GET_RETAILER_DASHBOARD_INFO> getRetailerDashboardSummaryList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Retailer retailer = JsonConvert.DeserializeObject<Retailer>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getRetailerDashboardSummaryList = new RSOVisitPlanPZ().GetRetailerDashboardInfo(retailer.RetailerId);
                    getRetailerDashboardSummary.data = getRetailerDashboardSummaryList;
                    getRetailerDashboardSummary.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getRetailerDashboardSummary;
        }

        [ResponseType(typeof(GetVistPlan))]
        [HttpPost]
        public GetVistPlan GetRSOVisitPlan(object[] data)
        {
            GetVistPlan visitPlan = new GetVistPlan();

            List<SP_GET_RETAILER_VISIT_PLAN> visitPlanList = null;

            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            GetVisitPlan getVisitPlan = JsonConvert.DeserializeObject<GetVisitPlan>(data[1].ToString());
            getVisitPlan.EntityType = 3;

            if (ValidateToken(cmnParam))
            {
                try
                {
                    visitPlanList = new VisitPlanPZ().GetRetailerVisitPlan(getVisitPlan.EntityType, getVisitPlan.VisitType, getVisitPlan.VisitDate, getVisitPlan.StaffUserId, getVisitPlan.Status);
                    visitPlan.data = visitPlanList;
                    visitPlan.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return visitPlan;
        }

        [ResponseType(typeof(GetLiftingDetail))]
        [HttpPost]
        public GetLiftingDetail GetLastLiftingDetail(object[] data)
        {
            GetLiftingDetail liftingDetail = new GetLiftingDetail();

            List<SP_GET_LIFTING_DETAIL> liftingDetailList = null;

            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Retailer retailer = JsonConvert.DeserializeObject<Retailer>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    liftingDetailList = new VisitPlanPZ().GetLiftingDetail(retailer.RetailerId);
                    liftingDetail.data = liftingDetailList;
                    liftingDetail.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return liftingDetail;
        }

        [ResponseType(typeof(GetMemo))]
        [HttpPost]
        public GetMemo GetMemo(object[] data)
        {
            GetMemo getMemo = new GetMemo();

            List<SP_GET_MEMO> memoList = null;

            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            SalesMemo memo = JsonConvert.DeserializeObject<SalesMemo>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    memoList = new SalesMemoPZ().GetMemo(memo.MemoNo);
                    getMemo.data = memoList;
                    getMemo.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getMemo;
        }

        [ResponseType(typeof(GetSalesMemo))]
        [HttpPost]
        public GetSalesMemo GetSalesMemo(object data)
        {
            GetSalesMemo getMemo = new GetSalesMemo();

            List<SP_GET_SALES_MEMO> memoList = null;

            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    memoList = new SalesMemoPZ().GetSalesMemo(cmnParam.UserId, cmnParam.RetailerId, cmnParam.FromDate, cmnParam.ToDate, cmnParam.MemoId);
                    getMemo.data = memoList;
                    getMemo.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getMemo;
        }

        
        [ResponseType(typeof(GetCommissionStructurePicture))]
        [HttpPost]
        public GetCommissionStructurePicture GetCommissionStracturePictures(object[] data)
        {
            GetCommissionStructurePicture objCommissionStructurePic = new GetCommissionStructurePicture();
            objCommissionStructurePic.status_code = 400;
            List<GET_COMMISSION_PICTURES> getCommissionPicture = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            CommissionStructure commissionStructure = JsonConvert.DeserializeObject<CommissionStructure>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getCommissionPicture = new VisitPlanPZ().GetCommissionPictures(0, commissionStructure.CommissionTypeId, commissionStructure.PictureSlNo);
                    objCommissionStructurePic.data = getCommissionPicture;
                    objCommissionStructurePic.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objCommissionStructurePic;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult SaveUpdateRetailerCreateReq(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            saveResult.Result = 0;
            saveResult.status_code = 400;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            RetailerCreateRequest retailerCreateReq = JsonConvert.DeserializeObject<RetailerCreateRequest>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    decimal SavedRetailerCreateReq = 0;
                    retailerCreateReq.RequestedBy = cmnParam.UserId;
                    retailerCreateReq.RequestStatus = 1;
                    SavedRetailerCreateReq = new RetailerPZ().SaveUpdateRetailerCreateReq(retailerCreateReq);

                    saveResult.Result = SavedRetailerCreateReq > 0 ? 1 : 0;
                    saveResult.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return saveResult;
        }

        [ResponseType(typeof(GetRetailerCreateRequest))]
        [HttpPost]
        public GetRetailerCreateRequest GetNewOutletRequestStatus(object[] data)
        {
            GetRetailerCreateRequest getRetailerCreateReq = new GetRetailerCreateRequest();

            List<SP_GET_RETAILER_CREATE_REQUEST> RetailerRequestList = null;

            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Params prms = JsonConvert.DeserializeObject<Params>(data[1].ToString());
            if (ValidateToken(cmnParam))
            {
                try
                {
                    RetailerRequestList = new RetailerPZ().GetRetailerCreateRequest(cmnParam.UserId, prms.DateFrom, prms.DateTo);
                    getRetailerCreateReq.data = RetailerRequestList;
                    getRetailerCreateReq.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getRetailerCreateReq;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public MarketUpdateSaveResult SaveUpdateMarketUpdate(object[] data)
        {
            MarketUpdateSaveResult saveResult = new MarketUpdateSaveResult();
            saveResult.status_code = 400;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            MarketUpdate marketUpdate = JsonConvert.DeserializeObject<MarketUpdate>(data[1].ToString());
            List<SP_GET_SAVE_RESULT_WITH_ERROR_CODE> resultWithErrorCode = new List<SP_GET_SAVE_RESULT_WITH_ERROR_CODE>();

            if (ValidateToken(cmnParam))
            {
                try
                {
                    marketUpdate.CreatedBy = cmnParam.UserId;
                    marketUpdate.EventId = marketUpdate.EventId == 0 ? null : marketUpdate.EventId;

                    resultWithErrorCode = new RetailerPZ().SaveUpdateMarketUpdate(marketUpdate);

                    saveResult.data = resultWithErrorCode;
                    saveResult.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return saveResult;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult SaveUpdateSafCollection(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            saveResult.Result = 0;
            saveResult.status_code = 400;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            SafCollectionLog safCollection = JsonConvert.DeserializeObject<SafCollectionLog>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    decimal SavedSafCollectionId = 0;
                    safCollection.UserId = cmnParam.UserId;

                    SavedSafCollectionId = new RetailerPZ().SaveUpdateSafCollection(safCollection);

                    saveResult.Result = SavedSafCollectionId > 0 ? 1 : 0;
                    saveResult.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return saveResult;
        }

        [ResponseType(typeof(GetSafCollectionLog))]
        [HttpPost]
        public GetSafCollectionLog CollectedSafList(object[] data)
        {
            GetSafCollectionLog safCollLog = new GetSafCollectionLog();

            List<GET_SAF_COLL> safCollList = null;

            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Retailer retailer = JsonConvert.DeserializeObject<Retailer>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    safCollList = new RetailerPZ().GetCollectedSaf(retailer);
                    safCollLog.data = safCollList;
                    safCollLog.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return safCollLog;
        }

        [ResponseType(typeof(GetCommissionHistory))]
        [HttpPost]
        public GetCommissionHistory CommissionHistory(object[] data)
        {
            GetCommissionHistory getCommHistory = new GetCommissionHistory();

            List<GET_COMMISSION_HISTORY> commissionHistoryList = null;

            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Retailer retailer = JsonConvert.DeserializeObject<Retailer>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    commissionHistoryList = new RetailerPZ().GetCommissionHistory(0, retailer.RetailerId);
                    getCommHistory.data = commissionHistoryList;
                    getCommHistory.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getCommHistory;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult SaveUpdateRetailerModifyReq(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            saveResult.Result = 0;
            saveResult.status_code = 400;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            RetailerModifyRequest retailerModifyReq = JsonConvert.DeserializeObject<RetailerModifyRequest>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    decimal SavedRetailerModifyReq = 0;
                    SavedRetailerModifyReq = new RetailerPZ().SaveUpdateRetailerModifyReq(retailerModifyReq);

                    saveResult.Result = SavedRetailerModifyReq > 0 ? 1 : 0;
                    saveResult.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return saveResult;
        }

        [ResponseType(typeof(GetFocProducts))]
        [HttpPost]
        public GetFocProducts GetFOCProducts(object data)
        {
            GetFocProducts getProducts = new GetFocProducts();
            List<SP_GET_FOC_PRODUCT> products = new List<SP_GET_FOC_PRODUCT>();
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    products = new ProductInfoPZ().GetFOCProducts(0);
                    getProducts.data = products;
                    getProducts.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getProducts;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult SaveUpdateFOCProductIssue(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            saveResult.Result = 0;
            saveResult.status_code = 400;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            TradeMaterialIssue tradeMaterialIssue = JsonConvert.DeserializeObject<TradeMaterialIssue>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    decimal SEQMaterialIssueId = new GetNewIdDZ().GetNewId("SQ_FF_TRADE_MAT_ISSUE_ID");
                    tradeMaterialIssue.Id = SEQMaterialIssueId;
                    tradeMaterialIssue.ReceiverType = 1;
                    tradeMaterialIssue.IssuedByUser = cmnParam.UserId;
                    tradeMaterialIssue.CreatedBy = cmnParam.UserId;
                    decimal SavedFocProductIssueId = 0;
                    SavedFocProductIssueId = new RetailerPZ().SaveUpdateFOCProductIssue(tradeMaterialIssue);

                    saveResult.Result = SavedFocProductIssueId > 0 ? 1 : 0;
                    saveResult.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return saveResult;
        }

        [ResponseType(typeof(GetFocIssuedProduct))]
        [HttpPost]
        public GetFocIssuedProduct GetFOCIssuedProducts(object[] data)
        {
            GetFocIssuedProduct focIssuedProduct = new GetFocIssuedProduct();

            List<SP_GET_TRADE_MATERIAL_ISSUE> issuedMaterialList = null;

            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Retailer retailer = JsonConvert.DeserializeObject<Retailer>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    issuedMaterialList = new RetailerPZ().GetFOCIssuedMaterial(retailer.RetailerId, cmnParam.UserId);
                    focIssuedProduct.data = issuedMaterialList;
                    focIssuedProduct.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return focIssuedProduct;
        }

        [ResponseType(typeof(GetSalesAndStock))]
        [HttpPost]
        public GetSalesAndStock GetSalesAndStock(object[] data)
        {
            GetSalesAndStock salesAndStock = new GetSalesAndStock();

            List<SP_GET_SALES_STOCK> salesAndStockList = null;

            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Retailer retailer = JsonConvert.DeserializeObject<Retailer>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    salesAndStockList = new RetailerPZ().GetSalesAndStock(retailer.RetailerId, cmnParam.UserId);
                    salesAndStock.data = salesAndStockList;
                    salesAndStock.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return salesAndStock;
        }

        [ResponseType(typeof(GetCurrentOffer))]
        [HttpPost]
        public GetCurrentOffer GetRetailerCurrentOffers(object[] data)
        {
            GetCurrentOffer getCurrentOffer = new GetCurrentOffer();
            getCurrentOffer.status_code = 400;
            List<SP_GET_CURRENT_OFFER> getCurrentOfferList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Retailer retailer = JsonConvert.DeserializeObject<Retailer>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getCurrentOfferList = new CurrentOfferPZ().GetRetailerCurrentOffer(retailer.RetailerId);
                    getCurrentOffer.data = getCurrentOfferList;
                    getCurrentOffer.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getCurrentOffer;
        }

        [ResponseType(typeof(GetCurrentOfferPicture))]
        [HttpPost]
        public GetCurrentOfferPicture GetRetailerCurrentOfferPictures(object[] data)
        {
            GetCurrentOfferPicture objCurrentOfferPic = new GetCurrentOfferPicture();
            objCurrentOfferPic.status_code = 400;
            List<GET_OFFER_PICTURES> getOfferPicture = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            CurrentOffer currentOffer = JsonConvert.DeserializeObject<CurrentOffer>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getOfferPicture = new VisitPlanPZ().GetRetailerCurrentOfferPictures(0, currentOffer.CurrentOfferId, currentOffer.PictureSlNo);
                    objCurrentOfferPic.data = getOfferPicture;
                    objCurrentOfferPic.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objCurrentOfferPic;
        }

        [ResponseType(typeof(GetCurrentOffer))]
        [HttpPost]
        public GetCurrentOffer GetRSOCurrentOffers(object data)
        {
            GetCurrentOffer getCurrentOffer = new GetCurrentOffer();
            getCurrentOffer.status_code = 400;
            List<SP_GET_CURRENT_OFFER> getCurrentOfferList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getCurrentOfferList = new CurrentOfferPZ().GetRSOCurrentOffer(cmnParam.UserId);
                    getCurrentOffer.data = getCurrentOfferList;
                    getCurrentOffer.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getCurrentOffer;
        }

        [ResponseType(typeof(GetCurrentOfferPicture))]
        [HttpPost]
        public GetCurrentOfferPicture GetRSOCurrentOfferPictures(object[] data)
        {
            GetCurrentOfferPicture objCurrentOfferPic = new GetCurrentOfferPicture();
            objCurrentOfferPic.status_code = 400;
            List<GET_OFFER_PICTURES> getOfferPicture = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            CurrentOffer currentOffer = JsonConvert.DeserializeObject<CurrentOffer>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getOfferPicture = new VisitPlanPZ().GetCurrentOfferPictures(0, currentOffer.CurrentOfferId, currentOffer.PictureSlNo);
                    objCurrentOfferPic.data = getOfferPicture;
                    objCurrentOfferPic.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objCurrentOfferPic;
        }

        [ResponseType(typeof(GetRetailerCurrentInfo))]
        [HttpPost]
        public GetRetailerCurrentInfo GetRetailerCurrentInfo(object[] data)
        {
            GetRetailerCurrentInfo getRetailerCurrentInfo = new GetRetailerCurrentInfo();
            getRetailerCurrentInfo.status_code = 400;
            List<SP_GET_RETAILER_CURRENT_INFO> getRetailerCurrentInfoList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Retailer retailer = JsonConvert.DeserializeObject<Retailer>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getRetailerCurrentInfoList = new RetailerPZ().GetRetailerCurrentInfo(retailer.RetailerId);
                    getRetailerCurrentInfo.data = getRetailerCurrentInfoList[0];
                    getRetailerCurrentInfo.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getRetailerCurrentInfo;
        }

        [ResponseType(typeof(GetRsoTargetVsAchivement))]
        [HttpPost]
        public GetRsoTargetVsAchivement GetRSOTargetVsAchivement(object[] data)
        {
            GetRsoTargetVsAchivement getRsoTargetAchive = new GetRsoTargetVsAchivement();
            getRsoTargetAchive.status_code = 400;
            List<SP_GET_RSO_TARGET_ACHIVEMENT> RsoTargetAchiveList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            RSO rso = JsonConvert.DeserializeObject<RSO>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    RsoTargetAchiveList = new RsoPZ().GetRsoTargetAchive(cmnParam.UserId, rso.MonthCount);
                    getRsoTargetAchive.data = RsoTargetAchiveList;
                    getRsoTargetAchive.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getRsoTargetAchive;
        }

        [ResponseType(typeof(GetRsoRouteWiseRetailer))]
        [HttpPost]
        public GetRsoRouteWiseRetailer GetRSORoutes(object data)
        {
            GetRsoRouteWiseRetailer getRsoRoutes = new GetRsoRouteWiseRetailer();
            getRsoRoutes.status_code = 400;
            List<GetRsoRoute> routeList = new List<GetRsoRoute>();
            List<SP_GET_ROUTE> RsoRouteList = null;
            List<SP_GET_RETAILER_ROUTE> retailerList = new List<SP_GET_RETAILER_ROUTE>();
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    RsoRouteList = new RsoPZ().GetRsoRoutes(cmnParam.UserId, cmnParam.DayName);
                    foreach (SP_GET_ROUTE rsoRoute in RsoRouteList)
                    {
                        GetRsoRoute objRsoRoute = new GetRsoRoute();
                        retailerList = new RsoPZ().GetRetailerByRoute(rsoRoute.ROUTE_ID);
                        objRsoRoute.RETAILER = retailerList;
                        objRsoRoute.ROUTE_ID = rsoRoute.ROUTE_ID;
                        objRsoRoute.ROUTE_NAME = rsoRoute.ROUTE_NAME;
                        objRsoRoute.ROUTE_CODE = rsoRoute.ROUTE_CODE;
                        routeList.Add(objRsoRoute);
                    }

                    getRsoRoutes.data = routeList;
                    getRsoRoutes.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getRsoRoutes;
        }




        [ResponseType(typeof(GetMarketUpdateType))]
        [HttpPost]
        public GetMarketUpdateType GetMarketUpdateTypes(object data)
        {
            GetMarketUpdateType getMarketUpdateType = new GetMarketUpdateType();
            getMarketUpdateType.status_code = 400;
            List<GET_DROPDOWN> MarketUpdateTypeList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    MarketUpdateTypeList = new RsoPZ().GetMarketUpdateTypes(0);
                    getMarketUpdateType.data = MarketUpdateTypeList;
                    getMarketUpdateType.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getMarketUpdateType;
        }

        [ResponseType(typeof(GetOperatorCode))]
        [HttpPost]
        public GetOperatorCode GetOperatorCodes(object data)
        {
            GetOperatorCode getOperatorCode = new GetOperatorCode();
            getOperatorCode.status_code = 400;
            List<GET_DROPDOWN> OperatorCodeList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    OperatorCodeList = new RsoPZ().GetOperatorCode();
                    getOperatorCode.data = OperatorCodeList;
                    getOperatorCode.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getOperatorCode;
        }

        [ResponseType(typeof(GetEventInfo))]
        [HttpPost]
        public GetEventInfo GetEventInfo(object data)
        {
            GetEventInfo getEventInfo = new GetEventInfo();
            getEventInfo.status_code = 400;
            List<GET_EVENT_INFO> EventList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    EventList = new RsoPZ().GetEventInfo(0, cmnParam.UserId);
                    getEventInfo.data = EventList;
                    getEventInfo.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getEventInfo;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult SaveMarketUpdatePictures(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            saveResult.Result = 0;
            saveResult.status_code = 400;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            MarketUpdatePicture marketUpdatePic = JsonConvert.DeserializeObject<MarketUpdatePicture>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    decimal SavedMarketUpdateId = 0;

                    SavedMarketUpdateId = new RetailerPZ().SaveUpdateMarketUpdatePicture(marketUpdatePic);

                    saveResult.Result = SavedMarketUpdateId;
                    saveResult.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return saveResult;
        }

        [ResponseType(typeof(GetMarketUpdateType))]
        [HttpPost]
        public GetDistrict GetDistricts(object data)
        {
            GetDistrict getDistrict = new GetDistrict();
            getDistrict.status_code = 400;
            List<GET_DROPDOWN> districtList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    districtList = new RsoPZ().GetDistricts(0, cmnParam.UserId);
                    getDistrict.data = districtList;
                    getDistrict.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getDistrict;
        }

        [ResponseType(typeof(GetMarketUpdateType))]
        [HttpPost]
        public GetThana GetThanas(object[] data)
        {
            GetThana getThana = new GetThana();
            getThana.status_code = 400;
            List<GET_DROPDOWN> thanaList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Thana thana = JsonConvert.DeserializeObject<Thana>(data[1].ToString());
            if (ValidateToken(cmnParam))
            {
                try
                {
                    thanaList = new RsoPZ().GetThanas(thana.DistrictId, cmnParam.UserId);
                    getThana.data = thanaList;
                    getThana.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getThana;
        }

        [ResponseType(typeof(GetCommissionStructure))]
        [HttpPost]
        public GetCommissionStructure GetCommissionStructure(object[] data)
        {
            GetCommissionStructure getCommissionStracture = new GetCommissionStructure();
            getCommissionStracture.status_code = 400;
            List<SP_GET_COMMISSION_STRUCTURE> getCommissionStructureList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Params parms = JsonConvert.DeserializeObject<Params>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getCommissionStructureList = new CurrentOfferPZ().GetCommissionStructureEntityWise(cmnParam.UserId, parms.EntityType);
                    getCommissionStracture.data = getCommissionStructureList;
                    getCommissionStracture.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getCommissionStracture;
        }

        [ResponseType(typeof(GetCommissionStructurePicture))]
        [HttpPost]
        public GetCommissionStructurePicture GetCommissionStructurePictures(object[] data)
        {
            GetCommissionStructurePicture objCommissionPic = new GetCommissionStructurePicture();
            objCommissionPic.status_code = 400;
            List<GET_COMMISSION_PICTURES> getCommissionStructure = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            CommissionPic commStrct = JsonConvert.DeserializeObject<CommissionPic>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getCommissionStructure = new VisitPlanPZ().GetCommissionPictures(0, commStrct.CommissionStructureId, commStrct.PictureSlNo);
                    objCommissionPic.data = getCommissionStructure;
                    objCommissionPic.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objCommissionPic;
        }

        [ResponseType(typeof(GetRetailerBestPractice))]
        [HttpPost]
        public GetRetailerBestPractice GetRetailerBestPractice(object[] data)
        {
            GetRetailerBestPractice getRetailerBestPractice = new GetRetailerBestPractice();
            getRetailerBestPractice.status_code = 400;
            IEnumerable<SP_GET_BEST_RETAILER_PRACTICE> bestRetailerPracticeList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Retailer retailer = JsonConvert.DeserializeObject<Retailer>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    bestRetailerPracticeList = new RetailerPZ().GetAllBestRetailerPractice(0, retailer.RetailerId);
                    getRetailerBestPractice.data = bestRetailerPracticeList;
                    getRetailerBestPractice.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getRetailerBestPractice;
        }

        [ResponseType(typeof(GetRSOBestPractice))]
        [HttpPost]
        public GetRSOBestPractice GetRSOBestPractice(object[] data)
        {
            GetRSOBestPractice getRSOestPractice = new GetRSOBestPractice();
            getRSOestPractice.status_code = 400;
            IEnumerable<SP_GET_BEST_RSO_PRACTICE> bestRsoPracticeList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            RSO rso = JsonConvert.DeserializeObject<RSO>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    bestRsoPracticeList = new RsoPZ().GetAllBestRsoPractice(0, rso.RsoId);
                    getRSOestPractice.data = bestRsoPracticeList;
                    getRSOestPractice.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getRSOestPractice;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult SaveRetailerCheckout(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            saveResult.Result = 0;
            saveResult.status_code = 400;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            RetailerCheckout retailerCheckout = JsonConvert.DeserializeObject<RetailerCheckout>(data[1].ToString());
            retailerCheckout.CreatedBy = cmnParam.UserId;

            if (ValidateToken(cmnParam))
            {
                try
                {
                    decimal SavedId = 0;
                    retailerCheckout.CreatedBy = cmnParam.UserId;

                    SavedId = new RetailerPZ().SaveUpdateRetailerCheckout(retailerCheckout);

                    saveResult.Result = SavedId;
                    saveResult.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return saveResult;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult UpdateRetailerLocation(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            saveResult.Result = 0;
            saveResult.status_code = 400;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            RetailerLocationUpdate retailerLocation = JsonConvert.DeserializeObject<RetailerLocationUpdate>(data[1].ToString());

            try
            {
                if (ValidateToken(cmnParam))
                {
                    decimal result = 0;

                    result = new VisitPlanPZ().RetailerLocationUpdate(retailerLocation.RetailerId, retailerLocation.LatValue, retailerLocation.LongValue, cmnParam.UserId);
                    saveResult.Result = Convert.ToInt64(result);
                    saveResult.status_code = 200;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return saveResult;
        }

        [ResponseType(typeof(GetFeedbackOption))]
        [HttpPost]
        public GetFeedbackOption GetFeedbackOptionList(object data)
        {
            GetFeedbackOption getFeedbackOption = new GetFeedbackOption();
            getFeedbackOption.status_code = 400;
            List<SP_GET_FEEDBACK_OPTION> getFeedbackOptionList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getFeedbackOptionList = new CurrentOfferPZ().GetFeedbackOptions(cmnParam.UserId);
                    getFeedbackOption.data = getFeedbackOptionList;
                    getFeedbackOption.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getFeedbackOption;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult SavePasswordRecoveryReqest(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            saveResult.Result = 0;
            saveResult.status_code = 400;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            PasswordRecoveryReqest recoveryRequest = JsonConvert.DeserializeObject<PasswordRecoveryReqest>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    decimal SavedId = 0;
                    SavedId = new RetailerPZ().SavePasswordRecoveryRequest(recoveryRequest);
                    saveResult.Result = SavedId;
                    saveResult.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return saveResult;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult SaveNewComplain(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            saveResult.Result = 0;
            saveResult.status_code = 400;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Complain complain = JsonConvert.DeserializeObject<Complain>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    decimal SavedId = 0;
                    complain.StatusId = 0;
                    complain.RaisedByUser = cmnParam.UserId;

                    SavedId = new RetailerPZ().SaveUpdateComplain(complain);

                    saveResult.Result = SavedId;
                    saveResult.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return saveResult;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult SaveComplainPicture(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            saveResult.Result = 0;
            saveResult.status_code = 400;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            ComplainPicture complainPic = JsonConvert.DeserializeObject<ComplainPicture>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    decimal SavedId = 0;

                    SavedId = new RetailerPZ().SaveUpdateComplainPicture(complainPic);

                    saveResult.Result = SavedId;
                    saveResult.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return saveResult;
        }

        [ResponseType(typeof(GetComplainType))]
        [HttpPost]
        public GetComplainType GetComplainType(object data)
        {
            GetComplainType getComplainType = new GetComplainType();
            getComplainType.status_code = 400;
            List<SP_GET_COMPLAIN_TYPE> getComplainTypeList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getComplainTypeList = new CurrentOfferPZ().GetComplainTypes(0);
                    getComplainType.data = getComplainTypeList;
                    getComplainType.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getComplainType;
        }

        [ResponseType(typeof(GetComplain))]
        [HttpPost]
        public GetComplain GetComplains(object[] data)
        {
            GetComplain objGetComplain = new GetComplain();
            objGetComplain.status_code = 400;
            List<SP_GET_COMPLAINS> getComplainList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            Complain complain = JsonConvert.DeserializeObject<Complain>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getComplainList = new VisitPlanPZ().GetComplains(complain);
                    objGetComplain.data = getComplainList;
                    objGetComplain.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objGetComplain;
        }

        [ResponseType(typeof(GetPerformanceKpi))]
        [HttpPost]
        public GetPerformanceKpi PerformanceKpi(object data)
        {
            GetPerformanceKpi objGetPerformanceKpi = new GetPerformanceKpi();
            objGetPerformanceKpi.status_code = 400;
            List<SP_GET_PERFORMANCE_KPI> performanceKpiList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    performanceKpiList = new VisitPlanPZ().GetPerformanceKpi();
                    objGetPerformanceKpi.data = performanceKpiList;
                    objGetPerformanceKpi.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objGetPerformanceKpi;
        }

        [ResponseType(typeof(GetTopBottomRetailers))]
        [HttpPost]
        public GetTopBottomRetailers TopBottomRetailers(object[] data)
        {
            GetTopBottomRetailers objGetTopBottomRetailer = new GetTopBottomRetailers();
            objGetTopBottomRetailer.status_code = 400;
            List<SP_GET_TOP_BOTTOM_RETAILER> performanceKpiList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            TopBottomRetailer tbRetailer = JsonConvert.DeserializeObject<TopBottomRetailer>(data[1].ToString());
            tbRetailer.UserId = cmnParam.UserId;

            if (ValidateToken(cmnParam))
            {
                try
                {
                    performanceKpiList = new VisitPlanPZ().GetTopBottomRetailers(tbRetailer);
                    objGetTopBottomRetailer.data = performanceKpiList;
                    objGetTopBottomRetailer.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objGetTopBottomRetailer;
        }

        [ResponseType(typeof(GetRoutePerformance))]
        [HttpPost]
        public GetRoutePerformance RoutePerformance(object[] data)
        {
            GetRoutePerformance objGetTopBottomRetailer = new GetRoutePerformance();
            objGetTopBottomRetailer.status_code = 400;
            List<SP_GET_ROUTE_PERFORMANCE> routePerformanceList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            RoutePerformance routePerformance = JsonConvert.DeserializeObject<RoutePerformance>(data[1].ToString());
            routePerformance.UserId = cmnParam.UserId;
            if (ValidateToken(cmnParam))
            {
                try
                {
                    routePerformanceList = new VisitPlanPZ().GetRoutePerformance(routePerformance);
                    objGetTopBottomRetailer.data = routePerformanceList;
                    objGetTopBottomRetailer.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objGetTopBottomRetailer;
        }

        [ResponseType(typeof(GetTodaySales))]
        [HttpPost]
        public GetTodaySales TodaySalesReport(object data)
        {
            GetTodaySales objTodaySales = new GetTodaySales();
            objTodaySales.status_code = 400;
            List<SP_GET_TODAY_SALES> todaySalesList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    todaySalesList = new VisitPlanPZ().GetTodaySales(cmnParam.UserId, cmnParam.FromDate, cmnParam.ToDate);
                    objTodaySales.data = todaySalesList;
                    objTodaySales.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objTodaySales;
        }

        [ResponseType(typeof(GetVisitDetail))]
        [HttpPost]
        public GetVisitDetail GetVisitDetail(object data)
        {
            GetVisitDetail objGetVisitDetail = new GetVisitDetail();
            objGetVisitDetail.status_code = 400;
            List<SP_GET_VISIT_DETAIL> getVisitDetailList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getVisitDetailList = new VisitPlanPZ().GetVisitDetail(cmnParam.UserId, cmnParam.FromDate, cmnParam.ToDate);
                    objGetVisitDetail.data = getVisitDetailList;
                    objGetVisitDetail.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objGetVisitDetail;
        }

         
        [ResponseType(typeof(GetCriticalRetailer))]
        [HttpPost]
        public GetCriticalRetailer GetCriticalRetailer(object data)
        {
            GetCriticalRetailer objGetVisitDetail = new GetCriticalRetailer();
            objGetVisitDetail.status_code = 400;
            List<SP_GET_CRITICAL_RETAILER> getVisitDetailList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getVisitDetailList = new VisitPlanPZ().GetCriticalRetailer(cmnParam.UserId, cmnParam.CriticalType);
                    objGetVisitDetail.data = getVisitDetailList;
                    objGetVisitDetail.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objGetVisitDetail;
        }


        [ResponseType(typeof(GetMemoDetail))]
        [HttpPost]
        public GetMemoDetail GetMemoDetail(object data)
        {
            GetMemoDetail objGetMemoDetail = new GetMemoDetail();
            objGetMemoDetail.status_code = 400;
            List<SP_GET_MEMO_DETAIL> getMemoDetailList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getMemoDetailList = new VisitPlanPZ().GetMemoDetail(cmnParam.UserId);
                    objGetMemoDetail.data = getMemoDetailList;
                    objGetMemoDetail.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objGetMemoDetail;
        }

        [ResponseType(typeof(GetRetailerWiseProductQty))]
        [HttpPost]
        public GetRetailerWiseProductQty GetRetailerWiseProductQty(object data)
        {
            GetRetailerWiseProductQty objGetRetailerWiseProductQty = new GetRetailerWiseProductQty();
            objGetRetailerWiseProductQty.status_code = 400;
            List<SP_GET_RETAILER_WISE_PRODUCT_QTY> getRetailerWiseProductQtyList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getRetailerWiseProductQtyList = new VisitPlanPZ().GetRetailerWiseProductQty(cmnParam.ProductId);
                    objGetRetailerWiseProductQty.data = getRetailerWiseProductQtyList;
                    objGetRetailerWiseProductQty.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objGetRetailerWiseProductQty;
        }

        [ResponseType(typeof(GetSurveyList))]
        [HttpPost]
        public GetSurveyList GetSurveyList(object data)
        {
            GetSurveyList objGetSurveyList = new GetSurveyList();
            objGetSurveyList.status_code = 400;
            List<SP_GET_SURVEY_LIST> getSurveyList = null;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data.ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    getSurveyList = new VisitPlanPZ().GetSurveyList(cmnParam.UserId);
                    objGetSurveyList.data = getSurveyList;
                    objGetSurveyList.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return objGetSurveyList;
        }

        [ResponseType(typeof(GetDeliveredMemoSerial))]
        [HttpPost]
        public GetDeliveredMemoSerial GetDeliveredMemoProduct(object[] data)
        {
            GetDeliveredMemoSerial getMemoProduct = new GetDeliveredMemoSerial();

            List<SP_GET_DELIVERED_MEMO_SERIAL> memoSerialList = null;

            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            SalesMemo memo = JsonConvert.DeserializeObject<SalesMemo>(data[1].ToString());
            memo.MemoProductSerialId = 0;

            if (ValidateToken(cmnParam))
            {
                try
                {
                    memoSerialList = new SalesMemoPZ().GetDeliveredMemoSerials(memo.MemoProductSerialId, memo.MemoProductId, memo.ProductId);
                    getMemoProduct.data = memoSerialList;
                    getMemoProduct.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return getMemoProduct;
        }

        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult SaveTopupDelivery(object[] data)
        {
            SaveResult saveResult = new SaveResult();
            saveResult.Result = 0;
            saveResult.status_code = 400;
            CmnParam cmnParam = JsonConvert.DeserializeObject<CmnParam>(data[0].ToString());
            ProductDelivery productDelivery = JsonConvert.DeserializeObject<ProductDelivery>(data[1].ToString());

            if (ValidateToken(cmnParam))
            {
                try
                {
                    decimal SavedId = 0;
                    productDelivery.CreatedBy = cmnParam.UserId;
                    SavedId = new RetailerPZ().SaveUpdateProductDelivery(productDelivery);

                    saveResult.Result = SavedId;
                    saveResult.status_code = 200;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }

            return saveResult;
        }


        [ResponseType(typeof(SaveResult))]
        [HttpPost]
        public SaveResult GetPassCode(object data)
        {
            SaveResult saveResult = new SaveResult();
            saveResult.Result = 0;
            saveResult.status_code = 400;
            vmLoginUser loginUser = JsonConvert.DeserializeObject<vmLoginUser>(data.ToString());

            try
            {
                decimal SavedId = 0;
                SavedId = new RsoPZ().GetPassCode(loginUser.UserLogin);
                saveResult.Result = SavedId;
                saveResult.status_code = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return saveResult;
        }

        #endregion Distribution Channel

    }
}
