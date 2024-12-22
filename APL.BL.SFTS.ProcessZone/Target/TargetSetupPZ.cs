using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APL.BL.SFTS.DataBridgeZone;

namespace APL.BL.SFTS.ProcessZone
{
    public class TargetSetupPZ
    {
        public TargetSetupPZ()
        {
        }

        public decimal SaveOrUpdateTargetSetup(decimal targetId, decimal comissionId, decimal tyreId, decimal distributorId,
            decimal retailerId, DateTime startDate, DateTime endDate, decimal maxPecent, decimal minPercent,
            decimal accuratePercent,
            decimal targetApplicable, decimal budgetFigure, decimal isApproved, DateTime submittedDate, decimal isActive,
            decimal createdBy, DateTime createDate, decimal updateBy, DateTime updateDate,
            Decimal productCategoryId, string productIdList, Decimal budgetUnit)
        {
            try
            {
                return new TargetSetupDZ().SaveOrUpdateTargetSetup(targetId, comissionId, tyreId, distributorId,
                                                                   retailerId, startDate, endDate, maxPecent, minPercent,
                                                                   accuratePercent, targetApplicable, budgetFigure, isApproved, submittedDate, isActive,
                                                                   createdBy, createDate, updateBy, updateDate, productCategoryId, productIdList, budgetUnit);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SP_GET_TARGET_SETUPcls> GetTargetSetupPaging(Decimal target_Id, Decimal comission_Id,
            Decimal tyre_Id, Decimal retailerID,
            decimal distributorID, string submittedDateFrom, string submittedDateTo, string startDateFrom,
            string endDateTo, Decimal parcentBetween, Decimal currentPage)
        {
            try
            {
                return new TargetSetupDZ().GetTargetSetupPaging(target_Id, comission_Id, tyre_Id, retailerID,
                    distributorID, submittedDateFrom, submittedDateTo, startDateFrom, endDateTo, parcentBetween,
                    currentPage);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SP_GET_TARGET_SETUPcls> GetAllTargetSetup(decimal target_Id, decimal comission_Id, decimal tyre_Id, decimal retailerID, decimal distributorID, decimal productCategoryID)
        {
            try
            {
                return new TargetSetupDZ().GetAllTargetSetup(target_Id, comission_Id, tyre_Id, retailerID, distributorID, productCategoryID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SP_GET_TARGET_ITEM> GetAllTargetItem(Decimal targetItemID)
        {
            try
            {
                return new TargetSetupDZ().GetAllTargetItem(targetItemID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_TARGET_PERIOD> GetAllTargetPeriod(Decimal targetPeriodID)
        {
            try
            {
                return new TargetSetupDZ().GetAllTargetPeriod(targetPeriodID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public List<SP_GET_TARGET_PERIOD> GetAllCommissionPeriod(Decimal targetPeriodID)
		{
			try
			{
				return new TargetSetupDZ().GetAllCommissionPeriod(targetPeriodID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<SP_GET_MONTH> GetMonths(Decimal MonthId)
        {
            List<SP_GET_MONTH> monthList = new List<SP_GET_MONTH>();
            SP_GET_MONTH month = new SP_GET_MONTH();
            try
            {
                monthList = new List<SP_GET_MONTH>()
                {
                    new SP_GET_MONTH() {MONTH_ID = 1, MONTH_NAME = "JANUARY" },
                    new SP_GET_MONTH() {MONTH_ID = 2, MONTH_NAME = "FEBRUARY" },
                    new SP_GET_MONTH() {MONTH_ID = 3, MONTH_NAME = "MARCH" },
                    new SP_GET_MONTH() {MONTH_ID = 4, MONTH_NAME = "APRIAL" },
                    new SP_GET_MONTH() {MONTH_ID = 5, MONTH_NAME = "MAY" },
                    new SP_GET_MONTH() {MONTH_ID = 6, MONTH_NAME = "JUNE" },
                    new SP_GET_MONTH() {MONTH_ID = 7, MONTH_NAME = "JULY" },
                    new SP_GET_MONTH() {MONTH_ID = 8, MONTH_NAME = "AUGUST" },
                    new SP_GET_MONTH() {MONTH_ID = 9, MONTH_NAME = "SEPTEMBER" },
                    new SP_GET_MONTH() {MONTH_ID = 10, MONTH_NAME = "OCTOBER" },
                    new SP_GET_MONTH() {MONTH_ID = 11, MONTH_NAME = "NOVEMBER" },
                    new SP_GET_MONTH() {MONTH_ID = 12, MONTH_NAME = "DECEMBER" }
                };

                return monthList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_VISIT_TYPE> GetAllVisitType(Decimal VisitTypeId)
        {
            try
            {
                return new TargetSetupDZ().GetAllVisitType(VisitTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_CENTER_TYPE> GetCenterTypes(Decimal CenterTypeId)
        {
            try
            {
                return new TargetSetupDZ().GetCenterTypes(CenterTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_ROLES> GetRoles(Decimal RoleId)
        {
            try
            {
                return new TargetSetupDZ().GetRoles(RoleId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_CHANNEL_TYPE> GetChannelType(Decimal ChannelTypeId)
        {
            try
            {
                return new TargetSetupDZ().GetChannelType(ChannelTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveOrUpdateDistributorTarget(decimal id, decimal targetItemId, decimal targetPeriod, int isActive, decimal createdByUserId, DateTime displayToDate)
        {
            try
            {
                return new TargetSetupDZ().SaveUpdateDistributorTarget(id, targetItemId, targetPeriod, isActive, createdByUserId, displayToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal UploadTargetDetail(decimal uploadCode, string monthCode, string itemCode, string applyId, decimal targetValue, decimal applyType, decimal log, decimal applySubType)
        {
            try
            {
                return new TargetSetupDZ().UploadTargetDetail(uploadCode, monthCode, itemCode, applyId, targetValue, applyType, log, applySubType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_TARGET_SETUPcls> GetUploadedTarget(decimal target_Id, decimal comission_Id, decimal tyre_Id, decimal retailerID, decimal distributorID, decimal productCategoryID)
        {
            try
            {
                return new TargetSetupDZ().GetAllTargetSetup(target_Id, comission_Id, tyre_Id, retailerID, distributorID, productCategoryID);

                //SP_GET_UPLOADED_TARGET
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal SaveUpdateTarget(decimal id, decimal TargetForId, decimal StaffRoleId, string targetItemCode, string targetPeriodCode, decimal uploadCode, DateTime setDate, decimal createdBy, decimal Version, DateTime RevisionUpTo)
        {
            try
            {
                return new TargetSetupDZ().SaveUpdateTarget(id, TargetForId, StaffRoleId, targetItemCode, targetPeriodCode, uploadCode, setDate, createdBy, Version, RevisionUpTo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveUpdateTargetRevise(decimal Id, decimal TargetId, decimal TargetDetailId, decimal Version, decimal TargetValue, decimal RevisedTargetValue, string Comments, decimal CreatedBy)
        {
            decimal result = 0;
            decimal TargetModifyDetailId = 0;
            try
            {
              decimal IsMasterSaved = new TargetSetupDZ().SaveUpdateTargetRevise(Id, TargetId, CreatedBy);
              decimal IsDetailSaved = new TargetSetupDZ().SaveUpdateTargetReviseDetail(TargetModifyDetailId, TargetId, TargetDetailId, Version, TargetValue, RevisedTargetValue, Id, Comments);

              result = IsMasterSaved;

              return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveStaffTargetRevise(decimal Id, decimal UserId, decimal TargetId, decimal Version, List<SP_GET_STAFF_TARGET_DETAIL> staffTargetList)
        {
            decimal result = 0;
            decimal TargetModifyDetailId = 0;
            try
            {
                decimal IsMasterSaved = new TargetSetupDZ().SaveStaffTargetModifyMaster(Id, UserId, TargetId, Version);

                decimal IsDetailSaved = 0;
                foreach (SP_GET_STAFF_TARGET_DETAIL staffTarget in staffTargetList)
                {
                    IsDetailSaved = new TargetSetupDZ().SaveStaffTargetModifyeDetail(TargetModifyDetailId, TargetId, staffTarget.ID, staffTarget.TARGET_VALUE_FOR_REVISE, Id, staffTarget.COMMENTS);
                }
                
                result = IsMasterSaved;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_TARGET_SETUP> GetAllTarget()
        {
            try
            {
                return new TargetSetupDZ().GetAllTarget();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_DISTRIBUTOR_UP_TARGET> GetAllDistributorTarget()
        {
            try
            {
                return new TargetSetupDZ().GetAllDistributorTarget();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_STAFF_TARGET> GetStaffTarget(decimal UserId, decimal Version)
        {
            try
            {
                return new TargetSetupDZ().GetStaffTarget(UserId, Version);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_STAFF_TARGET> GetStaffTargetForApprove(decimal UserId, decimal Version, decimal? UserType)
        {
            try
            {
                return new TargetSetupDZ().GetStaffTargetForApprove(UserId, Version, UserType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_IS_VALID_TARGET_FOR> GetIsValidTargetFor(decimal TargetForId, decimal StaffTypeId, string TargetForCode)
        {
            try
            {
                return new TargetSetupDZ().GetIsValidTargetFor(TargetForId, StaffTypeId, TargetForCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_STAFF_TARGET_DETAIL> GetStaffTargetDetailForApproval(decimal TargetId, decimal Version)
        {
            try
            {
                return new TargetSetupDZ().GetStaffTargetDetailForApproval(TargetId, Version);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_STAFF_TARGET_DETAIL> GetStaffTargetDetail(decimal TargetId, decimal Version, decimal UserId)
        {
            try
            {
                return new TargetSetupDZ().GetStaffTargetDetail(TargetId, Version, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_STAFF_TARGET_DETAIL> GetStaffReqTargetDetail(decimal TargetId, decimal Version)
        {
            try
            {
                return new TargetSetupDZ().GetStaffReqTargetDetail(TargetId, Version);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_DISTRIBUTOR_TARGET> GetDistributorTarget(decimal Id, decimal UserId)
        {
            try
            {
                return new TargetSetupDZ().GetDistributorTarget(Id, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_DISTRIBUTOR_TARGET> GetDistributorTargetForApprove(decimal Id, decimal UserId, decimal? UserType)
        {
            try
            {
                return new TargetSetupDZ().GetDistributorTargetForApprove(Id, UserId, UserType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_DISTRIBUTOR_TARGET> GetDistributorTargetDetail(decimal Id, decimal UserId, decimal Version)
        {
            try
            {
                return new TargetSetupDZ().GetDistributorTargetDetail(Id, UserId, Version);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_DISTRIBUTOR_TARGET> GetDistributorTargetReviseReq(decimal Id, decimal UserId, decimal Version)
        {
            try
            {
                return new TargetSetupDZ().GetDistributorTargetReviseReq(Id, UserId, Version);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal ApproveDistributorTargetRevise(decimal TargetId, decimal Version, decimal ActionType, string ApproverComment, decimal UserId, decimal? UserType)
        {
            try
            {
                return new TargetSetupDZ().ApproveDistributorTargetRevise(TargetId, Version, ActionType, ApproverComment, UserId, UserType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal ApproveStaffTargetRevise(decimal TargetId, decimal Version, decimal ActionType, string ApproverComment, decimal UserId, decimal? UserType)
        {
            try
            {
                return new TargetSetupDZ().ApproveStaffTargetRevise(TargetId, Version, ActionType, ApproverComment, UserId, UserType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_DISTRIBUTOR_TARGET_FILE> GetUploadedFileData(Decimal uploadCode, Decimal applyType)
        {
            try
            {
                return new TargetSetupDZ().GetUploadedFileData(uploadCode, applyType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_TARGET_FILE> TargetExcelTemplate(Decimal TargetPeriodId, Decimal TargetItemId, Decimal TargetFor, Decimal StaffTypeId)
        {
            try
            {
                return new TargetSetupDZ().GetTargetTemplate(TargetPeriodId, TargetItemId, TargetFor, StaffTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_TARGET_FILE> GetUploadedTargets(Decimal TargetPeriodId, Decimal TargetItemId, Decimal TargetFor, Decimal StaffTypeId, bool InitialVersion)
        {
            try
            {
                decimal IsInitialVersion = InitialVersion ? 1 : 0;
                return new TargetSetupDZ().GetUploadedTarget(TargetPeriodId, TargetItemId, TargetFor, StaffTypeId, IsInitialVersion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public List<SP_FF_GET_NOTIFICATION_TYPE> GetNotificationTypes(Decimal CenterTypeId)
		{
			try
			{
				return new TargetSetupDZ().GetNotificationTypes(CenterTypeId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<SP_GET_TARGET_PERIOD> GetTargetPeriodEarning(Decimal type)
		{
			try
			{
				return new TargetSetupDZ().GetTargetPeriodEarning(type);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
