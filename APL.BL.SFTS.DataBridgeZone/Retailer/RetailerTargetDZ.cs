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
    public  class RetailerTargetDZ
    {
        public RetailerTargetDZ()
        { }

        public List<SP_FF_GET_RETAILER_TARGET> GetRetailerTargets(decimal TargetId, decimal UserId)
        {
            try
            {
                OracleParameter TargetId_OP = new OracleParameter();
                TargetId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetId_OP.OracleDbType = OracleDbType.Decimal;
                TargetId_OP.Value = TargetId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_FF_GET_RETAILER_TARGET>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_RETAILER_TARGET>.GetDataBySP(new SP_FF_GET_RETAILER_TARGET(), "SP_FF_GET_RETAILER_TARGET", 10, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_FF_GET_TARGET_PERIOD> GetTargetPeriodList(decimal UserId)
        {
            try
            {
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_FF_GET_TARGET_PERIOD>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_TARGET_PERIOD>.GetDataBySP(new SP_FF_GET_TARGET_PERIOD(), "SP_FF_GET_TARGET_PERIOD", 2, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_FF_GET_TARGET_ITEM> GetTargetItemList(decimal UserId)
        {
            try
            {
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_FF_GET_TARGET_ITEM>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_TARGET_ITEM>.GetDataBySP(new SP_FF_GET_TARGET_ITEM(), "SP_FF_GET_TARGET_ITEM", 2, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Decimal DeleteRetailerTargetTemp()
        {
            try
            {

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENUGROUP_WEB>.InsertDataBySP("SP_DELETE_RETLTARGET_TEMP", resultOutID);
            }
            catch (Exception ex)                                           
            {
                throw ex;
            }
        }
        public Decimal SaveTargetToTemp(int Index, SP_FF_GET_RETAILER_TARGET retailerTarget, decimal UserId)
        {
            try
            {
                OracleParameter Index_OP = new OracleParameter();
                Index_OP.Direction = System.Data.ParameterDirection.Input;
                Index_OP.OracleDbType = OracleDbType.Decimal;
                Index_OP.Value = Index;

                OracleParameter PERIOD_ID_OP = new OracleParameter();
                PERIOD_ID_OP.Direction = System.Data.ParameterDirection.Input;
                PERIOD_ID_OP.OracleDbType = OracleDbType.Decimal;
                PERIOD_ID_OP.Value = retailerTarget.PERIOD_ID;

                OracleParameter PERIOD_NAME_OP = new OracleParameter();
                PERIOD_NAME_OP.Direction = System.Data.ParameterDirection.Input;
                PERIOD_NAME_OP.OracleDbType = OracleDbType.Varchar2;
                PERIOD_NAME_OP.Value = retailerTarget.PERIOD_NAME;

                OracleParameter ITEM_ID_OP = new OracleParameter();
                ITEM_ID_OP.Direction = System.Data.ParameterDirection.Input;
                ITEM_ID_OP.OracleDbType = OracleDbType.Decimal;
                ITEM_ID_OP.Value = retailerTarget.ITEM_ID;

                OracleParameter ITEM_NAME_OP = new OracleParameter();
                ITEM_NAME_OP.Direction = System.Data.ParameterDirection.Input;
                ITEM_NAME_OP.OracleDbType = OracleDbType.Varchar2;
                ITEM_NAME_OP.Value = retailerTarget.ITEM_NAME;

                OracleParameter STAFF_CODE_OP = new OracleParameter();
                STAFF_CODE_OP.Direction = System.Data.ParameterDirection.Input;
                STAFF_CODE_OP.OracleDbType = OracleDbType.Varchar2;
                STAFF_CODE_OP.Value = retailerTarget.STAFF_CODE;

                OracleParameter STAFF_TYPE_OP = new OracleParameter();
                STAFF_TYPE_OP.Direction = System.Data.ParameterDirection.Input;
                STAFF_TYPE_OP.OracleDbType = OracleDbType.Varchar2;
                STAFF_TYPE_OP.Value = retailerTarget.STAFF_TYPE;

                OracleParameter TARGET_OP = new OracleParameter();
                TARGET_OP.Direction = System.Data.ParameterDirection.Input;
                TARGET_OP.OracleDbType = OracleDbType.Decimal;
                TARGET_OP.Value = retailerTarget.TARGET;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENUGROUP_WEB>.InsertDataBySP("SP_SAVE_RETLTARGET_TEMP", resultOutID, Index_OP, PERIOD_ID_OP, PERIOD_NAME_OP, ITEM_ID_OP, ITEM_NAME_OP, STAFF_CODE_OP, STAFF_TYPE_OP, TARGET_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_FF_GET_RETAILER_TARGET> GetRetailerTargetsTemp(decimal UserId)
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

                return (List<SP_FF_GET_RETAILER_TARGET>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_RETAILER_TARGET>.GetDataBySP(new SP_FF_GET_RETAILER_TARGET(), "SP_GET_RETLTARGET_TEMP", 10, resultOutCurSor, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //p_ActionFlag IN NUMBER,
        //   p_TargetId IN NUMBER,
        //   p_ItemId IN NUMBER,
        //   p_PeriodId IN NUMBER,
        //   p_StaffCode IN VARCHAR,
        //   p_StaffType IN VARCHAR,
        //   p_Target IN NUMBER,
        //   p_SetDate IN DATE,
        //   p_UpTo IN DATE,
        //   p_UserId IN NUMBER
        public Decimal SaveRetailerTarget(RetailerTarget retailerTarget, decimal UserId)
        {
            try
            {
                OracleParameter ActionFlag_OP = new OracleParameter();
                ActionFlag_OP.Direction = System.Data.ParameterDirection.Input;
                ActionFlag_OP.OracleDbType = OracleDbType.Decimal;
                ActionFlag_OP.Value = retailerTarget.ActionFlag;

                OracleParameter TargetId_OP = new OracleParameter();
                TargetId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetId_OP.OracleDbType = OracleDbType.Decimal;
                TargetId_OP.Value = retailerTarget.TargetId;

                OracleParameter ItemId_OP = new OracleParameter();
                ItemId_OP.Direction = System.Data.ParameterDirection.Input;
                ItemId_OP.OracleDbType = OracleDbType.Varchar2;
                ItemId_OP.Value = retailerTarget.ItemId;


                OracleParameter PeriodId_OP = new OracleParameter();
                PeriodId_OP.Direction = System.Data.ParameterDirection.Input;
                PeriodId_OP.OracleDbType = OracleDbType.Varchar2;
                PeriodId_OP.Value = retailerTarget.PeriodId;

                OracleParameter StaffCode_OP = new OracleParameter();
                StaffCode_OP.Direction = System.Data.ParameterDirection.Input;
                StaffCode_OP.OracleDbType = OracleDbType.Varchar2;
                StaffCode_OP.Value = retailerTarget.StaffCode;

                OracleParameter StaffType_OP = new OracleParameter();
                StaffType_OP.Direction = System.Data.ParameterDirection.Input;
                StaffType_OP.OracleDbType = OracleDbType.Varchar2;
                StaffType_OP.Value = retailerTarget.StaffType;

                OracleParameter Target_OP = new OracleParameter();
                Target_OP.Direction = System.Data.ParameterDirection.Input;
                Target_OP.OracleDbType = OracleDbType.Varchar2;
                Target_OP.Value = retailerTarget.Target;

                OracleParameter SetDate_OP = new OracleParameter();
                SetDate_OP.Direction = System.Data.ParameterDirection.Input;
                SetDate_OP.OracleDbType = OracleDbType.Date;
                SetDate_OP.Value = Convert.ToDateTime(retailerTarget.SetDate.Split('/')[2] + "/" + retailerTarget.SetDate.Split('/')[1] + "/" + retailerTarget.SetDate.Split('/')[0]).Date;

                OracleParameter UpTo_OP = new OracleParameter();
                UpTo_OP.Direction = System.Data.ParameterDirection.Input;
                UpTo_OP.OracleDbType = OracleDbType.Date;
                UpTo_OP.Value = Convert.ToDateTime(retailerTarget.UpTo.Split('/')[2] + "/" + retailerTarget.UpTo.Split('/')[1] + "/" + retailerTarget.UpTo.Split('/')[0]).Date;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENUGROUP_WEB>.InsertDataBySP("SP_SAVE_RETAILER_TARGET_WB", resultOutID, ActionFlag_OP, TargetId_OP, ItemId_OP, PeriodId_OP, StaffCode_OP, StaffType_OP, Target_OP, SetDate_OP, UpTo_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal DeleteInfo(decimal trainingId)
        {
            try
            {
                OracleParameter trainingId_OP = new OracleParameter();
                trainingId_OP.Direction = System.Data.ParameterDirection.Input;
                trainingId_OP.OracleDbType = OracleDbType.Decimal;
                trainingId_OP.Value = trainingId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_SURVEY_DETAIL_Q_ANScls>.InsertDataBySP("SP_FF_DELETE_RETAILER_TARGET", resultOutID, trainingId_OP);             //SP_FF_DELETE_TRAININT_CONTENT
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
