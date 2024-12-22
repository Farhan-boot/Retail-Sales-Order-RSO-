using APL.BL.SFTS.DataBridgeZone.Common;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.Common
{
    public class MenuItemPZ
    {
        public List<SP_GET_MENUITEM_WEB> GetMenuItems(decimal MenuItemId, decimal UserId, decimal MenuFor)
        {
            List<SP_GET_MENUITEM_WEB> mainMenuList = new List<SP_GET_MENUITEM_WEB>();
            try
            {
                mainMenuList = new MenuItemDZ().GetMenuItems(MenuItemId, UserId,MenuFor);
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
        public List<SP_GET_MENUITEM_WEB> GetMenuGroups(decimal MenuItemId, decimal UserId, decimal MenuFor)
        {
            List<SP_GET_MENUITEM_WEB> mainMenuList = new List<SP_GET_MENUITEM_WEB>();
            try
            {
                mainMenuList = new MenuItemDZ().GetMenuGroups(MenuItemId, UserId, MenuFor);
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
        public Decimal SaveMenuItem(decimal ActionFlag, decimal ItemId, string MenuName, string MenuNameB, string MenuUrl, decimal MenuFor, decimal IsActive, decimal ParentId, decimal IsHeader, decimal UserId)
        {
            decimal result = 0;
            try
            {
                decimal IsEventSaved = 0;
                IsEventSaved = new MenuItemDZ().SaveMenuItem(ActionFlag, ItemId, MenuName, MenuNameB, MenuUrl, MenuFor, IsActive,ParentId,IsHeader, UserId);
                result = IsEventSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public decimal DeleteInfo(decimal itemId)
        {
            try
            {
                return new MenuItemDZ().DeleteInfo(itemId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal UpdateSrlNo(decimal itemId,decimal srlNo)
        {
            try
            {
                return new MenuItemDZ().UpdateSrlNo(itemId, srlNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
