using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.Models.ApiMobile;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class RsoDZ
    {
        readonly string connStringMainDB = ConfigurationManager.ConnectionStrings["APL_DB_ConnString"].ConnectionString;
        public RsoDZ()
        { }


        public Decimal SaveUpdateBestRsoPractice(decimal Id, decimal RsoId,
                                        decimal RetailerMarketAreaId, decimal PeriodId, decimal Year, decimal CalculationAreaId,
                                        String Description, decimal CreatedBy)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter RsoId_OP = new OracleParameter();
                RsoId_OP.Direction = System.Data.ParameterDirection.Input;
                RsoId_OP.OracleDbType = OracleDbType.Decimal;
                RsoId_OP.Value = RsoId;

                OracleParameter RetailerMarketAreaId_OP = new OracleParameter();
                RetailerMarketAreaId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerMarketAreaId_OP.OracleDbType = OracleDbType.Decimal;
                RetailerMarketAreaId_OP.Value = RetailerMarketAreaId;

                OracleParameter PeriodId_OP = new OracleParameter();
                PeriodId_OP.Direction = System.Data.ParameterDirection.Input;
                PeriodId_OP.OracleDbType = OracleDbType.Decimal;
                PeriodId_OP.Value = PeriodId;

                OracleParameter Year_OP = new OracleParameter();
                Year_OP.Direction = System.Data.ParameterDirection.Input;
                Year_OP.OracleDbType = OracleDbType.Decimal;
                Year_OP.Value = Year;

                OracleParameter CalculationAreaId_OP = new OracleParameter();
                CalculationAreaId_OP.Direction = System.Data.ParameterDirection.Input;
                CalculationAreaId_OP.OracleDbType = OracleDbType.Decimal;
                CalculationAreaId_OP.Value = CalculationAreaId;

                OracleParameter Description_OP = new OracleParameter();
                Description_OP.Direction = System.Data.ParameterDirection.Input;
                Description_OP.OracleDbType = OracleDbType.NVarchar2;
                Description_OP.Value = Description;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = System.Data.ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_BEST_RSO_PRACTICE>.InsertDataBySP("SP_FF_INS_UP_BEST_PRCT_RSO", resultOutID, Id_OP, RsoId_OP, RetailerMarketAreaId_OP, PeriodId_OP, Year_OP, CalculationAreaId_OP, Description_OP, CreatedBy_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal GetPassCode(string loginName, decimal appId)
        {
            try
            {
                OracleParameter loginName_OP = new OracleParameter();
                loginName_OP.Direction = System.Data.ParameterDirection.Input;
                loginName_OP.OracleDbType = OracleDbType.Varchar2;
                loginName_OP.Value = loginName;

                OracleParameter appId_OP = new OracleParameter();
                appId_OP.Direction = System.Data.ParameterDirection.Input;
                appId_OP.OracleDbType = OracleDbType.Decimal;
                appId_OP.Value = appId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_SEND_PASSCODE", resultOutID, loginName_OP, appId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_BEST_RSO_PRACTICE> GetAllBestRSOPractice(decimal BestPracticesRsoId, decimal StaffUserId)
        {
            try
            {
                OracleParameter BestPracticesRsoId_OP = new OracleParameter();
                BestPracticesRsoId_OP.Direction = System.Data.ParameterDirection.Input;
                BestPracticesRsoId_OP.OracleDbType = OracleDbType.Decimal;
                BestPracticesRsoId_OP.Value = BestPracticesRsoId;

                OracleParameter StaffUserId_OP = new OracleParameter();
                StaffUserId_OP.Direction = System.Data.ParameterDirection.Input;
                StaffUserId_OP.OracleDbType = OracleDbType.Decimal;
                StaffUserId_OP.Value = StaffUserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_BEST_RSO_PRACTICE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_BEST_RSO_PRACTICE>.GetDataBySP(new SP_GET_BEST_RSO_PRACTICE(), "SP_FF_GET_BEST_RSO_PRACT", 13, resultOutCurSor, BestPracticesRsoId_OP, StaffUserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RSO_COMMISSION> GetRSOCommission(SearchParam searchParam, DateTime? DateFrom, DateTime? DateTo)
        {
            try
            {
                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = searchParam.ZoneId;

                OracleParameter DateFrom_OP = new OracleParameter();
                DateFrom_OP.Direction = System.Data.ParameterDirection.Input;
                DateFrom_OP.OracleDbType = OracleDbType.Date;
                DateFrom_OP.Value = DateFrom;

                OracleParameter DateTo_OP = new OracleParameter();
                DateTo_OP.Direction = System.Data.ParameterDirection.Input;
                DateTo_OP.OracleDbType = OracleDbType.Date;
                DateTo_OP.Value = DateTo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RSO_COMMISSION>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_COMMISSION>.GetDataBySP(new SP_GET_RSO_COMMISSION(), "SP_FF_GET_RSO_COMMISSION", 6, resultOutCurSor, ZoneId_OP, DateFrom_OP, DateTo_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_DROPDOWN> GetMarketUpdateTypes(decimal Id)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;


                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_DROPDOWN>)ObjectMakerFromOracleSP.OracleHelper<GET_DROPDOWN>.GetDataBySP(new GET_DROPDOWN(), "SP_FF_GET_MARKET_UPDATE_TYPE", 3, resultOutCurSor, Id_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_DROPDOWN> GetDistricts(decimal Id, decimal UserId)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_DROPDOWN>)ObjectMakerFromOracleSP.OracleHelper<GET_DROPDOWN>.GetDataBySP(new GET_DROPDOWN(), "SP_FF_GET_DISTRICT", 3, resultOutCurSor, Id_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_DROPDOWN> GetThanas(decimal Id, decimal UserId)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;


                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_DROPDOWN>)ObjectMakerFromOracleSP.OracleHelper<GET_DROPDOWN>.GetDataBySP(new GET_DROPDOWN(), "SP_FF_GET_THANA", 3, resultOutCurSor, Id_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_EVENT_INFO> GetEventInfo(decimal Id, decimal UserId)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_EVENT_INFO>)ObjectMakerFromOracleSP.OracleHelper<GET_EVENT_INFO>.GetDataBySP(new GET_EVENT_INFO(), "SP_FF_GET_EVENT_INFO", 3, resultOutCurSor, Id_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_USER_WORK_AREA> GetUserWorkArea(decimal UserId)
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

                return (List<GET_USER_WORK_AREA>)ObjectMakerFromOracleSP.OracleHelper<GET_USER_WORK_AREA>.GetDataBySP(new GET_USER_WORK_AREA(), "SP_FF_GET_USER_WORK_AREA", 3, resultOutCurSor, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RPT_RSO_TARGET_ACHIVE> GetRsoTargetVsAchivement(GetRsoTargetAchivement rsoTargetAchive, decimal UserId, decimal MonthCount, decimal IsUserWise)
        {
            try
            {
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter MonthCount_OP = new OracleParameter();
                MonthCount_OP.Direction = System.Data.ParameterDirection.Input;
                MonthCount_OP.OracleDbType = OracleDbType.Decimal;
                MonthCount_OP.Value = MonthCount;

                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = rsoTargetAchive.ZoneId;

                OracleParameter ItemId_OP = new OracleParameter();
                ItemId_OP.Direction = System.Data.ParameterDirection.Input;
                ItemId_OP.OracleDbType = OracleDbType.Decimal;
                ItemId_OP.Value = rsoTargetAchive.ItemId;

                OracleParameter IsUserWise_OP = new OracleParameter();
                IsUserWise_OP.Direction = System.Data.ParameterDirection.Input;
                IsUserWise_OP.OracleDbType = OracleDbType.Decimal;
                IsUserWise_OP.Value = IsUserWise;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RPT_RSO_TARGET_ACHIVE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RPT_RSO_TARGET_ACHIVE>.GetDataBySP(new SP_GET_RPT_RSO_TARGET_ACHIVE(), "SP_FF_GET_RSO_TARGET_ACHIVE", 13, resultOutCurSor, UserId_OP, MonthCount_OP, ZoneId_OP, ItemId_OP, IsUserWise_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RSO_SALES_CALL_DAILY_ATTENDANCE> GetSalesCallAndDailyAttendance(SearchParam searchParam, DateTime? DateFrom, DateTime? DateTo)
        {
            try
            {
                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = searchParam.ZoneId;

                OracleParameter DateFrom_OP = new OracleParameter();
                DateFrom_OP.Direction = System.Data.ParameterDirection.Input;
                DateFrom_OP.OracleDbType = OracleDbType.Date;
                DateFrom_OP.Value = DateFrom;

                OracleParameter DateTo_OP = new OracleParameter();
                DateTo_OP.Direction = System.Data.ParameterDirection.Input;
                DateTo_OP.OracleDbType = OracleDbType.Date;
                DateTo_OP.Value = DateTo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RSO_SALES_CALL_DAILY_ATTENDANCE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_SALES_CALL_DAILY_ATTENDANCE>.GetDataBySP(new SP_GET_RSO_SALES_CALL_DAILY_ATTENDANCE(), "SP_FF_GET_SALS_CAL_DAILY_ATEN", 22, resultOutCurSor, ZoneId_OP, DateFrom_OP, DateTo_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RSO_DETAIL> GetRsoDetails(GetRsoDetails rsoDetail)
        {
            try
            {
                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = rsoDetail.ZoneId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RSO_DETAIL>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_DETAIL>.GetDataBySP(new SP_GET_RSO_DETAIL(), "SP_FF_GET_RSO_DETAIL", 22, resultOutCurSor, ZoneId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RSO_ATTENDANCE_AND_PATH> GetRsoAttendanceAndPath(SearchParam searchParam, DateTime? DateFrom, DateTime? DateTo)
        {
            try
            {
                OracleParameter ZoneId_OP = new OracleParameter();
                ZoneId_OP.Direction = System.Data.ParameterDirection.Input;
                ZoneId_OP.OracleDbType = OracleDbType.Decimal;
                ZoneId_OP.Value = searchParam.ZoneId;

                OracleParameter DateFrom_OP = new OracleParameter();
                DateFrom_OP.Direction = System.Data.ParameterDirection.Input;
                DateFrom_OP.OracleDbType = OracleDbType.Date;
                DateFrom_OP.Value = DateFrom;

                OracleParameter DateTo_OP = new OracleParameter();
                DateTo_OP.Direction = System.Data.ParameterDirection.Input;
                DateTo_OP.OracleDbType = OracleDbType.Date;
                DateTo_OP.Value = DateTo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				//return (List<SP_GET_RSO_ATTENDANCE_AND_PATH>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_ATTENDANCE_AND_PATH>.GetDataBySP(new SP_GET_RSO_ATTENDANCE_AND_PATH(), "SP_FF_GET_RSO_ATTENDANCE_PATH", 19, resultOutCurSor, ZoneId_OP, DateFrom_OP, DateTo_OP);
				return (List<SP_GET_RSO_ATTENDANCE_AND_PATH>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_ATTENDANCE_AND_PATH>.GetDataBySP(new SP_GET_RSO_ATTENDANCE_AND_PATH(), "FF_GET_RSO_ATTENDANCE_PATHV2", 19, resultOutCurSor, ZoneId_OP, DateFrom_OP, DateTo_OP);
			}
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RSO_TARGET_ACHIVEMENT> GetRsoTargetAchive(decimal UserId, decimal MonthCount, decimal AreaId, decimal ItemId, decimal IsUserWise)
        {
            try
            {
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter MonthCount_OP = new OracleParameter();
                MonthCount_OP.Direction = System.Data.ParameterDirection.Input;
                MonthCount_OP.OracleDbType = OracleDbType.Decimal;
                MonthCount_OP.Value = MonthCount;

                OracleParameter AreaId_OP = new OracleParameter();
                AreaId_OP.Direction = System.Data.ParameterDirection.Input;
                AreaId_OP.OracleDbType = OracleDbType.Decimal;
                AreaId_OP.Value = AreaId;

                OracleParameter ItemId_OP = new OracleParameter();
                ItemId_OP.Direction = System.Data.ParameterDirection.Input;
                ItemId_OP.OracleDbType = OracleDbType.Decimal;
                ItemId_OP.Value = ItemId;

                OracleParameter IsUserWise_OP = new OracleParameter();
                IsUserWise_OP.Direction = System.Data.ParameterDirection.Input;
                IsUserWise_OP.OracleDbType = OracleDbType.Decimal;
                IsUserWise_OP.Value = IsUserWise;
            
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RSO_TARGET_ACHIVEMENT>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_TARGET_ACHIVEMENT>.GetDataBySP(new SP_GET_RSO_TARGET_ACHIVEMENT(), "SP_FF_GET_RSO_TARGET_ACHIVE", 8, resultOutCurSor, UserId_OP, MonthCount_OP, AreaId_OP, ItemId_OP, IsUserWise_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_FF_RETAILER_ACHIEVEMENT> GetRetailerAchievement(decimal ItemType, decimal UserId)
        {
            try
            {
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter ItemType_OP = new OracleParameter();
                ItemType_OP.Direction = System.Data.ParameterDirection.Input;
                ItemType_OP.OracleDbType = OracleDbType.Decimal;
                ItemType_OP.Value = ItemType;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_FF_RETAILER_ACHIEVEMENT>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_RETAILER_ACHIEVEMENT>.GetDataBySP(new SP_FF_RETAILER_ACHIEVEMENT(), "SP_FF_RETAILER_ACHIEVEMENT", 4, resultOutCurSor, ItemType_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_ROUTE> GetRsoRoutes(decimal UserId, string DayName)
        {
            try
            {
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter DayName_OP = new OracleParameter();
                DayName_OP.Direction = System.Data.ParameterDirection.Input;
                DayName_OP.OracleDbType = OracleDbType.Varchar2;
                DayName_OP.Value = DayName;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_ROUTE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ROUTE>.GetDataBySP(new SP_GET_ROUTE(), "SP_FF_GET_RSO_ROUTES", 3, resultOutCurSor, UserId_OP, DayName_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_FF_GET_MENU_GROUP> GetMenuGroups(decimal UserType, decimal position)
        {
            try
            {
                OracleParameter UserType_OP = new OracleParameter();
                UserType_OP.Direction = System.Data.ParameterDirection.Input;
                UserType_OP.OracleDbType = OracleDbType.Decimal;
                UserType_OP.Value = UserType;

				OracleParameter position_OP = new OracleParameter();
				position_OP.Direction = System.Data.ParameterDirection.Input;
				position_OP.OracleDbType = OracleDbType.Decimal;
				position_OP.Value = position;

				OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_FF_GET_MENU_GROUP>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_MENU_GROUP>.GetDataBySP(new SP_FF_GET_MENU_GROUP(), "SP_FF_GET_MENU_GROUP", 2, resultOutCurSor, UserType_OP, position_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_FF_TRAINING_SECTION_LIST> GetTrainingSectionList(decimal UserId)
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

                return (List<SP_FF_TRAINING_SECTION_LIST>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_TRAINING_SECTION_LIST>.GetDataBySP(new SP_FF_TRAINING_SECTION_LIST(), "SP_FF_TRAINING_SECTION_LIST", 7, resultOutCurSor, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_FF_GET_TRAINING_SECTION> GetTrainingSection(decimal UserId, decimal TrainingId)
        {
            try
            {
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter TrainingId_OP = new OracleParameter();
                TrainingId_OP.Direction = System.Data.ParameterDirection.Input;
                TrainingId_OP.OracleDbType = OracleDbType.Decimal;
                TrainingId_OP.Value = TrainingId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_FF_GET_TRAINING_SECTION>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_TRAINING_SECTION>.GetDataBySP(new SP_FF_GET_TRAINING_SECTION(), "SP_FF_GET_TRAINING_SECTION", 7, resultOutCurSor, UserId_OP, TrainingId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SaveResult SaveBioDeviceReturnInfo(decimal UserId, DateTime ReturnDate, string DeviceId, string Remarks, decimal RetailerId)
        {
            try
            {
                SaveResult biometricDeviceInsertStatus = new SaveResult();
                OracleConnection cn = new OracleConnection(connStringMainDB);
                string spName = "SP_FF_RSO_BIO_DEVICE_RETURN";
                OracleCommand cmd = new OracleCommand(spName);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;
                cmd.Parameters.Add(resultOutID);

                OracleParameter resultValidationOutID = new OracleParameter();
                resultValidationOutID.Direction = System.Data.ParameterDirection.Output;
                resultValidationOutID.OracleDbType = OracleDbType.Varchar2;
                resultValidationOutID.Size = 500;
                cmd.Parameters.Add(resultValidationOutID);

                OracleParameter ReturnDate_OP = new OracleParameter();
                ReturnDate_OP.Direction = System.Data.ParameterDirection.Input;
                ReturnDate_OP.OracleDbType = OracleDbType.Date;
                ReturnDate_OP.Value = ReturnDate;
                cmd.Parameters.Add(ReturnDate_OP);

                OracleParameter DeviceId_OP = new OracleParameter();
                DeviceId_OP.Direction = System.Data.ParameterDirection.Input;
                DeviceId_OP.OracleDbType = OracleDbType.Varchar2;
                DeviceId_OP.Value = DeviceId;
                cmd.Parameters.Add(DeviceId_OP);

                OracleParameter Remarks_OP = new OracleParameter();
                Remarks_OP.Direction = System.Data.ParameterDirection.Input;
                Remarks_OP.OracleDbType = OracleDbType.Varchar2;
                Remarks_OP.Value = Remarks;
                cmd.Parameters.Add(Remarks_OP);

                OracleParameter RetailerId_OP = new OracleParameter();
                RetailerId_OP.Direction = System.Data.ParameterDirection.Input;
                RetailerId_OP.OracleDbType = OracleDbType.Varchar2;
                RetailerId_OP.Value = RetailerId;
                cmd.Parameters.Add(RetailerId_OP);

                

                OracleParameter userId_OP = new OracleParameter();
                userId_OP.Direction = System.Data.ParameterDirection.Input;
                userId_OP.OracleDbType = OracleDbType.Decimal;
                userId_OP.Value = UserId;
                cmd.Parameters.Add(userId_OP);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                biometricDeviceInsertStatus.Result = Convert.ToDecimal(resultOutID.Value.ToString());
                biometricDeviceInsertStatus.Message = resultValidationOutID.Value.ToString();
                biometricDeviceInsertStatus.status_code = 200;

                cmd.Connection.Close();

                return biometricDeviceInsertStatus;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_FF_GET_MENU_GROUP_ITEM_LIST> GetGroupItems(decimal UserType, decimal GroupId, decimal position, decimal LanguageId)
        {
            try
            {
                OracleParameter UserType_OP = new OracleParameter();
				UserType_OP.Direction = System.Data.ParameterDirection.Input;
				UserType_OP.OracleDbType = OracleDbType.Decimal;
				UserType_OP.Value = UserType;

				OracleParameter GroupId_OP = new OracleParameter();
				GroupId_OP.Direction = System.Data.ParameterDirection.Input;
				GroupId_OP.OracleDbType = OracleDbType.Decimal;
				GroupId_OP.Value = GroupId;

				OracleParameter position_OP = new OracleParameter();
				position_OP.Direction = System.Data.ParameterDirection.Input;
				position_OP.OracleDbType = OracleDbType.Decimal;
				position_OP.Value = position;

				OracleParameter LanguageId_OP = new OracleParameter();
				LanguageId_OP.Direction = System.Data.ParameterDirection.Input;
				LanguageId_OP.OracleDbType = OracleDbType.Decimal;
				LanguageId_OP.Value = LanguageId;

				OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_FF_GET_MENU_GROUP_ITEM_LIST>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_MENU_GROUP_ITEM_LIST>.GetDataBySP(new SP_FF_GET_MENU_GROUP_ITEM_LIST(), "SP_FF_GET_MENU_GROUP_ITEM_LIST", 4, resultOutCurSor, UserType_OP, GroupId_OP, position_OP, LanguageId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_ROUTE> GetRetailerByRoute(decimal RouteId)
        {
            try
            {
                OracleParameter RouteId_OP = new OracleParameter();
                RouteId_OP.Direction = System.Data.ParameterDirection.Input;
                RouteId_OP.OracleDbType = OracleDbType.Decimal;
                RouteId_OP.Value = RouteId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_ROUTE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_ROUTE>.GetDataBySP(new SP_GET_RETAILER_ROUTE(), "SP_FF_GET_RETAILER_ROUTE", 13, resultOutCurSor, RouteId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RSO_GPS> GetRsoGPS(decimal TerritoryId, decimal RsoId, DateTime VisitDate)
        {
            try
            {
                OracleParameter TerritoryId_OP = new OracleParameter();
                TerritoryId_OP.Direction = System.Data.ParameterDirection.Input;
                TerritoryId_OP.OracleDbType = OracleDbType.Decimal;
                TerritoryId_OP.Value = TerritoryId;

                OracleParameter RsoId_OP = new OracleParameter();
                RsoId_OP.Direction = System.Data.ParameterDirection.Input;
                RsoId_OP.OracleDbType = OracleDbType.Decimal;
                RsoId_OP.Value = RsoId;

                OracleParameter VisitDate_OP = new OracleParameter();
                VisitDate_OP.Direction = System.Data.ParameterDirection.Input;
                VisitDate_OP.OracleDbType = OracleDbType.Date;
                VisitDate_OP.Value = VisitDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RSO_GPS>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_GPS>.GetDataBySP(new SP_GET_RSO_GPS(), "SP_FF_GET_RSO_GPS", 15, resultOutCurSor, TerritoryId_OP, RsoId_OP, VisitDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all RSO by search option.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="rsoID"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_RSOcls> GetAllRso(Decimal distributorID, Decimal rsoID)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RSOcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSOcls>.GetDataBySP(new SP_GET_RSOcls(), "SP_FF_GET_RSO", 5, resultOutCurSor, distributorID_OP, rsoID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RSOcls> GetRsoFromZone(Decimal distributorID, Decimal rsoID, Decimal zoneID)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter zoneID_OP = new OracleParameter();
                zoneID_OP.Direction = System.Data.ParameterDirection.Input;
                zoneID_OP.OracleDbType = OracleDbType.Decimal;
                zoneID_OP.Value = zoneID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RSOcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSOcls>.GetDataBySP(new SP_GET_RSOcls(), "SP_FF_GET_RSO_FROM_ZONE", 5, resultOutCurSor, distributorID_OP, rsoID_OP, zoneID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get all Apps Inbox data for RSO by search option.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="rsoID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns>List of related object</returns>
        public List<SP_INS_UPD_RSO_APPS_INBOXcls> GetRsoAppsInbox(decimal distributorID, decimal rsoID, DateTime fromDate, DateTime toDate)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter fromDateOP = new OracleParameter();
                fromDateOP.Direction = ParameterDirection.Input;
                fromDateOP.OracleDbType = OracleDbType.Varchar2;
                fromDateOP.Value = fromDate.ToString("dd-MMM-yyyy");

                OracleParameter toDateOP = new OracleParameter();
                toDateOP.Direction = ParameterDirection.Input;
                toDateOP.OracleDbType = OracleDbType.Varchar2;
                toDateOP.Value = toDate.ToString("dd-MMM-yyyy");

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_INS_UPD_RSO_APPS_INBOXcls>)ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_RSO_APPS_INBOXcls>.GetDataBySP(new SP_INS_UPD_RSO_APPS_INBOXcls(), "SP_GET_RSO_APPS_INBOX", 16, resultOutCurSor, distributorID_OP, rsoID_OP, fromDateOP, toDateOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Get all Apps Inbox data using paging option for RSO by search option.
        /// </summary>
        /// <param name="inbox_Id"></param>
        /// <param name="rsoID"></param>
        /// <param name="distributorID"></param>
        /// <param name="noticeTypeID"></param>
        /// <param name="noticeInfo"></param>
        /// <param name="fromDATE"></param>
        /// <param name="toDATE"></param>
        /// <param name="currentPage"></param>
        /// <returns></returns>
        public List<SP_INS_UPD_RSO_APPS_INBOXcls> GetRsoAppsInboxPaging(decimal inbox_Id, decimal rsoID, decimal distributorID, decimal noticeTypeID, string noticeInfo,
           string fromDATE, string toDATE, decimal currentPage)
        {
            try
            {

                OracleParameter inbox_Id_OP = new OracleParameter();
                inbox_Id_OP.Direction = ParameterDirection.Input;
                inbox_Id_OP.OracleDbType = OracleDbType.Decimal;
                inbox_Id_OP.Value = inbox_Id;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter noticeTypeID_OP = new OracleParameter();
                noticeTypeID_OP.Direction = ParameterDirection.Input;
                noticeTypeID_OP.OracleDbType = OracleDbType.Decimal;
                noticeTypeID_OP.Value = noticeTypeID;

                OracleParameter noticeInfo_OP = new OracleParameter();
                noticeInfo_OP.Direction = ParameterDirection.Input;
                noticeInfo_OP.OracleDbType = OracleDbType.Varchar2;
                noticeInfo_OP.Value = noticeInfo;

                OracleParameter fromDATE_OP = new OracleParameter();
                fromDATE_OP.Direction = ParameterDirection.Input;
                fromDATE_OP.OracleDbType = OracleDbType.Varchar2;
                fromDATE_OP.Value = fromDATE;

                OracleParameter toDATE_OP = new OracleParameter();
                toDATE_OP.Direction = ParameterDirection.Input;
                toDATE_OP.OracleDbType = OracleDbType.Varchar2;
                toDATE_OP.Value = toDATE;

                OracleParameter currentPage_OP = new OracleParameter();
                currentPage_OP.Direction = ParameterDirection.Input;
                currentPage_OP.OracleDbType = OracleDbType.Decimal;
                currentPage_OP.Value = currentPage;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_INS_UPD_RSO_APPS_INBOXcls>)ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_RSO_APPS_INBOXcls>.GetDataBySP(new SP_INS_UPD_RSO_APPS_INBOXcls(), "SP_GET_RSO_APPS_INBOX_PAGING",
                                    16, resultOutCurSor, inbox_Id_OP, rsoID_OP, distributorID_OP, noticeTypeID_OP, noticeInfo_OP, fromDATE_OP, toDATE_OP, currentPage_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all RSO target, achivement and commission information from RSO_RETAILER_TARGET table. This table data fill by DMS anthor process.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="rsoID"></param>
        /// <param name="monthDate"></param>
        /// <param name="prodCategoryID"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_RSO_TAR_ACHIcls> GetRsoTargetAndCommission(Decimal distributorID, Decimal rsoID, string monthDate, Decimal prodCategoryID)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter monthDateOP = new OracleParameter();
                monthDateOP.Direction = System.Data.ParameterDirection.Input;
                monthDateOP.OracleDbType = OracleDbType.Varchar2;
                monthDateOP.Value = monthDate;


                OracleParameter prodCategoryID_OP = new OracleParameter();
                prodCategoryID_OP.Direction = System.Data.ParameterDirection.Input;
                prodCategoryID_OP.OracleDbType = OracleDbType.Decimal;
                prodCategoryID_OP.Value = prodCategoryID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RSO_TAR_ACHIcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_TAR_ACHIcls>.GetDataBySP(new SP_GET_RSO_TAR_ACHIcls(), "SP_GET_RSO_TAR_ACHI", 5, resultOutCurSor, distributorID_OP, rsoID_OP, monthDateOP, prodCategoryID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save or update RSO Apps Inbox information.
        /// </summary>
        /// <param name="totalVisitor"></param>
        /// <param name="isPending"></param>
        /// <param name="distributorID"></param>
        /// <param name="adminVisitDate"></param>
        /// <param name="noticeNote"></param>
        /// <param name="inDate"></param>
        /// <param name="rsoInboxID"></param>
        /// <param name="noticeType"></param>
        /// <param name="rsoID"></param>
        /// <param name="adminID"></param>
        /// <returns>RSO Apps Inbox ID value</returns>       
        public decimal SaveRsoAppsInbox(decimal totalVisitor, decimal isPending, decimal distributorID, DateTime adminVisitDate, String noticeNote, DateTime inDate, decimal rsoInboxID, decimal noticeType, decimal rsoID, decimal adminID)
        {
            try
            {
                OracleParameter totalVisitorOP = new OracleParameter();
                totalVisitorOP.Direction = ParameterDirection.Input;
                totalVisitorOP.OracleDbType = OracleDbType.Decimal;
                totalVisitorOP.Value = totalVisitor;

                OracleParameter isPendingOP = new OracleParameter();
                isPendingOP.Direction = ParameterDirection.Input;
                isPendingOP.OracleDbType = OracleDbType.Decimal;
                isPendingOP.Value = isPending;

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter adminVisitDateOP = new OracleParameter();
                adminVisitDateOP.Direction = ParameterDirection.Input;
                adminVisitDateOP.OracleDbType = OracleDbType.Date;
                adminVisitDateOP.Value = adminVisitDate;

                OracleParameter noticeNoteOP = new OracleParameter();
                noticeNoteOP.Direction = ParameterDirection.Input;
                noticeNoteOP.OracleDbType = OracleDbType.Varchar2;
                noticeNoteOP.Value = noticeNote;

                OracleParameter inDateOP = new OracleParameter();
                inDateOP.Direction = ParameterDirection.Input;
                inDateOP.OracleDbType = OracleDbType.Date;
                inDateOP.Value = inDate;

                OracleParameter rsoInboxID_OP = new OracleParameter();
                rsoInboxID_OP.Direction = ParameterDirection.Input;
                rsoInboxID_OP.OracleDbType = OracleDbType.Decimal;
                rsoInboxID_OP.Value = rsoInboxID;

                OracleParameter noticeTypeOP = new OracleParameter();
                noticeTypeOP.Direction = ParameterDirection.Input;
                noticeTypeOP.OracleDbType = OracleDbType.Varchar2;
                noticeTypeOP.Value = noticeType;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter adminID_OP = new OracleParameter();
                adminID_OP.Direction = ParameterDirection.Input;
                adminID_OP.OracleDbType = OracleDbType.Decimal;
                adminID_OP.Value = adminID;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_RSO_APPS_INBOXcls>.InsertDataBySP("SP_INS_UPD_RSO_APPS_INBOX", resultOutID, totalVisitorOP, isPendingOP, distributorID_OP, adminVisitDateOP, noticeNoteOP, inDateOP, rsoInboxID_OP, noticeTypeOP, rsoID_OP, adminID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update RSO Apps Inbox paticular field.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="noticeNote"></param>
        /// <param name="rsoInboxID"></param>
        /// <param name="noticeType"></param>
        /// <param name="rsoID"></param>
        /// <returns>Update row ID</returns>
        public decimal UpdateRSOInbox(decimal distributorID, String noticeNote, decimal rsoInboxID, decimal noticeType, decimal rsoID)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter noticeNoteOP = new OracleParameter();
                noticeNoteOP.Direction = ParameterDirection.Input;
                noticeNoteOP.OracleDbType = OracleDbType.Varchar2;
                noticeNoteOP.Value = noticeNote;

                OracleParameter ID_OP = new OracleParameter();
                ID_OP.Direction = ParameterDirection.Input;
                ID_OP.OracleDbType = OracleDbType.Decimal;
                ID_OP.Value = rsoInboxID;

                OracleParameter noticeTypeOP = new OracleParameter();
                noticeTypeOP.Direction = ParameterDirection.Input;
                noticeTypeOP.OracleDbType = OracleDbType.Varchar2;
                noticeTypeOP.Value = noticeType;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_RSO_APPS_INBOXcls>.InsertDataBySP("SP_UPD_RSO_APPS_INBOX", resultOutID, distributorID_OP,
                            rsoID_OP, noticeNoteOP, ID_OP, noticeTypeOP);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


		public List<SP_GET_RSO_COMMISSION_SUMMSRY> GetCommissionSummary(Decimal distributorID, Decimal rsoID, Decimal monthDate)
		{
			try
			{
				OracleParameter distributorID_OP = new OracleParameter();
				distributorID_OP.Direction = System.Data.ParameterDirection.Input;
				distributorID_OP.OracleDbType = OracleDbType.Decimal;
				distributorID_OP.Value = distributorID;

				OracleParameter rsoID_OP = new OracleParameter();
				rsoID_OP.Direction = System.Data.ParameterDirection.Input;
				rsoID_OP.OracleDbType = OracleDbType.Decimal;
				rsoID_OP.Value = rsoID;

				OracleParameter monthDateOP = new OracleParameter();
				monthDateOP.Direction = System.Data.ParameterDirection.Input;
				monthDateOP.OracleDbType = OracleDbType.Decimal;
				monthDateOP.Value = monthDate;
				
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_RSO_COMMISSION_SUMMSRY>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_COMMISSION_SUMMSRY>.GetDataBySP(new SP_GET_RSO_COMMISSION_SUMMSRY(), "SP_GET_RSO_COMMISSION_SUMMSRY", 6, resultOutCurSor, monthDateOP, rsoID_OP, distributorID_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}




		public List<SP_GET_RSO_COMMISSION_DETAILS> GetCommissionDetails(Decimal masterID)
		{
			try
			{
				OracleParameter masterID_OP = new OracleParameter();
				masterID_OP.Direction = System.Data.ParameterDirection.Input;
				masterID_OP.OracleDbType = OracleDbType.Decimal;
				masterID_OP.Value = masterID;
							

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_RSO_COMMISSION_DETAILS>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_COMMISSION_DETAILS>.GetDataBySP(new SP_GET_RSO_COMMISSION_DETAILS(), "SP_GET_RSO_COMMISSION_DETAILS", 9, resultOutCurSor, masterID_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<SP_GET_FF_RSO_EARNING> GetRsoEarning(Decimal distributorID, Decimal rsoID, Decimal monthDate)
		{
			try
			{
				OracleParameter distributorID_OP = new OracleParameter();
				distributorID_OP.Direction = System.Data.ParameterDirection.Input;
				distributorID_OP.OracleDbType = OracleDbType.Decimal;
				distributorID_OP.Value = distributorID;

				OracleParameter rsoID_OP = new OracleParameter();
				rsoID_OP.Direction = System.Data.ParameterDirection.Input;
				rsoID_OP.OracleDbType = OracleDbType.Decimal;
				rsoID_OP.Value = rsoID;

				OracleParameter monthDateOP = new OracleParameter();
				monthDateOP.Direction = System.Data.ParameterDirection.Input;
				monthDateOP.OracleDbType = OracleDbType.Decimal;
				monthDateOP.Value = monthDate;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_FF_RSO_EARNING>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_FF_RSO_EARNING>.GetDataBySP(new SP_GET_FF_RSO_EARNING(), "SP_GET_FF_RSO_EARNING", 14, resultOutCurSor, monthDateOP, rsoID_OP, distributorID_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public List<SP_GET_SPECIAL_REPORT> GetSpecialReport(SearchParam searchParam)
        {
            try
            {
                OracleParameter ZoneIdOP = new OracleParameter();
                ZoneIdOP.Direction = System.Data.ParameterDirection.Input;
                ZoneIdOP.OracleDbType = OracleDbType.Decimal;
                ZoneIdOP.Value = searchParam.ZoneId;

                OracleParameter FromDate_OP = new OracleParameter();
                FromDate_OP.Direction = System.Data.ParameterDirection.Input;
                FromDate_OP.OracleDbType = OracleDbType.Date;
                FromDate_OP.Value = searchParam.FromDate;

                OracleParameter ToDate_OP = new OracleParameter();
                ToDate_OP.Direction = System.Data.ParameterDirection.Input;
                ToDate_OP.OracleDbType = OracleDbType.Date;
                ToDate_OP.Value = searchParam.ToDate;


                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_SPECIAL_REPORT>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_SPECIAL_REPORT>.GetDataBySP(new SP_GET_SPECIAL_REPORT(), "SP_GET_SPECIAL_REPORT", 9, resultOutCurSor, ZoneIdOP, FromDate_OP, ToDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
