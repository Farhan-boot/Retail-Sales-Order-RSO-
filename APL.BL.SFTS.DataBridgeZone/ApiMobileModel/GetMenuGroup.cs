using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
    public class GetMenuGrouplIST
    {
		
		public Int32 MENUITEM_ID { get; set; }		
		public String MENU_NAME { get; set; }		
		public String MENU_URL { get; set; }		
		public Int32 GROUP_ID { get; set; }
		public List<SP_FF_GET_MENU_GROUP_ITEM_LIST> MENU_GROUP_ITEM { get; set; }
	}

	/*
	public class GetMenuGroup
	{
		public int GROUP_ID { get; set; }
		public string GROUP_NAME { get; set; }
		public List<GetGroupMenus> MENU_GROUP_ITEM { get; set; }
	} */
}
