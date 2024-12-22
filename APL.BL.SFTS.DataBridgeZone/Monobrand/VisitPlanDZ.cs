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
    public class VisitPlanDZ
    {
        public VisitPlanDZ()
        { }

        public List<GET_DROPDOWN> GetAmbm(decimal Id, decimal RmbmId)
        {
            try
            {
                OracleParameter IdOP = new OracleParameter();
                IdOP.Direction = System.Data.ParameterDirection.Input;
                IdOP.OracleDbType = OracleDbType.Decimal;
                IdOP.Value = Id;

                OracleParameter RmbmId_OP = new OracleParameter();
                RmbmId_OP.Direction = System.Data.ParameterDirection.Input;
                RmbmId_OP.OracleDbType = OracleDbType.Decimal;
                RmbmId_OP.Value = RmbmId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_DROPDOWN>)ObjectMakerFromOracleSP.OracleHelper<GET_DROPDOWN>.GetDataBySP(new GET_DROPDOWN(), "SP_FF_GET_AMBM", 3, resultOutCurSor, IdOP, RmbmId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_DROPDOWN> GetUsers()
        {
            try
            {
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_DROPDOWN>)ObjectMakerFromOracleSP.OracleHelper<GET_DROPDOWN>.GetDataBySP(new GET_DROPDOWN(), "SP_FF_GET_USERS", 3, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_DROPDOWN> GetComplainStatus(decimal ComplainTypeId)
        {
            try
            {
                OracleParameter ComplainTypeId_OP = new OracleParameter();
                ComplainTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                ComplainTypeId_OP.OracleDbType = OracleDbType.Decimal;
                ComplainTypeId_OP.Value = ComplainTypeId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_DROPDOWN>)ObjectMakerFromOracleSP.OracleHelper<GET_DROPDOWN>.GetDataBySP(new GET_DROPDOWN(), "SP_FF_GET_COMPLAIN_STATUS", 3, resultOutCurSor, ComplainTypeId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_AMBM_SHOP_VISIT> GetAmbmShopVisitSearch(decimal UserId, decimal AmbmId, DateTime? FromDate, DateTime? ToDate)
        {
            try
            {
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter AmbmId_OP = new OracleParameter();
                AmbmId_OP.Direction = System.Data.ParameterDirection.Input;
                AmbmId_OP.OracleDbType = OracleDbType.Decimal;
                AmbmId_OP.Value = AmbmId;

                OracleParameter FromDate_OP = new OracleParameter();
                FromDate_OP.Direction = System.Data.ParameterDirection.Input;
                FromDate_OP.OracleDbType = OracleDbType.Date;
                FromDate_OP.Value = FromDate;

                OracleParameter ToDate_OP = new OracleParameter();
                ToDate_OP.Direction = System.Data.ParameterDirection.Input;
                ToDate_OP.OracleDbType = OracleDbType.Date;
                ToDate_OP.Value = ToDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_AMBM_SHOP_VISIT>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_AMBM_SHOP_VISIT>.GetDataBySP(new SP_GET_AMBM_SHOP_VISIT(), "SP_FF_GET_AMBM_SHOP_VISIT_SRCH", 8, resultOutCurSor, UserId_OP, AmbmId_OP, FromDate_OP, ToDate_OP);
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
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_AMBM_SHOP_VISIT>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_AMBM_SHOP_VISIT>.GetDataBySP(new SP_GET_AMBM_SHOP_VISIT(), "SP_FF_GET_AMBM_SHOP_VISIT", 8, resultOutCurSor, UserId_OP);
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
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter DateFrom_OP = new OracleParameter();
                DateFrom_OP.Direction = System.Data.ParameterDirection.Input;
                DateFrom_OP.OracleDbType = OracleDbType.Date;
                DateFrom_OP.Value = DateFrom;

                OracleParameter DateTo_OP = new OracleParameter();
                DateTo_OP.Direction = System.Data.ParameterDirection.Input;
                DateTo_OP.OracleDbType = OracleDbType.Date;
                DateTo_OP.Value = DateTo;

                OracleParameter MarketUpdateTypeId_OP = new OracleParameter();
                MarketUpdateTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                MarketUpdateTypeId_OP.OracleDbType = OracleDbType.Decimal;
                MarketUpdateTypeId_OP.Value = MarketUpdateTypeId;

                OracleParameter EventId_OP = new OracleParameter();
                EventId_OP.Direction = System.Data.ParameterDirection.Input;
                EventId_OP.OracleDbType = OracleDbType.Decimal;
                EventId_OP.Value = EventId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_MARKET_UPDATE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_MARKET_UPDATE>.GetDataBySP(new SP_GET_MARKET_UPDATE(), "SP_FF_GET_MARKET_UPDATE", 13, resultOutCurSor, UserId_OP, DateFrom_OP, DateTo_OP, MarketUpdateTypeId_OP, EventId_OP);
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
                OracleParameter MarketUpdateTypeId_OP = new OracleParameter();
                MarketUpdateTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                MarketUpdateTypeId_OP.OracleDbType = OracleDbType.Decimal;
                MarketUpdateTypeId_OP.Value = MarketUpdateTypeId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_MARKET_UPDATE_TYPE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_MARKET_UPDATE_TYPE>.GetDataBySP(new SP_GET_MARKET_UPDATE_TYPE(), "SP_FF_GET_MARKET_UPD_TYPE", 4, resultOutCurSor, MarketUpdateTypeId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateMarketUpdateType(decimal Id, string Name, decimal IsActive, decimal CreatedBy)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter Name_OP = new OracleParameter();
                Name_OP.Direction = System.Data.ParameterDirection.Input;
                Name_OP.OracleDbType = OracleDbType.Varchar2;
                Name_OP.Value = Name;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = System.Data.ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Decimal;
                IsActive_OP.Value = IsActive;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_EVENT_INFO>.InsertDataBySP("SP_FF_IN_UP_MARKET_UPDATE_TYPE", resultOutID, Id_OP, Name_OP, CreatedBy_OP, IsActive_OP);
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
                OracleParameter VisitFeedbackStatusId_OP = new OracleParameter();
                VisitFeedbackStatusId_OP.Direction = System.Data.ParameterDirection.Input;
                VisitFeedbackStatusId_OP.OracleDbType = OracleDbType.Decimal;
                VisitFeedbackStatusId_OP.Value = VisitFeedbackStatusId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_VISIT_FEEDBACK_STATUS>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_VISIT_FEEDBACK_STATUS>.GetDataBySP(new SP_GET_VISIT_FEEDBACK_STATUS(), "SP_FF_GET_VISIT_FBACK_STATUS", 3, resultOutCurSor, VisitFeedbackStatusId_OP);
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
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter StatusDescription_OP = new OracleParameter();
                StatusDescription_OP.Direction = System.Data.ParameterDirection.Input;
                StatusDescription_OP.OracleDbType = OracleDbType.Varchar2;
                StatusDescription_OP.Value = StatusDescription;

				OracleParameter StatusDescriptionBAN_OP = new OracleParameter();
				StatusDescriptionBAN_OP.Direction = System.Data.ParameterDirection.Input;
				StatusDescriptionBAN_OP.OracleDbType = OracleDbType.NVarchar2;
				StatusDescriptionBAN_OP.Value = StatusDescriptionBAN;

				OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_EVENT_INFO>.InsertDataBySP("SP_FF_IN_UP_VISIT_FBACK_STATUS", resultOutID, Id_OP, StatusDescription_OP, StatusDescriptionBAN_OP, CreatedBy_OP);
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
                OracleParameter VisitId_OP = new OracleParameter();
                VisitId_OP.Direction = System.Data.ParameterDirection.Input;
                VisitId_OP.OracleDbType = OracleDbType.Decimal;
                VisitId_OP.Value = VisitId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_FEEDBACK_QUESTION_ANSWER>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FEEDBACK_QUESTION_ANSWER>.GetDataBySP(new SP_GET_FEEDBACK_QUESTION_ANSWER(), "SP_FF_GET_FEEDBACK_QA", 5, resultOutCurSor, VisitId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveRmbmAcknowledgement(decimal VisitId, string ApproverComment)
        {
            try
            {
                OracleParameter VisitId_OP = new OracleParameter();
                VisitId_OP.Direction = System.Data.ParameterDirection.Input;
                VisitId_OP.OracleDbType = OracleDbType.Decimal;
                VisitId_OP.Value = VisitId;

                OracleParameter ApproverComment_OP = new OracleParameter();
                ApproverComment_OP.Direction = System.Data.ParameterDirection.Input;
                ApproverComment_OP.OracleDbType = OracleDbType.Varchar2;
                ApproverComment_OP.Value = ApproverComment;


                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_RMBM_ACKNOWLEDGEMENT", resultOutID, VisitId_OP, ApproverComment_OP);
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
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_MESSAGE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_MESSAGE>.GetDataBySP(new SP_GET_MESSAGE(), "SP_FF_GET_SCROLL_MESSAGE", 1, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_VISIT_PLAN> GetRetailerVisitPlan(decimal entityType, decimal visitType, DateTime visitDate, decimal staffId, decimal status)
        {
            try
            {
                OracleParameter entityType_OP = new OracleParameter();
                entityType_OP.Direction = System.Data.ParameterDirection.Input;
                entityType_OP.OracleDbType = OracleDbType.Decimal;
                entityType_OP.Value = entityType;

                OracleParameter visitType_OP = new OracleParameter();
                visitType_OP.Direction = System.Data.ParameterDirection.Input;
                visitType_OP.OracleDbType = OracleDbType.Decimal;
                visitType_OP.Value = visitType;

                OracleParameter visitDate_OP = new OracleParameter();
                visitDate_OP.Direction = System.Data.ParameterDirection.Input;
                visitDate_OP.OracleDbType = OracleDbType.Date;
                visitDate_OP.Value = visitDate;

                OracleParameter staffId_OP = new OracleParameter();
                staffId_OP.Direction = System.Data.ParameterDirection.Input;
                staffId_OP.OracleDbType = OracleDbType.Decimal;
                staffId_OP.Value = staffId;

                OracleParameter status_OP = new OracleParameter();
                status_OP.Direction = System.Data.ParameterDirection.Input;
                status_OP.OracleDbType = OracleDbType.Decimal;
                status_OP.Value = status;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_VISIT_PLAN>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_VISIT_PLAN>.GetDataBySP(new SP_GET_RETAILER_VISIT_PLAN(), "SP_FF_GET_VISIT_PLAN_ENTITY", 14, resultOutCurSor, entityType_OP, visitType_OP, visitDate_OP, staffId_OP, status_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RSO_STOCK> GetRSOStock(decimal userId)
        {
            try
            {
                OracleParameter userId_OP = new OracleParameter();
                userId_OP.Direction = System.Data.ParameterDirection.Input;
                userId_OP.OracleDbType = OracleDbType.Decimal;
                userId_OP.Value = userId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RSO_STOCK>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_STOCK>.GetDataBySP(new SP_GET_RSO_STOCK(), "SP_FF_GET_RSO_STOCK_API", 6, resultOutCurSor, userId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_CHECK_DEVICE> CheckDevice(string DeviceId)
        {
            try
            {
                OracleParameter device_OP = new OracleParameter();
                device_OP.Direction = System.Data.ParameterDirection.Input;
                device_OP.OracleDbType = OracleDbType.Varchar2;
                device_OP.Value = DeviceId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_CHECK_DEVICE>)ObjectMakerFromOracleSP.OracleHelper<SP_CHECK_DEVICE>.GetDataBySP(new SP_CHECK_DEVICE(), "SP_CHECK_DEVICE", 2, resultOutCurSor, device_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_CHECK_USER_DEVICE> CheckUserDevice(string DeviceId, string UserCode, string AppVersion,string IMEI)
        {
            try
            {
                OracleParameter device_OP = new OracleParameter();
                device_OP.Direction = System.Data.ParameterDirection.Input;
                device_OP.OracleDbType = OracleDbType.Varchar2;
                device_OP.Value = DeviceId;

                OracleParameter userCode_OP = new OracleParameter();
                userCode_OP.Direction = System.Data.ParameterDirection.Input;
                userCode_OP.OracleDbType = OracleDbType.Varchar2;
                userCode_OP.Value = UserCode;

                OracleParameter appVersion_OP = new OracleParameter();
                appVersion_OP.Direction = System.Data.ParameterDirection.Input;
                appVersion_OP.OracleDbType = OracleDbType.Varchar2;
                appVersion_OP.Value = AppVersion;


                OracleParameter IMEI_OP = new OracleParameter();
                IMEI_OP.Direction = System.Data.ParameterDirection.Input;
                IMEI_OP.OracleDbType = OracleDbType.Varchar2;
                IMEI_OP.Value = IMEI;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List< SP_CHECK_USER_DEVICE>)ObjectMakerFromOracleSP.OracleHelper<SP_CHECK_USER_DEVICE>.GetDataBySP(new SP_CHECK_USER_DEVICE(), "SP_CHECK_USER_DEVICE", 2, resultOutCurSor, device_OP, userCode_OP, appVersion_OP, IMEI_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_APP_PASSWORD_CHANGE> ChangeAppPassword(string UserCode, string Password)
        {
            try
            {

                OracleParameter userCode_OP = new OracleParameter();
                userCode_OP.Direction = System.Data.ParameterDirection.Input;
                userCode_OP.OracleDbType = OracleDbType.Varchar2;
                userCode_OP.Value = UserCode;

                OracleParameter password_OP = new OracleParameter();
                password_OP.Direction = System.Data.ParameterDirection.Input;
                password_OP.OracleDbType = OracleDbType.Varchar2;
                password_OP.Value = Password;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_APP_PASSWORD_CHANGE>)ObjectMakerFromOracleSP.OracleHelper<SP_APP_PASSWORD_CHANGE>.GetDataBySP(new SP_APP_PASSWORD_CHANGE(), "SP_APP_PASSWORD_CHANGE", 1, resultOutCurSor,  userCode_OP, password_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_CHECK_USER_DEVICE_OTP> CheckUserDeviceOTP(string UserCode, string DeviceId, decimal OTP)
        {
            try
            {

                OracleParameter userCode_OP = new OracleParameter();
                userCode_OP.Direction = System.Data.ParameterDirection.Input;
                userCode_OP.OracleDbType = OracleDbType.Varchar2;
                userCode_OP.Value = UserCode;

                OracleParameter deviceId_OP = new OracleParameter();
                deviceId_OP.Direction = System.Data.ParameterDirection.Input;
                deviceId_OP.OracleDbType = OracleDbType.Varchar2;
                deviceId_OP.Value = DeviceId;

                OracleParameter otp_OP = new OracleParameter();
                otp_OP.Direction = System.Data.ParameterDirection.Input;
                otp_OP.OracleDbType = OracleDbType.Decimal;
                otp_OP.Value = OTP;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_CHECK_USER_DEVICE_OTP>)ObjectMakerFromOracleSP.OracleHelper<SP_CHECK_USER_DEVICE_OTP>.GetDataBySP(new SP_CHECK_USER_DEVICE_OTP(), "SP_CHECK_USER_DEVICE_OTP", 2, resultOutCurSor, deviceId_OP, userCode_OP, otp_OP);
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
                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;             

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_LIFTING_DETAIL>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_LIFTING_DETAIL>.GetDataBySP(new SP_GET_LIFTING_DETAIL(), "SP_FF_GET_LIFTING_DETAIL", 7, resultOutCurSor, RetailerId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_SHOP_VISIT_PLAN> GetShopVisitPlan(decimal entityType, decimal visitType, DateTime visitDate, decimal staffId, decimal status)
        {
            try
            {
                OracleParameter entityType_OP = new OracleParameter();
                entityType_OP.Direction = System.Data.ParameterDirection.Input;
                entityType_OP.OracleDbType = OracleDbType.Decimal;
                entityType_OP.Value = entityType;

                OracleParameter visitType_OP = new OracleParameter();
                visitType_OP.Direction = System.Data.ParameterDirection.Input;
                visitType_OP.OracleDbType = OracleDbType.Decimal;
                visitType_OP.Value = visitType;

                OracleParameter visitDate_OP = new OracleParameter();
                visitDate_OP.Direction = System.Data.ParameterDirection.Input;
                visitDate_OP.OracleDbType = OracleDbType.Date;
                visitDate_OP.Value = visitDate;

                OracleParameter staffId_OP = new OracleParameter();
                staffId_OP.Direction = System.Data.ParameterDirection.Input;
                staffId_OP.OracleDbType = OracleDbType.Decimal;
                staffId_OP.Value = staffId;

                OracleParameter status_OP = new OracleParameter();
                status_OP.Direction = System.Data.ParameterDirection.Input;
                status_OP.OracleDbType = OracleDbType.Decimal;
                status_OP.Value = status;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SHOP_VISIT_PLAN>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SHOP_VISIT_PLAN>.GetDataBySP(new SP_GET_SHOP_VISIT_PLAN(), "SP_FF_GET_VISIT_PLAN_ENTITY", 9, resultOutCurSor, entityType_OP, visitType_OP, visitDate_OP, staffId_OP, status_OP);
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
                OracleParameter QuestionnaireId_OP = new OracleParameter();
                QuestionnaireId_OP.Direction = System.Data.ParameterDirection.Input;
                QuestionnaireId_OP.OracleDbType = OracleDbType.Decimal;
                QuestionnaireId_OP.Value = QuestionnaireId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_FEEDBACK_QUESTIONNAIRE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FEEDBACK_QUESTIONNAIRE>.GetDataBySP(new SP_GET_FEEDBACK_QUESTIONNAIRE(), "SP_FF_GET_FDBACK_QUESTIONNAIRE", 8, resultOutCurSor, QuestionnaireId_OP);
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
                OracleParameter EventId_OP = new OracleParameter();
                EventId_OP.Direction = System.Data.ParameterDirection.Input;
                EventId_OP.OracleDbType = OracleDbType.Decimal;
                EventId_OP.Value = EventId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_EVENT_INFO>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_EVENT_INFO>.GetDataBySP(new SP_GET_EVENT_INFO(), "SP_FF_GET_EVENT", 5, resultOutCurSor, EventId_OP, UserId_OP);
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
                OracleParameter MessageId_OP = new OracleParameter();
                MessageId_OP.Direction = System.Data.ParameterDirection.Input;
                MessageId_OP.OracleDbType = OracleDbType.Decimal;
                MessageId_OP.Value = MessageId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SCROLL_MESSAGE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SCROLL_MESSAGE>.GetDataBySP(new SP_GET_SCROLL_MESSAGE(), "SP_FF_GET_ALL_SCROLL_MESSAGE", 5, resultOutCurSor, MessageId_OP, UserId_OP);
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
                OracleParameter TradeMaterialId_OP = new OracleParameter();
                TradeMaterialId_OP.Direction = System.Data.ParameterDirection.Input;
                TradeMaterialId_OP.OracleDbType = OracleDbType.Decimal;
                TradeMaterialId_OP.Value = TradeMaterialId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_FOC_PRODUCT_INFO>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FOC_PRODUCT_INFO>.GetDataBySP(new SP_GET_FOC_PRODUCT_INFO(), "SP_FF_GET_ALL_FOC_PRODUCT", 5, resultOutCurSor, TradeMaterialId_OP, UserId_OP);
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
                OracleParameter EventId_OP = new OracleParameter();
                EventId_OP.Direction = System.Data.ParameterDirection.Input;
                EventId_OP.OracleDbType = OracleDbType.Decimal;
                EventId_OP.Value = EventId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_ALL_ZONE>)ObjectMakerFromOracleSP.OracleHelper<GET_ALL_ZONE>.GetDataBySP(new GET_ALL_ZONE(), "SP_FF_GET_EVENT_AREAS", 3, resultOutCurSor, EventId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_FEEDBACK_QUESTION> GetFeedbackQuestionList(decimal VisitId, decimal RetailerId,decimal QuestionnaireId, decimal QuestionId)
        {
            try
            {
                OracleParameter VisitId_OP = new OracleParameter();
                VisitId_OP.Direction = System.Data.ParameterDirection.Input;
                VisitId_OP.OracleDbType = OracleDbType.Decimal;
                VisitId_OP.Value = VisitId;

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;

                OracleParameter QuestionnaireId_OP = new OracleParameter();
                QuestionnaireId_OP.Direction = System.Data.ParameterDirection.Input;
                QuestionnaireId_OP.OracleDbType = OracleDbType.Decimal;
                QuestionnaireId_OP.Value = QuestionnaireId;

                OracleParameter QuestionId_OP = new OracleParameter();
                QuestionId_OP.Direction = System.Data.ParameterDirection.Input;
                QuestionId_OP.OracleDbType = OracleDbType.Decimal;
                QuestionId_OP.Value = QuestionId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_FEEDBACK_QUESTION>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FEEDBACK_QUESTION>.GetDataBySP(new SP_GET_FEEDBACK_QUESTION(), "SP_FF_GET_FEEDBACK_QUESTION", 7, resultOutCurSor, VisitId_OP, RetailerId_OP, QuestionnaireId_OP, QuestionId_OP);
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
                OracleParameter StaffId_OP = new OracleParameter();
                StaffId_OP.Direction = System.Data.ParameterDirection.Input;
                StaffId_OP.OracleDbType = OracleDbType.Decimal;
                StaffId_OP.Value = StaffId;

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;

                OracleParameter Amount_OP = new OracleParameter();
                Amount_OP.Direction = System.Data.ParameterDirection.Input;
                Amount_OP.OracleDbType = OracleDbType.Decimal;
                Amount_OP.Value = Amount;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_MSISDN_LIST>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_MSISDN_LIST>.GetDataBySP(new SP_GET_MSISDN_LIST(), "SP_GET_MSISDN_LIST", 4, resultOutCurSor, StaffId_OP, RetailerId_OP, Amount_OP);
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
                OracleParameter StaffId_OP = new OracleParameter();
                StaffId_OP.Direction = System.Data.ParameterDirection.Input;
                StaffId_OP.OracleDbType = OracleDbType.Decimal;
                StaffId_OP.Value = StaffId;

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;

                OracleParameter Amount_OP = new OracleParameter();
                Amount_OP.Direction = System.Data.ParameterDirection.Input;
                Amount_OP.OracleDbType = OracleDbType.Decimal;
                Amount_OP.Value = Amount;

				OracleParameter PeriodType_OP = new OracleParameter();
				PeriodType_OP.Direction = System.Data.ParameterDirection.Input;
				PeriodType_OP.OracleDbType = OracleDbType.Decimal;
				PeriodType_OP.Value = PeriodType;

				OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_DENO_REPORT_LIST>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_DENO_REPORT_LIST>.GetDataBySP(new SP_GET_DENO_REPORT_LIST(), "SP_GET_DENO_REPORT_LIST", 4, resultOutCurSor, StaffId_OP, RetailerId_OP, Amount_OP, PeriodType_OP);
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
                OracleParameter QuestionnaireId_OP = new OracleParameter();
                QuestionnaireId_OP.Direction = System.Data.ParameterDirection.Input;
                QuestionnaireId_OP.OracleDbType = OracleDbType.Decimal;
                QuestionnaireId_OP.Value = QuestionnaireId;

                OracleParameter QuestionId_OP = new OracleParameter();
                QuestionId_OP.Direction = System.Data.ParameterDirection.Input;
                QuestionId_OP.OracleDbType = OracleDbType.Decimal;
                QuestionId_OP.Value = QuestionId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_ALL_FEEDBACK_QUESTION>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ALL_FEEDBACK_QUESTION>.GetDataBySP(new SP_GET_ALL_FEEDBACK_QUESTION(), "SP_FF_GET_ALL_FBACK_QUESTION", 3, resultOutCurSor, QuestionnaireId_OP, QuestionId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateVisit(decimal visitID, decimal visitPlanId, decimal staffUserId, decimal entityType, decimal centerId, decimal retailerId, decimal visitTimeLat, decimal visitTimeLong, decimal feedbackStatusId, string feedbackDescription, decimal entityOtherId, string entityOtherTypeName, string entityOtherName, decimal entityOrArea, decimal visitTypeId, decimal createdBy, decimal modifiedBy, decimal reviewedBy, decimal locationIsValid, DateTime locationValidAt, decimal locationDiffDistance)
        {
            try
            {
                OracleParameter visitID_OP = new OracleParameter();
                visitID_OP.Direction = System.Data.ParameterDirection.Input;
                visitID_OP.OracleDbType = OracleDbType.Decimal;
                visitID_OP.Value = visitID;

                //OracleParameter visitedDate_OP = new OracleParameter();
                //visitedDate_OP.Direction = System.Data.ParameterDirection.Input;
                //visitedDate_OP.OracleDbType = OracleDbType.Date;
                //visitedDate_OP.Value = visitedDate;

                OracleParameter visitPlanId_OP = new OracleParameter();
                visitPlanId_OP.Direction = System.Data.ParameterDirection.Input;
                visitPlanId_OP.OracleDbType = OracleDbType.Decimal;
                visitPlanId_OP.Value = visitPlanId;

                OracleParameter staffUserId_OP = new OracleParameter();
                staffUserId_OP.Direction = System.Data.ParameterDirection.Input;
                staffUserId_OP.OracleDbType = OracleDbType.Decimal;
                staffUserId_OP.Value = staffUserId;

                OracleParameter entityType_OP = new OracleParameter();
                entityType_OP.Direction = System.Data.ParameterDirection.Input;
                entityType_OP.OracleDbType = OracleDbType.Decimal;
                entityType_OP.Value = entityType;

                OracleParameter centerId_OP = new OracleParameter();
                centerId_OP.Direction = System.Data.ParameterDirection.Input;
                centerId_OP.OracleDbType = OracleDbType.Decimal;
                centerId_OP.Value = centerId;

                OracleParameter retailerId_OP = new OracleParameter();
                retailerId_OP.Direction = System.Data.ParameterDirection.Input;
                retailerId_OP.OracleDbType = OracleDbType.Decimal;
                retailerId_OP.Value = retailerId;

                OracleParameter visitTimeLat_OP = new OracleParameter();
                visitTimeLat_OP.Direction = System.Data.ParameterDirection.Input;
                visitTimeLat_OP.OracleDbType = OracleDbType.Decimal;
                visitTimeLat_OP.Value = visitTimeLat;

                OracleParameter visitTimeLong_OP = new OracleParameter();
                visitTimeLong_OP.Direction = System.Data.ParameterDirection.Input;
                visitTimeLong_OP.OracleDbType = OracleDbType.Decimal;
                visitTimeLong_OP.Value = visitTimeLong;

                OracleParameter feedbackStatusId_OP = new OracleParameter();
                feedbackStatusId_OP.Direction = System.Data.ParameterDirection.Input;
                feedbackStatusId_OP.OracleDbType = OracleDbType.Decimal;
                feedbackStatusId_OP.Value = feedbackStatusId;

                OracleParameter feedbackDescription_OP = new OracleParameter();
                feedbackDescription_OP.Direction = System.Data.ParameterDirection.Input;
                feedbackDescription_OP.OracleDbType = OracleDbType.Varchar2;
                feedbackDescription_OP.Value = feedbackDescription;

                OracleParameter entityOtherId_OP = new OracleParameter();
                entityOtherId_OP.Direction = System.Data.ParameterDirection.Input;
                entityOtherId_OP.OracleDbType = OracleDbType.Decimal;
                entityOtherId_OP.Value = entityOtherId;

                OracleParameter entityOtherTypeName_OP = new OracleParameter();
                entityOtherTypeName_OP.Direction = System.Data.ParameterDirection.Input;
                entityOtherTypeName_OP.OracleDbType = OracleDbType.Varchar2;
                entityOtherTypeName_OP.Value = entityOtherTypeName;

                OracleParameter entityOtherName_OP = new OracleParameter();
                entityOtherName_OP.Direction = System.Data.ParameterDirection.Input;
                entityOtherName_OP.OracleDbType = OracleDbType.Varchar2;
                entityOtherName_OP.Value = entityOtherName;

                OracleParameter entityOrArea_OP = new OracleParameter();
                entityOrArea_OP.Direction = System.Data.ParameterDirection.Input;
                entityOrArea_OP.OracleDbType = OracleDbType.Decimal;
                entityOrArea_OP.Value = entityOrArea;

                //OracleParameter marketAreaId_OP = new OracleParameter();
                //marketAreaId_OP.Direction = System.Data.ParameterDirection.Input;
                //marketAreaId_OP.OracleDbType = OracleDbType.Decimal;
                //marketAreaId_OP.Value = marketAreaId;

                OracleParameter visitTypeId_OP = new OracleParameter();
                visitTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                visitTypeId_OP.OracleDbType = OracleDbType.Decimal;
                visitTypeId_OP.Value = visitTypeId;

                OracleParameter createdBy_OP = new OracleParameter();
                createdBy_OP.Direction = System.Data.ParameterDirection.Input;
                createdBy_OP.OracleDbType = OracleDbType.Decimal;
                createdBy_OP.Value = createdBy;

                OracleParameter modifiedBy_OP = new OracleParameter();
                modifiedBy_OP.Direction = System.Data.ParameterDirection.Input;
                modifiedBy_OP.OracleDbType = OracleDbType.Decimal;
                modifiedBy_OP.Value = modifiedBy;

                OracleParameter reviewedBy_OP = new OracleParameter();
                reviewedBy_OP.Direction = System.Data.ParameterDirection.Input;
                reviewedBy_OP.OracleDbType = OracleDbType.Decimal;
                reviewedBy_OP.Value = reviewedBy;

                OracleParameter locationIsValid_OP = new OracleParameter();
                locationIsValid_OP.Direction = System.Data.ParameterDirection.Input;
                locationIsValid_OP.OracleDbType = OracleDbType.Decimal;
                locationIsValid_OP.Value = locationIsValid;

                OracleParameter locationValidAt_OP = new OracleParameter();
                locationValidAt_OP.Direction = System.Data.ParameterDirection.Input;
                locationValidAt_OP.OracleDbType = OracleDbType.Date;
                locationValidAt_OP.Value = locationValidAt;

                //OracleParameter locationDiffDistance_OP = new OracleParameter();
                //locationDiffDistance_OP.Direction = System.Data.ParameterDirection.Input;
                //locationDiffDistance_OP.OracleDbType = OracleDbType.Decimal;
                //locationDiffDistance_OP.Value = locationDiffDistance;

                OracleParameter outVisitIDOP = new OracleParameter();
                outVisitIDOP.Direction = System.Data.ParameterDirection.Output;
                outVisitIDOP.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<INS_UPD_VISIT>.InsertDataBySP("SP_FF_INS_UPD_VISIT", outVisitIDOP, visitID_OP, visitPlanId_OP, staffUserId_OP, entityType_OP, centerId_OP, retailerId_OP, visitTimeLat_OP, visitTimeLong_OP, feedbackStatusId_OP, feedbackDescription_OP, entityOtherId_OP, entityOtherTypeName_OP, entityOtherName_OP, entityOrArea_OP, visitTypeId_OP, createdBy_OP, modifiedBy_OP, reviewedBy_OP, locationIsValid_OP, locationValidAt_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateFeedbackAnswers(decimal Id, decimal VisitID, decimal QuestionId, decimal Ratting, string Obserbation, string ActionPoint)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter VisitID_OP = new OracleParameter();
                VisitID_OP.Direction = System.Data.ParameterDirection.Input;
                VisitID_OP.OracleDbType = OracleDbType.Decimal;
                VisitID_OP.Value = VisitID;

                OracleParameter QuestionId_OP = new OracleParameter();
                QuestionId_OP.Direction = System.Data.ParameterDirection.Input;
                QuestionId_OP.OracleDbType = OracleDbType.Decimal;
                QuestionId_OP.Value = QuestionId;

                OracleParameter Ratting_OP = new OracleParameter();
                Ratting_OP.Direction = System.Data.ParameterDirection.Input;
                Ratting_OP.OracleDbType = OracleDbType.Decimal;
                Ratting_OP.Value = Ratting;

                OracleParameter Obserbation_OP = new OracleParameter();
                Obserbation_OP.Direction = System.Data.ParameterDirection.Input;
                Obserbation_OP.OracleDbType = OracleDbType.Varchar2;
                Obserbation_OP.Value = Obserbation;

                OracleParameter ActionPoint_OP = new OracleParameter();
                ActionPoint_OP.Direction = System.Data.ParameterDirection.Input;
                ActionPoint_OP.OracleDbType = OracleDbType.Varchar2;
                ActionPoint_OP.Value = ActionPoint;
             
                OracleParameter outVisitIDOP = new OracleParameter();
                outVisitIDOP.Direction = System.Data.ParameterDirection.Output;
                outVisitIDOP.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<INS_UPD_FEEDBACK_ANSWERS>.InsertDataBySP("SP_FF_INS_UPD_FEDBCK_ANSWERS", outVisitIDOP, Id_OP, VisitID_OP, QuestionId_OP, Ratting_OP, Obserbation_OP, ActionPoint_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Decimal CancelVisit(decimal visitPlanId)
        {
            try
            {
                OracleParameter visitPlanId_OP = new OracleParameter();
                visitPlanId_OP.Direction = System.Data.ParameterDirection.Input;
                visitPlanId_OP.OracleDbType = OracleDbType.Decimal;
                visitPlanId_OP.Value = visitPlanId;

                OracleParameter outIDOP = new OracleParameter();
                outIDOP.Direction = System.Data.ParameterDirection.Output;
                outIDOP.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<INS_UPD_VISIT>.InsertDataBySP("SP_FF_CANCEL_VISIT", outIDOP, visitPlanId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_SHOP_STOCK> GetShopCurrentStock(decimal ShopId)
        {
            try
            {
                OracleParameter ShopId_OP = new OracleParameter();
                ShopId_OP.Direction = System.Data.ParameterDirection.Input;
                ShopId_OP.OracleDbType = OracleDbType.Decimal;
                ShopId_OP.Value = ShopId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SHOP_STOCK>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SHOP_STOCK>.GetDataBySP(new SP_GET_SHOP_STOCK(), "SP_FF_GET_CURRENT_STOCK", 3, resultOutCurSor, ShopId_OP);
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
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = complain.Id;

                OracleParameter ComplainFor_OP = new OracleParameter();
                ComplainFor_OP.Direction = System.Data.ParameterDirection.Input;
                ComplainFor_OP.OracleDbType = OracleDbType.Decimal;
                ComplainFor_OP.Value = complain.ComplainFor;

                OracleParameter ComplainForId_OP = new OracleParameter();
                ComplainForId_OP.Direction = System.Data.ParameterDirection.Input;
                ComplainForId_OP.OracleDbType = OracleDbType.Decimal;
                ComplainForId_OP.Value = complain.ComplainForId;

                OracleParameter TypeId_OP = new OracleParameter();
                TypeId_OP.Direction = System.Data.ParameterDirection.Input;
                TypeId_OP.OracleDbType = OracleDbType.Decimal;
                TypeId_OP.Value = complain.TypeId;

                OracleParameter StatusId_OP = new OracleParameter();
                StatusId_OP.Direction = System.Data.ParameterDirection.Input;
                StatusId_OP.OracleDbType = OracleDbType.Decimal;
                StatusId_OP.Value = complain.StatusId;

                OracleParameter FromDate_OP = new OracleParameter();
                FromDate_OP.Direction = System.Data.ParameterDirection.Input;
                FromDate_OP.OracleDbType = OracleDbType.Date;
                FromDate_OP.Value = complain.FromDate;

                OracleParameter ToDate_OP = new OracleParameter();
                ToDate_OP.Direction = System.Data.ParameterDirection.Input;
                ToDate_OP.OracleDbType = OracleDbType.Date;
                ToDate_OP.Value = complain.ToDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_COMPLAINS>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_COMPLAINS>.GetDataBySP(new SP_GET_COMPLAINS(), "SP_FF_GET_COMPLAINS", 13, resultOutCurSor, Id_OP, ComplainFor_OP, ComplainForId_OP, TypeId_OP, StatusId_OP, FromDate_OP, ToDate_OP);
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
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_PERFORMANCE_KPI>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_PERFORMANCE_KPI>.GetDataBySP(new SP_GET_PERFORMANCE_KPI(), "SP_FF_GET_PERFORMANCE_KPI", 3, resultOutCurSor);
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
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = tbRetailer.UserId;

                OracleParameter DistributorCode_OP = new OracleParameter();
                DistributorCode_OP.Direction = System.Data.ParameterDirection.Input;
                DistributorCode_OP.OracleDbType = OracleDbType.Varchar2;
                DistributorCode_OP.Value = tbRetailer.DistributorCode;

                OracleParameter AreaCode_OP = new OracleParameter();
                AreaCode_OP.Direction = System.Data.ParameterDirection.Input;
                AreaCode_OP.OracleDbType = OracleDbType.Varchar2;
                AreaCode_OP.Value = tbRetailer.AreaCode;

                OracleParameter Scope_OP = new OracleParameter();
                Scope_OP.Direction = System.Data.ParameterDirection.Input;
                Scope_OP.OracleDbType = OracleDbType.Decimal;
                Scope_OP.Value = tbRetailer.Scope;

                OracleParameter KpiCode_OP = new OracleParameter();
                KpiCode_OP.Direction = System.Data.ParameterDirection.Input;
                KpiCode_OP.OracleDbType = OracleDbType.Varchar2;
                KpiCode_OP.Value = tbRetailer.KpiCode;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_TOP_BOTTOM_RETAILER>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TOP_BOTTOM_RETAILER>.GetDataBySP(new SP_GET_TOP_BOTTOM_RETAILER(), "SP_FF_GET_TOP_BOTTOM_RET", 10, resultOutCurSor, UserId_OP, DistributorCode_OP, AreaCode_OP, Scope_OP, KpiCode_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_ROUTE_PERFORMANCE> GetRoutePerformance(RoutePerformance routePerformance)
        {
            try
            {
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = routePerformance.UserId;

                OracleParameter DistributorCode_OP = new OracleParameter();
                DistributorCode_OP.Direction = System.Data.ParameterDirection.Input;
                DistributorCode_OP.OracleDbType = OracleDbType.Varchar2;
                DistributorCode_OP.Value = routePerformance.DistributorCode;

                OracleParameter AreaCode_OP = new OracleParameter();
                AreaCode_OP.Direction = System.Data.ParameterDirection.Input;
                AreaCode_OP.OracleDbType = OracleDbType.Varchar2;
                AreaCode_OP.Value = routePerformance.AreaCode;

                OracleParameter Scope_OP = new OracleParameter();
                Scope_OP.Direction = System.Data.ParameterDirection.Input;
                Scope_OP.OracleDbType = OracleDbType.Decimal;
                Scope_OP.Value = routePerformance.Scope;

                OracleParameter KpiCode_OP = new OracleParameter();
                KpiCode_OP.Direction = System.Data.ParameterDirection.Input;
                KpiCode_OP.OracleDbType = OracleDbType.Varchar2;
                KpiCode_OP.Value = routePerformance.KpiCode;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_ROUTE_PERFORMANCE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ROUTE_PERFORMANCE>.GetDataBySP(new SP_GET_ROUTE_PERFORMANCE(), "SP_FF_GET_ROUTE_PERFORMANCE", 10, resultOutCurSor, UserId_OP, DistributorCode_OP, AreaCode_OP, Scope_OP, KpiCode_OP);
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
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter FromDate_OP = new OracleParameter();
                FromDate_OP.Direction = System.Data.ParameterDirection.Input;
                FromDate_OP.OracleDbType = OracleDbType.Date;
                FromDate_OP.Value = FromDate;

                OracleParameter ToDate_OP = new OracleParameter();
                ToDate_OP.Direction = System.Data.ParameterDirection.Input;
                ToDate_OP.OracleDbType = OracleDbType.Date;
                ToDate_OP.Value = ToDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_TODAY_SALES>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TODAY_SALES>.GetDataBySP(new SP_GET_TODAY_SALES(), "SP_FF_GET_RSO_SALES", 7, resultOutCurSor, UserId_OP, FromDate_OP, ToDate_OP);
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
                OracleParameter CenterId_OP = new OracleParameter();
                CenterId_OP.Direction = System.Data.ParameterDirection.Input;
                CenterId_OP.OracleDbType = OracleDbType.Decimal;
                CenterId_OP.Value = CenterId;

                OracleParameter CenterTypeId_OP = new OracleParameter();
                CenterTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                CenterTypeId_OP.OracleDbType = OracleDbType.Decimal;
                CenterTypeId_OP.Value = CenterTypeId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_CENTERS>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_CENTERS>.GetDataBySP(new SP_GET_CENTERS(), "SP_FF_GET_CENTERS", 6, resultOutCurSor, CenterId_OP, CenterTypeId_OP);
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
                OracleParameter ShopId_OP = new OracleParameter();
                ShopId_OP.Direction = System.Data.ParameterDirection.Input;
                ShopId_OP.OracleDbType = OracleDbType.Decimal;
                ShopId_OP.Value = ShopId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SHOP_TARGET_ACHIVE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SHOP_TARGET_ACHIVE>.GetDataBySP(new SP_GET_SHOP_TARGET_ACHIVE(), "SP_FF_GET_SHOP_TARGET_ACHIVE", 7, resultOutCurSor, ShopId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateVisitPlan(decimal VisitPlanId, DateTime VisitDate, decimal StaffUserId, decimal EntityType, decimal CenterId, decimal CreatedBy, decimal VisitTypeId)
        {
            try
            {
                OracleParameter VisitPlanId_OP = new OracleParameter();
                VisitPlanId_OP.Direction = System.Data.ParameterDirection.Input;
                VisitPlanId_OP.OracleDbType = OracleDbType.Decimal;
                VisitPlanId_OP.Value = VisitPlanId;

                OracleParameter VisitDate_OP = new OracleParameter();
                VisitDate_OP.Direction = System.Data.ParameterDirection.Input;
                VisitDate_OP.OracleDbType = OracleDbType.Date;
                VisitDate_OP.Value = VisitDate;

                OracleParameter StaffUserId_OP = new OracleParameter();
                StaffUserId_OP.Direction = System.Data.ParameterDirection.Input;
                StaffUserId_OP.OracleDbType = OracleDbType.Decimal;
                StaffUserId_OP.Value = StaffUserId;

                OracleParameter EntityType_OP = new OracleParameter();
                EntityType_OP.Direction = System.Data.ParameterDirection.Input;
                EntityType_OP.OracleDbType = OracleDbType.Decimal;
                EntityType_OP.Value = EntityType;

                OracleParameter CenterId_OP = new OracleParameter();
                CenterId_OP.Direction = System.Data.ParameterDirection.Input;
                CenterId_OP.OracleDbType = OracleDbType.Decimal;
                CenterId_OP.Value = CenterId;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter VisitTypeId_OP = new OracleParameter();
                VisitTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                VisitTypeId_OP.OracleDbType = OracleDbType.Decimal;
                VisitTypeId_OP.Value = VisitTypeId;

                OracleParameter outIDOP = new OracleParameter();
                outIDOP.Direction = System.Data.ParameterDirection.Output;
                outIDOP.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<INS_UPD_VISIT>.InsertDataBySP("SP_FF_INS_UPD_VISIT_PLAN", outIDOP, VisitPlanId_OP, VisitDate_OP, StaffUserId_OP, EntityType_OP, CenterId_OP, CreatedBy_OP, VisitTypeId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateClosingStatus(decimal ClosingStatusId, decimal CenterId, DateTime StatusDate, string StatusDescription, string ClosingTime, decimal CreatedBy)
        {
            try
            {
                OracleParameter ClosingStatusId_OP = new OracleParameter();
                ClosingStatusId_OP.Direction = System.Data.ParameterDirection.Input;
                ClosingStatusId_OP.OracleDbType = OracleDbType.Decimal;
                ClosingStatusId_OP.Value = ClosingStatusId;

                OracleParameter CenterId_OP = new OracleParameter();
                CenterId_OP.Direction = System.Data.ParameterDirection.Input;
                CenterId_OP.OracleDbType = OracleDbType.Decimal;
                CenterId_OP.Value = CenterId;

                OracleParameter StatusDate_OP = new OracleParameter();
                StatusDate_OP.Direction = System.Data.ParameterDirection.Input;
                StatusDate_OP.OracleDbType = OracleDbType.Date;
                StatusDate_OP.Value = StatusDate;

                OracleParameter StatusDescription_OP = new OracleParameter();
                StatusDescription_OP.Direction = System.Data.ParameterDirection.Input;
                StatusDescription_OP.OracleDbType = OracleDbType.Varchar2;
                StatusDescription_OP.Value = StatusDescription;

                OracleParameter ClosingTime_OP = new OracleParameter();
                ClosingTime_OP.Direction = System.Data.ParameterDirection.Input;
                ClosingTime_OP.OracleDbType = OracleDbType.Varchar2;
                ClosingTime_OP.Value = ClosingTime;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter outIDOP = new OracleParameter();
                outIDOP.Direction = System.Data.ParameterDirection.Output;
                outIDOP.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<INS_UPD_VISIT>.InsertDataBySP("SP_FF_INS_UPD_CLOSING_STATUS", outIDOP, ClosingStatusId_OP, CenterId_OP, StatusDate_OP, StatusDescription_OP, ClosingTime_OP, CreatedBy_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal CenterLocationUpdate(decimal CenterId, decimal LatValue, decimal LongValue)
        {
            try
            {
                OracleParameter CenterId_OP = new OracleParameter();
                CenterId_OP.Direction = System.Data.ParameterDirection.Input;
                CenterId_OP.OracleDbType = OracleDbType.Decimal;
                CenterId_OP.Value = CenterId;

                OracleParameter LatValue_OP = new OracleParameter();
                LatValue_OP.Direction = System.Data.ParameterDirection.Input;
                LatValue_OP.OracleDbType = OracleDbType.Decimal;
                LatValue_OP.Value = LatValue;

                OracleParameter LongValue_OP = new OracleParameter();
                LongValue_OP.Direction = System.Data.ParameterDirection.Input;
                LongValue_OP.OracleDbType = OracleDbType.Decimal;
                LongValue_OP.Value = LongValue;
                
                OracleParameter outIDOP = new OracleParameter();
                outIDOP.Direction = System.Data.ParameterDirection.Output;
                outIDOP.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<INS_UPD_VISIT>.InsertDataBySP("SP_FF_UPD_CENTER_LOCATION", outIDOP, CenterId_OP, LatValue_OP, LongValue_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal RetailerLocationUpdate(decimal RetailerId, decimal LatValue, decimal LongValue, decimal UserId)
        {
            try
            {
                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerId_OP.Value = RetailerId;

                OracleParameter LatValue_OP = new OracleParameter();
                LatValue_OP.Direction = System.Data.ParameterDirection.Input;
                LatValue_OP.OracleDbType = OracleDbType.Decimal;
                LatValue_OP.Value = LatValue;

                OracleParameter LongValue_OP = new OracleParameter();
                LongValue_OP.Direction = System.Data.ParameterDirection.Input;
                LongValue_OP.OracleDbType = OracleDbType.Decimal;
                LongValue_OP.Value = LongValue;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter outIDOP = new OracleParameter();
                outIDOP.Direction = System.Data.ParameterDirection.Output;
                outIDOP.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_UPD_RETAILER_LOCATION", outIDOP, RetailerId_OP, LatValue_OP, LongValue_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_MARKET_UPDATE_PICTURE> GetMarketUpdatePictures(decimal MarketUpdatePictureId, decimal MarketUpdateId, decimal PictureSlNo)
        {
            try
            {
                OracleParameter MarketUpdatePictureId_OP = new OracleParameter();
                MarketUpdatePictureId_OP.Direction = System.Data.ParameterDirection.Input;
                MarketUpdatePictureId_OP.OracleDbType = OracleDbType.Decimal;
                MarketUpdatePictureId_OP.Value = MarketUpdatePictureId;

                OracleParameter MarketUpdateId_OP = new OracleParameter();
                MarketUpdateId_OP.Direction = System.Data.ParameterDirection.Input;
                MarketUpdateId_OP.OracleDbType = OracleDbType.Decimal;
                MarketUpdateId_OP.Value = MarketUpdateId;

                OracleParameter PictureSlNo_OP = new OracleParameter();
                PictureSlNo_OP.Direction = System.Data.ParameterDirection.Input;
                PictureSlNo_OP.OracleDbType = OracleDbType.Decimal;
                PictureSlNo_OP.Value = PictureSlNo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_MARKET_UPDATE_PICTURE>)ObjectMakerFromOracleSP.OracleHelper<GET_MARKET_UPDATE_PICTURE>.GetDataBySP(new GET_MARKET_UPDATE_PICTURE(), "SP_FF_GET_MRKT_UPDATE_PICTURE", 2, resultOutCurSor, MarketUpdatePictureId_OP, MarketUpdateId_OP, PictureSlNo_OP);
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
                OracleParameter ComplainPictureId_OP = new OracleParameter();
                ComplainPictureId_OP.Direction = System.Data.ParameterDirection.Input;
                ComplainPictureId_OP.OracleDbType = OracleDbType.Decimal;
                ComplainPictureId_OP.Value = ComplainPictureId;

                OracleParameter ComplainId_OP = new OracleParameter();
                ComplainId_OP.Direction = System.Data.ParameterDirection.Input;
                ComplainId_OP.OracleDbType = OracleDbType.Decimal;
                ComplainId_OP.Value = ComplainId;

                OracleParameter PictureSlNo_OP = new OracleParameter();
                PictureSlNo_OP.Direction = System.Data.ParameterDirection.Input;
                PictureSlNo_OP.OracleDbType = OracleDbType.Decimal;
                PictureSlNo_OP.Value = PictureSlNo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_COMPLAIN_PICTURE>)ObjectMakerFromOracleSP.OracleHelper<GET_COMPLAIN_PICTURE>.GetDataBySP(new GET_COMPLAIN_PICTURE(), "SP_FF_GET_COMPLAIN_PICTURE", 2, resultOutCurSor, ComplainPictureId_OP, ComplainId_OP, PictureSlNo_OP);
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
                OracleParameter OfferPictureId_OP = new OracleParameter();
                OfferPictureId_OP.Direction = System.Data.ParameterDirection.Input;
                OfferPictureId_OP.OracleDbType = OracleDbType.Decimal;
                OfferPictureId_OP.Value = OfferPictureId;

                OracleParameter OfferId_OP = new OracleParameter();
                OfferId_OP.Direction = System.Data.ParameterDirection.Input;
                OfferId_OP.OracleDbType = OracleDbType.Decimal;
                OfferId_OP.Value = OfferId;

                OracleParameter PictureSlNo_OP = new OracleParameter();
                PictureSlNo_OP.Direction = System.Data.ParameterDirection.Input;
                PictureSlNo_OP.OracleDbType = OracleDbType.Decimal;
                PictureSlNo_OP.Value = PictureSlNo;
             
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_OFFER_PICTURES>)ObjectMakerFromOracleSP.OracleHelper<GET_OFFER_PICTURES>.GetDataBySP(new GET_OFFER_PICTURES(), "SP_FF_GET_CRNT_OFFER_PICTURE", 2, resultOutCurSor, OfferPictureId_OP, OfferId_OP, PictureSlNo_OP);
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
                OracleParameter OfferPictureId_OP = new OracleParameter();
                OfferPictureId_OP.Direction = System.Data.ParameterDirection.Input;
                OfferPictureId_OP.OracleDbType = OracleDbType.Decimal;
                OfferPictureId_OP.Value = OfferPictureId;

                OracleParameter OfferId_OP = new OracleParameter();
                OfferId_OP.Direction = System.Data.ParameterDirection.Input;
                OfferId_OP.OracleDbType = OracleDbType.Decimal;
                OfferId_OP.Value = OfferId;

                OracleParameter PictureSlNo_OP = new OracleParameter();
                PictureSlNo_OP.Direction = System.Data.ParameterDirection.Input;
                PictureSlNo_OP.OracleDbType = OracleDbType.Decimal;
                PictureSlNo_OP.Value = PictureSlNo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_OFFER_PICTURES>)ObjectMakerFromOracleSP.OracleHelper<GET_OFFER_PICTURES>.GetDataBySP(new GET_OFFER_PICTURES(), "SP_FF_GET_RET_CRNT_OFFER_PIC", 2, resultOutCurSor, OfferPictureId_OP, OfferId_OP, PictureSlNo_OP);
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
                OracleParameter CommissionPictureId_OP = new OracleParameter();
                CommissionPictureId_OP.Direction = System.Data.ParameterDirection.Input;
                CommissionPictureId_OP.OracleDbType = OracleDbType.Decimal;
                CommissionPictureId_OP.Value = CommissionPictureId;

                OracleParameter CommissionId_OP = new OracleParameter();
                CommissionId_OP.Direction = System.Data.ParameterDirection.Input;
                CommissionId_OP.OracleDbType = OracleDbType.Decimal;
                CommissionId_OP.Value = CommissionId;

                OracleParameter PictureSlNo_OP = new OracleParameter();
                PictureSlNo_OP.Direction = System.Data.ParameterDirection.Input;
                PictureSlNo_OP.OracleDbType = OracleDbType.Decimal;
                PictureSlNo_OP.Value = PictureSlNo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_COMMISSION_PICTURES>)ObjectMakerFromOracleSP.OracleHelper<GET_COMMISSION_PICTURES>.GetDataBySP(new GET_COMMISSION_PICTURES(), "SP_FF_GET_COM_STRUC_PICTURE", 2, resultOutCurSor, CommissionPictureId_OP, CommissionId_OP, PictureSlNo_OP);
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
                OracleParameter StatusDate_OP = new OracleParameter();
                StatusDate_OP.Direction = System.Data.ParameterDirection.Input;
                StatusDate_OP.OracleDbType = OracleDbType.Date;
                StatusDate_OP.Value = StatusDate;
               
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_SHOP_CLOSING_STATUS>)ObjectMakerFromOracleSP.OracleHelper<GET_SHOP_CLOSING_STATUS>.GetDataBySP(new GET_SHOP_CLOSING_STATUS(), "SP_FF_GET_SHOP_CLOSING_STATUS", 7, resultOutCurSor, StatusDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateQuestionnaire(Decimal QuestionnaireId, Decimal VisitEntityType, Decimal CenterTypeId, Decimal CreatedBy, Decimal VisitTypeId, Decimal IsActive)
        {
            try
            {
                OracleParameter QuestionnaireId_OP = new OracleParameter();
                QuestionnaireId_OP.Direction = System.Data.ParameterDirection.Input;
                QuestionnaireId_OP.OracleDbType = OracleDbType.Decimal;
                QuestionnaireId_OP.Value = QuestionnaireId;

                OracleParameter VisitEntityType_OP = new OracleParameter();
                VisitEntityType_OP.Direction = System.Data.ParameterDirection.Input;
                VisitEntityType_OP.OracleDbType = OracleDbType.Decimal;
                VisitEntityType_OP.Value = VisitEntityType;

                OracleParameter CenterTypeId_OP = new OracleParameter();
                CenterTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                CenterTypeId_OP.OracleDbType = OracleDbType.Decimal;
                CenterTypeId_OP.Value = CenterTypeId;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = System.Data.ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Decimal;
                IsActive_OP.Value = IsActive;

                OracleParameter VisitTypeId_OP = new OracleParameter();
                VisitTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                VisitTypeId_OP.OracleDbType = OracleDbType.Decimal;
                VisitTypeId_OP.Value = VisitTypeId;
                
                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_FEEDBACK_QUESTIONNAIRE>.InsertDataBySP("SP_FF_INS_UPD_QUESTIONNAIRE", resultOutID, QuestionnaireId_OP, VisitEntityType_OP, CenterTypeId_OP, CreatedBy_OP, IsActive_OP, VisitTypeId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateEvent(decimal EventId, string EventName, string Note, decimal IsActive, decimal CreatedBy, decimal IsToAll)
        {
            try
            {
                OracleParameter EventId_OP = new OracleParameter();
                EventId_OP.Direction = System.Data.ParameterDirection.Input;
                EventId_OP.OracleDbType = OracleDbType.Decimal;
                EventId_OP.Value = EventId;

                OracleParameter EventName_OP = new OracleParameter();
                EventName_OP.Direction = System.Data.ParameterDirection.Input;
                EventName_OP.OracleDbType = OracleDbType.Varchar2;
                EventName_OP.Value = EventName;

                OracleParameter Note_OP = new OracleParameter();
                Note_OP.Direction = System.Data.ParameterDirection.Input;
                Note_OP.OracleDbType = OracleDbType.Varchar2;
                Note_OP.Value = Note;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = System.Data.ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Decimal;
                IsActive_OP.Value = IsActive;

                OracleParameter IsToAll_OP = new OracleParameter();
                IsToAll_OP.Direction = System.Data.ParameterDirection.Input;
                IsToAll_OP.OracleDbType = OracleDbType.Decimal;
                IsToAll_OP.Value = IsToAll;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_EVENT_INFO>.InsertDataBySP("SP_FF_INS_UPD_EVENT", resultOutID, EventId_OP, EventName_OP, Note_OP, CreatedBy_OP, IsActive_OP, IsToAll_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateScrollMessage(decimal MessageId, string Message, DateTime DisplayFrom, DateTime DisplayTo, decimal IsActive, decimal CreatedBy)
        {
            try
            {
                OracleParameter MessageId_OP = new OracleParameter();
                MessageId_OP.Direction = System.Data.ParameterDirection.Input;
                MessageId_OP.OracleDbType = OracleDbType.Decimal;
                MessageId_OP.Value = MessageId;

                OracleParameter Message_OP = new OracleParameter();
                Message_OP.Direction = System.Data.ParameterDirection.Input;
                Message_OP.OracleDbType = OracleDbType.Varchar2;
                Message_OP.Value = Message;

                OracleParameter DisplayFrom_OP = new OracleParameter();
                DisplayFrom_OP.Direction = System.Data.ParameterDirection.Input;
                DisplayFrom_OP.OracleDbType = OracleDbType.Date;
                DisplayFrom_OP.Value = DisplayFrom;

                OracleParameter DisplayTo_OP = new OracleParameter();
                DisplayTo_OP.Direction = System.Data.ParameterDirection.Input;
                DisplayTo_OP.OracleDbType = OracleDbType.Date;
                DisplayTo_OP.Value = DisplayTo;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = System.Data.ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Decimal;
                IsActive_OP.Value = IsActive;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_SCROLL_MESSAGE>.InsertDataBySP("SP_FF_INS_UPD_SCROLL_MSG", resultOutID, MessageId_OP, Message_OP, DisplayFrom_OP,DisplayTo_OP, IsActive_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateTradeMaterial(decimal TradeMaterialId, string TradeMaterialCode, string TradeMaterialName, decimal IsActive, decimal CreatedBy)
        {
            try
            {
                OracleParameter TradeMaterialId_OP = new OracleParameter();
                TradeMaterialId_OP.Direction = System.Data.ParameterDirection.Input;
                TradeMaterialId_OP.OracleDbType = OracleDbType.Decimal;
                TradeMaterialId_OP.Value = TradeMaterialId;

                OracleParameter TradeMaterialCode_OP = new OracleParameter();
                TradeMaterialCode_OP.Direction = System.Data.ParameterDirection.Input;
                TradeMaterialCode_OP.OracleDbType = OracleDbType.Varchar2;
                TradeMaterialCode_OP.Value = TradeMaterialCode;

                OracleParameter TradeMaterialName_OP = new OracleParameter();
                TradeMaterialName_OP.Direction = System.Data.ParameterDirection.Input;
                TradeMaterialName_OP.OracleDbType = OracleDbType.Varchar2;
                TradeMaterialName_OP.Value = TradeMaterialName;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = System.Data.ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Decimal;
                IsActive_OP.Value = IsActive;
              
                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_FOC_PRODUCT_INFO>.InsertDataBySP("SP_FF_INS_UPD_FOC_PRODUCT", resultOutID, TradeMaterialId_OP, TradeMaterialCode_OP, TradeMaterialName_OP, CreatedBy_OP, IsActive_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateEventZone(decimal EventId, decimal ZoneId)
        {
            try
            {
                OracleParameter EventId_OP = new OracleParameter();
                EventId_OP.Direction = System.Data.ParameterDirection.Input;
                EventId_OP.OracleDbType = OracleDbType.Decimal;
                EventId_OP.Value = EventId;

                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = ZoneId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_INS_UPD_EVENT_AREA", resultOutID, EventId_OP, ZoneId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateQuestion(Decimal QuestionId, Decimal QuestionnaireId, String QuestionText, Decimal CreatedBy, Decimal IsActive, Decimal DisplayOrder)
        {
            try
            {
                OracleParameter QuestionId_OP = new OracleParameter();
                QuestionId_OP.Direction = System.Data.ParameterDirection.Input;
                QuestionId_OP.OracleDbType = OracleDbType.Decimal;
                QuestionId_OP.Value = QuestionId;

                OracleParameter QuestionnaireId_OP = new OracleParameter();
                QuestionnaireId_OP.Direction = System.Data.ParameterDirection.Input;
                QuestionnaireId_OP.OracleDbType = OracleDbType.Decimal;
                QuestionnaireId_OP.Value = QuestionnaireId;

                OracleParameter QuestionText_OP = new OracleParameter();
                QuestionText_OP.Direction = System.Data.ParameterDirection.Input;
                QuestionText_OP.OracleDbType = OracleDbType.Varchar2;
                QuestionText_OP.Value = QuestionText;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = System.Data.ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Decimal;
                IsActive_OP.Value = IsActive;

                OracleParameter DisplayOrder_OP = new OracleParameter();
                DisplayOrder_OP.Direction = System.Data.ParameterDirection.Input;
                DisplayOrder_OP.OracleDbType = OracleDbType.Decimal;
                DisplayOrder_OP.Value = DisplayOrder;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_FEEDBACK_QUESTIONNAIRE>.InsertDataBySP("SP_FF_INS_UPD_FEBACK_QUESTION", resultOutID, QuestionId_OP,  QuestionnaireId_OP, QuestionText_OP, CreatedBy_OP, IsActive_OP, DisplayOrder_OP);
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
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter FromDate_OP = new OracleParameter();
                FromDate_OP.Direction = System.Data.ParameterDirection.Input;
                FromDate_OP.OracleDbType = OracleDbType.Date;
                FromDate_OP.Value = fromDate;
                 
                OracleParameter ToDate_OP = new OracleParameter();
                ToDate_OP.Direction = System.Data.ParameterDirection.Input;
                ToDate_OP.OracleDbType = OracleDbType.Date;
                ToDate_OP.Value = toDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_VISIT_DETAIL>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_VISIT_DETAIL>.GetDataBySP(new SP_GET_VISIT_DETAIL(), "SP_FF_GET_VISITED_RETAILERS", 11, resultOutCurSor, UserId_OP, FromDate_OP, ToDate_OP);
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
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter CriticalType_OP = new OracleParameter();
                CriticalType_OP.Direction = System.Data.ParameterDirection.Input;
                CriticalType_OP.OracleDbType = OracleDbType.Varchar2;
                CriticalType_OP.Value = CriticalType;

				OracleParameter isPopup_OP = new OracleParameter();
				isPopup_OP.Direction = System.Data.ParameterDirection.Input;
				isPopup_OP.OracleDbType = OracleDbType.Decimal;
				isPopup_OP.Value = isPopup;

				OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_CRITICAL_RETAILER>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_CRITICAL_RETAILER>.GetDataBySP(new SP_GET_CRITICAL_RETAILER(), "FF_GET_CRITICAL_RETAILERS_V2", 13, resultOutCurSor, UserId_OP, CriticalType_OP, isPopup_OP);
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
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_MEMO_DETAIL>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_MEMO_DETAIL>.GetDataBySP(new SP_GET_MEMO_DETAIL(), "SP_FF_GET_MEMO_DETAIL", 9, resultOutCurSor, UserId_OP);
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
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SURVEY_LIST>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SURVEY_LIST>.GetDataBySP(new SP_GET_SURVEY_LIST(), "SP_FF_GET_SURVEY_LIST", 4, resultOutCurSor, UserId_OP);
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
                OracleParameter ProductId_OP = new OracleParameter();
                ProductId_OP.Direction = System.Data.ParameterDirection.Input;
                ProductId_OP.OracleDbType = OracleDbType.Decimal;
                ProductId_OP.Value = ProductId;

				OracleParameter UserID_OP = new OracleParameter();
				UserID_OP.Direction = System.Data.ParameterDirection.Input;
				UserID_OP.OracleDbType = OracleDbType.Decimal;
				UserID_OP.Value = UserID;

				OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_WISE_PRODUCT_QTY>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_WISE_PRODUCT_QTY>.GetDataBySP(new SP_GET_RETAILER_WISE_PRODUCT_QTY(), "SP_GET_RET_WISE_PRODUCT_QTY_V4", 4, resultOutCurSor, ProductId_OP, UserID_OP);
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
				
				OracleParameter RetailerId_OP = new OracleParameter();
				RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
				RetailerId_OP.OracleDbType = OracleDbType.Decimal;
				RetailerId_OP.Value = RetailerId;

				OracleParameter UserId_OP = new OracleParameter();
				UserId_OP.Direction = System.Data.ParameterDirection.Input;
				UserId_OP.OracleDbType = OracleDbType.Decimal;
				UserId_OP.Value = UserId;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_FF_GET_RETAILER_DEMAND>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_RETAILER_DEMAND>.GetDataBySP(new SP_FF_GET_RETAILER_DEMAND(), "SP_FF_GET_RETAILER_DEMAND", 5, resultOutCurSor, RetailerId_OP, UserId_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<SP_GET_NOTIFICATIONS> GetNotification(decimal APPID,  decimal UserId, decimal Id, decimal TYPE, string FROMDATE, string TODATE)
		{
			try
			{
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter APPID_OP = new OracleParameter();
				APPID_OP.Direction = System.Data.ParameterDirection.Input;
				APPID_OP.OracleDbType = OracleDbType.Decimal;
				APPID_OP.Value = APPID;

				OracleParameter UserId_OP = new OracleParameter();
				UserId_OP.Direction = System.Data.ParameterDirection.Input;
				UserId_OP.OracleDbType = OracleDbType.Decimal;
				UserId_OP.Value = UserId;

				OracleParameter Id_OP = new OracleParameter();
				Id_OP.Direction = System.Data.ParameterDirection.Input;
				Id_OP.OracleDbType = OracleDbType.Decimal;
				Id_OP.Value = Id;


				OracleParameter TYPE_OP = new OracleParameter();
				TYPE_OP.Direction = System.Data.ParameterDirection.Input;
				TYPE_OP.OracleDbType = OracleDbType.Decimal;
				TYPE_OP.Value = TYPE;


				OracleParameter FROMDATE_OP = new OracleParameter();
				FROMDATE_OP.Direction = System.Data.ParameterDirection.Input;
				FROMDATE_OP.OracleDbType = OracleDbType.Varchar2;
				FROMDATE_OP.Value = FROMDATE;


				OracleParameter TODATE_OP = new OracleParameter();
				TODATE_OP.Direction = System.Data.ParameterDirection.Input;
				TODATE_OP.OracleDbType = OracleDbType.Varchar2;
				TODATE_OP.Value = TODATE;



				return (List<SP_GET_NOTIFICATIONS>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_NOTIFICATIONS>.GetDataBySP(new SP_GET_NOTIFICATIONS(), "SP_FF_GET_NOTIFICATION", 10, resultOutCurSor, APPID_OP, UserId_OP, Id_OP, TYPE_OP, FROMDATE_OP, TODATE_OP);
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
                OracleParameter EV_Limit_Id_OP = new OracleParameter();
                EV_Limit_Id_OP.Direction = System.Data.ParameterDirection.Input;
                EV_Limit_Id_OP.OracleDbType = OracleDbType.Decimal;
                EV_Limit_Id_OP.Value = EV_Limit_Id;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;
                     var result = (List<SP_GET_ALL_EV_LIMIT>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ALL_EV_LIMIT>.GetDataBySP(new SP_GET_ALL_EV_LIMIT(), "SP_GET_ALL_EV_LIMIT", 5, resultOutCurSor, EV_Limit_Id_OP, UserId_OP);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateEVLimit(decimal EVLimitId, decimal MinAmount, decimal MaxAmount, decimal CreatedBy)
        {
            try
            {
                OracleParameter EVLimitId_OP = new OracleParameter();
                EVLimitId_OP.Direction = System.Data.ParameterDirection.Input;
                EVLimitId_OP.OracleDbType = OracleDbType.Decimal;
                EVLimitId_OP.Value = EVLimitId;

                OracleParameter MinAmount_OP = new OracleParameter();
                MinAmount_OP.Direction = System.Data.ParameterDirection.Input;
                MinAmount_OP.OracleDbType = OracleDbType.Varchar2;
                MinAmount_OP.Value = MinAmount;

                OracleParameter MaxAmount_OP = new OracleParameter();
                MaxAmount_OP.Direction = System.Data.ParameterDirection.Input;
                MaxAmount_OP.OracleDbType = OracleDbType.Varchar2;
                MaxAmount_OP.Value = MaxAmount;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;



                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_ALL_EV_LIMIT>.InsertDataBySP("SP_INS_UPD_EV_LIMIT", resultOutID, EVLimitId_OP, MinAmount_OP, MaxAmount_OP, CreatedBy_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
