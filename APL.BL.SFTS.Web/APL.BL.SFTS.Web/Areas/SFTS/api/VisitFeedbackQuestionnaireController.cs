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
    [RoutePrefix("SFTS/api/VisitFeedbackQuestionnaire")]
    public class VisitFeedbackQuestionnaireController : ApiController
    {
        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetFeedbackQuestionnaires(object[] data)
        {
            IEnumerable<SP_GET_FEEDBACK_QUESTIONNAIRE> feedbackQuestionnaireList = null;

            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                feedbackQuestionnaireList = new VisitPlanPZ().GetFeedbackQuestionnaires(objcmnParam.QuestionnaireId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                recordsTotal,
                feedbackQuestionnaireList
            });
        }

        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveUpdateQuestionnaire(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                vmQuestionnaire questionnaire = JsonConvert.DeserializeObject<vmQuestionnaire>(data[1].ToString());

                decimal updateResult = new VisitPlanPZ().SaveUpdateQuestionnaire(questionnaire.QuestionnaireId, questionnaire.VisitEntityType, questionnaire.CenterTypeId, objcmnParam.loggeduser, questionnaire.VisitTypeId, questionnaire.IsActive);
                result = updateResult > 0 ? updateResult.ToString() : result;
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                result = "";
            }


            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost, ApiAuthorization]
        public IHttpActionResult GetFeedbackQuestions(object[] data)
        {
            IEnumerable<SP_GET_ALL_FEEDBACK_QUESTION> feedbackQuestionList = null;

            int recordsTotal = 0;
            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                feedbackQuestionList = new VisitPlanPZ().GetAllFeedbackQuestions(objcmnParam.QuestionnaireId, objcmnParam.QuestionId);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                recordsTotal,
                feedbackQuestionList
            });
        }

        [HttpPost, ApiAuthorization]
        public HttpResponseMessage SaveUpdateQuestion(object[] data)
        {
            string result = "";

            try
            {
                vmCmnParameters objcmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                vmFeedbackQuestion question = JsonConvert.DeserializeObject<vmFeedbackQuestion>(data[1].ToString());

                decimal updateResult = new VisitPlanPZ().SaveUpdateQuestion(question.FeedbackQuestionId, question.QuestionnaireId, question.QuestionText, question.CreatedBy, question.IsActive, question.DisplayOrder);
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
