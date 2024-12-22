using APL.BL.SFTS.DataBridgeZone.SP_Class;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.Common
{
    public class MenuGroupDZ
    {
        public MenuGroupDZ()
        { }

        public List<SP_GET_MENUGROUP_WEB> GetMenuGroups(decimal MenuGroupId, decimal UserId)
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

                return (List<SP_GET_MENUGROUP_WEB>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENUGROUP_WEB>.GetDataBySP(new SP_GET_MENUGROUP_WEB(), "SP_GET_MENUGROUP_WEB", 5, resultOutCurSor, MenuGroupId_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Decimal SaveMenuGroup(decimal ActionFlag, decimal GroupId, string GroupName, decimal GroupFor,decimal IsActive, decimal UserId)
        {
            try
            {
                OracleParameter ActionFlag_OP = new OracleParameter();
                ActionFlag_OP.Direction = System.Data.ParameterDirection.Input;
                ActionFlag_OP.OracleDbType = OracleDbType.Decimal;
                ActionFlag_OP.Value = ActionFlag;

                OracleParameter GroupId_OP = new OracleParameter();
                GroupId_OP.Direction = System.Data.ParameterDirection.Input;
                GroupId_OP.OracleDbType = OracleDbType.Varchar2;
                GroupId_OP.Value = GroupId;

                OracleParameter GroupName_OP = new OracleParameter();
                GroupName_OP.Direction = System.Data.ParameterDirection.Input;
                GroupName_OP.OracleDbType = OracleDbType.Varchar2;
                GroupName_OP.Value = GroupName;

                OracleParameter GroupFor_OP = new OracleParameter();
                GroupFor_OP.Direction = System.Data.ParameterDirection.Input;
                GroupFor_OP.OracleDbType = OracleDbType.Decimal;
                GroupFor_OP.Value = GroupFor;

                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = System.Data.ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Decimal;
                IsActive_OP.Value = IsActive;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENUGROUP_WEB>.InsertDataBySP("SP_SAVE_MENUGROUP_WEB", resultOutID, ActionFlag_OP, GroupId_OP, GroupName_OP, GroupFor_OP, IsActive_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
