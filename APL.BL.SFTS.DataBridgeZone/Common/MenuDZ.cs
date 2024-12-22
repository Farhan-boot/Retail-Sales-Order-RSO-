using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class MenuDZ
    {
        public MenuDZ()
        { }

        public List<SP_GET_MENU> GetMainMenu(decimal UserId)
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

                return (List<SP_GET_MENU>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENU>.GetDataBySP(new SP_GET_MENU(), "SP_FF_GET_MAIN_MENU_V2", 6, resultOutCurSor, UserId_OP);
                //return (List<SP_GET_MENU>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENU>.GetDataBySP(new SP_GET_MENU(), "SP_FF_GET_MAIN_MENU", 6, resultOutCurSor, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_MENU> GetSubMenu(decimal UserId, decimal MainMenuId)
        {
            try
            {
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter MainMenuId_OP = new OracleParameter();
                MainMenuId_OP.Direction = System.Data.ParameterDirection.Input;
                MainMenuId_OP.OracleDbType = OracleDbType.Decimal;
                MainMenuId_OP.Value = MainMenuId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_MENU>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENU>.GetDataBySP(new SP_GET_MENU(), "SP_FF_GET_SUB_MENU_V2", 6, resultOutCurSor, UserId_OP, MainMenuId_OP);
                //return (List<SP_GET_MENU>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENU>.GetDataBySP(new SP_GET_MENU(), "SP_FF_GET_SUB_MENU", 6, resultOutCurSor, UserId_OP, MainMenuId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_ROLE_WISE_PERMISSION> GetRoleWisePermission(decimal UserId, string PermissionCode)
        {
            try
            {
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter PermissionCode_OP = new OracleParameter();
                PermissionCode_OP.Direction = System.Data.ParameterDirection.Input;
                PermissionCode_OP.OracleDbType = OracleDbType.Varchar2;
                PermissionCode_OP.Value = PermissionCode;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_ROLE_WISE_PERMISSION>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ROLE_WISE_PERMISSION>.GetDataBySP(new SP_GET_ROLE_WISE_PERMISSION(), "SP_FF_GET_ROLE_WISE_PERMISSION", 4, resultOutCurSor, UserId_OP, PermissionCode_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_PERMISSION> GetPermissions(decimal RoleId)
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

                return (List<SP_GET_PERMISSION>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_PERMISSION>.GetDataBySP(new SP_GET_PERMISSION(), "SP_FF_GET_PERMISSIONS", 5, resultOutCurSor, RoleId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_USER_ROLE> GetUserRoles(decimal UserId)
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

                return (List<SP_GET_USER_ROLE>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_USER_ROLE>.GetDataBySP(new SP_GET_USER_ROLE(), "SP_FF_GET_USER_ROLES", 4, resultOutCurSor, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public decimal SaveUpdatePermissions(decimal PermissionId, decimal RoleId, decimal IsActive, decimal CreatedBy)
        {
            try
            {
                OracleParameter PermissionId_OP = new OracleParameter();
                PermissionId_OP.Direction = ParameterDirection.Input;
                PermissionId_OP.OracleDbType = OracleDbType.Decimal;
                PermissionId_OP.Value = PermissionId;

                OracleParameter RoleId_OP = new OracleParameter();
                RoleId_OP.Direction = ParameterDirection.Input;
                RoleId_OP.OracleDbType = OracleDbType.Decimal;
                RoleId_OP.Value = RoleId;

                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Decimal;
                IsActive_OP.Value = IsActive;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_PERMISSION>.InsertDataBySP("SP_FF_IN_UP_ROLE_PERMISSION", resultOutID, RoleId_OP, PermissionId_OP, IsActive_OP, CreatedBy_OP);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public decimal SaveUpdateUserRoles(decimal UserId, decimal RoleId, decimal IsActive, decimal CreatedBy)
        {
            try
            {
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter RoleId_OP = new OracleParameter();
                RoleId_OP.Direction = ParameterDirection.Input;
                RoleId_OP.OracleDbType = OracleDbType.Decimal;
                RoleId_OP.Value = RoleId;

                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Decimal;
                IsActive_OP.Value = IsActive;

                OracleParameter CreatedBy_OP = new OracleParameter();
                CreatedBy_OP.Direction = ParameterDirection.Input;
                CreatedBy_OP.OracleDbType = OracleDbType.Decimal;
                CreatedBy_OP.Value = CreatedBy;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_PERMISSION>.InsertDataBySP("SP_FF_IN_UP_USER_ROLE", resultOutID, RoleId_OP, UserId_OP, IsActive_OP, CreatedBy_OP);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
