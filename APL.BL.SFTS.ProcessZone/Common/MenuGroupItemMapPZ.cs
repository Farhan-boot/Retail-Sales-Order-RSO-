using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.Common;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.Common
{
    public class MenuGroupItemMapPZ
    {
        public MenuGroupItemMapPZ()
        { }

        public List<SP_GET_GROUPITEM_MAP_WEB> GetMenuGroupItemMaps(decimal MappingId, decimal UserId)
        {
            List<SP_GET_GROUPITEM_MAP_WEB> mainMenuList = new List<SP_GET_GROUPITEM_MAP_WEB>();
            try
            {
                mainMenuList = new MenuGroupItemMapDZ().GetMenuGroupItemMaps(MappingId, UserId);
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
        public Decimal SaveMenuGroupItemMaps(GroupItemMap groupItems, decimal UserId)
        {
            decimal result = 0;
            try
            {
                decimal IsEventSaved = 0;
                int i = 0;
                foreach (var item in groupItems.ItemIds.Split(','))
                {
                    if(item.Trim()!="")
                    {
                        groupItems.ItemId = Convert.ToDecimal(item.Trim());
                        IsEventSaved = new MenuGroupItemMapDZ().SaveMenuGroupItemMap(i, groupItems, UserId);
                        i++;
                    }

                }
               
                result = IsEventSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public List<SP_GET_MENUITEM_WEB> GetMenuItems(decimal MenuGroupId, decimal UserId)
        {
            List<SP_GET_MENUITEM_WEB> mainMenuList = new List<SP_GET_MENUITEM_WEB>();
            try
            {
                mainMenuList = new MenuGroupItemMapDZ().GetMenuItems(MenuGroupId, UserId);
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
    }
}
