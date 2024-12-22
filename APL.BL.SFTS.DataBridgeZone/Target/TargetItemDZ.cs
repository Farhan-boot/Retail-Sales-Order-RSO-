using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.Target
{
   public class TargetItemDZ
    {
        public TargetItemDZ() { }

        public Decimal SaveUpdateTargetItem(decimal TargetItemId, string Code, string Name, decimal IsActive, string UnitName)
        {
            try
            {
                OracleParameter TargetItemId_OP = new OracleParameter();
                TargetItemId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetItemId_OP.OracleDbType = OracleDbType.Decimal;
                TargetItemId_OP.Value = TargetItemId;

                OracleParameter Code_OP = new OracleParameter();
                Code_OP.Direction = System.Data.ParameterDirection.Input;
                Code_OP.OracleDbType = OracleDbType.Varchar2;
                Code_OP.Value = Code;

                OracleParameter Name_OP = new OracleParameter();
                Name_OP.Direction = System.Data.ParameterDirection.Input;
                Name_OP.OracleDbType = OracleDbType.Varchar2;
                Name_OP.Value = Name;

                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = System.Data.ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Decimal;
                IsActive_OP.Value = IsActive;

                OracleParameter UnitName_OP = new OracleParameter();
                UnitName_OP.Direction = System.Data.ParameterDirection.Input;
                UnitName_OP.OracleDbType = OracleDbType.Varchar2;
                UnitName_OP.Value = UnitName;

                OracleParameter outIDOP = new OracleParameter();
                outIDOP.Direction = System.Data.ParameterDirection.Output;
                outIDOP.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_TARGET_ITEM>.InsertDataBySP("SP_FF_INS_UPD_TARGET_ITEM", outIDOP, TargetItemId_OP, Code_OP, Name_OP, IsActive_OP, UnitName_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateTargetItemApplyTo(decimal TargetItemApplyToId, decimal TargetItemId, decimal ChannelTypeId, decimal TargetEntityType, decimal? StaffTypeId, decimal? CenterTypeId, decimal DistributorIsSumOfStaff, decimal StaffIsSumOfCenter, decimal IsActive)
        {
            try
            {
                OracleParameter TargetItemApplyToId_OP = new OracleParameter();
                TargetItemApplyToId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetItemApplyToId_OP.OracleDbType = OracleDbType.Decimal;
                TargetItemApplyToId_OP.Value = TargetItemApplyToId;

                OracleParameter TargetItemId_OP = new OracleParameter();
                TargetItemId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetItemId_OP.OracleDbType = OracleDbType.Decimal;
                TargetItemId_OP.Value = TargetItemId;

                OracleParameter ChannelTypeId_OP = new OracleParameter();
                ChannelTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                ChannelTypeId_OP.OracleDbType = OracleDbType.Decimal;
                ChannelTypeId_OP.Value = ChannelTypeId;

                OracleParameter TargetEntityType_OP = new OracleParameter();
                TargetEntityType_OP.Direction = System.Data.ParameterDirection.Input;
                TargetEntityType_OP.OracleDbType = OracleDbType.Decimal;
                TargetEntityType_OP.Value = TargetEntityType;

                OracleParameter StaffTypeId_OP = new OracleParameter();
                StaffTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                StaffTypeId_OP.OracleDbType = OracleDbType.Decimal;
                StaffTypeId_OP.Value = StaffTypeId;

                OracleParameter CenterTypeId_OP = new OracleParameter();
                CenterTypeId_OP.Direction = System.Data.ParameterDirection.Input;
                CenterTypeId_OP.OracleDbType = OracleDbType.Decimal;
                CenterTypeId_OP.Value = CenterTypeId;

                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = System.Data.ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Decimal;
                IsActive_OP.Value = IsActive;

                OracleParameter outIDOP = new OracleParameter();
                outIDOP.Direction = System.Data.ParameterDirection.Output;
                outIDOP.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<GET_TARGET_ITEM_APPLY_TO>.InsertDataBySP("SP_FF_INS_UPD_TARGET_ITM_APLY", outIDOP, TargetItemApplyToId_OP, TargetItemId_OP, ChannelTypeId_OP, TargetEntityType_OP, StaffTypeId_OP, CenterTypeId_OP, IsActive_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_TARGET_ITEM> GetTargetItems(decimal TargetItemId, decimal UserId)
        {
            try
            {
                OracleParameter TargetItemId_OP = new OracleParameter();
                TargetItemId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetItemId_OP.OracleDbType = OracleDbType.Decimal;
                TargetItemId_OP.Value = TargetItemId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_TARGET_ITEM>)ObjectMakerFromOracleSP.OracleHelper<GET_TARGET_ITEM>.GetDataBySP(new GET_TARGET_ITEM(), "SP_FF_GET_TARGET_ITEM", 6, resultOutCurSor, TargetItemId_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<GET_TARGET_ITEM_APPLY_TO> GetTargetItemApplyTo(decimal TargetApplyToId ,decimal TargetItemId)
        {
            try
            {
                OracleParameter TargetApplyToId_OP = new OracleParameter();
                TargetApplyToId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetApplyToId_OP.OracleDbType = OracleDbType.Decimal;
                TargetApplyToId_OP.Value = TargetApplyToId;

                OracleParameter TargetItemId_OP = new OracleParameter();
                TargetItemId_OP.Direction = System.Data.ParameterDirection.Input;
                TargetItemId_OP.OracleDbType = OracleDbType.Decimal;
                TargetItemId_OP.Value = TargetItemId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_TARGET_ITEM_APPLY_TO>)ObjectMakerFromOracleSP.OracleHelper<GET_TARGET_ITEM_APPLY_TO>.GetDataBySP(new GET_TARGET_ITEM_APPLY_TO(), "SP_FF_GET_TARGET_ITEM_APPLY_TO", 10, resultOutCurSor, TargetApplyToId_OP, TargetItemId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
