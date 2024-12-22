using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{ 
   public class GetTodayHighlights
    {
       public GetHighlights data { get; set; }
       public int status_code { get; set; }
    }


	public class GetTodayHighlightsMTO
	{
		public GetHighlightsMTO data { get; set; }
		public int status_code { get; set; }
	}
}
