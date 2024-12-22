using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.Notice;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using APL.BL.SFTS.ProcessZone.Notice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class SurveyPZ
    {
        public SurveyPZ(){ }  

        /// <summary>
        /// Save or update Survey Detail Question and always save Survey Detail Answer. On update time delete old Survey Detail Answer and save new Survey Detail Answer.
        /// </summary>
        /// <param name="surveyDetailQID"></param>
        /// <param name="surveyListID"></param>
        /// <param name="point"></param>
        /// <param name="question"></param>
        /// <param name="note"></param>
        /// <param name="surveyQID"></param>
        /// <param name="answer"></param>
        /// <param name="surveyDetailAID"></param>
        /// <param name="surveyDetailDelAnsID"></param>
        /// <returns>Survey Detail Question ID</returns>
        public Decimal SaveSurveyQuestionAndAnswer(decimal surveyDetailQID, decimal surveyListID, decimal point, string question, string note, decimal surveyQID, string answer,
            decimal surveyDetailAID, decimal surveyDetailDelAnsID)
        {
            decimal sQID = 0;
            sQID = surveyDetailQID > 0 ? surveyDetailQID : 0;

            try
            {
                return new SurveyDZ().SaveSurveyQuestionAndAnswer(sQID, surveyListID, point, question, note, surveyQID, answer, surveyDetailAID, surveyDetailDelAnsID);
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }
        public List<SP_GET_ALL_DISTRIBUTOR> GetSurveyRegion(decimal surveyListID)
        {
            try
            {
                return new SurveyDZ().GetSurveyRegion(surveyListID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal PublishSurveyInfo(decimal surveyListID)
        {
            try
            {
                return new SurveyDZ().PublishSurveyInfo(surveyListID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Save or update Survey List.
        /// </summary>
        /// <param name="surveyListID"></param>
        /// <param name="distrubutorID"></param>
        /// <param name="rsoID"></param>
        /// <param name="routeID"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="createBy"></param>
        /// <param name="createDate"></param>
        /// <param name="surveyStatus"></param>
        /// <returns>Survey List ID</returns>
        public Decimal SaveSurveyList(decimal surveyListID, decimal distrubutorID, decimal rsoID, decimal routeID, string title, string description, DateTime startDateTime,
          DateTime endDateTime, decimal createBy, DateTime createDate, decimal surveyStatus, decimal _surveyFOR, List<GET_ID> surveyRegList)
		{
            try
            {
                decimal result = 0;
                result = new SurveyDZ().SaveSurveyList(surveyListID, distrubutorID, rsoID, routeID, title, description, startDateTime, endDateTime, createBy, createDate, surveyStatus, _surveyFOR);

                if (surveyListID == 0 && result > 0)
                {
                    surveyListID = result;
                }
                result = new SurveyDZ().DeleteExistingSurveyReg(surveyListID);
                if (surveyRegList.Count > 0)
                {
                    foreach (var item in surveyRegList)
                    {
                        new SurveyDZ().SaveUpdateSurveyRegion(surveyListID, item.Id);
                    }
                }
				string message = "New Survey !! " + title + " Survey duration from: " + startDateTime.ToString("dd-MM-yyyy") + " to: " + endDateTime.ToString("dd-MM-yyyy");

				decimal NoticeId_New = new NoticeSetupPZ().SaveNotification(0, 2, 2, startDateTime.ToString("dd/MM/yyyy"), endDateTime.ToString("dd/MM/yyyy"), title, message, "", "", 1, createBy, "", surveyRegList);

				decimal IsEventSaved = 0;
				int i = 0;
				if (surveyRegList.Count > 0)
				{
					foreach (var item in surveyRegList)
					{
						i++;
						IsEventSaved = new NoticeSetupDZ().SaveNotificationUser(i, NoticeId_New, item.Id, message, message, "");
					}
				}

				
				



				return surveyListID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Survey List data from SURVEY_LIST table by search option.
        /// </summary>
        /// <param name="surveyListID"></param>
        /// <param name="distribitorID"></param>
        /// <param name="routeID"></param>
        /// <returns>Single related object</returns>
        public SP_GET_SURVEYLISTcls GetSurvey(decimal surveyListID, decimal distribitorID, decimal routeID)
        {
            try
            {
                List<SP_GET_SURVEYLISTcls> surveyList = new SurveyDZ().GetAllSurveyList(surveyListID, distribitorID, routeID).OrderBy(sur=> sur.SURVEYLIST_ID).ToList();
                return surveyList.SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all Survey List data from SURVEY_LIST table by search option.
        /// </summary>
        /// <param name="surveyListID"></param>
        /// <param name="distribitorID"></param>
        /// <param name="routeID"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_SURVEYLISTcls> GetAllSurveyList(decimal surveyListID, decimal distribitorID, decimal routeID)
        {
            try
            {
                return new SurveyDZ().GetAllSurveyList(surveyListID, distribitorID, routeID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all Question for Survey List by search option.
        /// </summary>
        /// <param name="surveyListID"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_SURVEYQUESTION_LISTcls> GetAllSurveyQuestionList(decimal surveyListID, decimal rsoID, string token)
        {
            try
            {
                return new SurveyDZ().GetAllSurveyQuestionList(surveyListID, rsoID, token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        /// <summary>
        /// Get Survey Answer and Question for Survey List by search option.
        /// </summary>
        /// <param name="surveyDetailQID"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_SURVEYANSWER_LISTcls> GetAllSurveyAnswerList(decimal surveyDetailQID)
        {
            try
            {
                return new SurveyDZ().GetAllSurveyAnswerList(0, surveyDetailQID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Survey Answer and Question for Survey List by search option.
        /// </summary>
        /// <param name="surveyListID"></param>
        /// <param name="surveyDetailQID"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_SURVEYANSWER_LISTcls> GetAllSurveyAnswerList(decimal surveyListID, decimal surveyDetailQID)
        {
            try
            {
                return new SurveyDZ().GetAllSurveyAnswerList(surveyListID, surveyDetailQID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save or update Survey Analysis Answer.
        /// </summary>
        /// <param name="surverAnalysisAnsID"></param>
        /// <param name="distrubutorID"></param>
        /// <param name="rsoID"></param>
        /// <param name="surveyListID"></param>
        /// <param name="surveyDetailQID"></param>
        /// <param name="surveyDetailAID"></param>
        /// <param name="optainPoint"></param>
        /// <param name="submitDate"></param>
        /// <param name="adminRemark"></param>
        /// <returns>Row ID of table</returns>
        public Decimal SaveSurveyAnalysisAns(decimal surverAnalysisAnsID, decimal distrubutorID, decimal rsoID, decimal surveyListID, decimal surveyDetailQID,
           decimal surveyDetailAID, decimal optainPoint, DateTime submitDate, string adminRemark)
        {
            try
            {
                return new SurveyDZ().SaveSurveyAnalysisAns(surverAnalysisAnsID, distrubutorID, rsoID, surveyListID, surveyDetailQID, surveyDetailAID, optainPoint,
                    submitDate, adminRemark);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Survey wise analysis Answer by RSo.
        /// </summary>
        /// <param name="surveyListID"></param>
        /// <param name="distribitorID"></param>
        /// <param name="rsoID"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_SURVEYANALYSYS_ANScls> GetSurveyAnalysisAns(decimal surveyListID, decimal distribitorID, decimal rsoID, string token)
        {
            try
            {
                return new SurveyDZ().GetSurveyAnalysisAns(surveyListID, distribitorID, rsoID, token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        /// <summary>
        /// Get all Survey List , Survey Question and Survey Answer by search option.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="surveyListID"></param>
        /// <param name="surveyTitle"></param>
        /// <param name="searchStartDate"></param>
        /// <param name="searchEndDate"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_ALL_SURVEY_LIST_QUE_ANScls> GetSurveyListQuestionAns(decimal distributorID, decimal surveyListID, String surveyTitle, DateTime? searchStartDate, DateTime? searchEndDate)
        {
            try
            {
                return new SurveyDZ().GetSurveyListQuestionAns(distributorID, surveyListID, surveyTitle, searchStartDate, searchEndDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_FF_GET_SURVEY> GetSurveyResult(SearchParam searchParam)
        {
            List<SP_FF_GET_SURVEY> retailerSales = new List<SP_FF_GET_SURVEY>();
            try
            {
                retailerSales = new SurveyDZ().GetSurveyResult(searchParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return retailerSales;
        }
    }
}
