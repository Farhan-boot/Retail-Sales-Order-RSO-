using APL.BL.SFTS.DataBridgeZone.SP_Class;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.Notice
{
    public class NoticeSetupDZ
    {
        public NoticeSetupDZ() { }

        public List<SP_FF_GET_NOTIFICATION_TYPE> GetNotificationTypes(Decimal nottificationTypeId)
        {
            try
            {
                OracleParameter CenterTypeId_OP = new OracleParameter();
                CenterTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                CenterTypeId_OP.OracleDbType = OracleDbType.Decimal;
                CenterTypeId_OP.Value = nottificationTypeId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_FF_GET_NOTIFICATION_TYPE>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_NOTIFICATION_TYPE>.GetDataBySP(new SP_FF_GET_NOTIFICATION_TYPE(), "SP_FF_GET_NOTIFICATION_TYPE", 2, resultOutCurSor, CenterTypeId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		public List<SP_GET_RSOcls> GetAllRso(string rsoCode)
		{
			try
			{
				OracleParameter rsoCode_OP = new OracleParameter();
                rsoCode_OP.Direction = System.Data.ParameterDirection.Input;
                rsoCode_OP.OracleDbType = OracleDbType.Varchar2;
                rsoCode_OP.Value = rsoCode;


				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_RSOcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSOcls>.GetDataBySP(new SP_GET_RSOcls(), "SP_FF_GET_RSO_NOTICE", 5, resultOutCurSor, rsoCode_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<SP_GET_RETAILERcls> GetAllRetailer(string  retailerCode)
		{
			try
			{
				OracleParameter retailerCode_OP = new OracleParameter();
                retailerCode_OP.Direction = System.Data.ParameterDirection.Input;
                retailerCode_OP.OracleDbType = OracleDbType.Varchar2;
                retailerCode_OP.Value = retailerCode;


				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_RETAILERcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILERcls>.GetDataBySP(new SP_GET_RETAILERcls(), "SP_FF_GET_RTL_NOTICE", 11, resultOutCurSor, retailerCode_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<GET_REGION> GetRegion()
        {
            try
            {
                OracleParameter RegionCode_OP = new OracleParameter();
                RegionCode_OP.Direction = System.Data.ParameterDirection.Input;
                RegionCode_OP.OracleDbType = OracleDbType.Varchar2;
                RegionCode_OP.Value = "";
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_REGION>)ObjectMakerFromOracleSP.OracleHelper<GET_REGION>.GetDataBySP(new GET_REGION(), "GET_ZONE_AS_REGION", 2, RegionCode_OP, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_DISTRIBUTOR_BY_REG_IDcls> GetAllRegionDistributorTerri(decimal regionID, decimal distributorID, decimal territoryID)
        {
            try
            {
                OracleParameter regionID_OP = new OracleParameter();
                regionID_OP.Direction = System.Data.ParameterDirection.Input;
                regionID_OP.OracleDbType = OracleDbType.Decimal;
                regionID_OP.Value = regionID;

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter territoryID_OP = new OracleParameter();
                territoryID_OP.Direction = System.Data.ParameterDirection.Input;
                territoryID_OP.OracleDbType = OracleDbType.Decimal;
                territoryID_OP.Value = territoryID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_DISTRIBUTOR_BY_REG_IDcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_DISTRIBUTOR_BY_REG_IDcls>.GetDataBySP(new SP_GET_DISTRIBUTOR_BY_REG_IDcls(), "SP_FF_GET_DIST_BY_REG_ID", 12, resultOutCurSor, regionID_OP, distributorID_OP, territoryID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_FF_GET__NOTICE_LIST> GetNoticeList(decimal NoticeId, decimal UserId)
        {
            try
            {
                OracleParameter NoticeId_OP = new OracleParameter();
                NoticeId_OP.Direction = System.Data.ParameterDirection.Input;
                NoticeId_OP.OracleDbType = OracleDbType.Decimal;
                NoticeId_OP.Value = NoticeId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_FF_GET__NOTICE_LIST>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET__NOTICE_LIST>.GetDataBySP(new SP_FF_GET__NOTICE_LIST(), "SP_FF_GET_NOTICE_LIST", 19, resultOutCurSor, NoticeId_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveNotification(decimal NoticeId, decimal NoticeTypeId, decimal NoticeForId, string FromDate, string ToDate, string Title, string Message, string Url, string FileName, decimal IsActive, decimal UserId,string FlashTimes)
        {
            try
            {

				var date = FromDate.Split('/');

				OracleParameter NoticeId_OP = new OracleParameter();
                NoticeId_OP.Direction = System.Data.ParameterDirection.Input;
                NoticeId_OP.OracleDbType = OracleDbType.Decimal;
                NoticeId_OP.Value = NoticeId;

                OracleParameter NoticeTypeId_OP = new OracleParameter();
                NoticeTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                NoticeTypeId_OP.OracleDbType = OracleDbType.Decimal;
                NoticeTypeId_OP.Value = NoticeTypeId;


                OracleParameter NoticeForId_OP = new OracleParameter();
                NoticeForId_OP.Direction = System.Data.ParameterDirection.Input;
                NoticeForId_OP.OracleDbType = OracleDbType.Decimal;
                NoticeForId_OP.Value = NoticeForId;

                OracleParameter FromDate_OP = new OracleParameter();
                FromDate_OP.Direction = System.Data.ParameterDirection.Input;
                FromDate_OP.OracleDbType = OracleDbType.Date;
                FromDate_OP.Value =Convert.ToDateTime(FromDate.Split('/')[2]+"/"+ FromDate.Split('/')[1]+"/"+FromDate.Split('/')[0]).Date;

                OracleParameter ToDate_OP = new OracleParameter();
                ToDate_OP.Direction = System.Data.ParameterDirection.Input;
                ToDate_OP.OracleDbType = OracleDbType.Date;
                ToDate_OP.Value = Convert.ToDateTime(ToDate.Split('/')[2] + "/" + ToDate.Split('/')[1] + "/" + ToDate.Split('/')[0]).Date;

                OracleParameter Title_OP = new OracleParameter();
                Title_OP.Direction = System.Data.ParameterDirection.Input;
                Title_OP.OracleDbType = OracleDbType.NVarchar2;
                Title_OP.Value = Title;

                OracleParameter Message_OP = new OracleParameter();
                Message_OP.Direction = System.Data.ParameterDirection.Input;
                Message_OP.OracleDbType = OracleDbType.NVarchar2;
                Message_OP.Value = Message;

                OracleParameter Url_OP = new OracleParameter();
                Url_OP.Direction = System.Data.ParameterDirection.Input;
                Url_OP.OracleDbType = OracleDbType.Varchar2;
                Url_OP.Value = Url;

                OracleParameter FileName_OP = new OracleParameter();
                FileName_OP.Direction = System.Data.ParameterDirection.Input;
                FileName_OP.OracleDbType = OracleDbType.Varchar2;
                FileName_OP.Value = FileName;

                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = System.Data.ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Decimal;
                IsActive_OP.Value = IsActive;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter FlashTimes_OP = new OracleParameter();
                FlashTimes_OP.Direction = System.Data.ParameterDirection.Input;
                FlashTimes_OP.OracleDbType = OracleDbType.Varchar2;
                FlashTimes_OP.Value = FlashTimes;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET__NOTICE_LIST>.InsertDataBySP("SP_FF_SAVE_NOTICE_LIST", resultOutID, NoticeId_OP, NoticeTypeId_OP, NoticeForId_OP, FromDate_OP,ToDate_OP,Title_OP,Message_OP,Url_OP,FileName_OP,IsActive_OP,UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
   
        public Decimal DeleteNoticeUsers(decimal NoticeId)
        {
            try
            {
                OracleParameter NoticeId_OP = new OracleParameter();
                NoticeId_OP.Direction = System.Data.ParameterDirection.Input;
                NoticeId_OP.OracleDbType = OracleDbType.Decimal;
                NoticeId_OP.Value = NoticeId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_DELETE_NOTICE_USER", resultOutID, NoticeId_OP);  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Decimal SaveNotificationUser(int Index,decimal NoticeId_New, decimal RegionDdRsoId,string MessageEng,string MessagBan,string FileName)
        {
            try
            {
                OracleParameter Index_OP = new OracleParameter();
                Index_OP.Direction = System.Data.ParameterDirection.Input;
                Index_OP.OracleDbType = OracleDbType.Decimal;
                Index_OP.Value = Index;

                OracleParameter NoticeId_OP = new OracleParameter();
                NoticeId_OP.Direction = System.Data.ParameterDirection.Input;
                NoticeId_OP.OracleDbType = OracleDbType.Decimal;
                NoticeId_OP.Value = NoticeId_New;

                OracleParameter RegionDdRsoId_OP = new OracleParameter();
                RegionDdRsoId_OP.Direction = System.Data.ParameterDirection.Input;
                RegionDdRsoId_OP.OracleDbType = OracleDbType.Decimal;
                RegionDdRsoId_OP.Value = RegionDdRsoId;


                OracleParameter MessageEng_OP = new OracleParameter();
                MessageEng_OP.Direction = System.Data.ParameterDirection.Input;
                MessageEng_OP.OracleDbType = OracleDbType.NVarchar2;
                MessageEng_OP.Value = MessageEng;

                OracleParameter MessagBan_OP = new OracleParameter();
                MessagBan_OP.Direction = System.Data.ParameterDirection.Input;
                MessagBan_OP.OracleDbType = OracleDbType.NVarchar2;
                MessagBan_OP.Value = MessagBan;

                OracleParameter FileName_OP = new OracleParameter();
                FileName_OP.Direction = System.Data.ParameterDirection.Input;
                FileName_OP.OracleDbType = OracleDbType.Varchar2;
                FileName_OP.Value = FileName;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                var result= ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET__NOTICE_LIST>.InsertDataBySP("SP_FF_SAVE_NOTICE_USER", resultOutID, Index_OP, NoticeId_OP, RegionDdRsoId_OP, MessageEng_OP, MessagBan_OP, FileName_OP);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_ALL_DISTRIBUTOR> GetNotificationSetupReg(decimal NoticeId)
        {
            try
            {
                OracleParameter NoticeId_OP = new OracleParameter();
                NoticeId_OP.Direction = System.Data.ParameterDirection.Input;
                NoticeId_OP.OracleDbType = OracleDbType.Decimal;
                NoticeId_OP.Value = NoticeId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_ALL_DISTRIBUTOR>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ALL_DISTRIBUTOR>.GetDataBySP(new SP_GET_ALL_DISTRIBUTOR(), "SP_FF_GET_NOTICE_REG", 4, resultOutCurSor, NoticeId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_ALL_DISTRIBUTOR> GetNotificationSetupDis(decimal NoticeId)
        {
            try
            {
                OracleParameter NoticeId_OP = new OracleParameter();
                NoticeId_OP.Direction = System.Data.ParameterDirection.Input;
                NoticeId_OP.OracleDbType = OracleDbType.Decimal;
                NoticeId_OP.Value = NoticeId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_ALL_DISTRIBUTOR>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ALL_DISTRIBUTOR>.GetDataBySP(new SP_GET_ALL_DISTRIBUTOR(), "SP_FF_GET_NOTICE_DIS", 4, resultOutCurSor, NoticeId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Decimal SaveNotificationTime(int Index, decimal NoticeId_New, string NoticeTime)
        {
            try
            {
                OracleParameter Index_OP = new OracleParameter();
                Index_OP.Direction = System.Data.ParameterDirection.Input;
                Index_OP.OracleDbType = OracleDbType.Decimal;
                Index_OP.Value = Index;

                OracleParameter NoticeId_OP = new OracleParameter();
                NoticeId_OP.Direction = System.Data.ParameterDirection.Input;
                NoticeId_OP.OracleDbType = OracleDbType.Decimal;
                NoticeId_OP.Value = NoticeId_New;




                OracleParameter NoticeTime_OP = new OracleParameter();
                NoticeTime_OP.Direction = System.Data.ParameterDirection.Input;
                NoticeTime_OP.OracleDbType = OracleDbType.Varchar2;
                NoticeTime_OP.Value = NoticeTime;



                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                var result = ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET__NOTICE_LIST>.InsertDataBySP("SP_FF_SAVE_NOTICE_TIME", resultOutID, Index_OP, NoticeId_OP, NoticeTime_OP);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal DeleteInfo(decimal TableId)
        {
            try
            {
                OracleParameter TableId_OP = new OracleParameter();
                TableId_OP.Direction = System.Data.ParameterDirection.Input;
                TableId_OP.OracleDbType = OracleDbType.Decimal;
                TableId_OP.Value = TableId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_SURVEY_DETAIL_Q_ANScls>.InsertDataBySP("SP_FF_DELETE_NOTIFICATION", resultOutID, TableId_OP);            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
