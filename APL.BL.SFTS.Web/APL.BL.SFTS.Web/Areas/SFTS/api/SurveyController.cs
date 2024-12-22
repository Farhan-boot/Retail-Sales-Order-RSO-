using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.SFTS;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.Web.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APL.BL.SFTS.Web.Areas.SFTS.api
{
    [RoutePrefix("SFTS/api/Survey")]
    public class SurveyController : ApiController
    {
        public enum SurveyStatusEnum { NewSurvey = 1, PublishSurvey = 2, EndSurvey = 3 }
		public enum SurveyFOREnum { RSO = 1, MTO = 2 }
		[HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveUpdateSurvey(object[] data)
        {
            string result = "";
         
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                vmNewSurvey survey = JsonConvert.DeserializeObject<vmNewSurvey>(data[1].ToString());
                List<GET_ID> surveyRegList = JsonConvert.DeserializeObject<List<GET_ID>>(data[2].ToString());
                decimal surveyListID = 0;
                surveyListID = survey.SurveyId;
                if (surveyListID > 0)
                {
                    SP_INS_UPD_SURVEY_LISTcls surveyList = new SP_INS_UPD_SURVEY_LISTcls();
                    surveyList.DISTRIBUTORID = Convert.ToDecimal(survey.DistributorId);

                    surveyList.ROUTEID = survey.RouteId.ToString().Trim() != string.Empty ? Convert.ToDecimal(survey.RouteId) : 0;
                    surveyList.RSOID = 0;
                    surveyList.START_DATETIME = Convert.ToDateTime(survey.FromDate);
                    surveyList.END_DATETIME = Convert.ToDateTime(survey.ToDate);
                    surveyList.TITLE = survey.SurveyTitle;
                    surveyList.DESCRIPTION = survey.Description;
                    surveyList.CREATE_BY = 1;
                    surveyList.CREATE_DATE = DateTime.Now;
					surveyList.SURVEY_FOR = survey.SURVEY_FOR; // Convert.ToInt32(survey.RSOMTO.ToString());


					decimal updateResult = new SurveyPZ().SaveSurveyList(surveyListID, surveyList.DISTRIBUTORID, surveyList.RSOID, surveyList.ROUTEID, surveyList.TITLE, surveyList.DESCRIPTION,
                        surveyList.START_DATETIME, surveyList.END_DATETIME, surveyList.CREATE_BY, surveyList.CREATE_DATE, (int)SurveyStatusEnum.NewSurvey, surveyList.SURVEY_FOR, surveyRegList);

                    result = updateResult > 0 ? updateResult.ToString() : result;
                    //if (surveyListID > 0)
                    //{
                    //    ltlMessage.Text = MessageGodown.UpdateNotification; //"Update successfully.";
                    //    LoadNewSurveyList(0, 0);
                    //    //FillNewSurveyList(0, 0);
                    //    clearQuestion();
                    //    Session["SurveyID"] = null;
                    //    btnSave.Text = "New Survey";
                    //}
                }
                else
                {
                    SP_INS_UPD_SURVEY_LISTcls surveyList = new SP_INS_UPD_SURVEY_LISTcls();
                    surveyList.DISTRIBUTORID = Convert.ToDecimal(survey.DistributorId);
                    surveyList.ROUTEID = survey.RouteId.ToString() != string.Empty ? Convert.ToDecimal(survey.RouteId) : 0;
                    surveyList.RSOID = 0;
                    surveyList.START_DATETIME = Convert.ToDateTime(survey.FromDate);
                    surveyList.END_DATETIME = Convert.ToDateTime(survey.ToDate);
                    surveyList.TITLE = survey.SurveyTitle;
                    surveyList.DESCRIPTION = survey.Description;
                    surveyList.CREATE_BY = 1;
                    surveyList.CREATE_DATE = DateTime.Now;
					surveyList.SURVEY_FOR = survey.SURVEY_FOR;   // Convert.ToInt32(survey.RSOMTO.ToString());

					decimal SaveResult = new SurveyPZ().SaveSurveyList(0, surveyList.DISTRIBUTORID, surveyList.RSOID, surveyList.ROUTEID, surveyList.TITLE, surveyList.DESCRIPTION,
                        surveyList.START_DATETIME, surveyList.END_DATETIME, surveyList.CREATE_BY, surveyList.CREATE_DATE, (int)SurveyStatusEnum.NewSurvey, surveyList.SURVEY_FOR, surveyRegList);
                    result = SaveResult > 0 ? SaveResult.ToString() : result;
                    //if (result > 0)
                    //{
                    //    ltlMessage.Text = MessageGodown.SaveNotification; //"Save successfully.";
                    //    LoadNewSurveyList(0, 0);
                    //    //FillNewSurveyList(0, 0);
                    //    clearQuestion();
                    //    ltlMessage.Text = MessageGodown.SaveNotification;
                    //}
                    //else
                    //{
                    //    ltlMessage.Text = MessageGodown.FailSaveNotification;
                    //}
                }
            }
            catch (Exception ex)
            {
                string e =  ex.ToString();
                result = "";
                //ltlMessage.Text = "Process fail due to " + ex.Message;
            }


            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        
        [HttpPost, ApiAuthorization]
        public HttpResponseMessage PublishSurveyInfo(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                vmNewSurvey survey = JsonConvert.DeserializeObject<vmNewSurvey>(data[1].ToString());
                decimal surveyListID = 0;
                surveyListID = survey.SurveyId;
                if (surveyListID > 0)
                {
                    decimal updateResult = new SurveyPZ().PublishSurveyInfo(surveyListID);
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
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetSurveyRegion(object[] data)
        {
            IEnumerable<SP_GET_ALL_DISTRIBUTOR> surveyReg = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                surveyReg = new SurveyPZ().GetSurveyRegion(objcmnParam.SurveyId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                surveyReg
            });
        }
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetAllSurvey(object[] data)
        {
            IEnumerable<SP_GET_SURVEYLISTcls> surveyList = null;

            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                decimal distributorID = 0;
                decimal _routeID = 0;
                int curPage = -1;
                var currentPage = curPage == -1 ? objcmnParam.pageNumber : 0;
                surveyList = new SurveyPZ().GetAllSurveyList(0, distributorID, _routeID);

                foreach (var item in surveyList)
                {
                    
                    if (item.DISTRIBUTORID != 0 && item.DISTRIBUTOR_NAME == " " & item.ROUTEID != 0 && item.ROUTE_NAME == " ")
                    {
                        var distr = new DistributorPZ().GetAllDistributor(item.DISTRIBUTORID).FirstOrDefault(x => x.DISTRIBUTOR_ID == item.DISTRIBUTORID);
                        item.DISTRIBUTOR_NAME = distr.DISTRIBUTOR_NAME;
                        item.DISTRIBUTOR_CODE = distr.DISTRIBUTOR_CODE;
                        item.DISTRIBUTOR_NAME_CODE = item.DISTRIBUTOR_NAME + "(" + distr.DISTRIBUTOR_CODE + ")";

                        var route = new RoutePZ().GetAllRoute(item.DISTRIBUTORID, item.ROUTEID).FirstOrDefault(x => x.ROUTE_ID == item.ROUTEID);
                        item.ROUTE_NAME = route.ROUTENAME;
                        item.ROUTE_CODE = route.ROUTE_CODE;
                    }

                    else if (item.DISTRIBUTORID != 0 && item.DISTRIBUTOR_NAME == " ")
                    {
                        var distr = new DistributorPZ().GetAllDistributor(item.DISTRIBUTORID).FirstOrDefault(x => x.DISTRIBUTOR_ID == item.DISTRIBUTORID);
                        item.DISTRIBUTOR_NAME = distr.DISTRIBUTOR_NAME;
                        item.DISTRIBUTOR_CODE = distr.DISTRIBUTOR_CODE;
                        item.DISTRIBUTOR_NAME_CODE = item.DISTRIBUTOR_NAME + "(" + distr.DISTRIBUTOR_CODE + ")";
                    }
                    else if (item.ROUTEID != 0 && item.ROUTE_NAME == " ")
                    {
                        var route = new RoutePZ().GetAllRoute(item.DISTRIBUTORID, item.ROUTEID).FirstOrDefault(x => x.ROUTE_ID == item.ROUTEID);
                        item.ROUTE_NAME = route.ROUTENAME;
                        item.ROUTE_CODE = route.ROUTE_CODE;
                    }

                    surveyList = surveyList.OrderByDescending(sur => sur.SURVEYLIST_ID).ToList();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                recordsTotal,
                surveyList
            });
        }
        [HttpPost]
        public IHttpActionResult GetRegions(object[] data)
        {
            IEnumerable<GET_REGION> objListRegion = null;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objListRegion = new CurrentOfferPZ().GetRegions(0);
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
    }
}
