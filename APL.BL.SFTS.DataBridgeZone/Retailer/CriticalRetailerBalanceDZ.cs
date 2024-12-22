using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.Retailer
{
    public class CriticalRetailerBalanceDZ
    {
        public CriticalRetailerBalanceDZ()
        { }

        public List<SP_GET_CRTL_RETAILER_BALANCE> GetCriticalBalances(decimal CriticalBalanceId, decimal UserId)
        {
            try
            {
                OracleParameter CriticalBalanceId_OP = new OracleParameter();
                CriticalBalanceId_OP.Direction = System.Data.ParameterDirection.Input;
                CriticalBalanceId_OP.OracleDbType = OracleDbType.Decimal;
                CriticalBalanceId_OP.Value = CriticalBalanceId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_CRTL_RETAILER_BALANCE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_CRTL_RETAILER_BALANCE>.GetDataBySP(new SP_GET_CRTL_RETAILER_BALANCE(), "SP_GET_CRTL_RETL_BALANCE_WEB", 16, resultOutCurSor, CriticalBalanceId_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_DD_RETAILER_INFO> GetRetailerDistributorInfo(String retailerCode)
        {
            try
            {
                OracleParameter retailerCodeOP = new OracleParameter();
                retailerCodeOP.Direction = System.Data.ParameterDirection.Input;
                retailerCodeOP.OracleDbType = OracleDbType.Varchar2;
                retailerCodeOP.Value = retailerCode;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_DD_RETAILER_INFO>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_DD_RETAILER_INFO>.GetDataBySP(new SP_GET_DD_RETAILER_INFO(), "SP_GET_DD_RETAILER_INFO", 6, resultOutCurSor, retailerCodeOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_CRTBALANCE_TEMP> GetCriticalBalancesTemp(decimal UserId)
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

                return (List<SP_GET_CRTBALANCE_TEMP>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_CRTBALANCE_TEMP>.GetDataBySP(new SP_GET_CRTBALANCE_TEMP(), "SP_GET_CRTBALANCE_TEMP", 16, resultOutCurSor, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Decimal SaveBalanceToTemp(int Index,SP_GET_CRTL_RETAILER_BALANCE retailerBallance, decimal UserId)
        {
            try
            {
                OracleParameter Index_OP = new OracleParameter();
                Index_OP.Direction = System.Data.ParameterDirection.Input;
                Index_OP.OracleDbType = OracleDbType.Decimal;
                Index_OP.Value = Index;

                OracleParameter RETAILER_CODE_OP = new OracleParameter();
                RETAILER_CODE_OP.Direction = System.Data.ParameterDirection.Input;
                RETAILER_CODE_OP.OracleDbType = OracleDbType.Varchar2;
                RETAILER_CODE_OP.Value = retailerBallance.RETAILER_CODE;

                OracleParameter PRODUCT_NAME_OP = new OracleParameter();
                PRODUCT_NAME_OP.Direction = System.Data.ParameterDirection.Input;
                PRODUCT_NAME_OP.OracleDbType = OracleDbType.Varchar2;
                PRODUCT_NAME_OP.Value = retailerBallance.PRODUCT_NAME;

                OracleParameter SATURDAY_OP = new OracleParameter();
                SATURDAY_OP.Direction = System.Data.ParameterDirection.Input;
                SATURDAY_OP.OracleDbType = OracleDbType.Decimal;
                SATURDAY_OP.Value = retailerBallance.SATURDAY;

                OracleParameter SUNDAY_OP = new OracleParameter();
                SUNDAY_OP.Direction = System.Data.ParameterDirection.Input;
                SUNDAY_OP.OracleDbType = OracleDbType.Decimal;
                SUNDAY_OP.Value = retailerBallance.SUNDAY;

                OracleParameter MONDAY_OP = new OracleParameter();
                MONDAY_OP.Direction = System.Data.ParameterDirection.Input;
                MONDAY_OP.OracleDbType = OracleDbType.Decimal;
                MONDAY_OP.Value = retailerBallance.MONDAY;

                OracleParameter TUESDAY_OP = new OracleParameter();
                TUESDAY_OP.Direction = System.Data.ParameterDirection.Input;
                TUESDAY_OP.OracleDbType = OracleDbType.Decimal;
                TUESDAY_OP.Value = retailerBallance.TUESDAY;

                OracleParameter WEDNESDAY_OP = new OracleParameter();
                WEDNESDAY_OP.Direction = System.Data.ParameterDirection.Input;
                WEDNESDAY_OP.OracleDbType = OracleDbType.Decimal;
                WEDNESDAY_OP.Value = retailerBallance.WEDNESDAY;

                OracleParameter THURSDAY_OP = new OracleParameter();
                THURSDAY_OP.Direction = System.Data.ParameterDirection.Input;
                THURSDAY_OP.OracleDbType = OracleDbType.Decimal;
                THURSDAY_OP.Value = retailerBallance.THURSDAY;

                OracleParameter FRIDAY_OP = new OracleParameter();
                FRIDAY_OP.Direction = System.Data.ParameterDirection.Input;
                FRIDAY_OP.OracleDbType = OracleDbType.Decimal;
                FRIDAY_OP.Value = retailerBallance.FRIDAY;

                OracleParameter FROM_DATE_OP = new OracleParameter();
                FROM_DATE_OP.Direction = System.Data.ParameterDirection.Input;
                FROM_DATE_OP.OracleDbType = OracleDbType.Date;
                FROM_DATE_OP.Value = Convert.ToDateTime(retailerBallance.FROM_DATE).Date; ;

                OracleParameter TO_DATE_OP = new OracleParameter();
                TO_DATE_OP.Direction = System.Data.ParameterDirection.Input;
                TO_DATE_OP.OracleDbType = OracleDbType.Date;
                TO_DATE_OP.Value = Convert.ToDateTime(retailerBallance.TO_DATE).Date; ;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENUGROUP_WEB>.InsertDataBySP("SP_SAVE_CRTBALANCE_TEMP", resultOutID, Index_OP, RETAILER_CODE_OP, PRODUCT_NAME_OP, SATURDAY_OP, SUNDAY_OP, MONDAY_OP, TUESDAY_OP, WEDNESDAY_OP, THURSDAY_OP, FRIDAY_OP, FROM_DATE_OP, TO_DATE_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveCriticalBalance(CriticalBalance criticalBalance, decimal UserId)
        {
            try
            {
                OracleParameter ActionFlag_OP = new OracleParameter();
                ActionFlag_OP.Direction = System.Data.ParameterDirection.Input;
                ActionFlag_OP.OracleDbType = OracleDbType.Decimal;
                ActionFlag_OP.Value = criticalBalance.ActionFlag;

                OracleParameter CriticalBalanceId_OP = new OracleParameter();
                CriticalBalanceId_OP.Direction = System.Data.ParameterDirection.Input;
                CriticalBalanceId_OP.OracleDbType = OracleDbType.Decimal;
                CriticalBalanceId_OP.Value = criticalBalance.CriticalBalanceId;

                OracleParameter RETAILER_CODE_OP = new OracleParameter();
                RETAILER_CODE_OP.Direction = System.Data.ParameterDirection.Input;
                RETAILER_CODE_OP.OracleDbType = OracleDbType.Varchar2;
                RETAILER_CODE_OP.Value = criticalBalance.RetailerCode;


                OracleParameter PRODUCT_NAME_OP = new OracleParameter();
                PRODUCT_NAME_OP.Direction = System.Data.ParameterDirection.Input;
                PRODUCT_NAME_OP.OracleDbType = OracleDbType.Varchar2;
                PRODUCT_NAME_OP.Value = criticalBalance.ProductName;

                OracleParameter SATURDAY_OP = new OracleParameter();
                SATURDAY_OP.Direction = System.Data.ParameterDirection.Input;
                SATURDAY_OP.OracleDbType = OracleDbType.Decimal;
                SATURDAY_OP.Value = criticalBalance.Saturday;

                OracleParameter SUNDAY_OP = new OracleParameter();
                SUNDAY_OP.Direction = System.Data.ParameterDirection.Input;
                SUNDAY_OP.OracleDbType = OracleDbType.Decimal;
                SUNDAY_OP.Value = criticalBalance.Sunday;

                OracleParameter MONDAY_OP = new OracleParameter();
                MONDAY_OP.Direction = System.Data.ParameterDirection.Input;
                MONDAY_OP.OracleDbType = OracleDbType.Decimal;
                MONDAY_OP.Value = criticalBalance.Monday;

                OracleParameter TUESDAY_OP = new OracleParameter();
                TUESDAY_OP.Direction = System.Data.ParameterDirection.Input;
                TUESDAY_OP.OracleDbType = OracleDbType.Decimal;
                TUESDAY_OP.Value = criticalBalance.Tuesday;

                OracleParameter WEDNESDAY_OP = new OracleParameter();
                WEDNESDAY_OP.Direction = System.Data.ParameterDirection.Input;
                WEDNESDAY_OP.OracleDbType = OracleDbType.Decimal;
                WEDNESDAY_OP.Value = criticalBalance.Wednesday;

                OracleParameter THURSDAY_OP = new OracleParameter();
                THURSDAY_OP.Direction = System.Data.ParameterDirection.Input;
                THURSDAY_OP.OracleDbType = OracleDbType.Decimal;
                THURSDAY_OP.Value = criticalBalance.Thursday;

                OracleParameter FRIDAY_OP = new OracleParameter();
                FRIDAY_OP.Direction = System.Data.ParameterDirection.Input;
                FRIDAY_OP.OracleDbType = OracleDbType.Decimal;
                FRIDAY_OP.Value = criticalBalance.Friday;

                OracleParameter FROM_DATE_OP = new OracleParameter();
                FROM_DATE_OP.Direction = System.Data.ParameterDirection.Input;
                FROM_DATE_OP.OracleDbType = OracleDbType.Date;
                FROM_DATE_OP.Value = Convert.ToDateTime(criticalBalance.FromDate.Split('/')[2] + "/" + criticalBalance.FromDate.Split('/')[1] + "/" + criticalBalance.FromDate.Split('/')[0]).Date; 

                OracleParameter TO_DATE_OP = new OracleParameter();
                TO_DATE_OP.Direction = System.Data.ParameterDirection.Input;
                TO_DATE_OP.OracleDbType = OracleDbType.Date;
                TO_DATE_OP.Value = Convert.ToDateTime(criticalBalance.ToDate.Split('/')[2] + "/" + criticalBalance.ToDate.Split('/')[1] + "/" + criticalBalance.ToDate.Split('/')[0]).Date; 

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENUGROUP_WEB>.InsertDataBySP("SP_SAVE_CRTLRETL_BALANCE_WB", resultOutID, ActionFlag_OP, CriticalBalanceId_OP, RETAILER_CODE_OP,  PRODUCT_NAME_OP, SATURDAY_OP, SUNDAY_OP, MONDAY_OP, TUESDAY_OP, WEDNESDAY_OP, THURSDAY_OP, FRIDAY_OP, FROM_DATE_OP, TO_DATE_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Decimal DeleteCriticalBalanceTemp()
        {
            try
            {

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENUGROUP_WEB>.InsertDataBySP("SP_DELETE_CRTBALANCE_TEMP", resultOutID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
