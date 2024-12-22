using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class NationalTargetDistributionDZ
    {
        public NationalTargetDistributionDZ() { }

        #region Save Methods

        /// <summary>
        /// Save national target distribution which prepare from excel file. It is descript Region target or Distributor target or RSO target or Retailer target value for particular national target setup wise value.
        /// </summary>
        /// <param name="natTarDistribution"></param>
        /// <param name="natTarDistributionDetailColl"></param>
        /// <returns>NatTarDistributionID</returns>
        public decimal Save(SP_GET_NAT_TAR_DISTRIBUTIONcls natTarDistribution, List<SP_GET_NAT_TAR_DISTRIBUTION_WCcls> natTarDistributionDetailColl)
        {
            try
            {
                OracleParameter natTarDistributionOP = new OracleParameter();
                natTarDistributionOP.Direction = System.Data.ParameterDirection.Input;
                natTarDistributionOP.OracleDbType = OracleDbType.Decimal;
                natTarDistributionOP.Value = natTarDistribution.NAT_TAR_DISTRIBUTION_ID;

                OracleParameter channelID_OP = new OracleParameter();
                channelID_OP.Direction = System.Data.ParameterDirection.Input;
                channelID_OP.OracleDbType = OracleDbType.Decimal;
                channelID_OP.Value = natTarDistribution.CHANNELID;

                OracleParameter targetAmtTypeID_OP = new OracleParameter();
                targetAmtTypeID_OP.Direction = System.Data.ParameterDirection.Input;
                targetAmtTypeID_OP.OracleDbType = OracleDbType.Decimal;
                targetAmtTypeID_OP.Value = natTarDistribution.TARGET_AMT_TYPE_ID;

                OracleParameter natTarSetupNameOP = new OracleParameter();
                natTarSetupNameOP.Direction = System.Data.ParameterDirection.Input;
                natTarSetupNameOP.OracleDbType = OracleDbType.Varchar2;
                natTarSetupNameOP.Value = natTarDistribution.NAT_TAR_SET_NAME;

                OracleParameter commissionGrpID_OP = new OracleParameter();
                commissionGrpID_OP.Direction = System.Data.ParameterDirection.Input;
                commissionGrpID_OP.OracleDbType = OracleDbType.Decimal;
                commissionGrpID_OP.Value = natTarDistribution.COM_GROUP_ID;

                OracleParameter startDateOP = new OracleParameter();
                startDateOP.Direction = System.Data.ParameterDirection.Input;
                startDateOP.OracleDbType = OracleDbType.Date;
                startDateOP.Value = natTarDistribution.START_DATE;

                OracleParameter endDateOP = new OracleParameter();
                endDateOP.Direction = System.Data.ParameterDirection.Input;
                endDateOP.OracleDbType = OracleDbType.Date;
                endDateOP.Value = natTarDistribution.END_DATE;

                OracleParameter descriptionOP = new OracleParameter();
                descriptionOP.Direction = System.Data.ParameterDirection.Input;
                descriptionOP.OracleDbType = OracleDbType.Varchar2;
                descriptionOP.Value = natTarDistribution.DESCRIPTION;

                OracleParameter freezeDateOP = new OracleParameter();
                freezeDateOP.Direction = System.Data.ParameterDirection.Input;
                freezeDateOP.OracleDbType = OracleDbType.Date;
                freezeDateOP.Value = natTarDistribution.FREEZE_DATE;

                OracleParameter monthDateOP = new OracleParameter();
                monthDateOP.Direction = System.Data.ParameterDirection.Input;
                monthDateOP.OracleDbType = OracleDbType.Date;
                monthDateOP.Value = natTarDistribution.MONTH_DATE;

                OracleParameter totalExcelCloumnOP = new OracleParameter();
                totalExcelCloumnOP.Direction = System.Data.ParameterDirection.Input;
                totalExcelCloumnOP.OracleDbType = OracleDbType.Decimal;
                totalExcelCloumnOP.Value = natTarDistribution.TOTAL_ECL_CLN;

                OracleParameter createByOP = new OracleParameter();
                createByOP.Direction = System.Data.ParameterDirection.Input;
                createByOP.OracleDbType = OracleDbType.Decimal;
                createByOP.Value = natTarDistribution.CREATE_BY;

                OracleParameter createDateOP = new OracleParameter();
                createDateOP.Direction = System.Data.ParameterDirection.Input;
                createDateOP.OracleDbType = OracleDbType.Date;
                createDateOP.Value = natTarDistribution.CREATE_DATE;

                OracleParameter updateByOP = new OracleParameter();
                updateByOP.Direction = System.Data.ParameterDirection.Input;
                updateByOP.OracleDbType = OracleDbType.Decimal;
                updateByOP.Value = natTarDistribution.UPDATE_BY;

                OracleParameter updateDateOP = new OracleParameter();
                updateDateOP.Direction = System.Data.ParameterDirection.Input;
                updateDateOP.OracleDbType = OracleDbType.Date;
                updateDateOP.Value = natTarDistribution.UPDATE_DATE;

                OracleParameter nationalTargetSetupIDOP = new OracleParameter();
                nationalTargetSetupIDOP.Direction = System.Data.ParameterDirection.Input;
                nationalTargetSetupIDOP.OracleDbType = OracleDbType.Decimal;
                nationalTargetSetupIDOP.Value = natTarDistribution.NATIONAL_TARGET_SETUPID;

                OracleParameter resultOutID_OP = new OracleParameter();
                resultOutID_OP.Direction = System.Data.ParameterDirection.Output;
                resultOutID_OP.OracleDbType = OracleDbType.Decimal;


                decimal natTarDistributionID = ObjectMakerFromOracleSP.OracleHelper<SP_GET_NAT_TAR_DISTRIBUTIONcls>.InsertDataBySP("SP_IU_NAT_TAR_DISTRIBUTION",
                  resultOutID_OP, natTarDistributionOP, channelID_OP, targetAmtTypeID_OP, natTarSetupNameOP, commissionGrpID_OP, startDateOP, endDateOP, descriptionOP,
                  freezeDateOP, monthDateOP, totalExcelCloumnOP, createByOP, createDateOP, updateByOP, updateDateOP, nationalTargetSetupIDOP);

                decimal totalDetailExecuted = 0;
                foreach (var item in natTarDistributionDetailColl)
                {
                    OracleParameter natTarDistributorDetID_OP = new OracleParameter();
                    natTarDistributorDetID_OP.Direction = System.Data.ParameterDirection.Input;
                    natTarDistributorDetID_OP.OracleDbType = OracleDbType.Decimal;
                    natTarDistributorDetID_OP.Value = item.NAT_TAR_DISTRIBUTION_DET_ID;

                    OracleParameter natTarDistributorForen_OP = new OracleParameter();
                    natTarDistributorForen_OP.Direction = System.Data.ParameterDirection.Input;
                    natTarDistributorForen_OP.OracleDbType = OracleDbType.Decimal;
                    natTarDistributorForen_OP.Value = natTarDistributionID;

                    OracleParameter regionID_OP = new OracleParameter();
                    regionID_OP.Direction = System.Data.ParameterDirection.Input;
                    regionID_OP.OracleDbType = OracleDbType.Decimal;
                    regionID_OP.Value = item.REGION_ID;

                    OracleParameter distributorID_OP = new OracleParameter();
                    distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                    distributorID_OP.OracleDbType = OracleDbType.Decimal;
                    distributorID_OP.Value = item.DISTRIBUTOR_ID;

                    OracleParameter rsoID_OP = new OracleParameter();
                    rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                    rsoID_OP.OracleDbType = OracleDbType.Decimal;
                    rsoID_OP.Value = item.RSO_ID;

                    OracleParameter retailerID_OP = new OracleParameter();
                    retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                    retailerID_OP.OracleDbType = OracleDbType.Decimal;
                    retailerID_OP.Value = item.RETAILER_ID;
                    ////
                    OracleParameter xlsCln05_OP = new OracleParameter();
                    xlsCln05_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln05_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln05_OP.Value = item.XLS_CLN_05;

                    OracleParameter xlsCln06_OP = new OracleParameter();
                    xlsCln06_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln06_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln06_OP.Value = item.XLS_CLN_06;

                    OracleParameter xlsCln07_OP = new OracleParameter();
                    xlsCln07_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln07_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln07_OP.Value = item.XLS_CLN_07;

                    OracleParameter xlsCln08_OP = new OracleParameter();
                    xlsCln08_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln08_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln08_OP.Value = item.XLS_CLN_08;


                    OracleParameter xlsCln09_OP = new OracleParameter();
                    xlsCln09_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln09_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln09_OP.Value = item.XLS_CLN_09;


                    OracleParameter xlsCln10_OP = new OracleParameter();
                    xlsCln10_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln10_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln10_OP.Value = item.XLS_CLN_10;


                    OracleParameter xlsCln11_OP = new OracleParameter();
                    xlsCln11_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln11_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln11_OP.Value = item.XLS_CLN_11;


                    OracleParameter xlsCln12_OP = new OracleParameter();
                    xlsCln12_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln12_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln12_OP.Value = item.XLS_CLN_12;


                    OracleParameter xlsCln13_OP = new OracleParameter();
                    xlsCln13_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln13_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln13_OP.Value = item.XLS_CLN_13;

                    OracleParameter xlsCln14_OP = new OracleParameter();
                    xlsCln14_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln14_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln14_OP.Value = item.XLS_CLN_14;


                    OracleParameter xlsCln15_OP = new OracleParameter();
                    xlsCln15_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln15_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln15_OP.Value = item.XLS_CLN_15;


                    OracleParameter xlsCln16_OP = new OracleParameter();
                    xlsCln16_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln16_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln16_OP.Value = item.XLS_CLN_16;

                    OracleParameter xlsCln17_OP = new OracleParameter();
                    xlsCln17_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln17_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln17_OP.Value = item.XLS_CLN_17;

                    OracleParameter xlsCln18_OP = new OracleParameter();
                    xlsCln18_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln18_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln18_OP.Value = item.XLS_CLN_18;


                    OracleParameter xlsCln19_OP = new OracleParameter();
                    xlsCln19_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln19_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln19_OP.Value = item.XLS_CLN_19;


                    OracleParameter xlsCln20_OP = new OracleParameter();
                    xlsCln20_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln20_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln20_OP.Value = item.XLS_CLN_20;


                    OracleParameter xlsCln21_OP = new OracleParameter();
                    xlsCln21_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln21_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln21_OP.Value = item.XLS_CLN_21;


                    OracleParameter xlsCln22_OP = new OracleParameter();
                    xlsCln22_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln22_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln22_OP.Value = item.XLS_CLN_22;


                    OracleParameter xlsCln23_OP = new OracleParameter();
                    xlsCln23_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln23_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln23_OP.Value = item.XLS_CLN_23;


                    OracleParameter xlsCln24_OP = new OracleParameter();
                    xlsCln24_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln24_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln24_OP.Value = item.XLS_CLN_24;

                    OracleParameter xlsCln25_OP = new OracleParameter();
                    xlsCln25_OP.Direction = System.Data.ParameterDirection.Input;
                    xlsCln25_OP.OracleDbType = OracleDbType.Varchar2;
                    xlsCln25_OP.Value = item.XLS_CLN_25;

                    /////

                    OracleParameter createByDetailOP = new OracleParameter();
                    createByDetailOP.Direction = System.Data.ParameterDirection.Input;
                    createByDetailOP.OracleDbType = OracleDbType.Decimal;
                    createByDetailOP.Value = item.CREATE_BY;

                    OracleParameter createDateDetailOP = new OracleParameter();
                    createDateDetailOP.Direction = System.Data.ParameterDirection.Input;
                    createDateDetailOP.OracleDbType = OracleDbType.Date;
                    createDateDetailOP.Value = item.CREATE_DATE;

                    OracleParameter updateByDetailOP = new OracleParameter();
                    updateByDetailOP.Direction = System.Data.ParameterDirection.Input;
                    updateByDetailOP.OracleDbType = OracleDbType.Decimal;
                    updateByDetailOP.Value = item.UPDATE_BY;

                    OracleParameter updateDateDetailOP = new OracleParameter();
                    updateDateDetailOP.Direction = System.Data.ParameterDirection.Input;
                    updateDateDetailOP.OracleDbType = OracleDbType.Date;
                    updateDateDetailOP.Value = item.UPDATE_DATE;

                    OracleParameter resultOutDetailID_OP = new OracleParameter();
                    resultOutDetailID_OP.Direction = System.Data.ParameterDirection.Output;
                    resultOutDetailID_OP.OracleDbType = OracleDbType.Decimal;

                    decimal natTarDistributionDetID = ObjectMakerFromOracleSP.OracleHelper<SP_GET_NAT_TAR_DISTRIBUTIONcls>.InsertDataBySP("SP_IU_NAT_TAR_DISTRIBUTION_DET",
                        resultOutDetailID_OP, natTarDistributorDetID_OP, natTarDistributorForen_OP, regionID_OP, distributorID_OP, rsoID_OP, retailerID_OP,
                        xlsCln05_OP, xlsCln06_OP, xlsCln07_OP, xlsCln08_OP, xlsCln09_OP,
                        xlsCln10_OP, xlsCln11_OP, xlsCln12_OP, xlsCln13_OP, xlsCln14_OP,
                        xlsCln15_OP, xlsCln16_OP, xlsCln17_OP, xlsCln18_OP, xlsCln19_OP,
                        xlsCln20_OP, xlsCln21_OP, xlsCln22_OP, xlsCln23_OP, xlsCln24_OP, xlsCln25_OP,
                        createByDetailOP, createDateDetailOP, updateByDetailOP, updateDateDetailOP);

                    if (natTarDistributionDetID > 0)
                    {
                        totalDetailExecuted++;
                        natTarDistributionDetID = 0;
                    }
                }

                if (totalDetailExecuted != natTarDistributionDetailColl.Count)
                {
                    natTarDistributionID = -1;
                }

                return natTarDistributionID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Save Methods

        #region Get Methods      
     
        /// <summary>
        /// Get all national target distribution by search option.
        /// </summary>
        /// <param name="channelID"></param>
        /// <param name="targetAmtTypeID"></param>
        /// <param name="natTarDescription"></param>
        /// <param name="comGroID"></param>
        /// <param name="monthDate"></param>
        /// <param name="regionID"></param>
        /// <param name="distributorID"></param>
        /// <param name="nationalTargetSetupID"></param>
        /// <param name="currentPageNo"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_NAT_TAR_DISTRIBUTIONcls> GetParentAll(decimal channelID, decimal targetAmtTypeID, String natTarDescription, decimal comGroID, DateTime monthDate, decimal regionID, decimal distributorID, decimal nationalTargetSetupID, decimal currentPageNo) 
        {
            try
            {
                OracleParameter channelIDOP = new OracleParameter();
                channelIDOP.Direction = System.Data.ParameterDirection.Input;
                channelIDOP.OracleDbType = OracleDbType.Decimal;
                channelIDOP.Value = channelID;

                OracleParameter targetAmtTypeIDOP = new OracleParameter();
                targetAmtTypeIDOP.Direction = System.Data.ParameterDirection.Input;
                targetAmtTypeIDOP.OracleDbType = OracleDbType.Decimal;
                targetAmtTypeIDOP.Value = targetAmtTypeID;

                OracleParameter natTarDescriptionOP = new OracleParameter();
                natTarDescriptionOP.Direction = System.Data.ParameterDirection.Input;
                natTarDescriptionOP.OracleDbType = OracleDbType.Varchar2;
                natTarDescriptionOP.Value = natTarDescription;

                OracleParameter comGroIDOP = new OracleParameter();
                comGroIDOP.Direction = System.Data.ParameterDirection.Input;
                comGroIDOP.OracleDbType = OracleDbType.Decimal;
                comGroIDOP.Value = comGroID;

                OracleParameter monthDateOP = new OracleParameter();
                monthDateOP.Direction = System.Data.ParameterDirection.Input;
                monthDateOP.OracleDbType = OracleDbType.Varchar2;
                monthDateOP.Value = monthDate != DateTime.MinValue ? monthDate.ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter regionIDOP = new OracleParameter();
                regionIDOP.Direction = System.Data.ParameterDirection.Input;
                regionIDOP.OracleDbType = OracleDbType.Decimal;
                regionIDOP.Value = regionID;

                OracleParameter distributorIDOP = new OracleParameter();
                distributorIDOP.Direction = System.Data.ParameterDirection.Input;
                distributorIDOP.OracleDbType = OracleDbType.Decimal;
                distributorIDOP.Value = distributorID;

                 OracleParameter nationalTargetSetupIDOP = new OracleParameter();
                 nationalTargetSetupIDOP.Direction = System.Data.ParameterDirection.Input;
                 nationalTargetSetupIDOP.OracleDbType = OracleDbType.Decimal;
                 nationalTargetSetupIDOP.Value = nationalTargetSetupID;

                 OracleParameter currentPageNoOP = new OracleParameter();
                 currentPageNoOP.Direction = System.Data.ParameterDirection.Input;
                 currentPageNoOP.OracleDbType = OracleDbType.Decimal;
                 currentPageNoOP.Value = currentPageNo;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_NAT_TAR_DISTRIBUTIONcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_NAT_TAR_DISTRIBUTIONcls>.GetDataBySP(new SP_GET_NAT_TAR_DISTRIBUTIONcls(), "SP_GET_NAT_TAR_DISTRIBUTION", 26,
                    resultOutCurSor, channelIDOP, targetAmtTypeIDOP, natTarDescriptionOP, comGroIDOP, monthDateOP, regionIDOP, distributorIDOP, nationalTargetSetupIDOP, currentPageNoOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all national target distribution detail (child) by search option.
        /// </summary>
        /// <param name="natTarDistributionID"></param>
        /// <param name="natTarDistributionDetailID"></param>
        /// <param name="channelID"></param>
        /// <param name="targetAmtTypeID"></param>
        /// <param name="natTarSetupID"></param>
        /// <param name="comGroID"></param>
        /// <param name="monthDate"></param>
        /// <param name="regionID"></param>
        /// <param name="distributorID"></param>
        /// <returns></returns>
        public List<SP_GET_NAT_TAR_DISTRIBUTION_WCcls> GetParentChildAll(decimal natTarDistributionID, decimal natTarDistributionDetailID, decimal channelID, decimal targetAmtTypeID, decimal natTarSetupID, decimal comGroID, DateTime monthDate, decimal regionID, decimal distributorID)
        {
            try
            {
                OracleParameter natTarDistributionIDOP = new OracleParameter();
                natTarDistributionIDOP.Direction = System.Data.ParameterDirection.Input;
                natTarDistributionIDOP.OracleDbType = OracleDbType.Decimal;
                natTarDistributionIDOP.Value = natTarDistributionID;

                OracleParameter natTarDistributionDetailIDOP = new OracleParameter();
                natTarDistributionDetailIDOP.Direction = System.Data.ParameterDirection.Input;
                natTarDistributionDetailIDOP.OracleDbType = OracleDbType.Decimal;
                natTarDistributionDetailIDOP.Value = natTarDistributionDetailID;

                OracleParameter channelIDOP = new OracleParameter();
                channelIDOP.Direction = System.Data.ParameterDirection.Input;
                channelIDOP.OracleDbType = OracleDbType.Decimal;
                channelIDOP.Value = channelID;

                OracleParameter targetAmtTypeIDOP = new OracleParameter();
                targetAmtTypeIDOP.Direction = System.Data.ParameterDirection.Input;
                targetAmtTypeIDOP.OracleDbType = OracleDbType.Decimal;
                targetAmtTypeIDOP.Value = targetAmtTypeID;

                OracleParameter natTarSetupIDOP = new OracleParameter();
                natTarSetupIDOP.Direction = System.Data.ParameterDirection.Input;
                natTarSetupIDOP.OracleDbType = OracleDbType.Decimal;
                natTarSetupIDOP.Value = natTarSetupID;

                OracleParameter comGroIDOP = new OracleParameter();
                comGroIDOP.Direction = System.Data.ParameterDirection.Input;
                comGroIDOP.OracleDbType = OracleDbType.Decimal;
                comGroIDOP.Value = comGroID;

                OracleParameter monthDateOP = new OracleParameter();
                monthDateOP.Direction = System.Data.ParameterDirection.Input;
                monthDateOP.OracleDbType = OracleDbType.Varchar2;
                monthDateOP.Value = monthDate != DateTime.MinValue ? monthDate.ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter regionIDOP = new OracleParameter();
                regionIDOP.Direction = System.Data.ParameterDirection.Input;
                regionIDOP.OracleDbType = OracleDbType.Decimal;
                regionIDOP.Value = regionID;

                OracleParameter distributorIDOP = new OracleParameter();
                distributorIDOP.Direction = System.Data.ParameterDirection.Input;
                distributorIDOP.OracleDbType = OracleDbType.Decimal;
                distributorIDOP.Value = distributorID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_NAT_TAR_DISTRIBUTION_WCcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_NAT_TAR_DISTRIBUTION_WCcls>.GetDataBySP(new SP_GET_NAT_TAR_DISTRIBUTION_WCcls(), "SP_GET_NAT_TAR_DISTRIBUTION_WC", 44,
                    resultOutCurSor, natTarDistributionIDOP, natTarDistributionDetailIDOP, channelIDOP, targetAmtTypeIDOP, natTarSetupIDOP, comGroIDOP, monthDateOP, regionIDOP, distributorIDOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion Get Methods

        #region Delete Methods
        //Implement delete methods
        #endregion Delete Methods

    }
}
