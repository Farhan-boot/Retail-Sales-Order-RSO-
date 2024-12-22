using APL.BL.SFTS.DataBridgeZone;
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
    [RoutePrefix("SFTS/api/SurveyQuestionAndAnswer")]
    public class SurveyQuestionAndAnswerController : ApiController
    {
        decimal _surveyListID = 0;

        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveUpdateQuestion(object[] data)
        {
            string result = "";

            try
            {
                decimal _surveyQID = 0;
                // _surveyQID = Convert.ToDecimal(Session["SurveyQID"]);

                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                vmSurveyQuestion surveyQuestion = JsonConvert.DeserializeObject<vmSurveyQuestion>(data[1].ToString());


                if (_surveyQID > 0)
                {
                    SP_INS_UPD_SURVEY_DETAIL_Q_ANScls surveyQ = new SP_INS_UPD_SURVEY_DETAIL_Q_ANScls();
                    surveyQ.NOTE = surveyQuestion.Note;
                    surveyQ.POINT = 0; //Convert.ToDecimal(txtPoint.Text);
                    surveyQ.QUESTION = surveyQuestion.Question;
                    surveyQ.SURVEY_LIST_ID = Convert.ToDecimal(surveyQuestion.SurveyId);

                    decimal UpdateResult = new SurveyDZ().SaveSurveyQuestionAndAnswer(_surveyQID, surveyQ.SURVEY_LIST_ID, surveyQ.POINT, surveyQ.QUESTION, surveyQ.NOTE, 0, "", 0, 0);
                    result = UpdateResult > 0 ? UpdateResult.ToString() : result;
                    //if (result != 0)
                    //{
                    //    ltlMessage.Text = MessageGodown.UpdateNotification; //"Update Question successfully.";
                    //    LoadNewSurveyQuestionList(surveyQ.SURVEY_LIST_ID);
                    //    FillSurveyQuestionList(surveyQ.SURVEY_LIST_ID);
                    //    clearQuestion();
                    //    Session["SurveyQID"] = null;
                    //}
                    //else
                    //{
                    //    ltlMessage.Text = MessageGodown.FailSubmittNotification;
                    //}
                }
                else
                {
                    SP_INS_UPD_SURVEY_DETAIL_Q_ANScls surveyQ = new SP_INS_UPD_SURVEY_DETAIL_Q_ANScls();
                    surveyQ.NOTE = surveyQuestion.Note;
                    surveyQ.POINT = 0;// Convert.ToDecimal(txtPoint.Text);
                    surveyQ.QUESTION = surveyQuestion.Question;
                    surveyQ.SURVEY_LIST_ID = Convert.ToDecimal(surveyQuestion.SurveyId);

                    decimal SaveResult = new SurveyDZ().SaveSurveyQuestionAndAnswer(0, surveyQ.SURVEY_LIST_ID, surveyQ.POINT, surveyQ.QUESTION, surveyQ.NOTE, 0, "", 0, 0);
                    result = SaveResult > 0 ? SaveResult.ToString() : result;
                    //if (result != 0)
                    //{
                    //    ltlMessage.Text = MessageGodown.SaveNotification; //"Save Question successfully.";
                    //    LoadNewSurveyQuestionList(surveyQ.SURVEY_LIST_ID);
                    //    FillSurveyQuestionList(surveyQ.SURVEY_LIST_ID);
                    //    clearQuestion();
                    //}
                    //else
                    //{
                    //    ltlMessage.Text = MessageGodown.FailSaveNotification;
                    //}
                }
            }
            catch (Exception ex)
            {
                result = "";
                string e = ex.ToString();
                //ltlMessage.Text = "Process fail due to :" + ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveAnswer(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                vmSurveyQuestion surveyQuestion = JsonConvert.DeserializeObject<vmSurveyQuestion>(data[1].ToString());

                _surveyListID = Convert.ToDecimal(surveyQuestion.SurveyId);
                decimal SaveResult = new SurveyDZ().SaveQuestionAndAnswer(surveyQuestion.AnswerId, surveyQuestion.QuestionId, surveyQuestion.Answer);
                result = SaveResult > 0 ? SaveResult.ToString() : result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetQuestionList(object[] data)
        {
            IEnumerable<SP_GET_SURVEYQUESTION_LISTcls> objSurveyQuestionList = null;

            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                objSurveyQuestionList = new SurveyPZ().GetAllSurveyQuestionList(objcmnParam.SurveyId, 0, "");
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                recordsTotal,
                objSurveyQuestionList
            });
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetQuestionForEdit(object[] data)
        {
            SP_GET_SURVEYQUESTION_LISTcls objQuestion = null;

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                var questions = new SurveyPZ().GetAllSurveyQuestionList(Convert.ToDecimal(objcmnParam.SurveyQuestionId), 0, "");
                if (questions != null && questions.Count > 0)
                {
                    objQuestion = new SurveyPZ().GetAllSurveyQuestionList(Convert.ToDecimal(objcmnParam.SurveyQuestionId), 0, "").FirstOrDefault(x => x.SURVEY_DETAIL_QID == Convert.ToDecimal(objcmnParam.SurveyQuestionId));
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objQuestion
            });
        }
   
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetSurveyAnswerList(object[] data)
        {
            IEnumerable<SP_GET_SURVEYANSWER_LISTcls> objSurveyAnswerList = null;
            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                //objcmnParam.SurveyQuestionId = 0;
                objSurveyAnswerList = new SurveyPZ().GetAllSurveyAnswerList(objcmnParam.SurveyId, objcmnParam.SurveyQuestionId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                recordsTotal,
                objSurveyAnswerList
            });
        }

        [HttpPost, ApiAuthorization]
        public HttpResponseMessage DeleteAnswer(object[] data)
        {
            string result = "";
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                _surveyListID = Convert.ToDecimal(objcmnParam.SurveyId);
                decimal DeleteResult = new SurveyPZ().SaveSurveyQuestionAndAnswer(0, 0, 0, "", "", 0, "", 0, Convert.ToDecimal(objcmnParam.SurveyAnswerId));
                result = DeleteResult > 0 ? DeleteResult.ToString() : result;
                // ltlMessage.Text = "Delete successfully.";
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

    }
}
