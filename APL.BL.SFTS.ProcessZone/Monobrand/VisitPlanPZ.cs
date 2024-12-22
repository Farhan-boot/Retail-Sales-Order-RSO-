using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using APL.BL.SFTS.ShelterZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class VisitPlanPZ
    {
        public VisitPlanPZ()
        { }

        public List<GET_DROPDOWN> GetAmbm(decimal Id, decimal RmbmId)
        {
            List<GET_DROPDOWN> ambmList = new List<GET_DROPDOWN>();
            try
            {
                ambmList = new VisitPlanDZ().GetAmbm(Id, RmbmId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ambmList;
        }

        public List<GET_DROPDOWN> GetUsers()
        {
            List<GET_DROPDOWN> userList = new List<GET_DROPDOWN>();
            try
            {
                userList = new VisitPlanDZ().GetUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return userList;
        }

        public List<GET_DROPDOWN> GetComplainStatus(decimal ComplainTypeId)
        {
            List<GET_DROPDOWN> statusList = new List<GET_DROPDOWN>();
            try
            {
                statusList = new VisitPlanDZ().GetComplainStatus(ComplainTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return statusList;
        }

        public List<SP_GET_AMBM_SHOP_VISIT> GetAmbmShopVisitSearch(decimal UserId, decimal AmbmId, DateTime? FromDate, DateTime? ToDate)
        {
            try
            {
                return new VisitPlanDZ().GetAmbmShopVisitSearch(UserId, AmbmId, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_AMBM_SHOP_VISIT> GetAmbmShopVisit(decimal UserId)
        {
            try
            {
                return new VisitPlanDZ().GetAmbmShopVisit(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_MARKET_UPDATE> GetMarketUpdate(decimal UserId, DateTime? DateFrom, DateTime? DateTo, decimal MarketUpdateTypeId, decimal EventId)
        {
            try
            {
                return new VisitPlanDZ().GetMarketUpdate(UserId, DateFrom, DateTo, MarketUpdateTypeId, EventId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_MARKET_UPDATE_TYPE> GetMarketUpdateTypes(decimal MarketUpdateTypeId)
        {
            try
            {
                return new VisitPlanDZ().GetMarketUpdateTypes(MarketUpdateTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateMarketUpdateType(decimal Id, string Name, bool IsActive, decimal CreatedBy)
        {
            try
            {
                decimal isActive = IsActive ? 1 : 0;
                return new VisitPlanDZ().SaveUpdateMarketUpdateType(Id, Name, isActive, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_VISIT_FEEDBACK_STATUS> GetVisitFeedbackStatus(decimal VisitFeedbackStatusId)
        {
            try
            {
                return new VisitPlanDZ().GetVisitFeedbackStatus(VisitFeedbackStatusId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateVisitFeedbackStatus(decimal Id, string StatusDescription, string StatusDescriptionBAN, decimal CreatedBy)
        {
            try
            {
                return new VisitPlanDZ().SaveUpdateVisitFeedbackStatus(Id, StatusDescription, StatusDescriptionBAN, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_FEEDBACK_QUESTION_ANSWER> GetFeedbackQuestionAnswerList(decimal VisitId)
        {
            try
            {
                return new VisitPlanDZ().GetFeedbackQuestionAnswerList(VisitId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveRmbmAcknowledgement(decimal VisitId, string ApproverComment)
        {
            try
            {
                return new VisitPlanDZ().SaveRmbmAcknowledgement(VisitId, ApproverComment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public List<SP_GET_RETAILER_VISIT_PLAN> GetRetailerVisitPlan(decimal entityType, decimal visitType ,DateTime visitDate, decimal staffUserId, decimal status)
        {
            try
            {
                return new VisitPlanDZ().GetRetailerVisitPlan(entityType, visitType, visitDate, staffUserId, status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RSO_STOCK> GetRSOStock(decimal UserId)
        {
            try
            {
                return new VisitPlanDZ().GetRSOStock(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SP_CHECK_DEVICE CheckDevice(string DeviceId)
        {
            try
            {
                return new VisitPlanDZ().CheckDevice(DeviceId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SP_CHECK_USER_DEVICE CheckUserDevice(string DeviceId, string UserCode, string AppVersion,string IMEI)
        {
            try
            {
                return new VisitPlanDZ().CheckUserDevice(DeviceId, UserCode, AppVersion,IMEI).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ChangeAppPassword ChangeAppPassword(string UserCode, string Password)
        {
            try
            {
                ChangeAppPassword changeAppPassword = new ChangeAppPassword();
                changeAppPassword.status_code = 400;

                if(VerifyPassowordPolicy(Password))
                {
                    changeAppPassword.data = new VisitPlanDZ().ChangeAppPassword(UserCode, Password).FirstOrDefault();
                    changeAppPassword.status_code = 200;
                }
                else
                {
                    changeAppPassword.data = new SP_APP_PASSWORD_CHANGE
                    {
                        STATUS = 0
                    };
                    changeAppPassword.status_code = 200;
                }
                return changeAppPassword;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool VerifyPassowordPolicy(string Password)
        {
            int UniversalVerifyPolicyFlag = 0;
            int UniversalVerifyIncDecFlag = 1;
            int UniversalSameDigitFlag = 1;
            if (Password.Length > 6 || Password.Length < 6)
            {
                return false;
            }

            #region Sequence Check Asc or Dec Order
            int OrderFlag = 0;
            int passwordLength = Password.Length;

            for(int i=0; i<passwordLength; i++)
            {
                if (i > 0 && ((Password[i] >= 'a' && Password[i] <= 'z') || (Password[i] >= 'A' && Password[i] <= 'Z') || (Password[i] >= '0' && Password[i] <= '9')))
                {
                    if (i == 1)
                    {
                        var increCharTrack = (char)((int)Password[0] + 1);
                        var decCharTrack = (char)((int)Password[0] - 1);

                        if (((increCharTrack >= 'a' && increCharTrack <= 'z') || (increCharTrack >= 'A' && increCharTrack <= 'Z') || (increCharTrack >= '0' && increCharTrack <= '9')))
                        {
                            if (Password[i] == increCharTrack)
                            {
                                UniversalVerifyIncDecFlag++;
                                OrderFlag = 1; // Increcing Mode
                            }
                        }
                        if (((decCharTrack >= 'a' && decCharTrack <= 'z') || (decCharTrack >= 'A' && decCharTrack <= 'Z') || (decCharTrack >= '0' && decCharTrack <= '9')))
                        {
                            if (Password[i] == decCharTrack)
                            {
                                UniversalVerifyIncDecFlag++;
                                OrderFlag = 2; // Decreasing Mode
                            }
                        }
                        continue;
                    }

                    if (OrderFlag == 1)
                    {
                        var increCharTrack = (char)((int)Password[i-1] + 1);
                        if (((increCharTrack >= 'a' && increCharTrack <= 'z') || (increCharTrack >= 'A' && increCharTrack <= 'Z') || (increCharTrack >= '0' && increCharTrack <= '9')))
                        {
                            if (Password[i] == increCharTrack)
                            {
                                UniversalVerifyIncDecFlag++;
                            }
                        }
                    }
                    else if (OrderFlag == 2)
                    {
                        var decCharTrack = (char)((int)Password[i-1] - 1);
                        if (((decCharTrack >= 'a' && decCharTrack <= 'z') || (decCharTrack >= 'A' && decCharTrack <= 'Z') || (decCharTrack >= '0' && decCharTrack <= '9')))
                        {
                            if (Password[i] == decCharTrack)
                            {
                                UniversalVerifyIncDecFlag++;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else if (i == 0 && ((Password[i] >= 'a' && Password[i] <= 'z') || (Password[i] >= 'A' && Password[i] <= 'Z') || (Password[i] >= '0' && Password[i] <= '9')))
                {

                    continue;
                }
                else
                    break;
            }

            if(UniversalVerifyIncDecFlag == Password.Length && OrderFlag > 0)
            {
                return false;
            }
            #endregion

            #region Same Digit Test
            var FirstIndexChar = Password[0];
            for(int i = 1; i < passwordLength; i++)
            {
                if(Password[i] == FirstIndexChar)
                {
                    UniversalSameDigitFlag++;
                }
            }

            if(UniversalSameDigitFlag == Password.Length)
            {
                return false;
            }
            #endregion


            return true ;
        }

        public SP_CHECK_USER_DEVICE_OTP CheckUserDeviceOTP(string UserCode, string DeviceId, decimal OTP)
        {
            try
            {
                return new VisitPlanDZ().CheckUserDeviceOTP(UserCode, DeviceId, OTP).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_LIFTING_DETAIL> GetLiftingDetail(decimal RetailerId)
        {
            try
            {
                return new VisitPlanDZ().GetLiftingDetail(RetailerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_SHOP_VISIT_PLAN> GetShopVisitPlan(decimal entityType, decimal visitType, DateTime visitDate, decimal staffUserId, decimal status)
        {
            try
            {
                return new VisitPlanDZ().GetShopVisitPlan(entityType, visitType, visitDate, staffUserId, status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_MESSAGE> GetMessages()
        {
            try
            {
                return new VisitPlanDZ().GetMessages();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_FEEDBACK_QUESTIONNAIRE> GetFeedbackQuestionnaires(decimal QuestionnaireId)
        {
            try
            {
                return new VisitPlanDZ().GetFeedbackQuestionnaires(QuestionnaireId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_EVENT_INFO> GetEvents(decimal EventId, decimal UserId)
        {
            try
            {
                return new VisitPlanDZ().GetEvents(EventId, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_SCROLL_MESSAGE> GetScrollMessages(decimal MessageId, decimal UserId)
        {
            try
            {
                return new VisitPlanDZ().GetScrollMessages(MessageId, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_FOC_PRODUCT_INFO> GetFOCProducts(decimal TradeMaterialId, decimal UserId)
        {
            try
            {
                return new VisitPlanDZ().GetFOCProducts(TradeMaterialId, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<GET_ALL_ZONE> GetEventAreas(decimal EventId)
        {
            try
            {
                return new VisitPlanDZ().GetEventAreas(EventId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_FEEDBACK_QUESTION> GetFeedbackQuestionList(decimal VisitId, decimal RetailerId ,decimal QuestionnaireId, decimal QuestionId)
        {
            try
            {
                return new VisitPlanDZ().GetFeedbackQuestionList(VisitId, RetailerId, QuestionnaireId, QuestionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_MSISDN_LIST> GetMSISDNList(decimal StaffId, decimal RetailerId, decimal Amount)
        {
            try
            {
                return new VisitPlanDZ().GetMSISDNList(StaffId, RetailerId, Amount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_DENO_REPORT_LIST> GetDenoReportList(decimal StaffId, decimal RetailerId, decimal Amount, decimal PeriodType)
        {
            try
            {
                return new VisitPlanDZ().GetDenoReportList(StaffId, RetailerId, Amount, PeriodType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_ALL_FEEDBACK_QUESTION> GetAllFeedbackQuestions(decimal QuestionnaireId, decimal QuestionId)
        {
            try
            {
                return new VisitPlanDZ().GetAllFeedbackQuestions(QuestionnaireId, QuestionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateVisit(decimal visitID, decimal visitPlanId, decimal staffUserId, decimal entityType, decimal centerId, decimal retailerId, decimal visitTimeLat, decimal visitTimeLong, decimal feedbackStatusId, string feedbackDescription, decimal entityOtherId, string entityOtherTypeName, string entityOtherName, decimal entityOrArea, decimal visitTypeId, decimal createdBy, decimal modifiedBy, decimal reviewedBy, decimal locationIsValid, DateTime locationValidAt, decimal locationDiffDistance, List<FeedbackQuestionAnswer> ListFqa)
        {
            decimal isSaved = 0;
            try
            {
               decimal isVisitSaved = 0;
               decimal isAnswersSaved = 0;

                isVisitSaved = new VisitPlanDZ().SaveUpdateVisit(visitID, visitPlanId, staffUserId, entityType, centerId, retailerId, visitTimeLat, visitTimeLong, feedbackStatusId, feedbackDescription, entityOtherId, entityOtherTypeName, entityOtherName, entityOrArea, visitTypeId, createdBy, modifiedBy, reviewedBy, locationIsValid, locationValidAt, locationDiffDistance);
                foreach (FeedbackQuestionAnswer fqa in ListFqa)
                {
                    isAnswersSaved = new VisitPlanDZ().SaveUpdateFeedbackAnswers(fqa.Id, visitID, fqa.QuestionId, fqa.Rating, fqa.Obserbation, fqa.ActionPoint);
                }

                if (isVisitSaved > 0 && isAnswersSaved > 0)
                {
                    isSaved = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSaved;
        }


        public Decimal CancelVisit(decimal visitPlanId)
        {
            decimal isSaved = 0;
            try
            {
                isSaved = new VisitPlanDZ().CancelVisit(visitPlanId);             
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSaved;
        }


        public List<SP_GET_SHOP_STOCK> GetShopCurrentStock(decimal ShopId)
        {
            try
            {
                return new VisitPlanDZ().GetShopCurrentStock(ShopId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_SHOP_TARGET_ACHIVE> GetShopTargetVsAchivement(decimal ShopId)
        {
            try
            {
                return new VisitPlanDZ().GetShopTargetVsAchivement(ShopId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateVisitPlan(decimal VisitPlanId, DateTime VisitDate, decimal StaffUserId, decimal EntityType, decimal CenterId, decimal CreatedBy, decimal VisitTypeId)
        {
            decimal isSaved = 0;
            try
            {
                isSaved = new VisitPlanDZ().SaveUpdateVisitPlan(VisitPlanId, VisitDate, StaffUserId, EntityType, CenterId, CreatedBy, VisitTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSaved;
        }

        public Decimal SaveUpdateClosingStatus(decimal ClosingStatusId, decimal CenterId, DateTime StatusDate, string StatusDescription, string ClosingTime, decimal CreatedBy)
        {
            decimal isSaved = 0;
            try
            {
                isSaved = new VisitPlanDZ().SaveUpdateClosingStatus(ClosingStatusId, CenterId, StatusDate, StatusDescription, ClosingTime, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSaved;
        }

        public Decimal CenterLocationUpdate(decimal CenterId, decimal LatValue, decimal longValue)
        {
            decimal isSaved = 0;
            try
            {
                isSaved = new VisitPlanDZ().CenterLocationUpdate(CenterId, LatValue, longValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSaved;
        }

        public Decimal RetailerLocationUpdate(decimal RetailerId, decimal LatValue, decimal longValue, decimal UserId)
        {
            decimal isSaved = 0;
            try
            {
                isSaved = new VisitPlanDZ().RetailerLocationUpdate(RetailerId, LatValue, longValue, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSaved;
        }

        public List<GET_MARKET_UPDATE_PICTURE> GetMarketUpdatePictures(decimal MarketUpdatePictureId, decimal MarketUpdateId, decimal PictureSlNo)
        {
            try
            {
                return new VisitPlanDZ().GetMarketUpdatePictures(MarketUpdatePictureId, MarketUpdateId, PictureSlNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_COMPLAIN_PICTURE> GetComplainPictures(decimal ComplainPictureId, decimal ComplainId, decimal PictureSlNo)
        {
            try
            {
                return new VisitPlanDZ().GetComplainPictures(ComplainPictureId, ComplainId, PictureSlNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_OFFER_PICTURES> GetCurrentOfferPictures(decimal OfferPictureId, decimal OfferId, decimal PictureSlNo)
        {
            try
            {
                return new VisitPlanDZ().GetCurrentOfferPictures(OfferPictureId, OfferId, PictureSlNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_OFFER_PICTURES> GetRetailerCurrentOfferPictures(decimal OfferPictureId, decimal OfferId, decimal PictureSlNo)
        {
            try
            {
                return new VisitPlanDZ().GetRetailerCurrentOfferPictures(OfferPictureId, OfferId, PictureSlNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_COMMISSION_PICTURES> GetCommissionPictures(decimal CommissionPictureId, decimal CommissionId, decimal PictureSlNo)
        {
            try
            {
                return new VisitPlanDZ().GetCommissionPictures(CommissionPictureId, CommissionId, PictureSlNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_COMPLAINS> GetComplains(Complain complain)
        {
            try
            {
                return new VisitPlanDZ().GetComplains(complain);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_VISIT_DETAIL> GetVisitDetail(decimal UserId, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                return new VisitPlanDZ().GetVisitDetail(UserId, fromDate, toDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_CRITICAL_RETAILER> GetCriticalRetailer(decimal UserId, string CriticalType, decimal isPopup)
        {
            try
            {
                return new VisitPlanDZ().GetCriticalRetailer(UserId, CriticalType, isPopup);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_MEMO_DETAIL> GetMemoDetail(decimal UserId)
        {
            try
            {
                return new VisitPlanDZ().GetMemoDetail(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_SURVEY_LIST> GetSurveyList(decimal UserId)
        {
            try
            {
                return new VisitPlanDZ().GetSurveyList(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_WISE_PRODUCT_QTY> GetRetailerWiseProductQty(decimal ProductId, decimal UserID)
        {
            try
            {
                return new VisitPlanDZ().GetRetailerWiseProductQty(ProductId, UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_PERFORMANCE_KPI> GetPerformanceKpi()
        {
            try
            {
                return new VisitPlanDZ().GetPerformanceKpi();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_TOP_BOTTOM_RETAILER> GetTopBottomRetailers(TopBottomRetailer tbRetailer)
        {
            try
            {
                return new VisitPlanDZ().GetTopBottomRetailers(tbRetailer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_ROUTE_PERFORMANCE> GetRoutePerformance(RoutePerformance routePerf)
        {
            try
            {
                return new VisitPlanDZ().GetRoutePerformance(routePerf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_TODAY_SALES> GetTodaySales(decimal UserId, DateTime? FromDate, DateTime? ToDate)
        {
            try
            {
                return new VisitPlanDZ().GetTodaySales(UserId, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_CENTERS> GetCenters(decimal CenterId, decimal CenterTypeId)
        {
            try
            {
                return new VisitPlanDZ().GetCenters(CenterId, CenterTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_SHOP_CLOSING_STATUS> GetShopClosingStatus(DateTime StatusDate)
        {
            try
            {
                return new VisitPlanDZ().GetShopClosingStatus(StatusDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateQuestionnaire(Decimal QuestionnaireId, Decimal VisitEntityType, Decimal CenterTypeId, Decimal CreatedBy, Decimal VisitTypeId, bool IsActive)
        {
            try
            {
                decimal isActive = IsActive ? 1 : 0;
                return new VisitPlanDZ().SaveUpdateQuestionnaire(QuestionnaireId, VisitEntityType, CenterTypeId, CreatedBy, VisitTypeId, isActive);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateEventCreate(decimal EventId, string EventName, string Note, bool IsActive, decimal CreatedBy, List<GET_ID> ZoneList, bool IsToAll)
        {
            decimal result = 0;
            try
            {
                decimal isActive = IsActive ? 1 : 0;
                decimal isToAll = IsToAll ? 1 : 0;
                decimal IsEventSaved = 0;
                IsEventSaved = new VisitPlanDZ().SaveUpdateEvent(EventId, EventName, Note, isActive, CreatedBy, isToAll);
                result = IsEventSaved;
                foreach (var zone in ZoneList)
                {
                    new VisitPlanDZ().SaveUpdateEventZone(EventId, zone.Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public Decimal SaveUpdateScrollMessage(decimal MessageId, string Message, DateTime DisplayFrom, DateTime DisplayTo, bool IsActive, decimal CreatedBy)
        {
            decimal result = 0;
            try
            {
                decimal isActive = IsActive ? 1 : 0;
                decimal IsEventSaved = 0;
                IsEventSaved = new VisitPlanDZ().SaveUpdateScrollMessage(MessageId, Message, DisplayFrom, DisplayTo, isActive, CreatedBy);
                result = IsEventSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public Decimal SaveUpdateTradeMaterial(decimal TradeMaterialId, string TradeMaterialCode, string TradeMaterialName, bool IsActive, decimal CreatedBy)
        {
            decimal result = 0;
            try
            {
                decimal IsEventSaved = 0;
                decimal isActive = IsActive ? 1 : 0;
                IsEventSaved = new VisitPlanDZ().SaveUpdateTradeMaterial(TradeMaterialId, TradeMaterialCode, TradeMaterialName, isActive, CreatedBy);
                result = IsEventSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public Decimal SaveUpdateQuestion(Decimal QuestionId, Decimal QuestionnaireId, String QuestionText, Decimal CreatedBy, bool IsActive, Decimal DisplayOrder)
        {
            try
            {
                decimal isActive = IsActive ? 1 : 0;
                return new VisitPlanDZ().SaveUpdateQuestion(QuestionId, QuestionnaireId, QuestionText, CreatedBy, isActive, DisplayOrder);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public List<SP_FF_GET_RETAILER_DEMAND> GetRetailerDemandList(decimal UserId, decimal RetailerId)
		{
			try
			{
				return new VisitPlanDZ().GetRetailerDemandList(UserId, RetailerId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<SP_GET_NOTIFICATIONS> GetNotification(decimal APPID, decimal UserId, decimal Id, decimal TYPE, string FROMDATE, string TODATE)
		{
			try
			{
				return new VisitPlanDZ().GetNotification(APPID, UserId, Id, TYPE, FROMDATE, TODATE);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public List<SP_GET_ALL_EV_LIMIT> GetEVMinmaxlimit(decimal EV_Limit_Id, decimal UserId)
        {
            try
            {
                return new VisitPlanDZ().GetEVMinmaxlimit(EV_Limit_Id, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Decimal SaveUpdateEVLimit(decimal EVLimitId, decimal MinAmount, decimal MaxAmount, decimal CreatedBy)
        {
            decimal result = 0;
            try
            {
                decimal IsEventSaved = 0;
                IsEventSaved = new VisitPlanDZ().SaveUpdateEVLimit(EVLimitId, MinAmount, MaxAmount, CreatedBy);
                result = IsEventSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

    }
}
