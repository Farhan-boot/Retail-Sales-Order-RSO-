using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
	/*
	public class GetGroupMenu
	{
		public int GROUP_ID { get; set; }
		public string GROUP_NAME { get; set; }
		public List<GetGroupMenus> MENU_GROUP_ITEM { get; set; }
	}*/

	
	public class GetMenuByHeaderBodyFooter
	{
        public GetMenuByHeaderBodyFooter()
        {
          //  Header = new List<SP_FF_GET_MENU_GROUP_ITEM_LIST>();
            Body = new List<GetMenuGrouplIST>();
		//	Footer = new List<SP_FF_GET_MENU_GROUP_ITEM_LIST>();
		}

     //   public List<SP_FF_GET_MENU_GROUP_ITEM_LIST> Header { get; set; }
        public List<GetMenuGrouplIST> Body { get; set; }
	//	public List<SP_FF_GET_MENU_GROUP_ITEM_LIST> Footer { get; set; }

	} 
}
