using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.Notice;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.Notice
{
    public class NoticeSetupPZ
    {
        public NoticeSetupPZ()
        { }
        public List<SP_FF_GET_NOTIFICATION_TYPE> GetNotificationTypes(Decimal CenterTypeId)
        {
            try
            {
                return new NoticeSetupDZ().GetNotificationTypes(CenterTypeId);
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
				return new NoticeSetupDZ().GetAllRso(rsoCode);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<SP_GET_RETAILERcls> GetAllRetailer(string retailerCode)
		{
			try
			{
				return new NoticeSetupDZ().GetAllRetailer(retailerCode);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<GET_REGION> GetRegions()
        {
            List<GET_REGION> regionList = new List<GET_REGION>();
            try
            {
                regionList = new NoticeSetupDZ().GetRegion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return regionList;
        }
        public List<SP_GET_DISTRIBUTOR_BY_REG_IDcls> GetDistributor(Decimal regionID, Decimal distributorID, Decimal teritoryID)
        {
            try
            {
                return new NoticeSetupDZ().GetAllRegionDistributorTerri(regionID, distributorID, teritoryID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_FF_GET__NOTICE_LIST> GetNoticeList(decimal NoticeId,decimal UserId)
        {
            List<SP_FF_GET__NOTICE_LIST> routeList = new List<SP_FF_GET__NOTICE_LIST>();
            try
            {
                routeList = new NoticeSetupDZ().GetNoticeList(NoticeId,UserId);
                if(NoticeId>0)
                {
                    routeList = routeList.Where(w => w.NOTICE_ID == NoticeId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return routeList;
        }


        public Decimal SaveNotification(decimal NoticeId,decimal NoticeTypeId, decimal NoticeForId,string FromDate,string ToDate,string Title,string Message,string Url,string FileName, decimal IsActive, decimal UserId,string FlashTimes, List<GET_ID> noticeRegionList)
        {
            decimal result = 0;
            try
            {
                decimal IsEventSaved = 0;
                IsEventSaved = new NoticeSetupDZ().SaveNotification(NoticeId, NoticeTypeId, NoticeForId, FromDate, ToDate, Title, Message, Url, FileName, IsActive, UserId,FlashTimes);

              
                result = IsEventSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public List<SP_GET_ALL_DISTRIBUTOR> GetNotificationSetupReg(decimal NoticeId)
        {
            try
            {
                return new NoticeSetupDZ().GetNotificationSetupReg(NoticeId);
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
                return new NoticeSetupDZ().GetNotificationSetupDis(NoticeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Decimal SaveNotificationUsersAndTimes(List<NoticeUser> NoticeUsers, List<NoticeTime> NoticeTimes)
        {
            decimal result = 0;
            try
            {
                decimal IsEventSaved = 0;
                int i = 0;
               // var ff = new NoticeSetupDZ().DeleteNoticeUsers(NoticeUsers[0].NoticeId);
                foreach (var item in NoticeUsers)
                {
                  
                    IsEventSaved = new NoticeSetupDZ().SaveNotificationUser(i,item.NoticeId,item.RegionDdRsoId,item.Message_Eng,item.Message_Ban,item.FileName);
                    i++;
                }
                int j = 0;
                foreach (var item in NoticeTimes)
                {
                    IsEventSaved = new NoticeSetupDZ().SaveNotificationTime(j, item.NoticeId, item.NtcTime);
                    j++;
                }
                result = IsEventSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public decimal DeleteInfo(decimal TableId)
        {
            try
            {
                return new NoticeSetupDZ().DeleteInfo(TableId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
