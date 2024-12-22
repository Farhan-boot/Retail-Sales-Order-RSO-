using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class NationalTargetSetupDZ
    {
        public NationalTargetSetupDZ(){}
       
        #region Save Methods

        /// <summary>
        /// Save or update national target setup. It is prepared from commission group of member wise target setup value. 
        /// </summary>
        /// <param name="nationalTargetSetupId"></param>
        /// <param name="commissionGroupId"></param>
        /// <param name="comGrpMemMapId"></param>
        /// <param name="setupName"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="MonthDate"></param>
        /// <param name="freezeDate"></param>
        /// <param name="marketingTarget"></param>
        /// <param name="increasePer"></param>
        /// <param name="salesTarget"></param>
        /// <param name="targetUnitID"></param>
        /// <param name="minDecreasePer"></param>
        /// <param name="maxExtendPer"></param>
        /// <param name="minThresholdPer"></param>
        /// <param name="maxThresholdPer"></param>
        /// <param name="isReusable"></param>
        /// <param name="createBy"></param>
        /// <param name="createDate"></param>
        /// <param name="updateBy"></param>
        /// <param name="updateDate"></param>
        /// <returns>nationalTargetSetupId</returns>
        public Decimal Save(decimal nationalTargetSetupId, decimal commissionGroupId, decimal comGrpMemMapId, string setupName, DateTime startDate, DateTime endDate, 
            DateTime MonthDate, DateTime freezeDate, decimal marketingTarget, decimal increasePer, decimal salesTarget, decimal targetUnitID,
            decimal minDecreasePer, decimal maxExtendPer, decimal minThresholdPer, decimal maxThresholdPer, decimal isReusable,
            decimal createBy, DateTime createDate, decimal updateBy, DateTime updateDate)
        {
            try
            {
                OracleParameter nationalTargetSetupIdOP = new OracleParameter();
                nationalTargetSetupIdOP.Direction = System.Data.ParameterDirection.Input;
                nationalTargetSetupIdOP.OracleDbType = OracleDbType.Decimal;
                nationalTargetSetupIdOP.Value = nationalTargetSetupId;

                OracleParameter commissionGroupIdOP = new OracleParameter();
                commissionGroupIdOP.Direction = System.Data.ParameterDirection.Input;
                commissionGroupIdOP.OracleDbType = OracleDbType.Decimal;
                commissionGroupIdOP.Value = commissionGroupId;

                OracleParameter comGrpMemMapIdOP = new OracleParameter();
                comGrpMemMapIdOP.Direction = System.Data.ParameterDirection.Input;
                comGrpMemMapIdOP.OracleDbType = OracleDbType.Decimal;
                comGrpMemMapIdOP.Value = comGrpMemMapId;

                OracleParameter setupNameOP = new OracleParameter();
                setupNameOP.Direction = System.Data.ParameterDirection.Input;
                setupNameOP.OracleDbType = OracleDbType.Varchar2;
                setupNameOP.Value = setupName;                

                OracleParameter startDateOP = new OracleParameter();
                startDateOP.Direction = System.Data.ParameterDirection.Input;
                startDateOP.OracleDbType = OracleDbType.Varchar2;
                startDateOP.Value = startDate.ToString("dd-MMM-yyyy");

                OracleParameter endDateOP = new OracleParameter();
                endDateOP.Direction = System.Data.ParameterDirection.Input;
                endDateOP.OracleDbType = OracleDbType.Varchar2;
                endDateOP.Value = endDate.ToString("dd-MMM-yyyy");

                OracleParameter MonthDateOP = new OracleParameter();
                MonthDateOP.Direction = System.Data.ParameterDirection.Input;
                MonthDateOP.OracleDbType = OracleDbType.Varchar2;
                MonthDateOP.Value = MonthDate.ToString("dd-MMM-yyyy");

                OracleParameter freezeDateOP = new OracleParameter();
                freezeDateOP.Direction = System.Data.ParameterDirection.Input;
                freezeDateOP.OracleDbType = OracleDbType.Varchar2;
                freezeDateOP.Value = freezeDate.ToString("dd-MMM-yyyy");            

                OracleParameter marketingTargetOP = new OracleParameter();
                marketingTargetOP.Direction = System.Data.ParameterDirection.Input;
                marketingTargetOP.OracleDbType = OracleDbType.Decimal;
                marketingTargetOP.Value = marketingTarget;
                              
                OracleParameter increasePerOP = new OracleParameter();
                increasePerOP.Direction = System.Data.ParameterDirection.Input;
                increasePerOP.OracleDbType = OracleDbType.Decimal;
                increasePerOP.Value = increasePer;

                OracleParameter salesTargetOP = new OracleParameter();
                salesTargetOP.Direction = System.Data.ParameterDirection.Input;
                salesTargetOP.OracleDbType = OracleDbType.Decimal;
                salesTargetOP.Value = salesTarget;

                OracleParameter targetUnitIDOP = new OracleParameter();
                targetUnitIDOP.Direction = System.Data.ParameterDirection.Input;
                targetUnitIDOP.OracleDbType = OracleDbType.Decimal;
                targetUnitIDOP.Value = targetUnitID;
                
                OracleParameter minDecreasePerOP = new OracleParameter();
                minDecreasePerOP.Direction = System.Data.ParameterDirection.Input;
                minDecreasePerOP.OracleDbType = OracleDbType.Decimal;
                minDecreasePerOP.Value = minDecreasePer;

                OracleParameter maxExtendPerOP = new OracleParameter();
                maxExtendPerOP.Direction = System.Data.ParameterDirection.Input;
                maxExtendPerOP.OracleDbType = OracleDbType.Decimal;
                maxExtendPerOP.Value = maxExtendPer;

                OracleParameter minThresholdPerOP = new OracleParameter();
                minThresholdPerOP.Direction = System.Data.ParameterDirection.Input;
                minThresholdPerOP.OracleDbType = OracleDbType.Decimal;
                minThresholdPerOP.Value = minThresholdPer;

                OracleParameter maxThresholdPerOP = new OracleParameter();
                maxThresholdPerOP.Direction = System.Data.ParameterDirection.Input;
                maxThresholdPerOP.OracleDbType = OracleDbType.Decimal;
                maxThresholdPerOP.Value = maxThresholdPer;

                OracleParameter isReusableOP = new OracleParameter();
                isReusableOP.Direction = System.Data.ParameterDirection.Input;
                isReusableOP.OracleDbType = OracleDbType.Decimal;
                isReusableOP.Value = isReusable;

                OracleParameter createBy_OP = new OracleParameter();
                createBy_OP.Direction = System.Data.ParameterDirection.Input;
                createBy_OP.OracleDbType = OracleDbType.Decimal;
                createBy_OP.Value = createBy;

                OracleParameter createDate_OP = new OracleParameter();
                createDate_OP.Direction = System.Data.ParameterDirection.Input;
                createDate_OP.OracleDbType = OracleDbType.Varchar2;
                createDate_OP.Value = createDate.ToString("dd-MMM-yyyy");

                OracleParameter updateBy_OP = new OracleParameter();
                updateBy_OP.Direction = System.Data.ParameterDirection.Input;
                updateBy_OP.OracleDbType = OracleDbType.Decimal;
                updateBy_OP.Value = updateBy;

                OracleParameter updateDate_OP = new OracleParameter();
                updateDate_OP.Direction = System.Data.ParameterDirection.Input;
                updateDate_OP.OracleDbType = OracleDbType.Varchar2;
                updateDate_OP.Value = updateDate.ToString("dd-MMM-yyyy");

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_NATIONAL_TARGET_SETUP_PARENT_AND_DETAILcls>.InsertDataBySP("SP_IU_NATIONAL_TARGET_SETUP", resultOutID,
                     nationalTargetSetupIdOP,  commissionGroupIdOP,  comGrpMemMapIdOP,  setupNameOP, 
             startDateOP,  endDateOP,  MonthDateOP,  freezeDateOP,  marketingTargetOP,  increasePerOP,  salesTargetOP, targetUnitIDOP,
             minDecreasePerOP,  maxExtendPerOP,  minThresholdPerOP,  maxThresholdPerOP,  isReusableOP,
             createBy_OP,  createDate_OP,  updateBy_OP,  updateDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Save or update national target setup. It is prepared from commission group of member wise target setup value. 
        /// </summary>
        /// <param name="nationalTargetSetupId"></param>
        /// <param name="commissionGroupId"></param>
        /// <param name="setupName"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="MonthDate"></param>
        /// <param name="freezeDate"></param>
        /// <param name="isReusable"></param>
        /// <param name="createBy"></param>
        /// <param name="createDate"></param>
        /// <param name="updateBy"></param>
        /// <param name="updateDate"></param>
        /// <returns>NationalTargetSetupId</returns>
        public Decimal SaveParent(decimal nationalTargetSetupId, decimal commissionGroupId,  string setupName, DateTime startDate, DateTime endDate,
          DateTime MonthDate, DateTime freezeDate,  decimal isReusable, decimal createBy, DateTime createDate, decimal updateBy, DateTime updateDate)
        {
            try
            {
                OracleParameter nationalTargetSetupIdOP = new OracleParameter();
                nationalTargetSetupIdOP.Direction = System.Data.ParameterDirection.Input;
                nationalTargetSetupIdOP.OracleDbType = OracleDbType.Decimal;
                nationalTargetSetupIdOP.Value = nationalTargetSetupId;

                OracleParameter commissionGroupIdOP = new OracleParameter();
                commissionGroupIdOP.Direction = System.Data.ParameterDirection.Input;
                commissionGroupIdOP.OracleDbType = OracleDbType.Decimal;
                commissionGroupIdOP.Value = commissionGroupId;

                OracleParameter setupNameOP = new OracleParameter();
                setupNameOP.Direction = System.Data.ParameterDirection.Input;
                setupNameOP.OracleDbType = OracleDbType.Varchar2;
                setupNameOP.Value = setupName;

                OracleParameter startDateOP = new OracleParameter();
                startDateOP.Direction = System.Data.ParameterDirection.Input;
                startDateOP.OracleDbType = OracleDbType.Varchar2;
                startDateOP.Value = startDate.ToString("dd-MMM-yyyy");

                OracleParameter endDateOP = new OracleParameter();
                endDateOP.Direction = System.Data.ParameterDirection.Input;
                endDateOP.OracleDbType = OracleDbType.Varchar2;
                endDateOP.Value = endDate.ToString("dd-MMM-yyyy");

                OracleParameter MonthDateOP = new OracleParameter();
                MonthDateOP.Direction = System.Data.ParameterDirection.Input;
                MonthDateOP.OracleDbType = OracleDbType.Varchar2;
                MonthDateOP.Value = MonthDate.ToString("dd-MMM-yyyy");

                OracleParameter freezeDateOP = new OracleParameter();
                freezeDateOP.Direction = System.Data.ParameterDirection.Input;
                freezeDateOP.OracleDbType = OracleDbType.Varchar2;
                freezeDateOP.Value = freezeDate.ToString("dd-MMM-yyyy");                

                OracleParameter isReusableOP = new OracleParameter();
                isReusableOP.Direction = System.Data.ParameterDirection.Input;
                isReusableOP.OracleDbType = OracleDbType.Decimal;
                isReusableOP.Value = isReusable;

                OracleParameter createBy_OP = new OracleParameter();
                createBy_OP.Direction = System.Data.ParameterDirection.Input;
                createBy_OP.OracleDbType = OracleDbType.Decimal;
                createBy_OP.Value = createBy;

                OracleParameter createDate_OP = new OracleParameter();
                createDate_OP.Direction = System.Data.ParameterDirection.Input;
                createDate_OP.OracleDbType = OracleDbType.Varchar2;
                createDate_OP.Value = createDate.ToString("dd-MMM-yyyy");

                OracleParameter updateBy_OP = new OracleParameter();
                updateBy_OP.Direction = System.Data.ParameterDirection.Input;
                updateBy_OP.OracleDbType = OracleDbType.Decimal;
                updateBy_OP.Value = updateBy;

                OracleParameter updateDate_OP = new OracleParameter();
                updateDate_OP.Direction = System.Data.ParameterDirection.Input;
                updateDate_OP.OracleDbType = OracleDbType.Varchar2;
                updateDate_OP.Value = updateDate.ToString("dd-MMM-yyyy");

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_NATIONAL_TARGET_SETUP_PARENT_AND_DETAILcls>.InsertDataBySP("SP_IU_NATIONAL_TARGET_SETUP", resultOutID,
                     nationalTargetSetupIdOP, commissionGroupIdOP, setupNameOP, startDateOP, endDateOP, MonthDateOP, freezeDateOP, isReusableOP, createBy_OP, 
                     createDate_OP, updateBy_OP, updateDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save or update national target setup detail (child). It is prepared from commission group of member wise target setup value. 
        /// </summary>
        /// <param name="nationalTargetSetupDetailId">Must have value nationalTargetSetupId</param>
        /// <param name="nationalTargetSetupId"></param>
        /// <param name="comGrpMemMapId"></param>
        /// <param name="marketingTarget"></param>
        /// <param name="increasePer"></param>
        /// <param name="salesTarget"></param>
        /// <param name="targetUnitID"></param>
        /// <param name="minDecreasePer"></param>
        /// <param name="maxExtendPer"></param>
        /// <param name="minThresholdPer"></param>
        /// <param name="maxThresholdPer"></param>
        /// <param name="createBy"></param>
        /// <param name="createDate"></param>
        /// <param name="updateBy"></param>
        /// <param name="updateDate"></param>
        /// <returns>NationalTargetSetupDetailId</returns>
        public Decimal SaveChild(decimal nationalTargetSetupDetailId,  decimal nationalTargetSetupId, decimal comGrpMemMapId, decimal marketingTarget, 
            decimal increasePer, decimal salesTarget, decimal targetUnitID, decimal minDecreasePer, decimal maxExtendPer, decimal minThresholdPer, 
            decimal maxThresholdPer, decimal createBy, DateTime createDate, decimal updateBy, DateTime updateDate)
        {
            try
            {
                OracleParameter nationalTargetSetupDetailIdOP = new OracleParameter();
                nationalTargetSetupDetailIdOP.Direction = System.Data.ParameterDirection.Input;
                nationalTargetSetupDetailIdOP.OracleDbType = OracleDbType.Decimal;
                nationalTargetSetupDetailIdOP.Value = nationalTargetSetupDetailId;

                OracleParameter nationalTargetSetupIdOP = new OracleParameter();
                nationalTargetSetupIdOP.Direction = System.Data.ParameterDirection.Input;
                nationalTargetSetupIdOP.OracleDbType = OracleDbType.Decimal;
                nationalTargetSetupIdOP.Value = nationalTargetSetupId;
               
                OracleParameter comGrpMemMapIdOP = new OracleParameter();
                comGrpMemMapIdOP.Direction = System.Data.ParameterDirection.Input;
                comGrpMemMapIdOP.OracleDbType = OracleDbType.Decimal;
                comGrpMemMapIdOP.Value = comGrpMemMapId;
               
                OracleParameter marketingTargetOP = new OracleParameter();
                marketingTargetOP.Direction = System.Data.ParameterDirection.Input;
                marketingTargetOP.OracleDbType = OracleDbType.Decimal;
                marketingTargetOP.Value = marketingTarget;

                OracleParameter increasePerOP = new OracleParameter();
                increasePerOP.Direction = System.Data.ParameterDirection.Input;
                increasePerOP.OracleDbType = OracleDbType.Decimal;
                increasePerOP.Value = increasePer;

                OracleParameter salesTargetOP = new OracleParameter();
                salesTargetOP.Direction = System.Data.ParameterDirection.Input;
                salesTargetOP.OracleDbType = OracleDbType.Decimal;
                salesTargetOP.Value = salesTarget;

                OracleParameter targetUnitIDOP = new OracleParameter();
                targetUnitIDOP.Direction = System.Data.ParameterDirection.Input;
                targetUnitIDOP.OracleDbType = OracleDbType.Decimal;
                targetUnitIDOP.Value = targetUnitID;

                OracleParameter minDecreasePerOP = new OracleParameter();
                minDecreasePerOP.Direction = System.Data.ParameterDirection.Input;
                minDecreasePerOP.OracleDbType = OracleDbType.Decimal;
                minDecreasePerOP.Value = minDecreasePer;

                OracleParameter maxExtendPerOP = new OracleParameter();
                maxExtendPerOP.Direction = System.Data.ParameterDirection.Input;
                maxExtendPerOP.OracleDbType = OracleDbType.Decimal;
                maxExtendPerOP.Value = maxExtendPer;

                OracleParameter minThresholdPerOP = new OracleParameter();
                minThresholdPerOP.Direction = System.Data.ParameterDirection.Input;
                minThresholdPerOP.OracleDbType = OracleDbType.Decimal;
                minThresholdPerOP.Value = minThresholdPer;

                OracleParameter maxThresholdPerOP = new OracleParameter();
                maxThresholdPerOP.Direction = System.Data.ParameterDirection.Input;
                maxThresholdPerOP.OracleDbType = OracleDbType.Decimal;
                maxThresholdPerOP.Value = maxThresholdPer;               

                OracleParameter createBy_OP = new OracleParameter();
                createBy_OP.Direction = System.Data.ParameterDirection.Input;
                createBy_OP.OracleDbType = OracleDbType.Decimal;
                createBy_OP.Value = createBy;

                OracleParameter createDate_OP = new OracleParameter();
                createDate_OP.Direction = System.Data.ParameterDirection.Input;
                createDate_OP.OracleDbType = OracleDbType.Varchar2;
                createDate_OP.Value = createDate.ToString("dd-MMM-yyyy");

                OracleParameter updateBy_OP = new OracleParameter();
                updateBy_OP.Direction = System.Data.ParameterDirection.Input;
                updateBy_OP.OracleDbType = OracleDbType.Decimal;
                updateBy_OP.Value = updateBy;

                OracleParameter updateDate_OP = new OracleParameter();
                updateDate_OP.Direction = System.Data.ParameterDirection.Input;
                updateDate_OP.OracleDbType = OracleDbType.Varchar2;
                updateDate_OP.Value = updateDate.ToString("dd-MMM-yyyy");

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_NATIONAL_TARGET_SETUP_PARENT_AND_DETAILcls>.InsertDataBySP("SP_IU_NATIONAL_TARGET_SETUP_DE", resultOutID,
                   nationalTargetSetupDetailIdOP,  nationalTargetSetupIdOP, comGrpMemMapIdOP, marketingTargetOP, increasePerOP, salesTargetOP, targetUnitIDOP,
             minDecreasePerOP, maxExtendPerOP, minThresholdPerOP, maxThresholdPerOP, createBy_OP, createDate_OP, updateBy_OP, updateDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Save Methods

        #region Get Methods

        /// <summary>
        /// Get all national target setup (parent) by search option.
        /// </summary>
        /// <param name="nationalTargetSetupId"></param>
        /// <param name="commissionGroupId"></param>
        /// <param name="setupName"></param>
        /// <param name="fromMonthDate"></param>
        /// <param name="toMonthDate"></param>
        /// <param name="fromFreezeDate"></param>
        /// <param name="toFreezeDate"></param>
        /// <param name="currentPage"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_NATIONAL_TARGET_SETUPcls> GetParentAll(decimal nationalTargetSetupId, decimal commissionGroupId, string setupName,
          DateTime fromMonthDate, DateTime toMonthDate, DateTime fromFreezeDate, DateTime toFreezeDate, decimal currentPage)
        {
            try
            {
                OracleParameter nationalTargetSetupIdOP = new OracleParameter();
                nationalTargetSetupIdOP.Direction = System.Data.ParameterDirection.Input;
                nationalTargetSetupIdOP.OracleDbType = OracleDbType.Decimal;
                nationalTargetSetupIdOP.Value = nationalTargetSetupId;

                OracleParameter commissionGroupIdOP = new OracleParameter();
                commissionGroupIdOP.Direction = System.Data.ParameterDirection.Input;
                commissionGroupIdOP.OracleDbType = OracleDbType.Decimal;
                commissionGroupIdOP.Value = commissionGroupId;

                OracleParameter setupNameOP = new OracleParameter();
                setupNameOP.Direction = System.Data.ParameterDirection.Input;
                setupNameOP.OracleDbType = OracleDbType.Varchar2;
                setupNameOP.Value = setupName;

                OracleParameter fromMonthDateOP = new OracleParameter();
                fromMonthDateOP.Direction = System.Data.ParameterDirection.Input;
                fromMonthDateOP.OracleDbType = OracleDbType.Varchar2;
                fromMonthDateOP.Value = fromMonthDate != DateTime.MinValue ? fromMonthDate.ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter toMonthDateOP = new OracleParameter();
                toMonthDateOP.Direction = System.Data.ParameterDirection.Input;
                toMonthDateOP.OracleDbType = OracleDbType.Varchar2;
                toMonthDateOP.Value = toMonthDate != DateTime.MinValue ? toMonthDate.ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter fromFreezeDateOP = new OracleParameter();
                fromFreezeDateOP.Direction = System.Data.ParameterDirection.Input;
                fromFreezeDateOP.OracleDbType = OracleDbType.Varchar2;
                fromFreezeDateOP.Value = fromFreezeDate != DateTime.MinValue ? fromFreezeDate.ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter toFreezeDateOP = new OracleParameter();
                toFreezeDateOP.Direction = System.Data.ParameterDirection.Input;
                toFreezeDateOP.OracleDbType = OracleDbType.Varchar2;
                toFreezeDateOP.Value = toFreezeDate != DateTime.MinValue ? toFreezeDate.ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter currentPageOP = new OracleParameter();
                currentPageOP.Direction = System.Data.ParameterDirection.Input;
                currentPageOP.OracleDbType = OracleDbType.Decimal;
                currentPageOP.Value = currentPage;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_NATIONAL_TARGET_SETUPcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_NATIONAL_TARGET_SETUPcls>.GetDataBySP(new SP_GET_NATIONAL_TARGET_SETUPcls(), "SP_GET_NATIONAL_TARGET_SETUP", 15,
                    resultOutCurSor, nationalTargetSetupIdOP, commissionGroupIdOP, setupNameOP,
             fromMonthDateOP, toMonthDateOP, fromFreezeDateOP, toFreezeDateOP, currentPageOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all national target setup detail (child) by search option.
        /// </summary>
        /// <param name="nationalTargetSetupId"></param>
        /// <param name="nationalTargetSetupDetailId"></param>
        /// <param name="commissionGroupId"></param>
        /// <param name="comGrpMemMapId"></param>
        /// <param name="setupName"></param>
        /// <param name="fromMonthDate"></param>
        /// <param name="toMonthDate"></param>
        /// <param name="fromFreezeDate"></param>
        /// <param name="toFreezeDate"></param>
        /// <param name="currentPage"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_NATIONAL_TARGET_SETUP_PARENT_AND_DETAILcls> GetAll(decimal nationalTargetSetupId, decimal nationalTargetSetupDetailId, decimal commissionGroupId, 
            decimal comGrpMemMapId, string setupName, DateTime fromMonthDate, DateTime toMonthDate, DateTime fromFreezeDate, DateTime toFreezeDate, decimal currentPage)
        {
            try
            {
                OracleParameter nationalTargetSetupIdOP = new OracleParameter();
                nationalTargetSetupIdOP.Direction = System.Data.ParameterDirection.Input;
                nationalTargetSetupIdOP.OracleDbType = OracleDbType.Decimal;
                nationalTargetSetupIdOP.Value = nationalTargetSetupId;

                OracleParameter nationalTargetSetupDetailIdOP = new OracleParameter();
                nationalTargetSetupDetailIdOP.Direction = System.Data.ParameterDirection.Input;
                nationalTargetSetupDetailIdOP.OracleDbType = OracleDbType.Decimal;
                nationalTargetSetupDetailIdOP.Value = nationalTargetSetupDetailId;

                OracleParameter commissionGroupIdOP = new OracleParameter();
                commissionGroupIdOP.Direction = System.Data.ParameterDirection.Input;
                commissionGroupIdOP.OracleDbType = OracleDbType.Decimal;
                commissionGroupIdOP.Value = commissionGroupId;

                OracleParameter comGrpMemMapIdOP = new OracleParameter();
                comGrpMemMapIdOP.Direction = System.Data.ParameterDirection.Input;
                comGrpMemMapIdOP.OracleDbType = OracleDbType.Decimal;
                comGrpMemMapIdOP.Value = comGrpMemMapId;

                OracleParameter setupNameOP = new OracleParameter();
                setupNameOP.Direction = System.Data.ParameterDirection.Input;
                setupNameOP.OracleDbType = OracleDbType.Varchar2;
                setupNameOP.Value = setupName;
               
                OracleParameter fromMonthDateOP = new OracleParameter();
                fromMonthDateOP.Direction = System.Data.ParameterDirection.Input;
                fromMonthDateOP.OracleDbType = OracleDbType.Varchar2;
                fromMonthDateOP.Value = fromMonthDate != DateTime.MinValue ? fromMonthDate.ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter toMonthDateOP = new OracleParameter();
                toMonthDateOP.Direction = System.Data.ParameterDirection.Input;
                toMonthDateOP.OracleDbType = OracleDbType.Varchar2;
                toMonthDateOP.Value = toMonthDate != DateTime.MinValue ? toMonthDate.ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter fromFreezeDateOP = new OracleParameter();
                fromFreezeDateOP.Direction = System.Data.ParameterDirection.Input;
                fromFreezeDateOP.OracleDbType = OracleDbType.Varchar2;
                fromFreezeDateOP.Value  = fromFreezeDate != DateTime.MinValue ? fromFreezeDate.ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter toFreezeDateOP = new OracleParameter();
                toFreezeDateOP.Direction = System.Data.ParameterDirection.Input;
                toFreezeDateOP.OracleDbType = OracleDbType.Varchar2;
                toFreezeDateOP.Value = toFreezeDate != DateTime.MinValue ? toFreezeDate.ToString("dd-MMM-yyyy") : string.Empty;
               
                OracleParameter currentPageOP = new OracleParameter();
                currentPageOP.Direction = System.Data.ParameterDirection.Input;
                currentPageOP.OracleDbType = OracleDbType.Decimal;
                currentPageOP.Value = currentPage;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_NATIONAL_TARGET_SETUP_PARENT_AND_DETAILcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_NATIONAL_TARGET_SETUP_PARENT_AND_DETAILcls>.GetDataBySP(new SP_GET_NATIONAL_TARGET_SETUP_PARENT_AND_DETAILcls(), "SP_GET_NATIONAL_TAR_SET_P_A_D", 26,
                    resultOutCurSor, nationalTargetSetupIdOP, nationalTargetSetupDetailIdOP, commissionGroupIdOP,  comGrpMemMapIdOP,  setupNameOP, 
             fromMonthDateOP,  toMonthDateOP,  fromFreezeDateOP,  toFreezeDateOP,  currentPageOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Get Methods
    }
}
