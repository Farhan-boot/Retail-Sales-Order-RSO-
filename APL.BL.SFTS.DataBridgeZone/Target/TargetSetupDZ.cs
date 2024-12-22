using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class TargetSetupDZ
    {
        public TargetSetupDZ()
        {
        }

        public decimal SaveOrUpdateTargetSetup(decimal targetId, decimal comissionId, decimal tyreId, decimal distributorId,
          decimal retailerId, DateTime startDate, DateTime endDate, decimal maxPecent, decimal minPercent, decimal accuratePercent,
          decimal targetApplicable, decimal budgetFigure, decimal isApproved, DateTime submittedDate, decimal isActive,
          decimal createdBy, DateTime createDate, decimal updateBy, DateTime updateDate,
          Decimal productCategoryId, string productIdList, Decimal budgetUnit)
        {
            try
            {
                OracleParameter targetId_OP = new OracleParameter();
                targetId_OP.Direction = System.Data.ParameterDirection.Input;
                targetId_OP.OracleDbType = OracleDbType.Decimal;
                targetId_OP.Value = targetId;

                OracleParameter comissionId_OP = new OracleParameter();
                comissionId_OP.Direction = System.Data.ParameterDirection.Input;
                comissionId_OP.OracleDbType = OracleDbType.Decimal;
                comissionId_OP.Value = comissionId;

                OracleParameter tyreId_OP = new OracleParameter();
                tyreId_OP.Direction = System.Data.ParameterDirection.Input;
                tyreId_OP.OracleDbType = OracleDbType.Decimal;
                tyreId_OP.Value = tyreId;

                OracleParameter distributorId_OP = new OracleParameter();
                distributorId_OP.Direction = System.Data.ParameterDirection.Input;
                distributorId_OP.OracleDbType = OracleDbType.Decimal;
                distributorId_OP.Value = distributorId;

                OracleParameter retailerId_OP = new OracleParameter();
                retailerId_OP.Direction = System.Data.ParameterDirection.Input;
                retailerId_OP.OracleDbType = OracleDbType.Decimal;
                retailerId_OP.Value = retailerId;

                OracleParameter startDate_OP = new OracleParameter();
                startDate_OP.Direction = System.Data.ParameterDirection.Input;
                startDate_OP.OracleDbType = OracleDbType.Date;
                startDate_OP.Value = startDate;

                OracleParameter endDate_OP = new OracleParameter();
                endDate_OP.Direction = System.Data.ParameterDirection.Input;
                endDate_OP.OracleDbType = OracleDbType.Date;
                endDate_OP.Value = endDate;

                OracleParameter maxPecent_OP = new OracleParameter();
                maxPecent_OP.Direction = System.Data.ParameterDirection.Input;
                maxPecent_OP.OracleDbType = OracleDbType.Decimal;
                maxPecent_OP.Value = maxPecent;

                OracleParameter minPercent_OP = new OracleParameter();
                minPercent_OP.Direction = System.Data.ParameterDirection.Input;
                minPercent_OP.OracleDbType = OracleDbType.Decimal;
                minPercent_OP.Value = minPercent;

                OracleParameter accuratePercent_OP = new OracleParameter();
                accuratePercent_OP.Direction = System.Data.ParameterDirection.Input;
                accuratePercent_OP.OracleDbType = OracleDbType.Decimal;
                accuratePercent_OP.Value = accuratePercent;

                OracleParameter targetApplicable_OP = new OracleParameter();
                targetApplicable_OP.Direction = System.Data.ParameterDirection.Input;
                targetApplicable_OP.OracleDbType = OracleDbType.Char;
                targetApplicable_OP.Size = 1;
                targetApplicable_OP.Value = targetApplicable;

                OracleParameter budgetFigure_OP = new OracleParameter();
                budgetFigure_OP.Direction = System.Data.ParameterDirection.Input;
                budgetFigure_OP.OracleDbType = OracleDbType.Decimal;
                budgetFigure_OP.Value = budgetFigure;

                OracleParameter isApproved_OP = new OracleParameter();
                isApproved_OP.Direction = System.Data.ParameterDirection.Input;
                isApproved_OP.OracleDbType = OracleDbType.Decimal;
                isApproved_OP.Value = isApproved;

                OracleParameter submittedDate_OP = new OracleParameter();
                submittedDate_OP.Direction = System.Data.ParameterDirection.Input;
                submittedDate_OP.OracleDbType = OracleDbType.Date;
                submittedDate_OP.Value = submittedDate;

                OracleParameter isActive_OP = new OracleParameter();
                isActive_OP.Direction = System.Data.ParameterDirection.Input;
                isActive_OP.OracleDbType = OracleDbType.Decimal;
                isActive_OP.Value = isActive;

                OracleParameter createdBy_OP = new OracleParameter();
                createdBy_OP.Direction = System.Data.ParameterDirection.Input;
                createdBy_OP.OracleDbType = OracleDbType.Decimal;
                createdBy_OP.Value = createdBy;

                OracleParameter createDate_OP = new OracleParameter();
                createDate_OP.Direction = System.Data.ParameterDirection.Input;
                createDate_OP.OracleDbType = OracleDbType.Date;
                createDate_OP.Value = createDate;

                OracleParameter updateBy_OP = new OracleParameter();
                updateBy_OP.Direction = System.Data.ParameterDirection.Input;
                updateBy_OP.OracleDbType = OracleDbType.Decimal;
                updateBy_OP.Value = updateBy;

                OracleParameter updateDate_OP = new OracleParameter();
                updateDate_OP.Direction = System.Data.ParameterDirection.Input;
                updateDate_OP.OracleDbType = OracleDbType.Date;
                updateDate_OP.Value = updateDate;


                OracleParameter productCategoryId_OP = new OracleParameter();
                productCategoryId_OP.Direction = System.Data.ParameterDirection.Input;
                productCategoryId_OP.OracleDbType = OracleDbType.Decimal;
                productCategoryId_OP.Value = productCategoryId;

                OracleParameter productIdList_OP = new OracleParameter();
                productIdList_OP.Direction = System.Data.ParameterDirection.Input;
                productIdList_OP.OracleDbType = OracleDbType.Varchar2;
                productIdList_OP.Value = productCategoryId;

                OracleParameter budgetUnit_OP = new OracleParameter();
                budgetUnit_OP.Direction = System.Data.ParameterDirection.Input;
                budgetUnit_OP.OracleDbType = OracleDbType.Decimal;
                budgetUnit_OP.Value = budgetUnit;

                OracleParameter OutTargetId = new OracleParameter();
                OutTargetId.Direction = System.Data.ParameterDirection.Output;
                OutTargetId.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_TARGET_SETUPcls>.InsertDataBySP(
                    "SP_INS_UPD_TARGET_SETUP",
                    OutTargetId, targetId_OP, comissionId_OP, tyreId_OP, distributorId_OP,
                    retailerId_OP, startDate_OP, endDate_OP, maxPecent_OP, minPercent_OP, accuratePercent_OP,
                    targetApplicable_OP, budgetFigure_OP, isApproved_OP, submittedDate_OP, isActive_OP, createdBy_OP,
                    createDate_OP, updateBy_OP, updateDate_OP, productCategoryId_OP, productIdList_OP, budgetUnit_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_TARGET_SETUPcls> GetTargetSetupPaging(decimal target_Id, decimal comission_Id,
            decimal tyre_Id, decimal retailerID,
            decimal distributorID, string submittedDateFrom, string submittedDateTo, string startDateFrom,
            string endDateTo, decimal parcentBetween, decimal currentPage)
        {
            try
            {
                OracleParameter target_Id_OP = new OracleParameter();
                target_Id_OP.Direction = System.Data.ParameterDirection.Input;
                target_Id_OP.OracleDbType = OracleDbType.Decimal;
                target_Id_OP.Value = target_Id;

                OracleParameter comission_Id_OP = new OracleParameter();
                comission_Id_OP.Direction = System.Data.ParameterDirection.Input;
                comission_Id_OP.OracleDbType = OracleDbType.Decimal;
                comission_Id_OP.Value = comission_Id;

                OracleParameter tyre_Id_OP = new OracleParameter();
                tyre_Id_OP.Direction = System.Data.ParameterDirection.Input;
                tyre_Id_OP.OracleDbType = OracleDbType.Decimal;
                tyre_Id_OP.Value = tyre_Id;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter submittedDateFrom_OP = new OracleParameter();
                submittedDateFrom_OP.Direction = System.Data.ParameterDirection.Input;
                submittedDateFrom_OP.OracleDbType = OracleDbType.Varchar2;
                submittedDateFrom_OP.Value = submittedDateFrom;

                OracleParameter submittedDateTo_OP = new OracleParameter();
                submittedDateTo_OP.Direction = System.Data.ParameterDirection.Input;
                submittedDateTo_OP.OracleDbType = OracleDbType.Varchar2;
                submittedDateTo_OP.Value = submittedDateTo;

                OracleParameter startDateFrom_OP = new OracleParameter();
                startDateFrom_OP.Direction = System.Data.ParameterDirection.Input;
                startDateFrom_OP.OracleDbType = OracleDbType.Varchar2;
                startDateFrom_OP.Value = startDateFrom;

                OracleParameter endDateTo_OP = new OracleParameter();
                endDateTo_OP.Direction = System.Data.ParameterDirection.Input;
                endDateTo_OP.OracleDbType = OracleDbType.Varchar2;
                endDateTo_OP.Value = endDateTo;

                OracleParameter parcentBetween_OP = new OracleParameter();
                parcentBetween_OP.Direction = System.Data.ParameterDirection.Input;
                parcentBetween_OP.OracleDbType = OracleDbType.Decimal;
                parcentBetween_OP.Value = parcentBetween;

                OracleParameter currentPage_OP = new OracleParameter();
                currentPage_OP.Direction = System.Data.ParameterDirection.Input;
                currentPage_OP.OracleDbType = OracleDbType.Decimal;
                currentPage_OP.Value = currentPage;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_TARGET_SETUPcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TARGET_SETUPcls>.GetDataBySP(new SP_GET_TARGET_SETUPcls(), "SP_GET_TARGET_SETUP_PAGING", 29,
                                    resultOutCurSor, target_Id_OP, comission_Id_OP, tyre_Id_OP, retailerID_OP,
                                    distributorID_OP, submittedDateFrom_OP, submittedDateTo_OP, startDateFrom_OP,
                                    endDateTo_OP, parcentBetween_OP, currentPage_OP);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_TARGET_SETUPcls> GetAllTargetSetup(decimal target_Id, decimal comission_Id, decimal tyre_Id, decimal retailerID, decimal distributorID, decimal productCategoryID)
        {
            try
            {
                OracleParameter target_Id_OP = new OracleParameter();
                target_Id_OP.Direction = System.Data.ParameterDirection.Input;
                target_Id_OP.OracleDbType = OracleDbType.Decimal;
                target_Id_OP.Value = target_Id;

                OracleParameter comission_Id_OP = new OracleParameter();
                comission_Id_OP.Direction = System.Data.ParameterDirection.Input;
                comission_Id_OP.OracleDbType = OracleDbType.Decimal;
                comission_Id_OP.Value = comission_Id;

                OracleParameter tyre_Id_OP = new OracleParameter();
                tyre_Id_OP.Direction = System.Data.ParameterDirection.Input;
                tyre_Id_OP.OracleDbType = OracleDbType.Decimal;
                tyre_Id_OP.Value = tyre_Id;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;


                OracleParameter productCategoryID_OP = new OracleParameter();
                productCategoryID_OP.Direction = System.Data.ParameterDirection.Input;
                productCategoryID_OP.OracleDbType = OracleDbType.Decimal;
                productCategoryID_OP.Value = productCategoryID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_TARGET_SETUPcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TARGET_SETUPcls>.GetDataBySP(new SP_GET_TARGET_SETUPcls(), "SP_GET_ALL_TARGET_SETUP", 29, resultOutCurSor, target_Id_OP, comission_Id_OP, tyre_Id_OP, retailerID_OP, distributorID_OP, productCategoryID_OP);

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
                OracleParameter targetItemID_OP = new OracleParameter();
                targetItemID_OP.Direction = System.Data.ParameterDirection.Input;
                targetItemID_OP.OracleDbType = OracleDbType.Decimal;
                targetItemID_OP.Value = targetItemID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_TARGET_ITEM>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TARGET_ITEM>.GetDataBySP(new SP_GET_TARGET_ITEM(), "SP_FF_GET_TARGET_ITEM", 4, resultOutCurSor, targetItemID_OP);
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
                OracleParameter targetPeriodID_OP = new OracleParameter();
                targetPeriodID_OP.Direction = System.Data.ParameterDirection.Input;
                targetPeriodID_OP.OracleDbType = OracleDbType.Decimal;
                targetPeriodID_OP.Value = targetPeriodID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_TARGET_PERIOD>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TARGET_PERIOD>.GetDataBySP(new SP_GET_TARGET_PERIOD(), "SP_FF_GET_TARGET_PERIOD", 2, resultOutCurSor, targetPeriodID_OP);
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
				OracleParameter targetPeriodID_OP = new OracleParameter();
				targetPeriodID_OP.Direction = System.Data.ParameterDirection.Input;
				targetPeriodID_OP.OracleDbType = OracleDbType.Decimal;
				targetPeriodID_OP.Value = targetPeriodID;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_TARGET_PERIOD>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TARGET_PERIOD>.GetDataBySP(new SP_GET_TARGET_PERIOD(), "SP_FF_GET_COMMISSION_PERIOD", 2, resultOutCurSor, targetPeriodID_OP);
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
                OracleParameter VisitTypeId_OP = new OracleParameter();
                VisitTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                VisitTypeId_OP.OracleDbType = OracleDbType.Decimal;
                VisitTypeId_OP.Value = VisitTypeId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_VISIT_TYPE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_VISIT_TYPE>.GetDataBySP(new SP_GET_VISIT_TYPE(), "SP_FF_GET_VISIT_TYPE", 2, resultOutCurSor, VisitTypeId_OP);
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
                OracleParameter CenterTypeId_OP = new OracleParameter();
                CenterTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                CenterTypeId_OP.OracleDbType = OracleDbType.Decimal;
                CenterTypeId_OP.Value = CenterTypeId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_CENTER_TYPE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_CENTER_TYPE>.GetDataBySP(new SP_GET_CENTER_TYPE(), "SP_FF_GET_CENTER_TYPE", 2, resultOutCurSor, CenterTypeId_OP);
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
                OracleParameter RoleId_OP = new OracleParameter();
                RoleId_OP.Direction = System.Data.ParameterDirection.Input;
                RoleId_OP.OracleDbType = OracleDbType.Decimal;
                RoleId_OP.Value = RoleId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_ROLES>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ROLES>.GetDataBySP(new SP_GET_ROLES(), "SP_FF_GET_ROLES", 2, resultOutCurSor, RoleId_OP);
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
                OracleParameter ChannelTypeId_OP = new OracleParameter();
                ChannelTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                ChannelTypeId_OP.OracleDbType = OracleDbType.Decimal;
                ChannelTypeId_OP.Value = ChannelTypeId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_CHANNEL_TYPE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_CHANNEL_TYPE>.GetDataBySP(new SP_GET_CHANNEL_TYPE(), "SP_FF_GET_CHANNEL_TYPE", 2, resultOutCurSor, ChannelTypeId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    
        public Decimal SaveUpdateDistributorTarget(decimal id,decimal targetItemId, decimal targetPeriod, decimal isActive, decimal createdByUserId, DateTime setDate)
        {
            try
            {
                OracleParameter id_OP = new OracleParameter();
                id_OP.Direction = System.Data.ParameterDirection.Input;
                id_OP.OracleDbType = OracleDbType.Decimal;
                id_OP.Value = id;

                OracleParameter targetItemId_OP = new OracleParameter();
                targetItemId_OP.Direction = System.Data.ParameterDirection.Input;
                targetItemId_OP.OracleDbType = OracleDbType.Decimal;
                targetItemId_OP.Value = targetItemId;

                OracleParameter targetPeriod_OP = new OracleParameter();
                targetPeriod_OP.Direction = System.Data.ParameterDirection.Input;
                targetPeriod_OP.OracleDbType = OracleDbType.Decimal;
                targetPeriod_OP.Value = targetPeriod;

                OracleParameter isActive_OP = new OracleParameter();
                isActive_OP.Direction = System.Data.ParameterDirection.Input;
                isActive_OP.OracleDbType = OracleDbType.Decimal;
                isActive_OP.Value = isActive;

                OracleParameter createdByUserId_OP = new OracleParameter();
                createdByUserId_OP.Direction = System.Data.ParameterDirection.Input;
                createdByUserId_OP.OracleDbType = OracleDbType.Decimal;
                createdByUserId_OP.Value = createdByUserId;

                OracleParameter setDateOP = new OracleParameter();
                setDateOP.Direction = System.Data.ParameterDirection.Input;
                setDateOP.OracleDbType = OracleDbType.Date;
                setDateOP.Value = setDate;

                OracleParameter resultOutRSOGpsAttendanceID = new OracleParameter();
                resultOutRSOGpsAttendanceID.Direction = System.Data.ParameterDirection.Output;
                resultOutRSOGpsAttendanceID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_TERGAT_FOR_DIST>.InsertDataBySP("SP_INS_UPD_TARGET_FOR_DIST", resultOutRSOGpsAttendanceID, id_OP, targetItemId_OP, targetPeriod_OP, setDateOP, createdByUserId_OP, isActive_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal UploadTargetDetail(decimal uploadCode, string monthCode, string itemCode, string applyId, decimal targetValue, decimal applyType, decimal log, decimal applySubType)
        {
            try
            {
                OracleParameter uploadCode_OP = new OracleParameter();
                uploadCode_OP.Direction = System.Data.ParameterDirection.Input;
                uploadCode_OP.OracleDbType = OracleDbType.Decimal;
                uploadCode_OP.Value = uploadCode;

                OracleParameter monthCode_OP = new OracleParameter();
                monthCode_OP.Direction = System.Data.ParameterDirection.Input;
                monthCode_OP.OracleDbType = OracleDbType.Varchar2;
                monthCode_OP.Value = monthCode;

                OracleParameter itemCode_OP = new OracleParameter();
                itemCode_OP.Direction = System.Data.ParameterDirection.Input;
                itemCode_OP.OracleDbType = OracleDbType.Varchar2;
                itemCode_OP.Value = itemCode;

                OracleParameter applyId_OP = new OracleParameter();
                applyId_OP.Direction = System.Data.ParameterDirection.Input;
                applyId_OP.OracleDbType = OracleDbType.Varchar2;
                applyId_OP.Value = applyId;

                OracleParameter targetValue_OP = new OracleParameter();
                targetValue_OP.Direction = System.Data.ParameterDirection.Input;
                targetValue_OP.OracleDbType = OracleDbType.Decimal;
                targetValue_OP.Value = targetValue;
                
                OracleParameter applyType_OP = new OracleParameter();
                applyType_OP.Direction = System.Data.ParameterDirection.Input;
                applyType_OP.OracleDbType = OracleDbType.Decimal;
                applyType_OP.Value = applyType;

                OracleParameter log_OP = new OracleParameter();
                log_OP.Direction = System.Data.ParameterDirection.Input;
                log_OP.OracleDbType = OracleDbType.Decimal;
                log_OP.Value = log;

                OracleParameter applySubType_OP = new OracleParameter();
                applySubType_OP.Direction = System.Data.ParameterDirection.Input;
                applySubType_OP.OracleDbType = OracleDbType.Decimal;
                applySubType_OP.Value = applySubType;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_TERGAT_FOR_DIST>.InsertDataBySP("SP_FF_INS_TARGET_DETAIL_TEMP", resultOutID, uploadCode_OP, monthCode_OP, itemCode_OP, applyId_OP, targetValue_OP, applyType_OP, log_OP, applySubType_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateTarget(decimal id, decimal TargetForId, decimal StaffRoleId, string targetItemCode, string targetPeriodCode, decimal uploadCode, DateTime setDate, decimal createdBy, decimal Version, DateTime RevisionUpTo)
        {
            try
            {
                OracleParameter id_OP = new OracleParameter();
                id_OP.Direction = System.Data.ParameterDirection.Input;
                id_OP.OracleDbType = OracleDbType.Decimal;
                id_OP.Value = id;

                OracleParameter TargetForId_OP = new OracleParameter();
                TargetForId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetForId_OP.OracleDbType = OracleDbType.Decimal;
                TargetForId_OP.Value = TargetForId;

                OracleParameter StaffRoleId_OP = new OracleParameter();
                StaffRoleId_OP.Direction = System.Data.ParameterDirection.Input;
                StaffRoleId_OP.OracleDbType = OracleDbType.Decimal;
                StaffRoleId_OP.Value = StaffRoleId;

                OracleParameter targetItemCode_OP = new OracleParameter();
                targetItemCode_OP.Direction = System.Data.ParameterDirection.Input;
                targetItemCode_OP.OracleDbType = OracleDbType.Varchar2;
                targetItemCode_OP.Value = targetItemCode;

                OracleParameter targetPeriodCode_OP = new OracleParameter();
                targetPeriodCode_OP.Direction = System.Data.ParameterDirection.Input;
                targetPeriodCode_OP.OracleDbType = OracleDbType.Varchar2;
                targetPeriodCode_OP.Value = targetPeriodCode;

                OracleParameter uploadCode_OP = new OracleParameter();
                uploadCode_OP.Direction = System.Data.ParameterDirection.Input;
                uploadCode_OP.OracleDbType = OracleDbType.Decimal;
                uploadCode_OP.Value = uploadCode;

                OracleParameter setDate_OP = new OracleParameter();
                setDate_OP.Direction = System.Data.ParameterDirection.Input;
                setDate_OP.OracleDbType = OracleDbType.Date;
                setDate_OP.Value = setDate;

                OracleParameter createdBy_OP = new OracleParameter();
                createdBy_OP.Direction = System.Data.ParameterDirection.Input;
                createdBy_OP.OracleDbType = OracleDbType.Decimal;
                createdBy_OP.Value = createdBy;

                OracleParameter Version_OP = new OracleParameter();
                Version_OP.Direction = System.Data.ParameterDirection.Input;
                Version_OP.OracleDbType = OracleDbType.Decimal;
                Version_OP.Value = Version;

                OracleParameter RevisionUpTo_OP = new OracleParameter();
                RevisionUpTo_OP.Direction = System.Data.ParameterDirection.Input;
                RevisionUpTo_OP.OracleDbType = OracleDbType.Date;
                RevisionUpTo_OP.Value = RevisionUpTo;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_CURRENT_OFFERcls>.InsertDataBySP("SP_FF_INS_UPD_TARGET_DETAIL", resultOutID, id_OP, TargetForId_OP, StaffRoleId_OP, targetItemCode_OP, targetPeriodCode_OP, uploadCode_OP ,setDate_OP, createdBy_OP, Version_OP, RevisionUpTo_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateTargetRevise(decimal Id, decimal TargetId, decimal createdBy)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter TargetId_OP = new OracleParameter();
                TargetId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetId_OP.OracleDbType = OracleDbType.Decimal;
                TargetId_OP.Value = TargetId;

                OracleParameter createdBy_OP = new OracleParameter();
                createdBy_OP.Direction = System.Data.ParameterDirection.Input;
                createdBy_OP.OracleDbType = OracleDbType.Decimal;
                createdBy_OP.Value = createdBy;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_CURRENT_OFFERcls>.InsertDataBySP("SP_FF_IN_UP_TARGET_MODIFY_DIST", resultOutID, Id_OP, TargetId_OP, createdBy_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateTargetReviseDetail(decimal Id, decimal TargetId, decimal TargetDetailId, decimal Version, decimal TargetValue, decimal RevisedTargetValue, decimal ModifyRequestId, string Comments)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter TargetId_OP = new OracleParameter();
                TargetId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetId_OP.OracleDbType = OracleDbType.Decimal;
                TargetId_OP.Value = TargetId;

                OracleParameter TargetDetailId_OP = new OracleParameter();
                TargetDetailId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetDetailId_OP.OracleDbType = OracleDbType.Decimal;
                TargetDetailId_OP.Value = TargetDetailId;

                OracleParameter Version_OP = new OracleParameter();
                Version_OP.Direction = System.Data.ParameterDirection.Input;
                Version_OP.OracleDbType = OracleDbType.Decimal;
                Version_OP.Value = Version;

                OracleParameter TargetValue_OP = new OracleParameter();
                TargetValue_OP.Direction = System.Data.ParameterDirection.Input;
                TargetValue_OP.OracleDbType = OracleDbType.Decimal;
                TargetValue_OP.Value = TargetValue;

                OracleParameter RevisedTargetValue_OP = new OracleParameter();
                RevisedTargetValue_OP.Direction = System.Data.ParameterDirection.Input;
                RevisedTargetValue_OP.OracleDbType = OracleDbType.Decimal;
                RevisedTargetValue_OP.Value = RevisedTargetValue;

                OracleParameter ModifyRequestId_OP = new OracleParameter();
                ModifyRequestId_OP.Direction = System.Data.ParameterDirection.Input;
                ModifyRequestId_OP.OracleDbType = OracleDbType.Decimal;
                ModifyRequestId_OP.Value = ModifyRequestId;

                OracleParameter Comments_OP = new OracleParameter();
                Comments_OP.Direction = System.Data.ParameterDirection.Input;
                Comments_OP.OracleDbType = OracleDbType.Varchar2;
                Comments_OP.Value = Comments;
              
                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_CURRENT_OFFERcls>.InsertDataBySP("SP_FF_INS_TARGET_MDFY_DIST_DTL", resultOutID, Id_OP, TargetId_OP, TargetDetailId_OP, Version_OP, TargetValue_OP, RevisedTargetValue_OP, ModifyRequestId_OP, Comments_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveStaffTargetModifyMaster(decimal Id, decimal UserId, decimal TargetId, decimal Version)
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

                OracleParameter TargetId_OP = new OracleParameter();
                TargetId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetId_OP.OracleDbType = OracleDbType.Decimal;
                TargetId_OP.Value = TargetId;

                OracleParameter Version_OP = new OracleParameter();
                Version_OP.Direction = System.Data.ParameterDirection.Input;
                Version_OP.OracleDbType = OracleDbType.Decimal;
                Version_OP.Value = Version;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_STAFF_TARGET_MODIFY", resultOutID, Id_OP, UserId_OP, TargetId_OP, Version_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveStaffTargetModifyeDetail(decimal Id, decimal TargetId, decimal TargetDetailId, decimal RevisedTargetValue, decimal ModifyRequestId, string Comments)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter TargetId_OP = new OracleParameter();
                TargetId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetId_OP.OracleDbType = OracleDbType.Decimal;
                TargetId_OP.Value = TargetId;

                OracleParameter TargetDetailId_OP = new OracleParameter();
                TargetDetailId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetDetailId_OP.OracleDbType = OracleDbType.Decimal;
                TargetDetailId_OP.Value = TargetDetailId;

                OracleParameter RevisedTargetValue_OP = new OracleParameter();
                RevisedTargetValue_OP.Direction = System.Data.ParameterDirection.Input;
                RevisedTargetValue_OP.OracleDbType = OracleDbType.Decimal;
                RevisedTargetValue_OP.Value = RevisedTargetValue;

                OracleParameter ModifyRequestId_OP = new OracleParameter();
                ModifyRequestId_OP.Direction = System.Data.ParameterDirection.Input;
                ModifyRequestId_OP.OracleDbType = OracleDbType.Decimal;
                ModifyRequestId_OP.Value = ModifyRequestId;

                OracleParameter Comments_OP = new OracleParameter();
                Comments_OP.Direction = System.Data.ParameterDirection.Input;
                Comments_OP.OracleDbType = OracleDbType.Varchar2;
                Comments_OP.Value = Comments;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_CURRENT_OFFERcls>.InsertDataBySP("SP_FF_IN_STAFF_TARGET_MDFY_DTL", resultOutID, Id_OP, TargetId_OP, TargetDetailId_OP, RevisedTargetValue_OP, ModifyRequestId_OP, Comments_OP);
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
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_TARGET_SETUP>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TARGET_SETUP>.GetDataBySP(new SP_GET_TARGET_SETUP(), "SP_FF_GET_TARGET", 12, resultOutCurSor);
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
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_DISTRIBUTOR_UP_TARGET>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_DISTRIBUTOR_UP_TARGET>.GetDataBySP(new SP_GET_DISTRIBUTOR_UP_TARGET(), "SP_FF_GET_DISTRIBUTOR_TARGET", 11, resultOutCurSor);
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
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter Version_OP = new OracleParameter();
                Version_OP.Direction = System.Data.ParameterDirection.Input;
                Version_OP.OracleDbType = OracleDbType.Decimal;
                Version_OP.Value = Version;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_STAFF_TARGET>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_STAFF_TARGET>.GetDataBySP(new SP_GET_STAFF_TARGET(), "SP_FF_GET_STAFF_TARGET", 10, resultOutCurSor, UserId_OP, Version_OP);
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
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter Version_OP = new OracleParameter();
                Version_OP.Direction = System.Data.ParameterDirection.Input;
                Version_OP.OracleDbType = OracleDbType.Decimal;
                Version_OP.Value = Version;

                OracleParameter UserType_OP = new OracleParameter();
                UserType_OP.Direction = System.Data.ParameterDirection.Input;
                UserType_OP.OracleDbType = OracleDbType.Decimal;
                UserType_OP.Value = UserType;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_STAFF_TARGET>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_STAFF_TARGET>.GetDataBySP(new SP_GET_STAFF_TARGET(), "SP_FF_GET_STAFF_TRGT_FOR_APRV", 10, resultOutCurSor, UserId_OP, Version_OP, UserType_OP);
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
                OracleParameter TargetForId_OP = new OracleParameter();
                TargetForId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetForId_OP.OracleDbType = OracleDbType.Varchar2;
                TargetForId_OP.Value = TargetForId;

                OracleParameter StaffTypeId_OP = new OracleParameter();
                StaffTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                StaffTypeId_OP.OracleDbType = OracleDbType.Varchar2;
                StaffTypeId_OP.Value = StaffTypeId;

                OracleParameter TargetForCode_OP = new OracleParameter();
                TargetForCode_OP.Direction = System.Data.ParameterDirection.Input;
                TargetForCode_OP.OracleDbType = OracleDbType.Varchar2;
                TargetForCode_OP.Value = TargetForCode;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_IS_VALID_TARGET_FOR>)ObjectMakerFromOracleSP.OracleHelper<GET_IS_VALID_TARGET_FOR>.GetDataBySP(new GET_IS_VALID_TARGET_FOR(), "SP_FF_GET_IS_VALID_TARGET_FOR", 1, resultOutCurSor, TargetForId_OP, StaffTypeId_OP, TargetForCode_OP);
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
                OracleParameter TargetId_OP = new OracleParameter();
                TargetId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetId_OP.OracleDbType = OracleDbType.Decimal;
                TargetId_OP.Value = TargetId;

                OracleParameter Version_OP = new OracleParameter();
                Version_OP.Direction = System.Data.ParameterDirection.Input;
                Version_OP.OracleDbType = OracleDbType.Decimal;
                Version_OP.Value = Version;


                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_STAFF_TARGET_DETAIL>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_STAFF_TARGET_DETAIL>.GetDataBySP(new SP_GET_STAFF_TARGET_DETAIL(), "SP_FF_GET_STF_TRGT_DETAIL_APRV", 7, resultOutCurSor, TargetId_OP, Version_OP);
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
                OracleParameter TargetId_OP = new OracleParameter();
                TargetId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetId_OP.OracleDbType = OracleDbType.Decimal;
                TargetId_OP.Value = TargetId;

                OracleParameter Version_OP = new OracleParameter();
                Version_OP.Direction = System.Data.ParameterDirection.Input;
                Version_OP.OracleDbType = OracleDbType.Decimal;
                Version_OP.Value = Version;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_STAFF_TARGET_DETAIL>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_STAFF_TARGET_DETAIL>.GetDataBySP(new SP_GET_STAFF_TARGET_DETAIL(), "SP_FF_GET_STAFF_TARGET_DETAIL", 7, resultOutCurSor, TargetId_OP, Version_OP, UserId_OP);
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
                OracleParameter TargetId_OP = new OracleParameter();
                TargetId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetId_OP.OracleDbType = OracleDbType.Decimal;
                TargetId_OP.Value = TargetId;

                OracleParameter Version_OP = new OracleParameter();
                Version_OP.Direction = System.Data.ParameterDirection.Input;
                Version_OP.OracleDbType = OracleDbType.Decimal;
                Version_OP.Value = Version;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_STAFF_TARGET_DETAIL>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_STAFF_TARGET_DETAIL>.GetDataBySP(new SP_GET_STAFF_TARGET_DETAIL(), "SP_FF_GET_STAFF_REQ_TARGET_DTL", 7, resultOutCurSor, TargetId_OP, Version_OP);
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

                return (List<SP_GET_DISTRIBUTOR_TARGET>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_DISTRIBUTOR_TARGET>.GetDataBySP(new SP_GET_DISTRIBUTOR_TARGET(), "SP_FF_GET_TARGET_RVISE_DIST", 18, resultOutCurSor, Id_OP, UserId_OP);
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
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter UserType_OP = new OracleParameter();
                UserType_OP.Direction = System.Data.ParameterDirection.Input;
                UserType_OP.OracleDbType = OracleDbType.Decimal;
                UserType_OP.Value = UserType;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_DISTRIBUTOR_TARGET>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_DISTRIBUTOR_TARGET>.GetDataBySP(new SP_GET_DISTRIBUTOR_TARGET(), "SP_FF_GET_APRV_TRGT_RVISE_DIST", 17, resultOutCurSor, Id_OP, UserId_OP, UserType_OP);
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
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter Version_OP = new OracleParameter();
                Version_OP.Direction = System.Data.ParameterDirection.Input;
                Version_OP.OracleDbType = OracleDbType.Decimal;
                Version_OP.Value = Version;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_DISTRIBUTOR_TARGET>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_DISTRIBUTOR_TARGET>.GetDataBySP(new SP_GET_DISTRIBUTOR_TARGET(), "SP_FF_GET_TARGET_DETAIL_DIST", 17, resultOutCurSor, Id_OP, UserId_OP, Version_OP);
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
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter Version_OP = new OracleParameter();
                Version_OP.Direction = System.Data.ParameterDirection.Input;
                Version_OP.OracleDbType = OracleDbType.Decimal;
                Version_OP.Value = Version;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_DISTRIBUTOR_TARGET>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_DISTRIBUTOR_TARGET>.GetDataBySP(new SP_GET_DISTRIBUTOR_TARGET(), "SP_FF_GET_TRGT_DTL_DIST_MOD", 18, resultOutCurSor, Id_OP, UserId_OP, Version_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal ApproveDistributorTargetRevise(decimal TargetId, decimal Version, decimal ActionType, string ApproverComment, decimal UserId, decimal? UserType)
        {
            try
            {
                OracleParameter TargetId_OP = new OracleParameter();
                TargetId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetId_OP.OracleDbType = OracleDbType.Decimal;
                TargetId_OP.Value = TargetId;

                OracleParameter Version_OP = new OracleParameter();
                Version_OP.Direction = System.Data.ParameterDirection.Input;
                Version_OP.OracleDbType = OracleDbType.Decimal;
                Version_OP.Value = Version;

                OracleParameter ActionType_OP = new OracleParameter();
                ActionType_OP.Direction = System.Data.ParameterDirection.Input;
                ActionType_OP.OracleDbType = OracleDbType.Decimal;
                ActionType_OP.Value = ActionType;

                OracleParameter ApproverComment_OP = new OracleParameter();
                ApproverComment_OP.Direction = System.Data.ParameterDirection.Input;
                ApproverComment_OP.OracleDbType = OracleDbType.Varchar2;
                ApproverComment_OP.Value = ApproverComment;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter UserType_OP = new OracleParameter();
                UserType_OP.Direction = System.Data.ParameterDirection.Input;
                UserType_OP.OracleDbType = OracleDbType.Decimal;
                UserType_OP.Value = UserType;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_DIST_REVISE_REQ_APRVE", resultOutID, TargetId_OP, Version_OP, ActionType_OP, ApproverComment_OP, UserId_OP, UserType_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal ApproveStaffTargetRevise(decimal TargetId, decimal Version, decimal ActionType, string ApproverComment, decimal UserId, decimal? UserType)
        {
            try
            {
                OracleParameter TargetId_OP = new OracleParameter();
                TargetId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetId_OP.OracleDbType = OracleDbType.Decimal;
                TargetId_OP.Value = TargetId;

                OracleParameter Version_OP = new OracleParameter();
                Version_OP.Direction = System.Data.ParameterDirection.Input;
                Version_OP.OracleDbType = OracleDbType.Decimal;
                Version_OP.Value = Version;

                OracleParameter ActionType_OP = new OracleParameter();
                ActionType_OP.Direction = System.Data.ParameterDirection.Input;
                ActionType_OP.OracleDbType = OracleDbType.Decimal;
                ActionType_OP.Value = ActionType;

                OracleParameter ApproverComment_OP = new OracleParameter();
                ApproverComment_OP.Direction = System.Data.ParameterDirection.Input;
                ApproverComment_OP.OracleDbType = OracleDbType.Varchar2;
                ApproverComment_OP.Value = ApproverComment;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter UserType_OP = new OracleParameter();
                UserType_OP.Direction = System.Data.ParameterDirection.Input;
                UserType_OP.OracleDbType = OracleDbType.Decimal;
                UserType_OP.Value = UserType;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_IN_STF_REVISE_REQ_APRVE", resultOutID, TargetId_OP, Version_OP, ActionType_OP, ApproverComment_OP, UserId_OP, UserType_OP);
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
                OracleParameter uploadCode_OP = new OracleParameter();
                uploadCode_OP.Direction = System.Data.ParameterDirection.Input;
                uploadCode_OP.OracleDbType = OracleDbType.Decimal;
                uploadCode_OP.Value = uploadCode;

                OracleParameter applyType_OP = new OracleParameter();
                applyType_OP.Direction = System.Data.ParameterDirection.Input;
                applyType_OP.OracleDbType = OracleDbType.Decimal;
                applyType_OP.Value = applyType;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_DISTRIBUTOR_TARGET_FILE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_DISTRIBUTOR_TARGET_FILE>.GetDataBySP(new SP_GET_DISTRIBUTOR_TARGET_FILE(), "SP_FF_GET_TARGET_DETAIL_TEMP", 19, resultOutCurSor, uploadCode_OP, applyType_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_TARGET_FILE> GetTargetTemplate(Decimal TargetPeriodId, Decimal TargetItemId, Decimal TargetFor, Decimal StaffTypeId)
        {
            try
            {
                OracleParameter TargetPeriodId_OP = new OracleParameter();
                TargetPeriodId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetPeriodId_OP.OracleDbType = OracleDbType.Decimal;
                TargetPeriodId_OP.Value = TargetPeriodId;

                OracleParameter TargetItemId_OP = new OracleParameter();
                TargetItemId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetItemId_OP.OracleDbType = OracleDbType.Decimal;
                TargetItemId_OP.Value = TargetItemId;

                OracleParameter TargetFor_OP = new OracleParameter();
                TargetFor_OP.Direction = System.Data.ParameterDirection.Input;
                TargetFor_OP.OracleDbType = OracleDbType.Decimal;
                TargetFor_OP.Value = TargetFor;

                OracleParameter StaffTypeId_OP = new OracleParameter();
                StaffTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                StaffTypeId_OP.OracleDbType = OracleDbType.Decimal;
                StaffTypeId_OP.Value = StaffTypeId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_TARGET_FILE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TARGET_FILE>.GetDataBySP(new SP_GET_TARGET_FILE(), "SP_FF_GET_TARGET_TEMPLATE", 19, resultOutCurSor, TargetPeriodId_OP, TargetItemId_OP, TargetFor_OP, StaffTypeId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_TARGET_FILE> GetUploadedTarget(Decimal TargetPeriodId, Decimal TargetItemId, Decimal TargetFor, Decimal StaffTypeId, Decimal IsInitialVersion)
        {
            try
            {
                OracleParameter TargetPeriodId_OP = new OracleParameter();
                TargetPeriodId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetPeriodId_OP.OracleDbType = OracleDbType.Decimal;
                TargetPeriodId_OP.Value = TargetPeriodId;

                OracleParameter TargetItemId_OP = new OracleParameter();
                TargetItemId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetItemId_OP.OracleDbType = OracleDbType.Decimal;
                TargetItemId_OP.Value = TargetItemId;

                OracleParameter TargetFor_OP = new OracleParameter();
                TargetFor_OP.Direction = System.Data.ParameterDirection.Input;
                TargetFor_OP.OracleDbType = OracleDbType.Decimal;
                TargetFor_OP.Value = TargetFor;

                OracleParameter StaffTypeId_OP = new OracleParameter();
                StaffTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                StaffTypeId_OP.OracleDbType = OracleDbType.Decimal;
                StaffTypeId_OP.Value = StaffTypeId;

                OracleParameter IsInitialVersion_OP = new OracleParameter();
                IsInitialVersion_OP.Direction = System.Data.ParameterDirection.Input;
                IsInitialVersion_OP.OracleDbType = OracleDbType.Decimal;
                IsInitialVersion_OP.Value = IsInitialVersion;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_TARGET_FILE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TARGET_FILE>.GetDataBySP(new SP_GET_TARGET_FILE(), "SP_FF_GET_UPLOADED_TARGET", 19, resultOutCurSor, TargetPeriodId_OP, TargetItemId_OP, TargetFor_OP, StaffTypeId_OP, IsInitialVersion_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



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


		public List<SP_GET_TARGET_PERIOD> GetTargetPeriodEarning(Decimal type)
		{
			try
			{
				OracleParameter targetPeriodID_OP = new OracleParameter();
				targetPeriodID_OP.Direction = System.Data.ParameterDirection.Input;
				targetPeriodID_OP.OracleDbType = OracleDbType.Decimal;
				targetPeriodID_OP.Value = type;

				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_GET_TARGET_PERIOD>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TARGET_PERIOD>.GetDataBySP(new SP_GET_TARGET_PERIOD(), "SP_FF_GET_COMMISSION_PERIOD", 2, resultOutCurSor, targetPeriodID_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
