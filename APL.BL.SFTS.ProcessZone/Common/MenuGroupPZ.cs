using APL.BL.SFTS.DataBridgeZone.Common;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.Common
{
    public class MenuGroupPZ
    {
        public MenuGroupPZ()
        { }

        public List<SP_GET_MENUGROUP_WEB> GetMenuGroups(decimal MenuGroupId,decimal UserId)
        {
            List<SP_GET_MENUGROUP_WEB> mainMenuList = new List<SP_GET_MENUGROUP_WEB>();
            try
            {
                mainMenuList = new MenuGroupDZ().GetMenuGroups(MenuGroupId,UserId);
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

        public Decimal SaveMenuGroup(decimal ActionFlag,decimal GroupId, string GroupName, decimal GroupFor, decimal IsActive, decimal UserId)
        {
            decimal result = 0;
            try
            {
                decimal IsEventSaved = 0;
                IsEventSaved = new MenuGroupDZ().SaveMenuGroup(ActionFlag, GroupId, GroupName, GroupFor, IsActive, UserId);
                result = IsEventSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
