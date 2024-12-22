using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using APL.BL.SFTS.ShelterZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class MenuPZ
    {
        public MenuPZ()
        { }

        public List<SP_GET_MENU> GetMainMenu(decimal UserId)
        {
            List<SP_GET_MENU> mainMenuList = new List<SP_GET_MENU>();
            try
            {
                mainMenuList = new MenuDZ().GetMainMenu(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return mainMenuList;
        }

        public List<SP_GET_MENU> GetSubMenu(decimal UserId, decimal MainMenuId)
        {
            List<SP_GET_MENU> subMenuList = new List<SP_GET_MENU>();
            try
            {
                subMenuList = new MenuDZ().GetSubMenu(UserId, MainMenuId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return subMenuList;
        }

        public List<SP_GET_ROLE_WISE_PERMISSION> GetRoleWisePermission(decimal UserId, string PermissionCode)
        {
            List<SP_GET_ROLE_WISE_PERMISSION> roleWisePermission = new List<SP_GET_ROLE_WISE_PERMISSION>();
            try
            {
                roleWisePermission = new MenuDZ().GetRoleWisePermission(UserId, PermissionCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return roleWisePermission;
        }

        public List<SP_GET_PERMISSION> GetPermissions(decimal RoleId)
        {
            List<SP_GET_PERMISSION> permissionList = new List<SP_GET_PERMISSION>();
            try
            {
                permissionList = new MenuDZ().GetPermissions(RoleId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return permissionList;
        }

        public List<SP_GET_USER_ROLE> GetUserRoles(decimal UserId)
        {
            List<SP_GET_USER_ROLE> roleList = new List<SP_GET_USER_ROLE>();
            try
            {
                roleList = new MenuDZ().GetUserRoles(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return roleList;
        }

        public Decimal SaveUpdatePermissions(decimal PermissionId, decimal RoleId, decimal IsActive, decimal CreatedBy)
        {
            try
            {
                return new MenuDZ().SaveUpdatePermissions(PermissionId, RoleId, IsActive, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateUserRoles(decimal UserId, decimal RoleId, decimal IsActive, decimal CreatedBy)
        {
            try
            {
                return new MenuDZ().SaveUpdateUserRoles(UserId, RoleId, IsActive, CreatedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
