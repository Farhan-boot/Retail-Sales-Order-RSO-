using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.Common
{
    public class MenuGroupItemMapDZ
    {
        public MenuGroupItemMapDZ()
        { }

        public List<SP_GET_GROUPITEM_MAP_WEB> GetMenuGroupItemMaps(decimal MappingId, decimal UserId)
        {
            try
            {
                OracleParameter MappingId_OP = new OracleParameter();
                MappingId_OP.Direction = System.Data.ParameterDirection.Input;
                MappingId_OP.OracleDbType = OracleDbType.Decimal;
                MappingId_OP.Value = MappingId;

                OracleParameter GroupId_OP = new OracleParameter();
                GroupId_OP.Direction = System.Data.ParameterDirection.Input;
                GroupId_OP.OracleDbType = OracleDbType.Decimal;
                GroupId_OP.Value = 0;

                OracleParameter ItemId_OP = new OracleParameter();
                ItemId_OP.Direction = System.Data.ParameterDirection.Input;
                ItemId_OP.OracleDbType = OracleDbType.Decimal;
                ItemId_OP.Value = 0;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_GROUPITEM_MAP_WEB>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_GROUPITEM_MAP_WEB>.GetDataBySP(new SP_GET_GROUPITEM_MAP_WEB(), "SP_GET_GROUPITEM_MAP_WEB",9, resultOutCurSor, MappingId_OP, GroupId_OP, ItemId_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Decimal SaveMenuGroupItemMap(int Index, GroupItemMap groupItems, decimal UserId)
        {
            try
            {
                OracleParameter Index_OP = new OracleParameter();
                Index_OP.Direction = System.Data.ParameterDirection.Input;
                Index_OP.OracleDbType = OracleDbType.Decimal;
                Index_OP.Value = Index;

                OracleParameter ActionFlag_OP = new OracleParameter();
                ActionFlag_OP.Direction = System.Data.ParameterDirection.Input;
                ActionFlag_OP.OracleDbType = OracleDbType.Decimal;
                ActionFlag_OP.Value = groupItems.ActionFlag;

                OracleParameter MappingId_OP = new OracleParameter();
                MappingId_OP.Direction = System.Data.ParameterDirection.Input;
                MappingId_OP.OracleDbType = OracleDbType.Decimal;
                MappingId_OP.Value = groupItems.MappingId;

                OracleParameter GroupId_OP = new OracleParameter();
                GroupId_OP.Direction = System.Data.ParameterDirection.Input;
                GroupId_OP.OracleDbType = OracleDbType.Decimal;
                GroupId_OP.Value = groupItems.GroupId;


                OracleParameter ItemId_OP = new OracleParameter();
                ItemId_OP.Direction = System.Data.ParameterDirection.Input;
                ItemId_OP.OracleDbType = OracleDbType.Decimal;
                ItemId_OP.Value = groupItems.ItemId;

                OracleParameter MappingFor_OP = new OracleParameter();
                MappingFor_OP.Direction = System.Data.ParameterDirection.Input;
                MappingFor_OP.OracleDbType = OracleDbType.Decimal;
                MappingFor_OP.Value = groupItems.MappingFor;

                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = System.Data.ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Varchar2;
                IsActive_OP.Value = groupItems.IsActive;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Varchar2;
                UserId_OP.Value = UserId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                var result = ObjectMakerFromOracleSP.OracleHelper<SP_GET_GROUPITEM_MAP_WEB>.InsertDataBySP("SP_SAVE_GROUPITEM_MAP_WEB", resultOutID, Index_OP,ActionFlag_OP, MappingId_OP, GroupId_OP, ItemId_OP, MappingFor_OP, IsActive_OP, UserId_OP);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_MENUITEM_WEB> GetMenuItems(decimal MenuGroupId, decimal UserId)
        {
            try
            {
                OracleParameter MenuGroupId_OP = new OracleParameter();
                MenuGroupId_OP.Direction = System.Data.ParameterDirection.Input;
                MenuGroupId_OP.OracleDbType = OracleDbType.Decimal;
                MenuGroupId_OP.Value = MenuGroupId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_MENUITEM_WEB>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENUITEM_WEB>.GetDataBySP(new SP_GET_MENUITEM_WEB(), "SP_GET_MENUITEM_WEB", 7, resultOutCurSor, MenuGroupId_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
