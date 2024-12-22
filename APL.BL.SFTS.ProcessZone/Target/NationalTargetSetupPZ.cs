using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class NationalTargetSetupPZ
    {
        public NationalTargetSetupPZ() { }

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
        /// <returns></returns>
        public Decimal Save(decimal nationalTargetSetupId, decimal commissionGroupId, decimal comGrpMemMapId, string setupName,
            DateTime startDate, DateTime endDate, DateTime MonthDate, DateTime freezeDate, decimal marketingTarget, decimal increasePer, decimal salesTarget, decimal targetUnitID,
            decimal minDecreasePer, decimal maxExtendPer, decimal minThresholdPer, decimal maxThresholdPer, decimal isReusable,
            decimal createBy, DateTime createDate, decimal updateBy, DateTime updateDate)
        {
            try
            {
                return new NationalTargetSetupDZ().Save(nationalTargetSetupId, commissionGroupId, comGrpMemMapId, setupName,
             startDate, endDate, MonthDate, freezeDate, marketingTarget, increasePer, salesTarget, targetUnitID,
             minDecreasePer, maxExtendPer, minThresholdPer, maxThresholdPer, isReusable,
             createBy, createDate, updateBy, updateDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save or update national target setup detail (child). It is prepared from commission group of member wise target setup value. 
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
        /// <param name="natTarSetupDetailColl"></param>
        /// <returns></returns>
        public Decimal Save(decimal nationalTargetSetupId, decimal commissionGroupId,  string setupName,
           DateTime startDate, DateTime endDate, DateTime MonthDate, DateTime freezeDate, decimal isReusable,
           decimal createBy, DateTime createDate, decimal updateBy, DateTime updateDate, List<SP_GET_NATIONAL_TARGET_SETUP_PARENT_AND_DETAILcls> natTarSetupDetailColl)
        {
            try
            {
                decimal nationalTargetSetupIdOut =  new NationalTargetSetupDZ().SaveParent(nationalTargetSetupId, commissionGroupId, setupName, startDate, endDate, MonthDate, freezeDate, 
                    isReusable,  createBy, createDate, updateBy, updateDate);

                int totalExecutedRow = 0;
                foreach (var item in natTarSetupDetailColl)
                {
                    new NationalTargetSetupDZ().SaveChild(item.NATIONAL_TARGET_SETUP_DETAIL_ID, item.NATIONAL_TARGET_SETUP_ID, item.COMMISSION_GROUP_MEM_MAP_ID, item.MARKETING_TARGET, item.INCREASE_PER, item.SALES_TARGET, item.TARGET_UNIT_ID,
                item.MIN_DECREASE_PER, item.MAX_EXTEND_PER, item.MIN_THRESHOLD_PER, item.MAX_THRESHOLD_PER, item.CREATE_BY, item.CREATE_DATE, item.UPDATE_BY, item.UPDATE_DATE);
                    totalExecutedRow++;
                }
                return totalExecutedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save or update national target setup and national target setup detail (parent and child). It is prepared from commission group of member wise target setup value. 
        /// </summary>
        /// <param name="tarSetup"></param>
        /// <param name="natTarSetupDetailColl"></param>
        /// <returns>number or child row save into database </returns>
        public Decimal Save(SP_GET_NATIONAL_TARGET_SETUPcls tarSetup, List<SP_GET_NATIONAL_TARGET_SETUP_PARENT_AND_DETAILcls> natTarSetupDetailColl)
        {
            try
            {
                decimal nationalTargetSetupIdOut = new NationalTargetSetupDZ().SaveParent(tarSetup.NATIONAL_TARGET_SETUP_ID, tarSetup.COMMISSION_GROUP_ID, tarSetup.SETUP_NAME, tarSetup.START_DATE,
                    tarSetup.END_DATE, tarSetup.MONTH_DATE, tarSetup.FREEZE_DATE, tarSetup.IS_REUSABLE, tarSetup.CREATE_BY, tarSetup.CREATE_DATE, tarSetup.UPDATE_BY, tarSetup.UPDATE_DATE);

                int totalExecutedRow = 0;
                if (nationalTargetSetupIdOut > 0)
                {
                    foreach (var item in natTarSetupDetailColl)
                    {
                        item.NATIONAL_TARGET_SETUP_ID = nationalTargetSetupIdOut;
                        decimal nationalTargetSetupDetailIdOut = new NationalTargetSetupDZ().SaveChild(item.NATIONAL_TARGET_SETUP_DETAIL_ID, item.NATIONAL_TARGET_SETUP_ID, item.COMMISSION_GROUP_MEM_MAP_ID, item.MARKETING_TARGET, item.INCREASE_PER, item.SALES_TARGET, item.TARGET_UNIT_ID,
                                    item.MIN_DECREASE_PER, item.MAX_EXTEND_PER, item.MIN_THRESHOLD_PER, item.MAX_THRESHOLD_PER, item.CREATE_BY, item.CREATE_DATE, item.UPDATE_BY, item.UPDATE_DATE);
                        totalExecutedRow++;
                    }
                }
                return totalExecutedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save or update list of national target setup. It is prepared from commission group of member wise target setup value. 
        /// </summary>
        /// <param name="natTarSetupColl"></param>
        /// <returns></returns>
        public Decimal Save(List<SP_GET_NATIONAL_TARGET_SETUP_PARENT_AND_DETAILcls> natTarSetupColl)
        {
            try
            {
                int totalExecutedRow = 0;
                foreach (var item in natTarSetupColl)
                {
                    new NationalTargetSetupDZ().Save(item.NATIONAL_TARGET_SETUP_ID, item.COMMISSION_GROUP_ID, item.COMMISSION_GROUP_MEM_MAP_ID, item.SETUP_NAME,
                item.START_DATE, item.END_DATE, item.MONTH_DATE, item.FREEZE_DATE, item.MARKETING_TARGET, item.INCREASE_PER, item.SALES_TARGET, item.TARGET_UNIT_ID,
                item.MIN_DECREASE_PER, item.MAX_EXTEND_PER, item.MIN_THRESHOLD_PER, item.MAX_THRESHOLD_PER, item.IS_REUSABLE, item.CREATE_BY, item.CREATE_DATE,
                item.UPDATE_BY, item.UPDATE_DATE);
                    totalExecutedRow++;
                }
                return totalExecutedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
        public List<SP_GET_NATIONAL_TARGET_SETUPcls> GetParentAll(decimal nationalTargetSetupId, decimal commissionGroupId,
           string setupName, DateTime fromMonthDate, DateTime toMonthDate, DateTime fromFreezeDate, DateTime toFreezeDate, decimal currentPage)
        {
            try
            {
                return new NationalTargetSetupDZ().GetParentAll(nationalTargetSetupId, commissionGroupId,  setupName, fromMonthDate, toMonthDate, fromFreezeDate, toFreezeDate, currentPage);
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
        /// <returns></returns>
        public List<SP_GET_NATIONAL_TARGET_SETUP_PARENT_AND_DETAILcls> GetAll(decimal nationalTargetSetupId, decimal nationalTargetSetupDetailId, decimal commissionGroupId, 
            decimal comGrpMemMapId, string setupName, DateTime fromMonthDate, DateTime toMonthDate, DateTime fromFreezeDate, DateTime toFreezeDate, decimal currentPage)
        {
            try
            {
                return new NationalTargetSetupDZ().GetAll(nationalTargetSetupId, nationalTargetSetupDetailId, commissionGroupId, comGrpMemMapId, setupName,
             fromMonthDate, toMonthDate, fromFreezeDate, toFreezeDate, currentPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
