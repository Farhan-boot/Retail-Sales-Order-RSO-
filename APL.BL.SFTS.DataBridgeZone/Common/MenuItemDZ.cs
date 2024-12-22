using APL.BL.SFTS.DataBridgeZone.SP_Class;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.Common
{
    public class MenuItemDZ
    {
        public MenuItemDZ()
        { }

        public List<SP_GET_MENUITEM_WEB> GetMenuItems(decimal MenuItemId, decimal UserId, decimal MenuFor)
        {
            try
            {
                OracleParameter MenuItemId_OP = new OracleParameter();
                MenuItemId_OP.Direction = System.Data.ParameterDirection.Input;
                MenuItemId_OP.OracleDbType = OracleDbType.Decimal;
                MenuItemId_OP.Value = MenuItemId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter MenuFor_OP = new OracleParameter();
                MenuFor_OP.Direction = System.Data.ParameterDirection.Input;
                MenuFor_OP.OracleDbType = OracleDbType.Decimal;
                MenuFor_OP.Value = MenuFor;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_MENUITEM_WEB>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENUITEM_WEB>.GetDataBySP(new SP_GET_MENUITEM_WEB(), "SP_GET_MENUITEM_WEB", 12, resultOutCurSor, MenuItemId_OP, MenuFor_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_MENUITEM_WEB> GetMenuGroups(decimal MenuItemId, decimal UserId, decimal MenuFor)
        {
            try
            {
                OracleParameter MenuItemId_OP = new OracleParameter();
                MenuItemId_OP.Direction = System.Data.ParameterDirection.Input;
                MenuItemId_OP.OracleDbType = OracleDbType.Decimal;
                MenuItemId_OP.Value = MenuItemId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter MenuFor_OP = new OracleParameter();
                MenuFor_OP.Direction = System.Data.ParameterDirection.Input;
                MenuFor_OP.OracleDbType = OracleDbType.Decimal;
                MenuFor_OP.Value = MenuFor;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_MENUITEM_WEB>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENUITEM_WEB>.GetDataBySP(new SP_GET_MENUITEM_WEB(), "SP_GET_MENUGROUP_WEB", 12, resultOutCurSor, MenuItemId_OP, MenuFor_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Decimal SaveMenuItem(decimal ActionFlag, decimal ItemId, string MenuName, string MenuNameB, string MenuUrl, decimal MenuFor, decimal IsActive, decimal ParentId, decimal IsHeader, decimal UserId)
        {
            try
            {
                OracleParameter ActionFlag_OP = new OracleParameter();
                ActionFlag_OP.Direction = System.Data.ParameterDirection.Input;
                ActionFlag_OP.OracleDbType = OracleDbType.Decimal;
                ActionFlag_OP.Value = ActionFlag;

                OracleParameter ItemId_OP = new OracleParameter();
                ItemId_OP.Direction = System.Data.ParameterDirection.Input;
                ItemId_OP.OracleDbType = OracleDbType.Varchar2;
                ItemId_OP.Value = ItemId;

                OracleParameter MenuName_OP = new OracleParameter();
                MenuName_OP.Direction = System.Data.ParameterDirection.Input;
                MenuName_OP.OracleDbType = OracleDbType.Varchar2;
                MenuName_OP.Value = MenuName;

                OracleParameter MenuNameB_OP = new OracleParameter();
                MenuNameB_OP.Direction = System.Data.ParameterDirection.Input;
                MenuNameB_OP.OracleDbType = OracleDbType.NVarchar2;
                MenuNameB_OP.Value = MenuNameB;

                OracleParameter MenuUrl_OP = new OracleParameter();
                MenuUrl_OP.Direction = System.Data.ParameterDirection.Input;
                MenuUrl_OP.OracleDbType = OracleDbType.Varchar2;
                MenuUrl_OP.Value = MenuUrl;

                OracleParameter MenuFor_OP = new OracleParameter();
                MenuFor_OP.Direction = System.Data.ParameterDirection.Input;
                MenuFor_OP.OracleDbType = OracleDbType.Decimal;
                MenuFor_OP.Value = MenuFor;

                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = System.Data.ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Decimal;
                IsActive_OP.Value = IsActive;

                OracleParameter ParentId_OP = new OracleParameter();
                ParentId_OP.Direction = System.Data.ParameterDirection.Input;
                ParentId_OP.OracleDbType = OracleDbType.Decimal;
                ParentId_OP.Value = ParentId;

                OracleParameter IsHeader_OP = new OracleParameter();
                IsHeader_OP.Direction = System.Data.ParameterDirection.Input;
                IsHeader_OP.OracleDbType = OracleDbType.Decimal;
                IsHeader_OP.Value = IsHeader;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENUGROUP_WEB>.InsertDataBySP("SP_SAVE_MENUITEM_WEB", resultOutID, ActionFlag_OP, ItemId_OP, MenuName_OP, MenuNameB_OP, MenuUrl_OP, MenuFor_OP, IsActive_OP, ParentId_OP, IsHeader_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal DeleteInfo(decimal itemId)
        {
            try
            {
                OracleParameter itemId_OP = new OracleParameter();
                itemId_OP.Direction = System.Data.ParameterDirection.Input;
                itemId_OP.OracleDbType = OracleDbType.Decimal;
                itemId_OP.Value = itemId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_SURVEY_DETAIL_Q_ANScls>.InsertDataBySP("SP_FF_DELETE_APP_MENU", resultOutID, itemId_OP);             
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal UpdateSrlNo(decimal itemId, decimal srlNo)
        {
            try
            {
                OracleParameter itemId_OP = new OracleParameter();
                itemId_OP.Direction = System.Data.ParameterDirection.Input;
                itemId_OP.OracleDbType = OracleDbType.Decimal;
                itemId_OP.Value = itemId;

                OracleParameter srlNo_OP = new OracleParameter();
                srlNo_OP.Direction = System.Data.ParameterDirection.Input;
                srlNo_OP.OracleDbType = OracleDbType.Decimal;
                srlNo_OP.Value = srlNo;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_SURVEY_DETAIL_Q_ANScls>.InsertDataBySP("SP_FF_UPD_APPMENU_SRLNO", resultOutID, itemId_OP, srlNo_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
