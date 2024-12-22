using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class SurveyDZ
    {
        public SurveyDZ()
        { }       

        #region Get Methods

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
                OracleParameter surveyListID_OP = new OracleParameter();
                surveyListID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyListID_OP.OracleDbType = OracleDbType.Decimal;
                surveyListID_OP.Value = surveyListID;

                OracleParameter distribitorID_OP = new OracleParameter();
                distribitorID_OP.Direction = System.Data.ParameterDirection.Input;
                distribitorID_OP.OracleDbType = OracleDbType.Decimal;
                distribitorID_OP.Value = distribitorID;

                OracleParameter routeID_OP = new OracleParameter();
                routeID_OP.Direction = System.Data.ParameterDirection.Input;
                routeID_OP.OracleDbType = OracleDbType.Decimal;
                routeID_OP.Value = routeID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SURVEYLISTcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SURVEYLISTcls>.GetDataBySP(new SP_GET_SURVEYLISTcls(), "SP_FF_GET_SURVEYLIST", 17, resultOutCurSor, surveyListID_OP, distribitorID_OP, routeID_OP);
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
                OracleParameter surveyListID_OP = new OracleParameter();
                surveyListID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyListID_OP.OracleDbType = OracleDbType.Decimal;
                surveyListID_OP.Value = surveyListID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter token_OP = new OracleParameter();
                token_OP.Direction = System.Data.ParameterDirection.Input;
                token_OP.OracleDbType = OracleDbType.Varchar2;
                token_OP.Value = token;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SURVEYQUESTION_LISTcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SURVEYQUESTION_LISTcls>.GetDataBySP(new SP_GET_SURVEYQUESTION_LISTcls(), "SP_FF_GET_SURVEYQUESTION_LIST", 6, resultOutCurSor, surveyListID_OP, rsoID_OP, token_OP);
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

                OracleParameter surveyListID_OP = new OracleParameter();
                surveyListID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyListID_OP.OracleDbType = OracleDbType.Decimal;
                surveyListID_OP.Value = surveyListID; 

                OracleParameter surveyDetailQID_OP = new OracleParameter();
                surveyDetailQID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyDetailQID_OP.OracleDbType = OracleDbType.Decimal;
                surveyDetailQID_OP.Value = surveyDetailQID;
                
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SURVEYANSWER_LISTcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SURVEYANSWER_LISTcls>.GetDataBySP(new SP_GET_SURVEYANSWER_LISTcls(), "SP_FF_GET_SURVEYANSWER_LIST", 4, resultOutCurSor, surveyListID_OP, surveyDetailQID_OP);
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
        /// <param name="distributorID"></param>
        /// <param name="rsoID"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_SURVEYANALYSYS_ANScls> GetSurveyAnalysisAns(decimal surveyListID, decimal distributorID, decimal rsoID, string token)
        {
            try
            {
                OracleParameter surveyListID_OP = new OracleParameter();
                surveyListID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyListID_OP.OracleDbType = OracleDbType.Decimal;
                surveyListID_OP.Value = surveyListID;

                OracleParameter distribitorID_OP = new OracleParameter();
                distribitorID_OP.Direction = System.Data.ParameterDirection.Input;
                distribitorID_OP.OracleDbType = OracleDbType.Decimal;
                distribitorID_OP.Value = distributorID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter token_OP = new OracleParameter();
                token_OP.Direction = System.Data.ParameterDirection.Input;
                token_OP.OracleDbType = OracleDbType.Varchar2;
                token_OP.Value = token;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SURVEYANALYSYS_ANScls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SURVEYANALYSYS_ANScls>.GetDataBySP(new SP_GET_SURVEYANALYSYS_ANScls(), "SP_GET_SURVEYANALYSYS_ANS", 17, resultOutCurSor, surveyListID_OP, distribitorID_OP, rsoID_OP, token_OP);
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
                OracleParameter distribitorID_OP = new OracleParameter();
                distribitorID_OP.Direction = System.Data.ParameterDirection.Input;
                distribitorID_OP.OracleDbType = OracleDbType.Decimal;
                distribitorID_OP.Value = distributorID;

                OracleParameter surveyListID_OP = new OracleParameter();
                surveyListID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyListID_OP.OracleDbType = OracleDbType.Decimal;
                surveyListID_OP.Value = surveyListID;

                OracleParameter surveyTitleOP = new OracleParameter();
                surveyTitleOP.Direction = System.Data.ParameterDirection.Input;
                surveyTitleOP.OracleDbType = OracleDbType.Varchar2;
                surveyTitleOP.Value = surveyTitle;

                OracleParameter searchStartDateOP = new OracleParameter();
                searchStartDateOP.Direction = System.Data.ParameterDirection.Input;
                searchStartDateOP.OracleDbType = OracleDbType.Varchar2;
                searchStartDateOP.Value = searchStartDate != null ? ((DateTime)searchStartDate).ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter searchEndDateOP = new OracleParameter();
                searchEndDateOP.Direction = System.Data.ParameterDirection.Input;
                searchEndDateOP.OracleDbType = OracleDbType.Varchar2;
                searchEndDateOP.Value = searchEndDate != null ? ((DateTime)searchEndDate).ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_ALL_SURVEY_LIST_QUE_ANScls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ALL_SURVEY_LIST_QUE_ANScls>.GetDataBySP(new SP_GET_ALL_SURVEY_LIST_QUE_ANScls(), "SP_GET_ALL_SURVEY_LIST_QUE_ANS", 16, resultOutCurSor, distribitorID_OP, surveyListID_OP, surveyTitleOP, searchStartDateOP, searchEndDateOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Methods


        #region Save Methods

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
         DateTime endDateTime, decimal createBy, DateTime createDate, decimal surveyStatus, decimal _surveyFOR)
        {
            try
            {
                OracleParameter surveyListID_OP = new OracleParameter();
                surveyListID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyListID_OP.OracleDbType = OracleDbType.Decimal;
                surveyListID_OP.Value = surveyListID;

                OracleParameter distrubutorID_OP = new OracleParameter();
                distrubutorID_OP.Direction = System.Data.ParameterDirection.Input;
                distrubutorID_OP.OracleDbType = OracleDbType.Decimal;
                distrubutorID_OP.Value = distrubutorID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter routeID_OP = new OracleParameter();
                routeID_OP.Direction = System.Data.ParameterDirection.Input;
                routeID_OP.OracleDbType = OracleDbType.Decimal;
                routeID_OP.Value = routeID;

                OracleParameter titleOP = new OracleParameter();
                titleOP.Direction = System.Data.ParameterDirection.Input;
                titleOP.OracleDbType = OracleDbType.Varchar2;
                titleOP.Value = title;

                OracleParameter descriptionOP = new OracleParameter();
                descriptionOP.Direction = System.Data.ParameterDirection.Input;
                descriptionOP.OracleDbType = OracleDbType.Varchar2;
                descriptionOP.Value = description;

                OracleParameter startDateTimeOP = new OracleParameter();
                startDateTimeOP.Direction = System.Data.ParameterDirection.Input;
                startDateTimeOP.OracleDbType = OracleDbType.Varchar2;
                startDateTimeOP.Value = startDateTime.ToString("dd-MMM-yyyy");

                OracleParameter endDateTimeOP = new OracleParameter();
                endDateTimeOP.Direction = System.Data.ParameterDirection.Input;
                endDateTimeOP.OracleDbType = OracleDbType.Varchar2;
                endDateTimeOP.Value = endDateTime.ToString("dd-MMM-yyyy");


                OracleParameter createByOP = new OracleParameter();
                createByOP.Direction = System.Data.ParameterDirection.Input;
                createByOP.OracleDbType = OracleDbType.Decimal;
                createByOP.Value = createBy;

                OracleParameter createDateOP = new OracleParameter();
                createDateOP.Direction = System.Data.ParameterDirection.Input;
                createDateOP.OracleDbType = OracleDbType.Varchar2;
                createDateOP.Value = createDate.ToString("dd-MMM-yyyy");

                OracleParameter surveyStatusOP = new OracleParameter();
                surveyStatusOP.Direction = System.Data.ParameterDirection.Input;
                surveyStatusOP.OracleDbType = OracleDbType.Varchar2;
                surveyStatusOP.Value = surveyStatus;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

				OracleParameter surveyFOR = new OracleParameter();
				surveyFOR.Direction = System.Data.ParameterDirection.Input;
				surveyFOR.OracleDbType = OracleDbType.Decimal;
				surveyFOR.Value = _surveyFOR;

				return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_SURVEY_LISTcls>.InsertDataBySP("SP_FF_INS_UPD_SURVEY_LIST", resultOutID,
                    surveyListID_OP, distrubutorID_OP, rsoID_OP, routeID_OP, titleOP, descriptionOP, startDateTimeOP, endDateTimeOP, createByOP, createDateOP, surveyStatusOP, surveyFOR);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Decimal DeleteExistingSurveyReg(decimal surveyListID)
        {
            try
            {
                OracleParameter surveyListID_OP = new OracleParameter();
                surveyListID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyListID_OP.OracleDbType = OracleDbType.Decimal;
                surveyListID_OP.Value = surveyListID;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_DELETE_SURVEY_REG", resultOutID, surveyListID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Decimal SaveUpdateSurveyRegion(decimal surveyListID, decimal RegionId)
        {
            try
            {
                OracleParameter surveyListID_OP = new OracleParameter();
                surveyListID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyListID_OP.OracleDbType = OracleDbType.Decimal;
                surveyListID_OP.Value = surveyListID;

                OracleParameter RegionId_OP = new OracleParameter();
                RegionId_OP.Direction = System.Data.ParameterDirection.Input;
                RegionId_OP.OracleDbType = OracleDbType.Decimal;
                RegionId_OP.Value = RegionId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_INS_UPD_SURVEU_REG", resultOutID, surveyListID_OP, RegionId_OP);
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
                OracleParameter surveyListID_OP = new OracleParameter();
                surveyListID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyListID_OP.OracleDbType = OracleDbType.Decimal;
                surveyListID_OP.Value = surveyListID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_ALL_DISTRIBUTOR>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ALL_DISTRIBUTOR>.GetDataBySP(new SP_GET_ALL_DISTRIBUTOR(), "SP_FF_GET_SURVEY_REG", 4, resultOutCurSor, surveyListID_OP);
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
                OracleParameter surveyListID_OP = new OracleParameter();
                surveyListID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyListID_OP.OracleDbType = OracleDbType.Decimal;
                surveyListID_OP.Value = surveyListID;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_SURVEY_DETAIL_Q_ANScls>.InsertDataBySP("SP_FF_PUBLISH_SURVEY", resultOutID, surveyListID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
        public Decimal SaveSurveyQuestionAndAnswer(decimal surveyDetailQID, decimal surveyListID, decimal point, string question, string note, decimal surveyQID,
            string answer, decimal surveyDetailAID, decimal surveyDetailDelAnsID)
        {
            try
            {
                OracleParameter surveyDetailQID_OP = new OracleParameter();
                surveyDetailQID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyDetailQID_OP.OracleDbType = OracleDbType.Decimal;
                surveyDetailQID_OP.Value = surveyDetailQID;

                OracleParameter surveyListID_OP = new OracleParameter();
                surveyListID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyListID_OP.OracleDbType = OracleDbType.Decimal;
                surveyListID_OP.Value = surveyListID;

                OracleParameter point_OP = new OracleParameter();
                point_OP.Direction = System.Data.ParameterDirection.Input;
                point_OP.OracleDbType = OracleDbType.Decimal;
                point_OP.Value = point;

                OracleParameter question_OP = new OracleParameter();
                question_OP.Direction = System.Data.ParameterDirection.Input;
                question_OP.OracleDbType = OracleDbType.Varchar2;
                question_OP.Value = question;

                OracleParameter note_OP = new OracleParameter();
                note_OP.Direction = System.Data.ParameterDirection.Input;
                note_OP.OracleDbType = OracleDbType.Varchar2;
                note_OP.Value = note;

                OracleParameter surveyQID_OP = new OracleParameter();
                surveyQID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyQID_OP.OracleDbType = OracleDbType.Decimal;
                surveyQID_OP.Value = surveyQID;

                OracleParameter answer_OP = new OracleParameter();
                answer_OP.Direction = System.Data.ParameterDirection.Input;
                answer_OP.OracleDbType = OracleDbType.Varchar2;
                answer_OP.Value = answer;

                OracleParameter surveyDetailAID_OP = new OracleParameter();
                surveyDetailAID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyDetailAID_OP.OracleDbType = OracleDbType.Decimal;
                surveyDetailAID_OP.Value = surveyDetailAID;

                OracleParameter surveyDetailDelAnsID_OP = new OracleParameter();
                surveyDetailDelAnsID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyDetailDelAnsID_OP.OracleDbType = OracleDbType.Decimal;
                surveyDetailDelAnsID_OP.Value = surveyDetailDelAnsID;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_SURVEY_DETAIL_Q_ANScls>.InsertDataBySP("SP_FF_INS_UPD_SURVEY_Q_ANS", resultOutID, surveyDetailQID_OP,
                    surveyListID_OP, point_OP, question_OP, note_OP, surveyQID_OP, answer_OP, surveyDetailAID_OP, surveyDetailDelAnsID_OP);
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

                OracleParameter surverAnalysisAnsID_OP = new OracleParameter();
                surverAnalysisAnsID_OP.Direction = System.Data.ParameterDirection.Input;
                surverAnalysisAnsID_OP.OracleDbType = OracleDbType.Decimal;
                surverAnalysisAnsID_OP.Value = surverAnalysisAnsID;

                OracleParameter distrubutorID_OP = new OracleParameter();
                distrubutorID_OP.Direction = System.Data.ParameterDirection.Input;
                distrubutorID_OP.OracleDbType = OracleDbType.Decimal;
                distrubutorID_OP.Value = distrubutorID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter surveyListID_OP = new OracleParameter();
                surveyListID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyListID_OP.OracleDbType = OracleDbType.Decimal;
                surveyListID_OP.Value = surveyListID;

                OracleParameter surveyDetailQID_OP = new OracleParameter();
                surveyDetailQID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyDetailQID_OP.OracleDbType = OracleDbType.Decimal;
                surveyDetailQID_OP.Value = surveyDetailQID;

                OracleParameter surveyDetailAID_OP = new OracleParameter();
                surveyDetailAID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyDetailAID_OP.OracleDbType = OracleDbType.Decimal;
                surveyDetailAID_OP.Value = surveyDetailAID;

                OracleParameter optainPoint_OP = new OracleParameter();
                optainPoint_OP.Direction = System.Data.ParameterDirection.Input;
                optainPoint_OP.OracleDbType = OracleDbType.Decimal;
                optainPoint_OP.Value = optainPoint;

                OracleParameter submitDate_OP = new OracleParameter();
                submitDate_OP.Direction = System.Data.ParameterDirection.Input;
                submitDate_OP.OracleDbType = OracleDbType.Varchar2;
                submitDate_OP.Value = submitDate.ToString("dd-MMM-yyyy");

                OracleParameter adminRemark_OP = new OracleParameter();
                adminRemark_OP.Direction = System.Data.ParameterDirection.Input;
                adminRemark_OP.OracleDbType = OracleDbType.Varchar2;
                adminRemark_OP.Value = adminRemark;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                //return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_SURVEY_ANALYSIS_ANScls>.InsertDataBySP("SP_INS_UPD_SURVEY_ANALYSIS_ANS", resultOutID, surverAnalysisAnsID_OP,
                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_SURVEY_ANALYSIS_ANScls>.InsertDataBySP("INS_UPD_SURVEY_ANALYSIS_ANS_V2", resultOutID, surverAnalysisAnsID_OP,
                   distrubutorID_OP, rsoID_OP, surveyListID_OP, surveyDetailQID_OP, surveyDetailAID_OP, optainPoint_OP, submitDate_OP, adminRemark_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveQuestionAndAnswer(decimal surveyDetailAID, decimal surveyQID, string answer)
        {
            try
            {
                OracleParameter surveyDetailAID_OP = new OracleParameter();
                surveyDetailAID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyDetailAID_OP.OracleDbType = OracleDbType.Decimal;
                surveyDetailAID_OP.Value = surveyDetailAID;

                OracleParameter surveyQID_OP = new OracleParameter();
                surveyQID_OP.Direction = System.Data.ParameterDirection.Input;
                surveyQID_OP.OracleDbType = OracleDbType.Decimal;
                surveyQID_OP.Value = surveyQID;

                OracleParameter answer_OP = new OracleParameter();
                answer_OP.Direction = System.Data.ParameterDirection.Input;
                answer_OP.OracleDbType = OracleDbType.Varchar2;
                answer_OP.Value = answer;


                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_SURVEY_DETAIL_Q_ANScls>.InsertDataBySP("SP_FF_INS_UPD_SURVEY_ANS", resultOutID, surveyDetailAID_OP, surveyQID_OP, answer_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_FF_GET_SURVEY> GetSurveyResult(SearchParam searchParam)
        {
            try
            {
                OracleParameter SurveyId_OP = new OracleParameter();
                SurveyId_OP.Direction = System.Data.ParameterDirection.Input;
                SurveyId_OP.OracleDbType = OracleDbType.Varchar2;
                SurveyId_OP.Value = searchParam.SurveyId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_FF_GET_SURVEY>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_SURVEY>.GetDataBySP(new SP_FF_GET_SURVEY(), "SP_FF_GET_SURVEY", 6, resultOutCurSor, SurveyId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Save Methods
    }
}
