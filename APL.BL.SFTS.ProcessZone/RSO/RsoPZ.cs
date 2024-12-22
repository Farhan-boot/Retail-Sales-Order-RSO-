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
    public class RsoPZ
    {
        public const string _collectionNodePart = "Coll";
        public RsoPZ()
        { }

        public List<GET_USER_WORK_AREA> GetUserWorkArea(decimal UserId)
        {
            List<GET_USER_WORK_AREA> routeList = new List<GET_USER_WORK_AREA>();
            try
            {
                routeList = new RsoDZ().GetUserWorkArea(UserId);
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

        public List<SP_GET_RSO_SALES_CALL_DAILY_ATTENDANCE> GetSalesCallAndDailyAttendance(SearchParam searchParam, DateTime? FromDate, DateTime? ToDate)
        {
            List<SP_GET_RSO_SALES_CALL_DAILY_ATTENDANCE> rsoSalesCallAndAttendanceList = new List<SP_GET_RSO_SALES_CALL_DAILY_ATTENDANCE>();
            try
            {
                rsoSalesCallAndAttendanceList = new RsoDZ().GetSalesCallAndDailyAttendance(searchParam, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return rsoSalesCallAndAttendanceList;
        }

        public List<SP_GET_RSO_DETAIL> GetRSODetail(GetRsoDetails rsoDetail)
        {
            List<SP_GET_RSO_DETAIL> rsoDetails = new List<SP_GET_RSO_DETAIL>();
            try
            {
                rsoDetails = new RsoDZ().GetRsoDetails(rsoDetail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return rsoDetails;
        }

        public List<SP_GET_RSO_ATTENDANCE_AND_PATH> GetRsoAttendanceAndPath(SearchParam searchParam, DateTime? FromDate, DateTime? ToDate)
        {
            List<SP_GET_RSO_ATTENDANCE_AND_PATH> rsoAttendanceAndPaths = new List<SP_GET_RSO_ATTENDANCE_AND_PATH>();
            try
            {
                rsoAttendanceAndPaths = new RsoDZ().GetRsoAttendanceAndPath(searchParam, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return rsoAttendanceAndPaths;
        }

        public List<SP_GET_RPT_RSO_TARGET_ACHIVE> GetRsoTargetVsAchivement(GetRsoTargetAchivement rsoTargetAchive, decimal UserId)
        {
            List<SP_GET_RPT_RSO_TARGET_ACHIVE> rsoTargetAchiveList = new List<SP_GET_RPT_RSO_TARGET_ACHIVE>();
            try
            {
                rsoTargetAchiveList = new RsoDZ().GetRsoTargetVsAchivement(rsoTargetAchive, UserId, 1, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return rsoTargetAchiveList;
        }

        public decimal GetPassCode(string loginName)
        {
            decimal appId = 1133;
            try
            {
                return new RsoDZ().GetPassCode(loginName, appId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RSO_COMMISSION> GetRSOCommission(SearchParam searchParam, DateTime? FromDate, DateTime? ToDate)
        {
            List<SP_GET_RSO_COMMISSION> rsoCommission = new List<SP_GET_RSO_COMMISSION>();
            try
            {
                rsoCommission = new RsoDZ().GetRSOCommission(searchParam, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return rsoCommission;
        }

        public List<GET_DROPDOWN> GetOperatorCode()
        {
            try
            {
                List<GET_DROPDOWN> opCodeList = new List<GET_DROPDOWN>();
                opCodeList = new List<GET_DROPDOWN>()
                {
                    new GET_DROPDOWN {CODE_NAME = "GP", NAME = "GP" },
                    new GET_DROPDOWN {CODE_NAME = "Robi", NAME = "Robi" },
                    new GET_DROPDOWN {CODE_NAME = "Airtel", NAME = "Airtel" }
					//new GET_DROPDOWN {CODE_NAME = "BanglaLink", NAME = "BanglaLink" }
				};


                return opCodeList;
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
                return new RsoDZ().GetMarketUpdateTypes(Id);
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
                return new RsoDZ().GetDistricts(Id, UserId);
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
                return new RsoDZ().GetThanas(Id, UserId);
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
                return new RsoDZ().GetEventInfo(Id, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RSO_TARGET_ACHIVEMENT> GetRsoTargetAchive(decimal UserId, decimal MonthCount)
        {
            try
            {
                return new RsoDZ().GetRsoTargetAchive(UserId, MonthCount, 0, 0, 0);
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
                return new RsoDZ().GetRetailerAchievement(ItemType, UserId);
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
                return new RsoDZ().GetRsoRoutes(UserId, DayName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetMenuByHeaderBodyFooter GetMenuGroupList(decimal UserType, decimal LanguageId)
        {
            try
            {
                List<SP_FF_GET_MENU_GROUP_ITEM_LIST> GroupList = new List<SP_FF_GET_MENU_GROUP_ITEM_LIST>();
				List < SP_FF_GET_MENU_GROUP_ITEM_LIST > MENU_GROUP_ITEM = new List<SP_FF_GET_MENU_GROUP_ITEM_LIST>();
				List<GetMenuGrouplIST> getMenuGrouplIST = new List<GetMenuGrouplIST>();
				GetMenuByHeaderBodyFooter getMenuByHBF = new GetMenuByHeaderBodyFooter();

				GroupList = new RsoDZ().GetGroupItems(UserType, 0, 0, LanguageId);
				foreach (SP_FF_GET_MENU_GROUP_ITEM_LIST grouplist in GroupList)
				{
					GetMenuGrouplIST getMenuGroup = new GetMenuGrouplIST();
					MENU_GROUP_ITEM = new RsoDZ().GetGroupItems(UserType, grouplist.MENUITEM_ID, 0, LanguageId);
					
					getMenuGroup.GROUP_ID = grouplist.GROUP_ID;
					getMenuGroup.MENUITEM_ID = grouplist.MENUITEM_ID;
					getMenuGroup.MENU_NAME = grouplist.MENU_NAME;
					getMenuGroup.MENU_URL = grouplist.MENU_URL;

					getMenuGroup.MENU_GROUP_ITEM = MENU_GROUP_ITEM;

					getMenuGrouplIST.Add(getMenuGroup);

				}
				getMenuByHBF.Body = getMenuGrouplIST;


				/*
				int i = 0;
				for (i = 1; i < 4; i++)
				{
					if (i >= 4) { break; }
					 GroupList = new RsoDZ().GetGroupItems(UserType, 0, i, LanguageId);
					if (i == 1)
					{
						getMenuByHBF.Header = GroupList;
					}
					else if (i == 2)
					{
						
						foreach (SP_FF_GET_MENU_GROUP_ITEM_LIST grouplist in GroupList)
						{
							GetMenuGrouplIST getMenuGroup = new GetMenuGrouplIST();
							MENU_GROUP_ITEM = new RsoDZ().GetGroupItems(UserType, grouplist.MENUITEM_ID, i, LanguageId);

							getMenuGroup.GROUP_ID = grouplist.GROUP_ID;
							getMenuGroup.MENUITEM_ID = grouplist.MENUITEM_ID;							
							getMenuGroup.MENU_NAME = grouplist.MENU_NAME;
							getMenuGroup.MENU_URL = grouplist.MENU_URL;

							getMenuGroup.MENU_GROUP_ITEM = MENU_GROUP_ITEM;

							getMenuGrouplIST.Add(getMenuGroup);

						}
						getMenuByHBF.Body = getMenuGrouplIST;

					}
					else if (i == 3)
					{
						getMenuByHBF.Footer = GroupList;
					}
					
					

				}*/

                return getMenuByHBF;
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
                List<SP_FF_TRAINING_SECTION_LIST> TrainingSectionList = new List<SP_FF_TRAINING_SECTION_LIST>();
                TrainingSectionList = new RsoDZ().GetTrainingSectionList(UserId);
                
                return TrainingSectionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SP_FF_GET_TRAINING_SECTION GetTrainingSection(decimal UserId, decimal TrainingId)
        {
            try
            {
                SP_FF_GET_TRAINING_SECTION TrainingSection = new SP_FF_GET_TRAINING_SECTION();
                TrainingSection = new RsoDZ().GetTrainingSection(UserId,TrainingId).FirstOrDefault();
                return TrainingSection;
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
                SaveResult getResult = new RsoDZ().SaveBioDeviceReturnInfo(UserId,  ReturnDate,  DeviceId,  Remarks,  RetailerId);

                return getResult;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_RETAILER_ROUTE> GetRetailerByRoute(decimal RouteId)
        {
            try
            {
                return new RsoDZ().GetRetailerByRoute(RouteId);
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
                return new RsoDZ().GetRsoGPS(TerritoryId, RsoId, VisitDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveUpdateRsoBestPractice(decimal BestPracticesRsoId, decimal RsoId,
                                        decimal RetailerMarketAreaId, decimal PeriodId, decimal Year, decimal CalculationAreaId,
                                        String Description, decimal CreatedBy)
        {
            try
            {
                return new RsoDZ().SaveUpdateBestRsoPractice(BestPracticesRsoId, RsoId, RetailerMarketAreaId, PeriodId, Year, CalculationAreaId, Description, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_BEST_RSO_PRACTICE> GetAllBestRsoPractice(decimal BestPracticesRsoId, decimal StaffUserId)
        {
            try
            {
                return new RsoDZ().GetAllBestRSOPractice(BestPracticesRsoId, StaffUserId);
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
                return new RsoDZ().GetAllRso(distributorID, rsoID);
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
                return new RsoDZ().GetRsoFromZone(distributorID, rsoID, zoneID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public List<SP_GET_RSO_COMMISSION_SUMMSRY> GetCommissionSummary(decimal DistributorId, decimal RsoId, decimal MonthId)
		{
			try
			{
				return new RsoDZ().GetCommissionSummary(DistributorId, RsoId, MonthId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<SP_GET_RSO_COMMISSION_DETAILS> GetCommissionDetails(decimal masterID)
		{
			try
			{
				return new RsoDZ().GetCommissionDetails(masterID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<SP_GET_FF_RSO_EARNING> GetRsoEarning(decimal DistributorId, decimal RsoId, decimal MonthId)
		{
			try
			{
				return new RsoDZ().GetRsoEarning(DistributorId, RsoId, MonthId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		/// <summary>
		/// Get Apps Inbox data for all RSO , all distributor, particular distributor or particular RSO by search option.
		/// </summary>
		/// <param name="distributorID"></param>
		/// <param name="rsoID"></param>
		/// <param name="fromDate"></param>
		/// <param name="toDate"></param>
		/// <returns>List of RSO Apps Inbox object for Web Service compatible XML soap data format</returns>
		public ServiceStringXML GetROS_AppsInboxXML(decimal distributorID, decimal rsoID, DateTime fromDate, DateTime toDate)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            string objectXML = string.Empty;
            string objectItemName = new SP_INS_UPD_RSO_APPS_INBOXcls().GetType().Name + _collectionNodePart;
            try
            {
                List<SP_INS_UPD_RSO_APPS_INBOXcls> rosColl = new RsoDZ().GetRsoAppsInbox(0, 0, fromDate, toDate);
                List<SP_INS_UPD_RSO_APPS_INBOXcls> rosFilterColl = new List<SP_INS_UPD_RSO_APPS_INBOXcls>();
                if (rosColl != null && rosColl.Count > 0)
                {
                    foreach (var item in rosColl)
                    {
                        item.NOTICE_TYPE_STR = ((EnumCollection.NoticeTypeEnum)item.NOTICE_TYPE).ToString();
                        if (item.DISTRIBUTOR_ID == 0 && item.RSO_ID == 0)
                        {
                            rosFilterColl.Add(item);
                        }
                        else if (item.DISTRIBUTOR_ID == 0 && item.RSO_ID == rsoID)
                        {
                            rosFilterColl.Add(item);

                        }
                        else if (item.DISTRIBUTOR_ID == distributorID && item.RSO_ID == 0)
                        {
                            rosFilterColl.Add(item);
                        }
                        else if (item.DISTRIBUTOR_ID == distributorID && item.RSO_ID == rsoID)
                        {
                            rosFilterColl.Add(item);
                        }
                    }
                }
                if (rosFilterColl != null && rosFilterColl.Count > 0)
                {
                    objectXML = ConversionXML.ConvertObjectToXML<SP_INS_UPD_RSO_APPS_INBOXcls>(rosFilterColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
        }

        /// <summary>
        /// Get all Apps Inbox data using paging option for RSO by search option.
        /// </summary>
        /// <param name="inbox_Id"></param>
        /// <param name="rsoID"></param>
        /// <param name="distributorID"></param>
        /// <param name="noticeTypeID"></param>
        /// <param name="noticeInfo"></param>
        /// <param name="fromDATE"></param>
        /// <param name="toDATE"></param>
        /// <param name="currentPage"></param>
        /// <returns>List of related object</returns>
        public List<SP_INS_UPD_RSO_APPS_INBOXcls> GetRsoAppsInboxPaging(decimal inbox_Id, decimal rsoID,
                      decimal distributorID, decimal noticeTypeID, string noticeInfo, string fromDATE, string toDATE, decimal currentPage)
        {
            try
            {
                return new RsoDZ().GetRsoAppsInboxPaging(inbox_Id, rsoID, distributorID, noticeTypeID, noticeInfo, fromDATE, toDATE, currentPage);
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
        /// <returns>List of related object for Web Service compatible XML soap data format</returns>
        public ServiceStringXML GetRsoTargetAndCommission(Decimal distributorID, Decimal rsoID, string monthDate, Decimal prodCategoryID)
        {
            ServiceStringXML serviceStrXmlObj = new ServiceStringXML();
            string objectXML = string.Empty;
            string objectItemName = new SP_GET_RSO_TAR_ACHIcls().GetType().Name + _collectionNodePart;
            try
            {
                List<SP_GET_RSO_TAR_ACHIcls> rosColl = new RsoDZ().GetRsoTargetAndCommission(distributorID, rsoID, monthDate, prodCategoryID);
                if (rosColl != null && rosColl.Count > 0)
                {
                    foreach (var item in rosColl)
                    {
                        item.PRODUCT_CATEGORY_NAME = ((ProductCategoryEnum)item.PRODUCT_CATEGORY_ID).ToString();
                    }
                    objectXML = ConversionXML.ConvertObjectToXML<SP_GET_RSO_TAR_ACHIcls>(rosColl, _collectionNodePart);
                }
                else
                {
                    objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.DataNotFound);
                }
            }
            catch (Exception ex)
            {
                serviceStrXmlObj.IssueArisePlace = this.ToString();
                serviceStrXmlObj.OperationMessage = ex.Message;
                serviceStrXmlObj.StackTrace = ex.StackTrace;
                objectXML = MessageReplyXML.Confirmation(objectItemName, false, MessageGodown.NoInternet);
            }
            finally
            {
                serviceStrXmlObj.ObjectXML = objectXML;
            }
            return serviceStrXmlObj;
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
        public Decimal SaveROSAppsInbox(decimal totalVisitor, decimal isPending, decimal distributorID, DateTime adminVisitDate, String noticeNote, DateTime inDate, decimal rsoInboxID, decimal noticeType, decimal rsoID, decimal adminID)
        {
            Decimal objectAppsInboxId = 0;
            string objectItemName = new SP_INS_UPD_RSO_APPS_INBOXcls().GetType().Name + _collectionNodePart;
            try
            {
                objectAppsInboxId = new RsoDZ().SaveRsoAppsInbox(totalVisitor, isPending, distributorID, adminVisitDate, noticeNote, inDate, rsoInboxID, noticeType, rsoID, adminID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objectAppsInboxId;
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
            Decimal objectAppsInboxId = 0;
            string objectItemName = new SP_INS_UPD_RSO_APPS_INBOXcls().GetType().Name + _collectionNodePart;
            try
            {
                objectAppsInboxId = new RsoDZ().UpdateRSOInbox(distributorID, noticeNote, rsoInboxID, noticeType, rsoID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objectAppsInboxId;
        }

        public List<SP_GET_SPECIAL_REPORT> GetSpecialReport(SearchParam searchParam)
        {
            List<SP_GET_SPECIAL_REPORT> retailerSales = new List<SP_GET_SPECIAL_REPORT>();
            try
            {
                retailerSales = new RsoDZ().GetSpecialReport(searchParam);
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
